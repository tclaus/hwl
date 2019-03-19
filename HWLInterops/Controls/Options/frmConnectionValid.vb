Public Class frmConnectionValid


    Private m_dbResult As ClausSoftware.DataBase.DBResult
    ''' <summary>
    ''' Gibt den aktuellen Stats der DAtenbank zurück oder legt diesen fest, um eine Ausgabe zu erzeugen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DBResult() As ClausSoftware.DataBase.DBResult
        Get
            Return m_dbResult
        End Get
        Set(ByVal value As ClausSoftware.DataBase.DBResult)
            m_dbResult = value
        End Set
    End Property


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmConnectionValid_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If DBResult.IsValid Then
            PictureBox1.Image = My.Resources.Settings_Check_48x48
            Me.Text = GetText("ValidConnection", "Verbindung gültig")
            lblHeadline.Text = GetText("EstablishedDatabaseConnection", "Verbindung zur Datenbank konnte hergestellt werden")
            lblBody.Text = ""
            lblSolution.Text = ""
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        Else
            PictureBox1.Image = My.Resources.Settings_Warning_48x48
            Me.Text = GetText("InvalidConnection", "Verbindung ungültig")
            lblHeadline.Text = GetText("CouldNotEstablishDatabaseConnection", "Verbindung zur Datenbank konnte nicht hergestellt werden")
            lblBody.Text = DBResult.ErrorText
            lblSolution.Text = DBResult.Solution
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If

    End Sub

End Class