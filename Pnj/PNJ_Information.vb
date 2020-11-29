Module PNJ_Information

    Public Sub GiPnjDialogue(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' DCK -2  
                ' DCK ID sur la map

                .Pnj.EnDialogue = True

                'J'affiche le nom du PNJ auquel je parle.
                Dim idUnique As String = Mid(data, 4)

                If .Map.Entite.ContainsKey(idUnique) Then

                    EcritureMessage(index, "[Dofus]", "Je parle actuellement avec " & .Map.Entite(idUnique).Nom, Color.Orange)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiPnjDialogue", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Public Sub GiPnjQuestionReponse(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' DQ 318        ; 449                                           |   259     ;    329    ;
                ' DQ ID Réponse ; Information à mettre dans le dialogue de base | Réponse 1 ; Réponse 2 ; etc....

                .Pnj.Reponse.Clear()
                .Pnj.IdReponse = 0

                data = Mid(data, 3)

                Dim separateData As String() = Split(data, "|")

                .Pnj.IdReponse = Split(separateData(0), ";")(0)

                If data.Contains("|") Then

                    separateData = Split(separateData(1), ";")

                    For i = 0 To separateData.Count - 1

                        .Pnj.Reponse.Add(separateData(i))

                        EcritureMessage(index, "[Dofus - Réponse]", i + 1 & ") " & VarPnjRéponse(separateData(i)), Color.Green)

                    Next

                Else

                    EcritureMessage(index, "(Bot)", "Il n'y a plus aucune réponse disponible pour ce Pnj.", Color.Green)

                End If

                .Pnj.BloquePnj.Set()

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiPnjQuestionReponse", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

End Module
