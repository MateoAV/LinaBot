Public Class FrmAjouterCompte

    Private Sub FrmAjouterCompte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxChoixServeur.Items.Clear()

        For Each pair As KeyValuePair(Of String, ClassServeur) In VarServeur

            ComboBoxChoixServeur.Items.Add(pair.Key)

        Next

        ComboBoxChoixServeur.SelectedIndex = 0

    End Sub

    Private Sub TextBox_Nom_De_Compte_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNomDeCompte.Click, TextBoxMotDePasse.Click, TextBoxNomPersonnage.Click

        sender.Text = ""

    End Sub

    Private Sub ButtonAjouter_Click(sender As Object, e As EventArgs) Handles ButtonAjouter.Click

        Try

            'Je lis le fichier.
            Dim swLecture As New IO.StreamReader(Application.StartupPath + "\Compte/Comptes.txt")

            Dim ligneFinal As String = ""

            Do Until swLecture.EndOfStream

                Dim Ligne As String = swLecture.ReadLine

                If Ligne <> "" Then

                    ligneFinal &= Ligne & vbCrLf

                End If

            Loop

            'Puis je ferme le fichier.
            swLecture.Close()

            Dim monCompte As String

            monCompte = "Nom de compte : " & TextBoxNomDeCompte.Text & " | "
            monCompte &= "Mot de passe : " & TextBoxMotDePasse.Text & " | "
            monCompte &= "Nom du personnage : " & TextBoxNomPersonnage.Text & " | "
            monCompte &= "Serveur : " & ComboBoxChoixServeur.Text

            ligneFinal &= monCompte

            'J'ouvre le fichier pour y écrire se que je souhaite
            Dim swEcriture As New IO.StreamWriter(Application.StartupPath + "\Compte/Comptes.txt")

            swEcriture.Write(ligneFinal)

            'Puis je le ferme.
            swEcriture.Close()

            'Je mets les informations de base pour que se soit visible directement par l'utilisateur.
            TextBoxNomDeCompte.Text = "Nom de compte"
            TextBoxMotDePasse.Text = "Mot de passe"
            TextBoxNomPersonnage.Text = "Nom du personnage"

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try


    End Sub


End Class