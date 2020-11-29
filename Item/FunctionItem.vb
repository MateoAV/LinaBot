
Public Class FunctionItem

    ''' <summary>
    ''' Permet la suppression d'un item contenue dans l'inventaire du joueur.
    ''' </summary>
    ''' <param name="index">Indique le numéro bot.</param>
    ''' <param name="nom">Nom/ID de l'item.</param>
    ''' <param name="quantite">La quantité à supprimer (de base 999.999).</param>
    ''' <param name="caracteristique">Les caractéristiques que doit avoir l'item pour être supprimer.</param>
    ''' <returns>
    ''' True = Le bot a bien supprimé l'item. <br/>
    ''' False = Le bot n'a pas réussi à supprimer l'item.
    ''' </returns>
    Public Function Supprime(ByVal index As String, ByVal nom As String, Optional ByVal quantite As String = "999999", Optional ByVal caracteristique As ClassItemCaractéristique = Nothing) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassItem In CopyItem(index, .Inventaire).Values

                    If Pair.Nom.ToLower = nom.ToLower OrElse Pair.IdObjet.ToString = nom Then

                        If Pair.Equipement = "" Then

                            If IsNothing(caracteristique) OrElse ComparateurCaractéristiqueObjets(Pair.Caractéristique, caracteristique) Then

                                If quantite > CInt(Pair.Quantité) Then quantite = Pair.Quantité

                                EcritureMessage(index, "(Bot)", "Suppression de l'item " & Pair.Nom & " x " & quantite, Color.Gray)

                                .BloqueItem.Reset()

                                .Send("Od" & Pair.IdUnique & "|" & quantite)

                                .BloqueItem.WaitOne(15000)

                                Return Not Existe(index, Pair.IdUnique, caracteristique)

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

                EcritureMessage(index, "(Bot)", "Erreur lors de la suppression d'un item." & vbCrLf &
                                                "Nom : " & nom, Color.Red)

            End Try

            Return False

        End With

    End Function



    ''' <summary>
    ''' Permet de retirer un item contenue dans la banque/coffre/échange/HDV/Etc...
    ''' </summary>
    ''' <param name="index">Indique le numéro bot.</param>
    ''' <param name="nom">Nom/ID de l'item.</param>
    ''' <param name="quantite">La quantité à retirer (de base 999.999).</param>
    ''' <param name="caracteristique">Les caractéristiques que doit avoir l'item pour être retiré.</param>
    ''' <returns>
    ''' True = Le bot a bien retiré l'item. <br/>
    ''' False = Le bot n'a pas réussi à retirer l'item.
    ''' </returns>
    Public Function Retire(ByVal index As String, ByVal nom As String, Optional ByVal quantite As String = "999999", Optional ByVal caracteristique As ClassItemCaractéristique = Nothing) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassItem In .Echange.Moi.Inventaire.Values

                    If Pair.Nom.ToLower = nom.ToLower OrElse Pair.IdObjet.ToString = nom Then

                        If Pair.Equipement = "" Then

                            If IsNothing(caracteristique) OrElse ComparateurCaractéristiqueObjets(Pair.Caractéristique, caracteristique) Then

                                If quantite > CInt(Pair.Quantité) Then quantite = Pair.Quantité

                                EcritureMessage(index, "(Bot)", "Retire l'item " & Pair.Nom & " x " & quantite, Color.Gray)

                                .BloqueItem.Reset()

                                .Send("EMO-" & Pair.IdUnique & "|" & quantite)

                                Return .BloqueItem.WaitOne(15000)

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

                EcritureMessage(index, "(Bot)", "Erreur Pour retirer l'item." & vbCrLf &
                                         "Nom : " & nom, Color.Red)

            End Try

            Return False

        End With

    End Function



    ''' <summary>
    ''' Permet de déposer un item en Banque/Echange/Coffre/Etc...
    ''' </summary>
    ''' <param name="index">Indique le numéro bot.</param>
    ''' <param name="nom">Nom/ID de l'item.</param>
    ''' <param name="quantite">La quantité à déposer (de base 999.999).</param>
    ''' <param name="caracteristique">Les caractéristiques que doit avoir l'item pour être déposé.</param>
    ''' <returns>
    ''' True = Le bot a bien retiré l'item. <br/>
    ''' False = Le bot n'a pas réussi à retirer l'item.
    ''' </returns>
    Public Function Depose(ByVal index As String, ByVal nom As String, Optional ByVal quantite As String = "999999", Optional ByVal caracteristique As ClassItemCaractéristique = Nothing) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassItem In CopyItem(index, .Inventaire).Values

                    If Pair.Nom.ToLower = nom.ToLower OrElse Pair.IdObjet.ToString = nom Then

                        If Pair.Equipement = "" Then

                            If IsNothing(caracteristique) OrElse ComparateurCaractéristiqueObjets(Pair.Caractéristique, caracteristique) Then

                                If quantite > CInt(Pair.Quantité) Then quantite = Pair.Quantité

                                EcritureMessage(index, "(Bot)", "Dépose l'item " & Pair.Nom & " x " & quantite, Color.Gray)

                                .BloqueItem.Reset()

                                .Send("EMO+" & Pair.IdUnique & "|" & quantite)

                                Return .BloqueItem.WaitOne(15000)

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

                EcritureMessage(index, "(Bot)", "Erreur pour déposer l'item." & vbCrLf &
                                "Nom : " & nom, Color.Red)

            End Try

            Return False

        End With

    End Function



    ''' <summary>
    ''' Retourne un boolean si l'item existe ou non.
    ''' </summary>
    ''' <param name="index">Indique le numéro bot.</param>
    ''' <param name="nom">Nom/ID de l'item.</param>
    ''' <param name="caracteristique">Les caractéristiques que doit avoir l'item.</param>
    ''' <returns>
    ''' True = L'item existe dans l'inventaire. <br/>
    ''' False = L'item n'existe pas dans l'inventaire.
    ''' </returns>
    Public Function Existe(ByVal index As String, ByVal nom As String, Optional ByVal caracteristique As ClassItemCaractéristique = Nothing) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassItem In CopyItem(index, .Inventaire).Values

                    If Pair.Nom.ToLower = nom.ToLower Then

                        If IsNothing(caracteristique) OrElse ComparateurCaractéristiqueObjets(Pair.Caractéristique, caracteristique) Then

                            Return True

                        End If

                    End If

                Next

            Catch ex As Exception

                EcritureMessage(index, "(Bot)", "Erreur pour vérifier si l'item existe en inventaire." & vbCrLf &
                        "Nom : " & nom, Color.Red)

            End Try

            Return False

        End With

    End Function



    ''' <summary>
    ''' Equipe une item selon le nom/ID et les caractéristiques.
    ''' </summary>
    ''' <param name="index">Indique le numéro bot.</param>
    ''' <param name="nom">Nom/ID de l'item.</param>
    ''' <param name="caracteristique">Les caractéristiques que doit avoir l'item pour être equipé.</param>
    ''' <returns>
    ''' True = L'item est équipé. <br/>
    ''' False = L'item n'est pas équipé.
    ''' </returns>
    Public Function Equipe(ByVal index As String, ByVal nom As String, Optional ByVal caracteristique As ClassItemCaractéristique = Nothing) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassItem In CopyItem(index, .Inventaire).Values

                    If Pair.Nom.ToLower = nom.ToLower Then

                        If Pair.Equipement = "" Then

                            If IsNothing(caracteristique) OrElse ComparateurCaractéristiqueObjets(Pair.Caractéristique, caracteristique) Then

                                EcritureMessage(index, "(Bot)", "Equipe item : " & Pair.Nom, Color.Gray)

                                .BloqueItem.Reset()

                                .Send("OM" & Pair.IdUnique & "|" & RetourneEquipementCatégorie(index, Pair.Catégorie))

                                .BloqueItem.WaitOne(15000)

                                If .Inventaire.ContainsKey(Pair.IdUnique) AndAlso .Inventaire(Pair.IdUnique).Equipement <> "" Then

                                    Return True

                                Else

                                    Return False

                                End If

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

                EcritureMessage(index, "(Bot)", "Erreur pour équiper l'item voulu." & vbCrLf &
                        "Nom : " & nom, Color.Red)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Retourne le numéro pour savoir ou est équipé l'item.
    ''' </summary>
    ''' <param name="index">Indique le numéro bot.</param>
    ''' <param name="Categorie">La catégorie de l'item (amulette, anneaux, bottes, etc...)</param>
    ''' <returns>
    ''' Retourne le numéro pour savoir où est équipé l'item, si rien, retourne -1.
    ''' </returns>
    Private Function RetourneEquipementCatégorie(ByVal index As String, ByVal Categorie As Integer) As Integer

        With Comptes(index)

            Try

                Select Case Categorie

                    Case 1 'Amulette

                        Return 0

                    Case 5, 19, 8, 22, 7, 3, 4, 6, 20, 21, 83 'Arme

                        Return 1

                    Case 18 'Familier 

                        Return 8

                    Case 10 'Ceinture 

                        Return 3

                    Case 11 'Botte  

                        Return 5

                    Case 16 'Coiffe 

                        Return 6

                    Case 17, 81 'Cape/Sac

                        Return 7

                    Case 9 'Anneaux

                        Dim anneauxSuivant As Integer = 6

                        For Each Pair As ClassItem In CopyItem(index, .Inventaire).Values

                            If Pair.Catégorie = 9 Then

                                If Pair.Equipement = "4" OrElse Pair.Equipement = "2" Then

                                    anneauxSuivant -= (Pair.Equipement)

                                    If anneauxSuivant = 0 Then Exit For

                                End If

                            End If

                        Next

                        Return anneauxSuivant

                    Case 23 'Dofus

                        Dim dofusSuivant As Integer() = {9, 10, 11, 12, 13, 14}

                        For Each Pair As ClassItem In CopyItem(index, .Inventaire).Values

                            If Pair.Catégorie = 23 Then

                                If Pair.Equipement = "9" Then

                                    dofusSuivant(0) = 0

                                End If

                                If Pair.Equipement = "10" Then

                                    dofusSuivant(1) = 0

                                End If

                                If Pair.Equipement = "11" Then

                                    dofusSuivant(2) = 0

                                End If

                                If Pair.Equipement = "12" Then

                                    dofusSuivant(3) = 0

                                End If

                                If Pair.Equipement = "13" Then

                                    dofusSuivant(4) = 0

                                End If

                                If Pair.Equipement = "14" Then

                                    dofusSuivant(5) = 0

                                End If

                            End If

                        Next

                        For i = 0 To dofusSuivant.Count - 1

                            If dofusSuivant(i) > 0 Then

                                Return dofusSuivant(i)

                            End If

                        Next

                End Select

            Catch ex As Exception
            End Try

            Return -1

        End With

    End Function


    ''' <summary>
    ''' Déséquipe un item.
    ''' </summary>
    ''' <param name="index">Indique le numéro bot.</param>
    ''' <param name="nom">Nom/ID de l'item.</param>
    ''' <param name="caracteristique">Les caractéristiques que doit avoir l'item pour être déséquipé.</param>
    ''' <returns>
    ''' True = L'item est déséquipé. <br/>
    ''' False = L'item n'est pas déséquipé.
    ''' </returns>
    Public Function Desequipe(ByVal index As String, ByVal nom As String, Optional ByVal caracteristique As ClassItemCaractéristique = Nothing) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassItem In CopyItem(index, .Inventaire).Values

                    If Pair.Nom.ToLower = nom.ToLower Then

                        If Pair.Equipement <> "" Then

                            If IsNothing(caracteristique) OrElse ComparateurCaractéristiqueObjets(Pair.Caractéristique, caracteristique) Then

                                EcritureMessage(index, "(Bot)", "Déséquipe item : " & Pair.Nom, Color.Gray)

                                .BloqueItem.Reset()

                                .Send("OM" & Pair.IdUnique & "|-1")

                                .BloqueItem.WaitOne(15000)

                                If .Inventaire.ContainsKey(Pair.IdUnique) AndAlso .Inventaire(Pair.IdUnique).Equipement <> "" Then

                                    Return False

                                Else

                                    Return True

                                End If

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

                EcritureMessage(index, "(Bot)", "Erreur pour déséquiper l'item voulu." & vbCrLf &
                        "Nom : " & nom, Color.Red)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Jétte un objet au sol.
    ''' </summary>
    ''' <param name="index">Indique le numéro bot.</param>
    ''' <param name="nom">Nom/ID de l'item.</param>
    ''' <param name="quantité">La quantité à jeter (de base 999.999).</param>
    ''' <param name="caractéristique">Les caractéristiques que doit avoir l'item pour être jeté.</param>
    ''' <returns>
    ''' True = Le bot a bien jeté l'item. <br/>
    ''' False = Le bot n'a pas réussi à jeter l'item.
    ''' </returns>
    Public Function Jette(ByVal index As String, ByVal nom As String, Optional ByVal quantité As String = "999999", Optional ByVal caractéristique As ClassItemCaractéristique = Nothing) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassItem In CopyItem(index, .Inventaire).Values

                    If Pair.Nom.ToLower = nom.ToLower OrElse Pair.IdObjet.ToString = nom Then

                        If Pair.Equipement = "" Then

                            If IsNothing(caractéristique) OrElse ComparateurCaractéristiqueObjets(Pair.Caractéristique, caractéristique) Then

                                If quantité > CInt(Pair.Quantité) Then quantité = Pair.Quantité

                                EcritureMessage(index, "(Bot)", "Jette l'item " & Pair.Nom & " x " & quantité, Color.Gray)

                                .BloqueItem.Reset()

                                .Send("OD" & Pair.IdUnique & "|" & quantité)

                                Return .BloqueItem.WaitOne(15000)

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

                EcritureMessage(index, "(Bot)", "Erreur pour jeter l'item voulu." & vbCrLf &
                        "Nom : " & nom, Color.Red)

            End Try

            Return False

        End With

    End Function


    ''' <summary>
    ''' Utilise un objet de l'inventaire.
    ''' </summary>
    ''' <param name="index">Indique le numéro bot.</param>
    ''' <param name="nom">Nom/ID de l'item.</param>
    ''' <returns>
    ''' True = Le bot a bien utilisé l'item. <br/>
    ''' False = Le bot n'a pas réussi à utiliser l'item.
    ''' </returns>
    Public Function Utilise(ByVal index As String, ByVal nom As String) As Boolean

        With Comptes(index)

            Try

                For Each Pair As ClassItem In CopyItem(index, .Inventaire).Values

                If Pair.Nom.ToLower = nom.ToLower OrElse Pair.IdObjet.ToString = nom Then

                    EcritureMessage(index, "(Bot)", "Utilise l'item " & Pair.Nom, Color.Gray)

                    .BloqueItem.Reset()

                    .Send("OU" & Pair.IdUnique & "|")

                    Return .BloqueItem.WaitOne(15000)

                End If

            Next

            Catch ex As Exception

                EcritureMessage(index, "(Bot)", "Erreur pour utiliser l'item voulu." & vbCrLf &
                        "Nom : " & nom, Color.Red)

            End Try

            Return False

        End With

    End Function

End Class
