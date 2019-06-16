Imports ClausSoftware.HWLInterops


''' <summary>
''' Stellt eine Auflistung mit möglichen Einstellungsmenüs dar
''' </summary>
''' <remarks></remarks>
Public Enum SettingsOptionType
    ''' <summary>
    ''' Ohne ein besonderes Modul
    ''' </summary>
    ''' <remarks></remarks>
    [None]
    ''' <summary>
    ''' Artikel-Optionen
    ''' </summary>
    ''' <remarks></remarks>
    Items
    ''' <summary>
    ''' Datenbankverbindungen
    ''' </summary>
    ''' <remarks></remarks>
    DatabaseSettings
    ''' <summary>
    ''' ISDN-Monitor
    ''' </summary>
    ''' <remarks></remarks>
    Telefonie
    Taxes
    NumberGenerator
    Users
    Protocol

    ''' <summary>
    ''' Bearbeitet Textbausteine
    ''' </summary>
    ''' <remarks></remarks>
    TextTemplates

    ''' <summary>
    ''' Ruft das Bearbeiten von Transaktionen ab 
    ''' </summary>
    ''' <remarks></remarks>
    Transactions
End Enum

''' <summary>
''' Stellt eine Operfläche mit Optionen bereit
''' </summary>
''' <remarks></remarks>
Public Class frmOptions

    Private m_optionsList As New Dictionary(Of String, ClausSoftware.HWLInterops.IOptionMenue)

    Private m_mainui As MainUI


    ''' <summary>
    ''' Ruft den internen Namen für die Einstellung ab
    ''' </summary>
    ''' <param name="itemType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSettingName(ByVal itemType As SettingsOptionType) As String
        Select Case itemType
            Case SettingsOptionType.DatabaseSettings : Return "database"
            Case SettingsOptionType.Items : Return "items"
            Case SettingsOptionType.NumberGenerator : Return "numbers"
            Case SettingsOptionType.Protocol : Return "protocol"
            Case SettingsOptionType.Taxes : Return "tax"
            Case SettingsOptionType.Telefonie : Return "telephony"
            Case SettingsOptionType.Users : Return "users"
            Case SettingsOptionType.TextTemplates : Return "texttemplates"
            Case SettingsOptionType.Transactions : Return "transactions"

            Case Else
                Throw New NotImplementedException("Typ: " & itemType.ToString & " unbekannt")
        End Select
    End Function


    ''' <summary>
    ''' Füllt die Liste mit den Optionsdialogen auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillOptionList()
        m_optionsList.Add("items", New iucOptionArticles())
        m_optionsList.Add("database", New iucOptionConnections())

        m_optionsList.Add("telephony", New iucOptionTapiConfiguration(m_mainui))
        m_optionsList.Add("taxes", New iucOptionTaxes())
        m_optionsList.Add("numbers", New iucOptionNumberGenerator())
        m_optionsList.Add("users", New iucOptionsUsers())
        m_optionsList.Add("protocol", New iucOptionsUsers())
        m_optionsList.Add("texttemplates", New iucOptionsTextTemplateEdit())
        m_optionsList.Add("transactions", New iucOptionTransactions())


    End Sub

    Private Sub navItems_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles navItems.LinkClicked, navDatabase.LinkClicked, navNumbers.LinkClicked, navProtocol.LinkClicked, navTaxRates.LinkClicked, navTelephony.LinkClicked, navUserRights.LinkClicked, navTextTemplates.LinkClicked, navTransactions.LinkClicked

        Dim itemKey As String = CStr(CType(sender, DevExpress.XtraNavBar.NavBarItem).Tag)
        If m_optionsList.ContainsKey(itemKey) Then
            Dim item As UserControl = CType(m_optionsList(itemKey), UserControl)


            If item IsNot Nothing Then
                ShowOption(item, itemKey)
            End If
        End If

    End Sub

    ''' <summary>
    ''' Öffnet das jeweilige Einstellungs-Fenster
    ''' </summary>
    ''' <param name="optionType"></param>
    ''' <remarks></remarks>
    Public Sub ShowOption(ByVal optionType As SettingsOptionType)
        Dim itemKey As String = GetSettingName(optionType)

        If m_optionsList.ContainsKey(itemKey) Then
            Dim item As UserControl = CType(m_optionsList(itemKey), UserControl)


            If item IsNot Nothing Then
                ShowOption(item, itemKey)
            End If
        End If

    End Sub

    ''' <summary>
    ''' Zeigt dieses Optionsmodul an und bringt es in den Vorergrund
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Private Sub ShowOption(ByVal item As UserControl, ByVal itemKey As String)
        If Not grpControls.Contains(item) Then
            m_optionsList(itemKey).Initialize()
            grpControls.Controls.Add(item)
            item.Dock = DockStyle.Fill

        End If
        grpControls.Text = item.ToString



        item.BringToFront()
    End Sub

    Private Sub frmOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        MainApplication.getInstance.Settings.SaveFormsPos(Me)
    End Sub

    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MainApplication.getInstance.Languages.SetTextOnControl(Me)
        MainApplication.getInstance.Settings.RestoreFormsPos(Me)

        ShowOption(SettingsOptionType.Items)
        For Each itemGroup As DevExpress.XtraNavBar.NavBarGroup In nbcOptionBar.Groups

            itemGroup.Caption = GetText(itemGroup.Name, itemGroup.Caption)

            For Each item As DevExpress.XtraNavBar.NavBarItemLink In itemGroup.ItemLinks
                item.Item.Caption = GetText(item.ItemName, item.Caption)
            Next
        Next

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveAllOptions()
        Me.Close()
    End Sub

    ''' <summary>
    ''' Speichert alle Einstellungen ab
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveAllOptions()
        Dim needsrestart As Boolean

        For Each item As IOptionMenue In m_optionsList.Values
            needsrestart = needsrestart Or item.NeedsRestart
            item.Save()
        Next

        If needsrestart Then

            Dim maintext As String = GetText("mainApplicationRestartNeeded", "Die Änderung die Sie vorgenommen haben, werden erst wirksam, wenn {appname} neu gestartet wurde. /n Möchten Sie {appname} nun neu starten?")
            Dim header As String = GetText("headerApplicationRestartNeeded", "Neustart erforderlich")

            Dim result As DialogResult = MessageBox.Show(maintext, header, MessageBoxButtons.YesNo)

            If result = Windows.Forms.DialogResult.Yes Then
                If Not System.Diagnostics.Debugger.IsAttached Then
                    System.Windows.Forms.Application.Restart()
                Else
                    Debug.Print("Einen Restart verkneifen wir uns, da ein Debugger angedockt ist!")
                End If
            End If



        End If

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(ByVal mainui As MainUI)

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        m_mainui = mainui

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        FillOptionList()

    End Sub
End Class