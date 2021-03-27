Imports Discord.WebSocket

Public Class LinaBot

    Public CompteurCompte As Integer
    Public PathMITM As String
    Public TokenDiscord As String
    Dim _FrmDiscord As New FrmDiscord
    Dim WithEvents DiscordBot As New DiscordSocketClient

    Private Sub LinaBot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try


            Try

                Dim swLecture As New IO.StreamReader(Application.StartupPath + "\Data/PathMITM.txt")

                Do Until swLecture.EndOfStream

                    Dim ligne As String = swLecture.ReadLine

                    If ligne <> "" Then

                        PathMITM = ligne

                    End If

                Loop

                swLecture.Close()

            Catch ex As Exception

            End Try

            ChargeServeur()

            ChargeItems()

            ChargeSort()

            ChargeQuête()

            ChargeMap()

            ChargeRecolte()

            ChargeDivers()

            ChargeMobs()

            ChargePnj()

            ChargePnjRéponse()

            ChargeMaison()

            ChargeMetier()

            ChargeFamilier()

            ChargeCaractéristique()

            LoadPersonage()

            startup()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DiscordBotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiscordBotToolStripMenuItem.Click

        _FrmDiscord = New FrmDiscord
        _FrmDiscord.ShowDialog()

    End Sub

    Private Sub Ajouter_Un_Compte_Click(sender As Object, e As EventArgs) Handles Ajouter_Un_Compte.Click

        FrmAjouterCompte.Show()

    End Sub

    Private Sub Charger_Un_Compte_Click(sender As Object, e As EventArgs) Handles Charger_Un_Compte.Click

        FrmChargerCompte.Show()

    End Sub

    Private Sub Supprimer_Un_Compte_Click(sender As Object, e As EventArgs) Handles Supprimer_Un_Compte.Click

        FrmSupprimerCompte.Show()

    End Sub

    Private Sub MITMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MITMToolStripMenuItem.Click

        PathMITM = InputBox("Veuillez indiquer le chemin vers l'executable de dofus, exemple : ""D:\DOFUS RETRO\""", "Path", "")

        'J'ouvre le fichier pour y écrire se que je souhaite
        Dim swEcriture As New IO.StreamWriter(Application.StartupPath + "\Data/PathMITM.txt")

        swEcriture.Write(PathMITM)

        'Puis je le ferme.
        swEcriture.Close()

    End Sub

#Region "Discord"

    'EN COURS DE CREATION / TEST

    Dim DicoUser As New Dictionary(Of String, SocketUserMessage)

    Public Async Sub startup()

        Try
            Dim swLecture As New IO.StreamReader(Application.StartupPath + "\Data\TokenDiscord.txt")

            TokenDiscord = swLecture.ReadLine()

            'Puis je le ferme.
            swLecture.Close()

            ''this is the function that login the bot and start it
            If DiscordBot.LoginState() = 2 Then
                Await DiscordBot.LogoutAsync()
            End If



            DiscordBot = New DiscordSocketClient()



            ' Label3.ForeColor = Color.Red
            '  Label3.Text = "Status: login in"
            Try
                Await DiscordBot.LoginAsync(tokenType:=Discord.TokenType.Bot, TokenDiscord)
            Catch ex As Exception
                Dim ErrorValue = DirectCast(ex, Discord.Net.HttpException).HttpCode
                If ErrorValue = 401 Then
                    '  Label3.ForeColor = Color.Red
                    '  Label3.Text = "Status: Invalid Token"
                    Return
                End If

            End Try
            'rre
            '  Label3.ForeColor = Color.Orange
            '  Label3.Text = "Status: starting bot"
            Await DiscordBot.StartAsync()

        Catch ex As Exception
            ' MsgBox(ex.Message)

        End Try
    End Sub

    Private Function onMsg(msg As SocketMessage) As Task Handles DiscordBot.MessageReceived

        Dim monchannel As String = msg.Channel.Name
        Dim userMessage = TryCast(msg, SocketUserMessage)
        'DicoUser.Add(userMessage.Author.Username, userMessage)
        'Discord.UserExtensions.SendMessageAsync(userMessage.Author, "dejkhsdkg")


    End Function

    Public Sub sendMsg(monmessage As String, channel As String)

        Try

            Dim channel1 As Discord.IMessageChannel = DiscordBot.GetChannel(channel)
            channel1.SendMessageAsync(monmessage)

        Catch ex As Exception
            '  MsgBox("you must select a channel ID in the box")
        End Try
    End Sub


    Public Sub sendMsgPrivate(msg As String, nom As String)

        Try

            Discord.UserExtensions.SendMessageAsync(DicoUser(nom).Author, msg)

        Catch ex As Exception
            '  MsgBox("you must select a channel ID in the box")
        End Try
    End Sub
#End Region

End Class
