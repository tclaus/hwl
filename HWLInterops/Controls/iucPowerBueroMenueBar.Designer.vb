Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucPowerBueroMenueBar
    Inherits System.Windows.Forms.UserControl

    'iucPowerBueroMenueBar overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(iucPowerBueroMenueBar))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnArticles = New DevExpress.XtraEditors.SimpleButton()
        Me.btnadressbook = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBusiness = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCashFlow = New DevExpress.XtraEditors.SimpleButton()
        Me.btnKasse = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLetters = New DevExpress.XtraEditors.SimpleButton()
        Me.btnScheduler = New DevExpress.XtraEditors.SimpleButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnArticles, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnadressbook, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBusiness, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCashFlow, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnKasse, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLetters, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnScheduler, 6, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(968, 50)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnArticles
        '
        Me.btnArticles.Appearance.BackColor = System.Drawing.Color.Navy
        Me.btnArticles.Appearance.BackColor2 = System.Drawing.Color.White
        Me.btnArticles.Appearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.btnArticles.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArticles.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnArticles.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnArticles.Appearance.Options.UseBackColor = True
        Me.btnArticles.Appearance.Options.UseBorderColor = True
        Me.btnArticles.Appearance.Options.UseFont = True
        Me.btnArticles.Appearance.Options.UseForeColor = True
        Me.btnArticles.Appearance.Options.UseTextOptions = True
        Me.btnArticles.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnArticles.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.btnArticles.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.btnArticles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnArticles.Image = CType(resources.GetObject("btnArticles.Image"), System.Drawing.Image)
        Me.btnArticles.Location = New System.Drawing.Point(141, 3)
        Me.btnArticles.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnArticles.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnArticles.Name = "btnArticles"
        Me.btnArticles.Size = New System.Drawing.Size(132, 44)
        Me.btnArticles.TabIndex = 1
        Me.btnArticles.Text = "Material"
        Me.btnArticles.ToolTip = "Alle Artikel und Materialien."
        '
        'btnadressbook
        '
        Me.btnadressbook.Appearance.BackColor = System.Drawing.Color.Navy
        Me.btnadressbook.Appearance.BackColor2 = System.Drawing.Color.White
        Me.btnadressbook.Appearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.btnadressbook.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadressbook.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnadressbook.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnadressbook.Appearance.Options.UseBackColor = True
        Me.btnadressbook.Appearance.Options.UseBorderColor = True
        Me.btnadressbook.Appearance.Options.UseFont = True
        Me.btnadressbook.Appearance.Options.UseForeColor = True
        Me.btnadressbook.Appearance.Options.UseTextOptions = True
        Me.btnadressbook.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnadressbook.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.btnadressbook.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.btnadressbook.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnadressbook.Image = CType(resources.GetObject("btnadressbook.Image"), System.Drawing.Image)
        Me.btnadressbook.Location = New System.Drawing.Point(3, 3)
        Me.btnadressbook.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnadressbook.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnadressbook.Name = "btnadressbook"
        Me.btnadressbook.Size = New System.Drawing.Size(132, 44)
        Me.btnadressbook.TabIndex = 0
        Me.btnadressbook.Text = "Adressen"
        Me.btnadressbook.ToolTip = "Das Adressbuch enthält die Liste aller Kontakte"
        '
        'btnBusiness
        '
        Me.btnBusiness.Appearance.BackColor = System.Drawing.Color.Navy
        Me.btnBusiness.Appearance.BackColor2 = System.Drawing.Color.White
        Me.btnBusiness.Appearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.btnBusiness.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusiness.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnBusiness.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnBusiness.Appearance.Options.UseBackColor = True
        Me.btnBusiness.Appearance.Options.UseBorderColor = True
        Me.btnBusiness.Appearance.Options.UseFont = True
        Me.btnBusiness.Appearance.Options.UseForeColor = True
        Me.btnBusiness.Appearance.Options.UseTextOptions = True
        Me.btnBusiness.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnBusiness.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.btnBusiness.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.btnBusiness.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBusiness.Image = CType(resources.GetObject("btnBusiness.Image"), System.Drawing.Image)
        Me.btnBusiness.Location = New System.Drawing.Point(279, 3)
        Me.btnBusiness.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnBusiness.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnBusiness.Name = "btnBusiness"
        Me.btnBusiness.Size = New System.Drawing.Size(132, 44)
        Me.btnBusiness.TabIndex = 0
        Me.btnBusiness.Text = "Angebote/ Rechnungen"
        Me.btnBusiness.ToolTip = "Angebote / Rechnungen, sowie Bestellungen, Mahnungen, Gutschriften, Projektverwal" & _
            "tung."
        '
        'btnCashFlow
        '
        Me.btnCashFlow.Appearance.BackColor = System.Drawing.Color.Navy
        Me.btnCashFlow.Appearance.BackColor2 = System.Drawing.Color.White
        Me.btnCashFlow.Appearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.btnCashFlow.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashFlow.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnCashFlow.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnCashFlow.Appearance.Options.UseBackColor = True
        Me.btnCashFlow.Appearance.Options.UseBorderColor = True
        Me.btnCashFlow.Appearance.Options.UseFont = True
        Me.btnCashFlow.Appearance.Options.UseForeColor = True
        Me.btnCashFlow.Appearance.Options.UseTextOptions = True
        Me.btnCashFlow.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnCashFlow.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.btnCashFlow.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnCashFlow.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.btnCashFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCashFlow.Image = CType(resources.GetObject("btnCashFlow.Image"), System.Drawing.Image)
        Me.btnCashFlow.Location = New System.Drawing.Point(417, 3)
        Me.btnCashFlow.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnCashFlow.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnCashFlow.Name = "btnCashFlow"
        Me.btnCashFlow.Size = New System.Drawing.Size(132, 44)
        Me.btnCashFlow.TabIndex = 0
        Me.btnCashFlow.Text = "Forderungen/ Verbindlichkeiten"
        Me.btnCashFlow.ToolTip = "Forderungen / Verbindlichkeiten, enthält den gesamten Geldfluss."
        '
        'btnKasse
        '
        Me.btnKasse.Appearance.BackColor = System.Drawing.Color.Navy
        Me.btnKasse.Appearance.BackColor2 = System.Drawing.Color.White
        Me.btnKasse.Appearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.btnKasse.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKasse.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnKasse.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnKasse.Appearance.Options.UseBackColor = True
        Me.btnKasse.Appearance.Options.UseBorderColor = True
        Me.btnKasse.Appearance.Options.UseFont = True
        Me.btnKasse.Appearance.Options.UseForeColor = True
        Me.btnKasse.Appearance.Options.UseTextOptions = True
        Me.btnKasse.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnKasse.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.btnKasse.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.btnKasse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnKasse.Image = CType(resources.GetObject("btnKasse.Image"), System.Drawing.Image)
        Me.btnKasse.Location = New System.Drawing.Point(555, 3)
        Me.btnKasse.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnKasse.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnKasse.Name = "btnKasse"
        Me.btnKasse.Size = New System.Drawing.Size(132, 44)
        Me.btnKasse.TabIndex = 3
        Me.btnKasse.Text = "Kassenbuch"
        Me.btnKasse.ToolTip = "Kassenbuch zeigt das Journal des baren Geldflussses"
        '
        'btnLetters
        '
        Me.btnLetters.Appearance.BackColor = System.Drawing.Color.Navy
        Me.btnLetters.Appearance.BackColor2 = System.Drawing.Color.White
        Me.btnLetters.Appearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.btnLetters.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLetters.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnLetters.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnLetters.Appearance.Options.UseBackColor = True
        Me.btnLetters.Appearance.Options.UseBorderColor = True
        Me.btnLetters.Appearance.Options.UseFont = True
        Me.btnLetters.Appearance.Options.UseForeColor = True
        Me.btnLetters.Appearance.Options.UseTextOptions = True
        Me.btnLetters.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnLetters.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.btnLetters.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.btnLetters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLetters.Image = CType(resources.GetObject("btnLetters.Image"), System.Drawing.Image)
        Me.btnLetters.Location = New System.Drawing.Point(693, 3)
        Me.btnLetters.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnLetters.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnLetters.Name = "btnLetters"
        Me.btnLetters.Size = New System.Drawing.Size(132, 44)
        Me.btnLetters.TabIndex = 0
        Me.btnLetters.Text = "Briefe"
        Me.btnLetters.ToolTip = "Einfache Kurzbriefe."
        '
        'btnScheduler
        '
        Me.btnScheduler.Appearance.BackColor = System.Drawing.Color.Navy
        Me.btnScheduler.Appearance.BackColor2 = System.Drawing.Color.White
        Me.btnScheduler.Appearance.BorderColor = System.Drawing.Color.SaddleBrown
        Me.btnScheduler.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScheduler.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnScheduler.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal
        Me.btnScheduler.Appearance.Options.UseBackColor = True
        Me.btnScheduler.Appearance.Options.UseBorderColor = True
        Me.btnScheduler.Appearance.Options.UseFont = True
        Me.btnScheduler.Appearance.Options.UseForeColor = True
        Me.btnScheduler.Appearance.Options.UseTextOptions = True
        Me.btnScheduler.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnScheduler.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.btnScheduler.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.btnScheduler.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnScheduler.Image = CType(resources.GetObject("btnScheduler.Image"), System.Drawing.Image)
        Me.btnScheduler.Location = New System.Drawing.Point(831, 3)
        Me.btnScheduler.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
        Me.btnScheduler.LookAndFeel.UseDefaultLookAndFeel = False
        Me.btnScheduler.Name = "btnScheduler"
        Me.btnScheduler.Size = New System.Drawing.Size(134, 44)
        Me.btnScheduler.TabIndex = 0
        Me.btnScheduler.Text = "Termine"
        Me.btnScheduler.ToolTip = "Terminkalender verwaltet einfache und wiederkehrende Termine. Erzeugt Erinnerunge" & _
            "n rechtzeitig vor Fälligkeit."
        '
        'iucPowerBueroMenueBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "iucPowerBueroMenueBar"
        Me.Size = New System.Drawing.Size(968, 50)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnadressbook As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnArticles As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnBusiness As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLetters As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCashFlow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnKasse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnScheduler As DevExpress.XtraEditors.SimpleButton

End Class
