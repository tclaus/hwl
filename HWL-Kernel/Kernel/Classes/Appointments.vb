Option Explicit On
Option Strict On


Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports System.Runtime.InteropServices

Namespace Kernel

    ''' <summary>
    ''' enthält eine Auflistung von Termine
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Appointments
        Inherits BaseCollection(Of Appointment)
        Implements IDataCollection

        ''' <summary>
        ''' Ruft eine neue Auflistung von Terminen ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewCollection() As Data.BaseCollection(Of Appointment)
            Dim apList As New Appointments(MainApplication)
            Return apList
        End Function

        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub


        Public Sub Initialize() Implements IDataCollection.Initialize
            Me.DeleteObjectOnRemove = True

        End Sub
    End Class
End Namespace