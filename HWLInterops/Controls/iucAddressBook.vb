Imports ClausSoftware.Kernel
Imports DevExpress.XtraEditors.Controls
Imports ClausSoftware.Data
Imports DevExpress.XtraEditors

''' <summary>
''' Stellt das UserControl des Adressbuches bereit
''' </summary>
''' <remarks></remarks>
Public Class iucAddressBook
    Implements IModule

    Private m_workspaceExpanded As Boolean


    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        AddMenuItems()
    End Sub


    Public Sub New(ByVal myUI As MainUI)
        MyBase.New(myUI)
        InitializeComponent()
        AddMenuItems()
    End Sub

    Friend Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Private m_activeItem As Adress
    Private m_hasChanged As Boolean
    Private m_searchButton As EditorButton
    Private m_isLoading As Boolean

    ''' <summary>
    ''' Fügt Benutzerdefinierte Menüelemente der Neu... Menü hinzu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddMenuItems()
        Dim newItemBill As New CustomMenuItem("idNewBill") ' Neue Rechnung 
        newItemBill.Caption = GetText("mnuNameBillsOffers", "Angebot/Rechnung")

        'Dim newItemBrief As New CustomMenuItem("idNewLetter") ' Neue Rechnung 
        'newItemBrief.Caption = GetText("mnuNameLetter", "Brief")


        uicCommonGrid.CustomMenues.Clear()
        uicCommonGrid.CustomMenues.Add(newItemBill)
        'uicCommonGrid.CustomMenues.Add(newItemBrief)

    End Sub

    Private Sub CreateNewDocumentFromActiveElement()
        If Me.ActiveItem IsNot Nothing Then
            If ActiveItem.IsNew Then

                Dim newModule As iucMainModule = MainUI.OpenWorkingPane(HWLModules.Business)
                Dim container As Offers.iucBills = CType(newModule.WorkingItem, Offers.iucBills)

                container.ActiveAddress = Me.ActiveItem

            End If
        End If

    End Sub

    ''' <summary>
    ''' Erstellt ein neues Dokument mit dem aktiven Element
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateNewDocument()
        If Me.ActiveItem IsNot Nothing Then
            CreateNewDocument(Me.ActiveItem)
        Else
            CreateNewDocument(CType(uicCommonGrid.FocussedItem, Adress))
        End If

    End Sub

    ''' <summary>
    ''' Öffnet mit dem aktuell gewählten LIstenelement ein neuens "Angebote/Rechnungen" - Fenster
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateNewDocument(ByVal withcontact As Adress)
        Debug.Assert(withcontact IsNot Nothing, "Kann kein neues Dokument anlegen, wenn Kontakt-Obj nothing ist.")
        Try

            If Not withcontact.IsNew Then

                Dim newModule As iucMainModule = MainUI.OpenWorkingPane(HWLModules.Business, True)
                Dim container As Offers.iucBills = CType(newModule.WorkingItem, Offers.iucBills)

                container.ActiveAddress = withcontact
                container.ClearHasChangedState() ' Bei solcherart angelegten Dokumenten kann der Status zurückgesetzt werden
            Else
                MainApplication.getInstance.log.WriteLog("Es wurde versucht, von einem neuem Kontakt ein Dokument anzulegen.")
            End If

        Catch ex As Exception

        End Try


    End Sub

    Public Property ActiveItem() As Adress
        Get
            Return m_activeItem
        End Get
        Set(ByVal value As Adress)
            m_activeItem = value

            FillControls()

            MainUI.MRUManager.AddMRUElement(Me.ActiveItem)
        End Set
    End Property

    ''' <summary>
    ''' Ist True, wenn der Datensatz sich geändert hat
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            If m_activeItem IsNot Nothing Then

                If ActiveItem IsNot Nothing Then
                    Return ActiveItem.HasChanged Or m_hasChanged
                Else
                    Return m_hasChanged
                End If
            Else
                Return False
            End If

        End Get
    End Property

    ''' <summary>
    ''' MAcht das übergebene Objekt zum aktuellen Objekt. Führt eine Prüfung durch, falls ein anderes Objekt bereits bearbeitet wird.
    ''' </summary>
    ''' <param name="currentItem"></param>
    ''' <remarks></remarks>
    Friend Sub LoadCurrentItem(ByVal currentItem As StaticItem)
        If m_activeItem IsNot Nothing Then
            If HasChanged And m_hasChanged Then


                Dim result As DialogResult = AskChangedData()
                If result = DialogResult.Cancel Then Exit Sub

                If result = DialogResult.Yes Then
                    Save()
                Else
                    m_activeItem.Reload()

                End If

            End If
        End If


        ActiveItem = CType(currentItem, Adress)

    End Sub


    ''' <summary>
    ''' Startet einen Ausdruck-Manager
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Print() Implements IModule.Print
        Try


            MainUI.ShowPrintInGrid(uicCommonGrid.grdCommonGrid, DataSourceList.Addressbook, m_activeItem)


        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Print Addressbook", "Error in Printing Dialog")
        End Try


    End Sub
    ''' <summary>
    ''' Speichert das aktuelle Element ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Save() Implements IModule.SaveCurrentItem

        If m_activeItem IsNot Nothing Then

            If ActiveItem.IsDeleted Then
                ActiveItem = Nothing
                CreateNewItem()
                Exit Sub
            End If

            If HasChanged Then

                Dim isCurrentlyActive As Boolean = ActiveItem.IsActive ' Feststellen, on nun diese Adresse inaktiv ist

                FillObject()

                If ActiveItem.IsNew Then
                    MainApplication.getInstance.Adressen.Add(ActiveItem)
                End If

                ActiveItem.Save()
                MainApplication.getInstance.SendMessage(GetText("msgsaved", "Gespeichert."))
                MainUI.MRUManager.AddMRUElement(ActiveItem)

                If Not ActiveItem.IsActive And isCurrentlyActive Then
                    ' Dann hat sich der Zustand geändert und ein History - Eintrag muss erzeugt werden
                    Dim hItem As AddressHistoryItem = ActiveItem.History.GetNewItem

                    hItem.Adress = ActiveItem
                    hItem.Category = ActiveItem.History.Categories.GetCommonCategory
                    'TODO: NLS
                    hItem.Text = "Status wurde auf 'inaktiv' gesetzt."
                    hItem.Save()
                ElseIf ActiveItem.IsActive And Not isCurrentlyActive Then
                    ' Dann wurde ein "Inaktiv" - Status wieder hergestellt
                    Dim hItem As AddressHistoryItem = ActiveItem.History.GetNewItem

                    hItem.Adress = ActiveItem
                    hItem.Category = ActiveItem.History.Categories.GetCommonCategory
                    'TODO: NLS
                    hItem.Text = "Status wurde wieder auf 'aktiv' gesetzt."
                    hItem.Save()
                End If

                ActiveItem.Reload()
                m_hasChanged = False
            End If
            ' Nach dem Speichern dies auch selektieren
            uicCommonGrid.RefreshData()
            uicCommonGrid.SelectItemByID(m_activeItem.ID)

            FillControls()

        End If
    End Sub


    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Dim text As String
            If m_activeItem IsNot Nothing Then
                text = "Adressbuch " & ActiveItem.ToString
            Else
                text = "Adressbuch"
            End If

            Return text

        End Get
    End Property

    ''' <summary>
    ''' Füllt die Oberfläche mit den aktuellen Daten aus dem Datenobjekt
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillControls()
        If m_activeItem IsNot Nothing Then

            If m_workspaceExpanded Then  ' Wenn zusammengeschoben, dann Arbeitsbereich wiederf herstellen
                ToggleWorkspace()
            End If

            With m_activeItem
                m_isLoading = True

                lblCreatedAtValue.Text = .CreatedAt.ToString("D")
                lblLastChangedAtValue.Text = .ChangedAt.ToString("D")

                txtMemo.Text = .Description
                txtBankKonto.Text = .BankKontonummer
                txtBankLeitzahl.Text = .Bankleitzahl
                txtBankName.Text = .Bankname
                txtCompany.Text = .Company
                txtContactID.Text = .ContactDisplayID
                txtFirstName.Text = .FirstName
                txtLastName.Text = .LastName
                txtCountry.Text = .Country
                txtEbayID.Text = .EbayID
                txtEmail.Text = .EMail
                txtfax.Text = .Fax
                txtWorkOn.Text = .KindOfBusiness
                txtIBAN.Text = ""
                txtNotes.Text = .Notes
                txtCustomersDiscountValue.Text = .Rabatt

                ' Zahlungsziel
                txtTargetPaydateDays.EditValue = .TargetPayDays
                chkEnableTargetPayDate.Checked = .EnableTargetPayDate

                chkIsActiveContact.Checked = .IsActive

                txtDeliveryAdress.Text = .DeliveryAdress
                chkLinkDeliveryAdress.Checked = .DeliveryAdressLinked
                txtInvoiceAdress.Text = .InvoiceAdressWindow

                txtStreet.Text = .Street
                txtTelefon1.Text = .Telefon1
                txtPhone2.Text = .Telefon2
                txtTown.Text = .Town
                txtUstID.Text = ""
                txtZipCode.Text = .ZipCode

                If tabInformation.SelectedTabPage Is tbpHistory Then
                    RefreshHistory()
                Else
                    grdHistory.DataSource = Nothing
                End If

                ' txtCompany.Focus()


            End With

            If m_activeItem.ID = -1 Then
                txtContactID.Text = GetText("msgNewAdressDisplayID", "<NEU, wird beim Speichern gesetzt>")
            End If

            'Bei neuen Elementen kann die Historie nicht geändert werden
            btnAddHistory.Enabled = Not m_activeItem.IsNew
            btnEditHistory.Enabled = Not m_activeItem.IsNew

            btnNewDocumentFromAddress.Enabled = Not m_activeItem.IsNew

            txtCompany.Focus()
            m_hasChanged = False
            m_isLoading = False
        End If

    End Sub

    ''' <summary>
    ''' Füllt das Eingabefenster in das aktuelle Objekt
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillObject()
        If m_activeItem IsNot Nothing Then
            With m_activeItem
                .Description = txtMemo.Text
                .BankKontonummer = txtBankKonto.Text
                .Bankleitzahl = txtBankLeitzahl.Text
                .Bankname = txtBankName.Text
                .FirstName = txtFirstName.Text
                .LastName = txtLastName.Text
                .Country = txtCountry.Text
                .Company = txtCompany.Text
                .Datanorm = ""
                .DeliveryAdress = txtDeliveryAdress.Text
                .DeliveryAdressLinked = chkLinkDeliveryAdress.Checked

                'Zahlungsziel
                .TargetPayDays = CInt(txtTargetPaydateDays.EditValue)
                .EnableTargetPayDate = chkEnableTargetPayDate.Checked

                .EbayID = txtEbayID.Text
                .EMail = txtEmail.Text
                .Fax = txtfax.Text
                .KindOfBusiness = txtWorkOn.Text
                .InvoiceAdressWindow = txtInvoiceAdress.Text
                .Notes = txtNotes.Text
                .Town = txtTown.Text
                .ZipCode = txtZipCode.Text
                .PrintEntry = True
                .Street = txtStreet.Text
                .Telefon1 = txtTelefon1.Text
                .Telefon2 = txtPhone2.Text
                .Rabatt = txtCustomersDiscountValue.Text
                .IsActive = chkIsActiveContact.Checked
            End With
        End If
    End Sub

    Private Sub uicCommonGrid_AfterCreateNewItem(ByVal sender As Object, ByVal e As Kernel.StaticItemEventArgs) Handles uicCommonGrid.AfterCreateNewItem
        LoadCurrentItem(e.NewItem)
    End Sub

    Private Sub uicCommonGrid_ItemRowDoubleClick(ByVal key As String) Handles uicCommonGrid.ItemRowDoubleClick
        LoadCurrentItem(uicCommonGrid.FocussedItem)
        txtCompany.Focus()
    End Sub

    Private Sub iucAdressBook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        uicCommonGrid.Initialize()
        uicCommonGrid.Context = "Adressbuch"
        uicCommonGrid.SetDataSource(DataSourceList.Addressbook)



        uicCommonGrid.ShowFilterRow = True
        uicCommonGrid.Refresh()

        DefineSearchButtons()

        ' Neues Element vorbereiten
        CreateNewItem()

        DefineAutoCompleteBoxes()

    End Sub

    ''' <summary>
    ''' Definiert autocomplete für Postleitazahl, Stadt und Land
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DefineAutoCompleteBoxes()
        txtZipCode.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtTown.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtCountry.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        txtZipCode.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtTown.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCountry.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource

        txtZipCode.MaskBox.AutoCompleteCustomSource = GetZipCodes()
        txtTown.MaskBox.AutoCompleteCustomSource = GetTownNames()
        txtCountry.MaskBox.AutoCompleteCustomSource = GetCountyCodes()


    End Sub

    ''' <summary>
    ''' Ruft die Liste der Postleitzahlen ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetZipCodes() As AutoCompleteStringCollection
        Dim sc As New AutoCompleteStringCollection

        For Each item As Adress In MainApplication.getInstance.Adressen
            If Not sc.Contains(item.ZipCode.Trim) Then
                sc.Add(item.ZipCode.Trim)
            End If
        Next
        Return sc
    End Function

    ''' <summary>
    ''' Ruft die Liste der Städtenamen ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTownNames() As AutoCompleteStringCollection
        Dim sc As New AutoCompleteStringCollection

        For Each item As Adress In MainApplication.getInstance.Adressen
            If Not String.IsNullOrEmpty(item.Town) Then
                If Not sc.Contains(item.Town.Trim) Then
                    sc.Add(item.Town.Trim)
                End If
            End If

        Next
        Return sc
    End Function

    ''' <summary>
    ''' Ruft die Liste der Länder ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCountyCodes() As AutoCompleteStringCollection
        Dim sc As New AutoCompleteStringCollection

        For Each item As Adress In MainApplication.getInstance.Adressen
            If Not sc.Contains(item.Country.Trim) Then
                sc.Add(item.Country.Trim)
            End If
        Next
        Return sc
    End Function


    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnPrint Or actionButtons.btnSave Or actionButtons.btnNew Or actionButtons.btnDelete
        End Get

    End Property

    ''' <summary>
    ''' Leitet das Schliessen des Modules ein; Speichert eventuell geänderte Daten noch ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        If Me.ActiveItem IsNot Nothing Then
            If HasChanged And m_hasChanged Then
                Dim Result As DialogResult = AskChangedData()
                If Result = DialogResult.Yes Then
                    Save()
                End If
                If Result = DialogResult.Cancel Then
                    Return False
                End If
            End If
            Try
                Me.ActiveItem.Reload()
            Catch ex As Exception

            End Try



        End If

        Return True
    End Function

    Private Sub chkLinkDeliveryAdress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLinkDeliveryAdress.CheckedChanged
        If chkLinkDeliveryAdress.Checked Then
            txtDeliveryAdress.Text = txtInvoiceAdress.Text
            txtDeliveryAdress.Enabled = False
        Else
            txtDeliveryAdress.Enabled = True

        End If
    End Sub

    Private Sub mebInvoiceAdress_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceAdress.EditValueChanged
        If chkLinkDeliveryAdress.Checked Then
            txtDeliveryAdress.Text = txtInvoiceAdress.Text
        End If
    End Sub







    Private Sub ItemValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZipCode.TextChanged, txtTown.TextChanged, txtTelefon1.TextChanged, txtStreet.TextChanged, txtEmail.TextChanged, txtEbayID.TextChanged, txtCountry.TextChanged, txtFirstName.TextChanged, txtContactID.TextChanged, txtCompany.TextChanged, txtCustomersDiscountValue.TextChanged, txtNotes.TextChanged, txtMemo.TextChanged, MemoExEdit1.TextChanged, ButtonEdit2.TextChanged, ButtonEdit1.TextChanged, txtWorkOn.TextChanged, txtUstID.TextChanged, txtPhone2.TextChanged, txtIBAN.TextChanged, txtfax.TextChanged, txtBankName.TextChanged, txtBankLeitzahl.TextChanged, txtBankKonto.TextChanged, txtLastName.TextChanged
        m_hasChanged = True
        SetAdressWindow()
    End Sub

    ''' <summary>
    ''' Erstellt ein neuen Adresseintrag. Falls ein geänderter eintrag existiert, wird dieser erst gespeichert. Der Anwender kann den Vorgang abbrechen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateNewItem() Implements IModule.CreateNewItem
        If HasChanged Then
            Dim result As DialogResult = AskChangedData()
            If result = DialogResult.Cancel Then Exit Sub

            If result = DialogResult.Yes Then
                Save()
            End If
            If result = DialogResult.No Then m_hasChanged = False

        End If


        ActiveItem = MainApplication.getInstance.Adressen.GetNewItem ' Neues Objekt erstellen


    End Sub

    Private Sub IucSearchPanel1_SearchTextChanged(ByVal sender As Object, ByVal e As SearchTextEventArgs) Handles IucSearchPanel1.SearchTextChanged
        uicCommonGrid.SearchParameter(e.Text)

    End Sub



    Private Sub txtMemo_Properties_QueryPopUp(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMemo.Properties.QueryPopUp, MemoExEdit1.Properties.QueryPopUp
        txtMemo.Properties.PopupFormSize = New Size(txtMemo.Width, txtMemo.Properties.PopupFormSize.Height)
    End Sub

    Public Sub InitializeModule() Implements IModule.InitializeModule
        DefineSearchButtons()

        tabEditPanel.Width = SplitContainerControl1.Panel1.Width

    End Sub

    Private Sub btnResetInvoiceAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetInvoiceAdress.Click
        If m_activeItem IsNot Nothing Then
            m_activeItem.UserChangedAddressWindow = False
            SetAdressWindow()
        End If
    End Sub

    Private Sub SetAdressWindow()
        ' setzt bei einer Änderung das Adressfenster neui, sofern nicht vom Anwender bereits geändert

        Dim AdressText As String = ""

        Dim oldState As Boolean = m_isLoading
        If m_activeItem Is Nothing Then Exit Sub
        If Not m_activeItem.UserChangedAddressWindow Then
            m_isLoading = True
            If txtCompany.Text.Length > 0 Then
                AdressText = txtCompany.Text & vbCrLf
            End If

            If txtFirstName.Text.Length > 0 Then
                AdressText = AdressText & txtFirstName.Text & txtLastName.Text & vbCrLf
            End If

            If txtStreet.Text.Length > 0 Then
                AdressText = AdressText & txtStreet.Text & vbCrLf
            End If

            AdressText = AdressText & txtZipCode.Text & " " & txtTown.Text

            If Not My.Application.Culture.DisplayName.Contains(txtCountry.Text) Then
                AdressText = AdressText & vbCrLf & txtCountry.Text
            End If

            txtInvoiceAdress.Text = AdressText
            m_isLoading = oldState
        End If
    End Sub

    Private Sub SetSearchButtons(ByVal switch As Boolean)
        m_searchButton.Visible = switch
    End Sub

    ''' <summary>
    ''' Definiert einmalig den Suchmodus
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DefineSearchButtons()
        m_searchButton = New EditorButton(ButtonPredefines.Glyph, "Suche nach dieser Eigenschaft")
        m_searchButton.Image = My.Resources.view
        m_searchButton.Visible = False



        txtBankKonto.Properties.Buttons.Add(m_searchButton)
        txtBankLeitzahl.Properties.Buttons.Add(m_searchButton)
        txtBankName.Properties.Buttons.Add(m_searchButton)
        txtCompany.Properties.Buttons.Add(m_searchButton)
        txtContactID.Properties.Buttons.Add(m_searchButton)
        txtFirstName.Properties.Buttons.Add(m_searchButton)
        txtCountry.Properties.Buttons.Add(m_searchButton)
        txtEbayID.Properties.Buttons.Add(m_searchButton)
        txtEmail.Properties.Buttons.Add(m_searchButton)
        txtfax.Properties.Buttons.Add(m_searchButton)

        txtIBAN.Properties.Buttons.Add(m_searchButton)
        txtStreet.Properties.Buttons.Add(m_searchButton)
        txtTelefon1.Properties.Buttons.Add(m_searchButton)
        txtPhone2.Properties.Buttons.Add(m_searchButton)
        txtTown.Properties.Buttons.Add(m_searchButton)
        txtUstID.Properties.Buttons.Add(m_searchButton)
        txtWorkOn.Properties.Buttons.Add(m_searchButton)
        txtZipCode.Properties.Buttons.Add(m_searchButton)
    End Sub

    Private Sub mnuSerachIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearchIcons.Click
        SetSearchButtons(mnuSearchIcons.Checked)
    End Sub

    Private Sub SearchButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtZipCode.ButtonClick, txtTown.ButtonClick, txtTelefon1.ButtonClick, txtStreet.ButtonClick, txtEmail.ButtonClick, txtEbayID.ButtonClick, txtCountry.ButtonClick, txtFirstName.ButtonClick, txtContactID.ButtonClick, txtCompany.ButtonClick, txtCustomersDiscountValue.ButtonClick, ButtonEdit2.ButtonClick, ButtonEdit1.ButtonClick, txtLastName.ButtonClick

        If e.Button Is m_searchButton Then
            Dim srbBox As New frmSmallItemChooser
            srbBox.DataKind = frmSmallItemChooser.DataKindenum.Contacts
            srbBox.SearchProperties = CStr(CType(sender, Control).Tag)
            If srbBox.ShowDialog() = DialogResult.OK Then
                LoadCurrentItem(srbBox.SelectedItem)
            End If
        End If
    End Sub

    Private Sub txtWorkOn_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtEmail_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtEmail.Properties.ButtonClick
        If TypeOf e.Button.Tag Is String Then
            If e.Button.Tag.ToString = "email" Then
                If txtEmail.Text.Contains("@") Then
                    ' versuche ne Mail zu senden
                    Try
                        Process.Start("Mailto://" & txtEmail.Text)
                    Catch ex As Exception
                        MessageBox.Show("Eine Mail konnte nicht gesendet werden: " & vbCrLf & ex.Message, "Fehler beim senden einer EMail", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub btnOpenInGoogeMaps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenInGoogeMaps.Click
        OpenInMaps()
    End Sub

    ''' <summary>
    ''' Öffnet den aktuellen Kontakt als Karte im Web
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenInMaps()
        Try
            'http://maps.google.de/maps?f=q&source=s_q&hl=de&geocode=&q=Ihlanden+20,+44357+Mengede,+Dortmund

            Dim baseAdress As String = "http://maps.google.de/maps?f=q&source=s_q&hl=de&geocode=&"
            Dim webStreet As String = txtStreet.Text.Replace(" ", "+")
            Dim webZipCode As String = txtZipCode.Text.Replace(" ", "+")
            Dim webTown As String = txtTown.Text.Replace(" ", "+")
            Dim webcountry As String = txtCountry.Text.Replace(" ", "+")

            baseAdress = baseAdress & "q=" & webStreet & "," & webZipCode & "," & webTown & "," & webcountry
            Process.Start(baseAdress)

        Catch ex As Exception
            MessageBox.Show("Konnte nicht die Karten-Applikation öffnen: " & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub btnOpenJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenJournal.Click
        Try
            If m_activeItem IsNot Nothing Then
                If m_activeItem.ID <> 0 Then
                    Using journal As New frmJournal(MainUI)

                        journal.ShowAllByAdressID = m_activeItem.Kundennummer

                        If journal.ShowDialog = DialogResult.OK Then ' Falls ein Doppelklick gemaht wurde, dann das Teil auch öffnen
                            MainUI.OpenElementWindow(journal.SelectedDocument)

                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Open_Journal", "Error while opening the Journal from a given adress")
        End Try

    End Sub

    Private Sub txtInvoiceAdress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceAdress.TextChanged
        ' Hat der Anwender hier etwas geändert, dann das auch markieren
        If Not m_isLoading Then
            m_activeItem.UserChangedAddressWindow = True
        End If
    End Sub

    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            If m_activeItem IsNot Nothing Then
                Return m_activeItem.ReplikID
            Else
                Return String.Empty
            End If
        End Get
    End Property

    ''' <summary>
    ''' Löscht den aktuell in der Ansicht befindlichen Artikel
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteItem() Implements IModule.DeleteItem
        If m_activeItem IsNot Nothing Then
            If Not m_activeItem.HasUnresolvedContraints Then
                If AskDeleteData(m_activeItem.ToString) = DialogResult.Yes Then
                    m_activeItem.Delete()
                    '_Important: nach dem Löschen die Ansicht aufräumen! Es steht noch der alte Datensatz in den Eingabefeldern
                    ' (Kann auch im Grid gelöscht werden, dann weis die Oberfläche davon nichts)
                    SetEmptyTexts(Me)
                End If
            Else
                'TODO: NLS
                MessageBox.Show("Dieser Kontakt kann nicht gelöscht weren, da bereits Abhängigkeiten existieren." & vbCrLf &
                                "z.B. Als Lieferant verwendet oder es wurden Rechnungen oder Angebote geschrieben.", "Kontakt ist bereits verwendet", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If

        End If
    End Sub

    ''' <summary>
    ''' Löscht auf allen Textfeldern die Eingabemaske
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <remarks></remarks>
    Private Sub SetEmptyTexts(ByVal ctrl As Control)
        For Each item As Control In ctrl.Controls
            If TypeOf item Is TextEdit Then
                item.Text = String.Empty
            End If
            If item.Controls.Count > 0 Then
                SetEmptyTexts(item)
            End If
        Next
    End Sub

    Private Sub txtDeliveryAdress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeliveryAdress.TextChanged
        m_hasChanged = True
    End Sub

    ''' <summary>
    ''' Wartet mit dem Aufbauen der History, bis die Seite auch tatsählich aufgebaut wurde
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tabInformation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabInformation.SelectedPageChanged

        If tabInformation.SelectedTabPage Is tbpHistory Then
            RefreshHistory()
        End If
    End Sub

    ''' <summary>
    ''' Aktualisiert die History des Kontaktes
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshHistory()

        grdHistory.DataSource = ActiveItem.History
    End Sub

    Private Sub btnAddHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddHistory.Click
        CreateNewHistoryItem()
    End Sub

    Private Sub btnEditHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditHistory.Click
        EditSelectedHistoyrItem()
    End Sub

    ''' <summary>
    ''' Legt ein neues Benutzerdefiniertes History-Item an
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateNewHistoryItem()
        If Not ActiveItem.IsNew Then ' Neue Elemente können keine Historie haben
            Dim newItem As AddressHistoryItem = m_activeItem.History.GetNewItem()

            newItem.Adress = m_activeItem
            Using editForm As New frmEditHistory()
                editForm.HistoryItem = newItem

                If editForm.ShowDialog = DialogResult.OK Then ' Dann das Teil  speichern
                    newItem.SavewithoutTracking()
                    RefreshHistory()
                End If
            End Using
        End If

    End Sub

    ''' <summary>
    ''' Bearbeitet das gerade selektierte History-Item, falls möglich
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditSelectedHistoyrItem()
        Dim editItem As AddressHistoryItem

        If grvHistoryView.GetFocusedRow IsNot Nothing Then

            editItem = CType(grvHistoryView.GetFocusedRow, AddressHistoryItem)


            editItem.Adress = m_activeItem
            Using editForm As New frmEditHistory()
                editForm.HistoryItem = editItem

                If editForm.ShowDialog = DialogResult.OK Then ' Dann das Teil  speichern
                    editItem.SavewithoutTracking()
                    RefreshHistory()
                End If

            End Using
        End If

    End Sub

    Private Sub grvHistoryView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grvHistoryView.DoubleClick
        EditSelectedHistoyrItem()
    End Sub


    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get
            Return My.Resources.Contact_Card_16x16
        End Get
    End Property


    Private Sub chkIsActiveContact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsActiveContact.CheckedChanged
        Me.m_hasChanged = True
    End Sub

    Private Sub IucSearchPanel1_SetNextControl(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IucSearchPanel1.SetNextControl
        uicCommonGrid.Focus()
    End Sub


    Private Sub tabInformation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles tabInformation.SelectedPageChanged

    End Sub

    ''' <summary>
    ''' Lässt den Splitter zusammenfallen oder auseinander gehen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ToggleWorkspace()

        If m_workspaceExpanded Then
            SplitContainerControl1.SplitterPosition = tabEditPanel.Height ' Minimal

            m_workspaceExpanded = False
        Else
            SplitContainerControl1.SplitterPosition = 25 ' Minimal
            m_workspaceExpanded = True
        End If
    End Sub

    Private Sub btnMaximizeworkspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaximizeworkspace.Click
        ToggleWorkspace()
    End Sub

    Private Sub PanelControl1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelControl1.MouseDoubleClick
        ToggleWorkspace()
    End Sub

    Private Sub chkEnableTargetPayDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableTargetPayDate.CheckedChanged
        txtTargetPaydateDays.Enabled = chkEnableTargetPayDate.Checked
        If Not Me.m_isLoading Then
            m_hasChanged = True
        End If

    End Sub

    Private Sub txtTargetPaydateDays_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTargetPaydateDays.EditValueChanged
        If Not Me.m_isLoading Then
            m_hasChanged = True
        End If
    End Sub

    Private Sub txtTargetPaydateDays_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTargetPaydateDays.Validating
        ' Keine negativen Zahlungsziele oder > 1 Jahr (365 Tage) zulassen
        If CInt(txtTargetPaydateDays.EditValue) > 365 Or CInt(txtTargetPaydateDays.EditValue) < 0 Then
            e.Cancel = True
        End If

    End Sub

    Private Sub cmdNewDocumentFromAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDocumentFromAddress.Click
        CreateNewDocument(Me.ActiveItem)
    End Sub



    Private Sub grdHistory_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles grdHistory.DragDrop

        'For Each fItem As String In e.Data.GetFormats
        '    Debug.Print("FileDrop: " & fItem)
        'Next
        'If e.Data.GetDataPresent("Text") Then
        '    Dim filenames As String = CType(e.Data.GetData("Text", True), String)
        '    Debug.Print("Text:" & filenames)
        'End If



        'If e.Data.GetDataPresent("FileDrop") Then
        '    Dim filenames As String = CType(e.Data.GetData("FileDrop", True), String)
        '    Debug.Print(filenames)
        'End If

    End Sub

    Private Sub grdHistory_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles grdHistory.DragEnter
        If DragDropHelper.DataHasText(e.Data) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    'Drag Drop effekte

    Private Sub DragDropText(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtCompany.DragDrop, txtZipCode.DragDrop, txtTown.DragDrop, txtTelefon1.DragDrop, txtStreet.DragDrop, txtNotes.DragDrop, txtEmail.DragDrop, txtEbayID.DragDrop, txtCustomersDiscountValue.DragDrop, txtCountry.DragDrop, txtFirstName.DragDrop, txtLastName.DragDrop
        If DragDropHelper.DataHasText(e.Data) Then
            Dim textbox As TextEdit = CType(sender, TextEdit)

            textbox.Text &= DragDropHelper.DataGetText(e.Data)
        End If
    End Sub

    Private Sub DragEnterText(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtZipCode.DragEnter, txtTown.DragEnter, txtTelefon1.DragEnter, txtStreet.DragEnter, txtEmail.DragEnter, txtEbayID.DragEnter, txtCustomersDiscountValue.DragEnter, txtCountry.DragEnter, txtFirstName.DragEnter, txtCompany.DragEnter, txtNotes.DragEnter, txtLastName.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub

    Private Sub txtZipCode_Leave(sender As System.Object, e As System.EventArgs) Handles txtZipCode.Leave
        Try
            If String.IsNullOrEmpty(txtTown.Text) Then
                ' Stadt war noch nicht gewählt => Versuche anhand der PLZ die Stadt zu ermitteln

                txtTown.Text = MainApplication.getInstance.Adressen.GetTownByZipCode(txtZipCode.Text)
                txtTown.SelectAll()

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private m_mousePos As Point

    Private Sub txtEmail_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles txtZipCode.MouseDown, txtTown.MouseDown, txtTelefon1.MouseDown, txtStreet.MouseDown, txtLastName.MouseDown, txtFirstName.MouseDown, txtEmail.MouseDown, txtCountry.MouseDown, txtContactID.MouseDown, txtCompany.MouseDown
        m_mousePos = e.Location

    End Sub


    Private Sub txtEmail_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles txtZipCode.MouseMove, txtTown.MouseMove, txtTelefon1.MouseMove, txtStreet.MouseMove, txtLastName.MouseMove, txtFirstName.MouseMove, txtEmail.MouseMove, txtCountry.MouseMove, txtContactID.MouseMove, txtCompany.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then

        Else
            m_mousePos = Nothing
        End If
    End Sub
End Class