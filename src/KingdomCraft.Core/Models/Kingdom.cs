namespace KingdomCraft.Core.Models;

public class Kingdom
{
    public string Name { get; set; }
    public Dictionary<ResourceType, int> Resources { get; } = new()
    {
        { ResourceType.Gold, 100 },
        { ResourceType.Wood, 50 },
        { ResourceType.Stone, 50 },
        { ResourceType.Food, 50 }
    };

    public List<Building> Buildings { get; } = new();
    public List<Unit> Army { get; } = new();

    public Kingdom(string name)
    {
        Name = name;
        Buildings.Add(new Building(BuildingType.TownHall));
    }

    public void AddResource(ResourceType type, int amount)
    {
        Resources[type] = Resources.GetValueOrDefault(type) + amount;
    }

    public bool TrySpend(ResourceType type, int amount)
    {
        if (Resources.GetValueOrDefault(type) < amount)
            return false;

        Resources[type] -= amount;
        return true;
    }
}
