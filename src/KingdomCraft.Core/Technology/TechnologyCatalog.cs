using KingdomCraft.Core.Kingdom;

namespace KingdomCraft.Core.Technology;

/// <summary>
/// Công nghệ tối thiểu — công thức/công trình KHÔNG bị tech nào khóa thì mặc
/// định mở khóa sẵn (đồ gỗ cơ bản, đúng tinh thần Stone Age khởi đầu).
/// </summary>
public static class TechnologyCatalog
{
    public static readonly IReadOnlyList<TechnologyDefinition> All = new List<TechnologyDefinition>
    {
        new("stone_working", "Chế tác đá", goldCost: 20,
            unlocksRecipeIds: new[] { "craft_stone_axe", "craft_stone_pickaxe" },
            unlocksBuildingTypes: Array.Empty<BuildingType>()),

        new("commerce", "Thương mại", goldCost: 30,
            unlocksRecipeIds: Array.Empty<string>(),
            unlocksBuildingTypes: new[] { BuildingType.Market })
    };

    public static TechnologyDefinition? Find(string technologyId) =>
        All.FirstOrDefault(tech => tech.Id == technologyId);
}
