Option Explicit On
Option Strict On

Imports ClausSoftware.Data

Namespace Kernel
    ''' <summary>
    ''' Stellt eine Auflistung aller Briefe bereit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Letters
        Inherits BaseCollection(Of Letter)
        Implements IDataCollection


        Public Sub Initialize() Implements IDataCollection.Initialize
            Me.DisplayableProperties = "DocumentID;AddressField;Subject;Text;CreatedAt;Tag;RTFCodedText"
        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication)
            MyBase.New(BasisApplikation)

            Initialize()
        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication, ByVal criteria As DevExpress.Data.Filtering.CriteriaOperator)
            MyBase.New(BasisApplikation, criteria)
            Initialize()
        End Sub

    End Class
End Namespace