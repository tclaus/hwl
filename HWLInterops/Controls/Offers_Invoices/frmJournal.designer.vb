

Partial Public Class frmJournal
    Inherits ClausSoftware.HWLInterops.BaseForm




    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJournal))
        Me.grvAttachments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdJournalList = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuLstView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOpenDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCreateNewDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDuplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeletedocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUndeleteDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCreateSummarizedInvoice = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddAttachment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrintDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAttachmentSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteAttachmentItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTagged = New System.Windows.Forms.ToolStripMenuItem()
        Me.grvDocuments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFirstCol = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTagged = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDisplayID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHasAttachment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colChecked = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDocumentType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAdresswindow = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDocumentNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDocumentSum = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotalDuration = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIsCanceled = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHasInvoiceReference = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.repTaggedIcon = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.CardView1 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.nvbDocuments = New DevExpress.XtraNavBar.NavBarControl()
        Me.nbgGroupCommonDocs = New DevExpress.XtraNavBar.NavBarGroup()
        Me.nbiDocumentsAlle = New DevExpress.XtraNavBar.NavBarItem()
        Me.nbiDocumentsAngebote = New DevExpress.XtraNavBar.NavBarItem()
        Me.nbiDocumentsAufträge = New DevExpress.XtraNavBar.NavBarItem()
        Me.nbiDocumentsRechnungen = New DevExpress.XtraNavBar.NavBarItem()
        Me.nbiDocumentsGutschriften = New DevExpress.XtraNavBar.NavBarItem()
        Me.nbiDocumentsMahnungen = New DevExpress.XtraNavBar.NavBarItem()
        Me.cmsNavBar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnRenameNavBarItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOpen = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.lblJournalHeadline = New System.Windows.Forms.Label()
        Me.lblJournalTotalSum = New System.Windows.Forms.Label()
        Me.lblCurrentFile = New DevExpress.XtraEditors.LabelControl()
        Me.lcSaveAttachment = New ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.SearchPanel = New ClausSoftware.HWLInterops.iucSearchPanel()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.lblJournalViewFilter = New DevExpress.XtraEditors.LabelControl()
        Me.cboJournalFilterView = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblJournalSelectedTotalSumValue = New System.Windows.Forms.Label()
        Me.lblJournalTotalSumValue = New System.Windows.Forms.Label()
        Me.lblJournalSelectedTotalSum = New System.Windows.Forms.Label()
        Me.spcGridContainer = New DevExpress.XtraEditors.SplitContainerControl()
        Me.txtJournalMemo = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.grvAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdJournalList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuLstView.SuspendLayout()
        CType(Me.grvDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repTaggedIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nvbDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsNavBar.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.cboJournalFilterView.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spcGridContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcGridContainer.SuspendLayout()
        CType(Me.txtJournalMemo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grvAttachments
        '
        Me.grvAttachments.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.grvAttachments.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.grvAttachments.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.grvAttachments.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.grvAttachments.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.grvAttachments.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grvAttachments.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.grvAttachments.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grvAttachments.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.grvAttachments.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.grvAttachments.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.grvAttachments.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.grvAttachments.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.grvAttachments.Appearance.Empty.Options.UseBackColor = True
        Me.grvAttachments.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.EvenRow.Options.UseBackColor = True
        Me.grvAttachments.Appearance.EvenRow.Options.UseForeColor = True
        Me.grvAttachments.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.grvAttachments.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.grvAttachments.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.grvAttachments.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.grvAttachments.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.grvAttachments.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.grvAttachments.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White
        Me.grvAttachments.Appearance.FilterPanel.Options.UseBackColor = True
        Me.grvAttachments.Appearance.FilterPanel.Options.UseForeColor = True
        Me.grvAttachments.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.grvAttachments.Appearance.FixedLine.Options.UseBackColor = True
        Me.grvAttachments.Appearance.FocusedCell.BackColor = System.Drawing.Color.White
        Me.grvAttachments.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.FocusedCell.Options.UseBackColor = True
        Me.grvAttachments.Appearance.FocusedCell.Options.UseForeColor = True
        Me.grvAttachments.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.grvAttachments.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.grvAttachments.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grvAttachments.Appearance.FocusedRow.Options.UseForeColor = True
        Me.grvAttachments.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.grvAttachments.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.grvAttachments.Appearance.FooterPanel.Options.UseBackColor = True
        Me.grvAttachments.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.grvAttachments.Appearance.FooterPanel.Options.UseForeColor = True
        Me.grvAttachments.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grvAttachments.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grvAttachments.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.GroupButton.Options.UseBackColor = True
        Me.grvAttachments.Appearance.GroupButton.Options.UseBorderColor = True
        Me.grvAttachments.Appearance.GroupButton.Options.UseForeColor = True
        Me.grvAttachments.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grvAttachments.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grvAttachments.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.GroupFooter.Options.UseBackColor = True
        Me.grvAttachments.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.grvAttachments.Appearance.GroupFooter.Options.UseForeColor = True
        Me.grvAttachments.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.grvAttachments.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.GroupPanel.Options.UseBackColor = True
        Me.grvAttachments.Appearance.GroupPanel.Options.UseForeColor = True
        Me.grvAttachments.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grvAttachments.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.grvAttachments.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grvAttachments.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.GroupRow.Options.UseBackColor = True
        Me.grvAttachments.Appearance.GroupRow.Options.UseBorderColor = True
        Me.grvAttachments.Appearance.GroupRow.Options.UseFont = True
        Me.grvAttachments.Appearance.GroupRow.Options.UseForeColor = True
        Me.grvAttachments.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.grvAttachments.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.grvAttachments.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.grvAttachments.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.grvAttachments.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.grvAttachments.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.grvAttachments.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.grvAttachments.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.grvAttachments.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.grvAttachments.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.grvAttachments.Appearance.HorzLine.Options.UseBackColor = True
        Me.grvAttachments.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.grvAttachments.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.OddRow.Options.UseBackColor = True
        Me.grvAttachments.Appearance.OddRow.Options.UseForeColor = True
        Me.grvAttachments.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grvAttachments.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.grvAttachments.Appearance.Preview.Options.UseBackColor = True
        Me.grvAttachments.Appearance.Preview.Options.UseForeColor = True
        Me.grvAttachments.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.grvAttachments.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.grvAttachments.Appearance.Row.Options.UseBackColor = True
        Me.grvAttachments.Appearance.Row.Options.UseForeColor = True
        Me.grvAttachments.Appearance.RowSeparator.BackColor = System.Drawing.Color.White
        Me.grvAttachments.Appearance.RowSeparator.Options.UseBackColor = True
        Me.grvAttachments.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.grvAttachments.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grvAttachments.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grvAttachments.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grvAttachments.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.grvAttachments.Appearance.VertLine.Options.UseBackColor = True
        Me.grvAttachments.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grvAttachments.GridControl = Me.grdJournalList
        Me.grvAttachments.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.grvAttachments.Name = "grvAttachments"
        Me.grvAttachments.OptionsBehavior.Editable = False
        Me.grvAttachments.OptionsCustomization.AllowRowSizing = True
        Me.grvAttachments.OptionsDetail.EnableMasterViewMode = False
        Me.grvAttachments.OptionsDetail.ShowDetailTabs = False
        Me.grvAttachments.OptionsFilter.AllowColumnMRUFilterList = False
        Me.grvAttachments.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.grvAttachments.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvAttachments.OptionsSelection.MultiSelect = True
        Me.grvAttachments.OptionsView.ColumnAutoWidth = False
        Me.grvAttachments.OptionsView.EnableAppearanceEvenRow = True
        Me.grvAttachments.OptionsView.ShowGroupPanel = False
        '
        'grdJournalList
        '
        Me.grdJournalList.AllowDrop = True
        Me.grdJournalList.ContextMenuStrip = Me.ContextMenuLstView
        Me.grdJournalList.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.grvAttachments
        GridLevelNode1.RelationName = "Attachments"
        Me.grdJournalList.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdJournalList.Location = New System.Drawing.Point(0, 0)
        Me.grdJournalList.MainView = Me.grvDocuments
        Me.grdJournalList.Name = "grdJournalList"
        Me.grdJournalList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemPictureEdit, Me.RepositoryItemTextEdit1, Me.repTaggedIcon})
        Me.grdJournalList.Size = New System.Drawing.Size(546, 172)
        Me.grdJournalList.TabIndex = 0
        Me.grdJournalList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvDocuments, Me.CardView1, Me.grvAttachments})
        '
        'ContextMenuLstView
        '
        Me.ContextMenuLstView.AllowDrop = True
        Me.ContextMenuLstView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenDocument, Me.mnuCreateNewDocument, Me.mnuDuplicate, Me.ToolStripMenuItem1, Me.mnuDeletedocument, Me.mnuUndeleteDocument, Me.btnCreateSummarizedInvoice, Me.mnuAddAttachment, Me.mnuPrintDocument, Me.mnuAttachmentSaveAs, Me.mnuDeleteAttachmentItem, Me.mnuTagged})
        Me.ContextMenuLstView.Name = "ContextMenuLstView"
        Me.ContextMenuLstView.Size = New System.Drawing.Size(219, 252)
        '
        'mnuOpenDocument
        '
        Me.mnuOpenDocument.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuOpenDocument.Image = CType(resources.GetObject("mnuOpenDocument.Image"), System.Drawing.Image)
        Me.mnuOpenDocument.Name = "mnuOpenDocument"
        Me.mnuOpenDocument.Size = New System.Drawing.Size(218, 22)
        Me.mnuOpenDocument.Text = "Öffnen"
        '
        'mnuCreateNewDocument
        '
        Me.mnuCreateNewDocument.Image = CType(resources.GetObject("mnuCreateNewDocument.Image"), System.Drawing.Image)
        Me.mnuCreateNewDocument.Name = "mnuCreateNewDocument"
        Me.mnuCreateNewDocument.Size = New System.Drawing.Size(218, 22)
        Me.mnuCreateNewDocument.Text = "Neues Dokument anlegen"
        '
        'mnuDuplicate
        '
        Me.mnuDuplicate.Image = CType(resources.GetObject("mnuDuplicate.Image"), System.Drawing.Image)
        Me.mnuDuplicate.Name = "mnuDuplicate"
        Me.mnuDuplicate.Size = New System.Drawing.Size(218, 22)
        Me.mnuDuplicate.Text = "Duplizieren"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(215, 6)
        '
        'mnuDeletedocument
        '
        Me.mnuDeletedocument.Image = CType(resources.GetObject("mnuDeletedocument.Image"), System.Drawing.Image)
        Me.mnuDeletedocument.Name = "mnuDeletedocument"
        Me.mnuDeletedocument.Size = New System.Drawing.Size(218, 22)
        Me.mnuDeletedocument.Text = "Dokument stornieren"
        '
        'mnuUndeleteDocument
        '
        Me.mnuUndeleteDocument.Image = CType(resources.GetObject("mnuUndeleteDocument.Image"), System.Drawing.Image)
        Me.mnuUndeleteDocument.Name = "mnuUndeleteDocument"
        Me.mnuUndeleteDocument.Size = New System.Drawing.Size(218, 22)
        Me.mnuUndeleteDocument.Text = "Storno rückgängig machen"
        '
        'btnCreateSummarizedInvoice
        '
        Me.btnCreateSummarizedInvoice.Name = "btnCreateSummarizedInvoice"
        Me.btnCreateSummarizedInvoice.Size = New System.Drawing.Size(218, 22)
        Me.btnCreateSummarizedInvoice.Text = "Sammelrechnung erstellen"
        '
        'mnuAddAttachment
        '
        Me.mnuAddAttachment.Name = "mnuAddAttachment"
        Me.mnuAddAttachment.Size = New System.Drawing.Size(218, 22)
        Me.mnuAddAttachment.Text = "Anhang hinzufügen"
        '
        'mnuPrintDocument
        '
        Me.mnuPrintDocument.Image = CType(resources.GetObject("mnuPrintDocument.Image"), System.Drawing.Image)
        Me.mnuPrintDocument.Name = "mnuPrintDocument"
        Me.mnuPrintDocument.Size = New System.Drawing.Size(218, 22)
        Me.mnuPrintDocument.Text = "Dokument Drucken"
        '
        'mnuAttachmentSaveAs
        '
        Me.mnuAttachmentSaveAs.Image = CType(resources.GetObject("mnuAttachmentSaveAs.Image"), System.Drawing.Image)
        Me.mnuAttachmentSaveAs.Name = "mnuAttachmentSaveAs"
        Me.mnuAttachmentSaveAs.Size = New System.Drawing.Size(218, 22)
        Me.mnuAttachmentSaveAs.Text = "Speichern unter..."
        '
        'mnuDeleteAttachmentItem
        '
        Me.mnuDeleteAttachmentItem.Image = CType(resources.GetObject("mnuDeleteAttachmentItem.Image"), System.Drawing.Image)
        Me.mnuDeleteAttachmentItem.Name = "mnuDeleteAttachmentItem"
        Me.mnuDeleteAttachmentItem.Size = New System.Drawing.Size(218, 22)
        Me.mnuDeleteAttachmentItem.Text = "Löschen"
        '
        'mnuTagged
        '
        Me.mnuTagged.CheckOnClick = True
        Me.mnuTagged.Name = "mnuTagged"
        Me.mnuTagged.Size = New System.Drawing.Size(218, 22)
        Me.mnuTagged.Text = "Markierung"
        '
        'grvDocuments
        '
        Me.grvDocuments.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFirstCol, Me.colTagged, Me.colDisplayID, Me.colDate, Me.colHasAttachment, Me.colChecked, Me.colDocumentType, Me.colAdresswindow, Me.colDocumentNote, Me.colDocumentSum, Me.colTotalDuration, Me.colIsCanceled, Me.colHasInvoiceReference})
        Me.grvDocuments.FixedLineWidth = 1
        Me.grvDocuments.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grvDocuments.GridControl = Me.grdJournalList
        Me.grvDocuments.Name = "grvDocuments"
        Me.grvDocuments.OptionsBehavior.Editable = False
        Me.grvDocuments.OptionsDetail.ShowDetailTabs = False
        Me.grvDocuments.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails
        Me.grvDocuments.OptionsFilter.AllowMRUFilterList = False
        Me.grvDocuments.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvDocuments.OptionsSelection.MultiSelect = True
        Me.grvDocuments.OptionsView.ShowAutoFilterRow = True
        Me.grvDocuments.OptionsView.ShowGroupPanel = False
        Me.grvDocuments.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDisplayID, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colFirstCol
        '
        Me.colFirstCol.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.colFirstCol.MaxWidth = 13
        Me.colFirstCol.MinWidth = 13
        Me.colFirstCol.Name = "colFirstCol"
        Me.colFirstCol.OptionsColumn.AllowEdit = False
        Me.colFirstCol.OptionsColumn.ShowCaption = False
        Me.colFirstCol.OptionsFilter.AllowAutoFilter = False
        Me.colFirstCol.OptionsFilter.AllowFilter = False
        Me.colFirstCol.Visible = True
        Me.colFirstCol.VisibleIndex = 0
        Me.colFirstCol.Width = 13
        '
        'colTagged
        '
        Me.colTagged.AppearanceHeader.Options.UseImage = True
        Me.colTagged.Caption = "Markiert"
        Me.colTagged.FieldName = "Tagged"
        Me.colTagged.MaxWidth = 16
        Me.colTagged.MinWidth = 16
        Me.colTagged.Name = "colTagged"
        Me.colTagged.OptionsColumn.AllowSize = False
        Me.colTagged.OptionsColumn.ShowCaption = False
        Me.colTagged.Visible = True
        Me.colTagged.VisibleIndex = 1
        Me.colTagged.Width = 16
        '
        'colDisplayID
        '
        Me.colDisplayID.AppearanceCell.Options.UseTextOptions = True
        Me.colDisplayID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.colDisplayID.Caption = "Nummer"
        Me.colDisplayID.FieldName = "DocumentDisplayID"
        Me.colDisplayID.Name = "colDisplayID"
        Me.colDisplayID.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
        Me.colDisplayID.Visible = True
        Me.colDisplayID.VisibleIndex = 2
        Me.colDisplayID.Width = 77
        '
        'colDate
        '
        Me.colDate.Caption = "Datum"
        Me.colDate.FieldName = "DocumentDate"
        Me.colDate.Name = "colDate"
        Me.colDate.Visible = True
        Me.colDate.VisibleIndex = 3
        Me.colDate.Width = 77
        '
        'colHasAttachment
        '
        Me.colHasAttachment.Caption = "Dateien vorhanden"
        Me.colHasAttachment.FieldName = "HasAttachment"
        Me.colHasAttachment.Name = "colHasAttachment"
        Me.colHasAttachment.Width = 106
        '
        'colChecked
        '
        Me.colChecked.Caption = "Erledigt"
        Me.colChecked.FieldName = "Checked"
        Me.colChecked.MaxWidth = 60
        Me.colChecked.Name = "colChecked"
        Me.colChecked.Visible = True
        Me.colChecked.VisibleIndex = 4
        Me.colChecked.Width = 44
        '
        'colDocumentType
        '
        Me.colDocumentType.Caption = "Typ"
        Me.colDocumentType.FieldName = "DocumentTypeText"
        Me.colDocumentType.Name = "colDocumentType"
        Me.colDocumentType.Visible = True
        Me.colDocumentType.VisibleIndex = 5
        Me.colDocumentType.Width = 83
        '
        'colAdresswindow
        '
        Me.colAdresswindow.Caption = "Adressfenster"
        Me.colAdresswindow.FieldName = "AddressWindow"
        Me.colAdresswindow.Name = "colAdresswindow"
        Me.colAdresswindow.Visible = True
        Me.colAdresswindow.VisibleIndex = 6
        Me.colAdresswindow.Width = 83
        '
        'colDocumentNote
        '
        Me.colDocumentNote.Caption = "Bemerkung"
        Me.colDocumentNote.FieldName = "Subject"
        Me.colDocumentNote.Name = "colDocumentNote"
        Me.colDocumentNote.Width = 114
        '
        'colDocumentSum
        '
        Me.colDocumentSum.Caption = "Summe"
        Me.colDocumentSum.DisplayFormat.FormatString = "c"
        Me.colDocumentSum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDocumentSum.FieldName = "DisplayedEndPrice"
        Me.colDocumentSum.Name = "colDocumentSum"
        Me.colDocumentSum.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.colDocumentSum.Visible = True
        Me.colDocumentSum.VisibleIndex = 7
        Me.colDocumentSum.Width = 126
        '
        'colTotalDuration
        '
        Me.colTotalDuration.Caption = "Zeitdauer"
        Me.colTotalDuration.FieldName = "TotalDuration"
        Me.colTotalDuration.Name = "colTotalDuration"
        Me.colTotalDuration.OptionsColumn.AllowEdit = False
        '
        'colIsCanceled
        '
        Me.colIsCanceled.Caption = "Storno"
        Me.colIsCanceled.FieldName = "IsCanceled"
        Me.colIsCanceled.Name = "colIsCanceled"
        Me.colIsCanceled.OptionsColumn.AllowEdit = False
        '
        'colHasInvoiceReference
        '
        Me.colHasInvoiceReference.Caption = "Sammelrechnung"
        Me.colHasInvoiceReference.FieldName = "HasInvoiceReference"
        Me.colHasInvoiceReference.Name = "colHasInvoiceReference"
        Me.colHasInvoiceReference.OptionsColumn.AllowEdit = False
        Me.colHasInvoiceReference.Visible = True
        Me.colHasInvoiceReference.VisibleIndex = 8
        '
        'RepositoryItemPictureEdit
        '
        Me.RepositoryItemPictureEdit.Name = "RepositoryItemPictureEdit"
        Me.RepositoryItemPictureEdit.ReadOnly = True
        Me.RepositoryItemPictureEdit.ShowMenu = False
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'repTaggedIcon
        '
        Me.repTaggedIcon.Name = "repTaggedIcon"
        '
        'CardView1
        '
        Me.CardView1.FocusedCardTopFieldIndex = 0
        Me.CardView1.GridControl = Me.grdJournalList
        Me.CardView1.Name = "CardView1"
        '
        'ToolTip
        '
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip.ToolTipTitle = "information:"
        '
        'nvbDocuments
        '
        Me.nvbDocuments.ActiveGroup = Me.nbgGroupCommonDocs
        Me.nvbDocuments.AllowSelectedLink = True
        Me.nvbDocuments.ContentButtonHint = Nothing
        Me.nvbDocuments.ContextMenuStrip = Me.cmsNavBar
        Me.nvbDocuments.Dock = System.Windows.Forms.DockStyle.Left
        Me.nvbDocuments.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.nbgGroupCommonDocs})
        Me.nvbDocuments.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.nbiDocumentsAlle, Me.nbiDocumentsRechnungen, Me.nbiDocumentsAngebote, Me.nbiDocumentsMahnungen, Me.nbiDocumentsGutschriften, Me.nbiDocumentsAufträge})
        Me.nvbDocuments.Location = New System.Drawing.Point(0, 0)
        Me.nvbDocuments.LookAndFeel.UseWindowsXPTheme = True
        Me.nvbDocuments.Name = "nvbDocuments"
        Me.nvbDocuments.OptionsNavPane.ExpandedWidth = 133
        Me.nvbDocuments.OptionsNavPane.ShowExpandButton = False
        Me.nvbDocuments.OptionsNavPane.ShowOverflowPanel = False
        Me.nvbDocuments.Size = New System.Drawing.Size(133, 308)
        Me.nvbDocuments.TabIndex = 0
        Me.nvbDocuments.Text = "NavBarControl1"
        Me.nvbDocuments.View = New DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Blue")
        '
        'nbgGroupCommonDocs
        '
        Me.nbgGroupCommonDocs.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbgGroupCommonDocs.Appearance.Options.UseFont = True
        Me.nbgGroupCommonDocs.Caption = "Allgemein"
        Me.nbgGroupCommonDocs.Expanded = True
        Me.nbgGroupCommonDocs.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.nbiDocumentsAlle), New DevExpress.XtraNavBar.NavBarItemLink(Me.nbiDocumentsAngebote), New DevExpress.XtraNavBar.NavBarItemLink(Me.nbiDocumentsAufträge), New DevExpress.XtraNavBar.NavBarItemLink(Me.nbiDocumentsRechnungen), New DevExpress.XtraNavBar.NavBarItemLink(Me.nbiDocumentsGutschriften), New DevExpress.XtraNavBar.NavBarItemLink(Me.nbiDocumentsMahnungen)})
        Me.nbgGroupCommonDocs.Name = "nbgGroupCommonDocs"
        Me.nbgGroupCommonDocs.NavigationPaneVisible = False
        Me.nbgGroupCommonDocs.SelectedLinkIndex = 0
        '
        'nbiDocumentsAlle
        '
        Me.nbiDocumentsAlle.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbiDocumentsAlle.Appearance.Options.UseFont = True
        Me.nbiDocumentsAlle.Caption = "ALLE"
        Me.nbiDocumentsAlle.Hint = "Zeigt alle Dokumente an"
        Me.nbiDocumentsAlle.Name = "nbiDocumentsAlle"
        Me.nbiDocumentsAlle.Tag = -1
        '
        'nbiDocumentsAngebote
        '
        Me.nbiDocumentsAngebote.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbiDocumentsAngebote.Appearance.Options.UseFont = True
        Me.nbiDocumentsAngebote.Caption = "Angebote"
        Me.nbiDocumentsAngebote.Hint = "Zeigt alle Angebote an"
        Me.nbiDocumentsAngebote.Name = "nbiDocumentsAngebote"
        Me.nbiDocumentsAngebote.Tag = 0
        '
        'nbiDocumentsAufträge
        '
        Me.nbiDocumentsAufträge.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbiDocumentsAufträge.Appearance.Options.UseFont = True
        Me.nbiDocumentsAufträge.Caption = "Aufträge"
        Me.nbiDocumentsAufträge.Hint = "Zeigt alle Aufträge an"
        Me.nbiDocumentsAufträge.Name = "nbiDocumentsAufträge"
        Me.nbiDocumentsAufträge.Tag = 1
        '
        'nbiDocumentsRechnungen
        '
        Me.nbiDocumentsRechnungen.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbiDocumentsRechnungen.Appearance.Options.UseFont = True
        Me.nbiDocumentsRechnungen.Caption = "Rechnungen"
        Me.nbiDocumentsRechnungen.Hint = "Zeigt alle Rechnungen an"
        Me.nbiDocumentsRechnungen.Name = "nbiDocumentsRechnungen"
        Me.nbiDocumentsRechnungen.Tag = 2
        '
        'nbiDocumentsGutschriften
        '
        Me.nbiDocumentsGutschriften.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbiDocumentsGutschriften.Appearance.Options.UseFont = True
        Me.nbiDocumentsGutschriften.Caption = "Gutschriften"
        Me.nbiDocumentsGutschriften.Hint = "Zeigt alle Gutschriften an"
        Me.nbiDocumentsGutschriften.Name = "nbiDocumentsGutschriften"
        Me.nbiDocumentsGutschriften.Tag = 4
        '
        'nbiDocumentsMahnungen
        '
        Me.nbiDocumentsMahnungen.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbiDocumentsMahnungen.Appearance.Options.UseFont = True
        Me.nbiDocumentsMahnungen.Caption = "Mahnungen"
        Me.nbiDocumentsMahnungen.Hint = "Zeigt alle Mahnungen an"
        Me.nbiDocumentsMahnungen.Name = "nbiDocumentsMahnungen"
        Me.nbiDocumentsMahnungen.Tag = 3
        '
        'cmsNavBar
        '
        Me.cmsNavBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRenameNavBarItem})
        Me.cmsNavBar.Name = "cmsNavBar"
        Me.cmsNavBar.Size = New System.Drawing.Size(153, 48)
        '
        'btnRenameNavBarItem
        '
        Me.btnRenameNavBarItem.Name = "btnRenameNavBarItem"
        Me.btnRenameNavBarItem.Size = New System.Drawing.Size(152, 22)
        Me.btnRenameNavBarItem.Text = "Umbenennen"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(604, 273)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Schliessen"
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.Appearance.Options.UseFont = True
        Me.btnOpen.Location = New System.Drawing.Point(518, 273)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "Öffnen"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Appearance.Options.UseFont = True
        Me.btnPrint.Location = New System.Drawing.Point(437, 273)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Drucken..."
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(356, 273)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Löschen"
        '
        'lblJournalHeadline
        '
        Me.lblJournalHeadline.AutoSize = True
        Me.lblJournalHeadline.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJournalHeadline.Location = New System.Drawing.Point(7, 7)
        Me.lblJournalHeadline.Name = "lblJournalHeadline"
        Me.lblJournalHeadline.Size = New System.Drawing.Size(45, 15)
        Me.lblJournalHeadline.TabIndex = 81
        Me.lblJournalHeadline.Text = "Journal"
        '
        'lblJournalTotalSum
        '
        Me.lblJournalTotalSum.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJournalTotalSum.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblJournalTotalSum.Location = New System.Drawing.Point(9, 24)
        Me.lblJournalTotalSum.Name = "lblJournalTotalSum"
        Me.lblJournalTotalSum.Size = New System.Drawing.Size(98, 16)
        Me.lblJournalTotalSum.TabIndex = 82
        Me.lblJournalTotalSum.Tag = "DontTranslate"
        Me.lblJournalTotalSum.Text = "Summe:"
        '
        'lblCurrentFile
        '
        Me.lblCurrentFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentFile.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentFile.Appearance.Options.UseFont = True
        Me.lblCurrentFile.Location = New System.Drawing.Point(192, 283)
        Me.lblCurrentFile.Name = "lblCurrentFile"
        Me.lblCurrentFile.Size = New System.Drawing.Size(77, 15)
        Me.lblCurrentFile.TabIndex = 83
        Me.lblCurrentFile.Text = "<Current File>"
        '
        'lcSaveAttachment
        '
        Me.lcSaveAttachment.Active = False
        Me.lcSaveAttachment.Color = System.Drawing.Color.CornflowerBlue
        Me.lcSaveAttachment.InnerCircleRadius = 8
        Me.lcSaveAttachment.Location = New System.Drawing.Point(142, 395)
        Me.lcSaveAttachment.Name = "lcSaveAttachment"
        Me.lcSaveAttachment.NumberSpoke = 10
        Me.lcSaveAttachment.OuterCircleRadius = 10
        Me.lcSaveAttachment.RotationSpeed = 100
        Me.lcSaveAttachment.Size = New System.Drawing.Size(37, 29)
        Me.lcSaveAttachment.SpokeThickness = 4
        Me.lcSaveAttachment.StylePreset = ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX
        Me.lcSaveAttachment.TabIndex = 84
        Me.lcSaveAttachment.Visible = False
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(0, 0)
        '
        'SearchPanel
        '
        Me.SearchPanel.AllowTextFieldTabStop = True
        Me.SearchPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchPanel.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.SearchPanel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchPanel.Appearance.Options.UseBackColor = True
        Me.SearchPanel.Appearance.Options.UseFont = True
        Me.SearchPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SearchPanel.Location = New System.Drawing.Point(2, 0)
        Me.SearchPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.SearchPanel.Name = "SearchPanel"
        Me.SearchPanel.NullValuePrompt = "Suche...    F3"
        Me.SearchPanel.SelectedMenueItem = -1
        Me.SearchPanel.Size = New System.Drawing.Size(169, 25)
        Me.SearchPanel.Status = ClausSoftware.HWLInterops.iucSearchPanel.enumState.empty
        Me.SearchPanel.TabIndex = 0
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.SplitContainerControl1.Location = New System.Drawing.Point(133, 0)
        Me.SplitContainerControl1.LookAndFeel.SkinName = "The Asphalt World"
        Me.SplitContainerControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.SplitContainerControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblJournalHeadline)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblJournalViewFilter)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.cboJournalFilterView)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblJournalSelectedTotalSumValue)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblJournalTotalSumValue)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblJournalSelectedTotalSum)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblJournalTotalSum)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SearchPanel)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(558, 58)
        Me.SplitContainerControl1.SplitterPosition = 179
        Me.SplitContainerControl1.TabIndex = 90
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'lblJournalViewFilter
        '
        Me.lblJournalViewFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblJournalViewFilter.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJournalViewFilter.Appearance.Options.UseFont = True
        Me.lblJournalViewFilter.Appearance.Options.UseTextOptions = True
        Me.lblJournalViewFilter.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblJournalViewFilter.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblJournalViewFilter.Location = New System.Drawing.Point(171, 7)
        Me.lblJournalViewFilter.Name = "lblJournalViewFilter"
        Me.lblJournalViewFilter.Size = New System.Drawing.Size(59, 15)
        Me.lblJournalViewFilter.TabIndex = 84
        Me.lblJournalViewFilter.Text = "Ansicht:"
        '
        'cboJournalFilterView
        '
        Me.cboJournalFilterView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJournalFilterView.Location = New System.Drawing.Point(247, 2)
        Me.cboJournalFilterView.Name = "cboJournalFilterView"
        Me.cboJournalFilterView.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboJournalFilterView.Properties.Appearance.Options.UseFont = True
        Me.cboJournalFilterView.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboJournalFilterView.Properties.DropDownRows = 11
        Me.cboJournalFilterView.Properties.PopupSizeable = True
        Me.cboJournalFilterView.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboJournalFilterView.Size = New System.Drawing.Size(123, 22)
        Me.cboJournalFilterView.TabIndex = 0
        '
        'lblJournalSelectedTotalSumValue
        '
        Me.lblJournalSelectedTotalSumValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJournalSelectedTotalSumValue.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblJournalSelectedTotalSumValue.Location = New System.Drawing.Point(99, 40)
        Me.lblJournalSelectedTotalSumValue.Name = "lblJournalSelectedTotalSumValue"
        Me.lblJournalSelectedTotalSumValue.Size = New System.Drawing.Size(98, 16)
        Me.lblJournalSelectedTotalSumValue.TabIndex = 82
        Me.lblJournalSelectedTotalSumValue.Tag = "DontTranslate"
        Me.lblJournalSelectedTotalSumValue.Text = "0,00€"
        Me.lblJournalSelectedTotalSumValue.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblJournalTotalSumValue
        '
        Me.lblJournalTotalSumValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJournalTotalSumValue.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblJournalTotalSumValue.Location = New System.Drawing.Point(99, 24)
        Me.lblJournalTotalSumValue.Name = "lblJournalTotalSumValue"
        Me.lblJournalTotalSumValue.Size = New System.Drawing.Size(98, 16)
        Me.lblJournalTotalSumValue.TabIndex = 82
        Me.lblJournalTotalSumValue.Tag = "DontTranslate"
        Me.lblJournalTotalSumValue.Text = "0,00€"
        Me.lblJournalTotalSumValue.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblJournalSelectedTotalSum
        '
        Me.lblJournalSelectedTotalSum.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJournalSelectedTotalSum.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblJournalSelectedTotalSum.Location = New System.Drawing.Point(9, 40)
        Me.lblJournalSelectedTotalSum.Name = "lblJournalSelectedTotalSum"
        Me.lblJournalSelectedTotalSum.Size = New System.Drawing.Size(98, 16)
        Me.lblJournalSelectedTotalSum.TabIndex = 82
        Me.lblJournalSelectedTotalSum.Tag = "DontTranslate"
        Me.lblJournalSelectedTotalSum.Text = "Markierte:"
        '
        'spcGridContainer
        '
        Me.spcGridContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spcGridContainer.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2
        Me.spcGridContainer.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.spcGridContainer.Horizontal = False
        Me.spcGridContainer.Location = New System.Drawing.Point(133, 61)
        Me.spcGridContainer.Name = "spcGridContainer"
        Me.spcGridContainer.Panel1.Controls.Add(Me.grdJournalList)
        Me.spcGridContainer.Panel1.Text = "Panel1"
        Me.spcGridContainer.Panel2.Controls.Add(Me.txtJournalMemo)
        Me.spcGridContainer.Panel2.Text = "Panel2"
        Me.spcGridContainer.Size = New System.Drawing.Size(546, 206)
        Me.spcGridContainer.SplitterPosition = 28
        Me.spcGridContainer.TabIndex = 92
        Me.spcGridContainer.Text = "SplitContainerControl2"
        '
        'txtJournalMemo
        '
        Me.txtJournalMemo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtJournalMemo.Location = New System.Drawing.Point(0, 0)
        Me.txtJournalMemo.Margin = New System.Windows.Forms.Padding(0)
        Me.txtJournalMemo.Name = "txtJournalMemo"
        Me.txtJournalMemo.Properties.NullValuePrompt = "Notizen zum markierten dokument"
        Me.txtJournalMemo.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtJournalMemo.Size = New System.Drawing.Size(546, 28)
        Me.txtJournalMemo.TabIndex = 0
        '
        'frmJournal
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(691, 308)
        Me.Controls.Add(Me.spcGridContainer)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.nvbDocuments)
        Me.Controls.Add(Me.lcSaveAttachment)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblCurrentFile)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.barDockControlTop)
        Me.DoubleBuffered = True
        Me.LookAndFeel.UseWindowsXPTheme = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(698, 272)
        Me.Name = "frmJournal"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Journal"
        CType(Me.grvAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdJournalList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuLstView.ResumeLayout(False)
        CType(Me.grvDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repTaggedIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nvbDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsNavBar.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.cboJournalFilterView.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spcGridContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcGridContainer.ResumeLayout(False)
        CType(Me.txtJournalMemo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Friend WithEvents ContextMenuLstView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuOpenDocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrintDocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents nvbDocuments As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents nbgGroupCommonDocs As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents nbiDocumentsAngebote As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents nbiDocumentsRechnungen As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents nbiDocumentsAlle As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents grdJournalList As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvDocuments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents nbiDocumentsGutschriften As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents nbiDocumentsMahnungen As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents nbiDocumentsAufträge As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOpen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RepositoryItemPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents CardView1 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents grvAttachments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents mnuAttachmentSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteAttachmentItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblJournalHeadline As System.Windows.Forms.Label
    Friend WithEvents lblJournalTotalSum As System.Windows.Forms.Label
    Friend WithEvents lblCurrentFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lcSaveAttachment As HWLInterops.MRG.Controls.UI.LoadingCircle
    Friend WithEvents mnuAddAttachment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents colDisplayID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHasAttachment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colChecked As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDocumentType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAdresswindow As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDocumentNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDocumentSum As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents mnuCreateNewDocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeletedocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchPanel As ClausSoftware.HWLInterops.iucSearchPanel
    Friend WithEvents mnuDuplicate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents lblJournalViewFilter As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboJournalFilterView As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents mnuTagged As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colTagged As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repTaggedIcon As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents colFirstCol As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalDuration As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents spcGridContainer As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents txtJournalMemo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents mnuUndeleteDocument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colIsCanceled As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCreateSummarizedInvoice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsNavBar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnRenameNavBarItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colHasInvoiceReference As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblJournalSelectedTotalSum As System.Windows.Forms.Label
    Friend WithEvents lblJournalSelectedTotalSumValue As System.Windows.Forms.Label
    Friend WithEvents lblJournalTotalSumValue As System.Windows.Forms.Label
End Class
