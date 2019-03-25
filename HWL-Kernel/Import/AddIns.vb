Imports System.Reflection

Namespace AddIns

    ''' <summary>
    ''' Stellt eine Auflistung von nachgeladnenen Modulen bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AddInManager



        ''' <summary>
        ''' Stellt eine Auflistung von Klassen zur Verfügung, die als AddIn genutzt werden können
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)>
        Private m_AddInsList As New List(Of AddIns.IImportAddIn)
        ''' <summary>
        ''' Die verlängerung des Basispfades in dem die AddOns (Connectors) enthaltn sind
        ''' </summary>
        ''' <remarks></remarks>
        Private Const PathNameExtension As String = "connectors"

        ''' <summary>
        ''' Ruft die Liste der aktuellen AddIns ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property AddIns() As List(Of AddIns.IImportAddIn)
            Get
                Return m_AddInsList
            End Get
        End Property

        ''' <summary>
        ''' Nachladen: Aus dem Programme-Verzeichnis, dann aus dem lokalem Benutzerverzeichnis.
        ''' eine bestehende Auflistung wird überschrieben. Nachladen sollte man pro Programmsitzung nur einmal. 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadAddins()

            m_AddInsList.Clear()
            m_AddInsList.AddRange(GetAssemblies(My.Application.Info.DirectoryPath)) ' suche im eignen (Anwendungs-Binärpfad

            m_AddInsList.AddRange(GetAssemblies(System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, MainApplication.ApplicationName))) ' suche in 'eigenen Dokumente\HWL-2'

        End Sub


        ''' <summary>
        ''' Ruft die Liste der Assemblies vom angegebenen Pfad ab. 
        ''' </summary>
        ''' <param name="pathName">Der Basis pfad der Addins</param>
        ''' <returns>eine Auflistung von Importer-Instanzen</returns>
        ''' <remarks></remarks>
        Private Function GetAssemblies(ByVal pathName As String) As List(Of AddIns.IImportAddIn)

            Dim searchPathName As String = System.IO.Path.Combine(pathName, PathNameExtension) ' Vollen Pfadnamen erstellen

            Dim addinList As New List(Of AddIns.IImportAddIn)

            MainApplication.getInstance.log.WriteLog("Searching  in """ & searchPathName & """ for AddIns")

            If Not System.IO.Directory.Exists(searchPathName) Then  ' Pfad vorhanden ? 
                Debug.Print("  Pfad nicht gefunden oder leer:" & searchPathName)
                Return addinList  ' Leere Liste zurückgeben
            End If

            Dim MyAddinPointTypeName As String = GetType(ClausSoftware.AddIns.IImportAddIn).Name


            ' Alle Dateien in diesem Ordner und allen Unterordner durchsuchen
            For Each filename As String In System.IO.Directory.GetFiles(searchPathName, "*.dll", System.IO.SearchOption.AllDirectories)



                Try
                    Dim a As Assembly = Assembly.LoadFrom(filename)

                    MainApplication.getInstance.log.WriteLog("  Testing """ & a.GetName.ToString & """ if it has Addin Classes...")

                    Dim itemFound As Boolean = False
                    For Each addinPoint As Type In a.GetTypes
                        If addinPoint.GetInterface(MyAddinPointTypeName) IsNot Nothing Then
                            Dim connector As AddIns.IImportAddIn = CType(Activator.CreateInstance(addinPoint), ClausSoftware.AddIns.IImportAddIn)
                            connector.StartUp(MainApplication.getInstance)
                            addinList.Add(connector)
                            itemFound = True

                        End If

                    Next
                    If Not itemFound Then
                        ' entladen nicht unterstützt
                    End If
                Catch ex As Exception
                    MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.ErrorMessage, "Error while opening Addin: " & filename & ". ErrorText:' " & ex.Message)
                End Try
            Next

            Return addinList

        End Function

    End Class

End Namespace