Option Strict On
Option Explicit On

Imports System
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports System.Windows.Forms


''' <summary>
''' Enthält das Auslesen und Analysieren der Textfelder
''' </summary>
''' <remarks></remarks>
Public Class DatanormParser

    ''' <summary>
    ''' Enthält den Dateiname der gerade eingelesen wird
    ''' </summary>
    ''' <remarks></remarks>
    Private m_fileName As SingleFile

    ''' <summary>
    ''' Wird ausgelöst, nachdem eine neue Zeile gelesen wurde
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Event LineRead(ByVal sender As Object, ByVal e As LineNumerEventArgs)

    ''' <summary>
    ''' Damit kann eine kleine Meldung gesendet werden
    ''' </summary>
    ''' <param name="e">Der Nachrichten-Parameter</param>
    ''' <remarks></remarks>
    Public Event Message(sender As Object, e As MessageEventArgs)


    Private m_currentLineNumber As Long

    Private m_currentLine As String

    ''' <summary>
    ''' Enthält die Instanz des Dateischreibers
    ''' </summary>
    ''' <remarks></remarks>
    Private m_articlewriter As DataWriter = New DataWriter

    Private m_preisänderungssatz As New Preisänderungssatz
    Private m_leitungssatz As New Leitungssatz
    Private m_leitungssatzc1 As New LeitungssatzC1
    Private m_leitungssatzc2 As New Leitungssatzc2
    Private m_leistungssatzsach As New LeistungssatzSach
    Private m_leistungssatzfliesen As New LeistungssatzFliesen
    Private m_leistungssatzartikel As New LeistungssatzArtikel
    Private m_leistungssatzarbeitszeiten As New LeistungssatzArbeitszeiten
    Private m_leistungssatzgefahrenGGVS As New LeistungssatzGefahrenGGVS
    Private m_leistungssatzgefahrenVBS As New LeistungssatzGefahrenVBF
    Private m_leistungssatzzoll As New LeistungssatzZoll
    Private m_rohstoffzuschlagsatz As New Rohstoffzuschlagsatz
    Private m_zu_abschlagssatz As New zu_abschlagssatz
    Private m_rohstoffsatz As New Rohstoffsatz
    Private m_artikelset As New Artikelset
    Private m_artikelstücklisten As New Artikelstücklisten
    Private m_grafikbindungssatz As New Grafikbindungssatz
    Private m_dimensionssatz As New Dimensionssatz
    Private m_artikelsatzB As New ArtikelsatzB
    Private m_dateiende As New Dateiende
    Private m_vorlaufsatz As New Vorlaufsatz
    Private m_warengruppen As New Hauptwarengruppen
    Private m_artikelsatz As New Artikelsatz
    Private m_textsatz As New Textsatz
    Private m_rabattsatz As New Rabattsatz
    Private m_kundenkontrollsatz As New KundenkontrollSatz

    ''' <summary>
    ''' Ruft den Dateinamen der Datei die gelesen werden soll ab oder legt den fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileName As SingleFile
        Get
            Return m_fileName
        End Get
        Set(ByVal value As SingleFile)
            m_fileName = value
        End Set
    End Property


    ''' <summary>
    ''' Ruft die aktuell gelesenen Zeile ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentLine() As String
        Get
            Return m_currentLine
        End Get
    End Property

    ''' <summary>
    ''' Ruft die aktuelle gelesene Zeilennummer ab 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentLineNumer As Long
        Get
            Return m_currentLineNumber
        End Get
    End Property

    ''' <summary>
    ''' Ruft die erste Zeile des Datensatzes ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFirstLine() As String
        Dim firstLine As String
        Dim Valid50Datanorm As Boolean

        Try
            Using fileContents As IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(Me.FileName.FilePath)

                ' erste Zeile lesen 
                firstLine = fileContents.ReadLine()
            End Using

            Dim fields() As String = firstLine.Split(";"c)

            Valid50Datanorm = CheckFirstLine(fields)

        Catch ex As Exception
        End Try

        ' Nun den Vorlaufsatz auslesen 
        If Valid50Datanorm Then
            Dim retstring As String
            retstring = m_vorlaufsatz.FileContent & vbCrLf
            retstring &= m_vorlaufsatz.Copyright & vbCrLf

            retstring &= "Datum: " & m_vorlaufsatz.Datum & vbCrLf

            Return retstring
        Else
            ' Ungültiges Datenformat
            Return "Kein Datanorm 5 Format!"
        End If


    End Function

    ''' <summary>
    ''' Startet den Datenimport
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartImport()



        Dim filename As String = m_fileName.FilePath
        Dim fields As String()
        Dim delimiter As String = ";"

        ' einmal bis zum Ende lesen um die Datensatzlänge zu ermitteln
        Dim maxLineNumbers As Integer

        Using fileContents As IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(filename)

            ' Anzahl der Zeilen bestimmen
            Do While Not fileContents.EndOfStream
                fileContents.ReadLine()
                maxLineNumbers += 1

            Loop
        End Using
        Debug.Print("LineCount: " & maxLineNumbers)

        filename = GetVersion5Format(filename)

        RaiseEvent Message(Me, New MessageEventArgs("Starte das Einlesen von " & filename & "..."))
        Using parser As New TextFieldParser(filename)
            parser.SetDelimiters(delimiter)
            parser.HasFieldsEnclosedInQuotes = True

            fields = parser.ReadFields()

            If ParseVersion(fields) Then
                ' Version OK, dann Vorlaufsatz komplett einlesen

                CheckFirstLine(fields)

                ' Hauptschleife: Hier alle Daten auslesen 
                ' Messen wir lange der Import dauert
                Dim sw As New Stopwatch
                sw.Start()

                m_articlewriter.Clear()

                While Not parser.EndOfData
                    Try
                        m_currentLineNumber = parser.LineNumber

                        fields = parser.ReadFields()
                        ' Ab hier Zeilen lesen und auflösen
                        ReadLine(fields)

                        If m_currentLineNumber < 100 Then ' Hier noch jedesmal benachrichtigen, 
                            RaiseEvent LineRead(Me, New LineNumerEventArgs(parser.LineNumber, maxLineNumbers))

                        Else ' Danach nur jede 10. mal!
                            If m_currentLineNumber Mod 20 = 0 Then
                                RaiseEvent LineRead(Me, New LineNumerEventArgs(m_currentLineNumber, maxLineNumbers))
                            End If

                        End If

                        'Debug.Print("Line: " & parser.LineNumber)

                    Catch ex As Exception
                        MainApplication.getInstance.Log.WriteLog(ex, "DatanormImport", "Fehler beim Lesen der Zeile  (" & parser.ErrorLineNumber & ") : " & parser.ErrorLine)

                    End Try


                End While
                sw.Stop()
                RaiseEvent Message(Me, New MessageEventArgs("Einlesen beendet."))

                ' Letzes Benachrichtigen, alle Zeilen wurden gelesen
                RaiseEvent LineRead(Me, New LineNumerEventArgs(maxLineNumbers, maxLineNumbers))

                Debug.Print("Read: " & parser.LineNumber & " of File")
                Debug.Print("Elapsed Time: " & sw.Elapsed.ToString & "  ")

            Else
                ' Version war wohl falsch

            End If

        End Using
    End Sub

    ''' <summary>
    ''' Prüft, ob es sich um eine Version 5 handlet; falls nicht, wird erst eine Version 5 erzeugt und der Dateiname zurückgegeben
    ''' </summary>
    ''' <param name="orgFilename"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetVersion5Format(orgFilename As String) As String
        Dim newFilename As String = orgFilename
        Dim line As String

        Using fs As StreamReader = New System.IO.StreamReader(orgFilename)
            line = fs.ReadLine()
            fs.Close()
        End Using

        If Not String.IsNullOrEmpty(line) Then
            If line.StartsWith("V;050") Then Return orgFilename


            ' Nun ist es keine 5.0 Datei
            'DATAN005.EXE A:\DATANORM.001;C:\MEINPFAD\DATANORM.001;5;
            Dim baseFilename As String = System.IO.Path.GetFileNameWithoutExtension(orgFilename)
            baseFilename &= "--V5--"

            Dim basePath As String = System.IO.Path.GetDirectoryName(orgFilename)
            newFilename = System.IO.Path.Combine(basePath, baseFilename)

            ' Endung wieder herstellen
            newFilename &= System.IO.Path.GetExtension(orgFilename)


            ' Systemprozess starten

            'Dim argument As String = """" & orgFilename & """;""" & newFilename & """;5" ' Argument erzeugen lassen 
            Dim argument As String = orgFilename & ";" & newFilename & ";5" ' Argument erzeugen lassen 

            Dim converterFilename As String = VersionConverter.GetConverterPath

            If String.IsNullOrEmpty(converterFilename) Then
                MessageBox.Show("Installieren Sie erst den Datanorm-Konverter und starten Sie den Import erneut", "Datanorm-Konverter wird installiert", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Throw New Exception("Converter not installed")
            End If

            RaiseEvent Message(Me, New MessageEventArgs("Starte Konvertierung von alten Datanorm-Daten in die Version 5..."))
            Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(converterFilename, argument)
            p.WaitForExit()  ' warten, bis fertig...


        End If


        Return newFilename
    End Function


    ''' <summary>
    ''' Liest eine Zeile aus dem Datensatz ein und führt diese dem entsprechendem Parser zu.
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <remarks></remarks>
    ''' <exception cref="ArtikelsatznotfoundException">Wenn das Satzzeichen nicht gefunden wurde</exception>
    Public Sub ReadLine(ByVal fields As String())
        If fields.Length > 0 Then
            Dim satzzeichen As String = fields(0)
            If satzzeichen.Length = 1 Then
                Select Case fields(0).ToUpper
                    Case "A" : ParseArtikel(fields)
                        m_articlewriter.WriteArticleData(m_artikelsatz)

                    Case "B" : ParseArtikelsatzB(fields)
                        m_articlewriter.WriteArticleDataB(m_artikelsatzB)

                    Case "T" : ParseTextSatz(fields)
                        m_articlewriter.WriteTextData(m_textsatz)

                    Case "S" : ParseHauptwarenGruppen(fields)
                        m_articlewriter.WriteGroupData(m_warengruppen)

                    Case "K" : ParseKundenkontroll(fields) ' Uninteressant
                        ' Keine Analyse des Kundenkontrollsatzes

                    Case "R" : Parserabattsatz(fields)
                        m_articlewriter.WriteDiscounts(m_rabattsatz)

                    Case "P" : ParsePreisÄnderungssatz(fields)

                    Case "D" : ParseDimension(fields)
                    Case "E" : ParseDateiende(fields)
                        ' TODO: Dateien  anhängen ? 

                    Case "Z" : ParseRohstoffZuschlag(fields)

                    Case "G" : ParseGrafikSatz(fields) ' Nicht implemntiert

                    Case Else
                        Debug.Print("Überspringe: " & fields(0))
                        Throw New ArtikelsatznotfoundException("Artikelsatz nicht gefunden", satzzeichen)
                End Select
            Else
                Throw New ArtikelsatznotfoundException("Artikelsatz zu lang", satzzeichen)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Hält eine statistische Aufstellung von Datensatzkennzeichnen un deren Anzahl im gelesenen Datensatz
    ''' </summary>
    ''' <remarks></remarks>
    Private m_StatsData As New Dictionary(Of String, Integer)

    ''' <summary>
    ''' Fügt eine neue Statistik hinzu
    ''' </summary>
    ''' <param name="dataline"></param>
    ''' <remarks></remarks>
    Private Sub AddStats(ByVal dataline As String)
        If m_StatsData.ContainsKey(dataline) Then
            m_StatsData.Add(dataline, 0)
        End If

        m_StatsData(dataline) += 1


    End Sub

    ''' <summary>
    ''' Ruft eine Text-Aufstellung der gelesenden Datensätze ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetStats() As String
        Get
            Dim statstext As String = String.Empty
            statstext = "Satzart      Anzahl"
            For Each item As String In m_StatsData.Keys
                statstext &= item & ":  " & m_StatsData(item) & vbCrLf
            Next
            Return statstext

        End Get
    End Property

    ''' <summary>
    ''' Prüft den Vorlaufsatzsatz. Die erste Zeile jeder datanorm-datei
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckFirstLine(ByVal fields As String()) As Boolean
        If fields.Length > 0 Then
            Try
                If fields(0) = "V" Then
                    m_vorlaufsatz.Satzkennzeichen = fields(0)
                    m_vorlaufsatz.Version = fields(1) ' Sollte 050 sein

                    ' Die Art des einzulesenden Datensatzes merken
                    Select Case fields(2).ToString.ToUpper
                        Case "A" : m_vorlaufsatz.Datenkennzeichen = enumDatenkennzeichen.ArtikelStammDaten
                        Case "S" : m_vorlaufsatz.Datenkennzeichen = enumDatenkennzeichen.WarenGruppenSätze
                        Case "R" : m_vorlaufsatz.Datenkennzeichen = enumDatenkennzeichen.RabattGruppenSätze
                        Case "J" : m_vorlaufsatz.Datenkennzeichen = enumDatenkennzeichen.SetSätze
                        Case "P" : m_vorlaufsatz.Datenkennzeichen = enumDatenkennzeichen.PreisÄnderungsSätze
                        Case "T" : m_vorlaufsatz.Datenkennzeichen = enumDatenkennzeichen.TextSätzeUngebunden
                        Case "O" : m_vorlaufsatz.Datenkennzeichen = enumDatenkennzeichen.StückListendaten

                    End Select
                    'JJJJMMTT
                    Dim JJJJ As String
                    Dim MM As String
                    Dim TT As String
                    If fields(3).Length = 8 Then
                        JJJJ = fields(3).Substring(0, 4)
                        MM = fields(3).Substring(4, 2)
                        TT = fields(3).Substring(6, 2)
                    Else
                        Throw New ArgumentException("Datumfeld hat die falsche Länge")
                        Return False
                    End If
                    Dim filedate As New Date(CInt(JJJJ), CInt(MM), CInt(TT))
                    m_vorlaufsatz.Datum = filedate

                    m_vorlaufsatz.Währung = fields(4)
                    m_vorlaufsatz.FileContent = GetStringValue(fields, 5)
                    m_vorlaufsatz.Copyright = GetStringValue(fields, 6)
                    m_vorlaufsatz.Kuerzel = GetStringValue(fields, 7)

                    ' eindeutige Kennung ist wichtig zum wiederfinden eines Artikels
                    If String.IsNullOrEmpty(m_vorlaufsatz.Kuerzel) Then
                        m_articlewriter.ErstellerID = m_vorlaufsatz.FileContent
                    Else
                        m_articlewriter.ErstellerID = m_vorlaufsatz.Kuerzel
                    End If

                    m_vorlaufsatz.AnschriftErsteller = fields(8) & vbCrLf & fields(9) & vbCrLf & GetStringValue(fields, 10)
                    If fields.Length > 11 Then m_vorlaufsatz.AnschriftStrasse = GetStringValue(fields, 11)
                    If fields.Length > 12 Then m_vorlaufsatz.AnschriftLand = GetStringValue(fields, 12)
                    If fields.Length > 13 Then m_vorlaufsatz.AnschriftPLZ = GetStringValue(fields, 13)
                    If fields.Length > 14 Then m_vorlaufsatz.AnschriftOrt = GetStringValue(fields, 14)
                    Return True
                End If
            Catch ex As Exception

                Return False
            End Try
        Else
            Return False
        End If
        Return False
    End Function

    ''' <summary>
    ''' Lese Felder des Artikels ein
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <remarks></remarks>
    Private Function ParseArtikel(ByVal fields As String()) As Artikelsatz
        Try
            Select Case fields(1).ToString.ToUpper
                Case "N" : m_artikelsatz.Verarbeitungsmerker = enumVerarbeitungsmerker.NeuAnlage
                Case "A" : m_artikelsatz.Verarbeitungsmerker = enumVerarbeitungsmerker.Änderung
                Case Else

                    Debug.Print("Artikel Verarbeitungsmerker '" & fields(1) & "' in Zeile '" & Me.CurrentLineNumer & "' unbekannt! Nehme 'Neu' an.")
                    m_artikelsatz.Verarbeitungsmerker = enumVerarbeitungsmerker.NeuAnlage
            End Select



            With m_artikelsatz
                .Artikelnummer = GetStringValue(fields, 2)
                .KurzText1 = GetStringValue(fields, 3)
                .KurzText2 = GetStringValue(fields, 4)
                .Mengeneinheit = GetFullUnitName(GetStringValue(fields, 5))
                .Preiskennzeichen = CType(GetIntValue(fields, 6), enumPreisKennzeichen)
                .Preiseinheit = GetIntValue(fields, 7)
                .Preis = CDec(GetIntValue(fields, 8) / 100)
                .Rabattgruppe = GetStringValue(fields, 9)
                .Hauptwarengruppe = GetStringValue(fields, 10)
                .Warengruppe = GetStringValue(fields, 11)
                .Matchcode = GetStringValue(fields, 12)
                .KuerzelAlternativArtikelnummer = GetStringValue(fields, 13)
                .Alterartikelnummer = GetStringValue(fields, 14)
                .KuerzelHerstellernummer = GetStringValue(fields, 15)
                .Herstellernummer = GetStringValue(fields, 16)
                .HerstellerArtikelType = GetStringValue(fields, 17)
                .EAN = GetStringValue(fields, 18)
                .AnbindnummerGrafik = GetStringValue(fields, 19)
                .Mindesverpackungsmenge = GetIntValue(fields, 20)
                .Katalogseite = GetStringValue(fields, 21)
                .Textkennzeichen = CType(GetIntValue(fields, 22), enumTextKennzeichen)
                .Langtextnummer = GetStringValue(fields, 23)
                .Kostenart = GetStringValue(fields, 24)
                .Lagermerker = GetStringValue(fields, 25)
                .KuerzelErstellerRefnummer = GetStringValue(fields, 26)
                .Referenznummer = GetStringValue(fields, 27)
                .MwStsteuerMerker = CType(GetIntValue(fields, 28), enumMWstArt)


            End With
        Catch ex As Exception
            Debug.Print("Fehler beim Lesen des Artikelsatzes. " & ex.Message)
        End Try



        Return m_artikelsatz
    End Function

    ''' <summary>
    ''' Lese Felder des Artikels ein
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <remarks></remarks>
    Private Function Parserabattsatz(ByVal fields As String()) As Rabattsatz
        With m_rabattsatz
            .RabattgruppenID = GetStringValue(fields, 1)

            Select Case fields(2).ToString.ToUpper
                Case "1" : .RabattKennzeichen = enumRabattkennzeichen.Rabattsatz
                Case "2" : .RabattKennzeichen = enumRabattkennzeichen.Multi
                Case "3" : .RabattKennzeichen = enumRabattkennzeichen.Teuerungszuschlag
            End Select
            If .RabattKennzeichen <> enumRabattkennzeichen.Multi Then
                ' Normal sind 2 Nachkommastellen
                .Rabattwert = CDec(GetIntValue(fields, 3) / 100)
            Else
                ' Muti hat 3 Nachkommastellen
                .Rabattwert = CDec(GetIntValue(fields, 3) / 1000)
            End If

            .Rabattgruppenbezeichnung = GetStringValue(fields, 4)
        End With

        Return m_rabattsatz
    End Function

    ''' <summary>
    ''' Lese Felder des Artikels für die Textverarbeitung ein.
    ''' 
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <remarks>Wurde ein Langtext eines Artikel in der Textverarbeitung gegeben, dann ist der Text auszulesen und dem Artikel zuzuweisen</remarks>
    Private Function ParseTextSatz(ByVal fields As String()) As Textsatz

        With m_textsatz

            Select Case fields(1).ToString.ToUpper
                Case "N" : .Verarbeitungsmerker = enumVerarbeitungsmerker.NeuAnlage
                Case "A" : .Verarbeitungsmerker = enumVerarbeitungsmerker.Änderung
                Case "L" : .Verarbeitungsmerker = enumVerarbeitungsmerker.Löschung
            End Select

            .Textnummer = GetStringValue(fields, 2)

            Select Case fields(3).ToString.ToUpper
                Case "0" : .Merker = enumTextmerker.Ungebunden
                Case "1" : .Merker = enumTextmerker.Langtext
                Case "2" : .Merker = enumTextmerker.Einfügetextbaustein
            End Select

            ' Zeilennummer; wird ignoriert; es gild die Reihenfolge des Textes
            .Zeilennummer = GetIntValue(fields, 4)

            .Textzeile = GetStringValue(fields, 5)

        End With
        Return m_textsatz
    End Function
    'nicht fertig!

    ''' <summary>
    ''' Lese Felder des Artikels ein
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <remarks></remarks>
    Private Function ParseDateiende(ByVal fields As String()) As Dateiende
        If fields(0) = "E" Then
            m_dateiende.Anzahl = GetStringValue(fields, 1)
            m_dateiende.Bemerkung = GetStringValue(fields, 2)
        End If
        Return m_dateiende
    End Function
    ''' <summary>
    ''' Lese Felder des Artikelsatzes B ein (Löschungen / Änderungen)
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <remarks></remarks>
    Private Function ParseArtikelsatzB(ByVal fields As String()) As ArtikelsatzB
        Try
            Select Case fields(1).ToString.ToUpper
                Case "L" : m_artikelsatzB.Verarbeitungsmerker = enumVerarbeitungsmerker.Löschung
                Case "A" : m_artikelsatzB.Verarbeitungsmerker = enumVerarbeitungsmerker.Änderung
                Case Else
                    ' Nur Löschen oder Ändern möglich 
                    m_artikelsatzB.Verarbeitungsmerker = enumVerarbeitungsmerker.Löschung

            End Select

            With m_artikelsatzB
                .Artikelnummer = GetStringValue(fields, 2)
                .EditedArtikelnummer = GetStringValue(fields, 3)

                .Auslaufdatum = DateTime.Now

                ' Nur beim Löchen ein Ende-Dateum angeben
                DateTime.TryParse(GetStringValue(fields, 4), .Auslaufdatum)

            End With

        Catch ex As Exception
            Debug.Print("ParseArtikelsatzB: " & ex.Message)
        End Try

        Return m_artikelsatzB
    End Function
    ''' <summary>
    ''' Übersetzt den Kundenkontrollsatz "K"
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ParseKundenkontroll(ByVal fields As String()) As KundenkontrollSatz
        With m_kundenkontrollsatz
            .Kundennummer = GetStringValue(fields, 1)
            .Kundenanschrift1 = GetStringValue(fields, 8)
            .Kundenanschrift2 = GetStringValue(fields, 9)
            .Kundenanschrift3 = GetStringValue(fields, 10)
            .Land = GetStringValue(fields, 12)
            .Strasse = GetStringValue(fields, 11)
            .Postleitzahl = GetStringValue(fields, 13)
            .Ort = GetStringValue(fields, 14)
        End With
        Return m_kundenkontrollsatz
    End Function

    ''' <summary>
    ''' Übersetzt einen Warengruppensatz
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ParseHauptwarenGruppen(ByVal fields As String()) As Hauptwarengruppen
        m_warengruppen.Hauptwarengruppe = GetStringValue(fields, 1)
        m_warengruppen.UnterWarengruppe = GetStringValue(fields, 2)
        m_warengruppen.Bezeichnung = GetStringValue(fields, 3)

        Return m_warengruppen
    End Function

    ''' <summary>
    ''' wertet die Zeile Rohstoffzuschlag aus
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ParseDimension(ByVal fields As String()) As Dimensionssatz
        If fields(0) = "D" Then
            Select Case fields(1).ToString.ToUpper
                Case "N" : m_dimensionssatz.Verarbeitungsmerker = enumVerarbeitungsmerker.NeuAnlage
                Case "A" : m_dimensionssatz.Verarbeitungsmerker = enumVerarbeitungsmerker.Änderung
                Case "L" : m_dimensionssatz.Verarbeitungsmerker = enumVerarbeitungsmerker.Löschung
            End Select
            m_dimensionssatz.Dimensionstextnummer = GetStringValue(fields, 2)
            m_dimensionssatz.Zeilennummer = GetIntValue(fields, 3)

            Select Case fields(4).ToString.ToUpper
                Case "F" : m_dimensionssatz.unterkennzeichen = unterkennzeichen.Frei
                Case "T" : m_dimensionssatz.unterkennzeichen = unterkennzeichen.einfüge
                Case "E" : m_dimensionssatz.unterkennzeichen = unterkennzeichen.einfügefeld
            End Select
            m_dimensionssatz.Textzeile = GetStringValue(fields, 5)
            m_dimensionssatz.einfügetextbausteinnummer = GetStringValue(fields, 6)
        End If
        Return m_dimensionssatz
    End Function


    ''' <summary>
    ''' Prüft im Vorlaufsatz die Versionsnummer; liefert "True", wenn eine gültige 5er Version, sonst False. 
    ''' es wird nur die Version 5 gescannt. 
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ParseVersion(ByVal fields As String()) As Boolean
        Dim result As Boolean

        If fields.Length > 1 Then
            If fields(1) = "050" Then
                result = True

            End If
        End If


        If Not result Then
            MsgBox("Die verwendete DATANORM Version wird nicht unterstützt.")
        End If
        Return result
    End Function

    ''' <summary>
    ''' Wertet die Zeile Rohstoffsatz aus
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ParseRohstoffZuschlag(ByVal fields As String()) As Rohstoffsatz


        Try
            With m_rohstoffsatz
                .verarbeitungsmerker = GetStringValue(fields, 1)
                .artikelnummer = GetStringValue(fields, 2)
                .zeilennummer = GetStringValue(fields, 3)
                .bearbeitungsmerker2 = GetStringValue(fields, 4)
                .rohstoffmerker = GetStringValue(fields, 5)
                .zuschlagart = GetStringValue(fields, 6)
                .zuschlagkennzeichen = GetStringValue(fields, 7)
                .preiskennzeichen = GetStringValue(fields, 8)
                .preiseinheit = GetStringValue(fields, 9)
                .prozentsatz = GetStringValue(fields, 10)
                .VONRohstoffTagespreis = GetStringValue(fields, 11)
                .BISRohstoffTagespreis = GetStringValue(fields, 12)
                .umrechnungsfaktor = GetStringValue(fields, 13)

            End With

        Catch ex As Exception
            ' Kann nur ausgelöst werden, wenn die Felder zu klein sind
        End Try

        Return m_rohstoffsatz

    End Function

    ''' <summary>
    ''' Erlaubt es Bilddaten aus einer Datanorm-Datei abzuholen.
    '''  - Nicht implementiert! - 
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ParseGrafikSatz(ByVal fields As String()) As Grafikbindungssatz
        With m_grafikbindungssatz
            ' NIcht implementiert

        End With
        Return m_grafikbindungssatz
    End Function

    ''' <summary>
    ''' Erlaubt es Preisänderungen einzulesen
    ''' </summary>
    ''' <param name="fields"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ParsePreisÄnderungssatz(ByVal fields As String()) As Preisänderungssatz
        With m_preisänderungssatz
            'TODO: Preisänderungssätze
            .artikelnummer = GetStringValue(fields, 1)
            .preiskennzeichen = CType(GetIntValue(fields, 2), enumPreisKennzeichen)
            .preiseinheit = GetIntValue(fields, 3)
            .preis = CDec(GetIntValue(fields, 4) / 100)
            .rabattgruppe = GetStringValue(fields, 5)
            .rabattkennzeichen = CType(GetIntValue(fields, 6), enumRabattkennzeichen)

            Dim intVal As Integer = GetIntValue(fields, 7)
            If .rabattkennzeichen = enumRabattkennzeichen.Rabattsatz Or .rabattkennzeichen = enumRabattkennzeichen.Multi Then
                .rabatt = CInt(intVal / 100) ' 2 Nachkommastellen
            End If

            'TODO: weitere Rabattfelder

        End With

        Return m_preisänderungssatz
    End Function


    ''' <summary>
    ''' Ruft einen stringwert ab, der an der Index-stelle stehen soll. 
    ''' Ist kein Wert mehr vorhanden, wird ein Leerstring zurückgegeben.
    ''' </summary>
    ''' <param name="field">Die Datenzeile</param>
    ''' <param name="id">Die 1-Basierte Indexnummer</param>
    ''' <returns></returns>
    ''' <remarks>Damit werden 'teure' exceptions verhindert</remarks>
    Private Function GetStringValue(ByVal field() As String, ByVal id As Integer) As String
        If field.Length > id Then
            Return SetzeUmlaute(field(id))
        Else
            Return String.Empty
        End If
    End Function

    ''' <summary>
    ''' Ruft gemäss DTN - Richtlinie Kurze einheiten-Namen ab und ermittelt den langen Einheiten Name
    ''' </summary>
    ''' <param name="shortDTNUnit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetFullUnitName(shortDTNUnit As String) As String

        Select Case shortDTNUnit.ToUpper
            Case "CMK" : Return "cm²"
            Case "CMQ" : Return "cm³"
            Case "CMT" : Return "cm"
            Case "DZN" : Return "Dutzend"
            Case "GRM" : Return "Gramm"
            Case "HLT" : Return "Hektoliter"
            Case "KGM" : Return "Kilogramm"
            Case "KMT" : Return "Kilometer"
            Case "LTR" : Return "Liter"
            Case "MNT" : Return "Millimeter"
            Case "MTK" : Return "m²"
            Case "MTQ" : Return "m³"
            Case "MTR" : Return "Meter"
            Case "PCE" : Return "Stück"
            Case "PR" : Return "Paar"
            Case "SET" : Return "Satz"
            Case "TNE" : Return "Tonne"
            Case "STG" : Return "Stange"

            Case Else
                Return shortDTNUnit
        End Select
    End Function


    ''' <summary>
    ''' Setzt gemäss Datanorm - Tabelle einzelne Zeichen um
    ''' </summary>
    ''' <param name="stringData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function SetzeUmlaute(ByVal stringData As String) As String


        stringData = stringData.Replace(Chr(129), "ü")
        stringData = stringData.Replace(Chr(132), "ä")
        stringData = stringData.Replace(Chr(142), "Ä")
        stringData = stringData.Replace(Chr(148), "ö")
        stringData = stringData.Replace(Chr(153), "Ö")
        stringData = stringData.Replace(Chr(154), "Ü")
        stringData = stringData.Replace(Chr(225), "ß")
        stringData = stringData.Replace(Chr(253), "²")

        Return stringData

    End Function
    ''' <summary>
    ''' Ruft einen Integerwert ab, der an der Index-Stelle stehen soll. 
    ''' Ist kein Wert mehr vorhanden, wird ein Leerstring zurückgegeben.
    ''' </summary>
    ''' <param name="field">Die Datenzeile</param>
    ''' <param name="id">Die 1-Basierte Indexnummer</param>
    ''' <returns></returns>
    ''' <remarks>Damit werden 'teure' exceptions verhindert</remarks>
    Private Function GetIntValue(ByVal field() As String, ByVal id As Integer) As Integer
        If field.Length > id Then
            If field(id).Length > 0 Then
                Return CInt(field(id))
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function

End Class

''' <summary>
''' Stellt die aktuelle Zeielnnummer vereit, die gerade gelesen wurde
''' </summary>
''' <remarks></remarks>
<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)> _
Public Class LineNumerEventArgs
    Inherits EventArgs

    Private m_lineNumer As Long

    Private m_maxLineNumer As Long

    ''' <summary>
    ''' Ruft die maximale Anzahl von Zeilen ab, die in diesem Einlesevorgang existieren
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MaxLineNumber() As Long
        Get
            Return m_maxLineNumer
        End Get
        Set(ByVal value As Long)
            m_maxLineNumer = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft die aktuelle Zeielennummer ab, die gerade gelesen wurde
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LineNumber() As Long
        Get
            Return m_lineNumer
        End Get
        Set(ByVal value As Long)
            m_lineNumer = value
        End Set
    End Property

    Public Sub New(ByVal lineNumber As Long)
        Me.LineNumber = lineNumber
    End Sub

    Public Sub New(ByVal lineNumber As Long, ByVal maxLineNumber As Long)
        Me.LineNumber = lineNumber
        Me.MaxLineNumber = maxLineNumber
    End Sub
End Class

Public Class MessageEventArgs
    Inherits EventArgs
    Private m_message As String


    Public Sub New(message As String)
        m_message = message
    End Sub

    Public Property Message() As String
        Get
            Return m_message
        End Get
        Set(ByVal value As String)
            m_message = value
        End Set
    End Property

