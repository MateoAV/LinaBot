
Module mdlGuilde

#Region "Guilde Base"

    Public Sub GiGuildeInformation(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' gSLinaculerBot|a|0|i|9zldr|0 = La plupart à part le nom = Inconnu

                Dim separateData As String() = Split(data, "|")

                .Guilde.EnGuilde = 1

                If .Guilde.Invitation Then

                    .Guilde.Invitation = False

                    EcritureMessage(index, "[Dofus]", "Tu viens d'intégrer la guilde " & Mid(separateData(0), 3), Color.DarkViolet)

                End If

                .BloqueGuilde.Set()

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiGuildeInformation", data & vbCrLf & ex.Message)

            End Try


        End With

    End Sub

    Public Sub GiGuildeExp(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' gIG 0 | 5      | 28000   | 30271        | 48000
            ' gIG ? | Niveau | exp min | exp actuelle | exp max

            Dim separate As String() = Split(data, "|")

            With .Guilde

                .Niveau = separate(1)
                .ExpMinimum = separate(2)
                .ExpActuelle = separate(3)
                .ExpMaximum = separate(4)

            End With

            .BloqueGuilde.Set()

        End With

    End Sub

    Public Sub GiGuildeInvitationEnCours(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' gJR Linaculer
            ' gJR Nom

            .Guilde.Invitation = True

            .Guilde.JoueurQuiInvite = .Personnage.ID

            EcritureMessage(index, "[Dofus]", "Tu invites " & Mid(data, 4) & " à rejoindre ta guilde...", Color.Green)

            .BloqueGuilde.Set()

        End With

    End Sub

    Public Sub GiGuildeInvitationEnCoursInformation(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' gJr 2594870 | Linaculer | Attack on titan
            ' gJr ID      | Nom       | Nom Guilde

            Dim separateData As String() = Split(Mid(data, 4), "|")

            .Guilde.Invitation = True

            .Guilde.JoueurQuiInvite = separateData(0)

            EcritureMessage(index, "[Dofus]", separateData(1) & " t'invite à rejoindre sa guilde (" & separateData(2) & ") acceptes-tu ?", Color.Green)

            .BloqueGuilde.Set()

        End With

    End Sub

    Public Sub GiGuildeInvitationEnCoursRefuse(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' gJE 1234567
            ' gJE id

            .Guilde.Invitation = False
            .Guilde.JoueurQuiInvite = ""
            .Guilde.JoueurQuiEstInvite = ""

            EcritureMessage(index, "[Dofus]", Mid(data, 4) & " refuse d'intégrer ta guilde.", Color.Red)

            .BloqueGuilde.Set()

        End With

    End Sub

    Public Sub GiGuildeInvitationEnCoursAccepte(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' gJKa Linaculer
            ' gJKa nom

            .Guilde.Invitation = False
            .Guilde.JoueurQuiEstInvite = ""
            .Guilde.JoueurQuiInvite = ""

            EcritureMessage(index, "[Dofus]", Mid(data, 4) & " refuse d'intégrer ta guilde.", Color.Red)

            .BloqueGuilde.Set()

        End With

    End Sub

#End Region

#Region "Guilde Membres"

    Public Sub GiGuildeJoueurExclut(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Dim separateData As String() = Split(Mid(data, 4), "|")

            If separateData(0).ToLower = .Personnage.NomDuPersonnage.ToLower Then

                EcritureMessage(index, "[Dofus]", "Tu as banni " & separateData(1) & " de ta guilde.", Color.Green)

            Else

                EcritureMessage(index, "[Dofus]", "", Color.Green)

            End If

            .BloqueGuilde.Set()

        End With

    End Sub

    Public Sub GuildeMembresAjoute(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' gIM+ 1234567  ; Linaculer ; 60     ; 81     ; 2    ; 0        ; 0   ; 29694 ; 1        ; 0          ; 0                  | Next
            ' gIM+ IdUnique ; Nom       ; Niveau ; Classe ; Rang ; XpGagnée , %Xp ; Droit ; Connecté ; Alignement ; Dernière connexion | 
            Dim rangActuel() As String = {"A l'essai", "Meneur", "Bras Droit", "Trésorier", "Protecteur", "Artisan", "Réserviste", "Gardien", "Eclaireur", "Espion", "Diplomate", "Secrétaire",
            "Tueur de familiers", "Braconnier", "Chercheur de trésor", "Voleur", "Initié", "Assassin", "Gouverneur", "Muse", "Conseiller", "Elu", "Guide", "Mentor", "Recruteur",
            "Eleveur", "Marchand", "Apprenti", "Bourreau", "Mascotte", "Pénitent", "Tueur de Percepteurs", "Déserteur", "Traître", "Boulet", "Larbin", "A l'essai"}

            With .Guilde

                .Membre.Clear()

                Dim separateData As String() = Split(data, "|")

                For i = 0 To separateData.Count - 1

                    Dim separate As String() = Split(separateData(i), ";")

                    Dim NewJoueur As New ClassGuildeJoueur

                    With NewJoueur

                        .IdUnique = separate(0)
                        .Nom = separate(1)
                        .Niveau = separate(2)
                        .Classe = GuildeClasseAlignement(separate(3))
                        .Rang = rangActuel(separate(4))
                        .RangChiffre = separate(4)
                        .XpGagnée = separate(5)
                        .PrXp = separate(6)
                        .Connecté = separate(8)
                        .Alignement = GuildeClasseAlignement(separate(9))
                        .DernièreConnection = If(separate(10) = -1, "Dernière connexion il y a moins d'un jour", "")

                        Dim NewDroit As New ClassGuildeDroit

                        NewDroit = GuildeDroits(index, separate(1), separate(7))

                        .Droit = NewDroit
                        .DroitChiffre = separate(7)

                    End With

                    .Membre.Add(separate(1), NewJoueur)

                Next

            End With

            .BloqueGuilde.Set()

        End With

    End Sub

    Private Function GuildeClasseAlignement(ByVal Valeur As Integer) As String

        Select Case Valeur
            Case 0 : Return "Neutre" 'Neutre
            Case 1 : Return "Brakmarien"
            Case 2 : Return "Bontarien"
            Case 10, 11 : Return "Feca"
            Case 20, 21 : Return "Osamodas"
            Case 30, 31 : Return "Enutrof"
            Case 40, 41 : Return "Sram"
            Case 50, 51 : Return "Xelor"
            Case 60, 61 : Return "Ecaflip"
            Case 70, 71 : Return "Eniripsa"
            Case 80, 81 : Return "Iop"
            Case 90, 91 : Return "Cra"
            Case 100, 101 : Return "Sadida"
            Case 110, 111 : Return "Sacrieur"
            Case 120, 121 : Return "Pandawa"
            Case Else
                Return Valeur
        End Select
    End Function

    Private Function GuildeDroits(ByVal Index As Integer, ByVal Name_Joueur As String, ByVal Information As Integer) As ClassGuildeDroit

        With Comptes(Index)

            Dim newRights As New ClassGuildeDroit
            Dim Valeur() As Integer = {16384, 8192, 4096, 512, 256, 128, 64, 32, 16, 8, 4, 2}

            With newRights

                If Information = 1 Then

                    .GererLesBoosts = True
                    .GererLesDroits = True
                    .InviterDeNouveauxMembres = True
                    .Bannir = True
                    .GererLesRepartitionsXP = True
                    .GererSaRepartitionXP = True
                    .GererLesRangs = True
                    .PoserUnPercepteur = True
                    .CollecterSurUnPercepteur = True
                    .UtiliserLesEnclos = True
                    .AmenagerLesEnclos = True
                    .GererLesMonturesDesAutresMembres = True

                Else

                    For i = 0 To 11

                        If Information >= Valeur(i) Then

                            Select Case Information

                                Case 16384

                                    .GererLesBoosts = True

                                Case 8192

                                    .GererLesDroits = True

                                Case 4096

                                    .InviterDeNouveauxMembres = True

                                Case 512

                                    .Bannir = True

                                Case 256

                                    .GererLesRepartitionsXP = True

                                Case 128

                                    .GererSaRepartitionXP = True

                                Case 64

                                    .GererLesRangs = True

                                Case 32

                                    .PoserUnPercepteur = True

                                Case 16

                                    .CollecterSurUnPercepteur = True

                                Case 8

                                    .UtiliserLesEnclos = True

                                Case 4

                                    .AmenagerLesEnclos = True

                                Case 2

                                    .GererLesMonturesDesAutresMembres = True

                            End Select

                            Information -= Valeur(i)

                        End If

                    Next

                End If

            End With

            Return newRights

        End With

    End Function

    Public Sub GuildeMembreSupprime(ByVal index As Integer, ByVal data As Integer)

        With Comptes(index)

            Dim nom As String = Mid(data, 5)

            If .Guilde.Membre.ContainsKey(nom) Then

                .Guilde.Membre.Remove(nom)

            End If

            .BloqueGuilde.Set()

        End With

    End Sub

#End Region

#Region "Guilde Personnalisation"

    Public Sub GiGuildePersonnalisation(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' gIB1 |0|200|2|1000|100|0|1|5|1020|462;0|461;0|460;0|459;0|458;0|457;0|456;0|455;0|454;0|453;0|452;0|451;0
            ' gIB1 |                   ?

            Dim NewGuildePercepteur As New ClassGuildePercepteur

            Dim separateData As String() = Split(data, "|")

            With NewGuildePercepteur

                .NombreDePercepteur = separateData(0)
                .ActuellementPercepteur = separateData(1)
                .PointsDeVie = separateData(2)
                .BonusAuxDommages = separateData(3)
                .Pods = separateData(4)
                .Prospection = separateData(5)
                .Sagesse = separateData(6)

                .ResteARepartir = separateData(8)
                .CoûtPourPoserPercepteur = separateData(9)

                .ArmureAqueuse = Split(separateData(21), ";")(0)
                .ArmureIncandescente = Split(separateData(20), ";")(0)
                .ArmureTerrestre = Split(separateData(19), ";")(0)
                .ArmureVenteuse = Split(separateData(18), ";")(0)
                .Flamme = Split(separateData(17), ";")(0)
                .Cyclone = Split(separateData(16), ";")(0)
                .Vague = Split(separateData(15), ";")(0)
                .Rocher = Split(separateData(14), ";")(0)
                .MotSoignant = Split(separateData(13), ";")(0)
                .Desenvoutement = Split(separateData(12), ";")(0)
                .CompulsionDeMasse = Split(separateData(11), ";")(0)
                .Destabilisation = Split(separateData(10), ";")(0)

            End With

            .Guilde.Percepteur = NewGuildePercepteur

            .BloqueGuilde.Set()

        End With

    End Sub

#End Region

#Region "Guilde Percepteurs"

    Public Sub GiGuildePercepteurPosee(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            'gTS12,28|8840|-15|6|Name
            '12,28 = ?

            Dim separateData As String() = Split(data, "|")

            EcritureMessage(index, "[Guilde - Information]", "Le percepteur [Name] a été posé en (" & separateData(2) & ", " & separateData(3) & ") par " & separateData(4), Color.DarkViolet)

            .BloqueGuilde.Set()

        End With
    End Sub

    Public Sub GiGuildePercepteurRetire(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            'gTRm,f|8858|-17|7|Name

            Dim separateData As String() = Split(data, "|")

            EcritureMessage(index, "[Guilde - Information]", "Le percepteur [Name] en (" & separateData(2) & ", " & separateData(3) & ") a été retiré par " & separateData(4), Color.DarkViolet)

            .BloqueGuilde.Set()

        End With

    End Sub

#End Region

#Region "Guilde Enclos"

    Public Sub GiGuildeEnclos(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' gIF3 | 9999 ; 2 ; 2 ; 
            ' gIF3 | 9999 ; 2 ; 2 ; 

            .Guilde.Enclos.Clear()

            Dim separateData As String() = Split(data, "|")

            For i = 1 To separateData.Count - 1

                Dim separate As String() = Split(separateData(i), ";")

                Dim newEnclos As New ClassGuildeEnclos

                With newEnclos

                    .MapID = separate(0)
                    .Position = VarMap(separate(0))
                    .DragodindeActuelle = separate(1)
                    .DragodindeActuelle = separate(2)

                End With

                .Guilde.Enclos.Add(separate(0), newEnclos)

            Next

            .BloqueGuilde.Set()

        End With

    End Sub

#End Region

#Region "Guilde Maisons"

    Public Sub GiGuildeMaison(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            'gIH+ 599 ; Linaculer   ; -20,30 ;            ; 499    |
            '     ID  ; proriétaire ; Pos    ; compétence ; Droits | Next

            .Guilde.Maison.Clear()

            data = Mid(data, 5)

            Dim separateData As String() = Split(data, "|")

            For i = 0 To separateData.Count - 1

                Dim separate As String() = Split(separateData(i), ";")

                Dim Valeur As Integer() = {256, 128, 64, 32, 16, 8, 4, 2, 1}

                Dim newMaison As New ClassGuildeMaison

                With newMaison

                    For a = 0 To 8

                        If CInt(separate(4)) >= Valeur(a) Then

                            Select Case Valeur(a)

                                Case 256 '256 =  Repos autorisé aux membres de la guilde dans cette maison

                                    .ReposAutoriser = True

                                Case 128 '128 = Téléportation autorisée vers cette maison

                                    .TeleportationAutoriser = True

                                Case 64 '64 = Accès aux coffres interdit aux non-membres de la guilde

                                    .AccesCoffresInterditNonMembreGuilde = True

                                Case 32 '32 = Accès aux coffres autorisé aux membres de la guilde

                                    .AccesCoffresAutoriseMembreGuilde = True

                                Case 16 '16 = Accès interdit aux non-membres de la guilde

                                    .AccesInterditNonMembreGuilde = True

                                Case 8 '8 = Accès autorisé aux membres de la guilde

                                    .AccesAutoriserMembreGuilde = True

                                Case 4 '4 = Blason Visible pour tout le monde

                                    .BlasonVisiblePourToutMonde = True

                                Case 2 '2 = Blason Visible pour la guilde

                                    .BlasonVisiblePourGuilde = True

                                Case 1 '1 = Maison Visible pour la guilde.

                                    .MaisonVisiblePourGuilde = True

                            End Select

                            separate(4) = CInt(separate(4)) - Valeur(a)

                        End If

                    Next

                    .ID = separate(0)
                    .Proriétaire = separate(1)
                    .Position = separate(2)
                    .Compétence = separate(3)

                End With

                .Guilde.Maison.Add(separate(1), newMaison)

            Next

            .BloqueGuilde.Set()

        End With

    End Sub

#End Region

End Module
