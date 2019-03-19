Imports ClausSoftware.Kernel


''' <summary>
''' stellt einen dialog bereit, der eine LIste von Anrufen enthält, die erkannt wurden
''' </summary>
''' <remarks></remarks>
Public Class frmCallersList

    Private m_CallersList As PhoneCalls
    Private m_unknownAdresstext As String = GetText("msgUnknownCallerID", "<Unbekannt>")

    ''' <summary>
    ''' Enthält bereits gesuchte Telefonnummern und die ermittelte Adresse dazu. Nothing falls nichts gefunden werden konnte
    ''' </summary>
    ''' <remarks></remarks>
    Private m_checkedUnknownAddresses As New Dictionary(Of String, Adress)

    ''' <summary>
    ''' Stellt die Hauptklasse für UI-Operationen bereit
    ''' </summary>
    ''' <remarks></remarks>
    Private m_mainui As mainUI

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse
    ''' </summary>
    ''' <param name="ui"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ui As mainUI)
        Me.InitializeComponent()

        m_mainui = ui
    End Sub

    ''' <summary>
    ''' ruft die Liste der PhoneCalls ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Calls() As PhoneCalls
        Get
            Return m_CallersList
        End Get
        Set(ByVal value As PhoneCalls)
            m_CallersList = value

            grdCallersList.DataSource = value

        End Set
    End Property

    Private Sub repshowAddress_CustomDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles repshowAddress.CustomDisplayText
        Dim address As Adress = TryCast(e.Value, Adress)
        If address IsNot Nothing Then
            e.DisplayText = address.Company & ", " & address.ContactsName & ", " & address.ZipCode & " " & address.Town
        Else
            e.DisplayText = m_unknownAdresstext
        End If



    End Sub

    Private Sub frmCallersList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Languages.SetTextOnControl(Me)

        RestoreGridStyles(grvCallersList, "phoneCallerList")
    End Sub

    Private Sub frmCallersList_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then ' schliesst der Benutzer das Fenster, dann dieses nur verstecken

            SaveGridStyles(grvCallersList, "phoneCallerList")
            m_application.SendMessage("")

            e.Cancel = True
            Me.Hide()
        End If

    End Sub

    Private Sub grvCallersList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles grvCallersList.CustomColumnDisplayText
        If e.Column Is colCallerAddress Then

            Dim caller As PhoneCall = CType(grvCallersList.GetRow(e.RowHandle), PhoneCall)

            Dim address As Adress = caller.CallerAddress
            If address IsNot Nothing Then
                e.DisplayText = address.Company & ", " & address.ContactsName & ", " & address.ZipCode & " " & address.Town
            Else
                e.DisplayText = m_unknownAdresstext
            End If

        End If
        If e.Column Is colDate Then
            Dim caller As PhoneCall = CType(grvCallersList.GetRow(e.RowHandle), PhoneCall)
            Dim callDate As DateTime = caller.CallingDate

            ' wenn "Heute", dann nur Uhrzeit anzeigen lassen 
            If callDate.Date = Today Then
                e.DisplayText = callDate.TimeOfDay.ToString

            End If

        End If
    End Sub


    Private Sub grvCallersList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvCallersList.FocusedRowChanged

        ' Focussierte Zeile prüfen, wenn keine Adresse gefunden werden konnte

        If e.FocusedRowHandle > 0 Then ' Bei ganz leeren Grids kann das sein. 

            Dim caller As PhoneCall = CType(grvCallersList.GetRow(e.FocusedRowHandle), PhoneCall)

            If caller IsNot Nothing Then ' Adresse muss gültig sein
                If Not String.IsNullOrEmpty(caller.CallingID) Then  ' Keine leeren Telefonnummern prüfen

                    If Not m_checkedUnknownAddresses.ContainsKey(caller.CallingID) Then
                        Dim address As Adress = caller.CallerAddress
                        If address Is Nothing Then
                            caller.FindAddressByCallerID() ' Adresse erneut suchen
                            If caller.CallerAddress IsNot Nothing Then caller.Save()
                        End If
                        ' Merken; nicht erneut suchen
                        m_checkedUnknownAddresses.Add(caller.CallingID, address)
                    End If
                End If

            End If
        End If

    End Sub

    Private Sub frmCallersList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

    End Sub

    Private Sub frmCallersList_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
     
    End Sub

    Private Sub frmCallersList_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            ' Nach der Anzeige die höchste Nummer merken 
            If Me.Calls IsNot Nothing Then
                m_application.Settings.MonitorPhoneLinesLastNumber = Calls.GetMaxID
            End If

        End If
    End Sub

    Private Sub grvCallersList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvCallersList.KeyDown
        If e.KeyCode = Keys.Delete Then

            Do While grvCallersList.SelectedRowsCount > 0
                Dim CallToDelete As PhoneCall = TryCast(grvCallersList.GetRow(grvCallersList.GetSelectedRows(0)), PhoneCall)
                If CallToDelete IsNot Nothing Then
                    CallToDelete.Delete()
                End If

                'grvCallersList.DeleteRow(grvCallersList.GetSelectedRows(0))
            Loop

        End If

        If e.KeyCode = Keys.A And e.Control Then
            ' Alle Markieren
            grvCallersList.SelectRows(0, grvCallersList.RowCount - 1)
        End If

        If e.KeyCode = Keys.Enter Then
            If grvCallersList.FocusedRowHandle >= 0 Then
                OpenAdressByRow(grvCallersList.FocusedRowHandle)
                Exit Sub
            End If
        End If

    End Sub

    Private Sub grdCallersList_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdCallersList.MouseDoubleClick
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(grdCallersList.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView)


        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Location)
        If hi.InRow And hi.RowHandle >= 0 Then
            OpenAdressByRow(hi.RowHandle)
        End If

    End Sub


    Private Sub OpenAdressByRow(ByVal rowID As Integer)
        Dim caller As PhoneCall = TryCast(grvCallersList.GetRow(rowID), PhoneCall)
        If caller IsNot Nothing Then

            If caller.CallerAddress IsNot Nothing Then
                m_mainui.OpenElementWindow(caller.CallerAddress)
            End If
        End If

    End Sub

    Private Sub btnCopyCallerID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyCallerID.Click
        ' Die NUmmer des eingehenen Rufes kopieren
        Dim caller As PhoneCall = TryCast(grvCallersList.GetFocusedRow, PhoneCall)
        If caller IsNot Nothing Then
            Try
                Clipboard.SetText(caller.CallingID)
            Catch
            End Try
        End If
    End Sub

    Private Sub btnCReateNewContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNewContact.Click
        CreateNewContact()
    End Sub


    ''' <summary>
    ''' Erstellt einen neuen Kontakt anhand dieser angerufenen Nummer
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateNewContact()

        Dim caller As PhoneCall = TryCast(grvCallersList.GetFocusedRow, PhoneCall)
        If caller IsNot Nothing Then
            If caller.CallerAddress Is Nothing Then ' wenn bereits eine adresse zugewiesen werden konnte, dann nciht einer anderen zuweisen
                Me.TopMost = False
                Using frm As New frmEasyAddAddress
                    If frm.ShowDialog() = DialogResult.OK Then
                        ' neue Adresse wurde hinzugefügt / Hole diese mal ab, damit die Nr übergeben werden kann
                        If frm.Address IsNot Nothing Then
                            Dim newAdress As Adress = frm.Address

                            newAdress.Telefon1 = caller.CallingID
                            newAdress.Save()
                        End If
                    End If

                End Using
                Me.TopMost = True
            End If
        End If

    End Sub

    Private Sub btnAddCallerIDToAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCallerIDToAdress.Click
        AddFocusedCallerIDToAdress()
    End Sub

    Private Sub AddFocusedCallerIDToAdress()
        Dim caller As PhoneCall = TryCast(grvCallersList.GetFocusedRow, PhoneCall)
        If caller IsNot Nothing Then

            If caller.CallerAddress Is Nothing Then ' wenn bereits eine adresse zugewiesen werden konnte, dann nciht einer anderen zuweisen

                Me.TopMost = False
                Using frm As New frmSmallItemChooser
                    frm.DataKind = frmSmallItemChooser.DataKindenum.Contacts
                    frm.Initialize()
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        Dim newAdress As Adress = CType(frm.SelectedItem, Adress)
                        Dim testCallID As String = PhoneCall.GetNormalizedCalleID(newAdress.Telefon1)

                        If Not testCallID.Contains(caller.CallingID) Then   ' Nur wenn die eingehende Nr oder ein Teil davon nicht bereits vorhanden ist, dann zur bestehden Nr hinzufügen
                            newAdress.Telefon1 &= "; " & caller.CallingID
                            newAdress.Telefon1 = newAdress.Telefon1.Trim(New Char() {";"c, " "c})  ' überflüssige Zeichen am ende entfernen
                            newAdress.Save()
                        End If

                        If caller.CallerAddress Is Nothing Then
                            caller.CallerAddress = newAdress
                            caller.Save()
                        End If

                    End If


                End Using
                Me.TopMost = True
            End If

        End If
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Aufgabe aus dem Anruf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateNewTaskFromSelectedNumber()
        Dim caller As PhoneCall = TryCast(grvCallersList.GetFocusedRow, PhoneCall)
        If caller IsNot Nothing Then
            Dim newTask As Kernel.Task = m_application.Tasks.GetNewItem

            Dim address As Adress = caller.CallerAddress
            Dim AddressText As String = String.Empty

            If address IsNot Nothing Then
                AddressText = address.ToString
            End If

            newTask.CreateDate = Today
            newTask.Subject = GetText("Call") & " " & caller.CallingID
            newTask.Message = GetText("CallFrom", "Anruf von:") & vbCrLf & _
            AddressText & vbCrLf & _
                                      caller.CallingID

            m_application.Tasks.Add(newTask)

            m_mainui.OpenTasksList(newTask)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsPhoneHandling.Opening

        Dim caller As PhoneCall = TryCast(grvCallersList.GetFocusedRow, PhoneCall)
        If caller IsNot Nothing Then

            If caller.CallerAddress Is Nothing Then ' wenn bereits eine adresse zugewiesen werden konnte, dann nciht einer anderen zuweisen
                btnAddCallerIDToAdress.Enabled = True
                btnCreateNewContact.Enabled = True

            Else
                btnAddCallerIDToAdress.Enabled = False
                btnCreateNewContact.Enabled = False
            End If
        End If


    End Sub

    Private Sub btnCreateTaskFromCall_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateTaskFromCall.Click
        CreateNewTaskFromSelectedNumber()
    End Sub
End Class