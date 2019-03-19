Imports ClausSoftware.Tools
Imports ClausSoftware.Data


Namespace Kernel
    ''' <summary>
    ''' 'Hält eine Auflistung von Textvorlagen für Angebote / Rechnungen
    ''' </summary>
    ''' <remarks></remarks>
    Public Class HistoryCategories
        Inherits BaseCollection(Of HistoryCategory)
        Implements IDataCollection
        Private Const TransactionID As String = "B2559A2DF1DA48d2B0A6678C1B5F2269" ' DIE id für die Geschäftsvorfälle-Kategorie
        Private Const ReminderID As String = "B2559A2DF1DA48d2B0A6678C1B5F2270" ' DIE id für die Mahnungen-Kategorie
        Private Const CommonGroupID As String = "B2559A2DF1DA48d2B0A6678C1B5F2271" ' DIE id für die allgemeine Kategorie

        Private Shared m_transactionCategory As HistoryCategory
        Private Shared m_remindersCategory As HistoryCategory
        Private Shared m_commonCategory As HistoryCategory


        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)
            Initialize()
        End Sub
        '''<summary>
        ''' Ruft die System-Kategorie der Mahnungen ab 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRemindersCategory() As HistoryCategory
            If m_remindersCategory Is Nothing Then
                m_remindersCategory = GetItem(ReminderID)
                If m_remindersCategory Is Nothing Then
                    m_remindersCategory = Me.GetNewItem
                    m_remindersCategory.CategoryName = MainApplication.Languages.GetText("msgReminder", "Mahnung")
                    m_remindersCategory.ReplikID = ReminderID
                    m_remindersCategory.Save()
                    Me.Add(m_remindersCategory)
                End If
            End If


            Return m_remindersCategory

        End Function

        '''<summary>
        ''' Ruft die System-Kategorie für allgemeine (wichtige) Mitteilungen
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCommonCategory() As HistoryCategory
            If m_commonCategory Is Nothing Then
                m_commonCategory = GetItem(CommonGroupID)
                If m_commonCategory Is Nothing Then
                    m_commonCategory = Me.GetNewItem
                    m_commonCategory.CategoryName = MainApplication.Languages.GetText("msgCommonCategory", "Allgemeines")
                    m_commonCategory.ReplikID = CommonGroupID
                    m_commonCategory.Save()
                    Me.Add(m_commonCategory)
                End If
            End If
            Return m_commonCategory
        End Function


        ''' <summary>
        ''' Ruft die System-Kategorie der Geschäftsvorfälle ab.
        ''' Wenn diese Kategorie nicht oder nicht mehr existiert, wird diese erneut angelegt
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTransactionCategory() As HistoryCategory
            If m_transactionCategory Is Nothing Then
                m_transactionCategory = GetItem(TransactionID)
                If m_transactionCategory Is Nothing Then
                    m_transactionCategory = Me.GetNewItem
                    m_transactionCategory.CategoryName = MainApplication.Languages.GetText("msgTransaction", "Geschäftsvorfall")
                    m_transactionCategory.ReplikID = TransactionID
                    m_transactionCategory.Save()
                    Me.Add(m_transactionCategory)
                End If
            End If


            Return m_transactionCategory

        End Function

        ''' <summary>
        ''' Ruft die Namentlich angegebene Kategorie ab. 
        ''' Wenn diese nicht existiert, kann diese automatisch angelegt werden
        ''' </summary>
        ''' <param name="categoryName">Der Name der zu suchenden Kategorie</param>
        ''' <param name="autocreate">bei True wird die Kategorie angelegt, falls diese nicht gefunden werden konnte. </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function FindHistoryCategory(ByVal categoryName As String, ByVal autocreate As Boolean) As HistoryCategory
            For Each item As HistoryCategory In MainApplication.HistoryCategories
                If item.CategoryName.Equals(categoryName, StringComparison.InvariantCultureIgnoreCase) Then
                    Return item
                End If
            Next
            If autocreate Then
                Dim newCategory As HistoryCategory = MainApplication.HistoryCategories.GetNewItem
                newCategory.CategoryName = categoryName
                MainApplication.HistoryCategories.Add(newCategory)
                newCategory.Save()
                Return newCategory
            End If

            Return Nothing

        End Function


        Public Sub Initialize() Implements IDataCollection.Initialize

            GetTransactionCategory()
            GetRemindersCategory()

            Dim DisplayProps As New Text.StringBuilder

            DisplayProps.Append("Text;")
            Me.DisplayableProperties = DisplayProps.ToString
        End Sub
    End Class
End Namespace