
''' <summary>
''' Stellt die Startklasse da für die neue HWL Applikation
''' </summary>
''' <remarks></remarks>
Public Class MainClass

    Private Shared m_main As MainClass
    ' ''' <summary>
    ' ''' Stellt die Hauptklasse dar
    ' ''' </summary>
    ' ''' <remarks></remarks>
    Private m_engine As Main

    Private Delegate Sub ShowSplashScreenDele()

    ''' <summary>
    ''' Zeitmesser der das Startverhalten protokolliert
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared m_AppStartWatch As New Stopwatch

    ''' <summary>
    ''' Stellt ein Instanz des Startbildschirms dar
    ''' </summary>
    ''' <remarks></remarks>
    Private m_splashScreen As New frmSplashScreen

    Private Delegate Sub HideSplashScreenDele()

    ''' <summary>
    ''' Startet die Zeitmessung zum Start der Applikation
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub StartAppstartupTimer()
        m_AppStartWatch.Start()
    End Sub

    ''' <summary>
    ''' Ruft einen Text mit dem angegebenen schlüssel ab. Konnte der Text nicht gefunden werden, wird der Standardwert übergeben
    ''' </summary>
    ''' <param name="key">Schlüssel des Textes</param>
    Public Shared Function GetText(ByVal key As String) As String
        Return MainApplication.getInstance.Languages.GetText(key)
    End Function

    ''' <summary>
    ''' Ruft einen Text mit dem angegebenen Schlüssel ab. Konnte der Text nicht gefunden werden, wird der Standardwert übergeben
    ''' </summary>
    ''' <param name="key">Schlüssel des Textes</param>
    ''' <param name="defaultText">Wird verwendet, wenn in der Texte-Datenbank der Text nicht gefunden werden konnte</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetText(ByVal key As String, ByVal defaultText As String) As String
        Return MainApplication.getInstance.Languages.GetText(key, defaultText)
    End Function

    ''' <summary>
    ''' Die Startinstanz. Hier fängt alles an!
    ''' </summary>
    ''' <remarks></remarks>
    Shared Sub Main()

        Application.EnableVisualStyles()

        ShowHelpOnCommandLineDemand()
        StartAppstartupTimer()
        InitMainClass()
        StartApplication()
        m_main.ApplicationEnd()
    End Sub

    Private Shared Sub InitMainClass()
        m_main = New MainClass
    End Sub

    Private Shared Sub StartApplication()
        If m_main.Initialize() Then
            m_main.m_engine.MainApplication.SendMessage("Starte Hauptbildschirm...")
            m_main.StartWindow()
        End If
    End Sub

    Private Shared Sub ShowHelpOnCommandLineDemand()
        If Environment.CommandLine.Contains("/?") Or Environment.CommandLine.Contains("help") Or Environment.CommandLine.Contains("/h") Then
            MessageBox.Show(CommandLineManager.GetAllAttributes(), Application.ProductName, MessageBoxButtons.OK)
            End
        End If
    End Sub

    ''' <summary>
    ''' Zeigt den SplashScreen an 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowSplashScreen()
        If m_splashScreen Is Nothing Then
            m_splashScreen = New frmSplashScreen
        End If

        If m_splashScreen.InvokeRequired Then
            m_splashScreen.Invoke(New ShowSplashScreenDele(AddressOf ShowSplashScreen))
        Else
            m_splashScreen.Show()
            m_splashScreen.Refresh()
        End If
    End Sub

    ''' <summary>
    ''' Verbirgt den Splashscreen
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub HideSplashScreen()
        If m_splashScreen.InvokeRequired Then
            m_splashScreen.Invoke(New HideSplashScreenDele(AddressOf HideSplashScreen))
        Else
            m_splashScreen.Close()
            m_splashScreen = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Zeigt an, das dieser HWL - Start zum ersten mal stattfindet
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property IsFirstStart As Boolean

    ''' <summary>
    ''' Startet die Applikation, legt Datenbankverbindungen fest
    ''' </summary>
    ''' <returns>True if successful start, false if startup was not successful</returns>
    ''' <remarks></remarks>
    Friend Function Initialize() As Boolean
        'Aktuell: Datenbankverbindung wird vorausgesetzt

        ' Styles einschalten
        DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = False
        DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = True

        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "LILIAN" ' <<< NEW LINE
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetWindowsXPStyle()

        Application.EnableVisualStyles()

        m_engine = New Main

        InitLanguage()
        Dim DatabaseCreated As Boolean = False ' wird durch wizzard auf "True" gesetzt, wenn die Datenbank neu ist 
        Dim TaxesToCreate As Kernel.CountryInitialTaxRate = Nothing

        Dim sendStatisticalData As Boolean = True

        IsFirstStart = MainApplication.getInstance.Connections.FirstStart

        If IsFirstStart Then
            ' Kann entweder ein 1.7 Update sein, 
            '  oder Daten nicht vorhanden
            MainApplication.getInstance.Connections.FillConnectionsList()

            If Not MainApplication.getInstance.Connections.DefaultConnection Is Nothing Then
                Dim msgText As String = "Eine {AppName}-1.7 Datenbank wird  in das neuere {AppName}-2 Format übertragen. Danach ist es nicht mehr möglich, die bisherige Version zu starten. " & vbCrLf &
                                   "Möchten sie nun  automatisch die Konvertierung durchführen lassen und {Appname} V2.0 nutzen?"

                msgText = GetText("msgDataMigrationOldVersionwarning", msgText)

                Dim msgMigrationTitle As String = "Datenübernahme"
                msgMigrationTitle = GetText("msgMigrationTitle", msgMigrationTitle)

                If MessageBox.Show(msgText, msgMigrationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then

                    MainApplication.getInstance.Connections.DefaultConnection = Nothing
                End If
            End If

            ' Wurde eine 1.x Verbindung gefunden; diese zum Standard machen !
            If MainApplication.getInstance.Connections.DefaultConnection Is Nothing Then
                HideSplashScreen() ' Splash verstecken; der wizzard soll in den Vordergrund

                MainApplication.getInstance.SendMessage(MainApplication.getInstance.Languages.GetText("Erster Start von {appname}"))
                Dim frm As New frmInstallWizzard
                Dim result As DialogResult = frm.ShowDialog()

                '>Steuersätze aus dem wizzard abholen 

                If result = DialogResult.OK Then
                    ShowSplashScreen()

                    Dim DataType As DataBaseTypeenum
                    DataType = frm.DataBaseType

                    ' Bei neu angelegten Datenbanken den steuersatz vom Anwender nutzen
                    If DataType = DataBaseTypeenum.CloudBased Or DataType = DataBaseTypeenum.internalNew Then  ' In diesen Modi wurde eine Datenbank angelegt
                        DatabaseCreated = True
                        TaxesToCreate = frm.CurrentTaxValues
                    End If

                    If DataType = DataBaseTypeenum.internalNew Then
                        ' Jetzt neue DB anlegen
                        ' Bestehende Datenbanken werden im wizzard angezogen
                        CreateDefaultDatabase()

                    End If

                Else
                    ' Einrichtung / Start abrechen
                    Return False
                End If
            Else

                ' Beim ersten Start wurde eine HWL 1.7 Verbindung erkannt - diese auch speichern !
                MainApplication.getInstance.Connections.SaveConnections()
            End If
        End If
        ShowSplashScreen()

        m_engine.MainApplication.Connections.ReadConnections()

        ' Prüft auf existenz der angegeben Datenbank
        If Not CheckDBUserConnection() Then End

        ' Hier die Datenbank - Verbindeung herstellen, initialisieren und Schema-Update machen
        Dim RetValue As Boolean
        RetValue = m_engine.MainApplication.Initialize(m_engine.MainApplication.Connections.WorkConnection) ' Führt eine Initailisierung durch

        If Not RetValue Then
            MessageBox.Show(m_engine.MainApplication.LastSchemaUpdateError, MainApplication.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        CheckMaxSupportedOsVersion()

        MainApplication.getInstance.Settings.SettingSendStatistics = sendStatisticalData

        ' sofern der Wizzard durchlaufen wurde, den Steuerssatz auch anlegen 
        If DatabaseCreated AndAlso TaxesToCreate IsNot Nothing Then
            SetTaxRates(TaxesToCreate)
        Else
            ' Steuersätze kontrollieren, und gegebenfalls Reaparieren lassen 
            MainApplication.getInstance.TaxRates.Criteria = Nothing
            MainApplication.getInstance.TaxRates.Reload()

            If Kernel.TaxRates.IsInvalid Then
                CheckTaxRates()
            End If

        End If

        If IsFirstStart Then
            SetDefaultValues()
        End If

        CheckBuildInReports()

        HideSplashScreen()

        Return True

    End Function

    ''' <summary>
    ''' Wenn nicht durch eine Neuinstallation die Steuersätze im Setup defeiniert wurden, dann diese prüfen und anlegen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckTaxRates()

        FillTaxRates()
        ' Immer noch ungültig ? 


        'TODO: NLS
        MessageBox.Show("Der bisherige Steuersatz muss von Ihnen angepasst werden. " & vbCrLf &
                        "Bitte weisen Sie den Steuersätzten die Eigenschaft 'Normal','Ermässigt' usw zu." & vbCrLf &
                        "Das ist leider nötig, da dies nicht automatich erkannt werden konnte.", "Steuersatzarten neu zuweisen", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Do While Kernel.TaxRates.IsInvalid

            ' Dialog anzeigen lassen 
            Dim frm As New frmRepairTaxes
            If frm.ShowDialog() = vbOK Then

                MainApplication.getInstance.TaxRates.Save()
                MainApplication.getInstance.TaxRates.Initialize()
            Else
                'Abbrechen? 
                'TODO: Dann kann im Materialstamm keine Stamdardsteuer abgerufen werden!
                'TODO: NLS

            End If

            If Kernel.TaxRates.IsInvalid Then
                'TODO: NLS
                MessageBox.Show("Wenn Sie fortfahren, kann es zu Problemen bei der uweisung von Steuern kommen.", "{appname}", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Do
            End If
        Loop
    End Sub

    ''' <summary>
    ''' Füllt die Steuersätz auf, sofern nach dem start immer noch defekt
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillTaxRates()
        Dim m_currentTaxeValues As Kernel.CountryInitialTaxRate
        Dim taxes As New Kernel.CountryInitialTaxRates()
        m_currentTaxeValues = taxes.GetLocalTaxRate

        Debug.Print("Repariere Steuersätze für: " & My.Application.Culture.NativeName)

        If m_currentTaxeValues IsNot Nothing Then
            ' -1 heisst nicht vergeben

            Dim itemTax As Kernel.TaxRate = MainApplication.getInstance.TaxRates.GetNewItem

            itemTax.Name = GetText("NoTax", "Ohne")
            itemTax.TaxStatus = Kernel.enumTaxKind.NullTax
            itemTax.TaxValue = 0
            MainApplication.getInstance.TaxRates.Add(itemTax)

            itemTax = MainApplication.getInstance.TaxRates.GetNewItem
            itemTax.Name = GetText("ReducedTax", "Ermässigt")
            itemTax.TaxStatus = Kernel.enumTaxKind.ReducedTax
            itemTax.TaxValue = m_currentTaxeValues.ReducedTaxRate
            MainApplication.getInstance.TaxRates.Add(itemTax)

            itemTax = MainApplication.getInstance.TaxRates.GetNewItem
            itemTax.Name = GetText("NormalTax", "Normal")
            itemTax.TaxStatus = Kernel.enumTaxKind.NormalTax
            itemTax.TaxValue = m_currentTaxeValues.NormalTaxRate
            MainApplication.getInstance.TaxRates.Add(itemTax)


            If m_currentTaxeValues.ExtraTaxrate <> -1 Then
                itemTax = MainApplication.getInstance.TaxRates.GetNewItem
                itemTax.Name = GetText("ExtraTax", "Extra")
                itemTax.TaxStatus = Kernel.enumTaxKind.ExtraTax
                itemTax.TaxValue = m_currentTaxeValues.ExtraTaxrate
                MainApplication.getInstance.TaxRates.Add(itemTax)
            End If


            If m_currentTaxeValues.ReducedTaxRate2 <> -1 Then
                itemTax = MainApplication.getInstance.TaxRates.GetNewItem
                itemTax.Name = GetText("ExtraTax2", "Ermässigt-2")
                itemTax.TaxStatus = Kernel.enumTaxKind.ReducedTax2
                itemTax.TaxValue = m_currentTaxeValues.ReducedTaxRate2
                MainApplication.getInstance.TaxRates.Add(itemTax)
            End If

            MainApplication.getInstance.TaxRates.Save()

        End If
    End Sub


    ''' <summary>
    ''' Richtet die Sprache ein
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitLanguage()
        Dim lang As String

        Do
            Dim errormessage As String
            Try
                lang = MainApplication.getInstance.Languages.GetActiveLanguage
            Catch ex As Exception
                lang = ""
                ' Kann nur passieren, wenn per Kommandozeile eine ungültige Sprche angegeben wurde
                errormessage = ex.Message
            End Try
            If lang.Length = 0 Then
                ' Nun Sprache aussuchen lassen; 

                Dim InvalidLanguage, headInvalidLanguage As String

                If Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName = "de" Then
                    InvalidLanguage = "Sie haben per Kommandozeile eine unbekannte Sprache angegeben. Bitte berichtigen sie die Kommandozeile." & vbCrLf &
                        "Benutzen Sie diese Form: ""/lang:de"" or ""/lang:de-de""" & vbCrLf & vbCrLf &
                    "Möchten Sie mit Deutsch fortfahren oder abbrechen?"
                    headInvalidLanguage = "Unbekannte Sprache angegeben"
                Else
                    InvalidLanguage = "You have set an unknown language. Please correct this. " & vbCrLf &
                        "Use this form: ""/lang:de"" or ""/lang:de-de""" & vbCrLf & vbCrLf &
                        "Would you like to continue with english language setting or cancel?"
                    headInvalidLanguage = "Invalid Language"
                End If

                Dim res As DialogResult
                res = MessageBox.Show(InvalidLanguage, headInvalidLanguage, MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

                If res = DialogResult.Cancel Then
                    Me.ApplicationEnd()
                    End
                End If

            End If

        Loop Until lang.Length > 0

        MainApplication.getInstance.Languages.Initialize()


        MainApplication.getInstance.Languages.GetActiveLanguage()

    End Sub

    ''' <summary>
    ''' Legt aus der mitgelieferten Template-Datenbank einen Standard an
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateDefaultDatabase()

        MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.Information, "CreateDefaultDatabase: Erstellte standard Datenbank")

        Dim defaultConnection As Tools.Connection = Tools.Connections.GetSimpelDefaultDatabase()
        IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(defaultConnection.Path))
        IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(defaultConnection.BackupPath))

        Dim templatePath As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "TemplateDataBase\Template.mdb")
        If Not IO.File.Exists(defaultConnection.Path & "\daten.mdb") Then
            ' Falls das Zielverzeichnis noh nicht existiert, dann anlegen
            If Not IO.Directory.Exists(defaultConnection.Path) Then IO.Directory.CreateDirectory(defaultConnection.Path)
            IO.File.Copy(templatePath, defaultConnection.Path & "\daten.mdb", False)
        Else
            Debug.Print("Datendatei existiert schon am Zielort: " & defaultConnection.Path)
        End If

        If Not m_engine.MainApplication.Connections.Contains(defaultConnection) Then
            m_engine.MainApplication.Connections.Add(defaultConnection)
            m_engine.MainApplication.Connections.SaveConnections()
            m_engine.MainApplication.Connections.DefaultConnection = defaultConnection

            ' nun auch die Datenbank anlegen

        End If
    End Sub

    ''' <summary>
    ''' Schreibt die gewählten Steuersätze in die lokale Datenbank
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTaxRates(ByVal currentTaxeValues As Kernel.CountryInitialTaxRate)
        If MainApplication.getInstance.TaxRates.Count = 0 Then
            Dim tax As Kernel.TaxRate

            ' Normal und Ermässigt gibt es immer
            tax = MainApplication.getInstance.TaxRates.GetNewItem
            tax.TaxStatus = Kernel.enumTaxKind.NormalTax
            tax.TaxValue = currentTaxeValues.NormalTaxRate
            tax.Name = GetText(Kernel.enumTaxKind.NormalTax.ToString, "Normal")
            tax.Save()

            If currentTaxeValues.ReducedTaxRate >= 0 Then
                ' Ermässigt
                tax = MainApplication.getInstance.TaxRates.GetNewItem
                tax.TaxStatus = Kernel.enumTaxKind.ReducedTax
                tax.TaxValue = currentTaxeValues.ReducedTaxRate
                tax.Name = GetText(Kernel.enumTaxKind.ReducedTax.ToString, "Ermässigt")

                tax.Save()
            End If

            If currentTaxeValues.ReducedTaxRate2 >= 0 Then
                ' Zwischensatz  1
                tax = MainApplication.getInstance.TaxRates.GetNewItem
                tax.TaxStatus = Kernel.enumTaxKind.ReducedTax2
                tax.TaxValue = currentTaxeValues.ReducedTaxRate2
                tax.Name = GetText(Kernel.enumTaxKind.ReducedTax2.ToString, "Zwischensatz")
                tax.Save()
            End If

            If currentTaxeValues.ExtraTaxrate >= 0 Then

                ' Extra
                tax = MainApplication.getInstance.TaxRates.GetNewItem
                tax.TaxStatus = Kernel.enumTaxKind.ExtraTax
                tax.TaxValue = currentTaxeValues.ExtraTaxrate
                tax.Name = GetText(Kernel.enumTaxKind.ExtraTax.ToString, "Extra")

                tax.Save()
            End If

            ' Nullstaeuersatz
            tax = MainApplication.getInstance.TaxRates.GetNewItem
            tax.TaxStatus = Kernel.enumTaxKind.NullTax
            tax.TaxValue = 0
            tax.Name = GetText(Kernel.enumTaxKind.NullTax.ToString, "Ohne Steuern")

            tax.Save()

            MainApplication.getInstance.TaxRates.Reload()
        End If
    End Sub

    ''' <summary>
    ''' Prüft, ob die Datenbank-Verbindung gültig ist und benutzt werden kann
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDBUserConnection() As Boolean

        Dim res As DataBase.DBResult = Me.TestDatabaseConnection()
        If Not res.IsValid Then
            MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.Critical, "CheckuserConnection detects an invalid Database connection. ErrorText: " & res.ErrorText)
        End If

        ' Solange keine Standard-Verbindung existiert und diese nicht geöffnet werden kann, dann Abbruch !
        Do While Not res.IsValid
            Dim result As DialogResult
            Dim frm As New frmConnectionConfiguration
            result = frm.ShowDialog()

            If result = DialogResult.Cancel Then Return False

            res = Me.TestDatabaseConnection
        Loop
        Return True

    End Function


    ''' <summary>
    ''' Prüft, ob die aktuelle Datenverbindung existiert.  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TestDatabaseConnection() As DataBase.DBResult
        '  Dim myApp As New ClausSoftware.mainApplication
        MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.Verbose, "Startet Testen der Datenbankverbindung")
        'myApp.Connections.ReadConnections()
        MainApplication.getInstance.Connections.ReadConnections()
        Dim mydefaultConnection As Tools.Connection = MainApplication.getInstance.Connections.WorkConnection

        Dim result As New DataBase.DBResult()

        If mydefaultConnection Is Nothing Then
            MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.Verbose, "Keine Standardverbindung gefunden, erstellte neue Standardverbindung")
            CreateDefaultDatabase()
        End If

        If mydefaultConnection IsNot Nothing Then
            'Falls lokale Installation, UND die Datenbankdatei konnt enicht gefunden werden, lege diese an (kopiere aus Template)
            If mydefaultConnection.Servertype = Tools.enumServerType.Access Then
                If Not IO.File.Exists(mydefaultConnection.Path & "\daten.mdb") Then
                    CreateDefaultDatabase()
                End If
            End If


            Dim myTestDB As DataBase.DbEngine

            myTestDB = New DataBase.DbEngine(mydefaultConnection)
            MainApplication.getInstance.SendMessage("Stelle Verbindung mit " & mydefaultConnection.GetConnectionShortDescription & " her...") ' TODO: NLS
            result = myTestDB.TestConnection()
            myTestDB.Dispose()

        Else

            MainApplication.getInstance.log.WriteLog(Tools.LogSeverity.ErrorMessage, "Keine Standardverbindung angelegt. 'CreateDefaultDatabase' hat keine Verbindung erstellt!")


            ' Verbindung konnte gar nicht gefunden werden
            'TODO: NLS; Hier angeben, das überhaupt keine Verbindung konfiguriert wurde (Connection stzring war nothing) 
            result.ErrorText = "Es wurde keine Verbindung gefunden" 'TODo: NLS
            result.IsValid = False
            result.Solution = "Erstellen Sie eine neue Verbindung zu einer Datenbank"
        End If

        Return result
    End Function

    ''' <summary>
    ''' Startet das Hauptfenster und beginnt dessen MessageLoop
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub StartWindow()
        Dim MainWindow As New frmMain With {
            .IsFirstStart = Me.IsFirstStart
        }

        Application.Run(MainWindow)

    End Sub


    ''' <summary>
    ''' Beendet die Applikation
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ApplicationEnd()
        Try
            MainApplication.getInstance.Languages.SaveLanguageFile()
            MainApplication.getInstance.CloseConnection()

            AskFinalyBackup()

            m_engine.EndApplcation()

        Catch

        End Try
        End
    End Sub

    ''' <summary>
    ''' Erstellt abschliessend eine Sicherungskopie der Datenbank
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AskFinalyBackup()
        If MainApplication.getInstance.Database.DatabaseType = Tools.enumServerType.Access Then
            'TODO: NLS

            MainApplication.getInstance.SendMessage(GetText("msgCreatingDatabaseBackup", "Eine Sicherungskopie der Datenbank wird angelegt..."))

            'If MessageBox.Show("Möchten Sie eine Sicherungskopie anlegen?", "Datensicherung", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            MainApplication.getInstance.Database.StartBackup()
            'End If
        End If

    End Sub

    Public Sub New()

    End Sub

    Private Sub CheckBuildInReports()
        ' Beim start alle Reports testen ? 
        Printing.PrintingManager.CheckAndRepairDefaultLaoyuts()
    End Sub

    ''' <summary>
    ''' Setzt einige Standardwerte die beim allerersten Start nötig währen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDefaultValues()
        MainApplication.getInstance.Settings.Articlesettings.DefaultTaxRate = MainApplication.getInstance.TaxRates.GetNormalTax

    End Sub

    ''' <summary>
    ''' Läuft nur bis Windows 6.2
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckMaxSupportedOsVersion()
        Debug.Print("OSPlatform: " & My.Computer.Info.OSPlatform)
        Debug.Print("OSVersion: " & My.Computer.Info.OSVersion)

        'Maximal 6.1.xxxx  (Windows 7) 

        Dim osVersion As New Version(My.Computer.Info.OSVersion)
        If osVersion.Major > 6 Then
            Throw New ApplicationException("Invalid OS System")
            Application.Exit()
            End
        End If


        If osVersion.Minor > 3 Then
            Throw New ApplicationException("Invalid OS System")
            Application.Exit()
            End
        End If

    End Sub

End Class
