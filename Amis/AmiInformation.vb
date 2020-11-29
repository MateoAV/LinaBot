Module AmiInformation

    Sub GiAmiEnnemi(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                'FL | Leroienculeurné ; 1      ; Linaculers   ; 1     ; 0           ; 7         ; 1    ; 71 
                'FL | Pseudo          ; en ami ; Nom          ; Level ; alignement  ; id classe ; Sexe ; classe + sexe

                Dim separateData As String() = Split(data, "|")

                .Ami.Ami.Clear()
                .Ami.Ennemi.Clear()

                If separateData.Length > 1 Then

                    For i = 1 To separateData.Count - 1

                        Dim separate As String() = Split(separateData(i), ";")

                        Dim newFriend As New ClassAmiInformation

                        With newFriend

                            If separate.Length > 1 Then

                                .Pseudo = separate(0)
                                .EnAmi = separate(1)
                                .Nom = separate(2)
                                .Niveau = separate(3)

                                Select Case separate(4)

                                    Case "0"

                                        .Alignement = "Neutre"

                                    Case "1"

                                        .Alignement = "Bontarien"

                                    Case "2"

                                        .Alignement = "Brakmarien"

                                    Case Else

                                        .Alignement = "Inconnu"

                                End Select

                                Select Case separate(5)

                                    Case "1"

                                        .Classe = "Feca"

                                    Case "2"

                                        .Classe = "Osamodas"

                                    Case "3"

                                        .Classe = "Enutrof"

                                    Case "4"

                                        .Classe = "Sram"

                                    Case "5"

                                        .Classe = "Xelor"

                                    Case "6"

                                        .Classe = "Ecaflip"

                                    Case "7"

                                        .Classe = "Eniripsa"

                                    Case "8"

                                        .Classe = "Iop"

                                    Case "9"

                                        .Classe = "Cra"

                                    Case "10"

                                        .Classe = "Sadida"

                                    Case "11"

                                        .Classe = "Sacrieur"

                                    Case "12"

                                        .Classe = "Pandawa"

                                End Select

                                Select Case separate(6)

                                    Case "0"

                                        .Sex = "Male"

                                    Case "1"

                                        .Sex = "Femelle"

                                End Select

                                .ClasseSex = separate(7)

                            Else

                                .Pseudo = separate(0)
                                .EnAmi = False
                                .Nom = ""
                                .Niveau = ""
                                .Sex = ""
                                .Classe = ""
                                .ClasseSex = ""
                                .Alignement = ""

                            End If

                        End With

                        Select Case separateData(0)

                            Case "FL"

                                .Ami.Ami.Add(separate(0), newFriend)

                            Case "iL"

                                .Ami.Ennemi.Add(separate(0), newFriend)

                        End Select

                    Next

                End If

                .Ami.BloqueAmi.Set()

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiAmiEnnemi", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiAmiEnnemiAjoute(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' FAK Linacu ; 2 ; Linaculer ; 99     ; 9      ; 0    ; 90 
                ' FAK Pseudo ; ? ; Nom       ; Niveau ; Classe ; Sexe ; Classe + Sexe

                Dim separateData As String() = Split(Mid(data, 4), ";")

                EcritureMessage(index, "[Dofus]", "(" & separateData(0) & ") " & separateData(2) & " a été ajouté à votre liste " & If(Mid(data, 1, 1) = "F", "d'ami.", "d'ennemi"), Color.Green)

                .Ami.BloqueAmi.Set()

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiAmiEnnemiAjoute", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Sub GiAmiEnnemiInformation(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' BWK Linaculer | 1 | Lenculé | 7
                ' BWK Pseudo    | ? | Nom     | Zone

                data = Mid(data, 4)

                Dim separateData As String() = Split(data, "|")

                Dim phrase As String = separateData(2) & " (" & separateData(1) & ") se trouve en "

                Select Case separateData(3)

                    Case "-1"

                        phrase &= "zone inconnue."

                    Case "7"

                        phrase &= "bonta."

                    Case "11"

                        phrase &= "Brakmar"

                End Select

                EcritureMessage(index, "[Dofus]", phrase, Color.Green)

                .Ami.BloqueAmi.Set()

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiAmiEnnemiInformation", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

End Module
