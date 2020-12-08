
Public Class Class_Récolte

    'faire en sorte que le bot calcul lui même la PO de la canne.
    Private Delegate Sub dlgRecolte()
    Private Delegate Function dlgFRecolte()

    ''' <summary>
    ''' Recolte les ressources sur la map selon le nom indiqué.
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="nom"></param>
    ''' <returns></returns>
    Public Function Recolte(ByVal index As Integer, ByVal nom As String) As Boolean

        With Comptes(index)

            Dim celluleRecolte As Integer = Recherche(index, nom)

            If celluleRecolte > 0 Then

                ._Send = "GA500" & .Personnage.InteractionCellule & ";"

                Dim pecheur As Boolean = False

                Select Case nom.ToLower

                    Case "frene", "chene", "if", "ebene", "orme", "erable", "charme", "chataignier", "noyer", "merisier", "bombu",
                             "oliviolet", "bambou", "bambou sacre", "bambou sombre", "kaliptus"

                        ._Send &= .Map.Interaction(celluleRecolte).Action("couper")

                    Case "ble", "houblon", "seigle", "orge", "avoine", "malt", "riz"

                        ._Send &= .Map.Interaction(celluleRecolte).Action("faucher")

                    Case "trefle a 5 feuilles", "menthe sauvage", "orchidee freyesque", "edelweiss", "pandouille"

                        ._Send &= .Map.Interaction(celluleRecolte).Action("cueillir")

                    Case "fer", "cuivre", "bronze", "kobalte", "argent", "or", "bauxite", "etain", "manganese", "dolomite", "silicate"

                        ._Send &= .Map.Interaction(celluleRecolte).Action("collecter")

                    Case "petits poissons riviere", "petits poissons mer", "poissons mer", "poissons riviere", "gros poissons riviere",
                             "gros poissons mer", "poissons geants riviere", "poissons geants mer", "pichon"

                        ._Send &= .Map.Interaction(celluleRecolte).Action("pecher")
                        pecheur = True

                    Case "lin", "chanvre"

                        If .Metier.Metier.ContainsKey("alchimiste") AndAlso .Metier.Metier("alchimiste").ItemEquipé Then

                            ._Send &= .Map.Interaction(celluleRecolte).Action("cueillir")

                        ElseIf .Metier.Metier.ContainsKey("paysan") AndAlso .Metier.Metier("paysan").ItemEquipé Then

                            ._Send &= .Map.Interaction(celluleRecolte).Action("faucher")

                        End If

                End Select

                Dim newMap As New FunctionMap

                If pecheur Then

                    newMap.Deplacement(index, RecolteCelluleProche(index, celluleRecolte, CanneDistance(index)))

                Else

                    newMap.Deplacement(index, celluleRecolte)

                End If

                'mettre bloque recolte avant et si en recolte il bot attendre sinon pas réussi ou quelqu'un a pris le bot fait 
                ' un .set

                Task.Delay(1000).Wait()

                If .Recolte.EnRecolte Then

                    If .Recolte.BloqueRecolte.WaitOne(30000) = False Then

                        .Recolte.BloqueRecolte.Set()

                        Return False

                    End If

                Else

                    RecolteRaté(index, celluleRecolte)

                End If

                Return True

            End If

            Return False

        End With

    End Function



    ''' <summary>
    ''' Cherche la récolte la plus proche du joueur.
    ''' </summary>
    ''' <param name="nom">Indique le nom de la récolte. Exemple : Ble, Orge, Pichon, etc...</param>
    ''' <returns>
    ''' 0 = Le bot n'a aucune cellule disponible pour faire une récolte. <br/>
    ''' Renvoie la cellule de la récolte.
    ''' </returns>
    Private Function Recherche(ByVal index As Integer, ByVal nom As String) As Integer

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlgFRecolte(Function() Recherche(index, nom)))

            Else

                Dim distance As Integer = 999
                Dim cellule As Integer = 0

                For Each pair As KeyValuePair(Of Integer, ClassInteraction) In .Map.Interaction

                    If pair.Key <> .Map.Entite(.Personnage.ID).Cellule Then

                        'Exemple : Frêne = Frêne correspond à celle voulu par l'utilisateur
                        If nom.ToLower = pair.Value.Nom.ToLower Then

                            If pair.Value.Information = "disponible" Then

                                Dim distanceMoiCell As Integer = goalDistance(.Map.Entite(.Personnage.ID).Cellule, pair.Value.Cellule, .Map.Largeur)

                                If distanceMoiCell < distance AndAlso distanceMoiCell > 0 Then

                                    'Je vérifie qu'aucun mobs ne bloque la récolte
                                    If RecolteMonstre(index, pair.Value.Cellule) Then

                                        distance = distanceMoiCell

                                        cellule = pair.Value.Cellule

                                    End If

                                End If

                            End If

                        End If

                    End If

                Next

                .Personnage.InteractionCellule = cellule
                Return cellule

            End If

            .Personnage.InteractionCellule = 0
            Return 0

        End With

    End Function



    ''' <summary>
    ''' Vérifie si un mob ne se trouve pas sur la cellule voulu, sinon le bot attaquera sans le vouloir le mob.
    ''' </summary>
    ''' <param name="cellule">Indique la cellule de la récolte.</param>
    ''' <returns>
    ''' True = Le bot peut aller sur la cellule ou se trouve la récolte. <br/>
    ''' False = Le bot ne peut pas aller sur la cellule indiqué sinon il attaque le groupe de monstre.
    ''' </returns>
    Private Function RecolteMonstre(ByVal index As Integer, ByVal cellule As String) As Boolean

        With Comptes(index)

            For Each Pair As ClassEntite In CopyMap(index, .Map.Entite).Values

                If Pair.IDUnique < 0 AndAlso Pair.Cellule = cellule Then

                    EcritureMessage(index, "[Récolte]", "Un ou des mobs gangbang la ressource en '" & cellule & "', elle ne peut être récolté.", Color.Red)

                    Return False

                End If

            Next

            Return True

        End With

    End Function



    ''' <summary>
    ''' Change l'information de la récolte si le bot n'a pas réussi à la récolter, évite ainsi au bot de spammer la récolte.
    ''' </summary>
    ''' <param name="cellule">Indique la cellule de la récolte.</param>
    Private Sub RecolteRaté(ByVal index As Integer, ByVal cellule As String)

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                .FrmUser.Invoke(New dlgRecolte(Sub() RecolteRaté(index, cellule)))

            Else

                If .Map.Interaction.ContainsKey(cellule) Then

                    .Map.Interaction(cellule).Information = "indisponible"

                    EcritureMessage(index, "[Récolte]", "Le bot n'a pas réussie à récolter la ressource sur la cellule : " & cellule, Color.Red)

                End If

            End If

        End With

    End Sub

    ''' <summary>
    ''' Donne la cellule la plus proche pour récolter la ressource.
    ''' </summary>
    ''' <param name="cellule">Indique la cellule de la récolte.</param>
    ''' <param name="portée">Indique la portée maximum, utile seulement pour le métier de pêcheur.</param>
    ''' <returns>Retourne la cellule ou doit se trouver le personnage pour récolter la ressource.</returns>
    Private Function RecolteCelluleProche(ByVal index As Integer, ByVal cellule As String, ByVal portée As Integer) As Integer

        With Comptes(index)

            Dim meilleurCellule As Integer = cellule
            Dim Meilleur_Distance As Integer = 999
            Dim newList As New ArrayList

            newList = Liste_Cellule_Porté(index, cellule, 1, portée)

            For i = 0 To newList.Count - 1

                If .Map.Handler(newList(i)).active AndAlso .Map.Handler(newList(i)).lineOfSight AndAlso .Map.Handler(newList(i)).movement > 0 Then

                    Dim path As String = ""
                    Dim pather As New Pathfinding(index)
                    path = pather.pathing(index, newList(i))

                    If path <> "" AndAlso goalDistance(cellule, newList(i), .Map.Largeur) <= portée AndAlso goalDistance(cellule, newList(i), .Map.Largeur) < Meilleur_Distance Then
                        Meilleur_Distance = goalDistance(cellule, newList(i), .Map.Largeur)
                        meilleurCellule = newList(i)
                    End If

                End If

            Next

            Return meilleurCellule

        End With

    End Function

    Private Function CanneDistance(ByVal index As Integer) As Integer

        With Comptes(index)

            For Each pair As ClassItem In .Inventaire.Values

                If pair.Catégorie = 20 Then

                    If pair.Equipement <> "" Then

                        Select Case pair.IdObjet

                            Case "596"

                                Return 1

                            Case "1860"

                                Return 8

                            Case "1861"

                                Return 8

                            Case "1862"

                                Return 6

                            Case "1863"

                                Return 6

                            Case "1864"

                                Return 4

                            Case "1865"

                                Return 4

                            Case "1866"

                                Return 3

                            Case "1867"

                                Return 5

                            Case "1868"

                                Return 7

                            Case "2188"

                                Return 3

                            Case "8541"

                                Return 1

                        End Select

                    End If

                End If

            Next

            Return 0

        End With

    End Function

End Class

