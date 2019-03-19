Option Explicit On
Option Strict On

Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Stellt verknüpfungen sowie Metadaten zu den Artikelgruppen bereit.
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("Fixkosten")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class FixedCost
        Inherits StaticItem
        Implements IDataItem        

        Public Const TableName As String = "Fixkosten"

        Private m_oc As DevExpress.XtraScheduler.OccurrenceCalculator
        Private Shared YearsEnd As New Date(Today.Year, 12, 31) ' Jahesende feststellen

        Private m_Subject As String

        Private m_Sum As Decimal
        Private m_Period As Integer
        Private m_Interval As Integer
        Private m_nextschedule As Date
        Private m_Remider As Boolean
        Private m_AutoUpdate As Boolean
        Private m_LastDate As Date

        Private m_catID As Integer

        Private m_tmpText As String

        ''' <summary>
        ''' stellt einen Cache bereit, der die langsame Berechnung der noch offenen Kosten bis Jahresende enthält
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared m_costCache As New Dictionary(Of String, DevExpress.XtraScheduler.AppointmentBaseCollection)


        Private m_recurrence As String

        ''' <summary>
        ''' Ruft alle Kosten bis zum Jahresende ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("CostToYearsEnd", "Summe Jahresende")> _
        Public ReadOnly Property CostToYearsEnd() As Decimal
            Get
                Return GetCost(YearsEnd)
            End Get
        End Property

        ''' <summary>
        ''' Ruft die Gesamtkosten ab, die sich in diesem Jahr insgesamt ergeben
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("TotalCostPerYear", "Gesamtkosten Jahr")> _
        Public ReadOnly Property CostPerYear() As Decimal
            Get
                Dim startdate As New Date(Today.Year, 1, 1) ' Jahresanfang feststellen
                Dim endDate As Date = YearsEnd

                Return GetCost(startdate, endDate)
            End Get
        End Property

        ''' <summary>
        ''' Ruft die fälligen Kosten ab, die ab Heute bis zum Enddatum auflaufen
        ''' </summary>
        ''' <param name="endDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCost(ByVal endDate As Date) As Decimal
            Dim startdate As Date = Date.Today
            Return GetCost(startdate, endDate)
        End Function



        ''' <summary>
        ''' Ruft die noch fälligen Gesamtkosten vom Startdatum bis zu diesem Stichtag ab
        ''' </summary>
        ''' <param name="endDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCost(ByVal startdate As Date, ByVal endDate As Date) As Decimal

            Dim list As DevExpress.XtraScheduler.AppointmentBaseCollection
            Me.Recurrence.End = YearsEnd

            Dim myApp As New DevExpress.XtraScheduler.Appointment(DevExpress.XtraScheduler.AppointmentType.Pattern, startdate, endDate)

            If m_oc Is Nothing Then
                m_oc = DevExpress.XtraScheduler.OccurrenceCalculator.CreateInstance(Me.Recurrence)
            End If

            If Not m_costCache.ContainsKey(Me.RecurrenceXML) Then
                ' Das erstellen der Liste dauer Zeit, daher zwischenspeichern. 
                'LATER: Das Erstellen der Liste der zukünftigen Ereignisse sollten schneller gehen 
                list = m_oc.CalcOccurrences(New DevExpress.XtraScheduler.TimeInterval(startdate, endDate), myApp)
                m_costCache.Add(Me.RecurrenceXML, list)
                Debug.Print(" .. Cache miss!")
            Else
                list = m_costCache(Me.RecurrenceXML)
                ' Debug.Print(" .. Cache hit !")  ' Keine Meldung, da de Cache-Fall der schnellste Fall ist; ein Debug macht es nur langsamer

            End If

            Dim totalCost As Decimal


            For Each item As DevExpress.XtraScheduler.Appointment In list
                If item.Start >= startdate Then
                    totalCost += Me.PeriodicalCost
                End If

            Next

            Return totalCost
        End Function

        ''' <summary>
        ''' Ruft einen XML-Stream ab, der die Wiederholung als Dev-Express Objekt enthält
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <Persistent("Recurrence")> _
        Private Property RecurrenceXML() As String
            Get
                Return m_recurrence
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RecurrenceXML", m_recurrence, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft das komplexe wiederholungsmuster ab oder legt dieses fest. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Löst die bisherige Periode und Interval ab</remarks>
        Property Recurrence() As DevExpress.XtraScheduler.RecurrenceInfo
            Get
                If String.IsNullOrEmpty(Me.RecurrenceXML) Then
                    Dim res As DevExpress.XtraScheduler.RecurrenceInfo
                    res = GetRecByOldValues()
                    ' Dann aus den alten Werten umwandeln

                    Me.RecurrenceXML = Settings.xml_Serialize(res)
                    Return res

                Else
                    Return Settings.xml_deserialize(Of DevExpress.XtraScheduler.RecurrenceInfo)(Me.RecurrenceXML)

                End If
            End Get
            Set(ByVal value As DevExpress.XtraScheduler.RecurrenceInfo)

                Me.RecurrenceXML = Settings.xml_Serialize(value)
                m_oc = Nothing

            End Set
        End Property

        ''' <summary>
        ''' Ruft die alten HWL-1 Werte ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetRecByOldValues() As DevExpress.XtraScheduler.RecurrenceInfo
            Dim rec As New DevExpress.XtraScheduler.RecurrenceInfo

            Select Case Me.Period
                Case 1 : rec.DayNumber = Me.Interval
                    rec.Type = DevExpress.XtraScheduler.RecurrenceType.Daily
                    rec.Periodicity = Me.Interval

                Case 2 : rec.WeekOfMonth = CType(Me.Interval, DevExpress.XtraScheduler.WeekOfMonth)
                    rec.Type = DevExpress.XtraScheduler.RecurrenceType.Weekly
                    rec.Periodicity = Me.Interval

                Case 3 : rec.Month = Me.Interval
                    rec.Type = DevExpress.XtraScheduler.RecurrenceType.Monthly
                    rec.Periodicity = Me.Interval

                Case 4 ' Quartal, neu berechnen, das sind alle 3 Monate
                    rec.Periodicity = Me.Interval * 3
                    rec.Type = DevExpress.XtraScheduler.RecurrenceType.Monthly

                Case 5
                    rec.Type = DevExpress.XtraScheduler.RecurrenceType.Yearly


            End Select


            Return rec

        End Function

        ''' <summary>
        ''' Stellt einen freien Text bereit, in der als Klartext die Periode dargestellt wird.
        ''' (Jeden n-ten Monat) ..
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nicht mehr benötigt. wird in Echtzeit berechnet.")> _
        <Persistent("TempText")> _
        Public Property TempText() As String
            Get
                Return m_tmpText
            End Get
            Set(ByVal value As String)
                m_tmpText = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Fixkostengruppe ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("FixedCostGroup", "Gruppe")> _
        Public Property Group() As FixedCostGroup
            Get

                Return MainApplication.FixedCostGroups.GetItem(Me.CategoryID)
            End Get
            Set(ByVal value As FixedCostGroup)
                If value IsNot Nothing Then
                    CategoryID = value.ID
                Else
                    CategoryID = -1
                End If
            End Set
        End Property
        ''' <summary>
        ''' Enthält die ID der verwendeten Kategorie
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("KategorieID")> _
        Private Property CategoryID() As Integer
            Get
                Return m_catID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CategoryID", m_catID, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den letzten Termin ab an dem dieser Eintrag  noch gülig ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("LastDate", "Letzter Termin")> _
        <Persistent("letzterTermin")> _
        Public Property LastDate() As Date
            Get
                Return m_LastDate
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("LastDate", m_LastDate, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an ob der Eintrag sich selber stets aktualisiert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nicht mehr benötigt")> _
        <Persistent("Autoupdate")> _
        Public Property AutoUpdate() As Boolean
            Get
                Return m_AutoUpdate
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("AutoUpdate", m_AutoUpdate, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an ob dieser Termin einen Reminder auslöst oder legt dies fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("ReminderActive", "Aktiv")> _
        <Persistent("Erinnern")> _
        Public Property ReminderActive() As Boolean
            Get
                'TODO: Diese Termine im Terminkalender eintragen ? 
                Return m_Remider
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("ReminderActive", m_Remider, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Datum des nächsten termins ab oder legt dies fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nächste Termin wird aus der Wiederholung berechnet. DB-Abfrage nicht mehr benötigt")> _
        <Persistent("NächsterTermin")> _
        Private Property NextScheduleOLD() As Date
            Get
                Return m_nextschedule
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("NextSchedule", m_nextschedule, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den nächsten Zahlungstermin ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("NextscheduledDate", "Nächster Zahlungstermin")> _
        Public ReadOnly Property NextSchedule() As Date
            Get
                If m_oc Is Nothing Then
                    m_oc = DevExpress.XtraScheduler.OccurrenceCalculator.CreateInstance(Me.Recurrence)
                End If


                Dim myApp As New DevExpress.XtraScheduler.Appointment(DevExpress.XtraScheduler.AppointmentType.Pattern, Today, YearsEnd)


                ' Ruft den nächsten Termin ab 
                Return m_oc.FindNextOccurrenceTimeAfter(Today, myApp)

            End Get
        End Property

        ''' <summary>
        ''' Ruft die Häufigkeit ab oder legt diese fest. 1 Heisst jeder Tag/Monat/, 2 Heisst jeder 2. Tag/Monat, usw
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nun durch das Recurrence-Objekt")> _
        <PersistentAttribute("Interval")> _
        Public Property Interval() As Integer
            Get
                Return m_Interval
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Interval", m_Interval, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft die Text-Bezechnung ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("IntervalText", "Wiederholung")> _
        Public ReadOnly Property IntervalText() As String
            Get
                Return GetPeriodText()
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Text ab, der durch das Interval angegeben ist
        ''' </summary>        
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPeriodText() As String
            Dim tmp As String = ""
            Dim PeriodName As String = ""
            Select Case Me.Recurrence.Type

                Case DevExpress.XtraScheduler.RecurrenceType.Daily : PeriodName = m_mainApplication.Languages.GetText("Day", "Tag")
                Case DevExpress.XtraScheduler.RecurrenceType.Weekly : PeriodName = m_mainApplication.Languages.GetText("Week", "Woche")
                Case DevExpress.XtraScheduler.RecurrenceType.Monthly : PeriodName = m_mainApplication.Languages.GetText("Month", "Monat")
                Case DevExpress.XtraScheduler.RecurrenceType.Yearly : PeriodName = m_mainApplication.Languages.GetText("Year", "Jahr")

            End Select
            If Me.Recurrence.Periodicity > 1 Then
                tmp = m_mainApplication.Languages.GetText("EveryNPeriodName", "Jeden {0}. {1}", Me.Recurrence.Periodicity, PeriodName)
            Else
                Select Case Me.Recurrence.Type
                    Case DevExpress.XtraScheduler.RecurrenceType.Daily : tmp = m_mainApplication.Languages.GetText("EveryDay", "Jeden Tag")
                    Case DevExpress.XtraScheduler.RecurrenceType.Weekly : tmp = m_mainApplication.Languages.GetText("EveryWeek", "Jede Woche")
                    Case DevExpress.XtraScheduler.RecurrenceType.Monthly : tmp = m_mainApplication.Languages.GetText("EveryMonth", "Jeden Monat")
                    Case DevExpress.XtraScheduler.RecurrenceType.Yearly : tmp = m_mainApplication.Languages.GetText("EveryYear", "Jedes Jahr")
                End Select

            End If

            Return tmp
        End Function

        ''' <summary>
        ''' Ruft einen Schlüssel ab der die Wiederholrate angiebt oder legt diesen fest.
        ''' 1=Tag, 2=Woche, 3=Monat, 4=Quartal, 4=Jahr
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Obsolete("Nun durch das reccurence-Objekt erledigt")> _
        <Persistent("Periodität")> _
        Public Property Period() As Integer
            Get
                Return m_Period
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Period", m_Period, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Betrag der Fixkostenstelle ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("PeriodicalCost", "Regelmässige Kosten")> _
        <Persistent("Summe")> _
        Public Property PeriodicalCost() As Decimal
            Get
                Return m_Sum
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PeriodicalCost", m_Sum, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Text der Fixkostenstelle ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("FixedCostSubject", "Bezeichnung")> _
        <Persistent("Betreff")> _
        Public Property Subject() As String
            Get
                Return m_Subject
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("Subject", m_Subject, value)
            End Set
        End Property


        Public Sub New(ByVal session As Session)
            MyBase.New(session)


        End Sub

    End Class
End Namespace