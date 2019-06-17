Namespace DataBase
    ''' <summary>
    ''' Stellt einen Rückgabewert zur Verfügung der Informationen füber die Verfügbarkeit der Dtaenbank enthält.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DBResult

        Private m_isValid As Boolean

        Private m_ErrorText As String

        Private m_solution As String

        Public Sub New()
            MyBase.New()

        End Sub

        ''' <summary>
        ''' Enthält den Text einer möglichen Lösung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Solution() As String
            Get
                Return m_solution
            End Get
            Set(ByVal value As String)
                m_solution = value
            End Set
        End Property

        ''' <summary>
        ''' Enthält den gesammelten Text der Fehlermeldung
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ErrorText() As String
            Get
                Return m_ErrorText
            End Get
            Set(ByVal value As String)
                m_ErrorText = value
            End Set
        End Property

        ''' <summary>
        ''' Zeigt durch ein Wahr/Falsch Flag an, ob der Server eine Datenbankaufforderung akzeptiert
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsValid() As Boolean
            Get
                Return m_isValid
            End Get
            Set(ByVal value As Boolean)
                m_isValid = value
            End Set
        End Property


    End Class


End Namespace