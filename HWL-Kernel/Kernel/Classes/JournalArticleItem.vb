Option Explicit On
Option Strict On

Imports ClausSoftware.Data

Namespace Kernel
    ''' <summary>
    ''' Stellt einen Eintrag eines Dokumenten / Angebots-Dokuments bereit
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    <Persistent(JournalArticleItem.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    <DebuggerDisplay("ID = {ID}, Name = {m_Name}")> _
    Public Class JournalArticleItem
        Inherits StaticItem
        Implements IDataItem
        Implements ISortableItem

        Public Const TableName As String = "Items"

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_forPrinting As Boolean = False

        ''' <summary>
        ''' Enthält eine verkleinerte Ansicht des Artikelbildes
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_itemThumbnailPicture As Drawing.Image

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_Name As String = String.Empty
        ''' <summary>
        ''' enthält den unformatierten Langtext des Artikels
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
Private m_itemMemoText As String = String.Empty
        ''' <summary>
        ''' enthält den Formaterten Langtext des Artikeles
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_rtfItemMemoText As String = String.Empty

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_basePrice As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_unitID As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_timeInMinute As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_Stundensatz As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_salesPriceBeforeTax As Decimal

        ''' <summary>
        ''' Stellt die LfndNUmmer aus HWL1.7 da, aus KOmpatibilität noch enthalten.
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_parentDocID As Integer

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_positionID As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_itemCount As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_IstText As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_isItem As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_IstArbeit As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_OrgItemID As String = "T"
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_sequence As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_unitText As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_documentType As enumJournalDocumentType
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_isGrouped As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_Rabatt As Decimal
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_usediscount As Boolean
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_manufactorsAddressIDID As Integer
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_externalItemNumber As String = String.Empty
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_InterneArtikelnummer As String = String.Empty

        ''' <summary>
        ''' Enthält die Eigenschaft, ob Artikelpreise im Ausdruck rein als Netto oder als Brutto Werte angezeigt werden sollen
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_showWithTax As Boolean

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_taxRateValue As Decimal

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_taxRateID As Integer

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_showPicture As Boolean

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_itemPicture As Drawing.Image

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_parentItemID As String

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_parentItem As JournalArticleGroup

        ''' <summary>
        ''' Stellt ein Eintrag als Druck-Dokument zur Verfügung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>In HWL 1.x wurden Dokumente zum druck immer erst in der Datenbank gesichert. Ist ab 2.x nicht mehr nötig</remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)> _
        <Obsolete("Nicht mehr verwenden, ist nur aus kompatibilität noch enthalten")> _
        <Persistent("ForPrinting")> _
        Private Property ForPrinting() As Boolean
            Get

                Return m_forPrinting
            End Get
            Set(ByVal value As Boolean)
                m_forPrinting = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft ein Artikelbild ab oder legt dies fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ItemPicture", "Artikelbild")> _
        <ValueConverter(GetType(DevExpress.Xpo.Metadata.ImageValueConverter))> _
        <Persistent("ItemPicture")> _
        Public Property ItemPicture() As Drawing.Image
            Get
                Return m_itemPicture
            End Get
            Set(ByVal value As Drawing.Image)

                SetPropertyValue(Of System.Drawing.Image)("ItemPicture", m_itemPicture, value)
                m_itemThumbnailPicture = Nothing
            End Set
        End Property


        ''' <summary>
        ''' Ruft eine verkleinerte Anwsicht des Artikelbildes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("ItemThumbnailPicture", "Thumbnail")> _
        Public ReadOnly Property ItemThumbnailPicture As Drawing.Image
            Get
                If m_itemThumbnailPicture Is Nothing Then
                    If m_itemPicture IsNot Nothing Then
                        m_itemThumbnailPicture = m_itemPicture.GetThumbnailImage(160, 160, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbAbort), System.IntPtr.Zero)
                    End If
                End If
                Return m_itemThumbnailPicture
            End Get
        End Property

        Private Function ThumbAbort() As Boolean
            Debug.Print("Aborting Thumbnails?")
            Return False
        End Function


        ''' <summary>
        ''' Falls der Eintrag ein Bild enthält, zeigt diese Eigenschaft an, ob dieses dargestellt wird oder nicht
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ShowPicture")> _
        <ComponentModel.DefaultValue(False)> _
        Public Property ShowItemPicture() As Boolean
            Get
                Return m_showPicture
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ShowItemPicture", m_showPicture, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Steuersatz in % ab, (z.B. 19%), der disem Artikel zugrundliegt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("TaxRateValue", "Mwst.")> _
        <Persistent("TaxRate")> _
        Public Property TaxRateValue() As Decimal
            Get
                Return m_taxRateValue
            End Get
            Set(ByVal value As Decimal)

                SetPropertyValue(Of Decimal)("TaxRateValue", m_taxRateValue, value)
            End Set
        End Property

        ''' <summary>
        ''' Die ID des Steuersatzes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("TaxValueID")> _
        Public Property TaxRateID() As Integer
            Get
                Return m_taxRateID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TaxRateID", m_taxRateID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Steuersatz dieses Artikels ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property TaxRate() As Kernel.TaxRate
            Get
                Return MainApplication.TaxRates.GetItem(Me.TaxRateID)
            End Get
            Set(ByVal value As Kernel.TaxRate)
                If value IsNot Nothing Then
                    Me.TaxRateID = value.ID
                    Me.TaxRateValue = value.TaxValue
                Else
                    Me.TaxRateID = -1
                    ' ? was ist mit dem Steuerwert ? 
                End If
            End Set
        End Property


        ''' <summary>
        ''' Wahr, wenn der Artikelpreis inklusive Steueranteil angezeigt werden soll. ("Ink. MwSt"), Falsch, wenn Artikelpreis Netto-Betrag ist ("Preis plus MwSt")
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
            End Set
        End Property


        ''' <summary>
        ''' Kurztext des Artikels
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(250)> _
        <ClausSoftware.Tools.DisplayName("ItemName", "Artikelname")> _
        <Persistent("Name")> _
        Public Property ItemName() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = String.Empty

                If value.Length > m_mainApplication.Database.GetColumnCharacterLength(JournalArticleItem.TableName, "Name") Then

                    value = value.Substring(0, CInt(m_mainApplication.Database.GetColumnCharacterLength(JournalArticleItem.TableName, "Name")))
                End If

                SetPropertyValue(Of String)("ItemName", m_Name, value)

            End Set
        End Property

        ''' <summary>
        ''' Langtext des Artikels
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <ClausSoftware.Tools.DisplayName("ItemMemoText", "Artikelbeschreibung")> _
        <Persistent("Beschreibung")> _
        Public Property ItemMemoText() As String
            Get
                Return m_itemMemoText
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = String.Empty

                If value.Length > m_mainApplication.Database.GetColumnCharacterLength(JournalArticleItem.TableName, "Beschreibung") Then
                    value = value.Substring(0, CInt(m_mainApplication.Database.GetColumnCharacterLength(JournalArticleItem.TableName, "Beschreibung")))
                End If

                SetPropertyValue(Of String)("ItemMemoText", m_itemMemoText, value)
            End Set
        End Property

        ''' <summary>
        ''' RTF - Langtext des Artikels; Stellt einen Formatierten beschreibenden Text des Artikels dar oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <ClausSoftware.Tools.DisplayName("FormattedItemMemoText", "Artikelbeschreibung (Formatiert)")> _
        <Persistent("RTFMemoText")> _
        Public Property RTFItemMemoText() As String
            Get

                If m_rtfItemMemoText.Length < Me.ItemMemoText.Length Then
                    m_rtfItemMemoText = Me.ItemMemoText
                End If

                If Not m_rtfItemMemoText.StartsWith("{\rtf1") Then ' Man geht davon aus, das der RTF-text länger ist, als der normale Text!
                    If m_rtfItemMemoText.Contains(vbCrLf) Then
                        m_rtfItemMemoText = m_rtfItemMemoText.Replace(vbCrLf, "\par ")
                    End If
                    m_rtfItemMemoText = _
                        "{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset0 Arial;}}" & _
                    "\viewkind4\uc1\pard\lang1031\fs20 " & _
                    m_rtfItemMemoText & _
