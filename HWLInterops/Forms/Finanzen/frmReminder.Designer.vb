<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReminder
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
        Dim SpellCheckerISpellDictionary1 As DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary = New DevExpress.XtraSpellChecker.SpellCheckerISpellDictionary()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReminder))
        Dim OptionsSpelling1 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Dim OptionsSpelling2 As DevExpress.XtraSpellChecker.OptionsSpelling = New DevExpress.XtraSpellChecker.OptionsSpelling()
        Me.SpellChecker1 = New DevExpress.XtraSpellChecker.SpellChecker()
        Me.txtSubject = New DevExpress.XtraEditors.TextEdit()
        Me.txtDescription = New DevExpress.XtraRichEdit.RichEditControl()
        Me.lblRemindersLevel = New DevExpress.XtraEditors.LabelControl()
        Me.lblRemindersSubjectLine = New DevExpress.XtraEditors.LabelControl()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.chkIsInactiveReminder = New DevExpress.XtraEditors.CheckEdit()
        Me.datReminderDate = New DevExpress.XtraEditors.DateEdit()
        Me.datRemindersLimitDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblInvoiceDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblInvoiceNumber = New DevExpress.XtraEditors.LabelControl()
        Me.lblInvoiceNumberText = New DevExpress.XtraEditors.LabelControl()
        Me.lblInvoiceText = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.lstRemindersList = New DevExpress.XtraEditors.ListBoxControl()
        Me.btnNextReminderstep = New DevExpress.XtraEditors.SimpleButton()
        Me.lblRemindersLeveltext = New DevExpress.XtraEditors.LabelControl()
        Me.btndelete = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsInactiveReminder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datReminderDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datReminderDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datRemindersLimitDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datRemindersLimitDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstRemindersList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SpellChecker1
        '
        Me.SpellChecker1.Culture = New System.Globalization.CultureInfo("de-DE")
        SpellCheckerISpellDictionary1.AlphabetPath = ""
        SpellCheckerISpellDictionary1.CacheKey = Nothing
        SpellCheckerISpellDictionary1.Culture = New System.Globalization.CultureInfo("de-DE")
        SpellCheckerISpellDictionary1.DictionaryPath = "C:\tmp\de-de\de_DE.dic"
        SpellCheckerISpellDictionary1.Encoding = CType(resources.GetObject("SpellCheckerISpellDictionary1.Encoding"), System.Text.Encoding)
        SpellCheckerISpellDictionary1.GrammarPath = ""
        Me.SpellChecker1.Dictionaries.Add(SpellCheckerISpellDictionary1)
        Me.SpellChecker1.ParentContainer = Nothing
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.Location = New System.Drawing.Point(115, 246)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.Properties.Appearance.Options.UseFont = True
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.txtSubject, True)
        Me.txtSubject.Size = New System.Drawing.Size(422, 22)
        Me.SpellChecker1.SetSpellCheckerOptions(Me.txtSubject, OptionsSpelling1)
        Me.txtSubject.TabIndex = 2
        '
        'txtDescription
        '
        Me.txtDescription.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft
        Me.txtDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Appearance.Text.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Appearance.Text.Options.UseFont = True
        Me.txtDescription.Location = New System.Drawing.Point(14, 278)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden
        Me.SpellChecker1.SetShowSpellCheckMenu(Me.txtDescription, False)
        Me.txtDescription.Size = New System.Drawing.Size(524, 90)
        Me.txtDescription.SpellChecker = Me.SpellChecker1
        Me.SpellChecker1.SetSpellCheckerOptions(Me.txtDescription, OptionsSpelling2)
        Me.txtDescription.TabIndex = 3
        Me.txtDescription.Tag = "DontTranslate"
        '
        'lblRemindersLevel
        '
        Me.lblRemindersLevel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemindersLevel.Appearance.Options.UseFont = True
        Me.lblRemindersLevel.Location = New System.Drawing.Point(15, 189)
        Me.lblRemindersLevel.Name = "lblRemindersLevel"
        Me.lblRemindersLevel.Size = New System.Drawing.Size(57, 15)
        Me.lblRemindersLevel.TabIndex = 0
        Me.lblRemindersLevel.Text = "Mahnstufe"
        '
        'lblRemindersSubjectLine
        '
        Me.lblRemindersSubjectLine.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemindersSubjectLine.Appearance.Options.UseFont = True
        Me.lblRemindersSubjectLine.Location = New System.Drawing.Point(15, 249)
        Me.lblRemindersSubjectLine.Name = "lblRemindersSubjectLine"
        Me.lblRemindersSubjectLine.Size = New System.Drawing.Size(35, 15)
        Me.lblRemindersSubjectLine.TabIndex = 0
        Me.lblRemindersSubjectLine.Text = "Betreff"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Appearance.Options.UseFont = True
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(356, 375)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 27)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Speichern"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Appearance.Options.UseFont = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(450, 375)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 27)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Schliessen"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Appearance.Options.UseFont = True
        Me.btnPrint.Enabled = False
        Me.btnPrint.Location = New System.Drawing.Point(14, 375)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 27)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Drucken..."
        '
        'chkIsInactiveReminder
        '
        Me.chkIsInactiveReminder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIsInactiveReminder.Location = New System.Drawing.Point(349, 10)
        Me.chkIsInactiveReminder.Name = "chkIsInactiveReminder"
        Me.chkIsInactiveReminder.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsInactiveReminder.Properties.Appearance.Options.UseFont = True
        Me.chkIsInactiveReminder.Properties.AutoWidth = True
        Me.chkIsInactiveReminder.Properties.Caption = "Nicht mehr Mahnen"
        Me.chkIsInactiveReminder.Size = New System.Drawing.Size(130, 20)
        Me.chkIsInactiveReminder.TabIndex = 5
        '
        'datReminderDate
        '
        Me.datReminderDate.EditValue = Nothing
        Me.datReminderDate.Location = New System.Drawing.Point(115, 216)
        Me.datReminderDate.Name = "datReminderDate"
        Me.datReminderDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datReminderDate.Properties.Appearance.Options.UseFont = True
        Me.datReminderDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datReminderDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datReminderDate.Size = New System.Drawing.Size(117, 22)
        Me.datReminderDate.TabIndex = 0
        '
        'datRemindersLimitDate
        '
        Me.datRemindersLimitDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datRemindersLimitDate.EditValue = Nothing
        Me.datRemindersLimitDate.Location = New System.Drawing.Point(421, 216)
        Me.datRemindersLimitDate.Name = "datRemindersLimitDate"
        Me.datRemindersLimitDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datRemindersLimitDate.Properties.Appearance.Options.UseFont = True
        Me.datRemindersLimitDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datRemindersLimitDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datRemindersLimitDate.Size = New System.Drawing.Size(117, 22)
        Me.datRemindersLimitDate.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(333, 219)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(74, 15)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Neue Frist bis:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(15, 225)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(69, 15)
        Me.LabelControl2.TabIndex = 0
        Me.LabelControl2.Text = "Mahndatum:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblInvoiceDate, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblInvoiceNumber, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblInvoiceNumberText, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(80, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(254, 25)
        Me.TableLayoutPanel1.TabIndex = 8
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceDate.Appearance.Options.UseFont = True
        Me.lblInvoiceDate.Location = New System.Drawing.Point(135, 3)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(81, 17)
        Me.lblInvoiceDate.TabIndex = 0
        Me.lblInvoiceDate.Tag = "DontTRanslate"
        Me.lblInvoiceDate.Text = "vom 1.1.2009"
        '
        'lblInvoiceNumber
        '
        Me.lblInvoiceNumber.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceNumber.Appearance.Options.UseFont = True
        Me.lblInvoiceNumber.Location = New System.Drawing.Point(101, 3)
        Me.lblInvoiceNumber.Name = "lblInvoiceNumber"
        Me.lblInvoiceNumber.Size = New System.Drawing.Size(28, 17)
        Me.lblInvoiceNumber.TabIndex = 0
        Me.lblInvoiceNumber.Tag = "dontTRanslate"
        Me.lblInvoiceNumber.Text = "1234"
        '
        'lblInvoiceNumberText
        '
        Me.lblInvoiceNumberText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceNumberText.Appearance.Options.UseFont = True
        Me.lblInvoiceNumberText.Location = New System.Drawing.Point(3, 3)
        Me.lblInvoiceNumberText.Name = "lblInvoiceNumberText"
        Me.lblInvoiceNumberText.Size = New System.Drawing.Size(92, 17)
        Me.lblInvoiceNumberText.TabIndex = 0
        Me.lblInvoiceNumberText.Text = "Rechnung Nr.: "
        '
        'lblInvoiceText
        '
        Me.lblInvoiceText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInvoiceText.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceText.Appearance.Options.UseFont = True
        Me.lblInvoiceText.Appearance.Options.UseTextOptions = True
        Me.lblInvoiceText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lblInvoiceText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblInvoiceText.AutoEllipsis = True
        Me.lblInvoiceText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblInvoiceText.Location = New System.Drawing.Point(80, 39)
        Me.lblInvoiceText.Name = "lblInvoiceText"
        Me.lblInvoiceText.Size = New System.Drawing.Size(428, 32)
        Me.lblInvoiceText.TabIndex = 9
        Me.lblInvoiceText.Text = "Rechnungs-Text"
        '
        'PanelControl1
        '
        Me.PanelControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl1.Controls.Add(Me.PictureEdit1)
        Me.PanelControl1.Controls.Add(Me.lstRemindersList)
        Me.PanelControl1.Controls.Add(Me.TableLayoutPanel1)
        Me.PanelControl1.Controls.Add(Me.chkIsInactiveReminder)
        Me.PanelControl1.Controls.Add(Me.lblInvoiceText)
        Me.PanelControl1.Controls.Add(Me.btnNextReminderstep)
        Me.PanelControl1.Location = New System.Drawing.Point(15, 14)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(522, 155)
        Me.PanelControl1.TabIndex = 10
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Push_Pin_and_Note_32x32
        Me.PictureEdit1.Location = New System.Drawing.Point(12, 12)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Size = New System.Drawing.Size(65, 48)
        Me.PictureEdit1.TabIndex = 11
        '
        'lstRemindersList
        '
        Me.lstRemindersList.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstRemindersList.Appearance.Options.UseFont = True
        Me.lstRemindersList.Items.AddRange(New Object() {"1. Mahnung (1.1.2009)", "2. Mahnung (24.11.2009)"})
        Me.lstRemindersList.Location = New System.Drawing.Point(15, 78)
        Me.lstRemindersList.Name = "lstRemindersList"
        Me.lstRemindersList.Size = New System.Drawing.Size(231, 70)
        Me.lstRemindersList.TabIndex = 0
        '
        'btnNextReminderstep
        '
        Me.btnNextReminderstep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextReminderstep.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextReminderstep.Appearance.Options.UseFont = True
        Me.btnNextReminderstep.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Add_16x16
        Me.btnNextReminderstep.Location = New System.Drawing.Point(340, 104)
        Me.btnNextReminderstep.Name = "btnNextReminderstep"
        Me.btnNextReminderstep.Size = New System.Drawing.Size(168, 45)
        Me.btnNextReminderstep.TabIndex = 1
        Me.btnNextReminderstep.Text = "Nächste Mahnstufe..."
        '
        'lblRemindersLeveltext
        '
        Me.lblRemindersLeveltext.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemindersLeveltext.Appearance.Options.UseFont = True
        Me.lblRemindersLeveltext.Location = New System.Drawing.Point(115, 189)
        Me.lblRemindersLeveltext.Name = "lblRemindersLeveltext"
        Me.lblRemindersLeveltext.Size = New System.Drawing.Size(57, 15)
        Me.lblRemindersLeveltext.TabIndex = 11
        Me.lblRemindersLeveltext.Text = "Mahnstufe"
        '
        'btndelete
        '
        Me.btndelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btndelete.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btndelete.Appearance.Options.UseFont = True
        Me.btndelete.Enabled = False
        Me.btndelete.Location = New System.Drawing.Point(261, 375)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(87, 27)
        Me.btndelete.TabIndex = 6
        Me.btndelete.Text = "Löschen"
        '
        'frmReminder
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 416)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.lblRemindersLeveltext)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.datRemindersLimitDate)
        Me.Controls.Add(Me.datReminderDate)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblRemindersSubjectLine)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.lblRemindersLevel)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(536, 373)
        Me.Name = "frmReminder"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mahnungen"
        CType(Me.txtSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsInactiveReminder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datReminderDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datReminderDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datRemindersLimitDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datRemindersLimitDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstRemindersList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SpellChecker1 As DevExpress.XtraSpellChecker.SpellChecker
    Friend WithEvents lblRemindersLevel As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblRemindersSubjectLine As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNextReminderstep As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtSubject As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkIsInactiveReminder As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents datReminderDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents datRemindersLimitDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblInvoiceNumberText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblInvoiceDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblInvoiceNumber As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblInvoiceText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lstRemindersList As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents lblRemindersLeveltext As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btndelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtDescription As DevExpress.XtraRichEdit.RichEditControl
End Class
