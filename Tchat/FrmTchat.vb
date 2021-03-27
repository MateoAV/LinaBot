Public Class FrmTchat

    Private Delegate Sub Dlg()
    Private index As Integer

    Public Sub New(_Index As Integer)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        index = _Index
        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

#Region "Chargement + Socket"

    Private Sub FrmTchat_Closing(sender As Object, e As EventArgs) Handles MyBase.FormClosing

        With Comptes(index)

            If .Connecté Then

                RemoveHandler .Socket.Reception, AddressOf Reception

            End If

            .FrmTchat = New FrmTchat(index)

        End With

    End Sub

    Private Sub FrmTchat_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

        With Comptes(index)

            If .Connecté Then

                CheckBox_Information.Checked = .Tchat.Canal.Information
                CheckBox_Communs.Checked = .Tchat.Canal.General
                CheckBox_Groupe.Checked = .Tchat.Canal.GroupePriveeEquipe
                CheckBox_Guilde.Checked = .Tchat.Canal.Guilde
                CheckBox_Alignement.Checked = .Tchat.Canal.Alignement
                CheckBox_Recrutement.Checked = .Tchat.Canal.Recrutement
                CheckBox_Commerce.Checked = .Tchat.Canal.Commerce

                AddHandler .Socket.Reception, AddressOf Reception

            End If

        End With

    End Sub

    Private Sub Reception(ByVal sender As Object, ByVal e As Socket_EventArgs)

        With Comptes(index)

            Try

                Select Case e.Message(0)

                    Case "c"

                        Select Case e.Message(1)

                            Case "C"

                                Select Case e.Message(2)

                                    Case "+" ' cC+

                                        Canal(e.Message)

                                    Case "-" ' cC-

                                        Canal(e.Message)

                                End Select

                        End Select

                End Select

            Catch ex As Exception
            End Try

        End With

    End Sub

    Private Sub Canal(data As String)

        If InvokeRequired Then

            Invoke(New Dlg(Sub() Canal(data)))

        Else

            Dim checked As Boolean = If(Mid(data, 3, 1) = "+", True, False)

            'Puis je tcheck lettre par lettre les infos après le "+" ou le "-".
            For i = 3 To data.Length - 1

                Select Case data(i)

                    Case "i" 'Information

                        CheckBox_Information.Checked = checked

                    Case "*" 'Communs/Défaut

                        CheckBox_Communs.Checked = checked

                    Case "#" ', "$", "p" 'groupe/privée/équipe

                        CheckBox_Groupe.Checked = checked

                    Case "%" 'guilde

                        CheckBox_Guilde.Checked = checked

                    Case "!" 'alignement

                        CheckBox_Alignement.Checked = checked

                    Case "?" 'recrutement

                        CheckBox_Recrutement.Checked = checked

                    Case ":" 'Commerce

                        CheckBox_Commerce.Checked = checked

                End Select

            Next

        End If

    End Sub


#End Region

#Region "RichTextBox"

    Dim CompteurTchat, CompteurSocket As Integer

    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles RichTextBoxSocket.TextChanged

        If CompteurSocket > 600 Then

            RichTextBoxSocket.Clear()

            CompteurSocket = 0

        End If

        CompteurSocket += 1

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBoxTchat.TextChanged

        If CompteurTchat > 600 Then

            RichTextBoxTchat.Clear()

            CompteurTchat = 0

        End If

        CompteurTchat += 1

    End Sub

#End Region

#Region "CheckBox"

    Private Sub CheckBox_Information_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Information.Click,
        CheckBox_Communs.Click, CheckBox_Groupe.Click, CheckBox_Guilde.Click,
        CheckBox_Alignement.Click, CheckBox_Recrutement.Click, CheckBox_Commerce.Click

        Task.Run(Sub() CanalActiveDesactive(index, sender.Text, sender.Checked))


    End Sub

#End Region

#Region "Tchat"

    Private Sub TextBox_Tchat_TextChanged(sender As Object, e As KeyEventArgs) Handles TextBox_Tchat.KeyDown

        If e.KeyCode = 13 Then

            ButtonTchat_Click(Nothing, Nothing)

        End If

    End Sub

    Private Sub ButtonTchat_Click(sender As Object, e As EventArgs) Handles Button_Tchat.Click

        Dim message As String = TextBox_Tchat.Text

        Task.Run(Sub() CanalEnvoieMessage(index, message))

        TextBox_Tchat.Text = ""

    End Sub

#End Region

End Class