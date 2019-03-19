<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportExportManager
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
        Me.grpConnectors = New DevExpress.XtraEditors.GroupControl()
        Me.lstAddIns = New DevExpress.XtraEditors.ListBoxControl()
        Me.lblAddInLongDescription = New DevExpress.XtraEditors.LabelControl()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnStartConnector = New DevExpress.XtraEditors.SimpleButton()
        Me.lblGoToAddInDownloadSite = New DevExpress.XtraEditors.LabelControl()
        CType(Me.grpConnectors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpConnectors.SuspendLayout()
        CType(Me.lstAddIns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpConnectors
        '
        Me.grpConnectors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpConnectors.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpConnectors.Appearance.Options.UseFont = True
        Me.grpConnectors.Controls.Add(Me.lstAddIns)
        Me.grpConnectors.Location = New System.Drawing.Point(12, 30)
        Me.grpConnectors.Name = "grpConnectors"
        Me.grpConnectors.Size = New System.Drawing.Size(247, 170)
        Me.grpConnectors.TabIndex = 0
        Me.grpConnectors.Text = "Zusatzmodule"
        '
        'lstAddIns
        '
        Me.lstAddIns.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAddIns.Appearance.Options.UseFont = True
        Me.lstAddIns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstAddIns.Location = New System.Drawing.Point(2, 22)
        Me.lstAddIns.Name = "lstAddIns"
        Me.lstAddIns.Size = New System.Drawing.Size(243, 146)
        Me.lstAddIns.TabIndex = 0
        '
        'lblAddInLongDescription
        '
        Me.lblAddInLongDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAddInLongDescription.Appearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblAddInLongDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddInLongDescription.Appearance.Options.UseBorderColor = True
        Me.lblAddInLongDescription.Appearance.Options.UseFont = True
        Me.lblAddInLongDescription.Appearance.Options.UseTextOptions = True
        Me.lblAddInLongDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lblAddInLongDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblAddInLongDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblAddInLongDescription.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.lblAddInLongDescription.Location = New System.Drawing.Point(14, 206)
        Me.lblAddInLongDescription.Name = "lblAddInLongDescription"
        Me.lblAddInLongDescription.Padding = New System.Windows.Forms.Padding(5)
        Me.lblAddInLongDescription.Size = New System.Drawing.Size(331, 83)
        Me.lblAddInLongDescription.TabIndex = 1
        Me.lblAddInLongDescription.Text = "Beschreibungstext"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(270, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Schliessen"
        '
        'btnStartConnector
        '
        Me.btnStartConnector.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartConnector.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartConnector.Appearance.Options.UseFont = True
        Me.btnStartConnector.Location = New System.Drawing.Point(270, 41)
        Me.btnStartConnector.Name = "btnStartConnector"
        Me.btnStartConnector.Size = New System.Drawing.Size(75, 23)
        Me.btnStartConnector.TabIndex = 2
        Me.btnStartConnector.Text = "Starten"
        '
        'lblGoToAddInDownloadSite
        '
        Me.lblGoToAddInDownloadSite.AllowHtmlString = True
        Me.lblGoToAddInDownloadSite.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGoToAddInDownloadSite.Appearance.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblGoToAddInDownloadSite.Appearance.Options.UseFont = True
        Me.lblGoToAddInDownloadSite.Appearance.Options.UseForeColor = True
        Me.lblGoToAddInDownloadSite.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGoToAddInDownloadSite.Location = New System.Drawing.Point(13, 10)
        Me.lblGoToAddInDownloadSite.Name = "lblGoToAddInDownloadSite"
        Me.lblGoToAddInDownloadSite.Size = New System.Drawing.Size(146, 14)
        Me.lblGoToAddInDownloadSite.TabIndex = 3
        Me.lblGoToAddInDownloadSite.Text = "Weitere AddIns herunterladen"
        '
        'frmImportExportManager
        '
        Me.AcceptButton = Me.btnStartConnector
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(357, 301)
        Me.Controls.Add(Me.lblGoToAddInDownloadSite)
        Me.Controls.Add(Me.btnStartConnector)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblAddInLongDescription)
        Me.Controls.Add(Me.grpConnectors)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(373, 277)
        Me.Name = "frmImportExportManager"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import/Export Manager"
        CType(Me.grpConnectors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpConnectors.ResumeLayout(False)
        CType(Me.lstAddIns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpConnectors As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lstAddIns As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lblAddInLongDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnStartConnector As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblGoToAddInDownloadSite As DevExpress.XtraEditors.LabelControl
End Class
