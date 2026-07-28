namespace KingdomCraft.Core.Items;

/// <summary>Định nghĩa tĩnh cho 1 loại vật phẩm — xem Docs/07_Items/ItemTypes.md.</summary>
public class ItemDefinition
{
    public string Id { get; }
    public string Name { get; }
    public ItemCategory Category { get; }

    public ItemDefinition(string id, string name, ItemCategory category)
    {
        Id = id;
        Name = name;
        Category = category;
    }
}
