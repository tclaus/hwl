Public Class uclRTFEditor



    Public Property RTFText() As String
        Get
            Return rchTexteditor.RtfText
        End Get
        Set(ByVal value As String)
            rchTexteditor.RtfText = value
        End Set
    End Property

End Class
