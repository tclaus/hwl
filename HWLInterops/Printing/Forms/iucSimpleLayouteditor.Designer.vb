Namespace Printing
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class iucSimpleLayouteditor
        Inherits mainControlContainer

        'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
            Me.PageDesigner = New DevExpress.XtraReports.UserDesigner.XRDesignPanel()
            Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
            Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
            Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
            Me.btnResetLayout = New DevExpress.XtraEditors.SimpleButton()
            Me.btnZoomIn = New DevExpress.XtraEditors.SimpleButton()
            Me.btnZoomOut = New DevExpress.XtraEditors.SimpleButton()
            Me.grpFooter = New DevExpress.XtraEditors.GroupControl()
            Me.btneditFooterText2 = New DevExpress.XtraEditors.SimpleButton()
            Me.chkFooterText2 = New DevExpress.XtraEditors.CheckEdit()
            Me.btneditFooterText1 = New DevExpress.XtraEditors.SimpleButton()
            Me.btneditFooterImage = New DevExpress.XtraEditors.SimpleButton()
            Me.chkFooterText1 = New DevExpress.XtraEditors.CheckEdit()
            Me.chkFooterImage = New DevExpress.XtraEditors.CheckEdit()
            Me.grpHead = New DevExpress.XtraEditors.GroupControl()
            Me.lblAdressLine = New DevExpress.XtraEditors.LabelControl()
            Me.btnAdressLine = New DevExpress.XtraEditors.SimpleButton()
            Me.btnHeaderText2 = New DevExpress.XtraEditors.SimpleButton()
            Me.btnHeaderText1 = New DevExpress.XtraEditors.SimpleButton()
            Me.cmdEditHeaderImage = New DevExpress.XtraEditors.SimpleButton()
            Me.txtAdressLine = New DevExpress.XtraEditors.TextEdit()
            Me.chkHeaderText2 = New DevExpress.XtraEditors.CheckEdit()
            Me.chkHeaderText1 = New DevExpress.XtraEditors.CheckEdit()
            Me.chkHeaderImage = New DevExpress.XtraEditors.CheckEdit()
            Me.PropertyGridControl1 = New DevExpress.XtraVerticalGrid.PropertyGridControl()
            Me.cboControls = New DevExpress.XtraEditors.ComboBoxEdit()
            CType(Me.PageDesigner, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl1.SuspendLayout()
            CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainerControl1.SuspendLayout()
            CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl2.SuspendLayout()
            CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl3.SuspendLayout()
            CType(Me.grpFooter, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpFooter.SuspendLayout()
            CType(Me.chkFooterText2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkFooterText1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkFooterImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.grpHead, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpHead.SuspendLayout()
            CType(Me.txtAdressLine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkHeaderText2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkHeaderText1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.chkHeaderImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PropertyGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboControls.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PageDesigner
            '
            Me.PageDesigner.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PageDesigner.FireScrollEventOnMouseWheel = True
            Me.PageDesigner.Location = New System.Drawing.Point(0, 0)
            Me.PageDesigner.Name = "PageDesigner"
            Me.PageDesigner.Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
            Me.PageDesigner.ShowComponentTray = False
            Me.PageDesigner.Size = New System.Drawing.Size(700, 666)
            Me.PageDesigner.TabIndex = 1
            '
            'PanelControl1
            '
            Me.PanelControl1.Controls.Add(Me.PageDesigner)
            Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl1.Name = "PanelControl1"
            Me.PanelControl1.Size = New System.Drawing.Size(969, 696)
            Me.PanelControl1.TabIndex = 4
            '
            'SplitContainerControl1
            '
            Me.SplitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2
            Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Right
            Me.SplitContainerControl1.Horizontal = False
            Me.SplitContainerControl1.Location = New System.Drawing.Point(701, 0)
            Me.SplitContainerControl1.Name = "SplitContainerControl1"
            Me.SplitContainerControl1.Panel1.Controls.Add(Me.PanelControl2)
            Me.SplitContainerControl1.Panel1.Text = "Panel1"
            Me.SplitContainerControl1.Panel2.Controls.Add(Me.PropertyGridControl1)
            Me.SplitContainerControl1.Panel2.Controls.Add(Me.cboControls)
            Me.SplitContainerControl1.Panel2.Text = "Panel2"
            Me.SplitContainerControl1.Size = New System.Drawing.Size(268, 696)
            Me.SplitContainerControl1.SplitterPosition = 496
            Me.SplitContainerControl1.TabIndex = 6
            Me.SplitContainerControl1.Text = "SplitContainerControl1"
            '
            'PanelControl2
            '
            Me.PanelControl2.Controls.Add(Me.PanelControl3)
            Me.PanelControl2.Controls.Add(Me.grpFooter)
            Me.PanelControl2.Controls.Add(Me.grpHead)
            Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl2.Name = "PanelControl2"
            Me.PanelControl2.Size = New System.Drawing.Size(268, 496)
            Me.PanelControl2.TabIndex = 6
            '
            'PanelControl3
            '
            Me.PanelControl3.Controls.Add(Me.btnResetLayout)
            Me.PanelControl3.Controls.Add(Me.btnZoomIn)
            Me.PanelControl3.Controls.Add(Me.btnZoomOut)
            Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelControl3.Location = New System.Drawing.Point(2, 353)
            Me.PanelControl3.Name = "PanelControl3"
            Me.PanelControl3.Size = New System.Drawing.Size(264, 85)
            Me.PanelControl3.TabIndex = 3
            '
            'btnResetLayout
            '
            Me.btnResetLayout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnResetLayout.Location = New System.Drawing.Point(184, 50)
            Me.btnResetLayout.Name = "btnResetLayout"
            Me.btnResetLayout.Size = New System.Drawing.Size(75, 23)
            Me.btnResetLayout.TabIndex = 3
            Me.btnResetLayout.Text = "Zurücksetzen"
            '
            'btnZoomIn
            '
            Me.btnZoomIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnZoomIn.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Zoom_In
            Me.btnZoomIn.Location = New System.Drawing.Point(148, 6)
            Me.btnZoomIn.Name = "btnZoomIn"
            Me.btnZoomIn.Size = New System.Drawing.Size(111, 38)
            Me.btnZoomIn.TabIndex = 2
            Me.btnZoomIn.Text = "Hineinzoomen"
            '
            'btnZoomOut
            '
            Me.btnZoomOut.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Zoom_Out
            Me.btnZoomOut.Location = New System.Drawing.Point(5, 6)
            Me.btnZoomOut.Name = "btnZoomOut"
            Me.btnZoomOut.Size = New System.Drawing.Size(111, 38)
            Me.btnZoomOut.TabIndex = 2
            Me.btnZoomOut.Text = "Rauszoomen"
            '
            'grpFooter
            '
            Me.grpFooter.Controls.Add(Me.btneditFooterText2)
            Me.grpFooter.Controls.Add(Me.chkFooterText2)
            Me.grpFooter.Controls.Add(Me.btneditFooterText1)
            Me.grpFooter.Controls.Add(Me.btneditFooterImage)
            Me.grpFooter.Controls.Add(Me.chkFooterText1)
            Me.grpFooter.Controls.Add(Me.chkFooterImage)
            Me.grpFooter.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpFooter.Location = New System.Drawing.Point(2, 215)
            Me.grpFooter.Name = "grpFooter"
            Me.grpFooter.Size = New System.Drawing.Size(264, 138)
            Me.grpFooter.TabIndex = 0
            Me.grpFooter.Text = "Seitenfuss"
            '
            'btneditFooterText2
            '
            Me.btneditFooterText2.Location = New System.Drawing.Point(161, 102)
            Me.btneditFooterText2.Name = "btneditFooterText2"
            Me.btneditFooterText2.Size = New System.Drawing.Size(87, 21)
            Me.btneditFooterText2.TabIndex = 2
            Me.btneditFooterText2.Text = "Bearbeiten..."
            '
            'chkFooterText2
            '
            Me.chkFooterText2.Location = New System.Drawing.Point(22, 100)
            Me.chkFooterText2.Name = "chkFooterText2"
            Me.chkFooterText2.Properties.Caption = "Text 2"
            Me.chkFooterText2.Size = New System.Drawing.Size(170, 19)
            Me.chkFooterText2.TabIndex = 3
            '
            'btneditFooterText1
            '
            Me.btneditFooterText1.Location = New System.Drawing.Point(161, 67)
            Me.btneditFooterText1.Name = "btneditFooterText1"
            Me.btneditFooterText1.Size = New System.Drawing.Size(87, 21)
            Me.btneditFooterText1.TabIndex = 2
            Me.btneditFooterText1.Text = "Bearbeiten..."
            '
            'btneditFooterImage
            '
            Me.btneditFooterImage.Location = New System.Drawing.Point(161, 33)
            Me.btneditFooterImage.Name = "btneditFooterImage"
            Me.btneditFooterImage.Size = New System.Drawing.Size(87, 21)
            Me.btneditFooterImage.TabIndex = 2
            Me.btneditFooterImage.Text = "Bearbeiten..."
            '
            'chkFooterText1
            '
            Me.chkFooterText1.Location = New System.Drawing.Point(22, 65)
            Me.chkFooterText1.Name = "chkFooterText1"
            Me.chkFooterText1.Properties.Caption = "Text 1"
            Me.chkFooterText1.Size = New System.Drawing.Size(170, 19)
            Me.chkFooterText1.TabIndex = 2
            '
            'chkFooterImage
            '
            Me.chkFooterImage.Location = New System.Drawing.Point(22, 31)
            Me.chkFooterImage.Name = "chkFooterImage"
            Me.chkFooterImage.Properties.Caption = "Logo (Seitenfuss)"
            Me.chkFooterImage.Size = New System.Drawing.Size(170, 19)
            Me.chkFooterImage.TabIndex = 1
            '
            'grpHead
            '
            Me.grpHead.Controls.Add(Me.lblAdressLine)
            Me.grpHead.Controls.Add(Me.btnAdressLine)
            Me.grpHead.Controls.Add(Me.btnHeaderText2)
            Me.grpHead.Controls.Add(Me.btnHeaderText1)
            Me.grpHead.Controls.Add(Me.cmdEditHeaderImage)
            Me.grpHead.Controls.Add(Me.txtAdressLine)
            Me.grpHead.Controls.Add(Me.chkHeaderText2)
            Me.grpHead.Controls.Add(Me.chkHeaderText1)
            Me.grpHead.Controls.Add(Me.chkHeaderImage)
            Me.grpHead.Dock = System.Windows.Forms.DockStyle.Top
            Me.grpHead.Location = New System.Drawing.Point(2, 2)
            Me.grpHead.Name = "grpHead"
            Me.grpHead.Size = New System.Drawing.Size(264, 213)
            Me.grpHead.TabIndex = 0
            Me.grpHead.Text = "Seitenkopf"
            '
            'lblAdressLine
            '
            Me.lblAdressLine.Location = New System.Drawing.Point(24, 151)
            Me.lblAdressLine.Name = "lblAdressLine"
            Me.lblAdressLine.Size = New System.Drawing.Size(58, 13)
            Me.lblAdressLine.TabIndex = 3
            Me.lblAdressLine.Text = "Fensterzeile"
            '
            'btnAdressLine
            '
            Me.btnAdressLine.Location = New System.Drawing.Point(161, 146)
            Me.btnAdressLine.Name = "btnAdressLine"
            Me.btnAdressLine.Size = New System.Drawing.Size(87, 21)
            Me.btnAdressLine.TabIndex = 2
            Me.btnAdressLine.Text = "Bearbeiten..."
            '
            'btnHeaderText2
            '
            Me.btnHeaderText2.Location = New System.Drawing.Point(161, 112)
            Me.btnHeaderText2.Name = "btnHeaderText2"
            Me.btnHeaderText2.Size = New System.Drawing.Size(87, 21)
            Me.btnHeaderText2.TabIndex = 2
            Me.btnHeaderText2.Text = "Bearbeiten..."
            '
            'btnHeaderText1
            '
            Me.btnHeaderText1.Location = New System.Drawing.Point(161, 76)
            Me.btnHeaderText1.Name = "btnHeaderText1"
            Me.btnHeaderText1.Size = New System.Drawing.Size(87, 21)
            Me.btnHeaderText1.TabIndex = 2
            Me.btnHeaderText1.Text = "Bearbeiten..."
            '
            'cmdEditHeaderImage
            '
            Me.cmdEditHeaderImage.Location = New System.Drawing.Point(161, 42)
            Me.cmdEditHeaderImage.Name = "cmdEditHeaderImage"
            Me.cmdEditHeaderImage.Size = New System.Drawing.Size(87, 21)
            Me.cmdEditHeaderImage.TabIndex = 2
            Me.cmdEditHeaderImage.Text = "Bearbeiten..."
            '
            'txtAdressLine
            '
            Me.txtAdressLine.Location = New System.Drawing.Point(24, 173)
            Me.txtAdressLine.Name = "txtAdressLine"
            Me.txtAdressLine.Size = New System.Drawing.Size(224, 20)
            Me.txtAdressLine.TabIndex = 1
            '
            'chkHeaderText2
            '
            Me.chkHeaderText2.Location = New System.Drawing.Point(22, 110)
            Me.chkHeaderText2.Name = "chkHeaderText2"
            Me.chkHeaderText2.Properties.Caption = "Text 2"
            Me.chkHeaderText2.Size = New System.Drawing.Size(170, 19)
            Me.chkHeaderText2.TabIndex = 0
            '
            'chkHeaderText1
            '
            Me.chkHeaderText1.Location = New System.Drawing.Point(22, 74)
            Me.chkHeaderText1.Name = "chkHeaderText1"
            Me.chkHeaderText1.Properties.Caption = "Text 1"
            Me.chkHeaderText1.Size = New System.Drawing.Size(170, 19)
            Me.chkHeaderText1.TabIndex = 0
            '
            'chkHeaderImage
            '
            Me.chkHeaderImage.Location = New System.Drawing.Point(22, 40)
            Me.chkHeaderImage.Name = "chkHeaderImage"
            Me.chkHeaderImage.Properties.Caption = "Logo (Seitenkopf)"
            Me.chkHeaderImage.Size = New System.Drawing.Size(170, 19)
            Me.chkHeaderImage.TabIndex = 0
            '
            'PropertyGridControl1
            '
            Me.PropertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PropertyGridControl1.Location = New System.Drawing.Point(0, 22)
            Me.PropertyGridControl1.Name = "PropertyGridControl1"
            Me.PropertyGridControl1.Padding = New System.Windows.Forms.Padding(2, 0, 5, 2)
            Me.PropertyGridControl1.Size = New System.Drawing.Size(268, 172)
            Me.PropertyGridControl1.TabIndex = 0
            '
            'cboControls
            '
            Me.cboControls.Dock = System.Windows.Forms.DockStyle.Top
            Me.cboControls.Location = New System.Drawing.Point(0, 0)
            Me.cboControls.Name = "cboControls"
            Me.cboControls.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboControls.Properties.Appearance.Options.UseFont = True
            Me.cboControls.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.cboControls.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            Me.cboControls.Size = New System.Drawing.Size(268, 22)
            Me.cboControls.TabIndex = 1
            '
            'iucSimpleLayouteditor
            '
            Me.Appearance.BackColor = System.Drawing.Color.White
            Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Appearance.Options.UseBackColor = True
            Me.Appearance.Options.UseFont = True
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.SplitContainerControl1)
            Me.Controls.Add(Me.PanelControl1)
            Me.Name = "iucSimpleLayouteditor"
            Me.Size = New System.Drawing.Size(969, 696)
            CType(Me.PageDesigner, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl1.ResumeLayout(False)
            CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainerControl1.ResumeLayout(False)
            CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl2.ResumeLayout(False)
            CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl3.ResumeLayout(False)
            CType(Me.grpFooter, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpFooter.ResumeLayout(False)
            CType(Me.chkFooterText2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkFooterText1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkFooterImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.grpHead, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpHead.ResumeLayout(False)
            Me.grpHead.PerformLayout()
            CType(Me.txtAdressLine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkHeaderText2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkHeaderText1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.chkHeaderImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PropertyGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboControls.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PageDesigner As DevExpress.XtraReports.UserDesigner.XRDesignPanel
        Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
        Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents grpFooter As DevExpress.XtraEditors.GroupControl
        Friend WithEvents btneditFooterText2 As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents chkFooterText2 As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents btneditFooterText1 As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btneditFooterImage As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents chkFooterText1 As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents chkFooterImage As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents grpHead As DevExpress.XtraEditors.GroupControl
        Friend WithEvents lblAdressLine As DevExpress.XtraEditors.LabelControl
        Friend WithEvents btnHeaderText2 As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnHeaderText1 As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents cmdEditHeaderImage As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents txtAdressLine As DevExpress.XtraEditors.TextEdit
        Friend WithEvents chkHeaderText2 As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents chkHeaderText1 As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents chkHeaderImage As DevExpress.XtraEditors.CheckEdit
        Friend WithEvents PropertyGridControl1 As DevExpress.XtraVerticalGrid.PropertyGridControl
        Friend WithEvents btnZoomIn As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents btnZoomOut As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents cboControls As DevExpress.XtraEditors.ComboBoxEdit
        Friend WithEvents btnAdressLine As DevExpress.XtraEditors.SimpleButton
        Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
        Friend WithEvents btnResetLayout As DevExpress.XtraEditors.SimpleButton

    End Class
End Namespace