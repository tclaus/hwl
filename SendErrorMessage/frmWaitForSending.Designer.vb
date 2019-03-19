<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWaitForSending
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
        Me.MarqueeProgressBarControl1 = New DevExpress.XtraEditors.MarqueeProgressBarControl
        Me.lblSendingErrorInProgress = New DevExpress.XtraEditors.LabelControl
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MarqueeProgressBarControl1
        '
        Me.MarqueeProgressBarControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MarqueeProgressBarControl1.Location = New System.Drawing.Point(22, 34)
        Me.MarqueeProgressBarControl1.Name = "MarqueeProgressBarControl1"
        Me.MarqueeProgressBarControl1.Properties.LookAndFeel.UseWindowsXPTheme = True
        Me.MarqueeProgressBarControl1.Size = New System.Drawing.Size(259, 18)
        Me.MarqueeProgressBarControl1.TabIndex = 0
        '
        'lblSendingErrorInProgress
        '
        Me.lblSendingErrorInProgress.Location = New System.Drawing.Point(22, 12)
        Me.lblSendingErrorInProgress.Name = "lblSendingErrorInProgress"
        Me.lblSendingErrorInProgress.Size = New System.Drawing.Size(114, 13)
        Me.lblSendingErrorInProgress.TabIndex = 1
        Me.lblSendingErrorInProgress.Text = "Sende Fehlerbereicht..."
        '
        'frmWaitForSending
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 73)
        Me.Controls.Add(Me.lblSendingErrorInProgress)
        Me.Controls.Add(Me.MarqueeProgressBarControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmWaitForSending"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Senden..."
        CType(Me.MarqueeProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MarqueeProgressBarControl1 As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents lblSendingErrorInProgress As DevExpress.XtraEditors.LabelControl
End Class
