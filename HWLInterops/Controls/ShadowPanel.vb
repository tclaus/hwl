Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


Namespace ShadowPanel
    Public Class ShadowPanel
        Inherits Panel
        Private _panelColor As Color

        Public Property PanelColor() As Color
            Get
                Return _panelColor
            End Get
            Set(ByVal value As Color)
                _panelColor = value
            End Set
        End Property

        Private _borderColor As Color

        Public Property BorderColor() As Color
            Get

                Return _borderColor
            End Get
            Set(ByVal value As Color)
                _borderColor = value
            End Set
        End Property

        Private shadowSize As Integer = 5
        Private shadowMargin As Integer = 2

        ' static for good perfomance 
        Shared shadowDownRight As Image = My.Resources.tshadowdownright
        Shared shadowDownLeft As Image = My.Resources.tshadowdownleft
        Shared shadowDown As Image = My.Resources.tshadowdown
        Shared shadowRight As Image = My.Resources.tshadowright
        Shared shadowTopRight As Image = My.Resources.tshadowtopright


        Public Sub New()
        End Sub

        Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ' Get the graphics object. We need something to draw with ;-)
            Dim g As Graphics = e.Graphics
            'g.SmoothingMode = SmoothingMode.AntiAlias

            'Dim _Path As New GraphicsPath
            '_Path.AddRectangle(Me.DisplayRectangle)



            'Using _Brush As New PathGradientBrush(_Path)
            '    ' set the wrapmode so that the colors will layer themselves
            '    ' from the outer edge in
            '    _Brush.WrapMode = WrapMode.Clamp

            '    ' Create a color blend to manage our colors and positions and
            '    ' since we need 3 colors set the default length to 3
            '    Dim _ColorBlend As New ColorBlend(3)

            '    ' here is the important part of the shadow making process, remember
            '    ' the clamp mode on the colorblend object layers the colors from
            '    ' the outside to the center so we want our transparent color first
            '    ' followed by the actual shadow color. Set the shadow color to a 
            '    ' slightly transparent DimGray, I find that it works best.
            '    _ColorBlend.Colors = New Color() {Color.Transparent, Color.FromArgb(180, Color.DimGray), Color.FromArgb(180, Color.DimGray)}

            '    ' our color blend will control the distance of each color layer
            '    ' we want to set our transparent color to 0 indicating that the 
            '    ' transparent color should be the outer most color drawn, then
            '    ' our Dimgray color at about 10% of the distance from the edge
            '    _ColorBlend.Positions = New Single() {0.0F, 0.1F, 1.0F}

            '    ' assign the color blend to the pathgradientbrush
            '    _Brush.InterpolationColors = _ColorBlend

            '    ' fill the shadow with our pathgradientbrush
            '    e.Graphics.FillPath(_Brush, _Path)
            'End Using








            '------------------
            ' Create tiled brushes for the shadow on the right and at the bottom.
            Dim shadowRightBrush As New TextureBrush(shadowRight, WrapMode.Tile)
            Dim shadowDownBrush As New TextureBrush(shadowDown, WrapMode.Tile)

            ' Translate (move) the brushes so the top or left of the image matches the top or left of the
            ' area where it's drawed. If you don't understand why this is necessary, comment it out. 
            ' Hint: The tiling would start at 0,0 of the control, so the shadows will be offset a little.
            shadowDownBrush.TranslateTransform(0, Height - shadowSize)
            shadowRightBrush.TranslateTransform(Width - shadowSize, 0)

            ' Define the rectangles that will be filled with the brush.
            ' (where the shadow is drawn)
            ' X
            ' Y
            ' width (stretches)
            ' height
            Dim shadowDownRectangle As New Rectangle(shadowSize + shadowMargin, Height - shadowSize, Width - (shadowSize * 2 + shadowMargin), shadowSize)

            ' X
            ' Y
            ' width
            ' height (stretches)
            Dim shadowRightRectangle As New Rectangle(Width - shadowSize, shadowSize + shadowMargin, shadowSize, Height - (shadowSize * 2 + shadowMargin))

            ' And draw the shadow on the right and at the bottom.
            g.FillRectangle(shadowDownBrush, shadowDownRectangle)
            g.FillRectangle(shadowRightBrush, shadowRightRectangle)

            ' Now for the corners, draw the 3 5x5 pixel images.
            g.DrawImage(shadowTopRight, New Rectangle(Width - shadowSize, shadowMargin, shadowSize, shadowSize))
            g.DrawImage(shadowDownRight, New Rectangle(Width - shadowSize, Height - shadowSize, shadowSize, shadowSize))
            g.DrawImage(shadowDownLeft, New Rectangle(shadowMargin, Height - shadowSize, shadowSize, shadowSize))

            ' Fill the area inside with the color in the PanelColor property.
            ' 1 pixel is added to everything to make the rectangle smaller. 
            ' This is because the 1 pixel border is actually drawn outside the rectangle.
            ' X
            ' Y
            ' Width
            ' Height
            Dim fullRectangle As New Rectangle(1, 1, Width - (shadowSize + 2), Height - (shadowSize + 2))


            Dim bgBrush As New SolidBrush(_panelColor)
            g.FillRectangle(bgBrush, fullRectangle)


            ' Draw a nice 1 pixel border it a BorderColor is specified

            Dim borderPen As New Pen(BorderColor)
            g.DrawRectangle(borderPen, fullRectangle)


            ' Memory efficiency
            shadowDownBrush.Dispose()
            shadowRightBrush.Dispose()

            shadowDownBrush = Nothing
            shadowRightBrush = Nothing
        End Sub
    End Class
End Namespace

