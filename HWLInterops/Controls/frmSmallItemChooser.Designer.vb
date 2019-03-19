<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmallItemChooser
    Inherits ClausSoftware.HWLInterops.BaseForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.grdArticles = New DevExpress.XtraGrid.GridControl()
        Me.grvArticles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LoadingCircle1 = New ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle()
        Me.IucSearchPanel1 = New ClausSoftware.HWLInterops.iucSearchPanel()
        CType(Me.grdArticles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvArticles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdArticles
        '
        Me.grdArticles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdArticles.Location = New System.Drawing.Point(14, 57)
        Me.grdArticles.MainView = Me.grvArticles
        Me.grdArticles.Name = "grdArticles"
        Me.grdArticles.Size = New System.Drawing.Size(399, 302)
        Me.grdArticles.TabIndex = 1
        Me.grdArticles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvArticles})
        '
        'grvArticles
        '
        Me.grvArticles.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grvArticles.Appearance.EvenRow.Options.UseBackColor = True
        Me.grvArticles.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grvArticles.GridControl = Me.grdArticles
        Me.grvArticles.Name = "grvArticles"
        Me.grvArticles.OptionsBehavior.Editable = False
        Me.grvArticles.OptionsCustomization.AllowColumnMoving = False
        Me.grvArticles.OptionsCustomization.AllowFilter = False
        Me.grvArticles.OptionsMenu.EnableColumnMenu = False
        Me.grvArticles.OptionsNavigation.UseTabKey = False
        Me.grvArticles.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvArticles.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.grvArticles.OptionsSelection.UseIndicatorForSelection = False
        Me.grvArticles.OptionsView.EnableAppearanceEvenRow = True
        Me.grvArticles.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.grvArticles.OptionsView.ShowGroupPanel = False
        Me.grvArticles.OptionsView.ShowHorzLines = False
        Me.grvArticles.OptionsView.ShowIndicator = False
        Me.grvArticles.OptionsView.ShowVertLines = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(220, 369)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 27)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(325, 369)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Abbrechen"
        '
        'LoadingCircle1
        '
        Me.LoadingCircle1.Active = False
        Me.LoadingCircle1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LoadingCircle1.Color = System.Drawing.Color.DarkGray
        Me.LoadingCircle1.InnerCircleRadius = 8
        Me.LoadingCircle1.Location = New System.Drawing.Point(14, 366)
        Me.LoadingCircle1.Name = "LoadingCircle1"
        Me.LoadingCircle1.NumberSpoke = 10
        Me.LoadingCircle1.OuterCircleRadius = 10
        Me.LoadingCircle1.RotationSpeed = 100
        Me.LoadingCircle1.Size = New System.Drawing.Size(41, 38)
        Me.LoadingCircle1.SpokeThickness = 4
        Me.LoadingCircle1.StylePreset = ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX
        Me.LoadingCircle1.TabIndex = 6
        Me.LoadingCircle1.TabStop = False
        '
        'IucSearchPanel1
        '
        Me.IucSearchPanel1.AllowTextFieldTabStop = True
        Me.IucSearchPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IucSearchPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.IucSearchPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IucSearchPanel1.Location = New System.Drawing.Point(15, 27)
        Me.IucSearchPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.IucSearchPanel1.Name = "IucSearchPanel1"
        Me.IucSearchPanel1.NullValuePrompt = "Suche...    F3"
        Me.IucSearchPanel1.SelectedMenueItem = -1
        Me.IucSearchPanel1.Size = New System.Drawing.Size(397, 27)
        Me.IucSearchPanel1.Status = ClausSoftware.HWLInterops.iucSearchPanel.enumState.empty
        Me.IucSearchPanel1.TabIndex = 7
        '
        'frmSmallItemChooser
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(427, 410)
        Me.Controls.Add(Me.IucSearchPanel1)
        Me.Controls.Add(Me.LoadingCircle1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grdArticles)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSmallItemChooser"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Artkel wählen"
        CType(Me.grdArticles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvArticles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdArticles As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvArticles As DevExpress.XtraGrid.Views.Grid.GridView


    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LoadingCircle1 As ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle
    Friend WithEvents IucSearchPanel1 As ClausSoftware.HWLInterops.iucSearchPanel
End Class
