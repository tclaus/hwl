Option Explicit On
Option Strict On


Imports DevExpress.Xpo
Imports ClausSoftware.Data
Imports System.Drawing
Imports DevExpress.Data.Filtering

Namespace Kernel

    <DebuggerDisplay("Name:{Name}")> _
    <Persistent(Template.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Template
        Inherits StaticItem
        Implements IDataItem

        Friend Const Tablename As String = "Schablonen"

#Region "Properties"



        ''' <summary>
        ''' Enthält den Gruppen-Namen
        ''' </summary>
        ''' <remarks></remarks>
        Private m_name As String

        ''' <summary>
        ''' Enthält eine Unter-Gruppe
        ''' </summary>
        ''' <remarks>Unter-Gruppen kommen aus den Kategorieren, und werden als Parent-Child-Beziehung gesichert</remarks>
        Private m_subGroup As Group

        Private m_parentID As String




        ''' <summary>
        ''' Ruft den Schlüssel des Vater-Objektes ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <ComponentModel.Browsable(False)> _
        <Persistent("Uplink")> _
        <Size(32)> _
        Property ParentID() As String
            Get

                Return m_parentID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ParentID", m_parentID, value)
            End Set
        End Property




        ''' <summary>
        ''' Ruft alle einträge ab, ddie unter dieser Schablone existieren
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Articles() As Object
            Get
                Return Nothing
            End Get
        End Property


        ''' <summary>
        ''' Ruft alle Daten dieses Templates ab -erstmal nicht rekurssiv-
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetTemplateData() As TemplateDatas
            Dim Criteria As CriteriaOperator = CriteriaOperator.Parse("TemplateID='" & Me.ReplikID & "' AND Uplink='0'")
            Dim datas As New TemplateDatas(m_mainApplication, Criteria)
            Return datas

        End Function

        ''' <summary>
        ''' Ruft eine Liste mit unter-Gruppen ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property SubTemplates() As Templates
            Get

                Dim criteria As CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("Uplink='" & Me.Key & "'")


                Dim tmpGroups As New Templates(MainApplication, criteria)


                Return tmpGroups

            End Get

        End Property



        ''' <summary>
        ''' Ruft den Namen der Gruppe ab oder öegt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Name")> _
        Public Property Name() As String
            <DebuggerStepThrough()> _
            Get
                Return m_name
            End Get
            Set(ByVal value As String)

                SetPropertyValue("Name", m_name, value)
            End Set
        End Property


#End Region

        ''' <summary>
        ''' Speichert den Eintrag ab und vergibt eine neue Kundennummer
        ''' </summary>
        ''' <remarks></remarks>
        Public Overloads Sub Save()


            MyBase.Save()
        End Sub



        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace
