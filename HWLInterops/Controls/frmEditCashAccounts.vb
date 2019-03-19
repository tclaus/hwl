Imports ClausSoftware.Kernel

Public Class frmEditCashAccounts

    Private m_asNew As Boolean
    Private m_cashAccount As CashAccount

    ''' <summary>
    ''' erstellt eine neue Instanz des Formulares und ein aktives KOnto
    ''' </summary>
    ''' <param name="activeCashAccount"></param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal activeCashAccount As CashAccount, ByVal asNew As Boolean)
        Me.InitializeComponent()

        m_cashAccount = activeCashAccount

        FillParentGroups()
        FillMwSt()


        txtDisplayNumber.Text = CStr(activeCashAccount.AccountNumber)
        txtName.Text = activeCashAccount.AccountName

        If activeCashAccount.ParentID <> 0 Then
            cboBaseAccount.SelectedItem = activeCashAccount.ParentAccount
        End If

        cboBaseAccount.Enabled = asNew Or activeCashAccount.ParentID = 0


    End Sub

    ''' <summary>
    ''' Füllt die Mehrwertsteuersätze auf
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillMwSt()

        cboMwSt.DataSource = m_application.TaxRates
        cboMwSt.ValueMember = "ID"
        cboMwSt.DisplayMember = "Displayname"
        cboMwSt.SelectedValue = m_cashAccount.TaxID

        If cboMwSt.SelectedItem Is Nothing Then
            If cboMwSt.Items.Count > 0 Then
                cboMwSt.SelectedIndex = 0
            End If
        End If

    End Sub

    Sub FillParentGroups()

        cboBaseAccount.Items.Add("")  ' das 'leere' Element
        cboBaseAccount.Items.Add("-") ' Trennstrich, danach bginnen die Oberkonten

        For Each account As CashAccount In m_application.CashAccounts.GetBaseAccounts
            'If account.ParentID = 0 Then
            cboBaseAccount.Items.Add(account)
            ' End If
        Next
    End Sub


    Sub ShowCashAccount()
        txtName.Text = m_cashAccount.AccountName
        txtName.Text = CStr(m_cashAccount.AccountNumber)

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        m_cashAccount.AccountName = txtName.Text
        m_cashAccount.AccountNumber = CStr(txtDisplayNumber.Text)
        m_cashAccount.IsBaseAccount = chkBaseAccount.Checked

        m_cashAccount.TaxID = CType(cboMwSt.SelectedItem, TaxRate).ID

        ' nur, wenn auch was gescheites gewählt wurde, dann auch das Vater-Objekt setzen
        If cboBaseAccount.SelectedItem IsNot Nothing Then
            If TypeOf cboBaseAccount.SelectedItem Is CashAccount Then
                m_cashAccount.ParentID = CType(cboBaseAccount.SelectedItem, CashAccount).ID
            End If
        End If
        If CheckIfExists() Then
            'TODO: NLS
            MessageBox.Show("Diese Kontonummer wurder bereits vergeben. " & vbCrLf & _
                            "Bitte wählen Sie eine andere Kontonummer.", "Kontonummer bereits vergeben", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If


    End Sub

    ''' <summary>
    ''' Prüft, ob die angegebene KOntonummer bereits existiert, gibt True zurück, wenn die Kontonummer bereits vergeben wurde
    ''' </summary>
    ''' <remarks></remarks>
    Function CheckIfExists() As Boolean

        For Each account As CashAccount In m_application.CashAccounts
            If account.AccountNumber.Equals(m_cashAccount.AccountNumber, StringComparison.InvariantCultureIgnoreCase) Then
                If account.ID <> m_cashAccount.ID Then
                    ' Dann gibt es mindestends einen CashAccount, der eine gleiche Kontonummer hat
                    Return True
                End If
            End If
        Next
        Return False

    End Function

    Private Sub frmEditCashAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtName.Focus()
        m_application.Languages.SetTextOnControl(Me)

    End Sub

    Private Sub txtName_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Enter
        txtName.SelectAll()

    End Sub


    Private Sub btnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class