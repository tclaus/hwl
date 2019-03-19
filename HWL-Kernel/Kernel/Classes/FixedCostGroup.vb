Option Explicit On
Option Strict On

Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Stellt eine Gruppe für dei festen, wiederkehrenden Kosten bereit.
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("FixkostenKategorie")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class FixedCostGroup
        Inherits StaticItem
        Implements IDataItem

        Private m_groupName As String

        ''' <summary>
        ''' Name der Fixkostengruppe
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Gruppe")> _
        <Size(50)> _
        <Persistent("Name")> _
        Public Property GroupName() As String
            Get
                Return m_groupName
            End Get
            Set(ByVal value As String)
                If Not String.IsNullOrEmpty(value) Then
                    If value.Length > 50 Then
                        value = value.Substring(0, 49)
                    End If
                End If

                SetPropertyValue(Of String)("GroupName", m_groupName, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen der Gruppe ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.GroupName
        End Function


        Public Sub New(ByVal session As Session)
            MyBase.New(session)


        End Sub
    End Class
End Namespace