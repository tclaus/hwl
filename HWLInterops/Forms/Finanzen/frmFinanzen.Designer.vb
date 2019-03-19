<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFinanzen
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
        Me.btnCashFlow = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'btnCashFlow
        '
        Me.btnCashFlow.Location = New System.Drawing.Point(12, 12)
        Me.btnCashFlow.Name = "btnCashFlow"
        Me.btnCashFlow.Size = New System.Drawing.Size(118, 32)
        Me.btnCashFlow.TabIndex = 0
        Me.btnCashFlow.Text = "Finanzstatus"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(184, 143)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Schliessen"
        '
        'frmFinanzen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(271, 178)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCashFlow)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFinanzen"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Auswertungen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCashFlow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
End Class
