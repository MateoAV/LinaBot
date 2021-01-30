Imports System.Net.Sockets, System.Net, Org.Mentalis.Network.ProxySocket

Public Module Divers

    Private Delegate Sub dlgDivers()
    Private Delegate Function dlgFDivers()

    Public Sub Initialiser(ByVal index As Integer, ByVal frmGroupe As FrmGroupe)

        With Comptes(index)

            'Je donne l'index aussi dans le Panel_utilisateur
            .FrmUser.index = index '  .FrmUser.Index = compteur

            'Je nomme le Tab_Page par le nom du personnage.
            '  .FrmUser.GroupBoxName.Text = .Personnage.NomDuPersonnage

            'J'ajoute à la form "groupe", dans le tabcontrol, le tab_page.
            frmGroupe.FlowLayoutPanel1.Controls.Add(.FrmUser)



            'Charger les options ici.
            frmGroupe.BotIndex.Add(index)

        End With

    End Sub


    Public Sub ErreurFichier(ByVal index As Integer, ByVal nomJoueur As String, ByVal nomErreur As String, ByVal erreur As String)

        Try

            EcritureMessage(index, "[Erreur]", "Une erreur est survenue, veuillez envoyez les fichiers qui se trouve dans le dossier 'Erreur' à l'administrateur.", Color.Red)

            'Si le dossier erreur n'existe pas, alors je le créer
            If Not IO.Directory.Exists(Application.StartupPath & "\AllErreur") Then IO.Directory.CreateDirectory(Application.StartupPath & "\AllErreur")

            'J'ouvre le fichier pour y écrire se que je souhaite
            Dim swEcriture As New IO.StreamWriter(Application.StartupPath + "\AllErreur/" & nomJoueur & "_" & nomErreur & ".txt")

            swEcriture.WriteLine(erreur)

            'Puis je le ferme.
            swEcriture.Close()

        Catch ex As Exception

            MsgBox("erreur fichier, impossible de créer le fichier erreur : " & nomErreur & vbCrLf & ex.ToString)

        End Try

    End Sub

    Public Sub EcritureMessage(ByVal index As Integer, ByVal indice As String, ByVal message As String, ByVal couleur As Color)

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                    .FrmUser.Invoke(New dlgDivers(Sub() EcritureMessage(index, indice, message, couleur)))

                Else

                    .FrmUser.RichTextBox1.SelectionColor = couleur
                    .FrmUser.RichTextBox1.AppendText("[" & TimeOfDay & "] " & indice & " " & message & vbCrLf)
                    .FrmUser.RichTextBox1.ScrollToCaret()

                    .Tchat.Tchat.Add("[" & TimeOfDay & "] " & indice & " " & message, couleur)

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub
    Public Sub EcritureMessageSocket(ByVal index As Integer, ByVal indice As String, ByVal message As String, ByVal couleur As Color)

        With Comptes(index)

            Try

                If .FrmUser.InvokeRequired Then

                    .FrmUser.Invoke(New dlgDivers(Sub() EcritureMessageSocket(index, indice, message, couleur)))

                Else

                    .FrmUser.RichTextBox2.SelectionColor = couleur
                    .FrmUser.RichTextBox2.AppendText("[" & TimeOfDay & "] " & indice & " " & message & vbCrLf)
                    .FrmUser.RichTextBox2.ScrollToCaret()
                    .SockSendRecv.Add("[" & TimeOfDay & "] " & indice & " " & message, couleur)

                End If

            Catch ex As Exception

            End Try

        End With

    End Sub

    Public Function AsciiDecoder(ByVal msg As String) As String
        Dim msgFinal As String = ""
        Try

            Dim iMax As Integer = msg.Length
            Dim i As Integer = 0
            While (i < iMax)
                Dim caractC As Char = msg(i)
                Dim caractI As Integer = Asc(caractC)
                Dim nbLettreCode As Integer = 1
                If (caractI And 128) = 0 Then
                    msgFinal &= ChrW(caractI)
                Else
                    Dim temp As Integer = 64
                    Dim codecPremLettre As Integer = 63
                    While (caractI And temp)
                        temp >>= 1
                        codecPremLettre = codecPremLettre Xor temp
                        nbLettreCode += 1
                    End While
                    codecPremLettre = codecPremLettre And 255
                    Dim caractIFinal As Integer = caractI And codecPremLettre
                    nbLettreCode -= 1
                    i += 1
                    While (nbLettreCode <> 0)
                        caractC = msg(i)
                        caractI = Asc(caractC)
                        caractIFinal <<= 6
                        caractIFinal = caractIFinal Or (caractI And 63)
                        nbLettreCode -= 1
                        i += 1
                    End While
                    msgFinal &= ChrW(caractIFinal)
                End If
                i += nbLettreCode
            End While
        Catch ex As Exception

        End Try


        Return msgFinal.Replace("%27", "'").Replace("%C3%A9", "é").Replace("%2C", ",").Replace("%3F", "?").Replace("%C3%A8", "é").Replace("%29", "]").Replace("%28", "[")
    End Function 'Provient de Maxoubot.

    Public Function ProxySocketUtilisateur(ipAnkama As String, portAnkama As Integer, proxyIP As String, proxyPort As Integer, nomUtilisateur As String, motDePasse As String) As Socket

        Dim monProxy As ProxySocket = New ProxySocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

        monProxy.ProxyEndPoint = New IPEndPoint(IPAddress.Parse(proxyIP), proxyPort)

        If nomUtilisateur <> "" Then

            monProxy.ProxyUser = nomUtilisateur
            monProxy.ProxyPass = motDePasse

        End If

        monProxy.ProxyType = ProxyTypes.Socks5

        monProxy.Connect(ipAnkama, portAnkama)

        Return monProxy

    End Function

    Public Function CopyItem(ByVal index As Integer, ByVal dico As Dictionary(Of Integer, CItem)) As Dictionary(Of Integer, CItem)

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlgFDivers(Function() CopyItem(index, dico)))

            Else

                Dim newDico As New Dictionary(Of Integer, CItem)

                For Each pair As KeyValuePair(Of Integer, CItem) In dico

                    newDico.Add(pair.Key, pair.Value)

                Next

                Return newDico

            End If

        End With

    End Function
    Public Function CopyMap(ByVal index As Integer, ByVal dico As Dictionary(Of Integer, CEntite)) As Dictionary(Of Integer, CEntite)

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlgFDivers(Function() CopyMap(index, dico)))

            Else

                Dim newDico As New Dictionary(Of Integer, CEntite)

                For Each pair As KeyValuePair(Of Integer, CEntite) In dico

                    newDico.Add(pair.Key, pair.Value)

                Next

                Return newDico

            End If

        End With

    End Function

    Public Function CopyAmi(ByVal index As Integer, ByVal dico As Dictionary(Of String, CAmiInformation)) As Dictionary(Of String, CAmiInformation)

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlgFDivers(Function() CopyAmi(index, dico)))

            Else

                Dim newDico As New Dictionary(Of String, CAmiInformation)

                For Each pair As KeyValuePair(Of String, CAmiInformation) In dico

                    newDico.Add(pair.Key, pair.Value)

                Next

                Return newDico

            End If

        End With

    End Function

    Public Function CopyInteraction(ByVal index As Integer, ByVal dico As Dictionary(Of Integer, CInteraction)) As Dictionary(Of Integer, CInteraction)

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlgFDivers(Function() CopyInteraction(index, dico)))

            Else

                Dim newDico As New Dictionary(Of Integer, CInteraction)

                For Each pair As KeyValuePair(Of Integer, CInteraction) In dico

                    newDico.Add(pair.Key, pair.Value)

                Next

                Return newDico

            End If

        End With

    End Function



    ''' <summary>
    ''' Retourne l'ID ou la categorie de l'item.
    ''' </summary>
    ''' <param name="index">Indique le numéro du bot.</param>
    ''' <param name="nomID">Le nom de l'item ou son ID.</param>
    ''' <param name="choix">l'un des choix suivant : <br/>
    ''' ID = Retourne l'ID de l'item.
    ''' Categorie = Retourne la categorie de l'item.</param>
    ''' <returns>
    ''' Retourne l'ID ou la categorie selon le nom ou l'ID de l'item.
    ''' </returns>
    Public Function RetourneItemNomIdCategorie(ByVal index As Integer, ByVal nomID As String, ByVal choix As String) As String

        With Comptes(index)

            For Each pair As sItems In VarItems.Values

                If pair.Nom.ToLower = nomID.ToLower OrElse pair.ID = nomID Then

                    Select Case choix.ToLower

                        Case "id"

                            Return pair.ID

                        Case "categorie", "categori"

                            Return pair.Catégorie

                    End Select

                End If

            Next

        End With

        Return ""

    End Function

    Public Sub Pause(ByVal index As String, ByVal minimum As String, ByVal maximum As String)

        Dim rand As New Random

        Task.Delay(rand.Next(minimum, maximum)).Wait()

    End Sub

    Public Function ReturnOpenFileDialog(index As Integer) As String

        With Comptes(index)

            If .FrmUser.InvokeRequired Then

                Return .FrmUser.Invoke(New dlgFDivers(Function() ReturnOpenFileDialog(index)))

            Else

                Dim Ouverture_Fichier As New OpenFileDialog

                If Ouverture_Fichier.ShowDialog = 1 Then

                    Return Ouverture_Fichier.FileName

                End If

            End If

        End With

        Return ""

    End Function

End Module
