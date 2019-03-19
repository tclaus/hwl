
Namespace HomeScreen
    Public Class HomeScreenDefinition


        ''' <summary>
        ''' Schreibt die Definition des Hauptmenüs
        ''' </summary>
        ''' <param name="menuStructure">die Objektstruktur des Hauptmenüs</param>
        ''' <remarks></remarks>
        Friend Shared Sub FillMenue(ByVal menuStructure As MenuStructure)
            Dim Adressbook As New ModuleItem
            Adressbook.Icon = My.Resources.Contact_Card_32x32
            Adressbook.ModuleID = "MyID"
            Adressbook.ModuleName = "Adressbuch"


            Dim addAddress As New MenuFunction
            addAddress.Caption = "Neue Adresse anlegen"
            addAddress.FunctionID = "MyID"
            addAddress.IsVisible = True

            Adressbook.ListOfFunctions.Add(addAddress)

            Dim searchAddress As New MenuFunction
            searchAddress.Caption = "nach Adresse suchen"
            searchAddress.FunctionID = "MyID"
            searchAddress.IsVisible = True

            Adressbook.ListOfFunctions.Add(searchAddress)


            menuStructure.ListOfModules.Add(Adressbook)

            '----

            Dim BuisinesActs As New ModuleItem
            BuisinesActs.Icon = My.Resources.Contract_32x32
            BuisinesActs.ModuleID = "MyID"
            BuisinesActs.ModuleName = "Angebote / Rechnungen"
            menuStructure.ListOfModules.Add(BuisinesActs)

            Dim addInvoice As New MenuFunction
            addInvoice.Caption = "Neue Rechnung anlegen"
            addInvoice.FunctionID = "MyID"
            addInvoice.IsVisible = True

            BuisinesActs.ListOfFunctions.Add(addInvoice)

            Dim checkReminder As New MenuFunction
            checkReminder.Caption = "aktuelle Mahnungen"
            checkReminder.FunctionID = "MyID"
            checkReminder.IsVisible = True

            BuisinesActs.ListOfFunctions.Add(checkReminder)



            ' Finanzen
            Dim finanzen As New ModuleItem
            finanzen.Icon = My.Resources.Profits_32x32
            finanzen.ModuleID = "MyID"
            finanzen.ModuleName = "Finanzen"
            menuStructure.ListOfModules.Add(finanzen)

            Dim summary As New MenuFunction
            summary.Caption = "Übersicht"
            summary.FunctionID = "MyID"

            finanzen.ListOfFunctions.Add(summary)

            Dim winLoss As New MenuFunction
            winLoss.Caption = "Gewinn/Verlust"
            winLoss.FunctionID = "MyID"

            finanzen.ListOfFunctions.Add(winLoss)






        End Sub


    End Class
End Namespace
