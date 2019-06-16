Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering



Namespace Kernel

    ''' <summary>
    ''' Enthält die Tabelle der Teilzahlungen (Splittbuchungen)
    ''' </summary>
    ''' <remarks></remarks>
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class DownPayments
        Inherits BaseCollection(Of DownPayment)
        Implements IDataCollection

        Private m_unitListByID As New Dictionary(Of Integer, Unit)

        ''' <summary>
        ''' Enthält die übergeordnete Transaktion, sofern diese Auflistung davon abgeleitet wurde
        ''' </summary>
        ''' <remarks></remarks>
        Private m_parentTransaction As Transaction




        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim display As New Text.StringBuilder
            display.Append("PaidDate;")
            display.Append("Description;")
            display.Append("Ammount;")
            Me.DisplayableProperties = display.ToString

            Me.Sorting.Clear()
            Me.Sorting.Add(New SortProperty("PaidDate", DB.SortingDirection.Descending))


        End Sub

        ''' <summary>
        ''' Ruft die summe der bezahlten Beträge in dieser Auflistung ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TotalPaidAmmount() As Decimal
            Dim sum As Decimal
            For Each item As DownPayment In Me
                sum += item.Ammount
            Next
            Return sum
        End Function

        ''' <summary>
        ''' Ruft das letzte Bezahlt-Datum aus der Auflistung ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastPaymentDate As DateTime
            Get
                Dim lastPaidDate As DateTime
                For Each item As DownPayment In Me
                    If item.PaidDate > lastPaidDate Then
                        lastPaidDate = item.PaidDate
                    End If
                Next
                Return lastPaidDate

            End Get
        End Property

        ''' <summary>
        ''' Ruft eine Auflistung der Teilzahlungen für die angegebene TRansaktion ab 
        ''' </summary>
        ''' <param name="parentTransaction">Ein Verweis auf die Ausgangsbuchung</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDownPaymentsForItem(ByVal parentTransaction As Transaction) As DownPayments

            Dim appdata As MainApplication = BaseClass.m_mainApplication

            Dim Payments As DownPayments = New DownPayments(appdata, parentTransaction)
            Payments.Sorting.Clear()
            Payments.Sorting.Add(New SortProperty("PaidDate", DB.SortingDirection.Descending))

            If parentTransaction.IsPaid Then
                ' Kontrolle, ob das Datum gesetzt ist
                If parentTransaction.PaidDate = DateTime.MinValue Then
                    parentTransaction.PaidDate = Payments.LastPaymentDate
                    parentTransaction.SaveInternal()
                End If
            End If

            If parentTransaction.PaidAmmount <> 0 And Payments.Count = 0 Then
                ' Ein Bezahlt - Anteil, aber keine Zahlungseingänge kann auch nicht sein
                parentTransaction.PaidAmmount = 0
                parentTransaction.UnpaidAmmount = parentTransaction.TotalAmmount
                parentTransaction.SaveInternal()
            End If

            Return Payments
        End Function

        ''' <summary>
        ''' Aktualisiert die Summen der Ausgangsrechnung anhand der Bezahlten Beträge. Einzahlungen steuern die Gezahlt- und unbezahlten Beträge der Transaktion
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RefreshParentTransaction()
            Me.ParentTransaction.PaidAmmount = TotalPaidAmmount()
            Me.ParentTransaction.UnpaidAmmount = Math.Round(Me.ParentTransaction.TotalAmmount - Me.ParentTransaction.PaidAmmount, 2)


            If ParentTransaction.UnpaidAmmount = 0 Then
                ParentTransaction.IsPaidInternal = True

                ' Die eigenschaft kann nicht gesetzt erden, da diese auch die Zahlungseingänge und das Datum verändert!
            Else
                ParentTransaction.IsPaidInternal = False

            End If
        End Sub

        ''' <summary>
        ''' Entfernt alle Elemente aus der Auflistung
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RemoveAll()
            For Each item As DownPayment In Me
                Me.Remove(item)
            Next
        End Sub

        ''' <summary>
        ''' Speichert die Liste der Teilzahlungen ab. 
        ''' Für eine aktualiserung der übergeordneten TRansaktion muss ein RefreshParentTransaction aufgerufen werden
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()

            MyBase.Save()

        End Sub

        ''' <summary>
        ''' Ruft die Transaktion ab, zu der diese Auflistung die Teilzahlungen enthält
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentTransaction() As Transaction
            Get
                Return m_parentTransaction
            End Get

        End Property

        ''' <summary>
        ''' Erstellt eine neue Auflistung der Klasse mit dem angegeben übergeodnetem Transaktion
        ''' </summary>
        ''' <param name="BasisApplikation"></param>
        ''' <param name="parentTransaction"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal parentTransaction As Transaction)
            MyBase.New(BasisApplikation, DevExpress.Data.Filtering.CriteriaOperator.Parse("TransactionID=" & parentTransaction.ID))
            m_parentTransaction = parentTransaction
            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub



        Public Sub New(ByVal BasisApplikation As MainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub
    End Class
End Namespace