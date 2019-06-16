Imports DevExpress.XtraReports.UI

Namespace Printing

    ''' <summary>
    ''' stellt einen vereinfachten Dialog zum Bearbeiten von Report-Texten zur Verfügung
    ''' Ist visuell so aufgebaut wie der HWL 1.x- Dialog
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SimplePrintingTextedit


        Private m_xrLabel As XRControl
        Public Property ReportControl() As XRControl
            Get
                Return m_xrLabel
            End Get
            Set(ByVal value As XRControl)
                m_xrLabel = value
                FillUi()
            End Set
        End Property

        Private Sub FillUi()
            txtText.Text = ReportControl.Text
            txtText.ForeColor = ReportControl.ForeColor
            txtText.Font = ReportControl.Font

            Select Case ReportControl.TextAlignment
                Case DevExpress.XtraPrinting.TextAlignment.BottomLeft, DevExpress.XtraPrinting.TextAlignment.MiddleLeft, DevExpress.XtraPrinting.TextAlignment.TopLeft
                    radTextAlign.SelectedIndex = 0

                Case DevExpress.XtraPrinting.TextAlignment.BottomCenter, DevExpress.XtraPrinting.TextAlignment.MiddleCenter, DevExpress.XtraPrinting.TextAlignment.TopCenter
                    radTextAlign.SelectedIndex = 1

                Case DevExpress.XtraPrinting.TextAlignment.BottomRight, DevExpress.XtraPrinting.TextAlignment.MiddleRight, DevExpress.XtraPrinting.TextAlignment.TopRight
                    radTextAlign.SelectedIndex = 2

            End Select

        End Sub

        Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
            Dim fontdlg As New System.Windows.Forms.FontDialog()
            If fontdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtText.Font = fontdlg.Font
            End If

        End Sub



        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            ReportControl.Text = txtText.Text
            ReportControl.ForeColor = txtText.ForeColor
            ReportControl.Font = txtText.Font
            If radTextAlign.SelectedIndex = 0 Then
                ReportControl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
                txtText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

            End If

            If radTextAlign.SelectedIndex = 1 Then
                ReportControl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                txtText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            End If
            If radTextAlign.SelectedIndex = 2 Then
                ReportControl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                txtText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

            End If

            Me.Close()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub

        Private Sub btnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor.Click
            Dim cdlg As New System.Windows.Forms.ColorDialog
            If cdlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtText.ForeColor = cdlg.Color
            End If
        End Sub

        Private Sub SimplePrintingTextedit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            MainApplication.getInstance.Languages.SetTextOnControl(Me)

        End Sub

        Private Sub radTextAlign_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radTextAlign.SelectedIndexChanged

            ' Bei Klick in die Radio-Buttons dies auch sofort anzeigen lassen
            If radTextAlign.SelectedIndex = 0 Then
                txtText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            End If

            If radTextAlign.SelectedIndex = 1 Then
                txtText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End If
            If radTextAlign.SelectedIndex = 2 Then
                txtText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            End If

        End Sub
    End Class
End Namespace