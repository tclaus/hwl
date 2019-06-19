Imports ClausSoftware.Kernel
Imports ClausSoftware.Data
Imports DevExpress.XtraGrid.Views.Layout.ViewInfo
Imports ClausSoftware.Tools
Imports DevExpress.XtraTreeList.Nodes

''' <summary>
''' Stellt die Oberfläche für die Artikelerwaltung dar.
''' </summary>
''' <remarks></remarks>
Public Class iucArticles
    Implements IModule

    Private m_moduleDisplayText As String = GetText("moduleNameArticle", "Artikel")
    Private m_workspaceExpanded As Boolean
    Private m_SplitterInMove As Boolean

    ''' <summary>
    ''' Grösse des Splitters nach dem ersten Laden
    ''' </summary>
    ''' <remarks></remarks>
    Private m_splitterOrgSize As Integer

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Public Sub New(ByVal myUI As MainUI)
        MyBase.New(myUI)
        InitializeComponent()
    End Sub


    Private Enum calucateSteps
        ''' <summary>
        ''' Startet eine Berchnung ab dem Einkaufspreis 
        ''' </summary>
        ''' <remarks></remarks>
        BasePrice
        ''' <summary>
        ''' Startet eine Berechnung ab dem Rabattwert
        ''' </summary>
        ''' <remarks></remarks>
        Discount

        ''' <summary>
        ''' Startet einen Berechnung ab dem Rohstoffpreis
        ''' </summary>
        ''' <remarks></remarks>
        Resources

        ''' <summary>
        ''' Startet die Preisberechnung ab dem Gewinnwert
        ''' </summary>
        ''' <remarks></remarks>
        Gewinn

        ''' <summary>
        ''' Ändert den Gewinnwert, durch Änderung des Endpreises
        ''' </summary>
        ''' <remarks></remarks>
        EndPrice

    End Enum



    Private m_symbolLocked As Image = My.Resources.Symbol_Security
    Private m_symbolUnlocked As Image = My.Resources.Symbol_Security_Unlocked

    ''' <summary>
    ''' Enthält den Bezeichner für das Abspeichern und Laden der Grid-Konfiguration
    ''' </summary>
    ''' <remarks></remarks>
    Private Const myContext As String = "Materialstamm"

    'Please enter any new code here, below the Interop code

    ''' <summary>
    ''' Enthält den einzelnen, im  Moment bearbeiteten Artikel
    ''' </summary>
    ''' <remarks></remarks>
    Private m_activeItem As Article
    Private m_hasChanged As Boolean

    ''' <summary>
    ''' Ist True, wenn Artikel gerade geladen wird
    ''' </summary>
    ''' <remarks></remarks>
    Private m_isLoading As Boolean
    ''' <summary>
    ''' Ist True, wenn gerade die Zahenwerte aufgefüllt werden
    ''' </summary>
    ''' <remarks></remarks>
    Private IsRefreshing As Boolean

    Private WithEvents m_imagesTimer As New Timer

    ''' <summary>
    ''' Pictures is Dirty - Zeigt an, ob die Bilder nachgeladen werden müssen, weil noch ein anderes Bild angezeigt wurde
    ''' </summary>
    ''' <remarks></remarks>
    Private m_currentPicturesIsDirty As Boolean

    ''' <summary>
    ''' Wenn ein neuer Artikel angelegt wurde, dann den Kurztext markieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ArticlesGrid_NewArticleCreated(ByVal sender As Object, ByVal e As StaticItemEventArgs) Handles ArticlesGrid.AfterArticleCreated

        ' Standard Steuersatz festlegen 
        Dim DefaultTax As TaxRate
        Dim TaxID As Integer = CInt(MainApplication.getInstance.Settings.GetSetting(RegistryValues.ArticleDefaultTax, RegistrySections.ModuleArticles, "2"))

        LoadCurrentItem(e.NewItem)

        DefaultTax = MainApplication.getInstance.TaxRates.GetItem(TaxID)
        If DefaultTax IsNot Nothing Then
            cboTax.SelectedItem = DefaultTax
        Else
            If cboTax.Properties.Items.Count > 0 Then
                cboTax.SelectedIndex = 0
            Else
                MessageBox.Show("Sie haben keine Steuersätze definiert." & vbCrLf &
                "Legen Sie im Menü 'Optionen'=>'Steuern' die Steuersätze fest", "Kein Steuersatz definiert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If

        txtName.Focus()
        txtName.SelectAll()
    End Sub

    Private Sub ArticlesGrid_SelectedArticleChanged(ByVal key As String) Handles ArticlesGrid.ItemRowDoubleClick
        LoadCurrentItem(ArticlesGrid.SelectedArticle)
    End Sub




    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        If Me.ActiveItem IsNot Nothing Then
            If HasChanged And m_hasChanged Then
                Dim Result As DialogResult = AskChangedData()
                If Result = DialogResult.Yes Then
                    SaveCurrentItem()
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


    ''' <summary>
    ''' Ruft den jewiels aktiven displaytext ab, der auch Anteile des aktuellen Atrikels enthält
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            'TODO: NLS
            If ActiveItem IsNot Nothing Then
                Return m_moduleDisplayText & ": " & ActiveItem.ShortDescription

            Else
                Return m_moduleDisplayText

            End If
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            If ActiveItem IsNot Nothing Then
                Return ActiveItem.HasChanged Or m_hasChanged
            Else
                Return m_hasChanged
            End If
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule
        ArticlesGrid.Context = myContext
        ArticlesGrid.Initialize()
        ArticlesGrid.ShowFilterRow = True

        ArticlesGrid.Refresh()

    End Sub

    Friend Sub LoadCurrentItem(ByVal currentItem As StaticItem)
        If ActiveItem IsNot Nothing Then


            If HasChanged And m_hasChanged Then
                Dim result As DialogResult = AskChangedData(ActiveItem.ShortDescription)
                If result = DialogResult.Cancel Then Exit Sub

                If result = DialogResult.Yes Then
                    SaveCurrentItem()

                End If

            End If
        End If

        ActiveItem = CType(currentItem, Article)
        ActiveItem.Reload()

    End Sub



    ''' <summary>
    ''' Füllt die standard-Listen auf zB Einheitenfelder
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillDefaultControls()
        MruBase.Properties.Items.Clear()
        MruBase1.Properties.Items.Clear()
        MruPack.Properties.Items.Clear()

        MruBase.Properties.Items.AddRange(MainApplication.getInstance.Units)
        MruBase1.Properties.Items.AddRange(MainApplication.getInstance.Units)
        MruPack.Properties.Items.AddRange(MainApplication.getInstance.Units)

        cboRabatt.Properties.Items.AddRange(MainApplication.getInstance.Discounts)

        cboTax.Properties.Items.Clear()
        cboTax.Properties.Items.AddRange(MainApplication.getInstance.TaxRates)

        cboWorkAccount.Properties.Items.Clear()
        cboWorkAccount.Properties.Items.AddRange(MainApplication.getInstance.LoanAccounts)


    End Sub



    ''' <summary>
    ''' Füllt die GUI-Steuerelemente mit den Daten aus dem Objekt
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillControls()
        If ActiveItem IsNot Nothing Then

            FireRefreshDisplayText(Me.DisplayText)

            m_imagesTimer.Enabled = False
            m_isLoading = True
            ClearImageLists()

            With ActiveItem
                cboTax.SelectedItem = ActiveItem.TaxRate

                txtName.Text = .ShortDescription
                txtLongText.Text = .LongDescription

                txtCreatedAt.EditValue = .CreatedAt

                chkIsActive.Checked = .IsActive

                lblSummSellings.Text = .SumOutBound.ToString()

                Dim t As New TimeSpan(.TimeInMinutes \ 60, .TimeInMinutes Mod 60, 0)

                txtWorkTimeSpan.EditValue = t

                txtArticleName.Text = .CustomerArticleNumber
                txteanCode.Text = .EAN
                txtInternalArticleNumber.Text = .InternalArticleNumber
                txtMemo.Text = .Notes

                ' Anzeige der Textboxen als Netto der Brutto festlegen
                txtSingleEK.EditValue = .EinzelEK


                chkFixedendPrice.Checked = ActiveItem.FixedPrice
                cboRabatt.SelectedItem = .Discount

                MruBase1.SelectedItem = .VerpackungsEinheit
                If .Lieferant IsNot Nothing Then
                    lblDistributor.Text = .Lieferant.GetExtendedAdressField
                Else
                    lblDistributor.Text = "Nicht festgelegt" 'TODO: NLS
                End If

                txtItemCount.Text = CStr(.MinDeliveryCount)
                ' txtItemCount.Text = CStr(.MinSellCount)

                MruPack.SelectedItem = .Recheneinheit


                If .GewinnType = GewinnType.IsAbsolute Then
                    cboAddValueStyle.SelectedIndex = 1
                    SetAddValueStyle(False)
                Else
                    cboAddValueStyle.SelectedIndex = 0
                    SetAddValueStyle(True)
                End If

                txtAufschlagAbsolut.Text = CStr(.GewinnValue)
                txtSingleVK.EditValue = .CalulatedEndPrice

                ' Nur einschalten, wenn auch das Tab angeschaltet ist
                If mainTable.SelectedTabPage Is tabPictures Then
                    m_imagesTimer.Start()
                    m_imagesTimer.Enabled = True
                End If

                ' Nur attribute nachladen und anzeigen lassen 
                If mainTable.SelectedTabPage Is tabAttributes Then
                    FillAttributesGrid()
                End If

                txtManufactorsArticleNumber.Text = ActiveItem.ManufactorsArticleNumber
                ' workitems
                chkIsWorkItem.Checked = .IsWorkItem
                cboWorkAccount.SelectedItem = .LoanAccount

                RefreshTaxFields()
                'If mainTable.SelectedTabPage Is tabStorage Then
                FillStorageData()
                'End If

                If m_activeItem.ID = -1 Then

                    txtName.Text = GetText("msgNewArticleDisplayName", "<Neuer Artikel>")
                End If


                If mainTable.SelectedTabPage Is tabComponents Then
                    FillSubArticles()
                End If

                FillPredecessorHirachy()

                m_isLoading = False
                m_hasChanged = False

            End With
        End If
    End Sub


    ''' <summary>
    ''' Leert die Anzeige der Bilder
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetImageLists()
        If ActiveItem IsNot Nothing Then
            If m_currentPicturesIsDirty Then
                grdImages.DataSource = m_activeItem.ImageList
                m_currentPicturesIsDirty = False
            End If
        End If
    End Sub

    Private Sub ClearImageLists()
        If ActiveItem IsNot Nothing Then
            grdImages.DataSource = Nothing
            m_currentPicturesIsDirty = True
        End If
    End Sub

    ''' <summary>
    ''' Erstellt ein neues Element
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateNewItem() Implements IModule.CreateNewItem
        If Me.HasChanged Then
            Dim result As DialogResult = AskChangedData()
            If result = DialogResult.Cancel Then Exit Sub

            If result = DialogResult.Yes Then
                SaveCurrentItem()
            End If
            If result = DialogResult.No Then m_hasChanged = False

        End If

        ActiveItem = MainApplication.getInstance.ArticleList.GetNewItem
        txtName.Focus()
        txtName.SelectAll()

    End Sub

    Public Overrides Sub Print() Implements IModule.Print
        Try

            Using printingDialog As New Printing.dlgSimplePrinting
                printingDialog.Grid = ArticlesGrid.grdArticles   ' Grid zuweisen
                printingDialog.DataSourceType = DataSourceList.Articles ' Type zuweisen
                printingDialog.SelectedItem = m_activeItem   ' Aktuelle Instanz anzeigen alssen
                printingDialog.ShowDialog()
            End Using

        Catch ex As Exception

            MainApplication.getInstance.log.WriteLog(ex, "Drucker Fehler", "Fehler im Druck-Dialog der Artikelliste")
            MessageBox.Show("Fehler beim Drucken der Artikelliste aufgetreten.", "Fehler aufgetreten", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

    End Sub

    Public Overrides Sub Save()
        MyBase.Save()
        SaveCurrentItem()
    End Sub

    ''' <summary>
    ''' Speichert das aktuelle Element 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

        If ActiveItem IsNot Nothing Then

            If ActiveItem.IsNew Then
                ActiveItem.GroupID = Me.ArticlesGrid.SelectedGroupID
            End If

            ActiveItem.Save()
            MainApplication.getInstance.SendMessage(GetText("msgsaved", "Gespeichert."))

            ActiveItem.ImageList.Save()
            ArticlesGrid.RefreshData()
            m_hasChanged = False

        End If
    End Sub

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnNew Or actionButtons.btnPrint Or actionButtons.btnSave
        End Get
    End Property

    Private Sub iucArticles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Node.nodesList.Clear()
        m_imagesTimer.Enabled = False
        m_imagesTimer.Interval = 350

        txtLongText.Width = Panel11.Width


        DefineControlNodes()

        FillDefaultControls()
        chkRessources.Checked = False
        chkDiscountEnable.Checked = False

        SetPriceVisibility()
        m_hasChanged = False
        Me.CreateNewItem()

        m_splitterOrgSize = SplitContainerControl1.SplitterPosition

        AddHandler ArticlesGrid.RenameTriggered, AddressOf StartRename

        txtName.Focus()

        MainApplication.getInstance.Languages.SetTextOnControl(cmsBomItems)
        MainApplication.getInstance.Languages.SetTextOnControl(cmsImages)

    End Sub

    ''' <summary>
    ''' Setzt die Sichtbarkeit der Preisberechnung, wie gesetzt ind en Optionen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetPriceVisibility()

        Dim resourcesVisibility As Boolean
        Dim discountsVisibility As Boolean

        discountsVisibility = CBool(MainApplication.getInstance.Settings.GetSetting(RegistryValues.ShowArticleDiscounts, RegistrySections.ModuleArticles, "0"))

        resourcesVisibility = CBool(MainApplication.getInstance.Settings.GetSetting(RegistryValues.ShowArticleRessources, RegistrySections.ModuleArticles, "0"))

        chkDiscountEnable.Visible = discountsVisibility
        tabPanelDiscounts.Visible = discountsVisibility
        chkDiscountEnable.Checked = False

        chkRessources.Visible = resourcesVisibility
        tabPanelResources.Visible = resourcesVisibility
        chkRessources.Checked = False

    End Sub

    Private Sub IucSearchPanel1_SearchTextChanged(ByVal sender As Object, ByVal e As SearchTextEventArgs) Handles IucSearchPanel1.SearchTextChanged
        ArticlesGrid.SetSearchParameter(e.Text)
    End Sub

    Private Sub btnAdressSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdressSearch.Click
        SelectAdress()
    End Sub

    ''' <summary>
    ''' Öffnet einen Suchdialog um eine Adresse auszuwählen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SelectAdress()
        Dim AdresSearch As New frmSmallItemChooser
        AdresSearch.DataKind = frmSmallItemChooser.DataKindenum.Contacts
        AdresSearch.Initialize()
        If AdresSearch.ShowDialog = DialogResult.OK Then
            If AdresSearch.SelectedItem IsNot Nothing Then
                m_activeItem.Lieferant = CType(AdresSearch.SelectedItem, Adress)
                lblDistributor.Text = m_activeItem.Lieferant.GetExtendedAdressField
            End If
        End If
    End Sub


    Private Sub MruBase1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MruBase1.SelectedIndexChanged, MruBase.SelectedIndexChanged
        If ActiveItem IsNot Nothing Then
            If sender Is MruBase Then
                MruBase1.SelectedItem = MruBase.SelectedItem
            Else
                MruBase.SelectedItem = MruBase1.SelectedItem
            End If
            m_hasChanged = True
            If MruBase1.SelectedItem IsNot Nothing Then
                lblBaseUnit.Text = MruBase1.SelectedItem.ToString

                'TODO: Freie String versuchen als Einheit aufzunehmen


                ActiveItem.VerpackungsEinheit = TryCast(MruBase1.SelectedItem, Unit)
            Else
                lblBaseUnit.Text = ""
                ActiveItem.VerpackungsEinheit = Nothing
            End If

        End If

    End Sub

    ''' <summary>
    ''' Ruft das gerade aktive Element ab oder legt es fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ActiveItem() As Kernel.Article
        Get
            Return m_activeItem
        End Get
        Set(ByVal value As Kernel.Article)
            m_activeItem = value

            FillControls()

            MainUI.MRUManager.AddMRUElement(value)
        End Set
    End Property


    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            If ActiveItem IsNot Nothing Then
                Return ActiveItem.ReplikID
            Else
                Return String.Empty
            End If
        End Get
    End Property


    Private Sub txtGewinn_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_activeItem.GewinnRelativ = CDec(txtAufschlagAbsolut.EditValue)

    End Sub



    Private Sub ItemValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongText.TextChanged, txtName.TextChanged
        m_hasChanged = True
    End Sub

    Private Sub txtItemCount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemCount.EditValueChanged
        If ActiveItem IsNot Nothing Then
            ActiveItem.MinDeliveryCount = CDec(txtItemCount.EditValue)

            SetLabelFactor()

        End If
    End Sub

    ''' <summary>
    ''' Berechnet aus den einzelpreisen den Summenpreis
    ''' (rechte Seite der Preistabelle)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetMUltiplyUnits()
        Dim oldRefreshing As Boolean = IsRefreshing
        IsRefreshing = True
        Dim factor As Decimal = m_activeItem.MinDeliveryCount

        txtSingleEKMulti.EditValue = factor * CDec(txtSingleEK.EditValue)
        txtRabattPreisMulti.EditValue = factor * CDec(txtRabattpreis.EditValue)
        txtRohstoffPreisMulti.EditValue = factor * CDec(txtRohstoffpreis.EditValue)
        txtAufschlagMulti.EditValue = factor * CDec(txtAufschlagAbsolut.EditValue)
        txtVerkaufspreisMulti.EditValue = factor * CDec(txtVerkaufspreis.EditValue)
        IsRefreshing = oldRefreshing

    End Sub

    Private Sub SetLabelFactor()
        lblFactor.Text = CStr(txtItemCount.EditValue)
        lblFactorGewinn.Text = CStr(txtItemCount.EditValue)
        lblFactorDiscount.Text = CStr(txtItemCount.EditValue)
        lblFactorResources.Text = CStr(txtItemCount.EditValue)
        lblFactorVerkauf.Text = CStr(txtItemCount.EditValue)

    End Sub

    ''' <summary>
    ''' Aktualisiert die Textfelder mit den Preisen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshPriceLists(ByVal calculateStep As calucateSteps)
        If m_activeItem IsNot Nothing Then

            If IsRefreshing Then Exit Sub
            If m_isLoading Then Exit Sub
            IsRefreshing = True
            Select Case calculateStep
                Case calucateSteps.BasePrice

                    txtRabattpreis.EditValue = ActiveItem.DiscountPrice
                    txtRohstoffpreis.EditValue = ActiveItem.GetResourcesPrice
                    txtVerkaufspreis.EditValue = ActiveItem.CalulatedEndPrice
                    cboAddValueStyle.SelectedIndex = 1
                    txtAufschlagAbsolut.EditValue = ActiveItem.CalulatedEndPrice - ActiveItem.GetResourcesPrice
                    ' endpreis

                Case calucateSteps.Discount

                    txtRabattpreis.EditValue = ActiveItem.DiscountPrice
                    txtRohstoffpreis.EditValue = ActiveItem.GetResourcesPrice

                    txtVerkaufspreis.EditValue = ActiveItem.CalulatedEndPrice


                Case calucateSteps.Resources
                Case calucateSteps.Gewinn ' endpreis berechnen

                    txtVerkaufspreis.EditValue = ActiveItem.CalulatedEndPrice

                Case calucateSteps.EndPrice
                    ' ein geänderter Endpreis verändert den Gewinn/Aufschlag
                    If ActiveItem.FixedPrice Then
                        cboAddValueStyle.SelectedIndex = 1
                    End If

                    RefreshProfit()

            End Select

            ActiveItem.EinzelVK = ActiveItem.CalulatedEndPrice

            IsRefreshing = False
        End If

    End Sub




    Private Function GetRessourcePrice(ByVal currentPrice As Decimal) As Decimal
        Return currentPrice
    End Function

    Private Sub txtSingleEK_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSingleEK.EditValueChanged, txtsingleEK1.EditValueChanged

        'If m_isLoading Then Exit Sub
        If IsRefreshing Then Exit Sub
        IsRefreshing = True
        Dim editfield As DevExpress.XtraEditors.BaseEdit = CType(sender, DevExpress.XtraEditors.BaseEdit)
        If editfield.EditValue IsNot Nothing Then
            m_activeItem.EinzelEK = CDec(editfield.EditValue)

            Node.nodesList(editfield).SetValue()

            Node.nodesList(editfield).ResetVisited()
        End If

        IsRefreshing = False
    End Sub


    Private Sub cboRabatt_Properties_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboRabatt.Properties.ButtonClick
        If e.Button.Tag IsNot Nothing Then
            OpenDiscountsEditor()
        End If

    End Sub

    ''' <summary>
    ''' Opens the simple Rabattzeditor
    ''' </summary>
    ''' <remarks></remarks>
    Sub OpenDiscountsEditor()
        Dim frm As New frmSimpleEdit(DataSourceList.Discounts)
        frm.ShowDialog()

    End Sub

    Private Sub cboRabatt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRabatt.SelectedIndexChanged
        If m_activeItem IsNot Nothing And cboRabatt.SelectedItem IsNot Nothing Then
            m_activeItem.Discount = CType(cboRabatt.SelectedItem, Discount)

            RefreshPriceLists(calucateSteps.Discount)

        End If
    End Sub

    Private Sub txtsingleEK1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_activeItem.EinzelEK = CDec(txtSingleEK.EditValue)

    End Sub

    Private Sub SetAddValueStyle(ByVal isRelativ As Boolean)
        Dim info As New DevExpress.Utils.SuperToolTipSetupArgs
        info.Title.Text = "Aufschlagsberechnung"

        If isRelativ Then

            lblGewinnzuschlag.Text = "Aufschlag (Relativ)"
            info.Contents.Text = "Schlägt auf den absoluten Betrag diesen Prozentsatz auf"

            txtAufschlagAbsolut.Properties.DisplayFormat.FormatString = "n2"
            If m_isLoading Then Exit Sub

            m_activeItem.GewinnRelativ = m_activeItem.GewinnRelativ
        Else
            lblGewinnzuschlag.Text = "Aufschlag (Absolut)"

            info.Contents.Text = "Schlägt auf den absoluten Betrag diesen Betrag auf"

            txtAufschlagAbsolut.Properties.DisplayFormat.FormatString = "c2"
            If m_isLoading Then Exit Sub

            m_activeItem.GewinnAbsolut = m_activeItem.GewinnAbsolut

        End If

        txtAufschlagAbsolut.EditValue = m_activeItem.GewinnValue

        If CDec(txtAufschlagAbsolut.EditValue) < 0 Then
            txtAufschlagAbsolut.ForeColor = Color.Red
        Else
            txtAufschlagAbsolut.ForeColor = Nothing
        End If

        lblGewinnzuschlag.SuperTip = New DevExpress.Utils.SuperToolTip
        lblGewinnzuschlag.SuperTip.Setup(info)

        RefreshPriceLists(calucateSteps.Gewinn)

    End Sub



    Private Sub cboAddValueStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddValueStyle.SelectedIndexChanged

        If IsRefreshing Then Exit Sub

        RefreshProfit()
    End Sub

    ''' <summary>
    ''' Aktualisiert den Aufschlag anhand der Auswahl Absoult / Relativ und berechnet den Verkaufspreis neu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshProfit()
        If CStr(cboAddValueStyle.SelectedItem) = "%" Then

            SetAddValueStyle(True)
        Else
            SetAddValueStyle(False)

        End If


    End Sub


    Private Sub txtGewinn_EditValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAufschlagAbsolut.EditValueChanged
        If m_activeItem IsNot Nothing Then



            If m_isLoading Then Exit Sub
            If IsRefreshing Then Exit Sub
            IsRefreshing = True

            If CStr(cboAddValueStyle.SelectedItem) = "%" Then
                m_activeItem.GewinnRelativ = CDec(txtAufschlagAbsolut.EditValue)
            Else
                m_activeItem.GewinnAbsolut = CDec(txtAufschlagAbsolut.EditValue)
            End If

            ' Rote Farbe setzen, wenn Gewinn negativ
            If m_activeItem.GewinnValue >= 0 Then
                txtAufschlagAbsolut.ForeColor = Color.Black
            Else
                txtAufschlagAbsolut.ForeColor = Color.Red
            End If


            Dim editfield As DevExpress.XtraEditors.BaseEdit = CType(sender, DevExpress.XtraEditors.BaseEdit)

            Node.nodesList(editfield).SetValue()

            Node.nodesList(editfield).ResetVisited()

            IsRefreshing = False

        End If
    End Sub




    Private Sub txtVerkaufspreis_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVerkaufspreis.EditValueChanged, txtSingleVK.EditValueChanged


        If m_isLoading Then Exit Sub
        If IsRefreshing Then Exit Sub
        IsRefreshing = True

        Dim editfield As DevExpress.XtraEditors.BaseEdit = CType(sender, DevExpress.XtraEditors.BaseEdit)
        m_activeItem.EinzelVK = CDec(editfield.EditValue)

        Node.nodesList(editfield).SetValue()

        Node.nodesList(editfield).ResetVisited()

        IsRefreshing = False

    End Sub

    Private Sub m_imagesTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_imagesTimer.Tick
        m_imagesTimer.Enabled = False
        SetImageLists()

    End Sub

    ''' <summary>
    ''' Läd verzögerte Daten des Artikels
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillStorageData()
        Try
            Dim LastSoldDate As Date = m_activeItem.LastSelling

            If LastSoldDate = Date.MinValue Then
                lblLastSoldDate.Text = GetText("msgNoSoldItemsyet", "-bisher kein Verkauf-")
            Else
                lblLastSoldDate.Text = LastSoldDate.ToString("d")
            End If
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "FillSoldItemsValue", "Error in geting LastSellingDate")
        End Try
    End Sub

    ''' <summary>
    ''' Füllt einen Baum mit unter-Artikeln auf (Zusammengestzte Artikel / Leistungen) 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillSubArticles()
        If m_activeItem IsNot Nothing Then
            trvsubArticles.DataSource = m_activeItem.SubArticles
            RestoreTreeStyles(trvsubArticles, "BomList")
        End If

    End Sub
    Private Sub grdImages_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdImages.DragDrop

        Dim ar As Array = CType(e.Data.GetData("FileDrop"), Array)

        Dim files(ar.Length) As String

        ar.CopyTo(files, 0)


        AddImagesFromFileDrop(files)
    End Sub

    Private Sub grdImages_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdImages.DragEnter
        Dim formats As String() = e.Data.GetFormats
        Debug.Print(formats.ToString)

        Dim ImageOK As Boolean

        For Each item As String In formats
            If item.Equals("DragImageBits") Then
                ImageOK = True
            End If
        Next

        If ImageOK Then
            Dim ar As Array = CType(e.Data.GetData("FileName"), Array)
            For Each o As String In ar
                If System.IO.File.Exists(o) Then
                    e.Effect = DragDropEffects.Copy
                End If

            Next

        End If


    End Sub

    Private Sub mnuNewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewImage.Click
        AddNewImageFromFilesystem()


    End Sub

    ''' <summary>
    ''' Öffnet einen Dateidialog und läst Bilder auswählen zum einfügen in den Artikel
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddNewImageFromFilesystem()
        Dim filedialog As New Vista_Api.OpenFileDialog
        filedialog.Multiselect = True
        filedialog.Filter = "Bilddateien|*.png;*.gif;*.jpg"
        If filedialog.ShowDialog() = DialogResult.OK Then
            AddImagesFromFileDrop(filedialog.FileNames)
        End If

    End Sub

    Private Sub txtRabattpreis_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRabattpreis.EditValueChanged

        txtRabattPreisMulti.EditValue = CDec(txtRabattpreis.EditValue) * m_activeItem.MinDeliveryCount

    End Sub



    Private Sub chkDiscountEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiscountEnable.CheckedChanged

        tabPanelDiscounts.Visible = chkDiscountEnable.Checked


    End Sub

    Private Sub chkRessources_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRessources.CheckedChanged
        tabPanelResources.Visible = chkRessources.Checked
    End Sub

    Private Sub MainTable_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles mainTable.SelectedPageChanged

        If e.Page Is tabPictures Then
            SetImageLists()
            Exit Sub
        End If

        If e.Page Is tabAttributes Then
            FillAttributesGrid()
            Exit Sub
        End If

        If e.Page Is tabComponents Then
            FillSubArticles()
            RefreshCalculatedBOMPrice()
        End If

    End Sub

    ''' <summary>
    ''' Berechnet den Endpreis vom BOM neu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshCalculatedBOMPrice()
        If m_activeItem IsNot Nothing Then
            lblBomSumBasePrice.Text = m_activeItem.SubArticles.GetTotalBasePrice.ToString("c")
            lblBomSumEndPrice.Text = m_activeItem.SubArticles.GetTotalendPrice.ToString("c")
            lblBomCalculatedTime.Text = m_activeItem.SubArticles.GetTotalTime.ToString()
        Else
            lblBomSumBasePrice.Text = "0"
            lblBomSumEndPrice.Text = "0"
            lblBomCalculatedTime.Text = "00:00"

        End If

    End Sub
    Private Sub chkFixedendPrice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFixedendPrice.CheckedChanged

        If chkFixedendPrice.Checked Then
            chkFixedendPrice.Image = m_symbolLocked
            tabPanelGwinn.Enabled = False
        Else
            chkFixedendPrice.Image = m_symbolUnlocked
            tabPanelGwinn.Enabled = True
        End If


        If m_activeItem IsNot Nothing Then
            m_activeItem.FixedPrice = chkFixedendPrice.Checked
            cboAddValueStyle.SelectedIndex = 1 ' bei "Fester endpreis" kann es keinen Prozentualen Aufschlag geben
        End If
    End Sub

    Private Sub LayoutView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdImages.MouseDoubleClick, lvImages.DoubleClick, grdImages.DoubleClick
        ' prüfe, wo doppel geklickt wurde; auf einem eintzrag
        Dim hi As LayoutViewHitInfo = lvImages.CalcHitInfo(grdImages.PointToClient(MousePosition))
        If hi.InCard Then
            If hi.HitField.Column.ColumnType.Name = GetType(Image).Name Then
                ' Doppelklick auf ein Image-Feld
                Dim t As New HWLInterops.ArticlePictureBox()
                t.ShowImage(CType(lvImages.GetRow(hi.RowHandle), ImageData))
            End If
        End If
    End Sub

    ''' <summary>
    ''' Bild aus der Zwischenablage einfügen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InsertPicture()


        Dim ContainsImageFile As Boolean
        If My.Computer.Clipboard.ContainsFileDropList Then
            ContainsImageFile = CheckFileListForValidImages(My.Computer.Clipboard.GetFileDropList)
        End If

        If ContainsImageFile Then

            ' Fügt Dateien der auflistung hinzu
            Dim filedrop As Specialized.StringCollection = My.Computer.Clipboard.GetFileDropList()
            Dim files(filedrop.Count) As String

            filedrop.CopyTo(files, 0)

            AddImagesFromFileDrop(files)
        ElseIf My.Computer.Clipboard.ContainsImage Then

            ' Beim Clipboard gibt es keinen Filename
            Dim picture As Image
            picture = My.Computer.Clipboard.GetImage

            Dim newImageData As ImageData = AddImageToList(picture)
            newImageData.FileDate = Date.Today
            newImageData.Name = "" '  bei Teieln eines Bildes, leider keine näherern Infos
            newImageData.Description = ""


        End If
    End Sub

    ''' <summary>
    ''' Fügt aus der Liste der Dateien diese der Bilder-Auflistung hinzu
    ''' </summary>
    ''' <param name="filelist"></param>
    ''' <remarks></remarks>
    Sub AddImagesFromFileDrop(ByVal filelist As String())
        For Each file As String In filelist
            Try
                If System.IO.File.Exists(file) Then
                    Debug.Print(file)


                    Dim img As Image = System.Drawing.Image.FromFile(file)
                    Dim newImage As ImageData
                    newImage = AddImageToList(img)
                    newImage.SetByFile(file)

                End If

            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try


        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="newImage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AddImageToList(ByVal newImage As Image) As ImageData
        Dim newImageData As ImageData = m_activeItem.ImageList.GetNewItem()
        newImageData.Image = newImage
        newImageData.ReferenceID = m_activeItem.ReplikID
        m_activeItem.ImageList.Add(newImageData)
        m_hasChanged = True

        Return newImageData

    End Function


    Private Sub mnuDeleteImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteImage.Click
        If lvImages.FocusedRowHandle >= 0 Then

            Dim item As ImageData = CType(lvImages.GetRow(lvImages.FocusedRowHandle), ImageData)

            If item IsNot Nothing Then

                item.Delete()

                m_hasChanged = True
            End If

        End If
    End Sub

    Private Sub chkIsActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsActive.CheckedChanged
        If m_activeItem IsNot Nothing Then
            m_activeItem.IsActive = chkIsActive.Checked
        End If

    End Sub

    Public Sub DeleteItem() Implements IModule.DeleteItem
        If m_activeItem IsNot Nothing Then
            ArticlesGrid.DeleteSelectedArticles()
        End If
    End Sub

    Private Sub txtName_Textchanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtName.TextChanged
        If m_isLoading Then Exit Sub
        If m_activeItem IsNot Nothing Then
            m_activeItem.ShortDescription = txtName.Text
        End If
    End Sub

    Private Sub cmsImages_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsImages.Opening

        Dim ContainsImageFile As Boolean
        If My.Computer.Clipboard.ContainsFileDropList Then
            ContainsImageFile = CheckFileListForValidImages(My.Computer.Clipboard.GetFileDropList)
        End If

        If My.Computer.Clipboard.ContainsImage() Or ContainsImageFile Then
            mnuInsert.Visible = True
        Else
            mnuInsert.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Prüft eine gegebene Dateiliste auf gültige Bilddaten
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckFileListForValidImages(ByVal fileList As Specialized.StringCollection) As Boolean
        Dim validImage As Boolean
        For Each item As String In fileList
            ' wenn alle dateien Bilder sind, dann OK 
            Try
                Using newImage As Image = System.Drawing.Image.FromFile(item)
                    validImage = True
                End Using
            Catch
                validImage = False
                Exit For
            End Try
        Next
        Return validImage

    End Function

    Private Sub mnuInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInsert.Click
        InsertPicture()
    End Sub

    Private Sub cboTax_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTax.SelectedIndexChanged
        If m_activeItem IsNot Nothing Then
            If Not m_isLoading Then

                m_activeItem.TaxRate = CType(cboTax.SelectedItem, TaxRate)

                RefreshTaxFields()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Berechnet die Steuer-Felder neu und zeigt diese an
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshTaxFields()

        IsRefreshing = True
        txtSingleEKBrutto.EditValue = m_activeItem.EinzelEK * (1 + (m_activeItem.TaxRate.TaxValue / 100))
        txtSingleVKbrutto.EditValue = m_activeItem.CalulatedEndPrice * (1 + (m_activeItem.TaxRate.TaxValue / 100))
        IsRefreshing = False

    End Sub

    Private Sub txtLongText_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongText.EditValueChanged
        If m_activeItem IsNot Nothing Then
            m_activeItem.LongDescription = txtLongText.Text

        End If
    End Sub

    Private Sub txtArticleName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArticleName.EditValueChanged
        If m_activeItem IsNot Nothing Then
            m_activeItem.CustomerArticleNumber = txtArticleName.Text

        End If
    End Sub

    Private Sub txtName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.EditValueChanged
        If m_activeItem IsNot Nothing Then
            m_activeItem.ShortDescription = txtName.Text
        End If


    End Sub


    Private Sub txtSingleVKbrutto_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSingleVKbrutto.EditValueChanged

        'If m_isLoading Then Exit Sub
        If IsRefreshing Then Exit Sub
        IsRefreshing = True

        Dim editfield As DevExpress.XtraEditors.BaseEdit = CType(sender, DevExpress.XtraEditors.BaseEdit)
        m_activeItem.EinzelVK = CDec(editfield.EditValue) / (1 + m_activeItem.TaxRate.TaxValue / 100)

        Node.nodesList(editfield).SetValue()

        Node.nodesList(editfield).ResetVisited()

        IsRefreshing = False


    End Sub


    Private Sub txtWorkTimeSpan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWorkTimeSpan.EditValueChanged
        If m_activeItem IsNot Nothing Then

            Dim time As Date = txtWorkTimeSpan.Time
            Dim minutes As Integer = CInt(time.Ticks \ TimeSpan.TicksPerMinute)

            m_activeItem.TimeInMinutes = minutes
            SetWorkItemCost()

            If m_activeItem.LoanAccount IsNot Nothing Then
                ' Berechne nun den einzel-EK
                ' EK = Stundenpreis * Minuten/60
                Dim singleWorkEK As Decimal = CDec(m_activeItem.LoanAccount.PricePerHour * (m_activeItem.TimeInMinutes / 60))
                m_activeItem.EinzelEK = singleWorkEK
                IsRefreshing = True
                txtSingleEK.EditValue = m_activeItem.EinzelEK
                IsRefreshing = False

                RefreshPriceLists(calucateSteps.BasePrice)
            End If
        End If
    End Sub

    Private Sub cboWorkAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If m_activeItem IsNot Nothing Then
            m_activeItem.LoanAccount = CType(cboWorkAccount.SelectedItem, LoanAccount)

        End If
    End Sub


    Private Sub txtVerkaufspreisMulti_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuAddArticles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddArticles.Click
        Dim frm As New frmSmallItemChooser
        frm.DataKind = frmSmallItemChooser.DataKindenum.Articles
        frm.Initialize()
        If frm.ShowDialog() = DialogResult.OK Then

            Dim article As ClausSoftware.Data.StaticItem = frm.SelectedItem

            Dim newLink As BOM.ArticleLink = m_activeItem.SubArticles.GetNewItem(m_activeItem)
            newLink.Article = CType(article, Kernel.Article)
            newLink.Save()
            m_activeItem.SubArticles.Add(newLink)

            ' m_activeItem.SubArticles.Add(CType(article, ClausSoftware.Kernel.Article))
            trvsubArticles.RefreshDataSource()
            trvsubArticles.Refresh()
            ' InsertSubItemAtCurrentPosition(article)

            RefreshCalculatedBOMPrice()
        End If

    End Sub


    Private Sub InsertSubItemAtCurrentPosition(ByVal newArticle As Article)


    End Sub

    Private Sub trvsubArticles_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles trvsubArticles.DragEnter

        Dim articlesList As New ListOfArticles()

        If e.Data.GetDataPresent(GetType(ListOfArticles)) Then

            Dim isValid As Boolean = True
            articlesList = CType(e.Data.GetData(articlesList.GetType), ListOfArticles)
            For Each targetItem As Kernel.Article In articlesList.ArticlesList
                ' keine Rekursion aufbauen 


                For Each itemLink As BOM.ArticleLink In m_activeItem.SubArticles
                    'If itemLink.ArticleID = targetItem.Key Then
                    '    isValid = False
                    '    "
                    '    Exit For
                    'End If
                    If m_activeItem.Key = targetItem.Key Then
                        isValid = False
                        Exit For
                    End If
                Next


            Next
            If isValid Then
                e.Effect = DragDropEffects.Copy
            End If
        End If

    End Sub

    Private Sub trvsubArticles_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles trvsubArticles.DragDrop
        Dim articlesList As New ListOfArticles()

        If e.Data.GetDataPresent(GetType(ListOfArticles)) Then

            Dim isValid As Boolean = True
            articlesList = CType(e.Data.GetData(articlesList.GetType), ListOfArticles)
            For Each targetItem As Kernel.Article In articlesList.ArticlesList

                Dim newLink As BOM.ArticleLink = m_activeItem.SubArticles.GetNewItem(m_activeItem)
                newLink.Article = targetItem
                newLink.Save()
                m_activeItem.SubArticles.Add(newLink)


            Next
        End If


    End Sub

    Private Sub trvsubArticles_FocusedNodeChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles trvsubArticles.FocusedNodeChanged
        If e.Node IsNot Nothing Then
            Dim nodeArticle As BOM.ArticleLink = CType(trvsubArticles.GetDataRecordByNode(e.Node), BOM.ArticleLink)
            If nodeArticle IsNot Nothing Then
                If nodeArticle.Article IsNot Nothing Then
                    e.Node.HasChildren = nodeArticle.Article.SubArticles.Count > 0
                Else
                    ' Fehler, ein Kind-Artikel sollte es geben
                    e.Node.HasChildren = False
                End If
            End If
        End If

    End Sub

    Private Sub trvsubArticles_AfterDragNode(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles trvsubArticles.AfterDragNode

    End Sub

    Private Sub mnuEditPictures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditPictures.Click
        lvImages.OptionsBehavior.Editable = mnuEditPictures.Checked

    End Sub

    Private Sub txtArticleID_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txteanCode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txteanCode.EditValueChanged
        If m_activeItem IsNot Nothing Then
            m_activeItem.EAN = CStr(txteanCode.EditValue)
        End If
    End Sub

    Private Sub txtInternalArticleNumber_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If m_activeItem IsNot Nothing Then
            m_activeItem.InternalArticleNumber = txtInternalArticleNumber.Text
        End If
    End Sub

    ''' <summary>
    ''' Definiert abhängigkeiten der Benutzercontrols
    ''' </summary>
    ''' <remarks></remarks>
    Sub DefineControlNodes()


        Dim newNode As Node
        ' SingleEK (obere Leiste)
        newNode = New Node(txtSingleEK, New delGetValue(AddressOf GetEK))
        newNode.NextNodes.Add(New Node(txtsingleEK1, New delGetValue(AddressOf GetEK)))
        newNode.NextNodes.Add(New Node(txtSingleEKBrutto, New delGetValue(AddressOf GetEKBrutto)))
        newNode.NextNodes.Add(New Node(txtSingleVK, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtSingleEKMulti, New delGetValue(AddressOf GetEKMulti)))

        newNode.NextNodes.Add(New Node(txtVerkaufspreisMulti, New delGetValue(AddressOf GetVKMultiBrutto)))

        ' einzel-EK (Preistabelle)
        newNode = Node.nodesList.Item(txtsingleEK1)
        newNode.NextNodes.Add(Node.nodesList.Item(txtSingleEK))
        newNode.NextNodes.Add(New Node(txtSingleEKBrutto, New delGetValue(AddressOf GetEKBrutto)))
        newNode.NextNodes.Add(New Node(txtSingleVK, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtSingleEKMulti, New delGetValue(AddressOf GetEKMulti)))
        newNode.NextNodes.Add(New Node(txtVerkaufspreisMulti, New delGetValue(AddressOf GetVKMultiBrutto)))

        ' Einzel einkauf Brutto (obere Leiste)
        newNode = Node.nodesList.Item(txtSingleEKBrutto)
        newNode.NextNodes.Add(New Node(txtSingleEK, New delGetValue(AddressOf GetSingleEKNetto)))
        newNode.NextNodes.Add(New Node(txtsingleEK1, New delGetValue(AddressOf GetSingleEKNetto)))

        newNode.NextNodes.Add(New Node(txtSingleVK, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtSingleVKbrutto, New delGetValue(AddressOf GetSingleVKBrutto)))
        newNode.NextNodes.Add(New Node(txtVerkaufspreis, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtSingleEKMulti, New delGetValue(AddressOf GetEKMulti)))
        newNode.NextNodes.Add(New Node(txtVerkaufspreisMulti, New delGetValue(AddressOf GetVKMultiBrutto)))

        ' Brutto VK)
        newNode = Node.nodesList(txtSingleVKbrutto)
        newNode.NextNodes.Add(New Node(txtSingleVK, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtVerkaufspreis, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtSingleEKMulti, New delGetValue(AddressOf GetEKMulti)))
        newNode.NextNodes.Add(New Node(txtVerkaufspreisMulti, New delGetValue(AddressOf GetVKMultiBrutto)))

        newNode.NextNodes.Add(New Node(txtAufschlagAbsolut, New delGetValue(AddressOf GetAufschlag)))


        ' Netto VK geändert (obere Leiste)
        newNode = Node.nodesList(txtSingleVK)
        newNode.NextNodes.Add(New Node(txtSingleVKbrutto, New delGetValue(AddressOf GetSingleVKBrutto)))
        newNode.NextNodes.Add(New Node(txtVerkaufspreis, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtAufschlagAbsolut, New delGetValue(AddressOf GetAufschlag)))
        newNode.NextNodes.Add(New Node(txtSingleEKMulti, New delGetValue(AddressOf GetEKMulti)))
        newNode.NextNodes.Add(New Node(txtVerkaufspreisMulti, New delGetValue(AddressOf GetVKMultiBrutto)))

        'VK multi hat sich geändert
        newNode = Node.nodesList(txtVerkaufspreisMulti)
        newNode.NextNodes.Add(New Node(txtSingleVK, New delGetValue(AddressOf GetSingleVK)))

        ' Netto VK geändert (Preistabelle)
        newNode = Node.nodesList(txtVerkaufspreis)
        newNode.NextNodes.Add(New Node(txtSingleVKbrutto, New delGetValue(AddressOf GetSingleVKBrutto)))
        newNode.NextNodes.Add(New Node(txtSingleVK, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtAufschlagAbsolut, New delGetValue(AddressOf GetAufschlag)))
        newNode.NextNodes.Add(New Node(txtSingleEKMulti, New delGetValue(AddressOf GetEKMulti)))
        newNode.NextNodes.Add(New Node(txtVerkaufspreisMulti, New delGetValue(AddressOf GetVKMultiBrutto)))

        'Gewinn /Aufschlag geändert
        newNode = Node.nodesList(txtAufschlagAbsolut)
        newNode.NextNodes.Add(New Node(txtVerkaufspreis, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtSingleVK, New delGetValue(AddressOf GetSingleVK)))
        newNode.NextNodes.Add(New Node(txtSingleEKMulti, New delGetValue(AddressOf GetEKMulti)))
        newNode.NextNodes.Add(New Node(txtSingleVKbrutto, New delGetValue(AddressOf GetSingleVKBrutto)))


    End Sub

    Private Function GetAufschlag() As Decimal
        Return m_activeItem.GewinnValue
    End Function

    Private Function GetVKMultiBrutto() As Decimal
        Return m_activeItem.CalulatedEndPrice / m_activeItem.MinDeliveryCount
    End Function

    ''' <summary>
    ''' Ermittelt dein einzel EK (Netto) auf Grundlage des aktuellen einzel EK (Brutto)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSingleEKNetto() As Decimal
        Return m_activeItem.EinzelEK
    End Function

    Private Function GetSingleVKBrutto() As Decimal
        Return m_activeItem.CalulatedEndPrice * (1 + m_activeItem.TaxRate.TaxValue / 100)
    End Function

    ''' <summary>
    ''' Ruft den multiplizierten EK ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetEKMulti() As Decimal
        If m_activeItem IsNot Nothing Then
            Return m_activeItem.EinzelEK / m_activeItem.MinDeliveryCount
        End If
        Return 0D
    End Function

    Private Function GetSingleVK() As Decimal
        If m_activeItem IsNot Nothing Then
            Return m_activeItem.CalulatedEndPrice
        Else
            Return 0D
        End If
    End Function
    ''' <summary>
    ''' Ruft den Einzel-EK ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetEK() As Decimal
        If m_activeItem IsNot Nothing Then
            Return m_activeItem.EinzelEK
        End If
        Return 0D
    End Function

    ''' <summary>
    ''' Ruft den Brutto-einzelpreis ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetEKBrutto() As Decimal
        If m_activeItem IsNot Nothing Then
            Return m_activeItem.EinzelEK * (1 + m_activeItem.TaxRate.TaxValue / 100)
        Else
            Return 0D
        End If
    End Function



    Class Node

        Friend Shared nodesList As New Dictionary(Of DevExpress.XtraEditors.BaseEdit, Node)

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Private m_nextNodes As New List(Of Node)

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Private m_visited As Boolean
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Private m_control As DevExpress.XtraEditors.BaseEdit

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Private m_valueGetter As delGetValue

        Sub New(ByVal control As DevExpress.XtraEditors.BaseEdit, ByVal value As delGetValue)
            MyControl = control
            ValueGetter = value
            If Not nodesList.ContainsKey(control) Then
                nodesList.Add(control, Me)
            End If
        End Sub

        ''' <summary>
        ''' Löscht die Nodes-Liste
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Clear()
            nodesList.Clear()
            m_nextNodes.Clear()
        End Sub

        ''' <summary>
        ''' Ruft einen Verweis ab, der dieses Control repräsentiert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MyControl() As DevExpress.XtraEditors.BaseEdit
            Get
                Return m_control
            End Get
            Set(ByVal value As DevExpress.XtraEditors.BaseEdit)
                m_control = value
            End Set
        End Property


        ''' <summary>
        ''' Zeigt an, das dieses Node bereits besucht war
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Visited() As Boolean
            Get
                Return m_visited
            End Get
            Set(ByVal value As Boolean)
                m_visited = value
            End Set
        End Property


        Public Property ValueGetter() As delGetValue
            Get
                Return m_valueGetter
            End Get
            Set(ByVal value As delGetValue)
                m_valueGetter = value
            End Set
        End Property

        ''' <summary>
        ''' Setzt den Wert für dieses Control
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetValue()
            MyControl.EditValue = ValueGetter.Invoke
            Visited = True
            GoDeeper()
        End Sub


        Public Sub ResetVisited()
            For Each item As Node In Me.NextNodes
                If item.Visited Then
                    item.Visited = False
                    item.ResetVisited()
                End If
            Next
        End Sub

        Public Sub GoDeeper()
            For Each item As Node In Me.NextNodes
                If Not item.Visited Then
                    item.SetValue()
                    item.GoDeeper()
                End If
            Next
        End Sub

        ''' <summary>
        ''' Ruft einen Verweis auf die nächsten Node ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property NextNodes() As List(Of Node)
            Get
                Return m_nextNodes
            End Get

        End Property
    End Class

    Delegate Function delGetValue() As Decimal


    Private Sub txtSingleEKMulti_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSingleEKMulti.EditValueChanged, txtRohstoffPreisMulti.EditValueChanged, txtVerkaufspreisMulti.EditValueChanged
        'If m_isLoading Then Exit Sub
        If IsRefreshing Then Exit Sub
        IsRefreshing = True
        Dim editfield As DevExpress.XtraEditors.BaseEdit = CType(sender, DevExpress.XtraEditors.BaseEdit)
        If editfield.EditValue IsNot Nothing Then

            m_activeItem.EinzelEK = CDec(editfield.EditValue)

            Node.nodesList(editfield).SetValue()

            Node.nodesList(editfield).ResetVisited()
        End If
        IsRefreshing = False
    End Sub


    Private Sub MruPack_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MruPack.SelectedIndexChanged
        If m_activeItem IsNot Nothing Then
            m_activeItem.Recheneinheit = TryCast(MruPack.SelectedItem, Unit)
            m_hasChanged = True
        End If
    End Sub

    Private Sub txtSingleEKBrutto_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSingleEKBrutto.EditValueChanged
        'If m_isLoading Then Exit Sub
        If IsRefreshing Then Exit Sub
        IsRefreshing = True

        Dim editfield As DevExpress.XtraEditors.BaseEdit = CType(sender, DevExpress.XtraEditors.BaseEdit)
        m_activeItem.EinzelEK = CDec(editfield.EditValue) / (1 + m_activeItem.TaxRate.TaxValue / 100)

        Node.nodesList(editfield).SetValue()

        Node.nodesList(editfield).ResetVisited()

        IsRefreshing = False
    End Sub



    ''' <summary>
    ''' Artikelmerkmale einbelnden 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillAttributesGrid()
        ' Erst alle Attribute aus der Datenbank holen, dann die, die noch fehlen, aus der Attribute-Definition holen
        If m_activeItem IsNot Nothing Then
            If m_activeItem.Classification IsNot Nothing Then
                grdAttributes.DataSource = m_activeItem.ItemsAttributes
            Else
                grdAttributes.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub grvAttributes_ShownEditor(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles grvAttributes.CustomRowCellEdit

        If e.Column.Name = "colAttributeName" Then Exit Sub

        Dim item As Attributes.AttributeValue = CType(grvAttributes.GetRow(e.RowHandle), Attributes.AttributeValue)
        If item.GetAttributeDefinition Is Nothing Then Exit Sub

        If item.GetAttributeDefinition.AttributeType = enumAttributeType.ChooseOne Then
            repAttributesEnumValues.Items.Clear()
            repAttributesEnumValues.Items.AddRange(item.GetAttributeDefinition.MultiselectProfile.GetValueList)
            e.RepositoryItem = repAttributesEnumValues

            Exit Sub
        End If

        If TypeOf e.CellValue Is Boolean Then
            e.RepositoryItem = repAttrbutesCheckedit
        End If
        If TypeOf e.CellValue Is Date Then
            e.RepositoryItem = repAttributesDateEdit
        End If
    End Sub


    'Private Sub grvAttributes_CustomRowCellEditForEditing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles grvAttributes.CustomRowCellEditForEditing
    '    Dim item As Attributes.AttributeValue = CType(grvAttributes.GetRow(e.RowHandle), Attributes.AttributeValue)

    '    If item.GetAttributeDefinition.AttributeType = enumAttributeType.ChooseOne Then
    '        repAttributesEnumValues.Items.Clear()
    '        repAttributesEnumValues.Items.AddRange(item.GetAttributeDefinition.GetMultiselectProfile.GetValueList)
    '        e.RepositoryItem = repAttributesEnumValues

    '        Exit Sub
    '    End If


    '    If TypeOf e.CellValue Is Boolean Then
    '        e.RepositoryItem = repAttrbutesCheckedit
    '    End If

    '    If TypeOf e.CellValue Is Date Then
    '        e.RepositoryItem = repAttributesDateEdit
    '    End If
    'End Sub

    ''' <summary>
    ''' Setzt nicht editierbare spalten anch dem setzen der Datenquelle
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdAttributes_DataSourceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdAttributes.DataSourceChanged
        grvAttributes.Columns(0).OptionsColumn.AllowEdit = False
        grvAttributes.Columns(0).OptionsColumn.AllowFocus = False

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        m_activeItem.Refreshattributes()
        FillAttributesGrid()
    End Sub


    Private Sub trvsubArticles_ColumnWidthChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.ColumnChangedEventArgs) Handles trvsubArticles.ColumnWidthChanged
        If Not m_isLoading Then
            SaveTreeStyles(trvsubArticles, "BomList")
        End If

    End Sub

    Private Sub trvsubArticles_EndSorting(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvsubArticles.EndSorting
        If Not m_isLoading Then
            SaveTreeStyles(trvsubArticles, "BomList")
        End If

    End Sub

    Private Sub cboWorkAccount_Properties_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboWorkAccount.Properties.ButtonClick
        If TypeOf e.Button.Tag Is String Then
            If CStr(e.Button.Tag) = "Edit" Then
                Dim frm As New frmSimpleEdit(DataSourceList.LoanAccounts)
                If frm.ShowDialog() = DialogResult.OK Then
                    cboWorkAccount.Properties.Items.Clear()
                    cboWorkAccount.Properties.Items.AddRange(MainApplication.getInstance.LoanAccounts)

                End If
            End If
        End If
    End Sub

    Private Sub cboWorkAccount_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWorkAccount.SelectedIndexChanged
        If m_activeItem IsNot Nothing And cboWorkAccount.SelectedItem IsNot Nothing Then
            m_activeItem.LoanAccount = CType(cboWorkAccount.SelectedItem, LoanAccount)

            SetWorkItemCost()
        End If
    End Sub

    ''' <summary>
    ''' setzt den Preis in der Anzeige der Tätigkeit
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetWorkItemCost()
        If m_activeItem.LoanAccount IsNot Nothing Then
            Dim time As Date = txtWorkTimeSpan.Time
            Dim minutes As Long = CLng(time.Ticks \ TimeSpan.TicksPerMinute)

            txtWorkItemcosts.Text = ((m_activeItem.LoanAccount.PricePerHour / 60) * minutes).ToString("c")
        End If

    End Sub


    Private Sub chkIsWorkItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsWorkItem.CheckedChanged
        TableLayoutPanel1.Enabled = chkIsWorkItem.Checked

        txtsingleEK1.Enabled = Not chkIsWorkItem.Checked
        txtSingleEKBrutto.Enabled = Not chkIsWorkItem.Checked
        txtSingleEKMulti.Enabled = Not chkIsWorkItem.Checked

        cboWorkAccount.Enabled = chkIsWorkItem.Checked
        txtWorkTimeSpan.Enabled = chkIsWorkItem.Checked

        If ActiveItem IsNot Nothing Then
            ActiveItem.IsWorkItem = chkIsWorkItem.Checked
        End If

    End Sub

    Private Sub cmsBomItems_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsBomItems.Opening
        ' ist gerade ein Artikel selektiert und die Maus drauf? 
        If trvsubArticles.Selection.Count > 0 Then
            btnOpenBomItem.Visible = True
        Else
            btnOpenBomItem.Visible = False
        End If
    End Sub

    Private Sub OpenSelectedBomItem()
        If trvsubArticles.FocusedNode IsNot Nothing Then

            Dim newItemsList As iucArticles = CType(MainUI.OpenWorkingPane(HWLModules.Articles).WorkingItem, iucArticles)
            Dim BomItem As BOM.ArticleLink = CType(trvsubArticles.GetDataRecordByNode(trvsubArticles.FocusedNode), BOM.ArticleLink)
            If BomItem IsNot Nothing Then
                newItemsList.ActiveItem = BomItem.Article
            End If

        End If
    End Sub

    ''' <summary>
    ''' Löscht die markiertren Elemente der Stückliste
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteSelectedBomItem()
        ' Auflistung der markierten elemente kopieren
        Dim bomItemList As New List(Of DevExpress.XtraTreeList.Nodes.TreeListNode)
        For Each item As DevExpress.XtraTreeList.Nodes.TreeListNode In trvsubArticles.Selection
            bomItemList.Add(item)
        Next


        ' Elemente Löschen 
        For Each item As DevExpress.XtraTreeList.Nodes.TreeListNode In bomItemList
            Dim BomItem As BOM.ArticleLink = CType(trvsubArticles.GetDataRecordByNode(item), BOM.ArticleLink)
            BomItem.Delete()
        Next

        FillSubArticles()

    End Sub


    Private Sub btnOpenBomItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenBomItem.Click
        OpenSelectedBomItem()
    End Sub

    Private Sub mnuDeleteBomItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteBomItems.Click
        DeleteSelectedBomItem()
    End Sub

    Private Sub btnTransferSubPrices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferSubPrices.Click
        m_activeItem.EinzelEK = m_activeItem.SubArticles.GetTotalBasePrice
        txtSingleEK.EditValue = m_activeItem.EinzelEK

        m_activeItem.EinzelVK = ActiveItem.SubArticles.GetTotalendPrice
        txtSingleVK.EditValue = ActiveItem.EinzelVK

        m_activeItem.FixedPrice = True
        FillControls()

    End Sub

    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get
            Return My.Resources.Configuration_Tools_16x16
        End Get
    End Property

    Private Sub txtManufactorsArticleNumber_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManufactorsArticleNumber.EditValueChanged
        If ActiveItem IsNot Nothing Then
            ActiveItem.ManufactorsArticleNumber = txtManufactorsArticleNumber.Text
        End If

    End Sub

    Private Sub txtMemo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMemo.EditValueChanged
        If m_activeItem IsNot Nothing Then
            ActiveItem.Notes = txtMemo.Text
        End If
    End Sub

    ''' <summary>
    ''' Füllt das Baumdiagramm mit den veraltetetn Artikeln
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillPredecessorHirachy()
        trvHirachy.Nodes.Clear()
        trvHirachy.Columns.Clear()

        Dim Captions As String() = {"ArticleKey", "Article Name"} 'TODO: NLS
        Dim i As Integer
        For i = 0 To Captions.Length - 1
            trvHirachy.Columns.Add()
            trvHirachy.Columns(i).Caption = Captions(i)
            trvHirachy.Columns(i).VisibleIndex = CInt(IIf(i = 0, -1, i))
        Next



        Dim rootParentNode As TreeListNode = Nothing
        Dim Predecessor As List(Of Article) = ActiveItem.GetPredecessorItems

        If Predecessor IsNot Nothing Then
            SetPredecessorSubNode(Predecessor, rootParentNode)
        End If


    End Sub

    ''' <summary>
    ''' Setz das übergeordnete Node für die 'Lässt veralten'-Liste
    ''' </summary>
    ''' <param name="predecessors">eine Auflistung von Vorgängerartikeln</param>
    ''' <param name="parentNode">Der aktuelle  Artikel</param>
    ''' <remarks></remarks>
    Private Sub SetPredecessorSubNode(ByVal predecessors As List(Of Article), ByVal parentNode As TreeListNode)
        trvHirachy.BeginUnboundLoad()
        Dim Node As TreeListNode
        For Each item As Article In predecessors
            Dim Values As Object() = {item.Key, item.ToString}

            Node = trvHirachy.AppendNode(Values, parentNode)
            Node.HasChildren = True
        Next
        trvHirachy.EndUnboundLoad()
    End Sub

    Private Sub btnSetPredecessor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPredecessor.Click
        Dim oldItem As Article = GetNewItemFromDialog()

        If oldItem IsNot Nothing Then
            Dim newReplacement As Attributes.ArticleReplacement = ActiveItem.ArticlesHirachy.GetNewItem
            newReplacement.Predecessor = oldItem
            newReplacement.Successors = ActiveItem
            ActiveItem.ArticlesHirachy.Add(newReplacement)
            newReplacement.Save()
            FillPredecessorHirachy()
        End If

    End Sub

    Private Function GetNewItemFromDialog() As ClausSoftware.Kernel.Article
        Dim frm As New frmSmallItemChooser
        frm.DataKind = frmSmallItemChooser.DataKindenum.Articles


        If frm.ShowDialog() = DialogResult.OK Then
            Return CType(frm.SelectedItem, Article)
        Else
            Return Nothing
        End If

    End Function


    Private Sub btnEditArticleAttributes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditArticleAttributes.Click
        ' Keine Klassifizierung, wenn Artikel keiner Gruppe zugewiesen ist
        If m_activeItem.Group IsNot Nothing Then
            MainUI.StartClassificationWindow(m_activeItem.Group.AttributeClass) ' ruft ein Modales fenster auf
            FillAttributesGrid()

        End If

    End Sub

    
    Private Sub btnMaximizeworkspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaximizeworkspace.Click
        ToggleWorkspace()
    End Sub

    ''' <summary>
    ''' schiebt den Arbeitsbereich zusammen oder auseinander
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ToggleWorkspace()

        If m_workspaceExpanded Then
            Me.btnMaximizeworkspace.Image = My.Resources.Collapse_16x16
            Me.btnMaximizeworkspace.ToolTip = "Arbeitsbereich wiederherstellen" 'TODO: NLS
            SplitContainerControl1.SplitterPosition = m_splitterOrgSize ' Minimalgrösse
            m_workspaceExpanded = False
        Else
            Me.btnMaximizeworkspace.Image = My.Resources.FitToHeight_16x16
            Me.btnMaximizeworkspace.ToolTip = "Arbeitsbereich vergrössern" 'TODO: NLS
            SplitContainerControl1.SplitterPosition = pnlHeadline.Height

            m_workspaceExpanded = True
        End If
    End Sub



    Private Sub txtMemo_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMemo.DragDrop
        DragDropHelper.SetText(sender, e)
    End Sub

    Private Sub txtMemo_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtMemo.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub



    ''' <summary>
    ''' Aktiviertz den "Umbenennen" - Modus für das aktuell gewählte Element
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub StartRename(ByVal sender As Object, ByVal e As EventArgs)
        mainTable.SelectedTabPage = tabInformation
        txtName.Focus()
        txtName.SelectAll()
    End Sub

    ''' <summary>
    ''' Validiert die einheiten - KOmbobox. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UnitCombobox_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MruPack.Validating, MruBase1.Validating, MruBase.Validating

        ' Prüft freie Texteingabe un sucht eine einheit dazu. 
        ' Konnte keine Einheit gefunden werden; wird eine angelegt

        Dim cbo As DevExpress.XtraEditors.ComboBoxEdit = CType(sender, DevExpress.XtraEditors.ComboBoxEdit)

        If TypeOf cbo.SelectedItem Is String Then
            Dim newUnit As Unit
            newUnit = Units.FindUnit(CStr(cbo.EditValue), True)
            'dieser Auflistung hinzufügen; da neu
            cbo.Properties.Items.Add(newUnit)
            cbo.SelectedItem = newUnit

            ' Die neue Einheiten in den anderen Controls einfügen
            If Not MruBase.Properties.Items.Contains(newUnit) Then MruBase.Properties.Items.Add(newUnit)
            If Not MruBase1.Properties.Items.Contains(newUnit) Then MruBase1.Properties.Items.Add(newUnit)
            If Not MruPack.Properties.Items.Contains(newUnit) Then MruPack.Properties.Items.Add(newUnit)

            ' Die Basiseinheit gibt es zweimal
            If cbo Is MruBase Then MruBase1.SelectedItem = newUnit
            If cbo Is MruBase1 Then MruBase.SelectedItem = newUnit

            Exit Sub
        End If


    End Sub

    Private Sub Text_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtSingleVKbrutto.DragEnter, txtSingleVK.DragEnter, txtSingleEKBrutto.DragEnter, txtSingleEK.DragEnter, txtName.DragEnter, txtLongText.DragEnter, txtArticleName.DragEnter, txtManufactorsArticleNumber.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub

    Private Sub Text_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtSingleVKbrutto.DragDrop, txtSingleVK.DragDrop, txtSingleEKBrutto.DragDrop, txtSingleEK.DragDrop, txtName.DragDrop, txtManufactorsArticleNumber.DragDrop, txtLongText.DragDrop, txtArticleName.DragDrop
        DragDropHelper.SetText(sender, e)
    End Sub

    Private Sub txtName_Enter(sender As System.Object, e As System.EventArgs) Handles txtName.Enter
        txtName.SelectAll()
    End Sub
End Class

