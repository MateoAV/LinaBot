<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChargerCompte
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelNomGroupe = New System.Windows.Forms.Label()
        Me.TextBoxGroupeNom = New System.Windows.Forms.TextBox()
        Me.ButtonLoadCompte = New System.Windows.Forms.Button()
        Me.ListBoxCompte = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'LabelNomGroupe
        '
        Me.LabelNomGroupe.AutoSize = True
        Me.LabelNomGroupe.ForeColor = System.Drawing.Color.Black
        Me.LabelNomGroupe.Location = New System.Drawing.Point(12, 266)
        Me.LabelNomGroupe.Name = "LabelNomGroupe"
        Me.LabelNomGroupe.Size = New System.Drawing.Size(80, 13)
        Me.LabelNomGroupe.TabIndex = 19
        Me.LabelNomGroupe.Text = "Nom du groupe"
        '
        'TextBoxGroupeNom
        '
        Me.TextBoxGroupeNom.BackColor = System.Drawing.Color.White
        Me.TextBoxGroupeNom.ForeColor = System.Drawing.Color.Black
        Me.TextBoxGroupeNom.Location = New System.Drawing.Point(98, 263)
        Me.TextBoxGroupeNom.Name = "TextBoxGroupeNom"
        Me.TextBoxGroupeNom.Size = New System.Drawing.Size(190, 20)
        Me.TextBoxGroupeNom.TabIndex = 18
        Me.TextBoxGroupeNom.Text = "Groupe"
        Me.TextBoxGroupeNom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonLoadCompte
        '
        Me.ButtonLoadCompte.Location = New System.Drawing.Point(15, 298)
        Me.ButtonLoadCompte.Name = "ButtonLoadCompte"
        Me.ButtonLoadCompte.Size = New System.Drawing.Size(276, 49)
        Me.ButtonLoadCompte.TabIndex = 17
        Me.ButtonLoadCompte.Text = "Charger le(s) compte(s)"
        Me.ButtonLoadCompte.UseVisualStyleBackColor = True
        '
        'ListBoxCompte
        '
        Me.ListBoxCompte.BackColor = System.Drawing.Color.White
        Me.ListBoxCompte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBoxCompte.ForeColor = System.Drawing.Color.Black
        Me.ListBoxCompte.FormattingEnabled = True
        Me.ListBoxCompte.HorizontalScrollbar = True
        Me.ListBoxCompte.Location = New System.Drawing.Point(12, 12)
        Me.ListBoxCompte.Name = "ListBoxCompte"
        Me.ListBoxCompte.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxCompte.Size = New System.Drawing.Size(276, 236)
        Me.ListBoxCompte.TabIndex = 16
        '
        'FrmChargerCompte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 359)
        Me.Controls.Add(Me.LabelNomGroupe)
        Me.Controls.Add(Me.TextBoxGroupeNom)
        Me.Controls.Add(Me.ButtonLoadCompte)
        Me.Controls.Add(Me.ListBoxCompte)
        Me.Name = "FrmChargerCompte"
        Me.Text = "FrmChargerCompte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelNomGroupe As Label
    Friend WithEvents TextBoxGroupeNom As TextBox
    Friend WithEvents ButtonLoadCompte As Button
    Friend WithEvents ListBoxCompte As ListBox
End Class
