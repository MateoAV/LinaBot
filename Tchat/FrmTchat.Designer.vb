<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTchat
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTchat))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_Tchat = New System.Windows.Forms.TabPage()
        Me.RichTextBoxTchat = New System.Windows.Forms.RichTextBox()
        Me.TabPage_Socket = New System.Windows.Forms.TabPage()
        Me.RichTextBoxSocket = New System.Windows.Forms.RichTextBox()
        Me.TabPage_Option = New System.Windows.Forms.TabPage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CheckBox_Information = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Communs = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Groupe = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Recrutement = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Alignement = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Guilde = New System.Windows.Forms.CheckBox()
        Me.CheckBox_Commerce = New System.Windows.Forms.CheckBox()
        Me.TextBox_Tchat = New System.Windows.Forms.TextBox()
        Me.Button_Tchat = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_Tchat.SuspendLayout()
        Me.TabPage_Socket.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_Tchat)
        Me.TabControl1.Controls.Add(Me.TabPage_Socket)
        Me.TabControl1.Controls.Add(Me.TabPage_Option)
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(12, 11)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(702, 477)
        Me.TabControl1.TabIndex = 429
        '
        'TabPage_Tchat
        '
        Me.TabPage_Tchat.Controls.Add(Me.RichTextBoxTchat)
        Me.TabPage_Tchat.ImageIndex = 1
        Me.TabPage_Tchat.Location = New System.Drawing.Point(4, 47)
        Me.TabPage_Tchat.Name = "TabPage_Tchat"
        Me.TabPage_Tchat.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Tchat.Size = New System.Drawing.Size(694, 426)
        Me.TabPage_Tchat.TabIndex = 0
        Me.TabPage_Tchat.Text = "Tchat"
        Me.TabPage_Tchat.UseVisualStyleBackColor = True
        '
        'RichTextBoxTchat
        '
        Me.RichTextBoxTchat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxTchat.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RichTextBoxTchat.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBoxTchat.Name = "RichTextBoxTchat"
        Me.RichTextBoxTchat.Size = New System.Drawing.Size(682, 414)
        Me.RichTextBoxTchat.TabIndex = 0
        Me.RichTextBoxTchat.Text = ""
        '
        'TabPage_Socket
        '
        Me.TabPage_Socket.Controls.Add(Me.RichTextBoxSocket)
        Me.TabPage_Socket.ImageIndex = 0
        Me.TabPage_Socket.Location = New System.Drawing.Point(4, 47)
        Me.TabPage_Socket.Name = "TabPage_Socket"
        Me.TabPage_Socket.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Socket.Size = New System.Drawing.Size(694, 426)
        Me.TabPage_Socket.TabIndex = 1
        Me.TabPage_Socket.Text = "socket"
        Me.TabPage_Socket.UseVisualStyleBackColor = True
        '
        'RichTextBoxSocket
        '
        Me.RichTextBoxSocket.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxSocket.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RichTextBoxSocket.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBoxSocket.Name = "RichTextBoxSocket"
        Me.RichTextBoxSocket.Size = New System.Drawing.Size(682, 414)
        Me.RichTextBoxSocket.TabIndex = 1
        Me.RichTextBoxSocket.Text = ""
        '
        'TabPage_Option
        '
        Me.TabPage_Option.ImageIndex = 2
        Me.TabPage_Option.Location = New System.Drawing.Point(4, 47)
        Me.TabPage_Option.Name = "TabPage_Option"
        Me.TabPage_Option.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Option.Size = New System.Drawing.Size(694, 426)
        Me.TabPage_Option.TabIndex = 2
        Me.TabPage_Option.Text = "Option"
        Me.TabPage_Option.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Console.png")
        Me.ImageList1.Images.SetKeyName(1, "Tchat.png")
        Me.ImageList1.Images.SetKeyName(2, "Option.png")
        '
        'CheckBox_Information
        '
        Me.CheckBox_Information.AutoSize = True
        Me.CheckBox_Information.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Information.ForeColor = System.Drawing.Color.Lime
        Me.CheckBox_Information.Location = New System.Drawing.Point(12, 494)
        Me.CheckBox_Information.Name = "CheckBox_Information"
        Me.CheckBox_Information.Size = New System.Drawing.Size(103, 20)
        Me.CheckBox_Information.TabIndex = 430
        Me.CheckBox_Information.Text = "Information"
        Me.CheckBox_Information.UseVisualStyleBackColor = True
        '
        'CheckBox_Communs
        '
        Me.CheckBox_Communs.AutoSize = True
        Me.CheckBox_Communs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Communs.ForeColor = System.Drawing.Color.White
        Me.CheckBox_Communs.Location = New System.Drawing.Point(121, 494)
        Me.CheckBox_Communs.Name = "CheckBox_Communs"
        Me.CheckBox_Communs.Size = New System.Drawing.Size(94, 20)
        Me.CheckBox_Communs.TabIndex = 431
        Me.CheckBox_Communs.Text = "Communs"
        Me.CheckBox_Communs.UseVisualStyleBackColor = True
        '
        'CheckBox_Groupe
        '
        Me.CheckBox_Groupe.AutoSize = True
        Me.CheckBox_Groupe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Groupe.ForeColor = System.Drawing.Color.Cyan
        Me.CheckBox_Groupe.Location = New System.Drawing.Point(221, 494)
        Me.CheckBox_Groupe.Name = "CheckBox_Groupe"
        Me.CheckBox_Groupe.Size = New System.Drawing.Size(78, 20)
        Me.CheckBox_Groupe.TabIndex = 432
        Me.CheckBox_Groupe.Text = "Groupe"
        Me.CheckBox_Groupe.UseVisualStyleBackColor = True
        '
        'CheckBox_Recrutement
        '
        Me.CheckBox_Recrutement.AutoSize = True
        Me.CheckBox_Recrutement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Recrutement.ForeColor = System.Drawing.Color.Gray
        Me.CheckBox_Recrutement.Location = New System.Drawing.Point(493, 494)
        Me.CheckBox_Recrutement.Name = "CheckBox_Recrutement"
        Me.CheckBox_Recrutement.Size = New System.Drawing.Size(114, 20)
        Me.CheckBox_Recrutement.TabIndex = 435
        Me.CheckBox_Recrutement.Text = "Recrutement"
        Me.CheckBox_Recrutement.UseVisualStyleBackColor = True
        '
        'CheckBox_Alignement
        '
        Me.CheckBox_Alignement.AutoSize = True
        Me.CheckBox_Alignement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Alignement.ForeColor = System.Drawing.Color.Orange
        Me.CheckBox_Alignement.Location = New System.Drawing.Point(383, 494)
        Me.CheckBox_Alignement.Name = "CheckBox_Alignement"
        Me.CheckBox_Alignement.Size = New System.Drawing.Size(104, 20)
        Me.CheckBox_Alignement.TabIndex = 434
        Me.CheckBox_Alignement.Text = "Alignement"
        Me.CheckBox_Alignement.UseVisualStyleBackColor = True
        '
        'CheckBox_Guilde
        '
        Me.CheckBox_Guilde.AutoSize = True
        Me.CheckBox_Guilde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Guilde.ForeColor = System.Drawing.Color.DarkViolet
        Me.CheckBox_Guilde.Location = New System.Drawing.Point(305, 494)
        Me.CheckBox_Guilde.Name = "CheckBox_Guilde"
        Me.CheckBox_Guilde.Size = New System.Drawing.Size(72, 20)
        Me.CheckBox_Guilde.TabIndex = 433
        Me.CheckBox_Guilde.Text = "Guilde"
        Me.CheckBox_Guilde.UseVisualStyleBackColor = True
        '
        'CheckBox_Commerce
        '
        Me.CheckBox_Commerce.AutoSize = True
        Me.CheckBox_Commerce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Commerce.ForeColor = System.Drawing.Color.Sienna
        Me.CheckBox_Commerce.Location = New System.Drawing.Point(613, 494)
        Me.CheckBox_Commerce.Name = "CheckBox_Commerce"
        Me.CheckBox_Commerce.Size = New System.Drawing.Size(101, 20)
        Me.CheckBox_Commerce.TabIndex = 436
        Me.CheckBox_Commerce.Text = "Commerce"
        Me.CheckBox_Commerce.UseVisualStyleBackColor = True
        '
        'TextBox_Tchat
        '
        Me.TextBox_Tchat.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TextBox_Tchat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Tchat.ForeColor = System.Drawing.Color.White
        Me.TextBox_Tchat.Location = New System.Drawing.Point(12, 520)
        Me.TextBox_Tchat.Name = "TextBox_Tchat"
        Me.TextBox_Tchat.Size = New System.Drawing.Size(676, 22)
        Me.TextBox_Tchat.TabIndex = 437
        '
        'Button_Tchat
        '
        Me.Button_Tchat.BackgroundImage = Global.LinaBot.My.Resources.Resources.icons8_email_send_48
        Me.Button_Tchat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_Tchat.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_Tchat.ForeColor = System.Drawing.Color.White
        Me.Button_Tchat.Location = New System.Drawing.Point(694, 520)
        Me.Button_Tchat.Name = "Button_Tchat"
        Me.Button_Tchat.Size = New System.Drawing.Size(20, 20)
        Me.Button_Tchat.TabIndex = 400
        Me.Button_Tchat.UseVisualStyleBackColor = True
        '
        'FrmTchat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(726, 549)
        Me.Controls.Add(Me.Button_Tchat)
        Me.Controls.Add(Me.TextBox_Tchat)
        Me.Controls.Add(Me.CheckBox_Commerce)
        Me.Controls.Add(Me.CheckBox_Recrutement)
        Me.Controls.Add(Me.CheckBox_Groupe)
        Me.Controls.Add(Me.CheckBox_Alignement)
        Me.Controls.Add(Me.CheckBox_Communs)
        Me.Controls.Add(Me.CheckBox_Guilde)
        Me.Controls.Add(Me.CheckBox_Information)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmTchat"
        Me.Text = "Tchat"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_Tchat.ResumeLayout(False)
        Me.TabPage_Socket.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage_Tchat As TabPage
    Friend WithEvents RichTextBoxTchat As RichTextBox
    Friend WithEvents TabPage_Socket As TabPage
    Friend WithEvents RichTextBoxSocket As RichTextBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents TabPage_Option As TabPage
    Friend WithEvents CheckBox_Information As CheckBox
    Friend WithEvents CheckBox_Communs As CheckBox
    Friend WithEvents CheckBox_Groupe As CheckBox
    Friend WithEvents CheckBox_Recrutement As CheckBox
    Friend WithEvents CheckBox_Alignement As CheckBox
    Friend WithEvents CheckBox_Guilde As CheckBox
    Friend WithEvents CheckBox_Commerce As CheckBox
    Friend WithEvents TextBox_Tchat As TextBox
    Friend WithEvents Button_Tchat As Button
End Class
