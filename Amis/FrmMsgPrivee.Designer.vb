<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMsgPrivee
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
        Me.TextBox_Message = New System.Windows.Forms.TextBox()
        Me.Label_Text = New System.Windows.Forms.Label()
        Me.Button_Envoyer = New System.Windows.Forms.Button()
        Me.Button_Ajouter = New System.Windows.Forms.Button()
        Me.Button_Annuler = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox_Message
        '
        Me.TextBox_Message.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Message.Location = New System.Drawing.Point(12, 34)
        Me.TextBox_Message.Multiline = True
        Me.TextBox_Message.Name = "TextBox_Message"
        Me.TextBox_Message.Size = New System.Drawing.Size(494, 143)
        Me.TextBox_Message.TabIndex = 0
        '
        'Label_Text
        '
        Me.Label_Text.AutoSize = True
        Me.Label_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Text.ForeColor = System.Drawing.Color.White
        Me.Label_Text.Location = New System.Drawing.Point(12, 7)
        Me.Label_Text.Name = "Label_Text"
        Me.Label_Text.Size = New System.Drawing.Size(156, 20)
        Me.Label_Text.TabIndex = 1
        Me.Label_Text.Text = "Message privé à X"
        '
        'Button_Envoyer
        '
        Me.Button_Envoyer.BackColor = System.Drawing.Color.Lime
        Me.Button_Envoyer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Envoyer.Location = New System.Drawing.Point(12, 183)
        Me.Button_Envoyer.Name = "Button_Envoyer"
        Me.Button_Envoyer.Size = New System.Drawing.Size(105, 22)
        Me.Button_Envoyer.TabIndex = 2
        Me.Button_Envoyer.Text = "Envoyer"
        Me.Button_Envoyer.UseVisualStyleBackColor = False
        '
        'Button_Ajouter
        '
        Me.Button_Ajouter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Ajouter.Location = New System.Drawing.Point(142, 183)
        Me.Button_Ajouter.Name = "Button_Ajouter"
        Me.Button_Ajouter.Size = New System.Drawing.Size(235, 22)
        Me.Button_Ajouter.TabIndex = 3
        Me.Button_Ajouter.Text = "Ajouter à mes amis"
        Me.Button_Ajouter.UseVisualStyleBackColor = True
        '
        'Button_Annuler
        '
        Me.Button_Annuler.BackColor = System.Drawing.Color.Red
        Me.Button_Annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Annuler.Location = New System.Drawing.Point(402, 183)
        Me.Button_Annuler.Name = "Button_Annuler"
        Me.Button_Annuler.Size = New System.Drawing.Size(104, 22)
        Me.Button_Annuler.TabIndex = 4
        Me.Button_Annuler.Text = "Annuler"
        Me.Button_Annuler.UseVisualStyleBackColor = False
        '
        'FrmMsgPrivee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(521, 217)
        Me.Controls.Add(Me.Button_Annuler)
        Me.Controls.Add(Me.Button_Ajouter)
        Me.Controls.Add(Me.Button_Envoyer)
        Me.Controls.Add(Me.Label_Text)
        Me.Controls.Add(Me.TextBox_Message)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMsgPrivee"
        Me.Text = "Message privé à X"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox_Message As TextBox
    Friend WithEvents Label_Text As Label
    Friend WithEvents Button_Envoyer As Button
    Friend WithEvents Button_Ajouter As Button
    Friend WithEvents Button_Annuler As Button
End Class
