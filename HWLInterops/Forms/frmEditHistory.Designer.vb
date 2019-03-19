<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditHistory
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.chkSystemCreated = New DevExpress.XtraEditors.CheckEdit()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCreatedBy = New DevExpress.XtraEditors.LabelControl()
        Me.lblCreatedByText = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCreatedAt = New DevExpress.XtraEditors.LabelControl()
        Me.lblCreatedAtText = New DevExpress.XtraEditors.LabelControl()
        Me.txtComment = New DevExpress.XtraEditors.MemoEdit()
        Me.lblHistoryCategory = New DevExpress.XtraEditors.LabelControl()
        Me.lblComment = New DevExpress.XtraEditors.LabelControl()
        Me.cobCategory = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.chkSystemCreated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.txtComment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(332, 188)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Abbrechen"
        '
        'chkSystemCreated
        '
        Me.chkSystemCreated.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSystemCreated.Enabled = False
        Me.chkSystemCreated.Location = New System.Drawing.Point(17, 195)
        Me.chkSystemCreated.Name = "chkSystemCreated"
        Me.chkSystemCreated.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSystemCreated.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSystemCreated.Properties.Appearance.Options.UseFont = True
        Me.chkSystemCreated.Properties.Appearance.Options.UseForeColor = True
        Me.chkSystemCreated.Properties.Caption = "Automatisch angelegt"
        Me.chkSystemCreated.Size = New System.Drawing.Size(196, 20)
        Me.chkSystemCreated.TabIndex = 5
        Me.chkSystemCreated.ToolTip = "Kennzeichnet automatisch angelegte einträge, diese können nicht verändert werden." & _
    ""
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.75824!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.24176!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblCreatedBy, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCreatedByText, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(211, 14)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(212, 22)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedBy.Appearance.Options.UseFont = True
        Me.lblCreatedBy.Location = New System.Drawing.Point(3, 3)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(61, 15)
        Me.lblCreatedBy.TabIndex = 2
        Me.lblCreatedBy.Text = "Erstellt von:"
        '
        'lblCreatedByText
        '
        Me.lblCreatedByText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedByText.Appearance.Options.UseFont = True
        Me.lblCreatedByText.Location = New System.Drawing.Point(91, 3)
        Me.lblCreatedByText.Name = "lblCreatedByText"
        Me.lblCreatedByText.Size = New System.Drawing.Size(41, 15)
        Me.lblCreatedByText.TabIndex = 2
        Me.lblCreatedByText.Tag = "DontTranslate"
        Me.lblCreatedByText.Text = "Ersteller"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.15068!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.84932!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblCreatedAt, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCreatedAtText, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(16, 14)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 22)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'lblCreatedAt
        '
        Me.lblCreatedAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAt.Appearance.Options.UseFont = True
        Me.lblCreatedAt.Location = New System.Drawing.Point(3, 3)
        Me.lblCreatedAt.Name = "lblCreatedAt"
        Me.lblCreatedAt.Size = New System.Drawing.Size(39, 15)
        Me.lblCreatedAt.TabIndex = 2
        Me.lblCreatedAt.Text = "Datum:"
        '
        'lblCreatedAtText
        '
        Me.lblCreatedAtText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAtText.Appearance.Options.UseFont = True
        Me.lblCreatedAtText.Location = New System.Drawing.Point(76, 3)
        Me.lblCreatedAtText.Name = "lblCreatedAtText"
        Me.lblCreatedAtText.Size = New System.Drawing.Size(24, 15)
        Me.lblCreatedAtText.TabIndex = 2
        Me.lblCreatedAtText.Tag = "DontTranslate"
        Me.lblCreatedAtText.Text = "Date"
        '
        'txtComment
        '
        Me.txtComment.AllowDrop = True
        Me.txtComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(112, 85)
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComment.Properties.Appearance.Options.UseFont = True
        Me.txtComment.Size = New System.Drawing.Size(311, 92)
        Me.txtComment.TabIndex = 1
        '
        'lblHistoryCategory
        '
        Me.lblHistoryCategory.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistoryCategory.Appearance.Options.UseFont = True
        Me.lblHistoryCategory.Location = New System.Drawing.Point(16, 59)
        Me.lblHistoryCategory.Name = "lblHistoryCategory"
        Me.lblHistoryCategory.Size = New System.Drawing.Size(41, 15)
        Me.lblHistoryCategory.TabIndex = 2
        Me.lblHistoryCategory.Text = "Ereignis"
        '
        'lblComment
        '
        Me.lblComment.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComment.Appearance.Options.UseFont = True
        Me.lblComment.Location = New System.Drawing.Point(16, 88)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(63, 15)
        Me.lblComment.TabIndex = 2
        Me.lblComment.Text = "Kommentar"
        '
        'cobCategory
        '
        Me.cobCategory.Location = New System.Drawing.Point(112, 55)
        Me.cobCategory.Name = "cobCategory"
        Me.cobCategory.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobCategory.Properties.Appearance.Options.UseFont = True
        ToolTipTitleItem1.Text = "Kategorien bearbeiten"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Ermöglicht es, Kategorien für den Verlauf zu bearbeiten oder neue anzulegen"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.cobCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "edit", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", "edit", SuperToolTip1, False)})
        Me.cobCategory.Properties.PopupSizeable = True
        Me.cobCategory.Properties.Sorted = True
        Me.cobCategory.Size = New System.Drawing.Size(191, 22)
        Me.cobCategory.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.Location = New System.Drawing.Point(238, 188)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 27)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'frmEditHistory
        '
        Me.AcceptButton = Me.btnOK
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(434, 228)
        Me.Controls.Add(Me.chkSystemCreated)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.lblHistoryCategory)
        Me.Controls.Add(Me.lblComment)
        Me.Controls.Add(Me.cobCategory)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(388, 233)
        Me.Name = "frmEditHistory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Verlauf (Adresse)"
        CType(Me.chkSystemCreated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.txtComment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cobCategory As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblComment As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblHistoryCategory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtComment As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblCreatedAt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCreatedAtText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCreatedBy As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCreatedByText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkSystemCreated As DevExpress.XtraEditors.CheckEdit
End Class
