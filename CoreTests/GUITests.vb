Imports NUnit.Framework


<Category("Gui-Tests")> _
<TestFixture()> _
Public Class GUITests



    <Description("Startet alle Module einmal")> _
    <Test()> _
    Public Sub OpenUserControls()
        m_Gui.StartGlobalSearch("Teststring")

    End Sub

    <Test()> _
    Public Sub MyNewTest()
        ' Assert.Pass( "Alles OK!") ' Mikt assert.Pass kommt der Teambuilder nicht zurecht. stattdessen einfach ein exit machen 
    End Sub

End Class
