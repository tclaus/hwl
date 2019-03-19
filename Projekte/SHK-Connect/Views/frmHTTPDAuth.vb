

''' <summary>
''' Nummt Namen und Passwort an
''' </summary>
''' <remarks></remarks>
Public Class frmHTTPDAuth
    Private m_companyName As String = String.Empty

    Public Property HTTPCompanyName() As String
        Get
            Return m_companyName
        End Get
        Set(ByVal value As String)
            m_companyName = value
        End Set
    End Property

    Private Sub frmHTTPDAuth_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Text = HTTPCompanyName
    End Sub

    ReadOnly Property UserName As String
        Get
            Return txtName.Text
        End Get
    End Property


    ReadOnly Property Password As String
        Get
            Return txtPassword.Text
        End Get
    End Property
End Class