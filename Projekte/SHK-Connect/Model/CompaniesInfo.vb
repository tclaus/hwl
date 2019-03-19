Imports SHK_Connect.de.shk_connect.shkgh1
Imports System.IO.IsolatedStorage
Imports System.IO

Friend Class CompaniesInfo
    Inherits BaseData

    Friend Event StatusMessage(sender As Object, e As StatusMessageEventArg)

    ''' <summary>
    ''' Stellt die Liste der Unternehmen bereit. Sortiert anhand der Branchen-ID
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared m_listOfCompanies As Dictionary(Of Integer, List(Of UsersCompany))

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private WithEvents m_companySpecialInfo As New SpecialInfo



    ''' <summary>
    ''' Ruft ein Objekt ab, das erweiterte Unternehmensdaten bereithält
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property SpecialCompanyInfo As SpecialInfo
        Get
            Return m_companySpecialInfo
        End Get
    End Property

    ''' <summary>
    ''' Ruft die Liste der Firmen anhand gegebener Branche und Umkreis ab
    ''' </summary>
    ''' <param name="trade"></param>
    ''' <param name="distance"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCompanyByTradeId(trade As Trade, distance As Long) As List(Of UsersCompany)
        If m_listOfCompanies Is Nothing Then
            ' Neue Datenstruktur anlegen
            m_listOfCompanies = New Dictionary(Of Integer, List(Of UsersCompany))
        End If

        Dim tradeID As Integer
        If trade IsNot Nothing Then tradeID = trade.ID

        If Not m_listOfCompanies.ContainsKey(tradeID) Then

            Dim companiesListByTradeId As New List(Of UsersCompany)

            Dim service As New de.shk_connect.shkgh1.allgemeineAuskuenfteService

            RaiseEvent StatusMessage(Me, New StatusMessageEventArg("Starte Anfrage..."))


            Dim infoobj As New GetAllgemeineAuskunft()
            infoobj.Schnittstellenversion = ConnectionData.ConnectionVersion
            infoobj.Softwarename = ConnectionData.AppName
            infoobj.Softwarepasswort = ConnectionData.AppPassword

            ' --
            infoobj.BrancheID = CStr(tradeID)
            infoobj.Prozess = "STD"
            infoobj.Umkreis = New Umkreis()
            infoobj.Umkreis.Entfernung = "2000" 'CStr(distance)
            infoobj.Umkreis.Postleitzahl = "44357"


            Dim resp As GetAllgemeineAuskunftResponse = service.GetAllgemeineAuskunft(infoobj)

            If resp.Status.Code = "0" Then
                RaiseEvent StatusMessage(Me, New StatusMessageEventArg("OK"))
            Else
                RaiseEvent StatusMessage(Me, New StatusMessageEventArg(resp.Status.Meldung))
            End If

            Debug.Print("Schnittstellenversion: " & resp.Schnittstellenversion)
            Debug.Print("Serverkennung: " & resp.Serverkennung)
            Debug.Print("Status: " & resp.Status.Code & ": " & resp.Status.Meldung)
            If resp.Unternehmen IsNot Nothing Then
                Debug.Print("Unternehmen: " & resp.Unternehmen.Length)

                If resp.Unternehmen.Length = 0 Then
                    Debug.Print("Es wurden keine Unternehmen zurückgeliefert.")
                    Return New List(Of UsersCompany)
                End If


                For Each readCompany As Unternehmen In resp.Unternehmen
                    Dim newCompany As New UsersCompany
                    With readCompany
                        newCompany.ID = .ID
                        newCompany.Land = .Land
                        newCompany.Name = .Name
                        newCompany.Ort = .Ort
                        newCompany.PLZ = .PLZ
                        newCompany.Strasse = .Strasse
                    End With
                    companiesListByTradeId.Add(newCompany)

                Next
            Else
                Debug.Print("Keine Unternehmensdaten gefunden.")
            End If


            m_listOfCompanies.Add(tradeID, companiesListByTradeId)
            SaveCache()
        Else
            Debug.Print("Unternehmensdaten aus Cache geladen")

        End If

        Return m_listOfCompanies(tradeID)

    End Function


    ''' <summary>
    ''' Speichert die Linklisten der Unternehmen
    ''' </summary>
    ''' <remarks></remarks>
    Private m_detailsCompanyCache As New Dictionary(Of Integer, List(Of ProcessLink))

    ''' <summary>
    ''' Lehrt den Cache
    ''' </summary>
    ''' <param name="company"></param>
    ''' <remarks></remarks>
    Public Sub RefreshCompanyDetailInfo(company As Company)
        If m_detailsCompanyCache.ContainsKey(company.ID) Then
            m_detailsCompanyCache.Remove(company.ID)
        End If

    End Sub

    ''' <summary>
    ''' Ruft Details zu einer Firma ab
    ''' </summary>
    ''' <param name="company"></param>
    ''' <remarks></remarks>
    Public Function GetCompanyLinks(company As Company) As List(Of ProcessLink)

        If Not m_detailsCompanyCache.ContainsKey(company.ID) Then

            Dim infoBlock As CompanyDetailInfo
            'TODO: Caching

            infoBlock = Me.SpecialCompanyInfo.GetCompanyInfo(company)

            m_detailsCompanyCache.Add(company.ID, New List(Of ProcessLink))

            If infoBlock IsNot Nothing Then

                For Each pItm As ProcessItem In infoBlock.ProcessList
                    If pItm.ProcessCode = "STD" Then 'STD = Standard Datanorm

                        For Each link As ProcessLink In pItm.Links
                            link.CompanyName = company.Name ' Für die Anzeige im Grid
                            m_detailsCompanyCache(company.ID).Add(link)
                        Next
                    End If
                Next
            End If

            Debug.Print("Anzahl Links: " & CStr(m_detailsCompanyCache(company.ID).Count))


        Else
            Debug.Print("Cache Hit")
        End If

        ' Nicht  den Cache direkt rausgeben !
        Dim newList As New List(Of ProcessLink)
        newList.AddRange(m_detailsCompanyCache(company.ID))

        Return newList
    End Function

    ''' <summary>
    ''' Ruft die Auflistung aller Unternehmen ab, die Daten bereitstellen.
    ''' Wird aufgefüllt, indem die Branche abgefragt wird
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Companies As List(Of UsersCompany)
        Get

            Dim completeList As New List(Of UsersCompany)
            For Each companyListByTrade As List(Of UsersCompany) In m_listOfCompanies.Values
                completeList.AddRange(companyListByTrade)
            Next

            Return completeList

        End Get
    End Property


    ''' <summary>
    ''' Läd aus einem zwischenspeicher die Unternehmensdaten ein
    ''' </summary>
    ''' <remarks></remarks>
    Friend Overrides Sub LoadCache()
        Dim isolatedStorage As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, Nothing, Nothing)
        Try
            Dim isolatedStream As New IsolatedStorageFileStream("SHK-CompaniesList", FileMode.Open, isolatedStorage)

            Try
                Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                m_listOfCompanies = CType(formatter.Deserialize(isolatedStream), Dictionary(Of Integer, List(Of UsersCompany)))

                Debug.Print("Liste der Unternehmensdaten aus Cache gelesen.")

            Catch x As Exception
                Debug.Print("Fehler beim einlesen des Caches für Unternehmensdaten: " & x.Message)
            End Try
            isolatedStream.Close()

            isolatedStream = Nothing

            isolatedStorage.Close()
            isolatedStorage = Nothing
        Catch ex As Exception
            Debug.Print("Konnte Cache für Unternehmensdaten nicht einlesen: " & ex.Message)
        End Try

    End Sub

    Friend Sub SaveCache()
        Dim isolatedStorage As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, Nothing, Nothing)
        Try
            Dim isolatedStream As New IsolatedStorageFileStream("SHK-CompaniesList", FileMode.Create, isolatedStorage)
            Try
                Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                formatter.Serialize(isolatedStream, m_listOfCompanies)

            Catch x As Exception
                Debug.Print("Fehler beim schreiben des Caches für Unternehenm:" & x.Message)
            End Try
            isolatedStream.Close()
            isolatedStream = Nothing

            isolatedStorage.Close()
            isolatedStorage = Nothing
        Catch ex As Exception
            Debug.Print("Konnte Cache für Unternehmensdaten nicht schreiben: " & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Leert alle Listen. Damit wird bei der nächsten Anfrage wieder der Server gefragt
    ''' </summary>
    ''' <remarks></remarks>
    Friend Overrides Sub Refresh()
        m_listOfCompanies.Clear()
        m_listOfCompanies = Nothing

    End Sub

    Public Sub New()
        LoadCache()
        UsersCompany.LoadFavorites()

    End Sub

    Private Sub m_companySpecialInfo_StatusMessage(sender As Object, e As StatusMessageEventArg) Handles m_companySpecialInfo.StatusMessage
        RaiseEvent StatusMessage(sender, e)
    End Sub

End Class

''' <summary>
''' Stellt die Datenstruktur eines Datenlieferanten (Unternehmen) bereit
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class Company
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private m_id As Integer
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private m_Name As String
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private m_Strasse As String
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private m_plz As String
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private m_ort As String
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private m_land As String

    Private m_credential As CompanyCredential

    ''' <summary>
    ''' Besitzt Zugangsdaten
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasCredentials As Boolean
        Get
            Return m_credential IsNot Nothing
        End Get
    End Property
    ''' <summary>
    ''' Ruft Zugangsdaten für das Unternehmen ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Credential As CompanyCredential
        Get
            Return m_credential
        End Get
        Set(value As CompanyCredential)
            m_credential = value
        End Set
    End Property
    ''' <summary>
    ''' Land des Unternehmens, das angefragt wird
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Land() As String
        Get
            Return m_land
        End Get
        Set(ByVal value As String)
            m_land = value
        End Set
    End Property

    ''' <summary>
    ''' Ort des Unternehmens das angefragt wird
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Ort() As String
        Get
            Return m_ort
        End Get
        Set(ByVal value As String)
            m_ort = value
        End Set
    End Property

    ''' <summary>
    ''' Postleitzahl des Unternehms das angefragt wird
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PLZ() As String
        Get
            Return m_plz
        End Get
        Set(ByVal value As String)
            m_plz = value
        End Set
    End Property

    ''' <summary>
    ''' Strasse des Unternehmens, das angefragt wird
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Strasse() As String
        Get
            Return m_Strasse
        End Get
        Set(ByVal value As String)
            m_Strasse = value
        End Set
    End Property

    ''' <summary>
    ''' Name des Unternehmens das angefragt wird
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property
    ''' <summary>
    ''' eindeutige Kennung des Unternehmens, das angefragt wird
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft einen Anzeigetext ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return Me.Name & "(" & Me.Ort & ")"

    End Function

    Public Sub New()

    End Sub
End Class

''' <summary>
''' Erweitert die Unternehmens - Klasse (Company) um ein Favoriten-Eintrag
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class UsersCompany
    Inherits Company

    Private Shared m_favoriteIDs As New List(Of Integer) ' Speichert alle IDs, dessen Unternehmen als Favorit gekennzeichnet wurden
    Private Shared m_isFavoritesLoaded As Boolean
    ''' <summary>
    ''' Zeigt an, ob diese ID als Favorit gekennzeichnet wurde
    ''' </summary>
    ''' <param name="companyID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function IsCompanyIDFavorit(companyID As Integer) As Boolean
        Return m_favoriteIDs.Contains(companyID)
    End Function

    ''' <summary>
    ''' Als Favorit markieren
    ''' </summary>
    ''' <param name="companyId"></param>
    ''' <remarks></remarks>
    Friend Shared Sub SetAsFavorit(companyId As Integer)
        If Not m_favoriteIDs.Contains(companyId) Then
            m_favoriteIDs.Add(companyId)
        End If
    End Sub

    ''' <summary>
    ''' Eine Favoriten-Markierung entfernen
    ''' </summary>
    ''' <param name="companyID"></param>
    ''' <remarks></remarks>
    Friend Shared Sub RemoveFavorite(companyID As Integer)
        If m_favoriteIDs.Contains(companyID) Then
            m_favoriteIDs.Remove(companyID)
        End If
    End Sub

    ''' <summary>
    ''' Läd die Auflistung von Favoriten ein
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub LoadFavorites()
        If Not m_isFavoritesLoaded Then
            m_isFavoritesLoaded = True
            Dim isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, Nothing, Nothing)
            Try
                Dim isolatedStream As New IsolatedStorageFileStream("SHK-Connect_Favorites", FileMode.Open, isolatedStorage)

                Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                m_favoriteIDs = CType(formatter.Deserialize(isolatedStream), Global.System.Collections.Generic.List(Of Integer))

            Catch ex As Exception
                Debug.Print("Fehler beim Laden der Favoriten: " & ex.Message)
            Finally
                isolatedStorage.Close()

            End Try
        End If

    End Sub

    ''' <summary>
    ''' Speichert die Auflistung von Favoriten
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SaveFavorites()

        Dim isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, Nothing, Nothing)
        Try
            Using isoStream As New IsolatedStorageFileStream("SHK-Connect_Favorites", FileMode.Create, FileAccess.Write, isolatedStorage)

                Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                formatter.Serialize(isoStream, m_favoriteIDs)
                isoStream.Close()
            End Using

        Catch ex As Exception
            Debug.Print("Fehler beim Speichern der Favoriten: " & ex.Message)

        Finally
            isolatedStorage.Close()
        End Try

    End Sub

    ''' <summary>
    ''' Zeigt an, ob dieses Unternehmenb als Favorit gekennzeichnet wurde
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsFavorite As Boolean
        Get
            Return UsersCompany.IsCompanyIDFavorit(Me.ID)
        End Get
        Set(value As Boolean)
            If value Then
                UsersCompany.SetAsFavorit(Me.ID)
            Else
                UsersCompany.RemoveFavorite(Me.ID)
            End If

        End Set
    End Property



End Class

<Serializable()> _
Public Class CompanyCredential
    Private m_userID As String
    Private m_userName As String
    Private m_password As String
    Private m_companyID As String

    ''' <summary>
    ''' Ruft die ID der Firma ab ode legt diese fest für die diese Einstellungen gültig sind
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CompanyID() As String
        Get
            Return m_companyID
        End Get
        Set(ByVal value As String)
            m_companyID = value
        End Set
    End Property

    ''' <summary>
    ''' Passwort zum Datenstamm der Firma
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Password() As String
        Get
            Return m_password
        End Get
        Set(ByVal value As String)
            m_password = value
        End Set
    End Property

    ''' <summary>
    ''' Benutzername
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Username() As String
        Get
            Return m_userName
        End Get
        Set(ByVal value As String)
            m_userName = value
        End Set
    End Property

    ''' <summary>
    ''' Kundennummer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserId() As String
        Get
            Return m_userID
        End Get
        Set(ByVal value As String)
            m_userID = value
        End Set
    End Property

End Class