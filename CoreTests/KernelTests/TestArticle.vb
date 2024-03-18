Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Kernel


<Description("Testst Eigenschaften der Artikelverwaltung")> _
<Category("Artikels")> _
<TestFixture()> _
Public Class TestArticle

    <Test()> _
    Public Sub ArtikelTestSomeProperties()
        Dim a As Article = MainApplication.getInstance.ArticleList.GetNewItem

        a.Abmessung = "12meter"
        a.AddIngoing(100) ' Angfangsbestand (100 Hinzufügen
        a.AddOutBound(25) ' 25 entfernen


        Assert.NotNull(a.ArticlesHirachy.Count, "Artikelhierachie ist nothing")
        Assert.NotNull(a.AttachmentLinks.Count, "AttachmentLinks ist nothing")
        Assert.NotNull(a.Attachments, "Attachments sind nicht null")
        Assert.NotNull(a.Attachments.Count, "Attachments ist nothing")

        Assert.NotNull(a.ItemsAttributes, "Artikelattribute waren nothing")
        Assert.IsTrue(a.ItemsAttributes.Count >= 0, "Anzahl Artikelattribte konnte nicht geholt werden")

        Assert.NotNull(a.CalulatedEndPrice, "ein Fehler trat auf")
        Assert.IsFalse(a.ContainsPicture, "Kann noch kein Bild besitzen")


        Assert.NotNull(a.DefaultImage, "Jedem Artikel wird mindesteends das 'leere' Image angezeigt")
        ' a.GroupName = "testgruppe"  ' Testgruppe anlegen 
        'IMPORTANT: Test mit der Gruppe wieder einnehmen!

        StringAssert.AreEqualIgnoringCase(a.GroupName, a.Group.Name, "Angelegte Gruppe konnte nicht ermittelt werden. (Erwartet:'" & a.GroupName & "', erhalten:'" & a.Group.Name & "'")



    End Sub

    <Test(Description:="Setzt allgemeine Einstellungen für Artikellisten ")>
    Public Sub ShowSettings()
        Assert.NotNull(MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate, "setting: Standard Setuersatz sollte nicht null sein")
        Assert.NotNull(MainApplication.getInstance.Settings.Articlesettings.ShowInactiveItems, "Setting: Inaktive Elemente sollte einen wert zurückgeben")

        MainApplication.getInstance.Settings.Articlesettings.ShowInactiveItems = True
        Assert.IsTrue(MainApplication.getInstance.Settings.Articlesettings.ShowInactiveItems, "ShowInactiveItems: sollte True sein ")


        MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate = MainApplication.getInstance.TaxRates.GetNormalTax


        Assert.AreEqual(MainApplication.getInstance.TaxRates.GetNormalTax, MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate, "Steuzersatz konnte nicht gesetzt werden")

        MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate = MainApplication.getInstance.TaxRates.GetReducedTax
        Assert.AreEqual(MainApplication.getInstance.TaxRates.GetReducedTax, MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate, "Steuzersatz konnte nicht gesetzt werden")

        MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate = MainApplication.getInstance.TaxRates.GetNormalTax
        Assert.AreEqual(MainApplication.getInstance.TaxRates.GetNormalTax, MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate, "Steuzersatz konnte nicht gesetzt werden")



    End Sub

    <Test(Description:="Einfacher Attribute-Test")>
    Public Sub TestAttributes()
        Dim a As Article = MainApplication.getInstance.ArticleList.GetNewItem

        Assert.NotNull(a.ItemsAttributes, "Artikelattribute waren nothing")
        Assert.IsTrue(a.ItemsAttributes.Count >= 0, "Anzahl Artikelattribte konnte nicht geholt werden")

        Dim newattributeDef As Attributes.AttributeValueDefinition = New Attributes.AttributeValueDefinition(MainApplication.getInstance.Session)
        newattributeDef.AttributeName = "TestName"
        newattributeDef.AttributeType = enumAttributeType.Alphanummeric

        Assert.IsFalse(newattributeDef.IsInUse, "Neu angelegtes Attribut darf nicht in Benutzung sein")



        newattributeDef.Save()
        newattributeDef.Delete()
    End Sub
    <Test(Description:="Stückliste (BOM)")>
    Public Sub testBOM()
        Dim a As Article = MainApplication.getInstance.ArticleList.GetNewItem

        Assert.NotNull(a.SubArticles, "Sub Artikelliste darf kein Nothing zurückgeben")
        Assert.NotNull(a.GetParentArticles, "Parent Artikelliste darf kein Nothing zurückgeben")

        Assert.NotNull(a.SubArticles.GetArticles, "Artikelliste sollte nicht nothing sein")
        'TODO: Ein Sub-Artikel einfügen und damit auch mal testen
        Assert.IsTrue(a.SubArticles.GetTotalBasePrice >= 0, "Errechneter Basispreis sollte abgefragt werden können")
        Assert.IsTrue(a.SubArticles.GetTotalendPrice >= 0, "Errechneter Basispreis sollte abgefragt werden können")
        Assert.IsTrue(a.SubArticles.GetTotalTime >= 0, "Errechneter Zeitbasis sollte abgefragt werden können")

        Dim newbaseItemas As BOM.ArticleLink = a.SubArticles.GetNewItem

        newbaseItemas.ParentArticleID = a.Key

        Dim newsubItem As BOM.ArticleLink = a.SubArticles.GetNewItem(a)
        Assert.IsTrue(newsubItem.Quantity = 1, "Neues SubItem in der Stückliste sollte immer mindestends die Anzahl '1' haben")

    End Sub

    <Test(Description:="Testet Artikelersetzungen")>
    Public Sub TestReplacements()
        Dim a As Article = MainApplication.getInstance.ArticleList.GetNewItem


        Assert.NotNull(a.GetPredecessorItems, "Auflistung der Nachfolgeartikel darf nicht leer sein")
        Assert.NotNull(a.GetSucccessorItem, "Auflistung der Vorgängerartikel darf nicht leer sein")


        Dim b As Article = MainApplication.getInstance.ArticleList.GetNewItem
        a.GetSucccessorItem.Add(b)
        a.Save()
        b.Save()



        a.Reload()
        ' Nun hat A Nachfolger un B Vorgänger


        '    Assert.IsTrue(a.GetSucccessorItem.Count = 1, "Es sollte nun ein Nachfolger existieren")
        '    Assert.IsTrue(b.GetPredecessorItems.Count = 1, "Es sollte nun ein Vorgänger existieren")



    End Sub


    <Test(Description:="Erstellt eine kleine Vorschau eines Bildes")>
    Public Sub TestThumbnails()
        Using bigImage As New System.Drawing.Bitmap(500, 500) ' Leeres Bild erzeugen 

            Dim newArticle As Article = MainApplication.getInstance.ArticleList.GetNewItem
            newArticle.DefaultImage = bigImage

            Assert.NotNull(newArticle.ArticleThumbnail, "es konnte kein Thumbnail -Bild für den Artikel angelegt werden")

        End Using

    End Sub

    <Test(Description:="")>
    Public Sub TestArticleClone()
        Dim imageArticle As Article = MainApplication.getInstance.ArticleList(0)

        ' Falls am Artikel noch kein Bild hängt, eins anheften
        If MainApplication.getInstance.Images.Count = 0 Then
            MainApplication.getInstance.Images.Add(New ImageData(MainApplication.getInstance.Session))
            MainApplication.getInstance.Images(0).Image = New System.Drawing.Bitmap(500, 500)
            MainApplication.getInstance.Images.Save()
        End If

        If imageArticle.ImageList.Count = 0 Then
            imageArticle.ImageList.Add(MainApplication.getInstance.Images(0))
            imageArticle.Save()
        End If

        Dim clonedArticlde As Article = CType(imageArticle.Clone, Article)

        Assert.IsTrue(clonedArticlde.ImageList.Count > 0, "Nach dem Klonen war die Bilder-Liste leer, obwohl ein Bild erwartet wurde")



        'TODO: Stücklisten und Attachment-Links testen

    End Sub

    <Test(Description:="Ein Artikel, der in einerm Journaldokument verwendet wird, darf nicht gelöscht werden. (Anwender kann den 'inaktiv' setzen")>
    Public Sub TestExternalReferences()
        '34240M
        Dim refArticle As Article = MainApplication.getInstance.ArticleList.GetItem(34240)
        If refArticle IsNot Nothing Then
            Assert.IsTrue(refArticle.IsInJournal, "Artikel ist Bestandteil eines Journaldokumentes. die Prüfung war aber negativ.")
        Else
            Throw New Exception("artikel nicht gefunden")
        End If

    End Sub

End Class

