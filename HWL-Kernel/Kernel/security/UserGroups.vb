Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo

Namespace Kernel.Security

    ''' <summary>
    ''' Enthält eine Auflistung von Benutzergruppen dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Class UserGroups
        Inherits BaseCollection(Of UserGroup)
        Implements IDataCollection


        Public Sub New(ByVal BasisApplikation As mainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        ''' <summary>
        ''' Ruft eine neue Benutergruppe ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As UserGroup
            Dim newItem As UserGroup = MyBase.GetNewItem()

            Return newItem

        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim display As New Text.StringBuilder

            Me.DisplayableProperties = display.ToString


        End Sub
    End Class
End Namespace