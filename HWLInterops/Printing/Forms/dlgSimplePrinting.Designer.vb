Namespace Printing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Friend Class dlgSimplePrinting
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
            Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
            Me.cmdPrint = New DevExpress.XtraEditors.SimpleButton()
            Me.cobPrintLayouts = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.chkPrintList = New DevExpress.XtraEditors.CheckEdit()
            Me.chkPrintLayout = New DevExpress.XtraEditors.CheckEdit()
            Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.btnPreview = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.cobPrintLayouts.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkPrintList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkPrintLayout.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl1.SuspendLayout()
            Me.SuspendLayout()
            '
            'cmdClose
            '
            Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.cmdClose.Location = New System.Drawing.Point(209, 117)
            Me.cmdClose.Name = "cmdClose"
            Me.cmdClose.Size = New System.Drawing.Size(75, 23)
            Me.cmdClose.TabIndex = 1
            Me.cmdClose.Text = "Schliessen"
            '
            'cmdPrint
            '
            Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmdPrint.Location = New System.Drawing.Point(47, 117)
            Me.cmdPrint.Name = "cmdPrint"
            Me.cmdPrint.Size = New System.Drawing.Size(75, 23)
            Me.cmdPrint.TabIndex = 1
            Me.cmdPrint.Text = "Drucken"
            '
            'cobPrintLayouts
            '
            Me.cobPrintLayouts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cobPrintLayouts.Enabled = False
            Me.cobPrintLayouts.Location = New System.Drawing.Point(42, 65)
            Me.cobPrintLayouts.Name = "cobPrintLayouts"
            Me.cobPrintLayouts.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cobPrintLayouts.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.cobPrintLayouts.Size = New System.Drawing.Size(225, 20)
            Me.cobPrintLayouts.TabIndex = 2
            Me.cobPrintLayouts.Tag = "DontTranslate"
            '
            'chkPrintList
            '
            Me.chkPrintList.EditValue = True
            Me.chkPrintList.Location = New System.Drawing.Point(17, 13)
            Me.chkPrintList.Name = "chkPrintList"
            Me.chkPrintList.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintList.Properties.Appearance.Options.UseFont = True
            Me.chkPrintList.Properties.AutoWidth = True
            Me.chkPrintList.Properties.Caption = "Listendruck selektierter Elemente"
            Me.chkPrintList.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
            Me.chkPrintList.Properties.RadioGroupIndex = 1
            Me.chkPrintList.Size = New System.Drawing.Size(196, 20)
            Me.chkPrintList.TabIndex = 3
            '
            'chkPrintLayout
            '
            Me.chkPrintLayout.Location = New System.Drawing.Point(17, 39)
            Me.chkPrintLayout.Name = "chkPrintLayout"
            Me.chkPrintLayout.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintLayout.Properties.Appearance.Options.UseFont = True
            Me.chkPrintLayout.Properties.AutoWidth = True
            Me.chkPrintLayout.Properties.Caption = "Druck Layout wählen:"
            Me.chkPrintLayout.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio
            Me.chkPrintLayout.Properties.RadioGroupIndex = 1
            Me.chkPrintLayout.Size = New System.Drawing.Size(137, 20)
            Me.chkPrintLayout.TabIndex = 3
            Me.chkPrintLayout.TabStop = False
            '
            'PanelControl1
            '
            Me.PanelControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelControl1.Appearance.Options.UseBackColor = True
            Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
            Me.PanelControl1.Controls.Add(Me.chkPrintLayout)
            Me.PanelControl1.Controls.Add(Me.cobPrintLayouts)
            Me.PanelControl1.Controls.Add(Me.chkPrintList)
            Me.PanelControl1.Location = New System.Drawing.Point(12, 12)
            Me.PanelControl1.Name = "PanelControl1"
            Me.PanelControl1.Size = New System.Drawing.Size(272, 99)
            Me.PanelControl1.TabIndex = 4
            '
            'btnPreview
            '
            Me.btnPreview.Location = New System.Drawing.Point(128, 117)
            Me.btnPreview.Name = "btnPreview"
            Me.btnPreview.Size = New System.Drawing.Size(75, 23)
            Me.btnPreview.TabIndex = 4
            Me.btnPreview.Text = "Vorschau"
            '
            'dlgSimplePrinting
            '
            Me.AcceptButton = Me.cmdPrint
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.cmdClose
            Me.ClientSize = New System.Drawing.Size(296, 152)
            Me.Controls.Add(Me.btnPreview)
            Me.Controls.Add(Me.PanelControl1)
            Me.Controls.Add(Me.cmdPrint)
            Me.Controls.Add(Me.cmdClose)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "dlgSimplePrinting"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Drucken..."
            CType(Me.cobPrintLayouts.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkPrintList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkPrintLayout.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents cmdPrint As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents cobPrintLayouts As DevExpress.XtraEditors.ComboBoxEdit
        Friend WithEvents chkPrintList As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents chkPrintLayout As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btnPreview As DevExpress.XtraEditors.SimpleButton
    End Class
End Namespace