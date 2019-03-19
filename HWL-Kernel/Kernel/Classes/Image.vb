Imports DevExpress.Xpo
Imports System.Drawing
Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Stellt eine Klasse dar, die Bilder und Dateien enthält
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(ImageData.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class ImageData
        Inherits StaticItem
        Implements IDataItem

        Public Const TableName As String = "Material_Bilder"

        Private m_image As Image
        Private m_delayedImage As XPDelayedProperty = New XPDelayedProperty()

        Private m_description As String


        ''' <summary>
        ''' Ist der Dateiname..
        ''' </summary>
        ''' <remarks></remarks>
        Private m_referenceID As String

        Private m_FilePath As String

        Private m_name As String

        Private m_date As Date


        'Private m_ParentArticles As Articles

        '<Association("ArticleToImageList", GetType(Article), useAssociationNameAsIntermediateTableName:=True)> _
        '       Public ReadOnly Property ParentArticle() As Articles
        '    Get
        '        GetCollection(Of Article)("ParentArticle")
        '    End Get

        'End Property


        ''' <summary>
        ''' Enthält das Datum der Datei
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("FileDate")> _
        Public Property FileDate() As Date
            Get
                Return m_date
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("FileDate", m_date, value)
            End Set
        End Property



        ''' <summary>
        ''' Ruft die Bildaten ab oder setzt diese
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Data")> _
        <Delayed("m_delayedImage")> _
        <ValueConverter(GetType(DevExpress.Xpo.Metadata.ImageValueConverter))> _
        Public Property Image() As System.Drawing.Image
            Get
                Try
                    Return CType(m_delayedImage.Value, Drawing.Image)
                Catch ex As Exception
                    Debug.Print("Error while getting Image from property Image: " & ex.Message)
                End Try

                Return My.Resources.no_picture

            End Get
            Set(ByVal value As Image)
                m_delayedImage.Value = value
                SetHaschanged()
            End Set
        End Property

        ''' <summary>
        ''' VerweisID- zu einem Stamm-Datensatz; kann mehrfach vorkommen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("VerweisID")> _
        Public Property ReferenceID() As String
            Get
                Return m_referenceID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReferenceID", m_referenceID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Abmessungen des Bildes ab, sofern vergeben
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Resolution() As String
            Get
                If m_delayedImage.IsLoaded Then
                    If Me.Image IsNot Nothing Then
                        Return Me.Image.Width & "x" & Me.Image.Height
                    Else
                        Return "nicht verfügbar"
                    End If

                Else
                    Return ""
                End If
            End Get
        End Property

        ''' <summary>
        ''' Originaler Dateiname des Bildes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Pfad")> _
        Public Property FilePath() As String
            Get
                If m_FilePath Is Nothing Then
                    m_FilePath = ""
                End If
                Return m_FilePath
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("FilePath", m_FilePath, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Namen der Datei ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Name")> _
        Property Name() As String
            Get
                If m_name Is Nothing Then
                    Me.Name = System.IO.Path.GetFileName(Me.FilePath)
                End If
                Return m_name
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Name", m_name, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft eine Text-Beschreibung der Datei ab, um den Inhalt wiederzugeben oder legt dies fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(200)> _
        <Persistent("Beschreibung")> _
        Property Description() As String
            Get
                Return m_description
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", m_description, value)
            End Set
        End Property

        ''' <summary>
        ''' setzt die Bilddaten anhand des übergebenen Filenames
        ''' </summary>
        ''' <param name="fileName">Vollständiger Pfad zum Bild</param>
        ''' <remarks></remarks>
        Public Sub SetByFile(ByVal fileName As String)
            If System.IO.File.Exists(fileName) Then
                Debug.Print("Lege ein Bild-Objekt an: " & fileName)


                Dim img As Image = System.Drawing.Image.FromFile(fileName)
                Me.Image = img

                Me.Description = System.IO.Path.GetFileName(fileName)
                Me.Name = System.IO.Path.GetFileName(fileName)
                Me.FileDate = System.IO.File.GetCreationTime(fileName)
                Me.FilePath = fileName ' Interessiert eigentlich nicht mehr


            End If
        End Sub



        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
End Namespace