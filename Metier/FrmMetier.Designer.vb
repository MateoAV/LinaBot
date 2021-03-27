<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMetier
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMetier))
        Me.ProgressBarExperience = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBoxMetier = New System.Windows.Forms.PictureBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPageCharacteristics = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ListViewSkills = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPageRecipes = New System.Windows.Forms.TabPage()
        Me.TabPageOptions = New System.Windows.Forms.TabPage()
        Me.PictureBoxPublicMode = New System.Windows.Forms.PictureBox()
        Me.ButtonActiver = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.NumericUpDownRessources = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CheckBoxFournitPasRessource = New System.Windows.Forms.CheckBox()
        Me.CheckBoxGratuitEchec = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPayant = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelNiveau = New System.Windows.Forms.Label()
        Me.LabelNom = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.PictureBoxMetier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabPageCharacteristics.SuspendLayout()
        Me.TabPageOptions.SuspendLayout()
        CType(Me.PictureBoxPublicMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownRessources, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBarExperience
        '
        Me.ProgressBarExperience.Location = New System.Drawing.Point(284, 50)
        Me.ProgressBarExperience.Name = "ProgressBarExperience"
        Me.ProgressBarExperience.Size = New System.Drawing.Size(279, 23)
        Me.ProgressBarExperience.TabIndex = 60
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(170, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 24)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Expérience"
        '
        'PictureBoxMetier
        '
        Me.PictureBoxMetier.Image = CType(resources.GetObject("PictureBoxMetier.Image"), System.Drawing.Image)
        Me.PictureBoxMetier.Location = New System.Drawing.Point(94, 13)
        Me.PictureBoxMetier.Name = "PictureBoxMetier"
        Me.PictureBoxMetier.Size = New System.Drawing.Size(70, 70)
        Me.PictureBoxMetier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxMetier.TabIndex = 58
        Me.PictureBoxMetier.TabStop = False
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPageCharacteristics)
        Me.TabControl2.Controls.Add(Me.TabPageRecipes)
        Me.TabControl2.Controls.Add(Me.TabPageOptions)
        Me.TabControl2.Location = New System.Drawing.Point(94, 89)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(469, 446)
        Me.TabControl2.TabIndex = 57
        '
        'TabPageCharacteristics
        '
        Me.TabPageCharacteristics.AutoScroll = True
        Me.TabPageCharacteristics.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TabPageCharacteristics.Controls.Add(Me.GroupBox1)
        Me.TabPageCharacteristics.Controls.Add(Me.Label7)
        Me.TabPageCharacteristics.Controls.Add(Me.ListViewSkills)
        Me.TabPageCharacteristics.Controls.Add(Me.Label2)
        Me.TabPageCharacteristics.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCharacteristics.Name = "TabPageCharacteristics"
        Me.TabPageCharacteristics.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageCharacteristics.Size = New System.Drawing.Size(461, 420)
        Me.TabPageCharacteristics.TabIndex = 0
        Me.TabPageCharacteristics.Text = "Caractéristiques"
        '
        'GroupBox1
        '
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(6, 187)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 227)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Outil"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(-2, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(463, 24)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = " Outil                                                                           " &
    "       "
        '
        'ListViewSkills
        '
        Me.ListViewSkills.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ListViewSkills.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListViewSkills.ForeColor = System.Drawing.Color.White
        Me.ListViewSkills.GridLines = True
        Me.ListViewSkills.HideSelection = False
        Me.ListViewSkills.Location = New System.Drawing.Point(6, 27)
        Me.ListViewSkills.Name = "ListViewSkills"
        Me.ListViewSkills.Size = New System.Drawing.Size(449, 130)
        Me.ListViewSkills.TabIndex = 6
        Me.ListViewSkills.UseCompatibleStateImageBehavior = False
        Me.ListViewSkills.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Compétence"
        Me.ColumnHeader1.Width = 142
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Action"
        Me.ColumnHeader2.Width = 144
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Récolte/Case"
        Me.ColumnHeader3.Width = 159
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(-2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(463, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = " Compétences                                                                  "
        '
        'TabPageRecipes
        '
        Me.TabPageRecipes.AutoScroll = True
        Me.TabPageRecipes.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TabPageRecipes.Location = New System.Drawing.Point(4, 22)
        Me.TabPageRecipes.Name = "TabPageRecipes"
        Me.TabPageRecipes.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageRecipes.Size = New System.Drawing.Size(461, 420)
        Me.TabPageRecipes.TabIndex = 1
        Me.TabPageRecipes.Text = "Recette"
        '
        'TabPageOptions
        '
        Me.TabPageOptions.AutoScroll = True
        Me.TabPageOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TabPageOptions.Controls.Add(Me.PictureBoxPublicMode)
        Me.TabPageOptions.Controls.Add(Me.ButtonActiver)
        Me.TabPageOptions.Controls.Add(Me.Label6)
        Me.TabPageOptions.Controls.Add(Me.Label5)
        Me.TabPageOptions.Controls.Add(Me.ButtonSave)
        Me.TabPageOptions.Controls.Add(Me.NumericUpDownRessources)
        Me.TabPageOptions.Controls.Add(Me.Label4)
        Me.TabPageOptions.Controls.Add(Me.CheckBoxFournitPasRessource)
        Me.TabPageOptions.Controls.Add(Me.CheckBoxGratuitEchec)
        Me.TabPageOptions.Controls.Add(Me.CheckBoxPayant)
        Me.TabPageOptions.Controls.Add(Me.Label3)
        Me.TabPageOptions.Location = New System.Drawing.Point(4, 22)
        Me.TabPageOptions.Name = "TabPageOptions"
        Me.TabPageOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageOptions.Size = New System.Drawing.Size(461, 420)
        Me.TabPageOptions.TabIndex = 2
        Me.TabPageOptions.Text = "Options"
        '
        'PictureBoxPublicMode
        '
        Me.PictureBoxPublicMode.BackColor = System.Drawing.Color.DimGray
        Me.PictureBoxPublicMode.Image = CType(resources.GetObject("PictureBoxPublicMode.Image"), System.Drawing.Image)
        Me.PictureBoxPublicMode.Location = New System.Drawing.Point(431, 197)
        Me.PictureBoxPublicMode.Name = "PictureBoxPublicMode"
        Me.PictureBoxPublicMode.Size = New System.Drawing.Size(24, 24)
        Me.PictureBoxPublicMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxPublicMode.TabIndex = 55
        Me.PictureBoxPublicMode.TabStop = False
        '
        'ButtonActiver
        '
        Me.ButtonActiver.Location = New System.Drawing.Point(133, 384)
        Me.ButtonActiver.Name = "ButtonActiver"
        Me.ButtonActiver.Size = New System.Drawing.Size(188, 23)
        Me.ButtonActiver.TabIndex = 15
        Me.ButtonActiver.Text = "Activer"
        Me.ButtonActiver.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(13, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(431, 140)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = resources.GetString("Label6.Text")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(-3, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(464, 24)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = " Mode public (Inactif)                                                        "
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(133, 162)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(188, 23)
        Me.ButtonSave.TabIndex = 12
        Me.ButtonSave.Text = "Sauvegarder"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'NumericUpDownRessources
        '
        Me.NumericUpDownRessources.Location = New System.Drawing.Point(197, 121)
        Me.NumericUpDownRessources.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.NumericUpDownRessources.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericUpDownRessources.Name = "NumericUpDownRessources"
        Me.NumericUpDownRessources.Size = New System.Drawing.Size(30, 20)
        Me.NumericUpDownRessources.TabIndex = 11
        Me.NumericUpDownRessources.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(275, 16)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Nombre minimum d'ingrédients               cases"
        '
        'CheckBoxFournitPasRessource
        '
        Me.CheckBoxFournitPasRessource.AutoSize = True
        Me.CheckBoxFournitPasRessource.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxFournitPasRessource.ForeColor = System.Drawing.Color.Red
        Me.CheckBoxFournitPasRessource.Location = New System.Drawing.Point(6, 89)
        Me.CheckBoxFournitPasRessource.Name = "CheckBoxFournitPasRessource"
        Me.CheckBoxFournitPasRessource.Size = New System.Drawing.Size(193, 20)
        Me.CheckBoxFournitPasRessource.TabIndex = 9
        Me.CheckBoxFournitPasRessource.Text = "Ne fournit aucune ressource"
        Me.CheckBoxFournitPasRessource.UseVisualStyleBackColor = True
        '
        'CheckBoxGratuitEchec
        '
        Me.CheckBoxGratuitEchec.AutoSize = True
        Me.CheckBoxGratuitEchec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxGratuitEchec.ForeColor = System.Drawing.Color.Red
        Me.CheckBoxGratuitEchec.Location = New System.Drawing.Point(22, 66)
        Me.CheckBoxGratuitEchec.Name = "CheckBoxGratuitEchec"
        Me.CheckBoxGratuitEchec.Size = New System.Drawing.Size(126, 20)
        Me.CheckBoxGratuitEchec.TabIndex = 8
        Me.CheckBoxGratuitEchec.Text = "Gratuit sur échec"
        Me.CheckBoxGratuitEchec.UseVisualStyleBackColor = True
        '
        'CheckBoxPayant
        '
        Me.CheckBoxPayant.AutoSize = True
        Me.CheckBoxPayant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxPayant.ForeColor = System.Drawing.Color.Red
        Me.CheckBoxPayant.Location = New System.Drawing.Point(6, 43)
        Me.CheckBoxPayant.Name = "CheckBoxPayant"
        Me.CheckBoxPayant.Size = New System.Drawing.Size(69, 20)
        Me.CheckBoxPayant.TabIndex = 7
        Me.CheckBoxPayant.Text = "Payant"
        Me.CheckBoxPayant.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(-4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(465, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = " Options de référencement                                              "
        '
        'LabelNiveau
        '
        Me.LabelNiveau.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LabelNiveau.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNiveau.ForeColor = System.Drawing.Color.White
        Me.LabelNiveau.Location = New System.Drawing.Point(448, 13)
        Me.LabelNiveau.Name = "LabelNiveau"
        Me.LabelNiveau.Size = New System.Drawing.Size(115, 24)
        Me.LabelNiveau.TabIndex = 56
        Me.LabelNiveau.Text = "Niveau : 100"
        Me.LabelNiveau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelNom
        '
        Me.LabelNom.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LabelNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNom.ForeColor = System.Drawing.Color.White
        Me.LabelNom.Location = New System.Drawing.Point(170, 13)
        Me.LabelNom.Name = "LabelNom"
        Me.LabelNom.Size = New System.Drawing.Size(393, 24)
        Me.LabelNom.TabIndex = 55
        Me.LabelNom.Text = "Nom Metier"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 10)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(76, 525)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'FrmMetier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(573, 544)
        Me.Controls.Add(Me.LabelNiveau)
        Me.Controls.Add(Me.ProgressBarExperience)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBoxMetier)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.LabelNom)
        Me.Name = "FrmMetier"
        Me.Text = "Metier"
        CType(Me.PictureBoxMetier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPageCharacteristics.ResumeLayout(False)
        Me.TabPageCharacteristics.PerformLayout()
        Me.TabPageOptions.ResumeLayout(False)
        Me.TabPageOptions.PerformLayout()
        CType(Me.PictureBoxPublicMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownRessources, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBarExperience As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBoxMetier As PictureBox
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPageCharacteristics As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ListViewSkills As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPageRecipes As TabPage
    Friend WithEvents TabPageOptions As TabPage
    Friend WithEvents PictureBoxPublicMode As PictureBox
    Friend WithEvents ButtonActiver As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonSave As Button
    Friend WithEvents NumericUpDownRessources As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBoxFournitPasRessource As CheckBox
    Friend WithEvents CheckBoxGratuitEchec As CheckBox
    Friend WithEvents CheckBoxPayant As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelNiveau As Label
    Friend WithEvents LabelNom As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