End Class

''' <summary>
''' Stellt eine Ausnahme da, die für unbekannte Satzzeichen geworfen wird. 
''' </summary>
''' <remarks></remarks>
Friend Class ArtikelsatznotfoundException
    Inherits Exception
    Private m_satzzeichen As String
    ''' <summary>
    ''' Erstellt eine neue Instanz der Ausname
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="satzzeichen"></param>
    ''' <remarks></remarks>
    Sub New(ByVal message As String, ByVal satzzeichen As String)
        MyBase.New(message)
        m_satzzeichen = satzzeichen
    End Sub

    ''' <summary>
    ''' Ruft das Satzzeichen ab, das die Ausnahme ausgelöst hat
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Satzzeichen() As String
        Get
            Return m_satzzeichen
        End Get
    End Property
End Class

''' <summary>
''' Stellt einen einfachen Dateinamen bereit
''' </summary>
''' <remarks></remarks>
Public Class SingleFile
    Implements System.ComponentModel.INotifyPropertyChanged

    Private m_filePath As String = String.Empty
    Private m_Loaded As Boolean

    ''' <summary>
    ''' Zeigt an, das diese Datei bereits geladen wurde
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Loaded() As Boolean
        Get
            Return m_Loaded
        End Get
        Set(ByVal value As Boolean)
            m_Loaded = value
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("Loaded"))

        End Set
    End Property

    Property FilePath As String
        Get
            Return m_filePath
        End Get
        Set(value As String)
            m_filePath = value
            RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs("FilePath"))
        End Set
    End Property

    ''' <summary>
    ''' Ruft den kurzen Namen der Datei ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Dim name As String = m_filePath

        name = System.IO.Path.GetFileName(m_filePath)

        Return name
    End Function

    Public Sub New(fileName As String)
        m_filePath = fileName
    End Sub

    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class

Friend Class SortByextenstion
    Implements IComparer(Of SingleFile)



    Public Function Compare(x As SingleFile, y As SingleFile) As Integer Implements System.Collections.Generic.IComparer(Of SingleFile).Compare
        Try
            If x.FilePath.EndsWith(".WRG") Then
                Return 2
            End If

            Dim ex1, ex2 As String
            ex1 = IO.Path.GetExtension(x.FilePath)
            ex2 = IO.Path.GetExtension(y.FilePath)

            Return ex1.CompareTo(ex2)


        Catch ex As Exception

        End Try
        Return String.Compare(x.FilePath, y.FilePath)

    End Function

End Class