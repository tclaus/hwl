'Option Explicit On
'Option Strict On


'Imports ClausSoftware.Tools
'Imports ClausSoftware.Data
'Imports DevExpress.Data.Filtering
'Imports System.Text
'Imports DevExpress.Xpo.DB

'Namespace Kernel

'    ''' <summary>
'    ''' Stellt eine Liste von Journaldocument - Typen  da.
'    ''' </summary>
'    ''' <remarks></remarks>
'    Public Class JournalDocumentMetaInfos
'        Inherits BaseCollection(Of JournalDocumentMetaInfo)
'        Implements IDataCollection

'        Private m_dict As Dictionary(Of String, JournalDocumentMetaInfo)

'        ''' <summary>
'        ''' Ruft weitere Informationen des Dokuments ab
'        ''' </summary>
'        ''' <param name="id">Die Dokumenten - Zugriffsnummer</param>
'        ''' <value></value>
'        ''' <returns></returns>
'        ''' <remarks></remarks>
'        Function GetByDocumentKey(id As String) As JournalDocumentMetaInfo
'            If m_dict Is Nothing Then Rebuild()
'            Return m_dict(id)
'        End Function



'        Public Sub New(ByVal BasisApplikation As mainApplication)

'            MyBase.New(BasisApplikation)

'            Initialize()

'        End Sub


'        Public Overrides Sub Reload()
'            MyBase.Reload()
'            Rebuild()
'        End Sub

'        ''' <summary>
'        ''' Baut eine Liste mit IDs und den Typen auf. 
'        ''' </summary>
'        ''' <remarks></remarks>
'        Private Sub Rebuild()
'            If m_dict Is Nothing Then m_dict = New Dictionary(Of String, JournalDocumentMetaInfo)

'            m_dict.Clear()
'            For Each item As JournalDocumentMetaInfo In Me
'                m_dict.Add(item.Key, item)
'            Next

'        End Sub

'        Public Sub New(ByVal baseApplication As mainApplication, ByVal criteria As CriteriaOperator)
'            MyBase.New(baseApplication, criteria)
'            Initialize()

'        End Sub


'        Public Sub Initialize() Implements Data.IDataCollection.Initialize

'        End Sub

'        ''' <summary>
'        ''' Ruf eine neue Auflistung ab
'        ''' </summary>
'        ''' <returns></returns>
'        ''' <remarks></remarks>
'        Public Shadows Function GetNewCollection() As Data.BaseCollection(Of JournalDocumentMetaInfo)
'            Return MyBase.GetNewCollection()
'        End Function

'        ''' <summary>
'        ''' Ruft eine neue Auflstung mit dem angegebenen Kriterium ab
'        ''' </summary>
'        ''' <param name="criteria"></param>
'        ''' <returns></returns>
'        ''' <remarks></remarks>
'        Public Shadows Function GetNewCollection(criteria As CriteriaOperator) As Data.BaseCollection(Of JournalDocumentMetaInfo)
'            Return MyBase.GetNewCollection(criteria)
'        End Function

'    End Class
'End Namespace
