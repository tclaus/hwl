

''' <summary>
''' Zeigt einen Designer an, der ein allgemeines Brief-Papier enthält
''' </summary>
''' <remarks></remarks>
Public Class iucPageDesigner
    Implements IModule


    Private m_report As New DevExpress.XtraReports.UI.XtraReport()

    ''' <summary>
    ''' Schliesst das Modul wieder
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        ' Falls ungespeichert, dann speichern
        SaveCurrentItem()
        Return True
    End Function


    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            Return String.Empty
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem

    End Sub

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return "Seite einrichten" 'TODO: NLS
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule
        ' Lese Seitenlayout; falls nicht vorhanden, dann neu anlegen (aus HWL 1 aussuchen) 
        '

        Dim p As New PrintingManagerOldSystem()

        Dim CurrentLayoutData As String = MainApplication.getInstance.Settings.GetSetting("MainPageLayout", "reports")
        m_report.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        m_report.PaperKind = System.Drawing.Printing.PaperKind.A4

        m_report.Margins.Left = CInt(p.PrinterBounds.X * 2.54) + 40 '(in zentel mm)
        m_report.Margins.Right = 0
        m_report.Margins.Top = CInt(p.PrinterBounds.Y * 2.54) + 20 ' (in zentel mm)
        m_report.Margins.Bottom = m_report.Margins.Top

        If Not String.IsNullOrEmpty(CurrentLayoutData) Then
            Dim m As New System.IO.MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(CurrentLayoutData))
            m_report.LoadLayout(m)
        Else
            p.LoadPageSettings(m_report)
        End If

        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.AddNewDataSource, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.Exit, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.BindFieldToXRBarCode, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.BindFieldToXRCheckBox, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.BindFieldToXRLabel, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.BindFieldToXRPictureBox, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.BindFieldToXRRichText, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.BindFieldToXRZipCode, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.HtmlHome, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
        Me.XrDesignPanel1.SetCommandVisibility(DevExpress.XtraReports.UserDesigner.ReportCommand.ShowHTMLViewTab, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)



        Me.XrDesignPanel1.OpenReport(m_report)



    End Sub

    Public Sub NewItem() Implements IModule.CreateNewItem

    End Sub

    ''' <summary>
    ''' Hier nicht in dieser Form implemntietr
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Print() Implements IModule.Print

    End Sub

    ''' <summary>
    ''' speichert die aktuelle Report-Definition im neuen Format abab 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem
        Dim m As New System.IO.MemoryStream
        m_report.SaveLayout(m)
        MainApplication.getInstance.Settings.SetSetting("MainPageLayout", "reports", m)
    End Sub

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnSave
        End Get
    End Property
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

        End Get
    End Property
End Class
