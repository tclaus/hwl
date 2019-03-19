Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo

Namespace Kernel.Security

    ''' <summary>
    ''' Enthält eine Auflistung von Benutzer
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Users
        Inherits BaseCollection(Of User)
        Implements IDataCollection


        Public Sub New(ByVal BasisApplikation As mainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        ''' <summary>
        ''' Durchsucht die Benutzerliste nach einem Benutzer mit der angegebenen ID; 
        ''' Kann diese ID nicht gefunden  werden; wird ein Datensatz angelegt
        ''' </summary>
        ''' <param name="userID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetItem(userID As String) As User

            If String.IsNullOrEmpty(userID) Then Return Nothing

            Dim foundItem As User
            foundItem = MyBase.GetItem(userID)

            If foundItem Is Nothing Then
                ' Kein Benutzer mit diesem Namen / Code gefunden; möglicherweise ein Computernamen/Username kombination? 
                Dim newUser As User = Me.GetNewItem

                newUser.ReplikID = userID
                If userID.Contains("/") Then
                    newUser.Name = userID.Substring(userID.IndexOf("/") + 1)
                End If

                Me.Add(newUser)
                newUser.Save()
                Return newUser
            Else
                Return foundItem
            End If

        End Function

        ''' <summary>
        ''' Sucht einen Benutzernamen anhand des LoginNames und liefert das User-Objekt oder nothing zurück, wenn nichts gefunden werden konnte
        ''' </summary>
        ''' <param name="username"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Find(ByVal username As String) As User
            For Each item As User In Me
                If item.Name.Equals(username) Then
                    Return item
                End If
            Next
            Return Nothing
        End Function

        ''' <summary>
        ''' Ruft eine Kombination aus Rechnername und Benutzernamen ab. Damit kann auch auf Systemen, ohne Benutzersteuerung ein eindeutiger Benutzer festgelegt werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property MachineUserName() As String
            Get
                Dim username As String = My.Computer.Name & "/" & Environment.UserName

                username = username.Replace(" ", "_")
                ' Leerzeichen ausfiltern
                Return username
            End Get
        End Property

        ''' <summary>
        ''' Ruft einen Benutzernamen anhand des aktuellen Compuer-Logins ab 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserByComputer() As Security.User
            Dim name As String = MachineUserName

            Dim newUser As User = Me.GetNewItem()
            newUser.Name = name
            newUser.ReplikID = name
            Return newUser

        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim display As New Text.StringBuilder
            display.Append("Name;")
            display.Append("DiscountValue;")
            Me.DisplayableProperties = display.ToString


        End Sub
    End Class
End Namespace