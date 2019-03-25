Imports DevExpress.Xpo.DB
Imports ClausSoftware.Data

Namespace Kernel

    Public Class JournalArticleItems
        Inherits BaseCollection(Of JournalArticleItem)
        Implements IDataCollection

        Private m_parentView As JournalArticleGroup

        ''' <summary>
        ''' Ruft das übergeordnete ParentGroup ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParentGroup() As JournalArticleGroup
            Get
                Return m_parentView
            End Get
            Set(ByVal value As JournalArticleGroup)
                m_parentView = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft ein neues JournalItem ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As JournalArticleItem
            Dim newItem As JournalArticleItem = MyBase.GetNewItem()

            newItem.Sequence = 1
            newItem.ItemUnitText = ""
            Return newItem

        End Function
        ''' <summary>
        ''' Erstellgt eine neue Instanz der Klasse, das alle Elememt enthält
        ''' </summary>
        ''' <param name="BasisApplikation"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal BasisApplikation As MainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        ''' <summary>
        ''' setzt für alle darunterliegenden Artikel den Ansichtsmodus des Steuersatzes
        ''' </summary>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Sub SetShowWithTax(ByVal value As Boolean)
            For Each item As JournalArticleItem In Me
                item.ShowWithTax = value
            Next
        End Sub

        ''' <summary>
        ''' erstellt eine neue Instanz der Klasse mit dem angegebenen Kriterianausdruck
        ''' </summary>
        ''' <param name="BasisApplikation"></param>
        ''' <param name="criteria"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)

            Initialize()
        End Sub

        Public Sub New(ByVal parentJournalPosition As JournalArticleGroup)
            MyBase.New(Data.BaseCollection(Of JournalArticleGroup).MainApplication)
            Initialize()
            Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("ParentItemID='" & parentJournalPosition.ReplikID & "'")
            Me.Criteria = criteria


        End Sub


        ''' <summary>
        ''' Initialisiert die Anzeigeattribute
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize() Implements IDataCollection.Initialize

            Dim DisplayProps As New Text.StringBuilder
            DisplayProps.Append("Sequence;")
            DisplayProps.Append("ItemCount;")
            DisplayProps.Append("ItemName;")
            DisplayProps.Append("ItemMemoText;")
            DisplayProps.Append("RTFItemMemoText;") ' neu: formatierter Memeo Text

            DisplayProps.Append("TimeInMinutes;")
            DisplayProps.Append("ItemUnit;")
            DisplayProps.Append("BasePrice;")
            DisplayProps.Append("ItemSinglePurchasePrice;")

            DisplayProps.Append("SinglePriceAfterTax;") ' Einzelpreis ink Steuern
            DisplayProps.Append("SinglePriceBeforeTax;") ' Einzelpreis exk Steuern
            DisplayProps.Append("TotalPriceBeforeTax;")
            DisplayProps.Append("TotalPriceAfterTax;")
            DisplayProps.Append("TaxRateValue;")
            DisplayProps.Append("DiscountValue;")
            DisplayProps.Append("ExternalItemNumber;")
            DisplayProps.Append("InternalItemNumber;")
            DisplayProps.Append("DisplaySinglePrice;")
            DisplayProps.Append("DisplayTotalPrice;")
            DisplayProps.Append("ItemThumbnailPicture;")
            DisplayProps.Append("IsText;")


            Me.DisplayableProperties = DisplayProps.ToString

            Me.Sorting.Clear()
            Me.Sorting.Add(New SortProperty("Sequence", SortingDirection.Ascending))

        End Sub

        ''' <summary>
        ''' Ruft die höchste Positionsnummer in dieser Auflistung ab. 
        ''' Geht die gesamte Auflistung durch und ermittelt die höchste Nummer.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetMaxPositionNumber() As Integer

            Dim maxID As Integer = 0

            For Each item As JournalArticleItem In Me
                maxID = System.Math.Max(maxID, item.Sequence)
            Next
            Return maxID
        End Function

    End Class
End Namespace