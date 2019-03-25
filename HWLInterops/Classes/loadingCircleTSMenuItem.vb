'
' Copyright ©2006, 2007, Martin R. Gagné (martingagne@gmail.com)
' All rights reserved.
'
' Redistribution and use in source and binary forms, with or without modification,
' are permitted provided that the following conditions are met:
'
' - Redistributions of source code must retain the above copyright notice,
' this list of conditions and the following disclaimer.
'
' - Redistributions in binary form must reproduce the above copyright notice,
' this list of conditions and the following disclaimer in the documentation
' and/or other materials provided with the distribution.
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

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.Drawing

Namespace MRG.Controls.UI
    <ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)> _
    Public Class LoadingCircleToolStripMenuItem
        Inherits ToolStripControlHost
        ' Constants =========================================================

        ' Attributes ========================================================

        ' Properties ========================================================
        ''' <summary>
        ''' Gets the loading circle control.
        ''' </summary>
        ''' <value>The loading circle control.</value>
        <RefreshProperties(RefreshProperties.All), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property LoadingCircleControl() As LoadingCircle
            Get
                Return TryCast(Control, LoadingCircle)
            End Get
        End Property

        ' Constructor ========================================================
        ''' <summary>
        ''' Initializes a new instance of the <see cref="LoadingCircleToolStripMenuItem"/> class.
        ''' </summary>
        Public Sub New()
            MyBase.New(New LoadingCircle())
        End Sub

        ''' <summary>
        ''' Retrieves the size of a rectangular area into which a control can be fitted.
        ''' </summary>
        ''' <param name="constrainingSize">The custom-sized area for a control.</param>
        ''' <returns>
        ''' An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.
        ''' </returns>
        ''' <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        Public Overloads Overrides Function GetPreferredSize(ByVal constrainingSize As Size) As Size
            'return base.GetPreferredSize(constrainingSize);
            Return Me.LoadingCircleControl.GetPreferredSize(constrainingSize)
        End Function

        ''' <summary>
        ''' Subscribes events from the hosted control.
        ''' </summary>
        ''' <param name="control">The control from which to subscribe events.</param>
        Protected Overloads Overrides Sub OnSubscribeControlEvents(ByVal control As Control)
            MyBase.OnSubscribeControlEvents(control)

            'Add your code here to subsribe to Control Events
        End Sub

        ''' <summary>
        ''' Unsubscribes events from the hosted control.
        ''' </summary>
        ''' <param name="control">The control from which to unsubscribe events.</param>
        Protected Overloads Overrides Sub OnUnsubscribeControlEvents(ByVal control As Control)
            MyBase.OnUnsubscribeControlEvents(control)

            'Add your code here to unsubscribe from control events.
        End Sub
    End Class
End Namespace
