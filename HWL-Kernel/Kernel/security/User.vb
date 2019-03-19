Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Imports DevExpress


Namespace Kernel.Security

    ''' <summary>
    ''' Stellt eien Klasse dar, die Benutzer ihre Eigenschaften und Zugriffsrechte enthält
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("Users")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class User
        Inherits StaticItem
        Implements IDataItem

        Private m_name As String

        Private m_foreName As String

        Private m_surename As String
        Shared cryptedkey As String = "ljchjweiocheowicnwehncwchweihceiowh"
        Private m_password As String


        'Private m_culturestring As String

        '''' <summary>
        '''' Ruft den 2-Stelligen string ab, der die Kultur kennzeichnet
        '''' </summary>
        '''' <value>Standard ist die Kultur, die am Rechner eingestellt ist: DE-DE</value>
        '''' <returns></returns>
        '''' <remarks></remarks>
        '<Size(10)> _
        '<Persistent("CultureString")> _
        'Public Property Culturestring() As String
        '    Get
        '        Return m_culturestring
        '    End Get
        '    Set(ByVal value As String)
        '        m_culturestring = value
        '    End Set
        'End Property

        ''' <summary>
        ''' Ruft einen Wert ab, der angibt, ob das angegebene Modul gelesen werden kann 
        ''' </summary>
        ''' <param name="modulname"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AllowRead(ByVal modulname As PermissionModules) As Boolean

            'Ohne Benutzeerverwaltung den lokalen Benutzer volle reche geben. 
            ' Mit Benutzerverwaltung kann sich ein lokaler Benutzer nicht anmelden!
            If Me.Key.Equals(Users.MachineUserName) Then Return True

            Dim rightsList As Dictionary(Of PermissionModules, PermissionsRights) = MainApplication.UserRights.Getrights(Me.Key)

            If rightsList.ContainsKey(modulname) Then
                Return (rightsList(modulname) = PermissionsRights.Read)
            End If

            Return False
        End Function

        ''' <summary>
        ''' Liefert True, wenn der aktuelle Benutzer das Recht hat, im angegebenen Modul Schreibvorgänge auszuführen
        ''' </summary>
        ''' <param name="modulname"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AllowWrite(ByVal modulname As PermissionModules) As Boolean

            'Ohne Benutzeerverwaltung den lokalen Benutzer volle reche geben. 
            ' Mit Benutzerverwaltung kann sich ein lokaler Benutzer nicht anmelden!
            If Me.Key.Equals(Users.MachineUserName) Then Return True

            Dim rightsList As Dictionary(Of PermissionModules, PermissionsRights) = MainApplication.UserRights.Getrights(Me.Key)

            If rightsList.ContainsKey(modulname) Then
                Return (rightsList(modulname) = PermissionsRights.Write)
            End If

            Return False

        End Function

        ''' <summary>
        ''' Liefert True, wenn der aktuelle Benutzer das Recht hat, im angegebenen Modul Löschvorgänge auszuführen
        ''' </summary>
        ''' <param name="modulname"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AllowDelete(ByVal modulname As PermissionModules) As Boolean
            'Ohne Benutzeerverwaltung den lokalen Benutzer volle reche geben. 
            ' Mit Benutzerverwaltung kann sich ein lokaler Benutzer nicht anmelden!
            If Me.Key.Equals(Users.MachineUserName) Then Return True


            Return AllowWrite(modulname)

        End Function



        ''' <summary>
        ''' Ruft das (crypted) Password ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Password")> _
        Private Property Password() As String
            Get
                Return m_password
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Password", m_password, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft die Liste der Berechtigungben ab, die´diesem User 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRights() As UserRights
            Dim rights As UserRights
            Dim criteria As New DevExpress.Data.Filtering.BinaryOperator("Name", Me.Name, DevExpress.Data.Filtering.BinaryOperatorType.Equal)

            rights = New UserRights(MainApplication, criteria)

            ' Hmm... Alle rechte einfügen, die nicht existieren ? 
            ' = > Nö, Ist ein recht nicht da, gibt es das auch nicht 
            Return rights


        End Function

        ''' <summary>
        ''' Setzt das neue Passwort für den Benutzer
        ''' </summary>
        ''' <param name="newPassword"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetPassword(ByVal newPassword As String, ByVal oldPassword As String) As Boolean
            If CheckPassword(oldPassword) Then
                ' Neues PW setzten
                'geheimer schlüssel 
                Dim newPaswdBytes() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(newPassword)

                Dim c As New System.Security.Cryptography.HMACSHA256(System.Text.ASCIIEncoding.ASCII.GetBytes(cryptedkey))
                Dim hashBytes() As Byte = c.ComputeHash(newPaswdBytes)

                Me.Password = Convert.ToBase64String(hashBytes)
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Prüft den übergebenen Klartext gegen das gespeicherte crypted Password
        ''' </summary>
        ''' <param name="password">Password als Klartext</param>
        ''' <returns>True, wenn übereinstimmend, sonst False</returns>
        ''' <remarks></remarks>
        Public Function CheckPassword(ByVal password As String) As Boolean
            Dim newPaswdBytes() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(password)
            Dim c As New System.Security.Cryptography.HMACSHA256(System.Text.ASCIIEncoding.ASCII.GetBytes(cryptedkey))
            Dim hashBytes() As Byte = c.ComputeHash(newPaswdBytes)

            Dim checkwith As String = Convert.ToBase64String(hashBytes)

            If checkwith.Equals(Me.Password) Then
                Return True
            Else
                Return False

            End If


        End Function
        ''' <summary>
        ''' Ruft den Nachnamen ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Surename")> _
        Public Property SureName() As String
            Get
                Return m_surename
            End Get
            Set(ByVal value As String)
                m_surename = value
                SetPropertyValue(Of String)("SureName", m_surename, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den vollen Vornamen ab oder legt diesen fest 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ForeName")> _
        Public Property Firstname() As String
            Get
                Return m_foreName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Firstname", m_foreName, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Anmeldenamen des Benutzers ab oder legt diesen fest
        ''' </summary>
        ''' <value>Der Anmedlenamen sollte sich nicht weiter ändern </value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Name")> _
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Name", m_name, value)
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me.Name & " (" & Me.Firstname & ", " & Me.SureName & ")"
        End Function


        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace
