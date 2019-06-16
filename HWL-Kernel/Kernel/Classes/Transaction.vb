Option Explicit On
Option Strict On
Imports ClausSoftware.Data


Imports DevExpress.Xpo
Namespace Kernel

    ' tableename transactions / vorgänge

    ''' <summary>
    ''' Stellt einen Forderungen / Verbindlichkeiten-Eintrag da (Transaction) 
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(Transaction.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Transaction
        Inherits StaticItem
        Implements IDataItem

        Public Const TableName As String = "Vorgänge"

        Private Shared m_canceldDocumentsHelper As CanceledDocuments

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_text As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_date As Date
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_paid As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_paidDate As Date
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_targetDate As Date
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_cashAccount As Integer

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_isInbound As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_unpaidAmmount As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_paidAmmmount As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_splitt As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_hasSplitt As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_totalAmmount As Decimal

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_taxValue As Double

        ''' <summary>
        ''' Enthält die Verweis-ID zu einem eindeutigem Journaleintrag
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_internalDocumentID As Integer



        ''' <summary>
        ''' Legt fest, ob es eine interne Rechnungsnummer ist, oder eine HWL-Rechnungsnummer, bei internen rechnungen darf die Rechnungsnummer nicht geändert werden
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_IsInternal As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_documentDisplayNumber As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_target As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_adressID As Integer

        ''' <summary>
        ''' Kennung für die Wertepaare TaxValuePair (Tabelle Kassenbuchsteuern)
        ''' </summary>
        ''' <remarks></remarks>
        Const MyType As Integer = 2

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_TaxValuePair As TransactionTaxPairs

        Private m_DontCheckPayments As Boolean

        ''' <summary>
        '''  Ruft ein Hilfsobjekt ab, das aus dem Journal das 'Storniert' - Status ermittelt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property CanceldStateHelper As CanceledDocuments
            Get
                If m_canceldDocumentsHelper Is Nothing Then
                    m_canceldDocumentsHelper = New CanceledDocuments()
                    m_canceldDocumentsHelper.RefreshState()
                End If
                Return m_canceldDocumentsHelper
            End Get
        End Property

        ''' <summary>
        ''' Ist wahr, wenn das Jorunal als 'Storniert' gekennzeichnet ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("IsCanceled", "Storno")> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        Public ReadOnly Property IsCanceled As Boolean
            Get
                Return Me.CanceldStateHelper.GetCanceldState(Me.InternalDocumentID)

            End Get
        End Property

        ''' <summary>
        ''' Wenn dieses Dokument von einer intrenen Rechnung abgeleitet ist, kann es Storniert, aber nicht gelöscht werden
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetCanceled()
            Dim internalJournalDoc As JournalDocument
            internalJournalDoc = MainApplication.JournalDocuments.GetItem(Me.InternalDocumentID)
            If internalJournalDoc IsNot Nothing Then
                internalJournalDoc.SetCanceled()
                internalJournalDoc.Save()
            Else
                MainApplication.Log.WriteLog(Tools.LogSeverity.Warning, "Das Basisdokument der Transaktion mit der ID (" & Me.InternalDocumentID & ") kann nicht gefunden werden. stornieren nicht möglich.")
            End If
        End Sub

        ''' <summary>
        ''' Sefern dieses dokument als "Storniert" (Canceld) markiert ist, wird es wieder hergestellt
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearCanceled()
            Dim internalJournalDoc As JournalDocument
            internalJournalDoc = MainApplication.JournalDocuments.GetItem(Me.InternalDocumentID)
            If internalJournalDoc IsNot Nothing Then
                internalJournalDoc.ClearCanceled()
                internalJournalDoc.Save()
            Else
                MainApplication.Log.WriteLog(Tools.LogSeverity.Warning, "Das Basisdokument der Transaktion mit der ID (" & Me.InternalDocumentID & ") kann nicht gefunden werden. Aufheben der Stornieren nicht möglich.")
            End If
        End Sub


        ''' <summary>
        ''' Wenn True, dann nicht mehr auf Bezahlt-Status prüfen.
        ''' Es werden dann auch keine Benachrichtungen angezeigt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("DontCheckPayments")> _
        Public Property DontCheckPayments() As Boolean
            Get
                Return m_DontCheckPayments
            End Get
            Set(ByVal value As Boolean)

                SetPropertyValue(Of Boolean)("DontCheckPayments", m_DontCheckPayments, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft eine eindeutige fortlaufende Nummer ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("transactionID", "ID")> _
        Overrides Property ID() As Integer
            Get
                Return MyBase.ID
            End Get
            Set(ByVal value As Integer)
                MyBase.ID = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID der Adresse ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("Adresse")> _
        Private Property AdressID() As Integer
            Get
                Return m_adressID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("AdressID", m_adressID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Anzeigetext der Adresse ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("AddressDisplayText", "Adresse")> _
        Public ReadOnly Property AddressDisplayText() As String
            Get
                Dim thisAddress As Adress = Me.Adress
                If thisAddress IsNot Nothing Then
                    Return thisAddress.ToString
                Else
                    Return ""
                End If
            End Get
        End Property

        Dim m_foundAdress As Adress

        ''' <summary>
        ''' Ruft die Adresse ab, die der Datensatz zugewiesen wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Adresse")> _
        Public Property Adress() As Adress
            Get

                If m_foundAdress Is Nothing Then

                    m_foundAdress = MainApplication.Adressen.GetItem(AdressID)
                End If


                Return m_foundAdress

            End Get
            Set(ByVal value As Adress)
                If value IsNot Nothing Then
                    AdressID = value.ID
                    m_foundAdress = Nothing
                End If
            End Set
        End Property

        ''' <summary>
        ''' 0 Steht für Buchung an Bank, 1 für Buchung an Kassenbuch.
        ''' einträge sind auseinanderzuhalten
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Buchungsziel")> _
        Public Property Target() As Integer
            Get 'TODO: dies als Enum festlegen
                Return m_target
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Target", m_target, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Rechnungsnummer des Vorganges ab oder legt diese fest.
        ''' Bei internen Dokumenten kann das nicht geändert werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("ItemDisplayNummer", "Rechnungsnummer")> _
        <Persistent("RNummer")> _
        Public Property ItemDisplayNumber() As String
            Get

                Return m_documentDisplayNumber

            End Get
            Set(ByVal value As String)

                If Not String.IsNullOrEmpty(value) Then
                    If value.Length > 250 Then value = value.Substring(0, 250)
                End If

                SetPropertyValue(Of String)("ItemDisplayNumber", m_documentDisplayNumber, value)

            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, das es sich um eine selbstgeschriebene Rechnung mit Verweis auf 
        ''' ein vorhandenes Dokument handelt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("InternalTransaction", "Eigene Rechnung")> _
        <Persistent("HWLIntern")> _
        Public Property IsIntern() As Boolean
            Get
                Return m_IsInternal
            End Get
            Set(ByVal value As Boolean)
                m_IsInternal = value
            End Set
        End Property


        ''' <summary>
        ''' Ruft die interne Rechnungsnummer ab oder legt diese fest. 
        ''' Kennzeichnet eigengeschriebene Rechnungen. 
        ''' </summary>
        ''' <value>Es wird die eindeutige ID des Journaleintrages übergeben oder zurückgegeben</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("HWLRnummer")> _
        Public Property InternalDocumentID() As Integer
            Get
                Return m_internalDocumentID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("InternalDocumentID", m_internalDocumentID, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den MWST-Wert ab, der für diese Buchung verwendet wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("TaxValue", "Steuersatz")> _
        <Persistent("MWST")> _
        Public Property TaxValue() As Double
            Get

                Return m_taxValue
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("TaxValue", m_taxValue, value)
            End Set
        End Property

        Private m_taxValueID As Integer = -1
        ''' <summary>
        ''' Ruft die ID des verwendeten Steuersatzes ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("TaxValueID")> _
        Public Property TaxValueID() As Integer
            Get
                Return m_taxValueID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TaxValueID", m_taxValueID, value)
                If Not Me.IsLoading Then
                    If Me.TaxItem IsNot Nothing Then
                        TaxValue = Me.TaxItem.TaxValue
                    End If
                End If

            End Set
        End Property

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_TaxItem As TaxRate

        ''' <summary>
        ''' Ruft den verwendeten Steuersatz ab oder legt diesen fest. 
        ''' Gibt es eine Teilzahlung mit unterschiedlichen Steuersätzen, ist dieser wert ohne Bedeutung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TaxItem() As TaxRate
            Get
                Return m_mainApplication.TaxRates.GetItem(Me.TaxValueID)
            End Get
            Set(ByVal value As TaxRate)
                If value IsNot Nothing Then
                    Me.TaxValueID = value.ID
                    TaxValue = value.TaxValue
                Else
                    Me.TaxValueID = -1
                End If

            End Set
        End Property

        ''' <summary>
        ''' Liefert True, wenn dieser Datensatz unterschiedliche Steuersätze hat
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Ist Fucking scheisse! Ein überbleibsel von JK; Diese Sätze können nicht ohne weiteres berechnet / gedruckt werden!</remarks>
        Public Function HasPartialTaxValues() As Boolean
            If Me.TaxValueID = -1 Then
                ' Ist dann ein Kandidat - gibt es nun tatsächlch splittet TaxValues ? 
                Dim dummy As Object = Me.TaxValuePairs

                If dummy Is Nothing Then
                    Return False
                Else
                    Return True
                End If

                Return True

            End If
            Return False
        End Function

        ''' <summary>
        ''' Ruft die Auflistung von Steuersätzen und Beträgen ab.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TaxValuePairs() As TransactionTaxPairs
            Get

                If m_TaxValuePair Is Nothing Then

                    If Me.ID = -1 Then Return Nothing

                    Dim criteria As String
                    criteria = "Targettype=" & MyType & " AND ParentID=" & Me.ID

                    m_TaxValuePair = New TransactionTaxPairs(MainApplication, criteria)

                    'Falls noch kein eintrag existiert, dann den standard-Eintrag anlegen
                    If m_TaxValuePair.Count = 0 Then
                        Dim newItem As TaxValuePair = m_TaxValuePair.GetNewItem

                        newItem.ParentID = Me.ID ' Bei neuanlage ist hiet "-!"
                        newItem.Value = Math.Round(Me.TotalAmmount, 2)

                        newItem.TaxValue = CDec(Me.TaxValue)
                        m_TaxValuePair.Add(newItem)
                        newItem.Save()

                    End If

                End If
                ' Nun prüfen, ob der Gesamtbetrag mit den Steuern vereinbar ist, falls nicht => Reparieren
                If m_TaxValuePair.Count = 1 Then
                    m_TaxValuePair(0).Value = Me.TotalAmmount
                    m_TaxValuePair(0).Tax = Me.TaxItem
                    m_TaxValuePair(0).Save()
                End If


                Return m_TaxValuePair
            End Get

        End Property


        ''' <summary>
        ''' Zeigt an, ob eine Teilzahlung existiert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("HasSplitt")> _
        Public Property HasPartialPayment() As Boolean
            Get
                Return m_hasSplitt
            End Get
            Set(ByVal value As Boolean)
                m_hasSplitt = value
            End Set
        End Property

        Private m_downPayments As DownPayments

        ''' <summary>
        ''' Ruft die Liste der Teilzahlungen (früher Splittbuchungen) dieser Transaktion ab
        ''' Diese Auflistung wird immer aus der Datenbank neu eingelesen.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDownPayments() As DownPayments
            If m_downPayments Is Nothing Then
                m_downPayments = DownPayments.GetDownPaymentsForItem(Me)
                m_downPayments.DeleteObjectOnRemove = True
            End If
            Return m_downPayments
        End Function

        ''' <summary>
        ''' Enthält die Auflistung der aktuellen Mahnungen, soferm welche für diese Rechnung geschrieben wurden
        ''' </summary>
        ''' <remarks></remarks>
        Private m_reminders As Reminders

        ''' <summary>
        ''' Ruft die Auflistugn der Mahnungen für diese Transaktion ab. 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReminders() As Reminders
            If m_reminders Is Nothing Then
                Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("ClaimDocumentID='" & Me.Key & "'")
                m_reminders = New Reminders(MainApplication, criteria)
            End If

            Return m_reminders

        End Function

        ''' <summary>
        ''' Speichert nur die Transaktions-Daten ab 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveInternal()
            MyBase.Save()
        End Sub
        ''' <summary>
        ''' Speichert die Buchung und alle angehängten Teilzahlungen ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()


            GetDownPayments.RefreshParentTransaction()
            GetDownPayments.Save()

            If Not Me.IsPaid Then
                Me.PaidDate = Nothing
            End If

            MyBase.Save()

            Me.TaxValuePairs.Save()


            m_mainApplication.SendMessage(m_mainApplication.Languages.GetText("msgCommonelementSaved", "Gespeichert: '{0}'", Me.ToString))

        End Sub

        ''' <summary>
        ''' Erstellt eine kopie dieser Transaktion 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function Clone() As Object
            Dim newt As Transaction = CType(MyBase.Clone(), Transaction)
            ' Klone sind nicht an eine Rechnung gebunden !
            newt.IsIntern = False

            Return newt

        End Function

        ''' <summary>
        ''' Löscht diese Buchung und alle damit zusammenhängenden Teilzahlungen, sofern das Dokument nicht intern ist.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Delete()
            If Me.IsIntern Then
                Throw New CanNotDeleteInternalTransactionException(Me)

            End If

            DeleteInternal()
        End Sub

        ''' <summary>
        ''' Löscht den aktuellen Datrensatz, ohne eine Intern - Prüfung vorzunehmen
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub DeleteInternal()
            MyBase.Delete()

            Dim result As Integer = MainApplication.Database.ExcecuteNonQuery("delete from Splittbuchungen WHERE SPLITT = " & Me.ID)

            Debug.Print(result & " Teilzahlungen dieser Buchung gelöscht")


            result = MainApplication.Database.ExcecuteNonQuery("delete from KassenbuchSteuern WHERE VerweisID = " & Me.ID & " AND Targettype=" & TargetTaxValuePair.Transactions)

            Debug.Print(result & " Steueranteile dieser Buchung gelöscht")
        End Sub

        ''' <summary>
        ''' Gesamt-Rechnungsbetrag, in Brutto
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("TotalAmmount", "Betrag")> _
        <Persistent("TotalAmmount")> _
        Public Property TotalAmmount() As Decimal
            Get
                Return m_totalAmmount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TotalAmmount", m_totalAmmount, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den bezahlten Betrag ab oder legt diesen fest, 
        ''' Falls eine Teilzahlung vorgenommen wurde, dann kann dieser Wert nicht mehr geändert werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Bezahlt und unbezahlt zusammen ergeben die Recnungssumme?</remarks>
        <Tools.DisplayName("PaidAmmount", "Bezahlt")> _
        <Persistent("BetragBezahlt")> _
        Public Property PaidAmmount() As Decimal
            Get
                Return m_paidAmmmount
            End Get
            Set(ByVal value As Decimal)
                m_paidAmmmount = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den noch offenen Betrag ab oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("UnpaidAmmount", "Unbezahlt")> _
        <Persistent("BetragNichtBezahlt")> _
        Public Property UnpaidAmmount() As Decimal
            Get
                Return m_unpaidAmmount
            End Get
            Set(ByVal value As Decimal)
                m_unpaidAmmount = value
            End Set
        End Property


        '<PersistentAlias("IsInboundIntern")> _
        '<DisplayName("Ist Ausgabe")> _
        '        Public Property IsInbound() As Boolean
        '    Get
        '        Return (IsInboundIntern = 1)
        '    End Get
        '    Set(ByVal value As Boolean)
        '        If value Then
        '            IsInboundIntern = 1
        '        Else
        '            IsInboundIntern = -1
        '        End If
        '    End Set
        'End Property


        ''' <summary>
        ''' Zeigt an, das es sich um eine eingehende Rechnung (Verbindlichkeit, Ausgabe) handelt,
        ''' wenn wahr
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Ist Verbindlichkeit")> _
        <Persistent("IstRechnung")> _
        Private Property IsPayable() As Boolean
            Get
                Return m_isInbound
            End Get
            Set(ByVal value As Boolean)

                SetPropertyValue(Of Boolean)("IsPayable", m_isInbound, value)
            End Set
        End Property

        ''' <summary>
        ''' Kennzeichnet die Richtung des Geldflusses
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Geldfluss")> _
        Public Property MoneyFlow() As MoneyFlow
            Get
                If Me.IsPayable Then
                    Return Kernel.MoneyFlow.IsPayable
                Else
                    Return Kernel.MoneyFlow.IsReceiveable
                End If
            End Get
            Set(ByVal value As MoneyFlow)
                If value = Kernel.MoneyFlow.IsPayable Then
                    IsPayable = True
                Else
                    IsPayable = False
                End If
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
        ''' Ruft die ID des Kontos ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Konto")> _
        Private Property CashAccountID() As Integer
            Get
                Return m_cashAccount
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CashAccountID", m_cashAccount, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft das Zahlungsziel ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("TargetPayDate", "Ziel Datum")> _
        <Persistent("SollDatum")> _
        Public Property TargetPayDate() As Date
            Get
                Return m_targetDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("TargetPayDate", m_targetDate, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft das Bezhaltdatum ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("PaidDate", "Bezahltdatum")> _
        <Persistent("BezDatum")> _
        Public Property PaidDate() As Date
            Get
                Return m_paidDate
            End Get
            Set(ByVal value As Date)
                m_paidDate = value
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, das eine Forderung überfällig ist, also das Zieldatum überschritten hat
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("IsOverdue", "Ist überfällig")> _
        Public ReadOnly Property IsOverdue() As Boolean
            Get
                If Me.TotalAmmount = 0 Then Return False ' 0-Beträge können nicht 'überfällig' sein

                If Not Me.IsPaidInternal And Date.Compare(Me.TargetPayDate, Today) < 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property


        ''' <summary>
        ''' Ruft den Bezahl-Status ab oder legt es fest. Dieser wert berechnet sich stets aus (Bezahlt - Total) = 0
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
<Persistent("Bezahlt")> _
        Friend Property IsPaidInternal() As Boolean
            Get
                Return m_paid
            End Get
            Set(ByVal value As Boolean)

                If m_paid = value Then Exit Property
                'IMPORTANT: IsPaid, nur aus DB lesen, keine Daten ändern !
                ' Stattdessen "SetIsPaid benutzen;   Diese sollte eine Zahlung in Höhe des restbetrages duchführen 

                SetPropertyValue(Of Boolean)("IsPaidInternal", m_paid, value)


            End Set
        End Property

        <Tools.DisplayName("IsPaid", "Ist Bezahlt")> _
          Public ReadOnly Property IsPaid() As Boolean
            Get
                Return IsPaidInternal
            End Get
        End Property

        ''' <summary>
        ''' Setzt den Aktuellen Vorfall als "Bezahlt", indem ein Zahlungseingang iHv dem Restbetrag eingetragen wird, sofern etwas fehlt
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetIsPayed()

            Dim currentDownPayments As DownPayments = Me.GetDownPayments ' Aktuelle Buchungen holen


            If Math.Abs(TotalAmmount - currentDownPayments.TotalPaidAmmount) > 0.001 Then  ' Diese Konstruktion ist nötig, da die Double-werte durchaus nachkommastellen haben können
                Dim payment As DownPayment = currentDownPayments.GetNewItem
                payment.PaidDate = Today
                payment.ParentTransaction = Me

                payment.Description = "Eingang" 'TODO: NLS
                'TODO: Text aus Properties abholen ? 

                payment.Ammount = Me.TotalAmmount - currentDownPayments.TotalPaidAmmount
                payment.Save()
                Me.PaidAmmount = Me.TotalAmmount
                Me.UnpaidAmmount = 0
                Me.IsPaidInternal = True

                currentDownPayments.Add(payment)

            Else ' Dann haben die Teilzahlungen bereits den gesamtbetrag erreicht
                Me.PaidAmmount = Me.TotalAmmount ' Oder aus den Splitts abholen ? 
                Me.UnpaidAmmount = 0
                Me.IsPaidInternal = True
            End If


        End Sub
        ''' <summary>
        ''' Ruft das Erstelldatum der Aktion ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("Date", "Datum")> _
        <Persistent("Datum")> _
        Public Property ItemDate() As Date
            Get
                Return m_date
            End Get
            Set(ByVal value As Date)
                m_date = value
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Text der Buchung ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(255)> _
        <Tools.DisplayName("text", "Text")> _
        <Persistent("Text")> _
        Public Property Text() As String
            Get

                Return m_text

            End Get
            Set(ByVal value As String)
                If String.IsNullOrEmpty(value) Then
                    value = String.Empty
                End If

                If value.Length > m_mainApplication.Database.GetColumnCharacterLength(Transaction.TableName, "Text") Then
                    value = value.Substring(0, CInt(m_mainApplication.Database.GetColumnCharacterLength(Transaction.TableName, "Text")))
                End If

                m_text = value

            End Set
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        ''' <summary>
        ''' Ruft den Anzeigetext des Vorgangs ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            If Me.Text.Length > 0 Then
                Return Me.ItemDisplayNumber & " " & Me.ItemDate & " """ & Me.Text & """ " & Me.AddressDisplayText

            Else
                Return Me.ItemDisplayNumber & " " & Me.ItemDate & " " & Me.AddressDisplayText

            End If
        End Function


    End Class

    ''' <summary>
    ''' Enthält eine Auflistung von Steuer-Betrag Paaren die für die Foredrungen/Verbindlichkeiten vorgesehen sind
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TransactionTaxPairs
        Inherits TaxValuePairs

        Public Sub New(ByVal baseApp As MainApplication)
            MyBase.New(baseApp)
        End Sub

        Public Sub New(ByVal baseapplication As MainApplication, ByVal criteriastr As String)
            MyBase.New(baseapplication, criteriastr)
        End Sub

        Public Overrides Sub Add(ByVal newObject As TaxValuePair)
            newObject.Targettype = TargetTaxValuePair.Transactions
            MyBase.Add(newObject)
        End Sub

        ''' <summary>
        ''' Ruft ein neues Steuer / werte Paar ab für Forderungen/Verbindlichkeiten
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As TaxValuePair
            Dim newItem As TaxValuePair = MyBase.GetNewItem()

            newItem.Targettype = TargetTaxValuePair.Transactions
            Return newItem
        End Function



    End Class


    ''' <summary>
    ''' Interne Transaktionen können nicht gelöscht werden, da diese durch erstellte Rechnungen (oder Gutschriften) definiert werden
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CanNotDeleteInternalTransactionException
        Inherits Exception


        Private m_transactionelement As Transaction
        ''' <summary>
        ''' Enthält die Transaktion, die nicht gelöscht werden konnte da diese als 'intern' markiert ist und durch eine Rechnubng definiert wird
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Transaction() As Transaction
            Get
                Return m_transactionelement
            End Get
            Set(ByVal value As Transaction)
                m_transactionelement = value
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="internalTransaction"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal internalTransaction As Transaction)
            m_transactionelement = internalTransaction
        End Sub
    End Class


End Namespace