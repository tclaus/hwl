
Imports DevExpress
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports Microsoft.Win32

Namespace Tools

    ''' <summary>
    ''' Verwaltet Datenbankverbindungen. enthält eine Statische Liste von Verbindungen und steuert das Laden und Speichern. 
    ''' Verbindungen wedrden nicht in der Datenbank gespeichert sondern in der Registry
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Connections


        ''' <summary>
        ''' enthält eine interne Auflistung der zur Verfügung stehenden Datenbankverbindungen
        ''' </summary>
        ''' <remarks></remarks>
        Private m_connectionList As New System.Collections.Generic.List(Of Connection)()
        ''' <summary>
        ''' Enthält den Standard Registry - Pfad zum server-Verzeichnis
        ''' </summary>
        ''' <remarks></remarks>
        Private m_serverKeyValue As String
        Private m_currentValueRegKey As String

        Private m_DefaultHWLID As String = String.Empty
        Private m_defaultConnection As Connection


        Public Shared IsValid As Boolean
        Public Shared LastErrorMessage As String
        Private Const ConnectionFilename As String = "connections.dat"

        ''' <summary>
        ''' Ruft den Namen und vollständigen Pfad der Profile-Datei fest, die die Verbindungen speichert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ProfileFilename() As String
            Get
                Dim connectionName As String
                connectionName = System.IO.Path.Combine(ClausSoftware.Tools.Services.GetSpecialFolder(Services.SpecialFolderConst.CSIDL_APPDATA), MainApplication.ApplicationName)
                If Not System.IO.Directory.Exists(connectionName) Then
                    System.IO.Directory.CreateDirectory(connectionName)
                End If

                connectionName = System.IO.Path.Combine(connectionName, ConnectionFilename)
                Return connectionName
            End Get
        End Property

        ''' <summary>
        ''' Falls keine Verbindungs-Datei existiert, wird hier "True" zurückgegeben und der erste Start angenommen.
        ''' während des Starts der Applikation wird eine Datei erzeugt, dann wird hier ein "True" zurückgegeben.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property FirstStart() As Boolean
            Get
                'Return True
                ' Erster Start ist, wenn keine Profile-Datei existiert
                Return Not System.IO.File.Exists(ProfileFilename)

            End Get
        End Property

        ''' <summary>
        ''' Ermittelt aus dem übergebenen Connection - Objekt das Session-Objekt für die Datenbindung 
        ''' </summary>
        ''' <param name="actualConnection"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSessionFromConnectionData(ByVal actualConnection As Connection) As DevExpress.Xpo.Session
            Dim session As New DevExpress.Xpo.Session
            session.ConnectionString = GetConnectionString(actualConnection)

            Return session
        End Function

        ''' <summary>
        ''' Ermittelt einen vollständigen ConnectionString aus dem angegebenen Connection-Objekt
        ''' </summary>
        ''' <param name="actualConnection"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetConnectionString(ByVal actualConnection As Connection) As String

            If actualConnection.Servertype = enumServerType.Access Then

                Return "XpoProvider=MSAccess;" & GetSimpleConnectionString(actualConnection)
            End If

            If actualConnection.Servertype = enumServerType.MySQL Then
                Return "XpoProvider=MySql;" & GetSimpleConnectionString(actualConnection)
            End If

            Return ""
        End Function

        ''' <summary>
        ''' Ruft den ConnectionString der einfachen Standard -Datenbank ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetSimpelDefaultDatabase() As Connection
            Dim conn As New Connection

            With conn
                .AliasName = "Standard"
                .Path = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
                .Path = System.IO.Path.Combine(.Path, MainApplication.ApplicationName)
                .BackupPath = System.IO.Path.Combine(.Path, "Backup")
                .IsDefault = True
                .Servertype = enumServerType.Access


            End With
            Return conn
        End Function



        ''' <summary>
        ''' Ruft einen Connection String ab ohne die XPO-Spezifischen Provider (MySQL)
        ''' </summary>
        ''' <param name="actualConnection"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetSimpleConnectionString(ByVal actualConnection As Connection) As String

            If actualConnection Is Nothing Then ' Kann nothing bei der Erstinstallation sein, dann auch keine Connection zurückgeben
                Return ""
            End If

            If actualConnection.Servertype = enumServerType.Access Then

                actualConnection.Password = Services.GetDBPassword(actualConnection.Path)
                Dim FilePath As String

                If System.IO.Path.GetFileName(actualConnection.Path).Equals("daten.mdb", StringComparison.InvariantCultureIgnoreCase) Then
                    FilePath = actualConnection.Path
                Else
                    FilePath = System.IO.Path.Combine(actualConnection.Path, "daten.mdb")
                End If


                Dim accessConnectionString As String '= AccessConnectionProvider.GetConnectionStringACE(actualConnection.Path, actualConnection.Password)
                accessConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False ; Data Source='" & FilePath & "'"

                If actualConnection.Password.Length > 0 Then
                    accessConnectionString &= " ;JET OLEDB:Database Password=" & actualConnection.Password & ";"
                End If


                Return accessConnectionString
            End If

            If actualConnection.Servertype = enumServerType.MySQL Then
                Dim mysqlConnectionString As String
                mysqlConnectionString = "Server=" & actualConnection.ServerHostName & _
                " ;Database=" & actualConnection.Database & _
                " ;User ID='" & actualConnection.Username & "'" & _
                " ;Password='" & actualConnection.Password & "' " & _
                ";Use Compression = TRUE"
                Return mysqlConnectionString

            End If

            Return ""
        End Function
        ''' <summary>
        ''' Ruft die Datenverbindung ab, mit der eine Verbindung hergestellt werden soll. 
        ''' Berücksicht dabei, das die Standardverbindung durch Kommandozeilenparameter überschrieben werden kann
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property WorkConnection As Connection
            Get
                Dim commandLineOverride As String = GetCommandLineDefaultConnection()

                If Not String.IsNullOrEmpty(commandLineOverride) Then
                    Dim overrideConnection As Connection = GetConnectionByName(commandLineOverride)
                    If overrideConnection IsNot Nothing Then
                        Return overrideConnection
                    End If
                End If
                ' Falls keine Kommandline - Verbindung gefunden werden konnte, dann die als Standard markierte Verbindnung wählen
                Return Me.DefaultConnection

            End Get
        End Property

        ''' <summary>
        ''' Ruft die aktuelle Datenbankverbindung ab oder setzt diese. Existiert die angegebene Verbindung nicht in der Auflistung, 
        ''' wird diese hinzugefügt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DefaultConnection() As Connection
            <DebuggerStepThrough()> _
            Get

                Return m_defaultConnection
            End Get
            Set(ByVal value As Connection)

                If value Is Nothing Then
                    m_defaultConnection.IsDefault = False
                    m_defaultConnection = Nothing
                    Exit Property
                End If

                If Not Me.m_connectionList.Contains(value) Then
                    m_connectionList.Add(value)
                End If
                'alle anderen den default-status entziehen

                For Each item As Connection In m_connectionList
                    item.IsDefault = False
                    If item.Equals(value) Then
                        item.IsDefault = True
                        m_defaultConnection = item
                    End If
                Next


            End Set
        End Property

        ''' <summary>
        ''' Ruft die Datenbankverbindung anhand des Namens ab. 
        ''' Gibt es mehrere Verbindnungen mit dem selben Namen, wird er erste Treffer zurückgegeben
        ''' </summary>
        ''' <param name="connectionName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetConnectionByName(ByVal connectionName As String) As Connection
            For Each item As Connection In m_connectionList
                If item.AliasName.Equals(connectionName, StringComparison.InvariantCultureIgnoreCase) Then
                    Return item
                End If
            Next

            Return Nothing

        End Function

        ''' <summary>
        ''' Durchsucht die Commandline nach dem string "/db:" und ermittelt anhand des Namens die Connection, die als Default verwendet werden soll
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetCommandLineDefaultConnection() As String

            Return GetCommandLineParameter("db")

        End Function

        ''' <summary>
        ''' Überschreibt die einstellung der Standardverbindung
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetAsDefaultConection(ByVal newDefault As Connection)
            m_defaultConnection = newDefault
        End Sub

        ''' <summary>
        ''' Ruft die Liste aller Verbindungen ab. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ConnectionList() As System.Collections.Generic.List(Of Connection)
            Get
                If m_connectionList Is Nothing Then
                    m_connectionList = New System.Collections.Generic.List(Of Connection)
                    ReadConnections()
                End If

                Return m_connectionList
            End Get
        End Property

        ''' <summary>
        ''' Entfernt die angegebene verbindung aus der Auflistung, schreibt die Auflistung in der Registry neu
        ''' </summary>
        ''' <param name="connection"></param>
        ''' <remarks></remarks>
        Sub Remove(ByVal connection As Connection)
            If ConnectionList.Contains(connection) Then
                ConnectionList.Remove(connection)
            End If

            Me.SaveConnections()

        End Sub

        ''' <summary>
        ''' Fügt die angegebene Verbindung der Auflistung hinzu
        ''' </summary>
        ''' <param name="connection"></param>
        ''' <remarks></remarks>
        Sub Add(ByVal connection As Connection)
            If Not ConnectionList.Contains(connection) Then
                ConnectionList.Add(connection)
            End If

            Me.SaveConnections()

        End Sub

        ''' <summary>
        ''' Prüft, ob ie angegebene Verbindung in der Auflistung enthalten ist
        ''' </summary>
        ''' <param name="connection"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function Contains(ByVal connection As Connection) As Boolean
            Return ConnectionList.Contains(connection)

        End Function

        ''' <summary>
        ''' Sucht in dem Roaming.Vz die Datei für die Verbindungen, dort wird ab Version2 Die Daten gespeichert und nicht mehr ind er Registry
        ''' </summary>
        ''' <remarks>die aktuelle Auflistung der Verbindungen wird zurückgesetzt</remarks>
        Public Sub ReadConnections()
            Dim binReader As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
            binReader.AssemblyFormat = Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple

            MainApplication.getInstance.SendMessage(MainApplication.getInstance.Languages.GetText("ReadingConnectionsList", "Lese Liste der Datenbankverbindungen..."))
            Me.ConnectionList.Clear()

            If System.IO.File.Exists(ProfileFilename) Then
                Using ConnectionFile As New System.IO.FileStream(ProfileFilename, System.IO.FileMode.OpenOrCreate, IO.FileAccess.Read)
                    Try
                        Dim tmpconenctions As System.Collections.Generic.List(Of Connection) = TryCast(binReader.Deserialize(ConnectionFile), System.Collections.Generic.List(Of Connection))

                        ' sonst so lassen 
                        If tmpconenctions IsNot Nothing Then

                            For Each item As Connection In tmpconenctions
                                item.IsNew = False
                                Me.ConnectionList.Add(item)
                                If item.IsDefault Then
                                    Me.DefaultConnection = item
                                End If
                            Next
                        End If

                    Catch ex As Exception

                    End Try

                    ConnectionFile.Close()

                End Using



            End If

            ' Wenn nur eine Verbindung existiert, dann ist dies die standard-Verbindung
            If Me.ConnectionList.Count = 1 Then
                Me.DefaultConnection = Me.ConnectionList(0)
            End If

        End Sub

        ''' <summary>
        ''' Speichert die Liste der Verbindungen in der Connection-Datei
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveConnections()
            Dim binReader As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

            Using ConnectionFile As New System.IO.FileStream(ProfileFilename, System.IO.FileMode.OpenOrCreate)
                binReader.Serialize(ConnectionFile, Me.ConnectionList)
                ConnectionFile.Close()
            End Using


        End Sub
        ''' <summary>
        ''' Füllt die Liste der Datenbankverbindungen für HWL1.x, lesend aus den Verbindungen zu HWL1.
        ''' Ist keine Verbindung vorhanden, so liegt entweder eine Erstinstallation vor oder die Verbindungsdaten sind fehlerhaft.
        ''' </summary>
        ''' <remarks></remarks>        
        Sub FillConnectionsList()
            Debug.Print("FillConnectionsList: Baue Liste der Verbindungen auf.")
            If m_connectionList Is Nothing Then
                m_connectionList = New System.Collections.Generic.List(Of Connection)
            End If

            LastErrorMessage = ""


            m_connectionList.Clear()

            Try
                ' Falls der Haupt-Zweig nicht existiert, dann Kann die Liste auch nicht gefüllt werden


                ' Prüfe, ob der Schlüssel existiert
                If My.Computer.Registry.CurrentUser.OpenSubKey(m_serverKeyValue) Is Nothing Then

                    CopyOldPathToServerList()
                    ' Da ein Server-Pfad nicht existierte, dann diesen abspeichern und als Default eintragen
                    'Me.DefaultConnection = ConnectionList(0)
                    'SaveClassicConnections()

                    Exit Sub

                End If

                Dim CurrentValueKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(Me.m_serverKeyValue)

                If CurrentValueKey IsNot Nothing Then
                    ' wenn der Registry-Schlüssel existiert, dann die Verbindungen auslesen.                    
                    Debug.Print("Ein 'Server' - Eintrag existiert; durchsuche Liste aller Server und stelle Standard-Verbindung fest.")
                    Dim ServerKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(Me.m_serverKeyValue)


                    Dim DefaultNumber As Integer = CInt(ServerKey.GetValue(RegistryValues.Server_DefaultNumber))

                    For entryID As Integer = 1 To ServerKey.SubKeyCount
                        Dim connectionEntry As New Connection
                        m_connectionList.Add(connectionEntry)

                        Dim ConnectionEntryRegKey As Microsoft.Win32.RegistryKey = ServerKey.OpenSubKey(entryID.ToString)
                        With connectionEntry
                            .AliasName = CStr(ConnectionEntryRegKey.GetValue(RegistryValues.Server_AliasName, ""))
                            .Database = CStr(ConnectionEntryRegKey.GetValue(RegistryValues.Server_DatabaseName, ""))
                            .Password = CStr(ConnectionEntryRegKey.GetValue(RegistryValues.Server_Password, ""))
                            .Path = CStr(ConnectionEntryRegKey.GetValue(RegistryValues.Server_Path, ""))
                            .BackupPath = CStr(ConnectionEntryRegKey.GetValue(RegistryValues.Server_BackupPath, ""))

                            .ServerHostName = CStr(ConnectionEntryRegKey.GetValue(RegistryValues.Server_Servername, ""))


                            Dim regValue As Object = ConnectionEntryRegKey.GetValue(RegistryValues.Server_Servertype, enumServerType.Access)
                            Dim ServertypeValue As Integer

                            If TypeOf regValue Is String Then
                                Dim regstr As String = CStr(regValue)

                                If Integer.TryParse(regstr, ServertypeValue) Then

                                    ' dann war es ein Nummerischer wert
                                    'TODO: in HWL1 den Datenbanktype setzen, wenn server-Verbindung gespeichert wird
                                    If ServertypeValue = enumServerType.MySQL Or .Database.Length > 0 Then
                                        .Servertype = enumServerType.MySQL
                                    End If
                                    If ServertypeValue = enumServerType.Access And .Database.Length = 0 Then
                                        .Servertype = enumServerType.Access
                                    End If
                                Else
                                    ' dann ein String-wert "MySQL" oder "Access"

                                    .Servertype = CType([Enum].Parse(GetType(enumServerType), regstr), enumServerType)

                                End If
                            End If


                            .Username = CStr(ConnectionEntryRegKey.GetValue(RegistryValues.Server_Username))
                            .IsDefault = False

                            If entryID = DefaultNumber Then
                                Me.DefaultConnection = connectionEntry
                                IsValid = True
                            End If
                        End With

                    Next

                Else
                    IsValid = False
                    LastErrorMessage = "Konnte keine Registry-Daten finden"
                    'Throw New Exception("Kein Registryschlüssel gefunden. Programms scheint nicht korrekt installiert zu sein!")
                End If


            Finally
                'My.Computer.Registry.CurrentUser.Close()
            End Try
            If m_defaultConnection IsNot Nothing Then
                Debug.Print("Standard-Verbindung ist: " & m_defaultConnection.GetConnectionDescription)
            Else
                Debug.Print("Keine Verbindung möglich, da kein Registry-wert gefunden werden konnte")
            End If
        End Sub

        ''' <summary>
        ''' Sucht nach dem alten "Current-User"- Pfad und kopiert diesen in die Liste der Server rein.
        ''' Existiert dieser Pfad nicht, wird dieser angelegt
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CopyOldPathToServerList()
            Dim CurrentValueKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(Me.m_currentValueRegKey)
            Const OldDataPath As String = "DataPath"
            Dim DataPath As String
            Dim setAsDefault As Boolean

            If CurrentValueKey IsNot Nothing Then
                DataPath = CStr(CurrentValueKey.GetValue(OldDataPath, DefaultDatabasePath))
                setAsDefault = True ' Markieren und später als Standardpfad setzen => es wurde ja eine bestehende Verbindung gefunden

            Else

                DataPath = Me.DefaultDatabasePath
                setAsDefault = False ' es  gab kein Pfad, also auch kein Default anlegen
            End If

            ' DataPath = System.IO.Path.Combine(DataPath, "daten.mdb")

            Dim defaultConnection As New Connection()
            With defaultConnection
                .AliasName = MainApplication.getInstance.Languages.GetText("DefaultConnectionName", "Standard")
                .Database = ""
                .Path = DataPath
                .Password = Services.GetDBPassword(.Path)
                .ServerHostName = ""
                .Servertype = enumServerType.Access
                .Username = "admin"

                If .Password = "" Then ' Dann konnte entweder keine HWL.ini gefudnen werden,  beides => schlecht

                    IsValid = False
                Else
                    IsValid = True
                End If

            End With

            If Not Me.ConnectionList.Contains(defaultConnection) Then
                Me.ConnectionList.Add(defaultConnection)
            End If


        End Sub

        ''' <summary>
        ''' Ruft den standard-Pfad zur Datenbank ab (für Erstinstallation notwendig) 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function DefaultDatabasePath() As String
            Return Services.GetDefaultDataPath
        End Function

        ''' <summary>
        ''' Nach einer Verbindung wird die ID aus der Textdatei gelesen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property DefaultInitialID() As String
            Get
                If String.IsNullOrEmpty(m_DefaultHWLID) Then
                    m_DefaultHWLID = ClausSoftware.Tools.Services.GetNewHWLID
                End If
                Return m_DefaultHWLID
            End Get
        End Property

        ''' <summary>
        ''' Erwirkt eine neue HWL-ID; Achtung kann als Datenbank-Passwort verwendet werden!
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearAndRefreshAPPID()
            m_DefaultHWLID = ClausSoftware.Tools.Services.GetNewHWLID
            MainApplication.getInstance.Settings.SettingProgrammID = m_DefaultHWLID
            MainApplication.getInstance.Settings.Save()
        End Sub

        ''' <summary>
        ''' Speichert die Datenbankverbindungen in der Registry ab.
        ''' </summary>
        ''' <remarks></remarks>
        <Obsolete("Nur für HWL-1 Verbindungen gedacht")> _
        Sub SaveClassicConnections()
            ' die HWL-1 defaultverbindung beginnt bei -2

            Dim ServerKey As RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(m_serverKeyValue, True)
            Dim entryID As Integer
            'Erst alle Löschen 
            If ServerKey IsNot Nothing Then

                For Each subKey As String In ServerKey.GetSubKeyNames
                    ServerKey.DeleteSubKey(subKey, False)
                Next
            Else
                ServerKey = My.Computer.Registry.CurrentUser.CreateSubKey(m_serverKeyValue, RegistryKeyPermissionCheck.ReadWriteSubTree)

            End If


            For Each Connection As Connection In Me.ConnectionList
                entryID += 1


                Dim ConnectionEntryRegKey As Microsoft.Win32.RegistryKey = ServerKey.OpenSubKey(entryID.ToString, True)
                If ConnectionEntryRegKey Is Nothing Then  'sofern Schlüssel nicht existiert, dann einen anlegen 
                    ConnectionEntryRegKey = ServerKey.CreateSubKey(entryID.ToString, RegistryKeyPermissionCheck.ReadWriteSubTree)
                End If

                With Connection
                    ConnectionEntryRegKey.SetValue(RegistryValues.Server_AliasName, .AliasName.ToString)
                    ConnectionEntryRegKey.SetValue(RegistryValues.Server_DatabaseName, .Database)
                    ConnectionEntryRegKey.SetValue(RegistryValues.Server_Password, .Password)
                    ConnectionEntryRegKey.SetValue(RegistryValues.Server_Path, .Path)
                    ConnectionEntryRegKey.SetValue(RegistryValues.Server_BackupPath, .BackupPath)

                    ConnectionEntryRegKey.SetValue(RegistryValues.Server_Servername, .ServerHostName)
                    ConnectionEntryRegKey.SetValue(RegistryValues.Server_Servertype, .Servertype)
                    ConnectionEntryRegKey.SetValue(RegistryValues.Server_Username, .Username)
                    If Connection.Equals(Me.m_defaultConnection) Then
                        ServerKey.SetValue(RegistryValues.Server_DefaultNumber, CStr(entryID))
                    End If
                End With

            Next

            ' Höchste Server-Verbindung sichern
            ServerKey.SetValue(RegistryValues.Server_MaxServerCount, CStr(entryID))

            ' den Standard festlegen: 

        End Sub

        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse. Das Connections-Objekt existiert nur einmal 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            Debug.Print("Erstelle neue Instanz von Connections")


            Dim shortAppName As String = MainApplication.ApplicationName

            If shortAppName.StartsWith("HWL") Then shortAppName = "HWL1.7"
            If shortAppName.StartsWith("PB") Then shortAppName = "PB1.7"



            m_serverKeyValue = "Software\VB and VBA Program Settings\" & shortAppName & "\" & RegistrySections.Server
            m_currentValueRegKey = "Software\VB and VBA Program Settings\" & shortAppName & "\" & RegistrySections.CurrentVersion

            Debug.Print("m_serverKeyValue=" & m_serverKeyValue)

        End Sub
    End Class


End Namespace