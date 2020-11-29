Public Class FrmCaracteristique

    Public index As Integer
    Private Delegate Sub dlg()

    'Gestion de la form à l'ouverture et fermeture
    Private Sub FrmCaracteristique_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Comptes(index)

            If .Connecté Then

                LabelNomPersonnage.Text = .Personnage.NomDuPersonnage
                LabelNiveau.Text = "Niveau " & .Personnage.Niveau
                LabelPointVie.Text = .Personnage.Vitalité.Actuelle & " / " & .Personnage.Vitalité.Maximum
                LabelPA.Text = .Personnage.Caractéristique("pa").Total
                LabelPM.Text = .Personnage.Caractéristique("pm").Total
                LabelInitiative.Text = .Personnage.Caractéristique("initiative").Total
                LabelProspection.Text = .Personnage.Caractéristique("prospection").Total

                LabelVitaliter.Text = .Personnage.Caractéristique("vitaliter").Base & " (+" & .Personnage.Caractéristique("vitaliter").Equipement & ")"
                LabelSagesse.Text = .Personnage.Caractéristique("sagesse").Base & " (+" & .Personnage.Caractéristique("sagesse").Equipement & ")"
                LabelForce.Text = .Personnage.Caractéristique("force").Base & " (+" & .Personnage.Caractéristique("force").Equipement & ")"
                LabelIntelligence.Text = .Personnage.Caractéristique("intelligence").Base & " (+" & .Personnage.Caractéristique("intelligence").Equipement & ")"
                LabelChance.Text = .Personnage.Caractéristique("chance").Base & " (+" & .Personnage.Caractéristique("chance").Equipement & ")"
                LabelAgiliter.Text = .Personnage.Caractéristique("agiliter").Base & " (+" & .Personnage.Caractéristique("agiliter").Equipement & ")"

                LabelCapital.Text = .Personnage.CapitalCaractéristique

                With ProgressBarEnergie

                    .Minimum = 0
                    .Maximum = Comptes(index).Personnage.Energie.Maximum
                    .Value = Comptes(index).Personnage.Energie.Actuelle
                    ToolTip1.SetToolTip(ProgressBarEnergie, Comptes(index).Personnage.Energie.Pourcentage)

                End With

                With ProgressBarExperience

                    .Minimum = Comptes(index).Personnage.Expérience.Minimum
                    .Maximum = Comptes(index).Personnage.Expérience.Maximum
                    .Value = Comptes(index).Personnage.Expérience.Actuelle
                    ToolTip1.SetToolTip(ProgressBarExperience, Comptes(index).Personnage.Expérience.Pourcentage)

                End With

                Dim compteur As Integer = 0

                For Each pair As KeyValuePair(Of String, ClassCaractéristique) In .Personnage.Caractéristique

                    With ListView_Caractéristique

                        With .Items(compteur)

                            .SubItems(1).Text = pair.Value.Base

                            .SubItems(2).Text = pair.Value.Equipement

                            .SubItems(3).Text = pair.Value.Dons

                            .SubItems(4).Text = pair.Value.Boost

                            .SubItems(5).Text = pair.Value.Total

                            'Ici pour simplifier, j'indique que la couleur du texte sera soit vert ou rouge, si le total est supérieur à 0 = vert, sinon rouge.
                            .ForeColor = If(CInt(.SubItems(5).Text) > 0, Color.Green, Color.Red)

                        End With

                    End With

                    compteur += 1

                Next

                AddHandler .Socket.Reception, AddressOf Reception

            End If

        End With

    End Sub

    Private Sub FrmCaracteristique_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        With Comptes(index)

            If .Connecté Then

                RemoveHandler .Socket.Reception, AddressOf Reception

            End If

        End With

    End Sub

    'Reception des infos
    Private Sub Reception(ByVal sender As Object, ByVal e As Socket_EventArgs)

        With Comptes(index)

            Try

                Select Case e.Message(0)

                    Case "A"

                        Select Case e.Message(1)

                            Case "N"

                                Select Case e.Message(2)

                                    Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"

                                        GiNiveauUp(index, e.Message)

                                End Select

                            Case "s"

                                GiCaracteristique(index, e.Message)

                        End Select

                    Case "I"

                        Select Case e.Message(1)

                            Case "L"

                                Select Case e.Message(2)

                                    Case "F"

                                        GiPdvRestaure(index, e.Message)

                                    Case "S"

                                        GiRegenerationSeconde(index, e.Message)

                                End Select

                        End Select

                End Select

            Catch ex As Exception
            End Try

        End With

    End Sub

    Sub GiCaracteristique(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                    .FrmUser.Invoke(New dlg(Sub() GiCaracteristique(index, data)))

                Else

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

                    'Capital Caractéristique
                    LabelCapital.Text = separateData(2)

                    ' XP 26980    , 25200   , 32600
                    ' XP Actuelle , Minimum , Maximum
                    Dim separate As String() = Split(separateData(0), ",")

                    With ProgressBarExperience

                        .Minimum = separate(1)
                        .Maximum = separate(2)
                        .Value = separate(0)
                        ToolTip1.SetToolTip(ProgressBarExperience, (separate(0) - separate(1)) / (separate(2) - separate(1)) * 100)

                    End With

                    'Point de vie Actuel
                    separate = Split(separateData(5), ",")

                    '793      , 793
                    'Actuelle , Maximum
                    LabelPointVie.Text = If(separate(0) < 0, 0, separate(0)) & " / " & separate(1)

                    'Energie
                    separate = Split(separateData(6), ",")

                    '8956     , 10000
                    'Actuelle , Maximum
                    With ProgressBarEnergie

                        .Minimum = 0
                        .Maximum = separate(1)
                        .Value = separate(0)
                        ToolTip1.SetToolTip(ProgressBarEnergie, If(separate(0) < 0, 0, separate(0) / separate(1) * 100))

                    End With

                    Dim caractcout As New List(Of Integer) From {11, 12, 13, 14, 15, 16}

                    For i = 0 To 43

                        With ListView_Caractéristique

                            separate = Split(separateData(7 + i), ",")

                            With .Items(i)

                                .SubItems(1).Text = separate(0)

                                .SubItems(2).Text = If(separate.Count > 1, separate(1), "0")

                                .SubItems(3).Text = If(separate.Count > 1, separate(2), "0")

                                .SubItems(4).Text = If(separate.Count > 1, separate(3), "0")

                                Select Case separate.Count

                                    Case > 3

                                        .SubItems(5).Text = CInt(separate(0)) + CInt(separate(1)) + CInt(separate(2)) + CInt(separate(3))

                                    Case Else 'Si unique, genre initiative + prospection.

                                        .SubItems(5).Text = separate(0)

                                End Select

                                'Ici pour simplifier, j'indique que la couleur du texte sera soit vert ou rouge, si le total est supérieur à 0 = vert, sinon rouge.
                                .ForeColor = If(CInt(.SubItems(5).Text) > 0, Color.Green, Color.Red)

                            End With


                        End With

                    Next

                End With

                    LabelInitiative.Text = separateData(7)
                    LabelProspection.Text = separateData(8)

                    LabelVitaliter.Text = Split(separateData(12), ",")(0) & " (+" & Split(separateData(12), ",")(1) & ")"
                    LabelSagesse.Text = Split(separateData(13), ",")(0) & " (+" & Split(separateData(13), ",")(1) & ")"
                    LabelForce.Text = Split(separateData(11), ",")(0) & " (+" & Split(separateData(11), ",")(1) & ")"
                    LabelIntelligence.Text = Split(separateData(16), ",")(0) & " (+" & Split(separateData(16), ",")(1) & ")"
                    LabelChance.Text = Split(separateData(14), ",")(0) & " (+" & Split(separateData(14), ",")(1) & ")"
                    LabelAgiliter.Text = Split(separateData(15), ",")(0) & " (+" & Split(separateData(15), ",")(1) & ")"
                    LabelPointVie.Text = Split(separateData(5), ",")(0) & " / " & Split(separateData(5), ",")(1)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "[GiCaractéristique]", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiRegenerationSeconde(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try
                If .FrmUser.InvokeRequired Then

                    .FrmUser.Invoke(New dlg(Sub() GiRegenerationSeconde(index, data)))

                Else

                    ' ILS 2000
                    ' ILS Temps à attendre pour 1 pdv

                    TimerRegeneration.Enabled = False
                    TimerRegeneration.Interval = Mid(data, 4)
                    TimerRegeneration.Enabled = True

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiRégénérationSeconde", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiNiveauUp(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try
                If .FrmUser.InvokeRequired Then

                    .FrmUser.Invoke(New dlg(Sub() GiNiveauUp(index, data)))

                Else

                    LabelNiveau.Text = "Niveau " & Mid(data, 3)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiNiveauUp", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiPdvRestaure(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                    .FrmUser.Invoke(New dlg(Sub() GiPdvRestaure(index, data)))

                Else

                    ' ILF 1
                    ' ILF Nbr de pdv récupèré

                    Dim separate As String() = Split(LabelPointVie.Text, " / ")

                    Dim Vitaliter As String = CInt(separate(0)) + CInt(Mid(data, 4))

                    If CInt(Vitaliter) > CInt(separate(1)) Then

                        Vitaliter = separate(1)

                    End If

                    LabelPointVie.Text = Vitaliter & " / " & separate(1)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiPdvRestauré", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Private Sub TimerRegeneration_Tick(sender As Object, e As EventArgs) Handles TimerRegeneration.Tick

        With Comptes(index)

            Try

                If .Connecté AndAlso .Personnage.Vivant AndAlso .EnCombat = False Then

                    Dim separate As String() = Split(LabelPointVie.Text, " / ")

                    If CInt(separate(0)) < CInt(separate(1)) Then

                        LabelPointVie.Text = CInt(separate(0)) + 1 & " / " & separate(1)

                    End If

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

#Region "Button"

    Private Sub ButtonVitaliter_Click(sender As Object, e As EventArgs) Handles ButtonVitaliter.Click

        Comptes(index).Send("AB11")

    End Sub

    Private Sub ButtonSagesse_Click(sender As Object, e As EventArgs) Handles ButtonSagesse.Click

        Comptes(index).Send("AB12")

    End Sub

    Private Sub ButtonForce_Click(sender As Object, e As EventArgs) Handles ButtonForce.Click

        Comptes(index).Send("AB10")

    End Sub

    Private Sub ButtonIntelligence_Click(sender As Object, e As EventArgs) Handles ButtonIntelligence.Click

        Comptes(index).Send("AB15")

    End Sub

    Private Sub ButtonChance_Click(sender As Object, e As EventArgs) Handles ButtonChance.Click

        Comptes(index).Send("AB13")

    End Sub

    Private Sub ButtonAgiliter_Click(sender As Object, e As EventArgs) Handles ButtonAgiliter.Click

        Comptes(index).Send("AB14")

    End Sub

    Private Sub AddUpCaract()

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                .FrmUser.Invoke(New dlg(AddressOf AddUpCaract))

            Else

                ButtonVitaliter.Visible = False
                ButtonSagesse.Visible = False
                ButtonForce.Visible = False
                ButtonIntelligence.Visible = False
                ButtonChance.Visible = False
                ButtonAgiliter.Visible = False

                If .Personnage.ClasseSexe <> Nothing Then

                For Each pair As KeyValuePair(Of String, String()) In VarCaractéristique(VarPersonnage(CInt(.Personnage.ClasseSexe)).Nom)

                    For i = 2 To pair.Value.Count - 1

                            If .Personnage.Caractéristique(pair.Key.ToLower).Base >= CInt(Split(pair.Value(i), ">")(0)) AndAlso .Personnage.Caractéristique(pair.Key.ToLower).Base <= CInt(Split(pair.Value(i), ">")(1)) Then

                                If .Personnage.CapitalCaractéristique >= Split(pair.Value(i), ">")(2) Then

                                    Select Case pair.Key.ToLower

                                        Case "vitaliter"

                                            ButtonVitaliter.Visible = True
                                            ToolTip1.SetToolTip(ButtonVitaliter, Split(pair.Value(i), ">")(2))

                                        Case "sagesse"

                                            ButtonSagesse.Visible = True
                                            ToolTip1.SetToolTip(ButtonSagesse, Split(pair.Value(i), ">")(2))

                                        Case "intelligence"

                                            ButtonIntelligence.Visible = True
                                            ToolTip1.SetToolTip(ButtonIntelligence, Split(pair.Value(i), ">")(2))

                                        Case "force"

                                            ButtonForce.Visible = True
                                            ToolTip1.SetToolTip(ButtonForce, Split(pair.Value(i), ">")(2))

                                        Case "chance"

                                            ButtonChance.Visible = True
                                            ToolTip1.SetToolTip(ButtonChance, Split(pair.Value(i), ">")(2))

                                        Case "agiliter"

                                            ButtonAgiliter.Visible = True
                                            ToolTip1.SetToolTip(ButtonAgiliter, Split(pair.Value(i), ">")(2))

                                    End Select

                                End If

                            End If

                        Next

                Next

            End If

            End If

        End With

    End Sub

    Private Sub LabelCapital_Click(sender As Object, e As EventArgs) Handles LabelCapital.TextChanged

        AddUpCaract()

    End Sub

#End Region

End Class