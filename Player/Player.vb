Imports System.Net.Sockets
Imports System.Net
Imports System.Threading
Imports System.Text

Public Class Player

#Region "Socket"

    Public Sub CreateSocketAuthentification(ByVal IP As String, ByVal Port As String)

        Socket_Authentification = If(Proxy, New All_CallBack(IP, Port, Proxy, ProxyIp, ProxyPort, ProxyNdc, ProxyMdp), New All_CallBack(IP, Port))
        AddHandler Socket_Authentification.Connexion, AddressOf e_Connexion
        AddHandler Socket_Authentification.Deconnexion, AddressOf e_Deconnexion
        AddHandler Socket_Authentification.Envoie, AddressOf e_Envoi
        AddHandler Socket_Authentification.Reception, AddressOf E_Reception

    End Sub

    Public Sub CreateSocketServeurJeu(ByVal IP As String, ByVal Port As String)

        Socket = If(Proxy, New All_CallBack(IP, Port, Proxy, ProxyIp, ProxyPort, ProxyNdc, ProxyMdp), New All_CallBack(IP, Port)) 'New All_CallBack(IP, Port)
        AddHandler Socket.Deconnexion, AddressOf e_Deconnexion
        AddHandler Socket.Envoie, AddressOf e_Envoi
        AddHandler Socket.Reception, AddressOf E_Reception

    End Sub

#End Region

