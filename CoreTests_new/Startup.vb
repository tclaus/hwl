Imports NUnit.Framework
Imports ClausSoftware

''' <summary>
''' Markiert das Starten der Datenbank und herstellen der Verbindung zum Test-Server
''' </summary>
''' <remarks></remarks>
<SetUpFixture()> _
Public Class StartUp

    ''' <summary>
    ''' Schliesst die Applikation wieder
    ''' </summary>
    ''' <remarks></remarks>
    <NUnit.Framework.TearDown()> _
    Public Sub CloseApp()
        Debug.Print("Close Test Suite")
        MainApplication.getInstance.CloseConnection()
        Debug.Print("All Tests ended")
    End Sub

    ''' <summary>
    ''' TestStart, stellt verknüpfung zu einer Test-Datenbank her
    ''' </summary>
    ''' <remarks></remarks>
    <SetUp()>
    Public Sub Start()
        ' Starte Framework

        Debug.Print("Startup Test Suite")

        Dim connection As New Tools.Connection

        'Test-Datenbank
        connection.Database = "HWL_develop"
        connection.Password = "xy123za"
        connection.Path = ""
        connection.ServerHostName = "hwl-developer.de"
        connection.Servertype = Tools.enumServerType.MySQL

        connection.Username = "usr_hwldev"
        Dim result As Boolean


        MainApplication.getInstance.Connections.DefaultConnection = connection

        result = MainApplication.getInstance.Initialize(connection)

        Debug.Assert(result, "Keine Verbindung mit Datenbank möglich. Test abgebrochen.")


        m_Gui = New ClausSoftware.HWLInterops.MainUI(New System.Windows.Forms.Form)

        MainApplication.getInstance.Settings.SettingSendStatistics = False  ' Statistiken unterdrücken
        Debug.Print("Exiting Setup Tests")
    End Sub

End Class
