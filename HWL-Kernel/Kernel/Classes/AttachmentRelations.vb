Option Explicit On
Option Strict On


Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports System.Runtime.InteropServices
Imports DevExpress.Data.Filtering

Namespace Kernel

    ''' <summary>
    ''' Stellt eine LIste von Adressen da.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AttachmentsRelations
        Inherits BaseCollection(Of AttachmentsRelation)
        Implements IDataCollection

        Private Shared m_listOfSource As New Dictionary(Of String, List(Of String))

        ''' <summary>
        ''' Fügt dieser Auflistung einen Anhang hinzu und speichert die Verknüpfung und den Anhang sofort ab
        ''' </summary>
        ''' <param name="sourceDocumentID">Die ID des Dokumentes an dem dieser Anhang angebunden werden soll</param>
        ''' <param name="newAttachment">Der neu hinzuzufügende Dateianhang</param>
        ''' <remarks></remarks>
        Overloads Sub Add(ByVal sourceDocumentID As String, ByVal newAttachment As Attachment)

            Dim relation As AttachmentsRelation = Me.GetNewItem

            newAttachment = GetExistingAttachment(newAttachment) ' eventuell ein bereits existierendes Attachment abholen

            Dim criteria As New DevExpress.Data.Filtering.GroupOperator(GroupOperatorType.And, New BinaryOperator("SourceDocumentID", sourceDocumentID, BinaryOperatorType.Equal), _
                                                            New BinaryOperator("TargetAttachmentID", newAttachment.Key, BinaryOperatorType.Equal))

            'Wenn dies das letztze Objekt war, dann das Attachment auch löschen!
            If Me.Session.FindObject(Of AttachmentsRelation)(Criteria) Is Nothing Then

                relation.SourceDocumentID = sourceDocumentID
                relation.TargetAttachmentID = newAttachment.ReplikID

                MyBase.Add(relation)
                newAttachment.Save()
                relation.Save()
            Else
                Debug.Print("Attachment-Link existiert bereits. wird nicht erneut angelegt")
            End If

        End Sub

        ''' <summary>
        ''' Entfernt die Verknüpfung dieses Anhanges, ist die letzte Verknüpfung entfernt, wird der Anhang ebenfalls entfernt
        ''' </summary>
        ''' <param name="sourceDocumentID"></param>
        ''' <param name="newAttachment"></param>
        ''' <remarks></remarks>
        Overloads Sub Remove(sourceDocumentID As String, newAttachment As Attachment)
            Remove(sourceDocumentID, newAttachment.ReplikID)
        End Sub

        ''' <summary>
        ''' Entfernt die Verknüpfung dieses Anhanges, ist die letzte Verknüpfung entfernt, wird der Anhang ebenfalls entfernt
        ''' </summary>
        ''' <param name="sourceDocumentID"></param>
        ''' <param name="attachmentID"></param>
        ''' <remarks></remarks>
        Overloads Sub Remove(sourceDocumentID As String, attachmentID As String)
            Dim criteria As New DevExpress.Data.Filtering.GroupOperator(GroupOperatorType.And, New BinaryOperator("SourceDocumentID", sourceDocumentID, BinaryOperatorType.Equal), _
                                                                        New BinaryOperator("TargetAttachmentID", attachmentID, BinaryOperatorType.Equal))


            Dim testrelations As BaseCollection(Of AttachmentsRelation) = CType(Me.GetNewCollection(criteria), BaseCollection(Of AttachmentsRelation))
            Dim deleList As New List(Of AttachmentsRelation)
            deleList.AddRange(testrelations)
            
            ' Aus der eigenen Auflistung entfernen und löschen
            For Each item As AttachmentsRelation In deleList
                Me.Remove(item)
                item.Delete()
            Next




        End Sub

        ''' <summary>
        ''' Entfernt alle Verknüpfung dieser DokumentenID
        ''' </summary>
        ''' <param name="sourceDocumentID">Die ID des Ausgangsdokument, das entfernt werdn soll</param>
        ''' <remarks></remarks>
        Overloads Sub RemoveAllBySourceDocument(sourceDocumentID As String)
            Dim criteria As New BinaryOperator("SourceDocumentID", sourceDocumentID, BinaryOperatorType.Equal)

            Dim testrelations As BaseCollection(Of AttachmentsRelation) = CType(Me.GetNewCollection(criteria), BaseCollection(Of AttachmentsRelation))
            Debug.Print(testrelations.Count & " Verknüpfungen zu entfernen")
            testrelations.Delete()

        End Sub

        ''' <summary>
        ''' Ruft aus der Liste der Anhänge einen bereits existierenden Anhang ab. Anhänge werden anhand eines Hash-Wertes eindeutig identifiziert.
        ''' </summary>
        ''' <param name="attachmentItem">Das zu prüfende Attachment</param>
        ''' <returns>Entweder ein Link auf ein bestehendes Attachment oder es wird der Eingangsparameter wieder zurückgegeben</returns>
        ''' <remarks></remarks>
        Public Function GetExistingAttachment(attachmentItem As Attachment) As Attachment
            'Falls irgendwo bereits eine Datei existiert, dann füge nur den Link ein
            Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = New BinaryOperator("HashValue", attachmentItem.HashValue, BinaryOperatorType.Equal)

            Dim testAttachments As Attachments = New Attachments(MainApplication, criteria)

            If testAttachments.Count > 0 Then
                ' Es gibt einen Eintrag mit der Datei
                Return testAttachments(0)

            Else
                ' Den eingehenden Anhang abrufen
                Return attachmentItem
            End If

        End Function

        ''' <summary>
        ''' Ruft eine Auflistung von Attachments für ein element mit dem angegeben Schlüssel ab
        ''' </summary>
        ''' <param name="sourceDocumentID">Die ReplikID des Datensatzes der die angehängten Daten enthält</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAttachmentsBySourceID(ByVal sourceDocumentID As String) As Generic.List(Of Attachment)
            Debug.Print("Suche Anhänge von element.Key:'" & sourceDocumentID & "'")

            Dim criteria As CriteriaOperator = CriteriaOperator.Parse("SourceDocumentID= '" & sourceDocumentID & "'")

            Dim attachmentRelations As New AttachmentsRelations(MainApplication, criteria)

            Return attachmentRelations.GetAttachments

        End Function
        Public Overrides Sub Reload()
            MyBase.Reload()

            BuildAttachmentList()

        End Sub
        ''' <summary>
        ''' Baut den Cache aller Attachment-Verbindungen neu auf
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub BuildAttachmentList()

            If Not Me.IsLoaded Then
                Me.Load()
            End If

            m_listOfSource.Clear()
            For Each item As AttachmentsRelation In Me
                If Not m_listOfSource.ContainsKey(item.SourceDocumentID) Then
                    m_listOfSource.Add(item.SourceDocumentID, New List(Of String))
                End If
                m_listOfSource(item.SourceDocumentID).Add(item.TargetAttachmentID)

            Next
        End Sub


        Protected Overrides Sub OnCollectionChanged(ByVal args As DevExpress.Xpo.XPCollectionChangedEventArgs)
            Debug.Print("collection changed:" & args.CollectionChangedType.ToString)
            MyBase.OnCollectionChanged(args)

            Dim item As AttachmentsRelation = CType(args.ChangedObject, AttachmentsRelation)


            Select Case args.CollectionChangedType
                Case XPCollectionChangedType.AfterAdd
                    If Not m_listOfSource.ContainsKey(item.SourceDocumentID) Then
                        m_listOfSource.Add(item.SourceDocumentID, New List(Of String))
                    End If
                    m_listOfSource(item.SourceDocumentID).Add(item.TargetAttachmentID)

                Case XPCollectionChangedType.AfterRemove
                    If m_listOfSource.ContainsKey(item.SourceDocumentID) Then
                        If m_listOfSource(item.SourceDocumentID).Contains(item.TargetAttachmentID) Then
                            m_listOfSource(item.SourceDocumentID).Remove(item.TargetAttachmentID)

                            If m_listOfSource(item.SourceDocumentID).Count = 0 Then
                                m_listOfSource.Remove(item.SourceDocumentID)
                            End If


                        End If
                    End If

            End Select

        End Sub

        ''' <summary>
        ''' Zeihgt an, ob es für einen gegebenene SourcedocumentID einen Anhanhang gibt.
        ''' es wird direkt eine neue datenbanksuche durchgeführt
        ''' </summary>
        ''' <param name="sourceDocumentID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function HasAttachments(ByVal sourceDocumentID As String) As Boolean
            Dim criteria As CriteriaOperator = CriteriaOperator.Parse("SourceDocumentID= '" & sourceDocumentID & "'")

            Dim attachmentRelations As New AttachmentsRelations(MainApplication, criteria)
            Return attachmentRelations.Count > 0

        End Function

        Public Overrides Sub Load()
            MyBase.Load()

        End Sub



        Public Function GetAttachments() As Generic.List(Of Attachment)
            Dim col As New Generic.List(Of Attachment)
            Dim colIDs As New List(Of String)

            'In einer Menge von IDs suchen

            Debug.Print("Suche nach den Attachments")
            ' Baue auflistung der gesuchten ReplikIDs zusammen (Performant, wenn mehrere gesucht werden)
            For Each relation As AttachmentsRelation In Me
                colIDs.Add(relation.TargetAttachmentID)
            Next
            Dim inCriteria As New DevExpress.Data.Filtering.InOperator("ReplikID", colIDs)
            Dim attachmentList As New Attachments(MainApplication, inCriteria)

            Debug.Print(attachmentList.Count & " Attachments gefunden")

            If attachmentList.Count = 0 Then
                ' Es gibt zwar ein Link - aber kein Attachment dazu => entferne die Links!

            End If

            For Each singleAttachment As Attachment In attachmentList
                col.Add(singleAttachment)
            Next

            Return col

        End Function

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)

            BuildAttachmentList()

            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As CriteriaOperator)

            MyBase.New(BasisApplikation, criteria)

            BuildAttachmentList()

            Initialize()
        End Sub




        Public Sub Initialize() Implements IDataCollection.Initialize

        End Sub
    End Class
End Namespace
