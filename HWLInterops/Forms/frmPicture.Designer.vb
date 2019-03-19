<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPicture
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblDescriptionValue = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblnameValue = New System.Windows.Forms.Label
        Me.lbldateValue = New System.Windows.Forms.Label
        Me.lblSizeValue = New System.Windows.Forms.Label
        Me.lblImageSize = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.picImage = New DevExpress.XtraEditors.PictureEdit
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblDescriptionValue)
        Me.Panel1.Controls.Add(Me.lblDescription)
        Me.Panel1.Controls.Add(Me.lblnameValue)
        Me.Panel1.Controls.Add(Me.lbldateValue)
        Me.Panel1.Controls.Add(Me.lblSizeValue)
        Me.Panel1.Controls.Add(Me.lblImageSize)
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 285)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(420, 73)
        Me.Panel1.TabIndex = 1
        '
        'lblDescriptionValue
        '
        Me.lblDescriptionValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDescriptionValue.AutoEllipsis = True
        Me.lblDescriptionValue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescriptionValue.Location = New System.Drawing.Point(99, 56)
        Me.lblDescriptionValue.Name = "lblDescriptionValue"
        Me.lblDescriptionValue.Size = New System.Drawing.Size(102, 13)
        Me.lblDescriptionValue.TabIndex = 11
        Me.lblDescriptionValue.Tag = "DontTranslate"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDescription.Location = New System.Drawing.Point(6, 56)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(87, 17)
        Me.lblDescription.TabIndex = 10
        Me.lblDescription.Text = "Beschreibung:"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblnameValue
        '
        Me.lblnameValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblnameValue.AutoEllipsis = True
        Me.lblnameValue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnameValue.Location = New System.Drawing.Point(99, 3)
        Me.lblnameValue.Name = "lblnameValue"
        Me.lblnameValue.Size = New System.Drawing.Size(102, 13)
        Me.lblnameValue.TabIndex = 7
        Me.lblnameValue.Tag = "DontTranslate"
        '
        'lbldateValue
        '
        Me.lbldateValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbldateValue.AutoEllipsis = True
        Me.lbldateValue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldateValue.Location = New System.Drawing.Point(99, 30)
        Me.lbldateValue.Name = "lbldateValue"
        Me.lbldateValue.Size = New System.Drawing.Size(102, 13)
        Me.lbldateValue.TabIndex = 8
        Me.lbldateValue.Tag = "DontTranslate"
        '
        'lblSizeValue
        '
        Me.lblSizeValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSizeValue.AutoEllipsis = True
        Me.lblSizeValue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSizeValue.Location = New System.Drawing.Point(303, 3)
        Me.lblSizeValue.Name = "lblSizeValue"
        Me.lblSizeValue.Size = New System.Drawing.Size(113, 13)
        Me.lblSizeValue.TabIndex = 9
        Me.lblSizeValue.Tag = "DontTranslate"
        '
        'lblImageSize
        '
        Me.lblImageSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblImageSize.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImageSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblImageSize.Location = New System.Drawing.Point(211, 3)
        Me.lblImageSize.Name = "lblImageSize"
        Me.lblImageSize.Size = New System.Drawing.Size(86, 17)
        Me.lblImageSize.TabIndex = 4
        Me.lblImageSize.Text = "Abmessungen:"
        Me.lblImageSize.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDate.Location = New System.Drawing.Point(6, 30)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(87, 17)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "Datum:"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblName
        '
        Me.lblName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(6, 3)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(87, 17)
        Me.lblName.TabIndex = 6
        Me.lblName.Text = "Name:"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpeichernUnterToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(167, 26)
        '
        'SpeichernUnterToolStripMenuItem
        '
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter..."
        '
        'picImage
        '
        Me.picImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picImage.EditValue = Global.ClausSoftware.HWLInterops.My.Resources.Resources.no_picture
        Me.picImage.Location = New System.Drawing.Point(0, 0)
        Me.picImage.Name = "picImage"
        Me.picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.picImage.Size = New System.Drawing.Size(420, 285)
        Me.picImage.TabIndex = 2
        '
        'frmPicture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 358)
        Me.Controls.Add(Me.picImage)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPicture"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bild"
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.picImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblnameValue As System.Windows.Forms.Label
    Friend WithEvents lbldateValue As System.Windows.Forms.Label
    Friend WithEvents lblSizeValue As System.Windows.Forms.Label
    Friend WithEvents lblImageSize As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SpeichernUnterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblDescriptionValue As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents picImage As DevExpress.XtraEditors.PictureEdit
End Class
