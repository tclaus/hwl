

''' <summary>
''' Stellt eine Übersicht der letzten History-Einträge bereit
''' 
''' </summary>
''' <remarks></remarks>
Public Class frmEventLog


    Private m_application As ClausSoftware.mainApplication

    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
    Private m_History As ClausSoftware.Kernel.AddressHistoryItems

    Public ReadOnly Property History() As ClausSoftware.Kernel.AddressHistoryItems
        Get

            If m_History Is Nothing Then
                m_History = New ClausSoftware.Kernel.AddressHistoryItems(MainApplication)
            End If

            Return m_History
        End Get
    End Property


    Public Property MainApplication() As ClausSoftware.mainApplication
        Get
            Return m_application
        End Get
        Set(ByVal value As ClausSoftware.mainApplication)
            m_application = value
        End Set
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