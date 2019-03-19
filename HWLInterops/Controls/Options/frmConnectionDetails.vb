''' <summary>
''' Stellt einen Dialog bereit, in dem Details einer Datenbankverbindung angegeben werden können
''' </summary>
''' <remarks></remarks>
Public Class frmConnectionDetails

    Private m_currentConnection As ClausSoftware.Tools.Connection
    Private m_testOK As Boolean


    Private m_isNewConnection As Boolean

    Public Property IsNewConnection() As Boolean
        Get
            Return m_isNewConnection
        End Get
        Set(ByVal value As Boolean)
            m_isNewConnection = value
        End Set
    End Property

    ''' <summary>
    ''' Enthält den Datenbankpfad
    ''' </summary>
    ''' <remarks></remarks>
    Private m_dbPath As String

    ''' <summary>
    ''' Enthält den Sicherungspfad
    ''' </summary>
    ''' <remarks></remarks>
    Private m_dbBackupPath As String


    ''' <summary>
    ''' Ruft die aktuelle Verbindung ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property Connection() As ClausSoftware.Tools.Connection
        Get
            Return m_currentConnection
        End Get
        Set(ByVal value As ClausSoftware.Tools.Connection)
            m_currentConnection = value
            If value.IsNew Then
                tabDatabaseFile.PageVisible = True
                tabDatabaseServer.PageVisible = True

            Else
                If value.Servertype = Tools.enumServerType.Access Then
                    tabDatabaseFile.PageVisible = True
                    tabDatabaseServer.PageVisible = False
                Else
                    tabDatabaseServer.PageVisible = True
                    tabDatabaseFile.PageVisible = False
                End If

            End If
        End Set
    End Property

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Nun die Daten wieder in die Verbindung kopieren
        CopyData()
        Me.Close()
    End Sub

    ''' <summary>
    ''' Kopiert die Daten aus der Eingabemaske in das aktuelle Verbindungs-Objekt
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CopyData()
        Dim sourceData As ClausSoftware.Tools.Connection = GetConnectionData()
        With m_currentConnection
            .AliasName = sourceData.AliasName
            .Database = sourceData.Database
            .Password = sourceData.Password
            .Path = sourceData.Path
            .ServerHostName = sourceData.ServerHostName
            .Servertype = sourceData.Servertype
            .Username = sourceData.Username
            .IsDefault = sourceData.IsDefault
            .BackupPath = sourceData.BackupPath
        End With

    End Sub

    ''' <summary>
    ''' Ruft ein Verbindungsobjekt ab, das die aktuellen Daten enthält
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetConnectionData() As ClausSoftware.Tools.Connection
        Dim connectionData As New ClausSoftware.Tools.Connection()

        connectionData.IsDefault = chkAsdefault.Checked
        connectionData.AliasName = txtConnectionNameServer.Text

        If TabControlConnections.SelectedTabPage Is tabDatabaseServer Then

            connectionData.Database = txtConnectionDatabaseName.Text
            connectionData.Password = txtConnectionUserPassword.Text
            connectionData.ServerHostName = txtConnectionServerName.Text
            connectionData.Servertype = ClausSoftware.Tools.enumServerType.MySQL
            connectionData.Username = txtConnectionUsername.Text
            connectionData.Path = ""

        Else
            connectionData.Path = m_dbPath
            connectionData.BackupPath = m_dbBackupPath
            ' Passwort ermittelt sich aus der HWL-ID die aus dem Pfad gelesen wird
            connectionData.Database = ""
            connectionData.Password = ""
            connectionData.ServerHostName = ""
            connectionData.Servertype = ClausSoftware.Tools.enumServerType.Access
            connectionData.Username = ""


        End If

        Return connectionData

    End Function

    Private Sub btnGetPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPath.Click
        SetDataPath()

    End Sub

    Private Sub SetDataPath()
        Try
            Dim pathdlg As New Vista_Api.OpenFileDialog
            pathdlg.CheckFileExists = True
            pathdlg.Filter = ClausSoftware.mainApplication.ApplicationName & " Datenbankdatei (daten.mdb)|daten.mdb"
            pathdlg.Multiselect = False

            Dim tmpPath As String = m_dbPath


            If Not System.IO.Directory.Exists(tmpPath) Then
                tmpPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
            End If

            pathdlg.InitialDirectory = tmpPath
            pathdlg.FileName = tmpPath
            If pathdlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim filename As String = pathdlg.FileName

                Dim folderName As String = System.IO.Path.GetDirectoryName(filename)

                lblPath.Text = folderName
                m_dbPath = folderName

                m_dbBackupPath = IO.Path.Combine(folderName, "Backup")
                lblBackupPath.Text = m_dbBackupPath
            End If

        Catch ex As Exception
            m_application.Log.WriteLog(ex, "DataPath", "Ein Fehler trat auf beim anlegen des Datenpfades")
        End Try


        ' Da sollte auch ne HWL-ini liegen! 
    End Sub


    ''' <summary>
    ''' Zeigt an, ob ein Test der Datenbank positiv verlaufen ost
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property TestOK() As Boolean
        Get
            Return m_testOK
        End Get
        Set(ByVal value As Boolean)
            m_testOK = value

            btnOK.Enabled = value
            If m_application.Connections.ConnectionList.Count >= 1 Then
                chkAsdefault.Enabled = value And Not chkAsdefault.Checked
            End If
        End Set
    End Property

    Private Sub txtConnectionName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConnectionUserPassword.EditValueChanged, txtConnectionUsername.EditValueChanged, txtConnectionServerName.EditValueChanged, txtConnectionDatabaseName.EditValueChanged
        TestOK = False
    End Sub

    Private Delegate Sub StartTestDel()
    Private Delegate Sub ShowResultDel(ByVal result As ClausSoftware.DataBase.DBResult)


    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim wc As New Threading.WaitCallback(AddressOf StartDBTest)

        Threading.ThreadPool.QueueUserWorkItem(wc)
        btnTest.Enabled = False

    End Sub

    Private Sub ShowTestResult(ByVal result As ClausSoftware.DataBase.DBResult)
        Dim message As New frmConnectionValid()
        message.DBResult = result
        message.BringToFront()
        message.ShowDialog(Me)

        TestOK = result.IsValid
        btnTest.Enabled = True
    End Sub

    Private Sub StartDBTest(ByVal o As Object)
        Dim myTestConnection As ClausSoftware.Tools.Connection = GetConnectionData()

        Dim dbTest As New ClausSoftware.DataBase.DbEngine(myTestConnection)

        Dim result As ClausSoftware.DataBase.DBResult = dbTest.TestConnection
        Dim newShowresult As New ShowResultDel(AddressOf ShowTestResult)
        If Me.Visible Then
            Me.Invoke(newShowresult, New Object() {result})
        End If
    End Sub

    Private Sub frmConnectionDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Languages.SetTextOnControl(Me)

        FillControls()

    End Sub

    Sub FillControls()
        If m_currentConnection IsNot Nothing Then

            ' Sicherungspfad
            m_dbPath = m_currentConnection.Path
            m_dbBackupPath = m_currentConnection.BackupPath

            txtConnectionNameServer.Text = m_currentConnection.AliasName
            chkAsdefault.Checked = m_currentConnection.IsDefault

            If m_currentConnection.Servertype = ClausSoftware.Tools.enumServerType.MySQL Then
                TabControlConnections.SelectedTabPage = tabDatabaseServer
                txtConnectionDatabaseName.Text = m_currentConnection.Database
                txtConnectionServerName.Text = m_currentConnection.ServerHostName
                txtConnectionUsername.Text = m_currentConnection.Username
                txtConnectionUserPassword.Text = m_currentConnection.Password

                If IsNewConnection Then tabDatabaseFile.Hide()

            Else
                TabControlConnections.SelectedTabPage = tabDatabaseFile
                lblPath.Text = m_currentConnection.Path
                If IsNewConnection Then tabDatabaseServer.Hide()
                lblBackupPath.Text = m_currentConnection.BackupPath
            End If

            ' Falls dies die einzige Verbindung ist, dann ist diese die erste
            If m_application.Connections.ConnectionList.Count = 0 Then
                chkAsdefault.Checked = True
            End If

            ' Gibt es nur diese verbidnung, dann das Ändern der standard-Verbindung nicht zulasen
            If m_application.Connections.ConnectionList.Count < 2 Then
                chkAsdefault.Enabled = False
            Else
                chkAsdefault.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtConnectionNameFile_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConnectionNameFile.EditValueChanged, txtConnectionNameServer.EditValueChanged

        If sender Is txtConnectionNameServer Then
            txtConnectionNameFile.EditValue = txtConnectionNameServer.EditValue
        Else
            txtConnectionNameServer.EditValue = txtConnectionNameFile.EditValue
        End If
    End Sub

    Private Sub lblPath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Try
            Process.Start(lblPath.Text)
        Catch
        End Try
    End Sub

    Private Sub btnBackupPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackupPath.Click
        SetBackupPath()

    End Sub

    Private Sub chkAsdefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAsdefault.CheckedChanged

    End Sub

    ''' <summary>
    ''' Legt den Backup-Pfad für Access-Datenabnken fest
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetBackupPath()
        Try
            Dim pathdlg As New Vista_Api.FolderBrowserDialog

            Dim purePath As String = m_dbBackupPath
            If String.IsNullOrEmpty(purePath) Then purePath = Me.Connection.BackupPath

            If Not System.IO.Directory.Exists(purePath) Then
                purePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
            End If

            purePath = System.IO.Path.GetFullPath(purePath)


            pathdlg.ShowNewFolderButton = True
            pathdlg.SelectedPath = purePath

            If pathdlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim filename As String = pathdlg.SelectedPath

                lblBackupPath.Text = filename
                m_dbBackupPath = filename

            End If
        Catch ex As Exception
            m_application.Log.WriteLog(ex, "ConnectionDetails", "Fehler beim auswerten des Backupfades")
        End Try
    End Sub

    Private Sub btnCreateBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBackup.Click

        If m_application.Database.StartBackup("", Me.Connection) Then
            'TODO: NLS
            MessageBox.Show("Eine Sicherungskopie wurde angelegt.", "Datensicherung", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            'TODO: NLS
            MessageBox.Show("Sicherungskopie konnte nicht angelegt werden. Bitte prüfen Sie den Dateipfad", "Fehler bei der Datensicherung aufgetreten", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub



    Private Sub pathLabel_Click(sender As System.Object, e As System.EventArgs) Handles lblPath.Click, lblBackupPath.Click
        Dim lbl As DevExpress.XtraEditors.LabelControl = CType(sender, DevExpress.XtraEditors.LabelControl)
        Try
            System.Diagnostics.Process.Start(lbl.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCreateServerBackup_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateserverBackup.Click

        btnCreateserverBackup.Enabled = False
        LoadingCircle1.Visible = True
        LoadingCircle1.Active = True

        mainUI.CreateDatabaseBackup(Me.Connection)

        btnCreateserverBackup.Enabled = True

        LoadingCircle1.Visible = False
        LoadingCircle1.Active = False

        If Me.Connection.Servertype = Tools.enumServerType.MySQL Then
            MessageBox.Show("Server-Dump liegt unter " & vbCrLf & _
                                   m_application.Database.LastBackupPath, "Server-Backup angelegt")
        End If

    End Sub


    Private Sub frmConnectionDetails_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        ShowDatabaseSize()
    End Sub

    Private Sub ShowDatabaseSize()
        Try
            lblDatabaseSize.Text = m_application.Database.GetDatabaseSize(Connection)
        Catch ex As Exception
            'TODO: NLS
            Debug.Print("FEHLER beim ermitteln der Datenbankgrösse: " & ex.Message)
            lblDatabaseSize.Text = "<nicht verfügbar>"
        End Try

    End Sub

End Class