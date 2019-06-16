Public Class frmStatistics 

    Private Sub IucStatistics1_Close() Handles IucStatistics1.Close
        Me.Close()
    End Sub

    Private Sub frmStatistics_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MainApplication.getInstance.Settings.SaveFormsPos(Me)
    End Sub

    Private Sub frmStatistics_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Settings.RestoreFormsPos(Me)
        MainApplication.getInstance.Languages.SetTextOnControl(Me)
    End Sub



    Private Sub frmStatistics_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class