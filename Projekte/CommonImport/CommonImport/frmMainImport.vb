Public Class frmMainImport 

    Private m_DatasourceArray As String() = {"Adressbuch", "Artikel"}


    ''' <summary>
    ''' ruft den Dateinamen ab, der eingelesen werden soll oder legt diesen fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileName() As String
        Get
            Return txtFilePath.EditValue.ToString
        End Get
        Set(ByVal value As String)
            txtFilePath.EditValue = value
        End Set
    End Property

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnNextImportStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextImportStep.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    ''' <summary>
    ''' Ruft den Typ ab, der Importiert werden soll
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ImportType As ImportTargetType
        Get
            If lstDatasource.SelectedIndex = 0 Then Return ImportTargetType.Adresses
            If lstDatasource.SelectedIndex = 1 Then Return ImportTargetType.Articles

            Return ImportTargetType.Adresses
        End Get
    End Property

    Private Sub frmMainImport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lstDatasource.DataSource = m_DatasourceArray
        Dim tx As Windows.Forms.TextBox = txtFilePath.MaskBox
        tx.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
        tx.AutoCompleteSource = Windows.Forms.AutoCompleteSource.FileSystem

    End Sub

    Private Sub btnBrowseFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseFiles.Click
        Dim fs As New System.Windows.Forms.OpenFileDialog
        fs.Multiselect = False        
        fs.CheckFileExists = True
        fs.Filter = "CSV |*.CSV"

        If fs.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFilePath.Text = fs.FileName
        End If
        fs.Dispose()

    End Sub

    Private Sub txtFilePath_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilePath.EditValueChanged
        CurrentImportFileExist()
    End Sub

    ''' <summary>
    ''' Gigt Wahr zurück, wenn die Datei auch tatsächlich existiert
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CurrentImportFileExist() As Boolean
        Try
            If System.IO.File.Exists(txtFilePath.Text) Then
                btnNextImportStep.Enabled = True
                Return True
            Else
                btnNextImportStep.Enabled = False
                Return False
            End If
        Catch ex As Exception
            btnNextImportStep.Enabled = False
            Return False
        End Try
    End Function

End Class