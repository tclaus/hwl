Option Explicit On
Option Strict On
Imports ClausSoftware.Data


Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Kernel

    ''' <summary>
    ''' Enthält einen Kassenbucheintrag
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("Kassenbuch")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class CashJournalItem
        Inherits StaticItem
        Implements IDataItem

        Public Const TableName As String = "Kassenbuch"

        ' Deklariere mal die Felder !1

        ' Gleich richtig deklarieren - kein String ;)
        Private m_datum As Date

        Private m_buchungstext As String = String.Empty

        Private m_buchungsnummer As String = String.Empty

        Private m_kostenstelle As String = String.Empty

        Private m_taxValue As Double

        Private m_einnahme As Double

        Private m_ausgabe As Double


        Private m_cashAccountID As Integer

        Private m_TaxValuePair As CashTaxPairs

        Const MyType As Integer = 1

        ''' <summary>
        ''' Ruft die Paare von Werten und zugewiesenen Steuersätzen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TaxValuePairs() As CashTaxPairs
            Get

                If m_TaxValuePair Is Nothing Then

                    Dim criteria As String
                    criteria = "Targettype=" & MyType & " AND ParentID=" & Me.ID

                    m_TaxValuePair = New CashTaxPairs(MainApplication, criteria)
                    'Falls noch kein eintrag existiert, dann den standard-Eintrag anlegen
                    If m_TaxValuePair.Count = 0 Then
                        Dim newTaxPairItem As TaxValuePair = m_TaxValuePair.GetNewItem
                        newTaxPairItem.ParentID = Me.ID
                        newTaxPairItem.Value = Math.Round(CDec(Me.Einnahme - Me.Ausgabe), 2, MidpointRounding.AwayFromZero)
                        'TODO: Ist das so richtig, Einnahmen - Ausgabe ? 
                        newTaxPairItem.TaxValue = CDec(Me.TaxValue)

                        ' newTaxPairItem.Save()
                        m_TaxValuePair.Add(newTaxPairItem)
                    End If
                End If

                Return m_TaxValuePair
            End Get

        End Property

        ''' <summary>
        ''' Ruft die Differenz ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalDiff As Double
            Get
                Return Me.Einnahme - Me.Ausgabe
            End Get
        End Property

        ''' <summary>
        ''' Ruft die eindeutige, fortlaufende Nummer ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Overloads ReadOnly Property ID() As Integer
            Get
                Return MyBase.ID
            End Get
        End Property

        '''' <summary>
        '''' Ruft einen Dokumenten-ID ab
        '''' </summary>
        '''' <value></value>
        '''' <returns></returns>
        '''' <remarks></remarks>
        '<PersistentAlias("ID")> _
        '<DisplayName("Nummer")> _
        'Public Shadows ReadOnly Property DocumentID() As Integer
        '    Get
        '        Return MyBase.ID
        '    End Get
        'End Property

        ''' <summary>
        ''' Ruft die ID des Kontos ab oder legt eine fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Konto")> _
        Public Property CashAccountID() As Integer
            Get
                Return m_cashAccountID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CashAccountID", m_cashAccountID, value)

            End Set
        End Property


        Private m_parentBalance As Decimal

        <System.ComponentModel.Browsable(False)> _
        Public Property ParentBalance() As Decimal
            Get
                If m_parentItem IsNot Nothing Then
                    Return m_parentItem.Balance
                Else
                    Return m_parentBalance
                End If

            End Get
            Set(ByVal value As Decimal)
                m_parentBalance = value
            End Set
        End Property


        Private m_parentItem As CashJournalItem
        ''' <summary>
        ''' Ruft einen Verweis auf das logisch vor diesem eintrag liegende element ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParentItem() As CashJournalItem
            Get
                Return m_parentItem
            End Get
            Set(ByVal value As CashJournalItem)
                m_parentItem = value
            End Set
        End Property


        ''' <summary>
        ''' Ruft den aktuellen Bestand ab. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Muss von aussen gesetzt werden</remarks>
        <Tools.DisplayName("Balance", "Saldo")> _
        Public ReadOnly Property Balance As Decimal
            Get
                Return CDec(Me.ParentBalance + (Me.Einnahme - Me.Ausgabe))
            End Get
        End Property


        Public Overrides Sub Save()
            MyBase.Save()
            SetTaxLinikIDs()
            Me.TaxValuePairs.Save()
            m_mainApplication.SendMessage(m_mainApplication.Languages.GetText("msgCommonelementSaved", "Gespeichert: '{0}'", Me.ToString))

        End Sub

        ''' <summary>
        ''' wurden Steuersätze hinzugefügt, dann müssen die VerweisIDs angepasst werden
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetTaxLinikIDs()
            For Each taxItem As TaxValuePair In Me.TaxValuePairs
                taxItem.ParentID = Me.ID
            Next
        End Sub

        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        Public ReadOnly Property DateByMonthName As String
            Get
                Return Me.TransactionDate.ToString("MMMM")
            End Get
        End Property

        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        Public ReadOnly Property DateByMonthNumber As String
            Get
                Return Me.TransactionDate.Year & "_" & Me.TransactionDate.Month.ToString("(00)")
            End Get
        End Property

        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        Public ReadOnly Property DateByYear As String
            Get
                Return Me.TransactionDate.ToString("yyyy")
            End Get
        End Property


        <Tools.DisplayName("TransactionDate", "Datum")> _
        <Persistent("Datum")> _
        Public Property TransactionDate() As Date

            Get
                '  Debug.Print("TransDate:" & m_datum)
                Return m_datum

            End Get
            Set(ByVal value As Date)

                SetPropertyValue(Of Date)("TransactionDate", m_datum, value)
            End Set
        End Property

        <Tools.DisplayName("TransactionText", "Aussteller")> _
        <Persistent("Buchungstext")> _
        Public Property TransactionText() As String
            Get
                If m_buchungstext Is Nothing Then m_buchungstext = String.Empty
                Return m_buchungstext
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("TransactionText", m_buchungstext, value)
            End Set
        End Property

        <Tools.DisplayName("TransactionNumber", "Buchungstext / Nummer")> _
        <Persistent("Buchungstext2")> _
        Public Property Buchungsnummer() As String
            Get
                If m_buchungsnummer Is Nothing Then m_buchungsnummer = String.Empty
                Return m_buchungsnummer
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Buchungsnummer", m_buchungsnummer, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft das Buchungskonto ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("CashAccount", "Buchungskonto")> _
        Public Property CashAccount() As CashAccount
            Get
                Return MainApplication.CashAccounts.GetAccountByID(Me.CashAccountID)
            End Get
            Set(ByVal value As CashAccount)
                If value IsNot Nothing Then
                    Me.CashAccountID = value.AccountID
                Else
                    Me.CashAccountID = Nothing
                End If
            End Set
        End Property

        ''' <summary>
        ''' Ruft den tatsächlichen Steuersatz ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("taxValue", "Steuersatz")> _
        <Persistent("MWST")> _
        Public Property TaxValue() As Double
            Get
                Return m_taxValue

            End Get
            Set(ByVal value As Double)

                SetPropertyValue(Of Double)("TaxValue", m_taxValue, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den anteiligen Steuerbetrag dieser Buchung ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("TaxValueAmmount", "Betrag Steueranteil")> _
        Public ReadOnly Property TaxValueAmmount As Decimal
            Get
                ' Totalen Geldbetrag abholen
                Dim cashValue As Double = Me.Einnahme - Me.Ausgabe

                Dim ammount As Decimal
                ammount = CDec((cashValue / (100 + Me.TaxValue)) * (Me.TaxValue))
                Return ammount
            End Get
        End Property

        <Tools.DisplayName("Receipts", "Einnahme")> _
        <Persistent("Einnahme")> _
        Public Property Einnahme() As Double
            Get
                Return m_einnahme
            End Get
            Set(ByVal value As Double)

                SetPropertyValue(Of Double)("Einnahme", m_einnahme, value)
            End Set
        End Property

        <Tools.DisplayName("Outgoings", "Ausgaben")> _
        <Persistent("Ausgabe")> _
        Public Property Ausgabe() As Double
            Get
                Return m_ausgabe
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("Ausgabe", m_ausgabe, value)

            End Set
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        Public Overrides Function ToString() As String
            Return Me.ID & " " & Me.TransactionDate & " " & Me.TransactionText
        End Function

    End Class

    ''' <summary>
    ''' Enthält eine Auflistung von Steuer-Betrag Paaren die für die Foredrungen/Verbindlichkeiten vorgesehen sind
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CashTaxPairs
        Inherits TaxValuePairs

        Public Sub New(ByVal baseApp As mainApplication)
            MyBase.New(baseApp)
        End Sub

        Public Sub New(ByVal baseapplication As mainApplication, ByVal criteriastr As String)
            MyBase.New(baseapplication, criteriastr)
        End Sub

        ''' <summary>
        ''' Ruft ein neues Steuerpaar für Kassenbuch ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As TaxValuePair
            Dim newItem As TaxValuePair = MyBase.GetNewItem()
            newItem.Targettype = TargetTaxValuePair.CashJournal
            Return newItem
        End Function

        Public Overrides Sub Add(ByVal newObject As TaxValuePair)
            newObject.Targettype = TargetTaxValuePair.CashJournal
            MyBase.Add(newObject)
        End Sub


    End Class

End Namespace