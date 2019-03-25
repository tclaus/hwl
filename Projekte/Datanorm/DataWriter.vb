Option Explicit On
Option Strict On

Imports ClausSoftware.Kernel

''' <summary>
''' Schreibt die gelesenen Datenfelder in die Datenbank
''' </summary>
''' <remarks></remarks>
Friend Class DataWriter

    Private m_Articles As ClausSoftware.Kernel.Articles

    ''' <summary>
    ''' Stellt einen Standard Gruppennamen dar, in dem alle Importierten Daten abgelegt werden
    ''' </summary>
    ''' <remarks></remarks>
    Private Const DefaultGroupName As String = "Datanorm Importiert"

    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)>
    Private m_datanormErstellerID As String

    Private m_groupsList As New Dictionary(Of String, String) ' 1.: Hauptwarengruppe / Unterwarengruppe, 2: Ziel-Schlüssel der Gruppe


    ''' <summary>
    ''' Ruft die ID des Datanorm erstellers ab. Werden von mehreren LIeferabnten Daten eingelesen, ist nur zusammen mit der DTN-Artikelnummer und der DTN-Erstellers der Datensatz eindeutig
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ErstellerID() As String
        Get
            Return m_datanormErstellerID
        End Get
        Set(ByVal value As String)
            m_datanormErstellerID = value
        End Set
    End Property


    Public Sub New()
        ' Neue Auflistung abholen

        m_Articles = CType(MainApplication.getInstance().ArticleList.GetNewCollectionAsync, ClausSoftware.Kernel.Articles)

        ' (Artikel nicht lokal der Auflistung hinzufügen! Es können sehr viele Artikel werden !) 

        ScannGroups()

    End Sub

    ''' <summary>
    ''' Löscht Datenfelder, die zum Einleen zurückgesetzt werden müssen
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        m_textBlock.Clear()

    End Sub
    ''' <summary>
    ''' Schreibt den übergebenen Artikelsatz in die Datenbank
    ''' </summary>
    ''' <param name="articleData"></param>
    ''' <remarks></remarks>
    Public Sub WriteArticleData(ByVal articleData As Artikelsatz)
        Dim currentArticle As Article = GetDTNArticle(articleData.Artikelnummer)

        ' Neu oder Ändern ist egal - es werden alle Felder neu geschrieben. 
        With currentArticle
            ' Datanorm Stammdaten angeben
            .DatanormArtikelnummer = articleData.Artikelnummer
            .DatanormErsteller = Me.ErstellerID
            .DatanormMatchCode = articleData.Matchcode
            .SourceDatanorm = True

            ' Artikeldaten schreiben
            .EAN = articleData.EAN
            If articleData.Textkennzeichen = enumTextKennzeichen.Default Or
                articleData.Textkennzeichen = enumTextKennzeichen.KT1_KT2_Dimension Or
                articleData.Textkennzeichen = enumTextKennzeichen.KT1_KT2_LT Or
                articleData.Textkennzeichen = enumTextKennzeichen.KT1_KT2_LT_Dimension Then

                .ShortDescription = articleData.KurzText1
                .LongDescription = articleData.KurzText2
            End If

            If Not String.IsNullOrEmpty(articleData.Rabattgruppe) Then
                .Discount = MainApplication.getInstance.Discounts.GetByDTNKey(articleData.Rabattgruppe, Me.ErstellerID)
            End If

            If articleData.Textkennzeichen = enumTextKennzeichen.LT_KurzText2 Then
                ' Langtext voranstellen
                If m_textBlock.ContainsKey(articleData.Langtextnummer) Then
                    .ShortDescription = m_textBlock(articleData.Langtextnummer)
                Else
                    .ShortDescription = articleData.KurzText1
                    Debug.Print("Langtextnummer '" & articleData.Langtextnummer & "' nicht gefunden.")
                End If

                .LongDescription = articleData.KurzText1 & vbCrLf & articleData.KurzText2

            End If

            If articleData.Textkennzeichen = enumTextKennzeichen.KT1_KT2_LT Or articleData.Textkennzeichen = enumTextKennzeichen.KT1_KT2_LT_Dimension Then
                ' Langtext anfügen
                If m_textBlock.ContainsKey(articleData.Langtextnummer) Then
                    .LongDescription &= vbCrLf & m_textBlock(articleData.Langtextnummer)
                Else

                    Debug.Print("Langtextnummer '" & articleData.Langtextnummer & "' nicht gefunden.")
                End If

            End If

            If articleData.Textkennzeichen = enumTextKennzeichen.LT_Dimensionstext Then
                ' Langtext als shorttext aufnehmen
                If m_textBlock.ContainsKey(articleData.Langtextnummer) Then
                    .LongDescription = m_textBlock(articleData.Langtextnummer)
                Else
                    Debug.Print("Langtextnummer '" & articleData.Langtextnummer & "' nicht gefunden.")
                End If

                .LongDescription = "" ' Dimensionstext nicht implementiert!

            End If
            .GroupID = GetDTNGroup(articleData.Hauptwarengruppe, articleData.Warengruppe)

            .VerpackungsEinheit = Units.FindUnit(articleData.Mengeneinheit, True)
            .EinzelEK = articleData.Preis
            .CountShippingUnits = articleData.Preiseinheit ' Normalerweise "1"

            'Gute Frage: Preiseinheit ? 

            ' Nun das Teil auch speichern
            currentArticle.Save()

        End With
    End Sub

    ''' <summary>
    ''' Überträgt Löschungen und / oder Artikelnummer änderungen
    ''' </summary>
    ''' <param name="articleChangeData"></param>
    ''' <remarks></remarks>
    Sub WriteArticleDataB(ByVal articleChangeData As ArtikelsatzB)
        Dim currentArticle As Article = GetDTNArticle(articleChangeData.Artikelnummer)

        If articleChangeData.Verarbeitungsmerker = enumVerarbeitungsmerker.Löschung Then
            currentArticle.IsActive = False
            ' Nachfolge festlegen
            If articleChangeData.EditedArtikelnummer.Length > 0 Then
                Dim successor As Article = GetDTNArticle(articleChangeData.EditedArtikelnummer)
                currentArticle.GetSucccessorItem.Add(successor)

            End If
        End If

        ' Änderung der Artikelnummer
        If articleChangeData.Verarbeitungsmerker = enumVerarbeitungsmerker.Änderung Then
            currentArticle.DatanormArtikelnummer = articleChangeData.EditedArtikelnummer
        End If

        currentArticle.Save()

    End Sub

    Public Sub WritePreisÄnderungsSatz(preisSatz As Preisänderungssatz)
        With preisSatz
            Dim article As Article = Me.GetDTNArticle(.artikelnummer)
            If article IsNot Nothing Then

                article.EinzelEK = .preis
                If .preiskennzeichen <> enumPreisKennzeichen.EmpfohlenerVKNetto Then
                    If .preiskennzeichen = enumPreisKennzeichen.ListenPreis Then
                        article.Discount = MainApplication.getInstance.Discounts.GetByDTNKey(.rabattgruppe)
                        'IMPORTANT: Rabattkennzeichen: Multi / Rabatt/ Tererungszuschlag definieren !

                    End If


                Else
                    ' empfohlener VK

                End If
            End If

        End With
    End Sub


    ''' <summary>
    ''' Stellt einen Textbausteim mit seinem Schlüssl bereit
    ''' </summary>
    ''' <remarks></remarks>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Advanced)>
    Private m_textBlock As New Dictionary(Of String, String)

    ''' <summary>
    ''' Schreibt einen Textsatz in den lokalen Speicher
    ''' </summary>
    ''' <param name="textsatz"></param>
    ''' <remarks></remarks>
    Sub WriteTextData(ByVal textsatz As Textsatz)
        ' Einem Artikle einen Textsatz zuordnen

        If textsatz.Merker = enumTextmerker.Ungebunden Then Exit Sub ' Hat hier nichts zu suchen !

        If Not m_textBlock.ContainsKey(textsatz.Textnummer) Then
            m_textBlock.Add(textsatz.Textnummer, textsatz.Textzeile) ' erste Zeile anlegen
        Else
            ' Textzeile hinzufügen
            m_textBlock(textsatz.Textnummer) &= vbCrLf & textsatz.Textzeile
        End If

    End Sub



    ''' <summary>
    '''  Legt die Datanorm - Gruppen an
    ''' </summary>
    ''' <param name="gruppenSatz"></param>
    ''' <remarks></remarks>
    Sub WriteGroupData(gruppenSatz As Hauptwarengruppen)
        Dim DTNKey As String = gruppenSatz.Hauptwarengruppe & "/" & gruppenSatz.UnterWarengruppe 'Suchschlüssel von datanorm

        If Not m_groupsList.ContainsKey(DTNKey) Then

            ' Neue Gruppe anlegen 
            Dim grp As Group = MainApplication.getInstance.Groups.GetNewItem
            grp.Name = gruppenSatz.Bezeichnung

            grp.DTNHauptWarengruppe = gruppenSatz.Hauptwarengruppe
            grp.DTNUnterWarengruppe = gruppenSatz.UnterWarengruppe
            grp.DTNErsteller = Me.ErstellerID

            'Hmm...  Wenn ne Unterwarengruppe gesetzt ist; muss diese zur Hauptwarengruppe verzweigen.. 
            If Not String.IsNullOrEmpty(gruppenSatz.UnterWarengruppe) Then
                Dim parentID As String = GetDTNGroup(gruppenSatz.Hauptwarengruppe, String.Empty)
                grp.ParentID = parentID
            End If

            grp.IsExtern = True
            grp.Save()
            MainApplication.getInstance.Groups.Add(grp)

            m_groupsList.Add(DTNKey, grp.Key)

        End If

    End Sub

    ''' <summary>
    ''' Liest alle Gruppen ein, die für Datanorm relevant sein können
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScannGroups()
        m_groupsList.Clear()

        For Each item As Group In MainApplication.getInstance.Groups
            Dim DTNKey As String = item.DTNHauptWarengruppe & "/" & item.DTNUnterWarengruppe 'Suchschlüssel von datanorm
            If DTNKey.Length > 1 Then
                m_groupsList.Add(DTNKey, item.Key)
            End If
        Next

    End Sub

    ''' <summary>
    ''' Ruft ein Artikel anhand der Artikelnummer ab. Konnte kein Artikel gefunden werden, wird ein neuer Artikel zurückgegeben
    ''' </summary>
    ''' <param name="articleNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDTNArticle(ByVal articleNumber As String) As Article
        m_Articles.CriteriaString = "DatanormArtikelnummer = '" & articleNumber & "' AND DatanormErsteller='" & Me.ErstellerID & "'"

        'm_Articles.Reload()
        If m_Articles.Count = 0 Then
            ' Kein Artikel gefunden, lege einen neuen Artikel an
            Return m_Articles.GetNewItem
        Else
            ' Ein Artikel wurde gefunden, gebe diesen zurück
            Return m_Articles(0)
        End If

    End Function

    ''' <summary>
    ''' Ruft eine Ziel-ID zu den angegebenen Warengruppen ab. 
    ''' Bleibt leer, wenn keine Gruppe gefunden werden konnte
    ''' </summary>
    ''' <param name="hauptGruppenID"></param>
    ''' <param name="unterGruppenID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDTNGroup(hauptGruppenID As String, unterGruppenID As String) As String
        Dim DTNKey As String
        Static rootGroup As String = MainApplication.getInstance.Groups.RootGroup.Key

        If Not String.IsNullOrEmpty(hauptGruppenID) Then
            DTNKey = hauptGruppenID & "/"
        Else
            Return rootGroup  ' Wenn keine Hauptgruppe angegeben wurde, dann kann auch nichts zurückgegeben werden
        End If
        If Not String.IsNullOrEmpty(unterGruppenID) Then
            DTNKey &= unterGruppenID
        End If

        If m_groupsList.ContainsKey(DTNKey) Then
            Return m_groupsList(DTNKey)
        Else
            Return rootGroup
        End If

    End Function

    ''' <summary>
    ''' Schreibt einen Rabattsatz
    ''' </summary>
    ''' <param name="rabatt">Datanorm Rabattsatz</param>
    ''' <remarks></remarks>
    Public Sub WriteDiscounts(rabatt As Rabattsatz)

        Dim newDiscount As Discount = MainApplication.getInstance.Discounts.GetByDTNKey(rabatt.RabattgruppenID)

        If newDiscount Is Nothing Then
            newDiscount = MainApplication.getInstance.Discounts.GetNewItem
            MainApplication.getInstance.Discounts.Add(newDiscount)
        End If

        newDiscount.DiscountValue = rabatt.Rabattwert
        newDiscount.DTNDiscountID = rabatt.RabattgruppenID
        newDiscount.DTNErsteller = Me.ErstellerID
        newDiscount.DTNRabattKennzeichen = CType(rabatt.RabattKennzeichen, ClausSoftware.Kernel.enumRabattkennzeichen)
        newDiscount.SourceDatanorm = True
        newDiscount.Name = rabatt.Rabattgruppenbezeichnung
        newDiscount.Save()



    End Sub

End Class
