Public Class DatabaseHelper



    ''' <summary>
    ''' Sendet das Token und prüft so ob Daten empfangen wurden. Falls erfolgreich, werden diese Daten als Verbindungsdaten aufgenommen
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function CheckConnectionByToken(tokenID As String) As Boolean
        Try
            If String.IsNullOrEmpty(tokenID) Then Return False

            Dim localToken As String = tokenID.Replace("-", "") ' Bindestriche herausfiltern
            localToken = localToken.Trim  ' Leerzeichen entfernen


            Dim idb As New de.hwl_developer.HWLClouldService

            Dim data As de.hwl_developer.ConnectionData = idb.RequestNewDatabase(localToken)
            idb.Dispose()

            Dim c As New ClausSoftware.Tools.Connection
            c.AliasName = "Internet-Database"
            c.Database = data.DatabaseName
            c.IsDefault = True
            c.Password = data.Password
            c.ServerHostName = data.ServerName
            c.Servertype = Tools.enumServerType.MySQL
            c.Username = data.Username
            c.Token = tokenID
            MainApplication.getInstance.Connections.Add(c)
            MainApplication.getInstance.Connections.DefaultConnection = c

            MainApplication.getInstance.Connections.SaveConnections()
            Dim msgText As String = GetText("msgNewDatabaseserverCreated", "Eine neue Datenbankverbindung wurde unter der Bezeichnung '{0}' neu angelegt.", c.AliasName)
            Dim headlinetext As String = GetText("msgHeadDatabaseConnectionSaved", "Datenbankverbindung gespeichert")
            MessageBox.Show(msgText, headlinetext, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As Exception
            'TODO: NLS
            MessageBox.Show("Ein Fehler  trat auf:" & ex.Message & "", "Fehler beim Erstellen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally

        End Try

    End Function

End Class
