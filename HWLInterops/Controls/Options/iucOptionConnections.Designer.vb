Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucOptionConnections
    Inherits ClausSoftware.HWLInterops.BaseControl

    'iucOptionConnections overrides dispose to clean up the component list.
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnReload = New DevExpress.XtraEditors.SimpleButton()
        Me.lstConnections = New DevExpress.XtraEditors.ListBoxControl()
        Me.btnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCreateDBBackup = New DevExpress.XtraEditors.SimpleButton()
        Me.lblBackupPath = New DevExpress.XtraEditors.LabelControl()
        Me.lblPath = New DevExpress.XtraEditors.LabelControl()
        Me.lblDBPath = New System.Windows.Forms.Label()
        Me.lblDBBackupPath = New System.Windows.Forms.Label()
        Me.lblDBServer = New System.Windows.Forms.Label()
        CType(Me.lstConnections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Location = New System.Drawing.Point(218, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(99, 27)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Löschen"
        Me.btnDelete.ToolTip = "Löscht die markierte Verbindung"
        '
        'btnReload
        '
        Me.btnReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReload.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReload.Appearance.Options.UseFont = True
        Me.btnReload.Location = New System.Drawing.Point(218, 204)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(99, 27)
        Me.btnReload.TabIndex = 4
        Me.btnReload.Text = "neu laden"
        Me.btnReload.Visible = False
        '
        'lstConnections
        '
        Me.lstConnections.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstConnections.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstConnections.Appearance.Options.UseFont = True
        Me.lstConnections.Location = New System.Drawing.Point(3, 3)
        Me.lstConnections.Name = "lstConnections"
        Me.lstConnections.Size = New System.Drawing.Size(208, 117)
        Me.lstConnections.SortOrder = System.Windows.Forms.SortOrder.Ascending
        ToolTipTitleItem1.Text = "Verbindungen zur Datenbank"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Sie können unterschiedliche Verbindungen zur Programmdatenbank herstellen und die" & _
    "se wahlweise wechseln."
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.lstConnections.SuperTip = SuperToolTip1
        Me.lstConnections.TabIndex = 0
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Appearance.Options.UseFont = True
        Me.btnEdit.Location = New System.Drawing.Point(218, 37)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(99, 27)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Bearbeiten..."
        Me.btnEdit.ToolTip = "Öffnet ein Fenster um die markirte Verbindung zu bearbeiten."
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Appearance.Options.UseFont = True
        Me.btnNew.Location = New System.Drawing.Point(218, 70)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(99, 27)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "Neu..."
        Me.btnNew.ToolTip = "Legt eine neue Verbindung an."
        '
        'btnCreateDBBackup
        '
        Me.btnCreateDBBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCreateDBBackup.Location = New System.Drawing.Point(3, 204)
        Me.btnCreateDBBackup.Name = "btnCreateDBBackup"
        Me.btnCreateDBBackup.Size = New System.Drawing.Size(149, 27)
        Me.btnCreateDBBackup.TabIndex = 7
        Me.btnCreateDBBackup.Text = "Datensicherung anlegen"
        '
        'lblBackupPath
        '
        Me.lblBackupPath.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackupPath.Appearance.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblBackupPath.Appearance.Options.UseFont = True
        Me.lblBackupPath.Appearance.Options.UseForeColor = True
        Me.lblBackupPath.Appearance.Options.UseTextOptions = True
        Me.lblBackupPath.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisPath
        Me.lblBackupPath.AutoEllipsis = True
        Me.lblBackupPath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblBackupPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBackupPath.Location = New System.Drawing.Point(74, 162)
        Me.lblBackupPath.Name = "lblBackupPath"
        Me.lblBackupPath.Size = New System.Drawing.Size(243, 15)
        Me.lblBackupPath.TabIndex = 11
        Me.lblBackupPath.Tag = "DontTranslate"
        Me.lblBackupPath.Text = " - Pathname -"
        '
        'lblPath
        '
        Me.lblPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPath.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.Appearance.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPath.Appearance.Options.UseFont = True
        Me.lblPath.Appearance.Options.UseForeColor = True
        Me.lblPath.Appearance.Options.UseTextOptions = True
        Me.lblPath.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisPath
        Me.lblPath.AutoEllipsis = True
        Me.lblPath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPath.Location = New System.Drawing.Point(74, 141)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(247, 15)
        ToolTipTitleItem2.Text = "Pfad zur Datenbankdatei"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "In diesem Pfad ist die Datenbankdatei gespeichert." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Diese enthält sämtliche Daten" & _
    " des Programms"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.lblPath.SuperTip = SuperToolTip2
        Me.lblPath.TabIndex = 10
        Me.lblPath.Tag = "DontTranslate"
        Me.lblPath.Text = " - Pathname -"
        '
        'lblDBPath
        '
        Me.lblDBPath.AutoSize = True
        Me.lblDBPath.Location = New System.Drawing.Point(3, 141)
        Me.lblDBPath.Name = "lblDBPath"
        Me.lblDBPath.Size = New System.Drawing.Size(54, 15)
        Me.lblDBPath.TabIndex = 12
        Me.lblDBPath.Text = "DB-Pfad:"
        '
        'lblDBBackupPath
        '
        Me.lblDBBackupPath.AutoSize = True
        Me.lblDBBackupPath.Location = New System.Drawing.Point(3, 162)
        Me.lblDBBackupPath.Name = "lblDBBackupPath"
        Me.lblDBBackupPath.Size = New System.Drawing.Size(60, 15)
        Me.lblDBBackupPath.TabIndex = 13
        Me.lblDBBackupPath.Text = "DB-Kopie:"
        '
        'lblDBServer
        '
        Me.lblDBServer.AutoSize = True
        Me.lblDBServer.Location = New System.Drawing.Point(3, 126)
        Me.lblDBServer.Name = "lblDBServer"
        Me.lblDBServer.Size = New System.Drawing.Size(81, 15)
        Me.lblDBServer.TabIndex = 14
        Me.lblDBServer.Tag = "DONTTRANSLATE"
        Me.lblDBServer.Text = "-ServerName-"
        '
        'iucOptionConnections
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblDBServer)
        Me.Controls.Add(Me.lblDBBackupPath)
        Me.Controls.Add(Me.lblDBPath)
        Me.Controls.Add(Me.lblBackupPath)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.btnCreateDBBackup)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.lstConnections)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.btnDelete)
        Me.Name = "iucOptionConnections"
        Me.Size = New System.Drawing.Size(321, 234)
        CType(Me.lstConnections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnReload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lstConnections As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents btnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCreateDBBackup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblBackupPath As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPath As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDBPath As System.Windows.Forms.Label
    Friend WithEvents lblDBBackupPath As System.Windows.Forms.Label
    Friend WithEvents lblDBServer As System.Windows.Forms.Label

End Class
