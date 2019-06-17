Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading

Namespace Update
    ''' <summary>
    ''' Stellt einen UpdateManager zum Laden von aktualisierten Programmmodulen zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    Public Class UpdateManager

        ''' <summary>
        ''' Wird ausgelöst, wenn ein Update (update.exe) bereitsteht. 
        ''' Es wird nun immer das Update sofort geladen, und dem Anwender nur die ConfigDatei angezeigt
        ''' </summary>
        ''' <remarks></remarks>
        Public Event UpdateAvailable(ByVal path As String)

        Public Event ChangeLogAvailable(ByVal header As FileHeader)

        ' Pfade für die Release-Version von HWL / PB

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private Const HWLReleasePath As String = "http://claus-software.de/Downloads/"

 

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private AppName As String = ClausSoftware.MainApplication.ApplicationName()
        ''' <summary>
        ''' Enthält den Text der Changelog-datei
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_lastChangelog As String = GetText("mshNoUpdateFoundInWebsite", "Kein Update gefunden")


        Private WithEvents m_timer As New System.Windows.Forms.Timer()

        ''' <summary>
        ''' Ruft die eigene dateiversion ab oder legt diese fest. 
        ''' Format ist x.y.zzzz
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ApplicationVersion() As Version
            Get
                Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetEntryAssembly
                If a IsNot Nothing Then
                    Return a.GetName.Version ' Version der Hauptassembly ermitteln
                Else
                    Return My.Application.Info.Version
                End If

            End Get

        End Property

        ''' <summary>
        ''' Ruft das Erstellungsdaatum der Datei ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ApplicationDate() As System.DateTime
            Get
                Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
                'TODO: Datei Datum auslesen und zurückgeben
                Dim fPath As String = a.Location
                Dim file As System.IO.FileInfo = New System.IO.FileInfo(fPath)
                Dim fDate As Date = file.LastWriteTime

                Return fDate

            End Get
        End Property

        ' Eine erstellbare COM-Klasse muss eine Public Sub New() 
        ' ohne Parameter aufweisen. Andernfalls wird die Klasse 
        ' nicht in der COM-Registrierung registriert und kann nicht 
        ' über CreateObject erstellt werden.
        Public Sub New()
            MyBase.New()

        End Sub

        ''' <summary>
        ''' Wenn wahr, wird ein Update automatisch ausgeführt. Beim setzen der eigenschaft wird eine Tägliche Update-Suche angenommen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property AutoCheckUpdates As Boolean
            Get
                Dim UpdateInterval As String
                UpdateInterval = MainApplication.getInstance.Settings.GetSetting("UpdateCheckInterval", "Update", "Daily")
                ' Die Texte sind nur für die interene Speicherung gedacht
                If UpdateInterval = "Daily" Or UpdateInterval = "Weekly" Then
                    Return True
                Else
                    Return False
                End If

            End Get
            Set(ByVal value As Boolean)
                If value Then
                    MainApplication.getInstance.Settings.SetSetting("UpdateCheckInterval", "Update", "Daily")
                Else
                    MainApplication.getInstance.Settings.SetSetting("UpdateCheckInterval", "Update", "Never")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Startet einen warte-Timer, der den Update-Check verzögert
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub StartTimer()
            m_timer.Interval = 20 * 1000 ' 20 sekunden warten.. 
            m_timer.Start()
        End Sub

        Private Sub Timerelapsed() Handles m_timer.Tick
            m_timer.Stop()
            Dim t As New Threading.Thread(AddressOf StartAutomaticUpdateCheck)
            t.Start()



        End Sub
        ''' <summary>
        ''' Zeigt an, falls der Anwender ein Update durchgeführt hat, bevor das automatische Update gelaufen ist
        ''' </summary>
        ''' <remarks></remarks>
        Private m_UpdateRecentlyChecked As Boolean

        ''' <summary>
        ''' Startet das automatische Update
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub StartAutomaticUpdateCheck()
            If m_UpdateRecentlyChecked Then
                MainApplication.getInstance.log.WriteLog("Auto update rejected, user has already checked for Updates manually")
                Exit Sub
            End If
            MainApplication.getInstance.SendMessage(GetText("msgLookingForUpdates", "Suche nach Updates..."))

            Me.GetLatestChangeLogFile(True)

            '  wenn nach einem Updtae geprüft wude, letzte Prüfung merken
            My.Settings.LastUpdateCheck = Today

            If m_lastChangelog.Length > 0 AndAlso Me.NewUpdateAvailable Then


                Dim GetUpdateDialog As New Update.frmGetUpdate(Me)
                GetUpdateDialog.ShowDialog()
            Else
                MainApplication.getInstance.SendMessage(GetText("msgNonewUpdates", "Keine Aktualisierungen verfügbar."))

            End If

        End Sub

        ''' <summary>
        ''' Enthält das Datum und die Version der Datei im Changelog
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Public Structure FileHeader
            Public FileDate As Date
            Public FileVersion As Version ' im format "1.1.2222"
        End Structure


        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Private m_newChangelog As Boolean
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Private m_changelogheader As FileHeader
        ''' <summary>
        ''' Initialisiert das Teil
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize()
            modmain.InitializeApplication()
        End Sub

        ''' <summary>
        ''' Liest die jeweilige Konfig-Datei aus und gibt eine Messagebox aus, wenn eine neuere Datei gefunden wurde.
        ''' Konnte eine Changelog geladen werden, dann wird diese lokal gesichert
        ''' </summary>
        ''' <param name="internalCheck">Wenn Wahr, werden Warnmeldungen niht als Messagebox ausgegeben</param>
        ''' <remarks></remarks>
        Public Function GetLatestChangeLogFile(internalCheck As Boolean) As Boolean
            Static atWork As Boolean
            If atWork Then Return False
            atWork = True

            m_UpdateRecentlyChecked = True

            Try

                SyncLock Me
                    Dim changelogURL As String

                    changelogURL = GetChangeLogPath()

                    Dim tmpFile As String = System.IO.Path.GetTempPath
                    tmpFile = Path.Combine(tmpFile, "Changelog.txt")

                    If File.Exists(tmpFile) Then File.Delete(tmpFile)

                    'IMPORTANT: Updatecheck hier auch auf Dev-Versionen erweitertn
                    ' SHIFT - Taste bei Update-Check gedrückt; dies wird gemerkt, bis der Vorgang durch ist.


                    My.Computer.Network.DownloadFile(changelogURL, tmpFile)

                    m_lastChangelog = My.Computer.FileSystem.ReadAllText(tmpFile, System.Text.Encoding.UTF7)

                    System.IO.File.Delete(tmpFile)
                    m_changelogheader = GetChangelogHeader(m_lastChangelog)
                End SyncLock

                m_newChangelog = True
                RaiseEvent ChangeLogAvailable(m_changelogheader)
                Return True

            Catch ex As WebException
                m_lastChangelog = ""
                MainApplication.getInstance.log.WriteLog(ex, "GettingUpdateData", "Error getting Update File")
                If Not internalCheck Then
                    MessageBox.Show(GetText("msgTextNetworkErrorGettingUpdateFile", "Ein Fehler ist aufgetreten beim holen der Aktualisierung. /n Kontrollieren Sie Ihre Netzwerkverbindung und Proxy Einstellungen.") & vbCrLf &
                                     ex.Message, GetText("msgHeaderNetworkErrorGettingUpdateFile", "Aktualisierungsdaten konnten nicht geholt werden"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Catch ex As Exception
                m_lastChangelog = ""
                MainApplication.getInstance.log.WriteLog(ex, "GettingUpdateData", "Error getting Update File")
                If Not internalCheck Then
                    MessageBox.Show(GetText("msgTextNetworkCommonErrorGettingUpdateFile", "Ein Problem  ist aufgetreten beim holen der Aktualisierung. /n {0}", ex.Message), GetText("msgHeaderNetworkErrorGettingUpdateFile", "Aktualisierungsdaten konnten nicht geholt werden"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            Finally
                atWork = False
            End Try
            Return False
        End Function

        ''' <summary>
        ''' Zeigt an, ob ein neues Update bereitsteht
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property NewUpdateAvailable() As Boolean
            Get

                If Not m_newChangelog Then ' noch kein Update geladen
                    GetLatestChangeLogFile(False)
                End If

                ' Prüfe nun die Versionsnummer; bei gleichheit das Datum

                '  wenn nach einem Updtae geprüft wude, letzte Prüfung merken
                My.Settings.LastUpdateCheck = Today


                Dim RetValue As Boolean
                'IMPORTANT: Auf künftige Versionsnummern achten 
                If Me.ApplicationVersion < Me.ChangeLogHeader.FileVersion Then

                    MainApplication.getInstance.log.WriteLog("Set UpdateAvail  (True) Reason: Appversion is lower than changelog reports. ")
                    RetValue = True
                    Return RetValue
                End If

                ' (Unnötig) das Datum prüfen
                If Me.ApplicationDate < Me.ChangeLogHeader.FileDate Then
                    MainApplication.getInstance.log.WriteLog("Set UpdateAvail  (True) Reason: appdate is too old")

                    RetValue = True
                    Return RetValue
                End If


                Return RetValue

            End Get
        End Property

        ''' <summary>
        ''' Sofern die chackforUpdates-Routiene aufgerufen wurde, steht hier die Header-Info des Changelogs bereit
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ChangeLogHeader() As FileHeader
            Get
                Return m_changelogheader
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Text der Changelog-Datei ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ChangeLogText() As String
            Get
                Return m_lastChangelog
            End Get
        End Property

        ''' <summary>
        ''' Läd die angegebene datei und feuert ein event, wenn Update geladen wurde
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DownloadUpdateFileAsync()
            Dim url As String = Me.DownloadBasePath

            Dim tmppath As String = System.IO.Path.GetTempPath

            ' Die Dateinamen ermitteln
            'PB2-Update.exe
            ' HWL2-Update.exe
            Dim filename As String
            If ClausSoftware.MainApplication.ApplicationName.StartsWith("HWL", StringComparison.InvariantCultureIgnoreCase) Then
                filename = "hwl2.5-update.exe"
            Else
                filename = "pb2-update.exe"
            End If

            url &= filename.ToLower

            tmppath = System.IO.Path.Combine(tmppath, filename)

            If File.Exists(tmppath) Then
                File.Delete(tmppath)
            End If
            Dim retrieve As New WebRetrieve

            retrieve.StartDownload(url, tmppath)

            RaiseEvent UpdateAvailable(tmppath)

        End Sub

        ''' <summary>
        ''' Ruft aus dem Changelog-Text die erste und zweite Zeile ab. 
        ''' Dies sind Datum und Version
        ''' </summary>
        ''' <param name="changelogText">Der vollständig gelesene Änderungslog</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetChangelogHeader(ByVal changelogText As String) As FileHeader
            ' Version ist immer in der ersten Zeile
            ' Datum ist in der zweiten Zeile, im deutschem Format: TT.MM.YYYY
            Dim sr As New System.IO.StringReader(changelogText)

            ' Wichtig: Version  in der ersten Zeile, dann das Datum
            Dim versionline As String = sr.ReadLine
            Dim dateline As String = sr.ReadLine
            ' Bei der Beta-Version ändert sich nur das Datum, nicht die Version 

            Dim header As New FileHeader

            If versionline.ToLower.Contains("version") Then versionline = versionline.Trim.Substring(8)

            versionline &= ".0" ' noh eine NUll anhängen 

            header.FileVersion = New Version(versionline)
            Dim p As IFormatProvider = System.Globalization.CultureInfo.GetCultureInfo("DE-DE")


            Date.TryParseExact(dateline, New String() {"d.M.yyyy", "dd.M.yyyy", "dd.MM.yyyy"}, p, Globalization.DateTimeStyles.None, header.FileDate)

            Return header

        End Function

        ''' <summary>
        ''' Ist true, wenn ein neues Changelog bereitsteht
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property NewChangelogAvailable() As Boolean
            Get
                Return m_newChangelog
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Basispfad ab, der die changelog-datei und die Setup-Dateien enthält
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Private ReadOnly Property DownloadBasePath() As String
            Get
                Return HWLReleasePath
            End Get
        End Property



        ''' <summary>
        ''' Ruft den Pfad für die Changelog-Datei ab. enthält auch den Dateinamen
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Private Function GetChangeLogPath() As String
            Dim changelogPath As String = DownloadBasePath()



            Return changelogPath & "changelog.txt"

        End Function



    End Class

    ''' <summary>
    ''' Läd die Datei herunter und startet diese
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class WebRetrieve
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Delegate Sub StartDownloadDelegate(ByVal url As String, ByVal path As String)
        Private m_file As String

        Dim frm As New frmDownloadProgress

        ''' <summary>
        ''' Startet den Download Async
        ''' </summary>
        ''' <param name="url"></param>
        ''' <param name="file"></param>
        ''' <remarks></remarks>
        Public Sub StartDownload(ByVal url As String, ByVal file As String)
            m_file = file

            frm.lblDownloadProgress.Text = "0Kb"
            frm.Show()
            frm.Refresh()

            Dim myDel As New StartDownloadDelegate(AddressOf startDownloadAsync)
            Dim res As IAsyncResult = Nothing
            Dim cb As New AsyncCallback(AddressOf DownloadFinished)

            res = myDel.BeginInvoke(url, file, cb, Nothing)


        End Sub

        ''' <summary>
        ''' wird aufgerufen, nachdem der Download beendet ist.
        ''' </summary>
        ''' <param name="o"></param>
        ''' <remarks></remarks>
        Private Sub DownloadFinished(ByVal o As Object)
            If TypeOf o Is IAsyncResult Then
                If CType(o, IAsyncResult).IsCompleted Then

                    Try

                        MainApplication.getInstance.log.WriteLog("Try to start Update from : " & m_file, " -Update")

                        Process.Start(m_file)
                        MainApplication.getInstance.CloseConnection()
                        System.Windows.Forms.Application.Exit()

                    Catch ex As FileNotFoundException
                        'TODO: NLS
                        MessageBox.Show("Die heruntergeladene Datei konnte nicht gefunden werden", "Datei nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error)


                    Catch ex As Exception
                        'TODO: NLS
                        MessageBox.Show("Ein Fehler beim Starten des Updates ist aufgetreten:" & vbCrLf & _
                                        ex.Message, "Fehler beim starten des Updates", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If
            End If

        End Sub

        ''' <summary>
        ''' Startet den Download
        ''' </summary>
        ''' <param name="url"></param>
        ''' <param name="file"></param>
        ''' <remarks></remarks>
        Private Sub startDownloadAsync(ByVal url As String, ByVal file As String)

            Dim wr As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
            Dim str As Stream = ws.GetResponseStream()

            Dim filesize As Long = ws.ContentLength



            Dim inBuf(10000) As Byte
            Dim bytesRead As Integer = 0
            Dim fstr As New FileStream(file, FileMode.OpenOrCreate, FileAccess.Write)
            Dim n As Integer

            Do


                n = str.Read(inBuf, 0, inBuf.Length)
                fstr.Write(inBuf, 0, n)

                If n = 0 Then
                    str.Close()
                    fstr.Close() 'Download beendet


                    Exit Do
                End If
                bytesRead += n

                frm.SetText(bytesRead \ 1024 & " Kb / " & filesize \ 1024 & " Kb")
                frm.SetProgressBar((CInt(100 * bytesRead / filesize)))


            Loop While n > 0
            If frm.InvokeRequired Then
                Dim closedele As New MethodInvoker(AddressOf frm.Close)

                frm.Invoke(closedele)
            Else
                frm.Close()
            End If


        End Sub 'Main
    End Class 'WebRetrieve
End Namespace