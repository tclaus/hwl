Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Nodes
Imports ClausSoftware.Tools


''' <summary>
''' Stellt eine Auflistung der Hauptmodule dar
''' </summary>
''' <remarks></remarks>
Public Enum HWLModules
    ''' <summary>
    ''' Stellt den Eingangsbildschirm dar
    ''' </summary>
    ''' <remarks></remarks>
    [Homescreen]

    Adressbook

    ''' <summary>
    ''' Stellt statistische Daten zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    Statistics
    ''' <summary>
    ''' Rechnngsvorlagen
    ''' </summary>
    ''' <remarks></remarks>
    Templates
    ''' <summary>
    ''' Artikelliste / Materialstamm
    ''' </summary>
    ''' <remarks></remarks>
    Articles
    ''' <summary>
    ''' Angebote/Rechnungen
    ''' </summary>
    ''' <remarks></remarks>
    Business
    ''' <summary>
    ''' Stellt ein Formular mit regelmässig wiederkehrenden Kosten bereit
    ''' </summary>
    ''' <remarks></remarks>
    FixedCosts

    ''' <summary>
    ''' Stellt das Forderungen/Verbindlichkeiten-Formular bereit
    ''' </summary>
    ''' <remarks></remarks>
    Transactions

    ''' <summary>
    ''' Stellt das Formular des Kassenbuches bereit
    ''' </summary>
    ''' <remarks></remarks>
    CashJournal

    ''' <summary>
    ''' Stellt das Briefe-Formular bereit
    ''' </summary>
    ''' <remarks></remarks>
    Letters
    Scheduler
    Tasks
    ''' <summary>
    ''' Enthält das Modul "Seite einrichten", legt ein Seitenlayout an, das Journaldokumente überlagert
    ''' </summary>
    ''' <remarks></remarks>
    PageSettings
    ''' <summary>
    ''' Kennzeichnet die Anforderung, die Applikation zu beenden
    ''' </summary>
    ''' <remarks></remarks>
    ExitApp
    ''' <summary>
    ''' Öffnet ein Fenster mit einer Globalen Suche
    ''' </summary>
    ''' <remarks></remarks>
    GlobalSearch

    ''' <summary>
    ''' Zeigt eine einfache Aufstellung der Top 10 Produkte / Kunden
    ''' </summary>
    ''' <remarks></remarks>
    StatisticTop10

End Enum

Public Module modmain
    ''' <summary>
    ''' Stellt die einzige Klasse bereit, die einen ZUgang zu allen wesentlichen Tabellen ermöglichgt. 
    ''' Ist die Stammklasse der Applikation
    ''' </summary>
    ''' <remarks></remarks>
    Public m_application As ClausSoftware.mainApplication



    ''' <summary>
    ''' Ruft den Text in der aktuellen Sprache ab 
    ''' </summary>
    ''' <param name="key">Der Schlüssel zum Text.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetText(ByVal key As String) As String
        If m_application IsNot Nothing Then ' es kann sein, das dies bereits im designer aufgerufen wird. 
            Return m_application.Languages.GetText(key)
        Else
            Return key
        End If
    End Function

    ''' <summary>
    ''' Ruft den Text in der aktuellen Sprache ab 
    ''' </summary>
    ''' <param name="defaulttext">Kannd er text mit dem Schlüssel nicht gefunden werden, wird der Standardtext genutzt und gleichzeitig der textauflistung hinzugefügt</param>
    ''' <param name="key">Der Schlüssel zum Text.</param>
    Public Function GetText(ByVal key As String, ByVal defaulttext As String) As String
        If m_application IsNot Nothing Then
            Return m_application.Languages.GetText(key, defaulttext)
        Else
            Return defaulttext
        End If
    End Function

    ''' <summary>
    ''' Ruft den Text in der aktuellen Sprache ab. Übergibt einen StandardText sowie eine Auflistung an Erstezungsparametern
    ''' </summary>
    ''' <param name="key">Ein eindeutiger Schlüssel zum erkennen des Sprachtextes</param>
    ''' <param name="defaulttext">Standardtext der benutzt wird, wenn kein Zugriff auf die Texte-Datenbank existiert</param>
    ''' <param name="params">Eine Auflistung vonParametern, die die {0} - Platzhalter ersetzten</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetText(ByVal key As String, ByVal defaulttext As String, ByVal ParamArray params() As String) As String
        If m_application IsNot Nothing Then
            Return m_application.Languages.GetText(key, defaulttext, params)
        Else
            Return defaulttext
        End If
    End Function

    ''' <summary>
    ''' Key kennzeichnet den Basis-Pfad der Registry (für mehrfacheinträgee) 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub InitializeApplication()
        Try
            If m_application IsNot Nothing Then
                If Not m_application.Session Is Nothing Then
                    If Not m_application.Session.IsConnected Then
                        m_application.Connections.ReadConnections()
                        m_application.Initialize(m_application.Connections.WorkConnection)
                        Exit Sub
                    End If

                End If
            Else
                Debug.Print("Erstelle neue Instanz des Hauptprogramms")
                m_application = New ClausSoftware.mainApplication
            End If


            If m_application.Session Is Nothing OrElse Not m_application.Session.IsConnected Then

                SetStyles()

                m_application.Connections.ReadConnections()
                If ClausSoftware.Tools.Connections.IsValid Then
                    m_application.Initialize(m_application.Connections.WorkConnection)


                End If


            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            ' MessageBox.Show("Ein Fehler trat beim starten der Applikation auf." & vbCrLf & _
            '                ex.Message, "Fehler in Startprozedur", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    ''' <summary>
    ''' Setzt die Styles für Dev-Experess Formulare
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetStyles()
        ' Styles einschalten
        DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = False
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "LILIAN" ' <<< NEW LINE
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetWindowsXPStyle()

        System.Windows.Forms.Application.EnableVisualStyles()

    End Sub

    ''' <summary>
    ''' Schliesst eine aktuelle Verbindung wieder
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloseConnection()
        If m_application IsNot Nothing Then
            m_application.CloseConnection()

        End If



    End Sub



    Friend Sub SaveTreeStyles(ByVal trv As DevExpress.XtraTreeList.TreeList, ByVal context As String)
        Try
            Debug.Print("Sichere Einstellungen des Trees: " & context)
            Debug.Assert(Not String.IsNullOrEmpty(context), "Context kann nicht null sein")

            Dim stream As New System.IO.MemoryStream()

            trv.SaveLayoutToStream(stream)

            m_application.Settings.SetSetting("TreeLayout", context, stream)
        Catch ex As Exception
            m_application.Log.WriteLog(ex, "ERROR", "Error in Saving TreeStyles")
        End Try

    End Sub

    ''' <summary>
    ''' Speichert die Liste aller derzeit geöffneten Nodes ab
    ''' </summary>
    ''' <param name="trv"></param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Public Sub SaveTreeOpenNodes(ByVal trv As DevExpress.XtraTreeList.TreeList, ByVal context As String)
        Try
            Dim openNodes As New System.Text.StringBuilder
            GetOpenNodesList(trv.Nodes, openNodes)


            m_application.Settings.SetSetting("OpenTreeNodes", context, openNodes.ToString)
        Catch ex As Exception
            m_application.Log.WriteLog(ex, "ERROR", "Error inSaveTreeOpenNodes")
        End Try
    End Sub
    Private Sub GetOpenNodesList(ByVal nodes As Nodes.TreeListNodes, ByVal sb As System.Text.StringBuilder)

        For Each item As TreeListNode In nodes
            If item.Expanded Then
                sb.Append(CType(item.TreeList.GetDataRecordByNode(item), ClausSoftware.Data.StaticItem).Key)
                sb.Append(",")
                GetOpenNodesList(item.Nodes, sb)
            End If
        Next

    End Sub

    ''' <summary>
    ''' Stezt die Einstellung des Grids wieder zurück
    ''' </summary>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Friend Sub ResetGridStyles(ByVal context As String)
        m_application.Settings.DeleteSetting("GridLayout", context, m_application.CurrentUser.Key)

    End Sub

    ''' <summary>
    ''' Setzt die Einstellungen des angegebenen Grids im angegebenen Kontext.
    ''' </summary>
    ''' <param name="view">Das Gridview, dessen Einstellungen wieder hergestellt werden sollen</param>
    ''' <param name="context">Eine Bezeichnung zum Identifizieren des Grids</param>
    ''' <returns>true, wenn alte Einstellungen geladen werden konnten, sonst False. (Es lagen keine alten Einstellungen vor oder ein Fehler ist aufgetreten.</returns>
    ''' <remarks></remarks>
    Friend Function RestoreGridStyles(ByVal view As DevExpress.XtraGrid.Views.Base.BaseView, ByVal context As String) As Boolean
        Debug.Print("Lade Einstellungen des Grids" & context)
        Debug.Assert(Not String.IsNullOrEmpty(context), "Context kann nicht null sein")
        'Exit Function

        Try
            Dim value As String = m_application.Settings.GetSetting("GridLayout", context, "")
            value = value.Trim(New Char() {" "c, "?"c})

            If Not String.IsNullOrEmpty(value) Then
                Using mystream As New IO.MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(value))

                    Dim layoutOptions As New DevExpress.Utils.OptionsLayoutGrid
                    layoutOptions.StoreAppearance = False
                    layoutOptions.StoreVisualOptions = False

                    view.RestoreLayoutFromStream(mystream, layoutOptions)
                    mystream.Close()
                End Using

                Dim targetType As System.Type
                Dim propInfo As System.Reflection.PropertyInfo

                Dim gView As DevExpress.XtraGrid.Views.Grid.GridView = CType(view, DevExpress.XtraGrid.Views.Grid.GridView)
                ' Falls nachträglich eigenschaften hinzugefügt wurde, diese nun ausblenden 
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In gView.Columns
                    Dim attr() As DefaultGridVisibleAttribute



                    If gView.DataSource Is Nothing Then Return False

                    ' Im serverMode einen anderen Typ testen !
                    If TypeOf gView.DataSource Is DevExpress.Xpo.Helpers.XpoServerModeCore Then
                        targetType = CType(gView.DataSource, DevExpress.Xpo.Helpers.XpoServerModeCore).ClassInfo.ClassType
                    Else
                        targetType = CType(gView.DataSource, DevExpress.Xpo.XPBaseCollection).GetObjectClassInfo.ClassType
                    End If

                    propInfo = getPropertyByName(col.FieldName, targetType)
                    If propInfo IsNot Nothing Then
                        attr = CType(propInfo.GetCustomAttributes(GetType(DefaultGridVisibleAttribute), True), DefaultGridVisibleAttribute())
                        If attr.Length > 0 Then


                            If attr(0).Visible = EditorBrowsableState.Never Then
                                col.Visible = False
                                col.OptionsColumn.ShowInCustomizationForm = False
                            End If

                        End If
                    Else
                        Debug.Print(" Property konnte nicht gefunden werden!")

                    End If


                Next

                'TODO:  Spalten, die per Layout verloren gegangen sind; hier erzungernermassen hineinziehen !

                '' Sollte ein Feld neu hinzugekommen sein, dann dieses zumindest einblenden 
                'If TypeOf gView.DataSource Is DevExpress.Xpo.XPBaseCollection Then
                '    Dim xcollection As DevExpress.Xpo.XPBaseCollection = CType(gView.DataSource, DevExpress.Xpo.XPBaseCollection)
                '    For Each item As String In xcollection.DisplayableProperties.Split(";"c)
                '        Dim propertyName As String = item

                '        If gView.Columns.ColumnByFieldName(propertyName) Is Nothing Then
                '            ' dann wid eine Spalte vermist.. 
                '            Dim newColumn As New DevExpress.XtraGrid.Columns.GridColumn()
                '            newColumn.FieldName = propertyName

                '            newColumn.Caption = propertyName

                '            newColumn.Visible = False
                '            gView.Columns.Add(newColumn)
                '        End If

                '    Next
                'End If




                Return True
            Else
                If TypeOf view Is DevExpress.XtraGrid.Views.Grid.GridView Then
                    ' dann die standardmäsig nicht sichtbaren Felder ausblenden
                    Dim gView As DevExpress.XtraGrid.Views.Grid.GridView = CType(view, DevExpress.XtraGrid.Views.Grid.GridView)
                    Dim targetType As System.Type

                    If gView.DataSource Is Nothing Then Return False

                    ' Im serverMode einen anderen Typ testen !
                    If TypeOf gView.DataSource Is DevExpress.Xpo.Helpers.XpoServerModeCore Then
                        targetType = CType(gView.DataSource, DevExpress.Xpo.Helpers.XpoServerModeCore).ClassInfo.ClassType
                    Else
                        targetType = CType(gView.DataSource, DevExpress.Xpo.XPBaseCollection).GetObjectClassInfo.ClassType
                    End If

                    ' entsprechend attributierte Properties ausblenden und von de Anzeige entfernen
                    For Each col As DevExpress.XtraGrid.Columns.GridColumn In gView.Columns
                        Dim attr() As DefaultGridVisibleAttribute
                        Dim propInfo As System.Reflection.PropertyInfo

                        propInfo = getPropertyByName(col.FieldName, targetType)
                        If propInfo IsNot Nothing Then
                            attr = CType(propInfo.GetCustomAttributes(GetType(DefaultGridVisibleAttribute), True), DefaultGridVisibleAttribute())
                            If attr.Length > 0 Then
                                If attr(0).Visible = EditorBrowsableState.Advanced Then
                                    col.Visible = False
                                    col.OptionsColumn.ShowInCustomizationForm = True

                                End If

                                If attr(0).Visible = EditorBrowsableState.Never Then
                                    col.Visible = False
                                    col.OptionsColumn.ShowInCustomizationForm = False
                                End If

                                If attr(0).Visible = EditorBrowsableState.Always Then
                                    col.Visible = False
                                    col.OptionsColumn.ShowInCustomizationForm = False
                                    col.OptionsColumn.AllowShowHide = False
                                End If

                            End If
                        Else
                            Debug.Print(" Property konnte nicht gefunden werden!")
                        End If

                    Next
                End If





            End If
        Catch ex As Exception
            m_application.Log.WriteLog(ex, "modMain", "Fehler beim Wiederherstellen des Grids")
        End Try
        Return False

    End Function


    ''' <summary>
    ''' Setzt die Einstellungen des angegebnenen Grids im angegebenen Kontext.
    ''' </summary>
    ''' <param name="grid">Das Grid, dessen einstellungen wieder hergestellt werden sollen</param>
    ''' <param name="context">Eine Bezeichnung zum Identifizieren des Grids</param>
    ''' <returns>true, wenn alte Einstellungen geladen werden konnten, sonst False. (Es lagen keine alten Einstellungen vor oder ein Fehler ist aufgetreten.</returns>
    ''' <remarks></remarks>
    Friend Function RestoreGridStyles(ByVal grid As DevExpress.XtraGrid.GridControl, ByVal context As String) As Boolean
        Return RestoreGridStyles(grid.MainView, context)

    End Function

    ''' <summary>
    ''' Speichert die Einstellungen des Grids 
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Friend Sub SaveGridStyles(ByVal grid As DevExpress.XtraGrid.GridControl, ByVal context As String)
        SaveGridStyles(grid.MainView, context)
    End Sub

    ''' <summary>
    ''' Speichert die Einstellungen des Views eines Grids 
    ''' </summary>
    ''' <param name="view">Das View dessen Layout gesichert wird</param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Friend Sub SaveGridStyles(ByVal view As DevExpress.XtraGrid.Views.Base.BaseView, ByVal context As String)
        Debug.Print("Sichere Einstellungen des Grids: " & context)
        Debug.Assert(Not String.IsNullOrEmpty(context), "Context kann nicht null sein")

        Using mystream As New IO.MemoryStream()
            Dim layoutOptions As New DevExpress.Utils.OptionsLayoutGrid
            layoutOptions.StoreAppearance = False
            layoutOptions.StoreVisualOptions = False

            view.SaveLayoutToStream(mystream, layoutOptions)
            m_application.Settings.SetSetting("GridLayout", context, mystream)
            mystream.Close()
        End Using
    End Sub



    Friend Sub RestoreTreeStyles(ByVal trv As DevExpress.XtraTreeList.TreeList, ByVal context As String)

        Debug.Print("Lade Einstellungen des Trees" & context)
        Debug.Assert(Not String.IsNullOrEmpty(context), "Context kann nicht null sein")
        Try
            Dim value As String = m_application.Settings.GetSetting("TreeLayout", context, "")
            value = value.Trim(New Char() {" "c, "?"c})
            If Not String.IsNullOrEmpty(value) Then
                Dim mystream As New IO.MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(value))

                trv.RestoreLayoutFromStream(mystream)
            Else
                ' Erstmaliges öffnen des Treeviews
                Dim targetType As System.Type

                If TypeOf trv.DataSource Is DevExpress.Xpo.Helpers.XpoServerModeCore Then
                    targetType = CType(trv.DataSource, DevExpress.Xpo.Helpers.XpoServerModeCore).ClassInfo.ClassType
                Else
                    targetType = CType(trv.DataSource, DevExpress.Xpo.XPBaseCollection).GetObjectClassInfo.ClassType
                End If

                For Each col As DevExpress.XtraTreeList.Columns.TreeListColumn In trv.Columns
                    Dim attr() As DefaultGridVisibleAttribute
                    Dim propInfo As System.Reflection.PropertyInfo

                    'propInfo = targetType.GetProperty(col.FieldName, BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.Static Or BindingFlags.FlattenHierarchy)
                    propInfo = getPropertyByName(col.FieldName, targetType)

                    If propInfo IsNot Nothing Then
                        attr = CType(propInfo.GetCustomAttributes(GetType(DefaultGridVisibleAttribute), True), DefaultGridVisibleAttribute())
                        If attr.Length > 0 Then
                            If attr(0).Visible = EditorBrowsableState.Advanced Then
                                col.Visible = False
                                col.OptionsColumn.ShowInCustomizationForm = True

                            End If

                            If attr(0).Visible = EditorBrowsableState.Never Then
                                col.Visible = False
                                col.OptionsColumn.ShowInCustomizationForm = False
                            End If

                            If attr(0).Visible = EditorBrowsableState.Always Then
                                col.Visible = False
                                col.OptionsColumn.ShowInCustomizationForm = False
                            End If

                        End If
                    End If

                Next
            End If
        Catch ex As Exception
            m_application.Log.WriteLog(ex, "modMain", "Fehler beim wiederherstellen des Baumdiagramms", "")
        End Try

    End Sub

    ''' <summary>
    ''' Ruft aus einem gegebenen Typ ein PropertyInfo-Objekt ab. 
    ''' Dabei kannd er Name der Property auch geschachtelt im Format [Property].[Property].. angegeben werdem. 
    ''' Es wird der letzte Propertytyp zurückgegeben
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getPropertyByName(ByVal name As String, ByVal targetType As System.Type) As PropertyInfo
        Dim names() As String = name.Split("."c)
        Dim propInfo As PropertyInfo


        If names.Length > 1 Then
            propInfo = targetType.GetProperty(names(0))
            Return getPropertyByName(names(1), propInfo.PropertyType)
        Else
            propInfo = targetType.GetProperty(names(0))
        End If
        Return propInfo
    End Function

    ''' <summary>
    ''' Öffnet alle bereits geöffnmeten Treenodes wieder
    ''' </summary>
    ''' <param name="trv"></param>
    ''' <param name="context"></param>
    ''' <remarks></remarks>
    Public Sub RestoreTreeOpenNodes(ByVal trv As DevExpress.XtraTreeList.TreeList, ByVal context As String)
        Try
            Dim openNodes As String ' enthält eine Liste mit key-werten und den geöfneten Nodes
            openNodes = m_application.Settings.GetSetting("OpenTreeNodes", context, "")

            For Each key As String In openNodes.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                Dim node As TreeListNode = trv.FindNodeByKeyID(key)
                If node IsNot Nothing Then
                    node.Expanded = True
                End If
            Next

        Catch ex As Exception
            m_application.Log.WriteLog(ex, "ERROR", "Error in RestoreTreeOpenNodes")
        End Try


    End Sub



    ''' <summary>
    ''' Stellt einen einfachen Dialog bereit, der den Anwender bei Änderungen fragt, ob diese verworfen werden sollen
    ''' </summary>
    ''' <returns>Eine Yes/No/Cancel Antwort auf Die Frage "Möchten Sie die geänderten Daten speichern?</returns>
    Public Function AskChangedData() As DialogResult
        Return AskChangedData("")
    End Function

    ''' <summary>
    ''' Stellt einen einfachen Dialog bereit, der den Anwender bei Änderungen fragt, ob diese verworfen werden sollen.
    ''' Der Name des Datensatzes wird im Header aufgenommen
    ''' </summary>
    ''' <returns>Eine Yes/No/Cancel Antwort auf Die Frage "Möchten Sie die geänderten Daten speichern?</returns>
    Public Function AskChangedData(ByVal itemName As String) As DialogResult
        'TODO: NLS


        Return MessageBox.Show("Möchten Sie die geänderten Daten abspeichern?", "Daten wurden geändert", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)

    End Function

    ''' <summary>
    ''' Stellt einen einfachen Dialog bereit, der den Anwender bei Änderungen fragt, ob diese verworfen werden sollen.
    ''' Der Name des Datensatzes wird im Header aufgenommen
    ''' </summary>
    ''' <returns>Eine Yes/No/Cancel Antwort auf Die Frage "Möchten Sie die geänderten Daten speichern?</returns>
    Public Function AskCopySelectedData(ByVal itemcount As Integer) As DialogResult
        'TODO: NLS

        Return MessageBox.Show("Möchten Sie " & itemcount & " Daten kopieren ?", "Daten kopieren", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)

    End Function

    ''' <summary>
    ''' Stellt einen einfachen Dialog bereit, der den Anwender bei Löschen fragt, ob wirklich gelsöcht werden soll
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AskDeleteData(ByVal itemName As String) As DialogResult

        Dim msgAskDeleteDataCaption As String = GetText("msgAskDeleteDataCaption", "Daten löschen: ", itemName)
        Dim msgAskDeleteDataText As String = GetText("msgAskDeleteDataText", "Möchten Sie den gewählten Datensatz wirklich löschen?")

        Return MessageBox.Show(msgAskDeleteDataText, msgAskDeleteDataCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
    End Function

    Public Function AskDeleteData() As DialogResult
        Return AskDeleteData("")
    End Function

    ''' <summary>
    ''' Stellt einen einfachen Dialog bereit, der den Anwender bei Stornieren fragt, ob dies durchgeführt werden soll
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AskCancelDocument(ByVal itemName As String) As DialogResult

        Dim msgAskDeleteDataCaption As String = GetText("msgAskCancelDocumentCaption", "Dokument stornieren", itemName)
        Dim msgAskDeleteDataText As String = GetText("msgAskCancelDocumentText", "Möchten Sie den gewählten Datensatz stornieren?")

        Return MessageBox.Show(msgAskDeleteDataText, msgAskDeleteDataCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3)
    End Function


    ''' <summary>
    ''' Öffnet das angegebene Attachment mit der Windows-Shell
    ''' </summary>
    ''' <param name="attachment"></param>
    ''' <remarks></remarks>
    Friend Sub OpenAttachment(ByVal attachment As ClausSoftware.Kernel.Attachment)
        ' als Datei sichern; 
        Try
            Dim filename As String = attachment.GetFile
            Process.Start(filename)
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Speichert das Attachment an die angegebenen Position
    ''' </summary>
    ''' <param name="attachment"></param>
    ''' <remarks></remarks>
    Friend Sub SaveAttachementAs(ByVal attachment As ClausSoftware.Kernel.Attachment)

        Dim fod As New Vista_Api.SaveFileDialog
        fod.FileName = attachment.FileName

        If fod.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim path As String = System.IO.Path.GetDirectoryName(fod.FileName)
            attachment.GetFile(path)
            Process.Start(path)
        End If
    End Sub




End Module

''' <summary>
''' Enthält eine Auflistung von webadressenm, die direkt aus dem Programm angesprungen werden können
''' </summary>
''' <remarks></remarks>
Public Module webSites
    ''' <summary>
    ''' Enthält die Webadresse mit der Programmrückmeldung / Fehlermeldungen
    ''' </summary>
    ''' <remarks></remarks>
    Public Const wwwUserFeedbackSite As String = "http://claus-software.de"

    ''' <summary>
    ''' Enthält die 'Preise' - webseite
    ''' </summary>
    ''' <remarks></remarks>
    Public Const wwwCloudDatabasePriceWebsite As String = "http://claus-software.de"

    Public Const wwwProductPricesPage As String = "http://claus-software.de"

End Module

''' <summary>
''' Stellt eine Starthilfeklasse dar
''' </summary>
''' <remarks></remarks>
Public Class Main
    Sub New()

    End Sub

    ''' <summary>
    ''' Testet die Datenbankverbindung und bricht gegebenenfalls die Verbindung ab. 
    ''' Der Anwender kann bei einem Fehler per Dialog eine andere Verbindung angeben
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TestConnection() As ClausSoftware.DataBase.DBResult
        Dim myApp As New ClausSoftware.mainApplication
        Dim mydefaultConnection As ClausSoftware.Tools.Connection = myApp.Connections.WorkConnection
        Dim result As New ClausSoftware.DataBase.DBResult()
        Dim myTestDB As ClausSoftware.DataBase.DbEngine

        If mydefaultConnection IsNot Nothing Then
            myTestDB = New ClausSoftware.DataBase.DbEngine(mydefaultConnection)

            result = myTestDB.TestConnection()

        Else
            ' Verbindung konnte gar nicht gefunden werden
            'TODO: NLS
            result.ErrorText = "Es wurde keine Verbindung gefunden"
            result.IsValid = False
            result.Solution = "Erstellen Sie eine neue Verbindung zu einer Datenbank"
        End If

        If Not result.IsValid Then

            Dim frmConnectionError As New frmConnectionValid()
            frmConnectionError.DBResult = result
            frmConnectionError.ShowDialog()

        End If

        Return result


    End Function

    ''' <summary>
    ''' Erstellt eine neue Instanz der Hauptklassen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

        If m_application Is Nothing Then
            m_application = New ClausSoftware.mainApplication
        End If

        AddHandler System.Windows.Forms.Application.ApplicationExit, AddressOf SendApplicationexit


    End Sub

    Public Sub EndApplcation()
        modmain.CloseConnection()

    End Sub

    <ComVisible(False)> _
    ReadOnly Property MainApplication() As ClausSoftware.mainApplication
        Get
            Return m_application
        End Get
    End Property

    ''' <summary>
    ''' Wird aufgerufen, wenn die Aplikation beendet wird.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SendApplicationexit(ByVal sender As Object, ByVal e As EventArgs)
        m_application.UserStats.SendStatistics(ReportMessageType.ApplicationEnd, "Application", "End of Application")
    End Sub

End Class



