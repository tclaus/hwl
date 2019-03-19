Imports ClausSoftware.Tools
Imports ClausSoftware.Data


Namespace Kernel.Attributes
    ''' <summary>
    ''' 'Hält eine Auflistung Artikel bereit, die durch einen Nachfolger ersetzt wurden
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ArticleReplacements
        Inherits BaseCollection(Of ArticleReplacement)
        Implements IDataCollection

      
        ''' <summary>
        ''' Ruf ein neues Element ab und weist das aktuelle Datum zu
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As ArticleReplacement
            Dim newITem As ArticleReplacement = MyBase.GetNewItem()

            Return newITem
        End Function

        ''' <summary>
        ''' Ruft eine Auflistung von Vorgängern ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("ArticlesPredecessors", "Vorgänger (veraltet)")> _
        Public ReadOnly Property Predecessors() As List(Of Article)
            Get
                Dim newArticleLIst As New List(Of Article)
                For Each item As ArticleReplacement In Me
                    newArticleLIst.Add(item.Predecessor)
                Next
                Return newArticleLIst
            End Get

        End Property

        ''' <summary>
        ''' Ruft eine Auflistung von Nachfolgeartikeln ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("ArticlesSuccessors", "Nachfolger")> _
        Public ReadOnly Property Successors() As List(Of Article)
            Get
                Dim newArticleLIst As New List(Of Article)
                For Each item As ArticleReplacement In Me
                    newArticleLIst.Add(item.Successors)
                Next
                Return newArticleLIst
            End Get

        End Property

        ''' <summary>
        ''' Ruft den Ersetzungsartikel für ein gegebenen veraltetets Element ab, falls vorhanden
        ''' </summary>
        ''' <param name="orgItem">Der Artikel für den ein Nachfolgeartikel gesucht wird.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSucccessorItem(ByVal orgItem As Article) As ArticleReplacements
            Dim cr As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator("OldItemID", orgItem.Key, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
            Me.Filter = cr

            Return Me

        End Function

        ''' <summary>
        ''' Falls es einen Vorgängerartikel gibt, wird dieser abgerufen
        ''' </summary>
        ''' <param name="orgItem">Der Artikel zu dem ein Vorgänger gesucht wird</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPredecessor(ByVal orgItem As Article) As ArticleReplacements
            Dim cr As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator("ReplacedByID", orgItem.Key, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
            Me.Filter = cr
            Return Me

        End Function

        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator)

            MyBase.New(BasisApplikation, criteria)
            Initialize()

        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)
            Initialize()

        End Sub


        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder



            ' Me.DisplayableProperties = DisplayProps.ToString
        End Sub
    End Class
End Namespace