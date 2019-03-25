
''' <summary>
''' Enthält eine Kleine übersicht über die Heute fälligen Aufgaben
''' </summary>
''' <remarks></remarks>
Public Class TodayBar
    Private m_tasks As ClausSoftware.Kernel.Tasks
    Private m_appointments As ClausSoftware.Kernel.Appointments
    Private m_mainUI As MainUI

    Public Event ClosePanel()


    Public Property MainUI() As MainUI
        Get
            Return m_mainUI
        End Get
        Set(ByVal value As MainUI)
            m_mainUI = value
        End Set
    End Property


    Private Sub TodayBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DesignMode Then Exit Sub
        If MainApplication.getInstance Is Nothing Then Exit Sub
        MainApplication.getInstance.Languages.SetTextOnControl(Me)
        lblTodayBarHeadline.Text = MainApplication.ApplicationName & " " & GetText("today", "Heute") & "  (" & Now.ToString("d") & ")"
        InitialFillTasks()
        InitialFillAppointments()
        picCloseModule.Image = My.Resources.Close_16x16



    End Sub

    Private Sub InitialFillTasks()
        Try
            m_tasks = CType(MainApplication.getInstance.Tasks.GetNewCollection, Kernel.Tasks)
            m_tasks.Filter = New DevExpress.Data.Filtering.BinaryOperator("TaskFinished", False)
            m_tasks.Sorting.Add(New DevExpress.Xpo.SortProperty("Expiration", DevExpress.Xpo.DB.SortingDirection.Descending))

            AddHandler MainApplication.getInstance.Tasks.ListChanged, AddressOf MainTaskListChanged

            clbTasks.BeginUpdate()
            clbTasks.DataSource = m_tasks
            For n As Integer = 0 To clbTasks.ItemCount - 1
                If CType(clbTasks.GetItem(n), Kernel.Task).TaskFinished Then
                    clbTasks.SetItemChecked(n, True)
                End If
            Next
            clbTasks.EndUpdate()
        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "InitialFillTasks", "Initialize of 'Today's Tasks failed!")
        End Try
    End Sub

    Private Sub InitialFillAppointments()
        Try

            m_appointments = CType(MainApplication.getInstance.Appointments.GetNewCollection, Kernel.Appointments)
            AddHandler MainApplication.getInstance.Appointments.ListChanged, AddressOf MainAppointmentsListChanged

            Dim criteria As New DevExpress.Data.Filtering.BinaryOperator("StartDate", Today, DevExpress.Data.Filtering.BinaryOperatorType.GreaterOrEqual)
            m_appointments.Criteria = criteria
            m_appointments.Sorting.Add(New DevExpress.Xpo.SortProperty("StartDate", DevExpress.Xpo.DB.SortingDirection.Ascending))

            lstAppointments.DataSource = m_appointments

        Catch ex As Exception
            MainApplication.getInstance.log.WriteLog(ex, "InitialFillAppointments", "Initialize of 'Today's Appointments failed!")
        End Try

    End Sub


    Private Sub DrawCheckListItems(ByVal Sender As Object, ByVal e As DevExpress.XtraEditors.ListBoxDrawItemEventArgs) Handles clbTasks.DrawItem

        Dim item As Kernel.Task = CType(e.Item, Kernel.Task)
        If item.TaskFinished Then
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Strikeout)

        Else

        End If




    End Sub

    ''' <summary>
    ''' Wird ausgelöst, wenn sich irgendwo eine Aufgabe ändert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainTaskListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
        m_tasks.Reload()

        clbTasks.BeginUpdate()
        For n As Integer = 0 To clbTasks.ItemCount - 1
            If CType(clbTasks.GetItem(n), Kernel.Task).TaskFinished Then
                clbTasks.SetItemChecked(n, True)
            Else
                clbTasks.SetItemChecked(n, False)
            End If
        Next
        clbTasks.EndUpdate()

        clbTasks.Refresh()
    End Sub


    Private Sub clbTasks_ItemCheck(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ItemCheckEventArgs) Handles clbTasks.ItemCheck
        ' Anwender hat eine Aufgabe als "Erledigt" markiert
        Dim task As ClausSoftware.Kernel.Task = CType(clbTasks.GetItem(e.Index), Kernel.Task)
        task.TaskFinished = CBool(e.State)
        task.Save()
        clbTasks.Refresh()
    End Sub

    Private Sub headline_MouseEnter(ByVal sender As System.Object, ByVal e As EventArgs) Handles lblTodaysTasks.MouseEnter, lblTodayAppointments.MouseEnter
        Dim ctrl As Control = CType(sender, Control)

        ctrl.Font = New Font(ctrl.Font, FontStyle.Underline)
        ctrl.Cursor = Cursors.Hand

        ctrl.Refresh()
    End Sub
    Private Sub headline_MouseLeave(ByVal sender As System.Object, ByVal e As EventArgs) Handles lblTodaysTasks.MouseLeave, lblTodayAppointments.MouseLeave
        Dim ctrl As Control = CType(sender, Control)
        ctrl.Font = New Font(ctrl.Font, FontStyle.Regular)
        ctrl.Cursor = Cursors.Default
        ctrl.Refresh()
    End Sub

    Private Sub lblTodaysTasks_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTodaysTasks.MouseClick
        m_mainUI.OpenTasksList()
    End Sub

    ''' <summary>
    ''' Öffnet das Tasks - Fenster
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowTaskList()
        m_mainUI.OpenTasksList()
    End Sub

    ''' <summary>
    ''' Öffnet das Task-Fenster und öffnet das gewählte Element
    ''' </summary>
    ''' <param name="task"></param>
    ''' <remarks></remarks>
    Private Sub OpenSelectedTask(task As Kernel.Task)
        m_mainUI.OpenTasksList(task)
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <summary>
    ''' Aktualisiert den 'Heute' - Bereich, wenn ein Termin sich geändert hat
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainAppointmentsListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
        lstAppointments.Refresh()
    End Sub


    Private Sub lblTodayAppointments_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTodayAppointments.MouseClick
        m_mainUI.OpenWorkingPane(HWLModules.Scheduler)

    End Sub

    Private Sub picCloseModule_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCloseModule.MouseClick
        RaiseEvent ClosePanel()
    End Sub

    Private Sub TodayBar_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        picCloseModule.Left = Me.Width - picCloseModule.Width - 2
    End Sub

    Private Sub TodayBar_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            picCloseModule.Image = My.Resources.Close_16x16
        End If
    End Sub

    Private Delegate Sub OpenSelectedTaskDele(task As Kernel.Task)
    Private m_OpenSelectedTaskDele As New OpenSelectedTaskDele(AddressOf OpenSelectedTask)

    Private Sub clbTasks_ItemChecking(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ItemCheckingEventArgs) Handles clbTasks.ItemChecking
        ' hier prüfen, ob die maus auf so einer checkbox steht. 

        Dim p As Point = clbTasks.PointToClient(MousePosition)

        If p.X > 21 Then ' nicht die Checkbox getroffen
            e.Cancel = True

            If clbTasks.GetItem(e.Index) IsNot Nothing Then

                Me.Invoke(m_OpenSelectedTaskDele, New Object() {clbTasks.GetItem(e.Index)})
            Else
                Me.Invoke(New MethodInvoker(AddressOf ShowTaskList))

            End If

        Else
            e.Cancel = False
        End If

    End Sub

    Private Sub clbTasks_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles clbTasks.MouseDown

    End Sub
End Class
