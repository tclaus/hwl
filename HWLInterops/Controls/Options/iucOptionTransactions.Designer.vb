<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucOptionTransactions
    Inherits ClausSoftware.HWLInterops.BaseControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblReceiveablesOfTheLast = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.chksendNoticeUnpaidTransactions = New DevExpress.XtraEditors.CheckEdit()
        Me.speMonths = New DevExpress.XtraEditors.SpinEdit()
        Me.lblMonthNotice = New DevExpress.XtraEditors.LabelControl()
        CType(Me.chksendNoticeUnpaidTransactions.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.speMonths.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblReceiveablesOfTheLast
        '
        Me.lblReceiveablesOfTheLast.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiveablesOfTheLast.Appearance.Options.UseFont = True
        Me.lblReceiveablesOfTheLast.Location = New System.Drawing.Point(52, 96)
        Me.lblReceiveablesOfTheLast.Name = "lblReceiveablesOfTheLast"
        Me.lblReceiveablesOfTheLast.Size = New System.Drawing.Size(152, 15)
        Me.lblReceiveablesOfTheLast.TabIndex = 0
        Me.lblReceiveablesOfTheLast.Text = "Nur Forderungen der letzten "
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Location = New System.Drawing.Point(183, 208)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(87, 27)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "SimpleButton1"
        Me.SimpleButton1.Visible = False
        '
        'chksendNoticeUnpaidTransactions
        '
        Me.chksendNoticeUnpaidTransactions.Location = New System.Drawing.Point(23, 58)
        Me.chksendNoticeUnpaidTransactions.Name = "chksendNoticeUnpaidTransactions"
        Me.chksendNoticeUnpaidTransactions.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chksendNoticeUnpaidTransactions.Properties.Appearance.Options.UseFont = True
        Me.chksendNoticeUnpaidTransactions.Properties.AutoWidth = True
        Me.chksendNoticeUnpaidTransactions.Properties.Caption = "Beim Start offene Forderungen anzeigen"
        Me.chksendNoticeUnpaidTransactions.Size = New System.Drawing.Size(235, 20)
        Me.chksendNoticeUnpaidTransactions.TabIndex = 0
        '
        'speMonths
        '
        Me.speMonths.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.speMonths.Location = New System.Drawing.Point(52, 120)
        Me.speMonths.Name = "speMonths"
        Me.speMonths.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.speMonths.Properties.Appearance.Options.UseFont = True
        Me.speMonths.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.speMonths.Properties.MaxValue = New Decimal(New Integer() {24, 0, 0, 0})
        Me.speMonths.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.speMonths.Size = New System.Drawing.Size(45, 22)
        Me.speMonths.TabIndex = 1
        '
        'lblMonthNotice
        '
        Me.lblMonthNotice.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthNotice.Appearance.Options.UseFont = True
        Me.lblMonthNotice.Location = New System.Drawing.Point(115, 123)
        Me.lblMonthNotice.Name = "lblMonthNotice"
        Me.lblMonthNotice.Size = New System.Drawing.Size(133, 15)
        Me.lblMonthNotice.TabIndex = 0
        Me.lblMonthNotice.Text = "Monate benachrichtigen."
        '
        'iucOptionTransactions
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.speMonths)
        Me.Controls.Add(Me.chksendNoticeUnpaidTransactions)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.lblMonthNotice)
        Me.Controls.Add(Me.lblReceiveablesOfTheLast)
        Me.Name = "iucOptionTransactions"
        Me.Size = New System.Drawing.Size(332, 292)
        CType(Me.chksendNoticeUnpaidTransactions.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.speMonths.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblReceiveablesOfTheLast As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chksendNoticeUnpaidTransactions As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents speMonths As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblMonthNotice As DevExpress.XtraEditors.LabelControl

End Class
