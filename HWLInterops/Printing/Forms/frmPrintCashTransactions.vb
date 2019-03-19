Imports ClausSoftware.Kernel
Imports DevExpress.XtraBars

Namespace Printing
    ''' <summary>
    ''' Stellt einen Drucken-Dialog für das Kasenbuch bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class frmPrintCashTransactions
        Private m_currentGrid As DevExpress.XtraGrid.GridControl
        Private m_dataSourceType As DataSourceList
        Private m_cashItems As Kernel.CashJournalItems = CType(m_application.CashJournal.GetNewCollection, CashJournalItems)

        Private m_monthyCashSheet As String = GetText("btnMonthyCashsheet", "Kassenblatt")

        Dim lstMonthlyReport As New List(Of Kernel.Printing.Report)
        Dim lstYearReport As New List(Of Kernel.Printing.Report)


        ''' <summary>
        ''' Ruft den Datentype ab oder legt diesen fest. 
        ''' Damit kann später ein Layout wieder einer Datenquelle zugewiesen werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataSourceType() As DataSourceList
            Get
                Return m_dataSourceType
            End Get
            Set(ByVal value As DataSourceList)
                m_dataSourceType = value
            End Set
        End Property
        ''' <summary>
        ''' Ruft das Grid ab, das die aktuellen Datensätze enthält. Damit kann ein einfacher Listendruck umgesetzt werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Grid() As DevExpress.XtraGrid.GridControl
            Get
                Return m_currentGrid
            End Get
            Set(ByVal value As DevExpress.XtraGrid.GridControl)
                m_currentGrid = value
            End Set
        End Property

        Private Sub frmPrintCashAccounts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            ' Jahreszahlen vom Kassenbuch ermitteln
            cobYears.Properties.Items.AddRange(m_application.CashJournal.GetItemYears)

            If cobYears.Properties.Items.Count > 0 Then ' Wenn ein Jahr da ist,  dann dieses auch markieren
                cobYears.SelectedItem = cobYears.Properties.Items(0)
            End If

            CheckSelectedYearItem()

            m_application.Languages.SetTextOnControl(Me)

            btnPrintCashMonthly.Tag = Now.Month  ' aktuellen Monat sichern

            btnPrintCashMonthly.Text = Now.ToString("MMMM")

            Dim reps As New Kernel.Printing.Reports(m_application)
            ' Monatliche Reports
            reps.SetDataType(DataSourceList.CashJournalMonthy)
            lstMonthlyReport.Add(reps.GetDefaultReportLayout)

            'Jährliche Reports
            reps.SetDataType(DataSourceList.CashJournalYearly)
            lstYearReport.Add(reps.GetDefaultReportLayout)

        End Sub


        ''' <summary>
        ''' Ruft ein Kassenbuch-Monatsblatt ab 
        ''' </summary>
        ''' <param name="year"></param>
        ''' <param name="month"></param>
        ''' <remarks></remarks>
        Private Sub PrintMonthyRecord(ByVal year As Integer, ByVal month As Integer)
            m_application.SendMessage(GetText("msgOpeningPagePreview", "Öffne Seiten-Vorschau..."))

            Dim StartDate As Date = New Date(year, month, 1)

            Dim EndDate As Date = StartDate.AddMonths(1).AddDays(-1) ' Letzer Tag im Monat ermitteln

            Dim journalData As Kernel.CashJournalTimeFrame = m_application.CashJournalTimeFrame.GetCashJournalTimeFrame(StartDate, EndDate)
            Dim dataList As New List(Of CashJournalTimeFrame)

            dataList.Add(journalData)

            mainControlContainer.MainUI.OpenReportPreview(dataList, DataSourceList.CashJournalMonthy, lstMonthlyReport)

        End Sub

        ''' <summary>
        ''' Druckt eine Auflistung der Kassenbucheinträge Quartalsweise
        ''' </summary>
        ''' <param name="year"></param>
        ''' <param name="quartalNumber"></param>
        ''' <remarks></remarks>
        Private Sub PrintQuartalRecord(ByVal year As Integer, ByVal quartalNumber As Integer)
            m_application.SendMessage(GetText("msgOpeningPagePreview", "Öffne Seiten-Vorschau..."))

            ' Das Quartal dieses Jahres ermitteln
            Dim StartDate As Date = Date.Today
            Dim EndDate As Date

            StartDate = New Date(Today.Year, (quartalNumber - 1) * 3 + 1, 1)
            EndDate = StartDate.AddMonths(3).AddDays(-1)


            Dim journalData As Kernel.CashJournalTimeFrame = m_application.CashJournalTimeFrame.GetCashJournalTimeFrame(StartDate, EndDate)
            Dim dataList As New List(Of CashJournalTimeFrame)

            dataList.Add(journalData)

            mainControlContainer.MainUI.OpenReportPreview(dataList, DataSourceList.CashJournalMonthy, lstMonthlyReport)

        End Sub


        ''' <summary>
        ''' Jahresübersicht ermitteln
        ''' </summary>
        ''' <param name="year"></param>
        ''' <remarks></remarks>
        Private Sub PrintYearRecord(ByVal year As Integer)
            m_application.SendMessage(GetText("msgOpeningPagePreview", "Öffne Seiten-Vorschau..."))



            ' Das angegebebne Jahr übergeben
            Dim journalData As Kernel.CashJournalTimeFrame = m_application.CashJournalTimeFrame.GetCashJournalTimeFrame(New Date(year, 1, 1), New Date(year, 12, 31))
            Dim dataList As New List(Of CashJournalTimeFrame)

            dataList.Add(journalData)

            mainControlContainer.MainUI.OpenReportPreview(dataList, DataSourceList.CashJournalYearly, lstYearReport)

        End Sub

        Private Sub btnPrintLists_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLists.Click
            Grid.ShowPrintPreview()
        End Sub

        Private Sub btnPrintCashYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintCashYear.Click
            PrintYearRecord(CInt(cobYears.SelectedItem))
        End Sub

        Private Sub btnPrintCashMonthly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintCashMonthly.Click
            Dim itemTag As Integer
            If TypeOf e Is ItemClickEventArgs Then
                itemTag = CInt(CType(e, ItemClickEventArgs).Item.Tag)
            Else
                itemTag = CInt(btnPrintCashMonthly.Tag)
            End If
            PrintMonthyRecord(CInt(cobYears.SelectedItem), itemTag)
        End Sub

        Private Sub btnPrintCashMonthly_ShowDropDownControl(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.ShowDropDownControlEventArgs) Handles btnPrintCashMonthly.ShowDropDownControl
            m_cashItems.StartDate = New Date(CInt(cobYears.SelectedItem), 1, 1)
            m_cashItems.EndDate = New Date(CInt(cobYears.SelectedItem), 12, 31)
            m_cashItems.SetDateCriteria()

            Dim months As New List(Of Integer)

            'For Each item As CashJournalItem In m_cashItems
            '    If Not months.Contains(item.TransactionDate.Month) Then
            '        months.Add(item.TransactionDate.Month)
            '    End If

            'Next
            pumMonthNames.ItemLinks.Clear()
            ' Falls in einem MOnat keine Umsätze gemacht wurden, dann diese auch als "Keine Umsätze" ausweisen.
            For n As Integer = 1 To 12
                Dim d As New Date(Now.Year, n, 1)
                d.ToString("MMMM")
                Dim mbutton As New BarButtonItem
                mbutton.Caption = d.ToString("MMMM")
                mbutton.Tag = d.Month ' Die Nummer des Monats ermitteln
                AddHandler mbutton.ItemClick, AddressOf btnPrintCashMonthly_Click
                pumMonthNames.AddItem(mbutton)
            Next


        End Sub

      

        Private Sub cobYears_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobYears.SelectedIndexChanged
            ' wenn gewechselt wird, dann immer auf "Januar" schalten

            CheckSelectedYearItem()

            btnPrintCashMonthly.Text = m_monthyCashSheet & " (" & New Date(CInt(cobYears.SelectedItem), 1, 1).ToString("MMMM") & ")"
            btnPrintCashMonthly.Tag = Now.Month

        End Sub

        Private Sub btnSchliessen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub CheckSelectedYearItem()
            If cobYears.SelectedItem Is Nothing Then
                btnPrintCashMonthly.Enabled = False
                btnPrintCashYear.Enabled = False
            Else
                btnPrintCashMonthly.Enabled = True
                btnPrintCashYear.Enabled = True
            End If
        End Sub

        Private Sub btnPrintCashByQuarter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintCashByQuarter.Click
            Dim itemTag As Integer
            If TypeOf e Is ItemClickEventArgs Then
                itemTag = CInt(CType(e, ItemClickEventArgs).Item.Tag)
            Else
                itemTag = CInt(btnPrintCashByQuarter.Tag)
            End If

            If CInt(itemTag) = 0 Then ' Dieses Quartal
                Select Case Today.Month
                    Case 1 To 3 : itemTag = 1
                    Case 4 To 6 : itemTag = 2
                    Case 7 To 9 : itemTag = 3
                    Case 10 To 12 : itemTag = 4

                End Select
            End If

            PrintQuartalRecord(CInt(cobYears.SelectedItem), itemTag)

        End Sub

        Private Sub btnPrintCashByQuarter_ShowDropDownControl(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.ShowDropDownControlEventArgs) Handles btnPrintCashByQuarter.ShowDropDownControl
            If pumQuartals.ItemLinks.Count = 0 Then


                ' Falls in einem Monat keine Umsätze gemacht wurden, dann diese auch als "Keine Umsätze" ausweisen.
                For n As Integer = 1 To 4

                    Dim mbutton As New BarButtonItem
                    mbutton.Caption = n & " " & GetText("quarter", "Quartal")
                    mbutton.Tag = n
                    AddHandler mbutton.ItemClick, AddressOf btnPrintCashByQuarter_Click
                    pumQuartals.AddItem(mbutton)
                Next

            End If
        End Sub
    End Class
End Namespace
