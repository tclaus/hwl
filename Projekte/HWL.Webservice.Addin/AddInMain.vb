Public Class AddInMain
    Implements ClausSoftware.AddIns.IImportAddIn


    ''' <summary>
    ''' Ruft den anzeigenamen für den webdienst ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayName As String Implements ClausSoftware.AddIns.IImportAddIn.DisplayName
        Get
            Return "HWL Webservice"
        End Get
    End Property

    Public ReadOnly Property LongDescription As String Implements ClausSoftware.AddIns.IImportAddIn.LongDescription
        Get
            Return "Enthält eine Schnittstelle um HWL-Daten von anderen Plattformen und Geräten bereitzustellen. " & vbCrLf & _
                "Dienst enthält keine Anzeige"
        End Get
    End Property

    Public Sub Show() Implements ClausSoftware.AddIns.IImportAddIn.Show
        ' Nicht Implementiert - keine Anzeige

    End Sub

    Private m_hostservice As HostService

    Public Sub StartUp(rootApplication As ClausSoftware.mainApplication) Implements ClausSoftware.AddIns.IImportAddIn.StartUp
        If m_hostservice Is Nothing Then
            m_hostservice = New HostService

            m_hostservice.StartService()

        End If


    End Sub

    ''' <summary>
    ''' Ruft eine eindeutige Kennzeichnung für diesen Dienst ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UniqeID As String Implements ClausSoftware.AddIns.IImportAddIn.UniqeID
        Get
            Return "C7E23C0F-52AC-434B-B32F-4256371C8F6F"
        End Get
    End Property

    Public ReadOnly Property ShouldStartupOnStart As Boolean Implements ClausSoftware.AddIns.IImportAddIn.ShouldStartupOnStart
        Get
            Return True
        End Get
    End Property

    Public Sub ShutDown() Implements ClausSoftware.AddIns.IImportAddIn.ShutDown
        m_hostservice.StopService()
    End Sub
End Class
