
Imports System.Windows.Forms
Imports System.IO


Namespace Tools
    ''' <summary>
    ''' In der Folge der schwere des Fehlers
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum LogSeverity
        Critical
        ErrorMessage
        Warning
        Information
        Verbose
    End Enum

    ''' <summary>
    ''' Stellt eine Behandlung für Protokolldaten zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    Public Class LogHandling
        Private m_AppName As String


        ''' <summary>
        ''' Pfad zur Protokolldatei
        ''' </summary>
        ''' <remarks></remarks>
        Private m_logPath As String
        Private m_baseLogfile As String
        Private m_oldLogfile As String


        Public Sub New()

            m_AppName = MainApplication.ApplicationName
            m_logPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), MainApplication.ApplicationName & "\Log")   ' All Users   => Sprachen unter "Alle Benutzer" anlegen und nutzen
            m_baseLogfile = Path.Combine(m_logPath, m_AppName & ".log")
            m_oldLogfile = Path.Combine(m_logPath, m_AppName & "_old.log") ' Altes logfile erstellen

            If Not System.IO.Directory.Exists(m_logPath) Then  'Pfad anlegen, falls nicht existiert
                System.IO.Directory.CreateDirectory(m_logPath)
            End If

            'Sehr grosse Logfiles wegräumen
            If File.Exists(m_baseLogfile) Then
                Dim currentFile As New FileInfo(m_baseLogfile)
                Dim size As Integer = CInt(currentFile.Length \ 1024) ' Grösse in Kb
                If size > 5000 Then ' Ab dieser grösse das log verschieben

                    If File.Exists(m_oldLogfile) Then File.Delete(m_oldLogfile) ' Das alte alte File löschen

                    currentFile.MoveTo(m_oldLogfile) ' Das aktuelle dahineinkopieren
                End If
            End If



            StartLogging()
        End Sub

        ''' <summary>
        ''' Ruft den Pfad zur aktuellen Logdatei ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LogFilePath As String
            Get
                Return m_baseLogfile
            End Get
        End Property

        '''<summary>
        ''' Schreibt eine Fehlersituation in das lokale Logbuch
        ''' </summary>
        ''' <param name="ex">Die Ausnahme, die zu dem Fehler geführt hat</param>
        ''' <param name="category">Name des auslösendes Moduls</param>
        ''' <param name="caption">Letzte bekannte Aktion</param>
        Public Sub WriteLog(ByVal ex As Exception, ByVal category As String, ByVal caption As String)
            WriteLog(ex, category, caption, "")
        End Sub
        ''' <summary>
        ''' Schreibt eine Fehlersituation in das lokale Logbuch
        ''' </summary>
        ''' <param name="category">Name des auslösendes Moduls</param>
        ''' <param name="caption">Letzte bekannte Aktion</param>
        ''' <remarks></remarks>
        Public Sub WriteLog(ByVal category As String, ByVal caption As String)
            WriteLog(ClausSoftware.Tools.LogSeverity.Information, category, caption, "")
        End Sub

        ''' <summary>
        ''' Schreibt den Logeintrag einer Ausnahme. 
        ''' Diese sind immer als 'ErrorMessage' eingestuft
        ''' </summary>
        ''' <param name="ex"></param>
        ''' <param name="category">Name des auslösendes Moduls</param>
        ''' <param name="caption">Letzte bekannte Aktion</param>
        ''' <param name="description">Weitere hinweise zur Fehlersituation</param>
        ''' <remarks></remarks>
        Public Sub WriteLog(ByVal ex As Exception, ByVal category As String, ByVal caption As String, ByVal description As String)
            Dim exceptionText As String

            exceptionText = GetInnerExceptionMessages(ex)

            WriteLog(LogSeverity.ErrorMessage, category, caption, exceptionText & vbCrLf & description)

        End Sub

        ''' <summary>
        ''' Ruft die Inneren Ausnahmen ab
        ''' </summary>
        ''' <param name="ex"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetInnerExceptionMessages(ex As Exception) As String
            Dim txt As String
            txt = ex.ToString
            If ex.InnerException IsNot Nothing Then
                txt &= "Inner exception: & " & GetInnerExceptionMessages(ex.InnerException)
            End If

            Return txt

        End Function


        ''' <summary>
        ''' Schreibt eine normale Information in das Anwednungsprotokoll
        ''' </summary>
        ''' <param name="caption"></param>
        ''' <remarks></remarks>
        Public Sub WriteLog(ByVal caption As String)
            WriteLog(LogSeverity.Information, caption)
        End Sub

        ''' <summary>
        ''' Schreibt die Meldung in einen Meldungsspeicher (Textdatei / Logfile).
        ''' </summary>
        Public Sub WriteLog(ByVal severity As LogSeverity, ByVal caption As String)
            WriteLog(severity, String.Empty, caption, String.Empty)
        End Sub

        ''' <summary>
        ''' Schreibt die Meldung in einen Meldungsspeicher (Textdatei / Logfile).
        ''' </summary>
        ''' <param name="severity"></param>
        ''' <param name="category"></param>
        ''' <param name="caption"></param>
        ''' <param name="description"></param>
        ''' <remarks>Diese Methode ist Threadsicher</remarks>
        Public Sub WriteLog(ByVal severity As LogSeverity, ByVal category As String, ByVal caption As String, ByVal description As String)
            SyncLock Me
                If severity = LogSeverity.ErrorMessage Then

                End If

                caption = caption.Replace(vbCrLf, "\n")
                description = description.Replace(vbCrLf, "\n")

                Dim logText As String = Now & " " & "(" & severity.ToString & ") " & caption & description
                Debug.Print(logText)

                Try
                    File.AppendAllText(m_baseLogfile, logText & vbCrLf)

                Catch ex As Exception
                    Debug.Print("ERROR: Writelog, " & ex.Message)
                End Try
            End SyncLock

        End Sub

        ''' <summary>
        ''' Initialisiert das Aufschreiben der Protokolldatei
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub StartLogging()
            WriteLog("")
            WriteLog("-- Neuer Programmstart...  Version:" & My.Application.Info.Version.ToString)

        End Sub

        ''' <summary>
        ''' TODO: Sendet das Log zum Hersteller (webinterface)
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SendLog()


            'Unterscheiden, wenn der Anwender senden möchte, ist das Teil bereits abgeschmiert.. 
            'TODO: Hier fehlt noch etwas logik.. 


        End Sub

        Public Sub EndLogging()


        End Sub

    End Class

End Namespace