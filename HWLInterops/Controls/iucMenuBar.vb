

''' <summary>
''' Stellt einen Verteiler für die StammMenüs zur Verfügung
''' </summary>
''' <remarks></remarks>
Public Class iucMenuBar
    Implements IMenuBar

    Public Event ClickedModule(ByVal sender As Object, ByVal e As moduleEventargs) Implements IMenuBar.ClickedModule

    Public Delegate Sub delSelectedModuleChanged(ByVal key As HWLModules)
    Public Event SelectedModuleChanged As delSelectedModuleChanged


    Private Sub RaiseEvents(ByVal callingModule As HWLModules)
        Try
            RaiseEvent SelectedModuleChanged(callingModule)
            RaiseEvent ClickedModule(Me, New moduleEventargs(callingModule))
        Catch
        End Try
    End Sub


    Private Sub iucMenuBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DesignMode Then Exit Sub
        If MainApplication.getInstance IsNot Nothing Then
            MainApplication.getInstance.Languages.SetTextOnControl(Me)
        End If

        Dim addToolTipText As String = GetText("msgClickCTRLToOpenNewwindow", "CTRL- Klick um ein neues Fenster zu öffnen")
        cmdAdressbook.SuperTip.Items.Add(addToolTipText)
        cmdArticles.SuperTip.Items.Add(addToolTipText)
        cmdBusiness.SuperTip.Items.Add(addToolTipText)
        cmdCashFlow.SuperTip.Items.Add(addToolTipText)
        cmdKasse.SuperTip.Items.Add(addToolTipText)
        cmdLetters.SuperTip.Items.Add(addToolTipText)


    End Sub

    Private Sub cmdAdressbook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdressbook.Click
        RaiseEvents(HWLModules.Adressbook)
    End Sub


    Private Sub cmdArticles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArticles.Click
        RaiseEvents(HWLModules.Articles)
    End Sub

    Private Sub cmdBusiness_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBusiness.Click
        RaiseEvents(HWLModules.Business)
    End Sub

    Private Sub cmdCashFlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCashFlow.Click
        RaiseEvents(HWLModules.Transactions)
    End Sub

    Private Sub cmdKasse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKasse.Click
        RaiseEvents(HWLModules.CashJournal)
    End Sub

    Private Sub cmdLetters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLetters.Click
        RaiseEvents(HWLModules.Letters)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Try
            RaiseEvents(HWLModules.ExitApp)
        Catch
            ' nichts tun; es wird eh' beendet
        End Try
    End Sub

    Private Sub btnScheduler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScheduler.Click
        RaiseEvents(HWLModules.Scheduler)
    End Sub



End Class