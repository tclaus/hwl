Option Explicit On
Option Strict On
Imports System.ComponentModel
Imports ClausSoftware.Kernel

Imports ClausSoftware.Data




''' <summary>
''' Stellt eine Klasse zur Verfügung, die die zuletzt benutzetn Elemente enthält
''' </summary>
''' <remarks></remarks>
Public Class MRUElementManager

    ''' <summary>
    ''' Signalisiert, das sich die MRU-Liste geändert hat, und die Buttons-Auflistung entsprechend angepasst werden muss
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event MRUChanged(ByVal sender As MRUElementManager, ByVal e As EventArgs)
    Private WithEvents m_timer As New System.Windows.Forms.Timer

    ''' <summary>
    ''' Zeigt an, ob im Moment die LIste der Elemente neu Aufgebaut wird
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
    Private m_isloading As Boolean

    <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
    Private m_mruElements As New List(Of MRUElement)


    ''' <summary>
    ''' Enthält eine Auflistung an gelöschten Elementen
    ''' </summary>
    ''' <remarks></remarks>
    Private m_mruRemovedElements As New List(Of MRUElement)

    Private Const DefaultCount As Integer = 10
    Private m_maxItemsPerType As Integer = DefaultCount
    Private m_itemCounter As New Dictionary(Of MRUItemType, Integer)
    

    Private Enum MRUItemType
        JournalItem
        AdressItem
        ArticleItem
        TransactionItem
        CashItem
        Letter
        Reminder
    End Enum

    ''' <summary>
    ''' Speichert das neue Objekt des Verlaufes ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save(newItem As MRUElement)

        If m_isloading Then Exit Sub


        Dim recentItem As Kernel.RecentlyUsed = m_application.RecentlyUsedItems.GetItemByTargetID(newItem.Element.Key)

        ' Nur dann ein neues Element anlegen
        If recentItem Is Nothing Then
            recentItem = m_application.RecentlyUsedItems.GetNewItem
            recentItem.SetRecentItem(newItem.Element)

            m_application.RecentlyUsedItems.Add(recentItem)
        End If

        ' Neue Zeit festlegen
        recentItem.CalledAt = newItem.TimeStamp
        recentItem.Save()

    End Sub

    ''' <summary>
    ''' Ruft einen Typ basierend auf das staticItem ab
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetItemType(ByVal item As StaticItem) As RecentItemType
        If TypeOf item Is Kernel.Adress Then
            Return RecentItemType.AdressItem
        End If

        If TypeOf item Is Article Then
            Return RecentItemType.ArticleItem
        End If

        If TypeOf item Is CashJournalItem Then
            Return RecentItemType.CashItem
        End If

        If TypeOf item Is Transaction Then
            Return RecentItemType.TransactionItem
        End If

        If TypeOf item Is JournalDocument Then
            Return RecentItemType.JournalDocumentItem
        End If

        If TypeOf item Is Letter Then
            Return RecentItemType.Letter
        End If

        Throw New ArgumentException("Der Typ wurde nicht in GetItemTyp aufgenommen!")
        'TODO: einen Typ zurückgeben    
    End Function


    ''' <summary>
    ''' Ruft die maximale Anzahl von MRU-Einträgen pro ElementType ab oder legt diese fest. 
    ''' Standard ist 10 Einträge pro Type
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MaxItemsPerElementType() As Integer
        Get
            Return m_maxItemsPerType
        End Get
        Set(ByVal value As Integer)
            If value >= 0 And value < 100 Then
                m_maxItemsPerType = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Ruft die Liste der zuletzt geänderten Elemente ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property RecentlyModifiedElements() As List(Of MRUElement)
        Get
            Return m_mruElements
        End Get

    End Property

    ''' <summary>
    ''' Löscht die Auflistung der MRU - Elemente
    ''' </summary>
    ''' <remarks>Löscht auch die persistente Liste inder Datenbank</remarks>
    Public Sub ClearList()
        m_application.RecentlyUsedItems.Delete()
        RecentlyModifiedElements.Clear()
        StartElementChangedTimer()
    End Sub

    ''' <summary>
    ''' Fügt der Auflistung der MRU-Elemente ein weiteres Element hinzu. 
    ''' Existiert bereits das Element in der Liste, so wird der Wert erhöht
    ''' </summary>
    ''' <param name="element">Das Element, das der Liste hinzugefügt wird oder, falls bereits in der Liste vorhanden, an erster Stelle gesetzt wird.</param>
    ''' <remarks></remarks>
    Public Sub AddMRUElement(ByVal element As StaticItem)
        If element Is Nothing Then Exit Sub
        If element.IsNew Then Exit Sub


        Try
            Dim newMRUItem As MRUElement
            newMRUItem = CreateItem(element, Now)
            If m_mruElements.Contains(newMRUItem) Then
                m_mruElements.Remove(newMRUItem)

            End If

            m_mruElements.Add(newMRUItem)
            ' Nun alle anderen hochzählen, das zuletzt eingefügte Teil steht nun an der Spitze der Liste
            IncementAllOtherItems(newMRUItem)
            Me.Save(newMRUItem)

            ' Änderungen publizieren
            StartElementChangedTimer()

        Catch ex As Exception
            ' Kann eigentklich nur auftreten, wenn ein ungültiges / defektes Element übergeben wurde, 
            ' Das hat dann aber auch nichts in den MRUs zu suchen!
            Debug.Print("MRUManager kann Element nicht bearbeiten:" & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Erstellt ein neues vereinfachtes Element der zuletzt benutzten Objekte
    ''' </summary>
    ''' <param name="element"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateItem(element As StaticItem, calledAt As DateTime) As MRUElement
        Dim newMRUItem As New MRUElement(element)
        newMRUItem.TimeStamp = calledAt

        Return newMRUItem
    End Function

    ''' <summary>
    ''' Startet einen Timer der verzögert ein Ereignis sendet, das geänderte Elementauflistungen publiziert
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartElementChangedTimer()
        m_timer.Stop()
        m_timer.Start() ' Timer neustarten

    End Sub

    ''' <summary>
    ''' Alle anderen Elemente in der Wertigkeit hochzählen
    ''' </summary>
    ''' <param name="newItem"></param>
    ''' <remarks></remarks>
    Private Sub IncementAllOtherItems(ByVal newItem As MRUElement)

        Dim toRemove As New List(Of MRUElement)

        ' Elementtypen festlegen, um die als 'Verlauf' aufgenommen werden sollen
        For Each item As MRUItemType In [Enum].GetValues(GetType(MRUItemType))
            m_itemCounter(item) = 0
        Next


        For Each item As MRUElement In RecentlyModifiedElements

            If TypeOf item.Element Is Kernel.Adress Then
                CheckItemType(item, MRUItemType.AdressItem, toRemove)
            End If

            If TypeOf item.Element Is Kernel.Article Then
                CheckItemType(item, MRUItemType.ArticleItem, toRemove)
            End If
            If TypeOf item.Element Is Kernel.CashJournalItem Then
                CheckItemType(item, MRUItemType.CashItem, toRemove)
            End If
            If TypeOf item.Element Is Kernel.JournalDocument Then
                CheckItemType(item, MRUItemType.JournalItem, toRemove)
            End If

            If TypeOf item.Element Is Kernel.Letter Then
                CheckItemType(item, MRUItemType.Letter, toRemove)
            End If

            If TypeOf item.Element Is Kernel.Reminder Then
                CheckItemType(item, MRUItemType.Reminder, toRemove)
            End If

            If TypeOf item.Element Is Kernel.Transaction Then
                CheckItemType(item, MRUItemType.TransactionItem, toRemove)
            End If


        Next

        'Überhang entfernen (maximale Anzahl erreicht)
        For Each item As MRUElement In toRemove
            m_mruElements.Remove(item)
        Next


    End Sub

    ''' <summary>
    ''' Zählt die Elemente typsicher zusammen und reduziert die Liste
    ''' </summary>
    ''' <param name="item"></param>
    ''' <param name="itemType"></param>
    ''' <param name="itemsLIst"></param>
    ''' <remarks></remarks>
    Private Sub CheckItemType(ByVal item As MRUElement, ByVal itemType As MRUItemType, ByVal itemsLIst As List(Of MRUElement))

        If m_itemCounter(itemType) > MaxItemsPerElementType Then
            itemsLIst.Add(item)
        Else
            m_itemCounter(itemType) += 1
        End If
    End Sub
    


    ''' <summary>
    ''' Erstellt eine neue Instanz der Klasse
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        m_timer.Interval = 300
        m_timer.Stop()
        m_isloading = True

        ' Elementtypen festlegen, um die als 'Verlauf' aufgenommen werden sollen
        For Each item As MRUItemType In [Enum].GetValues(GetType(MRUItemType))
            m_itemCounter.Add(item, 0)
        Next

        For Each item As RecentlyUsed In m_application.RecentlyUsedItems
            RecentlyModifiedElements.Add(Me.CreateItem(item.GetRecentlyUsedItem, item.CalledAt))
        Next
        m_isloading = False

    End Sub

    ''' <summary>
    ''' Sendet eine verzögerte Mitteilung über eine geänderte Auflistung
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub m_timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_timer.Tick
        m_timer.Stop()
        RaiseEvent MRUChanged(Me, New EventArgs)
    End Sub
End Class

''' <summary>
''' Stellt ein einzelnes Element zur verfügung
''' </summary>
''' <remarks></remarks>
<DebuggerDisplay("Element:: {m_element}")> _
Public Class MRUElement
    Implements IComparable(Of MRUElement)
    Implements IComparable
    Implements IEquatable(Of MRUElement)

    Private m_element As StaticItem


    Private m_value As Integer

    Private m_timestamp As DateTime
    ''' <summary>
    ''' Ruft einen Zeitstempel der letzten Benutzung ab oder legt diesen fest. 
    ''' Damit kann der Verlauf über einen längeren Zeitraum festgehalten werden
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TimeStamp() As DateTime
        Get
            Return m_timestamp
        End Get
        Set(ByVal value As DateTime)
            m_timestamp = value
        End Set
    End Property



    ''' <summary>
    ''' Ruft das Element ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Element() As StaticItem
        Get
            Return m_element

        End Get

    End Property


    ''' <summary>
    ''' Erstellt eine neue Instanz der Klasse
    ''' </summary>
    ''' <param name="element"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal element As StaticItem)
        m_element = element
        m_value = 0
        m_timestamp = DateTime.Now

    End Sub

    Public Function CompareTo1(obj As Object) As Integer Implements System.IComparable.CompareTo
        If TypeOf obj Is MRUElement Then
            Return CompareTo(CType(obj, MRUElement))
        Else
            Throw New Exception("Typ kann nicht verglichen werden")
        End If
    End Function
    ''' <summary>
    ''' Vergleicht zwei MRU-Elemente miteinander und stellt je nach eingestelltem Wert das mit dem höheren Wert vor niedrigeren Elementen
    ''' </summary>
    ''' <param name="other">An object to compare with this object.</param>
    ''' <returns>A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the other parameter.  Zero This object is equal to other. Greater than zero This object is greater than other.</returns>
    ''' <remarks></remarks>
    Public Function CompareTo(ByVal other As MRUElement) As Integer Implements System.IComparable(Of MRUElement).CompareTo
        Return other.TimeStamp.CompareTo(Me.TimeStamp)
    End Function



    ''' <summary>
    ''' Führt einen Vergleich durch, ob ein MRU für das Element bereits existiert
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Equals1(ByVal other As MRUElement) As Boolean Implements System.IEquatable(Of MRUElement).Equals
        If Me.Element IsNot Nothing Then
            Return Me.Element.Key.Equals(other.Element.Key)
        Else

            Return False
        End If

    End Function



End Class

Friend Class CompareRecentelements
    Inherits Comparer(Of DateTime)


    Public Overrides Function Compare(x As Date, y As Date) As Integer
        Return y.CompareTo(y)
    End Function
End Class
