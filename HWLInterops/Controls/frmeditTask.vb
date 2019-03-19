Imports ClausSoftware.Kernel

''' <summary>
''' Stellt einen Dialog bereit, um eine einzelne Aufgabe zu bearbeiten
''' </summary>
''' <remarks></remarks>
Friend Class frmeditTask

    Private m_currentTask As Task

    Sub New(ByVal currentTask As Task)
        InitializeComponent()
        m_currentTask = currentTask
        If m_currentTask.CreateDate = Date.MinValue Then
            m_currentTask.CreateDate = Date.Today
        End If

        If m_currentTask.Expiration = Date.MinValue Then
            m_currentTask.Expiration = Nothing
        End If

    End Sub

    ''' <summary>
    ''' Füllt aus dem Task-Objekt die Steuerelemente
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillControls()
        If m_currentTask IsNot Nothing Then

            With m_currentTask
                txtSubject.Text = .Subject
                daeEndsAt.DateTime = .Expiration              
                txtMemo.Text = .Message
                chkTaskFinished.Checked = .TaskFinished
            End With
        End If
    End Sub


    ''' <summary>
    ''' Füllt das Task-Objekt auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillObject()
        If m_currentTask IsNot Nothing Then
            With m_currentTask
                .Subject = txtSubject.Text
                .Expiration = daeEndsAt.DateTime               
                .Message = txtMemo.Text
                .TaskFinished = chkTaskFinished.Checked
            End With
        End If

    End Sub




    Private Sub frmeditTask_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Languages.SetTextOnControl(Me)

        FillControls()
        txtSubject.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        FillObject()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmeditTask_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Hide()
        End If
    End Sub

    Private Sub txtSubject_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtSubject.DragEnter, txtMemo.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub

    Private Sub txtSubject_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtSubject.DragDrop, txtMemo.DragDrop
        DragDropHelper.SetText(sender, e)
    End Sub
End Class