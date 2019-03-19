Imports ClausSoftware.Kernel
Imports DevExpress.XtraEditors.Controls

''' <summary>
''' Stellt ein Dialog zur verfügung für das schnelle Eingeben eines Artikels
''' </summary>
''' <remarks></remarks>
Friend Class frmQuickArticleAdd


    Private m_article As Article

    ''' <summary>
    ''' Ruft den aktuell bearbeiteten Artikel ab oder legt diesen fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Material() As Article
        Get
            Return m_article
        End Get
        Set(ByVal value As Article)
            m_article = value

            txtDescription.Text = value.LongDescription
            txtName.Text = value.ShortDescription
            txtEAN.Text = value.EAN

            txtPreisEK.Text = CStr(value.EinzelEK)
            txtPreisVK.Text = CStr(value.EinzelVK)

        End Set
    End Property







    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Material.ShortDescription = txtName.Text
        Material.LongDescription = txtDescription.Text
        Material.VerpackungsEinheit = CType(cobUnit.SelectedItem, Unit)
        Material.Recheneinheit = Material.VerpackungsEinheit
        Material.MinDeliveryCount = 1
        Material.EinzelEK = CDec(txtPreisEK.Text)
        Material.EAN = txtEAN.Text
        Material.MinSellCount = 1
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmQuickArticleAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillUnitList()
    End Sub

    ''' <summary>
    ''' Füllt eine auswahlliste mit Einheiten
    ''' </summary>
    ''' <remarks></remarks>
    Sub FillUnitList()
        Dim Coll As ComboBoxItemCollection = cobUnit.Properties.Items
        Coll.BeginUpdate()
        Try
            For Each unit As ClausSoftware.Kernel.Unit In m_application.Units
                Coll.Add(unit)
            Next
        Finally
            Coll.EndUpdate()
        End Try

    End Sub
End Class