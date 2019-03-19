Namespace Kernel

    ''' <summary>
    ''' Stellt eine Auswahl an Datenobjekten bereit, die durch das Grid oder Druck-Manager angezeugt werden können
    ''' </summary>
    ''' <remarks>VORSICHT: Im RELEASE DÜRFEN HIER KEINE WEITEREN ELEMNETE ZWISCHEN GELEGT WERDEN !</remarks>
    Public Enum DataSourceList
        ''' <summary>
        ''' Nicht gesetzt 
        ''' </summary>
        ''' <remarks></remarks>
        [None]
        ''' <summary>
        ''' Stellt die Datenquelle des Adressbuches da
        ''' </summary>
        ''' <remarks></remarks>
        Addressbook
        ''' <summary>
        ''' Stellt Tätigkeiten da (Obsolete)
        ''' </summary>
        ''' <remarks></remarks>
        WorkItems

        ''' <summary>
        ''' Stellt Artikel (Materialstamm da)
        ''' </summary>
        ''' <remarks></remarks>
        Articles
        ''' <summary>
        ''' Zeigt alle Rechnungen / Angebote an (Journalliste)
        ''' </summary>
        ''' <remarks></remarks>
        Journal


        ''' <summary>
        ''' Zeigt ein spezielles Journaldokument an (Ausdruck einer Rechnung)
        ''' </summary>
        ''' <remarks></remarks>
        Journaldocument

        ''' <summary>
        ''' Kassenbuch, eine Monatsansicht im druck
        ''' </summary>
        ''' <remarks></remarks>
        CashJournalMonthy

        ''' <summary>
        ''' Forderungen/Verbindlichkeiten
        ''' </summary>
        ''' <remarks></remarks>
        Transactions
        Tasks
        Units
        Discounts
        Letters
        Reminders
        ''' <summary>
        ''' Stellt eine Liste mit wiederkehrenden Kosten bereit
        ''' </summary>
        ''' <remarks></remarks>
        FixedCosts

        ''' <summary>
        ''' Stellt eine Fixkostengruppe bereit
        ''' </summary>
        ''' <remarks></remarks>
        FixedCostGroup
        ''' <summary>
        ''' Lohnkonten, Arbeitsgruppen und Preise pro Stunde
        ''' </summary>
        ''' <remarks></remarks>
        LoanAccounts
        ''' <summary>
        ''' Benutzerlisten
        ''' </summary>
        ''' <remarks></remarks>
        users
        ''' <summary>
        ''' (Noch nicht implementiert)
        ''' </summary>
        ''' <remarks></remarks>
        Groups

        ''' <summary>
        ''' Kategorien der History
        ''' </summary>
        ''' <remarks></remarks>
        HistoryCategories

        ''' <summary>
        ''' enthält keine Daten, sondern das Briefe.Layout (Business)
        ''' </summary>
        ''' <remarks></remarks>
        BusinessLayouts

        ''' <summary>
        ''' Druckt eine Stückliste (Beim rechnungsdruck mit Auftragsheader)
        ''' </summary>
        ''' <remarks></remarks>
        BillOfMaterial

        ''' <summary>
        ''' Jahresübersicht Kassenbuch
        ''' </summary>
        ''' <remarks></remarks>
        CashJournalYearly

    End Enum



    ''' <summary>
    ''' Kennzeichnet die Richtung des Geldflusses. Geld kann entweder eingenommen (Forderung) oder ausgegeben (Verbindlichkeit) werden.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum MoneyFlow
        ''' <summary>
        ''' Kenntzeichnet einen Geldfluss als "Ausgabe", Verbindlichkeit. Das Geld verlässt das Unternehmen und vermindert die liquiden Mittel
        ''' </summary>
        ''' <remarks></remarks>
        IsPayable
        ''' <summary>
        ''' Kennzeichnet den Geldflus als "Einnahnme", Forderung. Das Geld wird von einem anderem Unternehmen erwartet und soll den eigenen Bestand an liquiden Mittel erhöhen.
        ''' </summary>
        ''' <remarks></remarks>
        IsReceiveable
    End Enum

End Namespace