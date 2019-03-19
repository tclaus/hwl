Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports ClausSoftware.Data


Namespace Kernel.AboItems


    ''' <summary>
    ''' Stellt eine Auflistung von aktuell angemeldeten HWL - Instanzen bereit
    ''' </summary>
    ''' <remarks>In der DAtenbank wird ein entsprechendes Feld mit den Namen der angemeldeten Instanzen gepflegt</remarks>
    <Persistent("AboItems")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class AboItem
        Inherits StaticItem
        Implements IDataItem

        Private Shared YearsEnd As New Date(Today.Year, 12, 31) ' Jahesende feststellen

        Private m_itemID As String

        Private m_RecurrenceXML As String

        ''' <summary>
        ''' Enthält das aktuelle wiederholungsmuster
        ''' </summary>
        ''' <remarks></remarks>
        Private m_recInfo As DevExpress.XtraScheduler.RecurrenceInfo

        ''' <summary>
        ''' Ruft das letzte ereignis ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastEvent() As Date
            Get

                Return Today
            End Get

        End Property
        Private m_recCalk As DevExpress.XtraScheduler.OccurrenceCalculator

        ''' <summary>
        ''' Ruft das nächste Ereignis ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property NextEvent() As Date
            Get
                If m_recCalk Is Nothing Then
                    m_recCalk = DevExpress.XtraScheduler.OccurrenceCalculator.CreateInstance(Me.Recurrence)
                End If


                Dim myApp As New DevExpress.XtraScheduler.Appointment(DevExpress.XtraScheduler.AppointmentType.Pattern, Today, YearsEnd)


                ' Ruft den nächsten Termin ab 
                Return m_recCalk.FindNextOccurrenceTimeAfter(Today, myApp)
            End Get

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
                    m_recInfo = New DevExpress.XtraScheduler.RecurrenceInfo

                Else
                    If m_recInfo Is Nothing Then
                        m_recInfo = Settings.xml_deserialize(Of DevExpress.XtraScheduler.RecurrenceInfo)(Me.RecurrenceXML)
                    End If

                End If

                Return m_recInfo
            End Get
            Set(ByVal value As DevExpress.XtraScheduler.RecurrenceInfo)

                Me.RecurrenceXML = Settings.xml_Serialize(value)
                m_recInfo = Nothing
                m_recCalk = Nothing

            End Set
        End Property


        ''' <summary>
        ''' XML-Definition des Wiederholungsintervals
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Recurrence")> _
        <Size(SizeAttribute.Unlimited)> _
        Private Property RecurrenceXML() As String
            Get
                Return m_RecurrenceXML
            End Get
            Set(ByVal value As String)
                m_RecurrenceXML = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen Verweis auf die ID des Elemnetes aus der Ursprungsrechmung ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("OrgItemID")> _
        <Size(32)> _
        Public Property OrgItemID() As String
            Get
                Return m_itemID
            End Get
            Set(ByVal value As String)
                m_itemID = value
            End Set
        End Property





        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace