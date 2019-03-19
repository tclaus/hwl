''' <summary>
''' Stellt einen Type des Attributes dar
''' </summary>
''' <remarks></remarks>
Public Enum enumAttributeType

    ''' <summary>
    ''' Beliebiger Text (Max 255 Zeichen)
    ''' </summary>
    ''' <remarks></remarks>
    <DisplayName("Alphanummerisch")> _
    Alphanummeric

    ''' <summary>
    ''' Eine ganze Zahl
    ''' </summary>
    ''' <remarks></remarks>
    <DisplayName("Nummerisch")> _
    Nummeric

    ''' <summary>
    ''' Zahl mit Nachkommaanteil
    ''' </summary>
    ''' <remarks></remarks>
    <DisplayName("Fliesskommazahl")> _
    Float

    ''' <summary>
    ''' Ein Wahrheitsfeld (Checkbox)
    ''' </summary>
    ''' <remarks></remarks>
    <DisplayName("Ja/Nein")> _
    YesNo

    ''' <summary>
    ''' Ein Datum-Typ
    ''' </summary>
    ''' <remarks></remarks>
    <DisplayName("Datum")> _
    DateType
    ''' <summary>
    ''' Einen aus N auswählen
    ''' </summary>
    ''' <remarks></remarks>
    <DisplayName("Einen wählen")> _
    ChooseOne

    ''' <summary>
    ''' Mehrere Optionen wählen (nicht verwendet derzeit)
    ''' </summary>
    ''' <remarks></remarks>
    <DisplayName("Mehrere wählen")> _
    ChooseSome

End Enum
