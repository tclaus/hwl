
''' <summary>
''' Stellt eine Schittstelle vereit, die berschreibt, wie das Grid Spalten formatieren soll
''' </summary>
''' <remarks></remarks>
Public Interface IGridFormatter

    ''' <summary>
    ''' Ruft den Formatierungsstring für eine genante Spalte (Propertyname) ab
    ''' </summary>
    ''' <param name="gridname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetFormatString(ByVal gridname As String) As String


End Interface
