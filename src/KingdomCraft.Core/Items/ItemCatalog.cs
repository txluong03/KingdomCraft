namespace KingdomCraft.Core.Items;

/// <summary>Danh mục item tối thiểu — xem Docs/07_Items/ItemTypes.md.</summary>
public static class ItemCatalog
{
    public static readonly IReadOnlyList<ItemDefinition> All = new List<ItemDefinition>
    {
        new("wood", "Gỗ", ItemCategory.Material),
        new("stone", "Đá", ItemCategory.Material),
        new("plank", "Ván gỗ", ItemCategory.Material),
        new("wooden_axe", "Rìu gỗ", ItemCategory.Tool),
        new("wooden_pickaxe", "Cuốc gỗ", ItemCategory.Tool),
        new("stone_axe", "Rìu đá", ItemCategory.Tool),
        new("stone_pickaxe", "Cuốc đá", ItemCategory.Tool)
    };

    public static ItemDefinition? Find(string itemId) =>
        All.FirstOrDefault(item => item.Id == itemId);
}
