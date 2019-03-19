
Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo

Namespace Kernel


    ''' <summary>
    ''' Stellt eine benutzerdefinierte Einstellung dar.
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("Properties")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Setting
        Inherits StaticItem
        Implements IDataItem

        ''' <summary>
        ''' Enthält den Wert der Einstellung
        ''' </summary>
        ''' <remarks></remarks>
        Private m_valueString As String
        ''' <summary>
        ''' Enthä#lt den eindeutigen Namen der Einstellung in diesem Bereich (Area)
        ''' </summary>
        ''' <remarks></remarks>
        Private m_settingsName As String

        ''' <summary>
        ''' Enthält einen Benutzernamen, fr den diese Einstellung gültig ist (SYSTEM oder Windows-Username)
        ''' </summary>
        ''' <remarks></remarks>
        Private m_username As String

        ''' <summary>
        ''' Der Gültigkeitsbereich dieser Einstellung, Isoliert gleiche Einstellungen voneinander
        ''' </summary>
        ''' <remarks></remarks>
        Private m_area As String


        ''' <summary>
        ''' Ruft den Wert der Einstellung ab oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <Persistent("Value")> _
        Public Property Value() As String
            Get
                Return m_valueString
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Value", m_valueString, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen der Einstellung ab oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Name")> _
        Public Property Name() As String
            Get
                Return m_settingsName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Name", m_settingsName, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen des Benutzer ab für den diese einstellung gültigkeit hat oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("UsernameID")> _
        Public Property UserName() As String
            Get
                Return m_username
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UserName", m_username, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Bereich ab für den die Einstellung gültigkeit hat oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Skope")> _
        Public Property Area() As String
            'TODO: Bereich aus festen Werten nehmen? 
            Get
                Return m_area
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Area", m_area, value)
            End Set
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace