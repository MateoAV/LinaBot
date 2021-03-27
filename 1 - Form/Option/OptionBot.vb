Public Class OptionBot

    Public Index As Integer

    Private Sub OptionBot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each pair As Dictionary(Of Integer, CSort) In VarSort.Values

            ComboBoxSort.Items.Add(pair.Values(0).Nom)

        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim swEcriture As New IO.StreamWriter(Application.StartupPath + "\Compte\Options/" & Comptes(Index).Personnage.NomDeCompte & "_" & Comptes(Index).Personnage.NomDuPersonnage & ".txt")


        swEcriture.Write("Caracteristique|" & CheckBoxCaracteristique.Checked & "|" & ComboBoxCaracteristique.SelectedItem & vbCrLf &
                         "Sort|" & CheckBoxSort.Checked & "|" & ListeBoxReturn() & vbCrLf &
                         "Proxy|" & CheckBoxProxy.Checked & "|" & TextBox_Proxy_IP.Text & "|" & TextBox_Proxy_Port.Text & "|" & TextBox_Proxy_Ndc.Text & "|" & TextBox_Proxy_Mdp.Text & vbCrLf)

        'Puis je le ferme.
        swEcriture.Close()

    End Sub

    Private Function ListeBoxReturn() As String

        Dim phrase As String = ""

        For i = 0 To ListBoxSort.Items.Count - 1

            phrase &= ListBoxSort.Items(i).ToString & "|"

        Next

        Return phrase

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ListBoxSort.Items.Add(ComboBoxSort.SelectedItem.ToString)

    End Sub

End Class