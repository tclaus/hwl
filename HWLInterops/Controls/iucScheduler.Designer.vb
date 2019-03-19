Option Strict On
Imports System.Windows.Forms
Imports System.ComponentModel

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class iucScheduler
    Inherits mainControlContainer

    'iucScheduler overrides dispose to clean up the component list.
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
        Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(iucScheduler))
        Me.SchedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager()
        Me.ViewSelectorBar1 = New DevExpress.XtraScheduler.UI.ViewSelectorBar()
        Me.ViewSelectorItem1 = New DevExpress.XtraScheduler.UI.ViewSelectorItem()
        Me.ViewSelectorItem2 = New DevExpress.XtraScheduler.UI.ViewSelectorItem()
        Me.ViewSelectorItem3 = New DevExpress.XtraScheduler.UI.ViewSelectorItem()
        Me.ViewSelectorItem4 = New DevExpress.XtraScheduler.UI.ViewSelectorItem()
        Me.ViewSelectorItem5 = New DevExpress.XtraScheduler.UI.ViewSelectorItem()
        Me.btnImportFromOutlook = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExportToOutlook = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SchedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage()
        Me.DateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
        Me.ViewSelector1 = New DevExpress.XtraScheduler.UI.ViewSelector()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnReload = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewSelector1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SchedulerControl1
        '
        Me.SchedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SchedulerControl1.Location = New System.Drawing.Point(209, 0)
        Me.SchedulerControl1.MenuManager = Me.BarManager1
        Me.SchedulerControl1.Name = "SchedulerControl1"
        Me.SchedulerControl1.Size = New System.Drawing.Size(783, 622)
        Me.SchedulerControl1.Start = New Date(2008, 8, 1, 0, 0, 0, 0)
        Me.SchedulerControl1.Storage = Me.SchedulerStorage1
        Me.SchedulerControl1.TabIndex = 0
        Me.SchedulerControl1.Text = "SchedulerControl1"
        Me.SchedulerControl1.Views.DayView.TimeRulers.Add(TimeRuler1)
        Me.SchedulerControl1.Views.WorkWeekView.TimeRulers.Add(TimeRuler2)
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.ViewSelectorBar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ViewSelectorItem1, Me.ViewSelectorItem2, Me.ViewSelectorItem3, Me.ViewSelectorItem4, Me.ViewSelectorItem5, Me.btnImportFromOutlook, Me.btnExportToOutlook, Me.btnReload})
        Me.BarManager1.MaxItemId = 8
        '
        'ViewSelectorBar1
        '
        Me.ViewSelectorBar1.DockCol = 0
        Me.ViewSelectorBar1.DockRow = 0
        Me.ViewSelectorBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.ViewSelectorBar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.ViewSelectorItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ViewSelectorItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.ViewSelectorItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.ViewSelectorItem4), New DevExpress.XtraBars.LinkPersistInfo(Me.ViewSelectorItem5), New DevExpress.XtraBars.LinkPersistInfo(Me.btnImportFromOutlook), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExportToOutlook), New DevExpress.XtraBars.LinkPersistInfo(Me.btnReload)})
        Me.ViewSelectorBar1.OptionsBar.AllowQuickCustomization = False
        Me.ViewSelectorBar1.OptionsBar.DisableClose = True
        Me.ViewSelectorBar1.OptionsBar.DisableCustomization = True
        Me.ViewSelectorBar1.OptionsBar.DrawDragBorder = False
        Me.ViewSelectorBar1.OptionsBar.UseWholeRow = True
        '
        'ViewSelectorItem1
        '
        Me.ViewSelectorItem1.Checked = True
        Me.ViewSelectorItem1.Glyph = CType(resources.GetObject("ViewSelectorItem1.Glyph"), System.Drawing.Image)
        Me.ViewSelectorItem1.GroupIndex = 1
        Me.ViewSelectorItem1.Id = 0
        Me.ViewSelectorItem1.LargeGlyph = CType(resources.GetObject("ViewSelectorItem1.LargeGlyph"), System.Drawing.Image)
        Me.ViewSelectorItem1.Name = "ViewSelectorItem1"
        Me.ViewSelectorItem1.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Day
        '
        'ViewSelectorItem2
        '
        Me.ViewSelectorItem2.Glyph = CType(resources.GetObject("ViewSelectorItem2.Glyph"), System.Drawing.Image)
        Me.ViewSelectorItem2.GroupIndex = 1
        Me.ViewSelectorItem2.Id = 1
        Me.ViewSelectorItem2.LargeGlyph = CType(resources.GetObject("ViewSelectorItem2.LargeGlyph"), System.Drawing.Image)
        Me.ViewSelectorItem2.Name = "ViewSelectorItem2"
        Me.ViewSelectorItem2.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek
        '
        'ViewSelectorItem3
        '
        Me.ViewSelectorItem3.Glyph = CType(resources.GetObject("ViewSelectorItem3.Glyph"), System.Drawing.Image)
        Me.ViewSelectorItem3.GroupIndex = 1
        Me.ViewSelectorItem3.Id = 2
        Me.ViewSelectorItem3.LargeGlyph = CType(resources.GetObject("ViewSelectorItem3.LargeGlyph"), System.Drawing.Image)
        Me.ViewSelectorItem3.Name = "ViewSelectorItem3"
        Me.ViewSelectorItem3.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Week
        '
        'ViewSelectorItem4
        '
        Me.ViewSelectorItem4.Glyph = CType(resources.GetObject("ViewSelectorItem4.Glyph"), System.Drawing.Image)
        Me.ViewSelectorItem4.GroupIndex = 1
        Me.ViewSelectorItem4.Id = 3
        Me.ViewSelectorItem4.LargeGlyph = CType(resources.GetObject("ViewSelectorItem4.LargeGlyph"), System.Drawing.Image)
        Me.ViewSelectorItem4.Name = "ViewSelectorItem4"
        Me.ViewSelectorItem4.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Month
        '
        'ViewSelectorItem5
        '
        Me.ViewSelectorItem5.Glyph = CType(resources.GetObject("ViewSelectorItem5.Glyph"), System.Drawing.Image)
        Me.ViewSelectorItem5.GroupIndex = 1
        Me.ViewSelectorItem5.Id = 4
        Me.ViewSelectorItem5.LargeGlyph = CType(resources.GetObject("ViewSelectorItem5.LargeGlyph"), System.Drawing.Image)
        Me.ViewSelectorItem5.Name = "ViewSelectorItem5"
        Me.ViewSelectorItem5.SchedulerViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline
        '
        'btnImportFromOutlook
        '
        Me.btnImportFromOutlook.Caption = "Von Outlook"
        Me.btnImportFromOutlook.Glyph = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Down
        Me.btnImportFromOutlook.Id = 5
        Me.btnImportFromOutlook.Name = "btnImportFromOutlook"
        Me.btnImportFromOutlook.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnExportToOutlook
        '
        Me.btnExportToOutlook.Caption = "Nach Outlook"
        Me.btnExportToOutlook.Glyph = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Arrow_Up
        Me.btnExportToOutlook.Id = 6
        Me.btnExportToOutlook.Name = "btnExportToOutlook"
        Me.btnExportToOutlook.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(992, 26)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 648)
        Me.barDockControlBottom.Size = New System.Drawing.Size(992, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 26)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 622)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(992, 26)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 622)
        '
        'SchedulerStorage1
        '
        '
        'DateNavigator1
        '
        Me.DateNavigator1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DateNavigator1.HotDate = Nothing
        Me.DateNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.DateNavigator1.Name = "DateNavigator1"
        Me.DateNavigator1.SchedulerControl = Me.SchedulerControl1
        Me.DateNavigator1.Size = New System.Drawing.Size(209, 622)
        Me.DateNavigator1.TabIndex = 1
        '
        'ViewSelector1
        '
        Me.ViewSelector1.BarManager = Me.BarManager1
        Me.ViewSelector1.SchedulerControl = Me.SchedulerControl1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SchedulerControl1)
        Me.Panel1.Controls.Add(Me.DateNavigator1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(992, 622)
        Me.Panel1.TabIndex = 4
        '
        'btnReload
        '
        Me.btnReload.Caption = "Neu Laden"
        Me.btnReload.Glyph = Global.ClausSoftware.HWLInterops.My.Resources.Resources.Refresh
        Me.btnReload.Id = 7
        Me.btnReload.Name = "btnReload"
        Me.btnReload.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'iucScheduler
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "iucScheduler"
        Me.Size = New System.Drawing.Size(992, 648)
        CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewSelector1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SchedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
    Friend WithEvents SchedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
    Friend WithEvents DateNavigator1 As DevExpress.XtraScheduler.DateNavigator
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents ViewSelectorBar1 As DevExpress.XtraScheduler.UI.ViewSelectorBar
    Friend WithEvents ViewSelectorItem1 As DevExpress.XtraScheduler.UI.ViewSelectorItem
    Friend WithEvents ViewSelectorItem2 As DevExpress.XtraScheduler.UI.ViewSelectorItem
    Friend WithEvents ViewSelectorItem3 As DevExpress.XtraScheduler.UI.ViewSelectorItem
    Friend WithEvents ViewSelectorItem4 As DevExpress.XtraScheduler.UI.ViewSelectorItem
    Friend WithEvents ViewSelectorItem5 As DevExpress.XtraScheduler.UI.ViewSelectorItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents ViewSelector1 As DevExpress.XtraScheduler.UI.ViewSelector
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnImportFromOutlook As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExportToOutlook As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnReload As DevExpress.XtraBars.BarButtonItem

End Class
