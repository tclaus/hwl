Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Exchange
Imports DevExpress.XtraScheduler.Outlook


''' <summary>
''' Enthält einen vollsständigen Terminplaner
''' </summary>
''' <remarks></remarks>
Public Class iucScheduler
    Implements IModule

    ''' <summary>
    ''' Enthält Pfade zu den Outlook-Kalender
    ''' </summary>
    ''' <remarks></remarks>
    Private outlookPaths() As String

    ''' <summary>
    ''' Erstellt verbindungen zur Datenbank
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initialize()

        InitializeApplication()


        SchedulerStorage1.BeginInit()
        SchedulerStorage1.Appointments.DataSource = m_application.Appointments

        SchedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
        SchedulerStorage1.Appointments.Mappings.Description = "Description"
        SchedulerStorage1.Appointments.Mappings.End = "EndDate"
        SchedulerStorage1.Appointments.Mappings.Label = "Label"
        SchedulerStorage1.Appointments.Mappings.Location = "Location"
        SchedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
        SchedulerStorage1.Appointments.Mappings.ResourceId = "ResourceId"
        SchedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
        SchedulerStorage1.Appointments.Mappings.Start = "StartDate"
        SchedulerStorage1.Appointments.Mappings.Status = "Status"
        SchedulerStorage1.Appointments.Mappings.Subject = "Subject"
        SchedulerStorage1.Appointments.Mappings.Type = "Type"


        SchedulerStorage1.Resources.Mappings.Caption = "Caption"
        SchedulerStorage1.Resources.Mappings.Color = "Color"
        SchedulerStorage1.Resources.Mappings.Id = "ID"
        SchedulerStorage1.Resources.Mappings.Image = "Image"

        SchedulerControl1.GoToToday()
        SchedulerStorage1.Resources.DataSource = m_application.AppointmentResources
        SchedulerControl1.ActivePrintStyle.AppointmentFont = New System.Drawing.Font(SchedulerControl1.ActivePrintStyle.AppointmentFont.FontFamily.Name, 8)
        SchedulerStorage1.EndInit()

#If DEBUG Then
        '  m_application.Licenses.RegisterGlobalLicense(m_licenseItem)
