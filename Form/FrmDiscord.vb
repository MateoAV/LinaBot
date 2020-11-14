Public Class FrmDiscord

    Private Sub FrmDiscord_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim swLecture As New IO.StreamReader(Application.StartupPath + "\Data/TokenDiscord.txt")

            Do Until swLecture.EndOfStream

                Dim ligne As String = swLecture.ReadLine

                If ligne <> "" Then

                    TextBox_TokenDiscord.Text = ligne

                End If

            Loop

            swLecture.Close()

            Dim swLectureOption As New IO.StreamReader(Application.StartupPath + "\Data/DiscordOption.txt")

            Do Until swLectureOption.EndOfStream

                Dim ligne As String = swLectureOption.ReadLine

                If ligne <> "" Then

                    Dim separateData As String() = Split(ligne, "|")

                    Select Case separateData(0).ToLower

                        Case "tchat"

                            TextBoxTchat.Text = If(separateData(1) <> "", separateData(1), "")
                            TextBox_TchatInformation.Text = If(separateData(2) <> "", separateData(2), "")
                            TextBox_TchatCommuns.Text = If(separateData(3) <> "", separateData(3), "")
                            TextBox_TchatGroupe.Text = If(separateData(4) <> "", separateData(4), "")
                            TextBox_TchatGuilde.Text = If(separateData(5) <> "", separateData(5), "")
                            TextBox_TchatAlignement.Text = If(separateData(6) <> "", separateData(6), "")
                            TextBox_TchatRecrutement.Text = If(separateData(7) <> "", separateData(7), "")
                            TextBox_TchatCommerce.Text = If(separateData(8) <> "", separateData(8), "")

                    End Select

                End If

            Loop

            swLectureOption.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmDiscord_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        'J'ouvre le fichier pour y écrire se que je souhaite
        Dim swEcriture As New IO.StreamWriter(Application.StartupPath + "\Data\DiscordOption.txt")

        Dim Tchat As String = "Tchat|" & TextBoxTchat.Text & "|" & TextBox_TchatInformation.Text & "|" & TextBox_TchatCommuns.Text & "|" & TextBox_TchatGroupe.Text &
            "|" & TextBox_TchatGuilde.Text & "|" & TextBox_TchatAlignement.Text & "|" & TextBox_TchatRecrutement.Text & "|" & TextBox_TchatCommerce.Text & vbCrLf

        swEcriture.Write(Tchat)

        'Puis je le ferme.
        swEcriture.Close()

    End Sub

    Private Sub TextBox_TokenDiscord_TextChanged(sender As Object, e As EventArgs) Handles TextBox_TokenDiscord.TextChanged
        Try

            'J'ouvre le fichier pour y écrire se que je souhaite
            Dim swEcriture As New IO.StreamWriter(Application.StartupPath + "\Data\TokenDiscord.txt")

            swEcriture.Write(TextBox_TokenDiscord.Text)

            'Puis je le ferme.
            swEcriture.Close()

            LinaBot.TokenDiscord = TextBox_TokenDiscord.Text

        Catch ex As Exception

        End Try

    End Sub

End Class