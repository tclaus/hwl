<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCallersList
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCallersList))
        Me.grdCallersList = New DevExpress.XtraGrid.GridControl()
        Me.cmsPhoneHandling = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnCopyCallerID = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAddCallerIDToAdress = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCreateNewContact = New System.Windows.Forms.ToolStripMenuItem()
        Me.grvCallersList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCallerID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCallerAddress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTargetID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repshowAddress = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.btnCreateTaskFromCall = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.grdCallersList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPhoneHandling.SuspendLayout()
        CType(Me.grvCallersList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repshowAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdCallersList
        '
        Me.grdCallersList.ContextMenuStrip = Me.cmsPhoneHandling
        Me.grdCallersList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCallersList.Location = New System.Drawing.Point(0, 0)
        Me.grdCallersList.MainView = Me.grvCallersList
        Me.grdCallersList.Name = "grdCallersList"
        Me.grdCallersList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repshowAddress})
        Me.grdCallersList.Size = New System.Drawing.Size(502, 309)
        Me.grdCallersList.TabIndex = 0
        Me.grdCallersList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvCallersList})
        '
        'cmsPhoneHandling
        '
        Me.cmsPhoneHandling.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnCopyCallerID, Me.btnAddCallerIDToAdress, Me.btnCreateNewContact, Me.btnCreateTaskFromCall})
        Me.cmsPhoneHandling.Name = "ContextMenuStrip1"
        Me.cmsPhoneHandling.Size = New System.Drawing.Size(199, 114)
        '
        'btnCopyCallerID
        '
        Me.btnCopyCallerID.Name = "btnCopyCallerID"
        Me.btnCopyCallerID.Size = New System.Drawing.Size(198, 22)
        Me.btnCopyCallerID.Text = "Rufnummer kopieren"
        '
        'btnAddCallerIDToAdress
        '
        Me.btnAddCallerIDToAdress.Name = "btnAddCallerIDToAdress"
        Me.btnAddCallerIDToAdress.Size = New System.Drawing.Size(198, 22)
        Me.btnAddCallerIDToAdress.Text = "Zu Kontakt hinzufügen"
        '
        'btnCreateNewContact
        '
        Me.btnCreateNewContact.Name = "btnCreateNewContact"
        Me.btnCreateNewContact.Size = New System.Drawing.Size(198, 22)
        Me.btnCreateNewContact.Text = "Neuen Kontakt anlegen"
        '
        'grvCallersList
        '
        Me.grvCallersList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colDate, Me.colCallerID, Me.colCallerAddress, Me.colTargetID})
        Me.grvCallersList.GridControl = Me.grdCallersList
        Me.grvCallersList.Name = "grvCallersList"
        Me.grvCallersList.OptionsBehavior.Editable = False
        Me.grvCallersList.OptionsDetail.EnableMasterViewMode = False
        Me.grvCallersList.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvCallersList.OptionsSelection.MultiSelect = True
        Me.grvCallersList.OptionsView.ShowGroupPanel = False
        Me.grvCallersList.OptionsView.ShowIndicator = False
        Me.grvCallersList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDate, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'colDate
        '
        Me.colDate.Caption = "Datum"
        Me.colDate.DisplayFormat.FormatString = "f"
        Me.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colDate.FieldName = "CallingDate"
        Me.colDate.Name = "colDate"
        Me.colDate.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.colDate.Visible = True
        Me.colDate.VisibleIndex = 0
        '
        'colCallerID
        '
        Me.colCallerID.Caption = "Telefonnummer"
        Me.colCallerID.FieldName = "CallingID"
        Me.colCallerID.Name = "colCallerID"
        Me.colCallerID.Visible = True
        Me.colCallerID.VisibleIndex = 1
        '
        'colCallerAddress
        '
        Me.colCallerAddress.Caption = "Teilnehmer"
        Me.colCallerAddress.FieldName = "CallerAddress"
        Me.colCallerAddress.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.colCallerAddress.Name = "colCallerAddress"
        Me.colCallerAddress.Visible = True
        Me.colCallerAddress.VisibleIndex = 2
        '
        'colTargetID
        '
        Me.colTargetID.Caption = "Zielnummer"
        Me.colTargetID.FieldName = "TargetCallID"
        Me.colTargetID.Name = "colTargetID"
        Me.colTargetID.Visible = True
        Me.colTargetID.VisibleIndex = 3
        '
        'repshowAddress
        '
        Me.repshowAddress.AutoHeight = False
        Me.repshowAddress.Name = "repshowAddress"
        '
        'btnCreateTaskFromCall
        '
        Me.btnCreateTaskFromCall.Name = "btnCreateTaskFromCall"
        Me.btnCreateTaskFromCall.Size = New System.Drawing.Size(198, 22)
        Me.btnCreateTaskFromCall.Text = "Aufgabe erstellen"
        '
        'frmCallersList
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 309)
        Me.Controls.Add(Me.grdCallersList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCallersList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Anruferliste"
        Me.TopMost = True
        CType(Me.grdCallersList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPhoneHandling.ResumeLayout(False)
        CType(Me.grvCallersList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repshowAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdCallersList As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvCallersList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCallerID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCallerAddress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents repshowAddress As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colTargetID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmsPhoneHandling As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnCopyCallerID As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddCallerIDToAdress As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCreateNewContact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCreateTaskFromCall As System.Windows.Forms.ToolStripMenuItem
End Class
