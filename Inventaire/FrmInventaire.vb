Public Class FrmInventaire

    Public Index As Integer
    Private Delegate Sub dlg()
    Dim IdUnique As Integer

    Private Sub FrmInventaire_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Comptes(Index)

            If .Connecté Then

                AddEquipment()
                AddItem()
                AddPods()
                AddKamas()

                AddHandler .Socket.Reception, AddressOf Reception

            End If

        End With
    End Sub

    Private Sub FrmInventaire_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

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

                        Case "A"

                            Select Case e.Message(1)

                                Case "s"

                                    GiCaractéristique(Index, e.Message)

                            End Select

                        Case "O"

                            Select Case e.Message(1)

                                Case "A"

                                    Select Case e.Message(2)

                                        Case "K"

                                            Select Case e.Message(3)

                                                Case "O"

                                                    GiItemAjoute(Index, e.Message)

                                            End Select

                                    End Select

                                Case "Q"

                                    GiInventaireQuantité(Index, e.Message)

                                Case "R"

                                    GiInventaireItemSupprime(Index, e.Message)

                                Case "M"

                                    GiEquipement(Index, e.Message)

                                Case "C"

                                    Select Case e.Message(2)

                                        Case "O"

                                            GiInventaireChangeCaracteristique(Index, e.Message)

                                    End Select

                                Case "w"

                                    GiPods(Index, e.Message)

                            End Select

                    End Select

                End If

            Catch ex As Exception
            End Try

        End With

    End Sub

#Region "Add"

    Private Sub AddKamas()

        With Comptes(Index)

            LabelKamas.Text = .Personnage.Kamas

        End With

    End Sub

    Private Sub AddPods()

        With Comptes(Index)

            ProgressBarPods.Minimum = 0
            ProgressBarPods.Maximum = .Personnage.Pods.Maximum
            ProgressBarPods.Value = .Personnage.Pods.Actuelle

            ToolTip1.SetToolTip(ProgressBarPods, .Personnage.Pods.Actuelle & "/" & .Personnage.Pods.Maximum & " (" & .Personnage.Pods.Pourcentage & ")")

        End With

    End Sub

    Private Sub AddItem()

        With Comptes(Index)

            For Each pair As KeyValuePair(Of Integer, ClassItem) In .Inventaire

                Dim newLabel As New Label

                With newLabel

                    .ForeColor = Color.White
                    .Text = pair.Value.Quantité
                    .TextAlign = ContentAlignment.TopLeft
                    .BackColor = Color.Transparent

                End With

                Dim newPictureBox As New PictureBox

                With newPictureBox

                    .Size = New Size(65, 65)
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Name = pair.Key

                    Dim newcontext As New ContextMenuStrip
                    newcontext = ContextMenuStripInventaire
                    newcontext.Name = pair.Key
                    .ContextMenuStrip = newcontext

                    AddHandler newLabel.MouseMove, Sub()
                                                       .BackColor = Color.Orange
                                                       IdUnique = pair.Key
                                                   End Sub
                    AddHandler newLabel.MouseLeave, Sub()
                                                        .BackColor = Color.Transparent
                                                    End Sub
                    AddHandler .MouseMove, Sub()
                                               .BackColor = Color.Orange
                                               IdUnique = pair.Key
                                           End Sub
                    AddHandler .MouseLeave, Sub()
                                                .BackColor = Color.Transparent
                                            End Sub

                    If IO.File.Exists(Application.StartupPath & "\Image\Item\" & VarItems(pair.Value.IdObjet).Catégorie & "/" & pair.Value.IdObjet & ".png") Then

                        .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(pair.Value.IdObjet).Catégorie & "/" & pair.Value.IdObjet & ".png")

                    Else

                        .Image = New Bitmap(Application.StartupPath & "\Image\Item\What.png")

                        End If

                        .Controls.Add(newLabel)

                    End With

                ToolTip1.SetToolTip(newPictureBox, pair.Value.Nom)
                FlowLayoutPanelInventory.Controls.Add(newPictureBox)

            Next

        End With

    End Sub

    Private Sub AddEquipment()

        With Comptes(Index)

            For Each Pair As KeyValuePair(Of Integer, ClassItem) In .Inventaire

                If Pair.Value.Equipement <> "" Then

                    If IO.File.Exists(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png") Then

                        Select Case Pair.Value.Equipement

                            Case 0 ' Amulette

                                With PictureBoxAmulet

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 5 'Botte  

                                With PictureBoxBoot

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 1 ' Arme

                                With PictureBoxWeapon

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 8 'Familier 

                                With PictureBoxPet

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 3 'Ceinture 

                                With PictureBoxBelt

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 6 'Coiffe 

                                With PictureBoxCap

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 7, 81 'Cape/Sac

                                With PictureBoxCape

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 2 ' Anneau 1

                                With PictureBoxRing1

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 4 ' Anneau 2

                                With PictureBoxRing2

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 9 ' Dofus 1

                                With PictureBoxDofus1

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 10 ' Dofus 2

                                With PictureBoxDofus2

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 11 ' Dofus 3

                                With PictureBoxDofus3

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 12 ' Dofus 4

                                With PictureBoxDofus4

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 13 ' Dofus 5

                                With PictureBoxDofus5

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                            Case 14 ' Dofus 6

                                With PictureBoxDofus6

                                    .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Pair.Value.IdObjet).Catégorie & "/" & Pair.Value.IdObjet & ".png")
                                    .Name = Pair.Key

                                    AddHandler .MouseMove, Sub()
                                                               .BackColor = Color.Orange
                                                           End Sub
                                    AddHandler .MouseLeave, Sub()
                                                                .BackColor = Color.Transparent
                                                            End Sub

                                End With

                        End Select

                    End If

                End If

            Next

        End With

    End Sub

