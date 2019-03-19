<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucTasks
    Inherits mainControlContainer

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.components = New System.ComponentModel.Container()
        Me.cmsDefault = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuNewItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TasksGrid = New ClausSoftware.HWLInterops.uicCommonGrid()
        Me.cmsDefault.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsDefault
        '
        Me.cmsDefault.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewItem, Me.mnuDeleteItem})
        Me.cmsDefault.Name = "ContextMenuStrip1"
        Me.cmsDefault.Size = New System.Drawing.Size(142, 48)
        '
        'mnuNewItem
        '
        Me.mnuNewItem.Name = "mnuNewItem"
        Me.mnuNewItem.Size = New System.Drawing.Size(141, 22)
        Me.mnuNewItem.Text = "Neu anlegen"
        '
        'mnuDeleteItem
        '
        Me.mnuDeleteItem.Name = "mnuDeleteItem"
        Me.mnuDeleteItem.Size = New System.Drawing.Size(141, 22)
        Me.mnuDeleteItem.Text = "Löschen"
        '
        'TasksGrid
        '
        Me.TasksGrid.AllowNewRow = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.TasksGrid.BackColor = System.Drawing.SystemColors.Control
        Me.TasksGrid.Context = Nothing
        Me.TasksGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TasksGrid.Editable = False
        Me.TasksGrid.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TasksGrid.Location = New System.Drawing.Point(0, 0)
        Me.TasksGrid.Name = "TasksGrid"
        Me.TasksGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.TasksGrid.ShowFilterRow = False
        Me.TasksGrid.Size = New System.Drawing.Size(589, 306)
        Me.TasksGrid.TabIndex = 0
        '
        'iucTasks
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TasksGrid)
        Me.Name = "iucTasks"
        Me.Size = New System.Drawing.Size(589, 306)
        Me.cmsDefault.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TasksGrid As HWLInterops.uicCommonGrid
    Friend WithEvents cmsDefault As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuNewItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteItem As System.Windows.Forms.ToolStripMenuItem

End Class
