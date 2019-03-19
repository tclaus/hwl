<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttributesMultiSelecteditor
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
        Me.lblSelectorName = New DevExpress.XtraEditors.LabelControl()
        Me.lblValues = New DevExpress.XtraEditors.LabelControl()
        Me.grdSelector = New DevExpress.XtraGrid.GridControl()
        Me.grvSelector = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdValues = New DevExpress.XtraGrid.GridControl()
        Me.grvValues = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.lblMultiselectorDescription = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.grdSelector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvSelector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdValues, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvValues, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSelectorName
        '
        Me.lblSelectorName.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectorName.Appearance.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblSelectorName.Appearance.Options.UseFont = True
        Me.lblSelectorName.Appearance.Options.UseForeColor = True
        Me.lblSelectorName.Location = New System.Drawing.Point(5, 3)
        Me.lblSelectorName.Name = "lblSelectorName"
        Me.lblSelectorName.Size = New System.Drawing.Size(101, 20)
        Me.lblSelectorName.TabIndex = 1
        Me.lblSelectorName.Text = "Auswahl-Name"
        '
        'lblValues
        '
        Me.lblValues.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValues.Appearance.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblValues.Appearance.Options.UseFont = True
        Me.lblValues.Appearance.Options.UseForeColor = True
        Me.lblValues.Location = New System.Drawing.Point(3, 3)
        Me.lblValues.Name = "lblValues"
        Me.lblValues.Size = New System.Drawing.Size(40, 20)
        Me.lblValues.TabIndex = 1
        Me.lblValues.Text = "Werte"
        '
        'grdSelector
        '
        Me.grdSelector.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdSelector.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdSelector.Location = New System.Drawing.Point(5, 29)
        Me.grdSelector.MainView = Me.grvSelector
        Me.grdSelector.Name = "grdSelector"
        Me.grdSelector.Size = New System.Drawing.Size(182, 177)
        Me.grdSelector.TabIndex = 2
        Me.grdSelector.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvSelector})
        '
        'grvSelector
        '
        Me.grvSelector.GridControl = Me.grdSelector
        Me.grvSelector.Name = "grvSelector"
        Me.grvSelector.NewItemRowText = "<Hier klicken für neues Profil>"
        Me.grvSelector.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused
        Me.grvSelector.OptionsCustomization.AllowGroup = False
        Me.grvSelector.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvSelector.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.grvSelector.OptionsView.ShowGroupPanel = False
        Me.grvSelector.OptionsView.ShowIndicator = False
        '
        'grdValues
        '
        Me.grdValues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdValues.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdValues.Location = New System.Drawing.Point(3, 29)
        Me.grdValues.MainView = Me.grvValues
        Me.grdValues.Name = "grdValues"
        Me.grdValues.Size = New System.Drawing.Size(178, 177)
        Me.grdValues.TabIndex = 2
        Me.grdValues.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvValues})
        '
        'grvValues
        '
        Me.grvValues.GridControl = Me.grdValues
        Me.grvValues.Name = "grvValues"
        Me.grvValues.NewItemRowText = "<Neuer Wert>"
        Me.grvValues.OptionsCustomization.AllowGroup = False
        Me.grvValues.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvValues.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.grvValues.OptionsView.ShowGroupPanel = False
        Me.grvValues.OptionsView.ShowIndicator = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.Location = New System.Drawing.Point(230, 307)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 27)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Speichern"
        Me.btnSave.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.Location = New System.Drawing.Point(324, 307)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Schliessen"
        '
        'lblMultiselectorDescription
        '
        Me.lblMultiselectorDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMultiselectorDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMultiselectorDescription.Appearance.Options.UseFont = True
        Me.lblMultiselectorDescription.Appearance.Options.UseTextOptions = True
        Me.lblMultiselectorDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblMultiselectorDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblMultiselectorDescription.Location = New System.Drawing.Point(14, 2)
        Me.lblMultiselectorDescription.Name = "lblMultiselectorDescription"
        Me.lblMultiselectorDescription.Size = New System.Drawing.Size(390, 62)
        Me.lblMultiselectorDescription.TabIndex = 1
        Me.lblMultiselectorDescription.Text = "Weist einem Profil mehrere Einstellungsmöglichkeiten zu. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bei der Zuordnung zu e" & _
            "iner Klassifikationseigenschaft kann gewählt werden, ob genau ein Wert gewählt w" & _
            "erden kann oder mehrere." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(14, 72)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(390, 216)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdSelector)
        Me.Panel1.Controls.Add(Me.lblSelectorName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(189, 210)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdValues)
        Me.Panel2.Controls.Add(Me.lblValues)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(198, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(189, 210)
        Me.Panel2.TabIndex = 1
        '
        'frmAttributesMultiSelecteditor
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 347)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblMultiselectorDescription)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(442, 385)
        Me.Name = "frmAttributesMultiSelecteditor"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Profile /Werte"
        CType(Me.grdSelector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvSelector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdValues, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvValues, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblSelectorName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblValues As DevExpress.XtraEditors.LabelControl
    Friend WithEvents grdSelector As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvSelector As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdValues As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvValues As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblMultiselectorDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
