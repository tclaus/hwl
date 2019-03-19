
Imports System.Windows.Forms

Namespace Tools


    ''' <summary>
    ''' Enthält Werkzeuge zum Behandeln und Melden von Fehlern, wird eine Messagebox mit einem Fehler ausgegeben, so wird diese
    ''' inerhalb der Sitzung kein zweites mal ausgegeben.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ErrorHandler

        Private Shared m_ThrownErrors As New List(Of String)

        ''' <summary>
        ''' Zeigt eien Meldung an, die darauf hinweist, das die DAtenabnk nicht das geforderte Schema besitzt
        ''' </summary>
        ''' <param name="name"></param>
        ''' <remarks></remarks>
        Shared Sub SQLException(ByVal name As String)
            ' report machen und Messagebox ausgeben 

            Dim messagename As String = "SQLException_" & name

            If Not m_ThrownErrors.Contains(messagename) Then
                'TODO: NLS  (Eventuell direkt entfernen) 
                m_ThrownErrors.Add(messagename)
                MessageBox.Show("Die Datenbank hat nicht das geforderte Format für '" & name & "'." & vbCrLf & _
                                "Führen Sie eine Aktualisierung der Datenbank durch. Wenn das Problem immer noch besteht, nehmen Sie Kontakt mit der technischen Unterstützung auf.", "Datenbankfehler aufgertreten", MessageBoxButtons.OK, MessageBoxIcon.Error)


            End If
        End Sub


    End Class
End Namespace
