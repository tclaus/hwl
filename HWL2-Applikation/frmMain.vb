Imports ClausSoftware.HWLInterops.Printing


''' <summary>
''' Hauptfenster. Bindet alle weiteren Steuerelement ein
''' </summary>
''' <remarks></remarks>
Public Class frmMain

    ''' <summary>
    ''' Die Menüleiste, entweder HWL oder PowerBüro
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents m_menuSelector As HWLInterops.IMenuBar
    Private m_hideIfMinimized As Boolean = False

    ''' <summary>
    ''' Stellt das UI-Objekt bereit. Enthält Steuerungen zum Anlegen und entfernen von Arbeitsmodulen
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents m_mainUI As New MainUI(Me)

    ''' <summary>
    ''' Stellt das Formular bereit, das eine Anruferliste anzeigt
    ''' </summary>
    ''' <remarks></remarks>
    Private m_showCallersListform As HWLInterops.frmCallersList

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Private m_isFirstStart As Boolean

    ''' <summary>
    ''' Zeigt an, das dies der erste Start ist
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsFirstStart() As Boolean
        Get
            Return m_isFirstStart
        End Get
        Set(ByVal value As Boolean)
            m_isFirstStart = value
        End Set
    End Property


    ''' <summary>
    ''' Ruft das Stammobjekt der Applikation ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property MainApplication() As ClausSoftware.MainApplication
        Get
            Return MainApplication.getInstance
        End Get
    End Property


    ''' <summary>
    ''' Setzt den Focus auf das Suchfenster
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetFocusOnSearchwindow(ByVal sender As Object, ByVal e As EventArgs)
        basesearchPanel.SetFocus()

    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        NotifyIcon1.Visible = False
        NotifyIcon1 = Nothing
    End Sub


    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'TODO: eventuell das schliessen verhindern, wenn noch ungespeicherte Änderungen vorliegen.. 

        If e.CloseReason = CloseReason.UserClosing Then
            ' Irgendwelche Fenster noch auf ? 
            m_mainUI.HasUnsavedChanges()

        End If




        Try ' Ein Fehler hier aber dann vollkommen ignorieren.. (Ist eh schlecht, wenn das passiert!
            MainApplication.getInstance.Settings.SaveFormsPos(Me)
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "FormMain_Closing", "Error while closing Form Main")
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DesignMode Then Exit Sub

        'Autocursor definieren
        AutoWaitCursor.Cursor = Cursors.WaitCursor
        AutoWaitCursor.Delay = New TimeSpan(0, 0, 0, 0, 25)
        ' Set the window handle to the handle of the main form in your application
        AutoWaitCursor.MainWindowHandle = Me.Handle
        AutoWaitCursor.Start()

        ' Sprachen der Oberfläche setzen
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

        'Menübar übersetzen.
        For Each item As DevExpress.XtraBars.BarItem In BarManager1.Items
            TranslateMenuItems(item)
        Next


        'Standard Icon Applikationsweit setzen
        GetType(System.Windows.Forms.Form).GetField("defaultIcon", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Static).SetValue(Nothing, Me.Icon)


        Me.Text = MainApplication.ApplicationName  ' Überschrift setzen

        ' Verbindungs-Text setzen
        SetConnectionstatusText()



        ' Das Panel aufbauen
        splMainSplitter.Panel1.Controls.Clear()


        'HWL / Power-Büro Unterscheidung für das Aufbauen des Menüs
        If MainApplication.ApplicationName.StartsWith("HWL") Then
            Dim menue As New iucMenuBar
            m_menuSelector = menue

            splMainSplitter.Horizontal = True
            splMainSplitter.Panel1.Controls.Add(menue)
            menue.Dock = DockStyle.Fill
            AddHandler m_menuSelector.ClickedModule, AddressOf ClickedModule

            splMainSplitter.SplitterPosition = CInt(MainApplication.getInstance.Settings.GetSetting(splMainSplitter.Name, "MainForm", splMainSplitter.SplitterPosition.ToString))


        Else
            Dim menue As New iucPowerBueroMenueBar
            m_menuSelector = menue
            splMainSplitter.Horizontal = False
            splMainSplitter.Panel1.Controls.Add(menue)
            splMainSplitter.SplitterPosition = menue.Height
            splMainSplitter.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel1


            menue.Dock = DockStyle.Fill
            AddHandler m_menuSelector.ClickedModule, AddressOf ClickedModule
        End If

        MainApplication.getInstance.Settings.RestoreFormsPos(Me)


        tabControl.TabPages.Clear() ' die Standard-Tabseite leeren; wir fangen dann ganz neu an

        'Statustext der Applikation auf die Statuszeile legen
        AddHandler MainApplication.getInstance.Message, AddressOf SetStatusText
        AddHandler MainApplication.getInstance.Progress, AddressOf SetProgress
        AddHandler MainApplication.getInstance.NetworkstateChanged, AddressOf DatabaseStateChanged
        AddHandler MainApplication.getInstance.DatabaseConnectionError, AddressOf DatabaseConnectionLost

        basesearchPanel.Top = 0
        basesearchPanel.Left = Me.Width - basesearchPanel.Width - 20

        ' Geänderte Systemeinstellungen beobachtn
        AddHandler Kernel.Settings.NamesSettingChanged, AddressOf SettingChangedWatcher


        ' Eingehende Anrufe signalisieren
        AddHandler m_mainUI.NewIncommingCall, AddressOf OnSetIncommingCallIcon

        SetIncommingCallIcon()

        ' Addins aufrufen und laden
        Dim dummyAddins As Object = MainApplication.getInstance.AddIns.AddIns

        StartModule(HWLModules.Homescreen)

        CheckBackgroundImage()


        AddHandler m_mainUI.FocusSearchBar, AddressOf SetFocusOnSearchwindow

        SetStatusText(GetText("msgApplicationLaunchReady", "Bereit."))
    End Sub

    Private Delegate Sub deleSetIncommingCallIcon()

    ''' <summary>
    ''' Setzt ein geändertes ISDN - Icon, bei einer eingehenenden Verbindung 
    ''' </summary>
    ''' <param name="sender">enthält das PhoneCall - Objekt</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OnSetIncommingCallIcon(ByVal sender As Object, ByVal e As EventArgs)
        Dim newCall As Kernel.PhoneCall = CType(sender, Kernel.PhoneCall)

        If Me.InvokeRequired Then
            Me.Invoke(New deleSetIncommingCallIcon(AddressOf SetIncommingCallIcon))
            Exit Sub
        End If

        SetIncommingCallIcon()

    End Sub
    ''' <summary>
    ''' Setzt das ISDN-Icon für die Anzeige neuer Anrufe
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetIncommingCallIcon()
        Dim CallList As New Kernel.PhoneCalls(MainApplication.getInstance)

        Dim callIcon As System.Drawing.Image
        Dim maxNumber As Integer = CallList.GetMaxID


        btnCallerList.SuperTip = New DevExpress.Utils.SuperToolTip()
        btnCallerList.SuperTip.Items.AddTitle(GetText("msgPhoneLineMonitor", "Telefonanrufe"))

        If MainApplication.getInstance.Settings.MonitorPhoneLinesLastNumber < maxNumber Then
            callIcon = My.Resources.telephone_16x16
            ' Anzahl der Calls überlagern
            Dim callCount As String = (maxNumber - MainApplication.getInstance.Settings.MonitorPhoneLinesLastNumber).ToString

            callIcon = Tools.Tools.AddTextToImage(CType(callIcon, Bitmap), callCount)
            btnCallerList.SuperTip.Items.Add(GetText("msgCountCalls", "Neue Anrufe: {0}", callCount))
        Else

            btnCallerList.SuperTip.Items.Add(GetText("msgClickToOpenPhoneCallList", "Öffnet die Liste der Telefonanrufe"))
            callIcon = My.Resources.telephone_16x16
        End If


        btnCallerList.Glyph = callIcon

    End Sub

    ''' <summary>
    ''' Blendet das Telefon-symbol ein oder aus; je nachdem ob Anrufe eingegangen sind oder nicht
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowCallersListIcon()
        ' Telefon nur einblenden, wenn auch die Option gesetzt ist
        If MainApplication.getInstance.Settings.MonitorPhoneLines Then
            btnCallerList.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Else
            btnCallerList.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        End If
    End Sub

    Private Delegate Sub ShowstatusText(ByVal message As String)
    Private Delegate Sub ShowstatusProgress(ByVal text As String, ByVal value As Integer, ByVal maxValue As Integer)


    ''' <summary>
    ''' Nimmt Statusmeldungen des Kernels auf, und leitet diese an die Statusleiste des Hauptfensters
    ''' </summary>
    ''' <param name="messagetext"></param>
    ''' <remarks></remarks>
    Private Sub SetStatusText(ByVal messagetext As String)

        If Me.InvokeRequired Then
            Me.Invoke(New ShowstatusText(AddressOf SetStatusText), messagetext)
            Exit Sub
        End If

        messagetext = messagetext.Replace(vbCrLf, " ")
        If messagetext.Length > 80 Then
            messagetext = messagetext.Substring(0, 76) & "..."
        End If

        ItemstatusText.Caption = messagetext
        ItemstatusText.Refresh()

    End Sub


    Private Sub ClickedModule(ByVal sender As Object, ByVal e As HWLInterops.moduleEventargs)

        StartModule(e.CallingModule)
    End Sub



    ''' <summary>
    ''' Startet ein neues Tab mit dem angegebenen Modul
    ''' </summary>
    ''' <param name="windowModule"></param>
    ''' <remarks></remarks>
    Private Sub StartModule(ByVal windowModule As HWLModules)

        ' Ist bei einem Klick die CTRL-Taste gedrückt, dann ein neues Panel aufmachen !
        If (Control.ModifierKeys And Keys.Control) = Keys.Control Then
            m_mainUI.OpenWorkingPane(windowModule, True)

        Else
            m_mainUI.OpenWorkingPane(windowModule)

        End If

    End Sub


    ''' <summary>
    ''' Ruft ein neues ArbeitsTab auf Grundlage des übergebenen Moduls auf
    ''' </summary>
    ''' <param name="userModule"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNewTab(ByVal userModule As iucMainModule) As DevExpress.XtraTab.XtraTabPage
        Try
            Dim tabPage As New DevExpress.XtraTab.XtraTabPage
            tabControl.TabPages.Add(tabPage)

            tabPage.Controls.Add(userModule)
            tabPage.Tag = userModule
            tabPage.Image = userModule.WorkingItem.SmallImage
            userModule.Dock = DockStyle.Fill
            tabPage.Text = userModule.ToString

            Return tabPage

        Catch ex As Exception
            Debug.Print("Konnte neues Modul nicht starten: " & ex.Message)
            Return Nothing
        End Try

    End Function

    Private Sub TabDisplayTextChanged(ByVal sender As iucMainModule, ByVal e As DisplayTextEventArgs)
        For Each tabItem As DevExpress.XtraTab.XtraTabPage In tabControl.TabPages
            If tabItem.Tag Is sender Then
                Dim tabText As String = e.NewDisplayText
                If tabText.Length > 25 Then
                    tabText = tabText.Substring(0, 23) & "..."
                End If
                tabItem.Text = tabText
                tabItem.Tooltip = e.NewDisplayText
            End If
        Next

    End Sub

    Private Sub tabControl_CloseButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabControl.CloseButtonClick
        m_mainUI.CloseModule(CType(tabControl.SelectedTabPage.Tag, iucMainModule))

    End Sub
    Private Sub tabControl_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tabControl.MouseClick
        Dim hi As DevExpress.XtraTab.ViewInfo.XtraTabHitInfo

        hi = tabControl.CalcHitInfo(e.Location)
        If e.Button = Windows.Forms.MouseButtons.Middle Then
            If hi.HitTest = DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader Then
                If hi.Page IsNot Nothing Then
                    m_mainUI.CloseModule(CType(hi.Page.Tag, iucMainModule))
                End If
            End If
        End If

    End Sub
    Private Sub btnShowTasks_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuShowTasks.ItemClick
        m_mainUI.OpenTasksList()

    End Sub

    Private Sub MenuEndApplication_click(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuEndApplication.ItemClick
        ClickedModule(Me, New moduleEventargs(HWLModules.ExitApp))
    End Sub

    Private Sub mnuCheckForUpdates_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuCheckForUpdates.ItemClick
        m_mainUI.StartManualUpdate()


    End Sub

    Private Sub mnuShowOptions_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuOptions.ItemClick
        m_mainUI.OpenToolExtrasConnections()
    End Sub


    Private Sub btnPageSetup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuPageSetup.ItemClick
        Try
            Using frm As New dlgReportManager
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "ReportManager", "ERROR while open Report Manager")
        End Try

    End Sub

    Private Sub btnStats_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuTopLists.ItemClick
        Try

            Dim frm As New frmModuleContainer(HWLModules.StatisticTop10)
            frm.ShowDialog()
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Error in Fixed Costs", "Fehler bei Statistiken")
        End Try


    End Sub

    Private Sub btnFixedCosts_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuFixedCosts.ItemClick
        Try

            Dim frm As New frmModuleContainer(HWLModules.FixedCosts)
            frm.ShowDialog()
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Error in Fixed Costs", "Fehler bei fixkosten")
        End Try
    End Sub



    Private Sub btnReports_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReports.ItemClick
        Try

            Dim frm As New frmFinanzen
            frm.ShowDialog()
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Cash_Flow", "Error while opening the Dialog 'Cash Flow'")
        End Try


    End Sub



    Private Sub BarButtonItem1_ItemClick_2(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        StartModule(HWLModules.Templates) ' Testweise mal die Templates einlesen
    End Sub

    ''' <summary>
    ''' Erstellt die Grafische Darstellung von Arbeitsmodulen, stellt einen Listener dar, der auf änderungen der Komponentenliste achtet und dann dynamisch die Tabs erzeugt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub m_mainUI_ModuleCollectionChanged(ByVal sender As HWLInterops.MainUI, ByVal e As HWLInterops.ModuleCollectionChangedEventArgs) Handles m_mainUI.ModuleCollectionChanged
        ModulManager(sender, e)

    End Sub

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        MainApplication.getInstance.JournalDocuments.CreateTransactionEntries()

    End Sub



    Private m_lastKnownSize As Size


    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If m_hideIfMinimized Then
            If Me.WindowState = FormWindowState.Minimized Then

                ShowNotifyIcon()
                Me.ShowInTaskbar = False
            End If
        Else
            m_lastKnownSize = Me.Size
        End If

    End Sub

    Private Sub frmMain_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        m_lastKnownSize = Me.Size

    End Sub

    Private Sub frmMain_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd
        MainApplication.getInstance.Settings.SaveFormsPos(Me)
    End Sub

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        ' Nun überwachungsprozesse starten
        m_mainUI.StartProcesses()
        AddHandler System.Windows.Forms.Application.Idle, AddressOf StartShowOverdueTransactionNotification



        m_mainUI.CheckTestPeriod()
        AddHandler System.Windows.Forms.Application.Idle, AddressOf LoadschedulerinBackground

        m_lastKnownSize = Me.Size

        ' Minimiert-Status für das "Ausblenden wenn minimiert" - Menü abholen
        m_hideIfMinimized = CBool(MainApplication.getInstance.Settings.GetSetting("HideIfMinimizes", "UI", "FALSE"))

        Me.IsFirstStart = True

        If Me.IsFirstStart Then

            Me.BeginInvoke(New MethodInvoker(Sub()
                                                 FirstStartPrintLayout()
                                             End Sub))
        End If




    End Sub

    ''' <summary>
    ''' Das Druck-Layout beim ersten mal aufrufen und initialisieren lassen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FirstStartPrintLayout()
        Try
            Dim dummy As New iucSimpleLayouteditor(m_mainUI)

            dummy.InitializeModule()

            dummy.SaveCurrentItem()
            dummy = Nothing
        Catch ex As Exception
        End Try

    End Sub



    ''' <summary>
    ''' Startet die Benachrichtung für üerfällige Transaktionen beim Start
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub StartShowOverdueTransactionNotification(ByVal sender As Object, ByVal e As EventArgs)
        RemoveHandler System.Windows.Forms.Application.Idle, AddressOf StartShowOverdueTransactionNotification

        If MainApplication.getInstance.Settings.TransactionSettings.SendUnpaidNoticeOnStartup Then
            m_mainUI.StartShowOverdueTransactionsThread()
        End If

    End Sub


    Private Sub LoadschedulerinBackground(ByVal sender As Object, ByVal e As EventArgs)
        If MainApplication.getInstance.Appointments.Session.IsObjectsLoading Then
            System.Threading.Thread.Sleep(2000)
            Exit Sub
        End If
        RemoveHandler System.Windows.Forms.Application.Idle, AddressOf LoadschedulerinBackground ' Diesen Handelr wieder entfernen
        Dim schedulerModulePane As iucMainModule

        schedulerModulePane = m_mainUI.OpenWorkingPane(HWLModules.Scheduler)
        ' dieses nur verstecken und einschalten 
        m_mainUI.CloseModule(schedulerModulePane)

    End Sub



    Private Sub btnLastActiveItems_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenuLastActiveItems.Popup
        Dim sw As New Stopwatch
        sw.Start()

        btnMenuLastActiveItems.ItemLinks.Clear()


        Dim lf As String() = New String(0) {vbCrLf}

        m_mainUI.MRUManager.RecentlyModifiedElements.Sort()
        Dim buttons As New List(Of DevExpress.XtraBars.BarItem)

        For Each item As MRUElement In m_mainUI.MRUManager.RecentlyModifiedElements ' Alle darin enthaltnen Elemente durchgehen
            If item.Element Is Nothing Then Continue For

            Dim lastItemButton As New DevExpress.XtraBars.BarButtonItem()

            Dim caption As String = item.Element.ToString

            ' Maximale Länge erlauben
            If caption.Length > 50 Then
                caption = caption.Substring(0, 50) & "..."
            End If

            lastItemButton.Caption = caption
            lastItemButton.Tag = item.Element
            lastItemButton.Glyph = MainUI.GetItemSmallImage(item.Element)

            If TypeOf item.Element Is Kernel.JournalDocument Then
                If CType(item.Element, Kernel.JournalDocument).IsCanceled Then
                    lastItemButton.Appearance.Font = New Font(lastItemButton.Appearance.Font, lastItemButton.Appearance.Font.Style Or FontStyle.Strikeout)

                End If
            End If

            If TypeOf item.Element Is Kernel.Transaction Then
                If CType(item.Element, Kernel.Transaction).IsCanceled Then
                    lastItemButton.Appearance.Font = New Font(lastItemButton.Appearance.Font, lastItemButton.Appearance.Font.Style Or FontStyle.Strikeout)

                End If
            End If


            buttons.Add(lastItemButton)

            AddHandler lastItemButton.ItemClick, AddressOf OnLastItemButtonClick
            If buttons.Count > 15 Then Exit For

        Next
        btnMenuLastActiveItems.AddItems(buttons.ToArray)


        If btnMenuLastActiveItems.ItemLinks.Count = 0 Then
            btnMenuLastActiveItems.AddItem(New DevExpress.XtraBars.BarButtonItem(Nothing, "Leer")) 'TODO: NLS
        End If

        sw.Stop()
        Debug.Print("Aufbau der MRU-Liste: " & sw.Elapsed.ToString)
    End Sub

    Private Sub OnLastItemButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        m_mainUI.OpenElementWindow(CType(e.Item.Tag, Data.StaticItem))

    End Sub

    Private Sub btnShowPageSetup_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuShowPageSetup.ItemClick
        m_mainUI.OpenWorkingPane(HWLModules.PageSettings)
    End Sub

    Private Sub BarButtonItem6_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuLockApplication.ItemClick
        Dim frm As New frmUnLock
        frm.ShowDialog()

    End Sub

    Private Sub btnDataImport_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuDataImportExport.ItemClick
        Try

            Using frm As New frmImportExportManager
                frm.ShowDialog()
            End Using

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.Critical, "AddIns", ex.Message, ex.ToString)
        End Try

    End Sub

    Private Sub btnActivateAllArticles_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim sql As String = "UPDATE MATERIALLISTE SET IsActive=1"
        Dim sw As New Stopwatch
        sw.Start()
        MainApplication.getInstance.Database.ExcecuteNonQuery(sql)
        sw.Stop()
        Debug.Print("Das setzen hat: " & sw.Elapsed.ToString & " gedauert")

    End Sub

    Private Sub basesearchPanel_SearchTextChanged(ByVal sender As System.Object, ByVal e As ClausSoftware.HWLInterops.SearchTextEventArgs) Handles basesearchPanel.SearchTextChanged

        m_mainUI.StartGlobalSearchThread(e.Text)

    End Sub

    Private Sub basesearchPanel_SetNextControl(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles basesearchPanel.SetNextControl
        ' Wurde ausgelöst, wenn der Anwendr auf die "Down" - Taste drückt. 
        Me.tabControl.SelectedTabPage.Controls(0).Focus()


    End Sub



    Delegate Sub deleModulestarter(ByVal sender As MainUI, ByVal e As ModuleCollectionChangedEventArgs)
    Private ModulManagerstarter As New deleModulestarter(AddressOf ModulManager)

    Private m_workPaneTabPages As New List(Of iucMainModule) ' eventuell später in eigene Klasse setzen


    ''' <summary>
    ''' Baut neue Module auf
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ModulManager(ByVal sender As MainUI, ByVal e As ModuleCollectionChangedEventArgs)
        If Me.InvokeRequired Then

            Me.Invoke(ModulManagerstarter, sender, e)
            Exit Sub
        End If

        If MainApplication.Session.IsObjectsLoading Then Exit Sub

        Dim sw As New Stopwatch
        sw.Start()
        ' Wurde vom Programmcode aus ein anderes Tab gewählt, dann dieses nach vorne holen
        If e.ChangeType = enumChangeType.Selected Then
            Dim selectedPage As DevExpress.XtraTab.XtraTabPage = Nothing
            For Each selectedPage In tabControl.TabPages
                If selectedPage.Tag Is e.WorkPane Then
                    tabControl.SelectedTabPage = selectedPage
                    selectedPage.PageVisible = True

                    Exit For
                End If
            Next

            tabControl.SelectedTabPage = selectedPage
            ' Wurde die Seite nicht angezeigt, dann eventuell noch schnell hinzufügen (Thread-Prpblem in zus. mit der Suche') 
            If tabControl.SelectedTabPage Is Nothing Then
                e.ChangeType = enumChangeType.Added
            End If
        End If

        If e.ChangeType = enumChangeType.Added Then
            Dim newpage As DevExpress.XtraTab.XtraTabPage = Nothing

            If TypeOf e.WorkPane.WorkingItem Is iucScheduler Then ' Den Scheduler nur einmal laufen lasen, das Tab also Wiederverwenden (sichtbar machen)
                For Each tabPage As DevExpress.XtraTab.XtraTabPage In tabControl.TabPages
                    If TypeOf CType(tabPage.Tag, iucMainModule).WorkingItem Is iucScheduler Then
                        tabPage.PageVisible = True
                        newpage = tabPage
                        Exit For
                    End If
                Next
            End If

            ' Neuen Tab aufbauen
            If newpage Is Nothing Then
                newpage = GetNewTab(e.WorkPane)
                AddHandler e.WorkPane.DisplayTextChanged, AddressOf TabDisplayTextChanged

                ' Den ersten Start des Terminkalenders nicht anzeigen 
                If TypeOf e.WorkPane.WorkingItem Is iucScheduler Then
                    newpage.PageVisible = False
                End If

                MainApplication.getInstance.Languages.SetTextOnControl(newpage) ' Texte für alles setzen
                m_workPaneTabPages.Add(e.WorkPane)

                MainApplication.getInstance.SendMessage(newpage.Text & " " & GetText("msgReady", "bereit"))
            End If

            tabControl.SelectedTabPage = newpage
        End If

        If e.ChangeType = enumChangeType.Removed Then


            ' Den Scheduler nicht entfernen, der bleibt im Hintergrund imemr aktiv
            If TypeOf e.WorkPane.WorkingItem Is iucScheduler Then ' Den Scheduler nur einmal laufen lasen, das Tab also Wiederverwenden (sichtbar machen)
                For Each tabPage As DevExpress.XtraTab.XtraTabPage In tabControl.TabPages
                    If TypeOf CType(tabPage.Tag, iucMainModule).WorkingItem Is iucScheduler Then
                        tabPage.PageVisible = False

                        Exit For
                    End If
                Next
            Else


                ' suche das Tab und entferne es
                Dim tabsToRemove As New List(Of DevExpress.XtraTab.XtraTabPage)
                For Each tabPage As DevExpress.XtraTab.XtraTabPage In tabControl.TabPages
                    tabsToRemove.Add(tabPage)
                Next

                For Each itemTabPage As DevExpress.XtraTab.XtraTabPage In tabsToRemove
                    If itemTabPage.Tag Is e.WorkPane Then

                        RemoveHandler e.WorkPane.DisplayTextChanged, AddressOf TabDisplayTextChanged

                        tabControl.TabPages.Remove(itemTabPage)
                        m_workPaneTabPages.Remove(e.WorkPane)
                    End If
                Next
            End If
        End If
        sw.Stop()
        Debug.Print("Aufbauen des Moduls hat: " & sw.Elapsed.ToString & " gedauert.")
    End Sub


    Private Sub btnOpenUserFeedbackSite_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuOpenUserFeedbackSite.ItemClick
        Process.Start(wwwUserFeedbackSite)

    End Sub


    Private Sub tabControl_SelectedPageChanging(ByVal sender As Object, ByVal e As DevExpress.XtraTab.TabPageChangingEventArgs) Handles tabControl.SelectedPageChanging
        ' nach dem Tab-Wechsel die Statusleise säubern. 
        MainApplication.getInstance.SendMessage("")

    End Sub

    Private Sub lblCurrentConectionstatusBar_ItemDoubleClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles lblCurrentConectionstatusBar.ItemDoubleClick
        m_mainUI.OpenToolExtrasConnections()

    End Sub

    Private Sub btnShowTodayToolBar_CheckedChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuShowTodayToolBar.CheckedChanged

        Dim ms As iucHomeScreen = m_mainUI.MainScreen
        If ms IsNot Nothing Then
            ms.ShowTodayBar = btnMenuShowTodayToolBar.Checked
        End If
    End Sub

    Private Sub btnView_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenuView.Popup
        Dim checkValue As Boolean
        ' Vor dem öffnen den aktuellen status anzeigen lassen 
        Dim ms As iucHomeScreen = m_mainUI.MainScreen
        If ms IsNot Nothing Then
            checkValue = ms.ShowTodayBar
        End If

        btnHideIfMinimized.Checked = m_hideIfMinimized

        btnMenuShowTodayToolBar.Checked = checkValue
        TranslateMenuItems(btnMenuView)
    End Sub

    Private Sub SetProgress(ByVal text As String, ByVal value As Integer, ByVal maxValue As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New ShowstatusProgress(AddressOf SetProgress), text, value, maxValue)
            Exit Sub
        End If
        Dim prg As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar = CType(BarEditItem2.Edit, DevExpress.XtraEditors.Repository.RepositoryItemProgressBar)


        If BarEditItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never Then
            BarEditItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If


        prg.Maximum = maxValue
        BarEditItem2.EditValue = value

        BarEditItem2.Refresh()


    End Sub

    Private Sub TranslateMenuItems_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenuFile.Popup, btnMenuView.Popup, btnMenuReports.Popup, btnMenuHelp.Popup, btnMenuExtras.Popup
        Dim bsItem As DevExpress.XtraBars.BarSubItem = CType(sender, DevExpress.XtraBars.BarSubItem)


        TranslateMenuItems(bsItem)
    End Sub

    ''' <summary>
    ''' Übersetzt das Kontextmenü
    ''' </summary>
    ''' <param name="subItem"></param>
    ''' <remarks></remarks>
    Private Sub TranslateMenuItems(ByVal subItem As DevExpress.XtraBars.BarItem)

        Static Dim translatedMenuItems As New List(Of Object)

        If Not translatedMenuItems.Contains(subItem) Then
            translatedMenuItems.Add(subItem)
        Else
            Exit Sub
        End If

        subItem.Caption = GetText(subItem.Name, subItem.Caption)

        If TypeOf subItem Is DevExpress.XtraBars.BarSubItem Then

            For Each item As DevExpress.XtraBars.BarItemLink In CType(subItem, DevExpress.XtraBars.BarSubItem).ItemLinks

                TranslateMenuItems(item.Item)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Zeigt das Notify-Icon an. 
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowNotifyIcon()
        NotifyIcon1.Visible = True

        NotifyIcon1.ShowBalloonTip(4000, Me.Text, GetText("msgApplicationNowMinimized", "{AppName} ist nun in der Symbolleiste."), ToolTipIcon.Info)

    End Sub

    Private Sub btnAboutBox_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAboutBox.ItemClick
        Using frm As New frmSplashScreen
            frm.AboutMode = True
            frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            frm.lblStatusMessage.Text = ""
            frm.Text = My.Application.Info.ProductName
            Dim result As DialogResult = frm.ShowDialog()
            Debug.Print("result:" & result)
        End Using

    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick

        If (Me.WindowState = FormWindowState.Minimized) Then
            Me.Size = m_lastKnownSize
            Me.WindowState = FormWindowState.Normal

        End If

        Me.ShowInTaskbar = True

        NotifyIcon1.Visible = False


        ' Activate the form.
        Me.Activate()

    End Sub

    Private Sub btnHideIfMinimized_CheckedChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnHideIfMinimized.CheckedChanged
        m_hideIfMinimized = btnHideIfMinimized.Checked
        MainApplication.getInstance.Settings.SetSetting("HideIfMinimizes", "UI", m_hideIfMinimized.ToString)
    End Sub

    Private Sub tabControl_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles tabControl.SelectedPageChanged
        If e.Page IsNot Nothing Then
            If e.Page.Tag IsNot Nothing Then
                m_mainUI.ActiveWorkPane = TryCast(e.Page.Tag, iucMainModule).WorkingItem
            Else
                '   Debug.Assert(False, "Tag des Tabs war leer!")
                ' Dann war es die startseite ? 
            End If


        End If


    End Sub

    ''' <summary>
    ''' Hintergrundbild für die Stammseite festlegen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckBackgroundImage()
        ' Default-Bild einfügen (Kann uch aus dem Dateisystem kommen, falls hinterlegt)
        If MainApplication.ApplicationName.StartsWith("HWL") Then
            m_mainUI.MainScreen.PanelBackgroundImage = My.Resources.bogenhigh_transparent
        Else
            m_mainUI.MainScreen.PanelBackgroundImage = My.Resources.PowerBüroMainScreen
        End If

        ' Nun im Dateisystem suchen. 
        Try
            Dim image As System.Drawing.Image = Nothing
            Dim base As String = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)

            base &= "\" & MainApplication.ApplicationName
            MainApplication.getInstance.log.WriteLog("Suche angepasstes Hintergrundbild in: " & base)

            base &= "\background"  ' Dateinamen bilden

            If System.IO.File.Exists(base & ".png") Then image = System.Drawing.Image.FromFile(base & ".png")
            If System.IO.File.Exists(base & ".jpg") Then image = System.Drawing.Image.FromFile(base & ".jpg")
            If System.IO.File.Exists(base & ".bmp") Then image = System.Drawing.Image.FromFile(base & ".bmp")
            If System.IO.File.Exists(base & ".gif") Then image = System.Drawing.Image.FromFile(base & ".gif")

            If image IsNot Nothing Then
                m_mainUI.MainScreen.PanelBackgroundImage = image
            End If


        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "UI", "Getting external Background  Image for Home workpane failed")
        End Try

    End Sub

    ''' <summary>
    ''' Setzt das Datenbank-Symbol gemäs aktueller Verbindungseigenschaften
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DatabaseStateChanged(ByVal sender As Object, ByVal e As DatabaseConnectionStateChanged)
        SetConnectionstatusText()
    End Sub


    Private Sub DatabaseConnectionLost(ByVal sender As Object, ByVal e As DatabaseErrorEventArgs)
        ' wird nach einem "Database Connection Changed" - event gefeuert. 
        ' Sollte einen Text angeben

        If MainApplication.getInstance.DatabaseConnectionstate <> DBConnectionState.OK Then
            MessageBox.Show(GetText("msgDatabaseConnectionexecpectedlyLost", "Die Datenbankverbindung wurde unterbrochen- der Vorgang konnte nicht ausgeführt werden" & vbCrLf &
                                    "Untersuchen Sie die Verbindung zur Datenbank."), GetText("msgHeadlineDatabseConnectionLost", "Datenbankverbindung verloren"), MessageBoxButtons.OK, MessageBoxIcon.Hand)

        End If

    End Sub

    ''' <summary>
    ''' Setzt den Text der Datenbankverbinung in der Statusleiste
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetConnectionstatusText()
        Dim connectionDisplayName As String
        If MainApplication.getInstance.Connections.WorkConnection.Servertype = Tools.enumServerType.Access Then
            connectionDisplayName = GetText("localDatabaseFile", "Lokal")
        Else
            connectionDisplayName = GetText("remoteDatabaseServer", "Server")
        End If

        ' Datenbank-Status ermitteln
        Dim failureText As String
        If MainApplication.getInstance.DatabaseConnectionstate = DBConnectionState.OK Then
            failureText = String.Empty
            lblCurrentConectionstatusBar.Glyph = My.Resources.Network_Harddisk16x16
        Else
            failureText = " -" & GetText("warningDatabaseUnavailable", "nicht verfügbar!")

            lblCurrentConectionstatusBar.Glyph = My.Resources.Network_Harddisk__Warning_16x16
        End If

        lblCurrentConectionstatusBar.Caption = connectionDisplayName & ": " & MainApplication.getInstance.Connections.WorkConnection.AliasName & failureText

        Dim info As New DevExpress.Utils.SuperToolTipSetupArgs(lblCurrentConectionstatusBar.SuperTip)
        info.Title.Text = MainApplication.getInstance.Connections.WorkConnection.AliasName & failureText
        info.Contents.Text = MainApplication.getInstance.Connections.WorkConnection.GetConnectionDescription

        ' Geschwindigkeit anzeigen lassen 
        If MainApplication.getInstance.Connections.WorkConnection.Servertype = Tools.enumServerType.MySQL And MainApplication.getInstance.DatabaseConnectionstate = DBConnectionState.OK Then
            info.Contents.Text &= vbCrLf & MainApplication.getInstance.LastDatabaseSpeed & "ms"
        End If

        lblCurrentConectionstatusBar.SuperTip.Setup(info)

    End Sub

    Private Sub ItemstatusText_ItemDoubleClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ItemstatusText.ItemDoubleClick
        Process.Start(MainApplication.getInstance.log.LogFilePath)
    End Sub



    Private Sub btnCallerList_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCallerList.ItemClick
        Try
            If m_showCallersListform Is Nothing Then
                m_showCallersListform = New HWLInterops.frmCallersList(m_mainUI)
                m_showCallersListform.Calls = New Kernel.PhoneCalls(MainApplication.getInstance)
            Else
                m_showCallersListform.Calls.Reload()
            End If

            m_showCallersListform.Visible = False

            m_showCallersListform.Show(Me)
            If m_showCallersListform.WindowState = FormWindowState.Minimized Then
                m_showCallersListform.WindowState = FormWindowState.Normal
            End If
        Catch ex As Exception

            MainApplication.getInstance.log.WriteLog(ex, "ShowCallerList", "Fehler beim Anzeigen der Anruferliste.")
        End Try

    End Sub

    ''' <summary>
    ''' Verfolgt geändrte Systemeinstellungen und passt die Oberfläche Dynamisch an
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SettingChangedWatcher(ByVal sender As Object, ByVal e As Kernel.SettingChangedEventArgs)

        If e.SettingName = "MonitorPhoneLines" Then
            ShowCallersListIcon()
            Exit Sub
        End If

        If e.SettingName = "MonitorPhoneLinesLastNumber" Then
            SetIncommingCallIcon()
        End If

    End Sub

    Private Sub btnMenuInvokeHelp_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuInvokeHelp.ItemClick

        m_mainUI.OpenHelpFile()

    End Sub


    Private Sub splMainSplitter_SplitterPositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles splMainSplitter.SplitterPositionChanged
        MainApplication.getInstance.Settings.SetSetting(splMainSplitter.Name, "MainForm", splMainSplitter.SplitterPosition.ToString)

    End Sub

    Private Sub btnRemoveAllImportetItems_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRemoveAllImportetItems.ItemClick
        If MessageBox.Show("Es werden alle Artikel und Artikelgruppen gelöscht, die durch einen Datanorm-Import angelegt wurden!" &
                           "Möchten Sie fortfahren?", "Datamorm-Artikel löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            Dim removedItemCount As Integer
            Dim removedGroupCount As Integer

            removedItemCount = MainApplication.getInstance.Database.ExcecuteNonQuery("DELETE FROM Materialliste where quelleDatanorm=1")
            removedGroupCount = MainApplication.getInstance.Database.ExcecuteNonQuery("DELETE FROM material_gruppen where quelleDatanorm=1")

            MainApplication.getInstance.SendMessage("Alle Datanorm-Artikel entfernt: " & removedItemCount & " Artikel, und " & removedGroupCount & " Gruppen.")


        End If
    End Sub


    Private Sub btnStartTeamViewer_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnStartTeamViewer.ItemClick
        Try
            MainApplication.getInstance.log.WriteLog("Starte Teamviewer per Download")
            Process.Start("http://www.teamviewer.com/download/TeamViewerQS_de.exe")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim sw As New Stopwatch
        sw.Start()

        For Each item As Kernel.JournalDocument In MainApplication.getInstance.JournalDocuments
            If item.DocumentType = enumJournalDocumentType.Angebot Then
                item.Delete()
            End If

        Next

        Try
            Dim journalDocumentCounter As Integer

            Do While journalDocumentCounter < 5000
                Dim newJournalDocument As Kernel.JournalDocument = MainApplication.getInstance.JournalDocuments.GetNewItem

                newJournalDocument.DocumentType = enumJournalDocumentType.Rechnung

                newJournalDocument.Address = MainApplication.getInstance.Adressen(0)
                Dim newgroup As Kernel.JournalArticleGroup = newJournalDocument.ArticleGroups.GetNewItem
                newgroup.HeaderText = "so ein Kopftext"


                newJournalDocument.ArticleGroups.Add(newgroup)

                ' mindestends 20 Artikel einbauen
                Dim articleCounter As Integer
                articleCounter = 0
                Do While articleCounter < 20
                    Dim newArticle As Kernel.JournalArticleItem = newgroup.ArticleList.GetNewItem
                    newArticle.BasePrice = 123
                    newArticle.ItemMemoText = "Lorem Ipsum .. "
                    newArticle.ItemName = "Langtext des Artikels Langtext des Artikels  Langtext des Artikels  Langtext des Artikels"
                    articleCounter += 1
                    newArticle.SinglePriceBeforeTax = CDec(Rnd() * 1000)
                    newArticle.TaxRate = MainApplication.getInstance.TaxRates.GetNormalTax

                    newgroup.AddJournalItem(newArticle)
                    articleCounter += 1
                Loop

                journalDocumentCounter += 1

                newJournalDocument.Save()

                Debug.Print("erstelle Journaldokument: " & journalDocumentCounter & "/5000""")
            Loop

        Catch ex As Exception

        Finally
            sw.Stop()
            Debug.Print("Anlegen der Testdokumente hat " & sw.Elapsed.ToString & " gedauert.")

        End Try

    End Sub

    Private m_eventLogForm As frmEventLog

    Private Sub btnEvntLog_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEvntLog.ItemClick

        If m_eventLogForm Is Nothing Then
            m_eventLogForm = New frmEventLog
        End If

        If Not m_eventLogForm.Visible Then
            m_eventLogForm.Show()
        End If

    End Sub
End Class
