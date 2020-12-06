Module mdlRecolte

    Public Sub GiRécolteEnCours(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' GA0 ; 501     ; 0123456   ; 35         , 18800
                ' GA0 ; Récolte ; ID Joueur ; Cellule ID , Temps en milliseconde

                Dim separateData As String() = Split(data, ";")

                Dim idPlayer As Integer = separateData(2) ' 0123456

                Dim send As String = Mid(separateData(0), 3) ' GA0

                separateData = Split(separateData(3), ",") ' 35,18800

                If idPlayer = .Personnage.ID Then

                    .Recolte.EnRecolte = True
                    .Recolte.BloqueRecolte.Reset()

                    .Personnage.InteractionCellule = separateData(0)
                    .Recolte.NumeroRecolte += 1

                    EcritureMessage(index, "[Récolte]", "Temps de récolte : " & If(separateData(1).Length = 4, Mid(separateData(1), 1, 1), Mid(separateData(1), 1, 2)) & " Seconde(s)", Color.Green)
                    EcritureMessage(index, "[Récolte]", "Récolte n° " & .Recolte.NumeroRecolte, Color.Green)

                    Wait(index, separateData(1), "GKK" & send)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GARecolteEnCours", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Private Async Sub Wait(ByVal index As Integer, ByVal pause As Integer, ByVal envoie As String)

        With Comptes(index)

            Try

                If .MITM = False Then

                    Await Task.Delay(pause)

                    .Send(envoie)

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

    Public Sub RécolteDrop(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                'IQ 1234567   | 2
                'IQ ID Joueur | Quantité

                data = Mid(data, 3)

                Dim separate As String() = Split(data, "|")

                If separate(0) = .Personnage.ID Then

                    EcritureMessage(index, "[Dofus]", "Vous avez obtenue " & separate(1) & " récolte(s).", Color.Green)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "RécolteDrop", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

End Module
