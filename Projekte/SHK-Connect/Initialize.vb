
''' <summary>
''' Initial-Klasse des Connectors; Verbindet sich mit dem Addin-Konstruktor
''' </summary>
''' <remarks></remarks>
Public Class Initialize
    Implements ClausSoftware.AddIns.IImportAddIn


    Private Shared m_Application As ClausSoftware.mainApplication

    ''' <summary>
    ''' Ruft das Haupt Applikations-Objekt ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Application As ClausSoftware.mainApplication
        Get

            If m_Application Is Nothing Then
                m_Application = New ClausSoftware.mainApplication()
            End If

            Return m_Application
        End Get
    End Property

    ''' <summary>
    ''' Ruft einen Anzeigetext ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ModulName As String
        Get
            Return "SHK-Connect"
        End Get
    End Property


    ''' <summary>
    ''' Anzeigename in der Oberfläche
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayName As String Implements ClausSoftware.AddIns.IImportAddIn.DisplayName
        Get
            Return Initialize.ModulName
        End Get
    End Property

    Public ReadOnly Property LongDescription As String Implements ClausSoftware.AddIns.IImportAddIn.LongDescription
        Get
            Return "Datenquellen des SHK-Branchenportals. stellt Datanormdaten von Unternehmen bereit."
        End Get
    End Property

    ''' <summary>
    ''' Zeigt ein Hauptfenster an
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Show() Implements ClausSoftware.AddIns.IImportAddIn.Show
        Try

            Dim frm As New frmMainSHKConnect
            frm.Show()

        Catch ex As Exception
            Application.Log.WriteLog(ex, ModulName, "Fehler im Hauptformular")
        End Try
    End Sub

    Public Sub StartUp(rootApplication As ClausSoftware.mainApplication) Implements ClausSoftware.AddIns.IImportAddIn.StartUp
        m_Application = rootApplication

        Application.UserStats.SendStatistics(ModulName, "Started")

    End Sub

    Public ReadOnly Property UniqeID As String Implements ClausSoftware.AddIns.IImportAddIn.UniqeID
        Get
            Return "5E33A05E-67C4-4ADF-A2DD-FDE0108D5171"
        End Get
    End Property

    Public ReadOnly Property ShouldStartupOnStart As Boolean Implements ClausSoftware.AddIns.IImportAddIn.ShouldStartupOnStart
        Get
            Return False
        End Get
    End Property

    Public Sub ShutDown() Implements ClausSoftware.AddIns.IImportAddIn.ShutDown
        m_Application.CloseConnection()
        m_Application = Nothing
    End Sub
End Class
