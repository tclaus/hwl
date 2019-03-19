<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucHomeScreen
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
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.TodayBar1 = New ClausSoftware.HWLInterops.TodayBar()
        Me.lblMainScreenwelcomeText = New DevExpress.XtraEditors.LabelControl()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 59)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.PictureEdit1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.TodayBar1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(814, 571)
        Me.SplitContainerControl1.SplitterPosition = 150
        Me.SplitContainerControl1.TabIndex = 4
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.AllowFocused = False
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.ReadOnly = True
        Me.PictureEdit1.Properties.ShowMenu = False
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureEdit1.Size = New System.Drawing.Size(814, 415)
        Me.PictureEdit1.TabIndex = 0
        '
        'TodayBar1
        '
        Me.TodayBar1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.TodayBar1.Appearance.Options.UseBackColor = True
        Me.TodayBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TodayBar1.Location = New System.Drawing.Point(0, 0)
        Me.TodayBar1.MainUI = Nothing
        Me.TodayBar1.Margin = New System.Windows.Forms.Padding(0)
        Me.TodayBar1.Name = "TodayBar1"
        Me.TodayBar1.Size = New System.Drawing.Size(814, 150)
        Me.TodayBar1.TabIndex = 2
        '
        'lblMainScreenwelcomeText
        '
        Me.lblMainScreenwelcomeText.Appearance.Font = New System.Drawing.Font("Segoe UI", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainScreenwelcomeText.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.lblMainScreenwelcomeText.Appearance.Options.UseFont = True
        Me.lblMainScreenwelcomeText.Appearance.Options.UseForeColor = True
        Me.lblMainScreenwelcomeText.Location = New System.Drawing.Point(19, 3)
        Me.lblMainScreenwelcomeText.Name = "lblMainScreenwelcomeText"
        Me.lblMainScreenwelcomeText.Size = New System.Drawing.Size(176, 50)
        Me.lblMainScreenwelcomeText.TabIndex = 1
        Me.lblMainScreenwelcomeText.Tag = "DontTranslate"
        Me.lblMainScreenwelcomeText.Text = "{appname}"
        '
        'iucHomeScreen
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.lblMainScreenwelcomeText)
        Me.Name = "iucHomeScreen"
        Me.Size = New System.Drawing.Size(817, 633)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMainScreenwelcomeText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TodayBar1 As ClausSoftware.HWLInterops.TodayBar
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit

End Class
