Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo

Namespace Kernel

    ''' <summary>
    ''' Stellt die Liste aller Rohstoffpreise dar.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Rohstoffpreise
        Inherits BaseCollection(Of Rohstoffpreis)
        Implements IDataCollection


        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub Initialize() Implements IDataCollection.Initialize

        End Sub
    End Class
End Namespace