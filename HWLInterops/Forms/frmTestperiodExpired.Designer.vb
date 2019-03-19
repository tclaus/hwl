<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestperiodExpired
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTestperiodExpired))
        Me.btnLater = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLicenses = New DevExpress.XtraEditors.SimpleButton()
        Me.lblProductActivation = New DevExpress.XtraEditors.LabelControl()
        Me.lblActivationText = New DevExpress.XtraEditors.LabelControl()
        Me.lblContact = New DevExpress.XtraEditors.LabelControl()
        Me.lblCompanywebAddress = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'btnLater
        '
        Me.btnLater.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLater.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLater.Appearance.Options.UseFont = True
        Me.btnLater.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLater.Location = New System.Drawing.Point(359, 316)
        Me.btnLater.Name = "btnLater"
        Me.btnLater.Size = New System.Drawing.Size(87, 27)
        Me.btnLater.TabIndex = 0
        Me.btnLater.Text = "Später"
        '
        'btnLicenses
        '
        Me.btnLicenses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLicenses.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLicenses.Appearance.Options.UseFont = True
        Me.btnLicenses.Location = New System.Drawing.Point(265, 316)
        Me.btnLicenses.Name = "btnLicenses"
        Me.btnLicenses.Size = New System.Drawing.Size(87, 27)
        Me.btnLicenses.TabIndex = 0
        Me.btnLicenses.Text = "Lizenzen..."
        '
        'lblProductActivation
        '
        Me.lblProductActivation.Appearance.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductActivation.Appearance.Options.UseFont = True
        Me.lblProductActivation.Appearance.Options.UseTextOptions = True
        Me.lblProductActivation.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblProductActivation.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lblProductActivation.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblProductActivation.Location = New System.Drawing.Point(64, 31)
        Me.lblProductActivation.Name = "lblProductActivation"
        Me.lblProductActivation.Size = New System.Drawing.Size(332, 48)
        Me.lblProductActivation.TabIndex = 1
        Me.lblProductActivation.Text = "Produktaktivierung"
        '
        'lblActivationText
        '
        Me.lblActivationText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivationText.Appearance.Options.UseFont = True
        Me.lblActivationText.Location = New System.Drawing.Point(14, 98)
        Me.lblActivationText.Name = "lblActivationText"
        Me.lblActivationText.Size = New System.Drawing.Size(383, 75)
        Me.lblActivationText.TabIndex = 1
        Me.lblActivationText.Tag = ""
        Me.lblActivationText.Text = resources.GetString("lblActivationText.Text")
        '
        'lblContact
        '
        Me.lblContact.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContact.Appearance.Options.UseFont = True
        Me.lblContact.Location = New System.Drawing.Point(14, 256)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(88, 60)
        Me.lblContact.TabIndex = 1
        Me.lblContact.Tag = "DontTranslate"
        Me.lblContact.Text = "Thorsten Claus" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DortuStrasse 15" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "44357 Dortmund" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblCompanywebAddress
        '
        Me.lblCompanywebAddress.AllowHtmlString = True
        Me.lblCompanywebAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompanywebAddress.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanywebAddress.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCompanywebAddress.Appearance.Options.UseFont = True
        Me.lblCompanywebAddress.Appearance.Options.UseForeColor = True
        Me.lblCompanywebAddress.Appearance.Options.UseTextOptions = True
        Me.lblCompanywebAddress.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.lblCompanywebAddress.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCompanywebAddress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCompanywebAddress.Location = New System.Drawing.Point(224, 274)
        Me.lblCompanywebAddress.Name = "lblCompanywebAddress"
        Me.lblCompanywebAddress.Padding = New System.Windows.Forms.Padding(14, 0, 0, 0)
        Me.lblCompanywebAddress.Size = New System.Drawing.Size(222, 18)
        Me.lblCompanywebAddress.TabIndex = 8
        Me.lblCompanywebAddress.Tag = "donttranslate"
        Me.lblCompanywebAddress.Text = "http://www.claus-software.de"
        '
        'frmTestperiodExpired
        '
        Me.AcceptButton = Me.btnLater
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnLater
        Me.ClientSize = New System.Drawing.Size(461, 357)
        Me.Controls.Add(Me.lblCompanywebAddress)
        Me.Controls.Add(Me.lblContact)
        Me.Controls.Add(Me.lblActivationText)
        Me.Controls.Add(Me.lblProductActivation)
        Me.Controls.Add(Me.btnLicenses)
        Me.Controls.Add(Me.btnLater)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTestperiodExpired"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "{AppName} Licenses"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLater As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLicenses As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblProductActivation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblActivationText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblContact As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCompanywebAddress As DevExpress.XtraEditors.LabelControl
End Class
