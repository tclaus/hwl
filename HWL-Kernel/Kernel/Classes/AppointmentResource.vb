Option Explicit On
Option Strict On


Imports DevExpress.Xpo
Imports ClausSoftware.Data
Imports System.IO
Imports System.Drawing

Namespace Kernel

    <Persistent(AppointmentsResource.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class AppointmentsResource
        Inherits StaticItem
        Implements IDataItem

        Friend Const Tablename As String = "AppointmentsResource"

        Dim fID As UInteger
        Dim fResourceID As Integer
        Dim fResourceName As String
        Dim fColor As UInteger
        Dim fCustomField1 As String



        <Persistent("ResourceID")> _
        Public Property ResourceID() As Integer
            Get
                Return fResourceID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ResourceID", fResourceID, value)
            End Set
        End Property

        <Persistent("ResourceName")> _
        <Size(50)> _
        Public Property ResourceName() As String
            Get
                Return fResourceName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ResourceName", fResourceName, value)
            End Set
        End Property

        <Persistent("Color")> _
        Public Property Color() As UInteger
            Get
                Return fColor
            End Get
            Set(ByVal value As UInteger)
                SetPropertyValue(Of UInteger)("Color", fColor, value)
            End Set
        End Property

        <Persistent("CustomField1")> _
        <Size(SizeAttribute.Unlimited)> _
        Public Property CustomField1() As String
            Get
                Return fCustomField1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CustomField1", fCustomField1, value)
            End Set
        End Property

      
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace