Namespace Kernel

    Public Interface ICommandLineArgumentsList
        Function GetCommandlineArguments() As CommandLineArgument()
    End Interface


    Public Class CommandLineManager
        Implements ICommandLineArgumentsList

        Public Function GetCommandlineArguments() As CommandLineArgument() Implements ICommandLineArgumentsList.GetCommandlineArguments
            Dim lst As New List(Of CommandLineArgument)
            Dim LangArg As New CommandLineArgument("/lang=<language>", "/lang=de-de ;   /lang=en ; /lang=en-us. Setzt die Oberflächensprache - und Kultur.", "/lang=de-de ;   /lang=en ; /lang=en-us. Sets the language and culture.")
            Dim DBArg As New CommandLineArgument("/db=<name>", "/db=connection. Startet HWL mit dem Namen der angegebenen Datenbankverbindung", "e.g.: /db=name. Starts HWL with the connectionname as current database.")

            lst.Add(LangArg)
            lst.Add(DBArg)
            Return lst.ToArray
        End Function
    End Class

    ''' <summary>
    ''' Stellt eine Markierung für eine Kammandozeile dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CommandLineArgument
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_UsageHelpText As String

        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_syntax As String

        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_usageHelpTextEnglish As String

        ''' <summary>
        ''' Ruft die Syntax ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Syntax() As String
            Get
                Return m_syntax
            End Get
            Set(ByVal value As String)
                m_syntax = value
            End Set
        End Property
        ''' <summary>
        ''' Ruft Hinweise zur Benutzung ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UsageTextGerman() As String
            Get
                Return m_UsageHelpText
            End Get
            Set(ByVal value As String)
                m_UsageHelpText = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den englischen Text ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UsageTextEnglish() As String
            Get
                Return m_usageHelpTextEnglish
            End Get
            Set(ByVal value As String)
                m_usageHelpTextEnglish = value
            End Set
        End Property




        ''' <summary>
        ''' Ruft einen Anzigetext für dieses Kommando ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return String.Format("{0,-20}, {1}", Syntax, UsageTextGerman)
        End Function

        Public Sub New(syntax As String, usageGerman As String, usageEnglish As String)
            Me.UsageTextEnglish = usageEnglish
            Me.UsageTextGerman = usageGerman
            Me.Syntax = syntax
        End Sub

    End Class

End Namespace