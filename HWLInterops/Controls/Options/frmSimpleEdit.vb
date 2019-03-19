Imports ClausSoftware.Kernel

Public Class frmSimpleEdit
    Friend Sub New(ByVal datasource As DataSourceList)

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        SimpleEdit.Init(datasource)

    End Sub

    Private Sub SimpleEdit_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles SimpleEdit.Close
        SimpleEdit.Save()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

   
    Private Sub SimpleEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleEdit.Load
        m_application.Languages.SetTextOnControl(Me)

    End Sub
End Class