﻿
Module MdlInteraction

    Public Sub GiInteractionEnJeu(index As Integer, data As String)

        With Comptes(index)

            Try

                'GDF | 206     ; 3    ; 0
                'GDF | Cellule ; Etat ; Utilisation                

                ' I separate the data by this sign "|"
                Dim separateData As String() = Split(data, "|")

                For i = 1 To separateData.Count - 1

                    ' I separate the data by this sign ";"
                    Dim separate As String() = Split(separateData(i), ";")

                    If .Map.Interaction.ContainsKey(separate(0)) Then

                        With .Map.Interaction(separate(0))

                            Select Case separate(2)

                                Case "0" ' Utilisation une personne

                                    Select Case separate(1) 'State now

                                        Case 2 'In Cut

                                            .Information = "en utilisation"

                                        Case 3, 4 'Cut

                                            .Information = "indisponible"

                                            If separate(0) = Comptes(index).Personnage.InteractionCellule Then

                                                Comptes(index).Recolte.EnRecolte = False
                                                Comptes(index).Personnage.EnInteraction = False

                                            End If

                                    End Select

                                Case "1" 'Utilisation possible

                                    .Information = "disponible"

                                Case Else

                                    EcritureMessage(index, "[Récolte]", "L'état de la ressource '" & .Nom & "' est inconnu, cellid : " & separate(0) & " Etat : " & separate(2), Color.Red)

                            End Select

                        End With

                        If separate(0) = .Personnage.InteractionCellule Then

                            .Map.Bloque.Set()

                        End If

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiInteractionEnJeu", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

End Module

#Region "Class"

Public Class CInteraction

    Public Cellule As Integer
    Public Sprite As Integer
    Public Nom As String
    Public Information As String
    Public Action As New Dictionary(Of String, Integer)

End Class

#End Region
