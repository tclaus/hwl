Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo

Namespace Kernel.Security

    ''' <summary>
    ''' Enthält eine Auflistung von Kurztexte, Aufgaben 
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class SecurityLocks
        Inherits BaseCollection(Of SecurityLock)
        Implements IDataCollection


        Public Sub New(ByVal BasisApplikation As MainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub



        ''' <summary>
        ''' Löcht alle sperren des aktellen Benutzers
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearAllLocks()
            Me.Criteria = New DevExpress.Data.Filtering.BinaryOperator("LockByName", MainApplication.CurrentUser.Name)
            Me.Reload()
            Me.Delete()
        End Sub

        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim display As New Text.StringBuilder

            Me.DisplayableProperties = display.ToString





        End Sub
    End Class
End Namespace