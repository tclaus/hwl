<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucGlobalSearch
    Inherits mainControlContainer


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
        Me.grdsearchItems = New DevExpress.XtraGrid.GridControl()
        Me.grvSearchItems = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSpacing = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIcon = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPictureEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.colType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemKey = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.RepositoryItemRichTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit()
        Me.layView = New DevExpress.XtraGrid.Views.Layout.LayoutView()
        Me.LayoutViewCard1 = New DevExpress.XtraGrid.Views.Layout.LayoutViewCard()
        Me.lblSearchHeadline = New DevExpress.XtraEditors.LabelControl()
        CType(Me.grdsearchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvSearchItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemRichTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdsearchItems
        '
        Me.grdsearchItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdsearchItems.Location = New System.Drawing.Point(0, 35)
        Me.grdsearchItems.LookAndFeel.SkinName = "Lilian"
        Me.grdsearchItems.LookAndFeel.UseDefaultLookAndFeel = False
        Me.grdsearchItems.MainView = Me.grvSearchItems
        Me.grdsearchItems.Name = "grdsearchItems"
        Me.grdsearchItems.Padding = New System.Windows.Forms.Padding(23, 0, 23, 0)
        Me.grdsearchItems.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1, Me.RepositoryItemPictureEdit1, Me.RepositoryItemRichTextEdit1})
        Me.grdsearchItems.Size = New System.Drawing.Size(892, 490)
        Me.grdsearchItems.TabIndex = 0
        Me.grdsearchItems.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvSearchItems, Me.layView})
        '
        'grvSearchItems
        '
        Me.grvSearchItems.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.grvSearchItems.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.grvSearchItems.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.grvSearchItems.Appearance.FocusedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.grvSearchItems.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grvSearchItems.Appearance.FocusedRow.Options.UseForeColor = True
        Me.grvSearchItems.Appearance.Preview.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grvSearchItems.Appearance.Preview.Options.UseFont = True
        Me.grvSearchItems.Appearance.SelectedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.grvSearchItems.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.grvSearchItems.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSpacing, Me.colIcon, Me.colType, Me.colID, Me.colItemKey})
        Me.grvSearchItems.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None
        Me.grvSearchItems.GridControl = Me.grdsearchItems
        Me.grvSearchItems.Name = "grvSearchItems"
        Me.grvSearchItems.OptionsBehavior.Editable = False
        Me.grvSearchItems.OptionsMenu.EnableColumnMenu = False
        Me.grvSearchItems.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvSearchItems.OptionsView.RowAutoHeight = True
        Me.grvSearchItems.OptionsView.ShowColumnHeaders = False
        Me.grvSearchItems.OptionsView.ShowGroupPanel = False
        Me.grvSearchItems.OptionsView.ShowHorzLines = False
        Me.grvSearchItems.OptionsView.ShowIndicator = False
        Me.grvSearchItems.OptionsView.ShowPreview = True
        Me.grvSearchItems.OptionsView.ShowVertLines = False
        Me.grvSearchItems.PreviewFieldName = "Description"
        '
        'colSpacing
        '
        Me.colSpacing.Caption = "- -"
        Me.colSpacing.Name = "colSpacing"
        Me.colSpacing.Visible = True
        Me.colSpacing.VisibleIndex = 0
        Me.colSpacing.Width = 20
        '
        'colIcon
        '
        Me.colIcon.Caption = "Icon"
        Me.colIcon.ColumnEdit = Me.RepositoryItemPictureEdit1
        Me.colIcon.FieldName = "Icon"
        Me.colIcon.Name = "colIcon"
        Me.colIcon.Visible = True
        Me.colIcon.VisibleIndex = 1
        Me.colIcon.Width = 40
        '
        'RepositoryItemPictureEdit1
        '
        Me.RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        Me.RepositoryItemPictureEdit1.PictureAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.RepositoryItemPictureEdit1.ReadOnly = True
        Me.RepositoryItemPictureEdit1.ShowMenu = False
        Me.RepositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'colType
        '
        Me.colType.AppearanceCell.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.colType.AppearanceCell.Options.UseFont = True
        Me.colType.Caption = "Typ"
        Me.colType.FieldName = "ItemTyp"
        Me.colType.Name = "colType"
        Me.colType.Visible = True
        Me.colType.VisibleIndex = 2
        Me.colType.Width = 352
        '
        'colID
        '
        Me.colID.Caption = "IDNumber"
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 3
        Me.colID.Width = 359
        '
        'colItemKey
        '
        Me.colItemKey.Caption = "Key"
        Me.colItemKey.FieldName = "Key"
        Me.colItemKey.Name = "colItemKey"
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'RepositoryItemRichTextEdit1
        '
        Me.RepositoryItemRichTextEdit1.Name = "RepositoryItemRichTextEdit1"
        Me.RepositoryItemRichTextEdit1.ReadOnly = True
        '
        'layView
        '
        Me.layView.Appearance.Card.BorderColor = System.Drawing.Color.White
        Me.layView.Appearance.Card.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.layView.Appearance.Card.Options.UseBorderColor = True
        Me.layView.Appearance.FieldCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.layView.Appearance.FieldCaption.Options.UseForeColor = True
        Me.layView.Appearance.SelectedCardCaption.BorderColor = System.Drawing.Color.Blue
        Me.layView.Appearance.SelectedCardCaption.Options.UseBorderColor = True
        Me.layView.Appearance.SeparatorLine.BackColor = System.Drawing.Color.Gainsboro
        Me.layView.Appearance.SeparatorLine.BorderColor = System.Drawing.Color.Gray
        Me.layView.Appearance.SeparatorLine.Options.UseBackColor = True
        Me.layView.Appearance.SeparatorLine.Options.UseBorderColor = True
        Me.layView.CardMinSize = New System.Drawing.Size(496, 55)
        Me.layView.CardVertInterval = 0
        Me.layView.GridControl = Me.grdsearchItems
        Me.layView.Name = "layView"
        Me.layView.OptionsBehavior.AutoFocusCardOnScrolling = True
        Me.layView.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.[Auto]
        Me.layView.OptionsCustomization.AllowFilter = False
        Me.layView.OptionsCustomization.AllowSort = False
        Me.layView.OptionsFilter.AllowColumnMRUFilterList = False
        Me.layView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.layView.OptionsFilter.UseNewCustomFilterDialog = True
        Me.layView.OptionsItemText.TextToControlDistance = 2
        Me.layView.OptionsMultiRecordMode.StretchCardToViewWidth = True
        Me.layView.OptionsView.AllowHotTrackFields = False
        Me.layView.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards
        Me.layView.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Near
        Me.layView.OptionsView.PartialCardWrapThreshold = 2
        Me.layView.OptionsView.ShowCardCaption = False
        Me.layView.OptionsView.ShowCardExpandButton = False
        Me.layView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.layView.OptionsView.ShowHeaderPanel = False
        Me.layView.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Column
        Me.layView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.layView.TemplateCard = Me.LayoutViewCard1
        '
        'LayoutViewCard1
        '
        Me.LayoutViewCard1.CustomizationFormText = "TemplateCard"
        Me.LayoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutViewCard1.GroupBordersVisible = False
        Me.LayoutViewCard1.Name = "LayoutViewCard1"
        Me.LayoutViewCard1.OptionsItemText.TextToControlDistance = 2
        Me.LayoutViewCard1.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutViewCard1.Text = "TemplateCard"
        '
        'lblSearchHeadline
        '
        Me.lblSearchHeadline.Appearance.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchHeadline.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchHeadline.Appearance.Options.UseFont = True
        Me.lblSearchHeadline.Appearance.Options.UseForeColor = True
        Me.lblSearchHeadline.Appearance.Options.UseTextOptions = True
        Me.lblSearchHeadline.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblSearchHeadline.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lblSearchHeadline.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblSearchHeadline.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSearchHeadline.Location = New System.Drawing.Point(0, 0)
        Me.lblSearchHeadline.Name = "lblSearchHeadline"
        Me.lblSearchHeadline.Size = New System.Drawing.Size(892, 35)
        Me.lblSearchHeadline.TabIndex = 1
        Me.lblSearchHeadline.Text = "Suche...."
        '
        'iucGlobalSearch
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grdsearchItems)
        Me.Controls.Add(Me.lblSearchHeadline)
        Me.Name = "iucGlobalSearch"
        Me.Size = New System.Drawing.Size(892, 525)
        CType(Me.grdsearchItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvSearchItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPictureEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemRichTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutViewCard1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdsearchItems As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvSearchItems As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents layView As DevExpress.XtraGrid.Views.Layout.LayoutView
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RepositoryItemPictureEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents LayoutViewCard1 As DevExpress.XtraGrid.Views.Layout.LayoutViewCard
    Friend WithEvents colType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemKey As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIcon As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSpacing As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblSearchHeadline As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RepositoryItemRichTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit

End Class
