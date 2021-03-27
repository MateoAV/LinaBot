Public Class FrmGuilde

    Public Index As Integer
    Private Delegate Sub dlg()
    Dim newGuilde As New FunctionGuilde

#Region "Chargement"

    Private Sub FrmGuilde_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Comptes(Index)

            Try

                Task.Run(AddressOf Me.Chargement)

                Task.Run(Function() newGuilde.Ouvre(Index))

                TabControl10_Click(Nothing, Nothing)

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub Chargement()

        With Comptes(Index)

            Try

                If .Connecté Then

                    AddHandler .Socket.Reception, AddressOf Reception

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub FrmGuilde_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        With Comptes(Index)

            Try

                If .Connecté Then

                    RemoveHandler .Socket.Reception, AddressOf Reception

                    Me.Dispose()

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub Reception(ByVal sender As Object, ByVal e As Socket_EventArgs)

        With Comptes(Index)

            Try

                If InvokeRequired Then

                    Invoke(New dlg(Sub() Reception(sender, e)))

                Else

                    Select Case e.Message(0)

                        Case "g"

                            Select Case e.Message(1)

                                Case "I"

                                    Select Case e.Message(2)

                                        Case "B"

                                            Personnalisation(Index, e.Message)

                                        Case "F"

                                            Enclos(Index, e.Message)

                                        Case "G"

                                            Exp(Index, e.Message)

                                        Case "H"

                                            Maison(Index, e.Message)

                                        Case "M"

                                            Select Case e.Message(3)

                                                Case "+"

                                                    AjouteMembres(Index, e.Message)

                                                Case "-"

                                                    SupprimeMembres(Index, e.Message)

                                            End Select

                                    End Select

                            End Select


                    End Select

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub TabControl10_Click(sender As Object, e As EventArgs) Handles TabControl10.Click

        With Comptes(Index)

            Try

                With newGuilde

                    Select Case TabControl10.SelectedTab.Text.ToLower

                        Case "membres"

                            Task.Run(Function() .Membres(Index))

                        Case "personnalisation"

                            Task.Run(Function() .Personnalisation(Index))

                        Case "percepteurs"

                            Task.Run(Function() .Percepteurs(Index))

                        Case "enclos"

                            Task.Run(Function() .Enclos(Index))

                        Case "maisons"

                            Task.Run(Function() .Maisons(Index))

                    End Select

                End With

            Catch ex As Exception

            End Try

        End With

    End Sub

#End Region

