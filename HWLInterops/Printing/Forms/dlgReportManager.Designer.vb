Namespace Printing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class dlgReportManager
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
            Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgReportManager))
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
            Me.lblPrintLayoutsInGroup = New DevExpress.XtraEditors.LabelControl()
            Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
            Me.btnImport = New DevExpress.XtraEditors.SimpleButton()
            Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
            Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
            Me.cobDataType = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.grdReportsList = New DevExpress.XtraGrid.GridControl()
            Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colIsDefault = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
            Me.colReportName = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.colreportType = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.txtDescriptionText = New DevExpress.XtraEditors.MemoEdit()
            Me.gridContextMenü = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuDuplicateReport = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuResetReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.cobDataType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grdReportsList, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtDescriptionText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gridContextMenü.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Appearance.Options.UseFont = True
            Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnClose.Location = New System.Drawing.Point(353, 335)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(87, 27)
            Me.btnClose.TabIndex = 7
            Me.btnClose.Text = "Schliessen"
            '
            'btnNew
            '
            Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnNew.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNew.Appearance.Options.UseFont = True
            Me.btnNew.Location = New System.Drawing.Point(341, 66)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(98, 27)
            Me.btnNew.TabIndex = 3
            Me.btnNew.Text = "Neu"
            '
            'lblPrintLayoutsInGroup
            '
            Me.lblPrintLayoutsInGroup.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPrintLayoutsInGroup.Appearance.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblPrintLayoutsInGroup.Appearance.Options.UseFont = True
            Me.lblPrintLayoutsInGroup.Appearance.Options.UseForeColor = True
            Me.lblPrintLayoutsInGroup.Location = New System.Drawing.Point(12, 12)
            Me.lblPrintLayoutsInGroup.Name = "lblPrintLayoutsInGroup"
            Me.lblPrintLayoutsInGroup.Size = New System.Drawing.Size(214, 20)
            Me.lblPrintLayoutsInGroup.TabIndex = 3
            Me.lblPrintLayoutsInGroup.Text = "Druck-Layouts in dieser Gruppe: "
            '
            'btnDelete
            '
            Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnDelete.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelete.Appearance.Options.UseFont = True
            Me.btnDelete.Enabled = False
            Me.btnDelete.Location = New System.Drawing.Point(341, 99)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(98, 27)
            Me.btnDelete.TabIndex = 4
            Me.btnDelete.Text = "Löschen"
            '
            'btnImport
            '
            Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnImport.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnImport.Appearance.Options.UseFont = True
            Me.btnImport.Location = New System.Drawing.Point(341, 193)
            Me.btnImport.Name = "btnImport"
            Me.btnImport.Size = New System.Drawing.Size(98, 27)
            Me.btnImport.TabIndex = 6
            Me.btnImport.Text = "Importieren..."
            '
            'btnExport
            '
            Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnExport.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExport.Appearance.Options.UseFont = True
            Me.btnExport.Enabled = False
            Me.btnExport.Location = New System.Drawing.Point(341, 159)
            Me.btnExport.Name = "btnExport"
            Me.btnExport.Size = New System.Drawing.Size(98, 27)
            Me.btnExport.TabIndex = 5
            Me.btnExport.Text = "Exportieren..."
            '
            'lblDescription
            '
            Me.lblDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDescription.Appearance.Options.UseFont = True
            Me.lblDescription.Location = New System.Drawing.Point(19, 247)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(75, 15)
            Me.lblDescription.TabIndex = 4
            Me.lblDescription.Text = "Beschreibung:"
            '
            'cobDataType
            '
            Me.cobDataType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cobDataType.Location = New System.Drawing.Point(12, 38)
            Me.cobDataType.Name = "cobDataType"
            Me.cobDataType.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cobDataType.Properties.Appearance.Options.UseFont = True
            Me.cobDataType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cobDataType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.cobDataType.Size = New System.Drawing.Size(317, 22)
            Me.cobDataType.TabIndex = 0
            '
            'grdReportsList
            '
            Me.grdReportsList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            GridLevelNode1.RelationName = "Level1"
            Me.grdReportsList.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
            Me.grdReportsList.Location = New System.Drawing.Point(12, 66)
            Me.grdReportsList.MainView = Me.GridView1
            Me.grdReportsList.Name = "grdReportsList"
            Me.grdReportsList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
            Me.grdReportsList.Size = New System.Drawing.Size(317, 157)
            Me.grdReportsList.TabIndex = 1
            Me.grdReportsList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
            '
            'GridView1
            '
            Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colIsDefault, Me.colReportName, Me.colreportType})
            Me.GridView1.GridControl = Me.grdReportsList
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
            Me.GridView1.OptionsCustomization.AllowGroup = False
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowColumnHeaders = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True

            Me.GridView1.OptionsView.ShowIndicator = False
            Me.GridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False

            '
            'colIsDefault
            '
            Me.colIsDefault.Caption = "Standard"
            Me.colIsDefault.ColumnEdit = Me.RepositoryItemCheckEdit1
            Me.colIsDefault.FieldName = "IsDefault"
            Me.colIsDefault.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Me.colIsDefault.Name = "colIsDefault"
            Me.colIsDefault.Visible = True
            Me.colIsDefault.VisibleIndex = 0
            '
            'RepositoryItemCheckEdit1
            '
            Me.RepositoryItemCheckEdit1.AutoHeight = False
            Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
            '
            'colReportName
            '
            Me.colReportName.Caption = "GridColumn1"
            Me.colReportName.FieldName = "ReportName"
            Me.colReportName.Name = "colReportName"
            Me.colReportName.Visible = True
            Me.colReportName.VisibleIndex = 1
            '
            'colreportType
            '
            Me.colreportType.AppearanceCell.Options.UseTextOptions = True
            Me.colreportType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Me.colreportType.Caption = "Typ"
            Me.colreportType.FieldName = "DataSourceKind"
            Me.colreportType.Name = "colreportType"
            Me.colreportType.OptionsColumn.AllowEdit = False
            Me.colreportType.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
            Me.colreportType.Visible = True
            Me.colreportType.VisibleIndex = 2
            '
            'txtDescriptionText
            '
            Me.txtDescriptionText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDescriptionText.Location = New System.Drawing.Point(19, 268)
            Me.txtDescriptionText.Name = "txtDescriptionText"
            Me.txtDescriptionText.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDescriptionText.Properties.Appearance.Options.UseFont = True
            Me.txtDescriptionText.Size = New System.Drawing.Size(422, 59)
            Me.txtDescriptionText.TabIndex = 8
            '
            'gridContextMenü
            '
            Me.gridContextMenü.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdit, Me.mnuDelete, Me.mnuDuplicateReport, Me.ToolStripMenuItem1, Me.mnuResetReports})
            Me.gridContextMenü.Name = "ContextMenuStrip1"
            Me.gridContextMenü.Size = New System.Drawing.Size(146, 98)
            '
            'mnuEdit
            '
            Me.mnuEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.mnuEdit.Name = "mnuEdit"
            Me.mnuEdit.Size = New System.Drawing.Size(145, 22)
            Me.mnuEdit.Text = "Bearbeiten..."
            '
            'mnuDelete
            '
            Me.mnuDelete.Name = "mnuDelete"
            Me.mnuDelete.Size = New System.Drawing.Size(145, 22)
            Me.mnuDelete.Text = "Löschen"
            '
            'mnuDuplicateReport
            '
            Me.mnuDuplicateReport.Name = "mnuDuplicateReport"
            Me.mnuDuplicateReport.Size = New System.Drawing.Size(145, 22)
            Me.mnuDuplicateReport.Text = "Duplizieren"
            '
            'ToolStripMenuItem1
            '
            Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
            Me.ToolStripMenuItem1.Size = New System.Drawing.Size(142, 6)
            '
            'mnuResetReports
            '
            Me.mnuResetReports.Name = "mnuResetReports"
            Me.mnuResetReports.Size = New System.Drawing.Size(145, 22)
            Me.mnuResetReports.Text = "Zurücksetzen"
            '
            'btnEdit
            '
            Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnEdit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEdit.Appearance.Options.UseFont = True
            Me.btnEdit.Enabled = False
            Me.btnEdit.Location = New System.Drawing.Point(341, 33)
            Me.btnEdit.Name = "btnEdit"
            Me.btnEdit.Size = New System.Drawing.Size(98, 27)
            Me.btnEdit.TabIndex = 2
            Me.btnEdit.Text = "Bearbeiten..."
            '
            'dlgReportManager
            '
            Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(451, 368)
            Me.Controls.Add(Me.txtDescriptionText)
            Me.Controls.Add(Me.grdReportsList)
            Me.Controls.Add(Me.lblDescription)
            Me.Controls.Add(Me.cobDataType)
            Me.Controls.Add(Me.lblPrintLayoutsInGroup)
            Me.Controls.Add(Me.btnEdit)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnExport)
            Me.Controls.Add(Me.btnImport)
            Me.Controls.Add(Me.btnDelete)
            Me.Controls.Add(Me.btnNew)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(467, 406)
            Me.Name = "dlgReportManager"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.Text = "Drucklayout-Manager"
            CType(Me.cobDataType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grdReportsList, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtDescriptionText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gridContextMenü.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents lblPrintLayoutsInGroup As DevExpress.XtraEditors.LabelControl
        Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnImport As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
        Friend WithEvents cobDataType As DevExpress.XtraEditors.ComboBoxEdit
        Friend WithEvents grdReportsList As DevExpress.XtraGrid.GridControl
        Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents colReportName As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents txtDescriptionText As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents colIsDefault As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Friend WithEvents gridContextMenü As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents colreportType As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents mnuResetReports As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuDuplicateReport As System.Windows.Forms.ToolStripMenuItem
    End Class

End Namespace