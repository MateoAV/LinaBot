Public Class FunctionMetier

    ''' <summary>
    ''' Change les options des métiers, payant, gratuit, etc.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="nomID">Le nom ou l'ID du métier.</param>
    ''' <param name="payant">True = payant. <br/> False = non payant.</param>
    ''' <param name="gratuitSurEchec">True = Gratuit si échec. <br/> False = Payant même si échec.</param>
    ''' <param name="neFournitAucuneRessource">True = Fournit aucune ressource pour le craft. <br/> False = peut fournir des ressources pour le craft..</param>
    ''' <param name="nombreIngredientMinimum">Le nombre d'ingrédient minimum pour effectuer un craft.</param>
    ''' <returns>
    ''' True = Option bien changé. <br/>
    ''' False = Option non changé.
    ''' </returns>
    Public Function [Option](ByVal index As Integer, ByVal nomID As String, ByVal payant As Boolean, ByVal gratuitSurEchec As Boolean, ByVal neFournitAucuneRessource As Boolean, ByVal nombreIngredientMinimum As Integer) As Boolean

        With Comptes(index)

            Try

                Dim numeroMetier As Integer = 0
                Dim NbrOption As Integer

                For Each pair As KeyValuePair(Of String, CMetierInformation) In .Metier.Metier

                    If pair.Value.Nom.ToLower = nomID.ToLower OrElse pair.Value.ID = nomID Then

                        If payant Then

                            NbrOption += 1

                        End If

                        If gratuitSurEchec Then

                            NbrOption += 2

                        End If

                        If neFournitAucuneRessource Then

                            NbrOption += 4

                        End If

                        .Socket.Envoyer("JO" & numeroMetier & "|" & NbrOption & "|" & nombreIngredientMinimum)

                        Return True

                    End If

                    numeroMetier += 1

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "Metier[Option]", ex.Message)

            End Try

            Return False

        End With

    End Function

    ''' <summary>
    ''' Active/Désactive le mode public.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="activer">
    ''' True = Activer le mode Public (tout le monde peut vous voir). <br/> 
    ''' False = Désactive le mode public (personne vous voit).
    ''' </param>
    ''' <returns>
    ''' True = l'action a réussie. <br/>
    ''' False = l'action a échoué.
    ''' </returns>
    Public Function ModePublic(ByVal index As Integer, ByVal activer As Boolean) As Boolean

        With Comptes(index)

            Try

                .Metier.Bloque.Reset()

                If activer Then

                    .Socket.Envoyer("EW+")

                Else

                    .Socket.Envoyer("EW-")

            End If

                Return .Metier.Bloque.WaitOne(15000)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "MetierModePublic", ex.Message)

            End Try

            Return False

        End With

    End Function

End Class
