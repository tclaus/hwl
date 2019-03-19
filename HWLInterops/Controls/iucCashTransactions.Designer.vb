<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucCashTransactions
    Inherits mainControlContainer

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblAddressText = New DevExpress.XtraEditors.LabelControl()
        Me.lblAccount = New DevExpress.XtraEditors.LabelControl()
        Me.lblTransactionDate = New DevExpress.XtraEditors.LabelControl()
        Me.txtDescription = New DevExpress.XtraEditors.TextEdit()
        Me.txtNumber = New DevExpress.XtraEditors.TextEdit()
        Me.datDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
        Me.cobTax = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblTaxRate = New DevExpress.XtraEditors.LabelControl()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.tblControls = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblNumberValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblID = New DevExpress.XtraEditors.LabelControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnCashAccount = New DevExpress.XtraEditors.ButtonEdit()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtAmmount = New DevExpress.XtraEditors.TextEdit()
        Me.lblAmmount = New DevExpress.XtraEditors.LabelControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbltxtIncome = New DevExpress.XtraEditors.LabelControl()
        Me.lblSumInbound = New DevExpress.XtraEditors.LabelControl()
        Me.lbltxtOutCome = New DevExpress.XtraEditors.LabelControl()
        Me.lblSumOutbound = New DevExpress.XtraEditors.LabelControl()
        Me.commonGrid = New ClausSoftware.HWLInterops.uicCommonGrid()
        Me.IucDateChooser1 = New ClausSoftware.HWLInterops.iucDateChooser()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbltxtStartSum = New DevExpress.XtraEditors.LabelControl()
        Me.lbltxtendSum = New DevExpress.XtraEditors.LabelControl()
        Me.lblStartingSum = New DevExpress.XtraEditors.LabelControl()
        Me.lblEndingSum = New DevExpress.XtraEditors.LabelControl()
        Me.lbltxtTotalCashToday = New DevExpress.XtraEditors.LabelControl()
        Me.lblTotalCashToday = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tblControls.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.btnCashAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.txtAmmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAddressText
        '
        Me.lblAddressText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddressText.Appearance.Options.UseFont = True
        Me.lblAddressText.Location = New System.Drawing.Point(3, 9)
        Me.lblAddressText.Name = "lblAddressText"
        Me.lblAddressText.Size = New System.Drawing.Size(89, 15)
        Me.lblAddressText.TabIndex = 1
        Me.lblAddressText.Text = "Buchung von/an"
        '
        'lblAccount
        '
        Me.lblAccount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount.Appearance.Options.UseFont = True
        Me.lblAccount.Location = New System.Drawing.Point(3, 9)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(63, 15)
        Me.lblAccount.TabIndex = 1
        Me.lblAccount.Text = "Kostenstelle"
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionDate.Appearance.Options.UseFont = True
        Me.lblTransactionDate.Location = New System.Drawing.Point(3, 9)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(64, 15)
        Me.lblTransactionDate.TabIndex = 1
        Me.lblTransactionDate.Text = "Belegdatum"
        '
        'txtDescription
        '
        Me.txtDescription.AllowDrop = True
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(3, 33)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Properties.Appearance.Options.UseFont = True
        Me.txtDescription.Properties.MaxLength = 250
        Me.txtDescription.Size = New System.Drawing.Size(171, 22)
        Me.txtDescription.TabIndex = 0
        '
        'txtNumber
        '
        Me.txtNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumber.Location = New System.Drawing.Point(162, 9)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumber.Properties.Appearance.Options.UseFont = True
        Me.txtNumber.Properties.MaxLength = 250
        Me.txtNumber.Size = New System.Drawing.Size(489, 22)
        Me.txtNumber.TabIndex = 0
        '
        'datDate
        '
        Me.datDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datDate.EditValue = Nothing
        Me.datDate.Location = New System.Drawing.Point(3, 33)
        Me.datDate.Name = "datDate"
        Me.datDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datDate.Properties.Appearance.Options.UseFont = True
        Me.datDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datDate.Size = New System.Drawing.Size(116, 22)
        Me.datDate.TabIndex = 0
        '
        'lblDescription
        '
        Me.lblDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Appearance.Options.UseFont = True
        Me.lblDescription.Location = New System.Drawing.Point(3, 13)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(125, 15)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Buchungstext/Nummer"
        '
        'cobTax
        '
        Me.cobTax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cobTax.Location = New System.Drawing.Point(7, 33)
        Me.cobTax.Name = "cobTax"
        Me.cobTax.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobTax.Properties.Appearance.Options.UseFont = True
        Me.cobTax.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cobTax.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cobTax.Size = New System.Drawing.Size(109, 22)
        Me.cobTax.TabIndex = 0
        '
        'lblTaxRate
        '
        Me.lblTaxRate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxRate.Appearance.Options.UseFont = True
        Me.lblTaxRate.Location = New System.Drawing.Point(6, 9)
        Me.lblTaxRate.Name = "lblTaxRate"
        Me.lblTaxRate.Size = New System.Drawing.Size(53, 15)
        Me.lblTaxRate.TabIndex = 1
        Me.lblTaxRate.Text = "Steuersatz"
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadioGroup1.Location = New System.Drawing.Point(0, 0)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.RadioGroup1.Properties.Appearance.Options.UseBackColor = True
        Me.RadioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Einnahme"), New DevExpress.XtraEditors.Controls.RadioGroupItem(Nothing, "Ausgabe")})
        Me.RadioGroup1.Size = New System.Drawing.Size(105, 58)
        Me.RadioGroup1.TabIndex = 0
        '
        'tblControls
        '
        Me.tblControls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblControls.ColumnCount = 7
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.370975!))
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.66594!))
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.93884!))
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.37061!))
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.77796!))
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.76167!))
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.11401!))
        Me.tblControls.Controls.Add(Me.Panel8, 0, 0)
        Me.tblControls.Controls.Add(Me.Panel1, 1, 0)
        Me.tblControls.Controls.Add(Me.Panel2, 2, 0)
        Me.tblControls.Controls.Add(Me.Panel4, 3, 0)
        Me.tblControls.Controls.Add(Me.Panel5, 4, 0)
        Me.tblControls.Controls.Add(Me.Panel6, 5, 0)
        Me.tblControls.Controls.Add(Me.Panel7, 6, 0)
        Me.tblControls.Controls.Add(Me.Panel3, 0, 1)
        Me.tblControls.Location = New System.Drawing.Point(3, 3)
        Me.tblControls.Name = "tblControls"
        Me.tblControls.RowCount = 2
        Me.tblControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.41584!))
        Me.tblControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.58416!))
        Me.tblControls.Size = New System.Drawing.Size(895, 101)
        Me.tblControls.TabIndex = 6
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.lblNumberValue)
        Me.Panel8.Controls.Add(Me.lblID)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(74, 58)
        Me.Panel8.TabIndex = 8
        '
        'lblNumberValue
        '
        Me.lblNumberValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumberValue.Appearance.Options.UseFont = True
        Me.lblNumberValue.Appearance.Options.UseTextOptions = True
        Me.lblNumberValue.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblNumberValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblNumberValue.Location = New System.Drawing.Point(3, 36)
        Me.lblNumberValue.Name = "lblNumberValue"
        Me.lblNumberValue.Size = New System.Drawing.Size(67, 13)
        Me.lblNumberValue.TabIndex = 1
        Me.lblNumberValue.Tag = "DontTranslate"
        Me.lblNumberValue.Text = "0"
        '
        'lblID
        '
        Me.lblID.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Appearance.Options.UseFont = True
        Me.lblID.Location = New System.Drawing.Point(3, 9)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(48, 15)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "Nummer"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.datDate)
        Me.Panel1.Controls.Add(Me.lblTransactionDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(74, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(122, 58)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtDescription)
        Me.Panel2.Controls.Add(Me.lblAddressText)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(196, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(178, 58)
        Me.Panel2.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnCashAccount)
        Me.Panel4.Controls.Add(Me.lblAccount)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(374, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(164, 58)
        Me.Panel4.TabIndex = 3
        '
        'btnCashAccount
        '
        Me.btnCashAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCashAccount.Location = New System.Drawing.Point(3, 32)
        Me.btnCashAccount.Name = "btnCashAccount"
        Me.btnCashAccount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashAccount.Properties.Appearance.Options.UseFont = True
        Me.btnCashAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.btnCashAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.btnCashAccount.Size = New System.Drawing.Size(158, 22)
        Me.btnCashAccount.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.cobTax)
        Me.Panel5.Controls.Add(Me.lblTaxRate)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(538, 0)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(123, 58)
        Me.Panel5.TabIndex = 4
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.RadioGroup1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(661, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(105, 58)
        Me.Panel6.TabIndex = 5
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtAmmount)
        Me.Panel7.Controls.Add(Me.lblAmmount)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(766, 0)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(129, 58)
        Me.Panel7.TabIndex = 7
        '
        'txtAmmount
        '
        Me.txtAmmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmmount.EditValue = 0.0R
        Me.txtAmmount.Location = New System.Drawing.Point(6, 33)
        Me.txtAmmount.Name = "txtAmmount"
        Me.txtAmmount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmmount.Properties.Appearance.Options.UseFont = True
        Me.txtAmmount.Properties.Appearance.Options.UseTextOptions = True
        Me.txtAmmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtAmmount.Properties.DisplayFormat.FormatString = "c"
        Me.txtAmmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmmount.Properties.EditFormat.FormatString = "c"
        Me.txtAmmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmmount.Properties.Mask.EditMask = "c"
        Me.txtAmmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAmmount.Size = New System.Drawing.Size(119, 22)
        Me.txtAmmount.TabIndex = 0
        '
        'lblAmmount
        '
        Me.lblAmmount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmmount.Appearance.Options.UseFont = True
        Me.lblAmmount.Location = New System.Drawing.Point(6, 9)
        Me.lblAmmount.Name = "lblAmmount"
        Me.lblAmmount.Size = New System.Drawing.Size(34, 15)
        Me.lblAmmount.TabIndex = 1
        Me.lblAmmount.Text = "Betrag"
        '
        'Panel3
        '
        Me.tblControls.SetColumnSpan(Me.Panel3, 5)
        Me.Panel3.Controls.Add(Me.lblDescription)
        Me.Panel3.Controls.Add(Me.txtNumber)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 61)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(655, 37)
        Me.Panel3.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbltxtIncome, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSumInbound, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbltxtOutCome, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSumOutbound, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(610, 516)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.82609!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.17391!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(284, 40)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'lbltxtIncome
        '
        Me.lbltxtIncome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxtIncome.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtIncome.Appearance.Options.UseFont = True
        Me.lbltxtIncome.Location = New System.Drawing.Point(79, 3)
        Me.lbltxtIncome.Name = "lbltxtIncome"
        Me.lbltxtIncome.Size = New System.Drawing.Size(60, 15)
        Me.lbltxtIncome.TabIndex = 8
        Me.lbltxtIncome.Text = "Einnahmen"
        '
        'lblSumInbound
        '
        Me.lblSumInbound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumInbound.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumInbound.Appearance.Options.UseFont = True
        Me.lblSumInbound.Location = New System.Drawing.Point(125, 22)
        Me.lblSumInbound.Name = "lblSumInbound"
        Me.lblSumInbound.Size = New System.Drawing.Size(14, 15)
        Me.lblSumInbound.TabIndex = 8
        Me.lblSumInbound.Tag = "DontTranslate"
        Me.lblSumInbound.Text = "0€"
        '
        'lbltxtOutCome
        '
        Me.lbltxtOutCome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxtOutCome.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtOutCome.Appearance.Options.UseFont = True
        Me.lbltxtOutCome.Location = New System.Drawing.Point(228, 3)
        Me.lbltxtOutCome.Name = "lbltxtOutCome"
        Me.lbltxtOutCome.Size = New System.Drawing.Size(53, 15)
        Me.lbltxtOutCome.TabIndex = 8
        Me.lbltxtOutCome.Text = "Ausgaben"
        '
        'lblSumOutbound
        '
        Me.lblSumOutbound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumOutbound.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumOutbound.Appearance.Options.UseFont = True
        Me.lblSumOutbound.Location = New System.Drawing.Point(267, 22)
        Me.lblSumOutbound.Name = "lblSumOutbound"
        Me.lblSumOutbound.Size = New System.Drawing.Size(14, 15)
        Me.lblSumOutbound.TabIndex = 8
        Me.lblSumOutbound.Tag = "DontTranslate"
        Me.lblSumOutbound.Text = "0€"
        '
        'commonGrid
        '
        Me.commonGrid.AllowNewRow = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.commonGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.commonGrid.Context = Nothing
        Me.commonGrid.Editable = False
        Me.commonGrid.Location = New System.Drawing.Point(0, 111)
        Me.commonGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.commonGrid.Name = "commonGrid"
        Me.commonGrid.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.commonGrid.ShowFilterRow = False
        Me.commonGrid.Size = New System.Drawing.Size(895, 397)
        Me.commonGrid.TabIndex = 0
        '
        'IucDateChooser1
        '
        Me.IucDateChooser1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IucDateChooser1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.IucDateChooser1.Appearance.Options.UseBackColor = True
        Me.IucDateChooser1.Location = New System.Drawing.Point(0, 516)
        Me.IucDateChooser1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.IucDateChooser1.Name = "IucDateChooser1"
        Me.IucDateChooser1.Size = New System.Drawing.Size(542, 112)
        Me.IucDateChooser1.TabIndex = 8
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.72727!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.27273!))
        Me.TableLayoutPanel2.Controls.Add(Me.lbltxtStartSum, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbltxtendSum, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblStartingSum, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblEndingSum, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lbltxtTotalCashToday, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblTotalCashToday, 1, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(610, 562)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(285, 63)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'lbltxtStartSum
        '
        Me.lbltxtStartSum.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtStartSum.Appearance.Options.UseFont = True
        Me.lbltxtStartSum.Location = New System.Drawing.Point(3, 3)
        Me.lbltxtStartSum.Name = "lbltxtStartSum"
        Me.lbltxtStartSum.Size = New System.Drawing.Size(123, 15)
        Me.lbltxtStartSum.TabIndex = 0
        Me.lbltxtStartSum.Text = "Anfangsbestand am {0}"
        '
        'lbltxtendSum
        '
        Me.lbltxtendSum.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtendSum.Appearance.Options.UseFont = True
        Me.lbltxtendSum.Location = New System.Drawing.Point(3, 24)
        Me.lbltxtendSum.Name = "lbltxtendSum"
        Me.lbltxtendSum.Size = New System.Drawing.Size(79, 15)
        Me.lbltxtendSum.TabIndex = 0
        Me.lbltxtendSum.Text = "Bestand am {0}"
        '
        'lblStartingSum
        '
        Me.lblStartingSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStartingSum.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartingSum.Appearance.Options.UseFont = True
        Me.lblStartingSum.Location = New System.Drawing.Point(268, 3)
        Me.lblStartingSum.Name = "lblStartingSum"
        Me.lblStartingSum.Size = New System.Drawing.Size(14, 15)
        Me.lblStartingSum.TabIndex = 0
        Me.lblStartingSum.Tag = "DontTranslate"
        Me.lblStartingSum.Text = "0€"
        '
        'lblEndingSum
        '
        Me.lblEndingSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEndingSum.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndingSum.Appearance.Options.UseFont = True
        Me.lblEndingSum.Location = New System.Drawing.Point(268, 24)
        Me.lblEndingSum.Name = "lblEndingSum"
        Me.lblEndingSum.Size = New System.Drawing.Size(14, 15)
        Me.lblEndingSum.TabIndex = 0
        Me.lblEndingSum.Tag = "DontTranslate"
        Me.lblEndingSum.Text = "0€"
        '
        'lbltxtTotalCashToday
        '
        Me.lbltxtTotalCashToday.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtTotalCashToday.Appearance.Options.UseFont = True
        Me.lbltxtTotalCashToday.Location = New System.Drawing.Point(3, 45)
        Me.lbltxtTotalCashToday.Name = "lbltxtTotalCashToday"
        Me.lbltxtTotalCashToday.Size = New System.Drawing.Size(65, 15)
        Me.lbltxtTotalCashToday.TabIndex = 1
        Me.lbltxtTotalCashToday.Text = "Endbestand:"
        '
        'lblTotalCashToday
        '
        Me.lblTotalCashToday.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCashToday.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCashToday.Appearance.Options.UseFont = True
        Me.lblTotalCashToday.Location = New System.Drawing.Point(268, 45)
        Me.lblTotalCashToday.Name = "lblTotalCashToday"
        Me.lblTotalCashToday.Size = New System.Drawing.Size(14, 15)
        Me.lblTotalCashToday.TabIndex = 2
        Me.lblTotalCashToday.Text = "0€"
        '
        'iucCashTransactions
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.IucDateChooser1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.tblControls)
        Me.Controls.Add(Me.commonGrid)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "iucCashTransactions"
        Me.Size = New System.Drawing.Size(900, 628)
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tblControls.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.btnCashAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.txtAmmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents commonGrid As ClausSoftware.HWLInterops.uicCommonGrid
    Friend WithEvents lblAddressText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblAccount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTransactionDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents datDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cobTax As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblTaxRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents tblControls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbltxtOutCome As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbltxtIncome As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSumInbound As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSumOutbound As DevExpress.XtraEditors.LabelControl
    Friend WithEvents IucDateChooser1 As ClausSoftware.HWLInterops.iucDateChooser
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbltxtStartSum As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbltxtendSum As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblStartingSum As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblEndingSum As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents txtAmmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblAmmount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents lblNumberValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCashAccount As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbltxtTotalCashToday As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTotalCashToday As DevExpress.XtraEditors.LabelControl

End Class
