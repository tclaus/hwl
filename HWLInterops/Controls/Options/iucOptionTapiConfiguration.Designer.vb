Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucOptionTapiConfiguration
    Inherits System.Windows.Forms.UserControl

    'iucTapiConfiguration overrides dispose to clean up the component list.
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
        Me.chkMonitorCAPIDevices = New System.Windows.Forms.CheckBox()
        Me.lblISDNMonitorHeadline = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'chkMonitorCAPIDevices
        '
        Me.chkMonitorCAPIDevices.AutoSize = True
        Me.chkMonitorCAPIDevices.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMonitorCAPIDevices.Location = New System.Drawing.Point(18, 119)
        Me.chkMonitorCAPIDevices.Name = "chkMonitorCAPIDevices"
        Me.chkMonitorCAPIDevices.Size = New System.Drawing.Size(169, 19)
        Me.chkMonitorCAPIDevices.TabIndex = 1
        Me.chkMonitorCAPIDevices.Text = "ISDN Telefone überwachen"
        Me.chkMonitorCAPIDevices.UseVisualStyleBackColor = True
        '
        'lblISDNMonitorHeadline
        '
        Me.lblISDNMonitorHeadline.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblISDNMonitorHeadline.Appearance.Options.UseFont = True
        Me.lblISDNMonitorHeadline.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblISDNMonitorHeadline.Location = New System.Drawing.Point(28, 14)
        Me.lblISDNMonitorHeadline.Name = "lblISDNMonitorHeadline"
        Me.lblISDNMonitorHeadline.Size = New System.Drawing.Size(278, 60)
        Me.lblISDNMonitorHeadline.TabIndex = 4
        Me.lblISDNMonitorHeadline.Text = "Wenn Ihr Computer über eine ISDN-Karte verfügt, kann {Appname} Sie über eingehend" & _
            "e Anrufer informieren, indem die Telefonnummer in dem Adressbuch gesucht wird." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
            ""
        '
        'iucOptionTapiConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblISDNMonitorHeadline)
        Me.Controls.Add(Me.chkMonitorCAPIDevices)
        Me.Name = "iucOptionTapiConfiguration"
        Me.Size = New System.Drawing.Size(309, 191)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkMonitorCAPIDevices As System.Windows.Forms.CheckBox
    Friend WithEvents lblISDNMonitorHeadline As DevExpress.XtraEditors.LabelControl

End Class
