Imports System.ComponentModel

Public Class frmSplashScreen

    Private m_aboutMode As Boolean

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        mpcSplash.Visible = True
        btnClose.Visible = False

        AddHandler MainApplication.getInstance.Message, AddressOf SetMessage
        AddHandler MainApplication.getInstance.Progress, AddressOf Progress
        AddHandler MainApplication.getInstance.StartMarquee, AddressOf ShowMarquee
        AddHandler MainApplication.getInstance.EndMarquee, AddressOf HideMarquee

        MainApplication.getInstance.Languages.SetTextOnControl(Me)
        lblApplicationTitle.Text = ClausSoftware.MainApplication.ApplicationName
        Me.Text = ""
    End Sub

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


    ''' <summary>
    ''' Schliesst das Fenster und gibt die Handler wieder frei
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub Close()
        If MainApplication.getInstance IsNot Nothing Then
            RemoveHandler MainApplication.getInstance.Message, AddressOf SetMessage
            RemoveHandler MainApplication.getInstance.Progress, AddressOf Progress
            RemoveHandler MainApplication.getInstance.StartMarquee, AddressOf ShowMarquee
            RemoveHandler MainApplication.getInstance.EndMarquee, AddressOf HideMarquee
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

        'Application title
        If My.Application.Info.Title <> "" Then
            lblApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            lblApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        ' Zur Not aus der eignen datenstruktur den Titel abholen 
        If MainApplication.getInstance IsNot Nothing Then
            lblApplicationTitle.Text = ClausSoftware.MainApplication.ApplicationName
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
        Me.Text = ClausSoftware.MainApplication.ApplicationName

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
