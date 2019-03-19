Option Explicit On
Option Strict On


Imports DevExpress.Xpo
Imports ClausSoftware.Data
Imports System.Drawing
Imports DevExpress.Data.Filtering

Namespace Kernel



    ''' <summary>
    ''' Enthält einen Datensatz für ein Lohnkonto, zusammengesetzt aus einer Bezeichnung und einem Stundensatz
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(LoanAccount.Tablename)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class LoanAccount
        Inherits StaticItem
        Implements IDataItem

        Friend Const Tablename As String = "Lohnkonto"


        Private m_name As String

        Private m_pricePerHour As Decimal

        ''' <summary>
        ''' Ruft einen Betrag ab, der pro Stunde für dieses Konto zu bezahlen ist (Mindest Brutto, um Selbstkosten zu decken)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Preis pro Stunde")> _
        <Persistent("PricePerHour")> _
        Public Property PricePerHour() As Decimal
            Get
                Return m_pricePerHour
            End Get
            Set(ByVal value As Decimal)
                m_pricePerHour = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Anzeige-Namen des Lohnkontos ab oder legt diesen fest
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
        ''' Speichert den Eintrag ab und vergibt eine neue Kundennummer
        ''' </summary>
        ''' <remarks></remarks>
        Public Overloads Sub Save()


            MyBase.Save()
        End Sub


        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        ''' <summary>
        ''' Ruft einen Anzeigetext für dieses Lohnkonto ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.Name & " (" & Me.PricePerHour & "/h)"
        End Function

    End Class
End Namespace
