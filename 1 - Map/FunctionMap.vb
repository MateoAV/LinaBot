﻿Public Class FunctionMap

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
    ''' <param name="EviteAgression">Indique si le bot doit éviter les monstres qui agresse.</param>
    ''' <param name="delaiMinimum">Temps d'attente minimum avant de pouvoir faire une autre action.</param>
    ''' <param name="delaiMaximum">Temps d'attente maximum avant de pouvoir faire une autre action.</param>
    ''' <returns>
    ''' True = Le déplacement a réussi. <br/> 
    ''' False = Le déplacement a échoué.
    ''' </returns>
    ''' 
    Public Function Deplacement(index As Integer, celluleDirection As String, Optional EviteAgression As Boolean = True, Optional delaiMinimum As Integer = 500, Optional delaiMaximum As Integer = 1500) As Boolean

        With Comptes(index)

            Try

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

                    Dim pather As New Pathfinding(index)
                    Dim path As String = pather.pathing(celluleDirection, True, False)

                    If path <> "" Then

                        If .Send("GA001" & path,
 _                           ' Bonnes informations    
                             {
                             "GA0;1;" & .Personnage.ID ' En Déplacement
                             },
 _                           ' Mauvaises informations                 
                             {
                             "GA;0" 'Le déplacement a échoué.
                             }) Then

                            If .Map.PathTotal.Length < 9 Then

                                Task.Delay(180 * .Map.PathTotal.Length).Wait()

                            Else

                                Task.Delay(80 * .Map.PathTotal.Length).Wait()

                            End If

                        End If

                        Return .Send("GKK0",
                                {
 _                              'Bonnes informations
                                "BN",
                                "GDM",
                                "GA;905;"
                                })

                    Else

                        EcritureMessage(index, "(Bot)", "Aucune chemin trouvé pour le déplacement." & vbCrLf &
                                                        "MapID : " & .Map.ID & vbCrLf &
                                                        "CellID : " & celluleDirection & vbCrLf &
                                                        "Coordonnées : " & .Map.Coordonnees, Color.Red)

                    End If

                End If

            Catch ex As Exception

            End Try

            Return False

        End With

    End Function



    ''' <summary>
    ''' Change l'orientation du personnage sur la carte.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="monOrientation">L'orientation à avoir : <br/>
    ''' Nord , NordEst , NordOuest , Sud , SudEst , SudOuest , Est , Ouest</param>
    ''' <returns></returns>
    Public Function ChangerOrientation(index As Integer, monOrientation As String) As Boolean

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

    Private Function Orientation(choix As String) As String

        Try

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

        Catch ex As Exception

        End Try

        Return "1"

    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="index"></param>
    ''' <param name="nomIDJoueur"></param>
    ''' <returns></returns>
    Public Function Agresser(index As Integer, nomIDJoueur As String) As Boolean

        With Comptes(index)

            Try

                For Each pair As CEntite In CopyMap(index, .Map.Entite).Values

                    If pair.Nom.ToLower = nomIDJoueur.ToLower OrElse pair.IDUnique.ToString = nomIDJoueur Then

                        Return .Send("GA906" & pair.IDUnique,
 _                                   ' Bonnes Informations
                                     {"GA;906;" & .Personnage.ID & ";" & pair.IDUnique}, 'J'ai bien aggréssé le joueur
 _                                    ' Mauvaises informations
                                     {"GA;906;" & .Personnage.ID & ";p"}) 'Action impossible sur cette carte.

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "FunctionMap_Agresser", ex.Message)

            End Try

            Return False

        End With

    End Function

End Class
