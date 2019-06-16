Option Explicit On
Option Strict On

Imports ClausSoftware.Data


Namespace Kernel
    Public Class DataBaseVersion
        Inherits BaseCollection(Of DBVersion)
        Implements IDataCollection

        ''' <summary>
        ''' Version ist in Form x.y.zzz ( eine Triade aus 3 Zahlen durch Punkt getrennt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Es gibt in dieser Tabelle nur eine Spalte</remarks>
        Public Property DBVersion() As String
            Get

                If Me.Count > 0 Then
                    Return Me(0).DBVersion
                Else
                    Return "0.0.0.0" ' NAch der ersten Installation; neue Datenbank
                End If
            End Get
            Set(ByVal value As String)
                If CheckDBVersionString(value) Then

                    Me(0).DBVersion = value

                Else
                    Throw New ArgumentException("DatenbankVersion hatte das falsche Format:'" & value & "'. Richtiges Format ist: xx.yy.zz")
                End If

            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CheckDBVersionString(ByVal Value As String) As Boolean
            Dim triade() As String = Split(Value, ".")
            Dim item As Integer

            ' 3 Blöcke? 
            If triade.Length = 3 Then
                If Integer.TryParse(triade(0), item) Then
                    If Integer.TryParse(triade(1), item) Then
                        If Integer.TryParse(triade(2), item) Then
                            Return True
                        End If
                    End If
                End If
                Debug.Print("Ein Element war keine Zahl")
                Return False
            Else
                Debug.Print("DBVersion muss aus 3 Elementen bestehen")
                Return False
            End If

        End Function

        Public Sub Initialize() Implements IDataCollection.Initialize

        End Sub

        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)

            'Initialize()
        End Sub
    End Class
End Namespace
