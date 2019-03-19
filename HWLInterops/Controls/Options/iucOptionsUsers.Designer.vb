<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucOptionsUsers
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstUsers = New DevExpress.XtraEditors.ListBoxControl()
        Me.grpUserRights = New DevExpress.XtraEditors.GroupControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.chkPermission = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEditUser = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        CType(Me.lstUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpUserRights, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpUserRights.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPermission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstUsers
        '
        Me.lstUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstUsers.Location = New System.Drawing.Point(0, 0)
        Me.lstUsers.Name = "lstUsers"
        Me.lstUsers.Size = New System.Drawing.Size(157, 314)
        Me.lstUsers.TabIndex = 0
        '
        'grpUserRights
        '
        Me.grpUserRights.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpUserRights.Controls.Add(Me.GridControl1)
        Me.grpUserRights.Location = New System.Drawing.Point(3, 3)
        Me.grpUserRights.Name = "grpUserRights"
        Me.grpUserRights.Size = New System.Drawing.Size(431, 261)
        Me.grpUserRights.TabIndex = 1
        Me.grpUserRights.Text = "Berechtigungen"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(2, 22)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkPermission})
        Me.GridControl1.Size = New System.Drawing.Size(427, 237)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'chkPermission
        '
        Me.chkPermission.AutoHeight = False
        Me.chkPermission.Name = "chkPermission"
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Location = New System.Drawing.Point(275, 280)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 4
        Me.btnNew.Text = "Neu..."
        Me.btnNew.ToolTip = "Neuen Benutzer anlegen"
        '
        'btnEditUser
        '
        Me.btnEditUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditUser.Location = New System.Drawing.Point(356, 280)
        Me.btnEditUser.Name = "btnEditUser"
        Me.btnEditUser.Size = New System.Drawing.Size(75, 23)
        Me.btnEditUser.TabIndex = 4
        Me.btnEditUser.Text = "Bearbeiten"
        Me.btnEditUser.Visible = False
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lstUsers)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.grpUserRights)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnNew)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnEditUser)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(603, 314)
        Me.SplitContainerControl1.SplitterPosition = 157
        Me.SplitContainerControl1.TabIndex = 5
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'iucOptionsUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "iucOptionsUsers"
        Me.Size = New System.Drawing.Size(603, 314)
        CType(Me.lstUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpUserRights, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpUserRights.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPermission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstUsers As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents grpUserRights As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEditUser As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents chkPermission As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

End Class
