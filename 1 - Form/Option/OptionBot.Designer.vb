<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionBot
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxProxy = New System.Windows.Forms.CheckBox()
        Me.TextBox_Proxy_Mdp = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Proxy_Ndc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_Proxy_Port = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_Proxy_IP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ListBoxSort = New System.Windows.Forms.ListBox()
        Me.CheckBoxSort = New System.Windows.Forms.CheckBox()
        Me.ComboBoxSort = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxCaracteristique = New System.Windows.Forms.CheckBox()
        Me.ComboBoxCaracteristique = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 399)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(768, 373)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBoxProxy)
        Me.GroupBox3.Controls.Add(Me.TextBox_Proxy_Mdp)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.TextBox_Proxy_Ndc)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.TextBox_Proxy_Port)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.TextBox_Proxy_IP)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(6, 233)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(756, 50)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Proxy"
        '
        'CheckBoxProxy
        '
        Me.CheckBoxProxy.AutoSize = True
        Me.CheckBoxProxy.Location = New System.Drawing.Point(8, 20)
        Me.CheckBoxProxy.Name = "CheckBoxProxy"
        Me.CheckBoxProxy.Size = New System.Drawing.Size(59, 17)
        Me.CheckBoxProxy.TabIndex = 8
        Me.CheckBoxProxy.Text = "Activer"
        Me.CheckBoxProxy.UseVisualStyleBackColor = True
        '
        'TextBox_Proxy_Mdp
        '
        Me.TextBox_Proxy_Mdp.Location = New System.Drawing.Point(623, 18)
        Me.TextBox_Proxy_Mdp.Name = "TextBox_Proxy_Mdp"
        Me.TextBox_Proxy_Mdp.Size = New System.Drawing.Size(124, 20)
        Me.TextBox_Proxy_Mdp.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(527, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Mot de passe"
        '
        'TextBox_Proxy_Ndc
        '
        Me.TextBox_Proxy_Ndc.Location = New System.Drawing.Point(403, 18)
        Me.TextBox_Proxy_Ndc.Name = "TextBox_Proxy_Ndc"
        Me.TextBox_Proxy_Ndc.Size = New System.Drawing.Size(118, 20)
        Me.TextBox_Proxy_Ndc.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(293, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Nom de compte"
        '
        'TextBox_Proxy_Port
        '
        Me.TextBox_Proxy_Port.Location = New System.Drawing.Point(246, 18)
        Me.TextBox_Proxy_Port.Name = "TextBox_Proxy_Port"
        Me.TextBox_Proxy_Port.Size = New System.Drawing.Size(41, 20)
        Me.TextBox_Proxy_Port.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(194, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "PORT"
        '
        'TextBox_Proxy_IP
        '
        Me.TextBox_Proxy_IP.Location = New System.Drawing.Point(95, 18)
        Me.TextBox_Proxy_IP.Name = "TextBox_Proxy_IP"
        Me.TextBox_Proxy_IP.Size = New System.Drawing.Size(93, 20)
        Me.TextBox_Proxy_IP.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(69, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IP"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.ListBoxSort)
        Me.GroupBox2.Controls.Add(Me.CheckBoxSort)
        Me.GroupBox2.Controls.Add(Me.ComboBoxSort)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(6, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(756, 162)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sort"
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(279, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ListBoxSort
        '
        Me.ListBoxSort.FormattingEnabled = True
        Me.ListBoxSort.Location = New System.Drawing.Point(6, 46)
        Me.ListBoxSort.Name = "ListBoxSort"
        Me.ListBoxSort.Size = New System.Drawing.Size(300, 108)
        Me.ListBoxSort.TabIndex = 3
        '
        'CheckBoxSort
        '
        Me.CheckBoxSort.AutoSize = True
        Me.CheckBoxSort.Location = New System.Drawing.Point(312, 21)
        Me.CheckBoxSort.Name = "CheckBoxSort"
        Me.CheckBoxSort.Size = New System.Drawing.Size(168, 17)
        Me.CheckBoxSort.TabIndex = 2
        Me.CheckBoxSort.Text = "Up automatiquement les sorts."
        Me.CheckBoxSort.UseVisualStyleBackColor = True
        '
        'ComboBoxSort
        '
        Me.ComboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSort.FormattingEnabled = True
        Me.ComboBoxSort.Location = New System.Drawing.Point(6, 19)
        Me.ComboBoxSort.Name = "ComboBoxSort"
        Me.ComboBoxSort.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxSort.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxCaracteristique)
        Me.GroupBox1.Controls.Add(Me.ComboBoxCaracteristique)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(756, 53)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Caracteristique"
        '
        'CheckBoxCaracteristique
        '
        Me.CheckBoxCaracteristique.AutoSize = True
        Me.CheckBoxCaracteristique.Location = New System.Drawing.Point(168, 21)
        Me.CheckBoxCaracteristique.Name = "CheckBoxCaracteristique"
        Me.CheckBoxCaracteristique.Size = New System.Drawing.Size(210, 17)
        Me.CheckBoxCaracteristique.TabIndex = 2
        Me.CheckBoxCaracteristique.Text = "Up automatiquement la caracteristique."
        Me.CheckBoxCaracteristique.UseVisualStyleBackColor = True
        '
        'ComboBoxCaracteristique
        '
        Me.ComboBoxCaracteristique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCaracteristique.FormattingEnabled = True
        Me.ComboBoxCaracteristique.Items.AddRange(New Object() {"Rien", "Vitaliter", "Sagesse", "Force", "Intelligence", "Chance", "Agiliter"})
        Me.ComboBoxCaracteristique.Location = New System.Drawing.Point(6, 19)
        Me.ComboBoxCaracteristique.Name = "ComboBoxCaracteristique"
        Me.ComboBoxCaracteristique.Size = New System.Drawing.Size(156, 21)
        Me.ComboBoxCaracteristique.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 417)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Sauvegarder"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OptionBot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "OptionBot"
        Me.Text = "OptionBot"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBoxSort As CheckBox
    Friend WithEvents ComboBoxSort As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBoxCaracteristique As CheckBox
    Friend WithEvents ComboBoxCaracteristique As ComboBox
    Friend WithEvents ListBoxSort As ListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBox_Proxy_Mdp As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox_Proxy_Ndc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_Proxy_Port As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_Proxy_IP As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents CheckBoxProxy As CheckBox
End Class
