''' <summary>
''' Stellt eine vereinfachung eines einzelnes Alert-Element dar. 
''' </summary>
''' <remarks></remarks>
Public Class AlertElement

    Private m_caption As String

    Private m_text As String

    Private m_image As Image

    Private m_onClick As OnAlertClick

    Private m_tag As Object

    ''' <summary>
    ''' Ruft ein allgemeines Objekt ab oder legt dieses fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tag() As Object
        Get
            Return m_tag
        End Get
        Set(ByVal value As Object)
            m_tag = value
        End Set
    End Property

    ''' <summary>
    ''' Legt ein Aufrufziel fest oder ruift dieses ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OnClick() As OnAlertClick
        Get
            Return m_onClick
        End Get
        Set(ByVal value As OnAlertClick)
            m_onClick = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft ein Anzeigebild ab oder legt deises fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Image() As Image
        Get
            Return m_image
        End Get
        Set(ByVal value As Image)
            m_image = value
        End Set
    End Property

    ''' <summary>
    ''' Legt den Anzeigetext fest oder ruft diesen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Text() As String
        Get
            Return m_text
        End Get
        Set(ByVal value As String)
            m_text = value
        End Set
    End Property

    ''' <summary>
    ''' Legt die Überschrift der Benachrichtigung ab oder legt dieses fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Caption() As String
        Get
            Return m_caption
        End Get
        Set(ByVal value As String)
            m_caption = value
        End Set
    End Property

End Class
