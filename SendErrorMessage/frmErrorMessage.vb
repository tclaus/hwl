Imports System.Text


''' <summary>
''' Stellt den Fehlerbereicht dar
''' </summary>
''' <remarks></remarks>
Friend Class frmErrorMessage

    Private m_exception As System.Exception

    Private m_Handler As MainErrorHandler
    Public Property ErrorHandler() As MainErrorHandler
        Get
            Return m_Handler
        End Get
        Set(ByVal value As MainErrorHandler)
            m_Handler = value

            Me.Exception = value.Currentexception

        End Set
    End Property


    Public Property Exception() As System.Exception
        Get
            Return m_exception
        End Get
        Set(ByVal value As System.Exception)
            m_exception = value

            txtErrorMessage.Text = "Text: " & m_exception.Message & vbCrLf
            txtErrorMessage.Text &= "In Methode: " & m_exception.Source & vbCrLf & vbCrLf
            txtErrorMessage.Text &= New String("-"c, 25) & vbCrLf
            txtErrorMessage.Text &= "Aufruferliste: " & vbCrLf & m_exception.StackTrace & vbCrLf



        End Set
    End Property


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        System.Windows.Forms.Application.Exit()
        Me.Close()

    End Sub

    Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click
        System.Windows.Forms.Application.Restart()

    End Sub

    Private Sub btnSendMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendMessage.Click

        SendMessage()
        btnSendMessage.Enabled = False

    End Sub

    Private Sub AfterSendMessage(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Timer1.Stop()
        waitForm.Close()

        If e.Error IsNot Nothing Then
            'TODO: NLS (Fehler biem Senden der Fehlermeldung)
            Trace.TraceWarning("Fehler beim senden der Nachricht! " & e.Error.ToString)
            ' Alternative anbieten ? 

            Dim msgText As String = MainApplication.getInstance.Languages.GetText("msgCriticalErrorOccuredWhileSending", "Ein Problem ist aufgetreten beim senden der Daten. " & vbCrLf & _
                                                                    "Bitte benachrichtigen Sie unseren Support." & vbCrLf & _
                                                                     "Text der Fehlermeldung:" & vbCrLf)
            Dim msgcaption As String = MainApplication.getInstance.Languages.GetText("headCriticalErrorOccuredWhileSending", "Konnte Fehlerdaten nicht senden")

            MessageBox.Show(msgText & _
                            "'" & e.Error.Message & "'", msgcaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Dim msgText As String = MainApplication.getInstance.Languages.GetText("msgThankYouForSendingErrorMessage", "Vielen Dank für das Senden des Berichtes.")
            Dim msgCaption As String = MainApplication.getInstance.Languages.GetText("msgHeadThanksForSendingErrorMessage", "Bericht gesendet")

            MessageBox.Show(msgText, msgCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

        'Nach dem Senden im Dialog verbleiben; Anwender kann dann "Neustarten" oder "schliessen"
        'System.Windows.Forms.Application.Exit()
        'Me.Close()

    End Sub


    Dim waitForm As New frmWaitForSending

    ''' <summary>
    ''' Sendet die Nachricht an den Webdienst
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SendMessage()

        Try

            Dim exceptionHash As Long = m_Handler.GetExceptionHashID

            System.Net.ServicePointManager.Expect100Continue = False
            Dim SystemInformation As String = Me.ErrorHandler.GetSessionDetails()

            Dim errorMessage As String = SystemInformation & Environment.NewLine & txtErrorMessage.Text



            Dim report As New ErrorReportingService.ErrorReporting
            report.Timeout = 30 * 1000 ' Nicht zu lange warten (in millisekunden)

            ' ich trottel: Hier stets aufpassen, das ich auch den richtigen event anziehe... 
            AddHandler report.SendErrorMessageExUserMessageCompleted, AddressOf AfterSendMessage
            ' Hier das Problem senden und ohne warten zurückkehren
            report.SendErrorMessageExUserMessageAsync(errorMessage, txtMailAddres.Text, txtUserMessage.Text, CInt(exceptionHash Mod Integer.MaxValue), New Object)
            Timer1.Start()

            waitForm.ShowDialog() ' Blockiert diesen Thread.. 
            waitForm.ResumeLayout(True)


        Catch ex As Exception
            waitForm.Hide()
        End Try

    End Sub

    Private Sub frmErrorMessage_HelpButtonClicked(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked

        Dim caption As String = MainApplication.getInstance.Languages.GetText("msgTroubleReports", "Problemberichte")
        Dim message As String = MainApplication.getInstance.Languages.GetText("msgTroubleReportsTest", "Das Programm hatte ein schwerwiegendes Problem und musste beendet werden. Sie können uns aber eine Fehlermeldung senden, mit dessen Hilfe wir versuchen können, das Problem zu beheben. " & vbCrLf & _
                        "In diesem Fehlerbereicht sind keinerlei persönliche Daten enthalten, sondern lediglich technische Eigenschaften, die zu dem Problem geführt haben könnten." & vbCrLf & _
                        "Alternativ können sie uns auch direkt eine e-Mail senden und das Problem schildern.")

        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        ' wenn der Timer abgelaufen ist, bevor die Nachricht gesendet werden konnt, dann stimmt was nicht... 
        AfterSendMessage(Nothing, New System.ComponentModel.AsyncCompletedEventArgs(New Exception("TimeOut"), True, Nothing))

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

    End Sub
End Class