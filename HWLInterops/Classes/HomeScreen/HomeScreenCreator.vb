Imports System
Imports System.Windows.Forms

Namespace HomeScreen


    Public Class HomeScreenCreator

        Private m_homePanel As Panel



        Public Sub New(ByVal homePanel As Panel)
            m_homePanel = homePanel
        End Sub

#Region "Menu"
        Private m_linearBrush As System.Drawing.Drawing2D.LinearGradientBrush

        ''' <summary>
        ''' Farbe der Überschriften der Startoberfläche
        ''' </summary>
        ''' <remarks></remarks>
        Private m_colorLabelHeading As Color = Color.DarkBlue

        ''' <summary>
        ''' Farbe der Menüeinträge unter den Überschriften
        ''' </summary>
        ''' <remarks></remarks>
        Private m_colorLabelMenuitems As Color = Color.Black


        Private m_menuStructure As MenuStructure

        ''' <summary>
        ''' Ruft die Menüstruktur ab, die auf dem Home-Bildschirm projektziert werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property HomeMenuStructure() As MenuStructure
            Get
                Return m_menuStructure
            End Get
            Set(ByVal value As MenuStructure)
                m_menuStructure = value
            End Set
        End Property


        ''' <summary>
        ''' Erstellt aus den Explorer-Bars dynamisch einen Startbildschirm mit den Buttons der entsprechen Überschriften der MainexplorerBar
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub CreateMainMenueTable()

            Dim myMenu As MenuStructure = m_menuStructure

            Debug.Assert(myMenu IsNot Nothing, "Es wurde nicht das Objekt für die Menüstruktur gesetzt!")


            Dim m_lblMainMenuItem As Label

            Dim menuToolTip As New System.Windows.Forms.ToolTip

            Dim upTopPosX As Integer = 11 ' Position X des Upper-Panels, + Anfangsabstand des linken Rahmens
            Dim upTopPosY As Integer = 11 ' Position Y des Upper-Panels
            Dim maxWidth As Integer ' Maximale Breite der zuletzt gezeichneten Spalte ermitteln 

            m_homePanel.SuspendLayout()
            m_homePanel.Controls.Clear()
            'm_homePanel_.FlowDirection = FlowDirection.TopDown
            m_homePanel.Tag = "DontTranslate" ' jeglichen Inhalt hier nicht übersetzen 


            m_homePanel.Visible = False

            Dim itemCounter As Integer

            ' Alle Über-Gruppen der Exp. Bar durchlaufen  und die Überschriften einsammeln
            For Each groupID As ModuleItem In myMenu.ListOfModules

                Dim groupToolTips As String = "" ' Stellt Tooltips mit den Items der jeweiligen Gruppe bereit; Für das "Benutzer Erlebniss" gedacht
                Dim UpperPanel As New MyFlowLayoutPanel


                UpperPanel.SuspendLayout()
                UpperPanel.FlowDirection = FlowDirection.LeftToRight
                UpperPanel.WrapContents = False
                UpperPanel.BackColor = Color.Transparent
                UpperPanel.Name = "UpperPanel"
                UpperPanel.Width = 300 ' Startbreite; skaliert automatisch bei grösseren Objekten
                UpperPanel.AutoSize = True
                UpperPanel.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
                UpperPanel.Margin = New Padding(11)

                ' UpperPanel.BorderStyle = BorderStyle.FixedSingle

                Dim Picturectrl As New System.Windows.Forms.PictureBox
                Picturectrl.Image = groupID.Icon
                'Picturectrl.BorderStyle = BorderStyle.FixedSingle
                Picturectrl.SizeMode = PictureBoxSizeMode.AutoSize
                Picturectrl.BackColor = Color.Transparent

                AddHandler Picturectrl.MouseEnter, AddressOf PictureMouseEnter
                AddHandler Picturectrl.MouseLeave, AddressOf PictureMouseLeave

                UpperPanel.Controls.Add(Picturectrl) ' Icon hinzufügen
                ' UpperPanel.BorderStyle = BorderStyle.FixedSingle

                Dim InnerPanel As New MyFlowLayoutPanel
                InnerPanel.AutoSize = True
                InnerPanel.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly

                InnerPanel.FlowDirection = FlowDirection.TopDown
                InnerPanel.WrapContents = False ' nicht umbrechen, auf jeden Fall nach unten!
                InnerPanel.BackColor = Color.Transparent
                AddHandler InnerPanel.MouseLeave, AddressOf InnerPanelMouseLeave
                AddHandler InnerPanel.MouseEnter, AddressOf InnerPanelMouseEnter


                ' Überschrift des inneren Panels festlegen
                Dim lblHeading As New Label
                'lblHeading.BorderStyle = BorderStyle.FixedSingle
                lblHeading.Text = groupID.ModuleName
                lblHeading.Name = "Headline"
                lblHeading.Font = New System.Drawing.Font("Tahoma", 14, FontStyle.Regular, GraphicsUnit.Point)
                lblHeading.ForeColor = m_colorLabelHeading
                lblHeading.Tag = groupID.ModuleID
                lblHeading.Cursor = Cursors.Hand
                lblHeading.AutoSize = True
                lblHeading.Margin = New Padding(0)
                lblHeading.Padding = New Padding(0)
                lblHeading.BackColor = Color.Transparent


                'If Main.m_isNoAdminUser Then
                '    lblHeading.ForeColor = Color.FromArgb(10, lblHeading.ForeColor)
                '    lblHeading.Enabled = False
                'End If

                'lblHeading.BorderStyle = BorderStyle.FixedSingle
                'InnerPanel.BorderStyle = BorderStyle.FixedSingle

                AddHandler lblHeading.Click, AddressOf MainMenueMouseClick
                AddHandler lblHeading.MouseEnter, AddressOf MainMenueMouseEnter    '
                AddHandler lblHeading.MouseLeave, AddressOf MainMenueMouseLeave   ' mimiks Link-Style

                InnerPanel.Controls.Add(lblHeading)

                ' Einzelne Items der untergeordneten explorerbars auslesen
                Dim ListPane As New MyFlowLayoutPanel
                ListPane.FlowDirection = FlowDirection.TopDown
                ListPane.AutoSize = True
                ListPane.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink



                '  For Each innerCtrl As Control In MainExplorerBar.Controls


                Dim localToolTips As String = String.Empty

                ' CType(ctrl, UltraWinExplorerBar.UltraExplorerBar).Name


                For Each MenuFunctionItem As MenuFunction In groupID.ListOfFunctions

                    If Not MenuFunctionItem.IsVisible Then Continue For

                    'TODO: Tooltip bilden ? 

                    m_lblMainMenuItem = New Label
                    AddHandler m_lblMainMenuItem.MouseEnter, AddressOf MainMenueMouseEnter    '
                    AddHandler m_lblMainMenuItem.MouseLeave, AddressOf MainMenueMouseLeave   ' mimics Link-Style

                    AddHandler m_lblMainMenuItem.Click, AddressOf MainMenueMouseClick        ' Click-event

                    m_lblMainMenuItem.Name = "lbl" & MenuFunctionItem.Name '  "Item"
                    m_lblMainMenuItem.BackColor = Color.Transparent
                    m_lblMainMenuItem.ForeColor = m_colorLabelMenuitems
                    m_lblMainMenuItem.AutoSize = True
                    m_lblMainMenuItem.Text = MenuFunctionItem.Caption
                    m_lblMainMenuItem.Cursor = Cursors.Hand
                    m_lblMainMenuItem.Font = New System.Drawing.Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point)
                    m_lblMainMenuItem.Tag = MenuFunctionItem.FunctionID



                    menuToolTip.SetToolTip(m_lblMainMenuItem, localToolTips)  ' Tooltip mit den Items anzeigen lassen
                    ListPane.Controls.Add(m_lblMainMenuItem)               ' Das Label der Form hinzufügen

                    groupToolTips += MenuFunctionItem.Caption + ": " + localToolTips + " " + Environment.NewLine

                Next



                'Next
                'ListPane.BorderStyle = BorderStyle.FixedSingle
                ListPane.AutoSize = True
                ListPane.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                '  ListPane.BorderStyle = BorderStyle.FixedSingle

                InnerPanel.Controls.Add(ListPane)
                ' InnerPanel.BorderStyle = BorderStyle.FixedSingle

                UpperPanel.Controls.Add(InnerPanel)

                AddHandler ListPane.MouseEnter, AddressOf ListPanelMouseEnter
                AddHandler ListPane.MouseLeave, AddressOf ListPanelMouseEnter


                ' Hintergrund aktivieren, wenn Maus darüber schwebt
                AddHandler UpperPanel.MouseEnter, AddressOf PanelMouseEnter
                AddHandler UpperPanel.MouseLeave, AddressOf PanelMouseLeave
                AddHandler UpperPanel.Paint, AddressOf UpperPanel_Paint

                'UpperPanel.BorderStyle = BorderStyle.FixedSingle

                UpperPanel.ResumeLayout()


                ' Grösste Breite bestlegen
                If UpperPanel.Width > maxWidth Then
                    maxWidth = UpperPanel.Width
                End If
                m_homePanel.Controls.Add(UpperPanel)

                ' Dem Haupt-Panel zuordnen
                'UpperPanel.BorderStyle = BorderStyle.FixedSingle
                UpperPanel.Top = upTopPosY
                UpperPanel.Left = upTopPosX

                m_homePanel.ResumeLayout()
                upTopPosY += UpperPanel.Height + CInt(UpperPanel.Margin.Bottom * 2.7)


                itemCounter += 1

                If (itemCounter + 1) Mod 4 = 0 Then
                    'm_homePanel.SetFlowBreak(UpperPanel, True)
                    upTopPosY = 11 ' Nicht ganz oben anfangen
                    upTopPosX += maxWidth + UpperPanel.Margin.Left ' Linken Rand einstellen, das breiteste Control gibt den Abstand vor
                End If



            Next


            m_homePanel.ResumeLayout()
            m_homePanel.Visible = True



        End Sub





        ''' <summary>
        ''' Dummy, gibt den eingehenden Text wieder zurück
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetText(ByVal key As String) As String
            Return key
        End Function

