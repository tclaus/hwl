Imports SHK_Connect.de.shk_connect.shkgh2

''' <summary>
''' Ruft zu einem Unternemen detailierte Daten ab
''' </summary>
''' <remarks></remarks>
Public Class SpecialInfo
    Friend Event StatusMessage(sender As Object, e As StatusMessageEventArg)

    ''' <summary>
    ''' Stellt Details zu einem angefragten Unternehmen bereit. 
    ''' Schlüssel ist die Unternehmens-ID
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared m_companiesDetailInfo As New Dictionary(Of Integer, CompanyDetailInfo)

    Private Shared m_companyLinkAuthDataList As New Dictionary(Of Integer, Linkauthorization)

    ''' <summary>
    ''' Ruft Zugangsdaten zu einem Unternehmen ab - sofern der Downloadlink dies verlangt
    ''' </summary>
    ''' <param name="companyID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAccessData(companyID As Integer) As Linkauthorization

        If m_companyLinkAuthDataList.ContainsKey(companyID) Then
            Return m_companyLinkAuthDataList(companyID)
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' Ruft Informationen zu diesem Untermehmen ab
    ''' </summary>
    ''' <param name="company">Das angefragte Unternehmen</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCompanyInfo(company As Company) As CompanyDetailInfo
        Debug.Print("Hole Info zum Unternehmen '" & company.ToString & "'")
        If Not m_companiesDetailInfo.ContainsKey(company.ID) Then

            Debug.Print(" Frage Server...")
            RaiseEvent StatusMessage(Me, New StatusMessageEventArg("Starte Anfrage..."))

            Dim service As New anwenderIndividuelleAuskuenfteService()

            Dim info As New GetIndividuelleAuskunft()

            If company.Credential IsNot Nothing Then

                info.Benutzername = company.Credential.Username
                info.Kundennummer = company.Credential.UserId
                info.Passwort = company.Credential.Password
            End If

            info.UnternehmensID = company.ID

            info.Schnittstellenversion = ConnectionData.ConnectionVersion
            info.Softwarename = ConnectionData.AppName
            info.Softwarepasswort = ConnectionData.AppPassword

            Dim response As GetIndividuelleAuskunftResponse

            response = service.GetIndividuelleAuskunft(info)
            If response IsNot Nothing Then

                Debug.Print("Status: " & response.Status.Code & ": " & response.Status.Meldung)
                Debug.Print("Serverkennung:" & response.Serverkennung)

                If response.Status.Code = "0" Then
                    RaiseEvent StatusMessage(Me, New StatusMessageEventArg("OK"))
                Else
                    RaiseEvent StatusMessage(Me, New StatusMessageEventArg(response.Status.Meldung))
                End If

                'Athentifizierung fehlgeschlagen
                If response.Status.Code = "4" Then
                    Throw New Exception(response.Status.Meldung)
                End If

                Dim newCompanyDetail As New CompanyDetailInfo
                With response
                    newCompanyDetail.Serverkennung = .Serverkennung

                    For Each pItem As SHK_Connect.de.shk_connect.shkgh2.Prozess In .Prozessliste
                        Dim newProcessItem As New ProcessItem
                        newProcessItem.URL = pItem.URL
                        newProcessItem.ProcessCode = pItem.Prozesscode

                        'Teilprozesse abholen 
                        If pItem.Teilprozesse IsNot Nothing Then
                            For Each item As String In pItem.Teilprozesse
                                newProcessItem.PartProcess.Add(item)
                            Next
                        End If

                        ' Dateiverknüpfungen abholen
                        If pItem.Link IsNot Nothing Then
                            For Each item As Link In pItem.Link
                                Dim newPLink As New ProcessLink

                                newPLink.Authenticode = item.Authentifizierungsmethode
                                newPLink.ChangeNotes = item.AenderungsInfo

                                'CookieListe abholen
                                If item.CookieList IsNot Nothing Then
                                    For Each cItem As String In item.CookieList
                                        newPLink.Cookielist.Add(cItem)
                                    Next
                                End If

                                newPLink.DataInfo = CDate(item.DatenDatum)
                                newPLink.Description = item.Beschreibung

                                Date.TryParse(item.Datum, newPLink.FileDate)

                                newPLink.Size = item.Groesse
                                newPLink.URL = item.URL

                                ' Link hinzufügen
                                newProcessItem.Links.Add(newPLink)
                            Next
                        End If

                        newCompanyDetail.ProcessList.Add(newProcessItem)
                    Next

                End With
                ' Das neue Detail der Auflistung hinzufügen
                m_companiesDetailInfo.Add(company.ID, newCompanyDetail)
            End If

        Else
            Debug.Print("Cache treffer! ")
        End If



        Return m_companiesDetailInfo(company.ID)

    End Function

    Public Sub New()

    End Sub
End Class

''' <summary>
''' stellt detailiertere Daten eines Untrernehmens dar
''' </summary>
''' <remarks></remarks>
Public Class CompanyDetailInfo
    Private m_serverkennung As String

    Private m_processList As New List(Of ProcessItem)

    ''' <summary>
    ''' Ruft Detaildaten zum Unternehmen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ProcessList As List(Of ProcessItem)
        Get
            Return m_processList
        End Get
    End Property

    Public Property Serverkennung() As String
        Get
            Return m_serverkennung
        End Get
        Set(ByVal value As String)
            m_serverkennung = value
        End Set
    End Property

End Class


Public Class ProcessItem
    Private m_process As String
    Private m_ProcessCode As String
    Private m_PartProcess As New List(Of String)
    Private m_URL As String
    Private m_Links As New List(Of ProcessLink)
    Private m_desciption As String

    Public Property Description() As String
        Get
            Return m_desciption
        End Get
        Set(ByVal value As String)
            m_desciption = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft weitere Daten zur Dateiverlinkung ab.
    ''' Kann mehrere Dateien enthalten
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Links() As List(Of ProcessLink)
        Get
            Return m_Links
        End Get
    End Property

    ''' <summary>
    ''' URL unter der die Kommunikation für weitere Daten mit dem Unternehmen rfolgt
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property URL() As String
        Get
            Return m_URL
        End Get
        Set(ByVal value As String)
            m_URL = value
        End Set
    End Property

    Public ReadOnly Property PartProcess As List(Of String)
        Get
            Return m_PartProcess
        End Get

    End Property

    Public Property ProcessCode() As String
        Get
            Return m_ProcessCode
        End Get
        Set(ByVal value As String)
            m_ProcessCode = value
        End Set
    End Property

    Public Property Process() As String
        Get
            Return m_process
        End Get
        Set(ByVal value As String)
            m_process = value
        End Set
    End Property

