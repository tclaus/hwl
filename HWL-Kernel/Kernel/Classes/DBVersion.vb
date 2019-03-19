Option Explicit On
Option Strict On

Imports ClausSoftware.Data

Namespace Kernel


    ''' <summary>
    ''' Stellt eine Zeile mit der aktuellen Version der Datenbank dar.
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(DBVersion.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class DBVersion
        Inherits StaticItem
        Implements IDataItem
        Public Const Tablename As String = "HWLVersion"

        Private m_VersionID As String

        ''' <summary>
        ''' Ruft die aktuelle Datenbankversion als xx.YY.ZZ ab oder legt diese fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Datenbank Version")> _
        <Persistent("VersionID")> _
        Public Property DBVersion() As String
            Get
                Return m_VersionID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DBVersion", m_VersionID, value)
            End Set
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
End Namespace