#Region "RaiseEvent"

    Public Sub e_Connexion(ByVal Sender As Object, ByVal e As Socket_EventArgs)

        Try

            With FrmUser

                If .InvokeRequired Then

                    .Invoke(New All_CallBack.D_All_CallBack(AddressOf e_Connexion), Sender, e)

                Else

                    With FrmUser

                        .LabelEtat.Text = "En Connexion"
                        .LabelEtat.ForeColor = Color.Orange

                        .LabelStatut.Text = "Connexion en cours..."
                        .LabelStatut.ForeColor = Color.Orange

                    End With

                    Client.BeginReceive(BufferClient, 0, BufferClient.Length, SocketFlags.None, New AsyncCallback(AddressOf ReceiveCallBackClient), Client)

                End If

            End With

        Catch ex As Exception


        End Try

    End Sub

    Public Sub e_Deconnexion(ByVal Sender As Object, ByVal e As Socket_EventArgs)

        Try

            With FrmUser

                ' Si on est déconnnecté
                If .InvokeRequired Then

                    .Invoke(New All_CallBack.D_All_CallBack(AddressOf e_Deconnexion), Sender, e)

                Else

                    With FrmUser

                        .LabelEtat.Text = "Déconnecté"
                        .LabelEtat.ForeColor = Color.Red

                        .LabelStatut.Text = "Inconnu"
                        .LabelStatut.ForeColor = Color.Red

                    End With

                End If

            End With

        Catch ex As Exception



        End Try

    End Sub

    Public Sub e_Envoi(ByVal Sender As Object, ByVal e As Socket_EventArgs)

        ' Si on envoie quelque chose
        Try

            With FrmUser

                If .InvokeRequired Then

                    .Invoke(New All_CallBack.D_All_CallBack(AddressOf e_Envoi), Sender, e)

                Else  'Loger

                    With FrmUser.RichTextBox2
                        .SelectionColor = Color.Red
                        .AppendText("[" & TimeOfDay & "] " & "Send : " & e.Message.Replace(Chr(10), "").Replace(Chr(0), "") & vbCrLf)
                        .ScrollToCaret()
                    End With

                End If

            End With

        Catch ex As Exception

            ErreurFichier(Index, Comptes(Index).Personnage.NomDuPersonnage, "e_Envoi", ex.Message)

        End Try

    End Sub

    Public Sub E_Reception(ByVal Message As Object, ByVal e As Socket_EventArgs)

        If e.Message <> Nothing Then

            Try

                If FrmUser.InvokeRequired Then

                    FrmUser.Invoke(New All_CallBack.D_All_CallBack(AddressOf E_Reception), Message, e)

                Else

                    'Loger
                    With FrmUser.RichTextBox2
                        .SelectionColor = Color.Cyan
                        .AppendText("[" & TimeOfDay & "] " & "Recv : " & e.Message & vbCrLf)
                        .ScrollToCaret()
                    End With

                    If e.Message <> "" Then

                        'Selection des infos
                        Select Case e.Message(0)

                                Case "A"

                                    Select Case e.Message(1)

                                        Case "B" ' AB

                                            Select Case e.Message(2)

                                                Case "E" ' ABE

                                                    BloqueCaractéristique.Set()
                                                    EcritureMessage(Index, "[Dofus]", "Impossible de up la caractéristique.", Color.Red)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "AB", e.Message)

                                            End Select

                                        Case "c" ' Ac

                                            Select Case e.Message(2)

                                                Case "0" ' Ac0

                                                    ' Utilisation inconnu

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Ac", e.Message)

                                            End Select

                                        Case "d" ' Ad

                                            GiPseudo(Index, e.Message)

                                        Case "f" ' Af

                                            GiFileAttenteAuthentification(Index, e.Message)

                                        Case "H" ' AH

                                            GiReçoisServeur(Index, e.Message)

                                        Case "L" ' AL

                                            Select Case e.Message(2)

                                                Case "K" ' ALK

                                                    GiReceptionPersonnage(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "AL", e.Message)

                                            End Select

                                        Case "l" ' Al

                                            Select Case e.Message(2)

                                                Case "E" 'AlE

                                                    'Je déconnecte le bot.
                                                    If MITM Then

                                                        Client.Close()

                                                    End If

                                                    Socket_Authentification.Connexion_Game(False)

                                                    Select Case e.Message(3)

                                                        Case "a" 'AlEa

                                                            EcritureMessage(Index, "[Dofus]", "Déjà en connexion.", Color.Red)

                                                        Case "b" 'AlEb

                                                            EcritureMessage(Index, "[Dofus]", "Votre compte à été banni.", Color.Red)

                                                        Case "c" 'AlEc

                                                            EcritureMessage(Index, "[Dofus]", "Vous êtes déjà connécté au serveur du jeu.", Color.Red)

                                                        Case "d" 'AlEd

                                                            EcritureMessage(Index, "[Dofus]", "Vous avez déconnecté une personne utilisant le compte.", Color.Red)

                                                        Case "f" 'AlEf

                                                            EcritureMessage(Index, "[Dofus]", "Mauvais mot de passe.", Color.Red)

                                                        Case "k" 'AlEk

                                                            'AlEk Jour | Heure | Minute

                                                            Dim Separation() As String = Split(Mid(e.Message, 5), "|")

                                                            'Le like me permet de regarde si le résultat correspond à chaque séparation.
                                                            If "1" = Separation(0) Like (Separation(1) Like Separation(2)) Then

                                                                EcritureMessage(Index, "[Dofus]", "Compte invalide, si vous avez 1j 1h 1m, il s'agît d'une IP bannie définitivement" & vbCrLf & "il vous suffit de changer d'IP pour régler le problème.", Color.Red)

                                                            Else

                                                                EcritureMessage(Index, "[Dofus]", "Ton compte est invalide pendant " & Separation(0) & " Jour(s) " & Separation(1) & " Heure(s) " & Separation(2) & " Minute(s)'.", Color.Red)

                                                            End If

                                                        Case "n" 'AlEn

                                                            EcritureMessage(Index, "[Dofus]", "La connexion ne sait pas faite corréctement.", Color.Red)

                                                        Case "p" 'AlEp

                                                            EcritureMessage(Index, "[Dofus]", "Votre compte n'est pas valide.", Color.Red)

                                                        Case "s" 'AlEs

                                                            EcritureMessage(Index, "[Dofus]", "Le Pseudo est déjà utilisé, veuillez en choisir un autre.", Color.Red)

                                                        Case "v" 'AlEv1.30.1

                                                            EcritureMessage(Index, "[Dofus]", "La version de DOFUS installée est invalide pour ce serveur. Pour accéder au jeu, la version '" & Mid(e.Message, 5) & "' est nécessaire.", Color.Red)

                                                            GiVersion(Index, e.Message)

                                                        Case "w" 'AlEw

                                                            EcritureMessage(Index, "[Dofus]", "Le serveur est complet. (Vous n'étes donc plus abonnée)", Color.Red)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Unknow", e.Message)

                                                    End Select

                                                Case "K" ' AlK

                                                    Select Case e.Message(3)

                                                        Case "0" ' AlK0

                                                            If MITM = False Then

                                                                Send("Ax")

                                                            End If

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "AlK", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Al", e.Message)

                                            End Select

                                        Case "Q" ' AQ

                                            GiQuestionSecréte(Index, e.Message)

                                        Case "q" ' Aq

                                            GiFileAttenteJeu(Index, e.Message)

                                        Case "R" ' AR

                                     'AR 6bk 
                                    'AR 6bk (ou autre) = les droits du personnage, genre échanger, défi, agresser etc.
                                    'Utile pour connaître les droits en fantôme/transformation etc.
                                    '(NON FINI)
                                   ' Statut_Information_Peronnage_Autorisation(iIndex, Base36ToDec(Mid(e.Message, 3)))

                                        Case "S" ' AS

                                            Select Case e.Message(2)

                                                Case "K" ' ASK

                                                    If MITM = False Then

                                                        Send("GC1")

                                                    End If

                                                    Connecté = True
                                                    EnConnexion = False

                                                    GiInventaire(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "AS", e.Message)

                                            End Select

                                        Case "s" ' As

                                            GiCaractéristique(Index, e.Message)

                                        Case "T" ' AT

                                            Select Case e.Message(2)

                                                Case "E" ' ATE

                                                    EcritureMessage(Index, "(Dofus)", "Connexion interrompue avec le serveur." & vbCrLf &
                                                                                  "Votre connexion est trop lente ou instable.", Color.Red)

                                                    If MITM Then

                                                        Client.Close()

                                                    End If

                                                    Socket_Authentification.Connexion_Game(False)

                                                Case "K" 'ATK

                                                    Select Case e.Message(3)

                                                        Case "0" 'ATK0

                                                            If MITM = False Then

                                                                Send("Ak0")
                                                                Send("AV")

                                                            End If

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "ATK", e.Message)

                                                    End Select

                                            End Select

                                        Case "V"

                                            Select Case e.Message(2)

                                                Case "0" 'AV0

                                                    If MITM = False Then

                                                        Send("Agfr")
                                                        'Socket.Envoyer("AiCode") = ? 
                                                        Send("AL")
                                                        Send("Af")

                                                    End If

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "AV", e.Message)

                                            End Select


                                        Case "X" ' AX

                                            Select Case e.Message(2)

                                                Case "E" ' AXE  

                                                    Select Case e.Message(3)

                                                        Case "d"

                                                            EcritureMessage(Index, "[Dofus]", "Serveur : En sauvegarde.", Color.Red)

                                                        Case "f" ' AXEf

                                                            EcritureMessage(Index, "[Dofus]",
                                                    "Serveur : COMPLET" & vbCrLf &
                                                    "Nombre maximum de joueurs atteint." & vbCrLf & vbCrLf &
                                                    "Pour bénéficier d'un accès prioritaire aux serveurs, nous vous invitons à vous abonner.
                                                     Vous pouvez également tenter de vous connecter sur un autre serveur. Vous pouvez également 
                                                     télécharger et vous connecter sur les serveurs Dofus 2.0, qui proposent un plus grand nombre
                                                     de place pour accueillir les joueurs !", Color.Red)

                                                            If MITM Then

                                                                Client.Close()

                                                            End If

                                                            Socket_Authentification.Connexion_Game(False)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "AXE", e.Message)

                                                    End Select

                                                Case "K" ' AXK

                                                    GiServeurIpPortTicket(Index, e.Message)

                                                    Exit Sub

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "AX", e.Message)

                                            End Select

                                        Case "x" ' Ax

                                            Select Case e.Message(2)

                                                Case "K" ' AxK

                                                    GiSelectionServeur(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Ax", e.Message)

                                            End Select

                                        Case "Y" ' AY

                                            Select Case e.Message(2)

                                                Case "K" ' AYK

                                                    GiServeurIpPortTicket(Index, e.Message)

                                                    Exit Sub

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "AY", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "A", e.Message)

                                    End Select

                                Case "a"

                                    Select Case e.Message(1)

                                        Case "l" ' al

                                ' al|270;0|49;1|etc....
                                ' Inconnu

                                        Case "m"

                                            'am478|2|1

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "a", e.Message)

                                    End Select

                                Case "B"

                                    Select Case e.Message(1)

                                        Case "D" ' BD

                                    ' BD650|8|6
                                    ' Donne l'année + le moi + le jour.

                                        Case "N" ' BN

                                    'Info bien reçu

                                        Case "p" ' Bp

                                    ' ?

                                        Case "T" ' BT

                                    'BT1599467490555
                                    ' ?

                                        Case "W" ' BW

                                            Select Case e.Message(2)

                                                Case "K" ' BWK

                                                    GiAmiEnnemiInformation(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "BW", e.Message)

                                            End Select

                                        Case "X" ' BX

                                            Select Case e.Message(2)

                                                Case ";" ' BX;

                                                    Select Case e.Message(3)

                                                        Case "1" ' BX;1

                                                            Select Case e.Message(4)

                                                                Case ";" ' BX;1;

                                                                    If MITM = False Then

                                                                        Send("BX" & (Personnage.ID + 14))

                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "BX;1", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "BX;", e.Message)

                                                    End Select

                                                Case "|" ' BX|

                                                    Select Case e.Message(3)

                                                        Case "+" ' BX|+

                                                            'BX|+337;6;0;30177576;Tacaci;9;90^100;0;1,0,0,30177744;790000;fff8f9;600000;b4,2412~16~8,1965,1f40,;1;;;Spanish Please;8,8i,1m,9zldr;0;;
                                                            If MITM = False Then

                                                                Send("BX" & Personnage.ID)

                                                            End If

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "B", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "BX", e.Message)

                                            End Select

                                        Case "Z" ' BZ

                                            Select Case e.Message(2)

                                                Case ";" ' BZ;

                                                    Select Case e.Message(2)

                                                        Case "1" ' BZ;1

                                                            Select Case e.Message(2)

                                                                Case ";" ' BZ;1;

                                                                    If MITM = False Then

                                                                        Send("BZ" & (Personnage.ID + 305))
                                                                        'ou Send("BZ" & Personnage.ID)
                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "BZ;1", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "BZ;", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "BZ", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "B", e.Message)

                                    End Select

                                Case "b"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "b", e.Message)

                                Case "C"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "C", e.Message)

                                Case "c"

                                    Select Case e.Message(1)

                                        Case "C" ' cC

                                            Select Case e.Message(2)

                                                Case "+" ' cC+

                                                    GiCanalDofus(Index, e.Message)

                                                Case "-" ' cC-

                                                    GiCanalDofus(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "cC", e.Message)

                                            End Select

                                        Case "M" ' cM

                                            Select Case e.Message(2)

                                                Case "K" ' cMK

                                                    GiDofusTchat(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "cM", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "c", e.Message)

                                    End Select

                                Case "D"

                                    Select Case e.Message(1)

                                        Case "C" ' DC

                                            Select Case e.Message(2)

                                                Case "K" ' DCK

                                                    GiPnjDialogue(Index, e.Message)

                                                Case "E" ' DCE

                                                    EnDialogue = True
                                                    BloqueDialogue.Set()
                                                    EcritureMessage(Index, "[Dofus]", "Vous êtes déjà en dialogue.", Color.Red)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "DC", e.Message)

                                            End Select

                                        Case "Q" ' DQ

                                            GiPnjQuestionRéponse(Index, e.Message)

                                        Case "V" ' DV

                                            EnDialogue = False
                                            fPnjRéponse.Clear()
                                            fDialogueRéponse = 0
                                            BloqueDialogue.Set()

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "D", e.Message)

                                    End Select

                                Case "d"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "d", e.Message)

                                Case "E"

                                    Select Case e.Message(1)

                                        Case "b" ' Eb

                                            Select Case e.Message(2)

                                                Case ";" ' Eb;

                                                    Select Case e.Message(3)

                                                        Case ";" ' Eb;1

                                                            Select Case e.Message(4)

                                                                Case ";" ' Eb;1;

                                                                    If MITM = False Then

                                                                        Send("Eb" & (Personnage.ID + 3958))
                                                                        'OU  Send("Eb" & (Personnage.ID + 14))
                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Eb;1", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Eb;", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Eb", e.Message)

                                            End Select

                                        Case "C" ' EC

                                        Select Case e.Message(2)

                                            Case "K" ' ECK

                                                Select Case e.Message(3)

                                                    Case "0" ' ECK0

                                                        EnHDV = True

                                                    Case "1" ' ECK1

                                                        If e.Message.Length > 4 Then

                                                            Select Case e.Message(4)

                                                                Case "0" ' ECK10

                                                                    EnHDV = True
                                                                    EcritureMessage(Index, "[Dofus]", "Vous êtes en vente avec le PNJ.", Color.Green)
                                                                    GiHotelDeVenteAcheterVendre(Index, e.Message)

                                                                Case "1" ' ECK11

                                                                    EnHDV = True
                                                                    EcritureMessage(Index, "[Dofus]", "Vous êtes en achat avec le PNJ.", Color.Green)
                                                                    GiHotelDeVenteAcheterVendre(Index, e.Message)

                                                                Case "5" ' ECK15

                                                                    EnBanque = True
                                                                    EcritureMessage(Index, "[Dofus]", "Vous êtes dans l'inventaire de la monture.", Color.Green)

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "ECK1", e.Message)

                                                            End Select

                                                        Else

                                                            EnEchange = True
                                                            BloqueEchange.Set()

                                                        End If

                                                    Case "5" ' ECK5

                                                        EnBanque = True

                                                    Case "8" ' ECK8|-88

                                                        EnBanque = True 'Percepteur

                                                    Case Else

                                                        ErreurFichier(Index, Personnage.NomDuPersonnage, "ECK", e.Message)

                                                End Select

                                            Case Else

                                                ErreurFichier(Index, Personnage.NomDuPersonnage, "EC", e.Message)

                                        End Select

                                    Case "H" ' EH

                                            Select Case e.Message(2)

                                                Case "L" ' EHL

                                                    GiHotelDeVenteItemID(Index, e.Message)

                                                Case "l" ' EHl

                                                    GiHotelDeVenteItemChoisi(Index, e.Message)

                                                Case "P" ' EHP

                                                    GiHotelDeVentePrixMoyen(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "EH", e.Message)

                                            End Select

                                        Case "K" ' EK

                                            Select Case e.Message(2)

                                                Case "0" ' EK0

                                                    GiEchangeValideInvalide(Index, e.Message)

                                                Case "1" ' EK1

                                                    GiEchangeValideInvalide(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "EK", e.Message)

                                            End Select

                                        Case "L" ' EL

                                            If e.Message <> "EL" Then

                                            Select Case e.Message(2)

                                                Case "O" ' ELO

                                                    FrmUser.DataGridView_Banque.Rows.Clear()
                                                    GiItemAjoute(Index, e.Message.Replace("EL", "").Replace("O", ""), FrmUser.DataGridView_Banque)

                                                Case Else

                                                    If EnHDV Then

                                                        GiHotelDeVenteItemEnVente(Index, e.Message)

                                                    Else

                                                        ErreurFichier(Index, Personnage.NomDuPersonnage, "EL", e.Message)

                                                    End If

                                            End Select

                                        Else

                                                HdvInfo.ListeItem.Clear()

                                            End If

                                        Case "M" ' EM

                                            Select Case e.Message(2)

                                                Case "K" ' EMK

                                                    Select Case e.Message(3)

                                                        Case "G" ' EMKG

                                                            EcritureMessage(Index, "[Dofus]", "Vous avez déposé " & Mid(e.Message, 5) & " kamas.", Color.Green)

                                                            If EnEchange Then

                                                            GiEchangeKamasMoi(Index, e.Message)

                                                        End If

                                                    Case "O" ' EMKO

                                                            Select Case e.Message(4)

                                                                Case "+" ' EMKO+

                                                                If EnEchange Then

                                                                    GiEchangeAjouteItemMoi(Index, e.Message)

                                                                End If

                                                            Case "-" ' EMKO-

                                                                If EnEchange Then

                                                                    GiEchangeSupprimeItemMoi(Index, e.Message)

                                                                End If

                                                            Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "EMKO", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "EMK", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "EM", e.Message)

                                            End Select

                                        Case "m" ' Em

                                            Select Case e.Message(2)

                                                Case "K" ' EmK

                                                    Select Case e.Message(3)

                                                        Case "G" ' EmKG

                                                            EcritureMessage(Index, "[Dofus]", "Il a déposé " & Mid(e.Message, 5) & " kamas.", Color.Green)

                                                            If EnEchange Then

                                                            GiEchangeKamasLui(Index, e.Message)

                                                        End If

                                                        Case "O" ' EmKO

                                                            Select Case e.Message(4)

                                                                Case "+" ' EmKO+

                                                                If EnEchange Then

                                                                    GiEchangeAjouteItemLui(Index, e.Message)

                                                                End If

                                                            Case "-" ' EmKO-

                                                                If EnEchange Then

                                                                    GiEchangeSupprimeItemLui(Index, e.Message)

                                                                End If

                                                            Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "EmKO", e.Message)

                                                            End Select

                                                        Case "+" ' EmK+

                                                            If EnHDV Then

                                                                GiHotelDeVenteItemMisEnVente(Index, e.Message)

                                                            End If

                                                        Case "-" ' EmK-

                                                            If EnHDV Then

                                                                GiHotelDeVenteRetireItemMisEnVente(Index, e.Message)

                                                            End If

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "EmK", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Em", e.Message)

                                            End Select

                                        Case "R" ' ER

                                            Select Case e.Message(2)

                                                Case "K" ' ERK

                                                    GiEchangeRecu(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "ER", e.Message)

                                            End Select

                                        Case "s" ' Es

                                            Select Case e.Message(2)

                                                Case "K" ' EsK

                                                    Select Case e.Message(3)

                                                        Case "O" ' EsKO

                                                            Select Case e.Message(4)

                                                                Case "+" ' EsKO+

                                                                    If EnBanque Then

                                                                    GiBanqueAjouteItem(Index, e.Message, FrmUser.DataGridView_Banque)

                                                                End If

                                                                Case "-" ' EsKO-

                                                                    If EnBanque Then

                                                                    GiBanqueSupprimeItem(Index, e.Message, FrmUser.DataGridView_Banque)

                                                                End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "EsKO", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "EsK", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Es", e.Message)

                                            End Select

                                        Case "V" ' EV

                                            If e.Message = "EV" Then

                                                If EnEchange Then

                                                    EcritureMessage(Index, "[Dofus]", "Echange annulé", Color.Red)

                                                End If

                                                EnBanque = False
                                                EnEchange = False
                                                EnInvitationEchange = False
                                                EnHDV = False
                                                HdvInfo.ListeItem.Clear()
                                                BloqueInteraction.Set()
                                                BloqueEchange.Set()
                                                BloqueHDV.Set()

                                            Else

                                                If e.Message = "EVa" Then

                                                    EcritureMessage(Index, "[Dofus]", "Echange effectué", Color.Red)

                                                    EnEchange = False
                                                    BloqueEchange.Set()

                                                Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "EV", e.Message)

                                                End If

                                            End If

                                        Case "v" ' Ev

                                            Select Case e.Message(2)

                                                Case "G" ' EvG

                                                    Select Case e.Message(3)

                                                        Case "1" ' EvG1

                                                            Select Case e.Message(4)

                                                                Case "|" ' EvG1|

                                                                    If MITM = False Then

                                                                        Send("Ev" & (Personnage.ID + 2))

                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "EvG1", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "EvG", e.Message)

                                                    End Select

                                                Case "1" ' Ev1

                                                    Select Case e.Message(3)

                                                        Case ";" ' Ev1;

                                                            Select Case e.Message(4)

                                                                Case "5" ' Ev1;5

                                                                    Select Case e.Message(5)

                                                                        Case "0" ' Ev1;50

                                                                            Select Case e.Message(6)

                                                                                Case "1" ' Ev1;501

                                                                                    Select Case e.Message(7)

                                                                                        Case ";" ' Ev1;501;

                                                                                            If MITM = False Then

                                                                                                'Ev1;501;1234567;384,10800
                                                                                                Send("Ev" & Personnage.ID)

                                                                                            End If

                                                                                        Case Else

                                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Ev1;501", e.Message)

                                                                                    End Select

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Ev1;50", e.Message)

                                                                            End Select

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Ev1;5", e.Message)

                                                                    End Select

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Ev1;", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Ev1", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Ev", e.Message)

                                            End Select

                                        Case "W" ' EW

                                            Select Case e.Message(2)

                                                Case "+" ' EW+

                                                    If e.Message.Length > 3 Then

                                                        ' EW+ 0123456   |
                                                        ' EW+ ID tchatJoueur |
                                                        'Inconnu

                                                    Else

                                                        GiMétierModePublic(Index, e.Message)

                                                    End If

                                                Case "-" ' EW-

                                                    If e.Message.Length > 3 Then


                                                    Else

                                                        GiMétierModePublic(Index, e.Message)

                                                    End If

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "EW", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "E", e.Message)

                                    End Select

                                Case "e"

                                    Select Case e.Message(1)

                                        Case "L" ' eL

                                            'eL7808|0 = Inconnu

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "e", e.Message)

                                    End Select

                                Case "F"

                                    Select Case e.Message(1)

                                        Case "A" ' FA

                                            Select Case e.Message(2)

                                                Case "K" ' FAK

                                                    GiAmiEnnemiAjoute(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "FA", e.Message)

                                            End Select

                                        Case "L" ' FL

                                            GiAmiEnnemi(Index, e.Message)

                                        Case "O" ' FO

                                            Select Case e.Message(2)

                                                Case "-" ' FO- 

                                                    AmiAvertie = False

                                                    EcritureMessage(Index, "[Dofus]", "Vous serai pas avertie lors de la connexion d'un ami.", Color.Green)

                                                Case "+" ' FO+

                                                    AmiAvertie = True

                                                    EcritureMessage(Index, "[Dofus]", "Vous serai avertie lors de la connexion d'un ami.", Color.Green)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "FO", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "F", e.Message)

                                    End Select

                                Case "f"

                                    Select Case e.Message(1)

                                        Case "C" ' fC

                                            Select Case CInt(e.Message(2).ToString)

                                                Case "0" ' fC0

                                                    EcritureMessage(Index, "[Dofus]", "Il n'y a aucun combat en cours actuellement sur la map.", Color.Green)

                                                    MapSpectateur = False

                                                Case > 0 ' fC1

                                                    EcritureMessage(Index, "[Dofus]", "Il y a des combats en cours actuellement sur la map.", Color.Green)

                                                    MapSpectateur = True

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "fC", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "f", e.Message)

                                    End Select

                                Case "G"

                                    Select Case e.Message(1)

                                        Case "A" ' GA

                                            Select Case e.Message(2)

                                                Case "0" ' GA0

                                                    Select Case e.Message(3)

                                                        Case ";" ' GA0;

                                                            Select Case e.Message(4)

                                                                Case "1" ' GA0;1

                                                                    Select Case e.Message(5)

                                                                        Case ";" ' GA0;1;

                                                                            GiMapDéplacementEntité(Index, e.Message)

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA0;1", e.Message)

                                                                    End Select

                                                                Case "5" ' GA0;5

                                                                    Select Case e.Message(5)

                                                                        Case "0" ' GA0;50

                                                                            Select Case e.Message(6)

                                                                                Case "1" ' GA0;501

                                                                                    Select Case e.Message(7)

                                                                                        Case ";" ' GA0;501;

                                                                                            GiRécolteEnCours(Index, e.Message)

                                                                                        Case Else

                                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA0;501", e.Message)

                                                                                    End Select

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA0;50", e.Message)

                                                                            End Select

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA0;5", e.Message)

                                                                    End Select

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA0;", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA0", e.Message)

                                                    End Select

                                                Case "1" ' GA1

                                                    Select Case e.Message(3)

                                                        Case ";" ' GA1;

                                                            Select Case e.Message(4)

                                                            Case "4" ' GA1;4

                                                                Select Case e.Message(5)

                                                                    Case ";" ' GA1;4;

                                                                        GiMapDéplacementEntitéEscalié(Index, e.Message)

                                                                    Case Else

                                                                        ErreurFichier(Index, Personnage.NomDuPersonnage, "GA1;4", e.Message)

                                                                End Select

                                                            Case "5" ' GA1;5

                                                                    Select Case e.Message(5)

                                                                        Case "0" ' GA1;50

                                                                            Select Case e.Message(6)

                                                                                Case "1" ' GA1;501

                                                                                    Select Case e.Message(7)

                                                                                        Case ";" ' GA1;501;

                                                                                            GiRécolteEnCours(Index, e.Message)

                                                                                        Case Else

                                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA1;501", e.Message)

                                                                                    End Select

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA1;50", e.Message)

                                                                            End Select

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA1;5", e.Message)

                                                                    End Select

                                                                Case Else

                                                                ErreurFichier(Index, Personnage.NomDuPersonnage, "GA1;", e.Message)

                                                        End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA", e.Message)

                                                    End Select

                                                Case ";" ' GA;

                                                    Select Case e.Message(3)

                                                        Case "0" ' GA;0

                                                            If _Send <> "" Then

                                                                Send(_Send)

                                                                _Send = ""

                                                            End If

                                                            PathTotal = ""
                                                            EnDéplacement = False
                                                            BloqueDéplacement.Set()

                                                        Case "1" ' GA;1

                                                            Select Case e.Message(4)

                                                                Case "0" ' GA;10

                                                                    Select Case e.Message(5)

                                                                        Case "0" ' GA;100

                                                                            Select Case e.Message(6)

                                                                                Case ";" ' GA;100;

                                                                                    GiCombatRetirePdv(Index, e.Message)

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;100", e.Message)

                                                                            End Select

                                                                        Case "2" ' GA;102

                                                                            GiCombatPAUtilisé(Index, e.Message)

                                                                        Case "3" ' GA;103

                                                                            Select Case e.Message(6)

                                                                                Case ";" ' GA;103;

                                                                                    GiMortJoueurMobs(Index, e.Message)

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;103", e.Message)

                                                                            End Select

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;10", e.Message)

                                                                    End Select

                                                                Case "1" ' GA;11

                                                                    Select Case e.Message(5)

                                                                        Case "6" ' GA;116

                                                                            GiCombatPOPerdu(Index, e.Message)

                                                                        Case "7" ' GA;117

                                                                            GiCombatPOGagné(Index, e.Message)

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;11", e.Message)

                                                                    End Select

                                                                Case "2" ' GA,12

                                                                    Select Case e.Message(5)

                                                                        Case "9" ' GA,129

                                                                            Select Case e.Message(6)

                                                                                Case ";" ' GA,129;

                                                                                    GiCombatPMPerdu(Index, e.Message)

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;129", e.Message)

                                                                            End Select

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;12", e.Message)

                                                                    End Select

                                                                Case ";" ' GA;1;

                                                                    GiMapDéplacementEntité(Index, e.Message)

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;1", e.Message)

                                                            End Select

                                                        Case "2" ' GA;2

                                                'GA;2;1234567;
                                                'Quand je change de map.
                                                'Inutile, car on passe par le GDM

                                                        Case "3" ' GA;3

                                                            Select Case e.Message(4)

                                                                Case "0" ' GA;30 

                                                                    Select Case e.Message(5)

                                                                        Case "0" ' GA;300

                                                                            Select Case e.Message(6)

                                                                                Case ";" ' GA;300;

                                                                                    GiCombatSortNormal(Index, e.Message)

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;300", e.Message)

                                                                            End Select

                                                                        Case "1" ' GA;301

                                                                            GiCombatSortCoupCritique(Index, e.Message)

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;30", e.Message)

                                                                    End Select

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;3", e.Message)

                                                            End Select

                                                        Case "9" ' GA;9

                                                            Select Case e.Message(4)

                                                                Case "0" ' GA;90

                                                                    Select Case e.Message(5)

                                                                        Case "0" ' GA;900

                                                                            Select Case e.Message(6)

                                                                                Case ";" ' GA;900;

                                                                                    GiDefiRecu(Index, e.Message)

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;900", e.Message)

                                                                            End Select

                                                                        Case "1"

                                                                            Select Case e.Message(6)

                                                                                Case ";" ' GA;901;

                                                                                    GiDefiAccepter(Index, e.Message)

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;901", e.Message)

                                                                            End Select

                                                                        Case "2"

                                                                            Select Case e.Message(6)

                                                                                Case ";" ' GA;902;

                                                                                    GiDefiRefuser(Index, e.Message)

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;902", e.Message)

                                                                            End Select

                                                                        Case "5" ' GA;905

                                                                            Select Case e.Message(6)

                                                                                Case ";" ' GA;905;

                                                                                    GiCombatEntrer(Index, e.Message)

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;905", e.Message)

                                                                            End Select

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;90", e.Message)

                                                                    End Select

                                                                Case "5" ' GA;95

                                                                    Select Case e.Message(5)

                                                                        Case "0" ' GA;950

                                                                            Select Case e.Message(6)

                                                                                Case ";" ' GA;950;

                                                                                    CombatEtat(Index, e.Message)

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;905", e.Message)

                                                                            End Select

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;90", e.Message)

                                                                    End Select

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;9", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GA;", e.Message)

                                                    End Select

                                                Case "F"

                                                    Select Case e.Message(3)

                                                        Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"

                                                            Task.Run(Sub() GiCombatAction(Index, e.Message))

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GAF", e.Message)

                                                    End Select

                                                Case "S" ' GAS

                                                    'GAS 1234567
                                                    'GAS id unique

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GA", e.Message)

                                            End Select

                                        Case "a" ' Ga

                                            Select Case e.Message(2)

                                                Case "F" ' GaF

                                                    Select Case e.Message(2)

                                                        Case "|" ' GaF|

                                                            If MITM = False Then

                                                                Send("Ga" & ((Personnage.ID * 2) + 11))

                                                            End If

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GaF", e.Message)

                                                    End Select

                                                Case "0" ' Ga0

                                                    Select Case e.Message(3)

                                                        Case ";" ' Ga0;

                                                            Select Case e.Message(4)

                                                                Case "1" ' Ga0;1

                                                                    Select Case e.Message(5)

                                                                        Case ";" ' Ga0;1;

                                                                            'Ga0;1;1234567;aaLcgbdgRchi
                                                                            If MITM = False Then

                                                                                Send("Ga" & Split(e.Message, ";")(2))

                                                                            End If

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Ga0;1", e.Message)

                                                                    End Select

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Ga0;", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Ga0", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Ga", e.Message)

                                            End Select

                                        Case "B" ' GB

                                            Select Case e.Message(2)

                                                Case "1" ' GB1

                                                    Select Case e.Message(3)

                                                        Case ";" ' GB1;

                                                            Select Case e.Message(4)

                                                                Case "5" ' GB1;5

                                                                    Select Case e.Message(5)

                                                                        Case "0" ' GB1;50

                                                                            Select Case e.Message(6)

                                                                                Case "1" ' GB1;501

                                                                                    Select Case e.Message(7)

                                                                                        Case ";" ' GB1;501;

                                                                                            If MITM = False Then

                                                                                                Send("GB" & Personnage.ID)

                                                                                            End If

                                                                                        Case Else

                                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GB1;501", e.Message)

                                                                                    End Select

                                                                                Case Else

                                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GB1;50", e.Message)

                                                                            End Select

                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GB1;5", e.Message)

                                                                    End Select

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GB1;", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GB1", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GB", e.Message)

                                            End Select

                                        Case "C" ' GC

                                            Select Case e.Message(2)

                                                Case "K" ' GCK

                                                    Select Case e.Message(3)

                                                        Case "|" ' GCK|

                                                            Select Case e.Message(4)

                                                                Case "1" ' GCK|1

                                                                    Select Case e.Message(5)

                                                                        Case "|" ' GCK|1|

                                                                            ' GCK|1|Linaculer
                                                                            ' ?
                                                                        Case Else

                                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GCK|1", e.Message)

                                                                    End Select

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GCK|", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GCK", e.Message)

                                                    End Select

                                                Case "E" ' GCE

                                                    ' ?

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GC", e.Message)

                                            End Select

                                        Case "D" ' GD

                                            If e.Message = "GD" Then

                                                If MITM = False Then

                                                    Send("GD" & Personnage.ID)

                                                End If

                                            Else

                                                Select Case e.Message(2)

                                                    Case "F" ' GDF

                                                        GiInteractionEnJeu(Index, e.Message)

                                                    Case "K" ' GDK

                                                        If e.Message = "GDK" Then

                                                            ' Inconnu

                                                        Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GD", e.Message)

                                                        End If

                                                    Case "M" ' GDM

                                                        Select Case e.Message(3)

                                                            Case "|" ' GDM|

                                                                GiMapData(Index, e.Message)

                                                            Case Else

                                                                ErreurFichier(Index, Personnage.NomDuPersonnage, "GDM", e.Message)

                                                        End Select

                                                    Case "O" ' GDO

                                                        Select Case e.Message(3)

                                                            Case "+" ' GDO+

                                                                GiMapAjouteObjet(Index, e.Message)

                                                            Case "-" ' GDO-

                                                                GiMapSupprimeObjet(Index, e.Message)

                                                            Case Else

                                                                ErreurFichier(Index, Personnage.NomDuPersonnage, "GDO", e.Message)

                                                        End Select

                                                    Case Else

                                                        ErreurFichier(Index, Personnage.NomDuPersonnage, "GD", e.Message)

                                                End Select

                                            End If

                                        Case "d" ' Gd

                                            Select Case e.Message(2)

                                                Case "O" ' GdO

                                                    Select Case e.Message(3)

                                                        Case "K" ' GdOK

                                                            GiCombatChallengeRéussi(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GdO", e.Message)

                                                    End Select

                                                Case "K" ' GdK

                                                    Select Case e.Message(3)

                                                        Case "O" ' GdKO

                                                            GiCombatChallengeEchoué(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GdK", e.Message)

                                                    End Select


                                                Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" ' Gdx

                                                    GiCombatChallengeReçu(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Gd", e.Message)

                                            End Select

                                        Case "E" ' GE

                                            GiCombatFin(Index, e.Message)

                                        Case "I" ' GI

                                            Select Case e.Message(2)

                                                Case "C" ' GIC

                                                    Select Case e.Message(3)

                                                        Case "|" ' GIC|

                                                            GiCombatPhasePlacement(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GIC", e.Message)

                                                    End Select

                                                Case "E" ' GIE

                                                    'GIE112;ID_Receveur;Nbr_Booste;;;;Nbr_Tour;ID_Sort    
                                                    'Indique les effets de sort en jeu.
                                                    'Inutile de le faire, car les booste je les affiche déjà avec  GA;112;2594870;2594870,6,6 
                                                    'Permet de l'afficher en jeu.

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GI", e.Message)

                                            End Select

                                        Case "J" ' GJ

                                            Select Case e.Message(2)

                                                Case "K" ' GJK

                                                    Select Case e.Message(3)

                                                        Case "2" ' GJK2

                                                            GiCombatTempsPréparation(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GJK", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GJ", e.Message)

                                            End Select

                                        Case "M" ' GM

                                            Select Case e.Message(2)

                                                Case "|" ' GM|

                                                    Select Case e.Message(3)

                                                        Case "+", "~" ' GM|+

                                                            GiMapAjouteEntité(Index, e.Message)

                                                        Case "-"

                                                            GiMapSupprimeEntité(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GM|", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GM", e.Message)

                                            End Select

                                        Case "P" ' GP

                                            GiPlacementCase(Index, e.Message)

                                        Case "R" ' GR

                                            Select Case e.Message(2)

                                                Case "1" ' GR1

                                                    GiCombatPrêt(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GR", e.Message)

                                            End Select

                                        Case "S" ' GS

                                            If e.Message <> "GS" Then

                                                ErreurFichier(Index, Personnage.NomDuPersonnage, "GS", e.Message)

                                            Else

                                                'GS  = ?

                                            End If

                                        Case "T" ' GT

                                            Select Case e.Message(2)

                                                Case "F" ' GTF
                                         'GTF-1
                                        'Tour pass
                                            '  If fMap.ContainsKey(Mid(Message, 4)) Then



                                            'End If

                                                Case "L" ' GTL

                                                    Select Case e.Message(3)

                                                        Case "|" ' GTL|

                                                            GiCombatOrdreTour(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GTL", e.Message)

                                                    End Select

                                                Case "M" ' GTM

                                                    Select Case e.Message(3)

                                                        Case "|" ' GTM|

                                                            GiCombatInformationTour(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "GTM", e.Message)

                                                    End Select

                                                Case "R" ' GTR

                                                    GiCombatTourPassé(Index, e.Message)

                                                Case "S" ' GTS

                                                    GiCombatTourActuel(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "GT", e.Message)

                                            End Select

                                        Case "t" ' Gt

                                            GiCombatLancer(Index, e.Message)

                                        Case "V" ' GV

                                            If e.Message = "GV" Then

                                                EnDefi = False
                                                BloqueDefi.Set()
                                                DefiIdDemandeur = Nothing
                                                EnCombatDefi = False

                                            Else

                                                ErreurFichier(Index, Personnage.NomDuPersonnage, "GV", e.Message)

                                            End If

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "G", e.Message)

                                    End Select

                                Case "g"

                                    Select Case e.Message(1)

                                        Case "H" ' gH

                                            Select Case e.Message(2)

                                                Case "E" ' gHE

                                                    Select Case e.Message(3)

                                                        Case "y" ' gHEy

                                                            EcritureMessage(Index, "[Dofus]", "Impossible de poser le percepteur maintenant, il doit se reposer.", Color.Red)
                                                            BloqueGuilde.Set()

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "gHE", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "gH", e.Message)

                                            End Select

                                        Case "I" ' gI

                                            Select Case e.Message(2)

                                                Case "B" ' gIB

                                                    GiGuildePersonnalisation(Index, e.Message)

                                                Case "F" ' gIF

                                                    GiGuildeEnclos(Index, e.Message)

                                                Case "G" ' gIG

                                                    GiGuildeExp(Index, e.Message)

                                                Case "H" ' gIH

                                                    Select Case e.Message(3)

                                                        Case "+" ' gIH+

                                                            GiGuildeMaison(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "gIH", e.Message)

                                                    End Select

                                                Case "M" ' gIM

                                                    Select Case e.Message(3)

                                                        Case "+" ' gIM+

                                                            GuildeMembresAjoute(Index, e.Message)

                                                        Case "-" ' gIM-

                                                            GuildeMembreSupprime(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "gIM", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "gI", e.Message)

                                            End Select

                                        Case "J" ' gJ

                                            Select Case e.Message(2)

                                                Case "E" ' gJE

                                                    GiGuildeInvitationEnCoursRefuse(Index, e.Message)

                                                Case "K" ' gJK

                                                    Select Case e.Message(3)

                                                        Case "a" ' gJKa

                                                            GiGuildeInvitationEnCoursAccepte(Index, e.Message)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "gJK", e.Message)

                                                    End Select

                                                Case "R" ' gJR

                                                    GiGuildeInvitationEnCours(Index, e.Message)

                                                Case "r" ' gJr

                                                    GiGuildeInvitationEnCoursInformation(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "gJ", e.Message)

                                            End Select

                                        Case "K" ' gK

                                            Select Case e.Message(2)

                                                Case "K" ' gKK

                                                    GiGuildeJoueurExclut(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "gK", e.Message)

                                            End Select

                                        Case "S" ' gS

                                            GiGuildeInformation(Index, e.Message)

                                        Case "T" ' gT

                                            Select Case e.Message(2)

                                                Case "R" ' gTR

                                                    GiGuildePercepteurRetire(Index, e.Message)

                                                Case "S" ' gTS

                                                    GiGuildePercepteurPosee(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "gT", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "g", e.Message)

                                    End Select

                                Case "H"

                                    Select Case e.Message(1)

                                        Case "C" ' HC

                                            EnAuthentification = True
                                            GiConnexionServeurAuthentification(Index, e.Message)

                                        Case "G" ' HG

                                            EnAuthentification = False
                                            GiConnexionServeurJeu(Index)

                                            Exit Sub

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "H", e.Message)

                                    End Select

                                Case "h"

                                    Select Case e.Message(1)

                                        Case "L" ' hL

                                            Select Case e.Message(2)

                                                Case "+" ' hL+

                                                    GiMaMaison(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "hL", e.Message)

                                            End Select

                                        Case "P" ' hP

                                            GiMaisonMap(Index, e.Message)

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "h", e.Message)

                                    End Select

                                Case "I"

                                    Select Case e.Message(1)

                                        Case "A" ' IA

                                            Select Case e.Message(2)

                                                Case "K" ' IAK

                                                    Select Case e.Message(3)

                                                        Case "O" ' IAKO

                                                            Select Case e.Message(4)

                                                                Case "+" ' IAKO+

                                                                    If MITM = False Then

                                                                        Send("IA" & (Personnage.ID + 25018))

                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "IAKO", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "IAK", e.Message)

                                                    End Select

                                                Case ";" ' IA;

                                                    Select Case e.Message(3)

                                                        Case "1" ' IA;1

                                                            Select Case e.Message(4)

                                                                Case ";" ' IA;1;

                                                                    If MITM = False Then

                                                                        Send("IA" & ((Personnage.ID * 2) + 14))

                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "IA;1", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "IA;", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "IA", e.Message)

                                            End Select

                                        Case "C" ' IC

                                            GiGroupeSuivreCoordonnées(Index, e.Message)

                                        Case "L" ' IL

                                            Select Case e.Message(2)

                                                Case "F" ' ILF

                                                    GiPdvRestauré(Index, e.Message)

                                                Case "S" ' ILS

                                                    GiRégénérationSeconde(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "IL", e.Message)

                                            End Select

                                        Case "m" ' Im

                                            GiDofusInformation(Index, e.Message)

                                        Case "Q" ' IQ

                                            RécolteDrop(Index, e.Message)

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "I", e.Message)

                                    End Select

                                Case "i"

                                    Select Case e.Message(1)

                                        Case "L" ' iL

                                            GiAmiEnnemi(Index, e.Message)

                                        Case "A" ' iA

                                            Select Case e.Message(2)

                                                Case "K" ' iAK

                                                    GiAmiEnnemiAjoute(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "iA", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "i", e.Message)

                                    End Select

                                Case "J"

                                    Select Case e.Message(1)

                                        Case "N" ' JN

                                            GiMétierUp(Index, e.Message)

                                        Case "O" ' JO

                                            GiMétierOption(Index, e.Message)

                                        Case "R" ' JR

                                            GiMétierSupprime(Index, e.Message)

                                        Case "S" ' JS

                                            Select Case e.Message(2)

                                                Case "|" ' JS|

                                                    GiMétierInformation(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "J", e.Message)

                                            End Select

                                        Case "X" ' JX

                                            Select Case e.Message(2)

                                                Case "|" ' JX|

                                                    GiMétierExpèrience(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "J", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "J", e.Message)

                                    End Select

                                Case "j"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "j", e.Message)

                                Case "K"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "K", e.Message)

                                Case "k"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "k", e.Message)

                                Case "L"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "L", e.Message)

                                Case "l"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "l", e.Message)

                                Case "M"

                                    Select Case e.Message(1)

                                        Case "0" ' M0

                                            Select Case e.Message(2)

                                                Case "1" ' M01

                                                    If e.Message = "M01" Then

                                                        EcritureMessage(Index, "[Dofus]", "Connexion interrompue avec le serveur." & vbCrLf &
                                                                                  "Tu es resté trop longtemps inactif.", Color.Red)

                                                        If MITM Then

                                                            Client.Close()

                                                        End If

                                                        Socket.Connexion_Game(False)

                                                    Else

                                                        Select Case e.Message(3)

                                                            Case "3" ' M013



                                                            Case Else

                                                                ErreurFichier(Index, Personnage.NomDuPersonnage, "M01", e.Message)

                                                        End Select

                                                    End If

                                                Case "2" ' M02

                                                    Select Case e.Message(3)

                                                        Case "7" ' M027

                                                            EcritureMessage(Index, "[Dofus]", "Connexion interrompue avec le serveur." & vbCrLf & "Ce serveur est complet. Seuls les comptes possédant déjà un personnage sur ce serveur peuvent s'y connecter.", Color.Red)

                                                            Socket_Authentification.Connexion_Game(False)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "M02", e.Message)

                                                    End Select

                                                Case "3" ' M03

                                                    Select Case e.Message(3)

                                                        Case "1" ' M031

                                                            EcritureMessage(Index, "[Dofus]", "Connexion interrompue avec le serveur." & vbCrLf &
                                                                        "Connexion refusé." & vbCrLf &
                                                                        "Le serveur de jeu n'a pas reçu les informations d'authentification suite à votre identification." & vbCrLf &
                                                                        "Réessayer, si le problème persiste, contactez votre admistrateur réseau ou votre FAI, il s'agit probablement d'une redirection erronée due à un mauvais paramétrage DNS.", Color.Red)

                                                            If MITM Then

                                                                Client.Close()

                                                            End If

                                                            Socket_Authentification.Connexion_Game(False)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "M03", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "M0", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, e.Message(0), e.Message)

                                    End Select

                                Case "m"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "m", e.Message)

                                Case "N"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "N", e.Message)

                                Case "n"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "n", e.Message)

                                Case "O"

                                    Select Case e.Message(1)

                                        Case "A" ' OA

                                            Select Case e.Message(2)

                                                Case "E" ' OAE

                                                    Select Case e.Message(3)

                                                        Case "F"

                                                            EcritureMessage(Index, "[Inventaire]", "Ton Inventaire est plein.", Color.Red)

                                                        Case "A"

                                                            EcritureMessage(Index, "[Dofus]", "Déjà équipé !.", Color.Red)

                                                        Case "L"

                                                            EcritureMessage(Index, "[Equipement]", "Ton niveau est trop faible pour equiper cet objet.", Color.Red)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "OAE", e.Message)

                                                    End Select

                                                    BloqueItem.Set()

                                                Case "K" ' OAK

                                                Select Case e.Message(3)

                                                    Case "O" ' OAKO

                                                        GiItemAjoute(Index, e.Message.Replace("OAKO", ""), FrmUser.DataGridView_Inventaire)

                                                    Case Else

                                                        ErreurFichier(Index, Personnage.NomDuPersonnage, "OAK", e.Message)

                                                End Select

                                            Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "OA", e.Message)

                                            End Select

                                        Case "a" ' Oa

                                            GiPlayerChangeEquipment(Index, e.Message)

                                        Case "C" ' OC

                                            Select Case e.Message(2)

                                                Case "O" ' OCO

                                                    GiInventoryChangedCharacteristic(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "OC", e.Message)

                                            End Select

                                        Case "k" ' Ok

                                            Select Case e.Message(2)

                                                Case "F" ' OkF

                                                    Select Case e.Message(3)

                                                        Case "|" ' OkF|

                                                            If MITM = False Then

                                                                Send("Ok" & Personnage.ID)

                                                            End If

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "OkF", e.Message)

                                                    End Select

                                                Case "K" ' OkK

                                                    Select Case e.Message(3)

                                                        Case "O" ' OkKO

                                                            Select Case e.Message(4)

                                                                Case "-" ' OkKO-

                                                                    If MITM = False Then

                                                                        Send("Ok" & (Personnage.ID + 3))

                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "OkKO", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "OkK", e.Message)

                                                    End Select

                                                Case "|" ' Ok|

                                                    Select Case e.Message(3)

                                                        Case "+" ' Ok|+

                                                            If MITM = False Then

                                                                'Ok|+233;0;0;1234567;Linaculer;3;30^100;0;0,0,0,12345678;ffffff;1f07b5;0;,9aa,9a9,,;0;;;;;0;;
                                                                Send("Ok" & Personnage.ID)

                                                            End If

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Ok|", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Ok", e.Message)

                                            End Select

                                        Case "M" ' OM

                                            GiEquipement(Index, e.Message)

                                        Case "Q" ' OQ

                                            GiInventaireQuantité(Index, e.Message)

                                        Case "R" ' OR

                                            GiInventaireItemSupprime(Index, e.Message)

                                        Case "S" ' OS

                                            Select Case e.Message(2)

                                                Case "+" ' OS+

                                                    GiBonusEquipementAjoute(Index, e.Message)

                                                Case "-" ' OS-

                                                    GiBonusEquipementSupprime(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "OS", e.Message)

                                            End Select

                                        Case "T" ' OT

                                            GiEquipementMétier(Index, e.Message)

                                        Case "w" ' Ow

                                            GiPods(Index, e.Message)

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "O", e.Message)

                                    End Select

                                Case "o"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "o", e.Message)

                                Case "P"

                                    Select Case e.Message(1)

                                        Case "a" ' Pa

                                            Select Case e.Message(2)

                                                Case ";" ' Pa;

                                                    Select Case e.Message(3)

                                                        Case "1" ' Pa;1

                                                            Select Case e.Message(4)

                                                                Case ";" ' Pa;1;

                                                                    If MITM = False Then

                                                                        Send("Pa" & (Personnage.ID + 28549))

                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Pa;1", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Pa;", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Pa", e.Message)

                                            End Select

                                        Case "B" ' PB

                                            Select Case e.Message(2)

                                                Case ";" ' PB;

                                                    Select Case e.Message(3)

                                                        Case "1" ' PB;1

                                                            Select Case e.Message(4)

                                                                Case ";" ' PB;1;

                                                                    If MITM = False Then

                                                                        Send("PB" & (Personnage.ID * 2))

                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "PB;1", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "PB;", e.Message)

                                                    End Select

                                                Case "|" ' PB|

                                                    Select Case e.Message(3)

                                                        Case "+" ' PB|+

                                                            If MITM = False Then

                                                                'PB|+37;0;0;1234567;Linaculer;9;90^100;0;0,0,0,1234567;-1;-1;-1;215b,,,,;0;;;;;0;;

                                                                Send("PB" & (Personnage.ID + 305))

                                                            End If

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "PB|", e.Message)

                                                    End Select

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "PB", e.Message)

                                            End Select

                                        Case "C" ' PC

                                            Select Case e.Message(2)

                                                Case "K" ' PCK

                                                    GiGroupeRejoint(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "PC", e.Message)

                                            End Select

                                        Case "F" ' PF

                                            Select Case e.Message(2)

                                                Case "K" ' PFK

                                                    GiGroupeSuivezTous(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "PF", e.Message)

                                            End Select

                                        Case "I" ' PI

                                            Select Case e.Message(2)

                                                Case "E" ' PIE

                                                    Select Case e.Message(3)

                                                        Case "a" ' PIEa

                                                            EnInvitationGroupe = False
                                                            BloqueGroupe.Set()
                                                            EcritureMessage(Index, "[Dofus]", "Impossible, ce joueur fait déjà partie d'un groupe.", Color.Red)

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "PIE", e.Message)

                                                    End Select

                                                Case "K" ' PIK

                                                    GiGroupeRecoitInvitation(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "PI", e.Message)

                                            End Select

                                        Case "L" ' PL

                                            ' PL 1234567
                                            ' PL id chef
                                            GroupeChefID = Mid(e.Message, 3)

                                        Case "M" ' PM

                                            Select Case e.Message(2)

                                                Case "+" ' PM+

                                                    GiGroupeAjouteMembre(Index, e.Message)

                                                Case "-" ' PM-

                                                    GiGroupeSupprimeMembre(Index, e.Message)

                                                Case "~" ' PM~

                                                    GiGroupeModifieMembre(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "PM", e.Message)

                                            End Select

                                        Case "R" ' PR

                                            EnInvitationGroupe = False
                                            BloqueGroupe.Set()

                                        Case "V"

                                            GiGroupeQuitte(Index, e.Message)

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "P", e.Message)

                                    End Select

                                Case "p"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "p", e.Message)

                                Case "Q"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, e.Message(0), e.Message)

                                Case "q"

                                    Select Case e.Message

                                        Case "qpong"

                                            'Temps en ms du délai entre moi et le serveur.

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "q", e.Message)

                                    End Select

                                Case "R"

                                    Select Case e.Message(1)

                                        Case "e" ' Re

                                            Select Case e.Message(2)

                                            Case "+" ' Re+

                                                MaMonture.Equiper = True
                                                GiDragodindeEncloEtableEquipé(Index, e.Message, FrmUser.DataGridViewDragodindeMaMonture)

                                            Case "-" ' Re-

                                                MaMonture.Equiper = False
                                                FrmUser.DataGridViewDragodindeMaMonture.Rows.Clear()

                                            Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Re", e.Message)

                                            End Select

                                        Case "p" ' Rp

                                            GiEncloMap(Index, e.Message)

                                        Case "r" ' Rr

                                            Select Case e.Message(2)

                                                Case "+" ' Rr+

                                                    GiDragodindeMonterDesendu(Index, e.Message)

                                                Case "-" ' Rr-

                                                    GiDragodindeMonterDesendu(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Rr", e.Message)

                                            End Select

                                        Case "x" ' Rx

                                            GiDragodindeExperienceDonnee(Index, e.Message)

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, e.Message(0), e.Message)

                                    End Select

                                Case "r"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "r", e.Message)

                                Case "S"

                                    Select Case e.Message(1)

                                        Case "L" ' SL

                                            Select Case e.Message(2).ToString

                                                Case "o" ' SLo

                                                    Select Case e.Message(3)

                                                        Case "+" ' SLo+

                                                    'Inconnu
                                                    ' SLo+

                                                        Case "-"

                                                            Sort.Clear()

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "SLo", e.Message)

                                                    End Select

                                                Case > 0

                                                    GiSortAjoute(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "SL", e.Message)

                                            End Select

                                        Case "l" ' Sl

                                            Select Case e.Message(2)

                                                Case ";" ' Sl;

                                                    Select Case e.Message(3)

                                                        Case "1" ' Sl;1

                                                            Select Case e.Message(4)

                                                                Case ";" ' Sl;1;

                                                                    If MITM = False Then

                                                                        Send("Sl" & Personnage.ID)
                                                                        'ou   Send("Sl" & (Personnage.ID + 50))
                                                                    End If

                                                                Case Else

                                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Sl;1", e.Message)

                                                            End Select

                                                        Case Else

                                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Sl;", e.Message)

                                                    End Select

                                                Case "|"

                                                    If MITM = False Then

                                                        Send("Sl" & ((Personnage.ID * 2) + 108))

                                                    End If

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Sl", e.Message)

                                            End Select

                                        Case "U" ' SU

                                            Select Case e.Message(2)

                                                Case "K" ' SUK

                                                    GiSortUp(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "SU", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "S", e.Message)

                                    End Select

                                Case "s"

                                    Select Case e.Message(1)

                                        Case "L" ' sL

                                            Select Case e.Message(2)

                                                Case "+" ' sL+

                                                    GiMesCoffres(Index, e.Message)

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "sL", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "s", e.Message)

                                    End Select

                                Case "T"

                                    Select Case e.Message(1)

                                        Case "T"

                                            Select Case e.Message(2).ToString

                                                Case > 0

                                                    ' TT32

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "TT", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, e.Message(0), e.Message)

                                    End Select

                                Case "t"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "t", e.Message)

                                Case "U"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "U", e.Message)

                                Case "u"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "u", e.Message)

                                Case "V"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "V", e.Message)

                                Case "v"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "v", e.Message)

                                Case "W"

                                    Select Case e.Message(1)

                                        Case "C" ' WC

                                            GiZaapInformation(Index, e.Message)

                                        Case "V"

                                            If e.Message = "WV" Then

                                                EnInteraction = False
                                                BloqueInteraction.Set()

                                            Else

                                                ErreurFichier(Index, Personnage.NomDuPersonnage, "WV", e.Message)

                                            End If

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "W", e.Message)

                                    End Select

                                Case "w"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "w", e.Message)

                                Case "X"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "X", e.Message)

                                Case "x"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "x", e.Message)

                                Case "Y"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Y", e.Message)

                                Case "y"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "y", e.Message)

                                Case "Z"

                                    Select Case e.Message(1)

                                        Case "S" ' ZS

                                            Select Case e.Message(2)

                                                Case "0" ' ZS0

                                                    Personnage.Alignement = "Neutre"

                                                Case "1" ' ZS1

                                                    Personnage.Alignement = "Bontarien"

                                                Case "2" ' ZS2

                                                    Personnage.Alignement = "Brakmarien"

                                                Case Else

                                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "ZS", e.Message)

                                            End Select

                                        Case Else

                                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Z", e.Message)

                                    End Select

                                Case "z"

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "z", e.Message)

                                Case Else

                                    ErreurFichier(Index, Personnage.NomDuPersonnage, "Unknow", e.Message)

                            End Select

                    End If

                    If MITM Then

                        Try


                            Dim _bufferClient() As Byte = Encoding.ASCII.GetBytes(e.Message.ToString & vbNullChar)
                            Client.BeginSend(_bufferClient, 0, _bufferClient.Length, SocketFlags.None, New AsyncCallback(AddressOf SendCallBack), Client)

                        Catch ex As Exception

                            ErreurFichier(Index, Personnage.NomDuPersonnage, "Unknow", e.Message.ToString)

                        End Try

                    End If

                End If

            Catch ex As Exception

            End Try

        End If

    End Sub

    Public Sub MITM_ReceptionClient(ByVal Message As Object)

        If Message <> "" Then

            Select Case Message.ToString.Replace(vbLf, Nothing)

                Case "GKK0", "GKK1"

                    EnDéplacement = False
                    StopDéplacement = False
                    BloqueDéplacement.Set()

            End Select

        End If

    End Sub

