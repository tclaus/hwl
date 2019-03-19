Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucMenuBar
    Inherits ClausSoftware.HWLInterops.BaseControl

    'iucMenuBar overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(iucMenuBar))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem1 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem2 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem3 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip4 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem4 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem4 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip5 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem5 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem5 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip6 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem6 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem6 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip7 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem7 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem7 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim SuperToolTip8 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipTitleItem8 As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem()
        Dim ToolTipItem8 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.cmdExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdKasse = New DevExpress.XtraEditors.SimpleButton()
        Me.btnScheduler = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdLetters = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdBusiness = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCashFlow = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdArticles = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdAdressbook = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Appearance.Options.UseFont = True
        Me.cmdExit.Appearance.Options.UseTextOptions = True
        Me.cmdExit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cmdExit.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.Location = New System.Drawing.Point(3, 454)
        Me.cmdExit.LookAndFeel.SkinName = "Lilian"
        Me.cmdExit.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(199, 38)
        ToolTipTitleItem1.Text = "Programmende"
        ToolTipItem1.LeftIndent = 6
        ToolTipItem1.Text = "Beendet das Programm"
        SuperToolTip1.Items.Add(ToolTipTitleItem1)
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.cmdExit.SuperTip = SuperToolTip1
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "&Ende"
        '
        'cmdKasse
        '
        Me.cmdKasse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdKasse.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKasse.Appearance.Options.UseFont = True
        Me.cmdKasse.Appearance.Options.UseTextOptions = True
        Me.cmdKasse.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cmdKasse.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character
        Me.cmdKasse.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdKasse.Image = CType(resources.GetObject("cmdKasse.Image"), System.Drawing.Image)
        Me.cmdKasse.Location = New System.Drawing.Point(3, 224)
        Me.cmdKasse.LookAndFeel.SkinName = "Lilian"
        Me.cmdKasse.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdKasse.Name = "cmdKasse"
        Me.cmdKasse.Size = New System.Drawing.Size(199, 48)
        ToolTipTitleItem2.Text = "Kassenbuch"
        ToolTipItem2.LeftIndent = 6
        ToolTipItem2.Text = "Geschäftsvorfälle, die direkt Bar gezahlt werden und eine Veränderung des Bar-Bes" & _
            "tandes auslösen"
        SuperToolTip2.Items.Add(ToolTipTitleItem2)
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.cmdKasse.SuperTip = SuperToolTip2
        Me.cmdKasse.TabIndex = 1
        Me.cmdKasse.Text = "&Kassenbuch"
        '
        'btnScheduler
        '
        Me.btnScheduler.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnScheduler.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScheduler.Appearance.Options.UseFont = True
        Me.btnScheduler.Appearance.Options.UseTextOptions = True
        Me.btnScheduler.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnScheduler.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character
        Me.btnScheduler.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.btnScheduler.Image = CType(resources.GetObject("btnScheduler.Image"), System.Drawing.Image)
        Me.btnScheduler.Location = New System.Drawing.Point(3, 330)
        Me.btnScheduler.LookAndFeel.SkinName = "Lilian"
        Me.btnScheduler.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnScheduler.Name = "btnScheduler"
        Me.btnScheduler.Size = New System.Drawing.Size(199, 48)
        ToolTipTitleItem3.Text = "Terminkalender"
        ToolTipItem3.LeftIndent = 6
        ToolTipItem3.Text = "Eine Tages/Wochen / Monatsansicht für all Ihre Termine und Aufgaben. "
        SuperToolTip3.Items.Add(ToolTipTitleItem3)
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.btnScheduler.SuperTip = SuperToolTip3
        Me.btnScheduler.TabIndex = 1
        Me.btnScheduler.Text = "&Terminplaner"
        '
        'cmdLetters
        '
        Me.cmdLetters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLetters.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLetters.Appearance.Options.UseFont = True
        Me.cmdLetters.Appearance.Options.UseTextOptions = True
        Me.cmdLetters.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cmdLetters.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character
        Me.cmdLetters.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdLetters.Image = CType(resources.GetObject("cmdLetters.Image"), System.Drawing.Image)
        Me.cmdLetters.Location = New System.Drawing.Point(3, 276)
        Me.cmdLetters.LookAndFeel.SkinName = "Lilian"
        Me.cmdLetters.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdLetters.Name = "cmdLetters"
        Me.cmdLetters.Size = New System.Drawing.Size(199, 48)
        ToolTipTitleItem4.Text = "Kurzbriefe"
        ToolTipItem4.LeftIndent = 6
        ToolTipItem4.Text = "Hier können Kurzbriefe verfasst werden."
        SuperToolTip4.Items.Add(ToolTipTitleItem4)
        SuperToolTip4.Items.Add(ToolTipItem4)
        Me.cmdLetters.SuperTip = SuperToolTip4
        Me.cmdLetters.TabIndex = 1
        Me.cmdLetters.Text = "&Briefe"
        '
        'cmdBuisiness
        '
        Me.cmdBusiness.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdBusiness.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBusiness.Appearance.Options.UseFont = True
        Me.cmdBusiness.Appearance.Options.UseTextOptions = True
        Me.cmdBusiness.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cmdBusiness.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character
        Me.cmdBusiness.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdBusiness.Image = CType(resources.GetObject("cmdBuisiness.Image"), System.Drawing.Image)
        Me.cmdBusiness.Location = New System.Drawing.Point(3, 120)
        Me.cmdBusiness.LookAndFeel.SkinName = "Lilian"
        Me.cmdBusiness.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdBusiness.Name = "cmdBuisiness"
        Me.cmdBusiness.Size = New System.Drawing.Size(199, 48)
        ToolTipTitleItem5.Text = "Angebote / Rechnungen"
        ToolTipItem5.LeftIndent = 6
        ToolTipItem5.Text = "Angebote, Rechnungen, sowie Gutschriften und Mahnungen. "
        SuperToolTip5.Items.Add(ToolTipTitleItem5)
        SuperToolTip5.Items.Add(ToolTipItem5)
        Me.cmdBusiness.SuperTip = SuperToolTip5
        Me.cmdBusiness.TabIndex = 1
        Me.cmdBusiness.Text = "Angebote/ &Rechnungen"
        '
        'cmdCashFlow
        '
        Me.cmdCashFlow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCashFlow.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCashFlow.Appearance.Options.UseFont = True
        Me.cmdCashFlow.Appearance.Options.UseTextOptions = True
        Me.cmdCashFlow.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cmdCashFlow.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character
        Me.cmdCashFlow.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdCashFlow.Image = CType(resources.GetObject("cmdCashFlow.Image"), System.Drawing.Image)
        Me.cmdCashFlow.Location = New System.Drawing.Point(3, 172)
        Me.cmdCashFlow.LookAndFeel.SkinName = "Lilian"
        Me.cmdCashFlow.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdCashFlow.Name = "cmdCashFlow"
        Me.cmdCashFlow.Size = New System.Drawing.Size(199, 48)
        ToolTipTitleItem6.Text = "Forderungen / Verbindlichkeiten"
        ToolTipItem6.LeftIndent = 6
        ToolTipItem6.Text = "Alle Buchungsvorfälle werden hier erfasst. Geschriebene Rechnungen werden hier ge" & _
            "bucht. Sie können auch eigene Ausgangsrechnungen oder eingehende Rechnungen hier" & _
            " buchen."
        SuperToolTip6.Items.Add(ToolTipTitleItem6)
        SuperToolTip6.Items.Add(ToolTipItem6)
        Me.cmdCashFlow.SuperTip = SuperToolTip6
        Me.cmdCashFlow.TabIndex = 0
        Me.cmdCashFlow.Text = "&Forderungen/ Verbindlichkeiten"
        '
        'cmdArticles
        '
        Me.cmdArticles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdArticles.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdArticles.Appearance.Options.UseFont = True
        Me.cmdArticles.Appearance.Options.UseTextOptions = True
        Me.cmdArticles.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cmdArticles.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character
        Me.cmdArticles.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdArticles.Image = CType(resources.GetObject("cmdArticles.Image"), System.Drawing.Image)
        Me.cmdArticles.Location = New System.Drawing.Point(3, 68)
        Me.cmdArticles.LookAndFeel.SkinName = "Lilian"
        Me.cmdArticles.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdArticles.Name = "cmdArticles"
        Me.cmdArticles.Size = New System.Drawing.Size(199, 48)
        ToolTipTitleItem7.Text = "Artikelliste / Leistungsverzeichnis"
        ToolTipItem7.LeftIndent = 6
        ToolTipItem7.Text = "Stellt eine Liste von Artikel, Baugruppen und Leistungen bereit. Artikel können m" & _
            "it anderen Artikeln oder Leitungen kombiniert werden. "
        SuperToolTip7.Items.Add(ToolTipTitleItem7)
        SuperToolTip7.Items.Add(ToolTipItem7)
        Me.cmdArticles.SuperTip = SuperToolTip7
        Me.cmdArticles.TabIndex = 0
        Me.cmdArticles.Text = "&Materialstamm"
        '
        'cmdAdressbook
        '
        Me.cmdAdressbook.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAdressbook.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAdressbook.Appearance.Options.UseFont = True
        Me.cmdAdressbook.Appearance.Options.UseTextOptions = True
        Me.cmdAdressbook.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cmdAdressbook.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character
        Me.cmdAdressbook.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.cmdAdressbook.Image = CType(resources.GetObject("cmdAdressbook.Image"), System.Drawing.Image)
        Me.cmdAdressbook.Location = New System.Drawing.Point(3, 14)
        Me.cmdAdressbook.LookAndFeel.SkinName = "Lilian"
        Me.cmdAdressbook.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cmdAdressbook.Name = "cmdAdressbook"
        Me.cmdAdressbook.Size = New System.Drawing.Size(199, 48)
        ToolTipTitleItem8.Text = "Adressbuch"
        ToolTipItem8.LeftIndent = 6
        ToolTipItem8.Text = "Enthält Adressdaten von Kunden und Lieferanten. Eine Aufstellung der Geschäftsvor" & _
            "fälle für einen Kontakt kann direkt aufgerufen werden."
        SuperToolTip8.Items.Add(ToolTipTitleItem8)
        SuperToolTip8.Items.Add(ToolTipItem8)
        Me.cmdAdressbook.SuperTip = SuperToolTip8
        Me.cmdAdressbook.TabIndex = 0
        Me.cmdAdressbook.Text = "&Adressbuch"
        '
        'iucMenuBar
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdKasse)
        Me.Controls.Add(Me.btnScheduler)
        Me.Controls.Add(Me.cmdLetters)
        Me.Controls.Add(Me.cmdBusiness)
        Me.Controls.Add(Me.cmdCashFlow)
        Me.Controls.Add(Me.cmdArticles)
        Me.Controls.Add(Me.cmdAdressbook)
        Me.Name = "iucMenuBar"
        Me.Size = New System.Drawing.Size(211, 506)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAdressbook As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdArticles As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdBusiness As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCashFlow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdLetters As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdKasse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnScheduler As DevExpress.XtraEditors.SimpleButton

End Class
