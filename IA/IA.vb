Module IA

    Public Sub IAChargement(ByVal index As Integer, ByVal chemin As String)

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

    Public Sub IABase(ByVal index As Integer)

        With Comptes(index)

            For i = 0 To .IntelligenceArtificielle.Count - 1

                Select Case Mid(.IntelligenceArtificielle(i).ToLower, 3)
                    Case "ava"
                        AvanceMobsProche(index)
                    Case "lan"
                        lancesort(index, Split(.IntelligenceArtificielle(i), " = ")(1))
                    Case "fin"

                End Select

            Next

        End With

    End Sub

    Private Sub lancesort(ByVal index As Integer, ByVal sort As Integer)

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


End Module
