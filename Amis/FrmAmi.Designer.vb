<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAmi
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_Ami = New System.Windows.Forms.TabPage()
        Me.ButtonAjouterAmi = New System.Windows.Forms.Button()
        Me.TextBoxAmi = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridViewAmi = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage_Ennemis = New System.Windows.Forms.TabPage()
        Me.ButtonAjouterEnnemi = New System.Windows.Forms.Button()
        Me.TextBoxEnnemi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridViewEnnemi = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage_Ignorés = New System.Windows.Forms.TabPage()
        Me.DataGridViewIgnorer = New System.Windows.Forms.DataGridView()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DataGridView_Ami_NonConnecter = New System.Windows.Forms.DataGridView()
        Me.DataGridViewButtonColumn3 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView_Ennemi_NonConnecter = New System.Windows.Forms.DataGridView()
        Me.DataGridViewButtonColumn4 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStripAmi = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.IgnorerPourLaSessionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessagePrivéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InviterDansMonGroupeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_Ami.SuspendLayout()
        CType(Me.DataGridViewAmi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_Ennemis.SuspendLayout()
        CType(Me.DataGridViewEnnemi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_Ignorés.SuspendLayout()
        CType(Me.DataGridViewIgnorer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_Ami_NonConnecter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_Ennemi_NonConnecter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripAmi.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage_Ami)
        Me.TabControl1.Controls.Add(Me.TabPage_Ennemis)
        Me.TabControl1.Controls.Add(Me.TabPage_Ignorés)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 494)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage_Ami
        '
        Me.TabPage_Ami.BackColor = System.Drawing.Color.Black
        Me.TabPage_Ami.Controls.Add(Me.DataGridView_Ami_NonConnecter)
        Me.TabPage_Ami.Controls.Add(Me.ButtonAjouterAmi)
        Me.TabPage_Ami.Controls.Add(Me.TextBoxAmi)
        Me.TabPage_Ami.Controls.Add(Me.Label2)
        Me.TabPage_Ami.Controls.Add(Me.DataGridViewAmi)
        Me.TabPage_Ami.Controls.Add(Me.Label1)
        Me.TabPage_Ami.Location = New System.Drawing.Point(4, 29)
        Me.TabPage_Ami.Name = "TabPage_Ami"
        Me.TabPage_Ami.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Ami.Size = New System.Drawing.Size(768, 461)
        Me.TabPage_Ami.TabIndex = 0
        Me.TabPage_Ami.Text = "Amis"
        '
        'ButtonAjouterAmi
        '
        Me.ButtonAjouterAmi.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ButtonAjouterAmi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAjouterAmi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAjouterAmi.ForeColor = System.Drawing.Color.White
        Me.ButtonAjouterAmi.Location = New System.Drawing.Point(456, 429)
        Me.ButtonAjouterAmi.Name = "ButtonAjouterAmi"
        Me.ButtonAjouterAmi.Size = New System.Drawing.Size(93, 26)
        Me.ButtonAjouterAmi.TabIndex = 364
        Me.ButtonAjouterAmi.Text = "Ajouter"
        Me.ButtonAjouterAmi.UseVisualStyleBackColor = False
        '
        'TextBoxAmi
        '
        Me.TextBoxAmi.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TextBoxAmi.ForeColor = System.Drawing.Color.White
        Me.TextBoxAmi.Location = New System.Drawing.Point(130, 429)
        Me.TextBoxAmi.Name = "TextBoxAmi"
        Me.TextBoxAmi.Size = New System.Drawing.Size(308, 26)
        Me.TextBoxAmi.TabIndex = 363
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 429)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(543, 26)
        Me.Label2.TabIndex = 362
        Me.Label2.Text = "Ajouter un ami"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewAmi
        '
        Me.DataGridViewAmi.AllowUserToAddRows = False
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAmi.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewAmi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewAmi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewAmi.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAmi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewAmi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewAmi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column5, Me.Column2, Me.Column3, Me.Column6, Me.Column4})
        Me.DataGridViewAmi.GridColor = System.Drawing.Color.Black
        Me.DataGridViewAmi.Location = New System.Drawing.Point(6, 6)
        Me.DataGridViewAmi.MultiSelect = False
        Me.DataGridViewAmi.Name = "DataGridViewAmi"
        Me.DataGridViewAmi.RowHeadersWidth = 4
        Me.DataGridViewAmi.Size = New System.Drawing.Size(543, 417)
        Me.DataGridViewAmi.TabIndex = 361
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Supprimé"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 83
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "ClasseSexe"
        Me.Column5.Name = "Column5"
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column5.Width = 118
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Comptes (Nom)"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Niveau"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 82
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Alignement"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 114
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "?"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 43
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(555, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(207, 26)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Non Connectés"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage_Ennemis
        '
        Me.TabPage_Ennemis.BackColor = System.Drawing.Color.Black
        Me.TabPage_Ennemis.Controls.Add(Me.DataGridView_Ennemi_NonConnecter)
        Me.TabPage_Ennemis.Controls.Add(Me.ButtonAjouterEnnemi)
        Me.TabPage_Ennemis.Controls.Add(Me.TextBoxEnnemi)
        Me.TabPage_Ennemis.Controls.Add(Me.Label3)
        Me.TabPage_Ennemis.Controls.Add(Me.DataGridViewEnnemi)
        Me.TabPage_Ennemis.Controls.Add(Me.Label4)
        Me.TabPage_Ennemis.ForeColor = System.Drawing.Color.White
        Me.TabPage_Ennemis.Location = New System.Drawing.Point(4, 29)
        Me.TabPage_Ennemis.Name = "TabPage_Ennemis"
        Me.TabPage_Ennemis.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Ennemis.Size = New System.Drawing.Size(768, 461)
        Me.TabPage_Ennemis.TabIndex = 1
        Me.TabPage_Ennemis.Text = "Ennemis"
        '
        'ButtonAjouterEnnemi
        '
        Me.ButtonAjouterEnnemi.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ButtonAjouterEnnemi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAjouterEnnemi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAjouterEnnemi.ForeColor = System.Drawing.Color.White
        Me.ButtonAjouterEnnemi.Location = New System.Drawing.Point(456, 429)
        Me.ButtonAjouterEnnemi.Name = "ButtonAjouterEnnemi"
        Me.ButtonAjouterEnnemi.Size = New System.Drawing.Size(93, 26)
        Me.ButtonAjouterEnnemi.TabIndex = 370
        Me.ButtonAjouterEnnemi.Text = "Ajouter"
        Me.ButtonAjouterEnnemi.UseVisualStyleBackColor = False
        '
        'TextBoxEnnemi
        '
        Me.TextBoxEnnemi.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TextBoxEnnemi.ForeColor = System.Drawing.Color.White
        Me.TextBoxEnnemi.Location = New System.Drawing.Point(156, 429)
        Me.TextBoxEnnemi.Name = "TextBoxEnnemi"
        Me.TextBoxEnnemi.Size = New System.Drawing.Size(282, 26)
        Me.TextBoxEnnemi.TabIndex = 369
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 429)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(543, 26)
        Me.Label3.TabIndex = 368
        Me.Label3.Text = "Ajouter un ennemi"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewEnnemi
        '
        Me.DataGridViewEnnemi.AllowUserToAddRows = False
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewEnnemi.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewEnnemi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewEnnemi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewEnnemi.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewEnnemi.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewEnnemi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEnnemi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn1, Me.Column7, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.DataGridViewEnnemi.GridColor = System.Drawing.Color.Black
        Me.DataGridViewEnnemi.Location = New System.Drawing.Point(6, 6)
        Me.DataGridViewEnnemi.MultiSelect = False
        Me.DataGridViewEnnemi.Name = "DataGridViewEnnemi"
        Me.DataGridViewEnnemi.RowHeadersWidth = 4
        Me.DataGridViewEnnemi.Size = New System.Drawing.Size(543, 417)
        Me.DataGridViewEnnemi.TabIndex = 367
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(555, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(207, 26)
        Me.Label4.TabIndex = 365
        Me.Label4.Text = "Non Connectés"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage_Ignorés
        '
        Me.TabPage_Ignorés.BackColor = System.Drawing.Color.Black
        Me.TabPage_Ignorés.Controls.Add(Me.DataGridViewIgnorer)
        Me.TabPage_Ignorés.Location = New System.Drawing.Point(4, 29)
        Me.TabPage_Ignorés.Name = "TabPage_Ignorés"
        Me.TabPage_Ignorés.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Ignorés.Size = New System.Drawing.Size(768, 461)
        Me.TabPage_Ignorés.TabIndex = 2
        Me.TabPage_Ignorés.Text = "Ignorés"
        '
        'DataGridViewIgnorer
        '
        Me.DataGridViewIgnorer.AllowUserToAddRows = False
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewIgnorer.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewIgnorer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewIgnorer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewIgnorer.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewIgnorer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewIgnorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewIgnorer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn2, Me.Column8, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.DataGridViewIgnorer.GridColor = System.Drawing.Color.Black
        Me.DataGridViewIgnorer.Location = New System.Drawing.Point(6, 6)
        Me.DataGridViewIgnorer.MultiSelect = False
        Me.DataGridViewIgnorer.Name = "DataGridViewIgnorer"
        Me.DataGridViewIgnorer.RowHeadersWidth = 4
        Me.DataGridViewIgnorer.Size = New System.Drawing.Size(756, 449)
        Me.DataGridViewIgnorer.TabIndex = 368
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(12, 517)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(325, 20)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "M'avertir lors de la connexion de l'un de mes amis."
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DataGridView_Ami_NonConnecter
        '
        Me.DataGridView_Ami_NonConnecter.AllowUserToAddRows = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Ami_NonConnecter.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView_Ami_NonConnecter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Ami_NonConnecter.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView_Ami_NonConnecter.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Ami_NonConnecter.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView_Ami_NonConnecter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Ami_NonConnecter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn3, Me.DataGridViewTextBoxColumn9})
        Me.DataGridView_Ami_NonConnecter.GridColor = System.Drawing.Color.Black
        Me.DataGridView_Ami_NonConnecter.Location = New System.Drawing.Point(555, 35)
        Me.DataGridView_Ami_NonConnecter.MultiSelect = False
        Me.DataGridView_Ami_NonConnecter.Name = "DataGridView_Ami_NonConnecter"
        Me.DataGridView_Ami_NonConnecter.RowHeadersWidth = 4
        Me.DataGridView_Ami_NonConnecter.Size = New System.Drawing.Size(207, 417)
        Me.DataGridView_Ami_NonConnecter.TabIndex = 365
        '
        'DataGridViewButtonColumn3
        '
        Me.DataGridViewButtonColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewButtonColumn3.HeaderText = "Supprimé"
        Me.DataGridViewButtonColumn3.Name = "DataGridViewButtonColumn3"
        Me.DataGridViewButtonColumn3.Width = 83
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.HeaderText = "Comptes"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridView_Ennemi_NonConnecter
        '
        Me.DataGridView_Ennemi_NonConnecter.AllowUserToAddRows = False
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Ennemi_NonConnecter.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView_Ennemi_NonConnecter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView_Ennemi_NonConnecter.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView_Ennemi_NonConnecter.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(48, Byte), Integer))
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView_Ennemi_NonConnecter.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView_Ennemi_NonConnecter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Ennemi_NonConnecter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewButtonColumn4, Me.DataGridViewTextBoxColumn10})
        Me.DataGridView_Ennemi_NonConnecter.GridColor = System.Drawing.Color.Black
        Me.DataGridView_Ennemi_NonConnecter.Location = New System.Drawing.Point(555, 35)
        Me.DataGridView_Ennemi_NonConnecter.MultiSelect = False
        Me.DataGridView_Ennemi_NonConnecter.Name = "DataGridView_Ennemi_NonConnecter"
        Me.DataGridView_Ennemi_NonConnecter.RowHeadersWidth = 4
        Me.DataGridView_Ennemi_NonConnecter.Size = New System.Drawing.Size(207, 417)
        Me.DataGridView_Ennemi_NonConnecter.TabIndex = 371
        '
        'DataGridViewButtonColumn4
        '
        Me.DataGridViewButtonColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewButtonColumn4.HeaderText = "Supprimé"
        Me.DataGridViewButtonColumn4.Name = "DataGridViewButtonColumn4"
        Me.DataGridViewButtonColumn4.Width = 83
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.HeaderText = "Comptes"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewButtonColumn2
        '
        Me.DataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewButtonColumn2.HeaderText = "Supprimé"
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.Width = 83
        '
        'Column8
        '
        Me.Column8.HeaderText = "ClasseSexe"
        Me.Column8.Name = "Column8"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Niveau"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 82
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn7.HeaderText = "Alignement"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 114
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.HeaderText = "?"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 43
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewButtonColumn1.HeaderText = "Supprimé"
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.Width = 83
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "ClasseSexe"
        Me.Column7.Name = "Column7"
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column7.Width = 118
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Comptes (Nom)"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Niveau"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 82
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "Alignement"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 114
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "?"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 43
        '
        'ContextMenuStripAmi
        '
        Me.ContextMenuStripAmi.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IgnorerPourLaSessionToolStripMenuItem, Me.InformationsToolStripMenuItem, Me.MessagePrivéToolStripMenuItem, Me.InviterDansMonGroupeToolStripMenuItem})
        Me.ContextMenuStripAmi.Name = "ContextMenuStripAmi"
        Me.ContextMenuStripAmi.Size = New System.Drawing.Size(205, 92)
        '
        'IgnorerPourLaSessionToolStripMenuItem
        '
        Me.IgnorerPourLaSessionToolStripMenuItem.Name = "IgnorerPourLaSessionToolStripMenuItem"
        Me.IgnorerPourLaSessionToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.IgnorerPourLaSessionToolStripMenuItem.Text = "Ignorer pour la session"
        '
        'InformationsToolStripMenuItem
        '
        Me.InformationsToolStripMenuItem.Name = "InformationsToolStripMenuItem"
        Me.InformationsToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.InformationsToolStripMenuItem.Text = "Informations"
        '
        'MessagePrivéToolStripMenuItem
        '
        Me.MessagePrivéToolStripMenuItem.Name = "MessagePrivéToolStripMenuItem"
        Me.MessagePrivéToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.MessagePrivéToolStripMenuItem.Text = "Message privé"
        '
        'InviterDansMonGroupeToolStripMenuItem
        '
        Me.InviterDansMonGroupeToolStripMenuItem.Name = "InviterDansMonGroupeToolStripMenuItem"
        Me.InviterDansMonGroupeToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.InviterDansMonGroupeToolStripMenuItem.Text = "Inviter dans mon groupe"
        '
        'FrmAmi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 546)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmAmi"
        Me.Text = "Amis"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_Ami.ResumeLayout(False)
        Me.TabPage_Ami.PerformLayout()
        CType(Me.DataGridViewAmi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_Ennemis.ResumeLayout(False)
        Me.TabPage_Ennemis.PerformLayout()
        CType(Me.DataGridViewEnnemi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_Ignorés.ResumeLayout(False)
        CType(Me.DataGridViewIgnorer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_Ami_NonConnecter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_Ennemi_NonConnecter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripAmi.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage_Ami As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage_Ennemis As TabPage
    Friend WithEvents TabPage_Ignorés As TabPage
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ButtonAjouterAmi As Button
    Friend WithEvents TextBoxAmi As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridViewAmi As DataGridView
    Friend WithEvents ButtonAjouterEnnemi As Button
    Friend WithEvents TextBoxEnnemi As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridViewEnnemi As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridViewIgnorer As DataGridView
    Friend WithEvents Column1 As DataGridViewButtonColumn
    Friend WithEvents Column5 As DataGridViewImageColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView_Ami_NonConnecter As DataGridView
    Friend WithEvents DataGridViewButtonColumn3 As DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView_Ennemi_NonConnecter As DataGridView
    Friend WithEvents DataGridViewButtonColumn4 As DataGridViewButtonColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn2 As DataGridViewButtonColumn
    Friend WithEvents Column8 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
    Friend WithEvents Column7 As DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStripAmi As ContextMenuStrip
    Friend WithEvents IgnorerPourLaSessionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MessagePrivéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InviterDansMonGroupeToolStripMenuItem As ToolStripMenuItem
End Class
