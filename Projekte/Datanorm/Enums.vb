Enum unterkennzeichen
    Frei
    einfüge
    einfügefeld
End Enum
''' <summary>
''' Stellt eine Kennung dar, die den aktuell eingelesenen Datensatz (Vorlaufsatz) beschreibt
''' </summary>
''' <remarks></remarks>
Enum enumDatenkennzeichen
    ''' <summary>
    ''' Kennzeichnet die Übertragung von Artikelsätzen
    ''' </summary>
    ''' <remarks></remarks>
    ArtikelStammDaten

    ''' <summary>
    ''' Kennzeichnet die Übertragung von Artikelgruppen
    ''' </summary>
    ''' <remarks></remarks>
    WarenGruppenSätze

    ''' <summary>
    ''' Kennzeichnet die Übertragung von Rabattsätzen
    ''' </summary>
    ''' <remarks></remarks>
    RabattGruppenSätze
    SetSätze
    PreisÄnderungsSätze
    TextSätzeUngebunden
    ''' <summary>
    ''' Stücklisten (ÖNorm)
    ''' </summary>
    ''' <remarks></remarks>
    StückListendaten
End Enum

''' <summary>
''' Beschreibt den Verwendungszweck dieses Textbausteins
''' </summary>
''' <remarks></remarks>
Enum enumTextmerker
    ''' <summary>
    ''' Text ohne Bezug zu einem Artikel
    ''' </summary>
    ''' <remarks></remarks>
    Ungebunden
    ''' <summary>
    ''' Langtext zum anbinden per Artikel.Langtextnummer an eine beliebige Anzahl von Artikeln
    ''' </summary>
    ''' <remarks></remarks>
    Langtext
    ''' <summary>
    ''' Einfügetext  zum einfügen in einen Dimensionstext, Platzhalter $-Zeichen
    ''' </summary>
    ''' <remarks></remarks>
    Einfügetextbaustein
End Enum

''' <summary>
''' Stellt eine Art da , den Rabattwert zu berechnen
''' </summary>
''' <remarks></remarks>
Enum enumRabattkennzeichen
    ''' <summary>
    ''' Der Rabattwert ist ein Prozentualer Wert. Netto Endpreis = Listenpreis -(Listenpreis * Wert/100)
    ''' </summary>
    ''' <remarks></remarks>
    Rabattsatz = 1
    ''' <summary>
    ''' Der Rabattwert ist ein Multiplikator (0,86  = Abschlag) Netto Endpreis = Listenpreis * Wert 
    ''' </summary>
    ''' <remarks></remarks>
    Multi = 2
    ''' <summary>
    ''' Der Wert ist ein Teuerungszuschlag (1,12 = 12% Zuschlag) Netto endpreis = Listenpreis * Wert
    ''' </summary>
    ''' <remarks></remarks>
    Teuerungszuschlag = 3
End Enum

''' <summary>
''' Beschreibt das Anlegen / Ändern oder Löschen von Daten
''' </summary>
''' <remarks></remarks>
Enum enumVerarbeitungsmerker
    NeuAnlage
    Löschung
    Änderung
End Enum

''' <summary>
''' stellt eine Art des Steuersatzes dar, wenn der übertragene Artikel nicht "normal" ist
''' </summary>
''' <remarks></remarks>
Enum enumMWstArt
    [Default] = 0
    Normal = 1
    erhöhterSatz = 2
    ReduzierterSart = 3
End Enum

''' <summary>
''' Alle Preise stets ohne MwSt.
''' </summary>
''' <remarks></remarks>
Enum enumPreisKennzeichen
    ''' <summary>
    ''' Netto einkaufspreis vom Händler
    ''' </summary>
    ''' <remarks></remarks>
    ListenPreis = 1
    ''' <summary>
    ''' Netto Verkaufspreis aus Sicht des Kunden
    ''' </summary>
    ''' <remarks></remarks>
    NettoPreis = 2

    ''' <summary>
    ''' Streckenpreis
    ''' Diese Angabe schliesst  Rabattgruppen oder Rabatte aus
    ''' </summary>
    ''' <remarks></remarks>
    Streckenpreis = 3

    ''' <summary>
    ''' Empfohlener Vk Netto
    ''' Diese Angabe schliesst  Rabattgruppen oder Rabatte aus
    ''' </summary>
    ''' <remarks></remarks>
    EmpfohlenerVKNetto = 4

    PreisAufAnfrage = 9
End Enum

''' <summary>
'''  Kennzeichnet die Art der Textaufbereitung bei Artikel
''' </summary>
''' <remarks></remarks>
Enum enumTextKennzeichen
    ''' <summary>
    ''' Kurztext 1 Kurztext 2
    ''' </summary>
    ''' <remarks></remarks>
    [Default] = 0
    ''' <summary>
    ''' Langtext, Kurztext 2
    ''' </summary>
    ''' <remarks></remarks>
    LT_KurzText2 = 1
    ''' <summary>
    ''' Kurztext, Dimensionstext
    ''' </summary>
    ''' <remarks></remarks>
    KT1_Dimension = 2
    LT_Dimensionstext = 3
    KT1_KT2_LT = 4
    KT1_KT2_Dimension = 5
    KT1_KT2_LT_Dimension = 6

End Enum
