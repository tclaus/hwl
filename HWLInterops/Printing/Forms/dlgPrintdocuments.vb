Imports ClausSoftware.Kernel

Namespace Printing

    ''' <summary>
    ''' Stellt einen Options-Dialog mit weiteren einstellungen für das Drucken von Angeboten / Rechnungen bereit.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class dlgPrintdocuments

        Private m_DocID As List(Of JournalDocument)

        Private m_mainUI As MainUI

        Private m_printLayouts As New List(Of LayoutToPrint)

        Private m_printOptions As New Printing.DocumentPrintingOptions

        ''' <summary>
        ''' Ruft die aktuellen Druck-Einstellungen ab.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property PrintOptions() As Printing.DocumentPrintingOptions
            Get
                Return m_printOptions
            End Get

        End Property

        ''' <summary>
        ''' Ruft die Liste von Dokumenten ab, die gedruckt werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DocumentsList() As List(Of JournalDocument)
            Get
                Return m_DocID

            End Get
            Set(ByVal value As List(Of JournalDocument))
                m_DocID = value
                If m_DocID.Count > 1 Then
                    txtdocumentsHeadline.Text = ""
                    txtdocumentsHeadline.Enabled = False
                Else
                    txtdocumentsHeadline.Text = m_DocID(0).DocumentTypeText
                    txtdocumentsHeadline.Enabled = True
                End If
            End Set
        End Property

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
            ShowPrintPreview()
        End Sub


        Private Sub CheckDocumentIsNew()
            If m_DocID.Count = 1 Then
                If m_DocID(0).IsNew Then
                    MessageBox.Show(GetText("msgDocumentNotSaved", "Das Dokument wurde noch nicht gespeichert und enthält noch keine gültige Dokumentennummer"), GetText("msgDocumentNotSavedHeadline", "Neues Dokument"), MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If
        End Sub

        ''' <summary>
        ''' Druckt sofort das gewünschte Dokument
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ShowPrintPreview()
            Try

                setUsersOptions()
                CheckDocumentIsNew()

                ' Liste zum Reportdesigner durchreichen, 

                m_mainUI.OpenReportPreview(Me.DocumentsList, DataSourceList.Journaldocument, GetSelectedReports, PrintOptions)
            Catch ex As Exception

                MainApplication.getInstance.log.WriteLog(ex, "Drucker-Fehler", "Fehler beim Druck eines Dokumentes")
                MessageBox.Show("Fehler beim drucken aufgetreten. Kontrollieren sie Ihre Drucker-Einstellungen.", "Drucker-Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try
        End Sub

        Private Sub PrintDirect()
            Try

                SetUsersOptions()
                CheckDocumentIsNew()

                m_mainUI.PrintReportsDirect(Me.DocumentsList, DataSourceList.Journaldocument, GetSelectedReports, PrintOptions)
            Catch ex As Exception

                MainApplication.getInstance.log.WriteLog(ex, "Drucker-Fehler", "Fehler beim Druck eines Dokumentes")


                'TODO : Default Printer angeben
                MessageBox.Show("Fehler beim Drucken aufgetreten. Kontrollieren sie Ihre Drucker-Einstellungen." & vbCrLf &
                                "Druckername: " & GetDefaultPrintername(), "Drucker-Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

        End Sub

        Private Function GetDefaultPrintername() As String
            Dim pname As String = "<Drucker nicht angegeben>"
            Try
                Dim pd As New System.Drawing.Printing.PrintDocument
                pname = pd.PrinterSettings.PrinterName
            Catch ex As Exception
            End Try
            Return pname
        End Function


        ''' <summary>
        ''' Ruft die Liste der selektierten Reports ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetSelectedReports() As List(Of Kernel.Printing.Report)
            Dim reportsList As New List(Of Kernel.Printing.Report)

            For Each item As LayoutToPrint In m_printLayouts
                If item.PrintIt Then
                    reportsList.Add(item.Layout)
                End If
            Next
            Return reportsList
        End Function

        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

            PrintDirect()

        End Sub


        Private Sub txtdocumentsHeadline_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdocumentsHeadline.EditValueChanged

            If m_DocID.Count = 1 Then
                m_DocID(0).DocumentTypeText = txtdocumentsHeadline.Text
            End If
        End Sub

        Private Sub dlgPrintdocuments_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            ' Lokale Einstellungen sichern
            MainApplication.getInstance.Settings.SetSetting(Tools.RegistryValues.PrintMemoTexte, Tools.RegistrySections.ModuleInvoices, CInt(chkPrintBusinesLayout.Checked).ToString)

            MainApplication.getInstance.Settings.ItemsSettings.DefaultPageCount = CShort(txtPageCount.Value)

        End Sub

        Private Sub dlgPrintdocuments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            MainApplication.getInstance.Languages.SetTextOnControl(Me)

            ' Text der Überschrift festlegen.. 
            Me.Text = MainApplication.getInstance.Languages.GetTextBydataKind(DataSourceList.Journaldocument) & " " & Me.Text

            Dim reports As New Kernel.Printing.Reports(MainApplication.getInstance)
            reports.SetDataType(DataSourceList.Journaldocument)

            For Each item As Kernel.Printing.Report In reports
                m_printLayouts.Add(New LayoutToPrint(item))
            Next

            grdPrintLayouts.DataSource = m_printLayouts
            Dim PrintBuisinessLayout As String = MainApplication.getInstance.Settings.GetSetting(Tools.RegistryValues.PrintMemoTexte, Tools.RegistrySections.ModuleInvoices, "1")
            If Not String.IsNullOrEmpty(PrintBuisinessLayout) Then
                chkPrintBusinesLayout.Checked = CBool(PrintBuisinessLayout)
            End If

            txtPageCount.Value = MainApplication.getInstance.Settings.ItemsSettings.DefaultPageCount



        End Sub


        Public Sub New(ByVal MainUI As MainUI)
            InitializeComponent()

            m_mainUI = MainUI
        End Sub

        Private Sub repLayoutName_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repLayoutName.ButtonClick
            ' Dann das Layout im Designer öffnen 

            Dim layout As LayoutToPrint = CType(GridView1.GetRow(GridView1.FocusedRowHandle), LayoutToPrint)

            m_mainUI.OpenReportDesigner(DocumentsList, DataSourceList.Journaldocument, layout.Layout)


        End Sub


        'Private Sub GridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridView1.MouseDown
        '    ' erwische den Button im Layout-Namen (geht irgendwie nicht..) 

        '    Dim p As System.Drawing.Point = grdPrintLayouts.PointToClient(e.Location) ' Punkt relativ im Control ermitteln 
        '    Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo
        '    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(grdPrintLayouts.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)
        '    hi = view.CalcHitInfo(p)


        '    ' So, nun mal schauen wo wir hinmüsen 
        '    If hi.InRowCell Then
        '        If hi.Column.Name = colTemplateName.Name Then
        '            ' Treffer.. 
        '            Dim rep As repLayoutName = hi.Column.ColumnEdit

        '        End If
        '    End If

        'End Sub


        Private Sub SetUsersOptions()
            ' Wird nicht dauerhaft gespeichert !
            For Each item As JournalDocument In DocumentsList
                item.PrintAsDeliveryNote = chkPrintAsDeliveryNote.Checked
            Next

            PrintOptions.PrintBusinesHeaderOnEveryPage = chkPrintBusinesReportOneveryPage.Checked
            PrintOptions.WithBusinesslayout = chkPrintBusinesLayout.Checked

        End Sub

        Private Sub chlShowLongText_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chlShowLongText.CheckedChanged
            PrintOptions.WithDescription = chlShowLongText.Checked

        End Sub

        Private Sub txtPageCount_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtPageCount.EditValueChanged
            Try
                Dim pageCount As Short = CShort(txtPageCount.EditValue)
                PrintOptions.PageCopies = pageCount
            Catch ex As Exception

            End Try
        End Sub

    End Class


End Namespace
