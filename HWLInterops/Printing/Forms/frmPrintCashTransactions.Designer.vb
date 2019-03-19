
Namespace Printing

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPrintCashTransactions
        Inherits ClausSoftware.HWLInterops.BaseForm


        'Form overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Me.btnPrintCashMonthly = New DevExpress.XtraEditors.DropDownButton()
            Me.pumMonthNames = New DevExpress.XtraBars.PopupMenu(Me.components)
            Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
            Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
            Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
            Me.btnPrintCashByQuarter = New DevExpress.XtraEditors.DropDownButton()
            Me.pumQuartals = New DevExpress.XtraBars.PopupMenu(Me.components)
            Me.cobYears = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.lblYear = New DevExpress.XtraEditors.LabelControl()
            Me.btnPrintLists = New DevExpress.XtraEditors.SimpleButton()
            Me.btnPrintCashYear = New DevExpress.XtraEditors.SimpleButton()
            Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
            Me.grpPrintCashReportsSheets = New DevExpress.XtraEditors.GroupControl()
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.pumMonthNames, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pumQuartals, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cobYears.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grpPrintCashReportsSheets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpPrintCashReportsSheets.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnPrintCashMonthly
            '
            Me.btnPrintCashMonthly.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintCashMonthly.Appearance.Options.UseFont = True
            Me.btnPrintCashMonthly.DropDownControl = Me.pumMonthNames
            Me.btnPrintCashMonthly.Enabled = False
            Me.btnPrintCashMonthly.Location = New System.Drawing.Point(73, 119)
            Me.btnPrintCashMonthly.Name = "btnPrintCashMonthly"
            Me.btnPrintCashMonthly.Size = New System.Drawing.Size(134, 27)
            Me.btnPrintCashMonthly.TabIndex = 3
            Me.btnPrintCashMonthly.Tag = "donttranslate"
            Me.btnPrintCashMonthly.Text = "Kassenblatt (Mai)"
            '
            'pumMonthNames
            '
            Me.pumMonthNames.Manager = Me.BarManager1
            Me.pumMonthNames.Name = "pumMonthNames"
            '
            'BarManager1
            '
            Me.BarManager1.DockControls.Add(Me.barDockControlTop)
            Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
            Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
            Me.BarManager1.DockControls.Add(Me.barDockControlRight)
            Me.BarManager1.Form = Me
            Me.BarManager1.MaxItemId = 0
            '
            'barDockControlTop
            '
            Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
            Me.barDockControlTop.Size = New System.Drawing.Size(285, 0)
            '
            'barDockControlBottom
            '
            Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.barDockControlBottom.Location = New System.Drawing.Point(0, 243)
            Me.barDockControlBottom.Size = New System.Drawing.Size(285, 0)
            '
            'barDockControlLeft
            '
            Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
            Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
            Me.barDockControlLeft.Size = New System.Drawing.Size(0, 243)
            '
            'barDockControlRight
            '
            Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
            Me.barDockControlRight.Location = New System.Drawing.Point(285, 0)
            Me.barDockControlRight.Size = New System.Drawing.Size(0, 243)
            '
            'btnPrintCashByQuarter
            '
            Me.btnPrintCashByQuarter.DropDownControl = Me.pumQuartals
            Me.btnPrintCashByQuarter.Location = New System.Drawing.Point(73, 86)
            Me.btnPrintCashByQuarter.MenuManager = Me.BarManager1
            Me.btnPrintCashByQuarter.Name = "btnPrintCashByQuarter"
            Me.BarManager1.SetPopupContextMenu(Me.btnPrintCashByQuarter, Me.pumQuartals)
            Me.btnPrintCashByQuarter.Size = New System.Drawing.Size(135, 27)
            Me.btnPrintCashByQuarter.TabIndex = 4
            Me.btnPrintCashByQuarter.Text = "Quartal"
            '
            'pumQuartals
            '
            Me.pumQuartals.Manager = Me.BarManager1
            Me.pumQuartals.Name = "pumQuartals"
            '
            'cobYears
            '
            Me.cobYears.Location = New System.Drawing.Point(73, 25)
            Me.cobYears.Name = "cobYears"
            Me.cobYears.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cobYears.Properties.Appearance.Options.UseFont = True
            Me.cobYears.Properties.Appearance.Options.UseTextOptions = True
            Me.cobYears.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.cobYears.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cobYears.Properties.NullValuePrompt = "Keine Einträge vorhanden"
            Me.cobYears.Properties.NullValuePromptShowForEmptyValue = True
            Me.cobYears.Properties.Sorted = True
            Me.cobYears.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.cobYears.Size = New System.Drawing.Size(131, 22)
            Me.cobYears.TabIndex = 0
            '
            'lblYear
            '
            Me.lblYear.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblYear.Appearance.Options.UseFont = True
            Me.lblYear.Location = New System.Drawing.Point(5, 28)
            Me.lblYear.Name = "lblYear"
            Me.lblYear.Size = New System.Drawing.Size(27, 15)
            Me.lblYear.TabIndex = 2
            Me.lblYear.Text = "Jahr: "
            '
            'btnPrintLists
            '
            Me.btnPrintLists.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnPrintLists.Location = New System.Drawing.Point(12, 204)
            Me.btnPrintLists.Name = "btnPrintLists"
            Me.btnPrintLists.Size = New System.Drawing.Size(120, 27)
            Me.btnPrintLists.TabIndex = 1
            Me.btnPrintLists.Text = "Listendruck"
            '
            'btnPrintCashYear
            '
            Me.btnPrintCashYear.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintCashYear.Appearance.Options.UseFont = True
            Me.btnPrintCashYear.Enabled = False
            Me.btnPrintCashYear.Location = New System.Drawing.Point(73, 53)
            Me.btnPrintCashYear.Name = "btnPrintCashYear"
            Me.btnPrintCashYear.Size = New System.Drawing.Size(135, 27)
            Me.btnPrintCashYear.TabIndex = 2
            Me.btnPrintCashYear.Text = "Jahresübersicht"
            '
            'LabelControl1
            '
            Me.LabelControl1.Location = New System.Drawing.Point(41, 37)
            Me.LabelControl1.Name = "LabelControl1"
            Me.LabelControl1.Size = New System.Drawing.Size(0, 13)
            Me.LabelControl1.TabIndex = 8
            '
            'grpPrintCashReportsSheets
            '
            Me.grpPrintCashReportsSheets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.grpPrintCashReportsSheets.Appearance.BackColor = System.Drawing.Color.White
            Me.grpPrintCashReportsSheets.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpPrintCashReportsSheets.Appearance.Options.UseBackColor = True
            Me.grpPrintCashReportsSheets.Appearance.Options.UseFont = True
            Me.grpPrintCashReportsSheets.AppearanceCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpPrintCashReportsSheets.AppearanceCaption.Options.UseFont = True
            Me.grpPrintCashReportsSheets.Controls.Add(Me.btnPrintCashByQuarter)
            Me.grpPrintCashReportsSheets.Controls.Add(Me.btnPrintCashMonthly)
            Me.grpPrintCashReportsSheets.Controls.Add(Me.btnPrintCashYear)
            Me.grpPrintCashReportsSheets.Controls.Add(Me.cobYears)
            Me.grpPrintCashReportsSheets.Controls.Add(Me.lblYear)
            Me.grpPrintCashReportsSheets.Location = New System.Drawing.Point(12, 16)
            Me.grpPrintCashReportsSheets.Name = "grpPrintCashReportsSheets"
            Me.grpPrintCashReportsSheets.Size = New System.Drawing.Size(258, 182)
            Me.grpPrintCashReportsSheets.TabIndex = 9
            Me.grpPrintCashReportsSheets.Text = "Kassenaufstellung"
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnClose.Location = New System.Drawing.Point(150, 204)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(120, 27)
            Me.btnClose.TabIndex = 10
            Me.btnClose.Text = "Schliessen"
            '
            'frmPrintCashTransactions
            '
            Me.Appearance.BackColor = System.Drawing.Color.White
            Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseBackColor = True
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(285, 243)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.grpPrintCashReportsSheets)
            Me.Controls.Add(Me.LabelControl1)
            Me.Controls.Add(Me.btnPrintLists)
            Me.Controls.Add(Me.barDockControlLeft)
            Me.Controls.Add(Me.barDockControlRight)
            Me.Controls.Add(Me.barDockControlBottom)
            Me.Controls.Add(Me.barDockControlTop)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmPrintCashTransactions"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Kassenbuch drucken..."
            CType(Me.pumMonthNames, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pumQuartals, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cobYears.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grpPrintCashReportsSheets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpPrintCashReportsSheets.ResumeLayout(False)
            Me.grpPrintCashReportsSheets.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnPrintCashMonthly As DevExpress.XtraEditors.DropDownButton
        Friend WithEvents cobYears As DevExpress.XtraEditors.ComboBoxEdit
        Friend WithEvents lblYear As DevExpress.XtraEditors.LabelControl
        Friend WithEvents btnPrintLists As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnPrintCashYear As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents pumMonthNames As DevExpress.XtraBars.PopupMenu
        Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
        Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
        Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents grpPrintCashReportsSheets As DevExpress.XtraEditors.GroupControl
        Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
        Friend WithEvents btnPrintCashByQuarter As DevExpress.XtraEditors.DropDownButton
        Friend WithEvents pumQuartals As DevExpress.XtraBars.PopupMenu
    End Class
End Namespace
