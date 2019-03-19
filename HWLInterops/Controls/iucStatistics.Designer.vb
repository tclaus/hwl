Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucStatistics
    Inherits mainControlContainer


    'iucStatistics overrides dispose to clean up the component list.
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
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.tabstatisticsList = New DevExpress.XtraTab.XtraTabPage()
        Me.lblYears = New DevExpress.XtraEditors.LabelControl()
        Me.spYears = New DevExpress.XtraEditors.SpinEdit()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCount = New DevExpress.XtraEditors.LabelControl()
        Me.lblSumme = New DevExpress.XtraEditors.LabelControl()
        Me.lblSumValue = New DevExpress.XtraEditors.LabelControl()
        Me.lblCountValue = New DevExpress.XtraEditors.LabelControl()
        Me.chkAllTimeStatistics = New DevExpress.XtraEditors.CheckEdit()
        Me.lblendDate = New DevExpress.XtraEditors.LabelControl()
        Me.lblstartDate = New DevExpress.XtraEditors.LabelControl()
        Me.datEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.datStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.radStatistics = New DevExpress.XtraEditors.RadioGroup()
        Me.grdMain = New DevExpress.XtraGrid.GridControl()
        Me.grvMain = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.tabstatisticsList.SuspendLayout()
        CType(Me.spYears.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.chkAllTimeStatistics.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radStatistics.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(3, 3)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.tabstatisticsList
        Me.XtraTabControl1.Size = New System.Drawing.Size(699, 516)
        Me.XtraTabControl1.TabIndex = 1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabstatisticsList})
        '
        'tabstatisticsList
        '
        Me.tabstatisticsList.Controls.Add(Me.lblYears)
        Me.tabstatisticsList.Controls.Add(Me.spYears)
        Me.tabstatisticsList.Controls.Add(Me.TableLayoutPanel1)
        Me.tabstatisticsList.Controls.Add(Me.chkAllTimeStatistics)
        Me.tabstatisticsList.Controls.Add(Me.lblendDate)
        Me.tabstatisticsList.Controls.Add(Me.lblstartDate)
        Me.tabstatisticsList.Controls.Add(Me.datEndDate)
        Me.tabstatisticsList.Controls.Add(Me.datStartDate)
        Me.tabstatisticsList.Controls.Add(Me.radStatistics)
        Me.tabstatisticsList.Controls.Add(Me.grdMain)
        Me.tabstatisticsList.Name = "tabstatisticsList"
        Me.tabstatisticsList.Size = New System.Drawing.Size(692, 487)
        Me.tabstatisticsList.Text = "Statistiken (Liste)"
        '
        'lblYears
        '
        Me.lblYears.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblYears.Location = New System.Drawing.Point(399, 381)
        Me.lblYears.Name = "lblYears"
        Me.lblYears.Size = New System.Drawing.Size(59, 13)
        Me.lblYears.TabIndex = 10
        Me.lblYears.Text = "ganze Jahre"
        '
        'spYears
        '
        Me.spYears.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.spYears.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.spYears.Location = New System.Drawing.Point(399, 403)
        Me.spYears.Name = "spYears"
        Me.spYears.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.spYears.Properties.IsFloatValue = False
        Me.spYears.Properties.Mask.EditMask = "d"
        Me.spYears.Size = New System.Drawing.Size(89, 20)
        Me.spYears.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblCount, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSumme, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSumValue, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCountValue, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 337)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(233, 45)
        Me.TableLayoutPanel1.TabIndex = 7
        Me.TableLayoutPanel1.Visible = False
        '
        'lblCount
        '
        Me.lblCount.Location = New System.Drawing.Point(43, 3)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(32, 13)
        Me.lblCount.TabIndex = 6
        Me.lblCount.Text = "Anzahl"
        '
        'lblSumme
        '
        Me.lblSumme.Location = New System.Drawing.Point(3, 3)
        Me.lblSumme.Name = "lblSumme"
        Me.lblSumme.Size = New System.Drawing.Size(34, 13)
        Me.lblSumme.TabIndex = 6
        Me.lblSumme.Text = "Summe"
        '
        'lblSumValue
        '
        Me.lblSumValue.Location = New System.Drawing.Point(3, 25)
        Me.lblSumValue.Name = "lblSumValue"
        Me.lblSumValue.Size = New System.Drawing.Size(34, 13)
        Me.lblSumValue.TabIndex = 6
        Me.lblSumValue.Text = "Summe"
        '
        'lblCountValue
        '
        Me.lblCountValue.Location = New System.Drawing.Point(43, 25)
        Me.lblCountValue.Name = "lblCountValue"
        Me.lblCountValue.Size = New System.Drawing.Size(32, 13)
        Me.lblCountValue.TabIndex = 6
        Me.lblCountValue.Text = "Anzahl"
        '
        'chkAllTimeStatistics
        '
        Me.chkAllTimeStatistics.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAllTimeStatistics.Location = New System.Drawing.Point(192, 379)
        Me.chkAllTimeStatistics.Name = "chkAllTimeStatistics"
        Me.chkAllTimeStatistics.Properties.Caption = "Alle Zeiträume"
        Me.chkAllTimeStatistics.Size = New System.Drawing.Size(173, 19)
        Me.chkAllTimeStatistics.TabIndex = 5
        '
        'lblendDate
        '
        Me.lblendDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblendDate.Location = New System.Drawing.Point(195, 437)
        Me.lblendDate.Name = "lblendDate"
        Me.lblendDate.Size = New System.Drawing.Size(48, 13)
        Me.lblendDate.TabIndex = 4
        Me.lblendDate.Text = "Enddatum"
        '
        'lblstartDate
        '
        Me.lblstartDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblstartDate.Location = New System.Drawing.Point(195, 407)
        Me.lblstartDate.Name = "lblstartDate"
        Me.lblstartDate.Size = New System.Drawing.Size(58, 13)
        Me.lblstartDate.TabIndex = 4
        Me.lblstartDate.Text = "Startdatum:"
        '
        'datEndDate
        '
        Me.datEndDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.datEndDate.EditValue = Nothing
        Me.datEndDate.Location = New System.Drawing.Point(279, 433)
        Me.datEndDate.Name = "datEndDate"
        Me.datEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datEndDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datEndDate.Size = New System.Drawing.Size(113, 20)
        Me.datEndDate.TabIndex = 3
        '
        'datStartDate
        '
        Me.datStartDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.datStartDate.EditValue = Nothing
        Me.datStartDate.Location = New System.Drawing.Point(279, 403)
        Me.datStartDate.Name = "datStartDate"
        Me.datStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datStartDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.datStartDate.Size = New System.Drawing.Size(113, 20)
        Me.datStartDate.TabIndex = 3
        '
        'radStatistics
        '
        Me.radStatistics.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.radStatistics.Location = New System.Drawing.Point(5, 381)
        Me.radStatistics.Name = "radStatistics"
        Me.radStatistics.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.radStatistics.Properties.Appearance.Options.UseBackColor = True
        Me.radStatistics.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Beste Kunden"), New DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Beste Produkte")})
        Me.radStatistics.Size = New System.Drawing.Size(168, 91)
        Me.radStatistics.TabIndex = 2
        '
        'grdMain
        '
        Me.grdMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdMain.Location = New System.Drawing.Point(0, 0)
        Me.grdMain.MainView = Me.grvMain
        Me.grdMain.Name = "grdMain"
        Me.grdMain.Size = New System.Drawing.Size(681, 356)
        Me.grdMain.TabIndex = 0
        Me.grdMain.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvMain})
        '
        'grvMain
        '
        Me.grvMain.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn1, Me.GridColumn3})
        Me.grvMain.GridControl = Me.grdMain
        Me.grvMain.Name = "grvMain"
        Me.grvMain.OptionsBehavior.Editable = False
        Me.grvMain.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grvMain.OptionsSelection.MultiSelect = True
        Me.grvMain.OptionsView.ShowFooter = True
        Me.grvMain.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Anzahl"
        Me.GridColumn2.DisplayFormat.FormatString = "d"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "Anzahl"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Summe"
        Me.GridColumn1.DisplayFormat.FormatString = "c"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "Summe"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Name / Bezeichnung"
        Me.GridColumn3.FieldName = "Name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(373, 224)
        '
        'iucStatistics
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "iucStatistics"
        Me.Size = New System.Drawing.Size(702, 522)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.tabstatisticsList.ResumeLayout(False)
        Me.tabstatisticsList.PerformLayout()
        CType(Me.spYears.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.chkAllTimeStatistics.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radStatistics.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabstatisticsList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdMain As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvMain As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents radStatistics As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents chkAllTimeStatistics As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblendDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblstartDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents datEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents datStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblCount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSumme As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSumValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCountValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents spYears As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblYears As DevExpress.XtraEditors.LabelControl

End Class
