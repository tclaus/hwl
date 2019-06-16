Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports System.Text
Imports DevExpress.Data.Filtering
Imports ClausSoftware.Tools

Namespace Kernel

    ''' <summary>
    ''' Enthält eine Auflistung von Artikeldokumente
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Articles
        Inherits BaseCollection(Of Article)
        Implements IDataCollection

        ''' <summary>
        ''' Ruft eine neue Auflistung mit einer neuen Sitzung ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNewCollectionAsync() As Data.BaseCollection(Of Article)
            Dim newAdressList As New Articles(MainApplication.GetNewSession)
            Return newAdressList
        End Function

        ''' <summary>
        ''' Ruft eine neue Auflistung des Typs "Artikel" ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function GetNewCollection() As Articles
            Return New Articles(MainApplication)
        End Function

        ''' <summary>
        ''' Ruft eine neue Auflistung des Typs Artikel ab und legt ein Filterkriterium fest
        ''' </summary>
        ''' <param name="criteria"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shadows Function GetNewCollection(ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator) As Articles
            Dim newAdressList As New Articles(MainApplication, criteria)
            Return newAdressList
        End Function


        'Public Shadows ReadOnly Property Count() As Integer

        '    Get
        '        If IsLoaded Then
        '            Return MyBase.Count
        '        Else
        '            Return 0I
        '        End If

        '    End Get
        'End Property


        Private Sub New(session As DevExpress.Xpo.Session)
            MyBase.New(session)
            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

        ''' <summary>
        ''' Erstellt ein neuen Artikel und legt Standardeigenaschaften fest
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As Article
            Dim newItem As Article
            newItem = MyBase.GetNewItem()
            newItem.TaxRate = MainApplication.TaxRates.GetItem(CInt(MainApplication.Settings.GetSetting(RegistryValues.ArticleDefaultTax, RegistrySections.ModuleArticles, "2")))
            newItem.MinDeliveryCount = 1
            newItem.MinSellCount = 1
            newItem.IsActive = True
            newItem.TaxRate = Me.DefaultTaxRate

            Return newItem

        End Function

        ''' <summary>
        ''' Ruft den StandardSteuersatz für neue Artikel ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DefaultTaxRate() As TaxRate
            Return MainApplication.Settings.Articlesettings.DefaultTaxRate
        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize
            Me.Sorting.Add(New SortProperty("ShortDescription", SortingDirection.Ascending))
            Dim displayProps As New StringBuilder

            displayProps.Append("IsActive;")
            displayProps.Append("ManufactorsArticleNumber;")
            displayProps.Append("ShortDescription;")
            displayProps.Append("LongDescription;")
            displayProps.Append("EinzelEK;")
            displayProps.Append("VerpackungsEinheitName;")
            displayProps.Append("CalulatedEndPrice;")
            displayProps.Append("CreatedAt;")
            displayProps.Append("ChangedAt;")
            displayProps.Append("Weight;")
            displayProps.Append("GroupName;")
            displayProps.Append("IsImported;")
            displayProps.Append("CustomerArticleNumber;")
            displayProps.Append("ManufactorsArticleNumber;")
            displayProps.Append("EAN;")
            displayProps.Append("DatanormMatchCode;")
            displayProps.Append("DefaultImage;")
            displayProps.Append("ShowInPrintings;")
            displayProps.Append("SumOnStock;")
            displayProps.Append("SumOutBound;")
            displayProps.Append("SumInBound;")
            displayProps.Append("IsWorkItem;")




            Me.DisplayableProperties = displayProps.ToString
            Me.FullTextSearchColumns = New String() {"ManufactorsArticleNumber", "ShortDescription", "CustomerArticleNumber"}
        End Sub

        '''' <summary>
        '''' Ruft einen neuen Artikel ab
        '''' </summary>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public Function GetNewItem() As Article
        '    Return New Article(MainApplication.Session)

        'End Function



    End Class
End Namespace