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

                If .EnCombat = False AndAlso .Recolte.EnRecolte = False Then

                    .Map.Bloque.Reset()

                    .Socket.Envoyer("eD" & .Personnage.ID & "|" & Orientation(monOrientation))

                    Return .Map.Bloque.WaitOne(15000)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "ChangerOrientation", ex.Message)

            End Try

            Return False

        End With

    End Function

    Public Function Orientation(ByVal choix As String) As String

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

End Class
