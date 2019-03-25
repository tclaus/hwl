Imports ClausSoftware.Kernel

Namespace Printing

    ''' <summary>
    ''' Stellt einen Options-Dialog mit weiteren einstellungen für das Drucken von Angeboten / Rechnungen bereit.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class dlgPrintLetters

        Private m_DocID As List(Of Letter)

        Private m_mainUI As MainUI

        Private m_printLayouts As New List(Of LayoutToPrint)

        ''' <summary>
        ''' Ruft die Liste von Dokumenten ab, die gedruckt werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LettersList() As List(Of Letter)
            Get
                Return m_DocID

            End Get
            Set(ByVal value As List(Of Letter))
                m_DocID = value

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

        Private Sub ShowPrintPreview()

            '    CheckDocumentIsNew()

            ' Liste zum Reportdesigner durchreichen, 
            ' 
            m_mainUI.OpenReportPreview(Me.LettersList, DataSourceList.Letters, GetSelectedReports, chkPrintBusinesLayout.Checked)

        End Sub

        Private Sub PrintDirect()

            'CheckDocumentIsNew()

            m_mainUI.PrintReportsDirect(Me.LettersList, DataSourceList.Letters, GetSelectedReports, chkPrintBusinesLayout.Checked)

        End Sub

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




        Private Sub dlgPrintdocuments_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            ' Lokale Einstellungen sichern
            MainApplication.getInstance.Settings.SetSetting(Tools.RegistryValues.PrintMemoTexte, Tools.RegistrySections.ModuleInvoices, CInt(chkPrintBusinesLayout.Checked).ToString)

        End Sub

        Private Sub dlgPrintdocuments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            MainApplication.getInstance.Languages.SetTextOnControl(Me)

            ' Text der Überschrift festlegen.. 
            Me.Text = MainApplication.getInstance.Languages.GetTextBydataKind(DataSourceList.Letters) & " " & Me.Text

            Dim reports As New Kernel.Printing.Reports(MainApplication.getInstance)
            reports.SetDataType(DataSourceList.Letters)

            For Each item As Kernel.Printing.Report In reports
                m_printLayouts.Add(New LayoutToPrint(item))
            Next

            grdPrintLayouts.DataSource = m_printLayouts


            Dim PrintLayouttext As String = MainApplication.getInstance.Settings.GetSetting(Tools.RegistryValues.PrintMemoTexte, Tools.RegistrySections.ModuleInvoices)
            Dim printLayout As Boolean
            printLayout = Boolean.TryParse(PrintLayouttext, printLayout)

            chkPrintBusinesLayout.Checked = printLayout

        End Sub


        Public Sub New(ByVal MainUI As MainUI)
            InitializeComponent()

            m_mainUI = MainUI
        End Sub

        Private Sub repLayoutName_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repLayoutName.ButtonClick
            ' Dann das Layout im Designer öffnen 

            Dim layout As LayoutToPrint = CType(GridView1.GetRow(GridView1.FocusedRowHandle), LayoutToPrint)

            m_mainUI.OpenReportDesigner(LettersList, DataSourceList.Journaldocument, layout.Layout)


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

    End Class

    ''' <summary>
    ''' Stellt eine Durckvorlage dar
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class LayoutToPrint

        Private m_printIt As Boolean

        Private m_Layout As Kernel.Printing.Report


        Private m_pageCount As Integer = 1
        ''' <summary>
        ''' Ruft die Anzahl der zu druckenden Seiten ab oder legt dies fest
        ''' (Rechnung oft 2, Lieferchein nur 1.. )
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PageCount() As Integer
            Get
                Return m_pageCount
            End Get
            Set(ByVal value As Integer)
                m_pageCount = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen des Reports ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LayoutName As String
            Get
                Return m_Layout.ReportName
            End Get
        End Property
        Public Property Layout() As Kernel.Printing.Report
            Get
                Return m_Layout
            End Get
            Set(ByVal value As Kernel.Printing.Report)
                m_Layout = value
            End Set
        End Property

        Public Property PrintIt() As Boolean
            Get
                Return m_printIt
            End Get
            Set(ByVal value As Boolean)
                m_printIt = value
            End Set
        End Property

        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse
        ''' </summary>
        ''' <param name="report"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal report As Kernel.Printing.Report)
            m_Layout = report
            m_printIt = report.IsDefault
        End Sub

    End Class

End Namespace
