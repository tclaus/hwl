Imports ClausSoftware.Kernel

Namespace Data

    ''' <summary>
    ''' Aktualisiert das Datenbankschema
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SchemaUpdater

        Dim m_lastError As String = String.Empty


        ''' <summary>
        ''' Aktualisiert die Datenbank und räumt liegengelassene Daten auf. Versionsunabhängig, kann immer durchgeführt werden
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ReorgDatabase(lastKnownVersion As String)
            Dim sql As String = String.Empty

            ' Vor den Umfangreichen DB-Anpassungen die ReplikID anpasssen

            If lastKnownVersion < "2.00.0000" Then
                ' wichtig für Updates aus alten Daten
                SetTextColLength(JournalDocument.Tablename, "ReplikID", 32)
                SetTextColLength(JournalArticleItem.TableName, "ReplikID", 32)
                SetTextColLength(JournalArticleGroup.TableName, "ReplikID", 32)

                SetTextColLength(Adress.Tablename, "ReplikID", 32)

                SetTextColLength(Article.TableName, "ReplikID", 32)
                SetTextColLength(Attachment.Tablename, "ReplikID", 32)
                SetTextColLength(CashJournalItem.TableName, "ReplikID", 32)
                SetTextColLength(Reminder.TableName, "ReplikID", 32)
                SetTextColLength(Transaction.TableName, "ReplikID", 32)
                SetTextColLength(CashJournalItem.TableName, "ReplikID", 32)
                SetTextColLength(Letter.TableName, "ReplikID", 32)
                SetTextColLength(Unit.TableName, "ReplikID", 32)

                SetTextColLength(FixedCost.TableName, "ReplikID", 32)
                SetTextColLength(CashAccount.TableName, "ReplikID", 32)

            End If


            Try
                MainApplication.getInstance.SendMessage("Bereinige Datenbank...") 'TODO: NLS
                ' Leere Bilder entsorgen
                sql = "delete FROM " & ImageData.TableName & " where data is null"
                MainApplication.getInstance.Database.ExcecuteNonQuery(sql)

                sql = " UPDATE " & Article.TableName & " SET intartnummer=ID WHERE intartnummer is null or intartnummer=''"
                MainApplication.getInstance.Database.ExcecuteNonQuery(sql)

                Debug.Print("Vater-ID von JournalArtikel ermitteln")
                sql = "Update Items I,Positions P SET I.ParentItemID= P.ReplikID where P.Nummer = I.LfndNUmmer AND I.Status=P.Status And I.Seite=P.Seite AND (I.ParentItemID is null or I.ParentItemID='')"
                MainApplication.getInstance.Database.ExcecuteNonQuery(sql)

                Debug.Print("Vater-ID von JournalGruppen setzen")
                sql = "Update JournalListe J, Positions P SET P.ParentItemID = J.ReplikID WHERE P.Nummer=J.lfndNUmmer AND P.Status=J.Status AND J.ForPrinting=0 AND  (P.ParentItemID ='' or P.ParentItemID is NULL)"
                MainApplication.getInstance.Database.ExcecuteNonQuery(sql)

                ' Aus den Properties die alten Udpate-Hinweise entfernen, da nun etwas anders gemanaged
                Debug.Print("Aus den Properties mit Skope Update entfernen, da nun lokal gemanaged")
                sql = "DELETE FROM PROPERTIES where Skope='Update' and (Name='LastUpdate' or Name='Interval')  "
                MainApplication.getInstance.Database.ExcecuteNonQuery(sql)

                ' Artikel mit falsch gesetzter >Interner Artikelnummer ensorgen


                ' Artikelbilder entfernen, die keinen Artikel mehr haben
                ' (Artikelbilder sind eine 1:1 Verbindung; Anhänge werden per Attachment_Links verknüpft
                ' 1. Alle Dateileichen einsammeln; 
                ' 2. Aus den Material_Bildern löschen
                sql = "Delete from material_bilder where verweisID not in (SELECT  ReplikID from materialliste)"
                If MainApplication.getInstance.Database.ExcecuteNonQuery(sql) > 0 Then
                    If MainApplication.getInstance.Connections.WorkConnection.Servertype = Tools.enumServerType.MySQL Then
                        sql = "OPTIMIZE TABLE material_bilder "
                        Dim result As Integer
                        result = MainApplication.getInstance.Database.ExcecuteNonQuery(sql)
                        MainApplication.getInstance.SendMessage(result & " alte Artikelbilder ohne Artikel entfernt") 'TODO: NLS
                    End If
                End If

                'Dateileichen: Attachmentverknüpfungen ohne Attacjtachment
                sql = "select ar.ID from attachmentsrelations ar LEFT JOIN attachments a ON ar.targetID = a.replikID" &
                " where a.replikID Is null "
                Dim dt As DataTable = MainApplication.getInstance.Database.GetData(sql)
                If dt.Rows.Count > 0 Then
                    Dim sqlDeleteRelation As String = "DELETE FROM " & AttachmentsRelation.Tablename & " WHERE ID in("
                    For Each item As DataRow In dt.Rows
                        sqlDeleteRelation &= CInt(item(0)) & ","

                    Next
                    sqlDeleteRelation &= "-1)"
                    Dim result As Integer
                    result = MainApplication.getInstance.Database.ExcecuteNonQuery(sqlDeleteRelation)

                    MainApplication.getInstance.SendMessage(result & " alte Anhangsverknüpfungen gelöscht")

                End If



                ' Alte Locks entsorgen
                Debug.Print("Entsorge alte Daten-Locks für den aktuell angemeldeten Benutzer")
                'TODO: Alle Locks freigeben, oder dem Anwender eine Liste zeigen ? 

            Catch ex As Exception
                Debug.Print("ReorgDatabase: SQL=" & sql & ex.Message)

            Finally
                MainApplication.getInstance.SendMessage("")
            End Try

        End Sub

        Private Sub LastChanceRepairTables(s As Session)
            Dim c As IDbCommand = s.DataLayer.CreateCommand
            Try
                ' AttachmentRelations: ein Index kam später hinzu, könnte sein, das dieser nicht angelegt werden kann
                Dim sql As String = "SELECT count(*),sourceid,targetid FROM attachmentsrelations" &
                                                    " group by sourceid,targetid" &
                                                    " Having count(*)>1"
                c.CommandText = sql
                Dim dt As New DataTable
                Do
                    dt.Clear()
                    dt.Load(c.ExecuteReader)
                    If dt.Rows.Count = 0 Then Exit Do ' Kein weiterer Durchlauf


                    For Each item As DataRow In dt.Rows
                        Dim deleC As IDbCommand = s.DataLayer.CreateCommand
                        Dim deleSQL As String = "DELETE FROM attachmentsrelations WHERE sourceid ='" & item("sourceid").ToString & "' AND targetID='" & item("targetID").ToString & "'"
                        deleC.CommandText = deleSQL
                        Dim result As Integer
                        result = deleC.ExecuteNonQuery()
                        Debug.Print(result & " Duplikate aus der AttachmentsRelations-Liste entfernt")
                    Next

                Loop While dt.Rows.Count > 0

            Catch ex As Exception
                MainApplication.getInstance.log.WriteLog(ex, "Fehler beim reparieren von Anhangs-Verknüpfungen", "LastChanceRepairTables")
            End Try

        End Sub

        ''' <summary>
        ''' Startet ein Datenbankupdate
        ''' </summary>
        ''' <remarks></remarks>
        Sub StartUpdate()

            MainApplication.getInstance.StartMarqueeBar()
            MainApplication.getInstance.SendMessage(MainApplication.getInstance.Languages.GetText("UpdatingDatabase", "Aktualisiere Datenbank..."))
            Dim dbVersion As String = "1.7.1740"  'Initialer Startwert
            Try
                Dim resultCount As Integer

                Dim sql As String
                Dim lastKnownVersion As String

                ' DB-Verbindung erstellen, um Datenbank-Update zu machen
                Dim conn As String = Tools.Connections.GetConnectionString(MainApplication.getInstance.Connections.WorkConnection)
                Using dl As IDataLayer = XpoDefault.GetDataLayer(conn, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)


                    'Dim p As New DevExpress.Xpo.XpoDefault

                    'Schema aktualisieren
                    Using tmpSession As Session = New Session(dl)



                        If MainApplication.getInstance.Session IsNot Nothing Then
                            If MainApplication.getInstance.Session.Connection IsNot Nothing Then
                                MainApplication.getInstance.Session.Connection.Close()
                            End If
                        End If

                        'IMPORTANT 1.5 Prüfung woanders machen ! - Zumindest mit einer anderen Connection!

                        Dim retValue As Object = MainApplication.getInstance.Database.ExcecuteScalar("SELECT VersionID FROM HWLVERSION")
                        If TypeOf retValue Is String Then

                            lastKnownVersion = CStr(retValue)

                            If CStr(retValue).StartsWith("1.5") Then

                                MainApplication.getInstance.log.WriteLog("Kann Datenbank nicht aktualisieren. Gelesene Datenbank ist: " & CStr(retValue))

                                Throw New Exception(MainApplication.getInstance.Languages.GetText("msgInitialHWL1.7 Database needed.", "Eine 1.7er Datenbank wird für das Update benötigt. " & vbCrLf &
                                                    "Installieren Sie erst eine 1.7 Version und starten diese, bevor Sie {appname}-2 starten." & vbCrLf & vbCrLf &
                                                    "Aktuelle Datenbank ist: '" & CStr(retValue) & "'"))

                            End If
                        Else
                            ' entweder kompltt leere Datenbank oder ein anderes Problem ist aufgereten
                            MainApplication.getInstance.log.WriteLog("Tabelle HWLVersion nicht gefunden und kein Eintrag orhanden!")
                        End If


                        Dim assemblies As System.Reflection.Assembly() = New System.Reflection.Assembly() _
                            {GetType(MainApplication).Assembly}
                        MainApplication.getInstance.SendMessage("Aktualisiere Datenbankschema...") 'TODo: NLS

                        ' Ein Backup anlegen, bevor das Schema auf "2.0" aktualisiert wird
                        If TypeOf retValue Is String Then ' Kann sein, das kein return wert angegeben wurde
                            If CStr(retValue).StartsWith("1") Then
                                MainApplication.getInstance.Database.StartBackup(CStr(retValue), MainApplication.getInstance.Connections.WorkConnection)
                            End If
                        End If

                        LastChanceRepairTables(tmpSession)

                        tmpSession.UpdateSchema(assemblies)
                        tmpSession.CreateObjectTypeRecords(assemblies)
                        tmpSession.Connection.Close()
                    End Using
                    dl.Connection.Close()
                End Using

                MainApplication.getInstance.Database.CloseConnection()

                System.Windows.Forms.Application.DoEvents()



                ReorgDatabase(lastKnownVersion)
                ' Hier nun die eigentliche session bauen 
                MainApplication.getInstance.SetSession(XpoHelper.GetNewSession)

                Dim dbCommand As IDbCommand = MainApplication.getInstance.Database.GetConnection.CreateCommand

                dbVersion = MainApplication.getInstance.DBVersion
                Debug.Print("Prüfe Datenbankschema auf Aktualität. Aktuelle Datenversion ist: " & dbVersion)

                ' Lesen vor dem Update
                MainApplication.getInstance.Database.GenerateDatabaseSchema()


                ' Daten aktualisieren. Bei Neuinstallierung fängt die Versionsnummer bei "2.0.0" an - keine Alten daten vorhanden
                If dbVersion >= "1.7.1740" Then
                    MainApplication.getInstance.SendMessage(MainApplication.getInstance.Languages.GetText("UpdatingFrom1.7.1740", "Aktualisiere Datenbank ab Version 1.7.1740..."))

                    '    If dbCommand Is Nothing Then System.Windows.Forms.MessageBox.Show("DBCommand is nothing")

                    If dbVersion < "1.7.1749" Then
                        ' Bilder-Verweise reparieren
                        sql = "update Material_Bilder M,Materialliste ML SET M.VerweisID=ML.ReplikID" &
        " where ML.BildID = M.ReplikID AND M.VerweisID =''"

                        dbCommand.CommandText = sql
                        dbCommand.ExecuteNonQuery()

                        ' Artikel Aktivieren
                        sql = "update Materialliste SET IsActive=True" &
                           " where IsActive is null or  IsActive =False"

                        dbCommand.CommandText = sql
                        dbCommand.ExecuteNonQuery()


                        ' Adressen aktivieren
                        sql = "update Adressen SET IsActive=True" &
   " where IsActive is null or  IsActive =False"

                        dbCommand.CommandText = sql
                        dbCommand.ExecuteNonQuery()

                        ' Für Splittbuchungen, zusätzlich ein "Total-Feld einfügen und bezahlte und unbezahlte Bteräge sortieren
                        sql = "update Vorgänge set BetragBezahlt = 0 where BetragBezahlt is null"
                        dbCommand.CommandText = sql
                        resultCount = dbCommand.ExecuteNonQuery()


                        ' TotalAmmount auffüllen
                        sql = "update Vorgänge set TotalAmmount = Betragnichtbezahlt+BetragBezahlt "
                        dbCommand.CommandText = sql
                        dbCommand.ExecuteNonQuery()

                        ' NICHT AUSFÜHREN, da STATEMENT NICHT UNTER ACCESS LÄUFT; "Schwund ist immer"
                        '' Falls splittbuchungen existieren, dann den Betrag Bezahlt auffüllen
                        'sql = "update Vorgänge v,Splittbuchungen s set v.betragbezahlt = ( select sum(s.betrag) as betrag" & _
                        '        " from Splittbuchungen s where s.Splitt=v.ID) where v.id =s.splitt"
                        'c.CommandText = sql
                        'c.ExecuteNonQuery()

                        ' Die Nicht bezahlten Beträge neu berechnen, wird nun stets vom Kernel aktuell gehalten
                        'sql = "update Vorgänge v set v.betragnichtbezahlt = TotalAmmount-BetragBezahlt"
                        'c.CommandText = sql
                        'c.ExecuteNonQuery()


                        ' Splitts löschen, die keine Buchung mehr haben
                        sql = "delete from Splittbuchungen where splitt  not in (select ID from Vorgänge)"
                        dbCommand.CommandText = sql
                        dbCommand.ExecuteNonQuery()

                        sql = "Update " & Kernel.Article.TableName & " SET GruppenID='" & Kernel.Groups.RootID & "' WHERE GruppenID is null or GruppenID='0000' or GruppenID=''"
                        dbCommand.CommandText = sql
                        dbCommand.ExecuteNonQuery()

                        ' Datenbank reorganisieren
                        ' Kassenbuch reparieren
                        sql = "Update Kassenbuch SET Einnahme=0 WHERE Einnahme is null"
                        dbCommand.CommandText = sql
                        dbCommand.ExecuteNonQuery()

                        sql = "Update Kassenbuch SET Ausgabe=0 WHERE Ausgabe is null"
                        dbCommand.CommandText = sql
                        dbCommand.ExecuteNonQuery()

                        dbVersion = "1.7.1749"
                        MainApplication.getInstance.DBVersion = dbVersion
                    End If
                End If
                If dbVersion < "2.00.0000" Then
                    MainApplication.getInstance.SendMessage(MainApplication.getInstance.Languages.GetText("UpdatingFrom2.0", "Aktualisiere Datenbank ab Version 2.0.0..."))


                    ' Adressbuch hat zusätzliche Spalten erhalten mit Datum und Änderungsdatum => Übertragen
                    Try
                        Dim actualNumber, count As Integer
                        count = MainApplication.getInstance.Adressen.Count
                        ' MainApplication.getInstance.Adressen.Session.BeginTransaction()
                        For Each item As Adress In MainApplication.getInstance.Adressen

                            Date.TryParse(item.Datum, item.CreatedAt)
                            Date.TryParse(item.LastChanged, item.ChangedAt)
                            item.IsActive = True
                            item.SavewithoutTracking()

                            actualNumber += 1
                            MainApplication.getInstance.SendMessage("Aktualisiere Adressbuch (Datum der letzten Änderung): " & actualNumber & "/" & count & ".", True) 'TODO:NLS

                        Next
                        'MainApplication.getInstance.Adressen.Session.CommitTransaction()

                    Catch ex As Exception
                        Debug.Print("Fehler in Version 2.00:" & ex.Message)
                    End Try

                    dbVersion = "2.00.0000"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                If dbVersion < "2.00.0001" Then
                    MainApplication.getInstance.SendMessage(MainApplication.getInstance.Languages.GetText("UpdatingFrom2.01", "Aktualisiere Datenbank ab Version 2.0.1..."))
                    ' die Steuerdaten der Artikel rübernehmen!

                    ' Vorab schon die Daten laden; sonst klappt es nicht mit dem Update !
                    MainApplication.getInstance.JournalDocuments.Load()
                    MainApplication.getInstance.TaxRates.Load()

                    Dim count As Integer = MainApplication.getInstance.JournalDocuments.Count
                    Dim actualNumber As Integer

                    For Each journalDocument As JournalDocument In MainApplication.getInstance.JournalDocuments
                        For Each pos As JournalArticleGroup In journalDocument.ArticleGroups

                            For posItemID As Integer = 0 To pos.ArticleList.Count - 1
                                Dim posItem As JournalArticleItem = pos.ArticleList(posItemID)
                                posItem.TaxRate = journalDocument.GlobalTaxRate
                                posItem.TaxRateValue = journalDocument.TaxValue

                                If posItem.HasChanged Then
                                    posItem.Save()
                                End If

                            Next
                        Next
                        actualNumber += 1
                        MainApplication.getInstance.SendMessage("Aktualisiere Journaldaten: " & actualNumber & "/" & count & ".", True) 'TODO:NLS
                    Next

                    MainApplication.getInstance.SendMessage("Journaldaten aktualisiert.") 'TODO:NLS

                    ' Nun das Steuer-Bit setzen, damit werden Artikel nur in Netto PLUS MwSt oder Brutto Ink MwSt angezeigt

                    MainApplication.getInstance.SendMessage("Aktualisiere Steuerdaten...") 'TODO:NLS

                    actualNumber = 0
                    MainApplication.getInstance.EndMarqueeBar()
                    For Each item As JournalDocument In MainApplication.getInstance.JournalDocuments
                        item.ShowWithoutTax = MainApplication.getInstance.Settings.ItemsSettings.ShowWithoutTax
                        item.Plainsave()
                        actualNumber += 1
                        MainApplication.getInstance.SendMessage("Aktualisiere Journaldaten (Steuerdaten) : " & actualNumber & "/" & count & ".", True) 'TODO:NLS

                    Next
                    MainApplication.getInstance.StartMarqueeBar()


                    dbVersion = "2.00.0001"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                'Targettype
                If dbVersion < "2.00.0002" Then
                    MainApplication.getInstance.SendMessage(MainApplication.getInstance.Languages.GetText("UpdatingFrom2.02", "Aktualisiere Datenbank ab Version 2.0.2..."))


                    ' Kassebuchsteuersätze übernehmen Sterern /Werte Paare zusammensetzen
                    sql = "UPDATE KassenbuchSteuern SET Targettype=1 where Targettype is null"
                    dbCommand.CommandText = sql
                    dbCommand.ExecuteNonQuery()

                    dbVersion = "2.00.0002"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                If dbVersion < "2.00.0003" Then
                    MainApplication.getInstance.SendMessage(MainApplication.getInstance.Languages.GetText("UpdatingFrom2.03", "Aktualisiere Datenbank ab Version 2.0.3..."))

                    ' Alte Mahnungen gibt es nicht mehr !

                    dbVersion = "2.00.0003"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                If dbVersion < "2.00.0004" Then
                    ' Geschäftsvorfälle ...
                    'TODo: NLS
                    MainApplication.getInstance.SendMessage("Aktualisiere Geschäftsvorfälle-Übersicht...") 'TODO:NLS
                    Dim id, maxvalue As Integer
                    maxvalue = MainApplication.getInstance.JournalDocuments.Count

                    For Each item As JournalDocument In MainApplication.getInstance.JournalDocuments
                        item.SetHistoryItem()
                        id += 1
                        MainApplication.getInstance.SendProgress("Journal-Historie erzeugen: " & id & "/" & maxvalue, id, maxvalue)
                    Next

                    dbVersion = "2.00.0004"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                If dbVersion < "2.00.0005" Then
                    ' Geschäftsvorfälle ...
                    MainApplication.getInstance.SendMessage("Aktualisiere ""Erstellt am / Geändert am"" - Daten der Artikelliste ...") 'TODO:NLS

                    Dim maxvalue As Integer
                    maxvalue = MainApplication.getInstance.ArticleList.Count


                    For n As Integer = 0 To maxvalue - 1

                        Dim item As Article = MainApplication.getInstance.ArticleList(n)

                        Dim changedAt As Date
                        If Date.TryParse(item.ChangedAtOld, changedAt) Then

                            item.ChangedAt = changedAt
                        End If

                        Dim createdAt As Date
                        If Date.TryParse(item.CreatedAtOld, createdAt) Then
                            item.CreatedAt = createdAt
                        End If
                        If item.HasChanged Then
                            item.SavewithoutTracking()
                        End If


                        If n Mod 10 = 0 Then
                            'TODO: NLS
                            MainApplication.getInstance.SendProgress("Artikel geändert: " & n & "/" & maxvalue, n, maxvalue)
                        End If

                    Next


                    dbVersion = "2.00.0005"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If
                If dbVersion < "2.00.0006" Then



                    dbVersion = "2.00.0006"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                If dbVersion < "2.00.0007" Then
                    MainApplication.getInstance.SendMessage("Aktualisiere Datenbank ab Version 2.0.7...") 'TODO:NLS

                    MainApplication.getInstance.SendMessage("Setze Zahlungen in Forderungen/Verbindlichkeiten...")
                    Dim dps As New DownPayments(MainApplication.getInstance)
                    Dim enUS As New Globalization.CultureInfo("en-US")

                    Dim itemcounter As Integer
                    Do While itemcounter < dps.Count

                        Dim item As DownPayment = dps(itemcounter)

                        Dim newPaidDate As Date

                        If MainApplication.getInstance.Connections.DefaultConnection.Servertype = Tools.enumServerType.MySQL Then
                            ' im server-Format hinterlegt
                            If Date.TryParseExact(item.Datum, "MM/dd/yyyy hh:mm:ss", enUS, Globalization.DateTimeStyles.None, newPaidDate) Then
                                item.PaidDate = newPaidDate
                                item.Datum = newPaidDate.ToString("yyyy-MM-dd", enUS)
                                item.Save()
                            Else
                                Debug.Print("Fehler in Splittbuchungen: Datum-Feld konnte nicht erkannt werden. " & item.ToString)
                            End If
                        Else ' Normal, als textfeld hinterlegt
                            If Date.TryParse(item.Datum, newPaidDate) Then
                                item.PaidDate = newPaidDate
                                item.Save()
                            Else
                                Debug.Print("Fehler in Splittbuchungen: Datum-Feld konnte nicht erkannt werden. " & item.ToString)
                            End If
                        End If

                        itemcounter += 1
                    Loop

                    dps.Dispose()
                    dps = Nothing

                    Dim n, maxvalue As Integer
                    maxvalue = MainApplication.getInstance.Transactions.Count

                    For Each item As Transaction In MainApplication.getInstance.Transactions
                        If item.IsPaidInternal Then
                            If item.GetDownPayments.Count = 0 Then
                                Dim newdp As DownPayment = item.GetDownPayments.GetNewItem
                                newdp.Ammount = item.TotalAmmount
                                newdp.PaidDate = item.PaidDate
                                newdp.Description = MainApplication.getInstance.Languages.GetText("paid", "Bezahlt")
                                newdp.ParentTransaction = item
                                newdp.Save()
                            End If
                        End If
                        n += 1
                        If n Mod 10 = 0 Then
                            'TODO: NLS
                            MainApplication.getInstance.SendProgress("Artikel geändert: " & n & "/" & maxvalue, n, maxvalue)
                        End If

                    Next

                    dbVersion = "2.00.0007"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If


                If dbVersion < "2.00.0008" Then
                    ' Vorfälle referenzieren nun die ID aus dem Journaldokument un nicht mehr die LfndNumme im Journal. !

                    ' Hilfstabelle anlegen 
                    Dim jLIste As New Dictionary(Of Integer, JournalDocument)

                    For Each item As JournalDocument In MainApplication.getInstance.JournalDocuments
                        If item.DocumentType = enumJournalDocumentType.Rechnung Then
                            ' Fehler absichern - kann sein, das das Dokument bereits existiert
                            If Not jLIste.ContainsKey(item.DocumentID) Then
                                jLIste.Add(item.DocumentID, item)
                            End If

                        End If

                    Next

                    MainApplication.getInstance.Transactions.Session = MainApplication.getInstance.GetNewSession
                    MainApplication.getInstance.Transactions.Reload()

                    Dim n, maxValue As Integer
                    maxValue = MainApplication.getInstance.Transactions.Count

                    For Each item As Transaction In MainApplication.getInstance.Transactions
                        If item.InternalDocumentID.ToString = item.ItemDisplayNumber Then
                            ' Dann stimmt was nicht. 
                            If jLIste.ContainsKey(item.InternalDocumentID) Then
                                item.InternalDocumentID = jLIste(item.InternalDocumentID).ID
                            Else
                                item.InternalDocumentID = 0
                                item.IsIntern = False
                            End If
                            item.Save()
                        End If
                        n += 1
                        If n Mod 10 = 0 Then
                            'TODO: NLS
                            MainApplication.getInstance.SendProgress("Transaktionen referenz-ID vergabe: " & n & "/" & maxValue, n, maxValue)
                        End If

                    Next

                    Dim deleteCount As Integer
                    Dim lstToDelete As New List(Of Transaction)

                    lstToDelete.Clear()
                    ' Die löschen, die nicht im Journal existieren !
                    For Each item As Transaction In MainApplication.getInstance.Transactions
                        If item.IsIntern Then
                            If MainApplication.getInstance.JournalDocuments.GetItem(item.InternalDocumentID) Is Nothing Then
                                ' Löschen !
                                MainApplication.getInstance.SendMessage("Transaktion '" & item.ToString & " hat keinen Journaleintrag!")
                                lstToDelete.Add(item)
                            End If
                        End If

                    Next

                    deleteCount = lstToDelete.Count
                    ' Löschen..
                    Do While lstToDelete.Count > 0

                        lstToDelete(0).DeleteInternal()
                        lstToDelete.Remove(lstToDelete(0))  ' das oberste nun entfernen
                    Loop
                    MainApplication.getInstance.SendMessage(deleteCount & " geisterhafte Transaktions-Einträge gelöscht")
                    MainApplication.getInstance.Transactions.Reload()

                    dbVersion = "2.00.0008"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                If dbVersion < "2.00.0009" Then
                    MainApplication.getInstance.SendMessage("Lösche nicht mehr verwendete Tabellen...") 'TODO:NLS
                    ' Alte Tabellen löschen (In HWL 2 nicht mehr genutzt oder nie genutzt
                    '                    Alte Tabellen entfernen (HWL - 2 braucht nicht mehr alle Tabellen) 
                    '"Bank"   - Nie benutzt, auch nicht nötig
                    MainApplication.getInstance.Database.DropTable("Bank")

                    '"Beschaffungsliste" - In HWL1 / 1.7 zum ermitteln des Ausdruckes benötigt
                    MainApplication.getInstance.Database.DropTable("Beschaffungsliste")

                    '"euroagent" - Wurde in HWl 1 benötigt um euro umwandlung der Preise zu ermitteln
                    MainApplication.getInstance.Database.DropTable("euroagent")

                    '"Kassenbuchtexte" - sollte mal Texte für da sSchnelle auffüllen des Kassenbuches enthalten; wird nun aus der aktuellen Kassenbuchliste erzeugt
                    MainApplication.getInstance.Database.DropTable("Kassenbuchtexte")

                    '"material_kategorien" - war mal Gruppe / Kategorie; in HWL 1.7 bereits obsolete
                    MainApplication.getInstance.Database.DropTable("material_kategorien")

                    '"HandwerkGruppenItems"
                    MainApplication.getInstance.Database.DropTable("HandwerkGruppenItems")

                    '"HandwerkGruppenListe"  - altes "Handwerk" - Modul aus HWl -1
                    MainApplication.getInstance.Database.DropTable("HandwerkGruppenListe")

                    '"tmphandwerkitems" in HWl 1 Modul "Handwerk".. 
                    MainApplication.getInstance.Database.DropTable("tmphandwerkitems")

                    '"tmpkalk" in HWl 1 / 1.7 Hilfstabelle zum Drucken von Rechnungen
                    MainApplication.getInstance.Database.DropTable("tmpkalk")

                    '"material_texte" für Datanorm mal entworfen - nie Benutzt.  (Vielleicht nochmal interessant?) 
                    MainApplication.getInstance.Database.DropTable("material_texte")

                    '"protokoll" - Sollte mal das Logfile enthalten; aber nie umgesetzt. 
                    MainApplication.getInstance.Database.DropTable("protokoll")

                    '"tmptab" - ? 
                    MainApplication.getInstance.Database.DropTable("tmptab")

                    '"MWSTTMP" - Zwischentabelle; für irgendwas mal verwendet
                    MainApplication.getInstance.Database.DropTable("MWSTTMP")

                    '"wahr" - Hilfstabelle, um Ja / Nein werte aufzulösen
                    MainApplication.getInstance.Database.DropTable("wahr")

                    '"Sondertxte" - nie verwendet
                    MainApplication.getInstance.Database.DropTable("Sondertxte")

                    dbVersion = "2.00.0009"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                If dbVersion < "2.00.0011" Then

                    'Den neuen Anzeigetext für den Journaltyp vergeben
                    Dim jtypes As New JournalDocumentTypes(MainApplication.getInstance)
                    If jtypes.Count = 0 Then
                        ' Journaldokument-Typ Tabellen füllen
                        For Each item As enumJournalDocumentType In [Enum].GetValues(GetType(enumJournalDocumentType))
                            Dim newType As JournalDocumentType = jtypes.GetNewItem
                            newType.InternalID = CInt(item)
                            newType.Name = JournalDocument.GetDocTypeDisplayName(item)  ' Ist dann Obsolete

                            jtypes.Add(newType)
                            newType.Save()
                        Next
                        MainApplication.getInstance.JournalDocuments.DocumentTypeNames.Reload()
                    End If


                    dbVersion = "2.00.0011"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                If dbVersion < "2.00.0012" Then
                    '  Anrufernummern mit einer führenden "0" versehen

                    Dim callers As New PhoneCalls(MainApplication.getInstance)
                    For Each callElement As PhoneCall In callers
                        ' Erkennung von Internen Nummern ? 
                        If callElement.CallingID.Length > 4 Then
                            ' Dann war es wohl keine interne Nummer
                            If Not callElement.CallingID.StartsWith("0") Then
                                callElement.CallingID = "0" & callElement.CallingID
                                callElement.SavewithoutTracking()
                            End If
                        End If
                    Next


                    dbVersion = "2.00.0012"
                    MainApplication.getInstance.DBVersion = dbVersion
                End If

                If dbVersion < "2.00.0013" Then

                    ' ReplikIDs auf 32 erzwingen; sofern ein altes Update durchlaufen wurde
                    ' Feld Adressen.Firma verlängern
                    SetTextFieldLength()

                    dbVersion = "2.00.0013"
                    MainApplication.getInstance.DBVersion = dbVersion

                End If
                If dbVersion < "2.00.0014" Then

                    ' Unterschrift unter Artikelgruppen ist nun änderbar
                    sql = "UPDATE " & JournalArticleGroup.TableName & " SET SummaryText='Gesamtpreis dieser Artikelgruppe'"
                    dbCommand.CommandText = sql
                    dbCommand.ExecuteNonQuery()

                    MainApplication.getInstance.DBVersion = "2.00.0014"
                End If

                If dbVersion < "2.00.0015" Then

                    'Noch einige Felder verlängern
                    CheckClass(New ActiveInstance(MainApplication.getInstance.Session))
                    CheckClass(New JournalArticleItem(MainApplication.getInstance.Session))

                    MainApplication.getInstance.DBVersion = "2.00.0015"
                End If

                If dbVersion < "2.00.0016" Then

                    'Formatierte Beschreibungsfelder in Artikellisten einpflegen
                    sql = "UPDATE " & JournalArticleItem.TableName & " SET  RTFMemoText=Beschreibung "
                    MainApplication.getInstance.Database.ExcecuteNonQuery(sql)

                    MainApplication.getInstance.DBVersion = "2.00.0016"
                End If

                If dbVersion < "2.00.0017" Then

                    CheckClass(New Appointment(MainApplication.getInstance.Session)) ' Location, subject und Description verlängert
                    MainApplication.getInstance.DBVersion = "2.00.0017"
                End If
                If dbVersion < "2.00.0018" Then

                    ' Das Feld "Vorname" hatte bisher den kompletten Namen enthalten; wird nun gesplittet in Vor- und Nachname

                    For Each adresse As Adress In MainApplication.getInstance.Adressen
                        Dim OldVorname As String = adresse.FirstName ' Hatte mal das komplette Feld ethalten

                        If Not String.IsNullOrEmpty(OldVorname) Then ' Nicht leer 

                            OldVorname = OldVorname.Trim  ' Nicht nurr ein Leerzeichen

                            If Not String.IsNullOrEmpty(OldVorname) Then ' Nicht leer 

                                If OldVorname.Contains(" ") Then
                                    ' (mindestends ein Leerzeichen gefunden; von rechts an das erste Wort suchen und übernehmen)
                                    Dim Lastname As String
                                    Lastname = OldVorname.Substring(OldVorname.LastIndexOf(" "c)).Trim
                                    OldVorname = OldVorname.Substring(0, OldVorname.LastIndexOf(" "c))

                                    adresse.FirstName = OldVorname
                                    adresse.LastName = Lastname

                                Else
                                    'den ganzen Text als Nachname deklarieren
                                    adresse.LastName = OldVorname
                                    adresse.FirstName = String.Empty
                                End If

                            End If

                        End If
                        adresse.SavewithoutTracking()
                    Next

                    MainApplication.getInstance.DBVersion = "2.00.0018"
                End If

                If dbVersion < "2.00.0019" Then

                    'Spalte verlängern - bei komplexen Adressen wurde das nicht berücksichtigt
                    SetTextColLength(Adress.Tablename, "  LieferAdresse", 1000)
                    MainApplication.getInstance.DBVersion = "2.00.0019"
                End If


            Catch ex As DevExpress.Xpo.DB.Exceptions.SchemaCorrectionNeededException
                m_lastError = "In Version: " & dbVersion & vbCrLf & vbCrLf & ex.Message

            Catch ex As Exception
                m_lastError = "In Version: " & dbVersion & vbCrLf & vbCrLf & ex.Message

            Finally
                MainApplication.getInstance.EndMarqueeBar()
            End Try


        End Sub

        Private Sub SetTextFieldLength()


            Dim FieldAddressCompanysize As Integer

            FieldAddressCompanysize = CInt(MainApplication.getInstance.Database.GetColumnCharacterLength(Adress.Tablename, "Firma"))
            If FieldAddressCompanysize = 50 Then
                ' auf 250 setzen
                SetTextColLength(Adress.Tablename, "Firma", 250)
            End If

            CheckClass(New Adress(MainApplication.getInstance.Session))
            CheckClass(New Appointment(MainApplication.getInstance.Session))
            CheckClass(New Article(MainApplication.getInstance.Session))
            CheckClass(New Attachment(MainApplication.getInstance.Session))
            CheckClass(New CashJournalItem(MainApplication.getInstance.Session))
            CheckClass(New RecentlyUsed(MainApplication.getInstance.Session))
            CheckClass(New Reminder(MainApplication.getInstance.Session))
            CheckClass(New Transaction(MainApplication.getInstance.Session))
            CheckClass(New CashJournalItem(MainApplication.getInstance.Session))
            CheckClass(New Letter(MainApplication.getInstance.Session))
            CheckClass(New Unit(MainApplication.getInstance.Session))
            CheckClass(New JournalDocument(MainApplication.getInstance.Session))
            CheckClass(New JournalArticleItem(MainApplication.getInstance.Session))
            CheckClass(New JournalArticleGroup(MainApplication.getInstance.Session))
            CheckClass(New FixedCost(MainApplication.getInstance.Session))
            CheckClass(New CashAccount(MainApplication.getInstance.Session))
            CheckClass(New JournalDocument(MainApplication.getInstance.Session))

            SetTextColLength(JournalDocument.Tablename, "CreatedByID", 64)
            ' Wie kann man das generell erfassen ? 

        End Sub

        ''' <summary>
        ''' Vergrössert das Mapping von textspalten auf der angegebenen Klasse
        ''' </summary>
        ''' <param name="persitentClass"></param>
        ''' <remarks></remarks>
        Private Sub CheckClass(persitentClass As StaticItem)

            MainApplication.getInstance.SendMessage("Aktualisiere Feldlängen..(" & persitentClass.ClassInfo.TableName & ")") 'TODO:NLS

            Debug.Print("Checke Tabelle " & persitentClass.ClassInfo.TableName)
            For Each item As DevExpress.Xpo.Metadata.XPMemberInfo In persitentClass.ClassInfo.PersistentProperties
                If item.MemberType Is GetType(String) Then
                    Debug.Print(" Checke FeldType: " & item.MappingField)
                    If item.MappingFieldSize > MainApplication.getInstance.Database.GetColumnCharacterLength(persitentClass.ClassInfo.TableName, item.MappingField) Then
                        'HIT
                        Debug.Print("  CharacterField Size mismatch!   DB-Size: " & MainApplication.getInstance.Database.GetColumnCharacterLength(persitentClass.ClassInfo.TableName, item.MappingField) & ", Needs to be:" & item.MappingFieldSize)

                        SetTextColLength(persitentClass.ClassInfo.TableName, item.MappingField, item.MappingFieldSize)

                    End If
                End If
            Next

            ' ReplikID nochmal prüfen (aus Altdaten-Übernahme)
            Try
                If MainApplication.getInstance.Database.GetColumnCharacterLength(persitentClass.ClassInfo.TableName, "ReplikID") > 32 Then
                    MainApplication.getInstance.log.WriteLog(" Verkürze Feld 'ReplikID' in Tabelle: '" & persitentClass.ClassInfo.TableName & "'.")
                    SetTextColLength(persitentClass.ClassInfo.TableName, "ReplikID", 32)
                End If
            Catch ex As Exception
                MainApplication.getInstance.log.WriteLog("  Beim verkürzen des Feldes ist ist ein Fehler aufgetreten: " & ex.Message)
            End Try

        End Sub


        ''' <summary>
        ''' Setzt die Länge der Spalte neu
        ''' </summary>
        ''' <param name="tablename"></param>
        ''' <param name="columnName"></param>
        ''' <param name="newSize"></param>
        ''' <remarks></remarks>
        Private Sub SetTextColLength(tablename As String, columnName As String, newSize As Integer)
            Dim sqlAccess As String = "ALTER TABLE " & tablename & " ALTER COLUMN " & columnName
            Dim sqlMySQL As String = "ALTER TABLE " & tablename & " MODIFY COLUMN " & columnName


            If MainApplication.getInstance.Database.DatabaseType = Tools.enumServerType.Access Then
                If newSize < 254 Then
                    sqlAccess &= " TEXT(" & newSize & ")"
                Else
                    sqlAccess &= " MEMO"

                End If

                MainApplication.getInstance.Database.ExcecuteNonQuery(sqlAccess)
            Else
                If newSize < 254 Then
                    sqlMySQL &= " VARCHAR(" & newSize & ")"
                Else
                    sqlMySQL &= " TEXT"

                End If

                MainApplication.getInstance.Database.ExcecuteNonQuery(sqlMySQL)
            End If

        End Sub
        ''' <summary>
        ''' Für Version 1.7.1745
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CalculateTransactionPaidAmmounts()

        End Sub

        ''' <summary>
        ''' Liefert den letzten Fehlertext zrück
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LastError() As String
            Get
                Return m_lastError
            End Get

        End Property

        ''' <summary>
        ''' Prüft, ob das Datenbankschema aktuell ist
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ValidateSchema() As Boolean
            Return MainApplication.getInstance.IsSchemaValid
        End Function


    End Class


End Namespace