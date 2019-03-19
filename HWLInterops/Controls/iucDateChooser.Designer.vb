Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucDateChooser
    Inherits ClausSoftware.HWLInterops.BaseControl

    'iucDateChooser overrides dispose to clean up the component list.
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
        Me.radAug = New System.Windows.Forms.RadioButton
        Me.radSep = New System.Windows.Forms.RadioButton
        Me.radOkt = New System.Windows.Forms.RadioButton
        Me.radNov = New System.Windows.Forms.RadioButton
        Me.radDez = New System.Windows.Forms.RadioButton
        Me.radJul = New System.Windows.Forms.RadioButton
        Me.radJun = New System.Windows.Forms.RadioButton
        Me.radMai = New System.Windows.Forms.RadioButton
        Me.radApril = New System.Windows.Forms.RadioButton
        Me.RadMärz = New System.Windows.Forms.RadioButton
        Me.radFeburar = New System.Windows.Forms.RadioButton
        Me.radJan = New System.Windows.Forms.RadioButton
        Me.radQ1 = New System.Windows.Forms.RadioButton
        Me.radQ2 = New System.Windows.Forms.RadioButton
        Me.radQ3 = New System.Windows.Forms.RadioButton
        Me.radQ4 = New System.Windows.Forms.RadioButton
        Me.radFullyear = New System.Windows.Forms.RadioButton
        Me.radAllDates = New System.Windows.Forms.RadioButton
        Me.cboYears = New DevExpress.XtraEditors.ComboBoxEdit
        CType(Me.cboYears.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'radAug
        '
        Me.radAug.AutoSize = True
        Me.radAug.Location = New System.Drawing.Point(310, 84)
        Me.radAug.Name = "radAug"
        Me.radAug.Size = New System.Drawing.Size(59, 17)
        Me.radAug.TabIndex = 0
        Me.radAug.Tag = "8"
        Me.radAug.Text = "August"
        Me.radAug.UseVisualStyleBackColor = True
        '
        'radSep
        '
        Me.radSep.AutoSize = True
        Me.radSep.Location = New System.Drawing.Point(374, 15)
        Me.radSep.Name = "radSep"
        Me.radSep.Size = New System.Drawing.Size(77, 17)
        Me.radSep.TabIndex = 0
        Me.radSep.Tag = "9"
        Me.radSep.Text = "September"
        Me.radSep.UseVisualStyleBackColor = True
        '
        'radOkt
        '
        Me.radOkt.AutoSize = True
        Me.radOkt.Location = New System.Drawing.Point(374, 38)
        Me.radOkt.Name = "radOkt"
        Me.radOkt.Size = New System.Drawing.Size(64, 17)
        Me.radOkt.TabIndex = 0
        Me.radOkt.Tag = "10"
        Me.radOkt.Text = "Oktober"
        Me.radOkt.UseVisualStyleBackColor = True
        '
        'radNov
        '
        Me.radNov.AutoSize = True
        Me.radNov.Location = New System.Drawing.Point(374, 61)
        Me.radNov.Name = "radNov"
        Me.radNov.Size = New System.Drawing.Size(74, 17)
        Me.radNov.TabIndex = 0
        Me.radNov.Tag = "11"
        Me.radNov.Text = "November"
        Me.radNov.UseVisualStyleBackColor = True
        '
        'radDez
        '
        Me.radDez.AutoSize = True
        Me.radDez.Location = New System.Drawing.Point(375, 84)
        Me.radDez.Name = "radDez"
        Me.radDez.Size = New System.Drawing.Size(73, 17)
        Me.radDez.TabIndex = 0
        Me.radDez.Tag = "12"
        Me.radDez.Text = "Dezember"
        Me.radDez.UseVisualStyleBackColor = True
        '
        'radJul
        '
        Me.radJul.AutoSize = True
        Me.radJul.Location = New System.Drawing.Point(310, 61)
        Me.radJul.Name = "radJul"
        Me.radJul.Size = New System.Drawing.Size(40, 17)
        Me.radJul.TabIndex = 0
        Me.radJul.Tag = "7"
        Me.radJul.Text = "Juli"
        Me.radJul.UseVisualStyleBackColor = True
        '
        'radJun
        '
        Me.radJun.AutoSize = True
        Me.radJun.Location = New System.Drawing.Point(310, 38)
        Me.radJun.Name = "radJun"
        Me.radJun.Size = New System.Drawing.Size(44, 17)
        Me.radJun.TabIndex = 0
        Me.radJun.Tag = "6"
        Me.radJun.Text = "Juni"
        Me.radJun.UseVisualStyleBackColor = True
        '
        'radMai
        '
        Me.radMai.AutoSize = True
        Me.radMai.Location = New System.Drawing.Point(310, 15)
        Me.radMai.Name = "radMai"
        Me.radMai.Size = New System.Drawing.Size(41, 17)
        Me.radMai.TabIndex = 0
        Me.radMai.Tag = "5"
        Me.radMai.Text = "Mai"
        Me.radMai.UseVisualStyleBackColor = True
        '
        'radApril
        '
        Me.radApril.AutoSize = True
        Me.radApril.Location = New System.Drawing.Point(235, 84)
        Me.radApril.Name = "radApril"
        Me.radApril.Size = New System.Drawing.Size(46, 17)
        Me.radApril.TabIndex = 0
        Me.radApril.Tag = "4"
        Me.radApril.Text = "April"
        Me.radApril.UseVisualStyleBackColor = True
        '
        'RadMärz
        '
        Me.RadMärz.AutoSize = True
        Me.RadMärz.Location = New System.Drawing.Point(235, 61)
        Me.RadMärz.Name = "RadMärz"
        Me.RadMärz.Size = New System.Drawing.Size(48, 17)
        Me.RadMärz.TabIndex = 0
        Me.RadMärz.Tag = "3"
        Me.RadMärz.Text = "März"
        Me.RadMärz.UseVisualStyleBackColor = True
        '
        'radFeburar
        '
        Me.radFeburar.AutoSize = True
        Me.radFeburar.Location = New System.Drawing.Point(235, 38)
        Me.radFeburar.Name = "radFeburar"
        Me.radFeburar.Size = New System.Drawing.Size(63, 17)
        Me.radFeburar.TabIndex = 0
        Me.radFeburar.Tag = "2"
        Me.radFeburar.Text = "Februar"
        Me.radFeburar.UseVisualStyleBackColor = True
        '
        'radJan
        '
        Me.radJan.AutoSize = True
        Me.radJan.Location = New System.Drawing.Point(235, 15)
        Me.radJan.Name = "radJan"
        Me.radJan.Size = New System.Drawing.Size(58, 17)
        Me.radJan.TabIndex = 0
        Me.radJan.Tag = "1"
        Me.radJan.Text = "Januar"
        Me.radJan.UseVisualStyleBackColor = True
        '
        'radQ1
        '
        Me.radQ1.AutoSize = True
        Me.radQ1.Location = New System.Drawing.Point(142, 15)
        Me.radQ1.Name = "radQ1"
        Me.radQ1.Size = New System.Drawing.Size(74, 17)
        Me.radQ1.TabIndex = 2
        Me.radQ1.Tag = "1"
        Me.radQ1.Text = "1. Quartal"
        Me.radQ1.UseVisualStyleBackColor = True
        '
        'radQ2
        '
        Me.radQ2.AutoSize = True
        Me.radQ2.Location = New System.Drawing.Point(142, 38)
        Me.radQ2.Name = "radQ2"
        Me.radQ2.Size = New System.Drawing.Size(74, 17)
        Me.radQ2.TabIndex = 2
        Me.radQ2.Tag = "2"
        Me.radQ2.Text = "2. Quartal"
        Me.radQ2.UseVisualStyleBackColor = True
        '
        'radQ3
        '
        Me.radQ3.AutoSize = True
        Me.radQ3.Location = New System.Drawing.Point(142, 61)
        Me.radQ3.Name = "radQ3"
        Me.radQ3.Size = New System.Drawing.Size(74, 17)
        Me.radQ3.TabIndex = 2
        Me.radQ3.Tag = "3"
        Me.radQ3.Text = "3. Quartal"
        Me.radQ3.UseVisualStyleBackColor = True
        '
        'radQ4
        '
        Me.radQ4.AutoSize = True
        Me.radQ4.Location = New System.Drawing.Point(142, 84)
        Me.radQ4.Name = "radQ4"
        Me.radQ4.Size = New System.Drawing.Size(77, 17)
        Me.radQ4.TabIndex = 2
        Me.radQ4.Tag = "4"
        Me.radQ4.Text = "4.  Quartal"
        Me.radQ4.UseVisualStyleBackColor = True
        '
        'radFullyear
        '
        Me.radFullyear.AutoSize = True
        Me.radFullyear.Location = New System.Drawing.Point(19, 38)
        Me.radFullyear.Name = "radFullyear"
        Me.radFullyear.Size = New System.Drawing.Size(83, 17)
        Me.radFullyear.TabIndex = 4
        Me.radFullyear.Tag = "0"
        Me.radFullyear.Text = "ganzes Jahr"
        Me.radFullyear.UseVisualStyleBackColor = True
        '
        'radAllDates
        '
        Me.radAllDates.AutoSize = True
        Me.radAllDates.Checked = True
        Me.radAllDates.Location = New System.Drawing.Point(19, 61)
        Me.radAllDates.Name = "radAllDates"
        Me.radAllDates.Size = New System.Drawing.Size(47, 17)
        Me.radAllDates.TabIndex = 4
        Me.radAllDates.TabStop = True
        Me.radAllDates.Tag = "-1"
        Me.radAllDates.Text = "Alles"
        Me.radAllDates.UseVisualStyleBackColor = True
        '
        'cboYears
        '
        Me.cboYears.Location = New System.Drawing.Point(19, 12)
        Me.cboYears.Name = "cboYears"
        Me.cboYears.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboYears.Properties.PopupSizeable = True
        Me.cboYears.Properties.Sorted = True
        Me.cboYears.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboYears.Size = New System.Drawing.Size(117, 20)
        Me.cboYears.TabIndex = 5
        '
        'iucDateChooser
        '
        Me.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboYears)
        Me.Controls.Add(Me.radAllDates)
        Me.Controls.Add(Me.radFullyear)
        Me.Controls.Add(Me.radQ4)
        Me.Controls.Add(Me.radQ3)
        Me.Controls.Add(Me.radQ2)
        Me.Controls.Add(Me.radQ1)
        Me.Controls.Add(Me.radJan)
        Me.Controls.Add(Me.radFeburar)
        Me.Controls.Add(Me.RadMärz)
        Me.Controls.Add(Me.radApril)
        Me.Controls.Add(Me.radMai)
        Me.Controls.Add(Me.radJun)
        Me.Controls.Add(Me.radJul)
        Me.Controls.Add(Me.radDez)
        Me.Controls.Add(Me.radNov)
        Me.Controls.Add(Me.radOkt)
        Me.Controls.Add(Me.radSep)
        Me.Controls.Add(Me.radAug)
        Me.Name = "iucDateChooser"
        Me.Size = New System.Drawing.Size(465, 119)
        CType(Me.cboYears.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents radAug As System.Windows.Forms.RadioButton
    Friend WithEvents radSep As System.Windows.Forms.RadioButton
    Friend WithEvents radOkt As System.Windows.Forms.RadioButton
    Friend WithEvents radNov As System.Windows.Forms.RadioButton
    Friend WithEvents radDez As System.Windows.Forms.RadioButton
    Friend WithEvents radJul As System.Windows.Forms.RadioButton
    Friend WithEvents radJun As System.Windows.Forms.RadioButton
    Friend WithEvents radMai As System.Windows.Forms.RadioButton
    Friend WithEvents radApril As System.Windows.Forms.RadioButton
    Friend WithEvents RadMärz As System.Windows.Forms.RadioButton
    Friend WithEvents radFeburar As System.Windows.Forms.RadioButton
    Friend WithEvents radJan As System.Windows.Forms.RadioButton
    Friend WithEvents radQ1 As System.Windows.Forms.RadioButton
    Friend WithEvents radQ2 As System.Windows.Forms.RadioButton
    Friend WithEvents radQ3 As System.Windows.Forms.RadioButton
    Friend WithEvents radQ4 As System.Windows.Forms.RadioButton
    Friend WithEvents radFullyear As System.Windows.Forms.RadioButton
    Friend WithEvents radAllDates As System.Windows.Forms.RadioButton
    Friend WithEvents cboYears As DevExpress.XtraEditors.ComboBoxEdit

End Class
