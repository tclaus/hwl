Option Explicit On
Option Strict On

Imports NUnit.Framework
Imports ClausSoftware.Kernel

<Description("Testet das Handling der Anhänge")> _
<TestFixture()> _
Public Class TestAttachments


    ''' <summary>
    ''' Erwarte ein "FilenotFound" exception
    ''' </summary>
    ''' <remarks></remarks>
    <ExpectedException(GetType(System.IO.FileNotFoundException))> _
    <Description("Legt einen Anhang mit ungültiger Datei an")> _
    <Test()> _
    Public Sub CreateAttachmentFileNotFound()
        Dim a As New Attachment(m_Application.Session)
        a.SetFile("bla bla bla")

    End Sub

    <Description("Legt einen Anhang an")> _
<Test()> _
    Public Sub CreateAttachment()
        Dim fileName As String
        fileName = My.Computer.FileSystem.GetTempFileName()
        My.Computer.FileSystem.WriteAllText(fileName, "Test on: " & Now.ToString, True)

        Dim a As New Attachment(m_Application.Session)
        a.SetFile(fileName)

        Assert.IsNotNullOrEmpty(a.HashValue, "Hashvalue vom Anhang düfte nicht leer ein.")

        m_Application.AttachmentRelations.Add("TestID", a) ' einem neuem Teil hinzufügen
        Dim OrgCount As Integer = m_Application.AttachmentRelations.Count

        ' Das selb Dokument sollte nicht mehrfach den selben Anhang haben
        m_Application.AttachmentRelations.Add("TestID", a) ' einem neuem Teil hinzufügen

        m_Application.AttachmentRelations.Add("TestID", a) ' einem neuem Teil hinzufügen
        Dim newCount As Integer = m_Application.AttachmentRelations.Count

        Assert.IsTrue(OrgCount = newCount, "Der selbe Verweis auf das selbe Objekt darf nicht mehrfach hinzugefügt werden")

        m_Application.AttachmentRelations.RemoveAllBySourceDocument("TestID")

    End Sub

End Class
