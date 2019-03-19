Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports ClausSoftware.Data

Namespace Kernel

    
    ''' <summary>
    ''' Stellt einen Namen für einen JournalTyp dar
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerDisplay("Name{Name}")> _
    <Persistent(JournalDocumentType.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class JournalDocumentType
        Inherits StaticItem
        Implements IDataItem

        Friend Const Tablename As String = "JournalDocumentType"

        Private m_name As String = String.Empty

        Private m_internalID As Integer
        Private m_visible As Boolean = True
        Private m_orderID As Integer

        ''' <summary>
        ''' Stellt eine Anzeigenreihenfolge dar
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("OrderID")> _
        Public Property OrderID() As Integer
            Get
                Return m_orderID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("OrderID", m_orderID, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt die Zugriffsnummer des JournalTyps dar
        ''' die eigebauten Namen können nicht geändert werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("InternalID")> _
        Public Property InternalID() As Integer
            Get
                Return m_internalID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("InternalID", m_internalID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den anzeigenamen der Eigenschaft auf oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Name")> _
        Property Name As String
            Get
                Return m_name
            End Get
            Set(value As String)

                SetPropertyValue(Of String)("Name", m_name, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, ob dieser Type sichtbar ist oder nicht. Interne Typen können nicht unsichtbar werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Visible")> _
Public Property Visible() As Boolean
            Get
                Return m_visible
            End Get
            Set(ByVal value As Boolean)

                If Not IsLoading Then ' Interne Typen dürfn nicht unsichtbar werden
                    If Me.IsALL Then Exit Property ' "ALLE" draf nicht unsichtbar werden (Unsichtbarkeit wird in auswahllisten zB Journal genutzt, nicht in Zuweisungstypen
                    If Me.IsIntern And Not value Then Exit Property
                End If

                SetPropertyValue(Of Boolean)("Visible", m_visible, value)
            End Set
        End Property


        ''' <summary>
        ''' Zeigt an, das dieser DokumentenTyp intern ist und nicht gelöscht werden darf
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsIntern As Boolean
            Get
                ' -1= ALLE; 4 = Gutschrift und ist der letzte eingebaute Typ
                If Me.InternalID >= enumJournalDocumentType.ALL And InternalID <= enumJournalDocumentType.Gutschrift Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        ''' <summary>
        ''' Zeigt an, das dieser Typ "ALLe" entspricht, also keinem Dokument zugeordnet werden darf sondern nur in Suchen verwendet werden kann.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsALL As Boolean
            Get

                Return Me.InternalID = -1
            End Get
        End Property

        ''' <summary>
        ''' Lösht den aktuellen Tyyp, sofern dieser kein eingebauter interner Typ war
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Delete()
            If Not IsIntern Then MyBase.Delete()
        End Sub
        ''' <summary>
        ''' Ruft den Nammen dieses Typs ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.Name
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)


        End Sub
    End Class
End Namespace
