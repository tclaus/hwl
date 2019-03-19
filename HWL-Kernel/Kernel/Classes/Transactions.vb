Option Explicit On
Option Strict On
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering

Namespace Kernel


    ''' <summary>
    ''' Stellt eine Auflistung von Forderungen / Verbindlichkeiten dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Transactions
        Inherits BaseCollection(Of Transaction)
        Implements IDataCollection
        Implements IGridFormatter

        Private m_transactionSums As New TransactionSum

        ''' <summary>
        ''' Ruft ein neuen Geschäftsvorfall ab 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As Transaction
            Dim newItem As Transaction = MyBase.GetNewItem()
            newItem.ItemDate = Date.Now
            newItem.IsPaidInternal = False
            Return newItem
        End Function


        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As String)

            MyBase.New(BasisApplikation, CriteriaOperator.Parse(criteria))

            Initialize()

        End Sub


        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        ''' <summary>
        ''' Ruft eine Auflistung an zuletzt verwendete Buchungstexte ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetListOfTexts() As String()

            Return MyBase.GetListOfColumn(Transaction.TableName, "Text")

        End Function


        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder

            With DisplayProps

                .Append("ID;") ' Als Index-Nummer
                .Append("ItemDate;")
                .Append("MoneyFlow;")
                .Append("ItemDisplayNumber;")
                .Append("Adress.InvoiceAdressWindow;")
                .Append("CashAccount.AccountNumber;")
                .Append("CashAccount.AccountName;")

                .Append("Text;")

                '.Append("Summe")

                .Append("PaidAmmount;") ' Bezahlter Anteil am Betrag

                .Append("UnpaidAmmount;") ' Noch unbezahlter Anteil am Betrag
                .Append("TotalAmmount;")  ' Gesamtsumme um die es geht
                .Append("IsPaid;")          ' Ist "wahr", wenn der Betrag vollständig (Paid=TotalAmmount) ist

                .Append("TargetPayDate;")
                .Append("PaidDate;")
                .Append("TaxItem.TaxValue;")
                .Append("IsIntern;")  ' Interne Rechnung
                .Append("IsCanceled;")


                Me.DisplayableProperties = .ToString

                Me.FullTextSearchColumns = New String() {"ItemDisplayNumber", "Adress.InvoiceAdressWindow", "Text"}

            End With

        End Sub

        ''' <summary>
        ''' Ruft die Jahreszahlen ab,zu denen Buchungn existieren
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemYears() As String()

            Dim lst As New List(Of String)
            For Each item As Transaction In Me
                If Not lst.Contains(CStr(item.ItemDate.Year)) Then
                    lst.Add(CStr(item.ItemDate.Year))
                End If
            Next
            Return lst.ToArray
        End Function

        ''' <summary>
        ''' Ruft für eine benannte Spalte einen Formatierungsstring ab. damit können Währungsformate an die Textfelder übergeben werden
        ''' </summary>
        ''' <param name="gridname"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFormatString(ByVal gridname As String) As String Implements IGridFormatter.GetFormatString

            Select Case gridname
                Case "PaidAmmount", "UnpaidAmmount", "TotalAmmount" : Return "C"
                Case Else : Return ""


            End Select


        End Function

        ''' <summary>
        ''' Berechnet die Summen für dieses Objekt neu
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CalculateSums()

            m_transactionSums.Reset()

            ' Hier eine Auflistung aller Steuersätze abholen
            Dim taxCriteriaString As String = "Targettype=2"
            Dim taxItems As New Kernel.TransactionTaxPairs(MainApplication, taxCriteriaString)


            Dim taxByValue As New Dictionary(Of Decimal, TaxRate)
            ' Steuerklassen anhand des Steuersatzes merken...  Und dann später der Forderung zuweisen
            For Each tax As TaxRate In MainApplication.TaxRates
                If Not taxByValue.ContainsKey(tax.TaxValue) Then
                    taxByValue.Add(tax.TaxValue, tax)
                End If

            Next

            'PERFORMANCE: NIcht immer ein neues Objekt erzeugen lassen, diese stattdessen lokal suchen 
            For Each item As Transaction In Me

                If item.IsCanceled Then Continue For ' Nicht für Stornierte Elemente

                taxItems.Filter = CriteriaOperator.Parse("ParentID = " & item.ID) ' Nur die Steuersätze dieses Elementes abholen lasen 

                If taxItems.Count > 0 Then

                    For Each taxItem As TaxValuePair In taxItems
                        If taxItem.Tax IsNot Nothing Then

                            If Not m_transactionSums.TaxList.ContainsKey(taxItem.Tax.ID) Then
                                m_transactionSums.TaxList.Add(taxItem.Tax.ID, taxItem)
                            Else
                                m_transactionSums.TaxList(taxItem.Tax.ID).Value += taxItem.Value ' Hier die Steuersätze aufaddieren
                            End If
                        End If


                    Next
                Else
                    ' Dann den einzigen Steuersatz ermitteln
                    If item.TaxItem Is Nothing Then
                        ' Na dann mal suchen... 
                        If Not taxByValue.ContainsKey(CDec(item.TaxValue)) Then
                            ' Der Steuersatz existierte nicht (mehr) in der Steuern-Auflistung, dann neu anlegen
                            Dim newTax As New TaxRate(MainApplication.Session)
                            newTax.TaxValue = CDec(item.TaxValue)
                            newTax.Name = item.TaxValue.ToString
                            newTax.Save()
                            taxByValue.Add(CDec(item.TaxValue), newTax)
                        End If
                        item.TaxItem = taxByValue(CDec(item.TaxValue))

                        item.Save()
                    End If

                    Dim taxItem As TaxValuePair = New TaxValuePair(MainApplication.Session)
                    taxItem.Tax = item.TaxItem
                    taxItem.Value = item.TotalAmmount
                    taxItem.TaxValue = CDec(item.TaxValue)
                    taxItem.Targettype = TargetTaxValuePair.Transactions
                    If Not taxItem.Tax Is Nothing Then
                        If Not m_transactionSums.TaxList.ContainsKey(taxItem.Tax.ID) Then
                            m_transactionSums.TaxList.Add(taxItem.Tax.ID, taxItem)
                        Else
                            m_transactionSums.TaxList(taxItem.Tax.ID).Value += taxItem.Value ' Hier die Steuersätze aufaddieren
                        End If
                    Else
                        ' IMPORTANT: MISSING TAXRATE
                        ' Kann vorkommen, das es keinen Steuersatz mit diesm Wert gibt => Anlegen ? 

                    End If


                End If



                If item.MoneyFlow = MoneyFlow.IsPayable Then


                    m_transactionSums.PaidAmmountOutbound += item.PaidAmmount
                    If Not item.IsPaidInternal Then
                        m_transactionSums.UnpaidAmmountOutbound += item.UnpaidAmmount
                    End If
                    m_transactionSums.PaidAmmountOutboundTaxes += item.PaidAmmount - CDec(item.PaidAmmount / (1 + item.TaxValue / 100))
                    m_transactionSums.UnpaidAmmountOutboundTaxes += item.UnpaidAmmount - CDec(item.UnpaidAmmount / (1 + item.TaxValue / 100))
                Else
                    m_transactionSums.PaidAmmountInbound += item.PaidAmmount
                    If Not item.IsPaidInternal Then
                        m_transactionSums.UnpaidAmmountInbound += item.UnpaidAmmount
                    End If

                    m_transactionSums.PaidAmmountInboundTaxes += item.PaidAmmount - CDec(item.PaidAmmount / (1 + item.TaxValue / 100))
                    m_transactionSums.UnpaidAmmountInboundTaxes += item.UnpaidAmmount - CDec(item.UnpaidAmmount / (1 + item.TaxValue / 100))

                End If
                '119-  119 /1.19
                '119-100
            Next
        End Sub



        ''' <summary>
        ''' Ermittelt aus der aktuellen Auflistung die Summe der gezahlten Beträge
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function SumAmmount() As TransactionSum
            CalculateSums()
            Return m_transactionSums
        End Function

        ''' <summary>
        ''' Ruft eine neue Auflistung der Transaktionen ab
        ''' </summary>
        ''' <param name="criteria"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewCollection(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator) As Data.BaseCollection(Of Transaction)
            Dim newTransactionList As New Transactions(MainApplication, criteria)
            Return newTransactionList
        End Function

    End Class

    ''' <summary>
    ''' Stellt eine Klasse zur Verfügung, die die aktuellen Summen der Forderungen und Verbindlichkeiten enthält
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TransactionSum


        Private m_sumPaidAmmountInbound As Decimal
        Private m_sumUnpaidAmmountInbound As Decimal
        Private m_sumPaidAmmountInboundTaxes As Decimal
        Private m_sumUnpaidAmmountInboundTaxes As Decimal


        Private m_sumPaidAmmountOutbound As Decimal
        Private m_sumUnpaidAmmountOutbound As Decimal
        Private m_sumPaidAmmountOutboundTaxes As Decimal
        Private m_sumUnpaidAmmountOutboundTaxes As Decimal


        Private m_TaxList As New Dictionary(Of Integer, TaxValuePair)

        ''' <summary>
        ''' Ruft eine Auflistung von Steuersätzen und dessen kummulierten Werten ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property TaxList() As Dictionary(Of Integer, TaxValuePair)
            Get
                Return m_TaxList
            End Get
        End Property

        ReadOnly Property TaskListValues() As List(Of TaxValuePair)
            Get
                Dim tmp As New List(Of TaxValuePair)

                For Each item As TaxValuePair In m_TaxList.Values
                    tmp.Add(item)
                Next

                Return tmp

            End Get
        End Property

        ''' <summary>
        ''' Löscht alle Anteile
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Reset()
            m_TaxList.Clear()
            m_sumPaidAmmountInbound = 0
            m_sumUnpaidAmmountInbound = 0
            m_sumPaidAmmountInboundTaxes = 0
            m_sumUnpaidAmmountInboundTaxes = 0


            m_sumPaidAmmountOutbound = 0
            m_sumUnpaidAmmountOutbound = 0
            m_sumPaidAmmountOutboundTaxes = 0
            m_sumUnpaidAmmountOutboundTaxes = 0

        End Sub

        ''' <summary>
        ''' Bezahlte eingehenede Rechnungen (Ausgaben)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PaidAmmountInbound() As Decimal
            Get
                Return m_sumPaidAmmountInbound
            End Get
            Set(ByVal value As Decimal)
                m_sumPaidAmmountInbound = value
            End Set
        End Property

        ''' <summary>
        ''' Unbezahlte eingehende Rechnungen (Ausgaben)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UnpaidAmmountInbound() As Decimal
            Get
                Return m_sumUnpaidAmmountInbound
            End Get
            Set(ByVal value As Decimal)
                m_sumUnpaidAmmountInbound = value
            End Set
        End Property

        ''' <summary>
        ''' Steueranteil der bezahlten eingehenden Rechnungen (Steuerlast der Ausgaben)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PaidAmmountInboundTaxes() As Decimal
            Get
                Return m_sumPaidAmmountInboundTaxes
            End Get
            Set(ByVal value As Decimal)
                m_sumPaidAmmountInboundTaxes = value
            End Set
        End Property

        ''' <summary>
        ''' Steuerlast der unbezahlten eingehenden Rechnungen (Steuerlast der Ausgaben)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UnpaidAmmountInboundTaxes() As Decimal
            Get
                Return m_sumUnpaidAmmountInboundTaxes
            End Get
            Set(ByVal value As Decimal)
                m_sumUnpaidAmmountInboundTaxes = value
            End Set
        End Property

        ''' <summary>
        ''' Bezahlte ausgehende Rechnungen beglichen Verbindlichkeiten.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PaidAmmountOutbound() As Decimal
            Get
                Return m_sumPaidAmmountOutbound
            End Get
            Set(ByVal value As Decimal)
                m_sumPaidAmmountOutbound = value
            End Set
        End Property

        ''' <summary>
        ''' Unbezahlte ausgehende Rechnungen, unbeglichene Verbindlichkeiten
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UnpaidAmmountOutbound() As Decimal
            Get
                Return m_sumUnpaidAmmountOutbound
            End Get
            Set(ByVal value As Decimal)
                m_sumUnpaidAmmountOutbound = value
            End Set
        End Property

        ''' <summary>
        ''' Steuerlast der bezahlten ausgehennden Rechnungen (Steueranteil der Einnahmen)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PaidAmmountOutboundTaxes() As Decimal
            Get
                Return m_sumPaidAmmountOutboundTaxes
            End Get
            Set(ByVal value As Decimal)
                m_sumPaidAmmountOutboundTaxes = value
            End Set
        End Property

        ''' <summary>
        ''' Steuerlast der unbezahlten ausgehenden Rechnungen (Steueranteil der Einnahmen)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property UnpaidAmmountOutboundTaxes() As Decimal
            Get
                Return m_sumUnpaidAmmountOutboundTaxes
            End Get
            Set(ByVal value As Decimal)
                m_sumUnpaidAmmountOutboundTaxes = value
            End Set
        End Property



    End Class

End Namespace