

''' <summary>
''' Stellt eine Fehlerbehandlung bereit, die nur im absoluten Crash erschient
''' </summary>
''' <remarks></remarks>
Public Class MainErrorHandler

    Private m_currentException As Exception

    Public Property Currentexception() As Exception
        Get
            Return m_currentException
        End Get
        Set(ByVal value As Exception)
            m_currentException = value
        End Set
    End Property

    ''' <summary>
    ''' Initialisert das Application-Exception Handling
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()


        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppCrashHandler
        ' AddHandler System.Windows.Forms.Application.ThreadException, AddressOf Me.UnhandledException


    End Sub

    ''' <summary>
    ''' Behandelt eine allgemeine unbehandelte Ausnahme, die nicht zu einem Programmabbruch führt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub UnhandledException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        'Dann ist kein Rekursiver aufruf möglich 

        'MainApplication.getInstance.UserStats.SendStatistics(ClausSoftware.Tools.ReportMessageType.ApplicationCrash, "Application", "Crash with: " & e.Exception.ToString)

        'RemoveHandler System.Windows.Forms.Application.ThreadException, AddressOf UnhandledException
        Currentexception = e.Exception

        Dim errorForm As New frmErrorMessage()

        errorForm.ErrorHandler = Me

        errorForm.ShowDialog()
        ' ein CrashHandler, und ein Apphandler

    End Sub

    ''' <summary>
    ''' Enthält die Senke in der alle ausnahmen einlaufen, die zu einem Programmabbruch führen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub AppCrashHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        'Dann ist kein Rekursiver aufruf möglich 

        'MainApplication.getInstance.UserStats.SendStatistics(ClausSoftware.Tools.ReportMessageType.ApplicationCrash, "Application", "Crash with: " & e.Exception.ToString)
        Try
            RemoveHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppCrashHandler
            Currentexception = CType(e.ExceptionObject, Exception)

            Dim errorForm As New frmErrorMessage()

            errorForm.ErrorHandler = Me

            errorForm.ShowDialog()
        Catch
        End Try

    End Sub

    Dim md5Generator As New System.Security.Cryptography.MD5CryptoServiceProvider()

    ''' <summary>
    ''' Ermittelt von einer gegebenen Ausnahme einen eindeutigen Hashwert, um verschiedene Fehlerzustände identifizieren zu können
    ''' </summary>
    Friend Function GetExceptionHashID() As Long
        Return GetExceptionHashID(Me.m_currentException)
    End Function

    ''' <summary>
    ''' Ermittelt von einer gegebenen Ausnahme einen eindeutigen Hashwert, um verschiedene Fehlerzustände identifizieren zu können
    ''' </summary>
    ''' <param name="ex">Eine Ausnahme, die Rekursiv bis zur Basis untersucht wird</param>
    ''' <returns>Einen Hashwert, der die Ausnahme und den gesamten Stacktrace bis zur Baiss identifiziert</returns>
    ''' <remarks></remarks>
    Friend Function GetExceptionHashID(ByVal ex As Exception) As Long
        Dim retVal As Long
        retVal = ex.StackTrace.GetHashCode
        If ex.InnerException IsNot Nothing Then
            retVal += GetExceptionHashID(ex.InnerException)
        End If
        Return retVal
    End Function

    ''' <summary>
    ''' Sendet die Fehlernachricht an einen Empänger
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub SendErrorReport()
        Throw New NotImplementedException("Diese Methode ist noch nicht erstellt worden.")
    End Sub

    ''' <summary>
    ''' Ruft allgemeine Daten ab, die für die Analyse relevant sein könnten
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSessionDetails() As String
        Dim tmp As New System.Text.StringBuilder

        tmp.AppendLine("Product:     " & My.Application.Info.ProductName)
        tmp.AppendLine("Application: " & My.Application.Info.Title)
        tmp.AppendLine("Version:     " & My.Application.Info.Version.ToString)

        tmp.AppendLine("DirPath:     " & My.Application.Info.DirectoryPath)
        tmp.AppendLine("Culture:     " & My.Application.Culture.ToString)

        ' Computer-Info
        tmp.AppendLine("OS:               " & My.Computer.Info.OSFullName & " V." & My.Computer.Info.OSVersion)
        tmp.AppendLine("Total Memory:     " & Math.Truncate((My.Computer.Info.TotalPhysicalMemory / 1024) / 1024) & " KB")
        tmp.AppendLine("Available Memory: " & Math.Truncate((My.Computer.Info.AvailablePhysicalMemory / 1024) / 1024) & " KB")

        tmp.AppendLine("Screen Size:      " & My.Computer.Screen.Bounds.Width & "x" & My.Computer.Screen.Bounds.Height & ", " & My.Computer.Screen.BitsPerPixel & "Bit Color, " & Screen.AllScreens.Length & " Screens")


        tmp.AppendLine("Processors:       " & System.Environment.ProcessorCount & " cores")

        Return tmp.ToString


    End Function


End Class

''' <summary>
''' Stellt eine Klasse bereit, die Fehlerinformationen enthält
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Class ErrorReport

    Sub test()


    End Sub

    Private m_exceptionStack As String

    Private m_Osversion As String

    Private m_osPlatform As String

    Private m_OsFullName As String

    Private m_UICulture As String

    Private m_screenResulution As String

    Private m_AssemblyVersion As Version

    Private m_exceptionName As String
    ''' <summary>
    ''' Name der Ausnahme
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property exceptionName() As String
        Get
            Return m_exceptionName
        End Get
        Set(ByVal value As String)
            m_exceptionName = value
        End Set
    End Property

    Public Property AssemblyVersion() As Version
        Get
            Return m_AssemblyVersion
        End Get
        Set(ByVal value As Version)
            m_AssemblyVersion = value
        End Set
    End Property

    Public Property ScreenResulution() As String
        Get
            Return m_screenResulution
        End Get
        Set(ByVal value As String)
            m_screenResulution = value
        End Set
    End Property

    Public Property UICultureName() As String
        Get
            Return m_UICulture
        End Get
        Set(ByVal value As String)
            m_UICulture = value
        End Set
    End Property

    Public Property OSFullName() As String
        Get
            Return m_OsFullName
        End Get
        Set(ByVal value As String)
            m_OsFullName = value
        End Set
    End Property

    Public Property OsPlatform() As String
        Get
            Return m_osPlatform
        End Get
        Set(ByVal value As String)
            m_osPlatform = value
        End Set
    End Property

    Public Property OsVersion() As String
        Get
            Return m_Osversion
        End Get
        Set(ByVal value As String)
            m_Osversion = value
        End Set
    End Property

    ''' <summary>
    ''' Aufrufstack, in der obersten Methode wurde die Ausnahme ausgelöst
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ExceptionStack() As String
        Get
            Return m_exceptionStack
        End Get
        Set(ByVal value As String)
            m_exceptionStack = value
        End Set
    End Property


End Class