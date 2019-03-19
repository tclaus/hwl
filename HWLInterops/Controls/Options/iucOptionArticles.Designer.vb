Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucOptionArticles
    Inherits ClausSoftware.HWLInterops.BaseControl

    'iucOptionArticles overrides dispose to clean up the component list.
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(iucOptionArticles))
        Me.btnEditDiscounts = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEditUnits = New DevExpress.XtraEditors.SimpleButton()
        Me.chkShowDiscounts = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowRessources = New DevExpress.XtraEditors.CheckEdit()
        Me.btnEditRessources = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDefaultTaxForNewItems = New DevExpress.XtraEditors.LabelControl()
        Me.cboTax = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnEditLoadAccounts = New DevExpress.XtraEditors.SimpleButton()
        Me.chkShowInactiveItems = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdSetTaxForAllItems = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdSetAllItemsActive = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.chkShowDiscounts.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowRessources.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowInactiveItems.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEditDiscounts
        '
        Me.btnEditDiscounts.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditDiscounts.Appearance.Options.UseFont = True
        Me.btnEditDiscounts.Location = New System.Drawing.Point(3, 60)
        Me.btnEditDiscounts.Name = "btnEditDiscounts"
        Me.btnEditDiscounts.Size = New System.Drawing.Size(87, 27)
        Me.btnEditDiscounts.TabIndex = 2
        Me.btnEditDiscounts.Text = "Rabattwerte..."
        '
        'btnEditUnits
        '
        Me.btnEditUnits.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditUnits.Appearance.Options.UseFont = True
        Me.btnEditUnits.Location = New System.Drawing.Point(3, 27)
        Me.btnEditUnits.Name = "btnEditUnits"
        Me.btnEditUnits.Size = New System.Drawing.Size(87, 27)
        Me.btnEditUnits.TabIndex = 0
        Me.btnEditUnits.Text = "Einheiten..."
        '
        'chkShowDiscounts
        '
        Me.chkShowDiscounts.Location = New System.Drawing.Point(0, 178)
        Me.chkShowDiscounts.Name = "chkShowDiscounts"
        Me.chkShowDiscounts.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowDiscounts.Properties.Appearance.Options.UseFont = True
        Me.chkShowDiscounts.Properties.Caption = "Rabatte benutzen"
        Me.chkShowDiscounts.Size = New System.Drawing.Size(194, 20)
        ToolTipTitleItem1.Text = "Rabatte ein/ausschalten"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Blendet die Rabattberechnung in der Artikelliste ein oder aus." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sie können dann i" & _
    "mmer noch für jeden Artikel einzeln die Rabattberechnung ein oder ausschalten."
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.chkShowDiscounts.SuperTip = SuperToolTip1
        Me.chkShowDiscounts.TabIndex = 5
        '
        'chkShowRessources
        '
        Me.chkShowRessources.Enabled = False
        Me.chkShowRessources.Location = New System.Drawing.Point(0, 204)
        Me.chkShowRessources.Name = "chkShowRessources"
        Me.chkShowRessources.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowRessources.Properties.Appearance.Options.UseFont = True
        Me.chkShowRessources.Properties.Caption = "Rohstoffpreise benutzen"
        Me.chkShowRessources.Size = New System.Drawing.Size(211, 20)
        ToolTipTitleItem2.Text = "Blendet Rohstoffberechnung ein oder aus"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = resources.GetString("ToolTipItem2.Text")
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.chkShowRessources.SuperTip = SuperToolTip2
        Me.chkShowRessources.TabIndex = 6
        '
        'btnEditRessources
        '
        Me.btnEditRessources.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditRessources.Appearance.Options.UseFont = True
        Me.btnEditRessources.Enabled = False
        Me.btnEditRessources.Location = New System.Drawing.Point(160, 27)
        Me.btnEditRessources.Name = "btnEditRessources"
        Me.btnEditRessources.Size = New System.Drawing.Size(123, 27)
        Me.btnEditRessources.TabIndex = 3
        Me.btnEditRessources.Text = "Rohstoffpreise..."
        '
        'lblDefaultTaxForNewItems
        '
        Me.lblDefaultTaxForNewItems.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultTaxForNewItems.Appearance.Options.UseFont = True
        Me.lblDefaultTaxForNewItems.Location = New System.Drawing.Point(2, 231)
        Me.lblDefaultTaxForNewItems.Name = "lblDefaultTaxForNewItems"
        Me.lblDefaultTaxForNewItems.Size = New System.Drawing.Size(105, 15)
        Me.lblDefaultTaxForNewItems.TabIndex = 4
        Me.lblDefaultTaxForNewItems.Text = "Standard-Steuersatz"
        '
        'cboTax
        '
        Me.cboTax.Location = New System.Drawing.Point(123, 230)
        Me.cboTax.Name = "cboTax"
        Me.cboTax.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTax.Properties.Appearance.Options.UseFont = True
        Me.cboTax.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboTax.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboTax.Size = New System.Drawing.Size(103, 22)
        Me.cboTax.TabIndex = 7
        '
        'btnEditLoadAccounts
        '
        Me.btnEditLoadAccounts.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditLoadAccounts.Appearance.Options.UseFont = True
        Me.btnEditLoadAccounts.Location = New System.Drawing.Point(3, 93)
        Me.btnEditLoadAccounts.Name = "btnEditLoadAccounts"
        Me.btnEditLoadAccounts.Size = New System.Drawing.Size(87, 27)
        Me.btnEditLoadAccounts.TabIndex = 1
        Me.btnEditLoadAccounts.Text = "Lohnkonten..."
        Me.btnEditLoadAccounts.Visible = False
        '
        'chkShowInactiveItems
        '
        Me.chkShowInactiveItems.Location = New System.Drawing.Point(0, 153)
        Me.chkShowInactiveItems.Name = "chkShowInactiveItems"
        Me.chkShowInactiveItems.Properties.Caption = "Inaktive Artikel anzeigen"
        Me.chkShowInactiveItems.Size = New System.Drawing.Size(194, 19)
        Me.chkShowInactiveItems.TabIndex = 4
        '
        'cmdSetTaxForAllItems
        '
        Me.cmdSetTaxForAllItems.Location = New System.Drawing.Point(232, 229)
        Me.cmdSetTaxForAllItems.Name = "cmdSetTaxForAllItems"
        Me.cmdSetTaxForAllItems.Size = New System.Drawing.Size(95, 23)
        Me.cmdSetTaxForAllItems.TabIndex = 8
        Me.cmdSetTaxForAllItems.Text = "für alle setzen"
        '
        'cmdSetAllItemsActive
        '
        Me.cmdSetAllItemsActive.Location = New System.Drawing.Point(160, 60)
        Me.cmdSetAllItemsActive.Name = "cmdSetAllItemsActive"
        Me.cmdSetAllItemsActive.Size = New System.Drawing.Size(123, 27)
        Me.cmdSetAllItemsActive.TabIndex = 9
        Me.cmdSetAllItemsActive.Text = "Alle Artikel aktiv setzen"
        '
        'iucOptionArticles
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdSetAllItemsActive)
        Me.Controls.Add(Me.cmdSetTaxForAllItems)
        Me.Controls.Add(Me.chkShowInactiveItems)
        Me.Controls.Add(Me.btnEditLoadAccounts)
        Me.Controls.Add(Me.cboTax)
        Me.Controls.Add(Me.lblDefaultTaxForNewItems)
        Me.Controls.Add(Me.chkShowRessources)
        Me.Controls.Add(Me.chkShowDiscounts)
        Me.Controls.Add(Me.btnEditRessources)
        Me.Controls.Add(Me.btnEditUnits)
        Me.Controls.Add(Me.btnEditDiscounts)
        Me.Name = "iucOptionArticles"
        Me.Size = New System.Drawing.Size(330, 261)
        CType(Me.chkShowDiscounts.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowRessources.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowInactiveItems.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnEditDiscounts As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEditUnits As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkShowDiscounts As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShowRessources As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnEditRessources As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblDefaultTaxForNewItems As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboTax As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btnEditLoadAccounts As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkShowInactiveItems As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdSetTaxForAllItems As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSetAllItemsActive As DevExpress.XtraEditors.SimpleButton

End Class
