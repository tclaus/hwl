<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFixedCostDetail
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
        Me.lblSubject = New DevExpress.XtraEditors.LabelControl()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSubject = New DevExpress.XtraEditors.TextEdit()
        Me.lblAmmount = New DevExpress.XtraEditors.LabelControl()
        Me.lblCategory = New DevExpress.XtraEditors.LabelControl()
        Me.txtPeriodicalAmmount = New DevExpress.XtraEditors.TextEdit()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cboCategory = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.MonthlyRecurrenceControl1 = New DevExpress.XtraScheduler.UI.MonthlyRecurrenceControl()
        Me.WeeklyRecurrenceControl1 = New DevExpress.XtraScheduler.UI.WeeklyRecurrenceControl()
        Me.YearlyRecurrenceControl1 = New DevExpress.XtraScheduler.UI.YearlyRecurrenceControl()
        Me.DailyRecurrenceControl1 = New DevExpress.XtraScheduler.UI.DailyRecurrenceControl()
        Me.radRecurrenceChoose = New DevExpress.XtraEditors.RadioGroup()
        Me.btneditGroup = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodicalAmmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radRecurrenceChoose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSubject
        '
        Me.lblSubject.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubject.Appearance.Options.UseFont = True
        Me.lblSubject.Location = New System.Drawing.Point(14, 21)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(38, 15)
        Me.lblSubject.TabIndex = 0
        Me.lblSubject.Text = "Betreff:"
        '
        'btnOK
        '
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.Location = New System.Drawing.Point(475, 14)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 27)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'txtSubject
        '
        Me.txtSubject.AllowDrop = True
        Me.txtSubject.Location = New System.Drawing.Point(117, 17)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.Properties.Appearance.Options.UseFont = True
        Me.txtSubject.Properties.MaxLength = 250
        Me.txtSubject.Size = New System.Drawing.Size(300, 22)
        Me.txtSubject.TabIndex = 0
        '
        'lblAmmount
        '
        Me.lblAmmount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmmount.Appearance.Options.UseFont = True
        Me.lblAmmount.Location = New System.Drawing.Point(14, 51)
        Me.lblAmmount.Name = "lblAmmount"
        Me.lblAmmount.Size = New System.Drawing.Size(37, 15)
        Me.lblAmmount.TabIndex = 0
        Me.lblAmmount.Text = "Betrag:"
        '
        'lblCategory
        '
        Me.lblCategory.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Appearance.Options.UseFont = True
        Me.lblCategory.Location = New System.Drawing.Point(14, 81)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(53, 15)
        Me.lblCategory.TabIndex = 0
        Me.lblCategory.Text = "Kategorie:"
        '
        'txtPeriodicalAmmount
        '
        Me.txtPeriodicalAmmount.AllowDrop = True
        Me.txtPeriodicalAmmount.Location = New System.Drawing.Point(117, 47)
        Me.txtPeriodicalAmmount.Name = "txtPeriodicalAmmount"
        Me.txtPeriodicalAmmount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodicalAmmount.Properties.Appearance.Options.UseFont = True
        Me.txtPeriodicalAmmount.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPeriodicalAmmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtPeriodicalAmmount.Properties.DisplayFormat.FormatString = "c"
        Me.txtPeriodicalAmmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPeriodicalAmmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPeriodicalAmmount.Properties.Mask.EditMask = "c"
        Me.txtPeriodicalAmmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPeriodicalAmmount.Size = New System.Drawing.Size(161, 22)
        Me.txtPeriodicalAmmount.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(475, 47)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Abbrechen"
        '
        'cboCategory
        '
        Me.cboCategory.Location = New System.Drawing.Point(117, 77)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategory.Properties.Appearance.Options.UseFont = True
        Me.cboCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboCategory.Properties.MaxLength = 50
        Me.cboCategory.Size = New System.Drawing.Size(161, 22)
        Me.cboCategory.TabIndex = 2
        '
        'MonthlyRecurrenceControl1
        '
        Me.MonthlyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.MonthlyRecurrenceControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthlyRecurrenceControl1.Appearance.Options.UseBackColor = True
        Me.MonthlyRecurrenceControl1.Appearance.Options.UseFont = True
        Me.MonthlyRecurrenceControl1.Location = New System.Drawing.Point(138, 107)
        Me.MonthlyRecurrenceControl1.Name = "MonthlyRecurrenceControl1"
        Me.MonthlyRecurrenceControl1.Size = New System.Drawing.Size(440, 129)
        Me.MonthlyRecurrenceControl1.TabIndex = 5
        '
        'WeeklyRecurrenceControl1
        '
        Me.WeeklyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.WeeklyRecurrenceControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WeeklyRecurrenceControl1.Appearance.Options.UseBackColor = True
        Me.WeeklyRecurrenceControl1.Appearance.Options.UseFont = True
        Me.WeeklyRecurrenceControl1.Location = New System.Drawing.Point(138, 107)
        Me.WeeklyRecurrenceControl1.Name = "WeeklyRecurrenceControl1"
        Me.WeeklyRecurrenceControl1.Size = New System.Drawing.Size(429, 129)
        Me.WeeklyRecurrenceControl1.TabIndex = 5
        '
        'YearlyRecurrenceControl1
        '
        Me.YearlyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.YearlyRecurrenceControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YearlyRecurrenceControl1.Appearance.Options.UseBackColor = True
        Me.YearlyRecurrenceControl1.Appearance.Options.UseFont = True
        Me.YearlyRecurrenceControl1.Location = New System.Drawing.Point(138, 107)
        Me.YearlyRecurrenceControl1.Name = "YearlyRecurrenceControl1"
        Me.YearlyRecurrenceControl1.Size = New System.Drawing.Size(429, 129)
        Me.YearlyRecurrenceControl1.TabIndex = 6
        '
        'DailyRecurrenceControl1
        '
        Me.DailyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.DailyRecurrenceControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DailyRecurrenceControl1.Appearance.Options.UseBackColor = True
        Me.DailyRecurrenceControl1.Appearance.Options.UseFont = True
        Me.DailyRecurrenceControl1.Location = New System.Drawing.Point(138, 107)
        Me.DailyRecurrenceControl1.Name = "DailyRecurrenceControl1"
        Me.DailyRecurrenceControl1.Size = New System.Drawing.Size(429, 129)
        Me.DailyRecurrenceControl1.TabIndex = 7
        '
        'radRecurrenceChoose
        '
        Me.radRecurrenceChoose.Location = New System.Drawing.Point(14, 107)
        Me.radRecurrenceChoose.Name = "radRecurrenceChoose"
        Me.radRecurrenceChoose.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.radRecurrenceChoose.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radRecurrenceChoose.Properties.Appearance.Options.UseBackColor = True
        Me.radRecurrenceChoose.Properties.Appearance.Options.UseFont = True
        Me.radRecurrenceChoose.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Täglich"), New DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Wöchentlich"), New DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Monatlich"), New DevExpress.XtraEditors.Controls.RadioGroupItem(5, "Jährlich")})
        Me.radRecurrenceChoose.Size = New System.Drawing.Size(117, 111)
        Me.radRecurrenceChoose.TabIndex = 4
        '
        'btneditGroup
        '
        Me.btneditGroup.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btneditGroup.Appearance.Options.UseFont = True
        Me.btneditGroup.Location = New System.Drawing.Point(285, 80)
        Me.btneditGroup.Name = "btneditGroup"
        Me.btneditGroup.Size = New System.Drawing.Size(25, 19)
        Me.btneditGroup.TabIndex = 3
        Me.btneditGroup.Text = "..."
        '
        'frmFixedCostDetail
        '
        Me.AcceptButton = Me.btnOK
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 237)
        Me.Controls.Add(Me.btneditGroup)
        Me.Controls.Add(Me.radRecurrenceChoose)
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.txtPeriodicalAmmount)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblAmmount)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.MonthlyRecurrenceControl1)
        Me.Controls.Add(Me.DailyRecurrenceControl1)
        Me.Controls.Add(Me.YearlyRecurrenceControl1)
        Me.Controls.Add(Me.WeeklyRecurrenceControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFixedCostDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Kostenbetrag"
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodicalAmmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radRecurrenceChoose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubject As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtSubject As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblAmmount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCategory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPeriodicalAmmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboCategory As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents MonthlyRecurrenceControl1 As DevExpress.XtraScheduler.UI.MonthlyRecurrenceControl
    Friend WithEvents WeeklyRecurrenceControl1 As DevExpress.XtraScheduler.UI.WeeklyRecurrenceControl
    Friend WithEvents YearlyRecurrenceControl1 As DevExpress.XtraScheduler.UI.YearlyRecurrenceControl
    Friend WithEvents DailyRecurrenceControl1 As DevExpress.XtraScheduler.UI.DailyRecurrenceControl
    Friend WithEvents radRecurrenceChoose As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents btneditGroup As DevExpress.XtraEditors.SimpleButton
End Class
