Imports ClausSoftware.Tools
Imports ClausSoftware.Data


Namespace Kernel
    ''' <summary>
    ''' 'Hält eine Auflistung von kürzlich verwendeten Elementen
    ''' </summary>
    ''' <remarks></remarks>
    Public Class RecentlyUsedItems
        Inherits BaseCollection(Of RecentlyUsed)
        Implements IDataCollection

        ''' <summary>
        ''' Anzahl der maximal zuletzt genutzen elemente, sind mehr elemente in dem Ringpuffer, werden die überzähligen Elemente entfernt
        ''' </summary>
        ''' <remarks></remarks>
        Public Const LastUsedMaxCount As Integer = 25

        
        ''' <summary>
        ''' Erstellt eine neue Auflistung der zuletzt genutzen Elemente des aktuellen Benutzers
        ''' </summary>
        ''' <param name="BasisApplikation"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)
            Me.CriteriaString = "UserName='" & MainApplication.CurrentUser.Key & "'"
            Me.Sorting.Add(New SortProperty("CalledAt", DB.SortingDirection.Descending))

            Initialize()

        End Sub

        Public Sub DeleteOldItems()


            If Me.Count > LastUsedMaxCount Then
                Dim oldestItem As Integer = Me(LastUsedMaxCount).ID
                Dim sql As String = "DELETE FROM " & RecentlyUsed.TableName & " WHERE username='" & MainApplication.CurrentUser.Key & "' and ID<" & oldestItem
                
                Dim deletedItems As Integer = MainApplication.Database.ExcecuteNonQuery(sql)
                Debug.Print("Alte Elemente aus RecentlyUsed gelöscht:" & deletedItems)
                Me.Reload()
            End If


        End Sub

        ''' <summary>
        ''' Speichert die Auflistung der MRU Elemente ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()

            MyBase.Save()         

        End Sub

        ''' <summary>
        ''' Ruft ein Objekt anhand des Zieltyps ab
        ''' </summary>
        ''' <param name="targetID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemByTargetID(targetID As String) As RecentlyUsed
            For Each item As RecentlyUsed In Me
                If item.ParentItemID.Equals(targetID) Then Return item
            Next
            Return Nothing
        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder

            
            Me.DisplayableProperties = DisplayProps.ToString



        End Sub
    End Class
End Namespace