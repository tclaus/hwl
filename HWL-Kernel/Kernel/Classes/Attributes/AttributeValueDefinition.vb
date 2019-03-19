Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data


Namespace Kernel.Attributes


    ''' <summary>
    '''  Stellt die Definition eines Klassenattributes
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(AttributeValueDefinition.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class AttributeValueDefinition
        Inherits StaticItem
        Implements IDataItem

        Public Const TableName As String = "AttributeValueDefinition"

        Private m_attributeName As String
        ''' <summary>
        ''' Enthält die  ID der Klasse, in der dieser Wert zugeordnet ist
        ''' </summary>
        ''' <remarks></remarks>
        Private m_classID As String
        Private m_attributeType As enumAttributeType

        Private m_MultiSelectdefinitionID As String
        Private m_multiselectProfile As MultiSelectProfile

        ''' <summary>
        ''' Ruft die ID der Multiselect-Eigenschaft ab. Gilt nur in Verbidnung mit dem Mutiselect Typ
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(32)> _
        <Persistent("MultiSelectID")> _
        Private Property MultiSelectID() As String
            Get
                Return m_MultiSelectdefinitionID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MultiSelectID", m_MultiSelectdefinitionID, value)
            End Set
        End Property



        ''' <summary>
        ''' Ruft das gewählte Multiselectprofil ab, sofern der Type eines der beiden Profiltypen 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MultiselectProfile() As MultiSelectProfile
            Get
                If Me.AttributeType = enumAttributeType.ChooseOne Then
                    If m_multiselectProfile Is Nothing Then
                        m_multiselectProfile = GetMultiselectProfile()
                    End If
                End If

                Return m_multiselectProfile
            End Get
            Set(ByVal value As MultiSelectProfile)
                m_multiselectProfile = value

                Me.MultiSelectID = value.Key

            End Set
        End Property




        ''' <summary>
        ''' Ruft die Mehrfachauswahl ab, sofern der übergeordenete Typ korrekt ist
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMultiselectProfile() As MultiSelectProfile
            If Me.AttributeType = enumAttributeType.ChooseOne Or Me.AttributeType = enumAttributeType.ChooseSome Then

                Dim Criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("ReplikID ='" & Me.MultiSelectID & "'")
                Dim profile As MultiSelectProfiles = New MultiSelectProfiles(MainApplication, Criteria)
                'es gibt genau ein Profil mit dem Schlüssel 
                If profile.Count > 0 Then
                    Return profile(0)
                Else
                    Debug.Assert(False, "Übel !")
                End If

            End If

            Debug.Print("Kein Multiselect Typ!")
            Return Nothing
        End Function

        ''' <summary>
        ''' Ist True, wenn diese Definition bereits von einem oder mehreren Artikel verwendet wird, also ein Wert zugewiesen wurde
        ''' </summary>
        ''' <returns>True, wenn mindestends ein Artikel diesen Wert bereits verwendet, sonst False</returns>
        ''' <remarks>Es wird jedesmal eine Datenabnkabfrage ausgeführt, um diesen Wert zu ermitteln</remarks>
        Public Function IsInUse() As Boolean
            Dim sql As String = "Select count(*) from " & Attributes.AttributeValue.TableName & " WHERE AttributeID='" & Me.Key & "'"
            Dim result As Integer = CInt(MainApplication.Database.ExcecuteScalar(sql))

            Return result > 0

        End Function

        ''' <summary>
        ''' Ruft den Type dieses Wertes ab oder legt diesen fest. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("AttributeType")> _
        Public Property AttributeType() As enumAttributeType
            Get
                Return m_attributeType

            End Get
            Set(ByVal value As enumAttributeType)
                SetPropertyValue(Of enumAttributeType)("AttributeType", m_attributeType, value)
            End Set
        End Property

        ''' <summary>
        ''' Stellt einen Verweis auf die Klasse der Attribute dar
        ''' </summary>
        ''' <remarks></remarks>
        <Indexed()> _
        <Size(32)> _
        <Persistent("AttributeClassID")> _
        Public Property AttributeClassID() As String
            Get
                Return m_classID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AttributeClassID", m_classID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen eines Wertes ab oder legt diesen fest.
        ''' Der Name kann auch als Schlüssel für Texte verwendet werden
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(50)> _
        <Persistent("AttributeName")> _
        Public Property AttributeName() As String
            Get
                Return m_attributeName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("AttributeName", m_attributeName, value)
            End Set
        End Property

        ''' <summary>
        ''' Löscht diese Definition und alle bereits zugewiesenen Attribut-Werte
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Delete()

            ' Alle jemals zugewiesene werte entfernen. Eine Prüfung sollte der Aufrufer bereits erledigt haben..
            Dim Sql As String = "DELETE FROM " & Attributes.AttributeValue.TableName & " WHERE AttributeID='" & Me.Key & "'"
            m_mainApplication.Database.ExcecuteNonQuery(Sql)

            MyBase.Delete()
        End Sub


        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

    End Class
End Namespace