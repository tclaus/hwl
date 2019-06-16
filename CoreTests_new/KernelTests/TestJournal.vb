Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Kernel

Imports DevExpress.Xpo


<TestFixture(Description:="Journal")> _
Public Class TestJournal

    <Test(description:="Prüft das Journal-Adressfenster Nach Zuweisung einer Adresse. (Inhalte sollten gleich sein)")> _
    Public Sub JournalDocument()
        Dim newItem As JournalDocument = MainApplication.getInstance.JournalDocuments.GetNewItem

        newItem.Address = MainApplication.getInstance.Adressen(0) ' Adressen zuweisen

        StringAssert.AreEqualIgnoringCase(newItem.AddressWindow, newItem.Address.InvoiceAdressWindow, "Bei der Zuweisung einer Adresse sollte das Adressfenster übergeben werden")

        Assert.NotNull(newItem.AddressWindow, "Adressfenster darf nicht null sein")

        Assert.IsTrue(newItem.CreatedAt = Today, "Created At sollte im Standard auf heute stehen")

    End Sub

    <Test(Description:="Legt ein neuen Journaleintrag an und speichert diesen")>
    Public Sub TestCreateJournalDocument()
        Dim newDocument As JournalDocument = MainApplication.getInstance.JournalDocuments.GetNewItem
        newDocument.Address = MainApplication.getInstance.Adressen(0) ' Adressen zuweisen

        Dim itemGroup1 As New Kernel.JournalArticleGroup(newDocument) ' Neu aus Collection
        Assert.AreEqual(itemGroup1.ParentDocument, newDocument, "Vater der Artikelgruppe sollte das Journaldokument sein")

        itemGroup1.HeaderText = "Testgruppe1"

        Dim itemGroup2 As Kernel.JournalArticleGroup = newDocument.GetNewArticleGroup
        Assert.AreEqual(itemGroup2.ParentDocument, newDocument, "Vater der Artikelgruppe sollte das Journaldokument sein")


        Dim Poscount As Integer = 12
        Dim Itemcount As Integer = 5
        Dim itemPrice As Decimal = 123

        Dim newarticle As JournalArticleItem = itemGroup1.GetNewItem
        newarticle.ItemCount = Itemcount
        newarticle.ItemName = "testartikel"
        newarticle.SinglePriceBeforeTax = itemPrice
        itemGroup1.ItemCount = Poscount

        newDocument.Save()
        ' Das sollte geklappt haben... 
        Debug.Print("Summe Artikelgruppe (DisplaySinglePrice):" & itemGroup1.DisplaySinglePrice)
        Debug.Print("Summe Artikelgruppe (DisplayTotalPrice):" & itemGroup1.DisplayTotalPrice)
        Debug.Print("Summe dokument (DisplayBasePrice)" & newDocument.DisplayBasePrice)

        Assert.AreEqual(itemGroup1.DisplayTotalPrice, Poscount * Itemcount * itemPrice, "Der berechnete Gesamtpreis stimmt nicht mit der Erwartung überein. Soll " & Poscount * Itemcount * itemPrice & ", ist:" & newDocument.TotalPriceBeforeTax & "")
        Assert.AreEqual(newDocument.TotalPriceBeforeTax, Poscount * Itemcount * itemPrice, "Der berechnete Gesamtpreis stimmt nicht mit der Erwartung überein. Soll " & Poscount * Itemcount * itemPrice & ", ist:" & newDocument.TotalPriceBeforeTax & "")

    End Sub

    <Test(Description:="Testet den Rabatt des Journals")>
    Public Sub TestJournalDiscount()

        ' Rabattwerte vom netto-Preis
        Dim newDocument As JournalDocument = MainApplication.getInstance.JournalDocuments.GetNewItem
        newDocument.Address = MainApplication.getInstance.Adressen(0) ' Adressen zuweisen

        newDocument.ShowWithoutTax = True  ' Damit beziehen sich Rabatte dann auf den Netto-Preis

        Dim itemGroup1 As New Kernel.JournalArticleGroup(newDocument) ' Neu aus Collection
        Assert.AreEqual(itemGroup1.ParentDocument, newDocument, "Vater der Artikelgruppe sollte das Journaldokument sein")

        itemGroup1.HeaderText = "Testgruppe1"


        Dim newarticle As JournalArticleItem = itemGroup1.GetNewItem
        newarticle.ItemName = "testartikel"
        newarticle.ItemCount = 12
        newarticle.SinglePriceBeforeTax = 100
        itemGroup1.ItemCount = 5

        ' Absolut; 
        ' Relativ testen 
        Debug.Print("Total Journal Price (before Discount): " & newDocument.TotalPriceBeforeTax)

        Dim currentBasePrice As Decimal = newDocument.TotalPriceBeforeTax



        newDocument.DiscountActive = True
        newDocument.DiscountIsAbsolut = True
        newDocument.DiscountValue = 10 ' 10€ abziehen

        Debug.Print("Total Journal Price (After 10€ Discount): " & newDocument.TotalPriceBeforeTax)
        ' Durch Rundnungsfehler ein delta bilden
        Assert.IsTrue((newDocument.DisplayedEndPrice - (currentBasePrice - 10)) < 0.0001, "Rabattwert (Absolut) wurde nicht korrekt berechnet. (war:" & newDocument.TotalPriceBeforeTax & ")")

        newDocument.DiscountIsAbsolut = False ' als Prozentualer Wert
        newDocument.DiscountValue = 12 ' 12% abziehen

        Debug.Print("Total Journal Price (After 12 % Discount): " & newDocument.TotalPriceBeforeTax)
        ' Durch Rundnungsfehler ein delta bilden

        Assert.IsTrue((newDocument.DisplayedEndPrice - (currentBasePrice * 0.88)) < 0.0001, "Rabattwert (Prozentual) wurde nicht korrekt berechnet. (war:" & newDocument.TotalPriceBeforeTax & ") ")

        '====================================================================
        '====================================================================
        ' Rabattwerte vom Brutto-Preis
        newDocument = MainApplication.getInstance.JournalDocuments.GetNewItem
        newDocument.Address = MainApplication.getInstance.Adressen(0) ' Adressen zuweisen

        newDocument.ShowWithoutTax = False  ' Damit beziehen sich Rabatte dann auf den Brutto-Preis

        itemGroup1 = New Kernel.JournalArticleGroup(newDocument) ' Neu aus Collection
        Assert.AreEqual(itemGroup1.ParentDocument, newDocument, "Vater der Artikelgruppe sollte das Journaldokument sein")

        itemGroup1.HeaderText = "Testgruppe1 (Brutto Preise)"

        newarticle = itemGroup1.GetNewItem
        newarticle.ItemName = "testartikel"
        newarticle.ItemCount = 12
        newarticle.SinglePriceBeforeTax = 100
        newarticle.TaxRate = MainApplication.getInstance.TaxRates.GetNormalTax ' 19%

        itemGroup1.ItemCount = 5

        ' Absolut; 
        ' Relativ testen 
        Debug.Print("Total Journal Price (before Discount): " & newDocument.DisplayedEndPrice) ' Nach den Steuern 

        Dim EndPriceBeforediscount As Decimal = newDocument.DisplayedEndPrice


        newDocument.DiscountActive = True
        newDocument.DiscountIsAbsolut = True
        newDocument.DiscountValue = 10 ' 10€ abziehen

        ' Durch Rundnungsfehler ein delta bilden
        Assert.IsTrue((newDocument.DisplayedEndPrice - (EndPriceBeforediscount - 10)) < 0.0001, "Rabattwert vom Brutto-Betrag (Absolut) wurde nicht korrekt berechnet. (war:" & newDocument.TotalPriceBeforeTax & ")")

        newDocument.DiscountIsAbsolut = False ' als Prozentualer Wert
        newDocument.DiscountValue = 12 ' 12% abziehen

        ' Durch Rundnungsfehler ein delta bilden
        Assert.IsTrue((newDocument.DisplayedEndPrice - (EndPriceBeforediscount * 0.88)) < 0.0001, "Rabattwert  vom Brutto-Betrag (Prozentual) wurde nicht korrekt berechnet. (war:" & newDocument.TotalPriceBeforeTax & ") ")




    End Sub

    <Description("Testet das Aufsummieren der einzelnen Journalelemente")>
    <Test()>
    Public Sub TestAccumulatedItems()
        ' 1. Allgemeine Funktion
        ' 2. Korrektes addieren

        Dim newDocument As JournalDocument = MainApplication.getInstance.JournalDocuments.GetNewItem
        newDocument.Address = MainApplication.getInstance.Adressen(0) ' Adressen zuweisen


        newDocument.AddArticleGroup(newDocument.ArticleGroups.GetNewItem)
        ' Artikel ermitteln
        newDocument.ArticleGroups(0).AddArticleItem(MainApplication.getInstance.ArticleList(1))
        ' Hier nun Artikel zuweisen

        newDocument.ArticleGroups(0).ArticleList(0).GetArticleItem.EinzelEK = 100  ' Basispreis temporär zuweisen
        newDocument.ArticleGroups(0).ArticleList(0).ItemCount = 2

        ' noch mal ein Artikel zuweisen
        newDocument.ArticleGroups(0).AddArticleItem(MainApplication.getInstance.ArticleList(1)) ' Der selbe Artikel, aber andere Eigenschaften
        newDocument.ArticleGroups(0).ArticleList(1).ItemCount = 1   ' Das sind nun 3 Artikel


        ' Aufsummierung feststellen
        Assert.IsTrue(newDocument.ListOfItems.Count = 2, "Anzahl der Artikel in der zusammengefassten Liste sollte 1 sein. (Mehrfach der selbe Artikel in der LIste)")

        Assert.IsTrue(newDocument.ListOfItems(0).ArticleSingleBasePrice = 100, "Basispreis eines Artikel stimmt in der zusammengefassten Auflistung nicht")



    End Sub

    <Test(Description:="Testet die Darstellung der Journaltypen")>
    Public Sub TestJournalTypes()
        Assert.NotNull(MainApplication.getInstance.JournalDocuments.DocumentTypeNames, "Journaltypen müssen gefüllt werden!")

        For Each item As JournalDocumentType In MainApplication.getInstance.JournalDocuments.DocumentTypeNames
            Assert.IsNotNullOrEmpty(item.Name, "Typename darf niemals leer sein !")
        Next

        'der "Alle" - Typ
        Dim allType As JournalDocumentType = MainApplication.getInstance.JournalDocuments.DocumentTypeNames.GetByDocumentID(enumJournalDocumentType.ALL)
        Assert.IsTrue(allType.InternalID = -1, "Der alle-Typ hatte die falsche Nummer")
        Assert.IsTrue(allType.IsALL, "Der ALLE-Typ wurde nicht erkannt!")
        Assert.IsTrue(allType.Visible, "Interner Typ 'ALLE' kann nicht unsichtbar werden")

        Trace.Write("Journaltyp ALLE: '" & allType.ToString & "'")

        Dim invoiceType As JournalDocumentType = MainApplication.getInstance.JournalDocuments.DocumentTypeNames.GetByDocumentID(enumJournalDocumentType.Rechnung)
        Assert.IsTrue(invoiceType.InternalID = enumJournalDocumentType.Rechnung, "Rechnungstyp hatte die falsche Nummer")
        Trace.Write("Journaltyp Rechnung: '" & invoiceType.ToString & "'")

        Dim reminderType As JournalDocumentType = MainApplication.getInstance.JournalDocuments.DocumentTypeNames.GetByDocumentID(enumJournalDocumentType.Mahnung)
        Assert.IsTrue(reminderType.InternalID = enumJournalDocumentType.Mahnung, "Mahnungstyp hatte die falsche Nummer")
        Trace.Write("Journaltyp reminder: '" & reminderType.ToString & "'")


    End Sub

    <Test(Description:="Testet das Stornieren (Canceln) ")>
    Public Sub TestCanceledDocument()
        Dim newDocument As JournalDocument = MainApplication.getInstance.JournalDocuments.GetNewItem
        newDocument.Address = MainApplication.getInstance.Adressen(0) ' Adressen zuweisen


        newDocument.Save()

        Assert.IsFalse(newDocument.IsCanceled, "Neue Dokumente dürfen nicht als 'gelöscht markiert sein")

        newDocument.SetCanceled()
        Assert.IsTrue(newDocument.IsCanceled, "Dieses Dokument sollte als 'gelöscht' markiert sein")


    End Sub
End Class
