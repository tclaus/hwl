Imports DevExpress.Xpo
Imports ClausSoftware.Tools
Imports System.Data

Public Class iucStatistics
    Implements IModule

    Private licenseGUID As String = "{BB935192-42EE-4798-B6AA-15206FCC711E}"

    Private m_licenseItem As New ClausSoftware.Data.LicenseItem("Statistics", licenseGUID)


    'Please enter any new code here, below the Interop code
    Private ConstTableItems As String = ClausSoftware.Kernel.JournalArticleItem.TableName
    Private ConstTableJournal As String = ClausSoftware.Kernel.JournalDocument.Tablename
    Private isLoading As Boolean = True

    Public Event Close()


    Private Enum enumStats
        BestCustomer
        BestArticles
        BestVolumes
    End Enum

    Private m_selectedDataSource As enumStats

    ''' <summary>
    ''' Setzt den Gesamtbetrag 
    ''' </summary>
    ''' <param name="sumValue"></param>
    ''' <remarks></remarks>
    Private Sub SetSum(ByVal sumValue As Decimal)
        lblSumValue.Text = sumValue.ToString("c2")
    End Sub

    Private Sub SetCount(ByVal countValue As Decimal)
        lblCountValue.Text = countValue.ToString
    End Sub



    Private Sub RunBestCustomers()
        ' Beste Kunden ( anzahl Rechnung, Rechnungsbetrag)


    End Sub

    ''' <summary>
    ''' enthält das Anfangs- und endjahr ind em Rechnungen geschrieben wurden
    ''' </summary>
    ''' <remarks></remarks>
    Class YearMinMax
        Public MinYear As Integer
        Public MaxYear As Integer

    End Class

    ''' <summary>
    ''' Ruft die Jahre ab, in denen Rechnungen geschrieben wurden
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetInvoiceYears() As YearMinMax
        Dim sql As String
        Dim dt As DataTable
        Dim years As New YearMinMax

        If DbType() = enumServerType.MySQL Then
            sql = "SELECT year(AngelegtAm) FROM JournalListe group by year(AngelegtAm)"
            dt = m_application.Database.GetData(sql)
        Else
            sql = "SELECT year(AngelegtAm) FROM JournalListe group by year(AngelegtAm)"
            dt = m_application.Database.GetData(sql)
        End If

        ' Initialisieren
        years.MinYear = Date.Today.Year
        years.MaxYear = Date.Today.Year

        For Each row As DataRow In dt.Rows
            If Not TypeOf row(0) Is DBNull Then
                years.MinYear = Math.Min(years.MinYear, CInt(row(0)))
                years.MaxYear = Math.Max(years.MaxYear, CInt(row(0)))
            End If
        Next

        spYears.Properties.MinValue = years.MinYear
        spYears.Properties.MaxValue = years.MaxYear
        Return years

    End Function

    Private Sub BestItems()
        ' Beste Kunden ( anzahl Rechnung, Rechnungsbetrag)
        Dim sql As String
        Dim sqlSumme As String
        Dim OrderBySumme As String
        Dim GroupBy As String
        Dim startdate As Date = datStartDate.DateTime
        Dim endDate As Date = datEndDate.DateTime

        If DbType() = enumServerType.MySQL Then
            OrderBySumme = "Summe"
            GroupBy = "OrgItem"
        Else
            OrderBySumme = "Summe" '"round( sum(I.VK*(1+J.Mwstwert/100)),2)"
            GroupBy = "I.Name"
        End If
        Dim freeText As String = GetText("freeTextWithoutItem", "-Freier Text ohne Artikel-")

        If chkAllTimeStatistics.Checked = False Then

            sql = "select SUM(I.Anzahl * P.Anzahl) as Anzahl  ,round( sum(I.Anzahl * P.Anzahl*I.VK*(1+J.Mwstwert/100)),2) as Summe, i.Name from " & ConstTableItems & " I, " & ConstTableJournal & " J, positions p where i.parentItemID = P.ReplikID and  I.status=2 and J.status=I.status and J.lfndnummer = I.lfndnummer and J.datum between " & ConvertDate2SqlString(datStartDate.DateTime) & " and " & ConvertDate2SqlString(datEndDate.DateTime) & "  AND OrgItem <>'T' group by " & GroupBy & " " & _
            "UNION SELECT SUM(I.Anzahl * P.Anzahl) as Anzahl  ,round( sum(I.Anzahl * P.Anzahl*I.VK*(1+J.Mwstwert/100)),2) as Summe, '" & freeText & "' as Name from " & ConstTableItems & " I, " & ConstTableJournal & " J ,  positions p where i.parentItemID = P.ReplikID and  I.status=2 and J.status=I.status and J.lfndnummer = I.lfndnummer and J.datum between " & ConvertDate2SqlString(datStartDate.DateTime) & " and " & ConvertDate2SqlString(datEndDate.DateTime) & "  AND I.OrgItem='T' group by " & GroupBy & " order by " & OrderBySumme & " desc "
        Else
            sql = "select SUM(I.Anzahl * P.Anzahl) as Anzahl ,round( sum(P.Anzahl*I.Anzahl*I.VK*(1+J.Mwstwert/100)),2) as Summe, i.Name from " & ConstTableItems & " I, " & ConstTableJournal & " J, positions p where i.parentItemID = P.ReplikID and  I.status=2 and J.status=I.status and J.lfndnummer = I.lfndnummer AND OrgItem <>'T' group by " & GroupBy & " " & _
              "UNION SELECT SUM(I.Anzahl * P.Anzahl) as Anzahl  ,round( sum(I.Anzahl * P.Anzahl*I.VK*(1+J.Mwstwert/100)),2) as Summe, '" & freeText & "' as Name from " & ConstTableItems & " I, " & ConstTableJournal & " J , positions p where i.parentItemID = P.ReplikID and  I.status=2 and J.status=I.status and J.lfndnummer = I.lfndnummer and  I.OrgItem='T' group by " & GroupBy & " order by " & OrderBySumme & " desc "

        End If

        Dim dt As DataTable = m_application.Database.GetData(sql)
        'TODO: Spalten übersetzen 
        'Testen: Spaltenübersetzung
        For Each col As System.Data.DataColumn In dt.Columns
            col.Caption = GetText(col.ColumnName)
        Next

        grdMain.DataSource = dt

        On Error Resume Next

    End Sub

    Private Sub BestCustomers()

        Dim sql As String
        Dim sqlSumme As String
        Dim OrderBySumme As String

        Dim startdate As Date = datStartDate.DateTime
        Dim endDate As Date = datEndDate.DateTime

        If DbType() = enumServerType.MySQL Then

            OrderBySumme = "Summe"
        Else
            OrderBySumme = "sum(betrag)"
        End If


        If chkAllTimeStatistics.Checked = False Then

            sql = "select count(*) as Anzahl,round( sum(betrag),2) as Summe, Adressfenster as Name from " & ConstTableJournal & " J where J.status=2 and datum between " & ConvertDate2SqlString(startdate) & " and " & ConvertDate2SqlString(endDate) & "  group by Adressfenster order by " & OrderBySumme & "  desc "
            sqlSumme = "select count(*) as anzahl, round(sum(betrag),2) as summe from " & ConstTableJournal & " J where J.status=2 and datum between " & ConvertDate2SqlString(startdate) & " and " & ConvertDate2SqlString(endDate)

        Else
            sql = "select count(*) as Anzahl,round( sum(betrag),2) as Summe, Adressfenster as Name from " & ConstTableJournal & " J where J.status=2  group by Adressfenster order by " & OrderBySumme & "  desc "
            sqlSumme = "select count(*) as anzahl, round(sum(betrag),2) as summe from " & ConstTableJournal & " J where J.status=2 "
        End If

        Dim dt As DataTable = m_application.Database.GetData(sql)

        grdMain.DataSource = dt


    End Sub

    Private Sub chkAllTimeStatistics_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllTimeStatistics.CheckedChanged
        Dim value As Boolean = chkAllTimeStatistics.Checked

        value = Not value

        lblstartDate.Enabled = value
        lblendDate.Enabled = value
        datStartDate.Enabled = value
        datEndDate.Enabled = value
        spYears.Enabled = value

        CreateStats(m_selectedDataSource)

    End Sub

    ''' <summary>
    ''' Erstellt die statistiken für ein angegebenes Wert
    ''' </summary>
    ''' <param name="kind"></param>
    ''' <remarks></remarks>
    Private Sub CreateStats(ByVal kind As enumStats)
        If m_application IsNot Nothing Then
            If isLoading Then Exit Sub
            m_selectedDataSource = kind

            Select Case kind
                Case enumStats.BestCustomer : BestCustomers()
                Case enumStats.BestArticles : BestItems()

            End Select
        End If
    End Sub



    Private Sub radStatistics_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radStatistics.SelectedIndexChanged
        Select Case radStatistics.SelectedIndex
            Case 0 : CreateStats(enumStats.BestCustomer)
            Case 1 : CreateStats(enumStats.BestArticles)
            Case 2

        End Select
    End Sub



    Private Sub datDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datStartDate.DateTimeChanged, datEndDate.DateTimeChanged
        CreateStats(m_selectedDataSource)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        grdMain.ShowPrintPreview()

    End Sub

    Private Sub iucStatistics_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isLoading = True
        datEndDate.DateTime = Date.Today
        datStartDate.DateTime = Date.Today.AddYears(-1)

        If m_application IsNot Nothing Then

            GetInvoiceYears()

            isLoading = False
            radStatistics.SelectedIndex = 0
        End If

    End Sub

    Private Sub spYears_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spYears.ValueChanged
        datStartDate.DateTime = New Date(CInt(spYears.Value), 1, 1)
        datEndDate.DateTime = New Date(CInt(spYears.Value), 12, 31)

        CreateStats(m_selectedDataSource)

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent Close()
    End Sub



    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        Return True
    End Function

    Public Sub CreateNewItem() Implements IModule.CreateNewItem

    End Sub

    Public ReadOnly Property CurrentItemID As String Implements IModule.CurrentItemID
        Get
            Return String.Empty
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem

    End Sub

    Public ReadOnly Property DisplayText As String Implements IModule.DisplayText
        Get
            Return GetText("modStatisticTop10", "Statistiken")
        End Get
    End Property

    Public ReadOnly Property HasChanged As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule

    End Sub

    ''' <summary>
    ''' ruft den drucken-dialog auf.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Print() Implements IModule.Print
        grdMain.ShowPrintPreview()
    End Sub

    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

    End Sub

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnPrint
        End Get
    End Property
End Class