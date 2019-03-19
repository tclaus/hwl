
''' <summary>
''' Stellt ein Formular bereit, das mehrere Beträge und Steuersätze beinhaltet
''' </summary>
''' <remarks></remarks>
Public Class frmEnterTaxRateValues

    Private m_TaxValuePairs As Kernel.TaxValuePairs
    ''' <summary>
    ''' Ruft die Auflistung de STeuersätze ab oer legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property TaxValuePairs() As Kernel.TaxValuePairs
        Get
            Return m_TaxValuePairs
        End Get
        Set(ByVal value As Kernel.TaxValuePairs)
            m_TaxValuePairs = value
        End Set
    End Property

    ''' <summary>
    ''' Füllt das Grid mit Zahlen / Wertpaare auf
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillGrid()
        grdValueTaxPairs.DataSource = Me.TaxValuePairs
    End Sub

    Private Sub frmEnterTaxRateValues_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_application.Settings.SaveFormsPos(Me)
    End Sub


    Private Sub frmEnterTaxRateValues_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Settings.RestoreFormsPos(Me)
        m_application.Languages.SetTextOnControl(Me)

        repTaxValue.Items.Clear()
        repTaxValue.Items.AddRange(m_application.TaxRates)

        FillGrid()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    
    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click

        m_TaxValuePairs.Add(m_TaxValuePairs.GetNewItem)
        grdValueTaxPairs.RefreshDataSource()
    End Sub

    
    Private Sub grvValueTaxPairs_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles grvValueTaxPairs.CustomColumnDisplayText

        If e.Column Is colTaxValue Then
            Dim d As Kernel.TaxValuePair = CType(grvValueTaxPairs.GetRow(e.RowHandle), Kernel.TaxValuePair)
            If d.Tax IsNot Nothing Then
                e.DisplayText = d.Tax.ToString
            End If
        End If

    End Sub

    Private Sub repTaxValue_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles repTaxValue.SelectedIndexChanged

    End Sub

    Private Sub grvValueTaxPairs_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles grvValueTaxPairs.ValidatingEditor
        If TypeOf e.Value Is Kernel.TaxRate Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim tPair As Kernel.TaxValuePair = CType(view.GetRow(view.FocusedRowHandle), Kernel.TaxValuePair)

            tPair.Tax = CType(e.Value, Kernel.TaxRate)

        End If


    End Sub
End Class
