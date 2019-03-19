Option Explicit On
Option Strict On

Namespace Offers
    ''' <summary>
    ''' stellt einen einfachen dialog vereit, der den MEMO-Text eines Angebots-Artikels nthält
    ''' </summary>
    ''' <remarks></remarks>
    Public Class frmeditItemsDescription



        Public Property Description() As String
            Get
                Return txtmemo.Text
            End Get
            Set(ByVal value As String)
                txtmemo.Text = value
            End Set
        End Property



        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub frmeditItemsDescription_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            m_application.Settings.SaveFormsPos(Me)

        End Sub

        Private Sub frmeditItemsDescription_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            m_application.Languages.SetTextOnControl(Me)
            m_application.Settings.RestoreFormsPos(Me)
        End Sub

        Private Sub txtmemo_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtmemo.DragEnter
            DragDropHelper.CheckForText(sender, e)
        End Sub

        Private Sub txtmemo_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtmemo.DragDrop
            DragDropHelper.SetText(sender, e)
        End Sub
    End Class
End Namespace
