
''' <summary>
''' Wenn HWL auf einer leeren Datenbank gestartet wird, wird dieser Dialog aufgrufen, wenn die Steuersätze nicht aufgefüllt ind
''' </summary>
''' <remarks></remarks>
Public Class frmRepairTaxes



    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub frmRepairTaxes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

    End Sub


End Class