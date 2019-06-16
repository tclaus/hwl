
Imports ClausSoftware.Tools
Imports ClausSoftware.Kernel

''' <summary>
''' Stellt einen Dialog für die Steuersätze zur Verfügung
''' </summary>
''' <remarks></remarks>
Public Class iucOptionTaxes
    Implements IOptionMenue


    Private m_showTaxAssignment As Boolean
    ''' <summary>
    ''' Zeigt die Auswahlfelder "In Recnungen Steuern anzeigen" und Einzelartikel sind Netto oder verbirgt diese
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("Zeigt die Auswahlfelder 'In Rechnungen Steuern anzeigen' und 'Einzelartikel sind Netto' oder verbirgt diese")> _
    Public Property ShowTaxAssignment() As Boolean
        Get
            Return m_showTaxAssignment
        End Get
        Set(ByVal value As Boolean)
            m_showTaxAssignment = value
            chkShowItemsWithTaxInDocument.Visible = value
            chkShowWithoutTax.Visible = value
            btneditCashAccounts.Visible = value
        End Set
    End Property


    'Please enter any new code here, below the Interop code

    Public Sub Initialize() Implements IOptionMenue.Initialize
        Try
            
            FillGrid()

            chkShowItemsWithTaxInDocument.Checked = MainApplication.getInstance.Settings.ItemsSettings.ShowItemsWithTax
            chkShowWithoutTax.Checked = MainApplication.getInstance.Settings.ItemsSettings.ShowWithoutTax
            chkUseRoundedTaxValues.Checked = MainApplication.getInstance.Settings.ItemsSettings.ShowRoundedTaxValues

        Catch ex As Exception

            Debug.Print(ex.Message)
        End Try

    End Sub




    ''' <summary>
    ''' Wird aufgerufen, wenn sich der Steuersatz geändert hat
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub TaxRateChanged(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    ''' <summary>
    ''' Füllt die Liste der Steuern auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillGrid()

        cboTaxstatus.Items.Clear()

        cboTaxstatus.Items.AddEnum(GetType(enumTaxKind))

        For Each item As DevExpress.XtraEditors.Controls.ImageComboBoxItem In cboTaxstatus.Items
            item.Description = GetTaxName(CType(item.Value, enumTaxKind))
        Next

        grdTaxes.DataSource = MainApplication.getInstance.TaxRates


    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim newTax As TaxRate = New TaxRate(MainApplication.getInstance.Session)
        newTax.Name = "Neuer Steuersatz"
        newTax.TaxStatus = enumTaxKind.OtherTax

        MainApplication.getInstance.TaxRates.Add(newTax)
        newTax.Save()

        FillGrid()


    End Sub


    ''' <summary>
    ''' Ruft einen Text ab, der den steuersatz beschreibt
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTaxName(ByVal e As enumTaxKind) As String
        Select Case e
            Case enumTaxKind.NullTax : Return GetText("taxNoTax", "Ohne Steuern")
            Case enumTaxKind.ReducedTax : Return GetText("taxReducedTax", "Ermässigt")
            Case enumTaxKind.NormalTax : Return GetText("taxStandardTax", "Normal")
            Case enumTaxKind.OtherTax : Return GetText("taxOthersTax", "Sonstige Steuern")
            Case enumTaxKind.ReducedTax2 : Return GetText("taxExtraTax2", "Zwischensatz")
            Case enumTaxKind.ExtraTax : Return GetText("taxExtraTax", "Extrasatz")
            Case Else
                Debug.Assert(False, "Unbekannter Steuertype!")
                Return GetText("taxOthers", "Sonstige Steuern") 'TODO: eher ungünstig; dieser Text wird nur übernommen, wenn der Code auch durchlaufen wird.
        End Select
    End Function

    Private Sub cboTaxstatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTaxstatus.SelectedIndexChanged
        ' die Steuertypen "Normal","ermässigt" und "Null" dürfen nur einmal vergeben werden

        Dim cbo As DevExpress.XtraEditors.ImageComboBoxEdit = CType(sender, DevExpress.XtraEditors.ImageComboBoxEdit)
        Dim selectedTax As TaxRate = CType(GridView1.GetRow(GridView1.FocusedRowHandle), TaxRate)

        Dim selItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = CType(cbo.SelectedItem, DevExpress.XtraEditors.Controls.ImageComboBoxItem)


        If CType(selItem.Value, enumTaxKind) <> enumTaxKind.OtherTax Then

            ' dann darf es nur einem von diesem Type geben 
            ' ein anderer eintrag wird dann zu "other"

            For Each item As TaxRate In MainApplication.getInstance.TaxRates
                If item.TaxStatus = CType(selItem.Value, enumTaxKind) And item.ID <> selectedTax.ID Then
                    item.TaxStatus = enumTaxKind.OtherTax
                End If
            Next

            grdTaxes.DataSource = MainApplication.getInstance.TaxRates

        End If



    End Sub

    Private Sub chkShowTaxInDocument_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowItemsWithTaxInDocument.CheckedChanged

        MainApplication.getInstance.Settings.ItemsSettings.ShowItemsWithTax = chkShowItemsWithTaxInDocument.Checked

        chkShowWithoutTax.Enabled = chkShowItemsWithTaxInDocument.Checked


    End Sub

    Private Sub chkShowWithoutTax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowWithoutTax.CheckedChanged


        MainApplication.getInstance.Settings.ItemsSettings.ShowWithoutTax = chkShowWithoutTax.Checked
    End Sub



    Private Sub iucTaxes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

        Initialize()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        'TODo: NLS
        If MessageBox.Show("Möchten Sie den ausgewählten Steuersatz löschen?", "Steuersatz löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim toDelete As TaxRate = CType(GridView1.GetRow(GridView1.FocusedRowHandle), TaxRate)
            toDelete.Delete()
            FillGrid()
            ' Steuersätze können nun noch in anderen Dokumenten vorkommen; welcher soll nun genommen wwerden? 



        End If
    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        Dim changedTax As TaxRate = CType(GridView1.GetRow(e.RowHandle), TaxRate)
        changedTax.Save()

    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim focusedTax As TaxRate = CType(GridView1.GetFocusedRow, TaxRate)

        btnDelete.Enabled = (focusedTax.TaxStatus = enumTaxKind.OtherTax) ' Nur "Andere" löschbar machen

    End Sub


    Public Sub Reload() Implements IOptionMenue.Reload
        MainApplication.getInstance.TaxRates.Reload()
        FillGrid()
    End Sub

    Public Sub Save() Implements IOptionMenue.Save
        MainApplication.getInstance.TaxRates.Save()
    End Sub

    Public Overrides Function ToString() As String
        Return Me.DisplayName
    End Function

    Public ReadOnly Property DisplayName() As String Implements IOptionMenue.DisplayName
        Get
            Return GetText("optionTaxsettings", "Steuern")
        End Get

    End Property

    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False
        End Get
    End Property

    Private Sub btneditCashAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneditCashAccounts.Click
        mainControlContainer.MainUI.ShowListCashAccounts()
    End Sub

    Private Sub chkUseRoundedTaxValues_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseRoundedTaxValues.CheckedChanged

        MainApplication.getInstance.Settings.ItemsSettings.ShowRoundedTaxValues = chkUseRoundedTaxValues.Checked

    End Sub

    Private Sub cmdDocuments_Click(sender As System.Object, e As System.EventArgs) Handles btnDocuments.Click
        Try
            Dim frm As New frmSetDocumentsTax
            frm.ShowDialog()
        Catch ex As Exception
            MainApplication.getInstance.Log.WriteLog(ex, "Alle Steuersätze angleichen", "Fehler beim angleichen der Steuersätze:  ")
        End Try

    End Sub
End Class