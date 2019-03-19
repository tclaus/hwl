Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data


Namespace Kernel.BOM


    ''' <summary>
    ''' Stellt ein Paar Artikel-Artikel da, das eine Stückliste darstellt
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("ArticleLinks")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class ArticleLink
        Inherits StaticItem
        Implements IDataItem


        Private m_parentArticleID As String

        Private m_articleID As String
        Private m_article As Article

        Private m_posNumber As String


        Private m_quantity As Double
        ''' <summary>
        ''' Ruft die Mengeneinheit des Artikels ab oder legt dieses fest. Bsp. Artikel ist "100m Kabel", dann kann in er Abzahl 23m stehen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("ItemCountInBOM", "Anzahl")> _
        <Persistent("Quantity")> _
        Public Property Quantity() As Double
            Get
                Return m_quantity
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Quantity", m_quantity, value)

            End Set
        End Property


        ''' <summary>
        ''' Ruft die Positionsnummer des Artikels innerhalb der stückliste ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(20)> _
        <Tools.DisplayName("PositionInBOM", "Pos.-Nr")> _
        <Persistent("Position")> _
        Public Property Position() As String
            Get
                Return m_posNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Position", m_posNumber, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den untegeordneten Artikel ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Article() As Article
            Get

                Return MainApplication.ArticleList.GetItem(ArticleID)
            End Get
            Set(ByVal value As Article)
                ArticleID = value.Key
            End Set
        End Property

        <Browsable(False)> _
        <Size(32)> _
                <Persistent("ArticleID")> _
                Public Property ArticleID() As String
            Get
                Return m_articleID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ArticleID", m_articleID, value)

            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID des übergeordneten Artikel ab, der diesem Link zugeordnet ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        <Size(32)> _
        <Persistent("ParentArticleID")> _
        Public Property ParentArticleID() As String
            Get
                Return m_parentArticleID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ParentArticleID", m_parentArticleID, value)
            End Set
        End Property


        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace