
''' <summary>
''' Dokumenten Type für Angebote /Rechnungen
''' </summary>
''' <remarks>Jedes Dokum trägt seinen Typen mit sich um</remarks>
Public Enum enumJournalDocumentType

    ALL = -1
    Angebot = 0
    Auftrag = 1
    Rechnung = 2

    ' Korrigiert
    Mahnung = 3
    Gutschrift = 4

    ' !! ACHTUNG: Die bestehenden NUmmern dürfen nicht verändert werden !

End Enum

''' <summary>
''' Enthält eine Auflistung der Datenlisten, die zur Verfügung stehen
''' </summary>
''' <remarks></remarks>
Public Enum CollectionType
    ''' <summary>
    ''' Adressbuch mit allen Kontaktdaten
    ''' </summary>
    ''' <remarks></remarks>
    Adressbook
    ''' <summary>
    ''' Tätigkeiten und Arbeitszeiten
    ''' </summary>
    ''' <remarks></remarks>
    WorkItems
    ''' <summary>
    ''' Artikel, (Materialstamm) 
    ''' </summary>
    ''' <remarks></remarks>
    Articles
    ''' <summary>
    ''' Rechnungen 
    ''' </summary>
    ''' <remarks></remarks>
    InVoices
End Enum