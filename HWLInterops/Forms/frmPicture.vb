Option Explicit On
Option Strict On

Imports ClausSoftware.Kernel


Friend Class frmPicture

    Dim m_MouseDown As Boolean = False
    Dim m_ImageItem As ImageData

    Sub New(ByVal imageitem As imageData)
        Me.InitializeComponent()
        m_ImageItem = imageitem
    End Sub

    Private Sub frmPicture_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Visible = False
        End If
    End Sub

    Sub SetImageData()
        If picImage.Image IsNot Nothing Then
            lblSizeValue.Text = picImage.Image.Width & " x " & picImage.Image.Height
        End If

    End Sub


#Region "Drag&Drop"

    Private Sub picImage_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim filename As String = System.IO.Path.GetFileName(m_ImageItem.FilePath)

            If filename.Length = 0 Then

                filename = System.IO.Path.Combine(System.IO.Path.GetTempPath, "ArticleFile.jpg")

            Else
                filename = System.IO.Path.Combine(System.IO.Path.GetTempPath, filename)
            End If

            ' in einen tmp - Ordner verschieben 

            m_ImageItem.Image.Save(filename)

            DoDragDrop(New DataObject(DataFormats.FileDrop, New String() {filename}), DragDropEffects.Copy)
        End If

    End Sub



    ''' <summary>
    ''' Holt den Namen des Bildes ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSelection() As String()

        Dim filename As String = System.IO.Path.GetFileName(m_ImageItem.FilePath)


        Return New String() {filename}

    End Function
#End Region


End Class