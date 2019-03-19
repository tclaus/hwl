Module Modservices
    ' ''' <summary>
    ' ''' Ruft den Text in der aktuellen Sprache ab 
    ' ''' </summary>
    ' ''' <param name="key">Der Schlüssel zum Text.</param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetText(ByVal key As String) As String
    '    ClausSoftware.HWLInterops.GetText()
    '    If m_application IsNot Nothing Then ' es kann sein, das dies bereits im designer aufgerufen wird. 
    '        Return m_application.Languages.GetText(key)
    '    Else
    '        Return key
    '    End If

    'End Function

    ' ''' <summary>
    ' ''' Ruft den Text in der aktuellen Sprache ab 
    ' ''' </summary>
    ' ''' <param name="defaulttext">Kannd er text mit dem Schlüssel nicht gefunden werden, wird der Standardtext genutzt und gleichzeitig der textauflistung hinzugefügt</param>
    ' ''' <param name="key">Der Schlüssel zum Text.</param>
    'Public Function GetText(ByVal key As String, ByVal defaulttext As String, ByVal ParamArray params() As Object) As String
    '    If MainClass.m_application IsNot Nothing Then

    '        Return MainClass.m_application.Languages.GetText(key, defaulttext, params)

    '    Else
    '        Return defaulttext
    '    End If
    'End Function
End Module
