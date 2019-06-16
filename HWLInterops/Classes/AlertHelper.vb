
Imports DevExpress.XtraBars.Alerter

''' <summary>
''' Stellt einen Aufrufdelegaten zur Verfügung, mit dem der Klick auf ein Alert-Fenster weitergereicht werden kann
''' </summary>
''' <param name="sender">Das Objekt, durch das die Benachrichtigung definiert ist</param>
''' <remarks></remarks>
Public Delegate Sub OnAlertClick(ByVal sender As AlertElement)


''' <summary>
''' Stellt eine Hilfsklasse für das Anzeigen von Alerts (Notifications) zur Verfügung
''' </summary>
''' <remarks></remarks>
Public Class AlertHelper
    Implements IDisposable

    Friend m_alertControl1 As AlertControl
    Private m_ui As MainUI

    ''' <summary>
    ''' Verteilt das gemeinsame Alert-event auf verschiedene Ziele
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AlertEventDispatcher(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Alerter.AlertClickEventArgs)
        If TypeOf e.Info.Tag Is AlertElement Then

            Dim AlertElement As AlertElement = CType(e.Info.Tag, HWLInterops.AlertElement)
            If AlertElement.OnClick IsNot Nothing Then
                AlertElement.OnClick.Invoke(AlertElement)
            End If

        End If
    End Sub


    ''' <summary>
    ''' Zeigt eine Notification an, ohne Bild und ohne Rückmeldung
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Public Sub ShowAlert(ByVal message As String)
        Dim alertItem As New AlertElement
        alertItem.Text = message
        ShowAlert(alertItem)
    End Sub

    ''' <summary>
    ''' Zeigt ein Benachrichtigungsfenster mit einer Überschrift und Nachrichtentext
    ''' </summary>
    ''' <param name="caption">Überschrift der Benachrichtigung</param>
    ''' <param name="message">Haupttext der Baneachritigung</param>
    ''' <remarks></remarks>
    Public Sub ShowAlert(ByVal caption As String, ByVal message As String)
        Dim alertItem As New AlertElement
        alertItem.Text = message
        alertItem.Caption = caption

        ShowAlert(alertItem)
    End Sub

    ''' <summary>
    ''' Zeigt eine Benachrichtung an
    ''' </summary>
    ''' <param name="caption">Überschrift der Benachrichtigung</param>
    ''' <param name="message">Haupttext der Baneachritigung</param>
    ''' <param name="alertImage">Icon das dargestellt wird</param>
    ''' <remarks></remarks>
    Public Sub ShowAlert(ByVal caption As String, ByVal message As String, ByVal alertImage As Image)
        Dim alertItem As New AlertElement
        alertItem.Text = message
        alertItem.Caption = caption
        alertItem.Image = alertImage
        ShowAlert(alertItem)
    End Sub

    ''' <summary>
    ''' Zeigt eine Benachrichtung mit den Daten die im element-Objekt übergeben wurden
    ''' </summary>
    ''' <param name="element">Stellt ein Objekt bereit, das Details zu dem aufzurufendem Benachrichtigung enthältr und eine Rücksprungadresse bereitstellt</param>
    ''' <remarks></remarks>
    Public Sub ShowAlert(ByVal element As AlertElement)
        With element
            If Not String.IsNullOrEmpty(.Caption) Then
                .Caption = MainApplication.ApplicationName & ": " & .Caption
            Else
                .Caption = MainApplication.ApplicationName
            End If

            Dim info As AlertInfo = New AlertInfo(.Caption, .Text)
            info.Image = .Image

            info.Tag = element
            InvokeShowAlert(info)


        End With


    End Sub

    Private Delegate Sub showAlertertDele(ByVal info As AlertInfo)
    Private m_showAlertertDele As New showAlertertDele(AddressOf InvokeShowAlert)

    ''' <summary>
    ''' Zeigt den alert
    ''' </summary>
    ''' <param name="info"></param>
    ''' <remarks></remarks>
    Private Sub InvokeShowAlert(ByVal info As AlertInfo)
        If m_ui.Mainform.InvokeRequired Then
            m_ui.Mainform.Invoke(m_showAlertertDele, info)

        Else
            m_alertControl1.Show(Nothing, info)

        End If
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz der Klasse
    ''' </summary>
    ''' <param name="ui"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ui As MainUI)
        m_ui = ui

        m_alertControl1 = New AlertControl(ui.Mainform.Container)

        AddHandler m_alertControl1.AlertClick, AddressOf Me.AlertEventDispatcher
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then

                If m_alertControl1 IsNot Nothing Then
                    m_alertControl1.Dispose()
                    m_alertControl1 = Nothing
                End If

            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
