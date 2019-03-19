Imports ClausSoftware
Imports ClausSoftware.Data
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

''' <summary>
''' Stellt einen dialog bereit, in dem Lizenzen für HWL verwaltet werden können.
''' </summary>
''' <remarks></remarks>
Public Class frmLicenses

    
    Private Sub frmLicenses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modmain.InitializeApplication()
        m_application.Languages.SetTextOnControl(Me)

        m_application = modmain.m_application

        lblProgramID.Text = m_application.ApplicationID.Substring(m_application.ApplicationID.Length - 5)

        If Not Tools.Services.CheckIfCodeIsValid(lblProgramID.Text) Then
            ' Code ungültig !
            lblInvalidCode.Visible = True
        Else
            lblInvalidCode.Visible = False
        End If


        FillLicensesList()
        Me.Text = Me.Text & " " & m_application.ApplicationID.Substring(m_application.ApplicationID.Length - 5)

        AddHandler GridView1.FocusedRowChanged, AddressOf FocusedRowChanged

        lblLicenseTextheadline.Text = lblLicenseTextheadline.Text.Replace("{0}", m_application.Licenses.GetBalanceLicenceTime.ToString)



    End Sub

    ''' <summary>
    ''' Erkennt eine Zeile 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub FocusedRowChanged(ByVal sender As Object, ByVal e As FocusedRowChangedEventArgs)

        Dim o As Object = GridView1.GetRow(e.FocusedRowHandle)
        If o IsNot Nothing Then
            o = GridView1.GetRow(GridView1.FocusedRowHandle)

            Dim license As ClausSoftware.Data.LicenseItem = TryCast(o, LicenseItem)

            If license IsNot Nothing Then
                btnEnterCode.Enabled = True
            Else
                btnEnterCode.Enabled = False
            End If

        Else
            btnEnterCode.Enabled = False
        End If

    End Sub

    ''' <summary>
    ''' Füllt die Liste der verfügbaren Lizenz-Module auf
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillLicensesList()
        Dim arraylist As New ArrayList

        Dim lastselectedID As Integer
        If GridView1.FocusedRowHandle > 0 Then
            lastselectedID = GridView1.FocusedRowHandle
        End If

        For Each lic As LicenseItem In m_application.Licenses.LizensesData.Values
            arraylist.Add(lic)

        Next
        grdLicenses.DataSource = arraylist

        Try

            'Liste kann leer sein!
            ' => Dann geht diese Zuwesiung nicht 
            GridView1.Columns("Name").VisibleIndex = 0 ' "Ist Aktiv auf Position 0 setzen

            If GridView1.RowCount > lastselectedID Then

                GridView1.FocusedRowHandle = lastselectedID
            End If
        Catch
        End Try

    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()

    End Sub


    Private Sub grdLicenses_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdLicenses.MouseDoubleClick
        Dim view As BaseView = grdLicenses.GetViewAt(grdLicenses.PointToClient(MousePosition))

        view = grdLicenses.FocusedView


        If view IsNot Nothing Then
            Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = CType(view.CalcHitInfo(grdLicenses.PointToClient(MousePosition)), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)
            Debug.Print(CStr(hi.HitTest))
            If hi.HitTest <> GridHitTest.ColumnEdge AndAlso hi.HitTest <> GridHitTest.Column Then
                If hi.RowHandle >= 0 Then
                    Dim o As Object = view.GetRow(hi.RowHandle)

                    ' hier steht nun das Objekt fest
                    ' Dialog aufrufen, wenn nicht aktiv 

                    Dim license As ClausSoftware.Data.LicenseItem
                    license = CType(o, ClausSoftware.Data.LicenseItem)

                    EnterLicenseCode(license)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Ermöglicht einen Lizenzschlüssel einzugeben
    ''' </summary>
    ''' <param name="license"></param>
    ''' <remarks></remarks>
    Private Sub EnterLicenseCode(ByVal license As ClausSoftware.Data.LicenseItem)
        ' If Not license.IsActive Then
        ' Dialog aufrufen
        Using enterLicenseCode As New frmLicenseCodeDialog()
            enterLicenseCode.License = license
            enterLicenseCode.ShowDialog()
            FillLicensesList()
        End Using

        ' End If
    End Sub

    Private Sub btnEnterCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnterCode.Click

        Dim o As Object

        If GridView1.FocusedRowHandle >= 0 Then

            o = GridView1.GetRow(GridView1.FocusedRowHandle)

            Dim license As ClausSoftware.Data.LicenseItem
            license = CType(o, ClausSoftware.Data.LicenseItem)

            EnterLicenseCode(license)
        End If

    End Sub

    ''' <summary>
    ''' Löscht die Lizenz, die in der Liste markiert wurde
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteLicense()
        Dim o As Object

        If GridView1.FocusedRowHandle >= 0 Then

            o = GridView1.GetRow(GridView1.FocusedRowHandle)

            Dim license As ClausSoftware.Data.LicenseItem

            license = CType(o, ClausSoftware.Data.LicenseItem)

            If license IsNot Nothing Then
                'TODO: NLS
                If MessageBox.Show("Möchten Sie die gewwählte Lizenz vollständig löschen? " & vbCrLf & _
                                   "" & _
                                   "Wenn ein Modul diese Lizenz anfordert, wird diese erneut angelegt. Eine eventuelle Freischaltung geht aber verlohren und muss neu angefordert werden.", "Lizenz vollständg löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    m_application.Licenses.Delete(license)
                    FillLicensesList()

                End If
            End If

        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteLicense()
    End Sub

    
    Private Sub GridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Dim focusedRow As Object
        focusedRow = GridView1.GetRow(e.FocusedRowHandle)
        If Not focusedRow Is Nothing Then
            Dim license As ClausSoftware.Data.LicenseItem

            license = CType(focusedRow, ClausSoftware.Data.LicenseItem)
            btnDelete.Enabled = Not license.IsActive  ' Nur inaktive (ungültige) LIzenzen können gelöscht werden
        End If

    End Sub

    Private Sub lblInvalidCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblInvalidCode.Click
        AskGenerateNewCode()
    End Sub

    ''' <summary>
    ''' Erweirkt das Nachfragen nach einem neuen HWL-Code
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AskGenerateNewCode()
        Dim result As DialogResult
        result = MessageBox.Show("Der Code ist möglicherweise beschädigt und kann nicht zum erzeugen von Lizenzen verwendet werden!" & vbCrLf & _
                        "Es kann aber ein neuer Code erzeugt werden. Möchten sie das nun tun?", "Programmcode beschädigt!", MessageBoxButtons.YesNo)
        If result = Windows.Forms.DialogResult.Yes Then
            ' HWL.ini neu schreiben
            ' in Datenbank neu hinterlegen
            ' HWL neu starten
            m_application.Connections.ClearAndRefreshAPPID()
            If Not System.Diagnostics.Debugger.IsAttached Then
                System.Windows.Forms.Application.Restart()
            Else
                Debug.Print("Einen Restart verkneifen wir uns, da ein Debugger angedockt ist!")
            End If
        End If
    End Sub

End Class