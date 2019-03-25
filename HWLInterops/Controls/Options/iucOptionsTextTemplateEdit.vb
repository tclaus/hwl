
Imports ClausSoftware.Tools
Imports ClausSoftware.Kernel

''' <summary>
''' Stellt einen Dialog für die Steuersätze zur Verfügung
''' </summary>
''' <remarks></remarks>
Public Class iucOptionsTextTemplateEdit
    Implements IOptionMenue



    'Please enter any new code here, below the Interop code

    Public Sub Initialize() Implements IOptionMenue.Initialize
        Try

            FillGrid()

        Catch ex As Exception

            Debug.Print(ex.Message)
        End Try

    End Sub



    ''' <summary>
    ''' Füllt die Liste der Steuern auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillGrid()


        grdTextTemplates.DataSource = MainApplication.getInstance.TextTemplates


    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim newText As TextTemplate = MainApplication.getInstance.TextTemplates.GetNewItem
        newText.Text = "<Text>" 'TODO: NLS

        newText.Save()
        MainApplication.getInstance.TextTemplates.Add(newText)

        Dim tempKey As String = newText.Key

        FillGrid()

        For n As Integer = 0 To grvTextTemplates.RowCount - 1
            If CType(grvTextTemplates.GetRow(n), TextTemplate).Key = tempKey Then
                grvTextTemplates.FocusedRowHandle = n
                grvTextTemplates.SelectRow(n)

                Exit For
            End If
        Next


    End Sub



    Private Sub iucTaxes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Languages.SetTextOnControl(Me)
        Initialize()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        'TODo: NLS
        If MessageBox.Show("Möchten Sie den ausgewählten Text  löschen?", "Textbaustein löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                Dim toDelete As TextTemplate = CType(grvTextTemplates.GetRow(grvTextTemplates.FocusedRowHandle), TextTemplate)
                If toDelete IsNot Nothing Then
                    toDelete.Delete()
                    FillGrid()
                    ' Steuersätze können nun noch in anderen Dokumenten vorkommen; welcher soll nun genommen wwerden? 
                End If

            Catch
            End Try



        End If
    End Sub

    Private m_activeText As TextTemplate

    Public Property ActiveText() As TextTemplate
        Get
            Return m_activeText
        End Get
        Set(ByVal value As TextTemplate)
            m_activeText = value
        End Set
    End Property


    Private Sub GridView1_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvTextTemplates.FocusedRowChanged
        Dim text As TextTemplate = CType(grvTextTemplates.GetFocusedRow, TextTemplate)
        m_activeText = text

        If text IsNot Nothing Then
            txtedit.EditValue = text.Text
        End If



    End Sub


    Public Sub Reload() Implements IOptionMenue.Reload
        MainApplication.getInstance.TextTemplates.Reload()
        FillGrid()
    End Sub

    Public Sub Save() Implements IOptionMenue.Save
        MainApplication.getInstance.TextTemplates.Save()
    End Sub

    Public Overrides Function ToString() As String
        Return Me.DisplayName
    End Function

    Public ReadOnly Property DisplayName() As String Implements IOptionMenue.DisplayName
        Get
            Return GetText("optionTextTemplates", "Textbausteine")
        End Get

    End Property

    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False
        End Get
    End Property


    Private Sub txtedit_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtedit.EditValueChanged
        If Me.ActiveText IsNot Nothing Then
            Me.ActiveText.Text = txtedit.Text
        End If

    End Sub

    Private Sub btnshowTextfieldPlaceholders_Click(sender As System.Object, e As System.EventArgs) Handles btnshowTextfieldPlaceholders.Click
        Dim str As String = ""

        For Each item As KeyValuePair(Of String, String) In JournalDocument.GetReplacementStringsTextblocks
            str &= item.Key & ", " & item.Value & vbCrLf
        Next

        MessageBox.Show(str, GetText("PlaceHoldersInTextfields", "Ersetzungen Textbausteinen"), MessageBoxButtons.OK)
    End Sub

    Private Sub grvTextTemplates_SelectionChanged(sender As System.Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles grvTextTemplates.SelectionChanged

        ' Wenn nichts selektiert ist, dann das Löschen unterdrücken
        If grvTextTemplates.GetSelectedRows.Length = 0 Then
            btnDelete.Enabled = False
        Else
            btnDelete.Enabled = True

        End If
    End Sub
End Class