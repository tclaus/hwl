Imports ClausSoftware.Kernel

Namespace Printing

    ''' <summary>
    ''' Stellt einen Dialog berit, der einfache Auswahl des Drucks bietet: 
    ''' Grid WYSIWYG drucken oder als Print-Layout drucken
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class dlgSimplePrinting


        Private m_currentGrid As DevExpress.XtraGrid.GridControl

        Private m_itemsList As Object

        Private m_dataSourceType As DataSourceList

        Private m_selecetdItem As Data.StaticItem

        ''' <summary>
        ''' Kennzeichnet die ID des aktuellen Items
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SelectedItem() As Data.StaticItem
            Get
                Return m_selecetdItem
            End Get
            Set(ByVal value As Data.StaticItem)
                m_selecetdItem = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Datentype ab oder legt diesen fest. 
        ''' Damit kann später ein Layout wieder einer Datenquelle zugewiesen werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataSourceType() As DataSourceList
            Get
                Return m_dataSourceType
            End Get
            Set(ByVal value As DataSourceList)
                m_dataSourceType = value

                Dim reports As New Kernel.Printing.Reports(m_application)
                reports.SetDataType(value)

                cobPrintLayouts.Properties.Items.Clear()
                cobPrintLayouts.Properties.Items.AddRange(reports)
                cobPrintLayouts.SelectedIndex = 0

            End Set
        End Property




        ''' <summary>
        ''' Ruft das Grid ab, das die aktuellen Datensätze enthält. Damit kann ein einfacher Listendruck umgesetzt werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Grid() As DevExpress.XtraGrid.GridControl
            Get
                Return m_currentGrid
            End Get
            Set(ByVal value As DevExpress.XtraGrid.GridControl)
                m_currentGrid = value
            End Set
        End Property


        Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click


            PrintDirect()

        End Sub

        


        ''' <summary>
        ''' Druckt nur das gewählte Element im Benutzerdefiniertem Layout
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ShowPreview()
            If chkPrintList.Checked Then

                Grid.ShowPrintPreview()
                Exit Sub
            End If
            Dim dataType As New List(Of Data.StaticItem)

            Dim gridView As DevExpress.XtraGrid.Views.Grid.GridView = CType(Grid.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

            ' Die selektiertren Elemente einsammeln und übergeben
            For Each itemNr As Integer In gridView.GetSelectedRows
                dataType.Add(CType(gridView.GetRow(itemNr), Data.StaticItem))

            Next
            Dim lst As New List(Of Kernel.Printing.Report)
            lst.Add(CType(cobPrintLayouts.SelectedItem, Kernel.Printing.Report))

            mainControlContainer.MainUI.OpenReportPreview(dataType, DataSourceType, lst)

        End Sub

        ''' <summary>
        ''' Druckt nur das gewählte Element im Benutzerdefiniertem Layout
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub PrintDirect()

            If chkPrintList.Checked Then
                Grid.ShowPrintPreview()
                Exit Sub
            End If

            Dim dataType As New List(Of Data.StaticItem)

            Dim gridView As DevExpress.XtraGrid.Views.Grid.GridView = CType(Grid.DefaultView, DevExpress.XtraGrid.Views.Grid.GridView)

            ' Die selektiertren Elemente einsammeln und übergeben
            For Each itemNr As Integer In gridView.GetSelectedRows
                dataType.Add(CType(gridView.GetRow(itemNr), Data.StaticItem))

            Next
            Dim lst As New List(Of Kernel.Printing.Report)
            lst.Add(CType(cobPrintLayouts.SelectedItem, Kernel.Printing.Report))

            mainControlContainer.MainUI.PrintReportsDirect(dataType, DataSourceType, lst)

        End Sub

        Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
            Me.Close()
        End Sub

        Private Sub dlgSimplePrinting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            m_application.Languages.SetTextOnControl(Me)
            
        End Sub

        Private Sub chkPrintLayout_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintLayout.CheckStateChanged
            cobPrintLayouts.Enabled = chkPrintLayout.Checked

        End Sub

        Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
            ShowPreview()
        End Sub
    End Class

End Namespace
