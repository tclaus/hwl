<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnectionDetails
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem5 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem6 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.TabControlConnections = New DevExpress.XtraTab.XtraTabControl()
        Me.tabDatabaseServer = New DevExpress.XtraTab.XtraTabPage()
        Me.lblDatabaseSize = New DevExpress.XtraEditors.LabelControl()
        Me.btnCreateserverBackup = New DevExpress.XtraEditors.SimpleButton()
        Me.txtConnectionDatabaseName = New DevExpress.XtraEditors.TextEdit()
        Me.txtConnectionUserPassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtConnectionUsername = New DevExpress.XtraEditors.TextEdit()
        Me.txtConnectionServerName = New DevExpress.XtraEditors.TextEdit()
        Me.lblConnectionDatabaseName = New DevExpress.XtraEditors.LabelControl()
        Me.txtConnectionNameServer = New DevExpress.XtraEditors.TextEdit()
        Me.lblConnectionUserPassword = New DevExpress.XtraEditors.LabelControl()
        Me.lblConnectionUserName = New DevExpress.XtraEditors.LabelControl()
        Me.lblConnectionHostName = New DevExpress.XtraEditors.LabelControl()
        Me.lblConnectionName = New DevExpress.XtraEditors.LabelControl()
        Me.tabDatabaseFile = New DevExpress.XtraTab.XtraTabPage()
        Me.btnCreateBackup = New DevExpress.XtraEditors.SimpleButton()
        Me.lblBackupPath = New DevExpress.XtraEditors.LabelControl()
        Me.lblNameBackupPath = New DevExpress.XtraEditors.LabelControl()
        Me.btnBackupPath = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPath = New DevExpress.XtraEditors.LabelControl()
        Me.txtConnectionNameFile = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnGetPath = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDatabasePath = New DevExpress.XtraEditors.LabelControl()
        Me.btnTest = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.chkAsdefault = New DevExpress.XtraEditors.CheckEdit()
        Me.LoadingCircle1 = New ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle()
        CType(Me.TabControlConnections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlConnections.SuspendLayout()
        Me.tabDatabaseServer.SuspendLayout()
        CType(Me.txtConnectionDatabaseName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConnectionUserPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConnectionUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConnectionServerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConnectionNameServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatabaseFile.SuspendLayout()
        CType(Me.txtConnectionNameFile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAsdefault.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControlConnections
        '
        Me.TabControlConnections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlConnections.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.TabControlConnections.Appearance.Options.UseBackColor = True
        Me.TabControlConnections.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlConnections.Location = New System.Drawing.Point(2, 5)
        Me.TabControlConnections.Name = "TabControlConnections"
        Me.TabControlConnections.SelectedTabPage = Me.tabDatabaseServer
        Me.TabControlConnections.Size = New System.Drawing.Size(409, 224)
        Me.TabControlConnections.TabIndex = 0
        Me.TabControlConnections.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabDatabaseFile, Me.tabDatabaseServer})
        '
        'tabDatabaseServer
        '
        Me.tabDatabaseServer.Controls.Add(Me.LoadingCircle1)
        Me.tabDatabaseServer.Controls.Add(Me.lblDatabaseSize)
        Me.tabDatabaseServer.Controls.Add(Me.btnCreateserverBackup)
        Me.tabDatabaseServer.Controls.Add(Me.txtConnectionDatabaseName)
        Me.tabDatabaseServer.Controls.Add(Me.txtConnectionUserPassword)
        Me.tabDatabaseServer.Controls.Add(Me.txtConnectionUsername)
        Me.tabDatabaseServer.Controls.Add(Me.txtConnectionServerName)
        Me.tabDatabaseServer.Controls.Add(Me.lblConnectionDatabaseName)
        Me.tabDatabaseServer.Controls.Add(Me.txtConnectionNameServer)
        Me.tabDatabaseServer.Controls.Add(Me.lblConnectionUserPassword)
        Me.tabDatabaseServer.Controls.Add(Me.lblConnectionUserName)
        Me.tabDatabaseServer.Controls.Add(Me.lblConnectionHostName)
        Me.tabDatabaseServer.Controls.Add(Me.lblConnectionName)
        Me.tabDatabaseServer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatabaseServer.Name = "tabDatabaseServer"
        Me.tabDatabaseServer.Size = New System.Drawing.Size(402, 195)
        Me.tabDatabaseServer.Text = "Datenbankserver"
        '
        'lblDatabaseSize
        '
        Me.lblDatabaseSize.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabaseSize.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDatabaseSize.Appearance.Options.UseFont = True
        Me.lblDatabaseSize.Appearance.Options.UseForeColor = True
        Me.lblDatabaseSize.Location = New System.Drawing.Point(8, 161)
        Me.lblDatabaseSize.Name = "lblDatabaseSize"
        Me.lblDatabaseSize.Size = New System.Drawing.Size(23, 15)
        Me.lblDatabaseSize.TabIndex = 12
        Me.lblDatabaseSize.Text = "0 Kb"
        '
        'btnCreateserverBackup
        '
        Me.btnCreateserverBackup.Location = New System.Drawing.Point(273, 148)
        Me.btnCreateserverBackup.Name = "btnCreateserverBackup"
        Me.btnCreateserverBackup.Size = New System.Drawing.Size(120, 28)
        Me.btnCreateserverBackup.TabIndex = 11
        Me.btnCreateserverBackup.Text = "Datensicherung..."
        '
        'txtConnectionDatabaseName
        '
        Me.txtConnectionDatabaseName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectionDatabaseName.Location = New System.Drawing.Point(160, 60)
        Me.txtConnectionDatabaseName.Name = "txtConnectionDatabaseName"
        Me.txtConnectionDatabaseName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConnectionDatabaseName.Properties.Appearance.Options.UseFont = True
        Me.txtConnectionDatabaseName.Size = New System.Drawing.Size(233, 22)
        ToolTipTitleItem1.Text = "Name der Datenbank"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Geben Sie hier den Namen der Datenbank an."
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.txtConnectionDatabaseName.SuperTip = SuperToolTip1
        Me.txtConnectionDatabaseName.TabIndex = 2
        '
        'txtConnectionUserPassword
        '
        Me.txtConnectionUserPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectionUserPassword.Location = New System.Drawing.Point(159, 120)
        Me.txtConnectionUserPassword.Name = "txtConnectionUserPassword"
        Me.txtConnectionUserPassword.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConnectionUserPassword.Properties.Appearance.Options.UseFont = True
        Me.txtConnectionUserPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConnectionUserPassword.Size = New System.Drawing.Size(233, 22)
        ToolTipTitleItem2.Text = "Passwort des Benutzers"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Geben Sie das Datenbankpasswort des Benutzers für diese Datenbank an."
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.txtConnectionUserPassword.SuperTip = SuperToolTip2
        Me.txtConnectionUserPassword.TabIndex = 4
        '
        'txtConnectionUsername
        '
        Me.txtConnectionUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectionUsername.Location = New System.Drawing.Point(159, 90)
        Me.txtConnectionUsername.Name = "txtConnectionUsername"
        Me.txtConnectionUsername.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConnectionUsername.Properties.Appearance.Options.UseFont = True
        Me.txtConnectionUsername.Size = New System.Drawing.Size(233, 22)
        ToolTipTitleItem3.Text = "Benutzername"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Geben Sie einen Benutzernamen an, der Lese/Schreibrechte auf diese Datenbank hat." & _
    ""
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.txtConnectionUsername.SuperTip = SuperToolTip3
        Me.txtConnectionUsername.TabIndex = 3
        '
        'txtConnectionServerName
        '
        Me.txtConnectionServerName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectionServerName.Location = New System.Drawing.Point(160, 30)
        Me.txtConnectionServerName.Name = "txtConnectionServerName"
        Me.txtConnectionServerName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConnectionServerName.Properties.Appearance.Options.UseFont = True
        Me.txtConnectionServerName.Size = New System.Drawing.Size(233, 22)
        ToolTipTitleItem4.Text = "Name des Servers"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Dies ist der Rechnername, auf dem die Datenbank läuft. Geben Sie den Netzwerkname" & _
    "n des Rechners an oder eine IP-Adresse. "
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.txtConnectionServerName.SuperTip = SuperToolTip4
        Me.txtConnectionServerName.TabIndex = 1
        '
        'lblConnectionDatabaseName
        '
        Me.lblConnectionDatabaseName.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnectionDatabaseName.Appearance.Options.UseFont = True
        Me.lblConnectionDatabaseName.Location = New System.Drawing.Point(8, 63)
        Me.lblConnectionDatabaseName.Name = "lblConnectionDatabaseName"
        Me.lblConnectionDatabaseName.Size = New System.Drawing.Size(87, 15)
        Me.lblConnectionDatabaseName.TabIndex = 0
        Me.lblConnectionDatabaseName.Text = "Datenbankname"
        '
        'txtConnectionNameServer
        '
        Me.txtConnectionNameServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectionNameServer.Location = New System.Drawing.Point(160, 0)
        Me.txtConnectionNameServer.Name = "txtConnectionNameServer"
        Me.txtConnectionNameServer.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConnectionNameServer.Properties.Appearance.Options.UseFont = True
        Me.txtConnectionNameServer.Size = New System.Drawing.Size(233, 22)
        ToolTipTitleItem5.Text = "Verbindungsname"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Geben Sie der Verbindung einen kurzen, eindeutigen Namen. z.B. ""Produktivserver"""
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.txtConnectionNameServer.SuperTip = SuperToolTip5
        Me.txtConnectionNameServer.TabIndex = 0
        '
        'lblConnectionUserPassword
        '
        Me.lblConnectionUserPassword.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnectionUserPassword.Appearance.Options.UseFont = True
        Me.lblConnectionUserPassword.Location = New System.Drawing.Point(8, 123)
        Me.lblConnectionUserPassword.Name = "lblConnectionUserPassword"
        Me.lblConnectionUserPassword.Size = New System.Drawing.Size(93, 15)
        Me.lblConnectionUserPassword.TabIndex = 0
        Me.lblConnectionUserPassword.Text = "Benutzerpasswort"
        '
        'lblConnectionUserName
        '
        Me.lblConnectionUserName.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnectionUserName.Appearance.Options.UseFont = True
        Me.lblConnectionUserName.Location = New System.Drawing.Point(8, 93)
        Me.lblConnectionUserName.Name = "lblConnectionUserName"
        Me.lblConnectionUserName.Size = New System.Drawing.Size(76, 15)
        Me.lblConnectionUserName.TabIndex = 0
        Me.lblConnectionUserName.Text = "Benutzername"
        '
        'lblConnectionHostName
        '
        Me.lblConnectionHostName.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnectionHostName.Appearance.Options.UseFont = True
        Me.lblConnectionHostName.Location = New System.Drawing.Point(8, 33)
        Me.lblConnectionHostName.Name = "lblConnectionHostName"
        Me.lblConnectionHostName.Size = New System.Drawing.Size(62, 15)
        Me.lblConnectionHostName.TabIndex = 0
        Me.lblConnectionHostName.Text = "Servername"
        '
        'lblConnectionName
        '
        Me.lblConnectionName.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnectionName.Appearance.Options.UseFont = True
        Me.lblConnectionName.Location = New System.Drawing.Point(8, 3)
        Me.lblConnectionName.Name = "lblConnectionName"
        Me.lblConnectionName.Size = New System.Drawing.Size(117, 15)
        Me.lblConnectionName.TabIndex = 0
        Me.lblConnectionName.Text = "Name der Verbindung"
        '
        'tabDatabaseFile
        '
        Me.tabDatabaseFile.Appearance.PageClient.BackColor = System.Drawing.Color.Transparent
        Me.tabDatabaseFile.Appearance.PageClient.Options.UseBackColor = True
        Me.tabDatabaseFile.Controls.Add(Me.btnCreateBackup)
        Me.tabDatabaseFile.Controls.Add(Me.lblBackupPath)
        Me.tabDatabaseFile.Controls.Add(Me.lblNameBackupPath)
        Me.tabDatabaseFile.Controls.Add(Me.btnBackupPath)
        Me.tabDatabaseFile.Controls.Add(Me.lblPath)
        Me.tabDatabaseFile.Controls.Add(Me.txtConnectionNameFile)
        Me.tabDatabaseFile.Controls.Add(Me.LabelControl1)
        Me.tabDatabaseFile.Controls.Add(Me.btnGetPath)
        Me.tabDatabaseFile.Controls.Add(Me.lblDatabasePath)
        Me.tabDatabaseFile.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatabaseFile.Name = "tabDatabaseFile"
        Me.tabDatabaseFile.Size = New System.Drawing.Size(402, 195)
        Me.tabDatabaseFile.Text = "Datei"
        '
        'btnCreateBackup
        '
        Me.btnCreateBackup.Location = New System.Drawing.Point(232, 146)
        Me.btnCreateBackup.Name = "btnCreateBackup"
        Me.btnCreateBackup.Size = New System.Drawing.Size(120, 28)
        Me.btnCreateBackup.TabIndex = 10
        Me.btnCreateBackup.Text = "Datensicherung..."
        '
        'lblBackupPath
        '
        Me.lblBackupPath.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackupPath.Appearance.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblBackupPath.Appearance.Options.UseFont = True
        Me.lblBackupPath.Appearance.Options.UseForeColor = True
        Me.lblBackupPath.Appearance.Options.UseTextOptions = True
        Me.lblBackupPath.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisPath
        Me.lblBackupPath.AutoEllipsis = True
        Me.lblBackupPath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblBackupPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBackupPath.Location = New System.Drawing.Point(8, 125)
        Me.lblBackupPath.Name = "lblBackupPath"
        Me.lblBackupPath.Size = New System.Drawing.Size(388, 15)
        Me.lblBackupPath.TabIndex = 9
        Me.lblBackupPath.Tag = "DontTranslate"
        Me.lblBackupPath.Text = " - Pathname -"
        '
        'lblNameBackupPath
        '
        Me.lblNameBackupPath.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameBackupPath.Appearance.Options.UseFont = True
        Me.lblNameBackupPath.Location = New System.Drawing.Point(9, 103)
        Me.lblNameBackupPath.Name = "lblNameBackupPath"
        Me.lblNameBackupPath.Size = New System.Drawing.Size(151, 15)
        Me.lblNameBackupPath.TabIndex = 8
        Me.lblNameBackupPath.Text = "Pfad für die Sicherungskopie"
        '
        'btnBackupPath
        '
        Me.btnBackupPath.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackupPath.Appearance.Options.UseFont = True
        Me.btnBackupPath.Location = New System.Drawing.Point(232, 91)
        Me.btnBackupPath.Name = "btnBackupPath"
        Me.btnBackupPath.Size = New System.Drawing.Size(87, 27)
        Me.btnBackupPath.TabIndex = 6
        Me.btnBackupPath.Text = "Pfad..."
        '
        'lblPath
        '
        Me.lblPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPath.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.Appearance.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPath.Appearance.Options.UseFont = True
        Me.lblPath.Appearance.Options.UseForeColor = True
        Me.lblPath.Appearance.Options.UseTextOptions = True
        Me.lblPath.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisPath
        Me.lblPath.AutoEllipsis = True
        Me.lblPath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPath.Location = New System.Drawing.Point(8, 69)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(391, 15)
        ToolTipTitleItem6.Text = "Pfad zur Datenbankdatei"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "In diesem Pfad ist die Datenbankdatei gespeichert." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Diese enthält sämtliche Daten" & _
    " des Programms"
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.lblPath.SuperTip = SuperToolTip6
        Me.lblPath.TabIndex = 5
        Me.lblPath.Tag = "DontTranslate"
        Me.lblPath.Text = " - Pathname -"
        '
        'txtConnectionNameFile
        '
        Me.txtConnectionNameFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectionNameFile.Location = New System.Drawing.Point(182, 0)
        Me.txtConnectionNameFile.Name = "txtConnectionNameFile"
        Me.txtConnectionNameFile.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConnectionNameFile.Properties.Appearance.Options.UseFont = True
        Me.txtConnectionNameFile.Size = New System.Drawing.Size(211, 22)
        Me.txtConnectionNameFile.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(8, 3)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(117, 15)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Name der Verbindung"
        '
        'btnGetPath
        '
        Me.btnGetPath.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetPath.Appearance.Options.UseFont = True
        Me.btnGetPath.Location = New System.Drawing.Point(231, 39)
        Me.btnGetPath.Name = "btnGetPath"
        Me.btnGetPath.Size = New System.Drawing.Size(87, 27)
        Me.btnGetPath.TabIndex = 2
        Me.btnGetPath.Text = "Pfad..."
        '
        'lblDatabasePath
        '
        Me.lblDatabasePath.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabasePath.Appearance.Options.UseFont = True
        Me.lblDatabasePath.Location = New System.Drawing.Point(8, 39)
        Me.lblDatabasePath.Name = "lblDatabasePath"
        Me.lblDatabasePath.Size = New System.Drawing.Size(73, 15)
        Me.lblDatabasePath.TabIndex = 0
        Me.lblDatabasePath.Text = "Pfad zur Datei"
        '
        'btnTest
        '
        Me.btnTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTest.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTest.Appearance.Options.UseFont = True
        Me.btnTest.Location = New System.Drawing.Point(313, 241)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(87, 27)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "Testen"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(313, 275)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(218, 275)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 27)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'chkAsdefault
        '
        Me.chkAsdefault.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAsdefault.Location = New System.Drawing.Point(0, 239)
        Me.chkAsdefault.Name = "chkAsdefault"
        Me.chkAsdefault.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAsdefault.Properties.Appearance.Options.UseFont = True
        Me.chkAsdefault.Properties.Caption = "Als standard setzen"
        Me.chkAsdefault.Size = New System.Drawing.Size(212, 20)
        Me.chkAsdefault.TabIndex = 6
        '
        'LoadingCircle1
        '
        Me.LoadingCircle1.Active = False
        Me.LoadingCircle1.Color = System.Drawing.Color.DarkGray
        Me.LoadingCircle1.InnerCircleRadius = 8
        Me.LoadingCircle1.Location = New System.Drawing.Point(201, 148)
        Me.LoadingCircle1.Name = "LoadingCircle1"
        Me.LoadingCircle1.NumberSpoke = 10
        Me.LoadingCircle1.OuterCircleRadius = 10
        Me.LoadingCircle1.RotationSpeed = 100
        Me.LoadingCircle1.Size = New System.Drawing.Size(56, 31)
        Me.LoadingCircle1.SpokeThickness = 4
        Me.LoadingCircle1.StylePreset = ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX
        Me.LoadingCircle1.TabIndex = 7
        Me.LoadingCircle1.Visible = False
        '
        'frmConnectionDetails
        '
        Me.AcceptButton = Me.btnOK
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(414, 315)
        Me.Controls.Add(Me.chkAsdefault)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TabControlConnections)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnectionDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Verbindungsdaten"
        CType(Me.TabControlConnections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlConnections.ResumeLayout(False)
        Me.tabDatabaseServer.ResumeLayout(False)
        Me.tabDatabaseServer.PerformLayout()
        CType(Me.txtConnectionDatabaseName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConnectionUserPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConnectionUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConnectionServerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConnectionNameServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatabaseFile.ResumeLayout(False)
        Me.tabDatabaseFile.PerformLayout()
        CType(Me.txtConnectionNameFile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAsdefault.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlConnections As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabDatabaseServer As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabDatabaseFile As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents txtConnectionUserPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtConnectionUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtConnectionServerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtConnectionNameServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblConnectionUserPassword As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblConnectionUserName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblConnectionHostName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblConnectionName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtConnectionDatabaseName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblConnectionDatabaseName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnTest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGetPath As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblDatabasePath As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkAsdefault As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtConnectionNameFile As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPath As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnBackupPath As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblNameBackupPath As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblBackupPath As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCreateBackup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCreateserverBackup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblDatabaseSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LoadingCircle1 As ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle
End Class
