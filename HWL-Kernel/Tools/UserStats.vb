Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web
Imports Microsoft.VisualBasic

Namespace Tools

    Public Enum ReportMessageType
        ''' <summary>
        ''' Absturz... 
        ''' </summary>
        ''' <remarks></remarks>
        ApplicationCrash
        ''' <summary>
        ''' Benutzerende der Applikation
        ''' </summary>
        ''' <remarks></remarks>
        ApplicationEnd
        ''' <summary>
        ''' Start der Applikation
        ''' </summary>
        ''' <remarks></remarks>
        ApplicationStart

        ''' <summary>
        ''' Zeitdauert, bis die Applikation gestartet ist
        ''' </summary>
        ''' <remarks></remarks>
        ApplicationStartUpTime
        ''' <summary>
        ''' Reine Information, ohne besondere Bedeutung
        ''' </summary>
        ''' <remarks></remarks>
        Info

        ''' <summary>
        ''' Zeigt einen warnzustand an. Ein nicht vorhersehbarer Zutand der Daten wurde erreicht und der Benutzer muss eingreiffen
        ''' </summary>
        ''' <remarks></remarks>
        Warning
        ''' <summary>
        ''' Startereignis eines Modules
        ''' </summary>
        ''' <remarks></remarks>
        ModulStart
        ''' <summary>
        ''' Ein Programmteil wurde geschlossen
        ''' </summary>
        ''' <remarks></remarks>
        ModulEnd
        ''' <summary>
        ''' Startdauer eines Programmteils von der Anforderung durch den Anwender (click) bis zur Bereitstellung der Oberfläche (_Shown)
        ''' </summary>
        ''' <remarks></remarks>
        StartupTime


    End Enum

End Namespace