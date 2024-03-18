Imports System.Threading
Imports System.Runtime.InteropServices

''' <summary>
''' Stellt einen automatisch arbeitenden Warte-Zustand des Cursors bereit
''' </summary>
''' <remarks></remarks>
<DebuggerStepThrough()> _
Friend Class AutoWaitCursor


#Region " Private Attributes..."



    ''' <summary>
    ''' The default TimeSpan to wait before showing the auto wait cursor.
    ''' </summary>
    Private Shared DEFAULT_DELAY As New TimeSpan(0, 0, 0, 0, 25)

    ''' <summary>
    ''' The application state monitor class (which monitors the application busy status).
    ''' </summary>
    Private Shared _appStateMonitor As New ApplicationStateMonitor(Cursors.WaitCursor, DEFAULT_DELAY)

#End Region
#Region " Constructors..."
    ''' <summary>
    ''' Initializes a new instance of the <see cref="T:AutoWaitCursor" /> class.
    ''' </summary>
    ''' <remarks>Intentionally hidden.</remarks>
    Private Sub New()
        'Do nothing
    End Sub

#End Region

#Region " Public Static Properties..."
    ''' <summary>
    ''' Returns the amount of time the application has been idle.
    ''' </summary>
    Public ReadOnly Property ApplicationIdleTime() As TimeSpan
        Get
            Return _appStateMonitor.ApplicationIdleTime
        End Get
    End Property

    ''' <summary>
    ''' Returns true if the auto wait cursor has been started.
    ''' </summary>
    Public Shared ReadOnly Property IsStarted() As Boolean
        Get
            Return _appStateMonitor.IsStarted
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the Cursor to use during Application busy periods.
    ''' </summary>
    Public Shared Property Cursor() As Cursor
        Get
            Return _appStateMonitor.Cursor
        End Get
        Set(ByVal value As Cursor)
            _appStateMonitor.Cursor = value
        End Set
    End Property

    ''' <summary>
    ''' Enables or disables the auto wait cursor.
    ''' </summary>
    Public Shared Property Enabled() As Boolean
        Get
            Return _appStateMonitor.Enabled
        End Get
        Set(ByVal value As Boolean)
            _appStateMonitor.Enabled = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the period of Time to wait before showing the WaitCursor whilst Application is working
    ''' </summary>
    Public Shared Property Delay() As TimeSpan
        Get
            Return _appStateMonitor.Delay
        End Get
        Set(ByVal value As TimeSpan)
            _appStateMonitor.Delay = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the main window handle of the application (ie the handle of an MDI form).
    ''' This is the window handle monitored to detect when the application becomes busy.
    ''' </summary>
    Public Shared Property MainWindowHandle() As IntPtr
        Get
            Return _appStateMonitor.MainWindowHandle
        End Get
        Set(ByVal value As IntPtr)
            _appStateMonitor.MainWindowHandle = value
        End Set
    End Property

#End Region

#Region " Public Methods..."

    ''' <summary>
    ''' Starts the auto wait cursor monitoring the application.
    ''' </summary>
    Public Shared Sub Start()
        AutoWaitCursor.Start(AutoWaitCursor.MainWindowHandle)
    End Sub

    ''' <summary>
    ''' Starts the auto wait cursor monitoring the application.
    ''' </summary>
    ''' <param name="mainWindowHandle">Specifies the main window handle of the application
    ''' (ie the handle of an MDI form).</param>
    Public Shared Sub Start(ByVal mainWindowHandle As IntPtr)
        AutoWaitCursor.MainWindowHandle = mainWindowHandle

        _appStateMonitor.Start()
    End Sub

    ''' <summary>
    ''' Stops the auto wait cursor monitoring the application.
    ''' </summary>
    Public Shared Sub [Stop]()
        _appStateMonitor.Stop()
    End Sub

#End Region

#Region " Private Class ApplicationStateMonitor..."

    ''' <summary>
    ''' Private class that monitors the state of the application and automatically
    ''' changes the cursor accordingly.
    ''' </summary>
    Private Class ApplicationStateMonitor : Implements IDisposable

