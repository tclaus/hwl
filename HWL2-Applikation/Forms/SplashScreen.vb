Public NotInheritable Class SplashScreen


    '  of the Project Designer ("Properties" under the "Project" menu).
    Private m_application As ClausSoftware.mainApplication
    Private m_aboutMode As Boolean

    ''' <summary>
    ''' Wenn true, dann kann ein Mausklick das Fenster schliessen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AboutMode As Boolean
        Get
            Return m_aboutMode
        End Get
        Set(ByVal value As Boolean)
            m_aboutMode = value
            If value Then
                btnClose.Visible = True
            Else
                btnClose.Visible = False

            End If
        End Set
    End Property


    Property MainApplication() As ClausSoftware.mainApplication
        Get
            Return m_application
        End Get
        Set(ByVal value As ClausSoftware.mainApplication)
            m_application = value

            mpcSplash.Visible = True
            btnClose.Visible = False

            AddHandler m_application.Message, AddressOf SetMessage
            AddHandler m_application.Progress, AddressOf Progress
            AddHandler m_application.StartMarquee, AddressOf ShowMarquee
            AddHandler m_application.EndMarquee, AddressOf HideMarquee

            m_application.Languages.SetTextOnControl(Me)
            lblApplicationTitle.Text = ClausSoftware.mainApplication.ApplicationName
            Me.Text = ""            
        End Set
    End Property

    ''' <summary>
    ''' Schliesst das Fenster und gibt die Handler wieder frei
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub Close()
        If m_application IsNot Nothing Then
            RemoveHandler m_application.Message, AddressOf SetMessage
            RemoveHandler m_application.Progress, AddressOf Progress
            RemoveHandler m_application.StartMarquee, AddressOf ShowMarquee
            RemoveHandler m_application.EndMarquee, AddressOf HideMarquee
        End If
        MyBase.Close()
    End Sub

    Private Sub HideMarquee(ByVal sender As Object, ByVal e As EventArgs)
        mpcSplash.Visible = False
    End Sub

    Private Sub ShowMarquee(ByVal sender As Object, ByVal e As EventArgs)
        mpcSplash.Visible = True
    End Sub

    Private Sub HideProgressBar()
        ProgressBarControl1.Visible = False
    End Sub
    ''' <summary>
    ''' Signalisiert den Fortschritt eines Prozesses
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="value"></param>
    ''' <param name="maxvalue"></param>
    ''' <remarks></remarks>
    Private Sub Progress(ByVal text As String, ByVal value As Integer, ByVal maxvalue As Integer)

        mpcSplash.Visible = False

        ProgressBarControl1.Visible = True
        'ProgressBarControl1. = text
        ProgressBarControl1.Properties.ShowTitle = True
        ProgressBarControl1.Properties.Maximum = maxvalue
        ProgressBarControl1.EditValue = value
        ProgressBarControl1.Refresh()
        Application.DoEvents()
    End Sub

    ''' <summary>
    ''' Schreibt einen Statustext im Startbildschirm
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub SetMessage(ByVal message As String)
        lblStatusMessage.Text = message
        lblStatusMessage.Refresh()
        Application.DoEvents()
    End Sub

    Private Sub SplashScreen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.AboutMode Then
            Me.Close()
        End If
    End Sub



    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            lblApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            lblApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)

        End If

        ' Zur Not aus der eignen datenstruktur den Titel abholen 
        If m_application IsNot Nothing Then
            lblApplicationTitle.Text = ClausSoftware.mainApplication.ApplicationName
        End If

        lblApplicationTitle.Refresh()
        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        lblVersion.Text = System.String.Format(lblVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        PictureEdit1.Image = My.Resources.Symbol_Check_24x24
        PictureEdit2.Image = My.Resources.Symbol_Check_24x24
        PictureEdit3.Image = My.Resources.Symbol_Check_24x24
        PictureEdit4.Image = My.Resources.Symbol_Check_24x24

        'Copyright info
        lblStatusMessage.Text = String.Empty
        Me.Text = ClausSoftware.mainApplication.ApplicationName

    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub lblCompanywebAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCompanywebAddress.Click
        Try ' webseite aufrufen, die hinter diesem Label angezeigt wird.
            Process.Start(lblCompanywebAddress.Text)
        Catch
        End Try
    End Sub
End Class
