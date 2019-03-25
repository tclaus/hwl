Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports ClausSoftware
Imports ClausSoftware.Kernel
Imports ClausSoftware.Data

''' <summary>
''' Stellt ein allgemeines Grid zur Verfügung, das verschiedenen Aufganben und Daten enthalten kann
''' </summary>
''' <remarks></remarks>
Public Class uicCommonGrid

    ''' <summary>
    ''' Stellt eine Auflistung an weiteren Menüelementen bereit; Diese werden unter "Neu..." eingeblendet
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SubMenue As New List(Of CustomMenuItem)

    ''' <summary>
    ''' wird ausgelöst, wenn die Daten in diesem Grid sich ändern, gelöscht oder hinzugefügt werden
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event RowChangedData(ByVal sender As Object, ByVal e As EventArgs)


    ''' <summary>
    ''' Signalisiert das Click-Ereignis auf ein Menüelement
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event MenuItemClicked(ByVal Sender As Object, ByVal e As MenuItemClickedEventArgs)

    ''' <summary>
    ''' Wird ausgelöst um zu signalisieren, das sich der Filter des Grids geändert hat, dieser schränkt die Datenquelle weiter ein
    ''' </summary>
    ''' <param name="criteria">Der Kriterienausdruck</param>
    ''' <remarks></remarks>
    <Description("wird ausgelöst, wenn sich der Filter des Grids geändert hat")> _
    Public Event CustomFilterChanged(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator)

    ''' <summary>
    ''' Wird ausgelöst, bevor ein Element eines Bestimmten Types angelegt wird
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event BeforeCreateNewItem(ByVal sender As Object, ByVal e As CreateItemArgs)
    Public Event AfterCreateNewItem(ByVal sender As Object, ByVal e As StaticItemEventArgs)

    ''' <summary>
    ''' Wird aufgerufen, nachdem ein Datenbankelement gelöscht wurde. 
    ''' Bei Massenlöschungen wird für jedes Element ein Event gefeuert.
    ''' </summary>
    ''' <param name="Sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event AfterDeleteItem(Sender As Object, e As StaticItemEventArgs)


    Dim m_baseCollection As BaseCollection(Of StaticItem)

    Dim m_serverModeDS As XPServerCollectionSource
    ''' <summary>
    ''' Enthält den Basistype der aktuellen Auflistung
    ''' </summary>
    ''' <remarks></remarks>
    Dim m_actualBaseCollection As BaseCollection
    Dim m_focusedItem As StaticItem

    ''' <summary>
    ''' enthält den Type der Datenquelle. Dieser Typ wird im Grid angezeigt
    ''' </summary>
    ''' <remarks></remarks>
    Private m_dataSourceType As DataSourceList
    Private m_currentContext As String



    Private m_context As String
    ''' <summary>
    ''' Ruft den Kontext des Grids ab oder legt diesen fest. 
    ''' </summary>
    ''' <value></value>
    ''' <returns>Kontext wird benötigt für die eindeutige Identifizirung des Grids</returns>
    ''' <remarks></remarks>
    <Description("Kontext wird benötigt für die eindeutige Identifizirung des Grids")> _
    <DisplayName("Context")> _
    Public Property Context() As String
        Get
            Return m_context
        End Get
        Set(ByVal value As String)
            m_context = value
        End Set
    End Property


    ''' <summary>
    ''' Schaltet die Funktion "Neue Zeile" ein oder aus
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property AllowNewRow As DevExpress.XtraGrid.Views.Grid.NewItemRowPosition
        Get
            Return grvCommonGrid.OptionsView.NewItemRowPosition
        End Get
        Set(ByVal value As DevExpress.XtraGrid.Views.Grid.NewItemRowPosition)
            grvCommonGrid.OptionsView.NewItemRowPosition = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft die Serververbindung ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ServerCollectionSource() As XPServerCollectionSource
        Get
            Return m_serverModeDS
        End Get
    End Property

    Public Sub Initialize()
        InitializeApplication()
    End Sub

    ''' <summary>
    ''' Ruft einen gemeinsamen Filterkriterium ab, das sich aus dem festen Filter und dem Filter des Grids zusammensetzt
    ''' </summary>
    ''' <param name="criteria">Zusätzliche Bedingung, die mit dem FixedFilter zusammengeführt werden soll</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAssebledFilterString(ByVal criteria As String) As String
        Dim fixedFilter As String
        If CType(grvCommonGrid.DataSource, DevExpress.Xpo.XPBaseCollection).Criteria IsNot Nothing Then
            fixedFilter = CType(grvCommonGrid.DataSource, DevExpress.Xpo.XPBaseCollection).Criteria.ToString

            If Not criteria.Equals(fixedFilter) Then
                criteria &= " AND " & fixedFilter
            End If
            If criteria.StartsWith(" AND ") Then
                criteria = criteria.Substring(5)
            End If

        End If

        Return criteria

    End Function

    ''' <summary>
    ''' ruft den Titel des Grids ab, damit kann zb eine Überschrift in Ausdrucken festgelegt werden
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTitleText(ByVal ds As DataSourceList) As String
        Return MainApplication.getInstance.Languages.GetTextBydataKind(ds)
    End Function

    ''' <summary>
    ''' Aktualisiert das Grid, indem der Cache neu eingelesen wird
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshData()
        Try
            If m_serverModeDS IsNot Nothing Then
                'MainApplication.getInstance.Session.DropIdentityMap()   ' Böse !
                m_serverModeDS.Reload()
            Else
                ' CType(grvCommonGrid.DataSource, BaseCollection(Of ClausSoftware.Data.StaticItem)).Reload()

                If TypeOf grvCommonGrid.DataSource Is Kernel.Transactions Then
                    CType(grvCommonGrid.DataSource, Kernel.Transactions).Reload()
                End If

                If TypeOf grvCommonGrid.DataSource Is Kernel.CashJournalItems Then
                    CType(grvCommonGrid.DataSource, Kernel.CashJournalItems).Reload()
                End If

                If TypeOf grvCommonGrid.DataSource Is Kernel.FixedCosts Then
                    CType(grvCommonGrid.DataSource, Kernel.FixedCosts).Reload()
                End If

            End If

            grvCommonGrid.RefreshData()

        Catch ex As Exception

            Debug.Print(ex.Message)

        End Try
    End Sub

    ''' <summary>
    ''' Markiert einen Eintrag in dem Grid (ohne es zu selektieren) anhand der eindeutigen ID
    ''' Kann der Eintrag in der LIste nicht gefunden werden, passiert nichts
    ''' </summary>
    ''' <param name="replikID"></param>
    ''' <remarks></remarks>
    Public Sub SelectItemByID(ByVal replikID As String)
        Dim Handle As Integer
        For Handle = 0 To grvCommonGrid.RowCount - 1
            Dim data As ClausSoftware.Data.IStaticItemData = CType(grvCommonGrid.GetRow(Handle), ClausSoftware.Data.IStaticItemData)
            If data IsNot Nothing Then
                If data.ReplikID.Equals(replikID, StringComparison.InvariantCultureIgnoreCase) Then
                    Debug.Print("Selektiere Row")
                    grvCommonGrid.SelectRow(Handle)
                    grvCommonGrid.FocusedRowHandle = Handle
                    Exit Sub
                End If
            End If
        Next
        Debug.Print("Keine Zeile zum markieren gefunden")
    End Sub

    ''' <summary>
    ''' Markiert einen Eintrag in dem Grid (ohne es zu selektieren) anhand der eindeutigen ID
    ''' Kann der Eintrag in der LIste nicht gefunden werden, passiert nichts
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Public Sub SelectItemByID(ByVal id As Integer)
        Dim Handle As Integer

        'grvCommonGrid.ClearSelection()

        For Handle = 0 To grvCommonGrid.RowCount - 1
            Dim data As ClausSoftware.Data.IStaticItemData = CType(grvCommonGrid.GetRow(Handle), ClausSoftware.Data.IStaticItemData)
            If data IsNot Nothing Then
                If data.ID = id Then
                    Debug.Print("Selektiere Row")

                    If Not grvCommonGrid.IsRowSelected(Handle) Then grvCommonGrid.SelectRow(Handle)
                    grvCommonGrid.FocusedRowHandle = Handle

                    Exit Sub
                End If
            End If
        Next
        Debug.Print("Keine Zeile zum Markieren gefunden")
    End Sub

    Public Sub SetFontSize(ByVal size As Integer)
        Dim newfont As New Font(grdCommonGrid.Font.FontFamily, size, grdCommonGrid.Font.Style)
        grdCommonGrid.Font = newfont
    End Sub


    Private Sub GridView1_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvCommonGrid.ColumnFilterChanged

        RaiseEvent CustomFilterChanged(grvCommonGrid.ActiveFilterString)
        SaveGridStyle()

    End Sub

    ''' <summary>
    ''' Ruft den aktuellen Filter ab, der auf dem Grid liegt
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ActiveFilterString() As String
        Get
            Return grvCommonGrid.ActiveFilterString
        End Get
    End Property


    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvCommonGrid.FocusedRowChanged
        Dim o As Object = grvCommonGrid.GetRow(e.FocusedRowHandle)

        If o IsNot Nothing Then
            m_focusedItem = CType(o, ClausSoftware.Data.StaticItem)

            RaiseEvent FocusedRowChanged(m_focusedItem.Key)
        End If
    End Sub

    ''' <summary>
    ''' die Dialoge des Grids Topmost anzeigen lassen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub GridView1_ShowcustomForm(ByVal sender As Object, ByVal e As EventArgs) Handles grvCommonGrid.ShowCustomizationForm
        grvCommonGrid.CustomizationForm.TopMost = True

    End Sub


    ''' <summary>
    ''' Ruft eine Auflistung aller gerade sichtbaren Zeilen ab. Bei Auflistungen, die sehr viele Elemente haben, kann dies etwas dauern
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRows() As List(Of Data.StaticItem)
        Dim tmpList As New List(Of Data.StaticItem)
        For n As Integer = 0 To grvCommonGrid.RowCount - 1
            tmpList.Add(CType(grvCommonGrid.GetRow(n), StaticItem))
        Next
        Return tmpList
    End Function

    ''' <summary>
    ''' Setzt die Datenquelle, die im Grid angezeigt werden soll.
    ''' </summary>
    ''' <param name="datasource">Typ der internen Datenquelle</param>
    ''' <remarks>wurde bisher der <see cref="Context">Context</see> nicht gesetzt, so wird anhand der Datenquelle der Kontext festgelegt</remarks>
    Public Sub SetDataSource(ByVal datasource As DataSourceList)

        If String.IsNullOrEmpty(Me.Context) Then
            Me.Context = datasource.ToString
        End If

        Dim formatter As IGridFormatter = Nothing

        m_serverModeDS = Nothing

        ' Alle nicht-server Objekte müssen in der Refresh-Methode aufgenommen werden !

        Select Case datasource
            Case DataSourceList.Addressbook

                m_serverModeDS = New XPServerCollectionSource(MainApplication.getInstance.Session, MainApplication.getInstance.Adressen.GetObjectClassInfo)
                m_serverModeDS.DisplayableProperties = MainApplication.getInstance.Adressen.DisplayableProperties
                m_dataSourceType = datasource


            Case DataSourceList.Journal
                m_serverModeDS = New XPServerCollectionSource(MainApplication.getInstance.Session, MainApplication.getInstance.JournalDocuments.GetObjectClassInfo)
                m_serverModeDS.DisplayableProperties = MainApplication.getInstance.JournalDocuments.DisplayableProperties
                m_dataSourceType = datasource
                If TypeOf MainApplication.getInstance.JournalDocuments Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.JournalDocuments, IGridFormatter)
                End If

            Case DataSourceList.Articles
                m_serverModeDS = New XPServerCollectionSource(MainApplication.getInstance.Session, MainApplication.getInstance.ArticleList.GetObjectClassInfo)
                m_serverModeDS.DisplayableProperties = MainApplication.getInstance.ArticleList.DisplayableProperties
                m_dataSourceType = datasource

                If Not MainApplication.getInstance.Settings.Articlesettings.ShowInactiveItems Then  ' Inaktive Artikel in Listen nicht mehr anzeigen lassen , falls ausgeschaltet werfden diese Artikel grau dargestellt
                    m_serverModeDS.FixedFilterString = "IsActive=" & True
                End If


                If TypeOf MainApplication.getInstance.ArticleList Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.ArticleList, IGridFormatter)
                End If

            Case DataSourceList.CashJournalMonthy
                If TypeOf MainApplication.getInstance.CashJournal Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.CashJournal, IGridFormatter)
                    SetGridFormatType(formatter)

                End If

                MainApplication.getInstance.CashJournal.Reload()
                grdCommonGrid.DataSource = MainApplication.getInstance.CashJournal
                m_dataSourceType = DataSourceList.CashJournalMonthy

            Case DataSourceList.Transactions
                If TypeOf MainApplication.getInstance.Transactions Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.Transactions, IGridFormatter)
                    SetGridFormatType(formatter)

                End If

                MainApplication.getInstance.Transactions.Reload()
                grdCommonGrid.DataSource = MainApplication.getInstance.Transactions
                m_dataSourceType = DataSourceList.Transactions

            Case DataSourceList.Tasks
                m_serverModeDS = New XPServerCollectionSource(MainApplication.getInstance.Session, MainApplication.getInstance.Tasks.GetObjectClassInfo)
                m_serverModeDS.DisplayableProperties = MainApplication.getInstance.Tasks.DisplayableProperties
                m_dataSourceType = datasource
                If TypeOf MainApplication.getInstance.Tasks Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.Transactions, IGridFormatter)
                End If

            Case DataSourceList.Units
                ' Kein servermodus !
                If TypeOf MainApplication.getInstance.Units Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.Units, IGridFormatter)
                End If
                grdCommonGrid.DataSource = MainApplication.getInstance.Units
                m_dataSourceType = DataSourceList.Units

            Case DataSourceList.Discounts
                ' Kein servermodus !
                If TypeOf MainApplication.getInstance.Discounts Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.Discounts, IGridFormatter)
                End If

                grdCommonGrid.DataSource = MainApplication.getInstance.Discounts
                m_dataSourceType = DataSourceList.Discounts

            Case DataSourceList.LoanAccounts
                ' Kein servermodus !
                If TypeOf MainApplication.getInstance.LoanAccounts Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.LoanAccounts, IGridFormatter)
                End If

                grdCommonGrid.DataSource = MainApplication.getInstance.LoanAccounts
                m_dataSourceType = DataSourceList.LoanAccounts


                'Benutzerlisten 
            Case DataSourceList.users
                If TypeOf MainApplication.getInstance.Users Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.Users, IGridFormatter)
                    SetGridFormatType(formatter)

                End If

                grdCommonGrid.DataSource = MainApplication.getInstance.Users
                m_dataSourceType = DataSourceList.users


            Case DataSourceList.HistoryCategories


                grdCommonGrid.DataSource = MainApplication.getInstance.HistoryCategories
                m_dataSourceType = DataSourceList.HistoryCategories


            Case DataSourceList.FixedCosts
                If TypeOf MainApplication.getInstance.FixedCosts Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.FixedCosts, IGridFormatter)
                End If

                grdCommonGrid.DataSource = MainApplication.getInstance.FixedCosts
                m_dataSourceType = DataSourceList.FixedCosts

            Case DataSourceList.FixedCostGroup
                If TypeOf MainApplication.getInstance.FixedCostGroups Is IGridFormatter Then
                    formatter = CType(MainApplication.getInstance.FixedCostGroups, IGridFormatter)
                End If

                grdCommonGrid.DataSource = MainApplication.getInstance.FixedCostGroups
                m_dataSourceType = DataSourceList.FixedCostGroup

        End Select

        ' wurde kein Server-Mode gesetzt, dann noch schnell das Grid formatieren und dann raus hier
        If m_serverModeDS Is Nothing Then
            SetGridFormatType(formatter)

            If grvCommonGrid.Columns.ColumnByFieldName("MoneyFlow") IsNot Nothing Then
                m_imageDirectionList.Images.Clear()
                m_imageDirectionList.Images.Add(My.Resources.arrow2_down_left_green) '0 = eingehend
                m_imageDirectionList.Images.Add(My.Resources.arrow2_up_right_red) ' 1= ausgehend

                repImageCombo.Items.Clear()
                repImageCombo.SmallImages = m_imageDirectionList
                Dim item As New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Forderung", MoneyFlow.IsReceiveable, 0) 'TODO: NLS

                repImageCombo.Items.Add(item)

                item = New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Verbindlichkeit", MoneyFlow.IsPayable, 1) ' TODO:NLS

                repImageCombo.Items.Add(item) ' Zwei elemente hinzufügen
                repImageCombo.ReadOnly = True


                grvCommonGrid.Columns.ColumnByFieldName("MoneyFlow").ColumnEdit = repImageCombo

            End If

            Exit Sub

        End If

        ' Nun das Grid für den Server-Mode vorbereiten, dann Formatieren

        grdCommonGrid.DataSource = Nothing

        grdCommonGrid.DataSource = m_serverModeDS


        SetGridFormatType(formatter)


        Dim listOfProps As New List(Of String)

        ' Properties, die nicht Persistent sind, können im Servermode nicht sortiert werden
        ' TODO: Dies muss in der Datenquelle gemacht werden
        For Each prop As Metadata.ReflectionPropertyInfo In m_serverModeDS.ObjectClassInfo.PersistentProperties
            listOfProps.Add(prop.Name)
        Next

        For Each col As GridColumn In grvCommonGrid.Columns
            If Not listOfProps.Contains(col.FieldName) Then
                col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                col.OptionsFilter.AllowFilter = False
                col.OptionsFilter.AllowAutoFilter = False
            End If

        Next



    End Sub

    ''' <summary>
    ''' Setzt Spaltenformatierung des Grids
    ''' </summary>
    ''' <param name="formatter"></param>
    ''' <remarks></remarks>
    Private Sub SetGridFormatType(ByVal formatter As IGridFormatter)
        If formatter IsNot Nothing Then
            For Each col As GridColumn In grvCommonGrid.Columns

                If formatter.GetFormatString(col.FieldName) <> "" Then
                    If col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None Then

                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        col.DisplayFormat.FormatString = formatter.GetFormatString(col.FieldName)

                        col.SortMode = ColumnSortMode.Value
                    End If
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Zeigt einen Drucken-Dialog
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowPrintPreview()
        Try
            Dim GridPrinting As SimpleGridPrinting = SimpleGridPrinting.GetSimpleGridPrinting
            GridPrinting.GridToPrint = grdCommonGrid
            GridPrinting.Headline = GetTitleText(m_dataSourceType)
            GridPrinting.ShowPreviewDialog()

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Listendruck", "Fehler beim erstellen der Druck-Vorschau")
        End Try

    End Sub

    ''' <summary>
    ''' Ruft den Schlüssel des gearde gewälten Elements ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FocusedRowKey() As String
        Get
            Return m_focusedItem.Key
        End Get
    End Property

    ''' <summary>
    ''' Ruft die ID der aktuell ausgewählten Spalte ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FocusedRowID() As Integer
        Get
            Return m_focusedItem.ID
        End Get
    End Property

    ''' <summary>
    ''' Ruft das eigentliche Element ab, das gerade markiert ist
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FocussedItem() As StaticItem
        Get
            Return m_focusedItem
        End Get
    End Property

    ''' <summary>
    ''' Speichert den kompletten Datensatz ab, (nur Usints un Discounts)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()

        Select Case m_dataSourceType

            Case DataSourceList.Units
                MainApplication.getInstance.Units.Save()

            Case DataSourceList.Discounts
                MainApplication.getInstance.Discounts.Save()


            Case Else

        End Select
    End Sub


    ''' <summary>
    ''' Wird ausgelöst, wenn die selektierte Zeile gewechselt wird
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Wird ausgelöst, wenn im grid die focussierte Zeile gewechselt wird")> _
    Public Event FocusedRowChanged(ByVal itemKey As String)

    <Description("Wird ausgelöst, wenn auf eine Zeile ein doppelklick ausgelöst wird")> _
    Public Event ItemRowDoubleClick(ByVal itemKey As String)

    ''' <summary>
    ''' Speichert das Grid mit allen Eigenschaften ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveGridStyle()
        Me.SaveGridStyle(Me.Context)
    End Sub

    ''' <summary>
    ''' Speichert das Grid in dem angegebnen Kontext ab
    ''' </summary>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Private Sub SaveGridStyle(ByVal context As String)
        Debug.Assert(Not String.IsNullOrEmpty(context), "Context des Grids darf nicht leer sein!")
        If m_styleLoading Then Exit Sub
        SaveGridStyles(grdCommonGrid, context)
    End Sub
    ''' <summary>
    ''' Läd die Einstellungen des Grids mit allen Einstellungen 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadGridStyle()
        LoadGridStyle(Me.Context)
    End Sub

    ''' <summary>
    ''' Ist True, wenn das GridStyle gerade eingeladen wird
    ''' </summary>
    ''' <remarks></remarks>
    Private m_styleLoading As Boolean

    ''' <summary>
    ''' Läd die Einstellungen des Grids mit allen Einstellungen im angegebenen Kontext
    ''' </summary>
    Private Sub LoadGridStyle(ByVal context As String)


        Debug.Assert(Not String.IsNullOrEmpty(context), "Context des Grids darf nicht leer sein!")
        m_styleLoading = True
        RestoreGridStyles(grdCommonGrid, context)
        m_styleLoading = False
    End Sub


    ''' <summary>
    ''' Löscht alle markierten Zeilen im Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteSelected()
        'TODO: NLS
        If MessageBox.Show("Möchten Sie die markierten Einträge löschen?", "Gewählte Einträge löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            DeleteSelectedRows(grvCommonGrid)

        End If
    End Sub

    ''' <summary>
    ''' Ruft alle derzeit selektiertren Elemente des Grids ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSelectedItems() As ClausSoftware.Data.StaticItem()
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView

        view = CType(grdCommonGrid.FocusedView, GridView)

        Dim dataItems() As ClausSoftware.Data.StaticItem
        Dim I As Integer

        ReDim dataItems(view.SelectedRowsCount - 1)
        For I = 0 To view.SelectedRowsCount - 1
            dataItems(I) = CType(view.GetRow(view.GetSelectedRows(I)), ClausSoftware.Data.StaticItem)
        Next

        Return dataItems

    End Function

    ''' <summary>
    ''' Löscht alle markierten Elemente eines Grids.
    ''' </summary>
    ''' <param name="View"></param>
    ''' <remarks></remarks>
    Private Sub DeleteSelectedRows(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView)

        Dim dataItems() As ClausSoftware.Data.StaticItem
        Dim I As Integer

        ReDim dataItems(view.SelectedRowsCount - 1)
        For I = 0 To view.SelectedRowsCount - 1
            dataItems(I) = CType(view.GetRow(view.GetSelectedRows(I)), ClausSoftware.Data.StaticItem)
        Next

        view.BeginSort()
        view.BeginUpdate()
        Try

            OnDeleteSelectedItems(dataItems)


            If m_serverModeDS IsNot Nothing Then ' Nicht alle Datenlisten sind Server-Mode Listen
                m_serverModeDS.Reload()
            End If

            view.RefreshData()

            RaiseEvent RowChangedData(Me, EventArgs.Empty)

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ClausSoftware.Tools.LogSeverity.Warning, "Can't delete this dataitem from GridMenü: " & ex.Message)
            MessageBox.Show(GetText("msgUnresolvedContraintsInDataItemCantDelete", "Kann Datensatz nicht löschen, es liegen eventuell noch Verweise vor."), GetText("msgDeleteRejected", "Löschen nicht möglich."), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally


            view.EndUpdate()
            view.EndSort()
            view.RefreshData()
        End Try
    End Sub

    ''' <summary>
    ''' Fürt das Löschen der Element aus der Datenliste aus
    ''' </summary>
    ''' <param name="dataItems"></param>
    ''' <remarks></remarks>
    Public Overridable Sub OnDeleteSelectedItems(ByVal dataItems() As ClausSoftware.Data.StaticItem)
        For Each dataItem As ClausSoftware.Data.StaticItem In dataItems

            dataItem.Delete()
            Try

                RaiseEvent AfterDeleteItem(Me, New StaticItemEventArgs(dataItem))

            Catch ex As Exception
                MainApplication.getInstance.log.WriteLog(ex, "Fehler in der Ereinisbehandlung des Löschens von Elementen", "AfterDeleteItem - Fehler")
            End Try


        Next

    End Sub

    ''' <summary>
    ''' Löst aus, wenn eine Zeile doppelt geklickt wurde
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RowDoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles grvCommonGrid.DoubleClick
        Dim view As GridView = CType(sender, GridView)


        Dim hi As ViewInfo.GridHitInfo = view.CalcHitInfo(grdCommonGrid.PointToClient(MousePosition))
        If hi.RowHandle < 0 Then Exit Sub

        If (hi.InRow) Then
            Dim StaticItem As ClausSoftware.Data.StaticItem = CType(grvCommonGrid.GetRow(hi.RowHandle), ClausSoftware.Data.StaticItem)

            StaticItem.Reload()

            m_focusedItem = StaticItem
            RaiseEvent ItemRowDoubleClick(StaticItem.Key)
        End If

    End Sub



    ''' <summary>
    ''' Ruft einen direkten Kriterien-String ab oder setzt diesen. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetCriteriaString(ByVal criteriaValue As DevExpress.Data.Filtering.CriteriaOperator)
        If m_serverModeDS IsNot Nothing Then
            m_serverModeDS.FixedFilterCriteria = criteriaValue
            m_serverModeDS.Reload()
        Else
            ' Filter auf das standard Datenobjekt anwenden 
            CType(grvCommonGrid.DataSource, XPBaseCollection).Criteria = criteriaValue
            'Select Case m_dataSourceType
            '    Case DataSourceList.Addressbook
            '        MainApplication.getInstance.Adressen.Filter = value
            '    Case DataSourceList.CashJournal
            '        MainApplication.getInstance.CashJournal.Filter = value
            '    Case Else
            '        Throw New NotImplementedException("Das setzen von Filtern ist noch nicht implementiert für den Typ: " & m_dataSourceType.ToString)

            'End Select
            RaiseEvent CustomFilterChanged(criteriaValue)
        End If

    End Sub

    'uicCommonGrid.CriteriaString = "Datum BETWEEN " & DateControl.GetStartDate & " AND " & DateControl.GetEndDate  'DateControl.GetStartDate, DateControl.GetEndDate

    ''' <summary>
    ''' Zeigt die Filterzeile im Grid an
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowFilterRow() As Boolean
        Get
            Return grvCommonGrid.OptionsView.ShowAutoFilterRow
        End Get
        Set(ByVal value As Boolean)
            grvCommonGrid.OptionsView.ShowAutoFilterRow = value
        End Set
    End Property

    Public Sub SearchParameter(ByVal searchText As String)
        Try
            Debug.Print("Suchtext: " & searchText)
            If String.IsNullOrEmpty(searchText) Then
                m_serverModeDS.FixedFilterString = ""
            Else
                If m_dataSourceType = DataSourceList.Addressbook Then

                    Dim searchValue As String = "%" & searchText & "%"

                    Dim cc As New DevExpress.Data.Filtering.CriteriaOperatorCollection
                    Dim cr As DevExpress.Data.Filtering.BinaryOperator = New DevExpress.Data.Filtering.BinaryOperator("Company", searchValue, DevExpress.Data.Filtering.BinaryOperatorType.Like)
                    cc.Add(cr)

                    cr = New DevExpress.Data.Filtering.BinaryOperator("ContactsName", searchValue, DevExpress.Data.Filtering.BinaryOperatorType.Like)
                    cc.Add(cr)

                    cr = New DevExpress.Data.Filtering.BinaryOperator("ContactDisplayID", searchValue, DevExpress.Data.Filtering.BinaryOperatorType.Like)
                    cc.Add(cr)

                    Dim cd As New DevExpress.Data.Filtering.GroupOperator(DevExpress.Data.Filtering.GroupOperatorType.Or, cc)


                    m_serverModeDS.FixedFilterCriteria = cd
                    ' m_serverModeDS.FixedFilterString = "([Company] LIKE '%" & searchText & "%' OR [ContactsName] LIKE '%" & searchText & "%' or [ContactDisplayID] like '%" & searchText & "%')"

                End If
            End If



            m_serverModeDS.Reload()

        Catch
        End Try


    End Sub

    Private HotTrackRowValue As Integer = GridControl.InvalidRowHandle

    Private Property HotTrackRow() As Integer
        Get
            Return HotTrackRowValue
        End Get
        Set(ByVal Value As Integer)
            If HotTrackRowValue <> Value Then
                Dim PrevHotTrackRow As Integer
                PrevHotTrackRow = HotTrackRowValue
                HotTrackRowValue = Value

                grvCommonGrid.RefreshRow(PrevHotTrackRow)
                grvCommonGrid.RefreshRow(HotTrackRowValue)


            End If
        End Set
    End Property

    Private Sub grvComonGrid_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles grvCommonGrid.RowCellStyle
        If e.RowHandle = HotTrackRow Then
            e.Appearance.BackColor = Color.PaleGoldenrod
        End If

        Dim activeItem As IHasActiveProperty = TryCast(CType(sender, GridView).GetRow(e.RowHandle), IHasActiveProperty)

        If activeItem IsNot Nothing Then
            If Not activeItem.IsActive Then
                e.Appearance.ForeColor = Color.Gray
            End If
        End If


    End Sub

    Private Sub GridView1_MouseMove(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles grvCommonGrid.MouseMove
        Dim View As GridView = CType(sender, GridView)
        With View.CalcHitInfo(New Point(e.X, e.Y))
            If .InRowCell Then
                HotTrackRow = .RowHandle
            Else
                HotTrackRow = GridControl.InvalidRowHandle
            End If
        End With
    End Sub



    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        DeleteSelected()
    End Sub

    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
        CreateNew()
    End Sub


    ''' <summary>
    ''' Erstellt einen neuen Eintrag des aktuellen Types
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function CreateNew() As StaticItem

        Dim newID As Integer = -1
        Dim newItem As StaticItem

        Dim ItemArg As New CreateItemArgs()
        ItemArg.DataItemType = m_dataSourceType

        RaiseEvent BeforeCreateNewItem(Me, ItemArg)
        If ItemArg.Cancel Then Return Nothing


        Select Case m_dataSourceType
            Case DataSourceList.Addressbook

                newItem = MainApplication.getInstance.Adressen.GetNewItem()
                'MainApplication.getInstance.Adressen.Add(CType(newItem, Adress))

                newID = newItem.ID

            Case DataSourceList.Tasks

                newItem = MainApplication.getInstance.Tasks.GetNewItem()
                MainApplication.getInstance.Tasks.Add(CType(newItem, Task))

                newID = newItem.ID

            Case DataSourceList.CashJournalMonthy
                newItem = MainApplication.getInstance.CashJournal.GetNewItem()
                'MainApplication.getInstance.CashJournal.Add(CType(newItem, CashJournalItem))

                newID = newItem.ID

            Case DataSourceList.Transactions
                newItem = MainApplication.getInstance.Transactions.GetNewItem()
                ' MainApplication.getInstance.Transactions.Add(CType(newItem, Transaction))

                newID = newItem.ID

            Case DataSourceList.Units
                newItem = MainApplication.getInstance.Units.GetNewItem()
                MainApplication.getInstance.Units.Add(CType(newItem, Unit))

                newID = newItem.ID

            Case DataSourceList.Discounts
                newItem = MainApplication.getInstance.Discounts.GetNewItem()
                MainApplication.getInstance.Discounts.Add(CType(newItem, Discount))

                newID = newItem.ID

            Case DataSourceList.LoanAccounts
                newItem = MainApplication.getInstance.LoanAccounts.GetNewItem
                MainApplication.getInstance.LoanAccounts.Add(CType(newItem, LoanAccount))

            Case DataSourceList.FixedCosts
                newItem = MainApplication.getInstance.FixedCosts.GetNewItem
                MainApplication.getInstance.FixedCosts.Add(CType(newItem, FixedCost))

            Case DataSourceList.FixedCostGroup
                newItem = MainApplication.getInstance.FixedCostGroups.GetNewItem
                MainApplication.getInstance.FixedCostGroups.Add(CType(newItem, FixedCostGroup))

            Case DataSourceList.HistoryCategories
                newItem = MainApplication.getInstance.HistoryCategories.GetNewItem()
                MainApplication.getInstance.HistoryCategories.Add(CType(newItem, HistoryCategory))

            Case Else
                Throw New NotImplementedException("Ein Objekt von diesem Type: " & m_dataSourceType.ToString & " kann nicht neu angelegt werden.")


        End Select
        RefreshData()

        If newID <> -1 Then
            SelectItemByID(newID)
        End If

        'Das auch Mitteilen
        RaiseEvent AfterCreateNewItem(Me, New StaticItemEventArgs(newItem))

        RaiseEvent RowChangedData(Me, EventArgs.Empty)

        Return newItem
    End Function

    Private Sub grvCommonGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvCommonGrid.KeyDown
        Dim view As GridView = CType(sender, GridView)
        If e.KeyCode = Keys.Return Then
            If view.GetFocusedRow IsNot Nothing Then


                Dim StaticItem As ClausSoftware.Data.StaticItem = CType(view.GetFocusedRow, ClausSoftware.Data.StaticItem)
                m_focusedItem = StaticItem

                RaiseEvent ItemRowDoubleClick(StaticItem.Key)

            End If

        End If

        ' Dann alle markierten Elemente löschen
        If e.KeyCode = Keys.Delete Then
            Me.DeleteSelected()
            Exit Sub
        End If

        ' Neues Element anlegen
        If e.KeyCode = Keys.N And e.Control Then
            Me.CreateNew()
            Exit Sub
        End If
    End Sub

    Private Sub mnuDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDuplicate.Click
        CloneSelectedItem()
    End Sub

    ''' <summary>
    ''' Setzt das Grid in einem edit-Modus oder ruft den Zustand ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Editable() As Boolean
        Get
            Return grvCommonGrid.OptionsBehavior.Editable
        End Get
        Set(ByVal value As Boolean)
            grvCommonGrid.OptionsBehavior.Editable = value

        End Set
    End Property

    ''' <summary>
    ''' Erstellt eine Kopie der selektierten Grid-Zeilen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloneSelectedItem()

        Dim dataItems() As ClausSoftware.Data.StaticItem
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView
        view = CType(grdCommonGrid.FocusedView, GridView)

        ' Liste der selektionen einsammeln
        ReDim dataItems(View.SelectedRowsCount - 1)
        For rowID As Integer = 0 To view.SelectedRowsCount - 1
            dataItems(rowID) = CType(view.GetRow(view.GetSelectedRows(rowID)), ClausSoftware.Data.StaticItem)
        Next

        OnCloneItems(dataItems)

        If m_serverModeDS IsNot Nothing Then ' Nicht alle Datenlisten sind Server-Mode Listen
            m_serverModeDS.Reload()
        End If

        RefreshData()

        RaiseEvent RowChangedData(Me, EventArgs.Empty)
        
    End Sub

    ''' <summary>
    '''  Klont die Liste der übergebenen Datenelemente
    ''' </summary>
    ''' <param name="dataItems"></param>
    ''' <remarks></remarks>
    Public Overridable Sub OnCloneItems(ByVal dataItems() As ClausSoftware.Data.StaticItem)
        For Each dataItem As StaticItem In dataItems
            Dim newItem As StaticItem = CType(dataItem.Clone, StaticItem)
            newItem.Save()
        Next
    End Sub

    ''' <summary>
    ''' Setzt die Spaltenkonfiguration zurück
    ''' </summary>
    ''' <remarks></remarks>
    Sub ResetGridStyle()
        ResetGridStyles(m_currentContext)
    End Sub

    Private Sub SpaltenZurücksetzenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpaltenZurücksetzenToolStripMenuItem.Click
        ResetGridStyle()
    End Sub

    ''' <summary>
    ''' Ruft das View an einer bestimmten Koordinate ab
    ''' </summary>
    ''' <param name="P">Die Mausposition</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetViewAt(ByVal P As Point) As Views.Base.BaseView

        Dim I As Integer
        P = grdCommonGrid.PointToClient(P)
        For I = grdCommonGrid.Views.Count - 1 To 0 Step -1
            Dim View As Views.Base.BaseView = CType(grdCommonGrid.Views(I), Views.Base.BaseView)
            If View.ViewRect.Contains(P) Then _
                Return View
        Next
        Return Nothing
    End Function

    Private Sub grdCommonGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdCommonGrid.Click

        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, GridControl)

        Dim hi As ViewInfo.GridHitInfo = CType(grid.MainView.CalcHitInfo(grid.PointToClient(MousePosition)), ViewInfo.GridHitInfo)
        Dim view As GridView = CType(grid.MainView, GridView)
        ' Filterzeile toggeln
        If hi.HitTest = ViewInfo.GridHitTest.ColumnButton Then

            view.OptionsView.ShowAutoFilterRow = Not view.OptionsView.ShowAutoFilterRow
        End If



    End Sub

    ''' <summary>
    ''' stellt Funktionen zur verfügung, die Indicator-Zelle selber zu zeichnen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Overridable Sub CustomDrawRowIndicator(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grvCommonGrid.CustomDrawRowIndicator
        ' If e.Info.IsRowIndicator Then
        'Dim row As DataRow = GridView1.GetDataRow(e.RowHandle)
        'If Not IsNothing(row) And row.RowError <> String.Empty Then
        '    e.Info.ImageIndex = -1
        '    e.Painter.DrawObject(e.Info)
        '    Dim r As Rectangle = e.Bounds
        '    r.Inflate(-1, -1)
        '    Dim x As Integer = r.X + (r.Width - imageList1.ImageSize.Width) / 2
        '    Dim y As Integer = r.Y + (r.Height - ImageList1.ImageSize.Height) / 2
        '    e.Graphics.DrawImageUnscaled(ImageList1.Images(0), x, y)
        '    e.Handled = True
        'End If
        '   End If
    End Sub

    Private Sub grvCommonGrid_ColumnPositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grvCommonGrid.ColumnPositionChanged
        SaveGridStyle()
    End Sub

    Private Sub crvCommonGrid_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles crvCommonGrid.DataSourceChanged
        LoadGridStyle()
    End Sub

    Private Sub grvCommonGrid_ColumnWidthChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles grvCommonGrid.ColumnWidthChanged
        SaveGridStyle()
    End Sub

    Private Sub grvCommonGrid_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvCommonGrid.DataSourceChanged
        LoadGridStyle()
    End Sub


    Private Sub btnOpenSelectedItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenSelectedItem.Click
        OpenSelectedItem()
    End Sub
    ''' <summary>
    ''' Öffnet das aktuelle focussierte Element per Doppelklick-Simulation
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenSelectedItem()
        If FocussedItem IsNot Nothing Then
            RaiseEvent ItemRowDoubleClick(FocussedItem.Key)

        End If

    End Sub

    Friend Overridable Sub CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles grvCommonGrid.CustomColumnDisplayText
        If m_dataSourceType = DataSourceList.CashJournalMonthy Then

            'TODO: diese Klasse vererben und dort die Speziellen Felder manipulieren
            ' Im Kassenbuch einnahme oder Uasgebe nicht anzeigen, wenn 0
            If e.Column.FieldName = "Ausgabe" Or e.Column.FieldName = "Einnahme" Then
                If CDec(e.Value) = 0 Then
                    e.DisplayText = ""

                End If
            End If
        End If
    End Sub

    Private m_imageDirectionList As New ImageList


    ''' <summary>
    ''' Ermittelt die Anzahl der markierten Zeilen im Grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grvCommonGrid_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs) Handles grvCommonGrid.SelectionChanged
        Dim SelectedCount As Integer = CType(sender, GridView).SelectedRowsCount
        Dim maxcount As Integer = CType(sender, GridView).RowCount

        MainApplication.getInstance.SendMessage(GetText("msgSelectedItemCount", "{0} von {1} markiert.", CStr(SelectedCount), CStr(maxcount)), True)

    End Sub


    ''' <summary>
    ''' Ruft eine Auflistung an Menüelementen ab, die unter "Neu..." eingeblendt werden
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property CustomMenues As List(Of CustomMenuItem)
        Get
            Return m_SubMenue
        End Get

    End Property

    Private m_customMenuBuild As Boolean

    Public Sub BuildCustomMenu()
        If Not m_customMenuBuild Then
            If CustomMenues.Count > 0 Then
                If Not cmsCommonGridMenue.Items.ContainsKey("idcustomNew") Then
                    'cmsCommonGridMenue.Items(1)

                    Dim customNewSeperator As New ToolStripSeparator()
                    cmsCommonGridMenue.Items.Add(customNewSeperator)  ' Trennstrich einfügen

                    ' Dies wird im Moment nur für das Adressbuch benötigt
                    'TODO: Im Adressbuch per VCererbung erledigen (wie bei iucTransactions) 
                    ' einfacher und klareres Handling

                    Dim customNewItem As New ToolStripMenuItem
                    customNewItem.Text = GetText("mnuMoreNew", "Neu...")
                    customNewItem.Name = "idcustomNew"
                    cmsCommonGridMenue.Items.Add(customNewItem)  ' Menüelement  "Neu..."



                    For Each item As CustomMenuItem In Me.CustomMenues
                        Dim newMenuItem As New ToolStripMenuItem
                        newMenuItem.Name = item.Name
                        newMenuItem.Text = item.Caption

                        customNewItem.DropDownItems.Add(newMenuItem) ' Hier hinzufügen..

                        AddHandler newMenuItem.Click, AddressOf cmsCommonGridMenue_ItemClicked
                    Next

                End If

            End If

            m_customMenuBuild = True
        End If

    End Sub

    Private Sub cmsCommonGridMenue_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsCommonGridMenue.Opening
        '  Das Menü um ein SubMenü erweitern. 
        BuildCustomMenu()
        OnOpenMenue()
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, bevor das Grid-Menü angezeigt wird. Kann überschreiben werden
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub OnOpenMenue()

    End Sub

    ''' <summary>
    ''' Wird ausgelöst, wenn ein benutzerangepasstes Menü gelickt wird
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmsCommonGridMenue_ItemClicked(ByVal sender As System.Object, ByVal e As EventArgs)
        'Dim args As New ToolStrip
        If TypeOf sender Is ToolStripMenuItem Then
            Dim item As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
            RaiseEvent MenuItemClicked(Me, New MenuItemClickedEventArgs(item.Name))

        End If

    End Sub

    Private Sub grvCommonGrid_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grvCommonGrid.RowStyle
        If m_dataSourceType = DataSourceList.Transactions Then
            Dim jDoc As Transaction = CType(grvCommonGrid.GetRow(e.RowHandle), Transaction)
            If jDoc IsNot Nothing Then
                If jDoc.IsCanceled Then
                    e.Appearance.Font = New Font(e.Appearance.Font, e.Appearance.Font.Style Or FontStyle.Strikeout)
                End If

            End If
        End If
    End Sub


    Private Sub uicCommonGrid_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If MainApplication.getInstance IsNot Nothing Then
            MainApplication.getInstance.Languages.SetTextOnControl(cmsCommonGridMenue)
        End If
    End Sub

End Class


Friend Class CustomMenuItem

    Private m_name As String

    Private m_caption As String
    ''' <summary>
    ''' Stellt den Menütext da oder legt diesen fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Caption() As String
        Get
            Return m_caption
        End Get
        Set(ByVal value As String)
            m_caption = value
        End Set
    End Property


    ''' <summary>
    ''' Stellt einen eindeutigen Namen dar oder legt diesen fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return m_name
        End Get
        Set(ByVal value As String)
            m_name = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal name As String)
        m_name = name
    End Sub
End Class

''' <summary>
''' Stellt das ereignis bereit, das ein Click auf ein Menüelement signalsiert
''' </summary>
''' <remarks></remarks>
Public Class MenuItemClickedEventArgs
    Inherits EventArgs

    Private m_ItemName As String

    Public Property ItemName() As String
        Get
            Return m_ItemName
        End Get
        Set(ByVal value As String)
            m_ItemName = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal itemName As String)
        Me.ItemName = itemName
    End Sub

End Class