End Class

''' <summary>
''' Enthält weitere Daten zu einem Prozess
''' </summary>
''' <remarks></remarks>
Public Class ProcessLink
    Private m_description As String = String.Empty
    Private m_URL As String = String.Empty
    Private m_date As DateTime
    Private m_size As Long?  ' Nullable (Warum auch immer..)

    Private m_Authenticode As de.shk_connect.shkgh2.Authentifizierungsmethode
    Private m_FileDate As DateTime
    Private m_ChangeNotes As String = String.Empty
    Private m_cookieList As New List(Of String)

    Private m_companyName As String

    ''' <summary>
    ''' Der Name des Unternehmns, zu dem dieser Link gehört
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CompanyName() As String
        Get
            Return m_companyName
        End Get
        Set(ByVal value As String)
            m_companyName = value
        End Set
    End Property

    ''' <summary>
    ''' Enthält eine Auflistung von Cookies
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Cookielist() As List(Of String)
        Get
            Return m_cookieList
        End Get

    End Property
    ''' <summary>
    ''' Enthält Informationen darüber, was sich in den Dateien geändert hat
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChangeNotes() As String
        Get
            Return m_ChangeNotes
        End Get
        Set(ByVal value As String)
            m_ChangeNotes = value
        End Set
    End Property

    ''' <summary>
    ''' Datum der Datei
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileDate() As DateTime
        Get
            Return m_FileDate
        End Get
        Set(ByVal value As DateTime)
            m_FileDate = value
        End Set
    End Property

    ''' <summary>
    ''' Enthält Information über die Art der Authentifizierung
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Authenticode() As de.shk_connect.shkgh2.Authentifizierungsmethode
        Get
            Return m_Authenticode
        End Get
        Set(ByVal value As de.shk_connect.shkgh2.Authentifizierungsmethode)
            m_Authenticode = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft die Dateigrösse in Bytes ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Size() As Long?
        Get
            Return m_size
        End Get
        Set(ByVal value As Long?)
            m_size = value
        End Set
    End Property

    ''' <summary>
    '''  Ruft das Datum der enthaltenen Daten ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataInfo() As DateTime
        Get
            Return m_date
        End Get
        Set(ByVal value As DateTime)
            m_date = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft den direkten Download-Link ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property URL() As String
        Get
            Return m_URL
        End Get
        Set(ByVal value As String)
            m_URL = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft eine Dateibeschreibung des Links ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(ByVal value As String)
            m_Description = value
        End Set
    End Property

End Class


Friend Enum ProcesLinkstatus
    WaitingForDownload ' noch nicht geladen
    Loaded ' Geladen 
    ErrorInDownload ' 

End Enum

''' <summary>
''' Enthält Zugangsdaten für einen einzelnen Link
''' </summary>
''' <remarks></remarks>
Public Class Linkauthorization
    Private m_linkID As String
    Private m_username As String
    Private m_password As String

    Public Property Password() As String
        Get
            Return m_password
        End Get
        Set(ByVal value As String)
            m_password = value
        End Set
    End Property

    Public Property Username() As String
        Get
            Return m_username
        End Get
        Set(ByVal value As String)
            m_username = value
        End Set
    End Property

    Public Property LinkID() As String
        Get
            Return m_linkID
        End Get
        Set(ByVal value As String)
            m_linkID = value
        End Set
    End Property

End Class


''' <summary>
''' Enthält weitere Informationen zum verwendeten Link
''' </summary>
''' <remarks></remarks>
Friend Class LocalProcesLink


    Private m_status As ProcesLinkstatus

    Private m_filePath As String = String.Empty
    Private m_parentLink As ProcessLink

    Public Property ParentLink() As ProcessLink
        Get
            Return m_parentLink
        End Get
        Set(ByVal value As ProcessLink)
            m_parentLink = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft den Pfad ab, uinter der die Datei geladen wurde
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FilePath() As String
        Get
            Return m_filePath
        End Get
        Set(ByVal value As String)
            m_filePath = value
        End Set
    End Property

    Public Property Status() As ProcesLinkstatus
        Get
            Return m_status
        End Get
        Set(ByVal value As ProcesLinkstatus)
            m_status = value
        End Set
    End Property


End Class
