Imports ClausSoftware.Data

''' <summary>
''' Zeigt ein Fenster an, das den Fortschritt des Kopieren von Dateien anzeigt
''' </summary>
''' <remarks></remarks>
Public Class frmWaitForFileCopy


    Dim m_filelist As String()
    Dim m_document As ClausSoftware.Data.IAttachments

    Dim m_backgroundworker As New BackgroundWorker

    ''' <summary>
    ''' Ruft das Zieldokument ab oder legt dies fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TargetDocument As IAttachments
        Get
            Return m_document
        End Get
        Set(value As IAttachments)
            m_document = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft die Dateiliste ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property FileList As String()
        Get
            Return m_filelist
        End Get
        Set(value As String())
            m_filelist = value
        End Set
    End Property

    ''' <summary>
    ''' Überträgt die interen Dateiliste an die Datenbank
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub AddFileToDocument(ByVal filellist As String())
        'Debug.Print("Füge: " & filename & " hinzu")
        Dim sw As New Stopwatch
        sw.Start()

        Dim counter As Integer = 1
        Using session As DevExpress.Xpo.Session = m_application.GetNewSession

            For Each filename As String In filellist
                Me.UseWaitCursor = True
                System.Windows.Forms.Application.DoEvents()

                Dim f As New System.IO.FileInfo(filename)
                Dim orgfilesize As Long = f.Length

                Debug.Print("Übertrage: " & filename)

                m_backgroundworker.ReportProgress(counter, filename)


                Dim attachment As New ClausSoftware.Kernel.Attachment(session)
                attachment.SetFile(filename)

                m_document.AttachmentLinks.Add(m_document.ReplikID, attachment)

                ' !! Der Anhang wird durch Hinzufügen der Links bereits gespeichert!

                sw.Stop()
                Debug.Print("Datei:" & filename & ":" & sw.Elapsed.ToString & "(" & Math.Round((orgfilesize / 1024) / sw.Elapsed.Seconds, 2) & "Kb/s)")
                counter += 1

            Next

            m_document.AttachmentLinks.Save()

        End Using


    End Sub



    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse und überträgt die angegenene Dateiliste an das angegenene Dokument
    ''' </summary>
    ''' <param name="targetDocument"></param>
    ''' <param name="filelist"></param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal targetDocument As ClausSoftware.Data.IAttachments, ByVal filelist As String())
        Me.New()

        m_filelist = filelist
        m_document = targetDocument


    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz der Klasse
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Backgroundworker, damit diese Oberfläche noch arbeiten kann
        AddHandler m_backgroundworker.DoWork, AddressOf Startwork
        AddHandler m_backgroundworker.RunWorkerCompleted, AddressOf CompletedWork
        AddHandler m_backgroundworker.ProgressChanged, AddressOf ProgressChanged

        m_backgroundworker.WorkerReportsProgress = True

    End Sub

    Public Sub StartWorking()
        Me.LoadingCircle1.Active = True

        m_backgroundworker.RunWorkerAsync()
    End Sub


    ''' <summary>
    ''' Startet die Aktion. Rückkehr erst nach ende der Aktion
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Startwork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)        
        AddFileToDocument(m_filelist)
    End Sub

    Private Sub ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        Try
            lblFile.Text = e.ProgressPercentage & "/" & m_filelist.Length & "  " & System.IO.Path.GetFileName(CStr(e.UserState))
            lblFile.Refresh()
        Catch
        End Try
    End Sub

    Private Sub CompletedWork(sender As Object, e As RunWorkerCompletedEventArgs)
        Me.LoadingCircle1.Active = False
        Me.Close()
    End Sub


    ''' <summary>
    ''' Nach der Anzeige mit dem kopieren beginnen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmWaitForFileCopy_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        StartWorking()
    End Sub
End Class