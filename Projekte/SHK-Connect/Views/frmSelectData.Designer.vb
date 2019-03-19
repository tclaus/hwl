<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectData
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblInfo = New DevExpress.XtraEditors.LabelControl()
        Me.grdFileList = New DevExpress.XtraGrid.GridControl()
        Me.grvFileList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDataInfo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFileDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFileDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCompanyName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colwayOfAuth = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdTargetLinkList = New DevExpress.XtraGrid.GridControl()
        Me.grvTargetLinkList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTargetDataInfo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTargetCompanyName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnstartDatanormImport = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.lblLinkChangeNotes = New DevExpress.XtraEditors.LabelControl()
        Me.lblStatus = New DevExpress.XtraEditors.LabelControl()
        Me.btnRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClearList = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTargetDir = New DevExpress.XtraEditors.LabelControl()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEditDownloadPath = New DevExpress.XtraEditors.SimpleButton()
        Me.colLoaded = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.grdFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTargetLinkList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvTargetLinkList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInfo
        '
        Me.lblInfo.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Appearance.Options.UseFont = True
        Me.lblInfo.Location = New System.Drawing.Point(14, 20)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(63, 15)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "Alle Dateien"
        '
        'grdFileList
        '
        Me.grdFileList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdFileList.Location = New System.Drawing.Point(14, 39)
        Me.grdFileList.MainView = Me.grvFileList
        Me.grdFileList.Name = "grdFileList"
        Me.grdFileList.ShowOnlyPredefinedDetails = True
        Me.grdFileList.Size = New System.Drawing.Size(367, 307)
        Me.grdFileList.TabIndex = 2
        Me.grdFileList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvFileList})
        '
        'grvFileList
        '
        Me.grvFileList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDataInfo, Me.colFileDescription, Me.colFileDate, Me.colCompanyName, Me.colwayOfAuth})
        Me.grvFileList.GridControl = Me.grdFileList
        Me.grvFileList.Name = "grvFileList"
        Me.grvFileList.OptionsBehavior.Editable = False
        Me.grvFileList.OptionsCustomization.AllowGroup = False
        Me.grvFileList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvFileList.OptionsView.ShowGroupPanel = False
        '
        'colDataInfo
        '
        Me.colDataInfo.Caption = "DataInfo"
        Me.colDataInfo.FieldName = "DataInfo"
        Me.colDataInfo.Name = "colDataInfo"
        Me.colDataInfo.Visible = True
        Me.colDataInfo.VisibleIndex = 0
        Me.colDataInfo.Width = 83
        '
        'colFileDescription
        '
        Me.colFileDescription.Caption = "Description"
        Me.colFileDescription.FieldName = "Description"
        Me.colFileDescription.Name = "colFileDescription"
        Me.colFileDescription.Visible = True
        Me.colFileDescription.VisibleIndex = 1
        Me.colFileDescription.Width = 180
        '
        'colFileDate
        '
        Me.colFileDate.Caption = "Datum"
        Me.colFileDate.FieldName = "FileDate"
        Me.colFileDate.Name = "colFileDate"
        Me.colFileDate.Visible = True
        Me.colFileDate.VisibleIndex = 2
        '
        'colCompanyName
        '
        Me.colCompanyName.Caption = "Name d. Firma"
        Me.colCompanyName.FieldName = "CompanyName"
        Me.colCompanyName.Name = "colCompanyName"
        Me.colCompanyName.Visible = True
        Me.colCompanyName.VisibleIndex = 3
        '
        'colwayOfAuth
        '
        Me.colwayOfAuth.Caption = "Authorisierung"
        Me.colwayOfAuth.FieldName = "Authenticode"
        Me.colwayOfAuth.Name = "colwayOfAuth"
        Me.colwayOfAuth.Visible = True
        Me.colwayOfAuth.VisibleIndex = 4
        '
        'grdTargetLinkList
        '
        Me.grdTargetLinkList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdTargetLinkList.Location = New System.Drawing.Point(481, 39)
        Me.grdTargetLinkList.MainView = Me.grvTargetLinkList
        Me.grdTargetLinkList.Name = "grdTargetLinkList"
        Me.grdTargetLinkList.ShowOnlyPredefinedDetails = True
        Me.grdTargetLinkList.Size = New System.Drawing.Size(297, 274)
        Me.grdTargetLinkList.TabIndex = 2
        Me.grdTargetLinkList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvTargetLinkList})
        '
        'grvTargetLinkList
        '
        Me.grvTargetLinkList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colLoaded, Me.colTargetDataInfo, Me.GridColumn2, Me.colTargetCompanyName})
        Me.grvTargetLinkList.GridControl = Me.grdTargetLinkList
        Me.grvTargetLinkList.Name = "grvTargetLinkList"
        Me.grvTargetLinkList.OptionsBehavior.Editable = False
        Me.grvTargetLinkList.OptionsCustomization.AllowGroup = False
        Me.grvTargetLinkList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvTargetLinkList.OptionsView.ShowGroupPanel = False
        '
        'colTargetDataInfo
        '
        Me.colTargetDataInfo.Caption = "Datainfo"
        Me.colTargetDataInfo.FieldName = "DataInfo"
        Me.colTargetDataInfo.Name = "colTargetDataInfo"
        Me.colTargetDataInfo.Visible = True
        Me.colTargetDataInfo.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Description"
        Me.GridColumn2.FieldName = "Description"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'colTargetCompanyName
        '
        Me.colTargetCompanyName.Caption = "Name d. Firma"
        Me.colTargetCompanyName.FieldName = "CompanyName"
        Me.colTargetCompanyName.Name = "colTargetCompanyName"
        Me.colTargetCompanyName.Visible = True
        Me.colTargetCompanyName.VisibleIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(481, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(118, 15)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Zum abholen markiert"
        '
        'btnstartDatanormImport
        '
        Me.btnstartDatanormImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnstartDatanormImport.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnstartDatanormImport.Appearance.Options.UseFont = True
        Me.btnstartDatanormImport.Location = New System.Drawing.Point(689, 8)
        Me.btnstartDatanormImport.Name = "btnstartDatanormImport"
        Me.btnstartDatanormImport.Size = New System.Drawing.Size(87, 27)
        Me.btnstartDatanormImport.TabIndex = 3
        Me.btnstartDatanormImport.Text = "Importieren..."
        '
        'btnAdd
        '
        Me.btnAdd.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Appearance.Options.UseFont = True
        Me.btnAdd.Location = New System.Drawing.Point(387, 99)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(87, 27)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = ">>"
        '
        'lblLinkChangeNotes
        '
        Me.lblLinkChangeNotes.Location = New System.Drawing.Point(14, 365)
        Me.lblLinkChangeNotes.Name = "lblLinkChangeNotes"
        Me.lblLinkChangeNotes.Size = New System.Drawing.Size(85, 13)
        Me.lblLinkChangeNotes.TabIndex = 4
        Me.lblLinkChangeNotes.Text = ".                           "
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.Location = New System.Drawing.Point(12, 366)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(4, 13)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Tag = "DONTTRANSLATE"
        Me.lblStatus.Text = "-"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(388, 132)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(86, 27)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "<<"
        '
        'btnClearList
        '
        Me.btnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearList.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearList.Appearance.Options.UseFont = True
        Me.btnClearList.Location = New System.Drawing.Point(481, 352)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(87, 27)
        Me.btnClearList.TabIndex = 7
        Me.btnClearList.Text = "Liste leeren"
        '
        'lblTargetDir
        '
        Me.lblTargetDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTargetDir.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTargetDir.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.lblTargetDir.Appearance.Options.UseFont = True
        Me.lblTargetDir.Appearance.Options.UseForeColor = True
        Me.lblTargetDir.AutoEllipsis = True
        Me.lblTargetDir.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTargetDir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblTargetDir.Location = New System.Drawing.Point(481, 319)
        Me.lblTargetDir.Name = "lblTargetDir"
        Me.lblTargetDir.Size = New System.Drawing.Size(246, 13)
        Me.lblTargetDir.TabIndex = 8
        Me.lblTargetDir.Text = "C:\ZipFiles"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(691, 352)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Schliessen"
        '
        'btnEditDownloadPath
        '
        Me.btnEditDownloadPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditDownloadPath.Location = New System.Drawing.Point(755, 319)
        Me.btnEditDownloadPath.Name = "btnEditDownloadPath"
        Me.btnEditDownloadPath.Size = New System.Drawing.Size(21, 18)
        Me.btnEditDownloadPath.TabIndex = 10
        Me.btnEditDownloadPath.Tag = "DONTTRANSLATE"
        Me.btnEditDownloadPath.Text = "..."
        '
        'colLoaded
        '
        Me.colLoaded.Caption = "Status"
        Me.colLoaded.Name = "colLoaded"
        Me.colLoaded.Visible = True
        Me.colLoaded.VisibleIndex = 0
        Me.colLoaded.Width = 40
        '
        'frmSelectData
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 391)
        Me.Controls.Add(Me.btnEditDownloadPath)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblTargetDir)
        Me.Controls.Add(Me.btnClearList)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblLinkChangeNotes)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnstartDatanormImport)
        Me.Controls.Add(Me.grdTargetLinkList)
        Me.Controls.Add(Me.grdFileList)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.lblInfo)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(804, 800)
        Me.MinimumSize = New System.Drawing.Size(804, 280)
        Me.Name = "frmSelectData"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Daten wählen"
        CType(Me.grdFileList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvFileList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTargetLinkList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvTargetLinkList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblInfo As DevExpress.XtraEditors.LabelControl
    Private WithEvents grdFileList As DevExpress.XtraGrid.GridControl
    Private WithEvents grvFileList As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents colDataInfo As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents colFileDescription As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents grdTargetLinkList As DevExpress.XtraGrid.GridControl
    Private WithEvents grvTargetLinkList As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents colTargetDataInfo As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnstartDatanormImport As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnAdd As DevExpress.XtraEditors.SimpleButton
    Private WithEvents lblLinkChangeNotes As DevExpress.XtraEditors.LabelControl
    Private WithEvents colFileDate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents colCompanyName As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents colTargetCompanyName As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents lblStatus As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnRemove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colwayOfAuth As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnClearList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTargetDir As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEditDownloadPath As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colLoaded As DevExpress.XtraGrid.Columns.GridColumn
End Class
