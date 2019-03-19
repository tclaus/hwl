<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModuleContainer
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
        Me.IucMainModule1 = New ClausSoftware.HWLInterops.iucMainModule()
        Me.SuspendLayout()
        '
        'IucMainModule1
        '
        Me.IucMainModule1.Appearance.BackColor = System.Drawing.Color.White
        Me.IucMainModule1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IucMainModule1.Appearance.Options.UseBackColor = True
        Me.IucMainModule1.Appearance.Options.UseFont = True
        Me.IucMainModule1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IucMainModule1.Location = New System.Drawing.Point(0, 0)
        Me.IucMainModule1.Name = "IucMainModule1"
        Me.IucMainModule1.Size = New System.Drawing.Size(425, 305)
        Me.IucMainModule1.TabIndex = 0
        '
        'frmModuleContainer
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 305)
        Me.Controls.Add(Me.IucMainModule1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModuleContainer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "frmModuleContainer"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IucMainModule1 As HWLInterops.iucMainModule
End Class
