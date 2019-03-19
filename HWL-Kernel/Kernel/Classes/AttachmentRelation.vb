Option Explicit On
Option Strict On


Imports DevExpress.Xpo
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering


Namespace Kernel

    ''' <summary>
    ''' Enthält einen Verweis einer Quell-ID zu einer Datensatz-ID
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(AttachmentsRelation.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class AttachmentsRelation
        Inherits StaticItem
        Implements IDataItem

        Friend Const Tablename As String = "AttachmentsRelations"

#Region "Properties"

        Private m_sourceID As String
        Private m_targetID As String

        ''' <summary>
        ''' Enthält den Datensatz, an dem dieser Anhang gebunden wird
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed("TargetAttachmentID", Unique:=True)> _
        <Persistent("SourceID")> _
        Property SourceDocumentID() As String
            Get
                Return m_sourceID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SourceDocumentID", m_sourceID, value)
            End Set
        End Property

        ''' <summary>
        ''' Enthält einen Verweis auf die ID eines Anhanges
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(32)> _
        <Persistent("TargetID")> _
        Property TargetAttachmentID() As String
            Get
                Return m_targetID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TargetAttachmentID", m_targetID, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Anhang dieser Verbindung ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAttachment() As Attachment

            Dim criteria As CriteriaOperator = CriteriaOperator.Parse("ReplikID='" & Me.TargetAttachmentID & "'")

            Dim attachments As New Attachments(m_mainApplication, criteria)


            If attachments.Count = 1 Then
                Return attachments(0)
            Else
                Return Nothing
            End If


        End Function

#End Region


        Public Overrides Function ToString() As String
            Return ""
        End Function


        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub


    End Class
End Namespace
