Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Partial Public Class frmFind
    Inherits XtraForm
    Private rtb As RichTextBox
    Public ReadOnly Property RichText() As RichTextBox
        Get
            Return rtb
        End Get
    End Property

    Public Sub New(ByVal r As RichTextBox, ByVal rec As Rectangle)
        rtb = r
        rtb.SelectionStart = 0
        InitializeComponent()
        Me.Location = New Point(rec.X + (rec.Width - Me.Width) \ 2, rec.Y + (rec.Height - Me.Height) \ 2)
        txtFind_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub btnFindNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFindNext.Click
        Dim rtf As RichTextBoxFinds = New RichTextBoxFinds()
        If chWholeword.Checked Then
            rtf = rtf Or RichTextBoxFinds.WholeWord
        End If
        If chCase.Checked Then
            rtf = rtf Or RichTextBoxFinds.MatchCase
        End If
        Dim p As Integer = rtb.Find(txtFind.Text, rtb.SelectionStart + rtb.SelectionLength, rtb.MaxLength, rtf)
        If p = -1 Then
            XtraMessageBox.Show("The search text is not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFind.TextChanged
        btnFindNext.Enabled = txtFind.Text <> ""
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Owner.Focus()
        Close()
    End Sub
End Class

