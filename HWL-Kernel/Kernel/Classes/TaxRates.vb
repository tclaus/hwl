Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Stellt eine Auflistung aller Steuersätze bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TaxRates
        Inherits BaseCollection(Of TaxRate)
        Implements IDataCollection

        Private Shared m_taxRate As New Dictionary(Of enumTaxKind, TaxRate)


        ''' <summary>
        ''' Ruft einen Steuersatz anhand de ID ab; Benutzt einen zwischenspeicher
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetItem(ByVal ID As Integer) As TaxRate

            Static taxCache As New Dictionary(Of Integer, TaxRate)

            If Not taxCache.ContainsKey(ID) Then
                taxCache.Add(ID, MyBase.GetItem(ID))
            End If

            Return taxCache(ID)

        End Function

        ''' <summary>
        ''' Ruft den Standard-Steuersatz ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNormalTax() As TaxRate
            If m_taxRate.ContainsKey(enumTaxKind.NormalTax) Then
                Return m_taxRate(enumTaxKind.NormalTax)
            Else
                'Dann den höchsten zurückliefern
                Dim maxVal As Decimal

                Dim highestTax As TaxRate = Nothing ' Erste zuweisung; in der schleife wird das aufgefüült

                For Each item As TaxRate In m_taxRate.Values
                    If highestTax Is Nothing Then
                        highestTax = item
                    End If
                    maxVal = item.TaxValue

                    If maxVal > highestTax.TaxValue Then
                        highestTax = item
                    End If

                Next

                Return highestTax
            End If

        End Function

        ''' <summary>
        ''' Läd die Liste der Steuersätze neu ein
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Reload()
            MyBase.Reload()

            ReloadInternalCache()

            ' Mindestends drei Steuersätze müsen vergeben sein!
            If m_taxRate.Count < 3 Then
                m_isInvalid = True
            Else
                m_isInvalid = False
            End If

        End Sub

        ''' <summary>
        ''' Ruft den Ermässsigten-Steuersatz ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReducedTax() As TaxRate
            If m_taxRate.ContainsKey(enumTaxKind.ReducedTax) Then
                Return m_taxRate(enumTaxKind.ReducedTax)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Ruft den Null-Steuersatz ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNullTax() As TaxRate

            If m_taxRate.ContainsKey(enumTaxKind.NullTax) Then
                Return m_taxRate(enumTaxKind.NullTax)
            Else
                Return Nothing
            End If

        End Function


        Public Sub New(ByVal BasisApplikation As mainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

        Public Sub Initialize() Implements IDataCollection.Initialize
            ' Die Steuersätze festlegen
            If Not Me.IsLoaded Then
                'Exit Sub
            End If

            If Me.CriteriaString Is Nothing Then
                ReloadInternalCache()

                    ' Mindestends drei steuersätze müsen vergeben sein!
                    If m_taxRate.Count < 3 Then
                        m_isInvalid = True
                    Else
                        m_isInvalid = False
                    End If

                End If


        End Sub


        ''' <summary>
        ''' Liefert 'wahr' zurück, wenn die Steuersätze nicht gültig sind (es wudn die Steuerarten nicht zugewiesen)
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsInvalid() As Boolean
            Return m_isInvalid
        End Function

        ''' <summary>
        ''' Mindestends die 3 Steuersätze sollten angegeben sein
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared m_isInvalid As Boolean

        ''' <summary>
        ''' Füllt die interne Liste der Steuerdaten auf
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ReloadInternalCache()
            m_taxRate.Clear()

            For Each taxItem As TaxRate In Me

                If Not m_taxRate.ContainsKey(taxItem.TaxStatus) Then
                    m_taxRate.Add(taxItem.TaxStatus, taxItem)
                End If

            Next
        End Sub

    End Class
End Namespace