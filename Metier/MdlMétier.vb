Module MdlMétier

    Public Sub GiMetierModePublic(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                'EW + OU -

                For Each Pair As KeyValuePair(Of String, ClassMétier) In .Métier

                    With Pair.Value

                        Select Case Mid(data, 3)

                            Case "+"

                                .ModePublic = True

                            Case "-"

                                .ModePublic = False

                        End Select

                    End With

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiMétierModePublic", data & vbCrLf & ex.Message)

            End Try

            .BloqueMétier.Set()

        End With

    End Sub

    Public Sub GiMétierInformation(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' JS | 17        ; 142                   ~ 2                    ~ 0                    ~ 0 ~ 70                  , next info métier actuel | Nex métier
                ' JS | ID_Métier ; ID_Atelier/ressources ~ Nbr_Case/Récolte min ~ Nbr_Case/Récolte max ~ ? ~ %_Réussite ou temps ,                         |

                Dim separateData As String() = Split(data, "|")

                For i = 1 To separateData.Count - 1

                    Dim separate As String() = Split(separateData(i), ";")

                    Dim idJob As Integer = separate(0)

                    separate = Split(separate(1), ",")

                    Dim newMétier As New ClassMétier

                    With newMétier

                        .ID = idJob
                        .Nom = VarMétier(idJob).Nom

                        .AtelierRessource = New Dictionary(Of String, ClassMétierAtelierRessource)

                        For a = 0 To separate.Count - 1

                            Dim separateCraft As String() = Split(separate(a), "~")

                            Dim newMétierAtelierRessource As New ClassMétierAtelierRessource

                            With newMétierAtelierRessource

                                .ID = separateCraft(0)
                                .Nom = VarMétier(idJob).Workshop(separateCraft(0)).GetValue(0)
                                .NombreCaseRécolteMinimum = separateCraft(1)
                                .NombreCaseRécolteMaximum = separateCraft(2)
                                .TempsRéussite = separateCraft(4)
                                .NomAction = VarMétier(idJob).Workshop(separateCraft(0)).GetValue(1)

                            End With

                            If .AtelierRessource.ContainsKey(newMétierAtelierRessource.Nom.ToLower) Then

                                .AtelierRessource(newMétierAtelierRessource.Nom.ToLower) = newMétierAtelierRessource

                            Else

                                .AtelierRessource.Add(newMétierAtelierRessource.Nom.ToLower, newMétierAtelierRessource)

                            End If

                        Next

                    End With

                    If .Métier.ContainsKey(newMétier.Nom.ToLower) Then

                        With .Métier(newMétier.Nom.ToLower)

                            newMétier.ExpérienceActuelle = .ExpérienceActuelle
                            newMétier.ExpérienceMaximum = .ExpérienceMaximum
                            newMétier.ExpérienceMinimum = .ExpérienceMinimum
                            newMétier.GratuitSurEchec = .GratuitSurEchec
                            newMétier.ItemEquipé = .ItemEquipé
                            newMétier.ModePublic = .ModePublic
                            newMétier.NeFournitAucuneRessource = .NeFournitAucuneRessource
                            newMétier.Niveau = .Niveau
                            newMétier.NombreIngrédientMinimum = .NombreIngrédientMinimum
                            newMétier.Payant = .Payant

                        End With

                        .Métier(newMétier.Nom.ToLower) = newMétier

                    Else

                        .Métier.Add(newMétier.Nom.ToLower, newMétier)

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiMétierInformation", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Public Sub GiMétierUp(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                'JN 28        | 73
                'JN ID Métier | Level

                data = Mid(data, 3)

                Dim separateData As String() = Split(data, "|")

                If .Métier.ContainsKey(VarMétier(separateData(0)).Nom.ToLower) Then

                    .Métier(VarMétier(separateData(0)).Nom.ToLower).Niveau = separateData(1)

                End If

                EcritureMessage(index, "(Dofus)", "Ton métier " & VarMétier(separateData(0)).Nom & " passe niveau " & separateData(1) & ".", Color.Green)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiMétierUp", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Public Sub GiMétierExpèrience(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' JX | 17         ; 42     ; 41044   ; 43205      ; 43378   ; ? |
                ' JX | ID_Métiers ; Niveau ; Exp_Min ; Exp_actuel ; Exp_Max ;   | Métier_Suivant

                Dim separateData As String() = Split(data, "|")

                For i = 1 To separateData.Count - 1

                    Dim separate As String() = Split(separateData(i), ";")

                    If separate(4) < 0 Then separate(4) = separate(3)

                    If .Métier.ContainsKey(VarMétier(separate(0)).Nom.ToLower) Then

                        With .Métier(VarMétier(separate(0)).Nom.ToLower)

                            .Niveau = separate(1)
                            .ExpérienceMinimum = separate(2)
                            .ExpérienceActuelle = separate(3)
                            .ExpérienceMaximum = separate(4)

                        End With

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiMétierExpèrience", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Public Sub GiMétierOption(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                'JO 0             | 4                      | 5
                'JO Numéro_Métier | Nombre_Pour_Check_Case | Nbr minimum ingrédient 

                data = Mid(data, 3)

                Dim separateData As String() = Split(data, "|")

                For Each pair As KeyValuePair(Of String, ClassMétier) In .Métier

                    If CInt(separateData(0)) = 0 Then

                        With pair.Value

                            .Payant = False
                            .NeFournitAucuneRessource = False
                            .GratuitSurEchec = False
                            .NombreIngrédientMinimum = separateData(2)

                            While CInt(separateData(1)) > 0

                                Select Case separateData(1)

                                    Case >= 4 'Ne Fournit aucune ressource

                                        .NeFournitAucuneRessource = True
                                        separateData(1) = CInt(separateData(1)) - 4

                                    Case >= 2 'Gratuit sur échec

                                        .GratuitSurEchec = True
                                        separateData(1) = CInt(separateData(1)) - 2

                                    Case >= 1 'Payant

                                        .Payant = True
                                        separateData(1) = CInt(separateData(1)) - 1

                                End Select

                            End While

                        End With

                        Return

                    Else

                        separateData(0) = CInt(separateData(0)) - 1

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiMétierOption", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Public Sub GiMétierSupprime(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' JR 56
                ' JR id métier

                data = Mid(data, 3)

                If .Métier.ContainsKey(VarMétier(data).Nom.ToLower) Then

                    .Métier.Remove(VarMétier(data).Nom.ToLower)

                End If

                EcritureMessage(index, "[Dofus]", "Tu as désappris le métier " & VarMétier(data).Nom & ".", Color.Green)

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiMétierSupprime", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

End Module
