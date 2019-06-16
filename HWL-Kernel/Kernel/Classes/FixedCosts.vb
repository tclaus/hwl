Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Namespace Kernel


    ''' <summary>
    ''' Stellt eine Liste von Positionen dar.
    ''' Positionen verknüpfen Dokumenete und Artikel in Positionsgruppen zusammen.
    ''' </summary>
    ''' <remarks>Eine Position stellt eine Gruppe von Artikel dar.</remarks>
    Public Class FixedCosts

        Inherits BaseCollection(Of FixedCost)
        Implements IDataCollection
        Implements IGridFormatter


        ''' <summary>
        ''' Ruft die Kosten bis zum Jahresende (31.12) ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Gesamtkosten bis zum Jahresende")> _
        Public ReadOnly Property CostToYearsEnd() As Decimal
            Get

                Dim cost As Decimal
                For Each item As FixedCost In Me
                    cost += item.CostToYearsEnd
                Next

                Return cost
            End Get
        End Property

        <DisplayName("Gesamtkosten bis zum Jahresende")> _
Public ReadOnly Property CostToMonthEnd() As Decimal
            Get

                Dim cost As Decimal
                For Each item As FixedCost In Me
                    cost += item.CostPerYear
                Next

                Return cost
            End Get
        End Property

        ''' <summary>
        ''' Ruft die Gesamtkosten eines Jahres ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Gesamtkosten Jahr")> _
        Public ReadOnly Property TotalCostPerYear() As Decimal
            Get

                Dim cost As Decimal
                For Each item As FixedCost In Me
                    cost += item.CostPerYear
                Next

                Return cost
            End Get
        End Property

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)
            Initialize()
        End Sub


        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder
            DisplayProps.Append("Subject;")
            DisplayProps.Append("Group.GroupName;")

            DisplayProps.Append("IntervalText;")
            DisplayProps.Append("NextSchedule;")
            DisplayProps.Append("PeriodicalCost;")
            DisplayProps.Append("CostToYearsEnd;")

            Me.DisplayableProperties = DisplayProps.ToString
        End Sub

        ''' <summary>
        ''' Ruft für einzelne splaten einen Formatierungsstring ab. Dieser wird im Grid angezeigt
        ''' </summary>
        ''' <param name="gridname"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFormatString(ByVal gridname As String) As String Implements IGridFormatter.GetFormatString

            Select Case gridname
                Case "CostToYearsEnd" : Return "C"
                Case "PeriodicalCost" : Return "C"
                Case Else : Return ""
            End Select

        End Function
    End Class
End Namespace