Public Class FunctionMap

    ''' <summary>
    ''' Compare 2 IDs de map.
    ''' </summary>
    ''' <param name="index">Le numéro du bot.</param>
    ''' <param name="mapID">La map ID à vérifier, Exemple : 7411</param>
    ''' <returns>
    ''' True = La MapID correspond à celle du bot. <br/>
    ''' False = La MapID ne correspond pas à celle du bot.
    ''' </returns>
    Public Function ID(index As Integer, mapID As Integer) As Boolean

        With Comptes(index)

            Try

                If mapID = .Map.ID Then

                    Return True

                End If

            Catch ex As Exception

            End Try

            Return False

        End With

    End Function

    ''' <summary>
    ''' Compare 2 coordonnées de map.
    ''' </summary>
    ''' <param name="index">Le numéro du bot.</param>
    ''' <param name="mapCoordonnees">La map à vérifier, Exemple : 4,-16</param>
    ''' <returns>True = La Map correspond à celle du bot. <br/>
    ''' False = La Map ne correspond pas à celle du bot.</returns>
    Public Function Coordonnees(index As Integer, mapCoordonnees As String) As Boolean

        With Comptes(index)

            Try

                If mapCoordonnees = .Map.Coordonnees Then

                    Return True

                End If

            Catch ex As Exception

            End Try

            Return False

        End With

    End Function

    ''' <summary>
    ''' Déplace le bot sur une cellule/Direction indiqué.
    ''' </summary>
    ''' <param name="celluleDirection">Indique la direction ou la cellule où doit aller le bot.</param>
    ''' <param name="delaiMinimum">Temps d'attente minimum avant de pouvoir faire une autre action.</param>
    ''' <param name="delaiMaximum">Temps d'attente maximum avant de pouvoir faire une autre action.</param>
    ''' <returns>
    ''' True = Le déplacement a réussi. <br/> 
    ''' False = Le déplacement a échoué.
    ''' </returns>
    ''' 
    Public Function Deplacement(index As Integer, celluleDirection As String, Optional delaiMinimum As Integer = 500, Optional delaiMaximum As Integer = 1500) As Boolean

        With Comptes(index)

            If .Map.EnDeplacement Then StopDéplacement(index)

            If .Map.EnDeplacement = False Then

                Select Case celluleDirection.ToLower

                    Case "haut"

                        celluleDirection = .Map.Haut

                    Case "bas"

                        celluleDirection = .Map.Bas

                    Case "gauche"

                        celluleDirection = .Map.Gauche

                    Case "droite"

                        celluleDirection = .Map.Droite

                End Select

                Dim mapID As Integer = .Map.ID
                Dim pather As New Pathfinding(index)
                Dim path As String = pather.pathing(celluleDirection)

                If path <> "" Then

                    .BloqueDeplacement.Reset()

                    .Send("GA001" & path,
                         {"GA;0", 'Le déplacement a échoué.
                          "GA0;1;" & .Personnage.ID, 'Indique que je suis en plein déplacement.
                          "GDM", 'Indique un changement de map.
                          "GA;905;"}) 'Je suis entré en combat.

                    .BloqueDeplacement.WaitOne(15000)

                    Dim Rand As New Random
                    Task.Delay(Rand.Next(delaiMinimum, delaiMaximum)).Wait()

                    If mapID <> .Map.ID OrElse celluleDirection <> .Map.Entite(.Personnage.ID).Cellule Then

                        Return True

                    Else

                        EcritureMessage(index, "(Bot)", "Le déplacement à échoué." & vbCrLf &
                                                            "MapID : " & mapID & vbCrLf &
                                                            "CellID : " & celluleDirection & vbCrLf &
                                                            "Coordonnées : " & .Map.Coordonnees, Color.Red)

                    End If

                Else

                    EcritureMessage(index, "(Bot)", "Aucune chemin trouvé pour le déplacement." & vbCrLf &
                                                        "MapID : " & mapID & vbCrLf &
                                                        "CellID : " & celluleDirection & vbCrLf &
                                                        "Coordonnées : " & .Map.Coordonnees, Color.Red)

                End If

            End If

            Return False

        End With

    End Function

    Private Sub StopDéplacement(ByVal index As Integer)

        With Comptes(index)

            EcritureMessage(index, "(Bot)", "Arrét du déplacement en cours...", Color.Lime)

            .Map.StopDeplacement = True

            While .Map.EnDeplacement

                Task.Delay(1000).Wait()

            End While

            .Map.StopDeplacement = False

            Task.Delay(1000).Wait()

        End With

    End Sub

    ''' <summary>
    ''' Change l'orientation du personnage sur la carte.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="monOrientation">L'orientation à avoir : <br/>
    ''' Nord , NordEst , NordOuest , Sud , SudEst , SudOuest , Est , Ouest</param>
    ''' <returns></returns>
    Public Function ChangerOrientation(ByVal index As Integer, ByVal monOrientation As String) As Boolean

        With Comptes(index)

            Try

                If .Combat.EnCombat = False AndAlso .Recolte.EnRecolte = False Then

                    Return .Send("eD" & Orientation(monOrientation),
                                 {"eD" & .Personnage.ID})

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "ChangerOrientation", ex.Message)

            End Try

            Return False

        End With

    End Function

    Private Function Orientation(ByVal choix As String) As String

        Select Case choix.ToLower

            Case "0", "est"

                Return If(IsNumeric(choix), "est", "0")

            Case "1", "sudest"

                Return If(IsNumeric(choix), "sudest", "1")

            Case "2", "sud"

                Return If(IsNumeric(choix), "sud", "2")

            Case "3", "sudouest"

                Return If(IsNumeric(choix), "sudouest", "3")

            Case "4", "ouest"

                Return If(IsNumeric(choix), "ouest", "4")

            Case "5", "nordouest"

                Return If(IsNumeric(choix), "nordouest", "5")

            Case "6", "nord"

                Return If(IsNumeric(choix), "nord", "6")

            Case "7", "nordest"

                Return If(IsNumeric(choix), "nordest", "7")

            Case Else

                Return If(IsNumeric(choix), "sud", "2")

        End Select

    End Function

    ''' <summary>
    ''' Effectue une interaction avec un objet interactif en jeu.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="nomID">Le nom ou l'ID avec quoi intéragir.</param>
    ''' <param name="actionID">le nom de l'action ou l'ID à faire avec l'objet interactif.</param>
    ''' <returns>
    ''' True = le bot à intéragit avec l'objet. <br/>
    ''' False = Le bot n'a pas réussi à intéragir avec l'objet.
    ''' </returns>
    Public Function Interaction(index As Integer, nomID As String, actionID As String) As Boolean

        With Comptes(index)

            Try

                For Each pair As CInteraction In CopyInteraction(index, .Map.Interaction).Values

                    If pair.Nom.ToLower = nomID.ToLower OrElse pair.Sprite = nomID Then

                        For Each pairAction As KeyValuePair(Of String, Integer) In pair.Action

                            If pairAction.Key.ToLower = actionID.ToLower OrElse pairAction.Value.ToString = actionID Then

                                Return .Send("GA500" & pair.Cellule & ";" & pairAction.Value,
                                             {"GDF|" & pair.Cellule & ";"})

                            End If

                        Next

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Interaction", ex.Message)

            End Try

            Return False

        End With

    End Function


    Public Function Attaquer(ByVal index As Integer, ByVal choix As String) As Boolean

        With Comptes(index)
            Try


                For Each pair As CEntite In .Map.Entite.Values
                    '  pair.IDCategorie = -3
                    If pair.IDUnique < 0 AndAlso pair.Cellule <> .Map.Entite(.Personnage.ID).Cellule Then

                        If Not IsNothing(pair.ID) AndAlso pair.ID.Contains(",") Then

                            If .Map.Handler(pair.Cellule).layerObject1Num <> 1030 AndAlso .Map.Handler(pair.Cellule).layerObject2Num <> 1030 Then

                                Return Deplacement(index, pair.Cellule)

                            End If

                        ElseIf pair.Classe <> "Pnj" Then

                            If .Map.Handler(pair.Cellule).layerObject1Num <> 1030 AndAlso .Map.Handler(pair.Cellule).layerObject2Num <> 1030 AndAlso Not pair.Nom.StartsWith("Mino") Then

                                Return Deplacement(index, pair.Cellule)

                            End If

                        End If



                    End If

                Next
            Catch ex As Exception

            End Try
            Return False

        End With

    End Function

End Class
