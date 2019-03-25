
''' <summary>
''' Enthält die Werte, die der Anwender in fioxkosten eingegben hat
''' </summary>
''' <remarks></remarks>
<Serializable()>
Public Class FixCostUserValues

    Private m_MonthPerYear As Decimal = 12

    Private m_daysPerMonth As Decimal = 20

    Private m_hoursPerDay As Decimal = 8

    Private m_minutesPerHour As Decimal = 60


    Private m_WorkersPerYear As Decimal = 1

    Private m_workersPerMonth As Decimal = 1

    Private m_workersPerDay As Decimal = 1

    Private m_workersPerHour As Decimal = 1

    Private m_workersPerMinute As Decimal = 1

    Public Property WorkersPerMinute() As Decimal
        Get
            Return m_workersPerMinute
        End Get
        Set(ByVal value As Decimal)
            m_workersPerMinute = value
        End Set
    End Property

    Public Property WorkersPerHour() As Decimal
        Get
            Return m_workersPerHour
        End Get
        Set(ByVal value As Decimal)
            m_workersPerHour = value
        End Set
    End Property

    Public Property WorkersPerDay() As Decimal
        Get
            Return m_workersPerDay
        End Get
        Set(ByVal value As Decimal)
            m_workersPerDay = value
        End Set
    End Property

    Public Property WorkersPerMonth() As Decimal
        Get
            Return m_workersPerMonth
        End Get
        Set(ByVal value As Decimal)
            m_workersPerMonth = value
        End Set
    End Property

    Public Property WorkersPerYear() As Decimal
        Get
            Return m_WorkersPerYear
        End Get
        Set(ByVal value As Decimal)
            m_WorkersPerYear = value
        End Set
    End Property


    Public Property MinutesPerHour() As Decimal
        Get
            Return m_minutesPerHour
        End Get
        Set(ByVal value As Decimal)
            m_minutesPerHour = value
        End Set
    End Property

    Public Property HoursPerDay() As Decimal
        Get
            Return m_hoursPerDay
        End Get
        Set(ByVal value As Decimal)
            m_hoursPerDay = value
        End Set
    End Property

    Public Property DaysPerMonth() As Decimal
        Get
            Return m_daysPerMonth
        End Get
        Set(ByVal value As Decimal)
            m_daysPerMonth = value
        End Set
    End Property

    Public Property MonthPerYear() As Decimal
        Get
            Return m_MonthPerYear
        End Get
        Set(ByVal value As Decimal)
            m_MonthPerYear = value
        End Set
    End Property

    Public Sub New()

    End Sub

End Class