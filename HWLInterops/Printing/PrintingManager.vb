Imports System.IO
Imports DevExpress
Imports DevExpress.XtraReports.UI
Imports ClausSoftware.Kernel
Namespace Printing
    ''' <summary>
    ''' Stellt Funktionen zum bearbeiten und verwalten von Druck-Layouts zur Verfügung
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PrintingManager
        ''' <summary>
        ''' Aktueller resultierender Report. (Kann das Haupt-Layout und Geschäftsbrief enthalten)
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_mainReport As DevExpress.XtraReports.UI.XtraReport

        ''' <summary>
        ''' Ruft den Namen des Adressfensters ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Const AddressWindowName As String = "lblAddressField"

        ''' <summary>
        ''' Ruft den Namen der Adresszeile ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Const AddressLineName As String = "lblAddressLine"


        ''' <summary>
        ''' Enthält eine Instanz auf die Auflistunge der Report-Objekte des Kernels
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_reportsObject As Kernel.Printing.Reports

        ''' <summary>
        ''' stellt den Typ der Datenquelle für das aktuelle Report dar
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_reportDatasourceKind As Kernel.DataSourceList

        ''' <summary>
        ''' Enthät das aktuelle Briefpapier-Layout
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_businessReport As DevExpress.XtraReports.UI.XtraReport

        ''' <summary>
        ''' Enthält den Systemnamen des aktuellen Reports
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_currentReportName As String

        ''' <summary>
        ''' Stellt eine Auflistung der Nutzdaten bereit
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Dim m_Data As Object

        ''' <summary>
        ''' Enthält das eigene Datenobjekt für das Hauptlayout-Daten
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_mainReportData As Kernel.Printing.Report

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_IsMainLayout As Boolean

        ''' <summary>
        ''' Enthält das eigene Briefpapier-Layout Datenobjekt
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_businessReportData As Kernel.Printing.Report

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_BusinesLayoutEnabled As Boolean

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_showBusinesLayout As Boolean = True

        ''' <summary>
        ''' Enthält eine Auflistung aller Controls, die das Briefpapier darstellen
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_businesReportControls As New Dictionary(Of String, XRControl)

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_Multireports As List(Of Kernel.Printing.Report)

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_pageCopies As Short

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
Private m_printBusinesHeaderOneveryPage As Boolean = True


        ''' <summary>
        ''' Zeigt an, ob das Buisines-Layout angezeigt werden soll oder nicht.
        ''' Abhängig von der Datenquelle - Nur Briefe und Journaldocumente können Briefe-Layout haben.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShowBusinesLayout() As Boolean
            Get
                Return m_showBusinesLayout And IsBusinesLayoutEnabled
            End Get
            Set(ByVal value As Boolean)

                If IsBusinesLayoutEnabled Then
                    m_showBusinesLayout = value
                Else
                    m_showBusinesLayout = False
                End If

                ' Die Layout-Elemente auch ein- oder ausschalten
                SetAllBusinesLayoutControlsVisible(m_showBusinesLayout)

            End Set
        End Property


        ''' <summary>
        ''' Zeigt an, ob das verwendete Layout ein Briefpepier (Buisiness-Layout) ermöglicht oder nicht. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend ReadOnly Property IsBusinesLayoutEnabled() As Boolean
            Get
                Return m_BusinesLayoutEnabled
            End Get

        End Property

        ''' <summary>
        ''' Ruft für BuisinessReports das eigene Report-Objekt ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BusinessReportData() As Kernel.Printing.Report
            Get
                Return m_businessReportData
            End Get
            Set(ByVal value As Kernel.Printing.Report)
                m_businessReportData = value
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, das das Geschäftspapier bearbeitet wurde. Wenn False, wird das Datensatz-LAyout des jeweiligen Moduls bearbeitet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsBusinessLayout() As Boolean
            Get
                Return m_IsMainLayout
            End Get
            Set(ByVal value As Boolean)
                m_IsMainLayout = value
            End Set
        End Property


        ''' <summary>
        ''' Stellt die jeweilige Reporter-Klasse zur Verfügung, das die Layoutdaten des aktuellen Reprts darstellt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MainReportData() As Kernel.Printing.Report
            Get
                Return m_mainReportData
            End Get
            Set(ByVal value As Kernel.Printing.Report)
                m_mainReportData = value
            End Set
        End Property

        ''' <summary>
        ''' Enthält eine Auflistung von Druckbaren Daten
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Property Data() As Object
            Get
                Return m_Data
            End Get
            Set(ByVal value As Object)
                m_Data = value
                ' Datenquelle Zuweisen, falls Report bereits aufgebaut wurde
                If m_mainReport IsNot Nothing Then
                    m_mainReport.DataSource = value
                End If

                PageCopies = 1

            End Set
        End Property


        ''' <summary>
        ''' Ruft den eindeutigen, internen Namen für dieses Durcker-Layout ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ReportName() As String
            Get
                Return m_currentReportName
            End Get
            Set(ByVal value As String)
                m_currentReportName = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Briefpapier-Layout (Geschäftslayout) ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BusinesReport() As DevExpress.XtraReports.UI.XtraReport
            Get
                Return m_businessReport
            End Get
            Set(ByVal value As DevExpress.XtraReports.UI.XtraReport)
                m_businessReport = value
            End Set
        End Property


        ''' <summary>
        ''' Ruft das Layout ab, das speziell für diesen Datentyp vorgesehen war
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property MainReport() As DevExpress.XtraReports.UI.XtraReport
            Get
                Return m_mainReport
            End Get
        End Property


        Property MultiReports As List(Of Kernel.Printing.Report)
            Get
                Return m_Multireports
            End Get
            Set(ByVal value As List(Of Kernel.Printing.Report))
                m_Multireports = value
            End Set
        End Property

        
        ''' <summary>
        ''' Ruft die Anzahl der zu druckenden Seiten ab oder legt diesye fest, die beim nächsten Ausdruck gewählt erden sollen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PageCopies As Short
            Get
                Return m_pageCopies
            End Get
            Set(ByVal value As Short)
                m_pageCopies = value
            End Set
        End Property

        ''' <summary>
        ''' Druckt das Briefe-Layout auf alle seiten oder nur auf der ersten Seite
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PrintBusinesHeaderOneveryPage As Boolean
            Get
                Return m_printBusinesHeaderOneveryPage
            End Get
            Set(value As Boolean)
                m_printBusinesHeaderOneveryPage = value
            End Set
        End Property

        ''' <summary>
        ''' Stetzt im zusammengefügten Report alle Layouts auf "sichtbar" oder "Unsichtbar", 
        ''' </summary>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Private Sub SetAllBusinesLayoutControlsVisible(ByVal value As Boolean)
            For Each item As XRControl In m_businesReportControls.Values
                item.Visible = value
            Next
        End Sub

        ''' <summary>
        ''' Fügt zwei Repprts zusammen, indem das Briefpapier mit aufgenommen wird. 
        ''' Standardmässig wird das Briefpapie auf jeder Seite gedruckt
        ''' </summary>
        ''' <param name="mergedReport"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function MergeReports(ByVal mergedReport As XtraReport) As XtraReport
            Return MergeReports(mergedReport, True)
        End Function

        Private m_headerList As New List(Of String)

        ''' <summary>
        ''' Ruft die Namen von elementen eines Reports ab, die abhängig von der Einstellung "Briefkopf auf jeedr Seite" im Report-Kopf oder auf dem Seitenkopf stehen sollen
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetHeaderelementNames() As List(Of String)
            If m_headerList.Count = 0 Then
                m_headerList.Add("lblDocumentType".ToLower)
                m_headerList.Add("lblContactID".ToLower)
                m_headerList.Add("lblDocumentID".ToLower)
                m_headerList.Add("lblDocumentDate".ToLower)
                m_headerList.Add("pnlDocumentHeader".ToLower) ' Panel - Kein schreibfehler !
                m_headerList.Add("lblDocumentHeaderText".ToLower)
                m_headerList.Add("lblAddressLine".ToLower)
                m_headerList.Add("lblAddressField".ToLower)

            End If
            Return m_headerList
        End Function
        ''' <summary>
        ''' Fügt zwei Reports zusammen und erstellt eines  
        ''' Man kann angeben, ob das Briefpapier auf jeder Seite oder nur auf der ersten Seite (ReportHeader) gedruckt werden soll.
        ''' </summary>
        ''' <param name="mergedReport">Der zusammenzu führende Report</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function MergeReports(ByVal mergedReport As XtraReport, businesHeaderOnEveryPage As Boolean) As XtraReport

            'Dim rep1 As XtraReport = Me.BuisinesReport  ' Das Briefpapier
            'Dim rep2 As XtraReport = Me.MainReport


            ' Bereits vorhandne Brieflaout-Controls entfernen
            Dim bandID As Integer
            Do While bandID < mergedReport.Bands.Count
                Dim ctrlID As Integer

                Do While ctrlID < mergedReport.Bands(bandID).Controls.Count

                    Dim ctrl As XRControl = mergedReport.Bands(bandID).Controls(ctrlID)

                    If TypeOf ctrl.Tag Is String AndAlso CStr(ctrl.Tag) = ClausSoftware.Kernel.Printing.Report.BusinessMarker Then

                        mergedReport.Bands(bandID).Controls.Remove(ctrl) ' Bestehende Löschen - Am TAG erkennen
                    Else
                        ctrlID += 1
                    End If
                Loop

                bandID += 1
            Loop


            Dim mycontrols As New List(Of XRControl)
            m_businesReportControls.Clear()
            ' Steuerelemente des seitenkopfes, die verschoben werden müssten..
            Dim additionalPageHeaderControls As New List(Of XRControl)

            ' Zwischenspeichern der Briefpapier-Controls (Header), alle Steuereelment des Briefpapiers durchgehen
            For Each ctrl As XRControl In BusinesReport.Bands(BandKind.PageHeader).Controls
                Try
                    mycontrols.Add(ctrl)
                    m_businesReportControls.Add(ctrl.Name, ctrl)
                Catch ex As Exception
                    ' Kann zb sein, das im Layout der Control - Name bereits vergeben ist
                    MainApplication.getInstance.log.WriteLog(ex, "MergeReports", "Zusammenfügen des Briefe-Layouts zum Druck-Layout")
                End Try

            Next

            For Each ctrl As XRControl In mergedReport.Bands(BandKind.PageHeader).Controls
                ' Markierte Controls für PageHeader ebenfalls abholen !
                ' String "HeaderItem"
                If Not businesHeaderOnEveryPage Then ' nur, wenn die Elemnte aus dem Seitenkopf entfernt werden müssen
                    If GetHeaderelementNames.Contains(ctrl.Name.ToLower) Then
                        additionalPageHeaderControls.Add(ctrl)
                    End If
                End If
            Next


            If businesHeaderOnEveryPage Then
                ' Nicht existierende Bands anlegen. Für Seitenlayout sind PageHeader und Page Footer nötig
                If mergedReport.Bands.GetBandByType(GetType(PageHeaderBand)) Is Nothing Then
                    Dim bf As New BandFactory
                    mergedReport.Bands.Add(bf.CreateInstance(BandKind.PageHeader))
                End If

            Else  ' Dann ReportHeader
                ' Nicht existierende Bands anlegen. Für Seitenlayout sind PageHeader und Page Footer nötig
                If mergedReport.Bands.GetBandByType(GetType(ReportHeaderBand)) Is Nothing Then
                    Dim bf As New BandFactory
                    mergedReport.Bands.Add(bf.CreateInstance(BandKind.ReportHeader))
                End If
            End If

            ' Fusszeile unverändert
            If mergedReport.Bands.GetBandByType(GetType(PageFooterBand)) Is Nothing Then
                Dim bf As New BandFactory
                mergedReport.Bands.Add(bf.CreateInstance(BandKind.PageFooter))
            End If

            ' Hinzufügen zum Ziel-Layout (HEADER)
            For Each ctrl As XRControl In mycontrols
                ' Nicht mehrfach hinzufügen, sondern löschen und Neu hinzu!
                Dim oldItem As XRControl = Nothing

                If businesHeaderOnEveryPage Then
                    oldItem = mergedReport.Bands(BandKind.PageHeader).FindControl(ctrl.Name, True) ' Bestehendes Control im Zielreport suchen und gegegebenfalls entfernen
                Else
                    oldItem = mergedReport.Bands(BandKind.ReportHeader).FindControl(ctrl.Name, True) ' Bestehendes Control im Zielreport suchen und gegegebenfalls entfernen
                End If

                If oldItem IsNot Nothing Then

                    If Not oldItem.Name.Equals("lblAddressField", StringComparison.InvariantCultureIgnoreCase) Then
                        If businesHeaderOnEveryPage Then
                            mergedReport.Bands(BandKind.PageHeader).Controls.Remove(oldItem)
                        Else
                            mergedReport.Bands(BandKind.ReportHeader).Controls.Remove(oldItem)
                        End If

                    End If

                End If

                ' Nur sichtbare Elemente des Briefkopfes auch übernehmen
                'If ctrl.Visible Then
                ctrl.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker


                If ctrl.Name.Equals("lblAddressField", StringComparison.InvariantCultureIgnoreCase) Then ' Dieses Contrl wird beim Einrichten definiert, aber im Ziellayout durch ein eigenes (Datengebundenes ersetzt) 
                    ' Hier ist die Position des bestehenden Layouts zu ermitteln und NICHT ein eiteres Control hinzuzufügen

                    Dim targetControl As XRControl = mergedReport.Bands(BandKind.PageHeader).FindControl("lblAddressField", True)
                    If targetControl IsNot Nothing Then
                        targetControl.LeftF = ctrl.LeftF
                        targetControl.TopF = ctrl.TopF
                        targetControl.WidthF = ctrl.WidthF
                        targetControl.HeightF = ctrl.HeightF
                        targetControl.Tag = Nothing
                    Else
                        MainApplication.getInstance.log.WriteLog("Konnte kein Adressfenster im Ziel-Layout finden")
                    End If

                Else ' Normales Control aus dem Briefe-Layout. Zum Ziellayout hinzufügen
                    ' Keine doppelten Namen zulassen 
                    Do While mergedReport.FindControl(ctrl.Name, True) IsNot Nothing
                        Dim ctrlNumber As Integer
                        ctrl.Name = ctrl.Name & "_" & ctrlNumber
                        ctrlNumber += 1
                    Loop

                    If businesHeaderOnEveryPage Then

                        mergedReport.Bands(BandKind.PageHeader).Controls.Add(ctrl)
                    Else
                        mergedReport.Bands(BandKind.ReportHeader).Controls.Add(ctrl)
                    End If

                End If

                ' End If
            Next

            mycontrols.Clear() ' Zwischenspeicher löschen


            If Not businesHeaderOnEveryPage Then
                ' dann die elemente aus 'additionalPageHeaderControls' in den Report-Header verschieben
                mergedReport.Bands(BandKind.ReportHeader).Controls.AddRange(additionalPageHeaderControls.ToArray)
                ' die ermittelte Liste rumwerfen
                For Each additionalPageHeaderControl As XRControl In additionalPageHeaderControls
                    If mergedReport.Bands(BandKind.PageHeader).Controls.Contains(additionalPageHeaderControl) Then
                        mergedReport.Bands(BandKind.PageHeader).Controls.Remove(additionalPageHeaderControl)
                    End If

                Next

            End If

            ' In der Fusszeile keine Änderung

            '           Fusszeile
            ' =============================
            For Each ctrl As XRControl In BusinesReport.Bands(BandKind.PageFooter).Controls
                mycontrols.Add(ctrl)

                m_businesReportControls.Add(ctrl.Name, ctrl) ' Alle Zwischenspeichern

            Next


            For Each ctrl As XRControl In mycontrols

                Dim oldItem As XRControl = Nothing
                If mergedReport.Bands(BandKind.PageFooter) IsNot Nothing Then
                    oldItem = mergedReport.Bands(BandKind.PageFooter).FindControl(ctrl.Name, True)
                End If

                If oldItem IsNot Nothing Then
                    mergedReport.Bands(BandKind.PageFooter).Controls.Remove(oldItem)
                End If
                If ctrl.Visible Then
                    ctrl.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker

                    Do While mergedReport.FindControl(ctrl.Name, True) IsNot Nothing
                        Dim ctrlNumber As Integer = 1
                        ctrl.Name = ctrl.Name & "_" & ctrlNumber
                        ctrlNumber += 1
                    Loop

                    mergedReport.Bands(BandKind.PageFooter).Controls.Add(ctrl)
                End If
            Next

            ' Normale Controls aus dem Seitenkopf an den oberen Rand verschieben
            If Not businesHeaderOnEveryPage Then MoveHeaderItems(mergedReport)

            TranslateReport(mergedReport)

            Return mergedReport
        End Function


        ''' <summary>
        ''' Ruft den Type der Datenquelle ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ReportDatasourceKind() As Kernel.DataSourceList
            Get
                Return m_reportDatasourceKind
            End Get
            Set(ByVal value As Kernel.DataSourceList)
                m_reportDatasourceKind = value
                CheckBusinessLayout()
                PageCopies = 1
            End Set
        End Property

        ''' <summary>
        ''' Speichert das Briefpapier ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveBusinessLayout()

            If BusinesReport IsNot Nothing Then
                SaveLayoutData(BusinessReportData, BusinesReport, True)
            Else
                Debug.Print("SaveBuisinessLayout: Briefpapier Layout war nothing, kann nicht speichern")
            End If
        End Sub

        ''' <summary>
        ''' Speichert das spezielle Layout dieser Druck-Klasse
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveMainLayout()

            If MainReport IsNot Nothing Then
                SaveLayoutData(MainReportData, MainReport, False)

            Else
                Debug.Print("SaveMainLayout: Main Layout war nothing, kann nicht speichern")
            End If

        End Sub

        ''' <summary>
        ''' Speichert den internen Datenstrom eines Reports ab
        ''' </summary>
        ''' <param name="layout">Stellt das eigene Report-Objekt dar</param>
        ''' <param name="xreport">Stellt das UI-Report Layout dar</param>
        ''' <param name="markBusinessItems">Falls Wahr, werden Elemente des Briefpapiers entfernt. Sollte nicht gesetzt werden, wenn das Briefpapier selber gespeichert wird (dumm)</param>
        ''' <remarks></remarks>
        Private Sub SaveLayoutData(ByVal layout As Kernel.Printing.Report, ByVal xreport As XtraReport, ByVal markBusinessItems As Boolean)

            If markBusinessItems Then ' Briefpapier-Logo markieren
                Dim bandID As Integer
                Do While bandID < xreport.Bands.Count
                    Dim ctrlID As Integer

                    Do While ctrlID < xreport.Bands(bandID).Controls.Count

                        Dim ctrl As XRControl = xreport.Bands(bandID).Controls(ctrlID)
                        ctrl.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker
                        ctrlID += 1
                    Loop

                    bandID += 1
                Loop
            Else

                ' Alle Business-Daten wieder entfernen

                Dim bandID As Integer
                Do While bandID < xreport.Bands.Count
                    Dim ctrlID As Integer

                    Do While ctrlID < xreport.Bands(bandID).Controls.Count

                        Dim ctrl As XRControl = xreport.Bands(bandID).Controls(ctrlID)
                        If TypeOf ctrl.Tag Is String AndAlso CStr(ctrl.Tag) = ClausSoftware.Kernel.Printing.Report.BusinessMarker Then
                            xreport.Bands(bandID).Controls.Remove(ctrl)
                        Else
                            ctrlID += 1

                        End If
                    Loop

                    bandID += 1
                Loop

            End If

            Dim Value As String
            Using m As New MemoryStream
                xreport.SaveLayout(m)

                Value = System.Text.UTF8Encoding.UTF8.GetString(m.GetBuffer())
            End Using

            If layout Is Nothing Then
                layout = m_reportsObject.GetNewItem

                If xreport Is BusinesReport Then
                    layout.DataSourceKind = DataSourceList.BusinessLayouts
                Else
                    layout.DataSourceKind = m_reportDatasourceKind

                End If
                layout.ReportName = "Standard"
                layout.IsDefault = True
            End If

            layout.ReportData = Value

            layout.Save()

        End Sub

        Private m_isLoaded As Boolean

        Public ReadOnly Property IsLoaded() As Boolean
            Get
                Return m_isLoaded
            End Get

        End Property


        ''' <summary>
        '''  Läd Daten für das Drucken vorab
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PreloadPrintingAssemblies()
            If Not IsLoaded Then
                Me.InitBusinessLayout()
            End If

        End Sub

        ''' <summary>
        ''' Initialisiert das Briefpapier-Layout (Geschäftslayout), es umgiebt das eigentliche Daten-Layout
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub InitBusinessLayout()
            SyncLock Me

                Try
                    Debug.Print("Initialisiere das Business-Layout")
                    If m_businessReport Is Nothing Then
                        ' Neues Dokument erstellen
                        m_businessReport = GetNewReport()
                    End If

                    m_businessReport.Name = "Briefpapier" ' TODO: NLS

                    If m_reportsObject Is Nothing Then
                        m_reportsObject = New Kernel.Printing.Reports(MainApplication.getInstance)
                    End If

                    Dim BusinesReports As Kernel.Printing.Reports ' ein oder mehrerer Geschäftspapier-Layouts abholen
                    BusinesReports = m_reportsObject.GetBusinessLayouts

                    m_businessReportData = BusinesReports.GetDefaultReportLayout ' Das Default-Geschäftspapier-Layout abholen


                    ' Konnte kein Layout gefunden werden, dann aus dem alten System (HWL-1.7 / HWL 1.5) ein Layout organisieren..
                    If m_businessReportData Is Nothing Then
                        Dim classicLayoutManager As New PrintingManagerOldSystem()
                        classicLayoutManager.LoadPageSettings(m_businessReport) ' Layout aus alter installation einlesen 

                        Dim m As New MemoryStream

                        m_businessReport.SaveLayout(m)

                        Dim Value As String = System.Text.ASCIIEncoding.ASCII.GetString(m.GetBuffer())

                        m_businessReportData = BusinesReports.GetNewItem


                        m_businessReportData.ReportData = Value ' Neuem Report die werte des Classic-Laoyuts zuweisen

                        m_businessReportData.ReportName = "Briefpapier" ' TODO: NLS
                        m_businessReportData.DataSourceKind = DataSourceList.BusinessLayouts
                        m_businessReportData.IsDefault = True
                        m_businessReportData.Save() ' Und sichern !
                    Else

                        ' Bestehendes Layout aus dem Datenstrom neu einlesen

                        m_businessReport.LoadLayout(m_businessReportData.GetReportStream)
                        ' Test trycast(m_businessReport.Bands( BandKind.PageHeader).FindControl("picHeader",True),XtraReports.UI.XRPictureBox)

                    End If

                Catch ex As Exception
                    MainApplication.getInstance.log.WriteLog(ex, "PrintingManager", "Error in InitBusinessLayout")

                Finally
                    m_isLoaded = True
                End Try
            End SyncLock

        End Sub



        ''' <summary>
        ''' Püft alle Druckbaren Module und erstellt ein standardLayout, sofern die Liste Leer ist und kein default-Layout gefunden wreden konnte
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub CheckAndRepairDefaultLaoyuts()
            ' Kein Modul ohne StandradLayout
            ' Alle Layouts prüfen
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)

            For Each dataSourceItem As DataSourceList In [Enum].GetValues(GetType(DataSourceList))
                If dataSourceItem = DataSourceList.None Then Continue For

                reps.SetDataType(dataSourceItem) ' Datentyp setzen
                Dim checkReport As Kernel.Printing.Report

                checkReport = reps.GetDefaultReportLayout

                If checkReport Is Nothing Then ' Kein Report dieses Typs in der Datenbank gefunden. Lade mitgeliefertes Standard-Layout

                    ' Hier wird nun ein Standard-Report aus den mitgebrachten Ressourcen-Dateien erstellt
                    Dim newReport As Kernel.Printing.Report = Nothing

                    Select Case dataSourceItem
                        Case DataSourceList.Addressbook
                            newReport = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard__Adressbuch)
                            newReport.DataSourceKind = DataSourceList.Addressbook

                        Case DataSourceList.Articles
                            newReport = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Artikellisten)
                            newReport.DataSourceKind = DataSourceList.Articles

                        Case DataSourceList.BillOfMaterial
                            newReport = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_BOM)
                            newReport.DataSourceKind = DataSourceList.BillOfMaterial

                        Case DataSourceList.CashJournalMonthy
                            newReport = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_CashJournalMonthly) ' Monatsblatt
                            newReport.DataSourceKind = DataSourceList.CashJournalMonthy

                        Case DataSourceList.CashJournalYearly
                            newReport = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_CashJournalYearly) ' Gesamtübersicht (ganzes Jahr)
                            newReport.DataSourceKind = DataSourceList.CashJournalYearly

                        Case DataSourceList.Journaldocument
                            newReport = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Invoices)
                            newReport.DataSourceKind = DataSourceList.Journaldocument


                        Case Else
                            ' Dann gab es kein Report
                    End Select

                    If newReport IsNot Nothing Then ' es konnte ein Report eingelesen werden
                        Try
                            newReport.IsDefault = True
                            newReport.Save()
                            reps.Add(newReport)
                        Catch
                        End Try

                    End If

                End If

            Next



        End Sub

        ''' <summary>
        ''' Setzt Seiteneigenschaften und legt die Datenbindung fest. Erstellt das MainReport
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub InitMainPageLayout()
            Try

                Dim reportData As String = ""

                m_mainReport = GetNewReport()



                If m_reportsObject Is Nothing Then
                    m_reportsObject = New Kernel.Printing.Reports(MainApplication.getInstance)
                End If

                'Die LIste anhand des Report-Typs einschränken
                m_reportsObject.SetDataType(m_reportDatasourceKind)


                If MainReportData Is Nothing Then ' Scheinbar war dies nothing, dann einen als 'Default' markiertes Report verwenden
                    Me.MainReportData = m_reportsObject.GetDefaultReportLayout
                End If

                If Me.MainReportData Is Nothing Then ' Kein Report dieses Typs in der Datenbank gefunden. Lade mitgeliefertes Standard-Layout

                    ' Hier wird nun ein Standard-Report aus den mitgebrachten Ressourcen-Dateien erstellt
                    Dim newReport As Kernel.Printing.Report

                    Select Case m_reportDatasourceKind
                        Case DataSourceList.Addressbook : newReport = PrintingDefaults.ResetDefaultLayoutAdressbook()
                        Case DataSourceList.Articles : newReport = PrintingDefaults.ResetDefaultLayoutArticles()
                        Case DataSourceList.BillOfMaterial : newReport = PrintingDefaults.ResetDefaultLayoutBillOfMaterial()
                        Case DataSourceList.CashJournalMonthy : newReport = PrintingDefaults.ResetDefaultLayoutCashJournalMonthly()
                        Case DataSourceList.CashJournalYearly : newReport = PrintingDefaults.ResetDefaultLayoutCashJournalYearly()
                        Case DataSourceList.Journaldocument : newReport = PrintingDefaults.ResetDefaultLayoutJournalDocument()
                        Case DataSourceList.Transactions : newReport = PrintingDefaults.ResetDefaultLayoutTransactions
                        Case Else
                            Throw New NotImplementedException("Ein Standard Report für diesen Typ :'" & m_reportDatasourceKind.ToString & "' existiert nicht")
                    End Select


                    ' Dieses Report kann bereits eingelesen worden sein; achte auf gleiche RepID

                    newReport.IsDefault = True
                    newReport.Save()
                    m_reportsObject.Add(newReport)
                    Me.MainReportData = newReport
                End If


                If MainReportData IsNot Nothing Then ' Dann war kein lokales Design für diesen Datentyp vorhanden

                    ' Nun das Layout aus dem Stream einlesen
                    m_mainReport.LoadLayout(MainReportData.GetReportStream)

                End If

                'TODO: Nur setzen, wenn nicht "Alle" gefordert ist
                If Me.Data IsNot Nothing Then
                    m_mainReport.DataSource = Me.Data

                Else
                    'TODO: Vielleicht nur die ersten 10 Datensätze ? 

                    MainApplication.getInstance.SendMessage(GetText("msgWaitFetchingData", "Hole Daten..."))


                    Select Case m_reportDatasourceKind
                        Case DataSourceList.Addressbook
                            Dim a As New Adressen(MainApplication.getInstance)
                            a.TopReturnedObjects = 10
                            m_mainReport.DataSource = a

                        Case DataSourceList.Articles
                            Dim a As New Articles(MainApplication.getInstance)
                            a.TopReturnedObjects = 10
                            m_mainReport.DataSource = a

                        Case DataSourceList.CashJournalMonthy, DataSourceList.CashJournalYearly
                            Dim journalData As Kernel.CashJournalTimeFrame = MainApplication.getInstance.CashJournalTimeFrame.GetCashJournalTimeFrame(New Date(Now.Year - 2, 1, 1), New Date(Now.Year, 12, 31))
                            Dim dataList As New List(Of CashJournalTimeFrame)

                            dataList.Add(journalData)
                            m_mainReport.DataSource = dataList

                        Case DataSourceList.Journal
                            Dim a As New JournalDocuments(MainApplication.getInstance)
                            a.TopReturnedObjects = 10
                            m_mainReport.DataSource = a

                        Case DataSourceList.Journaldocument

                            Dim p As JournalDocument = MainApplication.getInstance.JournalDocuments(MainApplication.getInstance.JournalDocuments.Count - 1)

                            Dim dataList As New List(Of JournalDocument)
                            dataList.Add(p)

                            m_mainReport.DataSource = dataList

                        Case DataSourceList.Reminders
                            Dim a As New Reminders(MainApplication.getInstance)
                            a.TopReturnedObjects = 10
                            m_mainReport.DataSource = a

                        Case DataSourceList.Transactions
                            Dim a As New Transactions(MainApplication.getInstance)
                            a.TopReturnedObjects = 10
                            m_mainReport.DataSource = a

                        Case DataSourceList.Letters
                            Dim a As New Letters(MainApplication.getInstance)
                            a.TopReturnedObjects = 10
                            m_mainReport.DataSource = a

                        Case DataSourceList.FixedCosts
                            Dim a As New FixedCosts(MainApplication.getInstance)
                            a.TopReturnedObjects = 10
                            m_mainReport.DataSource = a

                    End Select



                End If

                CheckBusinessLayout()

                ' es wurde kein Layout gefunden oder es hatte keinlerlei standard Bänder
                If m_mainReport.Bands.Count = 0 Then
                    Dim detailBand As Band
                    Dim b As New BandFactory()
                    detailBand = b.CreateInstance(BandKind.Detail)
                    detailBand.Name = GetText("Details", "Details")
                    m_mainReport.Bands.Add(detailBand)
                    m_mainReport.Bands.Add(b.CreateInstance(BandKind.PageHeader))

                End If

                'Falls Briefpapier gewünscht, dann das Briefpapier ebenfalls schonmal einladen
                If m_BusinesLayoutEnabled Then
                    InitBusinessLayout()
                    MergeReports(Me.MainReport, Me.PrintBusinesHeaderOneveryPage)
                End If

                m_mainReport.CreateDocument()
                m_mainReport.Name = MainApplication.getInstance.Languages.GetTextBydataKind(m_reportDatasourceKind)


            Catch ex As Exception
                ' Absturz beim wählen von vorgegebenen LAyouts !
                Debug.Print("Exception: InitMainLayout: " & ex.Message)

            End Try
        End Sub




        ''' <summary>
        ''' Ruft den minimalen Seitenrand in 1/100 Zoll ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function PrinterBounds() As System.Drawing.Point

            Dim ps As New System.Drawing.Printing.PageSettings()
            Dim pp As New System.Drawing.Printing.PrinterSettings()


            For Each pname As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                pp.PrinterName = pname
                If pp.IsDefaultPrinter Then
                    ps.PrinterSettings = pp

                    Return New System.Drawing.Point(CInt(ps.HardMarginX), CInt(ps.HardMarginY))
                End If
            Next



        End Function

        ''' <summary>
        ''' Gibt wahr zurück, wenn das aktuelle Layout ein Buisinesslayout erfordert
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckBusinessLayout() As Boolean

            ' Anhand der Datenquelle festlegen, ob es ein Buisiness-LAyout gibt oder nicht 
            Select Case m_reportDatasourceKind
                Case DataSourceList.Journaldocument : m_BusinesLayoutEnabled = True
                Case DataSourceList.Letters : m_BusinesLayoutEnabled = True
                Case DataSourceList.Reminders : m_BusinesLayoutEnabled = True
                Case Else
                    m_BusinesLayoutEnabled = False
            End Select
            Return m_BusinesLayoutEnabled

        End Function

        ''' <summary>
        ''' Ruft ein neues Report-Objekt ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetNewReport() As XtraReport
            Dim sw As New Stopwatch
            sw.Start()

            Dim newReport As New DevExpress.XtraReports.UI.XtraReport() ' Ein Report-Control erstellen; in diesem werden die Layoutdaten gesteckt
            Debug.Print("Created New Report: " & sw.Elapsed.ToString)
            ' Standard-Werte setzen 
            newReport.Name = GetText(m_reportDatasourceKind.ToString, m_reportDatasourceKind.ToString)

            'TODO: seiteneinstellung des Standarddruckers holen; dies dann speichern und festhalten ? 


            newReport.PaperKind = System.Drawing.Printing.PaperKind.A4
            newReport.ReportUnit = ReportUnit.TenthsOfAMillimeter
            'newReport.Margins.Left = CInt(PrinterBounds.X * 2.54) + 40 '(in zentel mm)
            'newReport.Margins.Right = 0
            'newReport.Margins.Top = CInt(PrinterBounds.Y * 2.54) + 20 ' (in zentel mm)
            'newReport.Margins.Bottom = newReport.Margins.Top

            sw.Stop()
            Debug.Print("Created New Report ;PageSettings: " & sw.Elapsed.ToString)

            Return newReport
        End Function

        ''' <summary>
        ''' Verschiebt die Elemente des Kopfes nach ganz oben. (Für Briefpapier auf der ersten seite nötig) 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MoveHeaderItems(ByVal mergedReport As XtraReport)

            Dim offset As Single = 1000

            ' Zwischenspeichern der Briefpapier-Controls (Header), alle Steuereelment des Briefpapirs durchgehen
            For Each ctrl As XRControl In mergedReport.Bands(BandKind.PageHeader).Controls
                Try
                    offset = Math.Min(ctrl.TopF + ctrl.HeightF, offset)

                    m_businesReportControls.Add(ctrl.Name, ctrl)
                Catch ex As Exception

                End Try

            Next

            ' Kleine Toleranz hinzufügen
            offset -= 40

            'Offset ist nun bekannt; verschiebe nun nach oben
            For Each ctrl As XRControl In mergedReport.Bands(BandKind.PageHeader).Controls
                Try

                    ctrl.TopF -= offset
                Catch ex As Exception

                End Try

            Next



            ' Die Resthöhe anpassen
            mergedReport.Bands(BandKind.PageHeader).HeightF -= offset

        End Sub

        ''' <summary>
        ''' Lokalisiert das Layout
        ''' </summary>
        ''' <param name="report"></param>
        ''' <remarks></remarks>
        Private Sub TranslateReport(report As XtraReport)
            ' Übersetzte Texte von Labels
            ' Nur, wenn nicht Datengebunden
            ' Nur, wenn nicht als "BuisinesLayout" getagged
            ' Prefix: "Print_" & Labelname

            For Each bandItem As Band In report.Bands


                For Each ctrlItem As XRControl In bandItem.Controls
                    TranslateCtrl(ctrlItem)
                Next
            Next


        End Sub

        ''' <summary>
        ''' Übersetzt die Menge an Steuerelementen
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <remarks></remarks>
        Private Sub TranslateCtrl(ctrl As XRControl)
            Const namePrefix As String = "Printerlayout_"
            If TypeOf ctrl Is XRLabel Then

                ' Neuen Businessmarker nicht verwenden
                If TypeOf ctrl.Tag Is String Then
                    If CStr(ctrl.Tag) = ClausSoftware.Kernel.Printing.Report.BusinessMarker Then Exit Sub
                End If

                If ctrl.DataBindings.Count > 0 Then Exit Sub ' Datengebundene Teile nicht übersetzen

                'TODO: Prüfe auf die gebundene Eigenschaft "Text"
                ctrl.Text = GetText(namePrefix & ctrl.Name, ctrl.Text)

            Else

                If ctrl.HasChildren Then
                    For Each innerCtrl As XRControl In ctrl.Controls
                        TranslateCtrl(innerCtrl)
                    Next
                End If
            End If

        End Sub
        ''' <summary>
        ''' Bereitet das Report für den Ausdruck vor
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CreateDocument()
            ' Layout, Daten und Typ sind gesetzt
            InitBusinessLayout()

            m_mainReport = GetNewReport() ' Neuen Report erstellen

            CheckBusinessLayout()

            MainReport.Pages.Clear()

            MainReport.PrintingSystem.ContinuousPageNumbering = False ' Jedes TeilDokument hat seine eigenen Nummerierung
            MainReport.PrintingSystem.ShowMarginsWarning = False  ' warnung auf Seitenränder unterdrücken

            For Each item As Kernel.Printing.Report In Me.m_Multireports
                Try
                    Dim Newreport As XtraReport = GetNewReport()

                    Newreport.LoadLayout(item.GetReportStream)

                    Newreport.DataSource = Data

                    Newreport.CreateDocument()
                    If ShowBusinesLayout Then
                        MergeReports(Newreport, Me.PrintBusinesHeaderOneveryPage)
                    End If
                    Newreport.CreateDocument()
                    MainReport.Pages.AddRange(Newreport.Pages)

                    '  MainReport.CreateDocument()
                Catch ex As Exception
                    MainApplication.getInstance.log.WriteLog(ex, "PrintingManager", "ERROR while creating Printlayout: '" & item.Description & "'")
                End Try

            Next


            MainReport.PrintingSystem.Document.Name = GetDocumentName()
            MainReport.PrintingSystem.ShowPrintStatusDialog = False

            ' (Durch Layoutanpassung zu lösen!)
            '' Im Falle von Kassenbuch: Adressline auffüllen
            'Dim addressline As DevExpress.XtraReports.UI.XRControl = MainReport.FindControl("lblAddressLine", True)
            'If addressline IsNot Nothing Then
            '    addressline.Text = MainApplication.getInstance.Settings.page
            'End If



            ' PDF - Optionen einstellen, falls gewünscht
            With MainReport.PrintingSystem.ExportOptions.Pdf
                .DocumentOptions.Application = MainApplication.getInstance.Languages.GetText("{AppName}")
                .DocumentOptions.Subject = GetDocumentSubject()
                .DocumentOptions.Title = MainReport.PrintingSystem.Document.Name
            End With


            ' Obtain the current export options.
            Dim options As XtraPrinting.ExportOptions = MainReport.PrintingSystem.ExportOptions

            ' Set Print Preview options.
            options.PrintPreview.ActionAfterExport = XtraPrinting.ActionAfterExport.AskUser

            options.PrintPreview.DefaultDirectory = GetLastPrintDocumentsFolder

            ' Falls nicht peniebel 'ungültige' Zeichen entfernt werden, wird der Default Dateiname "Document" angenommen
            options.PrintPreview.DefaultFileName = MainReport.PrintingSystem.Document.Name.Replace(System.IO.Path.GetInvalidFileNameChars, "_").Replace(System.IO.Path.GetInvalidPathChars, "").Replace(":", "").Replace(",", "").Replace(".", "_").Trim
            options.PrintPreview.SaveMode = XtraPrinting.SaveMode.UsingSaveFileDialog
            options.PrintPreview.ShowOptionsBeforeExport = False


            ' Versuche Mail-Adresse aus dem Adressbuch zu holen 
            options.Email.RecipientAddress = TryGetMailAdress()
            options.Email.Subject = GetDocumentName()
        End Sub

        ''' <summary>
        ''' Versuche aus dem Druck eine Mail-Adresse abzuholen
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function TryGetMailAdress() As String
            Dim mailAdress As String = String.Empty

            If TypeOf Data Is List(Of JournalDocument) Then
                'hole mal das erste Dokument ab; schaun wir mal was das ist ? 
                If CType(Data, List(Of JournalDocument)).Count > 0 Then
                    Dim firstItem As Object = CType(Data, List(Of JournalDocument))(0)
                    Dim jdocument As JournalDocument = CType(firstItem, JournalDocument)

                    If jdocument.Address IsNot Nothing Then
                        mailAdress = jdocument.Address.EMail.Trim.Trim(New Char() {";"c}) ' Ungültige Zeichen entfernen
                    End If

                End If
            End If

            Return mailAdress
        End Function

        Private Shared m_lastPrintDocumentsFolder As String

        ''' <summary>
        ''' Ruft den letzten bekannten Export-Pfad auf oder 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property GetLastPrintDocumentsFolder() As String
            Get
                If String.IsNullOrEmpty(m_lastPrintDocumentsFolder) Then
                    m_lastPrintDocumentsFolder = MainApplication.getInstance.Settings.GetSetting("LastPrintDocumentsFolder", "Printing", "%Homedrive%%Homepath%", MainApplication.getInstance.CurrentUser.Key)
                End If
                Return m_lastPrintDocumentsFolder
            End Get
            Set(value As String)
                m_lastPrintDocumentsFolder = value
                MainApplication.getInstance.Settings.SetSetting("LastPrintDocumentsFolder", "Printing", value, MainApplication.getInstance.CurrentUser.Key)
            End Set
        End Property

        ''' <summary>
        ''' Versucht einen Standatdnamen für das gerade zu druckende Dokument zu ermitteln
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetDocumentName() As String

            Dim defaultName As String
            Dim prefixName As String = MainApplication.getInstance.Languages.GetText("{AppName}") & ": "

            ' einen standarnamen für den Ausdruck finden
            defaultName = prefixName & MainApplication.getInstance.Languages.GetTextBydataKind(m_reportDatasourceKind)

            ' Jorunaldokument

            defaultName = prefixName & GetDocumentSubject()
            Return defaultName
        End Function

        ''' <summary>
        ''' Ruft den Standard
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetDocumentSubject() As String
            Dim defaultname As String = String.Empty
            If TypeOf Data Is List(Of JournalDocument) Then
                'hole mal das erste Dokument ab; schaun wir mal was das ist ? 
                If CType(Data, List(Of JournalDocument)).Count > 0 Then
                    Dim firstItem As Object = CType(Data, List(Of JournalDocument))(0)
                    defaultname = CType(firstItem, JournalDocument).ShortDisplaystring
                End If
            End If

            defaultname = defaultname.Replace(vbCrLf, "")
            defaultname = defaultname.Trim

            Return defaultname

        End Function

        ''' <summary>
        ''' Zeigt eine Reports-Auflistung in einem eigenen Vorschau-Fenster an
        ''' </summary>
        ''' <remarks></remarks>
        Sub ShowPreview()

            CreateDocument()



            ' einige Eigenschaften ausblenden
            MainReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)
            MainReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportMht, DevExpress.XtraPrinting.CommandVisibility.None)
            MainReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportMht, DevExpress.XtraPrinting.CommandVisibility.None)
            MainReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportRtf, DevExpress.XtraPrinting.CommandVisibility.None)
            MainReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

            MainReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendMht, DevExpress.XtraPrinting.CommandVisibility.None)
            MainReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendRtf, DevExpress.XtraPrinting.CommandVisibility.None)

            MainReport.PrintingSystem.SetCommandVisibility(XtraPrinting.PrintingSystemCommand.Customize, XtraPrinting.CommandVisibility.None)


            Dim eo As XtraPrinting.ExportOptions = MainReport.PrintingSystem.ExportOptions
            ' TODO: Image Formate einschränken beim Durck-Export

            RemoveHandler MainReport.PrintingSystem.StartPrint, AddressOf StartPrint
            AddHandler MainReport.PrintingSystem.StartPrint, AddressOf StartPrint

            MainReport.ShowPreview()

        End Sub

        ''' <summary>
        ''' Druckt eine Reports-Auflistung direkt und ohne weitere Nachfrage
        ''' </summary>
        ''' <remarks></remarks>
        Sub PrintDirect()

            CreateDocument()

            RemoveHandler MainReport.PrintingSystem.StartPrint, AddressOf StartPrint
            AddHandler MainReport.PrintingSystem.StartPrint, AddressOf StartPrint



            MainReport.ShowPrintStatusDialog = False

            MainReport.Print()

        End Sub

        Private Sub StartPrint(ByVal sender As Object, ByVal e As XtraPrinting.PrintDocumentEventArgs)
            e.PrintDocument.PrinterSettings.Copies = Me.PageCopies

        End Sub




    End Class


    Friend Class cHandler
        Implements XtraPrinting.ICommandHandler


        Public Function CanHandleCommand(ByVal command As DevExpress.XtraPrinting.PrintingSystemCommand, ByVal printControl As DevExpress.XtraPrinting.IPrintControl) As Boolean Implements DevExpress.XtraPrinting.ICommandHandler.CanHandleCommand
            If command = XtraPrinting.PrintingSystemCommand.Print Or command = XtraPrinting.PrintingSystemCommand.PrintDirect Then
                Return True
            End If
            Return False
        End Function

        Public Sub HandleCommand(ByVal command As DevExpress.XtraPrinting.PrintingSystemCommand, ByVal args() As Object, ByVal printControl As DevExpress.XtraPrinting.IPrintControl, ByRef handled As Boolean) Implements DevExpress.XtraPrinting.ICommandHandler.HandleCommand
            Dim p As DevExpress.XtraPrinting.XtraPageSettings = CType(printControl.PrintingSystem.PageSettings, XtraPrinting.XtraPageSettings)




        End Sub
    End Class

    ''' <summary>
    ''' Stellt eine Klasse bereit, die Standardlayouts wieder herstellen kann
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class PrintingDefaults


        Friend Shared Sub SetDefaultPrintLayouts(ByVal layoutType As DataSourceList)
            Select Case layoutType
                Case DataSourceList.Addressbook : ResetDefaultLayoutAdressbook()
                Case DataSourceList.Articles : ResetDefaultLayoutArticles()
                Case DataSourceList.BillOfMaterial : ResetDefaultLayoutBillOfMaterial()
                Case DataSourceList.BusinessLayouts
                Case DataSourceList.CashJournalMonthy : ResetDefaultLayoutCashJournalMonthly()
                Case DataSourceList.CashJournalYearly : ResetDefaultLayoutCashJournalYearly()
                Case DataSourceList.Journal ' Das Journal selber
                Case DataSourceList.Journaldocument
                    ResetDefaultLayoutJournalDocument()
                    ResetDefaultLayoutArticleSummary()
                Case DataSourceList.Transactions : ResetDefaultLayoutTransactions()
                Case DataSourceList.Letters : ResetDefaultLayoutLetters()
                Case DataSourceList.Reminders : ResetDefaultLayoutReminders()
            End Select

        End Sub



        ''' <summary>
        ''' Ruft das standardLayout für Adressebuch ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutAdressbook() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)

            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard__Adressbuch)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard__Adressbuch)

            newRep.IsDefault = True
            newRep.Save()
            Return newRep

        End Function

        ''' <summary>
        ''' Ruft das Standard-Layout für artikellisten ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutArticles() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)

            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Artikellisten)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Artikellisten)

            newRep.IsDefault = True
            newRep.Save()
            Return newRep

        End Function

        ''' <summary>
        ''' Ruft die stückliste  (Aus Artikelliste) ab.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutBillOfMaterial() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)

            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Artikellisten)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Artikellisten)

            newRep.IsDefault = True
            newRep.Save()
            Return newRep

        End Function

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutCashJournalMonthly() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)

            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_CashJournalMonthly)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_CashJournalMonthly)

            newRep.IsDefault = True
            newRep.Save()
            Return newRep

        End Function

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutCashJournalYearly() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)

            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_CashJournalYearly)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_CashJournalYearly)

            newRep.IsDefault = True
            newRep.Save()
            Return newRep

        End Function

        ''' <summary>
        ''' Ruft das standard Journaldokument ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutJournalDocument() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)


            ' Standard Druck-Layout
            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Invoices)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Invoices)

            newRep.IsDefault = True
            newRep.Save()
            Return newRep

        End Function

        ''' <summary>
        ''' Stellt das Layout für Artikelaufstellungen wieder her. (kein Standard-Layout, da optional wählbar)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutArticleSummary() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)


            ' Standard Druck-Layout
            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Materialaufstellung)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Materialaufstellung)

            newRep.IsDefault = False
            newRep.Save()
            Return newRep

        End Function

        ''' <summary>
        ''' Ruft das Standardlayout für Forderungen/Verbindlichkeiten ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutTransactions() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)


            ' Standard Druck-Layout
            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Materialaufstellung)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Materialaufstellung)

            newRep.IsDefault = True
            newRep.Save()
            Return newRep

        End Function


        ''' <summary>
        ''' Ruft das Standardlayout fürBriefe ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutLetters() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)


            ' Standard Druck-Layout
            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Letters)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Letters)

            newRep.IsDefault = True
            newRep.Save()
            Return newRep

        End Function

        ''' <summary>
        ''' Ruft das Standardlayout fürBriefe ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)>
        Friend Shared Function ResetDefaultLayoutReminders() As Kernel.Printing.Report
            Dim reps As New Kernel.Printing.Reports(MainApplication.getInstance)


            ' Standard Druck-Layout
            Dim dummy As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Reminders)

            Dim rep As Kernel.Printing.Report = reps.GetFromDB(dummy.Key)  ' Falls es diesen schon gibt => Löschen 
            If rep IsNot Nothing Then
                rep.Delete()
            End If

            Dim newRep As Kernel.Printing.Report = Kernel.Printing.Report.LoadFromStream(My.Resources.Standard_Reminders)
            newRep.DataSourceKind = DataSourceList.Reminders
            newRep.IsDefault = True
            newRep.Save()
            Return newRep

        End Function

    End Class

    ''' <summary>
    ''' Stellt Optionen bereit, um den Ausdruck von Journaldokumenten zu steuern
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DocumentPrintingOptions

        Private m_PrintDescription As Boolean = True
        Private m_printBusinessLayout As Boolean = True
        Private m_pagecopies As Short = 1

        Private m_printBusinesLayoutOnEveryPage As Boolean

        ''' <summary>
        ''' Legt fest, ob das Briefpapier-Layout auf jeder Seite gedruckt werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PrintBusinesHeaderOnEveryPage() As Boolean
            Get
                Return m_printBusinesLayoutOnEveryPage
            End Get
            Set(ByVal value As Boolean)
                m_printBusinesLayoutOnEveryPage = value
            End Set
        End Property

        ''' <summary>
        ''' Legt die anzahl der Seitenkopien fest oder ruft dies ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PageCopies() As Short
            Get
                Return m_pagecopies
            End Get
            Set(ByVal value As Short)
                m_pagecopies = value
            End Set
        End Property

        ''' <summary>
        ''' Druckt das Dokument mit dem Briefpapiert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WithBusinesslayout() As Boolean
            Get
                Return m_printBusinessLayout
            End Get
            Set(ByVal value As Boolean)
                m_printBusinessLayout = value
            End Set
        End Property

        ''' <summary>
        ''' Erzeigt einen Ausdruck mit dem Langtext unter den Artikeltexten
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WithDescription() As Boolean
            Get
                Return m_PrintDescription
            End Get
            Set(ByVal value As Boolean)
                m_PrintDescription = value
            End Set
        End Property

    End Class

End Namespace