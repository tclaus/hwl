Imports ClausSoftware.Tools

Namespace Kernel.NamedSettings
    ''' <summary>
    ''' Stellt beannte Eigenscharften für ArtikelListen zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ArticleListSettings

        Private m_mainApplication As MainApplication

        Friend Sub New(ByVal rootApplication As MainApplication)
            m_mainApplication = rootApplication
        End Sub

        ''' <summary>
        ''' Ruft den standard-steuersatz für Artikel ab osder legt diesen fest.
        ''' Standardwert ist der 'normale' Steuersatz.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DefaultTaxRate() As TaxRate
            Get
                Dim normalTaxRate As TaxRate = m_mainApplication.TaxRates.GetNormalTax
                ' Kann durch einen KOnfigurationsfehler "nothing" sein
                Dim normalTaxID As Integer
                If normalTaxRate IsNot Nothing Then
                    normalTaxID = normalTaxRate.ID
                End If

                Dim value As String = m_mainApplication.Settings.GetSetting(RegistryValues.ArticleDefaultTax, RegistrySections.ModuleArticles, normalTaxID.ToString)
                If Not String.IsNullOrEmpty(value) Then
                    Return m_mainApplication.TaxRates.GetItem(CInt(value))
                Else
                    Return m_mainApplication.TaxRates.GetNormalTax
                End If
                m_mainApplication.Log.sendLog()
            End Get
            Set(ByVal value As TaxRate)
                If value IsNot Nothing Then
                    m_mainApplication.Settings.SetSetting(RegistryValues.ArticleDefaultTax, RegistrySections.ModuleArticles, value.ID.ToString)
                End If

            End Set
        End Property

        ''' <summary>
        ''' Wenn wahr, werden in Auflistunegn etc deaktivierte Artikel angezeigt.  Wenn False werden diese nicht angezeigt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ShowInactiveItems As Boolean
            Get
                Return CBool(m_mainApplication.Settings.GetSetting(RegistryValues.RegKeyShowInactiveItems, RegistrySections.ModuleArticles, "1"))
            End Get
            Set(ByVal value As Boolean)
                m_mainApplication.Settings.SetSetting(RegistryValues.RegKeyShowInactiveItems, RegistrySections.ModuleArticles, CInt(value).ToString) ' nur null oder 1 speichern
            End Set
        End Property


    End Class
End Namespace