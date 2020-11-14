
Partial Class Player

    Public Proxy As Boolean = False
    Public ProxyIp, ProxyPort, ProxyNdc, ProxyMdp As String

#Region "MITM"

    Public Client As Net.Sockets.Socket
    Public Listener As Net.Sockets.Socket
    Public BufferClient(65536) As Byte
    Public MITM As Boolean
    Public AppMITM As Integer

#End Region



    'EXEMPLE SI 2 TRUC PAREIL SI FRIEND
    'Friend = Friend fSort
    'Public = Public Sort
    Public Index As Integer
    Public FrmGroupe As New FrmGroupe
    Public FrmUser As New FrmUser
    Public Personnage As New ClassPersonnage
    Public EnAuthentification As Boolean



    Public DiscordBot As Boolean = True

    'Connexion
    Public Connecté, EnConnexion As Boolean

    'Les Sockets
    Public Socket_Authentification, Socket As All_CallBack

    'Envoie
    Public _Send As String

    'Défi
    Public BloqueDefi As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public EnDefi, EnCombatDefi As Boolean
    Public DefiIdDemandeur As Integer

    'Echange
    Public EchangeMarchandise As New Dictionary(Of Integer, ClassItem)
    Public EnEchange, EnInvitationEchange As Boolean
    Public EchangeValideMoi, EchangeValideLui As Boolean
    Public BloqueEchange As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public EnEchangeKamasMoi, EnEchangeKamasLui As Integer

    'Inventaire
    Public BloqueItem As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public InventaireEchange As New Dictionary(Of Integer, ClassItem)
    Public BonusEquipement As New Dictionary(Of Integer, ClassBonusEquipement)

    'Caractéristique
    Public FullPods As Boolean
    Public BloqueCaractéristique As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)

    'Guilde
    Public Guilde As New ClassGuilde
    Public EnGuilde As Boolean
    Public EnInvitationGuilde As Boolean
    Public EnInvitationGuildeInviteur, EnInvitationGuildeInviter As String
    Public BloqueGuilde As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)

    'Tchat
    Public BloqueTchat As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)

    'Sort
    Public Sort As New Dictionary(Of String, ClassSort)

    'Ami
    Public AmiAvertie As Boolean

    'Hôtel de vente
    Public BloqueHDV As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public HdvInfo As New ClassHDV
    Public EnHDV As Boolean

    'Combat
    Public IA As New Dictionary(Of String, List(Of String))
    Public CombatListePlacement As New Dictionary(Of Integer, List(Of Integer))
    Public Challenge As New ClassChallenge
    Public CombatSpectateur As Boolean
    Public CombatPlacement As Boolean
    Public CombatEchec As Boolean
    Public CombatPause As Integer
    Public CombatMonTour As Boolean
    Public EnCombat As Boolean
    Public BloqueCombat As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)

    'Quête
    Public Quête As New Dictionary(Of String, ClassQuête)

    'Map
    Public BloqueDéplacement As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public MapLargeur, MapHauteur As Integer
    Public MapHandler(1280) As Cell
    Public fMapObjet As New Dictionary(Of Integer, ClassMapObjet)
    Public fMap As New Dictionary(Of Integer, ClassMap)
    Public MapCombat As New Dictionary(Of Integer, List(Of ClassMapCombatLancer))
    Public PathTotal As String
    Public MapSpectateur As Boolean
    Public MapID, CellID As Integer
    Public EnDéplacement As Boolean
    Public StopDéplacement As Boolean
    Public Haut, Bas, Gauche, Droite As Integer
    Public Coordonnées As String
    Public Map_Viewer_BitMap_All, Map_Viewer_BitMap As New Bitmap(1000, 1000)
    Public MapListeCelluleLeft(1024), MapListeCelluleTop(1024), MapListeCelluleRight(1024), MapListeCelluleDown(1024) As Point

    'Pnj
    Public EnDialogue As Boolean
    Public BloqueDialogue As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public fPnjRéponse As New List(Of String)
    Public fDialogueRéponse As Integer

    'Interaction
    Public InteractionCellID As Integer
    Public Interaction As New Dictionary(Of Integer, ClassInteraction)
    Public BloqueInteraction As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public EnInteraction As Boolean

    'Métier
    Public Métier As New Dictionary(Of String, ClassMétier)
    Public BloqueMétier As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)

    'Maison
    Public fMaison As New Dictionary(Of Integer, ClassMaison)
    Public Maison As New ClassMaison
    Public Coffre As New Dictionary(Of Integer, ClassCoffre)

    'Zaap
    Public fZaap As New Dictionary(Of Integer, Integer)

    'Ami
    Public BloqueAmi As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public fAmi As New Dictionary(Of String, List(Of sFriend))

    'Récolte
    Public BloqueRécolte As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public EnRécolte As Boolean
    Public RécolteNuméro As Integer

    'Enclo
    Public EncloMap As New ClassEnclo

    'Plugin
    Public fPlugin As Threading.Thread
    Public PluginAll As Threading.Thread

    'Banque
    Public EnBanque As Boolean
    Public Banque As New Dictionary(Of Integer, ClassItem)

    'Dragodinde
    Public BloqueDragodinde As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public MaMonture As New ClassMaMonture

    'Groupe
    Public BloqueGroupe As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public EnInvitationGroupe As Boolean
    Public EnGroupe As Boolean
    Public GroupeChefID As Integer
    Public GroupeSuivreId As Integer
    Public GroupeSuivreCoordonnées As String
    Public MonGroupe As New Dictionary(Of Integer, ClassGroupe)



    Structure sFriend

            Dim Pseudo As String
            Dim InFriend As Boolean
            Dim Name As String
            Dim Level As String
            Dim Alignment As String
            Dim Classe As String
            Dim Sex As String
            Dim ClasseSex As String

        End Structure

    End Class
