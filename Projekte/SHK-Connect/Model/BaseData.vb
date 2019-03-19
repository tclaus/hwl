
''' <summary>
''' Stellt allgemeine Klassen zur Verfügung zum Behandeln der Unternehemensdaten
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Friend MustInherit Class BaseData

    Friend MustOverride Sub Refresh()
    Friend MustOverride Sub LoadCache()


    Public Sub New()

    End Sub
End Class
