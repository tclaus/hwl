Imports SHK_Connect.de.shk_connect.shkgh
Imports System.IO
Imports System.IO.IsolatedStorage

''' <summary>
''' Stellt eine Auflistung von Branchen bereit
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Friend Class TradeInfo
    Inherits BaseData

    Friend Event StatusMessage(sender As Object, e As StatusMessageEventArg)


    ''' <summary>
    ''' Hilfsklasse für Branchen
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared m_shkGetBranchenListe As GetBranchenListe

    ''' <summary>
    ''' Auflistung der Branchen
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared m_tradeList As List(Of Trade)

    ''' <summary>
    ''' Ruft Servicestruktur der branchenliste ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property TradeListServiceStructure As GetBranchenListe
        Get
            If m_shkGetBranchenListe Is Nothing Then
                m_shkGetBranchenListe = New GetBranchenListe
                With m_shkGetBranchenListe
                    .Schnittstellenversion = ConnectionData.ConnectionVersion
                    .Softwarename = ConnectionData.AppName
                    .Softwarepasswort = ConnectionData.AppPassword

                End With
            End If
            Return m_shkGetBranchenListe
        End Get
    End Property


    ''' <summary>
    ''' Ruft die Auflistung aller zur Verfügung stehender Branchen ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Liste wird nicht aktualisiert</remarks>
    ReadOnly Property TradeList As List(Of Trade)
        Get

            ' Bei nothing wurde nichts geholt (auch kein cache), bei Count=0 war die geholte Liste leer..

            If m_tradeList Is Nothing OrElse m_tradeList.Count = 0 Then
                Try
                    Dim service As New branchenListeService

                    RaiseEvent StatusMessage(Me, New StatusMessageEventArg("Starte Anfrage..."))

                    Dim resp As GetBranchenListeResponse = service.GetBranchenListe(TradeListServiceStructure) '
                    Debug.Print("GetBranchenListe Status: " & resp.Status.Code & ": " & resp.Status.Meldung)
                    If resp.Status.Code = "0" Then
                        RaiseEvent StatusMessage(Me, New StatusMessageEventArg("OK"))
                    Else
                        RaiseEvent StatusMessage(Me, New StatusMessageEventArg(resp.Status.Meldung))
                    End If

                    m_tradeList = New List(Of Trade)
                    If resp.Branche IsNot Nothing Then
                        'Liste auffüllen
                        For Each item As Branche In resp.Branche
                            Dim newTrade As New Trade
                            newTrade.ID = item.ID
                            newTrade.Name = item.Name

                            m_tradeList.Add(newTrade)
                        Next
                    End If

                Catch ex As Exception
                    Initialize.Application.Log.WriteLog(ex, Initialize.ModulName, "Fehler beim holen der Branchenliste")
                End Try

                SaveCache()

            Else
                Debug.Print("Branchen aus Cache geladen")
            End If

            Return m_tradeList
        End Get
    End Property

    ''' <summary>
    '''  Läd die branchen aus einem Zwischenspeicher ein
    ''' </summary>
    ''' <remarks></remarks>
    Friend Overrides Sub LoadCache()

        Using isolatedStorage As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing, Nothing)
            Try
                Using isolatedStream As New IsolatedStorageFileStream("SHK-TradeInfo", FileMode.Open, isolatedStorage)

                    Try

                        ' Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
                        Dim formatter As New Xml.Serialization.XmlSerializer(GetType(List(Of Trade)))

                        m_tradeList = CType(formatter.Deserialize(isolatedStream), List(Of Trade))
                    Catch ex As Exception
                        Debug.Print("Fehler beim deserialisieren des Caches für Branchen: " & ex.Message)

                    Finally
                    End Try
                    isolatedStream.Close()
                End Using

                isolatedStorage.Close()

            Catch ex As Exception
                Debug.Print("Konnte Cache der Branchen nicht lesen: " & ex.Message)


            End Try
        End Using

    End Sub

    ''' <summary>
    '''  Läd die branchen aus einem Zwischenspeicher ein
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub SaveCache()

        Using isolatedStorage As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing, Nothing)
            Try
                Using isolatedStream As New IsolatedStorageFileStream("SHK-TradeInfo", FileMode.Create, isolatedStorage)

                    Try
                        ' Dim formatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                        Dim formatter As New Xml.Serialization.XmlSerializer(GetType(List(Of Trade)))

                        formatter.Serialize(isolatedStream, m_tradeList)

                        Debug.Print("Cache der Tradelist (Branchen) gespeichert")
                    Catch ex As Exception
                        Debug.Print("Fehler beim schreiben (serialisieren) des Caches für Branchen: " & ex.Message)
                    End Try

                    isolatedStream.Close()
                End Using

                isolatedStorage.Close()

            Catch ex As Exception
                Debug.Print("Konnte Cache der Branchen nicht schreiben: " & ex.Message)
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Nach einem Refresh kann die Branchenliste neu abgefragt werden
    ''' </summary>
    ''' <remarks></remarks>
    Friend Overrides Sub Refresh()
        m_tradeList = Nothing
    End Sub

    Public Sub New()
        LoadCache()

    End Sub
End Class

''' <summary>
''' Stellt eine einzelne Branche dar.
''' Die branche mit der ID -1 steht für "Favoriten. 
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public Class Trade
    Private m_id As Integer
    Private m_name As String

    Public Property Name() As String
        Get
            Return m_name
        End Get
        Set(ByVal value As String)
            m_name = value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft einen Anzeigetext ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function

    Public Sub New()

    End Sub

End Class
