Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports ClausSoftware.Data


Namespace Kernel.Printing

    ''' <summary>
    ''' stellt eine einfache Klasse zur Verfügung mit der Druck-Reports einfach serialisiert und ausgetauscht werden können
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class ReportProxy

        Private m_replikID As String

        Private m_reportData As String

        Private m_DataType As DataSourceList

        Private m_name As String

        Private m_description As String
        ''' <summary>
        ''' Eine längere Beschreinung dieses Reports
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Description() As String
            Get
                Return m_description
            End Get
            Set(ByVal value As String)
                m_description = value
            End Set
        End Property

        ''' <summary>
        ''' Der Anzeigename des Reports
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property

        ''' <summary>
        ''' Der Datentyp, den dieser Report bedient
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataType() As DataSourceList
            Get
                Return m_DataType
            End Get
            Set(ByVal value As DataSourceList)
                m_DataType = value
            End Set
        End Property

        ''' <summary>
        ''' Das Layout-Report als Datenstrom
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ReportData() As String
            Get
                Return m_reportData
            End Get
            Set(ByVal value As String)
                m_reportData = value
            End Set
        End Property

        ''' <summary>
        ''' Eine eindeutige Kennung dieses Reports
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ReplikID() As String
            Get
                Return m_replikID
            End Get
            Set(ByVal value As String)
                m_replikID = value
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class


End Namespace