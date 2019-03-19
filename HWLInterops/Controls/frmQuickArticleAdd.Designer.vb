<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuickArticleAdd
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
        Me.lblName = New DevExpress.XtraEditors.LabelControl()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
        Me.txtDescription = New DevExpress.XtraEditors.TextEdit()
        Me.lblUnit = New DevExpress.XtraEditors.LabelControl()
        Me.cobUnit = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblEndPrice = New DevExpress.XtraEditors.LabelControl()
        Me.txtPreisVK = New DevExpress.XtraEditors.TextEdit()
        Me.txtPreisEK = New DevExpress.XtraEditors.TextEdit()
        Me.lblBasePrice = New DevExpress.XtraEditors.LabelControl()
        Me.lblArticleEANCode = New DevExpress.XtraEditors.LabelControl()
        Me.txtEAN = New DevExpress.XtraEditors.TextEdit()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cobUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPreisVK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPreisEK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEAN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(30, 24)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(31, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(104, 21)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(320, 20)
        Me.txtName.TabIndex = 0
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(30, 50)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(68, 13)
        Me.lblDescription.TabIndex = 0
        Me.lblDescription.Text = "Beschreibung:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(104, 47)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Properties.Appearance.Options.UseTextOptions = True
        Me.txtDescription.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.txtDescription.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.txtDescription.Properties.AutoHeight = False
        Me.txtDescription.Size = New System.Drawing.Size(320, 47)
        Me.txtDescription.TabIndex = 1
        '
        'lblUnit
        '
        Me.lblUnit.Location = New System.Drawing.Point(30, 130)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(36, 13)
        Me.lblUnit.TabIndex = 2
        Me.lblUnit.Text = "Einheit:"
        '
        'cobUnit
        '
        Me.cobUnit.Location = New System.Drawing.Point(104, 127)
        Me.cobUnit.Name = "cobUnit"
        Me.cobUnit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cobUnit.Size = New System.Drawing.Size(118, 20)
        Me.cobUnit.TabIndex = 3
        '
        'lblEndPrice
        '
        Me.lblEndPrice.Location = New System.Drawing.Point(260, 159)
        Me.lblEndPrice.Name = "lblEndPrice"
        Me.lblEndPrice.Size = New System.Drawing.Size(80, 13)
        Me.lblEndPrice.TabIndex = 2
        Me.lblEndPrice.Text = "Preis VK (Netto):"
        '
        'txtPreisVK
        '
        Me.txtPreisVK.Location = New System.Drawing.Point(351, 156)
        Me.txtPreisVK.Name = "txtPreisVK"
        Me.txtPreisVK.Size = New System.Drawing.Size(73, 20)
        Me.txtPreisVK.TabIndex = 5
        '
        'txtPreisEK
        '
        Me.txtPreisEK.Location = New System.Drawing.Point(351, 127)
        Me.txtPreisEK.Name = "txtPreisEK"
        Me.txtPreisEK.Size = New System.Drawing.Size(73, 20)
        Me.txtPreisEK.TabIndex = 4
        '
        'lblBasePrice
        '
        Me.lblBasePrice.Location = New System.Drawing.Point(260, 130)
        Me.lblBasePrice.Name = "lblBasePrice"
        Me.lblBasePrice.Size = New System.Drawing.Size(76, 13)
        Me.lblBasePrice.TabIndex = 2
        Me.lblBasePrice.Text = "Preis EK (Netto)"
        '
        'lblArticleEANCode
        '
        Me.lblArticleEANCode.Location = New System.Drawing.Point(30, 103)
        Me.lblArticleEANCode.Name = "lblArticleEANCode"
        Me.lblArticleEANCode.Size = New System.Drawing.Size(53, 13)
        Me.lblArticleEANCode.TabIndex = 0
        Me.lblArticleEANCode.Text = "EAN-Code:"
        '
        'txtEAN
        '
        Me.txtEAN.Location = New System.Drawing.Point(104, 100)
        Me.txtEAN.Name = "txtEAN"
        Me.txtEAN.Size = New System.Drawing.Size(320, 20)
        Me.txtEAN.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(23, 194)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(351, 194)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Abbrechen"
        '
        'frmQuickArticleAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(440, 229)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cobUnit)
        Me.Controls.Add(Me.lblBasePrice)
        Me.Controls.Add(Me.lblEndPrice)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtPreisEK)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtPreisVK)
        Me.Controls.Add(Me.txtEAN)
        Me.Controls.Add(Me.lblArticleEANCode)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmQuickArticleAdd"
        Me.Text = "Schnelles hinzufügen von Artikel"
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cobUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPreisVK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPreisEK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEAN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblUnit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cobUnit As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblEndPrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPreisVK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPreisEK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblBasePrice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblArticleEANCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEAN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
End Class
