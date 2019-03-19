<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRTFItemDescriptionEdit
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
        Me.rtfMemoTextControl = New DevExpress.XtraRichEdit.RichEditControl()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(399, 235)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(318, 235)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 25)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        '
        'rtfMemoTextControl
        '
        Me.rtfMemoTextControl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple
        Me.rtfMemoTextControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtfMemoTextControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.rtfMemoTextControl.Location = New System.Drawing.Point(0, 0)
        Me.rtfMemoTextControl.Name = "rtfMemoTextControl"
        Me.rtfMemoTextControl.Options.Behavior.CreateNew = DevExpress.XtraRichEdit.DocumentCapability.Hidden
        Me.rtfMemoTextControl.Options.Behavior.FontSource = DevExpress.XtraRichEdit.RichEditBaseValueSource.Control
        Me.rtfMemoTextControl.Options.Behavior.Open = DevExpress.XtraRichEdit.DocumentCapability.Hidden
        Me.rtfMemoTextControl.Options.Bookmarks.Visibility = DevExpress.XtraRichEdit.RichEditBookmarkVisibility.Hidden
        Me.rtfMemoTextControl.Options.DocumentCapabilities.Bookmarks = DevExpress.XtraRichEdit.DocumentCapability.Hidden
        Me.rtfMemoTextControl.Size = New System.Drawing.Size(484, 218)
        Me.rtfMemoTextControl.TabIndex = 2
        Me.rtfMemoTextControl.Tag = "DontTranslate"
        '
        'frmRTFItemDescriptionEdit
        '
        Me.Appearance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(486, 272)
        Me.Controls.Add(Me.rtfMemoTextControl)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.MinimumSize = New System.Drawing.Size(434, 282)
        Me.Name = "frmRTFItemDescriptionEdit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Langtext"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Private WithEvents btnOk As DevExpress.XtraEditors.SimpleButton
    Private WithEvents rtfMemoTextControl As DevExpress.XtraRichEdit.RichEditControl
End Class
