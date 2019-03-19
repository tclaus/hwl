Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucSearchPanel
    Inherits ClausSoftware.HWLInterops.BaseControl

    'iucSearchPanel overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtSearchText = New DevExpress.XtraEditors.ButtonEdit()
        CType(Me.txtSearchText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'txtSearchText
        '
        Me.txtSearchText.AllowDrop = True
        Me.txtSearchText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearchText.EditValue = ""
        Me.txtSearchText.Location = New System.Drawing.Point(0, 0)
        Me.txtSearchText.Margin = New System.Windows.Forms.Padding(0)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchText.Properties.Appearance.Options.UseFont = True
        Me.txtSearchText.Properties.AutoHeight = False
        Me.txtSearchText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txtSearchText.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtSearchText.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.txtSearchText.Properties.NullValuePrompt = "Suche nach..."
        Me.txtSearchText.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtSearchText.Size = New System.Drawing.Size(222, 20)
        Me.txtSearchText.TabIndex = 4
        '
        'iucSearchPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.Controls.Add(Me.txtSearchText)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "iucSearchPanel"
        Me.Size = New System.Drawing.Size(222, 20)
        CType(Me.txtSearchText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtSearchText As DevExpress.XtraEditors.ButtonEdit

End Class
