Imports System.ComponentModel

Namespace Tools
    ''' <summary>
    ''' Stellt eine Datenbankverbindung mit ihren Eigenschaften da.
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerDisplay("{GetConnectionShortDescription}")> _
    <DebuggerStepThroughAttribute()> _
    <Serializable()> _
    Public Class Connection
        Implements IComparable(Of Connection)
        Implements ICloneable

        Private m_isNew As Boolean = True

        ''' <summary>
        ''' Enthält den Namen der Verbindung
        ''' </summary>
        ''' <remarks></remarks>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_alias As String = ""
        ''' <summary>
        ''' Enthält den Instanznamen der Datenbank bei Serververbindungen
        ''' </summary>
        ''' <remarks></remarks>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_database As String = ""
        ''' <summary>
        ''' Enthält das Passwort dieser Verbindung
        ''' </summary>
        ''' <remarks></remarks>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_Password As String = ""
        ''' <summary>
        ''' Enthält den Pfad der Datenbankdatei
        ''' </summary>
        ''' <remarks></remarks>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_Path As String = ""
        ''' <summary>
        ''' Enthält den Hostnamen (Computernamen) des Servers
        ''' </summary>
        ''' <remarks></remarks>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_ServerHostName As String = ""
        ''' <summary>
        ''' Enthält den Benutzernamenb der Server-Verbindung. leer bei Access-Datenbanken
        ''' </summary>
        ''' <remarks></remarks>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_Username As String = ""
        ''' <summary>
        ''' Enthält den Servertype dieser Verbindung. 
        ''' </summary>
        ''' <remarks></remarks>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_Servertype As enumServerType = enumServerType.Access

        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Private m_isDefault As Boolean


        Private m_backupPath As String = ""

        Private m_token As String = ""

        ''' <summary>
        ''' Ruft ein Datenbanktoken ab oder legt eines fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Token() As String
            Get
                Return m_token
            End Get
            Set(ByVal value As String)
                m_token = value
            End Set
        End Property

        ''' <summary>
        ''' Stellt einen Pfad zur Verfügung, wo jeweils eine Kopie der Datenbank gelagert wird
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property BackupPath() As String
            Get

                If String.IsNullOrEmpty(m_backupPath) Then
                    If Me.Path.Length > 0 Then
                        m_backupPath = System.IO.Path.GetDirectoryName(Me.Path) & "\Backup"
                    End If

                End If

                Return m_backupPath
            End Get
            Set(ByVal value As String)
                m_backupPath = value
            End Set
        End Property


        ''' <summary>
        ''' Legt fest ob diese Verbindung die Standardverbindung ist oder ruft dies ab.
        ''' Standardverbidnungen haben ein "*" im Alias-Namen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsDefault() As Boolean
            Get
                Return m_isDefault
            End Get
            Set(ByVal value As Boolean)
                m_isDefault = value
            End Set
        End Property


        Sub New()

        End Sub
        ''' <summary>
        ''' erstellte eine neue Verbindung mit dem angegebenen Alias-Name
        ''' </summary>
        ''' <param name="aliasName"></param>
        ''' <remarks></remarks>
        Sub New(ByVal aliasName As String)
            Me.AliasName = aliasName
        End Sub

        ''' <summary>
        ''' Ruft den Namen der Verbindung ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AliasName() As String
            Get
                Return m_alias
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    value = String.Empty
                End If
                m_alias = value
            End Set

        End Property

        ''' <summary>
        ''' Ruft den Type des Datenbankservers ab oder setzt diesen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Servertype() As enumServerType
            Get
                Return m_Servertype
            End Get
            Set(ByVal value As enumServerType)
                m_Servertype = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Benutzernamen für den Server ab oder setzt diesen.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Username() As String
            Get
                Return m_Username
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    value = String.Empty
                End If
                m_Username = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Host-Name des Servers ab oder setzt diesen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ServerHostName() As String
            Get
                Return m_ServerHostName
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    value = String.Empty
                End If
                m_ServerHostName = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Pfad zur Datenbankdatei ab oder setzt diesen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Path() As String
            Get
                Return m_Path
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    value = String.Empty
                End If
                m_Path = value

            End Set
        End Property

        ''' <summary>
        ''' Ruft das Passwort für den Datenbankzugriff ab oder setzt dieses
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Password() As String
            Get

                Return m_Password
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    value = String.Empty
                End If
                m_Password = value
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Namen der Datenbank ab oder setzt diesen
        ''' </summary>
        ''' <remarks></remarks>        
        Public Property Database() As String
            Get
                Return m_database
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    value = String.Empty
                End If
                m_database = value
            End Set
        End Property

        ''' <summary>
        '''  Wird benutzt, um neu erstellte Verbindungen zu kennzeichnen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property IsNew As Boolean
            Get
                Return m_isNew
            End Get
            Set(ByVal value As Boolean)
                m_isNew = value
            End Set
        End Property

        ''' <summary>
        ''' Liefert einen kurze Beschreibung der Verbindung.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetConnectionShortDescription() As String

            Dim text As String = Me.Servertype.ToString

            If Me.Servertype = enumServerType.Access Then
                text += ": Path=" & Me.Path
            End If

            If Me.Servertype = enumServerType.MySQL Then
                text += ": " & Me.ServerHostName & "." & Me.Database
            End If

            Return text
        End Function

        ''' <summary>
        ''' Ruft detailierte Daten zur Verbindung ab. 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetConnectionDescription() As String
            Dim text As String
            text = "Name=" & Me.AliasName & "; Type=" & Me.Servertype.ToString & ""
            If Me.Servertype = enumServerType.Access Then
                text += ";Path=" & Me.Path
            End If

            If Me.Servertype = enumServerType.MySQL Then
                text += "; Servername=" & Me.ServerHostName & "\" & Me.Database & "; Username=" & Me.Username
            End If

            Return text
        End Function

        ''' <summary>
        ''' Gibt den Namen der Verbindung wieder zurück.
        ''' Ist die Verbindung die Standardverbindung, dann wird dem Alias-Namen ein * vorangestellt
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overrides Function ToString() As String

            If Me.IsDefault Then
                Return "*" & Me.AliasName
            Else
                Return Me.AliasName
            End If

        End Function

        ''' <summary>
        ''' Prüft, ob zwei Connections gleich sind
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If Not TypeOf obj Is Connection Then
                Return MyBase.Equals(obj)
            Else
                Dim otherconnection As Connection = CType(obj, Connection)
                Dim areEqual As Boolean = True
                With Me
                    areEqual = .Database.Equals(otherconnection.Database, StringComparison.InvariantCultureIgnoreCase)
                    areEqual = areEqual And .Password.Equals(otherconnection.Password, StringComparison.InvariantCultureIgnoreCase)
                    areEqual = areEqual And (.Username = otherconnection.Username)
                    areEqual = areEqual And .Path.Equals(otherconnection.Path, StringComparison.InvariantCultureIgnoreCase)
                    areEqual = areEqual And .ServerHostName.Equals(otherconnection.ServerHostName, StringComparison.InvariantCultureIgnoreCase)
                    areEqual = areEqual And (.Servertype = otherconnection.Servertype)
                    areEqual = areEqual And (.AliasName = otherconnection.AliasName)

                End With
                Return areEqual
            End If
        End Function

        ''' <summary>
        ''' Prüft zwei Verbindungen auf Gleichheit
        ''' </summary>
        ''' <param name="c"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Overloads Function Equals(ByVal c As Connection) As Boolean
            Return Me.CompareTo(c) = 0
        End Function

        ''' <summary>
        ''' Vergleicht die angegebene Verbindung mit dieser Instanz
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Function CompareTo(ByVal other As Connection) As Integer Implements System.IComparable(Of Connection).CompareTo
            Dim value As Integer
            If other Is Nothing Then Return -1

            With other

                If Me.Servertype <> .Servertype Then
                    Return -1
                End If

                value = String.Compare(Me.Database, .Database, True)
                value += String.Compare(Me.Password, .Password, True)
                value += String.Compare(Me.Path, .Path, True)
                value += String.Compare(Me.ServerHostName, Me.ServerHostName, True)
                value += String.Compare(Me.Username, .Username, True)

                Return value

            End With
        End Function

        ''' <summary>
        ''' Erstellt eine Kopie der Verbindung und gibt diese zurück
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ComponentModel.EditorBrowsable(EditorBrowsableState.Advanced)> _
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim newConnection As New Connection()
            newConnection.AliasName = Me.AliasName
            newConnection.Database = Me.Database
            newConnection.Password = Me.Password
            newConnection.Path = Me.Path
            newConnection.ServerHostName = Me.ServerHostName
            newConnection.Servertype = Me.Servertype
            newConnection.Username = Me.Username
            Return newConnection

        End Function


      
    End Class


End Namespace