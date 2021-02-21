Module IA

    Public Sub IAChargement(index As Integer, chemin As String)

        With Comptes(index)

            .IntelligenceArtificielle.Clear()

            Dim swLecture As IO.StreamReader = New IO.StreamReader(chemin, System.Text.Encoding.UTF7)

            Dim Balise As String = ""

            Do Until swLecture.EndOfStream

                Dim ligneActuel As String = AsciiDecoder(swLecture.ReadLine)

                ligneActuel = ligneActuel.Replace(vbTab, "")

                While ligneActuel.Contains("  ")
                    ligneActuel = ligneActuel.Replace("  ", " ")
                End While

                While ligneActuel.StartsWith(" ")
                    ligneActuel = Mid(ligneActuel, 2, ligneActuel.Length)
                End While

                .IntelligenceArtificielle.Add(ligneActuel.Replace(vbTab, ""))

            Loop

            swLecture.Close()

        End With

    End Sub

    Public Sub IABase(index As Integer)

        With Comptes(index)

            For Each pair As String In .IntelligenceArtificielle

                Dim euh = Mid(pair, 3)

                Select Case Mid(pair.ToLower, 1, 3)
                    Case "ava"
                        Avance(index)
                    Case "lan"
                        lancesort(index, Split(pair, " = ")(1))
                    Case "fin"

                End Select

            Next

        End With

    End Sub

    Private Sub lancesort(index As Integer, sort As String)

        With Comptes(index)

            Try


                Dim meilleurDistance As Integer = 999
                Dim meilleurCellule As Integer = 0

                For Each pair As CEntite In .Map.Entite.Values

                    If pair.IDUnique < 0 AndAlso .Combat.Entite(pair.IDUnique).Vivant Then

                        If goalDistance(.Map.Entite(.Personnage.ID).Cellule, pair.Cellule, .Map.Largeur) < meilleurDistance Then

                            meilleurDistance = goalDistance(.Map.Entite(.Personnage.ID).Cellule, pair.Cellule, .Map.Largeur)
                            meilleurCellule = pair.Cellule

                        End If

                    End If

                Next

                sort = ReturnIDSort(index, sort)

                AddBarreSort(index, sort)

                If goalDistance(.Map.Entite(.Personnage.ID).Cellule, meilleurCellule, .Map.Largeur) < 10 Then
                    .Combat.Bloque.Reset()

                    .Send("GA300" & sort & ";" & meilleurCellule)

                    .Combat.Bloque.WaitOne(15000)

                    Task.Delay(3000).Wait()
                End If

                If .Combat.EnCombat Then

                    .Send("GT")
                    .Send("Gt")

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub


    Private Function ReturnIDSort(index As Integer, sort As String) As Integer

        With Comptes(index)

            For Each pair As Dictionary(Of Integer, CSort) In VarSort.Values

                If pair.Values(0).ID.ToString = sort OrElse pair.Values(0).Nom.ToLower = sort.ToLower Then

                    Return pair.Values(0).ID

                End If

            Next

        End With

        Return 0

    End Function

    Private Function AddBarreSort(index As Integer, sort As String) As Boolean

        With Comptes(index)

            For Each pair As KeyValuePair(Of String, CSort) In .Sort

                If pair.Value.Nom.ToLower = sort.ToLower OrElse pair.Value.ID.ToString = sort Then

                    If pair.Value.BarreSort = "_" Then

                        Return .Send("SM" & pair.Value.ID & "|1",
                                    {"BN"})

                    End If

                End If

            Next

        End With

        Return True

    End Function

End Module
