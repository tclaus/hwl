Namespace Kernel
    ''' <summary>
    ''' Stellt ein Zeitbereich einer Auflistung von Kassenbucheinträgen dar
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()>
    Public Class CashJournalTimeFrame

        Dim m_startDate As Date
        Dim m_endDate As Date
        Dim m_cashJournalItems As CashJournalItems

        Public Function GetCashJournalTimeFrame(ByVal startDate As System.DateTime, ByVal endDate As System.DateTime) As CashJournalTimeFrame
            Dim newCashTimeFrame As New CashJournalTimeFrame()
            newCashTimeFrame.SetTimeInterval(startDate, endDate)

            Return newCashTimeFrame

        End Function

        Public Function GetCashJournalTimeFrame() As CashJournalTimeFrame
            Dim newCashTimeFrame As New CashJournalTimeFrame()
            newCashTimeFrame.SetTimeInterval(Date.MinValue, Date.MaxValue)
            Return newCashTimeFrame

        End Function

        ''' <summary>
        ''' Ruft das Endedatum (inklusiv) ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property EndDate As Date
            Get
                Return m_endDate
            End Get

        End Property
        ''' <summary>
        ''' Ruft das anfangsdatum des Bereiches ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property StartDate As Date
            Get
                Return m_startDate
            End Get

        End Property

        ReadOnly Property TaxValueList As List(Of TaxValuePair)
            Get
                Return m_cashJournalItems.TotalTaxes
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Betrag ab, der nach diesem Zeitraum in der Kasse war
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TotalCashAfterThis As Decimal
            Get
                Return m_cashJournalItems.GetCashAfterThis
            End Get
        End Property

        ''' <summary>
        ''' Ruft die Auflistung der Kassenbucheinträge ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property CashJournal As CashJournalItems
            Get
                Return m_cashJournalItems
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Betrag ab, der VOR diesem Zeitraum in der Kasse enthalten war
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TotalCashBeforeThis As Decimal
            Get
                Return m_cashJournalItems.GetCashBeforeThis
            End Get
        End Property

        ''' <summary>
        ''' Erstellt den Datensatz mit den Start-und Endzeiten
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CreateData()
            m_cashJournalItems = CType(MainApplication.getInstance.CashJournal.GetNewCollection, CashJournalItems)
            If Me.StartDate > Date.MinValue Then
                m_cashJournalItems.StartDate = Me.StartDate
                m_cashJournalItems.EndDate = Me.EndDate
            End If

            m_cashJournalItems.SetDateCriteria()
        End Sub


        ''' <summary>
        ''' Setzt das Zeitinterval für die Kassenbucheinträge dieses Zeitraumes
        ''' </summary>
        ''' <param name="startdate"></param>
        ''' <param name="enddate"></param>
        ''' <remarks></remarks>
        Friend Sub SetTimeInterval(ByVal startdate As Date, ByVal enddate As Date)
            m_startDate = startdate
            m_endDate = enddate
            CreateData()
        End Sub
    End Class

End Namespace