Option Explicit On
Option Strict On
Imports ClausSoftware.Data


Imports DevExpress.Xpo
Namespace Kernel


    ''' <summary>
    ''' Stellt eine Mahnung dar
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent(Reminder.TableName)> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Reminder
        Inherits StaticItem
        Implements IDataItem

        Public Const TableName As String = "Mahnungen"

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_level As Integer

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_docLink As String

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_remindersText As String

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_remindersSubject As String
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_remindersDate As DateTime

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_oldDate As String

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_ClaimDocuments As String

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_FinalDate As DateTime

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_isInactiveReminder As Boolean = False

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Private m_remindersCost As Decimal


        Protected Overrides Sub OnSaved()
            MyBase.OnSaved()
            Me.SetNewHistoryItem()
        End Sub

        ''' <summary>
        ''' Setzt ein neues History-Item in dem entsprechendem Adress-Satz
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetNewHistoryItem()
            If Me.ParentTransaction.Adress Is Nothing Then
                Throw New ArgumentException("Es muss eine Adresse angegeben werden, bevor ein History-Item erstellt werden kann")
            End If
            ' Wird bei bereits existierendem Item dieses aktualisiert? 
            ' = > Nö! 

            Dim localAdress As Adress = Me.ParentTransaction.Adress
            Dim localHistory As AddressHistoryItems = localAdress.History

            If Not localHistory.ContainsSystemItem(Me.Key) Then
                ' Nicht bereits existierende Elemente erneut anlegen
                Debug.Print("Lege History-Element für neue Mahnung an")
                Dim myItem As AddressHistoryItem = localHistory.GetNewItem()
                myItem.Adress = localAdress
                myItem.Category = m_mainApplication.HistoryCategories.GetRemindersCategory
                myItem.IsSystemMessage = True
                myItem.ItemDate = Me.RemindersDate
                myItem.ParentItemID = Me.Key
                myItem.Text = "Eine Mahnung wurde angelegt. " & vbCrLf & _
                "Mahnung: " & Me.ToString & vbCrLf & _
