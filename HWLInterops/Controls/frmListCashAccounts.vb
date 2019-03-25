Imports ClausSoftware.Kernel
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraTreeList.Nodes

''' <summary>
''' Stellt einen Dialog bereit, der alle Steuerklassen auflistet und zur Auswahl bereitstellt.
''' </summary>
''' <remarks></remarks>
Public Class frmListCashAccounts

    Private m_selectedAccount As CashAccount

    ''' <summary>
    ''' Das Ursprünglich selektiere Konto
    ''' </summary>
    ''' <remarks></remarks>
    Private m_orgSelectedAccount As CashAccount



    Private Sub frmListCashAccounts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        modmain.InitializeApplication()
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

        FillListBox()

        trvAccounts.Focus()


    End Sub

    ''' <summary>
    ''' Ruft den markierten Steuersatz ab oder legt diesen fest.
    ''' Soll kein Konto selektiert sein, wird nothing übergeben
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectedAccount() As CashAccount
        Get
            Return m_selectedAccount
        End Get
        Set(ByVal value As CashAccount)
            m_selectedAccount = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft die ID des Kontos zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns>Die ID des selektierten Kontos oder -1 falls kein Konto gewählt wurde oder der Vorgang abgebrochen wurde</returns>
    ''' <remarks></remarks>
    Property SelectedAccountID() As Integer
        Get
            If m_selectedAccount IsNot Nothing Then
                Return m_selectedAccount.AccountID
            Else
                Return -1
            End If

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Sub FillListBox()
        FillListBox("")
    End Sub

    ''' <summary>
    ''' Füllt die Listbox mit einen Suchbegriff auf
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillListBox(ByVal searchtext As String)

        Dim itemsList As New List(Of CashAccount)

        MainApplication.getInstance.CashAccounts.Reload()

        searchtext = searchtext.Trim
        If Not String.IsNullOrEmpty(searchtext) Then

            For Each item As CashAccount In MainApplication.getInstance.CashAccounts
                If item.ToString.ToLower.Contains(searchtext) Then
                    itemsList.Add(item)
                End If
            Next

        Else
            itemsList.AddRange(MainApplication.getInstance.CashAccounts)

        End If



        trvAccounts.DataSource = itemsList
        trvAccounts.KeyFieldName = "ID"
        trvAccounts.ParentFieldName = "ParentID"
        trvAccounts.ExpandAll()

        trvAccounts.RefreshDataSource()

        ' wenn eine SelectedID vergeben wurde, siche diese raus und markiere diese

        If m_selectedAccount IsNot Nothing Then
            Dim node As TreeListNode = trvAccounts.FindNodeByKeyID(m_selectedAccount.ID)
            If node IsNot Nothing Then
                trvAccounts.SetFocusedNode(node)
            End If
        End If
        setButtons()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        CreateNewCashAccount()
    End Sub

    ''' <summary>
    ''' Legt ein neues element an
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateNewCashAccount()
        Dim manager As New CashAccountManager
        manager.AddNewCashAccount()
        FillListBox()

    End Sub

    ''' <summary>
    ''' Bearbeitet das aktuell markierte element
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditFocusedAccount()
        ' bei doubleclick auf einen eintrag: 

        Dim selectedCashAccount As CashAccount = CType(trvAccounts.GetDataRecordByNode(trvAccounts.FocusedNode), CashAccount)
        If selectedCashAccount IsNot Nothing Then
            Dim editForm As New frmEditCashAccounts(selectedCashAccount, False)
            If editForm.ShowDialog = Windows.Forms.DialogResult.OK Then
                selectedCashAccount.Save()
                FillListBox()
            Else
                selectedCashAccount.Reload()
            End If
        Else
            CreateNewCashAccount()
        End If
        FillListBox(IucSearchPanel1.Text)

        ' Versuche den Vorher selektierten eintrag wieder zu finden
        Dim toselect As TreeListNode = trvAccounts.FindNodeByKeyID(selectedCashAccount.ID)
        If toselect IsNot Nothing Then
            trvAccounts.Selection.Clear()
            trvAccounts.Selection.Add(toselect)
            trvAccounts.FocusedNode = toselect
            trvAccounts.Focus()
        End If



    End Sub

    Private Sub DeleteFocusedAccount()
        ' bei doubleclick auf einen eintrag: 

        Dim selectedCashAccount As CashAccount = CType(trvAccounts.GetDataRecordByNode(trvAccounts.FocusedNode), CashAccount)
        If selectedCashAccount Is Nothing Then Exit Sub

        ' Prüfe, ob Buchungen existieren 
        Dim oldCashes As New CashJournalItems(MainApplication.getInstance, "CashAccountID=" & selectedCashAccount.AccountID)
        Dim oldTransactions As New Transactions(MainApplication.getInstance, "CashAccountID=" & selectedCashAccount.AccountID)

        'TODO: NLS
        If oldCashes.Count > 0 Or oldTransactions.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Es existieren noch Buchungsvorfälle, die dieses Konto benutzen." & vbCrLf &
                            "Möchten Sie das Konto Löschen, und die Buchungen einem anderen Konto zuweisen?", "Konto wird verwendet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2)


            If result = Windows.Forms.DialogResult.Yes Then
                ' einem anderem Konto zuweisen
                ''= > Auswähleen
                Dim searchForm As New frmSmallItemChooser()
                searchForm.DataKind = frmSmallItemChooser.DataKindenum.CashAccounts
                searchForm.Initialize()

                If searchForm.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Dim selecedItem As CashAccount = CType(searchForm.SelectedItem, CashAccount)

                    If selecedItem.AccountID <> selectedCashAccount.AccountID And selecedItem.AccountID >= 0 Then
                        ' nun alle Buchungen dieser ID zuweisen!
                        MainApplication.getInstance.Session.BeginTransaction()


                        For Each cashItem As CashJournalItem In oldCashes
                            cashItem.CashAccountID = selecedItem.AccountID
                            cashItem.Save()
                        Next

                        For Each transaction As Transaction In oldTransactions
                            transaction.CashAccount = selecedItem
                            transaction.Save()
                        Next
                        selectedCashAccount.Delete()
                        MainApplication.getInstance.Session.CommitTransaction()

                    End If

                    ' Nur, wenn der Artikel nicht derselbe ist, dann auch löschen 

                Else
                    ' Kein Löschen durchgeführt
                    Exit Sub

                End If



            End If
        Else
            ' Keine Buchung liegt vor 
            ' WEG !
            selectedCashAccount.Delete()


        End If


        FillListBox()

    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub trvAccounts_GetNodeDisplayValue(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.GetNodeDisplayValueEventArgs) Handles trvAccounts.GetNodeDisplayValue
        Dim currentAccount As CashAccount = CType(trvAccounts.GetDataRecordByNode(e.Node), CashAccount)

        If currentAccount IsNot Nothing Then
            e.Value = currentAccount.AccountNumber & " " & currentAccount.AccountName & " " & currentAccount.TaxValue & "%"
        End If


    End Sub

    Private Sub trvAccounts_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles trvAccounts.MouseDoubleClick
        Dim hi As DevExpress.XtraTreeList.TreeListHitInfo = trvAccounts.CalcHitInfo(e.Location)


        If hi.Node IsNot Nothing Then

            m_selectedAccount = CType(trvAccounts.GetDataRecordByNode(hi.Node), CashAccount)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub trvAccounts_FocusedNodeChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles trvAccounts.FocusedNodeChanged
        If e.Node IsNot Nothing Then
            m_selectedAccount = CType(trvAccounts.GetDataRecordByNode(e.Node), CashAccount)
        Else
            m_selectedAccount = Nothing
        End If
        setButtons()
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        EditFocusedAccount()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteFocusedAccount()
    End Sub


    Private Sub trvAccounts_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles trvAccounts.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' EditFocusedAccount()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

        If e.KeyCode = Keys.Delete Then
            Me.DeleteFocusedAccount()
        End If


        If e.KeyCode = Keys.F5 Then
            trvAccounts.RefreshDataSource()
        End If

    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        DeleteFocusedAccount()
    End Sub

    Private Sub mnuedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuedit.Click
        EditFocusedAccount()
    End Sub

    ''' <summary>
    ''' wird die escape-Taste gedrückt, wird das Fornmular beendet
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmListCashAccounts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            m_selectedAccount = Nothing
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

        If e.KeyCode = Keys.F3 Then
            MainApplication.getInstance.CashAccounts.Reload()
            trvAccounts.RefreshDataSource()
        End If

    End Sub

    Private Sub IucSearchPanel1_SearchTextChanged(ByVal sender As System.Object, ByVal e As ClausSoftware.HWLInterops.SearchTextEventArgs) Handles IucSearchPanel1.SearchTextChanged
        FillListBox(e.Text)
    End Sub

    Private Sub frmListCashAccounts_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        IucSearchPanel1.Focus()

        ' Falls noch kein Konto angegeben wurde, dann den Neu-Dialog aufrufen
        If MainApplication.getInstance.CashAccounts.Count = 0 Then
            CreateNewCashAccount()
        End If

    End Sub

    Private Sub IucSearchPanel1_SetNextControl(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IucSearchPanel1.SetNextControl
        trvAccounts.Focus()
    End Sub

    Private Sub trvAccounts_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trvAccounts.SelectionChanged
        SetButtons()

    End Sub

    ''' <summary>
    ''' Setzt den Enabled/Disabled Status der Buttons
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setButtons()
        Dim hasSelections As Boolean = trvAccounts.Selection.Count > 0

        btnedit.Enabled = hasSelections
        btnDelete.Enabled = hasSelections
    End Sub
End Class