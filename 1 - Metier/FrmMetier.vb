Public Class FrmMetier

    Private index As Integer

    Public Sub New(_Index As Integer)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        index = _Index
        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Private Sub FrmMetier_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Comptes(index)

            For Each pair As CMetier In .Metier.Values

                Dim PictureMetier As New PictureBox
                PictureMetier.Size = New Size(70, 70)
                PictureMetier.SizeMode = PictureBoxSizeMode.Zoom
                PictureMetier.Name = pair.ID
                PictureMetier.Image = New Bitmap(Application.StartupPath & "\Image\Job/" & pair.Nom.ToLower & ".png")

                FlowLayoutPanel1.Controls.Add(PictureMetier)

                AddHandler PictureMetier.Click, Sub() AfficheMetier(pair.ID)

            Next

        End With

    End Sub


    Private Sub AfficheMetier(id As Integer)

        With Comptes(index)

            With .Metier(id)

                PictureBoxMetier.Image = New Bitmap(Application.StartupPath & "\Image\Job/" & .Nom.ToLower & ".png")
                LabelNom.Text = .Nom.ToUpper
                LabelNiveau.Text = "Niveau : " & .Niveau
                ProgressBarExperience.Minimum = .ExperienceMinimum
                ProgressBarExperience.Maximum = .ExperienceMaximum
                ProgressBarExperience.Value = .ExperienceActuelle

                CheckBoxPayant.Checked = .Payant
                CheckBoxGratuitEchec.Checked = .GratuitSurEchec
                CheckBoxFournitPasRessource.Checked = .NeFournitAucuneRessource

                NumericUpDownRessources.Value = If(.NombreIngredientMinimum < 2, 2, .NombreIngredientMinimum)

                Select Case .ModePublic

                    Case True

                        PictureBoxPublicMode.Image = New Bitmap(Application.StartupPath & "\Image/Yes.png")
                        ButtonActiver.Text = "Activé"
                        ButtonActiver.ForeColor = Color.Green

                    Case False

                        PictureBoxPublicMode.Image = New Bitmap(Application.StartupPath & "\Image/No.png")
                        ButtonActiver.Text = "Désactivé"
                        ButtonActiver.ForeColor = Color.Red

                End Select

                ListViewSkills.Items.Clear()

                For Each pair As CMetierAtelierRessource In .AtelierRessource.Values

                    With ListViewSkills

                        .Items.Add(New ListViewItem(pair.Nom))

                        With .Items(.Items.Count - 1)

                            .SubItems.Add(pair.Action)

                            If pair.TempsReussite <= 100 Then

                                .SubItems.Add(pair.NombreCaseRecolteMinimum & " cases (" & pair.TempsReussite & "%)")

                            Else

                                .SubItems.Add(pair.NombreCaseRecolteMinimum & " a " & pair.NombreCaseRecolteMaximum & " (temps : " & pair.TempsReussite & ")")

                            End If

                        End With

                    End With

                Next

            End With


        End With

    End Sub

End Class