#End Region

#Region "MITM"

    Private bloqueur As ManualResetEvent = New ManualResetEvent(False)

    Public Sub Main()

        Try

            Listener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Listener.Bind(New IPEndPoint(IPAddress.Parse("127.0.0.1"), 443))
            Listener.Listen(0)

            EcritureMessageSocket(Index, "[MITM]", " En Attente", Color.Red)

            Dim TAccept As New Thread(AddressOf AccepteMITM)
            TAccept.Start()

        Catch ex As Exception

            Listener.Close()

        End Try

    End Sub

    Private Sub AccepteMITM()

        Listener.BeginAccept(New AsyncCallback(AddressOf AcceptMITMCallBack), Listener)

    End Sub

    Private Sub AcceptMITMCallBack(ByVal AR As IAsyncResult)

        Socket_Authentification = If(Proxy, New All_CallBack(VarServeur("Authentification").IP, VarServeur("Authentification").Port, Proxy, ProxyIp, ProxyPort, ProxyNdc, ProxyMdp), New All_CallBack(VarServeur("Authentification").IP, VarServeur("Authentification").Port))

        Client = Listener.EndAccept(AR)

        AddHandler Socket_Authentification.Connexion, AddressOf e_Connexion
        AddHandler Socket_Authentification.Deconnexion, AddressOf e_Deconnexion
        AddHandler Socket_Authentification.Envoie, AddressOf e_Envoi
        AddHandler Socket_Authentification.Reception, AddressOf E_Reception

        EcritureMessageSocket(Index, "[MITM]", "Client connecté au bot.", Color.Red)
        Listener.Close()


    End Sub

    Dim sbClient As New StringBuilder()
    Public Sub ReceiveCallBackClient(ByVal AR As IAsyncResult)

        Try

            sbClient.Clear()

            Dim mClient As Socket = CType(AR.AsyncState, Socket)
            Dim bytesRead As Integer = Client.EndReceive(AR)

            If bytesRead > 0 Then

                For i = 0 To bytesRead - 1

                    If (BufferClient(i) = 0) Then

                        MITM_ReceptionClient(sbClient.ToString)

                        EcritureMessageSocket(Index, "[Client] ", "Send : " & sbClient.ToString, Color.Orange)

                        Dim bufferServer() As Byte = Encoding.UTF8.GetBytes(sbClient.ToString)

                        If EnAuthentification Then

                            Socket_Authentification.LaSocket.BeginSend(bufferServer, 0, bufferServer.Length, SocketFlags.None, New AsyncCallback(AddressOf SendCallBack), Socket_Authentification.LaSocket)

                        ElseIf Connecté OrElse EnConnexion Then

                            Socket.LaSocket.BeginSend(bufferServer, 0, bufferServer.Length, SocketFlags.None, New AsyncCallback(AddressOf SendCallBack), Socket.LaSocket)

                        End If

                        sbClient.Clear()

                    Else

                        sbClient.Append(ChrW(BufferClient(i)))

                    End If

                Next

                Try

                    mClient.BeginReceive(BufferClient, 0, BufferClient.Length, 0, New AsyncCallback(AddressOf ReceiveCallBackClient), mClient)

                Catch ex As Exception

                End Try

            ElseIf bytesRead = 0 Then

                Try

                    If EnAuthentification Then

                        Socket_Authentification.Connexion_Game(False)

                    ElseIf Connecté Then

                        Socket.Connexion_Game(False)

                    End If

                    Connecté = False

                    Main()

                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Send"

    Public Sub SendCallBack(ByVal AR As IAsyncResult)

        Dim LaSocket As Socket = CType(AR.AsyncState, Socket)
        Dim bytesSent As Integer = LaSocket.EndSend(AR)

    End Sub

    Public Sub Send(ByVal message As String, Optional ByVal wait As Boolean = False)

        If EnAuthentification Then

            Socket_Authentification.Envoyer(message)

        ElseIf Connecté OrElse EnConnexion Then

            Socket.Envoyer(message)

        End If

        If MITM AndAlso wait Then

            bloqueur.WaitOne(30000)

        End If

    End Sub

#End Region

End Class
