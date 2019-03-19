Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Kernel
Imports ClausSoftware.Data
Imports DevExpress.Xpo

<TestFixture()> _
Public Class KernelTest
   

    ''' <summary>
    ''' Öffet die Fixkostentabelle
    ''' </summary>
    ''' <remarks></remarks>
    <Category("Fixkosten")> _
    <Test()> _
    Public Sub OpenFixedCosts()
        Dim fixedCosts As ClausSoftware.Kernel.FixedCosts = m_Application.FixedCosts
        Assert.IsNotNull(fixedCosts, "Fixkostentabelle konnte nicht geöffnet werden")

    End Sub


    <Test(Description:="Öffne Appointments (Termine)")> _
    Public Sub OpenAppointments()
        Dim ap As Kernel.Appointments = m_Application.Appointments

        Assert.NotNull(ap, "Appointments konnten nicht geöffnet werden")
        Assert.IsTrue(ap.Count >= 0, "Appointments.Count abfragen geht nicht")


    End Sub

    <Test()> _
    Public Sub OpenAppointmentRessource()
        Dim apR As Kernel.AppointmentsResources = m_Application.AppointmentResources
        Assert.NotNull(apR, "Appointment-Resource  konnten nicht geöffnet werden")
        Assert.IsTrue(apR.Count >= 0, "AppointmentRessources.Count abfragen geht nicht")

    End Sub

    ''' <summary>
    ''' Öffnet die Kassenbucheinträge
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="Kassenbucheinträge")> _
    Public Sub OpenCashJournalItems()
        Dim cash As Kernel.CashJournalItems = m_Application.CashJournal
        Assert.NotNull(cash, "CashJournalItems  konnten nicht geöffnet werden")
        Assert.IsTrue(cash.Count >= 0, "CashJournalItems.Count abfragen geht nicht")

    End Sub


    ''' <summary>
    ''' Öffnet die Kassenbucheinträge
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="Kassenbucheinträge")> _
    Public Sub OpenCashJournalIAccounts()
        Dim cash As Kernel.CashAccounts = m_Application.CashAccounts
        Assert.NotNull(cash, "CashAccounts  konnten nicht geöffnet werden")
        Assert.IsTrue(cash.Count >= 0, "CashAccounts.Count abfragen geht nicht")

    End Sub

    <Category("Fixkosten")> _
    <Test()> _
    Public Sub CreateNewFixedCosts()
        Dim orgCount As Integer
        Dim fixedCosts As ClausSoftware.Kernel.FixedCosts = m_Application.FixedCosts

        orgCount = fixedCosts.Count ' Origane Anzahl feststellen

        Dim newItem As ClausSoftware.Kernel.FixedCost = fixedCosts.GetNewItem

        newItem.Subject = "Test-Eintrag"        
        newItem.Save()
        fixedCosts.Reload()


        Assert.Greater(fixedCosts.Count, orgCount, "Es sollte die Anzahl der Fixkosten nach Neuanlage erhöht worden sein. ")

    End Sub

    <Category("settings")> _
    <Description("Prüft die unterschiedlichen Möglichkeiten des Laden und Speichern von Einstellungen")> _
    Public Sub TestSettings()

        Dim valueOwnValue As String = "Deins"
        Dim valueOtherValue As String = "Meins"
        Dim valueNoUser As String = "No Value"

        m_Application.Settings.SetSetting("ABC", "123", valueOwnValue) ' Speichert einen Wert, und weist diesen dem aktuellen Benutzer zu
        m_Application.Settings.SetSetting("ABC", "123", valueOtherValue, "dummyUser") ' Speichert einen Wert, und weist diesen einem anderen Benutzer zu

        Dim testOwnValue As String
        Dim testOtherValue As String
        Dim testNoValue As String


        testOwnValue = m_Application.Settings.GetSetting("ABC", "123", "") ' mein eiger wert abholen
        testOtherValue = m_Application.Settings.GetSetting("ABC", "123", "", "dummyUser") ' Anderen wert abholen

        Assert.AreEqual(valueOwnValue, testOwnValue, "Benutzerwert war nach dem einlesen nicht gleich dem geschriebenen wert")
        Assert.AreEqual(valueOtherValue, testOtherValue, "Wert eines anderen Benutzers war nach dem einlesen nicht gleich dem geschriebenen wert")


        m_Application.Settings.SetSetting("ABC", "123", valueNoUser, "") ' Speichert einen Wert ohne Benutzerzuweisung
        m_Application.Settings.SetSetting("ABC", "123", "QuatschValue") ' Darf nicht den Wert ohne Benutzerangabe überschreiben

        testNoValue = m_Application.Settings.GetSetting("ABC", "123", "", "")
        Assert.AreEqual(valueNoUser, testNoValue, "Geschriebener Wert ist nicht mit dem gelesenen Wert identisch!")
    End Sub


    ''' <summary>
    ''' Beim Start muss immer ein Applikations-Benutzer existieren
    ''' </summary>
    ''' <remarks></remarks>
    <Category("Kernel")> _
    <Test()> _
    Public Sub ApplicationUserSet()
        Assert.NotNull(m_Application.CurrentUser, "Ein standard-benutzer muss immer gesetzt sein. Ist Keine Benutzerverwaltung aktiv, so muss ein Dummy-Benutzer mit Rechnernamen/Anmeldenamen gesetzt sein.")
        Assert.NotNull(m_Application.CurrentUser.Key, "ein Standardbenutzer ist gesetzt. Die Key-Eigenschaft war aber leer.")

    End Sub

    ''' <summary>
    ''' Die Application ID sollteniemals leer sein!
    ''' </summary>
    ''' <remarks></remarks>
    <Test()> _
    Public Sub testAppID()
        Assert.IsNotEmpty(m_Application.ApplicationID)
    End Sub

    ''' <summary>
    ''' Öffnet den Adressen-Datensatz
    ''' </summary>
    ''' <remarks></remarks>
    <Test()> _
     Public Sub OpenAddress()

        Dim adressen As Kernel.Adressen

        adressen = m_Application.Adressen
        Assert.IsNotNull(adressen, "Adressen war kein gefülltes Objekt")
        Assert.IsTrue(adressen.Count >= 0, "Adressen.Count konnte nicht ermittelt werden")

    End Sub

    <Test(Description:="Ruft die Auflistung der Calls für diesen Kontakt ab")> _
    Public Sub TestAdressPhoneCallList()
        Dim pc As PhoneCalls = m_Application.Adressen(0).PhoneCallList

        Assert.NotNull(m_Application.Adressen(0).PhoneCallList, "Liste der Calls für eine Adresse war leer")


        Dim orgCount As Integer = pc.Count ' Anzahl merken


        Dim newcall As PhoneCall = pc.GetNewItem()
        newcall.CallerAddress = m_Application.Adressen(0)
        newcall.CallingID = "007"
        newcall.Save()

        pc.Reload()

        ' Anzahl sollte nun um 1 höher sein 
        Assert.IsTrue(pc.Count > orgCount, "Scheinbar wurde der neue Call nicht der Adresse zugwiesen")


        newcall.CallerAddress = Nothing
        Assert.IsNull(newcall.CallerAddress, "Sollte nothing zurückgeben")

        Assert.NotNull(newcall.CallState, "Anrufzustand darf nicht nothing sein")
        newcall.Reload()
        Assert.IsTrue(newcall.CallerAddress.Key = m_Application.Adressen(0).Key, "Anruferadreswse sollte nun wieder hergestellt sein")

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
    <Description("Setzt ein Lock auf ein beliebiges Element und prüft dieses")> _
    <Test()> _
    Public Sub BeginLock()
        Dim maxCount As Integer = m_Application.Adressen.Count - 1
        Dim r As Random = New Random()

        Dim index As Integer = r.Next(0, maxCount - 1)

        Dim Adress As Kernel.Adress = m_Application.Adressen(index)
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

    <Test(description:="Öffnet die Artikel-Attribute liste")> _
    Public Sub OpenClassDefinitions()
        Dim classdef As Kernel.Attributes.ClassDefinitions = m_Application.ClassDefinitions
        Assert.IsNotNull(classdef, "Classefinition war nothing")
        Assert.IsTrue(classdef.Count >= 0, "Konnte die Anzahl nicht abrufen")

    End Sub

    <Description("Loading Application Units")> _
    <Test()> _
     Public Sub OpenUnits()
        Debug.Print("Lade Einheiten")

        Dim Einheiten As Kernel.Units

        Einheiten = m_Application.Units
        Assert.IsNotNull(Einheiten, "Einheiten war kein gefülltes Objekt")
        Assert.IsTrue(Einheiten.Count >= 0, "Einheiten.Count konnte nicht ermittelt werden")

        Debug.Print("EinheitName: " & Einheiten(0).Name)
        Debug.Print("DatanormKuerzel: " & Einheiten(0).DatanormShortName)

    End Sub

    ''' <summary>
    ''' Fixkostengruppe
    ''' </summary>
    ''' <remarks></remarks>
    <Test(description:="Öffne Fixkostengruppen")> _
    Public Sub OpenFixedCostGroups()
        Dim fg As Kernel.FixedCostGroups = m_Application.FixedCostGroups

        Assert.IsNotNull(fg, "Fixkostengruppe war kein gefülltes Objekt")
        Assert.IsTrue(fg.Count >= 0, "Fixkostengruppe.Count konnte nicht ermittelt werden")

    End Sub

    ''' <summary>
    ''' Ermittelt die letzte gemessene Datenbankgechwindigkeit
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TestLastDatabaseSpeedValue()
        Dim value As Integer = m_Application.LastDatabaseSpeed

    End Sub
    ''' <summary>
    ''' Artikelgruppen
    ''' </summary>
    ''' <remarks></remarks>
    <Test(description:="ArtikelGruppen")> _
    Public Sub OpenArticleGroups()
        Dim fg As Kernel.Groups = m_Application.Groups

        Assert.IsNotNull(fg, "Artikelgruppen war kein gefülltes Objekt")
        Assert.IsTrue(fg.Count >= 0, "Artikelgruppen.Count konnte nicht ermittelt werden")

    End Sub

    <Test(description:="Öffne Rabatte-Klasse")> _
    Public Sub OpenDiscounts()
        Dim discounts As Kernel.Discounts = m_Application.Discounts
        Assert.IsNotNull(discounts, "Rabatte war kein gefülltes Objekt")
        Assert.IsTrue(discounts.Count >= 0, "Discounts.Count konnte nicht ermittelt werden")

    End Sub

    <Description("Getting Database Version")> _
    <Test()> _
    Public Sub GetDBVersion()
        Dim DBValue As String
        DBValue = m_Application.DBVersion
        Debug.Print("Datenbankversion ist: " & DBValue)


        m_Application.DBVersion = "1.2.3"

        StringAssert.AreEqualIgnoringCase("1.2.3", m_Application.DBVersion)
        ' wieder herstellen
        m_Application.DBVersion = DBValue

    End Sub


    <Test()> _
    <ExpectedException(GetType(ArgumentException))> _
    Public Sub SetDBVersion()
        Dim DBValue As String
        DBValue = m_Application.DBVersion
        Debug.Print("Datenbankversion ist: " & DBValue)
        ' Setze richtige DB Version

        m_Application.DBVersion = "1.4.712"

        Debug.Assert(m_Application.DBVersion = "1.4.712", "Datenbankversion konnte nicht gesetzt werden")
        m_Application.DBVersion = DBValue
        'Sollte einen Fehler auslösen 
        m_Application.DBVersion = "Humptydumpty"


    End Sub

    <Test()> _
    Public Sub TestAttachments()
        Dim a As Kernel.Attachments = New Kernel.Attachments(m_Application)

        Assert.NotNull(a, "Attachmets sind null")
        Assert.NotNull(a.Count, "Attachments.count sind null")

    End Sub

    <Test()> _
    Public Sub CreateAttachment()
        Dim a As Kernel.Attachment = New Kernel.Attachment(m_Application.Session)
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
    <Test()> _
     Public Sub GetAdressItem()

        Dim adressen As Kernel.Adressen
        adressen = m_Application.Adressen
        If adressen.Count > 0 Then
            Debug.Print("Company: " & adressen(0).Company)
            Debug.Print("ContactsName: " & adressen(0).ContactsName)
            Debug.Print("Anmerkungen: " & adressen(0).Description)
            Debug.Print("Datanorm: " & adressen(0).Datanorm)
            Debug.Print("LastChanged: " & adressen(0).ChangedAt)
            Debug.Print("Fax: " & adressen(0).Fax)
            Debug.Print("ebayID: " & adressen(0).ebayID)
        End If

    End Sub

    <Test()> _
    Public Sub CreateAddress()
        Dim Adressen As Kernel.Adressen = m_Application.Adressen
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
        m_Application.Settings.SettingAdressID_Format = "$NR - $YY"
        Adresse.RefreshDisplayID()

        Debug.Print("Neue Adressennummer: " & Adresse.ContactDisplayID)
        StringAssert.EndsWith("74", Adresse.ContactDisplayID)

        Debug.Print("Lösche:" & Adresse.ToString)

        Adressen.Remove(Adresse)
        Adresse.Delete()


    End Sub
    <Description("Testes die Eindeutigkeit von Kennzeichnungen")> _
    <Test()> _
    Public Sub TestAdressesUniqeIds()
        Dim guid As String = System.Guid.NewGuid.ToString

        Assert.IsTrue(m_Application.Adressen.CheckUniqueID(guid), "Unique ID war nicht eindeutig!")  ' Diese ID sollte auf jeden Fall eindeutig sein

        Dim newAdress As Adress = m_Application.Adressen.GetNewItem
        newAdress.ebayID = guid
        newAdress.Save()

        Assert.IsFalse(m_Application.Adressen.CheckUniqueID(guid), "Unique ID sollte vergeben sein!")  ' Diese ID sollte auf jeden Fall eindeutig sein

        Dim testAdress As Adress = m_Application.Adressen.GetItemByUniqueID(guid)

        Assert.AreEqual(testAdress.Key, newAdress.Key, "Adresse konnte durch Unique ID nicht ermittelt werden")


    End Sub

    <Test()> _
     Public Sub OpenBriefe()

        Dim Briefe As Kernel.Letters

        Briefe = m_Application.Letters
        Assert.IsNotNull(Briefe, "Briefe war kein gefülltes Objekt")
        Assert.IsTrue(Briefe.Count >= 0, "Adressen.Count konnte nicht ermittelt werden")

    End Sub
    <Test()> _
    Public Sub AdressHistory()

        Dim adress As Kernel.Adress = m_Application.Adressen(0)
        Dim Histories As Kernel.AddressHistoryItems = adress.History

        Assert.IsTrue(Histories.Categories.Count > 0, "Histories sollte mindestes eine Standard-Kategorie besitzen")



        Dim OldCount As Integer
        OldCount = Histories.Count

        Dim newentry As Kernel.AddressHistoryItem = Histories.GetNewItem
        newentry.Adress = adress
        newentry.Category = m_Application.HistoryCategories.GetRemindersCategory
        newentry.Text = "Test History entry"
        newentry.Save()

        Assert.IsNotNullOrEmpty(newentry.Category.ToString)
        Assert.NotNull(newentry.Adress, "Addresse des History-elementes konnte nicht ermittelt werden")
        Assert.IsNotNullOrEmpty(newentry.Adress.ToString, "Address-Text des History-elementes konnte nicht ermittelt werden")

        Debug.Print("Kategoriename: " & newentry.Category.ToString)

        Assert.Greater(adress.History.Count, OldCount, "Neuer Histrory-eintrag wurde nicht der Auflistung hinzugefügt")

        Histories.Delete() ' Alle einträge wieder löschen 

    End Sub

    <Test()> _
     Public Sub OpenImages()

        Dim images As Kernel.Images

        images = m_Application.Images
        Assert.IsNotNull(images, "Bilder war kein gefülltes Objekt")
        Assert.IsTrue(images.Count >= 0, "images.Count konnte nicht ermittelt werden")

    End Sub

    <Test()> _
        Public Sub OpenNotes()

        Dim Notes As Kernel.Letters
        Notes = m_Application.Letters
        Assert.IsNotNull(Notes, "Notes war kein gefülltes Objekt")
        Assert.IsTrue(Notes.Count >= 0, "Notes.Count konnte nicht ermittelt werden")

    End Sub


    <Test()> _
     Public Sub ShowBriefe()
        Debug.Print("ShowBriefe")
        Dim Briefe As Kernel.Letters

        Briefe = m_Application.Letters
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

    <Test()> _
         Public Sub OpenJournal()
        Debug.Print("Öffen Journal der Dokumente")
        Dim Journal As Kernel.JournalDocuments
        Journal = m_Application.JournalDocuments


        Assert.IsNotNull(Journal, "Journal war kein gefülltes Objekt")
        Assert.IsTrue(Journal.Count >= 0, "Journal.Count konnte nicht ermittelt werden")

    End Sub
    <Test()> _
    Public Sub OpenJournalItems()
        Dim jItems As New Kernel.JournalArticleItems(m_Application)
        Assert.NotNull(jItems, "JournalItems war kein gefülltest Objekt!")

    End Sub




    <Test()> _
         Public Sub OpenArticleList()
        Debug.Print("Öffnet Materialliste")
        Dim Materialliste As Kernel.Articles
        Materialliste = m_Application.ArticleList

        Assert.IsNotNull(Materialliste, "Materialliste war kein gefülltes Objekt")
        Assert.IsTrue(Materialliste.Count >= 0, "Materialliste.Count konnte nicht ermittelt werden")

    End Sub

    <Test()> _
         Public Sub OpenJournalPositions()
        Debug.Print("Öffen eine Position im Journal der Dokumente")
        Dim Journal As Kernel.JournalDocuments
        Journal = m_Application.JournalDocuments


        Assert.IsNotNull(Journal, "Journal war kein gefülltes Objekt")
        Assert.IsTrue(Journal.Count >= 0, "Journal.Count konnte nicht ermittelt werden")


        Assert.IsTrue(Journal(0).ArticleGroups.Count >= 0, "Das Journaldokument enthält keine Positionen")



    End Sub

    <Test()> _
         Public Sub OpenItems()
        Debug.Print("Öffen Artikelliste der Dokumente")
        Dim Items As Kernel.JournalArticleItems

        Items = New Kernel.JournalArticleItems(m_Application)

        Assert.IsNotNull(Items, "Artikelliste war kein gefülltes Objekt")
        Assert.IsTrue(Items.Count >= 0, "Artikelliste.Count konnte nicht ermittelt werden")

    End Sub


    <Test()> _
         Public Sub OpenPositions()
        Debug.Print("Öffen Positionen der Dokumente")
        Dim Position As Kernel.JournalArticleGroups

        Position = New Kernel.JournalArticleGroups(m_Application)

        Assert.IsNotNull(Position, "Positionen war kein gefülltes Objekt")
        Assert.IsTrue(Position.Count >= 0, "Positionen.Count konnte nicht ermittelt werden")

    End Sub

    <Test()> _
         Public Sub OpenPositionItems()
        Debug.Print("Öffen die Artikel der Positionen der Dokumente")
        Dim Positionen As Kernel.JournalArticleGroups

        Positionen = New Kernel.JournalArticleGroups(m_Application)

        Assert.IsNotNull(Positionen, "Positionen war kein gefülltes Objekt")
        Assert.IsTrue(Positionen.Count >= 0, "Positionen.Count konnte nicht ermittelt werden")
        If Positionen.Count > 0 Then
            Assert.IsTrue(Positionen(0).ArticleList.Count >= 0, "Positionen(0).Items.Count konnte nicht ermittelt werden")
            For Each item As Kernel.JournalArticleItem In Positionen(0).ArticleList
                'TODO: Hier den Test ergänzen                
            Next
        End If

    End Sub

    <Description("Öffnet die Aufgabenliste")> _
    <Test()> _
    Public Sub OpenTasks()
        Debug.Print("Öffnet die Aufgabenliste")
        Dim tasks As Kernel.Tasks

        tasks = m_Application.Tasks

        Assert.IsNotNull(tasks, "Aufgaben war kein gefülltes Objekt")
        Assert.IsTrue(tasks.Count >= 0, "Aufgabenliste.Count konnte nicht ermittelt werden")

    End Sub

    <Description("Öffnet die Forderungen-Liste")> _
