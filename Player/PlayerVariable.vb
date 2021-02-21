
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

    Public Index As Integer
    Public FrmGroupe As New FrmGroupe
    Public FrmUser As New FrmUser
    Public Personnage As New ClassPersonnage

    'Connexion
    Public Connecté, EnConnexion As Boolean
    Public EnAuthentification As Boolean

    'Les Sockets
    Public Socket_Authentification, Socket As All_CallBack
    Public SockSendRecv As New Dictionary(Of String, Color)

    'Envoie
    Public _Send As String

    'DLL
    Public ThreadDll As Threading.Thread

    'Caractéristique
    Public Caracteristique As New CCaracteristique

    'Sort
    Public Sort As New Dictionary(Of String, CSort)
    Public BloqueSort As New Threading.ManualResetEvent(False)

    'Combat
    Public Combat As New CCombat

    'IA
    Public IntelligenceArtificielle As New List(Of String)

    'Map
    Public BloqueDeplacement As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public Map As New CMap

    'Guilde
    Public BloqueGuilde As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)

    'Inventaire
    Public Inventaire As New Dictionary(Of Integer, CItem)
    Public BloqueItem As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public BonusEquipement As New Dictionary(Of Integer, CBonusEquipement)

    'Dragodinde
    Public Dragodinde As New CDragodinde


    'Métier
    Public Metier As New Dictionary(Of Integer, CMetier)
    Public Recolte As New CRecolte

    'Guilde
    Public Guilde As New CGuilde

    'Pnj
    Public Pnj As New CPnj

    'Echange
    Public Echange As New CEchange

    'Ami
    Public Ami As New CAmi

    'Tchat
    Public Tchat As New CTchat
    Public FrmTchat As New FrmTchat(Index)

    'Maison
    Public Maison As New CMaison

    'Groupe
    Public Groupe As New CGroupe

    'Defi
    Public Defi As New CDefi

    'Zaap
    Public ZaapI As New Dictionary(Of Integer, Integer)

    'Enclos
    Public Enclos As New CEnclos

    'Option total
    Public [Option] As New COption

End Class
