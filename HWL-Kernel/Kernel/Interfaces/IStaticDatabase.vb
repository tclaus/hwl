''' <summary>
''' Stellt ein Interface zur Verfügung, das allgemeine Datenelemente beschreibt
''' </summary>
''' <remarks></remarks>
Public Interface IDataItem

End Interface

''' <summary>
''' Zeigt an, das eine Klasse mit diesem Interface eine "IsActive" - Eigenschaft besitzt und entsprechend markiert werden kann
''' </summary>
''' <remarks></remarks>
Public Interface IHasActiveProperty
    Property IsActive As Boolean
End Interface