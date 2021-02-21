Module Avancer

    Public Function Avance(index As Integer)

        With Comptes(index)

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

            If goalDistance(.Map.Entite(.Personnage.ID).Cellule, meilleurCellule, .Map.Largeur) > 1 Then

                Dim newPath As New Pathfinding(index)
                Dim path As String = newPath.pathing(meilleurCellule, False, True, False, True, .Combat.Entite(.Personnage.ID).PM)

                If path <> "" Then

                    .BloqueDeplacement.Reset()

                    .Send("GA001" & path)

                    .BloqueDeplacement.WaitOne(15000)

                    Task.Delay(1000).Wait()

                End If

            End If

            Return True

        End With

    End Function

End Module
