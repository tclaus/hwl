
''' <summary>
''' Stellt einen Benutzer - Logindialog in HWL dar.
''' </summary>
''' <remarks></remarks>
Public Class frmLoginDlg

    Private m_loginOK As Boolean

    ''' <summary>
    ''' Liefert True zurück, wenn das Benutzerlogin erfolgreich war
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LoginOK() As Boolean
        Get
            Return m_loginOK
        End Get

    End Property


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If MainApplication.getInstance.Users.Count > 0 Then
            Dim loginname As ClausSoftware.Kernel.Security.User = MainApplication.getInstance.Users.Find(txtUsername.Text)
            If loginname IsNot Nothing Then
                If loginname.CheckPassword(txtPassword.Text) Then
                    m_loginOK = True
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If

            m_loginOK = False
            Dim cl As New Vista_Api.CommandDialog
            'TODO: NLS
            cl.Text = "Geben Sie einen gültigen Benutzernamen und ein gültiges Passwort ein"
            cl.Title = "Benutzername oder Passwort falsch"
            cl.ShowDialog()
        Else
            ' Es gibt keinen Benutzer =>
            m_loginOK = True
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub frmLoginDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

    End Sub
End Class