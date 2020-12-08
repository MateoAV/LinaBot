<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcSort
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Me.LabelNom = New System.Windows.Forms.Label()
        Me.LabelPA = New System.Windows.Forms.Label()
        Me.LabelPO = New System.Windows.Forms.Label()
        Me.LabelCout = New System.Windows.Forms.Label()
        Me.LabelNiveau = New System.Windows.Forms.Label()
        Me.ButtonSort = New System.Windows.Forms.Button()
        Me.PictureBoxSort = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBoxSort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelNom
        '
        Me.LabelNom.AutoSize = True
        Me.LabelNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNom.ForeColor = System.Drawing.Color.White
        Me.LabelNom.Location = New System.Drawing.Point(59, 3)
        Me.LabelNom.Name = "LabelNom"
        Me.LabelNom.Size = New System.Drawing.Size(45, 20)
        Me.LabelNom.TabIndex = 1
        Me.LabelNom.Text = "Nom"
        '
        'LabelPA
        '
        Me.LabelPA.AutoSize = True
        Me.LabelPA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPA.ForeColor = System.Drawing.Color.White
        Me.LabelPA.Location = New System.Drawing.Point(59, 33)
        Me.LabelPA.Name = "LabelPA"
        Me.LabelPA.Size = New System.Drawing.Size(43, 20)
        Me.LabelPA.TabIndex = 2
        Me.LabelPA.Text = "6 PA"
        '
        'LabelPO
        '
        Me.LabelPO.AutoSize = True
        Me.LabelPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPO.ForeColor = System.Drawing.Color.White
        Me.LabelPO.Location = New System.Drawing.Point(125, 33)
        Me.LabelPO.Name = "LabelPO"
        Me.LabelPO.Size = New System.Drawing.Size(67, 20)
        Me.LabelPO.TabIndex = 3
        Me.LabelPO.Text = "1-10 PO"
        '
        'LabelCout
        '
        Me.LabelCout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCout.ForeColor = System.Drawing.Color.White
        Me.LabelCout.Location = New System.Drawing.Point(279, 32)
        Me.LabelCout.Name = "LabelCout"
        Me.LabelCout.Size = New System.Drawing.Size(208, 20)
        Me.LabelCout.TabIndex = 4
        Me.LabelCout.Text = "Coût du niveau suivant : 1"
        Me.LabelCout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelNiveau
        '
        Me.LabelNiveau.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNiveau.ForeColor = System.Drawing.Color.White
        Me.LabelNiveau.Location = New System.Drawing.Point(440, 3)
        Me.LabelNiveau.Name = "LabelNiveau"
        Me.LabelNiveau.Size = New System.Drawing.Size(71, 20)
        Me.LabelNiveau.TabIndex = 402
        Me.LabelNiveau.Text = "Niveau 1"
        Me.LabelNiveau.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonSort
        '
        Me.ButtonSort.BackgroundImage = Global.LinaBot.My.Resources.Resources.plus
        Me.ButtonSort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonSort.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonSort.ForeColor = System.Drawing.Color.White
        Me.ButtonSort.Location = New System.Drawing.Point(491, 31)
        Me.ButtonSort.Name = "ButtonSort"
        Me.ButtonSort.Size = New System.Drawing.Size(20, 20)
        Me.ButtonSort.TabIndex = 401
        Me.ButtonSort.UseVisualStyleBackColor = True
        Me.ButtonSort.Visible = False
        '
        'PictureBoxSort
        '
        Me.PictureBoxSort.Location = New System.Drawing.Point(3, 3)
        Me.PictureBoxSort.Name = "PictureBoxSort"
        Me.PictureBoxSort.Size = New System.Drawing.Size(50, 50)
        Me.PictureBoxSort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxSort.TabIndex = 0
        Me.PictureBoxSort.TabStop = False
        '
        'UcSort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.LabelNiveau)
        Me.Controls.Add(Me.ButtonSort)
        Me.Controls.Add(Me.LabelCout)
        Me.Controls.Add(Me.LabelPO)
        Me.Controls.Add(Me.LabelPA)
        Me.Controls.Add(Me.LabelNom)
        Me.Controls.Add(Me.PictureBoxSort)
        Me.Name = "UcSort"
        Me.Size = New System.Drawing.Size(516, 56)
        CType(Me.PictureBoxSort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBoxSort As PictureBox
    Friend WithEvents LabelNom As Label
    Friend WithEvents LabelPA As Label
    Friend WithEvents LabelPO As Label
    Friend WithEvents LabelCout As Label
    Friend WithEvents ButtonSort As Button
    Friend WithEvents LabelNiveau As Label
End Class
