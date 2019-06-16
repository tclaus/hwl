Option Strict On
Option Explicit On
Namespace Update

    Public Class frmDownloadProgress

        Private Delegate Sub SetTextDelegate(ByVal text As String)
        Private Delegate Sub SetProgressBarDelegate(ByVal position As Integer)
        Private ProgressBarDele As New SetProgressBarDelegate(AddressOf SetProgressBar)
        Private TextDele As New SetTextDelegate(AddressOf SetText)

        ''' <summary>
        ''' setzt den Fotschrittsbalken Threadsicher
        ''' </summary>
        ''' <param name="position"></param>
        ''' <remarks></remarks>
        Public Sub SetProgressBar(ByVal position As Object)
            If ProgressBarControl1.InvokeRequired Then
                ProgressBarControl1.Invoke(ProgressBarDele, New Object() {position})
                Exit Sub
            Else
                ProgressBarControl1.Position = CInt(position)
                'ProgressBarControl1.Refresh()
            End If

        End Sub

        ''' <summary>
        ''' Setzt den Text threadsicher
        ''' </summary>
        ''' <param name="text"></param>
        ''' <remarks></remarks>
        Public Sub SetText(ByVal text As Object)
            If lblDownloadProgress.InvokeRequired Then
                lblDownloadProgress.Invoke(TextDele, New Object() {text})
                Exit Sub
            Else
                lblDownloadProgress.Text = CStr(text)
                'lblDownloadProgress.Refresh()
            End If

        End Sub

        Public Sub New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()

            ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.


        End Sub

        Private Sub frmDownloadProgress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            MainApplication.getInstance.Languages.SetTextOnControl(Me)

        End Sub
    End Class

End Namespace
