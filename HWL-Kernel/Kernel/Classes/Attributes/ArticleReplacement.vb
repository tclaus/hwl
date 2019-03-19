Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports ClausSoftware.Data

Namespace Kernel.Attributes

    ''' <summary>
    ''' Enthält einen Artikelersetzung
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(ArticleReplacement.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class ArticleReplacement
        Inherits TrackedItem
        Implements IDataItem

        Public Const Tablename As String = "ArticleReplacements"

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_OldItemID As String

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_replacedByID As String

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_note As String
        ''' <summary>
        ''' Ruft eine Notiz ab, die die ARt der Ersetzung näher beschreibt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("Note", "Notiz")> _
        <Persistent("Note")> _
        Public Property Note() As String
            Get
                Return m_note
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Note", m_note, value)
            End Set
        End Property

        <Indexed()> _
        <Size(32)> _
        <Persistent("ReplacedByID")> _
        Friend Property ReplacedByID() As String
            Get
                Return m_replacedByID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReplacedByID", m_replacedByID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Ersetzungsartikel ab oder legt diesen fest
        ''' Gibt nothing zurück, wenn der Artikel keinen direkten Nachfolger hat.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <PersistentAlias("ReplacedByID")> _
        Property Successors() As Article
            Get
                Return MainApplication.ArticleList.GetItem(Me.ReplacedByID)
            End Get
            Set(ByVal value As Article)
                If value IsNot Nothing Then
                    Me.ReplacedByID = value.Key
                Else
                    Me.ReplacedByID = String.Empty
                End If
            End Set
        End Property
        ''' <summary>
        ''' Ruft die ID des bisherigen Artikels ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <Size(32)> _
        <Persistent("OldItemID")> _
        Friend Property OldItemID() As String
            Get
                Return m_OldItemID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("OldItemID", m_OldItemID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den veralteten Artikel ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Predecessor() As Article
            Get
                Return MainApplication.ArticleList.GetFromDB(Me.OldItemID)
            End Get
            Set(ByVal value As Article)
                If value Is Nothing Then
                    Throw New ArgumentException("Der Wert des alten Artikes darf nicht  leer sein")
                End If
                Me.OldItemID = value.Key

            End Set
        End Property
      
        Public Sub New(ByVal session As Session)
            MyBase.New(session)



        End Sub
    End Class
End Namespace