Option Explicit On
Option Strict On


Imports DevExpress.Xpo
Imports ClausSoftware.Data
Imports System.IO
Imports System.Drawing

Namespace Kernel

    <Persistent(Appointment.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Appointment
        Inherits StaticItem
        Implements IDataItem

        Friend Const Tablename As String = "Appointments"


        Dim fType As Integer
        Dim fStartDate As DateTime
        Dim fEndDate As DateTime
        Dim fLastModification As DateTime


        Dim fAllDay As Byte
        Dim fSubject As String
        Dim fLocation As String
        Dim fDescription As String
        Dim fStatus As Integer
        Dim fLabel As UInteger
        Dim fResourceID As UInteger
        Dim fRecurrenceInfo As String
        Dim fReminderInfo As String
        Dim fCustomField1 As String
        Dim fEntryID As String

        Private m_recInfo As RecurrenceInfo

        Public ReadOnly Property RecurrenceInfoData As RecurrenceInfo
            Get
                If m_recInfo Is Nothing Then
                    m_recInfo = New RecurrenceInfo(Me.RecurrenceInfo)
                End If
                Return m_recInfo
            End Get
        End Property



        <Persistent("Type")> _
        Public Property Type() As Integer
            Get
                Return fType
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Type", fType, value)
            End Set
        End Property

        <Indexed()> _
        <Persistent("StartDate")> _
        Public Property StartDate() As DateTime
            Get
                Return fStartDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("StartDate", fStartDate, value)
            End Set
        End Property

        <Persistent("EndDate")> _
        Public Property EndDate() As DateTime
            Get
                Return fEndDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EndDate", fEndDate, value)
            End Set
        End Property

        <Persistent("AllDay")> _
        Public Property AllDay() As Byte
            Get
                Return fAllDay
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("AllDay", fAllDay, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruftz eine Beschriftung ab oder legt eine fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <Persistent("Subject")> _
        Public Property Subject() As String
            Get
                Return fSubject
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Subject", fSubject, value)
            End Set
        End Property

        <Persistent("Location")> _
        <Size(255)> _
        Public Property Location() As String
            Get
                Return fLocation
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Location", fLocation, value)
            End Set
        End Property

        <Persistent("Description")> _
        <Size(SizeAttribute.Unlimited)> _
        Public Property Description() As String
            Get
                Return fDescription
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", fDescription, value)
            End Set
        End Property

        <Persistent("Status")> _
        Public Property Status() As Integer
            Get
                Return fStatus
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Status", fStatus, value)
            End Set
        End Property

        <Persistent("Label")> _
        Public Property Label() As UInteger
            Get
                Return fLabel
            End Get
            Set(ByVal value As UInteger)
                SetPropertyValue(Of UInteger)("Label", fLabel, value)
            End Set
        End Property

        <Persistent("ResourceID")> _
        Public Property ResourceID() As UInteger
            Get
                Return fResourceID
            End Get
            Set(ByVal value As UInteger)
                SetPropertyValue(Of UInteger)("ResourceID", fResourceID, value)
            End Set
        End Property


        ''' <summary>
        ''' ruft eine eindeutige ID ab, mit der der Datensatz mit Outlook synchronisiert werden kann
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <Size(75)> _
        <Persistent("OutlookEntryID")> _
        Public Property OutlookEntryID() As String
            Get
                Return fEntryID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("OutlookEntryID", fEntryID, value)

            End Set
        End Property

        <Persistent("RecurrenceInfo")> _
        <Size(SizeAttribute.Unlimited)> _
        Public Property RecurrenceInfo() As String
            Get
                Return fRecurrenceInfo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RecurrenceInfo", fRecurrenceInfo, value)

                ' Erzwingt ein neuschreiben der Seriendaten
                m_recInfo = Nothing
            End Set
        End Property



        ''' <summary>
        ''' Stellt ein XML - Objekt bereit, das eine erinnerung darstellt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ReminderInfo")> _
        <Size(SizeAttribute.Unlimited)> _
        Public Property ReminderInfo() As String
            Get
                Return fReminderInfo
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReminderInfo", fReminderInfo, value)
            End Set
        End Property

        <Persistent("CustomField1")> _
        <Size(SizeAttribute.Unlimited)> _
        Public Property CustomField1() As String
            Get
                Return fCustomField1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CustomField1", fCustomField1, value)
            End Set
        End Property

        <Persistent("LastModificationTime")> _
        Public Property LastModificationTime() As DateTime
            Get
                Return fLastModification
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LastModificationTime", fLastModification, value)

            End Set
        End Property


        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
        ''' <summary>
        ''' Ruft einen Anzeigetext dieses Termins ab 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String

            If Me.StartDate.Date = Today.Date Then
                Return MainApplication.Languages.GetText("today", "Heute") & ": " & Me.StartDate.ToString("t") & " " & Me.Subject
            End If

            If Me.StartDate.Date = Today.Date.AddDays(1) Then ' morgen
                Return MainApplication.Languages.GetText("tomorrow", "Morgen") & ": " & Me.StartDate.ToString("t") & " " & Me.Subject
            End If

            Return Me.StartDate & " " & Me.Subject
        End Function

        Private Sub Appointment_Changed(ByVal sender As Object, ByVal e As DevExpress.Xpo.ObjectChangeEventArgs) Handles Me.Changed
            If Me.IsLoading Then Exit Sub
            If e.Reason = ObjectChangeReason.Reset Then Exit Sub
            If String.IsNullOrEmpty(e.PropertyName) Then Exit Sub
            If e.PropertyName = "LastModificationTime" Then Exit Sub

            Me.LastModificationTime = Date.Now
        End Sub

    End Class


    ''' <summary>
    ''' Stellt eine Nur-Lese-eigenschaft bereit für die Darstellung von Serien
    ''' </summary>
    ''' <remarks></remarks>
    Public Class RecurrenceInfo
        Dim recurrence As New DevExpress.XtraScheduler.RecurrenceInfo()

        Private m_isRecurrence As Boolean
        Private m_startTime As TimeSpan
        Private m_endTime As TimeSpan
        Private m_duration As TimeSpan
        Private m_occurenceCount As Integer
        Private m_month As Integer
        Private m_seriesendDate As Date
        Private m_seriesStartDate As Date
        Private m_dayNumber As Integer
        Private m_guid As String
        Private m_recurrenceType As recurrenceType
        Private m_WeekDays As WeekDaysenum
        Private m_weekOfMonth As weekOfMonthEnum
        Private m_range As RecurrenceRange
        Private m_RecurrenceXMLString As String

        Property RecurrenceXMLString As String
            Get
                Return m_RecurrenceXMLString
            End Get
            Set(value As String)
                m_RecurrenceXMLString = value
            End Set
        End Property


        ''' <summary>
        ''' Zeigt an, das dieser Termin wiederkehrend ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property IsRecurrence As Boolean
            Get
                Return m_isRecurrence
            End Get
            Set(value As Boolean)
                m_isRecurrence = value
            End Set
        End Property

        Property StartTime As TimeSpan
            Get
                Return m_startTime
            End Get
            Set(value As TimeSpan)
                m_startTime = value
            End Set
        End Property

        Property EndTime As TimeSpan
            Get
                Return m_endTime
            End Get
            Set(value As TimeSpan)
                m_endTime = value
            End Set
        End Property
        Property Duration As TimeSpan
            Get
                Return m_duration
            End Get
            Set(value As TimeSpan)
                m_duration = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Anzahl der Wiederholungen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property OccurrenceCount As Integer
            Get
                Return m_occurenceCount
            End Get
            Set(value As Integer)
                m_occurenceCount = value
            End Set
        End Property
        ''' <summary>
        ''' Ruft den Monat ab an dem diese Serie stattfindet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Month As Integer
            Get
                Return m_month
            End Get
            Set(value As Integer)
                m_month = value

            End Set
        End Property

        ''' <summary>
        ''' Datum an dem diese Serie endet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property SeriesEndesDate As Date
            Get
                Return m_seriesendDate
            End Get
            Set(value As Date)
                m_seriesendDate = value
            End Set
        End Property

        Property SeriesStartDate As Date
            Get
                Return m_seriesStartDate
            End Get
            Set(value As Date)
                m_seriesStartDate = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the Day number within a Mounth
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property DayNumber As Integer
            Get
                Return m_dayNumber
            End Get
            Set(value As Integer)
                m_dayNumber = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die eindeutige Kennung dieser Serie ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Guid As String
            Get
                Return m_guid
            End Get
            Set(value As String)
                m_guid = value
            End Set
        End Property

        Property Periodicity As recurrenceType
            Get
                Return m_recurrenceType
            End Get
            Set(value As recurrenceType)
                m_recurrenceType = value
            End Set
        End Property

        Property WeekDays As WeekDaysenum
            Get
                Return m_WeekDays
            End Get
            Set(value As WeekDaysenum)
                m_WeekDays = value
            End Set
        End Property

        Property WeekOfMonth As weekOfMonthEnum
            Get
                Return m_weekOfMonth
            End Get
            Set(value As weekOfMonthEnum)
                m_weekOfMonth = value
            End Set
        End Property

        ''' <summary>
        ''' Gibt die Kennung an, wonach sich die Dauer der Serie richtet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Range As RecurrenceRange
            Get
                Return m_range
            End Get
            Set(value As RecurrenceRange)
                m_range = value
            End Set
        End Property

        ''' <summary>
        ''' Setzt die Properties
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetDates()
            recurrence.FromXml(Me.RecurrenceXMLString)
            IsRecurrence = True

            DayNumber = recurrence.DayNumber
            Duration = recurrence.Duration

            SeriesEndesDate = recurrence.End
            SeriesStartDate = recurrence.Start

            Guid = recurrence.Id.ToString
            Month = recurrence.Month
            OccurrenceCount = recurrence.OccurrenceCount
            Periodicity = CType(recurrence.Periodicity, recurrenceType)

            Range = CType(recurrence.Range, RecurrenceRange)

            WeekDays = CType(recurrence.WeekDays, WeekDaysenum)
            WeekOfMonth = CType(recurrence.WeekOfMonth, weekOfMonthEnum)

        End Sub

        Public Sub New(xmlData As String)
            Me.RecurrenceXMLString = xmlData
            SetDates()
        End Sub

    End Class

    Public Enum recurrenceType
        [none] = -1
        Minutely = 4
        Hourly = 5
        Daily = 0
        Weekly = 1
        Monthly = 2
        Yearly = 3
    End Enum


    Public Enum weekOfMonthEnum
        First = 1
        Fourth = 4
        Last = 5
        None = 0
        Second = 2
        Third = 3

    End Enum

    Public Enum WeekDaysenum
        EveryDay = 127
        Friday = 32
        Monday = 2
        Saturday = 64
        Sunday = 1
        Thursday = 16
        Tuesday = 4
        wednesday = 8
        WeekendDays = 65
        WorkDays = 62

    End Enum

    Public Enum RecurrenceRange
        EndByDate = 2
        NoEndDate = 0
        OccurenceCount = 1
    End Enum

End Namespace