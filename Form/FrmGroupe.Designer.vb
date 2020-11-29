<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGroupe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGroupe))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ButtonTrajet = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Black
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 68)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(776, 370)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'ButtonTrajet
        '
        Me.ButtonTrajet.BackgroundImage = CType(resources.GetObject("ButtonTrajet.BackgroundImage"), System.Drawing.Image)
        Me.ButtonTrajet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonTrajet.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonTrajet.ForeColor = System.Drawing.Color.White
        Me.ButtonTrajet.Location = New System.Drawing.Point(12, 12)
        Me.ButtonTrajet.Name = "ButtonTrajet"
        Me.ButtonTrajet.Size = New System.Drawing.Size(50, 50)
        Me.ButtonTrajet.TabIndex = 400
        Me.ButtonTrajet.UseVisualStyleBackColor = True
        '
        'FrmGroupe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ButtonTrajet)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "FrmGroupe"
        Me.Text = "FrmGroupe"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents ButtonTrajet As Button
End Class
