Option Explicit On
Option Strict On
Namespace Kernel
    ''' <summary>
    ''' Stellt eine Liste von IDs bereit, die als 'canceled' - (Stornierte) Journaldokumente enthält
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CanceledDocuments

        ''' <summary>
        ''' Enthälte eien Auflistung von Journal Keys, die als 'storniert' gekennzeichnet sind
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared m_CanceldJournalDocReplikIDs As New List(Of String)
        Private Shared m_canceldJournalDocIDs As New List(Of Integer)
        ''' <summary>
        ''' Ist Wahr, wenn das Dokument als Storniert mariert ist
        ''' </summary>
        ''' <param name="journalDoc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCanceldState(ByVal journalDoc As JournalDocument) As Boolean

            Return m_canceldJournalDocIDs.Contains(journalDoc.ID)

        End Function

        Public Function GetCanceldState(ByVal journalDocID As Integer) As Boolean

            Return m_canceldJournalDocIDs.Contains(journalDocID)

        End Function

        ''' <summary>
        ''' Aktualisiert den Status aller  stornierten Dokumente. Diese Methode ist thread-Safe
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub RefreshState()
            Static atwork As Boolean
            If Not atwork Then
                atwork = True

                Dim sql As String = "SELECT ReplikID,ID from " & JournalDocument.Tablename & " where IsCanceled = true"
                Dim dt As DataTable = MainApplication.getInstance.Database.GetData(sql)

                m_canceldJournalDocIDs.Clear()
                m_CanceldJournalDocReplikIDs.Clear()

                For Each item As DataRow In dt.Rows
                    m_CanceldJournalDocReplikIDs.Add(CStr(item(0)))
                    m_canceldJournalDocIDs.Add(CInt(item(1)))

                Next
                atwork = False
            End If

        End Sub

        ''' <summary>
        ''' Fügt der gesamten Auflistung einen Eintrag hinzu. Der tatsächliche 'Storno' Status wird dadurch nicht verändert
        ''' </summary>
        ''' <param name="journalDoc">Das basis - Journaldokument</param>
        ''' <remarks></remarks>
        Public Sub AddDocument(ByVal journalDoc As JournalDocument)
            If Not m_CanceldJournalDocReplikIDs.Contains(journalDoc.Key) Then m_CanceldJournalDocReplikIDs.Add(journalDoc.Key)
            If Not m_canceldJournalDocIDs.Contains(journalDoc.ID) Then m_canceldJournalDocIDs.Add(journalDoc.ID)

        End Sub
        ''' <summary>
        ''' Entfernt aus der Auflistung einen Eintrag. Der tatsächliche 'Storno' Status wird dadurch nicht verändert
        ''' </summary>
        Public Sub RemoveDocument(ByVal journalDoc As JournalDocument)
            If m_CanceldJournalDocReplikIDs.Contains(journalDoc.Key) Then m_CanceldJournalDocReplikIDs.Remove(journalDoc.Key)
            If m_canceldJournalDocIDs.Contains(journalDoc.ID) Then m_canceldJournalDocIDs.Remove(journalDoc.ID)

        End Sub

    End Class
End Namespace
