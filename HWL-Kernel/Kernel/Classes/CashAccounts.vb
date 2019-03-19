Option Explicit On
Option Strict On
Imports ClausSoftware.Data
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo.DB

Namespace Kernel


    ''' <summary>
    ''' Stellt eine Auflistung von Buchungskonten dar
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CashAccounts

        ' Kassenbuch erben
        Inherits BaseCollection(Of CashAccount)
        Implements IDataCollection

        Private m_list As New Dictionary(Of Integer, CashAccount)


        Public Sub New(ByVal BasisApplikation As mainApplication, ByVal criteria As String)

            MyBase.New(BasisApplikation, CriteriaOperator.Parse(criteria))

            Initialize()
            LoadCache()
        End Sub


        Public Sub New(ByVal BasisApplikation As mainApplication)

            MyBase.New(BasisApplikation)


            Initialize()
            LoadCache()
        End Sub

        ''' <summary>
        ''' Ruft eine Auflistung aller Parent-objekte ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetBaseAccounts() As CashAccounts
            Dim parentaccounts As New CashAccounts(MainApplication, "ParentID = 0")
            Return parentaccounts

        End Function

        ''' <summary>
        ''' Ruft ein Buchungskonto anhand der AccountID und nicht nach der Key-ID ab
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function GetAccountByID(ByVal id As Integer) As CashAccount

            If m_list.ContainsKey(id) Then
                Return m_list(id)
            Else
                Return Nothing
            End If
        End Function

        Private Sub LoadCache()

            m_list.Clear()

            For Each account As CashAccount In Me

                If Not m_list.ContainsKey(account.AccountID) Then
                    m_list.Add(account.AccountID, account)
                End If

            Next
        End Sub


        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder
            With DisplayProps
                .Append("AccountNumber;")
                .Append("AccountName;")

                Me.DisplayableProperties = .ToString
            End With

            Me.Sorting.Add(New SortProperty("AccountNumber", SortingDirection.Ascending))
            Me.Sorting.Add(New SortProperty("AccountName", SortingDirection.Ascending))
        End Sub



        Private Sub CashAccounts_CollectionChanged(ByVal sender As Object, ByVal e As DevExpress.Xpo.XPCollectionChangedEventArgs) Handles Me.CollectionChanged

            If e.CollectionChangedType = XPCollectionChangedType.AfterAdd Then

                If Not m_list.ContainsKey(CType(e.ChangedObject, CashAccount).AccountID) Then
                    m_list.Add(CType(e.ChangedObject, CashAccount).AccountID, CType(e.ChangedObject, CashAccount))
                End If
            End If

            If e.CollectionChangedType = XPCollectionChangedType.AfterRemove Then
                If m_list.ContainsKey(CType(e.ChangedObject, CashAccount).AccountID) Then
                    m_list.Remove(CType(e.ChangedObject, CashAccount).AccountID)
                End If
            End If


        End Sub
    End Class
End Namespace