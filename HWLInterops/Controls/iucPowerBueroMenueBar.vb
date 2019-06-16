
''' <summary>
''' stellt die Horizontale Menüleiste für Power-Büro zur Verfügung
''' </summary>
''' <remarks></remarks>
Public Class iucPowerBueroMenueBar
    Implements IMenuBar


    Public Delegate Sub delSelectedModuleChanged(ByVal key As HWLModules)
    Public Event SelectedModuleChanged As delSelectedModuleChanged

    Private Sub RaiseEvents(ByVal callingModule As HWLModules)
        RaiseEvent SelectedModuleChanged(callingModule)
        RaiseEvent ClickedModule(Me, New moduleEventargs(callingModule))

    End Sub

    Private Sub btnadressbook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadressbook.Click
        RaiseEvents(HWLModules.Adressbook)

    End Sub

    Private Sub btnArticles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArticles.Click
        RaiseEvents(HWLModules.Articles)

    End Sub

    Private Sub btnWorkitems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub cmdBuisiness_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusiness.Click
        RaiseEvents(HWLModules.Business)

    End Sub

    Private Sub btnCashFlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashFlow.Click
        RaiseEvents(HWLModules.Transactions)

    End Sub

    Private Sub btnKasse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKasse.Click
        RaiseEvents(HWLModules.CashJournal)

    End Sub

    Private Sub btnLetters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLetters.Click
        RaiseEvents(HWLModules.Letters)

    End Sub

    Private Sub btnScheduler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScheduler.Click
        RaiseEvents(HWLModules.Scheduler)

    End Sub

    Public Event ClickedModule(ByVal sender As Object, ByVal e As moduleEventargs) Implements IMenuBar.ClickedModule

    Private Sub iucPowerBueroMenueBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.DesignMode Then Exit Sub
        If MainApplication.getInstance IsNot Nothing Then
            MainApplication.getInstance.Languages.SetTextOnControl(Me)
        End If

        Dim addToolTipText As String = GetText("msgClickCTRLToOpenNewwindow", "CTRL- Klick um ein neues Fenster zu öffnen")
        btnadressbook.SuperTip.Items.Add(addToolTipText)
        btnArticles.SuperTip.Items.Add(addToolTipText)
        btnBusiness.SuperTip.Items.Add(addToolTipText)
        btnCashFlow.SuperTip.Items.Add(addToolTipText)
        btnKasse.SuperTip.Items.Add(addToolTipText)
        btnLetters.SuperTip.Items.Add(addToolTipText)

    End Sub
End Class