Namespace NLS
    ''' <summary>
    ''' Ruft ein Textelement ab, das durch einen eindeutigen Schlüssel einen Text enthält
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class NLSTextItem
        Implements INLSTextItem

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_descripion As String
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_key As String
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_text As String


        ''' <summary>
        ''' Ruft ein Beschreibung für den Übersetzer ab oder legt dieses fest
        ''' </summary>
        Public Property Description() As String Implements INLSTextItem.Description
            Get
                Return m_descripion
            End Get
            Set(ByVal value As String)
                m_descripion = value
            End Set
        End Property

        ''' <summary>
        ''' Enthält den eindeutigen Schlüssel, um einen Text zu identifizieren
        ''' </summary>
        Public Property NLSKey() As String Implements INLSTextItem.NLSKey
            Get
                Return m_key
            End Get
            Set(ByVal value As String)
                m_key = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Text in der Zielsprache ab oder legt diesen fest
        ''' </summary>
        Public Property NLSText() As String Implements INLSTextItem.NLSText
            Get
                Return m_text
            End Get
            Set(ByVal value As String)
                m_text = value
            End Set
        End Property
    End Class

    <Serializable()> _
    Public Class NLSTextItems
        Implements INLSTextItems

        Private m_texts As New Dictionary(Of String, INLSTextItem)
        Private m_cultureCode As String

        ''' <summary>
        ''' Ruft den 4-Stelligen Länder-KulturCode einer Sprache ab. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LanuguageCode() As String Implements INLSTextItems.LanuguageCode
            Get
                Return m_cultureCode
            End Get
            Set(ByVal value As String)
                m_cultureCode = value

            End Set
        End Property

        ''' <summary>
        ''' Enthält eine Auflistung der Texte in dieser Kultur
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TextItems() As System.Collections.Generic.Dictionary(Of String, INLSTextItem) Implements INLSTextItems.TextItems
            Get
                Return m_texts
            End Get

        End Property
    End Class

End Namespace
