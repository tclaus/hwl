Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware.Kernel
Imports ClausSoftware

<Description("Testet das Handling der Anhänge")>
<TestFixture()>
Public Class TestAttachments


    ''' <summary>
    ''' Erwarte ein "FilenotFound" exception
    ''' </summary>
    ''' <remarks></remarks>
    <ExpectedException(GetType(System.IO.FileNotFoundException))>
    <Description("Legt einen Anhang mit ungültiger Datei an")>
    <Test()>
    Public Sub CreateAttachmentFileNotFound()
        Dim a As New Attachment(MainApplication.getInstance.Session)
        a.SetFile("bla bla bla")

    End Sub

    <Description("Legt einen Anhang an")>
    <Test()>
    Public Sub CreateAttachment()
        Dim fileName As String
        fileName = My.Computer.FileSystem.GetTempFileName()
        My.Computer.FileSystem.WriteAllText(fileName, "Test on: " & Now.ToString, True)

        Dim a As New Attachment(MainApplication.getInstance.Session)
        a.SetFile(fileName)

        Assert.IsNotNullOrEmpty(a.HashValue, "Hashvalue vom Anhang düfte nicht leer ein.")

        MainApplication.getInstance.AttachmentRelations.Add("TestID", a) ' einem neuem Teil hinzufügen
        Dim OrgCount As Integer = MainApplication.getInstance.AttachmentRelations.Count

        ' Das selb Dokument sollte nicht mehrfach den selben Anhang haben
        MainApplication.getInstance.AttachmentRelations.Add("TestID", a) ' einem neuem Teil hinzufügen

        MainApplication.getInstance.AttachmentRelations.Add("TestID", a) ' einem neuem Teil hinzufügen
        Dim newCount As Integer = MainApplication.getInstance.AttachmentRelations.Count

        Assert.IsTrue(OrgCount = newCount, "Der selbe Verweis auf das selbe Objekt darf nicht mehrfach hinzugefügt werden")

        MainApplication.getInstance.AttachmentRelations.RemoveAllBySourceDocument("TestID")

    End Sub

End Class
