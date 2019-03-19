<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmeditTask
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
        Me.lblTasksEndsAt = New DevExpress.XtraEditors.LabelControl()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtSubject = New DevExpress.XtraEditors.TextEdit()
        Me.txtMemo = New DevExpress.XtraEditors.MemoEdit()
        Me.chkTaskFinished = New DevExpress.XtraEditors.CheckEdit()
        Me.daeEndsAt = New DevExpress.XtraEditors.DateEdit()
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMemo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTaskFinished.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.daeEndsAt.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.daeEndsAt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSubject
        '
        Me.lblSubject.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubject.Appearance.Options.UseFont = True
        Me.lblSubject.Location = New System.Drawing.Point(14, 17)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(38, 15)
        Me.lblSubject.TabIndex = 0
        Me.lblSubject.Text = "Betreff:"
        '
        'lblTasksEndsAt
        '
        Me.lblTasksEndsAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTasksEndsAt.Appearance.Options.UseFont = True
        Me.lblTasksEndsAt.Location = New System.Drawing.Point(14, 47)
        Me.lblTasksEndsAt.Name = "lblTasksEndsAt"
        Me.lblTasksEndsAt.Size = New System.Drawing.Size(51, 15)
        Me.lblTasksEndsAt.TabIndex = 0
        Me.lblTasksEndsAt.Text = "Fällig am:"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.Location = New System.Drawing.Point(346, 255)
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
        Me.btnCancel.Location = New System.Drawing.Point(439, 255)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Abbrechen"
        '
        'txtSubject
        '
        Me.txtSubject.AllowDrop = True
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.Location = New System.Drawing.Point(118, 14)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.Properties.Appearance.Options.UseFont = True
        Me.txtSubject.Size = New System.Drawing.Size(406, 22)
        Me.txtSubject.TabIndex = 0
        '
        'txtMemo
        '
        Me.txtMemo.AllowDrop = True
        Me.txtMemo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMemo.Location = New System.Drawing.Point(14, 74)
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemo.Properties.Appearance.Options.UseFont = True
        Me.txtMemo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.txtMemo.Size = New System.Drawing.Size(510, 173)
        Me.txtMemo.TabIndex = 3
        '
        'chkTaskFinished
        '
        Me.chkTaskFinished.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTaskFinished.Location = New System.Drawing.Point(342, 45)
        Me.chkTaskFinished.Name = "chkTaskFinished"
        Me.chkTaskFinished.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTaskFinished.Properties.Appearance.Options.UseFont = True
        Me.chkTaskFinished.Properties.Caption = "Aufgabe ist erledigt"
        Me.chkTaskFinished.Size = New System.Drawing.Size(182, 20)
        Me.chkTaskFinished.TabIndex = 2
        '
        'daeEndsAt
        '
        Me.daeEndsAt.EditValue = Nothing
        Me.daeEndsAt.Location = New System.Drawing.Point(118, 44)
        Me.daeEndsAt.Name = "daeEndsAt"
        Me.daeEndsAt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.daeEndsAt.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.daeEndsAt.Properties.Appearance.Options.UseFont = True
        Me.daeEndsAt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.daeEndsAt.Properties.NullDate = New Date(CType(0, Long))
        Me.daeEndsAt.Properties.NullText = "Keine Fälligkeit"
        Me.daeEndsAt.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.daeEndsAt.Size = New System.Drawing.Size(128, 22)
        Me.daeEndsAt.TabIndex = 1
        '
        'frmeditTask
        '
        Me.AcceptButton = Me.btnOK
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(538, 294)
        Me.Controls.Add(Me.daeEndsAt)
        Me.Controls.Add(Me.chkTaskFinished)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblTasksEndsAt)
        Me.Controls.Add(Me.lblSubject)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(477, 293)
        Me.Name = "frmeditTask"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aufgabe bearbeiten"
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMemo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTaskFinished.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.daeEndsAt.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.daeEndsAt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSubject As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTasksEndsAt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtSubject As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMemo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents chkTaskFinished As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents daeEndsAt As DevExpress.XtraEditors.DateEdit
End Class
