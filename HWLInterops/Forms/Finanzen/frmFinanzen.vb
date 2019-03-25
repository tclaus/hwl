''' <summary>
''' Stellt eine Portalseite dar, um einen schnellen Finanzüberblick zu erhalten
''' </summary>
''' <remarks></remarks>
Public Class frmFinanzen

    Private Sub btnCashFlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashFlow.Click

        Try
            Dim frm As New frmStaticSituation
            frm.ShowDialog()
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "CashFlow_StaticSituation", "Error while opening Static Situation")
        End Try

    End Sub

    Private Sub frmFinanzen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

    End Sub
End Class