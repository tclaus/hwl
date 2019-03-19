Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware
Imports DevExpress.Xpo


''' <summary>
''' Enthält Tests für die Lokalisation
''' </summary>
''' <remarks></remarks>
<Category("LanguageTests")> _
<TestFixture()> _
Public Class TestLanguages
    Public Sub New()

    End Sub

    ''' <summary>
    ''' Ruft die aktuelle sprache ab
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Ruft den Namen der aktuellen Sprache ab")> _
    <Test()> _
    Public Sub GetCurrentLanguage()
        Assert.IsNotEmpty(m_Application.Languages.GetActiveLanguage)
    End Sub
    ''' <summary>
    ''' Nur einen einfchen Text aus einen schlüssel abholen
    ''' </summary>
    ''' <remarks></remarks>
    <Test(description:="Ruft einen beliebigen Text ab")> _
    Public Sub SimpleGettext()
        m_Application.Languages.GetText("Test")
    End Sub

    <Test()> _
    Public Sub SimpleGettextWithDefault()
        ' Der text "defaultValue" sollte auch wieder zurückkommen
        Assert.AreEqual(m_Application.Languages.GetText("123Test123", "DefaultValue"), "DefaultValue")
    End Sub

    <Description("Testst das austauschen von Schlüsselwörter in der Übersetzung")> _
    <Test(description:="Tests the automatic replacement ob Apps name")> _
    Public Sub TestLanguageKeyWords()
        Dim target As String
        target = m_Application.Languages.GetText("Dummy", "Target {Appname}")

        StringAssert.DoesNotContain("{Appname}", target, "Textersetzung {Appname} liefert keine Ersetzung zurück")
    End Sub




    <Test()> _
    Public Sub SaveLanguage()
        ' Der text "defaultValue" sollte auch wieder zurückkommen
        m_Application.Languages.Initialize()
        Dim path As String = m_Application.Languages.SaveLanguageFile()
        Debug.Print("LanguagePath = " & path)
        Assert.IsTrue(System.IO.File.Exists(path), "Sprachdatei existiert nicht am angegeben Pfad. (" & path & ")")


    End Sub



End Class
