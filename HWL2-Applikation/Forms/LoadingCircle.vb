'
' Copyright ©2006, 2007, Martin R. Gagné (martingagne@gmail.com)
' All rights reserved.
'
' Redistribution and use in source and binary forms, with or without modification, 
' are permitted provided that the following conditions are met:
'
'   - Redistributions of source code must retain the above copyright notice, 
'     this list of conditions and the following disclaimer.
'
'   - Redistributions in binary form must reproduce the above copyright notice, 
'     this list of conditions and the following disclaimer in the documentation 
'     and/or other materials provided with the distribution.
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
' ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
' IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
' INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
' NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
' OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
' WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
' ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
' OF SUCH DAMAGE.
'

Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Namespace MRG.Controls.UI
    <DebuggerStepThrough()> _
    Public Class LoadingCircle
        Inherits UserControl
        ' Constants =========================================================
        Private Const NumberOfDegreesInCircle As Double = 360
        Private Const NumberOfDegreesInHalfCircle As Double = NumberOfDegreesInCircle / 2
        Private Const DefaultInnerCircleRadius As Integer = 8
        Private Const DefaultOuterCircleRadius As Integer = 10
        Private Const DefaultNumberOfSpoke As Integer = 10
        Private Const DefaultSpokeThickness As Integer = 4
        Private ReadOnly DefaultColor As Color = Color.DarkGray

        Private Const MacOSXInnerCircleRadius As Integer = 5
        Private Const MacOSXOuterCircleRadius As Integer = 11
        Private Const MacOSXNumberOfSpoke As Integer = 12
        Private Const MacOSXSpokeThickness As Integer = 2

        Private Const FireFoxInnerCircleRadius As Integer = 6
        Private Const FireFoxOuterCircleRadius As Integer = 7
        Private Const FireFoxNumberOfSpoke As Integer = 9
        Private Const FireFoxSpokeThickness As Integer = 4

        Private Const IE7InnerCircleRadius As Integer = 8
        Private Const IE7OuterCircleRadius As Integer = 9
        Private Const IE7NumberOfSpoke As Integer = 24
        Private Const IE7SpokeThickness As Integer = 4

        ' Enumeration =======================================================
        Public Enum StylePresets
            MacOSX
            Firefox
            IE7
            [Custom]
        End Enum

        ' Attributes ========================================================
        Private m_Timer As Timer
        Private m_IsTimerActive As Boolean
        Private m_NumberOfSpoke As Integer
        Private m_SpokeThickness As Integer
        Private m_ProgressValue As Integer
        Private m_OuterCircleRadius As Integer
        Private m_InnerCircleRadius As Integer
        Private m_CenterPoint As PointF
        Private m_Color As Color
        Private m_Colors As Color()
        Private m_Angles As Double()
        Private m_StylePreset As StylePresets

        ' Properties ========================================================
        ''' <summary>
        ''' Gets or sets the lightest color of the circle.
        ''' </summary>
        ''' <value>The lightest color of the circle.</value>
        <TypeConverter("System.Drawing.ColorConverter"), Category("LoadingCircle"), Description("Sets the color of spoke.")> _
        Public Property Color() As Color
            Get
                Return m_Color
            End Get
            Set(ByVal value As Color)
                m_Color = value

                GenerateColorsPallet()
                Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the outer circle radius.
        ''' </summary>
        ''' <value>The outer circle radius.</value>
        <Description("Gets or sets the radius of outer circle."), Category("LoadingCircle")> _
        Public Property OuterCircleRadius() As Integer
            Get
                If m_OuterCircleRadius = 0 Then
                    m_OuterCircleRadius = DefaultOuterCircleRadius
                End If

                Return m_OuterCircleRadius
            End Get
            Set(ByVal value As Integer)
                m_OuterCircleRadius = value
                Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the inner circle radius.
        ''' </summary>
        ''' <value>The inner circle radius.</value>
        <Description("Gets or sets the radius of inner circle."), Category("LoadingCircle")> _
        Public Property InnerCircleRadius() As Integer
            Get
                If m_InnerCircleRadius = 0 Then
                    m_InnerCircleRadius = DefaultInnerCircleRadius
                End If

                Return m_InnerCircleRadius
            End Get
            Set(ByVal value As Integer)
                m_InnerCircleRadius = value
                Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the number of spoke.
        ''' </summary>
        ''' <value>The number of spoke.</value>
        <Description("Gets or sets the number of spoke."), Category("LoadingCircle")> _
        Public Property NumberSpoke() As Integer
            Get
                If m_NumberOfSpoke = 0 Then
                    m_NumberOfSpoke = DefaultNumberOfSpoke
                End If

                Return m_NumberOfSpoke
            End Get
            Set(ByVal value As Integer)
                If m_NumberOfSpoke <> value AndAlso m_NumberOfSpoke > 0 Then
                    m_NumberOfSpoke = value
                    GenerateColorsPallet()
                    GetSpokesAngles()

                    Invalidate()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a value indicating whether this <see cref="T:LoadingCircle"/> is active.
        ''' </summary>
        ''' <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        <Description("Gets or sets the number of spoke."), Category("LoadingCircle")> _
        Public Property Active() As Boolean
            Get
                Return m_IsTimerActive
            End Get
            Set(ByVal value As Boolean)
                m_IsTimerActive = value
                ActiveTimer()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the spoke thickness.
        ''' </summary>
        ''' <value>The spoke thickness.</value>
        <Description("Gets or sets the thickness of a spoke."), Category("LoadingCircle")> _
        Public Property SpokeThickness() As Integer
            Get
                If m_SpokeThickness <= 0 Then
                    m_SpokeThickness = DefaultSpokeThickness
                End If

                Return m_SpokeThickness
            End Get
            Set(ByVal value As Integer)
                m_SpokeThickness = value
                Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the rotation speed.
        ''' </summary>
        ''' <value>The rotation speed.</value>
        <Description("Gets or sets the rotation speed. Higher the slower."), Category("LoadingCircle")> _
        Public Property RotationSpeed() As Integer
            Get
                Return m_Timer.Interval
            End Get
            Set(ByVal value As Integer)
                If value > 0 Then
                    m_Timer.Interval = value
                End If
            End Set
        End Property

        ''' <summary>
        ''' Quickly sets the style to one of these presets, or a custom style if desired
        ''' </summary>
        ''' <value>The style preset.</value>
        <Category("LoadingCircle"), Description("Quickly sets the style to one of these presets, or a custom style if desired"), DefaultValue(GetType(StylePresets), "Custom")> _
        Public Property StylePreset() As StylePresets
            Get
                Return m_StylePreset
            End Get
            Set(ByVal value As StylePresets)
                m_StylePreset = value

                Select Case m_StylePreset
                    Case StylePresets.MacOSX
                        SetCircleAppearance(MacOSXNumberOfSpoke, MacOSXSpokeThickness, MacOSXInnerCircleRadius, MacOSXOuterCircleRadius)
                        Exit Select
                    Case StylePresets.Firefox
                        SetCircleAppearance(FireFoxNumberOfSpoke, FireFoxSpokeThickness, FireFoxInnerCircleRadius, FireFoxOuterCircleRadius)
                        Exit Select
                    Case StylePresets.IE7
                        SetCircleAppearance(IE7NumberOfSpoke, IE7SpokeThickness, IE7InnerCircleRadius, IE7OuterCircleRadius)
                        Exit Select
                    Case StylePresets.[Custom]
                        SetCircleAppearance(DefaultNumberOfSpoke, DefaultSpokeThickness, DefaultInnerCircleRadius, DefaultOuterCircleRadius)
                        Exit Select
                End Select
            End Set
        End Property

        ' Construtor ========================================================
        ''' <summary>
        ''' Initializes a new instance of the <see cref="T:LoadingCircle"/> class.
        ''' </summary>
        Public Sub New()
            SetStyle(ControlStyles.UserPaint, True)
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            SetStyle(ControlStyles.ResizeRedraw, True)
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)

            m_Color = DefaultColor

            GenerateColorsPallet()
            GetSpokesAngles()
            GetControlCenterPoint()

            m_Timer = New Timer()
            AddHandler m_Timer.Tick, AddressOf aTimer_Tick
            ActiveTimer()

            AddHandler Me.Resize, AddressOf LoadingCircle_Resize
        End Sub

        ' Events ============================================================
        ''' <summary>
        ''' Handles the Resize event of the LoadingCircle control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        Private Sub LoadingCircle_Resize(ByVal sender As Object, ByVal e As EventArgs)
            GetControlCenterPoint()
        End Sub

        ''' <summary>
        ''' Handles the Tick event of the aTimer control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        Private Sub aTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
            m_ProgressValue = System.Threading.Interlocked.Increment(m_ProgressValue) Mod m_NumberOfSpoke
            Invalidate()
        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            If m_NumberOfSpoke > 0 Then
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality

                Dim intPosition As Integer = m_ProgressValue
                For intCounter As Integer = 0 To m_NumberOfSpoke - 1
                    intPosition = intPosition Mod m_NumberOfSpoke
                    DrawLine(e.Graphics, GetCoordinate(m_CenterPoint, m_InnerCircleRadius, m_Angles(intPosition)), GetCoordinate(m_CenterPoint, m_OuterCircleRadius, m_Angles(intPosition)), m_Colors(intCounter), m_SpokeThickness)
                    intPosition += 1
                Next
            End If

            MyBase.OnPaint(e)
        End Sub

        ' Overridden Methods ================================================
        ''' <summary>
        ''' Retrieves the size of a rectangular area into which a control can be fitted.
        ''' </summary>
        ''' <param name="proposedSize">The custom-sized area for a control.</param>
        ''' <returns>
        ''' An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.
        ''' </returns>
        Public Overloads Overrides Function GetPreferredSize(ByVal proposedSize As Size) As Size
            proposedSize.Width = (m_OuterCircleRadius + m_SpokeThickness) * 2

            Return proposedSize
        End Function

        ' Methods ===========================================================
        ''' <summary>
        ''' Darkens a specified color.
        ''' </summary>
        ''' <param name="_objColor">Color to darken.</param>
        ''' <param name="_intPercent">The percent of darken.</param>
        ''' <returns>The new color generated.</returns>
        Private Function Darken(ByVal _objColor As Color, ByVal _intPercent As Integer) As Color
            Dim intRed As Integer = _objColor.R
            Dim intGreen As Integer = _objColor.G
            Dim intBlue As Integer = _objColor.B
            Return Color.FromArgb(_intPercent, Math.Min(intRed, Byte.MaxValue), Math.Min(intGreen, Byte.MaxValue), Math.Min(intBlue, Byte.MaxValue))
        End Function

        ''' <summary>
        ''' Generates the colors pallet.
        ''' </summary>
        Private Sub GenerateColorsPallet()
            m_Colors = GenerateColorsPallet(m_Color, Active, m_NumberOfSpoke)
        End Sub

        ''' <summary>
        ''' Generates the colors pallet.
        ''' </summary>
        ''' <param name="_objColor">Color of the lightest spoke.</param>
        ''' <param name="_blnShadeColor">if set to <c>true</c> the color will be shaded on X spoke.</param>
        ''' <returns>An array of color used to draw the circle.</returns>
        Private Function GenerateColorsPallet(ByVal _objColor As Color, ByVal _blnShadeColor As Boolean, ByVal _intNbSpoke As Integer) As Color()
            Dim objColors As Color() = New Color(NumberSpoke - 1) {}

            ' Value is used to simulate a gradient feel... For each spoke, the 
            ' color will be darken by value in intIncrement.
            Dim bytIncrement As Byte = CByte((Byte.MaxValue / NumberSpoke))

            'Reset variable in case of multiple passes
            Dim PERCENTAGE_OF_DARKEN As Byte = 0
            For intCursor As Integer = 0 To NumberSpoke - 1

                If _blnShadeColor Then
                    If intCursor = 0 OrElse intCursor < NumberSpoke - _intNbSpoke Then
                        objColors(intCursor) = _objColor
                    Else
                        ' Increment alpha channel color
                        PERCENTAGE_OF_DARKEN += bytIncrement

                        ' Ensure that we don't exceed the maximum alpha
                        ' channel value (255)
                        If PERCENTAGE_OF_DARKEN > Byte.MaxValue Then
                            PERCENTAGE_OF_DARKEN = Byte.MaxValue
                        End If

                        ' Determine the spoke forecolor
                        objColors(intCursor) = Darken(_objColor, PERCENTAGE_OF_DARKEN)
                    End If
                Else
                    objColors(intCursor) = _objColor
                End If
            Next

            Return objColors
        End Function

        ''' <summary>
        ''' Gets the control center point.
        ''' </summary>
        Private Sub GetControlCenterPoint()
            m_CenterPoint = GetControlCenterPoint(Me)
        End Sub

        ''' <summary>
        ''' Gets the control center point.
        ''' </summary>
        ''' <returns>PointF object</returns>
        Private Function GetControlCenterPoint(ByVal _objControl As Control) As PointF
            Return New PointF(CSng(_objControl.Width / 2), CSng(_objControl.Height / 2 - 1))
        End Function

        ''' <summary>
        ''' Draws the line with GDI+.
        ''' </summary>
        ''' <param name="_objGraphics">The Graphics object.</param>
        ''' <param name="_objPointOne">The point one.</param>
        ''' <param name="_objPointTwo">The point two.</param>
        ''' <param name="_objColor">Color of the spoke.</param>
        ''' <param name="_intLineThickness">The thickness of spoke.</param>
        Private Sub DrawLine(ByVal _objGraphics As Graphics, ByVal _objPointOne As PointF, ByVal _objPointTwo As PointF, ByVal _objColor As Color, ByVal _intLineThickness As Integer)
            Using objPen As New Pen(New SolidBrush(_objColor), _intLineThickness)
                objPen.StartCap = LineCap.Round
                objPen.EndCap = LineCap.Round
                _objGraphics.DrawLine(objPen, _objPointOne, _objPointTwo)
            End Using
        End Sub

        ''' <summary>
        ''' Gets the coordinate.
        ''' </summary>
        ''' <param name="_objCircleCenter">The Circle center.</param>
        ''' <param name="_intRadius">The radius.</param>
        ''' <param name="_dblAngle">The angle.</param>
        ''' <returns></returns>
        Private Function GetCoordinate(ByVal _objCircleCenter As PointF, ByVal _intRadius As Integer, ByVal _dblAngle As Double) As PointF
            Dim dblAngle As Double = Math.PI * _dblAngle / NumberOfDegreesInHalfCircle

            Return New PointF(_objCircleCenter.X + _intRadius * CSng(Math.Cos(dblAngle)), _objCircleCenter.Y + _intRadius * CSng(Math.Sin(dblAngle)))
        End Function

        ''' <summary>
        ''' Gets the spokes angles.
        ''' </summary>
        Private Sub GetSpokesAngles()
            m_Angles = GetSpokesAngles(NumberSpoke)
        End Sub

        ''' <summary>
        ''' Gets the spoke angles.
        ''' </summary>
        ''' <param name="_intNumberSpoke">The number spoke.</param>
        ''' <returns>An array of angle.</returns>
        Private Function GetSpokesAngles(ByVal _intNumberSpoke As Integer) As Double()
            Dim Angles As Double() = New Double(_intNumberSpoke - 1) {}
            Dim dblAngle As Double = CDbl(NumberOfDegreesInCircle) / _intNumberSpoke
            For shtCounter As Integer = 0 To _intNumberSpoke - 1
                If shtCounter = 0 Then
                    Angles(shtCounter) = dblAngle
                Else
                    Angles(shtCounter) = Angles(shtCounter - 1) + dblAngle
                End If



            Next


            Return Angles
        End Function

        ''' <summary>
        ''' Actives the timer.
        ''' </summary>
        Private Sub ActiveTimer()
            If m_IsTimerActive Then
                m_Timer.Start()
            Else
                m_Timer.[Stop]()
                m_ProgressValue = 0
            End If

            GenerateColorsPallet()
            Invalidate()
        End Sub

        ''' <summary>
        ''' Sets the circle appearance.
        ''' </summary>
        ''' <param name="numberSpoke">The number spoke.</param>
        ''' <param name="spokeThickness">The spoke thickness.</param>
        ''' <param name="innerCircleRadius">The inner circle radius.</param>
        ''' <param name="outerCircleRadius">The outer circle radius.</param>
        Public Sub SetCircleAppearance(ByVal numberSpoke As Integer, ByVal spokeThickness As Integer, ByVal innerCircleRadius As Integer, ByVal outerCircleRadius As Integer)
            Me.NumberSpoke = numberSpoke
            Me.SpokeThickness = spokeThickness
            Me.InnerCircleRadius = innerCircleRadius
            Me.OuterCircleRadius = outerCircleRadius

            Invalidate()
        End Sub
    End Class
End Namespace

