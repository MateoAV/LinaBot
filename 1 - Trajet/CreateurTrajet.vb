Public Class CreateurTrajet


    Private index As Integer

    Public Sub New(_Index As Integer)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()
        index = _Index
        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Private Sub CreateurTrajet_Load(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Comptes(index).CreateurTrajetBot = New CreateurTrajet(index)
    End Sub

    Public Sub CreateurTrajetBase(index As Integer, cellule As String)

        With Comptes(index)

            Dim Phrase As String = "Map." & If(CheckBox1.Checked, "ID", "Coordonnees") & "(" & """" & If(CheckBox1.Checked, .Map.ID, .Map.Coordonnees) & """" & ")"

            If CheckBoxRecolte.Checked Then

                Phrase &= " : Recolte"

            End If

            If CheckBoxCombat.Checked Then

                Phrase &= " : Map.Attaquer(" & """" & "All" & """" & " , " & """" & "1" & """" & ")"

            End If

            Phrase &= " : Map.Deplacement(" & """" & irhiehgih(index, cellule) & """" & ")"

            Select Case TabControl1.SelectedTab.Text
                Case "Main"
                    RichTextBox1.AppendText(vbTab & Phrase & vbCrLf)
                Case "Banque"
                    RichTextBox2.AppendText(vbTab & Phrase & vbCrLf)
            End Select

        End With

    End Sub

    Private Function irhiehgih(index As Integer, cellule As String)

        With Comptes(index).Map

            Select Case cellule
                Case .Droite
                    Return "Droite"
                Case .Gauche
                    Return "Gauche"
                Case .Haut
                    Return "Haut"
                Case .Bas
                    Return "Bas"
                Case Else
                    Return cellule
            End Select

        End With

    End Function


End Class