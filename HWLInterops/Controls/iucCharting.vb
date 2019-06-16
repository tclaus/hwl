Imports DevExpress.XtraCharts
Imports ClausSoftware.Kernel

''' <summary>
''' Stellt eine Oberfläche mit grafischen Auswertungen bereit
''' </summary>
''' <remarks></remarks>
Public Class iucCharting
    Implements IModule

    ''' <summary>
    ''' Stellt einen Zeitgeber zur verfügung, um das Anzeigen der Stats zu verzögern
    ''' </summary>
    ''' <remarks></remarks>
    Private WithEvents m_timer As New Timer


    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FillData()
    End Sub

    Sub FillData()



        crtMain.DataSource = MainApplication.getInstance.JournalDocuments
        crtMain.SeriesDataMember = "DocumentTypeText"
        crtMain.SeriesTemplate.ArgumentDataMember = "Datum"
        crtMain.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime

        crtMain.SeriesTemplate.ValueDataMembers.Clear()
        crtMain.SeriesTemplate.ValueDataMembers.AddRange("Betrag")
        crtMain.SeriesTemplate.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        'ChartControl1.SeriesTemplate.LegendPointOptions.ArgumentDateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.MonthAndYear
        crtMain.SeriesTemplate.LegendPointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Currency
        crtMain.SeriesTemplate.Label.Visible = False



    End Sub

    Private Sub iucCharting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        modmain.InitializeApplication()
        m_timer.Interval = 500

        datStartDate.DateTime = Today.AddYears(-1)
        datEndDate.DateTime = Today
    End Sub

    Public Sub CreateJournalStats()
        Dim series1 As Series

        If chkPaintAs3D.Checked Then
            series1 = New Series("Umsatz", ViewType.Bar3D)
        Else
            series1 = New Series("Umsatz", ViewType.Line)
        End If

        crtMain.Series.Clear()
        crtMain.Series.Add(series1)

        FillSeriesByJournal(series1, datStartDate.DateTime, datEndDate.DateTime)
    End Sub

    Private Sub GetTopProducts()
        Dim sql As String
        Dim PreTopCount As String = ""
        Dim PostTopCount As String = ""

        If MainApplication.getInstance.Connections.WorkConnection.Servertype = ClausSoftware.Tools.enumServerType.Access Then
            PreTopCount = "Top 20"
        End If

        If MainApplication.getInstance.Connections.WorkConnection.Servertype = ClausSoftware.Tools.enumServerType.MySQL Then
            PostTopCount = "Limit 20"
        End If
        sql = "SELECT " & PreTopCount & " sum(Anzahl) as SumCount,Name,OrgItem, sum(VK) as SumVK  FROM Items I, JournalListe J where I.LfndNummer  = J.lfndNummer  and J.Status=2  group by Name,OrgItem having SumCount>0 order by 1 desc " & PostTopCount
        Dim dt As System.Data.DataTable = MainApplication.getInstance.Database.GetData(sql)


        If dt IsNot Nothing Then

            Dim series1 As Series

            If chkPaintAs3D.Checked Then
                series1 = New Series("Umsatz", ViewType.Bar3D)
            Else
                series1 = New Series("Umsatz", ViewType.Bar)
            End If
            series1.ArgumentScaleType = ScaleType.Qualitative


            crtMain.Series.Clear()
            crtMain.Series.Add(series1)

            series1.Label.Visible = False

            series1.DataSource = dt
            series1.ValueDataMembers.AddRange(New String() {"SumVK"})
            series1.ArgumentDataMember = "Name"


            series1.ArgumentScaleType = ScaleType.Qualitative
            series1.PointOptions.PointView = PointView.Undefined
            series1.ValueScaleType = ScaleType.Numerical
            series1.Label.Visible = False

        End If

    End Sub

    Private Sub FillSeriesByJournal(ByVal serie As Series, ByVal startDate As DateTime, ByVal endDate As DateTime)

        Dim seriaList As New SortedDictionary(Of String, Decimal)
        serie.Points.BeginUpdate()
        For Each document As JournalDocument In MainApplication.getInstance.JournalDocuments
            If document.DocumentDate < startDate Then Continue For
            If document.DocumentDate > endDate Then Continue For

            If document.DocumentType <> ClausSoftware.enumJournalDocumentType.Rechnung Then Continue For

            Dim datekey As String
            datekey = document.DocumentDate.Year & "." & document.DocumentDate.ToString("MM")
            If Not seriaList.ContainsKey(datekey) Then
                seriaList.Add(datekey, 0)
            End If

            seriaList(datekey) = seriaList(datekey) + document.DisplayedEndPrice


        Next

        For Each key As String In seriaList.Keys
            serie.Points.Add(New SeriesPoint(key, seriaList(key)))
        Next

        serie.ArgumentScaleType = ScaleType.Qualitative
        serie.PointOptions.PointView = PointView.Undefined
        serie.ValueScaleType = ScaleType.Numerical
        serie.Label.Visible = False


        serie.Points.EndUpdate()
        If TypeOf crtMain.Diagram Is XYDiagram3D Then
            CType(crtMain.Diagram, XYDiagram3D).AxisX.Label.Angle = 45
            CType(crtMain.Diagram, XYDiagram3D).AxisX.Label.Antialiasing = True
            CType(crtMain.Diagram, XYDiagram3D).RuntimeScrolling = True
            CType(crtMain.Diagram, XYDiagram3D).RuntimeZooming = True
            CType(crtMain.Diagram, XYDiagram3D).RuntimeRotation = True

        End If

        If TypeOf crtMain.Diagram Is XYDiagram Then
            CType(crtMain.Diagram, XYDiagram).AxisX.Label.Angle = 45
            CType(crtMain.Diagram, XYDiagram).AxisX.Label.Antialiasing = True
            CType(crtMain.Diagram, XYDiagram).EnableAxisXScrolling = True
            CType(crtMain.Diagram, XYDiagram).EnableAxisYScrolling = True

            CType(crtMain.Diagram, XYDiagram).EnableAxisXZooming = True
            CType(crtMain.Diagram, XYDiagram).EnableAxisYZooming = True
        End If

    End Sub



    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        Return True
    End Function

    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get

        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem

    End Sub

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return "Statistiken" 'todo:nls
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule

    End Sub

    Public Sub NewItem() Implements IModule.CreateNewItem

    End Sub

    Public Overrides Sub Print() Implements IModule.Print
        crtMain.ShowPrintPreview()
    End Sub

    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

    End Sub

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnPrint
        End Get
    End Property

    Private Sub m_timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_timer.Tick
        m_timer.Stop()
        CreateJournalStats()
    End Sub

    Private Sub radStatsByJournal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radStatsByJournal.SelectedIndexChanged
        m_timer.Stop()
        m_timer.Start()
    End Sub


    Private Sub chkPaintAs3D_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPaintAs3D.EditValueChanged
        m_timer.Stop()
        m_timer.Start()
    End Sub



    Private Sub datStartDate_Modified(ByVal sender As Object, ByVal e As System.EventArgs) Handles datStartDate.Modified, datEndDate.Modified
        m_timer.Stop()
        m_timer.Start()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioGroup1.SelectedIndexChanged
        GetTopProducts()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Public Sub New(ByVal myUI As MainUI)
        MyBase.New(myUI)
        InitializeComponent()

    End Sub

    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get
            'TODO: Kleines Bild für Charts festlegen
            Return Nothing
        End Get
    End Property
End Class
