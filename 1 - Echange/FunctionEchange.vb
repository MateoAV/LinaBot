Public Class FunctionEchange

    ''' <summary>
    ''' Lance un echange avec le joueur.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="nom">Le nom du joueur à qui lancer la demande d'échange.</param>
    ''' <returns>
    ''' True = Si le bot a réussie à faire la demande d'échange. <br/>
    ''' False = Si le bot n'a pas réussie à faire la demande d'échange.
    ''' </returns>
    Public Function Echange(ByVal index As String, ByVal nom As String) As Boolean

        With Comptes(index)

            Try

                If .Echange.EnEchange = False Then

                    For Each pair As KeyValuePair(Of Integer, ClassEntite) In .Map.Entite

                    If pair.Value.Nom.ToLower = nom.ToLower Then

                            .Echange.Bloque.Reset()

                            .Send("ER1|" & pair.Key)

                            .Echange.Bloque.WaitOne(15000)

                            Return .Echange.EnEchange

                        End If

                    Next

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "EchangeEchange", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Refuse ou arrête la demande d'échange en cours.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <returns>
    ''' True = Si le bot a réussie à refuser la demande d'échange. <br/>
    ''' False = Si le bot n'a pas réussie à refuser la demande d'échange.
    ''' </returns>
    Public Function RefuseArrete(ByVal index As String) As Boolean

        With Comptes(index)

            Try

                If .Echange.EnEchange OrElse .Echange.EnInvitation Then

                    .Echange.Bloque.Reset()

                    .Send("EV")

                    Return .Echange.Bloque.WaitOne(15000)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "EchangeRefuseArrete", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Accepte la demande d'échange.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <returns>
    ''' True = Si le bot a accepté la demande d'échange. <br/>
    ''' False = Si le bot n'a pas réussie à accepter la demande d'échange.
    ''' </returns>
    Public Function Accepte(ByVal index As String) As Boolean

        With Comptes(index)

            Try

                If .Echange.EnInvitation Then

                    .Echange.Bloque.Reset()

                    .Send("EA")

                    .Echange.Bloque.WaitOne(15000)

                    Return .Echange.EnEchange

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "EchangeAccepte", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Mais la quantité de kamas dans l'échange.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="quantite">La quantité de kamas à mettre dans l'échange.</param>
    ''' <returns>
    ''' True = Si le bot a réussie à mettre les kamas dans l'échange. <br/>
    ''' False = Si le bot n'a pas réussie à mettre les kamas dans l'échange.
    ''' </returns>
    Public Function Kamas(ByVal index As String, ByVal quantite As String) As Boolean

        With Comptes(index)

            Try

                If quantite > .Personnage.Kamas Then quantite = .Personnage.Kamas

                .Echange.Bloque.Reset()

                .Send("EMG" & quantite)

                Return .Echange.Bloque.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "EchangeKamas", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Valide l'échange en cours.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <returns>
    ''' True = Si le bot a validé l'échange. <br/>
    ''' False = Si le bot n'a pas réussie à valider l'échange.
    ''' </returns>
    Public Function Valide(ByVal index As String) As Boolean

        With Comptes(index)

            Try

                If .Echange.EnEchange Then

                    .Echange.Bloque.Reset()

                    .Send("EK")

                    Return .Echange.Bloque.WaitOne(15000)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "EchangeValide", ex.Message)

            End Try

            Return False

        End With

    End Function

End Class
