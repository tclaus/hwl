
''' <summary>
''' Stellt Funktionen bereit für die Verwaltung von Dokumente
''' </summary>
''' <remarks></remarks>
Public Class iucOptionDocuments
    Implements IOptionMenue

    Public ReadOnly Property DisplayName As String Implements IOptionMenue.DisplayName
        Get
            Return "Dokumente"
        End Get
    End Property

    Public Sub Initialize() Implements IOptionMenue.Initialize

    End Sub

    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False
        End Get
    End Property

    Public Sub Reload() Implements IOptionMenue.Reload

    End Sub

    Public Sub Save() Implements IOptionMenue.Save

    End Sub
End Class