"Rechnung: " & Me.ParentTransaction.ToString & vbCrLf & _
"Betrag: " & Me.ParentTransaction.UnpaidAmmount.ToString("c") & vbCrLf & _
                ""
                'TODO: NLS
                myItem.Save()
            End If


        End Sub

        ''' <summary>
        ''' Ruft die Standard-Verzögerung ab, nach wievielen Tagen diese Mahnung gezahlt werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DefaultNextTimeframe() As Integer
            Get
                'TODO: Defaultwerte aus den allgemienen Einstellungen abholen 

                Select Case Me.RemindersLevel
                    Case 1 : Return 14
                    Case 2 : Return 14
                    Case 3 : Return 10
                    Case Else : Return 10
                End Select


            End Get
        End Property


        ''' <summary>
        ''' Schlüssel zu der ursprünglichen Forderung (Transaktion)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>War früher eine ID zu dem Journal-Dokument (DocID) , nun wird stattdessen zur Foredrung verwiesen, da dort auch die Zahlungseingänge verwaltet werden können</remarks>
        <Indexed()> _
        <Size(32)> _
        <Persistent("ClaimDocumentID")> _
      Public Property ClaimDocumentID() As String
            Get
                Return m_ClaimDocuments
            End Get
            Set(ByVal value As String)
                m_ClaimDocuments = value
            End Set
        End Property


        <Obsolete("Das alte Datum-Feld in Mahnungen nicht mehr verwenden!")> _
        <Persistent("Datum")> _
                Public Property OldDate() As String
            Get
                Return m_oldDate
            End Get
            Set(ByVal value As String)
                m_oldDate = value
            End Set
        End Property





        ''' <summary>
        ''' Legt die zusätzlichen Mahnkosten fest oder ruuft diese ab.
        ''' Mahnkosten werden zum Recnungsbetrag aufgeschlagen, aber im Mahntext erwähnt.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("RemindersCosts")> _
        Public Property RemindersCost() As Decimal
            Get
                Return m_remindersCost
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("RemindersCost", m_remindersCost, value)
            End Set
        End Property

        ''' <summary>
        ''' Wenn wahr, ist diese Mahnung gestoppt und löst keine weiteren Mahnungen mehr aus. Damit ist diese Mahnung als erledigt gekennzeichnet.
        ''' (Nicht unbedingt auch als Gezahlt.)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("IsInactiveReminder")> _
        Public Property IsInactiveReminder() As Boolean
            Get
                Return m_isInactiveReminder
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsInactiveReminder", m_isInactiveReminder, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft das Ende-datum ab, bis wann diese Mahnung gezahlt werden soll
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("FinalDate")> _
        Public Property RemindersFinalDate() As DateTime
            Get
                Return m_FinalDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of Date)("FinalDate", m_FinalDate, value)
            End Set
        End Property


        ''' <summary>
        ''' Ruft das Mahndatum ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Date")> _
        Public Property RemindersDate() As DateTime
            Get
                Return m_remindersDate
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of Date)("RemindersDate", m_remindersDate, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die Betreffzeile der Mahnung ab oder legt diese fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("MahnBetreff")> _
        Public Property RemindersSubject() As String
            Get
                Return m_remindersSubject
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RemindersSubject", m_remindersSubject, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Haupttext der Mahnung ab oder legt diesen fest. Je nach MAhnstufe sollte der Text unterschiedlich streng ausfallen.
        ''' Der Text liegt als RTF vor.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("MahnText")> _
        <Size(SizeAttribute.Unlimited)> _
        Public Property RemindersText() As String
            Get
                Return m_remindersText
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RemindersText", m_remindersText, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die übergerodnete Transaktion ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ParentTransaction() As Transaction
            Get
                Return m_mainApplication.Transactions.GetItem(Me.ClaimDocumentID)
            End Get
            Set(ByVal value As Transaction)
                Me.ClaimDocumentID = value.Key
            End Set
        End Property


        ''' <summary>
        ''' Ruft die Mahnstufe ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Stufe")> _
        Public Property RemindersLevel() As Integer
            Get
                Return m_level
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Level", m_level, value)
            End Set
        End Property



        Public ReadOnly Property LevelDisplayText() As String
            Get
                ' TODO: NLS: einen Leveltext ermitteln
                Select Case Me.RemindersLevel
                    Case 1 : Return "Zahlungserinnerung (1.Mahnung)"
                    Case 2 : Return "Aufforderungzu Zahlen (2. Mahnung)"
                    Case 3 : Return "Letze Aufforderung (3. Mahnung)"
                    Case Else
                        Return "-da fällt mir nichts mehr ein.."
                End Select
            End Get
            
        End Property


        ''' <summary>
        ''' Ruft einen Anzeigetext dieser Mahnung ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Dim text As String
            text = m_mainApplication.Languages.GetText("msgReminderLevelDate", "{0}. Mahnung vom {1}" & Me.RemindersDate.ToString("d"), Me.RemindersLevel, Me.RemindersDate.ToString("d"))

            Return text
        End Function

        ''' <summary>
        ''' Setzt Standard-texte für die angegebene Mahnstufe
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetDefaultText()
            
            Select Case RemindersLevel
                Case 1
                    RemindersSubject = GetText("msgFirstRemindersubject", "1. Mahnung")
                    RemindersText = My.Resources.First_Remind
                Case 2
                    RemindersSubject = GetText("msgFSecondReminderSubject", "2. Mahnung")
                    RemindersText = My.Resources.Second_Remind
                Case 3
                    RemindersSubject = GetText("msgLastReminderSubject", "3. Mahnung")
                    RemindersText = My.Resources.First_Remind
                Case Else
                    Throw New ArgumentException("Es kann nur Mahnstufen 1-3 geben!")
            End Select


        End Sub

        ''' <summary>
        ''' Erstetzt die Platzhalter im Text gegnen die 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property GetFinalRTFText() As String
            Get
                'RN,  - Rechnungsnummer
                'RT'  - Rechnungtext
                'RD  -- Recnungsdatum
                'RB    - Rechnungsbetrag (Brutto- Betrag)
                'BV   - eigene Bankverbindung

                'DH   - Datum Heute

                Return Me.RemindersText

            End Get
        End Property



        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub
    End Class
End Namespace