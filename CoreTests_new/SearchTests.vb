Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports ClausSoftware.Kernel
Imports DevExpress.Xpo



<Category("Suchen")> _
<TestFixture()> _
Public Class SearchTests

    ''' <summary>
    ''' Volltextsuche anhand eiens suchbegriffes
    ''' </summary>
    ''' <remarks></remarks>
    <Test(Description:="Volltextsuche")> _
    Public Sub Suche1()
        Dim searchedList As Data.BaseCollection(Of Adress)
        searchedList = m_Application.Adressen.SearchByParameter("Claus")

        Assert.NotNull(searchedList, "suchliste war nothing. sollte aber eine leere Liste sein")

        searchedList = m_Application.Adressen.SearchByParameter("--wdcfhuweru--")

        Assert.NotNull(searchedList, "Suchliste war nothing. sollte aber eine leere Liste sein")


    End Sub


End Class
