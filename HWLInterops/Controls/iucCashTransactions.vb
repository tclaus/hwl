Option Explicit On
Option Strict On

Imports ClausSoftware.Kernel
Imports ClausSoftware.Data
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid

''' <summary>
''' stellt die Oberfläche für das Kassenbuch bereit
''' </summary>
''' <remarks></remarks>
Public Class iucCashTransactions
    Implements IModule

    Private m_cashList As Kernel.CashJournalItems


    Private m_activeItem As CashJournalItem

    ''' <summary>
    ''' Ruftd das aktuelle element ab, das im editorbereich steht oder legt es fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ActiveItem() As CashJournalItem
        Get
            Return m_activeItem
        End Get
        Set(ByVal value As CashJournalItem)
            m_activeItem = value

            MainUI.MRUManager.AddMRUElement(value)

            FillControls()

        End Set
    End Property

    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        If HasChanged Then
            SaveCurrentItem()
        End If
        Return True
    End Function

    ''' <summary>
    ''' Ruft die ID des aktuell geladenen Objektes ab. Nothing, falls gerade kein Objekt im Focus ist
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            If ActiveItem IsNot Nothing Then
                Return ActiveItem.Key
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem

    End Sub

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return "Kassenbuch" 'TODO: NLS
        End Get
    End Property

    Dim m_hasChanged As Boolean

    ''' <summary>
    ''' Ruft einen wert ab, der angibt, ob die Eingabemaske geändert wurde
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            If ActiveItem IsNot Nothing Then
                Return m_hasChanged
            Else
                Return False
            End If

        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule
        commonGrid.Context = "CashTransactions"
        commonGrid.SetDataSource(Kernel.DataSourceList.CashJournalMonthy)

        IucDateChooser1.SetYears(MainApplication.getInstance.CashJournal.GetItemYears)
        SetValueFields(commonGrid.ActiveFilterString)

    End Sub

    ''' <summary>
    ''' Erstellt ein neues Element in dieser Auflistung. Falls bereits ein element bearbeitet wird, so wird erst eine Frage gestellt, ob gespeichert werden soll
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateNewItem() Implements IModule.CreateNewItem
        If HasChanged Then
            Dim result As DialogResult = AskChangedData()
            If result = DialogResult.Cancel Then Exit Sub

            If result = DialogResult.Yes Then
                SaveCurrentItem()
            End If
            If result = DialogResult.No Then m_hasChanged = False '"Nicht speichern"
        End If

        ' Neues Element erstellen und der Auflistung hinzufügen
        ActiveItem = MainApplication.getInstance.CashJournal.GetNewItem
        datDate.Focus()


    End Sub

    ''' <summary>
    ''' Füllt die auto-Text-Felder auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillTextFieldList()

        Dim acsDescription As New AutoCompleteStringCollection()
        Dim acstarget As New AutoCompleteStringCollection()

        Dim txdescription As Windows.Forms.TextBox = txtDescription.MaskBox
        txdescription.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
        txdescription.AutoCompleteSource = Windows.Forms.AutoCompleteSource.CustomSource

        Dim txNumber As Windows.Forms.TextBox = txtNumber.MaskBox
        txNumber.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
        txNumber.AutoCompleteSource = Windows.Forms.AutoCompleteSource.CustomSource


        For Each item As Kernel.CashJournalItem In MainApplication.getInstance.CashJournal
            If Not acsDescription.Contains(item.TransactionText) Then
                acsDescription.Add(item.TransactionText)
            End If

            If Not acstarget.Contains(item.Buchungsnummer) Then
                acstarget.Add(item.Buchungsnummer)
            End If

        Next

        txdescription.AutoCompleteCustomSource = acsDescription
        txNumber.AutoCompleteCustomSource = acstarget
    End Sub

    ''' <summary>
    ''' Prints the cuurent Grid or whatever Enduser selelets in the following dialog
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Print() Implements IModule.Print
        Try
            Using frm As New Printing.frmPrintCashTransactions
                frm.Grid = Me.commonGrid.grdCommonGrid
                frm.DataSourceType = DataSourceList.CashJournalMonthy
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            ' wenn hier was passiert => log und Meldung machen !
            MainApplication.getInstance.log.WriteLog(ex, "Print CashJournal", "Error in Dialog")
        End Try

    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        SaveCurrentItem()
    End Sub

    ''' <summary>
    ''' Speichert den aktuellen Eintrag ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

        If Not MainUI.CheckIfLicenceValidForSaving() Then Exit Sub

        If Me.ActiveItem IsNot Nothing Then
            If Me.ActiveItem.IsDeleted Then
                Me.ActiveItem = Nothing
            End If


            If RadioGroup1.SelectedIndex = 0 Then
                ActiveItem.Ausgabe = 0
                ActiveItem.Einnahme = CDbl(txtAmmount.EditValue)

            Else
                ActiveItem.Ausgabe = CDbl(txtAmmount.EditValue)
                ActiveItem.Einnahme = 0

            End If

            If cobTax.SelectedItem Is Nothing Then
                MessageBox.Show(GetText("msgSelectAVATRate", "Legen Sie einen Steuersatz fest"), GetText("msgVATRate", "Steuersatz"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                cobTax.Focus()
                Exit Sub
            End If

            ActiveItem.TransactionDate = datDate.DateTime
            ActiveItem.Buchungsnummer = txtNumber.Text
            ActiveItem.TransactionText = txtDescription.Text
            ActiveItem.CashAccount = CType(btnCashAccount.EditValue, CashAccount)

            If ActiveItem.TaxValuePairs.Count = 0 Then ActiveItem.TaxValuePairs.Add(ActiveItem.TaxValuePairs.GetNewItem)

            ActiveItem.TaxValuePairs(0).Tax = CType(cobTax.SelectedItem, TaxRate)
            ActiveItem.TaxValuePairs(0).Value = CDec(txtAmmount.EditValue)

            ActiveItem.TaxValue = CDbl(CType(cobTax.SelectedItem, TaxRate).TaxValue)

            If Not MainApplication.getInstance.CashJournal.ContainsKey(ActiveItem.Key) Then
                MainApplication.getInstance.CashJournal.Add(ActiveItem)
            End If

            Me.ActiveItem.Save() ' Hier das element speichern

            MainApplication.getInstance.SendMessage(GetText("msgsaved", "Gespeichert."))

            commonGrid.RefreshData()
            commonGrid.SelectItemByID(ActiveItem.ID)

            ' vielleicht hat sich das Jahrgeänrt

            Dim years As New List(Of String)
            years.AddRange(IucDateChooser1.GetYears)

            Dim yfound As Boolean
            Dim missingYear As String = ""

            For Each item As String In years
                missingYear = item
                If item = ActiveItem.TransactionDate.Year.ToString Then
                    yfound = True
                    Exit For
                End If
            Next

            If Not yfound Then
                years.Add(missingYear)
                IucDateChooser1.SetYears(years.ToArray)
            End If


            IucDateChooser1.SetYears(MainApplication.getInstance.CashJournal.GetItemYears)

            FillControls()

            m_hasChanged = False
        End If
        SetValueFields(commonGrid.ActiveFilterString)
    End Sub

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnDelete Or actionButtons.btnNew Or actionButtons.btnPrint Or actionButtons.btnSave

        End Get
    End Property

    Private Sub CommonGrid_AfterCreateNewItem(ByVal sender As Object, ByVal e As Kernel.StaticItemEventArgs) Handles commonGrid.AfterCreateNewItem
        ' eine Prüfung fans bereits im Before-Event statt
        ActiveItem = CType(e.NewItem, CashJournalItem)

    End Sub


    Private Sub commonGrid_AfterDeleteItem(sender As Object, e As StaticItemEventArgs) Handles commonGrid.AfterDeleteItem
        ' DAs Löschen von Elementen aus dem Grid heraus auch mitteilen
        SetValueFields(commonGrid.ActiveFilterString)

    End Sub

    Private Sub CommonGrid_BeforeCreateNewItem(ByVal sender As Object, ByVal e As Kernel.CreateItemArgs) Handles commonGrid.BeforeCreateNewItem
        If m_activeItem IsNot Nothing Then

            ' Falls noh ein element bearbeitet wird, das Neu anlegen verhindern
            If Me.HasChanged Then
                Dim result As DialogResult = AskChangedData()
                If result = DialogResult.OK Then
                    m_activeItem.Save()
                End If

                If result = DialogResult.Cancel Then
                    e.Cancel = True
                    Exit Sub
                End If

            End If
        End If
    End Sub

    Private Sub CommonGrid_ItemRowDoubleClick(ByVal key As System.String) Handles commonGrid.ItemRowDoubleClick
        LoadCurrentItem(commonGrid.FocussedItem)
    End Sub

    Friend Sub LoadCurrentItem(ByVal currentItem As StaticItem)
        If m_activeItem IsNot Nothing Then
            If HasChanged And m_hasChanged Then


                Dim result As DialogResult = AskChangedData()
                If result = DialogResult.Cancel Then Exit Sub

                If result = DialogResult.Yes Then
                    SaveCurrentItem()
                Else
                    m_activeItem.Reload()

                End If

            End If
        End If


        ActiveItem = CType(currentItem, CashJournalItem)

    End Sub

    ''' <summary>
    ''' Füllt  Controls mit Standardwerten auf
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillDefaultControls()

        btnCashAccount.EditValue = MainApplication.getInstance.CashAccounts
        cobTax.Properties.Items.AddRange(MainApplication.getInstance.TaxRates)
        m_hasChanged = False

    End Sub
    ''' <summary>
    ''' Füllt das aktuell markierte Element in die Eingabezeile, sofern dieses nicht gerade in Berabeitung ist
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillControls()

        With ActiveItem

            txtDescription.Text = .TransactionText
            txtNumber.Text = .Buchungsnummer
            datDate.DateTime = .TransactionDate
            If .CashAccount IsNot Nothing Then
                btnCashAccount.EditValue = .CashAccount
            Else
                btnCashAccount.EditValue = Nothing
            End If

            If .Einnahme <> 0 Then
                txtAmmount.EditValue = .Einnahme
                RadioGroup1.SelectedIndex = 0
            Else
                txtAmmount.EditValue = .Ausgabe
                RadioGroup1.SelectedIndex = 1
            End If

            ' Gibt es nicht: Keine Mehrfachen Steuerarten im Kassenbuch !
            cobTax.SelectedItem = .TaxValuePairs(0).Tax

            ' Neue Buchung = 
            If Not .IsNew Then
                lblNumberValue.Text = CStr(.ID)
            Else
                lblNumberValue.Text = GetText("new", "Neu")

            End If

        End With


        ' achtung bei den steuern kann das wieder gestaffelt sein !

        m_hasChanged = False


    End Sub


    Private Sub GridLookUpEdit1View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim gridView As GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim hi As ViewInfo.GridHitInfo = CType(gridView.CalcHitInfo(gridView.GridControl.PointToClient(MousePosition)), ViewInfo.GridHitInfo)

        ' Filterzeile toggeln
        If hi.HitTest = ViewInfo.GridHitTest.ColumnButton Then

            gridView.OptionsView.ShowAutoFilterRow = Not gridView.OptionsView.ShowAutoFilterRow
        End If
    End Sub

    Private Sub grdAccount_Popup(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Das aktuelle Konto selektieren
        Dim gridView As GridView = CType(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View

        For n As Integer = 0 To gridView.RowCount - 1
            If m_activeItem.CashAccount IsNot Nothing Then
                If CType(gridView.GetRow(n), CashAccount).ID = m_activeItem.CashAccount.ID Then
                    gridView.SelectRow(n)
                    gridView.FocusedRowHandle = n
                    Exit For
                End If
            End If

        Next
    End Sub


    Private Sub CommonGrid_CustomFilterChanged(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator) Handles commonGrid.CustomFilterChanged
        SetValueFields(criteria)
    End Sub

    ''' <summary>
    ''' Berechnet die Wertefelder unter dem Grid, das die Summen enthält
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetValueFields(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator)

        MainApplication.getInstance.log.WriteLog(ClausSoftware.Tools.LogSeverity.Verbose, "Bereite Liste mit Forderungen/Verbindlichkeiten Summen vor")

        m_cashList = New CashJournalItems(MainApplication.getInstance, criteria)

        Dim cs As Kernel.CashJournalsSums = m_cashList.GetCashSums()
        lblSumInbound.Text = cs.Income.ToString("c")
        lblSumOutbound.Text = cs.Outcome.ToString("c")


        lblStartingSum.Text = m_cashList.GetCashBeforeThis.ToString("C")

        lblEndingSum.Text = m_cashList.GetCashAfterThis.ToString("C")

        lblTotalCashToday.Text = m_cashList.GetTotalCash.ToString("C")


        Dim startDate As Date = m_cashList.FirstItemdate
        Dim endDate As Date = m_cashList.LasttemDate

        'Texte für Anfangs- un endbestand ermitteln
        If startDate < Date.MaxValue Then
            lbltxtStartSum.Text = GetText(lbltxtStartSum.Name, lbltxtStartSum.Text, startDate.ToString("d")) ' Anfangsbestand
        Else
            ' Im Betrachtungszeitraum gab es kein Eintrag
            If m_cashList.StartDate > Date.MinValue Then ' Anfangsbestand seit Beginn oder seit einem Datum
                lbltxtStartSum.Text = GetText(lbltxtStartSum.Name, lbltxtStartSum.Text, m_cashList.StartDate.ToString("d")) ' Anfangsbestand
            Else
                lbltxtStartSum.Text = GetText("opening_balance", "Anfangsbestand")
            End If

        End If

        If endDate > Date.MinValue Then
            lbltxtendSum.Text = GetText(lbltxtendSum.Name, lbltxtendSum.Text, endDate.ToString("d")) ' endbestand
        Else
            ' endedateum aus dem Betrachtungszeitraum (kein eintrag geliefert)
            lbltxtendSum.Text = GetText(lbltxtendSum.Name, lbltxtendSum.Text, m_cashList.EndDate.ToString("d")) ' endbestand

        End If


        ' Die Texte auffüllen
        FillTextFieldList()

    End Sub

    Private Sub IucDateChooser1_DateChanged(ByVal sender As System.Object, ByVal e As ClausSoftware.HWLInterops.DateSpanEventArgs) Handles IucDateChooser1.DateChanged

        'TODO: Hier den Filter prüfen, wenn "Alle Jahre" gewählt wurden

        Dim criteria As DevExpress.Data.Filtering.CriteriaOperator
        If e.EndDate < Date.MaxValue And e.StartDate > Date.MinValue Then
            criteria = New DevExpress.Data.Filtering.BetweenOperator("TransactionDate", e.StartDate, e.EndDate)

        Else
            If e.StartDate > Date.MinValue Then
                criteria = New DevExpress.Data.Filtering.BinaryOperator("TransactionDate", e.StartDate, DevExpress.Data.Filtering.BinaryOperatorType.GreaterOrEqual)

            Else
                criteria = New DevExpress.Data.Filtering.BinaryOperator("TransactionDate", e.EndDate, DevExpress.Data.Filtering.BinaryOperatorType.LessOrEqual)

            End If
        End If


        commonGrid.SetCriteriaString(criteria)


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

    Private Sub EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.EditValueChanged, txtDescription.EditValueChanged, datDate.EditValueChanged
        m_hasChanged = True
    End Sub

    Private Sub SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobTax.SelectedIndexChanged
        m_hasChanged = True
    End Sub

    Private Sub iucCashTransactions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        commonGrid.Width = Me.Width ' Bereite erzwingen

        m_cashList = CType(MainApplication.getInstance.CashJournal.GetNewCollection, CashJournalItems)

        InitializeModule()

        FillDefaultControls()
        CreateNewItem()
    End Sub
    ''' <summary>
    ''' Ruft das kleine symbolbild für dieses Modul ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get
            Return My.Resources.Price_List_16x16
        End Get
    End Property

    Private Sub btnCashAccount_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles btnCashAccount.ButtonClick
        SelectCashAccount()
    End Sub

    Private Sub btnCashAccount_Properties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashAccount.Properties.Click
        SelectCashAccount()
    End Sub

    Private Sub btnCashAccount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            SelectCashAccount()
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Wählt ein Kassenbuchkonto aus
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SelectCashAccount()
        If m_activeItem IsNot Nothing Then
            Dim selectedCashAccount As CashAccount = MainUI.ShowListCashAccounts(m_activeItem.CashAccount)
            If selectedCashAccount IsNot Nothing Then

                btnCashAccount.EditValue = selectedCashAccount
                cobTax.SelectedItem = selectedCashAccount.TaxRate

                MainApplication.getInstance.Settings.LastSelectedCashAccount = selectedCashAccount
            End If

        End If
    End Sub


    Private Sub SelectNextControlOn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumber.KeyDown, txtDescription.KeyDown, txtAmmount.KeyDown, RadioGroup1.KeyDown, datDate.KeyDown, cobTax.KeyDown, btnCashAccount.KeyDown
        Try
            ' Auswahl anzeigen lassen
            If sender Is btnCashAccount Then
                If e.KeyCode = Keys.Space Or e.KeyCode = Keys.F2 Then
                    SelectCashAccount()
                End If
            End If

            If e.KeyCode = Keys.Enter Then
                If sender Is txtNumber Then
                    SaveCurrentItem()
                    CreateNewItem()
                Else
                    If sender Is datDate Then
                        txtDescription.Focus()
                        Exit Sub
                    End If
                    If sender Is txtDescription Then
                        btnCashAccount.Focus()
                        Exit Sub
                    End If

                    If sender Is btnCashAccount Then
                        cobTax.Focus()
                        Exit Sub
                    End If
                    If sender Is cobTax Then
                        RadioGroup1.Focus()
                        Exit Sub
                    End If

                    If sender Is RadioGroup1 Then
                        txtAmmount.Focus()
                        Exit Sub
                    End If

                    If sender Is txtAmmount Then
                        txtNumber.Focus()
                        Exit Sub
                    End If
                End If

            End If

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "CashTransaction", "Fehler beim Keydown-Ereignis!")
        End Try

    End Sub

    Private Sub commonGrid_RowChangedData(ByVal sender As Object, ByVal e As System.EventArgs) Handles commonGrid.RowChangedData

        FillTextFieldList()

    End Sub

    Private Sub txtDescription_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtDescription.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub

    Private Sub txtDescription_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtDescription.DragDrop
        DragDropHelper.SetText(sender, e)
    End Sub

    Private Sub txtAmmount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAmmount.Validating


    End Sub
End Class
