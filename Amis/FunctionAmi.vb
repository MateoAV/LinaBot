Public Class FunctionAmi

    ''' <summary>
    ''' Ouvre la liste d'ami/ennemi.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="choix">Choisis entre "Ami" et "Ennemi"</param>
    ''' <returns>
    ''' True = La liste est ouverte. <br/>
    ''' False = La liste n'est pas ouverte.
    ''' </returns>
    Public Function Ouvre(ByVal index As String, ByVal choix As String) As Boolean

        With Comptes(index)

            Try

                .Ami.BloqueAmi.Reset()

                Select Case choix.ToLower

                    Case "ami", "amie"

                        .Send("FL")

                    Case "ennemi", "ennemie"

                        .Send("iL")

                End Select

                Return .Ami.BloqueAmi.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "AmiOuvre", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Supprime le joueur de la liste d'ami/ennemi.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="pseudoNom">Le pseudo ou le nom de la personne.</param>
    ''' <param name="choix">Choisis entre "Ami" et "Ennemi"</param>
    ''' <returns>
    ''' True = Suppression réussie. <br/>
    ''' False = La suppression a échoué.
    ''' </returns>
    Public Function Supprime(ByVal index As String, ByVal pseudoNom As String, ByVal choix As String) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassAmiInformation In CopyAmi(index, If(choix.ToLower = "ami", .Ami.Ami, .Ami.Ennemi)).Values

                    If Pair.Pseudo.ToLower = pseudoNom.ToLower OrElse Pair.Nom.ToLower = pseudoNom.ToLower Then

                        .Ami.BloqueAmi.Reset()

                        Select Case choix.ToLower

                            Case "ami", "amie"

                                .Send("FD*" & Pair.Pseudo)

                            Case "ennemi", "ennemie"

                                .Send("iD*" & Pair.Pseudo)

                        End Select

                        .Ami.BloqueAmi.WaitOne(15000)

                        Select Case choix.ToLower

                            Case "ami", "amie"

                                If .Ami.Ami.ContainsKey(pseudoNom) Then Return False

                            Case "ennemi", "ennemie"

                                If .Ami.Ennemi.ContainsKey(pseudoNom) Then Return False

                        End Select

                        Return True

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Ami_Supprime", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Ajoute un ami/ennemi.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="pseudoNom">Le pseudo ou le nom de la personne.</param>
    ''' <param name="choix">Choisis entre "Ami" et "Ennemi"</param>
    ''' <returns>
    ''' True = Ajout réussie. <br/>
    ''' False = Ajout échoué.
    ''' </returns>
    Public Function Ajoute(ByVal index As String, ByVal pseudoNom As String, ByVal choix As String) As Boolean

        With Comptes(index)

            Try

                .Ami.BloqueAmi.Reset()

                Select Case choix.ToLower

                    Case "ami", "amie"

                        .Send("FA" & pseudoNom)

                    Case "ennemi", "ennemie"

                        .Send("iA%" & pseudoNom)

                End Select

                Return .Ami.BloqueAmi.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Ami_Ajoute", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Obtient les informations du joueur.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="pseudoNom">Le pseudo ou le nom de la personne.</param>
    ''' <param name="choix">Choisis entre "Ami" et "Ennemi"</param>
    ''' <returns>
    ''' True = Information obtenue. <br/>
    ''' False = aucune information obtenue.
    ''' </returns>
    Public Function Information(ByVal index As String, ByVal pseudoNom As String, ByVal choix As String) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassAmiInformation In CopyAmi(index, If(choix.ToLower = "ami", .Ami.Ami, .Ami.Ennemi)).Values

                    If Pair.Pseudo.ToLower = pseudoNom.ToLower OrElse Pair.Nom.ToLower = pseudoNom.ToLower Then

                        .Ami.BloqueAmi.Reset()

                        .Send("BW" & Pair.Nom)

                        Return .Ami.BloqueAmi.WaitOne(15000)

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "AmiInformation", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Rejoint un joueur directement sur la map (Incarnam)
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="nom">Nom du joueur.</param>
    ''' <returns>
    ''' True = Le bot a rejoint le joueur. <br/>
    ''' False = Le bot n'a pas réussie à rejoindre le joueur.
    ''' </returns>
    Public Function Rejoindre(ByVal index As String, ByVal nom As String) As Boolean

        With Comptes(index)

            Try

                .Ami.BloqueAmi.Reset()

                .Send("FJF" & nom)

                Return .Ami.BloqueAmi.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "AmiRejoindre", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Averti lors de la connexion d'un ami.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="ouiNon"></param>
    ''' <returns>
    ''' True = Le bot avertie via un message si un ami se connecte.. <br/>
    ''' False = Le bot n'avertie pas si un ami se connecte.
    ''' </returns>
    Public Function Avertie(ByVal index As String, ByVal ouiNon As String) As Boolean

        With Comptes(index)

            Try

                Select Case CBool(ouiNon)

                    Case True

                        .Send("FO+")

                    Case False

                        .Send("FO-")

                End Select

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "AmiAvertie", ex.Message)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Ignore ou supprime un joueur de la liste des ignorés.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="pseudoNom">Le pseudo ou le nom de la personne.</param>
    ''' <returns>
    ''' True = Le bot ignore ou supprime le joueur de la liste des ignorés. <br/>
    ''' False = Le bot n'a pas réussi à ignoré ou supprimé le joueur de la liste des ignorés.
    ''' </returns>
    Public Function IgnoreSupprime(ByVal index As String, ByVal pseudoNom As String) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassAmiInformation In CopyAmi(index, .Ami.Ignore).Values

                    If Pair.Pseudo.ToLower = pseudoNom.ToLower OrElse Pair.Nom.ToLower = pseudoNom.ToLower Then

                        .Ami.Ignore.Remove(pseudoNom)

                        Return True

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "AmiIgnoreSupprime", ex.Message)

            End Try

            Return False

        End With

    End Function

End Class
