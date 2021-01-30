<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUser
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUser))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.RthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MITMToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnecterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DéconnecterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SocketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConnecterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DéconnecterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelStatut = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LabelEtat = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ProgressBarPods = New System.Windows.Forms.ProgressBar()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ProgressBarExperience = New System.Windows.Forms.ProgressBar()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ProgressBarVitaliter = New System.Windows.Forms.ProgressBar()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ButtonPlugInIA = New System.Windows.Forms.Button()
        Me.ButtonCaracteristique = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.ButtonFamilier = New System.Windows.Forms.Button()
        Me.ButtonIA = New System.Windows.Forms.Button()
        Me.Button_Option = New System.Windows.Forms.Button()
        Me.TimerRegeneration = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimerStatut = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonDll = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RthToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1218, 24)
        Me.MenuStrip1.TabIndex = 402
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RthToolStripMenuItem
        '
        Me.RthToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MITMToolStripMenuItem1, Me.SocketToolStripMenuItem})
        Me.RthToolStripMenuItem.ForeColor = System.Drawing.Color.Lime
        Me.RthToolStripMenuItem.Name = "RthToolStripMenuItem"
        Me.RthToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.RthToolStripMenuItem.Text = "Connexion"
        '
        'MITMToolStripMenuItem1
        '
        Me.MITMToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.MITMToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnecterToolStripMenuItem, Me.DéconnecterToolStripMenuItem})
        Me.MITMToolStripMenuItem1.ForeColor = System.Drawing.Color.Red
        Me.MITMToolStripMenuItem1.Name = "MITMToolStripMenuItem1"
        Me.MITMToolStripMenuItem1.Size = New System.Drawing.Size(109, 22)
        Me.MITMToolStripMenuItem1.Text = "MITM"
        '
        'ConnecterToolStripMenuItem
        '
        Me.ConnecterToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ConnecterToolStripMenuItem.ForeColor = System.Drawing.Color.Lime
        Me.ConnecterToolStripMenuItem.Name = "ConnecterToolStripMenuItem"
        Me.ConnecterToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ConnecterToolStripMenuItem.Text = "Connecter"
        '
        'DéconnecterToolStripMenuItem
        '
        Me.DéconnecterToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DéconnecterToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.DéconnecterToolStripMenuItem.Name = "DéconnecterToolStripMenuItem"
        Me.DéconnecterToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.DéconnecterToolStripMenuItem.Text = "Déconnecter"
        '
        'SocketToolStripMenuItem
        '
        Me.SocketToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.SocketToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnecterToolStripMenuItem1, Me.DéconnecterToolStripMenuItem1})
        Me.SocketToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan
        Me.SocketToolStripMenuItem.Name = "SocketToolStripMenuItem"
        Me.SocketToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.SocketToolStripMenuItem.Text = "Socket"
        '
        'ConnecterToolStripMenuItem1
        '
        Me.ConnecterToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ConnecterToolStripMenuItem1.ForeColor = System.Drawing.Color.Lime
        Me.ConnecterToolStripMenuItem1.Name = "ConnecterToolStripMenuItem1"
        Me.ConnecterToolStripMenuItem1.Size = New System.Drawing.Size(141, 22)
        Me.ConnecterToolStripMenuItem1.Text = "Connecter"
        '
        'DéconnecterToolStripMenuItem1
        '
        Me.DéconnecterToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.DéconnecterToolStripMenuItem1.ForeColor = System.Drawing.Color.Red
        Me.DéconnecterToolStripMenuItem1.Name = "DéconnecterToolStripMenuItem1"
        Me.DéconnecterToolStripMenuItem1.Size = New System.Drawing.Size(141, 22)
        Me.DéconnecterToolStripMenuItem1.Text = "Déconnecter"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Console.png")
        Me.ImageList1.Images.SetKeyName(1, "Tchat.png")
        '
        'LabelStatut
        '
        Me.LabelStatut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelStatut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatut.ForeColor = System.Drawing.Color.Red
        Me.LabelStatut.Location = New System.Drawing.Point(3, 84)
        Me.LabelStatut.Name = "LabelStatut"
        Me.LabelStatut.Size = New System.Drawing.Size(154, 42)
        Me.LabelStatut.TabIndex = 415
        Me.LabelStatut.Text = "Inconnu"
        Me.LabelStatut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(154, 16)
        Me.Label7.TabIndex = 414
        Me.Label7.Text = "Statut"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelEtat
        '
        Me.LabelEtat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelEtat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEtat.ForeColor = System.Drawing.Color.Red
        Me.LabelEtat.Location = New System.Drawing.Point(3, 42)
        Me.LabelEtat.Name = "LabelEtat"
        Me.LabelEtat.Size = New System.Drawing.Size(154, 18)
        Me.LabelEtat.TabIndex = 413
        Me.LabelEtat.Text = "Déconnecté"
        Me.LabelEtat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 16)
        Me.Label5.TabIndex = 412
        Me.Label5.Text = "Etat"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(3, 197)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(45, 16)
        Me.Label20.TabIndex = 426
        Me.Label20.Text = "Pods"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBarPods
        '
        Me.ProgressBarPods.Location = New System.Drawing.Point(49, 194)
        Me.ProgressBarPods.Name = "ProgressBarPods"
        Me.ProgressBarPods.Size = New System.Drawing.Size(108, 23)
        Me.ProgressBarPods.TabIndex = 425
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(3, 168)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 16)
        Me.Label19.TabIndex = 424
        Me.Label19.Text = "Exp"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBarExperience
        '
        Me.ProgressBarExperience.Location = New System.Drawing.Point(49, 165)
        Me.ProgressBarExperience.Name = "ProgressBarExperience"
        Me.ProgressBarExperience.Size = New System.Drawing.Size(108, 23)
        Me.ProgressBarExperience.TabIndex = 423
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(3, 139)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 16)
        Me.Label18.TabIndex = 422
        Me.Label18.Text = "Vie"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBarVitaliter
        '
        Me.ProgressBarVitaliter.Location = New System.Drawing.Point(49, 136)
        Me.ProgressBarVitaliter.Name = "ProgressBarVitaliter"
        Me.ProgressBarVitaliter.Size = New System.Drawing.Size(108, 23)
        Me.ProgressBarVitaliter.TabIndex = 421
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonPlugInIA)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonCaracteristique)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button5)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button6)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button7)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button8)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button9)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button10)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonFamilier)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonIA)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button_Option)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(163, 27)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(299, 190)
        Me.FlowLayoutPanel1.TabIndex = 427
        '
        'ButtonPlugInIA
        '
        Me.ButtonPlugInIA.BackgroundImage = Global.LinaBot.My.Resources.Resources.Tchat
        Me.ButtonPlugInIA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonPlugInIA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonPlugInIA.ForeColor = System.Drawing.Color.White
        Me.ButtonPlugInIA.Location = New System.Drawing.Point(3, 3)
        Me.ButtonPlugInIA.Name = "ButtonPlugInIA"
        Me.ButtonPlugInIA.Size = New System.Drawing.Size(50, 50)
        Me.ButtonPlugInIA.TabIndex = 399
        Me.ButtonPlugInIA.UseVisualStyleBackColor = True
        '
        'ButtonCaracteristique
        '
        Me.ButtonCaracteristique.BackgroundImage = Global.LinaBot.My.Resources.Resources.Caracteristique
        Me.ButtonCaracteristique.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCaracteristique.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonCaracteristique.ForeColor = System.Drawing.Color.White
        Me.ButtonCaracteristique.Location = New System.Drawing.Point(59, 3)
        Me.ButtonCaracteristique.Name = "ButtonCaracteristique"
        Me.ButtonCaracteristique.Size = New System.Drawing.Size(50, 50)
        Me.ButtonCaracteristique.TabIndex = 400
        Me.ButtonCaracteristique.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.LinaBot.My.Resources.Resources.Sort
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(115, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(50, 50)
        Me.Button2.TabIndex = 401
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.LinaBot.My.Resources.Resources.Inventaire
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(171, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 50)
        Me.Button3.TabIndex = 402
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.LinaBot.My.Resources.Resources.Quete
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(227, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(50, 50)
        Me.Button4.TabIndex = 403
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.BackgroundImage = Global.LinaBot.My.Resources.Resources.Map
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(3, 59)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(50, 50)
        Me.Button5.TabIndex = 404
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackgroundImage = Global.LinaBot.My.Resources.Resources.Ami
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(59, 59)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(50, 50)
        Me.Button6.TabIndex = 405
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.BackgroundImage = Global.LinaBot.My.Resources.Resources.Guilde
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(115, 59)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(50, 50)
        Me.Button7.TabIndex = 406
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackgroundImage = Global.LinaBot.My.Resources.Resources.Dragodinde
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(171, 59)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(50, 50)
        Me.Button8.TabIndex = 407
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackgroundImage = Global.LinaBot.My.Resources.Resources.Conquete
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.Location = New System.Drawing.Point(227, 59)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(50, 50)
        Me.Button9.TabIndex = 408
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.BackgroundImage = Global.LinaBot.My.Resources.Resources.Console
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button10.ForeColor = System.Drawing.Color.White
        Me.Button10.Location = New System.Drawing.Point(3, 115)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(50, 50)
        Me.Button10.TabIndex = 409
        Me.Button10.UseVisualStyleBackColor = True
        '
        'ButtonFamilier
        '
        Me.ButtonFamilier.BackgroundImage = Global.LinaBot.My.Resources.Resources._8000
        Me.ButtonFamilier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonFamilier.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonFamilier.ForeColor = System.Drawing.Color.White
        Me.ButtonFamilier.Location = New System.Drawing.Point(59, 115)
        Me.ButtonFamilier.Name = "ButtonFamilier"
        Me.ButtonFamilier.Size = New System.Drawing.Size(50, 50)
        Me.ButtonFamilier.TabIndex = 410
        Me.ButtonFamilier.UseVisualStyleBackColor = True
        '
        'ButtonIA
        '
        Me.ButtonIA.BackgroundImage = Global.LinaBot.My.Resources.Resources.Ampoule_Off
        Me.ButtonIA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonIA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonIA.ForeColor = System.Drawing.Color.White
        Me.ButtonIA.Location = New System.Drawing.Point(115, 115)
        Me.ButtonIA.Name = "ButtonIA"
        Me.ButtonIA.Size = New System.Drawing.Size(50, 50)
        Me.ButtonIA.TabIndex = 411
        Me.ButtonIA.UseVisualStyleBackColor = True
        '
        'Button_Option
        '
        Me.Button_Option.BackgroundImage = Global.LinaBot.My.Resources.Resources._Option
        Me.Button_Option.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_Option.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_Option.ForeColor = System.Drawing.Color.White
        Me.Button_Option.Location = New System.Drawing.Point(171, 115)
        Me.Button_Option.Name = "Button_Option"
        Me.Button_Option.Size = New System.Drawing.Size(50, 50)
        Me.Button_Option.TabIndex = 412
        Me.Button_Option.UseVisualStyleBackColor = True
        '
        'TimerRegeneration
        '
        Me.TimerRegeneration.Enabled = True
        Me.TimerRegeneration.Interval = 2000
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1
        Me.ToolTip1.AutoPopDelay = 60000
        Me.ToolTip1.InitialDelay = 1
        Me.ToolTip1.ReshowDelay = 0
        '
        'TimerStatut
        '
        Me.TimerStatut.Enabled = True
        Me.TimerStatut.Interval = 1000
        '
        'ButtonDll
        '
        Me.ButtonDll.BackgroundImage = Global.LinaBot.My.Resources.Resources.DllBlue
        Me.ButtonDll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonDll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonDll.ForeColor = System.Drawing.Color.White
        Me.ButtonDll.Location = New System.Drawing.Point(386, 223)
        Me.ButtonDll.Name = "ButtonDll"
        Me.ButtonDll.Size = New System.Drawing.Size(76, 75)
        Me.ButtonDll.TabIndex = 413
        Me.ButtonDll.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(468, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(747, 520)
        Me.TabControl1.TabIndex = 428
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RichTextBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(739, 494)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(727, 482)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RichTextBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(739, 494)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RichTextBox2.Location = New System.Drawing.Point(6, 6)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(727, 482)
        Me.RichTextBox2.TabIndex = 1
        Me.RichTextBox2.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(113, 380)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 429
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(194, 382)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(101, 20)
        Me.TextBox1.TabIndex = 430
        '
        'FrmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.ProgressBarPods)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.ProgressBarExperience)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ProgressBarVitaliter)
        Me.Controls.Add(Me.LabelStatut)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LabelEtat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ButtonDll)
        Me.Name = "FrmUser"
        Me.Size = New System.Drawing.Size(1218, 550)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents RthToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MITMToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ConnecterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DéconnecterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SocketToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConnecterToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DéconnecterToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents LabelStatut As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LabelEtat As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents ProgressBarPods As ProgressBar
    Friend WithEvents Label19 As Label
    Friend WithEvents ProgressBarExperience As ProgressBar
    Friend WithEvents Label18 As Label
    Friend WithEvents ProgressBarVitaliter As ProgressBar
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ButtonPlugInIA As Button
    Friend WithEvents ButtonCaracteristique As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents TimerRegeneration As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TimerStatut As Timer
    Friend WithEvents ButtonFamilier As Button
    Friend WithEvents ButtonIA As Button
    Friend WithEvents Button_Option As Button
    Friend WithEvents ButtonDll As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
End Class
