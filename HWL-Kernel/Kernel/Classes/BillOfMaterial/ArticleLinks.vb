Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.Data.Filtering


Namespace Kernel.BOM

    ''' <summary>
    ''' Stellt eine Liste mit Artikel-Artikel Verknüpfungen bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ArticleLinks
        Inherits BaseCollection(Of ArticleLink)
        Implements IDataCollection

        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

        ''' <summary>
        ''' Ruft ein neuen Artikel-link mit dem angegebenen Vater-Artikel ab
        ''' </summary>
        ''' <param name="parentItem"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function GetNewItem(ByVal parentItem As Article) As ArticleLink
            Dim newItem As ArticleLink = MyBase.GetNewItem
            newItem.ParentArticleID = parentItem.Key

            newItem.Quantity = 1
            newItem.Position = "0" ' Standard-Positionsnr. (ist nicht so wichtig)

            Return newItem
        End Function

        ''' <summary>
        ''' Ruft alle Artikel ab, die in dieser Links-Auflistung existieren
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetArticles() As Articles

            Dim colIDs As New List(Of String)

            'In einer Menge von IDs suchen

            Debug.Print("Suche nach den Sub-Artikeln")
            ' Baue auflistung der gesuchten ReplikIDs zusammen (Performant, wenn mehrere gesucht werden)
            For Each relation As ArticleLink In Me
                colIDs.Add(relation.ArticleID)
            Next
            Dim inCriteria As New DevExpress.Data.Filtering.InOperator("ReplikID", colIDs)

            If inCriteria.Operands.Count = 0 Then
                Dim criteria As Filtering.CriteriaOperator = Filtering.CriteriaOperator.Parse("False")
                Dim articleList As New Articles(mainApplication, criteria)
                Return articleList
            Else
                Dim articleList As New Articles(mainApplication, inCriteria)

                Debug.Print(articleList.Count & " Artikel gefunden")

                Return articleList
            End If

        End Function

        ''' <summary>
        ''' Ruft den Gesamtpreis aller Artikel ab, die in dieser Stückliste enthalten sind
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTotalBasePrice() As Decimal
            Dim totalbasePrice As Decimal

            For Each item As ArticleLink In Me
                totalbasePrice += item.Article.EinzelEK
            Next
            Return totalbasePrice

        End Function

        ''' <summary>
        ''' Ruft den Verkaufspreis (netto) ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTotalendPrice() As Decimal
            Dim totalEndPrice As Decimal

            For Each item As ArticleLink In Me
                totalEndPrice += item.Article.EinzelVK
            Next
            Return totalEndPrice

        End Function

        ''' <summary>
        ''' Ruft die Zeitauer in Minuten ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTotalTime() As Decimal
            Dim totalTime As Decimal

            For Each item As ArticleLink In Me
                totalTime += item.Article.TimeInMinutes
            Next
            Return totalTime

        End Function

        ''' <summary>
        ''' Fügt der auflistung der eigenen eigenschafrten die Artikeleigenschaften hinzu 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize() Implements Data.IDataCollection.Initialize
            Dim dispProps As New Text.StringBuilder


            ' eigene Eigenschaften einsammeln
            dispProps.Append("Quantity;")
            dispProps.Append("Position;")
            ' Alle Properties der Artikel einsammeln
            Dim successorProps As String() = MainApplication.ArticleList.DisplayableProperties.Split(";"c)


            For Each item As String In successorProps
                dispProps.Append("Article." & item & ";")
            Next


            Me.DisplayableProperties = dispProps.ToString
        End Sub
    End Class
End Namespace