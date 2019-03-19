Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports ClausSoftware.Data

Namespace Kernel
    ''' <summary>
    ''' Enthält eine Auflistung von elementtypen, die als 'Kürzlich benutzt' verwendet werden können
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum RecentItemType
        AdressItem
        TransactionItem
        CashItem
        JournalDocumentItem
        ArticleItem
        ''' <summary>
        ''' Stellt den Typ eine Kurzbriefes dar
        ''' </summary>
        ''' <remarks></remarks>
        Letter

        ''' <summary>
        ''' Beim Auswerten ist ein Fehler aufgetreten
        ''' </summary>
        ''' <remarks></remarks>
        [Unknown]
    End Enum

    ''' <summary>
    ''' Enthält einen Eintrag, der ein zuletzt verwendetes Element beschreibt
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(RecentlyUsed.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class RecentlyUsed
        Inherits TrackedItem
        Implements IDataItem

        Public Const TableName As String = "RecentlyUsed"

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_parentItemID As String = ""
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_calledAt As Date
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_ItemTypeName As String

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_userName As String


        ''' <summary>
        ''' Ruft den Benutzernamen ab oder legt diesen fest.
        ''' Benutzername ist entweder Rechnername / Username oder die ID des Benutzers
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <Persistent("username")> _
        Public Property UserName() As String
            Get
                Return m_userName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UserName", m_userName, value)

            End Set
        End Property


        <Indexed()> _
        <Persistent("ItemTypeName")> _
        Private Property ItemTypeName() As String
            Get
                Return m_ItemTypeName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ItemTypeName", m_ItemTypeName, value)
            End Set
        End Property

        Private m_itemType As RecentItemType
        ''' <summary>
        ''' Ruft den Typ des eintrages ab oder legt diesen fest 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemType() As RecentItemType
            Get
                Return GetItemType(Me.ItemTypeName)
            End Get
            Set(ByVal value As RecentItemType)
                m_itemType = value

                Me.ItemTypeName = GetTypeName(value)

            End Set
        End Property

        ''' <summary>
        ''' Legt das Element fest 
        ''' </summary>
        ''' <param name="item"></param>
        ''' <remarks></remarks>
        Public Sub SetRecentItem(ByVal item As StaticItem)
            If item IsNot Nothing Then
                Me.ParentItemID = item.ReplikID
                Me.ItemType = GetRecentItemType(item)
                Me.UserName = MainApplication.CurrentUser.Key
            Else
                Debug.Print("Das neue Element wurde mit nothing zurückgegeben!")
            End If

        End Sub

        ''' <summary>
        ''' Ruft vom angegebenen Element die Typbezeichnung ab
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetRecentItemType(ByVal item As StaticItem) As RecentItemType
            If TypeOf item Is Kernel.Adress Then
                Return RecentItemType.AdressItem
            End If

            If TypeOf item Is Article Then
                Return RecentItemType.ArticleItem
            End If

            If TypeOf item Is CashJournalItem Then
                Return RecentItemType.CashItem
            End If

            If TypeOf item Is Transaction Then
                Return RecentItemType.TransactionItem
            End If

            If TypeOf item Is JournalDocument Then
                Return RecentItemType.JournalDocumentItem
            End If

            If TypeOf item Is Letter Then
                Return RecentItemType.Letter
            End If
            Debug.Assert(False, "Der Typ wurde nicht in GetItemTyp aufgenommen!")
            Return RecentItemType.Unknown

        End Function


        ''' <summary>
        ''' Ruft das Element ab. Das element wird dabei aus der Datenbank geladen
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetRecentlyUsedItem() As StaticItem
            Dim item As StaticItem

            Select Case Me.ItemType
                Case RecentItemType.AdressItem
                    item = MainApplication.Adressen.GetFromDB(Me.ParentItemID)
                Case RecentItemType.ArticleItem
                    item = MainApplication.ArticleList.GetFromDB(Me.ParentItemID)
                Case RecentItemType.CashItem
                    item = MainApplication.CashJournal.GetFromDB(Me.ParentItemID)
                Case RecentItemType.JournalDocumentItem
                    item = MainApplication.JournalDocuments.GetFromDB(Me.ParentItemID)
                Case RecentItemType.TransactionItem
                    item = MainApplication.Transactions.GetFromDB(Me.ParentItemID)
                Case RecentItemType.Letter
                    item = MainApplication.Letters.GetFromDB(Me.ParentItemID)


                Case Else
                    Debug.Print("Typ " & Me.ItemType.ToString & " nicht unterstützt !")

                    Return Nothing
            End Select

            Return item

        End Function

        ''' <summary>
        ''' Ruft einen kurzen Text-Bezeicner für den Datentyp ab 
        ''' </summary>
        ''' <param name="itemType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetTypeName(ByVal itemType As RecentItemType) As String
            Select Case itemType
                Case RecentItemType.AdressItem : Return "AdressItem"
                Case RecentItemType.ArticleItem : Return "ArticleItem"
                Case RecentItemType.CashItem : Return "CashItem"
                Case RecentItemType.JournalDocumentItem : Return "JournalDocumentItem"
                Case RecentItemType.TransactionItem : Return "TransactionItem"
                Case RecentItemType.Letter : Return "Letter"

                Case Else
                    Throw New ArgumentException("Typ (" & itemType.ToString & ") nicht unterstützt !")
            End Select
        End Function

        ''' <summary>
        ''' Ruft von einem Typenschlüssel (String) das Typ-Objekt ab
        ''' </summary>
        ''' <param name="typename"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetItemType(ByVal typename As String) As RecentItemType
            Select Case typename
                Case "AdressItem" : Return RecentItemType.AdressItem
                Case "ArticleItem" : Return RecentItemType.ArticleItem
                Case "CashItem" : Return RecentItemType.CashItem
                Case "JournalDocumentItem" : Return RecentItemType.JournalDocumentItem
                Case "TransactionItem" : Return RecentItemType.TransactionItem
                Case "Letter" : Return RecentItemType.Letter

                Case Else
                    Debug.Print("Typ (" & typename & ") nicht unterstützt !")
                    Return RecentItemType.Unknown
            End Select
        End Function

        ''' <summary>
        ''' Ruft einen Zeitstempel ab, an dem das element zuletzt genutzt wurde und legt so eine Reihenfolge fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("called_at")> _
        Public Property CalledAt() As Date
            Get
                Return m_calledAt
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("CalledAt", m_calledAt, value)
            End Set
        End Property

        ''' <summary>
        ''' Enthält die ID des Ausgangselementes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <Size(32)> _
        <Persistent("ParentItemID")> _
        Public Property ParentItemID() As String
            Get
                Return m_parentItemID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ParentItemID", m_parentItemID, value)
            End Set
        End Property



        Public Sub New(ByVal session As Session)
            MyBase.New(session)



        End Sub
    End Class
End Namespace