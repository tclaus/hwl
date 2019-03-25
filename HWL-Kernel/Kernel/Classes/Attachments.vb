Option Explicit On
Option Strict On


Imports ClausSoftware.Tools
Imports ClausSoftware.Data
Imports System.Runtime.InteropServices
Imports DevExpress.Data.Filtering

Namespace Kernel

    ''' <summary>
    ''' Stellt eine LIste von Adressen da.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Attachments
        Inherits BaseCollection(Of Attachment)
        Implements IDataCollection

        ''' <summary>
        ''' Holt eine Adresse anhand der Adsressennummer
        ''' </summary>
        ''' <param name="sourceID">Die ReplikId des Datensatzes der die angehängten Daten enthält</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAttachmentsBySourceID(ByVal sourceID As String) As Attachments
            'TODO: Performance


            Return Nothing
        End Function

        Public Sub New(ByVal baseApplication As MainApplication)
            MyBase.New(baseApplication)

            Initialize()
        End Sub


        Public Sub New(ByVal baseApplication As MainApplication, ByVal criteria As criteriaoperator)
            MyBase.New(baseApplication, criteria)

            Initialize()
        End Sub





        Public Sub Initialize() Implements IDataCollection.Initialize
            Dim DisplayProps As New Text.StringBuilder
            DisplayProps.Append("Icon;")
            DisplayProps.Append("FileName;")
            DisplayProps.Append("CreateDate;")
            DisplayProps.Append("PreviewFile;")

            Me.DisplayableProperties = DisplayProps.ToString

        End Sub
    End Class
End Namespace

