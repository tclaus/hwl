Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucAddressBook
    Inherits mainControlContainer

    'iucAdressBook overrides dispose to clean up the component list.
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.tabEditPanel = New DevExpress.XtraTab.XtraTabControl()
        Me.xtpCommonContact = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlBaseContactData = New System.Windows.Forms.Panel()
        Me.chkIsActiveContact = New DevExpress.XtraEditors.CheckEdit()
        Me.txtContactID = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblKey_ = New System.Windows.Forms.Label()
        Me.btnOpenInGoogeMaps = New DevExpress.XtraEditors.SimpleButton()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblStreet = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblContactName = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblZipCode = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.txtZipCode = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtCompany = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtCountry = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtLastName = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtFirstName = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtStreet = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtTown = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtEmail = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtTelefon1 = New DevExpress.XtraEditors.ButtonEdit()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnNewDocumentFromAddress = New DevExpress.XtraEditors.SimpleButton()
        Me.MemoExEdit1 = New DevExpress.XtraEditors.MemoExEdit()
        Me.btnOpenJournal = New DevExpress.XtraEditors.SimpleButton()
        Me.txtEbayID = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblKey = New System.Windows.Forms.Label()
        Me.ButtonEdit1 = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCustomersDiscountValue = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtMemo = New DevExpress.XtraEditors.MemoExEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRabattValue = New System.Windows.Forms.Label()
        Me.lblMemo = New System.Windows.Forms.Label()
        Me.ButtonEdit2 = New DevExpress.XtraEditors.ButtonEdit()
        Me.tabInformation = New DevExpress.XtraTab.XtraTabControl()
        Me.tbpInvoiceAdress = New DevExpress.XtraTab.XtraTabPage()
        Me.btnResetInvoiceAdress = New DevExpress.XtraEditors.SimpleButton()
        Me.txtInvoiceAdress = New DevExpress.XtraEditors.MemoEdit()
        Me.tbpDeliveryAdress = New DevExpress.XtraTab.XtraTabPage()
        Me.chkLinkDeliveryAdress = New DevExpress.XtraEditors.CheckEdit()
        Me.txtDeliveryAdress = New DevExpress.XtraEditors.MemoEdit()
        Me.btnResetdeliveryAdress = New DevExpress.XtraEditors.SimpleButton()
        Me.tbpNotes = New DevExpress.XtraTab.XtraTabPage()
        Me.txtNotes = New DevExpress.XtraEditors.MemoEdit()
        Me.tbpHistory = New DevExpress.XtraTab.XtraTabPage()
        Me.grdHistory = New DevExpress.XtraGrid.GridControl()
        Me.grvHistoryView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnEditHistory = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddHistory = New DevExpress.XtraEditors.SimpleButton()
        Me.xtpDetails = New DevExpress.XtraTab.XtraTabPage()
        Me.lblLastChangedAtValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblCreatedAtValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblLastChangedAt = New DevExpress.XtraEditors.LabelControl()
        Me.lblCreatedAt = New DevExpress.XtraEditors.LabelControl()
        Me.txtTargetPaydateDays = New DevExpress.XtraEditors.TextEdit()
        Me.lblDays = New DevExpress.XtraEditors.LabelControl()
        Me.chkEnableTargetPayDate = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPhone2 = New System.Windows.Forms.Label()
        Me.txtPhone2 = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblWorkOn = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.txtfax = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtWorkOn = New DevExpress.XtraEditors.ButtonEdit()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.xtpBankData = New DevExpress.XtraTab.XtraTabPage()
        Me.txtUstID = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblBankName = New System.Windows.Forms.Label()
        Me.lblLocalTaxID = New System.Windows.Forms.Label()
        Me.txtBankName = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblBankIBAN = New System.Windows.Forms.Label()
        Me.txtBankKonto = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtIBAN = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtBankLeitzahl = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblBankID = New System.Windows.Forms.Label()
        Me.lblAccountNumber = New System.Windows.Forms.Label()
        Me.chkohneMWST = New System.Windows.Forms.CheckBox()
        Me.chkLetterReceiver = New System.Windows.Forms.CheckBox()
        Me.uicCommonGrid = New ClausSoftware.HWLInterops.uicCommonGrid()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnMaximizeworkspace = New DevExpress.XtraEditors.SimpleButton()
        Me.IucSearchPanel1 = New ClausSoftware.HWLInterops.iucSearchPanel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSearchIcons = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.tabEditPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEditPanel.SuspendLayout()
        Me.xtpCommonContact.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlBaseContactData.SuspendLayout()
        CType(Me.chkIsActiveContact.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContactID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtZipCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCompany.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLastName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStreet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTown.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefon1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.MemoExEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEbayID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCustomersDiscountValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMemo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInformation.SuspendLayout()
        Me.tbpInvoiceAdress.SuspendLayout()
        CType(Me.txtInvoiceAdress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpDeliveryAdress.SuspendLayout()
        CType(Me.chkLinkDeliveryAdress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDeliveryAdress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpNotes.SuspendLayout()
        CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpHistory.SuspendLayout()
        CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvHistoryView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xtpDetails.SuspendLayout()
        CType(Me.txtTargetPaydateDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEnableTargetPayDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPhone2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkOn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.xtpBankData.SuspendLayout()
        CType(Me.txtUstID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBankName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBankKonto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIBAN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBankLeitzahl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.tabEditPanel)
        Me.SplitContainerControl1.Panel1.MinSize = 25
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.uicCommonGrid)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.PanelControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(926, 684)
        Me.SplitContainerControl1.SplitterPosition = 334
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'tabEditPanel
        '
        Me.tabEditPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabEditPanel.Appearance.BackColor = System.Drawing.Color.White
        Me.tabEditPanel.Appearance.Options.UseBackColor = True
        Me.tabEditPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.tabEditPanel.Location = New System.Drawing.Point(0, 0)
        Me.tabEditPanel.Name = "tabEditPanel"
        Me.tabEditPanel.SelectedTabPage = Me.xtpCommonContact
        Me.tabEditPanel.Size = New System.Drawing.Size(921, 335)
        Me.tabEditPanel.TabIndex = 130
        Me.tabEditPanel.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtpCommonContact, Me.xtpDetails})
        '
        'xtpCommonContact
        '
        Me.xtpCommonContact.Controls.Add(Me.TableLayoutPanel1)
        Me.xtpCommonContact.Name = "xtpCommonContact"
        Me.xtpCommonContact.Size = New System.Drawing.Size(915, 307)
        Me.xtpCommonContact.Text = "Allgemein"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.2766!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.7234!))
        Me.TableLayoutPanel1.Controls.Add(Me.pnlBaseContactData, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(915, 307)
        Me.TableLayoutPanel1.TabIndex = 144
        '
        'pnlBaseContactData
        '
        Me.pnlBaseContactData.AllowDrop = True
        Me.pnlBaseContactData.Controls.Add(Me.chkIsActiveContact)
        Me.pnlBaseContactData.Controls.Add(Me.txtContactID)
        Me.pnlBaseContactData.Controls.Add(Me.lblKey_)
        Me.pnlBaseContactData.Controls.Add(Me.btnOpenInGoogeMaps)
        Me.pnlBaseContactData.Controls.Add(Me.lblCountry)
        Me.pnlBaseContactData.Controls.Add(Me.lblPhone)
        Me.pnlBaseContactData.Controls.Add(Me.lblStreet)
        Me.pnlBaseContactData.Controls.Add(Me.lblEmail)
        Me.pnlBaseContactData.Controls.Add(Me.lblContactName)
        Me.pnlBaseContactData.Controls.Add(Me.lblCity)
        Me.pnlBaseContactData.Controls.Add(Me.lblZipCode)
        Me.pnlBaseContactData.Controls.Add(Me.lblCompany)
        Me.pnlBaseContactData.Controls.Add(Me.txtZipCode)
        Me.pnlBaseContactData.Controls.Add(Me.txtCompany)
        Me.pnlBaseContactData.Controls.Add(Me.txtCountry)
        Me.pnlBaseContactData.Controls.Add(Me.txtLastName)
        Me.pnlBaseContactData.Controls.Add(Me.txtFirstName)
        Me.pnlBaseContactData.Controls.Add(Me.txtStreet)
        Me.pnlBaseContactData.Controls.Add(Me.txtTown)
        Me.pnlBaseContactData.Controls.Add(Me.txtEmail)
        Me.pnlBaseContactData.Controls.Add(Me.txtTelefon1)
        Me.pnlBaseContactData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBaseContactData.Location = New System.Drawing.Point(0, 0)
        Me.pnlBaseContactData.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlBaseContactData.Name = "pnlBaseContactData"
        Me.pnlBaseContactData.Size = New System.Drawing.Size(469, 307)
        Me.pnlBaseContactData.TabIndex = 0
        '
        'chkIsActiveContact
        '
        Me.chkIsActiveContact.Location = New System.Drawing.Point(9, 242)
        Me.chkIsActiveContact.Name = "chkIsActiveContact"
        Me.chkIsActiveContact.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsActiveContact.Properties.Appearance.Options.UseFont = True
        Me.chkIsActiveContact.Properties.Caption = "Aktiver Kontakt"
        Me.chkIsActiveContact.Size = New System.Drawing.Size(198, 20)
        Me.chkIsActiveContact.TabIndex = 180
        '
        'txtContactID
        '
        Me.txtContactID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContactID.Location = New System.Drawing.Point(119, 7)
        Me.txtContactID.Name = "txtContactID"
        Me.txtContactID.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactID.Properties.Appearance.Options.UseFont = True
        SerializableAppearanceObject1.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.view
        SerializableAppearanceObject1.Options.UseImage = True
        Me.txtContactID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Global.ClausSoftware.HWLInterops.My.Resources.Resources.view, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "Startet  eine Suche", Nothing, Nothing, False)})
        Me.txtContactID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtContactID.Properties.ReadOnly = True
        Me.txtContactID.Size = New System.Drawing.Size(326, 22)
        Me.txtContactID.TabIndex = 0
        Me.txtContactID.Tag = "ContactDisplayID"
        '
        'lblKey_
        '
        Me.lblKey_.AutoSize = True
        Me.lblKey_.Location = New System.Drawing.Point(7, 12)
        Me.lblKey_.Name = "lblKey_"
        Me.lblKey_.Size = New System.Drawing.Size(88, 15)
        Me.lblKey_.TabIndex = 178
        Me.lblKey_.Text = "Adressnummer"
        '
        'btnOpenInGoogeMaps
        '
        Me.btnOpenInGoogeMaps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenInGoogeMaps.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenInGoogeMaps.Appearance.Options.UseFont = True
        Me.btnOpenInGoogeMaps.Location = New System.Drawing.Point(359, 244)
        Me.btnOpenInGoogeMaps.Name = "btnOpenInGoogeMaps"
        Me.btnOpenInGoogeMaps.Size = New System.Drawing.Size(87, 27)
        Me.btnOpenInGoogeMaps.TabIndex = 9
        Me.btnOpenInGoogeMaps.Text = "Karte öffnen"
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(7, 155)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(33, 15)
        Me.lblCountry.TabIndex = 182
        Me.lblCountry.Text = "Land"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(7, 181)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(47, 15)
        Me.lblPhone.TabIndex = 183
        Me.lblPhone.Text = "Telefon"
        '
        'lblStreet
        '
        Me.lblStreet.AutoSize = True
        Me.lblStreet.Location = New System.Drawing.Point(7, 99)
        Me.lblStreet.Name = "lblStreet"
        Me.lblStreet.Size = New System.Drawing.Size(43, 15)
        Me.lblStreet.TabIndex = 180
        Me.lblStreet.Text = "Strasse"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(7, 211)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(36, 15)
        Me.lblEmail.TabIndex = 187
        Me.lblEmail.Text = "Email"
        '
        'lblContactName
        '
        Me.lblContactName.AutoSize = True
        Me.lblContactName.Location = New System.Drawing.Point(7, 73)
        Me.lblContactName.Name = "lblContactName"
        Me.lblContactName.Size = New System.Drawing.Size(95, 15)
        Me.lblContactName.TabIndex = 188
        Me.lblContactName.Text = "Ansprechpartner"
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(195, 126)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(24, 15)
        Me.lblCity.TabIndex = 186
        Me.lblCity.Text = "Ort"
        '
        'lblZipCode
        '
        Me.lblZipCode.AutoSize = True
        Me.lblZipCode.Location = New System.Drawing.Point(7, 126)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(67, 15)
        Me.lblZipCode.TabIndex = 184
        Me.lblZipCode.Text = "Postleitzahl"
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Location = New System.Drawing.Point(8, 44)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(37, 15)
        Me.lblCompany.TabIndex = 185
        Me.lblCompany.Text = "Firma"
        '
        'txtZipCode
        '
        Me.txtZipCode.AllowDrop = True
        Me.txtZipCode.EnterMoveNextControl = True
        Me.txtZipCode.Location = New System.Drawing.Point(119, 123)
        Me.txtZipCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipCode.Properties.Appearance.Options.UseFont = True
        Me.txtZipCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtZipCode.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None
        Me.txtZipCode.Properties.MaxLength = 25
        Me.txtZipCode.Size = New System.Drawing.Size(69, 22)
        Me.txtZipCode.TabIndex = 4
        Me.txtZipCode.Tag = "ZipCode"
        '
        'txtCompany
        '
        Me.txtCompany.AllowDrop = True
        Me.txtCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCompany.EnterMoveNextControl = True
        Me.txtCompany.Location = New System.Drawing.Point(119, 37)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompany.Properties.Appearance.Options.UseFont = True
        Me.txtCompany.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtCompany.Properties.MaxLength = 250
        Me.txtCompany.Size = New System.Drawing.Size(326, 22)
        Me.txtCompany.TabIndex = 1
        Me.txtCompany.Tag = "Company"
        '
        'txtCountry
        '
        Me.txtCountry.AllowDrop = True
        Me.txtCountry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCountry.EnterMoveNextControl = True
        Me.txtCountry.Location = New System.Drawing.Point(119, 152)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountry.Properties.Appearance.Options.UseFont = True
        Me.txtCountry.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtCountry.Properties.MaxLength = 250
        Me.txtCountry.Size = New System.Drawing.Size(326, 22)
        Me.txtCountry.TabIndex = 6
        Me.txtCountry.Tag = "Country"
        '
        'txtLastName
        '
        Me.txtLastName.AllowDrop = True
        Me.txtLastName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLastName.EnterMoveNextControl = True
        Me.txtLastName.Location = New System.Drawing.Point(287, 66)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Properties.Appearance.Options.UseFont = True
        Me.txtLastName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtLastName.Properties.MaxLength = 250
        Me.txtLastName.Size = New System.Drawing.Size(158, 22)
        Me.txtLastName.TabIndex = 3
        Me.txtLastName.Tag = "ContactsName"
        '
        'txtFirstName
        '
        Me.txtFirstName.AllowDrop = True
        Me.txtFirstName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFirstName.EnterMoveNextControl = True
        Me.txtFirstName.Location = New System.Drawing.Point(119, 66)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Properties.Appearance.Options.UseFont = True
        Me.txtFirstName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtFirstName.Properties.MaxLength = 250
        Me.txtFirstName.Size = New System.Drawing.Size(166, 22)
        Me.txtFirstName.TabIndex = 2
        Me.txtFirstName.Tag = "ContactsName"
        '
        'txtStreet
        '
        Me.txtStreet.AllowDrop = True
        Me.txtStreet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStreet.EnterMoveNextControl = True
        Me.txtStreet.Location = New System.Drawing.Point(119, 95)
        Me.txtStreet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 1)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreet.Properties.Appearance.Options.UseFont = True
        Me.txtStreet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtStreet.Properties.MaxLength = 250
        Me.txtStreet.Size = New System.Drawing.Size(326, 22)
        Me.txtStreet.TabIndex = 3
        Me.txtStreet.Tag = "Street"
        '
        'txtTown
        '
        Me.txtTown.AllowDrop = True
        Me.txtTown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTown.EnterMoveNextControl = True
        Me.txtTown.Location = New System.Drawing.Point(227, 123)
        Me.txtTown.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTown.Name = "txtTown"
        Me.txtTown.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTown.Properties.Appearance.Options.UseFont = True
        Me.txtTown.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtTown.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None
        Me.txtTown.Properties.MaxLength = 250
        Me.txtTown.Size = New System.Drawing.Size(219, 22)
        Me.txtTown.TabIndex = 5
        Me.txtTown.Tag = "Town"
        '
        'txtEmail
        '
        Me.txtEmail.AllowDrop = True
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.EnterMoveNextControl = True
        Me.txtEmail.Location = New System.Drawing.Point(119, 207)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Properties.Appearance.Options.UseFont = True
        Me.txtEmail.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Global.ClausSoftware.HWLInterops.My.Resources.Resources.Email, New DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E)), SerializableAppearanceObject2, "Sendet eine e-Mail an diesen Empfänger", "email", Nothing, False)})
        Me.txtEmail.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtEmail.Properties.MaxLength = 250
        Me.txtEmail.Size = New System.Drawing.Size(326, 22)
        Me.txtEmail.TabIndex = 8
        Me.txtEmail.Tag = "EMail"
        '
        'txtTelefon1
        '
        Me.txtTelefon1.AllowDrop = True
        Me.txtTelefon1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelefon1.EnterMoveNextControl = True
        Me.txtTelefon1.Location = New System.Drawing.Point(119, 179)
        Me.txtTelefon1.Margin = New System.Windows.Forms.Padding(3, 2, 2, 3)
        Me.txtTelefon1.Name = "txtTelefon1"
        Me.txtTelefon1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefon1.Properties.Appearance.Options.UseFont = True
        Me.txtTelefon1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtTelefon1.Properties.MaxLength = 250
        Me.txtTelefon1.Size = New System.Drawing.Size(326, 22)
        Me.txtTelefon1.TabIndex = 7
        Me.txtTelefon1.Tag = "Telefon1;Telefon2"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(469, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(446, 307)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PanelControl2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tabInformation, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(446, 307)
        Me.TableLayoutPanel2.TabIndex = 180
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btnNewDocumentFromAddress)
        Me.PanelControl2.Controls.Add(Me.MemoExEdit1)
        Me.PanelControl2.Controls.Add(Me.btnOpenJournal)
        Me.PanelControl2.Controls.Add(Me.txtEbayID)
        Me.PanelControl2.Controls.Add(Me.lblKey)
        Me.PanelControl2.Controls.Add(Me.ButtonEdit1)
        Me.PanelControl2.Controls.Add(Me.Label3)
        Me.PanelControl2.Controls.Add(Me.txtCustomersDiscountValue)
        Me.PanelControl2.Controls.Add(Me.txtMemo)
        Me.PanelControl2.Controls.Add(Me.Label1)
        Me.PanelControl2.Controls.Add(Me.Label2)
        Me.PanelControl2.Controls.Add(Me.lblRabattValue)
        Me.PanelControl2.Controls.Add(Me.lblMemo)
        Me.PanelControl2.Controls.Add(Me.ButtonEdit2)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 153)
        Me.PanelControl2.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(446, 154)
        Me.PanelControl2.TabIndex = 0
        '
        'btnNewDocumentFromAddress
        '
        Me.btnNewDocumentFromAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewDocumentFromAddress.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewDocumentFromAddress.Appearance.Options.UseFont = True
        Me.btnNewDocumentFromAddress.Location = New System.Drawing.Point(306, 127)
        Me.btnNewDocumentFromAddress.Name = "btnNewDocumentFromAddress"
        Me.btnNewDocumentFromAddress.Size = New System.Drawing.Size(122, 27)
        Me.btnNewDocumentFromAddress.TabIndex = 174
        Me.btnNewDocumentFromAddress.Text = "Neues Dokument..."
        '
        'MemoExEdit1
        '
        Me.MemoExEdit1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MemoExEdit1.EnterMoveNextControl = True
        Me.MemoExEdit1.Location = New System.Drawing.Point(140, 65)
        Me.MemoExEdit1.Name = "MemoExEdit1"
        Me.MemoExEdit1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MemoExEdit1.Properties.Appearance.Options.UseFont = True
        Me.MemoExEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.MemoExEdit1.Properties.ShowIcon = False
        Me.MemoExEdit1.Size = New System.Drawing.Size(288, 22)
        Me.MemoExEdit1.TabIndex = 2
        '
        'btnOpenJournal
        '
        Me.btnOpenJournal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenJournal.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenJournal.Appearance.Options.UseFont = True
        Me.btnOpenJournal.Location = New System.Drawing.Point(306, 94)
        Me.btnOpenJournal.Name = "btnOpenJournal"
        Me.btnOpenJournal.Size = New System.Drawing.Size(122, 27)
        Me.btnOpenJournal.TabIndex = 3
        Me.btnOpenJournal.Text = "Journal öffnen"
        Me.btnOpenJournal.ToolTip = "Öffnet das Journal mit einem Filter auf diesen Kontakt"
        '
        'txtEbayID
        '
        Me.txtEbayID.AllowDrop = True
        Me.txtEbayID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEbayID.EnterMoveNextControl = True
        Me.txtEbayID.Location = New System.Drawing.Point(140, 8)
        Me.txtEbayID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.txtEbayID.Name = "txtEbayID"
        Me.txtEbayID.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEbayID.Properties.Appearance.Options.UseFont = True
        Me.txtEbayID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtEbayID.Properties.MaxLength = 250
        Me.txtEbayID.Size = New System.Drawing.Size(288, 22)
        Me.txtEbayID.TabIndex = 0
        '
        'lblKey
        '
        Me.lblKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblKey.AutoSize = True
        Me.lblKey.BackColor = System.Drawing.Color.Transparent
        Me.lblKey.Location = New System.Drawing.Point(2, 11)
        Me.lblKey.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.lblKey.Name = "lblKey"
        Me.lblKey.Size = New System.Drawing.Size(114, 15)
        Me.lblKey.TabIndex = 171
        Me.lblKey.Text = "Eindeutige Kennung"
        '
        'ButtonEdit1
        '
        Me.ButtonEdit1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEdit1.EnterMoveNextControl = True
        Me.ButtonEdit1.Location = New System.Drawing.Point(140, 8)
        Me.ButtonEdit1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.ButtonEdit1.Name = "ButtonEdit1"
        Me.ButtonEdit1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEdit1.Properties.Appearance.Options.UseFont = True
        Me.ButtonEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ButtonEdit1.Size = New System.Drawing.Size(288, 22)
        Me.ButtonEdit1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(2, 69)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 15)
        Me.Label3.TabIndex = 173
        Me.Label3.Text = "Notiz / Anmerkungen"
        '
        'txtCustomersDiscountValue
        '
        Me.txtCustomersDiscountValue.AllowDrop = True
        Me.txtCustomersDiscountValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomersDiscountValue.EnterMoveNextControl = True
        Me.txtCustomersDiscountValue.Location = New System.Drawing.Point(140, 36)
        Me.txtCustomersDiscountValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.txtCustomersDiscountValue.Name = "txtCustomersDiscountValue"
        Me.txtCustomersDiscountValue.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomersDiscountValue.Properties.Appearance.Options.UseFont = True
        Me.txtCustomersDiscountValue.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtCustomersDiscountValue.Properties.MaxLength = 250
        Me.txtCustomersDiscountValue.Size = New System.Drawing.Size(288, 22)
        Me.txtCustomersDiscountValue.TabIndex = 1
        '
        'txtMemo
        '
        Me.txtMemo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMemo.EnterMoveNextControl = True
        Me.txtMemo.Location = New System.Drawing.Point(140, 65)
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemo.Properties.Appearance.Options.UseFont = True
        Me.txtMemo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtMemo.Properties.ShowIcon = False
        Me.txtMemo.Size = New System.Drawing.Size(288, 22)
        Me.txtMemo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(2, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 15)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Eindeutige Kennung"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(2, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "Rabattwert"
        '
        'lblRabattValue
        '
        Me.lblRabattValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRabattValue.AutoSize = True
        Me.lblRabattValue.BackColor = System.Drawing.Color.Transparent
        Me.lblRabattValue.Location = New System.Drawing.Point(2, 39)
        Me.lblRabattValue.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.lblRabattValue.Name = "lblRabattValue"
        Me.lblRabattValue.Size = New System.Drawing.Size(64, 15)
        Me.lblRabattValue.TabIndex = 173
        Me.lblRabattValue.Text = "Rabattwert"
        '
        'lblMemo
        '
        Me.lblMemo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMemo.AutoSize = True
        Me.lblMemo.BackColor = System.Drawing.Color.Transparent
        Me.lblMemo.Location = New System.Drawing.Point(2, 69)
        Me.lblMemo.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.lblMemo.Name = "lblMemo"
        Me.lblMemo.Size = New System.Drawing.Size(122, 15)
        Me.lblMemo.TabIndex = 173
        Me.lblMemo.Text = "Notiz / Anmerkungen"
        '
        'ButtonEdit2
        '
        Me.ButtonEdit2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEdit2.EnterMoveNextControl = True
        Me.ButtonEdit2.Location = New System.Drawing.Point(140, 36)
        Me.ButtonEdit2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.ButtonEdit2.Name = "ButtonEdit2"
        Me.ButtonEdit2.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonEdit2.Properties.Appearance.Options.UseFont = True
        Me.ButtonEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.ButtonEdit2.Size = New System.Drawing.Size(288, 22)
        Me.ButtonEdit2.TabIndex = 1
        '
        'tabInformation
        '
        Me.tabInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabInformation.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.tabInformation.Appearance.Options.UseBackColor = True
        Me.tabInformation.Location = New System.Drawing.Point(3, 3)
        Me.tabInformation.Name = "tabInformation"
        Me.tabInformation.SelectedTabPage = Me.tbpInvoiceAdress
        Me.tabInformation.Size = New System.Drawing.Size(440, 147)
        Me.tabInformation.TabIndex = 0
        Me.tabInformation.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tbpInvoiceAdress, Me.tbpDeliveryAdress, Me.tbpNotes, Me.tbpHistory})
        '
        'tbpInvoiceAdress
        '
        Me.tbpInvoiceAdress.Controls.Add(Me.btnResetInvoiceAdress)
        Me.tbpInvoiceAdress.Controls.Add(Me.txtInvoiceAdress)
        Me.tbpInvoiceAdress.Name = "tbpInvoiceAdress"
        Me.tbpInvoiceAdress.Size = New System.Drawing.Size(434, 119)
        Me.tbpInvoiceAdress.Text = "Rechnungsadresse"
        '
        'btnResetInvoiceAdress
        '
        Me.btnResetInvoiceAdress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResetInvoiceAdress.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetInvoiceAdress.Appearance.Options.UseFont = True
        Me.btnResetInvoiceAdress.Location = New System.Drawing.Point(344, 88)
        Me.btnResetInvoiceAdress.Name = "btnResetInvoiceAdress"
        Me.btnResetInvoiceAdress.Size = New System.Drawing.Size(87, 27)
        Me.btnResetInvoiceAdress.TabIndex = 1
        Me.btnResetInvoiceAdress.Text = "Zurücksetzen"
        Me.btnResetInvoiceAdress.ToolTip = "Setzt die Rechnungsadresse zurück, indem die Kontaktdaten neu ausgelesen werden"
        '
        'txtInvoiceAdress
        '
        Me.txtInvoiceAdress.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtInvoiceAdress.Location = New System.Drawing.Point(0, 0)
        Me.txtInvoiceAdress.Name = "txtInvoiceAdress"
        Me.txtInvoiceAdress.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceAdress.Properties.Appearance.Options.UseFont = True
        Me.txtInvoiceAdress.Size = New System.Drawing.Size(434, 78)
        Me.txtInvoiceAdress.TabIndex = 0
        '
        'tbpDeliveryAdress
        '
        Me.tbpDeliveryAdress.Controls.Add(Me.chkLinkDeliveryAdress)
        Me.tbpDeliveryAdress.Controls.Add(Me.txtDeliveryAdress)
        Me.tbpDeliveryAdress.Controls.Add(Me.btnResetdeliveryAdress)
        Me.tbpDeliveryAdress.Name = "tbpDeliveryAdress"
        Me.tbpDeliveryAdress.Size = New System.Drawing.Size(434, 119)
        Me.tbpDeliveryAdress.Text = "Lieferadresse"
        '
        'chkLinkDeliveryAdress
        '
        Me.chkLinkDeliveryAdress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkLinkDeliveryAdress.Location = New System.Drawing.Point(3, 85)
        Me.chkLinkDeliveryAdress.Name = "chkLinkDeliveryAdress"
        Me.chkLinkDeliveryAdress.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLinkDeliveryAdress.Properties.Appearance.Options.UseFont = True
        Me.chkLinkDeliveryAdress.Properties.Caption = "Wie Rechnungsadresse"
        Me.chkLinkDeliveryAdress.Size = New System.Drawing.Size(208, 20)
        Me.chkLinkDeliveryAdress.TabIndex = 8
        '
        'txtDeliveryAdress
        '
        Me.txtDeliveryAdress.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtDeliveryAdress.Location = New System.Drawing.Point(0, 0)
        Me.txtDeliveryAdress.Name = "txtDeliveryAdress"
        Me.txtDeliveryAdress.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeliveryAdress.Properties.Appearance.Options.UseFont = True
        Me.txtDeliveryAdress.Size = New System.Drawing.Size(434, 76)
        Me.txtDeliveryAdress.TabIndex = 6
        '
        'btnResetdeliveryAdress
        '
        Me.btnResetdeliveryAdress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResetdeliveryAdress.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetdeliveryAdress.Appearance.Options.UseFont = True
        Me.btnResetdeliveryAdress.Location = New System.Drawing.Point(345, 87)
        Me.btnResetdeliveryAdress.Name = "btnResetdeliveryAdress"
        Me.btnResetdeliveryAdress.Size = New System.Drawing.Size(87, 27)
        Me.btnResetdeliveryAdress.TabIndex = 7
        Me.btnResetdeliveryAdress.Text = "Zurücksetzen"
        Me.btnResetdeliveryAdress.ToolTip = "Setzt die Rechnungsadresse zurück, indem die Kontaktdaten neu ausgelesen werden"
        '
        'tbpNotes
        '
        Me.tbpNotes.Controls.Add(Me.txtNotes)
        Me.tbpNotes.Name = "tbpNotes"
        Me.tbpNotes.Size = New System.Drawing.Size(434, 119)
        Me.tbpNotes.Text = "Notizen"
        '
        'txtNotes
        '
        Me.txtNotes.AllowDrop = True
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.Location = New System.Drawing.Point(0, 0)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Properties.Appearance.Options.UseFont = True
        Me.txtNotes.Size = New System.Drawing.Size(434, 119)
        Me.txtNotes.TabIndex = 6
        '
        'tbpHistory
        '
        Me.tbpHistory.Controls.Add(Me.grdHistory)
        Me.tbpHistory.Controls.Add(Me.btnEditHistory)
        Me.tbpHistory.Controls.Add(Me.btnAddHistory)
        Me.tbpHistory.Name = "tbpHistory"
        Me.tbpHistory.Size = New System.Drawing.Size(434, 119)
        Me.tbpHistory.Text = "Verlauf"
        '
        'grdHistory
        '
        Me.grdHistory.AllowDrop = True
        Me.grdHistory.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdHistory.Location = New System.Drawing.Point(0, 43)
        Me.grdHistory.MainView = Me.grvHistoryView
        Me.grdHistory.Name = "grdHistory"
        Me.grdHistory.Size = New System.Drawing.Size(434, 76)
        Me.grdHistory.TabIndex = 0
        Me.grdHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvHistoryView, Me.GridView2})
        '
        'grvHistoryView
        '
        Me.grvHistoryView.GridControl = Me.grdHistory
        Me.grvHistoryView.Name = "grvHistoryView"
        Me.grvHistoryView.OptionsBehavior.Editable = False
        Me.grvHistoryView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvHistoryView.OptionsView.ShowColumnHeaders = False
        Me.grvHistoryView.OptionsView.ShowGroupPanel = False
        Me.grvHistoryView.OptionsView.ShowIndicator = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.grdHistory
        Me.GridView2.Name = "GridView2"
        '
        'btnEditHistory
        '
        Me.btnEditHistory.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditHistory.Appearance.Options.UseFont = True
        Me.btnEditHistory.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Edit_Pen_16x16
        Me.btnEditHistory.Location = New System.Drawing.Point(171, 3)
        Me.btnEditHistory.Name = "btnEditHistory"
        Me.btnEditHistory.Size = New System.Drawing.Size(160, 27)
        Me.btnEditHistory.TabIndex = 2
        Me.btnEditHistory.Text = "Bearbeiten"
        '
        'btnAddHistory
        '
        Me.btnAddHistory.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddHistory.Appearance.Options.UseFont = True
        Me.btnAddHistory.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Add_16x16
        Me.btnAddHistory.Location = New System.Drawing.Point(4, 3)
        Me.btnAddHistory.Name = "btnAddHistory"
        Me.btnAddHistory.Size = New System.Drawing.Size(160, 27)
        Me.btnAddHistory.TabIndex = 1
        Me.btnAddHistory.Text = "Manuell hinzufügen"
        Me.btnAddHistory.ToolTip = "Fügt einen neuen Verlauf-Eintrag hinzu"
        '
        'xtpDetails
        '
        Me.xtpDetails.Controls.Add(Me.lblLastChangedAtValue)
        Me.xtpDetails.Controls.Add(Me.lblCreatedAtValue)
        Me.xtpDetails.Controls.Add(Me.lblLastChangedAt)
        Me.xtpDetails.Controls.Add(Me.lblCreatedAt)
        Me.xtpDetails.Controls.Add(Me.txtTargetPaydateDays)
        Me.xtpDetails.Controls.Add(Me.lblDays)
        Me.xtpDetails.Controls.Add(Me.chkEnableTargetPayDate)
        Me.xtpDetails.Controls.Add(Me.lblPhone2)
        Me.xtpDetails.Controls.Add(Me.txtPhone2)
        Me.xtpDetails.Controls.Add(Me.lblWorkOn)
        Me.xtpDetails.Controls.Add(Me.lblFax)
        Me.xtpDetails.Controls.Add(Me.txtfax)
        Me.xtpDetails.Controls.Add(Me.txtWorkOn)
        Me.xtpDetails.Controls.Add(Me.XtraTabControl1)
        Me.xtpDetails.Controls.Add(Me.chkohneMWST)
        Me.xtpDetails.Controls.Add(Me.chkLetterReceiver)
        Me.xtpDetails.Name = "xtpDetails"
        Me.xtpDetails.Size = New System.Drawing.Size(915, 307)
        Me.xtpDetails.Text = "Erweiterte Informationen"
        Me.xtpDetails.Tooltip = "Weitere Kontaktdaten, Bankverbindung"
        '
        'lblLastChangedAtValue
        '
        Me.lblLastChangedAtValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLastChangedAtValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastChangedAtValue.Location = New System.Drawing.Point(116, 270)
        Me.lblLastChangedAtValue.Name = "lblLastChangedAtValue"
        Me.lblLastChangedAtValue.Size = New System.Drawing.Size(59, 15)
        Me.lblLastChangedAtValue.TabIndex = 201
        Me.lblLastChangedAtValue.Tag = "DontTranslate"
        Me.lblLastChangedAtValue.Text = "-DateTime."
        '
        'lblCreatedAtValue
        '
        Me.lblCreatedAtValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCreatedAtValue.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAtValue.Location = New System.Drawing.Point(116, 251)
        Me.lblCreatedAtValue.Name = "lblCreatedAtValue"
        Me.lblCreatedAtValue.Size = New System.Drawing.Size(59, 15)
        Me.lblCreatedAtValue.TabIndex = 201
        Me.lblCreatedAtValue.Tag = "DontTranslate"
        Me.lblCreatedAtValue.Text = "-DateTime."
        '
        'lblLastChangedAt
        '
        Me.lblLastChangedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblLastChangedAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastChangedAt.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblLastChangedAt.Location = New System.Drawing.Point(7, 269)
        Me.lblLastChangedAt.Name = "lblLastChangedAt"
        Me.lblLastChangedAt.Size = New System.Drawing.Size(71, 15)
        Me.lblLastChangedAt.TabIndex = 201
        Me.lblLastChangedAt.Text = "Geändert am:"
        '
        'lblCreatedAt
        '
        Me.lblCreatedAt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCreatedAt.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedAt.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCreatedAt.Location = New System.Drawing.Point(7, 250)
        Me.lblCreatedAt.Name = "lblCreatedAt"
        Me.lblCreatedAt.Size = New System.Drawing.Size(58, 15)
        Me.lblCreatedAt.TabIndex = 201
        Me.lblCreatedAt.Text = "Erstellt am:"
        '
        'txtTargetPaydateDays
        '
        Me.txtTargetPaydateDays.Enabled = False
        Me.txtTargetPaydateDays.Location = New System.Drawing.Point(116, 136)
        Me.txtTargetPaydateDays.Name = "txtTargetPaydateDays"
        Me.txtTargetPaydateDays.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTargetPaydateDays.Properties.Appearance.Options.UseFont = True
        Me.txtTargetPaydateDays.Properties.Mask.EditMask = "d"
        Me.txtTargetPaydateDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTargetPaydateDays.Size = New System.Drawing.Size(37, 22)
        Me.txtTargetPaydateDays.TabIndex = 200
        '
        'lblDays
        '
        Me.lblDays.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDays.Location = New System.Drawing.Point(159, 139)
        Me.lblDays.Name = "lblDays"
        Me.lblDays.Size = New System.Drawing.Size(26, 15)
        Me.lblDays.TabIndex = 199
        Me.lblDays.Text = "Tage"
        '
        'chkEnableTargetPayDate
        '
        Me.chkEnableTargetPayDate.Location = New System.Drawing.Point(5, 138)
        Me.chkEnableTargetPayDate.Name = "chkEnableTargetPayDate"
        Me.chkEnableTargetPayDate.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnableTargetPayDate.Properties.Appearance.Options.UseFont = True
        Me.chkEnableTargetPayDate.Properties.Caption = "Zahlungsziel:"
        Me.chkEnableTargetPayDate.Size = New System.Drawing.Size(105, 20)
        Me.chkEnableTargetPayDate.TabIndex = 198
        '
        'lblPhone2
        '
        Me.lblPhone2.Location = New System.Drawing.Point(4, 50)
        Me.lblPhone2.Name = "lblPhone2"
        Me.lblPhone2.Size = New System.Drawing.Size(104, 15)
        Me.lblPhone2.TabIndex = 197
        Me.lblPhone2.Text = "Telefon (2)"
        '
        'txtPhone2
        '
        Me.txtPhone2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPhone2.EnterMoveNextControl = True
        Me.txtPhone2.Location = New System.Drawing.Point(116, 47)
        Me.txtPhone2.Name = "txtPhone2"
        Me.txtPhone2.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone2.Properties.Appearance.Options.UseFont = True
        Me.txtPhone2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtPhone2.Properties.MaxLength = 250
        Me.txtPhone2.Size = New System.Drawing.Size(399, 22)
        Me.txtPhone2.TabIndex = 193
        Me.txtPhone2.Tag = "Telefon2;Telefon1"
        '
        'lblWorkOn
        '
        Me.lblWorkOn.Location = New System.Drawing.Point(4, 21)
        Me.lblWorkOn.Name = "lblWorkOn"
        Me.lblWorkOn.Size = New System.Drawing.Size(101, 15)
        Me.lblWorkOn.TabIndex = 196
        Me.lblWorkOn.Text = "Gewerbe"
        '
        'lblFax
        '
        Me.lblFax.Location = New System.Drawing.Point(4, 80)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(101, 15)
        Me.lblFax.TabIndex = 195
        Me.lblFax.Text = "Fax"
        '
        'txtfax
        '
        Me.txtfax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtfax.EnterMoveNextControl = True
        Me.txtfax.Location = New System.Drawing.Point(116, 77)
        Me.txtfax.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfax.Properties.Appearance.Options.UseFont = True
        Me.txtfax.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtfax.Properties.MaxLength = 250
        Me.txtfax.Size = New System.Drawing.Size(399, 22)
        Me.txtfax.TabIndex = 194
        Me.txtfax.Tag = "Telefon1;Telefon2"
        '
        'txtWorkOn
        '
        Me.txtWorkOn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWorkOn.EnterMoveNextControl = True
        Me.txtWorkOn.Location = New System.Drawing.Point(116, 19)
        Me.txtWorkOn.Margin = New System.Windows.Forms.Padding(3, 2, 2, 3)
        Me.txtWorkOn.Name = "txtWorkOn"
        Me.txtWorkOn.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkOn.Properties.Appearance.Options.UseFont = True
        Me.txtWorkOn.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtWorkOn.Properties.MaxLength = 250
        Me.txtWorkOn.Size = New System.Drawing.Size(399, 22)
        Me.txtWorkOn.TabIndex = 192
        Me.txtWorkOn.Tag = "Gewerbe"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.XtraTabControl1.Appearance.Options.UseBackColor = True
        Me.XtraTabControl1.Location = New System.Drawing.Point(540, 8)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.xtpBankData
        Me.XtraTabControl1.Size = New System.Drawing.Size(366, 244)
        Me.XtraTabControl1.TabIndex = 173
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.xtpBankData})
        '
        'xtpBankData
        '
        Me.xtpBankData.Controls.Add(Me.txtUstID)
        Me.xtpBankData.Controls.Add(Me.lblBankName)
        Me.xtpBankData.Controls.Add(Me.lblLocalTaxID)
        Me.xtpBankData.Controls.Add(Me.txtBankName)
        Me.xtpBankData.Controls.Add(Me.lblBankIBAN)
        Me.xtpBankData.Controls.Add(Me.txtBankKonto)
        Me.xtpBankData.Controls.Add(Me.txtIBAN)
        Me.xtpBankData.Controls.Add(Me.txtBankLeitzahl)
        Me.xtpBankData.Controls.Add(Me.lblBankID)
        Me.xtpBankData.Controls.Add(Me.lblAccountNumber)
        Me.xtpBankData.Name = "xtpBankData"
        Me.xtpBankData.Size = New System.Drawing.Size(360, 216)
        Me.xtpBankData.Text = "Bankdaten"
        '
        'txtUstID
        '
        Me.txtUstID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUstID.Location = New System.Drawing.Point(124, 138)
        Me.txtUstID.Name = "txtUstID"
        Me.txtUstID.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUstID.Properties.Appearance.Options.UseFont = True
        Me.txtUstID.Properties.MaxLength = 250
        Me.txtUstID.Size = New System.Drawing.Size(233, 22)
        Me.txtUstID.TabIndex = 25
        '
        'lblBankName
        '
        Me.lblBankName.AutoSize = True
        Me.lblBankName.Location = New System.Drawing.Point(3, 22)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(97, 15)
        Me.lblBankName.TabIndex = 19
        Me.lblBankName.Text = "Bankverbindung:"
        '
        'lblLocalTaxID
        '
        Me.lblLocalTaxID.AutoSize = True
        Me.lblLocalTaxID.Location = New System.Drawing.Point(3, 140)
        Me.lblLocalTaxID.Name = "lblLocalTaxID"
        Me.lblLocalTaxID.Size = New System.Drawing.Size(49, 15)
        Me.lblLocalTaxID.TabIndex = 24
        Me.lblLocalTaxID.Text = "UsSt-ID:"
        '
        'txtBankName
        '
        Me.txtBankName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBankName.Location = New System.Drawing.Point(124, 18)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankName.Properties.Appearance.Options.UseFont = True
        Me.txtBankName.Properties.MaxLength = 250
        Me.txtBankName.Size = New System.Drawing.Size(233, 22)
        Me.txtBankName.TabIndex = 16
        '
        'lblBankIBAN
        '
        Me.lblBankIBAN.AutoSize = True
        Me.lblBankIBAN.Location = New System.Drawing.Point(3, 110)
        Me.lblBankIBAN.Name = "lblBankIBAN"
        Me.lblBankIBAN.Size = New System.Drawing.Size(34, 15)
        Me.lblBankIBAN.TabIndex = 23
        Me.lblBankIBAN.Text = "IBAN"
        '
        'txtBankKonto
        '
        Me.txtBankKonto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBankKonto.Location = New System.Drawing.Point(124, 48)
        Me.txtBankKonto.Name = "txtBankKonto"
        Me.txtBankKonto.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankKonto.Properties.Appearance.Options.UseFont = True
        Me.txtBankKonto.Properties.MaxLength = 250
        Me.txtBankKonto.Size = New System.Drawing.Size(233, 22)
        Me.txtBankKonto.TabIndex = 17
        '
        'txtIBAN
        '
        Me.txtIBAN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIBAN.Location = New System.Drawing.Point(124, 108)
        Me.txtIBAN.Name = "txtIBAN"
        Me.txtIBAN.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIBAN.Properties.Appearance.Options.UseFont = True
        Me.txtIBAN.Properties.MaxLength = 250
        Me.txtIBAN.Size = New System.Drawing.Size(233, 22)
        Me.txtIBAN.TabIndex = 22
        '
        'txtBankLeitzahl
        '
        Me.txtBankLeitzahl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBankLeitzahl.Location = New System.Drawing.Point(124, 77)
        Me.txtBankLeitzahl.Name = "txtBankLeitzahl"
        Me.txtBankLeitzahl.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankLeitzahl.Properties.Appearance.Options.UseFont = True
        Me.txtBankLeitzahl.Properties.MaxLength = 250
        Me.txtBankLeitzahl.Size = New System.Drawing.Size(233, 22)
        Me.txtBankLeitzahl.TabIndex = 18
        '
        'lblBankID
        '
        Me.lblBankID.AutoSize = True
        Me.lblBankID.Location = New System.Drawing.Point(3, 79)
        Me.lblBankID.Name = "lblBankID"
        Me.lblBankID.Size = New System.Drawing.Size(70, 15)
        Me.lblBankID.TabIndex = 21
        Me.lblBankID.Text = "Bankleitzahl"
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.AutoSize = True
        Me.lblAccountNumber.Location = New System.Drawing.Point(3, 52)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Size = New System.Drawing.Size(85, 15)
        Me.lblAccountNumber.TabIndex = 20
        Me.lblAccountNumber.Text = "Kontonummer"
        '
        'chkohneMWST
        '
        Me.chkohneMWST.AutoSize = True
        Me.chkohneMWST.BackColor = System.Drawing.Color.Transparent
        Me.chkohneMWST.Location = New System.Drawing.Point(7, 191)
        Me.chkohneMWST.Name = "chkohneMWST"
        Me.chkohneMWST.Size = New System.Drawing.Size(194, 19)
        Me.chkohneMWST.TabIndex = 171
        Me.chkohneMWST.Text = "Erhält Rechnungen ohne MWST"
        Me.chkohneMWST.UseVisualStyleBackColor = True
        Me.chkohneMWST.Visible = False
        '
        'chkLetterReceiver
        '
        Me.chkLetterReceiver.AutoSize = True
        Me.chkLetterReceiver.Location = New System.Drawing.Point(7, 171)
        Me.chkLetterReceiver.Name = "chkLetterReceiver"
        Me.chkLetterReceiver.Size = New System.Drawing.Size(121, 19)
        Me.chkLetterReceiver.TabIndex = 172
        Me.chkLetterReceiver.Text = "Erhält Serienbriefe"
        Me.chkLetterReceiver.UseVisualStyleBackColor = True
        '
        'uicCommonGrid
        '
        Me.uicCommonGrid.AllowNewRow = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.uicCommonGrid.BackColor = System.Drawing.Color.White
        Me.uicCommonGrid.Context = Nothing
        Me.uicCommonGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uicCommonGrid.Editable = False
        Me.uicCommonGrid.ForeColor = System.Drawing.Color.Black
        Me.uicCommonGrid.Location = New System.Drawing.Point(0, 31)
        Me.uicCommonGrid.Margin = New System.Windows.Forms.Padding(5)
        Me.uicCommonGrid.Name = "uicCommonGrid"
        Me.uicCommonGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.uicCommonGrid.ShowFilterRow = False
        Me.uicCommonGrid.Size = New System.Drawing.Size(926, 314)
        Me.uicCommonGrid.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.btnMaximizeworkspace)
        Me.PanelControl1.Controls.Add(Me.IucSearchPanel1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.PanelControl1.Size = New System.Drawing.Size(926, 31)
        Me.PanelControl1.TabIndex = 2
        '
        'btnMaximizeworkspace
        '
        Me.btnMaximizeworkspace.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnMaximizeworkspace.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.btnMaximizeworkspace.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMaximizeworkspace.Image = Global.ClausSoftware.HWLInterops.My.Resources.Resources.FitToHeight_16x16
        Me.btnMaximizeworkspace.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnMaximizeworkspace.Location = New System.Drawing.Point(884, 0)
        Me.btnMaximizeworkspace.LookAndFeel.SkinName = "Lilian"
        Me.btnMaximizeworkspace.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnMaximizeworkspace.Name = "btnMaximizeworkspace"
        Me.btnMaximizeworkspace.Size = New System.Drawing.Size(37, 31)
        Me.btnMaximizeworkspace.TabIndex = 3
        Me.btnMaximizeworkspace.ToolTip = "Arbeitsbereich maximieren"
        '
        'IucSearchPanel1
        '
        Me.IucSearchPanel1.AllowTextFieldTabStop = True
        Me.IucSearchPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.IucSearchPanel1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.IucSearchPanel1.Appearance.Options.UseBackColor = True
        Me.IucSearchPanel1.Appearance.Options.UseForeColor = True
        Me.IucSearchPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.IucSearchPanel1.Location = New System.Drawing.Point(2, 5)
        Me.IucSearchPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.IucSearchPanel1.Name = "IucSearchPanel1"
        Me.IucSearchPanel1.NullValuePrompt = "Suche...    F3"
        Me.IucSearchPanel1.SelectedMenueItem = -1
        Me.IucSearchPanel1.Size = New System.Drawing.Size(246, 22)
        Me.IucSearchPanel1.Status = ClausSoftware.HWLInterops.iucSearchPanel.enumState.empty
        Me.IucSearchPanel1.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSearchIcons})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(186, 26)
        '
        'mnuSearchIcons
        '
        Me.mnuSearchIcons.CheckOnClick = True
        Me.mnuSearchIcons.Name = "mnuSearchIcons"
        Me.mnuSearchIcons.Size = New System.Drawing.Size(185, 22)
        Me.mnuSearchIcons.Text = "Suchhilfe einblenden"
        '
        'iucAddressBook
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "iucAddressBook"
        Me.Size = New System.Drawing.Size(926, 684)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.tabEditPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEditPanel.ResumeLayout(False)
        Me.xtpCommonContact.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlBaseContactData.ResumeLayout(False)
        Me.pnlBaseContactData.PerformLayout()
        CType(Me.chkIsActiveContact.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContactID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtZipCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCompany.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLastName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFirstName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStreet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTown.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefon1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.MemoExEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEbayID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCustomersDiscountValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMemo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabInformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInformation.ResumeLayout(False)
        Me.tbpInvoiceAdress.ResumeLayout(False)
        CType(Me.txtInvoiceAdress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpDeliveryAdress.ResumeLayout(False)
        CType(Me.chkLinkDeliveryAdress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDeliveryAdress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpNotes.ResumeLayout(False)
        CType(Me.txtNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpHistory.ResumeLayout(False)
        CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvHistoryView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xtpDetails.ResumeLayout(False)
        Me.xtpDetails.PerformLayout()
        CType(Me.txtTargetPaydateDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEnableTargetPayDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPhone2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkOn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.xtpBankData.ResumeLayout(False)
        Me.xtpBankData.PerformLayout()
        CType(Me.txtUstID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBankName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBankKonto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIBAN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBankLeitzahl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents uicCommonGrid As HWLInterops.uicCommonGrid
    Friend WithEvents IucSearchPanel1 As HWLInterops.iucSearchPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlBaseContactData As System.Windows.Forms.Panel
    Friend WithEvents lblKey_ As System.Windows.Forms.Label
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents lblStreet As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblContactName As System.Windows.Forms.Label
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblZipCode As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents txtZipCode As DevExpress.XtraEditors.ButtonEdit
    Private WithEvents txtCompany As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtCountry As DevExpress.XtraEditors.ButtonEdit
    Private WithEvents txtFirstName As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtStreet As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtTown As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtEmail As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtTelefon1 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblKey As System.Windows.Forms.Label
    Friend WithEvents txtEbayID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents chkohneMWST As System.Windows.Forms.CheckBox
    Friend WithEvents chkLetterReceiver As System.Windows.Forms.CheckBox
    Friend WithEvents txtContactID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblRabattValue As System.Windows.Forms.Label
    Friend WithEvents txtCustomersDiscountValue As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents btnResetInvoiceAdress As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtInvoiceAdress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents btnResetdeliveryAdress As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDeliveryAdress As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents chkLinkDeliveryAdress As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtNotes As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents txtMemo As DevExpress.XtraEditors.MemoExEdit
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSearchIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMemo As System.Windows.Forms.Label
    Friend WithEvents btnOpenInGoogeMaps As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOpenJournal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tabEditPanel As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtpCommonContact As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents xtpDetails As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents grdHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvHistoryView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnAddHistory As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEditHistory As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tabInformation As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tbpInvoiceAdress As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tbpDeliveryAdress As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tbpNotes As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tbpHistory As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents chkIsActiveContact As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPhone2 As System.Windows.Forms.Label
    Friend WithEvents txtPhone2 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblWorkOn As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents txtfax As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtWorkOn As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents xtpBankData As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents txtUstID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblBankName As System.Windows.Forms.Label
    Friend WithEvents lblLocalTaxID As System.Windows.Forms.Label
    Friend WithEvents txtBankName As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblBankIBAN As System.Windows.Forms.Label
    Friend WithEvents txtBankKonto As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtIBAN As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtBankLeitzahl As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblBankID As System.Windows.Forms.Label
    Friend WithEvents lblAccountNumber As System.Windows.Forms.Label
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MemoExEdit1 As DevExpress.XtraEditors.MemoExEdit
    Friend WithEvents ButtonEdit1 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonEdit2 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents btnMaximizeworkspace As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtTargetPaydateDays As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblDays As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkEnableTargetPayDate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnNewDocumentFromAddress As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblLastChangedAtValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCreatedAtValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblLastChangedAt As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCreatedAt As DevExpress.XtraEditors.LabelControl
    Private WithEvents txtLastName As DevExpress.XtraEditors.ButtonEdit

End Class
