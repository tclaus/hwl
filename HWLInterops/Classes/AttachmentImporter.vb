Option Strict On
Option Explicit On

''' <summary>
''' Stellt einen Dialog bereit, um Anhänge zu importieren
''' </summary>
''' <remarks></remarks>
Public Class AttachmentImporter




    ''' <summary>
    ''' Startet das kopieren der Dateien Asynchron
    ''' </summary>
    ''' <param name="filelist"></param>
    ''' <param name="selectedDocument"></param>
    ''' <remarks></remarks>
    Friend Sub StartCopyFiles(ByVal filelist As Array, ByVal selectedDocument As ClausSoftware.Data.IAttachments)
        Try
            If selectedDocument IsNot Nothing Then

                Dim FilesList() As String = CType(filelist, String())

                Using frm As New frmWaitForFileCopy(selectedDocument, FilesList)

                    frm.ShowDialog() ' Zeigt den Dialog an und beginnt mit dem kopieren
                    frm.Close()
                End Using

            Else
                Debug.Print("Dokument war Nothing")
            End If


        Catch ex As Exception

            MainApplication.getInstance.log.WriteLog(ex, "AttachmentImporter", "Fehler beim einfügen von Attachments")

        End Try

    End Sub

End Class
