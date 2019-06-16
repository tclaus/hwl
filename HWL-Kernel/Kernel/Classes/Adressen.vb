Option Explicit On
Option Strict On


Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports System.Runtime.InteropServices
Imports DevExpress.Data.Filtering

Namespace Kernel

    ''' <summary>
    ''' Stellt eine LIste von Adressen da.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Adressen
        Inherits BaseCollection(Of Adress)
        Implements IDataCollection

        Private m_contactsByTag As New Dictionary(Of String, Adress)

        ''' <summary>
        '''  Prüft, ob die ID schon mal vergeben war
        ''' </summary>
        ''' <param name="idstr"></param>
        ''' <returns>TRUE if ID is Unque</returns>
        ''' <remarks></remarks>
        Public Function CheckUniqueID(ByVal idstr As String) As Boolean
            Dim sql As String
            Dim Count As Long

            Try
                '    If idstr = "" Then Return True

                sql = "select count(*) from " & Adress.Tablename & " where Schlüssel='" & idstr & "'"

                Dim res As Object = MainApplication.Database.ExcecuteScalar(sql)

                If Not TypeOf res Is DBNull Then
                    Count = CLng(res)
                Else
                    Return False
                End If

            Catch exp As Exception

            End Try
            Return (Count = 0)

        End Function
        ''' <summary>
        ''' Holt eine Adresse anhand der Adsressennummer aus dieser Auflistungsmenge. Existiert die Adresse mit der Kontaktnummer nicht, wird 'nothing' zurückgegeben
        ''' </summary>
        ''' <param name="Nummer"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemByNumber(ByVal Nummer As Long) As Adress

            For Each Item As Adress In Me
                If Item.Kundennummer = Nummer Then
                    Return Item
                End If
            Next
            Return Nothing
        End Function


        ''' <summary>
        ''' Prüft, ob der angegebene Artikel ein Abhängigkeit zu einem anderen Dokument besitzt. Dann kann dieser nicht gelöscht werden
        ''' </summary>
        ''' <param name="adressToCheck">Die zu prüfende Adresse</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function HasUnresolvedContraints(ByVal adressToCheck As Adress) As Boolean
            ' Gibt wahr /Falsch zurück oser gleich eine Liste mit abhängigkeiten ? 
            ' Artikel (lieferant) 
            ' Journal (sehr wichtig) 
            ' Briefe
            ' Forderungen
            Return adressToCheck.HasUnresolvedContraints
        End Function

        ''' <summary>
        ''' Ermittelt eine Adresse anhand der eBayID (UniqueID) 
        ''' </summary>
        ''' <param name="eBayID">Die ID (z.B. eBayID die deiseer Adresse zugewiesen wurde</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemByUniqueID(ByVal eBayID As String) As Adress
            Dim criteria As CriteriaOperator = New BinaryOperator("ebayID", eBayID)
            Dim contacts As Adressen = New Adressen(Data.BaseCollection(Of Adress).MainApplication, criteria)

            If contacts.Count > 0 Then
                Return contacts(0)
            Else
                Return Nothing
            End If



        End Function

        ''' <summary>
        ''' Ruft eine neue Auflistung aller Konmtaktdaten ab
        ''' </summary>
        ''' <param name="BasisApplikation"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal BasisApplikation As MainApplication)
            MyBase.New(BasisApplikation)
            Initialize()
        End Sub

        ''' <summary>
        ''' Ruft eine neue Auflistung 
        ''' </summary>
        ''' <param name="BasisApplikation"></param>
        ''' <param name="criteria"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

        ''' <summary>
        ''' Prüft, ob ein Adressen-Schlüssel bereits vergeben wurde. (Z.B.: als EbayID genutzt) 
        ''' </summary>
        ''' <param name="AdressID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IDExists(ByVal AdressID As String) As Boolean

            Dim sql As String
            sql = "SELECT count(*) FROM " & Adress.Tablename & " WHERE schlüssel='" & AdressID & "'"

            Dim result As Object
            result = MainApplication.Database.ExcecuteScalar(sql)
            If Not TypeOf result Is DBNull Then
                Return CInt(result) > 0
            End If
            Return False

        End Function

        ''' <summary>
        ''' Ruft eine neue freie Adressen-Numme aus der Datenbank ab.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNextAddressNumber() As Integer
            Dim result As Object

            Dim Sql As String = "SELECT max(Nummer) FROM " & Adress.Tablename
            result = MainApplication.Database.ExcecuteScalar(Sql)

            Dim MaxNUmber As Integer

            If Not TypeOf result Is DBNull Then
                MaxNUmber = CInt(result)
            Else
                MaxNUmber = 0
            End If

            Return MaxNUmber + 1

        End Function

        ''' <summary>
        ''' Durchsucht alle bestehenden Adressen, und gibt eine Stadt zurück, zu der die PLZ bereit passt
        ''' </summary>
        ''' <param name="zipCode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTownByZipCode(zipCode As String) As String
            If Not String.IsNullOrEmpty(zipCode) Then
                For Each addressItem As Adress In Me
                    If addressItem.ZipCode.Equals(zipCode, StringComparison.InvariantCultureIgnoreCase) Then
                        Return addressItem.Town
                    End If
                Next
            End If

            Return String.Empty
        End Function

        ''' <summary>
        ''' Wacht über geänderte Tags, ein Tag ist ein eindeutige Signatur um mit einem externen Programm (Adressverwaltung) 
        ''' einen Kontakt eindeutig zuzuordnen
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub TagChangerWatcher(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)
            If e.PropertyName.Equals("Tag") Then

                Dim Adress As Adress = CType(sender, Adress)
                If Not String.IsNullOrEmpty(Adress.Tag) Then

                    If m_contactsByTag(Adress.Tag) Is Nothing Then
                        m_contactsByTag.Add(Adress.Tag, Adress)
                    End If

                    m_contactsByTag.Add(Adress.Tag, Adress)


                End If
            End If
        End Sub

        Public Overrides Function BaseAdd(ByVal newObject As Object) As Integer


            Dim adress As Adress = CType(newObject, Adress)

            If Not String.IsNullOrEmpty(adress.Tag) Then
                m_contactsByTag.Add(adress.Tag, adress)
            End If

            AddHandler adress.PropertyChanged, AddressOf TagChangerWatcher

            Return MyBase.BaseAdd(newObject)
        End Function

        ''' <summary>
        ''' Ruft ein Adressbucheintrag anhand des Tags ab
        ''' </summary>
        ''' <param name="tag"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetContactByTag(ByVal tag As String) As Adress
            Return m_contactsByTag(tag)
        End Function

        ''' <summary>
        ''' Ruft eine neue Adrese ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As Adress
            Dim newAdress As Adress = MyBase.GetNewItem()
            newAdress.CreatedAt = Today
            newAdress.CreatedByID = MainApplication.CurrentUser.Key
            Return newAdress
        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder

            DisplayProps.Append("ContactDisplayID;")
            DisplayProps.Append("FirstName;")
            DisplayProps.Append("LastName;")

            DisplayProps.Append("Company;")
            DisplayProps.Append("Street;")
            DisplayProps.Append("ZipCode;")
            DisplayProps.Append("Town;")
            DisplayProps.Append("Telefon1;")
            DisplayProps.Append("Telefon2;")
            DisplayProps.Append("EMail;")
            DisplayProps.Append("Fax;")
            DisplayProps.Append("CreatedAt;")
            DisplayProps.Append("ChangedAt;")

            Me.DisplayableProperties = DisplayProps.ToString

            Me.FullTextSearchColumns = New String() {"ContactsName", "ContactDisplayID", "Company", "ebayID"}


        End Sub

        ''' <summary>
        ''' Ruft eine neue Auflistung von Adressen ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function GetNewCollection() As Adressen
            Return New Adressen(MainApplication)
        End Function

        ''' <summary>
        ''' Ruft eine neue Auflistung der Adressen mit dem angegebenen Kriterium ab
        ''' </summary>
        ''' <param name="criteria"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function GetNewCollection(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator) As Adressen
            Dim newAdressese As New Adressen(MainApplication, criteria)
            Return newAdressese
        End Function

    End Class
End Namespace

