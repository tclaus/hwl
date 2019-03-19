Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.Data.Filtering


Namespace Kernel.Printing

    ''' <summary>
    ''' Stellt eine Auflistung von Reports für einen bestimmten Datentyp dar.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Reports
        Inherits BaseCollection(Of Report)
        Implements IDataCollection

        ''' <summary>
        ''' Ruft eine Auflistung von Report-Layouts für die angegebene Datenquell ab. Gibt es noch keinen Report dieser Datengruppe, wird eine leere Auflistung zurückgegeben
        ''' </summary>
        ''' <param name="dataKind"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SetDataType(ByVal dataKind As DataSourceList) As Reports
            Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("DataSourceKind=" & dataKind)

            Me.Filter = criteria

            Return Me


        End Function

        ''' <summary>
        ''' Ruft Briefpapier-Layouts ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBusinessLayouts() As Reports
            Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("DataSourceKind=" & DataSourceList.BusinessLayouts)

            Me.Filter = criteria
            Return Me

        End Function

        ''' <summary>
        ''' Sofern eine bestimmte Datenquelle angegeben wurde; wird der als Standard-markierte Report zurückgegeben. 
        ''' Ist kein Report der Gruppe als Default angegebene, wir die erste als Default angenommen
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDefaultReportLayout() As Report

            If Me.Count > 0 Then
                For Each ReportItem As Report In Me
                    If ReportItem.IsDefault Then
                        Return ReportItem
                    End If
                Next

                Return Me(0)

            Else
                Return Nothing
            End If

        End Function

        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub



        Public Sub Initialize() Implements Data.IDataCollection.Initialize

            ' dies regelmässig untersuchen

        End Sub
    End Class
End Namespace