Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucTransactions
    Inherits mainControlContainer

    'iucTransactions overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.datItemDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblTransactionDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblTransactionAddress = New DevExpress.XtraEditors.LabelControl()
        Me.cobAddressList = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cobTaxRates = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblTaxrate = New DevExpress.XtraEditors.LabelControl()
        Me.lblAccount = New DevExpress.XtraEditors.LabelControl()
        Me.txtDescription = New DevExpress.XtraEditors.TextEdit()
        Me.txtAmmount = New DevExpress.XtraEditors.TextEdit()
        Me.radMoneyFlow = New DevExpress.XtraEditors.RadioGroup()
        Me.lblAmmount = New DevExpress.XtraEditors.LabelControl()
        Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
        Me.chkIsPaid = New DevExpress.XtraEditors.CheckEdit()
        Me.radPaidOn = New DevExpress.XtraEditors.RadioGroup()
        Me.pnlValues = New System.Windows.Forms.Panel()
        Me.grdTaxValues = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTaxName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTaxSum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblReceiveables = New DevExpress.XtraEditors.LabelControl()
        Me.lblPayables = New DevExpress.XtraEditors.LabelControl()
        Me.lblReveiveableValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblPayablesValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblItemID = New DevExpress.XtraEditors.LabelControl()
        Me.lblTransactionID = New DevExpress.XtraEditors.LabelControl()
        Me.lbInvoiceID = New DevExpress.XtraEditors.LabelControl()
        Me.txtItemID = New DevExpress.XtraEditors.TextEdit()
        Me.tableMainData = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtCashAccount = New DevExpress.XtraEditors.ButtonEdit()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.IucDateChooser1 = New ClausSoftware.HWLInterops.iucDateChooser()
        Me.commonGrid = New ClausSoftware.HWLInterops.transactionsGrid()
        Me.btnPayments = New DevExpress.XtraEditors.SimpleButton()
        Me.lblUnpaidAmmounts = New DevExpress.XtraEditors.LabelControl()
        Me.lblUnpaidAmmountValue = New DevExpress.XtraEditors.LabelControl()
        CType(Me.datItemDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datItemDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobAddressList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobTaxRates.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radMoneyFlow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsPaid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radPaidOn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlValues.SuspendLayout()
        CType(Me.grdTaxValues, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.txtItemID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tableMainData.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.txtCashAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'datItemDate
        '
        Me.datItemDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datItemDate.EditValue = Nothing
        Me.datItemDate.Location = New System.Drawing.Point(3, 31)
        Me.datItemDate.Name = "datItemDate"
        Me.datItemDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datItemDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datItemDate.Size = New System.Drawing.Size(95, 20)
        Me.datItemDate.TabIndex = 0
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.Location = New System.Drawing.Point(3, 8)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(53, 13)
        Me.lblTransactionDate.TabIndex = 2
        Me.lblTransactionDate.Text = "Buchdatum"
        '
        'lblTransactionAddress
        '
        Me.lblTransactionAddress.Location = New System.Drawing.Point(3, 8)
        Me.lblTransactionAddress.Name = "lblTransactionAddress"
        Me.lblTransactionAddress.Size = New System.Drawing.Size(39, 13)
        Me.lblTransactionAddress.TabIndex = 3
        Me.lblTransactionAddress.Text = "Adresse"
        '
        'cobAddressList
        '
        Me.cobAddressList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cobAddressList.Location = New System.Drawing.Point(3, 29)
        Me.cobAddressList.Name = "cobAddressList"
        Me.cobAddressList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Global.ClausSoftware.HWLInterops.My.Resources.Resources.view, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", "editor", Nothing, False)})
        Me.cobAddressList.Properties.DropDownRows = 12
        Me.cobAddressList.Properties.PopupSizeable = True
        Me.cobAddressList.Properties.Sorted = True
        Me.cobAddressList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cobAddressList.Size = New System.Drawing.Size(253, 22)
        Me.cobAddressList.TabIndex = 0
        '
        'cobTaxRates
        '
        Me.cobTaxRates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cobTaxRates.Location = New System.Drawing.Point(3, 31)
        Me.cobTaxRates.Name = "cobTaxRates"
        Me.cobTaxRates.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", "edit", Nothing, True)})
        Me.cobTaxRates.Size = New System.Drawing.Size(125, 20)
        Me.cobTaxRates.TabIndex = 0
        '
        'lblTaxrate
        '
        Me.lblTaxrate.Location = New System.Drawing.Point(3, 8)
        Me.lblTaxrate.Name = "lblTaxrate"
        Me.lblTaxrate.Size = New System.Drawing.Size(26, 13)
        Me.lblTaxrate.TabIndex = 8
        Me.lblTaxrate.Text = "MwSt"
        '
        'lblAccount
        '
        Me.lblAccount.Location = New System.Drawing.Point(3, 8)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(58, 13)
        Me.lblAccount.TabIndex = 9
        Me.lblAccount.Text = "Kostenstelle"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(3, 28)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Properties.MaxLength = 250
        Me.txtDescription.Properties.NullValuePrompt = "Geben Sie eine Bezeichnung für diese Rechnung an"
        Me.txtDescription.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtDescription.Size = New System.Drawing.Size(467, 20)
        Me.txtDescription.TabIndex = 0
        '
        'txtAmmount
        '
        Me.txtAmmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmmount.Location = New System.Drawing.Point(3, 28)
        Me.txtAmmount.Name = "txtAmmount"
        Me.txtAmmount.Properties.Appearance.Options.UseTextOptions = True
        Me.txtAmmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtAmmount.Properties.DisplayFormat.FormatString = "c"
        Me.txtAmmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtAmmount.Properties.EditFormat.FormatString = "c"
        Me.txtAmmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtAmmount.Properties.Mask.EditMask = "f"
        Me.txtAmmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAmmount.Properties.NullValuePrompt = "Rechnungsbetrag"
        Me.txtAmmount.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtAmmount.Size = New System.Drawing.Size(100, 20)
        Me.txtAmmount.TabIndex = 0
        '
        'radMoneyFlow
        '
        Me.radMoneyFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.radMoneyFlow.Location = New System.Drawing.Point(709, 0)
        Me.radMoneyFlow.Margin = New System.Windows.Forms.Padding(0)
        Me.radMoneyFlow.Name = "radMoneyFlow"
        Me.radMoneyFlow.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.radMoneyFlow.Properties.Appearance.Options.UseBackColor = True
        Me.radMoneyFlow.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.radMoneyFlow.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Einnahme"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Ausgabe")})
        Me.radMoneyFlow.Size = New System.Drawing.Size(114, 54)
        Me.radMoneyFlow.TabIndex = 0
        '
        'lblAmmount
        '
        Me.lblAmmount.Location = New System.Drawing.Point(3, 8)
        Me.lblAmmount.Name = "lblAmmount"
        Me.lblAmmount.Size = New System.Drawing.Size(32, 13)
        Me.lblAmmount.TabIndex = 13
        Me.lblAmmount.Text = "Betrag"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.Location = New System.Drawing.Point(3, 8)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(64, 13)
        Me.lblDescription.TabIndex = 14
        Me.lblDescription.Text = "Beschreibung"
        '
        'chkIsPaid
        '
        Me.chkIsPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIsPaid.Location = New System.Drawing.Point(832, 35)
        Me.chkIsPaid.Name = "chkIsPaid"
        Me.chkIsPaid.Properties.AutoWidth = True
        Me.chkIsPaid.Properties.Caption = "Vollständig bezahlt an:"
        Me.chkIsPaid.Size = New System.Drawing.Size(131, 19)
        Me.chkIsPaid.TabIndex = 1
        '
        'radPaidOn
        '
        Me.radPaidOn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radPaidOn.Location = New System.Drawing.Point(834, 65)
        Me.radPaidOn.Name = "radPaidOn"
        Me.radPaidOn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.radPaidOn.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Bank"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Kasse")})
        Me.radPaidOn.Size = New System.Drawing.Size(142, 54)
        Me.radPaidOn.TabIndex = 2
        '
        'pnlValues
        '
        Me.pnlValues.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlValues.Controls.Add(Me.grdTaxValues)
        Me.pnlValues.Controls.Add(Me.TableLayoutPanel2)
        Me.pnlValues.Location = New System.Drawing.Point(663, 472)
        Me.pnlValues.Name = "pnlValues"
        Me.pnlValues.Size = New System.Drawing.Size(317, 128)
        Me.pnlValues.TabIndex = 18
        '
        'grdTaxValues
        '
        Me.grdTaxValues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdTaxValues.Location = New System.Drawing.Point(3, 54)
        Me.grdTaxValues.MainView = Me.GridView1
        Me.grdTaxValues.Name = "grdTaxValues"
        Me.grdTaxValues.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.grdTaxValues.Size = New System.Drawing.Size(310, 69)
        Me.grdTaxValues.TabIndex = 2
        Me.grdTaxValues.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTaxName, Me.colTaxSum})
        Me.GridView1.GridControl = Me.grdTaxValues
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        '
        'colTaxName
        '
        Me.colTaxName.Caption = "Steuername"
        Me.colTaxName.FieldName = "Tax.DisplayName"
        Me.colTaxName.Name = "colTaxName"
        Me.colTaxName.Visible = True
        Me.colTaxName.VisibleIndex = 0
        '
        'colTaxSum
        '
        Me.colTaxSum.Caption = "Betrag"
        Me.colTaxSum.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colTaxSum.FieldName = "ValueInTax"
        Me.colTaxSum.Name = "colTaxSum"
        Me.colTaxSum.Visible = True
        Me.colTaxSum.VisibleIndex = 1
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "c"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.ReadOnly = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblReceiveables, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPayables, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblReveiveableValue, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPayablesValue, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblUnpaidAmmounts, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblUnpaidAmmountValue, 2, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(310, 45)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'lblReceiveables
        '
        Me.lblReceiveables.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReceiveables.Location = New System.Drawing.Point(48, 3)
        Me.lblReceiveables.Name = "lblReceiveables"
        Me.lblReceiveables.Size = New System.Drawing.Size(52, 13)
        Me.lblReceiveables.TabIndex = 0
        Me.lblReceiveables.Text = "Einnahmen"
        '
        'lblPayables
        '
        Me.lblPayables.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPayables.Location = New System.Drawing.Point(155, 3)
        Me.lblPayables.Name = "lblPayables"
        Me.lblPayables.Size = New System.Drawing.Size(48, 13)
        Me.lblPayables.TabIndex = 0
        Me.lblPayables.Text = "Ausgaben"
        '
        'lblReveiveableValue
        '
        Me.lblReveiveableValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReveiveableValue.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReveiveableValue.Appearance.Options.UseFont = True
        Me.lblReveiveableValue.Location = New System.Drawing.Point(93, 25)
        Me.lblReveiveableValue.Name = "lblReveiveableValue"
        Me.lblReveiveableValue.Size = New System.Drawing.Size(7, 13)
        Me.lblReveiveableValue.TabIndex = 0
        Me.lblReveiveableValue.Tag = "DontTranslate"
        Me.lblReveiveableValue.Text = "0"
        '
        'lblPayablesValue
        '
        Me.lblPayablesValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPayablesValue.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayablesValue.Appearance.Options.UseFont = True
        Me.lblPayablesValue.Location = New System.Drawing.Point(196, 25)
        Me.lblPayablesValue.Name = "lblPayablesValue"
        Me.lblPayablesValue.Size = New System.Drawing.Size(7, 13)
        Me.lblPayablesValue.TabIndex = 0
        Me.lblPayablesValue.Tag = "DontTranslate"
        Me.lblPayablesValue.Text = "0"
        '
        'lblItemID
        '
        Me.lblItemID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItemID.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemID.Appearance.Options.UseFont = True
        Me.lblItemID.Appearance.Options.UseTextOptions = True
        Me.lblItemID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblItemID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblItemID.Location = New System.Drawing.Point(3, 27)
        Me.lblItemID.Name = "lblItemID"
        Me.lblItemID.Size = New System.Drawing.Size(59, 15)
        Me.lblItemID.TabIndex = 19
        Me.lblItemID.Text = "0"
        '
        'lblTransactionID
        '
        Me.lblTransactionID.Location = New System.Drawing.Point(3, 8)
        Me.lblTransactionID.Name = "lblTransactionID"
        Me.lblTransactionID.Size = New System.Drawing.Size(39, 13)
        Me.lblTransactionID.TabIndex = 19
        Me.lblTransactionID.Text = "Nummer"
        '
        'lbInvoiceID
        '
        Me.lbInvoiceID.Location = New System.Drawing.Point(3, 8)
        Me.lbInvoiceID.Name = "lbInvoiceID"
        Me.lbInvoiceID.Size = New System.Drawing.Size(91, 13)
        Me.lbInvoiceID.TabIndex = 20
        Me.lbInvoiceID.Text = "Rechnungsnummer"
        '
        'txtItemID
        '
        Me.txtItemID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtItemID.Location = New System.Drawing.Point(3, 28)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.Properties.MaxLength = 250
        Me.txtItemID.Properties.NullValuePrompt = "Nummer d. Rechnung"
        Me.txtItemID.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtItemID.Size = New System.Drawing.Size(120, 20)
        Me.txtItemID.TabIndex = 0
        '
        'tableMainData
        '
        Me.tableMainData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tableMainData.ColumnCount = 4
        Me.tableMainData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableMainData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128.0!))
        Me.tableMainData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.tableMainData.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.tableMainData.Controls.Add(Me.Panel2, 0, 0)
        Me.tableMainData.Controls.Add(Me.Panel3, 1, 0)
        Me.tableMainData.Controls.Add(Me.Panel4, 2, 0)
        Me.tableMainData.Controls.Add(Me.radMoneyFlow, 3, 0)
        Me.tableMainData.Location = New System.Drawing.Point(3, 65)
        Me.tableMainData.Name = "tableMainData"
        Me.tableMainData.RowCount = 1
        Me.tableMainData.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableMainData.Size = New System.Drawing.Size(823, 54)
        Me.tableMainData.TabIndex = 22
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtDescription)
        Me.Panel2.Controls.Add(Me.lblDescription)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(474, 54)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtItemID)
        Me.Panel3.Controls.Add(Me.lbInvoiceID)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(474, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(128, 54)
        Me.Panel3.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.txtAmmount)
        Me.Panel4.Controls.Add(Me.lblAmmount)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(602, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(107, 54)
        Me.Panel4.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel9, 4, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(823, 54)
        Me.TableLayoutPanel1.TabIndex = 23
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblTransactionID)
        Me.Panel5.Controls.Add(Me.lblItemID)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(72, 54)
        Me.Panel5.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.datItemDate)
        Me.Panel6.Controls.Add(Me.lblTransactionDate)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(72, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(101, 54)
        Me.Panel6.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lblTransactionAddress)
        Me.Panel7.Controls.Add(Me.cobAddressList)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(173, 0)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(259, 54)
        Me.Panel7.TabIndex = 2
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.txtCashAccount)
        Me.Panel8.Controls.Add(Me.lblAccount)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(432, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(259, 54)
        Me.Panel8.TabIndex = 3
        '
        'txtCashAccount
        '
        Me.txtCashAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCashAccount.Location = New System.Drawing.Point(7, 29)
        Me.txtCashAccount.Name = "txtCashAccount"
        Me.txtCashAccount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashAccount.Properties.Appearance.Options.UseFont = True
        Me.txtCashAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCashAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtCashAccount.Size = New System.Drawing.Size(249, 22)
        Me.txtCashAccount.TabIndex = 11
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.lblTaxrate)
        Me.Panel9.Controls.Add(Me.cobTaxRates)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(691, 0)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(132, 54)
        Me.Panel9.TabIndex = 4
        '
        'IucDateChooser1
        '
        Me.IucDateChooser1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IucDateChooser1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.IucDateChooser1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IucDateChooser1.Appearance.Options.UseBackColor = True
        Me.IucDateChooser1.Appearance.Options.UseForeColor = True
        Me.IucDateChooser1.Location = New System.Drawing.Point(0, 497)
        Me.IucDateChooser1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.IucDateChooser1.Name = "IucDateChooser1"
        Me.IucDateChooser1.Size = New System.Drawing.Size(542, 107)
        Me.IucDateChooser1.TabIndex = 17
        '
        'commonGrid
        '
        Me.commonGrid.AllowNewRow = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.commonGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.commonGrid.BackColor = System.Drawing.SystemColors.Control
        Me.commonGrid.Context = Nothing
        Me.commonGrid.Editable = False
        Me.commonGrid.ForeColor = System.Drawing.SystemColors.ControlText
        Me.commonGrid.Location = New System.Drawing.Point(0, 126)
        Me.commonGrid.MainUI = Nothing
        Me.commonGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.commonGrid.Name = "commonGrid"
        Me.commonGrid.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.commonGrid.ShowFilterRow = False
        Me.commonGrid.Size = New System.Drawing.Size(980, 339)
        Me.commonGrid.TabIndex = 0
        '
        'btnPayments
        '
        Me.btnPayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPayments.Enabled = False
        Me.btnPayments.Location = New System.Drawing.Point(834, 0)
        Me.btnPayments.Name = "btnPayments"
        Me.btnPayments.Size = New System.Drawing.Size(142, 33)
        Me.btnPayments.TabIndex = 0
        Me.btnPayments.Text = "Zahlungseingänge..."
        '
        'lblUnpaidAmmounts
        '
        Me.lblUnpaidAmmounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnpaidAmmounts.Location = New System.Drawing.Point(232, 3)
        Me.lblUnpaidAmmounts.Name = "lblUnpaidAmmounts"
        Me.lblUnpaidAmmounts.Size = New System.Drawing.Size(75, 13)
        Me.lblUnpaidAmmounts.TabIndex = 1
        Me.lblUnpaidAmmounts.Text = "Offene Beträge"
        '
        'lblUnpaidAmmountValue
        '
        Me.lblUnpaidAmmountValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUnpaidAmmountValue.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnpaidAmmountValue.Appearance.Options.UseFont = True
        Me.lblUnpaidAmmountValue.Location = New System.Drawing.Point(300, 25)
        Me.lblUnpaidAmmountValue.Name = "lblUnpaidAmmountValue"
        Me.lblUnpaidAmmountValue.Size = New System.Drawing.Size(7, 13)
        Me.lblUnpaidAmmountValue.TabIndex = 2
        Me.lblUnpaidAmmountValue.Tag = "DontTranslate"
        Me.lblUnpaidAmmountValue.Text = "0"
        '
        'iucTransactions
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnPayments)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.tableMainData)
        Me.Controls.Add(Me.pnlValues)
        Me.Controls.Add(Me.IucDateChooser1)
        Me.Controls.Add(Me.radPaidOn)
        Me.Controls.Add(Me.chkIsPaid)
        Me.Controls.Add(Me.commonGrid)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "iucTransactions"
        Me.Size = New System.Drawing.Size(985, 600)
        CType(Me.datItemDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datItemDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobAddressList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobTaxRates.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radMoneyFlow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsPaid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radPaidOn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlValues.ResumeLayout(False)
        CType(Me.grdTaxValues, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.txtItemID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tableMainData.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.txtCashAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents commonGrid As HWLInterops.transactionsGrid
    Friend WithEvents datItemDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblTransactionDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTransactionAddress As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cobAddressList As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cobTaxRates As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblTaxrate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblAccount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAmmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents radMoneyFlow As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents lblAmmount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkIsPaid As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents radPaidOn As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents IucDateChooser1 As HWLInterops.iucDateChooser
    Friend WithEvents pnlValues As System.Windows.Forms.Panel
    Friend WithEvents lblItemID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTransactionID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbInvoiceID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtItemID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tableMainData As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblReceiveables As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPayables As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblReveiveableValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPayablesValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents grdTaxValues As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTaxName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTaxSum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents btnPayments As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCashAccount As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblUnpaidAmmounts As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUnpaidAmmountValue As DevExpress.XtraEditors.LabelControl

End Class
