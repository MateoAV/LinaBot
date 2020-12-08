

Module TrajetExecution

    Public Sub TrajetLecture(ByVal index As Integer, ByVal balise As String)

        With Comptes(index)

            While True

                TrajetEnCours(index, balise)

            End While

        End With

    End Sub

    Private Sub TrajetEnCours(ByVal index As Integer, ByVal balise As String, Optional ByVal banque As Boolean = False)

        With Comptes(index)

            Dim SearchEndLine As String = ""
            Dim nextLine As Boolean = True
            Dim whileLine As Integer = 0
            Dim SelectCase As String = ""

            'If 80 >= .FrmGroupe.Pods Then
            'If balise.ToLower <> "<banque>" AndAlso banque = False Then
            'TrajetEnCours(index, "<Banque>", True)
            'Return
            'End If
            'End If

            For a = 0 To .FrmGroupe.Trajet(balise).Count - 1

                With .FrmGroupe.Trajet(balise)

                    If .Item(a) <> "" AndAlso Mid(.Item(a), 1, 1) <> "'" Then

                        Dim separateAction As String() = Split(.Item(a), " : ")

                        For i = 0 To separateAction.Count - 1

                            Dim separatePair As String() = Split(separateAction(i), " ")

                            Select Case separatePair(0)

                                Case "If"

                                    nextLine = IfReturn(index, .Item(a))

                                    If nextLine Then

                                        SearchEndLine = "End If"

                                    End If

                                Case "ElseIf"

                                    If SearchEndLine <> "End If" Then

                                        nextLine = IfReturn(index, .Item(a))

                                    End If

                                    If nextLine Then

                                        SearchEndLine = "End If"

                                    End If

                                Case "Else"

                                    If SearchEndLine = "End If" Then

                                        If nextLine Then nextLine = False

                                    Else

                                        SearchEndLine = "End If"
                                        nextLine = True

                                    End If

                                Case "End"

                                    SearchEndLine = ""

                                    Select Case separatePair(1)

                                        Case "If"

                                            nextLine = True

                                        Case "While"

                                            If nextLine Then

                                                a = whileLine - 1

                                            Else

                                                nextLine = True
                                                whileLine = 0

                                            End If

                                        Case "Sub"

                                        Case "Select"

                                    End Select

                                Case "While"

                                    If WhileReturn(index, .Item(a)) Then

                                        nextLine = True
                                        whileLine = a

                                    Else

                                        nextLine = False
                                        whileLine = 0

                                    End If

                                Case "Call"

                                    If nextLine Then
                                        TrajetEnCours(index, separatePair(1), banque)
                                    End If

                                    'Select case
                                Case "Select"

                                    If SearchEndLine = "" Then SelectCase = SelectReturn(index, .Item(a))

                                Case "Case"

                                    Select Case separatePair(1)

                                        Case "Else"

                                            If SearchEndLine = "End Select" Then

                                                If nextLine Then nextLine = False

                                            Else

                                                SearchEndLine = "End Select"
                                                nextLine = True

                                            End If

                                        Case Else

                                            If SearchEndLine <> "End Select" AndAlso SearchEndLine <> "End If" Then

                                                nextLine = SelectCaseReturn(index, .Item(a), SelectCase)

                                            End If

                                            If nextLine Then

                                                SearchEndLine = "End Select"

                                            End If

                                    End Select
                                    '/Select case

                                Case Else

                                    If nextLine Then

                                        If Action(index, separateAction(i)) = False Then

                                            Exit For

                                        End If

                                    End If

                            End Select

                        Next

                    End If

                End With

            Next

        End With

    End Sub


    Private Function ReturnParametre(ByVal index As Integer, ByVal laligne As String) As String()

        Dim separateFunctionParamétre As String()

        If laligne.Contains(" = ") Then

            separateFunctionParamétre = Split(laligne, " = ")

            If separateFunctionParamétre(1).Contains("(") Then

                separateFunctionParamétre = Split(separateFunctionParamétre(1).Replace("""", ""), "(")
                separateFunctionParamétre = Split(separateFunctionParamétre(1), ")")
                separateFunctionParamétre = Split(separateFunctionParamétre(0), If(separateFunctionParamétre(0).Contains(", "), ", ", " , "))

            Else

                separateFunctionParamétre = Nothing

            End If

        Else

            If laligne.Contains("(") Then

                If laligne.Contains("""") Then

                    separateFunctionParamétre = Split(laligne.Replace("""", ""), "(")
                    separateFunctionParamétre = Split(separateFunctionParamétre(1), ")")
                    separateFunctionParamétre = Split(separateFunctionParamétre(0), If(separateFunctionParamétre(0).Contains(", "), ", ", " , "))

                Else

                    separateFunctionParamétre = Nothing

                End If

            Else

                separateFunctionParamétre = Nothing

            End If

        End If

        Dim functionParamétre(If(separateFunctionParamétre Is Nothing, 0, separateFunctionParamétre.Count)) As String
        functionParamétre(0) = index

        If Not separateFunctionParamétre Is Nothing Then

            For i = 0 To separateFunctionParamétre.Count - 1

                functionParamétre(i + 1) = separateFunctionParamétre(i)

            Next

        End If

        Return functionParamétre

    End Function


#Region "Action"

    Private Function Action(ByVal index As Integer, ByVal laLigne As String) As Boolean

        With Comptes(index)

            Dim separateLigne As String() = Split(laLigne, "(")

            Dim separate As String() = Split(separateLigne(0), ".")

            Dim Parametre As String() = ReturnParametre(index, laLigne)

            Select Case separate(0).ToLower

                Case "map"

                    Dim newMap As New FunctionMap

                    Select Case separate(1).ToLower

                        Case "id" ' Map.ID(7411)

                            Return newMap.ID(index, Parametre(1))

                        Case "deplacement" ' Map.deplacement("Droite")

                            Return newMap.Deplacement(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 500), If(Parametre.Length > 2, Parametre(3), 1500))

                    End Select

                Case "pnj"

                    Dim newPnj As New FunctionPnj

                    Select Case separate(1).ToLower

                        Case "parler"

                            newPnj.Parler(index, Parametre(1))

                        Case "quitte"

                           ' newPnj.Quitte(index)

                        Case "reponse"

                            newPnj.Reponse(index, Parametre(1))

                    End Select

                Case "item"

                    Dim newItem As New FunctionItem

                    Select Case separate(1).ToLower

                        Case "supprime", "suprime"

                            newItem.Supprime(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 999999))

                        Case "retire"

                            newItem.Retire(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 999999))

                        Case "depose"

                            newItem.Depose(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 999999))

                        Case "existe"

                            newItem.Existe(index, Parametre(1))

                        Case "equipe"

                            newItem.Equipe(index, Parametre(1))

                        Case "desequipe"

                            newItem.Desequipe(index, Parametre(1))

                        Case "jette", "jete", "jet"

                            newItem.Jette(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 999999))

                        Case "utilise"

                            newItem.Utilise(index, Parametre(1))

                        Case Else

                            MsgBox("Action inconnu, vérifier bien d'avoir les mots correctement orthographié et que la function existe." & vbCrLf &
                                   laLigne)

                    End Select

                Case "echange"

                    Dim newEchange As New FunctionEchange

                    Select Case separate(1).ToLower

                        Case "echange"

                            newEchange.Echange(index, Parametre(1))

                        Case "refuse", "arrete"

                            newEchange.RefuseArrete(index)

                        Case "accepte"

                            newEchange.Accepte(index)

                        Case "kamas"

                            newEchange.Kamas(index, Parametre(1))

                        Case "valide"

                            newEchange.Valide(index)

                    End Select

            End Select

        End With

        Return False

    End Function

#End Region

#Region "Spe"

    Private Function WhileReturn(ByVal index As Integer, ByVal laLigne As String) As Boolean

        With Comptes(index)

            Dim separate As String() = Split(laLigne, " ")

            Dim nomFunction As String = ReturnNomFunction(laLigne)
            Dim ParametreFunction As String() = ReturnParametreFunction(index, laLigne)

            Dim resultat1 As String '= LuaScript.GetFunction(nomFunction.ToLower).Call(ParametreFunction).First

            Select Case separate(1)

                Case "Integer"

                    Select Case separate(4)

                        Case "<"

                            If CInt(resultat1) <= CInt(separate(5)) Then

                                Return True

                            Else

                                Return False

                            End If

                        Case ">"

                            If CInt(resultat1) >= CInt(separate(5)) Then

                                Return True

                            Else

                                Return False

                            End If

                        Case "="

                            If CInt(resultat1) = CInt(separate(5)) Then

                                Return True

                            Else

                                Return False

                            End If

                    End Select

            End Select

            Return False

        End With

    End Function

    Public Function CallFunction(ByVal index As Integer, ByVal laLigne As String)

        With Comptes(index)

            Dim nomFunction As String = ReturnNomFunction(laLigne)
            Dim ParametreFunction As String() = ReturnParametreFunction(index, laLigne)

            ' Return LuaScript.GetFunction(nomFunction.ToLower).Call(ParametreFunction).First

        End With

    End Function

    Private Function IfReturn(ByVal index As Integer, ByVal laLigne As String) As Boolean

        With Comptes(index)

            Dim separateLigne As String() = Split(laLigne, " ")

            Dim nomFunction As String = ReturnNomFunction(laLigne)
            Dim ParametreFunction As String() = ReturnParametreFunction(index, laLigne)

            Dim resultat1 As String '= LuaScript.GetFunction(nomFunction.ToLower).Call(ParametreFunction).First

            Select Case separateLigne(1)

                Case "Integer"

                    Select Case separateLigne(4)

                        Case "<"

                            If CInt(resultat1) < CInt(separateLigne(5)) Then

                                Return True

                            Else

                                Return False

                            End If

                        Case ">"

                            If CInt(resultat1) > CInt(separateLigne(5)) Then

                                Return True

                            Else

                                Return False

                            End If

                        Case "="

                            If CInt(resultat1) = CInt(separateLigne(5)) Then

                                Return True

                            Else

                                Return False

                            End If

                    End Select

                Case "String"

                Case "Boolean"

                    If resultat1 = Split(laLigne, " = ")(2).Split(" ")(0) Then

                        Return True

                    Else

                        Return False

                    End If

            End Select

            Return False

        End With

    End Function

#End Region

#Region "Select Case"

    Private Function SelectReturn(ByVal index As Integer, ByVal laLigne As String) As String

        With Comptes(index)

            Dim separateLigne As String() = Split(laLigne, " ")

            Dim nomFunction As String = ReturnNomFunction(laLigne)
            Dim ParametreFunction As String() = ReturnParametreFunction(index, laLigne)

            ' Return LuaScript.GetFunction(nomFunction.ToLower).Call(ParametreFunction).First

        End With

    End Function

    Private Function SelectCaseReturn(ByVal index As Integer, ByVal laLigne As String, ByVal resultat As String) As Boolean

        With Comptes(index)

            Dim separate As String() = Split(laLigne, " ")

            Select Case separate(1)

                Case "Integer"

                    Select Case separate(2)

                        Case "<"

                            If CInt(resultat) < CInt(separate(3)) Then

                                Return True

                            Else

                                Return False

                            End If

                        Case ">"

                            If CInt(resultat) > CInt(separate(3)) Then

                                Return True

                            Else

                                Return False

                            End If

                        Case "="

                            If CInt(resultat) = CInt(separate(3)) Then

                                Return True

                            Else

                                Return False

                            End If

                    End Select

                Case "Boolean"

                Case "String"

            End Select

        End With

    End Function

#End Region

#Region "Function"

    Private Function ReturnNomFunction(ByVal laligne As String) As String

        Dim separate As String()

        If laligne.Contains(" = ") Then

            separate = Split(laligne, " = ")
            separate = Split(separate(1), "(")

        Else

            If laligne.Contains("Select") Then

                separate = Split(laligne, " ")
                separate = Split(separate(2), "(")

            Else

                separate = Split(laligne, "(")

            End If

        End If

        Return separate(0)

    End Function

    Private Function ReturnParametreFunction(ByVal index As Integer, ByVal laligne As String)

        Dim separateFunctionParamétre As String()

        If laligne.Contains(" = ") Then

            separateFunctionParamétre = Split(laligne, " = ")

            If separateFunctionParamétre(1).Contains("(") Then

                separateFunctionParamétre = Split(separateFunctionParamétre(1).Replace("""", ""), "(")
                separateFunctionParamétre = Split(separateFunctionParamétre(1), ")")
                separateFunctionParamétre = Split(separateFunctionParamétre(0), If(separateFunctionParamétre(0).Contains(", "), ", ", " , "))

            Else

                separateFunctionParamétre = Nothing

            End If

        Else

            If laligne.Contains("(") Then

                If laligne.Contains("""") Then

                    separateFunctionParamétre = Split(laligne.Replace("""", ""), "(")
                    separateFunctionParamétre = Split(separateFunctionParamétre(1), ")")
                    separateFunctionParamétre = Split(separateFunctionParamétre(0), If(separateFunctionParamétre(0).Contains(", "), ", ", " , "))

                Else

                    separateFunctionParamétre = Nothing

                End If

            Else

                separateFunctionParamétre = Nothing

            End If

        End If

        Dim functionParamétre(If(separateFunctionParamétre Is Nothing, 0, separateFunctionParamétre.Count)) As String
        functionParamétre(0) = index

        If Not separateFunctionParamétre Is Nothing Then

            For i = 0 To separateFunctionParamétre.Count - 1

                functionParamétre(i + 1) = separateFunctionParamétre(i)

            Next

        End If

        Return functionParamétre

    End Function

#End Region

End Module
