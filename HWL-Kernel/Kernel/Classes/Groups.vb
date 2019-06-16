Option Explicit On
Option Strict On


Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering
Imports System.Text
Imports DevExpress.Xpo.DB

Namespace Kernel

    ''' <summary>
    ''' Stellt eine Liste von Gruppen da.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Groups
        Inherits BaseCollection(Of Group)
        Implements IDataCollection

        Private Shared m_rootGroup As Group
        Private Shared m_rootKey As String = New String("F"c, 32)

        ''' <summary>
        ''' Ruft die oberste Vater-ID ab.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property RootID() As String
            Get
                Return m_RootKey
            End Get
        End Property

        ''' <summary>
        ''' Ruft die oberste Gruppe ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property RootGroup() As Group
            Get
                Return m_rootGroup
            End Get
        End Property


        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)
            Initialize()

        End Sub

        Public Sub New(ByVal baseApplication As MainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(baseApplication, criteria)
        End Sub

        ''' <summary>
        ''' Sucht eine Gruppe mit dem angegebenen Namen
        ''' </summary>
        ''' <param name="groupName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FindGroup(ByVal groupName As String) As Group

            For Each group As Group In MainApplication.Groups
                If group.Name.Equals(groupName, StringComparison.OrdinalIgnoreCase) Then
                    Return group
                End If
            Next
            Return Nothing
        End Function


        '''' <summary>
        '''' Ruft eine neue Instanz einer Gruppe ab
        '''' </summary>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Function GetNewItem() As Group
        '    Return New Group(MainApplication.Session)

        'End Function

        Public Sub Initialize() Implements Data.IDataCollection.Initialize
            Dim sortProps As SortingCollection
            sortProps = New SortingCollection(Nothing)

            sortProps.Add(New SortProperty("Name", SortingDirection.Ascending))
            sortProps.Add(New SortProperty("ID", SortingDirection.Ascending))


            'Immer das "ALL" - element erstellen
            If m_rootGroup Is Nothing Then
                m_rootGroup = Me.GetItem(RootID)
                If m_rootGroup Is Nothing Then
                    m_rootGroup = Me.GetNewItem
                    m_rootGroup.Name = "Alle Artikel"
                    m_rootGroup.ReplikID = RootID
                    m_rootGroup.Save()
                    Me.Add(m_rootGroup)
                End If

            End If




            Me.Sorting = sortProps
        End Sub

        Public Overrides Function GetNewCollection() As Data.BaseCollection(Of Group)
            Return MyBase.GetNewCollection()
        End Function

    End Class
End Namespace
