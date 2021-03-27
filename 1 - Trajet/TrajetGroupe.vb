Partial Module TrajetExecution

#Region "AMI"

    Private Function Ami_Ouvre(index As Integer, choix As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newAmi As New FunctionAmi
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newAmi.Ouvre(compte, choix)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Ami_Supprime(index As String, pseudoNom As String, choix As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newAmi As New FunctionAmi
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newAmi.Supprime(compte, pseudoNom, choix)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Ami_Ajoute(index As String, pseudoNom As String, choix As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newAmi As New FunctionAmi
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newAmi.Ajoute(compte, pseudoNom, choix)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Ami_Information(index As String, pseudoNom As String, choix As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newAmi As New FunctionAmi
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newAmi.Information(compte, pseudoNom, choix)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Ami_Rejoindre(index As String, Nom As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newAmi As New FunctionAmi
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newAmi.Rejoindre(compte, Nom)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Ami_Avertie(index As String, choix As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newAmi As New FunctionAmi
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newAmi.Avertie(compte, choix)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Ami_Exist(index As String, pseudoNom As String, choix As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newAmi As New FunctionAmi
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newAmi.Exist(compte, pseudoNom, choix)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

#End Region

#Region "Pnj"

    Private Function Groupe_Pnj_Parler(index As Integer, nomID As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newPnj As New FunctionPnj
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newPnj.Parler(compte, nomID)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Groupe_Pnj_Quitte_Dialogue(index As Integer) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newPnj As New FunctionPnj
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newPnj.QuitteDialogue(compte)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Groupe_Pnj_Reponse(index As Integer, phrase As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newPnj As New FunctionPnj
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newPnj.Reponse(compte, phrase)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Pnj_Acheter(index As Integer, nomID As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newPnj As New FunctionPnj
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newPnj.Acheter(compte, nomID)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Pnj_AcheterItem(index As Integer, nomID As String, quantiter As Integer, ByVal prix As Integer) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newPnj As New FunctionPnj
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newPnj.AcheterItem(compte, nomID, quantiter, prix)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Pnj_Recherche(index As Integer, nomID As String) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newPnj As New FunctionPnj
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newPnj.Recherche(compte, nomID)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

#End Region

#Region "Map"

    Private Function Deplacement(index As Integer, direction As String) As Boolean

        With Comptes(index)

            Try

                Dim newTask As New List(Of Task(Of Boolean))
                Dim newDeplacement As New FunctionMap
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newDeplacement.Deplacement(compte, direction)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                If newTask(i).Result = False Then

                    Return False

                End If

            Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function ID(index As Integer, mapID As String) As Boolean

        With Comptes(index)

            Try

                Dim newTask As New List(Of Task(Of Boolean))
                Dim NewDeplacement As New FunctionMap

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() NewDeplacement.ID(compte, mapID)))

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                If newTask(i).Result = False Then

                    Return False

                End If

            Next

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Coordonnees(index As Integer, mapCoordonnes As String) As Boolean

        With Comptes(index)

            Try

                Dim newTask As New List(Of Task(Of Boolean))
                Dim NewDeplacement As New FunctionMap

                For Each compte In .FrmGroupe.BotIndex

                newTask.Add(Task.Run(Function() NewDeplacement.Coordonnees(compte, mapCoordonnes)))

            Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                If newTask(i).Result = False Then

                    Return False

                End If

            Next

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Interaction(index As Integer, nomID As String, actionID As String) As Boolean

        With Comptes(index)

            Try

                Dim newTaskInteraction As New List(Of Task(Of Boolean))
                Dim newDeplacement As New FunctionInteraction
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTaskInteraction.Add(Task.Run(Function() newDeplacement.Interaction(compte, nomID, actionID)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTaskInteraction.ToArray)

                For i = 0 To newTaskInteraction.Count - 1

                    If newTaskInteraction(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Attaquer(index As Integer, choix As String, nombre As Integer) As Boolean

        With Comptes(index)

            Try

                Dim newDeplacement As New FunctionMap
                Dim rand As New Random

                For i = 0 To nombre - 1

                    '  newDeplacement.Attaquer(index, choix)

                    Task.Delay(2000).Wait()

                    If .Combat.EnCombat Then

                        While .Combat.EnCombat

                            Task.Delay(1000).Wait()

                        End While

                        Task.Delay(2000).Wait()

                    End If

                Next

                Task.Delay(rand.Next(750, 1750)).Wait()

                Return True

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

#End Region

#Region "Item"

    Private Function Groupe_Item_Supprime(index As Integer, nomID As String, Optional quantiter As String = "999999", Optional caracteristique As String = Nothing) As Boolean

        With Comptes(index)

            Try

                Dim newTask As New List(Of Task(Of Boolean))
                Dim newItem As New FunctionItem
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newItem.Supprime(compte, nomID, quantiter, caracteristique)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Groupe_Item_Retire(index As Integer, nomID As String, Optional quantiter As Integer = 999999, Optional caracteristique As String = Nothing) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newItem As New FunctionItem
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newItem.Retire(compte, nomID, quantiter, caracteristique)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Groupe_Item_Depose(index As Integer, nomID As String, Optional quantiter As Integer = 999999, Optional caracteristique As String = Nothing) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newItem As New FunctionItem
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newItem.Depose(compte, nomID, quantiter, caracteristique)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Groupe_Item_Equipe(index As Integer, nomID As String, Optional caracteristique As String = Nothing) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newItem As New FunctionItem
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newItem.Equipe(compte, nomID, caracteristique)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Groupe_Item_Desequipe(index As Integer, nomID As String, Optional caracteristique As String = Nothing) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newItem As New FunctionItem
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newItem.Desequipe(compte, nomID, caracteristique)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Groupe_Item_Jette(index As Integer, nomID As String, Optional quantiter As Integer = 999999, Optional caracteristique As String = Nothing) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newItem As New FunctionItem
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newItem.Jette(compte, nomID, quantiter, caracteristique)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Groupe_Item_Utilise(index As Integer, nomID As String, Optional quantiter As Integer = 1) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newItem As New FunctionItem
                Dim rand As New Random

                For a = 1 To quantiter

                    For Each compte In .FrmGroupe.BotIndex

                        newTask.Add(Task.Run(Function() newItem.Utilise(compte, nomID)))

                        Task.Delay(rand.Next(750, 1750)).Wait()

                    Next

                    Task.WaitAll(newTask.ToArray)

                    For i = 0 To newTask.Count - 1

                        If newTask(i).Result = False Then

                            Return False

                        End If

                    Next

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function

    Private Function Groupe_Item_Exist(index As Integer, nomID As String, Optional caracteristique As String = Nothing) As Boolean

        With Comptes(index)

            Try


                Dim newTask As New List(Of Task(Of Boolean))
                Dim newItem As New FunctionItem
                Dim rand As New Random

                For Each compte In .FrmGroupe.BotIndex

                    newTask.Add(Task.Run(Function() newItem.Existe(compte, nomID, caracteristique)))

                    Task.Delay(rand.Next(750, 1750)).Wait()

                Next

                Task.WaitAll(newTask.ToArray)

                For i = 0 To newTask.Count - 1

                    If newTask(i).Result = False Then

                        Return False

                    End If

                Next

                Task.Delay(1000).Wait()

            Catch ex As Exception

                Return False

            End Try

            Return True

        End With

    End Function


#End Region

End Module
