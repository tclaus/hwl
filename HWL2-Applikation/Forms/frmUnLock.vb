Public Class frmUnLock 


    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnUnlock.Click
        Me.Hide()

    End Sub

    Private Sub frmUnLock_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)
    End Sub

    Private Sub frmUnLock_FormClosing(ByVal sender As System.Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then ' Sollte nicht das Runterfahren verhindern.. 
            e.Cancel = True
        End If
    End Sub
End Class