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
    Public Class Templates
        Inherits BaseCollection(Of Template)
        Implements IDataCollection

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)
            Initialize()

        End Sub

        ''' <summary>
        ''' Erstellt eien neue Auflistung der Templates mit dem angegebenen Kriterienausdruck
        ''' </summary>
        ''' <param name="BasisApplikation"></param>
        ''' <param name="criteria"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As CriteriaOperator)

            MyBase.New(BasisApplikation, criteria)
            Initialize()

        End Sub

        Public Sub Initialize() Implements Data.IDataCollection.Initialize
            Dim sortProps As SortingCollection
            sortProps = New SortingCollection(Nothing)

            sortProps.Add(New SortProperty("Name", SortingDirection.Ascending))

            Me.Sorting = sortProps

            'AnzeigeProperties(festlegen)
            Dim displayProps As New StringBuilder
            displayProps.Append("Name;")
            displayProps.Append("Key;")
            displayProps.Append("ParentID;")

            Me.DisplayableProperties = displayProps.ToString

        End Sub
    End Class
End Namespace
