Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering

Namespace Kernel


    ''' <summary>
    ''' Enthält eine Auflistung von Bildern aus der Datenbank
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Images
        Inherits BaseCollection(Of ImageData)
        Implements IDataCollection


        ''' <summary>
        ''' Ruft eine Auflistung aller Bilder ab, die an dieser ReferenzID geheftet sind
        ''' </summary>
        ''' <param name="referenceID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReferencedImage(ByVal referenceID As String) As ImageData()
            Dim imageList As New Images(MainApplication)
            Dim criteria As CriteriaOperator = CriteriaOperator.Parse("ReferenceID = '" & referenceID & "'")

            imageList.Criteria = criteria
            If imageList.Count > 0 Then
                Dim result(imageList.Count - 1) As ImageData

                Dim index As Integer
                For Each imgData As ImageData In imageList
                    result(index) = imgData
                    index += 1
                Next

                Return result
            Else
                Return New ImageData() {}
            End If


        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize

        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication)
            MyBase.New(BasisApplikation)
            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

    End Class
End Namespace