Option Explicit On
Option Strict On


Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering
Imports System.Text
Imports DevExpress.Xpo.DB

Namespace Kernel

    ''' <summary>
    ''' Stellt eine Liste von Lohnkoten dar.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class LoanAccounts
        Inherits BaseCollection(Of LoanAccount)
        Implements IDataCollection

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)
            Initialize()

        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub


        Public Sub Initialize() Implements Data.IDataCollection.Initialize
            Dim displayable As New StringBuilder

            Me.DisplayableProperties = displayable.ToString

            Me.Sorting = New SortingCollection()
            Me.Sorting.Add(New SortProperty("Name", SortingDirection.Ascending))




        End Sub
    End Class
End Namespace
