Public Class Class_HDV
    Public Function Acheter(ByVal index As String) As Boolean

        With Comptes(index)

            For Each pair As KeyValuePair(Of Integer, ClassEntite) In .Map.Entite

                If VarPnj.ContainsKey(pair.Value.ID) Then

                    .Pnj.BloquePnj.Reset()

                    .Send("ER11|" & pair.Value.IDUnique)

                    Return .Pnj.BloquePnj.WaitOne(15000)

                End If

            Next

            Return False

        End With

    End Function

    Public Function Vendre(ByVal index As String) As Boolean

        With Comptes(index)

            For Each pair As KeyValuePair(Of Integer, ClassEntite) In .Map.Entite

                If VarPnj.ContainsKey(pair.Value.ID) Then

                    .Pnj.BloquePnj.Reset()

                    .Send("ER10|" & pair.Value.IDUnique)

                    Return .Pnj.BloquePnj.WaitOne(15000)

                End If

            Next

            Return False

        End With

    End Function

    Public Function Categorie(ByVal index As String, ByVal choix As String) As Boolean

        With Comptes(index)

            If .Pnj.EnHdvAchat OrElse .Pnj.EnHdvVente Then

                .Pnj.BloquePnj.Reset()

                Select Case choix.ToLower

                    Case "arc"

                        .Send("EHT2")

                    Case "baton"

                        .Send("EHT4")

                    Case "baguette"

                        .Send("EHT3")

                End Select

                Return .Pnj.BloquePnj.WaitOne(15000)

            End If

        End With

        Return False

    End Function

    Public Function SelectionneItem(ByVal index As String, ByVal choix As String) As Boolean

        With Comptes(index)

            If .Pnj.EnHdvAchat OrElse .Pnj.EnHdvVente Then

                .Pnj.BloquePnj.Reset()

                .Send("EHP" & VarItems(choix).ID)
                .Send("EHl" & VarItems(choix).ID)

                Return .Pnj.BloquePnj.WaitOne(15000)

            End If

        End With

        Return False

    End Function

    Public Function Achete(ByVal index As String, ByVal item As String, ByVal kamasUniter As String) As Boolean

        With Comptes(index)

            If .Pnj.EnHdvAchat OrElse .Pnj.EnHdvVente Then

                Dim boucle As Boolean = True

                While boucle

                    For Each pair As KeyValuePair(Of Integer, ClassHDVItem) In .Pnj.HotelDeVente.ListeItem

                        If VarItems(pair.Value.IdObjet).Nom.ToLower = item.ToLower OrElse pair.Value.IdObjet = item Then

                            boucle = False

                            If pair.Value.Prix100 <= CInt(kamasUniter * 100) Then

                                If .Personnage.Kamas >= CInt(kamasUniter * 100) Then

                                    .Pnj.BloquePnj.Reset()

                                    .Send("EHB" & pair.Key & "|3|" & pair.Value.Prix100)

                                    .Pnj.BloquePnj.WaitOne(15000)

                                    Task.Delay(1000).Wait()

                                    boucle = True

                                End If

                            End If

                            If pair.Value.Prix10 <= CInt(kamasUniter * 10) Then

                                If .Personnage.Kamas >= CInt(kamasUniter * 10) Then

                                    .Pnj.BloquePnj.Reset()

                                    .Send("EHB" & pair.Key & "|2|" & pair.Value.Prix10)

                                    .Pnj.BloquePnj.WaitOne(15000)

                                    Task.Delay(1000).Wait()

                                    boucle = True

                                End If

                            End If

                            If pair.Value.Prix1 <= CInt(kamasUniter) Then

                                If .Personnage.Kamas >= CInt(kamasUniter) Then

                                    .Pnj.BloquePnj.Reset()

                                    .Send("EHB" & pair.Key & "|1|" & pair.Value.Prix1)

                                    .Pnj.BloquePnj.WaitOne(15000)

                                    Task.Delay(1000).Wait()

                                    boucle = True

                                End If

                            End If

                        End If

                    Next

                End While

            End If

        End With

        Return False

    End Function

    Public Function Quitte(ByVal index As String) As Boolean

        With Comptes(index)

            If .Pnj.EnHdvAchat OrElse .Pnj.EnHdvVente Then

                .Pnj.BloquePnj.Reset()

                .Send("EV")

                Return .Pnj.BloquePnj.WaitOne(15000)

            End If

            Return False

        End With

    End Function

    Public Function Vente(ByVal index As String, ByVal item As String, ByVal quantiter As String, ByVal prix As String) As Boolean

        With Comptes(index)

            If .Pnj.EnHdvAchat OrElse .Pnj.EnHdvVente Then

                For Each pair As KeyValuePair(Of Integer, ClassItem) In .Inventaire

                    If pair.Value.Nom.ToLower = item.ToLower OrElse pair.Value.IdObjet = item Then

                        If pair.Value.Quantité >= quantiter Then

                            Dim quantiterVoulu As String = "3"

                            Select Case quantiter

                                Case "1"

                                    quantiterVoulu = "1"

                                Case "10"

                                    quantiterVoulu = "2"

                                Case "100"

                                    quantiterVoulu = "3"

                            End Select

                            .Pnj.BloquePnj.Reset()

                            .Send("EMO+" & pair.Key & "|" & quantiterVoulu & "|" & prix)

                            Return .Pnj.BloquePnj.WaitOne(15000)

                        End If

                    End If

                Next

            End If

            Return False

        End With

        Return False

    End Function


End Class
