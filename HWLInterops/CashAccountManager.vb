Imports ClausSoftware.Kernel
Imports ClausSoftware.MainApplication

Public Class CashAccountManager

    Public Sub New()

        
    End Sub


    ''' <summary>
    ''' Fügt ein neues Konto hinzu und gibt zu Zugriffsnummer zurück, -1 falls Fehlgeschlagen
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddNewCashAccount() As Integer

        ' Finde höchste interne NUmmer
        Dim maxid As Integer
        For Each account As CashAccount In MainApplication.getInstance.CashAccounts
            If account.AccountID > maxid Then
                maxid = account.AccountID
            End If
        Next


        Dim newCashAccount As CashAccount = MainApplication.getInstance.CashAccounts.GetNewItem
        newCashAccount.AccountID = maxid + 1

        newCashAccount.AccountName = "<neues Buchungskonto>" 'TODO: NLS
        newCashAccount.TaxID = MainApplication.getInstance.Settings.SettingDefaultTaxID

        Using frm As New frmEditCashAccounts(newCashAccount, True)
            If frm.ShowDialog = DialogResult.OK Then

                newCashAccount.Save()
                Return newCashAccount.ID
            Else
                Return -1

            End If
        End Using

    End Function

    ''' <summary>
    ''' Zeigt einen Dialog mit der LIste der Accounts an
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ShowCashAccountList(ByVal selectedID As Integer) As Integer
        Using frmCashAccountLIst As New frmListCashAccounts

            frmCashAccountLIst.SelectedAccountID = selectedID

            If frmCashAccountLIst.ShowDialog() = DialogResult.OK Then

                Return frmCashAccountLIst.SelectedAccountID
            Else
                Return -1
            End If
        End Using
    End Function

End Class


