Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucMainModule
    Inherits mainControlContainer

    'iucMainModule overrides dispose to clean up the component list.
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlButtonsCollection = New System.Windows.Forms.FlowLayoutPanel
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel1.Size = New System.Drawing.Size(756, 500)
        Me.Panel1.TabIndex = 0
        '
        'pnlButtonsCollection
        '
        Me.pnlButtonsCollection.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtonsCollection.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.pnlButtonsCollection.Location = New System.Drawing.Point(0, 500)
        Me.pnlButtonsCollection.Name = "pnlButtonsCollection"
        Me.pnlButtonsCollection.Size = New System.Drawing.Size(756, 47)
        Me.pnlButtonsCollection.TabIndex = 1
        '
        'iucMainModule
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlButtonsCollection)
        Me.Name = "iucMainModule"
        Me.Size = New System.Drawing.Size(756, 547)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlButtonsCollection As System.Windows.Forms.FlowLayoutPanel

End Class
