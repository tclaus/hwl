Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Offers

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class iucBills
        Inherits mainControlContainer

        'iucBills overrides dispose to clean up the component list.
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
            Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
            Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Me.grvItems = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colItemSortOrder = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colItemsCount = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colItemUnit = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repUnitCombo = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
            Me.colItemShortText = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repItemsShortTextB = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            Me.colTaxRate = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repTaxValues = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
            Me.colSinglePriceAfterTax = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repCurrencyValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
            Me.colTotalPriceAfterTax = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colTimeInMinutes = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repTimInMinutes = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
            Me.colInternamItemNumber = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colItemNumber = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colDiscount = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colBasePrice = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colSinglePriceBeforeTax = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colTotalPriceBeforeTax = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colImage = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repPicture = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
            Me.grdItemsList = New DevExpress.XtraGrid.GridControl()
            Me.cmsGridPosition = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.mnuNewItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuCopyPosition = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuInsertPositionFromClipboard = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuDeletePosition = New System.Windows.Forms.ToolStripMenuItem()
            Me.btnCreateDuplicate = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuOpenItemData = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuSyncWithOriginItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuExpandBOMItems = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
            Me.btnConvertTextToArticle = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuHideItemsPrices = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuResetItemsGroupPrice = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuHideItems = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuSetCurrentGroupNameAsDefaultName = New System.Windows.Forms.ToolStripMenuItem()
            Me.grvPositions = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colGroupSortOrder = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colGroupCount = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colGroupShortText = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repItemsShortText = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
            Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repItemPositionNumber = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
            Me.ttcGrid = New DevExpress.Utils.ToolTipController(Me.components)
            Me.splBillsHeaderPane = New DevExpress.XtraEditors.SplitContainerControl()
            Me.tabHeader = New DevExpress.XtraTab.XtraTabControl()
            Me.tabMain = New DevExpress.XtraTab.XtraTabPage()
            Me.pnlTabHeaderSettings = New System.Windows.Forms.TableLayoutPanel()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnAddAddress = New DevExpress.XtraEditors.SimpleButton()
            Me.lblDiscountText = New DevExpress.XtraEditors.LabelControl()
            Me.lblAdressdiscountText = New DevExpress.XtraEditors.LabelControl()
            Me.btnResetAdress = New DevExpress.XtraEditors.SimpleButton()
            Me.btnSearchAdress = New DevExpress.XtraEditors.SimpleButton()
            Me.txtAdresswindow = New DevExpress.XtraEditors.MemoEdit()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
            Me.txtDescription = New DevExpress.XtraEditors.TextEdit()
            Me.txtFooterText = New DevExpress.XtraEditors.MemoExEdit()
            Me.txtHeadText = New DevExpress.XtraEditors.MemoExEdit()
            Me.lblFooterText = New DevExpress.XtraEditors.LabelControl()
            Me.lblHeadText = New DevExpress.XtraEditors.LabelControl()
            Me.tabPayments = New DevExpress.XtraTab.XtraTabPage()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.chkShowWithoutTax = New DevExpress.XtraEditors.CheckEdit()
            Me.lblCashAccount = New DevExpress.XtraEditors.LabelControl()
            Me.btnCashAccount = New DevExpress.XtraEditors.ButtonEdit()
            Me.lblPaymentAccount = New DevExpress.XtraEditors.LabelControl()
            Me.lblPaimantDate = New DevExpress.XtraEditors.LabelControl()
            Me.lblDays = New DevExpress.XtraEditors.LabelControl()
            Me.txtTargetPaymentDays = New DevExpress.XtraEditors.TextEdit()
            Me.radPaimentDate = New DevExpress.XtraEditors.RadioGroup()
            Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
            Me.splBillsFooterPane = New DevExpress.XtraEditors.SplitContainerControl()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.pnlLowerSubPanel = New System.Windows.Forms.Panel()
            Me.lblEarningValue = New DevExpress.XtraEditors.LabelControl()
            Me.lblEarnings = New DevExpress.XtraEditors.LabelControl()
            Me.btnAddArticleGroup = New DevExpress.XtraEditors.SimpleButton()
            Me.talPrices = New System.Windows.Forms.TableLayoutPanel()
            Me.txtNetSumValue = New DevExpress.XtraEditors.TextEdit()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.chkDiscountActive = New DevExpress.XtraEditors.CheckEdit()
            Me.radDiscountType = New DevExpress.XtraEditors.RadioGroup()
            Me.txtDiscountValue = New DevExpress.XtraEditors.TextEdit()
            Me.txtDiscountName = New DevExpress.XtraEditors.TextEdit()
            Me.txtDiscountedValue = New DevExpress.XtraEditors.TextEdit()
            Me.lblSummValueAfterTax = New DevExpress.XtraEditors.LabelControl()
            Me.txtSumValueAfterTax = New DevExpress.XtraEditors.TextEdit()
            Me.lblTaxValueText2 = New DevExpress.XtraEditors.LabelControl()
            Me.lblTaxValueText1 = New DevExpress.XtraEditors.LabelControl()
            Me.lblTaxValue1 = New DevExpress.XtraEditors.LabelControl()
            Me.lblTaxValue2 = New DevExpress.XtraEditors.LabelControl()
            Me.lblTaxValueText3 = New DevExpress.XtraEditors.LabelControl()
            Me.lblTaxValue3 = New DevExpress.XtraEditors.LabelControl()
            Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
            Me.CheckButton1 = New DevExpress.XtraEditors.CheckButton()
            Me.lblTextNettoSumme = New DevExpress.XtraEditors.LabelControl()
            Me.chkShowPreviewLines = New DevExpress.XtraEditors.CheckEdit()
            Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblDocumentNumber = New DevExpress.XtraEditors.LabelControl()
            Me.lbldocumentDisplayID = New DevExpress.XtraEditors.LabelControl()
            Me.btnCloneDocument = New DevExpress.XtraEditors.SimpleButton()
            Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
            Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
            Me.lblAdressLine = New DevExpress.XtraEditors.LabelControl()
            Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
            Me.datDocumentVisibleDate = New DevExpress.XtraEditors.DateEdit()
            Me.lbldocumentsDate = New DevExpress.XtraEditors.LabelControl()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.lblCreatedAt = New DevExpress.XtraEditors.LabelControl()
            Me.lblChangedAtValue = New DevExpress.XtraEditors.LabelControl()
            Me.lblCreatedAtValue = New DevExpress.XtraEditors.LabelControl()
            Me.lblChangedAt = New DevExpress.XtraEditors.LabelControl()
            Me.lblCanceledStateAt = New DevExpress.XtraEditors.LabelControl()
            Me.lblCanceldAtValue = New DevExpress.XtraEditors.LabelControl()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
            Me.lblDocumehtTypeName = New DevExpress.XtraEditors.LabelControl()
            Me.cobDocumentType = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.btnMaximizeworkspace = New DevExpress.XtraEditors.SimpleButton()
            Me.btnJournal = New DevExpress.XtraEditors.SimpleButton()
            Me.cmsText = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.mnuPreview = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuCut = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuCopy = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuPaste = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuSaveToTemplate = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuLoadFromTemplate = New System.Windows.Forms.ToolStripMenuItem()
            Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
            CType(Me.grvItems, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repUnitCombo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repItemsShortTextB, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repTaxValues, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repCurrencyValue, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repTimInMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repPicture, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdItemsList, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.cmsGridPosition.SuspendLayout()
            CType(Me.grvPositions, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repItemsShortText, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repItemPositionNumber, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.splBillsHeaderPane, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splBillsHeaderPane.SuspendLayout()
            CType(Me.tabHeader, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabHeader.SuspendLayout()
            Me.tabMain.SuspendLayout()
            Me.pnlTabHeaderSettings.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.txtAdresswindow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtFooterText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtHeadText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabPayments.SuspendLayout()
            Me.Panel4.SuspendLayout()
            CType(Me.chkShowWithoutTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.btnCashAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtTargetPaymentDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.radPaimentDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.splBillsFooterPane, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splBillsFooterPane.SuspendLayout()
            Me.Panel5.SuspendLayout()
            Me.pnlLowerSubPanel.SuspendLayout()
            Me.talPrices.SuspendLayout()
            CType(Me.txtNetSumValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.chkDiscountActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.radDiscountType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDiscountValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDiscountName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDiscountedValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtSumValueAfterTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl2.SuspendLayout()
            CType(Me.chkShowPreviewLines.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel5.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.TableLayoutPanel8.SuspendLayout()
            Me.TableLayoutPanel4.SuspendLayout()
            Me.TableLayoutPanel3.SuspendLayout()
            CType(Me.datDocumentVisibleDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.datDocumentVisibleDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl3.SuspendLayout()
            CType(Me.cobDocumentType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl1.SuspendLayout()
            Me.cmsText.SuspendLayout()
            CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grvItems
            '
            Me.grvItems.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.grvItems.Appearance.EvenRow.Options.UseBackColor = True
            Me.grvItems.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colItemSortOrder, Me.colItemsCount, Me.colItemUnit, Me.colItemShortText, Me.colTaxRate, Me.colSinglePriceAfterTax, Me.colTotalPriceAfterTax, Me.colTimeInMinutes, Me.colInternamItemNumber, Me.colItemNumber, Me.colDiscount, Me.colBasePrice, Me.colSinglePriceBeforeTax, Me.colTotalPriceBeforeTax, Me.colImage})
            Me.grvItems.GridControl = Me.grdItemsList
            Me.grvItems.Name = "grvItems"
            Me.grvItems.NewItemRowText = "Klicken Sie hier, um eine neue Artikelzeile anzulegen"
            Me.grvItems.OptionsCustomization.AllowFilter = False
            Me.grvItems.OptionsCustomization.AllowGroup = False
            Me.grvItems.OptionsCustomization.AllowRowSizing = True
            Me.grvItems.OptionsCustomization.AllowSort = False
            Me.grvItems.OptionsDetail.AllowExpandEmptyDetails = True
            Me.grvItems.OptionsDetail.ShowDetailTabs = False
            Me.grvItems.OptionsMenu.EnableGroupPanelMenu = False
            Me.grvItems.OptionsSelection.MultiSelect = True
            Me.grvItems.OptionsView.AutoCalcPreviewLineCount = True
            Me.grvItems.OptionsView.EnableAppearanceEvenRow = True
            Me.grvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.grvItems.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
            Me.grvItems.OptionsView.ShowGroupPanel = False
            Me.grvItems.OptionsView.ShowViewCaption = True
            Me.grvItems.PreviewFieldName = "ItemMemoText"
            Me.grvItems.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colItemSortOrder, DevExpress.Data.ColumnSortOrder.Ascending)})
            '
            'colItemSortOrder
            '
            Me.colItemSortOrder.Caption = "Position"
            Me.colItemSortOrder.FieldName = "Sequence"
            Me.colItemSortOrder.Name = "colItemSortOrder"
            Me.colItemSortOrder.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
            Me.colItemSortOrder.Visible = True
            Me.colItemSortOrder.VisibleIndex = 0
            Me.colItemSortOrder.Width = 62
            '
            'colItemsCount
            '
            Me.colItemsCount.Caption = "Anzahl"
            Me.colItemsCount.FieldName = "ItemCount"
            Me.colItemsCount.Name = "colItemsCount"
            Me.colItemsCount.Visible = True
            Me.colItemsCount.VisibleIndex = 1
            Me.colItemsCount.Width = 88
            '
            'colItemUnit
            '
            Me.colItemUnit.Caption = "Einheit"
            Me.colItemUnit.ColumnEdit = Me.repUnitCombo
            Me.colItemUnit.FieldName = "ItemUnit"
            Me.colItemUnit.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
            Me.colItemUnit.Name = "colItemUnit"
            Me.colItemUnit.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            Me.colItemUnit.Visible = True
            Me.colItemUnit.VisibleIndex = 2
            Me.colItemUnit.Width = 95
            '
            'repUnitCombo
            '
            Me.repUnitCombo.AutoHeight = False
            Me.repUnitCombo.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repUnitCombo.HideSelection = False
            Me.repUnitCombo.Name = "repUnitCombo"
            Me.repUnitCombo.PopupSizeable = True
            Me.repUnitCombo.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick
            Me.repUnitCombo.Sorted = True
            Me.repUnitCombo.ValidateOnEnterKey = True
            '
            'colItemShortText
            '
            Me.colItemShortText.Caption = "Bezeichnung"
            Me.colItemShortText.ColumnEdit = Me.repItemsShortTextB
            Me.colItemShortText.FieldName = "ItemName"
            Me.colItemShortText.Name = "colItemShortText"
            Me.colItemShortText.Visible = True
            Me.colItemShortText.VisibleIndex = 3
            Me.colItemShortText.Width = 366
            '
            'repItemsShortTextB
            '
            Me.repItemsShortTextB.AutoHeight = False
            Me.repItemsShortTextB.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", "search", Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", "langtext", Nothing, True)})
            Me.repItemsShortTextB.MaxLength = 250
            Me.repItemsShortTextB.Name = "repItemsShortTextB"
            Me.repItemsShortTextB.NullValuePrompt = "F2 für Auswahl oder freie Texteingabe"
            Me.repItemsShortTextB.NullValuePromptShowForEmptyValue = True
            '
            'colTaxRate
            '
            Me.colTaxRate.Caption = "Steuersatz"
            Me.colTaxRate.ColumnEdit = Me.repTaxValues
            Me.colTaxRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.colTaxRate.FieldName = "TaxRate"
            Me.colTaxRate.Name = "colTaxRate"
            Me.colTaxRate.Visible = True
            Me.colTaxRate.VisibleIndex = 4
            Me.colTaxRate.Width = 70
            '
            'repTaxValues
            '
            Me.repTaxValues.AutoHeight = False
            Me.repTaxValues.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repTaxValues.Name = "repTaxValues"
            Me.repTaxValues.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick
            Me.repTaxValues.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            '
            'colSinglePriceAfterTax
            '
            Me.colSinglePriceAfterTax.Caption = "Einzelpreis (Brutto)"
            Me.colSinglePriceAfterTax.ColumnEdit = Me.repCurrencyValue
            Me.colSinglePriceAfterTax.FieldName = "SinglePriceAfterTax"
            Me.colSinglePriceAfterTax.Name = "colSinglePriceAfterTax"
            Me.colSinglePriceAfterTax.Visible = True
            Me.colSinglePriceAfterTax.VisibleIndex = 5
            Me.colSinglePriceAfterTax.Width = 116
            '
            'repCurrencyValue
            '
            Me.repCurrencyValue.AutoHeight = False
            Me.repCurrencyValue.DisplayFormat.FormatString = "c"
            Me.repCurrencyValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.repCurrencyValue.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.repCurrencyValue.Name = "repCurrencyValue"
            '
            'colTotalPriceAfterTax
            '
            Me.colTotalPriceAfterTax.Caption = "Gesamtpreis (Brutto)"
            Me.colTotalPriceAfterTax.ColumnEdit = Me.repCurrencyValue
            Me.colTotalPriceAfterTax.FieldName = "TotalPriceAfterTax"
            Me.colTotalPriceAfterTax.Name = "colTotalPriceAfterTax"
            Me.colTotalPriceAfterTax.Visible = True
            Me.colTotalPriceAfterTax.VisibleIndex = 6
            Me.colTotalPriceAfterTax.Width = 124
            '
            'colTimeInMinutes
            '
            Me.colTimeInMinutes.Caption = "Minuten"
            Me.colTimeInMinutes.ColumnEdit = Me.repTimInMinutes
            Me.colTimeInMinutes.FieldName = "TimeInMinutes"
            Me.colTimeInMinutes.Name = "colTimeInMinutes"
            '
            'repTimInMinutes
            '
            Me.repTimInMinutes.AutoHeight = False
            Me.repTimInMinutes.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.repTimInMinutes.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.repTimInMinutes.Mask.EditMask = "d"
            Me.repTimInMinutes.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            Me.repTimInMinutes.Mask.ShowPlaceHolders = False
            Me.repTimInMinutes.Name = "repTimInMinutes"
            '
            'colInternamItemNumber
            '
            Me.colInternamItemNumber.Caption = "eigene Artikelnummer"
            Me.colInternamItemNumber.FieldName = "InternalItemNumber"
            Me.colInternamItemNumber.Name = "colInternamItemNumber"
            Me.colInternamItemNumber.Width = 61
            '
            'colItemNumber
            '
            Me.colItemNumber.Caption = "Artikelnr."
            Me.colItemNumber.FieldName = "ExternalItemNumber"
            Me.colItemNumber.Name = "colItemNumber"
            Me.colItemNumber.Width = 61
            '
            'colDiscount
            '
            Me.colDiscount.Caption = "Rabatt"
            Me.colDiscount.FieldName = "DiscountValue"
            Me.colDiscount.Name = "colDiscount"
            Me.colDiscount.Width = 61
            '
            'colBasePrice
            '
            Me.colBasePrice.Caption = "Basis Preis"
            Me.colBasePrice.ColumnEdit = Me.repCurrencyValue
            Me.colBasePrice.FieldName = "BasePrice"
            Me.colBasePrice.Name = "colBasePrice"
            Me.colBasePrice.Width = 61
            '
            'colSinglePriceBeforeTax
            '
            Me.colSinglePriceBeforeTax.Caption = "Einzelpreis (netto)"
            Me.colSinglePriceBeforeTax.ColumnEdit = Me.repCurrencyValue
            Me.colSinglePriceBeforeTax.FieldName = "SinglePriceBeforeTax"
            Me.colSinglePriceBeforeTax.Name = "colSinglePriceBeforeTax"
            Me.colSinglePriceBeforeTax.Width = 76
            '
            'colTotalPriceBeforeTax
            '
            Me.colTotalPriceBeforeTax.Caption = "Gesamtpreis (Netto)"
            Me.colTotalPriceBeforeTax.ColumnEdit = Me.repCurrencyValue
            Me.colTotalPriceBeforeTax.FieldName = "TotalPriceBeforeTax"
            Me.colTotalPriceBeforeTax.Name = "colTotalPriceBeforeTax"
            Me.colTotalPriceBeforeTax.Width = 46
            '
            'colImage
            '
            Me.colImage.Caption = "Bild"
            Me.colImage.ColumnEdit = Me.repPicture
            Me.colImage.FieldName = "ItemPicture"
            Me.colImage.Name = "colImage"
            Me.colImage.Width = 96
            '
            'repPicture
            '
            Me.repPicture.Name = "repPicture"
            Me.repPicture.ShowMenu = False
            Me.repPicture.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
            '
            'grdItemsList
            '
            Me.grdItemsList.AllowDrop = True
            Me.grdItemsList.ContextMenuStrip = Me.cmsGridPosition
            Me.grdItemsList.Dock = System.Windows.Forms.DockStyle.Fill
            GridLevelNode1.LevelTemplate = Me.grvItems
            GridLevelNode1.RelationName = "Items"
            Me.grdItemsList.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
            Me.grdItemsList.Location = New System.Drawing.Point(0, 0)
            Me.grdItemsList.MainView = Me.grvPositions
            Me.grdItemsList.Name = "grdItemsList"
            Me.grdItemsList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repItemsShortText, Me.repUnitCombo, Me.repCurrencyValue, Me.repPicture, Me.repItemsShortTextB, Me.repItemPositionNumber, Me.repTimInMinutes, Me.repTaxValues})
            Me.grdItemsList.ShowOnlyPredefinedDetails = True
            Me.grdItemsList.Size = New System.Drawing.Size(942, 173)
            Me.grdItemsList.TabIndex = 0
            Me.grdItemsList.ToolTipController = Me.ttcGrid
            Me.grdItemsList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvPositions, Me.grvItems})
            '
            'cmsGridPosition
            '
            Me.cmsGridPosition.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewItem, Me.ToolStripMenuItem1, Me.mnuCopyPosition, Me.mnuInsertPositionFromClipboard, Me.mnuDeletePosition, Me.btnCreateDuplicate, Me.ToolStripMenuItem3, Me.mnuOpenItemData, Me.mnuSyncWithOriginItem, Me.mnuExpandBOMItems, Me.ToolStripMenuItem4, Me.btnConvertTextToArticle, Me.ToolStripMenuItem5, Me.mnuHideItemsPrices, Me.mnuResetItemsGroupPrice, Me.mnuHideItems, Me.mnuSetCurrentGroupNameAsDefaultName})
            Me.cmsGridPosition.Name = "cmsGrid"
            Me.cmsGridPosition.Size = New System.Drawing.Size(222, 336)
            '
            'mnuNewItem
            '
            Me.mnuNewItem.Name = "mnuNewItem"
            Me.mnuNewItem.Size = New System.Drawing.Size(221, 22)
            Me.mnuNewItem.Text = "Neu..."
            '
            'ToolStripMenuItem1
            '
            Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
            Me.ToolStripMenuItem1.Size = New System.Drawing.Size(218, 6)
            '
            'mnuCopyPosition
            '
            Me.mnuCopyPosition.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Copy
            Me.mnuCopyPosition.Name = "mnuCopyPosition"
            Me.mnuCopyPosition.Size = New System.Drawing.Size(221, 22)
            Me.mnuCopyPosition.Text = "Kopieren"
            '
            'mnuInsertPositionFromClipboard
            '
            Me.mnuInsertPositionFromClipboard.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.paste
            Me.mnuInsertPositionFromClipboard.Name = "mnuInsertPositionFromClipboard"
            Me.mnuInsertPositionFromClipboard.Size = New System.Drawing.Size(221, 22)
            Me.mnuInsertPositionFromClipboard.Text = "Einfügen"
            '
            'mnuDeletePosition
            '
            Me.mnuDeletePosition.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Delete
            Me.mnuDeletePosition.Name = "mnuDeletePosition"
            Me.mnuDeletePosition.Size = New System.Drawing.Size(221, 22)
            Me.mnuDeletePosition.Text = "Löschen"
            '
            'btnCreateDuplicate
            '
            Me.btnCreateDuplicate.Name = "btnCreateDuplicate"
            Me.btnCreateDuplicate.Size = New System.Drawing.Size(221, 22)
            Me.btnCreateDuplicate.Text = "Duplizieren"
            '
            'ToolStripMenuItem3
            '
            Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
            Me.ToolStripMenuItem3.Size = New System.Drawing.Size(218, 6)
            '
            'mnuOpenItemData
            '
            Me.mnuOpenItemData.Name = "mnuOpenItemData"
            Me.mnuOpenItemData.Size = New System.Drawing.Size(221, 22)
            Me.mnuOpenItemData.Text = "Artikeldaten aufrufen"
            '
            'mnuSyncWithOriginItem
            '
            Me.mnuSyncWithOriginItem.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Refresh
            Me.mnuSyncWithOriginItem.Name = "mnuSyncWithOriginItem"
            Me.mnuSyncWithOriginItem.Size = New System.Drawing.Size(221, 22)
            Me.mnuSyncWithOriginItem.Text = "Mit original synchronisieren"
            '
            'mnuExpandBOMItems
            '
            Me.mnuExpandBOMItems.Name = "mnuExpandBOMItems"
            Me.mnuExpandBOMItems.Size = New System.Drawing.Size(221, 22)
            Me.mnuExpandBOMItems.Text = "Stückliste erweitern"
            '
            'ToolStripMenuItem4
            '
            Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
            Me.ToolStripMenuItem4.Size = New System.Drawing.Size(218, 6)
            '
            'btnConvertTextToArticle
            '
            Me.btnConvertTextToArticle.Name = "btnConvertTextToArticle"
            Me.btnConvertTextToArticle.Size = New System.Drawing.Size(221, 22)
            Me.btnConvertTextToArticle.Text = "Text als Artikel aufnehmen"
            '
            'ToolStripMenuItem5
            '
            Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
            Me.ToolStripMenuItem5.Size = New System.Drawing.Size(218, 6)
            '
            'mnuHideItemsPrices
            '
            Me.mnuHideItemsPrices.CheckOnClick = True
            Me.mnuHideItemsPrices.Name = "mnuHideItemsPrices"
            Me.mnuHideItemsPrices.Size = New System.Drawing.Size(221, 22)
            Me.mnuHideItemsPrices.Text = "Einzelpreise ausblenden"
            '
            'mnuResetItemsGroupPrice
            '
            Me.mnuResetItemsGroupPrice.Name = "mnuResetItemsGroupPrice"
            Me.mnuResetItemsGroupPrice.Size = New System.Drawing.Size(221, 22)
            Me.mnuResetItemsGroupPrice.Text = "Gruppenpreis zurücksetzen"
            '
            'mnuHideItems
            '
            Me.mnuHideItems.CheckOnClick = True
            Me.mnuHideItems.Name = "mnuHideItems"
            Me.mnuHideItems.Size = New System.Drawing.Size(221, 22)
            Me.mnuHideItems.Text = "Artikel ausblenden"
            '
            'mnuSetCurrentGroupNameAsDefaultName
            '
            Me.mnuSetCurrentGroupNameAsDefaultName.Name = "mnuSetCurrentGroupNameAsDefaultName"
            Me.mnuSetCurrentGroupNameAsDefaultName.Size = New System.Drawing.Size(221, 22)
            Me.mnuSetCurrentGroupNameAsDefaultName.Text = "Gruppenname als Standard"
            '
            'grvPositions
            '
            Me.grvPositions.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.grvPositions.Appearance.EvenRow.Options.UseBackColor = True
            Me.grvPositions.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.grvPositions.Appearance.Row.Options.UseFont = True
            Me.grvPositions.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colGroupSortOrder, Me.colGroupCount, Me.colGroupShortText, Me.GridColumn2, Me.GridColumn3})
            Me.grvPositions.FixedLineWidth = 1
            Me.grvPositions.GridControl = Me.grdItemsList
            Me.grvPositions.Name = "grvPositions"
            Me.grvPositions.NewItemRowText = "Klicken sie hier, um eine neue Artikelgruppe anzulegen"
            Me.grvPositions.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
            Me.grvPositions.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
            Me.grvPositions.OptionsBehavior.SmartVertScrollBar = False
            Me.grvPositions.OptionsCustomization.AllowFilter = False
            Me.grvPositions.OptionsCustomization.AllowGroup = False
            Me.grvPositions.OptionsCustomization.AllowSort = False
            Me.grvPositions.OptionsDetail.AllowExpandEmptyDetails = True
            Me.grvPositions.OptionsDetail.ShowDetailTabs = False
            Me.grvPositions.OptionsSelection.MultiSelect = True
            Me.grvPositions.OptionsView.EnableAppearanceEvenRow = True
            Me.grvPositions.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
            Me.grvPositions.OptionsView.ShowGroupPanel = False
            Me.grvPositions.OptionsView.ShowPreviewLines = False
            Me.grvPositions.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colGroupSortOrder, DevExpress.Data.ColumnSortOrder.Ascending)})
            '
            'colGroupSortOrder
            '
            Me.colGroupSortOrder.Caption = "Pos.Nummer"
            Me.colGroupSortOrder.FieldName = "PositionNumber"
            Me.colGroupSortOrder.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Me.colGroupSortOrder.Name = "colGroupSortOrder"
            Me.colGroupSortOrder.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
            Me.colGroupSortOrder.Visible = True
            Me.colGroupSortOrder.VisibleIndex = 0
            Me.colGroupSortOrder.Width = 104
            '
            'colGroupCount
            '
            Me.colGroupCount.AppearanceCell.Options.UseTextOptions = True
            Me.colGroupCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.colGroupCount.Caption = "Anzahl"
            Me.colGroupCount.FieldName = "ItemCount"
            Me.colGroupCount.Name = "colGroupCount"
            Me.colGroupCount.Visible = True
            Me.colGroupCount.VisibleIndex = 1
            Me.colGroupCount.Width = 42
            '
            'colGroupShortText
            '
            Me.colGroupShortText.Caption = "Kurztext"
            Me.colGroupShortText.ColumnEdit = Me.repItemsShortText
            Me.colGroupShortText.FieldName = "HeaderText"
            Me.colGroupShortText.Name = "colGroupShortText"
            Me.colGroupShortText.Visible = True
            Me.colGroupShortText.VisibleIndex = 2
            Me.colGroupShortText.Width = 420
            '
            'repItemsShortText
            '
            Me.repItemsShortText.AutoHeight = False
            Me.repItemsShortText.MaxLength = 250
            Me.repItemsShortText.Name = "repItemsShortText"
            Me.repItemsShortText.NullValuePrompt = "Text eingeben oder Artikel wählen"
            '
            'GridColumn2
            '
            Me.GridColumn2.Caption = "Einzelpreis"
            Me.GridColumn2.ColumnEdit = Me.repCurrencyValue
            Me.GridColumn2.FieldName = "DisplaySinglePrice"
            Me.GridColumn2.Name = "GridColumn2"
            Me.GridColumn2.OptionsColumn.AllowEdit = False
            Me.GridColumn2.Visible = True
            Me.GridColumn2.VisibleIndex = 3
            Me.GridColumn2.Width = 47
            '
            'GridColumn3
            '
            Me.GridColumn3.Caption = "Gesamtpreis"
            Me.GridColumn3.ColumnEdit = Me.repCurrencyValue
            Me.GridColumn3.FieldName = "DisplayTotalPrice"
            Me.GridColumn3.Name = "GridColumn3"
            Me.GridColumn3.OptionsColumn.AllowEdit = False
            Me.GridColumn3.Visible = True
            Me.GridColumn3.VisibleIndex = 4
            Me.GridColumn3.Width = 58
            '
            'repItemPositionNumber
            '
            Me.repItemPositionNumber.AutoHeight = False
            Me.repItemPositionNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.repItemPositionNumber.Name = "repItemPositionNumber"
            Me.repItemPositionNumber.ReadOnly = True
            '
            'ttcGrid
            '
            '
            'splBillsHeaderPane
            '
            Me.splBillsHeaderPane.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1
            Me.splBillsHeaderPane.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splBillsHeaderPane.Horizontal = False
            Me.splBillsHeaderPane.Location = New System.Drawing.Point(0, 63)
            Me.splBillsHeaderPane.Margin = New System.Windows.Forms.Padding(0)
            Me.splBillsHeaderPane.Name = "splBillsHeaderPane"
            Me.splBillsHeaderPane.Panel1.Controls.Add(Me.tabHeader)
            Me.splBillsHeaderPane.Panel1.MinSize = 48
            Me.splBillsHeaderPane.Panel1.Text = "Panel1"
            Me.splBillsHeaderPane.Panel2.Controls.Add(Me.splBillsFooterPane)
            Me.splBillsHeaderPane.Panel2.Text = "Panel2"
            Me.splBillsHeaderPane.Size = New System.Drawing.Size(942, 474)
            Me.splBillsHeaderPane.SplitterPosition = 134
            Me.splBillsHeaderPane.TabIndex = 1
            Me.splBillsHeaderPane.Text = "SplitContainerControl1"
            '
            'tabHeader
            '
            Me.tabHeader.Appearance.BackColor = System.Drawing.Color.White
            Me.tabHeader.Appearance.Options.UseBackColor = True
            Me.tabHeader.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabHeader.Location = New System.Drawing.Point(0, 0)
            Me.tabHeader.Name = "tabHeader"
            Me.tabHeader.SelectedTabPage = Me.tabMain
            Me.tabHeader.Size = New System.Drawing.Size(942, 134)
            Me.tabHeader.TabIndex = 0
            Me.tabHeader.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabMain, Me.tabPayments, Me.XtraTabPage1})
            '
            'tabMain
            '
            Me.tabMain.Controls.Add(Me.pnlTabHeaderSettings)
            Me.tabMain.Name = "tabMain"
            Me.tabMain.Size = New System.Drawing.Size(935, 105)
            Me.tabMain.Text = "Einstellungen"
            '
            'pnlTabHeaderSettings
            '
            Me.pnlTabHeaderSettings.ColumnCount = 3
            Me.pnlTabHeaderSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
            Me.pnlTabHeaderSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.pnlTabHeaderSettings.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54.0!))
            Me.pnlTabHeaderSettings.Controls.Add(Me.Panel2, 0, 0)
            Me.pnlTabHeaderSettings.Controls.Add(Me.Panel3, 1, 0)
            Me.pnlTabHeaderSettings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlTabHeaderSettings.Location = New System.Drawing.Point(0, 0)
            Me.pnlTabHeaderSettings.Margin = New System.Windows.Forms.Padding(0)
            Me.pnlTabHeaderSettings.Name = "pnlTabHeaderSettings"
            Me.pnlTabHeaderSettings.RowCount = 1
            Me.pnlTabHeaderSettings.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.pnlTabHeaderSettings.Size = New System.Drawing.Size(935, 105)
            Me.pnlTabHeaderSettings.TabIndex = 3
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.btnAddAddress)
            Me.Panel2.Controls.Add(Me.lblDiscountText)
            Me.Panel2.Controls.Add(Me.lblAdressdiscountText)
            Me.Panel2.Controls.Add(Me.btnResetAdress)
            Me.Panel2.Controls.Add(Me.btnSearchAdress)
            Me.Panel2.Controls.Add(Me.txtAdresswindow)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(0, 0)
            Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(400, 105)
            Me.Panel2.TabIndex = 0
            '
            'btnAddAddress
            '
            Me.btnAddAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAddAddress.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Add_16x16
            Me.btnAddAddress.Location = New System.Drawing.Point(309, 72)
            Me.btnAddAddress.Name = "btnAddAddress"
            Me.btnAddAddress.Size = New System.Drawing.Size(87, 23)
            Me.btnAddAddress.TabIndex = 3
            Me.btnAddAddress.Text = "Neu..."
            '
            'lblDiscountText
            '
            Me.lblDiscountText.Location = New System.Drawing.Point(6, 89)
            Me.lblDiscountText.Name = "lblDiscountText"
            Me.lblDiscountText.Size = New System.Drawing.Size(55, 13)
            Me.lblDiscountText.TabIndex = 5
            Me.lblDiscountText.Text = "Rabattfeld:"
            '
            'lblAdressdiscountText
            '
            Me.lblAdressdiscountText.Location = New System.Drawing.Point(85, 89)
            Me.lblAdressdiscountText.Name = "lblAdressdiscountText"
            Me.lblAdressdiscountText.Size = New System.Drawing.Size(64, 13)
            Me.lblAdressdiscountText.TabIndex = 4
            Me.lblAdressdiscountText.Tag = "DontTranslate"
            Me.lblAdressdiscountText.Text = "- Rabatttext-"
            Me.lblAdressdiscountText.ToolTip = "Zeigt den Rabatttext diesee Adresse an."
            '
            'btnResetAdress
            '
            Me.btnResetAdress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnResetAdress.Location = New System.Drawing.Point(309, 39)
            Me.btnResetAdress.Name = "btnResetAdress"
            Me.btnResetAdress.Size = New System.Drawing.Size(87, 27)
            Me.btnResetAdress.TabIndex = 2
            Me.btnResetAdress.Text = "Zurücksetzen"
            '
            'btnSearchAdress
            '
            Me.btnSearchAdress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearchAdress.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.view
            Me.btnSearchAdress.Location = New System.Drawing.Point(309, 8)
            Me.btnSearchAdress.Name = "btnSearchAdress"
            Me.btnSearchAdress.Size = New System.Drawing.Size(87, 27)
            Me.btnSearchAdress.TabIndex = 1
            Me.btnSearchAdress.Text = "Suche..."
            '
            'txtAdresswindow
            '
            Me.txtAdresswindow.AllowDrop = True
            Me.txtAdresswindow.Location = New System.Drawing.Point(3, 10)
            Me.txtAdresswindow.Name = "txtAdresswindow"
            Me.txtAdresswindow.Properties.NullValuePrompt = "Wählen Sie eine Adresse oder geben Sie eine ein."
            Me.txtAdresswindow.Properties.NullValuePromptShowForEmptyValue = True
            Me.txtAdresswindow.Size = New System.Drawing.Size(274, 76)
            Me.txtAdresswindow.TabIndex = 0
            '
            'Panel3
            '
            Me.Panel3.Controls.Add(Me.lblDescription)
            Me.Panel3.Controls.Add(Me.txtDescription)
            Me.Panel3.Controls.Add(Me.txtFooterText)
            Me.Panel3.Controls.Add(Me.txtHeadText)
            Me.Panel3.Controls.Add(Me.lblFooterText)
            Me.Panel3.Controls.Add(Me.lblHeadText)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel3.Location = New System.Drawing.Point(400, 0)
            Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(481, 105)
            Me.Panel3.TabIndex = 1
            '
            'lblDescription
            '
            Me.lblDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDescription.Appearance.Options.UseFont = True
            Me.lblDescription.Location = New System.Drawing.Point(5, 8)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(76, 15)
            Me.lblDescription.TabIndex = 5
            Me.lblDescription.Text = "Beschreibung"
            '
            'txtDescription
            '
            Me.txtDescription.AllowDrop = True
            Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDescription.Location = New System.Drawing.Point(116, 7)
            Me.txtDescription.Name = "txtDescription"
            Me.txtDescription.Properties.MaxLength = 250
            Me.txtDescription.Properties.NullValuePrompt = "<Geben Sie eine Beschreibung ein>"
            Me.txtDescription.Properties.NullValuePromptShowForEmptyValue = True
            Me.txtDescription.Size = New System.Drawing.Size(362, 20)
            Me.txtDescription.TabIndex = 6
            Me.txtDescription.ToolTip = "Beschreibt den Inhalt dieses Dokumentes."
            '
            'txtFooterText
            '
            Me.txtFooterText.AllowDrop = True
            Me.txtFooterText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtFooterText.EditValue = ""
            Me.txtFooterText.Location = New System.Drawing.Point(116, 66)
            Me.txtFooterText.Name = "txtFooterText"
            Me.txtFooterText.Properties.ActionButtonIndex = 2
            Me.txtFooterText.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "Wählt aus den vorhandenen Textbausteinen eine Vorlage aus", "template", Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "Zeigt eine Vorschau des Textes mit aufgelösten Platzhaltern an.", "preview", Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, "", Nothing, Nothing, True)})
            Me.txtFooterText.Properties.MaxLength = 250
            Me.txtFooterText.Properties.NullValuePrompt = "Fusstext"
            Me.txtFooterText.Properties.NullValuePromptShowForEmptyValue = True
            Me.txtFooterText.Properties.ShowIcon = False
            Me.txtFooterText.Size = New System.Drawing.Size(362, 20)
            Me.txtFooterText.TabIndex = 8
            '
            'txtHeadText
            '
            Me.txtHeadText.AllowDrop = True
            Me.txtHeadText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtHeadText.Location = New System.Drawing.Point(116, 36)
            Me.txtHeadText.Name = "txtHeadText"
            Me.txtHeadText.Properties.ActionButtonIndex = 2
            Me.txtHeadText.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, "Wählt aus den vorhandenen Textbausteinen eine Vorlage aus", "template", Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject7, "Zeigt eine Vorschau des Textes mit aufgelösten Platzhaltern an.", "preview", Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject8, "", Nothing, Nothing, True)})
            Me.txtHeadText.Properties.MaxLength = 250
            Me.txtHeadText.Properties.NullValuePrompt = "Kopftext"
            Me.txtHeadText.Properties.NullValuePromptShowForEmptyValue = True
            Me.txtHeadText.Properties.ShowIcon = False
            Me.txtHeadText.Size = New System.Drawing.Size(362, 20)
            Me.txtHeadText.TabIndex = 7
            '
            'lblFooterText
            '
            Me.lblFooterText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFooterText.Appearance.Options.UseFont = True
            Me.lblFooterText.Location = New System.Drawing.Point(5, 69)
            Me.lblFooterText.Name = "lblFooterText"
            Me.lblFooterText.Size = New System.Drawing.Size(47, 15)
            Me.lblFooterText.TabIndex = 5
            Me.lblFooterText.Text = "Fusstext"
            '
            'lblHeadText
            '
            Me.lblHeadText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeadText.Appearance.Options.UseFont = True
            Me.lblHeadText.Location = New System.Drawing.Point(5, 39)
            Me.lblHeadText.Name = "lblHeadText"
            Me.lblHeadText.Size = New System.Drawing.Size(51, 15)
            Me.lblHeadText.TabIndex = 5
            Me.lblHeadText.Text = "Kopftext"
            '
            'tabPayments
            '
            Me.tabPayments.Controls.Add(Me.Panel4)
            Me.tabPayments.Name = "tabPayments"
            Me.tabPayments.Size = New System.Drawing.Size(935, 105)
            Me.tabPayments.Text = "Zahlungsweise"
            '
            'Panel4
            '
            Me.Panel4.Controls.Add(Me.chkShowWithoutTax)
            Me.Panel4.Controls.Add(Me.lblCashAccount)
            Me.Panel4.Controls.Add(Me.btnCashAccount)
            Me.Panel4.Controls.Add(Me.lblPaymentAccount)
            Me.Panel4.Controls.Add(Me.lblPaimantDate)
            Me.Panel4.Controls.Add(Me.lblDays)
            Me.Panel4.Controls.Add(Me.txtTargetPaymentDays)
            Me.Panel4.Controls.Add(Me.radPaimentDate)
            Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel4.Location = New System.Drawing.Point(0, 0)
            Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(935, 105)
            Me.Panel4.TabIndex = 3
            '
            'chkShowWithoutTax
            '
            Me.chkShowWithoutTax.Location = New System.Drawing.Point(260, 63)
            Me.chkShowWithoutTax.Name = "chkShowWithoutTax"
            Me.chkShowWithoutTax.Properties.Caption = "Einzelartikel als Nettopreis ausweisen"
            Me.chkShowWithoutTax.Size = New System.Drawing.Size(265, 19)
            Me.chkShowWithoutTax.TabIndex = 12
            Me.chkShowWithoutTax.ToolTip = "wenn gewählt, werden alle Preise inkusive Steuer angezeigt, sonst sind alle Preis" & _
        "e Nettopreise."
            '
            'lblCashAccount
            '
            Me.lblCashAccount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCashAccount.Appearance.Options.UseFont = True
            Me.lblCashAccount.Location = New System.Drawing.Point(262, 6)
            Me.lblCashAccount.Name = "lblCashAccount"
            Me.lblCashAccount.Size = New System.Drawing.Size(84, 15)
            Me.lblCashAccount.TabIndex = 11
            Me.lblCashAccount.Text = "Buchungskonto"
            '
            'btnCashAccount
            '
            Me.btnCashAccount.Location = New System.Drawing.Point(262, 22)
            Me.btnCashAccount.Name = "btnCashAccount"
            Me.btnCashAccount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCashAccount.Properties.Appearance.Options.UseFont = True
            Me.btnCashAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.btnCashAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.btnCashAccount.Size = New System.Drawing.Size(232, 22)
            Me.btnCashAccount.TabIndex = 10
            '
            'lblPaymentAccount
            '
            Me.lblPaymentAccount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPaymentAccount.Appearance.Options.UseFont = True
            Me.lblPaymentAccount.Location = New System.Drawing.Point(138, 6)
            Me.lblPaymentAccount.Name = "lblPaymentAccount"
            Me.lblPaymentAccount.Size = New System.Drawing.Size(66, 15)
            Me.lblPaymentAccount.TabIndex = 8
            Me.lblPaymentAccount.Text = "Zahlungsziel"
            '
            'lblPaimantDate
            '
            Me.lblPaimantDate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPaimantDate.Appearance.Options.UseFont = True
            Me.lblPaimantDate.Location = New System.Drawing.Point(15, 9)
            Me.lblPaimantDate.Name = "lblPaimantDate"
            Me.lblPaimantDate.Size = New System.Drawing.Size(66, 15)
            Me.lblPaimantDate.TabIndex = 6
            Me.lblPaimantDate.Text = "Zahlungsziel"
            '
            'lblDays
            '
            Me.lblDays.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDays.Appearance.Options.UseFont = True
            Me.lblDays.Location = New System.Drawing.Point(202, 28)
            Me.lblDays.Name = "lblDays"
            Me.lblDays.Size = New System.Drawing.Size(26, 15)
            Me.lblDays.TabIndex = 5
            Me.lblDays.Text = "Tage"
            '
            'txtTargetPaymentDays
            '
            Me.txtTargetPaymentDays.EditValue = "0"
            Me.txtTargetPaymentDays.Location = New System.Drawing.Point(138, 24)
            Me.txtTargetPaymentDays.Name = "txtTargetPaymentDays"
            Me.txtTargetPaymentDays.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTargetPaymentDays.Properties.Appearance.Options.UseFont = True
            Me.txtTargetPaymentDays.Properties.Appearance.Options.UseTextOptions = True
            Me.txtTargetPaymentDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.txtTargetPaymentDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtTargetPaymentDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtTargetPaymentDays.Properties.Mask.EditMask = "n0"
            Me.txtTargetPaymentDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            Me.txtTargetPaymentDays.Size = New System.Drawing.Size(50, 22)
            Me.txtTargetPaymentDays.TabIndex = 4
            '
            'radPaimentDate
            '
            Me.radPaimentDate.Location = New System.Drawing.Point(15, 25)
            Me.radPaimentDate.Name = "radPaimentDate"
            Me.radPaimentDate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.radPaimentDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.radPaimentDate.Properties.Appearance.Options.UseBackColor = True
            Me.radPaimentDate.Properties.Appearance.Options.UseFont = True
            Me.radPaimentDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.radPaimentDate.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Kein"), New DevExpress.XtraEditors.Controls.RadioGroupItem(14, "In 14 Tagen"), New DevExpress.XtraEditors.Controls.RadioGroupItem(30, "In 30 Tagen"), New DevExpress.XtraEditors.Controls.RadioGroupItem(-1, "Andere")})
            Me.radPaimentDate.Size = New System.Drawing.Size(129, 77)
            Me.radPaimentDate.TabIndex = 3
            '
            'XtraTabPage1
            '
            Me.XtraTabPage1.Name = "XtraTabPage1"
            Me.XtraTabPage1.PageVisible = False
            Me.XtraTabPage1.Size = New System.Drawing.Size(935, 105)
            Me.XtraTabPage1.Text = "XtraTabPage1"
            '
            'splBillsFooterPane
            '
            Me.splBillsFooterPane.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2
            Me.splBillsFooterPane.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splBillsFooterPane.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
            Me.splBillsFooterPane.Horizontal = False
            Me.splBillsFooterPane.Location = New System.Drawing.Point(0, 0)
            Me.splBillsFooterPane.Name = "splBillsFooterPane"
            Me.splBillsFooterPane.Panel1.Controls.Add(Me.Panel5)
            Me.splBillsFooterPane.Panel1.Text = "Panel1"
            Me.splBillsFooterPane.Panel2.CaptionLocation = DevExpress.Utils.Locations.Top
            Me.splBillsFooterPane.Panel2.Controls.Add(Me.pnlLowerSubPanel)
            Me.splBillsFooterPane.Panel2.ShowCaption = True
            Me.splBillsFooterPane.Panel2.Text = "Panel2"
            Me.splBillsFooterPane.Size = New System.Drawing.Size(942, 334)
            Me.splBillsFooterPane.SplitterPosition = 155
            Me.splBillsFooterPane.TabIndex = 8
            Me.splBillsFooterPane.Text = "SplitContainerControl2"
            '
            'Panel5
            '
            Me.Panel5.AutoSize = True
            Me.Panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.Panel5.BackColor = System.Drawing.Color.Transparent
            Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.Panel5.Controls.Add(Me.grdItemsList)
            Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel5.Location = New System.Drawing.Point(0, 0)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(942, 173)
            Me.Panel5.TabIndex = 0
            '
            'pnlLowerSubPanel
            '
            Me.pnlLowerSubPanel.AutoScroll = True
            Me.pnlLowerSubPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.pnlLowerSubPanel.Controls.Add(Me.lblEarningValue)
            Me.pnlLowerSubPanel.Controls.Add(Me.lblEarnings)
            Me.pnlLowerSubPanel.Controls.Add(Me.btnAddArticleGroup)
            Me.pnlLowerSubPanel.Controls.Add(Me.talPrices)
            Me.pnlLowerSubPanel.Controls.Add(Me.chkShowPreviewLines)
            Me.pnlLowerSubPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlLowerSubPanel.Location = New System.Drawing.Point(0, 0)
            Me.pnlLowerSubPanel.Name = "pnlLowerSubPanel"
            Me.pnlLowerSubPanel.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
            Me.pnlLowerSubPanel.Size = New System.Drawing.Size(942, 155)
            Me.pnlLowerSubPanel.TabIndex = 1
            '
            'lblEarningValue
            '
            Me.lblEarningValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEarningValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lblEarningValue.Appearance.Options.UseFont = True
            Me.lblEarningValue.Appearance.Options.UseForeColor = True
            Me.lblEarningValue.Location = New System.Drawing.Point(67, 7)
            Me.lblEarningValue.Name = "lblEarningValue"
            Me.lblEarningValue.Size = New System.Drawing.Size(14, 15)
            Me.lblEarningValue.TabIndex = 6
            Me.lblEarningValue.Text = "0€"
            '
            'lblEarnings
            '
            Me.lblEarnings.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEarnings.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lblEarnings.Appearance.Options.UseFont = True
            Me.lblEarnings.Appearance.Options.UseForeColor = True
            Me.lblEarnings.Location = New System.Drawing.Point(8, 7)
            Me.lblEarnings.Name = "lblEarnings"
            Me.lblEarnings.Size = New System.Drawing.Size(43, 15)
            Me.lblEarnings.TabIndex = 6
            Me.lblEarnings.Text = "Gewinn:"
            '
            'btnAddArticleGroup
            '
            Me.btnAddArticleGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnAddArticleGroup.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddArticleGroup.Appearance.Options.UseFont = True
            Me.btnAddArticleGroup.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Folder_Add_24x24
            Me.btnAddArticleGroup.Location = New System.Drawing.Point(6, 111)
            Me.btnAddArticleGroup.Name = "btnAddArticleGroup"
            Me.btnAddArticleGroup.Size = New System.Drawing.Size(182, 38)
            Me.btnAddArticleGroup.TabIndex = 1
            Me.btnAddArticleGroup.Text = "Neue Artikelgruppe..."
            Me.btnAddArticleGroup.ToolTip = "Erstellt eine neue Artikelgruppe"
            '
            'talPrices
            '
            Me.talPrices.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.talPrices.ColumnCount = 2
            Me.talPrices.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.2515!))
            Me.talPrices.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.7485!))
            Me.talPrices.Controls.Add(Me.txtNetSumValue, 1, 0)
            Me.talPrices.Controls.Add(Me.Panel1, 0, 1)
            Me.talPrices.Controls.Add(Me.txtDiscountedValue, 1, 1)
            Me.talPrices.Controls.Add(Me.lblSummValueAfterTax, 0, 5)
            Me.talPrices.Controls.Add(Me.txtSumValueAfterTax, 1, 5)
            Me.talPrices.Controls.Add(Me.lblTaxValueText2, 0, 3)
            Me.talPrices.Controls.Add(Me.lblTaxValueText1, 0, 2)
            Me.talPrices.Controls.Add(Me.lblTaxValue1, 1, 2)
            Me.talPrices.Controls.Add(Me.lblTaxValue2, 1, 3)
            Me.talPrices.Controls.Add(Me.lblTaxValueText3, 0, 4)
            Me.talPrices.Controls.Add(Me.lblTaxValue3, 1, 4)
            Me.talPrices.Controls.Add(Me.PanelControl2, 0, 0)
            Me.talPrices.Dock = System.Windows.Forms.DockStyle.Right
            Me.talPrices.Location = New System.Drawing.Point(546, 3)
            Me.talPrices.Name = "talPrices"
            Me.talPrices.RowCount = 6
            Me.talPrices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.talPrices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
            Me.talPrices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
            Me.talPrices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.talPrices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
            Me.talPrices.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
            Me.talPrices.Size = New System.Drawing.Size(396, 149)
            Me.talPrices.TabIndex = 3
            '
            'txtNetSumValue
            '
            Me.txtNetSumValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtNetSumValue.EditValue = "0"
            Me.txtNetSumValue.Location = New System.Drawing.Point(297, 3)
            Me.txtNetSumValue.Name = "txtNetSumValue"
            Me.txtNetSumValue.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtNetSumValue.Properties.Appearance.Options.UseFont = True
            Me.txtNetSumValue.Properties.Appearance.Options.UseTextOptions = True
            Me.txtNetSumValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.txtNetSumValue.Properties.DisplayFormat.FormatString = "c"
            Me.txtNetSumValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtNetSumValue.Properties.EditFormat.FormatString = "c"
            Me.txtNetSumValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtNetSumValue.Properties.ReadOnly = True
            Me.txtNetSumValue.Size = New System.Drawing.Size(96, 22)
            Me.txtNetSumValue.TabIndex = 2
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.chkDiscountActive)
            Me.Panel1.Controls.Add(Me.radDiscountType)
            Me.Panel1.Controls.Add(Me.txtDiscountValue)
            Me.Panel1.Controls.Add(Me.txtDiscountName)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 25)
            Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(294, 47)
            Me.Panel1.TabIndex = 3
            '
            'chkDiscountActive
            '
            Me.chkDiscountActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.chkDiscountActive.Location = New System.Drawing.Point(55, 3)
            Me.chkDiscountActive.Name = "chkDiscountActive"
            Me.chkDiscountActive.Properties.AutoWidth = True
            Me.chkDiscountActive.Properties.Caption = ""
            Me.chkDiscountActive.Size = New System.Drawing.Size(23, 19)
            Me.chkDiscountActive.TabIndex = 5
            Me.chkDiscountActive.Tag = "DontTRanslate"
            '
            'radDiscountType
            '
            Me.radDiscountType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.radDiscountType.EditValue = 0
            Me.radDiscountType.Enabled = False
            Me.radDiscountType.Location = New System.Drawing.Point(216, 1)
            Me.radDiscountType.Margin = New System.Windows.Forms.Padding(0)
            Me.radDiscountType.Name = "radDiscountType"
            Me.radDiscountType.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.radDiscountType.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.radDiscountType.Properties.Appearance.Options.UseBackColor = True
            Me.radDiscountType.Properties.Appearance.Options.UseFont = True
            Me.radDiscountType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.radDiscountType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Prozent"), New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Absolut")})
            Me.radDiscountType.Size = New System.Drawing.Size(78, 50)
            Me.radDiscountType.TabIndex = 4
            '
            'txtDiscountValue
            '
            Me.txtDiscountValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDiscountValue.EditValue = "0"
            Me.txtDiscountValue.Enabled = False
            Me.txtDiscountValue.Location = New System.Drawing.Point(152, 3)
            Me.txtDiscountValue.Name = "txtDiscountValue"
            Me.txtDiscountValue.Properties.Appearance.Options.UseTextOptions = True
            Me.txtDiscountValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.txtDiscountValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtDiscountValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtDiscountValue.Size = New System.Drawing.Size(64, 20)
            Me.txtDiscountValue.TabIndex = 2
            '
            'txtDiscountName
            '
            Me.txtDiscountName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDiscountName.EditValue = "Rabatt"
            Me.txtDiscountName.Enabled = False
            Me.txtDiscountName.Location = New System.Drawing.Point(84, 3)
            Me.txtDiscountName.Name = "txtDiscountName"
            Me.txtDiscountName.Size = New System.Drawing.Size(64, 20)
            Me.txtDiscountName.TabIndex = 1
            '
            'txtDiscountedValue
            '
            Me.txtDiscountedValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDiscountedValue.EditValue = "0"
            Me.txtDiscountedValue.Location = New System.Drawing.Point(297, 28)
            Me.txtDiscountedValue.Name = "txtDiscountedValue"
            Me.txtDiscountedValue.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDiscountedValue.Properties.Appearance.Options.UseFont = True
            Me.txtDiscountedValue.Properties.Appearance.Options.UseTextOptions = True
            Me.txtDiscountedValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.txtDiscountedValue.Properties.DisplayFormat.FormatString = "c"
            Me.txtDiscountedValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtDiscountedValue.Properties.EditFormat.FormatString = "c"
            Me.txtDiscountedValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtDiscountedValue.Properties.ReadOnly = True
            Me.txtDiscountedValue.Size = New System.Drawing.Size(96, 21)
            Me.txtDiscountedValue.TabIndex = 4
            '
            'lblSummValueAfterTax
            '
            Me.lblSummValueAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSummValueAfterTax.Appearance.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSummValueAfterTax.Appearance.Options.UseFont = True
            Me.lblSummValueAfterTax.Location = New System.Drawing.Point(191, 132)
            Me.lblSummValueAfterTax.Name = "lblSummValueAfterTax"
            Me.lblSummValueAfterTax.Size = New System.Drawing.Size(100, 18)
            Me.lblSummValueAfterTax.TabIndex = 1
            Me.lblSummValueAfterTax.Text = "Gesamtbetrag"
            '
            'txtSumValueAfterTax
            '
            Me.txtSumValueAfterTax.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtSumValueAfterTax.EditValue = "0"
            Me.txtSumValueAfterTax.Location = New System.Drawing.Point(297, 132)
            Me.txtSumValueAfterTax.Name = "txtSumValueAfterTax"
            Me.txtSumValueAfterTax.Properties.Appearance.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSumValueAfterTax.Properties.Appearance.Options.UseFont = True
            Me.txtSumValueAfterTax.Properties.Appearance.Options.UseTextOptions = True
            Me.txtSumValueAfterTax.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.txtSumValueAfterTax.Properties.DisplayFormat.FormatString = "c"
            Me.txtSumValueAfterTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtSumValueAfterTax.Properties.EditFormat.FormatString = "c"
            Me.txtSumValueAfterTax.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.txtSumValueAfterTax.Properties.ReadOnly = True
            Me.txtSumValueAfterTax.Size = New System.Drawing.Size(96, 24)
            Me.txtSumValueAfterTax.TabIndex = 7
            '
            'lblTaxValueText2
            '
            Me.lblTaxValueText2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxValueText2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTaxValueText2.Appearance.Options.UseFont = True
            Me.lblTaxValueText2.Location = New System.Drawing.Point(238, 94)
            Me.lblTaxValueText2.Name = "lblTaxValueText2"
            Me.lblTaxValueText2.Size = New System.Drawing.Size(53, 15)
            Me.lblTaxValueText2.TabIndex = 8
            Me.lblTaxValueText2.Text = "Steuersatz"
            '
            'lblTaxValueText1
            '
            Me.lblTaxValueText1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxValueText1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTaxValueText1.Appearance.Options.UseFont = True
            Me.lblTaxValueText1.Location = New System.Drawing.Point(238, 75)
            Me.lblTaxValueText1.Name = "lblTaxValueText1"
            Me.lblTaxValueText1.Size = New System.Drawing.Size(53, 15)
            Me.lblTaxValueText1.TabIndex = 8
            Me.lblTaxValueText1.Text = "Steuersatz"
            '
            'lblTaxValue1
            '
            Me.lblTaxValue1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxValue1.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTaxValue1.Appearance.Options.UseFont = True
            Me.lblTaxValue1.Location = New System.Drawing.Point(386, 75)
            Me.lblTaxValue1.Name = "lblTaxValue1"
            Me.lblTaxValue1.Size = New System.Drawing.Size(7, 15)
            Me.lblTaxValue1.TabIndex = 8
            Me.lblTaxValue1.Text = "0"
            '
            'lblTaxValue2
            '
            Me.lblTaxValue2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxValue2.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTaxValue2.Appearance.Options.UseFont = True
            Me.lblTaxValue2.Location = New System.Drawing.Point(386, 94)
            Me.lblTaxValue2.Name = "lblTaxValue2"
            Me.lblTaxValue2.Size = New System.Drawing.Size(7, 15)
            Me.lblTaxValue2.TabIndex = 8
            Me.lblTaxValue2.Text = "0"
            '
            'lblTaxValueText3
            '
            Me.lblTaxValueText3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxValueText3.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTaxValueText3.Appearance.Options.UseFont = True
            Me.lblTaxValueText3.Location = New System.Drawing.Point(238, 114)
            Me.lblTaxValueText3.Name = "lblTaxValueText3"
            Me.lblTaxValueText3.Size = New System.Drawing.Size(53, 15)
            Me.lblTaxValueText3.TabIndex = 8
            Me.lblTaxValueText3.Text = "Steuersatz"
            '
            'lblTaxValue3
            '
            Me.lblTaxValue3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxValue3.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTaxValue3.Appearance.Options.UseFont = True
            Me.lblTaxValue3.Location = New System.Drawing.Point(386, 114)
            Me.lblTaxValue3.Name = "lblTaxValue3"
            Me.lblTaxValue3.Size = New System.Drawing.Size(7, 15)
            Me.lblTaxValue3.TabIndex = 8
            Me.lblTaxValue3.Text = "0"
            '
            'PanelControl2
            '
            Me.PanelControl2.Controls.Add(Me.CheckButton1)
            Me.PanelControl2.Controls.Add(Me.lblTextNettoSumme)
            Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl2.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelControl2.Name = "PanelControl2"
            Me.PanelControl2.Size = New System.Drawing.Size(294, 25)
            Me.PanelControl2.TabIndex = 9
            '
            'CheckButton1
            '
            Me.CheckButton1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CheckButton1.Appearance.Options.UseFont = True
            Me.CheckButton1.Location = New System.Drawing.Point(5, 0)
            Me.CheckButton1.Name = "CheckButton1"
            Me.CheckButton1.Size = New System.Drawing.Size(79, 22)
            Me.CheckButton1.TabIndex = 7
            Me.CheckButton1.Text = "Details.."
            '
            'lblTextNettoSumme
            '
            Me.lblTextNettoSumme.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTextNettoSumme.Appearance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTextNettoSumme.Appearance.Options.UseFont = True
            Me.lblTextNettoSumme.Location = New System.Drawing.Point(205, 6)
            Me.lblTextNettoSumme.Name = "lblTextNettoSumme"
            Me.lblTextNettoSumme.Size = New System.Drawing.Size(86, 16)
            Me.lblTextNettoSumme.TabIndex = 1
            Me.lblTextNettoSumme.Tag = "DontTranslate"
            Me.lblTextNettoSumme.Text = "Summe (netto)"
            '
            'chkShowPreviewLines
            '
            Me.chkShowPreviewLines.Location = New System.Drawing.Point(6, 32)
            Me.chkShowPreviewLines.Name = "chkShowPreviewLines"
            Me.chkShowPreviewLines.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkShowPreviewLines.Properties.Appearance.Options.UseFont = True
            Me.chkShowPreviewLines.Properties.Caption = "Zeige Langtexte in Liste"
            Me.chkShowPreviewLines.Size = New System.Drawing.Size(166, 20)
            Me.chkShowPreviewLines.TabIndex = 5
            '
            'TableLayoutPanel5
            '
            Me.TableLayoutPanel5.ColumnCount = 3
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154.0!))
            Me.TableLayoutPanel5.Controls.Add(Me.FlowLayoutPanel1, 1, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel1, 0, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.PanelControl1, 2, 0)
            Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top
            Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
            Me.TableLayoutPanel5.RowCount = 1
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel5.Size = New System.Drawing.Size(942, 63)
            Me.TableLayoutPanel5.TabIndex = 5
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.Controls.Add(Me.TableLayoutPanel8)
            Me.FlowLayoutPanel1.Controls.Add(Me.btnCloneDocument)
            Me.FlowLayoutPanel1.Controls.Add(Me.TableLayoutPanel4)
            Me.FlowLayoutPanel1.Controls.Add(Me.TableLayoutPanel3)
            Me.FlowLayoutPanel1.Controls.Add(Me.TableLayoutPanel2)
            Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(175, 0)
            Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(613, 63)
            Me.FlowLayoutPanel1.TabIndex = 4
            Me.FlowLayoutPanel1.WrapContents = False
            '
            'TableLayoutPanel8
            '
            Me.TableLayoutPanel8.AutoSize = True
            Me.TableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel8.ColumnCount = 1
            Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel8.Controls.Add(Me.lblDocumentNumber, 0, 0)
            Me.TableLayoutPanel8.Controls.Add(Me.lbldocumentDisplayID, 0, 1)
            Me.TableLayoutPanel8.Location = New System.Drawing.Point(8, 0)
            Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
            Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
            Me.TableLayoutPanel8.RowCount = 2
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
            Me.TableLayoutPanel8.Size = New System.Drawing.Size(130, 44)
            Me.TableLayoutPanel8.TabIndex = 7
            '
            'lblDocumentNumber
            '
            Me.lblDocumentNumber.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDocumentNumber.Appearance.Options.UseFont = True
            Me.lblDocumentNumber.Location = New System.Drawing.Point(3, 3)
            Me.lblDocumentNumber.Name = "lblDocumentNumber"
            Me.lblDocumentNumber.Size = New System.Drawing.Size(83, 15)
            Me.lblDocumentNumber.TabIndex = 6
            Me.lblDocumentNumber.Text = "Dokumentennr."
            '
            'lbldocumentDisplayID
            '
            Me.lbldocumentDisplayID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbldocumentDisplayID.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbldocumentDisplayID.Appearance.Options.UseFont = True
            Me.lbldocumentDisplayID.Appearance.Options.UseTextOptions = True
            Me.lbldocumentDisplayID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.lbldocumentDisplayID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
            Me.lbldocumentDisplayID.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
            Me.lbldocumentDisplayID.Location = New System.Drawing.Point(2, 21)
            Me.lbldocumentDisplayID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.lbldocumentDisplayID.Name = "lbldocumentDisplayID"
            Me.lbldocumentDisplayID.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
            Me.lbldocumentDisplayID.Size = New System.Drawing.Size(126, 22)
            Me.lbldocumentDisplayID.TabIndex = 5
            Me.lbldocumentDisplayID.Text = "0"
            '
            'btnCloneDocument
            '
            Me.btnCloneDocument.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloneDocument.Appearance.Options.UseFont = True
            Me.btnCloneDocument.Location = New System.Drawing.Point(144, 3)
            Me.btnCloneDocument.Name = "btnCloneDocument"
            Me.btnCloneDocument.Size = New System.Drawing.Size(75, 23)
            Me.btnCloneDocument.TabIndex = 15
            Me.btnCloneDocument.Text = "Kopieren"
            '
            'TableLayoutPanel4
            '
            Me.TableLayoutPanel4.AutoSize = True
            Me.TableLayoutPanel4.ColumnCount = 2
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel4.Controls.Add(Me.LabelControl8, 0, 0)
            Me.TableLayoutPanel4.Controls.Add(Me.lblAdressLine, 1, 0)
            Me.TableLayoutPanel4.Location = New System.Drawing.Point(225, 0)
            Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
            Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
            Me.TableLayoutPanel4.RowCount = 1
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel4.Size = New System.Drawing.Size(61, 21)
            Me.TableLayoutPanel4.TabIndex = 12
            '
            'LabelControl8
            '
            Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.LabelControl8.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
            Me.LabelControl8.Appearance.Options.UseFont = True
            Me.LabelControl8.Appearance.Options.UseForeColor = True
            Me.LabelControl8.Appearance.Options.UseTextOptions = True
            Me.LabelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Me.LabelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
            Me.LabelControl8.Location = New System.Drawing.Point(3, 3)
            Me.LabelControl8.Name = "LabelControl8"
            Me.LabelControl8.Size = New System.Drawing.Size(1, 0)
            Me.LabelControl8.TabIndex = 2
            Me.LabelControl8.Text = "Adresse"
            '
            'lblAdressLine
            '
            Me.lblAdressLine.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAdressLine.Appearance.ForeColor = System.Drawing.Color.Black
            Me.lblAdressLine.Appearance.Options.UseFont = True
            Me.lblAdressLine.Appearance.Options.UseForeColor = True
            Me.lblAdressLine.Location = New System.Drawing.Point(10, 3)
            Me.lblAdressLine.Name = "lblAdressLine"
            Me.lblAdressLine.Size = New System.Drawing.Size(48, 15)
            Me.lblAdressLine.TabIndex = 3
            Me.lblAdressLine.Text = "Fa. Maier"
            '
            'TableLayoutPanel3
            '
            Me.TableLayoutPanel3.ColumnCount = 2
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.46154!))
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.53846!))
            Me.TableLayoutPanel3.Controls.Add(Me.datDocumentVisibleDate, 1, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.lbldocumentsDate, 0, 0)
            Me.TableLayoutPanel3.Location = New System.Drawing.Point(292, 0)
            Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
            Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
            Me.TableLayoutPanel3.RowCount = 1
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel3.Size = New System.Drawing.Size(130, 37)
            Me.TableLayoutPanel3.TabIndex = 14
            '
            'datDocumentVisibleDate
            '
            Me.datDocumentVisibleDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.datDocumentVisibleDate.EditValue = Nothing
            Me.datDocumentVisibleDate.Location = New System.Drawing.Point(53, 3)
            Me.datDocumentVisibleDate.Name = "datDocumentVisibleDate"
            Me.datDocumentVisibleDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.datDocumentVisibleDate.Properties.Appearance.Options.UseFont = True
            Me.datDocumentVisibleDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.datDocumentVisibleDate.Size = New System.Drawing.Size(74, 22)
            Me.datDocumentVisibleDate.TabIndex = 10
            '
            'lbldocumentsDate
            '
            Me.lbldocumentsDate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbldocumentsDate.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lbldocumentsDate.Appearance.Options.UseFont = True
            Me.lbldocumentsDate.Appearance.Options.UseForeColor = True
            Me.lbldocumentsDate.Location = New System.Drawing.Point(3, 3)
            Me.lbldocumentsDate.Name = "lbldocumentsDate"
            Me.lbldocumentsDate.Size = New System.Drawing.Size(39, 15)
            Me.lbldocumentsDate.TabIndex = 11
            Me.lbldocumentsDate.Text = "Datum:"
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 2
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.45055!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.54945!))
            Me.TableLayoutPanel2.Controls.Add(Me.lblCreatedAt, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblChangedAtValue, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.lblCreatedAtValue, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.lblChangedAt, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.lblCanceledStateAt, 0, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.lblCanceldAtValue, 1, 2)
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(428, 3)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 3
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.22148!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.22148!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.55704!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(182, 57)
            Me.TableLayoutPanel2.TabIndex = 13
            '
            'lblCreatedAt
            '
            Me.lblCreatedAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCreatedAt.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lblCreatedAt.Appearance.Options.UseFont = True
            Me.lblCreatedAt.Appearance.Options.UseForeColor = True
            Me.lblCreatedAt.Location = New System.Drawing.Point(3, 3)
            Me.lblCreatedAt.Name = "lblCreatedAt"
            Me.lblCreatedAt.Size = New System.Drawing.Size(71, 15)
            Me.lblCreatedAt.TabIndex = 12
            Me.lblCreatedAt.Text = "Angelegt am:"
            '
            'lblChangedAtValue
            '
            Me.lblChangedAtValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblChangedAtValue.Appearance.ForeColor = System.Drawing.Color.Black
            Me.lblChangedAtValue.Appearance.Options.UseFont = True
            Me.lblChangedAtValue.Appearance.Options.UseForeColor = True
            Me.lblChangedAtValue.Location = New System.Drawing.Point(93, 21)
            Me.lblChangedAtValue.Name = "lblChangedAtValue"
            Me.lblChangedAtValue.Size = New System.Drawing.Size(42, 15)
            Me.lblChangedAtValue.TabIndex = 12
            Me.lblChangedAtValue.Tag = "DontTranslate"
            Me.lblChangedAtValue.Text = "1.1.2009"
            '
            'lblCreatedAtValue
            '
            Me.lblCreatedAtValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCreatedAtValue.Appearance.ForeColor = System.Drawing.Color.Black
            Me.lblCreatedAtValue.Appearance.Options.UseFont = True
            Me.lblCreatedAtValue.Appearance.Options.UseForeColor = True
            Me.lblCreatedAtValue.Location = New System.Drawing.Point(93, 3)
            Me.lblCreatedAtValue.Name = "lblCreatedAtValue"
            Me.lblCreatedAtValue.Size = New System.Drawing.Size(42, 15)
            Me.lblCreatedAtValue.TabIndex = 12
            Me.lblCreatedAtValue.Tag = "DontTranslate"
            Me.lblCreatedAtValue.Text = "1.1.2009" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            '
            'lblChangedAt
            '
            Me.lblChangedAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblChangedAt.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lblChangedAt.Appearance.Options.UseFont = True
            Me.lblChangedAt.Appearance.Options.UseForeColor = True
            Me.lblChangedAt.Location = New System.Drawing.Point(3, 21)
            Me.lblChangedAt.Name = "lblChangedAt"
            Me.lblChangedAt.Size = New System.Drawing.Size(71, 15)
            Me.lblChangedAt.TabIndex = 12
            Me.lblChangedAt.Text = "Geändert am:"
            '
            'lblCanceledStateAt
            '
            Me.lblCanceledStateAt.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCanceledStateAt.Appearance.ForeColor = System.Drawing.Color.Red
            Me.lblCanceledStateAt.Appearance.Options.UseFont = True
            Me.lblCanceledStateAt.Appearance.Options.UseForeColor = True
            Me.lblCanceledStateAt.Location = New System.Drawing.Point(3, 39)
            Me.lblCanceledStateAt.Name = "lblCanceledStateAt"
            Me.lblCanceledStateAt.Size = New System.Drawing.Size(56, 15)
            Me.lblCanceledStateAt.TabIndex = 13
            Me.lblCanceledStateAt.Text = "Storno am"
            Me.lblCanceledStateAt.Visible = False
            '
            'lblCanceldAtValue
            '
            Me.lblCanceldAtValue.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCanceldAtValue.Appearance.ForeColor = System.Drawing.Color.Red
            Me.lblCanceldAtValue.Appearance.Options.UseFont = True
            Me.lblCanceldAtValue.Appearance.Options.UseForeColor = True
            Me.lblCanceldAtValue.Location = New System.Drawing.Point(93, 39)
            Me.lblCanceldAtValue.Name = "lblCanceldAtValue"
            Me.lblCanceldAtValue.Size = New System.Drawing.Size(48, 15)
            Me.lblCanceldAtValue.TabIndex = 14
            Me.lblCanceldAtValue.Tag = "DontTranslate"
            Me.lblCanceldAtValue.Text = "1.1.2009"
            Me.lblCanceldAtValue.Visible = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.PanelControl3, 1, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(169, 57)
            Me.TableLayoutPanel1.TabIndex = 7
            '
            'PanelControl3
            '
            Me.PanelControl3.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelControl3.Appearance.Options.UseBackColor = True
            Me.PanelControl3.Controls.Add(Me.lblDocumehtTypeName)
            Me.PanelControl3.Controls.Add(Me.cobDocumentType)
            Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl3.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelControl3.Name = "PanelControl3"
            Me.PanelControl3.Size = New System.Drawing.Size(169, 51)
            Me.PanelControl3.TabIndex = 0
            '
            'lblDocumehtTypeName
            '
            Me.lblDocumehtTypeName.Location = New System.Drawing.Point(6, 3)
            Me.lblDocumehtTypeName.Name = "lblDocumehtTypeName"
            Me.lblDocumehtTypeName.Size = New System.Drawing.Size(76, 13)
            Me.lblDocumehtTypeName.TabIndex = 9
            Me.lblDocumehtTypeName.Text = "Dokumententyp"
            '
            'cobDocumentType
            '
            Me.cobDocumentType.Location = New System.Drawing.Point(2, 17)
            Me.cobDocumentType.Name = "cobDocumentType"
            Me.cobDocumentType.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cobDocumentType.Properties.Appearance.Options.UseFont = True
            Me.cobDocumentType.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cobDocumentType.Properties.AppearanceDropDown.Options.UseFont = True
            Me.cobDocumentType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cobDocumentType.Properties.Items.AddRange(New Object() {"Angebot", "Rechnung", "Gutschrift", "Mahnung"})
            Me.cobDocumentType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.cobDocumentType.Size = New System.Drawing.Size(163, 24)
            Me.cobDocumentType.TabIndex = 8
            '
            'PanelControl1
            '
            Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelControl1.Appearance.Options.UseBackColor = True
            Me.PanelControl1.Controls.Add(Me.btnMaximizeworkspace)
            Me.PanelControl1.Controls.Add(Me.btnJournal)
            Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl1.Location = New System.Drawing.Point(791, 3)
            Me.PanelControl1.Name = "PanelControl1"
            Me.PanelControl1.Size = New System.Drawing.Size(148, 57)
            Me.PanelControl1.TabIndex = 8
            '
            'btnMaximizeworkspace
            '
            Me.btnMaximizeworkspace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnMaximizeworkspace.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
            Me.btnMaximizeworkspace.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.btnMaximizeworkspace.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.FitToHeight_16x16
            Me.btnMaximizeworkspace.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
            Me.btnMaximizeworkspace.Location = New System.Drawing.Point(104, 5)
            Me.btnMaximizeworkspace.LookAndFeel.SkinName = "Lilian"
            Me.btnMaximizeworkspace.LookAndFeel.UseDefaultLookAndFeel = False
            Me.btnMaximizeworkspace.Name = "btnMaximizeworkspace"
            Me.btnMaximizeworkspace.Size = New System.Drawing.Size(37, 27)
            Me.btnMaximizeworkspace.TabIndex = 2
            Me.btnMaximizeworkspace.ToolTip = "Arbeitsbereich maximieren"
            '
            'btnJournal
            '
            Me.btnJournal.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnJournal.Appearance.Options.UseFont = True
            Me.btnJournal.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.folder_document
            Me.btnJournal.Location = New System.Drawing.Point(5, 0)
            Me.btnJournal.Name = "btnJournal"
            Me.btnJournal.Size = New System.Drawing.Size(98, 43)
            Me.btnJournal.TabIndex = 0
            Me.btnJournal.Text = "Journal"
            '
            'cmsText
            '
            Me.cmsText.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPreview, Me.ToolStripSeparator1, Me.mnuCut, Me.mnuCopy, Me.mnuPaste, Me.ToolStripMenuItem2, Me.mnuSaveToTemplate, Me.mnuLoadFromTemplate})
            Me.cmsText.Name = "cmsText"
            Me.cmsText.Size = New System.Drawing.Size(217, 148)
            '
            'mnuPreview
            '
            Me.mnuPreview.Name = "mnuPreview"
            Me.mnuPreview.Size = New System.Drawing.Size(216, 22)
            Me.mnuPreview.Text = "Vorschau"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(213, 6)
            '
            'mnuCut
            '
            Me.mnuCut.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.cut
            Me.mnuCut.Name = "mnuCut"
            Me.mnuCut.Size = New System.Drawing.Size(216, 22)
            Me.mnuCut.Text = "Ausschneiden"
            '
            'mnuCopy
            '
            Me.mnuCopy.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Copy
            Me.mnuCopy.Name = "mnuCopy"
            Me.mnuCopy.Size = New System.Drawing.Size(216, 22)
            Me.mnuCopy.Text = "Kopieren"
            '
            'mnuPaste
            '
            Me.mnuPaste.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.paste
            Me.mnuPaste.Name = "mnuPaste"
            Me.mnuPaste.Size = New System.Drawing.Size(216, 22)
            Me.mnuPaste.Text = "Einfügen"
            '
            'ToolStripMenuItem2
            '
            Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
            Me.ToolStripMenuItem2.Size = New System.Drawing.Size(213, 6)
            '
            'mnuSaveToTemplate
            '
            Me.mnuSaveToTemplate.Name = "mnuSaveToTemplate"
            Me.mnuSaveToTemplate.Size = New System.Drawing.Size(216, 22)
            Me.mnuSaveToTemplate.Text = "Als neue Vorlage speichern"
            '
            'mnuLoadFromTemplate
            '
            Me.mnuLoadFromTemplate.Name = "mnuLoadFromTemplate"
            Me.mnuLoadFromTemplate.Size = New System.Drawing.Size(216, 22)
            Me.mnuLoadFromTemplate.Text = "Aus Vorlage holen"
            '
            'DxErrorProvider1
            '
            Me.DxErrorProvider1.ContainerControl = Me
            '
            'iucBills
            '
            Me.Appearance.BackColor = System.Drawing.Color.White
            Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseBackColor = True
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.splBillsHeaderPane)
            Me.Controls.Add(Me.TableLayoutPanel5)
            Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
            Me.Name = "iucBills"
            Me.Size = New System.Drawing.Size(942, 537)
            CType(Me.grvItems, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repUnitCombo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repItemsShortTextB, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repTaxValues, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repCurrencyValue, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repTimInMinutes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repPicture, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdItemsList, System.ComponentModel.ISupportInitialize).EndInit()
            Me.cmsGridPosition.ResumeLayout(False)
            CType(Me.grvPositions, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repItemsShortText, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repItemPositionNumber, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.splBillsHeaderPane, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splBillsHeaderPane.ResumeLayout(False)
            CType(Me.tabHeader, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabHeader.ResumeLayout(False)
            Me.tabMain.ResumeLayout(False)
            Me.pnlTabHeaderSettings.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.txtAdresswindow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtFooterText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtHeadText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabPayments.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.Panel4.PerformLayout()
            CType(Me.chkShowWithoutTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.btnCashAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtTargetPaymentDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.radPaimentDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.splBillsFooterPane, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splBillsFooterPane.ResumeLayout(False)
            Me.Panel5.ResumeLayout(False)
            Me.pnlLowerSubPanel.ResumeLayout(False)
            Me.pnlLowerSubPanel.PerformLayout()
            Me.talPrices.ResumeLayout(False)
            Me.talPrices.PerformLayout()
            CType(Me.txtNetSumValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.chkDiscountActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.radDiscountType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDiscountValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDiscountName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDiscountedValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtSumValueAfterTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl2.ResumeLayout(False)
            Me.PanelControl2.PerformLayout()
            CType(Me.chkShowPreviewLines.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel5.ResumeLayout(False)
            Me.TableLayoutPanel5.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.PerformLayout()
            Me.TableLayoutPanel8.ResumeLayout(False)
            Me.TableLayoutPanel8.PerformLayout()
            Me.TableLayoutPanel4.ResumeLayout(False)
            Me.TableLayoutPanel4.PerformLayout()
            Me.TableLayoutPanel3.ResumeLayout(False)
            Me.TableLayoutPanel3.PerformLayout()
            CType(Me.datDocumentVisibleDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.datDocumentVisibleDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl3.ResumeLayout(False)
            Me.PanelControl3.PerformLayout()
            CType(Me.cobDocumentType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl1.ResumeLayout(False)
            Me.cmsText.ResumeLayout(False)
            CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents splBillsHeaderPane As DevExpress.XtraEditors.SplitContainerControl
        Friend WithEvents grdItemsList As DevExpress.XtraGrid.GridControl
        Friend WithEvents grvPositions As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents tabHeader As DevExpress.XtraTab.XtraTabControl
        Friend WithEvents tabMain As DevExpress.XtraTab.XtraTabPage
        Friend WithEvents btnJournal As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents txtNetSumValue As DevExpress.XtraEditors.TextEdit
        Friend WithEvents lblTextNettoSumme As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblSummValueAfterTax As DevExpress.XtraEditors.LabelControl
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents lbldocumentDisplayID As DevExpress.XtraEditors.LabelControl
        Friend WithEvents cobDocumentType As DevExpress.XtraEditors.ComboBoxEdit
        Friend WithEvents lblCreatedAt As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCreatedAtValue As DevExpress.XtraEditors.LabelControl
        Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents datDocumentVisibleDate As DevExpress.XtraEditors.DateEdit
        Friend WithEvents lbldocumentsDate As DevExpress.XtraEditors.LabelControl
        Friend WithEvents tabPayments As DevExpress.XtraTab.XtraTabPage
        Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblAdressLine As DevExpress.XtraEditors.LabelControl
        Friend WithEvents colGroupCount As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colGroupSortOrder As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colGroupShortText As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents grvItems As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents cmsGridPosition As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents mnuNewItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents colItemsCount As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colItemShortText As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colItemUnit As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colItemNumber As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colBasePrice As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colInternamItemNumber As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colDiscount As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colImage As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colTaxRate As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colTotalPriceBeforeTax As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents repItemsShortText As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Friend WithEvents repUnitCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Friend WithEvents repCurrencyValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Friend WithEvents mnuCopyPosition As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuInsertPositionFromClipboard As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuDeletePosition As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents btnCreateDuplicate As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents repPicture As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
        Friend WithEvents talPrices As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents txtDiscountName As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtDiscountedValue As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtDiscountValue As DevExpress.XtraEditors.TextEdit
        Friend WithEvents txtSumValueAfterTax As DevExpress.XtraEditors.TextEdit
        Friend WithEvents radDiscountType As DevExpress.XtraEditors.RadioGroup
        Friend WithEvents lblTaxValueText2 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblTaxValueText3 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblTaxValueText1 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblTaxValue1 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblTaxValue2 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblTaxValue3 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents colSinglePriceBeforeTax As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents repItemsShortTextB As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Friend WithEvents chkShowPreviewLines As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents pnlTabHeaderSettings As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnResetAdress As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnSearchAdress As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents txtAdresswindow As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents cmsText As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents mnuPreview As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuCut As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuCopy As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuPaste As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuSaveToTemplate As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuLoadFromTemplate As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents pnlLowerSubPanel As System.Windows.Forms.Panel
        Friend WithEvents splBillsFooterPane As DevExpress.XtraEditors.SplitContainerControl
        Friend WithEvents btnAddArticleGroup As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuOpenItemData As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSyncWithOriginItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuExpandBOMItems As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents lblFooterText As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtFooterText As DevExpress.XtraEditors.MemoExEdit
        Friend WithEvents lblHeadText As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtHeadText As DevExpress.XtraEditors.MemoExEdit
        Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtDescription As DevExpress.XtraEditors.TextEdit
        Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents lblDocumentNumber As DevExpress.XtraEditors.LabelControl
        Friend WithEvents colTotalPriceAfterTax As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents colSinglePriceAfterTax As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents btnMaximizeworkspace As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents mnuHideItemsPrices As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuHideItems As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents btnConvertTextToArticle As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents repItemPositionNumber As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Friend WithEvents colTimeInMinutes As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents repTimInMinutes As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        Friend WithEvents repTaxValues As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents chkDiscountActive As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents lblAdressdiscountText As DevExpress.XtraEditors.LabelControl
        Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
        Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
        Friend WithEvents ttcGrid As DevExpress.Utils.ToolTipController
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents btnCashAccount As DevExpress.XtraEditors.ButtonEdit
        Friend WithEvents lblPaymentAccount As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblPaimantDate As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblDays As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtTargetPaymentDays As DevExpress.XtraEditors.TextEdit
        Friend WithEvents radPaimentDate As DevExpress.XtraEditors.RadioGroup
        Friend WithEvents lblCashAccount As DevExpress.XtraEditors.LabelControl
        Friend WithEvents CheckButton1 As DevExpress.XtraEditors.CheckButton
        Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblDiscountText As DevExpress.XtraEditors.LabelControl
        Friend WithEvents btnCloneDocument As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnAddAddress As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents chkShowWithoutTax As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents lblChangedAtValue As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblChangedAt As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCanceledStateAt As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCanceldAtValue As DevExpress.XtraEditors.LabelControl
        Friend WithEvents colItemSortOrder As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents lblEarningValue As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblEarnings As DevExpress.XtraEditors.LabelControl
        Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents lblDocumehtTypeName As DevExpress.XtraEditors.LabelControl
        Friend WithEvents mnuResetItemsGroupPrice As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuSetCurrentGroupNameAsDefaultName As System.Windows.Forms.ToolStripMenuItem

    End Class
End Namespace