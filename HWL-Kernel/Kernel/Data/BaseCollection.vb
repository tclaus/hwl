Option Explicit On
Option Strict On

Imports DevExpress.Data.Filtering

Namespace Data

    ''' <summary>
    ''' Enthält eine Liste mit allen Teilen 
    ''' </summary>
    ''' <typeparam name="ItemType"></typeparam>
    ''' <remarks></remarks>
    <Serializable()> _
    <DebuggerDisplay("Anzahl={Count}")> _
    Public Class BaseCollection(Of itemType As StaticItem)
        Inherits DevExpress.Xpo.XPCollection(Of itemType)
        Implements ICloneable
        Implements IEnumerable(Of itemType)

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If m_dictionary IsNot Nothing Then m_dictionary.Clear()
            If m_dictionaryId IsNot Nothing Then m_dictionaryId.Clear()
            MyBase.Dispose(disposing)
        End Sub
        ''' <summary>
        ''' enthält die ermittelte Anzahl der Datensätze dieser Tabelle
        ''' </summary>
        ''' <remarks></remarks>
        Private m_countByQuery As Integer
        ''' <summary>
        ''' Enthält eine Auflistung an Spaltennamen, die in dieser Auflistung zum Duchsuchen per Volltext genutzt erden kann
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_FullTextsearchColumns() As String = New String() {} ' Leer erzeugen


        ''' <summary>
        ''' Enthält eine Auflistung von ReplikIDs zu Objekten
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_dictionary As New Dictionary(Of String, itemType)

        ''' <summary>
        ''' enthält eine Auflistung vin ID-werten zu Objekten. stellt einen Zugriffscache dar
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_dictionaryId As New Dictionary(Of Integer, itemType)

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private Shared m_application As mainApplication
        ' Private m_dictionary As New Dictionary(Of String, itemType)

        ''' <summary>
        ''' Ist true, wenn eins der Elemente ungespeicherte Änderungen hat
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property HasChanges() As Boolean
            Get
                'Performance: Hier wird eine Liste durchlaufen, eventuell eleganter ? 
                For n As Integer = 0 To Me.Count - 1
                    If Me(n).HasChanged Then Return True
                Next
                Return False
            End Get
        End Property

        ''' <summary>
        ''' Führt eine Volltextsuche mit demangegebenen Parameter aus
        ''' </summary>
        ''' <param name="parameter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SearchByParameter(ByVal parameter As String) As BaseCollection(Of itemType)
            ' ein durch Leerzeichn getrenter Text
            'Para1 Para 2 Para3... 
            'where Col1 like 'Para1%' Or col1 like 'Para2%' ... 

            If Me.FullTextSearchColumns.Length = 0 Then
                Throw New ArgumentException("FullTextsearch-Element darf nicht leer sein.")
            End If

            ' Suchkriterien aufbauen
            Debug.Print("Starte Suche in: " & Me.ToString)
            Dim sw As New Stopwatch
            sw.Start()
            Dim criteriaList As New List(Of CriteriaOperator)
            If parameter.Trim.Length > 1 Then
                For Each seachCol As String In Me.FullTextSearchColumns
                    Dim expr1 As CriteriaOperator = New BinaryOperator(seachCol, "%" & parameter & "%", BinaryOperatorType.Like)
                    criteriaList.Add(expr1)
                Next
            Else
                ' Ungültiger Suchbegriff filtern
                Dim expr1 As CriteriaOperator = CriteriaOperator.Parse("1=2")
                criteriaList.Add(expr1)
            End If

            Dim commonop As CriteriaOperator = GroupOperator.Or(criteriaList)

            'IMPORTANT: Die jüngsten Einträge zuerst
            Debug.Print("Führe Parametersuche aus. SQL=" & commonop.ToString)
            Dim result As BaseCollection(Of itemType) = Me.GetNewCollection(commonop) ' 'MyClass' ignoriert das Shaddows aus einigen Klasen
            result.TopReturnedObjects = 10



            result.Load()
            Debug.Print(" Gefunden:" & result.Count)

            sw.Stop()
            Debug.Print(" Suche dauerte: " & sw.Elapsed.ToString)
            Return result

        End Function


        ''' <summary>
        ''' Ruft eine Liste mit Spaltennamen ab, die für eine Volltextsuche dieser Auflistung benutzer wird oder legt diese fest.
        ''' Diese LIste muss gefüllt sein, bevor die "Search"-Funktion verwendet werden kann
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property FullTextSearchColumns() As String()
            Get
                Return m_FullTextsearchColumns
            End Get
            Set(ByVal value() As String)
                m_FullTextsearchColumns = value
            End Set
        End Property


        ''' <summary>
        ''' Fügt das Objekt der Auflistung hinzu
        ''' </summary>
        ''' <param name="newObject"></param>
        ''' <remarks></remarks>
        Overridable Shadows Sub Add(ByVal newObject As itemType)

            MyBase.Add(newObject)
        End Sub

        ''' <summary>
        ''' Ruft den die Kriterienzeichenfolgge ab oder legt diese fest, 
        ''' Ezwingt ein Filtern auf der Datenbankseite
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shadows Property CriteriaString() As String
            Get
                Return MyBase.CriteriaString
            End Get
            Set(ByVal value As String)
                MyBase.CriteriaString = value
            End Set
        End Property


        'Protected Overrides Sub OnCollectionChanged(ByVal args As DevExpress.Xpo.XPCollectionChangedEventArgs)

        '    If args.CollectionChangedType = XPCollectionChangedType.AfterAdd Then
        '        If Not m_dictionary.ContainsKey(CType(args.ChangedObject, StaticItem).Key) Then
        '            m_dictionary.Add(CType(args.ChangedObject, StaticItem).Key, CType(args.ChangedObject, itemType))
        '        End If
        '    End If
        '    If args.CollectionChangedType = XPCollectionChangedType.AfterRemove Then

        '        If m_dictionary.ContainsKey(CType(args.ChangedObject, StaticItem).Key) Then
        '            m_dictionary.Remove(CType(args.ChangedObject, StaticItem).Key)
        '        End If

        '    End If

        '    MyBase.OnCollectionChanged(args)
        'End Sub

        ''' <summary>
        ''' Liefert die Anzahl der Datensätze zurück, ruft den ganzen Datenbestand ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows ReadOnly Property Count() As Integer
            Get
                Return MyBase.Count

            End Get
        End Property

        ''' <summary>
        ''' Ruft die Anzahl der Datensätze zurück, indem eine Datenbankabfrage mit diesem Filterkriterium gemacht wird
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCount() As Integer
            Return GetCount(String.Empty)
        End Function

        Public Function GetCount(filterCriteria As CriteriaOperator) As Integer
            Dim sql As String = String.Empty

            If filterCriteria IsNot Nothing Then
                sql = filterCriteria.ToString
            End If

            ' FilterCriteria legt die Properties in eckigen Klammern.. diese entfernen. (einfachster Fall)
            sql = sql.Replace("[", "")
            sql = sql.Replace("]", "")
            Return GetCount(sql)
        End Function

        ''' <summary>
        ''' Ermittelt die Anzahl der Datensätze indem direkt eine SQL-Abfrage gemacht wird. 
        ''' Es werden nicht die Datensätze tatsächlich abgeholt
        ''' </summary>
        ''' <param name="sqlcondition">Dem Bedingungsausdruck in SQL-syntax</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCount(sqlcondition As String) As Integer
            Dim sql As String
            Sql = "SELECT COUNT(*) from " & Me.GetObjectClassInfo.TableName

            If Not String.IsNullOrEmpty(sqlcondition) Then
                sql &= " WHERE " & sqlcondition
            End If

            Dim res As Object = m_application.Database.ExcecuteScalar(sql)

            If Not TypeOf res Is DBNull Then ' Bei leeren Tabellen kann DBNull zurückgegeben werden
                Debug.Print("Anzahl Zeilen: " & CInt(res))
                Return CInt(res)
            Else
                Return 0I
            End If


        End Function

        ''' <summary>
        ''' Ruft aus dem Datensatz die höchste ID ab
        ''' Kann zur Bestimmung der nächsten Nummer verwendet werden
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function GetMaxID() As Integer
            Dim Result As Integer = 0
            Dim table As String = ""
            Try
                table = Me.GetObjectClassInfo.TableName
                Dim sql As String = "SELECT MAX(ID) FROM " & table
                Dim res As Object = m_application.Database.ExcecuteScalar(sql)

                If Not TypeOf res Is DBNull Then ' Bei leeren Tabellen kann DBNull zurückgegeben werden
                    Result = CInt(res)
                Else
                    Return 0I
                End If

            Catch ex As Exception
                m_application.Log.WriteLog(ex, "GetMaxID", "Error while getting MAX(ID) from " & table)
            End Try

            Return Result

        End Function

        ''' <summary>
        ''' Ruft ein Element dieses Typs direkt von der DAtenbank ab
        ''' </summary>
        ''' <param name="id">Die nummerische ID des Elementes</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFromDB(ByVal id As Integer) As itemType
            Dim foundItem As itemType
            Dim cr As CriteriaOperator = New BinaryOperator("ID", id, BinaryOperatorType.Equal)
            foundItem = CType(MainApplication.Session.FindObject(GetType(itemType), cr), itemType)
            If foundItem IsNot Nothing Then
                ' Lokal hinzufügen
                If Not m_dictionary.ContainsKey(foundItem.Key) Then
                    m_dictionary.Add(foundItem.Key, foundItem)
                End If
                If Not m_dictionaryId.ContainsKey(foundItem.ID) Then
                    m_dictionaryId.Add(foundItem.ID, foundItem)
                End If
            End If

            Return foundItem
        End Function

        ''' <summary>
        ''' Ruft ein Element dieses Typs direkt aus der Datenbank ab. Gefundene elemente werden lokal vorgehalten.
        ''' </summary>
        ''' <param name="replikID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFromDB(ByVal replikID As String) As itemType
            If Not Me.Session.IsObjectsLoading Then
                Dim foundItem As itemType
                Dim cr As CriteriaOperator = New BinaryOperator("ReplikID", replikID, BinaryOperatorType.Equal)
                foundItem = CType(MainApplication.Session.FindObject(GetType(itemType), cr), itemType)
                If foundItem IsNot Nothing Then
                    ' Lokal hinzufügen
                    If Not m_dictionary.ContainsKey(foundItem.Key) Then
                        m_dictionary.Add(foundItem.Key, foundItem)
                    End If
                    If Not m_dictionaryId.ContainsKey(foundItem.ID) Then
                        m_dictionaryId.Add(foundItem.ID, foundItem)
                    End If
                End If

                Return foundItem
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Löscht alle in dieser Auflistung enthaltenen Elemente
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub Delete()


            Using uw As New UnitOfWork(Me.Session.Dictionary)
                Do While Me.Count > 0
                    Try
                        Me(0).Delete()
                    Catch ex As Exception
                        Debug.Print(" Problem beim Löschen: " & ex.Message)
                    End Try

                Loop
                'uw.Delete...

                uw.CommitChanges()

            End Using

        End Sub
        ''' <summary>
        ''' Speichert alle Elemente dieses Types in die Datenbank ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub Save()

            'Me.Session.BeginTransaction()
            For n As Integer = 0 To Me.Count - 1
                Dim item As itemType = Me(n)
                If item.HasChanged Then
                    item.Save()
                End If

            Next
            ' Me.Session.CommitTransaction()


        End Sub
        ''' <summary>
        ''' Erstellt eine neue Instanz des aktuellen Types
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function GetNewItem() As itemType
            Dim newitem As itemType
            newitem = CType(Activator.CreateInstance(GetType(itemType), New Object() {Me.Session}), itemType)
            newitem.ID = -1 ' Kenntlich machen, das ein neues Element angelegt wird

            Return newitem


        End Function


        ''' <summary>
        ''' Erstellt eine neue Auflistung dieses Typs
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function GetNewCollection() As BaseCollection(Of itemType)
            Dim newItemCollection As New BaseCollection(Of itemType)(m_application)
            Return newItemCollection

        End Function

        ''' <summary>
        ''' Ruft eine neue auflistung mit dem angegebenen Criterianausdruck ab
        ''' </summary>
        ''' <param name="criteria"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function GetNewCollection(ByVal criteria As CriteriaOperator) As BaseCollection(Of itemType)
            Dim newItemCollection As New BaseCollection(Of itemType)(m_application, criteria)
            Return newItemCollection

        End Function

        ''' <summary>
        ''' Prüft auf vorhandensein des Elementes in der Datenbank
        ''' </summary>
        ''' <param name="item"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Contains(ByVal item As itemType) As Boolean

            Return m_dictionary.ContainsKey(item.Key)

        End Function

        ''' <summary>
        ''' Prüft auf vorhandensein dieses Objekt-Schlüssels
        ''' </summary>
        ''' <param name="itemKey">Der 32-Stellige eindeutige Schlüsselwert</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ContainsKey(ByVal itemKey As String) As Boolean

            If Not String.IsNullOrEmpty(itemKey) Then

                If Me.Count = 0 Or Me.Count <> m_dictionary.Count Then   ' ein sicheres Zeichen, das die Liste noch nicht gescannt wurde.. 
                    BuildReplikIDList()
                End If

                Return m_dictionary.ContainsKey(itemKey)
            Else
                Return False
            End If


        End Function

        ''' <summary>
        ''' Zeigt an, ob die interne Datenstrukur initialisiert wurde 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property IsInitilized() As Boolean
            Get
                Return m_dictionaryId IsNot Nothing
            End Get
        End Property
        ''' <summary>
        ''' Holt das Item mit der Datenbank ID 
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function GetItem(ByVal ID As Integer) As itemType
            If m_dictionaryId.ContainsKey(ID) Then
                Return m_dictionaryId(ID)
            Else
                Return GetFromDB(ID)
            End If
        End Function

        ''' <summary>
        ''' Ruft ein Objekt anhand der ReplikID ab
        ''' </summary>
        ''' <param name="ReplikID">Eindeutigen Schlüssel im Datensatz</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function GetItem(ByVal replikID As String) As itemType
            Dim returnItem As itemType = Nothing

            If String.IsNullOrEmpty(replikID) Then
                Return Nothing
            End If
            Try
                If m_dictionary.ContainsKey(replikID) Then
                    Return m_dictionary(replikID)
                Else
                    Return GetFromDB(replikID)
                End If



            Catch ex As DevExpress.Xpo.DB.Exceptions.SchemaCorrectionNeededException
                ' Die DAtenbank scheint nicht aktuell zu sein 
                Debug.Print(ex.Message)
                Tools.ErrorHandler.SQLException(GetType(itemType).Name)
                Return Nothing

                'allgemeine Fehler
            Catch ex As Exception
                Debug.Print(ex.Message)
                Throw

            End Try
        End Function

        Public Overrides Sub Load()

            Dim firstFailed As Boolean
            Try
                MyBase.Load()
            Catch ex As Exception
                firstFailed = True
                m_application.Log.WriteLog(ex, "LOAD", "First Fail")

            End Try

            If firstFailed Then
                ' Mal versuchen ein zweites mal zu laden
                MyBase.Load()
            End If

        End Sub

        ''' <summary>
        ''' Baut die Liste der ReplikIDs neu auf
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub BuildReplikIDList()
            ' Liste aufbauen, wenn leer
            'Debug.Print("Rebuilding cached items list on '" & Me.GetType.Name & "',: " & Me.Count)

            m_dictionary.Clear()
            m_dictionaryId.Clear()
            For Each Item As itemType In Me
                Try
                    m_dictionary.Add(Item.Key, Item)
                    m_dictionaryId.Add(Item.ID, Item)
                Catch ex As Exception
                    Debug.Print(" BuildReplikIDList: Item mit diesem schlüssel existiert bereits: " & Item.ToString)
                End Try

            Next

        End Sub

        ''' <summary>
        ''' Ruft aus der Liste das Objekt mit der angegebnen Ordnungszahl ab
        ''' </summary>
        ''' <param name="id"></param>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Default Public Shadows ReadOnly Property [Object](ByVal id As Integer) As itemType
            Get
                If MyBase.Count > 0 And id < MyBase.Count Then
                    Return MyBase.Object(id)
                Else
                    Return Nothing
                End If

            End Get

        End Property

        ''' <summary>
        ''' Löscht die Auflistung und ruft alle Objekte neu ab
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Reload()
            Dim firstFailed As Boolean
            Try
                MyBase.Reload()
            Catch ex As Exception
                firstFailed = True
                m_application.Log.WriteLog(ex, "RELOAD", "First Fail")
            End Try
            If firstFailed Then
                MyBase.Reload()
            End If

        End Sub
        ''' <summary>
        ''' Legt eine neue Instanz einer Collection an.
        ''' </summary>
        ''' <param name="BaseApplication">Stammklasse die alle weiteren Classen zur verfügung stellt</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal baseApplication As mainApplication)
            MyBase.New(baseApplication.Session)

            BaseCollection(Of itemType).m_application = baseApplication

        End Sub

        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse ohne Kriterien
        ''' </summary>
        ''' <param name="session"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        ''' <summary>
        ''' Erstellt eine neue Instanz der Auflistung mit dem angegebenen Filter
        ''' </summary>
        ''' <param name="session"></param>
        ''' <param name="criteria"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal session As Session, ByVal criteria As CriteriaOperator)
            MyBase.New(session, criteria)
        End Sub

        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse mit einen Criterien-Ausdruck
        ''' </summary>
        ''' <param name="baseApplication"></param>
        ''' <param name="criteria"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal baseApplication As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(baseApplication.Session, criteria)
            m_application = baseApplication

        End Sub



        ''' <summary>
        ''' Stellt den standard-Konstruktor dar; es wird die Session.DefaultSession verwendet
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New(m_application.Session)

        End Sub

        '''' <summary>
        '''' Ruft die Instanz des Stammobjektes ab
        '''' </summary>
        '''' <value></value>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'ReadOnly Property MainApplication() As mainApplication
        '    <DebuggerStepThrough()> _
        '    Get
        '        Return m_application
        '    End Get

        'End Property
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
<ComponentModel.Browsable(False)> _
        Overloads Shared ReadOnly Property MainApplication() As mainApplication
            <DebuggerStepThrough()> _
            Get
                Return m_application
            End Get

        End Property

        ''' <summary>
        ''' Stellt eine Funktion bereit, Auflistungen zu vervielfältigen
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Nothing
        End Function

        ''' <summary>
        ''' Gibt eine Auflistung des aktuellen Typs zurück
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ToArray() As List(Of itemType)
            Dim newList As New List(Of itemType)
            For Each item As itemType In Me
                newList.Add(item)
            Next
            Return newList
        End Function


        Private Sub BaseCollection_CollectionChanged(ByVal sender As Object, ByVal e As DevExpress.Xpo.XPCollectionChangedEventArgs) Handles Me.CollectionChanged
            Dim item As StaticItem = CType(e.ChangedObject, StaticItem)
            If e.CollectionChangedType = XPCollectionChangedType.AfterAdd Then


                If item.ID = -1 Then
                    'Throw New ArgumentException("Es sollte das Item erst gespeichert, dann der Auflistung hinzugefügt werden")
                    'Hmm ? 
                End If
                If Not IsInitilized Then
                    BuildReplikIDList()
                End If

                If Not m_dictionary.ContainsKey(item.Key) Then
                    m_dictionary.Add(item.Key, CType(item, itemType))
                End If

                ' Neue Items haben noch keine gültige ID
                If Not item.ID = -1 And Not m_dictionaryId.ContainsKey(item.ID) Then
                    m_dictionaryId.Add(item.ID, CType(item, itemType))
                End If
                Exit Sub
            End If

            If e.CollectionChangedType = XPCollectionChangedType.AfterRemove Then
                If m_dictionary.ContainsKey(item.Key) Then
                    m_dictionary.Remove(item.Key)
                End If
                If m_dictionaryId.ContainsKey(item.ID) Then
                    m_dictionaryId.Remove(item.ID)
                End If
            End If

        End Sub

        Private Sub BaseCollection_ListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles Me.ListChanged


            If e.ListChangedType = ComponentModel.ListChangedType.Reset Then

                BuildReplikIDList()
            End If
        End Sub

        ''' <summary>
        ''' Ruft eine Auflistung von Spalteninhalten ab
        ''' </summary>
        ''' <param name="tableName"></param>
        ''' <param name="columnName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function GetListOfColumn(ByVal tableName As String, ByVal columnName As String) As String()
            Dim sql As String = "SELECT " & columnName & " FROM " & tableName & " GROUP BY  " & columnName & ""
            Dim dt As DataTable
            dt = MainApplication.Database.GetData(sql)

            Dim sb As New List(Of String)

            For Each item As DataRow In dt.Rows
                sb.Add(item(0).ToString)
            Next

            Return sb.ToArray
        End Function




    End Class


End Namespace