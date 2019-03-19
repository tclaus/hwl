<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWaitForFileCopy
    Inherits ClausSoftware.HWLInterops.BaseForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lblFile = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LoadingCircle1 = New HWLInterops.MRG.Controls.UI.LoadingCircle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFile
        '
        Me.lblFile.Location = New System.Drawing.Point(81, 21)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(249, 16)
        Me.lblFile.TabIndex = 1
        Me.lblFile.Text = "Datei"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'LoadingCircle1
        '
        Me.LoadingCircle1.Active = True
        Me.LoadingCircle1.Color = System.Drawing.Color.DarkGray
        Me.LoadingCircle1.InnerCircleRadius = 8
        Me.LoadingCircle1.Location = New System.Drawing.Point(12, 12)
        Me.LoadingCircle1.Name = "LoadingCircle1"
        Me.LoadingCircle1.NumberSpoke = 10
        Me.LoadingCircle1.OuterCircleRadius = 10
        Me.LoadingCircle1.RotationSpeed = 100
        Me.LoadingCircle1.Size = New System.Drawing.Size(48, 28)
        Me.LoadingCircle1.SpokeThickness = 4
        Me.LoadingCircle1.StylePreset = HWLInterops.MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX
        Me.LoadingCircle1.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblFile)
        Me.Panel1.Controls.Add(Me.LoadingCircle1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(351, 61)
        Me.Panel1.TabIndex = 3
        '
        'frmWaitForFileCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 61)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmWaitForFileCopy"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Kopiere..."
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents LoadingCircle1 As HWLInterops.MRG.Controls.UI.LoadingCircle
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
