Module mdlHDV

    Sub GiHotelDeVenteAcheterVendre(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' ECK11 | 1            , 10            , 100            ; 2            , 3            , 4            ; 2.0      ; 1000            ; 20                ; -1 ; 350
                ' ECK11 | Quantité * 1 , Quantité * 10 , Quantité * 100 ; Id Catégorie , Id Catégorie , Id Catégorie ; Taxe (%) ; Niveau Max Item ; Nbr item vendable ; ?  ; Nbr heure Max

                Dim separateData As String() = Split(data, "|")
                Dim separateInfo As String() = Split(separateData(1), ";")

                With .Pnj.HotelDeVente

                Dim separate As String() = Split(separateInfo(0), ",")

                .Quantiter1 = separate(0)
                .Quantiter10 = separate(1)
                .Quantiter100 = separate(2)

                separate = Split(separateInfo(1), ",")

                .ListeIdCatégorie.Clear()

                For i = 0 To separate.Count - 1

                    .ListeIdCatégorie.Add(separate(i))

                Next

                .Taxe = separateInfo(2)
                .NiveauMax = separateInfo(3)
                .NbrItemVendable = separateInfo(4)
                .HeureMax = separateInfo(6)

            End With

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiHotelDeVenteAcheterVendre", data & vbCrLf & ex.Message)

            End Try

            .Pnj.BloquePnj.Set()

        End With

    End Sub

    Sub GiHotelDeVenteItemID(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EHL2 | 829    ; 1351    ; etc...
                ' EHL2 | IdItem ; Id Item ; etc...

                Dim separateData As String() = Split(data, "|")
                EcritureMessage(index, "[Dofus]", "Vous avez sélectionner la catégorie : " & VarItemsCategorieNom(Mid(separateData(0), 4, separateData(0).Length)), Color.Green)

                separateData = Split(separateData(1), ";")

                With .Pnj.HotelDeVente

                    .ListeIdItem.Clear()

                    For i = 0 To separateData.Count - 1

                        .ListeIdItem.Add(separateData(i))

                    Next

                End With

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiHotelDeVenteItemID", data & vbCrLf & ex.Message)

            End Try

            .Pnj.BloquePnj.Set()

        End With

    End Sub

    Sub GiHotelDeVentePrixMoyen(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EHP 180      | 4836469
                ' EHP Id Objet | Prix Moyen

                Dim separateData As String() = Split(data, "|")

                .Pnj.HotelDeVente.PrixMoyen = separateData(1)

                EcritureMessage(index, "[Dofus]", "Prix Moyen constaté dans cet hôtel : " & separateData(1) & " kamas/u.", Color.Green)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiHotelDeVentePrixMoyen", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiHotelDeVenteItemChoisi(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EHl 180      | 7335643   ; 6f#1###0d0+1,64#10#14##1d5+15 ; 4150000  ;           ;            | Suivant
                ' EHl ID Objet | Id Unique ; Caracteristique               ; Prix * 1 ; Prix * 10 ; Prix * 100 | Suivant

                Dim separateData As String() = Split(data, "|")

                With .Pnj.HotelDeVente.ListeItem

                    .Clear()

                    For i = 1 To separateData.Count - 1

                        Dim separate As String() = Split(separateData(i), ";")

                        Dim newHDV As New ClassHDVItem

                        With newHDV

                            .IDUnique = separate(0)
                            .Caracteristique = ItemCaractéristique(separate(1))
                            .Prix1 = separate(2)
                            .Prix10 = separate(3)
                            .Prix100 = separate(4)

                        End With

                        .Add(separate(0), newHDV)

                    Next

                End With

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiHotelDeVenteItemChoisi", data & vbCrLf & ex.Message)

            End Try

            .Pnj.BloquePnj.Set()

        End With

    End Sub

    Sub GiHotelDeVenteItemEnVente(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EL 11759152  ; 100      ; 304      ;                 ; 10000 ; 1800          | 11803628;100;304;;10000;1800  
                ' EL Id Unique ; Quantité ; Id Objet ; Caractéristique ; Prix  ; Temps restant | Suivant

                Dim separateData As String() = Split(Mid(data, 3), "|")

                With .Pnj.HotelDeVente.ListeItem

                    .Clear()

                    For i = 1 To separateData.Count - 1

                        Dim separate As String() = Split(separateData(i), ";")

                        Dim newHDV As New ClassHDVItem

                        With newHDV

                            .IDUnique = separate(0)
                            .Quantiter = separate(1)
                            .IdObjet = separate(2)
                            .Caracteristique = ItemCaractéristique(separate(3))
                            .Prix = separate(4)
                            .TempsRestant = separate(5)

                        End With

                        .Add(separate(0), newHDV)

                    Next

                End With

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiHotelDeVenteItemEnVente", data & vbCrLf & ex.Message)

            End Try

            .Pnj.BloquePnj.Set()

        End With

    End Sub

    Sub GiHotelDeVenteItemMisEnVente(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EmK+ 11759152  | 100      | 304      |          | 10000 | 1800 
                ' EmK+ id unique | quantité | id objet | caract ? | Prix  | Temps Restant

                With .Pnj.HotelDeVente.ListeItem

                    Dim separateData As String() = Split(Mid(data, 5), "|")

                    Dim newHDV As New ClassHDVItem

                    With newHDV

                        .IDUnique = separateData(0)
                        .Quantiter = separateData(1)
                        .IdObjet = separateData(2)
                        .Caracteristique = ItemCaractéristique(separateData(3))
                        .Prix = separateData(4)
                        .TempsRestant = separateData(5)

                    End With

                    .Add(separateData(0), newHDV)

                End With

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiHotelDeVenteItemMisEnVente", data & vbCrLf & ex.Message)

            End Try

            .Pnj.BloquePnj.Set()

        End With

    End Sub

    Sub GiHotelDeVenteRetireItemMisEnVente(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EmK- 11791321
                ' EmK- Id Unique

                If .Pnj.HotelDeVente.ListeItem.ContainsKey(Mid(data, 5)) Then

                    .Pnj.HotelDeVente.ListeItem.Remove(Mid(data, 5))

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiHotelDeVenteRetireItemMisEnVente", data & vbCrLf & ex.Message)

            End Try

            .Pnj.BloquePnj.Set()

        End With

    End Sub

End Module
