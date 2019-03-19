Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports ClausSoftware.Data


Namespace Kernel.AboItems


    ''' <summary>
    ''' Enthält ein bearbeitetes ABO-Item, zu dem eine Rechnung erstellt wurde
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("WorkedAboItems")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class WorkedAboItem
        Inherits StaticItem
        Implements IDataItem


        Private m_InvoiceSent As Boolean

        Private m_TargetDocumentID As String

        Private m_parentAboItemID As String

        <Persistent("")> _
        <Size(32)> _
        <Indexed()> _
        Private Property ParentAboItemID() As String
            Get
                Return m_parentAboItemID
            End Get
            Set(ByVal value As String)
                m_parentAboItemID = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID des Rechnungs-Dokuemntens ab zu dem dieses ABO-Element zugewiesen wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("")> _
        <Size(32)> _
        <Indexed()> _
        Private Property TargetDocumentID() As String
            Get
                Return m_TargetDocumentID
            End Get
            Set(ByVal value As String)
                m_TargetDocumentID = value
            End Set
        End Property

        ''' <summary>
        ''' Ist Wahr, wenn eine Rechnung zu diesem Ereignis erstellt wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property InvoiceSent() As Boolean
            Get
                Return m_InvoiceSent
            End Get

        End Property





        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace