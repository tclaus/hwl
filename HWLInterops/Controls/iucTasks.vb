Imports ClausSoftware.Kernel
Imports ClausSoftware.Data

<CLSCompliant(False)> _
Public Class iucTasks
    Implements IModule


    Private m_activeItem As StaticItem


    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        Return True
    End Function

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return GetText("moduleTasks", "Aufgaben")
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule
        TasksGrid.SetDataSource(DataSourceList.Tasks)
        TasksGrid.Initialize()
        TasksGrid.Context = "Tasks"
        TasksGrid.ShowFilterRow = True

        m_application.Languages.SetTextOnControl(cmsDefault)

    End Sub

    ''' <summary>
    ''' Läd das angezeigte Item ein 
    ''' </summary>
    ''' <param name="currentItem"></param>
    ''' <remarks></remarks>
    Friend Sub LoadCurrentItem(ByVal currentItem As Task)
        If currentItem IsNot Nothing Then

            Dim editTask As New frmeditTask(currentItem)

            If editTask.ShowDialog() = DialogResult.OK Then
                If currentItem.IsNew Then
                    m_application.Tasks.Add(currentItem)
                End If
                currentItem.Save()

                TasksGrid.RefreshData()
            End If
        End If

    End Sub

    Public Sub NewItem() Implements IModule.CreateNewItem
        Dim newItem As Task = CType(TasksGrid.CreateNew(), Task)
        LoadCurrentItem(newItem)

    End Sub

    Public Overrides Sub Print() Implements IModule.Print
        TasksGrid.ShowPrintPreview()
    End Sub

    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

    End Sub

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnNew Or actionButtons.btnPrint Or actionButtons.btnDelete
        End Get
    End Property

    Private Sub TasksGrid_BeforeCreateNewItem(ByVal sender As Object, ByVal e As Kernel.CreateItemArgs) Handles TasksGrid.BeforeCreateNewItem
        e.Cancel = True

        Dim NewItem As Task
        NewItem = m_application.Tasks.GetNewItem()
        m_application.Tasks.Add(NewItem)
        LoadCurrentItem(NewItem)
    End Sub

    Private Sub TasksGrid_ItemRowDoubleClick(ByVal key As System.String) Handles TasksGrid.ItemRowDoubleClick

        LoadCurrentItem(CType(TasksGrid.FocussedItem, Task))

    End Sub

    Private Sub iucTasks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitializeModule()
    End Sub

    Private Sub mnuNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewItem.Click
        Me.NewItem()
    End Sub

    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            Return TasksGrid.FocusedRowKey
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem
        If m_activeItem IsNot Nothing Then
            If AskDeleteData() = DialogResult.Yes Then
                m_activeItem.Delete()
            End If
        End If
    End Sub

    Private Sub TasksGrid_SelectedRowChanged(ByVal key As String) Handles TasksGrid.FocusedRowChanged
        m_activeItem = TasksGrid.FocussedItem
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    End Sub

    Public Sub New(ByVal myUI As mainUI)
        MyBase.New(myUI)
        InitializeComponent()

    End Sub

    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get
            Return Nothing
        End Get
    End Property
End Class
