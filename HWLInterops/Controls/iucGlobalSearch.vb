Imports DevExpress.XtraGrid.Views.Layout
Imports DevExpress.XtraGrid.Views.Grid

Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.ViewInfo

Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Services.Implementation
Imports DevExpress.XtraEditors.Controls.Rtf
Imports System.Text.RegularExpressions



''' <summary>
''' Stellt das Fenster zur Globalen Suche bereit. 
''' Enthält das Suchergebnis der Globaken Suche .
''' </summary>
''' <remarks></remarks>
Public Class iucGlobalSearch
    Implements IModule



    Private m_quertyResult As New GlobalSearch.SearchResults()
    ''' <summary>
    ''' Enthält das Muster des Ausdruckes, der in den Texten ersetzt werden soll
    ''' </summary>
    ''' <remarks></remarks>
    Private m_regex As System.Text.RegularExpressions.Regex


    Private m_searchtext As String
    ''' <summary>
    ''' Ruft den Suchtext ab oder legt diesen fest. 
    ''' Der Suchtext wird hervorgehoben dargestellt. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HighligtedSearchtext() As String
        Get
            Return m_searchtext
        End Get
        Set(ByVal value As String)
            m_searchtext = System.Text.RegularExpressions.Regex.Escape(value)

            m_regex = New System.Text.RegularExpressions.Regex(m_searchtext, System.Text.RegularExpressions.RegexOptions.CultureInvariant Or System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            m_searchActive = True
        End Set
    End Property
    ''' <summary>
    ''' Startet einen warteprozess
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub StartInfoMessageProcess()
        m_quertyResult.Clear()
        Dim t As New Threading.Thread(New Threading.ThreadStart(AddressOf StartInfoMessageProcessIntern))
        t.Name = "Wait for Data (message)"
        t.Priority = Threading.ThreadPriority.AboveNormal
        t.Start()
    End Sub


    Private Sub StartInfoMessageProcessIntern()
        Debug.Print(" Warte bis zur Meldung 'Suche...'")
        Threading.Thread.Sleep(500) ' schlafen, falls sich nichts getan hat, dann Meldung bringen
        Debug.Print(" Invoke Meldung 'Suche...'")
        Me.Invoke(New MethodInvoker(AddressOf BeginSearch))
        Debug.Print(" Suchmeldung ist raus!")
        Threading.Thread.Sleep(100)
    End Sub

    ''' <summary>
    ''' Zeigt an, das eine Suche noch aktiv ist
    ''' </summary>
    ''' <remarks></remarks>
    Private m_searchActive As Boolean

    Delegate Sub BeginSearchDele()
    Delegate Sub EndSearchDele()


    ''' <summary>
    ''' Kennzeichnet den Begin eines suchvorgangs, der eine gewisse Mindestzeit schon dauert.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BeginSearch()
        If Me.InvokeRequired Then
            Me.Invoke(New BeginSearchDele(AddressOf BeginSearch))
        Else
            If m_searchActive Then
                If grvSearchItems.RowCount = 0 Then ' Bis jetzt nichts gefudnen...
                    lblSearchHeadline.Text = GetText("msgSearchInProgress", "Suchvorgang...")
                    lblSearchHeadline.BringToFront()
                    lblSearchHeadline.Refresh()
                    Me.Refresh()
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Kennzeichnet das ende eines Suchvorganges
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndSearch()

        If Me.InvokeRequired Then
            Me.Invoke(New EndSearchDele(AddressOf EndSearch))
        Else

            m_searchActive = False
            SyncLock Me
                If grvSearchItems.RowCount = 0 Then
                    lblSearchHeadline.Text = GetText("msgNoFoundItems", "Es wurden keine Suchergebnisse gefunden.")
                Else
                    lblSearchHeadline.Visible = False
                    lblSearchHeadline.SendToBack()
                End If
                lblSearchHeadline.Refresh()
            End SyncLock
        End If

    End Sub


    ''' <summary>
    ''' stellt eine Liste der gefundenen Elemente bereit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property QueryResult() As GlobalSearch.SearchResults
        Get
            Return m_quertyResult
        End Get
    End Property

    Private Delegate Sub RefreshGridDele()
    Private m_RefreshGridDele As New RefreshGridDele(AddressOf RefreshGrid)


    Public Sub RefreshGrid()

        If Me.InvokeRequired Then
            BeginInvoke(m_RefreshGridDele)

        Else
            grdsearchItems.RefreshDataSource()

        End If

    End Sub
    Public Function CloseModule() As Boolean Implements IModule.CloseModule
        Return True
    End Function

    Public ReadOnly Property CurrentItemID() As String Implements IModule.CurrentItemID
        Get
            Return String.Empty
        End Get
    End Property

    Public Sub DeleteItem() Implements IModule.DeleteItem
        Throw New NotImplementedException("Delete not available in global Search")
    End Sub

    Public ReadOnly Property DisplayText() As String Implements IModule.DisplayText
        Get
            Return m_application.Languages.GetText("lblSearchResults", "Suchergebnisse")
        End Get
    End Property

    Public ReadOnly Property HasChanged() As Boolean Implements IModule.HasChanged
        Get
            Return False
        End Get
    End Property

    Public Sub InitializeModule() Implements IModule.InitializeModule
        grdsearchItems.DataSource = m_quertyResult
    End Sub

    Public Sub NewItem() Implements IModule.CreateNewItem

    End Sub

    ''' <summary>
    ''' Drucken der Suchergebnisse nicht implementiert
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

                grvSearchItems.RefreshRow(PrevHotTrackRow)
                grvSearchItems.RefreshRow(HotTrackRowValue)


            End If
        End Set
    End Property

    Private m_hotCardap As New DevExpress.Utils.AppearanceObject

    Private Sub Initappereances()
        m_hotCardap.BackColor = Color.AliceBlue
        m_hotCardap.BackColor2 = Color.WhiteSmoke
        m_hotCardap.GradientMode = Drawing2D.LinearGradientMode.Vertical
        m_hotCardap.ForeColor = Color.Black




    End Sub



    Private Sub GridView1_RowCellStyle(ByVal sender As Object, ByVal e As RowCellStyleEventArgs) Handles grvSearchItems.RowCellStyle
        Dim view As GridView = CType(sender, GridView)
        If view.IsRowSelected(e.RowHandle) Then ' slektionen beachten
            e.Appearance.Combine(view.Appearance.FocusedRow)
            Exit Sub
        ElseIf e.RowHandle = HotTrackRow And Not view.IsRowSelected(e.RowHandle) Then
            e.CombineAppearance(m_hotCardap)
        End If
    End Sub

    Private Sub layView_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grvSearchItems.MouseMove
        Dim View As GridView = CType(sender, GridView)
        With View.CalcHitInfo(New Point(e.X, e.Y))
            If .InRow Then
                HotTrackRow = .RowHandle
            Else
                HotTrackRow = GridControl.InvalidRowHandle
            End If
        End With
    End Sub



    Private Sub iucGlobalSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Initappereances()

    End Sub

#Region " Schlüsselwörter für eine RTF-Darstellung"
    Private m_präfix As String = "\highlight1"
    Private m_suffix As String = "\highlight0"
#End Region

    Private Sub GridView2_CustomDrawRowPreview(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles grvSearchItems.CustomDrawRowPreview

        Dim view As GridView = CType(sender, GridView)

        Using vi As New RichTextEditViewInfo(RepositoryItemRichTextEdit1)
            Dim info As GlobalSearch.SearchResult = TryCast(grvSearchItems.GetRow(e.RowHandle), GlobalSearch.SearchResult)
            If info IsNot Nothing Then
                ' Suchtext erkennen und markieren
                Dim displaytext As String
                Dim position As Integer
                ' 11 = Länge des Präfixxes, * 2 Suffix
                Dim strb As New System.Text.StringBuilder(info.Description)

                Dim m As System.Text.RegularExpressions.Match = m_regex.Match(info.Description)
                Dim matchcount As Integer = 0
                While (m.Success)
                    matchcount += 1
                    'Console.WriteLine("Match:" & (matchcount))
                    ' Console.WriteLine("Position:" & (m.Index))

                    position = m.Index + (matchcount - 1) * (m_präfix.Length + m_suffix.Length)

                    If position < 0 Then position = 0

                    If strb.Length > position Then
                        strb.Insert(position, m_präfix)
                        position += m_präfix.Length + Me.HighligtedSearchtext.Length   ' Die Länge und das Präfixx hinzufügen
                        strb.Insert(position, m_suffix)
                    End If

                    m = m.NextMatch()
                End While

                strb.Insert(0, "{\rtf1\ansi\ansicpg1252\deff0\deflang1031{\fonttbl{\f0\fnil\fcharset0 Calibri;}}" & _
                            "{\colortbl ;\red253\green253\blue176;}")
                ' RTF Header einfügen

                strb.Append("}")   ' Am Ende das RTF-Schlusszeichen einfügen

                displaytext = strb.ToString

                vi.LoadText(displaytext)


                vi.UpdatePaintAppearance()
                'Hintergrund gemäss Focus bestimmen

                vi.Appearance.Reset()
                If view.IsRowSelected(e.RowHandle) Then ' slektionen beachten
                    vi.Appearance.Assign(view.Appearance.FocusedRow)
                ElseIf e.RowHandle = HotTrackRow Then ' HotTrack beachten
                    vi.Appearance.Assign(m_hotCardap)
                End If

                ' Hier das Icon Positionieren
                Dim leftPos As Integer = colIcon.Width * 2
                Dim rec As New Rectangle(leftPos, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)

                vi.CalcViewInfo(e.Graphics, System.Windows.Forms.MouseButtons.None, New Point(0, 5), rec)

                vi.Appearance.DrawBackground(e.Cache, e.Bounds)

                DevExpress.XtraEditors.Drawing.RichTextEditPainter.DrawRTF(vi, e.Cache)
            End If

        End Using
        e.Handled = True


    End Sub

    Private Sub grdsearchItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdsearchItems.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim view As GridView = CType(grdsearchItems.FocusedView, GridView)
            ActiveSelectedItem()
        End If
    End Sub



    Private Sub grdsearchItems_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdsearchItems.MouseDoubleClick
        Dim view As GridView = CType(grdsearchItems.FocusedView, GridView)

        ' Position ermitteln
        With view.CalcHitInfo(New Point(e.X, e.Y))
            If .InRow Then
                ' Diese Row ermitteln
                ActiveSelectedItem()

            End If
        End With

    End Sub

    ''' <summary>
    ''' Öffnet ein Fenster und Zeigt das gerade focussierte Element an
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveSelectedItem()
        If Not m_searchActive Then
            Dim view As GridView = CType(grdsearchItems.FocusedView, GridView)
            Dim item As GlobalSearch.SearchResult = CType(view.GetFocusedRow, GlobalSearch.SearchResult)
            mainControlContainer.MainUI.OpenElementWindow(item.OrgItem)
        End If

    End Sub


End Class

