Imports ClausSoftware.Kernel

''' <summary>
''' stellt eine Klasse bereit, die ein Artikelbild als Dialog anzeigen kann
''' </summary>
''' <remarks></remarks>
Public Class ArticlePictureBox

    Public Sub New()
        MyBase.New()


    End Sub


    Friend Sub ShowImage(ByVal imageData As ImageData)
        Using ImageBox As New frmPicture(imageData)


            If imageData IsNot Nothing Then
                ImageBox.picImage.Image = imageData.Image
                ImageBox.SetImageData()


                ImageBox.lbldateValue.Text = imageData.FileDate.ToString("MM.dd.yyyy")
                ImageBox.lblnameValue.Text = imageData.Name
                ImageBox.lblSizeValue.Text = imageData.Resolution
                ImageBox.lblDescriptionValue.Text = imageData.Description


            End If
            ImageBox.ShowDialog()
        End Using

    End Sub

End Class

