Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data


Namespace Kernel.Attributes


    ''' <summary>
    ''' Stellt eine Markmaleklasse dar. Diese enthält eine Auflistung von verwendbaren Merkmalen für eine bestimmte Gruppe. 
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("ClassDefinition")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class ClassDefinition
        Inherits StaticItem
        Implements IDataItem
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_name As String

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_valueDefinitions As AttributeValueDefinitions

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_parentID As String

        ''' <summary>
        ''' Ruft einen Satz an Definitionen ab die genau für diese Klasse belegt wurden
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ValueDefinitions() As AttributeValueDefinitions
            Get
                If m_valueDefinitions Is Nothing Then
                    Dim Criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("AttributeClassID = '" & Me.Key & "'")
                    m_valueDefinitions = New AttributeValueDefinitions(MainApplication, Criteria)
                End If
                Return m_valueDefinitions
            End Get
        End Property

        ''' <summary>
        ''' Läd die Klassendefinietion neu aus der Datenbank ein
        ''' </summary>
        ''' <remarks></remarks>
        Shadows Sub Reload()
            MyBase.Reload()
            If m_valueDefinitions IsNot Nothing Then
                m_valueDefinitions.Reload()
            End If

        End Sub

        Private m_parentDefinitions As List(Of AttributeValueDefinition)

        ''' <summary>
        ''' Ruft die Liste von Attributedefinituionen ab, die durch übergeordnete Gruppen definiert wurden. Diese sind in dieser Auflistung nicht änderbar
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetParentDefinitions() As List(Of AttributeValueDefinition)
            If m_parentDefinitions Is Nothing Then
                m_parentDefinitions = New List(Of AttributeValueDefinition)
            End If
            m_parentDefinitions.Clear()
            Dim parentGroup As Group = MainApplication.Groups.GetItem(Me.ParentGroupID)
            If parentGroup.ParentGroup IsNot Nothing AndAlso Not parentGroup.ParentGroup.IsRootGroup Then
                For Each item As AttributeValueDefinition In parentGroup.ParentGroup.AttributeClass.ValueDefinitions
                    m_parentDefinitions.Add(item)
                Next
            End If

            Return m_parentDefinitions
        End Function

        ''' <summary>
        ''' Löscht diese Klassendefinition und alle Werte-Paare
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Delete()

            ' Löscht die Attribute-Definition dieser Klasse
            Dim sql As String = "DELETE FROM " & Attributes.AttributeValueDefinition.TableName & " WHERE AttributeClassID='" & Me.Key & "'"
            m_mainApplication.Database.ExcecuteNonQuery(sql)

            ' Löscht nun alle zugewiesenen Werte
            sql = "DELETE FROM " & Attributes.AttributeValue.TableName & " WHERE AttributeID='" & Me.Key & "'"
            m_mainApplication.Database.ExcecuteNonQuery(sql)

            MyBase.Delete()


        End Sub

        ''' <summary>
        ''' Fügt der Auflistung von Werten einen neuen eintrag hinzu
        ''' </summary>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Sub Add(ByVal value As AttributeValueDefinition)

            value.AttributeClassID = Me.Key
            ValueDefinitions.Add(value)
        End Sub

        ''' <summary>
        ''' Speichert die Klassendefinition und alle dort enthaltenen Attributedefinitionen ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()
            MyBase.Save()
            ValueDefinitions.Save()

        End Sub

        ''' <summary>
        ''' Ruft die Bezeichnung der Attribute-Klasse ab oder legt diese fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Die Klasse ist normalerweise identisch mit der Gruppe.</remarks>
        <DevExpress.Xpo.DisplayName("KlassenName")> _
        <Size(50)> _
        <Persistent("ClassName")> _
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Name", m_name, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Gruppe ab, die dieser Attributklasse zugrunde liegt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Group As Group
            Get
                Return m_mainApplication.Groups.GetItem(Me.ParentGroupID)
            End Get
            Set(ByVal value As Group)
                If value IsNot Nothing Then
                    Me.ParentGroupID = value.Key
                End If
            End Set
        End Property

        ''' <summary>
        ''' Stellt einen Verweis auf eine übergeordnete Gruppen-Klasse dar
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <Size(32)> _
        <Persistent("ParentID")> _
        Public Property ParentGroupID() As String
            Get
                Return m_parentID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ParentID", m_parentID, value)
            End Set
        End Property


        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace