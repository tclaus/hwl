Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Imports DevExpress.Xpo


Namespace Kernel.Security

    ''' <summary>
    ''' Steöllt eien Klasse dar, mit der Kurztexte, Termine und Aufgaben geschrieben werden können
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("securityLocks")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Friend Class SecurityLock
        Inherits StaticItem
        Implements IDataItem


        Private m_ItemKey As String

        Private m_lockByName As String

        ''' <summary>
        ''' Ruft den Namen des Lockers ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("LockedBy")> _
        Public Property LockByName() As String
            Get
                Return m_lockByName
            End Get
            Set(ByVal value As String)
                m_lockByName = value
            End Set
        End Property

        ''' <summary>
        ''' Enthält den Schlüsel zum Gesperrten Elemenet
        ''' </summary>
        ''' <remarks></remarks>
        <Indexed()> _
        <Persistent("ItemKey")> _
        <Size(32)> _
        Public Property ItemKey() As String
            Get
                Return m_ItemKey
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ItemKey", m_ItemKey, value)
            End Set
        End Property





        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace
