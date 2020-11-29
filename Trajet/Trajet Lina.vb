Module Trajet_Lina

    Public Sub TrajetLoad(ByVal index As Integer, ByVal chemin As String)

        With Comptes(index)

            .FrmGroupe.Trajet.Clear()

            Dim swLecture As IO.StreamReader = New IO.StreamReader(chemin, System.Text.Encoding.UTF7)

            Dim Balise As String = ""

            Do Until swLecture.EndOfStream

                Dim ligneActuel As String = AsciiDecoder(swLecture.ReadLine)

                While ligneActuel.Contains("  ")
                    ligneActuel = ligneActuel.Replace("  ", " ")
                End While

                While ligneActuel.StartsWith(" ")
                    ligneActuel = Mid(ligneActuel, 2, ligneActuel.Length)
                End While

                Dim separateLecture As String() = Split(ligneActuel, " ")

                Select Case Mid(separateLecture(0), 1, 1)

                    Case "<"

                        Select Case Mid(separateLecture(0), 2, 1)

                            Case "/"

                                'Fin balise
                                Balise = ""

                            Case Else

                                'Début balise
                                Balise = ligneActuel

                        End Select

                    Case "D"

                        Select Case separateLecture(0)

                            Case "Dim"

                                Select Case separateLecture(1).ToLower

                                    Case "pods"

                                        '.FrmGroupe.Pods = separateLecture(3)

                                    Case "spectateur"

                                        ' .FrmGroupe.Spectateur = CBool(separateLecture(3))

                                End Select

                        End Select

                    Case Else

                        If Balise <> "" AndAlso ligneActuel <> "" AndAlso Not ligneActuel.StartsWith("'") Then

                            If Not .FrmGroupe.Trajet.ContainsKey(Balise) Then

                                .FrmGroupe.Trajet.Add(Balise, New List(Of String) From {ligneActuel})

                            Else

                                .FrmGroupe.Trajet(Balise).Add(ligneActuel)

                            End If

                        End If

                End Select

            Loop

            swLecture.Close()

            TrajetLecture(index, .FrmGroupe.Trajet.Keys(0))

        End With

    End Sub

End Module
