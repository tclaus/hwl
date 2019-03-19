<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaticSituation
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
        Me.lblCashValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblBankCash = New DevExpress.XtraEditors.LabelControl()
        Me.lblLiquidCashValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblreceiveable = New DevExpress.XtraEditors.LabelControl()
        Me.lblDebts = New DevExpress.XtraEditors.LabelControl()
        Me.lblCashInventory = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblInventoryValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblTotalCapital = New DevExpress.XtraEditors.LabelControl()
        Me.lblStoreAmmount = New DevExpress.XtraEditors.LabelControl()
        Me.lblNetworth = New DevExpress.XtraEditors.LabelControl()
        Me.lblMonetaryAssets = New DevExpress.XtraEditors.LabelControl()
        Me.lblPayables = New DevExpress.XtraEditors.LabelControl()
        Me.lblReveiceables = New DevExpress.XtraEditors.LabelControl()
        Me.lblLiquidMoney = New DevExpress.XtraEditors.LabelControl()
        Me.lblBank = New DevExpress.XtraEditors.LabelControl()
        Me.lblCash = New DevExpress.XtraEditors.LabelControl()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.cobYears = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblYears = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.cobYears.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCashValue
        '
        Me.lblCashValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashValue.Appearance.Options.UseFont = True
        Me.lblCashValue.Location = New System.Drawing.Point(3, 3)
        Me.lblCashValue.Name = "lblCashValue"
        Me.lblCashValue.Size = New System.Drawing.Size(138, 15)
        Me.lblCashValue.TabIndex = 0
        Me.lblCashValue.Text = "   Bargeld (Kassenbestand)"
        '
        'lblBankCash
        '
        Me.lblBankCash.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankCash.Appearance.Options.UseFont = True
        Me.lblBankCash.Location = New System.Drawing.Point(3, 33)
        Me.lblBankCash.Name = "lblBankCash"
        Me.lblBankCash.Size = New System.Drawing.Size(151, 15)
        Me.lblBankCash.TabIndex = 0
        Me.lblBankCash.Text = "+ Guthaben (Bankguthaben)"
        '
        'lblLiquidCashValue
        '
        Me.lblLiquidCashValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLiquidCashValue.Appearance.Options.UseFont = True
        Me.lblLiquidCashValue.Location = New System.Drawing.Point(3, 63)
        Me.lblLiquidCashValue.Name = "lblLiquidCashValue"
        Me.lblLiquidCashValue.Size = New System.Drawing.Size(88, 15)
        Me.lblLiquidCashValue.TabIndex = 0
        Me.lblLiquidCashValue.Text = "= Liquide Mittel"
        '
        'lblreceiveable
        '
        Me.lblreceiveable.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblreceiveable.Appearance.Options.UseFont = True
        Me.lblreceiveable.Location = New System.Drawing.Point(3, 93)
        Me.lblreceiveable.Name = "lblreceiveable"
        Me.lblreceiveable.Size = New System.Drawing.Size(79, 15)
        Me.lblreceiveable.TabIndex = 0
        Me.lblreceiveable.Text = "+ Forderungen"
        '
        'lblDebts
        '
        Me.lblDebts.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebts.Appearance.Options.UseFont = True
        Me.lblDebts.Location = New System.Drawing.Point(3, 123)
        Me.lblDebts.Name = "lblDebts"
        Me.lblDebts.Size = New System.Drawing.Size(100, 15)
        Me.lblDebts.TabIndex = 0
        Me.lblDebts.Text = "- Verbindlichkeiten"
        '
        'lblCashInventory
        '
        Me.lblCashInventory.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashInventory.Appearance.Options.UseFont = True
        Me.lblCashInventory.Location = New System.Drawing.Point(3, 153)
        Me.lblCashInventory.Name = "lblCashInventory"
        Me.lblCashInventory.Size = New System.Drawing.Size(95, 15)
        Me.lblCashInventory.TabIndex = 0
        Me.lblCashInventory.Text = "= Geldvermögen"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblCashValue, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCashInventory, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBankCash, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDebts, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLiquidCashValue, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblreceiveable, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblInventoryValue, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTotalCapital, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStoreAmmount, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNetworth, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblMonetaryAssets, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPayables, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblReveiceables, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLiquidMoney, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBank, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCash, 1, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(14, 38)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(315, 240)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblInventoryValue
        '
        Me.lblInventoryValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventoryValue.Appearance.Options.UseFont = True
        Me.lblInventoryValue.Location = New System.Drawing.Point(3, 183)
        Me.lblInventoryValue.Name = "lblInventoryValue"
        Me.lblInventoryValue.Size = New System.Drawing.Size(172, 15)
        Me.lblInventoryValue.TabIndex = 0
        Me.lblInventoryValue.Text = "+ Sachvermögen (Lagerbestand)"
        '
        'lblTotalCapital
        '
        Me.lblTotalCapital.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCapital.Appearance.Options.UseFont = True
        Me.lblTotalCapital.Location = New System.Drawing.Point(3, 213)
        Me.lblTotalCapital.Name = "lblTotalCapital"
        Me.lblTotalCapital.Size = New System.Drawing.Size(94, 15)
        Me.lblTotalCapital.TabIndex = 0
        Me.lblTotalCapital.Text = "= Reinvermögen"
        '
        'lblStoreAmmount
        '
        Me.lblStoreAmmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStoreAmmount.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStoreAmmount.Appearance.Options.UseFont = True
        Me.lblStoreAmmount.Location = New System.Drawing.Point(306, 183)
        Me.lblStoreAmmount.Name = "lblStoreAmmount"
        Me.lblStoreAmmount.Size = New System.Drawing.Size(6, 15)
        Me.lblStoreAmmount.TabIndex = 0
        Me.lblStoreAmmount.Tag = "DontTranslate"
        Me.lblStoreAmmount.Text = "0"
        '
        'lblNetworth
        '
        Me.lblNetworth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNetworth.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetworth.Appearance.Options.UseFont = True
        Me.lblNetworth.Location = New System.Drawing.Point(305, 213)
        Me.lblNetworth.Name = "lblNetworth"
        Me.lblNetworth.Size = New System.Drawing.Size(7, 15)
        Me.lblNetworth.TabIndex = 0
        Me.lblNetworth.Tag = "DontTranslate"
        Me.lblNetworth.Text = "0"
        '
        'lblMonetaryAssets
        '
        Me.lblMonetaryAssets.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMonetaryAssets.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonetaryAssets.Appearance.Options.UseFont = True
        Me.lblMonetaryAssets.Location = New System.Drawing.Point(305, 153)
        Me.lblMonetaryAssets.Name = "lblMonetaryAssets"
        Me.lblMonetaryAssets.Size = New System.Drawing.Size(7, 15)
        Me.lblMonetaryAssets.TabIndex = 0
        Me.lblMonetaryAssets.Tag = "DontTranslate"
        Me.lblMonetaryAssets.Text = "0"
        '
        'lblPayables
        '
        Me.lblPayables.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPayables.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayables.Appearance.Options.UseFont = True
        Me.lblPayables.Location = New System.Drawing.Point(306, 123)
        Me.lblPayables.Name = "lblPayables"
        Me.lblPayables.Size = New System.Drawing.Size(6, 15)
        Me.lblPayables.TabIndex = 0
        Me.lblPayables.Tag = "DontTranslate"
        Me.lblPayables.Text = "0"
        '
        'lblReveiceables
        '
        Me.lblReveiceables.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReveiceables.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReveiceables.Appearance.Options.UseFont = True
        Me.lblReveiceables.Location = New System.Drawing.Point(306, 93)
        Me.lblReveiceables.Name = "lblReveiceables"
        Me.lblReveiceables.Size = New System.Drawing.Size(6, 15)
        Me.lblReveiceables.TabIndex = 0
        Me.lblReveiceables.Tag = "DontTranslate"
        Me.lblReveiceables.Text = "0"
        '
        'lblLiquidMoney
        '
        Me.lblLiquidMoney.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLiquidMoney.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLiquidMoney.Appearance.Options.UseFont = True
        Me.lblLiquidMoney.Location = New System.Drawing.Point(305, 63)
        Me.lblLiquidMoney.Name = "lblLiquidMoney"
        Me.lblLiquidMoney.Size = New System.Drawing.Size(7, 15)
        Me.lblLiquidMoney.TabIndex = 0
        Me.lblLiquidMoney.Tag = "DontTranslate"
        Me.lblLiquidMoney.Text = "0"
        '
        'lblBank
        '
        Me.lblBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBank.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBank.Appearance.Options.UseFont = True
        Me.lblBank.Location = New System.Drawing.Point(306, 33)
        Me.lblBank.Name = "lblBank"
        Me.lblBank.Size = New System.Drawing.Size(6, 15)
        Me.lblBank.TabIndex = 0
        Me.lblBank.Tag = "DontTranslate"
        Me.lblBank.Text = "0"
        '
        'lblCash
        '
        Me.lblCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCash.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCash.Appearance.Options.UseFont = True
        Me.lblCash.Location = New System.Drawing.Point(306, 3)
        Me.lblCash.Name = "lblCash"
        Me.lblCash.Size = New System.Drawing.Size(6, 15)
        Me.lblCash.TabIndex = 0
        Me.lblCash.Tag = "DontTranslate"
        Me.lblCash.Text = "0"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(241, 292)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Schliessen"
        '
        'cobYears
        '
        Me.cobYears.Location = New System.Drawing.Point(212, 8)
        Me.cobYears.Name = "cobYears"
        Me.cobYears.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cobYears.Properties.Appearance.Options.UseFont = True
        Me.cobYears.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cobYears.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cobYears.Size = New System.Drawing.Size(117, 22)
        Me.cobYears.TabIndex = 3
        '
        'lblYears
        '
        Me.lblYears.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYears.Appearance.Options.UseFont = True
        Me.lblYears.Location = New System.Drawing.Point(17, 12)
        Me.lblYears.Name = "lblYears"
        Me.lblYears.Size = New System.Drawing.Size(125, 15)
        Me.lblYears.TabIndex = 4
        Me.lblYears.Text = "Betrachtungszeitraum"
        '
        'frmStaticSituation
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(343, 332)
        Me.Controls.Add(Me.lblYears)
        Me.Controls.Add(Me.cobYears)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(310, 303)
        Me.Name = "frmStaticSituation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Augenblickliche Finanz-Situation"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.cobYears.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCashValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblBankCash As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLiquidCashValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblreceiveable As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDebts As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCashInventory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblInventoryValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTotalCapital As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblStoreAmmount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblNetworth As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMonetaryAssets As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPayables As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblReveiceables As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLiquidMoney As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblBank As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCash As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cobYears As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblYears As DevExpress.XtraEditors.LabelControl
End Class
