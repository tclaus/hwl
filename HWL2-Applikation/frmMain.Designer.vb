<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits ClausSoftware.HWLInterops.BaseForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.splMainSplitter = New DevExpress.XtraEditors.SplitContainerControl()
        Me.IucMenuBar1 = New ClausSoftware.HWLInterops.iucMenuBar()
        Me.tabControl = New DevExpress.XtraTab.XtraTabControl()
        Me.tabMain = New DevExpress.XtraTab.XtraTabPage()
        Me.cmsTabbedMenue = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDivideHorizontally = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDivideVertically = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultBarAndDockingController1 = New DevExpress.XtraBars.DefaultBarAndDockingController(Me.components)
        Me.ApplicationMenu1 = New DevExpress.XtraBars.Ribbon.ApplicationMenu(Me.components)
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.ItemstatusText = New DevExpress.XtraBars.BarStaticItem()
        Me.BarEditItem2 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.btnCallerList = New DevExpress.XtraBars.BarButtonItem()
        Me.lblCurrentConectionstatusBar = New DevExpress.XtraBars.BarStaticItem()
        Me.mnuMenuBar = New DevExpress.XtraBars.Bar()
        Me.btnMenuFile = New DevExpress.XtraBars.BarSubItem()
        Me.btnMenuDataImportExport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuPageSetup = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuShowPageSetup = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuShowTasks = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuLockApplication = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuEndApplication = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuView = New DevExpress.XtraBars.BarSubItem()
        Me.btnMenuShowTodayToolBar = New DevExpress.XtraBars.BarCheckItem()
        Me.btnHideIfMinimized = New DevExpress.XtraBars.BarCheckItem()
        Me.btnMenuReports = New DevExpress.XtraBars.BarSubItem()
        Me.btnReports = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuFixedCosts = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuTopLists = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuExtras = New DevExpress.XtraBars.BarSubItem()
        Me.btnMenuOptions = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDatabase = New DevExpress.XtraBars.BarSubItem()
        Me.btnRemoveAllImportetItems = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEvntLog = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuLastActiveItems = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuHelp = New DevExpress.XtraBars.BarSubItem()
        Me.btnMenuInvokeHelp = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuOpenUserFeedbackSite = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuCheckForUpdates = New DevExpress.XtraBars.BarButtonItem()
        Me.btnStartTeamViewer = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAboutBox = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnMenuLicenses = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnHistory = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.btnLoadTeamView = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.basesearchPanel = New ClausSoftware.HWLInterops.iucSearchPanel()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        CType(Me.splMainSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splMainSplitter.SuspendLayout()
        CType(Me.tabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl.SuspendLayout()
        Me.cmsTabbedMenue.SuspendLayout()
        CType(Me.DefaultBarAndDockingController1.Controller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'splMainSplitter
        '
        Me.splMainSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splMainSplitter.Location = New System.Drawing.Point(0, 32)
        Me.splMainSplitter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.splMainSplitter.Name = "splMainSplitter"
        Me.splMainSplitter.Panel1.Controls.Add(Me.IucMenuBar1)
        Me.splMainSplitter.Panel1.Text = "Panel1"
        Me.splMainSplitter.Panel2.Controls.Add(Me.tabControl)
        Me.splMainSplitter.Panel2.Text = "Panel2"
        Me.splMainSplitter.Size = New System.Drawing.Size(1450, 991)
        Me.splMainSplitter.SplitterPosition = 179
        Me.splMainSplitter.TabIndex = 18
        Me.splMainSplitter.Text = "SplitContainerControl1"
        '
        'IucMenuBar1
        '
        Me.IucMenuBar1.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.IucMenuBar1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IucMenuBar1.Appearance.Options.UseBackColor = True
        Me.IucMenuBar1.Appearance.Options.UseForeColor = True
        Me.IucMenuBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IucMenuBar1.Location = New System.Drawing.Point(0, 0)
        Me.IucMenuBar1.Margin = New System.Windows.Forms.Padding(4, 7, 4, 7)
        Me.IucMenuBar1.Name = "IucMenuBar1"
        Me.IucMenuBar1.Size = New System.Drawing.Size(179, 991)
        Me.IucMenuBar1.TabIndex = 6
        '
        'tabControl
        '
        Me.tabControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.tabControl.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.tabControl.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl.Location = New System.Drawing.Point(0, 0)
        Me.tabControl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedTabPage = Me.tabMain
        Me.tabControl.Size = New System.Drawing.Size(1266, 991)
        Me.tabControl.TabIndex = 0
        Me.tabControl.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabMain})
        '
        'tabMain
        '
        Me.tabMain.ImageIndex = 4
        Me.tabMain.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Size = New System.Drawing.Size(1260, 957)
        Me.tabMain.Text = "Start"
        '
        'cmsTabbedMenue
        '
        Me.cmsTabbedMenue.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.cmsTabbedMenue.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDivideHorizontally, Me.mnuDivideVertically})
        Me.cmsTabbedMenue.Name = "cmsTabbedMenue"
        Me.cmsTabbedMenue.Size = New System.Drawing.Size(281, 64)
        '
        'mnuDivideHorizontally
        '
        Me.mnuDivideHorizontally.Image = Global.ClausSoftware.GUI.My.Resources.Resources.ArrangeWindowsHS
        Me.mnuDivideHorizontally.Name = "mnuDivideHorizontally"
        Me.mnuDivideHorizontally.Size = New System.Drawing.Size(280, 30)
        Me.mnuDivideHorizontally.Text = "Fenster horizontal teilen"
        '
        'mnuDivideVertically
        '
        Me.mnuDivideVertically.Image = Global.ClausSoftware.GUI.My.Resources.Resources.ArrangeSideBySideHS
        Me.mnuDivideVertically.Name = "mnuDivideVertically"
        Me.mnuDivideVertically.Size = New System.Drawing.Size(280, 30)
        Me.mnuDivideVertically.Text = "Fenster vertikal teilen"
        '
        'DefaultBarAndDockingController1
        '
        '
        '
        '
        Me.DefaultBarAndDockingController1.Controller.LookAndFeel.SkinName = "Lilian"
        Me.DefaultBarAndDockingController1.Controller.LookAndFeel.UseDefaultLookAndFeel = False
        '
        'ApplicationMenu1
        '
        Me.ApplicationMenu1.Manager = Me.BarManager1
        Me.ApplicationMenu1.Name = "ApplicationMenu1"
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar3, Me.mnuMenuBar})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnMenuFile, Me.btnMenuShowTasks, Me.btnMenuHelp, Me.btnMenuExtras, Me.btnMenuOptions, Me.btnMenuEndApplication, Me.btnMenuCheckForUpdates, Me.btnMenuLicenses, Me.btnMenuPageSetup, Me.btnMenuDataImportExport, Me.BarButtonItem2, Me.BarButtonItem3, Me.btnMenuReports, Me.btnMenuTopLists, Me.btnReports, Me.btnHistory, Me.btnMenuFixedCosts, Me.btnMenuInvokeHelp, Me.ItemstatusText, Me.BarButtonItem1, Me.BarButtonItem4, Me.btnMenuLastActiveItems, Me.BarButtonItem7, Me.btnMenuShowPageSetup, Me.btnMenuLockApplication, Me.btnMenuOpenUserFeedbackSite, Me.lblCurrentConectionstatusBar, Me.btnMenuView, Me.btnMenuShowTodayToolBar, Me.BarEditItem1, Me.BarEditItem2, Me.btnAboutBox, Me.btnHideIfMinimized, Me.btnCallerList, Me.btnDatabase, Me.btnRemoveAllImportetItems, Me.btnLoadTeamView, Me.btnStartTeamViewer, Me.BarButtonItem5, Me.btnEvntLog})
        Me.BarManager1.MainMenu = Me.mnuMenuBar
        Me.BarManager1.MaxItemId = 58
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemProgressBar1, Me.RepositoryItemLookUpEdit1})
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar3
        '
        Me.Bar3.BarAppearance.Normal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bar3.BarAppearance.Normal.Options.UseFont = True
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ItemstatusText), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, Me.BarEditItem2, "", False, True, True, 92), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCallerList), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.lblCurrentConectionstatusBar, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DisableClose = True
        Me.Bar3.OptionsBar.DisableCustomization = True
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'ItemstatusText
        '
        Me.ItemstatusText.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.ItemstatusText.Caption = "Statustext"
        Me.ItemstatusText.Id = 24
        Me.ItemstatusText.ItemAppearance.Normal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemstatusText.ItemAppearance.Normal.Options.UseFont = True
        Me.ItemstatusText.Name = "ItemstatusText"
        Me.ItemstatusText.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarEditItem2
        '
        Me.BarEditItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.BarEditItem2.Caption = "prgProgress"
        Me.BarEditItem2.Edit = Me.RepositoryItemProgressBar1
        Me.BarEditItem2.Id = 42
        Me.BarEditItem2.Name = "BarEditItem2"
        Me.BarEditItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        '
        'btnCallerList
        '
        Me.btnCallerList.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.btnCallerList.Caption = "Callers List"
        Me.btnCallerList.Glyph = Global.ClausSoftware.GUI.My.Resources.Resources.telephone_16x16
        Me.btnCallerList.Id = 48
        Me.btnCallerList.Name = "btnCallerList"
        '
        'lblCurrentConectionstatusBar
        '
        Me.lblCurrentConectionstatusBar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.lblCurrentConectionstatusBar.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lblCurrentConectionstatusBar.Caption = "(Verbindungsname)"
        Me.lblCurrentConectionstatusBar.Glyph = Global.ClausSoftware.GUI.My.Resources.Resources.Network_Harddisk16x16
        Me.lblCurrentConectionstatusBar.Id = 37
        Me.lblCurrentConectionstatusBar.ItemAppearance.Normal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentConectionstatusBar.ItemAppearance.Normal.Options.UseFont = True
        Me.lblCurrentConectionstatusBar.ItemAppearance.Normal.Options.UseImage = True
        Me.lblCurrentConectionstatusBar.Name = "lblCurrentConectionstatusBar"
        ToolTipTitleItem1.Text = "(Alias)"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Pfad oder Server.Host" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.lblCurrentConectionstatusBar.SuperTip = SuperToolTip1
        Me.lblCurrentConectionstatusBar.Tag = "dontTranslate"
        Me.lblCurrentConectionstatusBar.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'mnuMenuBar
        '
        Me.mnuMenuBar.BarName = "Custom 3"
        Me.mnuMenuBar.DockCol = 0
        Me.mnuMenuBar.DockRow = 0
        Me.mnuMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.mnuMenuBar.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuFile), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuView), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuReports), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuExtras), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuLastActiveItems), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuHelp)})
        Me.mnuMenuBar.OptionsBar.AllowQuickCustomization = False
        Me.mnuMenuBar.OptionsBar.DisableClose = True
        Me.mnuMenuBar.OptionsBar.DisableCustomization = True
        Me.mnuMenuBar.OptionsBar.DrawDragBorder = False
        Me.mnuMenuBar.OptionsBar.MultiLine = True
        Me.mnuMenuBar.OptionsBar.UseWholeRow = True
        Me.mnuMenuBar.Text = "Hauptmenüleiste"
        '
        'btnMenuFile
        '
        Me.btnMenuFile.Caption = "Datei"
        Me.btnMenuFile.Id = 3
        Me.btnMenuFile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuDataImportExport), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuPageSetup), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuShowPageSetup), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuShowTasks), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuLockApplication, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuEndApplication)})
        Me.btnMenuFile.Name = "btnMenuFile"
        '
        'btnMenuDataImportExport
        '
        Me.btnMenuDataImportExport.Caption = "Import/Export"
        Me.btnMenuDataImportExport.Id = 14
        Me.btnMenuDataImportExport.Name = "btnMenuDataImportExport"
        '
        'btnMenuPageSetup
        '
        Me.btnMenuPageSetup.Caption = "Druck Layouts verwalten..."
        Me.btnMenuPageSetup.Id = 13
        Me.btnMenuPageSetup.Name = "btnMenuPageSetup"
        '
        'btnMenuShowPageSetup
        '
        Me.btnMenuShowPageSetup.Caption = "Seite einrichten"
        Me.btnMenuShowPageSetup.Id = 31
        Me.btnMenuShowPageSetup.Name = "btnMenuShowPageSetup"
        '
        'btnMenuShowTasks
        '
        Me.btnMenuShowTasks.Caption = "Aufgaben"
        Me.btnMenuShowTasks.Id = 4
        Me.btnMenuShowTasks.Name = "btnMenuShowTasks"
        '
        'btnMenuLockApplication
        '
        Me.btnMenuLockApplication.Caption = "Sperren"
        Me.btnMenuLockApplication.Id = 32
        Me.btnMenuLockApplication.Name = "btnMenuLockApplication"
        Me.btnMenuLockApplication.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnMenuEndApplication
        '
        Me.btnMenuEndApplication.Caption = "Beenden"
        Me.btnMenuEndApplication.Id = 9
        Me.btnMenuEndApplication.Name = "btnMenuEndApplication"
        '
        'btnMenuView
        '
        Me.btnMenuView.Caption = "Ansicht"
        Me.btnMenuView.Id = 38
        Me.btnMenuView.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuShowTodayToolBar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnHideIfMinimized)})
        Me.btnMenuView.Name = "btnMenuView"
        '
        'btnMenuShowTodayToolBar
        '
        Me.btnMenuShowTodayToolBar.Caption = "{Appname} Heute"
        Me.btnMenuShowTodayToolBar.Id = 40
        Me.btnMenuShowTodayToolBar.Name = "btnMenuShowTodayToolBar"
        '
        'btnHideIfMinimized
        '
        Me.btnHideIfMinimized.Caption = "Ausblenden wenn minimiert"
        Me.btnHideIfMinimized.Id = 45
        Me.btnHideIfMinimized.Name = "btnHideIfMinimized"
        '
        'btnMenuReports
        '
        Me.btnMenuReports.Caption = "Auswertungen"
        Me.btnMenuReports.Id = 17
        Me.btnMenuReports.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnReports), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuFixedCosts), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuTopLists)})
        Me.btnMenuReports.Name = "btnMenuReports"
        '
        'btnReports
        '
        Me.btnReports.Caption = "Belege"
        Me.btnReports.Id = 19
        Me.btnReports.Name = "btnReports"
        '
        'btnMenuFixedCosts
        '
        Me.btnMenuFixedCosts.Caption = "Fixkosten"
        Me.btnMenuFixedCosts.Id = 22
        Me.btnMenuFixedCosts.Name = "btnMenuFixedCosts"
        '
        'btnMenuTopLists
        '
        Me.btnMenuTopLists.Caption = "Top-10 Listen"
        Me.btnMenuTopLists.Id = 18
        Me.btnMenuTopLists.Name = "btnMenuTopLists"
        '
        'btnMenuExtras
        '
        Me.btnMenuExtras.Caption = "Extras"
        Me.btnMenuExtras.Id = 7
        Me.btnMenuExtras.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuOptions), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem4), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDatabase), New DevExpress.XtraBars.LinkPersistInfo(Me.btnEvntLog)})
        Me.btnMenuExtras.Name = "btnMenuExtras"
        '
        'btnMenuOptions
        '
        Me.btnMenuOptions.Caption = "Optionen"
        Me.btnMenuOptions.Id = 8
        Me.btnMenuOptions.Name = "btnMenuOptions"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Templates"
        Me.BarButtonItem1.Id = 25
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Aus Journal nach Forderungen übertragen"
        Me.BarButtonItem4.Id = 26
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnDatabase
        '
        Me.btnDatabase.Caption = "Datenbank"
        Me.btnDatabase.Id = 49
        Me.btnDatabase.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRemoveAllImportetItems)})
        Me.btnDatabase.Name = "btnDatabase"
        '
        'btnRemoveAllImportetItems
        '
        Me.btnRemoveAllImportetItems.Caption = "Alle Importieren Artikel löschen"
        Me.btnRemoveAllImportetItems.Id = 50
        Me.btnRemoveAllImportetItems.Name = "btnRemoveAllImportetItems"
        '
        'btnEvntLog
        '
        Me.btnEvntLog.Caption = "Letzte Ereignisse"
        Me.btnEvntLog.Id = 57
        Me.btnEvntLog.Name = "btnEvntLog"
        '
        'btnMenuLastActiveItems
        '
        Me.btnMenuLastActiveItems.Caption = "Verlauf"
        Me.btnMenuLastActiveItems.Id = 29
        Me.btnMenuLastActiveItems.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem7)})
        Me.btnMenuLastActiveItems.Name = "btnMenuLastActiveItems"
        '
        'BarButtonItem7
        '
        Me.BarButtonItem7.Caption = "btnDummy"
        Me.BarButtonItem7.Id = 30
        Me.BarButtonItem7.Name = "BarButtonItem7"
        '
        'btnMenuHelp
        '
        Me.btnMenuHelp.Caption = "Hilfe"
        Me.btnMenuHelp.Id = 6
        Me.btnMenuHelp.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuInvokeHelp), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuCheckForUpdates), New DevExpress.XtraBars.LinkPersistInfo(Me.btnStartTeamViewer), New DevExpress.XtraBars.LinkPersistInfo(Me.btnAboutBox)})
        Me.btnMenuHelp.Name = "btnMenuHelp"
        '
        'btnMenuInvokeHelp
        '
        Me.btnMenuInvokeHelp.Caption = "Hilfe"
        Me.btnMenuInvokeHelp.Id = 23
        Me.btnMenuInvokeHelp.Name = "btnMenuInvokeHelp"
        '
        'btnMenuOpenUserFeedbackSite
        '
        Me.btnMenuOpenUserFeedbackSite.Caption = "Technische Unterstützung"
        Me.btnMenuOpenUserFeedbackSite.Id = 35
        Me.btnMenuOpenUserFeedbackSite.Name = "btnMenuOpenUserFeedbackSite"
        '
        'btnMenuCheckForUpdates
        '
        Me.btnMenuCheckForUpdates.Caption = "Aktualisierungen"
        Me.btnMenuCheckForUpdates.Id = 11
        Me.btnMenuCheckForUpdates.Name = "btnMenuCheckForUpdates"
        '
        'btnStartTeamViewer
        '
        Me.btnStartTeamViewer.Caption = "Starte Fernwartung..."
        Me.btnStartTeamViewer.Description = "Läd eine Fernwartungssoftware und startet diese."
        Me.btnStartTeamViewer.Id = 53
        Me.btnStartTeamViewer.Name = "btnStartTeamViewer"
        ToolTipItem2.Text = "Startet eine Fernwartung mit dieem Rechner"
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.btnStartTeamViewer.SuperTip = SuperToolTip2
        '
        'btnAboutBox
        '
        Me.btnAboutBox.Caption = "Über {Appname}..."
        Me.btnAboutBox.Id = 43
        Me.btnAboutBox.Name = "btnAboutBox"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.barDockControlTop.Size = New System.Drawing.Size(1450, 32)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 1023)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1450, 35)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 32)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 991)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1450, 32)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 991)
        '
        'btnMenuLicenses
        '
        Me.btnMenuLicenses.Caption = "Lizenzen..."
        Me.btnMenuLicenses.Id = 12
        Me.btnMenuLicenses.Name = "btnMenuLicenses"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Auswertungen"
        Me.BarButtonItem2.Id = 15
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Auswertungen"
        Me.BarButtonItem3.Id = 16
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'btnHistory
        '
        Me.btnHistory.Caption = "Kontakt Historie"
        Me.btnHistory.Id = 20
        Me.btnHistory.Name = "btnHistory"
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "BarEditItem1"
        Me.BarEditItem1.Edit = Me.RepositoryItemTextEdit1
        Me.BarEditItem1.Id = 41
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'btnLoadTeamView
        '
        Me.btnLoadTeamView.Caption = "Fernwartung"
        Me.btnLoadTeamView.Id = 52
        Me.btnLoadTeamView.Name = "btnLoadTeamView"
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Create 5000 JournalItems"
        Me.BarButtonItem5.Id = 56
        Me.BarButtonItem5.Name = "BarButtonItem5"
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'basesearchPanel
        '
        Me.basesearchPanel.AllowTextFieldTabStop = True
        Me.basesearchPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.basesearchPanel.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.basesearchPanel.Appearance.Options.UseBackColor = True
        Me.basesearchPanel.Location = New System.Drawing.Point(1167, 0)
        Me.basesearchPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.basesearchPanel.Name = "basesearchPanel"
        Me.basesearchPanel.NullValuePrompt = ""
        Me.basesearchPanel.SelectedMenueItem = -1
        Me.basesearchPanel.Size = New System.Drawing.Size(274, 37)
        Me.basesearchPanel.Status = ClausSoftware.HWLInterops.iucSearchPanel.enumState.empty
        Me.basesearchPanel.TabIndex = 0
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "HWl-2"
        Me.NotifyIcon1.BalloonTipTitle = "HWL ist nun minimiert in der Symbolleiste"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "HWL-2"
        '
        'frmMain
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1450, 1058)
        Me.Controls.Add(Me.basesearchPanel)
        Me.Controls.Add(Me.splMainSplitter)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmMain"
        Me.Text = "HWL"
        CType(Me.splMainSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splMainSplitter.ResumeLayout(False)
        CType(Me.tabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl.ResumeLayout(False)
        Me.cmsTabbedMenue.ResumeLayout(False)
        CType(Me.DefaultBarAndDockingController1.Controller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IucMenuBar1 As HWLInterops.iucMenuBar
    Friend WithEvents splMainSplitter As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents DefaultBarAndDockingController1 As DevExpress.XtraBars.DefaultBarAndDockingController
    Friend WithEvents ApplicationMenu1 As DevExpress.XtraBars.Ribbon.ApplicationMenu
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents mnuMenuBar As DevExpress.XtraBars.Bar
    Friend WithEvents btnMenuFile As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnMenuShowTasks As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuHelp As DevExpress.XtraBars.BarSubItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnMenuExtras As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnMenuOptions As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuEndApplication As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tabControl As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabMain As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnMenuCheckForUpdates As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuLicenses As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuPageSetup As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuDataImportExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuReports As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnReports As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnHistory As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuFixedCosts As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuTopLists As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuInvokeHelp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ItemstatusText As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents cmsTabbedMenue As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDivideHorizontally As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDivideVertically As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuLastActiveItems As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuShowPageSetup As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuLockApplication As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents basesearchPanel As ClausSoftware.HWLInterops.iucSearchPanel
    Friend WithEvents btnMenuOpenUserFeedbackSite As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents lblCurrentConectionstatusBar As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btnMenuView As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnMenuShowTodayToolBar As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents BarEditItem2 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents btnAboutBox As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnHideIfMinimized As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents btnCallerList As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnDatabase As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnRemoveAllImportetItems As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnLoadTeamView As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnStartTeamViewer As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnEvntLog As DevExpress.XtraBars.BarButtonItem


End Class
