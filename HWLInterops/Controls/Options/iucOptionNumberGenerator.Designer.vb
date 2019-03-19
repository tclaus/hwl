<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucOptionNumberGenerator
    Inherits ClausSoftware.HWLInterops.BaseControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblNumberOffers = New DevExpress.XtraEditors.LabelControl()
        Me.lblNumbersInvoices = New DevExpress.XtraEditors.LabelControl()
        Me.lblNumbersCustomers = New DevExpress.XtraEditors.LabelControl()
        Me.txtOffersReplacement = New DevExpress.XtraEditors.TextEdit()
        Me.txtInvoicesReplacement = New DevExpress.XtraEditors.TextEdit()
        Me.txtCustomersReplacement = New DevExpress.XtraEditors.TextEdit()
        Me.txtCustomersInitialNumber = New DevExpress.XtraEditors.TextEdit()
        Me.txtInvoicesInitialNumber = New DevExpress.XtraEditors.TextEdit()
        Me.txtOffersInitialNumber = New DevExpress.XtraEditors.TextEdit()
        Me.lblOffersPreview = New DevExpress.XtraEditors.LabelControl()
        Me.lblInvoicesPreview = New DevExpress.XtraEditors.LabelControl()
        Me.lblCustomersPreview = New DevExpress.XtraEditors.LabelControl()
        Me.lblStartValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblPlaceHolder = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNextNumberInList = New DevExpress.XtraEditors.LabelControl()
        Me.btnWriteNewData = New DevExpress.XtraEditors.SimpleButton()
        Me.LoadingCircle1 = New ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle()
        Me.btnShowPlaceHolder = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtOffersReplacement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvoicesReplacement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCustomersReplacement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCustomersInitialNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInvoicesInitialNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOffersInitialNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNumberOffers
        '
        Me.lblNumberOffers.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumberOffers.Appearance.Options.UseFont = True
        Me.lblNumberOffers.Location = New System.Drawing.Point(3, 23)
        Me.lblNumberOffers.Name = "lblNumberOffers"
        Me.lblNumberOffers.Size = New System.Drawing.Size(55, 15)
        Me.lblNumberOffers.TabIndex = 0
        Me.lblNumberOffers.Text = "Angebote:"
        '
        'lblNumbersInvoices
        '
        Me.lblNumbersInvoices.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumbersInvoices.Appearance.Options.UseFont = True
        Me.lblNumbersInvoices.Location = New System.Drawing.Point(3, 66)
        Me.lblNumbersInvoices.Name = "lblNumbersInvoices"
        Me.lblNumbersInvoices.Size = New System.Drawing.Size(67, 15)
        Me.lblNumbersInvoices.TabIndex = 0
        Me.lblNumbersInvoices.Text = "Rechnungen"
        '
        'lblNumbersCustomers
        '
        Me.lblNumbersCustomers.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumbersCustomers.Appearance.Options.UseFont = True
        Me.lblNumbersCustomers.Location = New System.Drawing.Point(3, 109)
        Me.lblNumbersCustomers.Name = "lblNumbersCustomers"
        Me.lblNumbersCustomers.Size = New System.Drawing.Size(48, 15)
        Me.lblNumbersCustomers.TabIndex = 0
        Me.lblNumbersCustomers.Text = "Adressen"
        '
        'txtOffersReplacement
        '
        Me.txtOffersReplacement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOffersReplacement.EditValue = "$NR"
        Me.txtOffersReplacement.Location = New System.Drawing.Point(180, 23)
        Me.txtOffersReplacement.Name = "txtOffersReplacement"
        Me.txtOffersReplacement.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOffersReplacement.Properties.Appearance.Options.UseFont = True
        Me.txtOffersReplacement.Properties.Appearance.Options.UseTextOptions = True
        Me.txtOffersReplacement.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtOffersReplacement.Size = New System.Drawing.Size(78, 22)
        Me.txtOffersReplacement.TabIndex = 1
        '
        'txtInvoicesReplacement
        '
        Me.txtInvoicesReplacement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvoicesReplacement.EditValue = "$NR"
        Me.txtInvoicesReplacement.Location = New System.Drawing.Point(180, 66)
        Me.txtInvoicesReplacement.Name = "txtInvoicesReplacement"
        Me.txtInvoicesReplacement.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoicesReplacement.Properties.Appearance.Options.UseFont = True
        Me.txtInvoicesReplacement.Properties.Appearance.Options.UseTextOptions = True
        Me.txtInvoicesReplacement.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtInvoicesReplacement.Size = New System.Drawing.Size(78, 22)
        Me.txtInvoicesReplacement.TabIndex = 3
        '
        'txtCustomersReplacement
        '
        Me.txtCustomersReplacement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomersReplacement.EditValue = "$NR"
        Me.txtCustomersReplacement.Location = New System.Drawing.Point(180, 109)
        Me.txtCustomersReplacement.Name = "txtCustomersReplacement"
        Me.txtCustomersReplacement.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomersReplacement.Properties.Appearance.Options.UseFont = True
        Me.txtCustomersReplacement.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCustomersReplacement.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtCustomersReplacement.Size = New System.Drawing.Size(78, 22)
        Me.txtCustomersReplacement.TabIndex = 5
        '
        'txtCustomersInitialNumber
        '
        Me.txtCustomersInitialNumber.EditValue = "0"
        Me.txtCustomersInitialNumber.Location = New System.Drawing.Point(76, 109)
        Me.txtCustomersInitialNumber.Name = "txtCustomersInitialNumber"
        Me.txtCustomersInitialNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomersInitialNumber.Properties.Appearance.Options.UseFont = True
        Me.txtCustomersInitialNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtCustomersInitialNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtCustomersInitialNumber.Properties.Mask.EditMask = "d"
        Me.txtCustomersInitialNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCustomersInitialNumber.Size = New System.Drawing.Size(65, 22)
        Me.txtCustomersInitialNumber.TabIndex = 4
        '
        'txtInvoicesInitialNumber
        '
        Me.txtInvoicesInitialNumber.EditValue = "0"
        Me.txtInvoicesInitialNumber.Location = New System.Drawing.Point(76, 66)
        Me.txtInvoicesInitialNumber.Name = "txtInvoicesInitialNumber"
        Me.txtInvoicesInitialNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoicesInitialNumber.Properties.Appearance.Options.UseFont = True
        Me.txtInvoicesInitialNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtInvoicesInitialNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtInvoicesInitialNumber.Properties.Mask.EditMask = "d"
        Me.txtInvoicesInitialNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtInvoicesInitialNumber.Size = New System.Drawing.Size(65, 22)
        Me.txtInvoicesInitialNumber.TabIndex = 2
        '
        'txtOffersInitialNumber
        '
        Me.txtOffersInitialNumber.EditValue = "0"
        Me.txtOffersInitialNumber.Location = New System.Drawing.Point(76, 23)
        Me.txtOffersInitialNumber.Name = "txtOffersInitialNumber"
        Me.txtOffersInitialNumber.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOffersInitialNumber.Properties.Appearance.Options.UseFont = True
        Me.txtOffersInitialNumber.Properties.Appearance.Options.UseTextOptions = True
        Me.txtOffersInitialNumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtOffersInitialNumber.Properties.Mask.EditMask = "d"
        Me.txtOffersInitialNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtOffersInitialNumber.Size = New System.Drawing.Size(65, 22)
        Me.txtOffersInitialNumber.TabIndex = 0
        '
        'lblOffersPreview
        '
        Me.lblOffersPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOffersPreview.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOffersPreview.Appearance.Options.UseFont = True
        Me.lblOffersPreview.Location = New System.Drawing.Point(344, 23)
        Me.lblOffersPreview.Name = "lblOffersPreview"
        Me.lblOffersPreview.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.lblOffersPreview.Size = New System.Drawing.Size(17, 15)
        Me.lblOffersPreview.TabIndex = 7
        Me.lblOffersPreview.Tag = "DONTTRANSLATE"
        Me.lblOffersPreview.Text = "0"
        '
        'lblInvoicesPreview
        '
        Me.lblInvoicesPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInvoicesPreview.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoicesPreview.Appearance.Options.UseFont = True
        Me.lblInvoicesPreview.Location = New System.Drawing.Point(344, 66)
        Me.lblInvoicesPreview.Name = "lblInvoicesPreview"
        Me.lblInvoicesPreview.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.lblInvoicesPreview.Size = New System.Drawing.Size(17, 15)
        Me.lblInvoicesPreview.TabIndex = 7
        Me.lblInvoicesPreview.Tag = "DONTTRANSLATE"
        Me.lblInvoicesPreview.Text = "0"
        '
        'lblCustomersPreview
        '
        Me.lblCustomersPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCustomersPreview.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomersPreview.Appearance.Options.UseFont = True
        Me.lblCustomersPreview.Location = New System.Drawing.Point(344, 109)
        Me.lblCustomersPreview.Name = "lblCustomersPreview"
        Me.lblCustomersPreview.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.lblCustomersPreview.Size = New System.Drawing.Size(17, 15)
        Me.lblCustomersPreview.TabIndex = 7
        Me.lblCustomersPreview.Tag = "DONTTRANSLATE"
        Me.lblCustomersPreview.Text = "0"
        '
        'lblStartValue
        '
        Me.lblStartValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartValue.Appearance.Options.UseFont = True
        Me.lblStartValue.Location = New System.Drawing.Point(76, 3)
        Me.lblStartValue.Name = "lblStartValue"
        Me.lblStartValue.Size = New System.Drawing.Size(47, 15)
        Me.lblStartValue.TabIndex = 8
        Me.lblStartValue.Text = "Startwert"
        '
        'lblPlaceHolder
        '
        Me.lblPlaceHolder.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlaceHolder.Appearance.Options.UseFont = True
        Me.lblPlaceHolder.Location = New System.Drawing.Point(147, 3)
        Me.lblPlaceHolder.Name = "lblPlaceHolder"
        Me.lblPlaceHolder.Size = New System.Drawing.Size(111, 15)
        Me.lblPlaceHolder.TabIndex = 8
        Me.lblPlaceHolder.Text = "Platzhalter/Ersetzung"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 409.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtCustomersInitialNumber, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtInvoicesInitialNumber, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtOffersInitialNumber, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCustomersPreview, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPlaceHolder, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblInvoicesPreview, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOffersPreview, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblStartValue, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCustomersReplacement, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtOffersReplacement, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtInvoicesReplacement, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNumbersCustomers, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNumbersInvoices, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNumberOffers, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNextNumberInList, 3, 0)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(773, 150)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'lblNextNumberInList
        '
        Me.lblNextNumberInList.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNextNumberInList.Appearance.Options.UseFont = True
        Me.lblNextNumberInList.Location = New System.Drawing.Point(264, 3)
        Me.lblNextNumberInList.Name = "lblNextNumberInList"
        Me.lblNextNumberInList.Size = New System.Drawing.Size(97, 15)
        Me.lblNextNumberInList.TabIndex = 8
        Me.lblNextNumberInList.Text = "Nächste Nummer:"
        '
        'btnWriteNewData
        '
        Me.btnWriteNewData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWriteNewData.Enabled = False
        Me.btnWriteNewData.Location = New System.Drawing.Point(243, 155)
        Me.btnWriteNewData.Name = "btnWriteNewData"
        Me.btnWriteNewData.Size = New System.Drawing.Size(128, 30)
        Me.btnWriteNewData.TabIndex = 0
        Me.btnWriteNewData.Text = "Neu schreiben..."
        '
        'LoadingCircle1
        '
        Me.LoadingCircle1.Active = False
        Me.LoadingCircle1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LoadingCircle1.Color = System.Drawing.Color.DarkGray
        Me.LoadingCircle1.InnerCircleRadius = 8
        Me.LoadingCircle1.Location = New System.Drawing.Point(6, 156)
        Me.LoadingCircle1.Name = "LoadingCircle1"
        Me.LoadingCircle1.NumberSpoke = 10
        Me.LoadingCircle1.OuterCircleRadius = 10
        Me.LoadingCircle1.RotationSpeed = 100
        Me.LoadingCircle1.Size = New System.Drawing.Size(36, 29)
        Me.LoadingCircle1.SpokeThickness = 4
        Me.LoadingCircle1.StylePreset = ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX
        Me.LoadingCircle1.TabIndex = 10
        Me.LoadingCircle1.Visible = False
        '
        'btnShowPlaceHolder
        '
        Me.btnShowPlaceHolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowPlaceHolder.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowPlaceHolder.Appearance.Options.UseFont = True
        Me.btnShowPlaceHolder.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Symbol_Help16x16
        Me.btnShowPlaceHolder.Location = New System.Drawing.Point(109, 155)
        Me.btnShowPlaceHolder.Name = "btnShowPlaceHolder"
        Me.btnShowPlaceHolder.Size = New System.Drawing.Size(128, 30)
        Me.btnShowPlaceHolder.TabIndex = 1
        Me.btnShowPlaceHolder.Text = "Zeige Platzhalter..."
        '
        'iucOptionNumberGenerator
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LoadingCircle1)
        Me.Controls.Add(Me.btnWriteNewData)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnShowPlaceHolder)
        Me.Name = "iucOptionNumberGenerator"
        Me.Size = New System.Drawing.Size(374, 194)
        CType(Me.txtOffersReplacement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvoicesReplacement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCustomersReplacement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCustomersInitialNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInvoicesInitialNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOffersInitialNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNumberOffers As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblNumbersInvoices As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblNumbersCustomers As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnShowPlaceHolder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtOffersReplacement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtInvoicesReplacement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCustomersReplacement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCustomersInitialNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtInvoicesInitialNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtOffersInitialNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblOffersPreview As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblInvoicesPreview As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCustomersPreview As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblStartValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPlaceHolder As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblNextNumberInList As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnWriteNewData As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LoadingCircle1 As ClausSoftware.HWLInterops.MRG.Controls.UI.LoadingCircle

End Class
