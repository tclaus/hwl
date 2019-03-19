Imports System.IO

''' <summary>
''' sucht den Datanorm-Konverter und läd gegegenenfalls die neue Version herunter 
''' </summary>
''' <remarks></remarks>
Public Class VersionConverter

    Const FolderName As String = "Datanorm_V5"
    Const FileName As String = "Datank05.exe"

    Friend Shared Function GetConverterPath() As String

        ' 1. Mitgeliefert in "./converter"
        ' 2. in "./"
        ' 3. in $Programfiles$/ Foldername

        Dim codePath As String = Path.GetDirectoryName(GetType(VersionConverter).Assembly.CodeBase)  ' Aktuellen Pfad ermitteln
        codePath = codePath.Replace("file:\", "")
        Dim extendePath As String
        extendePath = Path.Combine(codePath, FileName)


        If File.Exists(extendePath) Then
            Return extendePath
        Else
            Debug.Print("Converter not found in {0} ", extendePath)

        End If


        extendePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
        extendePath = Path.Combine(extendePath, FolderName) ' Ordnername der Standard-Instaöllation angeben
        extendePath = Path.Combine(extendePath, FileName)

        If File.Exists(extendePath) Then
            Return extendePath
        Else
            Debug.Print("Converter not found in {0} ", extendePath)

        End If

        System.Windows.Forms.MessageBox.Show("Eine notwendige Komponente für die Datanorm-Konvertierung wird nun geladen..", "Datanorm-Konverter fehlt", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)


        ' Nun neu laden 
        InitializeImport.Application.Log.WriteLog("Converter not found. Start loading and installing Datanorm Importer")

        'http://rechnungen-schreiben.de/download/datanorm-konvert.exe

        Dim converterAddress As String = "http://rechnungen-schreiben.de/download/datanorm-konvert.exe"

        Dim tmpDownloadTarget As String = Path.GetTempPath
        tmpDownloadTarget = Path.Combine(tmpDownloadTarget, "datanorm-konvert.exe")

        My.Computer.Network.DownloadFile(converterAddress, tmpDownloadTarget, String.Empty, String.Empty, True, 100, True)

        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(tmpDownloadTarget)
        p.WaitForExit()


        ' Bete, das der da drinn ist,..
        Return extendePath

    End Function


End Class
