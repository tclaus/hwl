Imports ClausSoftware.Kernel.Attributes
Imports ClausSoftware.Kernel

Public Class frmArticleAttributes

    Private m_selectedClass As ClassDefinition
    

    ''' <summary>
    ''' Ruft die aktive Attributeklasse ab oder setzt diese
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ActiveAttributeClass() As ClassDefinition
        Get
            Return m_selectedClass
        End Get
        Set(ByVal value As ClassDefinition)
            value.Reload()
            m_selectedClass = value
            lblAttributeDefinitionHeadline.Text = GetText("lblAttributeDefinitionHeadline", "Definitionen der Attribute für die Gruppe: ""{0}""", value.Group.Name)

            FillAttributesList()
        End Set
    End Property

    
    Private Sub frmArticleAttributes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MainApplication.getInstance IsNot Nothing Then
            MainApplication.getInstance.Settings.SaveFormsPos(Me)
        End If
    End Sub



    Private Sub frmArticleAttributes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        modmain.InitializeApplication()


        'Die comboboxen aufbauen 
        repCboItemType.Items.AddRange([Enum].GetValues(GetType(ClausSoftware.enumAttributeType)))
        MainApplication.getInstance.Languages.SetTextOnControl(Me)

        MainApplication.getInstance.Settings.RestoreFormsPos(Me)

    End Sub




    ''' <summary>
    ''' erstellt eine neue Gruppe
    ''' </summary>
    ''' <param name="parentclass"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AddNewClass(ByVal parentclass As ClassDefinition) As ClassDefinition

        Dim newClass As ClassDefinition = MainApplication.getInstance.ClassDefinitions.GetNewItem


        If parentclass IsNot Nothing Then
            newClass.ParentGroupID = parentclass.Key
        Else
            newClass.ParentGroupID = Groups.RootID
        End If
        newClass.Name = GetText("msgNewArticleClassName", "Neue Klasse")

        newClass.Save()

        MainApplication.getInstance.ClassDefinitions.Add(newClass)

        Return newClass
    End Function


    Sub FillAttributesList()
        If m_selectedClass IsNot Nothing Then

            grdValueDefinition.DataSource = m_selectedClass.ValueDefinitions
        Else
            grdValueDefinition.DataSource = Nothing
        End If


    End Sub

    ''' <summary>
    ''' Fügt ein neues attribut hinzu
    ''' </summary>
    ''' <remarks></remarks>
    Sub AddAttributeOnCurrentClass()
        Dim newAttribute As AttributeValueDefinition = New AttributeValueDefinition(MainApplication.getInstance.Session)
        newAttribute.AttributeName = GetText("msgNewArticleAttributeValueName", "neuer Wert")


        m_selectedClass.Add(newAttribute)

        grvValueDefinition.FocusedRowHandle = grvValueDefinition.RowCount - 1
        grvValueDefinition.FocusedColumn = grvValueDefinition.Columns(0)

        grvValueDefinition.ShowEditor()
    End Sub

    ''' <summary>
    ''' Speichert alle Klassendefinitionen ab
    ''' </summary>
    ''' <remarks></remarks>
    Sub Save()
        m_selectedClass.Save()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Save()
        Me.Close()
    End Sub

    ''' <summary>
    ''' Löscht den selektierten eintrag, sofern noch nicht in einem Artikel verwendet
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteSelected()
        ' Kann vom Artikel verwendet woden sein 
        ' Dann fragem ob auch alle Artikel diese Definition entzogen wird? 


        If grvValueDefinition.GetSelectedRows().Length > 0 Then
            Dim itemsToDelete As New List(Of Attributes.AttributeValueDefinition)

            For Each item As Integer In grvValueDefinition.GetSelectedRows

                Dim itemdef As Attributes.AttributeValueDefinition = CType(grvValueDefinition.GetRow(item), AttributeValueDefinition)
                itemsToDelete.Add(itemdef)
            Next

            For Each itemdef As Attributes.AttributeValueDefinition In itemsToDelete
                If itemdef.IsInUse() Then

                    Dim captionText As String = GetText("headTextDeleteAttributeDefinition", "Definition löschen")
                    Dim mainText As String = GetText("mainTextDeleteAttributeDefinition", "Dieses Sachmerkmal ({0}) findet bereits Verwendung in mindestends einem Artikel. " & vbCrLf _
                                                     & "Möchten Sie die Definition und alle wertzuweisungen dennoch löschen?", itemdef.AttributeName)


                    Dim result As DialogResult = MessageBox.Show(mainText, captionText, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)

                    If result = Windows.Forms.DialogResult.Yes Then
                        itemdef.Delete()
                    End If

                    If result = Windows.Forms.DialogResult.Cancel Then Exit Sub ' Abwürgen, die Schleife verlassen

                Else
                    ' einfach löschen, ohne Nachfrage, da offentsichtlich noch nie verwendet!
                    itemdef.Delete()

                End If

            Next
        End If


    End Sub

    Private Sub grvValueDefinition_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvValueDefinition.FocusedRowChanged
        Dim item As Object = grvValueDefinition.GetRow(e.FocusedRowHandle)

    End Sub

    Private Sub grvValueDefinition_InitNewRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grvValueDefinition.InitNewRow
        grvValueDefinition.FocusedRowHandle = e.RowHandle

        Dim newItem As AttributeValueDefinition = CType(grvValueDefinition.GetRow(e.RowHandle), AttributeValueDefinition)
        newItem.AttributeClassID = Me.ActiveAttributeClass.Key


    End Sub

    Private Sub repCboItemType_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repCboItemType.ButtonClick
        If e.Button.Index = 1 Then
            ' Dann war es der extra-Button 
            Dim item As AttributeValueDefinition = CType(grvValueDefinition.GetFocusedRow, AttributeValueDefinition)
            Dim frm As New frmAttributesMultiSelecteditor
            frm.SelectedProfile = item.MultiselectProfile
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                item.MultiselectProfile = frm.SelectedProfile
                item.Save()
            End If

        End If
    End Sub

    Private Sub repcboType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles repCboItemType.SelectedValueChanged
        Dim cbo As DevExpress.XtraEditors.ComboBoxEdit = CType(sender, DevExpress.XtraEditors.ComboBoxEdit)
        Dim value As enumAttributeType = CType(cbo.SelectedItem, enumAttributeType)
        If value = enumAttributeType.ChooseOne Or value = enumAttributeType.ChooseSome Then
            cbo.Properties.Buttons(1).Visible = True
            ' extra-Button einblenden, damit kann eine auswahl zugewiesen werden
        Else
            ' Zusatz-Button entfernen
            cbo.Properties.Buttons(1).Visible = False

        End If

    End Sub

    ''' <summary>
    ''' Bereits verwendete Attribute dürfen den Typ nicht mehr ändern!
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckAttributesInUse()
        ' Dann ist die Typ-Spalte zu sperren
        ' Bei Attributen, die vererbt urden dar der Name auch nicht geäbndert werden
        ' Oder anzeigen lassen ? 
        For n As Integer = 0 To grvValueDefinition.RowCount - 1

        Next


    End Sub

    Private Sub grvValueDefinition_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grvValueDefinition.RowCellStyle

        Dim item As AttributeValueDefinition = CType(grvValueDefinition.GetRow(e.RowHandle), AttributeValueDefinition)
        If item IsNot Nothing Then
            If item.AttributeClassID <> m_selectedClass.Key Then
                'dann die Spalte nicht editierbar machen 
                e.Appearance.BackColor = Color.LightGray
            End If
        End If
    End Sub

    Private Sub grvValueDefinition_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grvValueDefinition.ShowingEditor
        Dim item As AttributeValueDefinition = CType(grvValueDefinition.GetRow(grvValueDefinition.FocusedRowHandle), AttributeValueDefinition)

        If item IsNot Nothing Then
            If item.AttributeClassID <> m_selectedClass.Key Then
                'dann die Spalte nicht editierbar machen 
                e.Cancel = True
                Exit Sub
            End If

            If item.IsInUse Then

                ' dann darf der Typ nicht mehr geändert werden
                'If grvValueDefinition.FocusedColumn.Name = "colAttributeType" Then
                '    e.Cancel = True
                '    'TODO: Tooltip und auf das Problem hinweisen 
                '    Exit Sub
                'End If
            End If

            

        End If
    End Sub

 



    Private Sub grvValueDefinition_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvValueDefinition.ShownEditor
        If grvValueDefinition.FocusedColumn.Name = "colAttributeType" Then

            ' Falls der editor eingeschaltet werden soll, dann nun hier den extra-Button anzeigen lassen
            Dim cbo As DevExpress.XtraEditors.ComboBoxEdit = CType(grvValueDefinition.ActiveEditor, DevExpress.XtraEditors.ComboBoxEdit)

            Dim value As enumAttributeType = CType(cbo.SelectedItem, enumAttributeType)
            If value = enumAttributeType.ChooseOne Or value = enumAttributeType.ChooseSome Then
                cbo.Properties.Buttons(1).Visible = True
                ' extra-Button einblenden, damit kann eine auswahl zugewiesen werden
            Else
                ' Zusatz-Button entfernen
                cbo.Properties.Buttons(1).Visible = False

            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteSelected()
    End Sub

    Private Sub grdValueDefinition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdValueDefinition.KeyDown
        If e.KeyCode = Keys.Delete Then
            DeleteSelected()
        End If
    End Sub

End Class