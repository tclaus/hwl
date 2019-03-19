
''' <summary>
''' Beschreibt die Basisklasse für Formulare
''' </summary>
''' <remarks></remarks>
Public Class BaseForm
    Inherits DevExpress.XtraEditors.XtraForm

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'BaseForm
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Name = "BaseForm"
        Me.ResumeLayout(False)

    End Sub

    Private Sub BaseForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If m_application IsNot Nothing Then
            m_application.Languages.SetTextOnControl(Me)

        End If

    End Sub
End Class
