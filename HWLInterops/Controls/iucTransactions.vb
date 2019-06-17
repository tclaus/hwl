
Option Explicit On
Option Strict On

Imports ClausSoftware.Kernel
Imports ClausSoftware.Data
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid

''' <summary>
''' Stellt die Oberfläche für Einnahmen/Ausgaben bereit
''' </summary>
''' <remarks></remarks>
Public Class iucTransactions
    Implements IModule


    Private m_activeItem As Transaction
    Private m_hasChanged As Boolean

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged



    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        If HasChanged Then
            SaveCurrentItem()
        End If
        IucDateChooser1.SaveSettings(Me.commonGrid.Context)
        Return True
    End Function

    ''' <summary>
    ''' Setzt das gerade aktive Element oder ruft es ab. Es findet eine Prüfung statt ob der Vorgang erlaubt ist
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ActiveItem() As Transaction
        Get
            Return m_activeItem
        End Get
        Set(ByVal value As Transaction)
            'If HasChanged Then
            '    Dim Result As DialogResult = AskChangedData()

            '    If Result = DialogResult.Yes Then
            '        ActiveItem.Save()
            '    End If
            '    If Result = DialogResult.Cancel Then
            '        Exit Property
            '    End If
            'End If

            MainUI.MRUManager.AddMRUElement(value)

            m_activeItem = value
            FillControls()

        End Set
    End Property

    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            If m_activeItem IsNot Nothing Then
                Return m_activeItem.ReplikID
            Else
                Return String.Empty
            End If
        End Get
    End Property

    ''' <summary>
    ''' Löcht den im Editor eingestellten Datensatz
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteItem() Implements IModule.DeleteItem
        ' Klick auf Button - sollte den oben eingestellten Datensatz löschen 

        If Me.ActiveItem IsNot Nothing Then
            If Me.ActiveItem.IsIntern Then
                ' Dürfen nur storniert werden
                Me.ActiveItem.SetCanceled()
            Else
                ' Darf gelöscht werden
                Me.ActiveItem.Delete()

                Me.ActiveItem = Nothing

            End If
        End If
    End Sub

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return "Forderungen / Verbindlichkeiten" 'TODO: NLS
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            If m_activeItem IsNot Nothing Then
                Return m_activeItem.HasChanged Or m_hasChanged
            Else
                Return m_hasChanged
            End If
        End Get
    End Property

    Private m_isInitializing As Boolean = True


    Private Sub InitializeAsync()
        m_isInitializing = True
        commonGrid.Context = DataSourceList.Transactions.ToString
        commonGrid.SetDataSource(DataSourceList.Transactions)

        IucDateChooser1.SetYears(MainApplication.getInstance.Transactions.GetItemYears)

        SetValueFields("")

        m_isInitializing = False

        IucDateChooser1.RestoreSettings(commonGrid.Context)
    End Sub

    Private Delegate Sub InitializeAsyncDelegate()

    Public Sub InitializeModule() Implements IModule.InitializeModule

        'Me.BeginInvoke(New InitializeAsyncDelegate(AddressOf InitializeAsync))
        InitializeAsync()

    End Sub

    Public Sub CreateNewItem() Implements IModule.CreateNewItem
        If HasChanged Then
            Dim resulkt As DialogResult = AskChangedData()
            If resulkt = DialogResult.Cancel Then Exit Sub

            If resulkt = DialogResult.Yes Then
                SaveCurrentItem()
            End If

            If resulkt = DialogResult.No Then m_hasChanged = False

        End If
        ' Neues element erstellen und der Auflistung hinzufügen
        ActiveItem = MainApplication.getInstance.Transactions.GetNewItem


    End Sub

    Public Overrides Sub Print() Implements IModule.Print
        commonGrid.ShowPrintPreview()
    End Sub

    ''' <summary>
    ''' Zeigt eine Warnung an, das das Gezahlt-Flag nicht zu den Buchungn passt
    ''' </summary>
    ''' <returns>Wenn true, kann weiter gespeichert werden, sonst muss der Speichervorgang abgebrochen werden</returns>
    ''' <remarks></remarks>
    Public Function CheckInkonsistentPaidFlag() As Boolean
        Dim result As DialogResult
        If Not m_activeItem.IsNew Then
            'Hier steuert die Oberfläche das Verhalten des Objektes, wenn der Anwender meint, das 'gezahlt' - Flag zu entfernen.
            If Not chkIsPaid.Checked Then

                ' Fall 1: Genau eine einzahlung gibt es => Entfernen
                ' Fall 2: es gibt mehr als eine einzahlung, dann kann das Flag nicht entfernt werden

                Dim payments As DownPayments = m_activeItem.GetDownPayments

                'ACHTUNG: HIER PRÜFEN AUF DAS GESETZTE FLAG DS USERS
                If payments.Count = 1 Then

                    payments.Delete()
                    payments.RemoveAll()
                    Return True
                End If

                If payments.Count > 1 Then
                    'TODO: NLS
                    result = MessageBox.Show("Sie haben die 'gezahlt'-Markierung entfernt. Laut Einzahlungsliste wurde der Rechnungsbetrag aber in mehreren Teilzahlungen beglichen." & vbCrLf &
                                             "Entfernen oder ändern Sie die Einzahlungen.  " & vbCrLf &
                                             "Sobald es eine Differenz gibt, wird der gezahlt-Marker automatisch angepasst", "Einzahlungen liegen vor", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

            End If
        End If


        Return True

    End Function

    ''' <summary>
    ''' Speichert das Element ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Save()
        MyBase.Save()
        SaveCurrentItem()
    End Sub

    ''' <summary>
    ''' Speichert das Element ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

        If Not MainUI.CheckIfLicenceValidForSaving() Then Exit Sub

        If m_activeItem IsNot Nothing Then
            If m_activeItem.IsDeleted Then Exit Sub

            If txtCashAccount.EditValue Is Nothing Then
                MessageBox.Show(GetText("msgChooseAnAccountText", "Wählen sie ein Konto aus"), GetText("msgChooseAnAccountHeadline", "Buchungskonto wählen"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not CheckInkonsistentPaidFlag() Then Exit Sub
            m_activeItem.Adress = CType(cobAddressList.SelectedItem, Adress)
            'm_activeItem.CashAccount = CType(cobAccount.SelectedItem, CashAccount)

            m_activeItem.CashAccount = CType(txtCashAccount.EditValue, CashAccount)
            m_activeItem.TaxItem = CType(cobTaxRates.SelectedItem, TaxRate)


            m_activeItem.TotalAmmount = CDec(txtAmmount.EditValue)
            m_activeItem.Text = txtDescription.Text
            m_activeItem.ItemDate = datItemDate.DateTime
            m_activeItem.ItemDisplayNumber = txtItemID.Text

            ' Falls nun ein Paid - wchsel stattfidnet, auch das Zahldatum auf "Heute" setzen
            If m_activeItem.IsPaid = False And chkIsPaid.Checked = True Then
                m_activeItem.SetIsPayed()
                'Grosse FRage: was passiert, wenn der Harken entfernt wird? 
            End If

            If radMoneyFlow.SelectedIndex = 0 Then
                m_activeItem.MoneyFlow = MoneyFlow.IsReceiveable
            Else
                m_activeItem.MoneyFlow = MoneyFlow.IsPayable
            End If

            m_activeItem.Save()
            MainApplication.getInstance.SendMessage(GetText("msgsaved", "Gespeichert."))

            If Not MainApplication.getInstance.Transactions.ContainsKey(m_activeItem.Key) Then
                MainApplication.getInstance.Transactions.Add(m_activeItem)
            End If

            '  commonGrid.RefreshData()

            m_hasChanged = False

        End If
    End Sub


    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnNew Or actionButtons.btnPrint Or actionButtons.btnSave

        End Get
    End Property

    Private Sub gridTransactions_AfterCreateNewItem(ByVal sender As Object, ByVal e As Kernel.StaticItemEventArgs) Handles commonGrid.AfterCreateNewItem



        ActiveItem = CType(e.NewItem, Transaction)

        FillControls()
        txtDescription.Focus()
    End Sub
    ''' <summary>
    ''' Füllt die Standard Elemente auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FilldefaultControls()
        cobAddressList.Properties.Items.Clear()
        cobAddressList.Properties.Items.AddRange(MainApplication.getInstance.Adressen)

        'cobAccount.Properties.Items.Clear()
        'cobAccount.Properties.Items.AddRange(MainApplication.getInstance.CashAccounts)

        cobTaxRates.Properties.Items.Clear()
        cobTaxRates.Properties.Items.AddRange(MainApplication.getInstance.TaxRates)

        m_hasChanged = False

    End Sub

    Private Sub FillControls()
        If m_activeItem IsNot Nothing Then
            If m_activeItem.ID <> -1 Then
                lblItemID.Text = CStr(m_activeItem.ID)
            Else
                lblItemID.Text = GetText("New", "Neu")

            End If

            btnPayments.Enabled = True

            txtDescription.Text = m_activeItem.Text
            txtAmmount.EditValue = m_activeItem.TotalAmmount
            datItemDate.DateTime = m_activeItem.ItemDate
            cobAddressList.SelectedItem = m_activeItem.Adress
            If m_activeItem.CashAccount IsNot Nothing Then
                txtCashAccount.EditValue = m_activeItem.CashAccount
            Else
                txtCashAccount.EditValue = Nothing

            End If

            If Not m_activeItem.HasPartialTaxValues Then
                cobTaxRates.SelectedItem = m_activeItem.TaxItem ' Falls ein zusammengestzeter Steuersatz existiert, dann etwas anderes anzeigen lassen 
            Else
                cobTaxRates.SelectedItem = Nothing

                ' Kein Textedit möglich !
                cobTaxRates.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

            End If

            chkIsPaid.Checked = m_activeItem.IsPaid

            If m_activeItem.Target = 0 Then
                radPaidOn.SelectedIndex = 0
            Else
                radPaidOn.SelectedIndex = 1
                ' Beim speichern das Kasenbuch aktualisieren
            End If

            txtItemID.Text = m_activeItem.ItemDisplayNumber

            txtItemID.Properties.ReadOnly = m_activeItem.IsIntern  ' Eigene Rechnungsnummern können nicht geändert werden
            If m_activeItem.MoneyFlow = MoneyFlow.IsReceiveable Then
                radMoneyFlow.SelectedIndex = 0
            Else
                radMoneyFlow.SelectedIndex = 1

            End If

        Else
            ' Alle Eingabefelder löschen
            btnPayments.Enabled = False
        End If

        CheckIfDocumentIsLocked()

        m_hasChanged = False
    End Sub

    ''' <summary>
    ''' Prüft, ob das aktuelle dokument bearbeitet werden darf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckIfDocumentIsLocked()
        If Me.ActiveItem IsNot Nothing Then

            If ActiveItem.IsCanceled Then
                datItemDate.Enabled = False
                txtAmmount.Enabled = False
                txtDescription.Enabled = False
                txtDescription.Enabled = False
                radMoneyFlow.Enabled = False
                cobAddressList.Enabled = False
                cobTaxRates.Enabled = False

            Else
                ' Alles OK : Uneingeschränkte Bearbeitung möglich

                datItemDate.Enabled = True

                txtAmmount.Enabled = True
                txtDescription.Enabled = True
                txtDescription.Enabled = True
                radMoneyFlow.Enabled = True
                cobAddressList.Enabled = True
                cobTaxRates.Enabled = True


            End If
        End If
    End Sub

    Private Sub iucTransactions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        commonGrid.Width = Me.Width ' Bereite erzwingen

        FilldefaultControls()
        CreateNewItem()
        datItemDate.Focus()

        commonGrid.MainUI = MainUI

    End Sub


    Private Sub cobTaxRates_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cobTaxRates.ButtonClick
        If m_activeItem Is Nothing Then Exit Sub
        If TypeOf e.Button.Tag Is String Then
            If CStr(e.Button.Tag) = "edit" Then

                Dim frm As New frmEnterTaxRateValues

                ' Unter diesem Teil positionieren
                frm.Left = cobTaxRates.Left
                frm.Top = cobTaxRates.Top + cobTaxRates.Height


                frm.TaxValuePairs = m_activeItem.TaxValuePairs
                If frm.ShowDialog() = DialogResult.OK Then
                    ' Werte wieder zurückschreiben
                    If frm.TaxValuePairs.Count = 1 Then
                        ' Dann diesen wert in die combobox schreiben
                        cobTaxRates.SelectedItem = frm.TaxValuePairs(0).Tax
                        m_activeItem.TaxItem = frm.TaxValuePairs(0).Tax
                    Else
                        m_activeItem.TaxItem = Nothing
                        cobTaxRates.SelectedItem = Nothing
                        ' TODO: Bei mehreren Steuerarten noch mal nachsehen..
                        '
                    End If
                    Me.m_hasChanged = True
                End If



            End If
        End If
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

    Private Sub gridTransactions_CustomFilterChanged(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator) Handles commonGrid.CustomFilterChanged

        ' TODO: Hier diesen Filter noch hinzufügen
        SetValueFields(criteria)

    End Sub

    ''' <summary>
    ''' Füllt die summenliste auf mit den Zahlenwerten
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetValueFields(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator)

        MainApplication.getInstance.log.WriteLog(ClausSoftware.Tools.LogSeverity.Verbose, "Bereite Liste mit Forderungen/Verbindlichkeiten Summen vor")

        Dim transactions As Kernel.Transactions = New Transactions(MainApplication.getInstance, criteria)


        Dim sums As TransactionSum = transactions.SumAmmount()
        lblReveiveableValue.Text = (sums.PaidAmmountInbound + sums.UnpaidAmmountInbound).ToString("c")
        lblPayablesValue.Text = (sums.PaidAmmountOutbound + sums.UnpaidAmmountOutbound).ToString("c")

        lblUnpaidAmmountValue.Text = sums.UnpaidAmmountInbound.ToString("c")

        grdTaxValues.DataSource = sums.TaskListValues
    End Sub

    Private Sub gridTransactions_ItemRowDoubleClick(ByVal itemKey As String) Handles commonGrid.ItemRowDoubleClick
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


        ActiveItem = CType(currentItem, Transaction)

    End Sub

    Private Sub cobAddressList_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cobAddressList.ButtonClick
        If TypeOf e.Button.Tag Is String AndAlso CStr(e.Button.Tag) = "editor" Then
            If m_activeItem IsNot Nothing Then
                Dim frm As New frmSmallItemChooser
                frm.DataKind = frmSmallItemChooser.DataKindenum.Contacts
                frm.Initialize()
                frm.ShowDialog()

                Dim adressItem As ClausSoftware.Data.StaticItem = frm.SelectedItem
                cobAddressList.SelectedItem = CType(adressItem, Adress)
            End If
        End If
    End Sub

    Private Sub IucDateChooser1_DateChanged(ByVal sender As System.Object, ByVal e As ClausSoftware.HWLInterops.DateSpanEventArgs) Handles IucDateChooser1.DateChanged

        If m_isInitializing Then Exit Sub

        If e.AllDates Then
            commonGrid.SetCriteriaString(Nothing)
        Else

            Dim criteria As New DevExpress.Data.Filtering.BetweenOperator("ItemDate", e.StartDate, e.EndDate)

            commonGrid.SetCriteriaString(criteria)
        End If
    End Sub

    Private Sub btnPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayments.Click

        Using details As New frmPayableDetails(mainControlContainer.MainUI)
            If m_activeItem IsNot Nothing Then
                details.ActiveTransaction = m_activeItem
                details.ShowDialog()

                chkIsPaid.Checked = Me.ActiveItem.IsPaid
            End If
        End Using

    End Sub

    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get
            Return My.Resources.Profits_16x16

        End Get
    End Property



    Private Sub btnCashAccount_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCashAccount.ButtonClick
        SelectCashAccount()
    End Sub

    Private Sub btnCashAccount_Properties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCashAccount.Properties.Click
        SelectCashAccount()
    End Sub

    Private Sub btnCashAccount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCashAccount.KeyDown
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

                txtCashAccount.EditValue = selectedCashAccount
                cobTaxRates.SelectedItem = selectedCashAccount.TaxRate

                MainApplication.getInstance.Settings.LastSelectedCashAccount = selectedCashAccount
            End If


        End If
    End Sub

End Class

''' <summary>
''' Stellt ein angepasstes Grid für Transaktionen (Forderungen / Verbindlichkeiten) zur Verfügung
''' </summary>
''' <remarks></remarks>
Class transactionsGrid
    Inherits uicCommonGrid
    ''' <summary>
    ''' Snthält das warnsymbol
    ''' </summary>
    ''' <remarks></remarks>
    Private m_warnsign As Image = My.Resources.SymbolWarning_16x16

    Private mnuShowDetailedPayments As ToolStripMenuItem
    Private mnuShowParentInvoice As ToolStripMenuItem
    Private mnuUndelete As ToolStripMenuItem

    ''' <summary>
    ''' stellt einen Trennstrich im Dialog dar
    ''' </summary>
    ''' <remarks></remarks>
    Private m_showSeparator As ToolStripSeparator

    Private m_mainUI As MainUI

    Public Property MainUI As MainUI
        Get
            Return m_mainUI
        End Get
        Set(ByVal value As MainUI)
            m_mainUI = value
        End Set
    End Property

    ''' <summary>
    ''' Führt das Löschen der selektiertren Grid-Zeilen durch; sofern kein 'Internes' Dokument dabei ist
    ''' Interne Dokumente werden stornietr
    ''' </summary>
    ''' <param name="dataItems"></param>
    ''' <remarks></remarks>
    Public Overrides Sub OnDeleteSelectedItems(ByVal dataItems() As Data.StaticItem)

        For Each dataItem As ClausSoftware.Data.StaticItem In dataItems
            Dim transactionItem As Transaction = CType(dataItem, Transaction)
            If transactionItem.IsIntern Then
                transactionItem.SetCanceled()

            Else
                dataItem.Delete()
            End If
        Next

    End Sub

    Public Overrides Sub OnOpenMenue()
        MyBase.OnOpenMenue()

        Dim focussedTransaction As Transaction = CType(Me.grvCommonGrid.GetFocusedRow, Transaction)
        If focussedTransaction IsNot Nothing Then
            mnuShowParentInvoice.Enabled = focussedTransaction.IsIntern
        End If

        ' Mehrfachselektion!
        ' Duplizieren Ausblenden, wenn keine zu duplizierenden Elemente existieren
        ' Löschen: Ist "storno" / "Storno aufheben", bei Internen und Storniertren Elementen
        mnuDuplicate.Enabled = SelectionCanDuplicate()

        mnuDelete.Visible = SelectionCanDeleteOrCancel()
        mnuUndelete.Visible = SelectionCanUnDelete()

    End Sub

    ''' <summary>
    ''' Ist wahr, wenn im gewählten Bereich mindestends ein element Gelöscht / Storniert werden kann
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectionCanDeleteOrCancel() As Boolean
        Dim result As Boolean
        For Each item As Data.StaticItem In GetSelectedItems()
            If Not CType(item, Transaction).IsCanceled Then Return True
        Next
        Return result
    End Function

    ''' <summary>
    ''' Ist wahr, wenn im gewählten Bereich von mindestends einem Element der storno aufgehoben werden kann
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectionCanUnDelete() As Boolean
        Dim result As Boolean
        For Each item As Data.StaticItem In GetSelectedItems()
            If CType(item, Transaction).IsCanceled Then Return True
        Next
        Return result
    End Function



    ''' <summary>
    ''' Zeigt an, ob eine Duplizierung der aktuellen Grid-Auswahl möglich ist
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectionCanDuplicate() As Boolean
        Dim result As Boolean = True
        For Each item As Data.StaticItem In GetSelectedItems()
            ' Interne Dokument dürfen nicht dupliziert werden
            If CType(item, Transaction).IsIntern Then Return False
            ' Stornierte Elemente dürfen nicht dupliziert werden
            If CType(item, Transaction).IsCanceled Then Return False

        Next
        Return True
    End Function

    ''' <summary>
    ''' Ermöglicht das Klonen der selektiertren Datensätze nur, wenn diese nicht "Intern" sind. 
    ''' Diese können nicht geklont werden
    ''' </summary>
    ''' <param name="dataItems"></param>
    ''' <remarks></remarks>
    Public Overrides Sub OnCloneItems(ByVal dataItems() As Data.StaticItem)

        For Each dataItem As StaticItem In dataItems
            Dim transactionItem As Transaction = CType(dataItem, Transaction)
            If Not transactionItem.IsIntern Then
                Dim newItem As StaticItem = CType(transactionItem.Clone, StaticItem)
                newItem.Save()
            End If

        Next

    End Sub

    ''' <summary>
    ''' Reagert auf ein Klick in das Menü. Ruft den Dialog der Zahlungseingänge auf
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OnClickShowPayments(ByVal sender As Object, ByVal e As EventArgs)

        Using frm As New frmPayableDetails(mainControlContainer.MainUI)

            Dim focussedTRansaction As Transaction = CType(Me.grvCommonGrid.GetFocusedRow, Transaction)

            frm.ActiveTransaction = focussedTRansaction
            frm.ShowDialog()
        End Using

    End Sub

    ''' <summary>
    ''' Entfernt das Cancel-Flag wieder
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OnClickUndelete(ByVal sender As Object, ByVal e As EventArgs)
        For Each dataItem As Data.StaticItem In GetSelectedItems()
            Dim transactionItem As Transaction = CType(dataItem, Transaction)
            If transactionItem.IsCanceled Then
                transactionItem.ClearCanceled()
            End If
        Next

    End Sub

    Private Sub OnClickShowDocument(ByVal sender As Object, ByVal e As EventArgs)
        'TODO: Rechnung im Journal zeigen, oder gleich die Rechnung als PDF
        ' Überlegung: Rechnung als PDF später zeigen


        Dim focussedTRansaction As Transaction = CType(Me.grvCommonGrid.GetFocusedRow, Transaction)

        If focussedTRansaction.IsIntern Then

            Dim jDoc As Kernel.JournalDocument = MainApplication.getInstance.JournalDocuments.GetItem(focussedTRansaction.InternalDocumentID)

            MainUI.OpenElementWindow(jDoc)
        End If

    End Sub


    Private Sub transactionsGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mnuShowDetailedPayments = New ToolStripMenuItem(GetText("mnuShowDetailedPayments", "Zahlungseingänge..."), Nothing, AddressOf OnClickShowPayments) 'TODo: NLS
        mnuShowParentInvoice = New ToolStripMenuItem(GetText("mnuShowParentInvoice", "Zeige Rechnung"), Nothing, AddressOf OnClickShowDocument)

        mnuUndelete = New ToolStripMenuItem(GetText("mnuUnDodocumentCancel", "Storno aufheben"), Nothing, AddressOf OnClickUndelete)
        mnuUndelete.Image = My.Resources.Undo

        m_showSeparator = New ToolStripSeparator()


        cmsCommonGridMenue.Items.Insert(2, mnuShowDetailedPayments)
        cmsCommonGridMenue.Items.Insert(3, mnuShowParentInvoice)
        ' Undelete an den "Delete" - Button hängen
        cmsCommonGridMenue.Items.Insert(cmsCommonGridMenue.Items.IndexOf(mnuDelete), mnuUndelete)

        cmsCommonGridMenue.Items.Insert(5, m_showSeparator)  ' Trennstrich

        mnuDelete.Text = GetText("mnuDeleteOrCancel", "Löschen/Stornieren")

    End Sub

    <DebuggerStepThrough()> _
    Friend Overrides Sub CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs)
        MyBase.CustomDrawRowIndicator(sender, e)

        If e.Info.IsRowIndicator Then
            Dim trans As Transaction = CType(grvCommonGrid.GetRow(e.RowHandle), Transaction)
            If trans IsNot Nothing Then

                ' Warnung einblenden, wenn ZAhlung fälligkeit erreicht hat

                If trans.IsOverdue Then
                    e.Info.ImageIndex = -1
                    e.Painter.DrawObject(e.Info)
                    Dim r As Rectangle = e.Bounds
                    r.Inflate(-1, -1)

                    Dim x As Integer = CInt(r.X + (r.Width - m_warnsign.Width) / 2)
                    Dim y As Integer = CInt(r.Y + (r.Height - m_warnsign.Height) / 2)
                    e.Graphics.DrawImageUnscaled(m_warnsign, x, y)
                    e.Handled = True
                End If

            End If
        End If


    End Sub

End Class