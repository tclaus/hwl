Public Class frmTaxSummary 

    Private Sub frmTaxSummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim years As New List(Of Integer)


        For Each item As String In MainApplication.getInstance.Transactions.GetItemYears
            If Not years.Contains(CInt(item)) Then
                years.Add(CInt(item))

            End If
        Next

        For Each item As String In MainApplication.getInstance.CashJournal.GetItemYears
            If Not years.Contains(CInt(item)) Then
                years.Add(CInt(item))

            End If
        Next

        cobTimeFrame.Properties.Items.Clear()
        cobTimeFrame.Properties.Items.AddRange(years)
        cobTimeFrame.Properties.Sorted = True

    End Sub
End Class