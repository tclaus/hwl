Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Imports DevExpress.Xpo


Namespace Kernel.Security

    ''' <summary>
    ''' Stellt eine Klasse dar, die eine Auflistung von Berechtigungen enthält
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("UserRight")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class UserRight
        Inherits StaticItem
        Implements IDataItem

        ' Ready|write|Delete  ;   Modulname  ;   UserName

        Private m_rightName As PermissionsRights

        Private m_account As String

        Private m_modulName As PermissionModules
        ''' <summary>
        ''' Name des Moduls: Feststehender Name des Moduls, für das der Berechtigungssatz gilt
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Modulname")> _
        Public Property ModulID() As PermissionModules
            Get
                Return m_modulName
            End Get
            Set(ByVal value As PermissionModules)
                SetPropertyValue(Of PermissionModules)("ModulName", m_modulName, value)

            End Set


        End Property

        ''' <summary>
        ''' Ruft den Textnamen des Modules ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetModulname() As String

            'TODO: hier ein NLS-text reinsetzen
            Return ModulID.ToString
        End Function


        ''' <summary>
        ''' Benutzer- oder Gruppenname, für diese 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("AccountName")> _
        Public Property Account() As String
            Get
                Return m_account
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Account", m_account, value)

            End Set
        End Property

        ''' <summary>
        ''' Id der Berechtigung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("EffectiveRight")> _
        Public Property EffectiveRight() As PermissionsRights
            Get
                Return m_rightName
            End Get
            Set(ByVal value As PermissionsRights)

                SetPropertyValue(Of PermissionsRights)("EffectiveRight", m_rightName, value)
            End Set
        End Property





        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace
