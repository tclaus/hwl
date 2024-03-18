Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Data

Imports ClausSoftware.HWLInterops

''' <summary>
''' Testet aspekte der Haupt UI
''' </summary>
''' <remarks></remarks>
<Category("MainUI")> _
<TestFixture()> _
Public Class TestMainUI

    Private m_mainUI As New ClausSoftware.HWLInterops.MainUI(Nothing)

    ''' <summary>
    ''' Testet das Verhalten von MRU - Objekten 
    ''' </summary>
    ''' <remarks></remarks>
    <Test()> _
    Public Sub TestMRUElements()
        Dim mru As MRUElementManager = m_mainUI.MRUManager

        Assert.NotNull(mru.RecentlyModifiedElements, "Auflistung von MRU-Elementen darf nicht nothing sein")

        ' Zufälllige Zahl holen 
        Dim nextNr As Integer = CInt(1 + Rnd(Now.Millisecond) * MainApplication.getInstance.Adressen.Count - 1) Mod MainApplication.getInstance.Adressen.Count
        Dim testobj As StaticItem = MainApplication.getInstance.Adressen(nextNr)

        mru.ClearList()

        Assert.IsTrue(mru.RecentlyModifiedElements.Count = 0, "Nach einem Clear sollte die Liste der MRU-Elemente leer sein")

        mru.AddMRUElement(Nothing) ' Darf zu keinem Fehler führen

        mru.AddMRUElement(testobj)

        Assert.IsTrue(mru.RecentlyModifiedElements.Count = 1, "Es sollte nun 1 Element in der Liste vorhanden sein")
        mru.AddMRUElement(testobj)
        mru.AddMRUElement(testobj)
        mru.AddMRUElement(testobj)      ' Teste mehrfaches einfügen des selben Elementes
        mru.AddMRUElement(testobj)
        mru.AddMRUElement(testobj)

        Assert.IsTrue(mru.RecentlyModifiedElements.Count = 1, "Es sollte nach mehrfachen Einfügen des selben Elementes immer noch genau 1 Element vorhanden sein!")

        ' Nun einige Objekte einfügen
        nextNr = CInt(1 + Rnd(Now.Millisecond) * MainApplication.getInstance.Adressen.Count - 1) Mod MainApplication.getInstance.Adressen.Count
        testobj = MainApplication.getInstance.Adressen(nextNr)
        mru.AddMRUElement(testobj)

        nextNr = CInt(1 + Rnd(Now.Millisecond) * MainApplication.getInstance.ArticleList.Count - 1) Mod MainApplication.getInstance.ArticleList.Count
        testobj = MainApplication.getInstance.ArticleList(nextNr)
        mru.AddMRUElement(testobj)

        nextNr = CInt(1 + Rnd(Now.Millisecond) * MainApplication.getInstance.JournalDocuments.Count - 1) Mod MainApplication.getInstance.JournalDocuments.Count
        testobj = MainApplication.getInstance.JournalDocuments(nextNr)
        mru.AddMRUElement(testobj)

        System.Threading.Thread.Sleep(2000) ' warten, damit eine Zeitdifferenz entsteht

        nextNr = CInt(1 + Rnd(Now.Millisecond) * MainApplication.getInstance.CashJournal.Count - 1) Mod MainApplication.getInstance.CashJournal.Count
        testobj = MainApplication.getInstance.CashJournal(nextNr)
        mru.AddMRUElement(testobj)

        mru.RecentlyModifiedElements.Sort()
        Assert.AreEqual(mru.RecentlyModifiedElements(0).Element.Key, testobj.Key, "Das oberste Element in der MRU-Liste sollte nun das letzte Element sein")


    End Sub

End Class
