Public Module Variable

    Public Delegate Sub DlgPlayer(index As Integer, ByVal data As String)

    Public ListOfBotName As New List(Of String)
    Public Comptes As New List(Of Player)
    Friend VarServeur As New Dictionary(Of String, ClassServeur)
    Public VarItems As New Dictionary(Of Integer, sItems)
    Public VarSort As New Dictionary(Of Integer, Dictionary(Of Integer, ClassSort))
    Public VarQuête As New Dictionary(Of Integer, String)
    Public VarMap As New Dictionary(Of Integer, String)
    Public VarInteraction As New Dictionary(Of Integer, sInteraction)
    Public VarRecolte As New Dictionary(Of Integer, sInteraction)
    Public VarMobs As New Dictionary(Of Integer, Dictionary(Of Integer, sMobs))
    Public VarPnj As New Dictionary(Of Integer, String)
    Public VarPnjRéponse As New Dictionary(Of Integer, String)
    Public VarMaison As New Dictionary(Of Integer, sMaison)
    Public VarMétier As New Dictionary(Of Integer, sMétier)
    Public VarFamilier As New Dictionary(Of Integer, Dictionary(Of String, sFamilier))
    Public VarCaractéristique As New Dictionary(Of String, Dictionary(Of String, String()))
    Public VarPersonnage As New Dictionary(Of String, sPersonnage)
    Public VarItemsCategorieNom As New Dictionary(Of Integer, String) From
        {
        {2, "Arc"},
        {3, "Baguette"},
        {4, "Baton"},
        {0, "Inconnu"}
        }
    Public VarDragodindeId As New Dictionary(Of Integer, String) From
        {
        {1, "Amande Sauvage"},
        {3, "Ebene"},
        {6, "Rousse Sauvage"},
        {9, "Ebene et Ivoire"},
        {10, "Rousse"},
        {11, "Ivoire et Rousse"},
        {12, "Ebene et Rousse"},
        {15, "Turquoise"},
        {16, "Ivoire"},
        {17, "Indigo"},
        {18, "Doree"},
        {19, "Pourpre"},
        {20, "Amande"},
        {21, "Emeraude"},
        {22, "Orchidee"},
        {23, "Prune"},
        {33, "Amande et Doree"},
        {34, "Amande et Ebene"},
        {35, "Amande et Emeraude"},
        {36, "Amande et Indigo"},
        {37, "Amande et Ivoire"},
        {38, "Amande et Rousse"},
        {39, "Amande et Turquoise"},
        {40, "Amande et Orchidee"},
        {41, "Amande et Pourpre"},
        {42, "Doree et Ebene"},
        {43, "Doree et Emeraude"},
        {44, "Doree et Indigo"},
        {45, "Doree et Ivoire"},
        {46, "Doree et Rousse"},
        {47, "Doree et Turquoise"},
        {48, "Doree et Orchidee"},
        {49, "Doree et Pourpre"},
        {50, "Ebene et Emeraude"},
        {51, "Ebene et Indigo"},
        {52, "Ebene et Turquoise"},
        {53, "Ebene et Orchidee"},
        {54, "Ebene et Pourpre"},
        {55, "Emeraude et Indigo"},
        {56, "Emeraude et Ivoire"},
        {57, "Emeraude et Rousse"},
        {58, "Emeraude et Turquoise"},
        {59, "Emeraude et Orchidee"},
        {60, "Emeraude et Pourpre"},
        {61, "Indigo et Ivoire"},
        {62, "Indigo et Rousse"},
        {63, "Indigo et Turquoise"},
        {64, "Indigo et Orchidee"},
        {65, "Indigo et Pourpre"},
        {66, "Ivoire et Turquoise"},
        {67, "Ivoire et Orchidee"},
        {68, "Ivoire et Pourpre"},
        {69, "Turquoise et Rousse"},
        {70, "Orchidee et Rousse"},
        {71, "Pourpre et Rousse"},
        {72, "Turquoise et Orchidee"},
        {73, "Turquoise et Pourpre"},
        {74, "Doree Sauvage"},
        {76, "Orchidee et Pourpre"},
        {77, "Prune et Amande"},
        {78, "Prune et Doree"},
        {79, "Prune et Ebene"},
        {80, "Prune et Emeraude"},
        {82, "Prune et Indigo"},
        {83, "Prune et Ivoire"},
        {84, "Prune et Rousse"},
        {85, "Prune et Turquoise"},
        {86, "Prune et Orchidee"},
        {87, "Prune et Pourpre"},
        {88, "En Armure"},
        {89, "a Plumes"}
        }

#Region "Structure"
    Structure sFamilier

        Dim NourritureId As List(Of Integer)
        Dim IntervalRepasMin As Integer
        Dim IntervalRepasMax As Integer
        Dim CapacitéNormal As Integer
        Dim CapacitéMax As Integer

    End Structure

    Structure sMétier

        Dim IdJob As Integer
        Dim Nom As String
        Dim Workshop As Dictionary(Of Integer, String())

    End Structure
    Structure sMaison

        Dim Nom As String
        Dim Map As String
        Dim CellulePorte As String
        Dim MapId As String

    End Structure

    Structure sMobs

        Dim ID As Integer
        Dim Nom As String
        Dim Niveau As Integer
        Dim RésistanceNeutre As Integer
        Dim RésistanceTerre As Integer
        Dim RésistanceFeu As Integer
        Dim RésistanceEau As Integer
        Dim RésistanceAir As Integer
        Dim EsquivePA As Integer
        Dim EsquivePM As Integer

    End Structure

    Structure sPersonnage

        Dim ID As Integer
        Dim Nom As String
        Dim Sexe As String

    End Structure

    Structure sItems

        Dim ID As Integer
        Dim Nom As String
        Dim Catégorie As Integer
        Dim Pods As Integer

    End Structure

    Structure sInteraction

        Dim IdSprite As Integer
        Dim Name As String
        Dim DicoInteraction As Dictionary(Of String, Integer)

    End Structure
#End Region


End Module
