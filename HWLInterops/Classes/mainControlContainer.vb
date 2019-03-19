Imports ClausSoftware.Data

''' <summary>
''' Stellt die oberste Klasse bereit, die allgemeine Steurungsaufgaben der UserControls enth�lt
''' </summary>
''' <remarks></remarks>
Public Class mainControlContainer

    ''' <summary>
    ''' Wird ausgel�st, wenn sich der Anzeigetext der �berschrift �ndert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Event DisplayTextChanged(ByVal sender As mainControlContainer, ByVal e As DisplayTextEventArgs)

    Private Shared m_mainUI As mainUI

    ''' <summary>
    '''  Zeigt ein kleines Bild an, das in dern Tabs erscheint. Muss im Arbeitsmodul �berschrieben werden
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
    ''' Erm�glichst das Ausdrucken der aktiven Maske. 
    ''' Muss ind en Arbeitsmodulen �berschrieben werden
    ''' </summary>
    ''' <remarks></remarks>
    Overridable Sub Print()
        'Nischt.
    End Sub

    ''' <summary>
    ''' Erm�glicht das Abspeichern des gerade aktiven Elementes wenn �berschrieben. 
    ''' In der Basisklasse wird keine Funktion ausgef�hrt
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
    ''' L�st das Ereignis aus, das sich der Anzeigetext ge�ndert hat
    ''' </summary>
    ''' <param name="newDisplaytext"></param>
    ''' <remarks></remarks>
    Public Sub FireRefreshDisplayText(ByVal newDisplaytext As String)
        Dim displayargs As New DisplayTextEventArgs()
        displayargs.NewDisplayText = newDisplaytext

        RaiseEvent DisplayTextChanged(Me, displayargs)
    End Sub

    ''' <summary>
    ''' Ruft die Klasse ab, die die Oberfl�chensteuerung bereitstellt
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
    ''' Erstellt eine neue Instanz und �bergibt das Basis-UI Objekt
    ''' </summary>
    ''' <param name="ui"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ui As mainUI)
        Me.New()
        Debug.Assert(ui IsNot Nothing, "UI-Klasse darf nicht nothing sein!")
        m_mainUI = ui
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' F�gen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub



End Class

''' <summary>
''' Stellt eine Ereigniseigenschaft bereit, die einen Anzeigetext �bergibt 
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