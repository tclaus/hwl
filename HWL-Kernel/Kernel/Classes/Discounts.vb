Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo

Namespace Kernel

    ''' <summary>
    ''' Enthält eine Auflistung von Kurztexte, Aufgaben 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Discounts
        Inherits BaseCollection(Of Discount)
        Implements IDataCollection


        Public Sub New(ByVal BasisApplikation As MainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        ''' <summary>
        ''' Ruft den Rabatt ab, der durch diese Datanorm-ID gekennzeichnet wurde
        ''' </summary>
        ''' <param name="key">Der Schlüselwert dieses Rabattsatzes</param>
        ''' <param name="creatorID"> Der Datanorm-Ersteller (Kürzel)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetByDTNKey(key As String, creatorID As String) As Discount
            For Each item As Discount In Me

                If item.DTNDiscountID.Equals(key, StringComparison.OrdinalIgnoreCase) And _
                    item.DTNErsteller.Equals(creatorID) Then
                    Return item
                End If

            Next

            Return Nothing
        End Function

        ''' <summary>
        ''' Ruft den Rabatt ab, der durch diese Datanorm-ID gekennzeichnet wurde
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetByDTNKey(key As String) As Discount
            For Each item As Discount In Me

                If item.DTNDiscountID.Equals(key, StringComparison.OrdinalIgnoreCase) Then Return item

            Next

            Return Nothing
        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim display As New Text.StringBuilder
            display.Append("Name;")
            display.Append("DiscountValue;")
            Me.DisplayableProperties = display.ToString


        End Sub
    End Class
End Namespace