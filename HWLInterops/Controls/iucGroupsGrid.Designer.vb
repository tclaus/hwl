Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucGroupsGrid
    Inherits mainControlContainer

    'iucGroupsGrid overrides dispose to clean up the component list.
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(iucGroupsGrid))
        Me.grvAttachments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdArticles = New DevExpress.XtraGrid.GridControl()
        Me.cmsGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOpenItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCreateNewArticle = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenInNewWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDuplicateItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopySelectedArticles = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteArticle = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteAttachment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddAttachment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenItensGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.grvArticles = New ClausSoftware.HWLInterops.PrintingGrid()
        Me.PictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.RepositoryItemPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.SplitContainer1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.trvGroups = New DevExpress.XtraTreeList.TreeList()
        Me.colName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colReplikID = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cmsTreeView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuGroupDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCreateGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRenameGroupItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClassification = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCreateArticleFromGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuShowEmptyGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSelectforCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ttcTreeview = New DevExpress.Utils.ToolTipController(Me.components)
        Me.m_focusedNodeDeferment = New System.Windows.Forms.Timer(Me.components)
        CType(Me.grvAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdArticles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsGrid.SuspendLayout()
        CType(Me.grvArticles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.trvGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTreeView.SuspendLayout()
        Me.SuspendLayout()
        '
        'grvAttachments
        '
        Me.grvAttachments.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvAttachments.Appearance.OddRow.Options.UseBackColor = True
        Me.grvAttachments.GridControl = Me.grdArticles
        Me.grvAttachments.Name = "grvAttachments"
        Me.grvAttachments.OptionsBehavior.Editable = False
        Me.grvAttachments.OptionsCustomization.AllowGroup = False
        Me.grvAttachments.OptionsCustomization.AllowRowSizing = True
        Me.grvAttachments.OptionsDetail.EnableDetailToolTip = True
        Me.grvAttachments.OptionsDetail.ShowDetailTabs = False
        Me.grvAttachments.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvAttachments.OptionsSelection.MultiSelect = True
        Me.grvAttachments.OptionsView.EnableAppearanceEvenRow = True
        Me.grvAttachments.OptionsView.EnableAppearanceOddRow = True
        Me.grvAttachments.OptionsView.ShowGroupPanel = False
        '
        'grdArticles
        '
        Me.grdArticles.AllowDrop = True
        Me.grdArticles.ContextMenuStrip = Me.cmsGrid
        Me.grdArticles.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.LevelTemplate = Me.grvAttachments
        GridLevelNode1.RelationName = "Attachments"
        Me.grdArticles.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdArticles.Location = New System.Drawing.Point(0, 0)
        Me.grdArticles.MainView = Me.grvArticles
        Me.grdArticles.Name = "grdArticles"
        Me.grdArticles.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PictureEdit, Me.RepositoryItemPictureEdit})
        Me.grdArticles.Size = New System.Drawing.Size(672, 357)
        Me.grdArticles.TabIndex = 0
        Me.grdArticles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvArticles, Me.GridView3, Me.grvAttachments})
        '
        'cmsGrid
        '
        Me.cmsGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenItem, Me.mnuCreateNewArticle, Me.mnuOpenInNewWindow, Me.ToolStripMenuItem1, Me.mnuDuplicateItem, Me.mnuCopySelectedArticles, Me.mnuDeleteArticle, Me.mnuDeleteAttachment, Me.mnuAddAttachment, Me.mnuOpenItensGroup})
        Me.cmsGrid.Name = "cmsGrid"
        Me.cmsGrid.Size = New System.Drawing.Size(204, 230)
        '
        'mnuOpenItem
        '
        Me.mnuOpenItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuOpenItem.Name = "mnuOpenItem"
        Me.mnuOpenItem.Size = New System.Drawing.Size(203, 22)
        Me.mnuOpenItem.Text = "Artikel öffnen"
        '
        'mnuCreateNewArticle
        '
        Me.mnuCreateNewArticle.Image = CType(resources.GetObject("mnuCreateNewArticle.Image"), System.Drawing.Image)
        Me.mnuCreateNewArticle.Name = "mnuCreateNewArticle"
        Me.mnuCreateNewArticle.Size = New System.Drawing.Size(203, 22)
        Me.mnuCreateNewArticle.Text = "Neuen Artikel anlegen"
        Me.mnuCreateNewArticle.ToolTipText = "Erstellt in der aktuell ausgewählten Gruppe einen neuen Artikel"
        '
        'mnuOpenInNewWindow
        '
        Me.mnuOpenInNewWindow.Name = "mnuOpenInNewWindow"
        Me.mnuOpenInNewWindow.Size = New System.Drawing.Size(203, 22)
        Me.mnuOpenInNewWindow.Text = "Im neuen Fenster öffnen"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(200, 6)
        '
        'mnuDuplicateItem
        '
        Me.mnuDuplicateItem.Image = CType(resources.GetObject("mnuDuplicateItem.Image"), System.Drawing.Image)
        Me.mnuDuplicateItem.Name = "mnuDuplicateItem"
        Me.mnuDuplicateItem.Size = New System.Drawing.Size(203, 22)
        Me.mnuDuplicateItem.Text = "Duplizieren"
        Me.mnuDuplicateItem.ToolTipText = "Legt von dem aktuell angelegtem Artikel eine Kopie an. Die Kopie ist danach unabh" & _
    "ängig vom Ausgangsdokument"
        '
        'mnuCopySelectedArticles
        '
        Me.mnuCopySelectedArticles.Checked = True
        Me.mnuCopySelectedArticles.CheckOnClick = True
        Me.mnuCopySelectedArticles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuCopySelectedArticles.Image = CType(resources.GetObject("mnuCopySelectedArticles.Image"), System.Drawing.Image)
        Me.mnuCopySelectedArticles.Name = "mnuCopySelectedArticles"
        Me.mnuCopySelectedArticles.Size = New System.Drawing.Size(203, 22)
        Me.mnuCopySelectedArticles.Text = "Artikel bereitstellen"
        Me.mnuCopySelectedArticles.Visible = False
        '
        'mnuDeleteArticle
        '
        Me.mnuDeleteArticle.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Delete
        Me.mnuDeleteArticle.Name = "mnuDeleteArticle"
        Me.mnuDeleteArticle.Size = New System.Drawing.Size(203, 22)
        Me.mnuDeleteArticle.Text = "Artikel löschen"
        Me.mnuDeleteArticle.ToolTipText = "Löscht die aktuelle ausgewählten Artikel"
        '
        'mnuDeleteAttachment
        '
        Me.mnuDeleteAttachment.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Delete
        Me.mnuDeleteAttachment.Name = "mnuDeleteAttachment"
        Me.mnuDeleteAttachment.Size = New System.Drawing.Size(203, 22)
        Me.mnuDeleteAttachment.Text = "Anhang löschen"
        Me.mnuDeleteAttachment.ToolTipText = "Löscht den aktuell ausgewählten Anhang"
        '
        'mnuAddAttachment
        '
        Me.mnuAddAttachment.Name = "mnuAddAttachment"
        Me.mnuAddAttachment.Size = New System.Drawing.Size(203, 22)
        Me.mnuAddAttachment.Text = "Anhang hinzufügen"
        Me.mnuAddAttachment.ToolTipText = "Fügt aus dem Dateisystem eine beliebige Datei dem gewählten Artikel hinzu"
        '
        'mnuOpenItensGroup
        '
        Me.mnuOpenItensGroup.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Refresh
        Me.mnuOpenItensGroup.Name = "mnuOpenItensGroup"
        Me.mnuOpenItensGroup.Size = New System.Drawing.Size(203, 22)
        Me.mnuOpenItensGroup.Text = "Gruppe öffnen"
        '
        'grvArticles
        '
        Me.grvArticles.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvArticles.Appearance.EvenRow.Options.UseBackColor = True
        Me.grvArticles.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grvArticles.GridControl = Me.grdArticles
        Me.grvArticles.IsPrinting = False
        Me.grvArticles.Name = "grvArticles"
        Me.grvArticles.OptionsBehavior.Editable = False
        Me.grvArticles.OptionsCustomization.AllowRowSizing = True
        Me.grvArticles.OptionsDetail.EnableDetailToolTip = True
        Me.grvArticles.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails
        Me.grvArticles.OptionsFilter.AllowColumnMRUFilterList = False
        Me.grvArticles.OptionsFilter.AllowMRUFilterList = False
        Me.grvArticles.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.grvArticles.OptionsFilter.UseNewCustomFilterDialog = True
        Me.grvArticles.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvArticles.OptionsSelection.MultiSelect = True
        Me.grvArticles.OptionsView.EnableAppearanceEvenRow = True
        Me.grvArticles.OptionsView.ShowDetailButtons = False
        Me.grvArticles.OptionsView.ShowGroupPanel = False
        Me.grvArticles.PaintStyleName = "WindowsXP"
        '
        'PictureEdit
        '
        Me.PictureEdit.Name = "PictureEdit"
        '
        'RepositoryItemPictureEdit
        '
        Me.RepositoryItemPictureEdit.Name = "RepositoryItemPictureEdit"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.grdArticles
        Me.GridView3.Name = "GridView3"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Panel1.Controls.Add(Me.trvGroups)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdArticles)
        Me.SplitContainer1.Size = New System.Drawing.Size(856, 357)
        Me.SplitContainer1.SplitterPosition = 178
        Me.SplitContainer1.TabIndex = 0
        '
        'trvGroups
        '
        Me.trvGroups.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colName, Me.colReplikID})
        Me.trvGroups.ContextMenuStrip = Me.cmsTreeView
        Me.trvGroups.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvGroups.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvGroups.HorzScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Always
        Me.trvGroups.Location = New System.Drawing.Point(0, 0)
        Me.trvGroups.Name = "trvGroups"
        Me.trvGroups.OptionsBehavior.AllowIncrementalSearch = True
        Me.trvGroups.OptionsBehavior.AutoFocusNewNode = True
        Me.trvGroups.OptionsBehavior.AutoMoveRowFocus = True
        Me.trvGroups.OptionsBehavior.DragNodes = True
        Me.trvGroups.OptionsBehavior.EnableFiltering = True
        Me.trvGroups.OptionsBehavior.EnterMovesNextColumn = True
        Me.trvGroups.OptionsBehavior.ExpandNodesOnIncrementalSearch = True
        Me.trvGroups.OptionsBehavior.ShowEditorOnMouseUp = True
        Me.trvGroups.OptionsSelection.InvertSelection = True
        Me.trvGroups.OptionsSelection.MultiSelect = True
        Me.trvGroups.OptionsSelection.UseIndicatorForSelection = True
        Me.trvGroups.OptionsView.ShowColumns = False
        Me.trvGroups.OptionsView.ShowHorzLines = False
        Me.trvGroups.OptionsView.ShowIndicator = False
        Me.trvGroups.OptionsView.ShowVertLines = False
        Me.trvGroups.Size = New System.Drawing.Size(178, 357)
        Me.trvGroups.TabIndex = 0
        Me.trvGroups.ToolTipController = Me.ttcTreeview
        Me.trvGroups.TreeLevelWidth = 12
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.OptionsColumn.AllowEdit = False
        Me.colName.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.colName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 0
        '
        'colReplikID
        '
        Me.colReplikID.Caption = "TreeListColumn1"
        Me.colReplikID.FieldName = "ReplikID"
        Me.colReplikID.Name = "colReplikID"
        Me.colReplikID.Visible = True
        Me.colReplikID.VisibleIndex = 1
        '
        'cmsTreeView
        '
        Me.cmsTreeView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGroupDetails, Me.mnuCreateGroup, Me.mnuDeleteGroup, Me.mnuRenameGroupItem, Me.mnuClassification, Me.ToolStripMenuItem2, Me.mnuCreateArticleFromGroup, Me.mnuShowEmptyGroups, Me.mnuSelectforCopy})
        Me.cmsTreeView.Name = "cmdTreeView"
        Me.cmsTreeView.Size = New System.Drawing.Size(192, 208)
        '
        'mnuGroupDetails
        '
        Me.mnuGroupDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuGroupDetails.Name = "mnuGroupDetails"
        Me.mnuGroupDetails.Size = New System.Drawing.Size(191, 22)
        Me.mnuGroupDetails.Text = "Gruppen Details..."
        '
        'mnuCreateGroup
        '
        Me.mnuCreateGroup.Image = CType(resources.GetObject("mnuCreateGroup.Image"), System.Drawing.Image)
        Me.mnuCreateGroup.Name = "mnuCreateGroup"
        Me.mnuCreateGroup.Size = New System.Drawing.Size(191, 22)
        Me.mnuCreateGroup.Text = "Neue Gruppe anlegen"
        '
        'mnuDeleteGroup
        '
        Me.mnuDeleteGroup.Image = CType(resources.GetObject("mnuDeleteGroup.Image"), System.Drawing.Image)
        Me.mnuDeleteGroup.Name = "mnuDeleteGroup"
        Me.mnuDeleteGroup.Size = New System.Drawing.Size(191, 22)
        Me.mnuDeleteGroup.Text = "Gruppe löschen"
        '
        'mnuRenameGroupItem
        '
        Me.mnuRenameGroupItem.Name = "mnuRenameGroupItem"
        Me.mnuRenameGroupItem.Size = New System.Drawing.Size(191, 22)
        Me.mnuRenameGroupItem.Text = "Umbenennen"
        '
        'mnuClassification
        '
        Me.mnuClassification.Name = "mnuClassification"
        Me.mnuClassification.Size = New System.Drawing.Size(191, 22)
        Me.mnuClassification.Text = "Klassifizierung"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(188, 6)
        '
        'mnuCreateArticleFromGroup
        '
        Me.mnuCreateArticleFromGroup.Image = CType(resources.GetObject("mnuCreateArticleFromGroup.Image"), System.Drawing.Image)
        Me.mnuCreateArticleFromGroup.Name = "mnuCreateArticleFromGroup"
        Me.mnuCreateArticleFromGroup.Size = New System.Drawing.Size(191, 22)
        Me.mnuCreateArticleFromGroup.Text = "Neuen Artikel anlegen"
        Me.mnuCreateArticleFromGroup.ToolTipText = "Erstellt in der aktuell ausgewählten Gruppe einen neuen Artikel"
        '
        'mnuShowEmptyGroups
        '
        Me.mnuShowEmptyGroups.Name = "mnuShowEmptyGroups"
        Me.mnuShowEmptyGroups.Size = New System.Drawing.Size(191, 22)
        Me.mnuShowEmptyGroups.Text = "Zeige leere Gruppen"
        Me.mnuShowEmptyGroups.Visible = False
        '
        'mnuSelectforCopy
        '
        Me.mnuSelectforCopy.Checked = True
        Me.mnuSelectforCopy.CheckOnClick = True
        Me.mnuSelectforCopy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuSelectforCopy.Image = CType(resources.GetObject("mnuSelectforCopy.Image"), System.Drawing.Image)
        Me.mnuSelectforCopy.Name = "mnuSelectforCopy"
        Me.mnuSelectforCopy.Size = New System.Drawing.Size(191, 22)
        Me.mnuSelectforCopy.Text = "Gruppe bereitstellen"
        Me.mnuSelectforCopy.Visible = False
        '
        'ttcTreeview
        '
        '
        'm_focusedNodeDeferment
        '
        Me.m_focusedNodeDeferment.Interval = 300
        '
        'iucGroupsGrid
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "iucGroupsGrid"
        Me.Size = New System.Drawing.Size(856, 357)
        CType(Me.grvAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdArticles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsGrid.ResumeLayout(False)
        CType(Me.grvArticles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.trvGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTreeView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grdArticles As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvArticles As PrintingGrid
    Friend WithEvents cmsTreeView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCreateGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuShowEmptyGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents mnuSelectforCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCopySelectedArticles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteArticle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRenameGroupItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents trvGroups As DevExpress.XtraTreeList.TreeList
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents colName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents grvAttachments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents mnuAddAttachment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCreateNewArticle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteAttachment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDuplicateItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCreateArticleFromGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents mnuGroupDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClassification As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenItensGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colReplikID As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents ttcTreeview As DevExpress.Utils.ToolTipController
    Friend WithEvents mnuOpenItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenInNewWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents m_focusedNodeDeferment As System.Windows.Forms.Timer

End Class
