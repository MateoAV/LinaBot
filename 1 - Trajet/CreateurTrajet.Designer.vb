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
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.CheckBoxActiver = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRecolte = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCombat = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabControl2.SuspendLayout()
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
        Me.TabControl1.Controls.Add(Me.TabPage3)
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
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(543, 508)
        Me.RichTextBox2.TabIndex = 1
        Me.RichTextBox2.Text = ""
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.RichTextBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(554, 520)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Variable"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(543, 508)
        Me.RichTextBox3.TabIndex = 1
        Me.RichTextBox3.Text = "Dim Pods = 80"
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
        Me.CheckBoxRecolte.Location = New System.Drawing.Point(794, 541)
        Me.CheckBoxRecolte.Name = "CheckBoxRecolte"
        Me.CheckBoxRecolte.Size = New System.Drawing.Size(108, 17)
        Me.CheckBoxRecolte.TabIndex = 3
        Me.CheckBoxRecolte.Text = "Activer la recolte."
        Me.CheckBoxRecolte.UseVisualStyleBackColor = True
        '
        'CheckBoxCombat
        '
        Me.CheckBoxCombat.AutoSize = True
        Me.CheckBoxCombat.Location = New System.Drawing.Point(908, 541)
        Me.CheckBoxCombat.Name = "CheckBoxCombat"
        Me.CheckBoxCombat.Size = New System.Drawing.Size(108, 17)
        Me.CheckBoxCombat.TabIndex = 4
        Me.CheckBoxCombat.Text = "Activer le combat"
        Me.CheckBoxCombat.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(576, 535)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(212, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Sauvegarder"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Location = New System.Drawing.Point(580, 34)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(471, 495)
        Me.TabControl2.TabIndex = 6
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(463, 469)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "Pnj"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(463, 469)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "TabPage5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(787, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(107, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Activer la map ID"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CreateurTrajet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1063, 570)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBoxCombat)
        Me.Controls.Add(Me.CheckBoxRecolte)
        Me.Controls.Add(Me.CheckBoxActiver)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "CreateurTrajet"
        Me.Text = "Createur Trajet"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
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
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents CheckBox1 As CheckBox
End Class
