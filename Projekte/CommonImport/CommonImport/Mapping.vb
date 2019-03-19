Public Class Mapping

    Private m_active As Boolean

    Private m_Source As String

    Private m_target As ImportPropertyInfo

    Private m_orderId As Integer

    Private m_sourceID As Integer
    ''' <summary>
    ''' Ruft die Nummer der Spalte ab oder legt diese festz
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Einsatz muss geprüft werden; eventuell reicht der interne Name?</remarks>
    Public Property SourceID() As Integer
        Get
            Return m_sourceID
        End Get
        Set(ByVal value As Integer)
            m_sourceID = value
        End Set
    End Property

    ''' <summary>
    ''' Gibt die Reihenfolge der Zuweisung an
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrderID() As Integer
        Get
            Return m_orderId
        End Get
        Set(ByVal value As Integer)
            m_orderId = value
        End Set
    End Property
    ''' <summary>
    ''' Ruft Namen und Anzeigetext eines Zielattributes ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Target() As ImportPropertyInfo
        Get
            Return m_target
        End Get
        Set(ByVal value As ImportPropertyInfo)
            m_target = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft den eindeutigen Namen der Zielspalte ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Source() As String
        Get
            Return m_Source
        End Get
        Set(ByVal value As String)
            m_Source = value
        End Set
    End Property

    Public Property Active() As Boolean
        Get
            Return m_active
        End Get
        Set(ByVal value As Boolean)
            m_active = value
        End Set
    End Property

End Class
