Public Class UcSort

    Public index As Integer

    Private Sub UcSort_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, PictureBoxSort.MouseMove, LabelCout.MouseMove, LabelNiveau.MouseMove, LabelNom.MouseMove, LabelPA.MouseMove, LabelPO.MouseMove, ButtonSort.MouseMove
        Me.BackColor = Color.Orange
    End Sub

    Private Sub UcSort_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        Me.BackColor = Color.FromArgb(51, 56, 60)
    End Sub

    Private Sub ButtonSort_Click(sender As Object, e As EventArgs) Handles ButtonSort.Click

        With Comptes(index)

            Try

                .Send("SB" & .Sort(LabelNom.Text.ToLower).ID)

            Catch ex As Exception

            End Try

        End With

    End Sub

End Class
