

''' <summary>
''' stellt Funktionen bereit, um Dialoge aufzubauen 
''' </summary>
''' <remarks></remarks>
Public Class Vistadialogs


    Public Shared Function CommandDialog() As Boolean
        Dim links As New List(Of Vista_Api.CommandLink)
        Dim c As New Vista_Api.CommandLink(Vista_Api.CommandLink.DisplayStyle.Arrow, "wichtiger Text", "Description")

        links.Add(c)

        ' Hier sollte irgendwann mal ein Vista-Command like Dialog entstehen..


        Using cd As New Vista_Api.CommandDialog(links)

            cd.ShowIcon = True
            cd.ShowCancelButton = True

            cd.ShowDialog()
        End Using

        Return True
    End Function



    ' |Langtext|Kurztext

End Class
