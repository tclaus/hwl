<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUnLock
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
        Me.btnUnlock = New DevExpress.XtraEditors.SimpleButton
        Me.lblEnterUnlockPassword = New DevExpress.XtraEditors.LabelControl
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnUnlock
        '
        Me.btnUnlock.Location = New System.Drawing.Point(193, 70)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(75, 23)
        Me.btnUnlock.TabIndex = 0
        Me.btnUnlock.Text = "Entsperren"
        '
        'lblEnterUnlockPassword
        '
        Me.lblEnterUnlockPassword.Location = New System.Drawing.Point(39, 13)
        Me.lblEnterUnlockPassword.Name = "lblEnterUnlockPassword"
        Me.lblEnterUnlockPassword.Size = New System.Drawing.Size(217, 13)
        Me.lblEnterUnlockPassword.TabIndex = 1
        Me.lblEnterUnlockPassword.Text = "Geben Sie das Passwort zum entsperren ein: "
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(66, 33)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.NullValuePrompt = "Kennwort"
        Me.txtPassword.Size = New System.Drawing.Size(202, 20)
        Me.txtPassword.TabIndex = 2
        '
        'frmUnLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 100)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblEnterUnlockPassword)
        Me.Controls.Add(Me.btnUnlock)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUnLock"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "{appname} entsperren"
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUnlock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblEnterUnlockPassword As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
End Class
