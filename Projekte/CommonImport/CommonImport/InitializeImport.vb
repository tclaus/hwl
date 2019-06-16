Imports ClausSoftware
''' <summary>
''' Stellt die Verknüpfung zum Datenimport bereit
''' </summary>
''' <remarks></remarks>
Public Class InitializeImport
    Implements ClausSoftware.AddIns.IImportAddIn
    Private application As MainApplication

    Public ReadOnly Property UniqeID As String Implements ClausSoftware.AddIns.IImportAddIn.UniqeID
        Get
            Return "78378CA1-A9B3-4B64-B93E-801CE7E5A975"
        End Get
    End Property


    Public ReadOnly Property DisplayName As String Implements ClausSoftware.AddIns.IImportAddIn.DisplayName
        Get
            Return "Datei Import"
        End Get
    End Property

    Public ReadOnly Property LongDescription As String Implements ClausSoftware.AddIns.IImportAddIn.LongDescription
        Get
            Return "Importiert Adressen und Artikel aus Textdateien"
        End Get
    End Property

    Public Sub Show() Implements ClausSoftware.AddIns.IImportAddIn.Show

        Dim importController As New ImporterController(application)
    End Sub

    Public Sub StartUp(ByVal rootApplication As ClausSoftware.MainApplication) Implements ClausSoftware.AddIns.IImportAddIn.StartUp
        application = rootApplication
    End Sub

    Public ReadOnly Property ShouldStartupOnStart As Boolean Implements ClausSoftware.AddIns.IImportAddIn.ShouldStartupOnStart
        Get
            Return False
        End Get
    End Property

    Public Sub ShutDown() Implements ClausSoftware.AddIns.IImportAddIn.ShutDown

    End Sub
End Class
