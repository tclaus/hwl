<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayableDetails
    Inherits ClausSoftware.HWLInterops.BaseForm

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.lblInvoiceNumber = New DevExpress.XtraEditors.LabelControl()
        Me.lblDocumentNumber = New DevExpress.XtraEditors.LabelControl()
        Me.lblSumTotal = New DevExpress.XtraEditors.LabelControl()
        Me.lblInvoiceDate = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSumTotalValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblSumPaid = New DevExpress.XtraEditors.LabelControl()
        Me.lblSumPaidValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblPayDate = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDateToPayValue = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lblNewPayment = New DevExpress.XtraEditors.LabelControl()
        Me.datDate = New DevExpress.XtraEditors.DateEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.idDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDownPayment = New DevExpress.XtraEditors.TextEdit()
        Me.grpIncomeValue = New DevExpress.XtraEditors.GroupControl()
        Me.grdDownPayments = New DevExpress.XtraGrid.GridControl()
        Me.grvDownPayments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.currencyedit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.picState = New DevExpress.XtraEditors.PictureEdit()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.lblInvoiceText = New DevExpress.XtraEditors.LabelControl()
        Me.btnsetReminder = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.datDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDownPayment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpIncomeValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpIncomeValue.SuspendLayout()
        CType(Me.grdDownPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvDownPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.currencyedit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picState.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblInvoiceNumber
        '
        Me.lblInvoiceNumber.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceNumber.Appearance.Options.UseFont = True
        Me.lblInvoiceNumber.Location = New System.Drawing.Point(3, 3)
        Me.lblInvoiceNumber.Name = "lblInvoiceNumber"
        Me.lblInvoiceNumber.Size = New System.Drawing.Size(95, 16)
        Me.lblInvoiceNumber.TabIndex = 0
        Me.lblInvoiceNumber.Text = "Rechnung Nr.: "
        '
        'lblDocumentNumber
        '
        Me.lblDocumentNumber.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentNumber.Appearance.Options.UseFont = True
        Me.lblDocumentNumber.Location = New System.Drawing.Point(104, 3)
        Me.lblDocumentNumber.Name = "lblDocumentNumber"
        Me.lblDocumentNumber.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDocumentNumber.Size = New System.Drawing.Size(90, 16)
        Me.lblDocumentNumber.TabIndex = 0
        Me.lblDocumentNumber.Tag = "DontTranslate"
        Me.lblDocumentNumber.Text = "1234456789"
        '
        'lblSumTotal
        '
        Me.lblSumTotal.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumTotal.Appearance.Options.UseFont = True
        Me.lblSumTotal.Location = New System.Drawing.Point(3, 3)
        Me.lblSumTotal.Name = "lblSumTotal"
        Me.lblSumTotal.Size = New System.Drawing.Size(37, 15)
        Me.lblSumTotal.TabIndex = 0
        Me.lblSumTotal.Text = "Betrag:"
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceDate.Appearance.Options.UseFont = True
        Me.lblInvoiceDate.Location = New System.Drawing.Point(200, 3)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblInvoiceDate.Size = New System.Drawing.Size(92, 16)
        Me.lblInvoiceDate.TabIndex = 0
        Me.lblInvoiceDate.Tag = "DontTranslate"
        Me.lblInvoiceDate.Text = "vom 1.1.2009"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblInvoiceNumber, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblInvoiceDate, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDocumentNumber, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(65, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(357, 22)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblSumTotalValue
        '
        Me.lblSumTotalValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumTotalValue.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumTotalValue.Appearance.Options.UseFont = True
        Me.lblSumTotalValue.Location = New System.Drawing.Point(179, 3)
        Me.lblSumTotalValue.Name = "lblSumTotalValue"
        Me.lblSumTotalValue.Size = New System.Drawing.Size(21, 13)
        Me.lblSumTotalValue.TabIndex = 0
        Me.lblSumTotalValue.Tag = "DontTranslate"
        Me.lblSumTotalValue.Text = "123"
        '
        'lblSumPaid
        '
        Me.lblSumPaid.Location = New System.Drawing.Point(3, 24)
        Me.lblSumPaid.Name = "lblSumPaid"
        Me.lblSumPaid.Size = New System.Drawing.Size(85, 13)
        Me.lblSumPaid.TabIndex = 0
        Me.lblSumPaid.Text = "Summe Eingänge:"
        '
        'lblSumPaidValue
        '
        Me.lblSumPaidValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSumPaidValue.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumPaidValue.Appearance.Options.UseFont = True
        Me.lblSumPaidValue.Location = New System.Drawing.Point(179, 24)
        Me.lblSumPaidValue.Name = "lblSumPaidValue"
        Me.lblSumPaidValue.Size = New System.Drawing.Size(21, 13)
        Me.lblSumPaidValue.TabIndex = 0
        Me.lblSumPaidValue.Tag = "DontTranslate"
        Me.lblSumPaidValue.Text = "123"
        '
        'lblPayDate
        '
        Me.lblPayDate.Location = New System.Drawing.Point(3, 43)
        Me.lblPayDate.Name = "lblPayDate"
        Me.lblPayDate.Size = New System.Drawing.Size(65, 13)
        Me.lblPayDate.TabIndex = 0
        Me.lblPayDate.Text = "Zahlungsziel: "
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.63547!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.36453!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblSumPaid, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDateToPayValue, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSumTotal, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPayDate, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSumTotalValue, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSumPaidValue, 1, 1)
        Me.TableLayoutPanel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(5, 23)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(203, 67)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'lblDateToPayValue
        '
        Me.lblDateToPayValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateToPayValue.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateToPayValue.Appearance.Options.UseFont = True
        Me.lblDateToPayValue.Location = New System.Drawing.Point(152, 43)
        Me.lblDateToPayValue.Name = "lblDateToPayValue"
        Me.lblDateToPayValue.Size = New System.Drawing.Size(48, 13)
        Me.lblDateToPayValue.TabIndex = 0
        Me.lblDateToPayValue.Tag = "DontTranslate"
        Me.lblDateToPayValue.Text = "1.1.2009"
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.lblNewPayment)
        Me.GroupControl1.Controls.Add(Me.datDate)
        Me.GroupControl1.Controls.Add(Me.btnAdd)
        Me.GroupControl1.Controls.Add(Me.txtDownPayment)
        Me.GroupControl1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 109)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(410, 123)
        Me.GroupControl1.TabIndex = 3
        Me.GroupControl1.Text = "Forderungen Details"
        '
        'lblNewPayment
        '
        Me.lblNewPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNewPayment.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewPayment.Appearance.Options.UseFont = True
        Me.lblNewPayment.Location = New System.Drawing.Point(299, 26)
        Me.lblNewPayment.Name = "lblNewPayment"
        Me.lblNewPayment.Size = New System.Drawing.Size(78, 15)
        Me.lblNewPayment.TabIndex = 3
        Me.lblNewPayment.Text = "Neue Zahlung:"
        '
        'datDate
        '
        Me.datDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datDate.EditValue = Nothing
        Me.datDate.Location = New System.Drawing.Point(299, 70)
        Me.datDate.MenuManager = Me.BarManager1
        Me.datDate.Name = "datDate"
        Me.datDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datDate.Size = New System.Drawing.Size(106, 20)
        Me.datDate.TabIndex = 1
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.idDelete})
        Me.BarManager1.MaxItemId = 1
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(434, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 379)
        Me.barDockControlBottom.Size = New System.Drawing.Size(434, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 379)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(434, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 379)
        '
        'idDelete
        '
        Me.idDelete.Caption = "Löschen"
        Me.idDelete.Id = 0
        Me.idDelete.Name = "idDelete"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Appearance.Options.UseFont = True
        Me.btnAdd.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Add_16x16
        Me.btnAdd.Location = New System.Drawing.Point(299, 96)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(106, 25)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Hinzufügen"
        '
        'txtDownPayment
        '
        Me.txtDownPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDownPayment.Location = New System.Drawing.Point(299, 45)
        Me.txtDownPayment.MenuManager = Me.BarManager1
        Me.txtDownPayment.Name = "txtDownPayment"
        Me.txtDownPayment.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDownPayment.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtDownPayment.Properties.DisplayFormat.FormatString = "c"
        Me.txtDownPayment.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDownPayment.Properties.EditFormat.FormatString = "c"
        Me.txtDownPayment.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDownPayment.Size = New System.Drawing.Size(103, 20)
        Me.txtDownPayment.TabIndex = 0
        '
        'grpIncomeValue
        '
        Me.grpIncomeValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpIncomeValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpIncomeValue.Appearance.Options.UseFont = True
        Me.grpIncomeValue.AppearanceCaption.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpIncomeValue.AppearanceCaption.Options.UseFont = True
        Me.grpIncomeValue.Controls.Add(Me.grdDownPayments)
        Me.grpIncomeValue.Location = New System.Drawing.Point(12, 238)
        Me.grpIncomeValue.Name = "grpIncomeValue"
        Me.grpIncomeValue.Size = New System.Drawing.Size(410, 100)
        Me.grpIncomeValue.TabIndex = 4
        Me.grpIncomeValue.Text = "Zahlungseingänge"
        '
        'grdDownPayments
        '
        Me.grdDownPayments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDownPayments.Location = New System.Drawing.Point(2, 24)
        Me.grdDownPayments.MainView = Me.grvDownPayments
        Me.grdDownPayments.Name = "grdDownPayments"
        Me.grdDownPayments.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.currencyedit})
        Me.grdDownPayments.Size = New System.Drawing.Size(406, 74)
        Me.grdDownPayments.TabIndex = 0
        Me.grdDownPayments.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvDownPayments})
        '
        'grvDownPayments
        '
        Me.grvDownPayments.GridControl = Me.grdDownPayments
        Me.grvDownPayments.Name = "grvDownPayments"
        Me.grvDownPayments.OptionsCustomization.AllowFilter = False
        Me.grvDownPayments.OptionsCustomization.AllowGroup = False
        Me.grvDownPayments.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.grvDownPayments.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grvDownPayments.OptionsView.ShowGroupPanel = False
        '
        'currencyedit
        '
        Me.currencyedit.AutoHeight = False
        Me.currencyedit.DisplayFormat.FormatString = "c"
        Me.currencyedit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.currencyedit.EditFormat.FormatString = "c"
        Me.currencyedit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.currencyedit.Name = "currencyedit"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(344, 344)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Schliessen"
        '
        'picState
        '
        Me.picState.EditValue = Global.ClausSoftware.HWLInterops.My.Resources.Resources.checkbox_32x32
        Me.picState.Location = New System.Drawing.Point(10, 12)
        Me.picState.Name = "picState"
        Me.picState.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picState.Properties.Appearance.Options.UseBackColor = True
        Me.picState.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picState.Size = New System.Drawing.Size(47, 43)
        Me.picState.TabIndex = 7
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.idDelete)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'lblInvoiceText
        '
        Me.lblInvoiceText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceText.Appearance.Options.UseFont = True
        Me.lblInvoiceText.Appearance.Options.UseTextOptions = True
        Me.lblInvoiceText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lblInvoiceText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblInvoiceText.AutoEllipsis = True
        Me.lblInvoiceText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblInvoiceText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblInvoiceText.Location = New System.Drawing.Point(3, 3)
        Me.lblInvoiceText.Name = "lblInvoiceText"
        Me.lblInvoiceText.Size = New System.Drawing.Size(245, 64)
        Me.lblInvoiceText.TabIndex = 8
        Me.lblInvoiceText.Text = "Rechnungs-Text"
        '
        'btnsetReminder
        '
        Me.btnsetReminder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsetReminder.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsetReminder.Appearance.Options.UseFont = True
        Me.btnsetReminder.Location = New System.Drawing.Point(254, 3)
        Me.btnsetReminder.Name = "btnsetReminder"
        Me.btnsetReminder.Size = New System.Drawing.Size(100, 35)
        Me.btnsetReminder.TabIndex = 9
        Me.btnsetReminder.Text = "Mahnungen..."
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnsetReminder, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblInvoiceText, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(65, 33)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(357, 70)
        Me.TableLayoutPanel3.TabIndex = 14
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Delete
        Me.btnDelete.Location = New System.Drawing.Point(263, 344)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 19
        Me.btnDelete.Text = "Löschen"
        '
        'frmPayableDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(434, 379)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.picState)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpIncomeValue)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 387)
        Me.Name = "frmPayableDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Zahlungseingänge"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.datDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDownPayment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpIncomeValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpIncomeValue.ResumeLayout(False)
        CType(Me.grdDownPayments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvDownPayments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.currencyedit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picState.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblInvoiceNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDocumentNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSumTotal As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblInvoiceDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSumTotalValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSumPaid As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSumPaidValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPayDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grpIncomeValue As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblDateToPayValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents grdDownPayments As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvDownPayments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picState As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents idDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents datDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDownPayment As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblInvoiceText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents currencyedit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents btnsetReminder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblNewPayment As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
End Class
