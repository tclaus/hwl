Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Enthält eine Auflistung Kategorien, die für die Adress-History gedacht sind. 
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("HistoryCategory")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class HistoryCategory
        Inherits StaticItem
        Implements IDataItem


        Private m_text As String

        ''' <summary>
        ''' Gibt den Schablonentext zurück oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(100)> _
        <DisplayName("Ereignis-Typ")> _
        <Persistent("Text")> _
        Public Property CategoryName() As String
            Get
                Return m_text
            End Get
            Set(ByVal value As String)
                If value.Length > 100 Then
                    value = value.Substring(0, 99)
                End If

                SetPropertyValue(Of String)("CategoryName", m_text, value)

            End Set
        End Property

        Public Overrides Sub Save()
            MyBase.Save()
            m_mainApplication.SendMessage(m_mainApplication.Languages.GetText("msgCommonelementSaved", "Gespeichert: '{0}'", Me.ToString))

        End Sub

        Public Overrides Function ToString() As String
            Return Me.CategoryName
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
    End Class
End Namespace