#End Region

#Region "Data"

    Private Sub GiPods(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' Ow 750         | 3353
            ' Ow Pods actuel | Pods Max

            Dim separateData As String() = Split(Mid(data, 3), "|")

            ProgressBarPods.Minimum = 0
            ProgressBarPods.Maximum = separateData(1)
            ProgressBarPods.Value = separateData(0)

            ToolTip1.SetToolTip(ProgressBarPods, separateData(0) & "/" & separateData(1) & " (" & (separateData(0) / separateData(1)) * 100 & ")")


        End With

    End Sub

    Private Sub GiCaractéristique(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            'As 93821075 ,92071000  ,95886000   |165888|10                                 |8                      |0~0,0,0,0,0,0|793       ,793        |10000         ,10000          |439       |100        |6      ,2            ,0      ,0        ,8       |3      ,0            ,0      ,0        ,3       |0         ,-15             ,0         ,0           |0,248,0,0|220,137,0,0|0,0,0,0|1,30,0,0|158,250,0,0 |0,0,0,0|1,0,0,0|0,0,0,0|0,0,0,0         |0,0,0,0 |0,0,0,0 |0,7,0,0|0,0,0,0      |0,0,0,0       |0,0,0,0        |0,5,0,0|0,0,0,0|55,34,0,0|55,34,0,0|0,4,0,0               |0,0,0,0                |0,0,0,0                   |0,0,0,0                    |0,5,0,0              |0,1,0,0               |0,0,0,0                  |0,0,0,0                   |0,10,0,0           |0,2,0,0             |0,0,0,0                |0,0,0,0                 |0,4,0,0            |0,0,0,0             |0,0,0,0                |0,0,0,0                 |0,3,0,0            |0,0,0,0             |0,0,0,0                |0,0,0,0                 |19
            'As XP Actuel,Xp Minimum,XP Maximum |Kamas |Capital Caractéristiques disponible|Capital Sort disponible|Inconnu      |Pdv_Actuel,PDV_Maximum|Energie_Actuel,Energie_Maximum|Initiative|Prospection|PA_Base,PA_Equipement,PA_Dons,PA_Booste,PA_Total|PM_Base,PM_Equipement,PM_Dons,PM_Booste,PM_Total|Force_Base,Force_Equipement,Force_Dons,Force_Booste|Vitalité |Sagesse    |Chance |Agilité |Intelligence|PO     |Invoc  |Dommage|Dommage Physique|Maîtrise|%Dommage|Soin   |Dommage_Piège|%Dommage_Piège|Renvoie dommage|CC     |EC     |Esq PA   | Esq PM  |Résistance_Neutre_Fixe|%Résistance_Neutre_Fixe|pvp_Résistance_Neutre_Fixe|pvp_%Résistance_Neutre_Fixe|Résistance_Terre_Fixe|%Résistance_Terre_Fixe|pvp_Résistance_Terre_Fixe|pvp_%Résistance_Terre_Fixe|Résistance_Eau_Fixe|%Résistance_Eau_Fixe|pvp_Résistance_Eau_Fixe|pvp_%Résistance_Eau_Fixe|Résistance_Air_Fixe|%Résistance_Air_Fixe|pvp_Résistance_Air_Fixe|pvp_%Résistance_Air_Fixe|Résistance_Feu_Fixe|%Résistance_Feu_Fixe|pvp_Résistance_Feu_Fixe|pvp_%Résistance_Feu_Fixe|Inconnu

            'data reçu :
            'AsXp_Actuel,XP_Minimum,Xp_Maximum| = 0
            'Kamas| = 1

            LabelKamas.Text = Split(data, "|")(1)

        End With

    End Sub

    Private Sub GiInventaireItemSupprime(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' OR 55156977
            ' OR id Unique

            data = Mid(data, 3)

            For Each c As Control In FlowLayoutPanelInventory.Controls

                If TypeOf c Is PictureBox Then

                    If c.Name = data Then

                        FlowLayoutPanelInventory.Controls.RemoveByKey(data)

                        Exit For

                    End If

                End If

            Next

        End With

    End Sub

    Private Sub GiInventaireQuantité(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' OQ 55259212  | 699
            ' OQ Id Unique | Quantité

            data = Mid(data, 3)

            Dim separateData As String() = Split(data, "|")

            For Each c As Control In FlowLayoutPanelInventory.Controls

                If TypeOf c Is PictureBox Then

                    If c.Name = separateData(0) Then

                        For Each cPictureBox As Control In c.Controls

                            If TypeOf cPictureBox Is Label Then

                                cPictureBox.Text = separateData(1)

                                Exit For

                            End If

                        Next

                    End If

                End If

            Next

        End With

    End Sub

    Private Sub GiEquipement(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' OM 123515576 | 7
            ' OM id unique | Numéro équipement

            data = Mid(data, 3)

            Dim separateData As String() = Split(data, "|")

            For Each c As Control In GroupBox1.Controls

                If TypeOf c Is PictureBox Then

                    If separateData(1) <> Nothing Then

                        If IO.File.Exists(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png") Then

                            Select Case separateData(1)

                                Case 0 ' Amulette

                                    PictureBoxAmulet.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxAmulet.Name = separateData(0)

                                Case 5 'Botte  

                                    PictureBoxBoot.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxBoot.Name = separateData(0)

                                Case 1 ' Arme

                                    PictureBoxWeapon.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxWeapon.Name = separateData(0)

                                Case 8 'Familier 

                                    PictureBoxPet.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxPet.Name = separateData(0)

                                Case 3 'Ceinture 

                                    PictureBoxBelt.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxBelt.Name = separateData(0)

                                Case 6 'Coiffe 

                                    PictureBoxCap.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxCap.Name = separateData(0)

                                Case 7, 81 'Cape/Sac

                                    PictureBoxCape.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxCape.Name = separateData(0)

                                Case 2 ' Anneau 1

                                    PictureBoxRing1.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxRing1.Name = separateData(0)

                                Case 4 ' Anneau 2

                                    PictureBoxRing2.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxRing2.Name = separateData(0)

                                Case 9 ' Dofus 1

                                    PictureBoxDofus1.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxDofus1.Name = separateData(0)

                                Case 10 ' Dofus 2

                                    PictureBoxDofus2.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxDofus2.Name = separateData(0)

                                Case 11 ' Dofus 3

                                    PictureBoxDofus3.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxDofus3.Name = separateData(0)

                                Case 12 ' Dofus 4

                                    PictureBoxDofus4.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxDofus4.Name = separateData(0)

                                Case 13 ' Dofus 5

                                    PictureBoxDofus5.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxDofus5.Name = separateData(0)

                                Case 14 ' Dofus 6

                                    PictureBoxDofus6.Image = New Bitmap(Application.StartupPath & "\Image\Item\" & .Inventaire(separateData(0)).Catégorie & "/" & .Inventaire(separateData(0)).IdObjet & ".png")
                                    PictureBoxDofus6.Name = separateData(0)

                            End Select

                        End If

                        Exit For

                    Else

                        If c.Name = separateData(0) Then

                            If IO.File.Exists(Application.StartupPath & "\Image\Item\What.png") Then

                                Dim maPcitureBox As PictureBox = CType(c, PictureBox)

                                maPcitureBox.Image = New Bitmap(Application.StartupPath & "\Image\Item\What.png")

                            End If

                            Exit For

                        End If

                    End If

                End If

            Next

        End With

    End Sub

    Private Sub GiInventaireChangeCaracteristique(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            ' OCO 4a239fd  ~ 1f40    ~ 1        ~ 8                 ~ 320#5#48#9,328#28a#1f5#466,326#0#0#48,327#0#0#18a,9e#2da#0#0#0d0+730 ; 
            ' OCO idUnique ~ IdObjet ~ Quantité ~ Numéro Equipement ~ Caractéristique                                                      ; Next item

            data = Mid(data, 4)

            Dim separateData As String() = Split(data, ";")

            For i = 0 To separateData.Count - 1

                If separateData(i) <> "" Then

                    Dim separateItem As String() = Split(separateData(i), "~")

                    Dim IdUnique As String = Convert.ToInt64(separateItem(0), 16)

                    For Each c As Control In GroupBox1.Controls

                        If TypeOf c Is PictureBox Then

                            If c.Name = IdUnique Then

                                For Each cPictureBox As Control In c.Controls

                                    If TypeOf cPictureBox Is Label Then

                                        cPictureBox.Text = Convert.ToInt64(separateItem(2), 16).ToString

                                        Exit For

                                    End If

                                Next

                                Exit For

                            End If

                        End If

                    Next

                End If

            Next

        End With

    End Sub

    Private Sub GiItemAjoute(ByVal index As Integer, ByVal data As String)

        With Comptes(index)

            Try

                ' 262c1bc   ~ 241      ~ 5        ~ 1                 ~ 64#2#4#0#1d3+1  ,
                ' Id unique ~ Id Objet ~ Quantité ~ Numéro Equipement ~ Caractéristique , etc... ; tchatItem Suivant

                If data <> "" Then

                    Dim separateData As String() = Split(data, ";")

                    For i = 0 To separateData.Count - 2

                        Dim separateItem As String() = Split(separateData(i), "~")

                        Dim newLabel As New Label

                        With newLabel

                            .ForeColor = Color.White
                            .Text = Convert.ToInt64(separateItem(2), 16).ToString
                            .TextAlign = ContentAlignment.TopLeft
                            .BackColor = Color.Transparent

                        End With

                        Dim newPictureBox As New PictureBox With {.Size = New Size(65, 65), .SizeMode = PictureBoxSizeMode.Zoom, .Name = Convert.ToInt64(separateItem(0), 16).ToString}

                        With newPictureBox

                            .Size = New Size(65, 65)
                            .SizeMode = PictureBoxSizeMode.Zoom
                            .Name = Convert.ToInt64(separateItem(0), 16).ToString

                            If IO.File.Exists(Application.StartupPath & "\Image\Item\" & VarItems(Convert.ToInt64(separateItem(1), 16)).Catégorie & "/" & Convert.ToInt64(separateItem(1), 16).ToString & ".png") Then

                                .Image = New Bitmap(Application.StartupPath & "\Image\Item\" & VarItems(Convert.ToInt64(separateItem(1), 16)).Catégorie & "/" & Convert.ToInt64(separateItem(1), 16).ToString & ".png")

                            Else

                                .Image = New Bitmap(Application.StartupPath & "\Image\Item\What.png")

                            End If

                            .Controls.Add(newLabel)

                        End With

                        ToolTip1.SetToolTip(newPictureBox, VarItems(Convert.ToInt64(separateItem(1), 16)).Nom)
                        FlowLayoutPanelInventory.Controls.Add(newPictureBox)

                    Next

                End If

            Catch ex As Exception

                ErreurFichier(index, .Personnage.NomDuPersonnage, "GiItemAjoute", data & vbCrLf & ex.Message)

            End Try

        End With

    End Sub

#End Region

#Region "Action"

    Private Sub EquipéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EquipéToolStripMenuItem.Click

        Dim _IDUnique As Integer = IdUnique
        Dim newItem As New FunctionItem
        newItem.Equipe(Index, _IDUnique)

    End Sub

    Private Sub DesequiperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesequiperToolStripMenuItem.Click

        Dim _IDUnique As Integer = IdUnique
        Dim newItem As New FunctionItem
        newItem.Desequipe(Index, _IDUnique)

    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        Dim _IDUnique As Integer = IdUnique
        Dim Quantité As String = InputBox("Veuillez indiquer la quantité à supprimer (Minimum 1)", "Quantité", "1")
        Dim newItem As New FunctionItem
        newItem.Supprime(Index, _IDUnique, Quantité)

    End Sub

    Private Sub UtiliserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UtiliserToolStripMenuItem.Click

        Dim _IDUnique As Integer = IdUnique
        Dim newItem As New FunctionItem
        newItem.Utilise(Index, _IDUnique)

    End Sub

    Private Sub JeterAuSolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JeterAuSolToolStripMenuItem.Click

        Dim _IDUnique As Integer = IdUnique
        Dim Quantité As String = InputBox("Veuillez indiquer la quantité à jeter au sol (Minimum 1)", "Quantité", "1")
        Dim newItem As New FunctionItem
        newItem.Jette(Index, _IDUnique, Quantité)

    End Sub

#End Region

End Class


