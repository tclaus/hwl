Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.Data.Filtering
Imports System.Text


Namespace Kernel.Attributes

    ''' <summary>
    ''' Stellt eine Auflistung von Attribute-Werten bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AttributeValues
        Inherits BaseCollection(Of AttributeValue)
        Implements IDataCollection

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub




        ''' <summary>
        ''' Ruft ein neues Attribute-Werte Paar anhand der übergebenen Definition ab 
        ''' </summary>
        ''' <param name="itemDefinition"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function GetNewItem(ByVal itemDefinition As Attributes.AttributeValueDefinition) As AttributeValue
            Dim newItem As AttributeValue = MyBase.GetNewItem
            newItem.AttributeDefinitionID = itemDefinition.Key
            Return newItem
        End Function

        ''' <summary>
        ''' Prüft auf vorhandensein der Attributdefinition in der Attribute-Werte Liste
        ''' </summary>
        ''' <param name="attribute"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ContainsAttribute(ByVal attribute As AttributeValueDefinition) As Boolean
            For Each item As AttributeValue In Me
                If item.AttributeDefinitionID.Equals(attribute.Key) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

        ''' <summary>
        ''' Legt die Anzeigeeigenschaften fest
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize() Implements Data.IDataCollection.Initialize
            Dim Displayitems As New StringBuilder
            Displayitems.Append("AttributeName;")
            Displayitems.Append("DisplayValue;")

            Me.DisplayableProperties = Displayitems.ToString
        End Sub
    End Class
End Namespace