
''' <summary>
''' Stellt eine RabattArt dar
''' </summary>
''' <remarks></remarks>
Friend Structure Rabattsatz
    ''' <summary>
    ''' Schlüsselnummer dieses Rabattes
    ''' </summary>
    ''' <remarks></remarks>
    Public RabattgruppenID As String

    ''' <summary>
    ''' Markiert die Art des Rabattes: Przentualer Rabat, Zuschlag oder Multiplikator
    ''' </summary>
    ''' <remarks></remarks>
    Public RabattKennzeichen As enumRabattkennzeichen

    ''' <summary>
    ''' Der ermittelte Wert des Rabattaes; kann entweder ein Prozentatz oder ein Multiplikator sein
    ''' </summary>
    ''' <remarks></remarks>
    Public Rabattwert As Decimal

    ''' <summary>
    ''' Name (Anzeigetext) des Rabattes
    ''' </summary>
    ''' <remarks></remarks>
    Public Rabattgruppenbezeichnung As String
End Structure

''' <summary>
''' KundenKontrollsatz (erster Datensatz im Datanorm) 
''' </summary>
''' <remarks></remarks>
Friend Structure KundenkontrollSatz
    Public Kundennummer As String
    Public Kundenanschrift1 As String
    Public Kundenanschrift2 As String
    Public Kundenanschrift3 As String
    Public Strasse As String
    Public Land As String
    Public Postleitzahl As String
    Public Ort As String

End Structure


Friend Structure zu_abschlagssatz
    Public satzartenkennzeichen As String
    Public verarbeitungsmerker As String
    Public artikelnummer As String
    Public zeilennummer As String
    Public bearbeitungsmerker As String
    Public textzeile As String
    Public anzeigezeile As String
    Public zuschlagart As String
    Public zu_abschlagskennzeichen As String
    Public preiskennzeichen As String
    Public preiseinheit As String
    Public prozentsatz As String
    Public basismerker As String
    Public VON As String
    Public BIS As String

End Structure


''' <summary>
''' Stellt einen Rohstoffsatz dar
''' </summary>
''' <remarks></remarks>
Friend Structure Rohstoffsatz
    Public satzkennzeichen As String
    ''' <summary>
    ''' N = Neuanlage von zuschlägen , A = Änderung Zuschläge, L = Löschen von zuchlägen
    ''' </summary>
    ''' <remarks></remarks>
    Public verarbeitungsmerker As String
    Public artikelnummer As String
    Public zeilennummer As String
    Public bearbeitungsmerker2 As String
    Public rohstoffmerker As String
    Public zuschlagart As String
    Public zuschlagkennzeichen As String
    Public preiskennzeichen As String
    Public preiseinheit As String
    Public prozentsatz As String
    Public VONRohstoffTagespreis As String
    Public BISRohstoffTagespreis As String
    Public umrechnungsfaktor As String
    Public rohstoffanteil As String
    Public rohstoffumrechnungsfaktor As String

End Structure

Friend Structure Rohstoffzuschlagsatz
    Public verarbeitungsmerker As String
    Public artikelnummer As String
    Public zeilennummer As String
    Public bearbeitungsmerker3 As String
    Public rohstoffmerker As String
    Public preiskennzeichen As String
    Public preiseinheit As String
    Public bezugspreisbasis As String
    Public umrechnungsfaktor_bezugspreis As String
    Public gewicht As String
    Public umrechnungsfaktor_gewichtsangabe As String
End Structure

''' <summary>
''' Stellt das Satzartenzeichen 'P' dar. Preisangaben und Preisänderungen
''' </summary>
''' <remarks></remarks>
Friend Structure Preisänderungssatz
    Public artikelnummer As String
    Public preiskennzeichen As enumPreisKennzeichen
    ''' <summary>
    ''' Preiseinheit pro stück. Normal 1, aber zB auch 100
    ''' </summary>
    ''' <remarks></remarks>
    Public preiseinheit As Decimal
    Public preis As Decimal
    ''' <summary>
    ''' eintrag nur dann, wenn Preiseinheit "1" (Listenpreis)
    ''' </summary>
    ''' <remarks></remarks>
    Public rabattgruppe As String
    Public rabattkennzeichen As enumRabattkennzeichen
    Public rabatt As Integer
    Public rabattkennzeichen2 As enumRabattkennzeichen
    Public rabatt2 As Integer
    Public rabattkennzeichen3 As enumRabattkennzeichen
    Public rabatt3 As Integer
    Public teuerungszuschlag As enumRabattkennzeichen
End Structure

Friend Structure Leitungssatz
    Public verarbeitungsmerker As String
    Public verwendungszweck As String
End Structure

Friend Structure LeitungssatzC1
    Public verarbeitungsmerker As String
    Public verwendungszweck As String
    Public artikelnummer As String
    Public werkstoffnummer As String
    Public handelsgewicht As String
    Public DINGewicht As String
    Public oberflächeab As String
    Public oberflächeme As String
    Public querschnittsmerker As String
    Public querschnitt As String
End Structure

Friend Structure Artikelstücklisten
    Public verarbeitungsmerker As String
    Public setnummer As String
    Public setmerker As String
    Public zeilennummer As String
    Public aufrufmerker As String
    Public artikelnummer As String
    Public menge As String
End Structure

Friend Structure Artikelset
    Public verarbeitungsmerker As String
    Public setnummer As String
    Public setmerker As String
    Public zeilennummer As String
    Public matchcode As String
    Public description As String
    Public aufrufmerker As String
    Public artikelnummer As String
    Public menge As String
End Structure

Friend Structure Leitungssatzc2
    Public verarbeitungsmerker As String
    Public verwendnungszweck As String
    Public artikelnummer As String
    Public mengeneinheit As String
    Public umrechnungsfaktor As String
End Structure


Friend Structure LeistungssatzZoll
    Public verarbeitungsmerker As String
    Public verwendungszweck As String
    Public artikelnummer As String
    Public warennummer As String
End Structure

Friend Structure LeistungssatzGefahrenVBF
    Public verarbeitungsmerker As String
    Public verwendungszweck As String
    Public artikelnummer As String
    Public gefahrenklasse As String
    Public volumen As String
    Public GGVSUnterklasse As String
    Public GGVSZiffer As String
    Public prozent As String
    Public bruttomasse As String
    Public flammpunktkennzeichen As String
End Structure

Friend Structure LeistungssatzGefahrenGGVS
    Public verarbeitungsmerker As String
    Public verwendungszweck As String
    Public artikelnummer As String
    Public UNnummer As String
    Public GGVSklasse As String
    Public GGVSUnterklasse As String
    Public GGVSziffer As String
    Public prozentanteil As String
    Public chemie As String
    Public faktor As String
    Public versandstück As String
End Structure

Friend Structure LeistungssatzFliesen
    Public verarbeitungsmerker As String
    Public verwendungszweck As String
    Public artikelnummer As String
    Public längemm As String
    Public breitemm As String
    Public stärkemm As String
    Public sortierung As String
    Public gruppe As String
    Public frostsicher As String
    Public abgabeeinheit As String
    Public stück As String
    Public gewicht As String
    Public stückjeabgabeeinheit As String
    Public palette As String
    Public rutschhemmung As String
    Public verdrängungsraum As String
    Public naßbereich As String
    Public ritzhärte As String
    Public kategorie As String
    Public typ As String
    Public serie As String
    Public seite As String
    Public position As String
    Public alternativmengeneinheit As String
    Public stückjealternativmengeneinheit As String
End Structure

Friend Structure LeistungssatzArbeitszeiten
    Public verarbeitungsmerker As String
    Public verwendungszweck As String
    Public leistungsentnummer As String
    Public merker1 As String
    Public merker2 As String
    Public arbeitszeit As String
    Public leistungsartikelnummer As String
End Structure

Friend Structure LeistungssatzArtikel
    Public verarbeitungsmerker As String
    Public verwendungszweck As String
    Public artikelnummer As String
    Public merker1 As String
    Public merker2 As String
    Public arbeitszeit As String
End Structure

Friend Structure LeistungssatzSach
    Public verarbeitungsmerker As String
    Public verwendungszweck As String
    Public artikelnummer As String
    Public lfd As String
    Public sachmerkmalnum As String
    Public sachmerkmalbez As String
    Public sachmerkmalbild As String
    Public sachmerkmalleisten As String
End Structure

''' <summary>
''' Stellt eine Struktur zur Anzeige von Grafiken an Artikeln bereit
''' </summary>
''' <remarks></remarks>
Friend Structure Grafikbindungssatz
    ''' <summary>
    ''' Beschreibt die Verarbeitungsart des Datensatzes
    ''' </summary>
    ''' <remarks></remarks>
    Public verarbeitungsmerker As enumVerarbeitungsmerker

    Public grafikanbindnummer As String
    Public zeilennummer As String
    Public anbindeart As String
    Public dateiname As String
    Public dateinamenzusatz As String
    Public kurzbeschreibung As String
End Structure

Friend Structure Dimensionssatz
    Public Dimensionstextnummer As String
    Public Verarbeitungsmerker As enumVerarbeitungsmerker
    Public unterkennzeichen As unterkennzeichen
    ''' <summary>
    ''' Stellt eine einzelne Textzeile dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Textzeile As String

    Public einfügetextbausteinnummer As String

    Public Zeilennummer As Integer
End Structure

''' <summary>
''' Stellt einen Text zur Verfügung
''' </summary>
''' <remarks></remarks>
Friend Structure Textsatz
    
    Public Verarbeitungsmerker As enumVerarbeitungsmerker
    ''' <summary>
    ''' Stellt das eindeutige Kennzeichen für diesen Text bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Textnummer As String
    ''' <summary>
    ''' Verwendungsart des Textes, zb Langtext, Dimensionstext
    ''' </summary>
    ''' <remarks></remarks>
    Public Merker As enumTextmerker
    ''' <summary>
    ''' Die Zeilennummer des Textbausteiens (wird ignoriert, es gilt die Reihenfolge des Einlesens)
    ''' </summary>
    ''' <remarks></remarks>
    Public Zeilennummer As Integer
    ''' <summary>
    ''' Enthält den Text
    ''' </summary>
    ''' <remarks></remarks>
    Public Textzeile As String
End Structure

''' <summary>
''' Stellt Artikel Lösch- Aufträge oder Artikelnummern - Ändeurngen dar
''' </summary>
''' <remarks></remarks>
Friend Structure ArtikelsatzB
    Public Verarbeitungsmerker As enumVerarbeitungsmerker
    ''' <summary>
    ''' Datanorm-Artikelnummer des betreffenden Artikels
    ''' </summary>
    ''' <remarks></remarks>
    Public Artikelnummer As String '2!
    ''' <summary>
    ''' Neue Artikelnummer, sofern bei einer Löschung dies angegeben ist, ist das die Artikelnummer eines Ersatzartikels.
    ''' </summary>
    ''' <remarks></remarks>
    Public EditedArtikelnummer As String '3!
    ''' <summary>
    ''' Ablaufdatum des Artikels. Danach ist der Artikel nicht mehr verfügbar
    ''' </summary>
    ''' <remarks></remarks>
    Public Auslaufdatum As DateTime '4! ...
End Structure

Friend Structure Dateiende
    ''' <summary>
    ''' Anzahl der übertragenen Zeilen, wie sie von Datenlieferanten angegeben wurden
    ''' </summary>
    ''' <remarks></remarks>
    Public Anzahl As String
    ''' <summary>
    ''' Schlussbemerkung des Datenlieferanten
    ''' </summary>
    ''' <remarks></remarks>
    Public Bemerkung As String
End Structure

''' <summary>
''' Beschreibt die erste Zeile in der Datei
''' </summary>
''' <remarks></remarks>
Friend Structure Vorlaufsatz
    ''' <summary>
    ''' Immer "V"
    ''' </summary>
    ''' <remarks></remarks>
    Public Satzkennzeichen As String
    ''' <summary>
    ''' "050" Zwingend
    ''' </summary>
    ''' <remarks></remarks>
    Public Version As String
    Public Datenkennzeichen As enumDatenkennzeichen
    Public Datum As Date
    Public Währung As String
    ''' <summary>
    ''' Dateninhaltsbeschreibung
    ''' </summary>
    ''' <remarks></remarks>
    Public FileContent As String
    Public Copyright As String
    ''' <summary>
    ''' Kürzel Datnersteller
    ''' </summary>
    ''' <remarks></remarks>
    Public Kuerzel As String
    Public AnschriftErsteller As String ' 3 Zeilen
    Public AnschriftStrasse As String
    Public AnschriftLand As String
    Public AnschriftPLZ As String
    Public AnschriftOrt As String

End Structure

''' <summary>
''' Enthält Daten zu einem neuen  oder geändertem Artikel
''' </summary>
''' <remarks></remarks>
Friend Structure Artikelsatz
    ''' <summary>
    ''' Zeigt an, ob der Artikel Neu oder geändert werden soll
    ''' </summary>
    ''' <remarks></remarks>
    Public Verarbeitungsmerker As enumVerarbeitungsmerker

    ''' <summary>
    ''' Enthält die eindeutige datanorm-Artikelnummer dieses Datenlieferanten
    ''' </summary>
    ''' <remarks></remarks>
    Public Artikelnummer As String
    Public KurzText1 As String
    Public KurzText2 As String

    ''' <summary>
    ''' Name der Mengeneinheit
    ''' </summary>
    ''' <remarks></remarks>
    Public Mengeneinheit As String
    ''' <summary>
    ''' Zeigt an, ob es sich um einen Listenpreis oder Empfohlenen VK handelt
    ''' </summary>
    ''' <remarks></remarks>
    Public Preiskennzeichen As enumPreisKennzeichen
    ''' <summary>
    ''' Anzahl der einheiten in einem Bündel, normalerweise 1. Kann auch zb 10 sein für 10 Artikel zu diesem Preis
    ''' </summary>
    ''' <remarks></remarks>
    Public Preiseinheit As Integer
    Public Preis As Decimal
    Public Rabattgruppe As String

    ''' <summary>
    ''' Stellt eine Kennung einer Hauptwarengruppe dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Hauptwarengruppe As String
    ''' <summary>
    ''' Stellt eine Kennung einer Unterwarengruppe dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Warengruppe As String
    Public Matchcode As String
    ''' <summary>
    ''' Kurzzeichen der Alternativnummer. wird nur gesetzt, wenn alternative artikelnummer gesetzt ist
    ''' </summary>
    ''' <remarks></remarks>
    Public KuerzelAlternativArtikelnummer As String
    ''' <summary>
    ''' Alternative Artikelnummer.
    ''' </summary>
    ''' <remarks></remarks>
    Public Alterartikelnummer As String
    ''' <summary>
    ''' Kurzzeichen Herstellernummer
    ''' </summary>
    ''' <remarks></remarks>
    Public KuerzelHerstellernummer As String
    ''' <summary>
    ''' Hersteller Artikelnummer, zb wenn keine EAN vorhanden ist oder eigene Artikel-Nummern d. Herstellers zur Verfügung stehen
    ''' </summary>
    ''' <remarks></remarks>
    Public Herstellernummer As String

    ''' <summary>
    ''' Typenangabe des Herstellern
    ''' </summary>
    ''' <remarks></remarks>
    Public HerstellerArtikelType As String
    Public EAN As String
    ''' <summary>
    ''' Anbindnummer für den Grafiksatz
    ''' </summary>
    ''' <remarks></remarks>
    Public AnbindnummerGrafik As String

    ''' <summary>
    ''' Anzahl der Bündel in einer Lieferung
    ''' </summary>
    ''' <remarks></remarks>
    Public Mindesverpackungsmenge As Integer
    ''' <summary>
    ''' Katalogseite des Herstellers
    ''' </summary>
    ''' <remarks></remarks>
    Public Katalogseite As String
    ''' <summary>
    ''' Kennzeichnet die Art der Textaufbereitung
    ''' 1 = Kurztext1, Kurztext 2
    ''' 2 = Langtext, Kurztext 2, Kurztext 1
    ''' 3 = Langtext, dimensionstext
    ''' 4 = 
    ''' </summary>
    ''' <remarks></remarks>
    Public Textkennzeichen As enumTextKennzeichen
    ''' <summary>
    ''' Bei angabe einer Langtxtnummer wird ein späterer Textbaustein (Satzart T) erwartet und an diesem Artikel angeknüpft
    ''' </summary>
    ''' <remarks></remarks>
    Public Langtextnummer As String
    ''' <summary>
    ''' Kostenart- Nr. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Kostenart As String
    ''' <summary>
    ''' Information über ein Lager:  leer = Keine Info, 1 = Kataloghersteller führt Artikel im Lager / kurzfristig Lieferbar
    ''' 2 = Bestellartikel, Hersteller hat den Artikel nicht im Lager
    ''' </summary>
    ''' <remarks></remarks>
    Public Lagermerker As String
    ''' <summary>
    ''' Referenznummer dieses Artikels
    ''' </summary>
    ''' <remarks></remarks>
    Public KuerzelErstellerRefnummer As String
    ''' <summary>
    ''' Referenznummer des Artikels
    ''' </summary>
    ''' <remarks></remarks>
    Public Referenznummer As String
    ''' <summary>
    ''' Falls Artikel vom Steuersatz abweicht, kann hier eine andere Steuerart angegeben werden
    ''' </summary>
    ''' <remarks></remarks>
    Public MwStsteuerMerker As enumMWstArt

    Public Sub Clear()
        Me.Alterartikelnummer = String.Empty
        Me.AnbindnummerGrafik = String.Empty
        Me.Artikelnummer = String.Empty
        Me.EAN = String.Empty
        Me.Hauptwarengruppe = String.Empty
        Me.HerstellerArtikelType = String.Empty
        Me.Herstellernummer = String.Empty
        Me.Katalogseite = String.Empty
        Me.Kostenart = String.Empty
        Me.KuerzelAlternativArtikelnummer = String.Empty
        Me.KuerzelErstellerRefnummer = String.Empty
        Me.KuerzelHerstellernummer = String.Empty
        Me.KurzText1 = String.Empty
        Me.KurzText2 = String.Empty
        Me.Lagermerker = String.Empty
        Me.Langtextnummer = String.Empty
        Me.Matchcode = String.Empty
        Me.Mindesverpackungsmenge = 1
        Me.MwStsteuerMerker = enumMWstArt.Default
        Me.Preiskennzeichen = enumPreisKennzeichen.ListenPreis
        Me.Rabattgruppe = String.Empty
        Me.Referenznummer = String.Empty
        Me.Textkennzeichen = enumTextKennzeichen.Default
        'Me.Verarbeitungsmerker =  enumVerarbeitungsmerker.NeuAnlage
        Me.Warengruppe = String.Empty

    End Sub
End Structure

''' <summary>
'''  Stellt einen Warengruppensatz (Hauptgruppen / Untergruppen) dar
''' </summary>
''' <remarks></remarks>
Friend Structure Hauptwarengruppen
    ''' <summary>
    ''' Stellt eine Kennung der Hauptwarengruppe (ID) dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Hauptwarengruppe As String
    ''' <summary>
    ''' Stellt eine Kennung der Unterwarengruppe dar, wenn gesetzt ist dieser Datensatz eine Unterwarengruppe
    ''' </summary>
    ''' <remarks></remarks>
    Public UnterWarengruppe As String
    ''' <summary>
    ''' Enthält den Text (Name) der  Warengruppe
    ''' </summary>
    ''' <remarks></remarks>
    Public Bezeichnung As String
End Structure
