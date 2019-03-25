Imports ClausSoftware.Tools
Imports ClausSoftware.Data


Namespace Kernel
    ''' <summary>
    ''' 'Hält eine Auflistung von Textvorlagen für Angebote / Rechnungen
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TextTemplates
        Inherits BaseCollection(Of TextTemplate)
        Implements IDataCollection

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)
            Initialize()
        End Sub


        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder

            DisplayProps.Append("Text;")
            Me.DisplayableProperties = DisplayProps.ToString
        End Sub
    End Class
End Namespace