#End If



        Dim settingValue As String = m_application.Settings.GetSetting("Scheduler_Layout", "Layout", "", m_application.CurrentUser.Key)
        settingValue = settingValue.Trim(New Char() {" "c, "?"c})
        If Not String.IsNullOrEmpty(settingValue) Then
            Dim m As New System.IO.MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(settingValue))
            SchedulerControl1.RestoreLayoutFromStream(m)
        End If

    End Sub

    ''' <summary>
    ''' Zeigt an, ob eine Lizenz für dieses Modul zur Verfügung steht
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsActive() As Boolean
        Return m_application.Licenses.IsActivScheduler
    End Function

    ''' <summary>
    ''' Speichert geänderte Daten ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveData(ByVal apList As AppointmentBaseCollection)
        System.Diagnostics.Debug.Print("Speichere Termin...")


        If IsActive() Then

            m_application.Appointments.Save()

            m_application.AppointmentResources.Save()

            m_application.SendMessage(GetText("msgSchedulerUpdated", "Termin gesichert"))
        Else
            ' Lizenz sowas von abgelaufen !
            m_application.SendMessage(GetText("msgschedulerLicenceexpired", "Termin kann nicht gespeichert werden. Keine Terminkalender-Lizenz vorhanden"))
        End If

    End Sub

    ''' <summary>
    ''' Läd die Datenbank neu ein / übernimmt änderungen der andern Benutzer
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OnReloadAppointments()
        Static res As IAsyncResult
        If res IsNot Nothing AndAlso Not res.IsCompleted Then Exit Sub
        res = Me.BeginInvoke(New delReloadData(AddressOf ReloadData))
    End Sub

    Delegate Sub delReloadData()


    Public Sub DeleteData(ByVal apList As AppointmentBaseCollection)


        System.Diagnostics.Debug.Print(CStr(apList.Count))

    End Sub

    Private Sub SchedulerStorage1_AppointmentsChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerStorage1.AppointmentsChanged
        SaveData(CType(e.Objects, AppointmentBaseCollection))

    End Sub

    Private Sub SchedulerStorage1_AppointmentsDeleted(ByVal sender As System.Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerStorage1.AppointmentsDeleted
        ' SaveData(CType(e.Objects, AppointmentBaseCollection))
        DeleteData(CType(e.Objects, AppointmentBaseCollection))
    End Sub

    Private Sub SchedulerStorage1_AppointmentsInserted(ByVal sender As System.Object, ByVal e As DevExpress.XtraScheduler.PersistentObjectsEventArgs) Handles SchedulerStorage1.AppointmentsInserted
        SaveData(CType(e.Objects, AppointmentBaseCollection))

    End Sub

    ''' <summary>
    ''' Zeigt die aktuelle Ansicht zum drucken an
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowPrintPreview()


        SchedulerControl1.ShowPrintPreview()
    End Sub


    Public Sub ShowPrintOptionsMenue()

    End Sub

    ''' <summary>
    ''' Speichert das schema des Schedulers
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveSchedulerLayout()
        Using m As New System.IO.MemoryStream

            SchedulerControl1.SaveLayoutToStream(m)

            m_application.Settings.SetSetting("Scheduler_Layout", "Layout", m, m_application.CurrentUser.Key)
            m.Close()
        End Using

    End Sub

    ''' <summary>
    ''' Führt Aktionen beim Benutzergesteuerten Schliessen aus
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        SaveSchedulerLayout()

        Return True
    End Function

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return GetText("Scheduler", "Termine")
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Friend Sub LoadCurrentItem(ByVal currentItem As ClausSoftware.Data.StaticItem)

    End Sub

    Public Sub NewItem() Implements IModule.CreateNewItem

    End Sub

    Public Overrides Sub Print() Implements IModule.Print
        SchedulerControl1.ShowPrintOptionsForm()
    End Sub

    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

    End Sub

    Friend Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnPrint
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule
        Initialize()
    End Sub

    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            Throw New NotImplementedException("Aktives Element kann nicht zurückgegeben werden")
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem

    End Sub

    ''' <summary>
    ''' Läd alle Daten aus der Datenquelle neu ein
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub ReloadData()
        If Not SchedulerControl1.IsUpdateLocked Then
            m_application.Appointments.Reload()
            SchedulerControl1.RefreshData()
        End If

    End Sub

    Private Sub iucScheduler_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        '   ReloadData()
    End Sub

    Private Sub SchedulerControl1_ActiveViewChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SchedulerControl1.ActiveViewChanged
        SaveSchedulerLayout()
    End Sub


    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Public Sub New(ByVal myUI As mainUI)
        MyBase.New(myUI)
        InitializeComponent()

    End Sub

    ''' <summary>
    ''' Ruft das kleine symbolbild für dieses Modul ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get
            Return My.Resources.Calendar2Events_16x16
        End Get
    End Property


    ''' <summary>
    ''' Hole Outlook-Pfade
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property OutlookCalendarPaths() As String()
        Get

            Try

                outlookPaths = OutlookExchangeHelper.GetOutlookCalendarPaths()
            Catch
                Debug.Print("get the list of available calendars from Microsoft Outlook")
                outlookPaths = New String() {}
            End Try
            Return outlookPaths
        End Get
    End Property

    ''' <summary>
    ''' Name des Outlook Kalener
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property CalendarName() As String
        Get

            Dim setting As String = m_application.Settings.GetSetting("OutlookPath", "Sync")
            If String.IsNullOrEmpty(setting) Then
                setting = OutlookCalendarPaths(0)

                m_application.Settings.SetSetting("OutlookPath", "Sync", setting)
            End If

            Return setting

        End Get
    End Property


    Private m_isInsync As Boolean

    ''' <summary>
    ''' Zeigt an, das gerade Synchronisiert wird und kein Save ausgeführt werden soll
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsInSync() As Boolean
        Get
            Return m_isInsync
        End Get

    End Property


    ''' <summary>
    ''' Synchronisiert mir Outlook
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SyncToOL()
        Try
            ' export
            m_application.Log.WriteLog("Start Calender Exported to Outlook...")

            Dim expSynchronizer As AppointmentExportSynchronizer = SchedulerStorage1.CreateOutlookExportSynchronizer()

            TryCast(expSynchronizer, ISupportCalendarFolders).CalendarFolderName = CalendarName

            expSynchronizer.ForeignIdFieldName = "OutlookEntryID"
            AddHandler expSynchronizer.AppointmentSynchronizing, AddressOf ExportAppointments
            AddHandler expSynchronizer.AppointmentSynchronized, AddressOf synchronizer_AppointmentSynchronized


            Try
                m_isInsync = True
                expSynchronizer.Synchronize()
                m_application.SendMessage("Kalender nach Outlook exportiert") 'TODO:NLS

            Finally
                m_application.Log.WriteLog("Calender Exported to Outlook")

                RemoveHandler expSynchronizer.AppointmentSynchronizing, AddressOf ExportAppointments
                RemoveHandler expSynchronizer.AppointmentSynchronized, AddressOf synchronizer_AppointmentSynchronized

                m_isInsync = False
            End Try
        Catch ex As Exception
            m_application.Log.WriteLog(ex, "Outlook Importer", "Fehler beim Export nach Outlook")
        End Try



    End Sub

    Private Sub SyncFromOL()
        Try
            m_application.Log.WriteLog("Start Outlook Calender Import...")

            Dim synchronizer As AppointmentImportSynchronizer = SchedulerStorage1.CreateOutlookImportSynchronizer()

            TryCast(synchronizer, ISupportCalendarFolders).CalendarFolderName = CalendarName

            synchronizer.ForeignIdFieldName = "OutlookEntryID"
            AddHandler synchronizer.AppointmentSynchronizing, AddressOf ImportAppointments
            AddHandler synchronizer.AppointmentSynchronized, AddressOf synchronizer_AppointmentSynchronized

            Dim oldCur As Cursor = Windows.Forms.Cursor.Current
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            Try
                m_isInsync = True
                synchronizer.Synchronize()
                m_application.SendMessage("Outlook Kalender geladen") 'TODO:NLS
            Finally
                m_isInsync = False

                RemoveHandler synchronizer.AppointmentSynchronizing, AddressOf ImportAppointments
                RemoveHandler synchronizer.AppointmentSynchronized, AddressOf synchronizer_AppointmentSynchronized
                m_application.Log.WriteLog("Outlook Calender Imported")
            End Try
        Catch ex As Exception

            m_application.Log.WriteLog(ex, "Outlook Importer", "Fehler beim Import von Outlook")
        End Try



    End Sub

    Private Sub synchronizer_AppointmentSynchronized(ByVal sender As Object, ByVal e As AppointmentSynchronizedEventArgs)

    End Sub

    Private Sub ImportAppointments(ByVal sender As Object, ByVal e As AppointmentSynchronizingEventArgs)
        Dim ol As OutlookAppointmentSynchronizingEventArgs = CType(e, OutlookAppointmentSynchronizingEventArgs)
        If e.Operation = SynchronizeOperation.Delete Then e.Cancel = True
        If Not ol.OutlookAppointment Is Nothing Then
            If ol.OutlookAppointment.LastModificationTime < CType(ol.Appointment.CustomFields("LastModificationTime"), Date) Then
                e.Cancel = True
            End If
        End If


    End Sub
    Private Sub ExportAppointments(ByVal sender As Object, ByVal e As AppointmentSynchronizingEventArgs)
        'Debug.Print(e.Appointment.Description)

        Dim ol As OutlookAppointmentSynchronizingEventArgs = CType(e, OutlookAppointmentSynchronizingEventArgs)
        If e.Operation = SynchronizeOperation.Delete Then e.Cancel = True
        If Not ol.OutlookAppointment Is Nothing Then
            If ol.OutlookAppointment.LastModificationTime > CType(ol.Appointment.CustomFields("LastModificationTime"), Date) Then
                '   e.Cancel = True
            End If
        End If

    End Sub


    Private Sub btnImportFromOutlook_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImportFromOutlook.ItemClick
        SyncFromOL()
    End Sub

    Private Sub btnExportToOutlook_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExportToOutlook.ItemClick
        SyncToOL()
    End Sub

    Private Sub btnReload_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReload.ItemClick
        Me.OnReloadAppointments()
    End Sub
End Class