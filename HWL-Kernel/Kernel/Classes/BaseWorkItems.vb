Option Explicit On
Option Strict On

Imports ClausSoftware.Tools
Imports System.Runtime.InteropServices
Imports ClausSoftware.Data

Namespace Kernel
    Public Class BaseWorkItems
        Inherits BaseCollection(Of WorkItem)
        Implements IDataCollection



        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub



        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder
            Me.CriteriaString = "VaterID=0"
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