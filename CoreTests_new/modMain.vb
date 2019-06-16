Module modMain

    Public m_Gui As ClausSoftware.HWLInterops.MainUI

    ''' <summary>
    ''' Für Manuellen Start, falls dieses Projekt als exe übersetzt wird
    ''' </summary>
    ''' <remarks></remarks>
    Sub Main()

        Try
            Dim startup As New StartUp
            startup.Start() ' test starten

            Dim test As New KernelTest

            test.CreateAddress()
            test.GetAdressItem()
            test.GetDBVersion()
            test.GetSetting()
            test.OpenAddress()
            test.OpenArticleList()
            test.OpenBriefe()
            test.OpenUnits()
            test.OpenEinstellungen()
            test.OpenImages()
            test.OpenItems()
            test.OpenJournal()
            test.OpenJournalItems()
            test.OpenJournalPositions()
            test.OpenMWST()
            test.OpenNotes()
            test.OpenPositionItems()
            test.OpenPositions()
            test.SetDBVersion()
            test.ShowBriefe()

        Catch ex As Exception

            Debug.Print(ex.Message)
        End Try

    End Sub
End Module
