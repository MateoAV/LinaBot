Public Class FunctionZaap


    Public Function Utiliser(index As Integer) As Boolean

        With Comptes(index)

            For Each pair As CInteraction In CopyInteraction(index, .Map.Interaction).Values

                If pair.Nom = "Zaap" Then

                    '
                    Dim path As New Pathfinding(index)
                    Dim chemin As String = path.pathing("455")
                    If chemin <> "" Then
                        .Send("GA001" & chemin, {"wait ici"})
                        'puis end
                        Return .Send("GA500" & pair.Cellule & ";114", {"wait"})

                    End If

                        '

                        EcritureMessage(index, "(Bot)", "Utilisation du Zaap en cours (CellID : " & pair.Cellule & ").", Color.Lime)

                    ._Send = "GA500" & pair.Cellule & ";114"

                    Dim newMap As New FunctionMap
                    newMap.Deplacement(index, pair.Cellule)

                    Exit For

                End If

            Next

            Return .Personnage.EnInteraction

        End With


    End Function

    Public Function Sauvegarder(index As Integer) As Boolean

        With Comptes(index)

            For Each pair As CInteraction In CopyInteraction(index, .Map.Interaction).Values

                If pair.Nom = "Zaap" Then

                    EcritureMessage(index, "(Bot)", "Sauvegarde du Zaap en cours (CellID : " & pair.Cellule & ").", Color.Lime)

                    ._Send = "GA500" & pair.Cellule & ";44"

                    Dim newMap As New FunctionMap
                    newMap.Deplacement(index, pair.Cellule)

                    Return True

                    Exit For

                End If

            Next

            Return False

        End With


    End Function

    Public Function Destination(ByVal index As Integer, ByVal _map As String) As Boolean

        With Comptes(index)

            If .Personnage.EnInteraction Then

                If Not IsNumeric(_map) Then

                    For Each pair As KeyValuePair(Of Integer, String) In VarMap

                        If pair.Value = _map Then

                            If .ZaapI.ContainsKey(pair.Key) Then

                                _map = pair.Key

                                Exit For

                            End If

                        End If

                    Next

                End If

                If Not IsNumeric(VarMap) Then

                    EcritureMessage(index, "(Bot)", "Le bot n'a pas trouvé la map voulu dans les maps enregistré du Zaap.", Color.Red)

                    Return False

                End If

                If .ZaapI.ContainsKey(_map) Then

                    If .Personnage.Kamas >= .ZaapI(_map) Then

                        .Map.Bloque.Reset()

                        .Send("WU" & _map,
                             {"GDM"}) ' Change de Map.

                        EcritureMessage(index, "[Dofus]", "Vous avez payé " & .ZaapI(_map) & " pour utiliser le Zaap.", Color.Lime)

                    End If

                End If

            End If

            If _map = .Map.ID Then

                Return True

            End If

            Return False

        End With

    End Function

    Public Function Quitte(ByVal index As Integer) As Boolean

        With Comptes(index)

            If .Personnage.EnInteraction Then

                .Map.Bloque.Reset()

                .Send("WV")

                Return .Map.Bloque.WaitOne(15000)

            End If

            Return False

        End With

    End Function

End Class
