Imports DevExpress.XtraReports.UI

''' <summary>
''' Enthält ein Druck-Manager für das alte Druck-System.
''' Von hier sollte nur einmal die daten gelesen werden; danach sollten die Layoutdaten ausschliesslich aus dem neuen Format her kommen
''' </summary>
''' <remarks></remarks>
Public Class PrintingManagerOldSystem
    Private Const PrintControlAdressWindow As String = "lblAddressField"
    Private Const PrintControlAdressLine As String = "lblAddressLine"


    Private m_currentReport As XtraReport


    Const KeyLayout As String = "SeitenLayout"
    ' Logo 1
    Const PrnValPHTop As String = "PHTop"
    Const PrnValPHLeft As String = "PHLeft"
    Const PrnValPHWidth As String = "PHWidth"
    Const PrnValPHHeight As String = "PHHeight"
    Const prnValPHEnabled As String = "PHEnabled"
    Const prnValPHPfad As String = "PHPfad"
    'Logo2
    Const PrnValPH2Top As String = "PH2Top"
    Const PrnValPH2Left As String = "PH2Left"
    Const PrnValPH2Width As String = "PH2Width"
    Const PrnValPH2Height As String = "PH2Height"
    Const prnValPH2Enabled As String = "PH2Enabled"
    Const prnValPH2Pfad As String = "PH2Pfad"


    ' BankVerbindung (1. Kasten)
    Const prnValBankTop As String = "BankTop"
    Const prnValBankLeft As String = "BankLeft"
    Const prnValBankWidth As String = "BankWidth"
    Const prnValBankHeight As String = "BankHeight"
    Const prnValBankText As String = "BankText"
    Const prnValBankAlignment As String = "BankAlignment"
    Const prnValBankFont As String = "BankFont"
    Const prnValBankGroesse As String = "BankSize"
    Const prnValBankUnterstrichen As String = "BankUnterstrichen"
    Const prnValBankEnable As String = "BankEnable"
    Const prnValBankFett As String = "BankFett"
    Const prnValBankKursiv As String = "BankKursiv"
    Const prnValBankFarbe As String = "BankFarbe"

    ' slogan (2. Kasten)
    Const prnValSloganTop As String = "SloganTop"
    Const prnValSloganLeft As String = "SloganLeft"
    Const prnValSloganWidth As String = "SloganWidth"
    Const prnValSloganText As String = "SloganText"
    Const prnValSloganHeight As String = "SloganHeight"
    Const prnValSloganAlignment As String = "SloganAlignment"
    Const prnValSloganFont As String = "SloganFont"
    Const prnValSloganGroesse As String = "SloganSize"
    Const prnValSloganUnterstrichen As String = "SloganUnterstrichen"
    Const prnValSloganEnable As String = "SloganEnable"
    Const prnValSloganFett As String = "SloganFett"
    Const prnValSloganKursiv As String = "SloganKursiv"
    Const prnValSloganFarbe As String = "SloganFarbe"

    'Toptext1
    Const prnValTopText1Top As String = "TopText1Top"
    Const prnValTopText1Left As String = "TopText1Left"
    Const prnValTopText1Width As String = "TopText1Width"
    Const prnValTopText1Height As String = "TopText1Height"
    Const prnValTopText1Text As String = "TopText1Text"
    Const prnValTopText1Alignment As String = "TopText1Alignment"
    Const prnValTopText1Font As String = "TopText1Font"
    Const prnValTopText1Groesse As String = "TopText1Size"
    Const prnValTopText1Unterstrichen As String = "TopText1Unterstrichen"
    Const prnValTopText1Enable As String = "TopText1Enable"
    Const prnValTopText1Fett As String = "TopText1Fett"
    Const prnValTopText1Kursiv As String = "TopText1Kursiv"
    Const prnValTopText1Farbe As String = "TopText1Farbe"

    'Toptext2
    Const prnValTopText2Top As String = "TopText2Top"
    Const prnValTopText2Left As String = "TopText2Left"
    Const prnValTopText2Width As String = "TopText2Width"
    Const prnValTopText2Height As String = "TopText2Height"
    Const prnValTopText2Text As String = "TopText2Text"
    Const prnValTopText2Alignment As String = "TopText2Alignment"
    Const prnValTopText2Font As String = "TopText2Font"
    Const prnValTopText2Groesse As String = "TopText2Size"
    Const prnValTopText2Unterstrichen As String = "TopText2Unterstrichen"
    Const prnValTopText2Enable As String = "TopText2Enable"
    Const prnValTopText2Fett As String = "TopText2Fett"
    Const prnValTopText2Kursiv As String = "TopText2Kursiv"
    Const prnValTopText2Farbe As String = "TopText2Farbe"


    ' Fensterzeile
    Const prnValFensterzeileTop As String = "FensterzeileTop"
    Const prnValFensterzeileLeft As String = "FensterzeileLeft"
    Const prnValFensterzeileWidth As String = "FensterzeileWidth"
    Const prnValFensterzeileText As String = "FensterzeileText"
    Const prnValFensterzeileHeight As String = "FensterzeileHeight"
    Const prnValFensterzeileAlignment As String = "FensterzeileAlignment"
    Const prnValFensterzeileFont As String = "FensterzeileFont"
    Const prnValFensterzeileGroesse As String = "FensterzeileSize"
    Const prnValFensterzeileUnterstrichen As String = "FensterzeileUnterstrichen"
    Const prnValFensterzeileEnable As String = "FensterzeileEnable"
    Const prnValFensterzeileFett As String = "FensterzeileFett"
    Const prnValFensterzeileKursiv As String = "FensterzeileKursiv"
    Const prnValFensterzeileFarbe As String = "FensterzeileFarbe"

    ' Adressfenster
    Const prnValAdressfensterTop As String = "AdressfensterTop"
    Const prnValAdressfensterLeft As String = "AdressfensterLeft"
    Const prnValAdressfensterWidth As String = "AdressfensterWidth"
    Const prnValAdressfensterText As String = "AdressfensterText"
    Const prnValAdressfensterHeight As String = "AdressfensterHeight"
    Const prnValAdressfensterAlignment As String = "AdressfensterAlignment"
    Const prnValAdressfensterFont As String = "AdressfensterFont"
    Const prnValAdressfensterGroesse As String = "AdressfensterSize"
    Const prnValAdressfensterUnterstrichen As String = "AdressfensterUnterstrichen"
    Const prnValAdressfensterFarbe As String = "AdressfensterFarbe"

    Const prnValAdressfensterEnable As String = "AdressfensterEnable"
    Const prnValAdressfensterFett As String = "AdressfensterFett"
    Const prnValAdressfensterKursiv As String = "AdressfensterKursiv"

    Const prnValAdressfensterTopOffset As String = "AdressfensterOffset"  ' die zusätzliche vertikale Verschiebung des Adressfensters (mit Adresszeile)
    Const prnValAdressfensterLeftOffset As String = "AdressfensterLeftOffset"



    ''' <summary>
    ''' Legt Daten für ein grafisches Logo fest
    ''' </summary>
    ''' <remarks></remarks>
    Structure structLogoBoxSettings
        Public location As System.Drawing.Point
        Public size As System.Drawing.Size
        Public Image As Image
        Public enabled As Boolean

    End Structure

    ''' <summary>
    ''' enthält Daten für eine textbox
    ''' </summary>
    ''' <remarks></remarks>
    Structure structTextBoxSettings
        Public location As System.Drawing.Point
        Public size As System.Drawing.Size
        Public text As String
        Public font As System.Drawing.Font
        Public color As System.Drawing.Color
        Public enable As Boolean
        'Public alignment As System.Windows.Forms
        Public alignment As System.Windows.Forms.HorizontalAlignment

    End Structure

    Private logo1 As New structLogoBoxSettings
    Private logo2 As New structLogoBoxSettings

    ''' <summary>
    ''' Die erste Textbox (oben)
    ''' </summary>
    ''' <remarks></remarks>
    Private toptext1 As New structTextBoxSettings
    Private toptext2 As New structTextBoxSettings
    Private Fensterzeile As New structTextBoxSettings
    Private AdressField As New structTextBoxSettings

    'Untere Textfelder
    Private bank As New structTextBoxSettings
    Private slogan As New structTextBoxSettings


    Private Const TwipPermm As Double = 5.67

    Private m_justAdresswindow As Boolean

    ''' <summary>
    ''' Bei true wird lediglich das Adressfenster und die Fensterzeile geschrieben
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property JustAdresswindow() As Boolean
        Get
            Return m_justAdresswindow
        End Get
        Set(ByVal value As Boolean)
            m_justAdresswindow = value
            Dim t As New TextBox

        End Set
    End Property

    ''' <summary>
    ''' Holt von dem aktuelle Report den Seitenrand ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMargin() As System.Drawing.Printing.Margins
        Return m_currentReport.Margins
    End Function

    Public Sub LoadPageSettings(ByVal rep As XtraReport)

        m_currentReport = rep

        ReadPageSettings()
        SetSimplePageSettings(rep)

    End Sub


    ''' <summary>
    ''' Ruft den minimalen Seitenrand in 1/100 Zoll ab
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PrinterBounds() As System.Drawing.Point

        Dim ps As New System.Drawing.Printing.PageSettings()
        Dim pp As New System.Drawing.Printing.PrinterSettings()


        For Each pname As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            pp.PrinterName = pname
            If pp.IsDefaultPrinter Then
                ps.PrinterSettings = pp

                Return New System.Drawing.Point(CInt(ps.HardMarginX), CInt(ps.HardMarginY))
            End If
        Next

    End Function

    ''' <summary>
    ''' Ruft den Namen des Controls des Adressfensters ab. Kann nötig sein, um eine Datenbnindung herzustellen
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GetAddressWindowName() As String
        Return PrintControlAdressWindow
    End Function

    ''' <summary>
    ''' Liest die klassischen Seiteneinstellungn ein
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadPageSettings()
        With m_application.Settings

            ' Alle Grössen und Maase sind in zehntel millimeter !
            ' Daten wurden in HWL (alt) in Twips gespeichert; 1mm = 567 Twips; Seitenbreite = 21/29
            ' Daher müssen alle Angaben zur Position und Grösse ruch TwipPermm geteilt werden; Report - Designer arbeitet nun auch in mm/10

            Dim boolVal As Boolean
            Dim fontSize As Integer
            'Enthält einen Versatz, in zentel mm (mm/10), der vom oberen Rand abweicht
            Const YOffset As Integer = 0

            ' Logo der Überschrift
            logo1.location = New Point(CInt(.GetIntegerSetting(PrnValPHLeft, KeyLayout, 0, "") / TwipPermm), CInt(.GetIntegerSetting(PrnValPHTop, KeyLayout, 0, "") / TwipPermm))
            logo1.enabled = GetBool(.GetSetting(prnValPHEnabled, KeyLayout, "", ""))
            logo1.Image = GetImage("OberesLogo")

            logo1.size = New Size(CInt(.GetIntegerSetting(PrnValPHWidth, KeyLayout, 250, "") / TwipPermm), CInt(.GetIntegerSetting(PrnValPHHeight, KeyLayout, 0, "") / TwipPermm))

            ' Unteres Logo
            logo2.location = New Point(CInt(.GetIntegerSetting(PrnValPH2Left, KeyLayout, 0, "") / TwipPermm), CInt(.GetIntegerSetting(PrnValPH2Top, KeyLayout, 250, "") / TwipPermm))
            logo2.enabled = GetBool(.GetSetting(prnValPH2Enabled, KeyLayout, "", ""))
            logo2.Image = GetImage("UnteresLogo")
            logo2.size = New Size(CInt(.GetIntegerSetting(PrnValPH2Width, KeyLayout, 250, "") / TwipPermm), CInt(.GetIntegerSetting(PrnValPH2Height, KeyLayout, 250, "") / TwipPermm))

            'Fensterzeile
            Fensterzeile.enable = True
            fontSize = .GetIntegerSetting(prnValFensterzeileGroesse, KeyLayout, 12, "")
            Fensterzeile.font = New Font(.GetSetting(prnValFensterzeileFont, KeyLayout, "0", ""), fontSize)

            Dim f As New FontFamily("Arial")


            boolVal = GetBool(.GetSetting(prnValFensterzeileFett, KeyLayout, "", ""))
            If boolVal Then Fensterzeile.font = New Font(Fensterzeile.font, Fensterzeile.font.Style Or FontStyle.Bold)

            boolVal = GetBool(.GetSetting(prnValFensterzeileKursiv, KeyLayout, "", ""))
            If boolVal Then Fensterzeile.font = New Font(Fensterzeile.font, Fensterzeile.font.Style Or FontStyle.Italic)

            boolVal = GetBool(.GetSetting(prnValFensterzeileUnterstrichen, KeyLayout, "", ""))
            If boolVal Then Fensterzeile.font = New Font(Fensterzeile.font, Fensterzeile.font.Style Or FontStyle.Underline)

            Fensterzeile.text = .GetSetting(prnValFensterzeileText, KeyLayout, "", "")
            Fensterzeile.size = New Size(1500, 42)

            Fensterzeile.alignment = CType(.GetSetting(prnValFensterzeileAlignment, KeyLayout, "0", ""), HorizontalAlignment)

            ' Achtung: über Offsets gehen !
            Fensterzeile.location = New Point(0, 170)

            'Adressfenster
            AdressField.enable = True
            fontSize = .GetIntegerSetting(prnValAdressfensterGroesse, KeyLayout, 12, "")
            AdressField.font = New Font(.GetSetting(prnValAdressfensterFont, KeyLayout), fontSize)

            boolVal = GetBool(.GetSetting(prnValAdressfensterFett, KeyLayout, "", ""))
            If boolVal Then AdressField.font = New Font(Fensterzeile.font, AdressField.font.Style Or FontStyle.Bold)

            boolVal = GetBool(.GetSetting(prnValAdressfensterKursiv, KeyLayout, "", ""))
            If boolVal Then AdressField.font = New Font(Fensterzeile.font, AdressField.font.Style Or FontStyle.Italic)

            boolVal = GetBool(.GetSetting(prnValAdressfensterUnterstrichen, KeyLayout, "", ""))
            If boolVal Then AdressField.font = New Font(Fensterzeile.font, AdressField.font.Style Or FontStyle.Underline)

            AdressField.text = .GetSetting(prnValAdressfensterText, KeyLayout, "", "")
            AdressField.size = New Size(520, 200) ' Maase hier in zehntel mm !!

            Dim AdressTopOffset As Integer = CInt(.GetIntegerSetting(prnValAdressfensterTopOffset, KeyLayout, 0, "") / TwipPermm)
            Dim AdressLeftOffset As Integer = CInt(.GetIntegerSetting(prnValAdressfensterLeftOffset, KeyLayout, 0, "") / TwipPermm)


            'TODO: Adressfeld-Offset benutzen
            AdressField.location = New Point(160 + AdressLeftOffset, 560 + AdressTopOffset)   ' Maase hier in zehntel mm !!


            Fensterzeile.location = AdressField.location
            Fensterzeile.location.Y -= Fensterzeile.size.Height  ' direkt darüber anordnen

            fontSize = .GetIntegerSetting(prnValBankGroesse, KeyLayout, 12, "")
            ' Bank
            bank.enable = GetBool(.GetSetting(prnValBankEnable, KeyLayout, "", ""))
            bank.font = New Font(.GetSetting(prnValBankFont, KeyLayout, "", ""), fontSize)

            boolVal = GetBool(.GetSetting(prnValBankFett, KeyLayout, "", ""))
            If boolVal Then bank.font = New Font(bank.font, bank.font.Style Or FontStyle.Bold)

            boolVal = GetBool(.GetSetting(prnValBankKursiv, KeyLayout, "", ""))
            If boolVal Then bank.font = New Font(bank.font, bank.font.Style Or FontStyle.Italic)

            boolVal = GetBool(.GetSetting(prnValBankUnterstrichen, KeyLayout, "", ""))
            If boolVal Then bank.font = New Font(bank.font, bank.font.Style Or FontStyle.Underline)

            bank.text = .GetSetting(prnValBankText, KeyLayout, "", "")
            bank.size = New Size(CInt(.GetIntegerSetting(prnValBankWidth, KeyLayout, 250, "") / TwipPermm), CInt(.GetIntegerSetting(prnValBankHeight, KeyLayout, 250, "") / TwipPermm))
            bank.location = New Point(CInt(.GetIntegerSetting(prnValBankLeft, KeyLayout, 250, "") / TwipPermm), CInt(.GetIntegerSetting(prnValBankTop, KeyLayout, 250, "") / TwipPermm))
            bank.alignment = CType(.GetSetting(prnValBankAlignment, KeyLayout, "0", ""), HorizontalAlignment)

            'slogan
            slogan.enable = GetBool(.GetSetting(prnValSloganEnable, KeyLayout, "", ""))

            fontSize = .GetIntegerSetting(prnValSloganGroesse, KeyLayout, 12, "")

            slogan.font = New Font(.GetSetting(prnValSloganFont, KeyLayout, "", ""), fontSize, FontStyle.Regular)

            boolVal = GetBool(.GetSetting(prnValSloganFett, KeyLayout, "", ""))
            If boolVal Then slogan.font = New Font(slogan.font, FontStyle.Bold)

            boolVal = GetBool(.GetSetting(prnValSloganKursiv, KeyLayout, "", ""))
            If boolVal Then slogan.font = New Font(slogan.font, FontStyle.Italic)

            boolVal = GetBool(.GetSetting(prnValSloganUnterstrichen, KeyLayout, "", ""))
            If boolVal Then slogan.font = New Font(slogan.font, FontStyle.Underline)

            slogan.text = .GetSetting(prnValSloganText, KeyLayout, "", "")
            slogan.size = New Size(CInt(.GetIntegerSetting(prnValSloganWidth, KeyLayout, 2000, "") / TwipPermm), CInt(.GetIntegerSetting(prnValSloganHeight, KeyLayout, 500, "") / TwipPermm))
            slogan.location = New Point(CInt(.GetIntegerSetting(prnValSloganLeft, KeyLayout, 0, "") / TwipPermm), CInt(.GetIntegerSetting(prnValSloganTop, KeyLayout, 0, "") / TwipPermm) + YOffset)
            slogan.alignment = CType(.GetSetting(prnValSloganAlignment, KeyLayout, "0", ""), HorizontalAlignment)


            'TopText1
            toptext1.enable = GetBool(.GetSetting(prnValTopText1Enable, KeyLayout))
            fontSize = .GetIntegerSetting(prnValTopText1Groesse, KeyLayout, 12, "")

            toptext1.font = New Font(.GetSetting(prnValTopText1Font, KeyLayout, "", ""), fontSize, FontStyle.Regular)

            boolVal = GetBool(.GetSetting(prnValTopText1Fett, KeyLayout, "", ""))
            If boolVal Then toptext1.font = New Font(toptext1.font, FontStyle.Bold)

            boolVal = GetBool(.GetSetting(prnValTopText1Kursiv, KeyLayout, "", ""))
            If boolVal Then toptext1.font = New Font(toptext1.font, FontStyle.Italic)

            boolVal = GetBool(.GetSetting(prnValTopText1Unterstrichen, KeyLayout, "", ""))
            If boolVal Then toptext1.font = New Font(toptext1.font, FontStyle.Underline)

            toptext1.text = .GetSetting(prnValTopText1Text, KeyLayout, "", "")
            toptext1.size = New Size(CInt(.GetIntegerSetting(prnValTopText1Width, KeyLayout, 2000, "") / TwipPermm), CInt(.GetIntegerSetting(prnValTopText1Height, KeyLayout, 500, "") / TwipPermm))
            toptext1.location = New Point(CInt(.GetIntegerSetting(prnValTopText1Left, KeyLayout, 0, "") / TwipPermm), CInt(.GetIntegerSetting(prnValTopText1Top, KeyLayout, 0, "") / TwipPermm) + YOffset)
            toptext1.alignment = CType(.GetSetting(prnValTopText1Alignment, KeyLayout, "0", ""), HorizontalAlignment)


            'Toptext2
            toptext2.enable = GetBool(.GetSetting(prnValTopText2Enable, KeyLayout))
            fontSize = .GetIntegerSetting(prnValTopText2Groesse, KeyLayout, 12, "")

            toptext2.font = New Font(.GetSetting(prnValTopText2Font, KeyLayout), fontSize, FontStyle.Regular)

            boolVal = GetBool(.GetSetting(prnValTopText2Fett, KeyLayout, "", ""))
            If boolVal Then toptext2.font = New Font(toptext2.font, FontStyle.Bold)

            boolVal = GetBool(.GetSetting(prnValTopText2Kursiv, KeyLayout, "", ""))
            If boolVal Then toptext2.font = New Font(toptext2.font, FontStyle.Italic)

            boolVal = GetBool(.GetSetting(prnValTopText2Unterstrichen, KeyLayout, "", ""))
            If boolVal Then toptext2.font = New Font(toptext2.font, FontStyle.Underline)

            toptext2.text = .GetSetting(prnValTopText2Text, KeyLayout, "", "")
            toptext2.size = New Size(CInt(.GetIntegerSetting(prnValTopText2Width, KeyLayout, 2000, "") / TwipPermm), CInt(.GetIntegerSetting(prnValTopText2Height, KeyLayout, 500, "") / TwipPermm))
            toptext2.location = New Point(CInt(.GetIntegerSetting(prnValTopText2Left, KeyLayout, 0, "") / TwipPermm), CInt(.GetIntegerSetting(prnValTopText2Top, KeyLayout, 0, "") / TwipPermm) + YOffset)
            toptext2.alignment = CType(.GetSetting(prnValTopText2Alignment, KeyLayout, "0", ""), HorizontalAlignment)

        End With
    End Sub

    ''' <summary>
    ''' Ruft ein Bild mit der angegebenen ID ab
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetImage(ByVal id As String) As Image
        Dim imagelist As Kernel.ImageData() = m_application.Images.GetReferencedImage(id)
        If imagelist.Length = 0 Then
            Return Nothing
        Else
            Return imagelist(0).Image
        End If
    End Function

    Private Sub SetSimplePageSettings(ByVal rep As XtraReport)
        Dim pageheader As PageHeaderBand

        ' Kein Header gefunden? => Dann einen einbinden
        If rep.Bands.GetBandByType(GetType(PageHeaderBand)) Is Nothing Then
            pageheader = New PageHeaderBand
            rep.Bands.Add(pageheader)

        End If
        pageheader = CType(rep.Bands.GetBandByType(GetType(PageHeaderBand)), PageHeaderBand)

        If Not Me.JustAdresswindow Then
            ' Logo1
            SetImage(pageheader, logo1, "picHeader")
            SetText(pageheader, toptext1, "lblHeaderText1")
            SetText(pageheader, toptext2, "lblHeaderText2")
            'Das Label für Adresse existiert bereits
            SetText(pageheader, AdressField, PrintControlAdressWindow)
            SetText(pageheader, Fensterzeile, PrintControlAdressLine)

        Else ' Nur Adresszeile erstellen
            SetText(pageheader, AdressField, PrintControlAdressWindow)
            SetText(pageheader, Fensterzeile, PrintControlAdressLine)
        End If


        'Seitenfuss
        Dim pagefooter As PageFooterBand

        ' Kein Fuss gefunden? => Dann einen einbinden
        If rep.Bands.GetBandByType(GetType(PageFooterBand)) Is Nothing Then
            pagefooter = New PageFooterBand
            rep.Bands.Add(pagefooter)

        End If
        pagefooter = CType(rep.Bands.GetBandByType(GetType(PageFooterBand)), PageFooterBand)
        If Not Me.JustAdresswindow Then
            SetText(pagefooter, bank, "lblFooterText1")
            SetText(pagefooter, slogan, "lblFooterText2")
            SetImage(pagefooter, logo2, "picFooter")
        End If


    End Sub

    ''' <summary>
    ''' Setzt in einem gegebenen Report-Band ein Image (old Style)
    ''' </summary>
    ''' <param name="band"></param>
    ''' <param name="imageData"></param>
    ''' <remarks></remarks>
    Private Sub SetImage(ByVal band As Band, ByVal imageData As structLogoBoxSettings, ByVal name As String)

        If imageData.enabled Then
            If imageData.Image IsNot Nothing Then

                Dim mylogo As New XRPictureBox
                band.Controls.Add(mylogo)

                mylogo.Size = imageData.size
                mylogo.Image = imageData.Image
                mylogo.Location = imageData.location
                mylogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                mylogo.Name = name
            End If
        End If
    End Sub

    ''' <summary>
    ''' Setzt in einen Report-Band eine Textbox (old Style)
    ''' </summary>
    ''' <param name="band"></param>
    ''' <param name="textData"></param>
    ''' <remarks></remarks>
    Private Sub SetText(ByVal band As Band, ByVal textData As structTextBoxSettings, ByVal name As String)
        If textData.enable Then
            Dim myText As New XRLabel
            myText.Name = name
            band.Controls.Add(myText)
            With textData
                myText.Text = .text
                myText.ForeColor = Color.Black
                myText.Location = .location
                myText.Size = .size
                myText.Multiline = True
                myText.Font = .font
                Select Case .alignment
                    Case HorizontalAlignment.Left : myText.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
                    Case HorizontalAlignment.Center : myText.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    Case HorizontalAlignment.Right : myText.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
                    Case Else
                        myText.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft

                End Select
                'TODO: Alignement
            End With
        End If
    End Sub

    Private Sub SetText(ByVal band As Band, ByVal textData As structTextBoxSettings)
        SetText(band, textData, "")
    End Sub

    ''' <summary>
    ''' Holt aus einem String ("Wahr/Falsch; True /False", oder einem Int (1/-1 ;0) ein boolschen Wert ab, 
    ''' Gibt im Zweifel "false" zurück
    ''' </summary>
    ''' <param name="o"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetBool(ByVal o As Object) As Boolean
        If TypeOf o Is String Then
            Dim str As String = CType(o, String)
            If str.Equals("true", StringComparison.InvariantCultureIgnoreCase) Or str.Equals("wahr", StringComparison.InvariantCultureIgnoreCase) Then
                Return True
            End If
            If str.Equals("false", StringComparison.InvariantCultureIgnoreCase) Or str.Equals("falsch", StringComparison.InvariantCultureIgnoreCase) Then
                Return False
            End If

            Dim value As Integer
            If Integer.TryParse(str, value) Then
                If value = 0 Then
                    Return False
                End If

                Return True

            End If

            Return False
        End If


        If TypeOf o Is Integer Then
            Dim value As Integer = CType(o, Integer)
            If value = 0 Then
                Return False
            End If

            Return True

        End If

        Return False

    End Function

    Public Sub New()

    End Sub
End Class
