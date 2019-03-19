Imports ClausSoftware.Kernel

Namespace Telephony

    ''' <summary>
    ''' Stellt ISDN-Telephony-Funktionalität breit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CAPIPhony
        Private m_mainUI As mainUI

        Private Delegate Sub deleBeginShowCallInfobox(ByVal callInfo As Kernel.PhoneCall)
        Private Delegate Sub deleBeginHideCallInfobox()

        Dim asncHide As New deleBeginHideCallInfobox(AddressOf Me.BeginHideMessageBox)

        Dim frm As frmCallNotification

        Dim capi As Mommosoft.Capi.CapiApplication


        Private m_isAvailable As Boolean

        ''' <summary>
        ''' Wenn Wahr, wird ein eingehender Anruf durch ein Fenster signalisiert
        ''' </summary>
        ''' <remarks></remarks>
        Private m_MonitorPhoneLines As Boolean
        ''' <summary>
        ''' Legt fest, ob die Telefonleitung protokolliert werden soll oder ruft diesen Zustand ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MonitorPhoneLines() As Boolean
            Get
                Return m_MonitorPhoneLines
            End Get
            Set(ByVal value As Boolean)
                m_MonitorPhoneLines = value
            End Set
        End Property

        ''' <summary>
        ''' Ist True, wenn eine CAPI - Verbindung gefunden werden konnte
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsAvailable() As Boolean
            Get
                Return m_isAvailable
            End Get

        End Property

        Delegate Sub ShowCallNotification(p As Object)
        Private ShowCallNotifDelagate As New ShowCallNotification(AddressOf StartNotification)

        ''' <summary>
        ''' Startet die Benachrichtigung eines neuen Anrufes
        ''' </summary>
        ''' <param name="p"></param>
        ''' <remarks></remarks>
        Sub StartNotification(ByVal p As Object)
            Try
                If frm Is Nothing Then
                    frm = New frmCallNotification(m_mainUI)
                End If

                ' Könnte aus einem anderem Thread heraus kommen
                If frm.InvokeRequired Then
                    Debug.Print("WARNUNG: Calling Notification Fenster musste per 'invoke' aufgerufen werden!")
                    frm.Invoke(ShowCallNotifDelagate, New Object() {p})
                    Exit Sub
                End If

                frm.SetCallInfo(CType(p, PhoneCall))

                If frm.Visible Then ' Sonst kann kein ShowDialog aufgerufen werden! 
                    frm.Visible = False
                End If

                frm.ShowDialog()
            Catch ex As Exception
                m_application.Log.WriteLog(ex, "CallNotification Window", "frm.ShowDialog")
            End Try


        End Sub


        Public Sub InitCapi()
            If capi IsNot Nothing Then
                For Each cController As Mommosoft.Capi.Controller In capi.Controllers
                    cController.Listen(Mommosoft.Capi.CIPMask.Telephony Or Mommosoft.Capi.CIPMask.Audio31KHZ Or Mommosoft.Capi.CIPMask.Audio7KHZ)

                Next

                AddHandler capi.IncomingPhysicalConnection, AddressOf IncommingISDNCall
                AddHandler capi.ConnectionStatusChanged, AddressOf StatusChanged
            End If

        End Sub

        Private Sub IncommingISDNCall(ByVal sender As Object, ByVal e As Mommosoft.Capi.IncomingPhysicalConnectionEventArgs)
            Static processing As Boolean = False
            If Not processing Then
                processing = True
                Try
                    Debug.Print("(New-Call) Caller: " & e.Connection.CallingPartyNumber & " | Called: " & e.Connection.CalledPartyNumber)

                        Dim newPhoneLogentry As Kernel.PhoneCall = New Kernel.PhoneCall(m_application.GetNewSession)
                    newPhoneLogentry.TargetCallID = e.Connection.CalledPartyNumber
                    newPhoneLogentry.CallingID = e.Connection.CallingPartyNumber

                    If newPhoneLogentry.CallingID.Length > 4 Then ' Dann war es wohl kein Interner anruf => eine "0" davor setzen
                        newPhoneLogentry.CallingID = "0" & newPhoneLogentry.CallingID
                    End If

                    newPhoneLogentry.CallState = PhoneCall.CallStateType.Unanswered
                    newPhoneLogentry.CallingDate = Now
                    newPhoneLogentry.FindAddressByCallerID()
                    newPhoneLogentry.Save()  ' Und ab dafür !



                    If Me.MonitorPhoneLines Then

                        ' Dies auch signalisieren
                        m_mainUI.FireNewIncommingCall(newPhoneLogentry)

                        ' Neues Fenster basteln
                        Dim myCallNotification As New Threading.Thread(AddressOf StartNotification)
                        myCallNotification.Name = "CallNotification"
                        myCallNotification.Start(newPhoneLogentry)
                    End If

                Catch ex As Exception
                Finally
                    processing = False
                End Try
            Else
            End If


        End Sub

        Private Sub StatusChanged(ByVal sender As Object, ByVal e As Mommosoft.Capi.ConnectionEventArgs)
            Trace.WriteLine("Capi Line changes: " & e.Connection.Status.ToString, " ISDN-Line")
            If e.Connection.Status = Mommosoft.Capi.ConnectionStatus.Disconnected Then

                asncHide.BeginInvoke(Nothing, Nothing)
            End If

        End Sub



        ''' <summary>
        ''' Sofern eingeschaltet, wird die Anrufbenachrichtigung ausgeblendet
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub BeginHideMessageBox()
            If frm Is Nothing Then Exit Sub
            If frm.InvokeRequired Then
                Dim dele As New deleBeginHideCallInfobox(AddressOf BeginHideMessageBox)
                frm.Invoke(dele)
            Else

                If frm.Visible Then
                    frm.Hide()
                End If
            End If
        End Sub


        ' ''' <summary>
        ' ''' Ruft anhand einer CallerID eine Adresse ab, nothing, falls nicht gefunden
        ' ''' </summary>
        ' ''' <param name="callid"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Function FindAdressByCallerID(ByVal callid As String) As Adress

        '    For Each adress As Adress In m_application.Adressen
        '        Dim simplePhoneNumber As String = adress.Telefon1
        '        If Not String.IsNullOrEmpty(simplePhoneNumber) Then
        '            Debug.Print(simplePhoneNumber)
        '            simplePhoneNumber = simplePhoneNumber.Replace(" ", "") ' keine Leerzeichen
        '            simplePhoneNumber = simplePhoneNumber.Replace("-", "") ' keine Sonderzeichen
        '            simplePhoneNumber = simplePhoneNumber.Replace("/", "") ' keine Sonderzeichen
        '            simplePhoneNumber = simplePhoneNumber.Replace("\", "") ' keine Sonderzeichen
        '            simplePhoneNumber = simplePhoneNumber.Replace(":", "") ' keine Sonderzeichen
        '            simplePhoneNumber = simplePhoneNumber.Replace("(", "") ' keine Sonderzeichen
        '            simplePhoneNumber = simplePhoneNumber.Replace(")", "") ' keine Sonderzeichen

        '            If simplePhoneNumber.Contains(callid) Then
        '                Return adress
        '            End If
        '        End If

        '    Next
        '    Return Nothing
        'End Function

        Public Sub New(ByVal thisMainUI As mainUI)
            m_mainUI = thisMainUI
            Try
                capi = New Mommosoft.Capi.CapiApplication

                m_MonitorPhoneLines = m_application.Settings.MonitorPhoneLines
            Catch ex As Exception
                m_application.Log.WriteLog(ClausSoftware.Tools.LogSeverity.Warning, "Es stand keine CAPI-Verbindung zur Verfügung: " & ex.Message)
                m_isAvailable = False
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace
