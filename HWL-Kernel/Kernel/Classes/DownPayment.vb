Option Explicit On
Option Strict On
Imports ClausSoftware.Data


Namespace Kernel
    ''' <summary>
    ''' Enthält ein Einheitskennzeichnen wie Meter (m), Stück (stk) usw, sowie die Masseinheit und Anzeigeeinstellung.
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("Splittbuchungen")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class DownPayment
        Inherits StaticItem
        Implements IDataItem


        Private m_splitt As Integer
        Private m_ammount As Decimal
        Private m_text As String

        Private m_paidDate As Date
        Private m_oldPaidDate As String

        <Obsolete("Use 'PaidDate' instead. Dieses Feld war früher leider ein String - Feld...")> _
        <DisplayName("Zahlungsdatum")> _
<Persistent("Datum")> _
        Public Property Datum() As String
            Get
                Return m_oldPaidDate
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Datum", m_oldPaidDate, value)
            End Set
        End Property

        ''' <summary>
        ''' Datum der Buchung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("PaidDate", "Zahlungsdatum")> _
        <Persistent("PaidDate")> _
        Public Property PaidDate() As Date
            Get
                Return m_paidDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("PaidDate", m_paidDate, value)
            End Set
        End Property

        ''' <summary>
        ''' Text der Buchhung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("Description", "Bezeichnung")> _
        <Size(255)> _
        <Persistent("Text")> _
        Public Property Description() As String
            Get
                Return m_text
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", m_text, value)
            End Set
        End Property

        ''' <summary>
        ''' Betrag dieser Teilzahlung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("Ammount", "Betrag")> _
        <Persistent("Betrag")> _
        Public Property Ammount() As Decimal
            Get
                Return m_ammount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Ammount", m_ammount, value)
            End Set
        End Property

        ''' <summary>
        ''' ID der dazugehörigen Buchung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Splitt")> _
        Private Property TransactionID() As Integer
            Get
                Return m_splitt
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TransactionID", m_splitt, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die übergeordnete Transaktion ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParentTransaction() As Transaction
            Get
                Return m_mainApplication.Transactions.GetItem(Me.TransactionID)
            End Get
            Set(ByVal value As Transaction)
                Me.TransactionID = value.ID
            End Set
        End Property


        Public Overrides Function ToString() As String
            Return Me.Description
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace