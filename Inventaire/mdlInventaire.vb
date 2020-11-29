Module mdlInventaire

#Region "Réception Inventaire"

    Public Sub GiInventaire(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' ASK | 1234567   | Linaculer  | 99    | 9         | 0       | 90            | -1       | -1       | -1       | 262c1bc        ~ 241      ~ 1         ~ 1                 ~ 64#2#4#0#1d3+1  , 7d#1#0#0#0d0+1 ; Next Item
            ' ASK | ID Joueur | Nom Joueur | Level | Id Classe | Id Sexe | Classe + Sexe | Couleur1 | Couleur2 | Couleur3 | Id Unique Item ~ Id Objet ~ Quantity  ~ Number equipment  ~ Caractéristique , Caract Next    ; Item suivent

            Try

                Dim separateData As String() = Split(data, "|")

                ' Information
                .Personnage.ID = separateData(1)
                .Personnage.NomDuPersonnage = separateData(2)
                .Personnage.Niveau = separateData(3)
                .Personnage.Classe = separateData(4)
                .Personnage.Sexe = separateData(5)
                .Personnage.ClasseSexe = separateData(6)

                If Not ListOfBotName.Contains(separateData(2).ToLower) Then

                    ListOfBotName.Add(separateData(2).ToLower)

                End If

                ' .Personnage.Couleur1 = "&H" & separateData(7)
                ' .Personnage.Couleur2 = "&H" & separateData(8)
                ' .Personnage  .Couleur3 = "&H" & separateData(9)
                ' /Information

                EcritureMessage(index, "[Dofus]", "Connecté au personnage '" & separateData(2) & "' (Niveau : " & separateData(3) & ")", Color.Green)
                EcritureMessage(index, "[Dofus]", "Réception de l'inventaire.", Color.Green)

                .Inventaire.Clear()

                GiItemAjoute(index, separateData(10), .Inventaire)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiInventaire", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

#End Region

    Public Sub GiInventaireItemSupprime(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' OR 55156977
            ' OR id Unique

            data = Mid(data, 3)

            If .Inventaire.ContainsKey(data) Then

                .Inventaire.Remove(data)

            End If

            .BloqueItem.Set()

        End With

    End Sub

    Public Sub GiInventaireQuantité(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' OQ 55259212  | 699
            ' OQ Id Unique | Quantité

            data = Mid(data, 3)

            Dim separateData As String() = Split(data, "|")

            If .Inventaire.ContainsKey(separateData(0)) Then

                .Inventaire(separateData(0)).Quantité = separateData(1)

            End If

            .BloqueItem.Set()

        End With

    End Sub

    Public Sub GiEquipement(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' OM 123515576 | 7
            ' OM id unique | Numéro équipement

            data = Mid(data, 3)

            Dim separateData As String() = Split(data, "|")

            If .Inventaire.ContainsKey(separateData(0)) Then

                With .Inventaire(separateData(0))

                    If separateData(1) <> Nothing Then

                        .Equipement = separateData(1)

                    Else

                        .Equipement = ""

                    End If

                End With

            End If

            .BloqueItem.Set()

        End With

    End Sub

    Public Sub GiInventoryChangedCharacteristic(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' OCO 4a239fd  ~ 1f40    ~ 1        ~ 8                 ~ 320#5#48#9,328#28a#1f5#466,326#0#0#48,327#0#0#18a,9e#2da#0#0#0d0+730 ; 
            ' OCO idUnique ~ IdObjet ~ Quantité ~ Numéro Equipement ~ Caractéristique                                                      ; Next item

            data = Mid(data, 4)

            Dim separateData As String() = Split(data, ";")

            For i = 0 To separateData.Count - 1

                If separateData(i) <> "" Then

                    Dim separateItem As String() = Split(separateData(i), "~")

                    Dim IdUnique As String = Convert.ToInt64(separateItem(0), 16)

                    If .Inventaire.ContainsKey(IdUnique) Then

                        With .Inventaire(IdUnique)

                            'quantity
                            .Quantité = Convert.ToInt64(separateItem(2), 16)

                            'Caractéristique
                            .Caractéristique = ItemCaractéristique(separateItem(4))
                            .CaractéristiqueBrute = separateItem(4)

                            If separateItem(3) <> "" Then

                                .Equipement = Convert.ToInt64(separateItem(3), 16)

                            ElseIf VarItems(Convert.ToInt64(separateItem(1), 16)).Catégorie = "24" Then

                                .Equipement = "24"

                            Else

                                .Equipement = ""

                            End If

                        End With

                    End If

                End If

            Next

            .BloqueItem.Set()

        End With

    End Sub

    Public Sub GiEquipementMétier(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' OT 28
            ' OT Id Métier

            If data.Length > 2 Then

                If .Metier.ContainsKey(VarMétier(Mid(data, 3)).Nom) Then

                    .Metier(VarMétier(Mid(data, 3)).Nom).ItemEquipé = True

                End If

            Else

                For Each pair As ClassMétier In .Metier.Values

                    pair.ItemEquipé = False

                Next

            End If

        End With

    End Sub

End Module
