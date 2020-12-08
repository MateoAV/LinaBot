Module MdlMaison

    Public Sub GiMaMaison(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' hL + 556       ; 1          ; 0        ; 0
                ' hL + Id Maison ; Verouiller ; En Vente ; En Guilde

                data = Mid(data, 4)

                Dim separate As String() = Split(data, ";")

                With .Maison

                    .ID = separate(0)
                    .Vérouiller = separate(1)
                    .EnVente = separate(2)
                    .EnGuilde = separate(3)
                    .CellulePorte = VarMaison(.ID).CellulePorte
                    .MapID = VarMaison(.ID).MapId
                    .Coordonnées = VarMaison(.ID).Map
                    .Prix = 0
                    .Code = 0

                End With

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiMaMaison", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Public Sub GiMesCoffres(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' sL + 9999   _ 114     ; 1          | Next
                ' sL + Id Map _ Cellule ; Verouiller | Next

                data = Mid(data, 4)

                Dim separateData As String() = Split(data, "|")

                For i = 0 To separateData.Count - 1

                    Dim separate As String() = Split(separateData(i), ";")

                    Dim Vérouiller As Boolean = separate(1)

                    separate = Split(separate(0), "_")

                    Dim varCoffre As New ClassCoffre

                    With varCoffre

                        .Coordonnées = VarMap(separate(0))
                        .MapID = separate(0)
                        .CelluleCoffre = separate(1)
                        .Vérouiller = Vérouiller
                        .Code = Nothing

                    End With

                    If .Maison.Coffre.ContainsKey(separate(0)) Then

                        .Maison.Coffre(separate(0)) = varCoffre

                    Else

                        .Maison.Coffre.Add(separate(0), varCoffre)

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiMesCoffres", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Public Sub GiMaisonMap(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' hP 444 | Linacu ; 0            ; Lenculeur lourd ; a     , 0    ,i     ,9drge
                ' hP Id  | Pseudo ; pas en vente ; Nom guilde      ; blason,blason,blason,blason

                data = Mid(data, 3)

                Dim separateData As String() = Split(data, "|")

                Dim id As Integer = separateData(0)

                separateData = Split(separateData(1), ";")

                If Not VarMaison.ContainsKey(id) Then

                    MaisonAjouteInformation(index, id)

                End If

                Dim newMaison As New ClassMaison

                With newMaison

                    .ID = id
                    .Vérouiller = False
                    .EnVente = separateData(1)
                    .EnGuilde = False
                    .Propriétaire = separateData(0)
                    .CellulePorte = VarMaison(id).CellulePorte
                    .MapID = Comptes(index).Map.ID
                    .Coordonnées = Comptes(index).Map.Coordonnees
                    .Prix = 0
                    .Code = 0

                    If separateData.Length > 2 Then

                        .GuildeNom = separateData(2)

                    End If

                End With

                If VarMaison(id).Map = "[X,Y]" OrElse VarMaison(id).MapId = "0" Then

                    MaisonChangeInformation(index, id)

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiMaisonMap", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Private Sub MaisonChangeInformation(ByVal index As Integer, ByVal id As String)

        With Comptes(index)

            'Mise à jour de la version automatiquement (celui du fichier)
            Dim swLecture As New IO.StreamReader(Application.StartupPath & "\Data/Maison.txt")

            Dim ligneFinal As String = ""

            Do Until swLecture.EndOfStream

                Dim Ligne As String = swLecture.ReadLine

                If Ligne <> "" Then

                    Dim separate As String() = Split(Ligne, " | ")

                    If separate(0) = "hP : " & id Then

                        ligneFinal &= "hP : " & id & " | Porte : " & VarMaison(id).CellulePorte & " | Map : " & .Map.Coordonnees & " | Mapid : " & .Map.ID & " | Nom : " & VarMaison(id).Nom & vbCrLf

                    Else

                        ligneFinal &= Ligne & vbCrLf

                    End If

                End If

            Loop

            'Puis je ferme le fichier.
            swLecture.Close()

            'J'ouvre le fichier pour y écrire se que je souhaite
            Dim Sw_Ecriture As New IO.StreamWriter(Application.StartupPath + "\Data/Maison.txt")

            'J'écris dedans avant de le fermer.
            Sw_Ecriture.Write(ligneFinal)

            'Puis je le ferme.
            Sw_Ecriture.Close()

            ChargeMaison()

        End With

    End Sub

    Private Sub MaisonAjouteInformation(ByVal index As Integer, ByVal id As String)

        With Comptes(index)

            'Mise à jour de la version automatiquement (celui du fichier)
            Dim swLecture As New IO.StreamReader(Application.StartupPath & "\Data/Maison.txt")

            Dim ligneFinal As String = ""

            Do Until swLecture.EndOfStream

                Dim ligne As String = swLecture.ReadLine

                If ligne <> "" Then

                    ligneFinal &= ligne & vbCrLf

                End If

            Loop

            'Puis je ferme le fichier.
            swLecture.Close()

            ligneFinal &= "hP : " & id & " | Porte : 0 | Map : " & .Map.Coordonnees & " | Mapid : " & .Map.ID & " | Nom : Maison"

            'J'ouvre le fichier pour y écrire se que je souhaite
            Dim Sw_Ecriture As New IO.StreamWriter(Application.StartupPath + "\Data/Maison.txt")

            'J'écris dedans avant de le fermer.
            Sw_Ecriture.Write(ligneFinal)

            'Puis je le ferme.
            Sw_Ecriture.Close()

            ChargeMaison()

        End With

    End Sub

End Module
