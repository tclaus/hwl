<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainImport
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
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNextImportStep = New DevExpress.XtraEditors.SimpleButton()
        Me.lblImportStepOne = New DevExpress.XtraEditors.LabelControl()
        Me.lblSelectDatasourceFile = New DevExpress.XtraEditors.LabelControl()
        Me.lstDatasource = New DevExpress.XtraEditors.ListBoxControl()
        Me.txtFilePath = New DevExpress.XtraEditors.TextEdit()
        Me.btnBrowseFiles = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.lstDatasource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilePath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.Location = New System.Drawing.Point(303, 192)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Schliessen"
        '
        'btnNextImportStep
        '
        Me.btnNextImportStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextImportStep.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextImportStep.Appearance.Options.UseFont = True
        Me.btnNextImportStep.Enabled = False
        Me.btnNextImportStep.Location = New System.Drawing.Point(209, 192)
        Me.btnNextImportStep.Name = "btnNextImportStep"
        Me.btnNextImportStep.Size = New System.Drawing.Size(87, 27)
        Me.btnNextImportStep.TabIndex = 4
        Me.btnNextImportStep.Text = "Weiter"
        '
        'lblImportStepOne
        '
        Me.lblImportStepOne.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportStepOne.Appearance.Options.UseFont = True
        Me.lblImportStepOne.Location = New System.Drawing.Point(35, 35)
        Me.lblImportStepOne.Name = "lblImportStepOne"
        Me.lblImportStepOne.Size = New System.Drawing.Size(173, 15)
        Me.lblImportStepOne.TabIndex = 1
        Me.lblImportStepOne.Text = "1. Was möchten Sie importieren?"
        '
        'lblSelectDatasourceFile
        '
        Me.lblSelectDatasourceFile.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatasourceFile.Appearance.Options.UseFont = True
        Me.lblSelectDatasourceFile.Location = New System.Drawing.Point(35, 134)
        Me.lblSelectDatasourceFile.Name = "lblSelectDatasourceFile"
        Me.lblSelectDatasourceFile.Size = New System.Drawing.Size(161, 15)
        Me.lblSelectDatasourceFile.TabIndex = 1
        Me.lblSelectDatasourceFile.Text = "2. Wählen Sie eine Datenquelle"
        '
        'lstDatasource
        '
        Me.lstDatasource.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDatasource.Appearance.Options.UseFont = True
        Me.lstDatasource.Location = New System.Drawing.Point(52, 59)
        Me.lstDatasource.Name = "lstDatasource"
        Me.lstDatasource.Size = New System.Drawing.Size(301, 57)
        Me.lstDatasource.TabIndex = 0
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(52, 155)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(242, 20)
        Me.txtFilePath.TabIndex = 1
        '
        'btnBrowseFiles
        '
        Me.btnBrowseFiles.Location = New System.Drawing.Point(302, 152)
        Me.btnBrowseFiles.Name = "btnBrowseFiles"
        Me.btnBrowseFiles.Size = New System.Drawing.Size(87, 23)
        Me.btnBrowseFiles.TabIndex = 2
        Me.btnBrowseFiles.Text = "Durchsuchen..."
        '
        'frmMainImport
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 232)
        Me.Controls.Add(Me.btnBrowseFiles)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.lstDatasource)
        Me.Controls.Add(Me.lblSelectDatasourceFile)
        Me.Controls.Add(Me.lblImportStepOne)
        Me.Controls.Add(Me.btnNextImportStep)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmMainImport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import (Textdateien, CSV)"
        CType(Me.lstDatasource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilePath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNextImportStep As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblImportStepOne As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSelectDatasourceFile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lstDatasource As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents txtFilePath As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnBrowseFiles As DevExpress.XtraEditors.SimpleButton
End Class
