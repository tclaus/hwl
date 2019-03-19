Imports ClausSoftware.Tools
Imports ClausSoftware.Data


Namespace Kernel
    ''' <summary>
    ''' 'Hält eine Auflistung von eingehenden Anrufen
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PhoneCalls
        Inherits BaseCollection(Of PhoneCall)
        Implements IDataCollection

        ''' <summary>
        ''' Ruf ein neuen Anrufeintrag ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function GetNewItem() As PhoneCall
            Dim newITem As PhoneCall = MyBase.GetNewItem()

            Return newITem
        End Function


        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)
            Initialize()

        End Sub


        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder

            'Me.DisplayableProperties = DisplayProps.ToString
        End Sub
    End Class
End Namespace