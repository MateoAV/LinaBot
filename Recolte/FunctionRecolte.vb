
Public Class FunctionRecolte

    Private Delegate Sub dlgRecolte()

    ''' <summary>
    ''' Recolte les ressources sur la map selon le nom indiqué.
    ''' </summary>
    ''' <param name="index">Le numéro du bot.</param>
    ''' <returns>
    ''' True = le bot à fait une récolte. <br/>
    ''' False = Le bot n'a plus aucune récolte disponible sur la map.
    ''' </returns>
    Public Function Recolte(index As Integer) As Boolean

        With Comptes(index)

            Try

                Dim nomInteraction As String = ""
                Dim action As String = ""
                Dim distance As Integer = 999
                Dim cellule As Integer = 0

                For Each PairMap As KeyValuePair(Of Integer, CInteraction) In CopyInteraction(index, .Map.Interaction)

                    For Each PairRecolte As KeyValuePair(Of Object, Object) In .FrmGroupe.Variable("recolte")

                        If PairMap.Value.Nom.ToLower = PairRecolte.Value(1).ToString.ToLower Then

                            If PairMap.Value.Information = "disponible" Then

                                Dim distanceMoiCell As Integer = goalDistance(.Map.Entite(.Personnage.ID).Cellule, PairMap.Value.Cellule, .Map.Largeur)

                                If distanceMoiCell < distance AndAlso distanceMoiCell > 0 Then

                                    'Je vérifie qu'aucun mobs ne bloque la récolte
                                    If EviteMonstre(index, PairMap.Value.Cellule) Then

                                        nomInteraction = PairMap.Value.Nom
                                        action = PairRecolte.Value(2).ToString.ToLower
                                        distance = distanceMoiCell
                                        cellule = PairMap.Value.Cellule
                                        .Personnage.InteractionCellule = cellule

                                    End If

                                End If

                            End If

                        End If

                    Next

                Next

                If cellule > 0 Then

                    Dim newTask As New List(Of Task(Of Boolean))

                    Dim newMap As New FunctionMap
                    Dim newInteraction As New FunctionInteraction

                    newTask.Add(Task.Run(Function() newMap.Deplacement(index,
                    If(action.ToLower = "pecher",
                    CelluleProche(index, cellule, CanneDistance(index)), ' True
                    cellule)))) ' False

                    '  newTask.Add(Task.Run(Function() newMap.Deplacement(index, cellule))) ' False

                    Task.Delay(500).Wait()

                    newTask.Add(Task.Run(Function() newInteraction.Interaction(index, nomInteraction, action, cellule)))

                    Task.WaitAll(newTask.ToArray)

                    If newTask(1).Result = False Then

                        RecolteRaté(index, cellule)

                    Else

                        While .Recolte.EnRecolte

                            Task.Delay(1000).Wait()

                        End While

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
    ''' Vérifie si un mob ne se trouve pas sur la cellule voulu, sinon le bot attaquera sans le vouloir le mob.
    ''' </summary>
    ''' <param name="cellule">Indique la cellule de la récolte.</param>
    ''' <returns>
    ''' True = Le bot peut aller sur la cellule ou se trouve la récolte. <br/>
    ''' False = Le bot ne peut pas aller sur la cellule indiqué sinon il attaque le groupe de monstre.
    ''' </returns>
    Private Function EviteMonstre(index As Integer, cellule As String) As Boolean

        With Comptes(index)

            Try

                For Each Pair As CEntite In CopyMap(index, .Map.Entite).Values

                If Pair.IDCategorie < -1 OrElse Pair.IDCategorie < -2 OrElse Pair.IDCategorie < -3 Then

                    If Pair.Cellule = cellule Then

                        EcritureMessage(index, "[Récolte]", "Un ou des mobs gangbang la ressource en '" & cellule & "', elle ne peut être récolté.", Color.Red)

                        Return False

                    End If

                End If

            Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Recolte_EviteMonstre", ex.Message)

            End Try

            Return True

        End With

    End Function


    ''' <summary>
    ''' Change l'information de la récolte si le bot n'a pas réussi à la récolter, évite ainsi au bot de spammer la récolte.
    ''' </summary>
    ''' <param name="cellule">Indique la cellule de la récolte.</param>
    Private Sub RecolteRaté(index As Integer, cellule As String)

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                .FrmUser.Invoke(New dlgRecolte(Sub() RecolteRaté(index, cellule)))

            Else

                If .Map.Interaction.ContainsKey(cellule) Then

                    .Map.Interaction(cellule).Information = "indisponible"

                    EcritureMessage(index, "[Récolte]", "Le bot n'a pas réussie à récolter la ressource sur la cellule : " & cellule, Color.Red)

                End If

            End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "RecolteRaté", ex.Message)

            End Try

        End With

    End Sub


    ''' <summary>
    ''' Donne la cellule la plus proche pour récolter la ressource.
    ''' </summary>
    ''' <param name="cellule">Indique la cellule de la récolte.</param>
    ''' <param name="portée">Indique la portée maximum, utile seulement pour le métier de pêcheur.</param>
    ''' <returns>Retourne la cellule ou doit se trouver le personnage pour récolter la ressource.</returns>
    Private Function CelluleProche(index As Integer, cellule As String, portée As Integer) As Integer

        With Comptes(index)

            Dim meilleurCellule As Integer = cellule
            Dim Meilleur_Distance As Integer = 999
            Dim newList As New ArrayList

            Try

                newList = Liste_Cellule_Porté(index, cellule, 1, portée)

                For i = 0 To newList.Count - 1

                    If .Map.Handler(newList(i)).active AndAlso .Map.Handler(newList(i)).lineOfSight AndAlso .Map.Handler(newList(i)).movement > 1 Then

                        Dim path As String = ""
                        Dim pather As New Pathfinding(index)
                        path = pather.pathing(index, newList(i))
                        Dim distance As Integer = goalDistance(cellule, newList(i), .Map.Largeur)

                        If path <> "" AndAlso distance < Meilleur_Distance Then

                            Meilleur_Distance = distance
                            meilleurCellule = newList(i)

                        End If

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Recolte_CelluleProche", ex.Message)

            End Try

            Return meilleurCellule

        End With

    End Function



    ''' <summary>
    ''' Retourne la distance maximum de la canne selon l'ID de la canne équipé.
    ''' </summary>
    ''' <param name="index">Le numéro du bot.</param>
    ''' <returns>
    ''' Retourne la distance maximum de la canne.
    ''' </returns>
    Private Function CanneDistance(index As Integer) As Integer

        With Comptes(index)

            Try

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

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "CanneDistance", ex.Message)

            End Try

            Return 0

        End With

    End Function

End Class

