<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoginDlg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginDlg))
        Me.lblLoginHeadline = New DevExpress.XtraEditors.LabelControl()
        Me.lblLoginFormMainInstruction = New DevExpress.XtraEditors.LabelControl()
        Me.lblPassword = New DevExpress.XtraEditors.LabelControl()
        Me.lblUserName = New DevExpress.XtraEditors.LabelControl()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtUsername = New DevExpress.XtraEditors.TextEdit()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLoginHeadline
        '
        Me.lblLoginHeadline.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginHeadline.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.lblLoginHeadline.Appearance.Options.UseFont = True
        Me.lblLoginHeadline.Appearance.Options.UseForeColor = True
        Me.lblLoginHeadline.Location = New System.Drawing.Point(12, 10)
        Me.lblLoginHeadline.Name = "lblLoginHeadline"
        Me.lblLoginHeadline.Size = New System.Drawing.Size(84, 23)
        Me.lblLoginHeadline.TabIndex = 4
        Me.lblLoginHeadline.Text = "Anmelden"
        '
        'lblLoginFormMainInstruction
        '
        Me.lblLoginFormMainInstruction.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblLoginFormMainInstruction.Location = New System.Drawing.Point(12, 39)
        Me.lblLoginFormMainInstruction.Name = "lblLoginFormMainInstruction"
        Me.lblLoginFormMainInstruction.Size = New System.Drawing.Size(333, 26)
        Me.lblLoginFormMainInstruction.TabIndex = 3
        Me.lblLoginFormMainInstruction.Text = "Bitte geben Sie Namen und Passwort ein, um sich in {appname} anzumelden."
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(142, 109)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(48, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Passwort:"
        '
        'lblUserName
        '
        Me.lblUserName.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Appearance.Options.UseBackColor = True
        Me.lblUserName.Location = New System.Drawing.Point(117, 83)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(73, 13)
        Me.lblUserName.TabIndex = 2
        Me.lblUserName.Text = "Benutzername:"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(196, 106)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(162, 20)
        Me.txtPassword.TabIndex = 2
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsername.Location = New System.Drawing.Point(196, 80)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(162, 20)
        Me.txtUsername.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(286, 163)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(196, 163)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Symbol_Security_Unlocked_Soft_128x128
        Me.PictureBox1.Location = New System.Drawing.Point(12, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'frmLoginDlg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 198)
        Me.Controls.Add(Me.lblLoginHeadline)
        Me.Controls.Add(Me.lblLoginFormMainInstruction)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoginDlg"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anmelden in {appname}"
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblUserName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPassword As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLoginFormMainInstruction As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLoginHeadline As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
