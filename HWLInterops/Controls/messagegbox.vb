Imports Microsoft.VisualBasic

''' <summary>
''' Stellt eine Proxy-Klasse für die Darstellung einer Messagebox da
''' </summary>
''' <remarks></remarks>
<ComClass(myMessagebox.ClassId, myMessagebox.InterfaceId, myMessagebox.EventsId)> _
Public Class myMessagebox

#Region "COM-GUIDs"
    ' Diese GUIDs stellen die COM-Identität für diese Klasse 
    ' und ihre COM-Schnittstellen bereit. Wenn Sie sie ändern, können vorhandene 
    ' Clients nicht mehr auf die Klasse zugreifen.
    Public Const ClassId As String = "23677bce-9ec8-4791-b1cb-21a7471f83fe"
    Public Const InterfaceId As String = "13946326-3012-4004-80f9-47535ad92952"
    Public Const EventsId As String = "c98e117e-7262-495f-bdc7-fdbdac60a16e"
#End Region

    ' Eine erstellbare COM-Klasse muss eine Public Sub New() 
    ' ohne Parameter aufweisen. Andernfalls wird die Klasse 
    ' nicht in der COM-Registrierung registriert und kann nicht 
    ' über CreateObject erstellt werden.
    Public Sub New()
        MyBase.New()
    End Sub


    Function msgbox(ByVal title As String, ByVal buttons As Integer, ByVal text As String) As Integer
        Dim icon As MessageBoxIcon
        Dim but As MessageBoxButtons

        icon = MessageBoxIcon.Information
        System.Windows.Forms.Application.EnableVisualStyles()

        If [Enum].IsDefined(GetType(MessageBoxButtons), buttons And 7) Then


            but = CType(buttons And 7, MessageBoxButtons)
        Else
            but = MessageBoxButtons.OK
        End If

        If [Enum].IsDefined(GetType(MessageBoxIcon), buttons And (Integer.MaxValue - 7)) Then
            icon = CType(buttons And (Integer.MaxValue - 7), MessageBoxIcon)
        Else
            icon = MessageBoxIcon.Information
        End If




        Return CType(System.Windows.Forms.MessageBox.Show(text, title, but, icon), Integer)

    End Function


End Class


