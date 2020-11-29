Public Class FunctionMap

    ''' <summary>
    ''' Compare 2 IDs de map.
    ''' </summary>
    ''' <param name="index">Le numéro du bot.</param>
    ''' <param name="mapID">La map ID à vérifier, Exemple : 7411</param>
    ''' <returns>True = La MapID correspond à celle du bot. <br/>
    ''' False = La MapID ne correspond pas à celle du bot.</returns>
    Public Function ID(ByVal index As Integer, ByVal mapID As Integer) As Boolean

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
    ''' Déplace le bot sur une cellule/Direction indiqué.
    ''' </summary>
    ''' <param name="celluleDirection">Indique la direction ou la cellule où doit aller le bot.</param>
    ''' <param name="delaiMinimum">Temps d'attente minimum avant de pouvoir faire une autre action.</param>
    ''' <param name="delaiMaximum">Temps d'attente maximum avant de pouvoir faire une autre action.</param>
    ''' <returns>True = Le déplacement a réussi. <br/> 
    ''' False = Le déplacement a échoué.</returns>
    ''' 
    Public Function Deplacement(ByVal index As Integer, ByVal celluleDirection As String, Optional ByVal delaiMinimum As Integer = 500, Optional ByVal delaiMaximum As Integer = 1500) As Boolean

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

                    .Send("GA001" & path, True)

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

End Class
