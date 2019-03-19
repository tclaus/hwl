Option Explicit On
Option Strict On
Imports ClausSoftware.Data


Imports DevExpress.Xpo
Namespace Kernel

    ''' <summary>
    ''' Enthält eine Auflistung aller Buchungskonten. 
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerDisplay("AccountID={AccountID}, '{AccountName}' ")> _
    <Persistent("Konten")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class CashAccount
        Inherits StaticItem
        Implements IDataItem

        Public Const TableName As String = "Konten"

        ''' <summary>
        ''' Enthält die Zugriffsnummer des Kontos
        ''' </summary>
        ''' <remarks></remarks>
        Private m_IDnumber As Integer
        Private m_accountNumber As String = String.Empty
        Private m_parentID As Integer
        Private m_acccountName As String = String.Empty
        Private m_taxID As Integer


        '`Kontonr` int(11) default NULL,
        '`KontoName` varchar(50) default NULL,*
        '`mwstsatz` int(11) default NULL,
        '`Changed` tinyint(4) default '0',
        '`Deleted` tinyint(4) default '0',
        '`Generation` int(11) default NULL,
        '`ReplikID` varchar(255) default NULL,
        '`ParentID` int(10) unsigned default NULL,
        '`ID` int(10) unsigned NOT NULL auto_increment,
        '`AccountNumber` varchar(10) default NULL,


        Private m_IsBaseAccount As Boolean
        ''' <summary>
        ''' Basiskonto dient als Überschrift / Kontogruppe im Kontorahmen und kann als "nicht Buchbar" markiert werden, dann können keinerlei Buchungen vorgenommen werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("IsBaseAccount")> _
        Public Property IsBaseAccount() As Boolean
            Get
                Return m_IsBaseAccount
            End Get
            Set(ByVal value As Boolean)
                m_IsBaseAccount = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Kontennamen ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        <Tools.DisplayName("AccountName", "Buchungskonto")> _
        <Persistent("KontoName")> _
        Public Property AccountName() As String
            Get

                Return m_acccountName

            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AccountName", m_acccountName, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Interne Kontonummer ab oder legt diese fest
        ''' Diese nummer wird nicht für die Anzeige verwendet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Stellt im Fall der Konten den Primärschlüssel dar</remarks>
        <Tools.DisplayName("AccountID", "Kontonummer")> _
        <Persistent("Kontonr")> _
        Public Property AccountID As Integer
            Get
                Return m_IDnumber
            End Get
            Set(ByVal value As Integer)

                SetPropertyValue(Of Integer)("AccountID", m_IDnumber, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Steuersatz dieses Kontos ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property TaxRate As TaxRate
            Get
                Return MainApplication.TaxRates.GetItem(Me.TaxID)
            End Get
            Set(ByVal value As TaxRate)
                If value IsNot Nothing Then
                    Me.TaxID = value.ID
                Else
                    Me.TaxID = -1
                End If
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Wert des steuersatzes ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("MwSt.Wert")> _
        ReadOnly Property TaxValue() As Decimal
            Get
                Dim tax As TaxRate = MainApplication.TaxRates.GetItem(Me.TaxID)
                If tax IsNot Nothing Then
                    Return tax.TaxValue
                Else
                    Return 0
                End If
            End Get
        End Property



        ''' <summary>
        ''' Ruft die Nummer des Mehrwertsteuersatzes ab oder legt deise für dies KOnto fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("mwstsatz")> _
        Public Property TaxID() As Integer
            Get
                Return m_taxID

            End Get
            Set(ByVal value As Integer)

                SetPropertyValue(Of Integer)("TaxID", m_taxID, value)
            End Set
        End Property

        ''' <summary>
        ''' List das Vater-Objekt oder weist es zu, es können nur Vater-Objekte zugewiesen werdeb, die auch selber
        ''' keine Kind-Objekte sind. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ParentAccount() As CashAccount
            Get
                If Me.ParentID <> 0 Then
                    Dim CashAccounts As New CashAccounts(m_mainApplication)

                    CashAccounts.CriteriaString = "ID=" & Me.ParentID
                    If CashAccounts.Count = 1 Then
                        Return CashAccounts(0)
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As CashAccount)
                If value.ParentID = 0 Then
                    Me.ParentID = value.ID
                End If
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Nummer des übergeordneten Kontos ab oder legt diese fest. 
        ''' 0 Bedeutet das element selber ist ein Überkonto
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ParentID")> _
        Public Property ParentID() As Integer
            Get
                Return m_parentID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ParentID", m_parentID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die LIste der Unteraccounts ab, nothing, wenn dies selber ein Unteraccount ist
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function SubAccounts() As CashAccounts

            If Me.ParentID = 0 Then
                Dim CashAccounts As New CashAccounts(m_mainApplication)
                CashAccounts.CriteriaString = "ParentID=" & Me.ID
                Return CashAccounts
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Enthält die sichtbare Kontonummer; diese ist frei eingebbar und sollte führende Nullen enthalten.
        ''' Im SKR- zB "0010"
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Kontonummer")> _
        <Persistent("AccountNumber")> _
        Public Property AccountNumber() As String
            Get
                If String.IsNullOrEmpty(m_accountNumber) Then

                    m_accountNumber = CStr(Me.AccountID)
                End If

                Return m_accountNumber

            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("AccountNumber", m_accountNumber, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Anzeigetext für Oberflächenelementen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property DisplayText() As String
            Get
                Return Me.AccountNumber & " " & Me.AccountName
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Displaynamen dieses Accounts ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Dim offset As Integer
            If Me.ParentID <> 0 Then
                offset = 5
            End If

            Return Space(offset) & DisplayText

        End Function


        Protected Overrides Sub OnSaving()
            MyBase.OnSaving()
            If Me.ID = -1 Then
                Dim result As Integer
                Try
                    Dim sql As String = "Select max(ID) from Konten"

                    Dim resultObj As Object

                    resultObj = m_mainApplication.Database.ExcecuteScalar(sql)

                    If Not TypeOf resultObj Is DBNull Then

                        result = CInt(resultObj)
                    Else
                        result = 0
                    End If
                Catch
                Finally
                    Me.ID = result + 1
                    m_mainApplication.SendMessage(m_mainApplication.Languages.GetText("msgCommonelementSaved", "Gespeichert: '{0}'", Me.ToString))

                End Try


            End If
        End Sub

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace