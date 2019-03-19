
''' <summary>
''' Dokumenten Type f�r Angebote /Rechnungen
''' </summary>
''' <remarks>Jedes Dokum tr�gt seinen Typen mit sich um</remarks>
Public Enum enumJournalDocumentType

    ALL = -1
    Angebot = 0
    Auftrag = 1
    Rechnung = 2

    ' Korrigiert
    Mahnung = 3
    Gutschrift = 4

    ' !! ACHTUNG: Die bestehenden NUmmern d�rfen nicht ver�ndert werden !

End Enum

''' <summary>
''' Enth�lt eine Auflistung der Datenlisten, die zur Verf�gung stehen
''' </summary>
''' <remarks></remarks>
Public Enum CollectionType
    ''' <summary>
    ''' Adressbuch mit allen Kontaktdaten
    ''' </summary>
    ''' <remarks></remarks>
    Adressbook
    ''' <summary>
    ''' T�tigkeiten und Arbeitszeiten
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