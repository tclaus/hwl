Option Explicit On
Option Strict On

Imports ClausSoftware.Kernel

Namespace Data

    ''' <summary>
    ''' Stellt ein Interface bereit, das die Datenbankspalten enthält, die in jeder Klasse vorkommen.
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IStaticItemData

        ''' <summary>
        ''' Dynamisch zugewiesene ID des Datensatzes
        ''' </summary>
        Property ID() As Integer

        ''' <summary>
        ''' Primärschlüssel der Datenbank
        ''' </summary>
        Property ReplikID() As String
        ReadOnly Property Key() As String


    End Interface

    ''' <summary>
    ''' Stellt ein Interface bereit, das Klassen identifiziert, die Attachmets enthalten können
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IAttachments
        ''' <summary>
        ''' Ruft die Liste er Attachments ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Attachments() As Generic.List(Of Attachment)

        ''' <summary>
        ''' Ruft die Liste der attachment Links an, die zu diesem Objekt zeigen 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property AttachmentLinks() As AttachmentsRelations
        ''' <summary>
        ''' Ruft den eignen Schlüssel ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ReplikID() As String

    End Interface

End Namespace