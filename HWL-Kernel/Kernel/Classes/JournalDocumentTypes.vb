Option Explicit On
Option Strict On


Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering
Imports System.Text
Imports DevExpress.Xpo.DB

Namespace Kernel

    ''' <summary>
    ''' Stellt eine Liste von Journaldocument - Typen  da.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class JournalDocumentTypes
        Inherits BaseCollection(Of JournalDocumentType)
        Implements IDataCollection

        Private m_dict As Dictionary(Of Integer, JournalDocumentType)

        ''' <summary>
        ''' Ruft einen Typ anhand des DokumentenTyps ab. (Die Datenbank-ID wird hier nicht verwendet!)
        ''' </summary>
        ''' <param name="id">Die Dokumenten - Zugriffsnummer</param>
        ''' <remarks></remarks>
        Function GetByDocumentID(id As Integer) As JournalDocumentType
            If m_dict Is Nothing Then Rebuild()
            Return m_dict(id)
        End Function

        ''' <summary>
        ''' Ruft den Dokumententyp anhand des (alten) Enums ab
        ''' </summary>
        ''' <param name="idType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetByDocumentID(idType As enumJournalDocumentType) As JournalDocumentType
            If m_dict Is Nothing Then Rebuild()
            Return m_dict(CInt(idType))
        End Function


        Public Sub New(ByVal BasisApplikation As MainApplication)

            MyBase.New(BasisApplikation)

            Initialize()

        End Sub


        Public Overrides Sub Reload()
            MyBase.Reload()
            Rebuild()
        End Sub

        ''' <summary>
        ''' Baut eine Liste mit IDs und den Typen auf. 
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Rebuild()
            If m_dict Is Nothing Then m_dict = New Dictionary(Of Integer, JournalDocumentType)

            m_dict.Clear()
            For Each item As JournalDocumentType In Me
                m_dict.Add(item.InternalID, item)
            Next

        End Sub

        Public Sub New(ByVal baseApplication As MainApplication, ByVal criteria As CriteriaOperator)
            MyBase.New(baseApplication, criteria)
            Initialize()

        End Sub


        Public Sub Initialize() Implements Data.IDataCollection.Initialize

        End Sub

        Public Overrides Function GetNewCollection() As Data.BaseCollection(Of JournalDocumentType)
            Return MyBase.GetNewCollection()
        End Function

    End Class
End Namespace
