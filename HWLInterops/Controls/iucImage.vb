Public Class iucImage


    'Please enter any new code here, below the Interop code

    Public Enum PictureBoxSizeMode
        AutoSize = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        CenterImage = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Normal = System.Windows.Forms.PictureBoxSizeMode.Normal
        Stretch = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Zoom = System.Windows.Forms.PictureBoxSizeMode.Zoom

    End Enum

    Public Sub SetPicture(ByVal Filename As String)
        picBox.SizeMode = Windows.Forms.PictureBoxSizeMode.Zoom
        picBox.ImageLocation = Filename
        picBox.Load()
    End Sub


    Public Sub SetImageSize(ByVal mode As PictureBoxSizeMode)
        picBox.SizeMode = CType(mode, Windows.Forms.PictureBoxSizeMode)
    End Sub


End Class