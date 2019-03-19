Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucTemplates
    Inherits mainControlContainer

    'iucTemplates overrides dispose to clean up the component list.
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
        Me.IucGroupsGrid1 = New ClausSoftware.HWLInterops.iucGroupsGrid
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl
        Me.trvTemplates = New DevExpress.XtraTreeList.TreeList
        Me.trvTemplateData = New DevExpress.XtraTreeList.TreeList
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.trvTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trvTemplateData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IucGroupsGrid1
        '
        Me.IucGroupsGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IucGroupsGrid1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IucGroupsGrid1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IucGroupsGrid1.Appearance.Options.UseFont = True
        Me.IucGroupsGrid1.Appearance.Options.UseForeColor = True
        Me.IucGroupsGrid1.Context = "MainArticleGrid"
        Me.IucGroupsGrid1.Location = New System.Drawing.Point(-2, 42)
        Me.IucGroupsGrid1.Name = "IucGroupsGrid1"
        Me.IucGroupsGrid1.SelectedArticelID = ""
        Me.IucGroupsGrid1.SelectedGroupID = ""
        Me.IucGroupsGrid1.ShowFilterRow = False
        Me.IucGroupsGrid1.Size = New System.Drawing.Size(841, 198)
        Me.IucGroupsGrid1.TabIndex = 0
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SimpleButton1)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.IucGroupsGrid1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(983, 615)
        Me.SplitContainerControl1.SplitterPosition = 280
        Me.SplitContainerControl1.TabIndex = 1
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.trvTemplates)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.trvTemplateData)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(1137, 318)
        Me.SplitContainerControl2.SplitterPosition = 191
        Me.SplitContainerControl2.TabIndex = 0
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'trvTemplates
        '
        Me.trvTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvTemplates.Location = New System.Drawing.Point(-2, -2)
        Me.trvTemplates.Name = "trvTemplates"
        Me.trvTemplates.OptionsBehavior.Editable = False
        Me.trvTemplates.OptionsView.ShowColumns = False
        Me.trvTemplates.OptionsView.ShowIndicator = False
        Me.trvTemplates.Size = New System.Drawing.Size(131, 233)
        Me.trvTemplates.TabIndex = 0
        '
        'trvTemplateData
        '
        Me.trvTemplateData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvTemplateData.Location = New System.Drawing.Point(-3, 1)
        Me.trvTemplateData.Name = "trvTemplateData"
        Me.trvTemplateData.Size = New System.Drawing.Size(705, 229)
        Me.trvTemplateData.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(304, 8)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(87, 27)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "Initialize"
        '
        'iucTemplates
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "iucTemplates"
        Me.Size = New System.Drawing.Size(983, 615)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.trvTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trvTemplateData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IucGroupsGrid1 As HWLInterops.iucGroupsGrid
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents trvTemplates As DevExpress.XtraTreeList.TreeList
    Friend WithEvents trvTemplateData As DevExpress.XtraTreeList.TreeList
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton

End Class
