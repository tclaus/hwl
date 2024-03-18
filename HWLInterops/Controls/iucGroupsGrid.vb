Imports ClausSoftware.Kernel
Imports ClausSoftware.Tools.RegistrySections
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Xpo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraTreeList

Public Class iucGroupsGrid

    ''' <summary>
    ''' Enthält die aktuell selektierte Zeile
    ''' </summary>
    ''' <remarks></remarks>
    Private m_selectedAttachment As Attachment
    Private m_attachmentImporter As New AttachmentImporter

    ''' <summary>
    ''' Enthält den aktuellen Artikel, er im Grid selektiert ist
    ''' </summary>
    ''' <remarks></remarks>
    Private m_focusedItem As Article

    Dim m_showEmptyGroups As Boolean = False

    Dim m_searchCriteria As String
    Private downHitInfo As GridHitInfo
    Private treeIsInDropState As Boolean
    Private m_isLoading As Boolean

    Private m_selectedGroup As ClausSoftware.Kernel.Group


    WithEvents serverModeDS As XPServerCollectionSource


    ''' <summary>
    ''' Wird gefeuert, wenn ein neuer Artikel erstellt wurde, Dieser wurde bereits im Grid selektiert.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event AfterArticleCreated(ByVal sender As Object, ByVal e As StaticItemEventArgs)

    ''' <summary>
    ''' Wird ausgelöst, nachdem ein Artikel geköscht worden ist
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event AfterArticlesDeleted(ByVal sender As Object, ByVal e As EventArgs)


    Private m_groups As Groups

    ''' <summary>
    ''' Ruft eine Gruppen-Auflistung ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property ArticleGroups As Groups
        Get
            If m_groups Is Nothing Then
                m_groups = New Groups(MainApplication.getInstance)
            End If
            Return m_groups
        End Get
    End Property

    ''' <summary>
    ''' Ruft ein übergerodnetes Filterkrfiterium ab, das vor allen anderen Kriterien genutzt wird.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetBaseArticleListCritera() As DevExpress.Data.Filtering.CriteriaOperator
        If Not MainApplication.getInstance.Settings.Articlesettings.ShowInactiveItems Then  ' Wenn eingeschaltet, dann nur aktive Artikel anzeign lassen
            Dim c As New DevExpress.Data.Filtering.BinaryOperator("IsActive", True)
            Return c
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Startet das Grid und füllt ddie entsprechenden Listen auf
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()
        m_isLoading = True


        serverModeDS = New XPServerCollectionSource(MainApplication.getInstance.GetNewSession, MainApplication.getInstance.ArticleList.GetObjectClassInfo)
        serverModeDS.DisplayableProperties = MainApplication.getInstance.ArticleList.DisplayableProperties


        serverModeDS.FixedFilterCriteria = GetBaseArticleListCritera()

        FillGroups(trvGroups)

        grdArticles.ServerMode = True
        grdArticles.DataSource = serverModeDS


        'Sortiereigenschaft verhindern, wenn dynamisch erzeugte Eigenschaft
        Dim listOfProps As New List(Of String)

        For Each prop As Metadata.ReflectionPropertyInfo In serverModeDS.ObjectClassInfo.PersistentProperties
            listOfProps.Add(prop.Name)
        Next

        For Each col As GridColumn In grvArticles.Columns
            If Not listOfProps.Contains(col.FieldName) Then
                col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                col.OptionsFilter.AllowFilter = False
                col.OptionsFilter.AllowAutoFilter = False
            End If

        Next

        FormatMasterTable()

        Me.Refresh()
        m_isLoading = False

        ' Letzes Foccussiertes Node wieder aktivieren
        Dim lastselecedGroup As String = MainApplication.getInstance.Settings.GetSetting("SelectedArticleGroup", ClausSoftware.Tools.RegistrySections.ModuleArticles, "0000")
        Dim selecedNode As TreeListNode = trvGroups.FindNodeByKeyID(lastselecedGroup)
        If selecedNode IsNot Nothing Then
            trvGroups.FocusedNode = selecedNode
            selecedNode.Selected = True
            selecedNode.Selected = True
        End If

    End Sub


    ''' <summary>
    ''' Füllt die LIste der Gruppen neu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillGroups(ByVal trvGroups As TreeList)
        trvGroups.BeginUpdate()
        trvGroups.DataSource = Nothing

        trvGroups.ParentFieldName = "ParentID"
        trvGroups.KeyFieldName = "ReplikID"
        trvGroups.DataSource = Me.ArticleGroups
        trvGroups.EndUpdate()
        trvGroups.RefreshDataSource()

        'Alle geöffneten Nodes wieder herstellen
        RestoreTreeOpenNodes(trvGroups, Context)

        Dim lastselecedGroup As String = MainApplication.getInstance.Settings.GetSetting("SelectedArticleGroup", ClausSoftware.Tools.RegistrySections.ModuleArticles, "0000")
        Dim selecedNode As TreeListNode = trvGroups.FindNodeByKeyID(lastselecedGroup)
        If selecedNode IsNot Nothing Then
            trvGroups.FocusedNode = selecedNode
            selecedNode.Selected = True

        End If
        trvGroups.EndUpdate()

    End Sub

    ''' <summary>
    ''' Zeigt die Filterzeile im Grid an
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowFilterRow() As Boolean
        Get
            Return grvArticles.OptionsView.ShowAutoFilterRow
        End Get
        Set(ByVal value As Boolean)
            grvArticles.OptionsView.ShowAutoFilterRow = value
        End Set
    End Property

    Private Sub FormatInnerGrid(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles grvAttachments.CustomDrawColumnHeader

        Dim imageedit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit = CType(grdArticles.RepositoryItems("RepositoryItemPictureEdit"), DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit)
        imageedit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        If e.Column Is Nothing Then Exit Sub
        If e.Column.ColumnType.Name = GetType(Image).Name Then
            e.Column.ColumnEdit = imageedit

        End If

    End Sub

    Private Sub grvArticles_ColumnFilterChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvArticles.ColumnFilterChanged
        SaveGridStyle()
    End Sub

    Private Sub GridView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles grvArticles.ColumnWidthChanged
        SaveGridStyle()
    End Sub

    ''' <summary>
    ''' Zeichnet inaktive Artikel mit grauer Hintzergrundfarbe
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()>
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grvArticles.CustomDrawCell
        Dim article As Article = CType(grvArticles.GetRow(e.RowHandle), ClausSoftware.Kernel.Article)

        If article IsNot Nothing Then
            If Not article.IsActive Then
                e.Appearance.ForeColor = Color.DarkGray

            End If
        End If
    End Sub


    Private Sub MasterRowGetRelationCount(ByVal sender As Object, ByVal e As MasterRowGetRelationCountEventArgs) Handles grvArticles.MasterRowGetRelationCount
        e.RelationCount = 1 ' Es war mal gedacht, auch die Stückliste hier hineinzubringen .- wurde aber wieder verworfen
    End Sub

    Private Sub MasterRowEmpty(ByVal sender As Object, ByVal e As MasterRowEmptyEventArgs) Handles grvArticles.MasterRowEmpty

        If grvArticles.GridControl.IsPrinting Then
            e.IsEmpty = True
            Exit Sub
        End If

        If e.RelationIndex = 0 Then
            Dim item As Article = CType(grvArticles.GetRow(e.RowHandle), Article)
            If item IsNot Nothing Then

                e.IsEmpty = Not MainApplication.getInstance.AttachmentRelations.HasAttachments(item.ReplikID)


            End If
        End If
        If e.RelationIndex = 1 Then
            e.IsEmpty = False
        End If
    End Sub

    Private Sub MasterRowGetName(ByVal sender As Object, ByVal e As MasterRowGetRelationNameEventArgs) Handles grvArticles.MasterRowGetRelationName
        If e.RelationIndex = 0 Then
            e.RelationName = GetText("headlineAttachments", "Datei Anhänge")
        End If

    End Sub

    Private Sub MasterRowGetChildList(ByVal sender As Object, ByVal e As MasterRowGetChildListEventArgs) Handles grvArticles.MasterRowGetChildList

        If grvArticles.GridControl.IsPrinting Then
            Exit Sub
        End If

        If e.RelationIndex = 0 Then
            Dim item As Article = CType(grvArticles.GetRow(e.RowHandle), Article)

            e.ChildList = item.Attachments
        End If
        If e.RelationIndex = 1 Then
            Dim item As Article = CType(grvArticles.GetRow(e.RowHandle), Article)

            e.ChildList = item.SubArticles
        End If
    End Sub

    ''' <summary>
    ''' Legt den Namen der Grideinstellung fest
    ''' </summary>
    ''' <remarks></remarks>
    Private m_contextstring As String = "MainArticleGrid"

    ''' <summary>
    ''' Ruft den Kontext für die geespeicherten einstellungen ab oder legt dies fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Context() As String
        Get
            Return m_contextstring
        End Get
        Set(ByVal value As String)
            m_contextstring = value
        End Set
    End Property

    Private Sub grvArticles_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvArticles.FocusedRowChanged, grvAttachments.FocusedRowChanged

        If m_isLoading Then Exit Sub

        Dim view As BaseView
        view = grdArticles.FocusedView

        If view IsNot Nothing Then
            If view.Name = grvAttachments.Name Then

                m_selectedAttachment = CType(view.GetRow(e.FocusedRowHandle), Attachment)
            End If

            If view.Name = grvArticles.Name Then

                Dim o As Object = grvArticles.GetRow(e.FocusedRowHandle)
                If o IsNot Nothing Then
                    m_focusedItem = CType(o, ClausSoftware.Kernel.Article)
                    RaiseEvent FocusedItemChanged(m_focusedItem.Key)
                End If

            End If
        End If



    End Sub



    Private Sub GridView2_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles grvAttachments.MouseDown
        Dim view As GridView = CType(sender, GridView)
        downHitInfo = Nothing

        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If System.Windows.Forms.Control.ModifierKeys <> Keys.None Then Exit Sub
        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator And hitInfo.HitTest <> GridHitTest.RowEdge Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub GridView2_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles grvAttachments.MouseMove
        Dim view As GridView = CType(sender, GridView)
        If e.Button = MouseButtons.Left And Not downHitInfo Is Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(CInt(downHitInfo.HitPoint.X - dragSize.Width / 2),
                 CInt(downHitInfo.HitPoint.Y - dragSize.Height / 2)), dragSize)

            If Not dragRect.Contains(New Point(e.X, e.Y)) Then

                Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))

                Dim o As ClausSoftware.Kernel.Attachment = CType(view.GetRow(hitInfo.RowHandle), Attachment)
                Dim filename As String = o.GetFile

                ' hier die Dateien auslösen
                DoDragDrop(New DataObject(DataFormats.FileDrop, New String() {filename}), DragDropEffects.Copy)

                downHitInfo = Nothing
            End If
        End If
    End Sub


    ''' <summary>
    ''' die Dialoge des Grids Top Most anzeigen lassen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub GridView1_ShowcustomForm(ByVal sender As Object, ByVal e As EventArgs) Handles grvArticles.ShowCustomizationForm
        grvArticles.CustomizationForm.TopMost = True

    End Sub


    Public Sub RefreshData()

        If serverModeDS IsNot Nothing Then

            serverModeDS.Reload()
            grvArticles.RefreshData()
        End If
    End Sub

    ''' <summary>
    ''' Ruft die ID der selektiertren Gruppe ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectedGroupID() As String
        Get
            If m_selectedGroup IsNot Nothing Then
                Return m_selectedGroup.Key
            End If
            Return ""

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    ''' <summary>
    ''' Ruft den Schlüssel des gewählten Objektes ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectedArticelID() As String
        Get
            If m_focusedItem IsNot Nothing Then
                Return m_focusedItem.Key
            Else
                Return ""
            End If

        End Get
        Set(ByVal value As String)

        End Set
    End Property
    ''' <summary>
    ''' Ruft den aktuell gewählte Artikel ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property SelectedArticle() As Article
        Get
            Return m_focusedItem
        End Get
    End Property


    Public Delegate Sub delSelectedGroupChanged(ByVal key As String)
    Public Event SelectedGroupChanged As delSelectedGroupChanged

    ''' <summary>
    ''' Wird ausgelöst, wenn der focus der Zeile sich ändert
    ''' </summary>
    ''' <param name="key"></param>
    ''' <remarks></remarks>
    Public Event FocusedItemChanged(ByVal key As String)
    ''' <summary>
    ''' wird ausgelöst, wenn ein doppelklick auf eine Zeile stattfindet
    ''' </summary>
    ''' <param name="key"></param>
    ''' <remarks></remarks>
    Public Event ItemRowDoubleClick(ByVal key As String)

    ''' <summary>
    ''' Signalisiert, das der aktuelle Datensatz bearbeite werden soll. F2 - Taste gedrückt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event RenameTriggered(ByVal sender As Object, ByVal e As EventArgs)




    Private Sub mnuCreateGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCreateGroup.Click
        Dim newGroup As Group

        If trvGroups.FocusedNode IsNot Nothing AndAlso TypeOf trvGroups.GetDataRecordByNode(trvGroups.FocusedNode) Is Group Then

            newGroup = CreateNewGroup(CType(trvGroups.GetDataRecordByNode(trvGroups.FocusedNode), Group))
        Else
            newGroup = CreateNewGroup(Nothing)
        End If


        Dim newNode As TreeListNode = trvGroups.FindNodeByKeyID(newGroup.Key)
        trvGroups.FocusedNode = newNode


        StarteditingFocusedNode()

    End Sub

    ''' <summary>
    ''' Fügt einer gegebenen Gruppen-Objet eine neue Gruppe hinzu und gibt das Treenode zurück
    ''' </summary>
    ''' <param name="ParentGroup">Die eltern-Gruppe oder nothing, falls eine Stammgrupppe hinzgefügt werden soll</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateNewGroup(ByVal parentGroup As Group) As Group

        Dim newGroup As Group = Me.ArticleGroups.GetNewItem


        If parentGroup IsNot Nothing Then
            newGroup.ParentID = parentGroup.Key
        Else
            newGroup.ParentID = Groups.RootID
        End If
        newGroup.Name = GetText("NewArticleGroupName", "Neue Gruppe")
        newGroup.Save()

        Me.ArticleGroups.Add(newGroup)

        Return newGroup
    End Function

    ''' <summary>
    ''' Ruft den Namen der zuletzt mariertren Gruppe ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SelectedGroupName() As String
        Get
            If m_selectedGroup IsNot Nothing Then
                Return m_selectedGroup.Name
            Else
                Return ""
            End If
        End Get
    End Property

    Private Sub Serverexception(ByVal sender As Object, ByVal e As ServerExceptionThrownEventArgs) Handles serverModeDS.ServerExceptionThrown


    End Sub



    ''' <summary>
    ''' Wenn sich der Filter oder die markierte Zeile ändert, dann wird dies signalisiert
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RaiseFocusedRow()
        'Wenn die Gruppe geändert wurde, dann auch ein FocusedNode changed auslösen
        If m_isLoading Then Exit Sub

        Dim o As Object = grvArticles.GetRow(grvArticles.FocusedRowHandle)
        If o IsNot Nothing Then

            If m_focusedItem Is Nothing OrElse m_focusedItem.Key <> CType(o, ClausSoftware.Kernel.Article).Key Then
                m_focusedItem = CType(o, ClausSoftware.Kernel.Article)
                grvArticles.SelectRow(grvArticles.FocusedRowHandle)
                RaiseEvent FocusedItemChanged(m_focusedItem.Key)
            End If
        End If
    End Sub

    Private Sub mnuDeleteGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteGroup.Click
        DeleteSelectedGroups()

    End Sub


    Private Sub DeleteSelectedGroups()
        ' Löschen, wenn leer 
        Dim groupToDelete As Group
        Dim nodeslist As New List(Of TreeListNode)

        Dim toDeleteStack As New Stack(Of Group)


        If trvGroups.FocusedNode IsNot Nothing Then
            If m_selectedGroup IsNot Nothing Then
                If (m_selectedGroup.Key = Groups.RootID) Then Exit Sub ' Root - Node darf nicht gelöscht werden!
            End If
        End If

        For Each node As TreeListNode In trvGroups.Selection
            groupToDelete = CType(trvGroups.GetDataRecordByNode(node), Group)

            Dim dResult As DialogResult
            If groupToDelete.SubGroups.Count > 0 Or groupToDelete.ArticleCountInGroup > 0 Then  'OrElse groupToDelete.HasArticles 

                'TODO:NLS
                dResult = System.Windows.Forms.MessageBox.Show("Diese Gruppe :'" & groupToDelete.Name & "' enthält weitere Daten oder Gruppen! " & vbCrLf &
                                                               "Möchten Sie diese Gruppe und alles was sich darin befindet Löschen? (Untergruppen und Artikel)?", "Gruppe enthält Daten", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If dResult = DialogResult.Cancel Then
                    Exit Sub
                End If
            Else
                dResult = DialogResult.Yes
            End If

            If dResult = DialogResult.Yes Then

                ' Gruppe und Inhalt und untergruppen löschen

                toDeleteStack.Push(groupToDelete)
                nodeslist.Add(node)
            End If
        Next

        m_isLoading = True
        trvGroups.BeginUpdate()
        grdArticles.BeginUpdate()

        Do While toDeleteStack.Count > 0
            ' SQL Fehler möglich beim löschen von Gruppen
            Try
                Dim grp As Group = toDeleteStack.Pop
                grp.Delete(DeleteMode.DeleteSubgroups)
            Catch ex As Exception

            End Try

        Loop

        trvGroups.EndUpdate()
        grdArticles.EndUpdate()
        m_isLoading = False
        grdArticles.RefreshDataSource()

        FillGroups(trvGroups)



    End Sub

    Private Sub cmdTreeView_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsTreeView.Opening
        ' prüfe ob die markierte Gruppe leer ist

        Dim GroupAll As Boolean = False
        If trvGroups.FocusedNode IsNot Nothing Then
            If m_selectedGroup IsNot Nothing Then
                GroupAll = (m_selectedGroup.Key = Groups.RootID)
            End If
        End If
        mnuDeleteGroup.Enabled = Not GroupAll
        mnuCopySelectedArticles.Checked = Not GroupAll

    End Sub

    Private Sub mnuShowEmptyGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowEmptyGroups.Click
        m_showEmptyGroups = Not m_showEmptyGroups
        mnuShowEmptyGroups.Checked = m_showEmptyGroups

        FillGroups(trvGroups)
    End Sub

    ''' <summary>
    ''' Speichert das Layout des Grids ab, sowie den Abstand des Splitters
    ''' </summary>
    Public Sub SaveGridStyle()
        If Not m_isLoading Then
            SaveGridStyle(Me.Context)
        End If

    End Sub


    ''' <summary>
    ''' Speichert das Layout des Grids ab, sowie den Abstand des Splitters
    ''' </summary>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Private Sub SaveGridStyle(ByVal context As String)
        SaveGridStyles(grdArticles, context)
        MainApplication.getInstance.Settings.SetSetting("GridLayout-Splitter", context, CStr(SplitContainer1.SplitterPosition))
        MainApplication.getInstance.Settings.SetSetting("GridLayout-RowHeigh", context, CStr(grvArticles.RowHeight))



    End Sub

    Public Sub LoadGridStyle()
        LoadGridStyle(Me.Context)
    End Sub

    ''' <summary>
    ''' Ruft das Layout des Grids, sowie den Splitter-Abstand wieder ab
    ''' </summary>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Private Sub LoadGridStyle(ByVal context As String)
        RestoreGridStyles(grdArticles, context)
        SplitContainer1.SplitterPosition = CInt(MainApplication.getInstance.Settings.GetSetting("GridLayout-Splitter", context, CStr(SplitContainer1.SplitterPosition)))
        grvArticles.RowHeight = CInt(MainApplication.getInstance.Settings.GetSetting("GridLayout-RowHeigh", context, CStr(grvArticles.RowHeight)))
    End Sub


    ''' <summary>
    ''' Nicht implementiert
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Print()


    End Sub

    ''' <summary>
    ''' Zeigt ein einfaches Grid mit Überschrift an
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowPrintPreview()
        Try
            Dim GridPrinting As SimpleGridPrinting = SimpleGridPrinting.GetSimpleGridPrinting

            GridPrinting.GridToPrint = grdArticles
            GridPrinting.Headline = "Artikelliste"""
            GridPrinting.ShowPreviewDialog()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub grdArticles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdArticles.Click
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = CType(grdArticles.MainView.CalcHitInfo(grdArticles.PointToClient(MousePosition)), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)

        ' Filterzeile toggeln
        If hi.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.ColumnButton Then

            grvArticles.OptionsView.ShowAutoFilterRow = Not grvArticles.OptionsView.ShowAutoFilterRow
        End If

    End Sub

    Private Sub grdArticles_DataSourceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdArticles.DataSourceChanged
        Dim imageedit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit = CType(grdArticles.RepositoryItems("PictureEdit"), DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit)
        imageedit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grvArticles.Columns
            If col.ColumnType.Name = GetType(Image).Name Then
                col.ColumnEdit = imageedit

            End If
        Next

        LoadGridStyle()

    End Sub


    ''' <summary>
    ''' Löscht alle markierten Zeilen im Grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DeleteSelectedArticles()

        'TODO: NLS
        If MessageBox.Show("Möchten Sie die markierten Artikel löschen?", "Artikel löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            grvArticles.BeginDataUpdate()
            grvArticles.BeginSelection()
            'eine zwischenliste mit zu löschenden Einträgen
            Dim lstToDelete As New List(Of Integer)
            Dim maxCount As Integer = grvArticles.SelectedRowsCount
            Dim currentID As Integer

            For Each itemID As Integer In grvArticles.GetSelectedRows()
                Dim item As Article = CType(grvArticles.GetRow(itemID), Article)
                If item Is Nothing Then Continue For

                Try
                    ' Keine Artikel löschen, die in einer Stückliste verbaut wurden
                    If Not item.GetParentArticles.Count = 0 Then
                        'TODO: NLS
                        MessageBox.Show("Kann Artikel '" & item.ShortDescription & "' nicht löschen, da dieser Bauteil eines anderen Artikels ist.", "Artikel bereits verbaut.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Continue For
                    End If
                    If item.IsInJournal Then
                        MessageBox.Show("Kann Artikel """ & item.ShortDescription & " ""nicht löschen. Dieser wurde in einem Angebot oder einer Rechnung verwendet.", "Löschen nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        Continue For
                    End If

                    lstToDelete.Add(item.ID)
                    MainApplication.getInstance.SendMessage(currentID & "/ " & maxCount & " " & GetText("deleted"))
                    item.Delete()

                    currentID += 1
                Catch ex As Exception
                    MessageBox.Show("Kann Datensatz nicht löschen, es liegen eventuell noch Verweise vor", "Löschen nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End Try
            Next

            grvArticles.EndSelection()
            serverModeDS.Reload()
            grvArticles.EndDataUpdate()

        End If
    End Sub



    ''' <summary>
    ''' Implementiert Drag and Drop
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GridView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles grvArticles.MouseDown
        Dim view As GridView = CType(sender, GridView)
        downHitInfo = Nothing

        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If System.Windows.Forms.Control.ModifierKeys <> Keys.None Then Exit Sub
        If e.Button = MouseButtons.Left AndAlso hitInfo.InRow AndAlso hitInfo.HitTest <> GridHitTest.RowIndicator Then
            downHitInfo = hitInfo
        End If
    End Sub

    Private Sub GridView1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles grvArticles.MouseMove
        Dim view As GridView = CType(sender, GridView)

        If view.IsSizingState Then
            downHitInfo = Nothing
            Exit Sub
        End If


        If e.Button = MouseButtons.Left And Not downHitInfo Is Nothing Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(CInt(downHitInfo.HitPoint.X - dragSize.Width / 2),
                 CInt(downHitInfo.HitPoint.Y - dragSize.Height / 2)), dragSize)

            If Not dragRect.Contains(New Point(e.X, e.Y)) Then

                view.GridControl.DoDragDrop(GetSelectedArticles, DragDropEffects.All)
                downHitInfo = Nothing
            End If
        End If
    End Sub


    ''' <summary>
    ''' Setzt Formatierungstypen für die Haupt-Tabelle
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormatMasterTable()


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grvArticles.Columns
            If col.ColumnType.Name = GetType(Decimal).Name Then
                col.DisplayFormat.FormatString = "C"
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

            End If


        Next

    End Sub


    ''' <summary>
    ''' Ruft die Liste aller markierten Artikel ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSelectedArticles() As ListOfArticles
        Dim c As New ListOfArticles
        For Each RowID As Integer In grvArticles.GetSelectedRows()

            c.ArticlesList.Add(CType(grvArticles.GetRow(RowID), Article))

        Next

        Return c
    End Function


    ''' <summary>
    ''' Löst aus, wenn eine Zeile doppelt geklickt wurde
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RowDoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles grvArticles.DoubleClick
        Dim view As GridView = CType(sender, GridView)

        Try
            Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(grdArticles.PointToClient(MousePosition))

            If (hi.InRow) Then
                Dim rowItem As ClausSoftware.Kernel.Article = CType(grvArticles.GetRow(hi.RowHandle), ClausSoftware.Kernel.Article)
                If rowItem IsNot Nothing Then

                    m_focusedItem = rowItem
                    RaiseEvent ItemRowDoubleClick(rowItem.Key)
                End If
            End If

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog("Fehler beim RowDoubleClick: " & ex.Message)
        End Try

    End Sub


    Private Sub RowKeyPress(ByVal sender As Object, ByVal e As KeyEventArgs) Handles grvArticles.KeyDown
        Dim view As GridView = CType(sender, GridView)

        If e.KeyCode = Keys.Return Then
            If view.GetFocusedRow IsNot Nothing Then
                Dim rowItem As ClausSoftware.Kernel.Article = CType(view.GetFocusedRow, ClausSoftware.Kernel.Article)
                If rowItem IsNot Nothing Then

                    m_focusedItem = rowItem
                    RaiseEvent ItemRowDoubleClick(rowItem.Key)
                    e.Handled = True
                End If
            End If
        End If

        If e.KeyCode = Keys.F2 Then
            ' Rename - ereignis auslösen
            RaiseEvent RenameTriggered(Me, EventArgs.Empty)
        End If

    End Sub

    Private Sub iucGroupsGrid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DesignMode Then Exit Sub

        If MainApplication.getInstance IsNot Nothing Then
            ' weitere initailisierungen... 
            MainApplication.getInstance.Languages.SetTextOnControl(cmsGrid)
            MainApplication.getInstance.Languages.SetTextOnControl(cmsTreeView)
        End If
    End Sub



    Private Sub iucGroupsGrid_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        'Me.Refresh()

    End Sub

    Private Sub mnuSelectforCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectforCopy.Click

        If TypeOf trvGroups.FocusedNode.Tag Is Group Then
            ' zum kopieren markieren
            CType(trvGroups.FocusedNode.Tag, Group).CopyExtern = mnuCopySelectedArticles.Checked
            CType(trvGroups.FocusedNode.Tag, Group).Save()
        Else
            ' dann war "ALL" angeklickt
            ' Nur nach rückfrage
            If MessageBox.Show("Möchten Sie alle Gruppen für eine Übertragung markieren?", "Gruppen extern übertragen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                For Each Group As ClausSoftware.Kernel.Group In Me.ArticleGroups
                    Group.CopyExtern = True
                Next
            End If

            Me.ArticleGroups.Save()

        End If
    End Sub

    Private Sub grdArticles_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdArticles.DragDrop
        Try

            Dim fileList As Array = CType(e.Data.GetData(DataFormats.FileDrop), Array)
            If fileList Is Nothing Then
                Exit Sub
            End If

            Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = CType(grdArticles.Views(0).CalcHitInfo(grdArticles.PointToClient(MousePosition)), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)

            If hi.HitTest <> GridHitTest.ColumnEdge AndAlso hi.HitTest <> GridHitTest.Column Then
                If hi.RowHandle >= 0 Then


                    Dim currentDocument As Article = CType(grdArticles.DefaultView.GetRow(hi.RowHandle), Article)
                    Debug.Print("Do DragDrop with DocNumber:" & currentDocument.ID)

                    m_focusedItem = currentDocument

                    Me.Focus()
                    Me.Refresh()

                    m_attachmentImporter.StartCopyFiles(fileList, m_focusedItem)
                    grdArticles.RefreshDataSource()

                End If
            End If


        Catch ex As Exception

            Trace.WriteLine("Error in DragDrop function: " + ex.Message)
        End Try
        downHitInfo = Nothing
    End Sub

    Private Sub grdArticles_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdArticles.DragEnter
        Debug.Print("Drag&Drop_entered")

        If (e.Data.GetDataPresent(DataFormats.FileDrop)) And downHitInfo Is Nothing Then
            e.Effect = DragDropEffects.Copy

        Else
            e.Effect = DragDropEffects.None
        End If
        'Debug.Print(e.Data.GetFormats)
    End Sub

    Private Sub grdArticles_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdArticles.DragOver

        Dim View As GridView = CType(grdArticles.GetViewAt(grdArticles.PointToClient(New Point(e.X, e.Y))), GridView)

        If View IsNot Nothing Then
            With View.CalcHitInfo(grdArticles.PointToClient(New Point(e.X, e.Y)))
                If .InRowCell Then
                    HotTrackRow = .RowHandle
                Else
                    HotTrackRow = DevExpress.XtraGrid.GridControl.InvalidRowHandle
                End If
            End With

            Dim articles As New List(Of Kernel.Article)

            For Each rowID As Integer In grvArticles.GetSelectedRows
                articles.Add(CType(grvArticles.GetRow(rowID), Kernel.Article))
            Next

            e.Data.SetData(GetType(Kernel.Article), articles)
            e.Effect = DragDropEffects.All

        End If
    End Sub

    Private Sub grdArticles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdArticles.KeyDown
        'If e.Control And e.KeyCode = Keys.A Then
        '    ' alle Markieren
        '    GridView1.SelectAll()
        'End If
    End Sub

    Private HotTrackRowValue As Integer = DevExpress.XtraGrid.GridControl.InvalidRowHandle

    Private Property HotTrackRow() As Integer
        Get
            Return HotTrackRowValue
        End Get
        Set(ByVal Value As Integer)
            If HotTrackRowValue <> Value Then
                Dim PrevHotTrackRow As Integer
                PrevHotTrackRow = HotTrackRowValue
                HotTrackRowValue = Value

                grvArticles.RefreshRow(PrevHotTrackRow)
                grvArticles.RefreshRow(HotTrackRowValue)


            End If
        End Set
    End Property

    Private Sub cmsGrid_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsGrid.Opening
        ' Selektierte Artikel für externe kopie markieren

        Dim view As GridView = CType(grdArticles.FocusedView, GridView)

        If view Is grvArticles Then
            Dim AnyFocussedItems As Boolean = grvArticles.GetSelectedRows.Length > 0

            If grvArticles.GetFocusedRow() IsNot Nothing Then

            End If

            mnuCopySelectedArticles.Enabled = AnyFocussedItems
            mnuDeleteArticle.Enabled = AnyFocussedItems
            mnuDuplicateItem.Enabled = AnyFocussedItems
            mnuAddAttachment.Enabled = AnyFocussedItems
            mnuOpenInNewWindow.Enabled = AnyFocussedItems
            mnuOpenItem.Enabled = AnyFocussedItems
            mnuOpenItensGroup.Enabled = AnyFocussedItems

            mnuDeleteAttachment.Visible = False
            mnuOpenItensGroup.Visible = True
            mnuDeleteArticle.Visible = True

        Else ' Anhanng - Fenster war offen
            mnuOpenItensGroup.Visible = False
            mnuDeleteAttachment.Visible = True
            mnuDeleteArticle.Visible = False
            mnuSelectforCopy.Visible = False
        End If



    End Sub

    Private Sub mnuCopySelectedArticles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopySelectedArticles.Click

        For Each itemNumber As Integer In grvArticles.GetSelectedRows

            Dim Article As ClausSoftware.Kernel.Article = TryCast(grvArticles.GetRow(itemNumber), ClausSoftware.Kernel.Article)

            If Article IsNot Nothing Then
                Article.Copyextern = mnuCopySelectedArticles.Checked
                grvArticles.RefreshRow(itemNumber)

            End If

        Next

    End Sub

    Sub SetSearchParameter(ByVal searchText As String)
        Debug.Print("Suchtext: " & searchText)

        m_searchCriteria = searchText

        '(DTNmatchcode ='" & Trim(.Matchcode) & "' or userartikelnummer like '%" & .Matchcode & "%') 

        If searchText.Trim = "" Then
            grvArticles.ActiveFilterCriteria = Nothing

        Else
            grvArticles.ActiveFilter.NonColumnFilter = "[LongDescription] like '%" & searchText & "%' or [ShortDescription] like '%" & searchText & "%' or EAN='" & searchText & "' or CustomerArticleNumber like'%" & searchText & "%' or DatanormMatchCode like '%" & searchText & "%'"

        End If





    End Sub


    Private Sub mnuDeleteArticle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteArticle.Click

        DeleteSelectedArticles()

    End Sub


    Private Sub mnuRenameGroupItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRenameGroupItem.Click

        StarteditingFocusedNode()
    End Sub

    Private Sub StarteditingFocusedNode()
        If Not trvGroups.FocusedNode Is Nothing Then
            trvGroups.Columns(0).OptionsColumn.AllowEdit = True
            trvGroups.ShowEditor()

        End If
    End Sub

    Private Sub trvGroups_AfterCollapse(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles trvGroups.AfterCollapse, trvGroups.AfterExpand
        ' Die Liste aller geöffneten Nodes sichern und wieder herstellen
        SaveTreeOpenNodes(trvGroups, Context)
    End Sub

    Private Sub trvGroups_AfterDragNode(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles trvGroups.AfterDragNode

        CType(trvGroups.GetDataRecordByNode(e.Node), Group).Save()

    End Sub

    Private Sub trvGroups_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trvGroups.ShownEditor

    End Sub


    Private Sub trvGroups_HiddenEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvGroups.HiddenEditor
        trvGroups.Columns(0).OptionsColumn.AllowEdit = False

        CType(trvGroups.GetDataRecordByNode(trvGroups.FocusedNode), Group).Save()

    End Sub


    Private Sub trvGroups_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles trvGroups.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeleteSelectedGroups()
        End If

        If trvGroups.FocusedNode.HasChildren Then

            If e.KeyCode = Keys.Right Then
                trvGroups.FocusedNode.Expanded = True
            End If

            If e.KeyCode = Keys.Left Then
                trvGroups.FocusedNode.Expanded = False
            End If

            If e.KeyCode = Keys.Enter Then
                trvGroups.FocusedNode.Expanded = Not trvGroups.FocusedNode.Expanded
            End If
        End If

        'Bearbeiten
        If e.KeyCode = Keys.F2 Then
            e.SuppressKeyPress = True
            StarteditingFocusedNode()
        End If


    End Sub

    Private Sub trvGroups_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles trvGroups.DragEnter


        Debug.Print(e.AllowedEffect.ToString)
        If e.Data.GetDataPresent(GetType(ListOfArticles)) Then
            e.Effect = DragDropEffects.Move
        End If

    End Sub

    Private Sub trvGroups_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles trvGroups.DragDrop
        If e.Data.GetDataPresent(GetType(ListOfArticles)) Then

            ' alle Artikel im Clipboard in diese Gruppe reinlegen
            Dim targetNode As TreeListNode
            Dim hi As DevExpress.XtraTreeList.TreeListHitInfo = trvGroups.CalcHitInfo(trvGroups.PointToClient(New Point(e.X, e.Y)))
            If hi.Node IsNot Nothing Then


                targetNode = hi.Node
                Dim targetkey As String = CStr(targetNode.GetValue("ReplikID"))
                If targetkey <> Groups.RootID Then
                    Dim listOfArticles As ListOfArticles = CType(e.Data.GetData(GetType(ListOfArticles)), ListOfArticles)

                    For Each Article As Article In listOfArticles.ArticlesList
                        Article.GroupID = targetkey
                        Article.Save()
                    Next
                    grdArticles.RefreshDataSource()

                    trvGroups.SetFocusedNode(targetNode)
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_SelectionChanged(ByVal sender As Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs) Handles grvArticles.SelectionChanged
        RaiseFocusedRow()

        Dim SelectedCount As Integer = CType(sender, GridView).SelectedRowsCount
        Dim maxcount As Integer = CType(sender, GridView).RowCount

        MainApplication.getInstance.SendMessage(GetText("msgSelectedItemCount", "{0} von {1} markiert.", CStr(SelectedCount), CStr(maxcount)), True)

    End Sub

    ''' <summary>
    ''' Ruft aus dem aktuellem Grid das aktuell selektierte Objekt ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSelectedObject() As Object
        Dim view As BaseView = grdArticles.GetViewAt(grdArticles.PointToClient(MousePosition))

        view = grdArticles.FocusedView

        If view IsNot Nothing Then
            Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = CType(view.CalcHitInfo(grdArticles.PointToClient(MousePosition)), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)
            Debug.Print(CStr(hi.HitTest))
            If hi.HitTest <> GridHitTest.ColumnEdge AndAlso hi.HitTest <> GridHitTest.Column Then
                If hi.RowHandle >= 0 Then
                    Dim o As Object = view.GetRow(hi.RowHandle)
                    Return o
                End If
            End If
        End If
        Return Nothing
    End Function

    Private Sub GridView2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grvAttachments.DoubleClick
        Dim item As Object = GetSelectedObject()



        If TypeOf item Is ClausSoftware.Kernel.Attachment Then
            OpenAttachment(CType(item, Attachment))
        End If

    End Sub

    Private Sub AnhangHinzufügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddAttachment.Click

        Dim filellist() As String
        Dim fod As New Vista_Api.OpenFileDialog
        fod.Multiselect = True
        If fod.ShowDialog() = Windows.Forms.DialogResult.OK Then
            filellist = fod.FileNames
            Dim frm As New frmWaitForFileCopy(CType(m_focusedItem, ClausSoftware.Data.IAttachments), filellist)
            frm.ShowDialog()

        End If

    End Sub

    Private Sub GridView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grvArticles.MouseUp
        downHitInfo = Nothing
    End Sub

    ''' <summary>
    ''' Legt einen neuen Artikel an
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CreateNewArticle()
        Dim newID As Integer = -1
        Dim groupKey As String

        If m_selectedGroup Is Nothing Then
            'TODO: NLS
            Dim commandLinks As New List(Of Vista_Api.CommandLink)


            Dim command As New Vista_Api.CommandDialog()
            command.Text = "Möchten sie den Artikel anlegen?" 'TODO: NLS
            command.Title = "Neuen artikel anlegen"
            command.Description = "Sie finden den Artikel dann unter ""Alle"" Artikel wieder"
            command.ShowDialog()

            If MessageBox.Show("Sie haben keine Gruppe gewählt. Möchten Sie einen Artikel anlegen, ohne diesen einer bestimmten Gruppe zuzuweisen?" & vbCrLf &
                               "Sie finden den Artikel dann unter 'Alle Artikel' wieder.",
                            "Keine Artikelgruppe gewählt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                groupKey = Groups.RootID

            Else
                groupKey = m_selectedGroup.Key
            End If
        Else
            groupKey = m_selectedGroup.Key

        End If

        ' Filter entfernen, damit der neue RAtikel auf jeden Fall auch gefunden werden kann
        If Not grvArticles.ActiveFilter.IsEmpty Then
            grvArticles.ActiveFilterCriteria = Nothing
        End If

        Dim newItem As ClausSoftware.Kernel.Article
        newItem = MainApplication.getInstance.ArticleList.GetNewItem()

        newItem.GroupID = groupKey
        newItem.ShortDescription = GetText("NewArticleName", "<Neuer Artikel>")
        newItem.Save()
        ' MainApplication.getInstance.ArticleList.Add(newItem)

        newID = newItem.ID

        RefreshData()

        If newID <> -1 Then

            m_isLoading = True
            grvArticles.ClearSelection()

            ' den neuen Artikel auch gleich mal anzeigen lassen.. 
            For rowid As Integer = 0 To grvArticles.RowCount - 1
                Dim article As Article = CType(grvArticles.GetRow(rowid), ClausSoftware.Kernel.Article)
                If article.ID = newID Then
                    grvArticles.SelectRow(rowid)
                    grvArticles.FocusedRowHandle = rowid
                    Exit For
                End If
            Next
            m_isLoading = False

            RaiseFocusedRow()
        End If
        ' Benachrichtigen, das ein neuer Artikel erstellt wurde
        RaiseEvent AfterArticleCreated(Me, New StaticItemEventArgs(newItem))
    End Sub

    Private Sub mnuCreateNewArticle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCreateNewArticle.Click, mnuCreateArticleFromGroup.Click
        CreateNewArticle()
    End Sub

    Private Sub mnuDeleteAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteAttachment.Click
        DeleteSelectedAttachments()
    End Sub


    Private Sub DeleteSelectedAttachments()
        Dim view As GridView = CType(grdArticles.FocusedView, GridView)

        If view.Name = grvAttachments.Name Then

            Dim attachmentsToDelete As New List(Of Attachment)

            For Each rowID As Integer In view.GetSelectedRows
                Dim attachmentItem As Attachment = CType(view.GetRow(rowID), Attachment)
                attachmentsToDelete.Add(attachmentItem)
            Next

            Dim parentArticle As Article
            parentArticle = CType(CType(view.ParentView, GridView).GetFocusedRow, Article)

            For Each item As Attachment In attachmentsToDelete
                MainApplication.getInstance.AttachmentRelations.Remove(parentArticle.Key, item)
            Next


            view.DeleteSelectedRows()


            view.RefreshData()
        End If



    End Sub

    ''' <summary>
    ''' Löscht alle markierten Elemente eines Grids.
    ''' </summary>
    ''' <param name="View"></param>
    ''' <remarks></remarks>
    Friend Sub DeleteSelectedRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Row As ClausSoftware.Data.StaticItem
        Dim Rows() As ClausSoftware.Data.StaticItem
        Dim I As Integer

        ReDim Rows(View.SelectedRowsCount - 1)
        For I = 0 To View.SelectedRowsCount - 1
            Rows(I) = CType(View.GetRow(View.GetSelectedRows(I)), ClausSoftware.Data.StaticItem)
        Next

        View.BeginSort()
        Try
            For Each Row In Rows
                Row.Delete()
            Next
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ClausSoftware.Tools.LogSeverity.Warning, "Can't delete this GroupItem from GridMenü: " & ex.Message)
            MessageBox.Show(GetText("msgUnresolvedContraintsInDataItemCantDelete", "Kann Datensatz nicht löschen, es liegen eventuell noch Verweise vor."), GetText("msgDeleteRejected", "Löschen nicht möglich."), MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Finally
            View.EndSort()
        End Try
    End Sub

    Private Sub trvGroups_FocusedNodeChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles trvGroups.AfterFocusNode

        If m_isLoading Then Exit Sub

        m_focusedNodeDeferment.Stop()
        m_focusedNodeDeferment.Start()




    End Sub

    Private Sub FoccusedNodeChanged() Handles m_focusedNodeDeferment.Tick
        Static Dim Atwork As Boolean = False

        m_focusedNodeDeferment.Stop()
        If Atwork Then Exit Sub
        Atwork = True
        Try
            Dim group As Group = CType(trvGroups.GetDataRecordByNode(trvGroups.FocusedNode), ClausSoftware.Kernel.Group)

            If group IsNot Nothing Then

                If group.IsRootGroup Then ' dann keinen Filter verwenden
                    serverModeDS.FixedFilterCriteria = GetBaseArticleListCritera()
                Else

                    If Not group.IsNew Then ' Bei neuen Gruppenist ie LIste der untergeordneten Gruppen eher nicht wichtig
                        ' Nur bei untergruppen einen Filter verwenden, der die untergeordneten Gruppen einsamelt
                        Dim inop As New DevExpress.Data.Filtering.InOperator("GroupID", group.GetSubGroupList)
                        serverModeDS.FixedFilterCriteria = New DevExpress.Data.Filtering.GroupOperator(DevExpress.Data.Filtering.GroupOperatorType.And, GetBaseArticleListCritera, inop)
                    End If
                End If

                m_selectedGroup = group
                RaiseEvent SelectedGroupChanged(m_selectedGroup.Key)

                MainApplication.getInstance.Settings.SetSetting("SelectedArticleGroup", ModuleArticles, m_selectedGroup.Key)

            Else
                If serverModeDS IsNot Nothing Then
                    ' dann war es wohl "ALL"
                    serverModeDS.FixedFilterCriteria = GetBaseArticleListCritera()
                End If

                MainApplication.getInstance.Settings.SetSetting("SelectedArticleGroup", ModuleArticles, "0000")
                RaiseEvent SelectedGroupChanged("0000")
            End If


            RaiseFocusedRow()

        Catch ex As Exception
            Debug.Print(ex.Message)

        Finally
            Atwork = False

        End Try

    End Sub


    Private Sub mnuDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDuplicateItem.Click
        CloneSelectedItem()
    End Sub

    ''' <summary>
    ''' Kopiert den aktuell gewählten Artikel und legt diesen als neuen Artikel an
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloneSelectedItem()
        If m_focusedItem IsNot Nothing Then

            Dim newarticle As Article = CType(m_focusedItem.Clone, Article)
            Dim newId As Integer

            ' MainApplication.getInstance.ArticleList.Add(newarticle)
            newarticle.Save()
            newId = newarticle.ID

            RefreshData()

            If newId <> -1 Then
                m_focusedItem = newarticle

                For rowid As Integer = 0 To grvArticles.RowCount - 1
                    Dim article As Article = CType(grvArticles.GetRow(rowid), ClausSoftware.Kernel.Article)
                    If article.ID = newId Then
                        grvArticles.SelectRow(rowid)
                        grvArticles.FocusedRowHandle = rowid
                    Else
                        grvArticles.UnselectRow(rowid)
                    End If
                Next

            End If

        End If
    End Sub

    Private Sub GridView1_MasterRowGetRelationDisplayCaption(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles grvArticles.MasterRowGetRelationDisplayCaption
        If e.RelationIndex = 0 Then
            ' Falls das Fenster gezoomed wird, den Namen des Artikels anzeigen lassen 
            Dim item As Article = CType(grvArticles.GetRow(e.RowHandle), Article)
            e.RelationName = item.ShortDescription
        End If
    End Sub

    Private Sub GridView1_CustomFilterDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles grvArticles.CustomFilterDisplayText
        '  e.Value = "Hallo"

    End Sub


    Private Sub trvGroups_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvGroups.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hf As TreeListHitInfo = trvGroups.CalcHitInfo(e.Location)
            If hf.Node IsNot Nothing Then
                trvGroups.FocusedNode = hf.Node
            End If
        End If
    End Sub

    Private Sub trvGroups_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvGroups.MouseDoubleClick

        Dim hf As TreeListHitInfo = trvGroups.CalcHitInfo(e.Location)
        If hf.Node IsNot Nothing Then
            ShowGroupDetails(CType(trvGroups.GetDataRecordByNode(hf.Node), Group))
        End If

    End Sub

    ''' <summary>
    ''' Zeigt eine Detailansicht der Gruppe an
    ''' </summary>
    ''' <param name="group"></param>
    ''' <remarks></remarks>
    Private Sub ShowGroupDetails(ByVal group As Group)
        Dim frm As New frmSetGroupDetails()
        frm.Group = group
        frm.ShowDialog()
    End Sub


    Private Sub mnuGroupDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGroupDetails.Click
        If m_selectedGroup IsNot Nothing Then
            ShowGroupDetails(m_selectedGroup)
        End If
    End Sub

    Private Sub mnuClassification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClassification.Click


        MainUI.StartClassificationWindow(m_selectedGroup.AttributeClass)

    End Sub

    Private Sub GridView1_ColumnPositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grvArticles.ColumnPositionChanged
        SaveGridStyle()
    End Sub

    Private Sub btnRefreshGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenItensGroup.Click
        SyncGroupWithSelectedItem()
    End Sub

    Public Sub SyncGroupWithSelectedItem()
        If m_focusedItem IsNot Nothing Then
            Dim grpNode As DevExpress.XtraTreeList.Nodes.TreeListNode = trvGroups.FindNodeByFieldValue("ReplikID", m_focusedItem.GroupID)

            If grpNode Is Nothing Then
                Dim cl As New Vista_Api.CommandDialog()
                'TODO: NLS
                cl.Text = "Es konnte keine Gruppe zu diesem artikel gefunden werden"
                cl.Title = "Artikel ist keiner Gruppe zugeordnet"

                cl.ShowDialog()
            Else
                trvGroups.SetFocusedNode(grpNode)
            End If
        End If

    End Sub


    Private Sub ttcTreeview_GetActiveObjectInfo(ByVal sender As System.Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ttcTreeview.GetActiveObjectInfo
        ' Soll vor Allem im Treeview die Tooltips anzeigen lassen 
        Try
            If e.SelectedControl Is trvGroups Then
                Dim info As TreeListHitInfo = trvGroups.CalcHitInfo(e.ControlMousePosition)

                If (info IsNot Nothing) And (info.Node IsNot Nothing) Then
                    ' die Gruppe abholen
                    Dim grp As Group = CType(trvGroups.GetDataRecordByNode(info.Node), Group)
                    If grp Is Nothing Then Exit Sub

                    e.Info = New DevExpress.Utils.ToolTipControlInfo()
                    e.Info.Object = info.Node
                    e.Info.Title = grp.Name

                    e.Info.Text = grp.Description

                End If
            End If
        Catch ex As Exception
            Debug.Print("FEHLER in ttcTreeview_GetActiveObjectInfo: " & ex.Message)
        End Try

    End Sub

    Private Sub btnOpenItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenItem.Click
        OpenFocusedItem()
    End Sub

    Private Sub OpenFocusedItem()
        Try
            RaiseEvent ItemRowDoubleClick(m_focusedItem.Key)
        Catch
        End Try

    End Sub

    Private Sub grvArticles_MasterRowGetLevelDefaultView(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles grvArticles.MasterRowGetLevelDefaultView

        If e.RelationIndex = 0 Then
            e.DefaultView = grvAttachments
        End If

    End Sub

    Private Sub grvAttachments_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grvAttachments.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeleteSelectedAttachments()
        End If
    End Sub
End Class


''' <summary>
''' Stellt eine Grid-Klasse bereit, die für das Drucken grosser Mengen optimiert wurde
''' </summary>
''' <remarks></remarks>
Friend Class PrintingGrid
    Inherits DevExpress.XtraGrid.Views.Grid.GridView

    Private m_isPrinting As Boolean

    Public Property IsPrinting() As Boolean
        Get
            Return m_isPrinting
        End Get
        Set(ByVal value As Boolean)
            m_isPrinting = value
        End Set
    End Property

End Class

''' <summary>
''' Stellt eien Klasse bereit, die eine Auflistung von Artikeln kapselt
''' </summary>
''' <remarks></remarks>
Public Class ListOfArticles
    Private m_list As New List(Of ClausSoftware.Kernel.Article)

    ''' <summary>
    ''' Ruft eine Auflistung von Artikeln ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ArticlesList() As List(Of ClausSoftware.Kernel.Article)
        Get
            Return m_list
        End Get

    End Property

End Class
