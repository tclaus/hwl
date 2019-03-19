Namespace GlobalSearch

    ''' <summary>
    ''' Stellt eine Auflistung von Suchergebnissen dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SearchResults
        Inherits List(Of SearchResult)

        Public Overloads Sub AddRange(ByVal items As List(Of Data.StaticItem))

            For Each item As Data.StaticItem In items

                Me.Add(item)
            Next


        End Sub

        Public Overloads Sub Add(ByVal item As Data.StaticItem)
            MyBase.Add(New GlobalSearch.SearchResult(item))
        End Sub

    End Class
End Namespace
