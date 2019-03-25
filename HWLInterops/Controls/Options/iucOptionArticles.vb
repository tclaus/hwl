Imports ClausSoftware.Tools
Imports ClausSoftware.Kernel

''' <summary>
''' Optionen für Artikel
''' </summary>
''' <remarks></remarks>
Public Class iucOptionArticles
    Implements IOptionMenue

    'Please enter any new code here, below the Interop code


    Public Sub Initialize() Implements IOptionMenue.Initialize
        LoadSettings(False)
    End Sub

    ''' <summary>
    ''' Erzwingt ein Neuladen der Einstellungen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Reload() Implements IOptionMenue.Reload
        LoadSettings(True)
    End Sub

    ''' <summary>
    ''' Läd die Einstellungen neu ein
    ''' </summary>
    ''' <param name="force"></param>
    ''' <remarks></remarks>
    Private Sub LoadSettings(ByVal force As Boolean)
        cboTax.Properties.Items.Clear()
        cboTax.Properties.Items.AddRange(MainApplication.getInstance.TaxRates)
        cboTax.SelectedItem = MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate

        chkShowDiscounts.Checked = CBool(MainApplication.getInstance.Settings.GetSetting(RegistryValues.ShowArticleDiscounts, RegistrySections.ModuleArticles, "0", force))

        chkShowRessources.Checked = CBool(MainApplication.getInstance.Settings.GetSetting(RegistryValues.ShowArticleRessources, RegistrySections.ModuleArticles, "0", force))
        chkShowInactiveItems.Checked = MainApplication.getInstance.Settings.Articlesettings.ShowInactiveItems

    End Sub

    Public Sub Save() Implements IOptionMenue.Save

        If cboTax.SelectedItem IsNot Nothing Then
            MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate = CType(cboTax.SelectedItem, TaxRate)
        End If



    End Sub

    Private Sub btnEditUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditUnits.Click

        Dim editor As New frmSimpleEdit(DataSourceList.Units)
        editor.ShowDialog()

    End Sub

    Private Sub btnEditDiscounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDiscounts.Click
        Dim editor As New frmSimpleEdit(DataSourceList.Discounts)
        editor.ShowDialog()

    End Sub


    Private Sub btnEditLoadAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditLoadAccounts.Click
        Dim editor As New frmSimpleEdit(DataSourceList.LoanAccounts)
        editor.ShowDialog()
    End Sub

    Private Sub cboTax_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTax.SelectedIndexChanged

    End Sub

    Public Overrides Function ToString() As String
        Return Me.DisplayName
    End Function

    Public ReadOnly Property DisplayName() As String Implements IOptionMenue.DisplayName
        Get
            Return GetText("optionArticles", "Standardwerte Artikelverwaltung")
        End Get

    End Property

    Private Sub chkShowDiscounts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowDiscounts.CheckedChanged

        MainApplication.getInstance.Settings.SetSetting(RegistryValues.ShowArticleDiscounts, RegistrySections.ModuleArticles, CStr(CInt(chkShowDiscounts.Checked)))

    End Sub

    Private Sub chkShowRessources_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowRessources.CheckedChanged
        MainApplication.getInstance.Settings.SetSetting(RegistryValues.ShowArticleRessources, RegistrySections.ModuleArticles, CStr(CInt(chkShowRessources.Checked)))
    End Sub

    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False
        End Get
    End Property

    Private Sub btnAdvanced_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chkShowInactiveItems_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowInactiveItems.CheckedChanged
        MainApplication.getInstance.Settings.Articlesettings.ShowInactiveItems = chkShowInactiveItems.Checked

    End Sub

    Private Sub iucOptionArticles_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)
    End Sub

    Private Sub cmdSetTaxForAllItems_Click(sender As System.Object, e As System.EventArgs) Handles cmdSetTaxForAllItems.Click
        SetTaxForAllItems()
    End Sub

    ''' <summary>
    ''' Setzt den steuersatz für alle Artikel
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTaxForAllItems()
        Dim result As DialogResult
        result = MessageBox.Show("Möchten Sie den Steuersatz '" & cboTax.SelectedItem.ToString & "' für alle Artikel festschreiben ? ", "Steuern übernehmen", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim tax As Kernel.TaxRate = CType(cboTax.SelectedItem, TaxRate)

            Dim sql As String = "Update " & Kernel.Article.TableName & " SET mwst=" & tax.ID
            MainApplication.getInstance.SendMessage("Starte Aktualisierung der Artikelsteuersätze...")
            Dim count As Integer
            count = MainApplication.getInstance.Database.ExcecuteNonQuery(sql)
            MainApplication.getInstance.SendMessage(count & " Artikel aktualisiert.")

        End If
    End Sub

    Private Sub cmdSetAllItemsActive_Click(sender As System.Object, e As System.EventArgs) Handles cmdSetAllItemsActive.Click
        setAllItemsActive()
    End Sub

    ''' <summary>
    ''' Alle Artikel aktiv setzen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setAllItemsActive()
        Dim result As DialogResult
        result = MessageBox.Show("Möchten Sie alle Artikel auf den Status 'Aktiv' setzen?? ", "Alle Artikel aktivieren", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim sql As String = "Update " & Kernel.Article.TableName & " SET IsActive=TRUE"
            MainApplication.getInstance.SendMessage("Starte Aktualisierung des Aktiv-Status...")
            Dim count As Integer
            count = MainApplication.getInstance.Database.ExcecuteNonQuery(sql)
            MainApplication.getInstance.SendMessage(count & " Artikel aktualisiert.")
        End If
    End Sub

End Class