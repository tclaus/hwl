<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetArticleByBarcode
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
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.lblCurrentArticle = New DevExpress.XtraEditors.LabelControl()
        Me.iucSearchByEAN = New ClausSoftware.HWLInterops.iucSearchPanel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblBackMoney = New System.Windows.Forms.Label()
        Me.lbltextTotal = New System.Windows.Forms.Label()
        Me.lblAmmountGiven = New System.Windows.Forms.Label()
        Me.lblAmmountReturn = New System.Windows.Forms.Label()
        Me.txtGivenAmmount = New System.Windows.Forms.TextBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(371, 331)
        Me.btnCancel.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnCancel.LookAndFeel.UseWindowsXPTheme = True
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(290, 331)
        Me.btnOK.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.btnOK.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnOK.LookAndFeel.UseWindowsXPTheme = True
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'lblCurrentArticle
        '
        Me.lblCurrentArticle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentArticle.AutoEllipsis = True
        Me.lblCurrentArticle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCurrentArticle.Location = New System.Drawing.Point(12, 52)
        Me.lblCurrentArticle.Name = "lblCurrentArticle"
        Me.lblCurrentArticle.Size = New System.Drawing.Size(440, 30)
        Me.lblCurrentArticle.TabIndex = 3
        Me.lblCurrentArticle.Text = "Artikel"
        '
        'iucSearchByEAN
        '
        Me.iucSearchByEAN.AllowTextFieldTabStop = True
        Me.iucSearchByEAN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.iucSearchByEAN.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.iucSearchByEAN.Appearance.Options.UseForeColor = True
        Me.iucSearchByEAN.AutoSize = True
        Me.iucSearchByEAN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.iucSearchByEAN.Location = New System.Drawing.Point(12, 27)
        Me.iucSearchByEAN.Margin = New System.Windows.Forms.Padding(0)
        Me.iucSearchByEAN.Name = "iucSearchByEAN"
        Me.iucSearchByEAN.NullValuePrompt = "Suche...    F3"
        Me.iucSearchByEAN.SelectedMenueItem = -1
        Me.iucSearchByEAN.Size = New System.Drawing.Size(0, 0)
        Me.iucSearchByEAN.Status = ClausSoftware.HWLInterops.iucSearchPanel.enumState.empty
        Me.iucSearchByEAN.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(335, 238)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(109, 26)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBackMoney
        '
        Me.lblBackMoney.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBackMoney.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackMoney.Location = New System.Drawing.Point(335, 301)
        Me.lblBackMoney.Name = "lblBackMoney"
        Me.lblBackMoney.Size = New System.Drawing.Size(109, 26)
        Me.lblBackMoney.TabIndex = 5
        Me.lblBackMoney.Text = "0"
        Me.lblBackMoney.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbltextTotal
        '
        Me.lbltextTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltextTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltextTotal.Location = New System.Drawing.Point(237, 237)
        Me.lbltextTotal.Name = "lbltextTotal"
        Me.lbltextTotal.Size = New System.Drawing.Size(88, 26)
        Me.lbltextTotal.TabIndex = 6
        Me.lbltextTotal.Text = "Gesamt: "
        '
        'lblAmmountGiven
        '
        Me.lblAmmountGiven.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAmmountGiven.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmmountGiven.Location = New System.Drawing.Point(237, 268)
        Me.lblAmmountGiven.Name = "lblAmmountGiven"
        Me.lblAmmountGiven.Size = New System.Drawing.Size(92, 26)
        Me.lblAmmountGiven.TabIndex = 6
        Me.lblAmmountGiven.Text = "Gegeben:"
        '
        'lblAmmountReturn
        '
        Me.lblAmmountReturn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAmmountReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmmountReturn.Location = New System.Drawing.Point(237, 301)
        Me.lblAmmountReturn.Name = "lblAmmountReturn"
        Me.lblAmmountReturn.Size = New System.Drawing.Size(92, 26)
        Me.lblAmmountReturn.TabIndex = 6
        Me.lblAmmountReturn.Text = "Rückgeld:"
        '
        'txtGivenAmmount
        '
        Me.txtGivenAmmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGivenAmmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGivenAmmount.Location = New System.Drawing.Point(346, 268)
        Me.txtGivenAmmount.Name = "txtGivenAmmount"
        Me.txtGivenAmmount.Size = New System.Drawing.Size(100, 26)
        Me.txtGivenAmmount.TabIndex = 7
        Me.txtGivenAmmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(12, 82)
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.LookAndFeel.UseWindowsXPTheme = True
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(440, 153)
        Me.GridControl1.TabIndex = 8
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1, Me.GridView2})
        '
        'GridView1
        '
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsMenu.EnableFooterMenu = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Standard
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(400, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(52, 45)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'frmGetArticleByBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 366)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.txtGivenAmmount)
        Me.Controls.Add(Me.lblAmmountReturn)
        Me.Controls.Add(Me.lblAmmountGiven)
        Me.Controls.Add(Me.lbltextTotal)
        Me.Controls.Add(Me.lblBackMoney)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblCurrentArticle)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.iucSearchByEAN)
        Me.Name = "frmGetArticleByBarcode"
        Me.ShowIcon = False
        Me.Text = "Artikel einscannen"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents iucSearchByEAN As HWLInterops.iucSearchPanel
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblCurrentArticle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblBackMoney As System.Windows.Forms.Label
    Friend WithEvents lbltextTotal As System.Windows.Forms.Label
    Friend WithEvents lblAmmountGiven As System.Windows.Forms.Label
    Friend WithEvents lblAmmountReturn As System.Windows.Forms.Label
    Friend WithEvents txtGivenAmmount As System.Windows.Forms.TextBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
