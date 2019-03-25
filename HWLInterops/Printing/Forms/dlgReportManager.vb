
Imports ClausSoftware.Kernel.Printing
Imports ClausSoftware.Kernel
Namespace Printing
    ''' <summary>
    ''' Stellt ein Dialog bereit, in dem verschiedene Report-Layouts ausgewählt werden können
    ''' </summary>
    ''' <remarks></remarks>
    Public Class dlgReportManager

        Private m_reports As ClausSoftware.Kernel.Printing.Reports


        Private m_DatalistType As DataSourceList = DataSourceList.None

        Private m_LayoutManagerMode As Boolean
        ''' <summary>
        ''' Zeigt an, das der Dialog in einem Modus gestartet wurde, in dem das Layout selber nicht geändert werde kann
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LayoutManagerMode() As Boolean
            Get
                Return m_LayoutManagerMode
            End Get
            Set(ByVal value As Boolean)
                m_LayoutManagerMode = value

                cobDataType.Enabled = Not value


            End Set
        End Property

        ''' <summary>
        ''' Ruft den Typ des Reports ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataListType() As DataSourceList
            Get
                Return m_DatalistType
            End Get
            Set(ByVal value As DataSourceList)
                m_DatalistType = value
                ' eine "0" heisst hier "Alle"
                cobDataType.SelectedItem = value

                If m_reports IsNot Nothing Then
                    Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = Nothing
                    If value <> 0 Then
                        criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("DataSourceKind = " & Me.DataListType)
                    End If

                    m_reports.Filter = criteria
                End If

            End Set
        End Property


        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            m_reports.Save()
            Me.Close()
        End Sub

        Private Sub dlgReportManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            MainApplication.getInstance.Settings.SaveFormsPos(Me)

            MainApplication.getInstance.Settings.SetSetting("LastKnownReportKind", "Reports", cobDataType.SelectedIndex.ToString)
        End Sub


        Private Sub dlgReportManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = Nothing

            mainControlContainer.MainUI.CheckForDefaultLayouts()



            If Me.DataListType <> DataSourceList.None Then
                criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("DataSourceKind = " & Me.DataListType)
            End If
            ' Falls kein Datentyp gesetzt ist, dann ist der Filter auch gesetzt
            m_reports = New Reports(MainApplication.getInstance)
            m_reports.Filter = criteria

            grdReportsList.DataSource = m_reports

            MainApplication.getInstance.Settings.RestoreFormsPos(Me)
            MainApplication.getInstance.Languages.SetTextOnControl(Me)

            ' Das Kontextmenü übersetzen
            mnuDelete.Text = GetText(mnuDelete.Name, mnuDelete.Text)
            mnuDuplicateReport.Text = GetText(mnuDuplicateReport.Name, mnuDuplicateReport.Text)
            mnuEdit.Text = GetText(mnuEdit.Name, mnuEdit.Text)
            mnuResetReports.Text = GetText(mnuResetReports.Name, mnuResetReports.Text)



        End Sub

        Private Sub SetReportsFilter()

        End Sub

        Private Sub cobDataType_CustomDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles cobDataType.CustomDisplayText
            ' Aus de Enum, die hietr durchkommt den deutschen Text ermitteln
            'If TypeOf e.Value Is DataSourceList Then
            '    e.DisplayText = MainApplication.getInstance.Languages.GetTextBydataKind(CType(e.Value, DataSourceList))
            'End If
        End Sub

        Private Sub cobDataType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobDataType.SelectedIndexChanged
            If TypeOf cobDataType.SelectedItem Is DatasourceItem Then
                Me.DataListType = CType(cobDataType.SelectedItem, DatasourceItem).DataSource
                btnNew.Enabled = True
            Else
                'Alle ausgewählt

                Me.DataListType = 0
                btnNew.Enabled = False
            End If

            SetDisplayableProperties()

        End Sub

        Private Class DatasourceItem
            ''' <summary>
            ''' Zeigt an, das ein Objekt gleich ist
            ''' </summary>
            ''' <param name="obj"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Overrides Function Equals(ByVal obj As Object) As Boolean
                If TypeOf obj Is DatasourceItem Then
                    If CType(obj, DatasourceItem).DataSource = Me.DataSource Then
                        Return True
                    Else
                        Return False
                    End If
                Else

                    Return MyBase.Equals(obj)
                End If


            End Function

            Private m_dataSource As DataSourceList
            Public Property DataSource() As DataSourceList
                Get
                    Return m_dataSource
                End Get
                Set(ByVal value As DataSourceList)
                    m_dataSource = value
                End Set
            End Property

            ''' <summary>
            ''' Zeigt den Text an, der den Report-Typ darstellt
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Overrides Function ToString() As String
                Return MainApplication.getInstance.Languages.GetTextBydataKind(DataSource)
            End Function

            Public Sub New(ByVal DataSource As DataSourceList)
                m_dataSource = DataSource
            End Sub
        End Class

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

            Dim newReport As Report = m_reports.GetNewItem

            If TypeOf cobDataType.SelectedItem Is DatasourceItem Then
                newReport.DataSourceKind = CType(cobDataType.SelectedItem, DatasourceItem).DataSource

                newReport.ReportName = MainApplication.getInstance.Languages.GetText("NewPrintLayoutName", "Neues DruckLayout")
                newReport.Description = GetText("enum_" & newReport.DataSourceKind, newReport.DataSourceKind.ToString)
                m_reports.Add(newReport)
            End If

        End Sub

        Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
            ExportSelectedReport()
        End Sub

        ''' <summary>
        ''' Ruft den selektierten Report ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SelectedReport() As Report
            Get
                Return TryCast(GridView1.GetFocusedRow, Report)
            End Get

        End Property

        ''' <summary>
        ''' Erstellt eine Datei mit dem aktuell ausgewähltem Report-Layout und speichert diese ab
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ExportSelectedReport()
            If SelectedReport IsNot Nothing Then

                Using sfd As New Vista_Api.SaveFileDialog()

                    sfd.Filter = GetText("PrintLayoutFileDialogTitle", "Druck-Layout") & " (*.rep)|*.rep"
                    sfd.Title = GetText("PrintLayoutFileDialogTitle", "Druck-Layout")


                    Dim filename As String = SelectedReport.ReportName


                    For Each item As Char In System.IO.Path.GetInvalidFileNameChars
                        filename = filename.Replace(item, "_")
                    Next

                    sfd.FileName = filename

                    sfd.RestoreDirectory = True

                    If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                        ' Auf Endung prüfen: 
                        Try
                            If Not System.IO.Path.GetExtension(sfd.FileName).ToLower = ".rep" Then
                                sfd.FileName &= ".rep"
                            End If

                        Catch ex As Exception
                            ' Pfad ungültig 
                            MessageBox.Show(GetText("msgInvalidPathMessage", "Der angegebene Dateiname enthält ungültige Zeichen"), GetText("msgInvalidPathnameHeadline", "Ungültiger Pfad oder Dateiname"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try

                        ' Hier kein Briefpapier; daher kann immer das Buisineslayout entferntwerden
                        Dim ToSaveReport As Kernel.Printing.Report = CType(SelectedReport.Clone, Report)

                        ToSaveReport.RemoveBusinessLayout()

                        ToSaveReport.SaveToDisk(sfd.FileName)
                        ToSaveReport = Nothing

                    End If
                End Using
            End If
        End Sub

        ''' <summary>
        ''' Fügt ein Report dieser Auflistung hinzu
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ImportSelectedReport()


            Dim sfd As New Vista_Api.OpenFileDialog()
            Dim filterName As String = GetText("PrintLayoutOpendialogFilterFilename", "Druck Layouts")
            Dim filterdialogTitle As String = GetText("PrintLayoutOpenDialogTitle", "Report File")

            sfd.Filter = filterName & " (*.rep)|*.rep" 'rep|Druck Layout"
            sfd.Title = filterdialogTitle

            sfd.RestoreDirectory = True

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim filename As String = sfd.FileName
                Try
                    Dim newreport As Report
                    newreport = Report.LoadFromDisk(filename)
                    newreport.ReplikID = String.Empty  ' Leeren, sonst kann das niemals wieder importiert werden
                    m_reports.Add(newreport)
                    newreport.Save()

                Catch ex As Exception
                    Dim text As String = GetText("msgErrorOccuredWhileReadingDesignfile", "Ein Fehler trat auf beim lesen des Designs.")
                    Dim Caption As String = GetText("capFileNotfound", "Datei konnte nicht gelesen werden")
                    MessageBox.Show(text & vbCrLf & ex.Message, Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If


        End Sub
        Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
            ImportSelectedReport()
        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            DeleteSelectedReport()
        End Sub

        Private Sub DeleteSelectedReport()
            Dim result As DialogResult
            result = AskDeleteData(Me.SelectedReport.ReportName)
            If result = Windows.Forms.DialogResult.Yes Then
                Me.SelectedReport.Delete()

            End If
        End Sub

        Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
            SetDisplayableProperties()
        End Sub

        ''' <summary>
        ''' Setzt anzeigeeigenschaften gemäss des aktuell focussierten Eintrages
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetDisplayableProperties()
            Dim selectedReport As Report = CType(GridView1.GetFocusedRow, Report)
            If selectedReport IsNot Nothing Then

                mnuEdit.Enabled = True
                btnEdit.Enabled = True
                btnDelete.Enabled = True
                btnExport.Enabled = True

                txtDescriptionText.Text = selectedReport.Description
            Else
                mnuEdit.Enabled = False
                btnEdit.Enabled = False

                btnDelete.Enabled = False
                btnExport.Enabled = False
                txtDescriptionText.Text = String.Empty
            End If
        End Sub

        Private Sub txtDescriptionText_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescriptionText.EditValueChanged
            If Me.SelectedReport IsNot Nothing Then
                Me.SelectedReport.Description = CStr(txtDescriptionText.EditValue)

            End If
        End Sub

        Private Sub RepositoryItemCheckEdit1_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
            ' wird ein neuer Report selektiert, dann die anderen abwählen
            Dim chk As DevExpress.XtraEditors.CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)

            If chk.Checked Then
                ' Alle anderen in der selben Gruppe abwählen

                Dim actualReport As Report = Me.SelectedReport

                actualReport.IsDefault = True

                Dim reports As Reports = m_reports.SetDataType(Me.SelectedReport.DataSourceKind)
                For Each item As Report In reports

                    If item.ID <> actualReport.ID Then
                        item.IsDefault = False
                    End If

                Next

            End If

        End Sub

        Public Sub New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()
            Dim LastKnownIndex As Integer
            ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
            LastKnownIndex = CInt(MainApplication.getInstance.Settings.GetSetting("LastKnownReportKind", "Reports", "0"))

            'NLS wird hier direkt auf dem Conbtrol erledigt (Displaytext - Eigenschaft)
            cobDataType.Properties.Items.Clear()

            ' Die möglichen Auflistungen hinzufügen
            cobDataType.Properties.Items.Add("-- " & GetText("All", "Alle") & " --")

            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.Addressbook))
            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.Articles)) ' Materialstamm 
            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.BillOfMaterial)) ' Materialstamm 

            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.CashJournalMonthy)) ' Kassenbuch
            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.CashJournalYearly)) ' Kassenbuch

            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.Journal)) ' Auflistung der Jorunaldokumente
            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.Journaldocument)) ' Ein Angebot / Rechnung / usw..
            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.Letters)) ' Briefe
            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.Reminders)) ' Mahnungen (wie Briefe)
            cobDataType.Properties.Items.Add(New DatasourceItem(DataSourceList.Transactions)) ' Forderungen / Verbindlichkeiten

            cobDataType.SelectedIndex = LastKnownIndex

        End Sub

        Private Sub GridView1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridView1.MouseUp

            If e.Button = Windows.Forms.MouseButtons.Right Then
                gridContextMenü.Show(grdReportsList, e.Location)
            End If


        End Sub

        Private Sub btnOpenReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
            OpenSelectedReport()
        End Sub

        ''' <summary>
        ''' Öffnen einen Report-designer mit dem angegbenen Layout
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub OpenSelectedReport()
            If SelectedReport Is Nothing Then Exit Sub


            mainControlContainer.MainUI.OpenReportDesigner(Nothing, SelectedReport.DataSourceKind, Me.SelectedReport)


        End Sub


        Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
            OpenSelectedReport()
        End Sub


        Private Sub GridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
            If e.Column Is colreportType Then
                Dim colText As String = e.DisplayText
                If e.Value IsNot Nothing Then
                    If TypeOf e.Value Is DataSourceList Then
                        colText = GetText(CType(e.Value, DataSourceList).ToString)
                    End If
                    e.DisplayText = colText
                End If

            End If
        End Sub

        Private Sub GridView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hit As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(grdReportsList.PointToClient(MousePosition))

            If hit.InRow Then
                ' Treffer -Zeile geklickt 
                OpenSelectedReport()
            End If

        End Sub

        ''' <summary>
        ''' Stellt die Standardlayouts in dieser Gruppe wieder her. 
        ''' Standardlayouts sind die, die mitgeliefertwerden und bereits im Programmcode enthalten sind
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ResetReports()
            If cobDataType.SelectedItem IsNot Nothing Then
                If TypeOf cobDataType.SelectedItem Is DatasourceItem Then
                    Dim layoutType As DataSourceList = CType(cobDataType.SelectedItem, DatasourceItem).DataSource

                    Printing.PrintingDefaults.SetDefaultPrintLayouts(layoutType)
                    If m_reports IsNot Nothing Then
                        m_reports.Reload()
                    End If

                End If

            End If
        End Sub

        Private Sub btnResetReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResetReports.Click
            ResetReports()
        End Sub

        Private Sub gridContextMenü_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles gridContextMenü.Opening

            If GridView1.GetFocusedRow Is Nothing Then
                mnuEdit.Enabled = False
                mnuDelete.Enabled = False
            Else
                mnuEdit.Enabled = True
                mnuDelete.Enabled = True

            End If
        End Sub

        Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
            DeleteSelectedReport()
        End Sub

        Private Sub GridView1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridView1.KeyPress

        End Sub

        Private Sub GridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
            If e.KeyCode = Keys.Delete Then
                e.Handled = True
                Me.DeleteSelectedReport()
            End If
        End Sub

        Private Sub Duplicate()
            If Me.SelectedReport IsNot Nothing Then
                Dim newRep As Report
                newRep = CType(Me.SelectedReport.Clone(), Report)
                newRep.Save()
                m_reports.Add(newRep)

            End If
        End Sub

        Private Sub mnuDuplicateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDuplicateReport.Click
            Duplicate()
        End Sub
    End Class

End Namespace
