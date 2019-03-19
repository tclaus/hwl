<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLicenses
    Inherits ClausSoftware.HWLInterops.BaseForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.grdLicenses = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.lblProgramID = New System.Windows.Forms.Label()
        Me.lblApplicationKey = New System.Windows.Forms.Label()
        Me.lblLicenseTextheadline = New System.Windows.Forms.Label()
        Me.btnEnterCode = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.lblInvalidCode = New DevExpress.XtraEditors.LabelControl()
        CType(Me.grdLicenses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdLicenses
        '
        Me.grdLicenses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdLicenses.Location = New System.Drawing.Point(12, 173)
        Me.grdLicenses.MainView = Me.GridView1
        Me.grdLicenses.Name = "grdLicenses"
        Me.grdLicenses.Padding = New System.Windows.Forms.Padding(5)
        Me.grdLicenses.Size = New System.Drawing.Size(323, 135)
        Me.grdLicenses.TabIndex = 0
        Me.grdLicenses.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.CustomizationFormBounds = New System.Drawing.Rectangle(1197, 599, 208, 170)
        Me.GridView1.GridControl = Me.grdLicenses
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(245, 326)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Schliessen"
        '
        'lblProgramID
        '
        Me.lblProgramID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProgramID.BackColor = System.Drawing.Color.LightYellow
        Me.lblProgramID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProgramID.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgramID.Location = New System.Drawing.Point(192, 8)
        Me.lblProgramID.Name = "lblProgramID"
        Me.lblProgramID.Size = New System.Drawing.Size(140, 38)
        Me.lblProgramID.TabIndex = 6
        Me.lblProgramID.Tag = "dontTranslate"
        Me.lblProgramID.Text = "AB42Z"
        Me.lblProgramID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblApplicationKey
        '
        Me.lblApplicationKey.AutoSize = True
        Me.lblApplicationKey.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApplicationKey.Location = New System.Drawing.Point(12, 22)
        Me.lblApplicationKey.Name = "lblApplicationKey"
        Me.lblApplicationKey.Size = New System.Drawing.Size(124, 17)
        Me.lblApplicationKey.TabIndex = 7
        Me.lblApplicationKey.Text = "Programmschlüssel:"
        '
        'lblLicenseTextheadline
        '
        Me.lblLicenseTextheadline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLicenseTextheadline.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLicenseTextheadline.Location = New System.Drawing.Point(12, 92)
        Me.lblLicenseTextheadline.Name = "lblLicenseTextheadline"
        Me.lblLicenseTextheadline.Size = New System.Drawing.Size(320, 74)
        Me.lblLicenseTextheadline.TabIndex = 8
        Me.lblLicenseTextheadline.Text = "Nach der ersten Installation haben Sie {0} Tage Zeit alle Programmmodule vor dem " & _
    "Kauf zu testen. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Geben Sie bei der Anforderung des Lizenzschlüssels diesen Code" & _
    " an." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnEnterCode
        '
        Me.btnEnterCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnterCode.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnterCode.Appearance.Options.UseFont = True
        Me.btnEnterCode.Enabled = False
        Me.btnEnterCode.Location = New System.Drawing.Point(120, 326)
        Me.btnEnterCode.Name = "btnEnterCode"
        Me.btnEnterCode.Size = New System.Drawing.Size(118, 27)
        Me.btnEnterCode.TabIndex = 9
        Me.btnEnterCode.Text = "Code eingeben"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(26, 326)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 27)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Löschen"
        Me.btnDelete.ToolTip = "Löscht die gesamte Lizenz aus dem Lizenzspeicher. Wenn ein Modul eine Lizenz anfo" & _
    "rdert, wird diese wieder angelegt."
        '
        'lblInvalidCode
        '
        Me.lblInvalidCode.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblInvalidCode.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvalidCode.Appearance.ForeColor = System.Drawing.Color.Red
        Me.lblInvalidCode.Appearance.Options.UseBackColor = True
        Me.lblInvalidCode.Appearance.Options.UseFont = True
        Me.lblInvalidCode.Appearance.Options.UseForeColor = True
        Me.lblInvalidCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblInvalidCode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblInvalidCode.Location = New System.Drawing.Point(12, 51)
        Me.lblInvalidCode.Name = "lblInvalidCode"
        Me.lblInvalidCode.Size = New System.Drawing.Size(320, 38)
        Me.lblInvalidCode.TabIndex = 11
        Me.lblInvalidCode.Text = "Der Code ist möglicherweise beschädigt." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Klicken sie hier um den Code zu reparier" & _
    "en."
        Me.lblInvalidCode.Visible = False
        '
        'frmLicenses
        '
        Me.AcceptButton = Me.btnClose
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(347, 366)
        Me.Controls.Add(Me.lblInvalidCode)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEnterCode)
        Me.Controls.Add(Me.lblLicenseTextheadline)
        Me.Controls.Add(Me.lblApplicationKey)
        Me.Controls.Add(Me.lblProgramID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grdLicenses)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(363, 394)
        Me.Name = "frmLicenses"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " Lizenzen..."
        CType(Me.grdLicenses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdLicenses As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblProgramID As System.Windows.Forms.Label
    Friend WithEvents lblApplicationKey As System.Windows.Forms.Label
    Friend WithEvents lblLicenseTextheadline As System.Windows.Forms.Label
    Friend WithEvents btnEnterCode As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblInvalidCode As DevExpress.XtraEditors.LabelControl
End Class
