Public Class FunctionInteraction

    'Faire en orte que le bot cherche linteraction la plus proche selon ou se trouve le joueur, qui correspond à celle voulu.

    Public Sub InteractionEnJeu(ByVal index As String, ByVal nomInteraction As String, ByVal action As String)

        With Comptes(index)

            For Each Pair As CInteraction In CopyInteraction(index, .Map.Interaction).Values

                If Pair.Nom.ToLower = nomInteraction.ToLower Then

                    For Each PairValue As KeyValuePair(Of String, Integer) In VarInteraction(Pair.Sprite).DicoInteraction

                        If PairValue.Key.ToLower = action.ToLower Then

                            EcritureMessage(index, "[Intéraction]", "Le bot interagit avec '" & Pair.Nom & "' et effectue l'action : " & action, Color.Orange)

                            ._Send = "GA500" & Pair.Cellule & ";" & PairValue.Value

                            Dim newMap As New FunctionMap
                            newMap.Deplacement(index, Pair.Cellule)

                            Return

                        End If

                    Next

                End If

            Next

        End With

    End Sub

    Public Sub InteractionQuitte(ByVal index As Integer, ByVal choix As String)

        With Comptes(index)

            If .Personnage.EnInteraction Then

                .Map.Bloque.Reset()

                Select Case choix.ToLower

                    Case "zaap"

                        .Send("WV")

                    Case Else

                        .Send("EV")

                End Select

                .Map.Bloque.WaitOne(15000)

            End If

        End With

    End Sub

End Class
