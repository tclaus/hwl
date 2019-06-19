Imports DevExpress
Imports DevExpress.XtraPrinting
Imports DevExpress.Xpo
Imports System.IO
Imports System.ComponentModel.Design
Imports DevExpress.XtraReports.Design
'Imports DevExpress.XtraReports.UI
Imports ClausSoftware.Kernel

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data

Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors
Imports DevExpress.Skins
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraReports.UserDesigner

Namespace Printing

    ''' <summary>
    ''' Stellt das Modul des Druck-Designers dar.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class iucPrintingManager

        Private m_printingManager As New PrintingManager

        Private m_BusinessLetterLocked As Boolean
        ''' <summary>
        ''' wenn True wird verhindert, das das Briefpapier verwendet werden kann
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BusinessLetterLocked() As Boolean
            Get
                Return m_BusinessLetterLocked
            End Get
            Set(ByVal value As Boolean)
                m_BusinessLetterLocked = value
            End Set
        End Property



        Dim serverModeDS As XPServerCollectionSource

        ''' <summary>
        ''' Aktueller Report
        ''' </summary>
        ''' <remarks></remarks>
        Dim newReport As DevExpress.XtraReports.UI.XtraReport


        ''' <summary>
        ''' Enthält eine Auflistung von Druckbaren Daten
        ''' </summary>
        Friend Property Data() As Object
            Get
                Return m_printingManager.Data
            End Get
            Set(ByVal value As Object)
                m_printingManager.Data = value
            End Set
        End Property

        Property ActiveReport As Kernel.Printing.Report
            Get
                Return m_printingManager.MainReportData
            End Get
            Set(ByVal value As Kernel.Printing.Report)
                m_printingManager.MainReportData = value
            End Set
        End Property


        ''' <summary>
        ''' Druckt das Dokument sofort aus
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PrintDocument()
            PrintingSystem1.ExecCommand(PrintingSystemCommand.PrintDirect)


        End Sub

        ''' <summary>
        ''' Ruft dei datenquelle ab oder setzt diese
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ReportDatasourceType() As Kernel.DataSourceList
            Get
                Return m_printingManager.ReportDatasourceKind
            End Get
            Set(ByVal value As Kernel.DataSourceList)
                m_printingManager.ReportDatasourceKind = value
            End Set
        End Property



        ''' <summary>
        ''' Speichert den aktuellen Report wieder in die Datenbank
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub Saveworkspace()

            m_printingManager.SaveMainLayout()

            PageDesigner.ReportState = XtraReports.UserDesigner.ReportState.Saved

        End Sub

        ''' <summary>
        ''' 'Holt den Dateiname des Layouts ab
        ''' </summary>
        ''' <param name="defaultName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetFilenameForLayout(ByVal defaultName As String) As String
            ' Dateiname ist fest, wenn benutzer vie ein anderes Layout gewähltz hat
            Dim value As String = MainApplication.getInstance.Settings.GetSetting("DefaultLayout", Me.ReportDatasourceType.ToString, "")
            If value = "" Then
                MainApplication.getInstance.Settings.SetSetting("DefaultLayout", Me.ReportDatasourceType.ToString, defaultName)
                Return defaultName
            Else
                Return value
            End If
        End Function

        ''' <summary>
        ''' Erstellt ein Briefbogenlayout, falls gewünscht und erforderlich
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ShowBuisinesLayout() As Boolean
            Get
                Return m_printingManager.ShowBusinesLayout
            End Get
            Set(ByVal value As Boolean)
                m_printingManager.ShowBusinesLayout = value
            End Set
        End Property

        ''' <summary>
        ''' Startet den Aufbau des Drucken-Reports
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize()
            If Me.DesignMode Then Exit Sub
            Try

                ' CheckForLicenses()
                'MainApplication.getInstance.Settings.Reload()
                m_printingManager.InitBusinessLayout()
                m_printingManager.InitMainPageLayout()


                newReport = m_printingManager.MainReport

                'MainApplication.getInstance.Licenses.RegisterGlobalLicense(Me.LicenseFormularDesigner)
                AddHandler newReport.PrintProgress, AddressOf PrintProgress
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try


            CheckForLicenses()
            Me.PageDesigner.OpenReport(newReport)



            PageDesigner.ExecCommand(XtraReports.UserDesigner.ReportCommand.ShowPreviewTab)


            RibbonControl1.SelectedPage = PagePreview
            ' Kein speichern beim beenden
            ' Speichern in die Datenbank
            ' Kein Briefbogen-Layout


            ' newReport.PrintingSystem.AddCommandHandler(CType(New PrintCommandHandler(m_printingManager), XtraPrinting.ICommandHandler))


            btnShowBusinessLayout.Enabled = m_printingManager.IsBusinesLayoutEnabled
            btnShowBusinessLayout.Checked = m_printingManager.ShowBusinesLayout

            ' Feldlite sollt sich neu aufbauen
            Dim fieldList As DevExpress.XtraReports.UserDesigner.FieldListDockPanel = CType(XrDesignDockManager1(XtraReports.UserDesigner.DesignDockPanelType.FieldList), DevExpress.XtraReports.UserDesigner.FieldListDockPanel)
            Dim host As IDesignerHost = CType(PageDesigner.GetService(GetType(IDesignerHost)), IDesignerHost)


            fieldList.UpdateDataSource(host)


        End Sub
        ''' <summary>
        ''' Zeigt den aktuellen Druckfortschritt an
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub PrintProgress(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.PrintProgressEventArgs)
            MainApplication.getInstance.SendMessage(GetText("PrintPage", "Drucke Seite: {0}", CStr(e.PageIndex)))
        End Sub

        ''' <summary>
        ''' Beim Start abfragen, welche Lizenzen gezogen werden können; dann den Designer-Abnteil verbergen falls kein Designer-Lizenz vorhanden ist
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CheckForLicenses()
            ' exports; 
            ' Formulardesigner

            Dim ps As PrintingSystemBase = PrintControl1.PrintingSystem

            'RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
            '  RibbonControl1.SelectedPage = PrintPreviewRibbonPage
            '  PrintControl1.BringToFront()
            ' diese beiden auf keinen Fall enablen!
            ps.SetCommandVisibility(PrintingSystemCommand.ExportHtm, XtraPrinting.CommandVisibility.None)
            ps.SetCommandVisibility(PrintingSystemCommand.ExportMht, XtraPrinting.CommandVisibility.None)



            ' diese anhand der Lizenz "export" ein- oder ausschalten
            ps.SetCommandVisibility(PrintingSystemCommand.ExportCsv, XtraPrinting.CommandVisibility.None)
            ps.SetCommandVisibility(PrintingSystemCommand.ExportFile, XtraPrinting.CommandVisibility.None)
            ps.SetCommandVisibility(PrintingSystemCommand.ExportHtm, XtraPrinting.CommandVisibility.None)
            ps.SetCommandVisibility(PrintingSystemCommand.ExportPdf, XtraPrinting.CommandVisibility.None)
            ps.SetCommandVisibility(PrintingSystemCommand.ExportRtf, XtraPrinting.CommandVisibility.None)
            ps.SetCommandVisibility(PrintingSystemCommand.ExportTxt, XtraPrinting.CommandVisibility.None)
            ps.SetCommandVisibility(PrintingSystemCommand.ExportXls, XtraPrinting.CommandVisibility.None)

            ps.SetCommandVisibility(PrintingSystemCommand.Save, XtraPrinting.CommandVisibility.None)
            ps.SetCommandVisibility(PrintingSystemCommand.Open, XtraPrinting.CommandVisibility.None)
            ps.SetCommandVisibility(PrintingSystemCommand.DocumentMap, XtraPrinting.CommandVisibility.None)


            ' Designer bezogen
            PageDesigner.SetCommandVisibility(XtraReports.UserDesigner.ReportCommand.VerbReportWizard, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)

            PageDesigner.SetCommandVisibility(XtraReports.UserDesigner.ReportCommand.AddNewDataSource, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)

            PageDesigner.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport, XtraReports.UserDesigner.CommandVisibility.None)
            PageDesigner.ShowComponentTray = False

            Dim visibleValue As DevExpress.XtraReports.UserDesigner.CommandVisibility = XtraReports.UserDesigner.CommandVisibility.All


            Debug.Print("Formulardesigner hat Lizenz, wird freigeschaltet")
                visibleValue = XtraReports.UserDesigner.CommandVisibility.All

            PageDesigner.SetCommandVisibility(XtraReports.UserDesigner.ReportCommand.ShowDesignerTab, visibleValue)

        End Sub



        Private Sub btnReportLayoutManager_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReportLayoutManager.ItemClick
            Dim frm As New dlgReportManager
            frm.DataListType = Me.ReportDatasourceType
            frm.LayoutManagerMode = True
            frm.ShowDialog()

            ' Hier nun den Report austauschen 


        End Sub



        Private Sub btnShowBusinessLayout_CheckedChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowBusinessLayout.CheckedChanged
            If m_printingManager IsNot Nothing Then
                m_printingManager.ShowBusinesLayout = btnShowBusinessLayout.Checked
            End If

        End Sub

        ''' <summary>
        ''' Speichert das aktuell eingestellte Layout ohne Nachfrage ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Save()
            If m_printingManager.IsBusinessLayout Then

                m_printingManager.SaveBusinessLayout()

            Else
                m_printingManager.SaveMainLayout()

            End If

            ' Prevent the "Report has been changed" dialog from being shown.
            PageDesigner.ReportState = XtraReports.UserDesigner.ReportState.Saved
        End Sub

        Private Sub btnSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
            'PageDesigner.ExecCommand(ReportCommand.SaveFile)
            Me.Save()
        End Sub

        Private Sub test(ByVal sender As Object, ByVal e As EventArgs)
            'Throw New NotImplementedException

        End Sub



        Private Sub iucPrintingManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            PageDesigner.AddCommandHandler(CType(New SaveCommandHandler(PageDesigner, m_printingManager), XtraReports.UserDesigner.ICommandHandler))

        End Sub
    End Class

    Public Class PrintCommandHandler
        Implements XtraPrinting.ICommandHandler


        Public Sub New(ByVal manager As PrintingManager)

        End Sub


        Public Function CanHandleCommand(ByVal command As DevExpress.XtraPrinting.PrintingSystemCommand, ByVal printControl As DevExpress.XtraPrinting.IPrintControl) As Boolean Implements DevExpress.XtraPrinting.ICommandHandler.CanHandleCommand
            If command = PrintingSystemCommand.Print Or command = PrintingSystemCommand.PrintDirect Then
                Return True
            Else
                Return False
            End If

        End Function

        Public Sub HandleCommand(ByVal command As DevExpress.XtraPrinting.PrintingSystemCommand, ByVal args() As Object, ByVal printControl As DevExpress.XtraPrinting.IPrintControl, ByRef handled As Boolean) Implements DevExpress.XtraPrinting.ICommandHandler.HandleCommand

        End Sub
    End Class



    ''' <summary>
    ''' Überschreibt das Speichern von Report-Designs
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SaveCommandHandler
        Implements DevExpress.XtraReports.UserDesigner.ICommandHandler


        Private m_printingManager As PrintingManager
        Private m_designPanel As XtraReports.UserDesigner.XRDesignPanel

        Public Sub New(ByVal panel As XtraReports.UserDesigner.XRDesignPanel, ByVal manager As PrintingManager)
            m_printingManager = manager
            m_designPanel = panel
        End Sub

        ''' <summary>
        ''' Speichert den Report ab
        ''' </summary>
        ''' <remarks></remarks>
        Sub Save()
            ' Write your custom saving here.
            ' ...

            If Not ((m_designPanel.ReportState And XtraReports.UserDesigner.ReportState.Changed) = XtraReports.UserDesigner.ReportState.Changed) Then Exit Sub


            'TODO: NLS
            Dim result As DialogResult = MessageBox.Show(GetText("msgTextSaveChangedPrintLayout", "Möchten sie das geänderte Layout speichern?"), GetText("msgHeadLayoutWasChanged", "Layout wurde geändert"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)


            If m_printingManager.IsBusinessLayout Then
                If result = DialogResult.Yes Then

                    m_printingManager.SaveBusinessLayout()
                End If
            Else
                If result = DialogResult.Yes Then
                    m_printingManager.SaveMainLayout()

                End If
            End If

            ' Prevent the "Report has been changed" dialog from being shown.
            m_designPanel.ReportState = XtraReports.UserDesigner.ReportState.Saved

        End Sub

        Public Function CanHandleCommand(ByVal command As DevExpress.XtraReports.UserDesigner.ReportCommand) As Boolean Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.CanHandleCommand
            Return command = XtraReports.UserDesigner.ReportCommand.SaveFile Or command = XtraReports.UserDesigner.ReportCommand.SaveFileAs Or command = XtraReports.UserDesigner.ReportCommand.Closing
        End Function

        Public Sub HandleCommand(ByVal command As DevExpress.XtraReports.UserDesigner.ReportCommand, ByVal args() As Object, ByRef handled As Boolean) Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.HandleCommand
            If Not CanHandleCommand(command) Then
                Return
            End If

            ' Save a report.
            Save()

            ' Set handled to true to avoid the standard saving procedure to be called.
            handled = True
        End Sub


    End Class


End Namespace