Option Explicit On
Option Strict On


Imports DevExpress.Xpo

Namespace Data
    ''' <summary>
    ''' Enthält Stammdaten der Daten-Elemente
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
    <DebuggerDisplay("ID={ID}")> _
    <DefaultMembersPersistence(DefaultMembersPersistence.OnlyDeclaredAsPersistent)> _
    <NonPersistent()> _
    Public MustInherit Class StaticItem
        Inherits BaseClass
        Implements IStaticItemData
        Implements ICloneable

        
        ''' <summary>
        ''' Neue elemente, die noch nicht gespeichert wurden, haben die Ziffer "-1"
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_ID As Integer = -1

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_ReplikID As String


        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_hasChanged As Boolean


        ''' <summary>
        ''' Löscht das Objekt aus dem Datenspeicher. Beim vererben auf möglicherweise benutzte Referenzen achten.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Overloads Sub Delete()

            ' mal prüfen, ob der Eintrag nicht verwendet wird. 
            ' Das sind z.B., Adressbuch(In Journaldokumente, Forderungen/verbindlichkeiten), Artikel (In Sub-Artikel, Kalkulation); zu erweitern

            'TODO: beim Löschen auf Verweise achten
            MyBase.Delete()
        End Sub

        ''' <summary>
        ''' Zeigt an, ob ein Objekt als 'gelöscht' markiert wurde und nicht mehr als Datenabnk-Objekt existiert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads ReadOnly Property IsDeleted As Boolean
            Get
                Try

                    If Not Me.Session Is Nothing Then
                        Return MyBase.IsDeleted
                    Else
                        Debug.Print("Isdeleted noticed that a session-Object ist nothing. Therefore Object is deleted!")
                        ' Keine Session angegeben..  Objekt könnte daher gelöscht sein 
                        Return True
                    End If

                Catch ex As System.ObjectDisposedException
                    Return True  ' Höchstwarscheinlich ist es dann gelöscht.. 

                Catch ex As Exception
                    Throw ' Dann stimmt wohl was nicht damit 
                End Try
            End Get
        End Property

        ''' <summary>
        ''' Ruft einen Wert ab, der anzeigt, ob das Dokument bereits gesperrt ist , da es bereist bearbeitet wird
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function CheckLockState() As LockType
            Dim c As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator("ItemKey", Me.Key, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
            'Dim g As New DevExpress.Data.Filtering.GroupOperator(DevExpress.Data.Filtering.GroupOperatorType.And, c)

            'c = New DevExpress.Data.Filtering.BinaryOperator("LockByName", MainApplication.CurrentUser.Name, DevExpress.Data.Filtering.BinaryOperatorType.Equal)

            'g.Operands.Add(c)

            MainApplication.LockStateManager.Criteria = c
            MainApplication.LockStateManager.Reload()
            Dim lockItem As New LockType

            If MainApplication.LockStateManager.Count = 1 Then
                lockItem.LockedByName = MainApplication.LockStateManager(0).LockByName

                If String.Equals(m_mainApplication.CurrentUser.Name, lockItem.LockedByName) Then
                    lockItem.LockType = LockedbyType.ByMe
                Else
                    lockItem.LockType = LockedbyType.ByOthers
                End If

            End If
            Debug.Print("Lockstate of element '" & Me.GetType.Name & " is " & lockItem.LockType.ToString)
            Return lockItem

        End Function

        ''' <summary>
        ''' Markiert diesen Datensatz als 'in Bearbeitung' durch eine Sperre
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Lock()
            Try
                Dim c As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator("ItemKey", Me.Key, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
                Dim g As New DevExpress.Data.Filtering.GroupOperator(DevExpress.Data.Filtering.GroupOperatorType.And, c)

                c = New DevExpress.Data.Filtering.BinaryOperator("LockByName", MainApplication.CurrentUser.Name, DevExpress.Data.Filtering.BinaryOperatorType.Equal)

                g.Operands.Add(c)

                Dim m_lockstate As Kernel.security.SecurityLocks = MainApplication.LockStateManager

                m_lockstate.Criteria = g

                If m_lockstate.Count = 0 Then
                    Dim myLock As Kernel.security.SecurityLock = m_lockstate.GetNewItem

                    myLock.ItemKey = Me.Key
                    myLock.LockByName = MainApplication.CurrentUser.Name
                    myLock.Save()
                End If

            Catch ex As Exception
                m_mainApplication.log.WriteLog("Error while locking Data: (" & Me.Key & ") " & ex.Message)
            End Try


        End Sub

        ''' <summary>
        '''  Zu Implementieren
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsLocked() As Boolean
            'IMPORTANT: Is Locked im im static Item implementieren; Aufruf zum Lock-Manager umsetzen
            Return False
        End Function

        ''' <summary>
        ''' Löscht eine Sperre, sofern diese vom selben Benutzer angelegt wurde.
        ''' Wurde ein Sperre von einem anderen Benutzer angelegt, so kann der Datensatz nicht entspert werden
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Unlock()
            Dim c As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator("ItemKey", Me.Key, DevExpress.Data.Filtering.BinaryOperatorType.Equal)
            Dim g As New DevExpress.Data.Filtering.GroupOperator(DevExpress.Data.Filtering.GroupOperatorType.And, c)

            c = New DevExpress.Data.Filtering.BinaryOperator("LockByName", MainApplication.CurrentUser.Name, DevExpress.Data.Filtering.BinaryOperatorType.Equal)

            g.Operands.Add(c)

            MainApplication.LockStateManager.Criteria = g

            MainApplication.LockStateManager.Delete() ' Alle Elemente mit diesem Key löschen 

        End Sub

        ''' <summary>
        ''' Erzwingt das Aufheben einer Datensatz Sperre
        ''' </summary>
        ''' <remarks>Hebt die Sperre für diesen Datensatz auf, egal welcher Benutzer die Sperre gesetzt hat</remarks>
        Public Sub ForceUnlock()
            Dim c As DevExpress.Data.Filtering.CriteriaOperator = New DevExpress.Data.Filtering.BinaryOperator("ItemKey", Me.Key, DevExpress.Data.Filtering.BinaryOperatorType.Equal)

            MainApplication.LockStateManager.Criteria = c

            MainApplication.LockStateManager.Delete() ' Alle Elemente mit diesem Key löschen 
        End Sub

        ''' <summary>
        ''' Ist Wahr, wenn das Element neu ist und noch nicht in der Datenbank gespeichert wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        ReadOnly Property IsNew() As Boolean
            Get
                Return Me.ID = -1
            End Get
        End Property

        Protected Overrides Sub OnChanged(ByVal propertyName As String, ByVal oldValue As Object, ByVal newValue As Object)
            MyBase.OnChanged(propertyName, oldValue, newValue)
            m_hasChanged = True
        End Sub
        ''' <summary>
        ''' Setzt eine Marke die Anzeigt, das Änderungen durchgeführt wurden 
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub SetHaschanged()
            m_hasChanged = True
        End Sub
        ''' <summary>
        ''' Speichert den Eintrag ab 
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Overloads Sub Save()
            '' Beim Speichern die Verbindung auffrischen..  (damit kann erreicht werden, das bei Problemen ein Save noch mal durchkommt, falls die Verbindung gewaltsam geschlossen wurde
            'Me.Session.Connection.Close()
            'Me.Session.Connection.Open()

            MyBase.Save()

        End Sub

        Protected Overrides Sub OnSaved()
            MyBase.OnSaved()
            m_hasChanged = False
        End Sub

        Protected Overrides Sub OnLoaded()
            MyBase.OnLoaded()
            m_hasChanged = False
        End Sub

        ''' <summary>
        ''' Setzt den 'geändert' - Status wieder zurück
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub ClearHasChangedState()
            m_hasChanged = False
        End Sub

        ''' <summary>
        ''' Ist True, wenn das Objekt seit dem Laden geändert wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("HasChanged", "Wurde geändert")> _
        <ComponentModel.Browsable(False)> _
        Public Overridable ReadOnly Property HasChanged() As Boolean
            Get
                Return m_hasChanged
            End Get
        End Property

        ''' <summary>
        ''' Wird nach dem Prozess aufgerufen, der einen Datensatz einläd. Setzt das Changed-Flag zurück
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            m_hasChanged = False


        End Sub
#Region "Disable automatic Save in Grids"
        Protected Overrides Sub BeginEdit()
            MyBase.BeginEdit()
        End Sub

        Protected Overrides Sub EndEdit()
        End Sub

        Protected Overrides Sub CancelEdit()
        End Sub
#End Region
        ''' <summary>
        ''' Enthält einen autoInc-Wert des Datensatzes. Bei neuen und ungespeicherten Elementen ist der Wert -1
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Wird bei Neuanlage durch "reload" gesetzt</remarks>
        <ComponentModel.Browsable(False)> _
        <Key(True)> _
        <DisplayName("Nummer")> _
        <Persistent("ID")> _
        Public Overridable Property ID() As Integer Implements IStaticItemData.ID
            Get
                Return m_ID
            End Get
            Set(ByVal value As Integer)

                SetPropertyValue(Of Integer)("ID", m_ID, value)
            End Set
        End Property

        ''' <summary>
        ''' Enthält den Primärschlüssel der Datenbank; ist immer der selbe Schlüssel
        ''' </summary>
        ''' <value>Wird ein leerer Wert gesetzt, so wird automatisch stets eine neue GUID erzeugt</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(32)> _
        <Indexed(unique:=True)> _
        <ComponentModel.Browsable(False)> _
        <Persistent("ReplikID")> _
        Public Property ReplikID() As String Implements IStaticItemData.ReplikID
            <DebuggerStepThrough()> _
            Get
                Return m_ReplikID
            End Get
            Set(ByVal value As String)

                If String.IsNullOrEmpty(value) Then
                    value = Tools.Services.GetGUID
                End If


                SetPropertyValue(Of String)("ReplikID", m_ReplikID, value.Trim)

            End Set
        End Property

        ''' <summary>
        ''' Ruft die ReplikID ab.
        ''' Das ist ein Datenbankweit eindeutiger Wert, der jedes Element eindeutig identifiziert.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.Browsable(False)> _
        <ClausSoftware.Tools.DisplayName("InternalUniqueKeyValue", "Schlüssel ID (GUID)")> _
        <NonPersistent()> _
        Public ReadOnly Property Key() As String Implements IStaticItemData.Key
            <DebuggerStepThrough()> _
            Get
                Return m_ReplikID
            End Get

        End Property



        ''' <summary>
        ''' Legt ein neues Dokument an und vergibt eine neue, eindeutige ReplikID.
        ''' Wennd as Objekt aus der DAtenbank gelesen wird, so wird diese ID überschrieben
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal session As DevExpress.Xpo.Session)

            MyBase.New(session)
            m_ReplikID = Tools.Services.GetGUID

        End Sub



        Sub New()
            MyBase.New(m_mainApplication.Session)
            ' nichts; solllte nie aufgerufen werden !
            ' Debug.Assert(False, "Never call the default Constructor!")

        End Sub

        Protected Overrides Sub OnDeleted()
            MyBase.OnDeleted()

            Debug.Print("Objekt gelöscht: " & Me.ToString)
        End Sub

        ''' <summary>
        ''' Erstellt eine unabhängige Kopie von diesem Element 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Public Overridable Function Clone() As Object Implements System.ICloneable.Clone
            Dim newItem As StaticItem = Nothing

            Debug.Print("Erstelle einen Klon von: " & Me.GetType.Name)

            If Me.GetType.Name = GetType(Kernel.Article).Name Then
                newItem = m_mainApplication.ArticleList.GetNewItem
            End If

            If Me.GetType.Name = GetType(Kernel.ImageData).Name Then
                newItem = m_mainApplication.Images.GetNewItem
            End If
            If Me.GetType.Name = GetType(Kernel.Adress).Name Then
                newItem = m_mainApplication.Adressen.GetNewItem
            End If

            If Me.GetType.Name = GetType(Kernel.Transaction).Name Then
                newItem = m_mainApplication.Transactions.GetNewItem()
            End If

            If Me.GetType.Name = GetType(Kernel.CashAccount).Name Then
                newItem = m_mainApplication.CashAccounts.GetNewItem()
            End If

            If Me.GetType.Name = GetType(Kernel.Task).Name Then
                newItem = m_mainApplication.Tasks.GetNewItem()
            End If

            If Me.GetType.Name = GetType(Kernel.Unit).Name Then
                newItem = m_mainApplication.Units.GetNewItem()
            End If

            If Me.GetType.Name = GetType(Kernel.Discount).Name Then
                newItem = m_mainApplication.Discounts.GetNewItem()
            End If

            If Me.GetType.Name = GetType(Kernel.LoanAccount).Name Then
                newItem = m_mainApplication.LoanAccounts.GetNewItem()
            End If

            If Me.GetType.Name = GetType(Kernel.JournalArticleItem).Name Then
                newItem = New Kernel.JournalArticleItem(MainApplication.Session)
            End If

            If Me.GetType.Name = GetType(Kernel.JournalDocument).Name Then
                newItem = New Kernel.JournalDocument(MainApplication.Session)
            End If

            If Me.GetType.Name = GetType(Kernel.JournalArticleGroup).Name Then
                newItem = New Kernel.JournalArticleGroup(MainApplication.Session)
            End If

            If Me.GetType.Name = GetType(Kernel.JournalArticleItem).Name Then
                newItem = New Kernel.JournalArticleItem(MainApplication.Session)
            End If

            If TypeOf Me Is Kernel.BOM.ArticleLink Then
                newItem = New Kernel.BOM.ArticleLink(MainApplication.Session)
            End If

            If TypeOf Me Is Kernel.CashJournalItem Then
                newItem = m_mainApplication.CashJournal.GetNewItem
            End If

            If TypeOf Me Is Kernel.Printing.Report Then
                newItem = New Kernel.Printing.Report(MainApplication.Session)
            End If

            If TypeOf Me Is Kernel.Letter Then
                newItem = New Kernel.Letter(MainApplication.Session)
            End If

            If TypeOf Me Is Kernel.AttachmentsRelation Then
                newItem = New Kernel.AttachmentsRelation(MainApplication.Session)
            End If

            If TypeOf Me Is Kernel.FixedCost Then
                newItem = New Kernel.FixedCost(MainApplication.Session)
            End If

            If newItem Is Nothing Then
                Throw New NotImplementedException("Das Klonen von " & Me.GetType.Name & " ist noch nicht implementiert")
            End If


            CloneData(newItem)


            Return newItem
        End Function

        ''' <summary>
        ''' Füllt das Übergebene Objekt mit den Daten dieser aktuellen Instanz
        ''' </summary>
        ''' <param name="newItem"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CloneData(ByVal newItem As StaticItem) As StaticItem
            For Each propertyitem As Metadata.ReflectionPropertyInfo In Me.ClassInfo.PersistentProperties
                If Not propertyitem.IsKey And Not propertyitem.Name.Equals("replikid", StringComparison.InvariantCultureIgnoreCase) Then
                    newItem.SetMemberValue(propertyitem.Name, Me.GetMemberValue(propertyitem.Name))

                End If
            Next
            Return newItem

        End Function

    End Class

    Public Enum LockedbyType
        ''' <summary>
        ''' Datensatz von mir gesperrt
        ''' </summary>
        ''' <remarks></remarks>
        ByMe
        ''' <summary>
        ''' Datensatz von jemand anders gesperrt
        ''' </summary>
        ''' <remarks></remarks>
        ByOthers
        ''Datensatz nicht gesperrt
        ByNone
    End Enum

    ''' <summary>
    ''' Stellt Informationen über den aktuellen Sperrmechanismus bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class LockType

        Private m_IsLockedByMe As String = ""

        Private m_lockType As LockedbyType = LockedbyType.ByNone
        ''' <summary>
        ''' Ruft den aktuellen Sperrzustand ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LockType() As LockedbyType
            Get
                Return m_lockType
            End Get
            Set(ByVal value As LockedbyType)
                m_lockType = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen des aktuellen benutzers ab,d er des Datensatz gesperrt hat
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LockedByName() As String
            Get
                Return m_IsLockedByMe
            End Get
            Set(ByVal value As String)
                m_IsLockedByMe = value
            End Set
        End Property

    End Class

End Namespace