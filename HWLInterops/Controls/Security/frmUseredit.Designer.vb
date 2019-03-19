<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUseredit
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
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton
        Me.lblForeName = New DevExpress.XtraEditors.LabelControl
        Me.lblFamilyName = New DevExpress.XtraEditors.LabelControl
        Me.txtFirstName = New DevExpress.XtraEditors.TextEdit
        Me.txtSureName = New DevExpress.XtraEditors.TextEdit
        Me.lblLoginName = New DevExpress.XtraEditors.LabelControl
        Me.txtLoginName = New DevExpress.XtraEditors.TextEdit
        Me.lblPassword = New DevExpress.XtraEditors.LabelControl
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit
        Me.lblPassword1 = New DevExpress.XtraEditors.LabelControl
        Me.txtPassword1 = New DevExpress.XtraEditors.TextEdit
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSureName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLoginName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(264, 133)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(264, 162)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'lblForeName
        '
        Me.lblForeName.Location = New System.Drawing.Point(12, 29)
        Me.lblForeName.Name = "lblForeName"
        Me.lblForeName.Size = New System.Drawing.Size(42, 13)
        Me.lblForeName.TabIndex = 1
        Me.lblForeName.Text = "Vorname"
        '
        'lblFamilyName
        '
        Me.lblFamilyName.Location = New System.Drawing.Point(12, 55)
        Me.lblFamilyName.Name = "lblFamilyName"
        Me.lblFamilyName.Size = New System.Drawing.Size(50, 13)
        Me.lblFamilyName.TabIndex = 1
        Me.lblFamilyName.Text = "Nachname"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(92, 26)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(155, 20)
        Me.txtFirstName.TabIndex = 0
        '
        'txtSureName
        '
        Me.txtSureName.Location = New System.Drawing.Point(92, 52)
        Me.txtSureName.Name = "txtSureName"
        Me.txtSureName.Size = New System.Drawing.Size(155, 20)
        Me.txtSureName.TabIndex = 1
        '
        'lblLoginName
        '
        Me.lblLoginName.Location = New System.Drawing.Point(12, 81)
        Me.lblLoginName.Name = "lblLoginName"
        Me.lblLoginName.Size = New System.Drawing.Size(51, 13)
        Me.lblLoginName.TabIndex = 1
        Me.lblLoginName.Text = "Loginname"
        '
        'txtLoginName
        '
        Me.txtLoginName.Location = New System.Drawing.Point(92, 78)
        Me.txtLoginName.Name = "txtLoginName"
        Me.txtLoginName.Size = New System.Drawing.Size(155, 20)
        Me.txtLoginName.TabIndex = 2
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(12, 107)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(51, 13)
        Me.lblPassword.TabIndex = 1
        Me.lblPassword.Text = "Loginname"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(92, 104)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(155, 20)
        Me.txtPassword.TabIndex = 2
        '
        'lblPassword1
        '
        Me.lblPassword1.Location = New System.Drawing.Point(12, 133)
        Me.lblPassword1.Name = "lblPassword1"
        Me.lblPassword1.Size = New System.Drawing.Size(51, 13)
        Me.lblPassword1.TabIndex = 1
        Me.lblPassword1.Text = "Loginname"
        '
        'txtPassword1
        '
        Me.txtPassword1.Location = New System.Drawing.Point(92, 130)
        Me.txtPassword1.Name = "txtPassword1"
        Me.txtPassword1.Size = New System.Drawing.Size(155, 20)
        Me.txtPassword1.TabIndex = 2
        '
        'frmUseredit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 197)
        Me.Controls.Add(Me.txtPassword1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblPassword1)
        Me.Controls.Add(Me.txtLoginName)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.txtSureName)
        Me.Controls.Add(Me.lblLoginName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblFamilyName)
        Me.Controls.Add(Me.lblForeName)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmUseredit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Benutzer bearbeiten"
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSureName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLoginName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblForeName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblFamilyName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFirstName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSureName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblLoginName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtLoginName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPassword As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPassword1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPassword1 As DevExpress.XtraEditors.TextEdit
End Class
