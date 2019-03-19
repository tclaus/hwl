
''' <summary>
''' Stellt die Statusmeldung bereit, die vom SHK-Server gemeldet wird
''' </summary>
''' <remarks></remarks>
Class StatusMessageEventArg
    Inherits EventArgs
    Private m_statustext As String

    Public Property Statustext() As String
        Get
            Return m_statustext
        End Get
        Set(ByVal value As String)
            m_statustext = value
        End Set
    End Property

    Friend Sub New(statusMessage As String)
        m_statustext = statusMessage
    End Sub

End Class
