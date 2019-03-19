Imports DevExpress.XtraEditors

''' <summary>
''' Stellt ein Benutzercontrol bereit, das als Container für die workpages dient
''' </summary>
''' <remarks></remarks>
Public Class iucMainModule

    Private Shared InstanceCounter As Integer

    ''' <summary>
    ''' Ruft eine eindeutige Nummer dieses Controls ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property InstanceID As Integer
        Get
            Return InstanceCounter
        End Get
    End Property

    ''' <summary>
    ''' Läasst das untere Panel, im dem normalerweise die Buttons liegen verschwinden
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CollapseLowerPanel()
        pnlButtonsCollection.Height = 0
    End Sub

    ''' <summary>
    ''' Stellt das innere darzustellene Arbeitsmodul dar
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents m_module As IModule

    ''' <summary>
    ''' Wird ausgelöst, wenn das aktuelle Modul geschlossen werden soll
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event Close(ByVal sender As Object, ByVal e As EventArgs)

    ''' <summary>
    ''' Wird vom Adressbuch benutzt, wenn dort das Jorunal aufgerufn wird, dann wird bei einem doppelklik das Dokument aufgerufen
    ''' </summary>
    ''' <param name="documentNumber"></param>
    ''' <param name="documentType"></param>
    ''' <remarks></remarks>
    Public Event SelectedDocument(ByVal documentNumber As Integer, ByVal documentType As Integer)


    Private m_smallImage As Image = Nothing

    ''' <summary>
    ''' Stellt eine Eigenschaft zur Verfügung, die kleine Symbole anzeigen kann. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overridable ReadOnly Property SmallIcon() As Image
        Get
            Return m_smallImage
        End Get
        
    End Property

    ''' <summary>
    ''' Ruft den Anzeigetext des eingebetten Modules ab.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Displaytext() As String
        Get
            Return m_module.DisplayText
        End Get
    End Property


    Private m_workingItem As mainControlContainer

    ''' <summary>
    ''' Ruft das Steuerelement ab, das innerhalb des Modules dargestellt wird und die eigentliche Arbeitsoberfläche darstellt
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WorkingItem() As mainControlContainer
        Get
            Return m_workingItem
        End Get

    End Property


    Public Sub Initialize(ByVal hwlmodule As HWLModules)
        Me.SuspendLayout()

        Debug.Print("Initialisiere " & hwlmodule.ToString)

        Try
            Select Case hwlmodule

                Case HWLModules.Homescreen
                    m_workingItem = New iucHomeScreen

                Case HWLModules.Adressbook
                    m_workingItem = New iucAddressBook

                Case HWLModules.Scheduler
                    m_workingItem = New iucScheduler(MainUI)

                Case HWLModules.Statistics
                    m_workingItem = New iucCharting(MainUI)

                Case HWLModules.StatisticTop10
                    m_workingItem = New iucStatistics()

                Case HWLModules.Articles
                    m_workingItem = New iucArticles(MainUI)

                Case HWLModules.Business
                    m_workingItem = New Offers.iucBills(MainUI)

                Case HWLModules.Tasks
                    m_workingItem = New iucTasks(MainUI)

                Case HWLModules.Letters
                    m_workingItem = New iucLetters(MainUI)

                Case HWLModules.Transactions
                    m_workingItem = New iucTransactions(MainUI)

                Case HWLModules.PageSettings
                    ' Jenachdem welche Lizenz: simpleMode oder Extra-Mode
                    m_workingItem = New Printing.iucSimpleLayouteditor(MainUI)

                    'm_workingItem = New iucPageDesigner(MainUI)

                Case HWLModules.FixedCosts
                    m_workingItem = New iucFixedCosts(MainUI)

                Case HWLModules.CashJournal
                    m_workingItem = New iucCashTransactions(MainUI)

                Case HWLModules.Templates
                    m_workingItem = New iucTemplates(MainUI)

                Case HWLModules.GlobalSearch
                    m_workingItem = New iucGlobalSearch()

                Case Else
                    Throw New NotImplementedException("Äh.. sorry dieses Modul (" & hwlmodule.ToString & ") muss noch Programmiert werden")

            End Select

            ' 
            AddHandler m_workingItem.DisplayTextChanged, AddressOf FireDisplayTextChanged

            ' Das Interface auffüllen, damit werden die grundlegenden Ereignisse behandelt
            m_module = DirectCast(m_workingItem, IModule)


        Catch ex As Exception
            m_application.Log.WriteLog(ex, "Error", "in MainModule.Initialize")
            Debug.Print("Beim Erstellen von (" & hwlmodule.ToString & ") kam es zu einem schweren Fehler: " & ex.Message)
            Throw ' nach oben werfen! 
        End Try

        If m_module IsNot Nothing Then
            Try
                CType(m_module, Control).Dock = DockStyle.Fill
                Panel1.Controls.Add(CType(m_module, Control))
                m_module.InitializeModule()
            Catch ex As Exception
                m_application.Log.WriteLog(ex, "UI", "Error while initializing WorkerModule")
            End Try
        Else
            Debug.Print("Das zu startene Modul (" & hwlmodule.ToString & ") konnte nicht initialisiert werden und lieferte ein leeres Frame")
        End If

        FillButtons()
        Me.ResumeLayout()

    End Sub

    Shadows Event DisplayTextChanged(ByVal sender As iucMainModule, ByVal e As DisplayTextEventArgs)

    ''' <summary>
    ''' Leitet das ereignis "DisplaytextChanged" aus der Basisklasse weiter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FireDisplayTextChanged(ByVal sender As Object, ByVal e As DisplayTextEventArgs)
        RaiseEvent DisplayTextChanged(Me, e)
    End Sub

    Public Function CloseModule() As Boolean
        Return CloseModule(False)
    End Function

    ''' <summary>
    ''' Schliesst das angegebene Modul. 
    ''' Das kann verhindert werden
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CloseModule(ByVal fireEvent As Boolean) As Boolean
        Static working As Boolean

        If Not working Then
            working = True

            If m_module IsNot Nothing Then
                If m_module.CloseModule Then
                    If fireEvent Then
                        RaiseEvent Close(Me, EventArgs.Empty)
                    End If

                    working = False
                    Return True
                End If
            End If
            working = False
            Return False
        End If

        working = False
        Return True
    End Function

    Friend Sub CloseInternal()
        RemoveHandler m_workingItem.DisplayTextChanged, AddressOf FireDisplayTextChanged
        m_workingItem.Dispose()
        m_workingItem = Nothing

        m_module = Nothing ' Arbeitsmodul aus der auflistung entfernen
    End Sub
    ''' <summary>
    ''' Stellt eine Schliesen-Anforderung dar.  Ausgelöst durch den schliessen-Button
    ''' Das Aufrufende Modul muss "True"  
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloseModule(ByVal sender As Object, ByVal e As EventArgs)
        CloseModule(True)
    End Sub

    Public Function GetSelectedItemID() As String
        Return m_module.CurrentItemID
    End Function

    ''' <summary>
    ''' Nicht implementiert... 
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Print()

    End Sub

    ''' <summary>
    ''' Führt einen Druck-Befehl des Moduls aus
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintGrid(ByVal sender As Object, ByVal e As EventArgs)
        If m_module IsNot Nothing Then
            m_module.Print()
        End If
    End Sub

    Private Sub SaveCurrentItem(ByVal sender As Object, ByVal e As EventArgs)
        If m_module IsNot Nothing Then
            m_module.SaveCurrentItem()
        End If
    End Sub

    ''' <summary>
    ''' Erzwingt as Anlegen eines neuen elemengtes vom Typ des aktuellen Modules
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub NewItem(ByVal sender As Object, ByVal e As EventArgs)
        m_module.CreateNewItem()
    End Sub
    ''' <summary>
    ''' Erstellt dynamisch die Hauptbuttons, sofern vom inneren Steuerelement diese angegeben wurden. 
    ''' Der Homescreen enthält keine Buttons
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillButtons()

        pnlButtonsCollection.Controls.Clear()
        If m_module Is Nothing Then Exit Sub

        If TypeOf m_module Is iucHomeScreen Then
            pnlButtonsCollection.SendToBack()
            Exit Sub
        End If

        If (m_module.SupportedButtons And actionButtons.btnClose) = actionButtons.btnClose Then
            ' Close-Button einsetzen 
            Dim btn As New SimpleButton
            btn.Name = "btnClose"
            btn.Text = GetText("btnClose")


            AddHandler btn.Click, AddressOf CloseModule
            pnlButtonsCollection.Controls.Add(btn)

        End If
        If (m_module.SupportedButtons And actionButtons.btnPrint) = actionButtons.btnPrint Then
            Dim btn As New SimpleButton
            btn.Name = "btnPrint"
            btn.Text = GetText("btnPrint")

            AddHandler btn.Click, AddressOf PrintGrid
            pnlButtonsCollection.Controls.Add(btn)
        End If

        If (m_module.SupportedButtons And actionButtons.btnSave) = actionButtons.btnSave Then
            Dim btn As New SimpleButton
            btn.Name = "btnSave"
            btn.Text = GetText("btnSave")

            AddHandler btn.Click, AddressOf SaveCurrentItem
            pnlButtonsCollection.Controls.Add(btn)
        End If

        If (m_module.SupportedButtons And actionButtons.btnNew) = actionButtons.btnNew Then
            Dim btn As New SimpleButton
            btn.Name = "btnNew"
            btn.Text = GetText("btnNew")

            AddHandler btn.Click, AddressOf NewItem
            pnlButtonsCollection.Controls.Add(btn)
        End If

    End Sub



    ''' <summary>
    ''' Ruft das Arbeitsmodul ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ItemModule() As IModule
        Get
            Return m_module
        End Get
    End Property

    ''' <summary>
    ''' Ruft einen Überschriftentext für das geladene Modul ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        If m_module IsNot Nothing Then
            Return m_module.DisplayText
        Else
            Return ""
        End If
    End Function

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        InstanceCounter += 1

    End Sub

    Public Sub New(ByVal myUI As mainUI)
        MyBase.New(myUI)
        InitializeComponent()
        InstanceCounter += 1
    End Sub

End Class