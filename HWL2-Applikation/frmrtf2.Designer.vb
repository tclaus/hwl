﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmrtf2
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
        Me.Iucnotepadmain1 = New HWLInterops.iucLetters
        Me.SuspendLayout()
        '
        'Iucnotepadmain1
        '
        Me.Iucnotepadmain1.BackColor = System.Drawing.SystemColors.Control

        Me.Iucnotepadmain1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Iucnotepadmain1.ForeColor = System.Drawing.SystemColors.ControlText

        Me.Iucnotepadmain1.Location = New System.Drawing.Point(0, 0)
        Me.Iucnotepadmain1.Name = "Iucnotepadmain1"
        Me.Iucnotepadmain1.Size = New System.Drawing.Size(785, 519)
        Me.Iucnotepadmain1.TabIndex = 0
        '
        'frmrtf2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 519)
        Me.Controls.Add(Me.Iucnotepadmain1)
        Me.Name = "frmrtf2"
        Me.Text = "frmdrt2"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Iucnotepadmain1 As HWLInterops.iucLetters
End Class
