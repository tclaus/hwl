
Namespace Update
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDownloadProgress
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
            Me.lblDownloadProgress = New DevExpress.XtraEditors.LabelControl
            Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl
            CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblDownloadProgress
            '
            Me.lblDownloadProgress.Location = New System.Drawing.Point(84, 26)
            Me.lblDownloadProgress.Name = "lblDownloadProgress"
            Me.lblDownloadProgress.Size = New System.Drawing.Size(42, 13)
            Me.lblDownloadProgress.TabIndex = 1
            Me.lblDownloadProgress.Text = "Progress"
            '
            'ProgressBarControl1
            '
            Me.ProgressBarControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ProgressBarControl1.Location = New System.Drawing.Point(1, 2)
            Me.ProgressBarControl1.Name = "ProgressBarControl1"
            Me.ProgressBarControl1.Properties.ShowTitle = True
            Me.ProgressBarControl1.Size = New System.Drawing.Size(226, 18)
            Me.ProgressBarControl1.TabIndex = 2
            '
            'frmDownloadProgress
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(228, 44)
            Me.Controls.Add(Me.ProgressBarControl1)
            Me.Controls.Add(Me.lblDownloadProgress)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "frmDownloadProgress"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Update laden..."
            CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lblDownloadProgress As DevExpress.XtraEditors.LabelControl
        Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    End Class


End Namespace