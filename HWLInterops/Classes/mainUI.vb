Imports ClausSoftware.Kernel

Delegate Sub OnAction()

''' <summary>
''' Stellt die Grafische Steuerung der Oberfläche bereit
''' </summary>
''' <remarks></remarks>
Public Class MainUI
    ''' <summary>
    ''' Wird ausgelöst, wenn die Auflistung der geladenen Module sich geändert hat, zB neue werden erstellt oder es werden welche entfernt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Event ModuleCollectionChanged(ByVal sender As MainUI, ByVal e As ModuleCollectionChangedEventArgs)

    ''' <summary>
    ''' Signalisiert ein neuen eingehenen Anruf
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event NewIncommingCall(ByVal sender As Object, ByVal e As EventArgs)


    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Private m_printingManager As Printing.PrintingManager


    ''' <summary>
    ''' Enthält eine Auflistung der geladenen Module
    ''' </summary>
    ''' <remarks></remarks>
    Private m_modulesList As New List(Of iucMainModule)

    Private m_alerter As AlertHelper

    Private WithEvents m_AlerterTimer As New Timers.Timer(5 * 60 * 1000)
    ''' <summary>
    ''' stellt einen Update-Planer zur Verfügung, plant und führt Updates aus
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
    Private WithEvents m_updateManager As New Update.UpdateManager

    ''' <summary>
    ''' Stellt die Instanz des Hauptformulares dar
    ''' </summary>
    ''' <remarks></remarks>
    Private m_mainform As System.Windows.Forms.Form

    ''' <summary>
    ''' Enthält eine Instanz des CAPI (ISDN) - Treibers
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
    Private m_myPhony As Telephony.CAPIPhony

    ''' <summary>
    ''' stellt eine LIste mit den zuletzt verwendeten elementen zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
    Private WithEvents m_mruManager As MRUElementManager

    ''' <summary>
    ''' Enthält eine Auflistung mit IDs mit Ereignissen, die bereits als Notify-Meldung ausgegeben wurden
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
    Private m_dontNotifyAnyMore As New List(Of String)

    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
    Private m_tasksModule As frmModuleContainer

    ''' <summary>
    ''' Sendet eine Anforderung, die suchbar zu focusssieren
    ''' </summary>
    ''' <param name="mainUI"></param>
    ''' <param name="Empty"></param>
    ''' <remarks></remarks>
    Event FocusSearchBar(ByVal mainUI As MainUI, ByVal Empty As EventArgs)

    Private m_ActiveWorkPane As mainControlContainer
    ''' <summary>
    ''' Ruft das aktuell aktive Workmodule ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ActiveWorkPane As mainControlContainer
        Get
            Return m_ActiveWorkPane
        End Get
        Set(ByVal value As mainControlContainer)
            m_ActiveWorkPane = value
        End Set
    End Property

    Public Sub OpenTasksList()
        OpenTasksList(Nothing)
    End Sub

    ''' <summary>
    ''' Öffnet den Dialog des Aufgabenplaners und öffnet den angegebenen Task
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub OpenTasksList(task As Kernel.Task)

        If m_tasksModule Is Nothing OrElse m_tasksModule.IsDisposed Then
            m_tasksModule = New frmModuleContainer(HWLModules.Tasks)

        End If
        m_tasksModule.Show() ' nicht Modal 
        m_tasksModule.BringToFront()

        CType(m_tasksModule.WorkingItem, iucTasks).LoadCurrentItem(task)

    End Sub

    ''' <summary>
    ''' Ruft ein Instanz des Telefonie-Objektes ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Telephony As Telephony.CAPIPhony
        Get
            Return m_myPhony
        End Get
    End Property

    ''' <summary>
    ''' ruft eine Instanz des Hauptformulares ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Mainform As Form
        Get
            Return m_mainform
        End Get
    End Property


    ''' <summary>
    ''' Ruft einen Manager ab, der eine Auflistung der zuletzt verwendeten Elemente enthält
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MRUManager() As MRUElementManager
        Get
            If m_mruManager Is Nothing Then
                m_mruManager = New MRUElementManager
            End If
            Return m_mruManager
        End Get
    End Property

    ''' <summary>
    ''' Prüft den Test-Zeitraum und beendet die Testphase
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckTestPeriod()

    End Sub

    ''' <summary>
    ''' Beendet die Applikation augenblicklich
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Quit()
        Me.OpenWorkingPane(HWLModules.ExitApp)
        System.Windows.Forms.Application.Exit()
    End Sub

    ''' <summary>
    ''' Ruft zu einem gegebenen element das kleine Symbol ab
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetItemSmallImage(ByVal item As Data.StaticItem) As System.Drawing.Image
        If TypeOf item Is Transaction Then
            Return My.Resources.Profits_32x32
        End If

        If TypeOf item Is CashJournalItem Then
            Return My.Resources.Price_List_16x16
        End If

        If TypeOf item Is JournalDocument Then
            Return My.Resources.Contract_32x32
        End If

        If TypeOf item Is Adress Then
            Return My.Resources.Contact_Card_32x32
        End If

        If TypeOf item Is Letter Then
            Return My.Resources.Notepad_16x16
        End If

        If TypeOf item Is Article Then
            Return My.Resources.Configuration_Tools_16x16
        End If

        If TypeOf item Is Reminder Then
            Return My.Resources.Configuration_Tools_16x16
        End If

        If TypeOf item Is Appointment Then
            Return My.Resources.Calendar2Events_16x16
        End If

        Return Nothing
    End Function
    ''' <summary>
    ''' Ruft den Typenamen des angegebenen Elementes ab
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetItemTypeName(ByVal item As Data.StaticItem) As String
        If TypeOf item Is Transaction Then
            Return MainApplication.getInstance.Languages.GetText("TypeTransaction", "Geschäftsvorfall")
        End If

        If TypeOf item Is CashJournalItem Then
            Return MainApplication.getInstance.Languages.GetText("TypeCashJournalItem", "Geschäftsvorfall (Kasse)")
        End If

        If TypeOf item Is JournalDocument Then
            Dim document As JournalDocument = CType(item, JournalDocument)
            Return document.DocumentTypeText
        End If

        If TypeOf item Is Adress Then
            Return MainApplication.getInstance.Languages.GetText("TypeAdress", "Kontakt")
        End If

        If TypeOf item Is Letter Then
            Return MainApplication.getInstance.Languages.GetText("TypeLetter", "Korrespondenz")

        End If

        If TypeOf item Is Article Then
            Return MainApplication.getInstance.Languages.GetText("TypeArticle", "Artikel")
        End If

        If TypeOf item Is Reminder Then
            Return MainApplication.getInstance.Languages.GetText("TypeReminder", "Mahnung")
        End If

        Return Nothing
    End Function


    Private Sub TimerElapsed(ByVal sender As Object, ByVal e As EventArgs) Handles m_AlerterTimer.Elapsed
        ' Hier auf fällige Rechnungen schauen

        ' eine Anzeige für eine Rechnung kein zweites mal anzeigen alssen !
        CType(sender, Timers.Timer).Stop()
        Debug.Print("System-Timer (Delayed Invoices ) elapsed!")

        'Refreshsystemevents()
        CType(sender, Timers.Timer).Start()

    End Sub

    Public Sub StartInvokingsystemAlerts()
        Dim target As New OnAction(AddressOf ShowOverdueTransactionNotifications)
        target.BeginInvoke(Nothing, Nothing)
    End Sub

    ''' <summary>
    ''' Startet die suche nach überfälligen TRansaktionen asynchron
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartShowOverdueTransactionsThread()
        Dim t As New System.Threading.Thread(New Threading.ThreadStart(AddressOf ShowOverdueTransactionNotifications))
        t.Start()

    End Sub

    ''' <summary>
    ''' Aktualisiert die Systembenachritigungen, indem alle Nachrichten erneut gesendet werden
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowOverdueTransactionNotifications()
        Dim itemsCounter As Integer

        Dim maxAlertcount As Integer = 5
        MainApplication.getInstance.Transactions.Filter = Nothing
        MainApplication.getInstance.Transactions.Criteria = Nothing

        For Each item As Transaction In MainApplication.getInstance.Transactions
            If item.IsOverdue And Not item.DontCheckPayments Then

                ' Benachrichtigen zu diesem Element nicht mehr anzeigen lassen 
                If m_dontNotifyAnyMore.Contains(item.Key) Then Continue For
                m_dontNotifyAnyMore.Add(item.Key)

                itemsCounter += 1
                If itemsCounter < maxAlertcount Then
                    ' TODo: NLS

                    Dim element As New AlertElement
                    element.Caption = "Forderung überfällig" 'TODO: NLS
                    element.Text = item.ItemDisplayNumber & ": " & item.AddressDisplayText & vbCrLf & item.Text & vbCrLf & "Offener Betrag:" & item.UnpaidAmmount.ToString("c")
                    element.Image = My.Resources.calendar_warning_32x32
                    element.Tag = item
                    element.OnClick = AddressOf AlertTransactionClick
                    Me.Alert.ShowAlert(element)

                Else

                    ' Kein weiteren Alert anzeigen lassen 
                End If
            End If
        Next

        ' Falls nicht alle angezeigt werden konnten
        If itemsCounter > maxAlertcount Then
            'TODO: NLS
            Me.Alert.ShowAlert("Forderung überfällig", "Weitere " & itemsCounter - maxAlertcount & " offene Forderungen.", My.Resources.Symbol_Warning_2_32x32)
        End If

    End Sub


    Public Sub StartGlobalSearchThread(ByVal plainSearchText As String)

        Dim t As New Threading.Thread(AddressOf StartGlobalSearchTaskInternal)
        t.Name = "Start global search" ' dem Thread einen Namen geben

        t.Start(plainSearchText)

    End Sub

    Private Sub StartGlobalSearchTaskInternal(ByVal plainSearchText As Object)

        StartGlobalSearch(CStr(plainSearchText))
    End Sub

    ''' <summary>
    ''' Startet eine globale Suche
    ''' </summary>
    ''' <param name="plainSearchText">Der unbearbeitete Suchtext, wie vom Anwedner angegeben</param>
    ''' <remarks></remarks>
    Public Sub StartGlobalSearch(ByVal plainSearchText As String)
        plainSearchText = plainSearchText.Trim ' keine führenden oder folgenden Leerzeichen suchen


        ' Alle  Adresen (Name, Firmenname) 
        ' Alle Rechnungen (Nach Adressen-Name; , HeadText , FussText, Name) 
        ' Alle Forderungen (nach Adresse, Bezeichnung) 
        ' Alle Kassenbucheinträge
        SyncLock Me
            ' Jeweils 10 Stück, dann ein "Mehr..." einblenden
            If Not MainApplication.getInstance.PeriodicCheckConnection(True) Then Exit Sub

            ' In BaseItems ein "Search(Parameter as string) einbetten ? 
            Dim searchModule As iucMainModule = Me.OpenWorkingPane(HWLModules.GlobalSearch)
            Dim SearchPanel As iucGlobalSearch = CType(searchModule.WorkingItem, iucGlobalSearch)
            If SearchPanel Is Nothing Then Exit Sub

            SearchPanel.HighligtedSearchtext = plainSearchText

            SearchPanel.StartInfoMessageProcess()
            'Adressen
            '-----------------
            MainApplication.getInstance.SendMessage("Suche in Adressen...") 'TODO: NLS
            Dim searchedAdresses As Data.BaseCollection(Of Adress) = MainApplication.getInstance.Adressen.SearchByParameter(plainSearchText)

            For Each item As Data.StaticItem In searchedAdresses
                SearchPanel.QueryResult.Add(item)
            Next
            SearchPanel.RefreshGrid()


            ' Journaldokument
            '----------------
            MainApplication.getInstance.SendMessage("Suche in Journaldokumente...") 'TODO: NLS
            Dim searchedDocuments As Data.BaseCollection(Of JournalDocument) = MainApplication.getInstance.JournalDocuments.SearchByParameter(plainSearchText)
            searchedDocuments.Sorting.Add(New DevExpress.Xpo.SortProperty("ID", DevExpress.Xpo.DB.SortingDirection.Descending))

            For Each item As Data.StaticItem In searchedDocuments
                SearchPanel.QueryResult.Add(item)
            Next
            SearchPanel.RefreshGrid()

            'Vorderungen/Verbindlichkeiten
            '---------------- 
            MainApplication.getInstance.SendMessage("Suche in Geschäftsvorfälle...") 'TODO: NLS
            Dim searchedTransactions As Data.BaseCollection(Of Transaction) = MainApplication.getInstance.Transactions.SearchByParameter(plainSearchText)
            searchedTransactions.Sorting.Add(New DevExpress.Xpo.SortProperty("ID", DevExpress.Xpo.DB.SortingDirection.Descending))

            For Each item As Data.StaticItem In searchedTransactions
                SearchPanel.QueryResult.Add(item)
            Next
            SearchPanel.RefreshGrid()

            ' Kasse
            '----------------
            Dim searchedCashActions As Data.BaseCollection(Of CashJournalItem) = MainApplication.getInstance.CashJournal.SearchByParameter(plainSearchText)

            For Each item As Data.StaticItem In searchedCashActions
                SearchPanel.QueryResult.Add(item)
            Next
            SearchPanel.RefreshGrid()

            ' Artikelliste
            '----------------
            MainApplication.getInstance.SendMessage("Suche in Artikellliste..")
            Dim searchedArticles As Data.BaseCollection(Of Article) = MainApplication.getInstance.ArticleList.SearchByParameter(plainSearchText)
            searchedArticles.Sorting.Add(New DevExpress.Xpo.SortProperty("ID", DevExpress.Xpo.DB.SortingDirection.Descending))

            For Each item As Data.StaticItem In searchedArticles
                If item IsNot Nothing Then
                    SearchPanel.QueryResult.Add(item)
                End If

            Next
            SearchPanel.RefreshGrid()

            SearchPanel.EndSearch()
            MainApplication.getInstance.SendMessage(GetText("msgSearchEnded", "Suche beendet."))
        End SyncLock

    End Sub

    ''' <summary>
    ''' wird auf eine Notification geklickt, dann wird dieser Handler aufgerufen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub AlertTransactionClick(ByVal sender As AlertElement)
        Dim claims As iucTransactions = CType(Me.OpenWorkingPane(HWLModules.Transactions).WorkingItem, iucTransactions)
        claims.ActiveItem = TryCast(sender.Tag, Transaction)


    End Sub

    ''' <summary>
    ''' Öffnet das angegebene element anhand der übergebenen ID
    ''' </summary>
    ''' <param name="elementID"></param>
    ''' <remarks></remarks>
    Public Sub OpenElementWindow(ByVal elementID As Integer)

    End Sub


    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Delegate Sub OpenelementWindowDele(ByVal element As Data.StaticItem)

    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Private m_OpenelementWindows As New OpenelementWindowDele(AddressOf OpenElementWindow)

    ''' <summary>
    ''' Öffnet das angegebene Êlement in einem neuen Tab. Falls es bereits ein Tab mit dioesem element gibt, wird dies in den Vordegrund gestezt 
    ''' </summary>
    ''' <param name="element">Die Basisklasse des elementes, das geöffnet werden soll</param>
    ''' <remarks></remarks>
    Public Sub OpenElementWindow(ByVal element As Data.StaticItem)
        OpenElementWindow(element, False)
    End Sub

    ''' <summary>
    ''' Öffnet das angegebene Êlement in einem neuen Tab. Falls es bereits ein Tab mit dioesem element gibt, wird dies in den Vordegrund gestezt 
    ''' </summary>
    ''' <param name="element">Die Basisklasse des elementes, das geöffnet werden soll</param>
    ''' <remarks></remarks>
    Public Sub OpenElementWindow(ByVal element As Data.StaticItem, ByVal foreNewWindow As Boolean)
        If element Is Nothing Then Exit Sub

        If m_mainform.InvokeRequired Then
            m_mainform.Invoke(m_OpenelementWindows, New Object() {element})
            Exit Sub
        End If

        'TODO: Falls bereits ein Fenster geöffnet ist; dann dieses auch wieder in den Vordergrund holen 
        If Not MainApplication.getInstance.PeriodicCheckConnection(True) Then Exit Sub

        If TypeOf element Is Adress Then
            Dim elementWindow As iucAddressBook
            elementWindow = CType(Me.OpenWorkingPane(HWLModules.Adressbook, foreNewWindow).WorkingItem, iucAddressBook)
            'Hier das Threading einbauen !
            ' Invoke..   (Für Telefonie)

            elementWindow.ActiveItem = CType(element, Adress)
            Exit Sub
        End If

        If TypeOf element Is Article Then
            Dim elementWindow As iucArticles
            elementWindow = CType(Me.OpenWorkingPane(HWLModules.Articles, foreNewWindow).WorkingItem, iucArticles)
            elementWindow.ActiveItem = CType(element, Article)
            Exit Sub
        End If

        If TypeOf element Is CashJournalItem Then
            Dim elementWindow As iucCashTransactions
            elementWindow = CType(Me.OpenWorkingPane(HWLModules.CashJournal, foreNewWindow).WorkingItem, iucCashTransactions)
            elementWindow.ActiveItem = CType(element, CashJournalItem)
            Exit Sub
        End If

        If TypeOf element Is Letter Then
            Dim elementWindow As iucLetters
            elementWindow = CType(Me.OpenWorkingPane(HWLModules.Letters, foreNewWindow).WorkingItem, iucLetters)
            elementWindow.ActiveItem = CType(element, Letter)
            Exit Sub
        End If

        If TypeOf element Is Transaction Then
            Dim elementWindow As iucTransactions
            elementWindow = CType(Me.OpenWorkingPane(HWLModules.Transactions, foreNewWindow).WorkingItem, iucTransactions)
            elementWindow.ActiveItem = CType(element, Transaction)
            Exit Sub
        End If

        If TypeOf element Is JournalDocument Then
            Dim elementWindow As Offers.iucBills
            elementWindow = CType(Me.OpenWorkingPane(HWLModules.Business, foreNewWindow).WorkingItem, Offers.iucBills)
            elementWindow.ActiveItem = CType(element, JournalDocument)
            Exit Sub
        End If

        Debug.Assert(False, "Der Modulcontainer war nicht gesetzt")

    End Sub


    ''' <summary>
    ''' Startet Systmprozesse, die zyklisch auf Ereignisse aufpassen (zB Fällige Rechnungen)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartProcesses()
        m_AlerterTimer.Start()

    End Sub

    ''' <summary>
    ''' Ruft ein Fenster vom Typ "iucMainModule" ab
    ''' </summary>
    ''' <param name="paneType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWorkItemPane(ByVal paneType As System.Type) As iucMainModule
        ' Falls bereits ein Fenster mit der Globalen Suche existiert, benutze dies
        For Each item As iucMainModule In Me.m_modulesList
            If paneType.Equals(item.WorkingItem.GetType) Then
                Return item
                Exit For
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Legt ein neues Panel mit dem angegebnen Arbeitsmodul an, ist bereits ein Panel dieses Typs geöffnet, wird dieses verwendet
    ''' </summary>
    Public Function OpenWorkingPane(ByVal modulTyp As HWLModules) As iucMainModule
        Return OpenWorkingPane(modulTyp, False)
    End Function

    ''' <summary>
    ''' Legt ein neues Panel mit dem angegebnen Arbeitsmodul an, ist bereits ein Panel dieses Typs geöffnet, wird dieses verwendet
    ''' </summary>
    ''' <remarks></remarks>
    Public Function OpenWorkingPane(ByVal modulTyp As HWLModules, ByVal openNewPanel As Boolean) As iucMainModule
        Try
            MainApplication.getInstance.SendMessage(GetText("msgStartupNewWorkingPane", "Starte neues Modul: ") & MainApplication.getInstance.Languages.GetText(modulTyp.ToString) & "...")

            '    SyncLock Me

            ' Bei beenden nicht auch noch die Datenbank prüfen
            If modulTyp <> HWLModules.ExitApp And modulTyp <> HWLModules.Scheduler AndAlso Not MainApplication.getInstance.PeriodicCheckConnection(True) Then Return Nothing

            Dim newWorkingControl As iucMainModule = Nothing
            Dim sw As New Stopwatch
            sw.Start()
            MainApplication.getInstance.log.WriteLog("Adding new Module: " & modulTyp.ToString)

            If modulTyp <> HWLModules.ExitApp Then

                If modulTyp = HWLModules.GlobalSearch Then
                    newWorkingControl = GetWorkItemPane(GetType(iucGlobalSearch))
                    ' Falls bereits ein Fenster mit der Globalen Suche existiert, benutze dies            
                End If

                'Terminkalender nur einmal öffnen, (Reminders würden sich sonst mehrfach öffnen)
                If modulTyp = HWLModules.Scheduler Then
                    newWorkingControl = GetWorkItemPane(GetType(iucScheduler))
                    ' Falls bereits ein Fenster mit der Globalen Suche existiert, benutze dies

                End If


                If Not openNewPanel Then
                    newWorkingControl = GetWorkItemPane(GetTypeOfWorkpane(modulTyp))
                End If

                Dim moduleChangedArg As ModuleCollectionChangedEventArgs

                ' Es existiert noch kein Modul dieses Typs = > Lege ein neues an
                If newWorkingControl Is Nothing Then
                    newWorkingControl = New iucMainModule(Me)
                    m_modulesList.Add(newWorkingControl)
                    AddHandler newWorkingControl.Close, AddressOf CloseModule

                    newWorkingControl.Initialize(modulTyp)

                    moduleChangedArg = New ModuleCollectionChangedEventArgs(newWorkingControl, enumChangeType.Added)

                Else
                    ' Bereits bekanntes Modul aufrufen
                    moduleChangedArg = New ModuleCollectionChangedEventArgs(newWorkingControl, enumChangeType.Selected)

                End If

                If modulTyp = HWLModules.Homescreen Then  ' Home - Bereich maximieren; unteren Bereich ausblenden lassen
                    newWorkingControl.CollapseLowerPanel()
                End If

                RaiseEvent ModuleCollectionChanged(Me, moduleChangedArg) ' sendet eine Nachricht, um das ändern die Komponentenliste zu veröffentlichen
                Return newWorkingControl

            Else ' Hier eher ein exit aufrufen
                For Each item As iucMainModule In Me.m_modulesList
                    If item.ItemModule IsNot Nothing Then
                        item.ItemModule.CloseModule()
                    End If

                    'TODO: Als Funktion mit Rückgabewert definieren und alles Schliesen
                Next
                MainApplication.getInstance.CloseConnection()

                System.Windows.Forms.Application.Exit()
                Return Nothing
            End If
            '    End SyncLock

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "AddNewModule", "Error while starting new Module of type:" & modulTyp.ToString)

            If modulTyp = HWLModules.ExitApp Then ' "Notabschaltung"
                System.Windows.Forms.Application.Exit()
                Return Nothing
            End If

        End Try

        Return Nothing



    End Function

    ''' <summary>
    ''' RErmittelt den systemtyp eines Panles anhand des Modulbezeichners
    ''' </summary>
    ''' <param name="wpenum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTypeOfWorkpane(ByVal wpenum As HWLModules) As System.Type
        Select Case wpenum
            Case HWLModules.Adressbook : Return GetType(iucAddressBook)
            Case HWLModules.Articles : Return GetType(iucArticles)
            Case HWLModules.Business : Return GetType(Offers.iucBills)
            Case HWLModules.CashJournal : Return GetType(iucCashTransactions)
            Case HWLModules.FixedCosts : Return GetType(iucFixedCosts)
            Case HWLModules.Letters : Return GetType(iucLetters)
            Case HWLModules.Transactions : Return GetType(iucTransactions)
            Case HWLModules.Homescreen : Return GetType(iucHomeScreen)
            Case HWLModules.Scheduler : Return GetType(iucScheduler)
            Case HWLModules.GlobalSearch : Return (GetType(iucGlobalSearch))
            Case HWLModules.PageSettings : Return (GetType(Printing.iucSimpleLayouteditor))

            Case Else
                Debug.Assert(False, "Panel-Typ (" & wpenum.ToString & ") unbekannt!")
                Return Nothing
        End Select

    End Function


    ''' <summary>
    ''' Stellt Funktionen für das anzeigen von Benachrihtigungen zur Verfügung
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Alert() As AlertHelper
        Get
            Return m_alerter
        End Get
    End Property

    ''' <summary>
    ''' Leitet die Signalisierung weiter, das ein Modul geschlossen wurde
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CloseModule(ByVal sender As Object, ByVal e As EventArgs)
        Dim modContainer As iucMainModule = CType(sender, iucMainModule)
        CloseModule(modContainer)
    End Sub

    Public Sub CloseModule(ByVal workPaneModule As iucMainModule)
        If workPaneModule Is Nothing Then Exit Sub ' Nichts zu schliessen da.. 
        If Not TypeOf workPaneModule.WorkingItem Is iucScheduler Then
            If workPaneModule.CloseModule() Then
                Me.CloseModuleInternal(workPaneModule)
            End If
        Else
            ' Den Terminplaner nicht separat prüfen
            Me.CloseModuleInternal(workPaneModule)
        End If

    End Sub
    ''' <summary>
    ''' Leitet die Signalisierung weiter, das ein Modul geschlossen wurde
    ''' </summary>
    ''' <param name="workPaneModule">Das Arbeitsmodul, das geschlossen werden soll</param>
    ''' <remarks></remarks>
    Private Sub CloseModuleInternal(ByVal workPaneModule As iucMainModule)
        If workPaneModule Is Nothing Then Exit Sub ' Nichts zu schliessen da.. 

        Dim ModuleChangedArg As New ModuleCollectionChangedEventArgs(workPaneModule, enumChangeType.Removed)

        If Not TypeOf workPaneModule.WorkingItem Is iucScheduler Then

            If m_modulesList.Contains(workPaneModule) Then

                workPaneModule.CloseInternal()
                m_modulesList.Remove(workPaneModule)

                RemoveHandler workPaneModule.Close, AddressOf CloseModule
            End If
            RaiseEvent ModuleCollectionChanged(Me, ModuleChangedArg)
        Else
            ' Termine erhalten sonderbehandlung.  Wird nicht aus der LIste entfernt, spondern in der GUI nur unsichtbar geschaltet
            RaiseEvent ModuleCollectionChanged(Me, ModuleChangedArg)

        End If

    End Sub

    Public Sub FireCloseevent()

    End Sub

    ''' <summary>
    ''' Feuert ein Ereignis, das ein neuen eingehenen Anruf signalisiert
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FireNewIncommingCall(ByVal newPhoneCall As PhoneCall)
        Try
            RaiseEvent NewIncommingCall(newPhoneCall, EventArgs.Empty)
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz der Klasse und übrgibt das Hauptformular
    ''' </summary>
    ''' <param name="mainForm"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal mainForm As Form)

        m_mainform = mainForm

        If mainForm IsNot Nothing Then ' Im Testlauf kann es ssein, das es keine MainForm giebt
            m_alerter = New AlertHelper(Me)
        End If

        Initialize()

        'Den MessageFilter hinzufügen
        System.Windows.Forms.Application.AddMessageFilter(New GlobalKeyHandler(Me))


    End Sub


    Private Sub Initialize()
        Try
            ' Telefon-schicht einschalten
            m_myPhony = New Telephony.CAPIPhony(Me)
            m_myPhony.InitCapi()
        Catch ex As Exception
            Debug.Print("Fehler beim Initailisieren des CAPI-Treibes")
            ' Gab es einen Fehler, dann nicht wieder versuchen das Teil einzuschalten
            MainApplication.getInstance.Settings.MonitorPhoneLines = False
        End Try

        ' weitere Initialiserungenm
        Me.StartUpdateWizard()

        ' Laden einiger Assemblies für die Report-Anzeige

        AddHandler System.Windows.Forms.Application.Idle, AddressOf PreloadPrintManager

    End Sub

    ''' <summary>
    ''' Vorab laden von Druck-Layouts
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PreloadPrintManager(sender As Object, e As EventArgs)
        ' Etwas warten, damit andre Dinge erledigt werden können
        RemoveHandler System.Windows.Forms.Application.Idle, AddressOf PreloadPrintManager
        PrintingManager.PreloadPrintingAssemblies()

    End Sub

    Private Sub m_mruManage_MRUChanged(ByVal sender As MRUElementManager, ByVal e As System.EventArgs) Handles m_mruManager.MRUChanged
        ' ein Element kam hinzu oder wurde entfernt

    End Sub
    ''' <summary>
    ''' Öffnet ein modales Fenster zur Bearbeitung der Klassifikationen für eine Artikelgruppe
    ''' </summary>
    ''' <remarks></remarks>
    Sub StartClassificationWindow(ByVal attributeClass As Kernel.Attributes.ClassDefinition)
        Try

            Dim frm As New frmArticleAttributes
            frm.ActiveAttributeClass = attributeClass
            If frm.ShowDialog = DialogResult.OK Then
                frm.ActiveAttributeClass.Save()
            End If
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "StartClassificationWindow", "Error in Window Classification")
        End Try

    End Sub

    ''' <summary>
    ''' Öffnet das Einstellungsmenü mit der Option "Datenbanken"
    ''' </summary>
    ''' <remarks></remarks>
    Sub OpenToolExtrasConnections()
        OpenToolExtras(SettingsOptionType.DatabaseSettings)
    End Sub

    ''' <summary>
    ''' Öffnet den Dialog "Extras" mit benutzerdefinierten Einstellungem
    ''' </summary>
    Sub OpenToolExtras()
        OpenToolExtras(SettingsOptionType.None)
    End Sub
    ''' <summary>
    ''' Öffnet den Dialog "Extras" mit benutzerdefinierten Einstellungem
    ''' </summary>
    ''' <remarks></remarks>
    Sub OpenToolExtras(ByVal settingsOptionPage As SettingsOptionType)
        Try
            Using frm As New frmOptions(Me)
                frm.ShowOption(SettingsOptionType.DatabaseSettings)
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "UI", "Error: Optional-Dialog")
        End Try

    End Sub

    ''' <summary>
    ''' Ruft die aktive Instanz des Home-Screen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MainScreen As iucHomeScreen
        Get
            Dim mm As iucMainModule = Me.GetWorkItemPane(GetType(iucHomeScreen))
            If mm IsNot Nothing Then
                Return TryCast(mm.WorkingItem, iucHomeScreen)
            End If
            Return Nothing
        End Get
    End Property

    ''' <summary>
    ''' Startet eine Aufgabe, die einige Sekunden nach dem Start der Applikation nach Updates sucht und den Anwender informiert
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartUpdateWizard()
        ' Prüfen, ob heute lokal bereits nach einem Upate gesucht wurde, falls ja, dann Aufgabe abrechen 

        ' Zeitspanne Warten nach dem Start (ca 10 sek) 
        ' dann App.Idle anwarten, 
        ' Dann Changelog-Datei herunterladen, Dateum/Version prüfen und dann runterladen 
        Dim doCheckUpdate As Boolean = True
        Dim LastCheck As Date

        LastCheck = My.Settings.LastUpdateCheck

        If LastCheck <> Date.MinValue Then
            If LastCheck = Today Then
                Debug.Print("Heute kein weiterer Update-Check")
                Exit Sub ' Heute nicht nocheinmal automatisch prüfen
            End If
        End If

        ' Gültiges Update-Interval ist:
        ' "Never
        ' Weekly
        ' Daily
        ' 
        Dim UpdateIntervalName As String ' vom Anwender gewünschtes Interval
        Dim NextCheckDate As Date  ' Anhängig vom Interval, das nächste Prüfdatum
        UpdateIntervalName = MainApplication.getInstance.Settings.GetSetting("UpdateCheckInterval", "Update", "Daily")

        Select Case UpdateIntervalName
            Case "Never"
                MainApplication.getInstance.log.WriteLog("Update check Interval was set to 'Never'. No search for Updates")
                Exit Sub
            Case "Weekly"
                NextCheckDate = LastCheck.AddDays(7)

            Case "Daily"
                NextCheckDate = LastCheck.AddDays(1)

            Case Else ' im else - Fall konnte der Wert nicht gelesen werden, dann "Daily"
                NextCheckDate = LastCheck.AddDays(1)
                MainApplication.getInstance.Settings.SetSetting("UpdateCheckInterval", "Update", "Daily")
        End Select


        If NextCheckDate < Today Then
            My.Settings.LastUpdateCheck = Today
            My.Settings.Save()
            ' Prüfung überfällig; starte Update-Zyklus
            MainApplication.getInstance.log.WriteLog("Found that a update-check should be performed by Usersettings (" & UpdateIntervalName & ")")
            m_updateManager.StartTimer()
        Else
            ' Zeitschwelle nicht überschritten
            Debug.Print("No Update-check this time..")
        End If


    End Sub



    ''' <summary>
    ''' Startet manuell die Suche nach einem manuelles Update
    ''' </summary>
    ''' <remarks></remarks>
    Sub StartManualUpdate()
        Try

            If m_updateManager.GetLatestChangeLogFile(False) Then
                If m_updateManager.ChangeLogText.Length > 0 And m_updateManager.NewUpdateAvailable Then
                    Dim GetUpdate As New Update.frmGetUpdate(m_updateManager)
                    GetUpdate.ShowDialog()
                Else
                    MessageBox.Show(GetText("msgNoUpdatesAvailable", "Es sind keine Aktualisierungen verfügbar"), MainApplication.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "ERROR", "Update-Error")
        End Try
    End Sub

    ''' <summary>
    ''' Zeigt die  Auflistung der Buchungskonten an.Ermöglicht Änderungen an der Liste
    ''' </summary>
    ''' <returns>Ein selektiertes oder gewähltes Buchungskonto. 
    ''' Nothing, falls Anwender 'Abbrechen' gewählt hat</returns>
    ''' <remarks></remarks>
    Function ShowListCashAccounts() As CashAccount
        Return ShowListCashAccounts(Nothing)
    End Function


    ''' <summary>
    ''' Zeigt die  Auflistung der Buchungskonten an.Ermöglicht Änderungen an der Liste
    ''' </summary>
    ''' <returns>Ein selektiertes oder gewähltes Buchungskonto. 
    ''' Nothing, falls Anwender 'Abbrechen' gewählt hat</returns>
    ''' <param name="selectedAccount">Das aktuell zu selektierende Buchungskonto</param>
    ''' <remarks></remarks>
    Function ShowListCashAccounts(ByVal selectedAccount As CashAccount) As CashAccount
        Using frm As New frmListCashAccounts()
            frm.SelectedAccount = selectedAccount
            If frm.ShowDialog() = DialogResult.OK Then
                Return frm.SelectedAccount
            Else
                Return Nothing
            End If
        End Using
    End Function

    ''' <summary>
    ''' Prüft, ob die Basislizenz gültig ist und gespeichert werden darf. Gibt dann eine Meldung aus, das dies verhindert wurde.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckIfLicenceValidForSaving() As Boolean
        Return True

        'important: LIZENZPRÜFUNG: Wieder einschaltn für Prüfung!
        Return CheckIfLicenceValidForSaving(MainApplication.getInstance.Licenses.GetBaseLicense)
    End Function

    ''' <summary>
    ''' Prüft ob die angegebene Lizenz gültig ist und Daten gespeichert werden können. Gibt dann eine Meldung aus, das dies verhindert wurde.
    ''' </summary>
    ''' <param name="license"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckIfLicenceValidForSaving(ByVal license As Data.LicenseItem) As Boolean

        If Not MainApplication.getInstance.Licenses.IsBaseActive Then
            Dim lizenceText As String = MainApplication.getInstance.Languages.GetText("msgLicencePeriodExiredText", "Ihre Basislizenz ist nicht mehr gültig. sie können keine weiteren Daten speichern." & vbCrLf &
                            "Möchten sie nun unsere Webseite besuchen um eine Lizenz zu erwerben?")
            Dim licenceCaption As String = MainApplication.getInstance.Languages.GetText("msgLicencePeriodExiredCaption", "Testzeitraum abgelaufen")

            If MessageBox.Show(lizenceText, licenceCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = DialogResult.Yes Then
                Process.Start(wwwProductPricesPage)
            End If
            Return False
        Else
            Return True
        End If
    End Function


    ''' <summary>
    ''' Setzt den Focus auf das such-Fenster
    ''' </summary>
    ''' <remarks></remarks>
    Sub Focussearch()
        RaiseEvent FocusSearchBar(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Aktualisiert die Anwicht des aktuellen Arbeitskontainers. Eventuell werden angezeigte Daten neu geladen und änderungen verworfen
    ''' </summary>
    ''' <remarks></remarks>
    Sub RefreshCurrentContext()
        'Throw New NotImplementedException

        If TypeOf System.Windows.Forms.Form.ActiveForm Is frmJournal Then

            CType(System.Windows.Forms.Form.ActiveForm, frmJournal).Refresh()
            Exit Sub
        End If

        If Me.ActiveWorkPane IsNot Nothing Then
            Try
                Me.ActiveWorkPane.ReloadData()

            Catch ex As Exception
                MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.Warning, "Reload failed.", "UI", "Reload of '" & Me.ActiveWorkPane.Name & "' failed: " & ex.ToString)
            End Try
        End If

    End Sub

    ''' <summary>
    ''' Führt das Drucken der aktiven Anwendung aus - sofern implementiert
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub InvokePrint()
        If TypeOf System.Windows.Forms.Form.ActiveForm Is frmJournal Then

            CType(System.Windows.Forms.Form.ActiveForm, frmJournal).Refresh()
            Exit Sub
        End If

        If Me.ActiveWorkPane IsNot Nothing Then
            Try
                Me.ActiveWorkPane.Print()

            Catch ex As Exception
                MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.Warning, "Reload failed.", "UI", "Reload of '" & Me.ActiveWorkPane.Name & "' failed: " & ex.ToString)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Führt im gerade aktiven Panel ein Save-Kommando aus
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub InvokeSave()
        If TypeOf System.Windows.Forms.Form.ActiveForm Is frmJournal Then

            CType(System.Windows.Forms.Form.ActiveForm, frmJournal).Refresh()
            Exit Sub
        End If

        If Me.ActiveWorkPane IsNot Nothing Then
            Try
                Me.ActiveWorkPane.Save()

            Catch ex As Exception
                MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.Warning, "Reload failed.", "UI", "Reload of '" & Me.ActiveWorkPane.Name & "' failed: " & ex.ToString)
            End Try
        End If

    End Sub

    Private m_reportDesigner As Printing.frmPrintingManager

    ''' <summary>
    ''' Prüft auf vorhandensein der Standard Druck-Layouts und legt gegebnenfalls diese wieder an 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckForDefaultLayouts()

        MainApplication.getInstance.SendMessage(GetText("msgCheckingDefaultPrintingLayouts", "Prüfe Druck-Layouts"))
        Printing.PrintingManager.CheckAndRepairDefaultLaoyuts()

    End Sub

    ''' <summary>
    ''' Öffnet den Report-Dialog und übergibt eine Aufstellung von reports
    ''' </summary>
    ''' <param name="dataObject">Stellt eine Auflistung von Daten dar, die im Report ausgegeben werden sollen</param>
    ''' <param name="reportType">Typ des reports</param>
    ''' <param name="report">Das zu verwendete Report</param>
    ''' <remarks></remarks>
    Public Sub OpenReportDesigner(ByVal dataObject As Object, ByVal reportType As DataSourceList, ByVal report As Kernel.Printing.Report)
        Try
            If MainApplication.getInstance.Licenses.IsActivDesigner Then

            End If

            If Not MainApplication.getInstance.Licenses.IsActivDesigner Then
                MessageBox.Show("Der Testzeitraum für den Druck-Designer ist abgelaufen." & vbCrLf &
                                "Um Druck-Formulare bearbeiten zu können müssen sie eine separate Lizenz erwerben", "Testzeitraum beendet", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If


            If m_reportDesigner Is Nothing Then
                m_reportDesigner = New Printing.frmPrintingManager(dataObject, reportType)
            Else
                m_reportDesigner.DataSourceType = reportType
                m_reportDesigner.Data = dataObject

            End If

            m_reportDesigner.ActiveReport = report
            m_reportDesigner.ActivateBuisinesFrame = False
            m_reportDesigner.ShowDialog()
        Catch ex As Exception

            MainApplication.getInstance.log.WriteLog(ex, "PrintingSystem", "Error in Report Designer")

        End Try
    End Sub


    ''' <summary>
    ''' Ruft den Druck-Manager ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PrintingManager As Printing.PrintingManager
        Get
            If m_printingManager Is Nothing Then
                m_printingManager = New Printing.PrintingManager()

            End If
            Return m_printingManager
        End Get
    End Property

    ''' <summary>
    ''' Öffnet die Voransicht des angegebenen Reports und fügt die Seiten zusammen
    ''' </summary>
    Public Sub OpenReportPreview(ByVal dataObject As Object, ByVal reportType As DataSourceList, ByVal reports As List(Of Kernel.Printing.Report))
        OpenReportPreview(dataObject, reportType, reports, New Printing.DocumentPrintingOptions)
    End Sub

    Public Sub OpenReportPreview(ByVal dataObject As Object, ByVal reportType As DataSourceList, ByVal reports As List(Of Kernel.Printing.Report), ByVal showBusinesLayout As Boolean)

        Dim options As New Printing.DocumentPrintingOptions
        options.WithBusinesslayout = showBusinesLayout

        OpenReportPreview(dataObject, reportType, reports, options)
    End Sub


    ''' <summary>
    ''' Öffnet die Voransicht des angegebenen Reports und fügt die Seiten zusammen
    ''' </summary>
    ''' <param name="dataObject"></param>
    ''' <param name="reports">Eine Liste der Reports, die zusammengehängt werden sollen</param>
    ''' <remarks></remarks>
    Public Sub OpenReportPreview(ByVal dataObject As Object, ByVal reportType As DataSourceList, ByVal reports As List(Of Kernel.Printing.Report), options As Printing.DocumentPrintingOptions)
        Dim sw As New Stopwatch
        sw.Start()
        Debug.Print(PrintingManager.ToString & " (Object loaded) : " & sw.Elapsed.ToString)
        PrintingManager.Data = dataObject
        PrintingManager.ReportDatasourceKind = reportType
        PrintingManager.MultiReports = reports
        PrintingManager.ShowBusinesLayout = options.WithBusinesslayout
        PrintingManager.PageCopies = options.PageCopies
        PrintingManager.PrintBusinesHeaderOneveryPage = options.PrintBusinesHeaderOnEveryPage
        Debug.Print("Page buildet at: " & sw.Elapsed.ToString)

        PrintingManager.ShowPreview()
        Debug.Print("Preview Shown at: " & sw.Elapsed.ToString)
    End Sub



    ''' <summary>
    ''' Druckt die Reports sofort aus und verwendet Standardwerte
    ''' </summary>
    Public Sub PrintReportsDirect(ByVal dataObject As Object, ByVal reportType As DataSourceList, ByVal reports As List(Of Kernel.Printing.Report))

        PrintReportsDirect(dataObject, reportType, reports, New Printing.DocumentPrintingOptions)
    End Sub

    ''' <summary>
    ''' Druckt die Reports sofort aus
    ''' </summary>
    Public Sub PrintReportsDirect(ByVal dataObject As Object, ByVal reportType As DataSourceList, ByVal reports As List(Of Kernel.Printing.Report), ByVal showBusinesLayout As Boolean)
        Dim options As New Printing.DocumentPrintingOptions
        options.WithBusinesslayout = showBusinesLayout
        PrintReportsDirect(dataObject, reportType, reports, options)

    End Sub

    ''' <summary>
    ''' Druckt die Reports sofort aus
    ''' </summary>
    ''' <param name="dataObject"></param>
    ''' <param name="reportType"></param>
    ''' <param name="reports"></param>
    ''' <remarks></remarks>
    Public Sub PrintReportsDirect(ByVal dataObject As Object, ByVal reportType As DataSourceList, ByVal reports As List(Of Kernel.Printing.Report), options As Printing.DocumentPrintingOptions)

        PrintingManager.Data = dataObject
        PrintingManager.ReportDatasourceKind = reportType

        PrintingManager.MultiReports = reports
        PrintingManager.ShowBusinesLayout = options.WithBusinesslayout
        PrintingManager.PageCopies = options.PageCopies
        PrintingManager.PrintBusinesHeaderOneveryPage = options.PrintBusinesHeaderOnEveryPage

        PrintingManager.PrintDirect()

    End Sub

    ''' <summary>
    ''' Öffnet den Report-Dialog und zeigt das angebene Drucken-Layout an
    ''' </summary>
    ''' <param name="dataObject"></param>
    ''' <param name="dataSourceList"></param>
    ''' <remarks></remarks>
    Public Sub OpenReportDesigner(ByVal dataObject As Object, ByVal dataSourceList As DataSourceList)

        OpenReportDesigner(dataObject, dataSourceList, Nothing)
    End Sub


    Private m_simpleListPrinting As Printing.dlgSimplePrinting

    ''' <summary>
    ''' Zeigt den einfachen Druck-Dialog ür Grids an
    ''' </summary>
    ''' <param name="gridControl"></param>
    ''' <param name="dataSourceList"></param>
    ''' <param name="activeItem"></param>
    ''' <remarks></remarks>
    Sub ShowPrintInGrid(ByVal gridControl As DevExpress.XtraGrid.GridControl, ByVal dataSourceList As DataSourceList, ByVal activeItem As Adress)

        If m_simpleListPrinting Is Nothing Then
            m_simpleListPrinting = New Printing.dlgSimplePrinting
        End If

        m_simpleListPrinting.Grid = gridControl   ' Grid zuweisen
        m_simpleListPrinting.DataSourceType = dataSourceList
        m_simpleListPrinting.SelectedItem = activeItem   ' Aktuelle Instanz anzeigen alssen
        m_simpleListPrinting.ShowDialog()

    End Sub

    Function HasUnsavedChanges() As Boolean
        For Each item As iucMainModule In Me.m_modulesList
            'TODO Ändereungen an einem Modul erkennen
        Next
        Return False
    End Function

    ''' <summary>
    ''' Öffnet die Hilfe-Datei
    ''' </summary>
    ''' <remarks></remarks>
    Sub OpenHelpFile()
        Dim helpfile As String = String.Empty
        Try

            Dim langCode As String = MainApplication.getInstance.Languages.GetActiveLanguage.Substring(0, 2)

            helpfile = My.Application.Info.DirectoryPath & "\helpfiles\Help-" & langCode & ".chm"

            Process.Start(helpfile)

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Help", "ERROR: Opening help file failed. (" & helpfile & ")")
            MainApplication.getInstance.SendMessage(ex.Message)
        End Try
    End Sub


    Public Shared Function CreateDatabaseBackup(backupConnection As ClausSoftware.Tools.Connection) As Boolean
        If backupConnection.Servertype = Tools.enumServerType.MySQL Then
            If Not SetBackupDumper() Then
                ' Konnte kein MySQLDump finden
                Return False
            End If
        End If

        'Wenn bisher kein Rücksprung, dann kann nun 
        Dim retValue As Boolean
        retValue = MainApplication.getInstance.Database.StartBackup("", backupConnection)
        Return retValue

    End Function




    ''' <summary>
    ''' Setzt für ein Server-Backup die Dump-Datei
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function SetBackupDumper() As Boolean
        Const DumpFileName As String = "mysqldump.exe"
        If MainApplication.getInstance IsNot Nothing Then
            Dim lastDumpFilePath As String = MainApplication.getInstance.Settings.GetSetting("mySQLDumpPath", "Connections", "", MainApplication.getInstance.CurrentUser.Key)



            If System.IO.File.Exists(lastDumpFilePath) Then
            Else
                MainApplication.getInstance.log.WriteLog("MySqlDump not found in Path!")

                If MessageBox.Show("Zum sichern einer Server-Datenbank ist die Datei 'MySQLDump' notwendig. Geben Sie nun den Pfad der Datei an: ", "Dienstprogramm nicht gefunden", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                    Dim path As String
                    Dim openfileDlg As New System.Windows.Forms.OpenFileDialog()
                    openfileDlg.FileName = DumpFileName
                    openfileDlg.InitialDirectory = Tools.Services.GetSpecialFolder(Tools.Services.SpecialFolderConst.CSIDL_PROGRAM_FILESX86)

                    If openfileDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                        path = openfileDlg.FileName

                        If System.IO.File.Exists(path) Then
                            MainApplication.getInstance.Settings.SetSetting("mySQLDumpPath", "Connections", path, MainApplication.getInstance.CurrentUser.Key)

                        End If

                    Else
                        Return False
                    End If

                Else
                    Return False
                End If

            End If
            ' Alles OK
        End If

        Return True
    End Function




End Class

''' <summary>
''' Ruft das Modul und die Art der Änderung ab, um die es geht
''' </summary>
''' <remarks></remarks>
Public Class ModuleCollectionChangedEventArgs
    Inherits EventArgs

    Public Sub New(ByVal item As iucMainModule, ByVal changeType As enumChangeType)
        m_changeType = changeType
        m_item = item
    End Sub



    Private m_item As iucMainModule

    Private m_changeType As enumChangeType

    ''' <summary>
    ''' Ruft die Art der Änderung ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChangeType() As enumChangeType
        Get
            Return m_changeType
        End Get
        Set(ByVal value As enumChangeType)
            m_changeType = value
        End Set
    End Property



    ''' <summary>
    ''' Ruft das Modul ab, das gerade in der Auflistung geändert wurde
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WorkPane() As iucMainModule
        Get
            Return m_item
        End Get
        Set(ByVal value As iucMainModule)
            m_item = value
        End Set
    End Property

End Class

''' <summary>
''' Stellt eine Behandlung fü globale Tastenkombinationen bereit
''' </summary>
''' <remarks></remarks>
Friend Class GlobalKeyHandler
    Implements IMessageFilter
    Private m_mainUI As MainUI

    Private Enum WindowsMessages

        WM_KEYDOWN = &H100

    End Enum

    Public Sub New(ByVal ui As MainUI)

        m_mainUI = ui
    End Sub


    Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage

        ' F3 ode ALT-F : Suche ölffnen 
        ' F5: Aktualisieren
        If m.Msg = WindowsMessages.WM_KEYDOWN Then

            Dim [Keys] As Keys = CType(m.WParam.ToInt32(), Keys) And Keys.KeyCode

            ' F-Tasten
            Select Case [Keys]

                Case Windows.Forms.Keys.F1 ' Hilfe-Datei
                    m_mainUI.OpenHelpFile()
                    Return True

                Case Keys.F3 ' Globale Suche
                    m_mainUI.Focussearch()
                    Return True

                    'Refresh
                Case Windows.Forms.Keys.F5
                    m_mainUI.RefreshCurrentContext()
            End Select

            'STRG-Tasten

            If System.Windows.Forms.Form.ModifierKeys = Windows.Forms.Keys.Control Then
                Select Case [Keys]
                    Case Windows.Forms.Keys.P

                        m_mainUI.InvokePrint()
                        Return True

                        'Speichern
                    Case (Windows.Forms.Keys.S)
                        m_mainUI.InvokeSave()
                        Return True


                        ' Programmteile per STRG + Ziffer öffnen lassen 
                    Case Keys.D1
                        m_mainUI.OpenWorkingPane(HWLModules.Adressbook)
                        Return True

                    Case Keys.D2
                        m_mainUI.OpenWorkingPane(HWLModules.Articles)
                        Return True

                    Case Keys.D3
                        m_mainUI.OpenWorkingPane(HWLModules.Business)
                        Return True

                    Case Keys.D4
                        m_mainUI.OpenWorkingPane(HWLModules.Transactions)
                        Return True

                    Case Keys.D5
                        m_mainUI.OpenWorkingPane(HWLModules.CashJournal)
                        Return True

                    Case Keys.D6
                        m_mainUI.OpenWorkingPane(HWLModules.Letters)
                        Return True

                    Case Keys.D7
                        m_mainUI.OpenWorkingPane(HWLModules.Scheduler)
                        Return True
                End Select
            End If

        End If

        Return False
    End Function



End Class