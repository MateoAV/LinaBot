Public Class FrmUser

    Public index As Integer
    Private Delegate Sub DlgFrmUser()

    Private Sub ConnecterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnecterToolStripMenuItem.Click

        With Comptes(index)

            '  Dim newd As New FunctionAmi
            '  Dim info As Reflection.MethodInfo() = GetType(FunctionAmi).GetMethods
            '  Dim para As String() = {"1", "8", "8"}
            '  For i = 0 To info.Count - 1
            '      If info(i).Name = "Supprime" Then
            '          Dim eug = info(1).Invoke(newd, para)
            '      End If
            '  Next


            'FONCTIONNE
            ' Dim newd As New FunctionAmi
            ' Dim info As Reflection.MethodInfo = GetType(FunctionAmi).GetMethod("Ouvre")
            ' Dim eug = info.Invoke(newd, {"0", "o"})




            .MITM = True
            .Main()
            .AppMITM = Shell(LinaBot.PathMITM & "/Dofus Retro.exe", AppWinStyle.NormalNoFocus)

        End With

    End Sub

    Private Sub ConnecterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConnecterToolStripMenuItem1.Click

        With Comptes(index)

            .MITM = False

            Select Case .Connecté

                Case True

                    .Socket.Connexion_Game(False)

                Case False

                    Select Case .EnConnexion

                        Case True

                            .Socket_Authentification.Connexion_Game(False)

                        Case False

                            .CreateSocketAuthentification(VarServeur("Authentification").IP, VarServeur("Authentification").Port)

                    End Select

            End Select

        End With

    End Sub

    Private Sub DéconnecterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DéconnecterToolStripMenuItem1.Click, DéconnecterToolStripMenuItem.Click

        With Comptes(index)

            If .EnAuthentification Then

                .Socket_Authentification.Connexion_Game(False)

            ElseIf .Connecté Then

                .Socket.Connexion_Game(False)

            ElseIf .EnConnexion AndAlso .EnAuthentification = False Then

                .Socket.Connexion_Game(False)

            End If

        End With

    End Sub

    Private Sub TimerRegeneration_Tick(sender As Object, e As EventArgs) Handles TimerRegeneration.Tick

        With Comptes(index)

            If .Combat.EnCombat = False AndAlso .Connecté Then

                With ProgressBarVitaliter

                    If .Value + 1 < .Maximum Then

                        .Value += 1

                    End If

                    ToolTip1.SetToolTip(ProgressBarVitaliter, (.Value / .Maximum) * 100)

                End With

            End If

        End With

    End Sub

    Private Sub TimerStatut_Tick(sender As Object, e As EventArgs) Handles TimerStatut.Tick

        With Comptes(index)

            If .EnAuthentification Then

                LabelEtat.Text = "En Connexion"
                LabelEtat.ForeColor = Color.Orange

            ElseIf .EnConnexion Then

                LabelEtat.Text = "Connexion en cours..."
                LabelEtat.ForeColor = Color.Orange

            ElseIf .Connecté Then

                LabelEtat.Text = "Connecté"
                LabelEtat.ForeColor = Color.Lime

            ElseIf .Connecté = False AndAlso .EnAuthentification = False AndAlso .EnConnexion = False Then

                LabelEtat.Text = "Déconnecté"
                LabelEtat.ForeColor = Color.Red

            End If

            If .Map.EnDeplacement Then

                LabelStatut.Text = "En Déplacement"
                LabelStatut.ForeColor = Color.Cyan

            Else

                If .Connecté Then

                    LabelStatut.Text = "En Attente"
                    LabelStatut.ForeColor = Color.White

                Else

                    LabelStatut.Text = "Inconnu"
                    LabelStatut.ForeColor = Color.Red

                End If

            End If

        End With

    End Sub

#Region "Button"

    Private Sub ButtonCaracteristique_Click(sender As Object, e As EventArgs) Handles ButtonCaracteristique.Click

        Dim newCaract As New FrmCaracteristique
        newCaract.index = index
        newCaract.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim newSort As New FrmSort
        newSort.index = index
        newSort.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim newInventaire As New FrmInventaire
        newInventaire.index = index
        newInventaire.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

    End Sub

    Private Sub FrmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Comptes(index)

            ChargementOption(index)

        End With

    End Sub



    Private Sub ButtonIA_Click(sender As Object, e As EventArgs) Handles ButtonIA.Click

        With Comptes(index)

            ButtonIA.BackgroundImage = My.Resources.Ampoule_Off

            Dim Ouverture_Fichier As New OpenFileDialog

            If Ouverture_Fichier.ShowDialog = 1 Then

                Task.Run(Sub() IAChargement(index, Ouverture_Fichier.FileName))

                ButtonIA.BackgroundImage = My.Resources.Ampoule_On

            End If

        End With

    End Sub

    Private Sub Button_Option_Click(sender As Object, e As EventArgs) Handles Button_Option.Click

        'appelle un frm pour fairte les options.
        Dim newOption As New OptionBot
        newOption.Index = index
        newOption.Show()

    End Sub

    Private Sub ButtonDll_Click(sender As Object, e As EventArgs) Handles ButtonDll.Click

        'Charge Autant de Dll Voulu.
        With Comptes(index)

            If InvokeRequired Then

                Invoke(New DlgFrmUser(Sub() ButtonDll_Click(Nothing, Nothing)))

            Else

                Try

                    If .ThreadDll IsNot Nothing AndAlso .ThreadDll.IsAlive Then

                        .ThreadDll.Abort()

                        ButtonDll.BackgroundImage = My.Resources.DllBlue

                        Return

                    End If

                    Dim Ouverture_Fichier As New OpenFileDialog

                    If Ouverture_Fichier.ShowDialog = 1 Then

                        Dim path As String = Ouverture_Fichier.FileName
                        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(path)
                        Dim nomDLL As String = Split(a.ManifestModule.Name, ".")(0)
                        Dim nomClass = a.ExportedTypes(0).Name
                        Dim monType = a.ExportedTypes(0).UnderlyingSystemType
                        Dim lesSubs() = monType.GetMethods
                        Dim nomSub As String = lesSubs(0).Name
                        Dim mytype As Type = a.GetType(nomDLL.Replace(" ", "_") & "." & nomClass)

                        .ThreadDll = New Threading.Thread(Sub() LaunchPath(mytype.GetMethod(nomSub), Activator.CreateInstance(mytype))) With {.IsBackground = True}
                        .ThreadDll.Start()

                        ButtonDll.BackgroundImage = My.Resources.DllRed

                    Else

                        ButtonDll.BackgroundImage = My.Resources.DllBlue

                    End If

                Catch ex As Exception

                    MsgBox(ex.Message)

                End Try

            End If

        End With

    End Sub

    Private Sub LaunchPath(mymethod As System.Reflection.MethodInfo, obj As Object)

        Try

            mymethod.Invoke(obj, {index})

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub ButtonTchat_Click(sender As Object, e As EventArgs) Handles ButtonTchat.Click

        Comptes(index).FrmTchat.Show()

    End Sub



#End Region

End Class
