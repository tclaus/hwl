
''' <summary>
''' Stellt einen Container bereit, um allgemeine Workpanes (Arbeitsmodule) aufzunehmen
''' </summary>
''' <remarks></remarks>
Public Class frmModuleContainer

    Private m_module As HWLInterops.HWLModules

    Public Sub New(ByVal callingModule As HWLInterops.HWLModules)
        InitializeComponent()
        m_module = callingModule
    End Sub

    Private Sub frmModuleContainer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MainApplication.getInstance.Settings.SaveFormsPos(Me, m_module.ToString)

        MainApplication.getInstance.SendMessage("") ' alte Statusnachrichten löschen
    End Sub

    Private Sub frmModuleContainer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            If IucMainModule1.CloseModule() Then ' Löst das Schliessen - Ereignis aus
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frmModuleContainer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub



    Private Sub frmModuleContainer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IucMainModule1.Initialize(m_module)
        AddHandler IucMainModule1.Close, AddressOf IucMainModule1_Close

        MainApplication.getInstance.Languages.SetTextOnControl(Me)
        Me.Text = IucMainModule1.Displaytext
        MainApplication.getInstance.Settings.RestoreFormsPos(Me, m_module.ToString)



    End Sub

    ''' <summary>
    ''' Ruft das eigentliche Arbeitsmodul (die UI) ab, 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WorkingItem As mainControlContainer
        Get
            Return IucMainModule1.WorkingItem
        End Get
    End Property

    Private Sub IucMainModule1_Close(ByVal sender As Object, ByVal e As EventArgs)

        Me.Close()
    End Sub

    Private Sub frmModuleContainer_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown

        If e.KeyCode = Keys.Escape Then
            IucMainModule1.CloseModule()  ' Löst das Schliessen - Ereignis aus
        End If

    End Sub
End Class