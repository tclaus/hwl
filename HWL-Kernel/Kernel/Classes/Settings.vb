Imports DevExpress.Xpo.DB
Imports ClausSoftware.Data
Imports ClausSoftware.Tools
Imports DevExpress.Data.Filtering
Imports System.Xml.Serialization
Imports System.IO


Namespace Kernel
    Public Class Settings
        Inherits BaseCollection(Of Setting)
        Implements IDataCollection

        ''' <summary>
        ''' enthält zwischengespeicherte Einstellungsdaten
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared m_settingsCache As New Dictionary(Of String, String)

        Private m_itemsSettings As NamedSettings.ItemsSettings

        Private m_transactionSettings As NamedSettings.TransactionSettings

        Private m_articleListsettings As NamedSettings.ArticleListSettings

        Public Shared Event NamesSettingChanged(ByVal sender As Object, ByVal e As SettingChangedEventArgs)


        ''' <summary>
        ''' Ruft den Stammschlüsel der Registry der Applikation ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function BaseRegistryKey() As String
            Return "Software\VB and VBA Program Settings\" & MainApplication.ApplicationName
        End Function

        ''' <summary>
        ''' Sendet ein Ereignis, das das änderun einer benannten Eigenschaft kommuniziert
        ''' </summary>
        ''' <param name="settingName"></param>
        ''' <param name="oldValue"></param>
        ''' <param name="newValue"></param>
        ''' <remarks></remarks>
        Public Shared Sub FireNamesSettingChanged(ByVal settingName As String, ByVal oldValue As Object, ByVal newValue As Object)
            Try
                Dim args As New SettingChangedEventArgs
                args.SettingName = settingName
                args.OldValue = oldValue
                args.NewValue = newValue
                RaiseEvent NamesSettingChanged(Nothing, args)

            Catch ex As Exception
                Debug.Print("ERROR: Senden der Nachricht fehlgeschlagen")
            End Try

        End Sub

        ''' <summary>
        ''' Ruft einen Satz an spezifischen Einstellungen für die Artikelliste ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Articlesettings() As NamedSettings.ArticleListSettings
            Get
                If m_articleListsettings Is Nothing Then
                    m_articleListsettings = New NamedSettings.ArticleListSettings(MainApplication)
                End If
                Return m_articleListsettings
            End Get
        End Property

        ''' <summary>
        ''' Holt den Wert einer Einstellung. Liefert ein leeres Ergebnis, wenn keine Einstellung gefunden werden konnte.
        ''' </summary>
        ''' <param name="name">Gibt den Namen der Einstellung an</param>
        ''' <param name="area">Gibt den Gültigkeitsbereich der Einstellung an</param>
        ''' <param name="username">Gibt den Benutzernamen für diese Einstellung an</param>
        ''' <param name="defaultValue">Standardwert, sofern keine gespeicherte Einstellung gefunden werden konnte.</param>
        ''' <returns></returns>
        ''' <remarks>Liefert genau den ersten gefundenen Wert</remarks>
        Function GetSetting(ByVal name As String, ByVal area As String, ByVal defaultValue As String, ByVal username As String, ByVal forceReload As Boolean) As String

            ' im Cache nachsehen

            If username.Length = 0 Then
                username = "SYSTEM"
            End If

            Dim settingsKey As String = name & "_" & area & "_" & username ' Der letzte Teil ist immer der Benutzername, "SYSTEM" bei allgemeinen Einstellungen

            If forceReload Then
                ' Einstellungen vom Server verwerfen und neu einlesen
                Debug.Print("Neu einlesen der Einstellung erzwungen, lade neu aus Datenspeicher")
                If m_settingsCache.ContainsKey(settingsKey) Then
                    m_settingsCache.Remove(settingsKey)
                End If
            End If

            If m_settingsCache.ContainsKey(settingsKey) Then
                LogsettingValue(settingsKey, m_settingsCache(settingsKey))

                Return m_settingsCache(settingsKey)
            End If


            Debug.Print("GetSetting: Hole Einstellung vom Server:" & name & ", Bereich:" & area & ", User:" & username)

            Dim CriteriaUserString As String = "Name='" & name & "' AND Area='" & area & "' "

            ' SYSTEM- Benuzuer kann auch ein bisheriger ferier Username sein
            If Not username.Equals("SYSTEM") Then
                CriteriaUserString = CriteriaUserString & " AND UserName ='" & username & "'"
            Else
                CriteriaUserString = CriteriaUserString & " AND (UserName ='SYSTEM' or UserName is null or UserName='') " ' Dann auch nach leeren Einstellungen suchen 
                ' Dann den internen Speicher neu aufbauen
            End If

            Dim criteria As CriteriaOperator = CriteriaOperator.Parse(CriteriaUserString)

            ' Dim currentSetting As Settings = New Settings(MainApplication, criteria)
            Me.Filter = criteria

            Dim value As String

            If Me.Count > 0 Then
                LogsettingValue(settingsKey, Me(0).Value)

                value = Me(0).Value

                'Reparatur, wenn Username leer war, Achtung: Das verletzt die Zusammenarbeit mit HWL 1.7, besser so lassen und einen neuen Eintrag anlegen ? 
                'If String.IsNullOrEmpty(currentSetting(0).UserName) Then
                '    currentSetting(0).UserName = "SYSTEM"
                '    currentSetting(0).Save()
                'End If

            Else
                SetSetting(name, area, defaultValue, username)
                value = defaultValue
            End If


            If Not m_settingsCache.ContainsKey(settingsKey) Then
                m_settingsCache.Add(settingsKey, value)
            End If

            Return value

        End Function

        ''' <summary>
        ''' Schreibt einen verkürzten Logeintrag in die Debugausgabe
        ''' </summary>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        <Conditional("DEBUG")> _
        Private Sub LogsettingValue(ByVal name As String, ByVal value As String)
            Try
                If value.Length > 25 Then
                    Debug.Print(" Einstellung geholt: " & name & ", Wert: " & value.Substring(0, 25) & "...")
                Else
                    Debug.Print(" Einstellung geholt: " & name & ", Wert: " & value)

                End If
            Catch ex As Exception
                Debug.Print("LogsettingValue: " & ex.Message)
            End Try

        End Sub

        ''' <summary>
        ''' Wenn eine Eigensschfat mit diesen Parametern existiert, wird diese aus der Eigenschaftenliste entfernt
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="area"></param>
        ''' <remarks></remarks>
        Public Sub DeleteSetting(ByVal name As String, ByVal area As String)
            DeleteSetting(name, area, "")
        End Sub



        ''' <summary>
        ''' Speichert Position und Grösse des angegebenn Formulares
        ''' </summary>
        ''' <param name="frm">Das Formular dessen Einstellungen gespeichert werden sollen</param>
        ''' <remarks></remarks>
        Public Sub SaveFormsPos(ByVal frm As System.Windows.Forms.Form)

            SaveFormsPos(frm, frm.Name)
        End Sub

        ''' <summary>
        ''' Speichert die Grösse und Position des angegebenen Formulares in dem angegebenen Kontext
        ''' </summary>
        ''' <param name="frm"></param>
        ''' <param name="context"></param>
        ''' <remarks></remarks>
        Public Sub SaveFormsPos(ByVal frm As System.Windows.Forms.Form, ByVal context As String)

            Dim name As String = MainApplication.CurrentUser.Key

            Me.SetSetting("Formsize", context, frm.Size.ToString, name)
            Me.SetSetting("Formpos", context, frm.Location.ToString, name)
        End Sub

        ''' <summary>
        ''' Stellt Position und Grösse eines Formulares wieder her
        ''' </summary>
        Public Sub RestoreFormsPos(ByVal frm As System.Windows.Forms.Form)
            RestoreFormsPos(frm, frm.Name)

        End Sub



        ''' <summary>
        ''' Stellt Position und Grösse eines Formulares wieder her. Formulare sind immer Rechner/Benutzerabhängig, eine Prüfung auf angemeldete Benutzer findet nicht statt
        ''' </summary>
        ''' <param name="frm"></param>
        ''' <remarks></remarks>
        Public Sub RestoreFormsPos(ByVal frm As System.Windows.Forms.Form, ByVal context As String)

            MainApplication.Log.WriteLog("Stelle Position und Grösse des Formulars wieder her: " & frm.Name)

            Dim name As String = MainApplication.CurrentUser.Key

            Dim formSize As String = Me.GetSetting("Formsize", context, "", name, True)
            Dim formlocation As String = Me.GetSetting("Formpos", context, "", name, True)

            If formSize.Length > 0 Or formlocation.Length > 0 Then
                ' auseinanderpflücken

                formSize = formSize.Replace("{Width=", "")
                formSize = formSize.Replace("Height=", "")
                formSize = formSize.Replace("}", "")

                Dim width As Integer = CInt(formSize.Substring(0, formSize.IndexOf(",")))
                Dim height As Integer = CInt(formSize.Substring(formSize.IndexOf(",") + 1))


                formlocation = formlocation.Replace("{X=", "")
                formlocation = formlocation.Replace("Y=", "")
                formlocation = formlocation.Replace("}", "")

                Dim x As Integer = CInt(formlocation.Substring(0, formlocation.IndexOf(",")))
                Dim y As Integer = CInt(formlocation.Substring(formlocation.IndexOf(",") + 1))

                If x < 0 Then x = 0
                If y < 0 Then y = 0

                frm.Size = New System.Drawing.Size(width, height)
                frm.Location = New System.Drawing.Point(x, y)



            End If

        End Sub


        ''' <summary>
        ''' Wenn eine eigensschfat mit diesen Parametern existiert, wird diese aus der Eigenschaftenliste entfernt
        ''' </summary>
        Public Sub DeleteSetting(ByVal name As String, ByVal area As String, ByVal username As String)

            Dim crName As CriteriaOperator = New BinaryOperator("Name", name, BinaryOperatorType.Equal)
            Dim crArea As CriteriaOperator = New BinaryOperator("Area", area, BinaryOperatorType.Equal)
            Dim crUsername As CriteriaOperator = New BinaryOperator("UserName", username, BinaryOperatorType.Equal)
            Dim criteria As CriteriaOperator = CriteriaOperator.And(crName, crArea, crUsername)


            Dim currentSetting As Settings = New Settings(MainApplication, criteria)
            If currentSetting.Count > 0 Then

                ' Den Cache löschen
                If m_settingsCache.ContainsKey(name & "_" & area & "_" & username) Then
                    m_settingsCache.Remove(name & "_" & area & "_" & username)
                End If

                currentSetting(0).Delete()
            End If

        End Sub
        ''' <summary>
        ''' Läd den Datenstamm neu ein
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Reload()
            m_settingsCache.Clear()
            MyBase.Reload()
            Initialize()

        End Sub

        ''' <summary>
        ''' Ruft einen Einstellungssatz für Artikeleinstellungen ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ItemsSettings() As NamedSettings.ItemsSettings
            Get
                If m_itemsSettings Is Nothing Then
                    m_itemsSettings = New NamedSettings.ItemsSettings(MainApplication)
                End If
                Return m_itemsSettings
            End Get

        End Property

        ''' <summary>
        ''' Ruft einen Einstellungssatz für Transaktionen (Forderungen / Verbindlichkeiten) ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TransactionSettings() As NamedSettings.TransactionSettings
            Get
                If m_transactionSettings Is Nothing Then
                    m_transactionSettings = New NamedSettings.TransactionSettings(MainApplication)
                End If
                Return m_transactionSettings
            End Get

        End Property

        ''' <summary>
        ''' Holt den Wert einer Einstellung für den aktuell angemeldeten Benutzer ab
        ''' </summary>
        ''' <param name="name">eindeutiger Name der Einstellung</param>
        ''' <param name="area">Bereich der Einstellung</param>
        ''' <returns>Der Wert, der dem angemeldeten Benutzer zugeordnet war. Ein leerer String, wenn der wert nicht gesetzt war</returns>
        ''' <remarks></remarks>
        Function GetSetting(ByVal name As String, ByVal area As String) As String

            Return GetSetting(name, area, String.Empty, MainApplication.CurrentUser.Key, False)

        End Function

        ''' <summary>
        ''' Holt den Wert einer Einstellung
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="area"></param>
        ''' <param name="forcereload">Erzwingt ein neuladen aus dem Datenspeicher</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetSetting(ByVal name As String, ByVal area As String, ByVal forcereload As Boolean) As String

            Return GetSetting(name, area, String.Empty, MainApplication.CurrentUser.Key, forcereload)

        End Function

        ''' <summary>
        ''' Holt den Wert einer Einstellung. Liefert ein leeres Ergebnis, wenn keine Einstellung gefunden werden konnte.
        ''' Der wert ist benuzterabhängig
        ''' </summary>
        ''' <param name="name">Der Name der Eigenschaft</param>
        ''' <param name="area">Der Bereich in dem diese eigenschaft vorkommt, beine zusammen müsen eindeutig sein</param>
        ''' <returns></returns>
        ''' <remarks>Liefert genau den ersten gefundenen Wert</remarks>
        Function GetSetting(ByVal name As String, ByVal area As String, ByVal defaultValue As String) As String

            Return GetSetting(name, area, defaultValue, MainApplication.CurrentUser.Key, False)

        End Function

        ''' <summary>
        ''' Holt den Wert einer Einstellung
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="area"></param>
        ''' <param name="defaultValue"></param>
        ''' <param name="forcereload"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetSetting(ByVal name As String, ByVal area As String, ByVal defaultValue As String, ByVal forcereload As Boolean) As String

            Return GetSetting(name, area, defaultValue, MainApplication.CurrentUser.Key, forcereload)

        End Function

        ''' <summary>
        ''' Ruft einen Wert aus den Einstellungen ab, 
        ''' </summary>
        ''' <param name="name">Eindeutiger Name der Einstellung</param>
        ''' <param name="area">Bereich der Einstellung</param>
        ''' <param name="defaultValue">war der Wert nicht gesetzt, dann wird dieser Standardwert zurükgegeben.</param>
        ''' <param name="username"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetSetting(ByVal name As String, ByVal area As String, ByVal defaultValue As String, ByVal username As String) As String

            Return GetSetting(name, area, defaultValue, username, False)

        End Function

        ''' <summary>
        ''' Ruft einen wert ab vom Typ Integer
        ''' </summary>
        ''' <param name="name"></param>
        ''' <param name="area"></param>
        ''' <param name="defaultValue"></param>
        ''' <param name="username"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetIntegerSetting(ByVal name As String, ByVal area As String, ByVal defaultValue As Integer, ByVal username As String) As Integer
            Dim Value As String
            Value = GetSetting(name, area, CStr(defaultValue), username, False)

            Dim intValue As Integer
            If Integer.TryParse(Value, intValue) Then
                Return intValue
            Else
                Return defaultValue
            End If

        End Function


        ''' <summary>
        ''' Seraialisiert ein Objekt in ein String
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function xml_Serialize(ByVal obj As Object) As String
            Dim serializer As New XmlSerializer(obj.GetType)
            Dim s As String

            ' --- Serialisieren in MemoryStream
            Dim ms As New System.IO.MemoryStream()
            serializer.Serialize(ms, obj)


            ' --- Stream in String umwandeln
            Dim r As System.IO.StreamReader = New StreamReader(ms)
            r.BaseStream.Seek(0, SeekOrigin.Begin)
            s = r.ReadToEnd

            Return s
        End Function

        ''' <summary>
        ''' Deserailisiert ein Objekt wieder. Der Type muss angegeben werden
        ''' </summary>
        ''' <param name="inString">Der XML-Strom</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function xml_deserialize(Of serType)(ByVal inString As String) As serType

            Dim obj As Object
            ' --- Objekt in Stream kopieren
            Dim stream As New MemoryStream()
            Using w As New StreamWriter(stream)
                w.BaseStream.Seek(0, SeekOrigin.End)
                w.WriteLine(inString)
                w.Close()
            End Using

            ' Stream umkopieren, weil jetzt geschlossen
            stream = New MemoryStream(stream.ToArray)
            Dim serializer As New XmlSerializer(GetType(serType))
            obj = serializer.Deserialize(stream)

            stream.Close()
            stream = Nothing

            Return CType(obj, serType)
        End Function

        ''' <summary>
        ''' Speichert eine Einstellung aus einem Datenstrom in eine Benutzerdefinietrte Einstellung ab. es wird der aktuell angemeldete Benutzer verwendet
        ''' </summary>
        ''' <param name="name">Name der Einstellung</param>
        ''' <param name="area">Bereich der Einstellung</param>
        ''' <param name="value">Stream des Wertes</param>
        ''' <remarks></remarks>
        Public Sub SetSetting(ByVal name As String, ByVal area As String, ByVal value As System.IO.MemoryStream)
            SetSetting(name, area, value, MainApplication.CurrentUser.Key)
        End Sub

        Public Sub SetSetting(ByVal name As String, ByVal area As String, ByVal value As System.IO.MemoryStream, ByVal username As String)
            Dim valuestring As String = System.Text.UTF8Encoding.UTF8.GetString(value.GetBuffer()).Trim(New Char() {Chr(63)})
            SetSetting(name, area, valuestring, username)
        End Sub

        ''' <summary>
        ''' Setzt eine Einstellung oder Überschreibt eine bestehende. Schreibt diese in die Datenbank.
        ''' </summary>
        ''' <param name="Name">Der Name der Einstellung, z.B.: 'GridSize'</param>
        ''' <param name="Area">Der Bereich für den dies gültig ist, z.B.:'Journal'</param>
        ''' <param name="Value">Der Wert als String-Parameter, z.B. '200;10'</param>
        ''' <remarks></remarks>
        Public Sub SetSetting(ByVal name As String, ByVal area As String, ByVal value As String)
            Try
                SetSetting(name, area, value, MainApplication.CurrentUser.Key)

            Catch ex As Exception
                MainApplication.Log.WriteLog("ERROR while writing setting!", "SetSetting")
            End Try

        End Sub




        ''' <summary>
        ''' Setzt einen Einstellung unter Angabe eines Benutzernamens
        ''' </summary>
        ''' <param name="name">Der Name der Einstellung. Im angegebenen Bereich ist die Kombi Name/Area immer eindeutig</param>
        ''' <param name="area">Berecih in dem die einstellung gültig ist. ein bereich kann mehrere gleichnamige Werte enthalten</param>
        ''' <param name="username">Ist der Benuzername leer, so wird die Einstellung für alle Benutzer angenommen, ein SYSTEM-Eintrag wird erstellt</param>
        ''' <param name="value">Der string-Wert der Einstellung</param>
        ''' <remarks></remarks>
        ''' <exception cref="ArgumentException">Der Parameter 'Name' darf niemals leer sein</exception>
        Public Sub SetSetting(ByVal name As String, ByVal area As String, ByVal value As String, ByVal username As String)
            If String.IsNullOrEmpty(name) Then
                Throw New ArgumentException("Parameter 'Name' muss angegeben werden") 'TODO: NLS
                Exit Sub
            End If


            Debug.Assert(Not String.IsNullOrEmpty(area), "Das Area sollte immer gesetzt sein")

            Dim CriteriaUserString As String = "Name='" & name & "' AND Area='" & area & "' "

            If String.IsNullOrEmpty(username.Trim) Then
                username = "SYSTEM" '- Systemeinstellung vergeben
                ' Damit Sind diese Werte als Username möglich: 
                '"SYSTEM" - Alle Benutzer, global
                ' [Rechnername]/[benutername] - Keine Benuzerverwaltung
                ' ReplikID... Vielleicht doch besser Integer? 

            End If


            CriteriaUserString = CriteriaUserString & " AND UserName='" & username & "'"

            Dim criteria As CriteriaOperator = CriteriaOperator.Parse(CriteriaUserString)

            Dim cacheKey As String = name & "_" & area & "_" & username

            '  Dim currentSetting As Settings = New Settings(MainApplication, criteria)
            Me.Filter = criteria

            If Me.Count > 0 Then

                If Me(0).Value <> value Then

                    Me(0).Value = value
                    Me(0).Save()
                Else
                    ' Wert war identisch; nicht nochmal sichern
                    Debug.Print("Wert der Einstellung war identisch, wird nicht neu gespeichert")

                End If

            Else ' keine einstellung gefunden


                Dim NewSetting As New Setting(MainApplication.Session)
                NewSetting.Name = name
                NewSetting.Area = area
                NewSetting.UserName = username
                NewSetting.Value = value
                NewSetting.Save()
                Me.Add(NewSetting)

            End If
            ' Me.Reload()

            ' für den Cache sichern
            If Not m_settingsCache.ContainsKey(cacheKey) Then
                m_settingsCache.Add(cacheKey, value)
            Else
                m_settingsCache(cacheKey) = value
            End If


        End Sub

        ''' <summary>
        ''' Ruft einen wert aus der Registry ab
        ''' </summary>
        ''' <param name="area">Allgemeiner Bereich der Einstellung</param>
        ''' <param name="name">Eindeutiger Name innerhalb des Bereiches </param>
        ''' <param name="defaultValue">Existiert diese Eigenschaft nicht, so wird dieser Wert übergeben</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetLocalsetting(ByVal area As String, ByVal name As String, ByVal defaultValue As String) As String
            ' Prüfe, ob der Schlüssel existiert
            If My.Computer.Registry.CurrentUser.OpenSubKey(BaseRegistryKey) Is Nothing Then
                My.Computer.Registry.CurrentUser.CreateSubKey(BaseRegistryKey, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)

            End If

            Dim CurrentBaseKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(BaseRegistryKey, True)
            Dim Key As Microsoft.Win32.RegistryKey = CurrentBaseKey.OpenSubKey(area, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            If Key Is Nothing Then
                Key = CurrentBaseKey.CreateSubKey(area, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Key.SetValue(name, defaultValue, Microsoft.Win32.RegistryValueKind.String)
            End If

            Return CStr(Key.GetValue(name, defaultValue))
        End Function

        ''' <summary>
        ''' Setzt einen Wert in der lokalen Registry
        ''' </summary>
        ''' <param name="area">Allgemeiner Bereich der Einstellung</param>
        ''' <param name="name">Eindeutiger Name innerhalb des Bereiches </param>
        ''' <param name="value">Wert der Eigenschaft</param>
        ''' <remarks></remarks>
        Public Shared Sub SetLocalSetting(ByVal area As String, ByVal name As String, ByVal value As String)
            ' Prüfe, ob der Schlüssel existiert
            If My.Computer.Registry.CurrentUser.OpenSubKey(BaseRegistryKey) Is Nothing Then
                My.Computer.Registry.CurrentUser.CreateSubKey(BaseRegistryKey, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)

            End If

            Dim CurrentBaseKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey(BaseRegistryKey, True)

            Dim Key As Microsoft.Win32.RegistryKey = CurrentBaseKey.OpenSubKey(area, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            If Key Is Nothing Then
                Key = CurrentBaseKey.CreateSubKey(area, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
                Key.SetValue(name, value, Microsoft.Win32.RegistryValueKind.String)
            End If

            Key.SetValue(name, value)


        End Sub

        'TODO: settings lokal in der Registry sichern und wieder abholen 
        ' Das ganze dann in HWl1 abholen lassen 


#Region " Named Settings"
        ''' <summary>
        ''' Ruft den konstanten Namen der Datenbankdatei ab. Dies ist der Standard bei Neuinstallationen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SettingDatabaseFilename() As String
            Get
                Return "daten.mdb"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den konstanten Namen für die INI-datei der Datenbank ab.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SettingINIFilename() As String
            Get
                Return "HWL.ini"
            End Get
        End Property

        ''' <summary>
        ''' Enthält einen wert für die Basisnume von Dokumenten
        ''' </summary>
        ''' <remarks></remarks>
        Private m_documentBaseID? As Integer

        ''' <summary>
        ''' Enthält das Basisformat für Dokumentennummern
        ''' </summary>
        ''' <remarks></remarks>
        Private m_docIDFormat As String


        ''' <summary>
        ''' Enthält einen wert für die Basisnume von Dokumenten
        ''' </summary>
        ''' <remarks></remarks>
        Private m_offersBaseID? As Integer

        ''' <summary>
        ''' Enthält das Basisformat für Dokumentennummern
        ''' </summary>
        ''' <remarks></remarks>
        Private m_offersIDFormat As String

        ''' <summary>
        ''' Ruft die startnummer  für Angebote ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SettingOffersID_Base() As Integer
            Get
                Try
                    If Not m_offersBaseID.HasValue Then
                        m_offersBaseID = CInt(Me.GetSetting(RegistryValues.OffersID_Base, RegistrySections.CurrentVersion, "0"))
                    End If
                Catch
                    m_offersBaseID = 0
                End Try

                Return m_offersBaseID.Value

            End Get
            Set(ByVal value As Integer)
                Me.SetSetting(RegistryValues.OffersID_Base, RegistrySections.CurrentVersion, CStr(value))
                m_offersBaseID = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die erste Nummer für allgemeine Journaldokumente ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SettingInvoicesID_Base() As Integer
            Get
                Try
                    If Not m_documentBaseID.HasValue Then
                        m_documentBaseID = CInt(Me.GetSetting(RegistryValues.DocumentID_Base, RegistrySections.CurrentVersion, "0"))
                    End If
                Catch
                    m_documentBaseID = 0
                End Try

                Return m_documentBaseID.Value

            End Get
            Set(ByVal value As Integer)
                Me.SetSetting(RegistryValues.DocumentID_Base, RegistrySections.CurrentVersion, CStr(value))
                m_documentBaseID = value
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Formatierungsstring für Angebotsnummerierung ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SettingOffersID_Format() As String
            Get
                If String.IsNullOrEmpty(m_offersIDFormat) Then
                    m_offersIDFormat = Me.GetSetting(RegistryValues.OffersID_Format, RegistrySections.CurrentVersion, SettingInvoicesID_Format.ToString)
                End If
                Return m_offersIDFormat

            End Get
            Set(ByVal value As String)
                If value.ToUpper.Contains("$NR") Then
                    Me.SetSetting(RegistryValues.OffersID_Format, RegistrySections.CurrentVersion, value)
                    m_offersIDFormat = value
                Else
                    Throw New ArgumentException("Formatstring must contain a '$NR' for the current number!")
                End If
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Formatierungsstring für DokumentenNummern ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SettingInvoicesID_Format() As String
            Get
                If String.IsNullOrEmpty(m_docIDFormat) Then
                    m_docIDFormat = Me.GetSetting(RegistryValues.DocID_Format, RegistrySections.CurrentVersion, "$NR")
                End If
                Return m_docIDFormat

            End Get
            Set(ByVal value As String)
                If value.ToUpper.Contains("$NR") Then
                    Me.SetSetting(RegistryValues.DocID_Format, RegistrySections.CurrentVersion, value)
                    m_docIDFormat = value
                Else
                    Throw New ArgumentException("Formatstring must contain a '$NR' for the current number!")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Enthält die ProgrammID
        ''' </summary>
        ''' <remarks></remarks>
        Private m_programID As String

        ''' <summary>
        ''' Ruft die eindeutige ProgrammID dieser Installation ab oder setzt diese
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SettingProgrammID() As String
            Get
                If String.IsNullOrEmpty(m_programID) Then
                    m_programID = Me.GetSetting("ProgrammID", RegistrySections.CurrentVersion, "", "SYSTEM")
                End If
                Return m_programID
            End Get
            Set(ByVal value As String)
                m_programID = value

                Me.SetSetting("ProgrammID", RegistrySections.CurrentVersion, value, "SYSTEM")

            End Set
        End Property


        ''' <summary>
        ''' Ruft den Überwachungsstatus der Telefonieleitung ab, sofern vorhanden oder legt dies fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MonitorPhoneLines As Boolean
            Get
                Return CBool(Me.GetSetting("MonitorPhoneLines", "Phone", "False"))
            End Get
            Set(ByVal value As Boolean)
                Dim oldValue As Boolean = MonitorPhoneLines

                If value Then
                    Me.SetSetting("MonitorPhoneLines", "Phone", "True")
                Else
                    Me.SetSetting("MonitorPhoneLines", "Phone", "False")
                End If

                FireNamesSettingChanged("MonitorPhoneLines", oldValue, value)

            End Set
        End Property

        ''' <summary>
        ''' Ruft die höchste Datensatznummer ab, die bereits angezeigt wurde. Ist die Höchste aktuelle Nummer höher, liegen ungesehene einträge vor
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MonitorPhoneLinesLastNumber As Integer
            Get
                Return CInt(Me.GetSetting("MonitorPhoneLinesLastNumber", "Phone", "1"))
            End Get
            Set(ByVal value As Integer)
                Dim oldValue As Integer = MonitorPhoneLinesLastNumber
                Me.SetSetting("MonitorPhoneLinesLastNumber", "Phone", CStr(value))

                FireNamesSettingChanged("MonitorPhoneLinesLastNumber", oldValue, value)

            End Set
        End Property

        ''' <summary>
        ''' Läd den aktuellen Überwachungszustand der Telefonieleitung aus der Datenbank neu ein
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MonitorPhoneLinesReload()
            Me.GetSetting("MonitorPhoneLines", "Phone", "True", True)
        End Sub

        ''' <summary>
        ''' Ruft den Formatierungsstring für Dokuemntennummern ab.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SettingAdressID_Base() As Integer
            Get
                Return CInt(Me.GetSetting(RegistryValues.AdressID_Base, RegistrySections.CurrentVersion, "0"))
            End Get
            Set(ByVal value As Integer)

                Me.SetSetting(RegistryValues.AdressID_Base, RegistrySections.CurrentVersion, value.ToString)

            End Set
        End Property

        ''' <summary>
        ''' Ruft den Formatierungsstring für Adressnummern ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>

        Public Property SettingAdressID_Format() As String
            Get
                Return Me.GetSetting(RegistryValues.AdressID_Format, RegistrySections.CurrentVersion, "$NR")
            End Get
            Set(ByVal value As String)
                If value.ToUpper.Contains("$NR") Then
                    Me.SetSetting(RegistryValues.AdressID_Format, RegistrySections.CurrentVersion, value)
                Else
                    Me.SetSetting(RegistryValues.AdressID_Format, RegistrySections.CurrentVersion, "$NR")
                    Throw New ArgumentException("Formatstring must contain a '$NR' for the current number!")
                End If

            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID eines Standard-Steuersatzes ab.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SettingDefaultTaxID() As Integer
            Get
                Return CInt(Me.GetSetting(RegistryValues.DefaultCashAccountTaxID, RegistrySections.CurrentVersion, "0"))
            End Get
            Set(ByVal value As Integer)
                Me.SetSetting(RegistryValues.DefaultCashAccountTaxID, RegistrySections.CurrentVersion, value.ToString)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen Wert ab oder legt fest der angibt ob eine Mitteilung an den Qualitätsfeedback-Server gesendet werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SettingSendStatistics() As Boolean
            Get
                Return CBool(Me.GetSetting("QualiFeedback", RegistrySections.Communication, "1"))
            End Get

            Set(ByVal value As Boolean)
                Try
                    Me.SetSetting("QualiFeedback", RegistrySections.Communication, CStr(CInt(value)))

                Catch ex As Exception
                    MainApplication.Log.WriteLog("Quilifeedback - einstellung kann nicht geschrieben werden:" & ex.Message)
                End Try

            End Set
        End Property


#End Region

        ''' <summary>
        ''' Ruft den zuletzt in Angebote/Rechnungen vertwendeten Kontorahmen ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LastSelectedCashAccount As CashAccount
            Get
                Dim lastselectedCashAccountID As String
                lastselectedCashAccountID = Me.GetSetting("BillsTransaction", "GUI", "")
                Dim selectedCashAccount As CashAccount = MainApplication.CashAccounts.GetItem(lastselectedCashAccountID)
                Return selectedCashAccount

            End Get
            Set(ByVal value As CashAccount)
                If value IsNot Nothing Then
                    Me.SetSetting("BillsTransaction", "GUI", value.Key)

                Else
                    Me.SetSetting("BillsTransaction", "GUI", "")
                End If
            End Set
        End Property

        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)
            Initialize()
        End Sub

        Public Sub New(ByVal baseApplication As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(baseApplication, criteria)
            Initialize()
        End Sub

        Public Sub Initialize() Implements IDataCollection.Initialize
            For Each settingItem As Setting In Me
                Dim settingsKey As String = settingItem.Name & "_" & settingItem.Area & "_" & settingItem.UserName

                If Not m_settingsCache.ContainsKey(settingsKey) Then
                    m_settingsCache.Add(settingsKey, settingItem.Value)
                End If


            Next


        End Sub
    End Class

    ''' <summary>
    ''' Stellt eine geänderte Einstellung dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SettingChangedEventArgs
        Inherits EventArgs


        Private m_settingName As String

        Public Property SettingName() As String
            Get
                Return m_settingName
            End Get
            Set(ByVal value As String)
                m_settingName = value
            End Set
        End Property


        Private m_oldValue As Object

        Private m_newValue As Object

        Public Property NewValue() As Object
            Get
                Return m_newValue
            End Get
            Set(ByVal value As Object)
                m_newValue = value
            End Set
        End Property

        Public Property OldValue() As Object
            Get
                Return m_oldValue
            End Get
            Set(ByVal value As Object)
                m_oldValue = value
            End Set
        End Property


    End Class

End Namespace
