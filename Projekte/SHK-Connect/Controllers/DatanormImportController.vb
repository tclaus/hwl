
''' <summary>
''' Stellt eine Verbindung zum Datanorm-Import bereit, damit können 
''' </summary>
''' <remarks></remarks>
Friend Class DatanormImportController

    Private m_fileList As New List(Of String)

    Private m_datanormImporter As New ClausSoftware.ImporterController(Initialize.Application)

    Public Sub New()
        AddHandler m_datanormImporter.ReadLineNumber, AddressOf CurrentImportStateEventHandler
        '  AddHandler m_datanormImporter.Message, AddressOf ForwardMessage
    End Sub

    ''' <summary>
    ''' Behandelt den Import-Fortschritt
    ''' </summary>
    ''' <param name="sende"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CurrentImportStateEventHandler(sende As Object, e As ClausSoftware.LineNumerEventArgs)
        ' TODO: in der Dateiliste direkt den Fortschritt anzeigen lassen ? 

    End Sub


    ''' <summary>
    ''' Ruft die Dateiliste ab oder legt diese fest, die Importiert wreden soll
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileList As List(Of String)
        Get
            Return m_fileList
        End Get
        Set(value As List(Of String))
            m_fileList = value
        End Set
    End Property

    Friend Sub StartImport()
        m_datanormImporter.Filenames.Clear()

        'Dateinamen übertragen
        For Each fileName As String In Me.FileList
            m_datanormImporter.Filenames.Add(New ClausSoftware.SingleFile(fileName))
        Next

        m_datanormImporter.StartImportAsync()
    End Sub
End Class
