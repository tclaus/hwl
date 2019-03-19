Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports ClausSoftware.Data


Namespace Kernel


    ''' <summary>
    ''' Stellt eine Auflistung von aktuell angemeldeten HWL - Instanzen bereit
    ''' </summary>
    ''' <remarks>In der DAtenbank wird ein entsprechendes Feld mit den Namen der angemeldeten Instanzen gepflegt</remarks>
    <Persistent("ActiveInstances")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class ActiveInstance
        Inherits StaticItem
        Implements IDataItem

        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_computerName As String
        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_userName As String
        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_loginTime As DateTime

        ''' <summary>
        ''' Datum des letzten Login
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("LoginTime")> _
        Public Property LoginTime() As DateTime
            Get
                Return m_loginTime
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LoginTime", m_loginTime, value)
            End Set
        End Property

        ''' <summary>
        ''' Der Benuztzername der angemeldeten Instzanz
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(100)> _
        <Persistent("UserName")> _
        Public Property UserName() As String
            Get
                Return m_userName
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("UserName", m_userName, value)
            End Set
        End Property

        ''' <summary>
        ''' Name des angemeldeten Computers
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(100)> _
        <Persistent("Computername")> _
        Public Property ComputerName() As String
            Get
                Return m_computerName
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("ComputerName", m_computerName, value)
            End Set
        End Property




        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace