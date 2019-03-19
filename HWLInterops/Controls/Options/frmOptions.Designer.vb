<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.components = New System.ComponentModel.Container()
        Me.nbcOptionBar = New DevExpress.XtraNavBar.NavBarControl()
        Me.nGrpData = New DevExpress.XtraNavBar.NavBarGroup()
        Me.navItems = New DevExpress.XtraNavBar.NavBarItem()
        Me.navNumbers = New DevExpress.XtraNavBar.NavBarItem()
        Me.navTaxRates = New DevExpress.XtraNavBar.NavBarItem()
        Me.navTextTemplates = New DevExpress.XtraNavBar.NavBarItem()
        Me.navTransactions = New DevExpress.XtraNavBar.NavBarItem()
        Me.ngrpsystem = New DevExpress.XtraNavBar.NavBarGroup()
        Me.navProtocol = New DevExpress.XtraNavBar.NavBarItem()
        Me.navTelephony = New DevExpress.XtraNavBar.NavBarItem()
        Me.navUserRights = New DevExpress.XtraNavBar.NavBarItem()
        Me.navDatabase = New DevExpress.XtraNavBar.NavBarItem()
        Me.ToolTipController1 = New DevExpress.Utils.ToolTipController(Me.components)
        Me.splOptionsSplitter = New DevExpress.XtraEditors.SplitContainerControl()
        Me.grpControls = New DevExpress.XtraEditors.GroupControl()
        Me.lblOptionsWhereDoYouWantToStart = New DevExpress.XtraEditors.LabelControl()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.nbcOptionBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splOptionsSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splOptionsSplitter.SuspendLayout()
        CType(Me.grpControls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'nbcOptionBar
        '
        Me.nbcOptionBar.ActiveGroup = Me.nGrpData
        Me.nbcOptionBar.AllowDrop = False
        Me.nbcOptionBar.Appearance.ButtonHotTracked.BackColor = System.Drawing.Color.DarkKhaki
        Me.nbcOptionBar.Appearance.ButtonHotTracked.BackColor2 = System.Drawing.Color.PaleGoldenrod
        Me.nbcOptionBar.Appearance.ButtonHotTracked.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.nbcOptionBar.Appearance.ButtonHotTracked.Options.UseBackColor = True
        Me.nbcOptionBar.Appearance.ItemActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.nbcOptionBar.Appearance.ItemActive.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nbcOptionBar.Appearance.ItemActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nbcOptionBar.Appearance.ItemActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.nbcOptionBar.Appearance.ItemActive.Options.UseBackColor = True
        Me.nbcOptionBar.Appearance.ItemActive.Options.UseBorderColor = True
        Me.nbcOptionBar.Appearance.ItemHotTracked.BackColor = System.Drawing.Color.Wheat
        Me.nbcOptionBar.Appearance.ItemHotTracked.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.nbcOptionBar.Appearance.ItemHotTracked.Options.UseBackColor = True
        Me.nbcOptionBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.nbcOptionBar.ContentButtonHint = Nothing
        Me.nbcOptionBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nbcOptionBar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbcOptionBar.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.nGrpData, Me.ngrpsystem})
        Me.nbcOptionBar.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.navTaxRates, Me.navNumbers, Me.navProtocol, Me.navItems, Me.navDatabase, Me.navTelephony, Me.navUserRights, Me.navTextTemplates, Me.navTransactions})
        Me.nbcOptionBar.Location = New System.Drawing.Point(0, 0)
        Me.nbcOptionBar.Name = "nbcOptionBar"
        Me.nbcOptionBar.OptionsNavPane.ExpandedWidth = 127
        Me.nbcOptionBar.OptionsNavPane.ShowExpandButton = False
        Me.nbcOptionBar.OptionsNavPane.ShowOverflowPanel = False
        Me.nbcOptionBar.OptionsNavPane.ShowSplitter = False
        Me.nbcOptionBar.Size = New System.Drawing.Size(158, 313)
        Me.nbcOptionBar.StoreDefaultPaintStyleName = True
        Me.nbcOptionBar.TabIndex = 1
        Me.nbcOptionBar.Text = "Optionen"
        Me.nbcOptionBar.ToolTipController = Me.ToolTipController1
        '
        'nGrpData
        '
        Me.nGrpData.Caption = "Daten"
        Me.nGrpData.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None
        Me.nGrpData.Expanded = True
        Me.nGrpData.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText
        Me.nGrpData.Hint = "Enthält allgemeine Einstellungen zu verschiedenen Programmteilen"
        Me.nGrpData.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.navItems), New DevExpress.XtraNavBar.NavBarItemLink(Me.navNumbers), New DevExpress.XtraNavBar.NavBarItemLink(Me.navTaxRates), New DevExpress.XtraNavBar.NavBarItemLink(Me.navTextTemplates), New DevExpress.XtraNavBar.NavBarItemLink(Me.navTransactions)})
        Me.nGrpData.Name = "nGrpData"
        Me.nGrpData.NavigationPaneVisible = False
        '
        'navItems
        '
        Me.navItems.AppearancePressed.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.navItems.AppearancePressed.Options.UseFont = True
        Me.navItems.Caption = "Artikelliste"
        Me.navItems.Name = "navItems"
        Me.navItems.SmallImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Right
        Me.navItems.Tag = "items"
        '
        'navNumbers
        '
        Me.navNumbers.Caption = "Nummerngenerator"
        Me.navNumbers.Name = "navNumbers"
        Me.navNumbers.SmallImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Right
        Me.navNumbers.Tag = "numbers"
        '
        'navTaxRates
        '
        Me.navTaxRates.Caption = "Steuern"
        Me.navTaxRates.Name = "navTaxRates"
        Me.navTaxRates.SmallImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Right
        Me.navTaxRates.Tag = "taxes"
        '
        'navTextTemplates
        '
        Me.navTextTemplates.Caption = "Textbausteine"
        Me.navTextTemplates.Name = "navTextTemplates"
        Me.navTextTemplates.SmallImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Right
        Me.navTextTemplates.Tag = "texttemplates"
        '
        'navTransactions
        '
        Me.navTransactions.Caption = "Forderungen / Verbindlichkeiten"
        Me.navTransactions.Name = "navTransactions"
        Me.navTransactions.SmallImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Right
        Me.navTransactions.Tag = "transactions"
        '
        'ngrpsystem
        '
        Me.ngrpsystem.Caption = "System"
        Me.ngrpsystem.DragDropFlags = DevExpress.XtraNavBar.NavBarDragDrop.None
        Me.ngrpsystem.Expanded = True
        Me.ngrpsystem.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText
        Me.ngrpsystem.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.navProtocol), New DevExpress.XtraNavBar.NavBarItemLink(Me.navTelephony), New DevExpress.XtraNavBar.NavBarItemLink(Me.navUserRights), New DevExpress.XtraNavBar.NavBarItemLink(Me.navDatabase)})
        Me.ngrpsystem.Name = "ngrpsystem"
        Me.ngrpsystem.NavigationPaneVisible = False
        '
        'navProtocol
        '
        Me.navProtocol.Caption = "Protokoll"
        Me.navProtocol.Name = "navProtocol"
        Me.navProtocol.SmallImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Right
        Me.navProtocol.Tag = "protocol"
        Me.navProtocol.Visible = False
        '
        'navTelephony
        '
        Me.navTelephony.Caption = "Telefonie"
        Me.navTelephony.Name = "navTelephony"
        Me.navTelephony.SmallImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Right
        Me.navTelephony.Tag = "telephony"
        '
        'navUserRights
        '
        Me.navUserRights.Caption = "Benutzer"
        Me.navUserRights.Name = "navUserRights"
        Me.navUserRights.SmallImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Right
        Me.navUserRights.Tag = "users"
        Me.navUserRights.Visible = False
        '
        'navDatabase
        '
        Me.navDatabase.Caption = "Datenverbindungen"
        Me.navDatabase.Name = "navDatabase"
        Me.navDatabase.SmallImage = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Right
        Me.navDatabase.Tag = "database"
        '
        'splOptionsSplitter
        '
        Me.splOptionsSplitter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splOptionsSplitter.Location = New System.Drawing.Point(2, 0)
        Me.splOptionsSplitter.Name = "splOptionsSplitter"
        Me.splOptionsSplitter.Padding = New System.Windows.Forms.Padding(3)
        Me.splOptionsSplitter.Panel1.Controls.Add(Me.nbcOptionBar)
        Me.splOptionsSplitter.Panel1.Text = "Panel1"
        Me.splOptionsSplitter.Panel2.Controls.Add(Me.grpControls)
        Me.splOptionsSplitter.Panel2.Text = "Panel2"
        Me.splOptionsSplitter.Size = New System.Drawing.Size(555, 319)
        Me.splOptionsSplitter.SplitterPosition = 158
        Me.splOptionsSplitter.TabIndex = 2
        Me.splOptionsSplitter.Text = "SplitContainerControl1"
        '
        'grpControls
        '
        Me.grpControls.Appearance.BackColor = System.Drawing.Color.White
        Me.grpControls.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpControls.Appearance.Options.UseBackColor = True
        Me.grpControls.Appearance.Options.UseFont = True
        Me.grpControls.AppearanceCaption.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpControls.AppearanceCaption.ForeColor = System.Drawing.Color.DarkGreen
        Me.grpControls.AppearanceCaption.Options.UseFont = True
        Me.grpControls.AppearanceCaption.Options.UseForeColor = True
        Me.grpControls.Controls.Add(Me.lblOptionsWhereDoYouWantToStart)
        Me.grpControls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpControls.Location = New System.Drawing.Point(0, 0)
        Me.grpControls.LookAndFeel.UseWindowsXPTheme = True
        Me.grpControls.Name = "grpControls"
        Me.grpControls.Size = New System.Drawing.Size(386, 313)
        Me.grpControls.TabIndex = 0
        Me.grpControls.Text = "Einstellungen"
        '
        'lblOptionsWhereDoYouWantToStart
        '
        Me.lblOptionsWhereDoYouWantToStart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOptionsWhereDoYouWantToStart.Appearance.BackColor = System.Drawing.Color.LemonChiffon
        Me.lblOptionsWhereDoYouWantToStart.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionsWhereDoYouWantToStart.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.lblOptionsWhereDoYouWantToStart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.lblOptionsWhereDoYouWantToStart.Location = New System.Drawing.Point(5, 31)
        Me.lblOptionsWhereDoYouWantToStart.Name = "lblOptionsWhereDoYouWantToStart"
        Me.lblOptionsWhereDoYouWantToStart.Size = New System.Drawing.Size(370, 34)
        Me.lblOptionsWhereDoYouWantToStart.TabIndex = 0
        Me.lblOptionsWhereDoYouWantToStart.Text = "Wählen Sie einen Bereich, in dem Sie Einstellungen vornehmen möchten."
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(389, 339)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(469, 339)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Abbrechen"
        '
        'frmOptions
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(556, 372)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.splOptionsSplitter)
        Me.LookAndFeel.SkinName = "Lilian"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(572, 410)
        Me.Name = "frmOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Einstellungen vornehmen"
        CType(Me.nbcOptionBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.splOptionsSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splOptionsSplitter.ResumeLayout(False)
        CType(Me.grpControls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpControls.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents nbcOptionBar As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents nGrpData As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents navTaxRates As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents navNumbers As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents navProtocol As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents navItems As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents ngrpsystem As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents navDatabase As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents navTelephony As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents ToolTipController1 As DevExpress.Utils.ToolTipController
    Friend WithEvents splOptionsSplitter As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grpControls As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents navUserRights As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents lblOptionsWhereDoYouWantToStart As DevExpress.XtraEditors.LabelControl
    Friend WithEvents navTextTemplates As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents navTransactions As DevExpress.XtraNavBar.NavBarItem
End Class
