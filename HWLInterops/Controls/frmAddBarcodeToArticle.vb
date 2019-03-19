Imports DevExpress.Xpo

''' <summary>
''' Enthält ein formular,das per Barcode-Scanner einen Artikel anhand der EAN-Code sucht und anzeigt.
''' Der Anwender kann dann eine Zuweisung vornehmen
''' </summary>
''' <remarks></remarks>
Public Class frmAddBarcodeToArticle


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    

    Private Sub frmAddBarcodeToArticle_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        GroupsGridBox.Context = "Barcode"
        GroupsGridBox.Initialize()

    End Sub

    Private Sub IucSearchPanel1_SearchTextChanged(ByVal sender As Object, ByVal e As SearchTextEventArgs) Handles SearchPanelEAN.SearchTextChanged
        Dim Text As String = e.Text

        Dim eanArticle As New ClausSoftware.Kernel.Articles(m_application)
        eanArticle.CriteriaString = "EAN='" & text & "'"

        ' Zuweisen nur möglich, wenn auch ein Barcode existiert
        If text.Length > 0 Then
            btnAssign.Enabled = True
        Else
            btnAssign.Enabled = False
        End If

        lblSearchResult.Text = ""

        If eanArticle.Count = 0 Then
            ' existiert nicht
            lblSearchResult.Text = "-NICHT GEFUNDEN-"

        End If

        If eanArticle.Count = 1 Then
            ' Genau einen Artikel gefunden
            lblSearchResult.Text = eanArticle(0).ToString()
        End If

        If eanArticle.Count > 1 Then
            'Konflikt
            lblSearchResult.Text = "-Mehr als ein Artikel gefunden-"
        End If

        SearchPanelEAN.txtSearchText.SelectAll()
        SearchPanelEAN.txtSearchText.Focus()

    End Sub

    Private Sub LabelControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim newArticleForm As New frmQuickArticleAdd


        Dim newArticle As ClausSoftware.Kernel.Article = m_application.ArticleList.GetNewItem

        'den neuen Artikel der aktuell selektierten Grupppe zuweisen
        newArticle.GroupID = GroupsGridBox.SelectedGroupID
        newArticle.EAN = SearchPanelEAN.Text
        newArticleForm.Material = newArticle
        If newArticleForm.ShowDialog = Windows.Forms.DialogResult.OK Then
            m_application.ArticleList.Add(newArticle)
            newArticle.Save()
        End If

        SearchPanelEAN.txtSearchText.Focus()


    End Sub

    Private Sub SearchPanelArticles_SearchTextChanged(ByVal sender As Object, ByVal e As SearchTextEventArgs) Handles SearchPanelArticles.SearchTextChanged
        GroupsGridBox.SetSearchParameter(e.Text)
    End Sub

    Private Sub GroupsGridBox_ItemRowDoubleClick(ByVal key As System.String) Handles GroupsGridBox.ItemRowDoubleClick
        ' wurde auf ein Artikel ein doppelklick ausgeführt, dann diesen den EAN-Code zuweisen
        If Not String.IsNullOrEmpty(key) Then
            If key.Length > 0 Then
                AssignArticleToBarcode(key, SearchPanelEAN.Text)
            End If
        End If

    End Sub

    ''' <summary>
    ''' Einem Artikel den Barcode zuweisen
    ''' </summary>
    ''' <param name="articleKey"></param>
    ''' <param name="ean"></param>
    ''' <remarks></remarks>
    Sub AssignArticleToBarcode(ByVal articleKey As String, ByVal ean As String)

        ' Prüfe, ob dann doppelte möglicbh wären
        Dim eanArticle As New ClausSoftware.Kernel.Articles(m_application)
        eanArticle.CriteriaString = "EAN='" & ean & "'"
        If eanArticle.Count > 0 Then
            Dim result As DialogResult

            result = MessageBox.Show("Es existiert bereits mindestends ein Artikel mit dieser EAN-Nummer." & vbCrLf & _
                            "Möchten Sie den neuen Artikel dieser Nummer zuweisen und die EAN-Nummern der anderen Artikel löschen?", _
                             "Artikel mit der selben EAN gefunden", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            If result = Windows.Forms.DialogResult.Cancel Then Exit Sub

            If result = Windows.Forms.DialogResult.Yes Then
                ' die anderen EAN suchen und entfernen
                For Each oldArticle As ClausSoftware.Kernel.Article In eanArticle
                    oldArticle.EAN = ""
                    oldArticle.Save()

                Next

            End If
        End If
        ' neue EAN zuweisen
        Dim article As ClausSoftware.Kernel.Article
        article = m_application.ArticleList.GetItem(articleKey)
        article.EAN = SearchPanelEAN.Text
        article.Save()

        'dies nun nochmal anzeigen lassen: 
        Dim tmpText As String = SearchPanelEAN.Text
        SearchPanelEAN.Text = ""
        SearchPanelEAN.Text = tmpText

    End Sub

    Private Sub btnAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        If SearchPanelEAN.Text.Length > 0 And GroupsGridBox.SelectedArticelID.Length > 0 Then
            AssignArticleToBarcode(GroupsGridBox.SelectedArticelID, SearchPanelEAN.Text)
        End If

        SearchPanelEAN.txtSearchText.Focus()

    End Sub

    Private Sub frmAddBarcodeToArticle_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        SearchPanelEAN.Focus()
    End Sub
End Class