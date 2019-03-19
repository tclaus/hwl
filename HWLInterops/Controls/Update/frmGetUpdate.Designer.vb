Namespace Update

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmGetUpdate
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
            Me.txtChangelog = New DevExpress.XtraEditors.MemoEdit()
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            Me.btnInstall = New DevExpress.XtraEditors.SimpleButton()
            Me.chkAutoCheckForUpdates = New DevExpress.XtraEditors.CheckEdit()
            CType(Me.txtChangelog.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkAutoCheckForUpdates.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtChangelog
            '
            Me.txtChangelog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtChangelog.Location = New System.Drawing.Point(0, 0)
            Me.txtChangelog.Name = "txtChangelog"
            Me.txtChangelog.Properties.ReadOnly = True
            Me.txtChangelog.Size = New System.Drawing.Size(479, 134)
            Me.txtChangelog.TabIndex = 0
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.Location = New System.Drawing.Point(391, 140)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(75, 23)
            Me.btnClose.TabIndex = 1
            Me.btnClose.Text = "Schliessen"
            '
            'btnInstall
            '
            Me.btnInstall.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnInstall.Enabled = False
            Me.btnInstall.Location = New System.Drawing.Point(310, 140)
            Me.btnInstall.Name = "btnInstall"
            Me.btnInstall.Size = New System.Drawing.Size(75, 23)
            Me.btnInstall.TabIndex = 2
            Me.btnInstall.Text = "Installieren"
            '
            'chkAutoCheckForUpdates
            '
            Me.chkAutoCheckForUpdates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.chkAutoCheckForUpdates.Location = New System.Drawing.Point(12, 144)
            Me.chkAutoCheckForUpdates.Name = "chkAutoCheckForUpdates"
            Me.chkAutoCheckForUpdates.Properties.AutoWidth = True
            Me.chkAutoCheckForUpdates.Properties.Caption = "Automatisch nach Aktualisierungen suchen"
            Me.chkAutoCheckForUpdates.Size = New System.Drawing.Size(227, 19)
            Me.chkAutoCheckForUpdates.TabIndex = 3
            '
            'frmGetUpdate
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(478, 175)
            Me.Controls.Add(Me.chkAutoCheckForUpdates)
            Me.Controls.Add(Me.btnInstall)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.txtChangelog)
            Me.DoubleBuffered = True
            Me.MinimumSize = New System.Drawing.Size(494, 213)
            Me.Name = "frmGetUpdate"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Aktualisierungen"
            CType(Me.txtChangelog.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkAutoCheckForUpdates.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents txtChangelog As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnInstall As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents chkAutoCheckForUpdates As DevExpress.XtraEditors.CheckEdit
    End Class


End Namespace