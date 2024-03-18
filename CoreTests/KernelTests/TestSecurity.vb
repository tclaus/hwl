Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Kernel

<Category("Rechteverwaltung")> _
<TestFixture()> _
Public Class testSecurity


    <Test(description:="Benutzer. Rechteprüfung")> _
    Public Sub TestUsers()
        Assert.NotNull(MainApplication.getInstance.Users, "Benutzerliste war null")


        Assert.NotNull(MainApplication.getInstance.CurrentUser.ToString, "aktueller benutzer sollte auf jden Fall einen wert ausgeben (Rechnername)")

        Debug.Print("CurrentUser(text) = " & MainApplication.getInstance.CurrentUser.ToString)

        Assert.IsNotEmpty(Security.Users.MachineUserName, "einen Maschinen benutzername sollte vergeben worden sein")
        Debug.Print("MaschineUsername = " & Security.Users.MachineUserName)

        'TODO: Rechte prüfungen durchführen

        ' Aktueller Benutzer hat alle Rechte
        For Each secItem As Security.PermissionModules In [Enum].GetValues(GetType(Security.PermissionModules))
            Assert.IsTrue(MainApplication.getInstance.CurrentUser.AllowDelete(secItem), " Löschen Recht sollte gewährt sein für (" & secItem & ")")
            Assert.IsTrue(MainApplication.getInstance.CurrentUser.AllowRead(secItem), " Lesen Recht sollte gewährt sein für (" & secItem & ")")
            Assert.IsTrue(MainApplication.getInstance.CurrentUser.AllowWrite(secItem), " Schreib Recht sollte gewährt sein für (" & secItem & ")")
        Next




    End Sub

    ''' <summary>
    ''' Erstellt und testst Benutzergruppen
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="Benutzergruppen")>
    Public Sub TestGroups()

        Dim UserGroups As Kernel.Security.UserGroups = New Security.UserGroups(MainApplication.getInstance)


        Assert.NotNull(UserGroups, "Benutzergruppe war null")

        Assert.IsTrue(UserGroups.Count >= 0, "Anzahl der Gruppen konnte nicht gelesen werden")

        Dim newGroup As security.UserGroup = UserGroups.GetNewItem

        Assert.NotNull(newGroup, "Neue Gruppe konnte nicht erstellt werden (Object war nothing)")

    End Sub

End Class