#Region " Private Attributes..."

        ''' <summary>
        ''' The time the application became inactive.
        ''' </summary>
        Private m_inactiveStart As DateTime = DateTime.Now

        ''' <summary>
        ''' If the monitor has been started.
        ''' </summary>
        Private m_isStarted As Boolean

        ''' <summary>
        ''' Delay to wait before calling back
        ''' </summary>
        Private m_delay As TimeSpan

        ''' <summary>
        ''' The windows handle to the main process window.
        ''' </summary>
        Private m_mainWindowHandle As IntPtr = IntPtr.Zero

        ''' <summary>
        ''' Thread to perform the wait and callback
        ''' </summary>
        Private m_callbackThread As Thread

        ''' <summary>
        ''' Stores if the class has been disposed of.
        ''' </summary>
        Private m_isDisposed As Boolean

        ''' <summary>
        ''' Stores if the class is enabled or not.
        ''' </summary>
        Private m_enabled As Boolean = True

        ''' <summary>
        ''' GUI Thread Id .
        ''' </summary>
        Private m_mainThreadId As System.UInt32


        ''' <summary>
        ''' Callback Thread Id.
        ''' </summary>
        Private m_callbackThreadId As System.UInt32

        ''' <summary>
        ''' Stores the old cursor.
        ''' </summary>
        Private m_oldCursor As Cursor

        ''' <summary>
        ''' Stores the new cursor.
        ''' </summary>
        Private m_waitCursor As Cursor

#End Region

#Region " Constants..."

        ''' <summary>
        ''' API-Konstante
        ''' </summary>
        ''' <remarks></remarks>
        Private Const SMTO_NORMAL As Integer = &H0

        ''' <summary>
        ''' API-Konstante
        ''' </summary>
        ''' <remarks></remarks>
        Private Const SMTO_BLOCK As Integer = &H1

        ''' <summary>
        ''' API - Konstante
        ''' </summary>
        ''' <remarks></remarks>
        Private Const SMTO_NOTIMEOUTIFNOTHUNG As Integer = &H8

#End Region

#Region " API (PInvoke) Declarations..."

        ''' <summary>
        ''' Sendet eine Nachricht, das eine Zeitspanne angelaufen ist.
        ''' </summary>
        ''' <param name="hWnd"></param>
        ''' <param name="Msg"></param>
        ''' <param name="wParam"></param>
        ''' <param name="lParam"></param>
        ''' <param name="fuFlags"></param>
        ''' <param name="uTimeout"></param>
        ''' <param name="lpdwResult"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass")> <DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto, SetLastError:=True)> _
      Private Shared Function SendMessageTimeout(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As String, ByVal fuFlags As Integer, ByVal uTimeout As Integer, ByRef lpdwResult As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        ''' <summary>
        ''' Fügt einen Beobachter zu der angegebenen ThreadID hinzu.
        ''' </summary>
        ''' <param name="attachTo"></param>
        ''' <param name="attachFrom"></param>
        ''' <param name="attach"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass")> <CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1414:MarkBooleanPInvokeArgumentsWithMarshalAs")> <DllImport("USER32.DLL")> _
      Private Shared Function AttachThreadInput(ByVal attachTo As System.UInt32, ByVal attachFrom As System.UInt32, ByVal attach As Boolean) As System.UInt32
        End Function

        ''' <summary>
        ''' Ermittelt die aktuelle ThredaID, die überwacht werden soll
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass")> <DllImport("KERNEL32.DLL")> _
        Private Shared Function GetCurrentThreadId() As System.UInt32
        End Function

#End Region

#Region " Constructors..."
        ''' <summary>
        ''' Default member initialising Constructor.
        ''' </summary>
        ''' <param name="waitCursor">The wait cursor to use.</param>
        ''' <param name="delay">The delay before setting the cursor to the wait cursor.</param>
        Public Sub New(ByVal waitCursor As Cursor, ByVal delay As TimeSpan)
            'Constructor is called from (what is treated as) the main thread
            m_mainThreadId = GetCurrentThreadId()
            m_delay = delay
            m_waitCursor = waitCursor

            'Gracefully shuts down the state monitor
            AddHandler Application.ThreadExit, AddressOf OnApplicationThreadExit
        End Sub 'New

#End Region

#Region " IDisposable Interface Methods..."

        ''' <summary>
        ''' On Disposal terminates the Thread, calls Finish (on thread) if Start has been called
        ''' </summary>
        Public Sub Dispose() Implements IDisposable.Dispose
            If (m_isDisposed) Then
                Return
            End If

            'Kills the Thread loop
            m_isDisposed = True
        End Sub 'Dispose

#End Region

#Region " Public Properties..."

        ''' <summary>
        ''' Returns true if the auto wait cursor has been started.
        ''' </summary>
        Public ReadOnly Property IsStarted() As Boolean
            Get
                Return m_isStarted
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the main window handle of the application (ie the handle of an MDI form).
        ''' This is the window handle monitored to detect when the application becomes busy.
        ''' </summary>
        Public Property MainWindowHandle() As IntPtr
            Get
                Return m_mainWindowHandle
            End Get
            Set(ByVal value As IntPtr)
                m_mainWindowHandle = value
            End Set
        End Property


        ''' <summary>
        ''' Gets or sets the Cursor to show.
        ''' </summary>
        Public Property Cursor() As Cursor
            Get
                Return m_waitCursor
            End Get
            Set(ByVal value As Cursor)
                m_waitCursor = value
            End Set
        End Property

        ''' <summary>
        ''' Returns the amount of time the application has been idle.
        ''' </summary>
        Public ReadOnly Property ApplicationIdleTime() As TimeSpan
            Get
                Return DateTime.Now.Subtract(m_inactiveStart)
            End Get
        End Property

#End Region

