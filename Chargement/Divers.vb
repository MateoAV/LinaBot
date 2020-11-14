Module Divers

    Private Delegate Sub dlgDivers()
    Private Delegate Function dlgFDivers()

    Public Sub Initialiser(ByVal index As Integer, ByVal frmGroupe As FrmGroupe)

        With Comptes(index)

            'Je donne l'index aussi dans le Panel_utilisateur
            .FrmUser.Index = index '  .FrmUser.Index = compteur

            'Je nomme le Tab_Page par le nom du personnage.
            '  .FrmUser.GroupBoxName.Text = .Personnage.NomDuPersonnage

            'J'ajoute à la form "groupe", dans le tabcontrol, le tab_page.
            frmGroupe.FlowLayoutPanel1.Controls.Add(.FrmUser)



            'Charger les options ici.
            frmGroupe.BotIndex.Add(index)

        End With

    End Sub


    Public Sub ErreurFichier(ByVal index As Integer, ByVal nomJoueur As String, ByVal nomErreur As String, ByVal erreur As String)

        Try

            EcritureMessage(index, "[Erreur]", "Une erreur est survenue, veuillez envoyez les fichiers qui se trouve dans le dossier 'Erreur' à l'administrateur.", Color.Red)

            'Si le dossier erreur n'existe pas, alors je le créer
            If Not IO.Directory.Exists(Application.StartupPath & "\AllErreur") Then IO.Directory.CreateDirectory(Application.StartupPath & "\AllErreur")

            'J'ouvre le fichier pour y écrire se que je souhaite
            Dim swEcriture As New IO.StreamWriter(Application.StartupPath + "\AllErreur/" & nomJoueur & "_" & nomErreur & ".txt")

            swEcriture.WriteLine(erreur)

            'Puis je le ferme.
            swEcriture.Close()

        Catch ex As Exception

            MsgBox("erreur fichier, impossible de créer le fichier erreur : " & nomErreur & vbCrLf & ex.ToString)

        End Try

    End Sub

    Public Sub EcritureMessage(ByVal index As Integer, ByVal indice As String, ByVal message As String, ByVal couleur As Color)

        With Comptes(index).FrmUser

            Try

                If .InvokeRequired Then

                    .Invoke(New dlgDivers(Sub() EcritureMessage(index, indice, message, couleur)))

                Else

                    .RichTextBox1.SelectionColor = couleur

                    .RichTextBox1.AppendText("[" & TimeOfDay & "] " & indice & " " & message & vbCrLf)

                    .RichTextBox1.ScrollToCaret()

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

End Module
