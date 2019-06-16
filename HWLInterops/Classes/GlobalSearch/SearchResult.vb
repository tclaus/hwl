Namespace GlobalSearch
    ''' <summary>
    ''' Stellt ein Element der Suchergebnisse dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SearchResult


        Private m_key As String

        Private m_idNUmber As String

        Private m_description As String

        Private m_icon As System.Drawing.Image

        Private m_Type As String

        Private m_orgItem As Data.StaticItem
        ''' <summary>
        ''' Ruft das ursprüngliche Element ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property OrgItem() As Data.StaticItem
            Get
                Return m_orgItem
            End Get
        End Property

        ''' <summary>
        ''' Ruft einen Beshreibungsnamen des Typs des Dokumentes ab 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ItemTyp() As String
            Get
                Return m_Type
            End Get
            Set(ByVal value As String)
                m_Type = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Symbolbild für diese Typ ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Icon() As System.Drawing.Image
            Get
                Return m_icon
            End Get
            Set(ByVal value As System.Drawing.Image)
                m_icon = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_description
            End Get
            Set(ByVal value As String)
                m_description = value
            End Set
        End Property

        Public Property IDNumber() As String
            Get
                Return m_idNUmber
            End Get
            Set(ByVal value As String)
                m_idNUmber = value
            End Set
        End Property

        Public Property Key() As String
            Get
                Return m_key
            End Get
            Set(ByVal value As String)
                m_key = value
            End Set
        End Property



        Public Sub New(ByVal item As Data.StaticItem)
            If item IsNot Nothing Then
                Me.Description = item.ToString.Replace(vbCrLf, " ")
                Me.IDNumber = CStr(item.ID)
                Me.Key = item.Key
                Me.Icon = MainUI.GetItemSmallImage(item)
                Me.ItemTyp = MainUI.GetItemTypeName(item)

                m_orgItem = item
            End If

        End Sub
    End Class
End Namespace
