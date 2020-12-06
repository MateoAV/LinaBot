Public Class FunctionMaison

    Public Function CoffreOuvrir(ByVal index As Integer)

        With Comptes(index)

            For Each Pair As ClassInteraction In CopyDicoInteraction(index, .Interaction).Values

                If Pair.Nom.ToLower = "coffre" Then

                    For Each PairValue As KeyValuePair(Of String, Integer) In VarInteraction(Pair.Sprite).DicoInteraction

                        If PairValue.Key.ToLower = "ouvrir" Then

                            EcritureMessage(index, "[Intéraction]", "Le bot interagit avec '" & Pair.Nom & "' et effectue l'action : " & "ouvrir", Color.Orange)

                            ._Send = "GA500" & Pair.Cellule & ";" & PairValue.Value

                            .InteractionCellID = Pair.Cellule

                            .BloqueInteraction.Reset()

                            Dim newMap As New Class_Map
                            newMap.Déplacement(index, Pair.Cellule)

                            Return .BloqueInteraction.WaitOne(15000)

                        End If

                    Next

                End If

            Next

            Return False

        End With

    End Function

    Public Function CoffreFermer(ByVal index As Integer) As Boolean

        With Comptes(index)

            .BloqueInteraction.Reset()

            .Send("EV")

            Return .BloqueInteraction.WaitOne(15000)

        End With

    End Function

End Class
