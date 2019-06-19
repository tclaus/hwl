Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucArticles
    Inherits mainControlContainer

    'iucArticles overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            Node.nodesList.Clear()
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem5 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem6 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip7 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem7 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem7 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip8 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem8 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem8 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip9 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem9 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem9 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip10 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem10 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem10 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SuperToolTip11 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem11 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem11 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip12 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem12 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip13 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem13 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip14 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem14 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim SuperToolTip15 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem15 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.mainTable = New DevExpress.XtraTab.XtraTabControl()
        Me.tabInformation = New DevExpress.XtraTab.XtraTabPage()
        Me.PnlInfo = New System.Windows.Forms.TableLayoutPanel()
        Me.splInfoBox = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
        Me.txtLongText = New DevExpress.XtraEditors.MemoEdit()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.txtManufactorsArticleNumber = New DevExpress.XtraEditors.TextEdit()
        Me.lblManufactorsArticleNumber = New DevExpress.XtraEditors.LabelControl()
        Me.btnAdressSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDistributorName = New DevExpress.XtraEditors.LabelControl()
        Me.lblDistributor = New DevExpress.XtraEditors.LabelControl()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtInternalArticleNumber = New DevExpress.XtraEditors.TextEdit()
        Me.lblInternalArticleNumber = New DevExpress.XtraEditors.LabelControl()
        Me.chkIsActive = New DevExpress.XtraEditors.CheckEdit()
        Me.lblArticleTag = New DevExpress.XtraEditors.LabelControl()
        Me.txtArticleName = New DevExpress.XtraEditors.TextEdit()
        Me.lblCreatedAt = New DevExpress.XtraEditors.LabelControl()
        Me.txtCreatedAt = New DevExpress.XtraEditors.TextEdit()
        Me.tabCalculation = New DevExpress.XtraTab.XtraTabPage()
        Me.chkDiscountEnable = New DevExpress.XtraEditors.CheckEdit()
        Me.chkRessources = New DevExpress.XtraEditors.CheckEdit()
        Me.lblTaxRate = New DevExpress.XtraEditors.LabelControl()
        Me.cboTax = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tabPaneleinkauf = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlEinkauf = New System.Windows.Forms.Panel()
        Me.lblSingleBasePrice = New DevExpress.XtraEditors.LabelControl()
        Me.lblFactor = New DevExpress.XtraEditors.LabelControl()
        Me.txtSingleEKMulti = New DevExpress.XtraEditors.TextEdit()
        Me.txtsingleEK1 = New DevExpress.XtraEditors.TextEdit()
        Me.tabPanelDiscounts = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFactorDiscount = New DevExpress.XtraEditors.LabelControl()
        Me.txtRabattPreisMulti = New DevExpress.XtraEditors.TextEdit()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblDiscount = New DevExpress.XtraEditors.LabelControl()
        Me.cboRabatt = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtRabattpreis = New DevExpress.XtraEditors.TextEdit()
        Me.tabPanelResources = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.lblCommondityPrice = New DevExpress.XtraEditors.LabelControl()
        Me.txtRohstoffPreisMulti = New DevExpress.XtraEditors.TextEdit()
        Me.lblFactorResources = New DevExpress.XtraEditors.LabelControl()
        Me.txtRohstoffpreis = New DevExpress.XtraEditors.TextEdit()
        Me.tabPanelGwinn = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.cboAddValueStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtAufschlagAbsolut = New DevExpress.XtraEditors.TextEdit()
        Me.lblFactorGewinn = New DevExpress.XtraEditors.LabelControl()
        Me.txtAufschlagMulti = New DevExpress.XtraEditors.TextEdit()
        Me.pnlAufschlag = New System.Windows.Forms.Panel()
        Me.lblGewinnzuschlag = New DevExpress.XtraEditors.LabelControl()
        Me.TabPanelendPrice = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.chkFixedendPrice = New DevExpress.XtraEditors.CheckButton()
        Me.lblTotalsalesPrice = New DevExpress.XtraEditors.LabelControl()
        Me.txtVerkaufspreis = New DevExpress.XtraEditors.TextEdit()
        Me.lblFactorVerkauf = New DevExpress.XtraEditors.LabelControl()
        Me.txtVerkaufspreisMulti = New DevExpress.XtraEditors.TextEdit()
        Me.lblCount = New DevExpress.XtraEditors.LabelControl()
        Me.lblBaseUnit = New DevExpress.XtraEditors.LabelControl()
        Me.lblVPUnit = New DevExpress.XtraEditors.LabelControl()
        Me.txtItemCount = New DevExpress.XtraEditors.TextEdit()
        Me.MruPack = New DevExpress.XtraEditors.MRUEdit()
        Me.MruBase1 = New DevExpress.XtraEditors.MRUEdit()
        Me.tabmiscellaneous = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.txtMemo = New DevExpress.XtraEditors.MemoEdit()
        Me.lblMoreNotesAboutArticle = New DevExpress.XtraEditors.LabelControl()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.trvHirachy = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.lblSelectOldAndRedeemedArticles = New DevExpress.XtraEditors.LabelControl()
        Me.btnSetPredecessor = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPredecessorItems = New DevExpress.XtraEditors.LabelControl()
        Me.tabPictures = New DevExpress.XtraTab.XtraTabPage()
        Me.grdImages = New DevExpress.XtraGrid.GridControl()
        Me.cmsImages = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNewImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditPictures = New System.Windows.Forms.ToolStripMenuItem()
        Me.lvImages = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.colName = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.layoutViewField_LayoutViewColumn2 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colImage = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.layoutViewField_LayoutViewColumn3 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.colResulution = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn4 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewColumn1 = New DevExpress.XtraGrid.Columns.LayoutViewColumn()
        Me.layoutViewField_LayoutViewColumn1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewField()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.tabStorage = New DevExpress.XtraTab.XtraTabPage()
        Me.txteanCode = New DevExpress.XtraEditors.TextEdit()
        Me.lblEANCode = New DevExpress.XtraEditors.LabelControl()
        Me.tlbLastSelling = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLastSoldDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblSoldAt = New DevExpress.XtraEditors.LabelControl()
        Me.tlpLagerbestand = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSummSellings = New DevExpress.XtraEditors.LabelControl()
        Me.lblTextSumsellings = New DevExpress.XtraEditors.LabelControl()
        Me.lblMainUnit = New DevExpress.XtraEditors.LabelControl()
        Me.lblSumOfSoldItems = New DevExpress.XtraEditors.LabelControl()
        Me.tabComponents = New DevExpress.XtraTab.XtraTabPage()
        Me.btnTransferSubPrices = New DevExpress.XtraEditors.SimpleButton()
        Me.lblBomCalculatedTime = New DevExpress.XtraEditors.LabelControl()
        Me.lblBomSumEndPrice = New DevExpress.XtraEditors.LabelControl()
        Me.lbltxtCalculatedTime = New DevExpress.XtraEditors.LabelControl()
        Me.lbltxtCalculatedEndPrice = New DevExpress.XtraEditors.LabelControl()
        Me.lblBomSumBasePrice = New DevExpress.XtraEditors.LabelControl()
        Me.lbltxtBasePrice = New DevExpress.XtraEditors.LabelControl()
        Me.trvsubArticles = New DevExpress.XtraTreeList.TreeList()
        Me.cmsBomItems = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnOpenBomItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddArticles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopyArticles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPasteArticles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteBomItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabWorkItems = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtWorkItemcosts = New DevExpress.XtraEditors.TextEdit()
        Me.lblWorkItemCosts = New DevExpress.XtraEditors.LabelControl()
        Me.lblPayGroup = New DevExpress.XtraEditors.LabelControl()
        Me.lblDuration = New DevExpress.XtraEditors.LabelControl()
        Me.cboWorkAccount = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtWorkTimeSpan = New DevExpress.XtraEditors.TimeEdit()
        Me.lblShortTimeFormat = New DevExpress.XtraEditors.LabelControl()
        Me.chkIsWorkItem = New DevExpress.XtraEditors.CheckEdit()
        Me.tabAttributes = New DevExpress.XtraTab.XtraTabPage()
        Me.btnEditArticleAttributes = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.grdAttributes = New DevExpress.XtraGrid.GridControl()
        Me.grvAttributes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.repAttrbutesCheckedit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.repAttributesDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.repAttributesEnumValues = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.pnlHeadline = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.lblArticleShortDescription = New DevExpress.XtraEditors.LabelControl()
        Me.Panel3 = New DevExpress.XtraEditors.PanelControl()
        Me.txtSingleEKBrutto = New DevExpress.XtraEditors.TextEdit()
        Me.txtSingleEK = New DevExpress.XtraEditors.TextEdit()
        Me.lblWithoutTax = New DevExpress.XtraEditors.LabelControl()
        Me.lblWithTax = New DevExpress.XtraEditors.LabelControl()
        Me.lblSingleBasePriceHeadline = New DevExpress.XtraEditors.LabelControl()
        Me.Panel4 = New DevExpress.XtraEditors.PanelControl()
        Me.txtSingleVKbrutto = New DevExpress.XtraEditors.TextEdit()
        Me.txtSingleVK = New DevExpress.XtraEditors.TextEdit()
        Me.lblWithoutTax1 = New DevExpress.XtraEditors.LabelControl()
        Me.lblSingleEndPrice = New DevExpress.XtraEditors.LabelControl()
        Me.lblWithTax1 = New DevExpress.XtraEditors.LabelControl()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.MruBase = New DevExpress.XtraEditors.MRUEdit()
        Me.lblSingleUnit = New DevExpress.XtraEditors.LabelControl()
        Me.ArticlesGrid = New ClausSoftware.HWLInterops.iucGroupsGrid()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnMaximizeworkspace = New DevExpress.XtraEditors.SimpleButton()
        Me.IucSearchPanel1 = New ClausSoftware.HWLInterops.iucSearchPanel()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.mainTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainTable.SuspendLayout()
        Me.tabInformation.SuspendLayout()
        Me.PnlInfo.SuspendLayout()
        CType(Me.splInfoBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splInfoBox.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.txtLongText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        CType(Me.txtManufactorsArticleNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        CType(Me.txtInternalArticleNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtArticleName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreatedAt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCalculation.SuspendLayout()
        CType(Me.chkDiscountEnable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRessources.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.tabPaneleinkauf.SuspendLayout()
        Me.pnlEinkauf.SuspendLayout()
        CType(Me.txtSingleEKMulti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsingleEK1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPanelDiscounts.SuspendLayout()
        CType(Me.txtRabattPreisMulti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.cboRabatt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtRabattpreis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPanelResources.SuspendLayout()
        Me.Panel13.SuspendLayout()
        CType(Me.txtRohstoffPreisMulti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRohstoffpreis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPanelGwinn.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.cboAddValueStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAufschlagAbsolut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAufschlagMulti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAufschlag.SuspendLayout()
        Me.TabPanelendPrice.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.txtVerkaufspreis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVerkaufspreisMulti.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItemCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MruPack.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MruBase1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabmiscellaneous.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel14.SuspendLayout()
        CType(Me.txtMemo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel15.SuspendLayout()
        CType(Me.trvHirachy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPictures.SuspendLayout()
        CType(Me.grdImages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsImages.SuspendLayout()
        CType(Me.lvImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabStorage.SuspendLayout()
        CType(Me.txteanCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbLastSelling.SuspendLayout()
        Me.tlpLagerbestand.SuspendLayout()
        Me.tabComponents.SuspendLayout()
        CType(Me.trvsubArticles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsBomItems.SuspendLayout()
        Me.tabWorkItems.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.txtWorkItemcosts.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboWorkAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.txtWorkTimeSpan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsWorkItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAttributes.SuspendLayout()
        CType(Me.grdAttributes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvAttributes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAttrbutesCheckedit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAttributesDateEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAttributesDateEdit.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repAttributesEnumValues, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeadline.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.txtSingleEKBrutto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSingleEK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.txtSingleVKbrutto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSingleVK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.MruBase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.mainTable)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.pnlHeadline)
        Me.SplitContainerControl1.Panel1.MinSize = 60
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.ArticlesGrid)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.PanelControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(868, 585)
        Me.SplitContainerControl1.SplitterPosition = 309
        Me.SplitContainerControl1.TabIndex = 1
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'mainTable
        '
        Me.mainTable.Appearance.BackColor = System.Drawing.Color.White
        Me.mainTable.Appearance.Options.UseBackColor = True
        Me.mainTable.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.mainTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mainTable.Location = New System.Drawing.Point(0, 64)
        Me.mainTable.Margin = New System.Windows.Forms.Padding(0)
        Me.mainTable.Name = "mainTable"
        Me.mainTable.SelectedTabPage = Me.tabInformation
        Me.mainTable.Size = New System.Drawing.Size(868, 245)
        Me.mainTable.TabIndex = 8
        Me.mainTable.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabInformation, Me.tabCalculation, Me.tabmiscellaneous, Me.tabPictures, Me.tabStorage, Me.tabComponents, Me.tabWorkItems, Me.tabAttributes})
        '
        'tabInformation
        '
        Me.tabInformation.Controls.Add(Me.PnlInfo)
        Me.tabInformation.Name = "tabInformation"
        Me.tabInformation.Size = New System.Drawing.Size(861, 216)
        Me.tabInformation.Text = "Informationen"
        '
        'PnlInfo
        '
        Me.PnlInfo.ColumnCount = 2
        Me.PnlInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.PnlInfo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.PnlInfo.Controls.Add(Me.splInfoBox, 1, 0)
        Me.PnlInfo.Controls.Add(Me.Panel10, 0, 0)
        Me.PnlInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlInfo.Location = New System.Drawing.Point(0, 0)
        Me.PnlInfo.Name = "PnlInfo"
        Me.PnlInfo.RowCount = 1
        Me.PnlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.PnlInfo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 187.0!))
        Me.PnlInfo.Size = New System.Drawing.Size(861, 216)
        Me.PnlInfo.TabIndex = 26
        '
        'splInfoBox
        '
        Me.splInfoBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splInfoBox.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.splInfoBox.Location = New System.Drawing.Point(201, 3)
        Me.splInfoBox.Name = "splInfoBox"
        Me.splInfoBox.Panel1.Controls.Add(Me.Panel11)
        Me.splInfoBox.Panel1.Text = "Panel1"
        Me.splInfoBox.Panel2.Controls.Add(Me.Panel12)
        Me.splInfoBox.Panel2.Text = "Panel2"
        Me.splInfoBox.Size = New System.Drawing.Size(657, 210)
        Me.splInfoBox.SplitterPosition = 183
        Me.splInfoBox.TabIndex = 24
        Me.splInfoBox.Text = "SplitContainerControl2"
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.lblDescription)
        Me.Panel11.Controls.Add(Me.txtLongText)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(468, 210)
        Me.Panel11.TabIndex = 1
        '
        'lblDescription
        '
        Me.lblDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Appearance.Options.UseFont = True
        Me.lblDescription.Location = New System.Drawing.Point(13, 6)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(96, 15)
        Me.lblDescription.TabIndex = 23
        Me.lblDescription.Text = "Beschreibungstext" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtLongText
        '
        Me.txtLongText.AllowDrop = True
        Me.txtLongText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLongText.Location = New System.Drawing.Point(13, 28)
        Me.txtLongText.Name = "txtLongText"
        Me.txtLongText.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLongText.Properties.Appearance.Options.UseFont = True
        Me.txtLongText.Size = New System.Drawing.Size(452, 172)
        Me.txtLongText.TabIndex = 22
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.txtManufactorsArticleNumber)
        Me.Panel12.Controls.Add(Me.lblManufactorsArticleNumber)
        Me.Panel12.Controls.Add(Me.btnAdressSearch)
        Me.Panel12.Controls.Add(Me.lblDistributorName)
        Me.Panel12.Controls.Add(Me.lblDistributor)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(183, 210)
        Me.Panel12.TabIndex = 2
        '
        'txtManufactorsArticleNumber
        '
        Me.txtManufactorsArticleNumber.AllowDrop = True
        Me.txtManufactorsArticleNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtManufactorsArticleNumber.Location = New System.Drawing.Point(13, 170)
        Me.txtManufactorsArticleNumber.Name = "txtManufactorsArticleNumber"
        Me.txtManufactorsArticleNumber.Properties.MaxLength = 150
        Me.txtManufactorsArticleNumber.Size = New System.Drawing.Size(146, 20)
        Me.txtManufactorsArticleNumber.TabIndex = 23
        '
        'lblManufactorsArticleNumber
        '
        Me.lblManufactorsArticleNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblManufactorsArticleNumber.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManufactorsArticleNumber.Appearance.Options.UseFont = True
        Me.lblManufactorsArticleNumber.Location = New System.Drawing.Point(13, 150)
        Me.lblManufactorsArticleNumber.Name = "lblManufactorsArticleNumber"
        Me.lblManufactorsArticleNumber.Size = New System.Drawing.Size(163, 15)
        Me.lblManufactorsArticleNumber.TabIndex = 22
        Me.lblManufactorsArticleNumber.Text = "Artikelnummer des Lieferanten"
        '
        'btnAdressSearch
        '
        Me.btnAdressSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdressSearch.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdressSearch.Appearance.Options.UseFont = True
        Me.btnAdressSearch.Location = New System.Drawing.Point(93, 6)
        Me.btnAdressSearch.Name = "btnAdressSearch"
        Me.btnAdressSearch.Size = New System.Drawing.Size(87, 27)
        Me.btnAdressSearch.TabIndex = 20
        Me.btnAdressSearch.Text = "Adresse"
        '
        'lblDistributorName
        '
        Me.lblDistributorName.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistributorName.Appearance.Options.UseFont = True
        Me.lblDistributorName.Location = New System.Drawing.Point(13, 18)
        Me.lblDistributorName.Name = "lblDistributorName"
        Me.lblDistributorName.Size = New System.Drawing.Size(46, 15)
        Me.lblDistributorName.TabIndex = 21
        Me.lblDistributorName.Text = "Lieferant"
        '
        'lblDistributor
        '
        Me.lblDistributor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDistributor.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistributor.Appearance.Options.UseFont = True
        Me.lblDistributor.Appearance.Options.UseTextOptions = True
        Me.lblDistributor.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblDistributor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDistributor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.lblDistributor.Location = New System.Drawing.Point(13, 39)
        Me.lblDistributor.Name = "lblDistributor"
        Me.lblDistributor.Size = New System.Drawing.Size(163, 78)
        Me.lblDistributor.TabIndex = 19
        Me.lblDistributor.Text = "Lieferant" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Adresse + Telefon und Mail" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.txtInternalArticleNumber)
        Me.Panel10.Controls.Add(Me.lblInternalArticleNumber)
        Me.Panel10.Controls.Add(Me.chkIsActive)
        Me.Panel10.Controls.Add(Me.lblArticleTag)
        Me.Panel10.Controls.Add(Me.txtArticleName)
        Me.Panel10.Controls.Add(Me.lblCreatedAt)
        Me.Panel10.Controls.Add(Me.txtCreatedAt)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(198, 216)
        Me.Panel10.TabIndex = 0
        '
        'txtInternalArticleNumber
        '
        Me.txtInternalArticleNumber.Location = New System.Drawing.Point(6, 28)
        Me.txtInternalArticleNumber.Name = "txtInternalArticleNumber"
        Me.txtInternalArticleNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInternalArticleNumber.Properties.Appearance.Options.UseFont = True
        Me.txtInternalArticleNumber.Properties.ReadOnly = True
        Me.txtInternalArticleNumber.Size = New System.Drawing.Size(168, 22)
        ToolTipTitleItem1.Text = "Interne Artikelnummer"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Dies stellt eine eindeutige Artikelnummer dar. Diese wird beim Anlegen automatisc" & _
    "h vergeben. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sie sollten diese Nummer nicht ändern."
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.txtInternalArticleNumber.SuperTip = SuperToolTip1
        Me.txtInternalArticleNumber.TabIndex = 28
        '
        'lblInternalArticleNumber
        '
        Me.lblInternalArticleNumber.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInternalArticleNumber.Appearance.Options.UseFont = True
        Me.lblInternalArticleNumber.Location = New System.Drawing.Point(6, 6)
        Me.lblInternalArticleNumber.Name = "lblInternalArticleNumber"
        Me.lblInternalArticleNumber.Size = New System.Drawing.Size(120, 15)
        Me.lblInternalArticleNumber.TabIndex = 27
        Me.lblInternalArticleNumber.Text = "Interne Artikelnummer"
        '
        'chkIsActive
        '
        Me.chkIsActive.Location = New System.Drawing.Point(3, 162)
        Me.chkIsActive.Name = "chkIsActive"
        Me.chkIsActive.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActive.Properties.Appearance.Options.UseFont = True
        Me.chkIsActive.Properties.Caption = "Ist aktiv"
        Me.chkIsActive.Size = New System.Drawing.Size(99, 20)
        ToolTipTitleItem2.Text = "Artikel ist aktiv"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Nur aktive Artikel können in neuen Rechnungen oder Angebite aufgenommen werden"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.chkIsActive.SuperTip = SuperToolTip2
        Me.chkIsActive.TabIndex = 26
        '
        'lblArticleTag
        '
        Me.lblArticleTag.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticleTag.Appearance.Options.UseFont = True
        Me.lblArticleTag.Location = New System.Drawing.Point(3, 58)
        Me.lblArticleTag.Name = "lblArticleTag"
        Me.lblArticleTag.Size = New System.Drawing.Size(158, 15)
        Me.lblArticleTag.TabIndex = 25
        Me.lblArticleTag.Text = "Artikelname / Modellnummer"
        '
        'txtArticleName
        '
        Me.txtArticleName.AllowDrop = True
        Me.txtArticleName.Location = New System.Drawing.Point(6, 80)
        Me.txtArticleName.Name = "txtArticleName"
        Me.txtArticleName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArticleName.Properties.Appearance.Options.UseFont = True
        Me.txtArticleName.Properties.MaxLength = 150
        Me.txtArticleName.Size = New System.Drawing.Size(168, 22)
        ToolTipTitleItem3.Text = "Artikelname /Modellnummer"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Dies kann eine frei vergebene Artikelnummer sein oder eine Modellnummer des Herst" & _
    "ellers."
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.txtArticleName.SuperTip = SuperToolTip3
        Me.txtArticleName.TabIndex = 24
        '
        'lblCreatedAt
        '
        Me.lblCreatedAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAt.Appearance.Options.UseFont = True
        Me.lblCreatedAt.Location = New System.Drawing.Point(3, 110)
        Me.lblCreatedAt.Name = "lblCreatedAt"
        Me.lblCreatedAt.Size = New System.Drawing.Size(91, 15)
        Me.lblCreatedAt.TabIndex = 25
        Me.lblCreatedAt.Text = "Neu angelegt am"
        '
        'txtCreatedAt
        '
        Me.txtCreatedAt.Location = New System.Drawing.Point(6, 132)
        Me.txtCreatedAt.Name = "txtCreatedAt"
        Me.txtCreatedAt.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreatedAt.Properties.Appearance.Options.UseFont = True
        Me.txtCreatedAt.Properties.DisplayFormat.FormatString = "d"
        Me.txtCreatedAt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtCreatedAt.Properties.EditFormat.FormatString = "d"
        Me.txtCreatedAt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtCreatedAt.Properties.ReadOnly = True
        Me.txtCreatedAt.Size = New System.Drawing.Size(168, 22)
        ToolTipTitleItem4.Text = "Artikelname / ID"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Eindeutige Nummer des Artikels in dieser Datenbank"
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.txtCreatedAt.SuperTip = SuperToolTip4
        Me.txtCreatedAt.TabIndex = 24
        '
        'tabCalculation
        '
        Me.tabCalculation.Controls.Add(Me.chkDiscountEnable)
        Me.tabCalculation.Controls.Add(Me.chkRessources)
        Me.tabCalculation.Controls.Add(Me.lblTaxRate)
        Me.tabCalculation.Controls.Add(Me.cboTax)
        Me.tabCalculation.Controls.Add(Me.FlowLayoutPanel1)
        Me.tabCalculation.Controls.Add(Me.lblCount)
        Me.tabCalculation.Controls.Add(Me.lblBaseUnit)
        Me.tabCalculation.Controls.Add(Me.lblVPUnit)
        Me.tabCalculation.Controls.Add(Me.txtItemCount)
        Me.tabCalculation.Controls.Add(Me.MruPack)
        Me.tabCalculation.Controls.Add(Me.MruBase1)
        Me.tabCalculation.Name = "tabCalculation"
        Me.tabCalculation.Size = New System.Drawing.Size(861, 216)
        Me.tabCalculation.Text = "Preise"
        '
        'chkDiscountEnable
        '
        Me.chkDiscountEnable.EditValue = True
        Me.chkDiscountEnable.Location = New System.Drawing.Point(9, 134)
        Me.chkDiscountEnable.Margin = New System.Windows.Forms.Padding(0)
        Me.chkDiscountEnable.Name = "chkDiscountEnable"
        Me.chkDiscountEnable.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDiscountEnable.Properties.Appearance.Options.UseFont = True
        Me.chkDiscountEnable.Properties.AutoWidth = True
        Me.chkDiscountEnable.Properties.Caption = "Rabattberechnung nutzen"
        Me.chkDiscountEnable.Size = New System.Drawing.Size(160, 20)
        Me.chkDiscountEnable.TabIndex = 37
        '
        'chkRessources
        '
        Me.chkRessources.EditValue = True
        Me.chkRessources.Location = New System.Drawing.Point(9, 155)
        Me.chkRessources.Margin = New System.Windows.Forms.Padding(0)
        Me.chkRessources.Name = "chkRessources"
        Me.chkRessources.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRessources.Properties.Appearance.Options.UseFont = True
        Me.chkRessources.Properties.AutoWidth = True
        Me.chkRessources.Properties.Caption = "Rohstoffpreise nutzen"
        Me.chkRessources.Size = New System.Drawing.Size(138, 20)
        Me.chkRessources.TabIndex = 37
        '
        'lblTaxRate
        '
        Me.lblTaxRate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxRate.Appearance.Options.UseFont = True
        Me.lblTaxRate.Location = New System.Drawing.Point(10, 9)
        Me.lblTaxRate.Name = "lblTaxRate"
        Me.lblTaxRate.Size = New System.Drawing.Size(53, 15)
        Me.lblTaxRate.TabIndex = 38
        Me.lblTaxRate.Text = "Steuersatz"
        '
        'cboTax
        '
        Me.cboTax.Location = New System.Drawing.Point(133, 6)
        Me.cboTax.Name = "cboTax"
        Me.cboTax.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTax.Properties.Appearance.Options.UseFont = True
        Me.cboTax.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTax.Properties.Items.AddRange(New Object() {"Ohne 0 %", "Ermässigt 7 %", "Standard 19%"})
        Me.cboTax.Properties.MaxLength = 100
        Me.cboTax.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboTax.Size = New System.Drawing.Size(107, 22)
        Me.cboTax.TabIndex = 37
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.tabPaneleinkauf)
        Me.FlowLayoutPanel1.Controls.Add(Me.tabPanelDiscounts)
        Me.FlowLayoutPanel1.Controls.Add(Me.tabPanelResources)
        Me.FlowLayoutPanel1.Controls.Add(Me.tabPanelGwinn)
        Me.FlowLayoutPanel1.Controls.Add(Me.TabPanelendPrice)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(383, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(478, 216)
        Me.FlowLayoutPanel1.TabIndex = 36
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'tabPaneleinkauf
        '
        Me.tabPaneleinkauf.ColumnCount = 4
        Me.tabPaneleinkauf.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.04531!))
        Me.tabPaneleinkauf.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.tabPaneleinkauf.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.46138!))
        Me.tabPaneleinkauf.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.tabPaneleinkauf.Controls.Add(Me.pnlEinkauf, 0, 0)
        Me.tabPaneleinkauf.Controls.Add(Me.lblFactor, 2, 0)
        Me.tabPaneleinkauf.Controls.Add(Me.txtSingleEKMulti, 3, 0)
        Me.tabPaneleinkauf.Controls.Add(Me.txtsingleEK1, 1, 0)
        Me.tabPaneleinkauf.Location = New System.Drawing.Point(1, 1)
        Me.tabPaneleinkauf.Margin = New System.Windows.Forms.Padding(1)
        Me.tabPaneleinkauf.Name = "tabPaneleinkauf"
        Me.tabPaneleinkauf.RowCount = 1
        Me.tabPaneleinkauf.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tabPaneleinkauf.Size = New System.Drawing.Size(464, 30)
        Me.tabPaneleinkauf.TabIndex = 36
        '
        'pnlEinkauf
        '
        Me.pnlEinkauf.Controls.Add(Me.lblSingleBasePrice)
        Me.pnlEinkauf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEinkauf.Location = New System.Drawing.Point(0, 0)
        Me.pnlEinkauf.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlEinkauf.Name = "pnlEinkauf"
        Me.pnlEinkauf.Size = New System.Drawing.Size(167, 30)
        Me.pnlEinkauf.TabIndex = 38
        '
        'lblSingleBasePrice
        '
        Me.lblSingleBasePrice.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSingleBasePrice.Appearance.Options.UseFont = True
        Me.lblSingleBasePrice.Location = New System.Drawing.Point(3, 7)
        Me.lblSingleBasePrice.Name = "lblSingleBasePrice"
        Me.lblSingleBasePrice.Size = New System.Drawing.Size(108, 15)
        Me.lblSingleBasePrice.TabIndex = 37
        Me.lblSingleBasePrice.Text = "Einzel Einkaufspreis"
        '
        'lblFactor
        '
        Me.lblFactor.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactor.Appearance.Options.UseFont = True
        Me.lblFactor.Location = New System.Drawing.Point(289, 3)
        Me.lblFactor.Name = "lblFactor"
        Me.lblFactor.Size = New System.Drawing.Size(34, 15)
        Me.lblFactor.TabIndex = 12
        Me.lblFactor.Text = "x 250:"
        '
        'txtSingleEKMulti
        '
        Me.txtSingleEKMulti.Location = New System.Drawing.Point(346, 3)
        Me.txtSingleEKMulti.Name = "txtSingleEKMulti"
        Me.txtSingleEKMulti.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSingleEKMulti.Properties.Appearance.Options.UseFont = True
        Me.txtSingleEKMulti.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSingleEKMulti.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtSingleEKMulti.Properties.DisplayFormat.FormatString = "c2"
        Me.txtSingleEKMulti.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSingleEKMulti.Properties.EditFormat.FormatString = "n4"
        Me.txtSingleEKMulti.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSingleEKMulti.Properties.Mask.EditMask = "d"
        Me.txtSingleEKMulti.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSingleEKMulti.Size = New System.Drawing.Size(113, 22)
        Me.txtSingleEKMulti.TabIndex = 1
        '
        'txtsingleEK1
        '
        Me.txtsingleEK1.Location = New System.Drawing.Point(170, 3)
        Me.txtsingleEK1.Name = "txtsingleEK1"
        Me.txtsingleEK1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsingleEK1.Properties.Appearance.Options.UseFont = True
        Me.txtsingleEK1.Properties.Appearance.Options.UseTextOptions = True
        Me.txtsingleEK1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtsingleEK1.Properties.DisplayFormat.FormatString = "c2"
        Me.txtsingleEK1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtsingleEK1.Properties.EditFormat.FormatString = "n4"
        Me.txtsingleEK1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtsingleEK1.Properties.Mask.BeepOnError = True
        Me.txtsingleEK1.Properties.Mask.EditMask = "d"
        Me.txtsingleEK1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtsingleEK1.Size = New System.Drawing.Size(112, 22)
        ToolTipTitleItem5.Text = "Einzel Einkaufspreis (netto)"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Tragen sie hier den einzel Einkaufspreis ein, so wie Ihr Händeler ihnen diesen mi" & _
    "tteilt. "
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.txtsingleEK1.SuperTip = SuperToolTip5
        Me.txtsingleEK1.TabIndex = 1
        '
        'tabPanelDiscounts
        '
        Me.tabPanelDiscounts.ColumnCount = 4
        Me.tabPanelDiscounts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.04531!))
        Me.tabPanelDiscounts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.tabPanelDiscounts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.46138!))
        Me.tabPanelDiscounts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.tabPanelDiscounts.Controls.Add(Me.lblFactorDiscount, 2, 0)
        Me.tabPanelDiscounts.Controls.Add(Me.txtRabattPreisMulti, 3, 0)
        Me.tabPanelDiscounts.Controls.Add(Me.Panel6, 0, 0)
        Me.tabPanelDiscounts.Controls.Add(Me.Panel1, 1, 0)
        Me.tabPanelDiscounts.Location = New System.Drawing.Point(1, 33)
        Me.tabPanelDiscounts.Margin = New System.Windows.Forms.Padding(1)
        Me.tabPanelDiscounts.Name = "tabPanelDiscounts"
        Me.tabPanelDiscounts.RowCount = 1
        Me.tabPanelDiscounts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tabPanelDiscounts.Size = New System.Drawing.Size(464, 52)
        Me.tabPanelDiscounts.TabIndex = 35
        '
        'lblFactorDiscount
        '
        Me.lblFactorDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFactorDiscount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactorDiscount.Appearance.Options.UseFont = True
        Me.lblFactorDiscount.Location = New System.Drawing.Point(289, 34)
        Me.lblFactorDiscount.Name = "lblFactorDiscount"
        Me.lblFactorDiscount.Size = New System.Drawing.Size(29, 15)
        Me.lblFactorDiscount.TabIndex = 18
        Me.lblFactorDiscount.Text = "x 250:"
        '
        'txtRabattPreisMulti
        '
        Me.txtRabattPreisMulti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRabattPreisMulti.Location = New System.Drawing.Point(346, 29)
        Me.txtRabattPreisMulti.Name = "txtRabattPreisMulti"
        Me.txtRabattPreisMulti.Properties.DisplayFormat.FormatString = "#,00"
        Me.txtRabattPreisMulti.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRabattPreisMulti.Properties.EditFormat.FormatString = "#,00"
        Me.txtRabattPreisMulti.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRabattPreisMulti.Properties.Mask.EditMask = "d"
        Me.txtRabattPreisMulti.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRabattPreisMulti.Properties.ReadOnly = True
        Me.txtRabattPreisMulti.Size = New System.Drawing.Size(115, 20)
        Me.txtRabattPreisMulti.TabIndex = 15
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblDiscount)
        Me.Panel6.Controls.Add(Me.cboRabatt)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(167, 52)
        Me.Panel6.TabIndex = 19
        '
        'lblDiscount
        '
        Me.lblDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDiscount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscount.Appearance.Options.UseFont = True
        Me.lblDiscount.Location = New System.Drawing.Point(3, 6)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Size = New System.Drawing.Size(120, 15)
        Me.lblDiscount.TabIndex = 38
        Me.lblDiscount.Text = "Rabatt vom Listenpreis"
        '
        'cboRabatt
        '
        Me.cboRabatt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRabatt.Location = New System.Drawing.Point(3, 25)
        Me.cboRabatt.Name = "cboRabatt"
        Me.cboRabatt.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRabatt.Properties.Appearance.Options.UseFont = True
        Me.cboRabatt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboRabatt.Properties.Sorted = True
        Me.cboRabatt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboRabatt.Size = New System.Drawing.Size(160, 22)
        ToolTipTitleItem6.Text = "Rabatt auswählen"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Wählen Sie ihren Händlerrabatt auf diesen Artikel aus. Rabatte werden immer vom a" & _
    "ngegebenen Einkaufspreis noch abgezogen. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rabatte lassen sich im Menü ""Extras=>" & _
    "Optionen=>Artikel"" verwalten."
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.cboRabatt.SuperTip = SuperToolTip6
        Me.cboRabatt.TabIndex = 37
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtRabattpreis)
        Me.Panel1.Location = New System.Drawing.Point(167, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(119, 52)
        Me.Panel1.TabIndex = 20
        '
        'txtRabattpreis
        '
        Me.txtRabattpreis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRabattpreis.Location = New System.Drawing.Point(3, 27)
        Me.txtRabattpreis.Name = "txtRabattpreis"
        Me.txtRabattpreis.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRabattpreis.Properties.Appearance.Options.UseFont = True
        Me.txtRabattpreis.Properties.Appearance.Options.UseTextOptions = True
        Me.txtRabattpreis.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtRabattpreis.Properties.DisplayFormat.FormatString = "c2"
        Me.txtRabattpreis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRabattpreis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRabattpreis.Properties.Mask.EditMask = "d"
        Me.txtRabattpreis.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRabattpreis.Properties.ReadOnly = True
        Me.txtRabattpreis.Size = New System.Drawing.Size(112, 22)
        ToolTipTitleItem7.Text = "Rabattierter Einzelpreis"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Falls ein Rabatt gewählrt wurde, steht hier der ermässigte Einkaufspreis."
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.txtRabattpreis.SuperTip = SuperToolTip7
        Me.txtRabattpreis.TabIndex = 16
        '
        'tabPanelResources
        '
        Me.tabPanelResources.ColumnCount = 4
        Me.tabPanelResources.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.04531!))
        Me.tabPanelResources.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.tabPanelResources.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.46138!))
        Me.tabPanelResources.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.tabPanelResources.Controls.Add(Me.Panel13, 0, 0)
        Me.tabPanelResources.Controls.Add(Me.txtRohstoffPreisMulti, 3, 0)
        Me.tabPanelResources.Controls.Add(Me.lblFactorResources, 2, 0)
        Me.tabPanelResources.Controls.Add(Me.txtRohstoffpreis, 1, 0)
        Me.tabPanelResources.Location = New System.Drawing.Point(1, 87)
        Me.tabPanelResources.Margin = New System.Windows.Forms.Padding(1)
        Me.tabPanelResources.Name = "tabPanelResources"
        Me.tabPanelResources.RowCount = 1
        Me.tabPanelResources.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tabPanelResources.Size = New System.Drawing.Size(464, 30)
        Me.tabPanelResources.TabIndex = 32
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.lblCommondityPrice)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(167, 30)
        Me.Panel13.TabIndex = 37
        '
        'lblCommondityPrice
        '
        Me.lblCommondityPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCommondityPrice.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCommondityPrice.Appearance.Options.UseFont = True
        Me.lblCommondityPrice.Location = New System.Drawing.Point(3, 7)
        Me.lblCommondityPrice.Name = "lblCommondityPrice"
        Me.lblCommondityPrice.Size = New System.Drawing.Size(76, 15)
        Me.lblCommondityPrice.TabIndex = 21
        Me.lblCommondityPrice.Text = "Rohstoffpreise"
        '
        'txtRohstoffPreisMulti
        '
        Me.txtRohstoffPreisMulti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRohstoffPreisMulti.Location = New System.Drawing.Point(346, 3)
        Me.txtRohstoffPreisMulti.Name = "txtRohstoffPreisMulti"
        Me.txtRohstoffPreisMulti.Properties.Appearance.Options.UseTextOptions = True
        Me.txtRohstoffPreisMulti.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtRohstoffPreisMulti.Properties.DisplayFormat.FormatString = "c2"
        Me.txtRohstoffPreisMulti.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRohstoffPreisMulti.Properties.EditFormat.FormatString = "N4"
        Me.txtRohstoffPreisMulti.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRohstoffPreisMulti.Properties.Mask.EditMask = "d"
        Me.txtRohstoffPreisMulti.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRohstoffPreisMulti.Size = New System.Drawing.Size(115, 20)
        Me.txtRohstoffPreisMulti.TabIndex = 27
        '
        'lblFactorResources
        '
        Me.lblFactorResources.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFactorResources.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactorResources.Appearance.Options.UseFont = True
        Me.lblFactorResources.Location = New System.Drawing.Point(289, 3)
        Me.lblFactorResources.Name = "lblFactorResources"
        Me.lblFactorResources.Size = New System.Drawing.Size(29, 15)
        Me.lblFactorResources.TabIndex = 22
        Me.lblFactorResources.Text = "x 250:"
        '
        'txtRohstoffpreis
        '
        Me.txtRohstoffpreis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRohstoffpreis.EditValue = 12.22R
        Me.txtRohstoffpreis.Location = New System.Drawing.Point(170, 3)
        Me.txtRohstoffpreis.Name = "txtRohstoffpreis"
        Me.txtRohstoffpreis.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRohstoffpreis.Properties.Appearance.Options.UseFont = True
        Me.txtRohstoffpreis.Properties.Appearance.Options.UseTextOptions = True
        Me.txtRohstoffpreis.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtRohstoffpreis.Properties.DisplayFormat.FormatString = "c2"
        Me.txtRohstoffpreis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRohstoffpreis.Properties.EditFormat.FormatString = "n4"
        Me.txtRohstoffpreis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRohstoffpreis.Properties.Mask.EditMask = "c"
        Me.txtRohstoffpreis.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRohstoffpreis.Properties.ReadOnly = True
        Me.txtRohstoffpreis.Size = New System.Drawing.Size(113, 22)
        Me.txtRohstoffpreis.TabIndex = 20
        '
        'tabPanelGwinn
        '
        Me.tabPanelGwinn.ColumnCount = 4
        Me.tabPanelGwinn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.04531!))
        Me.tabPanelGwinn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.tabPanelGwinn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.46138!))
        Me.tabPanelGwinn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.tabPanelGwinn.Controls.Add(Me.Panel8, 1, 0)
        Me.tabPanelGwinn.Controls.Add(Me.lblFactorGewinn, 2, 0)
        Me.tabPanelGwinn.Controls.Add(Me.txtAufschlagMulti, 3, 0)
        Me.tabPanelGwinn.Controls.Add(Me.pnlAufschlag, 0, 0)
        Me.tabPanelGwinn.Location = New System.Drawing.Point(1, 119)
        Me.tabPanelGwinn.Margin = New System.Windows.Forms.Padding(1)
        Me.tabPanelGwinn.Name = "tabPanelGwinn"
        Me.tabPanelGwinn.RowCount = 1
        Me.tabPanelGwinn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tabPanelGwinn.Size = New System.Drawing.Size(464, 30)
        Me.tabPanelGwinn.TabIndex = 34
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.cboAddValueStyle)
        Me.Panel8.Controls.Add(Me.txtAufschlagAbsolut)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(167, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(119, 30)
        Me.Panel8.TabIndex = 38
        '
        'cboAddValueStyle
        '
        Me.cboAddValueStyle.Location = New System.Drawing.Point(72, 5)
        Me.cboAddValueStyle.Name = "cboAddValueStyle"
        Me.cboAddValueStyle.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAddValueStyle.Properties.Appearance.Options.UseFont = True
        Me.cboAddValueStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboAddValueStyle.Properties.ImmediatePopup = True
        Me.cboAddValueStyle.Properties.Items.AddRange(New Object() {"%", "€"})
        Me.cboAddValueStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboAddValueStyle.Size = New System.Drawing.Size(43, 22)
        ToolTipTitleItem8.Text = "Aufschläge Prozentual oder Absolut definieren"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Sie können Aufschläge auf einen Artikel entweder in Prozent des Einkaufes oder al" & _
    "s festen Wert ausdrücken. "
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.cboAddValueStyle.SuperTip = SuperToolTip8
        Me.cboAddValueStyle.TabIndex = 38
        '
        'txtAufschlagAbsolut
        '
        Me.txtAufschlagAbsolut.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAufschlagAbsolut.Location = New System.Drawing.Point(2, 5)
        Me.txtAufschlagAbsolut.Name = "txtAufschlagAbsolut"
        Me.txtAufschlagAbsolut.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAufschlagAbsolut.Properties.Appearance.Options.UseFont = True
        Me.txtAufschlagAbsolut.Properties.Appearance.Options.UseTextOptions = True
        Me.txtAufschlagAbsolut.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtAufschlagAbsolut.Properties.DisplayFormat.FormatString = "c2"
        Me.txtAufschlagAbsolut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAufschlagAbsolut.Properties.EditFormat.FormatString = "n4"
        Me.txtAufschlagAbsolut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAufschlagAbsolut.Properties.Mask.EditMask = "d"
        Me.txtAufschlagAbsolut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAufschlagAbsolut.Size = New System.Drawing.Size(70, 22)
        Me.txtAufschlagAbsolut.TabIndex = 24
        '
        'lblFactorGewinn
        '
        Me.lblFactorGewinn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFactorGewinn.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactorGewinn.Appearance.Options.UseFont = True
        Me.lblFactorGewinn.Location = New System.Drawing.Point(289, 3)
        Me.lblFactorGewinn.Name = "lblFactorGewinn"
        Me.lblFactorGewinn.Size = New System.Drawing.Size(29, 15)
        Me.lblFactorGewinn.TabIndex = 26
        Me.lblFactorGewinn.Text = "x 250:"
        '
        'txtAufschlagMulti
        '
        Me.txtAufschlagMulti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAufschlagMulti.Location = New System.Drawing.Point(346, 3)
        Me.txtAufschlagMulti.Name = "txtAufschlagMulti"
        Me.txtAufschlagMulti.Properties.Appearance.Options.UseTextOptions = True
        Me.txtAufschlagMulti.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtAufschlagMulti.Properties.DisplayFormat.FormatString = "#,00"
        Me.txtAufschlagMulti.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAufschlagMulti.Properties.EditFormat.FormatString = "N4"
        Me.txtAufschlagMulti.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAufschlagMulti.Properties.Mask.EditMask = "d"
        Me.txtAufschlagMulti.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAufschlagMulti.Size = New System.Drawing.Size(115, 20)
        Me.txtAufschlagMulti.TabIndex = 23
        '
        'pnlAufschlag
        '
        Me.pnlAufschlag.Controls.Add(Me.lblGewinnzuschlag)
        Me.pnlAufschlag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAufschlag.Location = New System.Drawing.Point(0, 0)
        Me.pnlAufschlag.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlAufschlag.Name = "pnlAufschlag"
        Me.pnlAufschlag.Size = New System.Drawing.Size(167, 30)
        Me.pnlAufschlag.TabIndex = 27
        '
        'lblGewinnzuschlag
        '
        Me.lblGewinnzuschlag.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGewinnzuschlag.Appearance.Options.UseFont = True
        Me.lblGewinnzuschlag.Location = New System.Drawing.Point(3, 7)
        Me.lblGewinnzuschlag.Name = "lblGewinnzuschlag"
        Me.lblGewinnzuschlag.Size = New System.Drawing.Size(53, 15)
        Me.lblGewinnzuschlag.TabIndex = 25
        Me.lblGewinnzuschlag.Text = "Aufschlag"
        '
        'TabPanelendPrice
        '
        Me.TabPanelendPrice.ColumnCount = 4
        Me.TabPanelendPrice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.04531!))
        Me.TabPanelendPrice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.TabPanelendPrice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.46138!))
        Me.TabPanelendPrice.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.74665!))
        Me.TabPanelendPrice.Controls.Add(Me.Panel9, 0, 0)
        Me.TabPanelendPrice.Controls.Add(Me.txtVerkaufspreis, 1, 0)
        Me.TabPanelendPrice.Controls.Add(Me.lblFactorVerkauf, 2, 0)
        Me.TabPanelendPrice.Controls.Add(Me.txtVerkaufspreisMulti, 3, 0)
        Me.TabPanelendPrice.Location = New System.Drawing.Point(1, 151)
        Me.TabPanelendPrice.Margin = New System.Windows.Forms.Padding(1)
        Me.TabPanelendPrice.Name = "TabPanelendPrice"
        Me.TabPanelendPrice.RowCount = 1
        Me.TabPanelendPrice.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TabPanelendPrice.Size = New System.Drawing.Size(464, 31)
        Me.TabPanelendPrice.TabIndex = 33
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.chkFixedendPrice)
        Me.Panel9.Controls.Add(Me.lblTotalsalesPrice)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(167, 31)
        Me.Panel9.TabIndex = 38
        '
        'chkFixedendPrice
        '
        Me.chkFixedendPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkFixedendPrice.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Symbol_Security_Unlocked
        Me.chkFixedendPrice.Location = New System.Drawing.Point(134, -1)
        Me.chkFixedendPrice.Name = "chkFixedendPrice"
        Me.chkFixedendPrice.Size = New System.Drawing.Size(29, 29)
        ToolTipTitleItem9.Text = "Verkaufspreis fixieren"
        ToolTipItem9.LeftIndent = 6
        ToolTipItem9.Text = "Wenn Fixiert, bleibt der Verkaufspreis stets gleich, auch wenn sich der Einkaufsp" & _
    "reis ändert. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Eine Änderung des Aufschlages ist nicht möglich und hat keine Aus" & _
    "wirkungen"
        SuperToolTip9.Items.Add(ToolTipTitleItem9)
        SuperToolTip9.Items.Add(ToolTipItem9)
        Me.chkFixedendPrice.SuperTip = SuperToolTip9
        Me.chkFixedendPrice.TabIndex = 37
        '
        'lblTotalsalesPrice
        '
        Me.lblTotalsalesPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalsalesPrice.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalsalesPrice.Appearance.Options.UseFont = True
        Me.lblTotalsalesPrice.Location = New System.Drawing.Point(3, 7)
        Me.lblTotalsalesPrice.Name = "lblTotalsalesPrice"
        Me.lblTotalsalesPrice.Size = New System.Drawing.Size(77, 15)
        Me.lblTotalsalesPrice.TabIndex = 29
        Me.lblTotalsalesPrice.Text = "Verkaufspreis"
        '
        'txtVerkaufspreis
        '
        Me.txtVerkaufspreis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVerkaufspreis.Location = New System.Drawing.Point(170, 3)
        Me.txtVerkaufspreis.Name = "txtVerkaufspreis"
        Me.txtVerkaufspreis.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVerkaufspreis.Properties.Appearance.Options.UseFont = True
        Me.txtVerkaufspreis.Properties.Appearance.Options.UseTextOptions = True
        Me.txtVerkaufspreis.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtVerkaufspreis.Properties.DisplayFormat.FormatString = "c2"
        Me.txtVerkaufspreis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtVerkaufspreis.Properties.EditFormat.FormatString = "n4"
        Me.txtVerkaufspreis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtVerkaufspreis.Properties.Mask.EditMask = "d"
        Me.txtVerkaufspreis.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtVerkaufspreis.Size = New System.Drawing.Size(113, 22)
        ToolTipTitleItem10.Text = "Verkaufspreis (netto)"
        ToolTipItem10.LeftIndent = 6
        ToolTipItem10.Text = "Dies ist der (netto) einzel Verkaufspreis der so auch auf einer Kundenrechnung er" & _
    "scheint."
        SuperToolTip10.Items.Add(ToolTipTitleItem10)
        SuperToolTip10.Items.Add(ToolTipItem10)
        Me.txtVerkaufspreis.SuperTip = SuperToolTip10
        Me.txtVerkaufspreis.TabIndex = 28
        '
        'lblFactorVerkauf
        '
        Me.lblFactorVerkauf.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFactorVerkauf.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactorVerkauf.Appearance.Options.UseFont = True
        Me.lblFactorVerkauf.Location = New System.Drawing.Point(289, 3)
        Me.lblFactorVerkauf.Name = "lblFactorVerkauf"
        Me.lblFactorVerkauf.Size = New System.Drawing.Size(34, 15)
        Me.lblFactorVerkauf.TabIndex = 30
        Me.lblFactorVerkauf.Text = "x 250:"
        '
        'txtVerkaufspreisMulti
        '
        Me.txtVerkaufspreisMulti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVerkaufspreisMulti.Location = New System.Drawing.Point(346, 3)
        Me.txtVerkaufspreisMulti.Name = "txtVerkaufspreisMulti"
        Me.txtVerkaufspreisMulti.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVerkaufspreisMulti.Properties.Appearance.Options.UseFont = True
        Me.txtVerkaufspreisMulti.Properties.Appearance.Options.UseTextOptions = True
        Me.txtVerkaufspreisMulti.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtVerkaufspreisMulti.Properties.DisplayFormat.FormatString = "C2"
        Me.txtVerkaufspreisMulti.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtVerkaufspreisMulti.Properties.EditFormat.FormatString = "N4"
        Me.txtVerkaufspreisMulti.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtVerkaufspreisMulti.Properties.Mask.EditMask = "d"
        Me.txtVerkaufspreisMulti.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtVerkaufspreisMulti.Size = New System.Drawing.Size(115, 21)
        Me.txtVerkaufspreisMulti.TabIndex = 19
        '
        'lblCount
        '
        Me.lblCount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Appearance.Options.UseFont = True
        Me.lblCount.Location = New System.Drawing.Point(12, 70)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(36, 15)
        Me.lblCount.TabIndex = 14
        Me.lblCount.Text = "Anzahl"
        '
        'lblBaseUnit
        '
        Me.lblBaseUnit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseUnit.Appearance.Options.UseFont = True
        Me.lblBaseUnit.AutoEllipsis = True
        Me.lblBaseUnit.Location = New System.Drawing.Point(10, 39)
        Me.lblBaseUnit.Name = "lblBaseUnit"
        Me.lblBaseUnit.Size = New System.Drawing.Size(71, 15)
        Me.lblBaseUnit.TabIndex = 8
        Me.lblBaseUnit.Text = "Einzel-Einheit"
        '
        'lblVPUnit
        '
        Me.lblVPUnit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVPUnit.Appearance.Options.UseFont = True
        Me.lblVPUnit.AutoEllipsis = True
        Me.lblVPUnit.Location = New System.Drawing.Point(12, 100)
        Me.lblVPUnit.Name = "lblVPUnit"
        Me.lblVPUnit.Size = New System.Drawing.Size(104, 15)
        Me.lblVPUnit.TabIndex = 7
        Me.lblVPUnit.Text = "Verpackungseinheit"
        '
        'txtItemCount
        '
        Me.txtItemCount.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtItemCount.Location = New System.Drawing.Point(133, 67)
        Me.txtItemCount.Name = "txtItemCount"
        Me.txtItemCount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCount.Properties.Appearance.Options.UseFont = True
        Me.txtItemCount.Properties.Appearance.Options.UseTextOptions = True
        Me.txtItemCount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtItemCount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtItemCount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtItemCount.Properties.Mask.EditMask = "f"
        Me.txtItemCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtItemCount.Size = New System.Drawing.Size(107, 22)
        Me.txtItemCount.TabIndex = 1
        '
        'MruPack
        '
        Me.MruPack.EditValue = ""
        Me.MruPack.Location = New System.Drawing.Point(133, 97)
        Me.MruPack.Name = "MruPack"
        Me.MruPack.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MruPack.Properties.Appearance.Options.UseFont = True
        Me.MruPack.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MruPack.Properties.MaxLength = 50
        Me.MruPack.Properties.Sorted = True
        Me.MruPack.Size = New System.Drawing.Size(107, 22)
        Me.MruPack.TabIndex = 3
        '
        'MruBase1
        '
        Me.MruBase1.EditValue = ""
        Me.MruBase1.Location = New System.Drawing.Point(133, 36)
        Me.MruBase1.Name = "MruBase1"
        Me.MruBase1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MruBase1.Properties.Appearance.Options.UseFont = True
        Me.MruBase1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MruBase1.Properties.Items.AddRange(New Object() {"Meter"})
        Me.MruBase1.Properties.MaxLength = 50
        Me.MruBase1.Properties.Sorted = True
        Me.MruBase1.Size = New System.Drawing.Size(107, 22)
        Me.MruBase1.TabIndex = 3
        '
        'tabmiscellaneous
        '
        Me.tabmiscellaneous.Controls.Add(Me.TableLayoutPanel2)
        Me.tabmiscellaneous.Controls.Add(Me.lblPredecessorItems)
        Me.tabmiscellaneous.Name = "tabmiscellaneous"
        Me.tabmiscellaneous.ShowCloseButton = DevExpress.Utils.DefaultBoolean.[True]
        Me.tabmiscellaneous.Size = New System.Drawing.Size(861, 216)
        Me.tabmiscellaneous.Text = "Sonstiges"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel14, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel15, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(861, 216)
        Me.TableLayoutPanel2.TabIndex = 10
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.txtMemo)
        Me.Panel14.Controls.Add(Me.lblMoreNotesAboutArticle)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(3, 3)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(424, 210)
        Me.Panel14.TabIndex = 0
        '
        'txtMemo
        '
        Me.txtMemo.AllowDrop = True
        Me.txtMemo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtMemo.Location = New System.Drawing.Point(0, 37)
        Me.txtMemo.Margin = New System.Windows.Forms.Padding(5)
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemo.Properties.Appearance.Options.UseFont = True
        Me.txtMemo.Size = New System.Drawing.Size(424, 173)
        Me.txtMemo.TabIndex = 5
        '
        'lblMoreNotesAboutArticle
        '
        Me.lblMoreNotesAboutArticle.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoreNotesAboutArticle.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMoreNotesAboutArticle.Appearance.Options.UseFont = True
        Me.lblMoreNotesAboutArticle.Appearance.Options.UseForeColor = True
        Me.lblMoreNotesAboutArticle.Location = New System.Drawing.Point(3, 9)
        Me.lblMoreNotesAboutArticle.Name = "lblMoreNotesAboutArticle"
        Me.lblMoreNotesAboutArticle.Size = New System.Drawing.Size(202, 17)
        Me.lblMoreNotesAboutArticle.TabIndex = 6
        Me.lblMoreNotesAboutArticle.Text = "Notizen/ Anmerkungen zum Artikel"
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.trvHirachy)
        Me.Panel15.Controls.Add(Me.lblSelectOldAndRedeemedArticles)
        Me.Panel15.Controls.Add(Me.btnSetPredecessor)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.Location = New System.Drawing.Point(433, 3)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(425, 210)
        Me.Panel15.TabIndex = 1
        '
        'trvHirachy
        '
        Me.trvHirachy.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TreeListColumn1})
        Me.trvHirachy.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.trvHirachy.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvHirachy.Location = New System.Drawing.Point(0, 89)
        Me.trvHirachy.Name = "trvHirachy"
        Me.trvHirachy.OptionsBehavior.Editable = False
        Me.trvHirachy.OptionsView.ShowColumns = False
        Me.trvHirachy.OptionsView.ShowIndicator = False
        Me.trvHirachy.Padding = New System.Windows.Forms.Padding(3)
        Me.trvHirachy.Size = New System.Drawing.Size(425, 121)
        Me.trvHirachy.TabIndex = 7
        '
        'TreeListColumn1
        '
        Me.TreeListColumn1.Caption = "Text"
        Me.TreeListColumn1.FieldName = "Text"
        Me.TreeListColumn1.Name = "TreeListColumn1"
        Me.TreeListColumn1.Visible = True
        Me.TreeListColumn1.VisibleIndex = 0
        '
        'lblSelectOldAndRedeemedArticles
        '
        Me.lblSelectOldAndRedeemedArticles.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectOldAndRedeemedArticles.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSelectOldAndRedeemedArticles.Appearance.Options.UseFont = True
        Me.lblSelectOldAndRedeemedArticles.Appearance.Options.UseForeColor = True
        Me.lblSelectOldAndRedeemedArticles.Location = New System.Drawing.Point(13, 9)
        Me.lblSelectOldAndRedeemedArticles.Name = "lblSelectOldAndRedeemedArticles"
        Me.lblSelectOldAndRedeemedArticles.Size = New System.Drawing.Size(331, 17)
        Me.lblSelectOldAndRedeemedArticles.TabIndex = 6
        Me.lblSelectOldAndRedeemedArticles.Text = "Dieser Artikel ersetzt die in der Liste aufgeführten Artikel."
        '
        'btnSetPredecessor
        '
        Me.btnSetPredecessor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetPredecessor.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetPredecessor.Appearance.Options.UseFont = True
        Me.btnSetPredecessor.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Add_16x16
        Me.btnSetPredecessor.Location = New System.Drawing.Point(241, 37)
        Me.btnSetPredecessor.Name = "btnSetPredecessor"
        Me.btnSetPredecessor.Size = New System.Drawing.Size(171, 23)
        Me.btnSetPredecessor.TabIndex = 9
        Me.btnSetPredecessor.Text = "Alten Artikel hinzufügen..."
        '
        'lblPredecessorItems
        '
        Me.lblPredecessorItems.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredecessorItems.Appearance.Options.UseFont = True
        Me.lblPredecessorItems.Location = New System.Drawing.Point(405, 12)
        Me.lblPredecessorItems.Name = "lblPredecessorItems"
        Me.lblPredecessorItems.Size = New System.Drawing.Size(77, 15)
        Me.lblPredecessorItems.TabIndex = 8
        Me.lblPredecessorItems.Text = "Lässt veralten: "
        '
        'tabPictures
        '
        Me.tabPictures.Controls.Add(Me.grdImages)
        Me.tabPictures.Name = "tabPictures"
        Me.tabPictures.Size = New System.Drawing.Size(861, 216)
        Me.tabPictures.Text = "Bilder"
        '
        'grdImages
        '
        Me.grdImages.AllowDrop = True
        Me.grdImages.ContextMenuStrip = Me.cmsImages
        Me.grdImages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdImages.Location = New System.Drawing.Point(0, 0)
        Me.grdImages.MainView = Me.lvImages
        Me.grdImages.Name = "grdImages"
        Me.grdImages.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemPictureEdit1})
        Me.grdImages.Size = New System.Drawing.Size(861, 216)
        Me.grdImages.TabIndex = 2
        Me.grdImages.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.lvImages})
        '
        'cmsImages
        '
        Me.cmsImages.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewImage, Me.mnuDeleteImage, Me.mnuInsert, Me.mnuEditPictures})
        Me.cmsImages.Name = "cmsImages"
        Me.cmsImages.Size = New System.Drawing.Size(153, 114)
        '
        'mnuNewImage
        '
        Me.mnuNewImage.Name = "mnuNewImage"
        Me.mnuNewImage.Size = New System.Drawing.Size(152, 22)
        Me.mnuNewImage.Text = "Hinzufügen..."
        '
        'mnuDeleteImage
        '
        Me.mnuDeleteImage.Name = "mnuDeleteImage"
        Me.mnuDeleteImage.Size = New System.Drawing.Size(152, 22)
        Me.mnuDeleteImage.Text = "Löschen"
        '
        'mnuInsert
        '
        Me.mnuInsert.Name = "mnuInsert"
        Me.mnuInsert.Size = New System.Drawing.Size(152, 22)
        Me.mnuInsert.Text = "Einfügen"
        '
        'mnuEditPictures
        '
        Me.mnuEditPictures.CheckOnClick = True
        Me.mnuEditPictures.Name = "mnuEditPictures"
        Me.mnuEditPictures.Size = New System.Drawing.Size(152, 22)
        Me.mnuEditPictures.Text = "Bearbeiten"
        '
        'lvImages
        '
        Me.lvImages.CardMinSize = New System.Drawing.Size(23, 21)
        Me.lvImages.Columns.AddRange(New DevExpress.XtraGrid.Columns.LayoutViewColumn() {Me.colName, Me.colImage, Me.colResulution, Me.LayoutViewColumn1})
        Me.lvImages.GridControl = Me.grdImages
        Me.lvImages.Name = "lvImages"
        Me.lvImages.OptionsBehavior.Editable = False
        Me.lvImages.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        Me.lvImages.OptionsCustomization.AllowFilter = False
        Me.lvImages.OptionsCustomization.AllowSort = False
        Me.lvImages.OptionsFilter.AllowColumnMRUFilterList = False
        Me.lvImages.OptionsFilter.AllowFilterEditor = False
        Me.lvImages.OptionsFilter.AllowMRUFilterList = False
        Me.lvImages.OptionsHeaderPanel.EnableCarouselModeButton = False
        Me.lvImages.OptionsHeaderPanel.ShowCarouselModeButton = False
        Me.lvImages.OptionsHeaderPanel.ShowSingleModeButton = False
        Me.lvImages.OptionsMultiRecordMode.StretchCardToViewHeight = True
        Me.lvImages.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards
        Me.lvImages.OptionsView.ShowCardCaption = False
        Me.lvImages.OptionsView.ShowCardExpandButton = False
        Me.lvImages.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Row
        Me.lvImages.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
        Me.lvImages.TemplateCard = Me.LayoutViewCard1
        Me.lvImages.ViewCaption = "Bilder des Artikels"
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colName.FieldName = "Name"
        Me.colName.LayoutViewField = Me.layoutViewField_LayoutViewColumn2
        Me.colName.Name = "colName"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'layoutViewField_LayoutViewColumn2
        '
        Me.layoutViewField_LayoutViewColumn2.EditorPreferredWidth = 149
        Me.layoutViewField_LayoutViewColumn2.Location = New System.Drawing.Point(0, 0)
        Me.layoutViewField_LayoutViewColumn2.Name = "layoutViewField_LayoutViewColumn2"
        Me.layoutViewField_LayoutViewColumn2.Size = New System.Drawing.Size(233, 27)
        Me.layoutViewField_LayoutViewColumn2.TextSize = New System.Drawing.Size(68, 13)
        Me.layoutViewField_LayoutViewColumn2.TextToControlDistance = 5
        '
        'colImage
        '
        Me.colImage.ColumnEdit = Me.RepositoryItemPictureEdit1
        Me.colImage.FieldName = "Image"
        Me.colImage.LayoutViewField = Me.layoutViewField_LayoutViewColumn3
        Me.colImage.Name = "colImage"
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        Me.RepositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        '
        'layoutViewField_LayoutViewColumn3
        '
        Me.layoutViewField_LayoutViewColumn3.EditorPreferredWidth = 222
        Me.layoutViewField_LayoutViewColumn3.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.layoutViewField_LayoutViewColumn3.Location = New System.Drawing.Point(0, 27)
        Me.layoutViewField_LayoutViewColumn3.MaxSize = New System.Drawing.Size(250, 250)
        Me.layoutViewField_LayoutViewColumn3.MinSize = New System.Drawing.Size(35, 35)
        Me.layoutViewField_LayoutViewColumn3.Name = "layoutViewField_LayoutViewColumn3"
        Me.layoutViewField_LayoutViewColumn3.Size = New System.Drawing.Size(233, 112)
        Me.layoutViewField_LayoutViewColumn3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutViewField_LayoutViewColumn3.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutViewField_LayoutViewColumn3.TextToControlDistance = 0
        Me.layoutViewField_LayoutViewColumn3.TextVisible = False
        '
        'colResulution
        '
        Me.colResulution.Caption = "Auflösung"
        Me.colResulution.FieldName = "Resolution"
        Me.colResulution.LayoutViewField = Me.layoutViewField_LayoutViewColumn4
        Me.colResulution.Name = "colResulution"
        Me.colResulution.OptionsColumn.AllowEdit = False
        '
        'layoutViewField_LayoutViewColumn4
        '
        Me.layoutViewField_LayoutViewColumn4.EditorPreferredWidth = 149
        Me.layoutViewField_LayoutViewColumn4.Location = New System.Drawing.Point(0, 166)
        Me.layoutViewField_LayoutViewColumn4.Name = "layoutViewField_LayoutViewColumn4"
        Me.layoutViewField_LayoutViewColumn4.Size = New System.Drawing.Size(233, 27)
        Me.layoutViewField_LayoutViewColumn4.TextSize = New System.Drawing.Size(68, 13)
        Me.layoutViewField_LayoutViewColumn4.TextToControlDistance = 5
        '
        'LayoutViewColumn1
        '
        Me.LayoutViewColumn1.Caption = "Beschreibung"
        Me.LayoutViewColumn1.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.LayoutViewColumn1.FieldName = "Description"
        Me.LayoutViewColumn1.LayoutViewField = Me.layoutViewField_LayoutViewColumn1
        Me.LayoutViewColumn1.Name = "LayoutViewColumn1"
        '
        'layoutViewField_LayoutViewColumn1
        '
        Me.layoutViewField_LayoutViewColumn1.EditorPreferredWidth = 149
        Me.layoutViewField_LayoutViewColumn1.Location = New System.Drawing.Point(0, 139)
        Me.layoutViewField_LayoutViewColumn1.MaxSize = New System.Drawing.Size(0, 27)
        Me.layoutViewField_LayoutViewColumn1.MinSize = New System.Drawing.Size(94, 27)
        Me.layoutViewField_LayoutViewColumn1.Name = "layoutViewField_LayoutViewColumn1"
        Me.layoutViewField_LayoutViewColumn1.Size = New System.Drawing.Size(233, 27)
        Me.layoutViewField_LayoutViewColumn1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.layoutViewField_LayoutViewColumn1.TextSize = New System.Drawing.Size(68, 13)
        Me.layoutViewField_LayoutViewColumn1.TextToControlDistance = 5
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "layoutViewTemplateCard"
        Me.LayoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.GroupBordersVisible = False
        Me.LayoutViewCard1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutViewField_LayoutViewColumn2, Me.layoutViewField_LayoutViewColumn3, Me.layoutViewField_LayoutViewColumn1, Me.layoutViewField_LayoutViewColumn4})
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 5
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'tabStorage
        '
        Me.tabStorage.Controls.Add(Me.txteanCode)
        Me.tabStorage.Controls.Add(Me.lblEANCode)
        Me.tabStorage.Controls.Add(Me.tlbLastSelling)
        Me.tabStorage.Controls.Add(Me.tlpLagerbestand)
        Me.tabStorage.Controls.Add(Me.lblSumOfSoldItems)
        Me.tabStorage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabStorage.Name = "tabStorage"
        Me.tabStorage.Size = New System.Drawing.Size(861, 216)
        Me.tabStorage.Text = "Lager"
        '
        'txteanCode
        '
        Me.txteanCode.Location = New System.Drawing.Point(25, 135)
        Me.txteanCode.Name = "txteanCode"
        Me.txteanCode.Properties.MaxLength = 250
        Me.txteanCode.Size = New System.Drawing.Size(117, 20)
        Me.txteanCode.TabIndex = 4
        '
        'lblEANCode
        '
        Me.lblEANCode.Location = New System.Drawing.Point(25, 113)
        Me.lblEANCode.Name = "lblEANCode"
        Me.lblEANCode.Size = New System.Drawing.Size(49, 13)
        Me.lblEANCode.TabIndex = 3
        Me.lblEANCode.Text = "EAN-Code"
        '
        'tlbLastSelling
        '
        Me.tlbLastSelling.AutoSize = True
        Me.tlbLastSelling.ColumnCount = 2
        Me.tlbLastSelling.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175.0!))
        Me.tlbLastSelling.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlbLastSelling.Controls.Add(Me.lblLastSoldDate, 1, 0)
        Me.tlbLastSelling.Controls.Add(Me.lblSoldAt, 0, 0)
        Me.tlbLastSelling.Location = New System.Drawing.Point(22, 76)
        Me.tlbLastSelling.Name = "tlbLastSelling"
        Me.tlbLastSelling.RowCount = 1
        Me.tlbLastSelling.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlbLastSelling.Size = New System.Drawing.Size(247, 25)
        Me.tlbLastSelling.TabIndex = 2
        '
        'lblLastSoldDate
        '
        Me.lblLastSoldDate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastSoldDate.Appearance.Options.UseFont = True
        Me.lblLastSoldDate.Location = New System.Drawing.Point(178, 3)
        Me.lblLastSoldDate.Name = "lblLastSoldDate"
        Me.lblLastSoldDate.Size = New System.Drawing.Size(54, 15)
        Me.lblLastSoldDate.TabIndex = 3
        Me.lblLastSoldDate.Text = "01.01.2009"
        '
        'lblSoldAt
        '
        Me.lblSoldAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoldAt.Appearance.Options.UseFont = True
        Me.lblSoldAt.Location = New System.Drawing.Point(3, 3)
        Me.lblSoldAt.Name = "lblSoldAt"
        Me.lblSoldAt.Size = New System.Drawing.Size(81, 15)
        Me.lblSoldAt.TabIndex = 3
        Me.lblSoldAt.Text = "Letzter Verkauf:"
        '
        'tlpLagerbestand
        '
        Me.tlpLagerbestand.AutoSize = True
        Me.tlpLagerbestand.ColumnCount = 3
        Me.tlpLagerbestand.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175.0!))
        Me.tlpLagerbestand.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLagerbestand.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpLagerbestand.Controls.Add(Me.lblSummSellings, 1, 0)
        Me.tlpLagerbestand.Controls.Add(Me.lblTextSumsellings, 0, 0)
        Me.tlpLagerbestand.Controls.Add(Me.lblMainUnit, 2, 0)
        Me.tlpLagerbestand.Location = New System.Drawing.Point(22, 42)
        Me.tlpLagerbestand.Name = "tlpLagerbestand"
        Me.tlpLagerbestand.RowCount = 1
        Me.tlpLagerbestand.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLagerbestand.Size = New System.Drawing.Size(346, 27)
        Me.tlpLagerbestand.TabIndex = 1
        '
        'lblSummSellings
        '
        Me.lblSummSellings.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSummSellings.Appearance.Options.UseFont = True
        Me.lblSummSellings.Location = New System.Drawing.Point(178, 3)
        Me.lblSummSellings.Name = "lblSummSellings"
        Me.lblSummSellings.Size = New System.Drawing.Size(14, 15)
        Me.lblSummSellings.TabIndex = 0
        Me.lblSummSellings.Text = "32"
        '
        'lblTextSumsellings
        '
        Me.lblTextSumsellings.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextSumsellings.Appearance.Options.UseFont = True
        Me.lblTextSumsellings.Location = New System.Drawing.Point(3, 3)
        Me.lblTextSumsellings.Name = "lblTextSumsellings"
        Me.lblTextSumsellings.Size = New System.Drawing.Size(131, 15)
        Me.lblTextSumsellings.TabIndex = 0
        Me.lblTextSumsellings.Text = "Geamtanzahl Verkäufe:"
        '
        'lblMainUnit
        '
        Me.lblMainUnit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainUnit.Appearance.Options.UseFont = True
        Me.lblMainUnit.Location = New System.Drawing.Point(198, 3)
        Me.lblMainUnit.Name = "lblMainUnit"
        Me.lblMainUnit.Size = New System.Drawing.Size(135, 15)
        Me.lblMainUnit.TabIndex = 0
        Me.lblMainUnit.Text = "Stück (Aus den Einheiten)"
        '
        'lblSumOfSoldItems
        '
        Me.lblSumOfSoldItems.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumOfSoldItems.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSumOfSoldItems.Appearance.Options.UseFont = True
        Me.lblSumOfSoldItems.Appearance.Options.UseForeColor = True
        Me.lblSumOfSoldItems.Location = New System.Drawing.Point(22, 16)
        Me.lblSumOfSoldItems.Name = "lblSumOfSoldItems"
        Me.lblSumOfSoldItems.Size = New System.Drawing.Size(356, 20)
        Me.lblSumOfSoldItems.TabIndex = 0
        Me.lblSumOfSoldItems.Text = "Summe der bisher verkauften Einheiten dieses Artikels"
        '
        'tabComponents
        '
        Me.tabComponents.Controls.Add(Me.btnTransferSubPrices)
        Me.tabComponents.Controls.Add(Me.lblBomCalculatedTime)
        Me.tabComponents.Controls.Add(Me.lblBomSumEndPrice)
        Me.tabComponents.Controls.Add(Me.lbltxtCalculatedTime)
        Me.tabComponents.Controls.Add(Me.lbltxtCalculatedEndPrice)
        Me.tabComponents.Controls.Add(Me.lblBomSumBasePrice)
        Me.tabComponents.Controls.Add(Me.lbltxtBasePrice)
        Me.tabComponents.Controls.Add(Me.trvsubArticles)
        Me.tabComponents.Name = "tabComponents"
        Me.tabComponents.Size = New System.Drawing.Size(861, 216)
        Me.tabComponents.Text = "Stückliste"
        '
        'btnTransferSubPrices
        '
        Me.btnTransferSubPrices.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTransferSubPrices.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferSubPrices.Appearance.Options.UseFont = True
        Me.btnTransferSubPrices.Location = New System.Drawing.Point(688, 136)
        Me.btnTransferSubPrices.Name = "btnTransferSubPrices"
        Me.btnTransferSubPrices.Size = New System.Drawing.Size(124, 27)
        Me.btnTransferSubPrices.TabIndex = 2
        Me.btnTransferSubPrices.Text = "Preise übertragen"
        '
        'lblBomCalculatedTime
        '
        Me.lblBomCalculatedTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBomCalculatedTime.Location = New System.Drawing.Point(919, 65)
        Me.lblBomCalculatedTime.Name = "lblBomCalculatedTime"
        Me.lblBomCalculatedTime.Size = New System.Drawing.Size(6, 13)
        Me.lblBomCalculatedTime.TabIndex = 1
        Me.lblBomCalculatedTime.Text = "0"
        '
        'lblBomSumEndPrice
        '
        Me.lblBomSumEndPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBomSumEndPrice.Location = New System.Drawing.Point(919, 43)
        Me.lblBomSumEndPrice.Name = "lblBomSumEndPrice"
        Me.lblBomSumEndPrice.Size = New System.Drawing.Size(6, 13)
        Me.lblBomSumEndPrice.TabIndex = 1
        Me.lblBomSumEndPrice.Text = "0"
        '
        'lbltxtCalculatedTime
        '
        Me.lbltxtCalculatedTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxtCalculatedTime.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtCalculatedTime.Appearance.Options.UseFont = True
        Me.lbltxtCalculatedTime.Location = New System.Drawing.Point(677, 61)
        Me.lbltxtCalculatedTime.Name = "lbltxtCalculatedTime"
        Me.lbltxtCalculatedTime.Size = New System.Drawing.Size(115, 15)
        Me.lbltxtCalculatedTime.TabIndex = 1
        Me.lbltxtCalculatedTime.Text = "Berechnete Zeitdauer:"
        '
        'lbltxtCalculatedEndPrice
        '
        Me.lbltxtCalculatedEndPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxtCalculatedEndPrice.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtCalculatedEndPrice.Appearance.Options.UseFont = True
        Me.lbltxtCalculatedEndPrice.Location = New System.Drawing.Point(677, 39)
        Me.lbltxtCalculatedEndPrice.Name = "lbltxtCalculatedEndPrice"
        Me.lbltxtCalculatedEndPrice.Size = New System.Drawing.Size(114, 15)
        Me.lbltxtCalculatedEndPrice.TabIndex = 1
        Me.lbltxtCalculatedEndPrice.Text = "Berechneter Endpreis:"
        '
        'lblBomSumBasePrice
        '
        Me.lblBomSumBasePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBomSumBasePrice.Location = New System.Drawing.Point(919, 21)
        Me.lblBomSumBasePrice.Name = "lblBomSumBasePrice"
        Me.lblBomSumBasePrice.Size = New System.Drawing.Size(6, 13)
        Me.lblBomSumBasePrice.TabIndex = 1
        Me.lblBomSumBasePrice.Text = "0"
        '
        'lbltxtBasePrice
        '
        Me.lbltxtBasePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltxtBasePrice.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltxtBasePrice.Appearance.Options.UseFont = True
        Me.lbltxtBasePrice.Location = New System.Drawing.Point(677, 17)
        Me.lbltxtBasePrice.Name = "lbltxtBasePrice"
        Me.lbltxtBasePrice.Size = New System.Drawing.Size(138, 15)
        Me.lbltxtBasePrice.TabIndex = 1
        Me.lbltxtBasePrice.Text = "Berechneter Einkaufspreis:"
        '
        'trvsubArticles
        '
        Me.trvsubArticles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvsubArticles.ContextMenuStrip = Me.cmsBomItems
        Me.trvsubArticles.Location = New System.Drawing.Point(0, 0)
        Me.trvsubArticles.Name = "trvsubArticles"
        Me.trvsubArticles.OptionsBehavior.DragNodes = True
        Me.trvsubArticles.OptionsBehavior.Editable = False
        Me.trvsubArticles.OptionsBehavior.ResizeNodes = False
        Me.trvsubArticles.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.trvsubArticles.OptionsSelection.MultiSelect = True
        Me.trvsubArticles.Size = New System.Drawing.Size(671, 415)
        Me.trvsubArticles.TabIndex = 0
        '
        'cmsBomItems
        '
        Me.cmsBomItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpenBomItem, Me.mnuAddArticles, Me.ToolStripMenuItem1, Me.mnuCopyArticles, Me.mnuPasteArticles, Me.mnuDeleteBomItems})
        Me.cmsBomItems.Name = "cmsSubArticles"
        Me.cmsBomItems.Size = New System.Drawing.Size(172, 120)
        '
        'btnOpenBomItem
        '
        Me.btnOpenBomItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenBomItem.Name = "btnOpenBomItem"
        Me.btnOpenBomItem.Size = New System.Drawing.Size(171, 22)
        Me.btnOpenBomItem.Text = "Artikel Öffnen"
        '
        'mnuAddArticles
        '
        Me.mnuAddArticles.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Add_16x16
        Me.mnuAddArticles.Name = "mnuAddArticles"
        Me.mnuAddArticles.Size = New System.Drawing.Size(171, 22)
        Me.mnuAddArticles.Text = "Artikel hinzufügen"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(168, 6)
        '
        'mnuCopyArticles
        '
        Me.mnuCopyArticles.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Copy
        Me.mnuCopyArticles.Name = "mnuCopyArticles"
        Me.mnuCopyArticles.Size = New System.Drawing.Size(171, 22)
        Me.mnuCopyArticles.Text = "Kopieren"
        '
        'mnuPasteArticles
        '
        Me.mnuPasteArticles.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.paste
        Me.mnuPasteArticles.Name = "mnuPasteArticles"
        Me.mnuPasteArticles.Size = New System.Drawing.Size(171, 22)
        Me.mnuPasteArticles.Text = "Einfügen"
        '
        'mnuDeleteBomItems
        '
        Me.mnuDeleteBomItems.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Delete
        Me.mnuDeleteBomItems.Name = "mnuDeleteBomItems"
        Me.mnuDeleteBomItems.Size = New System.Drawing.Size(171, 22)
        Me.mnuDeleteBomItems.Text = "Löschen"
        '
        'tabWorkItems
        '
        Me.tabWorkItems.Controls.Add(Me.TableLayoutPanel1)
        Me.tabWorkItems.Controls.Add(Me.chkIsWorkItem)
        Me.tabWorkItems.Name = "tabWorkItems"
        Me.tabWorkItems.Size = New System.Drawing.Size(861, 216)
        Me.tabWorkItems.Text = "Leistungsbeschreibung"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtWorkItemcosts, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblWorkItemCosts, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayGroup, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDuration, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboWorkAccount, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(58, 46)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(374, 95)
        Me.TableLayoutPanel1.TabIndex = 39
        '
        'txtWorkItemcosts
        '
        Me.txtWorkItemcosts.Location = New System.Drawing.Point(189, 59)
        Me.txtWorkItemcosts.Name = "txtWorkItemcosts"
        Me.txtWorkItemcosts.Properties.ReadOnly = True
        Me.txtWorkItemcosts.Size = New System.Drawing.Size(117, 20)
        Me.txtWorkItemcosts.TabIndex = 43
        '
        'lblWorkItemCosts
        '
        Me.lblWorkItemCosts.Location = New System.Drawing.Point(3, 59)
        Me.lblWorkItemCosts.Name = "lblWorkItemCosts"
        Me.lblWorkItemCosts.Size = New System.Drawing.Size(108, 13)
        Me.lblWorkItemCosts.TabIndex = 44
        Me.lblWorkItemCosts.Text = "Kosten dieser Leistung"
        '
        'lblPayGroup
        '
        Me.lblPayGroup.Location = New System.Drawing.Point(3, 3)
        Me.lblPayGroup.Name = "lblPayGroup"
        Me.lblPayGroup.Size = New System.Drawing.Size(61, 13)
        Me.lblPayGroup.TabIndex = 45
        Me.lblPayGroup.Text = "Lohngruppe:"
        '
        'lblDuration
        '
        Me.lblDuration.Location = New System.Drawing.Point(3, 29)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(33, 13)
        Me.lblDuration.TabIndex = 41
        Me.lblDuration.Text = "Dauer:"
        '
        'cboWorkAccount
        '
        Me.cboWorkAccount.EditValue = "Meisterlohn (65 €/std)"
        Me.cboWorkAccount.Location = New System.Drawing.Point(189, 3)
        Me.cboWorkAccount.Name = "cboWorkAccount"
        ToolTipTitleItem11.Text = "Lohngruppe bearbeiten"
        ToolTipItem11.LeftIndent = 6
        ToolTipItem11.Text = "Klicken Sie hier, um die Lohnkonten zu bearbeiten oder neue anzulegen"
        SuperToolTip11.Items.Add(ToolTipTitleItem11)
        SuperToolTip11.Items.Add(ToolTipItem11)
        Me.cboWorkAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", "Edit", SuperToolTip11, False)})
        Me.cboWorkAccount.Properties.Items.AddRange(New Object() {"Gesellenlohn", "Meisterlohn", "Hilfsarbeiter ali"})
        Me.cboWorkAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboWorkAccount.Size = New System.Drawing.Size(181, 20)
        Me.cboWorkAccount.TabIndex = 39
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtWorkTimeSpan)
        Me.Panel7.Controls.Add(Me.lblShortTimeFormat)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(186, 26)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(188, 30)
        Me.Panel7.TabIndex = 46
        '
        'txtWorkTimeSpan
        '
        Me.txtWorkTimeSpan.EditValue = New Date(2009, 10, 26, 0, 0, 0, 0)
        Me.txtWorkTimeSpan.Location = New System.Drawing.Point(3, 3)
        Me.txtWorkTimeSpan.Name = "txtWorkTimeSpan"
        Me.txtWorkTimeSpan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtWorkTimeSpan.Properties.Mask.EditMask = "t"
        Me.txtWorkTimeSpan.Size = New System.Drawing.Size(117, 20)
        Me.txtWorkTimeSpan.TabIndex = 40
        '
        'lblShortTimeFormat
        '
        Me.lblShortTimeFormat.Location = New System.Drawing.Point(127, 7)
        Me.lblShortTimeFormat.Name = "lblShortTimeFormat"
        Me.lblShortTimeFormat.Size = New System.Drawing.Size(45, 13)
        Me.lblShortTimeFormat.TabIndex = 42
        Me.lblShortTimeFormat.Text = "In hh:mm"
        '
        'chkIsWorkItem
        '
        Me.chkIsWorkItem.Location = New System.Drawing.Point(31, 18)
        Me.chkIsWorkItem.Name = "chkIsWorkItem"
        Me.chkIsWorkItem.Properties.AutoWidth = True
        Me.chkIsWorkItem.Properties.Caption = "Artikel ist eine Tätigkeit"
        Me.chkIsWorkItem.Size = New System.Drawing.Size(134, 19)
        Me.chkIsWorkItem.TabIndex = 38
        '
        'tabAttributes
        '
        Me.tabAttributes.Controls.Add(Me.btnEditArticleAttributes)
        Me.tabAttributes.Controls.Add(Me.btnRefresh)
        Me.tabAttributes.Controls.Add(Me.grdAttributes)
        Me.tabAttributes.Name = "tabAttributes"
        Me.tabAttributes.Size = New System.Drawing.Size(861, 216)
        Me.tabAttributes.Text = "Merkmale"
        '
        'btnEditArticleAttributes
        '
        Me.btnEditArticleAttributes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditArticleAttributes.Location = New System.Drawing.Point(696, 3)
        Me.btnEditArticleAttributes.Name = "btnEditArticleAttributes"
        Me.btnEditArticleAttributes.Size = New System.Drawing.Size(152, 44)
        Me.btnEditArticleAttributes.TabIndex = 2
        Me.btnEditArticleAttributes.Text = "Klassifizierung bearbeiten..."
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(1029, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(87, 27)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "Aktualisieren"
        '
        'grdAttributes
        '
        Me.grdAttributes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdAttributes.Location = New System.Drawing.Point(3, 0)
        Me.grdAttributes.MainView = Me.grvAttributes
        Me.grdAttributes.Name = "grdAttributes"
        Me.grdAttributes.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repAttrbutesCheckedit, Me.repAttributesDateEdit, Me.repAttributesEnumValues})
        Me.grdAttributes.Size = New System.Drawing.Size(672, 406)
        Me.grdAttributes.TabIndex = 0
        Me.grdAttributes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvAttributes})
        '
        'grvAttributes
        '
        Me.grvAttributes.GridControl = Me.grdAttributes
        Me.grvAttributes.Name = "grvAttributes"
        Me.grvAttributes.OptionsCustomization.AllowGroup = False
        Me.grvAttributes.OptionsView.ShowGroupPanel = False
        '
        'repAttrbutesCheckedit
        '
        Me.repAttrbutesCheckedit.AutoHeight = False
        Me.repAttrbutesCheckedit.Name = "repAttrbutesCheckedit"
        '
        'repAttributesDateEdit
        '
        Me.repAttributesDateEdit.AutoHeight = False
        Me.repAttributesDateEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repAttributesDateEdit.Name = "repAttributesDateEdit"
        Me.repAttributesDateEdit.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'repAttributesEnumValues
        '
        Me.repAttributesEnumValues.AutoHeight = False
        Me.repAttributesEnumValues.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repAttributesEnumValues.Name = "repAttributesEnumValues"
        Me.repAttributesEnumValues.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'pnlHeadline
        '
        Me.pnlHeadline.ColumnCount = 4
        Me.pnlHeadline.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlHeadline.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166.0!))
        Me.pnlHeadline.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167.0!))
        Me.pnlHeadline.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.pnlHeadline.Controls.Add(Me.Panel2, 0, 0)
        Me.pnlHeadline.Controls.Add(Me.Panel3, 1, 0)
        Me.pnlHeadline.Controls.Add(Me.Panel4, 2, 0)
        Me.pnlHeadline.Controls.Add(Me.Panel5, 3, 0)
        Me.pnlHeadline.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeadline.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeadline.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeadline.Name = "pnlHeadline"
        Me.pnlHeadline.RowCount = 1
        Me.pnlHeadline.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlHeadline.Size = New System.Drawing.Size(868, 64)
        Me.pnlHeadline.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtName)
        Me.Panel2.Controls.Add(Me.lblArticleShortDescription)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(415, 64)
        Me.Panel2.TabIndex = 14
        '
        'txtName
        '
        Me.txtName.AllowDrop = True
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.EditValue = ""
        Me.txtName.Location = New System.Drawing.Point(1, 40)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Properties.Appearance.Options.UseFont = True
        Me.txtName.Properties.MaxLength = 250
        Me.txtName.Properties.NullValuePrompt = "Kurztext des Artikels"
        Me.txtName.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtName.Size = New System.Drawing.Size(410, 22)
        Me.txtName.TabIndex = 0
        '
        'lblArticleShortDescription
        '
        Me.lblArticleShortDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticleShortDescription.Appearance.Options.UseFont = True
        Me.lblArticleShortDescription.Location = New System.Drawing.Point(7, 19)
        Me.lblArticleShortDescription.Name = "lblArticleShortDescription"
        Me.lblArticleShortDescription.Size = New System.Drawing.Size(42, 15)
        Me.lblArticleShortDescription.TabIndex = 10
        Me.lblArticleShortDescription.Text = "Kurztext"
        '
        'Panel3
        '
        Me.Panel3.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel3.Appearance.Options.UseBorderColor = True
        Me.Panel3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.Panel3.Controls.Add(Me.txtSingleEKBrutto)
        Me.Panel3.Controls.Add(Me.txtSingleEK)
        Me.Panel3.Controls.Add(Me.lblWithoutTax)
        Me.Panel3.Controls.Add(Me.lblWithTax)
        Me.Panel3.Controls.Add(Me.lblSingleBasePriceHeadline)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(415, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(166, 64)
        Me.Panel3.TabIndex = 15
        '
        'txtSingleEKBrutto
        '
        Me.txtSingleEKBrutto.AllowDrop = True
        Me.txtSingleEKBrutto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSingleEKBrutto.Location = New System.Drawing.Point(88, 40)
        Me.txtSingleEKBrutto.Name = "txtSingleEKBrutto"
        Me.txtSingleEKBrutto.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSingleEKBrutto.Properties.Appearance.Options.UseFont = True
        Me.txtSingleEKBrutto.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSingleEKBrutto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtSingleEKBrutto.Properties.DisplayFormat.FormatString = "c2"
        Me.txtSingleEKBrutto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSingleEKBrutto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSingleEKBrutto.Properties.Mask.EditMask = "c"
        Me.txtSingleEKBrutto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSingleEKBrutto.Size = New System.Drawing.Size(75, 22)
        ToolTipTitleItem12.Text = "Einzel Einkaufspreis (Brutto)"
        SuperToolTip12.Items.Add(ToolTipTitleItem12)
        Me.txtSingleEKBrutto.SuperTip = SuperToolTip12
        Me.txtSingleEKBrutto.TabIndex = 1
        '
        'txtSingleEK
        '
        Me.txtSingleEK.AllowDrop = True
        Me.txtSingleEK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSingleEK.Location = New System.Drawing.Point(1, 40)
        Me.txtSingleEK.Name = "txtSingleEK"
        Me.txtSingleEK.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSingleEK.Properties.Appearance.Options.UseFont = True
        Me.txtSingleEK.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSingleEK.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtSingleEK.Properties.DisplayFormat.FormatString = "c"
        Me.txtSingleEK.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtSingleEK.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSingleEK.Properties.Mask.EditMask = "c"
        Me.txtSingleEK.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSingleEK.Size = New System.Drawing.Size(75, 22)
        ToolTipTitleItem13.Text = "Einzel Einkaufspreis (netto)"
        SuperToolTip13.Items.Add(ToolTipTitleItem13)
        Me.txtSingleEK.SuperTip = SuperToolTip13
        Me.txtSingleEK.TabIndex = 0
        '
        'lblWithoutTax
        '
        Me.lblWithoutTax.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWithoutTax.Appearance.Options.UseFont = True
        Me.lblWithoutTax.Location = New System.Drawing.Point(3, 24)
        Me.lblWithoutTax.Name = "lblWithoutTax"
        Me.lblWithoutTax.Size = New System.Drawing.Size(30, 15)
        Me.lblWithoutTax.TabIndex = 6
        Me.lblWithoutTax.Text = "Netto"
        '
        'lblWithTax
        '
        Me.lblWithTax.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWithTax.Appearance.Options.UseFont = True
        Me.lblWithTax.Location = New System.Drawing.Point(88, 24)
        Me.lblWithTax.Name = "lblWithTax"
        Me.lblWithTax.Size = New System.Drawing.Size(33, 15)
        Me.lblWithTax.TabIndex = 6
        Me.lblWithTax.Text = "Brutto"
        '
        'lblSingleBasePriceHeadline
        '
        Me.lblSingleBasePriceHeadline.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSingleBasePriceHeadline.Appearance.Options.UseFont = True
        Me.lblSingleBasePriceHeadline.Location = New System.Drawing.Point(19, 3)
        Me.lblSingleBasePriceHeadline.Name = "lblSingleBasePriceHeadline"
        Me.lblSingleBasePriceHeadline.Size = New System.Drawing.Size(102, 15)
        Me.lblSingleBasePriceHeadline.TabIndex = 6
        Me.lblSingleBasePriceHeadline.Text = "einzel Einkaufspreis"
        '
        'Panel4
        '
        Me.Panel4.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.Appearance.Options.UseBorderColor = True
        Me.Panel4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.Panel4.Controls.Add(Me.txtSingleVKbrutto)
        Me.Panel4.Controls.Add(Me.txtSingleVK)
        Me.Panel4.Controls.Add(Me.lblWithoutTax1)
        Me.Panel4.Controls.Add(Me.lblSingleEndPrice)
        Me.Panel4.Controls.Add(Me.lblWithTax1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(581, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(167, 64)
        Me.Panel4.TabIndex = 16
        '
        'txtSingleVKbrutto
        '
        Me.txtSingleVKbrutto.AllowDrop = True
        Me.txtSingleVKbrutto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSingleVKbrutto.Location = New System.Drawing.Point(89, 40)
        Me.txtSingleVKbrutto.Name = "txtSingleVKbrutto"
        Me.txtSingleVKbrutto.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSingleVKbrutto.Properties.Appearance.Options.UseFont = True
        Me.txtSingleVKbrutto.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSingleVKbrutto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtSingleVKbrutto.Properties.DisplayFormat.FormatString = "c2"
        Me.txtSingleVKbrutto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSingleVKbrutto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSingleVKbrutto.Properties.Mask.EditMask = "c"
        Me.txtSingleVKbrutto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSingleVKbrutto.Size = New System.Drawing.Size(75, 22)
        ToolTipTitleItem14.Text = "Einzel Verkaufspreis (Brutto)"
        SuperToolTip14.Items.Add(ToolTipTitleItem14)
        Me.txtSingleVKbrutto.SuperTip = SuperToolTip14
        Me.txtSingleVKbrutto.TabIndex = 1
        '
        'txtSingleVK
        '
        Me.txtSingleVK.AllowDrop = True
        Me.txtSingleVK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSingleVK.Location = New System.Drawing.Point(2, 40)
        Me.txtSingleVK.Name = "txtSingleVK"
        Me.txtSingleVK.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSingleVK.Properties.Appearance.Options.UseFont = True
        Me.txtSingleVK.Properties.Appearance.Options.UseTextOptions = True
        Me.txtSingleVK.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtSingleVK.Properties.DisplayFormat.FormatString = "C"
        Me.txtSingleVK.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtSingleVK.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSingleVK.Properties.Mask.BeepOnError = True
        Me.txtSingleVK.Properties.Mask.EditMask = "c"
        Me.txtSingleVK.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSingleVK.Size = New System.Drawing.Size(75, 22)
        ToolTipTitleItem15.Text = "Einzel Verkaufspreis (netto)"
        SuperToolTip15.Items.Add(ToolTipTitleItem15)
        Me.txtSingleVK.SuperTip = SuperToolTip15
        Me.txtSingleVK.TabIndex = 0
        '
        'lblWithoutTax1
        '
        Me.lblWithoutTax1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWithoutTax1.Appearance.Options.UseFont = True
        Me.lblWithoutTax1.Location = New System.Drawing.Point(5, 24)
        Me.lblWithoutTax1.Name = "lblWithoutTax1"
        Me.lblWithoutTax1.Size = New System.Drawing.Size(30, 15)
        Me.lblWithoutTax1.TabIndex = 6
        Me.lblWithoutTax1.Text = "Netto"
        '
        'lblSingleEndPrice
        '
        Me.lblSingleEndPrice.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSingleEndPrice.Appearance.Options.UseFont = True
        Me.lblSingleEndPrice.Location = New System.Drawing.Point(18, 3)
        Me.lblSingleEndPrice.Name = "lblSingleEndPrice"
        Me.lblSingleEndPrice.Size = New System.Drawing.Size(103, 15)
        Me.lblSingleEndPrice.TabIndex = 6
        Me.lblSingleEndPrice.Text = "einzel Verkaufspreis"
        '
        'lblWithTax1
        '
        Me.lblWithTax1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWithTax1.Appearance.Options.UseFont = True
        Me.lblWithTax1.Location = New System.Drawing.Point(88, 24)
        Me.lblWithTax1.Name = "lblWithTax1"
        Me.lblWithTax1.Size = New System.Drawing.Size(33, 15)
        Me.lblWithTax1.TabIndex = 6
        Me.lblWithTax1.Text = "Brutto"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.MruBase)
        Me.Panel5.Controls.Add(Me.lblSingleUnit)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(748, 0)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(120, 64)
        Me.Panel5.TabIndex = 17
        '
        'MruBase
        '
        Me.MruBase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MruBase.EditValue = ""
        Me.MruBase.Location = New System.Drawing.Point(3, 40)
        Me.MruBase.Name = "MruBase"
        Me.MruBase.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MruBase.Properties.Appearance.Options.UseFont = True
        Me.MruBase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MruBase.Properties.MaxLength = 50
        Me.MruBase.Properties.PopupSizeable = True
        Me.MruBase.Properties.Sorted = True
        Me.MruBase.Size = New System.Drawing.Size(111, 22)
        Me.MruBase.TabIndex = 0
        '
        'lblSingleUnit
        '
        Me.lblSingleUnit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSingleUnit.Appearance.Options.UseFont = True
        Me.lblSingleUnit.Location = New System.Drawing.Point(3, 24)
        Me.lblSingleUnit.Name = "lblSingleUnit"
        Me.lblSingleUnit.Size = New System.Drawing.Size(36, 15)
        Me.lblSingleUnit.TabIndex = 6
        Me.lblSingleUnit.Text = "Einheit"
        '
        'ArticlesGrid
        '
        Me.ArticlesGrid.Appearance.BackColor = System.Drawing.Color.White
        Me.ArticlesGrid.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArticlesGrid.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ArticlesGrid.Appearance.Options.UseBackColor = True
        Me.ArticlesGrid.Appearance.Options.UseFont = True
        Me.ArticlesGrid.Appearance.Options.UseForeColor = True
        Me.ArticlesGrid.Context = "MainArticleGrid"
        Me.ArticlesGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ArticlesGrid.Location = New System.Drawing.Point(0, 36)
        Me.ArticlesGrid.Margin = New System.Windows.Forms.Padding(3, 12, 3, 3)
        Me.ArticlesGrid.Name = "ArticlesGrid"
        Me.ArticlesGrid.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.ArticlesGrid.SelectedArticelID = ""
        Me.ArticlesGrid.SelectedGroupID = ""
        Me.ArticlesGrid.ShowFilterRow = False
        Me.ArticlesGrid.Size = New System.Drawing.Size(868, 234)
        Me.ArticlesGrid.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnMaximizeworkspace)
        Me.PanelControl1.Controls.Add(Me.IucSearchPanel1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(868, 36)
        Me.PanelControl1.TabIndex = 2
        '
        'btnMaximizeworkspace
        '
        Me.btnMaximizeworkspace.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnMaximizeworkspace.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.btnMaximizeworkspace.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMaximizeworkspace.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.FitToHeight_16x16
        Me.btnMaximizeworkspace.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnMaximizeworkspace.Location = New System.Drawing.Point(829, 2)
        Me.btnMaximizeworkspace.LookAndFeel.SkinName = "Lilian"
        Me.btnMaximizeworkspace.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnMaximizeworkspace.Name = "btnMaximizeworkspace"
        Me.btnMaximizeworkspace.Size = New System.Drawing.Size(37, 32)
        Me.btnMaximizeworkspace.TabIndex = 3
        Me.btnMaximizeworkspace.ToolTip = "Arbeitsbereich maximieren"
        '
        'IucSearchPanel1
        '
        Me.IucSearchPanel1.AllowTextFieldTabStop = True
        Me.IucSearchPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.IucSearchPanel1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.IucSearchPanel1.Appearance.Options.UseBackColor = True
        Me.IucSearchPanel1.Appearance.Options.UseForeColor = True
        Me.IucSearchPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.IucSearchPanel1.Location = New System.Drawing.Point(5, 8)
        Me.IucSearchPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.IucSearchPanel1.Name = "IucSearchPanel1"
        Me.IucSearchPanel1.NullValuePrompt = "Suche...    F3"
        Me.IucSearchPanel1.SelectedMenueItem = -1
        Me.IucSearchPanel1.Size = New System.Drawing.Size(259, 23)
        Me.IucSearchPanel1.Status = ClausSoftware.HWLInterops.iucSearchPanel.enumState.empty
        Me.IucSearchPanel1.TabIndex = 1
        '
        'iucArticles
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "iucArticles"
        Me.Size = New System.Drawing.Size(868, 585)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.mainTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainTable.ResumeLayout(False)
        Me.tabInformation.ResumeLayout(False)
        Me.PnlInfo.ResumeLayout(False)
        CType(Me.splInfoBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splInfoBox.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.txtLongText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        CType(Me.txtManufactorsArticleNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.txtInternalArticleNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtArticleName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreatedAt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCalculation.ResumeLayout(False)
        Me.tabCalculation.PerformLayout()
        CType(Me.chkDiscountEnable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRessources.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.tabPaneleinkauf.ResumeLayout(False)
        Me.tabPaneleinkauf.PerformLayout()
        Me.pnlEinkauf.ResumeLayout(False)
        Me.pnlEinkauf.PerformLayout()
        CType(Me.txtSingleEKMulti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsingleEK1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPanelDiscounts.ResumeLayout(False)
        Me.tabPanelDiscounts.PerformLayout()
        CType(Me.txtRabattPreisMulti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.cboRabatt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtRabattpreis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPanelResources.ResumeLayout(False)
        Me.tabPanelResources.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        CType(Me.txtRohstoffPreisMulti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRohstoffpreis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPanelGwinn.ResumeLayout(False)
        Me.tabPanelGwinn.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        CType(Me.cboAddValueStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAufschlagAbsolut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAufschlagMulti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAufschlag.ResumeLayout(False)
        Me.pnlAufschlag.PerformLayout()
        Me.TabPanelendPrice.ResumeLayout(False)
        Me.TabPanelendPrice.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.txtVerkaufspreis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVerkaufspreisMulti.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItemCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MruPack.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MruBase1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabmiscellaneous.ResumeLayout(False)
        Me.tabmiscellaneous.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        CType(Me.txtMemo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        CType(Me.trvHirachy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPictures.ResumeLayout(False)
        CType(Me.grdImages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsImages.ResumeLayout(False)
        CType(Me.lvImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutViewField_LayoutViewColumn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabStorage.ResumeLayout(False)
        Me.tabStorage.PerformLayout()
        CType(Me.txteanCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbLastSelling.ResumeLayout(False)
        Me.tlbLastSelling.PerformLayout()
        Me.tlpLagerbestand.ResumeLayout(False)
        Me.tlpLagerbestand.PerformLayout()
        Me.tabComponents.ResumeLayout(False)
        Me.tabComponents.PerformLayout()
        CType(Me.trvsubArticles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsBomItems.ResumeLayout(False)
        Me.tabWorkItems.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.txtWorkItemcosts.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboWorkAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.txtWorkTimeSpan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsWorkItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAttributes.ResumeLayout(False)
        CType(Me.grdAttributes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvAttributes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAttrbutesCheckedit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAttributesDateEdit.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAttributesDateEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repAttributesEnumValues, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeadline.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.txtSingleEKBrutto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSingleEK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.txtSingleVKbrutto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSingleVK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.MruBase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ArticlesGrid As HWLInterops.iucGroupsGrid
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents txtSingleEKMulti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtsingleEK1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSingleVK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSingleEK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblSingleEndPrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSingleBasePriceHeadline As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSingleUnit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents mainTable As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabInformation As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabCalculation As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents MruPack As DevExpress.XtraEditors.MRUEdit
    Friend WithEvents MruBase1 As DevExpress.XtraEditors.MRUEdit
    Friend WithEvents txtItemCount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblVPUnit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents IucSearchPanel1 As HWLInterops.iucSearchPanel
    Friend WithEvents lblBaseUnit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tabmiscellaneous As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblArticleShortDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tabPictures As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grdImages As DevExpress.XtraGrid.GridControl
    Friend WithEvents lblDistributorName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAdressSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblDistributor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtLongText As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtVerkaufspreis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFactorVerkauf As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRohstoffPreisMulti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblTotalsalesPrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAufschlagAbsolut As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFactorGewinn As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAufschlagMulti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblGewinnzuschlag As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRohstoffpreis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFactorResources As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtVerkaufspreisMulti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCommondityPrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRabattpreis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFactorDiscount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRabattPreisMulti As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MruBase As DevExpress.XtraEditors.MRUEdit
    Friend WithEvents pnlHeadline As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Panel4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents tabPanelResources As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tabPanelDiscounts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tabPanelGwinn As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabPanelendPrice As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cboRabatt As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents pnlAufschlag As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents cboAddValueStyle As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cmsImages As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNewImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvImages As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colImage As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents chkDiscountEnable As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkRessources As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutViewColumn1 As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents colResulution As DevExpress.XtraGrid.Columns.LayoutViewColumn
    Friend WithEvents chkFixedendPrice As DevExpress.XtraEditors.CheckButton
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents lblCreatedAt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtArticleName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents mnuDeleteImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PnlInfo As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblArticleTag As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCreatedAt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents tabStorage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblSummSellings As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTextSumsellings As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMainUnit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSumOfSoldItems As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tlpLagerbestand As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents chkIsActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblSoldAt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tlbLastSelling As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblLastSoldDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents mnuInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents lblSingleBasePrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTaxRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboTax As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtSingleEKBrutto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSingleVKbrutto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txteanCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblEANCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMoreNotesAboutArticle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMemo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents tabComponents As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents trvsubArticles As DevExpress.XtraTreeList.TreeList
    Friend WithEvents cmsBomItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAddArticles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCopyArticles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPasteArticles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteBomItems As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditPictures As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents layoutViewField_LayoutViewColumn2 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn3 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn4 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents layoutViewField_LayoutViewColumn1 As DevExpress.XtraGrid.Views.Layout.LayoutViewField
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents txtInternalArticleNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblInternalArticleNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tabPaneleinkauf As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlEinkauf As System.Windows.Forms.Panel
    Friend WithEvents tabWorkItems As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents lblPayGroup As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblWorkItemCosts As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWorkItemcosts As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblShortTimeFormat As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDuration As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboWorkAccount As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents chkIsWorkItem As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lblDiscount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tabAttributes As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grdAttributes As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvAttributes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents repAttrbutesCheckedit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents repAttributesDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents splInfoBox As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblBomSumEndPrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbltxtCalculatedEndPrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblBomSumBasePrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbltxtBasePrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblBomCalculatedTime As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbltxtCalculatedTime As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtWorkTimeSpan As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents btnOpenBomItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTransferSubPrices As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtManufactorsArticleNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblManufactorsArticleNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents trvHirachy As DevExpress.XtraTreeList.TreeList
    Friend WithEvents btnSetPredecessor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPredecessorItems As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents btnEditArticleAttributes As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblWithTax As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblWithoutTax As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblWithoutTax1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblWithTax1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents lblSelectOldAndRedeemedArticles As DevExpress.XtraEditors.LabelControl
    Friend WithEvents repAttributesEnumValues As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents btnMaximizeworkspace As DevExpress.XtraEditors.SimpleButton

End Class
