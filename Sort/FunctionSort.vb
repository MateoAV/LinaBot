Public Class FunctionSort

    Public Function Up(ByVal index As String, ByVal nom As String) As Boolean

        With Comptes(index)

            Try

                If .Sort.ContainsKey(nom) Then

                    If .Personnage.Niveau >= .Sort(nom).NiveauRequisUp Then

                        If .Personnage.CapitalSort >= .Sort(nom).Niveau Then

                            .BloqueSort.Reset()

                            .Send("SB" & .Sort(nom).ID)

                            Return .BloqueSort.WaitOne(30000)

                        End If

                    End If

                End If

                Return False

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

        End With

    End Function

    Public Function [Return](ByVal index As String, ByVal nom As String, ByVal choix As String) As String

        With Comptes(index)

            If .Sort.ContainsKey(nom.ToLower) Then

                Select Case choix.ToLower

                    Case "id"

                        Return .Sort(nom.ToLower).ID

                    Case "niveaux du sort"

                        Return .Sort(nom.ToLower).Niveau

                    Case "nom"

                        Return .Sort(nom.ToLower).Nom

                    Case "po minimum"

                        Return .Sort(nom.ToLower).POMinimum

                    Case "po maximum"

                        Return .Sort(nom.ToLower).POMaximum

                    Case "pa"

                        Return .Sort(nom.ToLower).PA

                    Case "nombre de lancers par tour"

                        Return .Sort(nom.ToLower).NombreLancerParTour

                    Case "nombre de lancers par tour par joueur"

                        Return .Sort(nom.ToLower).NombreLancerParTourParJoueur

                    Case "nombre de tours entre deux lancers"

                        Return .Sort(nom.ToLower).NombreToursEntreDeuxLancers

                    Case "po modifiable"

                        Return .Sort(nom.ToLower).POModifiable

                    Case "ligne de vue"

                        Return .Sort(nom.ToLower).LigneDeVue

                    Case "lancer en ligne"

                        Return .Sort(nom.ToLower).LancerEnLigne

                    Case "cellules libres"

                        Return .Sort(nom.ToLower).CelluleLibre

                    Case "ec fini le tour"

                        Return .Sort(nom.ToLower).ECFiniTour

                    Case "zone minimum"

                        Return .Sort(nom.ToLower).ZoneMinimum

                    Case "zone maximum"

                        Return .Sort(nom.ToLower).ZoneMaximum

                    Case "zone effet"

                        Return .Sort(nom.ToLower).ZoneEffet

                    Case "niveau requis"

                        Return .Sort(nom.ToLower).NiveauRequisUp

                    Case "sort classe"

                        Return .Sort(nom.ToLower).SortClasse

                    Case "definition"

                        Return .Sort(nom.ToLower).Definition

                    Case "barre sort"

                        Return .Sort(nom.ToLower).BarreSort

                    Case Else

                        Return "nothing"

                End Select

            End If

            Return "nothing"

        End With

    End Function

    Public Function Placement(ByVal index As String, ByVal nom As String, ByVal barreSort As String) As Boolean

        With Comptes(index)

            If .Sort.ContainsKey(nom.ToLower) Then

                .BloqueSort.Reset()

                .Send("SM" & .Sort(nom).ID & "|" & barreSort)

                Return .BloqueSort.Set()

            End If

            Return False

        End With

    End Function

End Class
