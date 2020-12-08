
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

    'Caractéristique
    Public BloqueCaracteristique As New Threading.ManualResetEvent(False)

    'Sort
    Public Sort As New Dictionary(Of String, ClassSort)
    Public BloqueSort As New Threading.ManualResetEvent(False)

    'Combat
    Public EnCombat As Boolean

    'Map
    Public BloqueDeplacement As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public Map As New ClassMap

    'Guilde
    Public BloqueGuilde As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)

    'Inventaire
    Public Inventaire As New Dictionary(Of Integer, ClassItem)
    Public BloqueItem As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)
    Public BonusEquipement As New Dictionary(Of Integer, ClassBonusEquipement)

    'Dragodinde
    Public BloqueDragodinde As Threading.ManualResetEvent = New Threading.ManualResetEvent(False)

    'Métier

    Public Metier As New CMetier
    Public Recolte As New ClassRecolte

    'Guilde
    Public Guilde As New ClassGuilde

    'Pnj
    Public Pnj As New CPnj

    'Echange
    Public Echange As New CEchange

    'Ami
    Public Ami As New ClassAmi

    'Tchat
    Public Tchat As New ClassTchat

    Public Maison As New ClassMaison

End Class
