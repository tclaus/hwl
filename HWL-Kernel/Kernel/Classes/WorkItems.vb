Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports System.Runtime.InteropServices


Namespace Kernel
    Public Class WorkItems
        Inherits BaseCollection(Of WorkItem)
        Implements IDataCollection

        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub



        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder
            Me.CriteriaString = "Vater<>0"
            Me.Reload()
            'DisplayProps.Append("Nummer;")
            'DisplayProps.Append("Ansprechpartner;")
            'DisplayProps.Append("Firma;")
            'DisplayProps.Append("Strasse;")
            'DisplayProps.Append("Postleitzahl;")
            'DisplayProps.Append("Ort;")
            'DisplayProps.Append("Telefon1;")
            'DisplayProps.Append("Datum;")
            'DisplayProps.Append("LetzteÄnderung;")
            Me.DisplayableProperties = DisplayProps.ToString
        End Sub
    End Class

End Namespace