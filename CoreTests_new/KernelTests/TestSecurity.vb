Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Kernel
Imports DevExpress.Xpo

<Category("Rechteverwaltung")> _
<TestFixture()> _
Public Class testSecurity


    <Test(description:="Benutzer. Rechteprüfung")> _
    Public Sub TestUsers()
        Assert.NotNull(m_Application.Users, "Benutzerliste war null")


        Assert.NotNull(m_Application.CurrentUser.ToString, "aktueller benutzer sollte auf jden Fall einen wert ausgeben (Rechnername)")

        Debug.Print("CurrentUser(text) = " & m_Application.CurrentUser.ToString)

        Assert.IsNotNullOrEmpty(security.Users.MachineUserName, "einen Maschinen benutzername sollte vergeben worden sein")
        Debug.Print("MaschineUsername = " & security.Users.MachineUserName)

        'TODO: Rechte prüfungen durchführen

        ' Aktueller Benutzer hat alle Rechte
        For Each secItem As security.PermissionModules In [Enum].GetValues(GetType(security.PermissionModules))
            Assert.IsTrue(m_Application.CurrentUser.AllowDelete(secItem), " Löschen Recht sollte gewährt sein für (" & secItem & ")")
            Assert.IsTrue(m_Application.CurrentUser.AllowRead(secItem), " Lesen Recht sollte gewährt sein für (" & secItem & ")")
            Assert.IsTrue(m_Application.CurrentUser.AllowWrite(secItem), " Schreib Recht sollte gewährt sein für (" & secItem & ")")
        Next




    End Sub

    ''' <summary>
    ''' Erstellt und testst Benutzergruppen
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="Benutzergruppen")> _
    Public Sub TestGroups()

        Dim UserGroups As Kernel.security.UserGroups = New security.UserGroups(m_Application)


        Assert.NotNull(UserGroups, "Benutzergruppe war null")

        Assert.IsTrue(UserGroups.Count >= 0, "Anzahl der Gruppen konnte nicht gelesen werden")

        Dim newGroup As security.UserGroup = UserGroups.GetNewItem

        Assert.NotNull(newGroup, "Neue Gruppe konnte nicht erstellt werden (Object war nothing)")

    End Sub

End Class
