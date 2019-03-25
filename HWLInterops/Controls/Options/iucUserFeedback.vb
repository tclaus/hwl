''' <summary>
''' Automatische Rückmeldung der software per Web-Interface, stellt eine Benutzerabfrage zur Verfügung
''' </summary>
''' <remarks></remarks>
Public Class iucUserFeedback
    Implements IOptionMenue

    'Please enter any new code here, below the Interop code


    Public Sub Initialize() Implements IOptionMenue.Initialize
        modmain.InitializeApplication()
        chkqualicheck.Checked = MainApplication.getInstance.Settings.SettingSendStatistics
    End Sub

    Public Sub Reload() Implements IOptionMenue.Reload

    End Sub

    Public Sub Save() Implements IOptionMenue.Save

    End Sub


    Private Sub chkqualicheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkqualicheck.CheckedChanged
        MainApplication.getInstance.Settings.SettingSendStatistics = chkqualicheck.Checked
    End Sub
    Public Overrides Function ToString() As String
        Return Me.DisplayName
    End Function

    Public ReadOnly Property DisplayName() As String Implements IOptionMenue.DisplayName
        Get
            Return GetText("moduleCustomerQualityFeedback", "Qualitätssicherung")
        End Get

    End Property

    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False
        End Get
    End Property
End Class