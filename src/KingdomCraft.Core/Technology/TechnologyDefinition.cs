using KingdomCraft.Core.Kingdom;

namespace KingdomCraft.Core.Technology;

/// <summary>Định nghĩa 1 công nghệ — xem Docs/02_GDD/TechnologyTree.md.</summary>
public class TechnologyDefinition
{
    public string Id { get; }
    public string Name { get; }
    public int GoldCost { get; }
    public IReadOnlyList<string> UnlocksRecipeIds { get; }
    public IReadOnlyList<BuildingType> UnlocksBuildingTypes { get; }

    public TechnologyDefinition(
        string id,
        string name,
        int goldCost,
        IReadOnlyList<string> unlocksRecipeIds,
        IReadOnlyList<BuildingType> unlocksBuildingTypes)
    {
        Id = id;
        Name = name;
        GoldCost = goldCost;
        UnlocksRecipeIds = unlocksRecipeIds;
        UnlocksBuildingTypes = unlocksBuildingTypes;
    }
}
