
''' <summary>
''' Entghält einen einrichtungsdialog für die Erste einrichtung der Datenbank und Randdaten des Programms
''' </summary>
''' <remarks></remarks>
Public Class frmInstallWizzard


    Private m_databaseType As DataBaseTypeenum
    Private m_TaxesSelected As Boolean

    ''' <summary>
    ''' Enthält den aktuell eingestellten Steuersatz für dieses Land
    ''' </summary>
    ''' <remarks></remarks>
    Private m_currentTaxeValues As ClausSoftware.Kernel.CountryInitialTaxRate



    ''' <summary>
    ''' Ruft den vom Benutzer festgelegten oder geänderten Satz an Steuerdaten ab 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property CurrentTaxValues() As ClausSoftware.Kernel.CountryInitialTaxRate
        Get
            Return m_currentTaxeValues
        End Get
    End Property

    ''' <summary>
    ''' Ruft den Typ der erzeugten Datenbank ab 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property DataBaseType() As DataBaseTypeenum
        Get
            Return m_databaseType
        End Get
        Set(ByVal value As DataBaseTypeenum)
            m_databaseType = value
        End Set
    End Property




    ''' <summary>
    ''' Ermittelt aus einer Auflistung der europäischen Steuersätze den jeweiligen Satz für das aktuelle Land un zeigt diese in einer Übersicht an.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillLocalTaxRates()
        ' 1. Anhand der eingebauten Tabelle suchen; 
        ' 2. Falls nicht vorhanden, erfragen
        lstTaxData.Items.Clear()
        Dim taxes As New ClausSoftware.Kernel.CountryInitialTaxRates()
        m_currentTaxeValues = taxes.GetLocalTaxRate

        lblCountryCodeTaxRates.Text = My.Application.Culture.NativeName

        If m_currentTaxeValues IsNot Nothing Then
            ' -1 heisst nicht vergeben
            'TODO: NLS
            lstTaxData.Items.Add("Normal: " & m_currentTaxeValues.NormalTaxRate.ToString)
            lstTaxData.Items.Add("Reduziert: " & m_currentTaxeValues.ReducedTaxRate.ToString)

            If m_currentTaxeValues.ExtraTaxrate <> -1 Then lstTaxData.Items.Add("Extra: " & m_currentTaxeValues.ExtraTaxrate.ToString)
            If m_currentTaxeValues.ReducedTaxRate2 <> -1 Then lstTaxData.Items.Add("Zwischensatz: " & m_currentTaxeValues.ReducedTaxRate2.ToString)
        Else
            ' Keine Steuer gefunden
            lstTaxData.Items.Add("Keine Steuer gefunden.")
        End If

    End Sub

    Private Sub WizardControl1_SelectedPageChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraWizard.WizardPageChangingEventArgs) Handles WizardControl1.SelectedPageChanging
        If e.Direction = DevExpress.XtraWizard.Direction.Forward Then

            ' Datenbanktyp wählen => Cloud-DB anlegen / Existierende Verknüpfung wählen / Neue DB anlegen
            If e.PrevPage Is wizSelectDatabaseTarget Then
                ' Die Seite "Datenbank auswählen" sollte das aber prüfen...
                e.Page = SetDatabase(e.Page)
                Exit Sub
            End If

            If e.PrevPage Is wizSelectExistingDatabase Then
                e.Page = wizTaxes
                Exit Sub
            End If

            ' Steuern => Finish
            If e.PrevPage Is wizCreateInternetDatabase Then
                ' Das Token prüfen
                If chkHasToken.Checked Then
                    If DatabaseHelper.CheckConnectionByToken(txtToken.Text) = False Then
                        e.Cancel = True
                    End If
                Else
                    ' Dann die Daten eintrage und senden; 
                    ' Anwender muss dann auf das Token warten und neu starten
                End If


            End If

            If e.PrevPage Is wizCompleted Then
                ' Fertig und Anwender hat auf "Finish" geklickt
                Debug.Print("Finish")

                ' Steuerdaten werden im Aufrufer erstellt

                MainApplication.getInstance.Log.WriteLog(Tools.LogSeverity.Information, "Erstinstallation-Wizzard beendet")
                MainApplication.getInstance.UserStats.SendStatistics("Wizzard", "Finished")

                Exit Sub
            End If
        End If


        If e.Direction = DevExpress.XtraWizard.Direction.Backward Then

            If e.PrevPage Is wizTaxes Then
                ' Datenbank- Auswahl geben
                e.Page = SetDatabase(e.Page)
                If e.Page Is wizTaxes Then
                    ' Dann direkt zur DB-Auswahl zurückkehren
                    e.Page = wizSelectDatabaseTarget
                End If
                Exit Sub
            End If

            ' Wenn Rückwärz, dann auch genau die seite aufrufem die der Anwender vorher gewählt hat
            If e.PrevPage Is wizCreateInternetDatabase Or e.PrevPage Is wizSelectExistingDatabase Then
                e.Page = wizSelectDatabaseTarget
            End If

        End If


    End Sub

    ''' <summary>
    ''' Sucht anhand der gewählten option die nächste wizzard-Seite aus
    ''' </summary>
    ''' <param name="nextPage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetDatabase(ByVal nextPage As DevExpress.XtraWizard.BaseWizardPage) As DevExpress.XtraWizard.BaseWizardPage
        Select Case CInt(radDatabaseSelect.EditValue)
            Case 1 ' eigene lokale Datenbank verwenden 
                DataBaseType = DataBaseTypeenum.internalNew
                Return wizTaxes

            Case 2 'Datenbank(auswählen)
                DataBaseType = DataBaseTypeenum.internalExisting
                Return wizSelectExistingDatabase

            Case 3 ' Internet-Db auswählen
                DataBaseType = DataBaseTypeenum.CloudBased
                Return wizCreateInternetDatabase
            Case Else
                Return nextPage

        End Select
    End Function



    ''' <summary>
    ''' Sendet die Zugangsdaten an die Internet-Datenbank
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SendAccessDataAndgetToken() As Boolean
        Try
            Dim headline As String
            Dim message As String

            If Not txtPassword1.Text.Equals(txtPassword2.Text) Then
                headline = GetText("headInvalidPasswordsNotEqual", "Ungültiges Service-Passwort")
                message = GetText("msgInvalidPasswordsNotEqual", "Die Passwörter müssen gleich sein!")
                MessageBox.Show(message, headline, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return False
            End If

            UseWaitCursor = True
            MainApplication.getInstance.UserStats.SendStatistics(Tools.ReportMessageType.Info, "Cloud DB Request", "User requested a Cloud Database")

            Dim iDB As New de.hwl_developer.HWLClouldService()
            Dim result As Boolean = iDB.RequestToken(txtServiceName.Text, "Company", txtemailAdress.Text, MainApplication.ApplicationName, txtPassword1.Text)
            UseWaitCursor = False

            If result Then
                'TODO: NLS
                MessageBox.Show("Wir haben Ihnen nun eine e-Mail mit einem Zugangsschlüssel zugesendet. Dieses ist ab jetzt 14 Tage gültig und kann verwendet werden, um die Datenbank anzulegen" & vbCrLf &
                                "Tragen sie den Zugangsschlüssel in das Textfeld ein oder erstellen sie im Menü ""Extras"" eine neue Datenbankverbindung", "Zugangsschlüssel zugestellt", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                ' Fehler = > doof!
                Return False
            End If
        Catch ex As Exception
            UseWaitCursor = False
            MainApplication.getInstance.Log.WriteLog(ex, "DatabaseConnect in InstallWizzard", "Error while connecting to a Database")
            'TODO: NLS
            MessageBox.Show("Ein Fehler ist beim Verbinden mit dem Datenbankserver aufgetreten: " & vbCrLf & ex.Message, "Fehler beim Verbinden", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub TextEdit2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToken.EditValueChanged
        If txtToken.Text.Length = 32 Then
            wizCreateInternetDatabase.AllowNext = True

        Else
            wizCreateInternetDatabase.AllowNext = False

        End If
    End Sub


    ''' <summary>
    ''' Prüft ob der Senden.. Button aktiv geschaltet werden kann oder nicht
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckSendToButton()
        Dim valid As Boolean
        valid = txtPassword1.Text.Equals(txtPassword2.Text)

        valid = valid And txtemailAdress.Text.Length > 5
        't@t.de
        btnCreateCloudAccount.Enabled = valid
    End Sub


    Private Sub frmInstallWizzard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.DesignMode Then Exit Sub

        IucOptionConnections1.Reload()

        MainApplication.getInstance.Languages.SetTextOnControl(Me)
        picWizzardFinish.Image = My.Resources.signal_flag_checkered_LowContrast_128x128
        picHelpDatabase.Image = My.Resources.Symbol_Help_16x16

        If Not m_TaxesSelected Then
            ' Sofern noch unbekannt, setzte die Steuer-Seite
            FillLocalTaxRates()
        End If

        Me.Text = MainApplication.ApplicationName

    End Sub

    Private Sub chkHasToken_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHasToken.CheckedChanged, chkEnterData.CheckedChanged
        ' Check des jeweils anderen umkehren
        If sender Is chkHasToken Then
            chkEnterData.Checked = Not chkHasToken.Checked
        Else
            chkHasToken.Checked = Not chkEnterData.Checked
        End If


        txtToken.Enabled = chkHasToken.Checked

        txtemailAdress.Enabled = chkEnterData.Checked
        txtPassword1.Enabled = chkEnterData.Checked
        txtPassword2.Enabled = chkEnterData.Checked
        txtServiceName.Enabled = chkEnterData.Checked

    End Sub

    Private Sub btnSendAccessData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateCloudAccount.Click
        SendAccessDataAndgetToken()
    End Sub

    Delegate Sub sendAccountData()

    Private Sub BeginSendData()
        Me.BeginInvoke(New sendAccountData(AddressOf SendAccessDataAndgetToken))

    End Sub

    Private Sub lblcloudServicePriceInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblcloudServicePriceInformation.Click
        Process.Start(HWLInterops.wwwCloudDatabasePriceWebsite)
    End Sub

    Private Sub cloudService_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceName.EditValueChanged, txtPassword2.EditValueChanged, txtPassword1.EditValueChanged, txtemailAdress.EditValueChanged
        CheckSendToButton()

    End Sub

    Private Sub btnCustomInstallation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomInstallation.Click
        Me.WizardControl1.SetNextPage()
    End Sub

    Private Sub btnDefaultSimpleInstallation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultSimpleInstallation.Click
        ' Standard-Verbindung: 
        ' Altes HWL wird verwendet
        ' (Neue Db angelegt, falls kein altes HWL da ist)
        ' Standard Steuerdaten
        'MainApplication.getInstance.Connections.FillConnectionsList()
        Me.DataBaseType = DataBaseTypeenum.internalNew
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    
    Private Sub picSendUserData_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picSendUserData.MouseDown
        MessageBox.Show(GetText("msgSendStatisticDataInfo", "Sendet anonyme Daten zur nutzungsweise oder Fehlermeldungen an den Hersteller. Damit können wir die Softwarequalität stetig verbessern." & vbCrLf & vbCrLf & _
                                "Sie können diese Einstellung auch später im Menü 'Hilfe' jederzeit ändern."), GetText("msgSendStatisticDataInfoHead", "Sendet anonyme statistische Daten"), MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lblHelpChooseDatabase_Click(sender As System.Object, e As System.EventArgs) Handles lblHelpChooseDatabase.Click

    End Sub
End Class

''' <summary>
''' Stellt den Typ der gewählten Datenbank durch den Benutzer da
''' </summary>
''' <remarks></remarks>
Friend Enum DataBaseTypeenum

    ''' <summary>
    ''' Erstellt im lokalen standardpfad eine neue Datenbank
    ''' </summary>
    ''' <remarks></remarks>
    internalNew

    ''' <summary>
    ''' Wählt den Pfad zu einer bereits bestehenden Datenbank
    ''' </summary>
    ''' <remarks></remarks>
    internalExisting
    ''' <summary>
    ''' Wählt eine Internet-Basisrende Datenbank
    ''' </summary>
    ''' <remarks></remarks>
    CloudBased

End Enum
