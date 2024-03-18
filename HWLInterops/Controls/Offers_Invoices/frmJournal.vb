Imports ClausSoftware.Kernel
Imports DevExpress
Imports DevExpress.Data
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo



''' <summary>
''' Stellt das Formular mit allen Dokumenten bereit
''' </summary>
''' <remarks></remarks>
Public Class frmJournal


    Private m_gridWasFormatted As Boolean
    Private m_fileListToSave As New List(Of String)
    Private downHitInfo As GridHitInfo
    Private m_maxInsuranceID As Integer
    Private m_journalList As JournalDocuments

    ''' <summary>
    ''' Enthält den letzten memo-Text des Journaleintrages
    ''' </summary>
    ''' <remarks></remarks>
    Private m_memoText As String

    Private isloading As Boolean

    Friend Enum CurrentDateView
        ''' <summary>
        ''' Entspricht "Heute"
        ''' </summary>
        ''' <remarks></remarks>
        Day
        ''' <summary>
        ''' Entspricht "letzte 7 Tage"
        ''' </summary>
        ''' <remarks></remarks>
        Week
        ''' <summary>
        ''' entspricht "Letzte 30 Tage"
        ''' </summary>
        ''' <remarks></remarks>
        Month
        ''' <summary>
        ''' Dieses Quartal
        ''' </summary>
        ''' <remarks></remarks>
        ThisQuarter
        ''' <summary>
        ''' Entspricht "Letztes Jahr"
        ''' </summary>
        ''' <remarks></remarks>
        Year
        ''' <summary>
        ''' ALLE, ohne Filter
        ''' </summary>
        ''' <remarks></remarks>
        All

        ''' <summary>
        ''' Das erste Quartal des Jahres
        ''' </summary>
        ''' <remarks></remarks>
        FirstQuarter
        ''' <summary>
        ''' Das zweite Quartal dieses Jahres
        ''' </summary>
        ''' <remarks></remarks>
        SecondQuarter
        ''' <summary>
        ''' Das dritte Quartal des Jahres
        ''' </summary>
        ''' <remarks></remarks>
        ThirdQuarter
        ''' <summary>
        '''  Das virete Quartal dieses Jahres
        ''' </summary>
        ''' <remarks></remarks>
        FourthQuarter

    End Enum

    ''' <summary>
    ''' Stellt eine Filteroption für die Ansicht aller Dokumente bereit
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class JournalViewFilter

        Public Sub New(ByVal kind As CurrentDateView)
            Me.ViewKind = kind
        End Sub




        Private m_viewKind As CurrentDateView
        ''' <summary>
        ''' Ruft die aktuelle Ansicht ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Property ViewKind() As CurrentDateView
            Get
                Return m_viewKind
            End Get
            Set(ByVal value As CurrentDateView)
                m_viewKind = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Select Case Me.ViewKind
                Case CurrentDateView.All : Return GetText("itemAllDates", "Alle")
                Case CurrentDateView.Day : Return GetText("ItemToday", "Heute")
                Case CurrentDateView.Month : Return GetText("ItemThisMonth", "Dieser Monat")
                Case CurrentDateView.ThisQuarter : Return GetText("ItemThisQuarter", "Dieses Quartal")
                Case CurrentDateView.Week : Return GetText("ItemLast7Days", "Letze 7 Tage")
                Case CurrentDateView.Year : Return GetText("itemThisYear", "Seit Jahresbeginn")

                Case CurrentDateView.FirstQuarter : Return GetText("itemFirstQuarter", "1. Quartal")
                Case CurrentDateView.SecondQuarter : Return GetText("itemSecondQuarter", "2. Quartal")
                Case CurrentDateView.ThirdQuarter : Return GetText("itemThirdQuarter", "3. Quartal")
                Case CurrentDateView.FourthQuarter : Return GetText("itemForthQuarter", "4. Quartal")

                Case Else
                    Debug.Assert(False, "Filter im Journal niht bekannt")
                    Return "-ERROR"
            End Select

        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is JournalViewFilter Then

                Return Me.ViewKind = CType(obj, JournalViewFilter).ViewKind
            Else
                Return MyBase.Equals(obj)
            End If
        End Function
    End Class

    ''' <summary>
    ''' enthält den zuletzt eingestellten Dateumsbereich
    ''' </summary>
    ''' <remarks></remarks>
    Private m_lastDateView As CurrentDateView


    ''' <summary>
    ''' Enthält die aktuell selektierte Zeile
    ''' </summary>
    ''' <remarks></remarks>
    Private m_selectedAttachment As Attachment

    Private m_selectedDocument As JournalDocument

    Private m_attachmentImporter As New AttachmentImporter

    ''' <summary>
    ''' Ruft das View an einer bestimmten Koordinate ab
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <param name="P"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetViewAt(ByVal Grid As GridControl, ByVal P As Point) As BaseView
        Dim I As Integer
        P = Grid.PointToClient(P)
        For I = Grid.Views.Count - 1 To 0 Step -1
            Dim View As BaseView = CType(Grid.Views(I), BaseView)
            If View.ViewRect.Contains(P) Then _
                Return View
        Next
        Return Nothing
    End Function


    Private Sub frmJournal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason <> CloseReason.UserClosing Then
            m_selectedAttachment = Nothing
            m_selectedDocument = Nothing
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        SaveSettings()


    End Sub                 'instance

    ''' <summary>
    ''' Sichert die Einstellungen des Journals
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveSettings()
        Try
            ' Formular-Position sichern 
            MainApplication.getInstance.Settings.SaveFormsPos(Me)

            ' Auswahl der Art des Dokumentes sichern (explorer-Liste)
            MainApplication.getInstance.Settings.SetSetting("LastSelectedDocType", "Journal", CStr(nbgGroupCommonDocs.SelectedLinkIndex), MainApplication.getInstance.CurrentUser.Key)

            ' Einschränkung des Datums (Radio-Buttons) sichern
            MainApplication.getInstance.Settings.SetSetting("JournalDateFilter", "Journal", m_lastDateView.ToString, MainApplication.getInstance.CurrentUser.Key)

            ' Einstellung des Grids sichern
            modmain.SaveGridStyles(grdJournalList, "Journal")

            ' zuletzt markierten Datensatz wieder holen 
            Dim j As JournalDocument = CType(grvDocuments.GetFocusedRow, JournalDocument)

            If j IsNot Nothing Then
                MainApplication.getInstance.Settings.SetSetting("LastSelectedDocNumber", "Journal", CStr(j.ID), MainApplication.getInstance.CurrentUser.Key)
            Else
                MainApplication.getInstance.Settings.SetSetting("LastSelectedDocNumber", "Journal", "0", MainApplication.getInstance.CurrentUser.Key)
            End If
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Ruft die Einstellungen des Journals wieder ab
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RestoreSettings()
        MainApplication.getInstance.log.WriteLog("Rette Einstellungen...")

        '1. Formulardaten wieder herstellen (Grösse und Position) 
        MainApplication.getInstance.Settings.RestoreFormsPos(Me)

        MainApplication.getInstance.log.WriteLog("Selektiere Gruppenauswahl...")

        '2. explorer-Links wieder herstellen
        nbgGroupCommonDocs.SelectedLinkIndex = CInt(MainApplication.getInstance.Settings.GetSetting("LastSelectedDocType", "Journal", "-1", MainApplication.getInstance.CurrentUser.Key))
        ' Den Filter auch setzen 
        If nbgGroupCommonDocs.SelectedLinkIndex <> -1 Then
            SetDocTypeFilter(CInt(nbgGroupCommonDocs.SelectedLink.Item.Tag))
        End If


        ' Benutzer-Definierter Datumsbereich setzen (Radio-Buttons) 
        Dim lastDateFilter As String = MainApplication.getInstance.Settings.GetSetting("JournalDateFilter", "Journal", CStr(CurrentDateView.All), MainApplication.getInstance.CurrentUser.Key)


        Dim datesetting As CurrentDateView = CType([Enum].Parse(GetType(CurrentDateView), lastDateFilter, True), CurrentDateView)

        cboJournalFilterView.SelectedItem = New JournalViewFilter(datesetting)

        modmain.RestoreGridStyles(grdJournalList, "Journal")


        Dim selecedID As Integer = CInt(MainApplication.getInstance.Settings.GetSetting("LastSelectedDocNumber", "Journal", "0", MainApplication.getInstance.CurrentUser.Key))

        MainApplication.getInstance.log.WriteLog("Suche zuletzt selektierten Eintrag aus  " & grdJournalList.DefaultView.RowCount & " Rows")

        'If grdJournalList.DefaultView.RowCount < 100 Then

        For a As Integer = 0 To grdJournalList.DefaultView.RowCount
            Dim o As Object = grdJournalList.DefaultView.GetRow(a)
            ' Journalobjekte
            Dim journalItem As JournalDocument = TryCast(o, JournalDocument)
            If journalItem IsNot Nothing Then
                If journalItem.ID = selecedID Then
                    CType(grdJournalList.MainView, GridView).SelectRow(a)
                    CType(grdJournalList.MainView, GridView).FocusedRowHandle = a
                    CType(grdJournalList.MainView, GridView).TopRowIndex = a

                    Exit For
                End If
            End If
        Next
        'Else
        'MainApplication.getInstance.Log.WriteLog("Zu viele Zeilen, Überspringe die Suche nach der Zeile, die zu selektieren ist")
        'grvDocuments.SelectRow(grvDocuments.RowCount - 1)  ' die letze Zeile selekiere
        'End If


        spcGridContainer.SplitterPosition = CInt(MainApplication.getInstance.Settings.GetSetting("JournalGridSplitterPosition", "UI", spcGridContainer.SplitterPosition.ToString))
        spcGridContainer.Collapsed = CBool(MainApplication.getInstance.Settings.GetSetting("JournalGridSplitterCollapsed", "UI", Boolean.FalseString))


    End Sub



    ''' <summary>
    ''' Ruft die Liste der Journaldokumente ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property JournalList As JournalDocuments
        Get
            Return m_journalList
        End Get
        Set(value As JournalDocuments)
            m_journalList = value
        End Set
    End Property

    Private Sub frmJournal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.DesignMode Then Exit Sub

        isloading = True
        lblCurrentFile.Text = ""
        MainApplication.getInstance.log.WriteLog("Erstelle neue Journal-Auflistung...")
        JournalList = DirectCast(MainApplication.getInstance.JournalDocuments.GetNewCollection, JournalDocuments)

        MainApplication.getInstance.log.WriteLog("Weise Auflistung der Tabelle zu...")

        grdJournalList.DataSource = JournalList
        FormatMasterTable()

        SetNavBartexts()


        cboJournalFilterView.Properties.Items.Clear()
        cboJournalFilterView.Properties.Items.Add(New JournalViewFilter(CurrentDateView.All))
        cboJournalFilterView.Properties.Items.Add(New JournalViewFilter(CurrentDateView.Day))
        cboJournalFilterView.Properties.Items.Add(New JournalViewFilter(CurrentDateView.Week))
        cboJournalFilterView.Properties.Items.Add(New JournalViewFilter(CurrentDateView.Month))
        cboJournalFilterView.Properties.Items.Add(New JournalViewFilter(CurrentDateView.Year))
        cboJournalFilterView.Properties.Items.Add(New JournalViewFilter(CurrentDateView.FirstQuarter))
        cboJournalFilterView.Properties.Items.Add(New JournalViewFilter(CurrentDateView.SecondQuarter))
        cboJournalFilterView.Properties.Items.Add(New JournalViewFilter(CurrentDateView.ThirdQuarter))
        cboJournalFilterView.Properties.Items.Add(New JournalViewFilter(CurrentDateView.FourthQuarter))

        txtJournalMemo.Properties.NullValuePrompt = GetText("NullPromptTextJournalMemo", "Notizen zum markierten Dokument")

        RestoreSettings()

        MainApplication.getInstance.log.WriteLog("Setze Überschriftenzeile")
        RefreshHeadline()

        ' Menüelement "Umbenennen"
        btnRenameNavBarItem.Text = GetText("Rename", "Umbenennen")

        MainApplication.getInstance.Languages.SetTextOnControl(Me)

        If ShowAllByAdressID <> -1 Then
            SetFilterAdressID(ShowAllByAdressID)
        End If
        isloading = False
    End Sub

    ''' <summary>
    ''' Setzt die texte der Navigationselemente
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetNavBartexts()
        For Each item As XtraNavBar.NavBarItemLink In nbgGroupCommonDocs.ItemLinks
            Dim visibleItem As XtraNavBar.NavBarItem = item.Item
            Dim id As Integer = CInt(visibleItem.Tag)
            visibleItem.Caption = JournalList.DocumentTypeNames.GetByDocumentID(id).Name
        Next
    End Sub

    ''' <summary>
    ''' Ruft die Laufende Nummer ab (ist nicht der Primärschlüssel)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SelectedDocumentID() As Integer
        Get
            If m_selectedDocument IsNot Nothing Then
                Return m_selectedDocument.DocumentID
            Else
                Return -1
            End If
        End Get
    End Property

    ''' <summary>
    ''' Ruft die eindeutige ReplikID des selektierten Objektes ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SelectedDocumentKey() As String
        Get
            If m_selectedDocument IsNot Nothing Then
                Return m_selectedDocument.ReplikID
            Else
                Return ""
            End If
        End Get
    End Property

    ''' <summary>
    ''' Ruft die Dokumenten-Nummer des selektierten Dokumentes ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SelectedDocumentType() As Integer
        Get
            If m_selectedDocument IsNot Nothing Then
                Return m_selectedDocument.DocumentType
            Else
                Return -1
            End If
        End Get

    End Property

    ''' <summary>
    ''' Ruft das gerade ausgewählte Dokument ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property SelectedDocument() As JournalDocument
        Get
            Return m_selectedDocument
        End Get
    End Property

    ''' <summary>
    ''' Setzt Formatierungstypen für die Haupt-Tabelle
    ''' </summary>
    ''' <remarks></remarks>
    Sub FormatMasterTable()


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grvDocuments.Columns
            If col.ColumnType.Name = GetType(Decimal).Name Then
                col.DisplayFormat.FormatString = "C"
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

            End If
        Next

    End Sub



    Sub FormatInnerGrid(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles grvAttachments.CustomDrawColumnHeader

        Dim imageedit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit = CType(grdJournalList.RepositoryItems("RepositoryItemPictureEdit"), DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit)
        imageedit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        If e.Column Is Nothing Then Exit Sub
        If e.Column.ColumnType.Name = GetType(Image).Name Then
            e.Column.ColumnEdit = imageedit

        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    ''' <summary>
    ''' Filtermethode
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FilterData()



    End Sub

    Private Sub grdJournalList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdJournalList.Click
        Dim grid As DevExpress.XtraGrid.GridControl = CType(sender, GridControl)

        Dim hi As GridHitInfo = CType(grid.MainView.CalcHitInfo(grid.PointToClient(MousePosition)), GridHitInfo)
        Dim view As GridView = CType(grid.MainView, GridView)
        ' Filterzeile toggeln
        If hi.HitTest = GridHitTest.ColumnButton Then

            view.OptionsView.ShowAutoFilterRow = Not view.OptionsView.ShowAutoFilterRow
        End If
    End Sub

    Private Sub GridControl1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdJournalList.DoubleClick


        OpenSelectedItem()


    End Sub

    ''' <summary>
    ''' Ruft das aktuell fokussierte Objekt aus dem focussiertem Grid ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFocussedObject() As Object
        Dim view As GridView = CType(grdJournalList.FocusedView, GridView)

        If view IsNot Nothing Then

            Dim o As Object = view.GetFocusedRow
            Return o
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Öffnet das aktuell selektierte Grid-Element
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenSelectedItem()

        SaveSettings()

        Dim item As Object = GetFocussedObject()
        If item IsNot Nothing Then
            If TypeOf item Is Attachment Then
                OpenAttachment(CType(item, Attachment))
            End If
            If TypeOf item Is JournalDocument Then
                m_selectedDocument = CType(item, JournalDocument)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' erstellt eine Kopie des gewählten Dokumentes
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DuplicateDocument()
        Dim view As GridView = CType(grdJournalList.FocusedView, GridView)

        Dim lstNewRows As New List(Of JournalDocument)

        Dim rowCount As Integer = view.GetSelectedRows.Length

        If rowCount > 0 Then
            Dim result As DialogResult = AskCopySelectedData(rowCount)
            If result = Windows.Forms.DialogResult.No Or result = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End If

        If view Is grvDocuments Then

            For Each rowID As Integer In view.GetSelectedRows

                Dim item As JournalDocument = CType(view.GetRow(rowID), JournalDocument)

                Dim selectedDocument As JournalDocument = CType(item, JournalDocument)
                Dim newClone As JournalDocument = CType(selectedDocument.Clone, JournalDocument)
                newClone.Save()
                JournalList.Add(newClone)
                lstNewRows.Add(newClone)
            Next

            grvDocuments.ActiveFilterCriteria = Nothing
            view.ClearSelection()
            Dim firstRowID As Integer?

            For Each item As Kernel.JournalDocument In lstNewRows
                Dim RowID As Integer
                RowID = FindRowID(item)

                If Not firstRowID.HasValue Then firstRowID = RowID

                view.SelectRow(RowID)
            Next

            view.MakeRowVisible(firstRowID.Value, False)

        End If

    End Sub

    ''' <summary>
    ''' Sucht aus dem sichtbaren Grid das Element mit der angegebenen NUmmer raus
    ''' </summary>
    ''' <param name="journalItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function FindRowID(ByVal journalItem As JournalDocument) As Integer
        For n As Integer = 0 To grvDocuments.RowCount - 1
            Dim rowItem As JournalDocument = CType(grvDocuments.GetRow(n), JournalDocument)
            If rowItem IsNot Nothing Then
                If rowItem.ID = journalItem.ID Then Return n
            End If

        Next
        Return -1
    End Function


    Sub selectionchangd(ByVal sender As Object, ByVal e As XtraGrid.ViewFocusEventArgs) Handles grdJournalList.FocusedViewChanged
        Debug.Print("FocusedView:" & e.View.Name)

        If e.View.Name = grvDocuments.Name Then
            ' dann wurde der Fokus auf ein Journaldoc gelegt => Keine Attachment Funktionen jetz! 
            m_selectedAttachment = Nothing
        End If

        If e.View.Name = grvAttachments.Name Then
            m_selectedDocument = Nothing
        End If

    End Sub



    Private Sub GridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvDocuments.Click
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = CType(grdJournalList.Views(0).CalcHitInfo(grdJournalList.PointToClient(MousePosition)), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)
        If hi.InRowCell Then
            If hi.Column.FieldName = "Checked" Then

                Dim document As JournalDocument = CType(grvDocuments.GetRow(hi.RowHandle), JournalDocument)
                document.Checked = Not document.Checked
                document.Plainsave()
            End If
        End If
    End Sub


    ''' <summary>
    ''' Merkt sich das aktuell selektierte Objekt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdFocusedRowChanged(ByVal sender As Object, ByVal e As FocusedRowChangedEventArgs) Handles grvAttachments.FocusedRowChanged, grvDocuments.FocusedRowChanged
        ' selected row merken, wichtig für Kontextmenü!

        Dim view As BaseView
        view = grdJournalList.FocusedView

        If view IsNot Nothing Then
            If view.Name = grvAttachments.Name Then

                m_selectedAttachment = CType(view.GetRow(e.FocusedRowHandle), Attachment)
            End If
        End If

        If view.Name = grvDocuments.Name Then

            If m_selectedDocument IsNot Nothing Then
                ' Dann ist hier noch das alte Dokument drinn: Memotext erkennen

                SetChangedMemoText(m_selectedDocument)

            End If

            m_selectedDocument = CType(view.GetRow(e.FocusedRowHandle), JournalDocument)
            If m_selectedDocument IsNot Nothing Then
                txtJournalMemo.EditValue = m_selectedDocument.MemoText
            End If

        End If

    End Sub

    ''' <summary>
    ''' Speichert das aktuelle Memo - Feld ab
    ''' </summary>
    ''' <param name="currentDoc">das zuletzt focussierte Dokument</param>
    ''' <remarks></remarks>
    Private Sub SetChangedMemoText(ByVal currentDoc As Kernel.JournalDocument)
        If m_selectedDocument IsNot Nothing & Not m_memoText.Equals(m_selectedDocument.MemoText) Then
            currentDoc.MemoText = m_memoText
            currentDoc.Plainsave()
        End If

    End Sub

    ''' <summary>
    ''' Holt die letzte ID einer Rechnung, nur diese kann gelöscht werden
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetLastInsuraceID(ByVal documentType As enumJournalDocumentType) As Integer

        Dim sql As String = "Select MAX(ID) from JournalListe where Status=" & documentType

        Try
            Dim result As Object = MainApplication.getInstance.Database.ExcecuteScalar(sql)

            If result IsNot Nothing AndAlso Not TypeOf result Is DBNull Then
                m_maxInsuranceID = CInt(result)
            Else
                m_maxInsuranceID = 0
            End If
        Catch
        End Try

        Return m_maxInsuranceID

    End Function

    Private Sub SetImageEditOnGrid2(ByVal sender As Object, ByVal e As EventArgs)
        Dim imageedit As XtraEditors.Repository.RepositoryItemPictureEdit = CType(grdJournalList.RepositoryItems("RepositoryItemPictureEdit"), DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit)
        imageedit.SizeMode = XtraEditors.Controls.PictureSizeMode.Squeeze

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grvAttachments.Columns
            If col.ColumnType.Name = GetType(Image).Name Then
                col.ColumnEdit = imageedit

            End If
        Next
    End Sub

    Private Sub grdJournalList_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdJournalList.DragDrop
        Try

            Dim fileList As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = CType(grdJournalList.Views(0).CalcHitInfo(grdJournalList.PointToClient(MousePosition)), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)

            If hi.HitTest <> GridHitTest.ColumnEdge AndAlso hi.HitTest <> GridHitTest.Column Then
                If hi.RowHandle >= 0 Then


                    Dim currentDocument As Kernel.JournalDocument = CType(grdJournalList.DefaultView.GetRow(hi.RowHandle), Kernel.JournalDocument)
                    Debug.Print("Do DragDrop with DocNumber:" & currentDocument.DocumentID)

                    m_selectedDocument = currentDocument

                    Me.Activate() ' in the case Explorer overlaps this form
                    Me.Refresh()


                    'Dateien übertragen
                    m_attachmentImporter.StartCopyFiles(fileList, m_selectedDocument)
                    grdJournalList.RefreshDataSource()

                End If
            End If


        Catch ex As Exception

            Trace.WriteLine("Error in DragDrop function: " + ex.Message)
        End Try

    End Sub





    Private Sub grdJournalList_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdJournalList.DragEnter

        Debug.Print("Drag&Drop_entered")
        Dim p As Point = grdJournalList.PointToClient(MousePosition)

        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
            Exit Sub
        End If

        ' Nur auf Journaleinträge faöllen lassen 

        Dim viewOnMouse As GridView = CType(GetViewAt(grdJournalList, p), GridView)
        If viewOnMouse Is Nothing Then Exit Sub
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = CType(viewOnMouse.CalcHitInfo(p), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)

        If hi.InRow Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If


    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        m_selectedDocument = Nothing
        Me.Close()
    End Sub

    Private Sub mnuOpenDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenDocument.Click
        OpenSelectedItem()
    End Sub



    Private Sub mnuAttachmentSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAttachmentSaveAs.Click

        If m_selectedAttachment IsNot Nothing Then
            SaveAttachementAs(m_selectedAttachment)
        End If
    End Sub

    Private Sub ContextMenuLstView_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuLstView.Opening
        Dim view As GridView = CType(grdJournalList.FocusedView, GridView)

        If view Is grvDocuments Then



            ' dann Menüs für Dokuemnte einblenden 
            m_selectedDocument = CType(view.GetFocusedRow, JournalDocument)

            mnuAttachmentSaveAs.Visible = False
            mnuDeleteAttachmentItem.Visible = False ' Kann keine Journaldokumente Löschen!

            mnuCreateNewDocument.Enabled = True
            mnuDeletedocument.Visible = True
            mnuTagged.Visible = True
            btnCreateSummarizedInvoice.Visible = True

            If m_selectedDocument IsNot Nothing Then
                mnuTagged.Enabled = True
                mnuTagged.Checked = m_selectedDocument.Tagged
                mnuDuplicate.Enabled = True
                mnuOpenDocument.Enabled = True
                btnDelete.Enabled = True
                mnuAddAttachment.Enabled = True

                btnCreateSummarizedInvoice.Enabled = CreateSummarizedInvoiceAllowed()

                If view.SelectedRowsCount > 1 Then
                    mnuDeletedocument.Visible = False
                    mnuOpenDocument.Enabled = False
                    mnuTagged.Visible = False
                    mnuAddAttachment.Enabled = False
                    mnuUndeleteDocument.Visible = False

                Else
                    mnuDeletedocument.Enabled = True
                    mnuOpenDocument.Enabled = True
                    mnuTagged.Visible = True
                    mnuAddAttachment.Enabled = True

                    ' genau 1 Dokument , nun schauen, ob man es wiederherstellen oder löschen kann
                    mnuUndeleteDocument.Visible = m_selectedDocument.IsCanceled
                    mnuDeletedocument.Visible = Not m_selectedDocument.IsCanceled
                End If

            Else
                btnDelete.Enabled = False
                mnuAddAttachment.Enabled = False
                mnuTagged.Enabled = False
                mnuDuplicate.Enabled = False
                mnuOpenDocument.Enabled = False
            End If

        Else ' Dann war der Anhang sichtbar
            mnuTagged.Visible = False

            m_selectedAttachment = CType(view.GetFocusedRow, Attachment)
            ' dann Menüs für Attachmenbt einblenden 

            mnuAttachmentSaveAs.Visible = True
            mnuDeleteAttachmentItem.Visible = True ' Kann keine Journaldokumente Löschen!

            mnuDeletedocument.Visible = False
            btnCreateSummarizedInvoice.Visible = False
        End If



    End Sub

    ''' <summary>
    ''' Prüft alle selektierten Dokumente und prüft, ob eine Sammelrechnung erstellt werden kann
    ''' </summary>
    ''' <returns>Falls in der Auflistung nur ein Dokument bereits eine Sammelrecnung existiert, wird False zurückgegeben</returns>
    ''' <remarks></remarks>
    Private Function CreateSummarizedInvoiceAllowed() As Boolean
        Dim addressId As Integer = -1

        For Each rowID As Integer In grvDocuments.GetSelectedRows ' Selektierte Dokumente erstellen
            Dim document As JournalDocument = CType(grvDocuments.GetRow(rowID), JournalDocument)
            If document.HasInvoiceReference Then Return False

            ' Nicht bei unterschiedlichen Adressen !
            If document.Address IsNot Nothing Then
                If addressId = -1 Then ' Noch nie zugewiesen; Leere Adressen sind erlaubt
                    addressId = document.Address.ID
                End If

                If addressId <> document.Address.ID Then Return False ' Abweichende Adressen sind nicht erlaubt

            End If

        Next
        Return True
    End Function

    Private Sub NavBarControl1_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles nvbDocuments.LinkClicked
        ' filter einsetzen
        SetDocTypeFilter(CInt(e.Link.Item.Tag))

        RefreshHeadline()
    End Sub

    Private Sub SetDocTypeFilter(ByVal filterID As Integer)

        MainApplication.getInstance.log.WriteLog("Setzte TypeDoc Filter" & filterID)

        If JournalList IsNot Nothing Then
            If filterID > -1 Then
                JournalList.Filter = Filtering.CriteriaOperator.Parse("DocumentType=" & filterID)
            Else
                JournalList.Filter = Nothing
            End If
        End If

    End Sub

    ''' <summary>
    ''' Aktualisiert die Datenquelle
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Reload()
        MainApplication.getInstance.AttachmentRelations.Reload()
        grvDocuments.RefreshData()
        ' Ich könnte ja einen artikl in der Ansicht haben... der würde ebenfalls überschrieben werden !


    End Sub


    Private Sub RefreshHeadline()
        RefreshHeadlineInternal()
    End Sub

    ''' <summary>
    ''' Erzeugt die Überschrift mit den Summen der aktuellen Ansicht
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefreshHeadlineInternal()
        Dim totalSum As Decimal
        Dim selectedTotalSum As Decimal

        'lblJournalSelectedTotalSum

        If nbgGroupCommonDocs.SelectedLinkIndex = -1 Or nbgGroupCommonDocs.SelectedLinkIndex = 0 Then ' war "ALLE" oder keins angeklickt
            'TODO: NLS
            lblJournalHeadline.Text = "Alle Dokumente" & " (" & JournalList.Count & ") "

            ' Summe macht kein Sinn, da alle Dokumenetntypen durcheinander sind
            lblJournalTotalSumValue.Text = "--"

        Else
            lblJournalHeadline.Text = "" & nbgGroupCommonDocs.SelectedLink.Caption & " (" & grvDocuments.RowCount & ") "

            ' Summe berechnen, wenn die Liste Homogen ist
            For rownum As Integer = 0 To grvDocuments.RowCount - 1
                Dim document As Kernel.JournalDocument = DirectCast(grvDocuments.GetRow(rownum), Kernel.JournalDocument)
                If document IsNot Nothing Then
                    If Not document.IsCanceled Then
                        totalSum += document.DisplayedEndPrice

                    End If
                End If
            Next

            lblJournalTotalSumValue.Text = totalSum.ToString("c2")

        End If


        ' Summe der Selektierten Einträge berechnen - das geht auch, wenn unterschiedliche Dokumententypen angegeben sind
        For Each rownum As Integer In grvDocuments.GetSelectedRows
            Dim document As Kernel.JournalDocument = DirectCast(grvDocuments.GetRow(rownum), Kernel.JournalDocument)
            If document IsNot Nothing Then
                ' Hier auch die Stornos mitzählen
                selectedTotalSum += document.DisplayedEndPrice
            End If
        Next
        lblJournalSelectedTotalSumValue.Text = selectedTotalSum.ToString("c2")


    End Sub


    Private Sub mnuDeleteAttachmentItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDeleteAttachmentItem.Click
        ' löscht das angegebene Item auif Nachfrage
        ' Kann keine Dokuemnet Löschen
        Try
            If m_selectedAttachment IsNot Nothing Then
                DeleteSelectedAttachments()
            End If
        Catch
        End Try
    End Sub


    Private Sub DeleteSelectedAttachments()
        '1. aktives View holen, 
        ' 2. Alle selektierten entfernen

        Dim view As GridView = CType(grdJournalList.FocusedView, Views.Grid.GridView)

        Dim attachmentsToDelete As New List(Of Attachment)

        For Each rowID As Integer In view.GetSelectedRows
            Dim attachmentItem As Attachment = CType(view.GetRow(rowID), Attachment)
            attachmentsToDelete.Add(attachmentItem)
        Next

        Dim parentArticle As JournalDocument
        parentArticle = CType(CType(view.ParentView, GridView).GetFocusedRow, JournalDocument)

        For Each item As Attachment In attachmentsToDelete

            MainApplication.getInstance.AttachmentRelations.Remove(parentArticle.Key, item)
        Next

        view.DeleteSelectedRows()
        grdJournalList.RefreshDataSource()
        view.RefreshData()


    End Sub

    Private m_showDistinctAdress As Integer
    Private m_CustomFilterAdress As Integer = -1

    Property ShowAllByAdressID As Integer
        Get
            Return m_CustomFilterAdress
        End Get
        Set(ByVal value As Integer)
            m_CustomFilterAdress = value
        End Set
    End Property

    ''' <summary>
    ''' Setzt vor dem öffnen des Dialoges eine AdressId, löscht alle bisherigen Filter
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetFilterAdressID(ByVal addressID As Integer)
        MainApplication.getInstance.log.WriteLog("Setze Adressen-Filter auf die Adresse mit der ID:" & addressID)
        grvDocuments.ClearColumnsFilter()

        ' Item kann wohl nur per Index festgelegt werden
        nbgGroupCommonDocs.SelectedLinkIndex = 0
        'jetzt noch nach der Adressnummer rausfiltern

        grvDocuments.ActiveFilterCriteria = Nothing
        grvDocuments.ActiveFilterEnabled = False
        JournalList.Filter = Filtering.CriteriaOperator.Parse("AddressNumber=" & addressID)

    End Sub


    Private Sub grdJournalList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdJournalList.KeyDown

        If e.KeyCode = Keys.Return Then
            OpenSelectedItem()
        End If
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        OpenSelectedItem()
        Me.Close() ' es wurde hoffentlich ein Dokuent vorher angeklickt

    End Sub

    ''' <summary>
    ''' Stellt das einfache druck-Fenster für Journal bereit
    ''' </summary>
    ''' <remarks></remarks>
    Private m_simplePrintDialog As SimpleGridPrinting

    Private ReadOnly Property SimpleGridPrinting As SimpleGridPrinting
        Get

        End Get
    End Property

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim GridPrinting As SimpleGridPrinting = SimpleGridPrinting.GetSimpleGridPrinting
        GridPrinting.GridToPrint = grdJournalList
        GridPrinting.Headline = "Journal"

        GridPrinting.ShowPreviewDialog()

    End Sub

    Private m_ignoreFilterSetting As Boolean

    Private Sub grvDocuments_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grvDocuments.ColumnFilterChanged
        ' sobald irgend ein Filter gewechselt hat, alle neu Durchrechnen
        ' Anzahl und Summe berechnen

        If String.IsNullOrEmpty(grvDocuments.ActiveFilterString) Then
            m_ignoreFilterSetting = True
            cboJournalFilterView.SelectedIndex = 0
            m_ignoreFilterSetting = False

        End If

        RefreshHeadline()
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

                grvDocuments.RefreshRow(PrevHotTrackRow)
                grvDocuments.RefreshRow(HotTrackRowValue)


            End If
        End Set
    End Property

    Private Sub grvDocuments_MouseMove(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles grvDocuments.MouseMove
        Dim View As GridView = CType(sender, GridView)
        With View.CalcHitInfo(New Point(e.X, e.Y))
            If .InRowCell Then
                HotTrackRow = .RowHandle
            Else
                HotTrackRow = GridControl.InvalidRowHandle
            End If
        End With
    End Sub

    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles grvDocuments.RowCellStyle
        If e.RowHandle = HotTrackRow Then
            e.Appearance.BackColor = Color.PaleGoldenrod
        End If
    End Sub

    Private Sub grdJournalList_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdJournalList.DragOver

        Dim View As GridView = CType(grdJournalList.GetViewAt(grdJournalList.PointToClient(New Point(e.X, e.Y))), GridView)

        If View IsNot Nothing Then
            With View.CalcHitInfo(grdJournalList.PointToClient(New Point(e.X, e.Y)))
                If .InRowCell Then
                    HotTrackRow = .RowHandle
                Else
                    HotTrackRow = GridControl.InvalidRowHandle
                End If
            End With
        End If

    End Sub


    Private Sub mnuAddAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddAttachment.Click


        Dim fileList() As String
        Dim fod As New Vista_Api.OpenFileDialog
        fod.Multiselect = True
        If fod.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fileList = fod.FileNames

            m_attachmentImporter.StartCopyFiles(fileList, m_selectedDocument)
            grdJournalList.RefreshDataSource()

        End If
    End Sub

    Private Sub radQuarterView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetFilter(CurrentDateView.ThisQuarter)

    End Sub

    Private Sub SetFilter(ByVal dateview As CurrentDateView)

        m_lastDateView = dateview

        Dim FromDate As DateTime
        Dim ToDate As DateTime

        Select Case dateview
            Case CurrentDateView.Day
                FromDate = Today.Date
                ToDate = Today.Date

            Case CurrentDateView.Week ' Den Montag ermitteln ? 
                ' letzten Monat ermitteln


                FromDate = Today.AddDays(-7)
                ToDate = Today.Date

            Case CurrentDateView.Month
                FromDate = New Date(Today.Year, Today.Month, 1)
                ToDate = FromDate.AddMonths(1).AddDays(-1)

            Case CurrentDateView.ThisQuarter
                Dim activeQuarter As Integer = (Today.Month \ 4)
                If activeQuarter = 0 Then activeQuarter = 1

                FromDate = New Date(Today.Year, (activeQuarter - 1) * 3 + 1, 1)
                ToDate = FromDate.AddMonths(3).AddDays(-1)

            Case CurrentDateView.FirstQuarter
                FromDate = New Date(Today.Year, 1, 1)
                ToDate = New Date(Today.Year, 4, 1).AddDays(-1)

            Case CurrentDateView.SecondQuarter
                FromDate = New Date(Today.Year, 4, 1)
                ToDate = New Date(Today.Year, 7, 1).AddDays(-1)


            Case CurrentDateView.ThirdQuarter
                FromDate = New Date(Today.Year, 7, 1)
                ToDate = New Date(Today.Year, 10, 1).AddDays(-1)


            Case CurrentDateView.FourthQuarter
                FromDate = New Date(Today.Year, 10, 1)
                ToDate = New Date(Today.Year, 12, 31)

            Case CurrentDateView.Year
                FromDate = New Date(Today.Year, 1, 1)
                ToDate = New Date(Today.Year, 12, 31)

            Case CurrentDateView.All
                FromDate = Date.MinValue
                ToDate = Date.MaxValue
        End Select


        Dim BinaryFilter As CriteriaOperator
        Dim FilterString, FilterDisplayText As String
        Dim DateFilter As ColumnFilterInfo

        BinaryFilter = New GroupOperator(GroupOperatorType.And,
            New BinaryOperator("DocumentDate", FromDate, BinaryOperatorType.GreaterOrEqual),
            New BinaryOperator("DocumentDate", ToDate, BinaryOperatorType.LessOrEqual))
        FilterString = BinaryFilter.ToString()
        FilterDisplayText = String.Format("Datum zwischen {0:d} und {1:d}", FromDate, ToDate)
        DateFilter = New ColumnFilterInfo(FilterString, FilterDisplayText)


        grvDocuments.Columns("DocumentDate").FilterInfo = DateFilter
        RefreshHeadline()

    End Sub

    ''' <summary>
    ''' Holt von heute aus gesehen den letzen Montag ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetLastMonday() As Date

        Dim daydiff As Integer = 1 - (Date.Today.DayOfWeek)

        Return Date.Today.AddDays(daydiff)
    End Function



    Private Sub GridView1_CustomColumnSort(ByVal sender As System.Object, ByVal e As CustomColumnSortEventArgs) Handles grvDocuments.CustomColumnSort
        Try
            If e.Column.FieldName = "DocumentDisplayID" Then
                e.Handled = True

                Dim journalDoc1 As Kernel.JournalDocument = CType(e.RowObject1, Kernel.JournalDocument)
                Dim journalDoc2 As Kernel.JournalDocument = CType(e.RowObject2, Kernel.JournalDocument)


                If journalDoc1.DocumentID > journalDoc2.DocumentID Then
                    e.Result = 1
                Else
                    e.Result = -1
                End If
            End If

        Catch ex As Exception
            Debug.Print("Ausnahme bei frmJournal.CustomColumnSort: " & ex.Message)
        End Try

    End Sub

    Private Sub GridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvAttachments.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeleteSelectedAttachments()
        End If
    End Sub

    Private Sub GridView2_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles grvAttachments.MouseDown
        Dim view As GridView = CType(sender, GridView)
        downHitInfo = Nothing

        Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Control.ModifierKeys <> Keys.None Then Exit Sub
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
                If hitInfo.InRow Then
                    Dim o As ClausSoftware.Kernel.Attachment = CType(view.GetRow(hitInfo.RowHandle), Kernel.Attachment)
                    If o IsNot Nothing Then
                        Dim filename As String = o.GetFile

                        ' hier die Dateien auslösen
                        DoDragDrop(New DataObject(DataFormats.FileDrop, New String() {filename}), DragDropEffects.Copy)
                    End If
                End If
                downHitInfo = Nothing
            End If
        End If
    End Sub

    ''' <summary>
    ''' Löscht das markierte Element nach Rückfrage
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteSelectedDocument()
        ' Das letzte Dokument eines Typs darf gelöscht werden. 
        '  andere Dokumente (Rechnungen) müssen storniert weren

        ' Angebote Stornieren ? 

        If grdJournalList.FocusedView Is grvDocuments Then
            ' dann nach Rückfrage und Dokument löschen 
            Dim selectedItem As Kernel.JournalDocument = CType(grvDocuments.GetFocusedRow, JournalDocument)
            If selectedItem IsNot Nothing Then

                If MainApplication.getInstance.CurrentUser.AllowDelete(Kernel.Security.PermissionModules.JournalDocuments) Then
                    If AskCancelDocument("") = Windows.Forms.DialogResult.Yes Then

                        If MainApplication.getInstance.PeriodicCheckConnection(True) Then
                            'If MainApplication.getInstance.JournalDocuments.GetMaxID(selectedItem.DocumentType) = selectedItem.DocumentID Then
                            '    ' Den letzten Eintrag kann man löschen; 
                            '    ' bestehende nicht. 
                            '    selectedItem.Delete()

                            'Else

                            selectedItem.SetCanceled()
                            selectedItem.Save()
                            RefreshHeadline()
                            'End If
                        End If

                    End If
                End If

            End If
        End If

    End Sub

    ''' <summary>
    ''' druckt die selektierten Dokument direkt aus
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrintselectedDocuments()
        Dim view As GridView = CType(grdJournalList.FocusedView, GridView)

        If view Is grvDocuments Then
            Dim lstToPrint As New List(Of Kernel.JournalDocument)

            For Each rowID As Integer In view.GetSelectedRows
                lstToPrint.Add(CType(view.GetRow(rowID), Kernel.JournalDocument))

            Next

            If lstToPrint.Count > 5 Then

                Dim result As DialogResult = MessageBox.Show("Möchten Sie diese " & lstToPrint.Count & " Dokumente drucken?", "Dokumente drucken", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If DialogResult = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            Dim printLayouts As New List(Of Kernel.Printing.Report)

            Dim reports As New Kernel.Printing.Reports(MainApplication.getInstance)
            reports.SetDataType(Kernel.DataSourceList.Journaldocument)

            For Each item As Kernel.Printing.Report In reports
                If item.IsDefault Then
                    printLayouts.Add(item)
                End If

            Next

            ' Alle der rfeihe nach zum Drucker senden 
            For Each item As Kernel.JournalDocument In lstToPrint
                Dim lst As New List(Of Kernel.JournalDocument)
                lst.Add(item)
                m_mainui.PrintReportsDirect(lst, Kernel.DataSourceList.Journaldocument, printLayouts)
            Next

        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteSelectedDocument()
    End Sub


    Private Sub mnuCreateNewDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCreateNewDocument.Click
        CreateNewDocument()
    End Sub

    ''' <summary>
    ''' Ruft den aktuell verwendten Dokumententyp ab, der im Journalfilter angegeben ist
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentFilteredDocumentType As enumJournalDocumentType
        Get
            Return CType(CInt(nvbDocuments.SelectedLink.Item.Tag), enumJournalDocumentType)
        End Get
    End Property

    ''' <summary>
    ''' Legt ein neues Dokument vom aktuellen Typ an
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateNewDocument()

        If CurrentFilteredDocumentType <> enumJournalDocumentType.ALL Then
            Dim newJournalDoc As Kernel.JournalDocument = JournalList.GetNewItem(CurrentFilteredDocumentType)
            newJournalDoc.Save()
            JournalList.Add(newJournalDoc)
            JournalList.Reload()

            grvDocuments.RefreshData()
        End If

    End Sub

    Private Sub mnuDeletedocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeletedocument.Click
        DeleteSelectedDocument()

    End Sub

    Private Sub SearchPanel_SearchTextChanged(ByVal sender As Object, ByVal e As SearchTextEventArgs) Handles SearchPanel.SearchTextChanged
        ' Such-Criteria bauen
        ' Grid-Filter entfernen, 
        ' Suche durchführen
        Try
            If String.IsNullOrEmpty(e.Text) Then
                JournalList.Filter = Nothing
                Exit Sub
            End If

            Dim SearchText As String

            SearchText = e.Text.Trim

            Dim DisplayIDCriteria As CriteriaOperator = New Filtering.BinaryOperator("DocumentDisplayID", "%" & SearchText & "%", BinaryOperatorType.Like)
            Dim AdressCriteria As CriteriaOperator = New Filtering.BinaryOperator("AddressWindow", "%" & SearchText & "%", BinaryOperatorType.Like)
            Dim DocTypeCriteria As CriteriaOperator = New BinaryOperator("DocumentType", CInt(nbgGroupCommonDocs.SelectedLink.Item.Tag), BinaryOperatorType.Equal)

            If CInt(nbgGroupCommonDocs.SelectedLink.Item.Tag) <> 0 Then ' bei "0" ist der Type egal
                JournalList.Filter = CriteriaOperator.And(DocTypeCriteria, CriteriaOperator.Or(DisplayIDCriteria, AdressCriteria))
            Else
                JournalList.Filter = CriteriaOperator.Or(DisplayIDCriteria, AdressCriteria)
            End If

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Journal", "Fehler beim SearchtextChanged")
        End Try


    End Sub

    Private Sub mnuDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDuplicate.Click
        DuplicateDocument()
    End Sub

    Public Sub New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub
    Private m_mainui As MainUI

    ''' <summary>
    ''' Erstellt ein neues Journal mit der MainUI
    ''' </summary>
    ''' <param name="mainUI"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal mainUI As MainUI)

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        m_mainui = mainUI
    End Sub

    Private Sub SearchPanel_SetNextControl(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchPanel.SetNextControl
        ' Focus verschieben
        grdJournalList.Focus()
    End Sub

    Private Sub cboJournalFilterView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboJournalFilterView.SelectedIndexChanged
        If m_ignoreFilterSetting Then Exit Sub
        If cboJournalFilterView.SelectedIndex = 0 Then
            grvDocuments.ActiveFilter.Clear()
            Exit Sub
        End If

        Dim newViewFilter As JournalViewFilter = CType(cboJournalFilterView.SelectedItem, JournalViewFilter)
        SetFilter(newViewFilter.ViewKind)

    End Sub

    ''' <summary>
    ''' Wechselt das Tag des selektierten Dokumentes.  Speichert das Element unmittelbar ab
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ToggleTag()
        Dim item As Object = GetFocussedObject()
        If item IsNot Nothing Then

            If TypeOf item Is ClausSoftware.Kernel.JournalDocument Then

                CType(item, ClausSoftware.Kernel.JournalDocument).Tagged = Not CType(item, ClausSoftware.Kernel.JournalDocument).Tagged
                CType(item, ClausSoftware.Kernel.JournalDocument).Plainsave()

            End If
        End If
    End Sub

    Private Sub mnuTagged_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTagged.Click
        ToggleTag()
    End Sub

    Private Sub grvDocuments_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grvDocuments.CustomDrawCell
        If e.Column.Name = colTagged.Name Then

            Dim view As GridView = CType(sender, GridView)
            Dim item As Object = view.GetRow(e.RowHandle)
            If TypeOf item Is Kernel.JournalDocument Then

                Dim c As GridCellInfo = CType(e.Cell, GridCellInfo)
                Dim x, y As Integer
                x = CInt(c.Bounds.X + (c.Bounds.Width / 2) - 8)
                y = CInt(c.Bounds.Y + (c.Bounds.Height / 2) - 8)

                If CType(item, Kernel.JournalDocument).Tagged Then

                    e.Graphics.DrawIcon(System.Drawing.Icon.FromHandle(My.Resources.PushPin_16x16.GetHicon), x, y)
                    e.Handled = True
                Else
                    ' nichts ? 
                    e.Handled = True

                End If
            End If


        End If
    End Sub

    Private Sub grvDocuments_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles grvDocuments.CustomDrawColumnHeader
        'If e.Column IsNot Nothing Then
        '    If e.Column.Name = colTagged.Name Then
        '        Dim x, y As Integer
        '        ' Bildmitt berechnen, davon obere linke ecke des Icons

        '        e.Graphics.DrawIcon(System.Drawing.Icon.FromHandle(My.Resources.PushPin_16x16.GetHicon), x, y)
        '        e.Handled = True
        '    End If
        'End If

    End Sub


    Private Sub frmJournal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.SearchPanel.Focus()
    End Sub

    Private Sub spcGridContainer_SplitGroupPanelCollapsed(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.SplitGroupPanelCollapsedEventArgs) Handles spcGridContainer.SplitGroupPanelCollapsed
        If Not isloading Then
            MainApplication.getInstance.Settings.SetSetting("JournalGridSplitterCollapsed", "UI", e.Collapsed.ToString)
        End If
    End Sub

    Private Sub spcGridContainer_SplitterMoved(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spcGridContainer.SplitterMoved
        If Not isloading Then
            MainApplication.getInstance.Settings.SetSetting("JournalGridSplitterPosition", "UI", spcGridContainer.SplitterPosition.ToString)
        End If
    End Sub

    Private Sub txtJournalMemo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJournalMemo.EditValueChanged

        m_memoText = CStr(txtJournalMemo.EditValue)

    End Sub


    Private Sub mnuPrintDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPrintDocument.Click
        PrintselectedDocuments()
    End Sub

    Private Sub grvDocuments_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grvDocuments.RowStyle
        Dim journalDocumentItem As Kernel.JournalDocument = CType(grvDocuments.GetRow(e.RowHandle), Kernel.JournalDocument)

        If journalDocumentItem IsNot Nothing Then
            If journalDocumentItem.IsCanceled Then
                e.Appearance.Font = New Font(e.Appearance.Font, e.Appearance.Font.Style Or FontStyle.Strikeout)
                e.Appearance.ForeColor = Color.LightGray
            Else
                '  e.Appearance.Font = New Font(e.Appearance.Font, e.Appearance.Font.Style Xor FontStyle.Strikeout)
                '  e.Appearance.ForeColor = Color.Black

            End If
        End If

    End Sub

    Private Sub btnUndeleteDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUndeleteDocument.Click
        UndeleteDocument()
    End Sub

    ''' <summary>
    ''' Setzt den 'storno' - Zustand des Foccussierten Elementes wieder zurück
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UndeleteDocument()
        Dim item As Object = GetFocussedObject()

        If TypeOf item Is Kernel.JournalDocument Then
            Dim jDoc As Kernel.JournalDocument = CType(item, Kernel.JournalDocument)
            If jDoc.IsCanceled Then

                jDoc.ClearCanceled()
                jDoc.Save()
                RefreshHeadline()
            End If
        End If

    End Sub

    Private Sub txtJournalMemo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJournalMemo.Leave
        SetChangedMemoText(m_selectedDocument)
    End Sub

    Private Sub grvDocuments_MasterRowGetRelationCount(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles grvDocuments.MasterRowGetRelationCount
        e.RelationCount = 1
    End Sub

    Private Sub grvDocuments_MasterRowGetRelationName(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles grvDocuments.MasterRowGetRelationName
        e.RelationName = GetText("headlineAttachments", "Datei Anhänge")
    End Sub

    Private Sub grvDocuments_MasterRowGetLevelDefaultView(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles grvDocuments.MasterRowGetLevelDefaultView
        e.DefaultView = grvAttachments
    End Sub

    Private Sub grvDocuments_MasterRowGetChildList(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles grvDocuments.MasterRowGetChildList
        Dim docItem As Kernel.JournalDocument = CType(grvDocuments.GetRow(e.RowHandle), Kernel.JournalDocument)

        e.ChildList = docItem.Attachments

    End Sub

    Private Sub grvDocuments_MasterRowEmpty(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles grvDocuments.MasterRowEmpty
        If Not Me.isloading Then
            Dim docItem As Kernel.JournalDocument = CType(grvDocuments.GetRow(e.RowHandle), Kernel.JournalDocument)
            If docItem IsNot Nothing Then
                e.IsEmpty = Not docItem.HasAttachment

            End If
        Else
            e.IsEmpty = False
        End If

    End Sub

    Private Sub btnCreateSummarizedInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateSummarizedInvoice.Click
        CreateSummarizedInvoice()

    End Sub

    ''' <summary>
    ''' Erstellt aus allen markierten Elementen eine neue Sammelrechnung
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateSummarizedInvoice()
        ' Nur die markierten Teile einsammeln 
        ' Nur "Aufträge" (Lieferscheine) 
        ' Nur von Dokumenten, die nicht bereits als Sammelrechnung aufgenommen wurden

        Dim documentsList As New List(Of JournalDocument)
        For Each rowID As Integer In grvDocuments.GetSelectedRows ' Selektierte Dokumente erstellen
            Dim selectedDocument As JournalDocument = CType(grvDocuments.GetRow(rowID), JournalDocument)
            If Not selectedDocument.HasInvoiceReference Then
                documentsList.Add(selectedDocument)
            End If

        Next
        ' Im Journaldocuments - auflistung bauen lassen 
        ' Zum testen: Angebote
        Dim targetType As JournalDocumentType = JournalList.DocumentTypeNames.GetByDocumentID(enumJournalDocumentType.Rechnung)

        Dim summarizeddocument As JournalDocument = Nothing
        ' Nun das Dokument bauen
        Try
            summarizeddocument = JournalList.CreateSummarizedDocument(documentsList, targetType)

        Catch ex As NotEqualAddressesException

            MessageBox.Show(GetText("DocumentsMustHaveSameAddress", "Die Aufstellung muss von der selben Empfänger sein!"), GetText("DocumentsAreNotOfSameType", "Aufstellung nicht einheitlich"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        Catch ex As DocumentHasAlreadyASummaryInvoice
            MessageBox.Show(GetText("", "Das Dokument " & vbCrLf & "{0}" & vbCrLf & " wurde bereits als Sammelrechnung aufgenommen", ex.Document.DocumentTypeText),
                            GetText("DocumentAlreadyHasCollectiveInvoice", "es existiert bereits eine Sammelrechnung"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        Catch ex As NotEqualDocumentTypesException

            MessageBox.Show(GetText("DocumentsAreNotOfSameDocumentType", "Die Aufstellung muss von der selben Dokumenten-Typ sein!"), GetText("DocumentsAreNotOfSameType", "Aufstellung nicht einheitlich"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "Journaldocument", "Fehler beim Erstellen der Sammelrechnung")
            Exit Sub
        End Try

        If summarizeddocument IsNot Nothing Then

            ' Das Teil nun öffnen

            m_selectedDocument = summarizeddocument
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        Else
            ' Fehlermeldung ausgeben
        End If
    End Sub

    Private Sub btnRenameNavBarItem_Click(sender As System.Object, e As System.EventArgs) Handles btnRenameNavBarItem.Click
        RenameSelectedNavBarItem()
    End Sub

    ''' <summary>
    ''' Ermöglicht es, das selektierte Navigationselement (KournalTyp) umzubenennen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RenameSelectedNavBarItem()

        Dim nv As XtraNavBar.NavBarItem
        Dim lnk As XtraNavBar.NavBarItemLink = nvbDocuments.Groups(0).SelectedLink
        If lnk IsNot Nothing Then
            nv = lnk.Item


            Dim newName As String
            'TODo: NLS
            newName = InputBox("Geben sie einen neuen Namen für den Dokumententyp ein", "Namen ändern", nv.Caption)
            If Not String.IsNullOrEmpty(newName) Then
                ' Hier zuweisen !
                Dim docType As JournalDocumentType = JournalList.DocumentTypeNames(CInt(nv.Tag))
                docType.Name = newName.Trim
                docType.Save()
                SetNavBartexts()
            End If
        End If
    End Sub


    ''' <summary>
    ''' Bei rechter Maustaste das Navigationselement auch selektieren
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub nvbDocuments_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles nvbDocuments.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hi As XtraNavBar.NavBarHitInfo = nvbDocuments.CalcHitInfo(e.Location)
            If hi.InLink Then
                hi.Link.Group.SelectedLink = hi.Link
            End If
        End If
    End Sub

    ''' <summary>
    ''' Hat einen Verweis auf ein Sammelrechnungs-Symbol
    ''' </summary>
    ''' <remarks></remarks>
    Private m_hasInvoiceLinkImage As Image = My.Resources.Redo

    Private Sub grvDocuments_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grvDocuments.CustomDrawRowIndicator

        ' Row Indicator zeichnen, wenn das ein Sammelrechnungseintrag war
        ' Das "Redo" - Symbol wird dazu verwendte

        If e.Info.IsRowIndicator Then
            Dim grid As GridView = CType(sender, GridView)

            Dim jArticleItem As JournalDocument = CType(grid.GetRow(e.RowHandle), JournalDocument)
            If jArticleItem IsNot Nothing Then
                If jArticleItem.HasInvoiceReference Then

                    e.Info.ImageIndex = -1
                    e.Painter.DrawObject(e.Info)
                    Dim r As Rectangle = e.Bounds
                    r.Inflate(-1, -1)


                    Dim x As Integer = CInt(r.X + (r.Width - m_hasInvoiceLinkImage.Width) / 2)
                    Dim y As Integer = CInt(r.Y + (r.Height - m_hasInvoiceLinkImage.Height) / 2)
                    e.Graphics.DrawImageUnscaled(m_hasInvoiceLinkImage, x, y)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub grvDocuments_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles grvDocuments.SelectionChanged
        RefreshHeadline()
    End Sub


End Class