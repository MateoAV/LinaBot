<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjouterCompte
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
        Me.ButtonAjouter = New System.Windows.Forms.Button()
        Me.ComboBoxChoixServeur = New System.Windows.Forms.ComboBox()
        Me.TextBoxNomPersonnage = New System.Windows.Forms.TextBox()
        Me.TextBoxMotDePasse = New System.Windows.Forms.TextBox()
        Me.TextBoxNomDeCompte = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ButtonAjouter
        '
        Me.ButtonAjouter.Location = New System.Drawing.Point(12, 147)
        Me.ButtonAjouter.Name = "ButtonAjouter"
        Me.ButtonAjouter.Size = New System.Drawing.Size(262, 35)
        Me.ButtonAjouter.TabIndex = 41
        Me.ButtonAjouter.Text = "Ajouter le(s) compte(s)"
        Me.ButtonAjouter.UseVisualStyleBackColor = True
        '
        'ComboBoxChoixServeur
        '
        Me.ComboBoxChoixServeur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxChoixServeur.FormattingEnabled = True
        Me.ComboBoxChoixServeur.Location = New System.Drawing.Point(12, 120)
        Me.ComboBoxChoixServeur.Name = "ComboBoxChoixServeur"
        Me.ComboBoxChoixServeur.Size = New System.Drawing.Size(262, 21)
        Me.ComboBoxChoixServeur.TabIndex = 40
        '
        'TextBoxNomPersonnage
        '
        Me.TextBoxNomPersonnage.BackColor = System.Drawing.Color.White
        Me.TextBoxNomPersonnage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNomPersonnage.ForeColor = System.Drawing.Color.Black
        Me.TextBoxNomPersonnage.Location = New System.Drawing.Point(12, 84)
        Me.TextBoxNomPersonnage.Multiline = True
        Me.TextBoxNomPersonnage.Name = "TextBoxNomPersonnage"
        Me.TextBoxNomPersonnage.Size = New System.Drawing.Size(262, 30)
        Me.TextBoxNomPersonnage.TabIndex = 39
        Me.TextBoxNomPersonnage.Text = "Nom du personnage"
        Me.TextBoxNomPersonnage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxMotDePasse
        '
        Me.TextBoxMotDePasse.BackColor = System.Drawing.Color.White
        Me.TextBoxMotDePasse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxMotDePasse.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMotDePasse.Location = New System.Drawing.Point(12, 48)
        Me.TextBoxMotDePasse.Multiline = True
        Me.TextBoxMotDePasse.Name = "TextBoxMotDePasse"
        Me.TextBoxMotDePasse.Size = New System.Drawing.Size(262, 30)
        Me.TextBoxMotDePasse.TabIndex = 38
        Me.TextBoxMotDePasse.Text = "Mot de passe"
        Me.TextBoxMotDePasse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNomDeCompte
        '
        Me.TextBoxNomDeCompte.BackColor = System.Drawing.Color.White
        Me.TextBoxNomDeCompte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNomDeCompte.ForeColor = System.Drawing.Color.Black
        Me.TextBoxNomDeCompte.Location = New System.Drawing.Point(12, 12)
        Me.TextBoxNomDeCompte.Multiline = True
        Me.TextBoxNomDeCompte.Name = "TextBoxNomDeCompte"
        Me.TextBoxNomDeCompte.Size = New System.Drawing.Size(262, 30)
        Me.TextBoxNomDeCompte.TabIndex = 37
        Me.TextBoxNomDeCompte.Text = "Nom de compte"
        Me.TextBoxNomDeCompte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmAjouterCompte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(286, 194)
        Me.Controls.Add(Me.ButtonAjouter)
        Me.Controls.Add(Me.ComboBoxChoixServeur)
        Me.Controls.Add(Me.TextBoxNomPersonnage)
        Me.Controls.Add(Me.TextBoxMotDePasse)
        Me.Controls.Add(Me.TextBoxNomDeCompte)
        Me.Name = "FrmAjouterCompte"
        Me.Text = "FrmAjouterCompte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonAjouter As Button
    Friend WithEvents ComboBoxChoixServeur As ComboBox
    Friend WithEvents TextBoxNomPersonnage As TextBox
    Friend WithEvents TextBoxMotDePasse As TextBox
    Friend WithEvents TextBoxNomDeCompte As TextBox
End Class
