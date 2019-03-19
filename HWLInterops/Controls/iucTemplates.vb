Imports ClausSoftware.Kernel

Public Class iucTemplates
    Implements IModule



    'Please enter any new code here, below the Interop code
    Sub Initialize()
        modmain.InitializeApplication()

        FillTemplates()
        InitArticles()

    End Sub

    Sub InitArticles()
        IucGroupsGrid1.Initialize()

    End Sub

    Sub FillTemplates()

        trvTemplates.DataSource = New Templates(m_application)
        trvTemplates.ParentFieldName = "ParentID"
        trvTemplates.KeyFieldName = "Key"

        trvTemplates.PopulateColumns()
        trvTemplates.BestFitColumns()
        trvTemplates.ExpandAll()

    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Initialize()
    End Sub

    Private Sub trvTemplates_FocusedNodeChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles trvTemplates.FocusedNodeChanged
        If e.Node IsNot Nothing Then
            Dim o As Template = CType(trvTemplates.GetDataRecordByNode(e.Node), Template)

            trvTemplateData.DataSource = o.GetTemplateData


        End If


    End Sub

    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        Return True
    End Function

    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            Return String.Empty
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem

    End Sub

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return "Rechnungsvorlagen" 'TODO: NLS
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule

    End Sub

    Public Sub NewItem() Implements IModule.CreateNewItem

    End Sub

    ''' <summary>
    ''' Nich implementiert
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Print() Implements IModule.Print

    End Sub

    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

    End Sub

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnSave Or actionButtons.btnClose Or actionButtons.btnNew Or actionButtons.btnDelete
        End Get
    End Property

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