Namespace Offers
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmeditItemsDescription
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
            Me.txtmemo = New DevExpress.XtraEditors.MemoEdit()
            Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
            Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.txtmemo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtmemo
            '
            Me.txtmemo.AllowDrop = True
            Me.txtmemo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtmemo.Location = New System.Drawing.Point(0, 0)
            Me.txtmemo.Name = "txtmemo"
            Me.txtmemo.Size = New System.Drawing.Size(324, 109)
            Me.txtmemo.TabIndex = 0
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.Location = New System.Drawing.Point(131, 115)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(87, 27)
            Me.btnOK.TabIndex = 1
            Me.btnOK.Text = "OK"
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Location = New System.Drawing.Point(225, 115)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(87, 27)
            Me.btnCancel.TabIndex = 1
            Me.btnCancel.Text = "Abbrechen"
            '
            'frmeditItemsDescription
            '
            Me.AcceptButton = Me.btnOK
            Me.AccessibleDescription = "Langtext der Position"
            Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(323, 149)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.txtmemo)
            Me.MinimumSize = New System.Drawing.Size(339, 187)
            Me.Name = "frmeditItemsDescription"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Langetxt (-Artikel-)"
            CType(Me.txtmemo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents txtmemo As DevExpress.XtraEditors.MemoEdit
        Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    End Class
End Namespace
