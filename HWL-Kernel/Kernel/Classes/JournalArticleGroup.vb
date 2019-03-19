Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports ClausSoftware.Kernel
Imports DevExpress.Xpo

Namespace Kernel

    ''' <summary>
    ''' Stellt verknüpfungen sowie Metadaten zu den Artikelgruppen bereit.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    <Persistent("Positions")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class JournalArticleGroup
        Inherits StaticItem
        Implements IDataItem
        Implements ISortableItem

        Public Const TableName As String = "Positions"

        ' ''' <summary>
        ' ''' Wird ausgelöst, wenn sich das element oder eines seiner untergeordneten Elemente ändert
        ' ''' Die Art der Änderung wird nicht übergeben
        ' ''' </summary>
        ' ''' <param name="sender"></param>
        ' ''' <param name="e"></param>
        ' ''' <remarks></remarks>
        '  Public Event CustomPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)


        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_parentDocID As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_positionNumber As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_position As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_isHiddenArticlePrices As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_neverWasAGroup As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_groupPrice As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_dokumentType As enumJournalDocumentType
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_headerText As String = String.Empty

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_summaryText As String = String.Empty

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_itemcount As Decimal

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_isHidddenArticles As Boolean

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_ParentDocument As JournalDocument

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_parentItemID As String

        ''' <summary>
        ''' Stellt die Liste der enthaltenen Artikel in dieser Auflistung dar
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_articleList As JournalArticleItems

        ''' <summary>
        ''' Stellt die Liste aller Artikel vor der Bearbeitung dar
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_orgItemList As New List(Of JournalArticleItem)

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_forPrinting As Boolean = False

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
        ''' Ruft das Geändert-Signal für alle Artikel dieser Gruppe und der Gruppe selber ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides ReadOnly Property HasChanged As Boolean
            Get
                If MyBase.HasChanged Then Return True

                For Each item As JournalArticleItem In Me.ArticleList
                    If item.HasChanged Then Return True
                Next
                Return False
            End Get
        End Property

        ''' <summary>
        ''' Löscht das Geändert - Flag für alle arunterliegenden Objekte
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub ClearHasChangedState()
            MyBase.ClearHasChangedState()

            For Each item As JournalArticleItem In Me.ArticleList
                item.ClearHasChangedState()
            Next
        End Sub

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_showWithTax As Boolean

        ''' <summary>
        ''' Ruft die eindeutige Dokumentennummer ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nicht mehr verwenden, wir haben nun eine ParentID {String(32)}")> _
        <Persistent("Nummer")> _
        Private Property ParentDocID() As Integer
            Get
                Return m_parentDocID
            End Get
            Set(ByVal value As Integer)

                ' Vor dem Ändern noch die Liste aktuelisieren
                If Not Me.IsLoading Then
                    Debug.Print(CStr(Me.ArticleList.Count))
                End If
                SetPropertyValue(Of Integer)("ParentDocID", m_parentDocID, value)


            End Set
        End Property



        ''' <summary>
        ''' Ruft den Schlüssel des übergeordneten Journaldokumentes ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ParentItemID")> _
        <Indexed()> _
        <Size(32)> _
        Private Property ParentItemID() As String
            Get
                Return m_parentItemID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ParentItemID", m_parentItemID, value)
                m_ParentDocument = Nothing
            End Set
        End Property



        ''' <summary>
        ''' Kalkulations-Preis, jenachdem, wie die einstellung "Zeige Netto-Preis" ist. 
        ''' Dieser Wert kann bearbeitet werden, Persistent ist aber immer nur der Netto-Preis
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DisplaySinglePrice", "Einzelpreis")> _
        Public Property DisplaySinglePrice() As Decimal
            Get
                If ShowWithTax Then
                    Return Me.CustomerGroupPrice + TaxRateValue
                Else
                    Return Me.CustomerGroupPrice
                End If

            End Get
            Set(ByVal value As Decimal)

                If ShowWithTax Then ' dann kommt ein Brutto-Preis rein
                    Me.CustomerGroupPrice = value - TaxRateValue
                Else
                    Me.CustomerGroupPrice = value
                End If

            End Set
        End Property

        ''' <summary>
        ''' Wenn wahr, wird das Produkt aus Anzahl und Einzelpreis mit einem gerundeten Einzelpreis berechnet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property RoundSums As Boolean
            Get
                Return m_mainApplication.Settings.ItemsSettings.ShowRoundedTaxValues
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Gesamtpreis ab oder legt diesen fest. In Abhängigheit vom eingestellten Anzeigemodus des Steuersatzes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DisplayTotalPrice", "Gesamtpreis")> _
        Public Property DisplayTotalPrice() As Decimal
            Get

                If RoundSums Then
                    Return Math.Round(Me.DisplaySinglePrice, 2) * Me.ItemCount
                Else
                    Return Me.DisplaySinglePrice * Me.ItemCount
                End If

            End Get
            Set(ByVal value As Decimal)
                Me.DisplaySinglePrice = value / Me.ItemCount
            End Set
        End Property


        ''' <summary>
        ''' Ruft den kummulierten Steuersatz dieser Gruppe ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TaxRateValue() As Decimal
            Get
                Dim taxes As Dictionary(Of Decimal, JournalTaxValuePair)
                taxes = GetTaxPriceList
                Dim taxSum As Decimal

                For Each item As JournalTaxValuePair In taxes.Values
                    taxSum += item.TaxValuePrice
                Next

                Return taxSum
            End Get

        End Property

        ''' <summary>
        ''' Wahr, wenn der Artikelpreis inklusive steueranteil angezeigt werden soll. ("Ink. MwSt"), Falsch, wenn Artikelpreis Netto-Betrag ist ("Preis plus MwSt")
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShowWithTax() As Boolean
            Get
                Return m_showWithTax
            End Get
            Set(ByVal value As Boolean)
                m_showWithTax = value
                Me.ArticleList.SetShowWithTax(value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die reihenfolge ab in der sich diese Artikelgruppe befindet oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("PositionNumber", "Position Nummer")> _
        <Persistent("Seite")> _
        Public Property PositionNumber() As Integer Implements ISortableItem.Sequence
            Get
                Return m_positionNumber
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PositionNumber", m_positionNumber, value)
            End Set
        End Property

        ''' <summary>
        ''' Immer "1" Nicht verwendet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Dient der Infrastruktur und ist immer 1")> _
        <Persistent("Position")> _
        Private Property Position() As Integer
            Get
                Return 1
            End Get
            Set(ByVal value As Integer)

            End Set
        End Property


        ''' <summary>
        ''' Zeigt an, ob einzelne Artikelpriese dieser Position dargestellt werden, da alle Artikel eine Gruppe bilden oder legt dies fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        <Tools.DisplayName("IsHiddenArticlePrices", "Artikelpreise versteckt")> _
        <Persistent("IsGrouped")> _
Public Property IsHiddenArticlePrices() As Boolean
            Get
                Return m_isHiddenArticlePrices
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsHiddenArticlePrices", m_isHiddenArticlePrices, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, ob diese Position jemals verändert worden ist; daran kann man erkennen, ob der Gruppenpreis vom Benutzer verändert wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("NeverWasAGroup")> _
        Public Property NeverWasAGroup() As Boolean
            Get
                Return m_neverWasAGroup
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("NeverWasAGroup", m_neverWasAGroup, value)
            End Set
        End Property

        ''' <summary>
        ''' Enthält einen Netto-Gruppenpreis, der vom Benutzer geändert werden kann 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("Groupprice", "Gruppenpreis (Netto)")> _
        <Persistent("GroupAmmount")> _
        Public Property CustomerGroupPrice() As Decimal
            Get
                Return m_groupPrice
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CustomerGroupPrice", m_groupPrice, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Nettopreis ab, der duch Aufsummierung der einzelnen Artikel rnittelt wird. 
        ''' Ist diese Gruppe als 'Gruppiert' markiert, so hat der Anwender einen eigenen Preis gesetzt. Die einzelpreise sollten dann ignoriert werden
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CalculateNettoTotalGroupPrice() As Decimal
            Dim priceList As Dictionary(Of Decimal, JournalTaxValuePair)
            priceList = GetTaxPriceList()
            Dim totals As Decimal
            For Each item As JournalTaxValuePair In priceList.Values
                totals += item.NettoPrice
            Next

            Return totals

        End Function

        ''' <summary>
        ''' Zeigt an, das der Gruppenpreis von der berechneten Summe der Einzelpresie abweicht
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GroupPriceDiffersFromCalculatedPrice As Boolean
            Get
                Return Me.CustomerGroupPrice <> Me.CalculateNettoTotalGroupPrice
            End Get
        End Property

        ''' <summary>
        ''' Setzt den Gruppenpreis für diese Artikelgruppe zurück
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ResetCustomGroupPrice()
            Me.CustomerGroupPrice = CalculateNettoTotalGroupPrice()
            Me.NeverWasAGroup = True
        End Sub

        ''' <summary>
        ''' Ruft den Preis ab, den eine Aufsummierung der enthalten Artikel ergiebt.
        ''' </summary>
        ''' <returns>Eine Auflistung von Nettopreisen und deren Steuersätzen</returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("TaxValuePair", "Steuersätze")> _
        Public ReadOnly Property GetTaxPriceList() As Dictionary(Of Decimal, JournalTaxValuePair)
            Get

                Dim priceList As New Dictionary(Of Decimal, JournalTaxValuePair)
                'TODO: Hier den Überschriebenen Preis holen 

                For Each item As JournalArticleItem In Me.ArticleList
                    If item.TotalPriceBeforeTax = 0 Then Continue For

                    Dim price As New JournalTaxValuePair(m_mainApplication)

                    price.NettoPrice = item.TotalPriceBeforeTax
                    price.TaxRate = item.TaxRate

                    price.TotalPrice = item.TotalPriceAfterTax

                    If Not priceList.ContainsKey(price.TaxRateValue) Then
                        priceList.Add(price.TaxRateValue, price)

                    Else
                        priceList(price.TaxRateValue).NettoPrice += price.NettoPrice
                        priceList(price.TaxRateValue).TotalPrice += price.TotalPrice
                    End If
                Next


                Return priceList
            End Get
        End Property


        ''' <summary>
        ''' Ruft die Art des Vater-Dokumentes ab (Rechnung / Angebot usw), damit wird diese Position eindeutig einem Artikel zugewiesen, darf später nicht mehr geändert werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nicht mehr verwenden, wir haben nun eine ParentID {String(32)}")> _
        <Persistent("Status")> _
        Private Property DocumentType() As enumJournalDocumentType
            Get
                Return m_dokumentType
            End Get
            Set(ByVal value As enumJournalDocumentType)
                If Not Me.IsLoading Then
                    Debug.Print(CStr(Me.ArticleList.Count))
                End If
                SetPropertyValue(Of enumJournalDocumentType)("DocumentType", m_dokumentType, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Bezeichnung dieser Gruppe ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("HeaderText", "Bezeichnung")> _
        <Persistent("Name")> _
        Public Property HeaderText() As String
            Get
                Return m_headerText
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HeaderText", m_headerText, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Zusammenfassungstext unterhalb der Gruppe ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("SummaryText", "Zusammenfassungstext")> _
        <Persistent("SummaryText")> _
        <Size(250)> _
        Public Property SummaryText() As String
            Get
                Return m_summaryText
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SummaryText", m_summaryText, value)
            End Set
        End Property

        

        ''' <summary>
        ''' Ruft den Faktor ab, mit dem alle Artikel der Position multipliziert werden. 
        ''' Alle Artikel werden x-mal in der Berechnung mit eingezogen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ItemCount", "Anzahl")> _
        <Persistent("Anzahl")> _
        Public Property ItemCount() As Decimal
            Get
                Return m_itemcount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ItemCount", m_itemcount, value)
            End Set
        End Property

        ''' <summary>
        '''Positionen mit versteckten Artikel zeigen diese nicht an, es wird aber der Positions-Gesamtpreis angegeben.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        <ClausSoftware.Tools.DisplayName("IsHidddenArticles", "Artikel versteckt")> _
        <Persistent("IsHidden")> _
        Public Property IsHidddenArticles() As Boolean
            Get
                Return m_isHidddenArticles
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsHidddenArticles", m_isHidddenArticles, value)
            End Set
        End Property



        ''' <summary>
        ''' Fügt der Auflistung ein weiteren JournalItem Artikel hinzu.
        ''' </summary>
        ''' <param name="article"></param>
        ''' <remarks></remarks>
        Public Sub AddArticleItem(ByVal article As Article)
            Dim newJournalItem As New JournalArticleItem(MainApplication.Session)

            newJournalItem.SetByArticle(article)
            newJournalItem.ShowWithTax = Me.ShowWithTax
            Me.AddJournalItem(newJournalItem)

        End Sub

        ''' <summary>
        ''' Fügt der Auflistung ein neues Journalatrikel hinzu
        ''' </summary>
        ''' <param name="journalItem"></param>
        ''' <remarks></remarks>
        Public Sub AddJournalItem(ByVal journalItem As JournalArticleItem)

            journalItem.ParentArticleGroup = Me
            journalItem.ShowWithTax = Me.ShowWithTax
            ArticleList.Add(journalItem)
            AddHandler journalItem.Changed, AddressOf CustomItemChanged

        End Sub

        ''' <summary>
        ''' Erstellt ein neues Journalartikelelement mit dieser Gruppe als Basis
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNewItem() As JournalArticleItem
            Dim newItem As New JournalArticleItem(Me.Session)
            newItem.ParentArticleGroup = Me
            Me.AddJournalItem(newItem)
            Return newItem
        End Function

        ''' <summary>
        ''' Entfernt ein JournalArtikelItem aus der Auflistung wieder
        ''' </summary>
        ''' <param name="item"></param>
        ''' <remarks></remarks>
        Public Sub RemoveItem(ByVal item As JournalArticleItem)
            Me.ArticleList.Remove(item)
            RemoveHandler item.Changed, AddressOf CustomItemChanged

        End Sub

        ''' <summary>
        ''' Speichert diese Gruppe, sowie alle enthaltenen Artikel ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()

            MyBase.Save() ' diese Gruppe auch sichern

            ' Alle bestehenden Artikel in der Auflistung speichern
            For n As Integer = 0 To Me.ArticleList.Count - 1
                Dim item As JournalArticleItem = Me.ArticleList(n)

                item.ParentArticleGroup = Me
                item.Save()
            Next

            ' Nun mit der Ursprünglichen Liste vergleichen und die überzähligen Artikel löschen
            For Each item As JournalArticleItem In m_orgItemList
                If Not Me.ArticleList.ContainsKey(item.Key) Then
                    Try
                        item.Delete()
                    Catch ex As Exception
                        Debug.Print("Fehler beim löschen eines Artikel: " & ex.Message)
                    End Try

                End If
            Next

            'Listen wieder herstellen
            m_orgItemList.Clear()
            m_orgItemList.AddRange(Me.ArticleList)

        End Sub


        ''' <summary>
        ''' Ruft das übergeordnete Journaldokument ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParentDocument() As JournalDocument
            Get
                If m_ParentDocument Is Nothing Then

                    If String.IsNullOrEmpty(Me.ParentItemID) Then Return Nothing

                    Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("ReplikID='" & Me.ParentItemID & "'")
                    Dim posItems As JournalDocuments = New JournalDocuments(MainApplication, criteria)
                    If posItems.Count = 1 Then
                        m_ParentDocument = posItems(0)
                    Else
                        Return Nothing
                    End If
                End If

                Return m_ParentDocument
            End Get
            Set(ByVal value As JournalDocument)

                Me.ParentItemID = value.Key
                m_ParentDocument = value

            End Set
        End Property



        ''' <summary>
        ''' Gibt die Items einer Position in aufsteigender Reihenfolge wieder zurück. Liest direkt aus der Datenbank wenn die Liste noch leer ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(True)> _
        <ClausSoftware.Tools.DisplayName("ArticleList", "Artikelliste")> _
        Public ReadOnly Property ArticleList() As JournalArticleItems
            Get
                If m_articleList Is Nothing Then

                    Dim criteria As DevExpress.Data.Filtering.CriteriaOperator

                    criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("ParentItemID='" & Me.ReplikID & "'")

                    m_articleList = New JournalArticleItems(MainApplication, criteria)
                    ' In HWL-1 gespeicherte artikel haben kein ParentItem

                    'Jeden Artikel überwachen
                    For Each item As JournalArticleItem In m_articleList
                        RemoveHandler item.Changed, AddressOf CustomItemChanged
                        AddHandler item.Changed, AddressOf CustomItemChanged
                    Next

                    m_articleList.ParentGroup = Me ' der gesamten Gruppenauflistung die Herkunft mitteilen 

                    m_orgItemList.Clear()
                    m_orgItemList.AddRange(m_articleList)
                    AddHandler m_articleList.CollectionChanged, AddressOf CustomItemChanged ' auflistung hat sich geändert => Weiterleiten
                End If

                Return m_articleList
            End Get

        End Property

        ''' <summary>
        ''' Überwacht die Auflistung der Artikel und sendet neue Ereignisse, wenn sich ein Artikel oder die Artikelauflistung ändert
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub CustomItemChanged(ByVal sender As Object, ByVal e As EventArgs)

            ' Preise neu aufbauen !            
            If Not IsHiddenArticlePrices Then
                ' Netto.Artikelpreis neu abholen
                Me.CustomerGroupPrice = CalculateNettoTotalGroupPrice()
            Else
                ' Na , schlecht.. der Gruppenpreis soll nach Kundenwunsch konstant bleiben... 
            End If
            ' Hat sich die Auflistung geänbdert? 
            If TypeOf e Is XPCollectionChangedEventArgs Then
                Dim xpcollection As XPCollectionChangedEventArgs = CType(e, XPCollectionChangedEventArgs)
                If xpcollection.CollectionChangedType = XPCollectionChangedType.AfterAdd Then

                    Dim item As JournalArticleItem = CType(xpcollection.ChangedObject, JournalArticleItem)
                    AddHandler item.Changed, AddressOf Me.CustomItemChanged ' Das ändern der Gruppen-Auflistung überwachen

                End If

                ' Das entfernen ebenfalls überwachen
                If xpcollection.CollectionChangedType = XPCollectionChangedType.AfterRemove Then

                    Dim item As JournalArticleItem = CType(xpcollection.ChangedObject, JournalArticleItem)
                    RemoveHandler item.Changed, AddressOf Me.CustomItemChanged ' Das ändern der Gruppen-Auflistung überwachen

                End If
            End If

            'Das Ereignis weiterleiten
            'RaiseEvent CustomPropertyChanged(Me, EventArgs.Empty)

        End Sub

        ''' <summary>
        ''' Alle 'änderungs-ereignisse' behandeln und gesondert weiterleiten
        ''' </summary>
        ''' <param name="propertyName"></param>
        ''' <param name="oldValue"></param>
        ''' <param name="newValue"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnChanged(ByVal propertyName As String, ByVal oldValue As Object, ByVal newValue As Object)
            MyBase.OnChanged(propertyName, oldValue, newValue)

            CustomItemChanged(Me, EventArgs.Empty) ' Auch einzeln weiterleiten
        End Sub
        ''' <summary>
        ''' Erstellt im angegebenen Journaleintrag eine neue Artikelgruppe
        ''' Diese wird am ende vorhanderer Positionen eingefügt
        ''' </summary>
        ''' <param name="baseJournalDocument"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal baseJournalDocument As JournalDocument)

            ' hat das angegebene Journal bereits Positionen ? 
            MyBase.New(m_mainApplication.Session)

            SetDefaultValues(baseJournalDocument)

            baseJournalDocument.ArticleGroups.Add(Me) ' ZUm Dokument hinzufügen

        End Sub

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        ''' <summary>
        ''' Löscht diese Position aus der Datenbank und alle darin enthaltenen Artikel
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Delete()

            ArticleList.Delete()


            MyBase.Delete()
        End Sub

        ''' <summary>
        ''' Setzt Standardwerte für diese Artikelgruppe
        ''' </summary>
        ''' <param name="baseJournalDocument"></param>
        ''' <remarks></remarks>
        Sub SetDefaultValues(ByVal baseJournalDocument As JournalDocument)
            Me.ItemCount = 1
            Me.ParentDocument = baseJournalDocument
            Me.IsHiddenArticlePrices = False
            Me.IsHidddenArticles = False

            Me.SummaryText = MainApplication.Settings.ItemsSettings.DefaultItemsGroupSummary
            Me.HeaderText = MainApplication.Settings.ItemsSettings.DefaultItemsGroupHeadline

            Me.PositionNumber = baseJournalDocument.ArticleGroups.Count + 1  ' die neue Position wird nach der bestehenden eingeordnet
            Me.HeaderText = GetDefaultGroupHeaderText()

        End Sub

        ''' <summary>
        ''' Ruft den standard-Text ab, der für eine Artikelgruppe vorgesehen ist.
        ''' Löst den Platzhalter "$NR" auf und weist die aktuelle Nummer zu
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDefaultGroupHeaderText() As String
            ' Platzhalter: $Nr = Aktuell laufende Nummer; = Anzahl der Artikelgrzppen

            Dim defaultText As String = MainApplication.Settings.ItemsSettings.DefaultItemsGroupHeadline
            If Me.PositionNumber > 1 Then
                defaultText = defaultText & " " & CStr(Me.PositionNumber)
            End If

            Return defaultText
        End Function


    End Class


    ''' <summary>
    ''' Stellt eine Abstraktion der Klasse "ArtikelGruppe" dar
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class JournalArticleGroupProxy

        Private m_articleItems As New List(Of JournalArticelItemProxy)

        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_itemCount As Decimal
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_itemText As String
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_userPrice As Decimal

        ''' <summary>
        ''' Enthält den Preis der Gruppe, der abweichend ist von der Summe der Einzelpreise
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GroupPrice() As Decimal
            Get
                Return m_userPrice
            End Get
            Set(ByVal value As Decimal)
                m_userPrice = value
            End Set
        End Property

        ''' <summary>
        ''' Anzeigetext dieser Gruppe (Gruppenüberschrift)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemText() As String
            Get
                Return m_itemText
            End Get
            Set(ByVal value As String)
                m_itemText = value
            End Set
        End Property

        ''' <summary>
        ''' Multiplikator der Elemente in dieser Aufliustung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Itemcount() As Decimal
            Get
                Return m_itemCount
            End Get
            Set(ByVal value As Decimal)
                m_itemCount = value
            End Set
        End Property

        ''' <summary>
        ''' Stellt die Liste aller in dieser Gruppe enthaltenen Artikel dar
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ArticleItems() As List(Of JournalArticelItemProxy)
            Get
                Return m_articleItems
            End Get

        End Property
        Public Sub New()

        End Sub

        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse un legt die Liste der enthalten Artikel an
        ''' </summary>
        ''' <param name="group"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal group As JournalArticleGroup)
            Me.GroupPrice = group.CustomerGroupPrice
            Me.ItemText = group.HeaderText
            Me.Itemcount = group.ItemCount

            For Each item As JournalArticleItem In group.ArticleList
                ArticleItems.Add(New JournalArticelItemProxy(item))
            Next

        End Sub
    End Class

End Namespace