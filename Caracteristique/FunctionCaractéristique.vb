Public Class FunctionCaractéristique

    Private Delegate Function dlgCharacteristic()

    ''' <summary>
    ''' Permet de Up la caractéristique voulu.
    ''' </summary>
    ''' <param name="index">Indique le compte.</param>
    ''' <param name="caracteristique">Indique la caractéristique. Exemple : Vitalité, Sagesse, etc...</param>
    ''' <returns>Retourne 'True' s'il a Up, sinon 'False'</returns>
    Public Function Up(ByVal index As String, ByVal caracteristique As String) As Boolean

        With Comptes(index)

            Try

                If CaracteristiqueUpPossible(index, caracteristique) Then

                    .BloqueCaracteristique.Reset()

                    Select Case caracteristique.ToLower

                        Case "vitalité", "vitaliter"

                            .Send("AB11")

                        Case "sagesse"

                            .Send("AB12")

                        Case "force"

                            .Send("AB10")

                        Case "chance"

                            .Send("AB13")

                        Case "intelligence"

                            .Send("AB15")

                        Case "agilité", "agiliter"

                            .Send("AB14")

                    End Select

                    Return .BloqueCaracteristique.WaitOne(15000)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "FunctionCaracteristiqueUp", caracteristique & vbCrLf & ex.Message)

            End Try

            Return False

        End With

    End Function

    ''' <summary>
    ''' Vérifier si le personnage a assé de point pour up la caractéristique.
    ''' </summary>
    ''' <param name="index">Indique le compte.</param>
    ''' <param name="caracteristique">Indique la caractéristique à vérifier.</param>
    ''' <returns>Retourne 'True' s'il peut Up la caractéristique, sinon 'False'</returns>
    Private Function CaracteristiqueUpPossible(ByVal index As Integer, ByVal caracteristique As String) As Boolean

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                    Return .FrmUser.Invoke(New dlgCharacteristic(Function() CaracteristiqueUpPossible(index, caracteristique)))

                Else

                    If .Personnage.ClasseSexe <> Nothing Then

                        For Each pair As KeyValuePair(Of String, String()) In VarCaractéristique(VarPersonnage(CInt(.Personnage.ClasseSexe)).Nom)

                            For i = 2 To pair.Value.Count - 1

                                If caracteristique.ToLower = pair.Key.ToLower Then

                                    If .Personnage.Caractéristique(caracteristique).Base >= Split(pair.Value(i), ">")(0) AndAlso .Personnage.Caractéristique(caracteristique).Base <= Split(pair.Value(i), ">")(1) Then

                                        If .Personnage.CapitalCaractéristique >= Split(pair.Value(i), ">")(2) Then

                                            Return True

                                        End If

                                    End If

                                End If

                            Next

                        Next

                    End If

                    Return False

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "FunctionCaracteristiqueUpPossible", caracteristique & vbCrLf & ex.Message)

            End Try

            Return False

        End With

    End Function

    ''' <summary>
    ''' Retourne la valeur indiqué selon la caractéristique et le choix voulu.
    ''' </summary>
    ''' <param name="index">Indique le compte</param>
    ''' <param name="caracteristique">Indique la caractéristique. Exemple : Vitalité, Sagesse, etc...</param>
    ''' <param name="choix">Indique le choix : 'Base' , 'Equipement' , 'Dons' , 'Boosts' , 'Total'</param>
    ''' <returns>Retourne la valeur qui correspond à la caractéristique et au choix, sinon retourne '0'</returns>
    Public Function [Return](ByVal index As String, ByVal caracteristique As String, ByVal choix As String) As String

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                    Return .FrmUser.Invoke(New dlgCharacteristic(Function() [Return](index, caracteristique, choix)))

                Else

                    Select Case choix.ToLower

                        Case "base"

                            Return .Personnage.Caractéristique(caracteristique).Base

                        Case "equipement", "équipement"

                            Return .Personnage.Caractéristique(caracteristique).Equipement

                        Case "don", "dons"

                            Return .Personnage.Caractéristique(caracteristique).Dons

                        Case "boost", "boosts"

                            Return .Personnage.Caractéristique(caracteristique).Boost

                        Case "total", "totals"

                            Return .Personnage.Caractéristique(caracteristique).Total

                        Case Else

                            Return "0"

                    End Select

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "FunctionCaracteristiqueReturn", caracteristique & vbCrLf & choix & vbCrLf & ex.Message)

            End Try

            Return "0"

        End With

    End Function

    ''' <summary>
    ''' Retourne l'energie du personnage.
    ''' </summary>
    ''' <param name="index">Indique le compte.</param>
    ''' <param name="choix">'Actuelle' , 'Maximum' , 'Pr' (Pr = Pourcentage)</param>
    ''' <returns>Retourne la valeur selon le choix indiqué, sinon retourne '0'.</returns>
    Public Function Energie(ByVal index As String, ByVal choix As String) As String

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlgCharacteristic(Function() Energie(index, choix)))

            Else

                Select Case choix.ToLower

                    Case "actuelle", "actuel"

                        Return .Personnage.Energie.Actuelle

                    Case "maximum"

                        Return .Personnage.Energie.Maximum

                    Case "pr"

                        Return .Personnage.Energie.Pourcentage

                    Case Else

                        Return "0"

                End Select

            End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "FunctionCaracteristiqueEnergie", choix & vbCrLf & ex.Message)

            End Try

            Return "0"

        End With

    End Function

    ''' <summary>
    ''' Retourne le niveau du personnage.
    ''' </summary>
    ''' <param name="index">Indique le compte.</param>
    ''' <returns>Retourne le niveau actuelle du personnage, sinon retourne 0.</returns>
    Public Function Niveau(ByVal index As String) As String

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlgCharacteristic(Function() Niveau(index)))

            Else

                Return .Personnage.Niveau

            End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "FunctionCaracteristiqueNiveau", ex.Message)

            End Try

            Return "0"

        End With

    End Function

    ''' <summary>
    ''' Retourne l'expèrience du personnage.
    ''' </summary>
    ''' <param name="index">Indique le compte.</param>
    ''' <param name="choix">'Actuelle' , 'Maximum' , 'Minimum' , 'Pr' (Pr = Pourcentage)</param>
    ''' <returns>Retourne la valeur selon le choix indiqué, sinon retourne '0'.</returns>
    Public Function Experience(ByVal index As String, ByVal choix As String) As String

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                    Return .FrmUser.Invoke(New dlgCharacteristic(Function() Experience(index, choix)))

                Else

                    Select Case choix.ToLower

                        Case "minimum"

                            Return .Personnage.Expérience.Minimum

                        Case "actuelle", "actuel"

                            Return .Personnage.Expérience.Actuelle

                        Case "maximum"

                            Return .Personnage.Expérience.Maximum

                        Case "pr"

                            Return .Personnage.Expérience.Pourcentage

                        Case Else

                            Return "0"

                    End Select

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, choix & vbCrLf & "FunctionCaracteristiqueExperience", ex.Message)

            End Try

            Return "0"

        End With

    End Function

    ''' <summary>
    ''' Permet d'avoir le nombre de point de vie du personnage.
    ''' </summary>
    ''' <param name="index">Indique le compte.</param>
    ''' <param name="choix">'Actuelle' , 'Maximum' , 'Pr'</param>
    ''' <returns>Retourne la valeur selon le choix indiqué, sinon retourne '0'.</returns>
    Public Function PointDeVie(ByVal index As String, ByVal choix As String) As String

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                    Return .FrmUser.Invoke(New dlgCharacteristic(Function() PointDeVie(index, choix)))

                Else

                    Select Case choix.ToLower

                    Case "actuelle", "actuel"

                        Return .Personnage.Vitalité.Actuelle

                    Case "maximum"

                        Return .Personnage.Vitalité.Maximum

                    Case "pr"

                        Return .Personnage.Vitalité.Pourcentage

                    Case Else

                        Return "0"

                End Select

            End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, choix & vbCrLf & "FunctionCaracteristiquePointDeVie", choix & vbCrLf & ex.Message)

            End Try

            Return "0"

        End With

    End Function

End Class
