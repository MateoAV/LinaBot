Public Class FrmAmi

    Public Index As Integer
    Private Delegate Sub dlg()
    Dim pseudo As String
    Dim nom As String

#Region "Lancement"

    Private Sub FrmAmi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Comptes(Index)

            Try

                Task.Run(AddressOf Me.Chargement)

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub Chargement()

        With Comptes(Index)

            Try

                If .Connecté Then

                    Dim newAmi As New FunctionAmi
                    newAmi.Ouvre(Index, "ami")

                    AddAmi()
                    AddEnnemi()
                    AddIgnorer()

                    CheckBox_Avertie.Checked = .Ami.Avertie

                    AddHandler .Socket.Reception, AddressOf Reception

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub FrmAmi_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        With Comptes(Index)

            Try

                If .Connecté Then

                    RemoveHandler .Socket.Reception, AddressOf Reception

                    Me.Dispose()

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub Reception(ByVal sender As Object, ByVal e As Socket_EventArgs)

        With Comptes(Index)

            Try

                If InvokeRequired Then

                    Invoke(New dlg(Sub() Reception(sender, e)))

                Else

                    Select Case e.Message(0)

                        Case "F"

                            Select Case e.Message(1)

                                Case "L"

                                    Me.GiAmiEnnemi(Index, e.Message)

                            End Select

                        Case "i"

                            Select Case e.Message(1)

                                Case "L"

                                    Me.GiAmiEnnemi(Index, e.Message)

                            End Select

                    End Select

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

#End Region

