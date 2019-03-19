Module modDatabase

    ''' <summary>
    ''' Ruft den aktuell verwendeten servertype ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DbType() As ClausSoftware.Tools.enumServerType
        Return m_application.Connections.WorkConnection.Servertype
    End Function


    ''' <summary>
    ''' Konvertiert ein Datum in ein SQL-String
    ''' </summary>
    ''' <param name="dateValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConvertDate2SqlString(ByVal dateValue As Date) As String

        If DbType() = ClausSoftware.Tools.enumServerType.Access Then
            'help = "#" & Mid(inDat, 4, 2) & "/" & Left(inDat, 2) & "/" & Mid(inDat, 7, 4) & "#"
            Return "#" & dateValue.Day & "/" & dateValue.Month & "/" & dateValue.Year & "#"
        End If

        If DbType() = ClausSoftware.Tools.enumServerType.MySQL Then
            ' Help = "'" & Format(inDat, "yyyy-mm-dd") & "'"
            Return "'" & dateValue.ToString("yyyy-MM-dd") & "'"

        End If
        Return dateValue.ToString("d")
    End Function

End Module
