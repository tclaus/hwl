Option Explicit On
Option Strict On


Imports DevExpress.Xpo
Imports ClausSoftware.Data
Imports System.Drawing
Imports DevExpress.Data.Filtering

Namespace Kernel

    Enum TableID
        Article
        ArticleGroup

    End Enum

    ''' <summary>
    ''' Enthält einen Datensatz einer Rechnungsvorlage
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(TemplateData.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class TemplateData
        Inherits StaticItem
        Implements IDataItem

        Friend Const Tablename As String = "Schablone_Daten"

#Region "Properties"

        'insert into Material_Gruppen (Name,replikid,deleted,parentID)
        'select name,replikid,0,GruppenID from Material_Kategorien
        ' where replikid not in (select replikid from Material_Gruppen)



        ''' <summary>
        ''' Enthält den Verweis zum Vater-Template
        ''' </summary>
        ''' <remarks></remarks>
        Private m_parentID As String

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private m_uplink As String

        Private m_data As String

        Private m_requiredID As Integer

        Private m_tableID As Integer
        Private m_multiplikator As Double
        Private m_parentName As String
        Private m_listID As Integer

        ''' <summary>
        ''' Ruft den Schlüssel des Vater-Objektes ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <ComponentModel.Browsable(False)> _
        <Persistent("Schablone")> _
        <Size(32)> _
        Property TemplateID() As String
            Get
                If m_parentID Is Nothing Then
                    m_parentID = ""
                End If

                Return m_parentID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TemplateID", m_parentID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen der eigenschaft ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property DataName() As String
            Get
                Dim article As Article = MainApplication.ArticleList.GetItem(Me.Data)
                If article IsNot Nothing Then
                    Return article.ShortDescription
                Else
                    Return ""
                End If
            End Get

        End Property


        <ComponentModel.Browsable(False)> _
<Persistent("Uplink")> _
<Size(32)> _
Public Property Uplink() As String
            Get
                Return m_uplink
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Uplink", m_uplink, value)
            End Set
        End Property

        <ComponentModel.Browsable(False)> _
<Persistent("Data")> _
<Size(32)> _
Property Data() As String
            Get
                Return m_data
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Data", m_data, value)
            End Set
        End Property


        ''' <summary>
        ''' Zeigt an, das dieses Objekt in der Liste obligatorisch ist, also auf jeden Fall dazugehört
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("Required")> _
        Property RequiredID() As Integer
            Get
                Return m_requiredID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RequiredID", m_requiredID, value)
            End Set
        End Property

        ''' <summary>
        ''' Nur Artikel: Zeigt an, das in der Rechnungsvorlage dieser Artikel Wahlweise gewählt werden kann, muss aber nicht
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Nur für einzelne Artikel</remarks>
        <DisplayName("Optional")> _
        Property OptionalItem() As Boolean
            Get
                Return (RequiredID = 0)
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    RequiredID = 0
                Else
                    RequiredID = -1
                End If

            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, das dieser eintrag ein Ordner-eintrag ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property IsFolder() As Boolean
            Get
                If Uplink <> "0" And GetSubArticles.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get

        End Property


        Function GetSubArticles() As TemplateDatas
            Dim criteria As CriteriaOperator = CriteriaOperator.Parse("Uplink ='" & Me.ReplikID & "'")

            Dim sublists As New TemplateDatas(MainApplication, criteria)
            Return sublists
            
        End Function

        ''' <summary>
        ''' Zeigt an, das genau ein Artikel der gesamten Gruppe gewählt werden muss
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Nur Gruppe</remarks>
        <DisplayName("Genau 1 aus Gruppe")> _
        Property ExactOne() As Boolean
            Get
                Return (RequiredID = 1)
            End Get
            Set(ByVal value As Boolean)

                If value Then
                    RequiredID = 1
                Else
                    RequiredID = 0
                End If

            End Set
        End Property

        ''' <summary>
        ''' Keins, oder mehrere Elemente dder Gruppe
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Optional eins oder mehr")> _
        Property ZeroOrMore() As Boolean
            Get
                Return (RequiredID = 2)
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    RequiredID = 2
                Else
                    RequiredID = 0
                End If
            End Set
        End Property

        ''' <summary>
        ''' Genau ein Element der Gruppe
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Mindestends eins")> _
        Property OneOrMore() As Boolean
            Get
                Return (RequiredID = 3)
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    RequiredID = 3
                Else
                    RequiredID = 0
                End If
            End Set
        End Property

        <Persistent("Table")> _
        Property TableID() As Integer
            Get
                Return m_tableID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TableID", m_tableID, value)
            End Set
        End Property

        <Persistent("ParentName")> _
        Property ParentName() As String
            Get
                Return m_parentName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ParentName", m_parentName, value)
            End Set
        End Property

        <ComponentModel.Browsable(False)> _
        <Persistent("ListID")> _
        Property ListID() As Integer
            Get
                Return m_listID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ListID", m_listID, value)
            End Set
        End Property

#End Region

        ''' <summary>
        ''' Speichert den Eintrag ab und vergibt eine neue Kundennummer
        ''' </summary>
        ''' <remarks></remarks>
        Public Overloads Sub Save()


            MyBase.Save()
        End Sub


        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace
