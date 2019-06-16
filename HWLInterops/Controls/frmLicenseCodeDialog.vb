Imports ClausSoftware.Data
Imports ClausSoftware


''' <summary>
''' Enthält einen Dialog mit dem eine Lizenz freigeschaltet werden kann
''' </summary>
''' <remarks></remarks>
Public Class frmLicenseCodeDialog

    Dim m_license As LicenseItem

    ''' <summary>
    ''' Ruft die aktuell freizuschaltene Lizenz ab oder legt diese fest. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property License() As LicenseItem
        Get
            Return m_license
        End Get
        Set(ByVal value As LicenseItem)
            m_license = value
            lblLicenseCodeHeadline.Text = GetText(lblLicenseCodeHeadline.Name, "Geben Sie den Schlüssel zur Freischaltung der Lizenz {0} ein.", value.Name)
            txtcode.Text = MainApplication.getInstance.Licenses.GetLicenseKey(value)
        End Set
    End Property

    ''' <summary>
    ''' Testet eine einen lizenz-schlüssel auf gültigkeit
    ''' </summary>
    ''' <remarks></remarks>
    Function Testlicense(ByVal code As String) As Boolean
        Try
            Return MainApplication.getInstance.Licenses.BaseCodeCheck(License.GUID, code)
        Catch ex As Exception
            Debug.Print("FEHLER beim Testen einer Lizenz:" & ex.Message)
        End Try
        Return False
    End Function

    Private Sub txtcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcode.TextChanged

        CheckLicenseKey()
    End Sub

    Private Sub RegisterLicenseKey()
        If Testlicense(txtcode.Text) Then
            MainApplication.getInstance.Licenses.SetLicenseKey(License, txtcode.Text.Trim)
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        RegisterLicenseKey()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmLicenseCodeDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

        CheckLicenseKey()

        txtcode.Focus()
        txtcode.SelectAll()
    End Sub

    ''' <summary>
    ''' Prüft die eingabe auf korrektheit und zeigt dies gegebenfalls an
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckLicenseKey()
        If Testlicense(txtcode.Text) Then

            lblLicenseValid.Text = GetText("msgValidLicense", "Lizenz OK") '"Lizenz OK!" 'TODO: NLS
        Else
            lblLicenseValid.Text = GetText("msgInvalidLicense", "Ungültig.") '"Ungültig!" ' TODO: NLS
        End If
    End Sub

    Private Sub txtcode_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtcode.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub

    Private Sub txtcode_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtcode.DragDrop
        DragDropHelper.SetText(sender, e)
    End Sub
End Class