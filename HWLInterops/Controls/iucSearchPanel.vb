Imports DevExpress.XtraEditors.Controls

''' <summary>
''' Stellt eine Texteingabebox zur Verfügung, die für das suchen von Elementen optimiert ist
''' </summary>
''' <remarks></remarks>
<DefaultEvent("SearchTextChanged")> _
Public Class iucSearchPanel



    ''' <summary>
    ''' Ruft die Zeitverzögerung des suchfeldes in ms ab oder legt diese fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(500I)> _
    <Description("Ruft die Zeitverzögerung des suchfeldes in ms ab oder legt diese fest")> _
    Public Property TimerInterval() As Integer
        Get
            Return Timer1.Interval
        End Get
        Set(ByVal value As Integer)
            Timer1.Interval = value
        End Set
    End Property


    <Description("Wird nach einer Verzögerung ausgelöst, wenn sich der eingegebene Text ändert.")> _
    Public Event SearchTextChanged(ByVal sender As Object, ByVal e As SearchTextEventArgs)

    ''' <summary>
    ''' wird ausgelöst, wenn die Textbox ein "Down" erhält und so das nächste Steuerelement den Focus erhalten soll
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <Description("Wird ausgelöst, wenn signalisiert wird, das das nächste Steuerelement den Focus erhalten soll")> _
    Public Event SetNextControl(ByVal sender As Object, ByVal e As EventArgs)

    Private m_rememberSearchTexts As Boolean
    Private m_kontextMenuTexts As List(Of String)

    Event SelectedContectMenuHasChanged(ByVal sender As Object, ByVal e As SelectedContectMenuChangedeventArgs)

    ''' <summary>
    ''' Stellt den aktuellen Status des Suchfeldes dar.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_state As enumState = enumState.empty

    Private m_kontextMenue As ContextMenuStrip

    Private m_selectedContextItem As Integer = -1


    Private ButtonMenue As New EditorButton(ButtonPredefines.Down, GetText("msgClickHereForSeacrhPatterns", "Klicken um eine Auswahl an Suchmuster zu erhalten"))
    Private ButtonCancel As New EditorButton(ButtonPredefines.Close, GetText("msgClearSearch", "Suche löschen"))
    Private ButtonSearch As New EditorButton(ButtonPredefines.Glyph, GetText("msgSearchFor", "Suche nach "))

    ''' <summary>
    ''' Stellt den aktuellen Status des Suchfeldes dar.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumState
        ''' <summary>
        ''' Das suchfeld ist leer, Benutzer hat keinen spezifischen Text eingegeben
        ''' </summary>
        ''' <remarks></remarks>
        empty

        ''' <summary>
        ''' Das Suchfeld enthält Texte, die einer Suche zugeführt werden müssen.
        ''' </summary>
        ''' <remarks></remarks>
        edited
    End Enum

    ''' <summary>
    ''' Leitet die 'TabStop' Eigenschaft der Textbox weiter, erlaubt das focussieren der Textbox durch einen Tabstop
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("Leitet die 'TabStop' Eigenschaft der Textbox weiter, erlaubt das focussieren der Textbox durch einen Tabstop")> _
Public Property AllowTextFieldTabStop As Boolean
        Get
            Return txtSearchText.TabStop
        End Get
        Set(ByVal value As Boolean)
            txtSearchText.TabStop = value
        End Set
    End Property

    ''' <summary>
    ''' Enthält das markierte Menüelement
    ''' </summary>
    ''' <remarks></remarks>
    Class SelectedContectMenuChangedeventArgs
        Inherits EventArgs

        Private m_selectedItem As Integer

        Property SelectedItem() As Integer
            Get
                Return m_selectedItem
            End Get
            Set(ByVal value As Integer)
                m_selectedItem = value
            End Set
        End Property

        Sub New(ByVal selectedItem As Integer)
            m_selectedItem = selectedItem
        End Sub

    End Class



    ''' <summary>
    ''' Ruft das aktuell gewählte MenuItem ab, oder -1, falls kein Menü definiert
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SelectedMenueItem() As Integer
        Get
            Return m_selectedContextItem
        End Get
        Set(ByVal value As Integer)
            m_selectedContextItem = value
        End Set
    End Property


    Sub CreateKontextMenue()
        m_kontextMenue.Items.Clear()

        For Each item As String In m_kontextMenuTexts
            Dim MenuItem As New ToolStripMenuItem(item)
            MenuItem.CheckOnClick = True
            AddHandler MenuItem.Click, AddressOf MenuItemClick
            m_kontextMenue.Items.Add(MenuItem)

        Next

    End Sub


    ''' <summary>
    ''' Ermöglicht, das alle anderen Menüeinträge unchecked bleiben
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Sub MenuItemClick(ByVal sender As Object, ByVal e As EventArgs)
        ' wenn einer gechecked wird, dann alle anderen entfeernen !

        Dim MenuItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        For Each item As ToolStripMenuItem In m_kontextMenue.Items
            If Not item Is MenuItem Then
                item.Checked = False
            End If
        Next

        m_selectedContextItem = m_kontextMenue.Items.IndexOf(MenuItem)
        RaiseEvent SelectedContectMenuHasChanged(MenuItem, New SelectedContectMenuChangedeventArgs(m_selectedContextItem))

    End Sub

    ''' <summary>
    ''' Gibt den Suchtext wieder zurück oder setzt diesen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shadows Property Text() As String

        Get
            If m_state = enumState.edited Then
                Return txtSearchText.Text
            Else
                Return ""
            End If

        End Get


        Set(ByVal value As String)
            txtSearchText.Text = value
        End Set
    End Property


    ''' <summary>
    ''' Ruft den Text ab, der ausgegraut angezeigt wird, wenn kein text in der suche enthalten ist
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Description("Legt den Anzeigetext fest, der angezeigt wird wenn das Controll leer ist.")> _
    Public Property NullValuePrompt() As String
        Get
            Return txtSearchText.Properties.NullValuePrompt
        End Get
        Set(ByVal value As String)
            txtSearchText.Properties.NullValuePrompt = value
        End Set
    End Property

    ''' <summary>
    ''' Ruft den aktuellen Status des Suchfensters zurück oder setzt diesen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Status() As enumState

        Get
            Return m_state
        End Get
        Set(ByVal value As enumState)
            Static Entry As Boolean = False

            If Entry Then Exit Property
            Entry = True
            If value <> m_state Then

                If value = enumState.empty Then
                    m_state = value

                    ButtonCancel.Visible = False
                    ButtonSearch.Visible = True

                End If

                If value = enumState.edited Then
                    m_state = value

                    ButtonSearch.Visible = False
                    ButtonCancel.Visible = True

                End If

                ' RaiseEvent StatusChanged(Me, m_State)
            End If
            Entry = False
        End Set
    End Property

    Private Sub txtSearchText_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtSearchText.DragDrop
        DragDropHelper.SetText(sender, e)
    End Sub

  

    Private Sub txtSearchText_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchText.KeyDown


        If e.KeyCode = Keys.Escape Then
            txtSearchText.Text = ""
            txtSearchText.Focus()
        End If
        If e.KeyCode = Keys.Down Then ' das nächste Control markieren
            RaiseEvent SetNextControl(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub txtSearchText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchText.TextChanged

        If txtSearchText.Text.Length > 0 Then
            ' Button "Close search" einblenden
            Status = enumState.edited
        Else

            If String.IsNullOrEmpty(txtSearchText.Text) Then
                txtSearchText.EditValue = Nothing
                Exit Sub
            End If

            RaiseEvent SearchTextChanged(Me, New SearchTextEventArgs("")) 'Ereignis sofort auslösen
            Status = enumState.empty
        End If

        Timer1.Stop()
        Timer1.Enabled = False

        Timer1.Enabled = True
        Timer1.Start()

    End Sub

    ''' <summary>
    ''' Wenn angegeben, dann kann ein unter-Menü aufgeklappt werden
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Darf nicht Public werden!</remarks>
    Friend Property ItemList() As List(Of String)
        Get
            Return m_kontextMenuTexts
        End Get
        Set(ByVal value As List(Of String))
            m_kontextMenuTexts = value
            If value IsNot Nothing Then
                CreateKontextMenue()
                ButtonMenue.Visible = True
            Else
                ButtonMenue.Visible = False

            End If
        End Set
    End Property


    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As ButtonPressedEventArgs) Handles txtSearchText.ButtonClick

        If e.Button Is ButtonCancel Then
            If Status = enumState.edited Then
                txtSearchText.Text = Nothing
                RaiseEvent SearchTextChanged(Me, New SearchTextEventArgs(String.Empty))
            Else
                If Not String.IsNullOrEmpty(txtSearchText.Text) Then
                    RaiseEvent SearchTextChanged(Me, New SearchTextEventArgs(txtSearchText.Text))
                End If


                End If
        End If

        If e.Button Is ButtonMenue Then
            ' sofern möglich, kontextmenü anzeigen lassen 
            m_kontextMenue.Show(txtSearchText, New Point(txtSearchText.Location.X, txtSearchText.Location.Y + txtSearchText.Height))
        End If


    End Sub

    Private Sub txtSearchText_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchText.LostFocus
        If txtSearchText.Text.Trim.Length = 0 Then
            ' Status = enumState.empty
        Else

        End If
        txtSearchText.EditValue = Nothing
    End Sub

    <DebuggerStepThrough()> _
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False

        If Me.Status = enumState.edited Then
            RaiseEvent SearchTextChanged(Me, New SearchTextEventArgs(txtSearchText.Text))
        End If

    End Sub


    Private Sub txtSearchText_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchText.MouseEnter
        ' txtSearchText.BackColor = Nothing

    End Sub

    Private Sub txtSearchText_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchText.MouseLeave
        ' txtSearchText.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub iucSearchPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtSearchText.Properties.NullValuePrompt = GetText("msgSearchNullText", "Suche...    F3")

        ButtonSearch.Image = My.Resources.view

       

    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        txtSearchText.Properties.Buttons.Add(ButtonCancel)
        txtSearchText.Properties.Buttons.Add(ButtonSearch)

        ButtonSearch.Visible = True
        ButtonCancel.Visible = False
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Timer1.Interval = 500

    End Sub

    ''' <summary>
    ''' Setzt den Focus auf das Eingabefeld
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetFocus()
        txtSearchText.Focus()
    End Sub

    Private Sub txtSearchText_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles txtSearchText.DragEnter
        DragDropHelper.CheckForText(sender, e)
    End Sub
End Class

Public Class SearchTextEventArgs
    Inherits EventArgs

    Private m_Text As String = String.Empty

    ''' <summary>
    ''' Ruft den suchtext ab oder legt diesen fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Text() As String
        Get
            Return m_Text
        End Get
        Set(ByVal value As String)
            m_Text = value
        End Set
    End Property

    Public Sub New()

    End Sub
    ''' <summary>
    ''' Erstellt eine neue Instanz der Klasse und übergibt den suchtext
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal text As String)
        m_Text = text
    End Sub
End Class
