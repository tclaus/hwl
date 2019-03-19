<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSimpleEdit
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
        Me.SimpleEdit = New ClausSoftware.HWLInterops.iucOptionSimpleEdit
        Me.SuspendLayout()
        '
        'SimpleEdit
        '
        Me.SimpleEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.SimpleEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimpleEdit.ForeColor = System.Drawing.Color.Black
        Me.SimpleEdit.Location = New System.Drawing.Point(0, 0)
        Me.SimpleEdit.Name = "SimpleEdit"
        Me.SimpleEdit.Size = New System.Drawing.Size(319, 265)
        Me.SimpleEdit.TabIndex = 0
        '
        'frmSimpleEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 265)
        Me.Controls.Add(Me.SimpleEdit)
        Me.MinimumSize = New System.Drawing.Size(335, 303)
        Me.Name = "frmSimpleEdit"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Listen bearbeiten"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SimpleEdit As HWLInterops.iucOptionSimpleEdit
End Class
