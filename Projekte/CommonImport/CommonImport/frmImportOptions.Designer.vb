<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportOptions
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.grdMappings = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colActive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colSource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTarget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repTargetAttributes = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnStartImport = New DevExpress.XtraEditors.SimpleButton()
        Me.btnReset = New DevExpress.XtraEditors.SimpleButton()
        Me.lblMappingHint = New DevExpress.XtraEditors.LabelControl()
        Me.lblCounter = New DevExpress.XtraEditors.LabelControl()
        CType(Me.grdMappings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repTargetAttributes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdMappings
        '
        Me.grdMappings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdMappings.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMappings.Location = New System.Drawing.Point(16, 39)
        Me.grdMappings.MainView = Me.GridView1
        Me.grdMappings.Name = "grdMappings"
        Me.grdMappings.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repTargetAttributes, Me.RepositoryItemCheckEdit1})
        Me.grdMappings.Size = New System.Drawing.Size(293, 149)
        Me.grdMappings.TabIndex = 2
        Me.grdMappings.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colActive, Me.colSource, Me.colTarget})
        Me.GridView1.GridControl = Me.grdMappings
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colActive
        '
        Me.colActive.Caption = "Aktiv"
        Me.colActive.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.colActive.FieldName = "Active"
        Me.colActive.Name = "colActive"
        Me.colActive.Visible = True
        Me.colActive.VisibleIndex = 0
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'colSource
        '
        Me.colSource.Caption = "Quelle"
        Me.colSource.FieldName = "Source"
        Me.colSource.Name = "colSource"
        Me.colSource.OptionsColumn.AllowEdit = False
        Me.colSource.Visible = True
        Me.colSource.VisibleIndex = 1
        '
        'colTarget
        '
        Me.colTarget.Caption = "Ziel"
        Me.colTarget.ColumnEdit = Me.repTargetAttributes
        Me.colTarget.FieldName = "Target"
        Me.colTarget.Name = "colTarget"
        Me.colTarget.Visible = True
        Me.colTarget.VisibleIndex = 2
        '
        'repTargetAttributes
        '
        Me.repTargetAttributes.AutoHeight = False
        Me.repTargetAttributes.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.repTargetAttributes.DropDownRows = 12
        Me.repTargetAttributes.Name = "repTargetAttributes"
        Me.repTargetAttributes.NullValuePrompt = "Zielspalte wählen"
        Me.repTargetAttributes.PopupSizeable = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.Location = New System.Drawing.Point(222, 231)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Schliessen"
        '
        'btnStartImport
        '
        Me.btnStartImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartImport.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartImport.Appearance.Options.UseFont = True
        Me.btnStartImport.Location = New System.Drawing.Point(128, 231)
        Me.btnStartImport.Name = "btnStartImport"
        Me.btnStartImport.Size = New System.Drawing.Size(87, 27)
        Me.btnStartImport.TabIndex = 3
        Me.btnStartImport.Text = "Starte"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Appearance.Options.UseFont = True
        Me.btnReset.Location = New System.Drawing.Point(16, 194)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(90, 23)
        Me.btnReset.TabIndex = 4
        Me.btnReset.Text = "Zurücksetzen"
        '
        'lblMappingHint
        '
        Me.lblMappingHint.Location = New System.Drawing.Point(16, 19)
        Me.lblMappingHint.Name = "lblMappingHint"
        Me.lblMappingHint.Size = New System.Drawing.Size(122, 13)
        Me.lblMappingHint.TabIndex = 5
        Me.lblMappingHint.Text = "Weisen Sie die Spalten zu"
        '
        'lblCounter
        '
        Me.lblCounter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCounter.Location = New System.Drawing.Point(16, 245)
        Me.lblCounter.Name = "lblCounter"
        Me.lblCounter.Size = New System.Drawing.Size(16, 13)
        Me.lblCounter.TabIndex = 6
        Me.lblCounter.Text = "0/0"
        '
        'frmImportOptions
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 272)
        Me.Controls.Add(Me.lblCounter)
        Me.Controls.Add(Me.lblMappingHint)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnStartImport)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grdMappings)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(309, 310)
        Me.Name = "frmImportOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Optionen"
        CType(Me.grdMappings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repTargetAttributes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdMappings As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colActive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colSource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTarget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repTargetAttributes As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnStartImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnReset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblMappingHint As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCounter As DevExpress.XtraEditors.LabelControl
End Class
