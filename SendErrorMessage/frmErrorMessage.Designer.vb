<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErrorMessage
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmErrorMessage))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.lblerrorreportHeadline = New System.Windows.Forms.Label()
        Me.btnSendMessage = New System.Windows.Forms.Button()
        Me.txtMailAddres = New DevExpress.XtraEditors.TextEdit()
        Me.lblOptionalMailAddress = New DevExpress.XtraEditors.LabelControl()
        Me.lblOptionalMailNote = New DevExpress.XtraEditors.LabelControl()
        Me.lblSendeErrorMessageUsersNotice = New DevExpress.XtraEditors.LabelControl()
        Me.txtUserMessage = New DevExpress.XtraEditors.MemoExEdit()
        Me.lblErrorDescription = New DevExpress.XtraEditors.LabelControl()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtErrorMessage = New DevExpress.XtraEditors.MemoEdit()
        Me.lblUpdateWebSite = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtMailAddres.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserMessage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtErrorMessage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(479, 159)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Schliessen"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnRestart
        '
        Me.btnRestart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestart.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestart.Location = New System.Drawing.Point(398, 159)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(75, 23)
        Me.btnRestart.TabIndex = 0
        Me.btnRestart.Text = "Neustarten"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'lblerrorreportHeadline
        '
        Me.lblerrorreportHeadline.AutoSize = True
        Me.lblerrorreportHeadline.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblerrorreportHeadline.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblerrorreportHeadline.Location = New System.Drawing.Point(12, 9)
        Me.lblerrorreportHeadline.Name = "lblerrorreportHeadline"
        Me.lblerrorreportHeadline.Size = New System.Drawing.Size(469, 18)
        Me.lblerrorreportHeadline.TabIndex = 1
        Me.lblerrorreportHeadline.Text = "Es ist ein Problem aufgetreten, das Programm muss beendet werden. "
        '
        'btnSendMessage
        '
        Me.btnSendMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendMessage.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendMessage.Image = CType(resources.GetObject("btnSendMessage.Image"), System.Drawing.Image)
        Me.btnSendMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSendMessage.Location = New System.Drawing.Point(398, 115)
        Me.btnSendMessage.Name = "btnSendMessage"
        Me.btnSendMessage.Size = New System.Drawing.Size(156, 35)
        Me.btnSendMessage.TabIndex = 3
        Me.btnSendMessage.Text = "Fehlerbericht senden"
        Me.btnSendMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSendMessage.UseVisualStyleBackColor = True
        '
        'txtMailAddres
        '
        Me.txtMailAddres.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMailAddres.Location = New System.Drawing.Point(181, 130)
        Me.txtMailAddres.Name = "txtMailAddres"
        Me.txtMailAddres.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMailAddres.Properties.Appearance.Options.UseFont = True
        Me.txtMailAddres.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None
        Me.txtMailAddres.Properties.Mask.EditMask = "[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2}"
        Me.txtMailAddres.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        Me.txtMailAddres.Properties.Mask.ShowPlaceHolders = False
        Me.txtMailAddres.Size = New System.Drawing.Size(205, 22)
        Me.txtMailAddres.TabIndex = 4
        Me.txtMailAddres.ToolTip = "Wenn Sie uns ihre Nachrichtenadresse hinterlassen, können wir zu Ihnen Kontakt au" & _
    "fnehmen um den Fehler weiter bestimmen zu können. "
        '
        'lblOptionalMailAddress
        '
        Me.lblOptionalMailAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOptionalMailAddress.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionalMailAddress.Appearance.Options.UseFont = True
        Me.lblOptionalMailAddress.Location = New System.Drawing.Point(8, 137)
        Me.lblOptionalMailAddress.Name = "lblOptionalMailAddress"
        Me.lblOptionalMailAddress.Size = New System.Drawing.Size(156, 15)
        Me.lblOptionalMailAddress.TabIndex = 5
        Me.lblOptionalMailAddress.Text = "Mail-Adresse für Rückfragen: "
        '
        'lblOptionalMailNote
        '
        Me.lblOptionalMailNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOptionalMailNote.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionalMailNote.Appearance.Options.UseFont = True
        Me.lblOptionalMailNote.Location = New System.Drawing.Point(53, 156)
        Me.lblOptionalMailNote.Name = "lblOptionalMailNote"
        Me.lblOptionalMailNote.Size = New System.Drawing.Size(108, 15)
        Me.lblOptionalMailNote.TabIndex = 6
        Me.lblOptionalMailNote.Text = "(Freiwillige Angabe.)"
        '
        'lblSendeErrorMessageUsersNotice
        '
        Me.lblSendeErrorMessageUsersNotice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSendeErrorMessageUsersNotice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblSendeErrorMessageUsersNotice.Location = New System.Drawing.Point(15, 33)
        Me.lblSendeErrorMessageUsersNotice.Name = "lblSendeErrorMessageUsersNotice"
        Me.lblSendeErrorMessageUsersNotice.Size = New System.Drawing.Size(539, 52)
        Me.lblSendeErrorMessageUsersNotice.TabIndex = 7
        Me.lblSendeErrorMessageUsersNotice.Text = resources.GetString("lblSendeErrorMessageUsersNotice.Text")
        '
        'txtUserMessage
        '
        Me.txtUserMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUserMessage.EditValue = ""
        Me.txtUserMessage.Location = New System.Drawing.Point(181, 105)
        Me.txtUserMessage.Name = "txtUserMessage"
        Me.txtUserMessage.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserMessage.Properties.Appearance.Options.UseFont = True
        Me.txtUserMessage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtUserMessage.Properties.NullText = "Weitere Fehlerinformationen eingeben."
        Me.txtUserMessage.Properties.NullValuePrompt = "Weitere Fehlerinformationen eingeben."
        Me.txtUserMessage.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtUserMessage.Properties.ShowIcon = False
        Me.txtUserMessage.Size = New System.Drawing.Size(205, 22)
        Me.txtUserMessage.TabIndex = 8
        Me.txtUserMessage.ToolTip = "Geben Sie uns weitere Hinweise zum Auftreten des Fehlers."
        '
        'lblErrorDescription
        '
        Me.lblErrorDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblErrorDescription.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorDescription.Appearance.Options.UseFont = True
        Me.lblErrorDescription.Location = New System.Drawing.Point(8, 110)
        Me.lblErrorDescription.Name = "lblErrorDescription"
        Me.lblErrorDescription.Size = New System.Drawing.Size(112, 15)
        Me.lblErrorDescription.TabIndex = 9
        Me.lblErrorDescription.Text = "Hinweise zum Fehler:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'txtErrorMessage
        '
        Me.txtErrorMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErrorMessage.Location = New System.Drawing.Point(15, 103)
        Me.txtErrorMessage.Name = "txtErrorMessage"
        Me.txtErrorMessage.Properties.AllowFocused = False
        Me.txtErrorMessage.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.txtErrorMessage.Properties.Appearance.Options.UseBackColor = True
        Me.txtErrorMessage.Properties.ReadOnly = True
        Me.txtErrorMessage.Size = New System.Drawing.Size(539, 0)
        Me.txtErrorMessage.TabIndex = 10
        '
        'lblUpdateWebSite
        '
        Me.lblUpdateWebSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUpdateWebSite.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateWebSite.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.lblUpdateWebSite.Appearance.Options.UseFont = True
        Me.lblUpdateWebSite.Appearance.Options.UseForeColor = True
        Me.lblUpdateWebSite.Location = New System.Drawing.Point(298, 164)
        Me.lblUpdateWebSite.Name = "lblUpdateWebSite"
        Me.lblUpdateWebSite.Size = New System.Drawing.Size(94, 13)
        Me.lblUpdateWebSite.TabIndex = 11
        Me.lblUpdateWebSite.Text = "Claus-Software.de"
        '
        'frmErrorMessage
        '
        Me.AcceptButton = Me.btnClose
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(566, 194)
        Me.Controls.Add(Me.lblUpdateWebSite)
        Me.Controls.Add(Me.txtErrorMessage)
        Me.Controls.Add(Me.lblErrorDescription)
        Me.Controls.Add(Me.txtUserMessage)
        Me.Controls.Add(Me.lblSendeErrorMessageUsersNotice)
        Me.Controls.Add(Me.lblOptionalMailNote)
        Me.Controls.Add(Me.lblOptionalMailAddress)
        Me.Controls.Add(Me.txtMailAddres)
        Me.Controls.Add(Me.btnSendMessage)
        Me.Controls.Add(Me.lblerrorreportHeadline)
        Me.Controls.Add(Me.btnRestart)
        Me.Controls.Add(Me.btnClose)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(582, 232)
        Me.Name = "frmErrorMessage"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ein Problem ist aufgetreten"
        CType(Me.txtMailAddres.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserMessage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtErrorMessage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnRestart As System.Windows.Forms.Button
    Friend WithEvents lblerrorreportHeadline As System.Windows.Forms.Label
    Friend WithEvents btnSendMessage As System.Windows.Forms.Button
    Friend WithEvents txtMailAddres As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblOptionalMailAddress As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblOptionalMailNote As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSendeErrorMessageUsersNotice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUserMessage As DevExpress.XtraEditors.MemoExEdit
    Friend WithEvents lblErrorDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtErrorMessage As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblUpdateWebSite As DevExpress.XtraEditors.LabelControl
End Class
