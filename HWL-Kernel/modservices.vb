Module modservices


    ''' <summary>
    ''' Ermittelt aus der Kommandozeile  einen Parameter der mit diesem Namen angegeben wurde
    ''' </summary>
    ''' <param name="paramName">Ein benannter Paramater, der mit einem doppelpunkt (:) seinen Wert einleitet</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCommandLineParameter(ByVal paramName As String) As String
        Dim para As String = paramName

        Dim argsList() As String = Environment.CommandLine.Split(New Char() {"/"c}, StringSplitOptions.RemoveEmptyEntries)

        For Each arg As String In argsList
            If arg.ToLower.StartsWith(para & ":") Or arg.ToLower.StartsWith(para & "=") Then
                ' Parameter gefunden, nun den Wert ermitteln
                arg = arg.ToLower.Replace(para, "")
                arg = arg.Trim ' Leerzeichen entfernen
                Return arg.Trim(New Char() {"'"c, """"c, ":"c, "="c})  ' Anführungszeichen entfernen
            End If

        Next arg
        Return String.Empty

    End Function
End Module
