Option Explicit On
Option Strict On

' Siehe http://ec.europa.eu/taxation_customs/resources/documents/taxation/vat/how_vat_works/rates/vat_rates_de.pdf
Namespace Kernel

    ''' <summary>
    ''' Enthält einen Steuersatz für dieses Land
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CountryInitialTaxRate

        ' -1 Bedeutet nicht vergeben

        Private m_countryCode As String = ""

        Private m_reducedTaxRate As Decimal = -1

        Private m_normalTaxRate As Decimal = -1

        Private m_extraTaxRate As Decimal = -1

        Private m_zwischenSatz As Decimal = -1
        ''' <summary>
        ''' stellt einen Zwischensatz für besondere Anlässe dar
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ReducedTaxRate2() As Decimal
            Get
                Return m_zwischenSatz
            End Get
            Set(ByVal value As Decimal)
                m_zwischenSatz = value
            End Set
        End Property

        ''' <summary>
        ''' Zwischensteuersatz (nur für besondere Produkte)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ExtraTaxrate() As Decimal
            Get
                Return m_extraTaxRate
            End Get
            Set(ByVal value As Decimal)
                m_extraTaxRate = value
            End Set
        End Property

        Public Property NormalTaxRate() As Decimal
            Get
                Return m_normalTaxRate
            End Get
            Set(ByVal value As Decimal)
                m_normalTaxRate = value
            End Set
        End Property

        Public Property ReducedTaxRate() As Decimal
            Get
                Return m_reducedTaxRate
            End Get
            Set(ByVal value As Decimal)
                m_reducedTaxRate = value
            End Set
        End Property

        ''' <summary>
        ''' 2- Stelliger Ländercode
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CountryCode() As String
            Get
                Return m_countryCode
            End Get
            Set(ByVal value As String)
                m_countryCode = value
            End Set
        End Property



        ''' <summary>
        ''' Ermittelt aus dem Ländercode den Ländername
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property NativeCountryName() As String
            Get
                Dim r As New System.Globalization.RegionInfo(Me.CountryCode)
                Return r.DisplayName
            End Get
        End Property

        Public Sub New(ByVal countryCode As String, ByVal normalRate As Decimal, ByVal reducedTaxRate As Decimal)
            Me.CountryCode = countryCode
            Me.ReducedTaxRate = reducedTaxRate
            Me.NormalTaxRate = normalRate
        End Sub

        Public Sub New(ByVal countryCode As String, ByVal normalRate As Decimal, ByVal reducedTaxRate As Decimal, ByVal extraTax As Decimal)
            Me.CountryCode = countryCode
            Me.ReducedTaxRate = reducedTaxRate
            Me.NormalTaxRate = normalRate
            Me.ExtraTaxrate = extraTax
        End Sub

        Public Sub New(ByVal countryCode As String, ByVal normalRate As Decimal, ByVal reducedTaxRate As Decimal, ByVal extraTax As Decimal, ByVal zwischensatz As Decimal)
            Me.CountryCode = countryCode
            Me.ReducedTaxRate = reducedTaxRate
            Me.NormalTaxRate = normalRate
            Me.ExtraTaxrate = extraTax
            Me.ReducedTaxRate2 = zwischensatz
        End Sub

    End Class

    ''' <summary>
    ''' Stellt eine hart-Codierte Auflistung von Steuersätzen zur verfügung
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CountryInitialTaxRates
        Private m_countryTaxes As New Dictionary(Of String, CountryInitialTaxRate)

        Private Sub Initialize()
            m_countryTaxes.Clear()
            m_countryTaxes.Add("BE", New CountryInitialTaxRate("BE", 21, 12, 12, 12))
            m_countryTaxes.Add("BG", New CountryInitialTaxRate("BG", 20, 7))
            m_countryTaxes.Add("CZ", New CountryInitialTaxRate("CZ", 19, 9))
            m_countryTaxes.Add("DK", New CountryInitialTaxRate("DK", 25, -1))
            m_countryTaxes.Add("DE", New CountryInitialTaxRate("DE", 19, 7))
            m_countryTaxes.Add("EE", New CountryInitialTaxRate("EE", 20, 9))
            m_countryTaxes.Add("EL", New CountryInitialTaxRate("EL", 19, 9, 4.5D))
            m_countryTaxes.Add("ES", New CountryInitialTaxRate("ES", 16, 7, 4))
            m_countryTaxes.Add("FR", New CountryInitialTaxRate("FR", 19, 6, 5.5D, 2.1D))
            m_countryTaxes.Add("IE", New CountryInitialTaxRate("IE", 21.5D, 13.5D, 4.8D, 13.5D))
            m_countryTaxes.Add("IT", New CountryInitialTaxRate("IT", 20, 10, 4))
            m_countryTaxes.Add("CY", New CountryInitialTaxRate("CY", 15, 5, -1, 9))
            m_countryTaxes.Add("LV", New CountryInitialTaxRate("LV", 21, 10))
            m_countryTaxes.Add("LT", New CountryInitialTaxRate("LT", 21, 9, 5))
            m_countryTaxes.Add("LU", New CountryInitialTaxRate("LU", 15, 12, 6, 12))
            m_countryTaxes.Add("HU", New CountryInitialTaxRate("HU", 25, 18, 5))
            m_countryTaxes.Add("MT", New CountryInitialTaxRate("MT", 18, 5))
            m_countryTaxes.Add("NL", New CountryInitialTaxRate("NL", 19, 6))
            m_countryTaxes.Add("AT", New CountryInitialTaxRate("AT", 20, 10))
            m_countryTaxes.Add("PL", New CountryInitialTaxRate("PL", 22, 7, 3))
            m_countryTaxes.Add("PT", New CountryInitialTaxRate("PT", 20, 12, 5, 12))
            m_countryTaxes.Add("RO", New CountryInitialTaxRate("RO", 19, 9))
            m_countryTaxes.Add("SI", New CountryInitialTaxRate("SI", 20, 8.5D))
            m_countryTaxes.Add("FI", New CountryInitialTaxRate("FI", 22, 17, 8))
            m_countryTaxes.Add("SE", New CountryInitialTaxRate("SE", 25, 12, 6))
            m_countryTaxes.Add("UK", New CountryInitialTaxRate("UK", 15, 5))
        End Sub

        Public Function GetLocalTaxRate() As CountryInitialTaxRate
            Debug.Print("Suche Steuersätze für das Land: " & My.Application.Culture.EnglishName)
            Dim countryCode As String = My.Application.Culture.TwoLetterISOLanguageName.ToUpper
            If m_countryTaxes.ContainsKey(countryCode) Then
                Return m_countryTaxes(countryCode)
            Else
                Return New CountryInitialTaxRate(countryCode, -1, -1)
            End If


        End Function

        Public Sub New()
            Initialize()

        End Sub
    End Class

End Namespace
