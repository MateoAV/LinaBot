Public Class FrmAmi

    Public Index As Integer
    Private Delegate Sub dlg()
    Dim pseudo As String
    Dim nom As String

    Private Sub FrmAmi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Comptes(Index)

            If .Connecté Then

                AddAmi()
                AddEnnemi()
                AddIgnorer()

                AddHandler .Socket.Reception, AddressOf Reception

            End If

        End With

    End Sub

    Private Sub FrmAmi_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        With Comptes(Index)

            If .Connecté Then

                RemoveHandler .Socket.Reception, AddressOf Reception

                Me.Dispose()

            End If

        End With

    End Sub

    Private Sub Reception(ByVal sender As Object, ByVal e As Socket_EventArgs)

        With Comptes(Index)

            Try

                If InvokeRequired Then

                    Invoke(New dlg(Sub() Reception(sender, e)))

                Else

                    Select Case e.Message(0)

                        Case ""


                    End Select

                End If

            Catch ex As Exception
            End Try

        End With

    End Sub


#Region "Add"

    Private Sub AddAmi()

        With Comptes(Index)

            For Each pair As KeyValuePair(Of String, ClassAmiInformation) In .Ami.Ami

                If pair.Value.Connecte Then

                    With DataGridViewAmi

                        Dim newbutton As New DataGridViewButtonCell
                        newbutton.Value = "Supprimer"
                        .Rows.Add(newbutton)

                        With .Rows(.Rows.Count - 1)

                            .Cells(1).Value = New Bitmap(Application.StartupPath & "\Image\Personnage\" & pair.Value.ClasseSex & ".png")
                            .Cells(2).Value = pair.Value.Pseudo & " (" & pair.Value.Nom & ")"
                            .Cells(3).Value = pair.Value.Niveau
                            .Cells(4).Value = pair.Value.Alignement
                            ' .Cells(5).Value = pair.Value.

                        End With

                    End With

                Else

                    With DataGridView_Ami_NonConnecter

                        Dim newbutton As New DataGridViewButtonCell
                        newbutton.Value = "Supprimer"
                        .Rows.Add(newbutton)

                        With .Rows(.Rows.Count - 1)

                            .Cells(1).Value = pair.Value.Pseudo

                        End With

                    End With

                End If
            Next

        End With

    End Sub

    Private Sub AddEnnemi()

        With Comptes(Index)

            For Each pair As KeyValuePair(Of String, ClassAmiInformation) In .Ami.Ennemi

                If pair.Value.Connecte Then

                    With DataGridViewEnnemi

                        Dim newbutton As New DataGridViewButtonCell
                        newbutton.Value = "Supprimer"
                        .Rows.Add(newbutton)

                        With .Rows(.Rows.Count - 1)

                            .Cells(1).Value = New Bitmap(Application.StartupPath & "\Image\Personnage\" & pair.Value.ClasseSex & ".png")
                            .Cells(2).Value = pair.Value.Pseudo & " (" & pair.Value.Nom & ")"
                            .Cells(3).Value = pair.Value.Niveau
                            .Cells(4).Value = pair.Value.Alignement
                            ' .Cells(5).Value = pair.Value.

                        End With

                    End With

                Else

                    With DataGridView_Ennemi_NonConnecter

                        Dim newbutton As New DataGridViewButtonCell
                        newbutton.Value = "Supprimer"
                        .Rows.Add(newbutton)

                        With .Rows(.Rows.Count - 1)

                            .Cells(1).Value = pair.Value.Pseudo

                        End With

                    End With

                End If
            Next

        End With

    End Sub

    Private Sub AddIgnorer()

        With Comptes(Index)

            For Each pair As KeyValuePair(Of String, ClassAmiInformation) In .Ami.Ignore

                If pair.Value.Connecte Then

                    With DataGridViewIgnorer

                        Dim newbutton As New DataGridViewButtonCell
                        newbutton.Value = "Supprimer"
                        .Rows.Add(newbutton)

                        With .Rows(.Rows.Count - 1)

                            .Cells(1).Value = New Bitmap(Application.StartupPath & "\Image\Personnage\" & pair.Value.ClasseSex & ".png")
                            .Cells(2).Value = pair.Value.Pseudo & " (" & pair.Value.Nom & ")"
                            .Cells(3).Value = pair.Value.Niveau
                            .Cells(4).Value = pair.Value.Alignement
                            ' .Cells(5).Value = pair.Value.

                        End With

                    End With

                End If

            Next

        End With

    End Sub

#End Region

#Region "data"

    Sub GiAmiEnnemi(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                'FL | Leroienculeurné ; 1      ; Linaculers   ; 1     ; 0           ; 7         ; 1    ; 71 
                'FL | Pseudo          ; en ami ; Nom          ; Level ; alignement  ; id classe ; Sexe ; classe + sexe

                Dim separateData As String() = Split(data, "|")

                .Ami.Ami.Clear()
                .Ami.Ennemi.Clear()

                If separateData.Length > 1 Then

                    For i = 1 To separateData.Count - 1

                        Dim separate As String() = Split(separateData(i), ";")

                        Dim newFriend As New ClassAmiInformation

                        With newFriend

                            If separate.Length > 1 Then

                                .Pseudo = separate(0)
                                .Connecte = separate(1)
                                .Nom = separate(2)
                                .Niveau = separate(3)

                                Select Case separate(4)

                                    Case "0"

                                        .Alignement = "Neutre"

                                    Case "1"

                                        .Alignement = "Bontarien"

                                    Case "2"

                                        .Alignement = "Brakmarien"

                                    Case Else

                                        .Alignement = "Inconnu"

                                End Select

                                Select Case separate(5)

                                    Case "1"

                                        .Classe = "Feca"

                                    Case "2"

                                        .Classe = "Osamodas"

                                    Case "3"

                                        .Classe = "Enutrof"

                                    Case "4"

                                        .Classe = "Sram"

                                    Case "5"

                                        .Classe = "Xelor"

                                    Case "6"

                                        .Classe = "Ecaflip"

                                    Case "7"

                                        .Classe = "Eniripsa"

                                    Case "8"

                                        .Classe = "Iop"

                                    Case "9"

                                        .Classe = "Cra"

                                    Case "10"

                                        .Classe = "Sadida"

                                    Case "11"

                                        .Classe = "Sacrieur"

                                    Case "12"

                                        .Classe = "Pandawa"

                                End Select

                                Select Case separate(6)

                                    Case "0"

                                        .Sex = "Male"

                                    Case "1"

                                        .Sex = "Femelle"

                                End Select

                                .ClasseSex = separate(7)

                            Else

                                .Pseudo = separate(0)
                                .Connecte = False
                                .Nom = ""
                                .Niveau = ""
                                .Sex = ""
                                .Classe = ""
                                .ClasseSex = ""
                                .Alignement = ""

                            End If

                        End With

                        Select Case separateData(0)

                            Case "FL"

                                .Ami.Ami.Add(separate(0), newFriend)

                            Case "iL"

                                .Ami.Ennemi.Add(separate(0), newFriend)

                        End Select

                    Next

                End If

                .Ami.BloqueAmi.Set()

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiAmiEnnemi", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

    Private Sub ButtonAjouterAmi_Click(sender As Object, e As EventArgs) Handles ButtonAjouterAmi.Click

        Dim newAmi As New FunctionAmi
        newAmi.Ajoute(Index, TextBoxAmi.Text, "ami")

    End Sub

    Private Sub ButtonAjouterEnnemi_Click(sender As Object, e As EventArgs) Handles ButtonAjouterEnnemi.Click

        Dim newAmi As New FunctionAmi
        newAmi.Ajoute(Index, TextBoxAmi.Text, "ennemi")

    End Sub

    Private Sub DataGridViewEnnemi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEnnemi.CellContentClick

        pseudo = Split(DataGridViewEnnemi.Rows(e.RowIndex).Cells(2).Value, " ")(0)
        nom = Split(DataGridViewEnnemi.Rows(e.RowIndex).Cells(2).Value, " ")(0).Replace("(", "").Replace(")", "")

        If DataGridViewEnnemi.Rows(e.RowIndex).Cells(0).Selected Then

            Dim newAmi As New FunctionAmi
            newAmi.Supprime(Index, pseudo, "ennemi")

        Else

            ContextMenuStripAmi.Show()
            ContextMenuStripAmi.Location = New Point(Cursor.Position)

        End If

    End Sub

    Private Sub DataGridViewAmi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewAmi.CellContentClick

        pseudo = Split(DataGridViewAmi.Rows(e.RowIndex).Cells(2).Value, " ")(0)
        nom = Split(DataGridViewAmi.Rows(e.RowIndex).Cells(2).Value, " ")(0).Replace("(", "").Replace(")", "")

        If DataGridViewAmi.Rows(e.RowIndex).Cells(0).Selected Then

            Dim newAmi As New FunctionAmi
            newAmi.Supprime(Index, pseudo, "ami")

        Else

            ContextMenuStripAmi.Show()
            ContextMenuStripAmi.Location = New Point(Cursor.Position)

        End If

    End Sub

    Private Sub DataGridView_Ami_NonConnecter_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Ami_NonConnecter.CellContentClick

        pseudo = DataGridView_Ami_NonConnecter.Rows(e.RowIndex).Cells(1).Value

        If DataGridView_Ami_NonConnecter.Rows(e.RowIndex).Cells(0).Selected Then

            Dim newAmi As New FunctionAmi
            newAmi.Supprime(Index, pseudo, "ami")

        End If

    End Sub

    Private Sub DataGridView_Ennemi_NonConnecter_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Ennemi_NonConnecter.CellContentClick

        pseudo = DataGridView_Ennemi_NonConnecter.Rows(e.RowIndex).Cells(1).Value

        If DataGridView_Ennemi_NonConnecter.Rows(e.RowIndex).Cells(0).Selected Then

            Dim newAmi As New FunctionAmi
            newAmi.Supprime(Index, pseudo, "ami")

        End If

    End Sub

#End Region

End Class