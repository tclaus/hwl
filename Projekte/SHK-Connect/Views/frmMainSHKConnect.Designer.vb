<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainSHKConnect
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainSHKConnect))
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnStartImport = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lstBranche = New DevExpress.XtraEditors.ListBoxControl()
        Me.grdSHKConnectCompaniesList = New DevExpress.XtraGrid.GridControl()
        Me.grvSHKConnectCompaniesList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFavorit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repFavoriteCheckbox = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStrasse = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPLZ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHasCredentials = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lblStatusText = New DevExpress.XtraEditors.LabelControl()
        Me.picRefreshTradeList = New DevExpress.XtraEditors.PictureEdit()
        Me.picRefreshCompaniesList = New DevExpress.XtraEditors.PictureEdit()
        Me.btnEditAccessData = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.lstBranche, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSHKConnectCompaniesList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvSHKConnectCompaniesList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repFavoriteCheckbox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRefreshTradeList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRefreshCompaniesList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.Location = New System.Drawing.Point(455, 226)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Schliessen"
        '
        'btnStartImport
        '
        Me.btnStartImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartImport.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartImport.Appearance.Options.UseFont = True
        Me.btnStartImport.Image = Global.SHK_Connect.My.Resources.Resources.Download_24x24
        Me.btnStartImport.Location = New System.Drawing.Point(326, 226)
        Me.btnStartImport.Name = "btnStartImport"
        Me.btnStartImport.Size = New System.Drawing.Size(123, 27)
        Me.btnStartImport.TabIndex = 0
        Me.btnStartImport.Text = "Daten holen..."
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(14, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 15)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Branche"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(180, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(73, 15)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Unternehmen"
        '
        'lstBranche
        '
        Me.lstBranche.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstBranche.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBranche.Appearance.Options.UseFont = True
        Me.lstBranche.Items.AddRange(New Object() {"-Favoriten-", "Heizung", "Elektrik", "Metallbau", ""})
        Me.lstBranche.Location = New System.Drawing.Point(14, 33)
        Me.lstBranche.Name = "lstBranche"
        Me.lstBranche.Size = New System.Drawing.Size(140, 187)
        Me.lstBranche.TabIndex = 2
        '
        'grdSHKConnectCompaniesList
        '
        Me.grdSHKConnectCompaniesList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdSHKConnectCompaniesList.Location = New System.Drawing.Point(180, 33)
        Me.grdSHKConnectCompaniesList.MainView = Me.grvSHKConnectCompaniesList
        Me.grdSHKConnectCompaniesList.Name = "grdSHKConnectCompaniesList"
        Me.grdSHKConnectCompaniesList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repFavoriteCheckbox})
        Me.grdSHKConnectCompaniesList.Size = New System.Drawing.Size(347, 187)
        Me.grdSHKConnectCompaniesList.TabIndex = 3
        Me.grdSHKConnectCompaniesList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvSHKConnectCompaniesList})
        '
        'grvSHKConnectCompaniesList
        '
        Me.grvSHKConnectCompaniesList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFavorit, Me.colID, Me.colName, Me.colStrasse, Me.colPLZ, Me.colLand, Me.colHasCredentials})
        Me.grvSHKConnectCompaniesList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grvSHKConnectCompaniesList.GridControl = Me.grdSHKConnectCompaniesList
        Me.grvSHKConnectCompaniesList.Name = "grvSHKConnectCompaniesList"
        Me.grvSHKConnectCompaniesList.OptionsCustomization.AllowGroup = False
        Me.grvSHKConnectCompaniesList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvSHKConnectCompaniesList.OptionsView.ShowAutoFilterRow = True
        Me.grvSHKConnectCompaniesList.OptionsView.ShowGroupPanel = False
        '
        'colFavorit
        '
        Me.colFavorit.Caption = "Favorit"
        Me.colFavorit.ColumnEdit = Me.repFavoriteCheckbox
        Me.colFavorit.FieldName = "IsFavorite"
        Me.colFavorit.Name = "colFavorit"
        Me.colFavorit.Visible = True
        Me.colFavorit.VisibleIndex = 0
        Me.colFavorit.Width = 54
        '
        'repFavoriteCheckbox
        '
        Me.repFavoriteCheckbox.AutoHeight = False
        Me.repFavoriteCheckbox.Name = "repFavoriteCheckbox"
        '
        'colID
        '
        Me.colID.Caption = "ID"
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.AllowEdit = False
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 1
        Me.colID.Width = 60
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.OptionsColumn.AllowEdit = False
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 2
        Me.colName.Width = 86
        '
        'colStrasse
        '
        Me.colStrasse.Caption = "Strasse"
        Me.colStrasse.FieldName = "Strasse"
        Me.colStrasse.Name = "colStrasse"
        Me.colStrasse.OptionsColumn.AllowEdit = False
        Me.colStrasse.Visible = True
        Me.colStrasse.VisibleIndex = 3
        Me.colStrasse.Width = 86
        '
        'colPLZ
        '
        Me.colPLZ.Caption = "PLZ"
        Me.colPLZ.FieldName = "PLZ"
        Me.colPLZ.Name = "colPLZ"
        Me.colPLZ.OptionsColumn.AllowEdit = False
        Me.colPLZ.Visible = True
        Me.colPLZ.VisibleIndex = 4
        Me.colPLZ.Width = 86
        '
        'colLand
        '
        Me.colLand.Caption = "Land"
        Me.colLand.FieldName = "Land"
        Me.colLand.Name = "colLand"
        Me.colLand.OptionsColumn.AllowEdit = False
        Me.colLand.Visible = True
        Me.colLand.VisibleIndex = 5
        Me.colLand.Width = 93
        '
        'colHasCredentials
        '
        Me.colHasCredentials.Caption = "Zugangsdaten"
        Me.colHasCredentials.FieldName = "HasCredentials"
        Me.colHasCredentials.Name = "colHasCredentials"
        Me.colHasCredentials.Visible = True
        Me.colHasCredentials.VisibleIndex = 6
        '
        'lblStatusText
        '
        Me.lblStatusText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatusText.Location = New System.Drawing.Point(0, 250)
        Me.lblStatusText.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.lblStatusText.Name = "lblStatusText"
        Me.lblStatusText.Padding = New System.Windows.Forms.Padding(15, 0, 0, 0)
        Me.lblStatusText.Size = New System.Drawing.Size(19, 13)
        Me.lblStatusText.TabIndex = 4
        Me.lblStatusText.Text = "-"
        '
        'picRefreshTradeList
        '
        Me.picRefreshTradeList.EditValue = Global.SHK_Connect.My.Resources.Resources.Refresh_16x16
        Me.picRefreshTradeList.Location = New System.Drawing.Point(132, 7)
        Me.picRefreshTradeList.Name = "picRefreshTradeList"
        Me.picRefreshTradeList.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picRefreshTradeList.Properties.Appearance.Options.UseBackColor = True
        Me.picRefreshTradeList.Size = New System.Drawing.Size(22, 22)
        Me.picRefreshTradeList.TabIndex = 5
        '
        'picRefreshCompaniesList
        '
        Me.picRefreshCompaniesList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picRefreshCompaniesList.EditValue = Global.SHK_Connect.My.Resources.Resources.Refresh_16x16
        Me.picRefreshCompaniesList.Location = New System.Drawing.Point(505, 7)
        Me.picRefreshCompaniesList.Name = "picRefreshCompaniesList"
        Me.picRefreshCompaniesList.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picRefreshCompaniesList.Properties.Appearance.Options.UseBackColor = True
        Me.picRefreshCompaniesList.Size = New System.Drawing.Size(22, 22)
        Me.picRefreshCompaniesList.TabIndex = 5
        '
        'btnEditAccessData
        '
        Me.btnEditAccessData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditAccessData.Image = Global.SHK_Connect.My.Resources.Resources.Symbol_Security_Unlocked
        Me.btnEditAccessData.Location = New System.Drawing.Point(180, 226)
        Me.btnEditAccessData.Name = "btnEditAccessData"
        Me.btnEditAccessData.Size = New System.Drawing.Size(133, 27)
        Me.btnEditAccessData.TabIndex = 6
        Me.btnEditAccessData.Text = "Zugangsdaten..."
        '
        'frmMainSHKConnect
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 265)
        Me.Controls.Add(Me.btnEditAccessData)
        Me.Controls.Add(Me.picRefreshCompaniesList)
        Me.Controls.Add(Me.picRefreshTradeList)
        Me.Controls.Add(Me.lblStatusText)
        Me.Controls.Add(Me.grdSHKConnectCompaniesList)
        Me.Controls.Add(Me.lstBranche)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnStartImport)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(570, 303)
        Me.Name = "frmMainSHKConnect"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SHK Connect Import"
        CType(Me.lstBranche, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSHKConnectCompaniesList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvSHKConnectCompaniesList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repFavoriteCheckbox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRefreshTradeList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRefreshCompaniesList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnStartImport As DevExpress.XtraEditors.SimpleButton
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Private WithEvents lstBranche As DevExpress.XtraEditors.ListBoxControl
    Private WithEvents grdSHKConnectCompaniesList As DevExpress.XtraGrid.GridControl
    Private WithEvents grvSHKConnectCompaniesList As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents colFavorit As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents colStrasse As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents colPLZ As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents colLand As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents lblStatusText As DevExpress.XtraEditors.LabelControl
    Private WithEvents picRefreshTradeList As DevExpress.XtraEditors.PictureEdit
    Private WithEvents picRefreshCompaniesList As DevExpress.XtraEditors.PictureEdit
    Private WithEvents repFavoriteCheckbox As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colHasCredentials As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnEditAccessData As DevExpress.XtraEditors.SimpleButton

End Class
