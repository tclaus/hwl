<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEasyAddAddress
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
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.lblCompany = New DevExpress.XtraEditors.LabelControl()
        Me.lblContactName = New DevExpress.XtraEditors.LabelControl()
        Me.lblStreet = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCompany = New DevExpress.XtraEditors.TextEdit()
        Me.txtFirstName = New DevExpress.XtraEditors.TextEdit()
        Me.txtStreet = New DevExpress.XtraEditors.TextEdit()
        Me.txtZipCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtTown = New DevExpress.XtraEditors.TextEdit()
        Me.txtLastName = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtCompany.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtFirstName.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtStreet.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtZipCode.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtTown.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtLastName.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(266, 139)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(172, 139)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 27)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        '
        'lblCompany
        '
        Me.lblCompany.Location = New System.Drawing.Point(24, 24)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(26, 13)
        Me.lblCompany.TabIndex = 1
        Me.lblCompany.Text = "Firma"
        '
        'lblContactName
        '
        Me.lblContactName.Location = New System.Drawing.Point(24, 53)
        Me.lblContactName.Name = "lblContactName"
        Me.lblContactName.Size = New System.Drawing.Size(27, 13)
        Me.lblContactName.TabIndex = 1
        Me.lblContactName.Text = "Name"
        '
        'lblStreet
        '
        Me.lblStreet.Location = New System.Drawing.Point(25, 79)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(36, 13)
        Me.lblStreet.TabIndex = 1
        Me.lblStreet.Text = "Strasse"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 105)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 1
        Me.LabelControl4.Text = "PLZ/Ort"
        '
        'txtCompany
        '
        Me.txtCompany.AllowDrop = true
        Me.txtCompany.Location = New System.Drawing.Point(140, 24)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(215, 20)
        Me.txtCompany.TabIndex = 0
        '
        'txtFirstName
        '
        Me.txtFirstName.AllowDrop = true
        Me.txtFirstName.Location = New System.Drawing.Point(140, 50)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(107, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'txtStreet
        '
        Me.txtStreet.AllowDrop = true
        Me.txtStreet.Location = New System.Drawing.Point(140, 76)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(213, 20)
        Me.txtStreet.TabIndex = 2
        '
        'txtZipCode
        '
        Me.txtZipCode.AllowDrop = true
        Me.txtZipCode.Location = New System.Drawing.Point(140, 102)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(57, 20)
        Me.txtZipCode.TabIndex = 3
        '
        'txtTown
        '
        Me.txtTown.AllowDrop = true
        Me.txtTown.Location = New System.Drawing.Point(204, 102)
        Me.txtTown.Name = "txtTown"
        Me.txtTown.Size = New System.Drawing.Size(151, 20)
        Me.txtTown.TabIndex = 4
        '
        'txtLastName
        '
        Me.txtLastName.AllowDrop = true
        Me.txtLastName.Location = New System.Drawing.Point(253, 50)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(102, 20)
        Me.txtLastName.TabIndex = 1
        '
        'frmEasyAddAddress
        '
        Me.AcceptButton = Me.btnOK
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Appearance.Options.UseFont = true
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 15!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(368, 180)
        Me.Controls.Add(Me.txtTown)
        Me.Controls.Add(Me.txtZipCode)
        Me.Controls.Add(Me.txtStreet)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.txtCompany)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.lblStreet)
        Me.Controls.Add(Me.lblContactName)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmEasyAddAddress"
        Me.ShowIcon = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Adresse schnell hinzufügen"
        CType(Me.txtCompany.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtFirstName.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtStreet.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtZipCode.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTown.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtLastName.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblCompany As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblContactName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblStreet As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCompany As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFirstName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtStreet As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtZipCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTown As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLastName As DevExpress.XtraEditors.TextEdit
End Class
