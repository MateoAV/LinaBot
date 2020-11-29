Public Class Class_Connexion

    Private Delegate Function dlg()

    Public Function Connexion(ByVal index As String, ByVal nomDeCompte As String, ByVal motDePasse As String, ByVal serveur As String, ByVal nomDuPersonnage As String)

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlg(Function() Connexion(index, nomDeCompte, motDePasse, serveur, nomDuPersonnage)))

            Else

                With .Personnage

                    .NomDeCompte = nomDeCompte
                    .NomDuPersonnage = nomDuPersonnage
                    .Serveur = serveur
                    .MotDePasse = motDePasse

                End With

                If .MITM Then

                    If .AppMITM = Nothing OrElse .AppMITM = 0 Then

                        .Main()
                        .AppMITM = Shell(LinaBot.PathMITM & "/Dofus.exe", AppWinStyle.NormalNoFocus)

                        Task.Run(Sub() Lancement(index, .AppMITM))

                    Else

                        Task.Run(Sub() AddNdcMdp(index))

                    End If

                Else

                    .CreateSocketAuthentification(VarServeur("Authentification").IP, VarServeur("Authentification").Port)

                End If

            End If

        End With

    End Function

    Private Sub Lancement(ByVal index As Integer, ByVal id As Integer)


        Task.Delay(2000).Wait()
        AppActivate(id)
        Task.Delay(1000).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait("{ENTER}")
        AddNdcMdp(index)

    End Sub

    Public Sub AddNdcMdp(ByVal index As Integer)

        Task.Delay(5000).Wait()
        AppActivate(Comptes(index).AppMITM)
        Task.Delay(5000).Wait()
        SendKeys.SendWait(Comptes(index).Personnage.NomDeCompte)
        Task.Delay(100).Wait()
        SendKeys.SendWait("{TAB}")
        Task.Delay(100).Wait()
        SendKeys.SendWait(Comptes(index).Personnage.MotDePasse)
        Task.Delay(100).Wait()
        SendKeys.SendWait("{ENTER}")

    End Sub

End Class
