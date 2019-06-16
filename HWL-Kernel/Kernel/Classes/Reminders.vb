Option Explicit On
Option Strict On
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering

Namespace Kernel


    ''' <summary>
    ''' Stellt eine Auflistung von Mahnungen / Mahntexten zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Reminders
        Inherits BaseCollection(Of Reminder)
        Implements IDataCollection
        Implements IGridFormatter


        ''' <summary>
        ''' Ruft das Kassenbuch mit dem gewählten Criterienausdruck ab
        ''' </summary>
        ''' <param name="baseapplication"></param>
        ''' <param name="criteriastr"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal baseapplication As MainApplication, ByVal criteriastr As String)

            MyBase.New(baseapplication, CriteriaOperator.Parse(criteriastr))
            Initialize()

        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal baseapplication As MainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(baseapplication, criteria)
            Initialize()

        End Sub

        ''' <summary>
        ''' Ruft die höchste Mahnstufe ab, die in dieser Auflistung verwedet wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastReminder() As Integer
            Get
                Dim maxLevel As Integer
                For Each item As Reminder In Me
                    maxLevel = Math.Max(item.RemindersLevel, maxLevel)
                Next
                Return maxLevel
            End Get
        End Property


        ''' <summary>
        ''' Ruft die höchst mögliche Mahnstufe ab. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property MaxReminersLevel() As Integer
            Get
                Return 3
            End Get
        End Property

        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder

            With DisplayProps
                Dim disp As New Text.StringBuilder


                Me.DisplayableProperties = disp.ToString


            End With

        End Sub



        Public Function GetFormatString(ByVal gridname As String) As String Implements IGridFormatter.GetFormatString
            Return ""
        End Function
    End Class

End Namespace