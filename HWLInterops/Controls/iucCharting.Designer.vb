<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucCharting
    Inherits mainControlContainer

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series
        Dim SideBySideBarSeriesLabel1 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series
        Dim SideBySideBarSeriesLabel2 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel
        Dim SideBySideBarSeriesLabel3 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel
        Me.crtMain = New DevExpress.XtraCharts.ChartControl
        Me.lblchartsHeadline = New DevExpress.XtraEditors.LabelControl
        Me.lblTopArticles = New DevExpress.XtraEditors.LabelControl
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.radStatsByJournal = New DevExpress.XtraEditors.RadioGroup
        Me.datEndDate = New DevExpress.XtraEditors.DateEdit
        Me.datStartDate = New DevExpress.XtraEditors.DateEdit
        Me.lblStartDate = New DevExpress.XtraEditors.LabelControl
        Me.lblendDate = New DevExpress.XtraEditors.LabelControl
        Me.chkPaintAs3D = New DevExpress.XtraEditors.CheckEdit
        Me.chkTopProducts = New DevExpress.XtraEditors.CheckButton
        Me.chkSalesVolume = New DevExpress.XtraEditors.CheckButton
        CType(Me.crtMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.radStatsByJournal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPaintAs3D.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'crtMain
        '
        Me.crtMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        XyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisX.Range.SideMarginsEnabled = True
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisY.Range.SideMarginsEnabled = True
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        XyDiagram1.DefaultPane.BorderVisible = False
        XyDiagram1.DefaultPane.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient
        XyDiagram1.DefaultPane.Shadow.Visible = True

        Me.crtMain.Diagram = XyDiagram1
        Me.crtMain.Location = New System.Drawing.Point(226, 0)
        Me.crtMain.Name = "crtMain"
        Me.crtMain.PaletteName = "Median"
        SideBySideBarSeriesLabel1.LineVisible = True
        Series1.Label = SideBySideBarSeriesLabel1
        Series1.Name = "Series 1"
        SideBySideBarSeriesLabel2.LineVisible = True
        Series2.Label = SideBySideBarSeriesLabel2
        Series2.Name = "Series 2"
        Me.crtMain.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1, Series2}
        SideBySideBarSeriesLabel3.LineVisible = True
        Me.crtMain.SeriesTemplate.Label = SideBySideBarSeriesLabel3
        Me.crtMain.Size = New System.Drawing.Size(767, 586)
        Me.crtMain.TabIndex = 4
        '
        'lblchartsHeadline
        '
        Me.lblchartsHeadline.Location = New System.Drawing.Point(25, 52)
        Me.lblchartsHeadline.Name = "lblchartsHeadline"
        Me.lblchartsHeadline.Size = New System.Drawing.Size(70, 13)
        Me.lblchartsHeadline.TabIndex = 5
        Me.lblchartsHeadline.Text = "Auswertungen"
        '
        'lblTopArticles
        '
        Me.lblTopArticles.Location = New System.Drawing.Point(140, 38)
        Me.lblTopArticles.Name = "lblTopArticles"
        Me.lblTopArticles.Size = New System.Drawing.Size(64, 13)
        Me.lblTopArticles.TabIndex = 6
        Me.lblTopArticles.Text = "Top Produkte"
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Location = New System.Drawing.Point(67, 114)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.RadioGroup1.Properties.Appearance.Options.UseBackColor = True
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Nach Anzahl"), New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Nach Umsatz")})
        Me.RadioGroup1.Size = New System.Drawing.Size(153, 50)
        Me.RadioGroup1.TabIndex = 7
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(63, 19)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(138, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Umsatzentwicklung nach Zeit"
        '
        'radStatsByJournal
        '
        Me.radStatsByJournal.Location = New System.Drawing.Point(63, 228)
        Me.radStatsByJournal.Name = "radStatsByJournal"
        Me.radStatsByJournal.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.radStatsByJournal.Properties.Appearance.Options.UseBackColor = True
        Me.radStatsByJournal.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Nach Anzahl"), New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Nach Umsatz")})
        Me.radStatsByJournal.Size = New System.Drawing.Size(153, 50)
        Me.radStatsByJournal.TabIndex = 7
        '
        'datEndDate
        '
        Me.datEndDate.EditValue = Nothing
        Me.datEndDate.Location = New System.Drawing.Point(116, 319)
        Me.datEndDate.Name = "datEndDate"
        Me.datEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datEndDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.datEndDate.Size = New System.Drawing.Size(100, 20)
        Me.datEndDate.TabIndex = 8
        '
        'datStartDate
        '
        Me.datStartDate.EditValue = Nothing
        Me.datStartDate.Location = New System.Drawing.Point(116, 293)
        Me.datStartDate.Name = "datStartDate"
        Me.datStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.datStartDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.datStartDate.Size = New System.Drawing.Size(100, 20)
        Me.datStartDate.TabIndex = 8
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(52, 296)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(58, 13)
        Me.lblStartDate.TabIndex = 9
        Me.lblStartDate.Text = "Startdatum:"
        '
        'lblendDate
        '
        Me.lblendDate.Location = New System.Drawing.Point(52, 322)
        Me.lblendDate.Name = "lblendDate"
        Me.lblendDate.Size = New System.Drawing.Size(53, 13)
        Me.lblendDate.TabIndex = 9
        Me.lblendDate.Text = "EndDatum:"
        '
        'chkPaintAs3D
        '
        Me.chkPaintAs3D.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPaintAs3D.Location = New System.Drawing.Point(23, 567)
        Me.chkPaintAs3D.Name = "chkPaintAs3D"
        Me.chkPaintAs3D.Properties.Caption = "als 3D Zeichnen"
        Me.chkPaintAs3D.Size = New System.Drawing.Size(163, 19)
        Me.chkPaintAs3D.TabIndex = 10
        '
        'chkTopProducts
        '
        Me.chkTopProducts.GroupIndex = 1
        Me.chkTopProducts.Location = New System.Drawing.Point(22, 85)
        Me.chkTopProducts.Name = "chkTopProducts"
        Me.chkTopProducts.Size = New System.Drawing.Size(110, 23)
        Me.chkTopProducts.TabIndex = 11
        Me.chkTopProducts.TabStop = False
        Me.chkTopProducts.Text = "Top Produkte"
        '
        'chkSalesVolume
        '
        Me.chkSalesVolume.GroupIndex = 1
        Me.chkSalesVolume.Location = New System.Drawing.Point(20, 199)
        Me.chkSalesVolume.Name = "chkSalesVolume"
        Me.chkSalesVolume.Size = New System.Drawing.Size(112, 23)
        Me.chkSalesVolume.TabIndex = 11
        Me.chkSalesVolume.TabStop = False
        Me.chkSalesVolume.Text = "Umsatzentwicklung"
        '
        'iucCharting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkSalesVolume)
        Me.Controls.Add(Me.chkTopProducts)
        Me.Controls.Add(Me.chkPaintAs3D)
        Me.Controls.Add(Me.lblendDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.datStartDate)
        Me.Controls.Add(Me.datEndDate)
        Me.Controls.Add(Me.radStatsByJournal)
        Me.Controls.Add(Me.RadioGroup1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.lblTopArticles)
        Me.Controls.Add(Me.lblchartsHeadline)
        Me.Controls.Add(Me.crtMain)
        Me.Name = "iucCharting"
        Me.Size = New System.Drawing.Size(996, 589)
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.crtMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.radStatsByJournal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.datStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPaintAs3D.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crtMain As DevExpress.XtraCharts.ChartControl
    Friend WithEvents lblchartsHeadline As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTopArticles As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents radStatsByJournal As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents datEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents datStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblStartDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblendDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPaintAs3D As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTopProducts As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkSalesVolume As DevExpress.XtraEditors.CheckButton

End Class
