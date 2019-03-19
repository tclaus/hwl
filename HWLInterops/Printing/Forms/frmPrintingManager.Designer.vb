Namespace Printing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmPrintingManager
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
            Me.iucPrintingManager = New ClausSoftware.HWLInterops.Printing.iucPrintingManager()
            Me.SuspendLayout()
            '
            'iucPrintingManager
            '
            Me.iucPrintingManager.ActiveReport = Nothing
            Me.iucPrintingManager.BusinessLetterLocked = False
            Me.iucPrintingManager.Dock = System.Windows.Forms.DockStyle.Fill
            Me.iucPrintingManager.Location = New System.Drawing.Point(0, 0)
            Me.iucPrintingManager.Name = "iucPrintingManager"
            Me.iucPrintingManager.ReportDatasourceType = ClausSoftware.Kernel.DataSourceList.None
            Me.iucPrintingManager.ShowBuisinesLayout = False
            Me.iucPrintingManager.Size = New System.Drawing.Size(763, 593)
            Me.iucPrintingManager.TabIndex = 0
            '
            'frmPrintingManager
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(763, 593)
            Me.Controls.Add(Me.iucPrintingManager)
            Me.Name = "frmPrintingManager"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "Drucklayout"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents iucPrintingManager As Printing.iucPrintingManager


    End Class
End Namespace