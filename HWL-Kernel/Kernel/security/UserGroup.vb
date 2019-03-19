Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Imports DevExpress.Xpo


Namespace Kernel.Security

    ''' <summary>
    ''' Stellt eine Benutzergruppe dar
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("group")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class UserGroup
        Inherits StaticItem
        Implements IDataItem


        Private m_groupName As String

        'TODO: Zuordnungen Benutzer => Gruppen 
        'TODO: weitere Gruppeneigenachaften ? 
        <Persistent("GroupName")> _
        Public Property groupName() As String
            Get
                Return m_groupName
            End Get
            Set(ByVal value As String)
                m_groupName = value
            End Set
        End Property





        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace
