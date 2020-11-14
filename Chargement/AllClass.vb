Friend Class ClassServeur

    Public Nom As String
    Public IP As String
    Public Port As Integer
    Public ID As String

End Class

Public Class ClassPersonnage

    Public NomDeCompte As String
    Public MotDePasse As String
    Public NomDuPersonnage As String
    Public Serveur As String
    Public Alignement As String = ""
    Public ID As Integer
    Public Pseudo As String = ""
    Public QuestionSecréte As String = ""
    Public Abonnement As Date = TimeOfDay
    Public Ticket As String
    Public Niveau As Integer
    Public ClasseSexe As Integer
    Public Classe As Integer
    Public Sexe As Integer
    Public IDServeur As Integer
    Public Kamas As Integer
    Public Régénération As Integer
    Public CapitalCaractéristique As Integer
    Public CapitalSort As Integer
    Public Expérience As New ClassExpérience
    Public Pods As New ClassPods
    Public Energie As New ClassEnergie
    Public Vitalité As New ClassVitalité
    Public Caractéristique As New Dictionary(Of String, ClassCaractéristique) From {
    {"initiative", New ClassCaractéristique},
    {"prospection", New ClassCaractéristique},
    {"pa", New ClassCaractéristique},
    {"pm", New ClassCaractéristique},
    {"force", New ClassCaractéristique},
    {"vitaliter", New ClassCaractéristique},
    {"sagesse", New ClassCaractéristique},
    {"chance", New ClassCaractéristique},
    {"agiliter", New ClassCaractéristique},
    {"intelligence", New ClassCaractéristique},
    {"po", New ClassCaractéristique},
    {"creature invocable", New ClassCaractéristique},
    {"dommage", New ClassCaractéristique},
    {"dommage physique", New ClassCaractéristique},
    {"maitrise arme", New ClassCaractéristique},
    {"dommage pr", New ClassCaractéristique},
    {"soin", New ClassCaractéristique},
    {"piege", New ClassCaractéristique},
    {"piege pr", New ClassCaractéristique},
    {"renvoi dommage", New ClassCaractéristique},
    {"coup critique", New ClassCaractéristique},
    {"echec critique", New ClassCaractéristique},
    {"esquive pa", New ClassCaractéristique},
    {"esquive pm", New ClassCaractéristique},
    {"resistance neutre pvm", New ClassCaractéristique},
    {"resistance neutre pvm pr", New ClassCaractéristique},
    {"resistance neutre pvp", New ClassCaractéristique},
    {"resistance neutre pvp pr", New ClassCaractéristique},
    {"resistance terre pvm", New ClassCaractéristique},
    {"resistance terre pvm pr", New ClassCaractéristique},
    {"resistance terre pvp", New ClassCaractéristique},
    {"resistance terre pvp pr", New ClassCaractéristique},
    {"resistance eau pvm", New ClassCaractéristique},
    {"resistance eau pvm pr", New ClassCaractéristique},
    {"resistance eau pvp", New ClassCaractéristique},
    {"resistance eau pvp pr", New ClassCaractéristique},
    {"resistance air pvm", New ClassCaractéristique},
    {"resistance air pvm pr", New ClassCaractéristique},
    {"resistance air pvp", New ClassCaractéristique},
    {"resistance air pvp pr", New ClassCaractéristique},
    {"resistance feu pvm", New ClassCaractéristique},
    {"resistance feu pvm pr", New ClassCaractéristique},
    {"resistance feu pvp", New ClassCaractéristique},
    {"resistance feu pvp pr", New ClassCaractéristique}
}
    Public Dragodinde As New ClassDragodindeEquipé
End Class

#Region "Dragodinde"

Public Class ClassDragodindeEquipé

    Public Equipé As Boolean = False
    Public XpDonnee As Integer
    Public Information As New ClassDragodinde

End Class

Public Class ClassDragodinde

    Public IdUnique As Integer
    Public ID As Integer
    Public ArbreGénéalogique As String
    Public Capacité1, Capacité2 As String
    Public Nom, NomDragodinde As String
    Public Sexe As String
    Public ExpActuelle As Integer
    Public ExpMinimum As Integer
    Public ExpMaximum As Integer
    Public Niveau As Integer
    Public Montable As Boolean
    Public Endurance, EnduranceMax As Integer
    Public Maturité, MaturitéMax As Integer
    Public Energie, EnergieMax As Integer
    Public Amour, AmourMax As Integer
    Public Agressivité, Equilibré, Serein As Integer
    Public Fécondation As String
    Public Fatigue, FatigueMax As Integer
    Public Reproduction, ReproductionMax As Integer
    Public PodsActuelle, PodsMaximum As Integer
    Public Caractéristique As New ClassItemCaractéristique

End Class

#End Region




Public Class ClassInteraction

    Public Cellule As Integer
    Public Sprite As Integer
    Public Nom As String
    Public Information As String
    Public Action As New Dictionary(Of String, Integer)

End Class

Public Class ClassCaractéristique

    Public Base As String
    Public Equipement As String
    Public Dons As String
    Public Boost As String
    Public Total As String

End Class

Public Class ClassExpérience

    Public Minimum As Integer
    Public Maximum As Integer
    Public Actuelle As Integer
    Public Pourcentage As Integer

End Class

Public Class ClassVitalité

    Public Maximum As Integer = 55
    Public Actuelle As Integer = 0
    Public Pourcentage As Integer = 0

End Class

Public Class ClassEnergie

    Public Maximum As Integer
    Public Actuelle As Integer
    Public Pourcentage As Integer

End Class

Public Class ClassPods

    Public Maximum As Integer
    Public Actuelle As Integer
    Public Pourcentage As Integer

End Class

Public Class ClassItem

    Public IdObjet As Integer = 0
    Public IdUnique As Integer = 0
    Public Nom As String = ""
    Public Quantité As Integer = 0
    Public Caractéristique As New ClassItemCaractéristique
    Public CaractéristiqueBrute As String = ""
    Public Equipement As String = ""
    Public Catégorie As Integer = 0

End Class

Public Class ClassBonusEquipement

    Public NuméroPanoplie As Integer
    Public IDObjet As String()
    Public Caractéristique As ClassItemCaractéristique
    Public CaractéristiqueBrute As String

End Class

Public Class ClassItemCaractéristique

    Public VoleAir As String = "-999 à 999"
    Public DommageEau As String = "-999 à 999"
    Public DommageFeu As String = "-999 à 999"
    Public DommageTerre As String = "-999 à 999"
    Public DommageAir As String = "-999 à 999"
    Public DommageNeutre As String = "-999 à 999"
    Public PertePA As String = "-999 à 999"
    Public Pdv As String = "-999 à 999"
    Public Force As String = "-999 à 999"
    Public Vitalité As String = "-999 à 999"
    Public Sagesse As String = "-999 à 999"
    Public Intelligence As String = "-999 à 999"
    Public Chance As String = "-999 à 999"
    Public Agilité As String = "-999 à 999"
    Public PA As String = "-999 à 999"
    Public PM As String = "-999 à 999"
    Public PO As String = "-999 à 999"
    Public Invocation As String = "-999 à 999"
    Public Initiative As String = "-999 à 999"
    Public Prospection As String = "-999 à 999"
    Public Pods As String = "-999 à 999"
    Public CC As String = "-999 à 999"
    Public Dommage As String = "-999 à 999"
    Public PcDommage As String = "-999 à 999"
    Public DommagePiege As String = "-999 à 999"
    Public PcDommagePiege As String = "-999 à 999"
    Public Soin As String = "-999 à 999"
    Public ResistanceTerre As String = "-999 à 999"
    Public ResistanceEau As String = "-999 à 999"
    Public ResistanceFeu As String = "-999 à 999"
    Public ResistanceAir As String = "-999 à 999"
    Public ResistanceNeutre As String = "-999 à 999"
    Public PcResistanceTerre As String = "-999 à 999"
    Public PcResistanceEau As String = "-999 à 999"
    Public PcResistanceFeu As String = "-999 à 999"
    Public PcResistanceAir As String = "-999 à 999"
    Public PcResistanceNeutre As String = "-999 à 999"
    Public Cac As String = "-999 à 999"
    Public PierreAme As List(Of String)
    Public Puissance As String = "-999 à 999"
    Public FamilierPdv As String = "-999 à 999"
    Public FamilierRepas As Integer = 0
    Public FamilierCorpulence As String = "Normal"
    Public FamilierDernierRepas As String = "Aliment Inconnu"
    Public FamilierDateRepas As Date = TimeOfDay
    Public FamilierCapaciteAccrue As Boolean = False
    Public ResistanceItem As String = "-999 à 999"
    Public DragodindeDate As String = ""
    Public DragodindeIdUnique As String = ""
    Public DragodindePossesseur As String = ""
    Public DragodindeNom As String = ""
    Public DragodindeDateEnParchemin As Date = TimeOfDay

End Class

Public Class ClassCanal

    Public Information As Boolean
    Public Général As Boolean
    Public GroupePrivéeEquipe As Boolean
    Public Guilde As Boolean
    Public Alignement As Boolean
    Public Recrutement As Boolean
    Public Commerce As Boolean

End Class

Public Class ClassSort

    Public ID As Integer
    Public Niveau As Integer
    Public Nom As String
    Public POMinimum As Integer
    Public POMaximum As Integer
    Public PA As Integer
    Public NombreLancerParTour As Integer
    Public NombreLancerParTourParJoueur As Integer
    Public NombreToursEntreDeuxLancers As Integer
    Public POModifiable As Boolean
    Public LigneDeVue As Boolean
    Public LancerEnLigne As Boolean
    Public CelluleLibre As Boolean
    Public ECFiniTour As Boolean
    Public ZoneMinimum As Integer
    Public ZoneMaximum As Integer
    Public ZoneEffet As String
    Public NiveauRequisUp As Integer
    Public SortClasse As String
    Public Definition As String
    Public BarreSort As String

End Class

Public Class ClassQuête

    Public Nom As String
    Public ID As Integer

End Class

#Region "Map"

Public Class ClassMapObjet

    Public Cellule As Integer
    Public IdUnique As Integer
    Public Nom As String
    Public RésistanceMinimum As Integer
    Public Id As String
    Public RésistanceMaximum As Integer

End Class

Public Class ClassMap

    Public IDUnique As Integer
    Public Cellule As Integer
    Public Nom As String
    Public Niveau As String
    Public ID As String
    Public Etoile As Integer
    Public Classe As String
    Public Sexe As String
    Public Guilde As String
    Public ModeMarchand As Boolean
    Public Alignement As String
    Public Combat As New ClassMapCombat

End Class

Public Class ClassMapCombatLancer

    Public idUnique As Integer
    Public Id As Integer
    Public Nom As String
    Public Niveau As Integer

End Class

#End Region

Public Class ClassMétier

    Public Nom As String
    Public ID As Integer
    Public Niveau As Integer
    Public ItemEquipé As Boolean
    Public ExpérienceMinimum As Integer
    Public ExpérienceActuelle As Integer
    Public ExpérienceMaximum As Integer

    Public NeFournitAucuneRessource As Boolean
    Public GratuitSurEchec As Boolean
    Public Payant As Boolean
    Public NombreIngrédientMinimum As Integer
    Public ModePublic As Boolean

    Public AtelierRessource As New Dictionary(Of String, ClassMétierAtelierRessource)

End Class

Public Class ClassMétierAtelierRessource

    Public Nom As String
    Public ID As Integer
    Public NomAction As String
    Public NombreCaseRécolteMinimum As Integer
    Public NombreCaseRécolteMaximum As Integer
    Public TempsRéussite As Integer

End Class

Public Class ClassMaison

    Public Propriétaire As String
    Public ID As Integer
    Public Vérouiller As Boolean
    Public EnVente As Boolean
    Public EnGuilde As Boolean
    Public GuildeNom As String
    Public CellulePorte As Integer
    Public MapID As Integer
    Public Coordonnées As String
    Public Prix As Integer
    Public Code As Integer

End Class

Public Class ClassCoffre

    Public Vérouiller As Boolean
    Public CelluleCoffre As Integer
    Public MapID As Integer
    Public Coordonnées As String
    Public Code As Integer

End Class

Public Class ClassEnclo

    Public ID As Integer
    Public Guilde As String
    Public Prix As Integer
    Public NbrMaxDragodinde As Integer
    Public NbrMaxObjet As Integer

End Class


#Region "Combat"

Public Class ClassChallenge

    Public Nom As String
    Public Raté As Boolean
    Public Xp As Integer
    Public XpGroupe As Integer
    Public Butin As Integer
    Public ButinGroupe As Integer

End Class

Public Class ClassMapCombat

    Public Prêt As Boolean
    Public OrdreTour As Integer
    Public Vivant As Boolean
    Public Vitalité As Integer
    Public PA As Integer
    Public PM As Integer
    Public RésistanceEau As Integer
    Public RésistanceFeu As Integer
    Public RésistanceTerre As Integer
    Public RésistanceAir As Integer
    Public RésistanceNeutre As Integer
    Public EsquivePA As Integer
    Public EsquivePM As Integer
    Public NuméroTour As Integer
    Public Etat As String
    Public Equipe As Integer

End Class
#End Region

Public Class ClassDivers

    Public Function Pause(ByVal index As String, ByVal minimum As String, ByVal maximum As String)

        Dim rand As New Random

        Task.Delay(rand.Next(minimum, maximum)).Wait()

    End Function

End Class

#Region "Guilde"

Public Class ClassGuilde

    Public Niveau As String
    Public ExpMinimum As String
    Public ExpMaximum As String
    Public ExpActuelle As String
    Public Membre As New Dictionary(Of String, ClassGuildeJoueur)
    Public Percepteur As ClassGuildePercepteur
    Public Enclos As New Dictionary(Of String, ClassGuildeEnclos)
    Public Maison As New Dictionary(Of String, ClassGuildeMaison)

End Class

Public Class ClassGuildeJoueur

    Public Classe As String
    Public Nom As String
    Public IdUnique As String
    Public Rang As String
    Public RangChiffre As Integer
    Public Niveau As String
    Public PrXp As String
    Public Connecté As Boolean
    Public XpGagnée As String
    Public Alignement As String
    Public Droit As ClassGuildeDroit
    Public DroitChiffre As Integer
    Public DernièreConnection As String

End Class

Public Class ClassGuildeDroit

    Public GererLesBoosts As Boolean
    Public GererLesDroits As Boolean
    Public InviterDeNouveauxMembres As Boolean
    Public Bannir As Boolean
    Public GererLesRepartitionsXP As Boolean
    Public GererSaRepartitionXP As Boolean
    Public GererLesRangs As Boolean
    Public PoserUnPercepteur As Boolean
    Public CollecterSurUnPercepteur As Boolean
    Public UtiliserLesEnclos As Boolean
    Public AmenagerLesEnclos As Boolean
    Public GererLesMonturesDesAutresMembres As Boolean

End Class

Public Class ClassGuildePercepteur

    Public PointsDeVie As String
    Public BonusAuxDommages As String
    Public Prospection As String
    Public Sagesse As String
    Public Pods As String
    Public NombreDePercepteur As String
    Public ResteARepartir As String
    Public ActuellementPercepteur As String
    Public CoûtPourPoserPercepteur As String

    'Spell
    Public ArmureAqueuse As String
    Public ArmureIncandescente As String
    Public ArmureTerrestre As String
    Public ArmureVenteuse As String
    Public Flamme As String
    Public Cyclone As String
    Public Vague As String
    Public Rocher As String
    Public MotSoignant As String
    Public Desenvoutement As String
    Public CompulsionDeMasse As String
    Public Destabilisation As String

End Class

Public Class ClassGuildeEnclos

    Public MapID As Integer
    Public Position As String
    Public DragodindeActuelle As Integer
    Public DragodindeMaximum As Integer

End Class

Public Class ClassGuildeMaison

    Public MaisonVisiblePourGuilde As Boolean = False
    Public BlasonVisiblePourGuilde As Boolean = False
    Public BlasonVisiblePourToutMonde As Boolean = False
    Public AccesAutoriserMembreGuilde As Boolean = False
    Public AccesInterditNonMembreGuilde As Boolean = False
    Public AccesCoffresAutoriseMembreGuilde As Boolean = False
    Public AccesCoffresInterditNonMembreGuilde As Boolean = False
    Public TeleportationAutoriser As Boolean = False
    Public ReposAutoriser As Boolean = False

    Public ID As Integer
    Public Proriétaire As String
    Public Position As String
    Public Compétence As String

End Class
#End Region

#Region "Groupe"

Public Class ClassGroupe

    Public IdUnique As Integer
    Public Nom As String
    Public ClasseSexe As Integer
    Public Couleur1, Couleur2, Couleur3 As String
    Public Cac, Coiffe, Cape, Familier, Bouclier As String
    Public PdvActuel, PdvMaximum As Integer
    Public Niveau As Integer
    Public Initiative As Integer
    Public Prospection As Integer
End Class

#End Region

#Region "HDV"

Public Class ClassHDV

    Public Quantiter1, Quantiter10, Quantiter100 As Boolean
    Public ListeIdCatégorie As New List(Of Integer)
    Public ListeIdItem As New List(Of Integer)
    Public Taxe As Integer
    Public NiveauMax As Integer
    Public NbrItemVendable As Integer
    Public HeureMax As Integer
    Public PrixMoyen As Integer
    Public ListeItem As New Dictionary(Of Integer, ClassHDVItem)

End Class

Public Class ClassHDVItem

    Public IDUnique As Integer
    Public Caracteristique As New ClassItemCaractéristique
    Public Prix1, Prix10, Prix100 As Integer
    Public IdObjet As Integer
    Public TempsRestant As Integer
    Public Prix As Integer
    Public Quantiter As Integer

End Class

#End Region