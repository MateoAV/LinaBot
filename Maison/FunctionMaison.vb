Public Class FunctionMaison

    Public Function CoffreOuvrir(ByVal index As Integer)

        With Comptes(index)

            For Each Pair As CInteraction In CopyInteraction(index, .Map.Interaction).Values

                If Pair.Nom.ToLower = "coffre" Then

                    For Each PairValue As KeyValuePair(Of String, Integer) In VarInteraction(Pair.Sprite).DicoInteraction

                        If PairValue.Key.ToLower = "ouvrir" Then

                            EcritureMessage(index, "[Intéraction]", "Le bot interagit avec '" & Pair.Nom & "' et effectue l'action : " & "ouvrir", Color.Orange)

                            ._Send = "GA500" & Pair.Cellule & ";" & PairValue.Value

                            .Personnage.InteractionCellule = Pair.Cellule

                            .Map.Bloque.Reset()

                            Dim newMap As New FunctionMap
                            newMap.Deplacement(index, Pair.Cellule)

                            Return .Map.Bloque.WaitOne(15000)

                        End If

                    Next

                End If

            Next

            Return False

        End With

    End Function

    Public Function CoffreFermer(ByVal index As Integer) As Boolean

        With Comptes(index)

            If .Echange.EnEchange Then

                .Map.Bloque.Reset()

                .Send("EV")

                Return .Map.Bloque.WaitOne(15000)

            End If

        End With

    End Function

End Class
