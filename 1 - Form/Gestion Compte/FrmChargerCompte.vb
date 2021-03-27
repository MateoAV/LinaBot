Public Class FrmChargerCompte
    Private Sub FrmChargerCompte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'Je supprime tout se qui se trouve dans la listbox
            ListBoxCompte.Items.Clear()

            'J'ouvre et je lis le fichier.
            Dim swLecture As New IO.StreamReader(Application.StartupPath + "\Compte/Comptes.txt")

            Do Until swLecture.EndOfStream

                Dim Ligne As String = swLecture.ReadLine

                If Ligne <> "" Then

                    'Nom de compte : Linaculer | etc....
                    Dim separate() As String = Split(Ligne, " | ")

                    Dim nomDeCompte As String = Split(separate(0), " : ")(1)
                    Dim nomDuPersonnage As String = Split(separate(2), " : ")(1)

                    ListBoxCompte.Items.Add(nomDeCompte & " (" & nomDuPersonnage & ")") 'Nom de compte + Nom du personnage

                End If

            Loop

            'Puis je ferme le fichier.
            swLecture.Close()

        Catch ex As Exception

            ErreurFichier(0, "Unknow", "LoadCompte", ex.Message)

        End Try

    End Sub

    Private Sub TextBoxGroupeNom_TextChanged(sender As Object, e As EventArgs) Handles TextBoxGroupeNom.Click

        sender.Text = ""

    End Sub

    Private Sub ButtonLoadCompte_Click() Handles ButtonLoadCompte.Click

        Dim frmGroupe As New FrmGroupe
        frmGroupe.Text = TextBoxGroupeNom.Text
        frmGroupe.MdiParent = LinaBot
        frmGroupe.Show()

        'Je lis le fichier pour obtenir les comptes.
        Dim swLecture As New IO.StreamReader(Application.StartupPath + "\Compte/Comptes.txt")

        Do Until swLecture.EndOfStream

            Dim Ligne As String = swLecture.ReadLine

            If Ligne <> "" Then

                Dim separation() As String = Split(Ligne, " | ")

                'Je regarde si l'une des sélections correspond à la ligne actuel.
                If ListBoxCompte.SelectedItems.Contains(Split(separation(0), " : ")(1) & " (" & Split(separation(2), " : ")(1) & ")") Then 'Nom de compte + Nom du personnage

                    'J'ajoute alors aux comptes la class Player.
                    Comptes.Add(New Player)

                    'Puis pour le comptes actuel je met les informations nécessaire.
                    With Comptes(Comptes.Count - 1)

                        For a = 0 To separation.Count - 1

                            Dim separateInfo As String() = Split(separation(a), " : ")

                            Select Case separateInfo(0)

                                Case "Nom de compte"

                                    .Personnage.NomDeCompte = separateInfo(1)

                                Case "Mot de passe"

                                    .Personnage.MotDePasse = separateInfo(1)

                                Case "Nom du personnage"

                                    .Personnage.NomDuPersonnage = separateInfo(1)

                                    If Not ListOfBotName.Contains(separateInfo(1).ToLower) Then

                                        ListOfBotName.Add(separateInfo(1).ToLower)

                                    End If

                                Case "Serveur"

                                    .Personnage.Serveur = separateInfo(1)

                            End Select

                        Next

                        .Index = LinaBot.CompteurCompte

                        .FrmGroupe = frmGroupe

                        Initialiser(LinaBot.CompteurCompte, .FrmGroupe)

                        LinaBot.CompteurCompte += 1

                    End With

                End If

            End If

        Loop

        swLecture.Close()

        Close()

    End Sub


End Class