<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddBarcodeToArticle
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
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton
        Me.btnAssign = New DevExpress.XtraEditors.SimpleButton
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.lblSearchResult = New DevExpress.XtraEditors.LabelControl
        Me.SearchPanelArticles = New HWLInterops.iucSearchPanel
        Me.GroupsGridBox = New HWLInterops.iucGroupsGrid
        Me.SearchPanelEAN = New HWLInterops.iucSearchPanel
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(441, 338)
        Me.btnClose.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnClose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnClose.LookAndFeel.UseWindowsXPTheme = True
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Schliessen"
        '
        'btnAssign
        '
        Me.btnAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssign.Location = New System.Drawing.Point(441, 38)
        Me.btnAssign.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnAssign.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnAssign.LookAndFeel.UseWindowsXPTheme = True
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(75, 23)
        Me.btnAssign.TabIndex = 1
        Me.btnAssign.Text = "Zuweisen"
        Me.btnAssign.ToolTip = "Aktuellen Barcode den gewählten Artikel zuweisen"
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Location = New System.Drawing.Point(441, 9)
        Me.btnNew.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnNew.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnNew.LookAndFeel.UseWindowsXPTheme = True
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "Neu..."
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 19)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "EAN-Code:"
        '
        'lblSearchResult
        '
        Me.lblSearchResult.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchResult.Appearance.Options.UseFont = True
        Me.lblSearchResult.Location = New System.Drawing.Point(12, 55)
        Me.lblSearchResult.Name = "lblSearchResult"
        Me.lblSearchResult.Size = New System.Drawing.Size(63, 23)
        Me.lblSearchResult.TabIndex = 6
        Me.lblSearchResult.Text = "Artikel"
        '
        'SearchPanelArticles
        '
        Me.SearchPanelArticles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchPanelArticles.AutoSize = True
        Me.SearchPanelArticles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SearchPanelArticles.BackColor = System.Drawing.Color.White
        Me.SearchPanelArticles.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SearchPanelArticles.ItemList = Nothing
        Me.SearchPanelArticles.Location = New System.Drawing.Point(12, 101)
        Me.SearchPanelArticles.Margin = New System.Windows.Forms.Padding(0)
        Me.SearchPanelArticles.Name = "SearchPanelArticles"
        Me.SearchPanelArticles.SelectedMenueItem = -1
        Me.SearchPanelArticles.Size = New System.Drawing.Size(294, 22)
        Me.SearchPanelArticles.Status = HWLInterops.iucSearchPanel.enumState.empty
        Me.SearchPanelArticles.TabIndex = 8
        '
        'GroupsGridBox
        '
        Me.GroupsGridBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupsGridBox.BackColor = System.Drawing.SystemColors.Control
        Me.GroupsGridBox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupsGridBox.Location = New System.Drawing.Point(12, 136)
        Me.GroupsGridBox.Name = "GroupsGridBox"
        Me.GroupsGridBox.SelectedArticelID = Nothing
        Me.GroupsGridBox.SelectedGroupID = ""
        Me.GroupsGridBox.Size = New System.Drawing.Size(504, 196)
        Me.GroupsGridBox.TabIndex = 7
        '
        'SearchPanelEAN
        '
        Me.SearchPanelEAN.AutoSize = True
        Me.SearchPanelEAN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SearchPanelEAN.BackColor = System.Drawing.Color.White
        Me.SearchPanelEAN.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SearchPanelEAN.ItemList = Nothing
        Me.SearchPanelEAN.Location = New System.Drawing.Point(102, 9)
        Me.SearchPanelEAN.Margin = New System.Windows.Forms.Padding(0)
        Me.SearchPanelEAN.Name = "SearchPanelEAN"
        Me.SearchPanelEAN.SelectedMenueItem = -1
        Me.SearchPanelEAN.Size = New System.Drawing.Size(222, 22)
        Me.SearchPanelEAN.Status = HWLInterops.iucSearchPanel.enumState.empty
        Me.SearchPanelEAN.TabIndex = 3
        '
        'frmAddBarcodeToArticle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 375)
        Me.Controls.Add(Me.SearchPanelArticles)
        Me.Controls.Add(Me.GroupsGridBox)
        Me.Controls.Add(Me.lblSearchResult)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.SearchPanelEAN)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmAddBarcodeToArticle"
        Me.Text = "Barcode zu Artikel zuweisen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAssign As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SearchPanelEAN As HWLInterops.iucSearchPanel
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSearchResult As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupsGridBox As HWLInterops.iucGroupsGrid
    Friend WithEvents SearchPanelArticles As HWLInterops.iucSearchPanel
End Class
