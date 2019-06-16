Imports ClausSoftware.Kernel

Public Class frmSetDocumentsTax

    Private Sub cmdProceed_Click(sender As System.Object, e As System.EventArgs) Handles cmdProceed.Click
        StartSetTaxRates()
    End Sub

    Private Sub StartSetTaxRates()
        Dim result As DialogResult
        result = MessageBox.Show("Steuersätze ALLER Dokumente ab dem angegebenen Jahr angleichen? ", "Steuersätze angleichen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = Windows.Forms.DialogResult.Yes Then

            Dim targetDate As DateTime = New Date(CInt(txtYear.EditValue), 1, 1)
            Dim newTaxRate As TaxRate = CType(cobTaxRate.SelectedItem, TaxRate)

            Dim MaxCount As Integer = MainApplication.getInstance.JournalDocuments.Count
            Dim currentCount As Integer = 0

            For Each item As JournalDocument In MainApplication.getInstance.JournalDocuments
                Try
                    If item.DocumentDate > targetDate Then
                        For Each Group As JournalArticleGroup In item.ArticleGroups
                            For Each Article As JournalArticleItem In Group.ArticleList
                                If Article.TaxRate IsNot Nothing Then

                                    If Article.TaxRate.TaxValue <> 0 Then
                                        Article.TaxRate = newTaxRate
                                        Article.Save()
                                    End If

                                End If
                            Next
                        Next
                    End If
                Catch ex As Exception

                End Try

                currentCount += 1
                lblProgress.Text = currentCount & "/" & MaxCount
                lblProgress.Refresh()
            Next


        End If


    End Sub

    Private Sub frmSetDocumentsTax_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        For Each TaxRate As TaxRate In MainApplication.getInstance.TaxRates
            ' Nur nicht Leere Steuern zulassen
            If TaxRate.TaxValue > 0 Then
                cobTaxRate.Properties.Items.Add(TaxRate)
            End If
        Next


        txtYear.Text = "2007"
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class