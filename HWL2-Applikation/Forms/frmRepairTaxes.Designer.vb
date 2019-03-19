<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepairTaxes
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
        Me.IucOptionTaxes1 = New ClausSoftware.HWLInterops.iucOptionTaxes()
        Me.btnclose = New DevExpress.XtraEditors.SimpleButton()
        Me.lblCheckTaxRates = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'IucOptionTaxes1
        '
        Me.IucOptionTaxes1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IucOptionTaxes1.Appearance.BackColor = System.Drawing.Color.White
        Me.IucOptionTaxes1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IucOptionTaxes1.Appearance.Options.UseBackColor = True
        Me.IucOptionTaxes1.Appearance.Options.UseFont = True
        Me.IucOptionTaxes1.Location = New System.Drawing.Point(12, 45)
        Me.IucOptionTaxes1.Name = "IucOptionTaxes1"
        Me.IucOptionTaxes1.ShowTaxAssignment = False
        Me.IucOptionTaxes1.Size = New System.Drawing.Size(302, 200)
        Me.IucOptionTaxes1.TabIndex = 0
        '
        'btnclose
        '
        Me.btnclose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnclose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Appearance.Options.UseFont = True
        Me.btnclose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnclose.Location = New System.Drawing.Point(240, 251)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(74, 23)
        Me.btnclose.TabIndex = 1
        Me.btnclose.Text = "Schliessen"
        '
        'lblCheckTaxRates
        '
        Me.lblCheckTaxRates.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckTaxRates.Appearance.Options.UseFont = True
        Me.lblCheckTaxRates.Location = New System.Drawing.Point(13, 13)
        Me.lblCheckTaxRates.Name = "lblCheckTaxRates"
        Me.lblCheckTaxRates.Size = New System.Drawing.Size(137, 15)
        Me.lblCheckTaxRates.TabIndex = 2
        Me.lblCheckTaxRates.Text = "Prüfen Sie die Steuersätze:"
        '
        'frmRepairTaxes
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 286)
        Me.Controls.Add(Me.lblCheckTaxRates)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.IucOptionTaxes1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(332, 276)
        Me.Name = "frmRepairTaxes"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Steuersätze reparieren"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IucOptionTaxes1 As ClausSoftware.HWLInterops.iucOptionTaxes
    Friend WithEvents btnclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblCheckTaxRates As DevExpress.XtraEditors.LabelControl
End Class
