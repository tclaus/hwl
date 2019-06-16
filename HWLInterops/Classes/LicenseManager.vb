Imports ClausSoftware.Data
Imports ClausSoftware.GUI

''' <summary>
''' Stellt eine COM - Verfügbare Klasse bereit, die einfache Lizenzaufgaben übernimmt
''' </summary>
''' <remarks></remarks>
<ComClass(LicenseManager.ClassId, LicenseManager.InterfaceId, LicenseManager.EventsId)> _
Public Class LicenseManager

#Region "COM-GUIDs"
    ' Diese GUIDs stellen die COM-Identität für diese Klasse 
    ' und ihre COM-Schnittstellen bereit. Wenn Sie sie ändern, können vorhandene 
    ' Clients nicht mehr auf die Klasse zugreifen.
    Public Const ClassId As String = "a461427d-9dbf-42c5-b4cd-3b1d2a26ec7a"
    Public Const InterfaceId As String = "3150d7b9-330b-42be-88b3-8d7be7aa2cc7"
    Public Const EventsId As String = "57cde884-73d1-49c1-b25f-5e59db055fc2"
#End Region

    Private m_licenses As ClausSoftware.Data.Licenses


    ' Eine erstellbare COM-Klasse muss eine Public Sub New() 
    ' ohne Parameter aufweisen. Andernfalls wird die Klasse 
    ' nicht in der COM-Registrierung registriert und kann nicht 
    ' über CreateObject erstellt werden.
    Public Sub New()
        MyBase.New()
        modmain.InitializeApplication()

        m_licenses = MainApplication.getInstance.Licenses

    End Sub


    Enum Licenses
        Tätigkeiten
        AngeboteRechnungen
        ForderungenVerbindlichkeiten
        Kassenbuch
        Briefe
        Terminkalender


    End Enum

    ''' <summary>
    ''' Ruft einen Wert ab, der angibt, ob das Basismodul eine gültige Lizenz besitzt
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsBaseActive() As Boolean
        Return m_licenses.IsBaseActive
        ' gibt es keinen Code, dann muss die Zeitdauer nach Installation zählen

    End Function

    Public Sub ShowLicenceDialog()
        Dim frm As New frmLicenses
        frm.ShowDialog()

    End Sub



    ''' <summary>
    ''' Zeigt an, ob die Lizenz aktiv ist
    ''' </summary>
    ''' <param name="licensesenum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsActiveByID(ByVal licensesenum As Licenses) As Boolean
        Select Case licensesenum
            Case Licenses.AngeboteRechnungen : Return m_licenses.IsActivBusinessActs
            Case Licenses.ForderungenVerbindlichkeiten : Return m_licenses.IsActivTransactions
            Case Licenses.Kassenbuch : Return m_licenses.IsActivCashJournal

            Case Else
                Return True
        End Select
    End Function

    ''' <summary>
    ''' Ruft den Aktiv-Status einer Lizenz ab, diese ist inaktiv, wenn innerhalb des Installationsdatums +x Tage
    ''' diese nicht aktiviert wurde
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsActive(ByVal key As String) As Boolean
        Dim licenseItem As New LicenseItem("", key, False)

        Return MainApplication.getInstance.Licenses.IsActive(licenseItem)
    End Function

    ''' <summary>
    ''' Aktiviert eine Lizenz und gibt Rückmeldung, ob erfolgreich
    ''' </summary>
    ''' <param name="license">Lizenz, die zu aktivieren ist</param>
    ''' <param name="code"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function ActivateLicense(ByVal license As LicenseItem, ByVal code As String) As Boolean
        Return MainApplication.getInstance.Licenses.SetLicenseKey(license, code)
    End Function


    Public Function TestDaysLeft() As Integer
        Return MainApplication.getInstance.Licenses.GetBalanceLicenceTime
    End Function

End Class

