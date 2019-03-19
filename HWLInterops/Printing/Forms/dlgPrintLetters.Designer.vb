Namespace Printing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class dlgPrintLetters
        Inherits ClausSoftware.HWLInterops.BaseForm

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
            Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            Me.btnPrintPreview = New DevExpress.XtraEditors.SimpleButton()
            Me.chkPrintBusinesLayout = New DevExpress.XtraEditors.CheckEdit()
            Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
            Me.grpWhatToPrint = New DevExpress.XtraEditors.GroupControl()
            Me.grdPrintLayouts = New DevExpress.XtraGrid.GridControl()
            Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.colToPrint = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repChkToPrint = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
            Me.colTemplateName = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repLayoutName = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            Me.colPageCount = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.repComboboxedit = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
            Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.chkPrintBusinesLayout.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grpWhatToPrint, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpWhatToPrint.SuspendLayout()
            CType(Me.grdPrintLayouts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repChkToPrint, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repLayoutName, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repComboboxedit, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Appearance.Options.UseFont = True
            Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnClose.Location = New System.Drawing.Point(204, 85)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(87, 27)
            Me.btnClose.TabIndex = 0
            Me.btnClose.Text = "Schiessen"
            '
            'btnPrintPreview
            '
            Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPrintPreview.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintPreview.Appearance.Options.UseFont = True
            Me.btnPrintPreview.Location = New System.Drawing.Point(204, 14)
            Me.btnPrintPreview.Name = "btnPrintPreview"
            Me.btnPrintPreview.Size = New System.Drawing.Size(87, 27)
            Me.btnPrintPreview.TabIndex = 0
            Me.btnPrintPreview.Text = "Vorschau..."
            '
            'chkPrintBusinesLayout
            '
            Me.chkPrintBusinesLayout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.chkPrintBusinesLayout.Location = New System.Drawing.Point(28, 45)
            Me.chkPrintBusinesLayout.Name = "chkPrintBusinesLayout"
            Me.chkPrintBusinesLayout.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintBusinesLayout.Properties.Appearance.Options.UseFont = True
            Me.chkPrintBusinesLayout.Properties.Caption = "Mit Briefkopf"
            Me.chkPrintBusinesLayout.Size = New System.Drawing.Size(142, 20)
            Me.chkPrintBusinesLayout.TabIndex = 1
            '
            'grpWhatToPrint
            '
            Me.grpWhatToPrint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grpWhatToPrint.AppearanceCaption.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpWhatToPrint.AppearanceCaption.Options.UseFont = True
            Me.grpWhatToPrint.Controls.Add(Me.grdPrintLayouts)
            Me.grpWhatToPrint.Location = New System.Drawing.Point(14, 14)
            Me.grpWhatToPrint.Name = "grpWhatToPrint"
            Me.grpWhatToPrint.Size = New System.Drawing.Size(184, 0)
            Me.grpWhatToPrint.TabIndex = 2
            Me.grpWhatToPrint.Text = "Was möchten sie drucken?"
            '
            'grdPrintLayouts
            '
            Me.grdPrintLayouts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.grdPrintLayouts.Location = New System.Drawing.Point(2, 1)
            Me.grdPrintLayouts.MainView = Me.GridView1
            Me.grdPrintLayouts.Name = "grdPrintLayouts"
            Me.grdPrintLayouts.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repChkToPrint, Me.repLayoutName, Me.repComboboxedit})
            Me.grdPrintLayouts.Size = New System.Drawing.Size(180, 0)
            Me.grdPrintLayouts.TabIndex = 0
            Me.grdPrintLayouts.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
            '
            'GridView1
            '
            Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colToPrint, Me.colTemplateName, Me.colPageCount})
            Me.GridView1.GridControl = Me.grdPrintLayouts
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsCustomization.AllowFilter = False
            Me.GridView1.OptionsCustomization.AllowGroup = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.OptionsView.ShowIndicator = False
            '
            'colToPrint
            '
            Me.colToPrint.AppearanceHeader.Options.UseTextOptions = True
            Me.colToPrint.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.Character
            Me.colToPrint.Caption = "Drucken"
            Me.colToPrint.ColumnEdit = Me.repChkToPrint
            Me.colToPrint.FieldName = "PrintIt"
            Me.colToPrint.MaxWidth = 20
            Me.colToPrint.Name = "colToPrint"
            Me.colToPrint.ToolTip = "Drucken"
            Me.colToPrint.Visible = True
            Me.colToPrint.VisibleIndex = 0
            Me.colToPrint.Width = 20
            '
            'repChkToPrint
            '
            Me.repChkToPrint.AutoHeight = False
            Me.repChkToPrint.Name = "repChkToPrint"
            Me.repChkToPrint.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
            '
            'colTemplateName
            '
            Me.colTemplateName.Caption = "Vorlage"
            Me.colTemplateName.ColumnEdit = Me.repLayoutName
            Me.colTemplateName.FieldName = "LayoutName"
            Me.colTemplateName.Name = "colTemplateName"
            Me.colTemplateName.OptionsColumn.ReadOnly = True
            Me.colTemplateName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
            Me.colTemplateName.Visible = True
            Me.colTemplateName.VisibleIndex = 1
            Me.colTemplateName.Width = 101
            '
            'repLayoutName
            '
            Me.repLayoutName.AutoHeight = False
            Me.repLayoutName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "Öffnet den Vorlagen-Designer", Nothing, Nothing, True)})
            Me.repLayoutName.Name = "repLayoutName"
            Me.repLayoutName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            '
            'colPageCount
            '
            Me.colPageCount.Caption = "Seiten"
            Me.colPageCount.ColumnEdit = Me.repComboboxedit
            Me.colPageCount.FieldName = "PageCount"
            Me.colPageCount.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
            Me.colPageCount.Name = "colPageCount"
            Me.colPageCount.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
            Me.colPageCount.Visible = True
            Me.colPageCount.VisibleIndex = 2
            Me.colPageCount.Width = 40
            '
            'repComboboxedit
            '
            Me.repComboboxedit.AutoHeight = False
            Me.repComboboxedit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repComboboxedit.EditFormat.FormatString = "d0"
            Me.repComboboxedit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.repComboboxedit.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
            Me.repComboboxedit.Name = "repComboboxedit"
            '
            'btnPrint
            '
            Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPrint.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrint.Appearance.Options.UseFont = True
            Me.btnPrint.Location = New System.Drawing.Point(204, 47)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(87, 27)
            Me.btnPrint.TabIndex = 3
            Me.btnPrint.Text = "Drucken"
            '
            'dlgPrintLetters
            '
            Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(305, 125)
            Me.Controls.Add(Me.btnPrint)
            Me.Controls.Add(Me.grpWhatToPrint)
            Me.Controls.Add(Me.chkPrintBusinesLayout)
            Me.Controls.Add(Me.btnPrintPreview)
            Me.Controls.Add(Me.btnClose)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(321, 163)
            Me.Name = "dlgPrintLetters"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Briefe drucken..."
            CType(Me.chkPrintBusinesLayout.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grpWhatToPrint, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpWhatToPrint.ResumeLayout(False)
            CType(Me.grdPrintLayouts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repChkToPrint, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repLayoutName, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repComboboxedit, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnPrintPreview As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents chkPrintBusinesLayout As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents grpWhatToPrint As DevExpress.XtraEditors.GroupControl
        Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
        Friend WithEvents grdPrintLayouts As DevExpress.XtraGrid.GridControl
        Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents colToPrint As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents repChkToPrint As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Friend WithEvents colTemplateName As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents repLayoutName As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Friend WithEvents colPageCount As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents repComboboxedit As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    End Class

End Namespace