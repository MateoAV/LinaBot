Module TrajetExecution

    Public Sub TrajetLecture(ByVal index As Integer, ByVal balise As String)

        With Comptes(index)

            While True

                If RetourneEnBanque(index) Then

                    TrajetEnCours(index, "banque()", True)

                Else

                    TrajetEnCours(index, balise)

                End If

            End While

        End With

    End Sub

    Private Function RetourneEnBanque(ByVal index As Integer) As Boolean

        With Comptes(index)

            For Each bot As Integer In .FrmGroupe.BotIndex

                If Comptes(bot).Personnage.Pods.Pourcentage >= .FrmGroupe.Pods Then

                    Return True

                End If

            Next

            Return False

        End With

    End Function

    Private Function TrajetEnCours(ByVal index As Integer, ByVal balise As String, Optional ByVal banque As Boolean = False) As Boolean

        With Comptes(index)

            Dim SearchEndLine As String = ""
            Dim nextLine As Boolean = True
            Dim whileLine As Integer = 0
            Dim SelectCase As String = ""

            For a = 0 To .FrmGroupe.Trajet(balise).Count - 1

                Dim newGroupe As New FunctionGroupe
                newGroupe.GroupeInvite(index)

                With .FrmGroupe.Trajet(balise)

                    If .Item(a) <> "" AndAlso Mid(.Item(a), 1, 1) <> "'" Then

                        Dim separateAction As String() = Split(.Item(a), " : ")

                        For i = 0 To separateAction.Count - 1

                            If banque = False AndAlso RetourneEnBanque(index) Then

                                Exit Function

                            End If

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
                                        nextLine = TrajetEnCours(index, separatePair(1).ToLower, banque)
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

                                Case "return"

                                    Dim retourneValeur As String = separateAction(i).ToLower
                                    Return Action(index, Split(retourneValeur, "return ")(1))

                                Case Else

                                    If nextLine Then

                                        If Action(index, separateAction(i)) = False Then

                                            Exit For

                                        End If

                                    End If

                            End Select

                            Bloque(index)

                        Next

                    End If

                End With

                Task.Delay(1).Wait()

            Next

        End With

    End Function

    Private Sub Bloque(ByVal index As Integer)

        With Comptes(index)

            If .Combat.EnCombat Then

                While .Combat.EnCombat

                    Task.Delay(1000).Wait()

                End While

                Task.Delay(2000).Wait()

            End If

        End With

    End Sub

    Public Function ReturnParametre(ByVal index As Integer, ByVal laligne As String) As String()

        Dim separateFunctionParamétre As String()

        If laligne.Contains(" = ") Then

            separateFunctionParamétre = Split(laligne, " = ")

            If separateFunctionParamétre(1).Contains("(") Then

                separateFunctionParamétre = Split(separateFunctionParamétre(1).Replace("""", ""), "(")
                separateFunctionParamétre = Split(separateFunctionParamétre(1), ")")
                separateFunctionParamétre = Split(separateFunctionParamétre(0), " , ")

            Else

                separateFunctionParamétre = Nothing

            End If

        Else

            If laligne.Contains("(") Then

                If laligne.Contains("""") Then

                    separateFunctionParamétre = Split(laligne.Replace("""", ""), "(")
                    separateFunctionParamétre = Split(separateFunctionParamétre(1), ")")
                    separateFunctionParamétre = Split(separateFunctionParamétre(0), " , ")

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

                If separateFunctionParamétre(i).StartsWith(" ") Then
                    separateFunctionParamétre(i) = Mid(separateFunctionParamétre(i), 2)
                End If
                If separateFunctionParamétre(i).EndsWith(" ") Then
                    separateFunctionParamétre(i) = Mid(separateFunctionParamétre(i), 1, separateFunctionParamétre(i).Length - 1)
                End If
                functionParamétre(i + 1) = separateFunctionParamétre(i)

            Next

        End If

        Return functionParamétre

    End Function


#Region "Action"

    Public Function Action(index As Integer, laLigne As String)

        With Comptes(index)

            'Ici je dois avoir seulement l'action.
            'Exemple : Map.Interaction("Statue de Classe" , "Monter a Incarnoob")

            Dim separateLigne As String() = Split(laLigne.Replace(vbTab, ""), "(")

            Dim separate As String() = Split(separateLigne(0), ".")

            Dim Parametre As String() = ReturnParametre(index, laLigne)

            Select Case separate(0).ToLower

                'finir
                '-Groupoe
                '-Guilde
                '-Metier
                '-Zaap
                '-Map
                '-Interaction
                '-Pnj

                Case "ami" ' FINI

                    Select Case separate(1).ToLower

                        Case "ouvre"

                            Return Ami_Ouvre(index, Parametre(1))

                        Case "supprime"

                            Return Ami_Supprime(index, Parametre(1), Parametre(2))

                        Case "ajoute"

                            Return Ami_Ajoute(index, Parametre(1), Parametre(2))

                        Case "information"

                            Return Ami_Information(index, Parametre(1), Parametre(2))

                        Case "rejoindre"

                            Return Ami_Rejoindre(index, Parametre(1))

                        Case "avertie"

                            Return Ami_Avertie(index, Parametre(1))

                        Case "exist", "existe"

                            Return Ami_Exist(index, Parametre(1), Parametre(2))

                        Case Else

                            MsgBox("Information inconnu : " & laLigne)

                    End Select

                Case "echange" ' FINI

                    Dim newEchange As New FunctionEchange

                    Select Case separate(1).ToLower

                        Case "invite"

                            Return newEchange.Invite(index, Parametre(1))

                        Case "refuse"

                            Return newEchange.Refuse(index)

                        Case "arrete"

                            Return newEchange.Arrete(index)

                        Case "accepte"

                            Return newEchange.Accepte(index)

                        Case "kamas"

                            Return newEchange.Kamas(index, Parametre(1))

                        Case "valide"

                            Return newEchange.Valide(index)

                        Case "verification"

                            Return newEchange.Verification(index)

                        Case "enechange"

                            Return .Echange.EnEchange

                    End Select

                Case "defi" ' FINI

                    Dim newDefi As New FunctionDefi

                    Select Case separate(1).ToLower

                        Case "invite"

                            Return newDefi.Invite(index, Parametre(1))

                        Case "accepte"

                            Return newDefi.Accepte(index)

                        Case "refuse"

                            Return newDefi.Refuse(index)

                        Case "abandonne"

                            Return newDefi.Abandonne(index)

                        Case "annule"

                            Return newDefi.Annule(index)

                    End Select

                Case "item" ' FINI

                    Select Case separate(1).ToLower

                        Case "supprime", "suprime"

                            Return Groupe_Item_Supprime(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 999999))

                        Case "retire"

                            Return Groupe_Item_Retire(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 999999))

                        Case "depose"

                            Return Groupe_Item_Depose(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 999999))

                        Case "existe"

                            Return Groupe_Item_Exist(index, Parametre(1))

                        Case "equipe"

                            Return Groupe_Item_Equipe(index, Parametre(1))

                        Case "desequipe"

                            Return Groupe_Item_Desequipe(index, Parametre(1))

                        Case "jette", "jete", "jet"

                            Return Groupe_Item_Jette(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 999999))

                        Case "utilise"

                            Return Groupe_Item_Utilise(index, Parametre(1), If(Parametre.Length > 2, Parametre(2), 1))

                        Case Else

                            MsgBox("Action inconnu, vérifier bien d'avoir les mots correctement orthographié et que la function existe." & vbCrLf &
                                   laLigne)

                    End Select

                Case "groupe" ' FINI

                    Dim newGroupe As New FunctionGroupe

                    Select Case separate(1).ToLower

                        Case "invite"

                            Return newGroupe.Invite(index, Parametre(1))

                        Case "refuse"

                            Return newGroupe.RefuseArrete(index)

                        Case "arrete"

                            Return newGroupe.RefuseArrete(index)

                        Case "accepte"

                            Return newGroupe.Accepte(index)

                        Case "quitte"

                            Return newGroupe.Quitte(index)

                        Case "suivezmoitous"

                            Return newGroupe.SuivezMoiTous(index)

                        Case "arreteztousdemesuivre"

                            Return newGroupe.ArretezTousDeMeSuivre(index)

                        Case "suivreledeplacement"

                            Return newGroupe.SuivreLeDeplacement(index, Parametre(1))

                        Case "neplussuivreledeplacement"

                            Return newGroupe.NePlusSuivreLeDeplacement(index, Parametre(1))

                        Case "suivezletous"

                            Return newGroupe.SuivezLeTous(index, Parametre(1))

                        Case "arreteztousdelesuivre"

                            Return newGroupe.ArretezTousDeLeSuivre(index, Parametre(1))

                        Case "exclure"

                            Return newGroupe.Exclure(index, Parametre(1))

                        Case Else

                            MsgBox("La ligne n'est pas connu : " & laLigne)

                    End Select

                Case "guilde" ' FINI

                    Dim newGuilde As New FunctionGuilde

                    Select Case separate(1).ToLower

                        Case "ouvre"

                            newGuilde.Ouvre(index)

                            Select Case separate(2).ToLower

                                Case "membre", "membres"

                                    Return newGuilde.Membres(index)

                                Case "personnalisation"

                                    Return newGuilde.Personnalisation(index)

                                Case "percepteur", "percepteurs"

                                    Return newGuilde.Percepteurs(index)

                                Case "enclos", "enclo"

                                    Return newGuilde.Enclos(index)

                                Case "maisons", "maison"

                                    Return newGuilde.Maisons(index)

                                Case Else

                                    MsgBox("Ligne inconnu : " & laLigne)

                            End Select

                        Case "membre", "membres"

                            Select Case separate(2).ToLower

                                Case "exclure"

                                    Return newGuilde.Exclure(index, Parametre(1))

                                Case "invite"

                                    Return newGuilde.Invite(index, Parametre(1))

                                Case "refuse"

                                    Return newGuilde.Refuse(index)

                                Case "rang"

                                    Return newGuilde.Rang(index, Parametre(1), Parametre(2))

                                Case "droits", "droit"

                                    Return newGuilde.Droits(index, Parametre(1), Parametre(2), Parametre(3))

                                Case "experience"

                                    Return newGuilde.Experience(index, Parametre(1), Parametre(2))

                                Case Else

                                    MsgBox("Ligne inconnu : " & laLigne)

                            End Select

                        Case "personnalisation"

                            Select Case separate(2).ToLower

                                Case "up"

                                    Return newGuilde.Up(index, Parametre(1), Parametre(2))

                                Case "poserunpercepteur"

                                    Return newGuilde.PoserPercepteur(index)

                                Case "retirerunpercepteur"

                                    Return newGuilde.RetirerPercepteur(index)

                                Case "releverunpercepteur"

                                    Return newGuilde.ReleverPercepteur(index)

                                Case Else

                                    MsgBox("Ligne inconnu : " & laLigne)

                            End Select

                        Case "enclos", "enclo"

                            Select Case separate(2).ToLower

                                Case "teleporter"

                                    Return newGuilde.EnclosTeleporter(index, Parametre(1))

                                Case Else

                                    MsgBox("Ligne inconnu : " & laLigne)

                            End Select

                        Case "maisons", "maison"

                            Select Case separate(2).ToLower

                                Case "teleporter"

                                    Return newGuilde.MaisonsTeleporter(index, Parametre(1))

                                Case Else

                                    MsgBox("Ligne inconnu : " & laLigne)

                            End Select

                        Case Else

                            MsgBox("Ligne inconnu : " & laLigne)

                    End Select

                Case "metier" ' FINI

                    Dim newMetier As New FunctionMetier

                    Select Case separate(1).ToLower

                        Case "existe", "exist"

                            Return newMetier.Existe(index, Parametre(1))

                        Case "public"

                            Return newMetier.Public(index, Parametre(1))

                        Case "option"

                            Return newMetier.Option(index, Parametre(1), Parametre(2), Parametre(3), Parametre(4), Parametre(5))

                    End Select

                Case "chargement"

                    Select Case separate(1).ToLower

                        Case "trajet"

                            Task.Run(Sub() TrajetLoad(index, Parametre(1))).Wait()

                    End Select

                Case "connexion"

                    Connexion(index, Parametre(1), Parametre(2), Parametre(3), Parametre(4))

                    Task.Delay(30000).Wait()

                Case "zaap", "zaapi"

                    Dim newZaap As New FunctionZaap

                    Select Case separate(1).ToLower

                        Case "utiliser"

                            Return newZaap.Utiliser(index)

                        Case "sauvegarder"

                            Return newZaap.Sauvegarder(index)

                        Case "destination"

                            Return newZaap.Destination(index, Parametre(1))

                        Case "quitte"

                            Return newZaap.Quitte(index)

                        Case Else

                            MsgBox("Ligne inconnu : " & laLigne)

                    End Select

                Case "pnj"

                    Dim newPnj As New FunctionPnj

                    Select Case separate(1).ToLower

                        Case "parler"

                            Return Groupe_Pnj_Parler(index, Parametre(1))

                        Case "quitte"

                            Select Case separate(2).ToLower

                                Case "dialogue"

                                    Return Groupe_Pnj_Quitte_Dialogue(index)

                            End Select

                        Case "reponse"

                            Return Groupe_Pnj_Reponse(index, Parametre(1))

                        Case "achetervendre"

                            Select Case separate(2).ToLower

                                Case "parler"

                                    Return newPnj.AcheterVendre(index, Parametre(1))

                                Case "vendre"

                                    Return newPnj.AcheterVendreVendItem(index, Parametre(1), Parametre(2), Parametre(3))

                            End Select

                        Case "acheter"

                            If separate.Count > 2 Then

                                '  While AcheterItem(index, Parametre(1), Parametre(2), Parametre(3))

                                Task.Delay(500).Wait()

                                '  End While

                            Else

                                'Return Acheter(index, Parametre(1))

                            End If

                        Case "recherche"

                            '   Return Recherche(index, Parametre(1))

                    End Select

                Case "caracteristique", "caracteristiques"

                    Dim newCaracteristique As New FunctionCaractéristique

                    With newCaracteristique

                        Select Case separate(1).ToLower

                            Case "up"

                                Return .Up(index, Parametre(1))

                            Case "return", "retourne"

                                Return .Return(index, Parametre(1), Parametre(2))

                            Case "energie"

                                Return .Energie(index, Parametre(1))

                            Case "niveau", "niveaux"

                                Return .Niveau(index)

                            Case "experience"

                                Return .Experience(index, Parametre(1))

                            Case "pointdevie", "pdv"

                                Return .PointDeVie(index, Parametre(1))

                        End Select

                    End With

                Case "map"

                    Select Case separate(1).ToLower

                        Case "id" ' Map.ID("7411")

                            Return ID(index, Parametre(1))

                        Case "coordonnees" ' Map.Coordonnees("4,-16")

                            Return Coordonnees(index, Parametre(1))

                        Case "deplacement" ' Map.deplacement("Droite")

                            Return Deplacement(index, Parametre(1))

                        Case "interaction" ' Map.Interaction("Statue de classe" , "Se rendre a incarnam")

                            Return Interaction(index, Parametre(1), Parametre(2))

                        Case "attaquer"

                            Return Attaquer(index, Parametre(1), Parametre(2))

                    End Select

                Case "pause"

                    Pause(index, Parametre(1), Parametre(2))

                    Return True

                Case "personnage"

                    Select Case separate(1).ToLower

                        Case "niveau"

                            Return .Personnage.Niveau

                    End Select

                Case "recolte"

                    Dim newRecolte As New FunctionRecolte

                    While newRecolte.Recolte(index)

                        If RetourneEnBanque(index) Then

                            Return False

                        End If

                        Task.Delay(500).Wait()

                    End While

                    Return True

                Case "mobs"

                    Select Case separate(1).ToLower

                        Case "proche"

                            ' IAMobs(inde)

                    End Select

                Case "familier"

            End Select

        End With

        Return False

    End Function

#End Region

#Region "Spe"

    Public Function WhileReturn(ByVal index As Integer, ByVal laLigne As String) As Boolean

        With Comptes(index)

            Dim separate As String() = Split(laLigne, " ")

            Dim nomFunction As String = ReturnNomFunction(laLigne)
            Dim ParametreFunction As String() = ReturnParametreFunction(index, laLigne)

            Dim resultat1 As String = Action(index, nomFunction) '= LuaScript.GetFunction(nomFunction.ToLower).Call(ParametreFunction).First

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

    Public Function IfReturn(ByVal index As Integer, ByVal laLigne As String) As Boolean

        With Comptes(index)

            Dim separateLigne As String() = Split(laLigne, " ")

            Dim resultat As String = Action(index, separateLigne(1))

            If IsNumeric(separateLigne(3)) Then

                Select Case separateLigne(2)

                    Case "<"

                        If CInt(resultat) < CInt(separateLigne(3)) Then

                            Return True

                        Else

                            Return False

                        End If

                    Case ">"

                        If CInt(resultat) > CInt(separateLigne(3)) Then

                            Return True

                        Else

                            Return False

                        End If

                    Case "="

                        If CInt(resultat) = CInt(separateLigne(3)) Then

                            Return True

                        Else

                            Return False

                        End If

                End Select

            ElseIf separateLigne(3).ToLower = "true" OrElse separateLigne(3).ToLower = "false" Then

                If CBool(resultat) = CBool(separateLigne(3)) Then

                    Return True

                Else

                    Return False

                End If

            Else

                Select Case separateLigne(2)

                    Case "<>"

                        If resultat.ToLower <> separateLigne(3).ToLower Then

                            Return True

                        Else

                            Return False

                        End If

                    Case "="

                        If resultat.ToLower = separateLigne(3).ToLower Then

                            Return True

                        Else

                            Return False

                        End If

                End Select

            End If

            Return False

        End With

    End Function

#End Region

#Region "Select Case"

    Public Function SelectReturn(ByVal index As Integer, ByVal laLigne As String) As String

        With Comptes(index)

            Dim separateLigne As String() = Split(laLigne, " ")

            Dim nomFunction As String = ReturnNomFunction(laLigne)
            Dim ParametreFunction As String() = ReturnParametreFunction(index, laLigne)

            ' Return LuaScript.GetFunction(nomFunction.ToLower).Call(ParametreFunction).First

        End With

    End Function

    Public Function SelectCaseReturn(ByVal index As Integer, ByVal laLigne As String, ByVal resultat As String) As Boolean

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

    Private Function ReturnNomFunction2(ByVal laligne As String) As String

        Dim separate As String() = Split(laligne, " ")

        Return separate(1)

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

    Private Function ReturnNomFunction(ByVal laligne As String) As String

        Dim separate As String() = Split(laligne, " ")

        Return separate(1)
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
