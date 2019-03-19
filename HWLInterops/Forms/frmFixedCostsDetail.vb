Imports ClausSoftware.Kernel

''' <summary>
''' stellt einen Dialog bereit, in dem die Fixkosten im Detail bearbeitet werden können
''' </summary>
''' <remarks></remarks>
Public Class frmFixedCostDetail

    ''' <summary>
    ''' Enthäkt die zuletzt gewählte Wiederholrate
    ''' </summary>
    ''' <remarks></remarks>
    Private m_recurrence As DevExpress.XtraScheduler.RecurrenceInfo
    ''' <summary>
    ''' Enthält die Fixkosten
    ''' </summary>
    ''' <remarks></remarks>
    Private m_fixedCosst As ClausSoftware.Kernel.FixedCost

    Private m_hasChanged As Boolean

    ''' <summary>
    ''' Zeigt an, das sich derf Inhalt der Controls seit dem letzten Aufruf geändert hat
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HasChanged() As Boolean
        Get
            Return m_hasChanged
        End Get
        Set(ByVal value As Boolean)
            m_hasChanged = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft den Datensatz ab, der in diesem Dialog angezeigt und bearbeitet werden soll
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FixedCostItem() As ClausSoftware.Kernel.FixedCost
        Get
            Return m_fixedCosst
        End Get
        Set(ByVal value As ClausSoftware.Kernel.FixedCost)
            m_fixedCosst = value
            txtSubject.Text = value.Subject
            txtPeriodicalAmmount.EditValue = value.PeriodicalCost
            cboCategory.SelectedItem = value.Group
            Select Case value.Recurrence.Type
                Case DevExpress.XtraScheduler.RecurrenceType.Daily : radRecurrenceChoose.EditValue = 1
                    DailyRecurrenceControl1.RecurrenceInfo = value.Recurrence

                Case DevExpress.XtraScheduler.RecurrenceType.Weekly : radRecurrenceChoose.EditValue = 2
                    WeeklyRecurrenceControl1.RecurrenceInfo = value.Recurrence

                Case DevExpress.XtraScheduler.RecurrenceType.Monthly : radRecurrenceChoose.EditValue = 3
                    MonthlyRecurrenceControl1.RecurrenceInfo = value.Recurrence

                Case DevExpress.XtraScheduler.RecurrenceType.Yearly : radRecurrenceChoose.EditValue = 5  '"4" fehlt, da Quartal nicht mehr existiert
                    YearlyRecurrenceControl1.RecurrenceInfo = value.Recurrence

            End Select
            Me.HasChanged = False

        End Set
    End Property


    Private Sub frmFixedCostDetail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Languages.SetTextOnControl(Me)

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        CopyData()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    ''' <summary>
    ''' Überträgt die eingaben der UI in die Objekte
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CopyData()

        'Hat der Anwender eine Gruppe eingegeben, die noch nicht existiert ? 

        If Not m_application.FixedCostGroups.ContainsGroupName(cboCategory.Text) Then
            Me.FixedCostItem.Group = m_application.FixedCostGroups.GetGroupByName(cboCategory.Text)
        Else
            ' Gruppe existiert
            Me.FixedCostItem.Group = CType(cboCategory.SelectedItem, Kernel.FixedCostGroup)
        End If


        Me.FixedCostItem.Subject = txtSubject.Text
        Me.FixedCostItem.PeriodicalCost = CDec(txtPeriodicalAmmount.EditValue)

        Me.FixedCostItem.Recurrence = m_recurrence

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        QueryClose()
    End Sub

    Private Sub radRecurrenceChoose_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radRecurrenceChoose.SelectedIndexChanged
        Select Case CInt(radRecurrenceChoose.EditValue)
            Case 1 : DailyRecurrenceControl1.BringToFront()
                m_recurrence.Type = DevExpress.XtraScheduler.RecurrenceType.Daily

            Case 2 : WeeklyRecurrenceControl1.BringToFront()
                m_recurrence.Type = DevExpress.XtraScheduler.RecurrenceType.Weekly

            Case 3 : MonthlyRecurrenceControl1.BringToFront()
                m_recurrence.Type = DevExpress.XtraScheduler.RecurrenceType.Monthly

            Case 5 : YearlyRecurrenceControl1.BringToFront()
                m_recurrence.Type = DevExpress.XtraScheduler.RecurrenceType.Yearly

                HasChanged = True
        End Select

    End Sub

    ''' <summary>
    ''' Wenn sich ein Datum ändert, dann alle andere Controls auch benachrichtigen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RecurrenceControl_RecurrenceInfoChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonthlyRecurrenceControl1.RecurrenceInfoChanged, DailyRecurrenceControl1.RecurrenceInfoChanged, WeeklyRecurrenceControl1.RecurrenceInfoChanged, YearlyRecurrenceControl1.RecurrenceInfoChanged

        m_recurrence = CType(sender, DevExpress.XtraScheduler.UI.RecurrenceControlBase).RecurrenceInfo
        Me.HasChanged = True
    End Sub

    Private Sub btneditGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneditGroup.Click
        Dim frm As New frmSimpleEdit(DataSourceList.FixedCostGroup)
        frm.ShowDialog()

        cboCategory.Properties.Items.Clear()
        cboCategory.Properties.Items.AddRange(m_application.FixedCostGroups)

        m_application.FixedCostGroups.Save()

    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        cboCategory.Properties.Items.Clear()
        cboCategory.Properties.Items.AddRange(m_application.FixedCostGroups)

    End Sub

    Private Sub Text_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtPeriodicalAmmount.DragDrop, txtSubject.DragDrop
        DragDropHelper.SetText(sender, e)
    End Sub

    Private Sub txtSubject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubject.TextChanged, txtPeriodicalAmmount.TextChanged
        Me.HasChanged = True

    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        Me.HasChanged = True
    End Sub

    Private Sub frmFixedCostDetail_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            QueryClose()
        End If

    End Sub

    Private Sub QueryClose()
        If Me.HasChanged Then
            Dim result As DialogResult = AskChangedData()

            If result = Windows.Forms.DialogResult.Yes Then ' Ja, Speichern und Beenden 
                Me.DialogResult = Windows.Forms.DialogResult.OK
                CopyData()
                Me.Close()
                Exit Sub
            End If

            If result = Windows.Forms.DialogResult.Cancel Then ' Abbrechen gedrückt 

                Exit Sub
            End If


        End If

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Text_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtSubject.DragEnter, txtPeriodicalAmmount.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub
End Class