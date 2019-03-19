Option Explicit On
Option Strict On

Imports ClausSoftware.Data
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data


Namespace Kernel.Attributes


    ''' <summary>
    ''' Stellt einen Wert für die Mehrfachauswahl von Attributen dar
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(MultiSelectProfile.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class MultiSelectProfile
        Inherits StaticItem
        Implements IDataItem
        Public Const TableName As String = "MultiSelectProfile"

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_valueDisplayName As String

        <System.ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_profileValues As MultiSelectValues

        ''' <summary>
        ''' Ruft einen Wert ab der angibt, ob dieses Profil oder einer seiner werte eine Änderungen hatten
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides ReadOnly Property HasChanged() As Boolean
            Get
                Dim m_HasChanges As Boolean
                m_HasChanges = MyBase.HasChanged Or Me.GetValueList.HasChanges
                Return m_HasChanges

            End Get
        End Property

        ''' <summary>
        ''' Ruft den Namen des Profiles ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("DisplayName")> _
        Public Property DisplayName() As String
            Get
                Return m_valueDisplayName
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("DisplayName", m_valueDisplayName, value)
            End Set
        End Property



        ''' <summary>
        ''' Ruft die Werteliste ab, die diesem Profil zugeordnet wurde
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetValueList() As MultiSelectValues
            If m_profileValues Is Nothing Then
                Dim criteria As DevExpress.Data.Filtering.CriteriaOperator = DevExpress.Data.Filtering.CriteriaOperator.Parse("ProfileID='" & Me.Key & "'")
                m_profileValues = New MultiSelectValues(MainApplication, criteria)
                m_profileValues.ParentID = Me.Key
            End If
            Return m_profileValues
        End Function


        ''' <summary>
        ''' Speichert das Profil, sowie damit verknüpfte Wertlisten
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()
            MyBase.Save()
            Me.GetValueList.Save()
        End Sub

        ''' <summary>
        ''' Löscht das Profil, sowie damit verknüpfte Wertlisten
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Delete()
            MyBase.Delete()
            Me.GetValueList.Delete()
        End Sub

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        ''' <summary>
        ''' Ruft den Namen dieses Profiels ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.DisplayName
        End Function

    End Class
End Namespace