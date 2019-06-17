Imports Microsoft.VisualBasic.FileIO

Namespace Tools
    ''' <summary>
    ''' Stellt Funktionen zur Lokalisierung von HWL1 bereit
    ''' </summary>
    ''' <remarks></remarks>    

    Public Class Localisator

        ''' <summary>
        ''' Enthält eine Auflistung von unbekannten Texten, die nicht aus einer Text-Tabelle gelesen werden konnten
        ''' </summary>
        ''' <remarks></remarks>
        Private m_unknownTexts As New Dictionary(Of String, String)

        Private m_isInitialized As Boolean

        ''' <summary>
        ''' Enthält eine Auflistung von Schlüsssel - Werte Paare aller bekannten Texte
        ''' </summary>
        ''' <remarks></remarks>
        Private m_Language As New Dictionary(Of String, String)

        ''' <summary>
        ''' Systempfad der ausgelieferten Sprachen
        ''' </summary>
        ''' <remarks></remarks>
        Private m_Path As String
        ''' <summary>
        ''' Enthält den vollständigen Pfad zur Sprachdatei
        ''' </summary>
        ''' <remarks></remarks>
        Private m_currentFilePath As String

        Public Sub New()

            m_Path = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), MainApplication.ApplicationName & "\Languages")   ' All Users   => Sprachen unter "Alle Benutzer" anlegen und nutzen

            m_Path = System.IO.Path.GetFullPath(m_Path) ' Sollte vom Ausführenden Verzeichnis dadrunter liegn
        End Sub

        ''' <summary>
        ''' Ruft den Pfad ab unter dem die Sprachdateien liegen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property LocalizationPath As String
            Get
                Return m_Path
            End Get
        End Property

        ''' <summary>
        ''' Initialuzes the Language-System
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize()
            m_currentFilePath = System.IO.Path.Combine(m_Path, Me.GetActiveLanguage & ".txt")

            MainApplication.getInstance.log.WriteLog("Aktuelle Systemsprache ist: " & Me.GetActiveLanguage)
            MainApplication.getInstance.log.WriteLog("Suche Sprachdateien unter: '" & System.IO.Path.GetFullPath(m_Path) & "'")

            LoadLanguage()
            m_isInitialized = True
        End Sub

        ''' <summary>
        ''' Ruft einen Text für die Datenquelle ab
        ''' </summary>
        ''' <param name="kind"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTextBydataKind(ByVal kind As Kernel.DataSourceList) As String
            Select Case kind
                Case Kernel.DataSourceList.Addressbook : Return GetText("enum_" & kind.ToString, "Adressbuch")
                Case Kernel.DataSourceList.Articles : Return GetText("enum_" & kind.ToString, "Artikelliste")
                Case Kernel.DataSourceList.BillOfMaterial : Return GetText("enum_" & kind.ToString, "Stücklisten")
                Case Kernel.DataSourceList.CashJournalMonthy : Return GetText("enum_" & kind.ToString, "Kassenbuch (Monatsblatt)")
                Case Kernel.DataSourceList.CashJournalYearly : Return GetText("enum_" & kind.ToString, "Kassenbuch (Jahresübersicht)")
                Case Kernel.DataSourceList.Discounts : Return GetText("enum_" & kind.ToString, "Rabatte")
                Case Kernel.DataSourceList.FixedCostGroup : Return GetText("enum_" & kind.ToString, "Fixkosten (Gruppe)")
                Case Kernel.DataSourceList.FixedCosts : Return GetText("enum_" & kind.ToString, "Fixkosten")
                Case Kernel.DataSourceList.Groups : Return GetText("enum_" & kind.ToString, "Artikelgruppen")
                Case Kernel.DataSourceList.HistoryCategories : Return GetText("enum_" & kind.ToString, "Verlaufsgruppen")
                Case Kernel.DataSourceList.Journal : Return GetText("enum_" & kind.ToString, "Journalliste")
                Case Kernel.DataSourceList.Journaldocument : Return GetText("enum_" & kind.ToString, "Angebote/Rechnungen")
                Case Kernel.DataSourceList.Letters : Return GetText("enum_" & kind.ToString, "Briefe")
                Case Kernel.DataSourceList.LoanAccounts : Return GetText("enum_" & kind.ToString, "Arbeitsgruppen")
                Case Kernel.DataSourceList.None : Return GetText("enum_" & kind.ToString, "Keine")
                Case Kernel.DataSourceList.Reminders : Return GetText("enum_" & kind.ToString, "Termine/Erinnerungen")
                Case Kernel.DataSourceList.Tasks : Return GetText("enum_" & kind.ToString, "Aufgaben")
                Case Kernel.DataSourceList.Transactions : Return GetText("enum_" & kind.ToString, "Forderungen/Verbindlichkeiten")
                Case Kernel.DataSourceList.Units : Return GetText("enum_" & kind.ToString, "Einheiten")
                Case Kernel.DataSourceList.users : Return GetText("enum_" & kind.ToString, "Benutzerlisten")
                Case Kernel.DataSourceList.WorkItems : Return GetText("enum_" & kind.ToString, "Tätigkeiten")
                Case Else
                    Throw New NotImplementedException("Keien Übersetzung für " & kind)
            End Select

        End Function


        ''' <summary>
        ''' Fügt das Schlüssel-Werte-Paar der Aufliustung hinzu
        ''' </summary>
        ''' <param name="Key"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Sub SetText(ByVal key As String, ByVal value As String)
            If Not m_Language.ContainsKey(key) Then

                If Not m_unknownTexts.ContainsKey(key) Then
                    m_unknownTexts.Add(key, value)
                Else
                    m_unknownTexts(key) = value
                End If

                m_Language.Add(key, value)
            Else
                m_Language(key) = value
            End If

        End Sub

        ''' <summary>
        ''' Ruft zu einem gegebenen Text eine Übersetzung ab.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Public Function GetText(ByVal key As String) As String
            Dim translatedText As String

            translatedText = GetTextIntern(key)

            If translatedText.Equals(key) Then ' Dann wurde kein text zurückgegeben
                SetText(key, key) ' Füge den unbekannten Text der Auflistung hinzu
                translatedText = key
            End If

            Return GetSubstitutedKeywords(translatedText)

        End Function

        ''' <summary>
        ''' Ruft zu einem gegebenen Text eine Übersetzung ab.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        ''' <remarks>schreibt eine PAT-Datei mit </remarks>
        Private Function GetTextIntern(ByVal key As String) As String
            Dim translatedText As String
            Dim thisKey As String = key.ToLower

            If m_Language.ContainsKey(key) Then
                translatedText = m_Language(key)
            Else
                translatedText = key
            End If

            Return translatedText

        End Function

        ''' <summary>
        ''' Enthält das Schlüselwort für den Applikationsnamen
        ''' </summary>
        ''' <remarks></remarks>
        Private _AppName As String = System.Text.RegularExpressions.Regex.Escape("{appname}")
        ''' <summary>
        ''' Stellt Ersetungsregeln für {AppName} bereit
        ''' </summary>
        ''' <remarks></remarks>
        Private repAppName As New System.Text.RegularExpressions.Regex(_AppName, Text.RegularExpressions.RegexOptions.Compiled Or Text.RegularExpressions.RegexOptions.IgnoreCase)


        ''' <summary>
        ''' Tauscht Schlüsselwörter im Text aus
        ''' </summary>
        ''' <param name="orgText"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetSubstitutedKeywords(ByVal orgText As String) As String
            If Not String.IsNullOrEmpty(orgText) Then

                Dim newText As String
                newText = repAppName.Replace(orgText, MainApplication.ApplicationName)
                newText = newText.Replace("/n", vbCrLf)

                Return newText
            End If
            Return String.Empty

        End Function

        ''' <summary>
        ''' Sucht einen Text anhand des gegebenen Schlüssels, kann mit dem Schlüssel kein text gefunden werden, wird der Defaulttext übergeben,
        ''' sofern dieser nicht leer ist.
        ''' </summary>
        ''' <param name="key">Ein eindeutiger Wert um einen Text zu finden</param>
        ''' <param name="defaultValue">Wurde kein Text gefunden, wird dieser Standard-Wert genommen</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetText(ByVal key As String, ByVal defaultValue As String, ByVal ParamArray params() As Object) As String

            If String.IsNullOrEmpty(key) Then Return defaultValue
            If String.IsNullOrEmpty(defaultValue) Then defaultValue = key

            Dim translatedText As String = GetText(key)

            If translatedText.Equals(key) Then ' Dann wurde kein text zurückgegeben

                SetText(key, defaultValue) ' Füge den unbekannten Text der Auflistung hinzu

                translatedText = defaultValue


                ' Parameter ersetzen

            End If

            translatedText = GetSubstitutedKeywords(translatedText)

            If params IsNot Nothing Then
                If params.Length > 0 Then
                    Dim itemCounter As Integer
                    For itemCounter = 0 To params.Length - 1
                        translatedText = translatedText.Replace("{" & itemCounter & "}", params(itemCounter).ToString)

                    Next
                End If
            End If

            Return translatedText

        End Function

        ''' <summary>
        ''' Setzt von einem gegebenen Control die Text-Eigenschaft, sofern anhand des Namens ein Text-Schlüssel gefunden werden konnte
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <remarks></remarks>
        Public Sub SetTextOnControl(ByVal ctrl As System.Windows.Forms.Control)
            ' Alle untergeordneten Controls ebenfalls durchgehen und aktualisieren
            Dim key As String
            Dim text As String
            If ctrl.Name.Equals("PageDesigner", StringComparison.InvariantCultureIgnoreCase) Then Exit Sub
            ' Markierte Controls nicht übersetzen
            If ctrl.Tag IsNot Nothing Then

                Dim tagstr As String = TryCast(ctrl.Tag, String)
                If Not String.IsNullOrEmpty(tagstr) Then
                    If tagstr.Equals("donttranslate", StringComparison.InvariantCultureIgnoreCase) Then Exit Sub
                End If

            End If

            ' Normale Menüs erfassen
            If TypeOf ctrl Is System.Windows.Forms.ContextMenuStrip Then
                For Each item As System.Windows.Forms.ToolStripItem In CType(ctrl, System.Windows.Forms.ContextMenuStrip).Items

                    key = item.Name
                    text = item.Text
                    item.Text = GetText(key, text)

                Next
                Exit Sub
            End If

            ' Radiogruppen anders handhaben
            If TypeOf ctrl Is DevExpress.XtraEditors.RadioGroup Then
                For Each item As DevExpress.XtraEditors.Controls.RadioGroupItem In DirectCast(ctrl, DevExpress.XtraEditors.RadioGroup).Properties.Items
                    item.Description = GetText(item.Description)
                Next
                Exit Sub
            End If


            ' Rekursiv eintauchen
            If ctrl.Controls.Count > 0 Then
                For Each item As System.Windows.Forms.Control In ctrl.Controls
                    SetTextOnControl(item)
                Next
            End If


            ' NIcht alle Control-Typen prüfen: 
            ' Keine Textboxen, keine Panels, keine 

            If TypeOf ctrl Is DevExpress.XtraEditors.TextEdit Then Exit Sub ' Textboxen werden vom Anwender gefüllt, NULL-Texte sollten von den Modulen gefüllt werden
            If TypeOf ctrl Is System.Windows.Forms.TextBox Then Exit Sub ' Textboxen werden vom Anwender gefüllt, NULL-Texte sollten von den Modulen gefüllt werden

            If TypeOf ctrl Is System.Windows.Forms.UserControl Then Exit Sub ' UIsercontrols selber haben keine Text-Eigenschaft
            If TypeOf ctrl Is System.Windows.Forms.Panel Then Exit Sub
            If TypeOf ctrl Is System.Windows.Forms.SplitContainer Then Exit Sub
            If TypeOf ctrl Is System.Windows.Forms.SplitterPanel Then Exit Sub
            If TypeOf ctrl Is DevExpress.XtraEditors.SplitContainerControl Then Exit Sub
            If TypeOf ctrl Is System.Windows.Forms.Panel Then Exit Sub
            If TypeOf ctrl Is System.Windows.Forms.PictureBox Then Exit Sub
            If TypeOf ctrl Is DevExpress.XtraEditors.PictureEdit Then Exit Sub



            If TypeOf ctrl Is DevExpress.XtraEditors.LabelControl Then
                'Debug.Assert(ctrl.Name.StartsWith("lbl"), "Der Name eines Labels sollte mit 'lbl' beginnen")
            End If


            key = ctrl.Name
            text = ctrl.Text
            ctrl.Text = GetText(key, text)

        End Sub

        Private m_languagesearched As Boolean
        Private m_defaultLanguage As String = "de-de"

        ''' <summary>
        ''' Public Overridable ReadOnly Property Name As String
        '''Gets the culture name in the format $lt;languagecode2&gt;-&lt;country/regioncode2&gt;".
        ''' </summary>
        ''' <returns>The culture name in the format "languagecode2-country/regioncode2", where languagecode2 is a lowercase two-letter code derived from ISO 639-1 and country/regioncode2 is an uppercase two-letter code derived from ISO 3166.        </returns>
        ''' <remarks></remarks>
        Public Function GetActiveLanguage() As String

            If Not m_languagesearched Then
                m_languagesearched = True


                Dim overrideLanguage As String = GetCommandLineLanguage()

                If String.IsNullOrEmpty(overrideLanguage) Then
                    m_defaultLanguage = My.Application.Culture.Name
                Else

                    MainApplication.getInstance.log.WriteLog("Programmsprache per Komandoparameter auf " & overrideLanguage & " gesetzt.")

                    ' Hier auf Gültigkeit prüfen, nicht ZB "XY" als sprache angeben  => Fallback auf englisch? (Deutsch?) 
                    Dim cultureFound As Boolean
                    For Each item As System.Globalization.CultureInfo In System.Globalization.CultureInfo.GetCultures(Globalization.CultureTypes.AllCultures)
                        If item.Name.Equals(overrideLanguage, StringComparison.InvariantCultureIgnoreCase) Then

                            If Not item.IsNeutralCulture Then ' Neutrale kulturen können nicht als Thrad-Culture verwendet werden
                                My.Application.ChangeCulture(overrideLanguage)
                                My.Application.ChangeUICulture(overrideLanguage)
                            End If

                            cultureFound = True
                            Exit For
                        End If

                    Next
                    If Not cultureFound Then
                        'TODO: Eine exception bauen, die eine Klare Anweisung für den Anwender enthält (Klare Problembeschreibung und Lösungsvorschlag)

                        Throw New ArgumentException("The culture given by command line parameter (" & overrideLanguage & ") seems not to exist. Remove the '/lang:' -parameter or correct ist setting. " & vbCrLf &
                                                    "Use this form: ""/lang:de"" or ""/lang:de-de""")
                    End If
                    m_defaultLanguage = overrideLanguage
                End If
            End If

            Return m_defaultLanguage.ToUpper

        End Function

        Public Sub SetLanguage(ByVal languageCode As String)

        End Sub

        ''' <summary>
        ''' Ruft aus der Kommandizeile die zu verwendete sprache im Format /lang:de-de oder /lang:en ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetCommandLineLanguage() As String

            Return GetCommandLineParameter("lang")

        End Function

        ''' <summary>
        ''' Läd die Sprache gemäss aktueller Kultur ein, kann die Kultur nicht gefunden werden; wird versucht eine ähnliche Kultur zu laden. 
        ''' Aus "EN" kann so eine bestehende Datei "EN-GB"  gemacht werden.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadLanguage()

            Dim fields As String()
            Dim delimiter As String = ";"

            m_Language.Clear()
            m_unknownTexts.Clear()

            Dim filename As String = System.IO.Path.GetFileNameWithoutExtension(m_currentFilePath).ToUpper

            ' die diversen Englischen Dialekte erkennenn und reparieren. Im Zweifel nach EN-GB suchen; das solte ausgeliefert werden
            If filename.StartsWith("EN") Then
                If Not System.IO.File.Exists(m_currentFilePath) Then
                    If Not System.IO.Directory.Exists(m_Path) Then
                        System.IO.Directory.CreateDirectory(m_Path)
                    End If

                    Dim lanPath As String = System.IO.Path.GetFullPath(m_currentFilePath)
                    lanPath = lanPath.Substring(0, lanPath.LastIndexOf("\"c))
                    If System.IO.File.Exists(IO.Path.Combine(lanPath, "en-gb.txt")) Then
                        System.IO.File.Copy(IO.Path.Combine(lanPath, "en-gb.txt"), IO.Path.Combine(lanPath, filename & ".txt"))
                    End If


                End If
            End If



            If Not System.IO.File.Exists(m_currentFilePath) Then
                Debug.Print("Sprachen-Pfad konnte nicht gefunden werden; lege neuen Pfad an")


                ' wenn kein Pfad gefunden werden konnte, wurde auch keine Sprache ausgeliefert; lege die 

                If Not System.IO.Directory.Exists(m_Path) Then
                    System.IO.Directory.CreateDirectory(m_Path)
                End If


                System.IO.File.CreateText(m_currentFilePath)
            End If
            Dim value As String

            MainApplication.getInstance.log.WriteLog(LogSeverity.Verbose, "Lade Sprachdatei: " & m_currentFilePath)

            Using parser As New TextFieldParser(m_currentFilePath)
                parser.SetDelimiters(delimiter)
                While Not parser.EndOfData
                    ' Read in the fields for the current line
                    fields = Nothing

                    Try
                        fields = parser.ReadFields()
                    Catch ex As Exception ' Kann auftreten, wenn die Textdatei irgendwie beschädigt ist
                        MainApplication.getInstance.log.WriteLog(ex, "Languages", "Error while parsing line Nr.: " & parser.ErrorLineNumber)

                    End Try

                    If fields IsNot Nothing Then
                        ' Key;Value
                        If fields.Length > 1 Then
                            value = fields(1)

                            value = value.Replace("/n", Environment.NewLine)
                            If Not m_Language.ContainsKey(fields(0)) Then

                                m_Language.Add(fields(0), value)
                            Else
                                Debug.Print("Key in Language exist: " & fields(0))
                            End If

                        Else
                            Debug.Print("Can't parse Line Nr.: " & parser.LineNumber)
                        End If
                    End If



                End While
            End Using

        End Sub



        ''' <summary>
        ''' Speichert die aktuelle Sprachdatei ab
        ''' </summary>
        ''' <returns>Den Pfad zur Sprachdatei</returns>
        ''' <remarks></remarks>
        Public Function SaveLanguageFile() As String
            If m_isInitialized Then
                Try
                    Dim Textdata As String = GetTextFromDictionary()

                    If Textdata.Length > 0 Then ' Keine leeren Texte schreiben
                        MainApplication.getInstance.log.WriteLog(LogSeverity.Verbose, "Writing new language file in: " & m_currentFilePath)

                        My.Computer.FileSystem.WriteAllText(m_currentFilePath, Textdata, False)
                    End If

                Catch ex As Exception
                    MainApplication.getInstance.log.WriteLog(ex, "Languages", "Error while writing Languagefile")
                End Try

            End If

            Return m_currentFilePath
        End Function


        Private Function GetTextFromDictionary() As String
            Dim List As String = ""

            For Each kvp As KeyValuePair(Of String, String) In Me.m_Language
                Dim Value As String = kvp.Value

                Value = Value.Replace(Environment.NewLine, "/n") ' Für die Textdatei die NewLines gegen C - Symbole auswechseln

                List = List & _
                kvp.Key & ";" & Value & Environment.NewLine

            Next
            Return List
        End Function
    End Class


End Namespace