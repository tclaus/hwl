
Imports DevExpress.Xpo
Namespace Data

    ''' <summary>
    ''' Stellt BasisDienstleistungen bereit, die jede Applikation benötigt
    ''' </summary>
    ''' <remarks></remarks>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
    <DefaultMembersPersistence(DefaultMembersPersistence.OnlyDeclaredAsPersistent)> _
    <NonPersistent()> _
    Public MustInherit Class BaseClass
        Inherits XPLiteObject

        ''' <summary>
        ''' Enthältr eine Auflistung von Tabellen, die ein Liste der Spalten und deren maximale grösse enthält
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared ColumnSizes As New Dictionary(Of String, Dictionary(Of String, Integer))

        ''' <summary>
        ''' Stellt den globalen Verweis auf das Stammobjekt zur Verfügung
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Friend Shared m_mainApplication As MainApplication

        'Private Function Getsize(tablename As String, columnName As String) As Integer

        'End Function


        'Public sub SetPropertyValue(Of string)(propertyName As String, value As string)

        '    MyBase.SetPropertyValue(Of String)(propertyName, value)
        '    Dim m As DevExpress.Xpo.Metadata.XPMemberInfo



        'End Sub

        ''' <summary>
        ''' Ruft einen Text ab
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function GetText(ByVal key As String) As String
            Return m_mainApplication.Languages.GetText(key)
        End Function

        ''' <summary>
        ''' Ruft einen Text anhand des Schlüssels ab, übergibt einen standard-Text
        ''' </summary>
        ''' <param name="key"></param>
        ''' <param name="defaultText"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Function GetText(ByVal key As String, ByVal defaultText As String) As String
            Return m_mainApplication.Languages.GetText(key, defaultText)
        End Function

        ''' <summary>
        ''' Enthält die Basis-Klasse der Applikation
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        <ComponentModel.Browsable(False)> _
        <NonPersistent()> _
        Public ReadOnly Property MainApplication() As MainApplication
            <DebuggerStepThrough()> _
            Get
                Return m_mainApplication
            End Get

        End Property

        ''' <summary>
        ''' Erstellt eine neue instanz des ständigen Objektes
        ''' </summary>
        ''' <remarks></remarks>
        Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub



        Public Sub New()
            ' nichts; solllte nie aufgerufen werden !
        End Sub

    End Class

End Namespace