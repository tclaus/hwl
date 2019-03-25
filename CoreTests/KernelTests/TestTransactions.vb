Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Kernel

Imports DevExpress.Xpo


<TestFixture(Description:="Transaktionen (Geschäftsvorfälle)")> _
Public Class TestTransactions

    <Test(Description:="Erstellt eine Transaktion und legt diese als 'Bezahlt' fest. Dann muss eine Splittbuchung eingegangen sein.")> _
    Public Sub TestTransactionIsPaid()
        Dim t As Transaction = MainApplication.getInstance.Transactions.GetNewItem


        t.TotalAmmount = 123

        t.SetIsPayed()

        Assert.IsTrue(t.PaidAmmount = t.TotalAmmount, "Bei Status IstBezahlt sollte der Bezahlte Betrag gleich dem Endbetrag sein. (Paid=" & t.PaidAmmount & ", Total=" & t.TotalAmmount & ")")

        Assert.IsTrue(t.GetDownPayments.Count = 1, "Es sollte bei Bezahlt-Status eine Buchung vorhanden sein")
        Assert.IsTrue(t.GetDownPayments(0).Ammount = t.TotalAmmount, "Bei Status Bezahlt sollte diese Buchung gleich dem Gesamtbetrag sein")

    End Sub
    ''' <summary>
    ''' Testet die Steuersätze
    ''' </summary>
    ''' <remarks></remarks>
    <Test()>
    Public Sub TestTaxes()
        Dim s As New StartUp
        s.Start()

        Dim t As Transactions = MainApplication.getInstance.Transactions

        Assert.NotNull(t, "Transaction (Ver/For) konnten nicht ermittelt werden")
        Assert.IsTrue(t.Count >= 0, "Transaction (Ver/For)  Anzahl war null")

        Dim newTRans As Transaction = t.GetNewItem
        'Assert.Pass("Test passes! - Review this Test!")
        Exit Sub

        Dim tp = t(0).TaxValuePairs

        Assert.NotNull(tp, "Steuersatzdaten konnten nicht von den Transaktionen ermittelt werden")
        Assert.IsTrue(tp.Count >= 0, "Steuersatzdaten können nicht nulls sein!")

        For Each item As TaxValuePair In tp
            Debug.Print(item.ToString & " Total:" & item.Value)

        Next


    End Sub

    <Test(Description:="Testet die Behandlung des Stornierens unter Forerungen/Verbindlichkeiten")>
    Public Sub TestCanceldDocuments()

        Dim t As Transaction = MainApplication.getInstance.Transactions.GetNewItem
        Assert.IsFalse(t.IsCanceled, "Neue Transaktionen dürfen nicht gecancelt sein!")

        t.SetCanceled()
        Assert.IsFalse(t.IsCanceled, "Transaktionen ohne Bezug zu einem interen Journaldokument dürfen nicht storniert werden!")

        t.ClearCanceled()

    End Sub

    ''' <summary>
    ''' Ruft eine auflistung von verwendeten Texten ab
    ''' </summary>
    ''' <remarks></remarks>
    <Test()>
    Public Sub GetColumnDataGrouped()
        Dim str As String() = MainApplication.getInstance.Transactions.GetListOfTexts
        Assert.IsNotNull(str, "Liste der Texte war leer")
    End Sub

End Class

