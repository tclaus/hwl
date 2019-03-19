Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms


Partial Public Class frmReplace
    Inherits ClausSoftware.HWLInterops.BaseForm
    Private rtb As RichTextBox
    Public ReadOnly Property RichText() As RichTextBox
        Get
            Return rtb
        End Get
    End Property

    Public Sub New(ByVal r As RichTextBox, ByVal rec As Rectangle)
        rtb = r
        InitializeComponent()
        txtFind.Text = rtb.SelectedText
        Me.Location = New Point(rec.X + (rec.Width - Me.Width) \ 2, rec.Y + (rec.Height - Me.Height) \ 2)
        txtFind_TextChanged(Nothing, Nothing)
    End Sub

    Protected ReadOnly Property FindsOptions() As RichTextBoxFinds
        Get
            Dim rtf As RichTextBoxFinds = New RichTextBoxFinds()
            If chWholeword.Checked Then
                rtf = rtf Or RichTextBoxFinds.WholeWord
            End If
            If chCase.Checked Then
                rtf = rtf Or RichTextBoxFinds.MatchCase
            End If
            Return rtf
        End Get
    End Property

    Protected Sub MessageNotFound(ByVal p As Integer)
        If p = -1 Then
            DevExpress.XtraEditors.XtraMessageBox.Show("The search text is not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Protected Function Find() As Integer
        Return rtb.Find(txtFind.Text, rtb.SelectionStart + rtb.SelectionLength, rtb.MaxLength, FindsOptions)
    End Function

    Protected Function FindForReplace() As Integer
        Return rtb.Find(txtFind.Text, rtb.SelectionStart, rtb.MaxLength, FindsOptions)
    End Function

    Private Sub btnFindNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFindNext.Click
        MessageNotFound(Find())
    End Sub

    Private Sub txtFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFind.TextChanged
        btnFindNext.Enabled = txtFind.Text <> ""
        btnReplace.Enabled = btnFindNext.Enabled
        btnReplaceAll.Enabled = btnFindNext.Enabled
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Owner.Focus()
        Close()
    End Sub

    Private Sub btnReplace_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReplace.Click
        If FindForReplace() <> -1 Then
            rtb.SelectedText = txtReplace.Text
        Else
            MessageNotFound(-1)
        End If
    End Sub

    Private Sub btnReplaceAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReplaceAll.Click
        Dim r As Integer = -1
        Dim p As Integer = 0
        rtb.SelectionStart = 0
        rtb.SelectionLength = 0
        Do While p <> -1
            p = Find()
            If p <> -1 Then
                r += 1
                rtb.SelectedText = txtReplace.Text
            End If
        Loop
        MessageNotFound(r)
    End Sub
End Class

