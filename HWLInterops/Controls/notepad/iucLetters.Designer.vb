Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucLetters
    Inherits mainControlContainer

    'iucnotepadmain overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(iucLetters))
        Me.popupControlContainer1 = New DevExpress.XtraBars.PopupControlContainer()
        Me.pnlEditorForm = New System.Windows.Forms.Panel()
        Me.rtfmain = New ClausSoftware.HWLInterops.uclRTFEditor()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rtbSubject = New System.Windows.Forms.RichTextBox()
        Me.lblsubject = New DevExpress.XtraEditors.LabelControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.datDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblDate = New DevExpress.XtraEditors.LabelControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip()
        Me.mnucut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip()
        Me.lblLetterDescription = New System.Windows.Forms.Label()
        Me.btnOpenLetter = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNewLetter = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnResetAdress = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSearchAdress = New DevExpress.XtraEditors.SimpleButton()
        Me.txtAdresswindow = New DevExpress.XtraEditors.MemoEdit()
        Me.lblAddresswindow = New DevExpress.XtraEditors.LabelControl()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblCreatedAtValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblLastChangedAtValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblLastChangedAt = New DevExpress.XtraEditors.LabelControl()
        Me.lblcreatedAt = New DevExpress.XtraEditors.LabelControl()
        Me.txtTagWord = New DevExpress.XtraEditors.TextEdit()
        Me.Panel5 = New System.Windows.Forms.Panel()
        CType(Me.popupControlContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEditorForm.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.datDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.txtAdresswindow.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.txtTagWord.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.popupControlContainer1.Location = New System.Drawing.Point(0, 0)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(50, 50)
        Me.popupControlContainer1.TabIndex = 6
        Me.popupControlContainer1.Visible = False
        '
        'pnlEditorForm
        '
        Me.pnlEditorForm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEditorForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEditorForm.Controls.Add(Me.rtfmain)
        Me.pnlEditorForm.Controls.Add(Me.TableLayoutPanel2)
        Me.pnlEditorForm.Location = New System.Drawing.Point(3, 99)
        Me.pnlEditorForm.Name = "pnlEditorForm"
        Me.pnlEditorForm.Size = New System.Drawing.Size(1111, 683)
        Me.pnlEditorForm.TabIndex = 17
        '
        'rtfmain
        '
        Me.rtfmain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtfmain.Location = New System.Drawing.Point(-1, 42)
        Me.rtfmain.Name = "rtfmain"
        Me.rtfmain.RTFText = resources.GetString("rtfmain.RTFText")
        Me.rtfmain.Size = New System.Drawing.Size(1112, 640)
        Me.rtfmain.TabIndex = 29
        Me.rtfmain.Tag = "DontTranslate"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(33, 3)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(950, 35)
        Me.TableLayoutPanel2.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rtbSubject)
        Me.Panel1.Controls.Add(Me.lblsubject)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(749, 35)
        Me.Panel1.TabIndex = 0
        '
        'rtbSubject
        '
        Me.rtbSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbSubject.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbSubject.Location = New System.Drawing.Point(92, 5)
        Me.rtbSubject.Name = "rtbSubject"
        Me.rtbSubject.Size = New System.Drawing.Size(653, 24)
        Me.rtbSubject.TabIndex = 0
        Me.rtbSubject.Tag = "DontTranslate"
        Me.rtbSubject.Text = ""
        '
        'lblsubject
        '
        Me.lblsubject.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsubject.Appearance.Options.UseFont = True
        Me.lblsubject.Location = New System.Drawing.Point(17, 11)
        Me.lblsubject.Name = "lblsubject"
        Me.lblsubject.Size = New System.Drawing.Size(38, 15)
        Me.lblsubject.TabIndex = 27
        Me.lblsubject.Text = "Betreff:"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.datDate)
        Me.Panel3.Controls.Add(Me.lblDate)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(749, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(201, 35)
        Me.Panel3.TabIndex = 1
        '
        'datDate
        '
        Me.datDate.EditValue = Nothing
        Me.datDate.Location = New System.Drawing.Point(95, 4)
        Me.datDate.Name = "datDate"
        Me.datDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datDate.Size = New System.Drawing.Size(100, 20)
        Me.datDate.TabIndex = 26
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Appearance.Options.UseFont = True
        Me.lblDate.Location = New System.Drawing.Point(18, 7)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(36, 15)
        Me.lblDate.TabIndex = 25
        Me.lblDate.Text = "Datum"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnucut, Me.mnuCopy, Me.mnuInsert})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(149, 70)
        '
        'mnucut
        '
        Me.mnucut.Image = CType(resources.GetObject("mnucut.Image"), System.Drawing.Image)
        Me.mnucut.Name = "mnucut"
        Me.mnucut.Size = New System.Drawing.Size(148, 22)
        Me.mnucut.Text = "Ausschneiden"
        '
        'mnuCopy
        '
        Me.mnuCopy.Image = CType(resources.GetObject("mnuCopy.Image"), System.Drawing.Image)
        Me.mnuCopy.Name = "mnuCopy"
        Me.mnuCopy.Size = New System.Drawing.Size(148, 22)
        Me.mnuCopy.Text = "Kopieren"
        '
        'mnuInsert
        '
        Me.mnuInsert.Image = CType(resources.GetObject("mnuInsert.Image"), System.Drawing.Image)
        Me.mnuInsert.Name = "mnuInsert"
        Me.mnuInsert.Size = New System.Drawing.Size(148, 22)
        Me.mnuInsert.Text = "Einfügen"
        '
        'lblLetterDescription
        '
        Me.lblLetterDescription.AutoSize = True
        Me.lblLetterDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLetterDescription.Location = New System.Drawing.Point(3, 8)
        Me.lblLetterDescription.Name = "lblLetterDescription"
        Me.lblLetterDescription.Size = New System.Drawing.Size(69, 15)
        Me.lblLetterDescription.TabIndex = 24
        Me.lblLetterDescription.Text = "Schlagwort:"
        '
        'btnOpenLetter
        '
        Me.btnOpenLetter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenLetter.Appearance.Options.UseImage = True
        Me.btnOpenLetter.Appearance.Options.UseTextOptions = True
        Me.btnOpenLetter.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnOpenLetter.Image = CType(resources.GetObject("btnOpenLetter.Image"), System.Drawing.Image)
        Me.btnOpenLetter.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnOpenLetter.Location = New System.Drawing.Point(100, 3)
        Me.btnOpenLetter.Name = "btnOpenLetter"
        Me.btnOpenLetter.Size = New System.Drawing.Size(77, 76)
        Me.btnOpenLetter.TabIndex = 18
        Me.btnOpenLetter.Text = "Öffnen"
        '
        'btnNewLetter
        '
        Me.btnNewLetter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewLetter.Appearance.Options.UseImage = True
        Me.btnNewLetter.Appearance.Options.UseTextOptions = True
        Me.btnNewLetter.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Me.btnNewLetter.Image = CType(resources.GetObject("btnNewLetter.Image"), System.Drawing.Image)
        Me.btnNewLetter.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnNewLetter.Location = New System.Drawing.Point(23, 3)
        Me.btnNewLetter.Name = "btnNewLetter"
        Me.btnNewLetter.Size = New System.Drawing.Size(71, 76)
        Me.btnNewLetter.TabIndex = 18
        Me.btnNewLetter.Text = "Neu"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1115, 93)
        Me.TableLayoutPanel1.TabIndex = 25
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnResetAdress)
        Me.Panel2.Controls.Add(Me.btnSearchAdress)
        Me.Panel2.Controls.Add(Me.txtAdresswindow)
        Me.Panel2.Controls.Add(Me.lblAddresswindow)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(344, 87)
        Me.Panel2.TabIndex = 0
        '
        'btnResetAdress
        '
        Me.btnResetAdress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResetAdress.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAdress.Appearance.Options.UseFont = True
        Me.btnResetAdress.Location = New System.Drawing.Point(232, 52)
        Me.btnResetAdress.Name = "btnResetAdress"
        Me.btnResetAdress.Size = New System.Drawing.Size(91, 27)
        Me.btnResetAdress.TabIndex = 24
        Me.btnResetAdress.Text = "Zurücksetzen"
        '
        'btnSearchAdress
        '
        Me.btnSearchAdress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchAdress.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchAdress.Appearance.Options.UseFont = True
        Me.btnSearchAdress.Image = CType(resources.GetObject("btnSearchAdress.Image"), System.Drawing.Image)
        Me.btnSearchAdress.Location = New System.Drawing.Point(232, 21)
        Me.btnSearchAdress.Name = "btnSearchAdress"
        Me.btnSearchAdress.Size = New System.Drawing.Size(91, 27)
        Me.btnSearchAdress.TabIndex = 23
        Me.btnSearchAdress.Text = "Suche..."
        '
        'txtAdresswindow
        '
        Me.txtAdresswindow.Location = New System.Drawing.Point(4, 19)
        Me.txtAdresswindow.Name = "txtAdresswindow"
        Me.txtAdresswindow.Properties.NullValuePrompt = "Wählen Sie eine Adresse oder geben Sie eine ein."
        Me.txtAdresswindow.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtAdresswindow.Size = New System.Drawing.Size(202, 64)
        Me.txtAdresswindow.TabIndex = 22
        '
        'lblAddresswindow
        '
        Me.lblAddresswindow.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddresswindow.Appearance.Options.UseFont = True
        Me.lblAddresswindow.Location = New System.Drawing.Point(4, 4)
        Me.lblAddresswindow.Name = "lblAddresswindow"
        Me.lblAddresswindow.Size = New System.Drawing.Size(71, 15)
        Me.lblAddresswindow.TabIndex = 21
        Me.lblAddresswindow.Text = "Adressfenster"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblCreatedAtValue)
        Me.Panel4.Controls.Add(Me.lblLastChangedAtValue)
        Me.Panel4.Controls.Add(Me.lblLastChangedAt)
        Me.Panel4.Controls.Add(Me.lblcreatedAt)
        Me.Panel4.Controls.Add(Me.txtTagWord)
        Me.Panel4.Controls.Add(Me.lblLetterDescription)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(353, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(573, 87)
        Me.Panel4.TabIndex = 1
        '
        'lblCreatedAtValue
        '
        Me.lblCreatedAtValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCreatedAtValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAtValue.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.lblCreatedAtValue.Appearance.Options.UseFont = True
        Me.lblCreatedAtValue.Appearance.Options.UseForeColor = True
        Me.lblCreatedAtValue.Location = New System.Drawing.Point(93, 42)
        Me.lblCreatedAtValue.Name = "lblCreatedAtValue"
        Me.lblCreatedAtValue.Size = New System.Drawing.Size(46, 15)
        Me.lblCreatedAtValue.TabIndex = 27
        Me.lblCreatedAtValue.Tag = "DontTranslate"
        Me.lblCreatedAtValue.Text = "-Datum-"
        '
        'lblLastChangedAtValue
        '
        Me.lblLastChangedAtValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLastChangedAtValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastChangedAtValue.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.lblLastChangedAtValue.Appearance.Options.UseFont = True
        Me.lblLastChangedAtValue.Appearance.Options.UseForeColor = True
        Me.lblLastChangedAtValue.Location = New System.Drawing.Point(93, 61)
        Me.lblLastChangedAtValue.Name = "lblLastChangedAtValue"
        Me.lblLastChangedAtValue.Size = New System.Drawing.Size(46, 15)
        Me.lblLastChangedAtValue.TabIndex = 27
        Me.lblLastChangedAtValue.Tag = "DontTranslate"
        Me.lblLastChangedAtValue.Text = "-Datum-"
        '
        'lblLastChangedAt
        '
        Me.lblLastChangedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLastChangedAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastChangedAt.Appearance.Options.UseFont = True
        Me.lblLastChangedAt.Location = New System.Drawing.Point(6, 61)
        Me.lblLastChangedAt.Name = "lblLastChangedAt"
        Me.lblLastChangedAt.Size = New System.Drawing.Size(71, 15)
        Me.lblLastChangedAt.TabIndex = 26
        Me.lblLastChangedAt.Text = "Geändert am:"
        '
        'lblcreatedAt
        '
        Me.lblcreatedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblcreatedAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcreatedAt.Appearance.Options.UseFont = True
        Me.lblcreatedAt.Location = New System.Drawing.Point(6, 42)
        Me.lblcreatedAt.Name = "lblcreatedAt"
        Me.lblcreatedAt.Size = New System.Drawing.Size(71, 15)
        Me.lblcreatedAt.TabIndex = 26
        Me.lblcreatedAt.Text = "Angelegt am:"
        '
        'txtTagWord
        '
        Me.txtTagWord.Location = New System.Drawing.Point(113, 6)
        Me.txtTagWord.Name = "txtTagWord"
        Me.txtTagWord.Size = New System.Drawing.Size(238, 20)
        Me.txtTagWord.TabIndex = 25
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnOpenLetter)
        Me.Panel5.Controls.Add(Me.btnNewLetter)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(932, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(180, 87)
        Me.Panel5.TabIndex = 2
        '
        'iucLetters
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.pnlEditorForm)
        Me.Name = "iucLetters"
        Me.Size = New System.Drawing.Size(1115, 782)
        CType(Me.popupControlContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEditorForm.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.datDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txtAdresswindow.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.txtTagWord.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents popupControlContainer1 As DevExpress.XtraBars.PopupControlContainer
    Friend WithEvents pnlEditorForm As System.Windows.Forms.Panel
    Friend WithEvents btnNewLetter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOpenLetter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents rtbSubject As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnucut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLetterDescription As System.Windows.Forms.Label
    Friend WithEvents lblDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblsubject As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rtfmain As ClausSoftware.HWLInterops.uclRTFEditor
    Friend WithEvents datDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblAddresswindow As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnResetAdress As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSearchAdress As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtAdresswindow As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtTagWord As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCreatedAtValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLastChangedAtValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLastChangedAt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblcreatedAt As DevExpress.XtraEditors.LabelControl

End Class
