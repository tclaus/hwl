<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInstallWizzard
    Inherits ClausSoftware.HWLInterops.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstallWizzard))
        Me.WizardControl1 = New DevExpress.XtraWizard.WizardControl()
        Me.WelcomeWizardPage1 = New DevExpress.XtraWizard.WelcomeWizardPage()
        Me.btnDefaultSimpleInstallation = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCustomInstallation = New DevExpress.XtraEditors.SimpleButton()
        Me.lblwizzardWelcome = New DevExpress.XtraEditors.LabelControl()
        Me.wizCompleted = New DevExpress.XtraWizard.CompletionWizardPage()
        Me.picWizzardFinish = New DevExpress.XtraEditors.PictureEdit()
        Me.lblInstallWizzardFinishedText = New DevExpress.XtraEditors.LabelControl()
        Me.wizSelectDatabaseTarget = New DevExpress.XtraWizard.WizardPage()
        Me.radDatabaseSelect = New DevExpress.XtraEditors.RadioGroup()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblHeadlineFirstInstall = New DevExpress.XtraEditors.LabelControl()
        Me.wizSelectExistingDatabase = New DevExpress.XtraWizard.WizardPage()
        Me.lblDatabaseSelctionDescription = New DevExpress.XtraEditors.LabelControl()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.IucOptionConnections1 = New ClausSoftware.HWLInterops.iucOptionConnections()
        Me.wizTaxes = New DevExpress.XtraWizard.WizardPage()
        Me.lblHelpTaxRateswizzard = New DevExpress.XtraEditors.LabelControl()
        Me.picTaxRates = New DevExpress.XtraEditors.PictureEdit()
        Me.chkShowInvoiceswithVATIncluded = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowVATInInvoices = New DevExpress.XtraEditors.CheckEdit()
        Me.lblCountryCodeTaxRates = New DevExpress.XtraEditors.LabelControl()
        Me.btnedit = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTaxDataOK = New DevExpress.XtraEditors.LabelControl()
        Me.lstTaxData = New DevExpress.XtraEditors.ListBoxControl()
        CType(Me.WizardControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WizardControl1.SuspendLayout()
        Me.WelcomeWizardPage1.SuspendLayout()
        Me.wizCompleted.SuspendLayout()
        CType(Me.picWizzardFinish.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wizSelectDatabaseTarget.SuspendLayout()
        CType(Me.radDatabaseSelect.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wizSelectExistingDatabase.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wizTaxes.SuspendLayout()
        CType(Me.picTaxRates.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowInvoiceswithVATIncluded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowVATInInvoices.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstTaxData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WizardControl1
        '
        Me.WizardControl1.Appearance.ExteriorPage.BackColor = System.Drawing.Color.Red
        Me.WizardControl1.Appearance.ExteriorPage.Options.UseBackColor = True
        Me.WizardControl1.Appearance.ExteriorPageTitle.BackColor = System.Drawing.Color.Red
        Me.WizardControl1.Appearance.ExteriorPageTitle.Options.UseBackColor = True
        Me.WizardControl1.Appearance.Page.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.WizardControl1.Appearance.Page.BackColor2 = System.Drawing.Color.Lavender
        Me.WizardControl1.Appearance.Page.BorderColor = System.Drawing.Color.Transparent
        Me.WizardControl1.Appearance.Page.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.WizardControl1.Appearance.Page.Options.UseBackColor = True
        Me.WizardControl1.Appearance.Page.Options.UseBorderColor = True
        Me.WizardControl1.Controls.Add(Me.WelcomeWizardPage1)
        Me.WizardControl1.Controls.Add(Me.wizCompleted)
        Me.WizardControl1.Controls.Add(Me.wizSelectDatabaseTarget)
        Me.WizardControl1.Controls.Add(Me.wizSelectExistingDatabase)
        Me.WizardControl1.Controls.Add(Me.wizTaxes)
        Me.WizardControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WizardControl1.FinishText = "Fertig"
        Me.WizardControl1.HeaderImage = Global.ClausSoftware.GUI.My.Resources.Resources.Forms1
        Me.WizardControl1.Image = Global.ClausSoftware.GUI.My.Resources.Resources.Forms
        Me.WizardControl1.ImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.WizardControl1.Location = New System.Drawing.Point(0, 0)
        Me.WizardControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WizardControl1.Name = "WizardControl1"
        Me.WizardControl1.Pages.AddRange(New DevExpress.XtraWizard.BaseWizardPage() {Me.WelcomeWizardPage1, Me.wizSelectDatabaseTarget, Me.wizSelectExistingDatabase, Me.wizTaxes, Me.wizCompleted})
        Me.WizardControl1.Size = New System.Drawing.Size(881, 787)
        Me.WizardControl1.Text = "{appname} Ersteinrichtung"
        Me.WizardControl1.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero
        '
        'WelcomeWizardPage1
        '
        Me.WelcomeWizardPage1.AllowBack = False
        Me.WelcomeWizardPage1.AllowNext = False
        Me.WelcomeWizardPage1.Controls.Add(Me.btnDefaultSimpleInstallation)
        Me.WelcomeWizardPage1.Controls.Add(Me.btnCustomInstallation)
        Me.WelcomeWizardPage1.Controls.Add(Me.lblwizzardWelcome)
        Me.WelcomeWizardPage1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.WelcomeWizardPage1.Name = "WelcomeWizardPage1"
        Me.WelcomeWizardPage1.Size = New System.Drawing.Size(821, 592)
        Me.WelcomeWizardPage1.Text = "Wählen Sie die Art der Einrichtung"
        '
        'btnDefaultSimpleInstallation
        '
        Me.btnDefaultSimpleInstallation.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDefaultSimpleInstallation.Appearance.Options.UseFont = True
        Me.btnDefaultSimpleInstallation.Appearance.Options.UseTextOptions = True
        Me.btnDefaultSimpleInstallation.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnDefaultSimpleInstallation.Location = New System.Drawing.Point(284, 193)
        Me.btnDefaultSimpleInstallation.LookAndFeel.SkinName = "Money Twins"
        Me.btnDefaultSimpleInstallation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDefaultSimpleInstallation.Name = "btnDefaultSimpleInstallation"
        Me.btnDefaultSimpleInstallation.Size = New System.Drawing.Size(231, 70)
        ToolTipTitleItem1.Text = "Standard"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Falls dies Ihre erste {appname} Installation ist."
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.btnDefaultSimpleInstallation.SuperTip = SuperToolTip1
        Me.btnDefaultSimpleInstallation.TabIndex = 1
        Me.btnDefaultSimpleInstallation.Text = "Standardinstallation"
        '
        'btnCustomInstallation
        '
        Me.btnCustomInstallation.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomInstallation.Appearance.Options.UseFont = True
        Me.btnCustomInstallation.Appearance.Options.UseTextOptions = True
        Me.btnCustomInstallation.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnCustomInstallation.Location = New System.Drawing.Point(284, 313)
        Me.btnCustomInstallation.LookAndFeel.SkinName = "Money Twins"
        Me.btnCustomInstallation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCustomInstallation.Name = "btnCustomInstallation"
        Me.btnCustomInstallation.Size = New System.Drawing.Size(231, 103)
        ToolTipTitleItem2.Text = "Angepasst"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Erlaubt das Auswählen der Programmdatenbank, sowie der Steuerstätze"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.btnCustomInstallation.SuperTip = SuperToolTip2
        Me.btnCustomInstallation.TabIndex = 1
        Me.btnCustomInstallation.Text = "Angepasste Installation"
        '
        'lblwizzardWelcome
        '
        Me.lblwizzardWelcome.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblwizzardWelcome.Location = New System.Drawing.Point(101, 42)
        Me.lblwizzardWelcome.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblwizzardWelcome.Name = "lblwizzardWelcome"
        Me.lblwizzardWelcome.Size = New System.Drawing.Size(613, 140)
        Me.lblwizzardWelcome.TabIndex = 0
        Me.lblwizzardWelcome.Text = "Sie werden nun durch die Ersteinrichtung von {AppName} geführt." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dazu ist es nöti" &
    "g, die Art und Weise der Datenspeicherung festzulegen, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sowie ihre Steuersätze " &
    "zu überprüfen." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'wizCompleted
        '
        Me.wizCompleted.Controls.Add(Me.picWizzardFinish)
        Me.wizCompleted.Controls.Add(Me.lblInstallWizzardFinishedText)
        Me.wizCompleted.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.wizCompleted.Name = "wizCompleted"
        Me.wizCompleted.Size = New System.Drawing.Size(821, 592)
        Me.wizCompleted.Text = "Fertigstellen."
        '
        'picWizzardFinish
        '
        Me.picWizzardFinish.EditValue = Global.ClausSoftware.GUI.My.Resources.Resources.signal_flag_checkered_LowContrast_128x128
        Me.picWizzardFinish.Location = New System.Drawing.Point(249, 163)
        Me.picWizzardFinish.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picWizzardFinish.Name = "picWizzardFinish"
        Me.picWizzardFinish.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picWizzardFinish.Properties.Appearance.Options.UseBackColor = True
        Me.picWizzardFinish.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picWizzardFinish.Size = New System.Drawing.Size(269, 278)
        Me.picWizzardFinish.TabIndex = 1
        '
        'lblInstallWizzardFinishedText
        '
        Me.lblInstallWizzardFinishedText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstallWizzardFinishedText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblInstallWizzardFinishedText.Location = New System.Drawing.Point(47, 30)
        Me.lblInstallWizzardFinishedText.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblInstallWizzardFinishedText.Name = "lblInstallWizzardFinishedText"
        Me.lblInstallWizzardFinishedText.Size = New System.Drawing.Size(719, 75)
        Me.lblInstallWizzardFinishedText.TabIndex = 0
        Me.lblInstallWizzardFinishedText.Text = "{appname} ist nun bereit für den ersten Start." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nun wird die Datenbank für den St" &
    "art vorbereitet, danach können Sie sofort mit {appname} beginnen zu arbeiten." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'wizSelectDatabaseTarget
        '
        Me.wizSelectDatabaseTarget.Controls.Add(Me.radDatabaseSelect)
        Me.wizSelectDatabaseTarget.Controls.Add(Me.PictureBox1)
        Me.wizSelectDatabaseTarget.Controls.Add(Me.lblHeadlineFirstInstall)
        Me.wizSelectDatabaseTarget.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.wizSelectDatabaseTarget.Name = "wizSelectDatabaseTarget"
        Me.wizSelectDatabaseTarget.Size = New System.Drawing.Size(821, 592)
        Me.wizSelectDatabaseTarget.Text = "Wählen Sie einen Speicherort für Ihre Daten aus"
        '
        'radDatabaseSelect
        '
        Me.radDatabaseSelect.EditValue = 1
        Me.radDatabaseSelect.Location = New System.Drawing.Point(114, 172)
        Me.radDatabaseSelect.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.radDatabaseSelect.Name = "radDatabaseSelect"
        Me.radDatabaseSelect.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.radDatabaseSelect.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDatabaseSelect.Properties.Appearance.Options.UseBackColor = True
        Me.radDatabaseSelect.Properties.Appearance.Options.UseFont = True
        Me.radDatabaseSelect.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.radDatabaseSelect.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Auf diesem Computer eine neue Datenbank anlegen"), New DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Mit einer bereits bestehenden Datenbank verbinden")})
        Me.radDatabaseSelect.Size = New System.Drawing.Size(519, 138)
        Me.radDatabaseSelect.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.ClausSoftware.GUI.My.Resources.Resources.Forms1
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'lblHeadlineFirstInstall
        '
        Me.lblHeadlineFirstInstall.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadlineFirstInstall.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lblHeadlineFirstInstall.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblHeadlineFirstInstall.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblHeadlineFirstInstall.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblHeadlineFirstInstall.Location = New System.Drawing.Point(114, 7)
        Me.lblHeadlineFirstInstall.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblHeadlineFirstInstall.Name = "lblHeadlineFirstInstall"
        Me.lblHeadlineFirstInstall.Size = New System.Drawing.Size(573, 125)
        Me.lblHeadlineFirstInstall.TabIndex = 3
        Me.lblHeadlineFirstInstall.Text = resources.GetString("lblHeadlineFirstInstall.Text")
        '
        'wizSelectExistingDatabase
        '
        Me.wizSelectExistingDatabase.Controls.Add(Me.lblDatabaseSelctionDescription)
        Me.wizSelectExistingDatabase.Controls.Add(Me.PictureBox2)
        Me.wizSelectExistingDatabase.Controls.Add(Me.IucOptionConnections1)
        Me.wizSelectExistingDatabase.DescriptionText = "Wählen sie eine Datenbankverbindung aus oder erstellen Sie eine neue Verbindung z" &
    "u einer existierenden Datenbank."
        Me.wizSelectExistingDatabase.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.wizSelectExistingDatabase.Name = "wizSelectExistingDatabase"
        Me.wizSelectExistingDatabase.Size = New System.Drawing.Size(821, 592)
        Me.wizSelectExistingDatabase.Text = "Datenbank Auswahl"
        '
        'lblDatabaseSelctionDescription
        '
        Me.lblDatabaseSelctionDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabaseSelctionDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblDatabaseSelctionDescription.Location = New System.Drawing.Point(114, 20)
        Me.lblDatabaseSelctionDescription.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblDatabaseSelctionDescription.Name = "lblDatabaseSelctionDescription"
        Me.lblDatabaseSelctionDescription.Size = New System.Drawing.Size(576, 100)
        Me.lblDatabaseSelctionDescription.TabIndex = 2
        Me.lblDatabaseSelctionDescription.Text = "Wählen Sie eine bestehende Datenbankverbindung aus. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sollte noch keine Verbindun" &
    "g bestehen, so können sie einfach eine Anlegen." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Wählen Sie dann Ihre Standard-V" &
    "erbindung aus."
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.ClausSoftware.GUI.My.Resources.Resources.Network_Harddisk72x72
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'IucOptionConnections1
        '
        Me.IucOptionConnections1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.IucOptionConnections1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IucOptionConnections1.Appearance.Options.UseBackColor = True
        Me.IucOptionConnections1.Appearance.Options.UseFont = True
        Me.IucOptionConnections1.Location = New System.Drawing.Point(137, 158)
        Me.IucOptionConnections1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.IucOptionConnections1.Name = "IucOptionConnections1"
        Me.IucOptionConnections1.ShowDatabaseOptions = True
        Me.IucOptionConnections1.Size = New System.Drawing.Size(553, 258)
        Me.IucOptionConnections1.TabIndex = 0
        '
        'wizTaxes
        '
        Me.wizTaxes.Controls.Add(Me.lblHelpTaxRateswizzard)
        Me.wizTaxes.Controls.Add(Me.picTaxRates)
        Me.wizTaxes.Controls.Add(Me.chkShowInvoiceswithVATIncluded)
        Me.wizTaxes.Controls.Add(Me.chkShowVATInInvoices)
        Me.wizTaxes.Controls.Add(Me.lblCountryCodeTaxRates)
        Me.wizTaxes.Controls.Add(Me.btnedit)
        Me.wizTaxes.Controls.Add(Me.lblTaxDataOK)
        Me.wizTaxes.Controls.Add(Me.lstTaxData)
        Me.wizTaxes.DescriptionText = "Wählen Sie Ihre Steuerzone aus. "
        Me.wizTaxes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.wizTaxes.Name = "wizTaxes"
        Me.wizTaxes.Size = New System.Drawing.Size(821, 592)
        Me.wizTaxes.Text = "Steuerdaten auswählen"
        '
        'lblHelpTaxRateswizzard
        '
        Me.lblHelpTaxRateswizzard.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelpTaxRateswizzard.Appearance.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblHelpTaxRateswizzard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblHelpTaxRateswizzard.Location = New System.Drawing.Point(190, 422)
        Me.lblHelpTaxRateswizzard.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblHelpTaxRateswizzard.Name = "lblHelpTaxRateswizzard"
        Me.lblHelpTaxRateswizzard.Size = New System.Drawing.Size(171, 25)
        Me.lblHelpTaxRateswizzard.TabIndex = 6
        Me.lblHelpTaxRateswizzard.Text = "Hilfe zu Steuerdaten..."
        '
        'picTaxRates
        '
        Me.picTaxRates.EditValue = Global.ClausSoftware.GUI.My.Resources.Resources.Symbol_Help_16x16
        Me.picTaxRates.Location = New System.Drawing.Point(137, 410)
        Me.picTaxRates.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.picTaxRates.Name = "picTaxRates"
        Me.picTaxRates.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picTaxRates.Properties.Appearance.Options.UseBackColor = True
        Me.picTaxRates.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picTaxRates.Size = New System.Drawing.Size(41, 50)
        Me.picTaxRates.TabIndex = 5
        '
        'chkShowInvoiceswithVATIncluded
        '
        Me.chkShowInvoiceswithVATIncluded.Location = New System.Drawing.Point(166, 352)
        Me.chkShowInvoiceswithVATIncluded.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkShowInvoiceswithVATIncluded.Name = "chkShowInvoiceswithVATIncluded"
        Me.chkShowInvoiceswithVATIncluded.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowInvoiceswithVATIncluded.Properties.Appearance.Options.UseFont = True
        Me.chkShowInvoiceswithVATIncluded.Properties.Caption = "In Rechnungen Nettopreise zuzüglich Steuern anzeigen"
        Me.chkShowInvoiceswithVATIncluded.Size = New System.Drawing.Size(574, 30)
        Me.chkShowInvoiceswithVATIncluded.TabIndex = 4
        '
        'chkShowVATInInvoices
        '
        Me.chkShowVATInInvoices.Location = New System.Drawing.Point(140, 308)
        Me.chkShowVATInInvoices.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkShowVATInInvoices.Name = "chkShowVATInInvoices"
        Me.chkShowVATInInvoices.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowVATInInvoices.Properties.Appearance.Options.UseFont = True
        Me.chkShowVATInInvoices.Properties.Caption = "In Rechnungen Steuern ausweisen"
        Me.chkShowVATInInvoices.Size = New System.Drawing.Size(437, 30)
        Me.chkShowVATInInvoices.TabIndex = 4
        '
        'lblCountryCodeTaxRates
        '
        Me.lblCountryCodeTaxRates.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountryCodeTaxRates.Location = New System.Drawing.Point(140, 123)
        Me.lblCountryCodeTaxRates.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblCountryCodeTaxRates.Name = "lblCountryCodeTaxRates"
        Me.lblCountryCodeTaxRates.Size = New System.Drawing.Size(203, 25)
        Me.lblCountryCodeTaxRates.TabIndex = 3
        Me.lblCountryCodeTaxRates.Tag = "DontTranslate"
        Me.lblCountryCodeTaxRates.Text = "<Ländername für Steuer>"
        '
        'btnedit
        '
        Me.btnedit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.Appearance.Options.UseFont = True
        Me.btnedit.Enabled = False
        Me.btnedit.Location = New System.Drawing.Point(453, 162)
        Me.btnedit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(124, 45)
        Me.btnedit.TabIndex = 2
        Me.btnedit.Text = "Bearbeiten..."
        Me.btnedit.Visible = False
        '
        'lblTaxDataOK
        '
        Me.lblTaxDataOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxDataOK.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblTaxDataOK.Location = New System.Drawing.Point(74, 13)
        Me.lblTaxDataOK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lblTaxDataOK.Name = "lblTaxDataOK"
        Me.lblTaxDataOK.Size = New System.Drawing.Size(471, 25)
        Me.lblTaxDataOK.TabIndex = 1
        Me.lblTaxDataOK.Text = "Sind diese Steuerdaten so korrekt?"
        '
        'lstTaxData
        '
        Me.lstTaxData.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTaxData.Appearance.Options.UseFont = True
        Me.lstTaxData.Location = New System.Drawing.Point(140, 162)
        Me.lstTaxData.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstTaxData.Name = "lstTaxData"
        Me.lstTaxData.Size = New System.Drawing.Size(303, 135)
        Me.lstTaxData.TabIndex = 0
        '
        'frmInstallWizzard
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 787)
        Me.Controls.Add(Me.WizardControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "frmInstallWizzard"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.WizardControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WizardControl1.ResumeLayout(False)
        Me.WelcomeWizardPage1.ResumeLayout(False)
        Me.WelcomeWizardPage1.PerformLayout()
        Me.wizCompleted.ResumeLayout(False)
        CType(Me.picWizzardFinish.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wizSelectDatabaseTarget.ResumeLayout(False)
        Me.wizSelectDatabaseTarget.PerformLayout()
        CType(Me.radDatabaseSelect.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wizSelectExistingDatabase.ResumeLayout(False)
        Me.wizSelectExistingDatabase.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wizTaxes.ResumeLayout(False)
        Me.wizTaxes.PerformLayout()
        CType(Me.picTaxRates.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowInvoiceswithVATIncluded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowVATInInvoices.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstTaxData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WizardControl1 As DevExpress.XtraWizard.WizardControl
    Friend WithEvents WelcomeWizardPage1 As DevExpress.XtraWizard.WelcomeWizardPage
    Friend WithEvents wizCompleted As DevExpress.XtraWizard.CompletionWizardPage
    Friend WithEvents wizSelectDatabaseTarget As DevExpress.XtraWizard.WizardPage
    Friend WithEvents wizSelectExistingDatabase As DevExpress.XtraWizard.WizardPage
    Friend WithEvents IucOptionConnections1 As ClausSoftware.HWLInterops.iucOptionConnections
    Friend WithEvents lblDatabaseSelctionDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents wizTaxes As DevExpress.XtraWizard.WizardPage
    Friend WithEvents radDatabaseSelect As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblHeadlineFirstInstall As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblwizzardWelcome As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTaxDataOK As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lstTaxData As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents btnedit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblCountryCodeTaxRates As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblInstallWizzardFinishedText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents picWizzardFinish As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents btnDefaultSimpleInstallation As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCustomInstallation As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblHelpTaxRateswizzard As DevExpress.XtraEditors.LabelControl
    Friend WithEvents picTaxRates As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents chkShowInvoiceswithVATIncluded As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShowVATInInvoices As DevExpress.XtraEditors.CheckEdit
End Class
