Module IA

    Public Sub IAChargement(ByVal index As Integer, ByVal chemin As String)

        With Comptes(index)

            .IntelligenceArtificielle.Clear()

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

                    Case Else

                        If Balise <> "" AndAlso ligneActuel <> "" AndAlso Not ligneActuel.StartsWith("'") Then

                            If Not .IntelligenceArtificielle.ContainsKey(Balise) Then

                                .IntelligenceArtificielle.Add(Balise, New List(Of String) From {ligneActuel.Replace(vbTab, "")})

                            Else

                                .IntelligenceArtificielle(Balise).Add(ligneActuel.Replace(vbTab, ""))

                            End If

                        End If

                End Select

            Loop

            swLecture.Close()

        End With

    End Sub

    Public Sub IABase(ByVal index As Integer, ByVal balise As String)

        With Comptes(index)

            Dim SearchEndLine As String = ""
            Dim nextLine As Boolean = True
            Dim whileLine As Integer = 0
            Dim SelectCase As String = ""

            For a = 0 To .IntelligenceArtificielle(balise).Count - 1

                With .IntelligenceArtificielle(balise)

                    If .Item(a) <> "" AndAlso Mid(.Item(a), 1, 1) <> "'" Then

                        Dim separateAction As String() = Split(.Item(a), " : ")

                        For i = 0 To separateAction.Count - 1

                            Dim separatePair As String() = Split(separateAction(i), " ")

                            Select Case separatePair(0).ToLower

                                Case "if"

                                    nextLine = IfReturn(index, .Item(a))

                                    If nextLine Then

                                        SearchEndLine = "end if"

                                    End If

                                Case "elseif"

                                    If SearchEndLine <> "end if" Then

                                        nextLine = IfReturn(index, .Item(a))

                                    End If

                                    If nextLine Then

                                        SearchEndLine = "end if"

                                    End If

                                Case "else"

                                    If SearchEndLine = "end if" Then

                                        If nextLine Then nextLine = False

                                    Else

                                        SearchEndLine = "end if"
                                        nextLine = True

                                    End If

                                Case "end"

                                    SearchEndLine = ""

                                    Select Case separatePair(1).ToLower

                                        Case "if"

                                            nextLine = True

                                        Case "while"

                                            If nextLine Then

                                                a = whileLine - 1

                                            Else

                                                nextLine = True
                                                whileLine = 0

                                            End If

                                        Case "sub"

                                        Case "select"

                                    End Select

                                Case "while"

                                    If WhileReturn(index, .Item(a)) Then

                                        nextLine = True
                                        whileLine = a

                                    Else

                                        nextLine = False
                                        whileLine = 0

                                    End If

                                Case "call"

                                    If nextLine Then
                                        IABase(index, separatePair(1))
                                    End If

                                    'Select case
                                Case "select"

                                    If SearchEndLine = "" Then SelectCase = SelectReturn(index, .Item(a))

                                Case "case"

                                    Select Case separatePair(1).ToLower

                                        Case "else"

                                            If SearchEndLine = "end select" Then

                                                If nextLine Then nextLine = False

                                            Else

                                                SearchEndLine = "end select"
                                                nextLine = True

                                            End If

                                        Case Else

                                            If SearchEndLine <> "end select" AndAlso SearchEndLine <> "end if" Then

                                                nextLine = SelectCaseReturn(index, .Item(a), SelectCase)

                                            End If

                                            If nextLine Then

                                                SearchEndLine = "end select"

                                            End If

                                    End Select
                                    '/Select case

                                Case Else

                                    If nextLine Then

                                        If ActionIA(index, separateAction(i)) = False Then

                                            Exit For

                                        End If

                                    End If

                            End Select

                        Next

                    End If

                End With

                Task.Delay(1).Wait()

            Next

        End With

    End Sub




    Private Function ActionIA(ByVal index As Integer, ByVal laLigne As String)

        With Comptes(index)

            Dim separateLigne As String() = Split(laLigne.Replace(vbTab, ""), "(")

            Dim separate As String() = Split(separateLigne(0), ".")

            Dim Parametre As String() = ReturnParametre(index, laLigne)

            Select Case separate(0).ToLower

                Case "mobs"

                    Select Case separate(1).ToLower

                        Case "proche"

                            AvanceMobsProche(index)

                    End Select


            End Select


        End With

        Return ""

    End Function

End Module
