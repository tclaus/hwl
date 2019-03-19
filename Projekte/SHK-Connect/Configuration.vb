

''' <summary>
''' Stellt eine lokale Konfiguration bereit
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class Configuration
    Private m_localDownloadPath As String

    Private m_companyPasswords As New List(Of CompanyCredential)

    ''' <summary>
    ''' Ruft eine Auflistung von Firmen-Passwörtern ab 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Kombination aus Firmenname und deren Passswörter</remarks>
    Public Property CompanyPasswords() As List(Of CompanyCredential)
        Get
            Return m_companyPasswords
        End Get
        Set(ByVal value As List(Of CompanyCredential))
            m_companyPasswords = value
        End Set
    End Property


    ''' <summary>
    ''' Ruft den Pfad ab in dem die Dateien geladen werden sollen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LocalDownloadPath() As String
        Get
            Return m_localDownloadPath
        End Get
        Set(ByVal value As String)
            m_localDownloadPath = value
        End Set
    End Property

End Class
