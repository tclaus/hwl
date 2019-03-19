Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucOptionsTextTemplateEdit
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
        Me.grdTextTemplates = New DevExpress.XtraGrid.GridControl()
        Me.grvTextTemplates = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.coltext = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.txtedit = New DevExpress.XtraEditors.MemoEdit()
        Me.btnshowTextfieldPlaceholders = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.grdTextTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvTextTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtedit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdTextTemplates
        '
        Me.grdTextTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdTextTemplates.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTextTemplates.Location = New System.Drawing.Point(3, 0)
        Me.grdTextTemplates.MainView = Me.grvTextTemplates
        Me.grdTextTemplates.Name = "grdTextTemplates"
        Me.grdTextTemplates.Size = New System.Drawing.Size(327, 164)
        Me.grdTextTemplates.TabIndex = 0
        Me.grdTextTemplates.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvTextTemplates})
        '
        'grvTextTemplates
        '
        Me.grvTextTemplates.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.coltext})
        Me.grvTextTemplates.GridControl = Me.grdTextTemplates
        Me.grvTextTemplates.Name = "grvTextTemplates"
        Me.grvTextTemplates.OptionsCustomization.AllowSort = False
        Me.grvTextTemplates.OptionsMenu.EnableColumnMenu = False
        Me.grvTextTemplates.OptionsMenu.EnableFooterMenu = False
        Me.grvTextTemplates.OptionsMenu.EnableGroupPanelMenu = False
        Me.grvTextTemplates.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvTextTemplates.OptionsView.ShowColumnHeaders = False
        Me.grvTextTemplates.OptionsView.ShowGroupPanel = False
        Me.grvTextTemplates.OptionsView.ShowIndicator = False
        '
        'coltext
        '
        Me.coltext.Caption = "Text"
        Me.coltext.FieldName = "Text"
        Me.coltext.Name = "coltext"
        Me.coltext.OptionsColumn.AllowEdit = False
        Me.coltext.Visible = True
        Me.coltext.VisibleIndex = 0
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Location = New System.Drawing.Point(149, 256)
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
        Me.btnNew.Location = New System.Drawing.Point(243, 256)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(87, 27)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "Neu"
        '
        'txtedit
        '
        Me.txtedit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtedit.Location = New System.Drawing.Point(3, 186)
        Me.txtedit.Name = "txtedit"
        Me.txtedit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txtedit.Properties.NullText = "<Geben Sie hier einen Text ein>"
        Me.txtedit.Size = New System.Drawing.Size(327, 64)
        Me.txtedit.TabIndex = 4
        '
        'btnshowTextfieldPlaceholders
        '
        Me.btnshowTextfieldPlaceholders.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnshowTextfieldPlaceholders.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Symbol_Help16x16
        Me.btnshowTextfieldPlaceholders.Location = New System.Drawing.Point(3, 256)
        Me.btnshowTextfieldPlaceholders.Name = "btnshowTextfieldPlaceholders"
        Me.btnshowTextfieldPlaceholders.Size = New System.Drawing.Size(108, 30)
        Me.btnshowTextfieldPlaceholders.TabIndex = 5
        Me.btnshowTextfieldPlaceholders.Text = "Platzhalter..."
        '
        'iucOptionsTextTemplateEdit
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnshowTextfieldPlaceholders)
        Me.Controls.Add(Me.txtedit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.grdTextTemplates)
        Me.Name = "iucOptionsTextTemplateEdit"
        Me.Size = New System.Drawing.Size(334, 286)
        CType(Me.grdTextTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvTextTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtedit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdTextTemplates As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvTextTemplates As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents coltext As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtedit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents btnshowTextfieldPlaceholders As DevExpress.XtraEditors.SimpleButton

End Class
