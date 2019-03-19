Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.Data.Filtering


Namespace Kernel.Attributes

    ''' <summary>
    ''' Stellt eine Auflistung von Merkmalen bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ClassDefinitions
        Inherits BaseCollection(Of ClassDefinition)
        Implements IDataCollection

        Private m_attributes As AttributeValueDefinitions

        ''' <summary>
        ''' Ermittelt die angegebene Attributedefinition anhand des Schlüssels der Klassifikation
        ''' </summary>
        ''' <param name="key">Der Schlüssel der Attribte-Klasse</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAttributeDefinition(ByVal key As String) As AttributeValueDefinition
            If m_attributes Is Nothing Then
                m_attributes = New AttributeValueDefinitions(MainApplication)
            End If

            Return m_attributes.GetItem(key)

        End Function

        ''' <summary>
        ''' Ruft eine Klassifikation ab, die dieser Gruppe zugrunde liegt. existiert die Klasse nicht, wird diese angelegt
        ''' </summary>
        Function GetItemByItemGroup(ByVal Group As Group) As ClassDefinition
            If Group IsNot Nothing Then
                Return GetItemByItemGroup(Group.Key)
            Else
                Return Nothing
            End If

        End Function

        ''' <summary>
        ''' Ruft eine Klassifikation ab, die dieser Gruppe zugrunde liegt. existiert die Klasse nicht, wird diese angelegt
        ''' </summary>
        ''' <param name="GroupID">Die GruppenID. jede Gruppe ist einer Klassifikation zugewiesen</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetItemByItemGroup(ByVal GroupID As String) As ClassDefinition
            For Each item As ClassDefinition In Me
                If item.ParentGroupID.Equals(GroupID) Then
                    Return item
                End If
            Next
            'keine Klassifiktion zu dieser Gruppe gefunden; Lege eine neue an
            Dim newItem As ClassDefinition = Me.GetNewItem()

            newItem.ParentGroupID = GroupID
            newItem.Save()

            Me.Add(newItem) ' der eigenen auflistung hinzufügen

            Return newItem

        End Function
        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub


        Public Sub Initialize() Implements Data.IDataCollection.Initialize

        End Sub
    End Class
End Namespace