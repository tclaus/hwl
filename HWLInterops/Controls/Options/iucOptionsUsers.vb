Public Class iucOptionsUsers
    Implements IOptionMenue

    Public ReadOnly Property DisplayName() As String Implements IOptionMenue.DisplayName
        Get
            Return "Benuzterverwaltung" 'TODO: NLS
        End Get
    End Property

    Public Sub Initialize() Implements IOptionMenue.Initialize
        If MainApplication.getInstance IsNot Nothing Then
            lstUsers.DataSource = MainApplication.getInstance.Users
        End If
    End Sub

    Public Sub Reload() Implements IOptionMenue.Reload
        MainApplication.getInstance.Users.Reload()
    End Sub

    Public Sub Save() Implements IOptionMenue.Save
        MainApplication.getInstance.Users.Save()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ShowCreateNewUser()
    End Sub

    Private Sub ShowCreateNewUser()
        Dim newuser As Kernel.Security.User = MainApplication.getInstance.Users.GetNewItem
        Dim frm As New frmUseredit
        frm.UserAccount = newuser
        If frm.ShowDialog() = DialogResult.OK Then
            newuser.Save()
            MainApplication.getInstance.Users.Reload()
        End If


    End Sub

    Private Sub ShowEditNewUser(ByVal edituser As Kernel.Security.User)

        Dim frm As New frmUseredit
        frm.UserAccount = edituser
        If frm.ShowDialog() = DialogResult.OK Then
            edituser.Save()
            MainApplication.getInstance.Users.Reload()
        End If


    End Sub
    ''' <summary>
    ''' Erstellt aus den Listen ein DataGrid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GenerateRightsList()
        'Modulname |Rights list
        ' Briefe   | read | Write
        Dim rightsList As New List(Of rightProxy)

        For Each item As String In [Enum].GetNames(GetType(Kernel.Security.PermissionModules))
            Dim newRight As New rightProxy()
            newRight.ModulName = item
            newRight.None = True
            rightsList.Add(newRight)
        Next

        GridControl1.DataSource = rightsList
        GridView1.Columns(0).OptionsColumn.AllowEdit = False
        GridView1.Columns(1).ColumnEdit = chkPermission
        GridView1.Columns(2).ColumnEdit = chkPermission
        GridView1.Columns(3).ColumnEdit = chkPermission


    End Sub

    ''' <summary>
    ''' Stellt eine einefache Klasse dar, die das Rechte-system enthält
    ''' </summary>
    ''' <remarks></remarks>
    Class rightProxy
        Implements INotifyPropertyChanged



        Private m_rightName As String

        Private m_none As Boolean

        Private m_readOnly As Boolean

        Private m_write As Boolean
        Private m_displayname As String


        <System.ComponentModel.DisplayName("Modulname")>
        Public ReadOnly Property ModuldisplayName() As String
            Get
                'TODO: hier eiun Gettext einsetzen
                Return Me.ModulName
            End Get

        End Property

        ''' <summary>
        ''' Ist true, wenn der Anwender Schreibrechte besitzt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Write() As Boolean
            Get
                Return m_write
            End Get
            Set(ByVal value As Boolean)

                m_write = value
                If value Then
                    [ReadOnly] = False
                    None = False
                End If
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Write"))
            End Set
        End Property

        ''' <summary>
        ''' Ist True, wenn das Modul nur Leserechte enthält
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property [ReadOnly]() As Boolean
            Get
                Return m_readOnly
            End Get
            Set(ByVal value As Boolean)
                m_readOnly = value
                If value Then
                    None = False
                    Write = False
                End If
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("[ReadOnly]"))

            End Set
        End Property

        ''' <summary>
        ''' Ist True, wenn dieses Modul keinerlei Rechte enthält
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property None() As Boolean
            Get
                Return m_none
            End Get
            Set(ByVal value As Boolean)
                m_none = value
                If value Then
                    [ReadOnly] = False
                    Write = False
                End If
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("[None]"))

            End Set
        End Property

        ''' <summary>
        ''' Ruft den Modulnamen ab, der dieses recht enthält
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)>
        Public Property ModulName() As String
            Get
                Return m_rightName
            End Get
            Set(ByVal value As String)
                m_rightName = value
            End Set
        End Property



        Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    End Class

    ''' <summary>
    ''' Ruft den Anzeigenamen dieses Controls ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return Me.DisplayName
    End Function
    Private Sub lstUsers_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstUsers.MouseDoubleClick
        If lstUsers.SelectedItem IsNot Nothing Then
            ShowEditNewUser(CType(lstUsers.SelectedItem, Kernel.Security.User))
        End If

    End Sub

    Private Sub lstUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUsers.SelectedIndexChanged

        Dim user As Kernel.Security.User


        If lstUsers.SelectedItem IsNot Nothing Then

            user = CType(lstUsers.SelectedItem, Kernel.Security.User)

            GenerateRightsList()
        End If

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim user As rightProxy = CType(GridView1.GetRow(e.RowHandle), rightProxy)
        GridControl1.RefreshDataSource()
    End Sub



    Private Sub btnEditUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditUser.Click
        If lstUsers.SelectedItem IsNot Nothing Then
            ShowEditNewUser(CType(lstUsers.SelectedItem, Kernel.Security.User))
        End If
    End Sub

    Private Sub GridView1_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging

    End Sub

    Private Sub GridView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridView1.MouseUp
        GridView1.UpdateCurrentRow()
        GridControl1.RefreshDataSource()
    End Sub

    Private Sub GridView1_RowCellClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        GridView1.UpdateCurrentRow()
        GridControl1.RefreshDataSource()
    End Sub

    Private Sub chkPermission_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPermission.EditValueChanged
        GridView1.PostEditor()
    End Sub

    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False

        End Get
    End Property

    Private Sub iucOptionsUsers_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)
    End Sub
End Class
