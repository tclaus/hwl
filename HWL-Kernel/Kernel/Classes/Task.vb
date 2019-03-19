Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Imports DevExpress.Xpo


Namespace Kernel

    ''' <summary>
    ''' Stellt eien Klasse dar, mit der Kurztexte, Termine und Aufgaben geschrieben werden können
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("Report")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Task
        Inherits StaticItem
        Implements IDataItem

        Private m_Generated As Boolean

        Private m_edited As Boolean

        Private m_Date As DateTime
        Private m_Message As String
        Private m_sourceDB As String

        Private m_expirationDate As DateTime

        Private m_Comment As String

        ''' <summary>
        ''' Zeigt einen Kommentar zu der Meldung an, oder legt diesen fest.
        ''' Ein Kommentar entspricht einem längerem, beschreibenden Text.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <Tools.DisplayName("TaskMessage", "Notiz")> _
        <Persistent("Kommentar")> _
        Public Property Message() As String
            Get
                Return m_Comment
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Message", m_Comment, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt das Fälligkeitsdatum an, oder legt dieses fest. 
        ''' Überfällige Meldungen werden dem Benutzer wiederholt angezeigt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("TaskExpiration", "Fällig am")> _
        <Persistent("Fälligkeit")> _
        Public Property Expiration() As DateTime
            Get
                Return m_expirationDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of Date)("Expiration", m_expirationDate, value)

            End Set
        End Property

        ''' <summary>
        ''' Zeigt bei Systemerzeugten Meldungen die quell-Tabelle die diese Meldung erzeugt hat, an oder legt diese fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("BezugTabelle")> _
        Public Property SourceTable() As String
            Get
                Return m_sourceDB
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SourceTable", m_sourceDB, value)
            End Set
        End Property

        ''' <summary>
        ''' Enthält die Meldung des Eintrages in Kurzform.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("Tasksubject", "Betreff")> _
        <Persistent("Meldung")> _
        Public Property Subject() As String
            Get
                Return m_Message
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Subject", m_Message, value)
            End Set
        End Property


        ''' <summary>
        ''' Zeigt das Erstellungsdatum an oder legt dies fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>     
        ''' <remarks></remarks>
        <Tools.DisplayName("TaskCreatedAt", "Erstellt am")> _
        <Persistent("Datum")> _
        Public Property CreateDate() As DateTime
            Get
                Return m_Date
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of Date)("CreateDate", m_Date, value)
            End Set
        End Property

        <Tools.DisplayName("TaskClosed", "Erledigt")> _
        <Persistent("Bearbeitet")> _
        Public Property TaskFinished() As Boolean
            Get
                Return m_edited
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("TaskFinished", m_edited, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, das der Eintrag Systemerzeugt wurde, oder legt dies fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("SystemGenerated", "System erzeugt")> _
        <Persistent("Computergeneriert")> _
        Public Property Generated() As Boolean
            Get
                Return m_Generated
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("Generated", m_Generated, value)

            End Set
        End Property

        Public Overrides Function ToString() As String
            If Me.Expiration > Date.MinValue Then
                Return Me.Subject & " (" & Me.Expiration & ")"
            Else
                Return Me.Subject

            End If


        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace
