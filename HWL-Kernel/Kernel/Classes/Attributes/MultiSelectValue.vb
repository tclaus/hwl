Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data


Namespace Kernel.Attributes


    ''' <summary>
    ''' Stellt einen Wert für die Mehrfachauswahl von Attributen dar
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(MultiSelectValue.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class MultiSelectValue
        Inherits StaticItem
        Implements IDataItem
        Public Const TableName As String = "MultiSelectValue"

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_valueDisplayName As String
        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_profileID As String

        ''' <summary>
        ''' Ruft die ID des übergeordneten Profiles ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(32)> _
        <Indexed()> _
        <Persistent("ProfileID")> _
        Public Property ProfileID() As String
            Get
                Return m_profileID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ProfileID", m_profileID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den vom Anwender wählbaren Wert ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("DisplayName", "Anzeigename")> _
        <Persistent("DisplayName")> _
        Public Property DisplayName() As String
            Get
                Return m_valueDisplayName
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("DisplayName", m_valueDisplayName, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Anzeigenamen der Eigenschaft ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.DisplayName
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace