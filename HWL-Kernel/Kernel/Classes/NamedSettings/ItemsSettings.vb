Imports ClausSoftware.Tools

Namespace Kernel.NamedSettings

    ''' <summary>
    ''' Ruft eine Container-Klasse ab, die Einbstellungen für das Rechnungsmodul enthält.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ItemsSettings

        Private m_mainapplication As MainApplication

        ''' <summary>
        ''' Den Kopftext für Artikelgruppen im Auslieferungszustand
        ''' </summary>
        ''' <remarks></remarks>
        Private defaultGroupsHeadertext As String
        Private defaultGroupsFooterText As String

        Public Sub New(ByVal application As MainApplication)
            m_mainapplication = application

            ' Alte Standardtexte
            defaultGroupsHeadertext = m_mainapplication.Languages.GetText("ItemGroupDefaultName", "ArtikelGruppe")
            defaultGroupsFooterText = m_mainapplication.Languages.GetText("ItemGroupDefaultSummaryName", "Gesamtpreis dieser Artikelgruppe")


        End Sub

        ''' <summary>
        ''' Hält einen Cache für den Wert
        ''' </summary>
        ''' <remarks></remarks>
        Private m_ShowWithoutTax As Boolean?
        ''' <summary>
        ''' Hält einen Cache für den Wert
        ''' </summary>
        Private m_ShowRoundedTaxValues As Boolean?

        ''' <summary>
        ''' Hält einen Cache für den Wert
        ''' </summary>
        Private m_ShowItemswithTax As Boolean?

        Private m_LastUsedDocumentNumber As Integer?

        ''' <summary>
        ''' Ruft den Standardtext oberhalb von Artikelgruppen ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DefaultItemsGroupHeadline() As String
            Get
                Return m_mainapplication.Settings.GetSetting("DefaultItemsGroupHeadline", RegistrySections.ModuleInvoices, defaultGroupsHeadertext)
            End Get
            Set(ByVal value As String)
                m_mainapplication.Settings.SetSetting("DefaultItemsGroupHeadline", RegistrySections.ModuleInvoices, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Standardtext unterhalb von Artikelgruppen ab oder legt diesen fest. (Zusammenfassungstext)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DefaultItemsGroupSummary() As String
            Get
                ' war sonst: "Gesamtpreis dieser Artikelgruppe"; nun änderbar
                Return m_mainapplication.Settings.GetSetting("DefaultItemsGroupSummary", RegistrySections.ModuleInvoices, "Summe")
            End Get
            Set(ByVal value As String)
                m_mainapplication.Settings.SetSetting("DefaultItemsGroupSummary", RegistrySections.ModuleInvoices, value)
            End Set
        End Property

        ''' <summary>
        ''' Wenn True, werden Artikel in Rechnungen als Nettopreis, zuzüglich dem Mehrwertsteueranteil ausgewiesen, wenn False, ist der MwSt - Anteil bereits in der angezeigten Summe enthalten
        ''' und wird "Inkusive X MwSt angezeigt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShowWithoutTax() As Boolean
            Get
                If Not m_ShowWithoutTax.HasValue Then
                    m_ShowWithoutTax = CBool(m_mainapplication.Settings.GetSetting(RegistryValues.RegKeyShowItemsNetto, RegistrySections.CurrentVersion, "1"))
                End If
                Return m_ShowWithoutTax.Value

            End Get
            Set(ByVal value As Boolean)
                m_mainapplication.Settings.SetSetting(RegistryValues.RegKeyShowItemsNetto, RegistrySections.CurrentVersion, CInt(value).ToString)
                m_ShowWithoutTax = value

            End Set
        End Property

        ''' <summary>
        ''' Ruft den standard ab, um gerundete oder exakte Steuersätze anzuzeigen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ShowRoundedTaxValuesDefault As String
            Get
                Return "0"
            End Get
        End Property

        ''' <summary>
        ''' Wenn wahr, werden alle Steuersätze gerundet berechnet, wenn fasch, wird mit exakten Daten weitergearbeitet.
        ''' Das wirkt sich aus, wenn die Artikelanzahl 100 beträgt und die (gerundeten)  Nachkommastellen in den sichtbaren Bereich rutschen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShowRoundedTaxValues() As Boolean
            Get
                If Not m_ShowRoundedTaxValues.HasValue Then
                    m_ShowRoundedTaxValues = CBool(m_mainapplication.Settings.GetSetting(RegistryValues.RegKeyShowRoundedTaxValues, RegistrySections.CurrentVersion, ShowRoundedTaxValuesDefault))
                End If
                Return m_ShowRoundedTaxValues.Value
            End Get
            Set(ByVal value As Boolean)
                m_mainapplication.Settings.SetSetting(RegistryValues.RegKeyShowRoundedTaxValues, RegistrySections.CurrentVersion, CInt(value).ToString)
                m_ShowRoundedTaxValues = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID der zuletzt genutzen Dokuemnten-Nummer ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LastUsedDocumentType As Integer
            Get
                If Not m_LastUsedDocumentNumber.HasValue Then
                    m_LastUsedDocumentNumber = CInt(m_mainapplication.Settings.GetSetting(RegistryValues.RegLastUsedDocumentNumber, RegistrySections.CurrentVersion, "1"))
                End If
                Return m_LastUsedDocumentNumber.Value
            End Get
            Set(value As Integer)
                m_mainapplication.Settings.SetSetting(RegistryValues.RegLastUsedDocumentNumber, RegistrySections.CurrentVersion, CStr(value))
                m_LastUsedDocumentNumber = value
            End Set
        End Property

        ''' <summary>
        ''' Wenn Wahr, werden in Rechnungen und Angebote Artikel der Steueranteil angezeigt, sonst wird eine Rechnung erzeugt, ohne ausgewiesene MwSt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShowItemsWithTax() As Boolean
            Get
                If Not m_ShowItemswithTax.HasValue Then
                    m_ShowItemswithTax = CBool(m_mainapplication.Settings.GetSetting(RegistryValues.RegKeyShowMWST, RegistrySections.CurrentVersion, "1"))
                End If
                Return m_ShowItemswithTax.Value
            End Get
            Set(ByVal value As Boolean)
                m_mainapplication.Settings.SetSetting(RegistryValues.RegKeyShowMWST, RegistrySections.CurrentVersion, CStr(CInt(value)))
                m_ShowItemswithTax = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die standard Anzahl von seitenkopien ab für Angebote / Rechnungen oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DefaultPageCount() As Short
            Get

                Return CShort(m_mainapplication.Settings.GetSetting("DefaultPageCount", RegistrySections.ModuleInvoices, "1"))
                
            End Get
            Set(ByVal value As Short)
                m_mainapplication.Settings.SetSetting("DefaultPageCount", RegistrySections.ModuleInvoices, CStr(value))

            End Set
        End Property

        ''' <summary>
        ''' Ruft den standard Steuersatz ab, wenn freier Text benutzt wird
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DefaultUnboundTaxRate() As TaxRate
            Get
                Dim taxrateID As Integer

                taxrateID = CInt(m_mainapplication.Settings.GetSetting("DefaultUnboundTaxRate", RegistrySections.ModuleInvoices, "-1"))
                Return m_mainapplication.TaxRates.GetItem(taxrateID)

            End Get
            Set(ByVal value As TaxRate)
                If value IsNot Nothing Then
                    m_mainapplication.Settings.SetSetting("DefaultUnboundTaxRate", RegistrySections.ModuleInvoices, CStr(value.ID))
                Else
                    m_mainapplication.Settings.SetSetting("DefaultUnboundTaxRate", RegistrySections.ModuleInvoices, "-1")
                End If

            End Set
        End Property

    End Class
End Namespace