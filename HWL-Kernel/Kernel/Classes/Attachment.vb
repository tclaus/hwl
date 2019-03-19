Option Explicit On
Option Strict On


Imports DevExpress.Xpo
Imports ClausSoftware.Data
Imports System.IO
Imports System.Drawing

Namespace Kernel



    ''' <summary>
    ''' Enthält eine Datei
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(Attachment.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Attachment
        Inherits StaticItem
        Implements IDataItem

        Shared NotCompressableFiletypes() As String = {"zip", "gif", "jpg", "png", "pdf", "", "", "", "", "", "", "", "", "", "", "", "", ""}

        Friend Const Tablename As String = "Attachments"

#Region "Properties"

        'Private m_attachmentData As Byte() '? 
        Private m_createDate As DateTime
        Private m_note As String
        Private m_fileName As String
        Private m_shellIcon As XPDelayedProperty = New XPDelayedProperty()
        Private m_previewFile As XPDelayedProperty = New XPDelayedProperty()
        Private m_attachmentData As XPDelayedProperty = New XPDelayedProperty()
        Private m_size As Long


        Private m_hashValue As String
        ''' <summary>
        ''' Enthält einen Hashwert dieses Eintrages, damit kann das nachladen beschleunigt werden, indem aktuelle daten aus einem lokalen Cache geholt wird
        ''' oder um zu verhindern, das mehrfach dieselbe Datei eingecheckt wird.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        <System.ComponentModel.Browsable(False)> _
        <Indexed()> _
        <Persistent("HashValue")> _
        Public Property HashValue() As String
            Get

                If String.IsNullOrEmpty(m_hashValue) Then
                    m_hashValue = GetDataHashCode(CType(m_attachmentData.Value, Byte()))
                End If

                Return m_hashValue
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("HashValue", m_hashValue, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Dateinamen ab, der die zugrundeliegende Datei enthält
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <PersistentAlias("FileNameInternal")> _
        <Tools.DisplayName("Filename", "Dateiname")> _
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
        Public ReadOnly Property FileName() As String
            Get
                Return m_fileName
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Dateinamen ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>        
        <Persistent("FileName")> _
        Private Property FileNameInternal() As String
            Get
                Return m_fileName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FileNameInternal", m_fileName, value)

            End Set
        End Property


        ''' <summary>
        ''' Ruft eine Notiz der Datei ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(255)> _
        <Tools.DisplayName("Notice", "Bemerkung")> _
        <Persistent("Note")> _
        Public Property Note() As String
            Get
                Return m_note
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Note", m_note, value)

            End Set
        End Property

        Function GetDataHashCode(ByVal data As Byte()) As String
            Dim h As New System.Security.Cryptography.SHA512Managed()
            Dim dataBytes() As Byte = h.ComputeHash(data)
            Return Convert.ToBase64String(dataBytes)

        End Function

        Public Overrides Sub Save()
            If Me.HasChanged Then
                MyBase.Save()

                MainApplication.SendMessage(MainApplication.Languages.GetText("msgCommonelementSaved", "Gespeichert: '{0}'", Me.ToString))
            End If

        End Sub


        <Tools.DisplayName("CreateDate", "Erstellungsdatum")> _
        <Persistent("CreateDate")> _
        Public Property CreateDate() As DateTime
            Get
                Return m_createDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CreateDate", m_createDate, value)

            End Set
        End Property

        ''' <summary>
        ''' Ruft die Nutzdaten ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>es sollte kein direkter Zugriff auf diese Daten geben</remarks>
        <ClausSoftware.Tools.DisplayName("DataField", "Datensatz")> _
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        <Delayed("m_attachmentData")> _
        <Persistent("Data")> _
        Friend Property AttachmentData() As Byte()
            Get

                Return CType(m_attachmentData.Value, Byte())
            End Get
            Set(ByVal value As Byte())
                m_attachmentData.Value = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Grösse der angehängten Datei ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("Size", "Größe")> _
        <Persistent("Size")> _
        Public Property Size() As Long
            Get
                Return m_size
            End Get
            Set(ByVal value As Long)
                SetPropertyValue(Of Long)("size", m_size, value)

            End Set
        End Property
        ''' <summary>
        ''' Ruft eine Datei in einem temporäären Ordner ab, stellt den Pfadnamen bereit
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFile() As String

            Dim fullpath As String = Path.Combine(Path.GetTempPath, Me.FileName)

            Return UncompressFile(fullpath)

        End Function

        ''' <summary>
        ''' Speichert das Attachment in den angegebenen Pfad
        ''' </summary>
        ''' <param name="targetPath"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFile(ByVal targetPath As String) As String
            If Directory.Exists(targetPath) Then
                Dim fullpath As String = Path.Combine(targetPath, Me.FileName)

                Return UncompressFile(fullpath)
            Else
                Return ""
            End If
        End Function

        Private Function UncompressFile(ByVal targetfullpath As String) As String


            Dim sw As New Stopwatch
            sw.Start()
            If Array.IndexOf(NotCompressableFiletypes, Path.GetExtension(FileName).ToLower) <> -1 Then
                Dim ms As New MemoryStream(Me.AttachmentData)
                Dim gzip As New System.IO.Compression.GZipStream(ms, Compression.CompressionMode.Decompress)

                Dim expandedData() As Byte = ReadAllBytesFromStream(gzip)
                gzip.Close()
                File.WriteAllBytes(targetfullpath, expandedData)
            Else
                File.WriteAllBytes(targetfullpath, Me.AttachmentData)
            End If

            sw.Stop()
            Debug.Print("Unzip-Dauer:" & sw.Elapsed.ToString)

            Return targetfullpath

        End Function


        Private Shared Function ReadAllBytesFromStream(ByVal stream As Stream) As Byte()

            Dim buffer(4096) As Byte

            Dim offset As Integer = 0
            Dim totalCount As Integer = 0
            Using ms As New MemoryStream


                While True
                    Dim bytesRead As Integer = stream.Read(buffer, 0, buffer.Length)
                    If bytesRead = 0 Then
                        Exit While
                    End If
                    ms.Write(buffer, 0, bytesRead)
                End While
                Return ms.ToArray
            End Using

        End Function 'ReadAllBytesFromStream


        ''' <summary>
        ''' Löscht dieses Attachment, und räumt alle Verknüpfungen auf
        ''' </summary>
        ''' <remarks></remarks>
        Shadows Sub Delete()
            Dim relations As New AttachmentsRelations(MainApplication)
            relations.CriteriaString = "TargetAttachmentID='" & Me.ReplikID & "'"
            Debug.Print("Lösche Attachment und Verknüpfung")
            If relations.Count = 1 Then
                relations(0).Delete()
            End If

            MyBase.Delete()


        End Sub

        ''' <summary>
        ''' Ruft das aktuelle Datei-Icon ab oder legt es fest; 
        ''' Wird normalerweise bereits beim einfügen der DAtei von der Windows-Shell ermittelt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("Icon", "Symbol")> _
        <Delayed("m_shellIcon")> _
        <ValueConverter(GetType(DevExpress.Xpo.Metadata.ImageValueConverter))> _
        <Persistent("ShellIcon")> _
        Public Property Icon() As System.Drawing.Image
            Get
                Return CType(m_shellIcon.Value, Image)
            End Get
            Set(ByVal value As System.Drawing.Image)
                m_shellIcon.Value = value

            End Set
        End Property

        ''' <summary>
        ''' Ruft das Vorschaubild der Datei ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("PreviewImage", "Vorschau")> _
        <Delayed("m_previewFile")> _
       <ValueConverter(GetType(DevExpress.Xpo.Metadata.ImageValueConverter))> _
       <Persistent("PreviewFile")> _
        Public Property PreviewFile() As System.Drawing.Image
            Get
                Return CType(m_previewFile.Value, Image)
            End Get
            Set(ByVal value As System.Drawing.Image)
                m_previewFile.Value = value
            End Set
        End Property


        ''' <summary>
        ''' Schreibt eine Datei in dieses Attachment, bestehende Dateien werden überschrieben.
        ''' Der Dateiname wird weiter genutzt
        ''' </summary>
        ''' <param name="filename"></param>
        ''' <remarks></remarks>
        Public Sub SetFile(ByVal filename As String)

            If My.Computer.FileSystem.FileExists(filename) Then
                Dim orgFilesize As Long
                Dim sw As New Stopwatch
                sw.Start()

                Me.AttachmentData = File.ReadAllBytes(filename)
                Me.Size = Me.AttachmentData.Length
                orgFilesize = Me.Size

                ' setze das Icon der Datei un dsichere es in der DAtenbank
                Dim ico As System.Drawing.Icon = ClausSoftware.Tools.ShellIcon.GetLargeIcon(filename)
                If ico IsNot Nothing Then
                    Me.Icon = ico.ToBitmap
                Else
                    Me.Icon = Nothing
                End If

                Me.PreviewFile = Tools.ShellInterop.GetThumbnailImage(filename, 500, 32)

                If Me.PreviewFile Is Nothing Then ' Wenn keine Vorschau erzeugt werfen konnte, dann das icon verwenden
                    Me.PreviewFile = Me.Icon
                End If

                ' Nur komprimierbare Dateitypen verwenden
                If Array.IndexOf(NotCompressableFiletypes, Path.GetExtension(filename).ToLower) <> -1 Then

                    Using ms As New MemoryStream
                        Using gzip As New System.IO.Compression.GZipStream(ms, Compression.CompressionMode.Compress)

                            gzip.Write(Me.AttachmentData, 0, Me.AttachmentData.Length)
                            gzip.Close()
                        End Using

                        Me.AttachmentData = ms.GetBuffer
                    End Using
                End If

                Me.Size = Me.AttachmentData.Length
                sw.Stop()
                Debug.Print("Zip-Dauer:" & sw.Elapsed.ToString)
                Debug.Print("CompressionRatio (Orgsize/CompressSize):" & orgFilesize & "/" & Me.Size & ", " & Math.Round(Me.Size / 1024, 2) & "Kb (" & Me.Size / orgFilesize & ")")

                Me.FileNameInternal = Path.GetFileName(filename)
                Me.CreateDate = File.GetCreationTimeUtc(filename)
                Me.HashValue = GetDataHashCode(CType(m_attachmentData.Value, Byte()))

            Else
                Throw New FileNotFoundException(filename)
            End If
        End Sub

        ''' <summary>
        ''' Liefert True, wenn Daten existieren
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function DataExist() As Boolean

            If Not String.IsNullOrEmpty(FileName) Then

                Return (FileName.Length > 0)

            Else
                Return False
            End If


        End Function

        ''' <summary>
        ''' Erzeugt ein Vorschaubild durch die Windows-API
        ''' </summary>
        ''' <param name="fullPath"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateThumnail(ByVal fullPath As String) As Image
            Try
                Return Tools.ShellInterop.GetThumbnailImage(fullPath, 500, 32)
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            Return My.Resources.no_picture
        End Function


#End Region


        Public Overrides Function ToString() As String
            Return Me.FileName
        End Function



        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace
