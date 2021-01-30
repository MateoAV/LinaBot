Module Trajet_Lina

    Public Sub TrajetLoad(ByVal index As Integer, ByVal chemin As String)

        With Comptes(index)

            .FrmGroupe.Trajet.Clear()

            Dim swLecture As IO.StreamReader = New IO.StreamReader(chemin, System.Text.Encoding.UTF7)

            Dim Balise As String = ""

            Do Until swLecture.EndOfStream

                Dim ligneActuel As String = AsciiDecoder(swLecture.ReadLine)

                ligneActuel = ligneActuel.Replace(vbTab, "")

                While ligneActuel.Contains("  ")
                    ligneActuel = ligneActuel.Replace("  ", " ")
                End While

                While ligneActuel.StartsWith(" ")
                    ligneActuel = Mid(ligneActuel, 2, ligneActuel.Length)
                End While

                Dim separateLecture As String() = Split(ligneActuel, " ")

                Select Case separateLecture(0).ToLower

                    Case "sub", "function"

                        'Début balise
                        Balise = separateLecture(1)

                    Case "end"

                        Select Case separateLecture(1).ToLower

                            Case "sub", "function"

                                Balise = ""

                        End Select

                    Case "dim"

                        AddVariable(index, ligneActuel, separateLecture(1))

                        Select Case separateLecture(1).ToLower

                            Case "pods"

                                .FrmGroupe.Pods = separateLecture(3)

                            Case "spectateur"

                                ' .FrmGroupe.Spectateur = CBool(separateLecture(3))

                            Case Else

                        End Select

                    Case Else

                        If Balise <> "" AndAlso ligneActuel <> "" AndAlso Not ligneActuel.StartsWith("'") Then

                            If Not .FrmGroupe.Trajet.ContainsKey(Balise) Then

                                .FrmGroupe.Trajet.Add(Balise, New List(Of String) From {ligneActuel.Replace(vbTab, "")})

                            Else

                                .FrmGroupe.Trajet(Balise).Add(ligneActuel.Replace(vbTab, ""))

                            End If

                        End If

                End Select

            Loop

            swLecture.Close()

            TrajetLecture(index, .FrmGroupe.Trajet.Keys(0))

        End With

    End Sub


    Private Sub AddVariable(index As Integer, ligne As String, nomVariable As String)

        With Comptes(index)

            Dim separateLigne As String()

            separateLigne = Split(ligne.Replace("""", ""), "{") 'Dim Familier = {"Bworky = Pods" , "Chacha = Intelligence"}
            separateLigne = Split(separateLigne(1), "}") ' "Bworky = Pods" , "Chacha = Intelligence"}
            separateLigne = Split(separateLigne(0), " , ") ' "Bworky = Pods" , "Chacha = Intelligence"

            For i = 0 To separateLigne.Count - 1

                If separateLigne(i) <> "" Then

                    Dim separate As String() = Split(separateLigne(i), " = ")

                    If .FrmGroupe.Variable.ContainsKey(nomVariable.ToLower) Then

                        .FrmGroupe.Variable(nomVariable.ToLower).Add(separate(0), separate)

                    Else

                        .FrmGroupe.Variable.Add(nomVariable.ToLower, New Dictionary(Of Object, Object) From
                                                        {{
                                                        separate(0), ' Nom : Bworky
                                                        separate ' Information : Bworky  Pods  etc...
                                                        }})

                    End If

                End If

            Next

        End With

    End Sub

End Module