#Region "MenuMouseevents"


        ''' <summary>
        ''' Reagiert auf Mouseover des Hauptmenüs; Simuliert einen Web-Link; Stellt Text unterstrichen da.
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>

        Private Sub MainMenueMouseEnter(ByVal Sender As Object, ByVal e As EventArgs)

            Dim lbl As Label
            lbl = CType(Sender, Label)
            ' Nur die Headline-.Texte werden unterstrichen dargestellt
            lbl.Font = New Font(lbl.Font, FontStyle.Underline)

            If lbl.Name = "Headline" Then

                PanelMouseEnter(lbl.Parent.Parent, e)
            Else
                PanelMouseEnter(lbl.Parent.Parent.Parent, e)
            End If


        End Sub

        ''' <summary>
        ''' Reagiert auf Mouseover des Hauptmenüs; Simuliert einen Web-Link. Entfernt Unterstreichung.
        ''' Leitet das event weiter zum umgebenen Panel
        ''' </summary>
        ''' <param name="Sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>

        Private Sub MainMenueMouseLeave(ByVal Sender As Object, ByVal e As EventArgs)
            Dim lbl As Label
            lbl = CType(Sender, Label)
            lbl.Font = New Font(lbl.Font, FontStyle.Regular)
            If lbl.Name = "Headline" Then

                PanelMouseLeave(lbl.Parent.Parent, e)
            Else
                PanelMouseLeave(lbl.Parent.Parent.Parent, e)
            End If

        End Sub

        ''' <summary>
        ''' Untersucht einen Mausklick auf ein Element des Titels, und öffnet die entsprechende explorerbar
        ''' Leitet das event weiter zum umgebenen Panel
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub MainMenueMouseClick(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("Item Click!")

        End Sub

#End Region

#Region "Highlight Menuitems"


        ''' <summary>
        ''' Zeichnet einen Rahmen um die gewählten Einträge des Startmenues zur Hervorhebung des aktiven Eintrages.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        <DebuggerStepThrough()> _
        Private Sub ShowBorder(ByVal sender As Object, ByVal e As PaintEventArgs)
            Dim panel As Control = CType(sender, Control)

            m_linearBrush = _
                    New System.Drawing.Drawing2D.LinearGradientBrush( _
                    New Rectangle(0, 0, panel.Width, panel.Height), _
                     Color.FromArgb(255, 157, 185, 235), _
                     Color.FromArgb(255, 182, 215, 255), _
                    Drawing.Drawing2D.LinearGradientMode.Vertical _
                )

            Dim pen As System.Drawing.Pen
            pen = New System.Drawing.Pen(m_linearBrush)

            ' Dim graphics As Graphics = panel.CreateGraphics()

            'e.Graphics.FillRectangle(m_lb, 0, 0, panel.Width, panel.Height)
            e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1)
            pen.Dispose()
            m_linearBrush.Dispose()
            e.Dispose()

        End Sub

        ''' <summary>
        ''' Löscht den Rahmen um nicht mehr ausgewählte Elemente des Startmenues
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        <DebuggerNonUserCode()> _
        Private Sub HideBorder(ByVal sender As Object, ByVal e As PaintEventArgs)
            Dim panel As FlowLayoutPanel = CType(sender, FlowLayoutPanel)

            'm_lb = _
            '        New System.Drawing.Drawing2D.LinearGradientBrush( _
            '        New Rectangle(0, 0, panel.Width, panel.Height), _
            '         Color.FromArgb(20, 0, 0, 10), _
            '         Color.FromArgb(10, 0, 0, 10), _
            '        Drawing.Drawing2D.LinearGradientMode.Horizontal _
            '    )

            Dim pen As System.Drawing.Pen
            pen = New System.Drawing.Pen(Color.Transparent)

            'Dim graphics As Graphics = panel.CreateGraphics()

            'e.Graphics.FillRectangle(m_lb, 0, 0, panel.Width, panel.Height)
            e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1)

            pen.Dispose()
            e.Dispose()


        End Sub

        ''' <summary>
        ''' Wird an das Paint-Ereignis des Panels im Startmenu gehängt und zeichnet einen Rahmen beim selektieren und löscht diesen beim Abwählen wieder.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        <DebuggerStepThrough()> _
        Private Sub UpperPanel_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)

            If CBool(CType(sender, FlowLayoutPanel).Tag) = True Then ' Activated
                ShowBorder(sender, e)
            Else ' Nicht aktiviert
                HideBorder(sender, e)
            End If
        End Sub

        <DebuggerStepThrough()> _
        Private Sub PictureMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
            ' Upper-Panel- InnerPanel - Listpanel
            PanelMouseEnter(CType(sender, PictureBox).Parent, e)
        End Sub

        <DebuggerStepThrough()> _
        Private Sub PictureMouseLeave(ByVal sender As Object, ByVal e As EventArgs)
            ' Upper-Panel- InnerPanel - Listpanel
            PanelMouseLeave(CType(sender, PictureBox).Parent, e)

        End Sub

        <DebuggerStepThrough()> _
        Private Sub InnerPanelMouseLeave(ByVal sender As Object, ByVal e As EventArgs)
            ' Upper-Panel- InnerPanel - Listpanel
            PanelMouseLeave(CType(sender, FlowLayoutPanel).Parent, e)

        End Sub

        <DebuggerStepThrough()> _
        Private Sub InnerPanelMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
            ' Upper-Panel- InnerPanel - Listpanel
            PanelMouseEnter(CType(sender, FlowLayoutPanel).Parent, e)
        End Sub

        <DebuggerStepThrough()> _
        Private Sub ListPanelMouseLeave(ByVal sender As Object, ByVal e As EventArgs)
            ' Upper-Panel- InnerPanel - Listpanel
            PanelMouseLeave(CType(sender, FlowLayoutPanel).Parent.Parent, e)

        End Sub

        <DebuggerStepThrough()> _
        Private Sub ListPanelMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
            ' Upper-Panel- InnerPanel - Listpanel
            PanelMouseEnter(CType(sender, FlowLayoutPanel).Parent.Parent, e)
        End Sub

        ''' <summary>
        ''' Fährt die Maus über ein Panel der Hauptmenues, so wird dies durch eine Änderung der Farbe gekennzeichnet
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        <DebuggerStepThrough()> _
        Private Sub PanelMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
            Dim c As New Color
            c = Color.FromArgb(225, 238, 255)
            CType(sender, Control).Tag = CBool(True) ' Beim Paint wird der Rahmen festgelegt

            CType(sender, Control).BackColor = c

        End Sub


        ''' <summary>
        ''' Farbe des Hintergrundes wieder zurücksetzen wenn die Maus den Bereich verlässt.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        <DebuggerStepThrough()> _
        Private Sub PanelMouseLeave(ByVal sender As Object, ByVal e As EventArgs)
            Dim c As New Color
            c = Color.Transparent
            Dim p As Panel = CType(sender, Panel)

            ' Nur zurücksetzen, wenn das Control auch tatsächlich verlassen worden ist. 
            ' sonst flimmert es, wenn der Mauszeiger über ein eingebettetes Controll schwebt
            ' (Fokus geht dann verlohren, wird sogleioch wieder vom neuen Control ausgelöst und blubbert nach oben => Flimmert)
            Dim checkPoint As Point = m_homePanel.PointToClient(System.Windows.Forms.Form.MousePosition)

            If checkPoint.X > p.Location.X And checkPoint.X < p.Location.X + p.Size.Width Then
                ' ist immernoch innerhalbe der Horizontalen abmessungen
                If checkPoint.Y > p.Location.Y And checkPoint.Y < p.Location.Y + p.Size.Height Then
                    Exit Sub
                Else
                    p.Tag = False
                    p.BackColor = c
                End If
            Else
                p.Tag = False
                p.BackColor = c

            End If


        End Sub
#End Region

#End Region

    End Class

End Namespace