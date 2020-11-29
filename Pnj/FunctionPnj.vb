Public Class FunctionPnj

    ''' <summary>
    ''' Parler a un pnj présent sur la map.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="nom">Le nom ou l'ID du Pnj a parler.</param>
    ''' <returns>
    ''' True = Si le bot est en dialogue. <br/>
    ''' False = Le bot n'a pas réussi à parler au Pnj.
    ''' </returns>
    Public Function Parler(ByVal index As String, ByVal nom As String) As Boolean

        With Comptes(index)

            Try

                If .Pnj.EnDialogue = False Then

                    For Each Pair As ClassEntite In CopyMap(index, .Map.Entite).Values

                        If Pair.Nom.ToLower = nom.ToLower Then

                            .Pnj.BloquePnj.Reset()

                            .Send("DC" & Pair.IDUnique)

                            .Pnj.BloquePnj.WaitOne(15000)

                            Return .Pnj.EnDialogue

                        End If

                    Next

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Parler", ex.Message)

            End Try

            Return False

        End With

    End Function

    ''' <summary>
    ''' Donne une reponse au Pnj.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="phrase">La phrase à donner au Pnj pour lui répondre.</param>
    ''' <returns>
    ''' True = Le bot a bien réussi a répondre au Pnj. <br/>
    ''' False = Le bot n'a pas réussi a répondre au pnj.
    ''' </returns>
    Public Function Reponse(ByVal index As String, ByVal phrase As String) As Boolean

        With Comptes(index)

            Try

                If .Pnj.EnDialogue Then

                    If .Pnj.Reponse.Count > 0 Then

                        For i = 0 To .Pnj.Reponse.Count - 1

                            If phrase.ToLower = VarPnjRéponse(.Pnj.Reponse(i)).ToLower Then

                                EcritureMessage(index, "(Bot)", "Réponse : " & VarPnjRéponse(.Pnj.Reponse(i)), Color.Orange)

                                .Pnj.BloquePnj.Reset()

                                .Send("DR" & .Pnj.IdReponse & "|" & .Pnj.Reponse(i))

                                Return .Pnj.BloquePnj.WaitOne(15000)

                            End If

                        Next

                    Else

                        Quitte(index)

                    End If

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Réponse", ex.Message)

            End Try

            Return False

        End With

    End Function

    ''' <summary>
    ''' Quitte le dialogue en cours avec le pnj.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <returns>
    ''' True = Le bot a bien quitter le dialogue en cours. <br/>
    ''' False = Le bot n'a pas réussi à quitter le dialogue en cours.
    ''' </returns>
    Public Function Quitte(ByVal index As String)

        With Comptes(index)

            Try

                If .Pnj.EnDialogue Then

                    .Pnj.BloquePnj.Reset()

                    .Send("DV")

                    .Pnj.BloquePnj.WaitOne(15000)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "QuitteDialogue", ex.Message)

            End Try

            Return .Pnj.EnDialogue

        End With

    End Function

End Class
