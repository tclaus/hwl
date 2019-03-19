Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucOptionSimpleEdit
    Inherits ClausSoftware.HWLInterops.BaseControl

    'iucOptionSimpleEdit overrides dispose to clean up the component list.
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
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.UicCommonGrid1 = New ClausSoftware.HWLInterops.uicCommonGrid()
        Me.SuspendLayout()
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Location = New System.Drawing.Point(166, 196)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 5
        Me.btnNew.Text = "Neu"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(85, 196)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Löschen"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(247, 196)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Schliessen"
        '
        'UicCommonGrid1
        '
        Me.UicCommonGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UicCommonGrid1.BackColor = System.Drawing.SystemColors.Control
        Me.UicCommonGrid1.Context = Nothing
        Me.UicCommonGrid1.Editable = False
        Me.UicCommonGrid1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UicCommonGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UicCommonGrid1.Name = "UicCommonGrid1"
        Me.UicCommonGrid1.ShowFilterRow = False
        Me.UicCommonGrid1.Size = New System.Drawing.Size(328, 190)
        Me.UicCommonGrid1.TabIndex = 7
        '
        'iucOptionSimpleEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UicCommonGrid1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnDelete)
        Me.Name = "iucOptionSimpleEdit"
        Me.Size = New System.Drawing.Size(328, 222)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents UicCommonGrid1 As HWLInterops.uicCommonGrid

End Class
