Option Explicit On
Option Strict On

Imports ClausSoftware.Data



Namespace Kernel

    ''' <summary>
    ''' Enthält die Tabelle der Einheiten
    ''' </summary>
    ''' <remarks></remarks>
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Units
        Inherits BaseCollection(Of Unit)
        Implements IDataCollection

        Private m_unitListByID As New Dictionary(Of Integer, Unit)

        ''' <summary>
        ''' Füllt die Liste der Einheiten, wenn es eine Erstinstallation war, und die LIste absolut leer ist
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub FillMinimalUnitList()
            Dim newItem As Unit
            If Me.Count = 0 Then


                newItem = Me.GetNewItem
                newItem.Name = MainApplication.Languages.GetText("unitEmpty", "  ")
                newItem.ShortName = MainApplication.Languages.GetText("UnitEmptyShort", "   ")
                newItem.Decimals = 0
                Me.Add(newItem)
                newItem.Save()

                newItem = Me.GetNewItem
                newItem.Name = MainApplication.Languages.GetText("unitItem", "Stück")
                newItem.ShortName = MainApplication.Languages.GetText("UnitItemshort", "stk")
                newItem.Decimals = 0
                Me.Add(newItem)
                newItem.Save()
            End If


        End Sub

        Private Sub FillUnitList()
            m_unitListByID.Clear()
            For Each item As Unit In Me
                m_unitListByID.Add(item.ID, item)
            Next
        End Sub

        ''' <summary>
        ''' Holt eine einheit anhand der ID aus einem Cache
        ''' </summary>
        ''' <param name="ID">Die Zugriffsnummer der Einheit</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetItem(ByVal ID As Integer) As Unit
            If m_unitListByID.ContainsKey(ID) Then
                Return m_unitListByID(ID)
            Else
                Return Nothing
            End If


        End Function

        Public Overrides Sub Reload()
            MyBase.Reload()
            FillUnitList()
        End Sub




        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim display As New Text.StringBuilder
            display.Append("Name;")
            display.Append("ShortName;")
            display.Append("Decimals;")
            Me.DisplayableProperties = display.ToString

            Me.Sorting.Clear()
            Me.Sorting.Add(New SortProperty("Name", DB.SortingDirection.Ascending))

        End Sub
        ''' <summary>
        ''' Sucht eine Einheit anhand ihres Namens
        ''' </summary>
        ''' <param name="unitName">der Name der zu suchenden Einheit</param>
        ''' <param name="autoCreate">Legt eine einheit automatisch an, falls nicht gefunden werden konnte</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function FindUnit(ByVal unitName As String, ByVal autoCreate As Boolean) As Unit

            If unitName Is Nothing Then unitName = String.Empty '' Keine Nothings weiterverarbeiten

            If unitName.Length > 50 Then unitName = unitName.Substring(0, 49)

            If unitName.Length > 0 Then
                If unitName.Trim.Length = 0 Then
                    unitName = " "  ' Mehrfache Leerzeichen entfernen; nur ein einzelnes Leerzeichen zulassen

                End If
            End If

            For Each unitItem As Unit In MainApplication.Units
                If unitItem.Name.Equals(unitName, StringComparison.OrdinalIgnoreCase) Then
                    Return unitItem
                End If
            Next

            If autoCreate Then
                Dim newUnit As Unit = MainApplication.Units.GetNewItem
                newUnit.Name = unitName
                MainApplication.Units.Add(newUnit)
                newUnit.Save()
                MainApplication.Units.FillUnitList() ' Liste aktualisieren lassen
                Return newUnit
            End If

            Return Nothing
        End Function

        Public Sub New(ByVal BasisApplikation As MainApplication)
            MyBase.New(BasisApplikation)

            FillUnitList()

            Initialize()
        End Sub
    End Class
End Namespace