Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging



Namespace TextRuler.TextRulerControl
    Partial Friend Class TextRuler
        Inherits UserControl

#Region "Variables"
        'control dimensions
        Private [me] As New RectangleF()
        'drawzone area
        Private drawZone As New RectangleF()
        'area which is bounded by margins
        Private workArea As New RectangleF()
        'items of the ruler
        Private items As New List(Of RectangleF)()
        'tab stops
        Private tabs As New List(Of RectangleF)()
        'pen to draw with
        Private p As New Pen(Color.Transparent)
        'margins and indents in pixels (that is why float)
        Private lMargin As Integer = 20, rMargin As Integer = 15, llIndent As Integer = 20, luIndent As Integer = 20, rIndent As Integer = 15
        'border color
        Private _strokeColor As Color = Color.Black
        'background color
        Private _baseColor As Color = Color.White
        'position
        Private pos As Integer = -1
        'indicates if mouse button is being pressed and object is captured
        Private mCaptured As Boolean = False
        'indicates if margins are used
        Private m_noMargins As Boolean = False
        'index of the captured object
        Private capObject As Integer = -1, capTab As Integer = -1
        'are tabs enabled?
        Private _tabsEnabled As Boolean = False

        'value which represents dots per millimiter in current system
        Private dotsPermm As Single

        Friend Enum ControlItems
            LeftIndent
            LeftHangingIndent
            RightIndent
            LeftMargin
            RightMargin
        End Enum

#Region "Events declarations"
        Public Delegate Sub IndentChangedEventHandler(ByVal NewValue As Integer)
        Public Delegate Sub MultiIndentChangedEventHandler(ByVal LeftIndent As Integer, ByVal HangIndent As Integer)
        Public Delegate Sub MarginChangedEventHandler(ByVal NewValue As Integer)
        Public Delegate Sub TabChangedEventHandler(ByVal args As TabEventArgs)

        Public Event LeftHangingIndentChanging As IndentChangedEventHandler
        Public Event LeftIndentChanging As IndentChangedEventHandler
        Public Event RightIndentChanging As IndentChangedEventHandler
        Public Event BothLeftIndentsChanged As MultiIndentChangedEventHandler

        Public Event LeftMarginChanging As MarginChangedEventHandler
        Public Event RightMarginChanging As MarginChangedEventHandler

        Public Event TabAdded As TabChangedEventHandler
        Public Event TabRemoved As TabChangedEventHandler
        Public Event TabChanged As TabChangedEventHandler

#End Region

#End Region

#Region "Constructor"
        Private Sub InitializeComponent()
            Me.SuspendLayout()
            ' 
            ' TextRuler
            ' 
            Me.Name = "TextRuler"
            Me.Size = New System.Drawing.Size(100, 20)
            Me.ResumeLayout(False)

        End Sub

        Public Sub New()
            Me.SetStyle(ControlStyles.UserPaint, True)
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            Me.BackColor = Color.Transparent
            Me.Font = New Font("Arial", 7.25F)

            tabs.Clear()

            'margins and indents
            items.Add(New RectangleF())
            items.Add(New RectangleF())
            items.Add(New RectangleF())
            items.Add(New RectangleF())
            items.Add(New RectangleF())
            items.Add(New RectangleF())
            items.Add(New RectangleF())

            '
            '             * items[0] - left margin
            '             * items[1] - right margin
            '             * items[2] - left indent upper mark
            '             * items[3] - left indent lower mark (picture region)
            '             * items[4] - right indent mark
            '             * items[5] - left indent mark (self-moving region)
            '             * items[6] - left indent mark (all-moving region)
            '            


            
        End Sub
#End Region

