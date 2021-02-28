<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateurTrajet
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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CheckBoxActiver = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRecolte = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCombat = New System.Windows.Forms.CheckBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(543, 508)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(562, 546)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RichTextBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(554, 520)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RichTextBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(554, 520)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Banque"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CheckBoxActiver
        '
        Me.CheckBoxActiver.AutoSize = True
        Me.CheckBoxActiver.Location = New System.Drawing.Point(580, 12)
        Me.CheckBoxActiver.Name = "CheckBoxActiver"
        Me.CheckBoxActiver.Size = New System.Drawing.Size(115, 17)
        Me.CheckBoxActiver.TabIndex = 2
        Me.CheckBoxActiver.Text = "Activer le créateur."
        Me.CheckBoxActiver.UseVisualStyleBackColor = True
        '
        'CheckBoxRecolte
        '
        Me.CheckBoxRecolte.AutoSize = True
        Me.CheckBoxRecolte.Location = New System.Drawing.Point(580, 126)
        Me.CheckBoxRecolte.Name = "CheckBoxRecolte"
        Me.CheckBoxRecolte.Size = New System.Drawing.Size(108, 17)
        Me.CheckBoxRecolte.TabIndex = 3
        Me.CheckBoxRecolte.Text = "Activer la recolte."
        Me.CheckBoxRecolte.UseVisualStyleBackColor = True
        '
        'CheckBoxCombat
        '
        Me.CheckBoxCombat.AutoSize = True
        Me.CheckBoxCombat.Location = New System.Drawing.Point(580, 149)
        Me.CheckBoxCombat.Name = "CheckBoxCombat"
        Me.CheckBoxCombat.Size = New System.Drawing.Size(108, 17)
        Me.CheckBoxCombat.TabIndex = 4
        Me.CheckBoxCombat.Text = "Activer le combat"
        Me.CheckBoxCombat.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(543, 508)
        Me.RichTextBox2.TabIndex = 1
        Me.RichTextBox2.Text = ""
        '
        'CreateurTrajet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 570)
        Me.Controls.Add(Me.CheckBoxCombat)
        Me.Controls.Add(Me.CheckBoxRecolte)
        Me.Controls.Add(Me.CheckBoxActiver)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "CreateurTrajet"
        Me.Text = "Createur Trajet"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents CheckBoxActiver As CheckBox
    Friend WithEvents CheckBoxRecolte As CheckBox
    Friend WithEvents CheckBoxCombat As CheckBox
    Friend WithEvents RichTextBox2 As RichTextBox
End Class
