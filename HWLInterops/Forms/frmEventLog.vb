

''' <summary>
''' Stellt eine Übersicht der letzten History-Einträge bereit
''' 
''' </summary>
''' <remarks></remarks>
Public Class frmEventLog


    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
    Private m_History As ClausSoftware.Kernel.AddressHistoryItems

    Public ReadOnly Property History() As ClausSoftware.Kernel.AddressHistoryItems
        Get

            If m_History Is Nothing Then
                m_History = New ClausSoftware.Kernel.AddressHistoryItems(MainApplication.getInstance)
            End If

            Return m_History
        End Get
    End Property

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Private Sub frmEventLog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub frmEventLog_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        grdEventLog.DataSource = History


    End Sub

    Private Sub frmEventLog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        History.Reload()

    End Sub
End Class