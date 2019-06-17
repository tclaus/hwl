Imports ClausSoftware.Tools
Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO

Public Enum ImportTargetType
    Adresses
    Articles

End Enum


Public Class ImporterController

    Friend application As ClausSoftware.MainApplication

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Private m_filename As String

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Private m_importType As ImportTargetType

    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Private m_TargetAttributes As New List(Of ImportPropertyInfo)

    ''' <summary>
    ''' Enthält die Datentabelle mit den zu Importierenden Daten
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Private m_DataTable As System.Data.DataTable

    ''' <summary>
    ''' Enthält die Aufstellung der Spaltenzuweisungem
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Private m_mappings As New Mappings

    ''' <summary>
    ''' Stellt eine Auflistung der möglichen ZielAttribute bereit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property TargetAttributes() As List(Of ImportPropertyInfo)
        Get
            Return m_TargetAttributes
        End Get
    End Property

    ''' <summary>
    ''' Der Typ der eingelesen werden soll (Ziel Klasse)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImportType() As ImportTargetType
        Get
            Return m_importType
        End Get
        Set(ByVal value As ImportTargetType)
            m_importType = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft eine Textübersetzung ab
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="defaultValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetText(ByVal key As String, ByVal defaultValue As String) As String
        Return application.Languages.GetText(key, defaultValue)
    End Function


    ''' <summary>
    ''' Legt den Namen des einzulesenden Datei fest oder ruft diese ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImportFileName() As String
        Get
            Return m_filename
        End Get
        Set(ByVal value As String)
            m_filename = value

            Try
                m_basePath = System.IO.Path.GetDirectoryName(value)

            Catch ex As Exception
                MessageBox.Show(ex.Message, GetText("msgErrorReadingImportFile", "Fehler beim einlesen der Datei"), MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End Set
    End Property

    Private m_basePath As String

    ''' <summary>
    ''' Ruft den Basis-Pfad der Importierenden Datei ab
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property BaseImportPath As String
        Get
            Return m_basePath
        End Get
    End Property


    Public Sub ShowMainImport()
        Try
            Using frm As New frmMainImport

                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.ImportFileName = frm.FileName
                    Me.ImportType = frm.ImportType
                    LoadMapping()
                    ShowImportOptions()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Ein Fehler ist aufgetreten: " & ex.Message, "Fehler in der Anzeige des Importers", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub

    ''' <summary>
    ''' Ermittelt eine Aufstellung aller Zielattribute
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GenerateTargetAttributeList()
        Dim p As System.Reflection.PropertyInfo()

        Select Case Me.ImportType
            Case ImportTargetType.Adresses : p = GetType(ClausSoftware.Kernel.Adress).GetProperties()
            Case ImportTargetType.Articles : p = GetType(ClausSoftware.Kernel.Article).GetProperties()
            Case Else
                Throw New NotImplementedException("Der Typ: '' kann nicht eingelesen werden")
                Exit Sub
        End Select




        Dim attr As ImportableAttribute()
        TargetAttributes.Clear()

        For Each prop As System.Reflection.PropertyInfo In p
            Debug.Print("Prüfe Property: '" & prop.Name & "'")
            attr = CType(prop.GetCustomAttributes(GetType(ImportableAttribute), True), ImportableAttribute())

            If attr.Length = 1 Then ' Zum Import markiert
                Dim propertyInfo As New ImportPropertyInfo

                Dim disp As System.ComponentModel.DisplayNameAttribute() = CType(prop.GetCustomAttributes(GetType(System.ComponentModel.DisplayNameAttribute), True), System.ComponentModel.DisplayNameAttribute())

                If disp.Length > 0 Then
                    propertyInfo.DisplayName = disp(0).DisplayName

                Else
                    propertyInfo.DisplayName = prop.Name

                End If

                propertyInfo.PropertyName = prop.Name

                TargetAttributes.Add(propertyInfo)

            End If

        Next

    End Sub

    Event CounterIncreases(ByVal count As Integer, ByVal maxcount As Integer)

    ''' <summary>
    ''' Startet einen Asynchronen Vorgang um die gewählten Daten zu impiotrtieren
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub StartImport()

        If m_mappings.Count = 0 Then
            MessageBox.Show("Es wurden keine Zuweisungen vorgenommen.", "Keine Zuweisung gefunden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If m_DataTable.Rows.Count = 0 Then
            MessageBox.Show("Die zu importierende Tabelle enthält keine Werte", "Datenquelle ist leer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        SaveMapping()
        Dim tstart As New Threading.ThreadStart(AddressOf StartImportAsnc)
        Dim t As New Threading.Thread(tstart)
        t.Name = "Datenimport aus Datei :" & Me.ImportFileName
        t.Start()

    End Sub

    ''' <summary>
    ''' Startet den Import anhand des Mappings
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub StartImportAsnc()
        ' 1. Mapping wurde festgelegt
        ' Ziel-Typ bestimmt
        ' Daten im Datatable vorhanden 



        Dim rowNumber As Integer

        For Each item As DataRow In m_DataTable.Rows
            'MainApplication.getInstance.SendProgress("", rowNumber, m_DataTable.Rows.Count - 1)
            Dim newItem As ClausSoftware.Data.StaticItem
            'Neues Element abholen
            Select Case Me.ImportType
                Case ImportTargetType.Adresses
                    newItem = application.Adressen.GetNewItem

                Case ImportTargetType.Articles
                    newItem = application.ArticleList.GetNewItem
                Case Else
                    Throw New NotImplementedException("Der Typ existiert nicht")
            End Select

            For Each targetI As Mapping In Me.m_mappings
                If targetI.Target IsNot Nothing And targetI.Active Then

                    ' Zielwert ermitteln
                    Dim orgValue As Object = newItem.GetType.GetProperty(targetI.Target.PropertyName).GetValue(newItem, Nothing)
                    Dim TargetValue As Object

                    If TypeOf orgValue Is String Then
                        TargetValue = CStr(orgValue) & " " & item(targetI.SourceID).ToString ' Mehrfache Strings aneinander hängen 
                    Else

                        TargetValue = item(targetI.SourceID)
                        Dim orgType As System.Type = newItem.GetType.GetProperty(targetI.Target.PropertyName).PropertyType

                        If Not TargetValue.GetType Is orgType Then

                            If orgType.Equals(GetType(Int16)) Then
                                TargetValue = CInt(TargetValue)
                            End If

                            If orgType.Equals(GetType(Int32)) Then
                                TargetValue = CInt(TargetValue)
                            End If
                            If orgType.Equals(GetType(Decimal)) Then
                                TargetValue = CDec(TargetValue)
                            End If

                            If orgType.Equals(GetType(Double)) Then
                                TargetValue = CDbl(TargetValue)
                            End If
                            'TODO: Bild einfügen.. ? 
                            ' Quelle ist ein Dateiname / Bildpfad => Ziel ist das Image selber
                            If orgType.Equals(GetType(System.Drawing.Image)) Then

                                ' Dann ist Target der Name oder Pfad eines Bildes
                                Try

                                    Dim path As String = CStr(TargetValue)
                                    ' BaseImportPath
                                    ' Kann vollständiger Pfad sein oder nur der Dateiname
                                    path = System.IO.Path.Combine(Me.BaseImportPath, path)
                                    Dim image As System.Drawing.Image = System.Drawing.Image.FromFile(path)
                                    TargetValue = image
                                Catch ex As Exception
                                    application.log.WriteLog("ERROR Importing Image Data: " & ex.Message)
                                End Try


                            End If

                        End If



                    End If

                    'Zielwert setzen
                    newItem.GetType.GetProperty(targetI.Target.PropertyName).SetValue(newItem, TargetValue, Nothing)

                End If

            Next
            newItem.Save()
            rowNumber += 1
            'Dim showCounter As Boolean
            'If rowNumber < 25 Then
            '    showCounter = True
            'Else
            '    If rowNumber Mod 10 = 0 Then
            '        showCounter = True
            '    Else
            '        showCounter = False
            '    End If
            'End If
            'If showCounter Then RaiseEvent CounterIncreases(rowNumber, m_DataTable.Rows.Count)
            RaiseEvent CounterIncreases(rowNumber, m_DataTable.Rows.Count)
        Next
        ' Ende mitteilen
        RaiseEvent CounterIncreases(rowNumber, m_DataTable.Rows.Count)
        MessageBox.Show(rowNumber & "  " & "Daten wurden importiert.", "Abgeschlossen", MessageBoxButtons.OK)

    End Sub

    ''' <summary>
    ''' Speichert das Mapping anhand des Dateinamens  der zu Importierenden Datei
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub SaveMapping()
        Dim xs As New Xml.Serialization.XmlSerializer(GetType(Mappings))
        Dim o As New System.IO.MemoryStream

        xs.Serialize(o, m_mappings)

        Dim filename As String = System.IO.Path.GetFileName(Me.ImportFileName)

        application.Settings.SetSetting("ImportMapping_" & filename, "Mappings", o)
        application.Settings.Save()

    End Sub

    ''' <summary>
    ''' Läd das Mapping. Grundlage ist der Dateiname. Existiert noch kein Mapping - dann nichts
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub LoadMapping()
        Dim filename As String = System.IO.Path.GetFileName(Me.ImportFileName)
        Dim data As String = application.Settings.GetSetting("ImportMapping_" & filename, "Mappings", "")

        If Not String.IsNullOrEmpty(data) Then
            Using o As New System.IO.MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(data))

                Dim xs As New Xml.Serialization.XmlSerializer(GetType(Mappings))
                m_mappings = CType(xs.Deserialize(o), Mappings)
                o.Close()
            End Using

        End If

    End Sub

    ''' <summary>
    ''' Optionen-Fenster anzeigen lassen 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ShowImportOptions()

        Try
            GenerateTargetAttributeList()

            Using frm As New frmImportOptions
                frm.Filename = Me.ImportFileName
                For Each item As ImportPropertyInfo In Me.TargetAttributes
                    frm.TargetAttributes.Add(item.PropertyName, item)
                Next

                m_DataTable = GetImportData(Me.ImportFileName, True)

                If m_mappings.Count = 0 Then
                    SetMappings()
                End If

                frm.Mappings = m_mappings
                frm.ImportController = Me
                frm.ShowDialog()
            End Using

        Catch ex As Exception
            application.log.WriteLog(ex, "Fehler", "Importer Addin")
            'TODO: NLS
            MessageBox.Show("Fehler im Import: " & ex.Message, "Fehler aufgetreten.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


        End Try

    End Sub
    ''' <summary>
    ''' Ruft das Mapping anhand der Datenquelle ab
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub SetMappings()
        m_mappings.Clear()

        For Each col As System.Data.DataColumn In m_DataTable.Columns
            m_mappings.Add(New Mapping With {.Active = True, .Source = col.Caption, .SourceID = m_DataTable.Columns.IndexOf(col)})
        Next

    End Sub
    Private Function GetImportData(ByVal filename As String, ByVal firstLineIsHeadline As Boolean) As System.Data.DataTable

        If Not System.IO.File.Exists(filename) Then
            MessageBox.Show("Die Datei '" & System.IO.Path.GetFileName(filename) & "' konnte nicht gefunden werden", "Datei nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return Nothing

        End If
        Dim filename1 As String = filename
        Dim fields As String()
        Dim delimiter As String = ";"

        Dim dt As New System.Data.DataTable

        Using parser As New TextFieldParser(filename1, System.Text.UTF7Encoding.UTF7)
            parser.SetDelimiters(delimiter)


            If firstLineIsHeadline Then ' Überschrift einlesen
                ' Read in the fields for the current line
                fields = parser.ReadFields()
                ' Add code here to use data in fields variable.
                Dim number As Integer
                For Each item As String In fields
                    Dim col As New System.Data.DataColumn("col" & number, GetType(String))
                    col.Caption = item

                    dt.Columns.Add(col)
                    number += 1
                Next
            End If

            ' Hier die Daten einlesen 
            While Not parser.EndOfData
                ' Read in the fields for the current line
                fields = parser.ReadFields()
                If dt.Columns.Count = 0 Then ' Beim ersten Lesen die Spalten anlegen 
                    Dim number As Integer
                    For Each item As String In fields
                        Dim col As New System.Data.DataColumn("col" & number, GetType(String))
                        col.Caption = "Spalte: " & number
                        dt.Columns.Add(col)
                        number += 1
                    Next
                End If
                Dim colIndex As Integer
                colIndex = 0
                Dim newRow As DataRow = dt.NewRow
                For Each item As String In fields
                    newRow.Item(colIndex) = item
                    colIndex += 1
                Next
                dt.Rows.Add(newRow)
            End While
        End Using

        dt.AcceptChanges()
        Return dt
    End Function

    Public Sub New(ByVal mainApp As ClausSoftware.MainApplication)
        application = mainApp

        ShowMainImport() ' eingngsfenster öffnen
    End Sub
End Class

''' <summary>
''' Stellt Daten zu den verwendeten Eigenschaften bereit
''' </summary>
''' <remarks></remarks>
<DebuggerDisplay("PropertyName={m_propertyName}, DisplayName={m_propertyDisplayName}")> _
Public Class ImportPropertyInfo


    Private m_propertyName As String

    Private m_propertyDisplayName As String
    Public Property DisplayName() As String
        Get
            Return m_propertyDisplayName
        End Get
        Set(ByVal value As String)
            m_propertyDisplayName = value
        End Set
    End Property

    Public Property PropertyName() As String
        Get
            Return m_propertyName
        End Get
        Set(ByVal value As String)
            m_propertyName = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Me.DisplayName

    End Function


End Class
