<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TodayBar
    Inherits ClausSoftware.HWLInterops.BaseControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTodaysTasks = New DevExpress.XtraEditors.LabelControl()
        Me.clbTasks = New DevExpress.XtraEditors.CheckedListBoxControl()
        Me.lblTodayBarHeadline = New DevExpress.XtraEditors.LabelControl()
        Me.lstAppointments = New DevExpress.XtraEditors.ListBoxControl()
        Me.lblTodayAppointments = New DevExpress.XtraEditors.LabelControl()
        Me.picCloseModule = New DevExpress.XtraEditors.PictureEdit()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.clbTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstAppointments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCloseModule.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTodaysTasks
        '
        Me.lblTodaysTasks.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTodaysTasks.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodaysTasks.Appearance.Options.UseBackColor = True
        Me.lblTodaysTasks.Appearance.Options.UseFont = True
        Me.lblTodaysTasks.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblTodaysTasks.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTodaysTasks.Location = New System.Drawing.Point(0, 0)
        Me.lblTodaysTasks.Name = "lblTodaysTasks"
        Me.lblTodaysTasks.Padding = New System.Windows.Forms.Padding(5, 2, 2, 2)
        Me.lblTodaysTasks.Size = New System.Drawing.Size(166, 19)
        Me.lblTodaysTasks.TabIndex = 2
        Me.lblTodaysTasks.Text = "Aufgaben"
        '
        'clbTasks
        '
        Me.clbTasks.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbTasks.Appearance.Options.UseFont = True
        Me.clbTasks.Appearance.Options.UseTextOptions = True
        Me.clbTasks.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.clbTasks.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.clbTasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clbTasks.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned
        Me.clbTasks.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick
        Me.clbTasks.ItemHeight = 30
        Me.clbTasks.Location = New System.Drawing.Point(0, 19)
        Me.clbTasks.Name = "clbTasks"
        Me.clbTasks.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.clbTasks.Size = New System.Drawing.Size(166, 188)
        Me.clbTasks.TabIndex = 1
        '
        'lblTodayBarHeadline
        '
        Me.lblTodayBarHeadline.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.lblTodayBarHeadline.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblTodayBarHeadline.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.lblTodayBarHeadline.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodayBarHeadline.Appearance.ForeColor = System.Drawing.Color.Black
        Me.lblTodayBarHeadline.Appearance.Options.UseBackColor = True
        Me.lblTodayBarHeadline.Appearance.Options.UseBorderColor = True
        Me.lblTodayBarHeadline.Appearance.Options.UseFont = True
        Me.lblTodayBarHeadline.Appearance.Options.UseForeColor = True
        Me.lblTodayBarHeadline.Appearance.Options.UseTextOptions = True
        Me.lblTodayBarHeadline.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.lblTodayBarHeadline.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTodayBarHeadline.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTodayBarHeadline.Location = New System.Drawing.Point(0, 0)
        Me.lblTodayBarHeadline.Name = "lblTodayBarHeadline"
        Me.lblTodayBarHeadline.Padding = New System.Windows.Forms.Padding(20, 3, 0, 3)
        Me.lblTodayBarHeadline.Size = New System.Drawing.Size(498, 30)
        Me.lblTodayBarHeadline.TabIndex = 0
        Me.lblTodayBarHeadline.Tag = "donttranslate"
        Me.lblTodayBarHeadline.Text = "HWL Heute (21.05.2010)"
        '
        'lstAppointments
        '
        Me.lstAppointments.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAppointments.Appearance.Options.UseFont = True
        Me.lstAppointments.Appearance.Options.UseTextOptions = True
        Me.lstAppointments.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lstAppointments.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.lstAppointments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstAppointments.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned
        Me.lstAppointments.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick
        Me.lstAppointments.ItemHeight = 30
        Me.lstAppointments.Location = New System.Drawing.Point(0, 19)
        Me.lstAppointments.Name = "lstAppointments"
        Me.lstAppointments.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lstAppointments.Size = New System.Drawing.Size(173, 188)
        Me.lstAppointments.TabIndex = 3
        '
        'lblTodayAppointments
        '
        Me.lblTodayAppointments.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblTodayAppointments.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodayAppointments.Appearance.Options.UseBackColor = True
        Me.lblTodayAppointments.Appearance.Options.UseFont = True
        Me.lblTodayAppointments.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTodayAppointments.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTodayAppointments.Location = New System.Drawing.Point(0, 0)
        Me.lblTodayAppointments.Name = "lblTodayAppointments"
        Me.lblTodayAppointments.Padding = New System.Windows.Forms.Padding(5, 2, 2, 2)
        Me.lblTodayAppointments.Size = New System.Drawing.Size(173, 19)
        Me.lblTodayAppointments.TabIndex = 4
        Me.lblTodayAppointments.Text = "Termine"
        '
        'picCloseModule
        '
        Me.picCloseModule.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCloseModule.EditValue = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Close_16x16
        Me.picCloseModule.Location = New System.Drawing.Point(474, 3)
        Me.picCloseModule.Name = "picCloseModule"
        Me.picCloseModule.Properties.AllowFocused = False
        Me.picCloseModule.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.picCloseModule.Properties.Appearance.Options.UseBackColor = True
        Me.picCloseModule.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picCloseModule.Properties.ReadOnly = True
        Me.picCloseModule.Properties.ShowMenu = False
        Me.picCloseModule.Size = New System.Drawing.Size(25, 27)
        Me.picCloseModule.TabIndex = 6
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 30)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(498, 213)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.clbTasks)
        Me.Panel1.Controls.Add(Me.lblTodaysTasks)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 207)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lstAppointments)
        Me.Panel2.Controls.Add(Me.lblTodayAppointments)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(175, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(173, 207)
        Me.Panel2.TabIndex = 1
        '
        'TodayBar
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.picCloseModule)
        Me.Controls.Add(Me.lblTodayBarHeadline)
        Me.Name = "TodayBar"
        Me.Size = New System.Drawing.Size(498, 243)
        CType(Me.clbTasks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstAppointments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCloseModule.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTodayBarHeadline As DevExpress.XtraEditors.LabelControl
    Friend WithEvents clbTasks As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents lblTodaysTasks As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lstAppointments As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lblTodayAppointments As DevExpress.XtraEditors.LabelControl
    Friend WithEvents picCloseModule As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class
