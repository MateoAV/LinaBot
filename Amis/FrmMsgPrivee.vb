Public Class FrmMsgPrivee

    Public Index As Integer
    Public Nom As String
    Private Delegate Sub dlg()

    Private Sub FrmMsgPrivee_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Label_Text.Text = "Message privé à " & Nom

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button_Annuler_Click(sender As Object, e As EventArgs) Handles Button_Annuler.Click

        Try

            If InvokeRequired Then

                Invoke(New dlg(Sub() Button_Annuler_Click(Nothing, Nothing)))

            Else

                Me.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button_Envoyer_Click(sender As Object, e As EventArgs) Handles Button_Envoyer.Click

        Try

            Task.Run(AddressOf EnvoieMp)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub EnvoieMp()

        Task.Run(Function() CanalEnvoieMessage(Index, "/w " & Nom & " " & TextBox_Message.Text)).Wait()
        Button_Annuler_Click(Nothing, Nothing)

    End Sub

    Private Sub Button_Ajouter_Click(sender As Object, e As EventArgs) Handles Button_Ajouter.Click

        Try

            Task.Run(AddressOf Ajoute)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Ajoute()

        Try

            Dim newAmi As New FunctionAmi
            Task.Run(Function() newAmi.Ajoute(Index, Nom, "ami")).Wait()
            Button_Annuler_Click(Nothing, Nothing)

        Catch ex As Exception

        End Try

    End Sub

End Class