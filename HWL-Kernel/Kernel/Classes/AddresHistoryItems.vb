Imports ClausSoftware.Tools
Imports ClausSoftware.Data


Namespace Kernel
    ''' <summary>
    ''' 'Hält eine Auflistung von Textvorlagen für Angebote / Rechnungen
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AddressHistoryItems
        Inherits BaseCollection(Of AddressHistoryItem)
        Implements IDataCollection

        ''' <summary>
        ''' Ruft die Auflistung aller Kategorien ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Categories() As HistoryCategories
            Get                
                Return MainApplication.HistoryCategories
            End Get
        End Property

        ''' <summary>
        ''' Prüft auf Vorhandensein eines Eintrages mit Verweis auf dieses Ausgangsobjekt in diesem Filter
        ''' </summary>
        ''' <param name="parentItemKey"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ContainsSystemItem(ByVal parentItemKey As String) As Boolean
            Me.Filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("ParentItemID='" & parentItemKey & "'")
            For Each item As AddressHistoryItem In Me
                If item.ParentItemID.Equals(parentItemKey, StringComparison.InvariantCultureIgnoreCase) Then
                    Return True
                End If
            Next

            Return False
        End Function
        ''' <summary>
        ''' Ruf ein neues element ab und weist das aktuelle Datum zu
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As AddressHistoryItem
            Dim newITem As AddressHistoryItem = MyBase.GetNewItem()
            newITem.ItemDate = Today            
            Return newITem
        End Function


        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)
            Initialize()

        End Sub


        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder

            DisplayProps.Append("ItemDate;")
            DisplayProps.Append("Category.Text;")
            DisplayProps.Append("Text;")

            Me.DisplayableProperties = DisplayProps.ToString
        End Sub
    End Class
End Namespace