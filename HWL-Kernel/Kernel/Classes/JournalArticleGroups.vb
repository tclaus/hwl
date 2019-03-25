Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo

Namespace Kernel


    ''' <summary>
    ''' Stellt eine Liste von Artikelgruppen dar.
    ''' Positionen verknüpfen Dokumenete und Artikel in Positionsgruppen zusammen.
    ''' </summary>
    ''' <remarks>Eine Position stellt eine Gruppe von Artikel dar.</remarks>
    Public Class JournalArticleGroups
        Inherits BaseCollection(Of JournalArticleGroup)
        Implements IDataCollection

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)
            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator)

            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

        Private m_parentDocument As JournalDocument
        ''' <summary>
        ''' Ruft das Vater-Dokuement auf, sofern diese Liste homogn ist und einem einzigen Vater gehört
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParentDocument() As JournalDocument
            Get
                Return m_parentDocument
            End Get
            Set(ByVal value As JournalDocument)
                m_parentDocument = value
            End Set
        End Property


        ''' <summary>
        ''' Erstellt eine neue Auflistung und filtert eine Liste aller Gruppen die ind er Datenbank vorhanden sind
        ''' </summary>
        ''' <param name="parentDocument"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal parentDocument As JournalDocument)
            MyBase.New(parentDocument.MainApplication)

            If parentDocument Is Nothing Then Throw New ArgumentException("Parameter Journaldocument war nothing")
            Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("ParentItemID='" & parentDocument.ReplikID & "'")
            Me.Criteria = criteria

            Me.ParentDocument = parentDocument

            Me.Initialize()
        End Sub

        ''' <summary>
        ''' Ruft die Liste der Preise aller innerhalb der Gruppe vorkommenem Artikel ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPrices() As Dictionary(Of Decimal, JournalTaxValuePair)
            Dim priceList As New Dictionary(Of Decimal, JournalTaxValuePair)

            For Each item As JournalArticleGroup In Me
                For Each itemPrice As JournalTaxValuePair In item.GetTaxPriceList.Values

                    If Not priceList.ContainsKey(itemPrice.TaxRateValue) Then
                        priceList.Add(itemPrice.TaxRateValue, itemPrice)
                        priceList(itemPrice.TaxRateValue).NettoPrice *= item.ItemCount
                        priceList(itemPrice.TaxRateValue).TotalPrice *= item.ItemCount

                    Else
                        priceList(itemPrice.TaxRateValue).NettoPrice += item.ItemCount * itemPrice.NettoPrice
                        priceList(itemPrice.TaxRateValue).TotalPrice += item.ItemCount * itemPrice.TotalPrice

                    End If


                Next
            Next
            Return priceList

        End Function

        ''' <summary>
        ''' setzt für alle darunterliegenden Artikel den Ansichtsmodus des Steuersatzes
        ''' </summary>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Sub SetShowWithTax(ByVal value As Boolean)
            For Each item As JournalArticleGroup In Me
                item.ShowWithTax = value
            Next
        End Sub

        Public Overrides Function GetNewItem() As JournalArticleGroup
            Dim newItem As JournalArticleGroup = MyBase.GetNewItem()

            newItem.ParentDocument = ParentDocument
            Return newItem
        End Function


        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder
            'DisplayProps.Append("Seite;")
            DisplayProps.Append("ItemCount;")
            DisplayProps.Append("HeaderText;")
            DisplayProps.Append("CustomerGroupPrice;")
            DisplayProps.Append("ArticleList;")
            DisplayProps.Append("IsHidddenArticles;")  ' Kennzeichnet Gruppen, dessen Artikel versteckt sind
            DisplayProps.Append("IsHiddenArticlePrices;")  ' Kennzeichnet Gruppen, dessen Artikel-Preise versteckt sind

            DisplayProps.Append("PrintAsDeliveryNote;")  ' Als LIeferschein drucken; dann sollte im Druck-Layout die Preise ausgeblendet werden

            Me.DisplayableProperties = DisplayProps.ToString

            Dim sortCollection As DevExpress.Xpo.SortingCollection = New DevExpress.Xpo.SortingCollection()
            sortCollection.Add(New SortProperty("PositionNumber", DevExpress.Xpo.DB.SortingDirection.Ascending))
            Me.Sorting = sortCollection

        End Sub

    End Class
End Namespace