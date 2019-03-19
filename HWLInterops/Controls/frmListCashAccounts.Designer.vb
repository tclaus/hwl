<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListCashAccounts
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
        Me.components = New System.ComponentModel.Container()
        Me.lblCashAccountsHeadline = New System.Windows.Forms.Label()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNew = New DevExpress.XtraEditors.SimpleButton()
        Me.trvAccounts = New DevExpress.XtraTreeList.TreeList()
        Me.colAccountID = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ColAccountName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuedit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnedit = New DevExpress.XtraEditors.SimpleButton()
        Me.IucSearchPanel1 = New ClausSoftware.HWLInterops.iucSearchPanel()
        CType(Me.trvAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCashAccountsHeadline
        '
        Me.lblCashAccountsHeadline.AutoSize = True
        Me.lblCashAccountsHeadline.Location = New System.Drawing.Point(14, 10)
        Me.lblCashAccountsHeadline.Name = "lblCashAccountsHeadline"
        Me.lblCashAccountsHeadline.Size = New System.Drawing.Size(45, 15)
        Me.lblCashAccountsHeadline.TabIndex = 2
        Me.lblCashAccountsHeadline.Text = "Konten"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Location = New System.Drawing.Point(303, 305)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Schliessen"
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Appearance.Options.UseFont = True
        Me.btnNew.Location = New System.Drawing.Point(209, 305)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(87, 27)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "Neu..."
        '
        'trvAccounts
        '
        Me.trvAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvAccounts.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.trvAccounts.Appearance.EvenRow.Options.UseBackColor = True
        Me.trvAccounts.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colAccountID, Me.ColAccountName})
        Me.trvAccounts.ContextMenuStrip = Me.ContextMenuStrip1
        Me.trvAccounts.Location = New System.Drawing.Point(14, 62)
        Me.trvAccounts.Name = "trvAccounts"
        Me.trvAccounts.OptionsBehavior.AllowIncrementalSearch = True
        Me.trvAccounts.OptionsBehavior.AutoMoveRowFocus = True
        Me.trvAccounts.OptionsBehavior.Editable = False
        Me.trvAccounts.OptionsSelection.InvertSelection = True
        Me.trvAccounts.OptionsView.EnableAppearanceEvenRow = True
        Me.trvAccounts.OptionsView.ShowButtons = False
        Me.trvAccounts.OptionsView.ShowHorzLines = False
        Me.trvAccounts.OptionsView.ShowIndicator = False
        Me.trvAccounts.OptionsView.ShowRoot = False
        Me.trvAccounts.OptionsView.ShowVertLines = False
        Me.trvAccounts.Size = New System.Drawing.Size(377, 235)
        Me.trvAccounts.TabIndex = 1
        '
        'colAccountID
        '
        Me.colAccountID.Caption = "TreeListColumn2"
        Me.colAccountID.FieldName = "AccountID"
        Me.colAccountID.Name = "colAccountID"
        '
        'ColAccountName
        '
        Me.ColAccountName.Caption = "Name d. Kontos"
        Me.ColAccountName.FieldName = "AccountName"
        Me.ColAccountName.Name = "ColAccountName"
        Me.ColAccountName.OptionsColumn.AllowMove = False
        Me.ColAccountName.Visible = True
        Me.ColAccountName.VisibleIndex = 0
        Me.ColAccountName.Width = 319
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuedit, Me.mnuDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(131, 48)
        '
        'mnuedit
        '
        Me.mnuedit.Name = "mnuedit"
        Me.mnuedit.Size = New System.Drawing.Size(130, 22)
        Me.mnuedit.Text = "Bearbeiten"
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(130, 22)
        Me.mnuDelete.Text = "Löschen"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Appearance.Options.UseFont = True
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(114, 305)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 27)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Löschen"
        '
        'btnedit
        '
        Me.btnedit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnedit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.Appearance.Options.UseFont = True
        Me.btnedit.Enabled = False
        Me.btnedit.Location = New System.Drawing.Point(20, 305)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(87, 27)
        Me.btnedit.TabIndex = 5
        Me.btnedit.Text = "Bearbeiten..."
        '
        'IucSearchPanel1
        '
        Me.IucSearchPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IucSearchPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.IucSearchPanel1.Appearance.Options.UseBackColor = True
        Me.IucSearchPanel1.Location = New System.Drawing.Point(14, 36)
        Me.IucSearchPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.IucSearchPanel1.Name = "IucSearchPanel1"
        Me.IucSearchPanel1.NullValuePrompt = "Suche..."
        Me.IucSearchPanel1.SelectedMenueItem = -1
        Me.IucSearchPanel1.Size = New System.Drawing.Size(377, 23)
        Me.IucSearchPanel1.Status = ClausSoftware.HWLInterops.iucSearchPanel.enumState.empty
        Me.IucSearchPanel1.TabIndex = 0
        '
        'frmListCashAccounts
        '
        Me.AcceptButton = Me.btnClose
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 345)
        Me.Controls.Add(Me.IucSearchPanel1)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.trvAccounts)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblCashAccountsHeadline)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(319, 323)
        Me.Name = "frmListCashAccounts"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Auflistung Konten"
        CType(Me.trvAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCashAccountsHeadline As System.Windows.Forms.Label
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents trvAccounts As DevExpress.XtraTreeList.TreeList
    Friend WithEvents ColAccountName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnedit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colAccountID As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents IucSearchPanel1 As ClausSoftware.HWLInterops.iucSearchPanel
End Class
