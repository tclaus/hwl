Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Kernel.Security

    ''' <summary>
    ''' Module, die Berechtigungen erhalten k�nnen.
    ''' Diese Module erhalten die Berechtigungen: 
    ''' Lesen, Schreiben
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum PermissionsRights

        ''' <summary>
        ''' Kein recht, das Modul zu �ffnen
        ''' </summary>
        ''' <remarks></remarks>
        None = 0
        ''' <summary>
        ''' Erlaubt es lediglich einen Datensatz / Modul zu lesen, aber nicht diese irgendwie zu beabeiten
        ''' </summary>
        ''' <remarks></remarks>
        Read = 1
        ''' <summary>
        ''' Erlaubt es Datens�tze zu schreiben, �nderungen zu �bernehmen
        ''' </summary>
        ''' <remarks></remarks>
        Write = 2

        ''' <summary>
        ''' Erlaubt, einen Datensatz zu L�schen, behinhaltet alle anderen Rechte
        ''' </summary>
        ''' <remarks></remarks>
        Delete = 3


    End Enum

    ''' <summary>
    ''' Enth�lt eine Auflistung an m�glichen Modulen, f�r die eine Berechtigung vergeben werden kann
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum PermissionModules
        ''' <summary>
        ''' Eingebaute OPtionen, Kann Systemeinstellungen �ndern
        ''' </summary>
        ''' <remarks></remarks>
        Options
        ' eingebaute Module; weitere Module werden angelegt, wenn diese angefordert werden
        ''' <summary>
        ''' Alle Datens�tze des Adressnbuches
        ''' </summary>
        ''' <remarks></remarks>
        AdressBook

        ''' <summary>
        ''' Materialstamm
        ''' </summary>
        ''' <remarks></remarks>
        Articles
        ''' <summary>
        ''' Alle Angebots / Rechnungs / Gutschriften - Dokumente etc
        ''' </summary>
        ''' <remarks></remarks>
        JournalDocuments
        ''' <summary>
        ''' Termine
        ''' </summary>
        ''' <remarks></remarks>
        Appointments
        ''' <summary>
        ''' Briefe
        ''' </summary>
        ''' <remarks></remarks>
        Letters
        ''' <summary>
        ''' Forderungen / Verbindlichkeiten
        ''' </summary>
        ''' <remarks></remarks>
        Transactions
        ''' <summary>
        ''' Kassenbuch
        ''' </summary>
        ''' <remarks></remarks>
        CashFlow

    End Enum

    ''' <summary>
    ''' Enth�lt eine Auflistung von Kurztexte, Aufgaben 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class UserRights
        Inherits BaseCollection(Of UserRight)
        Implements IDataCollection


        Public Sub New(ByVal BasisApplikation As mainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal baseApplication As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(baseApplication, criteria)
        End Sub

        ''' <summary>
        ''' Ruft die gefilterte Rechte-Liste ab , die alle Rechte f�r den angegebenen Account enth�lt. Alle Modulnamen die nicht aufger�hrt sind, haben kein Zugriffsrecht
        ''' </summary>
        ''' <param name="accountnameID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Getrights(ByVal accountnameID As String) As Dictionary(Of PermissionModules, PermissionsRights)
            Dim rightList As New Dictionary(Of PermissionModules, PermissionsRights)

            For Each item As UserRight In Me
                If item.Account = accountnameID Then
                    rightList.Add(item.ModulID, item.EffectiveRight)
                End If
            Next

            Return rightList

        End Function


        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim display As New Text.StringBuilder

            Me.DisplayableProperties = display.ToString


        End Sub
    End Class
End Namespace