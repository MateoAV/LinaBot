Public Class FrmGroupe

    Public BotIndex As New List(Of Integer)
    Public Trajet As New Dictionary(Of String, List(Of String))
    Public ThreadTrajet As Threading.Thread
    Public Pods As Integer

    Public Variable As New Dictionary(Of String, Dictionary(Of Object, Object))

    Private Delegate Sub dlgSub()

    Private Sub ButtonTrajet_Click(sender As Object, e As EventArgs) Handles ButtonTrajet.Click

        If InvokeRequired Then

            Invoke(New dlgSub(Sub() ButtonTrajet_Click(Nothing, Nothing)))

        Else

            If ThreadTrajet IsNot Nothing AndAlso ThreadTrajet.IsAlive Then

                ThreadTrajet.Abort()

                ButtonTrajet.BackgroundImage = My.Resources.Parchemin_Off

            Else

                Dim Ouverture_Fichier As New OpenFileDialog

                If Ouverture_Fichier.ShowDialog = 1 Then

                    ThreadTrajet = New Threading.Thread(Sub() TrajetLoad(BotIndex.Item(0), Ouverture_Fichier.FileName)) With {.IsBackground = True}
                    ThreadTrajet.Start()

                    ButtonTrajet.BackgroundImage = My.Resources.Parchemin_On

                End If

            End If

        End If

    End Sub

End Class