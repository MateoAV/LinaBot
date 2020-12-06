Public Class FrmSort

    Public index As Integer
    Private Delegate Sub dlgSub()


    Private Sub FrmSort_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Comptes(index)

            If .Connecté Then

                LabelCapitalSort.Text = .Personnage.CapitalSort

                SortAjoute(index)

                AddHandler .Socket.Reception, AddressOf Reception

            End If

        End With

    End Sub

    Private Sub FrmSort_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        With Comptes(index)

            RemoveHandler .Socket.Reception, AddressOf Reception

        End With

    End Sub


    'Reception des infos
    Private Sub Reception(ByVal sender As Object, ByVal e As Socket_EventArgs)

        With Comptes(index)

            Try

                If InvokeRequired Then

                    Invoke(New dlgSub(Sub() Reception(sender, e)))

                Else

                    Select Case e.Message(0)

                        Case "A"

                            Select Case e.Message(1)

                                Case "s"

                                    LabelCapitalSort.Text = Split(e.Message, "|")(3).ToString

                            End Select

                        Case "S"

                            Select Case e.Message(1)

                                Case "U"

                                    Select Case e.Message(2)

                                        Case "K"

                                            GiSortUp(index, e.Message)

                                    End Select

                            End Select

                    End Select

                End If

            Catch ex As Exception
            End Try

        End With

    End Sub

    Sub SortAjoute(ByVal index As Integer)

        With Comptes(index)

            Try

                For Each pair As KeyValuePair(Of String, ClassSort) In .Sort

                    Dim newSort As New UcSort

                    With newSort

                        .index = index

                        .LabelNiveau.Text = "Niveau " & pair.Value.Niveau
                        .LabelNom.Text = VarSort(pair.Value.ID)(1).Nom
                        .LabelPA.Text = pair.Value.PA & " PA"
                        .LabelPO.Text = pair.Value.POMinimum & "-" & pair.Value.POMaximum & " PO"
                        .LabelCout.Text = "Coût du niveau suivant : " & pair.Value.NiveauRequisUp

                        .PictureBoxSort.Image = New Bitmap(Application.StartupPath & "\Image\Spell/" & pair.Value.ID & ".png")

                    End With

                    If CInt(LabelCapitalSort.Text) >= pair.Value.Niveau Then

                            If .Personnage.Niveau >= pair.Value.NiveauRequisUp Then

                                newSort.ButtonSort.Visible = True

                            End If

                        End If

                    FlowLayoutPanelSort.Controls.Add(newSort)

                Next

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

        End With

    End Sub

    Sub GiSortUp(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' SUK 142     ~ 4      ~ B
            ' SUK id sort ~ Niveau ~ barre de sort

            Try

                data = Mid(data, 4)

                Dim separateData As String() = Split(data, "~")

                For Each c As Control In FlowLayoutPanelSort.Controls

                    If TypeOf c Is UcSort Then

                        Dim newSort As UcSort = DirectCast(c, UcSort)

                        If VarSort.ContainsKey(separateData(0)) AndAlso VarSort(separateData(0)).ContainsKey(separateData(1)) Then

                            If newSort.LabelNom.Text.ToLower = VarSort(separateData(0))(separateData(1)).Nom.ToLower Then

                                With newSort

                                .index = index

                                .LabelNiveau.Text = "Niveau " & separateData(1)
                                .LabelNom.Text = VarSort(separateData(0))(separateData(1)).Nom
                                .LabelPA.Text = VarSort(separateData(0))(separateData(1)).PA & " PA"
                                .LabelPO.Text = VarSort(separateData(0))(separateData(1)).POMinimum & "-" & VarSort(separateData(0))(separateData(1)).POMaximum & " PO"
                                    .LabelCout.Text = "Coût du niveau suivant : " & VarSort(separateData(0))(separateData(1)).Niveau

                                    .PictureBoxSort.Image = New Bitmap(Application.StartupPath & "\Image\Spell/" & VarSort(separateData(0))(separateData(1)).ID & ".png")

                            End With

                                If CInt(LabelCapitalSort.Text) >= CInt(separateData(1)) Then

                                    If .Personnage.Niveau >= VarSort(separateData(0))(separateData(1)).NiveauRequisUp Then

                                        newSort.ButtonSort.Visible = True

                                    End If

                                End If

                                Exit Sub

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiSortUp", ex.Message)

            End Try

            .BloqueSort.Set()

        End With

    End Sub

    Private Sub LabelCapitalSort_Click(sender As Object, e As EventArgs) Handles LabelCapitalSort.TextChanged

        For Each c As Control In FlowLayoutPanelSort.Controls

            If TypeOf c Is UcSort Then

                Dim cUcSort As UcSort = DirectCast(c, UcSort)

                If CInt(LabelCapitalSort.Text) >= CInt(cUcSort.LabelNiveau.Text) Then

                    If Comptes(index).Personnage.Niveau >= VarSort(Comptes(index).Sort(cUcSort.LabelNom.Text.ToLower).ID)(CInt(cUcSort.LabelNiveau.Text)).NiveauRequisUp Then

                        cUcSort.ButtonSort.Visible = True

                    Else

                        cUcSort.ButtonSort.Visible = False

                    End If

                End If

            End If

        Next

    End Sub

End Class