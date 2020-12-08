Module MdlCaractéristique

    Sub GiCaractéristique(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                'As 93821075 ,92071000  ,95886000   |165888|10                                 |8                      |0~0,0,0,0,0,0|793       ,793        |10000         ,10000          |439       |100        |6      ,2            ,0      ,0        ,8       |3      ,0            ,0      ,0        ,3       |0         ,-15             ,0         ,0           |0,248,0,0|220,137,0,0|0,0,0,0|1,30,0,0|158,250,0,0 |0,0,0,0|1,0,0,0|0,0,0,0|0,0,0,0         |0,0,0,0 |0,0,0,0 |0,7,0,0|0,0,0,0      |0,0,0,0       |0,0,0,0        |0,5,0,0|0,0,0,0|55,34,0,0|55,34,0,0|0,4,0,0               |0,0,0,0                |0,0,0,0                   |0,0,0,0                    |0,5,0,0              |0,1,0,0               |0,0,0,0                  |0,0,0,0                   |0,10,0,0           |0,2,0,0             |0,0,0,0                |0,0,0,0                 |0,4,0,0            |0,0,0,0             |0,0,0,0                |0,0,0,0                 |0,3,0,0            |0,0,0,0             |0,0,0,0                |0,0,0,0                 |19
                'As XP Actuel,Xp Minimum,XP Maximum |Kamas |Capital Caractéristiques disponible|Capital Sort disponible|Inconnu      |Pdv_Actuel,PDV_Maximum|Energie_Actuel,Energie_Maximum|Initiative|Prospection|PA_Base,PA_Equipement,PA_Dons,PA_Booste,PA_Total|PM_Base,PM_Equipement,PM_Dons,PM_Booste,PM_Total|Force_Base,Force_Equipement,Force_Dons,Force_Booste|Vitalité |Sagesse    |Chance |Agilité |Intelligence|PO     |Invoc  |Dommage|Dommage Physique|Maîtrise|%Dommage|Soin   |Dommage_Piège|%Dommage_Piège|Renvoie dommage|CC     |EC     |Esq PA   | Esq PM  |Résistance_Neutre_Fixe|%Résistance_Neutre_Fixe|pvp_Résistance_Neutre_Fixe|pvp_%Résistance_Neutre_Fixe|Résistance_Terre_Fixe|%Résistance_Terre_Fixe|pvp_Résistance_Terre_Fixe|pvp_%Résistance_Terre_Fixe|Résistance_Eau_Fixe|%Résistance_Eau_Fixe|pvp_Résistance_Eau_Fixe|pvp_%Résistance_Eau_Fixe|Résistance_Air_Fixe|%Résistance_Air_Fixe|pvp_Résistance_Air_Fixe|pvp_%Résistance_Air_Fixe|Résistance_Feu_Fixe|%Résistance_Feu_Fixe|pvp_Résistance_Feu_Fixe|pvp_%Résistance_Feu_Fixe|Inconnu

                'data reçu :
                'AsXp_Actuel,XP_Minimum,Xp_Maximum| = 0
                'Kamas| = 1
                'Capital Caractéristiques disponible| = 2
                'Capital Sort disponible| = 3
                '0~0,0,0,0,0,0| = 4 (Inconnu)
                'Pdv_Actuel,PDV_Maximum| = 5
                'Energie_Actuel,Energie_Maximum| = 6
                'Initiative_Actuel| = 7
                'Prospection_Actuel| = 8

                'PA_Base,PA_Equipement,PA_Dons,PA_Booste,PA_Total| = 9
                'PM_Base,PM_Equipement,PM_Dons,PM_Booste,PM_Total| = 10

                'Force_Base,Force_Equipement,Force_Dons,Force_Booste| = 11
                'Vitalité_Base,Vitalité_Equipement,Vitalité_Dons,Vitalité_Booste| = 12
                'Sagesse_Base,Sagesse_Equipement,Sagesse_Dons,Sagesse_Booste| = 13
                'Chance_Base,Chance_Equipement,Chance_Dons,Chance_Booste| = 14
                'Agilité_Base,Agilité_Equipement,Agilité_Dons,Agilité_Booste| = 15
                'Intelligence_Base,Intelligence_Equipement,Intelligence_Dons,Intelligence_Booste| = 16

                'PO_Base,PO_Equipement,PO_Dons,PO_Booste| = 17
                'Invocation_Base,Invocation_Equipement,Invocation_Dons,Invocation_Booste| = 18
                'Dommage_Base,Dommage_Equipement,Dommage_Dons,Dommage_Booste| = 19
                'Dommage_Physique_Base,Dommage_Physique_Equipement,Dommage_Physique_Dons,Dommage_Physique_Booste| = 20
                'Maîtrise_Base,Maîtrise_Equipement,Maîtrise_Dons,Maîtrise_Booste| = 21
                '%Dommage_Base,%Dommage_Equipement,%Dommage_Dons,%Dommage_Booste| = 22
                'Soin_Base,Soin_Equipement,Soin_Dons,Soin_Booste| = 23
                'Dommage_Piège_Base,Dommage_Piège_Equipement,Dommage_Piège_Dons,Dommage_Piège_Booste| = 24
                '%Dommage_Piège_Base,%Dommage_Piège_Equipement,%Dommage_Piège_Dons,%Dommage_Piège_Booste| = 25
                'Renvoie_Dommage_Base,Renvoie_Dommage_Equipement,Renvoie_Dommage_Dons,Renvoie_Dommage_Booste| = 26

                'Coups_Critiques_Base,Coups_Critiques_Equipement,Coups_Critiques_Dons,Coups_Critiques_Booste| = 27
                'Echec_Critique_Base,Echec_Critique_Equipement,Echec_Critique_Dons,Echec_Critique_Booste| = 28

                'Esquive_PA_Base,Esquive_PA_Equipement,Esquive_PA_Dons,Esquive_PA_Booste| = 29
                'Esquive_PM_Base,Esquive_PM_Equipement,Esquive_PM_Dons,Esquive_PM_Booste| = 30

                'Résistance_Neutre_Fixe_Base,Résistance_Neutre_Fixe_Equipement,Résistance_Neutre_Fixe_Dons,Résistance_Neutre_Fixe_Booste| = 31
                '%Résistance_Neutre_Fixe_Base,%Résistance_Neutre_Fixe_Equipement,%Résistance_Neutre_Fixe_Dons,%Résistance_Neutre_Fixe_Booste| = 32
                'Résistance_Neutre_Fixe_PVP_Base,Résistance_Neutre_Fixe_PVP_Equipement,Résistance_Neutre_Fixe_PVP_Dons,Résistance_Neutre_Fixe_PVP_Booste| = 33
                '%Résistance_Neutre_Fixe_PVP_Base,%Résistance_Neutre_Fixe_PVP_Equipement,%Résistance_Neutre_Fixe_PVP_Dons,%Résistance_Neutre_Fixe_PVP_Booste| = 34

                'Résistance_Terre_Fixe_Base,Résistance_Terre_Fixe_Equipement,Résistance_Terre_Fixe_Dons,Résistance_Terre_Fixe_Booste| = 35
                '%Résistance_Terre_Fixe_Base,%Résistance_Terre_Fixe_Equipement,%Résistance_Terre_Fixe_Dons,%Résistance_Terre_Fixe_Booste| = 36
                'Résistance_Terre_Fixe_PVP_Base,Résistance_Terre_Fixe_PVP_Equipement,Résistance_Terre_Fixe_PVP_Dons,Résistance_Terre_Fixe_PVP_Booste| = 37
                '%Résistance_Terre_Fixe_PVP_Base,%Résistance_Terre_Fixe_PVP_Equipement,%Résistance_Terre_Fixe_PVP_Dons,%Résistance_Terre_Fixe_PVP_Booste| = 38

                'Résistance_Eau_Fixe_Base,Résistance_Eau_Fixe_Equipement,Résistance_Eau_Fixe_Dons,Résistance_Eau_Fixe_Booste| = 39
                '%Résistance_Eau_Fixe_Base,%Résistance_Eau_Fixe_Equipement,%Résistance_Eau_Fixe_Dons,%Résistance_Eau_Fixe_Booste| = 40
                'Résistance_Eau_Fixe_PVP_Base,Résistance_Eau_Fixe_PVP_Equipement,Résistance_Eau_Fixe_PVP_Dons,Résistance_Eau_Fixe_PVP_Booste| = 41
                '%Résistance_Eau_Fixe_PVP_Base,%Résistance_Eau_Fixe_PVP_Equipement,%Résistance_Eau_Fixe_PVP_Dons,%Résistance_Eau_Fixe_PVP_Booste| = 42

                'Résistance_Air_Fixe_Base,Résistance_Air_Fixe_Equipement,Résistance_Air_Fixe_Dons,Résistance_Air_Fixe_Booste| = 43
                '%Résistance_Air_Fixe_Base,%Résistance_Air_Fixe_Equipement,%Résistance_Air_Fixe_Dons,%Résistance_Air_Fixe_Booste| = 44
                'Résistance_Air_Fixe_PVP_Base,Résistance_Air_Fixe_PVP_Equipement,Résistance_Air_Fixe_PVP_Dons,Résistance_Air_Fixe_PVP_Booste| = 45
                '%Résistance_Air_Fixe_PVP_Base,%Résistance_Air_Fixe_PVP_Equipement,%Résistance_Air_Fixe_PVP_Dons,%Résistance_Air_Fixe_PVP_Booste| = 46

                'Résistance_Feu_Fixe_Base,Résistance_Feu_Fixe_Equipement,Résistance_Feu_Fixe_Dons,Résistance_Feu_Fixe_Booste| = 47
                '%Résistance_Feu_Fixe_Base,%Résistance_Feu_Fixe_Equipement,%Résistance_Feu_Fixe_Dons,%Résistance_Feu_Fixe_Booste| = 48
                'Résistance_Feu_Fixe_PVP_Base,Résistance_Feu_Fixe_PVP_Equipement,Résistance_Feu_Fixe_PVP_Dons,Résistance_Feu_Fixe_PVP_Booste| = 49
                '%Résistance_Feu_Fixe_PVP_Base,%Résistance_Feu_Fixe_PVP_Equipement,%Résistance_Feu_Fixe_PVP_Dons,%Résistance_Feu_Fixe_PVP_Booste| = 50

                '73 = 51 (Inconnu)

                data = Mid(data, 3)

                Dim separateData As String() = Split(data, "|")

                With .Personnage

                    'Kamas
                    .Kamas = separateData(1)

                    'Capital Caractéristique
                    .CapitalCaractéristique = separateData(2)

                    'Capital Sort
                    .CapitalSort = separateData(3)

                    ' XP 26980    , 25200   , 32600
                    ' XP Actuelle , Minimum , Maximum
                    Dim separate As String() = Split(separateData(0), ",")

                    With .Expérience

                        .Minimum = separate(1)
                        .Maximum = separate(2)
                        .Actuelle = separate(0)
                        .Pourcentage = (separate(0) - separate(1)) / (separate(2) - separate(1)) * 100

                    End With

                    'Point de vie Actuel
                    separate = Split(separateData(5), ",")

                    '793      , 793
                    'Actuelle , Maximum
                    With .Vitalité

                        .Maximum = separate(1)
                        .Actuelle = If(separate(0) < 0, 0, separate(0))
                        .Pourcentage = If(separate(0) < 0, 0, separate(0) / separate(1) * 100)

                    End With

                    'Energie
                    separate = Split(separateData(6), ",")

                    '8956     , 10000
                    'Actuelle , Maximum
                    With .Energie

                        .Maximum = separate(1)
                        .Actuelle = separate(0)
                        .Pourcentage = If(separate(0) < 0, 0, separate(0) / separate(1) * 100)

                    End With

                    Dim nomCaractéristique As String() = {"initiative", "prospection", "pa", "pm", "force", "vitaliter",
                            "sagesse", "chance", "agiliter", "intelligence", "po", "creature invocable", "dommage", "dommage physique", "maitrise arme",
                            "dommage pr", "soin", "piege", "piege pr", "renvoi dommage", "coup critique", "echec critique", "esquive pa", "esquive pm",
                            "resistance neutre pvm", "resistance neutre pvm pr", "resistance neutre pvp", "resistance neutre pvp pr",
                            "resistance terre pvm", "resistance terre pvm pr", "resistance terre pvp", "resistance terre pvp pr",
                            "resistance eau pvm", "resistance eau pvm pr", "resistance eau pvp", "resistance eau pvp pr",
                            "resistance air pvm", "resistance air pvm pr", "resistance air pvp", "resistance air pvp pr",
                            "resistance feu pvm", "resistance feu pvm pr", "resistance feu pvp", "resistance feu pvp pr"}

                    For i = 0 To 43

                        separate = Split(separateData(7 + i), ",")

                        '55   , 72         , 60   , 60
                        'Base , Equipement , Dons , Booste

                        With .Caractéristique(nomCaractéristique(i))

                            .Base = separate(0)
                            .Equipement = If(separate.Count > 1, separate(1), "0")
                            .Dons = If(separate.Count > 1, separate(2), "0")
                            .Boost = If(separate.Count > 1, separate(3), "0")

                            Select Case separate.Count

                                Case > 3

                                    .Total = CInt(separate(0)) + CInt(separate(1)) + CInt(separate(2)) + CInt(separate(3))

                                Case Else 'Si unique, genre initiative + prospection.

                                    .Total = separate(0)

                            End Select

                        End With

                    Next

                    separate = Split(separateData(5), ",")

                    .Régénération = CInt(separate(0)) / CInt(separate(1)) * 100

                End With

                If .MITM = False Then

                    .Send("BD") 'Permet d'avoir 'BD649|6|6' = la date.

                End If

                .BloqueCaracteristique.Set()

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "[GiCaractéristique]", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiPods(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' Ow 750         | 3353
                ' Ow Pods actuel | Pods Max

                data = Mid(data, 3)

                Dim separateData As String() = Split(data, "|")

                With .Personnage.Pods

                    .Maximum = separateData(1)
                    .Actuelle = separateData(0)
                    .Pourcentage = (separateData(0) / separateData(1)) * 100

                End With

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiPods", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiRégénérationSeconde(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' ILS 2000
                ' ILS Temps à attendre pour 1 pdv

                EcritureMessage(index, "(Dofus)", "Votre personnage récupére 1 point de vie toutes les " & Mid(data, 4, 1) & " seconde(s).", Color.Green)

                With .FrmUser

                    .TimerRegeneration.Enabled = False
                    .TimerRegeneration.Interval = Mid(data, 4)
                    .TimerRegeneration.Enabled = True

                End With

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiRégénérationSeconde", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiNiveauUp(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' AN 2
                ' AN Niveau

                EcritureMessage(index, "[Dofus]", "Tu passes niveau " & Mid(data, 3) & vbCrLf & "Tu gagnes 5 points pour faire évoluer tes caractéristiques et 1 point pour tes sorts.", Color.Green)

                .Personnage.Niveau = Mid(data, 3)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiNiveauUp", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiPdvRestauré(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' ILF 1
                ' ILF Nbr de pdv récupèré

                EcritureMessage(index, "(Dofus)", "Tu as retrouvé " & Mid(data, 4) & " points de vie.", Color.Green)

                With .Personnage.Vitalité

                    Dim Vitalité As Integer = .Actuelle + CInt(Mid(data, 4))

                    If Vitalité > .Maximum Then

                        .Actuelle = .Maximum

                    Else

                        .Actuelle = Vitalité

                    End If

                End With

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiPdvRestauré", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

End Module
