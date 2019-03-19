Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors

''' <summary>
''' Stellt ein einfaches Ausdrucken von Grids zur Verfügung. 
''' Erweitert das Grid-Drucken durch Headline und andere Meta-Daten
''' </summary>
''' <remarks></remarks>
Public Class SimpleGridPrinting

    ''' <summary>
    ''' Stellt die gemeinsame Druck-Klasse zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared m_simpleGridPrinting As SimpleGridPrinting

    ''' <summary>
    ''' Stellt den Druck-Prozessor bereit
    ''' </summary>
    ''' <remarks></remarks>
    Private m_printingSystem As PrintingSystem

    Private m_printingLink As HWLPrintableComponentLink

    ''' <summary>
    ''' Der Name des Reports; wird auch als Job-Name verwendet
    ''' </summary>
    ''' <remarks></remarks>
    Private m_reportname As String

    ''' <summary>
    ''' Das aktuelle Grid, das gedruckt werden soll
    ''' </summary>
    ''' <remarks></remarks>
    Private m_grd As GridControl

    ''' <summary>
    ''' Ruft das auszudruckene Grid ab oder legt es fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GridToPrint() As GridControl
        Get
            Return m_grd
        End Get
        Set(ByVal value As GridControl)
            m_grd = value
        End Set
    End Property

    ''' <summary>
    ''' Überschrüft über dem Ausdruck
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Headline As String
        Get
            Return m_reportname
        End Get
        Set(value As String)
            m_reportname = value
        End Set
    End Property

    Private Sub New()

    End Sub

    ''' <summary>
    ''' ruft eine Instanz dieser Klasse ab. 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSimpleGridPrinting() As SimpleGridPrinting
        If m_simpleGridPrinting Is Nothing Then
            m_simpleGridPrinting = New SimpleGridPrinting
            m_simpleGridPrinting.Init()
        End If
        Return m_simpleGridPrinting
    End Function

    ''' <summary>
    ''' Initialisiert das Druck-System
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Init()
        m_printingSystem = New PrintingSystem
        m_printingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4

        'm_printingLink = New HWLPrintableComponentLink(m_printingSystem)
    End Sub

    ''' <summary>
    ''' Zeigt die Seitenvorschau des Grids an
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ShowPreviewDialog()
        Using m_printingLink As New HWLPrintableComponentLink(m_printingSystem)
            'Using m_printingLink As New PrintableComponentLink(m_printingSystem)

            ' Specify the control to be printed.
            m_printingSystem.ClearContent()

            m_printingSystem.Pages.Clear()

            m_printingLink.Component = m_grd

            m_printingLink.ReportTitle = m_reportname
            Dim prefixName As String = m_application.Languages.GetText("{AppName}") & ": "
            m_printingSystem.Document.Name = prefixName & m_reportname
            'm_printingLink.CreateDocument()

            m_printingLink.ShowPreviewDialog()

        End Using




    End Sub



End Class

''' <summary>
''' Stellt einen anpassbaren Ausdruck dar in dem der Seitentitel angezeigt wird
''' </summary>
''' <remarks></remarks>
Friend Class HWLPrintableComponentLink
    Inherits PrintableComponentLink

    Private m_ReportTitle As String
    ''' <summary>
    ''' Ruift den Report-Titel (die Überschrift a oder legt diese fest)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportTitle() As String
        Get
            Return m_ReportTitle
        End Get
        Set(ByVal value As String)
            m_ReportTitle = value
        End Set
    End Property

    Public Sub New(ByVal p As PrintingSystem)
        MyBase.New(p)
    End Sub


    Protected Overrides Sub CreateReportHeader(ByVal gr As DevExpress.XtraPrinting.BrickGraphics)
        MyBase.CreateReportHeader(gr)

        'gr.Font = Me.def
        gr.BackColor = Nothing
        gr.ForeColor = SystemColors.ControlText
        gr.StringFormat = New BrickStringFormat(StringFormatFlags.NoWrap)
        gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Near)
        gr.Font = New Font("Tahoma", 14, FontStyle.Bold)
        Dim rec As RectangleF = New RectangleF(0, 0, gr.ClientPageSize.Width, 50)

        gr.DrawString(Me.ReportTitle, Color.Black, rec, BorderSide.None)

    End Sub
    
    ''' <summary>
    ''' Seitenfuss schreiben: Seite n von M 
    ''' </summary>
    ''' <param name="gr"></param>
    ''' <remarks></remarks>
    Protected Overloads Overrides Sub CreateMarginalFooter(ByVal gr As BrickGraphics)
        MyBase.CreateMarginalFooter(gr)

        gr.Modifier = BrickModifier.MarginalFooter
        Dim format As String = GetText("PageXofTotalY", "Seite {0} von {1}")
        Dim brick As PageInfoBrick = gr.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black, _
        New RectangleF(0, 0, 0, 20), BorderSide.None)
        brick.Alignment = BrickAlignment.Far
        brick.AutoWidth = True
    End Sub

End Class