<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSort
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
        Me.LabelNomPersonnage = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelCapitalSort = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanelSort = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'LabelNomPersonnage
        '
        Me.LabelNomPersonnage.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.LabelNomPersonnage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNomPersonnage.ForeColor = System.Drawing.Color.White
        Me.LabelNomPersonnage.Location = New System.Drawing.Point(1, 0)
        Me.LabelNomPersonnage.Name = "LabelNomPersonnage"
        Me.LabelNomPersonnage.Size = New System.Drawing.Size(554, 27)
        Me.LabelNomPersonnage.TabIndex = 341
        Me.LabelNomPersonnage.Text = "Tes sorts"
        Me.LabelNomPersonnage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(554, 27)
        Me.Label1.TabIndex = 342
        Me.Label1.Text = "Capital sorts"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCapitalSort
        '
        Me.LabelCapitalSort.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.LabelCapitalSort.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCapitalSort.ForeColor = System.Drawing.Color.White
        Me.LabelCapitalSort.Location = New System.Drawing.Point(415, 30)
        Me.LabelCapitalSort.Name = "LabelCapitalSort"
        Me.LabelCapitalSort.Size = New System.Drawing.Size(133, 27)
        Me.LabelCapitalSort.TabIndex = 343
        Me.LabelCapitalSort.Text = "0"
        Me.LabelCapitalSort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(554, 27)
        Me.Label3.TabIndex = 344
        Me.Label3.Text = "Type de sort"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.White
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Tous types", "Classe", "Elementaire", "Invocation", "Maitrise", "Special"})
        Me.ComboBox1.Location = New System.Drawing.Point(389, 63)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(159, 21)
        Me.ComboBox1.TabIndex = 345
        '
        'FlowLayoutPanelSort
        '
        Me.FlowLayoutPanelSort.AutoScroll = True
        Me.FlowLayoutPanelSort.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.FlowLayoutPanelSort.Location = New System.Drawing.Point(2, 90)
        Me.FlowLayoutPanelSort.Name = "FlowLayoutPanelSort"
        Me.FlowLayoutPanelSort.Size = New System.Drawing.Size(546, 395)
        Me.FlowLayoutPanelSort.TabIndex = 346
        '
        'FrmSort
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 487)
        Me.Controls.Add(Me.FlowLayoutPanelSort)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelCapitalSort)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelNomPersonnage)
        Me.Name = "FrmSort"
        Me.Text = "FrmSort"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelNomPersonnage As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelCapitalSort As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents FlowLayoutPanelSort As FlowLayoutPanel
End Class
