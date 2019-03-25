Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data


Namespace Kernel
    ''' <summary>
    ''' Stellt eine Form der Aufschlagsermittlung dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum GewinnType
        IsAbsolute
        IsRelative
    End Enum

    ''' <summary>
    ''' Stellt ein Artikel dar
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerDisplay("Name={ShortDescription}")> _
    <Persistent(Article.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Article
        Inherits TrackedItem
        Implements IDataItem
        Implements IAttachments
        Implements IHasActiveProperty

        Public Const TableName As String = "Materialliste"

        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_attachmentRelations As AttachmentsRelations

        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_classificationDefinition As Attributes.ClassDefinition


        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private Shared noPicture As Drawing.Image = My.Resources.no_picture

        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_itemsList As Attributes.AttributeValues

        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private Shared m_ArticleHirachy As Attributes.ArticleReplacements

        ''' <summary>
        ''' Speichert das Bild eines Artikel; so wird es nicht jedesmal aaus der Datenbank abgerufen
        ''' </summary>
        ''' <remarks></remarks>
        Private m_articleImage As Drawing.Image
        Private m_ImageList As ClausSoftware.Kernel.Images

        Private m_shortText As String = String.Empty
        Private m_longText As String = String.Empty

        Private m_einzelEK As Decimal

        Private m_EAN As String = String.Empty
        Private m_internalArticleNumber As String = String.Empty

        Private m_Gewinnspanne As String = String.Empty

        Private m_Priorität As Integer

        Private m_containePicture As Boolean

        Private m_adressID As Integer

        Private m_form As Integer
        ''' <summary>
        ''' Ein Artikel kann Abmessungen enthalten
        ''' </summary>
        ''' <remarks></remarks>
        Private m_Abmessung As String = String.Empty

        Private m_Recheneinheit As Integer

        Private m_VerpackungsEinheitID As Integer

        Private m_VerkaufspreisProEinheit As Decimal

        Private m_isWorkItem As Boolean

        ''' <summary>
        ''' Enthält das alte Feld "angelegt am"; durch neue Felder ersetzt
        ''' </summary>
        ''' <remarks></remarks>
        Private m_createdAt As Nullable(Of DateTime)

        ''' <summary>
        ''' Enthält das Feld "Geändert am" - durch neue Felder ersetzt
        ''' </summary>
        ''' <remarks></remarks>
        Private m_changedAt As Nullable(Of DateTime)

        Private m_subArticles As BOM.ArticleLinks

        ''' <summary>
        ''' Wahr, wenn der Artikel beliebig exportiert werden kann
        ''' </summary>
        ''' <remarks></remarks>
        Private m_exportable As Boolean

        Private m_VPAnzahl As Decimal

        Private m_AnzahlLiefereinheiten As Decimal

        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_userLocked As Boolean

        ''' <summary>
        ''' Enthält das Warengewicht in KG
        ''' </summary>
        ''' <remarks></remarks>
        Private m_gewicht As Decimal = -1

        'Private m_GewinnTypeProzent As Boolean

        Private m_timeInMinutes As Integer

        Private m_loadAccountID As String = String.Empty

        Private m_fixedGroupPrice As Boolean

        Private m_Rabatt As Integer

        Private m_dtnersteller As String = String.Empty

        ''' <summary>
        ''' Enthält eine freie, vom Benutzer vergebene Artikelnummer
        ''' </summary>
        ''' <remarks></remarks>
        Private m_userArticleID As String = String.Empty

        Private m_ExportWeb As Boolean

        Private m_IsActive As Boolean


        Private m_imageID As String

        Private m_groupID As String = Groups.RootID ' Gruppe festlegen, wenn noch nichts näher bekannt ist


        Private m_isImported As Boolean

        Private m_itemImage As System.Drawing.Image

        Private m_sourceDatanorm As Boolean

        Private m_mwstID As Integer

        Private m_datanormArtikelnummer As String = String.Empty
        Private m_manufactorsArticleNumber As String = String.Empty
        Private m_intArticleNumber As String = String.Empty
        Private m_datanormMatchCode As String = String.Empty

        Private m_showInPrintings As Boolean
        Private m_SumOutBound As Double

        Private m_SumInBound As Double

        ''' <summary>
        ''' AnzahlVerpackungsEinheit
        ''' </summary>
        ''' <remarks></remarks>
        Private m_countShippingUnits As Double = 1

        Private m_DTNHauptwarengruppe As String

        ''' <summary>
        ''' Enthält den Wert, der angibt ob der Verkaufspreis fest bleibt, 
        ''' Ist der VK fest, dann kann der Gewinn nicht geändert werden, ansonsten ist der VK-Preis vom Gewinn abhängig.
        ''' </summary>
        ''' <remarks></remarks>
        Private m_fixedendPrice As Boolean


        Private m_notes As String = String.Empty

        Private m_classifictionID As String

        ''' <summary>
        ''' erzwingt ein Abrufen der Classifikation
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CheckAndFixClassification()
            Dim myclassification As String = Me.ClassificationID

        End Sub

        ''' <summary>
        ''' Ruft die ID zu einer Klassifikation ab oder legt eine fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ClassificationID")> _
        <Size(32)> _
        Private Property ClassificationID() As String
            Get
                If Not Me.IsSaving Then
                    If String.IsNullOrEmpty(m_classifictionID) Then
                        ' dann anhand der Gruppe die ID raussuchen 
                        If Not Me.Group Is Nothing Then
                            Me.ClassificationID = Me.Group.AttributeClass.Key
                        Else
                            Return ""
                        End If


                    End If
                End If

                Return m_classifictionID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ClassificationID", m_classifictionID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Artikelhirachie ab. stellt Vorgänger und Nachvolgerartikel dar
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("ArticlesHirachy", "Artikelstammbaum")> _
        ReadOnly Property ArticlesHirachy() As Attributes.ArticleReplacements
            Get
                If m_ArticleHirachy Is Nothing Then
                    m_ArticleHirachy = New Attributes.ArticleReplacements(MainApplication)
                End If
                Return m_ArticleHirachy
            End Get
        End Property

        ''' <summary>
        ''' Sucht nach einem alten Bestehendem Artikel
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Wenn es einen alten Artikel gibt, so ist dieser Artikel "Nachfolger von" dem Artikel der hier zurückgegeben wird</remarks>
        Public Function GetPredecessorItems() As List(Of Article)

            Dim articleListe As New List(Of Article)

            Dim replacements As Attributes.ArticleReplacements = ArticlesHirachy.GetPredecessor(Me)

            Return replacements.Predecessors

        End Function

        ''' <summary>
        ''' Sucht nach einem Nachfolgeartikel
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSucccessorItem() As List(Of Article)


            Dim replacement As Attributes.ArticleReplacements = ArticlesHirachy.GetSucccessorItem(Me)
            Return replacement.Successors

        End Function


        ''' <summary>
        ''' Erzwingt ein Neuaufbau der Attribute für diesen Artikel
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Refreshattributes()
            m_itemsList = Nothing
        End Sub

        ''' <summary>
        ''' Ruft die Attribute.Werte Paare ab, die genau diesem Artikel zugewisen wurden.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetArticleAttributeValuePairs() As Attributes.AttributeValues
            Dim criteria As New Filtering.BinaryOperator("ArticleID", Me.Key)
            Return New Attributes.AttributeValues(MainApplication, criteria) ' Bereits vergebene Attribute-Werte paare aus Datenbank laden

        End Function

        ''' <summary>
        ''' Lieert Wahr zurück, wenn die Instanz diesers Moduls bereits gebildet wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ItemsAttributesActive As Boolean
            Get
                Return m_itemsList IsNot Nothing
            End Get
        End Property

        ''' <summary>
        ''' Ruft eine Auflistung von Item-Attributen ab, die für diesen Artikel definiert wurden
        ''' </summary>
        ''' <value></value>
        ''' <returns>Eine Auflistung von Attribute- und Werte paaren die für den Artikel vorgesehen sind</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ItemsAttributes() As Attributes.AttributeValues
            Get
                If m_itemsList Is Nothing Then
                    m_itemsList = GetArticleAttributeValuePairs()
                Else

                    m_itemsList.Reload()
                End If

                'Die Attributedefinitionen der Klassenliste neu einlesen und der Attribute-Werte auflistung hinzufügen
                If Me.Classification IsNot Nothing Then
                    ' Prüfe nun auf Schlüssel in der Definition
                    For Each item As Attributes.AttributeValueDefinition In Me.Classification.ValueDefinitions
                        If Not m_itemsList.ContainsAttribute(item) Then
                            Dim newValuePair As Attributes.AttributeValue = m_itemsList.GetNewItem(item)
                            newValuePair.ArticleID = Me.Key
                            m_itemsList.Add(newValuePair)

                            newValuePair.Save() ' erstmaliges speichern 
                        End If
                    Next

                    ' Alle Vater-Werte hinzufügen (Der übergeordneten Definitionen)
                    For Each item As Attributes.AttributeValueDefinition In Me.Classification.GetParentDefinitions
                        If Not m_itemsList.ContainsAttribute(item) Then
                            Dim newValuePair As Attributes.AttributeValue = m_itemsList.GetNewItem(item)
                            newValuePair.ArticleID = Me.Key
                            m_itemsList.Add(newValuePair)

                            newValuePair.Save() ' erstmaliges speichern 
                        End If
                    Next

                End If


                ' enthält nun die Liste der in er Datenbank vorhanden und die Attribute anhande der definition
                Return m_itemsList

            End Get
        End Property

        ''' <summary>
        ''' Speichert den Artikel und alle damit zusammenhängenden Daten ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()
            CheckAndFixClassification()
            MyBase.Save()

            If ImageListActive Then Me.ImageList.Save()
            If ItemsAttributesActive Then Me.ItemsAttributes.Save()
            If SubArticlesActive Then Me.SubArticles.Save()

            'm_mainApplication.SendMessage(m_mainApplication.Languages.GetText("msgCommonelementSaved", "Gespeichert: '{0}'", Me.ToString))
        End Sub



        ''' <summary>
        ''' Ruft die definierte Klassifikation ab, sofern vergeben oder legt diese fest
        ''' </summary>
        ''' <returns>Die Klassifikation oder nothing falls nicht vergeben.</returns>
        ''' <remarks>Die tatsächlichen Attribute werden aus der werte-Tabelle ermittelt. Druch umdefinition der Merkmale bleiben bereits vergebene Attribute bestehen </remarks>
        Public Function Classification() As Attributes.ClassDefinition
            If m_classificationDefinition Is Nothing Then
                m_classificationDefinition = MainApplication.ClassDefinitions.GetItemByItemGroup(Me.Group)
            End If
            Return m_classificationDefinition

        End Function

        ''' <summary>
        ''' Ruft eine Notiz zum Artikel ab, die nicht in Katalogen etc erscheint
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()> _
        <Size(SizeAttribute.Unlimited)> _
        <Tools.DisplayName("Notes", "Notizen")> _
        <Persistent("Notes")> _
        Public Property Notes() As String
            Get
                Return m_notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", m_notes, value)
            End Set
        End Property


        ''' <summary>
        ''' Wenn True, dann bleibt der Endpreis konstant; änderungen des Gewinnaufschlages werden ignoriert.
        ''' Auf False steuert der Gewinnaufschlag den Endverkaufspreis; eine Ändeurng des EndVK führt ebenfalls zu einer Änderung des Gewinns
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.DisplayName("Fester Endpreis")> _
        <Persistent("FixedPrice")> _
        Public Property FixedPrice() As Boolean
            Get
                Return m_fixedendPrice
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("FixedPrice", m_fixedendPrice, value)
            End Set
        End Property

        Overloads Property ReplikID() As String Implements IAttachments.ReplikID
            Get
                Return MyBase.ReplikID
            End Get
            Set(ByVal value As String)
                MyBase.ReplikID = value
            End Set
        End Property

        ''' <summary>
        ''' Zeigt die Summe der insgesamt eingehenenden Artikelanzahl
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <DevExpress.Xpo.DisplayName("Summe eingegangener Artikel")> _
        <Persistent("Eingang")> _
        Public Property SumInBound() As Double
            Get
                Return m_SumInBound
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("SumInBound", m_SumInBound, value)
            End Set
        End Property


        ''' <summary>
        ''' Zeigt die Summe der insgesmat ausgeheneden Artikel
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <DevExpress.Xpo.DisplayName("Summe ausgehender Artikel")> _
        <Persistent("Ausgang")> _
        Public Property SumOutBound() As Double
            Get
                Return m_SumOutBound
            End Get
            Set(ByVal value As Double)

                SetPropertyValue(Of Double)("SumOutBound", m_SumOutBound, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den aktuellen Rabattierten Preis ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("DiscountPrice", "Rabattierter Preis")> _
        ReadOnly Property DiscountPrice() As Decimal
            Get
                If Discount IsNot Nothing Then
                    Return EinzelEK * (1 - (Discount.DiscountValue / 100))
                Else
                    Return EinzelEK
                End If
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Ermittelten Endpreis ab.  Ist der endpreis fix, so wird der einzelvk abgerufen, 
        ''' sonst der berechnete Endpreis aus Discount, Rohstoffpreis und Gewinnaufschlag
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("CalulatedEndPrice", "Berechneter Endpreis")> _
        ReadOnly Property CalulatedEndPrice() As Decimal
            Get
                If FixedPrice Then
                    Return EinzelVK
                Else
                    Return DiscountPrice + GewinnAbsolut
                End If

            End Get
        End Property




        ''' <summary>
        ''' Zeigt an ob dieser Eintrag aktiv ist oder nicht
        ''' Nur aktive Artikel können in Rechnungen übernommen werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("IsActive", "Aktiv")> _
        <ComponentModel.DefaultValue(False)> _
        <Persistent("IsActive")> _
        Public Property IsActive() As Boolean Implements IHasActiveProperty.IsActive
            Get
                Return m_IsActive
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsActive", m_IsActive, value)
            End Set
        End Property

        ''' <summary>
        ''' Durchsucht die Rechnungen und zeigt an, wann der Artikel das letzte mal verkauft wurde
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LastSelling() As Date
            Dim sql As String
            sql = "SELECT I.Name, J.AngelegtAm FROM Items I,JournalListe J " & _
            " where I.orgitem ='" & Me.ID & "M'  AND J.Status=2  AND I.lfndNummer=J.lfndNummer   " & _
            " order by J.AngelegtAm DESC"

            Dim dt As DataTable = MainApplication.Database.GetData(sql)
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    Return CDate(dt.Rows(0)("AngelegtAm"))
                End If
            End If

            Return Date.MinValue

        End Function

        ''' <summary>
        ''' Ruft den Einzelpreis nach der Rabattierung ab, der um einen Rohstoffanteil ergänzt wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property GetResourcesPrice() As Decimal
            Get
                Return DiscountPrice
            End Get
        End Property

        ''' <summary>
        ''' Ruft die Anzahl der Artikel ab, die rechnerisch derzeit auf Lager sind
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        <DevExpress.Xpo.DisplayName("Auf Lager")>
        ReadOnly Property SumOnStock() As Double
            Get
                Return Me.SumInBound - Me.SumOutBound
            End Get
        End Property

        ''' <summary>
        ''' Fügt der Summe der ausgehenden Artikel die angegebene Anzahl hinzu
        ''' </summary>
        ''' <param name="count"></param>       
        ''' <remarks></remarks>
        Public Sub AddOutBound(ByVal count As Double)
            Me.SumOutBound = Me.SumOutBound + count
        End Sub

        ''' <summary>
        ''' Fügt der Summe der eingehenden Artikel diese Anzahl hinzu
        ''' </summary>
        ''' <param name="count"></param>
        ''' <remarks></remarks>
        Public Sub AddIngoing(ByVal count As Double)
            Me.SumInBound = Me.SumInBound + count
        End Sub



        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        <DevExpress.Xpo.DisplayName("Anzahl Verpackungseinheit")>
        <Persistent("AnzahlVerpackungsEinheit")>
        Property CountShippingUnits() As Double
            Get
                Return m_countShippingUnits
            End Get
            Set(ByVal value As Double)
                SetPropertyValue(Of Double)("CountShippingUnits", m_countShippingUnits, value)

            End Set
        End Property

        ''' <summary>
        ''' Zeigt an ob dieser Artikel im Katalogdrucker gedruckt werden soll oder nicht.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        <DevExpress.Xpo.DisplayName("Katalogdruck")>
        <Persistent("ShowInPrintings")>
        Property ShowInPrintings() As Boolean
            Get
                Return m_showInPrintings
            End Get
            Set(ByVal value As Boolean)

                SetPropertyValue(Of Boolean)("ShowInPrintings", m_showInPrintings, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Datanorm Matchcode ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        <DevExpress.Xpo.DisplayName("Datanorm Matchcode ")>
        <Persistent("DTNmatchcode")>
        Property DatanormMatchCode() As String
            Get
                Return m_datanormMatchCode
            End Get
            Set(ByVal value As String)

                If Not String.IsNullOrEmpty(value) Then
                    If value.Length > 150 Then
                        value = value.Substring(0, 149)
                    End If
                End If

                SetPropertyValue(Of String)("DatanormMatchCode", m_datanormMatchCode, value)
            End Set
        End Property

        ''' <summary>
        ''' enthält die HWLID der Installation, die diesen Datensatz aangelegft hat
        ''' </summary>
        ''' <remarks></remarks>
        Private m_HWLID As String

        ''' <summary>
        ''' Kennzeichnet diesen Artikel als Datanorm-Import
        ''' </summary>
        <ComponentModel.Browsable(False)>
        <Persistent("QuelleDatanorm")>
        Public Property SourceDatanorm() As Boolean
            Get
                Return m_sourceDatanorm
            End Get
            Set(ByVal value As Boolean)

                SetPropertyValue(Of Boolean)("SourceDatanorm", m_sourceDatanorm, value)
            End Set
        End Property

        ''' <summary>
        ''' Kennzeichnet diesen Artikel als von extern Importiert. Dieser Artikel wurde durch Datanorm oder einerm anderen Import-Vorgang in die Liste eingefügt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        <DevExpress.Xpo.DisplayName("Importierter Artikel")>
        <ComponentModel.Browsable(False)>
        <Persistent("quelleextern")>
        Public Property IsImported() As Boolean
            Get
                Return m_isImported
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsImported", m_isImported, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Gruppe ab in der dieser Artikel zugeordnet ist oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("ArticlesGroup", "Artikelgruppe")>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        Public Property Group() As Group
            Get
                Return MainApplication.Groups.GetItem(GroupID)

            End Get
            Set(ByVal value As Group)
                GroupID = value.Key
            End Set
        End Property

        ''' <summary>
        ''' Enthält die ID der Gruppe, in der dieser Artikel eingeordnet ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(32)>
        <Indexed()>
        <ComponentModel.Browsable(False)>
        <Persistent("GruppenID")>
        Public Property GroupID() As String
            Get
                Return m_groupID

            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GroupID", m_groupID, value)
                If Not IsLoading Then
                    GetClassificationID()
                End If

            End Set
        End Property

        ''' <summary>
        ''' Erzwingt das auslesen der Klassifikations-ID anhand der aktuellen Gruppe
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub GetClassificationID()
            If String.IsNullOrEmpty(m_classifictionID) Then
                ' dann anhand der Gruppe die ID raussuchen 
                If Not Me.Group Is Nothing Then
                    Me.ClassificationID = Me.Group.AttributeClass.Key
                Else
                    Return
                End If

            End If
        End Sub

        <Obsolete("Bilder liegen nun in externer Tabelle")>
        <ComponentModel.Browsable(False)>
        <Persistent("BildID")>
        Public Property BildID() As String
            <DebuggerStepThrough()>
            Get
                Return m_imageID
            End Get
            Set(ByVal value As String)
                If value IsNot Nothing Then
                    m_imageID = value.Trim
                Else
                    m_imageID = ""
                End If
            End Set
        End Property

        Private m_articleThumbnail As System.Drawing.Image

        ''' <summary>
        ''' Ruft eine verkelnerte Ansicht des Artikelbildes ab, sofern ein Bild existiert.
        ''' Liefert nothing zurück, wenn kein Artikelbild vorhanden ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(EditorBrowsableState.Advanced)>
        <Tools.DisplayName("ArticleThumbnail", "Artikelbild (klein)")>
        Public ReadOnly Property ArticleThumbnail As System.Drawing.Image
            Get
                If m_articleThumbnail Is Nothing Then
                    If Me.DefaultImage IsNot Nothing Then

                        m_articleThumbnail = Me.DefaultImage.GetThumbnailImage(160, 160, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbAbort), System.IntPtr.Zero)
                    End If
                End If
                Return m_articleThumbnail
            End Get
        End Property


        Private Function ThumbAbort() As Boolean
            Debug.Print("Aborting Thumbnails?")
            Return False
        End Function

        ''' <summary>
        ''' Ruft das zugewiesene Bild des Artikels ab oder legt es fest.
        ''' Es wird aus der Auflistung der Bilder das erste Bild jeweils manipuliert.  Einsetzen von 'nothing' ist nicht möglich
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()>
        <Tools.DisplayName("DefaultImage", "Bild")>
        Public Property DefaultImage() As System.Drawing.Image

            Get
                If ContainsPicture Then
                    If ImageList.Count > 0 Then
                        Return ImageList(0).Image
                    End If
                End If
                Return noPicture
            End Get
            Set(ByVal value As System.Drawing.Image)

                If value IsNot Nothing Then
                    ContainsPicture = True
                    Dim id As New ImageData(Me.Session)
                    id.Image = value
                    id.ReferenceID = Me.ReplikID

                    If ImageList.Count = 0 Then
                        ImageList.Add(id)
                    Else
                        ImageList(0).Image = id.Image
                        ImageList(0).Description = ""
                        ImageList(0).FilePath = ""

                    End If
                    m_articleThumbnail = Nothing ' Damit das Thumbnail zurücksetzen
                End If

            End Set
        End Property

        ''' <summary>
        ''' Liefert wahr, wenn dieses Modul bereits angelegt wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SubArticlesActive As Boolean
            Get
                Return m_subArticles IsNot Nothing
            End Get
        End Property

        ''' <summary>
        ''' Ruft alle verknüpften Stücklisten-Artikel ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function SubArticles() As BOM.ArticleLinks
            If m_subArticles Is Nothing Then
                Dim criteria As Filtering.CriteriaOperator = Filtering.CriteriaOperator.Parse("ParentArticleID='" & Me.Key & "'")
                m_subArticles = New BOM.ArticleLinks(MainApplication, criteria)
            End If
            Return m_subArticles
        End Function

        ''' <summary>
        ''' wenn Wahr, dann wurde der Artikel bereits in einem Journaldokument verbaut, kann nichtgelöschtwerden
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function IsInJournal() As Boolean

            Dim itemID As String = Me.ID & "M"

            Dim sql As String = "SELECT COUNT(*) FROM " & JournalArticleItem.TableName & " WHERE  OrgItem='" & itemID & "'"

            Dim o As Object = MainApplication.Database.ExcecuteScalar(sql)
            If Not TypeOf o Is DBNull Then
                Return (CInt(o) > 0)
            End If
            Return False

        End Function
        ''' <summary>
        ''' Ruft eine Liste mit Artikeln ab, die diesen Artikel als Bauteil enthalten.
        ''' </summary>
        ''' <returns>eine Liste mit Artikeln. Ist Leer, wenn dieser Artikel kein Teil eines anders Artikels ist</returns>
        ''' <remarks></remarks>
        Function GetParentArticles() As BOM.ArticleLinks
            Dim criteria As Filtering.CriteriaOperator = Filtering.CriteriaOperator.Parse("ArticleID='" & Me.Key & "'")
            Dim articleLinks As New BOM.ArticleLinks(MainApplication, criteria)

            Return articleLinks
        End Function

        ''' <summary>
        ''' Löscht den Artikel und alle damit verknüpften Elemente, sofern keine Verknüpfungen zu diesem Artikel existieren
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Delete()
            ' Nicht löschen, wenn Rechnungen oder andere Verknüpfungen  existieren
            If True Then
                DeleteInternal()
            End If

        End Sub

        ''' <summary>
        ''' Löscht den Artikel und alle amit verknüpften Elemente ohne weitere einschränkung
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub DeleteInternal()

            Me.ImageList.Delete() ' Alle Bilder löschen 

            Me.SubArticles.Delete() ' Alle Stücklisten - Verknüpfungen löschen 
            GetArticleAttributeValuePairs.Delete()

            ' Attachment-Links leeren
            Me.AttachmentLinks.Delete()
            Me.ArticlesHirachy.Delete() ' Alle veraltetet Artikel-Verknüpfungen (Vorgänger / Nachvolger) löschen 

            MyBase.Delete()
        End Sub



        ''' <summary>
        ''' Ist wahr, wenn die Imageliste jemals verwendet wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ImageListActive As Boolean
            Get
                Return m_ImageList IsNot Nothing
            End Get
        End Property

        ''' <summary>
        ''' Ruft eine Auflistung von Bildern ab, die diesem Artikel zugeordnet wurden
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>       
        Public Function ImageList() As Images
            'Get

            '    Return GetCollection(Of ImageData)("intImageList")
            'End Get

            If m_ImageList Is Nothing Then

                'Debug.Print("Starte das Abholen von Bilder")

                Dim criteria As New DevExpress.Data.Filtering.BinaryOperator("ReferenceID", Me.ReplikID, Filtering.BinaryOperatorType.Equal)

                m_ImageList = New Images(MainApplication, criteria)

            End If
            Return m_ImageList

        End Function

        ''' <summary>
        ''' Markiert einen Artikel als extern kopierbar; dieser Artikel kann dann z.B. im Internet bereitgestellt werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(True)>
        <DevExpress.Xpo.DisplayName("Extern bereitstellen")>
        <Persistent("CopyToWeb")>
        Public Property Copyextern() As Boolean
            Get
                Return m_ExportWeb
            End Get
            Set(ByVal value As Boolean)

                SetPropertyValue(Of Boolean)("CopyExtern", m_ExportWeb, value)
            End Set
        End Property


        ''' <summary>
        ''' Kennzeichnet den Artikel als Exportierbar. Dieser ARtikel erscheint inallen externen Listen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Im Moment nicht benutzen!")>
        <ComponentModel.Browsable(False)>
        <Persistent("ExportData")>
        Public Property Exportable() As Boolean
            Get
                Return m_exportable

            End Get
            Set(ByVal value As Boolean)

                SetPropertyValue(Of Boolean)("Exportable", m_exportable, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Artikelnummer des Datenliefertanten ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Zusammen mit dem Datanormersteller kann ein Artikel eindeutig wiedergefunden werden</remarks>
        <Indexed()>
        <Tools.DefaultGridVisible(EditorBrowsableState.Advanced)>
        <DevExpress.Xpo.DisplayName("Datanorm Artikelnummer")>
        <Persistent("DTNArtikelnummer")>
        Public Property DatanormArtikelnummer() As String
            Get
                Return m_datanormArtikelnummer & ""
            End Get
            Set(ByVal value As String)

                If Not String.IsNullOrEmpty(value) Then
                    If value.Length > 150 Then
                        value = value.Substring(0, 149)
                    End If
                End If

                SetPropertyValue(Of String)("DatanormArtikelnummer", m_datanormArtikelnummer, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Artikelnummer des Datenlieferanten ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()>
        <Indexed()>
        <ClausSoftware.Tools.DisplayName("ManufactorsItemNumber", "Artikelnummer d. Lieferanten")>
        <Persistent("extartnummer")>
        Public Property ManufactorsArticleNumber() As String
            Get
                Return m_manufactorsArticleNumber
            End Get
            Set(ByVal value As String)

                If Not String.IsNullOrEmpty(value) Then
                    If value.Length > 50 Then
                        value = value.Substring(0, 49)
                    End If
                End If

                SetPropertyValue(Of String)("ManufactorsArticleNumber", m_manufactorsArticleNumber, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft die interne Artikelnummer ab oder legt diese fest.
        ''' Diese wird beim Anlegen des Dokumentes automatisch vergeben.
        ''' Für eigene Artikelnummern benutzer das Feld "CustomArticleNumber"
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        <ClausSoftware.Tools.DisplayName("InternalItemID", "Interne Artikelnummer")>
        <Persistent("intartnummer")>
        Public Property InternalArticleNumber() As String
            Get
                Return m_intArticleNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("InternalArticleNumber", m_intArticleNumber, value)
            End Set
        End Property

        ''' <summary>
        ''' Gibt eine frei vergebare Artikelnummer zurück oder setzt diese.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        <Tools.DisplayName("CustomerArticleNumber", "Freie Artikelnummer")>
        <Persistent("UserArtikelNummer")>
        Public Property CustomerArticleNumber() As String
            Get
                Return m_userArticleID
            End Get
            Set(ByVal value As String)

                If Not String.IsNullOrEmpty(value) Then
                    If value.Length > 50 Then
                        value = value.Substring(0, 49)
                    End If
                End If

                SetPropertyValue(Of String)("CustomerArticleNumber", m_userArticleID, value)
            End Set
        End Property

        Private Shared m_TextToGroupList As New Dictionary(Of String, Group)


        ''' <summary>
        ''' Ruft den Namen der Gruppe ab, in der dieser Artikel mitglied ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        <Tools.DisplayName("GroupName", "Gruppenname")>
        Public Property GroupName() As String
            'todo: Ein MAterial(Artikel) hat immer genau eine Gruppe; Zuweisung definieren
            Get
                If Me.Group IsNot Nothing Then
                    Return Me.Group.Name
                Else
                    Return ""
                End If

            End Get
            Set(ByVal newName As String)

                If Me.Group IsNot Nothing AndAlso Not Me.Group.IsRootGroup Then ' Name festsetzen der Gruppe
                    Me.Group.Name = newName
                Else

                    If m_TextToGroupList.ContainsKey(newName) Then
                        Me.Group = m_TextToGroupList(newName)
                        Me.Group.Name = newName
                    Else


                        Dim newGroup As Group = Nothing
                        ' Suche eine Gruppe mit dem selben Namen
                        For Each item As Group In MainApplication.Groups.RootGroup.SubGroups
                            If item.Name.Equals(newName, StringComparison.InvariantCultureIgnoreCase) Then
                                newGroup = item
                                Exit For
                            End If
                        Next

                        If newGroup Is Nothing Then
                            newGroup = MainApplication.Groups.GetNewItem

                            newGroup.ParentGroup = MainApplication.Groups.RootGroup
                            newGroup.Name = newName
                            newGroup.Save()
                        End If

                        Me.Group = newGroup

                        m_TextToGroupList.Add(newGroup.Name, newGroup)

                    End If
                End If
            End Set
        End Property


        ''' <summary>
        ''' Prüft auf Änderungen des Artikels sowie der Merkmale und weitere verknüpfte Eigenschaften
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides ReadOnly Property HasChanged() As Boolean
            Get
                Dim m_haschanges As Boolean
                m_haschanges = MyBase.HasChanged

                If m_itemsList IsNot Nothing Then
                    m_haschanges = m_haschanges Or m_itemsList.HasChanges
                End If

                If m_attachmentRelations IsNot Nothing Then
                    m_haschanges = m_haschanges Or m_attachmentRelations.HasChanges
                End If

                Return m_haschanges
            End Get
        End Property

        ''' <summary>
        ''' Läd den Artikel und alle angeknüpften eigenschaften neu ein
        ''' </summary>
        ''' <remarks></remarks>
        Public Overloads Sub Reload()

            MyBase.Reload()
            If ItemsAttributesActive Then

                Me.ItemsAttributes.Reload()

                For Each item As Attributes.AttributeValue In Me.ItemsAttributes  ' ein collection.Reload führt nicht dazu, das alle elemente neu geladen werden !
                    item.Reload()
                Next
            End If

        End Sub

        ''' <summary>
        ''' Ruft die ID eines Einkaufsrabatts ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DevExpress.Xpo.DisplayName("Rabatt")>
        <Persistent("Rabatt")>
        Private Property DiscountID() As Integer
            Get
                Return m_Rabatt
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RabattID", m_Rabatt, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Rabatt ab der für diesen Artikel angegeben wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Discount() As Discount
            Get
                If DiscountID > 0 Then
                    Return MainApplication.Discounts.GetItem(DiscountID)
                Else
                    Return Nothing
                End If

            End Get
            Set(ByVal value As Discount)
                If value IsNot Nothing Then
                    DiscountID = value.ID
                Else
                    DiscountID = 0
                End If
            End Set
        End Property

        <ComponentModel.Browsable(False)>
        <Persistent("FixedGrpPreis")>
        Public Property FixedGroupPrice() As Boolean
            Get
                Return m_fixedGroupPrice
            End Get
            Set(ByVal value As Boolean)

                SetPropertyValue(Of Boolean)("FixedGroupPrice", m_fixedGroupPrice, value)
            End Set
        End Property

        <Obsolete("Nicht benutzen, wird nicht ausgewertet")>
        <Browsable(False)>
        <Persistent("GewinnTypeProz")>
        Private Property GewinnTypeProzent() As Boolean
            Get
                'Return m_GewinnTypeProzent
                Return False
            End Get
            Set(ByVal value As Boolean)
                'm_GewinnTypeProzent = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Gewicht in Kilogramm ab oder legt das fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()>
        <Tools.DefaultGridVisible(EditorBrowsableState.Advanced)>
        <Tools.DisplayName("Weight", "Gewicht (Kg)")>
        <Persistent("Gewicht")>
        Public Property Weight() As Decimal
            Get
                Return m_gewicht
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Weight", m_gewicht, value)
            End Set
        End Property

        ''' <summary>
        ''' Ist wahr, wenn noch kein Gewicht gesetzt wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Weightset As Boolean
            Get
                Return m_gewicht = -1
            End Get
        End Property

        ''' <summary>
        ''' Zeigt an, ob dieser Eintrag änderbar ist, kann eine Sperre enthalten.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Verwendung nicht klar definiert. Statttdessen neue Datensatzsperen verwenden!")>
        <Browsable(False)>
        <Persistent("Änderbar")>
        Public Property IsUserLocked() As Boolean
            Get
                'TODO: Von wem änderbar / von wem nicht ? 
                Return m_userLocked
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsUserLocked", m_userLocked, value)
            End Set
        End Property



        ''' <summary>
        ''' Ruft eine Kurzbezeichnung des Datanorm-Erstellers ab oder legt diese fest.
        ''' Zusammen mit der Datenoemartikelnummer kann ein Datanorm-Artikel eindeutig festgestellt werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>      
        <Indexed()>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)>
        <Persistent("dtnersteller")>
        Public Property DatanormErsteller() As String
            Get
                Return m_dtnersteller
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("DatanormErsteller", m_dtnersteller, value)
            End Set
        End Property


        ''' <summary>
        ''' Entspricht der kleinsten Abgabemenge. 
        ''' Bsp: Ein Speicherriegel wird immer paarweise Verkauft (Paar Riegel), dann steht hier eine 2.
        ''' Im Einkauf Erhalte ich aber die Speicherriegel nur als "Pack" zu je 10 Stück, dann steht bei Liefereinheit die 10. 
        '''  Das entspricht dann 5 Pärchen (10 Stück / 2 Paar pro Verkauf = 5 Verkaufbare einheiten)
        ''' Bsp. Kabel auf Rolle wird in 1 Meter verkauft, dann steht hier eine 1, bei Liefereinheit aber 100 Meter
        '''  Kabel wird immer 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()>
        <Tools.DisplayName("MinSellCount", "Anzahl Liefereinheiten")>
        <Persistent("AnzLiefereinheiten")>
        Public Property MinSellCount() As Decimal
            Get
                If m_AnzahlLiefereinheiten = 0 Then
                    m_AnzahlLiefereinheiten = 1
                    MinSellCount = 1
                End If
                Return m_AnzahlLiefereinheiten
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MinSellCount", m_AnzahlLiefereinheiten, value)
            End Set
        End Property

        ''' <summary>
        ''' Entspricht der Menge, auf die sich der Einkaufspreis bezieht.
        ''' Bsp. Hier steht eine 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()>
        <Tools.DisplayName("MindeliveryCount", "VP-Anzahl")>
        <Persistent("VPAnzahl")>
        Public Property MinDeliveryCount() As Decimal
            Get
                If m_VPAnzahl = 0 Then
                    m_VPAnzahl = 1
                    MinDeliveryCount = 1
                End If
                Return m_VPAnzahl
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MinDeliveryCount", m_VPAnzahl, value)

            End Set
        End Property


        <DevExpress.Xpo.DisplayName("Anhänge")>
        Public ReadOnly Property Attachments() As Generic.List(Of Attachment) Implements IAttachments.Attachments

            Get

                Return MainApplication.AttachmentRelations.GetAttachmentsBySourceID(Me.ReplikID)

            End Get
        End Property



        Private m_DTNRabattGruppe As String



        Private m_DTNWarengruppe As String


        Private m_KategorieID As String

        ''' <summary>
        ''' Ruft die interne Kategorie-ID ab oder legt diese fest (Nicht mehr verwendet in ab 1.7)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("KategorieID")>
        Private Property KategorieID() As String
            Get
                Return m_KategorieID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("KategorieID", m_KategorieID, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft die datanorm-Warengruppe ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("DTNWarengruppe")>
        Public Property DatanormWarengruppe() As String
            Get
                Return m_DTNWarengruppe
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DatanormWarengruppe", m_DTNWarengruppe, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die bezeichnung der Datanorm-Rabattgruppe ab oder legt diese fets
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("DTNRabattGruppe")>
        Public Property DatanormRabattGruppe() As String
            Get
                Return m_DTNRabattGruppe
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DatanormRabattGruppe", m_DTNRabattGruppe, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft die Datanorm-Hauptwarengruppenbezeichnung ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("DTNHauptwarengruppe")>
        Public Property DatanormHauptwarengruppe() As String
            Get
                Return m_DTNHauptwarengruppe
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("DatanormHauptwarengruppe", m_DTNHauptwarengruppe, value)
            End Set
        End Property


        ''' <summary>
        ''' Prüfe einige Felder auf nicht-leere Eigenschaften vor dem Speichern
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnSaving()
            If ManufactorsArticleNumber Is Nothing Then
                ManufactorsArticleNumber = ""
            End If

            If InternalArticleNumber Is Nothing Then
                InternalArticleNumber = ""
            End If

            If InternalArticleNumber Is Nothing Then
                InternalArticleNumber = ""
            End If

            'wurde diese nicht vergeben, dann die Artikelnummer festlegen
            If InternalArticleNumber = "" Then
                If Me.ID = -1 Then
                    Dim sql As String = "SELECT MAX(ID) from " & Article.TableName
                    Dim result As Integer
                    Try
                        Dim resultobj As Object
                        resultobj = MainApplication.Database.ExcecuteScalar(sql)
                        If Not TypeOf resultobj Is DBNull Then
                            result = CInt(resultobj)
                        End If

                    Catch
                    Finally
                        InternalArticleNumber = CStr(result + 1)
                    End Try

                Else
                    InternalArticleNumber = CStr(ID)
                End If


            End If

            If CustomerArticleNumber Is Nothing Then
                CustomerArticleNumber = ""
            End If

            If Me.HWLID Is Nothing Then
                Me.HWLID = MainApplication.ApplicationID
            End If

            If Me.GroupID Is Nothing Then
                Me.GroupID = ""
            End If

            ' wird nicht mehr verwendet
            If Me.KategorieID Is Nothing Then
                Me.KategorieID = ""
            End If

            If Me.LongDescription Is Nothing Then
                Me.LongDescription = ""
            End If

            If Me.ShortDescription Is Nothing Then
                Me.ShortDescription = ""
            End If

            If Me.DatanormArtikelnummer Is Nothing Then
                Me.DatanormArtikelnummer = ""
            End If

            If Me.DatanormErsteller Is Nothing Then
                Me.DatanormErsteller = ""
            End If

            If Me.DatanormHauptwarengruppe Is Nothing Then
                Me.DatanormHauptwarengruppe = ""
            End If

            If Me.DatanormRabattGruppe Is Nothing Then
                Me.DatanormRabattGruppe = ""
            End If

            If Me.DatanormWarengruppe Is Nothing Then
                Me.DatanormWarengruppe = ""
            End If

            'Preisberechnung überbrücken, falls nicht korrekt aufgefüllt
            If Not FixedPrice Then
                EinzelVK = CalulatedEndPrice
            End If


            ' Auch die Bilder abspeichern
            If m_ImageList IsNot Nothing Then
                Me.ImageList.Save()

                If Me.ImageList.Count > 0 Then
                    Me.ContainsPicture = True
                Else
                    Me.ContainsPicture = False
                End If

            End If


            MyBase.OnSaving()


        End Sub


        ''' <summary>
        ''' Ruft eine Auflistung von Anhängen dieses Dokuemntes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)>
        Public ReadOnly Property AttachmentLinks() As AttachmentsRelations Implements IAttachments.AttachmentLinks
            Get
                If m_attachmentRelations Is Nothing Then
                    Dim criteria As Filtering.CriteriaOperator = Filtering.CriteriaOperator.Parse("SourceDocumentID='" & Me.ReplikID & "'")
                    m_attachmentRelations = New AttachmentsRelations(MainApplication, criteria)
                End If

                Return m_attachmentRelations

            End Get

        End Property

        ''' <summary>
        ''' Ruft den bisherigen alten Wert ab, der auf dieem Feld stand
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(50)>
        <Obsolete("Altes Feld, nicht mehr verwenden")>
        <DevExpress.Xpo.DisplayName("Geändert am")>
        <Persistent("Geändertam")>
        Public Property ChangedAtOld() As String
            Get
                If m_changedAt.HasValue Then
                    Return m_changedAt.Value.ToString("d")
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    m_changedAt = Nothing
                    SetPropertyValue(Of String)("ChangedAtOld", Nothing)
                Else
                    Dim DateValue As Date

                    If DateTime.TryParse(value, DateValue) Then
                        m_changedAt = DateValue
                        SetPropertyValue(Of String)("ChangedAtOld", DateValue.ToString)

                    Else
                        m_changedAt = Nothing
                        SetPropertyValue(Of String)("ChangedAtOld", Nothing)
                    End If
                End If

            End Set
        End Property

        ''' <summary>
        ''' Ruft den bisherigen Wert ab, an dem der Artikel erstellt wurde, druch nativen Datentyp geändert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(50)>
        <Obsolete("Altes Feld, nicht mehr verwenden")>
        <DevExpress.Xpo.DisplayName("Angelegt am")>
        <Persistent("Angelegtam")>
        Public Property CreatedAtOld() As String
            Get
                If m_createdAt.HasValue Then
                    Return m_createdAt.Value.ToString("d")
                Else
                    Return Nothing
                End If
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    m_createdAt = Nothing
                    SetPropertyValue(Of String)("CreatedAtOld", Nothing)
                Else
                    Dim DateValue As Date
                    If DateTime.TryParse(value, DateValue) Then
                        m_createdAt = DateValue
                        SetPropertyValue(Of String)("CreatedAtOld", DateValue.ToString)
                    Else
                        m_createdAt = Nothing
                        SetPropertyValue(Of String)("CreatedAtOld", Nothing)
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Ruft den netto einzel VK pro einzelner Einheit ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()>
        <Tools.DisplayName("ArticleSingleEndPriceWithoutTax", "Verkaufspreis (netto)")>
        <Persistent("VKProeinheit")>
        Public Property EinzelVK() As Decimal
            Get
                Return m_VerkaufspreisProEinheit
            End Get
            Set(ByVal value As Decimal)

                SetPropertyValue(Of Decimal)("EinzelVK", m_VerkaufspreisProEinheit, value)
                If Not IsLoading Then
                    ' VK steuert Gewinn, 
                    GewinnAbsolut = value - GetResourcesPrice
                End If

            End Set
        End Property

        ''' <summary>
        ''' ID der Verpackungseinheit
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DevExpress.Xpo.DisplayName("VP Einheit")> _
        <Browsable(False)> _
        <Persistent("VPEinheit")> _
        Private Property VerpackungsEinheitID() As Integer
            Get
                Return m_VerpackungsEinheitID
            End Get
            Set(ByVal value As Integer)

                SetPropertyValue(Of Integer)("VerpackungsEinheitID", m_VerpackungsEinheitID, value)
            End Set
        End Property

        <Browsable(False)> _
        Public Property VerpackungsEinheit() As Unit
            Get
                Return MainApplication.Units.GetItem(Me.VerpackungsEinheitID)
            End Get
            Set(ByVal value As Unit)
                If value IsNot Nothing Then
                    VerpackungsEinheitID = value.ID
                End If

            End Set
        End Property

        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <DevExpress.Xpo.DisplayName("VK Einheit")> _
        Public ReadOnly Property VerpackungsEinheitName() As String
            Get
                Dim unit As Unit = MainApplication.Units.GetItem(Me.VerpackungsEinheitID)
                If unit IsNot Nothing Then
                    Return unit.Name
                Else
                    Return Nothing
                End If
            End Get

        End Property

        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <DevExpress.Xpo.DisplayName("Rechen-Einheit")> _
        Public ReadOnly Property RecheneinheitName() As String
            Get
                Dim unit As Unit = MainApplication.Units.GetItem(Me.RecheneinheitID)
                If unit IsNot Nothing Then
                    Return unit.Name
                Else
                    Return Nothing
                End If
            End Get

        End Property



        ''' <summary>
        ''' Ruft die Rechenenheit ab oder legt diese feest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        Public Property Recheneinheit() As Unit
            Get
                Dim unit As Unit = MainApplication.Units.GetItem(Me.RecheneinheitID)
                Return unit
            End Get
            Set(ByVal value As Unit)
                If value IsNot Nothing Then
                    Me.RecheneinheitID = value.ID
                Else
                    Me.RecheneinheitID = 0
                End If

            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID der verwendeten Recheninheit ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        <Persistent("Recheneinheit")> _
        Private Property RecheneinheitID() As Integer
            Get
                Return m_Recheneinheit
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RecheneinheitID", m_Recheneinheit, value)
            End Set
        End Property

        <Size(50)> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Persistent("Abmessung")> _
        Public Property Abmessung() As String
            Get
                Return m_Abmessung
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Abmessung", m_Abmessung, value)
            End Set
        End Property

        <Obsolete("Nichtmehr verwendet")> _
        <ComponentModel.Browsable(False)> _
        <Persistent("Form")> _
        Private Property Form() As Integer
            Get
                Return 0
            End Get
            Set(ByVal value As Integer)

            End Set
        End Property

        ''' <summary>
        ''' Ruft den Lieferanten ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Association("Contact", GetType(Adress))> _
        Public Property Lieferant() As Kernel.Adress
            Get
                Dim adress As Adress = MainApplication.Adressen.GetItem(Me.LieferantID)

                If adress Is Nothing Then
                    Return Nothing
                Else
                    Return adress
                End If
            End Get
            Set(ByVal value As Kernel.Adress)
                LieferantID = value.ID
            End Set
        End Property

        ''' <summary>
        ''' Setzt die Lieferanten-Adresse durch ID oder ruft diese ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>        
        <Browsable(False)> _
        <Persistent("Lieferant")> _
        Public Property LieferantID() As Integer
            Get
                Return m_adressID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("LieferantID", m_adressID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ist True, wenn mindestends ein Bild diesem Artikel zugeordnet wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <ComponentModel.Browsable(False)> _
        <Persistent("HatBild")> _
        Public Property ContainsPicture() As Boolean
            Get
                Return m_containePicture
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("HatBild", m_containePicture, value)
            End Set
        End Property

        <ComponentModel.Browsable(False)> _
        Public Property Priority() As Integer
            Get
                Return m_Priorität
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Priority", m_Priorität, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen textuellen Bezeiczner ab, der den Gewinnwert enthält, 
        ''' Kann ein Zahlenwert sein, oder ein Wert mit einem % - Zeichen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(50)> _
        <Browsable(False)> _
        <Persistent("Gewinn")> _
        Private Property Aufschlag() As String
            Get
                If String.IsNullOrEmpty(m_Gewinnspanne) Then
                    Aufschlag = "0"
                    m_Gewinnspanne = "0"
                End If
                Return m_Gewinnspanne
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("Gewinnspanne", m_Gewinnspanne, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt die Art des Aufschlages fest: Ein Absoluter Wert wird bei wechselnden Einkaufspreisen stets gleich hoch gelassen, (Gewinn stets gleich hoch)
        ''' Ein relativer Wert schwankt mit der Höhe des Einkaufspreises, Sgteigt der EK, steigt auch der absolute Gewinn.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Relativ: Gewinn in % vom EK, dann steigt bei einer 10% Einkaufspreiserhöhung der Artikel um 10% plus den Prozentsatz des eigenen Gewinnaufschlages.
        ''' Der Endpreis erhöht sich also um mehr als 10%. Bsp: Gewinnmarge liegt bei 20% vom Einkauf. EK steigt um 10%, dann ist der endpreis um 10% + 20% = 12 % teurer.
        ''' Absolut: Der Aufschlag ist ein fester Betrag, schwankt der Einkaufspreis, dann ändert sich der Verkaufspreis nur um den Betrag, der auch im EK zu sehen ist. 
        ''' Bsp.: Gewinnaufschlag liegt bei 10€, Einkaufspreis erhöht sich um 10%, Artikel kostet 100€, dann kostet der Artkel vorher: 110€, nach der Erhöhung: 110+10 = 120 euro, 10 Euro von 110€ Vk sind weniger als 10% teurer.
        ''' 
        ''' </remarks>
        Public ReadOnly Property GewinnType() As GewinnType
            Get
                If Aufschlag.EndsWith("%") Then
                    Return Kernel.GewinnType.IsRelative
                Else
                    Return Kernel.GewinnType.IsAbsolute
                End If
            End Get
        End Property

        ''' <summary>
        ''' Ruft den reinen Wert des Gewinns ab, enthält keine Info ob Absolut oder Relativbetrag
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GewinnValue() As Decimal
            Get
                Return CDec(Aufschlag.Trim("%"c))
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Gewinnwert als Absoulte Zahl ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GewinnAbsolut() As Decimal
            Get
                If Aufschlag.EndsWith("%") Then
                    Dim value As Decimal = CDec(Aufschlag.Trim("%"c))
                    value = value / 100

                    Return EinzelEK * value
                Else
                    Return CDec(Aufschlag)
                End If
            End Get
            Set(ByVal value As Decimal)
                Aufschlag = CStr(value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Gewinnwert als Prozentualen Wert von Einkauspreis ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property GewinnRelativ() As Decimal
            Get
                If Aufschlag.EndsWith("%") Then
                    Dim value As Decimal = CDec(Aufschlag.Trim("%"c))
                    Return value
                Else
                    Dim value As Decimal = CDec(Aufschlag)
                    If EinzelEK <> 0 Then
                        value = (value / EinzelEK) * 100
                    End If
                    Return value
                End If
            End Get

            Set(ByVal value As Decimal)
                Aufschlag = CStr(value) & "%"
            End Set
        End Property

        ''' <summary>
        ''' Ruft den netto-EK pro Einheit ab oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()> _
        <Tools.DisplayName("SingleBasePrice", "Einzel EK")> _
        <Persistent("PreisProeinheit")> _
        Public Property EinzelEK() As Decimal
            Get
                Return m_einzelEK
            End Get
            Set(ByVal value As Decimal)

                SetPropertyValue(Of Decimal)("EinzelEK", m_einzelEK, value)
            End Set
        End Property



        ''' <summary>
        ''' Ruft die Anzahl der Minuten ab, die für diese Tätigkeit verwendet werden oder legt dies fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DevExpress.Xpo.DisplayName("Zeitdauer")> _
        <Persistent("TimeInMinutes")> _
        Public Property TimeInMinutes() As Integer
            Get
                Return m_timeInMinutes
            End Get

            Set(ByVal value As Integer)

                SetPropertyValue(Of Integer)("TimeInMinutes", m_timeInMinutes, value)
            End Set
        End Property


        ''' <summary>
        ''' Falls tätigkeit, wird das verwendete Lohnkonto abgerufen oder festgelegt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("LoanAccount", "Lohnkonto")> _
        <Tools.DefaultGridVisible(EditorBrowsableState.Advanced)> _
        Public Property LoanAccount() As LoanAccount
            Get
                Return MainApplication.LoanAccounts.GetItem(LoanAccountID)
            End Get

            Set(ByVal value As LoanAccount)

                LoanAccountID = value.Key
            End Set
        End Property

        <Persistent("LoanAccountID")> _
        Private Property LoanAccountID() As String
            Get
                Return m_loadAccountID
            End Get

            Set(ByVal value As String)

                SetPropertyValue(Of String)("LoanAccountID", m_loadAccountID, value)
            End Set
        End Property


        ''' <summary>
        ''' Ein True zeigt an, das deiser Eintrag eine Arbeitsleitung ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("isWorkItem", "Ist Tätigkeit")> _
        <Persistent("IsWorkItem")> _
        <DefaultValue(False)> _
        Public Property IsWorkItem() As Boolean
            Get
                Return m_isWorkItem
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsWorkItem", m_isWorkItem, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft einen längeren beschreibenden Text ab oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()> _
        <Size(SizeAttribute.Unlimited)> _
        <Tools.DisplayName("LongDescription", "Langtext")> _
        <Persistent("Beschreibung")> _
        Public Property LongDescription() As String
            Get
                Return m_longText & ""
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LongDescription", m_longText, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen EAN-Code ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("EANCode", "EAN Code")> _
    <Persistent("DTNEAN")> _
        Public Property EAN() As String
            Get
                Return m_EAN
            End Get
            Set(ByVal value As String)

                If Not String.IsNullOrEmpty(value) Then
                    If value.Length > 150 Then
                        value = value.Substring(0, 149)
                    End If
                End If

                SetPropertyValue(Of String)("EAN", m_EAN, value)

            End Set
        End Property


        ''' <summary>
        ''' Ruft einen einzeiligen Kurtztext ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.ImportableAttribute()> _
        <Size(255)> _
        <Indexed()> _
        <Tools.DisplayName("ShortDescription", "Kurztext")> _
        <Persistent("Name")> _
        Public Property ShortDescription() As String
            Get
                Return m_shortText
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = String.Empty
                If value.Length > 255 Then value = value.Substring(0, 254)

                SetPropertyValue(Of String)("ShortDescription", m_shortText, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID der Steuer ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        <Persistent("mwst")> _
        Public Property MWSTID() As Integer
            Get
                Return m_mwstID

            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("MWSTID", m_mwstID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den verwendeten Steuersatz für diesen Artikel ab oder legt dies fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <DevExpress.Xpo.DisplayName("Steuersatz")> _
        Public Property TaxRate() As TaxRate
            Get
                If MainApplication.TaxRates.GetItem(MWSTID) Is Nothing Then
                    Return MainApplication.TaxRates(0)
                Else
                    Return MainApplication.TaxRates.GetItem(MWSTID)
                End If
            End Get
            Set(ByVal value As TaxRate)
                If value IsNot Nothing Then
                    MWSTID = value.ID
                End If
            End Set
        End Property


        <Browsable(False)> _
        <Persistent("HWLID")> _
        Public Property HWLID() As String
            Get

                Return m_HWLID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HWLID", m_HWLID, value)

            End Set
        End Property

        ''' <summary>
        ''' Ruft die eindeutige, unveränderbare Datensatznummer ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DevExpress.Xpo.DisplayName("Dokumentennummer")> _
        Public ReadOnly Property DocumentID() As Integer
            Get
                Return MyBase.ID
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Me.ShortDescription
        End Function




        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        ''' <summary>
        ''' Klont den angegebenen Artikel und 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overrides Function Clone() As Object
            Dim newArticle As Article
            newArticle = CType(MyBase.Clone(), Article)

            ' Erzwingen, das eine neue ArtikelID generiert wird
            newArticle.ID = -1
            newArticle.InternalArticleNumber = ""

            ' nun noch die Bilder
            For Each item As ImageData In Me.ImageList
                Dim newImage As ImageData = CType(item.Clone, ImageData)
                newImage.ReferenceID = newArticle.Key
                newArticle.ImageList.Add(newImage)

            Next

            'Nun Stückliste, falls vorhanden
            For Each item As BOM.ArticleLink In Me.SubArticles
                Dim newLink As BOM.ArticleLink = CType(item.Clone, BOM.ArticleLink)
                newLink.ParentArticleID = newArticle.Key
                newArticle.SubArticles.Add(newLink)
            Next

            ' Nun die Attachment-Links kopieren
            For Each item As AttachmentsRelation In Me.AttachmentLinks

                Dim newLink As AttachmentsRelation = CType(item.Clone, AttachmentsRelation)
                newLink.SourceDocumentID = newArticle.ReplikID
                newArticle.AttachmentLinks.Add(newLink)
            Next

            Return newArticle
        End Function


    End Class
End Namespace