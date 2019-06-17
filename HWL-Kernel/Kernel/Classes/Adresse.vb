Option Explicit On
Option Strict On


Imports DevExpress.Xpo
Imports ClausSoftware.Data
Imports System.Text


Namespace Kernel

    ''' <summary>
    ''' Stellt eine Kunden oder Kontaktadresse dar
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(Adress.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Adress
        Inherits TrackedItem
        Implements IDataItem
        Implements IHasActiveProperty



        Friend Const Tablename As String = "Adressen"

#Region "Properties"
        Private m_company As String = String.Empty
        Private m_isActive As Boolean = True

        Private m_Kundennummer As Integer
        Private m_eBayID As String
        Private m_firstName As String = String.Empty
        Private m_lastName As String = String.Empty

        Private m_street As String = String.Empty
        Private m_Postleitzahl As String = String.Empty
        Private m_Town As String = String.Empty
        Private m_country As String = String.Empty

        Private m_dateField As String = String.Empty
        Private m_KindOfBusiness As String = String.Empty
        Private m_Postempfänger As Boolean
        Private m_phone1 As String = String.Empty
        Private m_phone2 As String = String.Empty
        Private m_Fax As String = String.Empty
        Private m_Mobil As String = String.Empty
        Private m_email As String = String.Empty
        Private m_Rabatt As String = String.Empty
        Private m_description As String = String.Empty
        Private m_Datanorm As String = String.Empty
        Private m_Bankname As String = String.Empty
        Private m_Bankleitzahl As String = String.Empty
        Private m_Kontonummer As String = String.Empty
        Private m_deliveryAdress As String = String.Empty
        Private m_LetzeÄnderung As String = String.Empty
        Private m_UserChangedAdressFenster As Boolean
        Private m_invoiceAdress As String = String.Empty
        Private m_notes As String = String.Empty
        Private m_deletedsys As Integer
        Private m_deletedint As Integer

        Private m_tag As String = String.Empty
        Private m_contactsDisplayID As String
        Private m_PhoneCalls As PhoneCalls

        Private m_wirdgedruckt As Boolean

        ' IstKunde - Boolean ( 1 = Ja , 0 0 Nein )
        Private m_IstKunde As Boolean

        ' IstLieferant
        Private m_IstLieferant As Boolean

        ''' <summary>
        ''' Wenn wahr, dann wird das Lieferadress-Fenster automatisch mit jeer Änderunge der Adressdaten ebenfalls geändert. 
        ''' </summary>
        ''' <remarks></remarks>
        Private m_deliveryAdressLinked As Boolean = True

        ' Zahlungsziele für einen Kunden
        Private m_targetPayDays As Integer = 14
        Private m_enableTargetPayDate As Boolean


        ''' <summary>
        ''' Löscht den Kontakt nach einer Prüfung, ob ungelöste Abhängigkeiten existieren
        ''' </summary>
        ''' <remarks></remarks>
        ''' <exception cref="Exception"> Unresolved Constraints</exception>
        Public Overrides Sub Delete()
            If Not Me.HasUnresolvedContraints Then
                MyBase.Delete()
            Else

                Throw New Exception("Adress has referenced Journaldocuments!")
            End If

        End Sub

        ''' <summary>
        ''' Schaltet ein Kundenspezifisches Zahlungsziel ein- oder aus
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("EnableTargetPayDate")> _
        Property EnableTargetPayDate As Boolean
            Get
                Return m_enableTargetPayDate
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("EnableTargetPayDate", m_enableTargetPayDate, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Anzahl der Tage ab, die bei einem Zahlungsziel für diesen Kontakt vergeben werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("TargetPayDays")> _
        Property TargetPayDays As Integer
            Get
                Return m_targetPayDays
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TargetPayDays", m_targetPayDays, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die History dieses Eintrages ab. Wird stets aus der Datenbank neu eingelesen. 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function History() As AddressHistoryItems
            Dim myHistory As AddressHistoryItems = New AddressHistoryItems(MainApplication)

            Dim cr As New DevExpress.Data.Filtering.BinaryOperator("AddressID", Me.Key, DevExpress.Data.Filtering.BinaryOperatorType.Equal)

            myHistory.Criteria = cr
            Return myHistory

        End Function

        ''' <summary>
        ''' Wenn True, wird die Lieferadresse gleich der Rechnungsadresse gesetzt. Jede Änderung der Rechnungsadresse bewirkt auch eine änderung der
        ''' Lieferadresse.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("DeliveryAdressLinked", "Lieferadresse gleich Rechnungsadresse")> _
        <Persistent("DeliveryAdressLinked")> _
        Public Property DeliveryAdressLinked() As Boolean
            Get
                Return m_deliveryAdressLinked
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("DeliveryAdressLinked", m_deliveryAdressLinked, value)
            End Set
        End Property


        Public Event PropertyChanged(ByVal sender As Object, ByVal e As ComponentModel.PropertyChangedEventArgs)

        ''' <summary>
        ''' Ruft einen erweitertes Adressfeld mit Adresse, Mail und Telefonnummer ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetExtendedAdressField() As String
            Dim field As New StringBuilder

            If Not String.IsNullOrEmpty(Company) Then
                field.AppendLine(Company)
            End If
            If Not String.IsNullOrEmpty(ContactsName) Then
                field.AppendLine(ContactsName)
            End If

            If Not String.IsNullOrEmpty(ZipCode) Then
                field.Append(ZipCode)
            End If

            If Not String.IsNullOrEmpty(Town) Then
                field.AppendLine(Town)
            End If

            If Not String.IsNullOrEmpty(Telefon1) Then
                field.AppendLine(Telefon1)
            End If

            If Not String.IsNullOrEmpty(Telefon2) Then
                field.AppendLine(Telefon2)
            End If

            If Not String.IsNullOrEmpty(EMail) Then
                field.AppendLine(EMail)
            End If

            Return field.ToString

        End Function
        ''' <summary>
        ''' Ruft die Lieferadresse ab ode legt diese fest.
        ''' Lieferadresse kann frei definiert werden und kann anders sein, als die Rechnungsadresse
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
<ClausSoftware.Tools.DisplayName("DeliveryAdress", "Lieferadresse")> _
<Persistent("LieferAdresse")> _
        Public Property DeliveryAdress() As String
            Get
                Return m_deliveryAdress
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("DeliveryAdress", m_deliveryAdress, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft ein eindeutiges Flag ab oder legt dies fest; Wird benutzt um Adressen mit einem externen Programm 
        ''' zu synchronisieren
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("Tag")> _
        Public Property Tag() As String
            Get
                If m_tag IsNot Nothing Then
                    Return m_tag
                Else
                    Return String.Empty
                End If
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("Tag", m_tag, value)

                RaiseEvent PropertyChanged(Me, New ComponentModel.PropertyChangedEventArgs("Tag"))

            End Set
        End Property

        ''' <summary>
        ''' Ruft den Anzeigetext der Adressnummer ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()> _
        <ClausSoftware.Tools.DisplayName("ContactDisplayID", "Kontaktnummer")> _
        <Persistent("ContactDisplayID")> _
        Public Property ContactDisplayID() As String
            Get
                Return m_contactsDisplayID
            End Get
            Set(ByVal value As String)

                SetPropertyValue("ContactDisplayID", m_contactsDisplayID, value)

            End Set
        End Property

        ''' <summary>
        ''' Löschen der eigenen Adresse verhindern
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnDeleting()
            If Me.ID = 0 Then Exit Sub
            MyBase.OnDeleting()
        End Sub

        ''' <summary>
        ''' Speichert die Adresse ab. Bei neuen Adressen wird eine neue Kundennummer vergeben
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()

            If Me.Kundennummer = 0 Then
                ' Neue Nummer holen, bevor gespeichert wird
                Kundennummer = Me.MainApplication.Adressen.GetNextAddressNumber
                ContactDisplayID = CreateContactsID()
            End If



            If Me.ID = -1 Then
                ' Dann war es ein neues element 
                Me.CreatedAt = Date.Today

            End If

            ' das frühere "isdeleted"- Flag wird nicht mehr verwendet

            MyBase.Save()
            MainApplication.SendMessage(MainApplication.Languages.GetText("msgCommonelementSaved", "Gespeichert: '{0}'", Me.ToString))
        End Sub



        ''' <summary>
        ''' Ruft den Namen der Firma ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(255)> _
        <Tools.Importable()> _
        <ClausSoftware.Tools.DisplayName("Company", "Firma")> _
        <Persistent("Firma")> _
        Public Property Company() As String
            Get
                If m_company Is Nothing Then
                    Return ""
                End If

                Return m_company
            End Get
            Set(ByVal value As String)

                If value IsNot Nothing Then
                    If value.Length > m_mainApplication.Database.GetColumnCharacterLength(Adress.Tablename, "Firma") Then

                        value = value.Substring(0, CInt(m_mainApplication.Database.GetColumnCharacterLength(Adress.Tablename, "Firma")))
                    End If
                End If

                SetPropertyValue("Company", m_company, value)

            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, das der Datensatz als Gelöscht markiert ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("ist Gelöscht-Feld nicht mehr verweden!")> _
        <DisplayName("Gelöscht")> _
        <ComponentModel.Browsable(False)> _
        <Persistent("Deleted")> _
        Property IsDeletedSys() As Integer
            Get
                Return m_deletedsys
            End Get
            Set(ByVal value As Integer)

                SetPropertyValue(Of Integer)("IsDeletedSys", m_deletedsys, value)
            End Set
        End Property

        ''' <summary>
        ''' Obsolete. Das Feld wird nicht mehr verwendet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("ist Gelöscht-Feld nicht mehr verwenden!")> _
        <DisplayName("Gelöscht")> _
<ComponentModel.Browsable(False)> _
<Persistent("istGelöscht")> _
        Property IsDeletedInt() As Integer
            Get
                Return m_deletedint
            End Get
            Set(ByVal value As Integer)

                SetPropertyValue(Of Integer)("IsDeletedInt", m_deletedint, value)
            End Set
        End Property

        Private m_isCompany As Boolean

        ' ''Ruft eine Kennung ab, die angit ob dieser Kontakt eher eine Firma ist oder eine natürliche Person
        '<ClausSoftware.Tools.DisplayName("IsCompany", "Firma")> _
        '<Persistent("IsCompany")> _
        'Public Property IsCompany() As Boolean
        '    Get
        '        Return m_isCompany
        '    End Get
        '    Set(ByVal value As Boolean)

        '        SetPropertyValue(Of Boolean)("ContactsName", m_isCompany, value)
        '    End Set
        'End Property


        ''' <summary>
        ''' Ruft den vollständigen Namen des Kontaktes ab; es wird nicht nach vor-und Nachmanem unterschieden oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(100)> _
        <Tools.Importable()> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
      <ClausSoftware.Tools.DisplayName("FirstName", "Vorname")> _
      <Persistent("Vorname")> _
        Public Property FirstName() As String 'War mal "Vorname""" - und hatte den kompletten Kontakte-String enthalten
            Get
                If m_firstName Is Nothing Then
                    m_firstName = ""
                End If
                Return m_firstName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FirstName", m_firstName, value)
            End Set
        End Property

        <Size(100)> _
        <Tools.Importable()> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
<ClausSoftware.Tools.DisplayName("LastName", "Nachname")> _
<Persistent("Nachname")> _
        Public Property LastName() As String 'War mal "Vorname"""
            Get
                If m_lastName Is Nothing Then
                    m_lastName = String.Empty
                End If

                Return m_lastName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LastName", m_lastName, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Vor- und Namenamen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("ContactsName", "Name")> _
        Public ReadOnly Property ContactsName() As String
            Get
                Return m_firstName & " " & m_lastName
            End Get
        End Property

        ''' <summary>
        ''' Ruft die Strasse des Rechnungsempägers ab oder legt diese fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()> _
        <ClausSoftware.Tools.DisplayName("Street", "Strasse")> _
        <Persistent("Strasse")> _
        Public Property Street() As String
            Get
                If m_street Is Nothing Then
                    m_street = ""
                End If
                Return m_street
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Street", m_street, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Postleitazhl des Rechnungsempfängers ab oder legt diese fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()> _
<ClausSoftware.Tools.DisplayName("ZipCode", "PLZ")> _
 <Persistent("Postleitzahl")> _
        Public Property ZipCode() As String
            Get
                If m_Postleitzahl Is Nothing Then
                    m_Postleitzahl = ""
                End If

                Return m_Postleitzahl
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ZipCode", m_Postleitzahl, value)

            End Set
        End Property

        ''' <summary>
        ''' Ruft den Ort ab oder legt den fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()> _
        <ClausSoftware.Tools.DisplayName("Town", "Ort")> _
        <Persistent("Ort")> _
        Public Property Town() As String
            Get
                Return Me.m_Town
            End Get
            Set(ByVal value As String)

                If m_Town Is Nothing Then
                    m_Town = String.Empty
                End If

                SetPropertyValue(Of String)("Town", m_Town, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen kurztext ab, der das Gewerbe beschreibt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("KindOfBusiness", "Gewerbe")> _
        <Persistent("Gewerbe")> _
        Public Property KindOfBusiness() As String
            Get
                Return Me.m_KindOfBusiness
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("KindOfBusiness", m_KindOfBusiness, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Haupttelefonnummer ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()> _
        <ClausSoftware.Tools.DisplayName("Telephone1", "Telefon1")> _
        <Persistent("Telefonnummer")> _
        Public Property Telefon1() As String
            Get
                If m_phone1 Is Nothing Then m_phone1 = String.Empty
                Return m_phone1
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("Telefon1", m_phone1, value)
            End Set
        End Property

        ''' <summary>
        ''' Nich nicht belegt !
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <ClausSoftware.Tools.DisplayName("Telephone2", "Telefon2")> _
        <Persistent("Telefon2")> _
        Public Property Telefon2() As String
            Get
                If m_phone2 Is Nothing Then m_phone2 = String.Empty
                Return m_phone2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Telefon2", m_phone2, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Faxnummer ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()> _
        <ClausSoftware.Tools.DisplayName("Fax", "Fax")> _
        <Persistent("Faxnummer")> _
        Public Property Fax() As String
            Get

                If m_Fax Is Nothing Then m_Fax = String.Empty
                Return m_Fax

            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Fax", m_Fax, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Emailadresse ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.Importable()> _
<Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
  <ClausSoftware.Tools.DisplayName("EmailAddress", "e-Mail")> _
  <Persistent("EmailAdresse")> _
        Public Property EMail() As String
            Get

                If m_email Is Nothing Then m_email = String.Empty

                Return Me.m_email
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = String.Empty
                SetPropertyValue(Of String)("EMail", m_email, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen Rabatt ab, der diesem Kontakt bei Aufträgen überlicherweise gewährt wird.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("Discount", "Rabatt")> _
        <Persistent("Rabatt")> _
        Public Property Rabatt() As String
            Get
                Return Me.m_Rabatt
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Rabatt", m_Rabatt, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen längeren Text ab, der Beschreibungen zu diesem KOmntakt enthalten kann
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <Tools.Importable()> _
        <ClausSoftware.Tools.DisplayName("ContactsDescription", "Anmerkungen")> _
        <Persistent("Anmerkungen")> _
        Public Property Description() As String
            Get
                Return Me.m_description
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", m_description, value)
            End Set
        End Property



        ''' <summary>
        ''' Kürzel für Datanorm-Import
        ''' </summary>
        <ComponentModel.Browsable(False)> _
        <Persistent("DTNDatenersteller")> _
        Public Property Datanorm() As String
            Get
                Return Me.m_Datanorm
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("Datanorm", m_Datanorm, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen der Bank ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("BankName", "Name d. Bank")> _
        <ComponentModel.Browsable(False)> _
        <Persistent("Bankname")> _
        Public Property Bankname() As String
            Get
                Return Me.m_Bankname
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Bankname", m_Bankname, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Bankleitzahl ab oder legt diese fest. 
        ''' Eine Prüfung findet (noch) nicht statt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("BankIDNumber", "Bankleitzahl")> _
        <ComponentModel.Browsable(False)> _
        <Persistent("Bankleitzahl")> _
        Public Property Bankleitzahl() As String
            Get
                Return Me.m_Bankleitzahl
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("Bankleitzahl", m_Bankleitzahl, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die KOntonummer ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("BankAccountNumber", "KontoNr.")> _
        <ComponentModel.Browsable(False)> _
        <Persistent("Kontonummer")> _
        Public Property BankKontonummer() As String
            Get
                Return Me.m_Kontonummer
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BankKontonummer", m_Kontonummer, value)
            End Set
        End Property


        ''' <summary>
        ''' Ist wahr, wenn diese Adresse aktiv ist, sonst False. 
        ''' Inaktive Adressen werden in Anzeigen entsprechend markiert oder ganz ausgeblendet.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Ist eine sinnvolle Alternative zum löschen </remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("IsActive", "Aktiv")> _
        <Persistent("IsActive")> _
        Public Property IsActive() As Boolean Implements IHasActiveProperty.IsActive
            Get
                Return m_isActive
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsActive", m_isActive, value)
            End Set
        End Property


        <ComponentModel.Browsable(False)> _
        <Persistent("istkunde")> _
        Public Property IstKunde() As Boolean
            Get
                Return Me.m_IstKunde
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IstKunde", m_IstKunde, value)
            End Set
        End Property

        <ComponentModel.Browsable(False)> _
        <Persistent("istlieferant")> _
        Public Property IstLieferant() As Boolean
            Get
                Return Me.m_IstLieferant
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IstLieferant", m_IstLieferant, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt das Datum an, an dem der Eintrag angelegt wurde.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>        
        <Obsolete("Benutze nun die CreatedAt - Eigenschaft")> _
        <DisplayName("Datum")> _
        <Persistent("datum")> _
        Public Property Datum() As String
            Get
                Return Me.m_dateField
            End Get
            Set(ByVal value As String)

                If value IsNot Nothing AndAlso Not value.Length = 0 Then
                    ' Datum kommt hier noch im Deutschen format an
                    Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
                    Dim myDate As Date
                    Date.TryParseExact(value, "dd.mm.yyyy", provider, Globalization.DateTimeStyles.None, myDate)
                    value = myDate.ToString("d")
                Else
                    m_dateField = value
                End If

                SetPropertyValue(Of String)("Datum", m_dateField, value)

            End Set
        End Property

        <Obsolete("Benutze nun die ChangedAt - Eigenschaft")> _
        <DisplayName("Letze Änderung")> _
        <Persistent("LetzteAenderung")> _
        Public Property LastChanged() As String
            Get
                Return m_LetzeÄnderung
            End Get
            Set(ByVal value As String)
                Dim dateVal As Date

                If value IsNot Nothing AndAlso Not value.Length = 0 Then

                    If Date.TryParse(value, dateVal) Then
                        m_LetzeÄnderung = CDate(value).ToString("d")
                    Else
                        m_LetzeÄnderung = CStr(Date.Today)
                    End If


                Else
                    m_LetzeÄnderung = value
                End If


                SetPropertyValue(Of String)("LastChanged", m_LetzeÄnderung, value)

            End Set
        End Property


        ''' <summary>
        ''' Ruft den Namen des Landes des angegebenen Adresse ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("Country", "Land")> _
        <Persistent("land")> _
        Public Property Country() As String
            Get
                If m_country Is Nothing Then
                    m_country = ""
                End If
                Return m_country
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Country", m_country, value)
            End Set
        End Property

        ''' <summary>
        ''' Enthält eine kurze Notiz des Kontaktes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Vorsicht - die Datenbankspalte ist noch alt!</remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.Importable()> _
<ClausSoftware.Tools.DisplayName("ProductRange", "Lieferprogramm")> _
<Persistent("Lieferprogramm")> _
        Public Property Notes() As String
            Get
                Return m_notes
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Notes", m_notes, value)
            End Set
        End Property

        ''' <summary>
        ''' Markiert einen Datensatz der Nadchrichten / Post (werbemails) erhalten soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("CanReceiveMailings", "Postempfänger")> _
        <Persistent("Postempfänger")> _
        Public Property CanReceiveMailings() As Boolean
            Get
                Return Me.m_Postempfänger
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("CanReceiveMailings", m_Postempfänger, value)
            End Set
        End Property

        Private m_UniqueMACID As String = String.Empty


        ' Für einen späteren Abgleich mit dem MAC die Unique ID angeben
        <Size(100)> _
        <Persistent("MACUniqueID")> _
        Public Property UniqueMACID() As String
            Get
                Return m_UniqueMACID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UniqueMACID", m_UniqueMACID, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft einen eindeutig gültigen Adressschlüssel ab oder legt diesen fest. 
        ''' Kann als ebay-ID verwendet werden. Muss eindeutig sein. Kann nothing sein.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("AddressCustomID", "Kennung")>
        <Persistent("Schlüssel")>
        Public Property EbayID() As String
            Get

                Return Me.m_eBayID
            End Get
            Set(ByVal value As String)

                If value IsNot Nothing Then
                    If value.Trim.Length = 0 Then
                        value = Nothing
                    End If
                End If
                SetPropertyValue(Of String)("ebayID", m_eBayID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ist wahr, wenn der Anwender das Standard-Adressfenster geändert hat.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("UserChangedAdressFenster")> _
        Public Property UserChangedAddressWindow() As Boolean
            Get
                Return m_UserChangedAdressFenster
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("UserChangedAddressWindow", m_UserChangedAdressFenster, value)
            End Set
        End Property

        ''' <summary>
        ''' Enthält das Adressfenster dieses Kontaktes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <ClausSoftware.Tools.DisplayName("AddressWindow", "Adressfenster")> _
        <Persistent("AdressFenster")> _
        Public Property InvoiceAdressWindow() As String
            Get
                If m_invoiceAdress.Trim.Length = 0 Then
                    ResetInvoiceAdressbox()
                    Return m_invoiceAdress.Trim
                Else
                    Return m_invoiceAdress.Trim
                End If

            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    value = ""
                End If
                SetPropertyValue(Of String)("InvoiceAdressWindow", m_invoiceAdress, value)

            End Set
        End Property

        ''' <summary>
        ''' Ruft die eindeutige Kundennummer ab oder legt diese fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Im Addressbuch wird das Feld "Nummer" zur Erzeugung der AdressID's genutzt und nicht die ID selber.
        ''' Ist Schade, aber historisch bedingt.</remarks>
        <DisplayName("Nummer")> _
        <Persistent("Nummer")> _
        Public Property Kundennummer() As Integer
            Get
                Return Me.m_Kundennummer
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Kundennummer", m_Kundennummer, value)
            End Set
        End Property

        ''' <summary>
        ''' Ist wahr, wenn dieser Eintrag im Ausruck erscheinen soll.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Beim Ausdrucken von Adresslisten kann durch diese Markierung das Drucken dieser Adresse unterdrückt werden.</remarks>
        <ClausSoftware.Tools.DisplayName("EntryPrintable", "Im Ausdruck vorhanden")> _
        <ComponentModel.Browsable(False)> _
        <Persistent("wirdgedruckt")> _
        Public Property PrintEntry() As Boolean
            Get
                Return m_wirdgedruckt
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("PrindEntry", m_wirdgedruckt, value)
            End Set
        End Property

        ''' <summary>
        ''' Erstellt ein neues Brieffenster mit Name, Strasse und Ort der Adresse
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ResetInvoiceAdressbox()
            Dim AdressText As String = ""

            If Company.Length > 0 Then
                AdressText = Me.Company & vbCrLf
            End If

            If Me.ContactsName.Length > 0 Then
                AdressText = AdressText & Me.ContactsName & vbCrLf
            End If

            If Me.Street.Length > 0 Then
                AdressText = AdressText & Me.Street & vbCrLf
            End If

            AdressText = AdressText & Me.ZipCode & " " & Me.Town

            If Not My.Application.Culture.DisplayName.Contains(Me.Country) Then
                AdressText = AdressText & vbCrLf & Me.Country
            End If

            Me.InvoiceAdressWindow = AdressText.Trim
            Me.UserChangedAddressWindow = False
        End Sub

#End Region

        ''' <summary>
        ''' Prüft auf Abhängigkeitn zu anderen Elemeten ; dann darf die Adresse nicht gelöscht werden
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function HasUnresolvedContraints() As Boolean
            ' Prüfe nach Artikel
            ' Rechnungen (sehr wichtig) 
            ' Forderungen (recht wichtig) 
            'Mahnungen
            ' Briefe

            Dim modulName As String = "Adddress ContraintsCheck"

            Dim criteria As New DevExpress.Data.Filtering.BinaryOperator("AddressNumber", Me.ID)

            Using Items As New JournalDocuments(MainApplication, criteria)
                'contraints.AddRange(CType(Items.ToArray, Global.System.Collections.Generic.IEnumerable(Of Global.ClausSoftware.Data.StaticItem)))
                If Items.Count > 0 Then
                    MainApplication.log.WriteLog(modulName, "Contains Journaldata")
                    Return True
                End If
            End Using

            ' Forderungen direkt in der DB prüfen.. 
            Dim Sql As String = "SELECT count(*) FROM Vorgänge WHERE adresse=" & Me.ID
            Dim result As Integer
            result = CInt(MainApplication.Database.ExcecuteScalar(Sql))

            If result > 0 Then
                MainApplication.log.WriteLog(modulName, "Contains Transactions")
                Return True
            End If


            Return False ' Keine Abhängigkeiten gefunden
        End Function

        ''' <summary>
        ''' Aktualisiert die DisplayID dieses Datensatzes
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RefreshDisplayID()
            Me.ContactDisplayID = CreateContactsID(Me)
        End Sub

        ''' <summary>
        ''' Ruft eine neue formatierte Kontakt-ID ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CreateContactsID(ByVal adress As Adress) As String
            Dim idValue As String

            Dim dateValue As Date = adress.CreatedAt

            ' Nach Update kann das kaputt sein
            If dateValue = Date.MinValue Then
                Date.TryParse(adress.Datum, dateValue)

                If dateValue = Date.MinValue Then
                    ' schlecht... 
                    dateValue = Today ' Letzte chance
                Else
                    adress.CreatedAt = dateValue
                End If

            End If


            idValue = MainApplication.Tools.CreateAdressDisplayID(adress.Kundennummer, dateValue)

            Return idValue

        End Function

        Private Function CreateContactsID() As String
            Return CreateContactsID(Me)
        End Function

        ''' <summary>
        ''' Ruft eine Auflistung von Anrufen ab, die diesem Kontakt zugeordnet werden können
        ''' </summary>
        ''' <returns>Eine Auflistung von Anrufen, die diesem Kontakt zugeordnet weden konnte</returns>
        ''' <remarks></remarks>
        Function PhoneCallList() As PhoneCalls

            If m_PhoneCalls Is Nothing Then
                m_PhoneCalls = New PhoneCalls(Me.MainApplication)
                m_PhoneCalls.Criteria = New DevExpress.Data.Filtering.BinaryOperator("AddressID", Me.Key)
            End If
            Return m_PhoneCalls
        End Function

        ''' <summary>
        ''' Erstellt eine unabhängige Kopie der Adresse mit neuer AdressenNummer und aktuellem Anlegedatum
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function Clone() As Object
            Dim newAdess As Adress
            newAdess = CType(MyBase.Clone(), Adress)
            ' Für clone neue Adressnummer und Anlegedatum vergeben
            newAdess.Kundennummer = Me.MainApplication.Adressen.GetNextAddressNumber
            newAdess.ContactDisplayID = CreateContactsID(newAdess)

            Return newAdess
        End Function

        ''' <summary>
        ''' Ruft einen Anzeigetext der Adresse ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Dim AdressText As String
            AdressText = String.Concat(Me.ContactDisplayID & ", " & Me.Company, ", ", Me.ContactsName & ", " & Me.ZipCode & " " & Me.Town)
            AdressText = AdressText.Trim(New Char() {","c, " "c})
            Return AdressText
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace
