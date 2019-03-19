Imports System
Imports System.Windows.Forms


Namespace HomeScreen

    ''' <summary>
    ''' Stellt eine Klasse bereit, die einen transparenten (nicht durchsichtig) Hintergrund bereitstellt, hinter dem noch eine Grafik zu sehen ist
    ''' </summary>
    ''' <remarks></remarks>
    Class MyFlowLayoutPanel
        Inherits FlowLayoutPanel

        Public Sub MyFlowLayoutPanel()
            'Me.SetStyle(ControlStyles.Opaque, True)
        End Sub

        <DebuggerStepThrough()> _
        Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)



            MyBase.OnPaintBackground(e)
        End Sub


    End Class

End Namespace
