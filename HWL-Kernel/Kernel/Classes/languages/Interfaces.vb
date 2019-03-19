Namespace NLS
    ''' <summary>
    ''' Stellt eine schnittstelle bereit, die genau einen Schlüssel-Text paar enthält
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface INLSTextItem

        ''' <summary>
        ''' Enthält den eindeutigen Schlüssel, um einen Text zu identifizieren
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property NLSKey() As String
        ''' <summary>
        ''' Ruft den Text in der Zielsprache ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property NLSText() As String

        ''' <summary>
        ''' Ruft ein Beschreibung für den Übersetzer ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Description() As String

    End Interface

    ''' <summary>
    ''' Stellt eine Auflistung von Schlüssel-Text Paare in einer Sprache da
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface INLSTextItems
        ''' <summary>
        ''' Stellt die Auflistung von Texten bereit
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TextItems() As Dictionary(Of String, INLSTextItem)

        ''' <summary>
        ''' Ruft den 4-Stelligen ("DE-DE") LänderCode ab, um eine Sprache und Kultur festzulegen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property LanuguageCode() As String

    End Interface

End Namespace
