Option Explicit On
Option Strict On
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering

Namespace Kernel

    Public Class JournalDocuments
        Inherits BaseCollection(Of JournalDocument)
        Implements IDataCollection

        Private m_Invoices As JournalDocuments
        Private m_offers As JournalDocuments


        Private m_journaldisplayTypes As JournalDocumentTypes

        ''' <summary>
        ''' Erstellt eine zusammengefasstes Dokument, das die angegebene Dokumenten-Liste als Verweis darstellt
        ''' </summary>
        ''' <param name="documentsList">Eine einheitliche Liste von Dokumente, die zusammengefasst werden sollen, Adresse und Typ müssen gleich sein</param>
        ''' <param name="targetType">Der Ausgabetyp des Dokumentes</param>
        ''' <returns></returns>
        ''' <remarks>Alle dokumente müssen vom selben Typ sein
        ''' Alle Dokumente müssen vom selben Adressaten sein
        ''' Dokumente dürfen nicht bereits in einer sammelrechnung enthalten sein.
        ''' Das neue Dokumnet ist noch nicht gespeichert worden, wurde aber der Auflistung hinzugefügt</remarks>
        Public Function CreateSummarizedDocument(documentsList As List(Of JournalDocument), targetType As JournalDocumentType) As JournalDocument

            Dim lastTypeID As Integer?
            Dim lastContactID As Integer?

            If documentsList.Count = 0 Then Return Nothing


            For Each item As JournalDocument In documentsList
                ' Typen prüfen
                If Not lastTypeID.HasValue Then
                    lastTypeID = item.DocumentType
                Else
                    If lastTypeID <> item.DocumentType Then

                        Debug.Print("Kein einheitlicher Dokumenten Typ in der Auflistung!")
                        Throw New NotEqualDocumentTypesException
                        Return Nothing
                    End If
                End If

                ' Adressen prüfen
                If item.Address IsNot Nothing Then
                    If Not lastContactID.HasValue Then
                        lastContactID = item.Address.ID
                    Else

                        If lastContactID <> item.Address.ID Then
                            'TODO: es sollte zu erkennen sein warum das nicht geht
                            Debug.Print("Keine einheitliche Adresse in der Auflistung!")
                            Throw New NotEqualAddressesException()
                            'Return Nothing
                        End If

                    End If
                End If

                If item.HasInvoiceReference Then
                    Debug.Print("Das Dokument besitzt bereits einen Sammelrechnungs-Verweis")
                    Throw New DocumentHasAlreadyASummaryInvoice(item)
                End If

            Next


            ' Neues Dokument anlegen mit einer Gruppe
            Dim newDocument As JournalDocument = Me.GetNewItem
            newDocument.DocumentType = CType(targetType.InternalID, enumJournalDocumentType)

            newDocument.ArticleGroups.Add(newDocument.ArticleGroups.GetNewItem)
            newDocument.ArticleGroups(0).ParentDocument = newDocument
            newDocument.ArticleGroups(0).ItemCount = 1

            ' OK.. 
            newDocument.Address = documentsList(0).Address
            newDocument.AddressWindow = documentsList(0).AddressWindow

            For Each sourceDocument As JournalDocument In documentsList


                ' TODo: Die Anhang - Verweise zusammenführen

                ' Memo-Texte zusammenführen
                If Not String.IsNullOrEmpty(sourceDocument.MemoText) Then
                    newDocument.MemoText &= sourceDocument.DocumentDisplayID & ":  " & sourceDocument.MemoText & vbCrLf
                End If



                For Each priceItem As JournalTaxValuePair In sourceDocument.CalculatedPriceContainer

                    ' Neuen Eintrag anlegen lassen
                    Dim newInvoiceLink As JournalArticleItem = newDocument.ArticleGroups(0).ArticleList.GetNewItem

                    With newInvoiceLink
                        .ItemCount = 1
                        .ItemName = Me.DocumentTypeNames.GetByDocumentID(sourceDocument.DocumentType).Name & ", Nr. " & sourceDocument.DocumentDisplayID & "  (" & sourceDocument.DocumentDate.ToString("d") & ")"
                        .OrgItemID = sourceDocument.ID & "I" ' InvoiceLink ? 
                        .TimeInMinutes = CInt(sourceDocument.TotalDuration.TotalMinutes)

                        'TODO: wo kommt der Steuersatz her ? 

                        .TaxRate = priceItem.TaxRate
                        .SinglePriceBeforeTax = priceItem.NettoPrice

                    End With

                    newDocument.ArticleGroups(0).ArticleList.Add(newInvoiceLink)
                Next
            Next

            Return newDocument

        End Function

        ''' <summary>
        ''' Ruft eine neue Liste von Journaldokumentn ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function GetNewCollection() As JournalDocuments
            Return New JournalDocuments(MainApplication)
        End Function

        ''' <summary>
        ''' Ruft eine Auflistung von Journaldokumenttypen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DocumentTypeNames() As JournalDocumentTypes
            Get
                If m_journaldisplayTypes Is Nothing Then
                    m_journaldisplayTypes = New JournalDocumentTypes(MainApplication)
                    m_journaldisplayTypes.Load()
                End If
                Return m_journaldisplayTypes
            End Get
        End Property


        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As CriteriaOperator)

            MyBase.New(BasisApplikation, criteria)

            Initialize()
        End Sub

        Private m_DocumentsListType As enumJournalDocumentType


        Public Overrides Function GetMaxID() As Integer
            Return GetMaxID(m_DocumentsListType)
        End Function


        ''' <summary>
        ''' Ruft die höchste Dokumentennummer ab (unformatiert)
        ''' </summary>
        ''' <param name="documentsListType">Der zu suchende Dokumententyp</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function GetMaxID(ByVal documentsListType As enumJournalDocumentType) As Integer
            Dim result As Integer = 0
            Try
                Dim sql As String

                sql = "select max(lfndnummer) from JournalListe where Status=" & documentsListType

                Dim resultobj As Object = MainApplication.Database.ExcecuteScalar(sql)
                If TypeOf resultobj Is DBNull Then Return 0

                result = CInt(resultobj)
            Catch ex As Exception
            End Try
            Return result

        End Function


        ''' <summary>
        ''' Ruft ein Jorunaldokument anhand der gegebenen Quell-ID ab
        ''' </summary>
        ''' <param name="sourceID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDocumentsBySourceID(ByVal sourceID As String) As JournalDocument


            Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator("SourceID", sourceID, DevExpress.Data.Filtering.BinaryOperatorType.Equal)

            Dim journaldoc As New JournalDocuments(MainApplication, criteria)
            If journaldoc.Count > 0 Then
                Return journaldoc(0)
            Else
                Return Nothing
            End If

        End Function


        ''' <summary>
        ''' Legt zu jedem Eintrag in dieser Auflistung das Forderungen (Transaction) - Dokument an oder aktualisiert dieses.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CreateTransactionEntries()
            For Each item As JournalDocument In Me
                item.CreateTransactionEntry()
            Next
        End Sub

        ''' <summary>
        ''' Ruft ein neues Journaldokument vom angegebenen Type ab
        ''' </summary>
        ''' <param name="docType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function GetNewItem(ByVal docType As enumJournalDocumentType) As JournalDocument
            Dim newDocument As JournalDocument = Me.GetNewItem()
            newDocument.DocumentType = docType
            newDocument.DocumentDate = Today
            newDocument.ChangedAt = Now

            newDocument.ShowWithoutTax = MainApplication.Settings.ItemsSettings.ShowWithoutTax

            Return newDocument
        End Function

        ''' <summary>
        ''' Ruft ein neues Journaldokument ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As JournalDocument
            Dim newDocument As JournalDocument = MyBase.GetNewItem()
            newDocument.DocumentDate = Today
            newDocument.CreatedAt = Today
            newDocument.CreatedBy = MainApplication.CurrentUser

            Return newDocument
        End Function


        ''' <summary>
        ''' 'Initialisiert die Journaldokumente
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize() Implements IDataCollection.Initialize

            If DocumentTypeNames Is Nothing Then
                ' Läd die Dokumenten-Typen einmal ein 
            End If

            Dim DisplayProps As New Text.StringBuilder

            DisplayProps.Append("HasAttachment;")
            DisplayProps.Append("DocumentDisplayID;")
            DisplayProps.Append("Datum;")
            DisplayProps.Append("Checked;")
            DisplayProps.Append("DocumentTypeText;")
            DisplayProps.Append("Address.ContactDisplayID;")
            DisplayProps.Append("AddressWindow;")
            DisplayProps.Append("Subject;") ' Kombination aus JournalTitel und Kopftext, falls Titel nicht vergeben
            DisplayProps.Append("DisplayFooterText;")
            DisplayProps.Append("DisplayHeaderText;")
            DisplayProps.Append("DisplayedEndPrice;")
            DisplayProps.Append("TotalDuration;")
            DisplayProps.Append("DisplayTaxValueText;")
            DisplayProps.Append("IsCanceled;")
            DisplayProps.Append("CanceledAt;")


            Me.DisplayableProperties = DisplayProps.ToString

            Me.FullTextSearchColumns = New String() {"DocumentDisplayID", "AddressWindow", "Subject"}

        End Sub




        ''' <summary>
        ''' Ruft eine Auflistung aller Angebote ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Offers As JournalDocuments
            Get
                If m_offers Is Nothing Then
                    Dim cr As CriteriaOperator = New BinaryOperator("Status", enumJournalDocumentType.Angebot, BinaryOperatorType.Equal)
                    m_offers = New JournalDocuments(MainApplication, CriteriaString)
                    m_offers.m_DocumentsListType = enumJournalDocumentType.Angebot
                End If
                Return m_offers
            End Get
        End Property
        ''' <summary>
        ''' Ruft eine Auflistung aller Rechnungen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Invoices As JournalDocuments
            Get
                If m_Invoices Is Nothing Then
                    Dim cr As CriteriaOperator = New BinaryOperator("Status", enumJournalDocumentType.Rechnung, BinaryOperatorType.Equal)
                    m_Invoices = New JournalDocuments(MainApplication, CriteriaString)
                    m_Invoices.m_DocumentsListType = enumJournalDocumentType.Rechnung
                End If
                Return m_Invoices
            End Get
        End Property

        ''' <summary>
        ''' Ruft eine neue Auflistung der Journaldokumente mitz dem angegebenen Kriterium ab
        ''' </summary>
        ''' <param name="criteria">Das Kriterium, das benutzt werden soll</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function GetNewCollection(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator) As JournalDocuments
            Dim newJournalList As New JournalDocuments(MainApplication, criteria)
            Return newJournalList
        End Function

    End Class

    ''' <summary>
    ''' Stellt eine Ausnahme dar, die in einer Auflistung von Dokumenten ungleiche Typen markiert
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NotEqualDocumentTypesException
        Inherits Exception

    End Class

    ''' <summary>
    ''' Stellt eine Ausnahme dar, die ungleiche Adressen in einer Auflistung markiert
    ''' </summary>
    ''' <remarks></remarks>
    Public Class NotEqualAddressesException
        Inherits Exception

    End Class

    ''' <summary>
    ''' Markiert den Versuch, ein Dokument in einer Sammelrechnung zu überführen, zu der bereits eine Sammelrechnung existiert
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DocumentHasAlreadyASummaryInvoice
        Inherits Exception

        Private m_document As JournalDocument

        Public Sub New(message As String)
            MyBase.New(message)

        End Sub

        ''' <summary>
        ''' erstellt eine neue Instanz und übergibt das Dokument, das bereits ein sammelrechnungseintrag besitzt
        ''' </summary>
        ''' <param name="sourceDocument"></param>
        ''' <remarks></remarks>
        Public Sub New(sourceDocument As JournalDocument)
            MyBase.New()
            m_document = sourceDocument
        End Sub


        ''' <summary>
        ''' Ruft das angegebene dokument ab, das bereits ein Sammelrechnungs-Eintrag besitzt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Document() As JournalDocument
            Get
                Return m_document
            End Get
        End Property


    End Class
End Namespace