Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.Data.Filtering


Namespace Kernel.AboItems

    Public Class AboItems
        Inherits BaseCollection(Of AboItem)
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
        ''' Ruft ein neues element ab, das die eigenen LoginInformationen enthält
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As AboItem
            Dim newItem As AboItem = MyBase.GetNewItem()

            Return newItem
        End Function

        Public Sub Initialize() Implements Data.IDataCollection.Initialize

            ' dies regelmässig untersuchen

        End Sub
    End Class
End Namespace