#Region "Add"

    Private Sub AddAmi()

        With Comptes(Index)

            Try

                If InvokeRequired Then

                    Invoke(New dlg(Sub() AddAmi()))

                Else

                    For Each pair As KeyValuePair(Of String, CAmiInformation) In .Ami.Ami

                        If pair.Value.Connecte Then

                            With DataGridViewAmi

                                Dim newbutton As New DataGridViewButtonCell
                                newbutton.Value = "Supprimer"
                                .Rows.Add(newbutton.Value)

                                With .Rows(.Rows.Count - 1)

                                    .Cells(1).Value = New Bitmap(Application.StartupPath & "\Image\Personnage\" & pair.Value.ClasseSex & ".png")
                                    .Cells(2).Value = pair.Value.Pseudo & " (" & pair.Value.Nom & ")"
                                    .Cells(3).Value = pair.Value.Niveau
                                    .Cells(4).Value = pair.Value.Alignement
                                    .Cells(5).Value = ""

                                End With

                                .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                            End With

                        Else

                            With DataGridView_Ami_NonConnecter

                                Dim newbutton As New DataGridViewButtonCell
                                newbutton.Value = "Supprimer"
                                .Rows.Add(newbutton.Value)

                                With .Rows(.Rows.Count - 1)

                                    .Cells(1).Value = pair.Value.Pseudo

                                End With

                                .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                            End With

                        End If
                    Next

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub AddEnnemi()

        With Comptes(Index)

            Try

                If InvokeRequired Then

                    Invoke(New dlg(Sub() AddEnnemi()))

                Else

                    For Each pair As KeyValuePair(Of String, CAmiInformation) In .Ami.Ennemi

                    If pair.Value.Connecte Then

                        With DataGridViewEnnemi

                            Dim newbutton As New DataGridViewButtonCell
                            newbutton.Value = "Supprimer"
                            .Rows.Add(newbutton.Value)

                            With .Rows(.Rows.Count - 1)

                                .Cells(1).Value = New Bitmap(Application.StartupPath & "\Image\Personnage\" & pair.Value.ClasseSex & ".png")
                                .Cells(2).Value = pair.Value.Pseudo & " (" & pair.Value.Nom & ")"
                                .Cells(3).Value = pair.Value.Niveau
                                .Cells(4).Value = pair.Value.Alignement
                                .Cells(5).Value = ""

                            End With

                            .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                        End With

                    Else

                        With DataGridView_Ennemi_NonConnecter

                            Dim newbutton As New DataGridViewButtonCell
                            newbutton.Value = "Supprimer"
                            .Rows.Add(newbutton.Value)

                            With .Rows(.Rows.Count - 1)

                                .Cells(1).Value = pair.Value.Pseudo

                            End With

                            .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                        End With

                    End If
                Next

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub AddIgnorer()

        With Comptes(Index)

            Try

                If InvokeRequired Then

                    Invoke(New dlg(Sub() AddIgnorer()))

                Else

                    For Each pair As KeyValuePair(Of String, CAmiInformation) In .Ami.Ignore

                    If pair.Value.Connecte Then

                        With DataGridViewIgnorer

                            Dim newbutton As New DataGridViewButtonCell
                            newbutton.Value = "Supprimer"
                            .Rows.Add(newbutton.Value)

                            With .Rows(.Rows.Count - 1)

                                .Cells(1).Value = New Bitmap(Application.StartupPath & "\Image\Personnage\" & pair.Value.ClasseSex & ".png")
                                .Cells(2).Value = pair.Value.Pseudo & " (" & pair.Value.Nom & ")"
                                .Cells(3).Value = pair.Value.Niveau
                                .Cells(4).Value = pair.Value.Alignement
                                .Cells(5).Value = ""

                            End With

                            .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                        End With

                    End If

                Next

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

#End Region

#Region "data"

    Private Sub GiAmiEnnemi(index As Integer, data As String)

        With Comptes(index)

            Try

                'FL | Leroienculeurné ; 1      ; Linaculers   ; 1     ; 0           ; 7         ; 1    ; 71 
                'FL | Pseudo          ; en ami ; Nom          ; Level ; alignement  ; id classe ; Sexe ; classe + sexe

                Dim separateData As String() = Split(data, "|")

                DataGridViewAmi.Rows.Clear()
                DataGridViewEnnemi.Rows.Clear()

                If separateData.Length > 1 Then

                    For i = 1 To separateData.Count - 1

                        Dim separate As String() = Split(separateData(i), ";")

                        Dim newbutton As New DataGridViewButtonCell
                        newbutton.Value = "Supprimer"

                        'Connecté
                        If separate.Length > 1 Then

                            With If(separateData(0) = "FL", DataGridViewAmi, DataGridViewEnnemi)

                                .Rows.Add(newbutton.Value)

                                With .Rows(.Rows.Count - 1)

                                    .Cells(1).Value = New Bitmap(Application.StartupPath & "\Image\Personnage\" & separate(7) & ".png")
                                    .Cells(2).Value = separate(0) & " (" & separate(2) & ")"
                                    .Cells(3).Value = separate(3)

                                    Select Case separate(4)

                                        Case "0"

                                            .Cells(4).Value = "Neutre"

                                        Case "1"

                                            .Cells(4).Value = "Bontarien"

                                        Case "2"

                                            .Cells(4).Value = "Brakmarien"

                                        Case Else

                                            .Cells(4).Value = "Inconnu"

                                    End Select

                                    .Cells(5).Value = ""

                                End With

                                .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                            End With

                        Else 'Déconnecté

                            With DataGridView_Ami_NonConnecter

                                .Rows.Add(newbutton.Value)

                                With .Rows(.Rows.Count - 1)

                                    .Cells(1).Value = separate(0)

                                End With

                                .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                                .RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

                            End With

                        End If

                    Next

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

#End Region

#Region "Action"

    Private Sub ButtonAjouterAmi_Click(sender As Object, e As EventArgs) Handles ButtonAjouterAmi.Click

        Try

            Dim newAmi As New FunctionAmi
            Task.Run(Function() newAmi.Ajoute(Index, TextBoxAmi.Text, "ami"))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ButtonAjouterEnnemi_Click(sender As Object, e As EventArgs) Handles ButtonAjouterEnnemi.Click

        Try

            Dim newAmi As New FunctionAmi
            Task.Run(Function() newAmi.Ajoute(Index, TextBoxEnnemi.Text, "ennemi"))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridViewEnnemi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEnnemi.CellContentClick

        Try

            pseudo = Split(DataGridViewEnnemi.Rows(e.RowIndex).Cells(2).Value, " ")(0)
            nom = Split(DataGridViewEnnemi.Rows(e.RowIndex).Cells(2).Value, " ")(1).Replace("(", "").Replace(")", "")

            If DataGridViewEnnemi.Rows(e.RowIndex).Cells(0).Selected Then

                Dim newAmi As New FunctionAmi
                Task.Run(Function() newAmi.Supprime(Index, pseudo, "ennemi"))

            Else

                ContextMenuStripAmi.Show()
                ContextMenuStripAmi.Location = New Point(Cursor.Position)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridViewAmi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewAmi.CellContentClick

        Try

            pseudo = Split(DataGridViewAmi.Rows(e.RowIndex).Cells(2).Value, " ")(0)
            nom = Split(DataGridViewAmi.Rows(e.RowIndex).Cells(2).Value, " ")(1).Replace("(", "").Replace(")", "")

            If DataGridViewAmi.Rows(e.RowIndex).Cells(0).Selected Then

                Dim newAmi As New FunctionAmi
                Task.Run(Function() newAmi.Supprime(Index, pseudo, "ami"))

            Else

                ContextMenuStripAmi.Show()
                ContextMenuStripAmi.Location = New Point(Cursor.Position)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView_Ami_NonConnecter_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Ami_NonConnecter.CellContentClick

        Try

            pseudo = DataGridView_Ami_NonConnecter.Rows(e.RowIndex).Cells(1).Value

            If DataGridView_Ami_NonConnecter.Rows(e.RowIndex).Cells(0).Selected Then

                Dim newAmi As New FunctionAmi
                Task.Run(Function() newAmi.Supprime(Index, pseudo, "ami"))

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView_Ennemi_NonConnecter_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Ennemi_NonConnecter.CellContentClick

        Try

            pseudo = DataGridView_Ennemi_NonConnecter.Rows(e.RowIndex).Cells(1).Value

            If DataGridView_Ennemi_NonConnecter.Rows(e.RowIndex).Cells(0).Selected Then

                Dim newAmi As New FunctionAmi
                Task.Run(Function() newAmi.Supprime(Index, pseudo, "ami"))

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub IgnorerPourLaSessionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IgnorerPourLaSessionToolStripMenuItem.Click

        With Comptes(Index)

            Try

                Select Case TabControl1.SelectedTab.Text.ToLower

                    Case "amis"

                        .Ami.Ignore.Add(pseudo, .Ami.Ami(pseudo))

                    Case "ennemis"

                        .Ami.Ignore.Add(pseudo, .Ami.Ennemi(pseudo))

                End Select

            Catch ex As Exception

            End Try

        End With

    End Sub

    Private Sub InformationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformationsToolStripMenuItem.Click

        Try

            Dim newAmi As New FunctionAmi

            Select Case TabControl1.SelectedTab.Text.ToLower

                Case "amis"

                    Task.Run(Function() newAmi.Information(Index, pseudo, "ami"))

                Case "ennemis"

                    Task.Run(Function() newAmi.Information(Index, pseudo, "ennemi"))

            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub MessagePrivéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MessagePrivéToolStripMenuItem.Click

        Try

            Dim newMsg As New FrmMsgPrivee
            newMsg.Index = Index
            newMsg.Nom = nom
            newMsg.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub InviterDansMonGroupeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InviterDansMonGroupeToolStripMenuItem.Click

        Try

            Dim newGroupe As New FunctionGroupe
            Task.Run(Function() newGroupe.Invite(Index, nom))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabControl_Click(sender As Object, e As EventArgs) Handles TabControl1.Click

        Try

            Dim newAmi As New FunctionAmi

            Select Case TabControl1.SelectedTab.Text.ToLower

                Case "amis"

                    Task.Run(Function() newAmi.Ouvre(Index, "ami"))

                Case "ennemis"

                    Task.Run(Function() newAmi.Ouvre(Index, "ennemi"))

            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CheckBox_Avertie_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Avertie.CheckedChanged

        Try

            Dim newAmi As New FunctionAmi
            Task.Run(Function() newAmi.Avertie(Index, CheckBox_Avertie.Checked))

        Catch ex As Exception

        End Try

    End Sub

#End Region


End Class