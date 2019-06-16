Option Strict Off

Imports Microsoft.VisualBasic.FileIO
Imports System
Imports System.Drawing
 Imports System.Runtime.InteropServices


Namespace Tools


    ''' <summary>
    ''' Beschreibt den aktuell verwendeten Server-Type
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumServerType
        ''' <summary>
        ''' Noch nicht definiert (für neue Verbindungen)
        ''' </summary>
        ''' <remarks></remarks>
        Undefined = -1
        ''' <summary>
        ''' Lokale Access Datenbank
        ''' </summary>
        ''' <remarks></remarks>
        Access = 0
        ''' <summary>
        ''' MySQL - Server
        ''' </summary>
        ''' <remarks></remarks>
        MySQL = 1
    End Enum


    ''' <summary>
    ''' Enthält Hilfsprogramme zum SpecialPath, Passwörter generieren und weiteres
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Services

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Copyright ©1996-2000 VBnet, Randy Birch, All Rights Reserved.
        ' Some pages may also contain other copyrights by the author.
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' You are free to use this code within your own applications,
        ' but you are expressly forbidden from selling or otherwise
        ' distributing this source code without prior written consent.
        ' This includes both posting free demo projects made from this
        ' code as well as reproducing the code in text or html format.
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Enum SpecialFolderConst
            ''' <summary>
            ''' Desktop
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_DESKTOP = &H0                 '{desktop}
            ''' <summary>
            ''' IE Icon Path
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_INTERNET = &H1                'Internet Explorer (icon on desktop)
            ''' <summary>
            ''' Startmenu / Programs
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_PROGRAMS = &H2                'Start Menu\Programs
            ''' <summary>
            ''' My Computer / Control Panel
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_CONTROLS = &H3                'My Computer\Control Panel
            ''' <summary>
            ''' My Computer/Printers
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_PRINTERS = &H4                'My Computer\Printers
            ''' <summary>
            ''' My Documents
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_PERSONAL = &H5                'My Documents
            ''' <summary>
            ''' {USer}/Favorites
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_FAVORITES = &H6               '{user name}\Favorites
            ''' <summary>
            ''' Start Menu\Programs\Startup
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_STARTUP = &H7                 'Start Menu\Programs\Startup
            ''' <summary>
            ''' {user name}\Recent
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_RECENT = &H8                  '{user name}\Recent
            ''' <summary>
            ''' {user name}\SendTo
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_SENDTO = &H9                  '{user name}\SendTo
            ''' <summary>
            ''' {desktop}\Recycle Bin
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_BITBUCKET = &HA               '{desktop}\Recycle Bin
            ''' <summary>
            ''' {user name}\Start Menu
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_STARTMENU = &HB               '{user name}\Start Menu
            ''' <summary>
            ''' {user name}\Desktop
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_DESKTOPDIRECTORY = &H10       '{user name}\Desktop
            ''' <summary>
            ''' My Computer
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_DRIVES = &H11                 'My Computer
            ''' <summary>
            ''' Network Neighborhood
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_NETWORK = &H12                'Network Neighborhood
            ''' <summary>
            ''' {user name}\nethood
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_NETHOOD = &H13                '{user name}\nethood
            ''' <summary>
            ''' windows\fonts
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_FONTS = &H14                  'windows\fonts
            CSIDL_TEMPLATES = &H15
            ''' <summary>
            ''' All Users\Start Menu
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_COMMON_STARTMENU = &H16       'All Users\Start Menu
            ''' <summary>
            ''' All Users\Programs
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_COMMON_PROGRAMS = &H17        'All Users\Programs
            ''' <summary>
            ''' All Users\Startup
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_COMMON_STARTUP = &H18         'All Users\Startup
            ''' <summary>
            ''' All Users\Desktop
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_COMMON_DESKTOPDIRECTORY = &H19 'All Users\Desktop
            ''' <summary>
            ''' {user name}\Application Data
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_APPDATA = &H1A                '{user name}\Application Data
            ''' <summary>
            ''' {user name}\PrintHood
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_PRINTHOOD = &H1B              '{user name}\PrintHood
            ''' <summary>
            ''' {user name}\Local Settings\ 
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_LOCAL_APPDATA = &H1C          '{user name}\Local Settings\ 
            '_Application Data (non roaming)
            ''' <summary>
            ''' non localized startup
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_ALTSTARTUP = &H1D             'non localized startup
            CSIDL_COMMON_ALTSTARTUP = &H1E      'non localized common startup
            CSIDL_COMMON_FAVORITES = &H1F
            CSIDL_INTERNET_CACHE = &H20
            CSIDL_COOKIES = &H21
            CSIDL_HISTORY = &H22
            ''' <summary>
            ''' All Users\Application Data
            ''' </summary>
            ''' <remarks></remarks>
            CSIDL_COMMON_APPDATA = &H23          'All Users\Application Data
            CSIDL_WINDOWS = &H24                 'GetWindowsDirectory()
            CSIDL_SYSTEM = &H25                  'GetSystemDirectory()
            CSIDL_PROGRAM_FILES = &H26           'C:\Program Files
            CSIDL_MYPICTURES = &H27              'C:\Program Files\My Pictures
            CSIDL_PROFILE = &H28                 'USERPROFILE
            CSIDL_SYSTEMX86 = &H29               'x86 system directory on RISC
            CSIDL_PROGRAM_FILESX86 = &H2A        'x86 C:\Program Files on RISC
            CSIDL_PROGRAM_FILES_COMMON = &H2B    'C:\Program Files\Common
            CSIDL_PROGRAM_FILES_COMMONX86 = &H2C 'x86 Program Files\Common on RISC
            CSIDL_COMMON_TEMPLATES = &H2D        'All Users\Templates
            CSIDL_COMMON_DOCUMENTS = &H2E        'All Users\Documents
            CSIDL_COMMON_ADMINTOOLS = &H2F       'All Users\Start Menu\ _
            'Programs\Administrative Tools
            CSIDL_ADMINTOOLS = &H30              '{user name}\Start Menu _
            '\Programs\Administrative Tools
            CSIDL_FLAG_CREATE = &H8000           'combine with CSIDL_ value to force 
            'create on SHGetSpecialFolderLocation()
            CSIDL_FLAG_DONT_VERIFY = &H4000      'combine with CSIDL_ value to force 
            'create on SHGetSpecialFolderLocation()
            CSIDL_FLAG_MASK = &HFF00             'mask for all possible flag values
            SHGFP_TYPE_CURRENT = &H0             'current value for user verify it exists
            SHGFP_TYPE_DEFAULT = &H1
            MAX_PATH = 260

        End Enum
        ''' <summary>
        ''' Stellt einen P/invoke bereit, der Systemordner zurückliefert
        ''' </summary>
        ''' <param name="hwndOwner"></param>
        ''' <param name="nFolder"></param>
        ''' <param name="hToken"></param>
        ''' <param name="dwFlags"></param>
        ''' <param name="pszPath"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Runtime.InteropServices.DllImport("shell32.dll")> _
           Private Shared Function SHGetFolderPath(ByVal hwndOwner As IntPtr, ByVal nFolder As Int32, ByVal hToken As IntPtr, ByVal dwFlags As Int32, ByVal pszPath As System.Text.StringBuilder) As Int32
        End Function


        Public Shared PathSeperator As Char = System.IO.Path.DirectorySeparatorChar
        Private Const CSIDL_WINDOWS As Integer = &H24

        Public Shared Function GetSpecialFolder(ByVal FolderType As SpecialFolderConst) As String
            Dim Path As New System.Text.StringBuilder(300)

            If SHGetFolderPath(Nothing, FolderType, Nothing, 0, Path) = 0 Then
                Return Path.ToString
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' Ruft eine neue, eindeutige GUID ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetGUID() As String
            Dim GUID As String = System.Guid.NewGuid.ToString
            GUID = GUID.Replace("-"c, "").ToUpper

            Return GUID
        End Function

        ''' <summary>
        ''' Erstellt eine neue eindeutige HWL-ID Kennung
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetNewHWLID() As String
            Dim baseKey As String = GetGUID.Substring(0, 20)
            baseKey = GenerateCheckedKey(baseKey)
            Return baseKey
        End Function

        ''' <summary>
        ''' Verlängert den eingegebenen Schlüssel um den Prüf-Anteil
        ''' </summary>
        ''' <param name="InKey">ein 20-stelliger Schlüssel</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GenerateCheckedKey(ByVal InKey As String) As String
            If InKey.Length > 20 Then
                Throw New ArgumentException("Basis-sicherheitsschlüssel hat eine falsche Länge! Genau 20 Zeichen gefordert!")
            End If

            Dim Tail As String = String.Empty
            Dim CheckSum As Integer
            Dim a As Integer
            ' Das geht nur für Keys, die 20 Zeichen lang sind

            If InKey.Length < 21 Then
                ' Erzeuge Prüfsumme

                Tail = ""
                For a = 1 To 20
                    ' alle 5 Zeichen ein neues Erzeugen
                    CheckSum = CheckSum + Asc(Mid(InKey, a, 1)) + a
                    If a Mod 5 = 0 Then
                        CheckSum = CheckSum Mod 36 ' 26 Buchstaben + 10 Ziffern
                        ' nun noch eine Abbildung schaffen
                        ' 1. Alle Ziffern filtern Ascii 48 - 57

                        If CheckSum < 10 Then
                            CheckSum = CheckSum + 48 ' Offset zu den Ziffern
                        Else
                            CheckSum -= 10
                            CheckSum = CheckSum + 65  ' Offset zu den Buchstaben
                        End If 'CheckSum < 10
                        Tail = Tail & Chr(CheckSum) ' ein Zeichen anhängen
                        CheckSum = 0
                    End If ' a Mod 5 = 0

                Next a

                ' Zum Schluss den Tail selber nocheinmal Checken
                For a = 1 To 4
                    CheckSum = CheckSum + Asc(Mid(Tail, a, 1))
                Next a

                CheckSum = CheckSum Mod 36 ' 26 Buchstaben + 10 Ziffern
                ' nun noch eine Abbildung schaffen
                ' 1. Alle Ziffern filtern Ascii 48 - 57

                If CheckSum < 10 Then
                    CheckSum = CheckSum + 48 ' Offset zu den Ziffern
                Else
                    CheckSum -= 10
                    CheckSum = CheckSum + 65  ' Offset zu den Buchstaben
                End If
                Tail = Tail & Chr(CheckSum) ' ein Zeichen anhängen

                ' (tmpZahl < 48 Or tmpZahl > 57) And (tmpZahl < 65 Or tmpZahl > 90)


            Else 'Len(InKey) < 21
                Debug.Print("Der erzeugte Schlüssel ist nicht gültig. Er ist zu lang. (" & Len(InKey) & ") statt 20.")
            End If

            Return InKey & Tail

        End Function

        ''' <summary>
        ''' Prüft, ob der Code gültig ist
        ''' </summary>
        ''' <param name="Eingabe">Die letzten 5 Zeichen des Codes</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CheckIfCodeIsValid(ByVal Eingabe As String) As Boolean
            Dim summe As Long

            CheckIfCodeIsValid = False
            ' einige Prüfungen
            If Len(Eingabe) <> 5 Then
                Debug.Print("Programmcode muss 5 Zeichen lang sein  ")
                Exit Function
            End If

            ' Prüfen, ob der String auch OK ist. siehe Bug #20
            ' 4 Ziffern addieren, 5. Ziffer errechnen:

            summe = _
                Asc(Mid(Eingabe, 1, 1)) + _
                Asc(Mid(Eingabe, 2, 1)) + _
                Asc(Mid(Eingabe, 3, 1)) + _
                Asc(Mid(Eingabe, 4, 1))

            summe = summe Mod 36

            If summe < 10 Then
                summe = summe + 48 ' Offset zu den Ziffern
            Else
                summe = summe - 10
                summe = summe + 65 ' Offset zu den Buchstaben
            End If
            ' nun ist chr(summe) = dem letzten Zeichen, wenn nicht, dann stimmt was nicht
            If Chr(summe) <> Mid(Eingabe, 5, 1) Then
                Debug.Print("ungültiger Programm-Code")
                Exit Function
            Else
                CheckIfCodeIsValid = True
            End If

            ' ab hier ist der Code OK
            ' erzeuge also den neuen Code
        End Function


        ''' <summary>
        ''' Ermittelt den Standard-Pfad zur Access-Datenbank. (AllUseres ApplicationData\ProgramName\Daten\daten.mdb)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDefaultDataPath() As String
            Dim appData As String = GetSpecialFolder(SpecialFolderConst.CSIDL_COMMON_APPDATA)
            appData = System.IO.Path.Combine(appData, MainApplication.ApplicationName) ' Programmname im Pfad einbauen

            appData = System.IO.Path.Combine(appData, "Daten") ' Daten-Pfad einsetzen

            Return appData
        End Function

        ''' <summary>
        ''' Ermittelt das Passwort für die Access-Datenbank aus der bestehenden INI-Datei, die im angegeben Pfad liegt.
        ''' </summary>
        ''' <param name="Path">Der Pfad der Datenbank.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDBPassword(ByVal Path As String) As String
            Dim value As String = GetIDFromINIFile(Path)

            If value.Length = 25 Then
                Return value.Substring(0, 14)
            End If

            Return "" ' dann war es falsch
        End Function

        ''' <summary>
        ''' Ruft die HWL-ID anhand des INI-Files ab
        ''' </summary>
        ''' <param name="Path"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetIDFromINIFile(ByVal Path As String) As String
            If Path.Length > 0 Then
                Dim Folder As String

                If Path.EndsWith("\daten.mdb", StringComparison.InvariantCultureIgnoreCase) Then
                    Path = Path.Substring(0, Path.Length - 10)
                End If

                Folder = Path

                Const CodeFilename As String = "HWL.INI"

                'Im Pfad liegt auch die HWL.INI
                Dim folderExists As Boolean
                folderExists = My.Computer.FileSystem.DirectoryExists(Folder)
                Dim CodeFile As String = Folder & PathSeperator & CodeFilename
                Dim fileExists As Boolean
                fileExists = My.Computer.FileSystem.FileExists(CodeFile)

                If folderExists Then
                    Dim filename As String = Path

                    Dim fields As String() = Nothing
                    Dim delimiter As String = ":"
                    If System.IO.File.Exists(CodeFile) Then
                        Using parser As New TextFieldParser(CodeFile)
                            parser.SetDelimiters(delimiter)
                            While Not parser.EndOfData
                                ' Read in the fields for the current line
                                fields = parser.ReadFields()
                                ' Add code here to use data in fields variable.

                            End While
                        End Using
                    End If
                    If fields IsNot Nothing AndAlso fields.Length = 2 Then
                        Return fields(1)

                    End If

                End If
            End If
            Return ""
        End Function

    End Class

    Public Class Tools
        Private m_mainApplicaton As MainApplication

        ''' <summary>
        ''' Enthält die Ersetzungsregel für Nummern
        ''' </summary>
        ''' <remarks></remarks>
        Dim regNumberValue As New System.Text.RegularExpressions.Regex("\$NR", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Compiled)

        Dim regShortYearValue As New System.Text.RegularExpressions.Regex("\$YY|\$JJ", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Compiled)
        Dim regLongYearValue As New System.Text.RegularExpressions.Regex("\$YYYY|\$JJJJ", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Compiled)
        Dim regShortMonthValue As New System.Text.RegularExpressions.Regex("\$M", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Compiled)
        Dim regLongMonthValue As New System.Text.RegularExpressions.Regex("\$MM", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Compiled)
        Dim regShortDayValue As New System.Text.RegularExpressions.Regex("\$D", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Compiled)
        Dim regLongtDayValue As New System.Text.RegularExpressions.Regex("\$DD", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Compiled)

        ''' <summary>
        ''' Ruft eine Auflistung an gültigen Erstungsregeln für den Nummerngenerator ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReplacementStringsNumbergenerator() As Dictionary(Of String, String)
            Dim lst As New Dictionary(Of String, String)
            'TODO: NLS
            lst.Add("$NR", " Pflicht. Muss immer enthalten sein")
            lst.Add("$YY", " 2-Stellige Jahreszahl")
            lst.Add("$YYYY", " 4-stellige Jahreszahl")
            lst.Add("$M", " Normale Monatszahl")
            lst.Add("$MM", " 2-Stellige Monatszahl")
            lst.Add("$D", " normale Tageszahl")
            lst.Add("$DD", " 2-Stellige Tageszahl")


            Return lst

        End Function
        ' Datenspeicher kann die Datenbank, oder ein Verzeichnis sein? 
        Sub New(ByVal mainApplication As MainApplication)
            m_mainApplicaton = mainApplication
        End Sub

        ''' <summary>
        ''' Fügt eine Anzahl zu einem Bild hinzu
        ''' </summary>
        ''' <param name="bImg"></param>
        ''' <param name="msg"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function AddTextToImage(ByVal bImg As Bitmap, ByVal msg As String) As System.Drawing.Bitmap

            ' To void the error due to Indexed Pixel Format
            Dim img As System.Drawing.Image = New Bitmap(bImg, New System.Drawing.Size(bImg.Width, bImg.Height))
            Dim tmpImage As Bitmap = New Bitmap(img)
            Using graphic As Graphics = Graphics.FromImage(tmpImage)
                'Watermark effect
                Using brush As New System.Drawing.SolidBrush(Color.White)
                    Dim msgFont As New Font("Arial", 8, FontStyle.Bold)

                    Dim textSize As System.Drawing.SizeF = graphic.MeasureString(msg, msgFont, 16)

                    graphic.FillRectangle(Brushes.Red, New Rectangle(1, 1, textSize.Width, textSize.Height))

                    'Draw the text string to the Graphics object at a given position.
                    graphic.DrawString(msg, msgFont, brush, New PointF(1, 1))
                End Using
            End Using
            Return tmpImage
        End Function

        ''' <summary>
        ''' Ruft einen Anzeigetext für Journalnummern ab
        ''' </summary>
        ''' <param name="ActualNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateAdressDisplayID(ByVal ActualNumber As Integer, ByVal itemDate As Date) As String
            Dim Formatstr As String
            Dim OffsetNumber As String

            Formatstr = m_mainApplicaton.Settings.SettingAdressID_Format
            OffsetNumber = m_mainApplicaton.Settings.SettingAdressID_Base

            Dim NewNumber As Long
            Dim newdisplayID As String

            NewNumber = ActualNumber + OffsetNumber

            newdisplayID = GetDisplayID(NewNumber, Formatstr, itemDate)

            Return newdisplayID

        End Function

        ''' <summary>
        ''' Ruft einen Anzeigetext für Angebote und alle weiteren Journaldokuemnte (ausser Rechnungen)  ab
        ''' </summary>
        ''' <param name="ActualNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateOffersDisplayID(ByVal actualNumber As Integer, ByVal itemDate As Date) As String
            Dim Formatstr As String
            Dim OffsetNumber As String

            Formatstr = m_mainApplicaton.Settings.SettingOffersID_Format
            OffsetNumber = m_mainApplicaton.Settings.SettingOffersID_Base

            Dim NewNumber As Long
            Dim newdisplayID As String

            NewNumber = actualNumber + OffsetNumber

            newdisplayID = GetDisplayID(NewNumber, Formatstr, itemDate)

            Return newdisplayID

        End Function

        ''' <summary>
        ''' Ruft einen Anzeigetext für Journaldokumente (Rechnungen) ab
        ''' </summary>
        ''' <param name="ActualNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateInvoicesDisplayID(ByVal actualNumber As Integer, ByVal itemDate As Date) As String
            Dim Formatstr As String
            Dim OffsetNumber As String

            Formatstr = m_mainApplicaton.Settings.SettingInvoicesID_Format
            OffsetNumber = m_mainApplicaton.Settings.SettingInvoicesID_Base

            Dim NewNumber As Long
            Dim newdisplayID As String

            NewNumber = actualNumber + OffsetNumber

            newdisplayID = GetDisplayID(NewNumber, Formatstr, itemDate)

            Return newdisplayID

        End Function

        ''' <summary>
        ''' Ruft den Anzeigetext anhand eines gegebenen Eingabeformates ab
        ''' </summary>
        ''' <param name="number">Die aktuelle logische Nummer</param>        
        ''' <param name="formatstring">Die Formatierungszeichenfolge. ein "$NR" ist pflicht</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDisplayID(ByVal number As Integer, ByVal formatstring As String, ByVal itemDate As Date) As String
            Dim retValue As String
            If Not regNumberValue.IsMatch(formatstring) Then
                m_mainApplicaton.Log.WriteLog(ClausSoftware.Tools.LogSeverity.ErrorMessage, "Ein $NR konnte im Formatstring nicht gefunden werden. War (" & formatstring & ")")

                Throw New ArgumentException("Ein '$NR' konnte nicht in der Eingabezeichenfolge gefunden werden")
            Else

                Dim sint As New System.Globalization.NumberFormatInfo


                retValue = regNumberValue.Replace(formatstring, number) ' Nummer austauschen 

                Dim longYear As String = itemDate.Year

                retValue = regLongYearValue.Replace(retValue, itemDate.Year.ToString("####")) ' Langer Monat (01.dd.yyyy)   führende Null
                retValue = regShortYearValue.Replace(retValue, (itemDate.Year.ToString.Substring(2)))

                retValue = regLongMonthValue.Replace(retValue, itemDate.Month)
                retValue = regShortMonthValue.Replace(retValue, itemDate.Month)

                retValue = regLongtDayValue.Replace(retValue, itemDate.Day)
                retValue = regShortDayValue.Replace(retValue, itemDate.Day)

                Return retValue
            End If

        End Function


        ''' <summary>
        ''' Holt ein Bild per angegebenen Schlüssel aus dem Datenspeicher
        ''' </summary>
        ''' <param name="imageID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetImage(ByVal imageID As String) As Drawing.Image
            If imageID IsNot Nothing AndAlso imageID.Length > 0 Then

                Dim ImageData As Kernel.ImageData = m_mainApplicaton.Images.GetItem(imageID)
                If ImageData IsNot Nothing Then
                    Return ImageData.Image
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If

        End Function

        'todo: Bilderlisten per Referenz-ID abholen lassen




        Function SaveImage(ByVal key As String, ByVal name As String, ByVal description As String, ByVal path As String, ByVal imageToSave As Drawing.Image) As String

            Dim session As New Session
            Dim newImage As New Kernel.ImageData(session)
            newImage.FilePath = path
            newImage.Name = name
            newImage.Description = description
            newImage.Image = imageToSave
            newImage.ReferenceID = key
            m_mainApplicaton.Images.Add(newImage)
            newImage.Save()

            Return newImage.ReplikID

        End Function

        ''' <summary>
        ''' Ruft eine Liste mit allen Bildern aus dem Datenspeicher ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function ListImages() As String()

        End Function

        ''' <summary>
        ''' Entfernt ein Bild aus dem Datenspeicher
        ''' </summary>
        ''' <param name="key"></param>
        ''' <remarks></remarks>
        Sub RemoveImage(ByVal key As String)

        End Sub

    End Class

    ''' <summary>
    ''' Enthält eine Auflistung der RegistrySchlüssel für HWL1 und HWL2, Kennzeichnet die Areas, in der die Namenlicchen Werte stehen
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Class RegistrySections
        ''' <summary>
        ''' Ruft den Namen des Ordner "Server" ab,in dem die Datenbankverbindungen gespeichert sind
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>      
        Shared ReadOnly Property Server() As String
            Get
                Return "Server"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Bezeichner für Kommunikationseinstellungen ab, Senden der Qualifeedback Notizen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Communication() As String
            Get
                Return "Protokoll"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Namen des Ordner 'Current_Version' ab, In diesem werden wichtige allgemeine Daten gespeichert, die Rechnerabhängig sind
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property CurrentVersion() As String
            Get
                Return "Current Version"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Basisnamen für das Modul "Artikel" ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property ModuleArticles() As String
            Get
                Return "Articles"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Stamm-Schlüssel für Eigenschaften aus dem Bereich "Angebote/Rechnungen" ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property ModuleInvoices() As String
            Get
                Return "Kalkulation"
            End Get
        End Property

        ''' <summary>
        ''' Speichert Layoutdaten der Formulare, des Grids usw Rechnerabhängig ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property ModuleLayout() As String
            Get
                Return "Layout"
            End Get
        End Property
    End Class



    ''' <summary>
    ''' Enthält die Registry- Schlüssel die im jeweiligen Abschnitt (RegistrySection) enthaltn sind.
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> _
    Public Class RegistryValues
        Shared ReadOnly Property Server_MaxServerCount() As String
            Get
                Return "MaxServer"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den schlüssel ab, der für das drucken der Memo (Langtexte) zuständig ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property PrintMemoTexte As String
            Get
                Return "PrintMemoTexte"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Einstellungenamen für das Anzeigen von Rabatten in der Artikelliste ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property ShowArticleDiscounts() As String
            Get
                Return "ShowArticleDiscounts"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Einstellungsnamen für das Anzeigen von Rohstoffen in der Artikelliste ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property ShowArticleRessources() As String
            Get
                Return "ShowArticleRessources"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Schlüsselnamen für den standard-Steuersatz ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property ArticleDefaultTax() As String
            Get
                Return "ArticleDefaultTax"
            End Get
        End Property




        ''' <summary>
        ''' Ruft den eigenschaftennamen des Debuglevels ab; Wert iste eine ganze Zahl, die angibt wie genau das Protokoll geschrieben werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property DebugLevel() As String
            Get
                Return "Debug"
            End Get
        End Property


        ''' <summary>
        ''' enthält den Schlüssel, der die Nummer des Standard-Eintrages enthält. "-2" bedeutet, das der Pfad unter \CurrentUser\ benutzt wird.
        ''' "-2" wird jedoch nicht mehr gesetzt, aber noch aus Kompatibilitätsgründen ausgelesen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Server_DefaultNumber() As String
            Get
                Return "Default"
            End Get
        End Property
        ''' <summary>
        ''' Enthält den AliasNamen der aktuellen Verbindung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Server_AliasName() As String
            Get
                Return "Alias"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den Eigenschaftsnamen für das Anzeigen der Mehrwertsteuer in Rechnungen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property RegKeyShowMWST() As String
            Get
                Return "MWSTEinblenden"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den Eigenschaftsnamen für die zultzt genutze Dokumenten-Nr
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property RegLastUsedDocumentNumber As String
            Get
                Return "LastUsedDocumentNumber"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den eigenschaftsnamen für das anzeigen oder verbergen von Artikeln
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property RegKeyShowInactiveItems() As String
            Get
                Return "ShowInactiveItemsInLists"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den eigenschaftsnamen für das Anzeigen von Netto- oder Bruttopreisen. 
        ''' In Verbindung mit der Anzeige der MwSt wird ein Artikel "ink.""Mwst oder "plus MwSt" angezeigt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property RegKeyShowItemsNetto() As String
            Get
                Return "ShowNetto"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den Schlüssel für gerundete Steuerdaten
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property RegKeyShowRoundedTaxValues As String
            Get
                Return "ShowRoundedTaxValues"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den Datenbanknamen der Verbindung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Server_DatabaseName() As String
            Get
                Return "Databasename"
            End Get
        End Property

        ''' <summary>
        ''' Enthält das Passwort der Verbinung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Server_Password() As String
            Get
                Return "DBPassword"
            End Get
        End Property
        ''' <summary>
        ''' Enthält den Servernamen der Verbindung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Server_Servername() As String
            Get
                Return "Servername"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den Servertype der Verbindung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Server_Servertype() As String
            Get
                Return "Servertype"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den Pfad zur Datenbank
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Server_Path() As String
            Get
                Return "Path"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den Sicherungs-Pfad zur Datenbank
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Server_BackupPath() As String
            Get
                Return "BackupPath"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den Schlüssel des Benutzernamen der Verbindung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Server_Username() As String
            Get
                Return "Username"
            End Get
        End Property

        ''' <summary>
        ''' Enthält den schlüssel zum Pfad zur AccessDatenbank
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property Data_Path() As String
            Get
                Return "DataPath"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Schlüsselnamen des Basiswertes für Rechnungen ab (alle dokuemntentypen ausser Angebote)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property DocumentID_Base() As String
            Get
                Return "DocIDSockel"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Schlüsselnamen für den Formatstring für Dokumentennummern ab (Angebote /Rechnungen)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property DocID_Format() As String
            Get
                Return "DocIDFormat"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Schlüsselnamen des Basiswertes für Angebote ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property OffersID_Base() As String
            Get
                Return "OffersIDSockel"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Schlüsselnamen für den Formatstring für Angebote-Nummern ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property OffersID_Format() As String
            Get
                Return "OffersIDFormat"
            End Get
        End Property


        ''' <summary>
        ''' Ruft den Konfigurationsnamen füür die ID des Standard-Steuersatzes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property DefaultTaxID() As String
            Get
                Return "DefaultTaxID"
            End Get
        End Property


        ''' <summary>
        ''' Ruft den Schlüsselnamen für den Basiswert für Adressennummern ab.
        ''' </summary>
        Shared ReadOnly Property AdressID_Base() As String
            Get
                Return "KundennrSockel"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Schlüsselnamen für den Standard-Steuersatz der Steuern für Kassenbuchaktionen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property DefaultCashAccountTaxID As String
            Get
                Return "DefaultCashAccountTaxID"
            End Get
        End Property
        ''' <summary>
        ''' Ruft den Wertenamen für das verwendete Buchungskonto ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared ReadOnly Property InvoicesAccountNumber() As String
            Get
                Return "Buchkonto"
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Schlüsselnamen für den Formatstring für Adressennummern ab.
        ''' </summary>
        Shared ReadOnly Property AdressID_Format() As String
            Get
                Return "KundennrFormat"
            End Get
        End Property



    End Class



    ''' <summary>
    ''' Summary description for ShellIcon.
    ''' Summary description for ShellIcon. Get a small or large Icon with an easy C# function call
    ''' that returns a 32x32 or 16x16 System.Drawing.Icon depending on which function you call
    ''' either GetSmallIcon(string fileName) or GetLargeIcon(string fileName)
    ''' </summary>
    Public Class ShellIcon
        <StructLayout(LayoutKind.Sequential)> _
       Public Structure SHFILEINFO
            Public hIcon As IntPtr
            Public iIcon As IntPtr
            Public dwAttributes As UInteger
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
             Public szDisplayName As String
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
             Public szTypeName As String
        End Structure


        Private Class Win32
            Public Const SHGFI_ICON As UInteger = 256
            Public Const SHGFI_LARGEICON As UInteger = 0
            ' 'Large icon
            Public Const SHGFI_SMALLICON As UInteger = 1
            ' 'Small icon

            <DllImport("shell32.dll")> _
           Public Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, ByVal cbSizeFileInfo As UInteger, ByVal uFlags As UInteger) As IntPtr
            End Function
        End Class


        Public Sub New()
        End Sub


        Public Shared Function GetSmallIcon(ByVal fileName As String) As Icon
            Dim hImgSmall As IntPtr
            'the handle to the system image list
            Dim shinfo As New SHFILEINFO()


            'Use this to get the small Icon
            hImgSmall = Win32.SHGetFileInfo(fileName, 0, shinfo, CUInt(Marshal.SizeOf(shinfo)), Win32.SHGFI_ICON Or Win32.SHGFI_SMALLICON)


            'The icon is returned in the hIcon member of the shinfo struct
            Return (System.Drawing.Icon.FromHandle(shinfo.hIcon))
        End Function


        Public Shared Function GetLargeIcon(ByVal fileName As String) As Icon
            Dim hImgLarge As IntPtr
            'the handle to the system image list
            Dim shinfo As New SHFILEINFO()


            'Use this to get the large Icon
            hImgLarge = Win32.SHGetFileInfo(fileName, 0, shinfo, CUInt(Marshal.SizeOf(shinfo)), Win32.SHGFI_ICON Or Win32.SHGFI_LARGEICON)

            If hImgLarge.ToInt32 <> 0 Then
                'The icon is returned in the hIcon member of the shinfo struct
                Return (System.Drawing.Icon.FromHandle(shinfo.hIcon))
            Else
                Return Nothing
            End If
        End Function
    End Class

    ''' <summary>
    ''' Ruft den lokalisierten AnzeigeNamen ienr eigenschaft ab
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DisplayNameAttribute
        Inherits System.ComponentModel.DisplayNameAttribute


        Private m_key As String
        Private m_defaultText As String


        ''' <summary>
        ''' Erstellt einenen neuen Anzeigenamen mit dem angegeben schlüsel und einem Standardtext
        ''' </summary>
        ''' <param name="key"></param>
        ''' <param name="defaultText"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal key As String, ByVal defaultText As String)
            m_key = key
            m_defaultText = defaultText
        End Sub

        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse mit dem angegebenen Anzeigenamen
        ''' </summary>
        ''' <param name="displayName"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal displayName As String)
            MyBase.New(displayName)

        End Sub

        ''' <summary>
        ''' Ruft den lokalisierten Anzeigenamen ab. 
        ''' AnzeigeName beginnt immer mit einem "prop_"  für Property
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides ReadOnly Property DisplayName() As String
            Get
                If MainApplication.getInstance IsNot Nothing Or String.IsNullOrEmpty(m_key) Then ' Falls das Applikationsobjekt nicht gesetzt ist oder kein Schlüssel angegeben wurde, dann normal verhalten
                    Return MainApplication.getInstance.Languages.GetText("prop_" & m_key, m_defaultText)
                Else
                    Return MyBase.DisplayName
                End If

            End Get
        End Property

    End Class

    ''' <summary>
    ''' Markiert eine Spalte als 'Importierbar' Diese wird in Import-Dialogen dann auch angezeigt
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ImportableAttribute
        Inherits Attribute


    End Class

    ''' <summary>
    ''' Kennzeichnet eine sichtbare Eigenschaft so, das diese nicht Standardmässig eingeblendet werden soll.
    ''' Damit wird in Grids dieser Wert nicht angezeigt, sondern erst durch das 'Customization' - Formular zugänglich gemacht
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.Property)> _
    Public Class DefaultGridVisibleAttribute
        Inherits Attribute

        Private m_visible As System.ComponentModel.EditorBrowsableState
        ''' <summary>
        ''' Zeigt an, ob eine Eigenschaft immer sichtbar sein soll oder nur im "Custom" - Menü (Advanced-Einstellung) 
        ''' </summary>
        ''' <value></value>
        ''' <returns>'Advanced': Diese Eigenschaft ist erst im customize-Formular sichtbar, 
        ''' 'Always' (Default)  Diese Eigenschaft ist sofort sichtbar
        ''' 'Never' diese eigenschaft ist nicht sichtbar und kann auch nicht im customize-Menü erreiht werden.</returns>
        ''' <remarks></remarks>
        Public Property Visible() As System.ComponentModel.EditorBrowsableState
            Get
                Return m_visible
            End Get
            Set(ByVal value As System.ComponentModel.EditorBrowsableState)
                m_visible = value
            End Set
        End Property

        Public Sub New(ByVal visible As System.ComponentModel.EditorBrowsableState)
            MyBase.New()

            m_visible = visible
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

    End Class

End Namespace



