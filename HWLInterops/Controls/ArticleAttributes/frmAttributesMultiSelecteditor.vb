Imports ClausSoftware.Kernel.Attributes


''' <summary>
''' Stellt einen Dialog da, in dem eine Liste mit Auswahltypen Werte zugewiesen werden können
''' </summary>
''' <remarks></remarks>
Public Class frmAttributesMultiSelecteditor

    Private m_selectores As Kernel.Attributes.MultiSelectProfiles
    Private m_values As New System.Data.DataTable



    Private m_selectedProfile As MultiSelectProfile

    ''' <summary>
    ''' Ruft das Profil ab, das selektiert wurde oder legvt es fest
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectedProfile() As MultiSelectProfile
        Get
            Return m_selectedProfile
        End Get
        Set(ByVal value As MultiSelectProfile)
            m_selectedProfile = value
        End Set
    End Property

    Private Sub frmAttributesMultiSelecteditor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If m_application IsNot Nothing Then
            m_application.Settings.SaveFormsPos(Me)
        End If
    End Sub


    Private Sub frmAttributesMultiSelecteditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        m_selectores = New Kernel.Attributes.MultiSelectProfiles(m_application)

        grdSelector.DataSource = m_selectores
        m_application.Languages.SetTextOnControl(Me)
        m_application.Settings.RestoreFormsPos(Me)

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        
        DialogResult = Windows.Forms.DialogResult.OK

        m_selectores.Save() ' 
        Me.SelectedProfile = CType(grvSelector.GetFocusedRow, MultiSelectProfile)
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        m_selectores.Save() ' alle Profile und alle Werte Speichern.. 
        'was ist mit gelöschten ? 

    End Sub

    Private Sub grvSelector_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grvSelector.FocusedRowChanged

        ' Die werte des Focusssierten Profiles einlesen
        If e.FocusedRowHandle >= 0 Then
            Dim profile As Kernel.Attributes.MultiSelectProfile = CType(grvSelector.GetRow(e.FocusedRowHandle), Kernel.Attributes.MultiSelectProfile)
            If profile IsNot Nothing Then
                grdValues.DataSource = profile.GetValueList
            End If
        End If

    End Sub

    Private Sub grvSelector_SelectionChanged(ByVal sender As System.Object, ByVal e As DevExpress.Data.SelectionChangedEventArgs) Handles grvSelector.SelectionChanged

    End Sub

    Private Sub frmAttributesMultiSelecteditor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If SelectedProfile IsNot Nothing Then
            For itemNr As Integer = 0 To grvSelector.RowCount - 1
                Dim item As MultiSelectProfile = CType(grvSelector.GetRow(itemNr), MultiSelectProfile)
                If item.Key.Equals(SelectedProfile.Key) Then
                    grvSelector.FocusedRowHandle = itemNr
                    Exit For
                End If
            Next


        End If
    End Sub
End Class