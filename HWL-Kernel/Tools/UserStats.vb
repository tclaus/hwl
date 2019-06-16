Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web
Imports Microsoft.VisualBasic

Namespace Tools

    Public Enum ReportMessageType
        ''' <summary>
        ''' Absturz... 
        ''' </summary>
        ''' <remarks></remarks>
        ApplicationCrash
        ''' <summary>
        ''' Benutzerende der Applikation
        ''' </summary>
        ''' <remarks></remarks>
        ApplicationEnd
        ''' <summary>
        ''' Start der Applikation
        ''' </summary>
        ''' <remarks></remarks>
        ApplicationStart

        ''' <summary>
        ''' Zeitdauert, bis die Applikation gestartet ist
        ''' </summary>
        ''' <remarks></remarks>
        ApplicationStartUpTime
        ''' <summary>
        ''' Reine Information, ohne besondere Bedeutung
        ''' </summary>
        ''' <remarks></remarks>
        Info

        ''' <summary>
        ''' Zeigt einen warnzustand an. Ein nicht vorhersehbarer Zutand der Daten wurde erreicht und der Benutzer muss eingreiffen
        ''' </summary>
        ''' <remarks></remarks>
        Warning
        ''' <summary>
        ''' Startereignis eines Modules
        ''' </summary>
        ''' <remarks></remarks>
        ModulStart
        ''' <summary>
        ''' Ein Programmteil wurde geschlossen
        ''' </summary>
        ''' <remarks></remarks>
        ModulEnd
        ''' <summary>
        ''' Startdauer eines Programmteils von der Anforderung durch den Anwender (click) bis zur Bereitstellung der Oberfläche (_Shown)
        ''' </summary>
        ''' <remarks></remarks>
        StartupTime


    End Enum

    ''' <summary>
    ''' Stellt statistische Informationen zur Verfügung und kann statistische Daten senden 
    ''' Ermöglict es, Benutzer-Statistiken und Fehlerprotokolle zu senden.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class UserStats
        ' Verbindung prüfen; 
        ' Daten senden per html (geht auch ohen odbc) 

        ''' <summary>
        ''' enthält eine Nummer der aktuellen Instanz. 
        ''' Damit lassen sich mehrere gleichzeitige Programmläufe auseinanderhalten
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared randomNumber As Integer

        ''' <summary>
        ''' ein Verweis auf den Webservice
        ''' </summary>
        ''' <remarks></remarks>
        Private WithEvents m_statsServer As OnlineReporting.StatisticsReporting

        ''' <summary>
        ''' Sendet ein Datenpaket an den Statistik-Server mit Standard Applikationsname
        ''' </summary>
        ''' <param name="modulname">Der Name des verursachenden Modul. Ein Kurzname des Modules, nicht der Applikationsname</param>
        ''' <param name="messageText">Freier Text, was ist passiert? </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SendStatistics(ByVal modulname As String, ByVal messageText As String) As Boolean
            Return SendStatistics(ReportMessageType.Info, modulname, messageText)

        End Function

        Private m_info As StatisticInfo
        ''' <summary>
        ''' Ruft einige Datenbankstatistiken ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property InfoItem() As StatisticInfo
            Get

                If m_info Is Nothing Then
                    m_info = New StatisticInfo()
                End If

                Return m_info
            End Get

        End Property

        ''' <summary>
        ''' Ruft einen wert ab, der anzeigt ob das senden von anonymen Fehlernachrichten erlaubt ist.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SendingAllowed As Boolean
            Get

                If MainApplication.getInstance IsNot Nothing AndAlso MainApplication.getInstance.Session IsNot Nothing Then
                    Try
                        Return MainApplication.getInstance.Settings.SettingSendStatistics
                    Catch
                    End Try
                End If
                Return True

            End Get
        End Property

        ''' <summary>
        ''' Sendet ein Datenpaket an den Statistik-Server mit dem angegebenen Applikationsnamen und den Daten
        ''' </summary>
        ''' <param name="messageType">eine Spezifizierung der Nachrichten Art</param>
        ''' <param name="modulname">Kurzname des verursachenden Moduls, oder Aktionsname, wenn eindeutig (Start / End) </param>
        ''' <param name="messageText">Klartextname der Information</param>
        ''' <returns></returns>
        ''' <remarks>Es wird nichts übertragen, wenn der Anwender die Qualitätssicherung ausgeschaltet hat</remarks>
        Public Function SendStatistics(ByVal messageType As ReportMessageType, ByVal modulname As String, ByVal messageText As String) As Boolean
            SyncLock Me
                Static successfulSent As Boolean = True

                ' Kann sein, das das Applikationsobjekt noch nicht existiert


                If SendingAllowed Then

                    If successfulSent Then ' keine weiteren Anfragen, wenn Statistik nicht gesendet wwerden kann

                        Dim AppID As String = String.Empty
                        Try
                            If MainApplication.getInstance.Session IsNot Nothing Then
                                AppID = MainApplication.getInstance.ApplicationID()
                            Else
                                AppID = MainApplication.getInstance.GetLastKnownApplicationID
                            End If
                        Catch
                            ' ein Fehler hier ignorieren (kann durch fehlende ID beim ersten Start passieren
                        End Try

                        MainApplication.getInstance.Log.WriteLog(modulname, messageText)
                        successfulSent = SendData(randomNumber, AppID, modulname, messageType, messageText)
                        If Not successfulSent Then
                            MainApplication.getInstance.Log.WriteLog("Konnte Statistik nicht senden, sende keine weiteren Statistiken in dieser Instanz,")
                        End If
                    Else

                    End If
                End If
                Return successfulSent
            End SyncLock


        End Function

        ''' <summary>
        ''' Sendet eine Zeile von Statistik-Daten an den Statistik-Server
        ''' </summary>
        ''' <param name="AppID">32stellige Applikations-ID</param>
        ''' <param name="messageType">Die Art der Nachricht</param>
        ''' <param name="Modulename">Name des sendenen Moduls</param>
        ''' <param name="randomnummer">Eindeutige Programmnummer</param>
        ''' <param name="messageText">Freier Text der den Inhalt der NAchricht beschreibt</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function SendData(ByVal randomnummer As Integer, ByVal AppID As String, ByVal Modulename As String, ByVal messageType As ReportMessageType, ByVal messageText As String) As Boolean
            Dim sw As New Stopwatch
            Try
                sw.Start()
                If m_statsServer Is Nothing Then
                    m_statsServer = New OnlineReporting.StatisticsReporting()
                    AddHandler m_statsServer.SendApplicationMetricDataCompleted, AddressOf m_statsServer_SendApplicationMetricDataCompleted
                End If
                m_statsServer.SendApplicationMetricDataAsync(Date.Now, Modulename, randomnummer, AppID, My.Application.Info.Version.ToString, MainApplication.ApplicationName, messageType.ToString, messageText, New Object)

            Catch ex As Exception
                MainApplication.getInstance.Log.WriteLog(ex, "OnlineReporting", "Fehler beim senden der Daten") 'TODo: NLS
                Return False
            Finally
                sw.Stop()
                Debug.Print("Statistische Daten an asynchronen Dienst übergeben: " & sw.Elapsed.ToString & " gedauert")

            End Try
            Return True
        End Function

        Private Sub m_statsServer_SendApplicationMetricDataCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
            If e.Error IsNot Nothing Then
                Debug.Print("Statistic Data sent with errors: " & e.Error.Message)
                'System.Net.ServicePointManager.Expect100Continue = false;
            Else
                Debug.Print("Statistic Data Sent.")
            End If

        End Sub


        Friend Function CheckConnection() As Boolean
            Return My.Computer.Network.IsAvailable()
        End Function

        Friend Function Pingserver() As Boolean
            ' Ist manchmal eher unzuverlässig !
            Return True
        End Function

        Friend Sub StartTask()
            ' Dim t As New Threading.Thread


        End Sub


        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            System.Net.ServicePointManager.Expect100Continue = False

            Randomize(Now.Millisecond)
            randomNumber = CInt(60000 * Rnd(Now.Millisecond))
        End Sub

    End Class


    Friend Class statisticsData

        Private m_modulName As String

        Private m_messageText As String

        Private m_eventDateTime As DateTime

        Public Property EventDateTime() As DateTime
            Get
                Return m_eventDateTime
            End Get
            Set(ByVal value As DateTime)
                m_eventDateTime = value
            End Set
        End Property

        Public Property MessageText() As String
            Get
                Return m_messageText
            End Get
            Set(ByVal value As String)
                m_messageText = value
            End Set
        End Property

        Public Property ModulName() As String
            Get
                Return m_modulName
            End Get
            Set(ByVal value As String)
                m_modulName = value
            End Set
        End Property

    End Class


End Namespace