Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo

Namespace Kernel

    ''' <summary>
    ''' Enthält eine Auflistung von Kurztexte, Aufgaben 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Tasks
        Inherits BaseCollection(Of Task)
        Implements IDataCollection

        ''' <summary>
        ''' Ruft einen neue Aufgabe ab und setzt das Erstelldatum auf das aktuelle Datum
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As Task
            Dim newitem As Task = MyBase.GetNewItem()
            newitem.CreateDate = Date.Now
            newitem.Expiration = Nothing
            Return newitem

        End Function

        Public Sub New(ByVal BasisApplikation As MainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        ''' <summary>
        ''' Ruft eine neue Auflistung der Aufgaben ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewCollection() As ClausSoftware.Data.BaseCollection(Of ClausSoftware.Kernel.Task)
            Dim newItemCollection As New Tasks(MainApplication)
            Return newItemCollection
        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize

            Dim displayProps As New Text.StringBuilder            
            displayProps.Append("TaskFinished;")
            displayProps.Append("Subject;")
            displayProps.Append("CreateDate;")
            displayProps.Append("Expiration;")
            Me.DisplayableProperties = displayProps.ToString

        End Sub
    End Class
End Namespace