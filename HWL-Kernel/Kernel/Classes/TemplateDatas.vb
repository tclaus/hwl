Option Explicit On
Option Strict On


Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering
Imports System.Text
Imports DevExpress.Xpo.DB

Namespace Kernel

    ''' <summary>
    ''' Stellt eine Liste von Gruppen da.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TemplateDatas
        Inherits BaseCollection(Of TemplateData)
        Implements IDataCollection

        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)
            Initialize()

        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub


        Public Sub Initialize() Implements Data.IDataCollection.Initialize
            Dim displayable As New StringBuilder
            displayable.Append("DataName;")
            displayable.Append("ExactOne;")
            displayable.Append("OneOrMore;")
            displayable.Append("OptionalItem;")
            displayable.Append("ZeroOrMore;")

            Me.DisplayableProperties = displayable.ToString

            Me.Sorting = New SortingCollection()
            Me.Sorting.Add(New SortProperty("ListID", SortingDirection.Ascending))




        End Sub
    End Class
End Namespace
