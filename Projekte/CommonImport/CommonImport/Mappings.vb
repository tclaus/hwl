
<Serializable()> _
Public Class Mappings
    Inherits System.Collections.Generic.List(Of Mapping)

    Private m_MapTarget As String

    Private m_MapName As String
    ''' <summary>
    ''' Ruft den Namen des Mappings ab oder legt diesen fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MapName() As String
        Get
            Return m_MapName
        End Get
        Set(ByVal value As String)
            m_MapName = value
        End Set
    End Property

    Public Property MapTargetType() As String
        Get
            Return m_MapTarget
        End Get
        Set(ByVal value As String)
            m_MapTarget = value
        End Set
    End Property

    Public Sub New()

    End Sub
End Class
