Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.Data.Filtering


Namespace Kernel.Attributes

    ''' <summary>
    ''' Stellt eine Auflistung Werte-Defintionen bvereit. Alle Werte, die in einer Klasse vorkommen, sind hier gruppiert
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AttributeValueDefinitions
        Inherits BaseCollection(Of AttributeValueDefinition)
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

        End Sub
    End Class
End Namespace