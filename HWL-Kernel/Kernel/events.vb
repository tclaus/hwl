Imports System.ComponentModel
Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Enthält als Parameter ein Element und die Möglichkeit, den Vorgang abzubrechen
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ItemArgs
        Inherits CancelEventArgs

        Private m_staticItem As StaticItem

        ''' <summary>
        ''' Ruft ein Element ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StaticItem() As StaticItem
            Get
                Return m_staticItem
            End Get
            Set(ByVal value As StaticItem)
                m_staticItem = value
            End Set
        End Property

    End Class

    ''' <summary>
    ''' Enthält als Parameter ein Element und die Möglichkeit, den Vorgang abzubrechen
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CreateItemArgs
        Inherits CancelEventArgs

        Private m_staticItem As DataSourceList

        ''' <summary>
        ''' Ruft die Datenquelle ab, dessen Element neu erstellt werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataItemType() As DataSourceList
            Get
                Return m_staticItem
            End Get
            Set(ByVal value As DataSourceList)
                m_staticItem = value
            End Set
        End Property

    End Class

    ''' <summary>
    ''' Enthält Daten zu einem Element
    ''' </summary>
    ''' <remarks></remarks>
    Public Class StaticItemEventArgs
        Inherits EventArgs

        Private m_newItem As StaticItem
        Public Property NewItem() As StaticItem
            Get
                Return m_newItem
            End Get
            Set(ByVal value As StaticItem)
                m_newItem = value
            End Set
        End Property

        ''' <summary>
        ''' Erstellt eine neue Instanz der Klasse mit dem angegeben Element
        ''' </summary>
        ''' <param name="newItem"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal newItem As StaticItem)
            m_newItem = newItem
        End Sub



    End Class
End Namespace
