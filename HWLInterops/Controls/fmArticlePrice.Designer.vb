<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmArticlePrice
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
        Me.NavBarGroupControlContainer1 = New DevExpress.XtraNavBar.NavBarGroupControlContainer
        Me.NavBarGroupControlContainer2 = New DevExpress.XtraNavBar.NavBarGroupControlContainer
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl
        Me.NavBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarItem4 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem5 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem6 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarGroup2 = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarItem1 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem2 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem3 = New DevExpress.XtraNavBar.NavBarItem
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavBarControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NavBarGroupControlContainer1
        '
        Me.NavBarGroupControlContainer1.Name = "NavBarGroupControlContainer1"
        Me.NavBarGroupControlContainer1.Size = New System.Drawing.Size(347, 78)
        Me.NavBarGroupControlContainer1.TabIndex = 0
        '
        'NavBarGroupControlContainer2
        '
        Me.NavBarGroupControlContainer2.Name = "NavBarGroupControlContainer2"
        Me.NavBarGroupControlContainer2.Size = New System.Drawing.Size(347, 79)
        Me.NavBarGroupControlContainer2.TabIndex = 1
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.NavBarGroup1
        Me.NavBarControl1.ContentButtonHint = Nothing
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer1)
        Me.NavBarControl1.Controls.Add(Me.NavBarGroupControlContainer2)
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarGroup1, Me.NavBarGroup2})
        Me.NavBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.NavBarItem1, Me.NavBarItem2, Me.NavBarItem3, Me.NavBarItem4, Me.NavBarItem5, Me.NavBarItem6})
        Me.NavBarControl1.Location = New System.Drawing.Point(12, 31)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.OptionsNavPane.ExpandedWidth = 349
        Me.NavBarControl1.Size = New System.Drawing.Size(349, 288)
        Me.NavBarControl1.TabIndex = 31
        Me.NavBarControl1.Text = "NavBarControl1"
        Me.NavBarControl1.View = New DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Lilian")
        '
        'NavBarGroup1
        '
        Me.NavBarGroup1.Caption = "Rohstoffpreise"
        Me.NavBarGroup1.ControlContainer = Me.NavBarGroupControlContainer1
        Me.NavBarGroup1.Expanded = True
        Me.NavBarGroup1.GroupClientHeight = 79
        Me.NavBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarGroup1.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem4), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem5), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem6)})
        Me.NavBarGroup1.Name = "NavBarGroup1"
        '
        'NavBarItem4
        '
        Me.NavBarItem4.Caption = "NavBarItem4"
        Me.NavBarItem4.Name = "NavBarItem4"
        '
        'NavBarItem5
        '
        Me.NavBarItem5.Caption = "NavBarItem5"
        Me.NavBarItem5.Name = "NavBarItem5"
        '
        'NavBarItem6
        '
        Me.NavBarItem6.Caption = "NavBarItem6"
        Me.NavBarItem6.Name = "NavBarItem6"
        '
        'NavBarGroup2
        '
        Me.NavBarGroup2.Caption = "NavBarGroup2"
        Me.NavBarGroup2.ControlContainer = Me.NavBarGroupControlContainer2
        Me.NavBarGroup2.Expanded = True
        Me.NavBarGroup2.GroupClientHeight = 80
        Me.NavBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer
        Me.NavBarGroup2.Name = "NavBarGroup2"
        '
        'NavBarItem1
        '
        Me.NavBarItem1.Caption = "NavBarItem1"
        Me.NavBarItem1.Name = "NavBarItem1"
        '
        'NavBarItem2
        '
        Me.NavBarItem2.Caption = "NavBarItem2"
        Me.NavBarItem2.Name = "NavBarItem2"
        '
        'NavBarItem3
        '
        Me.NavBarItem3.Caption = "NavBarItem3"
        Me.NavBarItem3.Name = "NavBarItem3"
        '
        'fmArticlePrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 402)
        Me.Controls.Add(Me.NavBarControl1)
        Me.Name = "fmArticlePrice"
        Me.Text = "fmArticlePrice"
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavBarControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NavBarGroupControlContainer1 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents NavBarGroupControlContainer2 As DevExpress.XtraNavBar.NavBarGroupControlContainer
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem4 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem5 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem6 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup2 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem1 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem2 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem3 As DevExpress.XtraNavBar.NavBarItem
End Class
