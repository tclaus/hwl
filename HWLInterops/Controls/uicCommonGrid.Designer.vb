Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uicCommonGrid
    Inherits System.Windows.Forms.UserControl

    'uicCommonGrid overrides dispose to clean up the component list.
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
        Me.crvCommonGrid = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.grdCommonGrid = New DevExpress.XtraGrid.GridControl()
        Me.cmsCommonGridMenue = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnOpenSelectedItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDuplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpaltenZurücksetzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grvCommonGrid = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.repImageCombo = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.CardView1 = New DevExpress.XtraGrid.Views.Card.CardView()
        Me.XpServerCollectionSource = New DevExpress.Xpo.XPServerCollectionSource()
        CType(Me.crvCommonGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCommonGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCommonGridMenue.SuspendLayout()
        CType(Me.grvCommonGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repImageCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XpServerCollectionSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'crvCommonGrid
        '
        Me.crvCommonGrid.FocusedCardTopFieldIndex = 0
        Me.crvCommonGrid.GridControl = Me.grdCommonGrid
        Me.crvCommonGrid.Name = "crvCommonGrid"
        Me.crvCommonGrid.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled
        Me.crvCommonGrid.OptionsBehavior.Editable = False
        Me.crvCommonGrid.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        '
        'grdCommonGrid
        '
        Me.grdCommonGrid.ContextMenuStrip = Me.cmsCommonGridMenue
        Me.grdCommonGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCommonGrid.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        GridLevelNode1.LevelTemplate = Me.crvCommonGrid
        GridLevelNode1.RelationName = "Level1"
        Me.grdCommonGrid.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdCommonGrid.Location = New System.Drawing.Point(3, 3)
        Me.grdCommonGrid.MainView = Me.grvCommonGrid
        Me.grdCommonGrid.Name = "grdCommonGrid"
        Me.grdCommonGrid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repImageCombo})
        Me.grdCommonGrid.Size = New System.Drawing.Size(600, 185)
        Me.grdCommonGrid.TabIndex = 0
        Me.grdCommonGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvCommonGrid, Me.CardView1, Me.crvCommonGrid})
        '
        'cmsCommonGridMenue
        '
        Me.cmsCommonGridMenue.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpenSelectedItem, Me.ToolStripMenuItem1, Me.mnuNew, Me.mnuDuplicate, Me.mnuDelete, Me.SpaltenZurücksetzenToolStripMenuItem})
        Me.cmsCommonGridMenue.Name = "cmsCommonGridMenue"
        Me.cmsCommonGridMenue.Size = New System.Drawing.Size(185, 142)
        '
        'btnOpenSelectedItem
        '
        Me.btnOpenSelectedItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenSelectedItem.Name = "btnOpenSelectedItem"
        Me.btnOpenSelectedItem.Size = New System.Drawing.Size(184, 22)
        Me.btnOpenSelectedItem.Text = "Eintrag öffnen"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 6)
        '
        'mnuNew
        '
        Me.mnuNew.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Document_Add
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(184, 22)
        Me.mnuNew.Text = "Neu"
        '
        'mnuDuplicate
        '
        Me.mnuDuplicate.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Copy
        Me.mnuDuplicate.Name = "mnuDuplicate"
        Me.mnuDuplicate.Size = New System.Drawing.Size(184, 22)
        Me.mnuDuplicate.Text = "Duplizieren"
        '
        'mnuDelete
        '
        Me.mnuDelete.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Delete
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(184, 22)
        Me.mnuDelete.Text = "Löschen"
        '
        'SpaltenZurücksetzenToolStripMenuItem
        '
        Me.SpaltenZurücksetzenToolStripMenuItem.Name = "SpaltenZurücksetzenToolStripMenuItem"
        Me.SpaltenZurücksetzenToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.SpaltenZurücksetzenToolStripMenuItem.Text = "Spalten zurücksetzen"
        '
        'grvCommonGrid
        '
        Me.grvCommonGrid.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grvCommonGrid.Appearance.EvenRow.Options.UseBackColor = True
        Me.grvCommonGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grvCommonGrid.GridControl = Me.grdCommonGrid
        Me.grvCommonGrid.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.grvCommonGrid.Name = "grvCommonGrid"
        Me.grvCommonGrid.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled
        Me.grvCommonGrid.OptionsBehavior.Editable = False
        Me.grvCommonGrid.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvCommonGrid.OptionsSelection.MultiSelect = True
        Me.grvCommonGrid.OptionsView.EnableAppearanceEvenRow = True
        Me.grvCommonGrid.OptionsView.ShowGroupPanel = False
        Me.grvCommonGrid.PaintStyleName = "WindowsXP"
        '
        'repImageCombo
        '
        Me.repImageCombo.AutoHeight = False
        Me.repImageCombo.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repImageCombo.Name = "repImageCombo"
        '
        'CardView1
        '
        Me.CardView1.FocusedCardTopFieldIndex = 0
        Me.CardView1.GridControl = Me.grdCommonGrid
        Me.CardView1.Name = "CardView1"
        Me.CardView1.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled
        Me.CardView1.OptionsBehavior.Editable = False
        Me.CardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        '
        'XpServerCollectionSource
        '
        Me.XpServerCollectionSource.AllowEdit = True
        '
        'uicCommonGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grdCommonGrid)
        Me.Name = "uicCommonGrid"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Size = New System.Drawing.Size(606, 191)
        CType(Me.crvCommonGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCommonGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCommonGridMenue.ResumeLayout(False)
        CType(Me.grvCommonGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repImageCombo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XpServerCollectionSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdCommonGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvCommonGrid As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XpServerCollectionSource As DevExpress.Xpo.XPServerCollectionSource
    Friend WithEvents CardView1 As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents crvCommonGrid As DevExpress.XtraGrid.Views.Card.CardView
    Friend WithEvents cmsCommonGridMenue As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDuplicate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpaltenZurücksetzenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnOpenSelectedItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents repImageCombo As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

End Class
