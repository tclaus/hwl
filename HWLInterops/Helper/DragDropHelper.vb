Public Class DragDropHelper

    ''' <summary>
    ''' Prüft auf Vorhandensein von Text im aktuellen DragDrop-Kontext. Der Effekt wird dann auf 'copy' eingestellt
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Sub CheckForText(sender As Object, e As System.Windows.Forms.DragEventArgs)
        If DataHasText(e.Data) Then
            e.Effect = DragDropEffects.Copy Or DragDropEffects.Move
        End If

    End Sub

    ''' <summary>
    ''' Sofern der sender ein Typ von Control ist, wird der übergebene Text hineinkopiert
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetText(sender As Object, e As System.Windows.Forms.DragEventArgs)
        If DataHasText(e.Data) Then

            If TypeOf sender Is System.Windows.Forms.Control Then
                Dim ctrl As Control = CType(sender, Control)
                ctrl.Text &= DataGetText(e.Data)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Gibt Wahr zurück, wenn das Datenobjet einen Text enthält
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DataHasText(data As System.Windows.Forms.IDataObject) As Boolean

        For Each item As String In data.GetFormats
            Debug.Print(item)
            If item = "System.String" Then Return True
            If item = "Text" Then Return True
            If item = "UnicodeText" Then Return True
            If item = "HTML Format" Then Return True

        Next
        Debug.Print("No Text data found!")
        Return False
    End Function

    ''' <summary>
    '''  Ruft aus dem Clipboard einen unformatierten Text ab
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DataGetText(data As System.Windows.Forms.IDataObject) As String
        Dim defaultString As String = String.Empty
        For Each item As String In data.GetFormats
            Debug.Print(item)
            If item = "System.String" Then Return CStr(data.GetData(item))
            If item = "Text" Then Return CStr(data.GetData(item))
            If item = "UnicodeText" Then Return CStr(data.GetData(item))
            If item = "HTML Format" Then Continue For 'Return CStr(data.GetData(item))

        Next

        Return defaultString
    End Function
End Class
