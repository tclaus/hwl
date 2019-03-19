Namespace Telephony

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCallNotification
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCallNotification))
            Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
            Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblCallerTime = New DevExpress.XtraEditors.LabelControl()
            Me.lblNewIncommingCall = New DevExpress.XtraEditors.LabelControl()
            Me.lblCallerID = New DevExpress.XtraEditors.LabelControl()
            Me.lblCallStartTime = New DevExpress.XtraEditors.LabelControl()
            Me.lblCallerAdress = New DevExpress.XtraEditors.LabelControl()
            Me.btnOpenAdress = New DevExpress.XtraEditors.SimpleButton()
            CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnClose.Location = New System.Drawing.Point(261, 139)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(87, 27)
            Me.btnClose.TabIndex = 1
            Me.btnClose.Text = "Schliessen"
            '
            'PictureEdit1
            '
            Me.PictureEdit1.EditValue = Global.ClausSoftware.HWLInterops.My.Resources.Resources.telephone_48x48
            Me.PictureEdit1.Location = New System.Drawing.Point(3, 14)
            Me.PictureEdit1.Name = "PictureEdit1"
            Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PictureEdit1.Properties.InitialImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.telephone_48x48
            Me.PictureEdit1.Size = New System.Drawing.Size(87, 73)
            Me.PictureEdit1.TabIndex = 2
            Me.PictureEdit1.Tag = "DontTranslate"
            '
            'Panel1
            '
            Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1.Controls.Add(Me.lblCallerTime)
            Me.Panel1.Controls.Add(Me.lblNewIncommingCall)
            Me.Panel1.Controls.Add(Me.lblCallerID)
            Me.Panel1.Controls.Add(Me.lblCallStartTime)
            Me.Panel1.Location = New System.Drawing.Point(96, 14)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(251, 53)
            Me.Panel1.TabIndex = 0
            '
            'lblCallerTime
            '
            Me.lblCallerTime.Location = New System.Drawing.Point(3, 25)
            Me.lblCallerTime.Name = "lblCallerTime"
            Me.lblCallerTime.Size = New System.Drawing.Size(48, 13)
            Me.lblCallerTime.TabIndex = 0
            Me.lblCallerTime.Text = "Anrufzeit:"
            '
            'lblNewIncommingCall
            '
            Me.lblNewIncommingCall.Location = New System.Drawing.Point(3, 3)
            Me.lblNewIncommingCall.Name = "lblNewIncommingCall"
            Me.lblNewIncommingCall.Size = New System.Drawing.Size(55, 13)
            Me.lblNewIncommingCall.TabIndex = 0
            Me.lblNewIncommingCall.Text = "Anruf von: "
            '
            'lblCallerID
            '
            Me.lblCallerID.Location = New System.Drawing.Point(94, 3)
            Me.lblCallerID.Name = "lblCallerID"
            Me.lblCallerID.Size = New System.Drawing.Size(70, 13)
            Me.lblCallerID.TabIndex = 0
            Me.lblCallerID.Tag = "DontTranslate"
            Me.lblCallerID.Text = "0231 / 375864"
            '
            'lblCallStartTime
            '
            Me.lblCallStartTime.Location = New System.Drawing.Point(94, 25)
            Me.lblCallStartTime.Name = "lblCallStartTime"
            Me.lblCallStartTime.Size = New System.Drawing.Size(48, 13)
            Me.lblCallStartTime.TabIndex = 0
            Me.lblCallStartTime.Tag = "DontTranslate"
            Me.lblCallStartTime.Text = "Anrufzeit:"
            '
            'lblCallerAdress
            '
            Me.lblCallerAdress.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.lblCallerAdress.Appearance.Options.UseBackColor = True
            Me.lblCallerAdress.Appearance.Options.UseTextOptions = True
            Me.lblCallerAdress.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Me.lblCallerAdress.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
            Me.lblCallerAdress.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
            Me.lblCallerAdress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.lblCallerAdress.Location = New System.Drawing.Point(96, 74)
            Me.lblCallerAdress.Name = "lblCallerAdress"
            Me.lblCallerAdress.Size = New System.Drawing.Size(251, 59)
            Me.lblCallerAdress.TabIndex = 0
            Me.lblCallerAdress.Tag = "DontTranslate"
            Me.lblCallerAdress.Text = "-unbekannte Adresse-"
            '
            'btnOpenAdress
            '
            Me.btnOpenAdress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOpenAdress.Enabled = False
            Me.btnOpenAdress.Location = New System.Drawing.Point(139, 139)
            Me.btnOpenAdress.Name = "btnOpenAdress"
            Me.btnOpenAdress.Size = New System.Drawing.Size(114, 27)
            Me.btnOpenAdress.TabIndex = 1
            Me.btnOpenAdress.Text = "Adresse aufrufen"
            '
            'frmCallNotification
            '
            Me.Appearance.BackColor = System.Drawing.Color.White
            Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseBackColor = True
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSize = True
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(355, 179)
            Me.Controls.Add(Me.PictureEdit1)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.lblCallerAdress)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnOpenAdress)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.Name = "frmCallNotification"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Neuer Anruf"
            CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblNewIncommingCall As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCallerID As DevExpress.XtraEditors.LabelControl
        Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnOpenAdress As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents lblCallerTime As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCallStartTime As DevExpress.XtraEditors.LabelControl
        Friend WithEvents lblCallerAdress As DevExpress.XtraEditors.LabelControl
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    End Class
End Namespace
