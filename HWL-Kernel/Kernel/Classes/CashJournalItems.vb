Option Explicit On
Option Strict On
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo.DB

Namespace Kernel


    ''' <summary>
    ''' Stellt eine Auflistung von Kassenbucheinträgen dar
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
Public Class CashJournalItems
        Inherits BaseCollection(Of CashJournalItem)  ' Kassenbuch erben
        Implements IDataCollection
        Implements IGridFormatter

        Private m_cashSums As New CashJournalsSums

        ''' <summary>
        ''' Enthält die Liste aller Transaktionen die vor dem aktuellem Datum stehen ab, 
        ''' </summary>
        ''' <remarks></remarks>
        <System.ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_oldTransactions As CashJournalItems


        Private m_StartDate As Date

        Private m_endDate As Date
        ''' <summary>
        ''' Ruft das Ende-Datum dieser Auflistung ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EndDate() As Date
            Get
                Return m_endDate
            End Get
            Set(ByVal value As Date)
                m_endDate = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Startdatum dieser Auflistung ab ode legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StartDate() As Date
            Get
                Return m_StartDate
            End Get
            Set(ByVal value As Date)
                m_StartDate = value
            End Set
        End Property




        ''' <summary>
        ''' Ruft das Datum der ersten Buchung in dieser Auflistung ab.
        ''' Ist die Auflistung leer, wird maxvalue zurückgegeben
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property FirstItemdate As Date
            Get
                Dim minDate As Date = Date.MaxValue
                For Each item As CashJournalItem In Me
                    If item.TransactionDate < minDate Then
                        minDate = item.TransactionDate
                    End If
                Next
                Return minDate
            End Get
        End Property

        ''' <summary>
        ''' Ruft das Dateum der letzten Buchung ab die sich in dieser Auflistung befindet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LasttemDate As Date
            Get
                Dim maxDate As Date = Date.MinValue
                For Each item As CashJournalItem In Me
                    If item.TransactionDate > maxDate Then
                        maxDate = item.TransactionDate
                    End If
                Next
                Return maxDate
            End Get

        End Property


        ''' <summary>
        ''' Setzt das Kriterium, das Start-und endedatum dieser auflistung festhält
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetDateCriteria()
            Dim c1 As New DevExpress.Data.Filtering.BinaryOperator("TransactionDate", m_StartDate, BinaryOperatorType.GreaterOrEqual)
            Dim c2 As New DevExpress.Data.Filtering.BinaryOperator("TransactionDate", m_endDate, BinaryOperatorType.LessOrEqual)

            Me.Criteria = New DevExpress.Data.Filtering.GroupOperator(GroupOperatorType.And, c1, c2)
            Me.Reload()

            If Me.Count > 0 Then ' Laufende Summe berechnen
                Me(0).ParentBalance = Me.GetCashBeforeThis

                ' Vater-bezüge festlegen
                Dim LastItem As CashJournalItem = Nothing
                For Each item As CashJournalItem In Me
                    item.ParentItem = LastItem
                    LastItem = item
                Next
            End If

        End Sub


        ''' <summary>
        ''' Ruft die Jahreszahlen ab,zu denen Buchungn existieren
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetItemYears() As String()

            Dim lst As New List(Of String)
            For Each item As CashJournalItem In Me
                If Not lst.Contains(CStr(item.TransactionDate.Year)) Then
                    lst.Add(CStr(item.TransactionDate.Year))
                End If
            Next
            Return lst.ToArray
        End Function

        ''' <summary>
        ''' Ruft eine neue unabhängige Auflistung von Kassenbuch einträgen ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewCollection() As Global.ClausSoftware.Data.BaseCollection(Of Global.ClausSoftware.Kernel.CashJournalItem)
            Dim newCashItems As New CashJournalItems(MainApplication)

            Return newCashItems
        End Function

        ''' <summary>
        ''' Berechnet den Kassenbestand bis zu einem Zeitpunkt der vor dem frühsten Zeitpunkt in dieser Auflistung war
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCashBeforeThis() As Decimal
            ' Den Bestand berechnen, der Vor dieser Periode da war

            Dim sums As Decimal
            For Each item As CashJournalItem In GetTransactionsBeforeThisDate()
                sums = CDec(sums + (item.Einnahme - item.Ausgabe))
            Next
            Return sums
        End Function

        ''' <summary>
        ''' Ruft die vollständige Liste der Kassenbucheinträge ab, bis zu dem aktuelem Datum
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetTransactionsBeforeThisDate() As CashJournalItems
            If m_oldTransactions Is Nothing Then
                m_oldTransactions = New CashJournalItems(MainApplication)
            End If

            If Me.Count > 0 Then

                Dim criteria As New BinaryOperator("TransactionDate", Me(0).TransactionDate, BinaryOperatorType.Less)
                m_oldTransactions.Filter = criteria
            Else
                ' welches Filterkriterium ? 
                If TypeOf Me.Criteria Is BetweenOperator Then
                    Dim startDate As Date = CDate(CType(CType(Me.Criteria, BetweenOperator).BeginExpression, DevExpress.Data.Filtering.OperandValue).Value)

                    Dim criteria As New BinaryOperator("TransactionDate", startDate, BinaryOperatorType.LessOrEqual)
                    m_oldTransactions.Filter = criteria

                End If

            End If

            Return m_oldTransactions
        End Function

        ''' <summary>
        ''' Ruft den Kassenbestand ab, der am Ende dieses Auflistungszeitraumes vorliegt. Der Anfangsbestand wird ebenfalls berücksichtigt
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCashAfterThis() As Decimal

            Dim sums As Decimal
            For Each item As CashJournalItem In Me
                sums = CDec(sums + (item.Einnahme - item.Ausgabe))
            Next

            Return sums + GetCashBeforeThis()
        End Function

        ''' <summary>
        ''' Ruft den totalen Gesamtbestand (über alle Zeiträume) an liquiden Mitteln getrennt nach Steuern ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTotalCashSums() As CashJournalsSums
            Dim oldTRansactions As CashJournalItems
            oldTRansactions = New CashJournalItems(MainApplication)

            Return oldTRansactions.GetCashSums
        End Function

        ''' <summary>
        ''' Ruft eine Auflistung ab die die Steueranteile im Kassenbuch enthält.
        ''' Dazu sämtlihe bisherigen bis zum letzten Kassenbucheintrag dieser Periode einsammeln
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalTaxes As List(Of TaxValuePair)
            Get
                Dim helpTavValuePair As New Dictionary(Of Double, Decimal)

                Dim lstOfTaxPairs As New List(Of TaxValuePair)
                Me.GetTransactionsBeforeThisDate()
                ' Durch das Kassenbuch gehen und alle steueranteile von Anfang an einsammeln und 

                Dim allTransactions As New List(Of CashJournalItem)

                ' Alle früheren Einträge abholen
                For Each item As CashJournalItem In GetTransactionsBeforeThisDate()
                    allTransactions.Add(item)
                Next

                ' Alle Aktuellen einträge abholen
                For Each item As CashJournalItem In Me
                    allTransactions.Add(item)
                Next

                'Alle einträge durchlaufen und die Steueranteile zusammenfügen
                For Each item As CashJournalItem In allTransactions

                    If Not helpTavValuePair.ContainsKey(item.TaxValue) Then
                        helpTavValuePair.Add(item.TaxValue, CDec(item.Einnahme - item.Ausgabe))
                    Else
                        ' Ansonsten direkt den Wert hinzufügen
                        helpTavValuePair(item.TaxValue) = CDec(helpTavValuePair(item.TaxValue) + (item.Einnahme - item.Ausgabe))
                    End If

                Next

                For Each Item As KeyValuePair(Of Double, Decimal) In helpTavValuePair
                    Dim newtaxvaluepair As New TaxValuePair(MainApplication.Session)
                    newtaxvaluepair.TaxValue = CDec(Item.Key)
                    newtaxvaluepair.Text = Item.Key & "%"
                    newtaxvaluepair.Targettype = TargetTaxValuePair.CashJournal
                    newtaxvaluepair.Value = Item.Value

                    lstOfTaxPairs.Add(newtaxvaluepair)

                Next


                Return lstOfTaxPairs

            End Get
        End Property

        ''' <summary>
        ''' Ruft den aktuellen Kassenbestand ab. Enthält den augenblicklichen Barbestand an Geld
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTotalCash() As Decimal
            Dim sums As CashJournalsSums = Me.GetTotalCashSums
            Return sums.Income - sums.Outcome
        End Function

        ''' <summary>
        ''' Ermittelt aus der aktuellen Auflistung Gesamtbeträge und den Steuersatz
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCashSums() As CashJournalsSums
            m_cashSums.Reset()
            For Each item As CashJournalItem In Me
                m_cashSums.Income = CDec(m_cashSums.Income + item.Einnahme)
                m_cashSums.Outcome = CDec(m_cashSums.Outcome + item.Ausgabe)

                'steuern berechnen 
                m_cashSums.IncomeTax += CDec(item.Einnahme - item.Einnahme / (1 + item.TaxValue / 100))
                m_cashSums.OutcomeTax += CDec(item.Ausgabe - item.Ausgabe / (1 + item.TaxValue / 100))

            Next

            Return m_cashSums
        End Function


        ''' <summary>
        ''' Ruft das Kassenbuch mit dem gewählten Criterienausdruck ab
        ''' </summary>
        ''' <param name="baseapplication">Das Stammobjekt</param>
        ''' <param name="criteria">Ein zusammengesetzter Criterienausdruck</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal baseapplication As mainApplication, ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator)

            MyBase.New(baseapplication, criteria)
            Initialize()

        End Sub

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

        ''' <summary>
        ''' Ruft ein neuen Kassenbucheintrag ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As CashJournalItem
            Dim newCash As CashJournalItem = MyBase.GetNewItem()
            newCash.TransactionDate = Date.Today
            Return newCash
            'TODO: Standard-Konto festlegen
        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder
            Me.Sorting.Add(New SortProperty("TransactionDate", SortingDirection.Ascending))

            With DisplayProps
                .Append("ID;") ' Als Index-Nummer
                .Append("TransactionDate;")

                .Append("TransactionText;")

                .Append("Buchungsnummer;")

                .Append("CashAccount.AccountNumber;")
                .Append("CashAccount.AccountName;")

                .Append("TaxValue;")

                .Append("Einnahme;")

                .Append("Ausgabe;")
                .Append("DateByMonthNumber;")
                .Append("DateByMonthName;")

                .Append("DateByYear;")
                .Append("TaxValueAmmount")

                Me.DisplayableProperties = .ToString
                Me.FullTextSearchColumns = New String() {"Buchungsnummer", "TransactionText"}
            End With

        End Sub


        ''' <summary>
        ''' Ruft für eine benannte Spalte einen Formatierungsstring ab
        ''' </summary>
        ''' <param name="gridname"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFormatString(ByVal gridname As String) As String Implements IGridFormatter.GetFormatString

            Select Case gridname
                Case "Einnahme", "Ausgabe", "Balance", "TaxValueAmmount" : Return "C"
                Case Else : Return ""


            End Select
        End Function

        ''' <summary>
        ''' Ruft eine neue Auflistung der Kassenbucheinträge ab
        ''' </summary>
        ''' <param name="criteria"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewCollection(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator) As Data.BaseCollection(Of CashJournalItem)
            Dim newCashItemsList As New CashJournalItems(MainApplication, criteria)
            Return newCashItemsList
        End Function

    End Class

    ''' <summary>
    ''' Stellt eine Hülle bereit, in der Summen und Steuern enthalten sind
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CashJournalsSums

        Private m_income As Decimal

        Private m_outcome As Decimal
        Private m_incomeTax As Decimal
        Private m_outcomeTax As Decimal

        Sub Reset()
            m_income = 0
            m_outcome = 0
            m_incomeTax = 0
            m_outcomeTax = 0
        End Sub

        Public Property OutcomeTax() As Decimal
            Get
                Return m_outcomeTax
            End Get
            Set(ByVal value As Decimal)
                m_outcomeTax = value
            End Set
        End Property

        Public Property IncomeTax() As Decimal
            Get
                Return m_incomeTax
            End Get
            Set(ByVal value As Decimal)
                m_incomeTax = value
            End Set
        End Property


        Public Property Outcome() As Decimal

            Get
                Return m_outcome
            End Get
            Set(ByVal value As Decimal)
                m_outcome = value
            End Set
        End Property

        Public Property Income() As Decimal
            Get
                Return m_income
            End Get
            Set(ByVal value As Decimal)
                m_income = value
            End Set
        End Property



    End Class

End Namespace