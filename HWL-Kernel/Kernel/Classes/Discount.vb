Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Imports DevExpress.Xpo


Namespace Kernel

    Public Enum enumRabattkennzeichen
        ''' <summary>
        ''' Der Rabattwert ist ein Prozentualer Wert. Netto Endpreis = Listenpreis -(Listenpreis * Wert/100)
        ''' </summary>
        ''' <remarks></remarks>
        Rabattsatz
        ''' <summary>
        ''' Der Rabattwert ist ein Multiplikator (0,86  = Abschlag) Netto Endpreis = Listenpreis * Wert 
        ''' </summary>
        ''' <remarks></remarks>
        Multi
        ''' <summary>
        ''' Der Wert ist ein Teuerungszuschlag (1,12 = 12% Zuschlag) Netto endpreis = Listenpreis * Wert
        ''' </summary>
        ''' <remarks></remarks>
        Teuerungszuschlag
    End Enum


    ''' <summary>
    ''' Steöllt eien Klasse dar, mit der Kurztexte, Termine und Aufgaben geschrieben werden können
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("RabattGruppen")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Discount
        Inherits StaticItem
        Implements IDataItem



        Private m_name As String = String.Empty
        Private m_dicountValue As Decimal
        Private m_sourceDatanorm As Boolean

        Private m_DTNDiscountID As String = String.Empty

        Private m_DTNErsteller As String = String.Empty

        Private m_DTNRabattKennzeichen As Integer

        ''' <summary>
        '''  Ruft die Art des verwendeten Rabattwertes ab
        ''' </summary>
        Public Property DTNRabattKennzeichen As enumRabattkennzeichen
            Get
                Return CType(DTNRabattKennzeichenInternal, enumRabattkennzeichen)
            End Get
            Set(value As enumRabattkennzeichen)
                DTNRabattKennzeichenInternal = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Art des verwendeten Rabattwertes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("RabattKennzeichen")> _
        Private Property DTNRabattKennzeichenInternal() As Integer
            Get
                Return m_DTNRabattKennzeichen
            End Get
            Set(ByVal value As Integer)

                SetPropertyValue(Of Integer)("DTNRabattKennzeichenInternal", m_DTNRabattKennzeichen, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt den Datanorm-Namen des erstellers dieser Rabattgruppe an
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(255)> _
        <Persistent("DTNErsteller")> _
        Public Property DTNErsteller() As String
            Get
                Return m_DTNErsteller
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DTNErsteller", m_DTNErsteller, value)
            End Set
        End Property


        ''' <summary>
        ''' Enthält den Namen der Rabattgruppe aus Datanorm
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <Size(40)> _
        <Persistent("DTNRabattGruppe")> _
        Public Property DTNDiscountID() As String
            Get
                Return m_DTNDiscountID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DTNDiscountID", m_DTNDiscountID, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, ob dieser eintrag ursprünglich aus einem Datanorm-Impotr oder vom Anwender selber angelegt wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("QuelleDatanom")> _
        Public Property SourceDatanorm() As Boolean
            Get
                Return m_sourceDatanorm
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("SourceDatanorm", m_sourceDatanorm, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Prozentsatz ab, den dieser Rabatt entspricht
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Wert")> _
        <Persistent("Wert")> _
        Public Property DiscountValue() As Decimal
            Get
                Return m_dicountValue
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DiscountValue", m_dicountValue, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruf einen Rabattnamen ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Rabattname")> _
        <Size(255)> _
        <Persistent("Name")> _
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Name", m_name, value)

            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen und den Wert des Rabattes ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.Name & "(" & Me.DiscountValue & "%)"

        End Function


        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace
