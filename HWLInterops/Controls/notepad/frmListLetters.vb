
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Base
Imports ClausSoftware.Kernel
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data

''' <summary>
''' stellt einen dialog bereit, der Briefe auflistet
''' </summary>
''' <remarks></remarks>
Public Class frmListLetters

    Dim m_selectedLetter As Letter

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Friend Sub Initialize()
        Try

            m_application.Letters.Reload()
            grdLettersList.DataSource = m_application.Letters
            LoadGridStyle()

        Catch ex As Exception
            m_application.UserStats.SendStatistics("ListLetters", "FAILED:" & ex.Message)
        End Try
    End Sub


    Public Sub SaveGridStyle()
        SaveGridStyles(grdLettersList, "LettersList")
    End Sub

    Public Sub LoadGridStyle()
        RestoreGridStyles(grdLettersList, "LettersList")
    End Sub

    ''' <summary>
    ''' Ruft den augenblicklich gewählten Brief ab
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property SelectedLetter() As ClausSoftware.Kernel.Letter
        Get

            Return m_selectedLetter

        End Get
    End Property

    ''' <summary>
    ''' Wird auf ein Briefe-Eibtrag doppelt geklickt, dann wird dieser gewählt und der Diaalog geschlossen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grdLettersList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdLettersList.DoubleClick

        Dim view As ColumnView = CType(grdLettersList.FocusedView, ColumnView)

        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = CType(view.CalcHitInfo(grdLettersList.PointToClient(MousePosition)), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo)
        Debug.Print(CStr(hi.HitTest))

        If hi.HitTest <> GridHitTest.ColumnEdge AndAlso hi.HitTest <> GridHitTest.Column Then
            If hi.RowHandle >= 0 Then
                m_selectedLetter = CType(view.GetRow(hi.RowHandle), Letter)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        End If
    End Sub


    Private HotTrackRowValue As Integer = GridControl.InvalidRowHandle

    Private Property HotTrackRow() As Integer
        Get
            Return HotTrackRowValue
        End Get
        Set(ByVal Value As Integer)
            If HotTrackRowValue <> Value Then
                Dim PrevHotTrackRow As Integer
                PrevHotTrackRow = HotTrackRowValue
                HotTrackRowValue = Value

                GridView1.RefreshRow(PrevHotTrackRow)
                GridView1.RefreshRow(HotTrackRowValue)

                If HotTrackRowValue >= 0 Then
                    grdLettersList.Cursor = Cursors.Hand
                Else
                    grdLettersList.Cursor = Cursors.Default
                End If
            End If
        End Set
    End Property

    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If e.RowHandle = HotTrackRow Then
            e.Appearance.BackColor = Color.PaleGoldenrod
        End If
    End Sub

    Private Sub GridView1_MouseMove(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles GridView1.MouseMove
        Dim View As GridView = CType(sender, GridView)
        With View.CalcHitInfo(New Point(e.X, e.Y))
            If .InRowCell Then
                HotTrackRow = .RowHandle
            Else
                HotTrackRow = GridControl.InvalidRowHandle
            End If
        End With
    End Sub

    Private Sub Delete()
        Dim view As ColumnView = GridView1
        If view.FocusedRowHandle > -1 Then
            m_selectedLetter = CType(view.GetRow(view.FocusedRowHandle), Letter)
            Dim textPreview As String = m_selectedLetter.Text

            If textPreview.Length > 75 Then
                textPreview = textPreview.Substring(0, 75) & "..."
            End If

            'TODO: NLS
            If MessageBox.Show("Möchten Sie den Brief Nr.:" & m_selectedLetter.DocumentID & vbCrLf & _
                               " '" & textPreview & "' " & vbCrLf & vbCrLf & _
                               "wirklich löschen?", "Brief löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.Yes Then
                m_selectedLetter.Delete()
            End If




        End If
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
    End Sub


    ''' <summary>
    ''' Kopiert die gewählten Einträge
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Copy()
        Dim view As ColumnView = GridView1
        If view.FocusedRowHandle > -1 Then
            ' diesen Brief kopieren 
            m_selectedLetter = CType(view.GetRow(view.FocusedRowHandle), Letter)

            Dim newletter As Letter = CType(m_selectedLetter.Clone, Letter)

            newletter.Save()
            m_application.Letters.Add(newletter)

            Dim newItem As Letter
            For n As Integer = 0 To GridView1.RowCount - 1
                newItem = CType(GridView1.GetRow(n), Letter)
                If newItem.Key = newletter.Key Then
                    GridView1.FocusedRowHandle = n
                    GridView1.MakeRowVisible(n, False)
                    Exit For
                End If
            Next


        End If
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Copy()
    End Sub

    Private Sub OpenSelectedItem()
        Dim view As ColumnView = GridView1

        If view.FocusedRowHandle > -1 Then
            ' diesen Brief kopieren 
            m_selectedLetter = CType(view.GetRow(view.FocusedRowHandle), Letter)

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()


        End If
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        OpenSelectedItem()
    End Sub

    Private Sub frmListLetters_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveGridStyle()
    End Sub

    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click
        OpenSelectedItem()
    End Sub

    Private Sub mnucopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucopy.Click
        Copy()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
        Delete()
    End Sub

    Private Sub frmListLetters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_application.Languages.SetTextOnControl(Me)
    End Sub
End Class