''' <summary>
''' Stellt ein Formular bereit, das die Zugangsdaten einer Firma enthält
''' </summary>
''' <remarks></remarks>
Public Class frmEnterCompanyCredentials
    Private m_credentials As CompanyCredential

    ''' <summary>
    ''' Ruft die Unternehmensdaten ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Credentials() As CompanyCredential
        Get
            Return m_credentials
        End Get
        Set(ByVal value As CompanyCredential)
            m_credentials = value
            Fillcontrols()
        End Set
    End Property


    Private m_companyName As String = String.Empty

    Public Property CredentialCompanyName() As String
        Get
            Return m_companyName
        End Get
        Set(ByVal value As String)
            m_companyName = value
        End Set
    End Property


    ''' <summary>
    ''' Erstellt 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateCredentialData()
        m_credentials = New CompanyCredential
        m_credentials.Password = txtPassword.Text
        m_credentials.UserId = txtUserID.Text
        m_credentials.Username = txtUserName.Text

    End Sub

    Private Sub Fillcontrols()
        If m_credentials IsNot Nothing Then
            With m_credentials
                txtPassword.Text = .Password
                txtUserID.Text = .UserId
                txtUserName.Text = .Username
            End With
        Else
            txtPassword.Text = String.Empty
            txtUserID.Text = String.Empty
            txtUserName.Text = String.Empty

        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        CreateCredentialData()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmEnterCompanyCredentials_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Text &= " (" & Me.CredentialCompanyName & ")"
    End Sub
End Class