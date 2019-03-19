Option Explicit On
Option Strict On
Imports ClausSoftware.Data


Imports DevExpress.Xpo
Namespace Kernel

    ''' <summary>
    ''' stellt ein steuerziel da, entweder Kassebuch oder Foredrungen 
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum TargetTaxValuePair
        ''' <summary>
        ''' Kassenbuch
        ''' </summary>
        ''' <remarks></remarks>
        CashJournal = 1

        ''' <summary>
        ''' Forderungen / Verbindlichkeiten
        ''' </summary>
        ''' <remarks></remarks>
        Transactions = 2
    End Enum

    ''' <summary>
    ''' Enthält einen Steuerwert - Summe Paar dar. Damit können Buchungen erfasst werden, die keinen einheitlichen Steuersatz haben
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("KassenbuchSteuern")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class TaxValuePair
        Inherits StaticItem
        Implements IDataItem

        ' Deklariere mal die Felder !1


        Private m_targetID As Integer

        Private m_value As Decimal
        Private m_taxValue As Decimal

        Private m_text As String

        'Value nicht benutzt

        Private m_targetTyp As TargetTaxValuePair = TargetTaxValuePair.CashJournal


        Private m_tax As TaxRate


        Private m_taxRateID As Integer

        ''' <summary>
        ''' Ruft das Steuerobjekt ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("TaxRateID")> _
        Private Property TaxRateID() As Integer
            Get
                Return m_taxRateID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("TaxRateID", m_taxRateID, value)
            End Set
        End Property


        Private Shared m_taxListByValue As Dictionary(Of Decimal, TaxRate)

        ''' <summary>
        ''' Ruft das Steuerobjekt ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Tax() As TaxRate
            Get
                If Me.TaxRateID = 0 Then
                    ' Na dann suchen... 
                    If m_taxListByValue.ContainsKey(Me.TaxValue) Then
                        Me.TaxRateID = m_taxListByValue(Me.TaxValue).ID
                    Else
                        ' Kein steuersatz gefunden !
                    End If

                End If



                    Return MainApplication.TaxRates.GetItem(Me.TaxRateID)
            End Get
            Set(ByVal value As TaxRate)
                If value IsNot Nothing Then
                    Me.TaxRateID = value.ID
                    Me.TaxValue = value.TaxValue
                Else
                    Me.TaxRateID = -1  ' Unbekannter Steuersatz!
                End If

            End Set
        End Property


        ''' <summary>
        ''' Stellt die Herkunft der Steuer/Werte Paare fest
        ''' 1 = Kassenbuch, 2 = Forderungen/Verbindlichkeiten
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <Persistent("Targettype")> _
        Public Property Targettype() As TargetTaxValuePair
            Get
                Return m_targetTyp
            End Get
            Set(ByVal value As TargetTaxValuePair)
                SetPropertyValue(Of TargetTaxValuePair)("Targettype", m_targetTyp, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen kurzen Beschreibungstext ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.Browsable(False)> _
        <DisplayName("Beschreibung")> _
        <Size(255)> _
        <Persistent("Nachricht")> _
        Public Property Text() As String
            Get
                Return m_text
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Text", m_text, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Prozentsatz der Steuer ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Steuersatz in Prozent")> _
        <Persistent("Steuersatz")> _
        Public Property TaxValue() As Decimal
            Get
                Return m_taxValue
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TaxValue", m_taxValue, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Steueranteil des Betrages ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property ValueInTax() As Decimal
            Get
                If Me.TaxValue <> 0 Then
                    Return Me.Value - Me.Value / (1 + Me.TaxValue / 100)
                Else
                    Return 0
                End If

            End Get
        End Property


        ''' <summary>
        ''' Ruft den Brutto-Betrag der mit dieser Steuer behaftet ist ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Wert")> _
        Public Property Value() As Decimal
            Get
                Return m_value
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Value", m_value, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID des Datensatzes ab, der diesen Eintrag als Steueranteil enthält oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Indexed()> _
        <ComponentModel.Browsable(False)> _
        <Persistent("VerweisID")> _
        Public Property ParentID() As Integer
            Get
                Return m_targetID
            End Get
            Set(ByVal value As Integer)

                SetPropertyValue(Of Integer)("CashJournalID", m_targetID, value)
            End Set
        End Property



        Public Sub New(ByVal session As Session)
            MyBase.New(session)

            If TaxValuePair.m_taxListByValue Is Nothing Then
                TaxValuePair.m_taxListByValue = New Dictionary(Of Decimal, TaxRate)


            End If

        End Sub

        ''' <summary>
        ''' Nach dem Laden einige andere Dinge ausführen
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub OnLoaded()
            MyBase.OnLoaded()

            For Each taxItem As TaxRate In MainApplication.TaxRates
                If Not TaxValuePair.m_taxListByValue.ContainsKey(taxItem.TaxValue) Then
                    TaxValuePair.m_taxListByValue.Add(taxItem.TaxValue, taxItem)
                End If
            Next
        End Sub

        ''' <summary>
        ''' Ruft einen Anzeigetext ab, de den Steuersatz und den darin enthaltenen Betrag anzeigt
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.TaxValue & "%, " & Me.ValueInTax.ToString("c")
        End Function
    End Class
End Namespace
