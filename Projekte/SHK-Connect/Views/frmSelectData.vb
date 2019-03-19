
''' <summary>
''' Zeigt Details zu einer Firma an
''' </summary>
''' <remarks></remarks>
Public Class frmSelectData

    
    Private WithEvents m_companySpecialInfoMnager As New SpecialInfo()

    ''' <summary>
    ''' >Das ist die LIste der ausgewählten Links der Unternehmen
    ''' </summary>
    ''' <remarks></remarks>
    Private m_processLinkList As New List(Of ProcessLink)


    ''' <summary>
    ''' Diese Liste soll eingelesen werden.
    ''' Es sollen mehrere Dateien unterschiedlicher Unternehmen geladen werden können
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared m_linksToLoad As New List(Of ProcessLink)

    Private m_sourceLinkList As New List(Of ProcessLink)

    Public ReadOnly Property SourcesLinkList() As List(Of ProcessLink)
        Get
            Return m_sourceLinkList
        End Get
    
    End Property



    Private Sub m_companySpecialInfoMnager_StatusMessage(sender As Object, e As StatusMessageEventArg) Handles m_companySpecialInfoMnager.StatusMessage
        lblStatus.Text = e.Statustext

    End Sub

    Private Sub frmSelectData_Load(sender As Object, e As System.EventArgs) Handles Me.Load
     



    End Sub

    Private Sub grvFileList_FocusedRowChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvFileList.FocusedRowChanged
        Dim link As ProcessLink = TryCast(grvFileList.GetRow(e.FocusedRowHandle), ProcessLink)

        If link IsNot Nothing Then
            lblLinkChangeNotes.Text = link.ChangeNotes
        Else
            lblLinkChangeNotes.Text = ""
        End If


    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        AddSelectedLinks()
    End Sub

    ''' <summary>
    ''' Fügt die markierten Links zu der Auswahl hinzu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddSelectedLinks()
        If grvFileList.GetSelectedRows.Length > 0 Then
            For Each rowID As Integer In grvFileList.GetSelectedRows
                Dim link As ProcessLink = CType(grvFileList.GetRow(rowID), ProcessLink)

                If Not m_linksToLoad.Contains(link) Then
                    m_linksToLoad.Add(link)
                End If

            Next

            grdTargetLinkList.RefreshDataSource()
            grvTargetLinkList.RefreshData()

        End If
    End Sub

    Private Sub RemoveSelectedFiles()
        Dim lst As New List(Of Object)


        For Each itemID As Integer In grvTargetLinkList.GetSelectedRows
            lst.Add(grvTargetLinkList.GetRow(itemID))
        Next

        For Each item As ProcessLink In lst
            m_linksToLoad.Remove(item)
        Next

        grvTargetLinkList.RefreshData()

    End Sub

    Private m_tmpFileList As New List(Of String)

    Private Sub LoadFilesFromLinks()
        LoadFilesFromLinks(String.Empty, String.Empty)
    End Sub

    ''' <summary>
    ''' Startet den download der Dateien 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadFilesFromLinks(username As String, password As String)

        Dim tmpFolder As String
        m_tmpFileList.Clear()

        For Each item As ProcessLink In m_linksToLoad
            Try
                Debug.Print("Laden Datei von: " & item.CompanyName)
                Debug.Print(" von URL: " & item.URL)


                If item.Authenticode = de.shk_connect.shkgh2.Authentifizierungsmethode.HTTPAUTH Then
                    If String.IsNullOrEmpty(username) Then
                        Using frm As New frmHTTPDAuth
                            frm.HTTPCompanyName = item.CompanyName

                            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                                username = frm.UserName
                                password = frm.Password

                            Else
                                ' Abbrechen lassen
                                Continue For
                            End If

                        End Using
                    End If
                End If

                ' Tip: Buderus läuft
                tmpFolder = System.IO.Path.GetTempPath

                Dim targetFilename As String = GetFilenameFromURL(item.URL)

                Dim fulPath As String = System.IO.Path.Combine(tmpFolder, targetFilename)

                My.Computer.Network.DownloadFile(item.URL, fulPath, String.Empty, String.Empty, True, 250, True)
                Debug.Print("Datei gespeichert unter: " & fulPath)

                m_tmpFileList.Add(fulPath) ' TODO: Temp-Ordner auch wieder wegräumen !

                'Dim  zip As ICSharpCode.SharpZipLib.Zip.

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Fehler beim Laden der Datei von: " & item.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Next

        ' den Ordner öffnen
        If Not String.IsNullOrEmpty(tmpFolder) Then
            Dim p As New ProcessStartInfo
            p.Arguments = "/e,/select,"

            For Each item As String In m_tmpFileList
                p.Arguments &= String.Format("""{0}"",", item)
            Next
            p.Arguments = p.Arguments.Trim(","c)
            p.FileName = "explorer.exe"
            Process.Start(p)

        End If

        ' Entzippen 
        For Each file As String In m_tmpFileList
            Dim targetDir As String = UnzipFiles(file)

            StartDatanormImport(targetDir)
        Next

        ' 

    End Sub


    Private m_ics As ICSharpCode.SharpZipLib.Zip.FastZip

    ''' <summary>
    ''' Ruft den entzipper auf
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property ics As ICSharpCode.SharpZipLib.Zip.FastZip
        Get
            If m_ics Is Nothing Then
                m_ics = New ICSharpCode.SharpZipLib.Zip.FastZip
            End If
            Return m_ics
        End Get
    End Property

    ''' <summary>
    ''' Entpackt die angegebene Datei, sofern diese ein ZIP ist und gibt den Zielordner wieder zurück
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UnzipFiles(filename As String) As String
        Dim targetDir As String

        Try
            Dim orgFilename As String = System.IO.Path.GetFileNameWithoutExtension(filename)
            Dim rootTargetDir As String = System.IO.Path.GetDirectoryName(filename)

            targetDir = System.IO.Path.Combine(rootTargetDir, orgFilename)

            ' im selben Verzeichnis legen und den ZIP-Namen als Dateinamen angeben
            ics.ExtractZip(filename, targetDir, "")


        Catch ex As Exception
            Debug.Print("Fehler beim entzippen! " & ex.Message)
        End Try
        Return targetDir

    End Function

    ''' <summary>
    ''' Startet den Datenorm-Import
    ''' </summary>
    ''' <param name="targetDirectory"></param>
    ''' <remarks></remarks>
    Private Sub StartDatanormImport(targetDirectory As String)
        Dim dtn As New DatanormImportController()

        Dim filesList As String() = System.IO.Directory.GetFiles(targetDirectory)

        dtn.FileList.Clear()
        dtn.FileList.AddRange(filesList)

        dtn.StartImport()

    End Sub

    ''' <summary>
    ''' Holt aus einer kompeltten URl den Dateinamen ab
    ''' </summary>
    ''' <param name="url"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFilenameFromURL(url As String) As String
        Dim filename As String

        filename = url.Substring(url.LastIndexOf("/"c) + 1)


        Return filename
    End Function


    Private Sub btnstartDatanormImport_Click(sender As System.Object, e As System.EventArgs) Handles btnstartDatanormImport.Click
        LoadFilesFromLinks()
    End Sub

    Private Sub frmSelectData_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        grdFileList.DataSource = Me.SourcesLinkList

        grdTargetLinkList.DataSource = m_linksToLoad
    End Sub

    Private Sub btnClearList_Click(sender As System.Object, e As System.EventArgs) Handles btnClearList.Click
        m_linksToLoad.Clear()
        grvTargetLinkList.RefreshData()
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        RemoveSelectedFiles()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lblTargetDir_Click(sender As System.Object, e As System.EventArgs) Handles lblTargetDir.Click
        Try
            ' Versucht, das Directory zu öffnen
            If IO.Directory.Exists(lblTargetDir.Text) Then
                Process.Start(lblTargetDir.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grvTargetLinkList_CustomDrawCell(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grvTargetLinkList.CustomDrawCell
        ' Zeichnet kein oder ein "Downloaded" - Symbol
        ' Wird geladen => Geladen 
        If e.Column Is colLoaded Then
            e.Graphics.DrawImage(My.Resources.Refresh_16x16, e.Bounds)
            e.Handled = True
        End If


    End Sub
End Class

