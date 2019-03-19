
''' <summary>
''' Stellt ein Steuerelement zur Verfügung, das RTF - Texte speichern kann
''' </summary>
''' <remarks></remarks>
Public Class frmRTFItemDescriptionEdit


    ''' <summary>
    ''' Ruft reinen Text ab oder setzt diesen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PlainText() As String
        Get
            Return rtfMemoTextControl.Text
        End Get
        Set(ByVal value As String)
            rtfMemoTextControl.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Leert die Texteingabe
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        rtfMemoTextControl.ResetText()

    End Sub

    ''' <summary>
    ''' Ruft den formatierten Text ab oder legt diesen fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RTFText() As String
        Get
            Return rtfMemoTextControl.RtfText
        End Get
        Set(ByVal value As String)
            rtfMemoTextControl.RtfText = value

        End Set
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
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

    Private Sub txtmemo_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles rtfMemoTextControl.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub

    Private Sub txtmemo_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles rtfMemoTextControl.DragDrop
        DragDropHelper.SetText(sender, e)
    End Sub

End Class