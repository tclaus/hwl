''' <summary>
''' Enthält eine statische Finazübersicht über ein wählbares Geschäftsjahr
''' </summary>
''' <remarks></remarks>
Public Class frmStaticSituation

    Sub FillValues(ByVal year As Integer)
        ' Barbestand aus Kasse

        Dim startDate As Date
        Dim endDate As Date

        If year <> 0 Then
            startDate = New Date(year, 1, 1)
            endDate = New Date(year, 12, 31)

            m_application.Transactions.Criteria = New DevExpress.Data.Filtering.BetweenOperator("ItemDate", startDate, endDate)
            m_application.CashJournal.Criteria = New DevExpress.Data.Filtering.BetweenOperator("TransactionDate", startDate, endDate)

        Else
            m_application.CashJournal.Criteria = Nothing
            m_application.Transactions.Criteria = Nothing
        End If

        Dim transactionSums As Kernel.TransactionSum = m_application.Transactions.SumAmmount

        Dim totalCash, bankValue, openReceiveables, openPayables, totalMoney, storeValue As Decimal
        totalCash = m_application.CashJournal.GetCashAfterThis
        bankValue = (transactionSums.PaidAmmountInbound - transactionSums.PaidAmmountOutbound)
        openReceiveables = transactionSums.UnpaidAmmountInbound
        openPayables = transactionSums.UnpaidAmmountOutbound


        lblCash.Text = totalCash.ToString("C") ' Bargeld (aus Kasse)
        lblBank.Text = bankValue.ToString("C") ' Kontostand (aus Forderungen / Verbindlichkeiten)
        lblLiquidMoney.Text = (totalCash + bankValue).ToString("C") ' Liquide Mittel
        '-----------------
        lblReveiceables.Text = openReceiveables.ToString("C")
        lblPayables.Text = openPayables.ToString("C")

        totalMoney = (totalCash + bankValue) + (openReceiveables - openPayables)
        lblMonetaryAssets.Text = totalMoney.ToString("C") ' Geldvermögen, wenn noch alles gezahlt wird

        lblStoreAmmount.Text = storeValue.ToString("C")  ' Lagerbestand... 
        'TODO: Lagerbestand ermitteln... 

        lblNetworth.Text = (totalMoney + storeValue).ToString("C")
    End Sub

    Private Sub frmStaticSituation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Languages.SetTextOnControl(Me)

        FillValues(0)

        Dim years As New List(Of Integer)


        For Each item As String In m_application.Transactions.GetItemYears
            If Not years.Contains(CInt(item)) Then
                years.Add(CInt(item))

            End If
        Next

        For Each item As String In m_application.CashJournal.GetItemYears
            If Not years.Contains(CInt(item)) Then
                years.Add(CInt(item))

            End If
        Next

        cobYears.Properties.Items.Clear()
        cobYears.Properties.Items.AddRange(years)
        cobYears.Properties.Sorted = True

    End Sub


    Private Sub ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStoreAmmount.TextChanged, lblReveiceables.TextChanged, lblPayables.TextChanged, lblNetworth.TextChanged, lblMonetaryAssets.TextChanged, lblLiquidMoney.TextChanged, lblCash.TextChanged, lblBank.TextChanged
        Dim lbl As DevExpress.XtraEditors.LabelControl = CType(sender, DevExpress.XtraEditors.LabelControl)
        If CDec(lbl.Text) < 0 Then
            lbl.ForeColor = Color.Red
        Else
            lbl.ForeColor = Color.Black

        End If
    End Sub



    Private Sub cobYears_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobYears.SelectedIndexChanged
        FillValues(CInt(cobYears.SelectedItem))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class