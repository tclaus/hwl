Imports ClausSoftware.Kernel


''' <summary>
''' Stellt die Oberfläche für Mahnungen bereit
''' </summary>
''' <remarks></remarks>
Public Class frmReminder



    Private m_parentTRansaction As Transaction


    Private m_hasChanges As Boolean

    Private m_mainUI As MainUI

    Public Property MainUI() As MainUI
        Get
            Return m_mainUI
        End Get
        Set(ByVal value As MainUI)
            m_mainUI = value
        End Set
    End Property


    ''' <summary>
    ''' wenn True, dann liegen in dieser Maske oder der aktiven Mahnung Änderungen vor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HasChanges() As Boolean
        Get
            Return m_hasChanges
        End Get
        Set(ByVal value As Boolean)
            m_hasChanges = value
        End Set
    End Property


    ''' <summary>
    ''' Legt die zugrundeliegende Transaktion fest oder ruft diese ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentTransaction() As Transaction
        Get
            Return m_parentTRansaction
        End Get
        Set(ByVal value As Transaction)
            m_parentTRansaction = value
            FillControls()
        End Set
    End Property

    ''' <summary>
    ''' Füllt die Steuerelemente des Manungungsdialoges auf
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillControls()
        lblInvoiceDate.Text = m_parentTRansaction.ItemDate.ToString("d")
        lblInvoiceNumber.Text = m_parentTRansaction.ItemDisplayNumber
        lblInvoiceText.Text = m_parentTRansaction.Text

        FillListOfReminders()
        Me.HasChanges = False

    End Sub

    ''' <summary>
    ''' Füllt die LIste der Mahnungen auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillListOfReminders()
        lstRemindersList.Items.Clear()
        For Each item As Reminder In m_parentTRansaction.GetReminders
            lstRemindersList.Items.Add(item)
        Next

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

        CloseForm()
    End Sub

    ''' <summary>
    ''' Fragt nach, die Anwednung zu beenden
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloseForm()
        If Me.ActiveReminder IsNot Nothing Then
            If Me.HasChanges Then
                Dim result As DialogResult = AskChangedData()
                If result = Windows.Forms.DialogResult.Yes Then

                    Me.ActiveReminder.Save()

                End If
                If result = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        End If

        Me.Close()
    End Sub

    Private Sub cmdNextReminderstep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextReminderstep.Click
        CreateNextRemindersLevel()
    End Sub



    Private m_activeReminder As Reminder

    ''' <summary>
    ''' Ruft die gerade aktive Manstiufe ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ActiveReminder() As Reminder
        Get
            Return m_activeReminder
        End Get
        Set(ByVal value As Reminder)
            m_activeReminder = value

            If ActiveReminder IsNot Nothing Then
                btndelete.Enabled = True
                btnPrint.Enabled = True
                btnSave.Enabled = True
                btnNextReminderstep.Enabled = ParentTransaction.GetReminders.LastReminder < ParentTransaction.GetReminders.MaxReminersLevel
            Else
                btndelete.Enabled = False
                btnPrint.Enabled = False
                btnSave.Enabled = False

            End If

        End Set
    End Property


    ''' <summary>
    ''' Erstellt die nächste Mahnstufe
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateNextRemindersLevel()
        If ParentTransaction.GetReminders.LastReminder < ParentTransaction.GetReminders.MaxReminersLevel Then
            If Me.HasChanges And ActiveReminder IsNot Nothing Then
                Dim result As DialogResult
                result = AskChangedData()
                If result = Windows.Forms.DialogResult.Yes Then
                    ActiveReminder.Save()
                End If

                If result = Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If

            End If

            Dim nextReminder As Reminder = ParentTransaction.GetReminders.GetNewItem
            nextReminder.ParentTransaction = Me.ParentTransaction
            nextReminder.RemindersLevel = ParentTransaction.GetReminders.Count + 1
            nextReminder.RemindersDate = Today
            nextReminder.RemindersFinalDate = Today.AddDays(nextReminder.DefaultNextTimeframe) ' Nächstes Mahndatum festlegen
            nextReminder.SetDefaultText()

            lstRemindersList.Items.Add(nextReminder)

            ActiveReminder = nextReminder

            Me.ParentTransaction.GetReminders.Add(nextReminder)

            FillRemindersText()
        End If

    End Sub

    ''' <summary>
    ''' Füllt die steuerelemente mit der aktuellen Mahnung auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillRemindersText()
        If Me.ActiveReminder IsNot Nothing Then

            If ActiveReminder.RemindersText.StartsWith("{\rtf") Then
                txtDescription.RtfText = ActiveReminder.RemindersText
            Else
                txtDescription.Text = ActiveReminder.RemindersText
            End If




            txtSubject.Text = ActiveReminder.RemindersSubject
            datReminderDate.DateTime = ActiveReminder.RemindersDate
            datRemindersLimitDate.DateTime = ActiveReminder.RemindersFinalDate
            chkIsInactiveReminder.Checked = ActiveReminder.IsInactiveReminder

            lblRemindersLeveltext.Text = ActiveReminder.LevelDisplayText

            Me.HasChanges = False
        End If
    End Sub

    Private Sub txtDescription_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubject.EditValueChanged, datRemindersLimitDate.EditValueChanged, datReminderDate.EditValueChanged
        Me.HasChanges = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.ActiveReminder IsNot Nothing Then
            Me.ActiveReminder.Save()
            Me.HasChanges = False
        End If
    End Sub

    Private Sub chkIsInactiveReminder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIsInactiveReminder.CheckedChanged
        Me.HasChanges = True
    End Sub

    Private Sub lstRemindersList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRemindersList.SelectedIndexChanged
        If Me.HasChanges And ActiveReminder IsNot Nothing Then
            Dim result As DialogResult
            result = AskChangedData()
            If result = Windows.Forms.DialogResult.Yes Then
                ActiveReminder.Save()
            End If
            If result = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

        End If

        Dim reminderItem As Reminder = CType(lstRemindersList.SelectedItem, Reminder)
        Me.ActiveReminder = reminderItem
        FillRemindersText()

    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        ActiveReminder.RemindersText = txtDescription.RtfText

        MainUI.OpenReportDesigner(Me.ParentTransaction.GetReminders, DataSourceList.Letters)


    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        DeleteActiveReminder()
    End Sub

    ''' <summary>
    ''' Löscht den gerade aktiven Reminder
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteActiveReminder()
        If m_activeReminder IsNot Nothing Then
            Dim result As DialogResult = AskDeleteData()
            If result = Windows.Forms.DialogResult.Yes Then
                m_activeReminder.Delete()
            End If

        End If
    End Sub

    Private Sub frmReminder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            CloseForm()
        End If

    End Sub

    Private Sub frmReminder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmReminder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

    End Sub

    Private Sub frmReminder_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        FillControls()

    End Sub
End Class