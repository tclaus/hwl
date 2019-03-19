
''' <summary>
''' Stellt das Control für das Start-Panel mit dem ersten anzuzeigenden Screen dar
''' </summary>
''' <remarks></remarks>
Public Class iucHomeScreen
    Implements IModule


    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        Return True
    End Function

    ''' <summary>
    ''' Ruft das Hintergrundbild ab oder legt es fest 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PanelBackgroundImage As Image
        Get
            Return PictureEdit1.Image
        End Get
        Set(ByVal value As Image)
            PictureEdit1.Image = value
        End Set
    End Property


    ''' <summary>
    ''' Legt fest, ob die "Heute"- Ansicht sichtbar sein sollte oder nicht 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowTodayBar() As Boolean
        Get
            Return (SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both)
        End Get
        Set(ByVal value As Boolean)
            ' entweder beie Panels oder nur ein Panel anzeigen lassen
            If value Then
                SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
                m_application.Settings.SetSetting("TodayBar", "GUI", "True", m_application.CurrentUser.Key)
            Else
                SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
                m_application.Settings.SetSetting("TodayBar", "GUI", "False", m_application.CurrentUser.Key)
            End If



        End Set
    End Property


    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            Return String.Empty
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem

    End Sub

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return GetText("module_Start", "Start")

        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule
        CreateMainScreen()
        TodayBar1.MainUI = MainUI

        AddHandler TodayBar1.ClosePanel, AddressOf CloseTodayBar

    End Sub

    ''' <summary>
    ''' Bewirkt ein Schliessen der Today-Anzeige
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloseTodayBar()
        Me.ShowTodayBar = False
    End Sub


    ''' <summary>
    ''' Home-screen aufbauen, mit dem Hauptmenütext
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateMainScreen()
        'Dim homescreenCreator As New HomeScreen.HomeScreenCreator(pnlHomeScreen)
        'Dim stucture As New HomeScreen.MenuStructure
        'HomeScreen.HomeScreenDefinition.FillMenue(stucture)

        'homescreenCreator.HomeMenuStructure = stucture  ' Menüdefinition zuweisen 
        'homescreenCreator.CreateMainMenueTable() ' Menü aufbauen

        ' TODO: initiales Bild einlesen 

    End Sub



    Public Sub NewItem() Implements IModule.CreateNewItem

    End Sub

    ''' <summary>
    ''' Nicht implementirt
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub Print() Implements IModule.Print

    End Sub

    Public Sub SaveCurrentItem() Implements IModule.SaveCurrentItem

    End Sub

    Public Event StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IModule.StatusChanged

    Public ReadOnly Property SupportedButtons() As actionButtons Implements IModule.SupportedButtons
        Get
            Return actionButtons.None
        End Get
    End Property

    Public Overrides ReadOnly Property SmallImage() As System.Drawing.Image
        Get
            Return My.Resources.Home_16x16
        End Get
    End Property

    Private Sub iucHomeScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If DesignMode Then Exit Sub
        Dim result As String

        SplitContainerControl1.Width = Me.Width

        TodayBar1.Width = SplitContainerControl1.Panel2.Width

        result = m_application.Settings.GetSetting("TodayBar", "GUI", "True", m_application.CurrentUser.Key)
        If result.Equals("true", StringComparison.InvariantCultureIgnoreCase) Then
            ShowTodayBar = True
        Else
            ShowTodayBar = False
        End If


        ' Appname Hardcoded einsetzen (dann kann man nicht ind en textdateien den Dateinamen verändern)
        lblMainScreenwelcomeText.Text = m_application.Languages.GetText("{AppName}")

    End Sub
End Class
