Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Enthält einen Anrufeintrag, der vom Anrufsystem erkannt wurde
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(PhoneCall.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class PhoneCall
        Inherits TrackedItem
        Implements IDataItem

        Public Const Tablename As String = "PhoneCall"

        ''' <summary>
        ''' enthält einen Zustand des Anrufes
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum CallStateType
            ''' <summary>
            ''' Anruf wurde angenommen
            ''' </summary>
            ''' <remarks></remarks>
            Answered
            ''' <summary>
            ''' Anruf wurde nicht angenommen
            ''' </summary>
            ''' <remarks></remarks>
            Unanswered
        End Enum

        Private m_callingID As String

        Private m_targetCallID As String

        Private m_CallState As CallStateType


        Private m_AdressID As String

        Private m_callDate As DateTime

        Private m_callinDuration As TimeSpan
        ''' <summary>
        ''' Ruft die ZTeitdauer ab, die der Anruf gedauert hat (Zeitdauer des Klingelnlassns, bis Ende d. Anrifes) 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("CallingDuration")> _
        Public Property CallingDuration() As TimeSpan
            Get
                Return m_callinDuration
            End Get
            Set(ByVal value As TimeSpan)
                SetPropertyValue(Of TimeSpan)("CallingDuration", m_callinDuration, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Zeitpunkt des Begins des Anrifes ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("CallingDate")> _
        Public Property CallingDate() As DateTime
            Get
                Return m_callDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CallingDate", m_callDate, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID der Adresse ab, die diesem Anruf zugeordnet werden konnte. Kann leer sein, wenn keine Zuweisung möglich
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <Size(32)> _
        <Persistent("AddressID")> _
        Private Property AddressID() As String
            Get
                Return m_AdressID
            End Get
            Set(ByVal value As String)
                m_AdressID = value
            End Set
        End Property

        ''' <summary>
        ''' Aktualisiert die Adresse anhand der Anrufernummer
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub FindAddressByCallerID()
            Me.CallerAddress = FindAddressByCallerID(Me.CallingID)
        End Sub

        ''' <summary>
        ''' Ruft anhand einer CallerID eine Adresse ab, nothing, falls nicht gefunden
        ''' </summary>
        ''' <param name="callid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function FindAddressByCallerID(ByVal callid As String) As Adress

            If String.IsNullOrEmpty(callid) Then Return Nothing

            For Each adress As Adress In m_mainApplication.Adressen
                Dim simplePhoneNumber As String = adress.Telefon1
                If Not String.IsNullOrEmpty(simplePhoneNumber) Then
                    Debug.Print(simplePhoneNumber)

                    simplePhoneNumber = GetNormalizedCalleID(simplePhoneNumber)

                    If simplePhoneNumber.Contains(callid) Then
                        Return adress
                    End If
                End If

            Next
            Return Nothing
        End Function

        ''' <summary>
        ''' Ruft eine CallID ab, die nur nummerische Zeichen enthält
        ''' </summary>
        ''' <param name="callerID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Public Shared Function GetNormalizedCalleID(ByVal callerID As String) As String
            If Not String.IsNullOrEmpty(callerID) Then
                callerID = callerID.Replace(" ", "") ' keine Leerzeichen
                callerID = callerID.Replace("-", "") ' keine Sonderzeichen
                callerID = callerID.Replace("/", "") ' keine Sonderzeichen
                callerID = callerID.Replace("\", "") ' keine Sonderzeichen
                callerID = callerID.Replace(":", "") ' keine Sonderzeichen
                callerID = callerID.Replace("(", "") ' keine Sonderzeichen
                callerID = callerID.Replace(")", "") ' keine Sonderzeichen
            Else
                callerID = String.Empty ' zumindest einen leeren String zurückgeben
            End If

            Return callerID
        End Function

        ''' <summary>
        ''' Sofern möglich enthält diese Eigenschaft den adressdatensatz des Anrufers. 
        ''' Falls dieser nicht erkannt wurde, wird 'nothing' zurückgegeben
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CallerAddress() As Adress
            Get
                Return MainApplication.Adressen.GetItem(Me.AddressID)
            End Get
            Set(ByVal value As Adress)
                If value IsNot Nothing Then
                    Me.AddressID = value.Key
                Else
                    Me.AddressID = Nothing
                End If
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Zustand des Anrufes ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CallState() As CallStateType
            Get
                Return m_CallState
            End Get
            Set(ByVal value As CallStateType)
                m_CallState = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Zielrufnummer ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(30)> _
        <Persistent("TargetCallID")> _
        Public Property TargetCallID() As String
            Get
                Return m_targetCallID
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("TargetCallID", m_targetCallID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die eingehende Rufnummer ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(25)> _
        <Persistent("CallingID")> _
        Public Property CallingID() As String
            Get
                Return m_callingID
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("CallingID", m_callingID, value)
            End Set
        End Property


        Public Sub New(ByVal session As Session)
            MyBase.New(session)



        End Sub
    End Class
End Namespace