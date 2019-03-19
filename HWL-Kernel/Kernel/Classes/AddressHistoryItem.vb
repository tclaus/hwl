Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Enthält einen History-Eintrag, der einen Vorgang innerhalb des Addressbuches beschreibt
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("AdressHistory")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class AddressHistoryItem
        Inherits TrackedItem
        Implements IDataItem

 
        Private m_addressID As String

        Private m_date As Date

        Private m_CategoryID As String

        Private m_text As String

        Private m_SystemMessage As Boolean

        Private m_parentItemID As String = ""

        ''' <summary>
        ''' Wenn dieser Meldung eine SystemMeldung war, steht hier die ID des Ausgangsdatensatzes drinn. 
        ''' Kann also eine Rechnung (Journaledokument), Mahnung, Forderung etc sein.. Verhindert doppel-Eintragunge
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

        ''' <summary>
        ''' Ruft einen Wert ab, der bestimmt, ob dieser Eintrag automatisch erzeugt ist. 
        ''' Vom System angelegte Ereignisse sollten vom Anwender nicht bearbeitet werden können.
        ''' </summary>
        ''' <remarks></remarks>
        <DisplayName("Systemfeld")> _
        <Persistent("SystemField")> _
                Public Property IsSystemMessage() As Boolean
            Get
                Return m_SystemMessage
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsSystemMessage", m_SystemMessage, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Text des Ereignisses ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <DisplayName("Kommentar")> _
        <Persistent("Itemstext")> _
        Public Property Text() As String
            Get
                Return m_text
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Text", m_text, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Text der Kategorie ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(32)> _
        <Persistent("ItemCategory")> _
        Private Property CategoryID() As String
            Get
                Return m_CategoryID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CategoryID", m_CategoryID, value)
            End Set
        End Property


        <DisplayName("Ereignis")> _
        Property Category() As HistoryCategory
            Get
                Return MainApplication.HistoryCategories.GetItem(Me.CategoryID)

            End Get
            Set(ByVal value As HistoryCategory)

                Me.CategoryID = value.Key
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Datum des Ereignisses ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Datum")> _
        <Persistent("ItemDate")> _
        Public Property ItemDate() As Date
            Get
                Return m_date
            End Get
            Set(ByVal value As Date)
                m_date = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID des Addresseintrages ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("AdressID")> _
                <Indexed()> _
                <Size(32)> _
                Private Property AddressID() As String
            Get
                Return m_addressID
            End Get
            Set(ByVal value As String)
                SetPropertyValue("AddressHistory", m_addressID, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft die Adresse des Eintrages ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Adress() As Adress
            Get
                Return MainApplication.Adressen.GetItem(Me.AddressID)
            End Get
            Set(ByVal value As Adress)
                If value IsNot Nothing Then
                    AddressID = value.Key
                Else
                    AddressID = ""
                End If
            End Set
        End Property



        Public Overrides Function ToString() As String
            Return Me.Text
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

           

        End Sub
    End Class
End Namespace