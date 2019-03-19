
''' <summary>
''' Stellt ein Dialog bereit, in dem Benutzeraccounts angelegt oder geändert werden können
''' </summary>
''' <remarks></remarks>
Public Class frmUseredit

    Private m_user As ClausSoftware.Kernel.security.User

    ''' <summary>
    ''' Legt den bearbeiteten Benuztueraccount fest oder ruft diesen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UserAccount() As ClausSoftware.Kernel.security.User

        Get
            Return m_user
        End Get
        Set(ByVal value As ClausSoftware.Kernel.security.User)

            m_user = value
            txtSureName.Text = m_user.SureName
            txtFirstName.Text = m_user.Firstname
            txtLoginName.Text = m_user.Name

        End Set
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        m_user.SureName = txtSureName.Text
        m_user.Firstname = txtFirstName.Text
        m_user.Name = txtLoginName.Text

        'TODO: nur bei neuen Usern auch das Passwort ändern
        If txtPassword.Text = txtPassword1.Text Then
            m_user.SetPassword(txtPassword.Text, "")
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()


    End Sub

    Private Sub txtFirstName_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtFirstName.EditValueChanging, txtSureName.EditValueChanging
        If txtFirstName.Text.Length > 0 Then

            txtLoginName.Text = txtFirstName.Text.Substring(0, 1) & txtSureName.Text
        Else
            txtLoginName.Text = txtSureName.Text
        End If
    End Sub
End Class