" \par}"

                End If

                Return m_rtfItemMemoText
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = String.Empty

                SetPropertyValue(Of String)("RTFItemMemoText", m_rtfItemMemoText, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Netto-Grundpreis ab oder legt diesen fest. Der Grundpreis wird nicht multipliziert, und zum Preis einmal dazuaddiert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("BasePrice", "Grundpreis")> _
        <Persistent("Grundpreis")> _
        Public Property BasePrice() As Decimal
            Get
                Return m_basePrice
            End Get
            Set(ByVal value As Decimal)

                SetPropertyValue(Of Decimal)("BasePrice", m_basePrice, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Verkaufte (Handhabbare Einheit-ID ab) ode rlegt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <Persistent("Einheit")> _
        Public Property UnitID() As Integer
            Get
                Return m_unitID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("UnitID", m_unitID, value)

            End Set
        End Property

        ''' <summary>
        ''' Ruft den einzel-EK des Artikels ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("ItemSinglePurchasePrice", "Einzel EInkaufspreis")> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        Public ReadOnly Property ItemSinglePurchasePrice As Decimal
            Get
                If Me.GetArticleItem IsNot Nothing Then
                    Return Me.GetArticleItem.EinzelEK
                End If
                Return 0D
            End Get
        End Property





        ''' <summary>
        ''' Gibt die Einheit als Einheitsobjekt wieder zurück
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ItemUnit", "Einheit")> _
        Public Property ItemUnit() As Unit
            Get
                Return Me.MainApplication.Units.GetItem(UnitID)
            End Get
            Set(ByVal value As Unit)
                If value IsNot Nothing Then
                    UnitID = value.ID
                    ItemUnitText = value.Name
                Else
                    UnitID = 0
                End If
            End Set
        End Property

        ''' <summary>
        ''' Anzahl der Minuten die dieser Artikel (z.B. bei Einbauarbeiten) benötigt.
        ''' Ist der Artikel eine Arbeitszeit, dann ist dies die Arbeitszeit in Minuten
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("minutes", "Minuten")> _
        <Persistent("Minuten")> _
        Public Property TimeInMinutes() As Integer
            Get
                Return m_timeInMinute
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TimeInMinutes", m_timeInMinute, value)
            End Set
        End Property

        ''' <summary>
        ''' Kosten pro Stunde bei Tätigkeiten (Arbeitszeiten); nicht Artikelart "Text" und "Material"
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Stundensatz")> _
        Public Property PricePerHour() As Decimal
            Get
                Return m_Stundensatz
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PricePerHour", m_Stundensatz, value)
            End Set
        End Property

        ''' <summary>
        ''' Einzel Netto Verkauspreis dieses Artikels, ohne Aufschläge oder Basispreise
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Alle Preise sind Netto</remarks>
        <ClausSoftware.Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
<ClausSoftware.Tools.DisplayName("SinglePriceBeforeTax", "Einzelpreis (netto)")> _
<Persistent("VK")> _
        Public Property SinglePriceBeforeTax() As Decimal
            Get
                Return m_salesPriceBeforeTax
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SinglePriceBeforeTax", m_salesPriceBeforeTax, value)
            End Set
        End Property

        ''' <summary>
        ''' Einzel Brutto Verkaufspreis
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
        <ClausSoftware.Tools.DisplayName("SinglePriceAfterTax", "Einzelpreis (brutto)")> _
        Public Property SinglePriceAfterTax() As Decimal
            Get
                Return SinglePriceBeforeTax * (1 + TaxRateValue / 100)
            End Get
            Set(ByVal value As Decimal)
                SinglePriceBeforeTax = value / (1 + TaxRateValue / 100)

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
                    Return Me.SinglePriceAfterTax
                Else
                    Return Me.SinglePriceBeforeTax
                End If

            End Get
            Set(ByVal value As Decimal)

                If ShowWithTax Then ' dann kommt ein Brutto-Preis rein
                    Me.SinglePriceAfterTax = value
                Else
                    Me.SinglePriceBeforeTax = value
                End If

            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, ob eine Summe gerundet (auf 2 Nachkommastellen des Einzelpreises) oder exakt berechnet werden soll
        ''' </summary>
        ''' <value>True, wenn Summen gerundet werden sollen, sonst False</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property RoundSum As Boolean
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
                If RoundSum Then
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
        ''' Ruft den Gesamtpreis (Basis + Anzahl x Einzelpreis) ab, der keinen Steueranteil enthält. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
        <ClausSoftware.Tools.DisplayName("TotalPriceBeforeTax", "Gesamtpreis (netto)")> _
        Public ReadOnly Property TotalPriceBeforeTax() As Decimal
            Get
                If RoundSum Then
                    Return Me.BasePrice + Math.Round(Me.SinglePriceBeforeTax, 2) * Me.ItemCount - Me.DiscountValue

                Else
                    Return Me.BasePrice + Me.SinglePriceBeforeTax * Me.ItemCount - Me.DiscountValue
                End If

            End Get
        End Property

        ''' <summary>
        ''' Ruft den Gesamtpreis inklusiver Steueranteil ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
        <ClausSoftware.Tools.DisplayName("TotalPriceAfterTax", "Gesamtpreis (brutto)")> _
        Public ReadOnly Property TotalPriceAfterTax() As Decimal
            Get
                Dim taxrate As Decimal = (1 + Me.TaxRateValue / 100)

                If RoundSum Then
                    Return Me.BasePrice * taxrate + Math.Round(Me.SinglePriceAfterTax, 2) * Me.ItemCount - Me.DiscountValue * taxrate

                Else
                    Return (Me.BasePrice + Me.SinglePriceBeforeTax * Me.ItemCount - Me.DiscountValue) * (1 + Me.TaxRateValue / 100)

                End If

            End Get
        End Property

        ''' <summary>
        ''' Verknüpfung zum Journaldokument. Enthält die ID des Journaldokumentes; ID und Type müssen zur Position passen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nicht mehr verwenden, wir haben nun eine ParentID {String(32)}")> _
        <Persistent("lfndNummer")> _
        Private Property ParentDocID() As Integer
            Get
                Return m_parentDocID
            End Get
            Set(ByVal value As Integer)

                If value <> m_parentDocID Then
                    m_parentItem = Nothing
                End If

                SetPropertyValue(Of Integer)("ParentDocID", m_parentDocID, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft die ID der übergeordneten Journalgruppe (JournalPosition) ab oder legt diese fest
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
                m_parentItem = Nothing ' Das Zielobjekt auf ' nothing setzen
            End Set
        End Property


        ''' <summary>
        ''' Ruft das übergeordnete Element ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParentArticleGroup() As JournalArticleGroup
            Get
                If m_parentItem Is Nothing Then
                    m_parentItem = SearchParentGroup()
                End If
                Return m_parentItem
            End Get
            Set(ByVal value As JournalArticleGroup)
                If value IsNot Nothing Then

                    If value Is m_parentItem Then Exit Property
                    If m_parentItemID = value.Key Then Exit Property

                    ParentItemID = value.Key
                    m_parentItem = value
                Else
                    ParentItemID = String.Empty
                    m_parentItem = Nothing
                End If


            End Set
        End Property

        ''' <summary>
        ''' Erstellt eine neue Kopie dieses Artikels
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function Clone() As Object
            Dim ClonedItem As JournalArticleItem = CType(MyBase.Clone, JournalArticleItem)

            ClonedItem.ParentArticleGroup = Me.ParentArticleGroup
            Return ClonedItem
        End Function

        ''' <summary>
        '''Sucht die Übergeordnet Gruppe aus der Datenbank.
        ''' Wenn dieser Artikel ein neuer Artikel ist, gibvt es kine übergeordnete Gruppe und es wird 'nothing' zurükgegeben.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function SearchParentGroup() As JournalArticleGroup

            Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("ReplikID='" & Me.ParentItemID & "'")
            Dim posItems As JournalArticleGroups = New JournalArticleGroups(MainApplication, criteria)
            If posItems.Count = 1 Then
                Return posItems(0)
            Else
                Return Nothing
            End If

        End Function


        ''' <summary>
        ''' Bei Dokumente können die Artikel in mehreren Seiten erscheinen. Es ergibt sich dann ein Seitenumbruch im Ausruck und in der Eingabemaske.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nicht mehr verwenden, wir haben nun eine ParentID {String(32)}")> _
        <Persistent("Seite")> _
        Private Property PositionID() As Integer
            Get
                Return m_positionID
            End Get
            Set(ByVal value As Integer)

                If m_positionID <> value Then ' Das ParentItemPos-Objekt ungültig machen
                    m_parentItem = Nothing
                End If

                SetPropertyValue(Of Integer)("PositionID", m_positionID, value)
            End Set
        End Property



        ''' <summary>
        ''' Nicht verwenden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Dient der Infrastruktur und ist immer 1")> _
<Persistent("Pos")> _
        Private Property oldPosition() As Integer
            Get
                Return 1
            End Get
            Set(ByVal value As Integer)

            End Set
        End Property

        ''' <summary>
        ''' Anzahl des Artikels
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ItemCount", "Anzahl")> _
        <Persistent("Anzahl")> _
        Public Property ItemCount() As Decimal
            Get
                Return m_itemCount
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ItemCount", m_itemCount, value)
            End Set
        End Property

        ''' <summary>
        ''' Kennzeichnet einen Text, schliesst "IstMaterial" und "IstArbeit" aus.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Das kann bei freien Eingaben der Fall sein, oder aber es gibt keine Artikelverknüpfung (mehr).
        ''' Der Wert kann nur gesetzt werden, aber nicht gelöscht. Setze stattdesen einen von IstText, IstArbeit und IstMaterial.</remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        Public ReadOnly Property IsText() As Boolean
            Get
                Return Me.OrgItemID.EndsWith("T")
            End Get

        End Property

        ''' <summary>
        ''' Kennzeichnet diesen Eintrag als Referenz einer Rechnung (Sammelrechnungseintrag)
        ''' </summary>
        ''' <value></value>
        ''' <returns>OrgItem endet auf "I" für Invoice</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsInvoiceReference As Boolean
            Get
                Return Me.OrgItemID.EndsWith("I")
            End Get
        End Property


        ''' <summary>
        ''' Kennzeichnet einen Artikel, schliesst "IstText" und "IstArbeit" aus.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Der Wert kann nur gesetzt werden, aber nicht gelöscht. Setze stattdesen einen von IstText, IstArbeit und IstMaterial.</remarks>
        Public ReadOnly Property IsItem() As Boolean
            Get
                Return Me.OrgItemID.EndsWith("M")
            End Get

        End Property

        ''' <summary>
        ''' Kennzeichnet eine reine Tätigkeit
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Der Wert kann nur gesetzt werden, aber nicht gelöscht. Setze stattdesen einen von IstText, IstArbeit und IstMaterial.</remarks>
        Public ReadOnly Property IsWorkItem() As Boolean
            Get
                Return Me.OrgItemID.EndsWith("A")
            End Get

        End Property





        ''' <summary>
        ''' Ist die nummerische ID aus Tätigkeiten oder Material zusammen mit einem Suffix "M" für Material, einem einzelnen "T" für Text, 
        ''' und einem "A" für Arbeit. 
        ''' Der Wert kann leer sein, oder nur eine Ziffer enthalten; dann ist es ein Material (nur Ziffer), oder Text (Leer).
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("OrgItem")> _
        Public Property OrgItemID() As String
            Get
                If m_OrgItemID Is Nothing Then
                    m_OrgItemID = ""
                End If
                Return m_OrgItemID
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("OrgItemID", m_OrgItemID, value)
            End Set
        End Property

        Private m_item As Article

        ''' <summary>
        ''' Ruft das Artikelobjekt ab. Kann im Fehlerfall 'nothing' sein
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetArticleItem() As Article
            If m_item Is Nothing Then
                Dim itemID As Integer
                If Me.OrgItemID.EndsWith("M") AndAlso Me.OrgItemID.Length > 1 Then
                    itemID = CInt(Me.OrgItemID.Substring(0, Me.OrgItemID.Length - 1))
                    m_item = MainApplication.ArticleList.GetFromDB(itemID)

                Else ' Dann war es nicht als Artikel gekennzeichnet, vielleicht ein text ? 
                    Return Nothing
                End If



            End If

            Return m_item
        End Function

        ''' <summary>
        ''' Absolute Position dieses Items innerhalb seines Blocks. In dieser Reihenfolge werden die Artikel auch angezeigt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
        <Tools.DisplayName("Position", "Position")> _
        <Persistent("AbsPosition")> _
        Public Property Sequence() As Integer Implements ISortableItem.Sequence
            Get
                Return m_sequence
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Sequence", m_sequence, value)

                If Not IsLoading Then
                    DisplayPositionNumber = value.ToString
                End If

            End Set
        End Property

        ''' <summary>
        ''' Enthält den Anzeigetext für die fortlaufende Positionsnummer
        ''' </summary>
        ''' <remarks></remarks>
        Private m_displayPositionNumber As String = String.Empty

        ''' <summary>
        ''' Anzeigetext der Positionsnummer
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("Position", "Position")> _
        <Persistent("DisplayPositionNumber")> _
        Private Property DisplayPositionNumber As String
            Get
                If String.IsNullOrEmpty(m_displayPositionNumber) Then
                    m_displayPositionNumber = CStr(Sequence)
                End If
                Return m_displayPositionNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DisplayPositionNumber", m_displayPositionNumber, value)

            End Set
        End Property

        ''' <summary>
        ''' Die Einheit als Text. Überschreibt den EinheitStr-Objekt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ItemUnitText", "Einheit Name")> _
        <Persistent("EinheitStr")> _
        Public Property ItemUnitText() As String
            Get
                Return m_unitText
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ItemUnitText", m_unitText, value)
            End Set
        End Property

        ''' <summary>
        ''' Kennzeichnet die Dokumentenzugehörigkeit des Items
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nicht mehr verwenden, wir haben nun eine ParentID {String(32)}")> _
        <Persistent("Status")> _
        Private Property DocumentType() As enumJournalDocumentType
            Get
                Return m_documentType
            End Get
            Set(ByVal value As enumJournalDocumentType)
                If value = enumJournalDocumentType.ALL Then Throw New ArgumentException("Enum 'ALL' kann nicht in der Datenbankschicht gesetzt werden")

                SetPropertyValue(Of enumJournalDocumentType)("DocumentType", m_documentType, value)

            End Set
        End Property

        ''' <summary>
        ''' Kennzeichnet ein Item als Gruppen-Item;
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>In der GUI wird dann kein Gesamtpreis ermittelt</remarks>
        <Persistent("IstGruppe")> _
        Public Property IsGrouped() As Boolean
            Get
                Return m_isGrouped
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsGrouped", m_isGrouped, value)
            End Set
        End Property

        ''' <summary>
        ''' Wert eines Rabatts (oder Aufschlag) sofern RabattAktiv ist.
        ''' Betrag wird dem Verkauspreis zu- oder abgezogen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Rabatt")> _
        Public Property DiscountValue() As Decimal
            Get
                Return m_Rabatt
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DiscountValue", m_Rabatt, value)
            End Set
        End Property

        ''' <summary>
        ''' Ist der Rabatt aktiv, so wird vom Verkauspreis Rabattwert ab- oder aufgeschlagen; je nach Vorzeichen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("RabattAktiv")> _
        Public Property UseDiscount() As Boolean
            Get
                Return m_usediscount
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("UseDiscount", m_usediscount, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt die ID eines Lieferanten für diesen Artikel dar.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Lieferant")> _
        Public Property ManufactorsAddressID() As Integer
            Get
                Return m_manufactorsAddressIDID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ManufactorsAddressID", m_manufactorsAddressIDID, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt die Adressklasse des Lieferanten für diesen Artikel dar
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ManufactorsAddress", "Hersteller Adresse")> _
        Public Property ManufactorsAddress() As Adress
            Get
                Return MainApplication.Adressen.GetItem(Me.ManufactorsAddressID)
            End Get
            Set(ByVal lieferant As Adress)
                If lieferant IsNot Nothing Then
                    Me.ManufactorsAddressID = lieferant.ID
                Else
                    Me.ManufactorsAddressID = 0
                End If
            End Set
        End Property

        ''' <summary>
        ''' Artikelnummer des Lieferanten (Manufactors ArticleNumber))
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ExternalItemNumber", "Artikelnummer d. Herstellers")> _
        <Size(50)> _
        <Persistent("extartnummer")> _
        Public Property ExternalItemNumber() As String
            Get
                Return m_externalItemNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ExternalItemNumber", m_externalItemNumber, value)
            End Set
        End Property

        ''' <summary>
        ''' Eigene, benutzerdefinierte Artikelnummer
        ''' </summary>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("InternalItemNumber", "eigene Artikelnummer")> _
        <Size(50)> _
        <Persistent("intartnummer")> _
        Public Property InternalItemNumber() As String
            Get
                Return m_InterneArtikelnummer
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InternalItemNumber", m_InterneArtikelnummer, value)
            End Set
        End Property

        ''' <summary>
        ''' Setzt alle Eigenschaften anhand eines Artikels
        ''' </summary>
        ''' <param name="templateArticle"></param>
        ''' <remarks></remarks>
        Public Sub SetByArticle(ByVal templateArticle As Article)
            If templateArticle IsNot Nothing Then
                Me.OrgItemID = templateArticle.ID & "M"

                Me.ItemCount = 1

                Me.BasePrice = 0
                m_item = templateArticle
                SyncWithItem()

            End If

        End Sub

        ''' <summary>
        ''' Übeträgt die originalen Artikeldaten in diesen Datensatz
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SyncWithItem()
            Dim item As Article = Me.GetArticleItem
            If item IsNot Nothing Then
                Me.SinglePriceBeforeTax = item.EinzelVK
                Me.ItemUnit = item.VerpackungsEinheit
                Me.InternalItemNumber = item.CustomerArticleNumber

                Me.ManufactorsAddress = item.Lieferant
                Me.ExternalItemNumber = item.ManufactorsArticleNumber

                Me.ItemName = item.ShortDescription
                Me.ItemMemoText = item.LongDescription
                Me.RTFItemMemoText = item.LongDescription

                Me.ItemPicture = item.DefaultImage
                Me.TaxRate = item.TaxRate
                Me.TimeInMinutes = item.TimeInMinutes

            End If
        End Sub

        ''' <summary>
        ''' Prüft, ob der Artikel und der originale Artikelnoch übereinstimmen. 
        ''' Gibt True zurück, wenn beide Artikel noch identisch sind, sonst false.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckItemisInSync() As Boolean
            'TODO: Artikel und Orgitem vergleichen und prüfen
            Return True
        End Function
        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse
        ''' </summary>
        ''' <param name="session"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
            ' Standards setzen

        End Sub

        
    End Class

    ''' <summary>
    ''' Enthält ein wertepaar: Nettopreis, Steueranteil und Summe
    ''' </summary>
    ''' <remarks></remarks>
    Public Class JournalTaxValuePair

        Private m_mainApplication As MainApplication

        Private m_Netto As Decimal

        ''' <summary>
        ''' Enthält den Bruttopreis
        ''' </summary>
        ''' <remarks></remarks>
        Private m_bruttoValue As Decimal
        ''' <summary>
        ''' Enthält den Steueranteil
        ''' </summary>
        ''' <remarks></remarks>
        Private m_taxValuePrice As Decimal


        Private m_taxrate As TaxRate

        ''' <summary>
        ''' Ruft den hier verwendeten Steuersatz ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TaxRate() As TaxRate
            Get

                ' Steuersatz retten, dürfte niemals nothing sein
                If m_taxrate Is Nothing Then
                    m_taxrate = m_mainApplication.TaxRates.GetNormalTax
                End If

                Return m_taxrate
            End Get
            Set(ByVal value As TaxRate)
                m_taxrate = value
            End Set
        End Property


        ''' <summary>
        ''' Enthält den Steueranteil in % 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TaxRateValue() As Decimal
            Get
                Return TaxRate.TaxValue
            End Get
            'Set(ByVal value As Decimal)
            '    m_TaxRateValue = value
            'End Set
        End Property

        ''' <summary>
        ''' Enthält die Summe aus Nettopreis und Steueranmteil
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TotalPrice() As Decimal
            Get
                Return m_bruttoValue
            End Get
            Set(ByVal value As Decimal)
                m_bruttoValue = value
            End Set
        End Property

        ''' <summary>
        ''' Enthält den Steueranteil, der zum Nettopreis hinzukommt
        ''' </summary>
        ''' <value>Steueranteil</value>
        ''' <returns></returns>
        ''' <remarks>Nettopreis plus Steueranteil ergibt den Gesamtpreis</remarks>
        Public ReadOnly Property TaxValuePrice() As Decimal
            Get
                Return m_bruttoValue - m_Netto
            End Get
         
        End Property

        ''' <summary>
        ''' Enthält den Preisanteil ohne Steuern
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property NettoPrice() As Decimal
            Get
                Return m_Netto
            End Get
            Set(ByVal value As Decimal)
                m_Netto = value
            End Set
        End Property

        Public Sub New(ByVal mainApp As MainApplication)
            m_mainApplication = mainApp
        End Sub
    End Class

    ''' <summary>
    ''' Stellt eine vereinfachte Klasse eines JournalArtikels dar
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class JournalArticelItemProxy
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_key As String
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_OrgID As String
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_ItemCount As Decimal
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_UnitID As Integer
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_name As String
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_description As String
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_basePrice As Decimal
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_TaxRate As Decimal
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_image As System.Drawing.Image
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_AdressID As Integer

        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_formattedMemoText As String


        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_salesPrice As Decimal
        ''' <summary>
        ''' Verkaufspreis
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SinglePriceBeforeTax() As Decimal
            Get
                Return m_salesPrice
            End Get
            Set(ByVal value As Decimal)
                m_salesPrice = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID des Lieferanten ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AdressID() As Integer
            Get
                Return m_AdressID
            End Get
            Set(ByVal value As Integer)
                m_AdressID = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft ein Bild des Elementes ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemImage() As System.Drawing.Image
            Get
                Return m_image
            End Get
            Set(ByVal value As System.Drawing.Image)
                m_image = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die steuersatzrate in % ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TayRate() As Decimal
            Get
                Return m_TaxRate
            End Get
            Set(ByVal value As Decimal)
                m_TaxRate = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Basispreis ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Basispreis wird genau einmal berechnet aber mit der Anzahl nicht Multipliziert</remarks>
        Public Property BasePrice() As Decimal
            Get
                Return m_basePrice
            End Get
            Set(ByVal value As Decimal)
                m_basePrice = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den langen Beschreibugnstext ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemMemoText() As String
            Get
                Return m_description
            End Get
            Set(ByVal value As String)
                m_description = value
            End Set
        End Property



        ''' <summary>
        ''' enthält den Formatierten memeotext
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RTFItemMemoText() As String
            Get
                Return m_formattedMemoText
            End Get
            Set(ByVal value As String)
                m_formattedMemoText = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Artikelnamen ab (Kurztext) oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemName() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID der Einheit ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UnitID() As Integer
            Get
                Return m_UnitID
            End Get
            Set(ByVal value As Integer)
                m_UnitID = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft di verwendte Anzahl dieses Elemetes ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemCount() As Decimal
            Get
                Return m_ItemCount
            End Get
            Set(ByVal value As Decimal)
                m_ItemCount = value
            End Set
        End Property

        ''' <summary>
        ''' Stellt einen Verweis auf das ursprügliche Element da. 
        ''' Die Endung "T" deutet auf einen Freitext hin, "M" auf einen Artikel
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property OrgItemID() As String
            Get
                Return m_OrgID
            End Get
            Set(ByVal value As String)
                m_OrgID = value
            End Set
        End Property

        ''' <summary>
        ''' stellt den eindeutigen schlüssel des Elementes dar
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Key() As String
            Get
                Return m_key
            End Get
            Set(ByVal value As String)
                m_key = value
            End Set
        End Property


        Public Sub New(ByVal baseItem As JournalArticleItem)
            Me.BasePrice = baseItem.BasePrice
            Me.SinglePriceBeforeTax = baseItem.SinglePriceBeforeTax
            Me.ItemMemoText = baseItem.ItemMemoText
            Me.RTFItemMemoText = baseItem.RTFItemMemoText

            Me.ItemCount = baseItem.ItemCount
            Me.Key = baseItem.Key
            Me.ItemName = baseItem.ItemName
            Me.OrgItemID = baseItem.OrgItemID
            Me.UnitID = baseItem.UnitID
            'Me.ItemImage = baseItem.ItemPicture
            Me.AdressID = baseItem.ManufactorsAddressID

            Me.InternalItemNumber = baseItem.InternalItemNumber
            Me.ExternalItemNumber = baseItem.ExternalItemNumber
            If baseItem.ItemPicture IsNot Nothing Then
                Me.ItemPicture = CType(baseItem.ItemPicture.Clone, Drawing.Image)
            End If

            Me.TimeInMinutes = baseItem.TimeInMinutes
            Me.DiscountValue = baseItem.DiscountValue

            Me.TaxRateID = baseItem.TaxRateID  ' Anm.: Alle eigenschaften müssen serialisierebar sein für den Transport über das copy / Paste Interface

        End Sub

        Public Sub New()
            ' Parameterloser Konstruktor für serialisierung
        End Sub

        Private m_InternalItemNumber As String
        Private m_ItemPicture As System.Drawing.Image
        Private m_TimeInMinutes As Integer
        Private m_ExternalItemNumber As String
        Private m_DiscountValue As Decimal
        Private m_TaxRateID As Integer

        Public Property InternalItemNumber As String
            Get
                Return m_InternalItemNumber
            End Get
            Set(value As String)
                m_InternalItemNumber = value
            End Set
        End Property

        Public Property ItemPicture As System.Drawing.Image
            Get
                Return m_ItemPicture
            End Get
            Set(value As System.Drawing.Image)
                m_ItemPicture = value
            End Set
        End Property

        Public Property TimeInMinutes As Integer
            Get
                Return m_TimeInMinutes
            End Get
            Set(value As Integer)
                m_TimeInMinutes = value
            End Set
        End Property

        Public Property ExternalItemNumber As String
            Get
                Return m_ExternalItemNumber
            End Get
            Set(value As String)
                m_ExternalItemNumber = value
            End Set
        End Property

        Public Property DiscountValue As Decimal
            Get
                Return m_DiscountValue
            End Get
            Set(value As Decimal)
                m_DiscountValue = value
            End Set
        End Property

        Public Property TaxRateID As Integer
            Get
                Return m_TaxRateID
            End Get
            Set(value As Integer)
                m_TaxRateID = value
            End Set
        End Property
    End Class

End Namespace