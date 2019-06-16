
''' <summary>
''' Stellt statisische Informationen zur Verfügung 
''' </summary>
''' <remarks></remarks>
Public Class StatisticInfo


    Private m_AdressbookCount As Integer
    Private m_ArticleCount As Integer
    Private m_JournalDocuments As Integer
    Private m_nextAddressNumber As Integer
    Private m_NextArticleNUmber As Integer
    Private m_nextInvoiceNumber As Integer

    ''' <summary>
    ''' Erstellt eine neue Instanz der Klasse
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        FillData()
    End Sub

    Private m_NextOffersNumber As Integer

    Public ReadOnly Property NextOffersNumber() As Integer
        Get
            Return m_NextOffersNumber
        End Get

    End Property

    Public ReadOnly Property NextInvoiceNumber() As Integer
        Get
            Return m_nextInvoiceNumber
        End Get

    End Property

    Public ReadOnly Property NextArticleNumber() As Integer
        Get
            Return m_NextArticleNUmber
        End Get
    End Property

    Public ReadOnly Property NextAddressNumber() As Integer
        Get
            Return m_nextAddressNumber
        End Get
    End Property

    ''' <summary>
    ''' Ruft die Anzahl der Datensätze ab (Angebote/Rechnungen)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property InvoiceCount() As Integer
        Get
            Return m_JournalDocuments
        End Get

    End Property

    ''' <summary>
    ''' Ruft die Anzahl der Datensätze ab (Artikel)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ArticleCount() As Integer
        Get
            Return m_ArticleCount
        End Get

    End Property

    ''' <summary>
    ''' Ruft die Anzahl der Datensätze ab (Adressen)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AddessbookCount() As Integer
        Get
            Return m_AdressbookCount
        End Get
    End Property

    ''' <summary>
    ''' Füllt die Daten auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillData()
        m_AdressbookCount = MainApplication.getInstance.Adressen.GetCount
        m_ArticleCount = MainApplication.getInstance.ArticleList.GetCount
        m_JournalDocuments = MainApplication.getInstance.JournalDocuments.GetCount

        m_nextAddressNumber = MainApplication.getInstance.Adressen.GetMaxID
        m_NextArticleNUmber = MainApplication.getInstance.ArticleList.GetMaxID
        m_nextInvoiceNumber = MainApplication.getInstance.JournalDocuments.Invoices.GetMaxID
        m_NextOffersNumber = MainApplication.getInstance.JournalDocuments.Offers.GetMaxID
    End Sub


End Class

