Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucOptionTaxes
    Inherits ClausSoftware.HWLInterops.BaseControl

    'iucTaxes overrides dispose to clean up the component list.
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
        Me.grdTaxes = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVATRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repVATEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colTaxstatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboTaxstatus = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
        Me.chkShowItemsWithTaxInDocument = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowWithoutTax = New DevExpress.XtraEditors.CheckEdit()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btneditCashAccounts = New DevExpress.XtraEditors.SimpleButton()
        Me.chkUseRoundedTaxValues = New DevExpress.XtraEditors.CheckEdit()
        Me.btnDocuments = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.grdTaxes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repVATEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTaxstatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowItemsWithTaxInDocument.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowWithoutTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkUseRoundedTaxValues.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdTaxes
        '
        Me.grdTaxes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdTaxes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTaxes.Location = New System.Drawing.Point(3, 0)
        Me.grdTaxes.MainView = Me.GridView1
        Me.grdTaxes.Name = "grdTaxes"
        Me.grdTaxes.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cboTaxstatus, Me.repVATEdit})
        Me.grdTaxes.Size = New System.Drawing.Size(327, 137)
        Me.grdTaxes.TabIndex = 0
        Me.grdTaxes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colName, Me.colVATRate, Me.colTaxstatus})
        Me.GridView1.GridControl = Me.grdTaxes
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowSort = False
        Me.GridView1.OptionsMenu.EnableColumnMenu = False
        Me.GridView1.OptionsMenu.EnableFooterMenu = False
        Me.GridView1.OptionsMenu.EnableGroupPanelMenu = False
        Me.GridView1.OptionsView.ShowColumnHeaders = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        '
        'colName
        '
        Me.colName.Caption = "Name"
        Me.colName.FieldName = "Name"
        Me.colName.Name = "colName"
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 0
        '
        'colVATRate
        '
        Me.colVATRate.Caption = "Steuersatz"
        Me.colVATRate.ColumnEdit = Me.repVATEdit
        Me.colVATRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colVATRate.FieldName = "TaxValue"
        Me.colVATRate.Name = "colVATRate"
        Me.colVATRate.Visible = True
        Me.colVATRate.VisibleIndex = 1
        '
        'repVATEdit
        '
        Me.repVATEdit.AutoHeight = False
        Me.repVATEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.repVATEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.repVATEdit.Mask.EditMask = "n1"
        Me.repVATEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.repVATEdit.Name = "repVATEdit"
        '
        'colTaxstatus
        '
        Me.colTaxstatus.Caption = "GridColumn1"
        Me.colTaxstatus.ColumnEdit = Me.cboTaxstatus
        Me.colTaxstatus.FieldName = "TaxStatus"
        Me.colTaxstatus.Name = "colTaxstatus"
        Me.colTaxstatus.Visible = True
        Me.colTaxstatus.VisibleIndex = 2
        '
        'cboTaxstatus
        '
        Me.cboTaxstatus.AutoHeight = False
        Me.cboTaxstatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTaxstatus.Name = "cboTaxstatus"
        '
        'chkShowItemsWithTaxInDocument
        '
        Me.chkShowItemsWithTaxInDocument.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkShowItemsWithTaxInDocument.Location = New System.Drawing.Point(3, 176)
        Me.chkShowItemsWithTaxInDocument.Name = "chkShowItemsWithTaxInDocument"
        Me.chkShowItemsWithTaxInDocument.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowItemsWithTaxInDocument.Properties.Appearance.Options.UseFont = True
        Me.chkShowItemsWithTaxInDocument.Properties.Caption = "In Rechnungen Steuer ausweisen"
        Me.chkShowItemsWithTaxInDocument.Size = New System.Drawing.Size(247, 20)
        Me.chkShowItemsWithTaxInDocument.TabIndex = 1
        Me.chkShowItemsWithTaxInDocument.ToolTip = "Zeigtt in Rechnungen einen Steuersatz an. "
        '
        'chkShowWithoutTax
        '
        Me.chkShowWithoutTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkShowWithoutTax.Location = New System.Drawing.Point(3, 202)
        Me.chkShowWithoutTax.Name = "chkShowWithoutTax"
        Me.chkShowWithoutTax.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowWithoutTax.Properties.Appearance.Options.UseFont = True
        Me.chkShowWithoutTax.Properties.Caption = "Einzelartikel als Nettopreis ausweisen"
        Me.chkShowWithoutTax.Size = New System.Drawing.Size(247, 20)
        Me.chkShowWithoutTax.TabIndex = 2
        Me.chkShowWithoutTax.ToolTip = "wenn gewähltm wird ein Artikel mit dem Nettopreis ausgewiesen. (Für Verkauf an Hä" & _
    "ndler)"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Location = New System.Drawing.Point(150, 143)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 27)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Löschen"
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Appearance.Options.UseFont = True
        Me.btnNew.Location = New System.Drawing.Point(244, 143)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(87, 27)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "Neu"
        '
        'btneditCashAccounts
        '
        Me.btneditCashAccounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btneditCashAccounts.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneditCashAccounts.Appearance.Options.UseFont = True
        Me.btneditCashAccounts.Location = New System.Drawing.Point(243, 241)
        Me.btneditCashAccounts.Name = "btneditCashAccounts"
        Me.btneditCashAccounts.Size = New System.Drawing.Size(87, 27)
        Me.btneditCashAccounts.TabIndex = 4
        Me.btneditCashAccounts.Text = "Konten..."
        '
        'chkUseRoundedTaxValues
        '
        Me.chkUseRoundedTaxValues.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkUseRoundedTaxValues.Location = New System.Drawing.Point(3, 228)
        Me.chkUseRoundedTaxValues.Name = "chkUseRoundedTaxValues"
        Me.chkUseRoundedTaxValues.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUseRoundedTaxValues.Properties.Appearance.Options.UseFont = True
        Me.chkUseRoundedTaxValues.Properties.Caption = "Steuern Runden"
        Me.chkUseRoundedTaxValues.Size = New System.Drawing.Size(218, 20)
        Me.chkUseRoundedTaxValues.TabIndex = 6
        '
        'btnDocuments
        '
        Me.btnDocuments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDocuments.Location = New System.Drawing.Point(244, 212)
        Me.btnDocuments.Name = "btnDocuments"
        Me.btnDocuments.Size = New System.Drawing.Size(86, 23)
        Me.btnDocuments.TabIndex = 7
        Me.btnDocuments.Text = "Dokumente..."
        '
        'iucOptionTaxes
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnDocuments)
        Me.Controls.Add(Me.chkUseRoundedTaxValues)
        Me.Controls.Add(Me.btneditCashAccounts)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.chkShowWithoutTax)
        Me.Controls.Add(Me.chkShowItemsWithTaxInDocument)
        Me.Controls.Add(Me.grdTaxes)
        Me.Name = "iucOptionTaxes"
        Me.Size = New System.Drawing.Size(334, 274)
        CType(Me.grdTaxes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repVATEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTaxstatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowItemsWithTaxInDocument.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowWithoutTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkUseRoundedTaxValues.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdTaxes As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVATRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkShowItemsWithTaxInDocument As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShowWithoutTax As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboTaxstatus As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
    Friend WithEvents colTaxstatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btneditCashAccounts As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents repVATEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents chkUseRoundedTaxValues As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnDocuments As DevExpress.XtraEditors.SimpleButton

End Class
