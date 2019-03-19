<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetDocumentsTax
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdProceed = New DevExpress.XtraEditors.SimpleButton()
        Me.cobTaxRate = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblTaxRate = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtYear = New DevExpress.XtraEditors.TextEdit()
        Me.lblProgress = New DevExpress.XtraEditors.LabelControl()
        CType(Me.cobTaxRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(32, 32)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(192, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Steuersätze auf Dokumente angleichen."
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Location = New System.Drawing.Point(203, 176)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Schliessen"
        '
        'cmdProceed
        '
        Me.cmdProceed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdProceed.Location = New System.Drawing.Point(122, 176)
        Me.cmdProceed.Name = "cmdProceed"
        Me.cmdProceed.Size = New System.Drawing.Size(75, 23)
        Me.cmdProceed.TabIndex = 2
        Me.cmdProceed.Text = "Ausführen"
        '
        'cobTaxRate
        '
        Me.cobTaxRate.Location = New System.Drawing.Point(116, 79)
        Me.cobTaxRate.Name = "cobTaxRate"
        Me.cobTaxRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cobTaxRate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cobTaxRate.Size = New System.Drawing.Size(114, 20)
        Me.cobTaxRate.TabIndex = 3
        '
        'lblTaxRate
        '
        Me.lblTaxRate.Location = New System.Drawing.Point(32, 86)
        Me.lblTaxRate.Name = "lblTaxRate"
        Me.lblTaxRate.Size = New System.Drawing.Size(52, 13)
        Me.lblTaxRate.TabIndex = 4
        Me.lblTaxRate.Text = "Steuersatz"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(32, 112)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Ab Jahr: "
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(116, 105)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Properties.Mask.EditMask = "d"
        Me.txtYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtYear.Size = New System.Drawing.Size(100, 20)
        Me.txtYear.TabIndex = 5
        '
        'lblProgress
        '
        Me.lblProgress.Location = New System.Drawing.Point(32, 143)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(50, 13)
        Me.lblProgress.TabIndex = 6
        Me.lblProgress.Text = "Fortschritt"
        '
        'frmSetDocumentsTax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 211)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.lblTaxRate)
        Me.Controls.Add(Me.cobTaxRate)
        Me.Controls.Add(Me.cmdProceed)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "frmSetDocumentsTax"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Steuersätze angleichen"
        CType(Me.cobTaxRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdProceed As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cobTaxRate As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblTaxRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtYear As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblProgress As DevExpress.XtraEditors.LabelControl
End Class
