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
    ''' Stellt eine Auflistung von Werten für die Mehrfachauswahl von Attributen breit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MultiSelectValues
        Inherits BaseCollection(Of MultiSelectValue)
        Implements IDataCollection


        Private m_basePranetID As String


        Public Overrides Function BaseAdd(ByVal newObject As Object) As Integer
            CType(newObject, MultiSelectValue).ProfileID = Me.ParentID
            Return MyBase.BaseAdd(newObject)

        End Function
        ''' <summary>
        ''' Ruift die ID des übergeordneten Profiels ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParentID() As String
            Get
                Return m_basePranetID
            End Get
            Set(ByVal value As String)
                m_basePranetID = value
            End Set
        End Property
        

        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

  

        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

        ''' <summary>
        ''' Legt die Anzeigeeigenschaften fest
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize() Implements Data.IDataCollection.Initialize
            Dim Displayitems As New StringBuilder            
            Displayitems.Append("DisplayName;")

            Me.DisplayableProperties = Displayitems.ToString
        End Sub
    End Class
End Namespace