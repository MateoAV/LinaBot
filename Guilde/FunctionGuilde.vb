Public Class FunctionGuilde

#Region "Ouverture"

    Public Function Ouvre(ByVal index As String) As Boolean

        With Comptes(index)

            Try

                .BloqueGuilde.Reset()

                .Send("gIG")

                Return .BloqueGuilde.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Guilde_Ouvre", ex.Message)

            End Try

            Return False

        End With

    End Function

    Public Function Membres(ByVal index As String) As Boolean

        With Comptes(index)

            Try

                .BloqueGuilde.Reset()

                .Send("gIM")

                Return .BloqueGuilde.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Guilde_Membres", ex.Message)

            End Try

            Return False

        End With

    End Function

    Public Function Personnalisation(ByVal index As String) As Boolean

        With Comptes(index)

            Try

                .BloqueGuilde.Reset()

                .Send("gIB")

                Return .BloqueGuilde.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Guilde_Personnalisation", ex.Message)

            End Try

            Return False

        End With

    End Function

    Public Function Percepteurs(ByVal index As String) As Boolean

        With Comptes(index)

            Try

                .BloqueGuilde.Reset()

                .Send("gIT")

                Return .BloqueGuilde.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Guilde_Percepteurs", ex.Message)

            End Try

            Return False

        End With

    End Function

    Public Function Enclos(ByVal index As String) As Boolean

        With Comptes(index)

            Try

                .BloqueGuilde.Reset()

                .Send("gITV")
                .Send("gIF")

                Return .BloqueGuilde.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Guilde_Enclos", ex.Message)

            End Try

            Return False

        End With

    End Function

    Public Function Maisons(ByVal index As String) As Boolean

        With Comptes(index)

            Try
                .BloqueGuilde.Reset()

                .Send("gIH")

                Return .BloqueGuilde.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Guilde_Maisons", ex.Message)

            End Try

            Return False

        End With

    End Function

#End Region

