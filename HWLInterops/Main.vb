﻿Imports ClausSoftware.Tools

''' <summary>
''' Stellt eine Starthilfeklasse dar
''' </summary>
''' <remarks></remarks>
Public Class Main
    Sub New()

    End Sub

    ''' <summary>
    ''' Testet die Datenbankverbindung und bricht gegebenenfalls die Verbindung ab. 
    ''' Der Anwender kann bei einem Fehler per Dialog eine andere Verbindung angeben
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TestConnection() As ClausSoftware.DataBase.DBResult

        Dim mydefaultConnection As ClausSoftware.Tools.Connection = MainApplication.getInstance.Connections.WorkConnection
        Dim result As New ClausSoftware.DataBase.DBResult()
        Dim myTestDB As ClausSoftware.DataBase.DbEngine

        If mydefaultConnection IsNot Nothing Then
            myTestDB = New ClausSoftware.DataBase.DbEngine(mydefaultConnection)

            result = myTestDB.TestConnection()

        Else
            ' Verbindung konnte gar nicht gefunden werden
            'TODO: NLS
            result.ErrorText = "Es wurde keine Verbindung gefunden"
            result.IsValid = False
            result.Solution = "Erstellen Sie eine neue Verbindung zu einer Datenbank"
        End If

        If Not result.IsValid Then

            Dim frmConnectionError As New frmConnectionValid()
            frmConnectionError.DBResult = result
            frmConnectionError.ShowDialog()

        End If

        Return result


    End Function

    Public Sub EndApplcation()
        modmain.CloseConnection()
    End Sub

    <ComVisible(False)>
    ReadOnly Property MainApplication() As ClausSoftware.MainApplication
        Get
            Return MainApplication.getInstance
        End Get
    End Property

End Class



