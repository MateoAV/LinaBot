Partial Class Player

    'TOUT METTRE DANS GESTION POUR LAISSE LE RESTE AU PROPRE.

    Private ReadOnly GestionInfo As New Gestion
    'Faire 2 facon si rien indiquer bot auto
    ' si indiquer faire comme voulu par luser
    Public Sub GestionReception(message As Object, e As Socket_EventArgs)

        With Comptes(Index).GestionInfo

            Try

                If e.Message <> "" Then

                Select Case e.Message(0)

                    Case "A"

                        Select Case e.Message(2)

                            Case "N"

                                .Upsort(Index)
                                .UpCaracteristique(Index)

                        End Select

                    Case "G"

                        Select Case e.Message(1)

                            Case "J"

                                Select Case e.Message(2)

                                    Case "K"

                                        Select Case e.Message(3)

                                            Case "K"

                                                Task.Run(Sub() .CombatTempsPreparation(Index, e.Message))

                                        End Select

                                End Select

                            Case "T"

                                Select Case e.Message(2)
                                    Case "S"

                                        Dim separate As String() = Split(Mid(e.Message, 4), "|")

                                        If separate(0) = Comptes(Index).Personnage.ID Then

                                            '  Task.Run(Function() Avance(Index))

                                        End If

                                End Select

                            Case "t"

                                If .ThreadCombat IsNot Nothing AndAlso .ThreadCombat.IsAlive Then

                                    Return

                                Else

                                    Task.Run(Sub() .CombatLancer(Index, e.Message))

                                End If

                            Case "P"

                                Task.Run(Sub() .CombatPlacementCase(Index, e.Message))

                        End Select

                    Case "O"

                        Select Case e.Message(1)

                            Case "w"

                                If Personnage.Pods.Pourcentage >= FrmGroupe.Variable("pods").Values(0)(0) Then

                                    Task.Run(Sub() .Supprime(Index))

                                End If

                        End Select

                    Case "P"

                        Select Case e.Message(1)

                            Case "I" ' PI

                                Select Case e.Message(2)

                                    Case "K" ' PIK

                                        Task.Run(Sub() .GroupeInvitationRecu(Index))

                                End Select

                            Case "M" ' PM

                                Select Case e.Message(2)

                                    Case "-" ' PM-

                                        Task.Run(Sub() .GroupeQuitte(Index))

                                End Select

                        End Select

                End Select

            End If

            Catch ex As Exception

            End Try

        End With

    End Sub

End Class

Class Gestion

    Public ThreadCombat As Threading.Thread

#Region "Groupe"

    Sub GroupeInvitationRecu(index As Integer)

        With Comptes(index)

            If .Groupe.Inviteur <> .Personnage.NomDuPersonnage Then

                For Each bot As Integer In .FrmGroupe.BotIndex

                    If .Groupe.Inviteur = Comptes(bot).Personnage.NomDuPersonnage Then

                        Dim newGroupe As New FunctionGroupe
                        Task.Run(Function() newGroupe.Accepte(index))

                        Exit For

                    End If

                Next

            End If

        End With

    End Sub

    Sub GroupeQuitte(index As Integer)

        With Comptes(index)

            Dim newGroupe As New FunctionGroupe
            Task.Run(Function() newGroupe.Quitte(index))

        End With

    End Sub

#End Region

