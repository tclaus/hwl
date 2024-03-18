Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Kernel
Imports ClausSoftware.Data
<TestFixture()>
Public Class KernelTest


    ''' <summary>
    ''' Öffet die Fixkostentabelle
    ''' </summary>
    ''' <remarks></remarks>
    <Category("Fixkosten")>
    <Test()>
    Public Sub OpenFixedCosts()
        Dim fixedCosts As ClausSoftware.Kernel.FixedCosts = MainApplication.getInstance.FixedCosts
        Assert.IsNotNull(fixedCosts, "Fixkostentabelle konnte nicht geöffnet werden")

    End Sub


    <Test(Description:="Öffne Appointments (Termine)")>
    Public Sub OpenAppointments()
        Dim ap As Kernel.Appointments = MainApplication.getInstance.Appointments

        Assert.NotNull(ap, "Appointments konnten nicht geöffnet werden")
        Assert.IsTrue(ap.Count >= 0, "Appointments.Count abfragen geht nicht")


    End Sub

    <Test()>
    Public Sub OpenAppointmentRessource()
        Dim apR As Kernel.AppointmentsResources = MainApplication.getInstance.AppointmentResources
        Assert.NotNull(apR, "Appointment-Resource  konnten nicht geöffnet werden")
        Assert.IsTrue(apR.Count >= 0, "AppointmentRessources.Count abfragen geht nicht")

    End Sub

    ''' <summary>
    ''' Öffnet die Kassenbucheinträge
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="Kassenbucheinträge")>
    Public Sub OpenCashJournalItems()
        Dim cash As Kernel.CashJournalItems = MainApplication.getInstance.CashJournal
        Assert.NotNull(cash, "CashJournalItems  konnten nicht geöffnet werden")
        Assert.IsTrue(cash.Count >= 0, "CashJournalItems.Count abfragen geht nicht")

    End Sub


    ''' <summary>
    ''' Öffnet die Kassenbucheinträge
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="Kassenbucheinträge")>
    Public Sub OpenCashJournalIAccounts()
        Dim cash As Kernel.CashAccounts = MainApplication.getInstance.CashAccounts
        Assert.NotNull(cash, "CashAccounts  konnten nicht geöffnet werden")
        Assert.IsTrue(cash.Count >= 0, "CashAccounts.Count abfragen geht nicht")

    End Sub

    <Category("Fixkosten")>
    <Test()>
    Public Sub CreateNewFixedCosts()
        Dim orgCount As Integer
        Dim fixedCosts As ClausSoftware.Kernel.FixedCosts = MainApplication.getInstance.FixedCosts

        orgCount = fixedCosts.Count ' Origane Anzahl feststellen

        Dim newItem As ClausSoftware.Kernel.FixedCost = fixedCosts.GetNewItem

        newItem.Subject = "Test-Eintrag"
        newItem.Save()
        fixedCosts.Reload()


        Assert.Greater(fixedCosts.Count, orgCount, "Es sollte die Anzahl der Fixkosten nach Neuanlage erhöht worden sein. ")

    End Sub

    <Category("settings")>
    <Description("Prüft die unterschiedlichen Möglichkeiten des Laden und Speichern von Einstellungen")>
    Public Sub TestSettings()

        Dim valueOwnValue As String = "Deins"
        Dim valueOtherValue As String = "Meins"
        Dim valueNoUser As String = "No Value"

        MainApplication.getInstance.Settings.SetSetting("ABC", "123", valueOwnValue) ' Speichert einen Wert, und weist diesen dem aktuellen Benutzer zu
        MainApplication.getInstance.Settings.SetSetting("ABC", "123", valueOtherValue, "dummyUser") ' Speichert einen Wert, und weist diesen einem anderen Benutzer zu

        Dim testOwnValue As String
        Dim testOtherValue As String
        Dim testNoValue As String


        testOwnValue = MainApplication.getInstance.Settings.GetSetting("ABC", "123", "") ' mein eiger wert abholen
        testOtherValue = MainApplication.getInstance.Settings.GetSetting("ABC", "123", "", "dummyUser") ' Anderen wert abholen

        Assert.AreEqual(valueOwnValue, testOwnValue, "Benutzerwert war nach dem einlesen nicht gleich dem geschriebenen wert")
        Assert.AreEqual(valueOtherValue, testOtherValue, "Wert eines anderen Benutzers war nach dem einlesen nicht gleich dem geschriebenen wert")


        MainApplication.getInstance.Settings.SetSetting("ABC", "123", valueNoUser, "") ' Speichert einen Wert ohne Benutzerzuweisung
        MainApplication.getInstance.Settings.SetSetting("ABC", "123", "QuatschValue") ' Darf nicht den Wert ohne Benutzerangabe überschreiben

        testNoValue = MainApplication.getInstance.Settings.GetSetting("ABC", "123", "", "")
        Assert.AreEqual(valueNoUser, testNoValue, "Geschriebener Wert ist nicht mit dem gelesenen Wert identisch!")
    End Sub


    ''' <summary>
    ''' Beim Start muss immer ein Applikations-Benutzer existieren
    ''' </summary>
    ''' <remarks></remarks>
    <Category("Kernel")>
    <Test()>
    Public Sub ApplicationUserSet()
        Assert.NotNull(MainApplication.getInstance.CurrentUser, "Ein standard-benutzer muss immer gesetzt sein. Ist Keine Benutzerverwaltung aktiv, so muss ein Dummy-Benutzer mit Rechnernamen/Anmeldenamen gesetzt sein.")
        Assert.NotNull(MainApplication.getInstance.CurrentUser.Key, "ein Standardbenutzer ist gesetzt. Die Key-Eigenschaft war aber leer.")

    End Sub

    ''' <summary>
    ''' Die Application ID sollteniemals leer sein!
    ''' </summary>
    ''' <remarks></remarks>
    <Test()>
    Public Sub testAppID()
        Assert.IsNotEmpty(MainApplication.getInstance.ApplicationID)
    End Sub

    ''' <summary>
    ''' Öffnet den Adressen-Datensatz
    ''' </summary>
    ''' <remarks></remarks>
    <Test()>
    Public Sub OpenAddress()

        Dim adressen As Kernel.Adressen

        adressen = MainApplication.getInstance.Adressen
        Assert.IsNotNull(adressen, "Adressen war kein gefülltes Objekt")
        Assert.IsTrue(adressen.Count >= 0, "Adressen.Count konnte nicht ermittelt werden")

    End Sub

    <Test(Description:="Ruft die Auflistung der Calls für diesen Kontakt ab")>
    Public Sub TestAdressPhoneCallList()
        Dim pc As PhoneCalls = MainApplication.getInstance.Adressen(0).PhoneCallList

        Assert.NotNull(MainApplication.getInstance.Adressen(0).PhoneCallList, "Liste der Calls für eine Adresse war leer")


        Dim orgCount As Integer = pc.Count ' Anzahl merken


        Dim newcall As PhoneCall = pc.GetNewItem()
        newcall.CallerAddress = MainApplication.getInstance.Adressen(0)
        newcall.CallingID = "007"
        newcall.Save()

        pc.Reload()

        ' Anzahl sollte nun um 1 höher sein 
        Assert.IsTrue(pc.Count > orgCount, "Scheinbar wurde der neue Call nicht der Adresse zugwiesen")


        newcall.CallerAddress = Nothing
        Assert.IsNull(newcall.CallerAddress, "Sollte nothing zurückgeben")

        Assert.NotNull(newcall.CallState, "Anrufzustand darf nicht nothing sein")
        newcall.Reload()
        Assert.IsTrue(newcall.CallerAddress.Key = MainApplication.getInstance.Adressen(0).Key, "Anruferadreswse sollte nun wieder hergestellt sein")

        newcall.CallState = PhoneCall.CallStateType.Answered

        Assert.IsTrue(newcall.CallState = PhoneCall.CallStateType.Answered, "Callstate konnte nicht gesetzt werden")

        newcall.CallState = PhoneCall.CallStateType.Unanswered

        Assert.IsTrue(newcall.CallState = PhoneCall.CallStateType.Unanswered, "Callstate konnte nicht gesetzt werden")

        Debug.Print("CallTarget=" & newcall.TargetCallID)
        Assert.NotNull(newcall.CallingDuration, "Zeitdauer des Anrufes nicht gesetzt")

    End Sub

    ''' <summary>
    ''' Prüft das direkte Locking eines Elementes 
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Setzt ein Lock auf ein beliebiges Element und prüft dieses")>
    <Test()>
    Public Sub BeginLock()
        Dim maxCount As Integer = MainApplication.getInstance.Adressen.Count - 1
        Dim r As Random = New Random()

        Dim index As Integer = r.Next(0, maxCount - 1)

        Dim Adress As Kernel.Adress = MainApplication.getInstance.Adressen(index)
        Adress.ForceUnlock()

        Dim lockState As ClausSoftware.Data.LockType
        lockState = Adress.CheckLockState

        If lockState.LockType = Data.LockedbyType.ByNone Then
            Adress.Lock()
            Assert.IsTrue(Adress.CheckLockState.LockType = Data.LockedbyType.ByMe, "Der Datensatz sollte gesperrt sein, ist es aber nicht")
            Adress.Unlock()
            Assert.IsTrue(Adress.CheckLockState.LockType = Data.LockedbyType.ByNone, "Der Datensatz konnte nicht entsperrt werden")
        Else
            Assert.Pass("Das Element ist bereits gespert, obwohl keine gesperrten Elemente existiern dürften!")
        End If


    End Sub

    <Test(Description:="Öffnet die Artikel-Attribute liste")>
    Public Sub OpenClassDefinitions()
        Dim classdef As Kernel.Attributes.ClassDefinitions = MainApplication.getInstance.ClassDefinitions
        Assert.IsNotNull(classdef, "Classefinition war nothing")
        Assert.IsTrue(classdef.Count >= 0, "Konnte die Anzahl nicht abrufen")

    End Sub

    <Description("Loading Application Units")>
    <Test()>
    Public Sub OpenUnits()
        Debug.Print("Lade Einheiten")

        Dim Einheiten As Kernel.Units

        Einheiten = MainApplication.getInstance.Units
        Assert.IsNotNull(Einheiten, "Einheiten war kein gefülltes Objekt")
        Assert.IsTrue(Einheiten.Count >= 0, "Einheiten.Count konnte nicht ermittelt werden")

        Debug.Print("EinheitName: " & Einheiten(0).Name)
        Debug.Print("DatanormKuerzel: " & Einheiten(0).DatanormShortName)

    End Sub

    ''' <summary>
    ''' Fixkostengruppe
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="Öffne Fixkostengruppen")>
    Public Sub OpenFixedCostGroups()
        Dim fg As Kernel.FixedCostGroups = MainApplication.getInstance.FixedCostGroups

        Assert.IsNotNull(fg, "Fixkostengruppe war kein gefülltes Objekt")
        Assert.IsTrue(fg.Count >= 0, "Fixkostengruppe.Count konnte nicht ermittelt werden")

    End Sub

    ''' <summary>
    ''' Ermittelt die letzte gemessene Datenbankgechwindigkeit
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TestLastDatabaseSpeedValue()
        Dim value As Integer = MainApplication.getInstance.LastDatabaseSpeed

    End Sub
    ''' <summary>
    ''' Artikelgruppen
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="ArtikelGruppen")>
    Public Sub OpenArticleGroups()
        Dim fg As Kernel.Groups = MainApplication.getInstance.Groups

        Assert.IsNotNull(fg, "Artikelgruppen war kein gefülltes Objekt")
        Assert.IsTrue(fg.Count >= 0, "Artikelgruppen.Count konnte nicht ermittelt werden")

    End Sub

    <Test(Description:="Öffne Rabatte-Klasse")>
    Public Sub OpenDiscounts()
        Dim discounts As Kernel.Discounts = MainApplication.getInstance.Discounts
        Assert.IsNotNull(discounts, "Rabatte war kein gefülltes Objekt")
        Assert.IsTrue(discounts.Count >= 0, "Discounts.Count konnte nicht ermittelt werden")

    End Sub

    <Description("Getting Database Version")>
    <Test()>
    Public Sub GetDBVersion()
        Dim DBValue As String
        DBValue = MainApplication.getInstance.DBVersion
        Debug.Print("Datenbankversion ist: " & DBValue)


        MainApplication.getInstance.DBVersion = "1.2.3"

        StringAssert.AreEqualIgnoringCase("1.2.3", MainApplication.getInstance.DBVersion)
        ' wieder herstellen
        MainApplication.getInstance.DBVersion = DBValue

    End Sub


    <Test()>
    Public Sub SetDBVersion()
        Dim DBValue As String
        DBValue = MainApplication.getInstance.DBVersion
        Debug.Print("Datenbankversion ist: " & DBValue)
        ' Setze richtige DB Version

        MainApplication.getInstance.DBVersion = "1.4.712"

        Debug.Assert(MainApplication.getInstance.DBVersion = "1.4.712", "Datenbankversion konnte nicht gesetzt werden")
        MainApplication.getInstance.DBVersion = DBValue
        'Sollte einen Fehler auslösen 
        MainApplication.getInstance.DBVersion = "Humptydumpty"


    End Sub

    <Test()>
    Public Sub TestAttachments()
        Dim a As Kernel.Attachments = New Kernel.Attachments(MainApplication.getInstance)

        Assert.NotNull(a, "Attachmets sind null")
        Assert.NotNull(a.Count, "Attachments.count sind null")

    End Sub

    <Test()>
    Public Sub CreateAttachment()
        Dim a As Kernel.Attachment = New Kernel.Attachment(MainApplication.getInstance.Session)
        a.CreateDate = Today
        Assert.IsFalse(a.DataExist)

        a.SetFile("CoreTests.dll")

        a.Note = "test Attachment"
        Assert.IsTrue(a.HasChanged, "Es wurden kieine änderungen signalisiert")
        a.Save()
        a.Delete()

    End Sub

    ''' <summary>
    ''' Das erste Item aus der (Adressen)-Liste rausholen
    ''' </summary>
    ''' <remarks></remarks>
    <Test()>
    Public Sub GetAdressItem()

        Dim adressen As Kernel.Adressen
        adressen = MainApplication.getInstance.Adressen
        If adressen.Count > 0 Then
            Debug.Print("Company: " & adressen(0).Company)
            Debug.Print("ContactsName: " & adressen(0).ContactsName)
            Debug.Print("Anmerkungen: " & adressen(0).Description)
            Debug.Print("Datanorm: " & adressen(0).Datanorm)
            Debug.Print("LastChanged: " & adressen(0).ChangedAt)
            Debug.Print("Fax: " & adressen(0).Fax)
            Debug.Print("ebayID: " & adressen(0).EbayID)
        End If

    End Sub

    <Test()>
    Public Sub CreateAddress()
        Dim Adressen As Kernel.Adressen = MainApplication.getInstance.Adressen
        Dim OldCount As Long
        Dim NewCount As Long
        Debug.Print("AdresseAnlegen")

        Dim Adresse As ClausSoftware.Kernel.Adress

        Adresse = Adressen.GetNewItem()

        Adresse.Company = "neue Testfirma"
        Adresse.FirstName = "First"
        Adresse.LastName = "Last"

        OldCount = Adressen.Count

        Adressen.Add(Adresse)
        NewCount = Adressen.Count

        Assert.IsTrue(Adresse.ContactsName = Adresse.FirstName & " " & Adresse.LastName)

        Assert.IsTrue(NewCount > OldCount, "Es wurde der Collection keine Adresse hinzugefügt")

        Adresse.Save()
        Adressen.Reload()
        Debug.Assert(NewCount = Adressen.Count, "Nach einem Reload war die Grösse der Collection anders!")

        Debug.Assert(Adressen.IndexOf(Adresse) > 0, "Neuer Datensatz ist nicht in der Collection enthalten")

        'Adresse aktualisieren
        Adresse.CreatedAt = New Date(1974, 6, 1)
        MainApplication.getInstance.Settings.SettingAdressID_Format = "$NR - $YY"
        Adresse.RefreshDisplayID()

        Debug.Print("Neue Adressennummer: " & Adresse.ContactDisplayID)
        StringAssert.EndsWith("74", Adresse.ContactDisplayID)

        Debug.Print("Lösche:" & Adresse.ToString)

        Adressen.Remove(Adresse)
        Adresse.Delete()


    End Sub
    <Description("Testes die Eindeutigkeit von Kennzeichnungen")>
    <Test()>
    Public Sub TestAdressesUniqeIds()
        Dim guid As String = System.Guid.NewGuid.ToString

        Assert.IsTrue(MainApplication.getInstance.Adressen.CheckUniqueID(guid), "Unique ID war nicht eindeutig!")  ' Diese ID sollte auf jeden Fall eindeutig sein

        Dim newAdress As Adress = MainApplication.getInstance.Adressen.GetNewItem
        newAdress.EbayID = guid
        newAdress.Save()

        Assert.IsFalse(MainApplication.getInstance.Adressen.CheckUniqueID(guid), "Unique ID sollte vergeben sein!")  ' Diese ID sollte auf jeden Fall eindeutig sein

        Dim testAdress As Adress = MainApplication.getInstance.Adressen.GetItemByUniqueID(guid)

        Assert.AreEqual(testAdress.Key, newAdress.Key, "Adresse konnte durch Unique ID nicht ermittelt werden")


    End Sub

    <Test()>
    Public Sub OpenBriefe()

        Dim Briefe As Kernel.Letters

        Briefe = MainApplication.getInstance.Letters
        Assert.IsNotNull(Briefe, "Briefe war kein gefülltes Objekt")
        Assert.IsTrue(Briefe.Count >= 0, "Adressen.Count konnte nicht ermittelt werden")

    End Sub
    <Test()>
    Public Sub AdressHistory()

        Dim adress As Kernel.Adress = MainApplication.getInstance.Adressen(0)
        Dim Histories As Kernel.AddressHistoryItems = adress.History

        Assert.IsTrue(Histories.Categories.Count > 0, "Histories sollte mindestes eine Standard-Kategorie besitzen")



        Dim OldCount As Integer
        OldCount = Histories.Count

        Dim newentry As Kernel.AddressHistoryItem = Histories.GetNewItem
        newentry.Adress = adress
        newentry.Category = MainApplication.getInstance.HistoryCategories.GetRemindersCategory
        newentry.Text = "Test History entry"
        newentry.Save()

        Assert.IsNotEmpty(newentry.Category.ToString)
        Assert.NotNull(newentry.Adress, "Addresse des History-elementes konnte nicht ermittelt werden")
        Assert.IsNotEmpty(newentry.Adress.ToString, "Address-Text des History-elementes konnte nicht ermittelt werden")

        Debug.Print("Kategoriename: " & newentry.Category.ToString)

        Assert.Greater(adress.History.Count, OldCount, "Neuer Histrory-eintrag wurde nicht der Auflistung hinzugefügt")

        Histories.Delete() ' Alle einträge wieder löschen 

    End Sub

    <Test()>
    Public Sub OpenImages()

        Dim images As Kernel.Images

        images = MainApplication.getInstance.Images
        Assert.IsNotNull(images, "Bilder war kein gefülltes Objekt")
        Assert.IsTrue(images.Count >= 0, "images.Count konnte nicht ermittelt werden")

    End Sub

    <Test()>
    Public Sub OpenNotes()

        Dim Notes As Kernel.Letters
        Notes = MainApplication.getInstance.Letters
        Assert.IsNotNull(Notes, "Notes war kein gefülltes Objekt")
        Assert.IsTrue(Notes.Count >= 0, "Notes.Count konnte nicht ermittelt werden")

    End Sub


    <Test()>
    Public Sub ShowBriefe()
        Debug.Print("ShowBriefe")
        Dim Briefe As Kernel.Letters

        Briefe = MainApplication.getInstance.Letters
        Debug.Print("Briefe.Count: " & Briefe.Count)
        If Briefe.Count > 0 Then
            Debug.Print(Briefe(0).AddressField)
            Debug.Print(CStr(Briefe(0).UserDefinedAdresswindow))
            Debug.Print(Briefe(0).Subject)
            Debug.Print(Briefe(0).Text)
            Debug.Print(CStr(Briefe(0).CreatedAt))
            Debug.Print(CStr(Briefe(0).LastChangedAt))
            Debug.Print(CStr(Briefe(0).ID))
        End If

    End Sub

    <Test()>
    Public Sub OpenJournal()
        Debug.Print("Öffen Journal der Dokumente")
        Dim Journal As Kernel.JournalDocuments
        Journal = MainApplication.getInstance.JournalDocuments


        Assert.IsNotNull(Journal, "Journal war kein gefülltes Objekt")
        Assert.IsTrue(Journal.Count >= 0, "Journal.Count konnte nicht ermittelt werden")

    End Sub
    <Test()>
    Public Sub OpenJournalItems()
        Dim jItems As New Kernel.JournalArticleItems(MainApplication.getInstance)
        Assert.NotNull(jItems, "JournalItems war kein gefülltest Objekt!")

    End Sub




    <Test()>
    Public Sub OpenArticleList()
        Debug.Print("Öffnet Materialliste")
        Dim Materialliste As Kernel.Articles
        Materialliste = MainApplication.getInstance.ArticleList

        Assert.IsNotNull(Materialliste, "Materialliste war kein gefülltes Objekt")
        Assert.IsTrue(Materialliste.Count >= 0, "Materialliste.Count konnte nicht ermittelt werden")

    End Sub

    <Test()>
    Public Sub OpenJournalPositions()
        Debug.Print("Öffen eine Position im Journal der Dokumente")
        Dim Journal As Kernel.JournalDocuments
        Journal = MainApplication.getInstance.JournalDocuments


        Assert.IsNotNull(Journal, "Journal war kein gefülltes Objekt")
        Assert.IsTrue(Journal.Count >= 0, "Journal.Count konnte nicht ermittelt werden")


        Assert.IsTrue(Journal(0).ArticleGroups.Count >= 0, "Das Journaldokument enthält keine Positionen")



    End Sub

    <Test()>
    Public Sub OpenItems()
        Debug.Print("Öffen Artikelliste der Dokumente")
        Dim Items As Kernel.JournalArticleItems

        Items = New Kernel.JournalArticleItems(MainApplication.getInstance)

        Assert.IsNotNull(Items, "Artikelliste war kein gefülltes Objekt")
        Assert.IsTrue(Items.Count >= 0, "Artikelliste.Count konnte nicht ermittelt werden")

    End Sub


    <Test()>
    Public Sub OpenPositions()
        Debug.Print("Öffen Positionen der Dokumente")
        Dim Position As Kernel.JournalArticleGroups

        Position = New Kernel.JournalArticleGroups(MainApplication.getInstance)

        Assert.IsNotNull(Position, "Positionen war kein gefülltes Objekt")
        Assert.IsTrue(Position.Count >= 0, "Positionen.Count konnte nicht ermittelt werden")

    End Sub

    <Test()>
    Public Sub OpenPositionItems()
        Debug.Print("Öffen die Artikel der Positionen der Dokumente")
        Dim Positionen As Kernel.JournalArticleGroups

        Positionen = New Kernel.JournalArticleGroups(MainApplication.getInstance)

        Assert.IsNotNull(Positionen, "Positionen war kein gefülltes Objekt")
        Assert.IsTrue(Positionen.Count >= 0, "Positionen.Count konnte nicht ermittelt werden")
        If Positionen.Count > 0 Then
            Assert.IsTrue(Positionen(0).ArticleList.Count >= 0, "Positionen(0).Items.Count konnte nicht ermittelt werden")
            For Each item As Kernel.JournalArticleItem In Positionen(0).ArticleList
                'TODO: Hier den Test ergänzen                
            Next
        End If

    End Sub

    <Description("Öffnet die Aufgabenliste")>
    <Test()>
    Public Sub OpenTasks()
        Debug.Print("Öffnet die Aufgabenliste")
        Dim tasks As Kernel.Tasks

        tasks = MainApplication.getInstance.Tasks

        Assert.IsNotNull(tasks, "Aufgaben war kein gefülltes Objekt")
        Assert.IsTrue(tasks.Count >= 0, "Aufgabenliste.Count konnte nicht ermittelt werden")

    End Sub

    <Description("Öffnet die Forderungen-Liste")>
    <Test()>
    Public Sub OpenTransactions()
        Debug.Print("Öffnet die Forderungen-Liste")
        Dim trans As Kernel.Transactions

        trans = MainApplication.getInstance.Transactions

        Assert.IsNotNull(trans, "Forderungen/ Verbindlichkeiten war kein gefülltes Objekt")
        Assert.IsTrue(trans.Count >= 0, "Forderungen/ Verbindlichkeiten .Count konnte nicht ermittelt werden")

    End Sub

    <Test()>
    Public Sub OpenMWST()
        Debug.Print("Öffen Mehrwertsteuer-Tabelle der Dokumente")
        Dim Steuern As Kernel.TaxRates

        Steuern = New Kernel.TaxRates(MainApplication.getInstance)

        Assert.IsNotNull(Steuern, "Mehrwertsteuer war kein gefülltes Objekt")
        Assert.IsTrue(Steuern.Count >= 0, "Artikelliste.Count konnte nicht ermittelt werden")

    End Sub

    <Description("Holt ein Objekt anhand der Indexnummer der Auflistung ab")>
    <Test()>
    Public Sub OpenObjectbyID()
        Dim target As Object
        target = MainApplication.getInstance.ArticleList(0)
        Assert.NotNull(target, "Es konnte kein Objekt an der Position '0' geholt werden")

    End Sub

    <Description("Testt eine leeres Kriterium in einer Collection")>
    <Test()>
    Public Sub TestEmptyCollectionCriteria()
        Dim testcll As Articles = New Articles(MainApplication.getInstance, Nothing)
        Assert.IsTrue(testcll.Count > 0, "Die Auflistung sollte mit einem leerem Kriterium gefüllt sein.")
    End Sub


    <Description("Holt ein Objekt anhand einer ungültigen Indexnummer der Auflistung ab")>
    <Test()>
    Public Sub OpenObjectbyInvalidID()
        Dim target As Object
        target = MainApplication.getInstance.ArticleList(MainApplication.getInstance.ArticleList.Count + 5)
        Assert.IsNull(target, "Bei einer ungültigen Zugriffsnummer sollte 'nothing' zurückgegeben werden!")

    End Sub

    <Ignore("MySQL Dump für Server-DB nötig; klappt nicht als Unit-Test")>
    <Test()>
    Public Sub TestStartBackup()
        Dim result As Boolean = MainApplication.getInstance.Database.StartBackup()
        Assert.IsTrue(result, "Anlegen der Sicherungskopie hat 'False' ergeben.")

    End Sub

    ''' <summary>
    ''' Holt die Tabelle der Properties, der Einstellungen ab
    ''' </summary>
    ''' <remarks></remarks>
    <Test()>
    Public Sub OpenEinstellungen()
        Debug.Print("Öffne Einstellungen-Tabelle")
        Dim Einstellungen As Kernel.Settings

        Einstellungen = New Kernel.Settings(MainApplication.getInstance)

        Assert.IsNotNull(Einstellungen, "Einstellungen war kein gefülltes Objekt")
        Assert.IsTrue(Einstellungen.Count >= 0, "Einstellungen.Count konnte nicht ermittelt werden")

    End Sub

    <Test()>
    Public Sub GetSetting()
        Debug.Print("Lese und Setze Einstellungen-Tabelle ")
        Dim Einstellungen As Kernel.Settings

        Einstellungen = New Kernel.Settings(MainApplication.getInstance)
        'Sollte eine Exception auslösen
        Dim Wert As String
        Wert = Einstellungen.GetSetting("irgendwas nicht da", "Kenne ich nicht")
        Assert.AreSame(Wert, String.Empty, "Eine nicht gefundene Einstellung sollte einen leeren Wert zurückgeben")

        ' Setze Werte und hole Werte
        Dim EinstellungName As String = "Test-Value"

        Einstellungen.SetSetting(EinstellungName, "Test", "Ohne Benutzer")

        Einstellungen = MainApplication.getInstance.Settings
        Einstellungen.Reload()

        Wert = Einstellungen.GetSetting(EinstellungName, "Test")
        Assert.AreNotSame(Wert, String.Empty, "(nicht Benutzerdefiniert) Der Wert " & EinstellungName & "  sollte etwas anderes als einen Leerstring enthalten")
        Debug.Print("(nicht Benutzerdefiniert) Einstellung " & EinstellungName & "  hatte den Wert:" & Wert)


        ' Benutzerdefinierte Einstellung
        Einstellungen.SetSetting(EinstellungName, "Test", "Test-User", "Benutzerdefiniert")

        Einstellungen = MainApplication.getInstance.Settings
        Einstellungen.Reload()

        Wert = Einstellungen.GetSetting(EinstellungName, "Test", "Test-User")
        Assert.AreNotSame(Wert, String.Empty, "(Benutzerdefiniert) Der Wert " & EinstellungName & "  sollte etwas anderes als einen Leerstring enthalten")
        Debug.Print("(Benutzerdefiniert) Einstellung " & EinstellungName & "  hatte den Wert:" & Wert)

    End Sub

    <Category("Security")>
    <Description("Legt einen dummy-Benutzer fest, der aus dem Rechnernamen und eingeloggtem Benutzernamen gebildet wird")>
    <Test()>
    Public Sub getUserByComputer()
        Dim dummyUser As ClausSoftware.Kernel.Security.User = MainApplication.getInstance.Users.GetUserByComputer()

        Assert.AreEqual(dummyUser.Name, dummyUser.Key, "DummyUser muss denselben Schlüssel haben wie Name")
        Assert.AreEqual(dummyUser.Name, Kernel.Security.Users.MachineUserName, "DummyUser.Name format muss sein: ComputerName\UserName")
        Assert.AreEqual(dummyUser.Name, Kernel.Security.Users.MachineUserName, "DummyUser.Name format muss sein: ComputerName\UserName")


    End Sub


    <Test()>
    <Description("Neue Adress-Einträge müssen immer das aktuelle Erstellungsdatum und Ersteller aufweisen")>
    Public Sub AnewItemHasCorrectCreatedAtState()
        Dim newAdress As Kernel.Adress = MainApplication.getInstance.Adressen.GetNewItem

        Assert.AreEqual(newAdress.CreatedAt, Date.Today, "Adressen Erstellungsdatum war nicht gesetzt.")
        Assert.AreEqual(newAdress.CreatedByID, MainApplication.getInstance.CurrentUser.Key, "Ersteller einer neuen Adresse war nicht gesetzt. Auch wenn keine Benutzerverwaltung isntalliert ist, muss immer der User.Key als Ersteller angegeben sein (sonst Rechnername/Benutzername)")



    End Sub

    <Test()>
    Public Sub TestBaseClassMethods()
        Dim a As Kernel.Adress = MainApplication.getInstance.Adressen(0)
        Debug.Print("IsDeleted: " & CType(a, BaseClass).IsDeleted)
        Debug.Print("IsLoading: " & CType(a, BaseClass).IsLoading)

        Assert.IsTrue(MainApplication.getInstance.Adressen.Contains(a), "Contains lieferte False (True erwartet)")
        Assert.IsTrue(MainApplication.getInstance.Adressen.ContainsKey(a.Key), "Contains lieferte False (True erwartet)")
        Assert.IsFalse(MainApplication.getInstance.Adressen.ContainsKey("Test123abnc"), "Contains lieferte True (False erwartet)")

        Dim newA As Kernel.Adress = CType(a.Clone, Kernel.Adress)
        Assert.NotNull(newA, "Klon einer Adresse schlug fehl")

        Assert.NotNull(MainApplication.getInstance.Adressen.FullTextSearchColumns, "Volltext (Adressbuch) war nothing.")

    End Sub

    <Category("Kernel")>
    <Test(Description:="BaseCollection=ToArray")>
    Public Sub ToArraytest()
        Dim lst As List(Of Kernel.Adress) = MainApplication.getInstance.Adressen.ToArray()

        Assert.NotNull(lst, "Liste 'ToArray' war nothing.")

    End Sub

    <Category("Kernel")>
    <Test(Description:="Ruft Daten direkt aus der Datenbankschnittstelle oder lokaler Aufllistung ab")>
    Public Sub GetFromDB()
        Dim a As Kernel.Adress = MainApplication.getInstance.Adressen(0)

        Assert.NotNull(MainApplication.getInstance.Adressen.GetFromDB(a.Key), "Ermitteln eines Datensatzes aus Datenbank anhand des Schlüssels fehlgeschlagen.")
        Assert.NotNull(MainApplication.getInstance.Adressen.GetFromDB(a.ID), "Ermitteln eines Datensatzes aus Datenbank anhand des Schlüssels fehlgeschlagen.")

        Assert.NotNull(MainApplication.getInstance.Adressen.GetItem(a.ID), "Bekannter Datensatz aus lokaler Auflistung geht nicht")
        Assert.NotNull(MainApplication.getInstance.Adressen.GetItem(a.Key), "Bekannter Datensatz aus lokaler Auflistung geht nicht")


    End Sub

    <Category("Addins")>
    <Test(Description:="Rufe Addins auf")>
    Public Sub StartAddins()


        Assert.NotNull(MainApplication.getInstance.AddIns, "Addins konnten nicht geöffnet werden")
        Assert.NotNull(MainApplication.getInstance.AddIns.AddIns.Count, "Addins.Count konnten nicht geöffnet werden")

        Debug.Print("Addin count: " & MainApplication.getInstance.AddIns.AddIns.Count)
    End Sub

    <Test(Description:="testet allgemeine Artikeleigenschaften der Rechnungserstellung")>
    Public Sub Settingstest()
        Assert.NotNull(MainApplication.getInstance.Settings.ItemsSettings.ShowWithoutTax, "ShowItemsnetto hat nothing zurückgegeben")
        Assert.NotNull(MainApplication.getInstance.Settings.ItemsSettings.ShowItemsWithTax, "ShowItemswithTax hat nothing zurückgegeben")

        MainApplication.getInstance.Settings.ItemsSettings.ShowWithoutTax = True
        Assert.IsTrue(MainApplication.getInstance.Settings.ItemsSettings.ShowWithoutTax, "True war erwartet")

        MainApplication.getInstance.Settings.ItemsSettings.ShowWithoutTax = False
        Assert.IsFalse(MainApplication.getInstance.Settings.ItemsSettings.ShowWithoutTax, "False war erwartet")


    End Sub

    ''' <summary>
    ''' Testst fixkostengruppen
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="Testet Fixkostengruppen")>
    Public Sub testFixedCostsGroups()
        Dim fg As FixedCostGroups = MainApplication.getInstance.FixedCostGroups

        Assert.NotNull(fg, "Fixkostengruppe war nothing")
        Assert.IsTrue(fg.Count >= 0, "Anzahl der Fixkostengruppe konnte nicht ermittelt werden")
        Dim orgCount As Integer = fg.Count

        ' Neue Gruppe anlegen 
        Dim newFG As FixedCostGroup = fg.GetNewItem
        newFG.GroupName = "Nur für den Test angelegt"
        newFG.Save()

        Dim orgKey As String = newFG.ReplikID
        Assert.IsNotEmpty(orgKey, "Neue Gruppe hatte kein eindeutisgen Schlüssel!")

        fg.Reload()

        ' Nun sollte auch der neue schlüssel existieren !

        Assert.Greater(fg.Count, orgCount, "Nach dem neuanlegen einer Fixkostengruppe sollte einer mehr ind er Liste stehen!")
        Dim testGroup As FixedCostGroup = fg.GetItem(orgKey)

        ' m?? 
        Assert.AreEqual(newFG, testGroup, "Neu gezogene Gruppe war nicht gleich der gespeicherten Gruppe?")




    End Sub

    ''' <summary>
    ''' Testst die zuletzt benutzten Elemente
    ''' </summary>
    ''' <remarks></remarks>
    <Test()>
    Public Sub TestRecentlyUsed()
        Dim ru As RecentlyUsedItems = MainApplication.getInstance.RecentlyUsedItems

        Assert.NotNull(ru, "Recently Used Groups war nothing")

        Dim newItem As RecentlyUsed = ru.GetNewItem
        newItem.CalledAt = Now

        Dim TestItem As Adress = MainApplication.getInstance.Adressen.GetItem(1)

        newItem.SetRecentItem(TestItem)

        Assert.NotNull(newItem.GetRecentlyUsedItem, "Das zurückgegebene Element war nothing")



    End Sub

    <Test(Description:="Tests die Arbeitszeiten-Konten")>
    Public Sub TestLoadAccounts()
        Dim ac As LoanAccounts = MainApplication.getInstance.LoanAccounts

        Assert.NotNull(ac, "LoanAccounts war nothing")

        Assert.IsTrue(ac.Count >= 0, "Die Anzahld er Arbeitszeiten-KOnten konnte nicht ermittelt werden")

        Dim orgCount As Integer = ac.Count

        Dim newac As LoanAccount = ac.GetNewItem

        newac.Name = "Test-Lohnkonto"
        newac.PricePerHour = 123.99D

        newac.Save()
        ac.Reload()
        Assert.Greater(ac.Count, orgCount, "Nach dem speichern eines Lohnkontos wurde die Anzahl nicht erhöht")
        newac.Delete()
        ac.Reload()


    End Sub

    <Test(Description:="Testet die Textbausteine")>
    Public Sub TestTextTemplates()
        Dim t = MainApplication.getInstance.TextTemplates

        Assert.NotNull(t, "TextTemplates konnten nicht von der Stammklasse ermittelt werden")
        Assert.IsTrue(t.Count > 0, "")

        Dim newText As TextTemplate = MainApplication.getInstance.TextTemplates.GetNewItem
        newText.Text = "Hallo welt"

        Assert.IsTrue(newText.HasChanged, "Das 'HasChanged' - Flag ist nicht gesetzt!") ' Nicht Objektspeziefisch !

        newText.Save()

        newText.Delete()

        'Assert.IsTrue(newText.IsDeleted, "IsDeleted - eigenschaft ist nicht True nach dem löschen!")
    End Sub

    Public Sub New()

    End Sub
End Class
