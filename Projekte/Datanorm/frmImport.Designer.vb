<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatanormImport
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.btnAddFile = New DevExpress.XtraEditors.SimpleButton()
        Me.lblSelectDatasourceFile = New DevExpress.XtraEditors.LabelControl()
        Me.btnNextImportStep = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.prgCurrentLine = New DevExpress.XtraEditors.ProgressBarControl()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblImportProgress = New DevExpress.XtraEditors.LabelControl()
        Me.lblDatanormDescription = New DevExpress.XtraEditors.LabelControl()
        Me.lstFileList = New DevExpress.XtraEditors.ListBoxControl()
        Me.btnRemoveFile = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.prgCurrentLine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstFileList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddFile
        '
        Me.btnAddFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddFile.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddFile.Appearance.Options.UseFont = True
        Me.btnAddFile.Location = New System.Drawing.Point(290, 33)
        Me.btnAddFile.Name = "btnAddFile"
        Me.btnAddFile.Size = New System.Drawing.Size(115, 27)
        Me.btnAddFile.TabIndex = 8
        Me.btnAddFile.Text = "Datei hinzufügen..."
        '
        'lblSelectDatasourceFile
        '
        Me.lblSelectDatasourceFile.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatasourceFile.Appearance.Options.UseFont = True
        Me.lblSelectDatasourceFile.Location = New System.Drawing.Point(17, 12)
        Me.lblSelectDatasourceFile.Name = "lblSelectDatasourceFile"
        Me.lblSelectDatasourceFile.Size = New System.Drawing.Size(165, 15)
        Me.lblSelectDatasourceFile.TabIndex = 7
        Me.lblSelectDatasourceFile.Text = "Wählen Sie die Datanorm-Datei"
        '
        'btnNextImportStep
        '
        Me.btnNextImportStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextImportStep.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextImportStep.Appearance.Options.UseFont = True
        Me.btnNextImportStep.Enabled = False
        Me.btnNextImportStep.Location = New System.Drawing.Point(191, 230)
        Me.btnNextImportStep.Name = "btnNextImportStep"
        Me.btnNextImportStep.Size = New System.Drawing.Size(101, 31)
        Me.btnNextImportStep.TabIndex = 9
        Me.btnNextImportStep.Text = "Start"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.Location = New System.Drawing.Point(301, 230)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 31)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Schliessen"
        '
        'prgCurrentLine
        '
        Me.prgCurrentLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.prgCurrentLine.Location = New System.Drawing.Point(12, 219)
        Me.prgCurrentLine.Name = "prgCurrentLine"
        Me.prgCurrentLine.Size = New System.Drawing.Size(164, 21)
        Me.prgCurrentLine.TabIndex = 11
        Me.prgCurrentLine.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblImportProgress
        '
        Me.lblImportProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblImportProgress.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportProgress.Appearance.Options.UseFont = True
        Me.lblImportProgress.Location = New System.Drawing.Point(12, 246)
        Me.lblImportProgress.Name = "lblImportProgress"
        Me.lblImportProgress.Size = New System.Drawing.Size(17, 15)
        Me.lblImportProgress.TabIndex = 12
        Me.lblImportProgress.Text = "0/0"
        Me.lblImportProgress.Visible = False
        '
        'lblDatanormDescription
        '
        Me.lblDatanormDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDatanormDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatanormDescription.Appearance.Options.UseFont = True
        Me.lblDatanormDescription.Appearance.Options.UseTextOptions = True
        Me.lblDatanormDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lblDatanormDescription.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblDatanormDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDatanormDescription.Location = New System.Drawing.Point(17, 154)
        Me.lblDatanormDescription.Name = "lblDatanormDescription"
        Me.lblDatanormDescription.Size = New System.Drawing.Size(349, 47)
        Me.lblDatanormDescription.TabIndex = 13
        Me.lblDatanormDescription.Text = "-Datensatzbeschreibung-"
        '
        'lstFileList
        '
        Me.lstFileList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFileList.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFileList.Appearance.Options.UseFont = True
        Me.lstFileList.Location = New System.Drawing.Point(17, 33)
        Me.lstFileList.Name = "lstFileList"
        Me.lstFileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFileList.Size = New System.Drawing.Size(267, 104)
        Me.lstFileList.TabIndex = 14
        '
        'btnRemoveFile
        '
        Me.btnRemoveFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveFile.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveFile.Appearance.Options.UseFont = True
        Me.btnRemoveFile.Location = New System.Drawing.Point(290, 75)
        Me.btnRemoveFile.Name = "btnRemoveFile"
        Me.btnRemoveFile.Size = New System.Drawing.Size(115, 27)
        Me.btnRemoveFile.TabIndex = 15
        Me.btnRemoveFile.Text = "Entfernen"
        '
        'frmDatanormImport
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 273)
        Me.Controls.Add(Me.btnRemoveFile)
        Me.Controls.Add(Me.lstFileList)
        Me.Controls.Add(Me.lblDatanormDescription)
        Me.Controls.Add(Me.lblImportProgress)
        Me.Controls.Add(Me.prgCurrentLine)
        Me.Controls.Add(Me.btnAddFile)
        Me.Controls.Add(Me.lblSelectDatasourceFile)
        Me.Controls.Add(Me.btnNextImportStep)
        Me.Controls.Add(Me.btnClose)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(395, 285)
        Me.Name = "frmDatanormImport"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Datanorm-Import"
        CType(Me.prgCurrentLine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstFileList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddFile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblSelectDatasourceFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnNextImportStep As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents prgCurrentLine As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblImportProgress As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDatanormDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lstFileList As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents btnRemoveFile As DevExpress.XtraEditors.SimpleButton
End Class
