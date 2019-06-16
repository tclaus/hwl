Option Explicit On
Option Strict On


Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports System.Runtime.InteropServices

Namespace Kernel

    ''' <summary>
    ''' Stellt eine Liste von Resourcen des Terminplaners da
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AppointmentsResources
        Inherits BaseCollection(Of AppointmentsResource)
        Implements IDataCollection



        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub Initialize() Implements IDataCollection.Initialize

        End Sub
    End Class
End Namespace


