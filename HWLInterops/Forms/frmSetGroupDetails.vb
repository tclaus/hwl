Imports ClausSoftware.Kernel

''' <summary>
''' Enthält Details zu einer Artikelgruppe
''' </summary>
''' <remarks></remarks>
Public Class frmSetGroupDetails

    Private m_group As Group

    ''' <summary>
    ''' Ruft die verwendete Gruppe ab oder legt Details der Guppe fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property Group() As Group
        Get
            Return m_group
        End Get
        Set(ByVal value As Group)
            m_group = value
        End Set
    End Property

    Private Sub FillControls()
        txtGroupDescription.Text = Group.Description
        txtGroupName.Text = Group.Name
        picGroupPicture.Image = Group.GetImage

    End Sub

    Private Sub SaveData()
        Group.Name = txtGroupName.Text
        Group.Description = txtGroupDescription.Text
        Group.SetImage(picGroupPicture.Image)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveData()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmSetGroupDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

        FillControls()
    End Sub
End Class