Option Explicit On
Option Strict On
Imports ClausSoftware.Data
Imports DevExpress.Data
Imports DevExpress.Data.Filtering

Namespace Kernel

    ''' <summary>
    ''' Stellt ein Journaldokument dar. Enthält ein Angebot, Rechnung, Bestellung, Gutschrift oder Mahnung
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    <Persistent(JournalDocument.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class JournalDocument
        Inherits StaticItem
        Implements IDataItem
        Implements IAttachments

        Public Const Tablename As String = "JournalListe"

        Private Shared m_canceldDocumentsHelper As CanceledDocuments

        ''' <summary>
        ''' Enthält den Stornierungs-Status
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_isCanceld As Boolean


        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_headText As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_adressID As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_contactID As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_createdAt As Date = Now
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_changedAt As Date
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_documentType As enumJournalDocumentType
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_documentID As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_DokumentenDatum As Date
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_memo As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_TargetPayDate As DateTime
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_DiscountActive As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_discountValue As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_Titeltext As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_cashAccountID As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_footerText As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_forPrinting As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_Adressfenster As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_userChangedAddressWindow As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_ParentDocID As String

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_canceldAt As DateTime

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_canceledBy As String

        ''' <summary>
        ''' Geasmtzeitdauer dieses Auftrages / Rechnung
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_Totalduration As TimeSpan

        ''' <summary>
        ''' Enthält den absoluten Brutto Endpreis, inkusive aller Steuern, sowie Auf-und Abschläge
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_bruttoFixedEndPrice As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_TypeOfDocText As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_RabattIstAbsolut As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_RabattAbsolutBertrag As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_erledigt As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_GlobalerArtikelRabatt As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_taxValueID As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_taxValue As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_rabatttext As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_showWithTax As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_createdBy As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_totalPriceBeforeTax As Decimal

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_Steuersatz As TaxRate
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_displayDocumentID As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_deliveryAdress As String = String.Empty

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Dim m_myPriceListContainer As New List(Of JournalTaxValuePair)


        ''' <summary>
        ''' Stellt eine Auflistung aller Ursprünglich vorhandenen Gruppen dar
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Dim m_orgItemGroups As New List(Of JournalArticleGroup)

        ''' <summary>
        ''' Enthält eine Auflistung aller aktuellen Artikelgruppen
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Dim m_itemGroups As JournalArticleGroups

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_useDeliveryAdress As Boolean

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_itemSource As String = String.Empty

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_copyIntern As Boolean = True
        ''' <summary>
        ''' Enthält eine Auflistung aller Journalartikel aus allen Gruppen
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_journalItemsList As New Dictionary(Of String, AcummulatedJournalItem)
        Private m_journalItemListList As New List(Of AcummulatedJournalItem)
        ''' <summary>
        ''' Enthält den Wert den dieses Dokument als 'markiert' darstellt 
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_tagged As Boolean
        Dim itemsListNeedRebuild As Boolean

        ''' <summary>
        ''' Markiert eine aktuelle Lösch-Operation
        ''' </summary>
        ''' <remarks></remarks>
        Private m_isDeleting As Boolean

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_hasInvoiceReference As Boolean?

        ''' <summary>
        ''' Zeigt an, ob das Dokument bereits in einer Sammelrechnung aufgenommen wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("InvoiceReference", "Sammelrechnung erstellt")> _
        Public ReadOnly Property HasInvoiceReference() As Boolean?
            Get
                If Not m_hasInvoiceReference.HasValue Then
                    ' Aus einer Sammelrchnungsliste prüfen

                    If m_referenceInvoicesList Is Nothing Then
                        m_referenceInvoicesList = New ReferenceInvoices

                        MainApplication.log.WriteLog("Erstelle neue Liste der Sammelrechnungen für Referenzen")

                        Dim sql As String

                        sql = "SELECT I.OrgItem, J.ID, J.ReplikID FROM items I,Positions P,JournalListe J where P.ReplikID = I.ParentItemID " & _
                                " AND P.ParentItemID = J.ReplikID "
                        Dim dt As DataTable = MainApplication.Database.GetData(sql)

                        For Each row As System.Data.DataRow In dt.Rows
                            Dim newOrgItem As String = row(0).ToString
                            If newOrgItem.EndsWith("I") Then
                                If Not m_referenceInvoicesList.ReferenceInvoicelist.ContainsKey(newOrgItem) Then
                                    Dim newReferenceInvoice As New ReferenceInvoice

                                    Dim newrefID As Integer = CInt(row(1))

                                    newReferenceInvoice.ReferenceDocumentID = newrefID
                                    m_referenceInvoicesList.ReferenceInvoicelist.Add(newOrgItem, newReferenceInvoice)
                                End If
                            End If

                        Next

                        ' Damit ist die Liste eingelesen

                    End If

                    If m_ReferenceInvoice Is Nothing Then

                        ' Prüfen, ob dieser Eintrag enthalten war..
                        If m_referenceInvoicesList.ReferenceInvoicelist.ContainsKey(Me.ID & "I") Then
                            m_ReferenceInvoice = m_referenceInvoicesList.ReferenceInvoicelist(Me.ID & "I")
                            m_hasInvoiceReference = True
                        Else
                            m_hasInvoiceReference = False

                        End If


                    End If

                    '                    m_ReferenceInvoice = New HasReferenceInvoice

                    '                    Dim sql As String '= "SELECT ID,ParentItemID FROM " & JournalArticleItem.TableName & " WHERE OrgItem='" & Me.ID & "I'"  ' DokumentenNummer + "I" zB "123I"

                    '                    ' Wenn als Sammelrechnung aufgenommen, dann ist die ORGITEM  des JournalArtikels gleich der Dokumentennummer
                    '                    sql = "SELECT J.ID, J.ReplikID FROM items I,Positions P,JournalListe J where I.OrgItem ='" & Me.ID & "I' " & _
                    '" and P.ReplikID = I.ParentItemID " & _
                    '" AND P.ParentItemID = J.ReplikID "


                    '                    Dim dt As DataTable = MainApplication.Database.GetData(sql)
                    '                    If dt.Rows.Count = 0 Then
                    '                        m_hasInvoiceReference = False
                    '                    Else
                    '                        m_hasInvoiceReference = True

                    '                        ' Die ID des Zieldokumentes schon mal abholen
                    '                        m_ReferenceInvoice.ReferenceDocumentID = CInt(dt.Rows(0)("ID"))

                    '                    End If
                End If

                Return m_hasInvoiceReference
            End Get

        End Property


        Private m_ReferenceInvoice As ReferenceInvoice

        ''' <summary>
        ''' Stellt eine gemeinsame Auflistung von Sammelrechnungsreferenzen bereit
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared m_referenceInvoicesList As ReferenceInvoices


        ''' <summary>
        ''' Ruft das verlinkte Journaldokument ab, sofern eins existiert. Gibt sonst 'nothing' zurück
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReferenceInvoice() As JournalDocument
            If m_ReferenceInvoice Is Nothing Then

                If HasInvoiceReference Then

                    ' Dann nur einmal das verlinkte Dokument abholen
                    If m_ReferenceInvoice.ReferenceDocumentID.HasValue Then
                        m_ReferenceInvoice.ReferenceDocument = MainApplication.JournalDocuments.GetItem(m_ReferenceInvoice.ReferenceDocumentID.Value)
                    End If

                    Return m_ReferenceInvoice.ReferenceDocument

                End If
            Else
                Return m_ReferenceInvoice.ReferenceDocument

            End If

            ' Dann gab es nichts
            Return Nothing
        End Function

        ''' <summary>
        ''' Löscht dieses Dokument und alle darin verknüpften Daten endgültig. 
        ''' Aus Sicht der UI sollte stattdessen ein "Storno" (Methode SetCanceled) benutzen.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Delete()
            m_isDeleting = True
            MyBase.Delete()

            Me.ArticleGroups.Delete()
            DeleteTransactionDocument()
            Me.AttachmentLinks.Delete()

            m_isDeleting = False

        End Sub

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_printAsDeliveryNote As Boolean

        ''' <summary>
        ''' "Als Lieferschein drucken lassen; Ändert nur die Anzeige im Ausdruck; nicht den eigentlichen Inhalt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        Public Property PrintAsDeliveryNote As Boolean
            Get
                Return m_printAsDeliveryNote
            End Get
            Set(value As Boolean)
                m_printAsDeliveryNote = value
            End Set
        End Property

        ''' <summary>
        ''' Löscht eine eventuell erstellte Transaktion, wenn das Ausgangsdokument entfernt wurde. 
        '''  Vermeidet Datenleichen. die Oberfläche sollte sich um Konsistenz bemühen um nicht beliebige Datensätze zu entfernen
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub DeleteTransactionDocument()
            If Not (Me.DocumentType = enumJournalDocumentType.Rechnung Or Me.DocumentType = enumJournalDocumentType.Gutschrift) Then Exit Sub

            Dim criteria As CriteriaOperator = CriteriaOperator.Parse("InternalDocumentID= '" & Me.ID & "'")

            Dim myTransactions As New Transactions(MainApplication, criteria)
            ' Gibt es bereits Buchungen ? 

            ' ACHTUNG: Ist die Schleife falsch, oder die Abfrage, werden ALLE Transaktionen gelöscht !
            If myTransactions.Count > 0 Then myTransactions(0).DeleteInternal()


        End Sub


        ''' <summary>
        ''' Wenn true, wird dieses Dokument als 'markiert' dargestellt. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("Tagged", "Markiert")> _
        <System.ComponentModel.Description("Markierung")> _
        <Persistent("Flagged")> _
        Public Property Tagged() As Boolean
            Get
                Return m_tagged
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Tagged", m_tagged, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft eine zusammengefasse Liste aller Journalelemente ab und addiert alle Zahlendaten (Anzahl, Ziten usw.) 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ListOfItems As List(Of AcummulatedJournalItem)
            Get

                If itemsListNeedRebuild Then
                    m_journalItemsList.Clear()
                    m_journalItemListList.Clear()
                    itemsListNeedRebuild = False

                    Me.TotalDuration = TimeSpan.Zero

                    For Each itemGroup As JournalArticleGroup In Me.ArticleGroups
                        For Each item As JournalArticleItem In itemGroup.ArticleList
                            If Not item.IsText Then
                                Dim accItem As AcummulatedJournalItem

                                If Not m_journalItemsList.ContainsKey(item.OrgItemID) Then
                                    m_journalItemsList.Add(item.OrgItemID, New AcummulatedJournalItem(item.GetArticleItem))
                                    accItem = m_journalItemsList(item.OrgItemID)
                                Else
                                    accItem = m_journalItemsList(item.OrgItemID)
                                End If

                                accItem.ItemCount += item.ItemCount
                                accItem.ItemDisplayName = item.ItemName

                                accItem.ItemTimeSpan = m_journalItemsList(item.OrgItemID).ItemTimeSpan.Add(New TimeSpan(0, CInt(item.ItemCount * item.TimeInMinutes), 0))

                                ' Zeiten aufaddieren
                                Me.TotalDuration = Me.TotalDuration.Add(m_journalItemsList(item.OrgItemID).ItemTimeSpan)
                            End If
                        Next



                    Next

                    m_journalItemListList.AddRange(m_journalItemsList.Values)
                End If

                Return m_journalItemListList
            End Get
        End Property


        ''' <summary>
        ''' Erstellt aus diesem Vorfall einen Buchungssatz, wenn dieser Vorfall eine Rechnung oder Gutschrift ist
        ''' es werden keine Vorfälle doppelt angelegt
        ''' </summary>
        ''' <remarks></remarks>
        Sub CreateTransactionEntry()
            ' Nur für Rechnungen ode Gutschriften ausführen
            If Not (Me.DocumentType = enumJournalDocumentType.Rechnung Or Me.DocumentType = enumJournalDocumentType.Gutschrift) Then Exit Sub

            Dim criteria As CriteriaOperator = CriteriaOperator.Parse("InternalDocumentID= '" & Me.ID & "'")

            Dim myTransactions As New Transactions(MainApplication, criteria)
            ' Gibt es bereits Buchungen ? 

            Dim myTransaction As Transaction

            If myTransactions.Count > 0 Then
                myTransaction = myTransactions(0)
            Else
                myTransaction = myTransactions.GetNewItem()
                myTransaction.InternalDocumentID = Me.ID ' Eindeutige ID übergeben

                ' Gutschriften als negativen Betrag übernehmen!
                If Me.DocumentType = enumJournalDocumentType.Gutschrift Then
                    myTransaction.UnpaidAmmount = -myTransaction.TotalAmmount
                Else
                    ' normale Rechnungen 
                    myTransaction.UnpaidAmmount = myTransaction.TotalAmmount

                End If

                myTransaction.IsIntern = True
            End If


            myTransaction.Adress = Me.Address
            myTransaction.CashAccount = Me.CashAccount

            myTransaction.ItemDate = Me.DocumentDate
            myTransaction.MoneyFlow = MoneyFlow.IsReceiveable
            myTransaction.ItemDisplayNumber = Me.DocumentDisplayID
            myTransaction.TargetPayDate = Me.PaymentTarget

            ' Wenn nur eine einzige Steuer angegeben wurde, dann diese eintragen, sonst auf "False" setzen
            If CalculatedPriceContainer.Count = 1 Then
                myTransaction.TaxItem = CalculatedPriceContainer(0).TaxRate
                myTransaction.TaxValue = CalculatedPriceContainer(0).TaxRate.TaxValue
            Else
                myTransaction.TaxItem = Nothing
                myTransaction.TaxValue = Nothing
            End If



            myTransaction.Text = Me.Subject
            myTransaction.TotalAmmount = Me.DisplayedEndPrice  ' Gutschriften mit negativem Betrag aufnehmen

            If Me.DocumentType = enumJournalDocumentType.Gutschrift Then
                myTransaction.TotalAmmount = -Me.DisplayedEndPrice
            Else
                ' normale Rechnungen 
                myTransaction.TotalAmmount = Me.DisplayedEndPrice

            End If


            myTransaction.Save()

            ' Nun die Steuersätze speichern

            myTransaction.TaxValuePairs.Delete()
            For Each jTaxPair As JournalTaxValuePair In CalculatedPriceContainer

                Dim taxPair As TaxValuePair = myTransaction.TaxValuePairs.GetNewItem
                taxPair.ParentID = myTransaction.ID
                taxPair.Tax = jTaxPair.TaxRate
                taxPair.Text = jTaxPair.TaxRate.ToString
                taxPair.Value = jTaxPair.TotalPrice

                myTransaction.TaxValuePairs.Add(taxPair)
            Next


        End Sub


        ''' <summary>
        ''' Stellt eine Kennung dar, mit der eine Datenquelle Identifiziert werden kann (z.B. eBAyID / ) 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("SourceID")> _
        Public Property SourceID() As String
            Get
                Return m_itemSource
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SourceID", m_itemSource, value)
            End Set
        End Property

        ''' <summary>
        ''' Storno wurde erstellt und muss noch in die History geschrieben werden
        ''' </summary>
        ''' <remarks></remarks>
        Private m_CanceledStateSet As Boolean
        ''' <summary>
        ''' Storno wurde Rückgängig gemacht, und muss noch in die History geschrieben werden
        ''' </summary>
        ''' <remarks></remarks>
        Private m_CanceledStateCanceled As Boolean


        ''' <summary>
        ''' Setzt die Storno - Eigenschaft. Wird nicht automatisch gespeichert.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetCanceled()
            Me.IsCanceled = True
            Me.CanceledAt = Now
            Me.CanceledBy = m_mainApplication.CurrentUser.Name
            Me.CanceldStateHelper.AddDocument(Me)
            m_CanceledStateCanceled = False
            m_CanceledStateSet = True
        End Sub

        ''' <summary>
        ''' Entfernt den Status wieder aus der Auflistung. Wird nicht automatisch gespeichert.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ClearCanceled()
            Me.IsCanceled = False
            Me.CanceledBy = String.Empty
            Me.CanceledAt = Date.MinValue
            Me.CanceldStateHelper.RemoveDocument(Me)
            m_CanceledStateCanceled = True
            m_CanceledStateSet = False
        End Sub

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
        ''' Wenn wahr, wurde der Eintrag als ungültig markiert / Storniert. Bei Rechnungen werden summen nicht betrachtet und der entsprechende Buchungssatz wird nicht berücksichtigt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Nur Rechnungen können Storniert werden. Beim speichern ist die Auflistung der Stornierten rechnungen zu aktualisieruen</remarks>
        <Tools.DisplayName("IsCanceled", "Storno")> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Indexed()> _
        <Persistent("IsCanceled")> _
        Public Property IsCanceled As Boolean
            Get
                Return m_isCanceld
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsCanceled", m_isCanceld, value)
            End Set
        End Property


        ''' <summary>
        ''' Wenn als Storno markiert, wird hier der Name desjenigen angegeben, der den Storno ausgelöst hat
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(64)> _
        <Persistent("CanceledBy")> _
        Public Property CanceledBy() As String
            Get
                Return m_canceledBy
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("CanceledBy", m_canceledBy, value)
            End Set
        End Property

        ''' <summary>
        ''' Wenn als Storno markiert wird hier das Datum des Stornos angegenen.
        ''' Wurde kein storno gesetzt, wird kein gültiges Datum zurückgegeben
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Persistent("CanceledAt")> _
        Public Property CanceledAt() As DateTime
            Get
                Return m_canceldAt
            End Get
            Set(ByVal value As DateTime)

                SetPropertyValue(Of DateTime)("CanceledAt", m_canceldAt, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeuigt an, ob für Lieferscheine Lieferadresse statt Rechnungsadresse verwendet werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("UseDeliverAdress", "Benutze Lieferadresse")> _
        <Persistent("UseDeliveryAdress")> _
        Public Property UseDeliverAdress() As Boolean
            Get
                Return m_useDeliveryAdress
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("UseDeliverAdress", m_useDeliveryAdress, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Textfeld der Lieferadresse ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DeliveryAdress", "Lieferadresse")> _
        <Persistent("DeliveryAdress")> _
        Public Property DeliveryAdress() As String
            Get
                Return m_deliveryAdress
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("DeliveryAdress", m_deliveryAdress, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Mehrwertsteuersatz ab, der für alle Artikel gesetzt wurde oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("CommonTaxRate", "Steuersatz")> _
        Public Property CommonTaxRate() As TaxRate
            Get
                Return Me.MainApplication.TaxRates.GetItem(Me.TaxValueID)
            End Get
            Set(ByVal neuerSteuersatz As TaxRate)
                Me.TaxValueID = neuerSteuersatz.ID
            End Set
        End Property



        ''' <summary>
        ''' Überschrift oberhalb des Dokuments (Im Ausdruck)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <ClausSoftware.Tools.DisplayName("HeadText", "Kopftext")> _
        <Persistent("Kopftext")> _
        Public Property HeadText() As String
            Get
                If m_headText Is Nothing Then
                    m_headText = String.Empty
                End If
                Return m_headText
            End Get
            Set(ByVal value As String)
                If value IsNot Nothing Then
                    If value.Length > m_mainApplication.Database.GetColumnCharacterLength(JournalDocument.Tablename, "Kopftext") Then

                        value = value.Substring(0, CInt(m_mainApplication.Database.GetColumnCharacterLength(JournalDocument.Tablename, "Kopftext")))
                    End If
                End If

                SetPropertyValue(Of String)("HeadText", m_headText, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft die numerische ID der Adresse ab, die diesem eintrag zugeordnet ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("AddressNumberID", "Adressennummer")> _
        <Persistent("KNummer")> _
        Public Property AddressNumber() As Integer
            Get
                Return m_adressID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("AddressNumber", m_adressID, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft das Adressenobjekt dieses Dokumentes ab oder setzt es.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("Address", "Adresse")> _
        Public Property Address() As Kernel.Adress
            Get

                Return MainApplication.Adressen.GetItemByNumber(m_adressID)
            End Get
            Set(ByVal value As Kernel.Adress)
                If value IsNot Nothing Then
                    m_adressID = CInt(value.Kundennummer)
                    Me.AddressWindow = value.InvoiceAdressWindow

                End If

            End Set
        End Property



        ''' <summary>
        ''' Gesamtdauer für alle Artikel
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>        
        <Tools.DisplayName("TotalDuration", "Zeitdauer")> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Persistent("TotalDuration")> _
        Public Property TotalDuration() As TimeSpan
            Get
                Return m_Totalduration
            End Get
            Set(ByVal value As TimeSpan)

                SetPropertyValue(Of TimeSpan)("TotalDuration", m_Totalduration, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft das Datum ab, wann der Datensatz angelegt wurde. Kann nicht geändert werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("CreatedAt", "Angelegt am")> _
        <Persistent("AngelegtAm")> _
        Public Property CreatedAt() As Date
            Get
                Return m_createdAt
            End Get

            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("CreatedAt", m_createdAt, value)
            End Set
        End Property

        <ComponentModel.Browsable(False)> _
        <Size(64)> _
        <Persistent("CreatedByID")> _
        Public Property CreatedByID() As String
            Get
                Return m_createdBy
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CreatedByID", m_createdBy, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Ersteller des Dokumentes ab.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Besitzt nur einen Wert, wenn auch eine Benutzersteuerung aktiviert wurde</remarks>    
        <ClausSoftware.Tools.DisplayName("CreatedBy", "Angelegt von")> _
        Property CreatedBy() As Security.User
            Get
                Return MainApplication.Users.GetItem(Me.CreatedByID)
            End Get
            Set(ByVal value As Security.User)
                If value IsNot Nothing Then
                    CreatedByID = value.Key
                Else
                    CreatedByID = String.Empty
                End If
            End Set
        End Property



        ''' <summary>
        ''' Ruft das Datum ab, an dem das Dokument zuletzt geändert und gespeichert wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ChangedAt", "Geändert am")> _
        <Persistent("GeändertAm")> _
        Public Property ChangedAt() As Date
            Get
                Return m_changedAt
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("ChangedAt", m_changedAt, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt den Typ des Dokuments dar oder legt dies fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <System.ComponentModel.Browsable(False)> _
        <ClausSoftware.Tools.DisplayName("DocumentTyp", "Dokumenten Typ")> _
        <Persistent("Status")> _
        Public Property DocumentType() As enumJournalDocumentType
            Get
                Return m_documentType
            End Get
            Set(ByVal value As enumJournalDocumentType)
                If value = enumJournalDocumentType.ALL Then Throw New ArgumentException("Dokumententyp 'ALL' kann icht gesetzt werden")

                'If Not Me.IsLoading Then
                '    Debug.Print(CStr(Me.ArticleGroups.Count))
                'End If

                SetPropertyValue(Of enumJournalDocumentType)("DocumentType", m_documentType, value)

                Me.DocumentTypeText = GetDocumentTypeDisplayName(value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt die aktuelle Nummer des Dokuments dar, diese bildet die Dokumentennummer, die im Ausdruck erscheint.
        ''' Ist für jeweils ein Dokuementen-Typ eindeutig
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        <ClausSoftware.Tools.DisplayName("DocumentKeyID", "Nummer")> _
        <Persistent("lfndNummer")> _
        Public Property DocumentID() As Integer
            Get

                Return m_documentID
            End Get
            Set(ByVal value As Integer)
                ' Bevor der wert sich änder noch schnell die Positionen abholen!

                If Not Me.IsLoading Then
                    Debug.Print(CStr(Me.ArticleGroups.Count))
                End If

                SetPropertyValue(Of Integer)("DocumentID", m_documentID, value)

            End Set
        End Property


        ''' <summary>
        ''' Ruft aus einem Dokuemententype einen Anzeigenamen ab
        ''' </summary>
        ''' <param name="docType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nun die neue Funktion XY verwenden!")> _
        Public Shared Function GetDocTypeDisplayName(ByVal docType As enumJournalDocumentType) As String
            Select Case docType
                Case enumJournalDocumentType.ALL : Return m_mainApplication.Languages.GetText("JournalTypeALL", "Alle")
                Case enumJournalDocumentType.Angebot : Return m_mainApplication.Languages.GetText("JournalTypeOffers", "Angebot")
                Case enumJournalDocumentType.Auftrag : Return m_mainApplication.Languages.GetText("JournalTypeOrder", "Auftrag")
                Case enumJournalDocumentType.Gutschrift : Return m_mainApplication.Languages.GetText("JournalTypeRefund", "Gutschrift")
                Case enumJournalDocumentType.Mahnung : Return m_mainApplication.Languages.GetText("JournalTypeReminder", "Mahnung")
                Case enumJournalDocumentType.Rechnung : Return m_mainApplication.Languages.GetText("JournalTypeInvoice", "Rechnung")
                Case Else : Return "-Fehler-" 'TODo:NLS
            End Select
        End Function

        ''' <summary>
        ''' Enthält einen Typ des Journaldokumntes
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared m_journalTypes As Dictionary(Of Integer, JournalDocumentType)

        ''' <summary>
        ''' Ruft den Namen des Dokumenten-Typs ab
        ''' </summary>
        ''' <param name="documentTypeID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDocumentTypeDisplayName(ByVal documentTypeID As Integer) As String
            Dim jType As JournalDocumentType = MainApplication.JournalDocuments.DocumentTypeNames(documentTypeID)

            If jType IsNot Nothing Then
                Return jType.Name
            Else
                Return "-Nicht definiert-"
            End If


        End Function



        ''' <summary>
        ''' Stellt eine Auflistung aller Anhänge zu dieem Dokument dar.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("AttachmentList", "Anhänge")> _
        Public ReadOnly Property Attachments() As Generic.List(Of Attachment) Implements IAttachments.Attachments
            Get
                Return MainApplication.AttachmentRelations.GetAttachmentsBySourceID(Me.ReplikID)
            End Get
        End Property

        ''' <summary>
        ''' Ruft die ReplikID des Dokuemntes ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Overloads Property ReplikID() As String Implements IAttachments.ReplikID
            Get
                Return MyBase.ReplikID
            End Get
            Set(ByVal value As String)
                MyBase.ReplikID = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft eine Auflistung von Anhängen dieses Dokuementes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        Public ReadOnly Property AttachmentLinks() As AttachmentsRelations Implements IAttachments.AttachmentLinks
            Get
                Dim criteria As Filtering.CriteriaOperator = Filtering.CriteriaOperator.Parse("SourceDocumentID='" & Me.ReplikID & "'")
                Dim attachmentRelations As New AttachmentsRelations(MainApplication, criteria)

                Return attachmentRelations
            End Get

        End Property

        ''' <summary>
        ''' Stellt das Dokumentendatum dar, wie es im Ausdruck erscheint.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DocumentDate", "Datum")> _
        <Persistent("Datum")> _
        Public Property DocumentDate() As Date
            Get

                ' Letzte Hoffnung - Dokumenten-Dateum setzen
                If m_DokumentenDatum = Date.MinValue Then
                    If Not m_createdAt = DateTime.MinValue Then
                        m_DokumentenDatum = m_createdAt
                    End If
                End If

                Return m_DokumentenDatum
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("DocumentDate", m_DokumentenDatum, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt ein Beschreibungstext für dieses Dokument dar. Wird nicht gedruckt, kann weitere Infos zum Hergang erhalten
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
         <ClausSoftware.Tools.DisplayName("MemoText", "Beschreibung")> _
        <Persistent("Memo")> _
        Public Property MemoText() As String
            Get
                If m_memo Is Nothing Then
                    Return String.Empty
                End If
                Return m_memo
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = String.Empty
                SetPropertyValue(Of String)("MemoText", m_memo, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt das Zahlungsziel dar. Nach Ablauf dieser Zeitspanne gilt das Dokument als nicht bezahlt und Überfällig.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("PaymentTarget", "Zahlungsziel")> _
        <Persistent("Ultimo")> _
        Public Property PaymentTarget() As DateTime
            Get
                ' MinValue bedeutet nicht, das es nie bezahlt werden soll, sondern unverzüglich
                If m_TargetPayDate = Date.MinValue Then
                    m_TargetPayDate = Me.DocumentDate
                End If

                Return m_TargetPayDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("PaymentTarget", m_TargetPayDate, value)
            End Set
        End Property

        ''' <summary>
        ''' Wert eines Rabatts (oder Aufschlag) sofern RabattAktiv ist.
        ''' Betrag wird dem Verkauspreis zu- oder abgezogen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DiscountValue", "Rabattwert")> _
        <Persistent("Rabatt")> _
        Public Property DiscountValue() As Decimal
            Get
                Return m_discountValue
            End Get
            Set(ByVal value As Decimal)

                SetPropertyValue(Of Decimal)("DiscountValue", m_discountValue, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Absuluten Betrag in Währungseinheit des Rabattes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("DiscountValueAbs", "Rabattbetrag")> _
        Public ReadOnly Property DiscountValueAbs As Decimal
            Get

                Dim TaxedValue As Decimal

                If Me.ShowWithoutTax Then
                    TaxedValue = Me.EndPriceAfterTax()
                Else
                    TaxedValue = Me.EndPriceBeforeTaxAndDiscount()
                End If


                If Me.DiscountIsAbsolut Then
                    Return DiscountValue
                End If
                ' Prozentuelen Wert berechnen 

                Return TaxedValue * (Me.DiscountValue / 100)

            End Get

        End Property


        ''' <summary>
        ''' Legt den Text für Rechnungsrabatte fest oder ruft diesen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DiscountText", "Rabatttext")> _
        <Size(50)> _
        <Persistent("RabattText")> _
        Public Property DiscountText() As String
            Get
                Return m_rabatttext
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DiscountText", m_rabatttext, value)
            End Set
        End Property


        ''' <summary>
        ''' Ist der Rabatt aktiv, so wird vom Verkauspreis Rabattwert ab- oder aufgeschlagen; je nach Vorzeichen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DiscountActive", "Rabatt aktiv")> _
        <Persistent("RabattAktiv")> _
        Public Property DiscountActive() As Boolean
            Get
                Return m_DiscountActive
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("DiscountActive", m_DiscountActive, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt einen Einzeiler dar, der den Inhalt des Dokumentes kurz beschreibt. Text ist nur im Journal sichtbar
        ''' Wird nicht ausgedruckt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("TitelText", "Text")> _
        <Persistent("TitelText")> _
        Public Property TitelText() As String
            Get
                If m_Titeltext Is Nothing Then m_Titeltext = String.Empty
                Return m_Titeltext
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TitelText", m_Titeltext, value)
            End Set
        End Property


        ''' <summary>
        ''' Enthält eine Ansicht aus dem Titel und der Kopfzeile
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("Subject", "Betreff")> _
        Public ReadOnly Property Subject() As String
            Get

                If String.IsNullOrEmpty(Me.TitelText) And String.IsNullOrEmpty(Me.HeadText) Then
                    ' Beide Texte waren leer. 
                    ' = > Nr. Datum und Adresse
                    Return Me.DocumentDisplayID & ", " & Me.DocumentDate.ToString("D") & ", " & Me.AddressWindow
                End If

                ' Einer der Texte Kopftext oder Titel existiert

                If String.IsNullOrEmpty(HeadText.Trim) Then
                    Return TitelText
                End If

                If String.IsNullOrEmpty(TitelText.Trim) Then
                    Return HeadText
                End If

                Return TitelText & ", " & HeadText
            End Get

        End Property

        ''' <summary>
        ''' Zeigt an, wenn dies eine Rechnung ist, ob der Datensatz auch als Geschäftsvorfall genutz werden soll. 
        ''' Ab HWL 2 ist der Standard "Ja", Alle Rechnungen werden kopiert.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("In HWL 2 ist der Standard immer auf TRUE")> _
        <Persistent("CopyIntern")> _
        Public Property CopyIntern() As Boolean
            Get
                Return m_copyIntern
            End Get
            Set(ByVal value As Boolean)
                value = True
                SetPropertyValue(Of Boolean)("CopyIntern", m_copyIntern, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt die Kontonummer dar oder legt diese fest zu der das Dokument gebucht wird, falls der type eine Rechnung oder Gutschrift ist.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("KontonummerID")> _
        <Persistent("Kontonummer")> _
        Public Property CashAccountID() As Integer
            Get
                Return m_cashAccountID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CashAccountID", m_cashAccountID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Buchungskonto ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("CashAccount", "Buchungskonto")> _
        Property CashAccount() As CashAccount
            Get

                Return MainApplication.CashAccounts.GetItem(Me.CashAccountID)

            End Get
            Set(ByVal value As CashAccount)
                If value IsNot Nothing Then
                    Me.CashAccountID = value.ID
                Else
                    Me.CashAccountID = -1
                End If

            End Set
        End Property

        ''' <summary>
        ''' Stellt einen Text unterhalb des Dokuments dar oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
<ClausSoftware.Tools.DisplayName("FooterText", "Fusstext")> _
<Persistent("Fusstext")> _
        Public Property FooterText() As String
            Get
                If m_footerText Is Nothing Then
                    m_footerText = ""
                End If
                Return m_footerText
            End Get
            Set(ByVal value As String)

                If value IsNot Nothing Then
                    If value.Length > m_mainApplication.Database.GetColumnCharacterLength(JournalDocument.Tablename, "Fusstext") Then

                        value = value.Substring(0, CInt(m_mainApplication.Database.GetColumnCharacterLength(JournalDocument.Tablename, "Fusstext")))
                    End If
                End If

                SetPropertyValue("FooterText", m_footerText, value)

            End Set
        End Property


        ''' <summary>
        ''' Stellt ein Eintrag als Druck-Dokument zur Verfügung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>In HWL 1.x wurden Dokumente zum druck immer erst in der Datenbank gesichert. Ist ab 2.x nicht mehr nötig</remarks>
        <Obsolete("Nicht mehr verwenden")> _
        <Persistent("ForPrinting")> _
        Property ForPrinting() As Boolean
            Get
                Return m_forPrinting
            End Get
            Set(ByVal value As Boolean)
                m_forPrinting = value
            End Set
        End Property

        ''' <summary>
        ''' Stellt das Adressfenster dar oder legt es fest, so wie es im Dokument erscheinen soll.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
 <ClausSoftware.Tools.DisplayName("AddressWindow", "Adressfenster")> _
 <Persistent("AdressFenster")> _
        Public Property AddressWindow() As String
            Get
                If m_Adressfenster Is Nothing Then m_Adressfenster = String.Empty

                Return m_Adressfenster
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AddressWindow", m_Adressfenster, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt einen Merker dar, der anzeigt ob das Adressfenster durch Benutzereingriff nicht dem Adressfenster aus derm Adressdokument entspricht.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ClausSoftware.Tools.DisplayName("AddressWindowChangedByUser", "Adressfenster geändert")> _
        <Persistent("UserChangedAdressFenster")> _
        Public Property AddressWindowChangedByUser() As Boolean
            Get
                Return m_userChangedAddressWindow
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("AddressWindowChangedByUser", m_userChangedAddressWindow, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt eien verbindung zu einem anderen Document her. (Mahungen sind zB von Rechnungen abgeleitet)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("ParentdocID")> _
        Public Property ParentDocumentID() As String
            Get
                Return m_ParentDocID
            End Get
            Set(ByVal value As String)
                m_ParentDocID = value


            End Set
        End Property

        ''' <summary>
        ''' Fügt dem aktuellen Journaleintrag eine neue Position hinzu
        ''' </summary>
        ''' <param name="newArticleGroup">Fügt eine neue Artikelgruppe diesem Dokument hinzu</param>
        ''' <remarks></remarks>
        Public Sub AddArticleGroup(ByVal newArticleGroup As JournalArticleGroup)
            newArticleGroup.ParentDocument = Me
            newArticleGroup.ShowWithTax = Me.ShowWithoutTax
            Me.ArticleGroups.Add(newArticleGroup)
            AddHandler newArticleGroup.Changed, AddressOf JournalGroupChanged
        End Sub

        ''' <summary>
        ''' Erstellt eine neue Journalartikelgruppe mit diesem Element als Basis.
        ''' Das element wird der Auflistung der Gruppen hinzugefügt
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNewArticleGroup() As JournalArticleGroup
            Dim newgroup As New JournalArticleGroup(Me)
            Me.AddArticleGroup(newgroup)
            Return newgroup
        End Function

        ''' <summary>
        ''' Wird ausgelöst, wenn sich eine untergeordnete Gruppe geändert hat
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub JournalGroupChanged(ByVal sender As Object, ByVal e As EventArgs)
            Static AtWork As Boolean
            If AtWork Or m_isDeleting Then Exit Sub
            AtWork = True
            SetHaschanged()

            TotalPriceBeforeTax = EndPriceBeforeTaxAndDiscount ' Berechneten Endpreis auf das Dokument schreiben

            ' Die Auflistunghat sich geändert
            If TypeOf e Is XPCollectionChangedEventArgs Then
                Dim xpcollection As XPCollectionChangedEventArgs = CType(e, XPCollectionChangedEventArgs)
                If xpcollection.CollectionChangedType = XPCollectionChangedType.AfterAdd Then

                    Dim item As JournalArticleGroup = CType(xpcollection.ChangedObject, JournalArticleGroup)
                    AddHandler item.Changed, AddressOf Me.JournalGroupChanged ' Das ändern der Gruppen-Auflistung überwachen

                End If

                ' Das entfernen ebenfalls überwachen
                If xpcollection.CollectionChangedType = XPCollectionChangedType.AfterRemove Then

                    Dim item As JournalArticleGroup = CType(xpcollection.ChangedObject, JournalArticleGroup)
                    RemoveHandler item.Changed, AddressOf Me.JournalGroupChanged ' Das ändern der Gruppen-Auflistung überwachen

                End If
            End If

            'Angezeigten endpreis neu berechnen
            If DiscountActive Then ' Bei bei Aktivität den Betrag auch berechnen
                'Me.DisplayedEndPrice = Me.EndPriceAfterTax - Me.DiscountValueAbs ' Endpreis im Journal erzeugen

                Dim totalPrice As Decimal
                For Each discountedValue As JournalTaxValuePair In Me.DiscountedPriceList.DiscountedValues
                    totalPrice += discountedValue.TotalPrice
                Next
                Me.DisplayedEndPrice = totalPrice
            Else
                Me.DisplayedEndPrice = Me.EndPriceAfterTax
            End If

            



            AtWork = False

        End Sub

        Protected Overrides Sub OnChanged(ByVal propertyName As String, ByVal oldValue As Object, ByVal newValue As Object)
            MyBase.OnChanged(propertyName, oldValue, newValue)
            SetHaschanged()

            JournalGroupChanged(Me, EventArgs.Empty)
            
        End Sub
        ''' <summary>
        ''' Ruft alle Positionen dieses Journaldokumentes ab. 
        ''' Die Auflistung wird nur einmal vom server ermittelt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ArticleGroups", "Artikelgruppen")> _
        <ComponentModel.Browsable(True)> _
        Public ReadOnly Property ArticleGroups() As JournalArticleGroups
            Get

                If m_itemGroups Is Nothing Then

                    m_itemGroups = New JournalArticleGroups(Me)

                    'Alle Artikelgruppen unter Beobachtung stellen
                    For Each item As JournalArticleGroup In m_itemGroups
                        RemoveHandler item.Changed, AddressOf JournalGroupChanged
                        AddHandler item.Changed, AddressOf JournalGroupChanged
                    Next
                    ' Steuersätze reparieren, falls noch niht geschehen 

                    ' Tempoäre Liste erzwingen 
                    Dim grpList As New List(Of JournalArticleGroup)
                    grpList.AddRange(m_itemGroups)

                    For Each pos As JournalArticleGroup In grpList

                        For posItemID As Integer = 0 To pos.ArticleList.Count - 1
                            Dim posItem As JournalArticleItem = pos.ArticleList(posItemID)

                            If posItem.TaxRateValue = 0 Then ' Ist ein Hinweis darauf, das keine Steuersätze vergeben wurden
                                posItem.TaxRateID = Me.TaxValueID
                                posItem.TaxRateValue = Me.TaxValue

                                If posItem.HasChanged Then
                                    posItem.Save()
                                End If
                            End If
                        Next

                    Next

                    'Urspüngliche Auflistung der Positionen merken; die Differenz bildet später die Grundlage zum löschen
                    m_orgItemGroups.Clear()
                    m_orgItemGroups.AddRange(m_itemGroups)

                    AddHandler m_itemGroups.CollectionChanged, AddressOf JournalGroupChanged
                End If

                Return m_itemGroups
            End Get

        End Property


        ''' <summary>
        ''' Entfernt eine Position aus der Auflistung
        ''' </summary>
        ''' <param name="position"></param>
        ''' <remarks></remarks>
        Public Sub RemovePosition(ByVal position As JournalArticleGroup)
            RemoveHandler position.Changed, AddressOf JournalGroupChanged
            ArticleGroups.Remove(position)

        End Sub

        ''' <summary>
        ''' Liefert das zugrundeliegende Vater-Dokument wieder zurück
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        Public Property ParentDocument() As Kernel.JournalDocument
            Get
                If Me.ParentDocumentID.Length = 32 Then ' Nur dann ist dort eine ReplikID enthalten mit einem Verweis auf (möglichwerweise) einem andern Dokument

                    Return Me.MainApplication.JournalDocuments.GetItem(Me.ParentDocumentID)
                Else
                    Return (Nothing)
                End If

            End Get
            Set(ByVal ParentDocument As Kernel.JournalDocument)
                Me.ParentDocumentID = CStr(ParentDocument.ID)
            End Set
        End Property


        ''' <summary>
        ''' Zeigt den kummulierten brutto Rechnungsbetrag an, der auch auf der Rechnung erscheint. 
        ''' Inklusive Steueranteil und Rabatt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Der Betrag ist der Endbetrag, der auf der Rechnung angezeigt wird (immer Brutto) Entspricht der letzten Zeile im Rechnungsdokument. Der Wert kann nicht gesetzte werden, einzelpreise aktualisieren sich nicht</remarks>
        <ClausSoftware.Tools.DisplayName("SalesPrice", "Betrag")> _
        <Persistent("Betrag")> _
        Public Property DisplayedEndPrice() As Decimal
            Get

                Return m_bruttoFixedEndPrice

            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DisplayedEndPrice", m_bruttoFixedEndPrice, value)
            End Set
        End Property



        ''' <summary>
        ''' Berechneter netto Gesamtpreis, (Aus Summe aller Artikelgruppen), wird berechnet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("TotalPriceBeforeTax", "Netto Gesamtpreis")> _
        <Persistent("TotalPriceBeforeTax")> _
        Public Property TotalPriceBeforeTax() As Decimal
            Get
                Return m_totalPriceBeforeTax
            End Get
            Set(ByVal value As Decimal)

                SetPropertyValue(Of Decimal)("TotalPriceBeforeTax", m_totalPriceBeforeTax, value)
            End Set
        End Property



        ''' <summary>
        ''' Ruft die Liste der netto- Einzelpreise aus allen Artikeln ab; Nach MwSt sortiert und dessen netto-Betrag dabei
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("CalculatedTaxesContainer", "Steueranteile des Dokumentes")> _
        Public ReadOnly Property CalculatedPriceContainer() As List(Of JournalTaxValuePair)
            Get
                Dim priceList As New Dictionary(Of Decimal, JournalTaxValuePair)
                priceList.Clear()

                Dim totalNettoPrice, totalBruttoPrice As Decimal

                For Each itemPrice As JournalTaxValuePair In Me.ArticleGroups.GetPrices.Values
                    If Not priceList.ContainsKey(itemPrice.TaxRateValue) Then
                        priceList.Add(itemPrice.TaxRateValue, itemPrice)
                    Else
                        priceList(itemPrice.TaxRateValue).NettoPrice += itemPrice.NettoPrice
                        priceList(itemPrice.TaxRateValue).TotalPrice += itemPrice.TotalPrice

                    End If
                    ' Für anteilige Rabattabzüge nötig
                    totalNettoPrice += itemPrice.NettoPrice
                    totalBruttoPrice += itemPrice.TotalPrice

                Next

                m_myPriceListContainer.Clear()
                m_myPriceListContainer.AddRange(priceList.Values)
                priceList = Nothing

                Return m_myPriceListContainer
            End Get
        End Property

        ''' <summary>
        ''' Ruft eine Auflistung von Steuern und Preisen ab und enthält zusätzlich den rabattierten Wert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DiscountedPriceList", "Rabattierte Steueranteile")> _
        Public ReadOnly Property DiscountedPriceList As DiscountedPriceContainer
            Get

                ' Relativen Rabattwert festlegen
                Dim relativediscount As Decimal
                If Me.EndPriceAfterTax > 0 Then

                    If Me.ShowWithoutTax Then
                        relativediscount = 100 * (Me.DiscountValueAbs / Me.EndPriceAfterTax)
                    Else
                        relativediscount = 100 * (Me.DiscountValueAbs / Me.EndPriceBeforeTaxAndDiscount)
                    End If
                Else
                    relativediscount = 0
                End If


                If Not Me.DiscountActive Then ' Nur, wenn der Rabatt eingeschaltet ist auch berechnen
                    relativediscount = 0
                End If

                Dim dpc As New DiscountedPriceContainer(MainApplication)
                dpc.DiscountRelative = relativediscount
                dpc.UndiscountedValues = Me.CalculatedPriceContainer
                Return dpc
            End Get
        End Property

        ''' <summary>
        ''' Fügt ein Verlauf-eintrag der Adresse hinzu
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub SetHistoryItem()

            If Me.Address Is Nothing Then Exit Sub
            Try
                ' Neue (und geänderte?) Ereignisse werden hinzugefügt
                If Not Me.Address.History.ContainsSystemItem(Me.Key) Then
                    Dim newItem As AddressHistoryItem = Me.Address.History.GetNewItem()
                    newItem.ItemDate = Me.DocumentDate
                    newItem.ParentItemID = Me.Key
                    newItem.IsSystemMessage = True
                    newItem.Category = MainApplication.HistoryCategories.GetTransactionCategory
                    newItem.Adress = Me.Address

                    With newItem
                        'TODO: NLS
                        Select Case Me.DocumentType
                            Case enumJournalDocumentType.Angebot
                                .Text = "Neues Angebot erstellt: " & vbCrLf
                            Case enumJournalDocumentType.Auftrag
                                .Text = "Neuer Auftrag erstellt" & vbCrLf
                            Case enumJournalDocumentType.Gutschrift
                                .Text = "Neue Gutschrift erstellt" & vbCrLf
                            Case enumJournalDocumentType.Mahnung
                                .Text = "Neue Mahnung erstellt" & vbCrLf
                            Case enumJournalDocumentType.Rechnung
                                .Text = "Neue Rechnung erstellt" & vbCrLf
                        End Select

                        .Text &= "Nummer: " & Me.DocumentDisplayID & " " & Me.Subject & vbCrLf & "Gesamtpreis: " & Me.DisplayedEndPrice.ToString("c")
                    End With
                    newItem.Save()
                    Me.Address.History.Add(newItem)
                End If

                If m_CanceledStateSet Then
                    ' Storno markieren
                    Dim newItem As AddressHistoryItem = Me.Address.History.GetNewItem()
                    newItem.ItemDate = Me.DocumentDate
                    newItem.ParentItemID = Me.Key
                    newItem.IsSystemMessage = True
                    newItem.Category = MainApplication.HistoryCategories.GetTransactionCategory
                    newItem.Adress = Me.Address
                    'TODO: NLS
                    newItem.Text = "Dokument wurde storniert" & vbCrLf
                    newItem.Text &= Me.DocumentTypeText & "Nummer: " & Me.DocumentDisplayID & " " & Me.Subject & vbCrLf & "Gesamtpreis: " & Me.DisplayedEndPrice.ToString("c")
                    m_CanceledStateSet = False
                    newItem.Save()
                    Me.Address.History.Add(newItem)
                End If

                If m_CanceledStateCanceled Then
                    ' Storno markieren
                    Dim newItem As AddressHistoryItem = Me.Address.History.GetNewItem()
                    newItem.ItemDate = Me.DocumentDate
                    newItem.ParentItemID = Me.Key
                    newItem.IsSystemMessage = True
                    newItem.Category = MainApplication.HistoryCategories.GetTransactionCategory
                    newItem.Adress = Me.Address
                    'TODO: NLS
                    newItem.Text = "Storno wurde wieder rückgängig gemacht." & vbCrLf
                    newItem.Text &= Me.DocumentTypeText & " Nummer: " & Me.DocumentDisplayID & " " & Me.Subject & vbCrLf & "Gesamtpreis: " & Me.DisplayedEndPrice.ToString("c")
                    m_CanceledStateCanceled = False
                    newItem.Save()
                    Me.Address.History.Add(newItem)
                End If

            Catch ex As Exception
                MainApplication.log.WriteLog(ex, "SetHistoryItem", "Fehler beim Speichern von Verlaufsinformationen des Journaldokumentes")
            End Try
        End Sub

        Protected Overrides Sub OnLoaded()
            MyBase.OnLoaded()

        End Sub

        ''' <summary>
        ''' Wahr, wenn der Artikelpreis inklusive steueranteil angezeigt werden soll. ("Ink. MwSt"), Falsch, wenn Artikelpreis Netto-Betrag ist ("Preis plus MwSt")
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ShowWithTax")> _
        Public Property ShowWithoutTax() As Boolean
            Get
                Return m_showWithTax
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ShowWithoutTax", m_showWithTax, value)
                If Not IsLoading Then
                    Me.ArticleGroups.SetShowWithTax(value)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Zeigt den Text an, der die art der Summe kennzeichnet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("DisplayBasePriceText", "Anzeigetext Summe")> _
        ReadOnly Property DisplayBasePriceText As String
            Get
                If Me.ShowWithoutTax Then
                    Return GetText("msgInvoiceSumWithTax", "Summe")
                Else
                    Return GetText("msgInvoiceSumWithoutTax", "Summe (netto)")
                End If
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Text ab, der bei einer Rechnung den Text 'Mit Steuern / Ohne Steuern' enthält
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("DisplayTaxValueText", "Anzeigetext Steuersummen")> _
        ReadOnly Property DisplayTaxValueText As String
            Get
                If Me.ShowWithoutTax Then
                    Return GetText("msgInvoiceVATIncluded", "Ink. MwSt.: ")
                Else
                    Return GetText("msgInvoiceVATOnTop", "Zuzgl. MwSt.: ")
                End If
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Basispreis ab. Je nach Einstellung mit oder ohne Steueranteil, nicht Rabattiert.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("DisplayBasePrice", "Summe")> _
        ReadOnly Property DisplayBasePrice As Decimal
            Get

                If Me.ShowWithoutTax Then
                    Return EndPriceAfterTax()
                Else
                    Return EndPriceBeforeTaxAndDiscount
                End If
            End Get
        End Property

        ''' <summary>
        ''' Ruft die Zwischensumme ab. Summe - Rabattwert. Je nach Sinstellung wird der Steuerbehaftete  Wert oder der  Nettowert angeigt
        ''' </summary>
        ''' <value></value>
        ''' <returns>Rabattwert wird nur berücksichtigt, wenn dieser auch 'aktiv' ist</returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("DisplayDiscountedValue", "Zwischensumme")> _
        Public ReadOnly Property DisplayDiscountedValue As Decimal
            Get
                If DiscountActive Then
                    Return DisplayBasePrice - DiscountValueAbs
                Else
                    Return DisplayBasePrice
                End If

            End Get
        End Property

        ''' <summary>
        ''' Ruft den kalkulierten netto-Gesamtpreis ab, ohne Abzüge.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("EndPriceBeforeTax", "Nettobetrag")> _
        Public ReadOnly Property EndPriceBeforeTaxAndDiscount() As Decimal
            Get
                Dim endPrice As Decimal

                For Each item As JournalTaxValuePair In CalculatedPriceContainer
                    endPrice += item.NettoPrice
                Next

                Return endPrice
            End Get
        End Property

        ''' <summary>
        '''Ermittelt den Gesamtpreis inklusive Steueranteil ab , ohne Abzüge.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function EndPriceAfterTax() As Decimal

            Dim endPrice As Decimal

            For Each item As JournalTaxValuePair In CalculatedPriceContainer
                endPrice += item.TotalPrice
            Next

            Return endPrice


        End Function

        ''' <summary>
        ''' Liefert den Text des Documententypen wieder zurück oder setzt diesen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Enthält die Textdarstellung des aktuellen Dokumentes</remarks>
        <ClausSoftware.Tools.DisplayName("DocumentTypeText", "Dokumententyp")> _
        <Persistent("TypeOfDocText")> _
        Public Property DocumentTypeText() As String
            Get
                Return m_TypeOfDocText
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DocumentTypeText", m_TypeOfDocText, value)
            End Set
        End Property



        ''' <summary>
        ''' Stellt einen wert da, der anzeigt ob der Rabattwert Absolut, also in festen Geld-Beträgen erscheint.
        ''' Bei TRUE ist der Rabattwert ein fester Betrag, wenn FALSE ein Prozentualer Abschlag
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("RabattIsAbs")> _
        Public Property DiscountIsAbsolut() As Boolean
            Get
                Return m_RabattIstAbsolut
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue("DiscountIsAbsolut", m_RabattIstAbsolut, value)
            End Set
        End Property

        ''' <summary>
        ''' Absoluter Wert des Rabatts
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("RabattAbs")> _
        Public Property RabattAbsolut() As Decimal
            Get
                Return m_RabattAbsolutBertrag
            End Get
            Set(ByVal value As Decimal)
                m_RabattAbsolutBertrag = value
            End Set
        End Property

        ''' <summary>
        ''' Stellt einen Wert dar, der anzeigt ob dieses Dokument abgeschlossen, also der Geschäftsvorfall Erfüllt ist.
        ''' Rechnungen wurden geliefert udn bezahlt, Mahnungen beglichen usw. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("FinishedTagged", "Erledigt")> _
        <Persistent("erledigt")> _
        Public Property Checked() As Boolean
            Get
                Return m_erledigt

            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Checked", m_erledigt, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt einen Wert dar, der anzeigt ob für dieses Dokument ein Rabatt benutzt wurde.
        ''' Wenn ja, so enthält die Spalte 'Rabatt' den Rabattwert.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("GlobalArtikelRabatt")> _
        Public Property GlobalItemDiscount() As Boolean
            Get
                Return m_GlobalerArtikelRabatt
            End Get
            Set(ByVal value As Boolean)
                m_GlobalerArtikelRabatt = value
            End Set
        End Property



        ''' <summary>
        ''' Ruft den gemeinsamen steuersatz ab, der der gesamten Rechnung zugeordnet ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        <Obsolete("Das gesamte dokument kann keinen steuersatz mehr haben; dies wird durch die einzelnen Artikel festgelegt")> _
        Public Property GlobalTaxRate() As Kernel.TaxRate
            Get
                Return MainApplication.TaxRates.GetItem(Me.TaxValueID)
            End Get
            Set(ByVal value As Kernel.TaxRate)
                Me.TaxValueID = value.ID
            End Set
        End Property


        ''' <summary>
        ''' Enthält die ID des Mwst-satzes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Steuersatz des Dokumentes bestimmt sich nach den einzelnen Artikel-Steuersätzen")> _
        <ComponentModel.Browsable(False)> _
        <Persistent("mwstsatz")> _
        Private Property TaxValueID() As Integer
            Get
                Return m_taxValueID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TaxValueID", m_taxValueID, value)
            End Set
        End Property

        ''' <summary>
        ''' Absoluter Prozentsatz des MWST-Wertes. Muss nicht mit dem tatsächlichen Wert übereinstimmen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Steuersatz des Dokumentes bestimmt sich nach den einzelnen Artikel-Steuersätzen")> _
        <ClausSoftware.Tools.DisplayName("TaxValue", "MwSt")> _
        <Persistent("mwstwert")> _
        Public Property TaxValue() As Decimal
            Get
                Return m_taxValue
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TaxValue", m_taxValue, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, ob dieses Dokument einen Anháng besitzt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("HasAttachment", "Anhang")> _
        ReadOnly Property HasAttachment() As Boolean
            Get
                Return MainApplication.AttachmentRelations.HasAttachments(Me.ReplikID)
            End Get
        End Property

        ''' <summary>
        ''' Speichert nur dieses Journaldokument, ohne die verknüpften Artikelgruppen etc,
        ''' Nur bei bereits bestehenden Journaleinträgen möglich
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Plainsave()
            If Not Me.IsNew Then
                MyBase.Save()
            Else
                Throw New InvalidOperationException("Cant plainSave a Journalentry if this entry is in 'new'-State")
            End If
        End Sub

        ''' <summary>
        ''' Läd die Daten neu ein
        ''' </summary>
        ''' <remarks></remarks>
        Public Overloads Sub Reload()
            m_itemGroups.Reload()
            MyBase.Reload()

            ' Den iscanceld - Status aktualiseren
            If Me.IsCanceled Then
                Me.CanceldStateHelper.AddDocument(Me)
            Else
                Me.CanceldStateHelper.RemoveDocument(Me)
            End If
        End Sub

        ''' <summary>
        ''' Aktualisiert die Anzeige ID dieses Datensatzes
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RefreshDisplayID()
            If Me.DocumentType = enumJournalDocumentType.Rechnung Then
                Me.DocumentDisplayID = m_mainApplication.Tools.CreateInvoicesDisplayID(Me.DocumentID, Me.CreatedAt)
            ElseIf Me.DocumentType = enumJournalDocumentType.Angebot Then
                Me.DocumentDisplayID = m_mainApplication.Tools.CreateOffersDisplayID(Me.DocumentID, Me.CreatedAt)

            Else
                ' alle anderen Typen einfach hochzählen
                Me.DocumentDisplayID = Me.DocumentID.ToString

            End If


        End Sub

        ''' <summary>
        ''' Ruft das Geändert-Signal für dieses Dokument und alle arin enthaltenen Gruppen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides ReadOnly Property HasChanged As Boolean
            Get
                If MyBase.HasChanged Then Return MyBase.HasChanged

                ' Falls False, dann rekursiv alle Gruppen und Artikl durchsuchen, ob diese sich geändert haben
                For Each item As JournalArticleGroup In Me.ArticleGroups
                    If item.HasChanged Then Return True
                Next

                Return False
            End Get
        End Property

        ''' <summary>
        ''' Entfernt das Geändert - Flag für alle Journalgruppen unter diesem Dokument
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub ClearHasChangedState()
            MyBase.ClearHasChangedState()

            ' Falls False, dann rekursiv alle Gruppen und Artikl durchsuchen, ob diese sich geändert haben
            For Each item As JournalArticleGroup In Me.ArticleGroups
                item.ClearHasChangedState()
            Next
        End Sub

        ''' <summary>
        ''' Speichert das JournalDokument und alles was darin enthalten ist ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()
            If String.IsNullOrEmpty(SourceID) Then SourceID = " "
            If String.IsNullOrEmpty(DiscountText) Then DiscountText = " "
            If String.IsNullOrEmpty(DeliveryAdress) Then DeliveryAdress = " "

            Dim wasNew As Boolean = Me.IsNew

            If Me.HasChanged Then
                Me.ChangedAt = Now
                Me.itemsListNeedRebuild = True


                Debug.Print("Speichere Journal-Dokument")

                If Me.DocumentID = 0 Then ' Noch nie gespeichert? 
                    ' höchste DB-Nummer abholen 

                    Dim result As Integer
                    Dim sql As String


                    Dim resultobj As Object
                    sql = "select max(lfndnummer) from JournalListe where Status=" & Me.DocumentType
                    resultobj = MainApplication.Database.ExcecuteScalar(sql)

                    If Not TypeOf resultobj Is DBNull Then
                        result = CInt(resultobj) + 1
                    Else
                        result = 0
                    End If
                    Me.DocumentID = result

                End If

                If Me.DocumentType = enumJournalDocumentType.Rechnung Then
                    Me.DocumentDisplayID = m_mainApplication.Tools.CreateInvoicesDisplayID(Me.DocumentID, Me.CreatedAt)   ' Anhand der DocID die Ansichts-ID festlegen
                ElseIf Me.DocumentType = enumJournalDocumentType.Angebot Then
                    Me.DocumentDisplayID = m_mainApplication.Tools.CreateOffersDisplayID(Me.DocumentID, Me.CreatedAt)   ' Anhand der DocID die Ansichts-ID festlegen

                Else
                    Me.DocumentDisplayID = Me.DocumentID.ToString


                End If



                MyBase.Save()
                SaveItemGroups()

                Me.CreateTransactionEntry() ' In Forderungen / Verbindlichkeiten auch anlegen, falls noch nicht existiert

                SetHistoryItem()

            End If
        End Sub

        Private Sub SaveItemGroups()
            ' 1. Alle bestehenden Gruppen neu speichern, dann alle existierenden Gruppen löschen, die nicht mehr in der Auflistung sind. 

            For n As Integer = 0 To Me.ArticleGroups.Count - 1
                'For each kann scheitern, da beim Save das element geöndert wird
                Me.ArticleGroups(n).Save()

            Next

            ' nun mit der OrgLIste vergleichen, und alles wa snicht gleich ist, löschen
            For Each item As JournalArticleGroup In m_orgItemGroups
                If Not Me.ArticleGroups.ContainsKey(item.Key) Then
                    item.Delete()
                End If
            Next

            ' Listen synchronisieren
            m_orgItemGroups.Clear()
            m_orgItemGroups.AddRange(Me.ArticleGroups)


        End Sub

        ''' <summary>
        ''' Ruft eine komplette Kopie des Dokumentes ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Das Dokument wird jedoch nicht erneut gespeichert</remarks>
        Public Overrides Function Clone() As Object
            Dim newDocument As JournalDocument = CType(MyBase.Clone, JournalDocument)

            newDocument.ID = -1 ' ist ein neues Dokument; beim speichern wird eine neue ID vergeben
            newDocument.DocumentID = 0
            newDocument.DocumentDisplayID = String.Empty ' Dies sollte leer sein !


            'Für das Zahlungsziel die bisherige differenz berechnen und übernehmen
            Dim addedDays As Integer = CInt(DateDiff(DateInterval.Day, newDocument.PaymentTarget, newDocument.DocumentDate))

            newDocument.CreatedAt = Now ' Kopie wurde heute angelegt
            newDocument.DocumentDate = Today
            newDocument.PaymentTarget = newDocument.DocumentDate.AddDays(addedDays)
            newDocument.SourceID = Me.SourceID

            ' Geklonte Dokumente dürfen nicht im storno-Zustand bleiben
            If newDocument.IsCanceled Then newDocument.ClearCanceled()

            For Each item As JournalArticleGroup In Me.ArticleGroups
                Dim newGroup As JournalArticleGroup = CType(item.Clone, JournalArticleGroup)

                newDocument.AddArticleGroup(newGroup)

                For Each articleItem As JournalArticleItem In item.ArticleList
                    Dim newArticle As JournalArticleItem = CType(articleItem.Clone, JournalArticleItem)
                    newGroup.AddJournalItem(newArticle)
                Next
            Next

            Return newDocument
        End Function



        ''' <summary>
        ''' Zeigt die angepasste Dokumentennummer an
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(50)> _
        <ClausSoftware.Tools.DisplayName("DocumentDisplayID", "Dokumentennummer")> _
        <Persistent("DocumentDisplayID")> _
        Public Property DocumentDisplayID() As String
            Get
                If String.IsNullOrEmpty(m_displayDocumentID) Then
                    Return m_mainApplication.Languages.GetText("msgUnkownNewDocumentID", "-neu-")
                Else
                    Return m_displayDocumentID

                End If

            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DocumentDisplayID", m_displayDocumentID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Kopftext ab, in dem Platzhalter ersetzt sind.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DisplayHeaderText", "Kopftext")> _
        Public ReadOnly Property DisplayHeaderText() As String
            Get
                Return GetParsedText(HeadText)
            End Get

        End Property

        ''' <summary>
        ''' Ruft den Text ab, in dem Platzhalter ersetzt sind
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DisplayFooterrText", "Fusstext")> _
        Public ReadOnly Property DisplayFooterText() As String
            Get
                Return GetParsedText(FooterText)
            End Get
        End Property

        ''' <summary>
        ''' Ruft die Textersetzung ab
        ''' </summary>
        ''' <param name="InText"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetParsedText(ByVal InText As String) As String

            InText = InText.Replace("$RD", Me.DocumentDate.ToString("d"))
            InText = InText.Replace("$ZZ", Me.PaymentTarget.ToString("d"))
            InText = InText.Replace("$AD", Date.Today.ToString("d"))
            InText = InText.Replace("$RN", Me.DocumentDisplayID)
            InText = InText.Replace("$SB", Me.DisplayedEndPrice.ToString("c"))   '"Summe Brutto"
            InText = InText.Replace("$SN", Me.DocumentDate.ToString("d")) '"Summe Netto"
            Return InText
        End Function

        ''' <summary>
        ''' Ruft eine Auflistung aller möglichen Text-Platzhalter ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetReplacementStringsTextblocks() As Dictionary(Of String, String)
            Dim items As New Dictionary(Of String, String)

            items.Add("$RD", m_mainApplication.Languages.GetText("DocumentDate", "Datum des Dokumentes")) '
            items.Add("$ZZ", m_mainApplication.Languages.GetText("DocumentTargetPaymentDate", "Zahlungsziel des Dokumentes")) '
            items.Add("$AD", m_mainApplication.Languages.GetText("CurrentDate", "Aktuelles Datum")) '
            items.Add("$RN", m_mainApplication.Languages.GetText("DocumentNumber", "Nummer Dokumentes")) '
            items.Add("$SB", m_mainApplication.Languages.GetText("TotalWithTax", "Gesamtpreis Brutto"))
            items.Add("$SN", m_mainApplication.Languages.GetText("TotalWithoutTax", "Gesamtsumme Netto"))
            items.Add("$MWST", m_mainApplication.Languages.GetText("TotalTaxValue", "MwSt-Anteil des Gesamtpreises"))

            Return items


        End Function



        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        Public Overrides Function ToString() As String

            Dim displayText As String = String.Empty

            displayText = Me.DocumentTypeText & " Nr.: " & Me.DocumentDisplayID & ", " & Me.DocumentDate & vbCrLf & "  " & Me.AddressWindow.ToString.Replace(vbCrLf, " ") & ", " & Me.DisplayedEndPrice.ToString("c") '& vbCrLf & _
            '"" & Me.Subject & " """
            ' Im subject ist auch bereits die Adresse enthalten das ist doof, wenn diese nochmal in der Zeile auftaucht..
            Return displayText

        End Function

        ''' <summary>
        ''' Ruft einen kurzen Anzeigetext des Dokumentes ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ShortDisplaystring() As String
            Dim displayText As String = Me.DocumentTypeText & " Nr.: " & Me.DocumentDisplayID & ", " & Me.DocumentDate & vbCrLf

            Return displayText

        End Function

        Private Sub JournalDocument_Changed(ByVal sender As Object, ByVal e As DevExpress.Xpo.ObjectChangeEventArgs) Handles Me.Changed
            itemsListNeedRebuild = True
        End Sub
    End Class

    ''' <summary>
    ''' Stellt ein vereinfachtes Objekt dar, das aufsummierte Daten eines Journaldokumentes enthält
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class AcummulatedJournalItem

        Private m_itemKey As String = String.Empty

        Private m_itemCount As Decimal

        Private m_itemDisplayName As String = String.Empty

        Private m_itemTimeSpan As TimeSpan
        Private m_article As Article

        ''' <summary>
        ''' Ruft die Zeitdauer ab oder lgt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemTimeSpan() As TimeSpan
            Get
                Return m_itemTimeSpan
            End Get
            Set(ByVal value As TimeSpan)
                m_itemTimeSpan = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Anzeigetext des Artikels ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemDisplayName() As String
            Get
                Return m_itemDisplayName
            End Get
            Set(ByVal value As String)
                m_itemDisplayName = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Gesamtanzahl ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemCount() As Decimal
            Get
                Return m_itemCount
            End Get
            Set(ByVal value As Decimal)
                m_itemCount = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Schlüssel des elementes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        Public Property ItemKey() As String
            Get
                Return m_itemKey
            End Get
            Set(ByVal value As String)
                m_itemKey = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Einzel-Einkaufspreis des Artikels ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ArticleSingleBasePrice As Decimal
            Get
                If Not m_article Is Nothing Then
                    Return m_article.EinzelEK
                Else
                    Return 0D
                End If
            End Get

        End Property

        ''' <summary>
        ''' Erstellt diese Instanz und verknüpft diese mit dem angegebenen artikel
        ''' </summary>
        ''' <param name="article"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal article As Article)
            m_article = article

            If article IsNot Nothing Then ' Kann nothing sein, wenn der Ursprungsartikel bereits gelöscht wurde

                m_itemKey = article.ID & "M"
            End If

        End Sub
    End Class

    ''' <summary>
    ''' Berechnet auf Basis des Preiscontaines einen neuen Container, der die ermässigten Preise enthält
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DiscountedPriceContainer
        Private m_discountRelatice As Decimal

        Private m_priceContainer As List(Of JournalTaxValuePair)
        ''' <summary>
        ''' Aufstellung nach Abzug von Rabatt
        ''' </summary>
        ''' <remarks></remarks>
        Private m_discountedPriceContainer As List(Of JournalTaxValuePair)
        Private m_app As MainApplication
        Public Sub New(app As MainApplication)
            m_app = app
        End Sub
        ''' <summary>
        ''' Ruft eine Auflistung der verringerten Beträge ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DiscountedValues", "Rabattierte Steueranteile")> _
        Public ReadOnly Property DiscountedValues As List(Of JournalTaxValuePair)
            Get
                If m_discountedPriceContainer Is Nothing Then
                    m_discountedPriceContainer = New List(Of JournalTaxValuePair)

                    For Each priceItem As JournalTaxValuePair In m_priceContainer
                        Dim reducedIterm As New JournalTaxValuePair(m_app)
                        reducedIterm.NettoPrice = priceItem.NettoPrice * (1 - DiscountRelative / 100)
                        reducedIterm.TotalPrice = priceItem.TotalPrice * (1 - DiscountRelative / 100)
                        reducedIterm.TaxRate = priceItem.TaxRate

                        m_discountedPriceContainer.Add(reducedIterm)
                    Next

                End If

                Return m_discountedPriceContainer
            End Get
        End Property

        ''' <summary>
        ''' Enthält eine Auflistung von kummulierten Steuersätzen und netto- und brutto Preisen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("UndiscountedValues", "Unrabattierte Steueranteile")> _
        Public Property UndiscountedValues() As List(Of JournalTaxValuePair)
            Get
                Return m_priceContainer
            End Get
            Set(ByVal value As List(Of JournalTaxValuePair))
                m_priceContainer = value
                m_discountedPriceContainer = Nothing
            End Set
        End Property


        Public Property DiscountRelative() As Decimal
            Get
                Return m_discountRelatice
            End Get
            Set(ByVal value As Decimal)
                m_discountRelatice = value
            End Set
        End Property

    End Class

    Friend Class ReferenceInvoice
        Private m_ReferenceDocument As JournalDocument
        Private m_ReferenceDocumentID As Integer?

        Property ReferenceDocument As JournalDocument
            Get
                Return m_ReferenceDocument
            End Get
            Set(value As JournalDocument)
                m_ReferenceDocument = value

            End Set
        End Property

        Property ReferenceDocumentID As Integer?
            Get
                Return m_ReferenceDocumentID
            End Get
            Set(value As Integer?)
                m_ReferenceDocumentID = value
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Stellt eine Auflistung von 
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class ReferenceInvoices
        Private m_referenceInvoices As New Dictionary(Of String, ReferenceInvoice)

        Public Sub Refresh()
            m_referenceInvoices.Clear()
        End Sub

        Public ReadOnly Property ReferenceInvoicelist As Dictionary(Of String, ReferenceInvoice)
            Get
                Return m_referenceInvoices
            End Get
        End Property

    End Class

End Namespace