
<ComClass(ScannerManager.ClassId, ScannerManager.InterfaceId, ScannerManager.EventsId)> _
Public Class ScannerManager

#Region "COM-GUIDs"
    ' Diese GUIDs stellen die COM-Identität für diese Klasse 
    ' und ihre COM-Schnittstellen bereit. Wenn Sie sie ändern, können vorhandene 
    ' Clients nicht mehr auf die Klasse zugreifen.
    Public Const ClassId As String = "d0f1c846-027a-4497-aa43-5db5c451ee4d"
    Public Const InterfaceId As String = "3682b092-b8f1-45c4-b2b6-5adfc575c6c5"
    Public Const EventsId As String = "de00b4a8-fada-43ba-89e5-299d84c37e0e"
#End Region


    Public Structure Items
        Dim Count As Integer
        Dim ArtNr As String

    End Structure

    Private m_basketList As BasketItemList


    ' Eine erstellbare COM-Klasse muss eine Public Sub New() 
    ' ohne Parameter aufweisen. Andernfalls wird die Klasse 
    ' nicht in der COM-Registrierung registriert und kann nicht 
    ' über CreateObject erstellt werden.
    Public Sub New()
        MyBase.New()
    End Sub


    Public Function Getitems1() As BasketItemList
        Return m_basketList
    End Function

    Public Function GetItems() As Array

        Dim a As New ArrayList

        For Each bItem As BasketItem In m_basketList.Values
           
            a.Add(bItem)

        Next
        Return a.ToArray
    End Function

    ''' <summary>
    ''' Enthält den Dokumenten-Key des Journaldokumentes
    ''' </summary>
    ''' <remarks></remarks>
    Dim m_documentNumber As String
    Dim m_result As Boolean
    Dim m_group As Integer
    Dim m_docState As DocState

    ''' <summary>
    ''' enthält das aktuelle Dokumenten-Status
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum DocState
        Angebot = 0
        Bestellung = 1
        Rechnung = 2
        Mahnung = 3
        Gutschrift = 4
    End Enum

    ''' <summary>
    ''' Ruft eine Dokumentennummer ab oder legt diese fest; damit weis der Barcode-Scanner wo die Artikel hinzugefügt werden sollen.
    ''' Die Dokumentennummer muss bereits vorher vom Programm vergeben worden sein.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DocumentKey() As String
        Get
            Return m_documentNumber
        End Get
        Set(ByVal value As String)
            m_documentNumber = value
        End Set
    End Property

    ''' <summary>
    ''' Die aktuelle Position innerhalb der Liste
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GroupNumber() As Integer
        Get
            Return m_group
        End Get
        Set(ByVal value As Integer)
            m_group = value
        End Set
    End Property

    ''' <summary>
    ''' Kennzeichnet den Type des Dokumentes :Angebot / Rechnung ... 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DocType() As DocState
        Get
            Return m_docState
        End Get
        Set(ByVal value As DocState)
            m_docState = value
        End Set
    End Property

    ''' <summary>
    ''' Legt fest, ob der Scan mit "OK" /(TRUE) oder Abbrechen bestätigt wurde 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property ScanOK() As Boolean
        Get
            Return m_result
        End Get

    End Property


    Public Sub ShowDialog()
        Dim frm As New frmGetArticleByBarcode
        If frm.ShowDialog() = DialogResult.OK Then
            m_result = True
            ' Artikel kopieren
            'CopySelecedArticles(frm.Basket)
            m_basketList = frm.Basket
        Else
            m_result = False
        End If

    End Sub

    ''' <summary>
    ''' Kopiert die Artikel aus dem Scan in die Rechnunge-Vorlage
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CopySelecedArticles(ByVal list As BasketItemList)

        ' Artikel kopieren
        ' Journaleintrag erzeugen, sofern noch keiner existiert
        ' 
        ' Aktuelle Gruppe muss bekannt sein 
        ' Artikel hinzufügen
        Dim journalentry As ClausSoftware.Kernel.JournalDocument = CheckAndCreateJournal()


        ' Gesamte Gruppe wird überschrieben
        Dim position As ClausSoftware.Kernel.JournalArticleGroup

        If journalentry.ArticleGroups.Count = 0 Then
            position = New ClausSoftware.Kernel.JournalArticleGroup(journalentry)
            position.HeaderText = "Gescannt von Kasse" 'TODO: Text festlegen
            position.Save()
        Else
            position = journalentry.ArticleGroups(Me.GroupNumber)
        End If

        Dim itemsToRemove As New ClausSoftware.Kernel.JournalArticleItems(m_application)



        Dim indexNumber As Integer

        ' nun die Items aus dem Basket einfügen 
        Using session As New DevExpress.Xpo.Session
            For Each BasketItem As BasketItem In list.List
                Dim newitem As New ClausSoftware.Kernel.JournalArticleItem(session)

                With BasketItem
                    newitem.ItemCount = CDec(.Ammount)
                    newitem.ItemmemoText = .Article.ShortDescription

                    newitem.ItemUnit = .Article.VerpackungsEinheit

                    newitem.Sequence = indexNumber
                    indexNumber += 1
                    newitem.Save()
                End With

            Next
        End Using



    End Sub

    ''' <summary>
    ''' Prüft, ob ein Journaleintrag existiert und legt gegegenfalls ein an
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckAndCreateJournal() As ClausSoftware.Kernel.JournalDocument

        Dim journal As ClausSoftware.Kernel.JournalDocument = m_application.JournalDocuments.GetItem(m_documentNumber)

        If journal Is Nothing Then

            journal = New ClausSoftware.Kernel.JournalDocument(m_application.Session)
            journal.ReplikID = Me.DocumentKey
            journal.DocumentType = CType(Me.DocType, ClausSoftware.enumJournalDocumentType)
            journal.CreatedAt = Date.Today
            journal.DocumentDate = Date.Today

            journal.Save()



        End If

        Return journal


    End Function


End Class


