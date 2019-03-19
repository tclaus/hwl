Option Explicit On
Option Strict On
Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Enthält eine Kennung der steuerarten, damit kann eine Steuerart identifiziert werden
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum enumTaxKind

        ''' <summary>
        ''' Normaler Steuersatz (19%)
        ''' </summary>
        ''' <remarks></remarks>
        <DisplayName("Standard")> _
        NormalTax = 1

        ''' <summary>
        ''' ermässigter Steuersatz (7%)
        ''' </summary>
        ''' <remarks></remarks>
        <DisplayName("Ermässigt")> _
        ReducedTax = 2


        ''' <summary>
        ''' Steuersatz "0"
        ''' </summary>
        ''' <remarks></remarks>
        <DisplayName("Ohne Steuern")> _
        NullTax = 3

        ''' <summary>
        ''' Sonstige Steuerart
        ''' </summary>
        ''' <remarks></remarks>
        <DisplayName("Sonstige")> _
        OtherTax = 4

        ''' <summary>
        ''' Zwischensatz
        ''' </summary>
        ''' <remarks></remarks>
        <DisplayName("Zwischensatz")> _
ReducedTax2 = 5

        ''' <summary>
        ''' Extrasatz für spezielle Waren
        ''' </summary>
        ''' <remarks></remarks>
        <DisplayName("Extra")> _
ExtraTax = 6

    End Enum

    ''' <summary>
    ''' Stellt die Steuersätze bereit
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("MWST")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class TaxRate
        Inherits StaticItem
        Implements IDataItem



        Private m_name As String
        Private m_value As Decimal
        ''' <summary>
        ''' Enthält eine Kennung ob dieser Steuersatz "Normal","Ermässigt" oder "Null" ist
        ''' </summary>
        ''' <remarks></remarks>
        Private m_taxKind As Integer = -1

        ''' <summary>
        ''' Name des Steueresatzes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Name")> _
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
        ''' Wert des Steuersatzes in Prozenz.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Wert")> _
        <Persistent("Wert")> _
        Public Property TaxValue() As Decimal
            Get
                Return m_value
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TaxValue", m_value, value)

            End Set
        End Property

        ''' <summary>
        ''' Ruft den Steuersatz ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("TaxKind")> _
        Private Property TaxKind() As Integer
            Get
                If [Enum].IsDefined(GetType(enumTaxKind), m_taxKind) Then
                    Return m_taxKind
                Else
                    Return enumTaxKind.OtherTax
                End If

            End Get
            Set(ByVal value As Integer)

                If [Enum].IsDefined(GetType(enumTaxKind), value) Then
                    SetPropertyValue(Of Integer)("TaxKind", m_taxKind, value)
                Else
                    SetPropertyValue(Of Integer)("TaxKind", enumTaxKind.OtherTax, value)
                End If


            End Set
        End Property

        ''' <summary>
        ''' Ruft eine Kennung ab, die angibt welcher Art dieser Steuersatz ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property TaxStatus() As enumTaxKind
            Get
                Return CType(TaxKind, enumTaxKind)
            End Get
            Set(ByVal value As enumTaxKind)
                TaxKind = value
            End Set
        End Property


        ''' <summary>
        ''' Ruft den Anzeigenamen dieses Steuersatzes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Bezeichnung")> _
        Public ReadOnly Property Displayname() As String
            Get
                Return Me.Name & " " & Me.TaxValue & "% "
            End Get
        End Property

        ''' <summary>
        ''' Ruft den Anzeigenamen dieses Steuersatzes ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Displayname()

        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace