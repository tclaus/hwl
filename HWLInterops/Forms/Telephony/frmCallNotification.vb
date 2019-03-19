
Imports ClausSoftware.Kernel

Namespace Telephony


    Public Class frmCallNotification

        Private m_mainUI As mainUI

        Private m_callInfo As PhoneCall

        Private Delegate Sub SetCallInfoDele(ByVal currentCall As PhoneCall)
        Private m_SetCallInfoDele As New SetCallInfoDele(AddressOf SetCallInfo)

        ''' <summary>
        ''' Setzt threadsicher die Eigenschaft des PhoneCalls
        ''' </summary>
        ''' <param name="currentCall"></param>
        ''' <remarks></remarks>
        Public Sub SetCallInfo(ByVal currentCall As PhoneCall)
            If Me.InvokeRequired Then
                Me.Invoke(m_SetCallInfoDele, currentCall)
            Else
                CallInfo = currentCall
            End If
        End Sub

        ''' <summary>
        ''' Die Anrufer-Information
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CallInfo() As PhoneCall
            Get
                Return m_callInfo
            End Get
            Set(ByVal value As PhoneCall)
                m_callInfo = value
                lblCallerID.Text = value.CallingID
                lblCallStartTime.Text = value.CallingDate.ToString("d")

                If value.CallerAddress IsNot Nothing Then
                    lblCallerAdress.Text = value.CallerAddress.InvoiceAdressWindow
                    btnOpenAdress.Enabled = True
                Else
                    lblCallerAdress.Text = GetText("msgUnknownAdrssFromCallerID", "-unbekannte Adresse-")
                    btnOpenAdress.Enabled = False
                End If
                btnOpenAdress.Enabled = True

            End Set
        End Property

        Private Sub frmCallNotification_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'PictureEdit1.Image = My.Resources.telephone_48x48

            m_application.Languages.SetTextOnControl(Me)

        End Sub

        Private Sub btnOpenAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenAdress.Click
            ' Adressbuh aufmachen, wenn eine adresse üpbergeben wurde, 
            ' Nur das Adressbuch 
            If Me.CallInfo.CallerAddress IsNot Nothing Then

                'Dim newAdressentry As Adress = m_application.Adressen.GetNewItem
                'newAdressentry.Telefon1 = "0" & Me.CallInfo.CallingID ' Führende Null angeben
                'Me.CallInfo.CallerAddress = newAdressentry
                m_mainUI.OpenElementWindow(Me.CallInfo.CallerAddress)
            Else
                m_mainUI.OpenWorkingPane(HWLModules.Adressbook)

            End If




        End Sub
        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse und übergibt die StammUI-Klasse
        ''' </summary>
        ''' <param name="thisMainUI"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal thisMainUI As mainUI)

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()

            ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
            m_mainUI = thisMainUI
        End Sub
    End Class
End Namespace
