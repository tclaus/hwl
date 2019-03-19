Imports ClausSoftware.Data

''' <summary>
''' Stellt die oberste Klasse bereit, die allgemeine Steurungsaufgaben der UserControls enthält
''' </summary>
''' <remarks></remarks>
Public Class mainControlContainer

    ''' <summary>
    ''' Wird ausgelöst, wenn sich der Anzeigetext der Überschrift ändert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Event DisplayTextChanged(ByVal sender As mainControlContainer, ByVal e As DisplayTextEventArgs)

    Private Shared m_mainUI As mainUI

    ''' <summary>
    '''  Zeigt ein kleines Bild an, das in dern Tabs erscheint. Muss im Arbeitsmodul überschrieben werden
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overridable ReadOnly Property SmallImage() As Image
        Get
            Return Nothing
        End Get
    End Property

    ''' <summary>
    ''' Ermöglichst das Ausdrucken der aktiven Maske. 
    ''' Muss ind en Arbeitsmodulen überschrieben werden
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub Print()
        'Nischt.
    End Sub

    ''' <summary>
    ''' Ermöglicht das Abspeichern des gerade aktiven Elementes wenn überschrieben. 
    ''' In der Basisklasse wird keine Funktion ausgeführt
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub Save()
        ' Nischt - wird in den einzelnen Modulen implementiert
    End Sub

    ''' <summary>
    ''' Erlaubt das neuladen der gerade aktiven Daten und bewirkt ein Neuaufbau der Anzeige sofern implementiert
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub ReloadData()
        '
    End Sub

    ''' <summary>
    ''' Löst das Ereignis aus, das sich der Anzeigetext geändert hat
    ''' </summary>
    ''' <param name="newDisplaytext"></param>
    ''' <remarks></remarks>
    Public Sub FireRefreshDisplayText(ByVal newDisplaytext As String)
        Dim displayargs As New DisplayTextEventArgs()
        displayargs.NewDisplayText = newDisplaytext

        RaiseEvent DisplayTextChanged(Me, displayargs)
    End Sub

    ''' <summary>
    ''' Ruft die Klasse ab, die die Oberflächensteuerung bereitstellt
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property MainUI() As mainUI
        Get
            Return m_mainUI
        End Get
    End Property

    ''' <summary>
    ''' Erstellt eine neue Instanz und übergibt das Basis-UI Objekt
    ''' </summary>
    ''' <param name="ui"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ui As mainUI)
        Me.New()
        Debug.Assert(ui IsNot Nothing, "UI-Klasse darf nicht nothing sein!")
        m_mainUI = ui
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub



End Class

''' <summary>
''' Stellt eine Ereigniseigenschaft bereit, die einen Anzeigetext übergibt 
''' </summary>
''' <remarks></remarks>
Public Class DisplayTextEventArgs
    Inherits EventArgs

    Private m_dispayText As String
    ''' <summary>
    ''' Ruft den Anzeigetext ab oder legt diesen fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NewDisplayText() As String
        Get
            Return m_dispayText
        End Get
        Set(ByVal value As String)
            m_dispayText = value
        End Set
    End Property
End Class