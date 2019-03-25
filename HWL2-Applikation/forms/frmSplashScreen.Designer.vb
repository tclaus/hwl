<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSplashScreen
    Inherits ClausSoftware.HWLInterops.BaseForm


    Friend WithEvents lblApplicationTitle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblStatusMessage As System.Windows.Forms.Label
    Friend WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mpcSplash = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblStatusMessage = New System.Windows.Forms.Label()
        Me.lblcopyrightCompany = New DevExpress.XtraEditors.LabelControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.lblCompanywebAddress = New DevExpress.XtraEditors.LabelControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureEdit4 = New DevExpress.XtraEditors.PictureEdit()
        Me.PictureEdit3 = New DevExpress.XtraEditors.PictureEdit()
        Me.PictureEdit2 = New DevExpress.XtraEditors.PictureEdit()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.lblSplashReports = New DevExpress.XtraEditors.LabelControl()
        Me.lblSplashTransactions = New DevExpress.XtraEditors.LabelControl()
        Me.lblSplashBills = New DevExpress.XtraEditors.LabelControl()
        Me.lblSplashAdresses = New DevExpress.XtraEditors.LabelControl()
        Me.lblApplicationTitle = New System.Windows.Forms.Label()
        Me.MainLayoutPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.mpcSplash.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainLayoutPanel
        '
        Me.MainLayoutPanel.BackColor = System.Drawing.Color.White
        Me.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MainLayoutPanel.ColumnCount = 2
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 364.0!))
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380.0!))
        Me.MainLayoutPanel.Controls.Add(Me.Panel1, 1, 0)
        Me.MainLayoutPanel.Controls.Add(Me.lblcopyrightCompany, 0, 1)
        Me.MainLayoutPanel.Controls.Add(Me.Panel2, 1, 1)
        Me.MainLayoutPanel.Controls.Add(Me.Panel3, 0, 0)
        Me.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainLayoutPanel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MainLayoutPanel.Name = "MainLayoutPanel"
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 319.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.MainLayoutPanel.Size = New System.Drawing.Size(744, 443)
        Me.MainLayoutPanel.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.mpcSplash)
        Me.Panel1.Controls.Add(Me.ProgressBarControl1)
        Me.Panel1.Controls.Add(Me.lblVersion)
        Me.Panel1.Controls.Add(Me.lblStatusMessage)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(368, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(372, 311)
        Me.Panel1.TabIndex = 2
        '
        'mpcSplash
        '
        Me.mpcSplash.EditValue = 0
        Me.mpcSplash.Location = New System.Drawing.Point(9, 279)
        Me.mpcSplash.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.mpcSplash.Name = "mpcSplash"
        Me.mpcSplash.Size = New System.Drawing.Size(357, 26)
        Me.mpcSplash.TabIndex = 4
        Me.mpcSplash.Tag = "DontTranslate"
        Me.mpcSplash.Visible = False
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(9, 279)
        Me.ProgressBarControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Size = New System.Drawing.Size(357, 26)
        Me.ProgressBarControl1.TabIndex = 3
        Me.ProgressBarControl1.Visible = False
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(0, 0)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(372, 22)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Tag = "DontTranslate"
        Me.lblVersion.Text = "Version {0}.{1}.{2}.{3}"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblStatusMessage
        '
        Me.lblStatusMessage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblStatusMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusMessage.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusMessage.Location = New System.Drawing.Point(13, 218)
        Me.lblStatusMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatusMessage.Name = "lblStatusMessage"
        Me.lblStatusMessage.Size = New System.Drawing.Size(345, 57)
        Me.lblStatusMessage.TabIndex = 2
        Me.lblStatusMessage.Text = "Start..."
        '
        'lblcopyrightCompany
        '
        Me.lblcopyrightCompany.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcopyrightCompany.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lblcopyrightCompany.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblcopyrightCompany.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblcopyrightCompany.Location = New System.Drawing.Point(4, 323)
        Me.lblcopyrightCompany.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblcopyrightCompany.Name = "lblcopyrightCompany"
        Me.lblcopyrightCompany.Padding = New System.Windows.Forms.Padding(38, 15, 0, 0)
        Me.lblcopyrightCompany.Size = New System.Drawing.Size(356, 115)
        Me.lblcopyrightCompany.TabIndex = 4
        Me.lblcopyrightCompany.Tag = "DontTranslate"
        Me.lblcopyrightCompany.Text = "Claus-Software " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Thorsten Claus" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Gibbenhey 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "44227 Dortmund"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.lblCompanywebAddress)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(364, 319)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(380, 124)
        Me.Panel2.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(249, 73)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(112, 34)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Schliessen"
        Me.btnClose.Visible = False
        '
        'lblCompanywebAddress
        '
        Me.lblCompanywebAddress.AllowHtmlString = True
        Me.lblCompanywebAddress.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanywebAddress.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCompanywebAddress.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCompanywebAddress.Location = New System.Drawing.Point(4, 50)
        Me.lblCompanywebAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblCompanywebAddress.Name = "lblCompanywebAddress"
        Me.lblCompanywebAddress.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
        Me.lblCompanywebAddress.Size = New System.Drawing.Size(226, 28)
        Me.lblCompanywebAddress.TabIndex = 7
        Me.lblCompanywebAddress.Tag = "donttranslate"
        Me.lblCompanywebAddress.Text = "http://claus-software.de"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PictureEdit4)
        Me.Panel3.Controls.Add(Me.PictureEdit3)
        Me.Panel3.Controls.Add(Me.PictureEdit2)
        Me.Panel3.Controls.Add(Me.PictureEdit1)
        Me.Panel3.Controls.Add(Me.lblSplashReports)
        Me.Panel3.Controls.Add(Me.lblSplashTransactions)
        Me.Panel3.Controls.Add(Me.lblSplashBills)
        Me.Panel3.Controls.Add(Me.lblSplashAdresses)
        Me.Panel3.Controls.Add(Me.lblApplicationTitle)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(4, 4)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(356, 311)
        Me.Panel3.TabIndex = 6
        '
        'PictureEdit4
        '
        Me.PictureEdit4.Location = New System.Drawing.Point(34, 218)
        Me.PictureEdit4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureEdit4.Name = "PictureEdit4"
        Me.PictureEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit4.Size = New System.Drawing.Size(45, 44)
        Me.PictureEdit4.TabIndex = 2
        '
        'PictureEdit3
        '
        Me.PictureEdit3.Location = New System.Drawing.Point(34, 174)
        Me.PictureEdit3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureEdit3.Name = "PictureEdit3"
        Me.PictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit3.Size = New System.Drawing.Size(45, 44)
        Me.PictureEdit3.TabIndex = 2
        '
        'PictureEdit2
        '
        Me.PictureEdit2.Location = New System.Drawing.Point(34, 129)
        Me.PictureEdit2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureEdit2.Name = "PictureEdit2"
        Me.PictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit2.Size = New System.Drawing.Size(45, 44)
        Me.PictureEdit2.TabIndex = 2
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Location = New System.Drawing.Point(34, 83)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Size = New System.Drawing.Size(45, 44)
        Me.PictureEdit1.TabIndex = 2
        '
        'lblSplashReports
        '
        Me.lblSplashReports.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSplashReports.Location = New System.Drawing.Point(88, 227)
        Me.lblSplashReports.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblSplashReports.Name = "lblSplashReports"
        Me.lblSplashReports.Size = New System.Drawing.Size(153, 29)
        Me.lblSplashReports.TabIndex = 1
        Me.lblSplashReports.Text = "Auswertungen"
        '
        'lblSplashTransactions
        '
        Me.lblSplashTransactions.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSplashTransactions.Location = New System.Drawing.Point(88, 183)
        Me.lblSplashTransactions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblSplashTransactions.Name = "lblSplashTransactions"
        Me.lblSplashTransactions.Size = New System.Drawing.Size(205, 29)
        Me.lblSplashTransactions.TabIndex = 1
        Me.lblSplashTransactions.Text = "Geschäftsprozesse"
        '
        'lblSplashBills
        '
        Me.lblSplashBills.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSplashBills.Location = New System.Drawing.Point(88, 137)
        Me.lblSplashBills.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblSplashBills.Name = "lblSplashBills"
        Me.lblSplashBills.Size = New System.Drawing.Size(247, 29)
        Me.lblSplashBills.TabIndex = 1
        Me.lblSplashBills.Text = "Angebote/Rechnungen"
        '
        'lblSplashAdresses
        '
        Me.lblSplashAdresses.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSplashAdresses.Location = New System.Drawing.Point(88, 92)
        Me.lblSplashAdresses.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblSplashAdresses.Name = "lblSplashAdresses"
        Me.lblSplashAdresses.Size = New System.Drawing.Size(102, 29)
        Me.lblSplashAdresses.TabIndex = 1
        Me.lblSplashAdresses.Text = "Adressen"
        '
        'lblApplicationTitle
        '
        Me.lblApplicationTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblApplicationTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblApplicationTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApplicationTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblApplicationTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblApplicationTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblApplicationTitle.Name = "lblApplicationTitle"
        Me.lblApplicationTitle.Size = New System.Drawing.Size(356, 58)
        Me.lblApplicationTitle.TabIndex = 0
        Me.lblApplicationTitle.Tag = "DontTranslate"
        Me.lblApplicationTitle.Text = "{AppName}"
        Me.lblApplicationTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'frmSplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 443)
        Me.ControlBox = False
        Me.Controls.Add(Me.MainLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplashScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MainLayoutPanel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.mpcSplash.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents mpcSplash As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents lblcopyrightCompany As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCompanywebAddress As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureEdit4 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PictureEdit3 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PictureEdit2 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblSplashReports As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSplashTransactions As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSplashBills As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSplashAdresses As DevExpress.XtraEditors.LabelControl

End Class
