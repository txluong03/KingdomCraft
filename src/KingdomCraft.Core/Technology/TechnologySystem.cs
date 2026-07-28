using KingdomCraft.Core.Kingdom;

namespace KingdomCraft.Core.Technology;

public class TechnologySystem
{
    public bool IsRecipeUnlocked(KingdomState kingdom, string recipeId)
    {
        var gatingTech = TechnologyCatalog.All.FirstOrDefault(tech => tech.UnlocksRecipeIds.Contains(recipeId));
        return gatingTech is null || kingdom.ResearchedTechnologyIds.Contains(gatingTech.Id);
    }

    public bool IsBuildingUnlocked(KingdomState kingdom, BuildingType type)
    {
        var gatingTech = TechnologyCatalog.All.FirstOrDefault(tech => tech.UnlocksBuildingTypes.Contains(type));
        return gatingTech is null || kingdom.ResearchedTechnologyIds.Contains(gatingTech.Id);
    }

    public bool TryResearch(KingdomState kingdom, string technologyId)
    {
        var tech = TechnologyCatalog.Find(technologyId);
        if (tech is null || kingdom.ResearchedTechnologyIds.Contains(technologyId))
            return false;

        if (!kingdom.Resources.TrySpend("gold", tech.GoldCost))
            return false;

        kingdom.ResearchedTechnologyIds.Add(technologyId);
        return true;
    }
}
