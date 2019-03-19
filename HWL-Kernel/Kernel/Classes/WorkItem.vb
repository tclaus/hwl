Imports DevExpress.Xpo
Imports ClausSoftware.Data

Namespace Kernel

    <Persistent("Tätigkeiten")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class WorkItem
        Inherits StaticItem
        Implements IDataItem

        Private m_name As String
        Private m_description As String

        Private m_vater As Integer


        ''' <summary>
        ''' EIne 0 bedeutet, dieses Workitem ist das erste der Gruppe und enthält den Gruppennamen; 
        ''' Eine ziffer >0 kennzeichnet die Referent auf das Vater-Objekt 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Vater")> _
        <Persistent("Vater")> _
        Public Property VaterID() As Integer
            Get
                Return Me.m_vater
            End Get
            Set(ByVal value As Integer)
                m_name = CStr(value)
            End Set
        End Property

        ''' <summary>
        ''' Kurzname des Arbeitseinsatzes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Name")> _
        <Persistent("Name")> _
        Public Property Name() As String
            Get
                Return Me.m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property

        ''' <summary>
        ''' Langtext mit Beschreibung 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Beschreibung")> _
        <Persistent("Beschreibung")> _
        Public Property Description() As String
            Get
                Return Me.m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property

    End Class
End Namespace