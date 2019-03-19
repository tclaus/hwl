Namespace HomeScreen

    Public Class MenuStructure


        Private m_listOfModules As New List(Of ModuleItem)

        Public ReadOnly Property ListOfModules() As List(Of ModuleItem)
            Get
                Return m_listOfModules
            End Get
        End Property


    End Class


    ''' <summary>
    ''' enthälkt ein MenüModul mit seinem Element 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ModuleItem

        Private m_ModuleName As String


        Private m_listOfFunctions As New List(Of MenuFunction)

        Private m_Icon As Image

        Private m_isVisible As Boolean


        Private m_id As String
        ''' <summary>
        ''' Eindeutige ID des entsprechenden Menüs
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ModuleID() As String
            Get
                Return m_id
            End Get
            Set(ByVal value As String)
                m_id = value
            End Set
        End Property


        Public Property IsVisible() As Boolean
            Get
                Return m_isVisible
            End Get
            Set(ByVal value As Boolean)
                m_isVisible = value
            End Set
        End Property

        Public Property Icon() As Image
            Get
                Return m_Icon
            End Get
            Set(ByVal value As Image)
                m_Icon = value
            End Set
        End Property

        Public ReadOnly Property ListOfFunctions() As List(Of MenuFunction) ' <- Funktion hat einen Namen, NLS-Key udn Funktionszeiger
            Get
                Return m_listOfFunctions
            End Get

        End Property

        ''' <summary>
        ''' DisplayName des Modules
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ModuleName() As String
            Get
                Return m_ModuleName
            End Get
            Set(ByVal value As String)
                m_ModuleName = value
            End Set
        End Property




    End Class

    Public Class MenuFunction

        Private m_functionName As String

        Private m_functionID As String

        Private m_isVisible As Boolean = True

        Private m_name As String
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property

        Public Property IsVisible() As Boolean
            Get
                Return m_isVisible
            End Get
            Set(ByVal value As Boolean)
                m_isVisible = value
            End Set
        End Property

        ''' <summary>
        ''' eindeutige Kennung des Funktionsaufrufes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FunctionID() As String
            Get
                Return m_functionID
            End Get
            Set(ByVal value As String)
                m_functionID = value
            End Set
        End Property

        ''' <summary>
        ''' Name der Funktion
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Caption() As String
            Get
                Return m_functionName
            End Get
            Set(ByVal value As String)
                m_functionName = value
            End Set
        End Property

    End Class


End Namespace