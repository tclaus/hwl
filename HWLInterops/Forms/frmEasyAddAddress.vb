''' <summary>
''' Stellt ein Formular zur Verfügung, das die schnelle Aufnahme einer Adresse ermöglicht
''' </summary>
''' <remarks></remarks>
Public Class frmEasyAddAddress

    Private m_hasChanged As Boolean

    Private m_newAddress As Kernel.Adress

    ''' <summary>
    ''' Ruft das neue Adressobjekt ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Address() As Kernel.Adress
        Get
            Return m_newAddress
        End Get
        Set(ByVal value As Kernel.Adress)
            m_newAddress = value
        End Set
    End Property

    Public Property HasChanged() As Boolean
        Get
            Return m_hasChanged
        End Get
        Set(ByVal value As Boolean)
            m_hasChanged = value
        End Set
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SAveAsNewAddress()
    End Sub


    Private Sub SAveAsNewAddress()
        m_newAddress = MainApplication.getInstance.Adressen.GetNewItem
        m_newAddress.Company = txtCompany.Text
        m_newAddress.FirstName = txtFirstName.Text
        m_newAddress.LastName = txtLastName.Text

        m_newAddress.Street = txtStreet.Text
        m_newAddress.ZipCode = txtZipCode.Text
        m_newAddress.Town = txtTown.Text

        Dim result As DialogResult


        'result = MessageBox.Show("Möchten Sie die Adresse:" & vbCrLf & _
        '                m_newAddress.InvoiceAdressWindow & vbCrLf & vbCrLf & _
        '                "Zur Adressliste hinzufügen?", "Adresse hinzufügen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)


        result = MessageBox.Show(GetText("AskAddNewAddress", "Möchten Sie die Adresse: /n {0} /n" &
                        " zur Adressliste hinzufügen?", m_newAddress.InvoiceAdressWindow), GetText("AskAddAddress", "Adresse hinzufügen"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If result = Windows.Forms.DialogResult.Yes Then
            m_newAddress.Save()
            MainApplication.getInstance.Adressen.Add(m_newAddress)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
            Exit Sub
        End If

        If result = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If


        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()


    End Sub

    Private Sub txtCompany_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZipCode.TextChanged, txtTown.TextChanged, txtStreet.TextChanged, txtFirstName.TextChanged, txtCompany.TextChanged, txtLastName.TextChanged
        Me.HasChanged = True
    End Sub

    Private Sub frmEasyAddAddress_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.HasChanged = False
    End Sub

    Private Sub Text_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtZipCode.DragEnter, txtTown.DragEnter, txtStreet.DragEnter, txtFirstName.DragEnter, txtCompany.DragEnter, txtLastName.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub

    Private Sub text_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtZipCode.DragDrop, txtTown.DragDrop, txtStreet.DragDrop, txtFirstName.DragDrop, txtCompany.DragDrop, txtLastName.DragDrop
        DragDropHelper.SetText(sender, e)
    End Sub
End Class