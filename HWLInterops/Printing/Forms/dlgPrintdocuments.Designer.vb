Namespace Printing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class dlgPrintdocuments
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
            Me.repPageCount = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
            Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
            Me.lblDocumentsHeadline = New DevExpress.XtraEditors.LabelControl()
            Me.txtdocumentsHeadline = New DevExpress.XtraEditors.TextEdit()
            Me.chlShowLongText = New DevExpress.XtraEditors.CheckEdit()
            Me.lblPageCount = New DevExpress.XtraEditors.LabelControl()
            Me.txtPageCount = New DevExpress.XtraEditors.SpinEdit()
            Me.chkPrintAsDeliveryNote = New DevExpress.XtraEditors.CheckEdit()
            Me.chkPrintBusinesReportOneveryPage = New DevExpress.XtraEditors.CheckEdit()
            CType(Me.chkPrintBusinesLayout.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grpWhatToPrint, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpWhatToPrint.SuspendLayout()
            CType(Me.grdPrintLayouts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repChkToPrint, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repLayoutName, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.repPageCount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtdocumentsHeadline.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chlShowLongText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.txtPageCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkPrintAsDeliveryNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkPrintBusinesReportOneveryPage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Appearance.Options.UseFont = True
            Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnClose.Location = New System.Drawing.Point(359, 242)
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
            Me.btnPrintPreview.Location = New System.Drawing.Point(359, 14)
            Me.btnPrintPreview.Name = "btnPrintPreview"
            Me.btnPrintPreview.Size = New System.Drawing.Size(87, 27)
            Me.btnPrintPreview.TabIndex = 0
            Me.btnPrintPreview.Text = "Vorschau..."
            '
            'chkPrintBusinesLayout
            '
            Me.chkPrintBusinesLayout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.chkPrintBusinesLayout.Location = New System.Drawing.Point(264, 165)
            Me.chkPrintBusinesLayout.Name = "chkPrintBusinesLayout"
            Me.chkPrintBusinesLayout.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintBusinesLayout.Properties.Appearance.Options.UseFont = True
            Me.chkPrintBusinesLayout.Properties.Caption = "Mit Briefkopf"
            Me.chkPrintBusinesLayout.Size = New System.Drawing.Size(193, 20)
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
            Me.grpWhatToPrint.Size = New System.Drawing.Size(339, 131)
            Me.grpWhatToPrint.TabIndex = 2
            Me.grpWhatToPrint.Text = "Druckvorlage wählen"
            '
            'grdPrintLayouts
            '
            Me.grdPrintLayouts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.grdPrintLayouts.Location = New System.Drawing.Point(2, 24)
            Me.grdPrintLayouts.MainView = Me.GridView1
            Me.grdPrintLayouts.Name = "grdPrintLayouts"
            Me.grdPrintLayouts.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repChkToPrint, Me.repLayoutName, Me.repPageCount})
            Me.grdPrintLayouts.Size = New System.Drawing.Size(335, 105)
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
            Me.colPageCount.ColumnEdit = Me.repPageCount
            Me.colPageCount.FieldName = "PageCount"
            Me.colPageCount.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right
            Me.colPageCount.Name = "colPageCount"
            Me.colPageCount.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
            Me.colPageCount.Width = 40
            '
            'repPageCount
            '
            Me.repPageCount.AutoHeight = False
            Me.repPageCount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.repPageCount.EditFormat.FormatString = "d0"
            Me.repPageCount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.repPageCount.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
            Me.repPageCount.Name = "repPageCount"
            '
            'btnPrint
            '
            Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPrint.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrint.Appearance.Options.UseFont = True
            Me.btnPrint.Location = New System.Drawing.Point(359, 47)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(87, 27)
            Me.btnPrint.TabIndex = 3
            Me.btnPrint.Text = "Drucken"
            '
            'lblDocumentsHeadline
            '
            Me.lblDocumentsHeadline.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblDocumentsHeadline.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDocumentsHeadline.Appearance.Options.UseFont = True
            Me.lblDocumentsHeadline.Location = New System.Drawing.Point(16, 168)
            Me.lblDocumentsHeadline.Name = "lblDocumentsHeadline"
            Me.lblDocumentsHeadline.Size = New System.Drawing.Size(61, 15)
            Me.lblDocumentsHeadline.TabIndex = 4
            Me.lblDocumentsHeadline.Text = "Überschrift:"
            '
            'txtdocumentsHeadline
            '
            Me.txtdocumentsHeadline.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtdocumentsHeadline.Location = New System.Drawing.Point(150, 163)
            Me.txtdocumentsHeadline.Name = "txtdocumentsHeadline"
            Me.txtdocumentsHeadline.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtdocumentsHeadline.Properties.Appearance.Options.UseFont = True
            Me.txtdocumentsHeadline.Size = New System.Drawing.Size(98, 22)
            Me.txtdocumentsHeadline.TabIndex = 5
            '
            'chlShowLongText
            '
            Me.chlShowLongText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.chlShowLongText.Location = New System.Drawing.Point(14, 219)
            Me.chlShowLongText.Name = "chlShowLongText"
            Me.chlShowLongText.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chlShowLongText.Properties.Appearance.Options.UseFont = True
            Me.chlShowLongText.Properties.Caption = "Langtexte ausdrucken"
            Me.chlShowLongText.Size = New System.Drawing.Size(147, 20)
            Me.chlShowLongText.TabIndex = 6
            Me.chlShowLongText.Visible = False
            '
            'lblPageCount
            '
            Me.lblPageCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblPageCount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPageCount.Appearance.Options.UseFont = True
            Me.lblPageCount.Location = New System.Drawing.Point(16, 194)
            Me.lblPageCount.Name = "lblPageCount"
            Me.lblPageCount.Size = New System.Drawing.Size(93, 15)
            Me.lblPageCount.TabIndex = 7
            Me.lblPageCount.Text = "Anzahl Exemplare"
            '
            'txtPageCount
            '
            Me.txtPageCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtPageCount.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.txtPageCount.Location = New System.Drawing.Point(150, 191)
            Me.txtPageCount.Name = "txtPageCount"
            Me.txtPageCount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPageCount.Properties.Appearance.Options.UseFont = True
            Me.txtPageCount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.txtPageCount.Properties.Mask.EditMask = "f0"
            Me.txtPageCount.Properties.MaxValue = New Decimal(New Integer() {255, 0, 0, 0})
            Me.txtPageCount.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
            Me.txtPageCount.Size = New System.Drawing.Size(44, 22)
            Me.txtPageCount.TabIndex = 8
            '
            'chkPrintAsDeliveryNote
            '
            Me.chkPrintAsDeliveryNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.chkPrintAsDeliveryNote.Location = New System.Drawing.Point(264, 191)
            Me.chkPrintAsDeliveryNote.Name = "chkPrintAsDeliveryNote"
            Me.chkPrintAsDeliveryNote.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintAsDeliveryNote.Properties.Appearance.Options.UseFont = True
            Me.chkPrintAsDeliveryNote.Properties.Caption = "Preise ausblenden"
            Me.chkPrintAsDeliveryNote.Size = New System.Drawing.Size(193, 20)
            Me.chkPrintAsDeliveryNote.TabIndex = 9
            '
            'chkPrintBusinesReportOneveryPage
            '
            Me.chkPrintBusinesReportOneveryPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.chkPrintBusinesReportOneveryPage.Location = New System.Drawing.Point(264, 217)
            Me.chkPrintBusinesReportOneveryPage.Name = "chkPrintBusinesReportOneveryPage"
            Me.chkPrintBusinesReportOneveryPage.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintBusinesReportOneveryPage.Properties.Appearance.Options.UseFont = True
            Me.chkPrintBusinesReportOneveryPage.Properties.Caption = "Auf jeder Seite drucken"
            Me.chkPrintBusinesReportOneveryPage.Size = New System.Drawing.Size(193, 20)
            Me.chkPrintBusinesReportOneveryPage.TabIndex = 10
            '
            'dlgPrintdocuments
            '
            Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(460, 282)
            Me.Controls.Add(Me.chkPrintBusinesReportOneveryPage)
            Me.Controls.Add(Me.chkPrintAsDeliveryNote)
            Me.Controls.Add(Me.txtPageCount)
            Me.Controls.Add(Me.lblPageCount)
            Me.Controls.Add(Me.chlShowLongText)
            Me.Controls.Add(Me.txtdocumentsHeadline)
            Me.Controls.Add(Me.lblDocumentsHeadline)
            Me.Controls.Add(Me.btnPrint)
            Me.Controls.Add(Me.grpWhatToPrint)
            Me.Controls.Add(Me.chkPrintBusinesLayout)
            Me.Controls.Add(Me.btnPrintPreview)
            Me.Controls.Add(Me.btnClose)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(476, 320)
            Me.Name = "dlgPrintdocuments"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Drucken..."
            CType(Me.chkPrintBusinesLayout.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grpWhatToPrint, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpWhatToPrint.ResumeLayout(False)
            CType(Me.grdPrintLayouts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repChkToPrint, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repLayoutName, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.repPageCount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtdocumentsHeadline.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chlShowLongText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.txtPageCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkPrintAsDeliveryNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkPrintBusinesReportOneveryPage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnPrintPreview As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents chkPrintBusinesLayout As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents grpWhatToPrint As DevExpress.XtraEditors.GroupControl
        Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
        Friend WithEvents lblDocumentsHeadline As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtdocumentsHeadline As DevExpress.XtraEditors.TextEdit
        Friend WithEvents grdPrintLayouts As DevExpress.XtraGrid.GridControl
        Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents colToPrint As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents repChkToPrint As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Friend WithEvents colTemplateName As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents repLayoutName As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Friend WithEvents colPageCount As DevExpress.XtraGrid.Columns.GridColumn
        Friend WithEvents repPageCount As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Friend WithEvents chlShowLongText As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents lblPageCount As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtPageCount As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents chkPrintAsDeliveryNote As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents chkPrintBusinesReportOneveryPage As DevExpress.XtraEditors.CheckEdit
    End Class

End Namespace