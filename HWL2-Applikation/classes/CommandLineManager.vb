
Public Class CommandLineManager
        Public Shared Function GetAllAttributes() As String
            Dim c As New ClausSoftware.Kernel.CommandLineManager
            c.GetCommandlineArguments()

            Dim commandLines As String = String.Empty

            For Each item As Kernel.CommandLineArgument In c.GetCommandlineArguments
                commandLines &= item.ToString & Environment.NewLine
            Next

            Return commandLines
        End Function

    End Class
