<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnterCompanyCredentials
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
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblUserPassword = New DevExpress.XtraEditors.LabelControl()
        Me.lblUserName = New DevExpress.XtraEditors.LabelControl()
        Me.lblUserID = New DevExpress.XtraEditors.LabelControl()
        Me.txtUserID = New DevExpress.XtraEditors.TextEdit()
        Me.txtUserName = New DevExpress.XtraEditors.TextEdit()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(234, 123)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 27)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(140, 123)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Abbrechen"
        '
        'lblUserPassword
        '
        Me.lblUserPassword.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserPassword.Appearance.Options.UseFont = True
        Me.lblUserPassword.Location = New System.Drawing.Point(14, 88)
        Me.lblUserPassword.Name = "lblUserPassword"
        Me.lblUserPassword.Size = New System.Drawing.Size(47, 15)
        Me.lblUserPassword.TabIndex = 1
        Me.lblUserPassword.Text = "Passwort"
        '
        'lblUserName
        '
        Me.lblUserName.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Appearance.Options.UseFont = True
        Me.lblUserName.Location = New System.Drawing.Point(14, 58)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(71, 15)
        Me.lblUserName.TabIndex = 1
        Me.lblUserName.Text = "Kundenname"
        '
        'lblUserID
        '
        Me.lblUserID.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserID.Appearance.Options.UseFont = True
        Me.lblUserID.Location = New System.Drawing.Point(14, 28)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(87, 15)
        Me.lblUserID.TabIndex = 1
        Me.lblUserID.Text = "Kundennummer"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(127, 24)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Properties.Appearance.Options.UseFont = True
        Me.txtUserID.Size = New System.Drawing.Size(194, 22)
        Me.txtUserID.TabIndex = 2
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(127, 54)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Properties.Appearance.Options.UseFont = True
        Me.txtUserName.Size = New System.Drawing.Size(194, 22)
        Me.txtUserName.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(127, 84)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Properties.Appearance.Options.UseFont = True
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(194, 22)
        Me.txtPassword.TabIndex = 2
        '
        'frmEnterCompanyCredentials
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 163)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.lblUserID)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lblUserPassword)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEnterCompanyCredentials"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Zugangsdaten der Firma"
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblUserPassword As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUserName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUserID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUserID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUserName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
End Class
