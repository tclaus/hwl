''' <summary>
''' Stellt einen Dialog dar, der auf abgelaufene Lizenzen hinweist
''' </summary>
''' <remarks></remarks>
Public Class frmTestperiodExpired
    Private Sub lblCompanywebAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCompanywebAddress.Click

        Try
            Process.Start(lblCompanywebAddress.Text)
        Catch
        End Try

    End Sub


    Private Sub frmTestperiodExpired_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Languages.SetTextOnControl(Me)

        Dim DaysLeft As Integer = m_application.Licenses.GetBalanceLicenceTime


        lblActivationText.Text = GetText("lblActivationText", lblActivationText.Text, DaysLeft.ToString)

        CheckCloseButtonstate()

    End Sub

    ''' <summary>
    ''' die Anzeige das "Later" - Button kann variieren: Bis 90 Tage über die Zeit kann ein "Später" ausgeführt werden; danach nur ein "Schliessen"
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckCloseButtonstate()
        ' Bei mehr als 90 Tagen über die Zeit, auch kein Read-Only - Zugriff mehr!

        Dim DaysLeft As Integer = m_application.Licenses.GetBalanceLicenceTime
        Dim baseLic As Data.LicenseItem = m_application.Licenses.GetBaseLicense
        If DaysLeft < -30 And Not m_application.Licenses.BaseCodeCheck(baseLic) Then
            btnLater.Text = GetText("btnclose")
        Else

            If m_application.Licenses.BaseCodeCheck(baseLic) Then
                btnLater.Text = GetText("btnOK")
            Else
                btnLater.Text = GetText("btnLater")
            End If

        End If

    End Sub

    Private Sub btnLater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLater.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnLicenses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLicenses.Click
        Me.TopMost = False

        Using frm As New frmLicenses
            frm.ShowDialog()
            ' Nach eingabe der Lizenzen prüfen; ob das Programm weiterarbeiten darf
            CheckCloseButtonstate()

        End Using
    End Sub
End Class