Option Explicit On
Option Strict On

Imports System.Windows.Forms
Imports System.Drawing


Public Class frmDatanormImport

    Private m_importer As ImporterController
    Private m_fileList As New List(Of SingleFile)

    ''' <summary>
    ''' Stellt das Check-Symbol bereit
    ''' </summary>
    ''' <remarks></remarks>
    Private okImage As Image = My.Resources.Symbol_Check

    Public Sub New(ByVal controller As ImporterController)
        InitializeComponent()

        m_importer = controller
        AddHandler m_importer.ReadLineNumber, AddressOf SetLineNumber
        AddHandler m_importer.EndReading, AddressOf EndReading
        AddHandler m_importer.Message, AddressOf SetMessage

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnNextImportStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextImportStep.Click

        If m_importer.IsRunning Then
            m_importer.CancelImport()
            btnNextImportStep.Text = "Start" 'TODo: NLS

        Else

            btnNextImportStep.Text = "Abbrechen" 'TODo: NLS

            prgCurrentLine.Visible = True
            m_importer.StartImportAsync()
        End If



    End Sub

    Private Sub btnAddFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFile.Click

        lblDatanormDescription.Text = ""

        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.FileName = lblSelectDatasourceFile.Text
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            For Each fn As String In OpenFileDialog1.FileNames
                If System.IO.File.Exists(fn) Then

                    m_fileList.Add(New SingleFile(fn))
                End If
            Next
            btnNextImportStep.Enabled = True
        End If

        '   lblDatanormDescription.Text = m_importer.GetFirstLine(fn)

        m_fileList.Sort(New SortByextenstion)

        lstFileList.Refresh()

    End Sub

    ''' <summary>
    ''' Entfernt die selektierten Zeilen aus der Auflistung
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveSelectedFile()
        lstFileList.BeginUpdate()

        ' Liste erstellen mit den Teilen, die zu entfernen sind
        Dim lst As New List(Of SingleFile)
        For Each item As Object In lstFileList.SelectedItems
            lst.Add(CType(item, SingleFile))
        Next

        ' Diese nun entfernen
        For Each item As SingleFile In lst
            m_fileList.Remove(item)
        Next

        lstFileList.EndUpdate()
        lstFileList.Refresh()
    End Sub

    Delegate Sub setMessageDelegate(sender As Object, e As MessageEventArgs)
    Private messageDele As New setMessageDelegate(AddressOf SetMessage)

    Private Sub SetMessage(sender As Object, e As MessageEventArgs)
        If Me.InvokeRequired Then
            Me.BeginInvoke(messageDele, New Object() {sender, e})
            Exit Sub
        End If

        lblImportProgress.Text = e.Message
        lblImportProgress.Refresh()
    End Sub


    Delegate Sub setLineNumberDelegate(ByVal sender As Object, ByVal e As LineNumerEventArgs)
    Private dele As New setLineNumberDelegate(AddressOf SetLineNumber)

    Private Sub SetLineNumber(ByVal sender As Object, ByVal e As LineNumerEventArgs)
        Static LastUpdate As Integer

        If LastUpdate = Now.Millisecond / 200 Then Exit Sub
        ' die hunderststel laufen weiter; alle 100ms den zwischenspeicher aktualisieren 
        LastUpdate = CInt(Now.Millisecond / 200)


        ' Kann Threaded aufgerufen werden
        If Me.InvokeRequired Then

            Me.Invoke(dele, New Object() {sender, e})
            Exit Sub
        End If


        prgCurrentLine.Properties.Maximum = CInt(e.MaxLineNumber)
        prgCurrentLine.EditValue = e.LineNumber

        prgCurrentLine.Refresh()
        If Not lblImportProgress.Visible Then lblImportProgress.Visible = True

        lblImportProgress.Text = CInt(100 * (e.LineNumber / e.MaxLineNumber)) & "%  " & e.LineNumber & "/" & e.MaxLineNumber
        lblImportProgress.Refresh()

    End Sub

    ''' <summary>
    ''' Wenn der Einlesevorgang beendet wurde, wird die Oberfläche wieder zurückgesetzt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EndReading(sender As Object, e As EventArgs)
        AfterReading()
    End Sub

    Delegate Sub AfterReadingDele()
    Private m_AfterReading As New AfterReadingDele(AddressOf AfterReading)

    ''' <summary>
    ''' Stellt nach dem Einlesen die Oberfläche wieder her
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AfterReading()
        If Me.InvokeRequired Then

            Me.Invoke(m_AfterReading)
            Exit Sub
        End If


        '  MessageBox.Show("Einlesen der Datei beendet", "Einlesen beendet", MessageBoxButtons.OK, MessageBoxIcon.Information)
        btnNextImportStep.Text = "Start"
        lblImportProgress.Text = "0/0"
        prgCurrentLine.EditValue = 0I
        lstFileList.Refresh()

    End Sub

    Private Sub frmDatanormImport_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'TODO:  Letzes Verzeichnis / Datei auswählen lassen 
        lstFileList.DataSource = m_fileList
        m_importer.Filenames = m_fileList

    End Sub

    Private Sub btnRemoveFile_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveFile.Click
        RemoveSelectedFile()
    End Sub

    Private Sub lstFileList_DrawItem(sender As System.Object, e As DevExpress.XtraEditors.ListBoxDrawItemEventArgs) Handles lstFileList.DrawItem
        ' Rechts soll ein "OK" - Icon erscheinen, wenn die Datei geladen wurde

        Dim backBrush1 As New SolidBrush(Color.FromArgb(255, 255, 255))  ' Weiß
        Dim backBrush2 As New SolidBrush(Color.FromArgb(237, 237, 237))   ' Helles Grau
        Dim backBrush3 As New SolidBrush(Color.FromArgb(220, 235, 252))     ' Selektionsfarbe 

        ' declare field representing the text of the item being drawn
        Dim itemText As String
        itemText = lstFileList.GetItemText(e.Index)
        Dim lineItem As SingleFile


        If Not (e.State And DrawItemState.Selected) = 0 Then
            e.Cache.FillRectangle(backBrush3, e.Bounds)
            ControlPaint.DrawBorder3D(e.Graphics, e.Bounds)
            e.Cache.DrawString(itemText, New Font(e.Appearance.Font.Name, e.Appearance.Font.Size, _
              FontStyle.Bold), New SolidBrush(Color.Black), e.Bounds, e.Appearance.GetStringFormat())

            ' Das Icon drüber malen 
            lineItem = CType(e.Item, SingleFile)
            If lineItem.Loaded Then
                ' Icon an der rechten seite malen
                Dim rightSidePoint As New Point(e.Bounds.X + e.Bounds.Width - 20, e.Bounds.Y + 1)
                e.Cache.Graphics.DrawImage(okImage, rightSidePoint)
            End If

            e.Handled = True
            Exit Sub
        End If

        'In abwechselnden Grautönen ? 
        If e.Index Mod 2 = 0 Then
            e.Cache.FillRectangle(backBrush1, e.Bounds)
        Else
            e.Cache.FillRectangle(backBrush2, e.Bounds)
        End If

        ' Text malen 
        e.Cache.DrawString(itemText, e.Appearance.Font, New SolidBrush(Color.Black), e.Bounds, e.Appearance.GetStringFormat())


        ' Das Icon drüber malen 
        lineItem = CType(e.Item, SingleFile)
        If lineItem.Loaded Then
            ' Icon an der rechten seite malen
            Dim rightSidePoint As New Point(e.Bounds.X + e.Bounds.Width - 20, e.Bounds.Y + 1)
            e.Cache.Graphics.DrawImage(okImage, rightSidePoint)
        End If

        e.Handled = True

    End Sub
End Class


