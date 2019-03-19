Option Explicit On
Option Strict On
Imports ClausSoftware.Data


Namespace Kernel
    ''' <summary>
    ''' Enth�lt ein Einheitskennzeichnen wie Meter (m), St�ck (stk) usw, sowie die Masseinheit und Anzeigeeinstellung.
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.DefaultBindingProperty("Name")> _
    <DebuggerDisplay("Einheit Name: {Name}")> _
    <Persistent("Einheit")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Unit
        Inherits StaticItem
        Implements IDataItem
        Implements IComparable
        Implements IComparable(Of Unit)

        Public Const TableName As String = "Einheit"


        Private m_Name As String = String.Empty
        Private m_DTNK�rzel As String = String.Empty
        Private m_shortname As String = String.Empty
        Private m_Decimals As Integer



        ''' <summary>
        ''' Ausgeschriebener Name der Einheit.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("UnitName", "Name")> _
        <Persistent("Name")> _
        Public Property Name() As String
            Get
                If m_Name Is Nothing Then m_Name = String.Empty
                Return m_Name
            End Get
            Set(ByVal value As String)

                If Not String.IsNullOrEmpty(value) Then
                    If value.Length > 50 Then value = value.Substring(0, 49)
                End If


                SetPropertyValue(Of String)("Name", m_Name, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den kurznamen f�r Datanorm ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("UnitDataNormShortName", "Datanom-K�rzel")> _
        <Persistent("DTNKuerzel")> _
        Public Property DatanormShortName() As String
            Get
                Return m_DTNK�rzel
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DatanormShortName", m_DTNK�rzel, value)
            End Set
        End Property

        ''' <summary>
        ''' Das Kurzzeichen der einheit: m f�r Meter, Min f�r Minute, h f�r Stunde
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("UnitShortName", "Kurzzeichen")> _
        <Size(10)> _
        <Persistent("ShortName")> _
        Public Property ShortName() As String

            Get
                If m_shortname Is Nothing Then
                    m_shortname = String.Empty
                End If

                Return m_shortname
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Shortname", m_shortname, value)
            End Set
        End Property

        ''' <summary>
        ''' Anzahl der anzuzeigenden Nachkommastellen
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("UnitDecimals", "Kommastellen")> _
        <Persistent("Decimals")> _
        Public Property Decimals() As Integer
            Get
                Return m_Decimals
            End Get
            Set(ByVal value As Integer)
                If value < 0 Then
                    value = -1 ' Zeigt an, das keine Begrenzung der Einheit stattfindet
                End If
                SetPropertyValue(Of Integer)("Decimals", m_Decimals, value)

            End Set
        End Property

        ''' <summary>
        ''' Zeigt einen Zahlenwert in dieser Einheit an
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ShowValue(ByVal Value As Decimal) As String
            'TODO: Nachkommas ber�cksichtiugen
            Return FormatNumber(Value, 0, TriState.True, TriState.False, TriState.False)

        End Function

        ''' <summary>
        ''' Ruft die Eingabemaske ab (Formatierungszeichne), Einheiten sind immer nummerisch
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <ClausSoftware.Tools.DisplayName("UnitMask", "Eingabemaske")> _
        Public ReadOnly Property InputMask() As String
            Get
                Return "D" & Decimals
            End Get
        End Property

        ''' <summary>
        ''' einheiten k�nnen zb in Materiallisten oder anderen Tabellen wiederverwendet werden k�nnen, 
        ''' L�schen dann nicht erlauben
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Delete()
            'TODO: Bei einheiten euf Referenzen achten

        End Sub

        Public Overrides Function ToString() As String
            If Me.Name Is Nothing Then Me.Name = ""
            Return Me.Name
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        Public Function CompareTo(other As Unit) As Integer Implements System.IComparable(Of Unit).CompareTo
            Return String.Compare(Me.Name, other.Name)
        End Function
    End Class
End Namespace