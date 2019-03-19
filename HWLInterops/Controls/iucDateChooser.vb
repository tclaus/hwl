Imports System.Xml
Imports System.Xml.Serialization


''' <summary>
''' Stellt ein Usercontrol zur Verfügung, in dem man Datum-Bereiche eingeben kann
''' </summary>
''' <remarks></remarks>
Public Class iucDateChooser

    <Description("Wird gefeuert, wenn das eingestellte Datum durch Benutzereingaben geändert wird")> _
    Event DateChanged(ByVal sender As Object, ByVal e As DateSpanEventargs)


    ''' <summary>
    ''' Enthält einen Datumsbereich
    ''' </summary>
    ''' <remarks></remarks>
    Private timespan As New SimpleTimeSpan

    Private m_eventsBlocked As Boolean = True ' Blockieren, solange das Teil noch startet

    <Conditional("DEBUG")> _
    Private Sub DatechangedViewer() Handles Me.DateChanged
        Debug.Print("DateStart:" & timespan.StartDate & ";  DateEnd:" & timespan.EndDate)

    End Sub

    ''' <summary>
    ''' Feuert ein 'Datum-geändert' - event, sofern dieses freigeschaltet wurde
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RaiseEventDateChanged()
        If Not m_eventsBlocked Then
            Dim dateSpan As New DateSpanEventargs
            dateSpan.StartDate = Me.GetStartDate
            dateSpan.EndDate = Me.GetEndDate

            dateSpan.AllDates = timespan.ShowAll
            RaiseEvent DateChanged(Me, dateSpan)
        End If
    End Sub

    ''' <summary>
    ''' Speichert das Zeitinterval mit dem kontext in den globalen Einstellungem
    ''' </summary>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Public Sub SaveSettings(ByVal context As String)
        Dim sb As New System.Text.StringBuilder

        Dim ts As New IO.StringWriter(sb)

        Dim xml As New XmlSerializer(GetType(SimpleTimeSpan))

        xml.Serialize(ts, timespan)

        m_application.Settings.SetSetting("SimpleDateTimeInterval", context, sb.ToString())


    End Sub

    ''' <summary>
    ''' Ruft das Zeitinterval wieder ab und setzt die Oberfläche entsprechend
    ''' </summary>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Public Sub RestoreSettings(ByVal context As String)
        Dim datetimeValue As String
        datetimeValue = m_application.Settings.GetSetting("SimpleDateTimeInterval", context, "")
        If datetimeValue.Length > 0 Then
            Try
                Dim xml As New XmlSerializer(GetType(SimpleTimeSpan))

                Dim stream As New IO.StringReader(datetimeValue)


                timespan = CType(xml.Deserialize(stream), SimpleTimeSpan)

                ' Nun noch die GUI auffüllen
                m_eventsBlocked = True

                SetYear(CStr(timespan.Year))
                If timespan.FullYear Then SetFullYear()
                If timespan.ShowAll Then SetAllDates()


                SetMonth(timespan.Month)
                SetQuarter(timespan.Quarter)

                timespan.ShowAll = timespan.ShowAll

                m_eventsBlocked = False
                RaiseEventDateChanged()

            Catch ex As Exception

            Finally
                m_eventsBlocked = False
            End Try
        End If
    End Sub


    ''' <summary>
    ''' Ruft das Anfangsdatum des Intervals ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStartDate() As Date
        Return timespan.StartDate
    End Function

    ''' <summary>
    ''' Ruft das Endedatum des Interval ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetEndDate() As Date
        Return timespan.EndDate
    End Function

    ''' <summary>
    ''' Initialisiert die Arbeitsklasse
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitApplication()
        modmain.InitializeApplication()
    End Sub

    Private Sub Month_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radApril.CheckedChanged, radSep.CheckedChanged, radOkt.CheckedChanged, radNov.CheckedChanged, RadMärz.CheckedChanged, radMai.CheckedChanged, radJun.CheckedChanged, radJul.CheckedChanged, radJan.CheckedChanged, radFeburar.CheckedChanged, radDez.CheckedChanged, radAug.CheckedChanged
        ' das Tag enthält die Nummer des Monats
        If CType(sender, RadioButton).Checked Then

            cboYears.Enabled = True

            Dim number As Integer = CInt(CType(sender, Control).Tag)
            If cboYears.SelectedIndex >= 0 Then
                timespan.Year = CInt(cboYears.SelectedItem)
                timespan.Month = number

                RaiseEventDateChanged()
            End If
        End If

    End Sub

    ''' <summary>
    ''' Setzt die Liste der Jahreszahlen. 
    ''' </summary>
    ''' <param name="years">eine durch komma separierte Liste von Jahgreszahlen</param>
    ''' <remarks></remarks>
    Public Sub SetYears(ByVal years As String)

        cboYears.Properties.Items.Clear()
        For Each Year As String In years.Split(","c)
            If Not cboYears.Properties.Items.Contains(Year) Then
                cboYears.Properties.Items.Add(Year)
            End If
        Next


        If cboYears.Properties.Items.Count > 0 Then
            cboYears.SelectedIndex = 0
        End If

    End Sub

    Private m_years As String()

    Public ReadOnly Property GetYears As String()
        Get
            Return m_years
        End Get
    End Property

    ''' <summary>
    ''' Setzt die Liste der zu verwendenen Jahre
    ''' </summary>
    ''' <param name="years"></param>
    ''' <remarks></remarks>
    Public Sub SetYears(ByVal years() As String)
        m_years = years

        cboYears.Properties.Items.Clear()
        cboYears.Properties.Items.AddRange(m_years)
    End Sub
    Private Sub Quartal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radQ4.CheckedChanged, radQ3.CheckedChanged, radQ2.CheckedChanged, radQ1.CheckedChanged
        If CType(sender, RadioButton).Checked Then
            cboYears.Enabled = True
            Dim number As Integer = CInt(CType(sender, Control).Tag)

            If cboYears.SelectedIndex >= 0 Then
                timespan.Year = CInt(cboYears.SelectedItem)
                timespan.Quarter = number
                RaiseEventDateChanged()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Setzt alle Daten
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetAllDates()
        radAllDates.Checked = True
    End Sub

    ''' <summary>
    ''' Setzt das ganze Jahr
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetFullYear()
        radFullyear.Checked = True
    End Sub

    Private Sub Fullyear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radFullyear.CheckedChanged
        If radFullyear.Checked Then
            cboYears.Enabled = True
            If cboYears.SelectedIndex >= 0 Then
                timespan.Year = CInt(cboYears.SelectedItem)
                timespan.FullYear = radFullyear.Checked

                RaiseEventDateChanged()
            End If
       
        End If
    End Sub

    Private Sub cboYears_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYears.SelectedIndexChanged
        If cboYears.SelectedIndex >= 0 Then

            timespan.ShowAll = False
            timespan.Year = CInt(cboYears.SelectedItem)
            'radFullyear.Checked = True


            RaiseEventDateChanged()
        End If
    End Sub


    Public Sub SetYear(ByVal year As String)
        cboYears.SelectedItem = year
    End Sub


    Public Sub SetMonth(ByVal month As Integer)

        Select Case month
            Case 1 : radJan.Checked = True
            Case 2 : radFeburar.Checked = True
            Case 3 : RadMärz.Checked = True
            Case 4 : radApril.Checked = True
            Case 5 : radMai.Checked = True
            Case 6 : radJun.Checked = True
            Case 7 : radJul.Checked = True
            Case 8 : radAug.Checked = True
            Case 9 : radSep.Checked = True
            Case 10 : radOkt.Checked = True
            Case 11 : radNov.Checked = True
            Case 12 : radDez.Checked = True
            Case Else
                ' ? 


        End Select

    End Sub

    Public Sub SetQuarter(ByVal quarter As Integer)
        Select Case quarter
            Case 1 : radQ1.Checked = True
            Case 2 : radQ2.Checked = True
            Case 3 : radQ3.Checked = True
            Case 4 : radQ4.Checked = True
            Case Else
                ' ..
        End Select
    End Sub


    Public Function GetMonth() As Integer
        Return timespan.Month
    End Function

    Public Function GetQuarter() As Integer
        Return timespan.Quarter
    End Function

    Public Function GetYear() As Integer
        Return timespan.Year
    End Function

    Private Sub radAllDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radAllDates.CheckedChanged
        If CType(sender, RadioButton).Checked Then
            timespan.ShowAll = radAllDates.Checked
            cboYears.Enabled = False
            RaiseEventDateChanged()
        End If

    End Sub

    ''' <summary>
    ''' Enthält eine Klasse, die ein Zeitfenster darstellt
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Class SimpleTimeSpan

        Private m_year As Integer
        Private m_month As Integer
        Private m_quarter As Integer
        Private m_showAll As Boolean
        Private m_fullYear As Boolean

        ' Den Datumsbereich
        <NonSerialized()> _
        Private m_currentStartDate As New Date(2000, 1, 1)
        <NonSerialized()> _
        Private m_currentEndDate As New Date(2015, 1, 1)


        ''' <summary>
        ''' Ist True, wenn das ganze Jahr ausgewählt ist und keine weiteres Datum beachtet werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FullYear() As Boolean
            Get
                Return m_fullYear
            End Get
            Set(ByVal value As Boolean)
                m_fullYear = value

                If value Then ' Wenn ganzes Jahr, dann müssen die weiteren Details ausgeblendet werden!
                    Me.m_month = 0
                    Me.m_quarter = 0
                    Me.m_showAll = False

                    If m_year > 1990 Then
                        m_currentStartDate = New Date(m_year, 1, 1)
                        m_currentEndDate = m_currentStartDate.AddYears(1).AddDays(-1)
                    End If
                End If

            End Set
        End Property

        ''' <summary>
        ''' True, wenn keinerlei Datum berücksichtigt werden soll, sonst False
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ShowAll() As Boolean
            Get
                Return m_showAll
            End Get
            Set(ByVal value As Boolean)
                m_showAll = value
                ' Wenn kein Datum erwünscht, dann auch alle Details ausblenden
                If value Then
                    Me.m_fullYear = False
                    Me.m_month = 0
                    Me.m_quarter = 0
                    ' Me.m_year = 0

                    m_currentStartDate = Date.MinValue
                    m_currentEndDate = Date.MaxValue
                End If

            End Set
        End Property

        ''' <summary>
        ''' Ruft das Anfangsdatum ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property StartDate() As Date
            Get
                Return m_currentStartDate
            End Get
        End Property

        ''' <summary>
        ''' Ruft das Endedatum des Intervals ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property EndDate() As Date
            Get
                Return m_currentEndDate
            End Get
        End Property


        ''' <summary>
        ''' Ruft das Quartal ab oder legt es fest;- 0 steht für keine Auswahl
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Quarter() As Integer
            Get
                Return m_quarter
            End Get
            Set(ByVal value As Integer)
                If value >= 1 And value <= 4 Then
                    m_quarter = value

                    Me.m_month = 0
                    Me.m_fullYear = False
                    Me.m_showAll = False

                    If m_year > 1990 Then
                        m_currentStartDate = New Date(m_year, (value - 1) * 3 + 1, 1)
                        m_currentEndDate = m_currentStartDate.AddMonths(3).AddDays(-1)
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen Monat (1-12) ab, 0 steht für keine Auswahl
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Month() As Integer
            Get
                Return m_month
            End Get
            Set(ByVal value As Integer)
                If value >= 1 And value <= 12 Then
                    m_month = value

                    Me.m_fullYear = False
                    Me.m_quarter = 0
                    Me.m_showAll = False

                    If m_year > 1990 Then
                        m_currentStartDate = New Date(Year, value, 1)
                        m_currentEndDate = m_currentStartDate.AddMonths(1).AddDays(-1)
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Jahr als Integer ab oder kegt es fest, "0" stehzt für keine Auswahl
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Year() As Integer
            Get
                Return m_year
            End Get
            Set(ByVal value As Integer)
                If value = 0 Then value = Now.Year ' Reparieren, falls falshce Daten reinkommen


                m_year = value

                If Me.Month = 0 Or Me.Quarter = 0 Then ' dann war 'ganzes Jahr' gewählt
                    m_currentStartDate = New Date(value, 1, 1)
                    m_currentEndDate = New Date(value, 12, 31)
                Else
                    m_currentStartDate = New Date(value, m_currentStartDate.Month, m_currentStartDate.Day)
                    m_currentEndDate = New Date(value, m_currentEndDate.Month, m_currentEndDate.Day)
                End If


            End Set
        End Property

    End Class

    Private Sub iucDateChooser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        m_eventsBlocked = False ' Nach dem Laden die Ereignisse wieder zulassen

    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.


        FillMonthNames()

    End Sub

    ''' <summary>
    ''' Füllt die Monats-Radio-Knopfe mit lokaisieren Namen auf
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillMonthNames()

        Dim c As System.Globalization.CultureInfo = System.Globalization.CultureInfo.GetCultureInfo("EN")
        Dim myCulture As System.Globalization.DateTimeFormatInfo = My.Application.Culture.DateTimeFormat

        For monthNumber As Integer = 1 To 12
            Dim Name As String = myCulture.GetMonthName(monthNumber)
            Select Case monthNumber
                Case 1 : radJan.Text = Name
                Case 2 : radFeburar.Text = Name
                Case 3 : RadMärz.Text = Name
                Case 4 : radApril.Text = Name
                Case 5 : radMai.Text = Name
                Case 6 : radJun.Text = Name
                Case 7 : radJul.Text = Name
                Case 8 : radAug.Text = Name
                Case 9 : radSep.Text = Name
                Case 10 : radOkt.Text = Name
                Case 11 : radNov.Text = Name
                Case 12 : radDez.Text = Name


            End Select


        Next




    End Sub

End Class


''' <summary>
''' Stellt ein Argument dar, das ein Zeitinterval enthält
''' </summary>
''' <remarks></remarks>
Public Class DateSpanEventArgs
    Inherits EventArgs

    Private m_startDate As DateTime

    Private m_endDate As Date


    Private m_AllDates As Boolean
    ''' <summary>
    ''' Wenn True, dann wird kein Zeitraum angegeben, sondern 'alle' Daten aus dem gesamten zur Verfügung stehenden Zeitraum verwendet
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AllDates() As Boolean
        Get
            Return m_AllDates
        End Get
        Set(ByVal value As Boolean)
            m_AllDates = value
        End Set
    End Property


    ''' <summary>
    ''' Ruft das ende des Zeitfensters ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EndDate() As Date
        Get
            Return m_endDate
        End Get
        Set(ByVal value As Date)
            m_endDate = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft den Begin des Zeitfensters ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartDate() As DateTime
        Get
            Return m_startDate

        End Get
        Set(ByVal value As DateTime)
            m_startDate = value
        End Set
    End Property

End Class
