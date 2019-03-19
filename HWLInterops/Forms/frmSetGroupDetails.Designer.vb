<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetGroupDetails
    Inherits ClausSoftware.HWLInterops.BaseForm

    'Form overrides dispose to clean up the component list.
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
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.lblGroupDetailHeadline = New DevExpress.XtraEditors.LabelControl()
        Me.txtGroupDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.picGroupPicture = New DevExpress.XtraEditors.PictureEdit()
        Me.txtGroupName = New DevExpress.XtraEditors.TextEdit()
        Me.lblGroupName = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.txtGroupDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGroupPicture.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroupName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Appearance.Options.UseFont = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(307, 207)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Appearance.Options.UseFont = True
        Me.btnOK.Location = New System.Drawing.Point(226, 207)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        '
        'lblGroupDetailHeadline
        '
        Me.lblGroupDetailHeadline.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGroupDetailHeadline.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupDetailHeadline.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblGroupDetailHeadline.Appearance.Options.UseFont = True
        Me.lblGroupDetailHeadline.Appearance.Options.UseForeColor = True
        Me.lblGroupDetailHeadline.Appearance.Options.UseTextOptions = True
        Me.lblGroupDetailHeadline.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lblGroupDetailHeadline.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblGroupDetailHeadline.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblGroupDetailHeadline.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblGroupDetailHeadline.Location = New System.Drawing.Point(12, 10)
        Me.lblGroupDetailHeadline.Name = "lblGroupDetailHeadline"
        Me.lblGroupDetailHeadline.Size = New System.Drawing.Size(375, 33)
        Me.lblGroupDetailHeadline.TabIndex = 1
        Me.lblGroupDetailHeadline.Text = "Name und Beschreibung der Gruppe"
        '
        'txtGroupDescription
        '
        Me.txtGroupDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGroupDescription.Location = New System.Drawing.Point(127, 31)
        Me.txtGroupDescription.Name = "txtGroupDescription"
        Me.txtGroupDescription.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupDescription.Properties.Appearance.Options.UseFont = True
        Me.txtGroupDescription.Properties.MaxLength = 250
        Me.txtGroupDescription.Size = New System.Drawing.Size(248, 118)
        Me.txtGroupDescription.TabIndex = 2
        '
        'picGroupPicture
        '
        Me.picGroupPicture.Location = New System.Drawing.Point(3, 31)
        Me.picGroupPicture.Name = "picGroupPicture"
        Me.picGroupPicture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.picGroupPicture.Size = New System.Drawing.Size(118, 88)
        Me.picGroupPicture.TabIndex = 3
        '
        'txtGroupName
        '
        Me.txtGroupName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGroupName.Location = New System.Drawing.Point(127, 3)
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupName.Properties.Appearance.Options.UseFont = True
        Me.txtGroupName.Properties.MaxLength = 250
        Me.txtGroupName.Size = New System.Drawing.Size(248, 22)
        Me.txtGroupName.TabIndex = 4
        '
        'lblGroupName
        '
        Me.lblGroupName.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupName.Appearance.Options.UseFont = True
        Me.lblGroupName.Location = New System.Drawing.Point(3, 3)
        Me.lblGroupName.Name = "lblGroupName"
        Me.lblGroupName.Size = New System.Drawing.Size(79, 15)
        Me.lblGroupName.TabIndex = 5
        Me.lblGroupName.Text = "Gruppenname:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtGroupName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblGroupName, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtGroupDescription, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.picGroupPicture, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 49)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(378, 152)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'frmSetGroupDetails
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 242)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblGroupDetailHeadline)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(410, 280)
        Me.Name = "frmSetGroupDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gruppendetails festlegen"
        CType(Me.txtGroupDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGroupPicture.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroupName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblGroupDetailHeadline As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtGroupDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents picGroupPicture As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtGroupName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblGroupName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
