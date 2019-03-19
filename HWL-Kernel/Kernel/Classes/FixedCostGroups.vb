Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Namespace Kernel


    ''' <summary>
    ''' Stellt eine Liste von Positionen dar.
    ''' Positionen verknüpfen Dokumenete und Artikel in Positionsgruppen zusammen.
    ''' </summary>
    ''' <remarks>Eine Position stellt eine Gruppe von Artikel dar.</remarks>
    Public Class FixedCostGroups

        Inherits BaseCollection(Of FixedCostGroup)
        Implements IDataCollection

        ''' <summary>
        ''' Prüft, ob eine Gruppe mit dem angegebenen Namen bereits existiert
        ''' </summary>
        ''' <param name="name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ContainsGroupName(ByVal name As String) As Boolean
            For Each item As FixedCostGroup In Me
                If item.GroupName.Equals(name, StringComparison.InvariantCultureIgnoreCase) Then
                    Return True
                End If
            Next
            Return False

        End Function

        ''' <summary>
        ''' Ruft eine Grupp anhand des angegeben Namens ab. Erstellt die Gruppe, falls diese noch nicht existiert
        ''' </summary>
        ''' <param name="name">Der Anzeigename der gesuchten Gruppe</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGroupByName(ByVal name As String) As FixedCostGroup
            For Each item As FixedCostGroup In Me
                If item.GroupName.Equals(name, StringComparison.InvariantCultureIgnoreCase) Then
                    Return item
                End If
            Next
            Debug.Print("Fixkostengruppe '" & name & "' konnte nicht gefunden werden. Lege diese neu an.")
            Dim newGroup As FixedCostGroup = Me.GetNewItem
            newGroup.GroupName = name
            newGroup.Save()
            Me.Add(newGroup)

            Return newGroup

        End Function

        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)
            Initialize()
        End Sub

        ''' <summary>
        ''' Legt sichtbare Eigenschaften für die Anzeige, zB Grids fest
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder
            DisplayProps.Append("GroupName")

            Me.DisplayableProperties = DisplayProps.ToString
        End Sub


    End Class
End Namespace