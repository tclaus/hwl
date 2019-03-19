Namespace Update
    ''' <summary>
    ''' stellt einen dialog bereit, der das Änderungsprotokoll vom server enthält und einen Download ermöglichgt
    ''' </summary>
    ''' <remarks></remarks>
    Public Class frmGetUpdate

        Private m_update As Update.UpdateManager

        Public Sub New(ByVal update As Update.UpdateManager)
            Me.InitializeComponent()
            m_update = update

        End Sub
        Friend Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub frmGetUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtChangelog.Text = m_update.ChangeLogText
            txtChangelog.DeselectAll()

            btnInstall.Enabled = m_update.NewUpdateAvailable

            chkAutoCheckForUpdates.Checked = m_update.AutoCheckUpdates

        End Sub

        Private Sub btnInstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInstall.Click
            Try
                m_update.DownloadUpdateFileAsync()
                ' hier nun installieren = > Applikation beenden
            Catch
            End Try

        End Sub

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub chkAutoCheckForUpdates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoCheckForUpdates.CheckedChanged
            m_update.AutoCheckUpdates = chkAutoCheckForUpdates.Checked

        End Sub
    End Class

End Namespace
