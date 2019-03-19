Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraBars.Ribbon.Gallery
Imports System.IO
Imports ClausSoftware.Kernel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraScheduler.Printing
Imports System.Drawing.Printing
Imports ClausSoftware.Data
Imports DevExpress.XtraRichEdit.API.Native

<CLSCompliant(False)> _
Public Class iucLetters
    Implements IModule

    Private documentIndex As Integer = 0
    ''' <summary>
    ''' Enthält die Standardbeite des Briefbogens; wird für das Zoomen herangezogen
    ''' </summary>
    ''' <remarks></remarks>
    Private m_defaultwith As Integer


    Private m_hasChanges As Boolean
    ''' <summary>
    ''' Stellt den aktuellen Brief dar
    ''' </summary>
    ''' <remarks></remarks>
    <EditorBrowsable(EditorBrowsableState.Advanced)> _
    Private m_activeItem As ClausSoftware.Kernel.Letter


    Private temporarayRTF As New RTFControl

    ''' <summary>
    ''' Legt das aktive Element fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ActiveItem() As Letter
        Get
            Return m_activeItem
        End Get
        Set(ByVal value As Letter)
            m_activeItem = value
            If value IsNot Nothing Then
                rtbSubject.Text = m_activeItem.Subject
                rtfmain.RTFText = m_activeItem.RTFCodedText
                txtAdresswindow.Text = m_activeItem.AddressField
                txtTagWord.Text = m_activeItem.Tag
                datDate.EditValue = m_activeItem.CreatedAt

                lblCreatedAtValue.Text = m_activeItem.CreatedAt.ToString("d")
                lblLastChangedAtValue.Text = m_activeItem.LastChangedAt.ToString("d")

                'End If

                If m_activeItem.Address IsNot Nothing Then
                    SetStaustext("Dokument-Nummer: " & m_activeItem.DocumentID & ", Adressnummer:" & m_activeItem.Address.Kundennummer)
                Else
                    SetStaustext("Dokument-Nummer: " & m_activeItem.DocumentID)
                End If
            End If

        End Set
    End Property



    Private Sub LoadLetter(ByVal sender As Object, ByVal e As EventArgs)
        '  Stop

    End Sub

    Private ReadOnly Property DocumentName() As String
        Get
            Return String.Format("New Document {0}", documentIndex)
        End Get
    End Property

    Private Sub CreateNewDocument() Implements IModule.CreateNewItem
        Me.ActiveItem = m_application.Letters.GetNewItem

    End Sub


    ''' <summary>
    ''' Startet das Modul und stellt eine Verbindung zu der Datenbank her
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

        InitializeApplication()

    End Sub


    Private Sub btnNewLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewLetter.Click
        CreateNewDocument()


    End Sub


    Private Sub ClearControls()
        txtAdresswindow.Text = ""
        rtbSubject.Clear()
        rtfmain.RTFText = ""

    End Sub


    Private Sub paintback(ByVal e As PaintEventArgs)



    End Sub

    Private Sub OpenLetterDialog()
        Dim SearchLetters As New frmListLetters

        SearchLetters.Initialize()

        If SearchLetters.ShowDialog() = DialogResult.OK Then
            ' Dann dieses Brief auswählen, sofern der bisherige gespeichert wurde

            Me.ActiveItem = SearchLetters.SelectedLetter

        End If

        MainUI.MRUManager.AddMRUElement(ActiveItem)

        Me.Refresh()
    End Sub

    Private Sub btnOpenLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenLetter.Click
        OpenLetterDialog()
    End Sub

    Public Overrides Sub Print() Implements IModule.Print

        Try
            Using printing As New Printing.dlgPrintLetters(MainUI)
                ' printing.Grid = ArticlesGrid.grdArticles   ' Grid zuweisen
                Dim itemsList As New List(Of Letter)
                itemsList.Add(Me.ActiveItem)

                printing.LettersList = itemsList ' Aktuelle Instanz anzeigen alssen
                printing.ShowDialog()
            End Using


        Catch ex As Exception
            m_application.Log.WriteLog(ex, "Letters", "Print Letters")
        Finally
            Me.UseWaitCursor = False
        End Try
    End Sub

    ''' <summary>
    ''' Fragt nach, ob aktueller Brief gespeichert werden soll. 
    ''' Wird ""Yes" gewählt, so wird der Brief auch gespeichert
    ''' </summary>
    ''' <returns>Cancel, falls Abbruch durch Benutzer, sonst "OK". </returns>
    ''' <remarks></remarks>
    Function AskSaveDialog() As DialogResult
        Dim result As DialogResult
        result = modmain.AskChangedData

        If result = DialogResult.Yes Then
            SaveCurrentItem()
        End If

        Return DialogResult.OK

    End Function

    Private Function CloseDocument() As Boolean Implements IModule.CloseModule
        ' frage wegen Speichern, dann beenden 
        If ActiveItem IsNot Nothing And m_hasChanges Then

            If AskSaveDialog() = DialogResult.OK Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub btnSearchAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAdress.Click
        OpenAdressSearch()
    End Sub

    ''' <summary>
    ''' Öffnet einen adress-Suchdialog
    ''' </summary>
    ''' <remarks></remarks>
    Sub OpenAdressSearch()
        Try
            Dim frm As New frmSmallItemChooser
            frm.DataKind = frmSmallItemChooser.DataKindenum.Contacts
            frm.Initialize()
            frm.ShowDialog()

            Dim adressItem As ClausSoftware.Data.StaticItem = frm.SelectedItem
            If ActiveItem IsNot Nothing Then
                m_activeItem.Address = CType(adressItem, Adress)
                txtAdresswindow.Text = m_activeItem.Address.InvoiceAdressWindow
            End If

        Catch ex As Exception
            m_application.Log.WriteLog(ex, "UI", "Error while getting Address from Letters")

        End Try
    End Sub


    Private Sub btnResetAdress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAdress.Click

        If m_activeItem IsNot Nothing Then
            If m_activeItem.Address IsNot Nothing Then
                txtAdresswindow.Text = m_activeItem.Address.InvoiceAdressWindow
                m_activeItem.UserDefinedAdresswindow = False
            End If

        Else
            txtAdresswindow.Text = String.Empty
        End If
    End Sub

    ''' <summary>
    ''' Speichert das aktuelle Element ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Save()
        MyBase.Save()
        SaveCurrentItem()
    End Sub

    ''' <summary>
    ''' Überträgt die Eingabedaten in das Briefe-Objekt und speichert dies ab
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

        If Not MainUI.CheckIfLicenceValidForSaving() Then Exit Sub
        If Not m_application.Licenses.IsActiveLetters Then

            MessageBox.Show(GetText("msgMissingLettersLicense", "Sie haben keine Lizenz für 'Briefe'. Speichern nicht möglich!"), GetText("msgMissingLicense", "Keine Lizenz vorhanden"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If m_activeItem IsNot Nothing Then
            ' If IsActive() Then

            m_activeItem.AddressField = txtAdresswindow.Text
            m_activeItem.RTFCodedText = rtfmain.RTFText
            m_activeItem.Subject = rtbSubject.Text
            m_activeItem.Tag = txtTagWord.Text
            m_activeItem.CreatedAt = CDate(datDate.EditValue)
            m_activeItem.Save()

            m_application.SendMessage(GetText("msgsaved", "Gespeichert."))

        End If
    End Sub

    Private Sub txtAdresswindow_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdresswindow.TextChanged
        If m_activeItem IsNot Nothing Then
            m_activeItem.UserDefinedAdresswindow = True
        End If
    End Sub


    ''' <summary>
    ''' Setzt einen Statustext, der den aktuellen Zustand des Dokuemntes angibt
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub SetStaustext(ByVal message As String)
        '
    End Sub

    Private Sub iucnotepadmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        CreateNewDocument()

        Debug.Print("Briefe - Lizenz:" & m_application.Licenses.IsActiveLetters.ToString)  ' Dummy - damit wird im Lizenzmanagement ein Eintrag angelegt

        Dim defaultprinter As New System.Drawing.Rectangle(0, 0, 100, 100)

        Dim ps As New PrinterSettings
        ps.CreateMeasurementGraphics()

        Dim pagesettings As New PageSettings(ps)


        Dim prn As New PrintPageEventArgs(ps.CreateMeasurementGraphics, defaultprinter, pagesettings.Bounds, pagesettings)
        prn.HasMorePages = True



    End Sub




    Private Sub btnBullet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub iucnotepadmain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '   m_defaultwith = TextRuler1.Width
    End Sub




    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return GetText("Letters", "Briefe")
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule

    End Sub

    Public Sub LoadCurrentItem(ByVal currentitem As StaticItem)

    End Sub


    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.btnClose Or actionButtons.btnPrint Or actionButtons.btnSave
        End Get
    End Property

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    End Sub

    Public Sub New(ByVal myUI As mainUI)
        MyBase.New(myUI)
        InitializeComponent()

    End Sub

    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            If m_activeItem IsNot Nothing Then
                Return m_activeItem.ReplikID
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem
        If m_activeItem IsNot Nothing Then
            If AskDeleteData() = DialogResult.Yes Then
                m_activeItem.Delete()
                ClearControls()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Ruft ein kleines Bild ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get
            Return My.Resources.Notepad_16x16

        End Get
    End Property

End Class