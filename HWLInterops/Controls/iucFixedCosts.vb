Imports ClausSoftware.Kernel

''' <summary>
''' Stellt ein Control bereit, das wiederkehrende Kosten enthält
''' </summary>
''' <remarks></remarks>
Public Class iucFixedCosts
    Implements IModule
    ''' <summary>
    ''' Enthält die Benutzereingaben
    ''' </summary>
    ''' <remarks></remarks>
    Private m_userValues As New FixCostUserValues
    ''' <summary>
    ''' Gesamtjahreskosten
    ''' </summary>
    ''' <remarks></remarks>
    Private m_TotalYearsCost As Decimal ' 

    ''' <summary>
    ''' Verbleibende Kosten bis zum Jahresende
    ''' </summary>
    ''' <remarks></remarks>
    Private m_YearsEndCost As Decimal ' 

    ''' <summary>
    ''' Monatskosten pro Kalkulierten Monat
    ''' </summary>
    ''' <remarks></remarks>
    Private m_CostPerCalculatedMonth As Decimal
    ''' <summary>
    ''' Kosten Pro kalkulierten Arbeitstag
    ''' </summary>
    ''' <remarks></remarks>
    Private m_CostPerCalculatedDay As Decimal

    ''' <summary>
    ''' Kosten Pro Arbeitsstunde
    ''' </summary>
    ''' <remarks></remarks>
    Private m_costPerCalculatedHour As Decimal
    Private m_costPerCalculatedMinute As Decimal


    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        SaveUserValues()
        Return True
    End Function

    ''' <summary>
    ''' Speichert die Benutzereinstellungen der Eingabefelder
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveUserValues()

        With m_userValues
            .MonthPerYear = CDec(txtCountMonth.EditValue)
            .DaysPerMonth = CDec(txtCountDays.EditValue)
            .HoursPerDay = CDec(txtCountHours.EditValue)
            .MinutesPerHour = CDec(txtCountMinutes.EditValue)

            .WorkersPerYear = CDec(txtworkersCount1.EditValue)
            .WorkersPerMonth = CDec(txtworkersCount2.EditValue)
            .WorkersPerDay = CDec(txtworkersCount3.EditValue)
            .WorkersPerHour = CDec(txtworkersCount4.EditValue)
            .WorkersPerMinute = CDec(txtworkersCount5.EditValue)
        End With


        Dim m As New System.IO.MemoryStream
        Dim ser As New System.Xml.Serialization.XmlSerializer(GetType(FixCostUserValues))
        ser.Serialize(m, m_userValues)


        MainApplication.getInstance.Settings.SetSetting("fixedCostUserValues", "fixedCostsUserValues", m, MainApplication.getInstance.CurrentUser.Key)
    End Sub

    ''' <summary>
    ''' Läd Benutzereinstellungen der Eingabefelder
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUserSettings()
        Try
            Dim inValue As IO.StringReader
            Dim tmpstr As String

            tmpstr = MainApplication.getInstance.Settings.GetSetting("fixedCostUserValues", "fixedCostsUserValues", "", MainApplication.getInstance.CurrentUser.Key)

            inValue = New IO.StringReader(tmpstr)

            Dim ser As New System.Xml.Serialization.XmlSerializer(GetType(FixCostUserValues))
            m_userValues = CType(ser.Deserialize(inValue), FixCostUserValues)

        Catch ex As Exception
            Debug.Print("Fehler beim deserialiseren: " & ex.Message) ' egal, dann eben ohne Benutztereinstellungem
        End Try

        If m_userValues Is Nothing Then
            m_userValues = New FixCostUserValues
        End If

        With m_userValues
            txtCountMonth.EditValue = .MonthPerYear
            txtCountDays.EditValue = .DaysPerMonth
            txtCountHours.EditValue = .HoursPerDay
            txtCountMinutes.EditValue = .MinutesPerHour

            txtworkersCount1.EditValue = .WorkersPerYear
            txtworkersCount2.EditValue = .WorkersPerMonth
            txtworkersCount3.EditValue = .WorkersPerDay
            txtworkersCount4.EditValue = .WorkersPerHour
            txtworkersCount5.EditValue = .WorkersPerMinute
        End With

    End Sub

    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            Return String.Empty
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem

    End Sub

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return GetText("moduleNameFixedCosts", "Fixkosten") '
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule

    End Sub

    Public Sub NewItem() Implements IModule.CreateNewItem
        UicCommonGrid1.CreateNew()
    End Sub

    Public Overrides Sub Print() Implements IModule.Print
        UicCommonGrid1.ShowPrintPreview()
    End Sub

    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

    End Sub

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnDelete Or actionButtons.btnNew Or actionButtons.btnPrint
        End Get
    End Property

    Private Sub iucFixedCosts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DesignMode Then Exit Sub

        MainApplication.getInstance.FixedCosts.Reload()
        UicCommonGrid1.Context = "FixedCosts"
        UicCommonGrid1.Editable = False
        UicCommonGrid1.SetDataSource(DataSourceList.FixedCosts)

        LoadUserSettings()

        FillSumFields()
        AddHandler UicCommonGrid1.BeforeCreateNewItem, AddressOf BeforeCreateNewItem

    End Sub

    ''' <summary>
    ''' Aufsummierung der Kosten neu berechnen und anzeigen lassen
    ''' Stellt das erste allgemeine Tab dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FillSumFields()

        Dim listOfCosts As New List(Of FixedCost)

        For Each item As Data.StaticItem In UicCommonGrid1.GetRows
            If item IsNot Nothing Then
                listOfCosts.Add(CType(item, FixedCost))
            End If

        Next

        m_TotalYearsCost = 0
        m_YearsEndCost = 0

        For Each item As FixedCost In listOfCosts
            m_TotalYearsCost += item.CostPerYear
            m_YearsEndCost += item.CostToYearsEnd
        Next

        lblCostToYearsEnd.Text = m_YearsEndCost.ToString("c")
        lblCostperYear.Text = m_TotalYearsCost.ToString("c")

        ' Jährliche Kosten auf einen Monat berechnen
        lblCostPerMonth.Text = (m_TotalYearsCost / 12).ToString("c")

        FillCostCalculations()

    End Sub

    ''' <summary>
    ''' Berechnet den Anteil der Jahreskosten auf eine angegebene Anzahl von Stunden/Tag
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillCostCalculations()
        lblFixedCostPerYearValue.Text = m_TotalYearsCost.ToString("c") ' Volle Jahreskosten
        CostPerCalculatedMonth()

    End Sub

    ''' <summary>
    ''' Wenn im Grid ein neues element angelegt wird, wird dies hier unterbrochen und das Anlegen selber gesteuert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BeforeCreateNewItem(ByVal sender As Object, ByVal e As CreateItemArgs)
        e.Cancel = True
        Dim item As FixedCost = MainApplication.getInstance.FixedCosts.GetNewItem()
        OpenSelectedItem(item)
    End Sub

    Private Sub UicCommonGrid1_CustomFilterChanged(ByVal criteriaValue As DevExpress.Data.Filtering.CriteriaOperator) Handles UicCommonGrid1.CustomFilterChanged
        ' Hat sich der Filter geändert, dann summen neu berechnen lassen
        FillSumFields()
    End Sub

    ''' <summary>
    ''' Doppelklick auf ein Fixkosteneintrag
    ''' </summary>
    ''' <param name="key"></param>
    ''' <remarks></remarks>
    Private Sub UicCommonGrid1_ItemRowDoubleClick(ByVal key As System.String) Handles UicCommonGrid1.ItemRowDoubleClick

        OpenSelectedItem(CType(UicCommonGrid1.FocussedItem, Kernel.FixedCost))


    End Sub

    ''' <summary>
    ''' Öffnet den angegebenen Fixkosteneintrag in einem neuem Dialog
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Public Sub OpenSelectedItem(ByVal item As ClausSoftware.Kernel.FixedCost)
        Try
            Dim frm As New frmFixedCostDetail
            frm.FixedCostItem = item
            If frm.ShowDialog() = DialogResult.OK Then
                item.Save()
                MainApplication.getInstance.FixedCosts.Reload()
                UicCommonGrid1.RefreshData()
                FillSumFields()
            End If
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Error in fixCost Details", "Fehler beim anzeigen der Fixkostendetails")
        End Try

    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    End Sub

    Public Sub New(ByVal myUI As MainUI)
        MyBase.New(myUI)
        InitializeComponent()

    End Sub

    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get

        End Get
    End Property

    Private Sub txtHourcount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FillCostCalculations()
    End Sub

    Private Sub txtHourcount_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        If CInt(e.NewValue) > 24 Then
            'e.NewValue = 24I
            e.Cancel = True
        End If

        If CInt(e.NewValue) < 1 Then
            e.Cancel = True
        End If

    End Sub




    Private Sub txtWorkHoursPerDay_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        If CInt(e.NewValue) < 1 Then
            e.Cancel = True
        End If

        If CInt(e.NewValue) > 24 Then
            e.Cancel = True
        End If

    End Sub

    Private Sub lblFixedCostPerYearValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFixedCostPerYearValue.TextChanged
        CostPerCalculatedMonth()
        CostPerYearDivided()
    End Sub

    ''' <summary>
    ''' Jahreskosten durch Anzahl der Mitarbeiter
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CostPerYearDivided()
        Try
            lblFixedCostworkers1Value.Text = (m_TotalYearsCost / CInt(txtworkersCount1.EditValue)).ToString("c")
        Catch
            lblFixedCostworkers1Value.Text = "-"
        End Try

    End Sub

    Private Sub CostPerHourDivided()
        Try
            lblFixedCostworkers4Value.Text = (m_costPerCalculatedHour / CInt(txtworkersCount4.EditValue)).ToString("c")
        Catch
            lblFixedCostworkers4Value.Text = "-"
        End Try

    End Sub

    Private Sub CostPerMinuteDivided()
        Try
            lblFixedCostworkers5Value.Text = (m_costPerCalculatedMinute / CInt(txtworkersCount5.EditValue)).ToString("c")
        Catch
            lblFixedCostworkers5Value.Text = "-"
        End Try

    End Sub


    Private Sub txtworkersCount1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtworkersCount1.EditValueChanged
        CostPerYearDivided()
    End Sub

    Private Sub txtworkersCount2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtworkersCount2.EditValueChanged
        CostPerMonthDivided()
    End Sub

    ''' <summary>
    ''' Berechnet die Monatskosten geteilt durch Anzahl der Arbeiter
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CostPerMonthDivided()
        Try
            lblFixedCostworkers2Value.Text = (m_CostPerCalculatedMonth / CInt(txtworkersCount2.EditValue)).ToString("c")
        Catch
            lblFixedCostworkers2Value.Text = "-"
        End Try

    End Sub

    Private Sub CostPerDayDivided()
        Try
            lblFixedCostworkers3Value.Text = (m_CostPerCalculatedDay / CInt(txtworkersCount3.EditValue)).ToString("c")
        Catch
            lblFixedCostworkers3Value.Text = "-"
        End Try

    End Sub

    ''' <summary>
    ''' Berechnet die Monatskosten per N Arbeitsmonaten/Jahr
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CostPerCalculatedMonth()
        Try
            m_CostPerCalculatedMonth = m_TotalYearsCost / CInt(txtCountMonth.EditValue)
            lblFixedCostMonthsPerYearValue.Text = m_CostPerCalculatedMonth.ToString("c")
        Catch
            lblFixedCostMonthsPerYearValue.Text = "-"
        End Try
    End Sub

    ''' <summary>
    ''' Berechnet die Tageskosten bei N Arbeitstagen /Monat
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CostPerCalculatedDay()
        Try
            m_CostPerCalculatedDay = m_CostPerCalculatedMonth / CInt(txtCountDays.EditValue)
            lblFixedCostsDaysPerMonthValue.Text = m_CostPerCalculatedDay.ToString("c")
        Catch
            lblFixedCostsDaysPerMonthValue.Text = "-"
        End Try
    End Sub

    ''' <summary>
    ''' Berechnet die Stundenkosten bei N Arbeitsstunden/Tag
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CostPerCalculatedHour()
        Try
            m_costPerCalculatedHour = m_CostPerCalculatedDay / CInt(txtCountDays.EditValue)
            lblFixedCostHoursPerDayValue.Text = m_costPerCalculatedHour.ToString("c")
        Catch
            lblFixedCostHoursPerDayValue.Text = "-"
        End Try

    End Sub

    ''' <summary>
    ''' Berechnet die Minutenkosten bei N Minuten/Stunde
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CostPerCalculatedMinute()
        Try
            m_costPerCalculatedMinute = m_costPerCalculatedHour / CInt(txtCountMinutes.EditValue)
            lblFixedCostMinutesPerHourValue.Text = m_costPerCalculatedMinute.ToString("c")
        Catch
            lblFixedCostMinutesPerHourValue.Text = "-"
        End Try

    End Sub

    Private Sub txtCostPerCountMonth_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCountMonth.EditValueChanged
        CostPerCalculatedMonth()
    End Sub

    Private Sub lblFixedCostMonthsPerYearValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFixedCostMonthsPerYearValue.TextChanged
        CostPerCalculatedDay()
        CostPerMonthDivided()
    End Sub

    Private Sub lblFixedCostsDaysPerMonthValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFixedCostsDaysPerMonthValue.TextChanged
        CostPerCalculatedHour()
        CostPerDayDivided()
    End Sub

    Private Sub txtCostPerCountDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCountDays.EditValueChanged
        CostPerCalculatedDay()
    End Sub

    Private Sub txtCostPerCountHours_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCountHours.EditValueChanged
        CostPerCalculatedHour()
    End Sub

    Private Sub txtworkersCount3_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtworkersCount3.EditValueChanged
        CostPerDayDivided()
    End Sub

    Private Sub txtworkersCount4_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtworkersCount4.EditValueChanged, txtworkersCount5.EditValueChanged
        CostPerHourDivided()
    End Sub

    Private Sub lblFixedCostHoursPerDayValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFixedCostHoursPerDayValue.TextChanged
        CostPerCalculatedMinute()
        CostPerHourDivided()
    End Sub

    Private Sub txtCountMinutes_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCountMinutes.EditValueChanged
        CostPerCalculatedMinute()
    End Sub

    Private Sub lblFixedCostMinutesPerHourValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFixedCostMinutesPerHourValue.TextChanged
        CostPerMinuteDivided()
    End Sub
End Class
