Option Explicit On
Option Strict On

''' <summary>
''' Stellt das hauptformular für den Import bereit
''' </summary>
''' <remarks></remarks>
Public Class frmMainSHKConnect

    Private WithEvents m_tradeInfo As New TradeInfo
    Private WithEvents m_companies As New CompaniesInfo

    Private m_lastSelectedTrade As Trade

    Private m_startup As Boolean = True

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        SaveLocalsettings()
        Me.Close()
    End Sub


    Private Sub SaveLocalsettings()
        ' Liste der Favoriten abspeichern  (anhand der CompanyID)
        UsersCompany.SaveFavorites()

    End Sub

    Private Sub frmMainSHKConnect_ClientSizeChanged(sender As Object, e As System.EventArgs) Handles Me.ClientSizeChanged

    End Sub

    Private Sub frmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Me.DesignMode Then
            FillTradeList()
        End If


        Initialize.Application.Settings.RestoreFormsPos(Me)

    End Sub



    ''' <summary>
    ''' Füllt die Liste der Branchen auf
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillTradeList()


        lstBranche.Items.Clear()

        lstBranche.DataSource = m_tradeInfo.TradeList

    End Sub



    Private Sub lstBranche_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstBranche.SelectedIndexChanged

        Dim selectedTrade As Trade

        If lstBranche.SelectedItem IsNot Nothing Then
            If TypeOf lstBranche.SelectedItem Is Trade Then
                selectedTrade = CType(lstBranche.SelectedItem, Trade)

                GetCompaniesBySelectedTrade(selectedTrade)
            End If

        End If

    End Sub

    Private Sub GetCompaniesBySelectedTrade(trade As Trade)
        If trade IsNot Nothing Then

            m_lastSelectedTrade = trade ' letzte Liste merken
            grdSHKConnectCompaniesList.DataSource = m_companies.GetCompanyByTradeId(trade, 5000)
        End If

    End Sub

    Private Sub picRefreshTradeList_click(sender As System.Object, e As System.EventArgs) Handles picRefreshTradeList.Click

        m_tradeInfo.Refresh() ' Listen leeren; sonst wird nichts aufgebaut
        FillTradeList()
    End Sub

    Private Sub picRefreshCompaniesList_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles picRefreshCompaniesList.EditValueChanged

        'TODO: beim Refresh die Teilliste leeren
        GetCompaniesBySelectedTrade(m_lastSelectedTrade)

    End Sub


    Private Sub Show_StatusMessage(sender As Object, e As StatusMessageEventArg) Handles m_companies.StatusMessage, m_tradeInfo.StatusMessage

        lblStatusText.Text = e.Statustext
    End Sub

    Private Sub grdCompaniesList_DoubleClick(sender As System.Object, e As System.EventArgs) Handles grdSHKConnectCompaniesList.DoubleClick
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo

        Dim p As Point = grdSHKConnectCompaniesList.PointToClient(Control.MousePosition)

        hi = CType(grdSHKConnectCompaniesList.FocusedView, DevExpress.XtraGrid.Views.Grid.GridView).CalcHitInfo(p)

        If hi.InRow Then
            Dim selectedCompany As Company = CType(grvSHKConnectCompaniesList.GetRow(hi.RowHandle), Company)
            OpenDetailsForSelectedCompany(selectedCompany)
        End If

    End Sub

    ''' <summary>
    ''' Holt Detaildaten (Links) zum Unternehen ab 
    ''' </summary>
    ''' <param name="company"></param>
    ''' <remarks></remarks>
    Private Sub OpenDetailsForSelectedCompany(company As Company)

        Try
            Dim linkLIst As List(Of ProcessLink) = m_companies.GetCompanyLinks(company)

            Dim frm As New frmSelectData
            frm.SourcesLinkList.Clear()
            frm.SourcesLinkList.AddRange(linkLIst)
            linkLIst.Clear()

            frm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Ein Problem ist aufgetreten beim holen der Unternehmensdaten:" & Environment.NewLine & _
                            ex.Message, "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private m_needsPosSave As Boolean

    Private Sub frmMainSHKConnect_LocationChanged(sender As Object, e As System.EventArgs) Handles Me.LocationChanged
        If Not m_startup Then
            m_needsPosSave = True
        End If
    End Sub

    Private Sub frmMainSHKConnect_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If m_needsPosSave Then
            m_needsPosSave = False
            Initialize.Application.Settings.SaveFormsPos(Me)
        End If
    End Sub


    Private Sub frmMain_ResizeEnd(sender As Object, e As System.EventArgs) Handles Me.ResizeEnd
        If Not m_startup Then
            Initialize.Application.Settings.SaveFormsPos(Me)
        End If
    End Sub

    Private Sub frmMainSHKConnect_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        m_startup = False
    End Sub

    Private Sub btnStartImport_Click(sender As System.Object, e As System.EventArgs) Handles btnStartImport.Click

    End Sub

    Private Sub repFavoriteCheckbox_CheckStateChanged(sender As Object, e As System.EventArgs) Handles repFavoriteCheckbox.CheckStateChanged

        SaveLocalsettings()
    End Sub

    Private Sub btnEditAccessData_Click(sender As System.Object, e As System.EventArgs) Handles btnEditAccessData.Click

        Dim selectedCompany As UsersCompany = TryCast(grvSHKConnectCompaniesList.GetFocusedRow, UsersCompany)
        If selectedCompany IsNot Nothing Then

            Using frm As New frmEnterCompanyCredentials
                frm.Credentials = selectedCompany.Credential
                frm.CredentialCompanyName = selectedCompany.Name

                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

                    selectedCompany.Credential = frm.Credentials

                    m_companies.SaveCache() ' geänderte Daten direkt wieder speichern
                End If
            End Using

        End If

    End Sub
End Class
