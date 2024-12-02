Imports System.Data.Common
Imports ClausSoftware.Tools

Namespace DataBase
    ''' <summary>
    ''' Stellt Methoden zur Verbindung mit einer Datenbank bereit und kann Commands ausführen und 
    ''' Daten zurückgeben.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DbEngine
        Implements IDisposable

        Private m_connectionString As String
        Private m_datbasename As String
        Private m_dbconnection As DbConnection

        Private ReadOnly m_timeout As Integer = 3600 ' 60 Minuten Timeout (default ist 30) 
        Private m_connectionData As Tools.Connection

        Private m_mainApplication As MainApplication

        ''' <summary>
        ''' Stellt eine Verbinudung zur Haupt Applikationsklasse her
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property MainApplication As MainApplication
            Get
                Return m_mainApplication
            End Get
            Set(ByVal value As MainApplication)
                m_mainApplication = value
            End Set
        End Property

        ''' <summary>
        ''' Stellt eine neue Datenbankverbindung bereit, die unabhängig vom Server arbeitet
        ''' </summary>
        ''' <param name="myConnection">Die Datenbankverbindung mit der eine Verbindung hergestellt werden soll</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal myConnection As Connection)
            m_connectionData = myConnection
        End Sub

        ''' <summary>
        ''' Testet die aktuelle Datenbankverknüpfung. es wird nur auf Vorhandensein der Datenbank geprüft, nicht auf existenz einr HWL-Instanz
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TestConnection() As DBResult
            ' 1. Ping
            ' 2. DB öffnen
            ' 3.

            Dim result As New DBResult
            result.IsValid = True

            Dim errorMessage As String = ""
            Dim conObj As DbConnection = Nothing
            Try
                m_dbconnection = Nothing
                conObj = Me.GetConnection ' es wird stets versucht, die Verbindung zu öffnen


            Catch ex As MySql.Data.MySqlClient.MySqlException

                result.IsValid = False
                result.ErrorText = ex.Message & Environment.NewLine

                Select Case ex.Number
                    Case 1044
                        result.Solution = "Prüfen Sie den Namen der Datenbank, den Benutzernamen und das Passwort."
                        Return result
                    Case 1045
                        'Access denied for user 'tclaus1'@'192.168.0.115' (using password: YES)
                        result.ErrorText += "Benutzername konnte nicht in der angegebenen Datenbank (" & m_connectionData.Database & ") gefunden werden."
                        result.Solution = "Prüfen Sie, ob dieser Benutzername und das Passwort an der angegebenen datenbank gültig sind."
                        Return result
                    Case Else
                        ' weitere behandlung weiter unten
                End Select
            Catch ex As OleDb.OleDbException
                result.IsValid = False
                Select Case ex.ErrorCode
                    Case -2147217843
                        'TODO: NLS
                        result.ErrorText = "Ungültiges Datenbankpasswort"
                        result.Solution = "Die Datenbank ist mit einem Passwort verschlüsselt. Dieses wird kodiert in der Datei" & vbCrLf
                        result.Solution &= "HWL.ini verwahrt. Diese Datei muss im selben Verzeichnis wie die Datendatei liegen." & vbCrLf
                        result.Solution &= "Entweder fehlt diese Datei oder hat einen Inhalt, der nicht zur Datenbank passt." & vbCrLf & vbCrLf
                        result.Solution &= "In Ihrem Backup-Verzeichnis der Datenbank sollten immer korrekte Paare Daten-Datei und Schlüsseldatei liegen." & vbCrLf
                        result.Solution &= "Kopieren Sie aus der aktuellsten Sicherungskopie dieses Pärchen in den Daten-Ordner. "

                    Case -2147467259
                        ' File Not Found
                        'TODO: NLS
                        result.ErrorText = ex.Message
                        result.Solution = "Die Datenbank wurde am angegebenen Pfad nicht gefunden." & vbCrLf
                        result.Solution &= "Prüfen Sie den Pfad in ihrer Datenbankverbindung." & vbCrLf
                        result.Solution &= "Falls Sie {appname} neu installiert haben, führen sie die Installation erneut aus."

                    Case Else
                        result.ErrorText = ex.Message & Environment.NewLine
                End Select


            Catch ex As Exception
                result.ErrorText = ex.Message & Environment.NewLine

            End Try

            'Dann hat der Test nicht funktioniert
            If Not result.IsValid Then


                If m_connectionData.Servertype = enumServerType.MySQL Then
                    If Not (m_connectionData.ServerHostName.Equals("localhost", StringComparison.InvariantCultureIgnoreCase) Or m_connectionData.ServerHostName.Equals(My.Computer.Name, StringComparison.InvariantCultureIgnoreCase)) Then
                        ' Ist der Server auf diesem Rechner, 
                        Try
                            If String.IsNullOrEmpty(m_connectionData.ServerHostName) Then
                                result.ErrorText += "Es wurde kein Pfad zum Server angegeben"
                                result.Solution += "Geben Sie einen Servernamen oder 'localhost' an"
                                Return result
                            End If
                        Catch ex As Exception
                            result.ErrorText += "Ein Problem wurde mit dem Servernamen festgestellt."
                            result.Solution += "Kontrollieren Sie den Namen des Servers."
                            Return result
                        End Try

                        ' Try Ping the Server
                        Try
                            If Not My.Computer.Network.Ping(m_connectionData.ServerHostName) Then
                                result.ErrorText += "Der Server hat auf ein Ping-Signal nicht geantwortet."
                                result.Solution = "Stellen Sie sicher, das der Server mit dem Namen (" & m_connectionData.ServerHostName & "') existiert." & Environment.NewLine
                                result.Solution += "Prüfen Sie, ob der Server verfügbar ist."
                                Return result
                            End If
                        Catch ex As Exception
                            result.ErrorText += "Der Name des Servers enthält ungültige Zeichen oder ist keine IP-Adresse"
                            result.Solution += "Geben Sie den korrekten Namen des Servers ein." & vbCrLf
                            result.Solution += "Eine IP-Adresse ist eine ziffernfolge im Format 255.255.255.255, wobei die Zahlen zwischen 0 und 255 liegen."
                        End Try

                    End If

                    ' Ping geht, oder es war der Localhost
                    ' entweder war die Datenbank nicht gestarter, falsche DB-Name oder kein Zugriffsrecht

                End If
            Else
                ' Verbindung gültig. Prüfe nun die Datenbankvetrsion!
                ' Kann nicht mit einem älteren Cliengt eine neuere Datenbank benutzen
                Dim sqlVersion As String = "SELECT VersionID FROM " & ClausSoftware.Kernel.DBVersion.Tablename
                Dim versionresult As Object = Me.ExcecuteScalar(sqlVersion)
                ' Ist Nothing, wenn Datenbank noch leer ist
                If TypeOf versionresult Is String Then
                    Dim versionstr As String
                    versionstr = CStr(versionresult)
                    ' nun prüfen
                    'TODO: Versionsnummer angeben, mit der zu prüfen ist

                End If

                If m_connectionData.Servertype = enumServerType.Access Then
                    ' Auf Schreibschutz prüfen; Kann besonders bei Kopieren von CD vorkommen
                    Dim fi As New System.IO.FileInfo(m_connectionData.Path & "\daten.mdb")
                    If (fi.Attributes And System.IO.FileAttributes.ReadOnly) = System.IO.FileAttributes.ReadOnly Then
                        result.IsValid = False

                        'TODO: NLS
                        result.ErrorText &= "Pfad: " & fi.FullName & vbCrLf
                        result.ErrorText &= "Die Datenbankdatei war schreibgeschützt und kann nicht benutzt werden." & vbCrLf
                        result.ErrorText &= "So entfernen Sie den Schreibschutz: "
                        result.Solution = " 1. Öffnen Sie die den Speicherort der Datei." & vbCrLf
                        result.Solution &= " 2. Klicken mit der rechten Maustaste auf die Datei 'daten.mdb'" & vbCrLf
                        result.Solution &= " 3. Wählen Sie dann im Menü 'Eigenschaften' " & vbCrLf
                        result.Solution &= " 4. Im Dialog der sich dann öffnet wählen Sie den Reiter 'Allgemein'" & vbCrLf
                        result.Solution &= " 5. Entfernen Sie den Haken bei 'Schreibschutz'."

                    End If

                End If

            End If

            ' Versuchen zu schliessen, falls offen
            If conObj IsNot Nothing Then
                If conObj.State = ConnectionState.Open Then
                    conObj.Close()
                    conObj.Dispose()
                    conObj = Nothing
                    m_dbconnection.Close()

                End If
            End If

            Return result
        End Function

        Sub Connect(ByVal databasename As String, ByVal connectionstring As String)
            m_connectionString = connectionstring
            m_datbasename = databasename.ToLower
            GetProviderFactory()
        End Sub

        ''' <summary>
        ''' Ruft den aktuellen Typ der Datenbank ab. 
        ''' Liefert Undefined, falls der Typ nicht gesetz oder noch keine Verbindung aufgebaut ist.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DatabaseType As enumServerType
            Get
                If m_connectionData IsNot Nothing Then
                    Return m_connectionData.Servertype
                Else
                    Return enumServerType.Undefined
                End If
            End Get
        End Property

        ''' <summary>
        ''' Ermittelt aus der aktuellen Datenbankverbindung eine Providerfabrik
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Durch Providerfabriken kann man alle Datenbankspezifischen Objekte herleiten lassen</remarks>
        ''' <exception cref="ArgumentException"> Falls keine Fabrik erzeugt werden konnte.</exception>
        Private Function GetProviderFactory() As DbProviderFactory

            Dim dt As DataTable = DbProviderFactories.GetFactoryClasses
            Dim searchForName As String = ""

            Select Case m_connectionData.Servertype

                Case Tools.enumServerType.Access : searchForName = "OleDb Data Provider"
                Case Tools.enumServerType.MySQL : searchForName = ""
                Case Else

                    Throw New Exception("'" & Me.m_datbasename.ToLower & "' : unknown Database provider - exiting application!")
            End Select

            For Each row As DataRow In dt.Rows

                If row("Name").ToString.Equals(searchForName, StringComparison.InvariantCultureIgnoreCase) Then
                    Return DbProviderFactories.GetFactory(row)
                End If
            Next

            Throw New ArgumentException("Could not parse Database Connection for building a Provider Factory. Actual Dataprovider is: " & "SQL-CLIENT")

        End Function

        ''' <summary>
        ''' Schliesst die Datenbankverbindung wieder
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CloseConnection()
            If m_dbconnection IsNot Nothing Then
                If (m_dbconnection.State And 1) = 1 Then
                    m_dbconnection.Close()
                    m_dbconnection = Nothing
                End If

            End If
        End Sub

        ''' <summary>
        ''' Ruft eine geöffnete datenbankverbindung ab
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetConnection() As DbConnection

            If m_dbconnection Is Nothing Then
                Dim constr As String = Tools.Connections.GetSimpleConnectionString(m_connectionData)
                If String.IsNullOrEmpty(constr) Then
                    Return Nothing
                End If

                If m_connectionData.Servertype = Tools.enumServerType.MySQL Then
                    m_dbconnection = New MySql.Data.MySqlClient.MySqlConnection(constr)
                Else
                    Dim factory As DbProviderFactory
                    factory = GetProviderFactory()
                    m_dbconnection = factory.CreateConnection()

                    m_dbconnection.ConnectionString = constr

                End If

            End If

            If m_dbconnection.State = ConnectionState.Closed Then

                m_dbconnection.Open()
            End If


            Return m_dbconnection


        End Function

        ''' <summary>
        ''' Ruft eine System.Datatabel ab, die dien Inhalt der Datenbank enthält und durch den angegebenen SQL-String definiert wurde.
        ''' Auch im Fehlerfall wird immer ein Datatable zurückgegeben
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(ByVal sql As String) As DataTable
            Dim dt As New DataTable()
            Try
                Dim comm As DbCommand = GetConnection.CreateCommand()
                comm.CommandText = sql
                comm.CommandTimeout = m_timeout



                dt.Load(comm.ExecuteReader())

                comm.Connection.Close()
            Catch ex As Exception
                MainApplication.log.WriteLog(ex, "Database", "ERROR while getting a Datatable")
            End Try

            Return dt

        End Function

        Public Function GetSchema() As System.Data.DataTable
            Return GetConnection.GetSchema()
        End Function

        ''' <summary>
        ''' Ruft das Schema der Datenbank ab
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSchema(name As String) As System.Data.DataTable

            Return GetConnection.GetSchema(name)
        End Function

        ''' <summary>
        ''' Führt einen SQL - Befehl aus, und gibt eine Datenstruktur zurück
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExcecuteScalar(ByVal sql As String) As Object
            Try
                SyncLock Me

                    Debug.Print("Exceuting: " & sql)
                    Dim retValue As Object
                    Dim comm As DbCommand = GetConnection.CreateCommand()
                    comm.CommandText = sql
                    comm.CommandTimeout = m_timeout
                    retValue = comm.ExecuteScalar


                    If retValue IsNot Nothing Then
                        Debug.Print("Scalar Results: " & retValue.ToString)
                    Else
                        Debug.Print("Scalar Results an empty value")
                    End If

                    Return retValue

                End SyncLock
            Catch e As Exception
                Debug.Print("FAILURE excecuting Skalar: " & sql & Environment.NewLine & e.Message)
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Ruft einen Datareader ab, mit dem sequenziell grosse Datenmengen gelesen werden können
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataReader(ByVal sql As String) As DbDataReader
            Try
                Dim com As DbCommand = GetConnection.CreateCommand
                com.CommandText = sql
                com.CommandTimeout = m_timeout
                Return com.ExecuteReader()

            Catch e As Exception
                Debug.Print("FAILURE excecuting Datareader: " & sql & Environment.NewLine & e.Message)
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Füht die Abfrage aus und liefert die Anzahl der betroffenen Datensätze zurück
        ''' </summary>
        ''' <param name="sql"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExcecuteNonQuery(ByVal sql As String) As Integer
            Try
                SyncLock Me
                    Dim comm As DbCommand = GetConnection.CreateCommand()
                    comm.CommandTimeout = m_timeout
                    Dim retValue As Integer

                    comm.CommandText = sql
                    ' V2.0.21
                    '123
                    retValue = comm.ExecuteNonQuery
                    Debug.Print("Excecute affected: " & retValue & " records.")
                    Return retValue
                End SyncLock

            Catch ex As Exception
                m_mainApplication.log.WriteLog(ex, "Database", "ERROR excecuting NonQuery")
                Return 0
            End Try
        End Function

        Private disposedValue As Boolean = False        ' So ermitteln Sie überflüssige Aufrufe

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    If m_dbconnection IsNot Nothing Then
                        If m_dbconnection.State <> ConnectionState.Closed Then
                            m_dbconnection.Close()
                        End If
                    End If
                End If

            End If
            Me.disposedValue = True
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function StartBackup() As Boolean
            Return StartBackup("", m_connectionData)
        End Function

        ''' <summary>
        ''' Ruft die aktuelle Datenbankgrösse als Ansichtstext ab
        ''' </summary>
        ''' <param name="myConnection"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDatabaseSize(myConnection As Connection) As String

            If myConnection.Servertype = enumServerType.Access Then
                Dim filename As String = myConnection.Path & "daten.mdb"

                If System.IO.File.Exists(filename) Then
                    Dim f As New System.IO.FileInfo(filename)
                    Return CStr(Math.Round((f.Length / 1024) / 1024, 2))  ' grösse in MB
                Else
                    Return String.Empty
                End If

            Else



                Dim sql As String

                sql = "         SELECT s.schema_name, " &
    " CONCAT(IFNULL(ROUND((SUM(t.data_length)+SUM(t.index_length)) " &
    " /1024/1024,2),0.00),""Mb"") total_size," &
    "" &
    " CONCAT(IFNULL(ROUND(((SUM(t.data_length)+SUM(t.index_length))-SUM(t.data_free))/1024/1024,2),0.00),""Mb"")" &
    "" &
    " data_used," &
    " CONCAT(IFNULL(ROUND(SUM(data_free)/1024/1024,2),0.00),""Mb"") data_free," &
    " IFNULL(ROUND((((SUM(t.data_length)+SUM(t.index_length))-SUM(t.data_free)) " &
    " /((SUM(t.data_length)+SUM(t.index_length)))*100),2),0) pct_used," &
    " COUNT(table_name) total_tables" &
    " FROM INFORMATION_SCHEMA.SCHEMATA s" &
    " LEFT JOIN INFORMATION_SCHEMA.TABLES t ON s.schema_name = t.table_schema" &
    " WHERE s.schema_name = """ & myConnection.Database & """" &
    " GROUP BY s.schema_name" &
    " ORDER BY pct_used DESC"

                Dim totalSize As String = "0 Mb"

                Dim dt As System.Data.DataTable = Me.GetData(sql)
#If DEBUG Then
                'Überschrift ausgeben
                For colnr As Integer = 0 To dt.Columns.Count - 1
                    Debug.Write(dt.Columns(colnr).ColumnName & "   ")
                Next
                Debug.WriteLine("")
                For rownr As Integer = 0 To dt.Rows.Count - 1
                    For colnr As Integer = 0 To dt.Columns.Count - 1

                        If TypeOf dt.Rows(rownr)(colnr) Is System.Byte() Then
                            Debug.Write(System.Text.ASCIIEncoding.ASCII.GetString(CType(dt.Rows(rownr)(colnr), Byte())))
                        Else
                            Debug.Write(dt.Rows(rownr)(colnr).ToString)
                        End If

                        Debug.Write("   ")

                    Next
                    Debug.WriteLine("")
                Next
#End If

                If dt.Rows.Count = 1 Then
                    totalSize = System.Text.ASCIIEncoding.ASCII.GetString(CType(dt.Rows(0)("total_size"), Byte()))
                End If
                Return totalSize
            End If


        End Function


        Private m_dumpWriter As System.IO.StreamWriter
        Private m_targetDumpFile As String

        ''' <summary>
        ''' Ruft den zuletzt verwendeten Backup-Pfad ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastBackupPath As String
            Get
                Return m_targetDumpFile
            End Get
        End Property

        Private m_backupInProgress As Boolean


        ''' <summary>
        ''' Zeigt an, das ein Datenbank-Backup gearde läuft
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property BackupInProgress As Boolean
            Get
                Return m_backupInProgress
            End Get
        End Property

        ''' <summary>
        ''' Erstellt eine Sicherungskopie der Access-Datenank
        ''' </summary>
        ''' <remarks></remarks>
        Function StartBackup(ByVal prefixFolderName As String, targetConnection As Connection) As Boolean

            m_mainApplication.SendMessage("Starte Datenbank - Backup...") 'TODO: NLS
            m_backupInProgress = True

            Try
                If targetConnection.Servertype = enumServerType.Access Then


                    ' Datei rüberkopieren
                    Dim localDate As String = Now.ToString("d")
                    Dim filename As String = "daten.mdb"

                    Dim targetFilename As String

                    If prefixFolderName.Length = 0 Then
                        targetFilename = System.IO.Path.Combine(targetConnection.BackupPath, localDate)
                    Else
                        ' einen weiteren Unter-Ordner anlegen
                        targetFilename = System.IO.Path.Combine(targetConnection.BackupPath, prefixFolderName)
                        targetFilename = System.IO.Path.Combine(targetFilename, localDate)

                    End If


                    If Not System.IO.Directory.Exists(targetFilename) Then
                        System.IO.Directory.CreateDirectory(targetFilename)
                    End If

                    'HWL.ini - Datei nur einmal kopieren 
                    If Not System.IO.File.Exists(targetFilename & "\HWL.ini") Then
                        If System.IO.File.Exists(targetConnection.Path & "\HWL.ini") Then ' Kann sein, das noch keine HWL.INI existiert (da währe dann der Code drinn für die Datenbank-verschlüselung)
                            System.IO.File.Copy(targetConnection.Path & "\HWL.ini", targetFilename & "\hwl.ini")
                        End If
                    End If


                    'Datenbank-Datei zuweisen 
                    targetFilename = System.IO.Path.Combine(targetFilename, filename)

                    If System.IO.File.Exists(targetFilename) Then
                        System.IO.File.Delete(targetFilename)

                    End If

                    ' Für eine Rückgabe pfad weitergeben
                    m_targetDumpFile = targetFilename

                    ' Datenbank nun kopieren
                    System.IO.File.Copy(targetConnection.Path & "\daten.mdb", targetFilename)
                    Debug.Print("Sicherungskopie wurde angelegt")

                    If MainApplication IsNot Nothing Then
                        MainApplication.SendMessage("Sicherungskopie wurde angelegt unter: " & targetFilename)

                    End If

                    Return True

                Else ' Hier Server - Backup

                    Dim dumpPath As String
                    dumpPath = MainApplication.Settings.GetSetting("mySQLDumpPath", "Connections", "mysqldump.exe", MainApplication.CurrentUser.Key)
                    If System.IO.File.Exists(dumpPath) Then

                        Dim parameters As String
                        Dim targetFolder As String = System.IO.Path.GetTempPath
                        parameters = "--skip-extended-insert  -u" & targetConnection.Username & " -p" & targetConnection.Password & " " & targetConnection.Database  '& " >" & targetFolder & " dump.sql"

                        m_targetDumpFile = targetFolder & "dump.sql" ' Ziel festlegen 

                        If System.IO.File.Exists(m_targetDumpFile) Then
                            System.IO.File.Delete(m_targetDumpFile)
                        End If

                        MainApplication.log.WriteLog("Start a database dump to  '" & targetFolder & "'...")
                        Try

                            Dim sInfo As New ProcessStartInfo(dumpPath, parameters)
                            sInfo.UseShellExecute = False
                            sInfo.ErrorDialog = False
                            sInfo.CreateNoWindow = True
                            sInfo.RedirectStandardOutput = True

                            Dim p As New System.Diagnostics.Process()

                            p.StartInfo = sInfo

                            AddHandler p.OutputDataReceived, AddressOf WriteDataDumper


                            Debug.Print("Writing to: " & m_targetDumpFile)

                            p.Start()
                            p.BeginOutputReadLine()



                            p.WaitForExit()
                            MainApplication.SendMessage("Datenbank - Dump gespeichert (" & m_targetDumpFile & ")")

                            m_dumpWriter.Flush()
                            m_dumpWriter.Close()
                            m_dumpWriter = Nothing
                            RemoveHandler p.OutputDataReceived, AddressOf WriteDataDumper

                        Catch ex As Exception
                            MainApplication.log.WriteLog(ex, "DatabaseDump", "Error while dumping Database-Server")
                        End Try
                    Else
                        Throw New System.IO.FileNotFoundException("MySQlDump.exe not found!")
                    End If
                End If


            Catch ex As Exception
                Debug.Print("ERROR while creating Database Backup: " & ex.Message)
                If MainApplication IsNot Nothing Then
                    MainApplication.SendMessage("Ein Fehler ist beim Anlegen der Sicherungskopie aufgetreten: " & ex.Message)
                    MainApplication.log.WriteLog(ex, "Database", "Error while creating backup.", "Ein Fehler ist beim Anlegen der Sicherungskopie aufgetreten")
                End If

                Return False

            Finally
                m_backupInProgress = False
            End Try

            Return True

        End Function



        Private Sub WriteDataDumper(sender As Object, e As System.Diagnostics.DataReceivedEventArgs)
            If m_dumpWriter Is Nothing Then
                m_dumpWriter = New System.IO.StreamWriter(m_targetDumpFile, True)
                m_dumpWriter.AutoFlush = True
            End If

            m_dumpWriter.WriteLine(e.Data)

        End Sub

        ''' <summary>
        ''' Löscht die angegebene Tabelle
        ''' </summary>
        ''' <param name="tableName">Der Name der zu löschenden Tabelle</param>
        ''' <remarks></remarks>
        Function DropTable(ByVal tableName As String) As Boolean
            Try
                Dim result As Integer
                result = ExcecuteNonQuery("Drop Table " & tableName)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Dim m_attributeSize As New Dictionary(Of String, Long)

        ''' <summary>
        ''' Ruft die Characterlänge ab von der gesuchten Spalte. Ist die spalte kein Text-Typ oder kann der Name nicht gefunden wreden, so wird, "-1" zurückgegeben
        ''' </summary>
        ''' <param name="tablename"></param>
        ''' <param name="columnname"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetColumnCharacterLength(tablename As String, columnname As String) As Long
            Dim colKey As String = tablename & "_" & columnname
            colKey = colKey.ToUpper

            If m_attributeSize.ContainsKey(colKey) Then
                Return m_attributeSize(colKey)
            End If

            Return -1I ' nicht definiert

        End Function

        ''' <summary>
        ''' Ermittelt die Datenbankstruktur
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub GenerateDatabaseSchema()

            Dim data As System.Data.DataTable = Me.GetSchema("Columns")

            m_mainApplication.log.WriteLog("Hole Datenbankschema und Spaltenlängen von Textspalten...")
            m_attributeSize.Clear()

            For Each row As System.Data.DataRow In data.Rows

                Dim colKey As String = row("TABLE_NAME").ToString & "_" & row("COLUMN_NAME").ToString
                colKey = colKey.ToUpper
                Dim size As Object = row("CHARACTER_MAXIMUM_LENGTH")

                ' Dann muss eine Zahl drauf stehen. (geht nicht anders) 
                If Not TypeOf size Is DBNull Then
                    If CLng(size) = 0 Then
                        size = 65536L  ' Dann war es wohl ein längeres MEMO - Feld
                        'TODO: Für andere sehr langen Felder prüfen!
                    End If

                    m_attributeSize.Add(colKey, CLng(size))
                End If

            Next

            m_mainApplication.log.WriteLog("  " & m_attributeSize.Count & " Textspalten gefunden.")

        End Sub


#Region " IDisposable Support "
        ' Dieser Code wird von Visual Basic hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Ändern Sie diesen Code nicht. Fügen Sie oben in Dispose(ByVal disposing As Boolean) Bereinigungscode ein.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region




    End Class


End Namespace