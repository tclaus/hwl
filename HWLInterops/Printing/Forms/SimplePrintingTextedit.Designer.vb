Namespace Printing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SimplePrintingTextedit
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
            Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
            Me.btnColor = New DevExpress.XtraEditors.SimpleButton()
            Me.btnFont = New DevExpress.XtraEditors.SimpleButton()
            Me.lblTexteditHeadline = New DevExpress.XtraEditors.LabelControl()
            Me.txtText = New DevExpress.XtraEditors.MemoEdit()
            Me.radTextAlign = New DevExpress.XtraEditors.RadioGroup()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.radTextAlign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.Location = New System.Drawing.Point(264, 235)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(87, 27)
            Me.btnOK.TabIndex = 0
            Me.btnOK.Text = "OK"
            '
            'btnColor
            '
            Me.btnColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnColor.Location = New System.Drawing.Point(108, 235)
            Me.btnColor.Name = "btnColor"
            Me.btnColor.Size = New System.Drawing.Size(87, 27)
            Me.btnColor.TabIndex = 0
            Me.btnColor.Text = "Farbe..."
            '
            'btnFont
            '
            Me.btnFont.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnFont.Location = New System.Drawing.Point(14, 235)
            Me.btnFont.Name = "btnFont"
            Me.btnFont.Size = New System.Drawing.Size(87, 27)
            Me.btnFont.TabIndex = 0
            Me.btnFont.Text = "Schrift..."
            '
            'lblTexteditHeadline
            '
            Me.lblTexteditHeadline.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTexteditHeadline.Appearance.Options.UseFont = True
            Me.lblTexteditHeadline.Location = New System.Drawing.Point(14, 14)
            Me.lblTexteditHeadline.Name = "lblTexteditHeadline"
            Me.lblTexteditHeadline.Size = New System.Drawing.Size(91, 15)
            Me.lblTexteditHeadline.TabIndex = 1
            Me.lblTexteditHeadline.Text = "Angezeigter Text:"
            '
            'txtText
            '
            Me.txtText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtText.Location = New System.Drawing.Point(14, 36)
            Me.txtText.Name = "txtText"
            Me.txtText.Size = New System.Drawing.Size(432, 122)
            Me.txtText.TabIndex = 2
            '
            'radTextAlign
            '
            Me.radTextAlign.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.radTextAlign.Location = New System.Drawing.Point(76, 3)
            Me.radTextAlign.Name = "radTextAlign"
            Me.radTextAlign.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.radTextAlign.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.radTextAlign.Properties.Appearance.Options.UseBackColor = True
            Me.radTextAlign.Properties.Appearance.Options.UseFont = True
            Me.radTextAlign.Properties.EnableFocusRect = True
            Me.radTextAlign.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
            Me.radTextAlign.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Links"), New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Zentriert"), New DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Rechts")})
            Me.radTextAlign.Size = New System.Drawing.Size(280, 30)
            Me.radTextAlign.TabIndex = 3
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.radTextAlign, 1, 0)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(14, 164)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(432, 53)
            Me.TableLayoutPanel1.TabIndex = 4
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Location = New System.Drawing.Point(358, 235)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(87, 27)
            Me.btnCancel.TabIndex = 0
            Me.btnCancel.Text = "Abbrechen"
            '
            'SimplePrintingTextedit
            '
            Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(460, 276)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.txtText)
            Me.Controls.Add(Me.lblTexteditHeadline)
            Me.Controls.Add(Me.btnFont)
            Me.Controls.Add(Me.btnColor)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(410, 273)
            Me.Name = "SimplePrintingTextedit"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Anzeigetext"
            CType(Me.txtText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.radTextAlign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnColor As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnFont As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents lblTexteditHeadline As DevExpress.XtraEditors.LabelControl
        Friend WithEvents txtText As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents radTextAlign As DevExpress.XtraEditors.RadioGroup
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    End Class
End Namespace