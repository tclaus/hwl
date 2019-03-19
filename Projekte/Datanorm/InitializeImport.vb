''' <summary>
''' Stellt die Verknüpfung zum Datenimport bereit
''' </summary>
''' <remarks></remarks>
Public Class InitializeImport
    Implements ClausSoftware.AddIns.IImportAddIn


    Private Shared m_application As ClausSoftware.mainApplication

    Public Shared ReadOnly Property Application As ClausSoftware.mainApplication
        Get
            Return m_application
        End Get
    End Property


    Public ReadOnly Property UniqeID As String Implements ClausSoftware.AddIns.IImportAddIn.UniqeID
        Get
            Return "78378CA1-A9B3-4B64-B93E-801CE7E5A123"
        End Get
    End Property

    Public ReadOnly Property DisplayName As String Implements ClausSoftware.AddIns.IImportAddIn.DisplayName
        Get
            Return "Datanorm Import"
        End Get
    End Property

    Public ReadOnly Property LongDescription As String Implements ClausSoftware.AddIns.IImportAddIn.LongDescription
        Get
            Return "Importiert  Artikel aus Datanormdateien"
        End Get
    End Property

    Public Sub Show() Implements ClausSoftware.AddIns.IImportAddIn.Show

        Dim importController As New ImporterController(m_application)
        importController.ShowDialog()

    End Sub

    Public Sub StartUp(ByVal rootApplication As ClausSoftware.mainApplication) Implements ClausSoftware.AddIns.IImportAddIn.StartUp
        m_application = rootApplication
    End Sub

    Public ReadOnly Property ShouldStartupOnStart As Boolean Implements AddIns.IImportAddIn.ShouldStartupOnStart
        Get
            Return False
        End Get
    End Property

    Public Sub ShutDown() Implements AddIns.IImportAddIn.ShutDown

    End Sub
End Class
