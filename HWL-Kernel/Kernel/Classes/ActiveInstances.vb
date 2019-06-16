Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.Data.Filtering


Namespace Kernel

    ''' <summary>
    ''' Stellt eine Aufstellung aller derzeit angemeldeten Programmbenutzer dar. 
    ''' Beim Start wird der Rechnername- und Benutzername in diese Liste eingetragen, beimbeenden wider entfernt
    ''' </summary>
    ''' <remarks>Damit sollte mal eine Lizenzprüfung bei Multiuser-Betrieb realisiert werden.</remarks>
    Public Class ActiveInstances
        Inherits BaseCollection(Of ActiveInstance)
        Implements IDataCollection

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub


        ' 1. Anlegen eines neuen Accounts, den eigenen rechnernamen überschreiben
        ' 2. Prfen ob ein anderer Account existiert
        ' 3. Wenn ja, Meldung macehn

        ''' <summary>
        ''' Schreibt den eigenen Rechnernamen in diese Tabelle, bestehende Daten werden überschrieben
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub WriteLoginTag()
            Dim computername As String = My.Computer.Name

            Me.Filter = CriteriaOperator.Parse("ComputerName='" & computername & "'")
            ' alle bestehende des eigenen Compuetrs Löschen

            Do While Me.Count > 0
                Me(0).Delete()
            Loop


            ' eigenen Eintrag wieder anlegen
            Dim newInstance As ActiveInstance = Me.GetNewItem
            newInstance.Save()

            Me.Add(newInstance)

            Me.Filter = Nothing

            Dim otherInstances As String() = CheckLoggedInInstances()

            'If otherInstances.Length > 0 Then
            '    MainApplication.UserStats.SendStatistics("InstanceMonitor", "CurrentlyLogged-In:" & otherInstances.Length)
            'End If

        End Sub

        ''' <summary>
        ''' Liefert eine Liste mit allen anderen angemeldeten Computern zurück
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckLoggedInInstances() As String()
            Dim computername As String = My.Computer.Name
            Me.Filter = CriteriaOperator.Parse("ComputerName<>'" & computername & "'")

            Dim newList As New List(Of String)

            For Each item As ActiveInstance In Me
                newList.Add(item.ComputerName)
            Next

            Return newList.ToArray

        End Function

        ''' <summary>
        ''' Entfernt den eigenen Eintrag wieder 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RemoveOwnInstance()
            Dim computername As String = My.Computer.Name
            Me.Filter = CriteriaOperator.Parse("ComputerName ='" & computername & "'")

            Do While Me.Count > 0
                Me(0).Delete()
            Loop


        End Sub

        ''' <summary>
        ''' Ruft ein neues element ab, das die eigenen LoginInformationen enthält
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As ActiveInstance
            Dim newItem As ActiveInstance = MyBase.GetNewItem()

            Dim wi As System.Security.Principal.WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent

            newItem.ComputerName = My.Computer.Name

            newItem.UserName = wi.Name
            newItem.LoginTime = Date.Now
            Return newItem
        End Function

        Public Sub Initialize() Implements Data.IDataCollection.Initialize

            ' dies regelmässig untersuchen

        End Sub
    End Class
End Namespace