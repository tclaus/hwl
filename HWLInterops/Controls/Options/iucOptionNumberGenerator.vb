Imports ClausSoftware.Tools
Imports ClausSoftware.Kernel

''' <summary>
''' stellt Optionen für die Nummernvergabe bereit
''' </summary>
''' <remarks></remarks>
Public Class iucOptionNumberGenerator
    Implements IOptionMenue

    Private m_Info As StatisticInfo
    ''' <summary>
    ''' Ist Wahr, solange die Datenfelder gefüllt erden
    ''' </summary>
    ''' <remarks></remarks>
    Private m_isLoading As Boolean

    ''' <summary>
    ''' Zeigt änderungen an den Datenfeldern an
    ''' </summary>
    ''' <remarks></remarks>
    Private m_changed As Boolean


    ''' <summary>
    ''' Zeigt eine Vorschau der Dokumentennummer an.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowPreviewInvoiceNumbers()
        ' Unterstüzte Platzhalter
        ' $JJJJ   - Jahreszahl
        ' $MM     - Monatszahl
        ' $TT     - Tageszahl
        ' Jeweils des Datums an dem das Dokument angelegt wurde

        If m_isLoading Then Exit Sub


        m_Info = MainApplication.getInstance.UserStats.InfoItem
        Try
            lblInvoicesPreview.Text = MainApplication.getInstance.Tools.GetDisplayID(CInt(txtInvoicesInitialNumber.EditValue) + m_Info.NextInvoiceNumber, txtInvoicesReplacement.Text, Now)
        Catch
            lblInvoicesPreview.Text = "-"
        End Try
        Try
            lblOffersPreview.Text = MainApplication.getInstance.Tools.GetDisplayID(CInt(txtOffersInitialNumber.EditValue) + m_Info.NextOffersNumber, txtOffersReplacement.Text, Now)
        Catch
            lblOffersPreview.Text = "-"
        End Try
        Try
            lblCustomersPreview.Text = MainApplication.getInstance.Tools.GetDisplayID(CInt(txtCustomersInitialNumber.EditValue) + m_Info.NextAddressNumber, txtCustomersReplacement.Text, Now)
        Catch
            lblCustomersPreview.Text = "-"
        End Try

    End Sub

    ''' <summary>
    ''' Zeigt an, das sich der Inhalt geändert hat
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Changed() As Boolean
        Get
            Return m_changed
        End Get
        Set(ByVal value As Boolean)
            m_changed = value
            btnWriteNewData.Enabled = value
        End Set
    End Property

    Public ReadOnly Property DisplayName() As String Implements IOptionMenue.DisplayName
        Get
            Return GetText("optionNumberGenerator", "Nummernvergabe")
        End Get
    End Property

    ''' <summary>
    ''' Setzt Startwerte der Oberfläche
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize() Implements IOptionMenue.Initialize

        Reload()

    End Sub

    ''' <summary>
    ''' Aktualisiert die eingaben
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Reload() Implements IOptionMenue.Reload

        m_isLoading = True
        'Adressen
        txtCustomersInitialNumber.EditValue = MainApplication.getInstance.Settings.SettingAdressID_Base
        txtCustomersReplacement.Text = MainApplication.getInstance.Settings.SettingAdressID_Format

        'Angebote
        txtOffersInitialNumber.EditValue = MainApplication.getInstance.Settings.SettingOffersID_Base
        txtOffersReplacement.Text = MainApplication.getInstance.Settings.SettingOffersID_Format

        'Rechnungen
        txtInvoicesInitialNumber.EditValue = MainApplication.getInstance.Settings.SettingInvoicesID_Base
        txtInvoicesReplacement.EditValue = MainApplication.getInstance.Settings.SettingInvoicesID_Format
        m_isLoading = False

        ' Neu aufbauen
        ShowPreviewInvoiceNumbers()
        m_changed = False
    End Sub

    Public Sub Save() Implements IOptionMenue.Save
        Try
            WriteNewData()   ' Darf nicht abstürzen
        Catch
        End Try
    End Sub

    Public Overrides Function ToString() As String
        Return Me.DisplayName
    End Function

    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False
        End Get
    End Property

    Private Sub btnShowPlaceHolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowPlaceHolder.Click
        Dim str As String = ""

        For Each item As KeyValuePair(Of String, String) In MainApplication.getInstance.Tools.GetReplacementStringsNumbergenerator
            str &= item.Key & ":" & item.Value & vbCrLf
        Next

        MessageBox.Show(str, GetText("PlaceHoldersInNumberGenerator", "Ersetzungen im Nummerngenerator"), MessageBoxButtons.OK)

    End Sub

    Private Sub btnWriteNewData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteNewData.Click
        WriteNewData()
    End Sub

    ''' <summary>
    ''' Schreibt alle Datensätze neu, in denen die Nummeriergung geändert wurde
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WriteNewData()
        LoadingCircle1.Visible = True
        LoadingCircle1.Active = True
        btnWriteNewData.Enabled = False
        Me.Enabled = False

        Dim itemcount As Integer
        Dim counter As Integer

        Dim strAddresses As String = GetText("Adresses", "Adressen")
        Dim strDocuments As String = GetText("CommonDocuments", "Dokumente")
        Dim strInvoices As String = GetText("Invoices", "Rechnungen")

        If CInt(txtCustomersInitialNumber.EditValue) <> MainApplication.getInstance.Settings.SettingAdressID_Base Or CStr(txtCustomersReplacement.EditValue) <> MainApplication.getInstance.Settings.SettingAdressID_Format Then
            ' Adressbuch-Nummern neu schreiben
            ' (Display-ID setzen)
            MainApplication.getInstance.Settings.SettingAdressID_Base = CInt(txtCustomersInitialNumber.EditValue)
            MainApplication.getInstance.Settings.SettingAdressID_Format = CStr(txtCustomersReplacement.EditValue)

            MainApplication.getInstance.Adressen.Criteria = Nothing ' Sicherstellen, das wir alles erwischen
            itemcount = MainApplication.getInstance.Adressen.Count
            counter = 0
            MainApplication.getInstance.SendMessage(GetText("WritingNewAddressNumbers", "Schreibe neue Kontaktnummern"))
            For Each item As Adress In MainApplication.getInstance.Adressen
                item.RefreshDisplayID()
                item.Save()
                counter += 1
                MainApplication.getInstance.SendProgress(strAddresses, counter, itemcount)

            Next
        End If

        ' Nun allgemein alle Dokuemnte neu schreiben...
        If CInt(txtOffersInitialNumber.EditValue) <> MainApplication.getInstance.Settings.SettingOffersID_Base Or CStr(txtOffersReplacement.EditValue) <> MainApplication.getInstance.Settings.SettingOffersID_Format Then
            MainApplication.getInstance.Settings.SettingOffersID_Base = CInt(txtOffersInitialNumber.EditValue)
            MainApplication.getInstance.Settings.SettingOffersID_Format = CStr(txtOffersReplacement.EditValue)

            itemcount = MainApplication.getInstance.JournalDocuments.Count
            MainApplication.getInstance.SendMessage(GetText("WritingNewOfferNumbers", "Schreibe neue Angebots-Nummern"))

            For Each item As JournalDocument In MainApplication.getInstance.JournalDocuments
                If item.DocumentType = enumJournalDocumentType.Angebot Then
                    item.RefreshDisplayID()
                    item.Plainsave()
                End If

                counter += 1
                MainApplication.getInstance.SendProgress(strDocuments, counter, itemcount)

            Next
        End If
        '.. Und weil es so schön war, nun nur alle Rechnungen schreiben
        If CInt(txtInvoicesInitialNumber.EditValue) <> MainApplication.getInstance.Settings.SettingInvoicesID_Base Or CStr(txtInvoicesReplacement.EditValue) <> MainApplication.getInstance.Settings.SettingInvoicesID_Format Then
            MainApplication.getInstance.Settings.SettingInvoicesID_Base = CInt(txtInvoicesInitialNumber.EditValue)
            MainApplication.getInstance.Settings.SettingInvoicesID_Format = CStr(txtInvoicesReplacement.EditValue)

            MainApplication.getInstance.JournalDocuments.Criteria = Nothing

            MainApplication.getInstance.SendMessage(GetText("WritingNewInvoiceNumbers", "Schreibe neue Rechnungs-Nummern"))

            For Each item As JournalDocument In MainApplication.getInstance.JournalDocuments
                If item.DocumentType = enumJournalDocumentType.Rechnung Then
                    item.RefreshDisplayID()
                    item.Plainsave()
                End If

                counter += 1
                MainApplication.getInstance.SendProgress(strInvoices, counter, itemcount)
            Next


        End If
        Me.Changed = False

        LoadingCircle1.Visible = False
        LoadingCircle1.Active = False
        Me.Enabled = True

    End Sub

    Private Sub txtOffersReplacement_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOffersReplacement.Validating, txtInvoicesReplacement.Validating, txtCustomersReplacement.Validating
        ' ein "$NR" muss enthaltn bleiben !

        Dim ctrl As Control = CType(sender, Control)
        Dim innerText As String = ctrl.Text.ToUpper
        If Not innerText.Contains("$NR") Then

            'TODO: NLS
            MessageBox.Show("Ein $NR steht als Platzhalter für die fortlaufende Nummer und muss immer angegeben werden.", "Platzhalter fehlt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If

    End Sub
    ''' <summary>
    ''' Ermittelt eine Änderung der Textboxen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Textbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOffersReplacement.TextChanged, txtOffersInitialNumber.TextChanged, txtInvoicesReplacement.TextChanged, txtInvoicesInitialNumber.TextChanged, txtCustomersReplacement.TextChanged, txtCustomersInitialNumber.TextChanged
        Me.Changed = True
        ShowPreviewInvoiceNumbers()
    End Sub

    Public Sub New()
        m_isLoading = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_isLoading = False
    End Sub

    Private Sub iucOptionNumberGenerator_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

        txtInvoicesInitialNumber.EditValue = MainApplication.getInstance.Settings.SettingInvoicesID_Base
        txtInvoicesReplacement.EditValue = MainApplication.getInstance.Settings.SettingInvoicesID_Format

        txtOffersInitialNumber.EditValue = MainApplication.getInstance.Settings.SettingOffersID_Base
        txtOffersReplacement.EditValue = MainApplication.getInstance.Settings.SettingOffersID_Format

    End Sub
End Class
