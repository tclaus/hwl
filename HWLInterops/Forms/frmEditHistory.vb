Imports ClausSoftware.Kernel

''' <summary>
''' Stellt einen Dialog bereit, der einen History-Eintrag bereit
''' </summary>
''' <remarks></remarks>
Public Class frmEditHistory


    Private m_historyItem As AddressHistoryItem


    ''' <summary>
    ''' Legt das aktuelle Verlaufs-element fest, das in diesem Dialog bearbeitet werden soll
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HistoryItem() As Kernel.AddressHistoryItem
        Get
            Return m_historyItem
        End Get
        Set(ByVal value As Kernel.AddressHistoryItem)
            m_historyItem = value

            FillItem()

        End Set
    End Property

    ''' <summary>
    ''' Füllt einen History-Eintrag in die 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillItem()
        txtComment.Text = m_historyItem.Text
        cobCategory.SelectedItem = m_historyItem.Category
        lblCreatedAtText.Text = m_historyItem.ItemDate.ToString("d")
        lblCreatedByText.Text = m_historyItem.CreatedBy.ToString
        chkSystemCreated.Checked = m_historyItem.IsSystemMessage
        Me.Text = m_application.Languages.GetText("HistoryDialogHeader", "Verlauf ({0}})", m_historyItem.Adress.ToString)


    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        m_historyItem.Text = txtComment.Text

        ' Freitext als neue Kategorie anlegen
        If TypeOf cobCategory.SelectedItem Is String Then
            m_historyItem.Category = HistoryCategories.FindHistoryCategory(CStr(cobCategory.EditValue), True)
            cobCategory.Properties.Items.Add(m_historyItem.Category)
        End If

        If TypeOf cobCategory.SelectedItem Is HistoryCategory Then
            m_historyItem.Category = CType(cobCategory.SelectedItem, HistoryCategory)
        End If


        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cobCategory_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cobCategory.ButtonClick
        If TypeOf e.Button.Tag Is String Then
            If CStr(e.Button.Tag) = "edit" Then
                Dim frm As New frmSimpleEdit(Kernel.DataSourceList.HistoryCategories)
                frm.ShowDialog()
                cobCategory.Properties.Items.Clear()
                cobCategory.Properties.Items.AddRange(m_application.HistoryCategories)

                cobCategory.SelectedItem = m_historyItem.Category

            End If
        End If
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()


    End Sub

    Private Sub cobCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobCategory.SelectedIndexChanged

    End Sub

    Private Sub frmEditHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Languages.SetTextOnControl(Me)

        m_application.HistoryCategories.GetTransactionCategory() ' Zumindest eine Kategorie erzwingen
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        cobCategory.Properties.Items.Clear()
        cobCategory.Properties.Items.AddRange(m_application.HistoryCategories)
        cobCategory.SelectedItem = m_historyItem.Category

        FillItem()

    End Sub

    Private Sub frmEditHistory_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown



    End Sub

    Private Sub txtComment_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtComment.DragDrop
        DragDropHelper.SetText(sender, e)

    End Sub

    Private Sub txtComment_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtComment.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub
End Class
