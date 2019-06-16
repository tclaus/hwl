Imports ClausSoftware.Kernel
Imports ClausSoftware.Tools
Imports DevExpress.Xpo.DB
Imports Microsoft.Win32
Imports System.IO
Imports System.IO.IsolatedStorage

''' <summary>
''' Stellt eine Kennung bereit, mit der die Art der Applikation festgelegt werden kann. 
''' wir haben im Moment die Typen: HWl, PowerBüro und Weiteer "OEM". Der tatsächliche Application-Name kann durch die Eigenschaft "ApplicationName" ermittelt werden
''' </summary>
''' <remarks></remarks>
Public Enum AppType
    HWL
    PowerBuero
    OEM
End Enum

''' <summary>
''' Hauptklasse, stellt Verweise zu allen anderen Business-Objekten bereit
''' </summary>
''' <remarks></remarks>
<DebuggerDisplay("InstanceID={UniqueID}")>
Public Class MainApplication

    ''' <summary>
    ''' Kennzeichnet eindeutig eine Instanz des Objektes
    ''' </summary>
    ''' <remarks></remarks>
    Private UniqueID As Integer

    ''' <summary>
    ''' Enthält den letzten bekannten Datenbank status
    ''' </summary>
    ''' <remarks></remarks>
    Private m_dbconnectionState As DBConnectionState

    ''' <summary>
    ''' Stellt ein Ereignis bereit für allgemeine Nachrichten, die für den Anwender sichtbar in der Oberfläche erscheinen
    ''' </summary>
    ''' <param name="messagetext"></param>
    ''' <remarks></remarks>
    Public Event Message(ByVal messagetext As String)
    Public Event Progress(ByVal text As String, ByVal value As Integer, ByVal maxValue As Integer)

    ''' <summary>
    ''' Signalisiert das ein Balken für die Anzeige eines Vorganges unbestimmter Dauer erscheinen soll
    ''' </summary>
    ''' <remarks></remarks>
    Public Event StartMarquee(ByVal sender As Object, ByVal e As EventArgs)
    ''' <summary>
    ''' Zeigt an, das der Marquee-Balken verschiwnden soll
    ''' </summary>
    ''' <remarks></remarks>
    Public Event EndMarquee(ByVal sender As Object, ByVal e As EventArgs)
    ''' <summary>
    ''' Wird gesendet, um einen Fortschritsbalken wieder zu beenden 
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ProgressHide(ByVal sender As Object, ByVal e As EventArgs)

    ''' <summary>
    ''' Sendet ein ereignis, wenn ein Problem mit der DAtenbankverbindung festgestellt wurde.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event DatabaseConnectionError(ByVal sender As Object, ByVal e As DatabaseErrorEventArgs)

    Public Event NetworkstateChanged(ByVal sender As Object, ByVal e As DatabaseConnectionStateChanged)


    Private m_users As Kernel.Security.Users

    Private m_cashJournalTimeFrame As CashJournalTimeFrame
    Private m_contacts As Adressen
    Private m_Briefe As Letters
    Private m_connections As Connections
    Private m_cashAccounts As CashAccounts
    Private m_UserStats As UserStats
    ''' <summary>
    ''' Enthält die Auflistung aller Lohnkonten
    ''' </summary>
    ''' <remarks></remarks>
    Private m_loanAccounts As LoanAccounts

    Private m_units As Units
    Private m_DBVersions As DataBaseVersion
    Private m_JournalDocuments As JournalDocuments
    Private m_settings As Settings
    Private m_taxRates As TaxRates
    Private m_Rohstoffpreise As Rohstoffpreise
    Private m_Textschablonen As TextTemplates
    Private m_CashJournal As CashJournalItems
    Private m_FixedCosts As FixedCosts
    Private m_notes As Tasks
    Private m_images As Images
    Private m_baseWorkItems As BaseWorkItems
    Private m_groups As Groups
    Private m_licenses As Data.Licenses
    Private m_transactions As Transactions
    Private m_databaseConnection As DataBase.DbEngine

    Friend Shared m_CurrentConnection As New Connection
    Private m_mainSession As Session

    Private m_articleList As Articles
    Private m_tools As ClausSoftware.Tools.Tools
    Private m_attachmentRelations As AttachmentsRelations
    Private m_appointments As ClausSoftware.Kernel.Appointments
    Private m_appointmentsresources As ClausSoftware.Kernel.AppointmentsResources
    Private m_logHandler As LogHandling

    Private m_discounts As Kernel.Discounts

    Private m_classdefinitions As Attributes.ClassDefinitions
    Private WithEvents DatabaseTimer As New Timers.Timer(8 * 60 * 1000) ' alle 5 Miniten ein Keepalive senden

    Private m_FixCostGroups As ClausSoftware.Kernel.FixedCostGroups

    Private m_HistoryCategories As Kernel.HistoryCategories

    Private m_multiselectProfiles As Kernel.Attributes.MultiSelectProfiles

    Private m_recentlyUsed As Kernel.RecentlyUsedItems

    ''' <summary>
    ''' Stellt den Addin-manager zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    Private m_addinManager As AddIns.AddInManager

    ''' <summary>
    ''' Enthält das Lockstate Objekt 
    ''' </summary>
    ''' <remarks></remarks>
    Private m_lockstate As Kernel.Security.SecurityLocks

    ''' <summary>
    ''' Ruft den Manager ab, der Addins bereitstellt
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AddIns As AddIns.AddInManager
        Get
            If m_addinManager Is Nothing Then
                m_addinManager = New AddIns.AddInManager()
                m_addinManager.LoadAddins()
            End If
            Return m_addinManager
        End Get
    End Property

    ''' <summary>
    ''' Rurft einen Manager ab, der die Lock-flags zum sperren von Elementen enthält
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property LockStateManager() As Security.SecurityLocks
        Get
            If m_lockstate Is Nothing Then
                m_lockstate = New Security.SecurityLocks(Me)
            End If

            Return m_lockstate
        End Get
    End Property

    ''' <summary>
    ''' Ruft eine Auflistung von zuletzt verwendeten Elemente ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RecentlyUsedItems() As Kernel.RecentlyUsedItems
        Get
            If m_recentlyUsed Is Nothing Then
                m_recentlyUsed = New RecentlyUsedItems(Me)
            End If
            Return m_recentlyUsed
        End Get

    End Property

    ''' <summary>
    ''' Ruft eine Liste mit 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MultiselectProfiles() As Kernel.Attributes.MultiSelectProfiles
        Get

            If m_multiselectProfiles Is Nothing Then
                m_multiselectProfiles = New Kernel.Attributes.MultiSelectProfiles(Me)
            End If

            Return m_multiselectProfiles
        End Get

    End Property

    ''' <summary>
    ''' Ruft die Liste aller Kategorien für die History ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HistoryCategories() As Kernel.HistoryCategories
        Get
            If m_HistoryCategories Is Nothing Then
                m_HistoryCategories = New Kernel.HistoryCategories(Me)
            End If
            Return m_HistoryCategories
        End Get

    End Property

    ''' <summary>
    ''' Ruft alle Fixkostengruppen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FixedCostGroups() As ClausSoftware.Kernel.FixedCostGroups
        Get
            If m_FixCostGroups Is Nothing Then
                m_FixCostGroups = New FixedCostGroups(Me)
            End If
            Return m_FixCostGroups
        End Get

    End Property

    ''' <summary>
    ''' Enthält den Standard-benutzer des Systems. Ist keine Benutzerverwaltung aktiviert, dann wird ein Benutzer aus den systemdaten ermittelt
    ''' </summary>
    ''' <remarks></remarks>
    Private m_currentUser As Kernel.Security.User

    Private m_userrights As Security.UserRights

    Private m_language As Tools.Localisator
    ''' <summary>
    ''' Sendet das Signal um einen Wartebalen unbestimmter Dauer anzuzeigen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartMarqueeBar()
        RaiseEvent StartMarquee(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Sendet das Signal um einen eingeschalteten Wartebalken wieder zu beenden
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndMarqueeBar()
        RaiseEvent EndMarquee(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Ruft die Instanz der Sprachverwaltung ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Languages() As Tools.Localisator
        Get
            If m_language Is Nothing Then
                m_language = New Localisator()
            End If

            Return m_language
        End Get

    End Property

    ''' <summary>
    ''' Ruft die Auflistung aller Benutzerberechtigungen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UserRights() As Security.UserRights
        Get
            If m_userrights Is Nothing Then
                m_userrights = New Security.UserRights(Me)
            End If
            Return m_userrights
        End Get
    End Property

    ''' <summary>
    ''' Ruft den aktuellen Systembenutzer ab oder legt diesen fest.
    ''' Mit diesem Benutzer werden alle Programmeinstellungen geladen und gespeichert. zB Fenstergrösse- und Position, 
    ''' Layouteigenschaften der Listen usw. Jedoch keine Global wirksamen Eigenschaften.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Gibt es keine Benutzerverwaltung, so sollte immer ein Standardbenutzer existieren, der aus dem Rechenrnamen und Anmeldenamen gebildet wird.</remarks>
    Public Property CurrentUser() As Kernel.Security.User
        Get
            If m_currentUser Is Nothing Then
                m_currentUser = Me.Users.GetUserByComputer
            End If

            Return m_currentUser
        End Get
        Set(ByVal value As Kernel.Security.User)
            m_currentUser = value
        End Set
    End Property


    ''' <summary>
    ''' Ruft die Liste der Benutzer ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Users() As Kernel.Security.Users
        <DebuggerStepThrough()>
        Get
            If m_users Is Nothing Then
                m_users = New Kernel.Security.Users(Me)
            End If
            Return m_users

        End Get

    End Property

    ''' <summary>
    ''' Ruft eine Merkmalliste ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ClassDefinitions() As Attributes.ClassDefinitions
        Get
            If m_classdefinitions Is Nothing Then
                m_classdefinitions = New Attributes.ClassDefinitions(Me)
            End If
            Return m_classdefinitions
        End Get

    End Property

    ''' <summary>
    ''' Ruft die Rabattgruppen ab 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Discounts() As Discounts
        Get
            If m_discounts Is Nothing Then
                m_discounts = New Discounts(Me)
            End If
            Return m_discounts
        End Get

    End Property


    Private instanceID As String

    ''' <summary>
    ''' Ruft die eindeutige ProgrammID (32 stellige ID) ab. Ist nur gültig, wenn die DAtenbank auch geöffnet wurde, sonst wird eine neue ID erzeugt und zurückgegeben.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ApplicationID() As String
        Get
            ' Nur, wenn DB-Verbindung besteht !
            If instanceID Is Nothing Then
                'ProgrammID in die Datenbank schreiben falls noch niucht geschehen 
                If Settings.SettingProgrammID.Length = 0 Then
                    Settings.SettingProgrammID = Connections.DefaultInitialID
                    Settings.Save()
                End If

                instanceID = Me.Settings.SettingProgrammID
                SetLastUsedApplicationID(instanceID)

            End If

            Return instanceID
        End Get

    End Property

    ''' <summary>
    ''' Schreibt die zuletzt verwendete ApplicationID in einen dauerhaften lokalen Speicher
    ''' </summary>
    ''' <param name="appID"></param>
    ''' <remarks></remarks>
    Private Sub SetLastUsedApplicationID(ByVal appID As String)

        Dim isolatedStorage As System.IO.IsolatedStorage.IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, Nothing, Nothing)
        Dim isoStream As New IsolatedStorageFileStream("AppID.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write)

        Using writer As New StreamWriter(isoStream)
            writer.WriteLine(appID.Trim)
        End Using

    End Sub
    ''' <summary>
    ''' Ruft die zuletzt verwendete ApplicationID ab, falls möglich
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetLastKnownApplicationID() As String
        Dim InputText As String = "No ID"
        Try
            Dim isolatedStorage As System.IO.IsolatedStorage.IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, Nothing, Nothing)

            Dim isolatedStream As New IsolatedStorageFileStream("AppID.txt", FileMode.Open, FileAccess.Read)


            Using reader As New StreamReader(isolatedStream)
                InputText = reader.ReadToEnd
            End Using
        Catch ex As Exception
            Debug.Print("GetLastKnownApplicationID: " & ex.Message)
        End Try

        Return InputText.Trim
    End Function

    ''' <summary>
    ''' Ruft eine direkte Verbindung zur Datenbank ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Database() As DataBase.DbEngine
        Get
            If m_databaseConnection Is Nothing Then
                m_databaseConnection = New DataBase.DbEngine(Me.Connections.WorkConnection)
                m_databaseConnection.MainApplication = Me
            End If

            Return m_databaseConnection

        End Get

    End Property

    ''' <summary>
    ''' Ruft eine Auflistung der Lohnkoten ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LoanAccounts() As LoanAccounts
        Get
            If m_loanAccounts Is Nothing Then
                m_loanAccounts = New LoanAccounts(Me)
            End If
            Return m_loanAccounts

        End Get

    End Property

    Private Shared instanceName As String

    ''' <summary>
    ''' Ruft den OEM-Kurznamen der Applikation ab. Im Moment fest verdrahtet.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ApplicationName() As String

        Const appnamestr As String = "ApplicationName"

        Dim appType As String = GetCommandLineParameter("apptype")
        If Not String.IsNullOrEmpty(appType) Then Return appType

        If instanceName Is Nothing Then
            ' Aus der Applikations-Datei den Programmtype lesen
            Dim fileContents As String
            Dim filename As String = "ApplicationInfo.ini"

            filename = System.IO.Path.Combine(My.Application.Info.DirectoryPath, filename)
            Debug.Print("Suche nach Datei mit Applikationsname: " & filename)

            If My.Computer.FileSystem.FileExists(filename) Then

                fileContents = My.Computer.FileSystem.ReadAllText(filename, System.Text.UTF8Encoding.UTF7)

                ' Format ist Type = Wert

                If fileContents.Contains(appnamestr) Then
                    Dim filepos As Integer
                    filepos = fileContents.IndexOf(appnamestr)
                    ' ab der Position vom = bis zum ende
                    Dim value As String
                    value = fileContents.Substring(filepos + appnamestr.Length + 1)
                    If value.Contains(vbCrLf) Then
                        value = value.Substring(0, value.IndexOf(vbCrLf)).Trim
                    End If

                    instanceName = value
                Else
                    instanceName = "HWL"
                End If
            Else ' File not fouund; suche nach vorhandenem Registry - Key

                Debug.Print("Keine Datei gefunden; analysiere Registry...")
                ' Suche nach aktuellem Registry-Key: 
                Dim exists As Boolean = False
                Try
                    Dim regKey As RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\VB and VBA Program Settings")

                    If regKey IsNot Nothing Then

                        'Alle möglichen unter-Schlüssel durchsuchen
                        'TODO: Später HWL2 einen eigenen subkey geben
                        Dim subKeys As String() = regKey.GetSubKeyNames


                        For Each subKey As String In subKeys
                            If subKey.Contains("HWL") Then
                                If regKey.OpenSubKey(subKey & "\Current Version") IsNot Nothing Then
                                    If subKey.Contains("HWL") Then
                                        instanceName = "HWL2"
                                    Else
                                        instanceName = "PB2"

                                    End If
                                    Exit For
                                Else
                                    instanceName = "PB2"
                                    Exit For
                                End If
                            End If

                            ' Kein registry-Key gefunden; NLS nicht möglich, da App noch nicht gestartet ist                            
                            instanceName = "<Keine Applikation installiert>"
                        Next

                    End If


                Finally
                    My.Computer.Registry.CurrentUser.Close()
                End Try


            End If
        End If

        Return instanceName
    End Function

    ''' <summary>
    ''' Ruft die Protokollinstanz ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Log() As LogHandling
        Get
            If m_logHandler Is Nothing Then
                m_logHandler = New LogHandling()
            End If
            Return m_logHandler
        End Get

    End Property

    ''' <summary>
    ''' Sendet eine öffentliche Nachricht aus dem Systemkern. Dies kann als Ereignis abgefangen und in Oberflächen angezeigt werden werden
    ''' </summary>
    ''' <param name="message">Die Nachricht, die öffentlich gemacht werden soll</param>
    ''' <remarks></remarks>
    Public Sub SendMessage(ByVal message As String)
        SendMessage(message, False)
    End Sub
    ''' <summary>
    ''' Sendet eine öffentliche Nachricht aus dem Systemkern. Dies kann als Ereignis abgefangen und in Oberflächen angezeigt werden werden
    ''' </summary>
    ''' <param name="dontLog">Wenn True, dann wird das senden an die Logging-Instanz unterdrückt</param>
    ''' <param name="message">Die Nachricht, die öffentlich gemacht werden soll</param>
    Public Sub SendMessage(ByVal message As String, ByVal dontLog As Boolean)
        If Not dontLog And message.Trim.Length > 0 Then
            If Not String.IsNullOrEmpty(message) Then Me.Log.WriteLog("User Message: " & message)
        End If

        RaiseEvent message(message)
    End Sub

    Public ReadOnly Property DatabaseConnectionstate As DBConnectionState
        Get
            Return m_dbconnectionState
        End Get
    End Property


    ''' <summary>
    ''' Sendet eine Benachrichtigung, die einen warte-Balken unbestimmter länge anzeigt
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="currentValue"></param>
    ''' <param name="maxvalue"></param>
    ''' <remarks></remarks>
    Public Sub SendProgress(ByVal text As String, ByVal currentValue As Integer, ByVal maxvalue As Integer)
        RaiseEvent Progress(text, currentValue, maxvalue)
    End Sub

    Public Sub HideProgressBar()
        RaiseEvent ProgressHide(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Ruft die Auflistung aller termine auf
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Appointments() As ClausSoftware.Kernel.Appointments
        Get
            If m_appointments Is Nothing Then
                m_appointments = New Appointments(Me)

            End If
            Return m_appointments
        End Get

    End Property

    Public ReadOnly Property AppointmentResources() As ClausSoftware.Kernel.AppointmentsResources
        Get
            If m_appointmentsresources Is Nothing Then
                m_appointmentsresources = New AppointmentsResources(Me)
            End If
            Return m_appointmentsresources
        End Get

    End Property

    Private Shared m_sessionID As Long

    ''' <summary>
    ''' Stellt eine Zufallszahl bereit, die innerhalb dieser Sitzung eindeutig ist
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared ReadOnly Property SessionID() As Long
        Get
            If m_sessionID = 0 Then
                Dim r As New Random(Now.Millisecond)
                m_sessionID = r.Next(10000, Integer.MaxValue)

            End If
            Return m_sessionID
        End Get
    End Property

    ReadOnly Property Tools() As Tools.Tools
        Get
            If m_tools Is Nothing Then
                m_tools = New Tools.Tools(Me)
            End If

            Return m_tools
        End Get
    End Property

    ''' <summary>
    ''' Ruft die standard-Datenbankschicht ab die für dieses Prozess verwendet wird
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Session() As Session
        <DebuggerStepThrough()>
        Get
            Return m_mainSession
        End Get
    End Property

    ''' <summary>
    ''' Ruft eine neue Session mit diesem Objekt ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNewSession() As Session
        Return XpoHelper.GetNewSession
    End Function

    ''' <summary>
    ''' Ruft eine neues Arbeitspaket ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNewUnitOfWork() As UnitOfWork
        Return XpoHelper.GetNewUnitOfWork
    End Function

    ''' <summary>
    ''' Ruft eine Liste von Verbindung von quelldokumenten zu verbundenen Anhängen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AttachmentRelations() As AttachmentsRelations
        <DebuggerStepThrough()>
        Get
            If m_attachmentRelations Is Nothing Then
                m_attachmentRelations = New AttachmentsRelations(Me)
            End If
            Return m_attachmentRelations


        End Get


    End Property

    ''' <summary>
    ''' Ruft ein Interval von Kassenbucheinträgen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CashJournalTimeFrame As CashJournalTimeFrame
        Get
            If m_cashJournalTimeFrame Is Nothing Then
                m_cashJournalTimeFrame = New CashJournalTimeFrame()
            End If
            Return m_cashJournalTimeFrame
        End Get
    End Property

    ''' <summary>
    ''' Stellt das Kassenbuch bereit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CashJournal() As CashJournalItems
        <DebuggerStepThrough()>
        Get
            If m_CashJournal Is Nothing Then
                m_CashJournal = New CashJournalItems()
            End If

            Return m_CashJournal
        End Get

    End Property

    ''' <summary>
    ''' Ruft eine Auflistung von Forderungen / Verbindlichkeiten ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Transactions() As Transactions
        <DebuggerStepThrough()>
        Get
            If m_transactions Is Nothing Then
                m_transactions = New Transactions()
                m_transactions.Initialize()
            End If
            Return m_transactions

        End Get
    End Property


    ''' <summary>
    ''' Ruft eine Verwaltungsschicht für die Behandlung von Lizenzen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Licenses() As Data.Licenses
        <DebuggerStepThrough()>
        Get
            If m_licenses Is Nothing Then
                m_licenses = New Data.Licenses()
                m_licenses.InitilizeLicenses()
            End If
            Return m_licenses
        End Get
    End Property

    ''' <summary>
    ''' Stellt die Auflistung der Fixkosten bereit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FixedCosts() As FixedCosts
        Get
            If m_FixedCosts Is Nothing Then
                m_FixedCosts = New FixedCosts(Me)
            End If

            Return m_FixedCosts
        End Get

    End Property

    ''' <summary>
    ''' Ruft die Gruppenliste ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Groups() As Groups
        <DebuggerStepThrough()>
        Get
            If m_groups Is Nothing Then
                m_groups = New Groups(Me)
            End If
            Return m_groups
        End Get

    End Property

    ''' <summary>
    ''' Gibt eine Auflistung aller Artikel zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ArticleList() As Articles
        <DebuggerStepThrough()>
        Get
            If m_articleList Is Nothing Then
                m_articleList = New Articles(Me)
            End If

            Return m_articleList
        End Get

    End Property


    ''' <summary>
    ''' Gibt eine eine Liste von Textbausteinen zurück.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TextTemplates() As TextTemplates
        Get
            If m_Textschablonen Is Nothing Then
                m_Textschablonen = New TextTemplates(Me)
            End If

            Return m_Textschablonen
        End Get

    End Property

    ''' <summary>
    ''' Gibt eine Liste mit Datanorm-Rohstoffpreise zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Rohstoffpreise() As Rohstoffpreise
        Get
            If m_Rohstoffpreise Is Nothing Then
                m_Rohstoffpreise = New Rohstoffpreise(Me)
            End If
            Return m_Rohstoffpreise
        End Get

    End Property

    ''' <summary>
    ''' Gibt eine Liste mit Steuersätzen zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TaxRates() As TaxRates
        <DebuggerStepThrough()>
        Get
            If m_taxRates Is Nothing Then
                m_taxRates = New TaxRates(Me)
            End If
            Return m_taxRates
        End Get

    End Property

    ''' <summary>
    ''' Ruft eine LIste mit gespeicherten Bildern ab.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Images() As Images
        <DebuggerStepThrough()>
        Get
            If m_images Is Nothing Then
                m_images = New Images(Me)
            End If
            Return m_images
        End Get
    End Property

    ''' <summary>
    ''' Gibt eine Liste mit Adressbucheinträgen zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Adressen() As Adressen
        <DebuggerStepThrough()>
        Get
            If m_contacts Is Nothing Then
                m_contacts = New Adressen(Me)
            End If
            Return m_contacts
        End Get
    End Property

    Public ReadOnly Property BaseWorkItems() As BaseWorkItems
        <DebuggerStepThrough()>
        Get
            If m_baseWorkItems Is Nothing Then
                m_baseWorkItems = New BaseWorkItems(Me)
            End If

            Return m_baseWorkItems

        End Get
    End Property

    ''' <summary>
    ''' Gibt eine Liste mit Journaleinträgen zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property JournalDocuments() As JournalDocuments
        <DebuggerStepThrough()>
        Get
            If m_JournalDocuments Is Nothing Then
                m_JournalDocuments = New JournalDocuments(Me)
            End If

            Return m_JournalDocuments
        End Get
    End Property

    ''' <summary>
    ''' Gibt eine Liste mit Kurzbriefen zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Letters() As Letters
        <DebuggerStepThrough()>
        Get
            If m_Briefe Is Nothing Then
                m_Briefe = New Letters(Me)
            End If
            Return m_Briefe
        End Get
    End Property

    ''' <summary>
    ''' Gibt eine Liste mit Einheiten zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Units() As Units
        Get
            If m_units Is Nothing Then
                m_units = New Units(Me)
            End If
            Return m_units
        End Get
    End Property

    ''' <summary>
    ''' Ruft die auflistung der Notizen ab.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Tasks() As Tasks
        <DebuggerStepThrough()>
        Get
            If m_notes Is Nothing Then
                m_notes = New Tasks(Me)
            End If
            Return m_notes
        End Get
    End Property
    ''' <summary>
    ''' Gibt die aktuelle Datenbankversion zurück oder setzt diese.
    ''' ein setzten wirkt sich sofort auf die Datenbank aus und wird geschrieben.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DBVersion() As String
        Get
            Try
                If m_DBVersions Is Nothing Then
                    m_DBVersions = New DataBaseVersion(Me)
                    m_DBVersions.Load()
                End If
                Return m_DBVersions.DBVersion
            Catch ex As Exception
                Me.Log.WriteLog(ex, "Kernel", "Get DBVersion")

            End Try
            Return String.Empty
        End Get
        Set(ByVal value As String)

            If m_DBVersions Is Nothing Then
                m_DBVersions = New DataBaseVersion(Me)
            End If

            m_DBVersions.Reload()
            If m_DBVersions.Count = 0 Then
                ' das einzige Objekt anlegen 
                m_DBVersions.Add(New DBVersion(m_mainSession))

            End If

            m_DBVersions.DBVersion = value

            m_DBVersions.Save()
        End Set
    End Property




    ''' <summary>
    ''' Gibt die Liste der Einstellungen zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Settings() As Settings
        <DebuggerStepThrough()>
        Get
            If m_settings Is Nothing Then
                m_settings = New Settings(Me)
            End If

            Return m_settings
        End Get

    End Property


    'TODO: Hier ist noch etwas zu füllen
    ''' <summary>
    ''' Holt eine Liste mit konfiguriertren Datenbank-Verbinden ab.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Connections() As Connections
        <DebuggerStepThrough()>
        Get
            If m_connections Is Nothing Then
                m_connections = New Connections()
            End If

            Return m_connections
        End Get

    End Property

    ''' <summary>
    ''' Ruft die Liste der Buchungs-Konten ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CashAccounts() As CashAccounts
        <DebuggerStepThrough()>
        Get
            If m_cashAccounts Is Nothing Then
                m_cashAccounts = New CashAccounts(Me)
            End If

            Return m_cashAccounts

        End Get

    End Property


    ''' <summary>
    ''' Stellt Staitsische Informationen zur Verfügung und kann Statistiosche Daten senden 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UserStats() As UserStats
        <DebuggerStepThrough()>
        Get
            If m_UserStats Is Nothing Then
                m_UserStats = New UserStats()
            End If
            Return m_UserStats
        End Get
    End Property

    '''' <summary>
    '''' Holt die aktuelle Datenbankverbindung ab. Im Testbetrieb ist das eine MySQL-Datenbank auf einem Server
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public ReadOnly Property CurrentConnection() As Connection
    '    Get
    '        m_CurrentConnection = Connections.GetCurrentConnection(HWLData.enumServerType.Access)
    '        ' prüfe

    '        Return m_CurrentConnection
    '    End Get

    'End Property

    ''' <summary>
    ''' Legt Verbindungen zur Datenbank fest
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Initialize(ByVal myConnection As Connection) As Boolean
        'Hier das globale Session-Objekt erzeugen

        Me.SendMessage(Me.Languages.GetText("ConnectingToDatabase...", "Verbinde mit Datenbank..."))

        If myConnection Is Nothing Then
            'TODO:NLS
            Throw New Exception(Me.Languages.GetText("NoConnectionDefinied", "Keine Verbindung zur Datenbank festgelegt"))
        End If


        Static oldconnnection As Connection = New Connection

        ' dies auch als Default festlegen
        'Me.Connections.SetAsDefaultConection(myConnection)

        Try
            If myConnection IsNot Nothing Then
                If m_mainSession IsNot Nothing AndAlso m_mainSession.IsConnected And Not myConnection.Equals(oldconnnection) Then
                    Log.WriteLog("Verbindung zum XPO-Objekt war noch geöffnet und eine andere Verbindung wird angefordert.")


                    m_mainSession.Connection.Close()

                Else


                End If

                Dim connState As Boolean


                If m_mainSession Is Nothing Then
                    connState = False
                Else
                    connState = m_mainSession.IsConnected
                End If

                If Not connState Then
                    Debug.Print("Erstelle neue Verbindung: " & myConnection.GetConnectionDescription)


                    Dim Conn As String = ClausSoftware.Tools.Connections.GetConnectionString(myConnection)
                    XpoHelper.SetConnection(Conn)
                    'XpoDefault.DataLayer = XpoDefault.GetDataLayer(Conn, AutoCreateOption.None)' Klassich
                    'm_mainSession = New Session(XpoDefault.DataLayer)

                    XpoDefault.Session = Nothing

                    If IsSchemaValid() Then  ' Schema prüfen und session erstellen

                        If m_mainSession Is Nothing Then
                            m_mainSession = XpoHelper.GetNewSession
                        End If

                        ' Falls die Einheiten komplett leer sind: Neu anlegen 
                        Me.Units.FillMinimalUnitList()


                        oldconnnection = CType(myConnection.Clone, Connection)



                        ' Alles OK 
                        SendMessage("Verbindung hergestellt")

                        'Debug.Print("  Connection:" & m_mainSession.DataLayer.Connection.ConnectionString)

                    Else
                        Throw New ApplicationException(Me.LastSchemaUpdateError)
                        Debug.Print("Schema benötigt ein Update!")

                    End If
                End If
            End If

            SetActiveUserInstance()

            If myConnection.Servertype = enumServerType.MySQL Then
                DatabaseTimer.Start()
            End If


            ' Beim Starten als ersten den aktuellen rechnernamen / Usernamen als Temporären benutzer definieren
            Me.CurrentUser = Me.Users.GetUserByComputer

            RemoveOldDataLocks()

            Return True
        Catch e As Exception
            'TODO: Meldung machen, wenn connection nicht funktionierte
            SendMessage("Konnte keine Verbindung herstellen: " & e.Message)

            Return False
        End Try
    End Function

    ''' <summary>
    ''' Entfernt alte Datei-Sperren
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveOldDataLocks()
        Try
            Me.Log.WriteLog(LogSeverity.Verbose, "RemoveOldDataLocks: Datensatzsperren aufheben")
            'Alle Datensatz-Sperren entfernen
            Using locks As New Security.SecurityLocks(Me)
                locks.ClearAllLocks()
            End Using


        Catch ex As Exception
            Me.Log.WriteLog(ex, "ActiveInstances", "Set Userinstance failed")
        End Try


    End Sub

    ''' <summary>
    ''' Setzt einen aktiven Benuzter. Prüft, ob die aktuelle Datenbankinstanz die Anzahl der aktuellen Verbindungen erlaubt
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetActiveUserInstance()
        Try
            ' Eigene Logininfos setzen
            Me.Log.WriteLog(LogSeverity.Verbose, "Setzte aktive Benutzerinstanz")
            Using InstanceMonitor As New ActiveInstances(Me)
                InstanceMonitor.WriteLoginTag()
                Me.Log.WriteLog("Aktuell aktive Benutzerinstanzen:" & InstanceMonitor.Count)
            End Using

        Catch ex As Exception
            Me.Log.WriteLog(ex, "ActiveInstances", "Set Userinstance failed")

        End Try

    End Sub


    ''' <summary>
    ''' Schliesst eine Datenverbindung wieder
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseConnection()
        Debug.Print("CloseConnection: Verbindung Schliessen angefordert")
        Try
            If m_mainSession IsNot Nothing Then
                If m_mainSession.DataLayer IsNot Nothing Then
                    Using instances As New ActiveInstances(Me)
                        instances.RemoveOwnInstance()
                    End Using

                End If

                DatabaseTimer.Stop()
                Database.CloseConnection()
                m_mainSession.Disconnect()

            End If

        Catch ex As Exception
            Debug.Print("Fehler beim schliessen der Verbindungen des MainApplication-Objektes: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Ruft die Fehlermeldung ab, die beim Start ein Fehler beim Schemaupdate (aktualisieren der Datenbank) beschereibt
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LastSchemaUpdateError As String
        Get
            Return m_lastSchemaUpdateError
        End Get
    End Property
    Private m_lastSchemaUpdateError As String

    Private m_DatabaseSchema As Data.SchemaUpdater

    ''' <summary>
    ''' Prüft, ob das Schema aktualisiert werden muss
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function IsSchemaValid() As Boolean
        If m_DatabaseSchema Is Nothing Then m_DatabaseSchema = New Data.SchemaUpdater()


        m_DatabaseSchema.StartUpdate()
        If String.IsNullOrEmpty(m_DatabaseSchema.LastError) Then
            m_lastSchemaUpdateError = m_DatabaseSchema.LastError

            Me.Database.GenerateDatabaseSchema()

            Return True
        Else
            m_lastSchemaUpdateError = m_DatabaseSchema.LastError
            Return False
        End If


    End Function

    Private Shared m_instance As MainApplication = New MainApplication

    Public Shared Function getInstance() As MainApplication
        Return m_instance
    End Function

    Private Sub New()
        Static Dim intCounter As Integer
        If Data.BaseClass.m_mainApplication Is Nothing Then ' Mehrfachinstantiierung kann vorkommen, wenn für einen Testaufbau der Datenbankverbindung ein weiteres Application-Objekt erzeugt wird
            Data.BaseClass.m_mainApplication = Me
            ' kann man das als atomares Objekt definieren? 
        End If

        UniqueID = intCounter
        Log.WriteLog("Neuer Start von HWL...")
        Log.WriteLog(LogSeverity.Verbose, "Neue Instanz der Basis-Objekte: " & UniqueID)


        intCounter += 1
    End Sub

    ''' <summary>
    ''' Enthält die Db-Geschwindigkeit in ms
    ''' </summary>
    ''' <remarks></remarks>
    Private m_lastDatabaseSpeed As Integer

    ''' <summary>
    ''' stellt die zuletzt gemessene Datenbankgeschwindigkeit dar
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DebuggerDisplay("{m_lastDatabaseSpeed} ms")>
    Public ReadOnly Property LastDatabaseSpeed() As Integer
        Get
            Return m_lastDatabaseSpeed
        End Get

    End Property

    Private Sub DatabaseTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles DatabaseTimer.Elapsed
        If m_mainSession.IsConnected() Then
            Try
                If Me.Session.IsObjectsLoading Or Me.Session.IsObjectsSaving Then Exit Sub
                DatabaseTimer.Stop()

                PeriodicCheckConnection(False)


            Catch ex As Exception
                Debug.Print("Keepalive sent a Problem: " & ex.Message)
                Me.Log.WriteLog(LogSeverity.ErrorMessage, "Database connection lost!")

            Finally
                DatabaseTimer.Start() ' immer wieder prüfen...
            End Try

        Else
            Debug.Print("KeepAlive: No Connection.")
        End If
    End Sub

    ''' <summary>
    ''' Prüft die aktuelle Datenbankverbindung. 
    ''' Feuert eine Ausnahme, wenn die Verbinung nicht Aufgebaut ist. 
    ''' </summary>
    ''' <returns>True, falls die Verbindung in Ordnung ist, False sonst.</returns>
    ''' <remarks></remarks>
    Public Function PeriodicCheckConnection(ByVal raiseErrorEvent As Boolean) As Boolean
        SyncLock Me

            If Me.Session.IsObjectsLoading Or Me.Session.IsObjectsSaving Then Return True
            If Me.Database.BackupInProgress Then Return True

            Dim sw As New Stopwatch
            sw.Start()
            ' eine Aktion ausführen, die auch den richtigen Layer bedient

            If Me.Connections.DefaultConnection.Servertype = enumServerType.Access Then Return True ' Lokale Datei nicht testen !

            Dim oldState As DBConnectionState = m_dbconnectionState ' augenblicklichen Status feststellen

            Try

                If My.Computer.Network.IsAvailable Then

                    m_DBVersions.Reload()
                    Dim testVal As Object = Me.Database.ExcecuteScalar("Select max(ID) from Adressen")
                    If testVal Is Nothing Then
                        Throw New Exception("Could not get Data")
                    End If

                    m_dbconnectionState = DBConnectionState.OK

                Else
                    m_dbconnectionState = DBConnectionState.NetworkUnreachable
                    ' Netzwerk nicht erreichbar

                    ' Datenbankänderung signalisieren,falls sich etwas geändert hat
                    If oldState <> m_dbconnectionState Then
                        RaiseEvent NetworkstateChanged(Me, New DatabaseConnectionStateChanged(m_dbconnectionState))
                    End If

                    ' Dann ein ereignis senden, das eine Warnung auslöst
                    If raiseErrorEvent Then
                        RaiseEvent DatabaseConnectionError(Me, New DatabaseErrorEventArgs(DBConnectionState.NetworkUnreachable))
                    End If
                    Return False ' Keine gültige Datenbankverbindung 
                End If



            Catch ex As Exception
                ' Ein Ereignis senden, wenn ein Fehler erkannt wurde
                m_dbconnectionState = DBConnectionState.NetworkUnreachable


                If oldState <> m_dbconnectionState Then
                    RaiseEvent NetworkstateChanged(Me, New DatabaseConnectionStateChanged(m_dbconnectionState))
                End If

                If raiseErrorEvent Then
                    RaiseEvent DatabaseConnectionError(Me, New DatabaseErrorEventArgs(ex))
                Else
                    Throw ' event nach oben werfen
                End If
                Return False
            Finally
                sw.Stop()

            End Try

            Debug.Print("KeepAlive: Database speed: " & sw.ElapsedMilliseconds.ToString & "ms")
            m_lastDatabaseSpeed = CInt(sw.ElapsedMilliseconds)

            ' Datenbankänderung signalisieren, - zumindest die Zeitdauer hat scih geändert
            RaiseEvent NetworkstateChanged(Me, New DatabaseConnectionStateChanged(m_dbconnectionState))

            Return True

        End SyncLock
    End Function

    ''' <summary>
    ''' Setzt die Datenbak-Verbindung für alle Objekte
    ''' </summary>
    ''' <param name="session"></param>
    ''' <remarks></remarks>
    Friend Sub SetSession(ByVal session As DevExpress.Xpo.Session)
        m_mainSession = session
    End Sub

End Class

''' <summary>
''' Enthält eine Klasse, die einen Datalayer abholt
''' </summary>
''' <remarks></remarks>
Friend NotInheritable Class XpoHelper

    Private Shared m_connection As String

    Public Shared Sub SetConnection(ByVal Connection As String)
        m_connection = Connection
    End Sub


    Public Shared Function GetNewSession() As Session
        Return New Session(DataLayer)
    End Function

    Public Shared Function GetNewUnitOfWork() As UnitOfWork
        Return New UnitOfWork(DataLayer)
    End Function

    Private Shared lockObject As New Object()

    Private Shared fDataLayer As IDataLayer

    ''' <summary>
    ''' Ruft einen Datalayer ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared ReadOnly Property DataLayer() As IDataLayer
        Get
            If fDataLayer Is Nothing Then
                SyncLock lockObject
                    fDataLayer = GetDataLayer()
                End SyncLock
            End If
            Return fDataLayer
        End Get
    End Property

    ''' <summary>
    ''' Erstellt einen neuen multithreaded DataLayer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetDataLayer() As IDataLayer
        XpoDefault.Session = Nothing

        Dim dict As Metadata.XPDictionary = New Metadata.ReflectionDictionary()
        Dim store As IDataStore = XpoDefault.GetConnectionProvider(m_connection, AutoCreateOption.SchemaAlreadyExists)

        dict.GetDataStoreSchema(GetType(MainApplication).Assembly) ' Das Dictionary erstellen lasen 

        Dim dl As IDataLayer = New ThreadSafeDataLayer(dict, store)
        Return dl
    End Function


End Class

''' <summary>
''' Enthält einen Status des aktuellen Datenbankzustandes
''' </summary>
''' <remarks></remarks>
Public Enum DBConnectionState

    ''' <summary>
    ''' Alles OK 
    ''' </summary>
    ''' <remarks></remarks>
    OK

    ''' <summary>
    ''' Netzwerk nicht erreichbar
    ''' Problem mit der Netzwerkarte, Kabel LAn oder WAN
    ''' </summary>
    ''' <remarks></remarks>
    NetworkUnreachable

    ''' <summary>
    ''' Ein einfaches Ping kam nicht durch..
    ''' </summary>
    ''' <remarks></remarks>
    PingDidNotRespond
    ''' <summary>
    ''' Datenbank nicht erreichbar
    ''' </summary>
    ''' <remarks></remarks>
    DatabaseUnreachable

End Enum

''' <summary>
''' Sendet eine Mitteilung, das ein aktutes Datenbankproblem vorliegt
''' </summary>
''' <remarks></remarks>
Public Class DatabaseErrorEventArgs
    Inherits EventArgs


    Private m_dbErrorKind As DBConnectionState

    ''' <summary>
    ''' Ruft die Art des Fehles ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DBErrorKind() As DBConnectionState
        Get
            Return m_dbErrorKind
        End Get
    End Property

    Public Sub New(ByVal dberrorKind As DBConnectionState)
        m_dbErrorKind = dberrorKind
    End Sub

    Public Sub New(ByVal ex As Exception)
        m_innerException = ex
    End Sub

    Private m_innerException As Exception


    Public ReadOnly Property InnerException() As Exception
        Get
            Return m_innerException
        End Get
    End Property

End Class

''' <summary>
''' Stellt einen Ereignisparameter bereit, der die aktuelle Datenbankverbindung angiebt
''' </summary>
''' <remarks></remarks>
Public Class DatabaseConnectionStateChanged
    Inherits EventArgs

    Public Sub New(ByVal dbstate As DBConnectionState)
        m_dbConnectionState = dbstate
    End Sub

    Private m_dbConnectionState As DBConnectionState

    Public Property DatabaseConnectionstate() As DBConnectionState
        Get
            Return m_dbConnectionState
        End Get
        Set(ByVal value As DBConnectionState)
            m_dbConnectionState = value
        End Set
    End Property

End Class