#Region "Membres"

    Public Function Exclure(ByVal index As String, ByVal nom As String) As Boolean

        With Comptes(index)

            .BloqueGuilde.Reset()

            .Send("gK" & nom)

            Return .BloqueGuilde.WaitOne(15000)

        End With

    End Function

    Public Function Invite(ByVal index As String, ByVal nom As String) As Boolean

        With Comptes(index)

            .BloqueGuilde.Reset()

            .Send("gJR" & nom)

            .Guilde.JoueurQuiEstInvite = nom

            Return .BloqueGuilde.WaitOne(15000)

        End With

    End Function

    Public Function Refuse(ByVal index As String) As Boolean

        With Comptes(index)

            .BloqueGuilde.Reset()

            .Send("gJE" & .Guilde.JoueurQuiInvite)

            Return .BloqueGuilde.WaitOne(15000)

        End With

    End Function

    Public Function Rang(ByVal index As String, ByVal membre As String, ByVal leRang As String) As Boolean

        With Comptes(index)

            Dim rangActuel() As String = {"a l'essai", "meneur", "bras droit", "tresorier", "protecteur", "artisan", "reserviste",
                "gardien", "eclaireur", "espion", "diplomate", "secretaire", "tueur de familiers", "braconnier", "chercheur de tresor",
                "voleur", "initie", "assassin", "gouverneur", "muse", "conseiller", "elu", "guide", "mentor", "recruteur",
                "eleveur", "marchand", "apprenti", "bourreau", "mascotte", "penitent", "tueur de percepteurs", "deserteur", "traitre",
                "boulet", "larbin", "a l'essai"}

            For i = 0 To rangActuel.Count - 1

                If rangActuel(i) = leRang.ToLower Then

                    For Each pair As ClassGuildeJoueur In .Guilde.Membre.Values

                        If pair.Nom.ToLower = membre.ToLower Then

                            .Send("gP" & pair.IdUnique & "|" & i & "|" & pair.PrXp & "|" & pair.DroitChiffre)

                            Return True

                        End If

                    Next

                End If

            Next

            Return False

        End With

    End Function

    Public Function Experience(ByVal index As String, ByVal membre As String, ByVal valeur As String) As Boolean

        With Comptes(index)

            For Each pair As ClassGuildeJoueur In .Guilde.Membre.Values

                If pair.Nom.ToLower = membre.ToLower Then

                    .Send("gP" & pair.IdUnique & "|" & pair.RangChiffre & "|" & valeur & "|" & pair.DroitChiffre)

                    Return True

                End If

            Next

            Return False

        End With

    End Function

    Public Function Droits(ByVal index As String, ByVal membre As String, ByVal lesDroits As String, ByVal Active As Boolean) As Boolean

        With Comptes(index)

            For Each pair As ClassGuildeJoueur In .Guilde.Membre.Values

                If pair.Nom.ToLower = membre.ToLower Then

                    .Send("gP" & pair.IdUnique & "|" & pair.RangChiffre & "|" & pair.PrXp & "|" & ReturnDroit(pair.Droit, lesDroits, Active))

                    Return True

                End If

            Next

            Return False

        End With

    End Function

    Private Function ReturnDroit(ByVal membre As ClassGuildeDroit, ByVal lesDroits As String, ByVal Active As Boolean) As Integer

        Dim valeur As Integer = 0

        With membre

            valeur += If(.GererLesBoosts = True, 16384, 0)
            valeur += If(.GererLesDroits = True, 8192, 0)
            valeur += If(.InviterDeNouveauxMembres = True, 4096, 0)
            valeur += If(.Bannir = True, 512, 0)
            valeur += If(.GererLesRepartitionsXP = True, 256, 0)
            valeur += If(.GererSaRepartitionXP = True, 128, 0)
            valeur += If(.GererLesRangs = True, 64, 0)
            valeur += If(.PoserUnPercepteur = True, 32, 0)
            valeur += If(.CollecterSurUnPercepteur = True, 16, 0)
            valeur += If(.UtiliserLesEnclos = True, 8, 0)
            valeur += If(.AmenagerLesEnclos = True, 4, 0)
            valeur += If(.GererLesMonturesDesAutresMembres = True, 2, 0)

            Dim separate As String() = Split(lesDroits, " | ")

            For i = 0 To separate.Count - 1

                Select Case separate(i).ToLower

                    Case "gerer les boosts"

                        valeur += If(Active = True, If(.GererLesBoosts = True, 0, 16384), If(.GererLesBoosts = True, -16384, -0))

                    Case "gerer les droits"

                        valeur += If(Active = True, If(.GererLesDroits = True, 0, 8192), If(.GererLesDroits = True, -8192, -0))

                    Case "inviter de nouveaux membres"

                        valeur += If(Active = True, If(.InviterDeNouveauxMembres = True, 0, 4096), If(.InviterDeNouveauxMembres = True, -4096, -0))

                    Case "bannir"

                        valeur += If(Active = True, If(.Bannir = True, 0, 512), If(.Bannir = True, -512, -0))

                    Case "gerer les repartitions d'xp"

                        valeur += If(Active = True, If(.GererLesRepartitionsXP = True, 0, 256), If(.GererLesRepartitionsXP = True, -256, -0))

                    Case "gerer sa repartition d'xp"

                        valeur += If(Active = True, If(.GererSaRepartitionXP = True, 0, 128), If(.GererSaRepartitionXP = True, -128, -0))

                    Case "gerer les rangs"

                        valeur += If(Active = True, If(.GererLesRangs = True, 0, 64), If(.GererLesRangs = True, -64, -0))

                    Case "poser un percepteur"

                        valeur += If(Active = True, If(.PoserUnPercepteur = True, 0, 32), If(.PoserUnPercepteur = True, -32, -0))

                    Case "collecter sur un percepteur"

                        valeur += If(Active = True, If(.CollecterSurUnPercepteur = True, 0, 16), If(.CollecterSurUnPercepteur = True, -16, -0))

                    Case "utiliser les enclos"

                        valeur += If(Active = True, If(.UtiliserLesEnclos = True, 0, 8), If(.UtiliserLesEnclos = True, -8, -0))

                    Case "amenager les enclos"

                        valeur += If(Active = True, If(.AmenagerLesEnclos = True, 0, 4), If(.AmenagerLesEnclos = True, -4, -0))

                    Case "gerer les montures des autres membres"

                        valeur += If(Active = True, If(.GererLesMonturesDesAutresMembres = True, 0, 2), If(.GererLesMonturesDesAutresMembres = True, -2, -0))

                End Select

            Next

        End With

        Return valeur

    End Function

#End Region

#Region "Personnalisation"

    Public Function Up(ByVal index As String, ByVal choix As String, ByVal quantiter As String) As Boolean

        With Comptes(index)

            For i = 0 To CInt(quantiter)

                Select Case choix.ToLower

                    Case "prospection"

                        If CInt(.Guilde.Percepteur.Prospection) < 500 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 1 Then

                                .BloqueGuilde.Reset()

                                .Send("gBp")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "sagesse"

                        If CInt(.Guilde.Percepteur.Sagesse) < 400 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 1 Then

                                .BloqueGuilde.Reset()

                                .Send("gBx")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "pods"

                        If CInt(.Guilde.Percepteur.Pods) < 5000 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 1 Then

                                .BloqueGuilde.Reset()

                                .Send("gBo")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "nombre de percepteur"

                        If CInt(.Guilde.Percepteur.NombreDePercepteur) < 50 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 10 Then

                                .BloqueGuilde.Reset()

                                .Send("gBk")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "armure aqueuse"

                        If CInt(.Guilde.Percepteur.ArmureAqueuse) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB451")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "armure incandescente"

                        If CInt(.Guilde.Percepteur.ArmureIncandescente) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB452")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "armure terrestre"

                        If CInt(.Guilde.Percepteur.ArmureTerrestre) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB453")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "armure venteuse"

                        If CInt(.Guilde.Percepteur.ArmureVenteuse) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB454")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "flamme"

                        If CInt(.Guilde.Percepteur.Flamme) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB455")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "cyclone"

                        If CInt(.Guilde.Percepteur.Cyclone) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB456")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "vague"

                        If CInt(.Guilde.Percepteur.Vague) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB457")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "rocher"

                        If CInt(.Guilde.Percepteur.Rocher) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB458")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "mot soignant"

                        If CInt(.Guilde.Percepteur.MotSoignant) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB459")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "desenvoutement"

                        If CInt(.Guilde.Percepteur.Desenvoutement) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB460")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "compulsion de masse"

                        If CInt(.Guilde.Percepteur.CompulsionDeMasse) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB461")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                    Case "destabilisation"

                        If CInt(.Guilde.Percepteur.Destabilisation) < 5 Then

                            If CInt(.Guilde.Percepteur.ResteARepartir) >= 5 Then

                                .BloqueGuilde.Reset()

                                .Send("gB462")

                                .BloqueGuilde.WaitOne(15000)

                            End If

                        End If

                End Select

            Next

            Return .BloqueGuilde.WaitOne(1000)

        End With

    End Function

    Public Function PoserPercepteur(ByVal index As String) As Boolean

        With Comptes(index)

            If .Personnage.Kamas >= CInt(.Guilde.Percepteur.CoûtPourPoserPercepteur) Then

                .BloqueGuilde.Reset()

                .Send("gH")

                Return .BloqueGuilde.WaitOne(15000)

            End If

        End With

    End Function

    Public Function RetirerPercepteur(ByVal index As String) As Boolean

        With Comptes(index)

            .BloqueGuilde.Reset()

            For Each pair As ClassEntite In .Map.Entite.Values

                If pair.Classe = "-6" Then

                    .Send("gF" & pair.IDUnique)

                    Exit For

                End If

            Next

            Return .BloqueGuilde.WaitOne(15000)

        End With

    End Function

    Public Function ReleverPercepteur(ByVal index As String) As Boolean

        With Comptes(index)

            .BloqueGuilde.Reset()

            For Each pair As ClassEntite In .Map.Entite.Values

                If pair.Classe = "-6" Then

                    .Send("ER8|-88" & pair.IDUnique)

                    Exit For

                End If

            Next

            Return .BloqueGuilde.WaitOne(15000)

        End With

    End Function

#End Region

#Region "Percepteurs"

#End Region

#Region "Enclos"

    Public Function EnclosTeleporter(ByVal index As Integer, ByVal enclos As String) As Boolean

        With Comptes(index)

            .BloqueGuilde.Reset()

            .Send("gf" & enclos)

            Return .BloqueGuilde.Set()

        End With

    End Function

#End Region

#Region "Maisons"

    Public Function MaisonsTeleporter(ByVal index As Integer, ByVal maisons As String) As Boolean

        With Comptes(index)

            .BloqueGuilde.Reset()

            For Each pair As ClassGuildeMaison In .Guilde.Maison.Values

                If pair.Proriétaire.ToLower = maisons.ToLower Then

                    .Send("gh" & pair.ID)

                    Exit For

                End If

            Next

            Return .BloqueGuilde.Set()

        End With

    End Function

#End Region

End Class
