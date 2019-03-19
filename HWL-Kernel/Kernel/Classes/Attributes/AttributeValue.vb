Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data


Namespace Kernel.Attributes


    ''' <summary>
    ''' Stellt einen Attribute-Werte paar da
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(AttributeValue.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class AttributeValue
        Inherits StaticItem
        Implements IDataItem
        Public Const TableName As String = "AttributeValuePair"

        ''' <summary>
        ''' Enthält einen String, der den Text-Wert darstellt
        ''' </summary>
        ''' <remarks></remarks>
        Private m_valueString As String

        Private m_valueBoolean As Boolean

        ''' <summary>
        ''' enthält den Zeiger auf den Artikel. Einmal gestezte Werte können nie verändert werden
        ''' </summary>
        ''' <remarks></remarks>
        Private m_articleID As String

        ''' <summary>
        ''' TBD: Bei wertelisten Zeigeer auf den Wert (ist dann eiun String)
        ''' </summary>
        ''' <remarks></remarks>
        Private m_valueID As String

        ''' <summary>
        ''' Zeiger auf die Attributedefinition
        ''' </summary>
        ''' <remarks></remarks>
        Private m_AttributeDefinitionID As String

        Private m_decimalValue As Decimal
        Private m_attributeDefinition As AttributeValueDefinition

        ''' <summary>
        ''' Enthält den Wert bei einem Zahlenfeld
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("DecimalValue")> _
        Public Property DecimalValue() As Decimal
            Get
                Return m_decimalValue
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DecimalValue", m_decimalValue, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen des Attributes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("AttributeName", "Name d. Eigenschaft")> _
        Public ReadOnly Property AttributeName() As String
            Get

                If GetAttributeDefinition() IsNot Nothing Then
                    Return GetAttributeDefinition.AttributeName
                Else
                    Return m_mainApplication.Languages.GetText("AttributeNotFoundPlaceholder", "<Nicht gefunden>")
                End If

            End Get
        End Property

        ''' <summary>
        ''' Stellt die Verweis-ID auf die Definition des Attributes in seiner Klasse (AttributeValueDefinition) dar dar
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(32)> _
        <Persistent("AttributeID")> _
        Public Property AttributeDefinitionID() As String
            Get
                Return m_AttributeDefinitionID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AttributeDefinitionID", m_AttributeDefinitionID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Definition des Attributes ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAttributeDefinition() As AttributeValueDefinition

            If m_attributeDefinition Is Nothing Then
                Dim criteria As New DevExpress.Data.Filtering.BinaryOperator("ReplikID", Me.AttributeDefinitionID)
                Dim av As New Attributes.AttributeValueDefinitions(MainApplication, criteria)
                If av.Count > 0 Then
                    m_attributeDefinition = av(0)
                Else
                    ' Hmm... nichts gefunden...
                End If
            Else
                m_attributeDefinition.Reload()
            End If

                Return m_attributeDefinition
        End Function


        ''' <summary>
        ''' Ruft eine Verweis-ID ab, die auf einen Wert zeigt bei Auswahlwerten (1 aus n - WerteListen)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ValueID")> _
        Public Property ValueID() As String
            Get
                Return m_valueID
            End Get
            Set(ByVal value As String)
                m_valueID = value
            End Set
        End Property

        ''' <summary>
        ''' Enthält die ArtikelID, zu der dieser Wert gehört
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ArticleID")> _
        <Size(32)> _
        Public Property ArticleID() As String
            Get
                Return m_articleID
            End Get
            Set(ByVal value As String)
                m_articleID = value
            End Set
        End Property


        ''' <summary>
        ''' Ruft einen Boolean-Wert ab, bei Ja/Nein Feldern
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("BoolValue")> _
        Public Property BoolValue() As Boolean
            Get
                Return m_valueBoolean
            End Get
            Set(ByVal value As Boolean)
                m_valueBoolean = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen String-Wert ab, bei Textfeldern
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("StringValue")> _
        Public Property StringValue() As String
            Get
                Return m_valueString
            End Get
            Set(ByVal value As String)
                m_valueString = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Wert ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DisplayName("Value", "Wert")> _
        Public Property DisplayValue() As Object
            Get

                If m_attributeDefinition IsNot Nothing Then
                    Select Case GetAttributeDefinition.AttributeType
                        Case enumAttributeType.Alphanummeric : Return StringValue
                        Case enumAttributeType.Float, enumAttributeType.Nummeric : Return DecimalValue
                        Case enumAttributeType.YesNo : Return BoolValue
                        Case enumAttributeType.DateType
                            If Not String.IsNullOrEmpty(StringValue) Then
                                Return DateValue(StringValue)
                            Else
                                Return New Date
                            End If

                        Case enumAttributeType.ChooseOne
                            Try
                                Return GetAttributeDefinition.GetMultiselectProfile.GetValueList.GetItem(Me.ValueID)
                            Catch ex As Exception
                                Return Nothing
                            End Try


                        Case Else
                            '' Throw New ArgumentException("Der Typ: " & m_attribuetDefinition.AttributeType & " ist nicht definiert")
                            Return String.Empty
                    End Select
                Else
                    Return String.Empty
                End If

            End Get
            Set(ByVal value As Object)

                Select Case m_attributeDefinition.AttributeType
                    Case enumAttributeType.Alphanummeric : Me.StringValue = CStr(value)
                    Case enumAttributeType.Float, enumAttributeType.Nummeric : DecimalValue = CDec(value)
                    Case enumAttributeType.YesNo : BoolValue = CBool(value)
                    Case enumAttributeType.DateType : Me.StringValue = CStr(value) ' Keine Typumwandlung
                    Case enumAttributeType.ChooseOne
                        ' Dann war der Typ ein MutiSelectValue
                        If TypeOf value Is MultiSelectValue Then
                            ValueID = CType(value, MultiSelectValue).Key
                        End If
                    Case Else
                        Throw New ArgumentException("Der Typ: " & m_attributeDefinition.AttributeType & " ist nicht definiert")
                End Select
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Anzeigetext des Wertes ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return CStr(Me.DisplayValue)
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace