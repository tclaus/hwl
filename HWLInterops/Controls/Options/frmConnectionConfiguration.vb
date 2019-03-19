
''' <summary>
''' stellt ein formular bereit, das die Datenbankverbindungen verwaltet
''' </summary>
''' <remarks></remarks>
Public Class frmConnectionConfiguration

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmConnectionConfiguration_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IucOptionConnections1.Initialize()
        m_application.Languages.SetTextOnControl(Me)

    End Sub
End Class