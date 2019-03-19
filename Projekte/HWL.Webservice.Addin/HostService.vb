Imports System.ServiceModel
Imports System.ServiceModel.Description

''' <summary>
''' Stellt Funktionen zum bereitstekllen des Dienstes bereit
''' </summary>
''' <remarks></remarks>
Public Class HostService

    Private m_baseAddress As Uri = New Uri("http://192.168.0.151:8080/")
    Private host As Web.WebServiceHost

    ''' <summary>
    ''' Ruft die Basisadresse des Dienstes ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BaseAddress As Uri
        Get

            Return m_baseAddress
        End Get
        Set(value As Uri)

        End Set
    End Property

    ''' <summary>
    ''' Startet den Dienstservice. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartService()
        ' Create the ServiceHost.
        Try
            Dim singeltonInstance As New HWLService()

            host = New Web.WebServiceHost(singeltonInstance, BaseAddress)

            ' Enable metadata publishing.
            Dim smb As New ServiceMetadataBehavior()
            smb.HttpGetEnabled = True


            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15
            host.Description.Behaviors.Add(smb)


            Dim wsBinding As New WebHttpBinding(WebHttpSecurityMode.None)

            'Add Relative Address
            host.AddServiceEndpoint(GetType(IHWLService), wsBinding, "HWLService")

            AddHandler host.Closed, AddressOf HostClosed
            AddHandler host.Faulted, AddressOf HostFaulted
            AddHandler host.Opened, AddressOf HostOpend
            AddHandler host.UnknownMessageReceived, AddressOf HostUnknownMessageReceived


            ' Open the ServiceHost to start listening for messages. Since
            ' no endpoints are explicitly configured, the runtime will create
            ' one endpoint per base address for each service contract implemented
            ' by the service.
            host.Open()

            Console.WriteLine("The service is ready at {0}", BaseAddress)

        Catch ex As Exception
            Console.WriteLine("The service Failed  {0}", ex.Message)

        End Try


    End Sub

    Public Sub StopService()
        
        Debug.Print("Stoping Servcie..")
        ' Close the ServiceHost.
        host.Close()

    End Sub

    Private Sub HostClosed(sender As Object, e As EventArgs)
        Debug.Print("Host Closed")
    End Sub

    Private Sub HostFaulted(sender As Object, e As EventArgs)

        Debug.Print("Host Faulted")
    End Sub

    Private Sub HostOpend(sender As Object, e As EventArgs)
        Debug.Print("Host Opened")
    End Sub

    Private Sub HostUnknownMessageReceived(sender As Object, e As UnknownMessageReceivedEventArgs)
        Debug.Print("Host deteced an unknown Message:" & e.Message.ToString)
    End Sub

End Class
