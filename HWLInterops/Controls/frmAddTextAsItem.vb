Imports DevExpress.XtraTreeList
Imports ClausSoftware.Kernel
Imports DevExpress.XtraTreeList.Nodes

''' <summary>
''' Stellt einen  Dialog zur Verfügung, der eine Artikel-Gruppenausdwahl bereitstellt.
''' </summary>
''' <remarks></remarks>
Public Class frmAddTextAsItem


    Private m_Article As JournalArticleItem

    ''' <summary>
    ''' Legt den Namen der Grideinstellung fest
    ''' </summary>
    ''' <remarks></remarks>
    Private m_contextstring As String = "MainArticleGrid"

    ''' <summary>
    ''' Ruft den zu importierenden Artikel ab oder legt diesen fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SimpleArticle() As JournalArticleItem
        Get
            Return m_Article
        End Get
        Set(ByVal value As JournalArticleItem)
            m_Article = value
        End Set
    End Property


    Private Sub frmAddTextAsItem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillGroups(trvArticleGroups)
        m_application.Languages.SetTextOnControl(Me)


    End Sub

    ''' <summary>
    ''' Fügt den Artikel zur aktuell gewählten Gruppe hinzu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddToSelectedArticle()
        Dim targetGroup As Group

        If trvArticleGroups.FocusedNode IsNot Nothing And SimpleArticle IsNot Nothing Then
            targetGroup = CType(trvArticleGroups.GetDataRecordByNode(trvArticleGroups.FocusedNode), Group)



            Dim newArticle As Article = m_application.ArticleList.GetNewItem
            newArticle.ShortDescription = SimpleArticle.ItemName
            newArticle.LongDescription = SimpleArticle.ItemMemoText
            newArticle.EinzelVK = SimpleArticle.SinglePriceBeforeTax
            newArticle.TaxRate = SimpleArticle.TaxRate
            newArticle.EinzelEK = SimpleArticle.BasePrice

            'TODO: Weitere Parameter übergeben ? 

            newArticle.Group = targetGroup
            newArticle.Save()

            ' ID dem Artikel wieder zuweisen
            SimpleArticle.OrgItemID = newArticle.ID & "M"


            ' Bei Focuswechsel die markierung speichern
            Dim group As Group = CType(trvArticleGroups.GetDataRecordByNode(trvArticleGroups.FocusedNode), ClausSoftware.Kernel.Group)
            m_application.Settings.SetSetting("SelectedArticleGroup", Tools.RegistrySections.ModuleArticles, group.Key)


        End If

    End Sub


    ''' <summary>
    ''' Füllt die LIste der Gruppen neu
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillGroups(ByVal trvGroups As TreeList)

        m_application.Groups.Reload()


        Dim groups As ClausSoftware.Kernel.Groups = m_application.Groups
        trvGroups.BeginUpdate()

        trvGroups.ParentFieldName = "ParentID"
        trvGroups.KeyFieldName = "ReplikID"
        trvGroups.DataSource = groups
        trvGroups.EndUpdate()

        'Alle geöffneten Nodes wieder herstellen
        RestoreTreeOpenNodes(trvGroups, m_contextstring)

        Dim lastselecedGroup As String = m_application.Settings.GetSetting("SelectedArticleGroup", ClausSoftware.Tools.RegistrySections.ModuleArticles, "0000")
        Dim selecedNode As TreeListNode = trvGroups.FindNodeByKeyID(lastselecedGroup)
        If selecedNode IsNot Nothing Then
            trvGroups.FocusedNode = selecedNode
            selecedNode.Selected = True
            selecedNode.Selected = True
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        AddToSelectedArticle()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFolder.Click
        CreateNewFolder()
    End Sub


    Private Sub CreateNewFolder()
        Dim newGroup As Group

        If trvArticleGroups.FocusedNode IsNot Nothing AndAlso TypeOf trvArticleGroups.GetDataRecordByNode(trvArticleGroups.FocusedNode) Is Group Then

            newGroup = CreateNewGroup(CType(trvArticleGroups.GetDataRecordByNode(trvArticleGroups.FocusedNode), Group))
        Else
            newGroup = CreateNewGroup(Nothing)
        End If


        Dim newNode As Nodes.TreeListNode = trvArticleGroups.FindNodeByKeyID(newGroup.Key)
        trvArticleGroups.FocusedNode = newNode


        StarteditingFocusedNode()
    End Sub

    ''' <summary>
    ''' Fügt einer gegebenen Gruppen-Objet eine neue Gruppe hinzu und gibt das Treenode zurück
    ''' </summary>
    ''' <param name="ParentGroup">Die eltern-Gruppe oder nothing, falls eine Stammgrupppe hinzgefügt werden soll</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateNewGroup(ByVal parentGroup As Group) As Group

        Dim newGroup As Group = m_application.Groups.GetNewItem


        If parentGroup IsNot Nothing Then
            newGroup.ParentID = parentGroup.Key
        Else
            newGroup.ParentID = Groups.RootID
        End If
        newGroup.Name = GetText("NewArticleGroupName", "Neue Gruppe")
        newGroup.Save()

        m_application.Groups.Add(newGroup)

        Return newGroup
    End Function

    Private Sub StarteditingFocusedNode()
        If Not trvArticleGroups.FocusedNode Is Nothing Then
            trvArticleGroups.Columns(0).OptionsColumn.AllowEdit = True
            trvArticleGroups.ShowEditor()

        End If
    End Sub


End Class
