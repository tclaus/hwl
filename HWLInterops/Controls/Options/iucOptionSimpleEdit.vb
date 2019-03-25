Imports ClausSoftware.Kernel
Imports ClausSoftware.Data



''' <summary>
''' Stellt einen einfachen editor für Simple Listen bereit
''' Eingaben / edit passiert direkt in der Liste
''' </summary>
''' <remarks></remarks>
Public Class iucOptionSimpleEdit
    Implements IOptionMenue


    Public Event Close(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub Initialize() Implements IOptionMenue.Initialize
        If MainApplication.getInstance Is Nothing Then
            modmain.InitializeApplication()
        End If
    End Sub

    Public Sub Reload() Implements IOptionMenue.Reload
        UicCommonGrid1.RefreshData()
    End Sub

    Public Sub Save() Implements IOptionMenue.Save
        If UicCommonGrid1.FocussedItem IsNot Nothing Then
            ' könnte sein, das dieses Element gerade gelöscht wurde
            If Not UicCommonGrid1.FocussedItem.IsDeleted Then
                UicCommonGrid1.FocussedItem.Save()
            End If

        End If
    End Sub



    ''' <summary>
    ''' Startet das Grid mit iner Liste des angegenbenen Types
    ''' </summary>
    ''' <param name="DataSource"></param>
    ''' <remarks></remarks>
    Friend Sub Init(ByVal DataSource As DataSourceList)
        UicCommonGrid1.Context = DataSource.ToString
        UicCommonGrid1.SetDataSource(DataSource)
        UicCommonGrid1.Editable = True

    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        RaiseEvent Close(Me, New EventArgs)

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        UicCommonGrid1.DeleteSelected()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim newItem As StaticItem = UicCommonGrid1.CreateNew()
        UicCommonGrid1.SelectItemByID(newItem.Key)



    End Sub

    Public Overrides Function ToString() As String
        Return Me.DisplayName
    End Function

    Public ReadOnly Property DisplayName() As String Implements IOptionMenue.DisplayName
        Get
            Return MainApplication.getInstance.Languages.GetText("Edit")
        End Get

    End Property

    Public ReadOnly Property NeedsRestart As Boolean Implements IOptionMenue.NeedsRestart
        Get
            Return False

        End Get
    End Property
End Class