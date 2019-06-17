Option Explicit On
Option Strict On

Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Data
Imports ClausSoftware.Data
Imports System.IO


Namespace Kernel.Printing


    ''' <summary>
    ''' Stellt ein Benutzerdefiniertes Druck-Layout zur Verfügung
    ''' </summary>
    ''' <remarks></remarks>
    <DebuggerDisplay("Id: {ID}, Reporttyp: {m_Datasourcekind}, Name: {m_name}")> _
    <Serializable()> _
    <Persistent("Reports")> _
    <MapInheritance(MapInheritanceType.OwnTable)> _
    Public Class Report
        Inherits StaticItem
        Implements IDataItem

        ''' <summary>
        ''' Markiert steuerelemente des Brief-Layouts, die im vereinfachten "Seite einrichten" erstellt wurden.
        ''' Eine Klasse funktioniert da nicht
        ''' </summary>
        ''' <remarks></remarks>
        Public Const BusinessMarker As String = "BusinessMarker"

        Private m_name As String

        Private m_description As String

        Private m_Datasourcekind As DataSourceList

        Private m_isDefault As Boolean

        Private m_ReportData As String = String.Empty

        ''' <summary>
        ''' Ruft das Report als Stream ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReportStream() As System.IO.Stream

            Dim m As New System.IO.MemoryStream(System.Text.UTF8Encoding.UTF8.GetBytes(Me.ReportData))
            Return m
        End Function

        ''' <summary>
        ''' Legt das Report Layout durch seinen Stream fest
        ''' </summary>
        ''' <param name="reportStream"></param>
        ''' <remarks></remarks>
        Public Sub SetReportStream(ByVal reportStream As System.IO.MemoryStream)
            Dim strValue As String

            strValue = System.Text.UTF8Encoding.UTF8.GetString(reportStream.GetBuffer())

            Me.ReportData = strValue

        End Sub

        ''' <summary>
        ''' Ruft das Report Layout ab oder legt es fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ReportData")> _
        <Size(SizeAttribute.Unlimited)> _
        Public Property ReportData() As String
            Get
                Return m_ReportData
            End Get
            Set(ByVal value As String)

                SetPropertyValue(Of String)("ReportData", m_ReportData, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen Wert ab, der anzeigt ob dieses LAyout das Standardlayout in dieser Gruppe ist
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("IsDefault")> _
        Public Property IsDefault() As Boolean
            Get
                Return m_isDefault
            End Get
            Set(ByVal value As Boolean)
                SetPropertyValue(Of Boolean)("IsDefault", m_isDefault, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft den Typ des Reports ab (die Datenquelle)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("DataSourceType")> _
        Public Property DataSourceKind() As DataSourceList
            Get
                Return m_Datasourcekind
            End Get
            Set(ByVal value As DataSourceList)
                SetPropertyValue(Of DataSourceList)("DataSourceKind", m_Datasourcekind, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft einen beschreibenden Text für diesen Report ab oder legt diesen fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("Description")> _
        <Size(250)> _
        Public Property Description() As String
            Get
                Return m_description
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Description", m_description, value)
            End Set
        End Property

        ''' <summary>
        ''' Ruft eine eindeutige Report-Bezeichnung ab oder legt diese fest
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Persistent("ReportName")> _
        Public Property ReportName() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ReportName", m_name, value)
            End Set
        End Property

        ''' <summary>
        ''' Erstellt ein neuen Repotr auf Basiss dieses bestehenden. Es wird ein neuer Schlüssel gebildet
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function Clone() As Object
            Dim newReport As Report = CType(MyBase.Clone, Report)


            newReport.ReplikID = ""  ' Zurückseten, sonst überschreiben wir das element
            newReport.IsDefault = False  ' Klone können kein default sein. 

            Return newReport
        End Function

        ''' <summary>
        ''' Ruft den Ansichtsnamen des Reports ab
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return Me.ReportName & " (" & m_mainApplication.Languages.GetTextBydataKind(Me.DataSourceKind) & ")"

        End Function


        ''' <summary>
        ''' Speichert diesen Report als XML-File in einer Datei
        ''' </summary>
        ''' <param name="filename"></param>
        ''' <remarks></remarks>
        Public Sub SaveToDisk(ByVal filename As String)
            Dim serFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Using tw As New System.IO.FileStream(filename, System.IO.FileMode.Create)

                Dim proxy As New ReportProxy
                proxy.DataType = Me.DataSourceKind
                proxy.Description = Me.Description
                proxy.Name = Me.ReportName
                proxy.ReplikID = Me.ReplikID
                proxy.ReportData = Me.ReportData

                Dim m As New System.IO.MemoryStream
                Dim z As New System.IO.Compression.GZipStream(tw, System.IO.Compression.CompressionMode.Compress)

                serFormatter.Serialize(z, proxy)


                '    Pump(m, z)

                z.Close()
                tw.Close()
            End Using
        End Sub

        ''' <summary>
        ''' Erstellt ein neues Report-Objekt von einer Datei
        ''' </summary>
        ''' <param name="filename"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' Wirft eine <exception cref="System.IO.FileNotFoundException">FileNotFoundexception</exception> wenn die DAtei unter diesem Namen nicht gefudnen wreden konnte
        Public Shared Function LoadFromDisk(ByVal filename As String) As Report

            If System.IO.File.Exists(filename) Then

                Dim newreportProxy As ReportProxy
                Dim newReport As Report

                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

                Dim fs As New System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read) ' Datei öffnen 
                Dim unzip As New System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Decompress) ' Dekompressor öffnen

                newreportProxy = CType(bf.Deserialize(unzip), ReportProxy)

                newReport = GetReportFromProxy(newreportProxy)

                Return newReport
            Else ' Ansonsten ..
                m_mainApplication.log.WriteLog(Tools.LogSeverity.Critical, "Filenotfound: Reportdatei konnte nicht gefunden werden. ")

                Throw New System.IO.FileNotFoundException(m_mainApplication.Languages.GetText("msgReportFileNotFoundError", "Die Report-Datei '{0}' konnte nicht gefunden werden.", filename))
                Return Nothing
            End If

        End Function
        ''' <summary>
        ''' Pumpt die Daten von einem Strom in den anderen
        ''' </summary>
        ''' <param name="input"></param>
        ''' <param name="output"></param>
        ''' <remarks></remarks>
        Private Shared Sub Pump(ByVal input As Stream, ByVal output As Stream)

            Dim bytes(4096) As Byte
            Dim n As Integer = input.Read(bytes, 0, bytes.Length)

            While (n) <> 0
                output.Write(bytes, 0, n)
                n = input.Read(bytes, 0, bytes.Length)

            End While
        End Sub

        ''' <summary>
        ''' erstellt einen Neuen Report aus einem übergebenen Datenstrom
        ''' </summary>
        ''' <param name="reportBuffer">Ein Byte-Array das ein serialisiertes Report-Objekt enthält, unkomprimiert</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function LoadFromStream(ByVal reportBuffer As Byte()) As Report

            Try
                Dim newreport As Report
                Dim newreportProxy As ReportProxy
                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

                Dim m As New System.IO.MemoryStream(reportBuffer)  ' in einen MemoryStream dekomprimierem
                Dim unzip As New System.IO.Compression.GZipStream(m, System.IO.Compression.CompressionMode.Decompress)

                newreportProxy = CType(bf.Deserialize(unzip), ReportProxy)



                newreport = GetReportFromProxy(newreportProxy)

                newreport.ID = -1

                Return newreport
            Catch ex As Exception
                m_mainApplication.log.WriteLog(ex, "Reports", "Error while reading Datastream")
                Throw
            End Try

        End Function

        ''' <summary>
        ''' ermittelt aus einem gegebenen Proxy das eport-Object
        ''' </summary>
        ''' <param name="proxyReport"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function GetReportFromProxy(ByVal proxyReport As ReportProxy) As Report
            Dim newReport As Report
            newReport = New Report(m_mainApplication.Session)
            newReport.DataSourceKind = proxyReport.DataType
            newReport.Description = proxyReport.Description
            newReport.ReportName = proxyReport.Name
            newReport.ReportData = proxyReport.ReportData
            newReport.ReplikID = proxyReport.ReplikID
            newReport.ID = -1
            Return newReport
        End Function


        Private Sub New()

        End Sub

        Public Sub New(ByVal session As Session)
            MyBase.New(session)

        End Sub

        ''' <summary>
        ''' Entfernt von diesem Report alle Steuerelemente, die ein Briefpapier-Layout darstellen
        ''' </summary>
        ''' <remarks></remarks>
        Sub RemoveBusinessLayout()
            Dim xreport As New DevExpress.XtraReports.UI.XtraReport

            xreport.LoadLayout(Me.GetReportStream)

            Dim bandID As Integer
            bandID = 0

            Do While bandID < xreport.Bands.Count
                Dim ctrlID As Integer
                ctrlID = 0
                Do While ctrlID < xreport.Bands(bandID).Controls.Count

                    Dim ctrl As DevExpress.XtraReports.UI.XRControl = xreport.Bands(bandID).Controls(ctrlID)

                    If TypeOf ctrl.Tag Is String AndAlso CStr(ctrl.Tag) = Report.BusinessMarker Then
                        xreport.Bands(bandID).Controls.Remove(ctrl)
                    Else
                        ctrlID += 1
                    End If
                Loop

                bandID += 1
            Loop

            Using M As New System.IO.MemoryStream
                Try
                    xreport.SaveLayout(M)
                    Me.SetReportStream(M)
                Catch
                    'Maybe some dlls are missing. ? 
                End Try

            End Using

        End Sub

    End Class



End Namespace