
''' <summary>
''' Stellt das Fromular dar, das weitere Addons anzeigen und starten kann
''' </summary>
''' <remarks></remarks>
Public Class frmImportExportManager


    Private m_addondowbloadTarget As String = "http://rechnungen-schreiben.de/?page_id=191" 'TODO: Auch Addins anbieten

    Private Sub frmImportExportManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Sprachen der Oberfläche setzen
        m_application.Languages.SetTextOnControl(Me)

        lstAddIns.DataSource = m_application.AddIns.AddIns
        lstAddIns.DisplayMember = "DisplayName"

    End Sub

    Private Sub lstAddIns_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAddIns.SelectedIndexChanged
        Dim item As AddIns.IImportAddIn = TryCast(lstAddIns.SelectedItem, AddIns.IImportAddIn)

        If item IsNot Nothing Then
            lblAddInLongDescription.Text = item.LongDescription
        End If

    End Sub

    Private Sub grpConnectors_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles grpConnectors.Paint

    End Sub

    Private Sub lstAddIns_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAddIns.MouseDoubleClick
        StartSelectedAddIn()
    End Sub

    Private Sub StartSelectedAddIn()
        Dim item As AddIns.IImportAddIn = Nothing
        Try
            item = TryCast(lstAddIns.SelectedItem, AddIns.IImportAddIn)

            If item IsNot Nothing Then
                item.Show() 'TODO: später in einem anderem Thread starten? 
            End If
        Catch ex As Exception
            If item IsNot Nothing Then
                m_application.Log.WriteLog(Tools.LogSeverity.Critical, "ERROR Starting Addin", "Error while Starting Addin '" & item.DisplayName & "'", ex.Message)
            End If
            MessageBox.Show("Text der Fehlermeldung: " & vbCrLf & ex.Message, "Fehler beim Aufrufen des Addins", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

    End Sub

    Private Sub btnStartConnector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartConnector.Click
        StartSelectedAddIn()
    End Sub


    Private Sub lblGoToAddInDownloadSite_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblGoToAddInDownloadSite.MouseClick
        Process.Start(m_addondowbloadTarget)
    End Sub
End Class