#Region " Public Methods..."

        ''' <summary>
        ''' Starts the application state monitor.
        ''' </summary>
        Public Sub Start()
            If (Not m_isStarted) Then
                m_isStarted = True

                Me.CreateMonitorThread()
            End If
        End Sub

        ''' <summary>
        ''' Stops the application state monitor.
        ''' </summary>
        Public Sub [Stop]()
            If (m_isStarted) Then
                m_isStarted = False
            End If
        End Sub

        ''' <summary>
        ''' Set the Cursor to wait.
        ''' </summary>
        Public Sub SetWaitCursor()
            'Start is called in a new Thread, grab the new
            ' Thread Id so we can attach to Main thread's input
            m_callbackThreadId = GetCurrentThreadId()

            'Have to call this before calling Cursor.Current
            AttachThreadInput(m_callbackThreadId, m_mainThreadId, True)

            m_oldCursor = Windows.Forms.Cursor.Current
            Windows.Forms.Cursor.Current = m_waitCursor
        End Sub

        ''' <summary>
        ''' Finish showing the Cursor (switch back to previous Cursor).
        ''' </summary>
        Public Sub RestoreCursor()
            'Restore the cursor
            Windows.Forms.Cursor.Current = m_oldCursor

            'Detach from Main thread input

            AttachThreadInput(m_callbackThreadId, m_mainThreadId, False)
        End Sub

        ''' <summary>
        ''' Enable/Disable the call to Start (note, once Start is called it *always* calls the paired Finish).
        ''' </summary>
        Public Property Enabled() As Boolean
            Get
                Return m_enabled
            End Get
            Set(ByVal value As Boolean)
                m_enabled = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the period of Time to wait before calling the Start method.
        ''' </summary>
        Public Property Delay() As TimeSpan
            Get
                Return m_delay
            End Get
            Set(ByVal value As TimeSpan)
                m_delay = value
            End Set
        End Property


#End Region

#Region " Private Methods..."


        ''' <summary>
        ''' Prepares the class creating a Thread that monitors the main application state.
        ''' </summary>
        Private Sub CreateMonitorThread()
            'Create the monitor thread
            m_callbackThread = New Thread(New ThreadStart(AddressOf ThreadCallbackLoop))
            m_callbackThread.Name = "AutoWaitCursorCallback"
            m_callbackThread.IsBackground = True

            'Start the thread
            m_callbackThread.Start()
        End Sub

        ''' <summary>
        ''' Thread callback method.
        ''' Loops calling SetWaitCursor and RestoreCursor until Disposed.
        ''' </summary>
        Private Sub ThreadCallbackLoop()
            Try
                Do
                    If Not m_enabled OrElse m_mainWindowHandle = IntPtr.Zero Then
                        'Just sleep
                        Thread.Sleep(m_delay)
                    Else
                        'Wait for start
                        If IsApplicationBusy(m_delay, m_mainWindowHandle) Then
                            Try
                                Me.SetWaitCursor()
                                WaitForIdle()
                            Finally
                                ' Always calls Finish (even if we are Disabled)
                                Me.RestoreCursor()
                                ' Store the time the application became inactive
                                m_inactiveStart = DateTime.Now
                            End Try
                        Else
                            ' Wait before checking again
                            Thread.Sleep(25)
                        End If
                    End If
                Loop While Not m_isDisposed AndAlso m_isStarted
            Catch
                'The thread is being aborted, just reset the abort
                '   and exit gracefully
                Thread.ResetAbort()
            End Try
        End Sub


        ''' <summary>
        ''' Blocks until the application responds to a test message.
        ''' If the application doesn't respond with the timespan, will return false,
        ''' else returns true.
        ''' </summary>
        <CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")> Private Function IsApplicationBusy(ByVal delay As TimeSpan, ByVal windowHandle As IntPtr) As Boolean
            Const INFINITE As Integer = Int32.MaxValue
            Const WM_NULL As Integer = 0

            Dim result As Integer = 0

            Dim success As Boolean = False


            'See if the application is responding
            If (delay = TimeSpan.MaxValue) Then
                success = SendMessageTimeout(windowHandle, WM_NULL, 0, Nothing, SMTO_BLOCK, INFINITE, result)
            Else
                success = SendMessageTimeout(windowHandle, WM_NULL, 0, Nothing, SMTO_BLOCK, System.Convert.ToInt32(delay.TotalMilliseconds), result)
            End If

            If result <> 0 Then
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' Waits for the ResetEvent (set by Dispose and Reset),
        ''' since Start has been called we *have* to call RestoreCursor once the thread is idle again.
        ''' </summary>
        Private Sub WaitForIdle()
            'Wait indefinately until the application is idle
            IsApplicationBusy(TimeSpan.MaxValue, m_mainWindowHandle)
        End Sub

        ''' <summary>
        ''' The application is closing, shut the state monitor down.
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        Private Sub OnApplicationThreadExit(ByVal sender As Object, ByVal e As EventArgs)
            Me.Dispose()
        End Sub

#End Region

    End Class

#End Region

End Class
