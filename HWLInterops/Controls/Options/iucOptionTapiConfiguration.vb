''' <summary>
''' stellt Optionen für eine Telefonie-schnittstelle bereit
''' </summary>
''' <remarks></remarks>
Public Class iucOptionTapiConfiguration
    Implements IOptionMenue


    Private m_mainUI As MainUI


    Public Sub Initialize() Implements IOptionMenue.Initialize
        chkMonitorCAPIDevices.Checked = MainApplication.getInstance.Settings.MonitorPhoneLines
    End Sub

    Public Sub Reload() Implements IOptionMenue.Reload
        MainApplication.getInstance.Settings.MonitorPhoneLinesReload()
        chkMonitorCAPIDevices.Checked = MainApplication.getInstance.Settings.MonitorPhoneLines

    End Sub

    Public Sub Save() Implements IOptionMenue.Save

        ' Phone: ein / Ausschalten
        MainApplication.getInstance.Settings.MonitorPhoneLines = chkMonitorCAPIDevices.Checked
        m_mainUI.Telephony.MonitorPhoneLines = chkMonitorCAPIDevices.Checked
    End Sub

    Public Overrides Function ToString() As String
        Return Me.DisplayName
    End Function

    Public ReadOnly Property DisplayName() As String Implements IOptionMenue.DisplayName
        Get
            Return GetText("optionPhonemonitoring", "Telefonie")
        End Get

    End Property

    Private Sub iucOptionTapiConfiguration_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

    End Sub

    Public Sub New(ByVal mainUI As MainUI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_mainUI = mainUI
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False

        End Get
    End Property
End Class