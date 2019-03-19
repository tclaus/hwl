
<Flags()> _
Public Enum actionButtons
    ''' <summary>
    ''' Keine Buttons
    ''' </summary>
    ''' <remarks></remarks>
    [None] = 0
    ''' <summary>
    ''' Der schliessen-Button
    ''' </summary>
    ''' <remarks></remarks>
    btnClose = 1
    ''' <summary>
    ''' Der speichern-Button
    ''' </summary>
    ''' <remarks></remarks>
    btnSave = 2
    ''' <summary>
    ''' Der Drucken-Button
    ''' </summary>
    ''' <remarks></remarks>
    btnPrint = 4
    ''' <summary>
    ''' Der Neu-Button
    ''' </summary>
    ''' <remarks></remarks>
    btnNew = 8
    ''' <summary>
    ''' Der Löschen-Button
    ''' </summary>
    ''' <remarks></remarks>
    btnDelete = 16

End Enum

Public Interface IMenuBar
    ''' <summary>
    ''' Stellt das Modul dar, das im Menü aufgerufen wurde
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Event ClickedModule(ByVal sender As Object, ByVal e As moduleEventargs)




End Interface

Public Class moduleEventargs
    Inherits EventArgs


    Private m_module As HWLModules

    ''' <summary>
    ''' Enthält das Aufgerufene Modul, 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CallingModule() As HWLModules
        Get
            Return m_module
        End Get
        Set(ByVal value As HWLModules)
            m_module = value
        End Set
    End Property

    Public Sub New(ByVal callingModule As HWLModules)
        m_module = callingModule
    End Sub

End Class

''' <summary>
''' stellt Methoden zur Verwaltung von zentral organisierten Optionsmenues bereit
''' </summary>
''' <remarks></remarks>
Public Interface IOptionMenue

    ''' <summary>
    ''' Startet das Optionen-Modul, läd Einstellungen und zeigt diese an
    ''' </summary>
    ''' <remarks></remarks>
    Sub Initialize()

    ''' <summary>
    ''' Speichert geänderte Optionen ab
    ''' </summary>
    ''' <remarks></remarks>
    Sub Save()

    ''' <summary>
    ''' Verwirft eventuelle Änderungen und läd Einstellungen neu ein
    ''' </summary>
    ''' <remarks></remarks>
    Sub Reload()

    ''' <summary>
    ''' Ruft den Anzeigenamen dieses Steierelementes ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DisplayName() As String

    ''' <summary>
    ''' Lifert True zurück, wenn eine Ändeung in dieser Einstellung erfordert, das HWL neu gestartet werden muss
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property NeedsRestart As Boolean

End Interface


''' <summary>
''' Stellt ein Interface da, das ein Hauptmodul  darstellt
''' </summary>
''' <remarks></remarks>
Public Interface IModule

    Event StatusChanged(ByVal sender As Object, ByVal e As EventArgs)


    ReadOnly Property HasChanged() As Boolean
    ''' <summary>
    ''' Ruft den Text ab, der durch ein aktuell selektiertes Element definiert wird
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property DisplayText() As String

    ''' <summary>
    ''' Speichert das aktuelle Element ab
    ''' </summary>
    ''' <remarks></remarks>
    Sub SaveCurrentItem()

    ''' <summary>
    ''' Erstellt ein neues Element im aktuellen Kontext
    ''' </summary>
    ''' <remarks></remarks>
    Sub CreateNewItem()

    ''' <summary>
    ''' Löscht das aktuell ausgewählt Element
    ''' </summary>
    ''' <remarks></remarks>
    Sub DeleteItem()

    ''' <summary>
    ''' Leitet das Schliessen eines Modules ein
    ''' </summary>
    ''' <remarks></remarks>
    Function CloseModule() As Boolean

    ''' <summary>
    ''' Ruft den dialog zum Drucken des aktiven Fensters auf
    ''' </summary>
    ''' <remarks></remarks>
    Sub Print()

    ''' <summary>
    ''' Enthält eine Auflistung von Buttons, die eingeblendet wwerden sollen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SupportedButtons() As actionButtons

    ''' <summary>
    ''' Startet notwendige Initialisierungen 
    ''' </summary>
    ''' <remarks></remarks>
    Sub InitializeModule()

    ''' <summary>
    ''' Ruft die ReplikID des gerade selektierten Elementes ab
    ''' Leer, wenn kein Element markiert wurde
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CurrentItemID() As String



End Interface