Imports ClausSoftware.Tools

Namespace Kernel.NamedSettings

    Public Class TransactionSettings
        Private m_mainapplication As MainApplication

        Public Sub New(ByVal application As MainApplication)
            m_mainapplication = application
        End Sub


        ''' <summary>
        ''' Schaltet das anzeigen einer Benachrichtigung über unbezahlt Transaktionen ein oder aus.
        ''' Keine Systemeinstellung, sondern eine Benutzereinstellung.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SendUnpaidNoticeOnStartup() As Boolean
            Get
                Return CBool(m_mainapplication.Settings.GetSetting("SendUnpaidNoticeOnStartup", "Transactions", "FALSE"))
            End Get
            Set(ByVal value As Boolean)

                m_mainapplication.Settings.SetSetting("SendUnpaidNoticeOnStartup", "Transactions", value.ToString)
            End Set
        End Property


    End Class

End Namespace