#Region "Gestion"

    Private Sub Exp(index As Integer, data As String)

        With Comptes(index)

            Try

                ' gIG 0 | 5      | 28000   | 30271        | 48000
                ' gIG ? | Niveau | exp min | exp actuelle | exp max

                Dim separate As String() = Split(data, "|")

                LabelGuildeNiveau.Text = "Niveau : " & separate(1)

                With ProgressBarGuildeXP

                    .Minimum = separate(2)
                    .Maximum = separate(4)
                    .Value = separate(3)

                End With

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub AjouteMembres(index As Integer, data As String)

        With Comptes(index)

            Try

                ' gIM+ 1234567  ; Linaculer ; 60     ; 81     ; 2    ; 0        ; 0   ; 29694 ; 1        ; 0          ; 0                  | Next
                ' gIM+ IdUnique ; Nom       ; Niveau ; Classe ; Rang ; XpGagnée , %Xp ; Droit ; Connecté ; Alignement ; Dernière connexion | 
                Dim rangActuel() As String = {"A l'essai", "Meneur", "Bras Droit", "Trésorier", "Protecteur", "Artisan", "Réserviste", "Gardien", "Eclaireur", "Espion", "Diplomate", "Secrétaire",
            "Tueur de familiers", "Braconnier", "Chercheur de trésor", "Voleur", "Initié", "Assassin", "Gouverneur", "Muse", "Conseiller", "Elu", "Guide", "Mentor", "Recruteur",
            "Eleveur", "Marchand", "Apprenti", "Bourreau", "Mascotte", "Pénitent", "Tueur de Percepteurs", "Déserteur", "Traître", "Boulet", "Larbin", "A l'essai"}

                Dim separateData As String() = Split(Mid(data, 5), "|")

                DataGridViewGuildeMembre.Rows.Clear()

                For i = 0 To separateData.Count - 1

                    Dim separate As String() = Split(separateData(i), ";")

                    With DataGridViewGuildeMembre

                        .Rows.Add(separate(0))

                        With .Rows(.Rows.Count - 1)

                            .Cells(1).Value = separate(1)
                            .Cells(2).Value = separate(2)
                            .Cells(3).Value = New Bitmap(Application.StartupPath & "\Image\Personnage/" & separate(3) & ".png")
                            .Cells(4).Value = rangActuel(separate(4))
                            .Cells(5).Value = separate(5)
                            .Cells(6).Value = separate(6)
                            .Cells(7).Value = New Bitmap(Application.StartupPath & "\Image\Alignement/" & separate(9) & ".png")

                            .Cells(9).Value = New Bitmap(If(separate(8) = "1", Application.StartupPath & "\Image/Yes.png", Application.StartupPath & "\Image/No.png"))

                        End With

                        .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                    End With

                Next

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub SupprimeMembres(index As Integer, data As Integer)

        With Comptes(index)

            Try

                ' gIM- Linaculer
                ' gIM- nom du joueur

                Dim nom As String = Mid(data, 5)

                For Each pair As DataGridViewRow In CopyDatagridView(index, DataGridViewGuildeMembre).Rows

                    If pair.Cells(1).Value.ToString.ToLower = Mid(data, 5).ToLower Then

                        DataGridViewGuildeMembre.Rows.RemoveAt(pair.Index)

                        Exit Sub

                    End If

                Next

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub Personnalisation(index As Integer, data As String)

        With Comptes(index)

            Try

                ' gIB1 |0|200|2|1000|100|0|1|5|1020|462;0|461;0|460;0|459;0|458;0|457;0|456;0|455;0|454;0|453;0|452;0|451;0
                ' gIB1 |                   ?

                Dim separateData As String() = Split(data, "|")

                LabelGuildePercepteurPosée.Text = separateData(1) & "/" & Mid(separateData(0), 4, separateData(0).Length)
                LabelGuildePercepteurVitaliter.Text = separateData(2)
                LabelGuildePercepteurDommage.Text = separateData(3)
                LabelGuildePercepteurPods.Text = separateData(4)
                LabelGuildePercepteurProspection.Text = separateData(5)
                LabelGuildePercepteurSagesse.Text = separateData(6)
                LabelGuildePercepteurNombre.Text = separateData(7)
                LabelGuildePercepteurCapital.Text = separateData(8)
                LabelGuildePercepteurCoutKamas.Text = separateData(9)

                Percepteur_Sort_451.Text = "Armure Aqueuse" & vbCrLf &
                                           "Niveau : " & Split(separateData(21), ";")(1) & vbCrLf &
                                           "(Réduit les dégâts Eau)"

                Percepteur_Sort_452.Text = "Armure Incandescente" & vbCrLf &
                                           "Niveau : " & Split(separateData(20), ";")(1) & vbCrLf &
                                           "(Réduit les dégâts Feu)"

                Percepteur_Sort_453.Text = "Armure Terrestre" & vbCrLf &
                                           "Niveau : " & Split(separateData(19), ";")(1) & vbCrLf &
                                           "(Réduit les dégâts Neutre/Terre)"

                Percepteur_Sort_454.Text = "Armure Venteuse" & vbCrLf &
                                           "Niveau : " & Split(separateData(18), ";")(1) & vbCrLf &
                                           "(Réduit les dégâts Air)"

                Percepteur_Sort_455.Text = "Flamme" & vbCrLf &
                                           "Niveau : " & Split(separateData(17), ";")(1) & vbCrLf &
                                           "(Inflige des dégâts Feu)"

                Percepteur_Sort_456.Text = "Cyclone" & vbCrLf &
                                           "Niveau : " & Split(separateData(16), ";")(1) & vbCrLf &
                                           "(Inflige des dégâts Air)"

                Percepteur_Sort_457.Text = "Vague" & vbCrLf &
                                           "Niveau : " & Split(separateData(15), ";")(1) & vbCrLf &
                                           "(Inflige des dégâts Eau)"

                Percepteur_Sort_458.Text = "Rocher" & vbCrLf &
                                           "Niveau : " & Split(separateData(14), ";")(1) & vbCrLf &
                                           "(Inflige des dégâts Terre)"

                Percepteur_Sort_459.Text = "Mot soignant" & vbCrLf &
                                           "Niveau : " & Split(separateData(13), ";")(1) & vbCrLf &
                                           "(Permet de soigner un allié)"

                Percepteur_Sort_460.Text = "Désenvoutement" & vbCrLf &
                                           "Niveau : " & Split(separateData(12), ";")(1) & vbCrLf &
                                           "(Enléve les envoûtements d'un ennemi)"

                Percepteur_Sort_461.Text = "Compulsion de masse" & vbCrLf &
                                           "Niveau : " & Split(separateData(11), ";")(1) & vbCrLf &
                                           "(Augmente les dégâts Percepteur + Allié)"

                Percepteur_Sort_462.Text = "Déstabilisation" & vbCrLf &
                                           "Niveau : " & Split(separateData(10), ";")(1) & vbCrLf &
                                           "(Augmente les Echecs Critiques ennemi)"

            Catch ex As Exception

            End Try

        End With

    End Sub

    Public Sub Percepteur(index As Integer, data As String)

        With Comptes(index)

            Try

                ' gITM+ 2ki ; b , 28 , Linaculer1    , 1516232486517 ,   , 0 , 0 ; 2ki ; 0 
                ' gITM+     ; ? , ?  , Nom du poseur , ?             , ? , ? , ? ; ?   ; ?

                'Inconnu actuellement

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiGuildePercepteurPosee", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Private Sub Enclos(index As Integer, data As String)

        With Comptes(index)

            Try

                ' gIF3 | 9999 ; 2 ; 2 ; 
                ' gIF3 | 9999 ; 2 ; 2 ; 

                DataGridViewGuildeEnclos.Rows.Clear()

                Dim separateData As String() = Split(data, "|")

                For i = 1 To separateData.Count - 1

                    Dim separate As String() = Split(separateData(i), ";")

                    Dim newEnclos As New CGuildeEnclos

                    With newEnclos

                        .MapID = separate(0)
                        .Position = VarMap(separate(0))
                        .DragodindeActuelle = separate(1)
                        .DragodindeActuelle = separate(2)

                    End With

                    .Guilde.Enclos.Add(separate(0), newEnclos)

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiGuildeEnclos", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Private Sub Maison(index As Integer, data As String)

        With Comptes(index)

            Try

                'gIH+ 999 ; Linaculer   ; 666,66 ;            ; 499    |
                '     ID  ; proriétaire ; Pos    ; compétence ; Droits | Next

                Dim separateData As String() = Split(Mid(data, 5), "|")

                DataGridViewGuildeMaisons.Rows.Clear()

                For i = 0 To separateData.Count - 1

                    Dim separate As String() = Split(separateData(i), ";")

                    Dim Valeur As Integer() = {256, 128, 64, 32, 16, 8, 4, 2, 1}

                    With DataGridViewGuildeMaisons

                        .Rows.Add("Maison")

                        .Rows(.Rows.Count - 1).Cells(1).Value = separate(1)

                        .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                    End With

                    LabelNomMaison.Text = "Maison"
                    LabelPropriétaire.Text = "Prorpiétaire : " & separate(1)
                    LabelCoordonnees.Text = "Coordonnées : " & separate(2)

                    For a = 0 To 8

                        If CInt(separate(4)) >= Valeur(a) Then

                            Select Case Valeur(a)

                                Case 256 '256 =  Repos autorisé aux membres de la guilde dans cette maison

                                    ListBoxDroits.Items.Add("Repos autorié aux membres de la guilde dans cette maison")

                                Case 128 '128 = Téléportation autorisée vers cette maison

                                    ListBoxDroits.Items.Add("Téléportation autorisée vers cette maison")

                                Case 64 '64 = Accès aux coffres interdit aux non-membres de la guilde

                                    ListBoxDroits.Items.Add("Accès aux coffres interdit aux non-membres de la guilde")

                                Case 32 '32 = Accès aux coffres autorisé aux membres de la guilde

                                    ListBoxDroits.Items.Add("Accès aux coffres autorisé aux membres de la guilde")

                                Case 16 '16 = Accès interdit aux non-membres de la guilde

                                    ListBoxDroits.Items.Add("Accès interdit aux non-membres de la guilde")

                                Case 8 '8 = Accès autorisé aux membres de la guilde

                                    ListBoxDroits.Items.Add("Accès autorisé aux membres de la guilde")

                                Case 4 '4 = Blason Visible pour tout le monde

                                    ListBoxDroits.Items.Add("Blason Visible pour tout le monde")

                                Case 2 '2 = Blason Visible pour la guilde

                                    ListBoxDroits.Items.Add("Blason Visible pour la guilde")

                                Case 1 '1 = Maison Visible pour la guilde.

                                    ListBoxDroits.Items.Add("Maison Visible pour la guilde")

                            End Select

                            separate(4) = CInt(separate(4)) - Valeur(a)

                        End If

                    Next

                Next

            Catch ex As Exception

            End Try

        End With

    End Sub
#End Region

#Region "Droits"

#End Region

End Class