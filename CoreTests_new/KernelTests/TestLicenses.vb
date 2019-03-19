Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Kernel

Imports DevExpress.Xpo


<TestFixture(Description:="Lizenzen Test")> _
Public Class TestLicenses

    Private m_licenses As Data.Licenses

    <TestFixtureSetUp()> _
    Public Sub GetLicenses()
        m_licenses = m_Application.Licenses

    End Sub

    <Test()> _
    Public Sub TestdefaultLicenses()
        Debug.Print("Angebote/Rechnungen: " & m_licenses.IsActivBusinessActs.ToString)
        Debug.Print("Kassenbuch  : " & m_licenses.IsActivCashJournal.ToString)
        Debug.Print("Benutzerverw.: " & m_licenses.IsActiveUserSecurity.ToString)
        Debug.Print("Termine: " & m_licenses.IsActivScheduler.ToString)
        Debug.Print("Forderungen/Verbindlichkeiten: " & m_licenses.IsActivTransactions.ToString)



    End Sub

    <Description("Ruft die Restzeit (oder Überhang) der Basislizenz ab")> _
    <Test()> _
    Public Sub GetBaseBalance()
        Dim value As Integer
        value = m_licenses.GetBalanceLicenceTime()
        Debug.Print("restzeit der Basis-Lizenz: " & value & " Tage")

    End Sub

    <Test(description:="Ruft die Basislizenz ab")> _
    Public Sub GetBaseLicense()
        Dim item As Data.LicenseItem = m_licenses.GetBaseLicense

        Assert.IsNotNullOrEmpty(item.GUID, "GUID der Basislizenz war nicht gesetzt")


        Assert.IsNotNullOrEmpty(item.Name, "Name der Basislizenz war nicht gesetzt")
        Debug.Print("Basislizenz: ")
        Debug.Print("  GUID: " & item.GUID)
        Debug.Print("  Name: " & item.Name)
        Debug.Print("  Aktiv: " & item.IsActive.ToString)


    End Sub

    '<Test()> _
    'Public Sub GetAllLicenses()

    'End Sub

End Class
