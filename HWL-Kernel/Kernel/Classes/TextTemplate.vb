Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Enthält eine Auflistung von Textschablonen für Angebote / Rechnungen
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("Textschablonen")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class TextTemplate
        Inherits StaticItem
        Implements IDataItem



        Private m_text As String
        Private m_Type As String

        ''' <summary>
        ''' Gibt den Schablonentext zurück oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(SizeAttribute.Unlimited)> _
        <Persistent("Text")> _
        Public Property Text() As String
            Get
                Return m_text
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Text", m_text, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den enthaltenen Text ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.Text
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
End Namespace