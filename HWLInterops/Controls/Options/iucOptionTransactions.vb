Public Class iucOptionTransactions
    Implements IOptionMenue


    ''' <summary>
    ''' Ruft die Überschrift dieses Optionsfensters ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayName As String Implements IOptionMenue.DisplayName
        Get
            Return GetText("headlineOptionTransaction", "Forderungen / Verbindlichkeiten")
        End Get
    End Property

    Public Sub Initialize() Implements IOptionMenue.Initialize
        Reload()
    End Sub

    ''' <summary>
    ''' Ist wahr, wenn eine Ändeurung dieser Einstellung nur durch einen Neustart aktiviert werden kann
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False
        End Get
    End Property

    Public Sub Reload() Implements IOptionMenue.Reload

        chksendNoticeUnpaidTransactions.Checked = MainApplication.getInstance.Settings.TransactionSettings.SendUnpaidNoticeOnStartup

    End Sub


    Public Sub Save() Implements IOptionMenue.Save

        MainApplication.getInstance.Settings.TransactionSettings.SendUnpaidNoticeOnStartup = chksendNoticeUnpaidTransactions.Checked
    End Sub

    Private Sub chksendNoticeUnpaidTransactions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chksendNoticeUnpaidTransactions.CheckedChanged

        SetTimeFrame(chksendNoticeUnpaidTransactions.Checked)

    End Sub

    ''' <summary>
    ''' Schaltet die Zeitdauer der Benachrichtigung ein oder aus
    ''' </summary>
    ''' <param name="enabled"></param>
    ''' <remarks></remarks>
    Private Sub SetTimeFrame(ByVal enabled As Boolean)
        lblMonthNotice.Enabled = enabled
        lblReceiveablesOfTheLast.Enabled = enabled
        speMonths.Enabled = enabled

    End Sub


    Private Sub iucOptionTransactions_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)
    End Sub
End Class
