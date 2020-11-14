<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSupprimerCompte
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
        Me.ButtonDeleteCompte = New System.Windows.Forms.Button()
        Me.ListBoxCompte = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ButtonDeleteCompte
        '
        Me.ButtonDeleteCompte.Location = New System.Drawing.Point(12, 263)
        Me.ButtonDeleteCompte.Name = "ButtonDeleteCompte"
        Me.ButtonDeleteCompte.Size = New System.Drawing.Size(275, 44)
        Me.ButtonDeleteCompte.TabIndex = 10
        Me.ButtonDeleteCompte.Text = "Supprimer le(s) compte(s)"
        Me.ButtonDeleteCompte.UseVisualStyleBackColor = True
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
        Me.ListBoxCompte.Size = New System.Drawing.Size(275, 236)
        Me.ListBoxCompte.TabIndex = 9
        '
        'FrmSupprimerCompte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 319)
        Me.Controls.Add(Me.ButtonDeleteCompte)
        Me.Controls.Add(Me.ListBoxCompte)
        Me.Name = "FrmSupprimerCompte"
        Me.Text = "FrmSupprimerCompte"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonDeleteCompte As Button
    Friend WithEvents ListBoxCompte As ListBox
End Class
