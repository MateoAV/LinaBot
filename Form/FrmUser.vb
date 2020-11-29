Public Class FrmUser

    Public index As Integer


    Private Sub ConnecterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnecterToolStripMenuItem.Click

        With Comptes(index)

            .MITM = True
            .Main()

            .AppMITM = Shell(LinaBot.PathMITM & "/Dofus.exe", AppWinStyle.NormalNoFocus)

        End With

    End Sub

    Private Sub ConnecterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConnecterToolStripMenuItem1.Click

        With Comptes(index)

            .MITM = False

            Select Case .Connecté

                Case True

                    .Socket.Connexion_Game(False)

                Case False

                    Select Case .EnConnexion

                        Case True

                            .Socket_Authentification.Connexion_Game(False)

                        Case False

                            .CreateSocketAuthentification(VarServeur("Authentification").IP, VarServeur("Authentification").Port)

                    End Select

            End Select

        End With

    End Sub

    Private Sub DéconnecterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DéconnecterToolStripMenuItem1.Click, DéconnecterToolStripMenuItem.Click

        With Comptes(index)

            If .EnAuthentification Then

                .Socket_Authentification.Connexion_Game(False)

            ElseIf .Connecté Then

                .Socket.Connexion_Game(False)

            ElseIf .EnConnexion AndAlso .EnAuthentification = False Then

                .Socket.Connexion_Game(False)

            End If

        End With

    End Sub

    Private Sub TimerRegeneration_Tick(sender As Object, e As EventArgs) Handles TimerRegeneration.Tick

        With Comptes(index)

            If .EnCombat = False AndAlso .Connecté Then

                With ProgressBarVitaliter

                    If .Value + 1 < .Maximum Then

                        .Value += 1

                    End If

                    ToolTip1.SetToolTip(ProgressBarVitaliter, (.Value / .Maximum) * 100)

                End With

            End If

        End With

    End Sub

    Private Sub TimerStatut_Tick(sender As Object, e As EventArgs) Handles TimerStatut.Tick

        With Comptes(index)

            If .EnAuthentification Then

                LabelEtat.Text = "En Connexion"
                LabelEtat.ForeColor = Color.Orange

            ElseIf .EnConnexion Then

                LabelEtat.Text = "Connexion en cours..."
                LabelEtat.ForeColor = Color.Orange

            ElseIf .Connecté Then

                LabelEtat.Text = "Connecté"
                LabelEtat.ForeColor = Color.Lime

            ElseIf .Connecté = False AndAlso .EnAuthentification = False AndAlso .EnConnexion = False Then

                LabelEtat.Text = "Déconnecté"
                LabelEtat.ForeColor = Color.Red

            End If

            If .Map.EnDeplacement Then

                LabelStatut.Text = "En Déplacement"
                LabelStatut.ForeColor = Color.Cyan

            Else

                If .Connecté Then

                    LabelStatut.Text = "En Attente"
                    LabelStatut.ForeColor = Color.White

                Else

                    LabelStatut.Text = "Inconnu"
                    LabelStatut.ForeColor = Color.Red

                End If

            End If

        End With

    End Sub

#Region "Button"

    Private Sub ButtonCaracteristique_Click(sender As Object, e As EventArgs) Handles ButtonCaracteristique.Click

        Dim newCaract As New FrmCaracteristique
        newCaract.index = index
        newCaract.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim newSort As New FrmSort
        newSort.index = index
        newSort.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim newInventaire As New FrmInventaire
        newInventaire.index = index
        newInventaire.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

#End Region

End Class