#Region "Combat"

    Sub CombatTempsPreparation(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' GJK2 | 0 | 1 | 0 | 30000                                      | 4 
            ' GJK2 | ? | ? | ? | Temps restant avant que le combat se lance | ?

            Dim separateData As String() = Split(data, "|")

            If CInt(separateData(4)) > 1 Then

                If .FrmGroupe.BotIndex.Count > 1 Then

                    Dim newCombat As New FunctionCombat
                    Task.Run(Function() newCombat.Spectateur(index, True))

                End If

            End If

        End With

    End Sub

    'sinon execute le code normalement et après l'apelle je fais las task.run de se que je souahite
    'exemple : 
    ' Case "I"
    'GiAmi(index,e.message)
    'task.run(sub() gege())
    Sub CombatLancer(index As Integer, data As String)

        With Comptes(index)

            Try

                'Indique l'épée et le tas de monstre (se qu'il contient)

                ' Gt -42                     | + 1234567   ; Linaculer ; 60 
                ' Gt -43                     | + -1        ; 63        ; 3      |+-2;63;2 
                ' Gt Id Unique Epee/Tas Mobs | + Id Unique ; Nom/ID    ; Niveau | Suivant

                Dim separateData As String() = Split(data, "|")
                Dim id As Integer = Mid(separateData(0), 3, separateData(0).Length)

                For i = 1 To separateData.Count - 1

                    Dim separate As String() = Split(separateData(i), ";")

                    For Each bot As Integer In .FrmGroupe.BotIndex

                        If separate(0) = Comptes(bot).Groupe.ChefID AndAlso .Personnage.ID = Comptes(bot).Personnage.ID Then

                            'J'entre dans la combat
                            Dim newCombat As New FunctionCombat

                            ThreadCombat = New Threading.Thread(Sub() newCombat.Rejoindre(bot, id)) With {.IsBackground = True}
                            ThreadCombat.Start()

                            Task.Delay(500).Wait()

                            ThreadCombat = New Threading.Thread(Sub() newCombat.Pret(bot, True)) With {.IsBackground = True}
                            ThreadCombat.Start()

                            Return

                        End If

                    Next

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiCombatLancer", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub CombatPlacementCase(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                If .Groupe.ChefID = 0 Then

                    Dim newCombat1 As New FunctionCombat
                    Task.Run(Function() newCombat1.Pret(index, True))

                ElseIf .Groupe.ChefID > 0 OrElse .Personnage.ID = .Groupe.ChefID Then

                    Task.Delay(5000).Wait()
                    Dim newCombat1 As New FunctionCombat
                    Task.Run(Function() newCombat1.Pret(index, True))
                    Return

                End If
                ' GP bfbubBbPbYcbcfct  | fBfPfXf1f_gdgOg2  | 0 
                ' GP Cellules Equipe 1 | Cellules equipé 2 | Indique l'équipe dans laquel vous êtes (couleur des cases)

                If .Combat.EnPreparation Then

                    Dim separateData As String() = Split(Mid(data, 3), "|")

                    For a = 1 To separateData(separateData(2)).Length Step 2

                        Dim cellule As Integer = ReturnLastCell(Mid(separateData(separateData(2)), a, 2))

                        'Tcheck la cellule correspond à celle voulu
                        's'il veut la cellule proche/éloigné etc....

                        If cellule = "X" Then

                            Dim newCombat As New FunctionCombat
                            Task.Run(Function() newCombat.Placement(index, cellule))

                            Task.Delay(8000).Wait()

                            Task.Run(Function() newCombat.Pret(index, True))

                            Exit For

                        End If

                    Next

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiCombatPlacementCase", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

#End Region

#Region "Caracteristique"

    Sub UpCaracteristique(index As Integer)

        With Comptes(index)

            Dim newCaracteristique As New FunctionCaractéristique

            newCaracteristique.Up(index, .OptionCaracteristique)

        End With

    End Sub

    Sub UpSort(index As Integer)

        With Comptes(index)

            Dim newSort As New FunctionSort

            For i = 0 To .OptionSort.Count - 1

                newSort.Up(index, .OptionSort(i))

            Next

        End With

    End Sub

#End Region

#Region "Suppression"

    Sub Supprime(index As Integer)

        With Comptes(index)

            Try

                For Each pair As Object In .FrmGroupe.Variable("supprime").Values

                    For Each item As CItem In CopyItem(index, .Inventaire).Values

                        If item.Nom.ToLower = pair(0).ToString.ToLower OrElse item.IdObjet.ToString = pair(0).ToString Then

                            Dim newItem As New FunctionItem

                            newItem.Supprime(index, item.IdObjet)

                        End If

                    Next

                Next

            Catch ex As Exception

            End Try

        End With

    End Sub

#End Region

End Class