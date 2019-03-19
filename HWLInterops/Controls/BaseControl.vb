
''' <summary>
''' Stellt das Basis control zur Verfügung
''' </summary>
''' <remarks></remarks>
Public Class BaseControl
    Inherits DevExpress.XtraEditors.XtraUserControl


    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'BaseControl
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Name = "BaseControl"
        Me.Size = New System.Drawing.Size(442, 296)
        Me.ResumeLayout(False)

    End Sub
End Class
