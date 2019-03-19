Imports DevExpress.XtraReports
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.UserDesigner.ReportCommand

Namespace Printing

    ''' <summary>
    ''' Stellt einen Dialog bereit, der ein einfaches Bearbeiten des Briefe-Layouts ermöglicht.
    ''' </summary>
    ''' <remarks>Stellt das einfache "Seite einrichten" von früher dar</remarks>
    Public Class iucSimpleLayouteditor
        Implements IModule

        Private m_report As DevExpress.XtraReports.UI.XtraReport
        ''' <summary>
        ''' stellt den Druck-Manager für das Briefpapier bereit
        ''' </summary>
        ''' <remarks></remarks>
        Private m_printingManager As New PrintingManager

        Private m_footerText1 As XRControl
        Private m_headerText2 As XRControl


        ''' <summary>
        ''' Stellt die Adresszeile dar
        ''' </summary>
        ''' <remarks></remarks>
        Private m_addressLine As XRControl

        Public Function CloseModule() As Boolean Implements IModule.CloseModule

            Return True

        End Function

        Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
            Get
                Return String.Empty
            End Get
        End Property

        ''' <summary>
        ''' In diesem Dialog kann man nicht löschen
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DeleteItem() Implements IModule.DeleteItem

        End Sub

        ''' <summary>
        ''' Ruft den Anzeigetext dieses Modules ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
            Get
                Return GetText("msgPageSetup", "Seite einrichten")
            End Get
        End Property

        Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
            Get

            End Get
        End Property

        Public Sub InitializeModule() Implements IModule.InitializeModule

            m_printingManager.InitBusinessLayout()
            m_report = m_printingManager.BusinesReport ' Briefpapier abholen

            m_printingManager.IsBusinessLayout = True


            ' Den Designer aufbauen; einige Funktionen ausblenden
            Me.PageDesigner.SetCommandVisibility(AddNewDataSource, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility([Exit], DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(BindFieldToXRBarCode, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(BindFieldToXRCheckBox, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(BindFieldToXRLabel, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(BindFieldToXRPictureBox, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(BindFieldToXRRichText, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(BindFieldToXRZipCode, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(HtmlHome, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(ShowHTMLViewTab, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)

            Me.PageDesigner.SetCommandVisibility(InsertBottomMarginBand, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(InsertDetailBand, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(InsertGroupFooterBand, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(InsertGroupHeaderBand, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)

            Me.PageDesigner.SetCommandVisibility(NewReportWizard, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)
            Me.PageDesigner.SetCommandVisibility(VerbEditBands, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)



            ' PageDesigner.SetCommandVisibility(Delete, UserDesigner.CommandVisibility.None) ' Löschen verhindern
            PageDesigner.SetCommandVisibility(Cut, UserDesigner.CommandVisibility.None)


            ' Fussleiste nicht anzeigen lassen
            PageDesigner.ShowComponentTray = False
            PageDesigner.SetCommandVisibility(ShowScriptsTab, DevExpress.XtraReports.UserDesigner.CommandVisibility.None)

            ' Den Report aufbauen 
            Me.PageDesigner.OpenReport(m_report)

            'Dim setValue As String
            'setValue = m_application.Settings.GetSetting("SimpleReportLayout", "SimpleReport")

            'Dim bytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(setValue)

            'Dim s As New System.IO.MemoryStream(bytes)

            'XrDesignBarManager1.RestoreLayoutFromStream(s) ' Das einfache Report-Layout abspeichermn

            PageDesigner.AddCommandHandler(CType(New SaveCommandHandler(PageDesigner, m_printingManager), DevExpress.XtraReports.UserDesigner.ICommandHandler))

            InitPageElementControls()

        End Sub

        ''' <summary>
        ''' Stellt die Checkboxen der Hilfselemente ein
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub InitPageElementControls()
            chkFooterImage.Checked = GetFooterImage.Visible
            chkHeaderImage.Checked = GetHeaderImage.Visible
            chkFooterText1.Checked = GetFooterText1.Visible
            chkFooterText2.Checked = GetFooterText1.Visible
            chkHeaderText1.Checked = GetHeaderText1.Visible
            chkHeaderText2.Checked = GetHeaderText2.Visible

            ' Die adresszeile aus der Oberfläche holen 
            txtAdressLine.Text = GetAddressline.Text

            GetAddressfield() ' Das Adressfeld darstellen. 



        End Sub

        Public Sub NewItem() Implements IModule.CreateNewItem

        End Sub

        Public Overrides Sub Print() Implements IModule.Print

        End Sub

        ''' <summary>
        ''' Speichert das Business-Layout ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem
            m_printingManager.SaveBusinessLayout()
        End Sub

        Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

        Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
            Get
                Return actionButtons.btnClose Or actionButtons.btnSave
            End Get
        End Property

        Public Sub New(ByVal myUI As mainUI)
            MyBase.New(myUI)
            InitializeComponent()

        End Sub

#Region " Steuerung der Seitenelemente"
        Private Sub chkHeaderImage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeaderImage.CheckedChanged
            Dim item As XRControl = GetHeaderImage()
            item.Visible = chkHeaderImage.Checked
            'm_report.CreateDocument()
            PageDesigner.PerformLayout()
        End Sub


        Private m_headerImage As XRPictureBox
        Private m_footerImage As XRPictureBox

        ''' <summary>
        ''' Ruft das Logo für den Seitenfuss ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetFooterImage() As XRPictureBox
            If m_footerImage Is Nothing Then
                m_footerImage = CType(GetBand(BandKind.PageFooter).Controls("picFooter"), XRPictureBox)
                If m_footerImage Is Nothing Then
                    m_footerImage = New XRPictureBox
                    m_footerImage.Name = "picFooter"
                    m_footerImage.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
                    m_footerImage.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker

                    m_footerImage.LeftF = CSng(3 * m_footerImage.WidthF * 1.5)

                    PageDesigner.Report.Bands(DevExpress.XtraReports.UI.BandKind.PageFooter).Controls.Add(m_footerImage)
                End If
            End If


            Return m_footerImage

        End Function

        ''' <summary>
        ''' Ruft ein Band ab. Falls es im angegeben Report nicht existiert, wird es angelegt
        ''' </summary>
        ''' <param name="kind"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetBand(ByVal kind As DevExpress.XtraReports.UI.BandKind) As DevExpress.XtraReports.UI.Band
            Dim band As DevExpress.XtraReports.UI.Band = PageDesigner.Report.Bands(kind)
            If band Is Nothing Then
                Dim bFactory As New DevExpress.XtraReports.UI.BandFactory
                band = bFactory.CreateInstance(kind)
                PageDesigner.Report.Bands.Add(band)
            End If
            Return band
        End Function

        ''' <summary>
        ''' Ruft das Logo für den Seitenkopf ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetHeaderImage() As XRPictureBox
            If m_headerImage Is Nothing Then
                m_headerImage = CType(GetBand(BandKind.PageHeader).Controls("picHeader"), XRPictureBox)
                If m_headerImage Is Nothing Then
                    m_headerImage = New XRPictureBox
                    m_headerImage.Name = "picHeader"
                    m_headerImage.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
                    m_headerImage.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker

                    m_headerImage.LeftF = CSng(3 * m_headerImage.WidthF * 1.5)

                    PageDesigner.Report.Bands(DevExpress.XtraReports.UI.BandKind.PageHeader).Controls.Add(m_headerImage)
                End If
            End If


            Return m_headerImage

        End Function




        ''' <summary>
        ''' Ruft die Adresszeile ab oder legt diese fest
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetAddressline() As XRControl
            If m_addressLine Is Nothing Then
                m_addressLine = CType(GetBand(BandKind.PageHeader).Controls("lblAddressLine"), XRControl)

                If m_addressLine Is Nothing Then
                    m_addressLine = New XRLabel
                    m_addressLine.Name = "lblAddressLine"
                    m_addressLine.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker

                    PageDesigner.Report.Bands(DevExpress.XtraReports.UI.BandKind.PageHeader).Controls.Add(m_addressLine)
                End If

            End If

            txtAdressLine.EditValue = m_addressLine.Text
            Return m_addressLine

        End Function
        ''' <summary>
        ''' Ruft das element ab, das den 2. Textblock der Überschrift darstellt
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetHeaderText2() As XRControl
            If m_headerText2 Is Nothing Then
                m_headerText2 = CType(GetBand(BandKind.PageHeader).Controls("lblHeaderText2"), XRControl)

                If m_headerText2 Is Nothing Then
                    m_headerText2 = New XRLabel
                    m_headerText2.Name = "lblHeaderText2"
                    CType(m_headerText2, XRLabel).Multiline = True

                    m_headerText2.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker

                    m_headerText2.LeftF = CSng(2 * m_headerText2.WidthF * 1.5)

                    PageDesigner.Report.Bands(DevExpress.XtraReports.UI.BandKind.PageHeader).Controls.Add(m_headerText2)
                End If

            End If

            Return m_headerText2

        End Function

        ''' <summary>
        ''' stellt das Adressfenster dar
        ''' </summary>
        ''' <remarks></remarks>
        Private m_addressfieldText As XRControl

        ''' <summary>
        ''' Ruft das Adressfenster-Control ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetAddressfield() As XRControl
            If m_addressfieldText Is Nothing Then
                m_addressfieldText = CType(GetBand(BandKind.PageHeader).Controls("lblAddressField"), XRControl)

                If m_addressfieldText Is Nothing Then

                    Dim defaultHeigh As Single
                    Dim dummy As New XRLabel
                    defaultHeigh = dummy.HeightF

                    m_addressfieldText = New XRLabel
                    m_addressfieldText.Name = "lblAddressField" ' Konstante - der Name wird später gesucht und ein entsprechendes Element in der Zielmaske wieder so positioniert.
                    m_addressfieldText.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker

                    CType(m_addressfieldText, XRLabel).Multiline = True

                    m_addressfieldText.LeftF = GetAddressline.LeftF
                    m_addressfieldText.Top = CInt(GetAddressline.Top + GetAddressline.HeightF + 5)
                    m_addressfieldText.WidthF = GetAddressline.WidthF
                    m_addressfieldText.HeightF = 3 * defaultHeigh ' x-Fache grösse annehmen
                    PageDesigner.Report.Bands(DevExpress.XtraReports.UI.BandKind.PageHeader).Controls.Add(m_addressfieldText)
                End If

            End If

            Return m_addressfieldText

        End Function

        Private m_headerText1 As XRControl
        ''' <summary>
        ''' Ruft den ersten Kopftext ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetHeaderText1() As XRControl
            If m_headerText1 Is Nothing Then
                m_headerText1 = CType(GetBand(BandKind.PageHeader).Controls("lblHeaderText1"), XRControl)

                If m_headerText1 Is Nothing Then
                    m_headerText1 = New XRLabel
                    m_headerText1.Name = "lblHeaderText1"
                    CType(m_headerText1, XRLabel).Multiline = True

                    m_headerText1.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker
                    m_headerText1.LeftF = CSng(m_headerText1.WidthF * 1.5)

                    PageDesigner.Report.Bands(DevExpress.XtraReports.UI.BandKind.PageHeader).Controls.Add(m_headerText1)
                End If

            End If

            Return m_headerText1

        End Function




        ''' <summary>
        ''' Ruft den ersten Fusstext ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetFooterText1() As XRControl

            m_footerText1 = CType(GetBand(BandKind.PageFooter).Controls("lblFooterText1"), XRControl)
            If m_footerText1 Is Nothing Then
                If m_footerText1 Is Nothing Then
                    m_footerText1 = New XRLabel
                    m_footerText1.Name = "lblFooterText1"
                    CType(m_footerText1, XRLabel).Multiline = True
                    m_footerText1.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker

                    m_footerText1.LeftF = CSng(m_footerText1.WidthF * 1.5)

                    PageDesigner.Report.Bands(DevExpress.XtraReports.UI.BandKind.PageFooter).Controls.Add(m_footerText1)
                End If

            End If

            Return m_footerText1

        End Function

        Private Sub GetServices()

        End Sub

        Private m_footerText2 As XRControl

        Private Function GetFooterText2() As XRControl

            m_footerText2 = CType(GetBand(BandKind.PageFooter).Controls("lblFooterText2"), XRControl)
            If m_footerText2 Is Nothing Then
                If m_footerText2 Is Nothing Then
                    m_footerText2 = New XRLabel
                    m_footerText2.Name = "lblFooterText2"
                    CType(m_footerText2, XRLabel).Multiline = True

                    m_footerText2.Tag = ClausSoftware.Kernel.Printing.Report.BusinessMarker
                    m_footerText2.LeftF = CSng(2 * m_footerText2.WidthF * 1.5)

                    PageDesigner.Report.Bands(DevExpress.XtraReports.UI.BandKind.PageFooter).Controls.Add(m_footerText2)
                End If

            End If

            Return m_footerText2

        End Function

        Private Sub XrDesignPanel1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageDesigner.SelectionChanged

            If PageDesigner.GetSelectedComponents.Length = 1 Then
                PropertyGridControl1.SelectedObject = PageDesigner.GetSelectedComponents(0)
            Else
                If PageDesigner.GetSelectedComponents.Length > 1 Then
                    PropertyGridControl1.SelectedObjects = PageDesigner.GetSelectedComponents
                Else
                    '=0 
                    PropertyGridControl1.SelectedObjects = Nothing

                End If

            End If




            Dim selected As Object() = PageDesigner.GetSelectedComponents
            cboControls.Properties.Items.Clear()

            If selected.Length = 1 Then
                Dim selControl As XRControl = TryCast(PageDesigner.GetSelectedComponents(0), XRControl)
                If selControl IsNot Nothing Then
                    cboControls.Properties.Items.AddRange(selControl.Band.Controls)
                    cboControls.SelectedItem = selControl
                End If
            End If


        End Sub

        Private Sub cmdEditHeaderImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditHeaderImage.Click
            Try
                Dim f As New Vista_Api.OpenFileDialog()
                If f.ShowDialog() = DialogResult.OK Then
                    GetHeaderImage.Image = Image.FromFile(f.FileName)
                End If

            Catch ex As InsufficientMemoryException
                m_application.Log.WriteLog(ex, "SimpleLayouteditor", "Ein Fehler trat mit dem Bild auf - wahrscheinlich ist die Bild-Datei defekt.")

            Catch ex As Exception
                m_application.Log.WriteLog(ex, "SimpleLayouteditor", "Ein Fehler trat mit dem Bild auf")
            End Try



        End Sub

        Private Sub chkHeaderText1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeaderText1.CheckedChanged
            GetHeaderText1.Visible = chkHeaderText1.Checked
        End Sub



        Private Sub Button_Textedit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneditFooterText1.Click, btneditFooterText2.Click, btnHeaderText2.Click, btnHeaderText1.Click, btnAdressLine.Click

            Dim frm As New SimplePrintingTextedit

            If sender Is btneditFooterText1 Then
                frm.ReportControl = GetFooterText1()
            End If
            If sender Is btneditFooterText2 Then
                frm.ReportControl = GetFooterText2()

            End If
            If sender Is btnHeaderText1 Then
                frm.ReportControl = GetHeaderText1()

            End If
            If sender Is btnHeaderText2 Then
                frm.ReportControl = GetHeaderText2()
            End If

            If sender Is btnAdressLine Then
                frm.ReportControl = GetAddressline()
            End If

            frm.ShowDialog()

            PageDesigner.Update()
            PageDesigner.Activate()
            PageDesigner.ResumeLayout(True)
        End Sub


        Private Sub PageDesigner_ZoomValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            ' PageDesigner.ExecCommand(Zoom, New Object() {PageDesignerZoom.Value / 100})


        End Sub

        Private Sub chkHeaderText2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeaderText2.CheckedChanged
            GetHeaderText2.Visible = chkHeaderText2.Checked
        End Sub

        Private Sub chkFooterImage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFooterImage.CheckedChanged
            GetFooterImage.Visible = chkFooterImage.Checked

        End Sub

        Private Sub chkFooterText1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFooterText1.CheckedChanged
            GetFooterText1.Visible = chkFooterText1.Checked
        End Sub

        Private Sub chkFooterText2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFooterText2.CheckedChanged
            GetFooterText2.Visible = chkFooterText2.Checked

        End Sub
#End Region



        Private Sub PageDesigner_ComponentChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.Design.ComponentChangedEventArgs) Handles PageDesigner.ComponentChanged
            Debug.Print("Component changing: " & e.Component.ToString)

        End Sub

        Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
            PageDesigner.ExecCommand(ZoomOut)


        End Sub

        Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click
            PageDesigner.ExecCommand(ZoomIn)

        End Sub

        Private Sub PageDesigner_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PageDesigner.MouseDown
            Dim selected As Object() = PageDesigner.GetSelectedComponents


        End Sub

        Private Sub txtAdressLine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdressLine.TextChanged
            m_addressLine.Text = txtAdressLine.Text
        End Sub

        Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub PageDesigner_ComponentRemoving(ByVal sender As System.Object, ByVal e As System.ComponentModel.Design.ComponentEventArgs) Handles PageDesigner.ComponentRemoving

            ' Die Bänder PageHeader, und PageFooter dürfen nicht gelöscht werden
            If TypeOf e.Component Is DevExpress.XtraReports.UI.PageHeaderBand Or _
                TypeOf e.Component Is DevExpress.XtraReports.UI.PageFooterBand Then

            End If

            Debug.Print("Wirklich löschen ?")
        End Sub

        Private Sub cboControls_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboControls.SelectedIndexChanged
            'TODO: Beim wechsel der selektierten Zeile auch das Control selektieren
            Dim serviceProvider As IServiceProvider = CType(PageDesigner, IServiceProvider)

            Dim selectionService As System.ComponentModel.Design.ISelectionService = CType(serviceProvider.GetService(GetType(System.ComponentModel.Design.ISelectionService)), System.ComponentModel.Design.ISelectionService)
            Dim selCollection As New Collection
            selCollection.Add(cboControls.SelectedItem)
            selectionService.SetSelectedComponents(selCollection)

        End Sub

        Private Sub btnResetLayout_Click(sender As System.Object, e As System.EventArgs) Handles btnResetLayout.Click

            ResetLayout()

        End Sub

        Private Sub ResetLayout()
            Dim result As DialogResult
            result = MessageBox.Show("Möchten Sie das Druck-Layout vollständig zurücksetzen?", "Layout zurücksetzen", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
            If result = DialogResult.Yes Then

                Do While PageDesigner.Report.Bands.Count > 0
                    Dim band As DevExpress.XtraReports.UI.Band = PageDesigner.Report.Bands(0)
                    Do While Band.Controls.Count > 0
                        Band.Controls.Remove(Band.Controls(0))
                    Loop

                    PageDesigner.Report.Bands.Remove(PageDesigner.Report.Bands(0))

                Loop

            End If
        End Sub

    End Class
End Namespace