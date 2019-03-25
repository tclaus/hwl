Imports DevExpress.Xpo
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Data.Filtering
Imports ClausSoftware.Kernel
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports ClausSoftware.Data
Imports DevExpress.XtraGrid.Views.Grid

''' <summary>
''' enthält einen vereinfachten Auswahldialog, mit dem einafch Daten aus verschiedenen Quellen gesucht werden können
''' </summary>
''' <remarks></remarks>
Public Class frmSmallItemChooser

    Private WithEvents m_serverModeDS As XPServerCollectionSource

    Private m_session As Session = MainApplication.getInstance.Session

    Private m_selectedItem As ClausSoftware.Data.StaticItem

    Private m_internalFixedFilter As String

    Private m_dataKind As DataKindenum
    Private m_customSearchProp As String = ""
    ''' <summary>
    ''' Legt den Datentype füür das Auswahlfenster fest
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum DataKindenum
        ''' <summary>
        ''' Artikel / Material
        ''' </summary>
        ''' <remarks></remarks>
        Articles
        ''' <summary>
        ''' Adressbuch
        ''' </summary>
        ''' <remarks></remarks>
        Contacts
        ''' <summary>
        ''' Kontorahmen
        ''' </summary>
        ''' <remarks></remarks>
        CashAccounts

        ''' <summary>
        ''' Textbausteine
        ''' </summary>
        ''' <remarks></remarks>
        TextTemplates
    End Enum

    ''' <summary>
    ''' Legt die Suchdatenquelle fest oder ruft diese ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataKind() As DataKindenum
        Get
            Return m_dataKind
        End Get
        Set(ByVal value As DataKindenum)
            m_dataKind = value
            m_customSearchProp = ""
        End Set
    End Property

    ''' <summary>
    ''' Ruft eine Semikolon-Getrennte LIste mit Properties ab, nach denen gesucht werden soll
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchProperties() As String
        Get
            Return m_customSearchProp
        End Get
        Set(ByVal value As String)
            m_customSearchProp = value

        End Set
    End Property

    ''' <summary>
    ''' Ruft eine Auflistung von Criterien ab, die in dem Suchpanel gebildet wurden
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCustomFilter() As CriteriaOperator

        Dim params(m_customSearchProp.Split(";"c).Length) As CriteriaOperator
        Dim n As Integer

        For Each item As String In m_customSearchProp.Split(";"c)
            Dim expr As CriteriaOperator = New BinaryOperator(item, "%" & IucSearchPanel1.Text & "%", BinaryOperatorType.Like)

            params(n) = expr
            n += 1
        Next
        Return GroupOperator.Or(params)

    End Function

    Public Sub Initialize()

        Select Case DataKind

            Case DataKindenum.Articles
                m_serverModeDS = New XPServerCollectionSource(m_session, MainApplication.getInstance.ArticleList.GetObjectClassInfo)
                m_serverModeDS.DisplayableProperties = "ShortDescription;LongDescription;GroupName;CalulatedEndPrice"
                '  m_internalFixedFilter = "FALSE" 'ersteinmal nichts anzeign lassen

                Me.Text = GetText("msgSearchArticles", "Artikel suchen")
                IucSearchPanel1.NullValuePrompt = GetText("SearchingByItemNameOrDescription", "Suche nach Artkelname oder-beschreibung")

            Case DataKindenum.Contacts
                m_serverModeDS = New XPServerCollectionSource(m_session, MainApplication.getInstance.Adressen.GetObjectClassInfo)
                m_serverModeDS.DisplayableProperties = "ContactDisplayID;ContactsName;Company;ZipCode;Town;Street"

                Me.Text = GetText("msgsearchByContactName", "Kontakt suchen")
                IucSearchPanel1.NullValuePrompt = GetText("msgSearchByContactNameLong", "Suche nach Kontakt")


            Case DataKindenum.CashAccounts
                m_serverModeDS = New XPServerCollectionSource(m_session, MainApplication.getInstance.CashAccounts.GetObjectClassInfo)
                m_serverModeDS.DisplayableProperties = MainApplication.getInstance.CashAccounts.DisplayableProperties
                Me.Text = GetText("msgSearchByAccountName", "Konto suchen")
                IucSearchPanel1.NullValuePrompt = GetText("msgSearchByAccountNameLong", "Suche nach Kontoname")


            Case DataKindenum.TextTemplates
                m_serverModeDS = New XPServerCollectionSource(m_session, MainApplication.getInstance.TextTemplates.GetObjectClassInfo)
                m_serverModeDS.DisplayableProperties = MainApplication.getInstance.TextTemplates.DisplayableProperties

                Me.Text = GetText("SearchTextBlock", "Textbaustein suchen")
                IucSearchPanel1.NullValuePrompt = GetText("SearchForTextblocks", "Suche nach Textbaustein")


        End Select


        If m_customSearchProp.Length > 0 Then
            For Each searchItem As String In m_customSearchProp.Split(";"c)
                If Not m_serverModeDS.DisplayableProperties.Contains(searchItem) Then
                    m_serverModeDS.DisplayableProperties = String.Concat(m_serverModeDS.DisplayableProperties, ";" & searchItem)
                End If
            Next
        End If

        ' System.Threading.Thread.Sleep(10000) ' kurz warten

        grdArticles.ServerMode = True
        m_serverModeDS.FixedFilterString = m_internalFixedFilter
        m_serverModeDS.Reload()

        grdArticles.DataSource = m_serverModeDS



    End Sub





    ''' <summary>
    ''' Nach Ablauf des Timers Suche starten
    ''' </summary>
    ''' <remarks></remarks>
    Sub StartSearch(ByVal searchText As String)


        If m_customSearchProp.Length > 0 Then
            m_serverModeDS.FixedFilterCriteria = GetCustomFilter()
        Else
            'LoadingCircle1.Visible = True
            LoadingCircle1.Active = True


            Select Case DataKind

                Case DataKindenum.Articles
                    Dim expr1 As CriteriaOperator = New BinaryOperator("LongDescription", "%" & searchText & "%", BinaryOperatorType.Like)
                    Dim expr2 As CriteriaOperator = New BinaryOperator("ShortDescription", "%" & searchText & "%", BinaryOperatorType.Like)
                    Dim expr3 As CriteriaOperator = New BinaryOperator("EAN", "%" & searchText & "%", BinaryOperatorType.Like)
                    Dim expr4 As CriteriaOperator = New BinaryOperator("CustomerArticleNumber", "%" & searchText & "%", BinaryOperatorType.Like)
                    ' Dim expr5 As CriteriaOperator = New BinaryOperator("IsActive", True, BinaryOperatorType.Equal)

                    Dim commonop As CriteriaOperator = GroupOperator.Or(expr1, expr2, expr3, expr4)
                    m_serverModeDS.FixedFilterCriteria = commonop

                    '    m_serverModeDS.FixedFilterCriteria = GroupOperator.Combine(GroupOperatorType.And, commonop, expr5)

                Case DataKindenum.Contacts
                    Dim expr1 As CriteriaOperator = New BinaryOperator("ContactDisplayID", "%" & searchText & "%", BinaryOperatorType.Like)
                    Dim expr2 As CriteriaOperator = New BinaryOperator("FirstName", "%" & searchText & "%", BinaryOperatorType.Like)
                    Dim expr3 As CriteriaOperator = New BinaryOperator("LastName", "%" & searchText & "%", BinaryOperatorType.Like)
                    Dim expr4 As CriteriaOperator = New BinaryOperator("Company", "%" & searchText & "%", BinaryOperatorType.Like)
                    Dim expr5 As CriteriaOperator = New BinaryOperator("Town", "%" & searchText & "%", BinaryOperatorType.Like)
                    m_serverModeDS.FixedFilterCriteria = GroupOperator.Or(expr1, expr2, expr3, expr4, expr5)

                Case DataKindenum.CashAccounts
                    Dim expr1 As CriteriaOperator = New BinaryOperator("AccountNumber", "%" & searchText & "%", BinaryOperatorType.Like)
                    Dim expr2 As CriteriaOperator = New BinaryOperator("AccountName", "%" & searchText & "%", BinaryOperatorType.Like)
                    m_serverModeDS.FixedFilterCriteria = GroupOperator.Or(expr1, expr2)

                Case DataKindenum.TextTemplates
                    Dim expr1 As CriteriaOperator = New BinaryOperator("Text", "%" & searchText & "%", BinaryOperatorType.Like)
                    m_serverModeDS.FixedFilterCriteria = GroupOperator.Or(expr1)


            End Select

            'LoadingCircle1.Visible = False
            LoadingCircle1.Active = False
        End If


    End Sub

    Friend Property SelectedID() As Integer
        Get
            Return m_selectedItem.ID
        End Get
        Set(ByVal value As Integer)

            ' mal sehen, ob das auch existiert.. 
            'Blöd, im Materialstamm können das mehrere 100.000 Artikel sein... 


        End Set
    End Property


    ''' <summary>
    ''' Ruft den gewählten Artikel ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property SelectedItem() As ClausSoftware.Data.StaticItem
        Get
            Return m_selectedItem
        End Get
        Set(ByVal value As ClausSoftware.Data.StaticItem)
            m_selectedItem = value
        End Set
    End Property


    Sub CustomColumn(ByVal sender As Object, ByVal e As CustomColumnDisplayTextEventArgs) Handles grvArticles.CustomColumnDisplayText
        If TypeOf e.Value Is Decimal Then
            e.DisplayText = CDec(e.Value).ToString("c")
        Else

            Dim valStr As String = e.DisplayText

            e.DisplayText = valStr.Trim.Replace(vbCrLf, "")

        End If

    End Sub





    Private Sub SetNextControl(ByVal sender As System.Object, ByVal e As EventArgs) Handles IucSearchPanel1.SetNextControl
        ' Den Focus weiterreichen
        grdArticles.Focus()
        grvArticles.FocusedRowHandle = 0
    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvArticles.FocusedRowChanged
        If Me.Visible Then
            m_selectedItem = TryCast(grvArticles.GetRow(e.FocusedRowHandle), StaticItem)
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_selectedItem = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        m_selectedItem = TryCast(grvArticles.GetFocusedRow, StaticItem)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub grdArticles_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdArticles.MouseDoubleClick
        Dim hi As GridHitInfo

        hi = grvArticles.CalcHitInfo(e.Location)
        If hi.InRow And hi.RowHandle >= 0 Then

            m_selectedItem = TryCast(grvArticles.GetRow(hi.RowHandle), StaticItem)

            ' dann war ein doppelklicck in eine Row
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()


        End If



    End Sub

    Private Sub frmSmallItemChooser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MainApplication.getInstance.Settings.SaveFormsPos(Me)
    End Sub

    Private Sub frmSmallItemChooser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MainApplication.getInstance.Settings.RestoreFormsPos(Me)

        MainApplication.getInstance.Languages.SetTextOnControl(Me)

        Select Case Me.DataKind
            Case DataKindenum.Articles : Me.Text = GetText("SearchArticles", "Artikel suchen")
            Case DataKindenum.CashAccounts : Me.Text = GetText("SearchAccounts", "Konten suchen")
            Case DataKindenum.Contacts : Me.Text = GetText("SearchContacts", "Kontakte suchen")
            Case DataKindenum.TextTemplates : Me.Text = GetText("SearchTextTemplates", "Textbausteine suchen")
            Case Else
                Me.Text = GetText("search...", "Suchen...")

        End Select


        Me.IucSearchPanel1.SetFocus()
    End Sub


    Private Sub frmSmallItemChooser_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.IucSearchPanel1.SetFocus()
        Initialize()
    End Sub

    Private Sub grdArticles_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdArticles.KeyDown
        If e.KeyCode = Keys.Enter Then

            m_selectedItem = CType(grvArticles.GetRow(grvArticles.FocusedRowHandle), StaticItem)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub


    Private Sub GridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvArticles.KeyDown
        If e.KeyCode = Keys.Up Then ' ist das obverste element Focussiert, dann wieder in die iengabezeile reingehen
            If grvArticles.FocusedRowHandle <= 0 Then
                IucSearchPanel1.SetFocus()
            End If
        End If
    End Sub

    Private Sub IucSearchPanel1_SearchTextChanged(ByVal sender As Object, ByVal e As SearchTextEventArgs) Handles IucSearchPanel1.SearchTextChanged
        StartSearch(e.Text)
    End Sub

    Private Sub grvArticles_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grvArticles.RowCellStyle

        ' Inaktive Daten grau anzeigen
        Dim activeItem As IHasActiveProperty = TryCast(CType(sender, GridView).GetRow(e.RowHandle), IHasActiveProperty)

        If activeItem IsNot Nothing Then
            If Not activeItem.IsActive Then
                e.Appearance.ForeColor = Color.Gray
            End If
        End If

    End Sub
End Class