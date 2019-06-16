''' <summary>
''' Stellt einen Dialog bereit, der das Eingeben von Artikel durch einen Barcodescanner unterstützt
''' </summary>
''' <remarks></remarks>
Public Class frmGetArticleByBarcode

    ''' <summary>
    ''' Enthält die Liste aller Einträge des Warenkorbes
    ''' </summary>
    ''' <remarks></remarks>
    Dim WithEvents m_basketItemList As New BasketItemList

    ''' <summary>
    ''' Ruft die Einkaufsliste ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property Basket() As BasketItemList
        Get
            Return m_basketItemList
        End Get
    End Property

    Private Sub iucSearchByEAN_SearchTextChanged(ByVal sender As Object, ByVal e As SearchTextEventArgs) Handles iucSearchByEAN.SearchTextChanged

        Dim text As String = e.Text

        PictureBox1.Image = My.Resources.Document_Error_32x32
        lblCurrentArticle.Text = ""
        text = text.Trim

        If text.Length = 0 Then
            ' keine gültige Suche
            Exit Sub
        End If

        Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("EAN='" & text & "'")
        Dim eanArticle As New ClausSoftware.Kernel.Articles(MainApplication.getInstance, criteria)

        Debug.Print("Suche:" & criteria.LegacyToString)

        lblCurrentArticle.Text = ""
        If eanArticle.Count > 1 Then
            ' Beide in einem kleinen Dialog anzeigen und auswählen lassen
            lblCurrentArticle.Text = "Keine eindeutige Auswahl, es wurden " & eanArticle.Count & "  Artikel mit dieser Nummer gefunden"
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)

        End If

        If eanArticle.Count = 1 Then
            lblCurrentArticle.Text = "Gefunden:" & eanArticle(0).ToString()
            ' Artikel in die Liste übernehmen

            AddArticleToList(text, eanArticle(0))
            PictureBox1.Image = My.Resources.Document_Check_32x32
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        End If

        If eanArticle.Count = 0 Then
            lblCurrentArticle.Text = "Keine Artikel mit dieser Nummer gefunden!"
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)

        End If

        ' den Focus wieder setzen
        iucSearchByEAN.txtSearchText.SelectAll()
        iucSearchByEAN.txtSearchText.Focus()
    End Sub

    ''' <summary>
    ''' Fügt diesen Artiel der Liste hinzu und setzt den zugriff auf den übergebenn Schlüsssel (EAN-Code)
    ''' </summary>
    ''' <param name="article"></param>
    ''' <remarks></remarks>
    Friend Sub AddArticleToList(ByVal key As String, ByVal article As ClausSoftware.Kernel.Article)
        If m_basketItemList.ContainsKey(key) Then
            ' einen Artikel aufaddieren
            m_basketItemList(key).Ammount += 1
        Else
            m_basketItemList.Add(key, New BasketItem(key, 1, article, article.EinzelVK))
        End If

        GridView1.RefreshData()



    End Sub

    Private Sub frmGetArticleByBarcode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        iucSearchByEAN.Focus()
        iucSearchByEAN.txtSearchText.SelectAll()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'todo: was ist mit den Artikel?
        ' Direkt in die Datenbank schreiben ? 
        Me.Close()
    End Sub

    Private Sub frmGetArticleByBarcode_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GridControl1.DataSource = m_basketItemList.List

    End Sub


    Private Sub lstArticleList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown

        Dim basketItem As BasketItem

        For Each itemID As Integer In GridView1.GetSelectedRows
            basketItem = CType(GridView1.GetRow(itemID), HWLInterops.BasketItem)
            If basketItem IsNot Nothing Then



                If e.KeyCode = Keys.Delete Then

                    m_basketItemList.Remove(basketItem.EANKey)

                End If

                ' hinzufügen / abziehen 

                If e.KeyCode = Keys.Add Then
                    ' Hinzufügen

                    basketItem.Ammount += 1

                End If

                If e.KeyCode = Keys.Subtract Then
                    ' Hinzufügen
                    If basketItem.Ammount > 0 Then
                        basketItem.Ammount -= 1

                    End If
                End If

            End If
        Next

    End Sub



    Private Sub txtGivenAmmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGivenAmmount.TextChanged
        ' berechnet das Rückgeld
        Dim value As Decimal
        If Decimal.TryParse(txtGivenAmmount.Text, value) Then
            Dim back As Double
            back = value - m_basketItemList.TotalCharge
            lblBackMoney.Text = back.ToString("C")
        End If
    End Sub

    Private Sub m_basketItemList_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles m_basketItemList.PropertyChanged

        GridControl1.RefreshDataSource()
        lblTotal.Text = m_basketItemList.TotalCharge.ToString("C")

    End Sub
End Class

''' <summary>
''' Enthält eine Auflistung vom Einträgen die eingescannt wurden
''' </summary>
''' <remarks></remarks>
Public Class BasketItemList
    Inherits System.Collections.Generic.Dictionary(Of String, BasketItem)
    Implements INotifyPropertyChanged



    Dim m_basketList As New List(Of BasketItem)

    ''' <summary>
    ''' Ruft den Kalkuliertren Gesamtpreis ab oder legt einen Preis fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property TotalCharge() As Double
        Get

            Dim total As Double
            For Each basketItem As BasketItem In Values
                total += (basketItem.Ammount * basketItem.Price)
            Next
            Return total
        End Get
    End Property

    ''' <summary>
    ''' Gibz eine Liste der Items zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property List() As List(Of BasketItem)
        Get
            Return m_basketList
        End Get
    End Property


    ''' <summary>
    ''' Fügt ein Eintrag der Liste hinzu
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="basketitem"></param>
    ''' <remarks></remarks>
    Shadows Sub Add(ByVal key As String, ByVal basketitem As BasketItem)
        MyBase.Add(key, basketitem)
        m_basketList.Add(basketitem)

        BubbleEvent(Me, New PropertyChangedEventArgs(""))

        AddHandler basketitem.PropertyChanged, AddressOf BubbleEvent
    End Sub

    ''' <summary>
    ''' Entfernt ein Eintrag as der Liste
    ''' </summary>
    ''' <param name="key"></param>
    ''' <remarks></remarks>
    Shadows Sub Remove(ByVal key As String)
        Dim item As BasketItem = Me(key)
        m_basketList.Remove(item)
        MyBase.Remove(key)


        BubbleEvent(Me, New PropertyChangedEventArgs(""))

        RemoveHandler item.PropertyChanged, AddressOf BubbleEvent


    End Sub

    Sub BubbleEvent(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(sender, e)
    End Sub



    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Public Sub New()

    End Sub


End Class

''' <summary>
''' Stellt eine Klasse bereit, die einen Artikel aus der Kassenbuchung enthält und Anzahl, sowie Endpreis enthält
''' </summary>
''' <remarks></remarks>
<ComClass(BasketItem.ClassId, BasketItem.InterfaceId, BasketItem.EventsId)> _
Public Class BasketItem
    Implements INotifyPropertyChanged


    ' These  GUIDs provide the COM identity for this class 
    ' and its COM interfaces. If you change them, existing 
    ' clients will no longer be able to access the class.

    Public Const ClassId As String = "8420184B-584E-439d-B42F-5C73AEE789E3"
    Public Const InterfaceId As String = "6F0776C8-BD5C-4d2c-BBEC-0681A1B36D29"
    Public Const EventsId As String = "1F5E1F01-9A88-4ecc-AC4C-4F5818E8DC9F"



    Dim m_article As ClausSoftware.Kernel.Article
    Dim m_count As Double
    Dim m_price As Double  ' endpreis für den Kunden (Netto oder Brutto?)
    Dim m_key As String

    ''' <summary>
    ''' Ruft den Artikel ab, der im Korb liegt
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DisplayName("Artikel")> _
    Friend Property Article() As ClausSoftware.Kernel.Article
        Get
            Return m_article
        End Get
        Set(ByVal value As ClausSoftware.Kernel.Article)
            m_article = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Article"))
        End Set
    End Property

    ''' <summary>
    ''' Ruft die ID des Eintrages ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ID() As Integer
        Get
            Return m_article.ID
        End Get
    End Property

    ''' <summary>
    ''' Ruft die Anzahl der Artikel ab, die im Korb liegen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DisplayName("Anzahl")> _
    Property Ammount() As Double
        Get
            Return m_count
        End Get
        Set(ByVal value As Double)
            m_count = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Ammount"))
        End Set
    End Property

    ''' <summary>
    ''' Ruft den Endkundenpreis des Artikels ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DisplayName("Preis")> _
    Property Price() As Double
        Get
            Return m_price
        End Get
        Set(ByVal value As Double)
            m_price = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Price"))
        End Set
    End Property

    Sub New()
    End Sub

    ''' <summary>
    ''' Erstellt ein neues Objekt der Klasse
    ''' </summary>
    ''' <param name="ammount">Anzahl der Artikel</param>
    ''' <param name="article">Artikel</param>
    ''' <param name="charge">End-Preis des Artikels</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal key As String, ByVal ammount As Decimal, ByVal article As ClausSoftware.Kernel.Article, ByVal charge As Decimal)
        m_article = article
        m_price = charge
        m_count = ammount
        m_key = key
    End Sub



    <DisplayName("EAN / Code")> _
    ReadOnly Property EANKey() As String
        Get
            Return m_key
        End Get
    End Property

    <DisplayName("Bezeichnung")> _
    ReadOnly Property Displaytext() As String
        Get
            Return ToString()
        End Get
    End Property
    ''' <summary>
    ''' Zeigt den Anzeogetext des Eintrages an
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return Me.Ammount & ", " & Me.Article.ToString & ", " & Me.Price
    End Function

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class