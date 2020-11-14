Public Class FrmSupprimerCompte
    Private Sub FrmSupprimerCompte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'Je supprime tout se qui se trouve dans la listbox
            ListBoxCompte.Items.Clear()

            'J'ouvre et je lis le fichier.
            Dim swLecture As New IO.StreamReader(Application.StartupPath + "\Compte/Comptes.txt")

            Do Until swLecture.EndOfStream

                Dim Ligne As String = swLecture.ReadLine

                If Ligne <> "" Then

                    Dim separate() As String = Split(Ligne, " | ")

                    Dim nomDeCompte As String = Split(separate(0), " : ")(1)
                    Dim nomDuPersonnage As String = Split(separate(2), " : ")(1)

                    ListBoxCompte.Items.Add(nomDeCompte & " (" & nomDuPersonnage & ")") 'Nom de compte + Nom du personnage

                End If

            Loop

            'Puis je ferme le fichier.
            swLecture.Close()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub ButtonDeleteCompte_Click() Handles ButtonDeleteCompte.Click

        Try

            'J'ouvre et je lis le fichier.
            Dim swLecture As New IO.StreamReader(Application.StartupPath + "\Compte/Comptes.txt")

            Dim ligneFinal As String = ""

            Do Until swLecture.EndOfStream

                Dim Ligne As String = swLecture.ReadLine

                If Ligne <> "" Then

                    Dim separate() As String = Split(Ligne, " | ")

                    Dim nomDeCompte As String = Split(separate(0), " : ")(1)
                    Dim nomDuPersonnage As String = Split(separate(2), " : ")(1)

                    'Si le compte n'est pas sélectionné, ça indique qu'il ne doit pas être supprimé, donc je le re écrit dans le fichier.
                    If Not ListBoxCompte.SelectedItems.Contains(nomDeCompte & " (" & nomDuPersonnage & ")") Then

                        ligneFinal &= Ligne & vbCrLf

                    Else

                        'Vue qu'il est sélectionné, donc il doit être supprimé, je ne le re écrit pas dans le fichier et je supprime aussi le fichier "option" du compte.
                        If IO.File.Exists(Application.StartupPath + "\Compte\Options\" & nomDeCompte & "_" & nomDuPersonnage & ".txt") Then

                            My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\Compte\Options\" & nomDeCompte & "_" & nomDuPersonnage & ".txt")

                        End If

                    End If

                End If

            Loop

            'Puis je ferme le fichier.
            swLecture.Close()

            'Puis je réecrit le fichier sans le(s) compte(s) sélectionné(s)
            Dim swEcriture As New IO.StreamWriter(Application.StartupPath + "\Compte/Comptes.txt")

            swEcriture.Write(ligneFinal)

            swEcriture.Close()

            FrmSupprimerCompte_Load(Nothing, Nothing)

        Catch ex As Exception

            ErreurFichier(0, "Unknow", "ButtonDeleteCompte", ex.Message)

        End Try

    End Sub

End Class