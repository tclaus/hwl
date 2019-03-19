Imports ClausSoftware.Kernel

Namespace Printing

    ''' <summary>
    ''' Stellt den Formular-Container bereit das das eigentliche Drucken-Steuerelement enthält.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class frmPrintingManager

        Dim m_data As Object

        Private m_dataSourceType As DataSourceList

        Private m_PrintDocument As Boolean

        Private m_activeReport As Kernel.Printing.Report

        Private m_ActivateBusinessFrame As Boolean

        ''' <summary>
        ''' wenn eingeschaltet wird ein Briefpapier um das Layout gelegt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ActivateBuisinesFrame() As Boolean
            Get
                Return m_ActivateBusinessFrame
            End Get
            Set(ByVal value As Boolean)
                m_ActivateBusinessFrame = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den aktiven Report ab oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ActiveReport() As Kernel.Printing.Report
            Get
                Return m_activeReport
            End Get
            Set(ByVal value As Kernel.Printing.Report)
                m_activeReport = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Datentype ab oder legt deisen fest
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
            End Set
        End Property

        Private Sub frmPrintingManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Try

                'TODO: Fragen nach schliessen der Printing-Form ? 
                m_application.Settings.SaveFormsPos(Me)
            Catch ex As Exception
            End Try
        End Sub

        ''' <summary>
        ''' Wenn True, wird das Dokument sofort auf dem Standard-Drucker gedrcuht und nicht erst die Vorschau angezeigt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PrintDocument() As Boolean
            Get
                Return m_PrintDocument
            End Get
            Set(ByVal value As Boolean)
                m_PrintDocument = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Datenquelle ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Data As Object
            Get
                Return m_data
            End Get
            Set(ByVal value As Object)
                m_data = value
            End Set
        End Property

        Private Sub frmPrintingManager_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
                e.Handled = True
            End If
        End Sub


        Private Sub frmPrintLetter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Me.DesignMode Then Exit Sub
            m_application.SendMessage(GetText("msgWaitForPrintDesignerLoad", "Lade den Layout-Designer..."))

            iucPrintingManager.ReportDatasourceType = DataSourceType
            iucPrintingManager.Data = m_data
            iucPrintingManager.ActiveReport = Me.ActiveReport
            iucPrintingManager.Initialize()


            m_application.Settings.RestoreFormsPos(Me)
            m_application.Languages.SetTextOnControl(Me)

            If Me.PrintDocument Then
                iucPrintingManager.PrintDocument()
                'Me.Close()
            End If
            ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
            Me.Text = Me.Text & " (" & GetText(DataSourceType.ToString, DataSourceType.ToString) & ") "

        End Sub

        ''' <summary>
        ''' Startet eine neue Instanz des Drucker-Layouts.
        ''' </summary>
        ''' <param name="data">Eine Auflistung der übergebenen Daten. Ist idealerweise eine Instanz von BaseCollection, jede ander Auflistung, die das iCollection-Interface implementiert ist aber auch gut.</param>
        ''' <param name="dataType">Eine Kennung über den verwendeten Datentyp</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal data As Object, ByVal dataType As DataSourceList)

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()
            m_data = data
            m_dataSourceType = dataType

        End Sub

        Public Sub New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()
        End Sub

    End Class

End Namespace