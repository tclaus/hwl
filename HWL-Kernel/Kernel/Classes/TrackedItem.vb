Option Explicit On
Option Strict On

Imports ClausSoftware.Data



Namespace Kernel

    ''' <summary>
    ''' Stellt eine Klasse dar, die ein bestehendes Objekt um die Attribute ChangedAt / ChangedBy; CreatedAt/CratedBy erweitert und eindeutige Benutzerdaten enthält,
    ''' um Ersteller und letze Änerung zu verfolgen
    ''' </summary>
    ''' <remarks></remarks>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
<DebuggerDisplay("CreatedBy={}, ChangedAt={ChangedAt}")> _
<DefaultMembersPersistence(DefaultMembersPersistence.OnlyDeclaredAsPersistent)> _
<NonPersistent()> _
Public Class TrackedItem
        Inherits StaticItem
        Implements IDataItem

        Private m_changedAt As Date
        Private m_changedBy As String = String.Empty

        Private m_createdAt As Date = Now
        Private m_createdByID As String = String.Empty




        ''' <summary>
        ''' Ruft den Benutzer-Account ab, von dem Useraccount, de diesen Eintrag angelegt hat.
        ''' Wenn keine Benutzerverwaltung existiert, dann ist das der Rechenrname / Benutzername des aktuellen Benutzers, damit bleibt der wert unterscheidbar. 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Public Function CreatedBy() As security.User
            If Not String.IsNullOrEmpty(Me.CreatedByID) Then
                Dim user As Kernel.security.User = MainApplication.Users.GetItem(Me.CreatedByID)
                If user IsNot Nothing Then
                    Return user
                Else
                    Return MainApplication.CurrentUser
                End If
            Else
                Return MainApplication.CurrentUser
            End If

        End Function

        ''' <summary>
        ''' Ruft den Benutzeraccount ab, der zuletzt an diesem Datensatz eine Änderung vorgenommen hat oder setzt diesen 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("LastChangedBy", "Zuletzt geändert von")> _
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Public Property ChangedBy() As security.User
            Get
                Return MainApplication.Users.GetItem(Me.ChangedByID)
            End Get
            Set(ByVal value As security.User)
                If value IsNot Nothing Then
                    Me.ChangedByID = value.Key
                Else
                    Me.ChangedByID = ""
                End If

            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID des Erstellers ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("CreatedBy", "Angelegt von")> _
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        <Size(64)> _
        <Persistent("CreatedByID")> _
        Public Property CreatedByID() As String
            Get
                If String.IsNullOrEmpty(m_createdByID) Then m_createdByID = MainApplication.CurrentUser.Key

                Return m_createdByID
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = String.Empty
                If value.Length > m_mainApplication.Database.GetColumnCharacterLength(Me.ClassInfo.TableName, "CreatedByID") Then
                    value = value.Substring(0, CInt(m_mainApplication.Database.GetColumnCharacterLength(Me.ClassInfo.TableName, "CreatedByID")))
                End If
                m_createdByID = value
            End Set
        End Property


        ''' <summary>
        ''' Ruft das Erstellungsdatum des Eintrages ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("CreatedAt", "Angelegt am")> _
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        <Persistent("CreatedAt")> _
        Public Property CreatedAt() As Date
            Get

                If m_createdAt <= Date.MinValue Then
                    ' Datum reparieren, falls defekt
                    If m_changedAt >= Date.MinValue Then
                        m_createdAt = m_changedAt
                    Else
                        m_createdAt = New Date(2000, 1, 1)
                    End If

                    Me.SavewithoutTracking()
                End If

                Return m_createdAt
            End Get
            Set(ByVal value As Date)

                SetPropertyValue(Of Date)("CreatedAt", m_createdAt, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft die ID des Benutzers ab, der die letzte Ändenrung durchgeführt hat
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("LastChangedBy", "Zuletzt geändert von")> _
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        <Size(64)> _
        <Persistent("ChangedByID")> _
        Public Property ChangedByID() As String
            Get
                If m_changedBy Is Nothing Then
                    m_changedBy = String.Empty
                End If
                Return m_changedBy
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then value = String.Empty
                If value.Length > m_mainApplication.Database.GetColumnCharacterLength(Me.ClassInfo.TableName, "ChangedByID") Then
                    value = value.Substring(0, CInt(m_mainApplication.Database.GetColumnCharacterLength(Me.ClassInfo.TableName, "ChangedByID")))
                End If

                SetPropertyValue(Of String)("ChangedByID", m_changedBy, value)

            End Set
        End Property


        ''' <summary>
        ''' Ruft das Datum ab, an dem dieser Datensatz zuletzt geändert wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("LastChangedAt", "Zuletzt geändert am")> _
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        <Persistent("ChangedAt")> _
        Public Property ChangedAt() As Date
            Get

                If m_changedAt <= Date.MinValue Then ' ungültiges Datum
                    If CreatedAt >= Date.MinValue Then
                        m_changedAt = Me.CreatedAt
                    Else
                        m_changedAt = Today
                    End If
                    Me.SavewithoutTracking()
                End If


                Return m_changedAt
            End Get
            Set(ByVal value As Date)
                SetPropertyValue(Of Date)("ChangedAt", m_changedAt, value)

            End Set
        End Property

        Protected Overrides Sub OnSaving()
            'TODO: wie erkenne ich heir, das der Datensatz neu ist ? 

            MyBase.OnSaving()
        End Sub

        ''' <summary>
        ''' Speichert den Eintrag ab, jedoch ohne Tracking-Daten (ChangedAt / ChangedBy) zu sichern
        ''' </summary>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)> _
        Public Sub SavewithoutTracking()
            MyBase.Save()
        End Sub
        ''' <summary>
        ''' Sichert beim speichern den letzten Anwender 
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Save()
            Me.ChangedBy = MainApplication.CurrentUser
            Me.ChangedAt = Now

            MyBase.Save()
        End Sub

        Public Sub New(ByVal session As DevExpress.Xpo.Session)
            MyBase.New(session)
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub
    End Class
End Namespace