<Test()> _
    Public Sub OpenTransactions()
        Debug.Print("Öffnet die Forderungen-Liste")
        Dim trans As Kernel.Transactions

        trans = m_Application.Transactions

        Assert.IsNotNull(trans, "Forderungen/ Verbindlichkeiten war kein gefülltes Objekt")
        Assert.IsTrue(trans.Count >= 0, "Forderungen/ Verbindlichkeiten .Count konnte nicht ermittelt werden")

    End Sub

    <Test()> _
         Public Sub OpenMWST()
        Debug.Print("Öffen Mehrwertsteuer-Tabelle der Dokumente")
        Dim Steuern As Kernel.TaxRates

        Steuern = New Kernel.TaxRates(m_Application)

        Assert.IsNotNull(Steuern, "Mehrwertsteuer war kein gefülltes Objekt")
        Assert.IsTrue(Steuern.Count >= 0, "Artikelliste.Count konnte nicht ermittelt werden")

    End Sub

    <Description("Holt ein Objekt anhand der Indexnummer der Auflistung ab")> _
    <Test()> _
    Public Sub OpenObjectbyID()
        Dim target As Object
        target = m_Application.ArticleList(0)
        Assert.NotNull(target, "Es konnte kein Objekt an der Position '0' geholt werden")

    End Sub

    <Description("Testt eine leeres Kriterium in einer Collection")> _
    <Test()> _
    Public Sub TestEmptyCollectionCriteria()
        Dim testcll As Articles = New Articles(m_Application, Nothing)
        Assert.IsTrue(testcll.Count > 0, "Die Auflistung sollte mit einem leerem Kriterium gefüllt sein.")
    End Sub


    <Description("Holt ein Objekt anhand einer ungültigen Indexnummer der Auflistung ab")> _
<Test()> _
    Public Sub OpenObjectbyInvalidID()
        Dim target As Object
        target = m_Application.ArticleList(m_Application.ArticleList.Count + 5)
        Assert.IsNull(target, "Bei einer ungültigen Zugriffsnummer sollte 'nothing' zurückgegeben werden!")

    End Sub

    <Ignore("MySQL Dump für Server-DB nötig; klappt nicht als Unit-Test")> _
    <Test()> _
    Public Sub TestStartBackup()
        Dim result As Boolean = m_Application.Database.StartBackup()
        Assert.IsTrue(result, "Anlegen der Sicherungskopie hat 'False' ergeben.")

    End Sub

    ''' <summary>
    ''' Holt die Tabelle der Properties, der Einstellungen ab
    ''' </summary>
    ''' <remarks></remarks>
    <Test()> _
    Public Sub OpenEinstellungen()
        Debug.Print("Öffne Einstellungen-Tabelle")
        Dim Einstellungen As Kernel.Settings

        Einstellungen = New Kernel.Settings(m_Application)

        Assert.IsNotNull(Einstellungen, "Einstellungen war kein gefülltes Objekt")
        Assert.IsTrue(Einstellungen.Count >= 0, "Einstellungen.Count konnte nicht ermittelt werden")

    End Sub

    <Test()> _
    Public Sub GetSetting()
        Debug.Print("Lese und Setze Einstellungen-Tabelle ")
        Dim Einstellungen As Kernel.Settings

        Einstellungen = New Kernel.Settings(m_Application)
        'Sollte eine Exception auslösen
        Dim Wert As String
        Wert = Einstellungen.GetSetting("irgendwas nicht da", "Kenne ich nicht")
        Assert.AreSame(Wert, String.Empty, "Eine nicht gefundene Einstellung sollte einen leeren Wert zurückgeben")

        ' Setze Werte und hole Werte
        Dim EinstellungName As String = "Test-Value"

        Einstellungen.SetSetting(EinstellungName, "Test", "Ohne Benutzer")

        Einstellungen = m_Application.Settings
        Einstellungen.Reload()

        Wert = Einstellungen.GetSetting(EinstellungName, "Test")
        Assert.AreNotSame(Wert, String.Empty, "(nicht Benutzerdefiniert) Der Wert " & EinstellungName & "  sollte etwas anderes als einen Leerstring enthalten")
        Debug.Print("(nicht Benutzerdefiniert) Einstellung " & EinstellungName & "  hatte den Wert:" & Wert)


        ' Benutzerdefinierte Einstellung
        Einstellungen.SetSetting(EinstellungName, "Test", "Test-User", "Benutzerdefiniert")

        Einstellungen = m_Application.Settings
        Einstellungen.Reload()

        Wert = Einstellungen.GetSetting(EinstellungName, "Test", "Test-User")
        Assert.AreNotSame(Wert, String.Empty, "(Benutzerdefiniert) Der Wert " & EinstellungName & "  sollte etwas anderes als einen Leerstring enthalten")
        Debug.Print("(Benutzerdefiniert) Einstellung " & EinstellungName & "  hatte den Wert:" & Wert)

    End Sub

    <Category("Security")> _
    <Description("Legt einen dummy-Benutzer fest, der aus dem Rechnernamen und eingeloggtem Benutzernamen gebildet wird")> _
    <Test()> _
    Public Sub getUserByComputer()
        Dim dummyUser As ClausSoftware.Kernel.security.User = m_Application.Users.GetUserByComputer()

        Assert.AreEqual(dummyUser.Name, dummyUser.Key, "DummyUser muss denselben Schlüssel haben wie Name")
        Assert.AreEqual(dummyUser.Name, Kernel.security.Users.MachineUserName, "DummyUser.Name format muss sein: ComputerName\UserName")
        Assert.AreEqual(dummyUser.Name, Kernel.security.Users.MachineUserName, "DummyUser.Name format muss sein: ComputerName\UserName")


    End Sub


    <Test()> _
    <Description("Neue Adress-Einträge müssen immer das aktuelle Erstellungsdatum und Ersteller aufweisen")> _
    Public Sub AnewItemHasCorrectCreatedAtState()
        Dim newAdress As Kernel.Adress = m_Application.Adressen.GetNewItem

        Assert.AreEqual(newAdress.CreatedAt, Date.Today, "Adressen Erstellungsdatum war nicht gesetzt.")
        Assert.AreEqual(newAdress.CreatedByID, m_Application.CurrentUser.Key, "Ersteller einer neuen Adresse war nicht gesetzt. Auch wenn keine Benutzerverwaltung isntalliert ist, muss immer der User.Key als Ersteller angegeben sein (sonst Rechnername/Benutzername)")



    End Sub

    <Test()> _
    Public Sub TestBaseClassMethods()
        Dim a As Kernel.Adress = m_Application.Adressen(0)
        Debug.Print("IsDeleted: " & CType(a, BaseClass).IsDeleted)
        Debug.Print("IsLoading: " & CType(a, BaseClass).IsLoading)

        Assert.IsTrue(m_Application.Adressen.Contains(a), "Contains lieferte False (True erwartet)")
        Assert.IsTrue(m_Application.Adressen.ContainsKey(a.Key), "Contains lieferte False (True erwartet)")
        Assert.IsFalse(m_Application.Adressen.ContainsKey("Test123abnc"), "Contains lieferte True (False erwartet)")

        Dim newA As Kernel.Adress = CType(a.Clone, Kernel.Adress)
        Assert.NotNull(newA, "Klon einer Adresse schlug fehl")

        Assert.NotNull(m_Application.Adressen.FullTextSearchColumns, "Volltext (Adressbuch) war nothing.")

    End Sub

    <Category("Kernel")> _
    <Test(description:="Ruft einige Daten der Tabellen ab")> _
    Public Sub GetStatsParameter()
        Dim i As StatisticInfo = m_Application.UserStats.InfoItem

        Assert.NotNull(i.AddessbookCount, "Konnte nicht gelesen werden")
        Assert.NotNull(i.ArticleCount, "Konnte nicht gelesen werden")
        Assert.NotNull(i.InvoiceCount, "Konnte nicht gelesen werden")
        Assert.NotNull(i.NextAddressNumber, "Konnte nicht gelesen werden")
        Assert.NotNull(i.NextArticleNumber, "Konnte nicht gelesen werden")
        Assert.NotNull(i.NextInvoiceNumber, "Konnte nicht gelesen werden")
        Assert.NotNull(i.NextOffersNumber, "Konnte nicht gelesen werden")


    End Sub

    <Category("Kernel")> _
    <Test(Description:="BaseCollection=ToArray")> _
    Public Sub ToArraytest()
        Dim lst As List(Of Kernel.Adress) = m_Application.Adressen.ToArray()

        Assert.NotNull(lst, "Liste 'ToArray' war nothing.")

    End Sub

    <Category("Kernel")> _
    <Test(description:="Ruft Daten direkt aus der Datenbankschnittstelle oder lokaler Aufllistung ab")> _
    Public Sub GetFromDB()
        Dim a As Kernel.Adress = m_Application.Adressen(0)

        Assert.NotNull(m_Application.Adressen.GetFromDB(a.Key), "Ermitteln eines Datensatzes aus Datenbank anhand des Schlüssels fehlgeschlagen.")
        Assert.NotNull(m_Application.Adressen.GetFromDB(a.ID), "Ermitteln eines Datensatzes aus Datenbank anhand des Schlüssels fehlgeschlagen.")

        Assert.NotNull(m_Application.Adressen.GetItem(a.ID), "Bekannter Datensatz aus lokaler Auflistung geht nicht")
        Assert.NotNull(m_Application.Adressen.GetItem(a.Key), "Bekannter Datensatz aus lokaler Auflistung geht nicht")


    End Sub

    <Category("Addins")> _
    <Test(description:="Rufe Addins auf")> _
    Public Sub StartAddins()


        Assert.NotNull(m_Application.AddIns, "Addins konnten nicht geöffnet werden")
        Assert.NotNull(m_Application.AddIns.AddIns.Count, "Addins.Count konnten nicht geöffnet werden")

        Debug.Print("Addin count: " & m_Application.AddIns.AddIns.Count)
    End Sub

    <Test(description:="testet allgemeine Artikeleigenschaften der Rechnungserstellung")> _
    Public Sub Settingstest()
        Assert.NotNull(m_Application.Settings.ItemsSettings.ShowWithoutTax, "ShowItemsnetto hat nothing zurückgegeben")
        Assert.NotNull(m_Application.Settings.ItemsSettings.ShowItemsWithTax, "ShowItemswithTax hat nothing zurückgegeben")

        m_Application.Settings.ItemsSettings.ShowWithoutTax = True
        Assert.IsTrue(m_Application.Settings.ItemsSettings.ShowWithoutTax, "True war erwartet")

        m_Application.Settings.ItemsSettings.ShowWithoutTax = False
        Assert.IsFalse(m_Application.Settings.ItemsSettings.ShowWithoutTax, "False war erwartet")


    End Sub

    ''' <summary>
    ''' Testst fixkostengruppen
    ''' </summary>
    ''' <remarks></remarks>
    <Test(description:="Testet Fixkostengruppen")> _
    Public Sub testFixedCostsGroups()
        Dim fg As FixedCostGroups = m_Application.FixedCostGroups

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
    <Test()> _
    Public Sub TestRecentlyUsed()
        Dim ru As RecentlyUsedItems = m_Application.RecentlyUsedItems

        Assert.NotNull(ru, "Recently Used Groups war nothing")

        Dim newItem As RecentlyUsed = ru.GetNewItem
        newItem.CalledAt = Now

        Dim TestItem As Adress = m_Application.Adressen.GetItem(1)

        newItem.SetRecentItem(TestItem)

        Assert.NotNull(newItem.GetRecentlyUsedItem, "Das zurückgegebene Element war nothing")



    End Sub

    <Test(description:="Tests die Arbeitszeiten-Konten")> _
    Public Sub TestLoadAccounts()
        Dim ac As LoanAccounts = m_Application.LoanAccounts

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

    <Test(description:="Testet die Textbausteine")> _
    Public Sub TestTextTemplates()
        Dim t = m_Application.TextTemplates

        Assert.NotNull(t, "TextTemplates konnten nicht von der Stammklasse ermittelt werden")
        Assert.IsTrue(t.Count > 0, "")

        Dim newText As TextTemplate = m_Application.TextTemplates.GetNewItem
        newText.Text = "Hallo welt"

        Assert.IsTrue(newText.HasChanged, "Das 'HasChanged' - Flag ist nicht gesetzt!") ' Nicht Objektspeziefisch !

        newText.Save()

        newText.Delete()

        'Assert.IsTrue(newText.IsDeleted, "IsDeleted - eigenschaft ist nicht True nach dem löschen!")
    End Sub

    Public Sub New()

    End Sub
End Class
