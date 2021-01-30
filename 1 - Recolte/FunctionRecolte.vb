
Public Class FunctionRecolte

    'faire en sorte que le bot calcul lui même la PO de la canne.
    Private Delegate Sub dlgRecolte()
    Private Delegate Function dlgFRecolte()

    ''' <summary>
    ''' Recolte les ressources sur la map selon le nom indiqué.
    ''' </summary>
    ''' <param name="index">Le numéro du bot.</param>
    ''' <param name="nom">Le nom ou l'ID de la récolte, exemple : Frene</param>
    ''' <param name="action">Le nom de l'action à faire en jeu, exemple : couper</param>
    ''' <returns>
    ''' True = le bot à fait une récolte. <br/>
    ''' False = Le bot n'a plus aucune récolte disponible sur la map.
    ''' </returns>

    Public Function Recolte(index As Integer, nom As String, action As String) As Boolean

        With Comptes(index)

            Try

                Dim celluleRecolte As Integer = Recherche(index, nom)

                If celluleRecolte > 0 Then

                    ._Send = "GA500" & celluleRecolte & ";" & .Map.Interaction(celluleRecolte).Action(action.ToLower)

                    Dim newMap As New FunctionMap

                    If action.ToLower = "pecher" Then

                        newMap.Deplacement(index, RecolteCelluleProche(index, celluleRecolte, CanneDistance(index)))

                    Else

                        newMap.Deplacement(index, celluleRecolte)

                    End If

                    Task.Delay(1000).Wait()

                    If .Recolte.EnRecolte Then

                        While .Recolte.EnRecolte

                            Task.Delay(1000).Wait()

                        End While

                        Task.Delay(1000).Wait()

                    Else

                        RecolteRaté(index, celluleRecolte)

                    End If

                    Return True

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "FunctionRecolte_Recolte", ex.Message)

            End Try

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
    Private Function Recherche(index As Integer, nom As String) As Integer

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlgFRecolte(Function() Recherche(index, nom)))

            Else

                Dim distance As Integer = 999
                Dim cellule As Integer = 0

                For Each pair As KeyValuePair(Of Integer, CInteraction) In .Map.Interaction

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
    Private Function RecolteMonstre(index As Integer, cellule As String) As Boolean

        With Comptes(index)

            For Each Pair As CEntite In CopyMap(index, .Map.Entite).Values

                If Pair.IDCategorie < -1 OrElse Pair.IDCategorie < -2 OrElse Pair.IDCategorie < -3 Then

                    If Pair.Cellule = cellule Then

                        EcritureMessage(index, "[Récolte]", "Un ou des mobs gangbang la ressource en '" & cellule & "', elle ne peut être récolté.", Color.Red)

                        Return False

                    End If

                End If

            Next

            Return True

        End With

    End Function



    ''' <summary>
    ''' Change l'information de la récolte si le bot n'a pas réussi à la récolter, évite ainsi au bot de spammer la récolte.
    ''' </summary>
    ''' <param name="cellule">Indique la cellule de la récolte.</param>
    Private Sub RecolteRaté(index As Integer, cellule As String)

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
    Private Function RecolteCelluleProche(index As Integer, cellule As String, portée As Integer) As Integer

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
                    Dim distance As Integer = goalDistance(cellule, newList(i), .Map.Largeur)

                    If path <> "" AndAlso distance <= portée AndAlso distance < Meilleur_Distance Then

                        Meilleur_Distance = distance
                        meilleurCellule = newList(i)

                    End If

                End If

            Next

            Return meilleurCellule

        End With

    End Function

    Private Function CanneDistance(index As Integer) As Integer

        With Comptes(index)

            Dim canne As New Dictionary(Of Integer, Integer) From
               {{596, 1},
                {1860, 8},
                {1861, 8},
                {1862, 6},
                {1863, 6},
                {1864, 4},
                {1865, 4},
                {1866, 3},
                {1867, 5},
                {1868, 7},
                {2188, 3},
                {8541, 1}}

            For Each pair As CItem In .Inventaire.Values

                If pair.Categorie = 20 Then

                    If pair.Equipement <> "" Then

                        Return canne(pair.IdObjet)

                    End If

                End If

            Next

            Return 0

        End With

    End Function

End Class

