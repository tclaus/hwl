<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArticleAttributes
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.grdValueDefinition = New DevExpress.XtraGrid.GridControl()
        Me.grvValueDefinition = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colAttributeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAttributeType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.repCboItemType = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colMultiselectProfile = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lblAttributeDefinitionHeadline = New DevExpress.XtraEditors.LabelControl()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.grdValueDefinition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvValueDefinition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.repCboItemType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdValueDefinition
        '
        Me.grdValueDefinition.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdValueDefinition.Location = New System.Drawing.Point(1, 58)
        Me.grdValueDefinition.MainView = Me.grvValueDefinition
        Me.grdValueDefinition.Name = "grdValueDefinition"
        Me.grdValueDefinition.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.repCboItemType})
        Me.grdValueDefinition.ShowOnlyPredefinedDetails = True
        Me.grdValueDefinition.Size = New System.Drawing.Size(391, 127)
        Me.grdValueDefinition.TabIndex = 0
        Me.grdValueDefinition.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvValueDefinition})
        '
        'grvValueDefinition
        '
        Me.grvValueDefinition.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAttributeName, Me.colAttributeType, Me.colMultiselectProfile})
        Me.grvValueDefinition.GridControl = Me.grdValueDefinition
        Me.grvValueDefinition.Name = "grvValueDefinition"
        Me.grvValueDefinition.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
        Me.grvValueDefinition.OptionsCustomization.AllowGroup = False
        Me.grvValueDefinition.OptionsSelection.MultiSelect = True
        Me.grvValueDefinition.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.grvValueDefinition.OptionsView.ShowGroupPanel = False
        Me.grvValueDefinition.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        '
        'colAttributeName
        '
        Me.colAttributeName.Caption = "Name"
        Me.colAttributeName.FieldName = "AttributeName"
        Me.colAttributeName.Name = "colAttributeName"
        Me.colAttributeName.Visible = True
        Me.colAttributeName.VisibleIndex = 0
        '
        'colAttributeType
        '
        Me.colAttributeType.Caption = "Type"
        Me.colAttributeType.ColumnEdit = Me.repCboItemType
        Me.colAttributeType.FieldName = "AttributeType"
        Me.colAttributeType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.colAttributeType.Name = "colAttributeType"
        Me.colAttributeType.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText
        Me.colAttributeType.Visible = True
        Me.colAttributeType.VisibleIndex = 1
        '
        'repCboItemType
        '
        Me.repCboItemType.AutoHeight = False
        Me.repCboItemType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, False)})
        Me.repCboItemType.Name = "repCboItemType"
        Me.repCboItemType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'colMultiselectProfile
        '
        Me.colMultiselectProfile.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colMultiselectProfile.AppearanceCell.Options.UseBackColor = True
        Me.colMultiselectProfile.Caption = "Auswahl-Profil"
        Me.colMultiselectProfile.FieldName = "MultiselectProfile.DisplayName"
        Me.colMultiselectProfile.Name = "colMultiselectProfile"
        Me.colMultiselectProfile.OptionsColumn.AllowEdit = False
        Me.colMultiselectProfile.OptionsColumn.AllowFocus = False
        Me.colMultiselectProfile.Visible = True
        Me.colMultiselectProfile.VisibleIndex = 2
        '
        'lblAttributeDefinitionHeadline
        '
        Me.lblAttributeDefinitionHeadline.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAttributeDefinitionHeadline.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblAttributeDefinitionHeadline.Appearance.Options.UseFont = True
        Me.lblAttributeDefinitionHeadline.Appearance.Options.UseForeColor = True
        Me.lblAttributeDefinitionHeadline.Location = New System.Drawing.Point(14, 12)
        Me.lblAttributeDefinitionHeadline.Name = "lblAttributeDefinitionHeadline"
        Me.lblAttributeDefinitionHeadline.Size = New System.Drawing.Size(240, 34)
        Me.lblAttributeDefinitionHeadline.TabIndex = 2
        Me.lblAttributeDefinitionHeadline.Tag = "DontTranslate"
        Me.lblAttributeDefinitionHeadline.Text = "Definitionen der Attribute für die Gruppe:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{0}"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(295, 193)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 27)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.Location = New System.Drawing.Point(202, 193)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(109, 193)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 27)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Löschen"
        '
        'frmArticleAttributes
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(394, 232)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblAttributeDefinitionHeadline)
        Me.Controls.Add(Me.grdValueDefinition)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(347, 200)
        Me.Name = "frmArticleAttributes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Klassifizierungen definieren"
        CType(Me.grdValueDefinition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvValueDefinition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.repCboItemType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdValueDefinition As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvValueDefinition As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblAttributeDefinitionHeadline As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colAttributeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAttributeType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents repCboItemType As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents colMultiselectProfile As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
End Class
