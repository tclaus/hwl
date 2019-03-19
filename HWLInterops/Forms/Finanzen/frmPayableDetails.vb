Imports ClausSoftware.Kernel
Imports System.ComponentModel

''' <summary>
''' Stellt Zahlungsdetails zu einer Forderung dar
''' </summary>
''' <remarks></remarks>
Public Class frmPayableDetails

    <EditorBrowsable(EditorBrowsableState.Advanced)> _
    Private m_activeTransaction As Transaction

    <EditorBrowsable(EditorBrowsableState.Advanced)> _
    Private m_downPayments As DownPayments

    Private m_FormCaption As String = "Zahlungsdetails" 'TODO: NLS

    Private m_mainUI As mainUI

    Public Property MainUI() As mainUI
        Get
            Return m_mainUI
        End Get
        Set(ByVal value As mainUI)
            m_mainUI = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft die aktuelle TRansaktion ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ActiveTransaction() As Transaction
        Get
            Return m_activeTransaction
        End Get
        Set(ByVal value As Transaction)
            m_activeTransaction = value
            m_downPayments = value.GetDownPayments
            FillControls()
        End Set
    End Property

    ''' <summary>
    ''' Ruft die Auflistung der aktuellen Teilzahlungen ab 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property ActiveDownPayments() As DownPayments
        Get
            Return m_downPayments
        End Get
    End Property


    ''' <summary>
    ''' Füllt das Formular mit den Werten aus der Forderung auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillControls()
        FillDownPayments()
        lblDocumentNumber.Text = m_activeTransaction.ItemDisplayNumber
        lblInvoiceDate.Text = GetText("From", "vom ") & m_activeTransaction.ItemDate.ToString("d")
        lblDateToPayValue.Text = m_activeTransaction.TargetPayDate.ToString("d")
        lblSumTotalValue.Text = m_activeTransaction.TotalAmmount.ToString("c")
        lblSumPaidValue.Text = (m_activeTransaction.TotalAmmount - m_activeTransaction.UnpaidAmmount).ToString("c")
        lblInvoiceText.Text = m_activeTransaction.Text

        ' Den Zahlstatus definieren
        If m_activeTransaction.UnpaidAmmount > 0 Then
            ' Nun kann entweder das Zahlungsziel noch niht erreicht sein
            If Date.Compare(m_activeTransaction.TargetPayDate, Now) > 0 Then
                ' Alles OK, wir warten noch 
                picState.Image = My.Resources.hourglass_32x32
                picState.ToolTip = "Zahlungsziel noch nicht überschritten" 'TODO: NLS
                btnsetReminder.Enabled = False
            Else
                ' Zahlungsziel überschritten
                picState.Image = My.Resources.calendar_warning_32x32
                picState.ToolTip = "Zahlungsziel überschritten" 'TODO: NLS
                btnsetReminder.Enabled = True

            End If

            txtDownPayment.Enabled = True
            datDate.Enabled = True
            btnAdd.Enabled = True


        Else
            picState.Image = My.Resources.checkbox_32x32
            picState.ToolTip = "Betrag bezahlt" 'TODO: NLS

            txtDownPayment.Enabled = False
            datDate.Enabled = False
            btnAdd.Enabled = False

            btnsetReminder.Enabled = True


        End If

        txtDownPayment.EditValue = ActiveTransaction.UnpaidAmmount
        datDate.DateTime = Today



    End Sub

    ''' <summary>
    ''' Füllt die Liste der Zahlungseingänge für diese Forderung auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillDownPayments()


        If ActiveDownPayments IsNot Nothing Then
            grdDownPayments.DataSource = ActiveDownPayments
        End If

    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click


        If ActiveDownPayments.HasChanges Then
            If AskSaveItem Then
                Me.Close()
            Else
                Exit Sub
            End If

        End If

    End Sub

    ''' <summary>
    ''' Stellt dem Anwender die Frage, ob Änderungen gespeichert erden sollen und damit die Eingabe beendent werden soll
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AskSaveItem() As Boolean
        Dim result As DialogResult = AskChangedData(ActiveTransaction.Text)

        If result = Windows.Forms.DialogResult.Yes Then
            grdDownPayments.RefreshDataSource()
            ActiveDownPayments.RefreshParentTransaction()


            ' Hier das Zahldatum reparieren !
            ' Das letzte Zahldatum in der Liste wird auch im Dokument gespeihcrtee
            Dim lastPayedDate As DateTime
            For Each item As DownPayment In ActiveDownPayments
                If item.PaidDate > lastPayedDate Then
                    lastPayedDate = item.PaidDate
                End If
            Next

            'If (ActiveDownPayments.TotalPaidAmmount - ActiveDownPayments.ParentTransaction.TotalAmmount) < 0.01 Then
            '    ActiveDownPayments.ParentTransaction.SetIsPayed()
            'End If

            If ActiveDownPayments.ParentTransaction.IsPaid Then
                ActiveDownPayments.ParentTransaction.PaidDate = lastPayedDate

            End If

            ActiveDownPayments.Save() ' Beim Speichern auch den Betrag in der Rechnung anpassen ? 
            ActiveDownPayments.ParentTransaction.SaveInternal()
            Return True
        End If

        If result = Windows.Forms.DialogResult.Cancel Then
            Return False
        End If

        Return True

    End Function

    Private Sub idDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles idDelete.ItemClick
        DeleteSelected()
    End Sub

    ''' <summary>
    ''' Löscht die markierten Einträge
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteSelected()
        Dim result As DialogResult
        If grvDownPayments.GetSelectedRows.Length > 0 Then
            result = modmain.AskDeleteData
            If result = Windows.Forms.DialogResult.Yes Then

                For Each itemNr As Integer In grvDownPayments.GetSelectedRows
                    Dim data As DownPayment = CType(grvDownPayments.GetRow(itemNr), DownPayment)
                    data.Delete()

                Next

                Me.ActiveDownPayments.RefreshParentTransaction()
            End If
        End If


    End Sub

    ''' <summary>
    ''' Eine Einzahlung vornehmen
    ''' </summary>
    ''' <remarks></remarks>
    Private Function AddNewPayment() As DownPayment

        If ActiveTransaction.UnpaidAmmount > 0 Then
            Dim newPaymanet As DownPayment = Me.ActiveDownPayments.GetNewItem
            Me.ActiveDownPayments.Add(newPaymanet)
            Return newPaymanet
        End If
        Return Nothing

    End Function


    Private Sub grdDownPayments_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdDownPayments.KeyUp

        If e.KeyCode = Keys.Delete Then
            DeleteSelected()
        End If
        If e.KeyCode = Keys.Add And e.Control Then
            AddNewPayment()
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        AddNewPaymentFromText()
    End Sub

    Private Sub frmPayableDetails_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_application.Settings.SaveFormsPos(Me)
    End Sub

    Private Sub frmPayableDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Settings.RestoreFormsPos(Me)

        picState.Image = My.Resources.checkbox_32x32

    End Sub

    Private Sub grvDownPayments_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvDownPayments.DataSourceChanged

        Debug.Assert(grvDownPayments.Columns("Ammount") IsNot Nothing, "Konnte die Ammount-Spalte nicht finden!")

        grvDownPayments.Columns("Ammount").ColumnEdit = currencyedit

    End Sub

    Private Sub btnsetReminder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetReminder.Click
        OpenRemindersForm()
    End Sub

    ''' <summary>
    ''' Öffnet die Mahnungen - Oberfläche
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenRemindersForm()
        Using frm As New frmReminder
            frm.MainUI = Me.MainUI
            frm.ParentTransaction = Me.ActiveTransaction
            frm.ShowDialog()
        End Using
    End Sub

    ''' <summary>
    ''' Fügt eine neue Zahlung aus den Eingabefeldern hinzu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddNewPaymentFromText()
        Dim newPaymentAmmount As Decimal = Math.Round(CDec(txtDownPayment.EditValue), 2)

        If newPaymentAmmount + Me.ActiveDownPayments.TotalPaidAmmount > Me.ActiveTransaction.TotalAmmount Then
            'TODo: NLS
            Dim result As DialogResult = MessageBox.Show("Damit währe der gezahlte Betrag grösser als die offene Forderung" & vbCrLf & _
                            "Möchten sie die Zahlung dennoch hinzufügen?", "Zahlbetrag grösser als Forderung", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

            If result <> Windows.Forms.DialogResult.Yes Then Exit Sub

        End If

        Dim newPayment As DownPayment = AddNewPayment()
        newPayment.PaidDate = datDate.DateTime
        newPayment.Ammount = Math.Round(CDec(txtDownPayment.EditValue), 2)
        newPayment.Description = "Zahlungseingang" 'TODo: NLS

    End Sub

    Public Sub New(ByVal mainUI As mainUI)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_application.Languages.SetTextOnControl(Me)

        m_mainUI = mainUI
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_application.Languages.SetTextOnControl(Me)
    End Sub

    Private Sub frmPayableDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ' Recnungsdaten anzeigen lassen 
        FillControls()

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        DeleteSelected()
    End Sub
End Class