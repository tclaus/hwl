<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddTextAsItem
    Inherits ClausSoftware.HWLInterops.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.trvArticleGroups = New DevExpress.XtraTreeList.TreeList()
        Me.TreeListColumn1 = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.cmdTreeview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnNewFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.lblHeadlineAddArticleText = New DevExpress.XtraEditors.LabelControl()
        CType(Me.trvArticleGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmdTreeview.SuspendLayout()
        Me.SuspendLayout()
        '
        'trvArticleGroups
        '
        Me.trvArticleGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvArticleGroups.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.TreeListColumn1})
        Me.trvArticleGroups.ContextMenuStrip = Me.cmdTreeview
        Me.trvArticleGroups.Location = New System.Drawing.Point(14, 50)
        Me.trvArticleGroups.Name = "trvArticleGroups"
        Me.trvArticleGroups.OptionsSelection.InvertSelection = True
        Me.trvArticleGroups.OptionsView.ShowColumns = False
        Me.trvArticleGroups.OptionsView.ShowIndicator = False
        Me.trvArticleGroups.Size = New System.Drawing.Size(298, 99)
        Me.trvArticleGroups.TabIndex = 0
        '
        'TreeListColumn1
        '
        Me.TreeListColumn1.Caption = "Name"
        Me.TreeListColumn1.FieldName = "Name"
        Me.TreeListColumn1.Name = "TreeListColumn1"
        Me.TreeListColumn1.OptionsColumn.AllowEdit = False
        Me.TreeListColumn1.Visible = True
        Me.TreeListColumn1.VisibleIndex = 0
        '
        'cmdTreeview
        '
        Me.cmdTreeview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNewFolder})
        Me.cmdTreeview.Name = "ContextMenuStrip1"
        Me.cmdTreeview.Size = New System.Drawing.Size(204, 48)
        '
        'btnNewFolder
        '
        Me.btnNewFolder.Name = "btnNewFolder"
        Me.btnNewFolder.Size = New System.Drawing.Size(203, 22)
        Me.btnNewFolder.Text = "Neuen Ordner anlegen..."
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(225, 155)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.Location = New System.Drawing.Point(130, 155)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 27)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'lblHeadlineAddArticleText
        '
        Me.lblHeadlineAddArticleText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadlineAddArticleText.Appearance.Options.UseFont = True
        Me.lblHeadlineAddArticleText.Appearance.Options.UseTextOptions = True
        Me.lblHeadlineAddArticleText.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblHeadlineAddArticleText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblHeadlineAddArticleText.Location = New System.Drawing.Point(15, 1)
        Me.lblHeadlineAddArticleText.Name = "lblHeadlineAddArticleText"
        Me.lblHeadlineAddArticleText.Size = New System.Drawing.Size(310, 42)
        Me.lblHeadlineAddArticleText.TabIndex = 2
        Me.lblHeadlineAddArticleText.Text = "Wählen Sie die Artikelgruppe, in der der Text als Artikel eingefügt werden soll."
        '
        'frmAddTextAsItem
        '
        Me.AcceptButton = Me.btnOK
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(326, 196)
        Me.Controls.Add(Me.lblHeadlineAddArticleText)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.trvArticleGroups)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddTextAsItem"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Text als Artikel anlegen"
        CType(Me.trvArticleGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmdTreeview.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents trvArticleGroups As DevExpress.XtraTreeList.TreeList
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TreeListColumn1 As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents lblHeadlineAddArticleText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdTreeview As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnNewFolder As System.Windows.Forms.ToolStripMenuItem
End Class
