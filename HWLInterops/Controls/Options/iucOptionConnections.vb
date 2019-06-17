Imports ClausSoftware.Tools

''' <summary>
''' Stellt Optionen für die Datenbankverbindung bereit
''' </summary>
''' <remarks></remarks>
Public Class iucOptionConnections
    Implements IOptionMenue

    ' Nur für HWL, nicht für PB
    Public Const constWebServerInfo As String = "Http://claus-software.de/index.php?file=content_ServerInfo.php"
    'TODO: Link für Power Büro angeben

    Private m_needsRestart As Boolean

    ''' <summary>
    ''' Enthält die Standardverbindung bevor diese vcerändert woden ist.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_orgConnection As ClausSoftware.Tools.Connection


    Public Sub Initialize() Implements IOptionMenue.Initialize

        MainApplication.getInstance.Connections.ReadConnections()
        lstConnections.DataSource = MainApplication.getInstance.Connections.ConnectionList
        lstConnections.Refresh()

        lstConnections.SelectedItem = MainApplication.getInstance.Connections.DefaultConnection

    End Sub

    Private m_showDBOptions As Boolean = True

    <Description("Zeigt Datenbankoptionen an")>
    Property ShowDatabaseOptions As Boolean
        Get
            Return m_showDBOptions
        End Get
        Set(value As Boolean)
            m_showDBOptions = value

            lblPath.Visible = value
            lblBackupPath.Visible = value
            lblDBBackupPath.Visible = value
            lblDBPath.Visible = value
            btnCreateDBBackup.Visible = value

        End Set
    End Property

    Public Sub Reload() Implements IOptionMenue.Reload
        Initialize()
    End Sub

    Public Sub Save() Implements IOptionMenue.Save

    End Sub

    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReload.Click
        Initialize()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteSelectedItem()
    End Sub

    Private Sub DeleteSelectedItem()

        Dim selectedCon As ClausSoftware.Tools.Connection = SelectedConnection
        If selectedCon IsNot Nothing Then
            If selectedCon.Equals(MainApplication.getInstance.Connections.DefaultConnection) Or selectedCon.IsDefault Then
                'TODO: NLS
                MessageBox.Show("Sie können die aktuelle Verbindung nicht löschen", "Kann Verbindung nicht löschen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'TODO: NLS
            If MessageBox.Show("Möchten Sie die gewählte Verbindung " & selectedCon.AliasName & " wirklich löschen?", "Verbindung löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MainApplication.getInstance.Connections.Remove(selectedCon)
                Initialize()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Ruft die aktuell selektierte Verbindung ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedConnection As ClausSoftware.Tools.Connection
        Get
            Return TryCast(lstConnections.SelectedItem, ClausSoftware.Tools.Connection)
        End Get
    End Property


    Private Sub EditSelectedItem()
        Dim selectedCon As ClausSoftware.Tools.Connection = SelectedConnection

        If selectedCon IsNot Nothing Then
            If EditItem(selectedCon) = DialogResult.OK Then

                If selectedCon.IsDefault Then
                    MainApplication.getInstance.Connections.DefaultConnection = selectedCon
                End If

                MainApplication.getInstance.Connections.SaveConnections()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Öffnet einen Dialog zum bearbeitend er neuen Verbindung
    ''' </summary>
    ''' <param name="connection"></param>
    ''' <remarks></remarks>
    Private Function EditItem(ByVal connection As ClausSoftware.Tools.Connection) As DialogResult
        Dim editConnection As New frmConnectionDetails()

        editConnection.Connection = connection



        Dim result As DialogResult = editConnection.ShowDialog()

        ' besser Die Connection-List als eigen Klasse abspeichern und nur einen Default-eigenschaft definieren
        If connection.IsDefault Then ' die standard-Verbindung erzwingen
            MainApplication.getInstance.Connections.DefaultConnection = connection
        End If

        Return result

    End Function

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        OpenSelectedItem()
    End Sub

    Private Sub OpenSelectedItem()
        EditSelectedItem()
        Initialize()
    End Sub

    Private Sub CreateNewConnection()
        Dim newConnection As New ClausSoftware.Tools.Connection(GetText("msgNewConnectionName", "<Neue Verbindung>"))
        newConnection.Servertype = ClausSoftware.Tools.enumServerType.Undefined
        newConnection.ServerHostName = "localhost"
        newConnection.IsNew = True

        If EditItem(newConnection) = DialogResult.OK Then
            If newConnection.IsDefault Then
                MainApplication.getInstance.Connections.DefaultConnection = newConnection
            End If

            MainApplication.getInstance.Connections.Add(newConnection)
            'MainApplication.getInstance.Connections.SaveClassicConnections()
            Initialize()
        End If

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        CreateNewConnection()
    End Sub

    Private Sub lstConnections_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstConnections.MouseDoubleClick
        Dim itemno As Integer = lstConnections.IndexFromPoint(e.Location)
        If itemno >= 0 Then

            EditSelectedItem()
            Initialize()
        End If
    End Sub

    Private Sub iucOptionConnections_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.DesignMode Then Exit Sub
        Debug.Print("Status von MainApplication.getInstance ist: " & (MainApplication.getInstance Is Nothing))

        If MainApplication.getInstance IsNot Nothing Then
            Dim defaultconnection As Connection = MainApplication.getInstance.Connections.DefaultConnection
            If defaultconnection IsNot Nothing Then
                m_orgConnection = CType(defaultconnection.Clone, Connection)
            End If
        End If

        MainApplication.getInstance.Languages.SetTextOnControl(Me)

    End Sub

    Public Overrides Function ToString() As String
        Return Me.DisplayName
    End Function

    Public ReadOnly Property DisplayName() As String Implements IOptionMenue.DisplayName
        Get
            Return GetText("optionConections", "Datenbankverbindungen")
        End Get

    End Property

    ''' <summary>
    ''' Ist True, wenn eine Änderung erfordert, das HWL neu gestartet werden muss.
    ''' Das ist der Fall, wenn dei standard-Verbindung nicht mehr so ist, wie vor der Bearbeitung
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            If m_orgConnection IsNot Nothing Then
                Return Not m_orgConnection.Equals(MainApplication.getInstance.Connections.DefaultConnection)
            Else
                Return True
            End If


        End Get
    End Property

    ''' <summary>
    ''' Erstelltz eine Datensicherung vom aktuell selektiertem Eintrag
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateBackup()
        MainApplication.getInstance.Database.StartBackup("", Me.SelectedConnection)
    End Sub

    Private Sub btnCreateDBBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDBBackup.Click
        If Me.SelectedConnection IsNot Nothing Then
            Try
                MainUI.CreateDatabaseBackup(Me.SelectedConnection)

                If Me.SelectedConnection.Servertype = Tools.enumServerType.MySQL Then
                    MessageBox.Show("Server-Dump liegt unter " & vbCrLf &
                                           MainApplication.getInstance.Database.LastBackupPath, "Server-Backup angelegt")
                End If
            Catch ex As Exception
                MainApplication.getInstance.log.WriteLog(ex, "Database Backup", "Fehler beim Anlegen eines Backups von '" & Me.SelectedConnection.GetConnectionShortDescription & "'")
            End Try

        End If

    End Sub

    Private Sub DBPathLabel_Click(sender As System.Object, e As System.EventArgs) Handles lblPath.Click, lblBackupPath.Click
        Dim lbl As DevExpress.XtraEditors.LabelControl = CType(sender, DevExpress.XtraEditors.LabelControl)
        Try
            System.Diagnostics.Process.Start(lbl.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lstConnections_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstConnections.SelectedIndexChanged
        Dim selectedItem As Connection = Me.SelectedConnection

        If selectedItem IsNot Nothing Then

            If selectedItem.Servertype = enumServerType.Access Then
                ' Pfade anzeigen lassen
                lblDBServer.Visible = False
                lblBackupPath.Visible = ShowDatabaseOptions
                lblBackupPath.Text = selectedItem.BackupPath
                lblPath.Visible = ShowDatabaseOptions
                lblPath.Text = selectedItem.Path

                lblDBBackupPath.Visible = ShowDatabaseOptions
                lblDBPath.Visible = ShowDatabaseOptions
            Else
                ' Keine Pfade anzeigen lassen ! Hier giebt es den Datenbankserver
                lblDBServer.Visible = ShowDatabaseOptions

                lblDBServer.Text = selectedItem.GetConnectionShortDescription

                lblPath.Visible = False
                lblBackupPath.Visible = False
                lblDBBackupPath.Visible = False
                lblDBPath.Visible = False

            End If


        Else
            ShowDatabaseOptions = False

        End If
    End Sub
End Class