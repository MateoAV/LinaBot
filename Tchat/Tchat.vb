Public Module Tchat

    Public Function CanalActiveDesactive(ByVal index As Integer, ByVal canal As String, ByVal choix As String) As String

        With Comptes(index)

            If .Connecté Then

                .Tchat.BloqueTchat.Reset()

                Dim envoyer As String = "cC" & If(choix = True, "+", "-")

                Select Case canal.ToLower

                    Case "information"

                        .Send(envoyer & "i")

                    Case "communs", "commun"

                        .Send(envoyer & "*")

                    Case "groupe"

                        .Send(envoyer & "#$p")

                    Case "guilde"

                        .Send(envoyer & "%")

                    Case "alignement"

                        .Send(envoyer & "!")

                    Case "recrutement"

                        .Send(envoyer & "?")

                    Case "commerce"

                        .Send(envoyer & ":")

                    Case Else

                        Return "Impossible de trouver le canal indiqué, vérifier qu'il est bien orthographié ou existant."

                End Select

                Select Case .Tchat.BloqueTchat.WaitOne(15000)

                    Case True

                        Return "[Tchat] : Action réussi !"

                    Case False

                        .Tchat.BloqueTchat.Set()

                        Return "[Tchat] : Action échoué !"

                End Select

            Else

                Return "Le bot n'est pas connecté."

            End If

            Return "Aucune action possible. " & "Canal : " & canal & ", Choix : " & choix

        End With

    End Function

    Public Function CanalEnvoieMessage(ByVal index As Integer, ByVal message As String) As String

        With Comptes(index)

            Try

                If .Connecté Then

                    If message <> "" Then

                        Dim canal As String = Split(message, " ")(0)

                        message = message.Replace(canal & " ", "")

                        .Tchat.BloqueTchat.Reset()

                        Select Case canal.ToLower

                            Case "/c" ' Communs

                                .Send("BM*|" & message & "|")

                            Case "/w" ' Message Privée

                                Dim joueur As String = Split(message, " ")(0)
                                .Send("BM" & joueur & "|" & message.Replace(joueur & " ", "") & "|")

                            Case "/p" ' Groupe

                                .Send("BM$|" & message & "|")

                            Case "/g" ' Guilde

                                .Send("BM%|" & message & "|")

                            Case "/r" ' Recrutement

                                .Send("BM?|" & message & "|")

                            Case "/b" ' Commerce

                                .Send("BM:|" & message & "|")

                            Case "/a" ' Alignement

                                .Send("BM!|" & message & "|")

                            Case Else

                        End Select

                        Select Case .Tchat.BloqueTchat.WaitOne(15000)

                            Case True

                                Return "[Tchat - Réussi] - L'envoie du message à bien été effectué."

                            Case False

                                .Tchat.BloqueTchat.Set()

                                Return "[Tchat - Erreur] - Malheureusement personne vous entend :/"

                        End Select

                    Else

                        Return "Vous devez mettre un message pour que le bot l'envoie en jeu."

                    End If

                Else

                    Return "Le bot n'est pas connecté."

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDeCompte, "CanalEnvoieMessage", ex.Message)

            End Try

            Return "impossible d'envoyer le message, soit le message contient une erreur, soit le bot n'a pas réussi à envoyer le message pour diverse raison."

        End With

    End Function

End Module
