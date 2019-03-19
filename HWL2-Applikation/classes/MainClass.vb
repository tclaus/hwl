Imports ClausSoftware.HWLInterops
Imports Microsoft.Win32

''' <summary>
''' Stellt die Startklasse da für die neue HWL / PB Applikation
''' </summary>
''' <remarks></remarks>
Public Class MainClass
    Private Shared m_main As MainClass
    ' ''' <summary>
    ' ''' Stellt die Hauptklasse dar
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Shared m_application As ClausSoftware.mainApplication
    Private m_engine As HWLInterops.Main

    Friend m_errorReporting As ClausSoftware.ErrorReporting.MainErrorHandler

    Private Delegate Sub ShowSplashScreenDele()


    ''' <summary>
    ''' Zeitmesser der das Startverhalten protokolliert
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared m_AppStartWatch As New Stopwatch

    ''' <summary>
    ''' Stoppt den Starttimer nach Aufbau der Hauptapplikation und sendet den Bericht
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub SendApplicationStartuptime()

        m_application.UserStats.SendStatistics(ClausSoftware.Tools.ReportMessageType.ApplicationStartUpTime, "Application", m_AppStartWatch.Elapsed.ToString)

    End Sub

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
        Return m_application.Languages.GetText(key)
    End Function

    ''' <summary>
    ''' Ruft einen Text mit dem angegebenen Schlüssel ab. Konnte der Text nicht gefunden werden, wird der Standardwert übergeben
    ''' </summary>
    ''' <param name="key">Schlüssel des Textes</param>
    ''' <param name="defaultText">Wird verwendet, wenn in der Texte-Datenbank der Text nicht gefunden werden konnte</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetText(ByVal key As String, ByVal defaultText As String) As String
        Return m_application.Languages.GetText(key, defaultText)
    End Function

    ''' <summary>
    ''' Die Startinstanz. Hier fängt alles an!
    ''' </summary>
    ''' <remarks></remarks>
    Shared Sub Main()

        System.Windows.Forms.Application.EnableVisualStyles()

        ' Falls Hilfe gewünscht, Text ausgeben
        If Environment.CommandLine.Contains("/?") Or Environment.CommandLine.Contains("help") Or Environment.CommandLine.Contains("/h") Then
            MessageBox.Show(CommandLineManager.GetAllAttributes(), System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK)
            End
        End If

        StartAppstartupTimer()

        m_main = New MainClass

        m_main.StartErrorReporting()

        If m_main.Initialize() Then ' ' Starte applikation, wenn "False" zurückgegeben wurde, dann war ein Start nicht möglich
            ' Die Gründe wurden bereits behandelt
            m_main.m_engine.MainApplication.SendMessage("Starte Hauptbildschirm...") 'TODO: NLS

            m_main.StartWindow() ' Starting Main Window


            ' Application ends here
        End If
        m_main.ApplicationEnd()
    End Sub


    ''' <summary>
    ''' Stellt ein Instanz des Startbildschirms dar
    ''' </summary>
    ''' <remarks></remarks>
    Private m_splashScreen As New SplashScreen

    Private Delegate Sub HideSplashScreenDele()



    
    ''' <summary>
    ''' Zeigt den SplashScreen an 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowSplashScreen()
        If m_splashScreen Is Nothing Then
            m_splashScreen = New SplashScreen
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
            m_splashScreen.Dispose()
            m_splashScreen = Nothing  ' .. und Tschüss!
        End If
    End Sub


    Private m_isFirstStart As Boolean

    ''' <summary>
    ''' Zeu´gt an, das dieser HWL - Start zum ersten mal stattfindet
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsFirstStart As Boolean
        Get
            Return m_isFirstStart
        End Get
        Set(value As Boolean)
            m_isFirstStart = value
        End Set
    End Property

    ''' <summary>
    ''' Startet die Applikation, legt Datenbankverbindungen fest
    ''' </summary>
    ''' <remarks></remarks>
    Friend Function Initialize() As Boolean
        'Aktuell: Datenbankverbindung wird vorausgesetzt


        ' Styles einschalten
        DevExpress.LookAndFeel.UserLookAndFeel.Default.UseDefaultLookAndFeel = False
        DevExpress.LookAndFeel.UserLookAndFeel.Default.UseWindowsXPTheme = True

        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "LILIAN" ' <<< NEW LINE
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SetWindowsXPStyle()


        System.Windows.Forms.Application.EnableVisualStyles()


        m_engine = New HWLInterops.Main
        m_engine.Initialize()
        m_errorReporting.Application = m_application ' Applikationsobjekt dem Error message zuweisen


        m_splashScreen.MainApplication = m_application

        m_application.UserStats.SendStatistics(ClausSoftware.Tools.ReportMessageType.ApplicationStart, "Application", "New Application Startup")
        m_application.UserStats.SendStatistics(ClausSoftware.Tools.ReportMessageType.ApplicationStart, "OS Version", My.Computer.Info.OSFullName & "(" & My.Computer.Info.OSVersion & ")")

        InitLanguage()
        Dim DatabaseCreated As Boolean = False ' wird durch wizzard auf "True" gesetzt, wenn die Datenbank neu ist 
        Dim TaxesToCreate As ClausSoftware.Kernel.CountryInitialTaxRate = Nothing

        Dim sendStatisticalData As Boolean = True

        IsFirstStart = m_application.Connections.FirstStart

        If IsFirstStart Then
            ' Kann entweder ein 1.7 Update sein, 
            '  oder Daten nicht vorhanden
            m_application.Connections.FillConnectionsList()

            If Not m_application.Connections.DefaultConnection Is Nothing Then
                Dim msgText As String = "Eine {AppName}-1.7 Datenbank wird  in das neuere {AppName}-2 Format übertragen. Danach ist es nicht mehr möglich, die bisherige Version zu starten. " & vbCrLf & _
                                   "Möchten sie nun  automatisch die Konvertierung durchführen lassen und {Appname} V2.0 nutzen?"

                msgText = GetText("msgDataMigrationOldVersionwarning", msgText)

                Dim msgMigrationTitle As String = "Datenübernahme"
                msgMigrationTitle = GetText("msgMigrationTitle", msgMigrationTitle)

                If MessageBox.Show(msgText, msgMigrationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then

                    m_application.Connections.DefaultConnection = Nothing
                End If
            End If



            ' Wurde eine 1.x Verbindung gefunden; diese zum Standard machen !
            If m_application.Connections.DefaultConnection Is Nothing Then
                HideSplashScreen() ' Splash verstecken; der wizzard soll in den Vordergrund

                m_application.UserStats.SendStatistics(ClausSoftware.Tools.ReportMessageType.ModulStart, "Setupwizzard", "Starting Setup Wizzard (first Install)")
                m_application.SendMessage(m_application.Languages.GetText("Erster Start von {appname}"))
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
                    sendStatisticalData = frm.chkSendCustomerData.Checked
                Else
                    ' Einrichtung / Start abrechen
                    Return False
                End If
            Else

                ' Beim ersten Start wurde eine HWL 1.7 Verbindung erkannt - diese auch speichern !
                m_application.Connections.SaveConnections()
            End If
        Else

        End If




        ShowSplashScreen()

        m_engine.MainApplication.Connections.ReadConnections()

        ' Prüft auf existenz der angegeben Datenbank
        If Not CheckDBUserConnection() Then End

        ' Hier die Datenbank - Verbindeung herstellen, initialisieren und Schema-Update machen
        Dim RetValue As Boolean
        RetValue = m_engine.MainApplication.Initialize(m_engine.MainApplication.Connections.WorkConnection) ' Führt eine Initailisierung durch

        If Not RetValue Then
            MessageBox.Show(m_engine.MainApplication.LastSchemaUpdateError, mainApplication.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If


        CheckCompetetors()

        CheckMaxSupportedOsVersion()

        m_application.Settings.SettingSendStatistics = sendStatisticalData

        ' sofern der Wizzard durchlaufen wurde, den Steuerssatz auch anlegen 
        If DatabaseCreated AndAlso TaxesToCreate IsNot Nothing Then
            SetTaxRates(TaxesToCreate)
        Else
            ' Steuersätze kontrollieren, und gegebenfalls Reaparieren lassen 
            m_application.TaxRates.Criteria = Nothing
            m_application.TaxRates.Reload()

            If ClausSoftware.Kernel.TaxRates.IsInvalid Then
                CheckTaxRates()
            End If

        End If

        If IsFirstStart Then
            SetDefaultValues()
        End If

        'auf Lizenz prüfen; gegebenfalls hier das Programm beenden
        CheckLicenses()
        CheckBuildInReports()
        ' Benutzerlogin anzeigen lassen, wenn Benutzer angemeldet sind und eine entsprechende Lizenz existiert
        CheckUserLogin()


        HideSplashScreen()

        Return True

    End Function

    ''' <summary>
    ''' Wenn nicht durch eine Neuinstallation die Steuersätze im Setup defeiniert wurden, dann diese prüfen und anlegen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckTaxRates()
        m_application.UserStats.SendStatistics(ClausSoftware.Tools.ReportMessageType.Warning, "Taxes", "Invalid Tax assignment. starting UserDialog to set Taxrates")

        FillTaxRates()
        ' Immer noch ungültig ? 


        'TODO: NLS
        MessageBox.Show("Der bisherige Steuersatz muss von Ihnen angepasst werden. " & vbCrLf & _
                        "Bitte weisen Sie den Steuersätzten die Eigenschaft 'Normal','Ermässigt' usw zu." & vbCrLf & _
                        "Das ist leider nötig, da dies nicht automatich erkannt werden konnte.", "Steuersatzarten neu zuweisen", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Do While ClausSoftware.Kernel.TaxRates.IsInvalid


            ' Dialog anzeigen lassen 
            Dim frm As New frmRepairTaxes
            If frm.ShowDialog() = vbOK Then

                m_application.TaxRates.Save()
                m_application.TaxRates.Initialize()
            Else
                'Abbrechen? 
                'TODO: Dann kann im Materialstamm keine Stamdardsteuer abgerufen werden!
                'TODO: NLS

            End If

            If ClausSoftware.Kernel.TaxRates.IsInvalid Then
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
        Dim m_currentTaxeValues As ClausSoftware.Kernel.CountryInitialTaxRate
        Dim taxes As New ClausSoftware.Kernel.CountryInitialTaxRates()
        m_currentTaxeValues = taxes.GetLocalTaxRate

        Debug.Print("Repariere Steuersätze für: " & My.Application.Culture.NativeName)

        If m_currentTaxeValues IsNot Nothing Then
            ' -1 heisst nicht vergeben

            Dim itemTax As Kernel.TaxRate = m_application.TaxRates.GetNewItem

            
            itemTax.Name = GetText("NoTax", "Ohne")
            itemTax.TaxStatus = Kernel.enumTaxKind.NullTax
            itemTax.TaxValue = 0
            m_application.TaxRates.Add(itemTax)

            itemTax = m_application.TaxRates.GetNewItem
            itemTax.Name = GetText("ReducedTax", "Ermässigt")
            itemTax.TaxStatus = Kernel.enumTaxKind.ReducedTax
            itemTax.TaxValue = m_currentTaxeValues.ReducedTaxRate
            m_application.TaxRates.Add(itemTax)

            itemTax = m_application.TaxRates.GetNewItem
            itemTax.Name = GetText("NormalTax", "Normal")
            itemTax.TaxStatus = Kernel.enumTaxKind.NormalTax
            itemTax.TaxValue = m_currentTaxeValues.NormalTaxRate
            m_application.TaxRates.Add(itemTax)


            If m_currentTaxeValues.ExtraTaxrate <> -1 Then
                itemTax = m_application.TaxRates.GetNewItem
                itemTax.Name = GetText("ExtraTax", "Extra")
                itemTax.TaxStatus = Kernel.enumTaxKind.ExtraTax
                itemTax.TaxValue = m_currentTaxeValues.ExtraTaxrate
                m_application.TaxRates.Add(itemTax)
            End If


            If m_currentTaxeValues.ReducedTaxRate2 <> -1 Then
                itemTax = m_application.TaxRates.GetNewItem
                itemTax.Name = GetText("ExtraTax2", "Ermässigt-2")
                itemTax.TaxStatus = Kernel.enumTaxKind.ReducedTax2
                itemTax.TaxValue = m_currentTaxeValues.ReducedTaxRate2
                m_application.TaxRates.Add(itemTax)
            End If

            m_application.TaxRates.Save()

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
                lang = m_application.Languages.GetActiveLanguage
            Catch ex As Exception
                lang = ""
                ' Kann nur passieren, wenn per Kommandozeile eine ungültige Sprche angegeben wurde
                errormessage = ex.Message
            End Try
            If lang.Length = 0 Then
                ' Nun Sprache aussuchen lassen; 

                Dim InvalidLanguage, headInvalidLanguage As String

                If System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName = "de" Then
                    InvalidLanguage = "Sie haben per Kommandozeile eine unbekannte Sprache angegeben. Bitte berichtigen sie die Kommandozeile." & vbCrLf & _
                        "Benutzen Sie diese Form: ""/lang:de"" or ""/lang:de-de""" & vbCrLf & vbCrLf & _
                    "Möchten Sie mit Deutsch fortfahren oder abbrechen?"
                    headInvalidLanguage = "Unbekannte Sprache angegeben"
                Else
                    InvalidLanguage = "You have set an unknown language. Please correct this. " & vbCrLf & _
                        "Use this form: ""/lang:de"" or ""/lang:de-de""" & vbCrLf & vbCrLf & _
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

        m_application.Languages.Initialize()


        m_application.Languages.GetActiveLanguage()

    End Sub

    ''' <summary>
    ''' Legt aus der mitgelieferten Template-Datenbank einen Standard an
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateDefaultDatabase()

        m_application.Log.WriteLog(Tools.LogSeverity.Information, "CreateDefaultDatabase: Erstellte standard Datenbank")

        Dim defaultConnection As ClausSoftware.Tools.Connection = Tools.Connections.GetSimpelDefaultDatabase()
        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(defaultConnection.Path))
        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(defaultConnection.BackupPath))

        Dim templatePath As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "TemplateDataBase\Template.mdb")
        If Not System.IO.File.Exists(defaultConnection.Path & "\daten.mdb") Then
            ' Falls das Zielverzeichnis noh nicht existiert, dann anlegen
            If Not System.IO.Directory.Exists(defaultConnection.Path) Then System.IO.Directory.CreateDirectory(defaultConnection.Path)
            System.IO.File.Copy(templatePath, defaultConnection.Path & "\daten.mdb", False)
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

    Private Sub CheckUserLogin()
        'If m_application.Users.Count > 0 Then

        '    If m_application.Licenses.IsActiveUserSecurity Then ' Nur wenn die Benutzereinrichtung lizensiert wurde, dann auch den Login-screen anzeigen lassen

        '        Dim frm As New ClausSoftware.HWLInterops.frmLoginDlg
        '        frm.Application = m_application
        '        frm.ShowDialog()
        '    End If

        'End If

    End Sub

    ''' <summary>
    ''' Schreibt die gewählten Steuersätze in die lokale Datenbank
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTaxRates(ByVal currentTaxeValues As ClausSoftware.Kernel.CountryInitialTaxRate)
        If m_application.TaxRates.Count = 0 Then
            Dim tax As Kernel.TaxRate

            ' Normal und Ermässigt gibt es immer
            tax = m_application.TaxRates.GetNewItem
            tax.TaxStatus = Kernel.enumTaxKind.NormalTax
            tax.TaxValue = currentTaxeValues.NormalTaxRate
            tax.Name = GetText(Kernel.enumTaxKind.NormalTax.ToString, "Normal")
            tax.Save()

            If currentTaxeValues.ReducedTaxRate >= 0 Then
                ' Ermässigt
                tax = m_application.TaxRates.GetNewItem
                tax.TaxStatus = Kernel.enumTaxKind.ReducedTax
                tax.TaxValue = currentTaxeValues.ReducedTaxRate
                tax.Name = GetText(Kernel.enumTaxKind.ReducedTax.ToString, "Ermässigt")

                tax.Save()
            End If

            If currentTaxeValues.ReducedTaxRate2 >= 0 Then
                ' Zwischensatz  1
                tax = m_application.TaxRates.GetNewItem
                tax.TaxStatus = Kernel.enumTaxKind.ReducedTax2
                tax.TaxValue = currentTaxeValues.ReducedTaxRate2
                tax.Name = GetText(Kernel.enumTaxKind.ReducedTax2.ToString, "Zwischensatz")
                tax.Save()
            End If

            If currentTaxeValues.ExtraTaxrate >= 0 Then

                ' Extra
                tax = m_application.TaxRates.GetNewItem
                tax.TaxStatus = Kernel.enumTaxKind.ExtraTax
                tax.TaxValue = currentTaxeValues.ExtraTaxrate
                tax.Name = GetText(Kernel.enumTaxKind.ExtraTax.ToString, "Extra")

                tax.Save()
            End If

            ' Nullstaeuersatz
            tax = m_application.TaxRates.GetNewItem
            tax.TaxStatus = Kernel.enumTaxKind.NullTax
            tax.TaxValue = 0
            tax.Name = GetText(Kernel.enumTaxKind.NullTax.ToString, "Ohne Steuern")

            tax.Save()

            m_application.TaxRates.Reload()
        End If
    End Sub

    ''' <summary>
    ''' Prüft, ob die Datenbank-Verbindung gültig ist und benutzt werden kann
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckDBUserConnection() As Boolean
        Dim Result As DialogResult

        Dim res As ClausSoftware.DataBase.DBResult = Me.TestDatabaseConnection()
        If Not res.IsValid Then
            m_application.Log.WriteLog(Tools.LogSeverity.Critical, "CheckuserConnection detects an invalid Database connection. ErrorText: " & res.ErrorText)
        End If

        ' Solange keine Standard-Verbindung existiert und diese nicht geöffnet werden kann, dann Abbruch !
        Do While Not res.IsValid
            Dim frm As New frmConnectionConfiguration
            Result = frm.ShowDialog()

            If Result = DialogResult.Cancel Then Return False

            res = Me.TestDatabaseConnection
        Loop
        Return True

    End Function


    ''' <summary>
    ''' Prüft, ob die aktuelle Datenverbindung existiert.  
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TestDatabaseConnection() As ClausSoftware.DataBase.DBResult
        '  Dim myApp As New ClausSoftware.mainApplication
        m_application.Log.WriteLog(Tools.LogSeverity.Verbose, "Startet Testen der Datenbankverbindung")
        'myApp.Connections.ReadConnections()
        m_application.Connections.ReadConnections()
        Dim mydefaultConnection As ClausSoftware.Tools.Connection = m_application.Connections.WorkConnection

        Dim result As New ClausSoftware.DataBase.DBResult()

        If mydefaultConnection Is Nothing Then
            m_application.Log.WriteLog(Tools.LogSeverity.Verbose, "Keine Standardverbindung gefunden, erstellte neue Standardverbindung")
            CreateDefaultDatabase()
        End If

        If mydefaultConnection IsNot Nothing Then
            'Falls lokale Installation, UND die Datenbankdatei konnt enicht gefunden werden, lege diese an (kopiere aus Template)
            If mydefaultConnection.Servertype = Tools.enumServerType.Access Then
                If Not System.IO.File.Exists(mydefaultConnection.Path & "\daten.mdb") Then
                    CreateDefaultDatabase()
                End If
            End If


            Dim myTestDB As ClausSoftware.DataBase.DbEngine

            myTestDB = New ClausSoftware.DataBase.DbEngine(mydefaultConnection)
            m_application.SendMessage("Stelle Verbindung mit " & mydefaultConnection.GetConnectionShortDescription & " her...") ' TODO: NLS
            result = myTestDB.TestConnection()
            myTestDB.Dispose()

        Else

            m_application.Log.WriteLog(Tools.LogSeverity.ErrorMessage, "Keine Standardverbindung angelegt. 'CreateDefaultDatabase' hat keine Verbindung erstellt!")


            ' Verbindung konnte gar nicht gefunden werden
            'TODO: NLS; Hier angeben, das überhaupt keine Verbindung konfiguriert wurde (Connection stzring war nothing) 
            result.ErrorText = "Es wurde keine Verbindung gefunden" 'TODo: NLS
            result.IsValid = False
            result.Solution = "Erstellen Sie eine neue Verbindung zu einer Datenbank"
        End If

        Return result


    End Function

    ''' <summary>
    ''' Initialisiert das Globale Fehlerhandling für schwerwiegende Fehler
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartErrorReporting()
        m_errorReporting = New ErrorReporting.MainErrorHandler(m_application)
        AddHandler System.Windows.Forms.Application.ThreadException, AddressOf localThreadExeption
    End Sub

    ''' <summary>
    ''' Startet das Hauptfenster und beginnt dessen MessageLoop
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub StartWindow()

        Dim MainWindow As New frmMain
        MainWindow.IsFirstStart = Me.IsFirstStart

        System.Windows.Forms.Application.Run(MainWindow)

    End Sub


    ''' <summary>
    ''' Beendet die Applikation
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ApplicationEnd()
        Try
            m_application.UserStats.SendStatistics(ClausSoftware.Tools.ReportMessageType.ApplicationEnd, "Application runtime", m_AppStartWatch.Elapsed.ToString)
            m_application.Languages.SaveLanguageFile()
            m_application.CloseConnection()

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
        If m_application.Database.DatabaseType = Tools.enumServerType.Access Then
            'TODO: NLS

            m_application.SendMessage(GetText("msgCreatingDatabaseBackup", "Eine Sicherungskopie der Datenbank wird angelegt..."))

            'If MessageBox.Show("Möchten Sie eine Sicherungskopie anlegen?", "Datensicherung", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            m_application.Database.StartBackup()
            'End If
        End If

    End Sub

    Public Sub New()

    End Sub

    Private Shared Sub localThreadExeption(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)
        If m_application IsNot Nothing Then
            m_application.UserStats.SendStatistics(Tools.ReportMessageType.ApplicationCrash, "MainApplication-Crash", e.Exception.Message)

            ' 1. Zeile Mesage, die weiteren Zeilen der Stack -Trace ? 
            Dim st As String = String.Empty
            For Each line As String In e.Exception.StackTrace
                st &= line & vbCrLf
            Next

            ' Mit Stack senden
            m_application.UserStats.SendStatistics(Tools.ReportMessageType.ApplicationCrash, "MainApplication-Crash", st)

            'Das zuletzt gesendte Merken und dann ignorieren
            Static LastMessage As String = String.Empty

            ' Fehlermeldung direkt senden 
            Try
                If m_application.UserStats.SendingAllowed Then
                    Dim er As New ClausSoftware.ErrorReporting.MainErrorHandler(m_application)
                    System.Net.ServicePointManager.Expect100Continue = False
                    Dim SystemInformation As String = er.GetSessionDetails()

                    Dim errorMessage As String = SystemInformation

                    errorMessage &= Environment.NewLine & Environment.NewLine

                    errorMessage &= ClausSoftware.Tools.LogHandling.GetInnerExceptionMessages(e.Exception)


                    er.Application = m_application
                    er.Currentexception = e.Exception

                    ' Niemals die selbe Meldung mehrfach nacheinander senden
                    If Not LastMessage.Equals(errorMessage) Then
                        LastMessage = errorMessage

                        Dim report As New ClausSoftware.ErrorReporting.ErrorReportingService.ErrorReporting()
                        report.Timeout = 30 * 1000 ' Nicht zu lange warten (in millisekunden)
                        ' Hier das Problem senden und ohne warten zurückkehren
                        report.SendErrorMessageExUserMessageAsync(errorMessage, "DirectSend", "Internal catched Exception", 0, New Object)
                    End If
                End If

            Catch
            End Try


        End If

    End Sub

    Private Sub CheckBuildInReports()
        ' Beim start alle Reports testen ? 
        Printing.PrintingManager.CheckAndRepairDefaultLaoyuts()
    End Sub
    ''' <summary>
    ''' stellt eine Lizenzprüfung breit
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckLicenses()
        ' TC am 23.01.2013: Keine Einschränkung mehr !
        ' Habs aufgegeben
        Debug.Print("LIZENZPRÜFUNG UMGEHEN!")

        'IMPORTANT: LIZENZPRÜFUNG UMGEHEN!  (Rücksprung rausnehmen, um wieder Lizenzen zu prüfen)
        Return

        ' 30 Tage stille, dann 30 Tage Meldung 
        Dim daysLeft As Integer = m_application.Licenses.GetBalanceLicenceTime()

        ' 60 Tage ab Installationszeitraum wird gezählt; 
        ' negative Zahlen kennzeichnen mehr als 60 Tage nach Installation


        Dim baseLic As Data.LicenseItem = m_application.Licenses.GetBaseLicense
        ' Nur wenn 30 Tage seit Installation vergangen sidn UND keine Lizenz existiert, dann meldung machen...
        If daysLeft < 30 And Not m_application.Licenses.BaseCodeCheck(baseLic) Then  ' 30 Tage Frist abgelaufen; meldung machen 

            ' Meldung aufrufen
            Using frm As New frmTestperiodExpired
                frm.ShowDialog()
            End Using

            ' 90 (60 Tage Zeitraum + 30 weitere Tage) Tage über die Zeit, keine weitere Programmausführung mehr!

            If daysLeft < -30 And Not m_application.Licenses.BaseCodeCheck(baseLic) Then
                Me.ApplicationEnd()
                End
            End If

            If Not m_application.Licenses.IsBaseActive Then ' Testzeitraum überschritten, dann ist die Lizenz auf jeden Fall "ungültig"
                '  Auf das Ende hinweisen

                'TODO: NLS
                If MessageBox.Show("Nach Ablauf des Testzeitraumes können Sie keine Daten mehr speichern. Bitte erwerben sie die Vollversion.", "Testzeitraum abgelaufen", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) <> DialogResult.OK Then
                    Me.ApplicationEnd()
                    End
                End If

            End If
        End If


    End Sub

    ''' <summary>
    ''' Setzt einige Standardwerte die beim allerersten Start nötig währen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDefaultValues()
        m_application.Settings.Articlesettings.DefaultTaxRate = m_application.TaxRates.GetNormalTax

    End Sub

    ''' <summary>
    ''' Auf existenz anderer Produkte prüfen
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckCompetetors()

        'HKEY_CURRENT_USER\
        Dim KB2011exists As Boolean = False
        Try
            If My.Computer.Registry.CurrentUser.OpenSubKey("Software\combit\Dialog Position\KINGBILL2011") IsNot Nothing Then
                KB2011exists = True
            End If
        Finally
            My.Computer.Registry.CurrentUser.Close()
        End Try

        Dim KB2010exists As Boolean = False

        Try
            If My.Computer.Registry.CurrentUser.OpenSubKey("Software\combit\Dialog Position\KINGBILL2010") IsNot Nothing Then
                KB2010exists = True
            End If
        Finally
            My.Computer.Registry.CurrentUser.Close()
        End Try


        If KB2010exists Then
            m_application.UserStats.SendStatistics("Competitors", "KB-2010")
        End If

        If KB2011exists Then
            m_application.UserStats.SendStatistics("Competitors", "KB-2011")
        End If
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
            System.Windows.Forms.Application.Exit()
            End
        End If


        If osVersion.Minor > 3 Then
            Throw New ApplicationException("Invalid OS System")
            System.Windows.Forms.Application.Exit()
            End
        End If

    End Sub

    Public Class CommandLineManager
        Public Shared Function GetAllAttributes() As String
            Dim c As New ClausSoftware.Kernel.CommandLineManager
            c.GetCommandlineArguments()

            Dim commandLines As String = String.Empty

            For Each item As Kernel.CommandLineArgument In c.GetCommandlineArguments
                commandLines &= item.ToString & Environment.NewLine
            Next

            Return commandLines
        End Function

    End Class

End Class
