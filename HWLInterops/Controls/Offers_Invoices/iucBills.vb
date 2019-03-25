Option Explicit On
Option Strict On

Imports ClausSoftware.Kernel
Imports ClausSoftware.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Namespace Offers
    ''' <summary>
    ''' Stellt den Typ dar, der anzeigt ob das Element im Viewmode angezeigt wird oder bearbeitet werden kann 
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ViewModeType
        ''' <summary>
        ''' Das aktuelle element kann bearbeitet erden 
        ''' </summary>
        ''' <remarks></remarks>
        EditMode
        ''' <summary>
        ''' Das aktuelle element kann nicht bearbeitet werden
        ''' </summary>
        ''' <remarks></remarks>
        ViewMode

    End Enum

    Public Structure IconInfo
        Public fIcon As Boolean
        Public xHotspot As Integer
        Public yHotspot As Integer
        Public hbmMask As IntPtr
        Public hbmColor As IntPtr
    End Structure



    ''' <summary>
    ''' Stellt das "Angeboet/Rechnungen" - Modul bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class iucBills
        Implements IModule

        Private m_journalForm As New frmJournal(MainUI)

        Private m_frmRTFItemDescriptionEdit As frmRTFItemDescriptionEdit

        Dim m_warnImage As Image = My.Resources.SymbolWarning_16x16

        Private m_workspaceExpanded As Boolean ' True, wenn Bereich maximiert, sonst false

        Private session As DevExpress.Xpo.Session
        Private m_activeItem As ClausSoftware.Kernel.JournalDocument

        Private m_viewMode As ViewModeType
        ''' <summary>
        ''' Ruft einen Wert ab, er anzeigt ob das element berabeitet werden kann oder nicht
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property EditorMode() As ViewModeType
            Get
                Return m_viewMode
            End Get
            Set(ByVal value As ViewModeType)
                m_viewMode = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Editor für Formatierte Texte ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property RTFItemDescriptionEdit As frmRTFItemDescriptionEdit
            Get
                If m_frmRTFItemDescriptionEdit Is Nothing Then
                    m_frmRTFItemDescriptionEdit = New frmRTFItemDescriptionEdit
                End If
                Return m_frmRTFItemDescriptionEdit

            End Get
        End Property

        ''' <summary>
        ''' Ruft das gerade aktive Element ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ActiveItem() As JournalDocument
            Get
                Return m_activeItem
            End Get
            Set(ByVal value As JournalDocument)

                Dim oldItem As JournalDocument = m_activeItem
                If value IsNot Nothing Then
                    If oldItem IsNot Nothing AndAlso Not oldItem.Key.Equals(value.Key) Then oldItem.Unlock() 'Sperre aufhaben, wenn das element sich ändert


                    m_activeItem = value
                    m_activeItem.ShowWithoutTax = Not chkShowWithoutTax.Checked

                    MainUI.MRUManager.AddMRUElement(value)

                    ' Kann während der Berabitung gesperrt werden
                    Dim lockState As LockType = m_activeItem.CheckLockState
                    If lockState.LockType <> LockedbyType.ByOthers Then
                        m_activeItem.Lock() ' selber sperren
                        EditorMode = ViewModeType.EditMode
                    Else
                        EditorMode = ViewModeType.ViewMode
                        'TODO: NLS
                        'TODO: Datensatz-Sperren 
                        ' MessageBox.Show("Datensatz wurde gesperrt von: --  Sie können keine Änderungen vornehmen", "Datensatz gesperrt", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If


                    RemoveHandler m_activeItem.Changed, AddressOf OnDocumentChanged
                    AddHandler m_activeItem.Changed, AddressOf OnDocumentChanged

                    FillDocumentData()

                    If Not m_activeItem.IsNew Then
                        cobDocumentType.Enabled = False
                    Else
                        cobDocumentType.Enabled = True
                    End If

                Else
                    m_activeItem = Nothing
                End If
                ClearHasChangedState()
            End Set
        End Property


        <DllImport("user32.dll")> _
        Public Shared Function GetIconInfo(ByVal hIcon As IntPtr, ByRef pIconInfo As IconInfo) As _
        <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll")> _
        Public Shared Function CreateIconIndirect(ByRef icon As IconInfo) As IntPtr
        End Function


        ''' <summary>
        ''' Initiliaisiert den Applikationsobjekt
        ''' </summary>
        ''' <remarks></remarks>
        Sub Initialize()

            ActiveItem = New ClausSoftware.Kernel.JournalDocument(MainApplication.getInstance.Session)

            ' Preview-Eigenscahft liegt im Grid-Layout
            chkShowPreviewLines.Checked = grvItems.OptionsView.ShowPreview

        End Sub

        Private Sub btnJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJournal.Click
            OpenJournalAsync()
        End Sub


        Private Delegate Sub OpenJournalDele()
        Private OpenJournalDelegate As New OpenJournalDele(AddressOf StartOpenJournal)

        ''' <summary>
        ''' Öffnet das Journal Asynchron (warum?) 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub OpenJournalAsync()
            Try

                'Opener.BeginInvoke(Nothing, Nothing)
                Me.Invoke(OpenJournalDelegate)

            Catch ex As Exception
                ' TODO: eine fehlende Verbindung markieren
                MainApplication.getInstance.log.WriteLog(ex, "Journalstart", "Fehler im Journal")
            End Try
        End Sub

        Private Delegate Sub FillByJournalInternalDelegate(ByVal documentItem As JournalDocument)
        Private StartFilling As New FillByJournalInternalDelegate(AddressOf OpenJournalEntryInternal)


        ''' <summary>
        ''' Öffnet das Journal Asynchron
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub StartOpenJournal()

            If Not MainApplication.getInstance.PeriodicCheckConnection(True) Then Exit Sub

            If m_journalForm Is Nothing Then m_journalForm = New frmJournal(MainUI)

            If m_journalForm.ShowDialog() = DialogResult.OK Then

                If Not m_journalForm.SelectedDocument Is Nothing Then


                    Me.Invoke(StartFilling, New Object() {m_journalForm.SelectedDocument})

                End If
            End If

            ' Im Journal könnt das aktuelle dokument gelöscht woredn sein => Prüfen und gegebenfall das Workpane schliessen
            If Me.ActiveItem.IsDeleted Then
                Me.ActiveItem = Nothing
                NewDocument()
            End If


        End Sub


        ''' <summary>
        ''' Öffnet ein neues Element mit dem angegebenen Schlüssel
        ''' </summary>
        ''' <param name="documentItem">Das anzuzeigende Dokument</param>
        ''' <remarks></remarks>
        Private Sub OpenJournalEntryInternal(ByVal documentItem As JournalDocument)

            If MainApplication.getInstance.PeriodicCheckConnection(True) Then
                MainApplication.getInstance.JournalDocuments.Filter = Nothing
                MainApplication.getInstance.JournalDocuments.Criteria = Nothing

                ' Farge, falls das aktive Dokument noch bearbeitet wurde, Speichern oder neues Fenster öffnen ? 
                If ActiveItem IsNot Nothing Then
                    If ActiveItem.Key = documentItem.Key Then Exit Sub

                    If ActiveItem.HasChanged Then
                        ' Neues Fenster aufmachen 
                        MainUI.OpenElementWindow(documentItem, True)
                        Exit Sub
                    End If

                End If

                ActiveItem = documentItem
                FillDocumentData()
            End If

        End Sub

        ''' <summary>
        ''' Aktualisiert die Ansicht des Dokumentes. Läd alle Daten des Dokumentes in die ansicht neu ein.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub FillDocumentData()
            Me.IsLoading = True
            FillHeaderControls()

            lblChangedAtValue.Text = ActiveItem.ChangedAt.ToString("d")
            lblCreatedAtValue.Text = ActiveItem.CreatedAt.ToString("d")
            lbldocumentDisplayID.Text = ActiveItem.DocumentDisplayID

            ' Storno - Status feststellen
            If ActiveItem.IsCanceled Then
                lblCanceldAtValue.Text = ActiveItem.CanceledAt.ToString("d")
                lblCanceldAtValue.ToolTip = ActiveItem.CanceledBy
                lblCanceledStateAt.ToolTip = ActiveItem.CanceledBy

                lblCanceldAtValue.Visible = True
                lblCanceledStateAt.Visible = True
            Else
                lblCanceldAtValue.Visible = False
                lblCanceledStateAt.Visible = False
            End If


            If ActiveItem.IsNew Then
                lbldocumentDisplayID.ToolTip = GetText("msgDocumentIDWillSetAfterSave", "Nummer wird nach dem Speichern gesetzt")
            Else
                lbldocumentDisplayID.ToolTip = lbldocumentDisplayID.Text

            End If


            datDocumentVisibleDate.EditValue = ActiveItem.DocumentDate

            If ActiveItem.IsNew Then
                chkShowWithoutTax.Checked = MainApplication.getInstance.Settings.ItemsSettings.ShowWithoutTax
            Else
                chkShowWithoutTax.Checked = Not ActiveItem.ShowWithoutTax
            End If


            'Den Dokuemntentype anzeigen
            For Each item As JournalDocumentType In cobDocumentType.Properties.Items
                If item.InternalID = ActiveItem.DocumentType Then
                    cobDocumentType.SelectedItem = item
                End If
            Next

            grdItemsList.DataSource = ActiveItem.ArticleGroups

            For n As Integer = 0 To grvPositions.RowCount - 1
                grvPositions.ExpandMasterRow(n)
            Next
            Me.IsLoading = False

            ' Fuss mit Preisen auffüllen
            FillPricesumField()

            grvItems.ZoomView()

            ' Datensatzsperren prüfen
            CheckIfDocumentIsLocked()

        End Sub

        ''' <summary>
        ''' ein Dokument kann gesperrt sein (Datensatz-Lock) oder die Berabeitung kann verhindert werden, (storno) 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CheckIfDocumentIsLocked()
            If Me.ActiveItem IsNot Nothing Then

                Dim lockedState As Boolean
                lockedState = DocumentIsLocked

                If lockedState Then
                    grvItems.OptionsBehavior.ReadOnly = True
                    grvPositions.OptionsBehavior.ReadOnly = True
                    txtAdresswindow.Enabled = False
                    btnSearchAdress.Enabled = False
                    btnResetAdress.Enabled = False
                    btnAddAddress.Enabled = False
                    txtHeadText.Properties.ReadOnly = True
                    txtFooterText.Properties.ReadOnly = True
                    chkDiscountActive.Enabled = False
                    txtDiscountName.Enabled = False
                    txtDiscountedValue.Enabled = False

                    btnAddArticleGroup.Enabled = False

                    grvItems.OptionsBehavior.Editable = False

                Else
                    grvItems.OptionsBehavior.ReadOnly = False
                    grvPositions.OptionsBehavior.ReadOnly = False
                    txtAdresswindow.Enabled = True
                    btnSearchAdress.Enabled = True
                    btnResetAdress.Enabled = True
                    btnAddAddress.Enabled = True
                    txtHeadText.Properties.ReadOnly = False
                    txtFooterText.Properties.ReadOnly = False
                    chkDiscountActive.Enabled = True
                    txtDiscountName.Enabled = True
                    txtDiscountedValue.Enabled = True

                    btnAddArticleGroup.Enabled = True

                    'Den Storno-Status anzeigen lassen
                    lblCanceldAtValue.Visible = False
                    lblCanceledStateAt.Visible = False
                    grvItems.OptionsBehavior.Editable = True

                End If
            End If
        End Sub

        ''' <summary>
        ''' Ruft den aktuellen Locked-Status des Dokumenten ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property DocumentIsLocked As Boolean
            Get
                If ActiveItem IsNot Nothing Then
                    Return ActiveItem.IsCanceled Or ActiveItem.IsLocked
                End If
                Return False
            End Get
        End Property

        ''' <summary>
        ''' Behandelt jegliche Änderung des Inhaltes des Grids
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub OnDocumentChanged(ByVal sender As Object, ByVal e As EventArgs)
            FillPricesumField() ' Preise auffüllen
        End Sub

        Private Sub FillPricesumField()
            ' Das Grid auffüllen und den Preise-Block auffüllen
            If IsLoading Then Exit Sub ' aufladen ignorieren, solange geladen wird

            Dim oldValue As Boolean = Me.IsLoading
            Me.IsLoading = True
            lblTextNettoSumme.Text = ActiveItem.DisplayBasePriceText

            txtNetSumValue.EditValue = ActiveItem.DisplayBasePrice

            txtDiscountName.EditValue = ActiveItem.DiscountText  ' Rabatttext ("Rabatt / Aufschlag") 
            txtDiscountValue.EditValue = ActiveItem.DiscountValue ' Zahlenwert des Rabattes (Kann Prozentual oder Absolut sein) 
            If ActiveItem.DiscountActive Then
                txtDiscountedValue.EditValue = ActiveItem.DiscountValueAbs ' wert des Rabattes (nicht er nun erzielte Betrag, der Steht dann ganz unten) 
            Else
                txtDiscountedValue.EditValue = 0D

            End If


            chkDiscountActive.Checked = ActiveItem.DiscountActive
            lblChangedAtValue.Text = ActiveItem.ChangedAt.ToString("d")
            txtSumValueAfterTax.EditValue = ActiveItem.DisplayedEndPrice
            ReduceTaxFields()

            chkShowWithoutTax.Checked = Not ActiveItem.ShowWithoutTax

            ShowTaxFields()

            'Auf Preisunterschreitung prüfen
            Dim totalMinPrice As Decimal
            For Each item As Kernel.AcummulatedJournalItem In m_activeItem.ListOfItems
                totalMinPrice += (item.ItemCount * item.ArticleSingleBasePrice)

            Next

            'TODO: NLS
            If m_activeItem.TotalPriceBeforeTax < totalMinPrice Then  ' Endbetrag < Summe der Artikel
                Dim minEK As String = GetText("msgBelowMinBasePriceWarning", "Gesamtpreis der Artikel liegt unter dem Verkaufspreis! (EK={0})", totalMinPrice.ToString("c"))
                DxErrorProvider1.SetError(txtSumValueAfterTax, minEK)
                DxErrorProvider1.SetErrorType(txtSumValueAfterTax, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
            Else
                DxErrorProvider1.SetError(txtSumValueAfterTax, "")
                DxErrorProvider1.SetErrorType(txtSumValueAfterTax, DevExpress.XtraEditors.DXErrorProvider.ErrorType.None)
            End If
            lblEarningValue.Text = (ActiveItem.TotalPriceBeforeTax - totalMinPrice).ToString("c")
            Me.IsLoading = oldValue
        End Sub

        ''' <summary>
        ''' Blendet die Steuerfelder ein, jenachdem, ob diese tatsächlich benötigt werden
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ShowTaxFields()
            'Steuersätze auffüllen und eintragen lassen 
            Dim taxNumber As Integer
            Dim defaultHeigh As Integer

            Dim dummyLabel As New DevExpress.XtraEditors.LabelControl

            defaultHeigh = dummyLabel.Height
            Dim TaxText As String = GetText("tax", "Steuern")

            For Each taxPart As JournalTaxValuePair In m_activeItem.DiscountedPriceList.DiscountedValues

                If taxNumber = 0 Then
                    talPrices.RowStyles(2).Height = defaultHeigh
                    lblTaxValue1.Text = taxPart.TaxValuePrice.ToString("c")
                    lblTaxValueText1.Text = TaxText & " " & taxPart.TaxRateValue & "%"
                End If
                If taxNumber = 1 Then
                    talPrices.RowStyles(3).Height = defaultHeigh
                    lblTaxValue2.Text = taxPart.TaxValuePrice.ToString("c")
                    lblTaxValueText2.Text = TaxText & " " & taxPart.TaxRateValue & "%"
                End If
                If taxNumber = 2 Then
                    talPrices.RowStyles(4).Height = defaultHeigh
                    lblTaxValue3.Text = taxPart.TaxValuePrice.ToString("c")
                    lblTaxValueText3.Text = TaxText & " " & taxPart.TaxRateValue & "%"
                End If

                taxNumber += 1
            Next
        End Sub

        ''' <summary>
        ''' Alle Zeilen im Preisfeld mit steuersatz verbergen
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ReduceTaxFields()
            For n As Integer = 0 To 2 ' Alle steuersätze minimieren
                talPrices.RowStyles(2 + n).Height = 0
            Next

        End Sub

        Public Function CloseModule() As Boolean Implements IModule.CloseModule



            If ActiveItem IsNot Nothing Then

                If Me.ActiveItem.IsDeleted Then Return True

                If m_activeItem.HasChanged Then
                    Dim result As DialogResult = AskChangedData()
                    If result = DialogResult.Yes Then
                        Me.SaveCurrentItem()
                    End If
                    If result = DialogResult.Cancel Then
                        Return False
                    End If
                End If
                ' Neu laden, da alle Änderungen noch im Speicher sind 
                ActiveItem.Reload()

                Return True

            Else
                Return True
            End If
        End Function

        Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
            Get
                Return GetText("Offers&Invoices", "Angebote / Rechnungen")
            End Get
        End Property

        ''' <summary>
        ''' Liefert True zurück, wenn es irgendwelche änderung gab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
            Get
                Return m_activeItem.HasChanged

            End Get
        End Property

        ''' <summary>
        ''' Löscht den 'Geändert' - Status. Das aktuelle Dokument wird als 'ungeändert' markiert.
        ''' </summary>
        ''' <remarks>Das kann beim speichern zu problemen führen.</remarks>
        Public Sub ClearHasChangedState()
            If Me.ActiveItem IsNot Nothing Then
                Me.ActiveItem.ClearHasChangedState()
            End If
        End Sub

        Public Sub InitializeModule() Implements IModule.InitializeModule

            chkShowPreviewLines.Checked = grvItems.OptionsView.ShowPreview
        End Sub

        Friend Sub LoadCurrentItem(ByVal currentItem As StaticItem)

        End Sub


        Private m_IsActiveLoad As Boolean

        ''' <summary>
        ''' Zeigt an, das im Moment Daten eingeladen werden. Aktualisierungen des Datenobjektes sollten nicht stattfinden, wennm dieser wert auf "True" steht. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsLoading() As Boolean
            Get
                Return m_IsActiveLoad
            End Get
            Set(ByVal value As Boolean)
                m_IsActiveLoad = value
            End Set
        End Property


        ''' <summary>
        ''' Erstellt ein neues Dokument. Ist bereits eines in Arbeit, so wird vorher eine Frage gestellt
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub NewDocument() Implements IModule.CreateNewItem
            If ActiveItem IsNot Nothing Then
                If ActiveItem.HasChanged Then
                    Dim result As DialogResult = AskChangedData()
                    If result = DialogResult.Cancel Then Exit Sub

                    If result = DialogResult.Yes Then
                        SaveCurrentItem()
                    End If

                End If
            End If
            'TODO: Last Type angeben
            IsLoading = True

            ' Neuen dokumententyp abhängig von der letzten eingabe des Benuzters
            Dim newDocType As enumJournalDocumentType = CType(MainApplication.getInstance.Settings.ItemsSettings.LastUsedDocumentType, enumJournalDocumentType)
            ActiveItem = MainApplication.getInstance.JournalDocuments.GetNewItem(newDocType)

            Dim firstArticleGroup As New JournalArticleGroup(ActiveItem)


            m_activeItem.AddArticleGroup(firstArticleGroup)
            IsLoading = False

            FillDocumentData()
            m_activeItem.ClearHasChangedState()

            ' Die erste Gruppe expandieren
            grvPositions.ExpandMasterRow(0)
            grvItems.OptionsView.ShowViewCaption = True
            ClearHasChangedState()
        End Sub



        ''' <summary>
        ''' Startet den Druckvorgang des aktuellen Dokumentes
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Print() Implements IModule.Print
            Try

                'ReorderSortOrder()

                Using printing As New Printing.dlgPrintdocuments(MainUI)
                    ' printing.Grid = ArticlesGrid.grdArticles   ' Grid zuweisen
                    Dim itemsList As New List(Of JournalDocument)
                    itemsList.Add(m_activeItem)

                    printing.DocumentsList = itemsList ' Aktuelle Instanz anzeigen lassen

                    printing.ShowDialog()
                End Using

            Catch ex As Exception

                MainApplication.getInstance.log.WriteLog(ex, "Drucker Fehler", "Fehler im Druck-Dialog eines Dokuments")
                MessageBox.Show("Fehler beim Drucken eines Dokumentes aufgetreten.", "Fehler aufgetreten", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

        End Sub

        ''' <summary>
        ''' Führt ein Speichern des aktuellen Datensatzs aus
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()

            SaveCurrentItem()
        End Sub


        ''' <summary>
        ''' Führt ein Speichern des aktuellen Datensatzs aus
        ''' </summary>
        Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

            If ActiveItem.IsDeleted Then
                'TODO: NLS
                MainApplication.getInstance.SendMessage("Zu speicherndes Dokument war als 'gelöscht'markiert. Speichern nicht möglich")
                Exit Sub
            End If

            If ActiveItem IsNot Nothing Then

                If ActiveItem.CashAccount IsNot Nothing Then
                    Me.IsLoading = True ' Refreshs der Oberfläche verhindern

                    ActiveItem.Save()

                    ' Nachdem ein neues Dokument erstmalig gesichert wurde, die Combobox ausschalten; Typewahl ist dann nicht mehr möglich!
                    cobDocumentType.Enabled = False

                    MainApplication.getInstance.SendMessage(GetText("msgsaved", "Gespeichert."))
                    MainUI.MRUManager.AddMRUElement(ActiveItem)
                    Me.IsLoading = False

                Else

                    MessageBox.Show(GetText("msgChooseAnAccountText", "Wählen sie ein Konto aus. " & vbCrLf & _
                                            " Sie müssen ein Buchungskonto für 'Rechnungen' angeben. " & vbCrLf & _
                                            "Wenn Sie noch keine Konten angelegt haben, so erstellen Sie einfach zB ein neues Konto 'Einnahmen'. "), GetText("msgChooseAnAccountHeadline", "Buchungskonto wählen"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SelectCashAccount()
                End If

            End If

            ' Bei neuen Elementen wird nach dem Speichern erst die ID vergeben
            FillDocumentData()

            ' Durch den Neuaufbau in der Oberfläche kann der Status ständig wider geändert worden sein
            m_activeItem.ClearHasChangedState()

        End Sub

        ''' <summary>
        ''' In allen Grids die Positionsnummern neu sortieren
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ReorderSortOrder()
            ' aus den Grids die Artikel neu durchzählen
            Dim RowOrder As Integer = 1
            For parentRowHandler As Integer = 0 To grvPositions.RowCount - 1
                Dim articleView As GridView = CType(grvPositions.GetDetailView(parentRowHandler, 0), GridView)

                ReorderSortOrder(articleView)

                ' Auch die Artikelgruppen neu sortieren lassen
                Dim articleGroup As JournalArticleGroup = CType(grvPositions.GetRow(parentRowHandler), JournalArticleGroup)
                If articleGroup IsNot Nothing Then
                    articleGroup.PositionNumber = RowOrder
                    RowOrder += 1
                End If

            Next
        End Sub
        ''' <summary>
        ''' Die Views neu durchsortieren
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ReorderSortOrder(ByVal view As GridView)


            If view IsNot Nothing Then
                Dim sequence As Integer = 1
                view.BeginSort()
                view.BeginDataUpdate()

                Dim newsequence As Integer = 1
                For rowId As Integer = 0 To view.RowCount - 1
                    Dim sortableElement As ISortableItem = CType(view.GetRow(rowId), ISortableItem)

                    If sortableElement IsNot Nothing Then
                        sortableElement.Sequence = newsequence
                        newsequence += 1
                    End If

                Next

                ' Sortieren auf der Datenquelle wieder einschalten
                '  ds.Sorting.Add(New DevExpress.Xpo.SortProperty("Sequence", DevExpress.Xpo.DB.SortingDirection.Ascending))

                view.EndDataUpdate()
                view.EndSort()

            End If

        End Sub

        Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

        Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
            Get
                Return actionButtons.btnClose Or actionButtons.btnNew Or actionButtons.btnPrint Or actionButtons.btnSave
            End Get
        End Property

        Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
            Get
                If m_activeItem IsNot Nothing Then
                    Return m_activeItem.ReplikID
                Else
                    Return String.Empty
                End If
            End Get
        End Property

        Public Sub DeleteItem() Implements IModule.DeleteItem

        End Sub



        Private Sub grvPositions_ColumnPositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvPositions.ColumnPositionChanged
            Dim col As DevExpress.XtraGrid.Columns.GridColumn = CType(sender, Columns.GridColumn)
            SaveGridStyles(col.View, "GroupsView")
        End Sub


        Private Sub grvPositions_MasterRowEmpty(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles grvPositions.MasterRowEmpty
            e.IsEmpty = False

        End Sub

        Private Sub grvPositions_MasterRowGetRelationCount(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles grvPositions.MasterRowGetRelationCount
            e.RelationCount = 1

        End Sub

        Private Sub grvPositions_MasterRowGetChildList(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles grvPositions.MasterRowGetChildList
            Dim items As JournalArticleGroup
            items = CType(grvPositions.GetRow(e.RowHandle), JournalArticleGroup)

            If items IsNot Nothing Then
                e.ChildList = items.ArticleList
            End If

        End Sub

        Public Overrides Sub Refresh()
            MyBase.Refresh()

            If m_activeItem IsNot Nothing Then
                grdItemsList.BeginUpdate()
                IsLoading = True

                m_activeItem.Reload()

                IsLoading = False
                grdItemsList.EndUpdate()
            End If
            grdItemsList.RefreshDataSource()
        End Sub


        Private Sub grvPositions_MasterRowGetRelationName(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles grvPositions.MasterRowGetRelationName
            e.RelationName = "Items"

        End Sub

        Private Sub grvPositions_MasterRowGetLevelDefaultView(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles grvPositions.MasterRowGetLevelDefaultView

            e.DefaultView = grvItems

        End Sub

        Private Sub grvPositions_MasterRowGetRelationDisplayCaption(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles grvPositions.MasterRowGetRelationDisplayCaption
            e.RelationName = "Hallo"

        End Sub

        Private Sub mnuNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewItem.Click
            CreateNewItem()
        End Sub

        ''' <summary>
        ''' Legt eine neue Artikelgruppe an. Gruppen können Artikel oder einfachen Text enthalten
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CreateNewGroup()
            If DocumentIsLocked Then Exit Sub


            Dim newArticleGroup As New JournalArticleGroup(ActiveItem)
            MakeGroupVisible(newArticleGroup)

            FillPricesumField() ' Hmm.. sollte per Ereignis automatisch aufgerufen werden
        End Sub

        ''' <summary>
        ''' Legt einen neuen Artikel an 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CreateNewItem()

            If DocumentIsLocked Then Exit Sub

            If ActiveItem.ArticleGroups.Count > 0 Then

                Dim article As ClausSoftware.Data.StaticItem = GetNewItemFromDialog()
                If article IsNot Nothing Then



                    Dim currentPos As JournalArticleGroup

                    Dim o As Object = grdItemsList.DefaultView.DataSource

                    If TypeOf o Is JournalArticleGroup Then
                        currentPos = CType(o, JournalArticleGroup)
                    ElseIf TypeOf o Is JournalArticleItems Then
                        Dim Articleitems As JournalArticleItems = CType(o, JournalArticleItems)
                        currentPos = Articleitems.ParentGroup
                    ElseIf TypeOf o Is JournalArticleGroups Then

                        currentPos = CType(grvPositions.GetFocusedRow, JournalArticleGroup)
                    End If

                    Dim newArticleItem As JournalArticleItem = currentPos.ArticleList.GetNewItem


                    ' Falls ein Artikel aus dem Dialog gewählt wurde, dann diesen übernehmen
                    If article IsNot Nothing Then

                        newArticleItem.SetByArticle(CType(article, Kernel.Article))
                    Else
                        newArticleItem.ItemCount = 1
                        newArticleItem.ItemName = GetText("NewArticleDisplayName", "<Neuer Artikel>")

                    End If


                    currentPos.AddJournalItem(newArticleItem)

                End If
                FillPricesumField()
            End If

        End Sub

        ''' <summary>
        ''' Ruft einen neuen Artikel aus einem Dialog ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetNewItemFromDialog() As ClausSoftware.Kernel.Article
            Dim frm As New frmSmallItemChooser
            frm.DataKind = frmSmallItemChooser.DataKindenum.Articles


            If frm.ShowDialog() = DialogResult.OK Then
                Return CType(frm.SelectedItem, Article)
            Else
                Return Nothing
            End If

        End Function



        ''' <summary>
        ''' Füllt die Repository-Items auf
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub FillCombo()

            repUnitCombo.Items.AddRange(MainApplication.getInstance.Units)
            repTaxValues.Items.AddRange(MainApplication.getInstance.TaxRates)


            cobDocumentType.Properties.Items.Clear()

            'Baut aus dem ENUM eine Liste auf 
            For Each item As JournalDocumentType In MainApplication.getInstance.JournalDocuments.DocumentTypeNames

                If Not item.IsALL Then
                    cobDocumentType.Properties.Items.Add(item)
                End If

            Next


        End Sub


        Private Sub repUnitCombo_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles repUnitCombo.EditValueChanged
            Debug.Print("Unit: " & CType(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue.ToString)


        End Sub

        Private Sub EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles repUnitCombo.EditValueChanging, repCurrencyValue.EditValueChanging, repItemsShortText.EditValueChanging, repTaxValues.EditValueChanging

            grvItems.PostEditor()
        End Sub

        Private Sub cmsGrid_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsGridPosition.Opening
            ' Beim öffnen prüfen, welche Optionen möglich sind, und welche nicht 


            Dim view As GridView = CType(grdItemsList.FocusedView, GridView)
            Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(grdItemsList.PointToClient(MousePosition))


            Dim HasItems As Boolean ' Gibvt es in der Auflistung "Artikel" ? 
            Dim IsExpandable As Boolean ' Falls Artikel, sind diese erweiterbar?  (stückliste?)

            mnuNewItem.Enabled = Not DocumentIsLocked

            'Kopieren / Einfügen /Duplizieren gilt immer für alle Artikel
            If view.GetSelectedRows.Length = 0 Then
                mnuCopyPosition.Enabled = False
                mnuDeletePosition.Enabled = False
                btnCreateDuplicate.Enabled = False

            Else
                mnuCopyPosition.Enabled = True
                mnuDeletePosition.Enabled = Not DocumentIsLocked
                btnCreateDuplicate.Enabled = Not DocumentIsLocked

                ' Es wurde etwas selektiert

                ' Hier die Liste der selektierten Elemente durchgehen und auf Eigenschaften der Artikel prüfen
                For Each rowID As Integer In view.GetSelectedRows
                    Dim selectedItem As StaticItem = CType(view.GetRow(rowID), StaticItem)
                    If TypeOf selectedItem Is JournalArticleItem Then
                        Dim jItem As JournalArticleItem = CType(selectedItem, JournalArticleItem)
                        If jItem.IsItem Then
                            HasItems = True
                        End If
                        If jItem.IsItem Then
                            If jItem.GetArticleItem IsNot Nothing Then
                                If jItem.GetArticleItem.SubArticles.Count > 0 Then
                                    IsExpandable = True
                                End If
                            Else
                                IsExpandable = False
                            End If

                        End If

                        ' Kann man wohl noch brauchen..
                    End If

                Next

            End If

            mnuOpenItemData.Enabled = HasItems
            mnuSyncWithOriginItem.Enabled = HasItems And Not DocumentIsLocked
            mnuExpandBOMItems.Enabled = IsExpandable


            ' Caption des Artikel-Views erkennen, und alle Aktionen auf alle Artikel beziehen
            If view.Name = grvPositions.Name Or hi.HitTest = ViewInfo.GridHitTest.ViewCaption Then ' es wurde eine Positions-Zeile angeklickt (auch für Caption-Leiste)
                Dim selectedItem As JournalArticleGroup = CType(grvPositions.GetFocusedRow, JournalArticleGroup)
                If selectedItem IsNot Nothing Then
                    mnuHideItemsPrices.Visible = True
                    mnuHideItemsPrices.Checked = selectedItem.IsHiddenArticlePrices

                    mnuHideItems.Visible = True
                    mnuHideItems.Checked = selectedItem.IsHidddenArticles
                End If
            Else
                mnuHideItems.Visible = False
                mnuHideItemsPrices.Visible = False

            End If

            ' Einfügen nur, wenn auch etwas im Clipboard ist: 

            Dim d As IDataObject = My.Computer.Clipboard.GetDataObject()

            If d.GetDataPresent("JournalArticleItem") Or d.GetDataPresent("JournalArticleGroup") Then
                mnuInsertPositionFromClipboard.Enabled = Not DocumentIsLocked
            Else
                mnuInsertPositionFromClipboard.Enabled = False


            End If

        End Sub

        Private Sub mnuCopyPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopyPosition.Click
            CopySelectedToClipboard()
        End Sub

        ''' <summary>
        ''' Kopiert alle markierten Einträge in das Clipboard
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CopySelectedToClipboard()
            Dim view As GridView = CType(grdItemsList.FocusedView, GridView)
            Dim d As New DataObject()

            Dim ItemsList As New System.Collections.Generic.List(Of JournalArticelItemProxy) ' Sofern eine LIste mit Artikel markiert wurde
            Dim GroupList As New System.Collections.Generic.List(Of JournalArticleGroupProxy) ' Sofern eine Liste von artikelgruppen gewählt wurde, dann diese übertragen
            If view.Name = grvItems.Name Then
                ' Jede markierte Zeile durchlaufen; und alles ins clipboard stecken
                For Each n As Integer In view.GetSelectedRows
                    Dim data As JournalArticleItem = CType(view.GetRow(n), JournalArticleItem)
                    'Kopie anlagen 
                    Dim ItemProxy As New JournalArticelItemProxy(data)

                    ItemsList.Add(ItemProxy)

                Next

                d.SetData("JournalArticleItem", ItemsList) ' eine Liste der Artikel kopieren
            End If

            'Positionen: 
            If view.Name = grvPositions.Name Then
                ' Jede markierte Zeile durchlaufen; und alles ins clipboard stecken
                For Each n As Integer In view.GetSelectedRows
                    Dim data As JournalArticleGroup = CType(view.GetRow(n), JournalArticleGroup)
                    'Kopie anlagen 
                    Dim ItemProxy As New JournalArticleGroupProxy(data)

                    GroupList.Add(ItemProxy)

                Next

                d.SetData("JournalArticleGroup", GroupList) ' eine LIste der Artikel kopieren
            End If

            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetDataObject(d)
        End Sub

        Private Sub mnuDeletePosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeletePosition.Click
            RemoveSelectedRows()
        End Sub

        ''' <summary>
        ''' Entfernt alle markierten Zeilen des Grids aus der Auflistung.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub RemoveSelectedRows()

            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(grdItemsList.FocusedView, GridView)
            If View Is Nothing Then Exit Sub


            Dim RowData As ClausSoftware.Data.StaticItem
            Dim rowDataList() As ClausSoftware.Data.StaticItem
            Dim I As Integer

            ReDim rowDataList(View.SelectedRowsCount - 1)
            For I = 0 To View.SelectedRowsCount - 1
                rowDataList(I) = CType(View.GetRow(View.GetSelectedRows(I)), ClausSoftware.Data.StaticItem)
            Next

            View.BeginSort()
            Try
                For Each RowData In rowDataList

                    If TypeOf RowData Is JournalArticleGroup And RowData IsNot Nothing Then
                        Dim row As JournalArticleGroup = CType(RowData, JournalArticleGroup)

                        If row.ArticleList.Count > 0 Then

                            Dim msgText As String = GetText("msgDoYouWantToDeleteArticleGroupWithArticles", "Die Artikelgruppe ""{0}"" enthält noch weitere Artikel. " & vbCrLf & " Möchten Sie diese ebenfalls löschen?", row.HeaderText)
                            Dim headText As String = GetText("headDoYouWantToDeleteArticleGroupWithArticles", "Artikelgruppe löschen")
                            Dim result As DialogResult = MessageBox.Show(msgText, headText, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                            If result = DialogResult.Cancel Then Exit Sub

                            If result = DialogResult.Yes Then
                                m_activeItem.ArticleGroups.Remove(row)

                                Continue For
                            Else
                                Exit Sub
                            End If

                        Else ' Ohne Rückfrage löschen
                            m_activeItem.ArticleGroups.Remove(row)

                        End If

                    End If

                    If TypeOf RowData Is JournalArticleItem Then
                        Dim ArticleItem As JournalArticleItem = CType(RowData, JournalArticleItem)
                        Dim parentPos As JournalArticleGroup = ArticleItem.ParentArticleGroup

                        ' Erst beim Speichern tatsächlich löschen !

                        parentPos.RemoveItem(ArticleItem)
                    End If

                Next

                ReorderSortOrder()

            Finally
                View.EndSort()
            End Try
        End Sub

        ''' <summary>
        ''' Kopiert die selektierten Einträge innerhalb der Auflistung
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub DuplicateSelectedItem()

            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(grdItemsList.FocusedView, GridView)

            Dim I As Integer

            If View Is grvItems Then ' dann war ein Artikel in einer Position markiert
                ' Stelle aktive Position fest


            End If

            For I = 0 To View.SelectedRowsCount - 1


                Dim itemToCopy As StaticItem = CType(View.GetRow(View.GetSelectedRows(I)), ClausSoftware.Data.StaticItem)
                Dim newItem As StaticItem = CType(itemToCopy.Clone, StaticItem)
                If TypeOf newItem Is JournalArticleItem Then
                    CType(newItem, JournalArticleItem).ParentArticleGroup = CType(itemToCopy, JournalArticleItem).ParentArticleGroup
                End If

                InsertItemAt(newItem)


            Next
            ReorderSortOrder()
        End Sub
        ''' <summary>
        ''' Fügt das angegebnene Element an seine "Parent" - Position wieder ein
        ''' </summary>
        ''' <param name="newItem"></param>
        ''' <remarks></remarks>
        Private Sub InsertItemAt(ByVal newItem As StaticItem)

            If newItem Is Nothing Then Exit Sub

            If TypeOf newItem Is JournalArticleItem Then ' Der Position hinzufügen
                Dim parentGroup As JournalArticleGroup = CType(newItem, JournalArticleItem).ParentArticleGroup

                If parentGroup IsNot Nothing Then
                    parentGroup.AddJournalItem(CType(newItem, JournalArticleItem))
                End If

            End If

            If TypeOf newItem Is JournalArticleGroup Then ' Eine neue Gruppe hinzufügen
                Dim parentDocument As JournalDocument = CType(newItem, JournalArticleGroup).ParentDocument

                If parentDocument IsNot Nothing Then
                    parentDocument.AddArticleGroup(CType(newItem, JournalArticleGroup))
                End If

            End If
        End Sub

        Private Sub mnuDuplicatePosition_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateDuplicate.Click
            DuplicateSelectedItem()
        End Sub




        Private Sub chkShowWithTax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not IsLoading Then
                If m_activeItem IsNot Nothing Then
                    m_activeItem.ShowWithoutTax = Not chkShowWithoutTax.Checked
                    Dim view As DevExpress.XtraGrid.Views.Grid.GridView
                    view = CType(grdItemsList.DefaultView, GridView)

                    view.RefreshData()


                    For row As Integer = 0 To grvPositions.RowCount - 1
                        grvPositions.RefreshRow(row)

                    Next
                End If

            End If
        End Sub

        Private m_OldItemsPosValue, m_oldGroupPosValue As Integer

        Private Sub grvPositions_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvPositions.CellValueChanging
            ' Vorab die Sequenze-Nummer der Zeile holen; im Changed-event ist diese bereits zugewiesen
            If e.Column.Name = colGroupSortOrder.Name Then
                Dim view As GridView = CType(sender, GridView)
                Dim RowToMove As JournalArticleGroup = CType(view.GetRow(e.RowHandle), JournalArticleGroup)
                m_oldGroupPosValue = RowToMove.PositionNumber
            End If
        End Sub

        Private Sub grvItems_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvItems.CellValueChanging
            ' Vorab die Sequenze-Nummer der Zeile holen; im Changed-event ist diese bereits zugewiesen
            If e.Column.Name = colItemSortOrder.Name Then
                Dim view As GridView = CType(sender, GridView)
                Dim RowToMove As JournalArticleItem = CType(view.GetRow(e.RowHandle), JournalArticleItem)
                If RowToMove IsNot Nothing Then ' Kann nothing sein, wenn Filterzeile erwischt..
                    m_OldItemsPosValue = RowToMove.Sequence
                End If

            End If
        End Sub



        Private Sub grvItems_CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles grvItems.CustomColumnDisplayText
            If e.Column.Name = colItemUnit.Name Then

                Dim item As JournalArticleItem = CType(CType(sender, GridView).GetRow(e.RowHandle), JournalArticleItem)
                If item IsNot Nothing Then
                    If item.ItemUnit IsNot Nothing Then ' Falls keine einheit gewählt wurde, dann ist diese 'Nothing'
                        e.DisplayText = item.ItemUnit.ToString
                    End If

                End If
                Exit Sub
            End If

            If e.Column.Name = colTaxRate.Name Then
                Dim item As JournalArticleItem = CType(CType(sender, GridView).GetRow(e.RowHandle), JournalArticleItem)
                If item IsNot Nothing Then
                    If item.TaxRate IsNot Nothing Then ' Falls keine einheit gewählt wurde, dann ist diese 'Nothing'
                        e.DisplayText = item.TaxRate.ToString
                    End If

                End If
                Exit Sub
            End If

        End Sub


        Private Sub grvItems_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles grvItems.RowUpdated

            If Not grvItems.GetMasterRowExpanded(e.RowHandle) Then
                grvItems.ExpandMasterRow(e.RowHandle)
            End If


        End Sub

        Private Sub grvItems_InitNewRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grvItems.InitNewRow
            Dim gv As GridView = CType(sender, GridView)
            Dim item As JournalArticleItem = CType(gv.GetFocusedRow, JournalArticleItem)
            ' Wird aufgerufen, bevor in der NEwLine ein neuer Datensatz bearbeitet wird, aber noch nicht der Auflistung hinzugefügt wurde
            If item.IsNew Then
                item.ParentArticleGroup = GetFocusedArticleGroup()
                item.ShowWithTax = m_activeItem.ShowWithoutTax
                item.Sequence = item.ParentArticleGroup.ArticleList.GetMaxPositionNumber + 1
                item.TaxRate = MainApplication.getInstance.Settings.ItemsSettings.DefaultUnboundTaxRate

                item.ParentArticleGroup.AddJournalItem(item)

            End If


        End Sub


        ''' <summary>
        ''' Ruft die aktuell focussierte Artiklgruppe ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetFocusedArticleGroup() As JournalArticleGroup
            'Return TryCast(CType(grdItemsList.FocusedView, GridView).GetFocusedRow, JournalArticleGroup)
            'If grdItemsList.FocusedView Is grvPositions Then
            '    Return TryCast(CType(grdItemsList.FocusedView, GridView).GetFocusedRow(), JournalArticleGroup)
            'Else
            '    Return TryCast(CType(CType(grdItemsList.FocusedView, GridView).ParentView, GridView).GetFocusedRow(), JournalArticleGroup)
            'End If


            Dim source As Object = grdItemsList.FocusedView.DataSource

            If TypeOf source Is JournalArticleItems Then
                Return CType(source, JournalArticleItems).ParentGroup
            ElseIf TypeOf source Is JournalArticleGroup Then
                ' Dann kann es selber nur die Vater-View gewesen sein: 
                Return CType(source, JournalArticleGroup)
            ElseIf TypeOf source Is JournalArticleGroups Then
                ' Dann die Focussierte Gruppe suchen 

                Dim o As Object = CType(grdItemsList.FocusedView, GridView).GetFocusedRow
                If o IsNot Nothing Then
                    If TypeOf o Is JournalArticleGroup Then
                        Return CType(o, JournalArticleGroup)

                    End If
                End If

            End If




        End Function

        ''' <summary>
        ''' Ruft den aktuell focussierten im Grid Artikel ab.
        ''' wenn kein Artikel den Focus hat, dann wird nothing zurückgegeben
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetFocusedArticle() As JournalArticleItem
            Return TryCast(CType(grdItemsList.FocusedView, GridView).GetFocusedRow, JournalArticleItem)
        End Function

        Private Sub cobDocumentType_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobDocumentType.SelectedValueChanged
            If m_activeItem IsNot Nothing Then
                m_activeItem.DocumentType = CType(CType(cobDocumentType.SelectedItem, JournalDocumentType).InternalID, enumJournalDocumentType)

                If Not Me.IsLoading Then ' Nur Benutzereingaben ermitteln; niht das Laden von Dokumente
                    MainApplication.getInstance.Settings.ItemsSettings.LastUsedDocumentType = m_activeItem.DocumentType
                End If

            End If
        End Sub

        Private Sub repItemsShortTextB_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repItemsShortTextB.ButtonClick
            If TypeOf e.Button.Tag Is String Then
                If CStr(e.Button.Tag) = "search" Then
                    SearchAndReplaceItem()

                    Exit Sub
                End If
                If CStr(e.Button.Tag) = "langtext" Then
                    SetItemsDescription()


                End If

            End If
        End Sub

        ''' <summary>
        ''' Öffnet einen Dialog um den Langtext des aktuell foccussierten Artikels zu bearbeiten
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetItemsDescription()
            ' Langtext bearbeiten
            Dim rowHandle As Integer = CType(grdItemsList.FocusedView, GridView).FocusedRowHandle
            If rowHandle < 0 Then Exit Sub

            SetItemsDescription(rowHandle)

        End Sub

        ''' <summary>
        ''' Öffnet einen Dialog um den Langtext des mit dem Parameter RowHandle definierten Artikels zu bearbeiten
        ''' </summary>
        ''' <param name="rowHandle"></param>
        ''' <remarks></remarks>
        Private Sub SetItemsDescription(ByVal rowHandle As Integer)
            If rowHandle < 0 Then Exit Sub
            Debug.Print("focused View:" & grdItemsList.FocusedView.Name)
            Dim currentArticle As Kernel.JournalArticleItem = CType(grdItemsList.FocusedView.GetRow(rowHandle), JournalArticleItem)

            'Using frm As New frmeditItemsDescription
            '    frm.Description = currentArticle.ItemMemoText

            '    If frm.ShowDialog() = DialogResult.OK Then
            '        currentArticle.ItemMemoText = frm.Description
            '    End If
            'End Using

            RTFItemDescriptionEdit.Clear()


            RTFItemDescriptionEdit.RTFText = currentArticle.RTFItemMemoText

            If RTFItemDescriptionEdit.ShowDialog = DialogResult.OK Then
                currentArticle.RTFItemMemoText = RTFItemDescriptionEdit.RTFText
                currentArticle.ItemMemoText = RTFItemDescriptionEdit.PlainText

            End If
        End Sub

        ''' <summary>
        ''' Fügt einen anderen Artikel an Stelle des aktuellen Artikels ein
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SearchAndReplaceItem()
            ' Aktuellen Artikel ermitteln 
            If TypeOf grdItemsList.FocusedView Is GridView Then

                Dim rowHandle As Integer = CType(grdItemsList.FocusedView, GridView).FocusedRowHandle

                Debug.Print("focused View:" & grdItemsList.FocusedView.Name)
                Dim currentArticle As Kernel.JournalArticleItem = CType(grdItemsList.FocusedView.GetRow(rowHandle), JournalArticleItem)

                ' Suche ausführen und Artikel auswählen lassen
                Dim article As Kernel.Article = GetNewItemFromDialog()
                If article IsNot Nothing Then
                    'TODO: fokussierte Position ermitteln
                    If currentArticle IsNot Nothing Then ' Bestehenden Artikel überschreiben

                        currentArticle.SetByArticle(article)
                    Else ' Neuen Artikel in der Focusssierten Artikelgruppe hinzufügen

                        Dim currentPos As JournalArticleGroup = CType(grvPositions.GetFocusedRow, JournalArticleGroup)
                        currentPos.AddArticleItem(article)
                    End If

                    grdItemsList.FocusedView.UpdateCurrentRow()

                End If

            End If
        End Sub


        Private Sub chkShowPreviewLines_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowPreviewLines.CheckedChanged

            If Not IsLoading Then
                grvItems.OptionsView.ShowPreview = chkShowPreviewLines.Checked

                grvItems.OptionsView.AutoCalcPreviewLineCount = True
            End If

        End Sub

        Private Sub grvPositions_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvPositions.KeyDown
            If e.KeyCode = Keys.Add Or e.KeyCode = Keys.Return Then
                grvPositions.ExpandMasterRow(grvPositions.FocusedRowHandle)
            End If
        End Sub

        Private Sub splBillsHeaderPane1_SplitGroupPanelCollapsed(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.SplitGroupPanelCollapsedEventArgs) Handles splBillsHeaderPane.SplitGroupPanelCollapsed
            MainApplication.getInstance.Settings.SetSetting(splBillsHeaderPane.Name & "_Collapsed", "Bills", e.Collapsed.ToString)

        End Sub



        Private Sub SplitContainerControl1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles splBillsHeaderPane.SplitterMoved
            If splBillsHeaderPane.SplitterPosition > 195 Then
                splBillsHeaderPane.SplitterPosition = 195
            End If

            MainApplication.getInstance.Settings.SetSetting(splBillsHeaderPane.Name & "_pos", "Bills", splBillsHeaderPane.SplitterPosition.ToString)


        End Sub

        Public Sub New()
            Me.IsLoading = True

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()

            ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
            Me.IsLoading = False
        End Sub

        Public Sub New(ByVal myUI As MainUI)
            MyBase.New(myUI)

            Me.IsLoading = True

            InitializeComponent()

            Me.IsLoading = False
        End Sub


        ''' <summary>
        ''' Ruft ein kleines Anzeigebild ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
            Get
                Return My.Resources.Contract_16x16
            End Get
        End Property


        ''' <summary>
        ''' Füllt die Steuerelemente auf
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub FillHeaderControls()
            If m_activeItem IsNot Nothing Then
                txtAdresswindow.Text = m_activeItem.AddressWindow

                If m_activeItem.Address IsNot Nothing Then
                    Me.ActiveAddress = m_activeItem.Address
                End If

                txtHeadText.Text = m_activeItem.HeadText
                txtFooterText.Text = m_activeItem.FooterText
                txtDescription.Text = m_activeItem.TitelText

                ' Zahlungsziel ist immer grösser als das Rechnungsdatum, daher die Anzahl der Tage berechnen lassen 
                Dim dateDiff As Integer
                dateDiff = m_activeItem.PaymentTarget.Subtract(m_activeItem.DocumentDate).Days
                If dateDiff < 0 Then
                    m_activeItem.PaymentTarget = m_activeItem.DocumentDate
                    dateDiff = 0
                    Debug.Print("Zahlungsziel liegt in der Vergangenheit! wurde auf '0' gesetzt")
                End If

                txtTargetPaymentDays.EditValue = dateDiff
                Select Case dateDiff
                    Case 14 : radPaimentDate.SelectedIndex = 1
                    Case 30 : radPaimentDate.SelectedIndex = 2
                    Case Else : radPaimentDate.SelectedIndex = 3
                End Select
                If m_activeItem.CashAccount IsNot Nothing Then
                    btnCashAccount.Text = m_activeItem.CashAccount.ToString
                Else
                    m_activeItem.CashAccount = MainApplication.getInstance.Settings.LastSelectedCashAccount
                End If


            End If
        End Sub

        Private Sub btnSearchAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAdress.Click
            Using frm As New frmSmallItemChooser
                Try
                    frm.DataKind = frmSmallItemChooser.DataKindenum.Contacts
                    frm.Initialize()
                    frm.ShowDialog()

                    Dim adressItem As ClausSoftware.Data.StaticItem = frm.SelectedItem
                    If ActiveItem IsNot Nothing AndAlso adressItem IsNot Nothing Then
                        Me.ActiveAddress = CType(adressItem, Adress)
                    End If
                Catch ex As Exception
                    ' Ein unbekannter Fehler kann von Zeit zu Zeit auftreten? 
                End Try

            End Using

        End Sub

        ''' <summary>
        ''' Ruft die aktuelle Adresse ab oder legt diese fest, nothing falls nur Benutzerdefiniert ein Adressfenster eingegeben wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ActiveAddress As Adress
            Get
                Return ActiveItem.Address
            End Get
            Set(ByVal value As Adress)

                If ActiveItem Is Nothing Then Exit Property

                If Not IsLoading Then
                    ActiveItem.Address = value
                Else
                    Exit Property
                End If

                txtAdresswindow.Text = ActiveItem.AddressWindow
                ActiveItem.AddressWindowChangedByUser = False

                If ActiveItem.Address IsNot Nothing Then
                    lblAdressdiscountText.Text = ActiveItem.Address.Rabatt

                    If ActiveItem.Address.EnableTargetPayDate Then

                        Select Case ActiveItem.Address.TargetPayDays
                            Case 14 : radPaimentDate.SelectedIndex = 1
                            Case 30 : radPaimentDate.SelectedIndex = 2

                            Case Else
                                radPaimentDate.SelectedIndex = 3 ' andere
                                txtTargetPaymentDays.EditValue = ActiveAddress.TargetPayDays
                        End Select
                    Else
                        ' Kein Zahlungsziel angegeben
                        radPaimentDate.SelectedIndex = 0
                    End If

                Else
                    ' Adresse irgendwie nicht gültig
                    lblAdressdiscountText.Text = String.Empty
                    radPaimentDate.SelectedIndex = 3 ' andere
                    txtTargetPaymentDays.EditValue = ActiveAddress.TargetPayDays
                End If

                ' radPaimentDate.SelectedIndex = '0,1,2,3'  = 0 = Kein; 1 = 14, 2 = 30; 3 = andere

            End Set
        End Property



        Private Sub btnResetAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAdress.Click

            ResetAdresswindow()

        End Sub

        ''' <summary>
        ''' Setzt das Adressfenster zurück, falls vom Benutzer geändert
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ResetAdresswindow()
            If ActiveItem IsNot Nothing Then
                If m_activeItem.Address IsNot Nothing Then
                    ActiveItem.AddressWindow = m_activeItem.Address.InvoiceAdressWindow
                    txtAdresswindow.Text = m_activeItem.AddressWindow
                    ActiveItem.AddressWindowChangedByUser = False
                End If
            End If
        End Sub

        ''' <summary>
        ''' Ruft ein Zieldatum ab, ausgehend vom Datum des Dokuments plu der Anzahl der Tage
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property TargetPayDate As Date
            Get
                Return ActiveItem.DocumentDate.AddDays(CInt(txtTargetPaymentDays.EditValue))
            End Get
            Set(ByVal value As Date)

                txtTargetPaymentDays.EditValue = value.Subtract(ActiveItem.DocumentDate).Days

            End Set
        End Property

        Private m_TargetDateChanging As Boolean

        Private Sub txtDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTargetPaymentDays.EditValueChanged
            Dim value As Integer = CInt(txtTargetPaymentDays.EditValue)
            If m_TargetDateChanging Then Exit Sub
            m_TargetDateChanging = True

            If value <> 14 And value <> 30 Then
                radPaimentDate.SelectedIndex = -1
            End If

            If value < 0 Then
                value = 0
            Else
                If ActiveItem IsNot Nothing Then
                    ActiveItem.PaymentTarget = m_activeItem.DocumentDate.AddDays(value)
                    Select Case value
                        Case 14 : radPaimentDate.SelectedIndex = 1
                        Case 30 : radPaimentDate.SelectedIndex = 2
                        Case Else
                            radPaimentDate.SelectedIndex = 3 ' Andere
                    End Select
                End If

            End If
            m_TargetDateChanging = False
        End Sub

        Private Sub txtAdresswindow_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdresswindow.EditValueChanged
            If ActiveItem IsNot Nothing Then
                ActiveItem.AddressWindow = txtAdresswindow.Text
                ActiveItem.AddressWindowChangedByUser = True
                lblAdressLine.Text = txtAdresswindow.Text
            End If

        End Sub


        Private Sub setHeader_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If MainApplication.getInstance IsNot Nothing Then
                Dim collapsed As Boolean
                Dim pos As Integer
                collapsed = CBool(MainApplication.getInstance.Settings.GetSetting(splBillsFooterPane.Name & "_Collapsed", "Bills", Boolean.FalseString))
                pos = CInt(MainApplication.getInstance.Settings.GetSetting(splBillsFooterPane.Name & "_pos", "Bills", splBillsFooterPane.SplitterPosition.ToString))

                splBillsFooterPane.SplitterPosition = pos
                splBillsFooterPane.Collapsed = collapsed


                repItemsShortTextB.Buttons(0).Image = My.Resources.view

                collapsed = CBool(MainApplication.getInstance.Settings.GetSetting(splBillsHeaderPane.Name & "_Collapsed", "Bills", Boolean.FalseString))
                pos = CInt(MainApplication.getInstance.Settings.GetSetting(splBillsHeaderPane.Name & "_pos", "Bills", splBillsHeaderPane.SplitterPosition.ToString))

                splBillsHeaderPane.SplitterPosition = pos
                splBillsHeaderPane.Collapsed = collapsed

                RestoreGridStyles(grvItems, "ItemsView")
                grvItems.ClearSorting()
                grvItems.SortInfo.Add(colItemSortOrder, DevExpress.Data.ColumnSortOrder.Ascending)

                grvItems.OptionsView.NewItemRowPosition = NewItemRowPosition.Top
                grvItems.NewItemRowText = GetText("BillsGridNewItemRow", "Klicken Sie hier, um eine neue Artikelzeile anzulegen")

                RestoreGridStyles(grvPositions, "GroupsView")

                grvPositions.ClearSorting()
                grvPositions.SortInfo.Add(colGroupSortOrder, DevExpress.Data.ColumnSortOrder.Ascending)

                colItemSortOrder.SortMode = ColumnSortMode.Value
                colItemSortOrder.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                colItemNumber.SortMode = ColumnSortMode.Value
                colItemNumber.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending


                txtFooterText.Properties.MaxLength = CInt(MainApplication.getInstance.Database.GetColumnCharacterLength(JournalDocument.Tablename, "Fusstext"))
                txtHeadText.Properties.MaxLength = CInt(MainApplication.getInstance.Database.GetColumnCharacterLength(JournalDocument.Tablename, "Kopftext"))

                FillCombo()
                ReduceTaxFields()

                ' Neues Dokumenbt erstellen
                NewDocument()
            End If

            chkShowPreviewLines.Checked = grvItems.OptionsView.ShowPreview

        End Sub



        ''' <summary>
        ''' Zeigt ein Preview des Kopftextes an; löst die Platzhalter auf
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ShowPreviewHeaderText()
            Dim inText As String
            Dim outText As String


            inText = txtHeadText.Text
            ActiveItem.HeadText = inText
            outText = ActiveItem.HeadText

            If outText.Length = 0 Then
                outText = GetText("msgNoTextGiven", "-- Kein Text angegeben --")
            End If

            ' nun Platzhalter auflösen lassen 
            ' im Jorunal aufhängen?              
            MessageBox.Show(outText, GetText("msgPreviewHeader", "Vorschau (Kopftext)"), MessageBoxButtons.OK, MessageBoxIcon.None)

        End Sub

        ''' <summary>
        ''' Zeigt ein Preview des Fusstextes an. Löst die Platzhalter auf
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ShowPreviewFooterText()
            Dim inText As String
            Dim outText As String


            inText = txtFooterText.Text
            ActiveItem.FooterText = inText
            outText = ActiveItem.FooterText

            If outText.Length = 0 Then
                outText = GetText("msgNoTextGiven", "-- Kein Text angegeben --")
            End If

            ' nun Platzhalter auflösen lassen 
            ' im Jorunal aufhängen?              
            MessageBox.Show(outText, GetText("msgPreviewFooter", "Vorschau (Fusstext)"), MessageBoxButtons.OK, MessageBoxIcon.None)

        End Sub


        Private Sub txtDescription_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.EditValueChanged
            If ActiveItem IsNot Nothing Then
                ActiveItem.TitelText = txtDescription.Text
            End If
        End Sub


        Private Sub TextEditor_QueryPopup(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFooterText.QueryPopUp, txtHeadText.QueryPopUp

            'Erzwingt eine KOnstante Breite des Kopftext-Fensters
            Dim baseTextbox As DevExpress.XtraEditors.MemoExEdit = CType(sender, DevExpress.XtraEditors.MemoExEdit)
            Dim item As Control = baseTextbox.GetChildAtPoint(baseTextbox.PointToClient(MousePosition))

            baseTextbox.Properties.PopupFormSize = New System.Drawing.Size(CType(sender, DevExpress.XtraEditors.MemoExEdit).Width, baseTextbox.Properties.PopupFormSize.Height)

        End Sub

        Private Sub talPrices_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles talPrices.Resize
            pnlLowerSubPanel.Height = talPrices.Height

        End Sub

        Private Sub ToggleTaxField()
            If talPrices.RowStyles(1).Height > 0 Then
                talPrices.RowStyles(1).Height = 0
                ReduceTaxFields()
                txtDiscountedValue.Visible = False
            Else
                talPrices.RowStyles(1).Height = radDiscountType.Height
                ShowTaxFields()
                txtDiscountedValue.Visible = True

            End If
        End Sub

        Private Sub cmdDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

            ToggleTaxField()



        End Sub

        Private Sub cmdAddArticleGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddArticleGroup.Click
            CreateNewGroup()
        End Sub

        Private Sub HeadFooterText_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeadText.EditValueChanged, txtFooterText.EditValueChanged

            If ActiveItem IsNot Nothing Then
                If sender Is txtHeadText Then
                    ActiveItem.HeadText = CStr(txtHeadText.EditValue)
                End If
                If sender Is txtFooterText Then
                    ActiveItem.FooterText = CStr(txtFooterText.EditValue)
                End If


            End If

        End Sub

        Private Sub btnOpenItemData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenItemData.Click

            OpenSelectedItemInWorkPane()

        End Sub
        ''' <summary>
        ''' Öffnet die markierten einträge in ihrem eigenen Workpane
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub OpenSelectedItemInWorkPane()
            Dim selectedItem As StaticItem
            Dim activeView As GridView = CType(grdItemsList.FocusedView, GridView)

            If activeView.GetSelectedRows.Length > 0 Then
                For Each rowID As Integer In activeView.GetSelectedRows
                    selectedItem = CType(activeView.GetRow(rowID), StaticItem)

                    If TypeOf selectedItem Is JournalArticleItem Then
                        Dim journalItem As JournalArticleItem = CType(selectedItem, JournalArticleItem)
                        If journalItem.IsItem Then
                            Dim articleItem As Article = CType(selectedItem, JournalArticleItem).GetArticleItem

                            MainUI.OpenElementWindow(articleItem)
                        End If

                    End If
                Next

            End If
        End Sub


        Private Sub btnSyncWithOriginItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSyncWithOriginItem.Click
            SyncWithOrgItem()
        End Sub

        Private Sub SyncWithOrgItem()
            Dim selectedItem As StaticItem
            Dim activeView As GridView = CType(grdItemsList.FocusedView, GridView)

            If activeView.GetSelectedRows.Length > 0 Then
                For Each rowID As Integer In activeView.GetSelectedRows
                    selectedItem = CType(activeView.GetRow(rowID), StaticItem)

                    If TypeOf selectedItem Is JournalArticleItem Then

                        CType(selectedItem, JournalArticleItem).SyncWithItem()


                    End If
                Next

                ' Neue Preise anzeigen lassen 
                FillPricesumField()
            End If
        End Sub

        Private Sub grvItems_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvItems.KeyDown
            If grvItems.ActiveEditor Is Nothing Then
                If e.KeyData = Keys.Delete Then
                    RemoveSelectedRows()
                    e.Handled = True
                End If
            End If


            If grvItems.FocusedColumn.Name = colItemShortText.Name Then
                If e.KeyData = Keys.F2 Then
                    CreateNewItem()
                End If
            End If


        End Sub

        Private Sub mnuExpandItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExpandBOMItems.Click
            ExpandSelectedItem()
        End Sub

        ''' <summary>
        ''' Expandiert den Artikel wenn dieser eine Tsückliste enthält
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ExpandSelectedItem()

            Dim activeView As GridView = CType(grdItemsList.FocusedView, GridView)
            Dim selectedItem As JournalArticleItem

            Dim currentPos As JournalArticleGroup = CType(grvPositions.GetFocusedRow, JournalArticleGroup)

            For Each rowid As Integer In activeView.GetSelectedRows
                selectedItem = TryCast(activeView.GetRow(rowid), JournalArticleItem)
                If selectedItem IsNot Nothing Then
                    If selectedItem.GetArticleItem.SubArticles.Count > 0 Then
                        ' NUn fargen, ob er Artikel erweitert werden soll
                        Dim result As DialogResult = MessageBox.Show("Möchten sie den Artikel:'" & selectedItem.ItemName & "' erweitern?" & vbCrLf & _
                                                                     "Es werden dann alle enthaltenen Einzelteile in das Dokument aufgenommen.", "Artikel erweitern", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                        If result = DialogResult.Cancel Then
                            Exit Sub
                        End If

                        If result = DialogResult.No Then
                            Continue For
                        End If
                        ' Nun den Artikel auflösen: 
                        ' JournalArtikel löschen
                        ' Alle einzelnen ayrtikel abholen
                        For Each item As BOM.ArticleLink In selectedItem.GetArticleItem.SubArticles
                            Dim newArticleItem As JournalArticleItem = currentPos.ArticleList.GetNewItem
                            newArticleItem.SetByArticle(item.Article)

                            newArticleItem.ItemCount = CDec(item.Quantity)


                            currentPos.AddJournalItem(newArticleItem)

                        Next
                        currentPos.RemoveItem(selectedItem)
                    End If


                End If
                ' 1. Rückfrage, "Kann nicht rückgängig gemacht werden"
                ' 2. stückliste nehmen
                ' 3. neue Gruppe anölegen 
                ' 4. Alle Artikel der stückliste durchgehen und als Artikel einfügen
            Next

        End Sub


        Private Sub lblDays_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub



        Private Sub txtHeadText_Properties_Click(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtHeadText.Properties.ButtonClick, txtFooterText.Properties.ButtonClick
            ' Button click auf den Preview -Button 
            If TypeOf e.Button.Tag Is String Then

                ' Vorschau mit aufgelösten Platzhalten setzen
                If CStr(e.Button.Tag) = "preview" Then
                    If sender Is txtHeadText Then
                        ShowPreviewHeaderText()
                    End If

                    If sender Is txtFooterText Then
                        ShowPreviewFooterText()
                    End If

                    Exit Sub
                End If

                ' Aus den Vorlagen den Text anzeigen lassen 
                If CStr(e.Button.Tag) = "template" Then

                    Dim frm As New frmSmallItemChooser()
                    frm.DataKind = frmSmallItemChooser.DataKindenum.TextTemplates
                    If frm.ShowDialog = DialogResult.OK Then
                        ' daten übernehmen 

                        Dim template As Kernel.TextTemplate = CType(frm.SelectedItem, Kernel.TextTemplate)
                        If template IsNot Nothing Then
                            If sender Is txtHeadText Then
                                txtHeadText.Text = template.Text
                            End If

                            If sender Is txtFooterText Then
                                txtFooterText.Text = template.Text
                            End If
                        End If
                    End If

                End If
            End If


        End Sub


        Private Sub grvPositions_MasterRowExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles grvPositions.MasterRowExpanded
            Debug.Print(CType(sender, DevExpress.XtraGrid.Views.Base.BaseView).Name & " " & CType(sender, DevExpress.XtraGrid.Views.Base.BaseView).RowCount)

            ' beim expandieren der Artikelgruppen, das Detail sofort Zoomen (maximale Ansicht)
            Dim view As GridView = CType(grvPositions.GetDetailView(e.RowHandle, e.RelationIndex), GridView)
            view.ZoomView()
            If Not m_IsActiveLoad Then
                RestoreGridStyles(view, "ItemsView")
                grvItems.ClearSorting()
                grvItems.SortInfo.Add(colItemSortOrder, DevExpress.Data.ColumnSortOrder.Ascending)
            End If

            'grvItems.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom

        End Sub


        ''' <summary>
        ''' Ruft die Auflistung an gedraggten Zeilen ab
        ''' </summary>
        ''' <param name="view"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetDragData(ByVal view As GridView) As JournalArticleItem()
            Dim selecetion As Integer() = view.GetSelectedRows
            If selecetion Is Nothing Then Return Nothing

            Dim count As Integer = selecetion.Length
            Dim result() As JournalArticleItem = New JournalArticleItem(count) {}
            For i As Integer = 0 To count - 1

                result(i) = CType(view.GetRow(selecetion(i)), JournalArticleItem)
            Next

            Return result
        End Function



        Private Sub grdItemsList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdItemsList.KeyDown

            If e.KeyCode = Keys.C And e.Modifiers = Keys.Control Then
                CopySelectedToClipboard()
            End If

            If e.KeyCode = Keys.V And e.Modifiers = Keys.Control Then
                PasteClipBoardData()
            End If

            If e.KeyCode = Keys.Delete Then
                RemoveSelectedRows()
            End If

        End Sub



        Private Sub grvItems_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvItems.CellValueChanged
            If e.Column.Name = colItemSortOrder.Name Then
                Dim view As GridView = CType(sender, GridView)

                Dim RowToMove As ISortableItem = CType(view.GetRow(e.RowHandle), ISortableItem)
                If Not RowToMove Is Nothing Then
                    MoveElementToPosition(view, RowToMove, CInt(e.Value), m_OldItemsPosValue)
                End If

                '' wenn das Positions-Feld geändert wurde, neu einsortieren und abspeichern
                'view.BeginSort()

                'Dim newPosID As Integer = CInt(e.Value)
                'Dim oldPosID As Integer
                'If newPosID <= 1 Then newPosID = 1
                'If newPosID > view.RowCount Then newPosID = view.RowCount


                'oldPosID = m_OldItemsPosValue
                'RowToMove.Sequence = 10000

                '' Alle neu durchnummerieren (ausser den germerkten Wert)
                '' Dann den gemerkten Wert einfügen
                '' Kann ganz am ende stehen (newpos > RowCount; dann rowPos = Row.count
                '' kann ganz am Anfang stehen; 0=1
                ''

                'Dim Min, Max As Integer
                'Min = System.Math.Min(oldPosID, newPosID)
                'Max = System.Math.Max(oldPosID, newPosID)

                '' Sequences sind immer um 1 höher als die RowID! 
                'Min -= 1 : Max -= 1

                'Dim nextRowID As Integer = Min + 1

                'If newPosID < oldPosID Then ' wenn ein 'rückwärts-Sprung passiert, dannn bereits eine Nummer überspringem
                '    nextRowID += 1
                'End If
                'For rowID As Integer = Min To Max

                '    Dim artItem As JournalArticleItem = CType(view.GetRow(rowID), JournalArticleItem)

                '    If artItem.Sequence = 10000 Then ' Das ist der Eintrag, der verschoben werden soll
                '        Continue For
                '    End If

                '    artItem.Sequence = nextRowID  ' rowID fängt bei "0" an; dies sollte aber nicht als Positions-Nr übernommen werden
                '    ' normaler Zähler
                '    nextRowID += 1
                'Next

                '' Neue Zeile an der korrekten Stelle einfügen
                'RowToMove.Sequence = newPosID

                'view.EndSort()

            End If
            FillPricesumField() ' Sofern ein Preisfeld geändert wurde, dann die Preisliste neu berechnen

        End Sub


        Private Sub grvPositions_CellValueChanged(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvPositions.CellValueChanged

            If e.Column.Name = colGroupSortOrder.Name Then

                Dim view As GridView = CType(sender, GridView)

                Dim RowToMove As ISortableItem = CType(view.GetRow(e.RowHandle), ISortableItem)
                MoveElementToPosition(view, RowToMove, CInt(e.Value), m_oldGroupPosValue)

                '' wenn das Positions-Feld geändert wurde, neu einsortieren und abspeichern
                'view.BeginSort()

                'Dim newPosID As Integer = CInt(e.Value)
                'Dim oldPosID As Integer
                'If newPosID <= 1 Then newPosID = 1
                'If newPosID > view.RowCount Then newPosID = view.RowCount
                'Dim RowToMove As JournalArticleGroup = CType(view.GetRow(e.RowHandle), JournalArticleGroup)

                'oldPosID = m_OldItemsPosValue
                'RowToMove.PositionNumber = 10000

                '' Alle neu durchnummerieren (ausser den germerkten Wert)
                '' Dann den gemerkten Wert einfügen
                '' Kann ganz am ende stehen (newpos > RowCount; dann rowPos = Row.count
                '' kann ganz am Anfang stehen; 0=1
                ''

                'Dim Min, Max As Integer
                'Min = System.Math.Min(oldPosID, newPosID)
                'Max = System.Math.Max(oldPosID, newPosID)

                '' Sequences sind immer um 1 höher als die RowID! 
                'Min -= 1 : Max -= 1

                'Dim nextRowID As Integer = Min + 1

                'If newPosID < oldPosID Then ' wenn ein 'rückwärts-Sprung passiert, dannn bereits eine Nummer überspringem
                '    nextRowID += 1
                'End If
                'For rowID As Integer = Min To Max

                '    Dim artItem As JournalArticleGroup = CType(view.GetRow(rowID), JournalArticleGroup)

                '    If artItem.PositionNumber = 10000 Then ' Das ist der Eintrag, der verschoben werden soll
                '        Continue For
                '    End If

                '    artItem.PositionNumber = nextRowID  ' rowID fängt bei "0" an; dies sollte aber nicht als Positions-Nr übernommen werden
                '    ' normaler Zähler
                '    nextRowID += 1
                'Next

                '' Neue Zeile an der korrekten Stelle einfügen
                'RowToMove.PositionNumber = newPosID

                'view.EndSort()
            End If
        End Sub


        ''' <summary>
        ''' Verschiebt das angegebene element an die neue logische POsition im Grid
        ''' </summary>
        ''' <param name="element"></param>
        ''' <param name="newLogicalPosition"></param>
        ''' <remarks></remarks>
        Private Sub MoveElementToPosition(view As GridView, element As ISortableItem, newLogicalPosition As Integer, oldLogicalPosition As Integer)
            Try
                ' wenn das Positions-Feld geändert wurde, neu einsortieren und abspeichern
                view.BeginSort()

                Dim newPosID As Integer = newLogicalPosition
                Dim oldPosID As Integer = oldLogicalPosition

                If newPosID <= 1 Then newPosID = 1
                If newPosID > view.RowCount Then newPosID = view.RowCount
                Dim RowToMove As ISortableItem = element

                RowToMove.Sequence = 10000

                ' Alle neu durchnummerieren (ausser den germerkten Wert)
                ' Dann den gemerkten Wert einfügen
                ' Kann ganz am ende stehen (newpos > RowCount; dann rowPos = Row.count
                ' kann ganz am Anfang stehen; 0=1
                '

                Dim Min, Max As Integer
                Min = System.Math.Min(oldPosID, newPosID)
                Max = System.Math.Max(oldPosID, newPosID)

                ' Sequences sind immer um 1 höher als die RowID! 
                Min -= 1 : Max -= 1
                If Min < 0 Then Min = 0

                Dim nextRowID As Integer = Min + 1

                If newPosID < oldPosID Then ' wenn ein 'rückwärts-Sprung passiert, dannn bereits eine Nummer überspringem
                    nextRowID += 1
                End If
                For rowID As Integer = Min To Max

                    Dim artItem As ISortableItem = CType(view.GetRow(rowID), ISortableItem)

                    If artItem IsNot Nothing Then
                        If artItem.Sequence = 10000 Then ' Das ist der Eintrag, der verschoben werden soll
                            Continue For
                        End If
                        artItem.Sequence = nextRowID  ' rowID fängt bei "0" an; dies sollte aber nicht als Positions-Nr übernommen werden
                    End If

                    ' normaler Zähler
                    nextRowID += 1
                Next

                ' Neue Zeile an der korrekten Stelle einfügen
                RowToMove.Sequence = newPosID
            Catch ex As Exception

            Finally

                view.EndSort()
            End Try

        End Sub

        ''' <summary>
        ''' Versucht die Daten des Clipbaords in das Grid einzufügen. 
        ''' Das kann ein Artikel eines anderen Dokumentes sein, eine ganze POsition oder ein Artikl aus der Artikelliste
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PasteClipBoardData()
            ' Prüfen, ob was drinn ist 
            Dim data As IDataObject = My.Computer.Clipboard.GetDataObject

            Dim FocusedParentGroup As JournalArticleGroup = GetFocusedArticleGroup()
            For Each item As String In data.GetFormats
                Select Case item
                    Case "JournalArticleItem" 'Dann war es ein StaticItem (Artikel, Position oder Artikeldaten)

                        Dim newItemList As List(Of JournalArticelItemProxy) = CType(My.Computer.Clipboard.GetData(item), Global.System.Collections.Generic.List(Of Global.ClausSoftware.Kernel.JournalArticelItemProxy))
                        ' Das Vater-element definieren: 
                        ' Aus dem Focussed Group die Parent-Gruppe ermitteln
                        If newItemList IsNot Nothing Then
                            For Each newArticleProxy As JournalArticelItemProxy In newItemList

                                Dim newArticle As JournalArticleItem = FocusedParentGroup.ArticleList.GetNewItem()

                                SetNewItem(newArticle, newArticleProxy) ' den Proxy auf das Element schreiben
                                ' Vater-Element festlegen
                                newArticle.ParentArticleGroup = FocusedParentGroup ' Das eigene Dokument festlegen
                                newArticle.Sequence = newArticle.ParentArticleGroup.ArticleList.Count + 1
                                InsertItemAt(newArticle) ' einfügen

                            Next
                        End If
                    Case "JournalArticleGroup" ' eine ganze Gruppe wurde gewählt
                        Dim newItemList As List(Of JournalArticleGroupProxy) = CType(My.Computer.Clipboard.GetData(item), Global.System.Collections.Generic.List(Of Global.ClausSoftware.Kernel.JournalArticleGroupProxy))
                        If newItemList IsNot Nothing Then
                            For Each posItemProxy As JournalArticleGroupProxy In newItemList
                                Dim newGroup As JournalArticleGroup = Me.ActiveItem.ArticleGroups.GetNewItem
                                With posItemProxy
                                    'Position-eigenschaften setzen 
                                    '...
                                    newGroup.ItemCount = .Itemcount
                                    newGroup.HeaderText = .ItemText
                                    newGroup.PositionNumber = newGroup.ParentDocument.ArticleGroups.Count + 1

                                    ' Doppelte Gruppennamen erkennen
                                    If GroupNameExist(.ItemText) Then
                                        Dim newGroupName As String = .ItemText & " - " & GetText("CopyOf", "Kopie")
                                        newGroup.HeaderText = newGroupName
                                    End If

                                    newGroup.CustomerGroupPrice = .GroupPrice

                                End With

                                ' Alle Artikel der Position setzen
                                For Each newArticleProxy As JournalArticelItemProxy In posItemProxy.ArticleItems

                                    Dim newArticle As JournalArticleItem = newGroup.ArticleList.GetNewItem()

                                    SetNewItem(newArticle, newArticleProxy) ' den Proxy auf das Element schreiben
                                    ' Vater-element festlegen
                                    newArticle.ParentArticleGroup = newGroup ' Das eigene Dokument festlegen

                                    InsertItemAt(newArticle) ' einfügen

                                Next
                                Me.ActiveItem.ArticleGroups.Add(newGroup)


                            Next
                        End If
                End Select
            Next

        End Sub
        ''' <summary>
        ''' Setzt den Artikle-Proxy auf das neue Artikelelement
        ''' </summary>
        ''' <param name="articleItem"></param>
        ''' <param name="articleProxy"></param>
        ''' <remarks></remarks>
        Private Sub SetNewItem(ByVal articleItem As JournalArticleItem, ByVal articleProxy As JournalArticelItemProxy)
            ' Neues Element anlegen (neuen Key, und Neue Instanz erzeugen

            With articleProxy
                articleItem.BasePrice = .BasePrice
                articleItem.SinglePriceBeforeTax = .SinglePriceBeforeTax
                articleItem.ItemCount = .ItemCount
                articleItem.ItemName = .ItemName
                articleItem.ItemMemoText = .ItemMemoText
                articleItem.RTFItemMemoText = .RTFItemMemoText

                articleItem.ItemUnit = MainApplication.getInstance.Units.GetItem(.UnitID)
                'articleItem.ItemPicture = .ItemImage
                articleItem.ManufactorsAddressID = .AdressID
                articleItem.OrgItemID = .OrgItemID

                articleItem.InternalItemNumber = .InternalItemNumber
                articleItem.ExternalItemNumber = .ExternalItemNumber
                articleItem.ItemPicture = .ItemPicture
                articleItem.TimeInMinutes = .TimeInMinutes
                articleItem.DiscountValue = .DiscountValue
                articleItem.TaxRate = MainApplication.getInstance.TaxRates.GetItem(.TaxRateID)

            End With
        End Sub

        Private Sub mnuInsertPositionFromClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInsertPositionFromClipboard.Click
            PasteClipBoardData()
        End Sub

        Private Sub grvItems_ShowingEditor(ByVal sender As Object, ByVal e As EventArgs) Handles grvItems.ShownEditor
            Dim view As GridView = CType(sender, GridView)


            If view.FocusedColumn.Name = colItemUnit.Name Then
                Dim item As JournalArticleItem = CType(view.GetFocusedRow, JournalArticleItem)
                If item IsNot Nothing Then ' Kann sein, wenn eine ungültige Zeile erwischt wurde (die AddRow vielleicht oder Filterzeile) 
                    CType(view.ActiveEditor, DevExpress.XtraEditors.ComboBoxEdit).SelectedItem = item.ItemUnit
                End If
                Exit Sub
            End If

            If view.FocusedColumn.Name = colTaxRate.Name Then
                Dim item As JournalArticleItem = CType(view.GetFocusedRow, JournalArticleItem)
                If item IsNot Nothing Then ' Kann sein, wenn eine ungültige Zeile erwischt wurde (die AddRow vielleicht oder Filterzeile) 
                    CType(view.ActiveEditor, DevExpress.XtraEditors.ComboBoxEdit).SelectedItem = item.TaxRate
                End If

            End If

        End Sub


        ''' <summary>
        ''' schiebt den Arbeitsbereich zusammen oder auseinander
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Toggleworkspace()
            m_workspaceExpanded = Not m_workspaceExpanded

            If m_workspaceExpanded Then
                Me.btnMaximizeworkspace.Image = My.Resources.Collapse_16x16
                Me.btnMaximizeworkspace.ToolTip = "Arbeitsbereich wiederherstellen" 'TODO: NLS
                splBillsHeaderPane.Collapsed = True
                splBillsFooterPane.Collapsed = True


            Else
                Me.btnMaximizeworkspace.Image = My.Resources.FitToHeight_16x16
                Me.btnMaximizeworkspace.ToolTip = "Arbeitsbereich vergrössern" 'TODO: NLS
                splBillsHeaderPane.Collapsed = False
                splBillsFooterPane.Collapsed = False

            End If

        End Sub

        Private Sub btnMaximizeworkspace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaximizeworkspace.Click
            Toggleworkspace()
        End Sub



        Private Sub grvItems_Layout(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvItems.Layout
            Dim view As GridView = CType(sender, GridView)

            If view.Name = grvItems.Name Then ' OK, das Artikel-View ändert sich
                Dim dt As JournalArticleItems = CType(view.DataSource, JournalArticleItems)
                view.ViewCaption = dt.ParentGroup.HeaderText

            End If
            'If Not view.SortedColumns.Contains(colGridOrder) Then
            '    colGridOrder.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            'End If
        End Sub


        Private Sub grvItems_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grvItems.MouseDown
            Dim view As GridView = CType(sender, GridView)
            Dim hi As ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
            With hi

                If e.Button = Windows.Forms.MouseButtons.Left Then 'Nur linke Taste berücksichtigen; RMT ruft Kontetmenü auf
                    If .HitTest = ViewInfo.GridHitTest.ViewCaption Then
                        If view.IsZoomedView Then
                            view.NormalView()
                        Else
                            view.ZoomView()
                        End If
                    End If
                End If

            End With
        End Sub

        Private Sub SubmnuHideItems_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHideItems.CheckedChanged
            SetItemGroupHideItems(mnuHideItems.Checked)
        End Sub

        Private Sub mnuHideItemsPrices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHideItemsPrices.CheckedChanged
            SetItemGroupHidePrices(mnuHideItemsPrices.Checked)
        End Sub

        ''' <summary>
        ''' Setzt die Eigenschaft "Einzelpreise verbergen" für die aktuell markierte Gruppe
        ''' </summary>
        ''' <param name="newValue"></param>
        ''' <remarks></remarks>
        Private Sub SetItemGroupHidePrices(ByVal newValue As Boolean)
            Dim item As JournalArticleGroup = TryCast(grvPositions.GetFocusedRow, JournalArticleGroup)
            If item IsNot Nothing Then
                item.IsHiddenArticlePrices = newValue
                grdItemsList.Refresh()
            End If

        End Sub

        ''' <summary>
        ''' Setzt den Gruppenpreis für die foccussierte Artikelgruppe wieder zurück
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ResetSelectedItemsGroupPrice()
            Dim item As JournalArticleGroup = TryCast(grvPositions.GetFocusedRow, JournalArticleGroup)
            If item IsNot Nothing Then
                item.ResetCustomGroupPrice()
                grdItemsList.Refresh()
            End If
        End Sub

        ''' <summary>
        ''' Setzt die Eigenschaft "Artikel ausblenden" für die aktuell markierte Gruppe.
        ''' Es werden dann die einzelnen Artikel dieser Grupp nicht im Ausdruck dargestellt
        ''' </summary>
        ''' <param name="newValue"></param>
        ''' <remarks></remarks>
        Private Sub SetItemGroupHideItems(ByVal newValue As Boolean)
            Dim item As JournalArticleGroup = TryCast(grvPositions.GetFocusedRow, JournalArticleGroup)
            If item IsNot Nothing Then
                item.IsHidddenArticles = newValue
                If newValue Then
                    SetItemGroupHidePrices(True)   ' wenn der artikel ausgeblenet ist, dann auch auf jeden Fall der Preis. 
                End If
                grdItemsList.Refresh()
            End If

        End Sub

        Private Sub grvItems_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grvItems.CustomDrawCell
            ' Preise grau darstellen, wenn "IsGrouped" gewählt wurde
            Dim view As GridView = CType(sender, GridView)
            If view IsNot Nothing Then
                Dim article As JournalArticleItem = CType(view.GetRow(e.RowHandle), JournalArticleItem)
                If article IsNot Nothing Then

                    Dim articleGroup As JournalArticleGroup = article.ParentArticleGroup
                    If articleGroup IsNot Nothing Then
                        If articleGroup.IsHiddenArticlePrices Then ' Ist diese Gruppe zusammengefasst, dann die Einzelpreise ausblenden 
                            If e.Column.FieldName.Equals("SinglePriceAfterTax") Or _
                                     e.Column.FieldName.Equals("SinglePriceBeforeTax") Or _
                                     e.Column.FieldName.Equals("TotalPriceAfterTax") Or _
                                     e.Column.FieldName.Equals("TotalPriceBeforeTax") Or _
                                                     e.Column.FieldName.Equals("BasePrice") Then

                                e.Appearance.ForeColor = Color.DarkGray
                            End If
                        End If

                        If articleGroup.IsHidddenArticles Then   ' Artikel verstecken; dann die ganzen Artikel ausblenden 
                            e.Appearance.ForeColor = Color.DarkGray

                        End If

                    End If
                End If
            End If

        End Sub

        ''' <summary>
        ''' stellt Funktionen zur verfügung, die Indicator-Zelle selber zu zeichnen
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Friend Overridable Sub CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grvItems.CustomDrawRowIndicator
            If e.Info.IsRowIndicator Then
                Dim grid As GridView = CType(sender, GridView)

                Dim jArticleItem As JournalArticleItem = CType(grid.GetRow(e.RowHandle), JournalArticleItem)
                If jArticleItem IsNot Nothing Then
                    Dim baseArticle As Article = jArticleItem.GetArticleItem
                    If baseArticle IsNot Nothing Then
                        If jArticleItem.SinglePriceBeforeTax < baseArticle.EinzelEK Then



                            e.Info.ImageIndex = -1
                            e.Painter.DrawObject(e.Info)
                            Dim r As Rectangle = e.Bounds
                            r.Inflate(-1, -1)


                            Dim x As Integer = CInt(r.X + (r.Width - m_warnImage.Width) / 2)
                            Dim y As Integer = CInt(r.Y + (r.Height - m_warnImage.Height) / 2)
                            e.Graphics.DrawImageUnscaled(m_warnImage, x, y)
                            e.Handled = True
                        End If
                    End If

                End If
            End If
        End Sub

        Private Sub btnConvertTextToArticle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertTextToArticle.Click
            AddFocusedItemToArticlesList()
        End Sub

        ''' <summary>
        ''' Fügt den focussierten Artikel zur Artikldatenbank hinzu, sofern der aktuellFocussierte artikel ein Text ist
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub AddFocusedItemToArticlesList()
            Using frm As New frmAddTextAsItem
                frm.SimpleArticle = GetFocusedArticle()

                frm.ShowDialog()

            End Using

        End Sub



        ''' <summary>
        ''' Wählt ein Kassenbuchkonto aus
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SelectCashAccount()
            If m_activeItem IsNot Nothing Then
                Dim selectedCashAccount As CashAccount = MainUI.ShowListCashAccounts(m_activeItem.CashAccount)
                If selectedCashAccount IsNot Nothing Then
                    m_activeItem.CashAccount = selectedCashAccount
                    btnCashAccount.Text = selectedCashAccount.ToString

                    MainApplication.getInstance.Settings.LastSelectedCashAccount = selectedCashAccount
                End If


            End If
        End Sub

        Private Sub repTaxValues_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles repTaxValues.EditValueChanged
            Debug.Print("TaxRate: " & CType(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue.ToString)

            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(grdItemsList.FocusedView, GridView)
            Dim item As JournalArticleItem = CType(view.GetFocusedRow, JournalArticleItem)

            If item IsNot Nothing Then
                item.TaxRate = CType(CType(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue, TaxRate)

                ' Bei Freitext die letzte Änderung übernehmen
                If item.IsText Then
                    MainApplication.getInstance.Settings.ItemsSettings.DefaultUnboundTaxRate = item.TaxRate
                End If
            End If


        End Sub

        Private Sub btnCashAccount_Properties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashAccount.Properties.Click
            SelectCashAccount()
        End Sub

        Private Sub txtDiscountName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountName.TextChanged
            If Not IsLoading Then
                If ActiveItem IsNot Nothing Then
                    ActiveItem.DiscountText = CStr(txtDiscountName.EditValue)
                End If
            End If
        End Sub

        Private Sub chkDiscountActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiscountActive.CheckedChanged

            txtDiscountName.Enabled = chkDiscountActive.Checked
            txtDiscountValue.Enabled = chkDiscountActive.Checked
            radDiscountType.Enabled = chkDiscountActive.Checked
            If ActiveItem IsNot Nothing Then
                ActiveItem.DiscountActive = chkDiscountActive.Checked
                FillPricesumField()
            End If
        End Sub

        Private Sub txtDiscountValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountValue.TextChanged
            If Not IsLoading Then
                If ActiveItem IsNot Nothing Then
                    Try

                        Dim discountValue As Decimal
                        If Decimal.TryParse(txtDiscountValue.Text, discountValue) Then
                            ActiveItem.DiscountValue = discountValue
                            FillPricesumField()
                        End If

                    Catch
                    End Try
                End If


            End If
        End Sub

        Private Sub radDiscountType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDiscountType.SelectedIndexChanged
            If Not IsLoading Then
                If ActiveItem IsNot Nothing Then
                    If radDiscountType.SelectedIndex = 0 Then ActiveItem.DiscountIsAbsolut = False
                    If radDiscountType.SelectedIndex = 1 Then ActiveItem.DiscountIsAbsolut = True
                    FillPricesumField()
                End If


            End If
        End Sub

        Private Sub txtDiscountName_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountName.Validated
            If ActiveItem IsNot Nothing Then
                Me.IsLoading = True
                ActiveItem.DiscountText = txtDiscountName.Text
                Me.IsLoading = False
            End If
        End Sub

        Private Sub ToolTipController1_GetActiveObjectInfo(ByVal sender As System.Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ttcGrid.GetActiveObjectInfo

            If Not e.SelectedControl Is grdItemsList Then Exit Sub

            Dim info As DevExpress.Utils.ToolTipControlInfo = e.Info

            Try
                Dim view As GridView = TryCast(grdItemsList.GetViewAt(e.ControlMousePosition), GridView)
                If (view Is Nothing) Then Return
                If Not view.Name = grvItems.Name Then Return
                Dim hi As ViewInfo.GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)

                If hi.HitTest = ViewInfo.GridHitTest.RowIndicator Then
                    If Not hi.InRow Then Exit Sub
                    Dim jArticleItem As JournalArticleItem = CType(view.GetRow(hi.RowHandle), JournalArticleItem)
                    If jArticleItem IsNot Nothing Then
                        Dim baseArticle As Article = jArticleItem.GetArticleItem
                        If baseArticle IsNot Nothing Then
                            If jArticleItem.SinglePriceBeforeTax < baseArticle.EinzelEK Then
                                info = New DevExpress.Utils.ToolTipControlInfo("", "Der Einkaufspreis ( " & baseArticle.EinzelEK.ToString("c") & " ) wurde unterschritten.")

                            End If
                        End If
                    End If


                    Exit Sub
                End If

            Catch
            Finally
                e.Info = info
            End Try

        End Sub



        Private Sub grvItems_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grvItems.DoubleClick
            ' Memo-Text aufrufen, wenn Doppelklick in RowPreview
            Dim mpos As System.Drawing.Point = grdItemsList.PointToClient(Control.MousePosition)

            Dim view As GridView = CType(sender, GridView)

            Dim hi As ViewInfo.GridHitInfo = view.CalcHitInfo(New Point(mpos.X, mpos.Y))
            If hi.HitTest = ViewInfo.GridHitTest.RowPreview Then
                SetItemsDescription(hi.RowHandle)
            End If


        End Sub

        Private Sub CheckButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckButton1.CheckedChanged
            ToggleTaxField()
        End Sub

        ''' <summary>
        ''' Sucht nach Vorhandensein dieses Gruppennamens. Gibt 'True' zurück, wenn ein gleichlautender Name in diesem Dokument gefunden wurde
        ''' </summary>
        ''' <param name="groupName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GroupNameExist(ByVal groupName As String) As Boolean
            For Each item As JournalArticleGroup In Me.ActiveItem.ArticleGroups
                If item.HeaderText.Equals(groupName, StringComparison.InvariantCultureIgnoreCase) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Private Sub btnCloneDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloneDocument.Click
            If Me.ActiveItem IsNot Nothing Then

                If Me.HasChanged Then
                    Dim result As DialogResult = AskChangedData()
                    If result = DialogResult.Cancel Then Exit Sub
                    If result = DialogResult.Yes Then Me.Save()

                End If


                Dim newDocument As JournalDocument = CType(Me.ActiveItem.Clone, JournalDocument)
                MainUI.OpenElementWindow(newDocument, True) ' ein neues Fenster erzwingen

            End If

        End Sub

        Private Sub btnAddAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAddress.Click
            Using frm As New frmEasyAddAddress
                If frm.ShowDialog() = DialogResult.OK Then
                    ' neue Adresse wurde hinzugefügt / Hole diese mal ab, damit die Nr übergeben werden kann
                    If frm.Address IsNot Nothing Then
                        Me.ActiveAddress = frm.Address
                    End If
                End If

            End Using

        End Sub

        ''' <summary>
        ''' Versucht die neue Artikelgruppe im übergeordneten Grid anzuzeigen
        ''' </summary>
        ''' <param name="newArticleGroup"></param>
        ''' <remarks></remarks>
        Private Sub MakeGroupVisible(ByVal newArticleGroup As JournalArticleGroup)
            Try
                grvPositions.CollapseAllDetails()

                For n As Integer = 0 To grvPositions.RowCount - 1
                    Dim item As JournalArticleGroup = CType(grvPositions.GetRow(n), JournalArticleGroup)
                    If item Is newArticleGroup Then
                        grvPositions.MakeRowVisible(n, False)
                        grvPositions.SelectRow(n)
                        grvPositions.FocusedRowHandle = n
                        Exit For
                    End If
                Next

            Catch ex As Exception
                MainApplication.getInstance.log.WriteLog(ex, "Bills", "Error in 'MakeGroupVisible'")
            End Try

        End Sub

        Private Sub radPaimentDate_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPaimentDate.SelectedIndexChanged
            Dim value As Integer = CInt(radPaimentDate.EditValue) ' CInt(radPaimentDate.Properties.Items(radPaimentDate.SelectedIndex).Value)

            If m_TargetDateChanging Then Exit Sub

            If value > 0 Then
                txtTargetPaymentDays.EditValue = value

                If ActiveItem IsNot Nothing Then
                    If Not IsLoading Then
                        ActiveItem.PaymentTarget = TargetPayDate

                    End If

                End If
            Else
                txtTargetPaymentDays.EditValue = 0I
            End If

        End Sub

        Private Sub datDocumentVisibleDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles datDocumentVisibleDate.EditValueChanged

            If ActiveItem IsNot Nothing Then
                Me.ActiveItem.DocumentDate = datDocumentVisibleDate.DateTime
            End If

        End Sub

        Private Sub splBillsFooterPane_SplitGroupPanelCollapsed(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.SplitGroupPanelCollapsedEventArgs) Handles splBillsFooterPane.SplitGroupPanelCollapsed
            MainApplication.getInstance.Settings.SetSetting(splBillsFooterPane.Name & "_Collapsed", "Bills", e.Collapsed.ToString)

        End Sub

        Private Sub splBillsFooterPane_SplitterMoved(ByVal sender As Object, ByVal e As System.EventArgs) Handles splBillsFooterPane.SplitterMoved
            MainApplication.getInstance.Settings.SetSetting(splBillsFooterPane.Name & "_pos", "Bills", splBillsFooterPane.SplitterPosition.ToString)

        End Sub

        Private Sub repItemsShortTextB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles repItemsShortTextB.KeyDown
            If e.KeyCode = Keys.F2 Then
                CreateNewItem()
            End If
        End Sub

        Private Sub chkShowWithoutTax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowWithoutTax.CheckedChanged
            If ActiveItem IsNot Nothing Then
                ActiveItem.ShowWithoutTax = Not chkShowWithoutTax.Checked
                grdItemsList.RefreshDataSource()
            End If
        End Sub


        Private Sub grvItems_ColumnPositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvItems.ColumnPositionChanged
            Dim col As DevExpress.XtraGrid.Columns.GridColumn = CType(sender, Columns.GridColumn)


            SaveGridStyles(col.View, "ItemsView")

        End Sub

        Private Sub grvItems_ColumnWidthChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles grvItems.ColumnWidthChanged
            SaveGridStyles(e.Column.View, "ItemsView")

        End Sub

        Private Sub grvPositions_ColumnWidthChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles grvPositions.ColumnWidthChanged
            SaveGridStyles(e.Column.View, "GroupsView")
        End Sub

        Private Sub repUnitCombo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles repUnitCombo.Validating

            ' Prüft freie Texteingabe un sucht eine einheit dazu. 
            ' Konnte keine einheit gefunden werden; wird eine angelegt

            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(grdItemsList.FocusedView, GridView)
            Dim item As JournalArticleItem = CType(view.GetFocusedRow, JournalArticleItem)

            Dim cbo As DevExpress.XtraEditors.ComboBoxEdit = CType(sender, DevExpress.XtraEditors.ComboBoxEdit)

            If TypeOf cbo.SelectedItem Is String Then
                item.ItemUnit = Units.FindUnit(CStr(cbo.EditValue), True)
                'dieser Auflistung hinzufügen; da neu
                repUnitCombo.Items.Add(item.ItemUnit)
                Exit Sub
            End If

            If TypeOf cbo.SelectedItem Is Unit Then
                item.ItemUnit = CType(cbo.SelectedItem, Unit)
                Exit Sub
            End If
        End Sub

        Private Sub Text_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtHeadText.DragEnter, txtFooterText.DragEnter, txtDescription.DragEnter, txtAdresswindow.DragEnter
            DragDropHelper.CheckForText(sender, e)

        End Sub

        Private Sub Text_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtHeadText.DragDrop, txtFooterText.DragDrop, txtDescription.DragDrop, txtAdresswindow.DragDrop
            DragDropHelper.SetText(sender, e)
        End Sub

        Private Sub txtHeadText_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtHeadText.KeyDown, txtFooterText.KeyDown

            Dim textbox As DevExpress.XtraEditors.MemoExEdit = CType(sender, DevExpress.XtraEditors.MemoExEdit)


            If e.KeyCode = Keys.Delete Then
                textbox.Text = String.Empty
            End If
        End Sub


        Private Sub mnuResetItemsGroupPrice_Click(sender As System.Object, e As System.EventArgs) Handles mnuResetItemsGroupPrice.Click
            ResetSelectedItemsGroupPrice()
        End Sub

        ''' <summary>
        ''' Definiert den Namen der aktuellen Artikelgruppe als Standard
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetCurrentGroupNameAsDefaultGroupName()
            Dim item As JournalArticleGroup = TryCast(grvPositions.GetFocusedRow, JournalArticleGroup)
            If item IsNot Nothing Then
                Dim CurrentName As String
                CurrentName = item.HeaderText
                MainApplication.getInstance.Settings.ItemsSettings.DefaultItemsGroupHeadline = CurrentName
            End If
        End Sub

        Private Sub mnuSetCurrentGroupNameAsDefaultName_Click(sender As System.Object, e As System.EventArgs) Handles mnuSetCurrentGroupNameAsDefaultName.Click
            SetCurrentGroupNameAsDefaultGroupName()
        End Sub

    End Class
End Namespace