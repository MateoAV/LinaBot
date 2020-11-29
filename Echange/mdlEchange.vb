Module mdlEchange

    Sub GiEchangeRecu(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' ERK 1234567    | 7654321     | 1
                ' ERK Id Lanceur | Id Receveur | ?

                Dim separateData As String() = Split(Mid(data, 4), "|")

                .Personnage.InvitationEchange = True

                If separateData(0) <> .Personnage.ID Then

                    EcritureMessage(index, "[Dofus]", .Map.Entite(separateData(0)).Nom & " te propose de faire un échange. acceptes-tu ?", Color.Green)

                Else

                    EcritureMessage(index, "[Dofus]", "En Attente de la réponse de " & .Map.Entite(separateData(1)).Nom & " pour un échange...", Color.Green)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiEchangeRecu", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiEchangeValideInvalide(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EK 1      1234567
                ' EK 1 ou 0 Id perso

                Dim id As Integer = Mid(data, 4)

                Select Case Mid(data, 3, 1)

                    Case "0"

                        If id = .Personnage.ID Then

                            .Echange.Moi.Valider = False

                        Else

                            .Echange.Lui.Valider = False

                        End If

                    Case "1"

                        If id = .Personnage.ID Then

                            .Echange.Moi.Valider = True

                        Else

                            .Echange.Lui.Valider = True

                        End If

                End Select

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiEchangeValideInvalide", data & vbCrLf & ex.Message)

            End Try

            .Echange.BloqueEchange.Set()

        End With

    End Sub

    Sub GiEchangeAjouteItemLui(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EmKO+ 40514824  | 1        | 7659     |
                ' EmKO+ Id Unique | Quantité | Id Objet | Caractéristique

                Dim separateData As String() = Split(Mid(data, 6), "|")

                If .Echange.Lui.Inventaire.ContainsKey(separateData(0)) Then

                    .Echange.Lui.Inventaire(separateData(0)).Quantité = separateData(1)

                Else

                    Dim newItem As New ClassItem

                    With newItem

                        .IdObjet = separateData(2)

                        .IdUnique = separateData(0)

                        .Nom = VarItems(Convert.ToInt64(separateData(2))).Nom

                        .Quantité = separateData(1)

                        .Caractéristique = ItemCaractéristique(separateData(3))

                        .CaractéristiqueBrute = separateData(3)

                        .Catégorie = VarItems(.IdObjet).Catégorie

                        .Equipement = ""

                    End With

                    If .Echange.Lui.Inventaire.ContainsKey(newItem.IdUnique) Then

                        .Echange.Lui.Inventaire(newItem.IdUnique) = newItem

                    Else

                        .Echange.Lui.Inventaire.Add(newItem.IdUnique, newItem)

                    End If

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiEchangeAjouteItemLui", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiEchangeSupprimeItemLui(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EmKO- 40420233
                ' EmKO- Id Unique

                Dim idUnique As String = Mid(data, 6)

                If .Echange.Lui.Inventaire.ContainsKey(idUnique) Then

                    .Echange.Lui.Inventaire.Remove(idUnique)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiEchangeSupprimeItemLui", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiEchangeAjouteItemMoi(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EMKO+ 40420233  | 20 
                ' EMKO+ Id Unique | Quantité

                Dim separateData As String() = Split(Mid(data, 6), "|")

                If .Echange.Moi.Inventaire.ContainsKey(separateData(0)) Then

                    .Echange.Moi.Inventaire(separateData(0)).Quantité = separateData(1)

                Else

                    Dim newItem As ClassItem = .Inventaire(separateData(0))

                    newItem.Quantité = separateData(1)

                    .Echange.Moi.Inventaire.Add(separateData(0), newItem)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiEchangeAjouteItemMoi", data & vbCrLf & ex.Message)

            End Try

            .BloqueItem.Set()

        End With

    End Sub

    Sub GiEchangeSupprimeItemMoi(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EMKO- 40420233
                ' EMKO- Id Unique

                Dim idUnique As String = Mid(data, 6)

                If .Echange.Moi.Inventaire.ContainsKey(idUnique) Then

                    .Echange.Moi.Inventaire.Remove(idUnique)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiEchangeSupprimeItemMoi", data & vbCrLf & ex.Message)

            End Try

            .BloqueItem.Set()

        End With

    End Sub

    Sub GiEchangeKamasLui(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' EmKG 5
                ' EmKG Kamas

                .Echange.Lui.Kamas = Mid(data, 5)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiEchangeKamasLui", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiEchangeKamasMoi(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' Echange
                ' EMKG 5
                ' EMKG kamas

                ' Banque/Coffre
                ' EsKG 5
                ' EsKG kamas

                .Echange.Moi.Kamas = Mid(data, 5)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiEchangeKamasMoi", data & vbCrLf & ex.Message)

            End Try

            .Echange.BloqueEchange.Set()

        End With

    End Sub

End Module
