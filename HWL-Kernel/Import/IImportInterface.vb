Namespace AddIns

    ''' <summary>
    ''' Provices an Interface for communicating with Kernnel (to make Import / Export functionalities, AKA 'Connectors') 
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IImportAddIn

        ''' <summary>
        ''' Provides an uniue ID to identify this Addon 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Should be a Kind of GUID - String (32 characters) </remarks>
        ReadOnly Property UniqeID As String


        ''' <summary>
        ''' Initializes the Connector and sets up a conenction to the main Kernel
        ''' </summary>
        ''' <remarks></remarks>
        Sub StartUp(ByVal rootApplication As mainApplication)

        ''' <summary>
        ''' Returns the Displayname of this connector
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property DisplayName() As String

        ''' <summary>
        ''' A long description of what this connector does and How
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property LongDescription() As String


        ''' <summary>
        ''' Shows the GUI of the AddIn
        ''' </summary>
        ''' <remarks></remarks>
        Sub Show()

        ''' <summary>
        ''' Provides methodes to safely shutdown all running processes in this Addin
        ''' </summary>
        ''' <remarks></remarks>
        Sub ShutDown()

        ''' <summary>
        ''' If this Addin is inititially Loaded is a immediate Startup will be done if this returns True. 
        ''' Normaly this returns false since a startup is only needed if a user action is invoked.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ShouldStartupOnStart As Boolean


    End Interface
End Namespace

