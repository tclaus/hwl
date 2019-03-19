Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo

Namespace Kernel

    ''' <summary>
    ''' Stellt einen Tagespreis eines Rohstoffes dar.
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("RohstoffTagesPrs")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Rohstoffpreis
        Inherits StaticItem
        Implements IDataItem


        Private m_Rohstoffname As String
        Private m_Preis As Decimal
        Private m_DatanormMerker As String
        Private m_LetzeAktualisierung As DateTime


        ''' <summary>
        ''' Bezeichnung des Rohstoffes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Rohstoff")> _
        Public Property Rohstoffname() As String
            Get
                Return m_Rohstoffname
            End Get
            Set(ByVal value As String)
                m_Rohstoffname = value
            End Set
        End Property

        ''' <summary>
        ''' Aktueller Tagespreis Rohstoff
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Preis")> _
        Public Property Preis() As Decimal
            Get
                Return m_Preis
            End Get
            Set(ByVal value As Decimal)
                m_Preis = value
            End Set
        End Property

        ''' <summary>
        ''' Datanorm Kennuung des Rohstoffes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("DTNRohstoffmerker")> _
        Public Property DatanormRohstoffmerker() As String
            Get
                Return m_DatanormMerker
            End Get
            Set(ByVal value As String)
                m_DatanormMerker = value
            End Set
        End Property

        ''' <summary>
        ''' Zeigt die letzte änderung des Preises an.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("LetzeAenderung")> _
        Public Property ZuletzAktualisiert() As DateTime
            Get
                Return m_LetzeAktualisierung
            End Get
            Set(ByVal value As DateTime)
                m_LetzeAktualisierung = value
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.Rohstoffname & ", " & Me.Preis
        End Function

    End Class
End Namespace