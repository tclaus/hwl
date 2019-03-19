Option Explicit On
Option Strict On


Imports DevExpress.Xpo
Imports ClausSoftware.Data
Imports System.Drawing

Namespace Kernel

    Public Enum DeleteMode
        ''' <summary>
        ''' Verschiebt alle Untergruppoen und enthaltene Artikel an die nächst höhere ebene
        ''' </summary>
        ''' <remarks></remarks>
        MoveSubGroupsToParent

        ''' <summary>
        ''' Löscht alle darunterliegende Gruppen und Artikel
        ''' </summary>
        ''' <remarks></remarks>
        DeleteSubgroups
    End Enum

    ''' <summary>
    ''' Stellt eine Artikelgruppe dar
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerDisplay("Gruppenname: {Name}")> _
    <Persistent(Group.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Group
        Inherits StaticItem
        Implements IDataItem

        Friend Const Tablename As String = "Material_Gruppen"

        ''' <summary>
        ''' Ruft eine Textuelle Liste aller Untergruppen ab
        ''' </summary>
        ''' <remarks></remarks>
        Private m_groupList As New List(Of String)

        ''' <summary>
        ''' enthält die Liste der aktuellen Subgruppen
        ''' </summary>
        ''' <remarks></remarks>
        Private m_subGroups As Groups

        Private m_hasImage As Boolean

        Private m_classdefinition As Attributes.ClassDefinition

#Region "Properties"

        'insert into Material_Gruppen (Name,replikid,deleted,parentID)
        'select name,replikid,0,GruppenID from Material_Kategorien
        ' where replikid not in (select replikid from Material_Gruppen)



        ''' <summary>
        ''' Enthält den Gruppen-Namen
        ''' </summary>
        ''' <remarks></remarks>
        Private m_name As String = ""
        Private m_childList As String
        ''' <summary>
        ''' Enthält die Beshreibung der Gruppe
        ''' </summary>
        ''' <remarks></remarks>
        Private m_groupDescription As String = String.Empty


        ''' <summary>
        ''' Enthält; falls vorhanden ein Gruppen-Bild
        ''' </summary>
        ''' <remarks></remarks>
        Private m_Image As Image

        ''' <summary>
        ''' Enthält eine Unter-Gruppe
        ''' </summary>
        ''' <remarks>Unter-Gruppen kommen aus den Kategorieren, und werden als Parent-Child-Beziehung gesichert</remarks>
        Private m_subGroup As Group

        Private m_parentID As String

        ''' <summary>
        ''' Zeigt an, das der Inhalt dieser Gruppe zum externen kopieren bereitgestellt wird
        ''' </summary>
        ''' <remarks></remarks>
        Private m_copyToWeb As Boolean

        ''' <summary>
        ''' Zeigt an, das diese Grupppe durch einen (Datanorm) Import erzeugt wurde
        ''' </summary>
        ''' <remarks></remarks>
        Private m_isextern As Boolean


        Private m_dtnUnterWarenGruppe As String = String.Empty
        Private m_dtnHauptWarengruppe As String = String.Empty
        ''' <summary>
        ''' enthält den Datanorm Ersteller
        ''' </summary>
        ''' <remarks></remarks>
        Private m_dtnErsteller As String = String.Empty


        ''' <summary>
        ''' Enthält eine Interne Warengruppennummer; Dient zur Identifikation von gleichnamigen Gruppen bei Datenimport
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
            <Tools.DisplayName("DTNUnterWarengruppe", "Datanorm Warengruppe")> _
            <Persistent("DTNWarengruppe")> _
        Public Property DTNUnterWarengruppe() As String
            Get
                Return m_dtnUnterWarenGruppe
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("DTNUnterWarengruppe", m_dtnUnterWarenGruppe, value)
            End Set
        End Property


        ''' <summary>
        ''' Enthält eine Interne Haupt-Warengruppennummer; Dient zur Identifikation von gleichnamigen Gruppen bei Datenimport
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
            <Tools.DisplayName("DTNHauptWarengruppe", "Datanorm Hauptwarengruppe")> _
            <Persistent("DTNHauptWarengruppe")> _
        Public Property DTNHauptWarengruppe() As String
            Get
                Return m_dtnHauptWarengruppe
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("DTNHauptWarengruppe", m_dtnHauptWarengruppe, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Datanorm - Ersteller ab oder legt diesen fest sofern der DAtensatz durch einen Datanorm - Import erstellt wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
            <Tools.DisplayName("DTNErsteller", "Datanorm Ersteller")> _
            <Persistent("DTNErsteller")> _
        Public Property DTNErsteller() As String
            Get
                Return m_dtnErsteller
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("DTNErsteller", m_dtnErsteller, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen Beschreibungstext der Gruppe ab (Marketingtext) oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("Description", "Beschreibung")> _
        <Size(255)> _
        <Persistent("Description")> _
        Public Property Description() As String
            Get
                Return m_groupDescription
            End Get
            Set(ByVal value As String)
                If Not value Is Nothing Then
                    If value.Length > 255 Then value = value.Substring(0, 254)
                    m_groupDescription = value
                Else
                    m_groupDescription = String.Empty
                End If

            End Set
        End Property


        ''' <summary>
        ''' Zeigt an, ob ein Bild existiert oder nicht; existiert zu einer diesem Eintrag kein Bild, dann wird ein Platzhalter-Bild zurückgegeben
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("HasImage")> _
        Public Property HasImage() As Boolean
            Get
                Return m_hasImage
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("HasImage", m_hasImage, value)
            End Set
        End Property

            ''' <summary>
            ''' Ruft das dieser Gruppe zugewiesene Bild ab
            ''' </summary>
            ''' <returns></returns>
            ''' <remarks></remarks>
        Function GetImage() As Image

            If HasImage Then
                Dim imagelist() As ImageData = MainApplication.Images.GetReferencedImage(Me.Key)

                If imagelist IsNot Nothing AndAlso imagelist.Length > 0 Then
                    Return imagelist(0).Image
                End If
            End If

            Return My.Resources.no_picture

        End Function

        ''' <summary>
        ''' Speichert ein Symbolbild für diese Gruppe ab und benutzt Name und Beschreibung dieser Gruppe
        ''' </summary>
        ''' <param name="groupPicture"></param>
        ''' <remarks></remarks>
        Public Sub SetImage(ByVal groupPicture As Image)
            Dim newImagedata As New ImageData(MainApplication.Session)
            newImagedata.Description = Me.Description
            newImagedata.FileDate = Date.Today
            newImagedata.Name = Me.Name
            newImagedata.ReferenceID = Me.Key
            Me.SetImage(newImagedata)
        End Sub

        ''' <summary>
        ''' Legt ein Bild für diese Gruppe fest
        ''' </summary>
        ''' <param name="groupPicture"></param>
        ''' <remarks></remarks>
        Public Sub SetImage(ByVal groupPicture As ImageData)
            Dim imagelist() As ImageData = MainApplication.Images.GetReferencedImage(Me.Key)

            For Each item As ImageData In imagelist
                item.Delete()
            Next
            If groupPicture IsNot Nothing Then
                groupPicture.ReferenceID = Me.Key
                groupPicture.Save()
                Me.HasImage = True
            Else
                Me.HasImage = False
            End If

        End Sub

        ''' <summary>
        ''' Ruft den Schlüssel des Vater-Objektes ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <ComponentModel.Browsable(False)> _
        <Persistent("ParentID")> _
        <Size(32)> _
        Property ParentID() As String
            Get
                If m_parentID Is Nothing Then
                    m_parentID = ""
                End If

                Return m_parentID
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    value = Groups.RootID
                End If

                If value.Length = 0 Then
                    value = Groups.RootID
                End If

                SetPropertyValue(Of String)("ParentID", m_parentID, value)

            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, das der Inhalt dieser Gruppe extern übertragen werden kann
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Extern bereitstellen")> _
        <ComponentModel.Browsable(True)> _
                <Persistent("CopyToWeb")> _
                Property CopyExtern() As Boolean
            Get
                Return m_copyToWeb
            End Get
            Set(ByVal value As Boolean)

                SetPropertyValue(Of Boolean)("CopyExtern", m_copyToWeb, value)

            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, das diese Gruppe durch einen Import erzeugt wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Ist extern")> _
        <ComponentModel.Browsable(True)> _
                <Persistent("QuelleDatanorm")> _
        Property IsExtern() As Boolean
            Get
                Return m_isextern
            End Get
            Set(ByVal value As Boolean)
                m_isextern = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft alle Artikel ab, die genau dieser Gruppe zugewiesen wurden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Artikel")> _
        ReadOnly Property Articles() As Articles
            Get
                Dim newArticles As New Articles(Me.MainApplication)
                newArticles.Criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("GroupID='" & Me.Key & "'")
                Return newArticles
            End Get
        End Property

        ''' <summary>
        ''' Ruft die Anzahl der Artikel in dieser Gruppe ab; 
        ''' Es wird eine Datenbankabfrage gemacht.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ArticleCountInGroup As Integer
            Get
                Return MainApplication.ArticleList.GetCount("GruppenID='" & Me.Key & "'")
            End Get
        End Property


        ''' <summary>
        ''' Zeigt an, ob dieser Gruppe oder einer untergeordneten Gruppe Artikel zugwiesen wurden
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function HasArticles() As Boolean

            Dim sw As New Stopwatch
            sw.Start()
            Debug.Print("Hat Artikel:" & Me.Name)


            ' diese Gruppe und alle Untergruppen fragen, ob Artikel existieren
            ' hole eine Liste mit dieser GruppenID und alle Gruppen, die diese ID als VaterID haben
            Dim sql As String
            sql = "select count(*) from Materialliste where GruppenID='" & Me.Key & "'"
            ' Artikeldb fragen, ob Artikel mit diesr Db existiert, dann den ganzen Gruppenbaum traversieren,um alle Gruppen zu fragen

            Dim countItems As Integer = CInt(m_mainApplication.Database.ExcecuteScalar(sql))
            If countItems > 0 Then Return True ' der beste Fall; Gruppe hat Artikel

            ' wennn nicht, prüfe alle Subgroups


            Dim repID As String = Me.ReplikID
            Dim ids As New Stack(Of String)
            ids.Push(repID) ' oberste ReplikID auf dem Stack legen

            Dim currenentGroup As Group = Me

            'todo: Iterativ alle Subgroups dannach fragen, ob dort Artikel eingefügt sind
            Do While ids.Count > 0
                Debug.Print(CStr(ids.Count))
                currenentGroup = MainApplication.Groups.GetItem(ids.Pop)
                If currenentGroup IsNot Nothing Then
                    ' Zähle alle Artikel dieser Gruppe
                    sql = "select count(*) from Materialliste where GruppenID='" & currenentGroup.Key & "'"
                    ' Artikeldb fragen, ob Artikel mit diesr Db existiert, dann den ganzen Gruppenbaum traversieren,um alle Gruppen zu fragen

                    Dim countsubItems As Integer = CInt(m_mainApplication.Database.ExcecuteScalar(sql))

                    If countItems > 0 Then
                        Debug.Print(sw.Elapsed.ToString & " HasArticles: true")
                        Return True ' der beste Fall; Gruppe hat Artikel, sofortiger Rückzug
                    Else
                        ' gehe nun alle weiteren Gruppen durch

                        If currenentGroup.SubGroups.Count > 0 Then

                            ' alle Subgroups auf dem Stack legen
                            For Each subGroup As Group In currenentGroup.SubGroups
                                ids.Push(subGroup.ReplikID)
                            Next
                        End If
                    End If
                End If
            Loop

            Debug.Print(sw.Elapsed.ToString & " HasArticles: False")
            Return False

        End Function

        ''' <summary>
        ''' Ruft eine Auflistung aller Untergruppen ab 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSubGroupList() As List(Of String)

            If String.IsNullOrEmpty(ChildList) Then
                m_groupList.Clear()
                m_groupList.Add(Me.Key)
                Dim IDList As New System.Text.StringBuilder

                For Each subGroup As Group In Me.SubGroups

                    m_groupList.AddRange(subGroup.GetSubGroupList())
                Next

                For Each item As String In m_groupList
                    IDList.Append(item)
                    IDList.Append(",")
                Next
                Me.ChildList = IDList.ToString
                If Me.ChildList.Length > 0 Then ' das letzte KOmma entfernen
                    Me.ChildList = Me.ChildList.Remove(Me.ChildList.Length - 1, 1)
                End If
            Else
                ' aus der ChildList eine Liste machen 
                If m_groupList.Count = 0 Then
                    For Each item As String In Me.ChildList.Split(","c)
                        m_groupList.Add(item)
                    Next
                End If
            End If



            Return m_groupList
        End Function

        ''' <summary>
        ''' Setzt den Cache mit der Gruppenliste wieder zurück
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ResetsubGroupCache()
            m_groupList.Clear()
        End Sub
        ''' <summary>
        ''' Ruft eine Liste mit unter-Gruppen ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function SubGroups() As Groups

            Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("ParentID='" & Me.Key & "'")

            m_subGroups = New Groups(MainApplication, criteria)

            Return m_subGroups

        End Function

        ''' <summary>
        ''' Ruft die übergeordnete Gruppe ab, sofern vorhanden oder setzt diese
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ParentGroup() As Group
            Get
                Return MainApplication.Groups.GetItem(Me.ParentID)

            End Get
            Set(ByVal value As Group)
                If value IsNot Nothing Then
                    Me.ParentID = value.ReplikID
                Else
                    Me.ParentID = Groups.RootID
                End If
            End Set
        End Property

        ''' <summary>
        ''' Ist True, wenn die betrachtetet Gruppe die oberste Gruppe ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property IsRootGroup() As Boolean
            Get
                Return Me.Key.Equals(Groups.RootID, StringComparison.InvariantCultureIgnoreCase)
            End Get
        End Property
        ''' <summary>
        ''' Ruft einen Komma-Getrennte Auflistung aller Kinder-Gruppen dieser Gruppe ab
        ''' Diese Auflistung muss neu erstellt werdem wenn sich die Kinder ändern.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DevExpress.Xpo.Size(SizeAttribute.Unlimited)> _
        <Persistent("ChildList")> _
        Property ChildList() As String
            Get
                Return m_childList
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ChildList", m_childList, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen der Gruppe ab oder öegt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Name")> _
        Public Property Name() As String
            <DebuggerStepThrough()> _
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                If value.Length > 250 Then
                    value = value.Substring(0, 249)
                End If

                SetPropertyValue(Of String)("Name", m_name, value)
            End Set
        End Property



#End Region

        ''' <summary>
        ''' Ruft die Klassifikation zu dieser Gruppe ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property AttributeClass() As Attributes.ClassDefinition
            Get
                If m_classdefinition Is Nothing Then
                    m_classdefinition = MainApplication.ClassDefinitions.GetItemByItemGroup(Me.Key)

                    ' Wird die Gruppe frisch angelegt, ist die Klassifiktion noch nicht korrekt gefüllt
                    If m_classdefinition.Group Is Nothing Then
                        m_classdefinition.Group = Me
                    End If

                End If
                Return m_classdefinition
            End Get
        End Property

        Public Overloads Sub Delete(ByVal mode As DeleteMode)
            Select Case mode
                Case DeleteMode.DeleteSubgroups : DeleteWithSubgroups()
                Case DeleteMode.MoveSubGroupsToParent : DeleteAndMove()
            End Select
        End Sub

        ''' <summary>
        ''' Löscht alle Untergruppen und die darin enthaltenen Artikel
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DeleteWithSubgroups()


            Dim list As String = ""
            For Each item As String In Me.GetSubGroupList
                list += "'" & item & "',"
            Next
            list = list.Trim(","c)

            Dim sql As String = "delete from " & Article.TableName & " where GruppenID in (" & list & ")" ' Artikel entfrenen

            MainApplication.Database.ExcecuteScalar(sql)

            'Alle Kinder löschen
            sql = "delete from " & Group.Tablename & " where ParentID in (" & list & ")"
            MainApplication.Database.ExcecuteScalar(sql)

            ' Die eigene Gruppe auch löschen !
            'sql = "delete from " & Group.Tablename & " where ReplikID ='" & Me.Key & "'"
            'MainApplication.Database.ExcecuteScalar(sql)

            Me.Delete()

        End Sub
        ''' <summary>
        ''' Löscht den Gruppeneintrag und verschiebt alle Elemente dadrunter eine Ebene höher.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub DeleteAndMove()
            Try
                Dim sql As String = "UPDATE FROM " & Article.TableName & " SET GruppenID='" & Me.ParentID & "' WHERE GruppenID='" & Me.Key & "'"

                MainApplication.Database.ExcecuteScalar(sql)

                sql = "UPDATE FROM " & Group.Tablename & " SET ParentID='" & Me.ParentID & "' WHERE ParentID='" & Me.Key & "'"
                MainApplication.Database.ExcecuteScalar(sql)

                Me.ParentGroup.Reload() ' Vater-Gruppe die Liste der Subgroups neu aufbauen lassen !

                MyBase.Delete()

            Catch ex As Exception
                Debug.Print("Delete Group: " & ex.Message)
            End Try

        End Sub


        Public Overrides Sub Save()
            MyBase.Save()
            m_mainApplication.SendMessage(m_mainApplication.Languages.GetText("msgCommonelementSaved", "Gespeichert: '{0}'", Me.ToString))

        End Sub

        Public Sub New(ByVal session As Session)
            MyBase.New(session)


        End Sub
    End Class
End Namespace
