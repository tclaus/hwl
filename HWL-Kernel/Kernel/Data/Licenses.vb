Imports ClausSoftware.Kernel
Imports System.ComponentModel

Namespace Data


    ''' <summary>
    ''' Enthält eine Auflistung zur Verfügung stehender Lizenzen
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Licenses

        ''' <summary>
        ''' Testzeitraum (60 Tage) 
        ''' </summary>
        ''' <remarks></remarks>
        Public Const TestPeried As Integer = 60

        Private Const LicenseKeyName As String = "LicenseKey"
        Private Const LicenseName As String = "LicenseName"



        Private Shared licenseGUIDHWL As String = "{FF946C06-6CEC-49fe-B628-66DD02FF1BD0}"
        Friend Shared m_licenseItemHWL As New ClausSoftware.Data.LicenseItem("Basis-HWL", licenseGUIDHWL)

        ' Power - Büro (Basis)
        Private Shared licenseGUIDPB As String = "{C8532D14-7013-499d-BEA1-2C09D3616961}"
        Friend Shared m_licenseItemPB As New ClausSoftware.Data.LicenseItem("Basis-PowerBüro", licenseGUIDPB)

        ''' <summary>
        ''' Eindeutiger Lizenzcode für "Formulardesigner"
        ''' </summary>
        ''' <remarks></remarks>
        Private licenseGUIDDesigner As String = "{A308C8C1-1B7E-4df0-8B7A-925B4C61D060}"
        Private m_licenseFormularDesigner As New ClausSoftware.Data.LicenseItem("Formulardesigner", licenseGUIDDesigner)

        'Briefe
        Private licenseGUIDLetter As String = "{7DB2AA74-DCBE-46e4-81A2-0B5603B5A8F8}"
        Private m_licenseItemLetter As New ClausSoftware.Data.LicenseItem("Briefe", licenseGUIDLetter)


        Private licenseGUIDWorkItems As String = "{B127ECE9-1452-48da-B160-9348DF568B50}"
        Private m_licenseItemWorkItems As New LicenseItem("Tätigkeiten", licenseGUIDWorkItems)

        Private licenseGUIDBusinessActs As String = "{96097D81-CE85-4c48-9F01-C7AAA4567875}"
        Private m_licenseItemBusinessActs As New LicenseItem("Angebote / Rechnungen", licenseGUIDBusinessActs)

        Private licenseGUIDTransactions As String = "{E26A2BB4-1042-45a0-86DB-A1EACBD6BC2C}"
        Private m_licenseItemTransactions As New LicenseItem("Forderungen/Verbindlichkeiten", licenseGUIDTransactions)

        Private licenseGUICashJournal As String = "{BDB0BD4D-677E-4d16-A4AB-E4ACBDBC9A29}"
        Private m_licenseItemCashJournal As New LicenseItem("Kassenbuch", licenseGUICashJournal)
        '
        Private licenseGUIDUserSecurity As String = "{416562D8-CFD0-4db4-88E9-885885C5FB8E}"
        ''' <summary>
        ''' Enthält das Lizenzobjekt für Benutzerverwaltungen
        ''' </summary>
        ''' <remarks></remarks>
        Private m_licenseUserSecurity As New LicenseItem("Benutzerverwaltung", licenseGUICashJournal) 'TODO: NLS

        'Terminplaner
        Private m_licenseGUIDScheduler As String = "{38AF8D77-853C-49e5-A3B2-75E835B37AD7}"
        Private m_licenseItemScheduler As New ClausSoftware.Data.LicenseItem("Terminplaner", m_licenseGUIDScheduler)


        ' ''' <summary>
        ' ''' Zeigt an, ob die angegebene Lizenz (Tätigkeiten) aktiv ist
        ' ''' </summary>
        ' ''' <value></value>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public ReadOnly Property isActivWorkItems() As Boolean
        '    Get
        '        Return IsActive(m_licenseItemWorkItems)
        '    End Get
        'End Property

        ''' <summary>
        ''' Löscht die angegebene Lizenz vollständig aus den Einstellungen
        ''' </summary>
        ''' <param name="License"></param>
        ''' <remarks></remarks>
        Public Sub Delete(ByVal license As LicenseItem)

            MainApplication.getInstance.Settings.DeleteSetting(license.GUID, LicenseKeyName, "SYSTEM")
            MainApplication.getInstance.Settings.DeleteSetting(license.Name, LicenseName, "SYSTEM")


        End Sub

        ''' <summary>
        ''' Zeigt an, ob die angegebene Lizenz (Briefe) aktiv ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsActiveLetters() As Boolean
            Get
                Return IsActive(m_licenseItemLetter)
            End Get
        End Property

        ''' <summary>
        ''' Zeigt an, ob die angegebene Lizenz (Angebote / Rechnungen) aktiv ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsActivBusinessActs() As Boolean
            Get
                Return IsActive(m_licenseItemBusinessActs)
            End Get
        End Property

        ''' <summary>
        ''' Zeigt an, ob eine Benutzerverwaltng aktiv ist. Damit können Benutzer rechte zugewiesen werden, sowie eine Athentifizierung beim Start.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsActiveUserSecurity() As Boolean
            Get
                Return IsActive(m_licenseUserSecurity)
            End Get
        End Property

        ''' <summary>
        ''' Zeigt an, ob die angegebene Lizenz (Forderungen / Verbindlichkeiten) aktiv ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsActivTransactions() As Boolean
            Get
                Return IsActive(m_licenseItemTransactions)
            End Get
        End Property

        ''' <summary>
        ''' Ist wahr, wenn eine gültige Designer-Lizenz vorhanden ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsActivDesigner As Boolean
            Get
                Return IsActive(m_licenseFormularDesigner)
            End Get
        End Property

        ''' <summary>
        ''' Ist wahr, wenn eine gültige TerminkalenderLizenz vorhanden ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsActivScheduler As Boolean
            Get
                Return IsActive(m_licenseItemScheduler)
            End Get
        End Property

        ''' <summary>
        ''' Zeigt an, ob die angegebene Lizenz (Kassenbuch) aktiv ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsActivCashJournal() As Boolean
            Get
                Return IsActive(m_licenseItemCashJournal)
            End Get
        End Property


        ''' <summary>
        ''' Stellt eine Auflistung aller aktuell registrierten Lizenzen bereit
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property LizensesData() As SortedList(Of String, LicenseItem)
            Get

                Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator("Area", LicenseName, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
                Dim licensesettings As New ClausSoftware.Kernel.Settings(MainApplication.getInstance, criteria)

                Dim licensesList As New SortedList(Of String, LicenseItem)

                ' Baue eine Liste mit Lizenzen auf
                For Each licenseSetting As Setting In licensesettings
                    Dim LiceseItem As New LicenseItem(licenseSetting.Name,
                                                      licenseSetting.Value,
                                                      IsActive(GetLicenseItemFromSetting(licenseSetting)))


                    licensesList.Add(licenseSetting.Name, LiceseItem)
                Next

                Return licensesList
            End Get
        End Property

        ''' <summary>
        ''' Ruft ein Lizenzobjekt aus einer Lizenzeinstellung ab
        ''' </summary>
        ''' <param name="licenseSetting"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetLicenseItemFromSetting(ByVal licenseSetting As Setting) As LicenseItem

            Return New LicenseItem(licenseSetting.Name, licenseSetting.Value, TestLicense(licenseSetting.Value, ""))

        End Function

        ''' <summary>
        ''' Prüft, ob die Basis-Lizenz für das Hauptprogramm abgelaufen ist
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsBaseActive() As Boolean
            If MainApplication.ApplicationName.Contains("HWL") Then
                Return IsActive(m_licenseItemHWL)
            Else
                Return IsActive(m_licenseItemPB)
            End If
        End Function

        ''' <summary>
        ''' Ruft die jeweilige Basislizenz ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBaseLicense() As LicenseItem
            If MainApplication.ApplicationName.Contains("HWL") Then
                Return m_licenseItemHWL
            Else
                Return m_licenseItemPB
            End If
        End Function

        ''' <summary>
        ''' Prüft ob für den angegebenen Code eine Lizenz zur Verfügung steht.
        ''' Vergleicht hinterlegten Lizenz-Schlüssel mit dem aktuellen Programm-Schlüssel
        ''' </summary>
        ''' <param name="license"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsActive(ByVal license As LicenseItem) As Boolean
            '  geht in Settings und holt da einen Wert raus
            Dim value As String = MainApplication.getInstance.Settings.GetSetting(license.GUID, LicenseKeyName, "", "SYSTEM")

            If String.IsNullOrEmpty(value) Or value.Length = 0 Then ' dann mal wenigstends prüfen, ob nicht vielleicht eine Zeitliche Lizenz besteht
                ' existierte nicht
                ' => Anlegen!
                value = MainApplication.getInstance.Settings.GetSetting(license.Name, LicenseName, license.GUID, "SYSTEM")
                If value.Length = 0 Then
                    RegisterLicense(license)

                End If

                'TC: am 23.01.2013
                'important: LIZENZPRÜFUNG: Wieder einschalten!
                Return True
                'Return TestLicense(license)
            Else

                'important: LIZENZPRÜFUNG: Wieder einschalten!
                Return True
                'Return TestLicense(license)
            End If
        End Function

        ''' <summary>
        ''' Vergleicht eine Lizenz mit dem hinterlegten Freischaltschlüsssel
        ''' </summary>
        ''' <returns>TRUE, wenn das eine  gültige Lizenz war, sonst FALSE</returns>
        ''' <remarks>Vergleicht den Lizenzschlüssel mit der aktuellen ProgrammID und dem Lizenzschlüssel</remarks>
        Private Function TestLicense(ByVal license As LicenseItem) As Boolean

            Dim licenseKey As String = MainApplication.getInstance.Settings.GetSetting(license.GUID, LicenseKeyName, "", "SYSTEM")
            Return TestLicense(license, licenseKey)

        End Function


        ''' <summary>
        ''' Überladen. Testet eine Lizenz-GUID mit einen angegebenen Schlüssel auf gültigkeit
        ''' </summary>
        ''' <param name="licenseGUID"></param>
        ''' <param name="testcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function TestLicense(ByVal licenseGUID As String, ByVal testcode As String) As Boolean

            Dim hwlID As String = MainApplication.getInstance.ApplicationID

            Dim retVal As Boolean
            Try


                If testcode.Length > 0 And hwlID.Length > 0 Then
                    Return BaseCodeCheck(licenseGUID, testcode)

                Else
                    retVal = False
                End If

                Dim installdate As Date
                Try
                    installdate = GetInstallDate(licenseGUID)
                Catch
                    installdate = Today
                    SetInstallDate(licenseGUID)
                End Try

                ' Nun alles freigeben,was innerhalb des Testzeitraumes frei war
                Dim daysLeft As Integer = GetBalanceLicenceTime(licenseGUID)

                If daysLeft >= 0 Then
                    Debug.Print("Lizenz war gültig (innerhalb Testzeitraum), Rest=" & daysLeft)
                    retVal = True
                Else
                    Debug.Print("Lizenz war ungültig (Testzeitraum abgelaufen), Rest=" & daysLeft)
                    retVal = False
                End If

            Catch ex As Exception
                Trace.TraceError(ex.Message)

            End Try
            Return retVal

        End Function

        ''' <summary>
        ''' Ruft die Restzeit der Testphase nach der Erstinstallation in Tagen ab.        
        ''' </summary>
        ''' <returns>Positive Zahlen kennzeichneen die Resttage des Testzeitraumes, negative Werte kennzeichnen eine überfälligkeit</returns>
        ''' <remarks></remarks>
        Public Function GetBalanceLicenceTime(ByVal licenseCode As String) As Integer
            Dim installdate As Date = GetInstallDate(licenseCode)
            ' 60 Tage testzeitraum

            Dim rest As TimeSpan = Today.Subtract(installdate)
            Return TestPeried - rest.Days

        End Function

        ''' <summary>
        ''' Ruft die Restzeit für die jeweilige Basislizenz ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBalanceLicenceTime() As Integer
            If MainApplication.ApplicationName.Contains("HWL") Then
                Return GetBalanceLicenceTime(m_licenseItemHWL.GUID)
            Else
                Return GetBalanceLicenceTime(m_licenseItemPB.GUID)

            End If
        End Function

        ''' <summary>
        ''' Ruft das Installationsdatum ab. 
        ''' Falls das Datum nicht gefunden werden konnte, so wird es auf "heute" festgelegt.
        ''' </summary>
        Public Function GetInstallDate(ByVal licenseCode As LicenseItem) As Date
            Return GetInstallDate(licenseCode.GUID)
        End Function

        ''' <summary>
        ''' Ruft das Installationsdatum ab. 
        ''' Falls das Datum nicht gefunden werden konnte, so wird es auf "heute" festgelegt.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetInstallDate(ByVal licenseCode As String) As Date
            Dim DateValue As String = MainApplication.getInstance.Settings.GetSetting("Installdate_" & licenseCode, Tools.RegistrySections.CurrentVersion, Today.ToShortDateString, "")
            Dim resDate As Date
            If Date.TryParse(DateValue, resDate) Then
                Return resDate
            Else
                ' Nicht aufzulösen.  Möglicherweise durch falsche Ländereinstellungen defekt. Neu setzen und sichern

                MainApplication.getInstance.Settings.SetSetting("Installdate_" & licenseCode, Tools.RegistrySections.CurrentVersion, Today.ToShortDateString, "")
                Return Today
            End If

        End Function

        ''' <summary>
        ''' Setzt das Lizenzdatum auf das aktuelle Datum
        ''' </summary>
        ''' <param name="licenseCode"></param>
        ''' <remarks></remarks>
        Public Sub SetInstallDate(ByVal licenseCode As LicenseItem)
            SetInstallDate(licenseCode.GUID)
        End Sub

        ''' <summary>
        ''' Setzt das Installationsdatum eines Codes auf das aktuelle datum
        ''' </summary>
        ''' <param name="licenseCode"></param>
        ''' <remarks></remarks>
        Public Sub SetInstallDate(ByVal licenseCode As String)
            MainApplication.getInstance.Settings.SetSetting("Installdate_" & licenseCode, Tools.RegistrySections.CurrentVersion, Today.ToShortDateString, "")
        End Sub

        ''' <summary>
        ''' Überladen. Testet eine Lizenz gegen einen angegebenen Schlüsssel und der aktuellen ProgrammID
        ''' </summary>
        ''' <param name="license">Die zu testende Lizenz</param>
        ''' <param name="testcode">Der Freischaltschlüssel</param>
        ''' <returns>TRUE, wenn Code gültig, sinst FALSE </returns>
        ''' <remarks></remarks>
        Public Function TestLicense(ByVal license As LicenseItem, ByVal testcode As String) As Boolean
            Return TestLicense(license.GUID, testcode)
        End Function

        ''' <summary>
        ''' Setzt für eine gegebene Lizenz den Schlüssel und schaltet die somit frei
        ''' </summary>
        ''' <param name="license">Die Lizenz, fr die der Code gespeichert werden soll</param>
        ''' <param name="code">Der Lizenz-Freischaltcode</param>
        ''' <returns>TRUE, wenn Lizenz aktiviert werden konnte, ssonst FALSE, falls der Code nicht gültig ist</returns>
        ''' <remarks></remarks>
        Public Function SetLicenseKey(ByVal license As LicenseItem, ByVal code As String) As Boolean


            If TestLicense(license, code) Then
                ' dann den Schlüssel auch abspeichern
                MainApplication.getInstance.Settings.SetSetting(license.GUID, LicenseKeyName, code, "SYSTEM")
                Return True
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' Ruft den Schlüssel einer Lizenz ab, sofern vorhanden
        ''' </summary>
        ''' <param name="license"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLicenseKey(ByVal license As LicenseItem) As String
            Return MainApplication.getInstance.Settings.GetSetting(license.GUID, LicenseKeyName, "", "SYSTEM")
        End Function


        ''' <summary>
        ''' Registriert die angegebene Lizenz in einem globalen Lizenz-Speicher. damit kann im Lizenz-Generator eine Lizenz zu diesem Eintrag erzeuig werden. 
        ''' Nicht für den Programmablauf relevant
        ''' (Datenbank auf Claus-Software)
        ''' </summary>
        ''' <param name="license"></param>
        ''' <remarks></remarks>
        <Conditional("DEBUG")>
        Public Sub RegisterGlobalLicense(ByVal license As LicenseItem)
            Exit Sub

            ''IMPORTANT: Hier das Passwort entfernen
            'Dim cb As New MySql.Data.MySqlClient.MySqlConnection("Server=lin-sql.df-webhosting.de;Database=usr_web764_1;Uid=web764;Pwd=alterego")
            'Dim command As New MySql.Data.MySqlClient.MySqlCommand()

            '' 1. Lesen, dann schreiben 
            'cb.Open()
            'command.Connection = cb
            'command.CommandText = "Select count(*) from Lizenzen where Lizenzcode='" & license.GUID & "'"
            'Dim Value As Object = command.ExecuteScalar()

            'If Value IsNot Nothing Then
            '    ' dann muss es ein Int gewesen sein 
            '    If CInt(Value) > 0 Then
            '        ' gibt es schon !
            '    Else
            '        command.CommandText = "insert into Lizenzen (Lizenzcode,Lizenzname) values ('" & license.GUID & "','" & license.Name & "')"
            '        command.ExecuteNonQuery()
            '    End If
            'End If

            'cb.Close()

        End Sub
        ''' <summary>
        ''' Registriert einen Lizenz-Type in der lokalen Datenbank
        ''' </summary>
        ''' <param name="license"></param>
        ''' <remarks></remarks>
        Private Sub RegisterLicense(ByVal license As LicenseItem)
            ' in Settings diese Lizenz reinschreiben, falls noch nicht existiert
            MainApplication.getInstance.Settings.SetSetting(license.Name, LicenseName, license.GUID, "SYSTEM")
            ' MainApplication.getInstance.Settings.SetSetting(license.GUID, LicenseKeyName, "", "SYSTEM") ' den Lizenzschlüssel erstmal freilassen

        End Sub

        ''' <summary>
        ''' Registriert eigene Lizenzen in den globalen Lizenzspeicher
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub InitilizeLicenses()
            'RegisterGlobalLicense(m_licenseItemHWL)
            'RegisterGlobalLicense(m_licenseItemPB)
            'RegisterGlobalLicense(m_licenseItemBuisinessActs)
            'RegisterGlobalLicense(m_licenseItemCashJournal)
            'RegisterGlobalLicense(m_licenseItemTransactions)
            'RegisterGlobalLicense(m_licenseItemWorkItems)


            If MainApplication.ApplicationName.StartsWith("HWL") Then
                RegisterLicense(m_licenseItemHWL)
            Else
                RegisterLicense(m_licenseItemPB)

                RegisterLicense(m_licenseItemBusinessActs)
                RegisterLicense(m_licenseItemCashJournal)
                RegisterLicense(m_licenseItemTransactions)
                RegisterLicense(m_licenseItemWorkItems)
            End If



        End Sub

        ''' <summary>
        ''' Testet nur den Code auf korrektheit, berücksichtigt nicht die Zeit
        ''' </summary>
        Public Function BaseCodeCheck(ByVal license As LicenseItem) As Boolean
            Dim licenseKey As String = MainApplication.getInstance.Settings.GetSetting(license.GUID, LicenseKeyName, "", "SYSTEM")
            Return BaseCodeCheck(license.GUID, licenseKey)
        End Function

        ''' <summary>
        ''' Testet nur den Code auf korrektheit, berücksichtigt nicht die Zeit
        ''' </summary>
        ''' <param name="licenseGUID"></param>
        ''' <param name="testCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function BaseCodeCheck(ByVal licenseGUID As String, ByVal testCode As String) As Boolean
            ' Ist mit dem HWL-Code verwurschtelt
            ' aber wie?
            ' Name der Lizenz + HWL-Code = Lizenz
            Dim hwlID As String = MainApplication.getInstance.ApplicationID
            Dim licenceNumber As Integer
            Dim HWLCode As String
            Dim hnumber As Integer

            testCode = testCode.Trim
            Debug.Print("Teste Lizenz:" & licenseGUID)
            If testCode.StartsWith("Z") Then
                testCode = testCode.Substring(1)
            End If


            HWLCode = hwlID.Substring(hwlID.Length - 5)

            ' die letzten 5 Stellen

            ' Jeden Ascii-Wert eines Zeichen des Names des Moduls mit dem Asci-Wert der jeweiligen Stelle des HWL-Codes addieren.
            hnumber = 0
            licenceNumber = 0
            Dim charNumber As Integer = 1

            For Each Character As Char In licenseGUID
                licenceNumber += Asc(Character) * (charNumber * 2) + Asc(HWLCode(hnumber)) * (hnumber + 1)
                hnumber += 1
                If hnumber >= HWLCode.Length Then
                    hnumber = 0
                End If
                charNumber += 1
            Next



            If Hex(licenceNumber) = testCode Then

                ' Code war gültig und kann zurückgegeben werden
                Debug.Print("Lizenz war gültig (gültiger Code)")
                Return True
            Else
                ' Code war ungültig, nun kann noch innerhalb der Testphase ein TRue zurückgegeben werden
                Return False
            End If
        End Function

    End Class

    ''' <summary>
    ''' Stellt eine Lizenz da
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerDisplay("Lizenz:{Name}, Aktiv:{IsActive}, GUID:{GUID}")> _
    Public Class LicenseItem

        Private m_name As String
        Private m_gui As String
        Private m_isActive As Boolean

        ''' <summary>
        ''' Ruft den Namen der Lizenz ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Name() As String
            <DebuggerStepThrough()> _
            Get
                Return m_name
            End Get

        End Property

        ''' <summary>
        ''' Ruft den eindeutigen Schlüssel der Lizenz ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Browsable(False)> _
        ReadOnly Property GUID() As String
            <DebuggerStepThrough()> _
            Get
                Return m_gui
            End Get
        End Property

        ''' <summary>
        ''' Zeigt an, ob es sich um eien freigeschaltete Lizenz handelt, 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Aktiv")> _
Public ReadOnly Property IsActive() As Boolean
            Get
                Return m_isActive
            End Get

        End Property

        Sub New(ByVal name As String, ByVal guid As String, ByVal active As Boolean)
            m_name = name
            m_gui = guid
            m_isActive = active
        End Sub

        Sub New(ByVal name As String, ByVal guid As String)
            m_name = name
            m_gui = guid
            m_isActive = False
        End Sub

        ''' <summary>
        ''' Ruft den Namen der Lizenz ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.Name
        End Function

    End Class


End Namespace

