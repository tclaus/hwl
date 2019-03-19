<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnterTaxRateValues
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
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.grdValueTaxPairs = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.grvValueTaxPairs = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTaxValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repTaxValue = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repValueedit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.grdValueTaxPairs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.grvValueTaxPairs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repTaxValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repValueedit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(210, 128)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(129, 128)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'grdValueTaxPairs
        '
        Me.grdValueTaxPairs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdValueTaxPairs.ContextMenuStrip = Me.ContextMenuStrip1
        Me.grdValueTaxPairs.Location = New System.Drawing.Point(0, 0)
        Me.grdValueTaxPairs.MainView = Me.grvValueTaxPairs
        Me.grdValueTaxPairs.Name = "grdValueTaxPairs"
        Me.grdValueTaxPairs.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repValueedit, Me.repTaxValue})
        Me.grdValueTaxPairs.ShowOnlyPredefinedDetails = True
        Me.grdValueTaxPairs.Size = New System.Drawing.Size(297, 122)
        Me.grdValueTaxPairs.TabIndex = 2
        Me.grdValueTaxPairs.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvValueTaxPairs})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(119, 48)
        '
        'mnuNew
        '
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(118, 22)
        Me.mnuNew.Text = "Neu"
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(118, 22)
        Me.mnuDelete.Text = "Löschen"
        '
        'grvValueTaxPairs
        '
        Me.grvValueTaxPairs.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTaxValue, Me.colValue})
        Me.grvValueTaxPairs.GridControl = Me.grdValueTaxPairs
        Me.grvValueTaxPairs.Name = "grvValueTaxPairs"
        Me.grvValueTaxPairs.OptionsCustomization.AllowColumnMoving = False
        Me.grvValueTaxPairs.OptionsCustomization.AllowFilter = False
        Me.grvValueTaxPairs.OptionsCustomization.AllowGroup = False
        Me.grvValueTaxPairs.OptionsCustomization.AllowSort = False
        Me.grvValueTaxPairs.OptionsMenu.EnableColumnMenu = False
        Me.grvValueTaxPairs.OptionsMenu.EnableFooterMenu = False
        Me.grvValueTaxPairs.OptionsMenu.EnableGroupPanelMenu = False
        Me.grvValueTaxPairs.OptionsView.ShowFooter = True
        Me.grvValueTaxPairs.OptionsView.ShowGroupPanel = False
        Me.grvValueTaxPairs.OptionsView.ShowIndicator = False
        Me.grvValueTaxPairs.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colTaxValue, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'colTaxValue
        '
        Me.colTaxValue.Caption = "Steuersatz"
        Me.colTaxValue.ColumnEdit = Me.repTaxValue
        Me.colTaxValue.FieldName = "Tax"
        Me.colTaxValue.Name = "colTaxValue"
        Me.colTaxValue.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.colTaxValue.Visible = True
        Me.colTaxValue.VisibleIndex = 0
        '
        'repTaxValue
        '
        Me.repTaxValue.AutoHeight = False
        Me.repTaxValue.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repTaxValue.Name = "repTaxValue"
        Me.repTaxValue.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colValue
        '
        Me.colValue.Caption = "Betrag"
        Me.colValue.ColumnEdit = Me.repValueedit
        Me.colValue.FieldName = "Value"
        Me.colValue.Name = "colValue"
        Me.colValue.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.colValue.Visible = True
        Me.colValue.VisibleIndex = 1
        '
        'repValueedit
        '
        Me.repValueedit.AutoHeight = False
        Me.repValueedit.DisplayFormat.FormatString = "c"
        Me.repValueedit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.repValueedit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.repValueedit.Mask.EditMask = "f"
        Me.repValueedit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repValueedit.Name = "repValueedit"
        '
        'frmEnterTaxRateValues
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 163)
        Me.Controls.Add(Me.grdValueTaxPairs)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MinimumSize = New System.Drawing.Size(313, 197)
        Me.Name = "frmEnterTaxRateValues"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Werte/ Steuersätze"
        CType(Me.grdValueTaxPairs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.grvValueTaxPairs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repTaxValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repValueedit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grdValueTaxPairs As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvValueTaxPairs As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTaxValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repValueedit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents repTaxValue As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
