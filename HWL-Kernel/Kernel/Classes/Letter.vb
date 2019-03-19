Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports ClausSoftware.Data

Namespace Kernel

    ''' <summary>
    ''' Stellt eien Klasse dar, mit der Briefe geschrieben werden können
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("Briefe")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Letter
        Inherits StaticItem
        Implements IDataItem

        Public Const TableName As String = "Briefe"

        Private m_addressID As Long
        Private m_rtfText As String = String.Empty ' Kann demnächst auch RTF sein
        Private m_subject As String
        Private m_angelegtAm As DateTime = Now
        Private m_letzteÄnderungAm As DateTime = Now
        Private m_addressWindow As String
        Private m_BenutzerDefiniertesAdressfenster As Boolean
        Private m_rtfHelper As New System.Windows.Forms.RichTextBox
        Private m_tagValue As String

        ''' <summary>
        ''' Enthält eine Nummer des Briefes
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DisplayName("Nummer")> _
        Public Shadows ReadOnly Property DocumentID() As Integer
            Get
                Return MyBase.ID
            End Get
        End Property

        Public Overrides Sub Save()
            Me.LastChangedAt = Now
            Dim o As Object = Me.AddressField  ' Wenn das Adressfeld noch ermittelt wwerden muss

            MyBase.Save()


            m_mainApplication.SendMessage(m_mainApplication.Languages.GetText("msgCommonelementSaved", "Gespeichert: '{0}'", Me.ToString))

        End Sub


        ''' <summary>
        ''' Ruft die ID der Adresse ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        <ComponentModel.Browsable(False)> _
        <Persistent("Kundennr")> _
        Public Property AddressID() As Long
            Get
                Return m_addressID
            End Get
            Set(ByVal value As Long)
                SetPropertyValue(Of Long)("AddressID", m_addressID, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den reinen Ascii-Text des Briefes ab
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        <DisplayName("Text")> _
        Public ReadOnly Property Text() As String
            Get
                If RTFCodedText.StartsWith("{\rtf") Then

                    m_rtfHelper.Rtf = RTFCodedText
                Else
                    m_rtfHelper.Text = RTFCodedText
                    RTFCodedText = m_rtfHelper.Rtf
                    Me.Save() ' da ich nun Daten geändert hae, auch sichern
                End If

                Return m_rtfHelper.Text
            End Get

        End Property

        ''' <summary>
        ''' Ruft ein Schlagwort ab oder legt dieses fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("Tag", "Schlagwort")> _
        <Persistent("Tag")> _
        Public Property Tag() As String
            Get
                If m_tagValue Is Nothing Then
                    m_tagValue = ""
                End If
                Return m_tagValue
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    m_tagValue = ""
                Else
                    m_tagValue = value
                End If


            End Set
        End Property

        ''' <summary>
        ''' Ruft den kodiereten RTF-text ab oder legt diesen fest.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        <Size(DevExpress.Xpo.SizeAttribute.Unlimited)> _
        <Persistent("Brieftext")> _
        Public Property RTFCodedText() As String
            Get
                If m_rtfText IsNot Nothing Then
                    Return m_rtfText
                Else
                    Return ""
                End If

            End Get
            Set(ByVal value As String)

                If value Is Nothing Then
                    m_rtfText = ""
                Else
                    m_rtfText = value
                End If

            End Set
        End Property

        ''' <summary>
        ''' Enthält den Namen des Briefes (früher Betreffzeile)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
        <Tools.DisplayName("subject", "Betreff")> _
        <Persistent("Dateiname")> _
        Public Property Subject() As String
            Get
                Return m_subject
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    value = ""

                End If

                m_subject = value

            End Set
        End Property

        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
        <Tools.DisplayName("CreatedAt", "Angelegt am")> _
        <Persistent("AngelegtAm")> _
        Public Property CreatedAt() As DateTime
            Get
                Return m_angelegtAm
            End Get
            Set(ByVal value As DateTime)
                m_angelegtAm = value
            End Set
        End Property

        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Advanced)> _
        <Tools.DisplayName("LastChangedAt", "Zuletzt geändert am")> _
        <Persistent("GeändertAm")> _
        Public Property LastChangedAt() As DateTime
            Get
                Return m_letzteÄnderungAm
            End Get
            Set(ByVal value As DateTime)
                m_letzteÄnderungAm = value
            End Set
        End Property


        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Always)> _
        <Tools.DisplayName("AddressField", "Adressfenster")> _
        <Persistent("Adressfenster")> _
        Public Property AddressField() As String
            Get
                If Not Me.UserDefinedAdresswindow Then

                    If Me.Address IsNot Nothing Then
                        m_addressWindow = Me.Address.InvoiceAdressWindow
                    End If

                End If
                Return m_addressWindow
            End Get
            Set(ByVal value As String)

                SetPropertyValue("AddressField", m_addressWindow, value)
            End Set
        End Property

        ''' <summary>
        ''' Zeigt an, ob das Adressfenster nachträglich vom Benutzer geändert wurde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        <ComponentModel.Browsable(False)> _
        <Persistent("UserChangedAdressFenster")> _
        Public Property UserDefinedAdresswindow() As Boolean
            Get

                Return m_BenutzerDefiniertesAdressfenster
            End Get
            Set(ByVal value As Boolean)
                m_BenutzerDefiniertesAdressfenster = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den aktuellen Kontakt ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Tools.DefaultGridVisible(ComponentModel.EditorBrowsableState.Never)> _
        Public Property Address() As Kernel.Adress
            Get
                If Me.AddressID > 0 Then
                    If Not IsLoading Then
                        Return MainApplication.Adressen.GetItemByNumber(CInt(Me.AddressID))
                    End If
                End If
                Return Nothing
            End Get
            Set(ByVal value As Kernel.Adress)
                Me.AddressID = value.Kundennummer
            End Set
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        ''' <summary>
        ''' Ruft einen Anzeigetext für dieses Dokument ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Dim displayText As String = Me.Subject

            If Me.Text.Length > 80 Then
                displayText &= vbCrLf & Text.Substring(0, 80) & "..."
            Else
                displayText &= vbCrLf & Text
            End If

            Return displayText

        End Function

    End Class
End Namespace
