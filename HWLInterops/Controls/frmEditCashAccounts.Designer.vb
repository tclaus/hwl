<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditCashAccounts
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
        Me.lblAccoutName = New DevExpress.XtraEditors.LabelControl()
        Me.lblBasedOn = New DevExpress.XtraEditors.LabelControl()
        Me.lblAccountNumber = New DevExpress.XtraEditors.LabelControl()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.cboBaseAccount = New System.Windows.Forms.ComboBox()
        Me.txtDisplayNumber = New DevExpress.XtraEditors.TextEdit()
        Me.cboMwSt = New System.Windows.Forms.ComboBox()
        Me.lblTaxRate = New DevExpress.XtraEditors.LabelControl()
        Me.chkBaseAccount = New DevExpress.XtraEditors.CheckEdit()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDisplayNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkBaseAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAccoutName
        '
        Me.lblAccoutName.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccoutName.Appearance.Options.UseFont = True
        Me.lblAccoutName.Location = New System.Drawing.Point(143, 18)
        Me.lblAccoutName.Name = "lblAccoutName"
        Me.lblAccoutName.Size = New System.Drawing.Size(93, 15)
        Me.lblAccoutName.TabIndex = 1
        Me.lblAccoutName.Text = "Name des Kontos"
        '
        'lblBasedOn
        '
        Me.lblBasedOn.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBasedOn.Appearance.Options.UseFont = True
        Me.lblBasedOn.Location = New System.Drawing.Point(31, 132)
        Me.lblBasedOn.Name = "lblBasedOn"
        Me.lblBasedOn.Size = New System.Drawing.Size(67, 15)
        Me.lblBasedOn.TabIndex = 1
        Me.lblBasedOn.Text = "Basiert auf... "
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountNumber.Appearance.Options.UseFont = True
        Me.lblAccountNumber.Location = New System.Drawing.Point(31, 18)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Size = New System.Drawing.Size(78, 15)
        Me.lblAccountNumber.TabIndex = 1
        Me.lblAccountNumber.Text = "Kontonummer"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(143, 40)
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Properties.Appearance.Options.UseFont = True
        Me.txtName.Size = New System.Drawing.Size(231, 22)
        Me.txtName.TabIndex = 1
        '
        'cboBaseAccount
        '
        Me.cboBaseAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBaseAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBaseAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaseAccount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBaseAccount.FormattingEnabled = True
        Me.cboBaseAccount.ItemHeight = 15
        Me.cboBaseAccount.Location = New System.Drawing.Point(31, 153)
        Me.cboBaseAccount.MaxDropDownItems = 25
        Me.cboBaseAccount.Name = "cboBaseAccount"
        Me.cboBaseAccount.Size = New System.Drawing.Size(230, 23)
        Me.cboBaseAccount.TabIndex = 3
        '
        'txtDisplayNumber
        '
        Me.txtDisplayNumber.Location = New System.Drawing.Point(31, 39)
        Me.txtDisplayNumber.Name = "txtDisplayNumber"
        Me.txtDisplayNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisplayNumber.Properties.Appearance.Options.UseFont = True
        Me.txtDisplayNumber.Size = New System.Drawing.Size(90, 22)
        Me.txtDisplayNumber.TabIndex = 0
        '
        'cboMwSt
        '
        Me.cboMwSt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMwSt.FormattingEnabled = True
        Me.cboMwSt.Location = New System.Drawing.Point(31, 96)
        Me.cboMwSt.Name = "cboMwSt"
        Me.cboMwSt.Size = New System.Drawing.Size(140, 23)
        Me.cboMwSt.TabIndex = 2
        '
        'lblTaxRate
        '
        Me.lblTaxRate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxRate.Appearance.Options.UseFont = True
        Me.lblTaxRate.Location = New System.Drawing.Point(31, 72)
        Me.lblTaxRate.Name = "lblTaxRate"
        Me.lblTaxRate.Size = New System.Drawing.Size(56, 15)
        Me.lblTaxRate.TabIndex = 5
        Me.lblTaxRate.Text = "Steuersatz:"
        '
        'chkBaseAccount
        '
        Me.chkBaseAccount.Location = New System.Drawing.Point(29, 187)
        Me.chkBaseAccount.Name = "chkBaseAccount"
        Me.chkBaseAccount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseAccount.Properties.Appearance.Options.UseFont = True
        Me.chkBaseAccount.Properties.Caption = "Basiskonto - nicht Buchbar"
        Me.chkBaseAccount.Size = New System.Drawing.Size(233, 20)
        Me.chkBaseAccount.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(304, 220)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 27)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.Location = New System.Drawing.Point(210, 220)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(87, 27)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'frmEditCashAccounts
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(406, 261)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.chkBaseAccount)
        Me.Controls.Add(Me.lblTaxRate)
        Me.Controls.Add(Me.cboMwSt)
        Me.Controls.Add(Me.cboBaseAccount)
        Me.Controls.Add(Me.txtDisplayNumber)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblAccountNumber)
        Me.Controls.Add(Me.lblBasedOn)
        Me.Controls.Add(Me.lblAccoutName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(339, 205)
        Me.Name = "frmEditCashAccounts"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Kontorahmen bearbeiten"
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDisplayNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkBaseAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAccoutName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblBasedOn As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblAccountNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboBaseAccount As System.Windows.Forms.ComboBox
    Friend WithEvents txtDisplayNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboMwSt As System.Windows.Forms.ComboBox
    Friend WithEvents lblTaxRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkBaseAccount As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
End Class
