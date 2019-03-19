
Public Class ImporterController

    Private m_application As ClausSoftware.mainApplication
    Private m_datanorm As New DatanormParser()
    Private m_filenameList As New List(Of SingleFile)

    Public Event ReadLineNumber(ByVal sender As Object, ByVal e As LineNumerEventArgs)
    Public Event Message(sender As Object, e As MessageEventArgs)

    Public Event EndReading(sender As Object, e As EventArgs)

    Private threadStartParameters As New Threading.ThreadStart(AddressOf StartImport)
    Private threadImportData As Threading.Thread

    Sub New(ByVal mainApplication As ClausSoftware.mainApplication)
        ' TODO: Complete member initialization 
        m_application = mainApplication

        AddHandler m_datanorm.LineRead, AddressOf FireLineRead
        AddHandler m_datanorm.Message, AddressOf FireMessageSent
    End Sub

    ''' <summary>
    ''' Ruft das Stammobjekt ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property Application As ClausSoftware.mainApplication
        Get
            Return m_application
        End Get
    End Property

    Friend Sub ShowDialog()
        Dim frm As New frmDatanormImport(Me)
        frm.Show()
    End Sub

    ''' <summary>
    ''' Ruft den dateinamen ab oder legt den fest, der eingelesen  werden soll
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Filenames As List(Of SingleFile)
        Get
            Return m_filenameList
        End Get
        Set(ByVal value As List(Of SingleFile))
            m_filenameList = value
        End Set
    End Property

    ''' <summary>
    ''' Startet den Import-Vorgang
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartImportAsync()
        Static isWorking As Boolean
        If isWorking Then Exit Sub
        isWorking = True

        threadImportData = New Threading.Thread(threadStartParameters)
        threadImportData.Name = "Datanorm Importer"
        threadImportData.Start()

        isWorking = False

    End Sub

    ''' <summary>
    ''' Ist wahr, wenn der Import-Vorgang gerade läuft
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsRunning As Boolean
        Get
            If threadImportData IsNot Nothing Then
                Return threadImportData.IsAlive
            Else
                Return False
            End If

        End Get
    End Property

    ''' <summary>
    ''' Bricht den aktuellen Thread ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CancelImport()
        If threadImportData IsNot Nothing Then
            If threadImportData.IsAlive Then
                threadImportData.Abort()
            End If
        End If
    End Sub

    ' ''' <summary>
    ' ''' Ruft die erste Zeile des Datensatzes ab, ohne die Datei komplett zu lesen
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function GetFirstLine(fileName As String) As String
    '    m_datanorm.FileName = fileName
    '    Return m_datanorm.GetFirstLine
    'End Function


    ''' <summary>
    ''' Startet den Datanorm-Importvorgang Asynchron (bald) 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartImport()

        ' Datei liste Sortieren: warengruppen vorne!
        ' Rabatte vorne

        m_filenameList.Sort(New SortByextenstion)


        For Each fileItem As SingleFile In m_filenameList
            If Not fileItem.Loaded Then
                m_datanorm.FileName = fileItem
                m_datanorm.StartImport()
                fileItem.Loaded = True
                RaiseEvent EndReading(Me, EventArgs.Empty)
            End If
        Next


    End Sub



    Private Sub FireLineRead(ByVal sender As Object, ByVal e As LineNumerEventArgs)
        RaiseEvent ReadLineNumber(sender, e)
    End Sub

    Private Sub FireMessageSent(sender As Object, e As MessageEventArgs)
        RaiseEvent Message(sender, e)
    End Sub

End Class