#Region "Painting"
        Private Sub DrawBackGround(ByVal g As Graphics)
            'clear background
            p.Color = Color.Transparent
            g.FillRectangle(p.Brush, [me])

            'fill background
            p.Color = _baseColor
            g.FillRectangle(p.Brush, drawZone)
        End Sub

        Private Sub DrawMargins(ByVal g As Graphics)
            items(0) = New RectangleF(0.0F, 3.0F, lMargin * dotsPermm, 14.0F)
            items(1) = New RectangleF(drawZone.Width - (CSng(rMargin) * dotsPermm) + 1.0F, 3.0F, rMargin * dotsPermm + 5.0F, 14.0F)
            p.Color = Color.DarkGray
            g.FillRectangle(p.Brush, items(0))
            g.FillRectangle(p.Brush, items(1))

            g.PixelOffsetMode = PixelOffsetMode.None
            'draw border
            p.Color = _strokeColor
            g.DrawRectangle(p, 0, 3, [me].Width - 1, 14)
        End Sub

        Private Sub DrawTextAndMarks(ByVal g As Graphics)
            Dim points As Integer = CInt((drawZone.Width / dotsPermm) / 10)
            Dim range As Single = 5 * dotsPermm
            Dim i As Integer = 0
            p.Color = Color.Black
            Dim sz As SizeF
            For i = 0 To points * 2 + 1
                If i Mod 2 = 0 AndAlso i <> 0 Then
                    sz = g.MeasureString((Convert.ToInt32(i / 2)).ToString(), Me.Font)
                    g.DrawString((Convert.ToInt32(i / 2)).ToString(), Me.Font, p.Brush, New PointF(CSng((i * range - CSng((sz.Width / 2)))), CSng(([me].Height / 2)) - CSng((sz.Height / 2))))
                Else
                    g.DrawLine(p, CSng((i * range)), 7.0F, CSng((i * range)), 12.0F)
                End If
            Next
            g.PixelOffsetMode = PixelOffsetMode.Half
        End Sub

        Private Sub DrawIndents(ByVal g As Graphics)
            items(2) = New RectangleF(CSng(luIndent) * dotsPermm - 4.5F, 0.0F, 9.0F, 8.0F)
            items(3) = New RectangleF(CSng(llIndent) * dotsPermm - 4.5F, 8.2F, 9.0F, 11.8F)
            items(4) = New RectangleF(CSng((drawZone.Width - (CSng(rIndent) * dotsPermm - 4.5F) - 7.0F)), 11.0F, 9.0F, 8.0F)

            'regions for moving left indentation marks
            items(5) = New RectangleF(CSng(llIndent) * dotsPermm - 4.5F, 8.2F, 9.0F, 5.9F)
            items(6) = New RectangleF(CSng(llIndent) * dotsPermm - 4.5F, 14.1F, 9.0F, 5.9F)

            g.DrawImage(My.Resources.rtfResource.l_indet_pos_upper, items(2))
            g.DrawImage(My.Resources.rtfResource.l_indent_pos_lower, items(3))
            g.DrawImage(My.Resources.rtfResource.r_indent_pos, items(4))
        End Sub

        Private Sub DrawTabs(ByVal g As Graphics)
            If _tabsEnabled = False Then
                Return
            End If

            Dim i As Integer = 0

            If tabs.Count = 0 Then
                Return
            End If
            For i = 0 To tabs.Count - 1

                g.DrawImage(My.Resources.rtfResource.tab_pos, tabs(i))
            Next
        End Sub
#End Region

#Region "Actions"
        Private Sub AddTab(ByVal pos As Single)
            Dim rect As New RectangleF(pos, 10.0F, 8.0F, 8.0F)
            tabs.Add(rect)

            RaiseEvent TabAdded(CreateTabArgs(pos))

        End Sub

        ''' <summary>
        ''' Returns List which contains positions of the tabs converted to millimeters.
        ''' </summary>
        Public ReadOnly Property TabPositions() As List(Of Integer)
            Get
                Dim lst As New List(Of Integer)()
                Dim i As Integer = 0
                For i = 0 To tabs.Count - 1
                    lst.Add(CInt((tabs(i).X / dotsPermm)))
                Next
                lst.Sort()
                Return lst
            End Get
        End Property

        ''' <summary>
        ''' Returns List which contains positions of the tabs in pixels.
        ''' </summary>
        Public ReadOnly Property TabPositionsInPixels() As List(Of Integer)
            Get
                Dim lst As New List(Of Integer)()
                Dim i As Integer = 0
                For i = 0 To tabs.Count - 1
                    lst.Add(CInt((tabs(i).X)))
                Next
                lst.Sort()
                Return lst
            End Get
        End Property

        ''' <summary>
        ''' Sets positions for tabs. It uses positions represented in pixels.
        ''' </summary>
        ''' <param name="positions"></param>
        Public Sub SetTabPositionsInPixels(ByVal positions As Integer())
            If positions Is Nothing Then
                tabs.Clear()
            Else
                tabs.Clear()
                Dim i As Integer = 0
                For i = 0 To positions.Length - 1
                    Dim rect As New RectangleF(Convert.ToSingle(positions(i)), 10.0F, 8.0F, 8.0F)
                    tabs.Add(rect)
                Next
            End If
            Me.Refresh()
        End Sub

        ''' <summary>
        ''' Sets positions for tabs. It uses positions represented in millemeters.
        ''' </summary>
        ''' <param name="positions"></param>
        Public Sub SetTabPositionsInMillimeters(ByVal positions As Integer())
            If positions Is Nothing Then
                tabs.Clear()
            Else
                tabs.Clear()
                Dim i As Integer = 0
                Dim rect As RectangleF
                For i = 0 To positions.Length - 1
                    If positions(i) <> 0 Then
                        rect = New RectangleF(positions(i) * dotsPermm, 10.0F, 8.0F, 8.0F)
                        tabs.Add(rect)
                    End If
                Next
                Me.Refresh()
            End If
        End Sub

        Friend Function GetValueInPixels(ByVal item As ControlItems) As Integer
            Select Case item
                Case ControlItems.LeftIndent
                    Return CInt((luIndent * dotsPermm))
                Case ControlItems.LeftHangingIndent

                    Return CInt((llIndent * dotsPermm))
                Case ControlItems.RightIndent

                    Return CInt((rIndent * dotsPermm))
                Case ControlItems.LeftMargin

                    Return CInt((lMargin * dotsPermm))
                Case ControlItems.RightMargin

                    Return CInt((rMargin * dotsPermm))
                Case Else

                    Return 0

            End Select
        End Function

        Public ReadOnly Property DotsPerMillimeter() As Single
            Get
                Return dotsPermm
            End Get
        End Property
#End Region

#Region "Properties"
        ''' <summary>
        ''' Gets or sets color for the border
        ''' </summary>
        <DefaultValue(GetType(Color), "Black")> _
        <Description("Color of the border drawn on the bounds of control.")> _
        Public Property BorderColor() As Color
            Get
                Return _strokeColor
            End Get
            Set(ByVal value As Color)
                _strokeColor = value
                Me.Refresh()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets color for the background
        ''' </summary>
        <DefaultValue(GetType(Color), "White")> _
        <Description("Base color for the control.")> _
        Public Property BaseColor() As Color
            Get
                Return _baseColor
            End Get
            Set(ByVal value As Color)
                _baseColor = value
            End Set
        End Property

        ''' <summary>
        ''' Enables or disables usage of the margins. If disabled, margins values are set to 1.
        ''' </summary>
        <Category("Margins")> _
        <Description("If true Margins are disabled, otherwise, false.")> _
        <DefaultValue(False)> _
        Public Property NoMargins() As Boolean
            Get
                Return m_noMargins
            End Get
            Set(ByVal value As Boolean)
                m_noMargins = value
                If value = True Then
                    Me.lMargin = 1
                    Me.rMargin = 1
                End If
                Me.Refresh()
            End Set
        End Property

        ''' <summary>
        ''' Specifies left margin
        ''' </summary>
        <Category("Margins")> _
        <Description("Gets or sets left margin. This value is in millimeters.")> _
        <DefaultValue(20)> _
        Public Property LeftMargin() As Integer
            Get
                Return lMargin
            End Get
            Set(ByVal value As Integer)
                If m_noMargins <> True Then
                    lMargin = value
                End If
                Me.Refresh()
            End Set
        End Property

        ''' <summary>
        ''' Specifies right margin
        ''' </summary>
        <Category("Margins")> _
        <Description("Gets or sets right margin. This value is in millimeters.")> _
        <DefaultValue(15)> _
        Public Property RightMargin() As Integer
            Get
                Return rMargin
            End Get
            Set(ByVal value As Integer)
                If m_noMargins <> True Then
                    rMargin = value
                End If
                Me.Refresh()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets indentation of the first line of the paragraph
        ''' </summary>
        <Category("Indents")> _
        <Description("Gets or sets left hanging indent. This value is in millimeters.")> _
        <DefaultValue(20)> _
        Public Property LeftHangingIndent() As Integer
            Get
                Return llIndent - 1
            End Get
            Set(ByVal value As Integer)
                llIndent = value + 1
                Me.Refresh()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets indentation from the left of the base text of the paragraph
        ''' </summary>
        <Category("Indents")> _
        <Description("Gets or sets left indent. This value is in millimeters.")> _
        <DefaultValue(20)> _
        Public Property LeftIndent() As Integer
            Get
                Return luIndent - 1
            End Get
            Set(ByVal value As Integer)
                luIndent = value + 1
                Me.Refresh()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets right indentation of the paragraph
        ''' </summary>
        <Category("Indents")> _
        <Description("Gets or sets right indent. This value is in millimeters.")> _
        <DefaultValue(15)> _
        Public Property RightIndent() As Integer
            Get
                Return rIndent - 1
            End Get
            Set(ByVal value As Integer)
                rIndent = value + 1
                Me.Refresh()
            End Set
        End Property

        <Category("Tabulation")> _
        <Description("True to display tab stops, otherwise, False")> _
        <DefaultValue(False)> _
        Public Property TabsEnabled() As Boolean
            Get
                Return _tabsEnabled
            End Get
            Set(ByVal value As Boolean)
                _tabsEnabled = value
                Me.Refresh()
            End Set
        End Property
#End Region

#Region "Overriders"
        Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            'set compositing to high quality because of using images for indents
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality

            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            'make smooth control
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            'this will braw smoother control, without blur and fast ;).
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half
            'this will braw text with highest quality
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

            [me] = New RectangleF(0.0F, 0.0F, CSng(Me.Width), CSng(Me.Height))
            drawZone = New RectangleF(1.0F, 3.0F, [me].Width - 2.0F, 14.0F)
            workArea = New RectangleF(CSng(lMargin) * dotsPermm, 3.0F, drawZone.Width - (CSng(rMargin) * dotsPermm) - drawZone.X * 2, 14.0F)

            'firstly, draw background.
            DrawBackGround(e.Graphics)

            'then, draw margins
            DrawMargins(e.Graphics)

            'then, draw text (numbers) and marks (vertical lines)
            DrawTextAndMarks(e.Graphics)

            'then, draw indent marks
            DrawIndents(e.Graphics)

            'finally, draw tab stops
            DrawTabs(e.Graphics)
        End Sub

        Protected Overloads Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)
            Me.Height = 20
        End Sub

        Protected Overloads Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            Dim i As Integer = 0

            mCaptured = False

            'process left mouse button only
            If e.Button <> MouseButtons.Left Then
                Return
            End If
            For i = 0 To 6

                If items(i).Contains(e.Location) = True AndAlso i <> 3 Then
                    'i must not be equal to 3, as this is region for whole image
                    If m_noMargins = True AndAlso (i = 0 OrElse i = 1) Then
                        Exit For
                    End If

                    capObject = i
                    mCaptured = True
                    Exit For
                End If
            Next

            If mCaptured = True Then
                Return
            End If

            If tabs.Count = 0 Then
                Return
            End If

            If _tabsEnabled = False Then
                Return
            End If

            i = 0
            For i = 0 To tabs.Count - 1

                If tabs(i).Contains(e.Location) = True Then
                    capTab = i
                    pos = CInt((tabs(i).X / dotsPermm))
                    mCaptured = True
                    Exit For
                End If
            Next

        End Sub

        Protected Overloads Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MyBase.OnMouseUp(e)

            'process left mouse button only
            If e.Button <> MouseButtons.Left Then
                Return
            End If

            If workArea.Contains(e.Location) = False Then
                If mCaptured = True AndAlso capTab <> -1 AndAlso _tabsEnabled = True Then
                    Try
                        Dim pos As Single = tabs(capTab).X * dotsPermm
                        tabs.RemoveAt(capTab)

                        RaiseEvent TabRemoved(CreateTabArgs(pos))

                    Catch generatedExceptionName As Exception
                    End Try
                End If
            ElseIf workArea.Contains(e.Location) = True Then
                If mCaptured <> True AndAlso _tabsEnabled = True Then
                    AddTab(CSng(e.Location.X))
                ElseIf mCaptured = True AndAlso capTab <> -1 Then
                    If _tabsEnabled = True Then
                        RaiseEvent TabChanged(CreateTabArgs(e.Location.X))
                    End If
                End If
            End If

            capTab = -1
            mCaptured = False
            capObject = -1
            Me.Refresh()
        End Sub

        Protected Overloads Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            If mCaptured = True AndAlso capObject <> -1 Then
                Select Case capObject
                    Case 0
                        If m_noMargins = True Then
                            Return
                        End If
                        If e.Location.X <= CInt(([me].Width - rMargin * dotsPermm - 35.0F)) Then
                            Me.lMargin = CInt((e.Location.X / dotsPermm))
                            If Me.lMargin < 1 Then
                                Me.lMargin = 1
                            End If

                            RaiseEvent LeftMarginChanging(lMargin)

                            Me.Refresh()
                        End If
            Exit Select
                    Case 1

                        If m_noMargins = True Then
                            Return
                        End If
                        If e.Location.X >= CInt((lMargin * dotsPermm + 35.0F)) Then
                            Me.rMargin = CInt(((drawZone.Width / dotsPermm) - CInt((e.Location.X / dotsPermm))))
                            If Me.rMargin < 1 Then
                                Me.rMargin = 1
                            End If

                            RaiseEvent RightMarginChanging(rMargin)

                            Me.Refresh()
                        End If
            Exit Select
                    Case 2

                        If e.Location.X <= CInt(([me].Width - rIndent * dotsPermm - 35.0F)) Then
                            Me.luIndent = CInt((e.Location.X / dotsPermm))
                            If Me.luIndent < 1 Then
                                Me.luIndent = 1
                            End If
                            RaiseEvent LeftIndentChanging(luIndent - 1)
                            Me.Refresh()
                        End If
            Exit Select
                    Case 4


                        If e.Location.X >= CInt((Math.Max(llIndent, luIndent) * dotsPermm + 35.0F)) Then
                            Me.rIndent = CInt((([me].Width / dotsPermm) - CInt((e.Location.X / dotsPermm))))
                            If Me.rIndent < 1 Then
                                Me.rIndent = 1
                            End If
                            RaiseEvent RightIndentChanging(rIndent - 1)
                            Me.Refresh()
                        End If
            Exit Select
                    Case 5

                        If e.Location.X <= CInt((drawZone.Width - rIndent * dotsPermm - 35.0F)) Then
                            Me.llIndent = CInt((e.Location.X / dotsPermm))
                            If Me.llIndent < 1 Then
                                Me.llIndent = 1
                            End If
                            RaiseEvent LeftHangingIndentChanging(llIndent - 1)
                            Me.Refresh()
                        End If
            Exit Select
                    Case 6

                        If e.Location.X <= CInt((drawZone.Width - rIndent * dotsPermm - 35.0F)) Then
                            Me.luIndent = luIndent + CInt((e.Location.X / dotsPermm)) - llIndent
                            Me.llIndent = CInt((e.Location.X / dotsPermm))
                            If Me.llIndent < 1 Then
                                Me.llIndent = 1
                            End If
                            If Me.luIndent < 1 Then
                                Me.luIndent = 1
                            End If

                            RaiseEvent BothLeftIndentsChanged(luIndent - 1, llIndent - 1)
                            Me.Refresh()
                        End If
            Exit Select

                End Select
            ElseIf mCaptured = True AndAlso capTab <> -1 Then
                If workArea.Contains(e.Location) = True Then
                    tabs(capTab) = New RectangleF(CSng(e.Location.X), tabs(capTab).Y, tabs(capTab).Width, tabs(capTab).Height)
                    Me.Refresh()
                End If
            Else
                Dim i As Integer = 0
                For i = 0 To 4

                    If items(i).Contains(e.Location) = True Then
                        Select Case i
                            Case 0
                                If m_noMargins = True Then
                                    Return
                                End If
                                Cursor = Cursors.SizeWE
                                Exit Select
                            Case 1

                                If m_noMargins = True Then
                                    Return
                                End If
                                Cursor = Cursors.SizeWE
                                Exit Select
                        End Select
                        Exit For
                    End If
                    Me.Cursor = Cursors.[Default]
                Next
            End If

        End Sub
#End Region

#Region "Events classes"
        Friend Class TabEventArgs
            Inherits EventArgs
            Private _posN As Integer = -1
            Private _posO As Integer = -1

            Friend Property NewPosition() As Integer
                Get
                    Return _posN
                End Get
                Set(ByVal value As Integer)
                    _posN = value
                End Set
            End Property

            Friend Property OldPosition() As Integer
                Get
                    Return _posO
                End Get
                Set(ByVal value As Integer)
                    _posO = value
                End Set
            End Property
        End Class

        Private Function CreateTabArgs(ByVal newPos As Single) As TabEventArgs
            Dim tae As New TabEventArgs()
            tae.NewPosition = CInt((newPos / dotsPermm))
            tae.OldPosition = pos
            Return tae
        End Function

#End Region

        Private Sub TextRuler_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize


            Using g As Graphics = Graphics.FromHwnd(Me.Handle)
                dotsPermm = g.DpiX / 25.4F
            End Using

        End Sub
    End Class
End Namespace

