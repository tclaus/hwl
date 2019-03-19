Public Class frmImportOptions 

    Private m_mappings As Mappings

    Private m_filename As String

    Private m_controller As ImporterController
    Private m_TargetAttributes As New Dictionary(Of String, ImportPropertyInfo)


    Public Property ImportController() As ImporterController
        Get
            Return m_controller
        End Get
        Set(ByVal value As ImporterController)
            m_controller = value

            AddHandler m_controller.CounterIncreases, AddressOf IncrementCounter

        End Set
    End Property

    ''' <summary>
    ''' Ruft die Auflistunhg aller möglichen ZielAttribute ab ode rlegt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property TargetAttributes() As Dictionary(Of String, ImportPropertyInfo)
        Get
            Return m_TargetAttributes
        End Get
        Set(ByVal value As Dictionary(Of String, ImportPropertyInfo))
            m_TargetAttributes = value
        End Set
    End Property


    Public Property Filename() As String
        Get
            Return m_filename
        End Get
        Set(ByVal value As String)
            m_filename = value
        End Set
    End Property


    ''' <summary>
    ''' Ruft die Auflistung der Zuweisungen ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Mappings() As Mappings
        Get
            Return m_mappings
        End Get
        Set(ByVal value As Mappings)
            m_mappings = value
        End Set
    End Property

    Private Sub FillGrid()


        grdMappings.DataSource = m_mappings
        repTargetAttributes.Items.AddRange(Me.TargetAttributes.Values)

    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmImportOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.ImportController.m_application.Settings.SaveFormsPos(Me, "ImporterAddin")
    End Sub

    Private Sub frmImportOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillGrid()

        Me.ImportController.m_application.Settings.RestoreFormsPos(Me, "ImporterAddin")

    End Sub


    Private Sub btnStartImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStartImport.Click


        lblCounter.Visible = True
        startUpdate()


        'Me.Close()
    End Sub

    ''' <summary>
    ''' Startet den Importvorgang Asynchron
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub startUpdate()


        Me.ImportController.StartImport()

    End Sub

#Region "Threaded"
    Private Delegate Sub ShowImportCount(ByVal cout As Integer, ByVal maxcount As Integer)
    Private m_ShowImportCountdele As New ShowImportCount(AddressOf IncrementCounter)


    Private Sub IncrementCounter(ByVal count As Integer, ByVal maxcount As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(m_ShowImportCountdele, New Object() {count, maxcount})
            Exit Sub
        End If

        lblCounter.Text = String.Format("{0}/{1}", count, maxcount)
        lblCounter.Update()
    End Sub

#End Region

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        Me.ImportController.SetMappings()
        GridView1.RefreshData()
    End Sub
End Class