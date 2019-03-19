Option Explicit On
Option Strict On
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering

Namespace Kernel


    ''' <summary>
    ''' Stellt eine Auflistung von Teilwerten mit unterschiedlichen Steuersatz zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class TaxValuePairs
        Inherits BaseCollection(Of TaxValuePair)
        Implements IDataCollection
        Implements IGridFormatter


        ''' <summary>
        ''' Ruft das Kassenbuch mit dem gewählten Criterienausdruck ab
        ''' </summary>
        ''' <param name="baseapplication"></param>
        ''' <param name="criteriastr"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal baseapplication As mainApplication, ByVal criteriastr As String)

            MyBase.New(baseapplication, CriteriaOperator.Parse(criteriastr))
            Initialize()

        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal baseapplication As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(baseapplication, criteria)
            Initialize()

        End Sub



        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder

            With DisplayProps
                Dim disp As New Text.StringBuilder
                disp.Append("Tax;")
                disp.Append("Value")


                Me.DisplayableProperties = disp.ToString


            End With

        End Sub



        Public Function GetFormatString(ByVal gridname As String) As String Implements IGridFormatter.GetFormatString
            Return ""
        End Function
    End Class

End Namespace